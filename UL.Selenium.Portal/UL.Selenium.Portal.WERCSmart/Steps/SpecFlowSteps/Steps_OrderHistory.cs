using Reqnroll;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System;
using System.IO;
using UL.Automation.ReqnrollHelpers.Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "OrderHistoryPage")]
	class Steps_OrderHistory
	{
		[RegexStepDefinition(@"In the Order History section, Click on (Subscription|WERCSmart)")]
		public void ClickTheOrderHistoryLink(string linkText)
		{
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the Order History section, Click 'Filter' button")]
		public void ClickFlterButton()
		{
			string button = "Filter";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Order History section, Click 'Clear Filter' button")]
		public void ClickClearFlterButton()
		{
			string button = "Clear Filter";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Order History section, Verify 'WERCSmart' table is displayed")]
		public void VerifyWERCSmartTableIsDisplayed()
		{
			Report.IsTrue(new OrderHistoryPage().TableExists(), $"WERCSmart table is not displayed", $"Successfully WERCSmart table is displayed");
		}

		[RegexStepDefinition(@"In the Order History section, Verify 'Subscription' table is displayed")]
		public void VerifySubscriptionTableIsDisplayed()
		{
			Report.IsTrue(new OrderHistoryPage().TableExists(), $"Subscription table is not displayed", $"Successfully Subscription table is displayed");
		}

		[RegexStepDefinition(@"In the Order History section, click action (View details|Close) for order number: (.*)")]
		public void ClickActionForOrder(string ordernumber, string action)
		{
			Report.IsTrue(new OrderHistoryPage().ClickAction(ordernumber, action),
				$"Failed to click action:{action} for order: {ordernumber}",
				$"Successfully clicked action: {action} for order: {ordernumber}");
		}



		[RegexStepDefinition(@"In the Order History section, Filter by 'WPS ID/Product name' for value: (.*)")]
		public void FilterByWPSIDProduct(string value)
		{
			string fieldname = "WPS ID";
			new OrderHistoryPage().EnterText(fieldname, value);
			new Steps_Prototype().ClickButton("Filter");
		}

		[RegexStepDefinition(@"In the Order History section, Filter by 'Order #' for value: (.*)")]
		public void FilterByOrderProduct(string value)
		{
			string fieldname = "Order";
			new OrderHistoryPage().EnterText(fieldname, value);
			new Steps_Prototype().ClickButton("Filter");
		}


		[RegexStepDefinition(@"In the Order History section, in the 'Report Download' pop up click 'Close' button")]
		public void ClickYesNoCancelPopUp()
		{
			string popupTitle = "Report Download";
			string button = "Close";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}

		[RegexStepDefinition(@"In the Order History section, the 'Report Download' popup (should|should not) be displayed")]
		public void AreYouSureYouWishToCancelIsDisplayed(string condition)
		{
			string modalTitle = "Report Download";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}


		[RegexStepDefinition(@"In the Order History section, Verify 'View Details' is displayed")]
		public void VerifyViewDetailsIsDisplayed()
		{

			Report.IsTrue(new OrderHistoryPage().ViewDetailsIsDisplayed(), "View Details is not displayed", "Successfully View Details is displayed");

		}

		[RegexStepDefinition(@"In the Order History sectionn, From the Filter By dropdown - I select option: (All|Payment Pending|Payment Failed|Payment Received|Completed|Cancelled)")]
		public void FilterByDropdownSelectOption(string optionValue)
		{
			OrderHistoryPage orderHistoryPage = new OrderHistoryPage();
			Report.IsTrue(orderHistoryPage.FilterByDropdownExists(), $"Failed, Sub Format type dropdown is not displayed", $"Successfully displayed Sub Format type dropdown");
			Report.IsTrue(orderHistoryPage.FilterByDropdownClick(), $"Failed to click Sub Format type dropdown", $"Successfully clicked Sub Format type dropdown ");
			Report.IsTrue(orderHistoryPage.FilterByDropdownOptionExists(optionValue), $"Failed, Sub Format type dropdown option {optionValue} is not displayed", $"Successfully displayed Sub Format type dropdown option {optionValue}");
			Report.IsTrue(orderHistoryPage.FilterByDropdownOptionClick(optionValue), $"Failed to click option {optionValue} in Sub Format type dropdown", $"Successfully clicked option {optionValue} in Sub Format type dropdown");
		}


		[RegexStepDefinition(@"In the Order History section, currently on page number: (.*)")]
		public void OrderIsActiveOnPageNumber(string expectedPage)
		{
			var order = new OrderHistoryPage();
			string activePage = order.OrderActivePage();
			Report.IsTrue(activePage == expectedPage,
				$"The Order History is not on the expected page:  {expectedPage}. It is on page: {activePage}",
				$"The Order History is on the expected page:  {expectedPage}");
		}
		#region Pagiation Button Steps
		[RegexStepDefinition(@"In the Order History section, confirm (Prev|…|Next) Pagination button (does|does not) exist")]
		public void OrderHistoryPageConfirmPagiationButtonDoesDoesNotExist(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {does_doesnot} exist.", $"Success, confirmed {buttonLabel} pagination button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Order History section, click (Prev|…|Next) Pagination button")]
		public void OrderHistoryPageClickPagiationButton(string buttonLabel)
		{
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(myProductTableFooter.PaginationButtonClick(buttonLabel), $"Failure, failed to click {buttonLabel} pagination button.", $"Success, click {buttonLabel} pagination button currently selected.");
			}
		}

		[RegexStepDefinition(@"In the Order History section, confirm (Prev|…|Next) Pagination button (is|is not) disabled")]
		public void OrderHistoryPageConfirmPagiationButtonIsIsNotDisabled(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonDisabled(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} disabled.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} disabled.");
			}
		}

		[RegexStepDefinition(@"In the Order History section, confirm (Prev|…|Next) Pagination button (is|is not) currently selected")]
		public void OrderHistoryConfirmPagiationButtonIsIsNotSelected(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonCurrent(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} currently selected.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} currently selected.");
			}
		}
		#endregion

		[RegexStepDefinition(@"I confirm that a file is downloaded with file name: (.*) then close the Report Download popup. I save the file as (.*)")]
		public void ReportPdfIsDownloaded(string file, string savedAs)
		{
			var selReportDownload = new ReportDownload();
			if (selReportDownload.Wait_for_load())
			{
				int count = 0;
				Report.Info("Confirm file is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				while (count < 120)
				{
					string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
					if (dir.Any())
					{
						Report.Success("File with name: " + dir.FirstOrDefault() + " was found in the download directory");
						Report.Info("Closing the Report Download popup");
						Report.IsTrue(selReportDownload.ClickClose(),
							"Failed to close the Report Download popup",
							"Successfully closed the Report Download popup");
						Context.AddToContext(savedAs, dir.FirstOrDefault());
						return;
					}
					Delay.Seconds(1);
					count++;
				}
				Report.Failure("Unable to find file: '" + file + "' in the download directory after 120 seconds");
				Report.Info("Closing the Report Download popup");
				Report.IsTrue(selReportDownload.ClickClose(),
					"Failed to close the Report Download popup",
					"Successfully closed the Report Download popup");
			}
		}
	}


}


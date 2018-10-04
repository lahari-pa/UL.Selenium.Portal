using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using NPOI.SS.Formula.Functions;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;


namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "SHA")]
	class Steps_SHA
	{
		[Given(@"I navigate to Studio")]
		public void GivenINavigateToStudio()
		{
			SeleniumBrowser.WebBrowser.Url = TReVor.TestVariables.GetVariableSavedAs("SHAUrl");
			SeleniumBrowser.WebBrowser.WaitForPageLoad();

		}

		[Given(@"I navigate to Portal")]
		public void GivenINavigateToPortal()
		{
			SeleniumBrowser.WebBrowser.Url = GlobalParameters.TestUrl;
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
		}


		[Given(@"I login to Studio as Administrator")]
		public void GivenILoginToStudioAsAdministrator()
		{
			StudioLogin thisStudioLogin = new StudioLogin();
			var shaUser = TReVor.TestUsers.GetUserSavedAs("SHAUser");
			thisStudioLogin.Username = shaUser.Username;
			thisStudioLogin.Password = shaUser.Password;
			thisStudioLogin.ClickSignIn();
			Delay.Seconds(3);
			StudioDesktop thisStudioDesktop = new StudioDesktop();
			Report.IsTrue(thisStudioDesktop.Wait_for_load(30), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
			Report.Info("Studio desktop is loaded");
			StudioTopMenu thisStudioTopMenu = new StudioTopMenu();
			Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");
		}

		[Given(@"I click top menu item: (.*) and submenu item: (.*)")]
		public void GivenIClickTopMenuItemAndSubMenuItem(string menuItem, string submenuItem)
		{
			StudioTopMenu thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(30), "Top menu has not loaded", "Top menu has loaded");
			Report.IsTrue(thisTopMenu.ClickSubMenu(menuItem, submenuItem), "Failed to click: " + menuItem,
				"Successfully clicked: " + menuItem);
		}

		[Given(@"In SHA Manager Page I click top menu item: (.*)")]
		public void GivenInSHAManagerPageIClickTopMenuItem(string menuItem)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			Report.IsTrue(thisShaManager.ClickTopMenuItem(menuItem), "Failed to click: " + menuItem,
				"Successfully clicked: " + menuItem);
		}

		[Given(@"In SHA Manager Page I click sub menu item: (.*)")]
		public void GivenInSHAManagerPageIClickSubMenuItem(string menuItem)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			for (int i = 0; i < 5; i++)
			{
				Report.Info("Attempt " + i.ToString());
				if (thisShaManager.ClickActionsMenuOption(menuItem))
				{
					Report.Success("Successfully clicked: " + menuItem);
					return;
				}
				Delay.Seconds(1);
			}
			Report.Failure("Failed to click: " + menuItem);
		}

		[Given(@"In the the Manage Global Messages dialog I add and save the following messages:")]
		public void GivenIAddTheFollowingMessages(Table table)
		{
			StudioManageGlobalMessages thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
			Report.IsTrue(thisStudioManageGlobalMessages.Wait_for_load(),
				"Manage Global Messages dialog is not showing", "Manage global messages dialog is showing");
			List<Message> ListOfMessages = new List<Message>();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Message thisMessage = new Message();
				thisMessage.Title = thisRow["Title"];

				if (thisRow["Message"] == "generated")
				{
					thisMessage.MessageBody = System.Guid.NewGuid().ToString();
				}
				else
				{
					thisMessage.MessageBody = thisRow["Message"];
				}

				thisMessage.Type = thisRow["Type"];
				thisMessage.Active = (thisRow["Active"].ToLower() == "true");
				thisMessage.Level = thisRow["Level"];
				ListOfMessages.Add(thisMessage);
				Report.IsTrue(thisStudioManageGlobalMessages.AddMessage(thisMessage), "Successfully added message",
					"Failed to add message");
			}

			Context.AddToContext("Messages", ListOfMessages);
		}

		[Given(@"I close the Manage Global Messages dialog")]
		public void GivenICloseTheManageGlobalMessagesDialog()
		{
			StudioManageGlobalMessages thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
			Report.IsTrue(thisStudioManageGlobalMessages.ClickCloseButton(), "Failed to close messages dialog",
				"Successfully closed messages dialog");
		}

		[Given(@"In SHA Manager Page I select status: (.*)")]
		public void GivenInSHAManagerPageISelectStatus(string status)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			Report.IsTrue(thisShaManager.SelectFromStatusFilter(status), "Failed to select status: " + status,
				"Successfully selected status: " + status);
		}





		//|Status|Client|SearchPattern|ProductId|ProductName|DateRange|LastActivityDate|Supplier|User|Reviewer|OnSuspended|RecertificationActive|GGOnlyProducts|ECommFlowProducts|TReg|OrderNo|SubmissionDate|UPC|ParentUPC|

		[Given(@"In SHA Manager ProductSearch page I run search:")]
		public void GivenInSHAManagerPageIRunSearch(TechTalk.SpecFlow.Table table)
		{
			StudioSHAManagerProductSearch thisProductSearch = new StudioSHAManagerProductSearch();
			Report.IsTrue(thisProductSearch.Wait_for_load(60), "Product search page has not loaded",
				"Product search page has loaded as expected");
			var x = table.Rows.ToDictionary(r => r[0], r => r[1]);
			for (int i = 0; i < x.Count; i++)
			{
				Delay.Seconds(1);
				switch (x.Keys.ElementAt(i))
				{
					case "Status":
						Report.IsTrue(thisProductSearch.SelectFromStatusFilter(x.Values.ElementAt(i)),
							"Failed to set status to: " + x.Values.ElementAt(i), "Successfully set status");
						break;
					case "Client":
						Report.IsTrue(thisProductSearch.SelectFromClientFilter(x.Values.ElementAt(i)),
							"Failed to set client", "Successfully set client");
						break;
					case "SearchPattern":
						Report.IsTrue(thisProductSearch.SelectFromSearchPatternFilter(x.Values.ElementAt(i)),
							"Failed to set search pattern", "Successfully set search pattern");
						break;
					case "ProductID":
					case "ProductId":
						Report.IsTrue(thisProductSearch.EnterProductID(x.Values.ElementAt(i)),
							"Failed to set product id", "Successfully set product id");
						break;
					case "ProductName":
						Report.IsTrue(thisProductSearch.EnterProductName(x.Values.ElementAt(i)),
							"Failed to set product name", "Successfully set product name");
						break;
					case "DateRange":
						Report.IsTrue(thisProductSearch.SelectFromDateRangeFilter(x.Values.ElementAt(i)),
							"Failed to set date range", "Successfully set date range");
						break;
					case "DateFrom":
						Report.IsTrue(thisProductSearch.EnterDateFrom(x.Values.ElementAt(i)),
							"Failed to set date range", "Successfully set date range");
						break;
					case "DateTo":
						Report.IsTrue(thisProductSearch.EnterDateTo(x.Values.ElementAt(i)),
							"Failed to set date range", "Successfully set date range");
						break;
					case "LastActivityDate":
						Report.IsTrue(thisProductSearch.EnterLastActivityDate(x.Values.ElementAt(i)),
							"Failed to set activity date", "Successfully set activity date");
						break;
					case "Supplier":
						Report.IsTrue(thisProductSearch.EnterSupplier(x.Values.ElementAt(i)),
							"Failed to set supplier", "Successfully set supplier");
						break;
					case "User":
						Report.IsTrue(thisProductSearch.EnterUser(x.Values.ElementAt(i)),
							"Failed to set user", "Successfully set user");
						break;
					case "Reviewer":
						Report.IsTrue(thisProductSearch.EnterReviewer(x.Values.ElementAt(i)),
							"Failed to set reviewer", "Successfully set reviewer");
						break;
					case "OnSuspended":
						Report.IsTrue(thisProductSearch.CheckOnSuspended(x.Values.ElementAt(i) == "true"),
							"Failed to set on suspended", "Successfully set on suspended");
						break;
					case "RecertificationActive":
						Report.IsTrue(thisProductSearch.CheckRecertificationActive(x.Values.ElementAt(i) == "true"),
							"Failed to set recertification active", "Successfully set recertification active");
						break;
					case "GGOnlyProducts":
						Report.IsTrue(thisProductSearch.CheckGoodGuideOnlyProducts(x.Values.ElementAt(i) == "true"),
							"Failed to set Good Guide only products", "Successfully set Good Guide only products");
						break;
					case "ECommFlowProducts":
						Report.IsTrue(thisProductSearch.CheckECommFlowProducts(x.Values.ElementAt(i) == "true"),
							"Failed to set EComm flow products", "Successfully set EComm flow products");
						break;
					case "TReg":
						Report.IsTrue(thisProductSearch.SelectFromTRegFilter(x.Values.ElementAt(i)),
							"Failed to set TReg", "Successfully set TReg");
						break;
					case "OrderNo":
						Report.IsTrue(thisProductSearch.EnterOrderNo(x.Values.ElementAt(i)),
							"Failed to set order no", "Successfully set order no");
						break;
					case "SubmissionDate":
						Report.IsTrue(thisProductSearch.EnterSubmissionDate(x.Values.ElementAt(i)),
							"Failed to set submission date", "Successfully set submission date");
						break;
					case "UPC":
						Report.IsTrue(thisProductSearch.EnterUPC(x.Values.ElementAt(i)),
							"Failed to set upc", "Successfully set upc");
						break;
					case "ParentUPC":
						Report.IsTrue(thisProductSearch.EnterParentUPC(x.Values.ElementAt(i)),
							"Failed to set parent upc", "Successfully set parent upc");
						break;
					default:
						throw new Exception("Invalid column name");
				}
			}
			Report.Screenshot();
			Delay.Seconds(1);
			Report.IsTrue(thisProductSearch.ClickButton("Find"), "Failed to click find", "Clicked find");
			Delay.Seconds(1);
			Report.Info("Waiting for spinner");
			GeneralUtilities.StudioWaitForSpinner();
			Report.Info("Finished waiting for spinner");

		}

		[Given(@"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its status is: (.*)")]
		public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(string productSavedAs, string status)
		{
			TestReport.UseSubSteps = true;
			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			var ID = ProductDetails.Id;

			//rerun search until status is as expected or give up
			int counter = 0;

			while (counter < 100)
			{
				Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

				if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
				{
					Report.Info("Re-running search");
					StudioSHAManager myStudioShaManager = new StudioSHAManager();

					myStudioShaManager.ClickBottomMenuOption("Search");

					Steps_SHA myStepsSha = new Steps_SHA();

					TechTalk.SpecFlow.Table table = new TechTalk.SpecFlow.Table(new string[] {
						"SearchTerm",
						"SearchValue"});
					table.AddRow(new string[] {
						"ProductID",
						ID});
					table.AddRow(new string[] {
						"Status",
						status});
					myStepsSha.GivenInSHAManagerPageIRunSearch(table);

					Delay.Seconds(2);
					StudioSHAManager mySHAManager = new StudioSHAManager();
					mySHAManager.WaitForProductList(120);
					/*
					topProduct = mySHAManager.GetTopXProducts(1).FirstOrDefault();
					if (topProduct != null)
					{
						if (topProduct.ID == ID && topProduct.Status == status)
						{
							Report.Info("Got match");
							break;
						}

						Report.Info(counter + ": status is: " + status);
					}
					*/
					Delay.Seconds(2);
					counter++;
				}
				else
				{
					break;
				}

			}

			var topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
			if (topProductnew != null)
			{
				Report.IsTrue(topProductnew.ID == ID && topProductnew.Status == status, "Expected: id=" + ID + " and status " + status + " but got: " + topProductnew.ID + " and " + topProductnew.Status, "Statuses match");
			}
			else
			{
				Report.Failure("No products found");
			}

		}

	}
}

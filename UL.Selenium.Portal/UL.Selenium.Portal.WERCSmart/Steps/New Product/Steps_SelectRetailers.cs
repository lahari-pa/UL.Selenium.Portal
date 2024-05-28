using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsSelectRetailers
	{
		[RegexStepDefinition(@"I should see the Select Retailers pop up")]
		[RegexStepDefinition(@"the 'Select Retailers' window appears")]
		public void GivenIShouldSeeTheSelectRetailersPopUp()
		{
			var selSelectRetailers = new SelectRetailers();	
			new Retailer().ClickAddRetailers();
			Delay.Seconds(1);			
			Report.IsTrue(selSelectRetailers.WaitForContainerToBeVisible(20), "Select retailers page is not loaded", "Select retailers page is loaded.");

		}

		[RegexStepDefinition(@"I click the (.*) retailers option in the Select Retailers popup")]
		public void ClickRetailersOption(string option)
		{
			Report.IsTrue(new SelectRetailers().ClickRetailerOption(option) && GeneralUtilities.Wait_for_load_finish(), "Failed to click the retailers option: " + option, "Successfully clicked the retailers option: " + option);
		}

		[RegexStepDefinition(@"I confirm that retailers are displayed in (list|tile) view with checkboxes next to each")]
		public void ConfirmRetailersAreDisplayedInViewType(string viewType)
		{
			Report.IsTrue(new SelectRetailers().RetailersShownInViewType(viewType),
				"Retailers were not shown in " + viewType + " view with checkboxes!",
				"Retailers were shown in " + viewType + " view with checkboxes");
		}

		[RegexStepDefinition(@"I click Done on Select Retailers window")]
		public void IClickDoneButtonOnSelectRetailersWindow()
		{
			Report.IsTrue(new SelectRetailers().ClickDone(), "Failed to click Done button.", "Successfully clicked Done button.");
		}

		[RegexStepDefinition(@"I select the following retailers in the Select Retailers popup list view:")]
		public void SelectRetailersInListView(Table retailers)
		{
			var retailersToSelect = new List<string>();
			var selSelectRetailers = new SelectRetailers();

			var opened = new Retailer().ClickAddRetailers();

			var selectRetailerPopupIsDisplayed = new Retailer().SelectRetailsPopupIsDisplayed();

			if (!selectRetailerPopupIsDisplayed)
			{
				if (opened)
				{
					Delay.Seconds(1);
					retailers.Rows.Cast<TableRow>().ToList().ForEach(x => retailersToSelect.Add(x["Retailer"]));
					foreach (string retailer in retailersToSelect)
					{
						Report.IsTrue(selSelectRetailers.SelectRetailerFromListView(retailer), "Failed to select retailer: " + retailer + " from the Select Retailers list view", "Successfully selected the retailer: " + retailer + " from the Select Retailers list view");
					}
				}
				else
				{
					Report.Failure($"Failed to click the 'Add Retailers Button'");
				}
			} else
			{
				Delay.Seconds(1);
				retailers.Rows.Cast<TableRow>().ToList().ForEach(x => retailersToSelect.Add(x["Retailer"]));
				foreach (string retailer in retailersToSelect)
				{
					Report.IsTrue(selSelectRetailers.SelectRetailerFromListView(retailer), "Failed to select retailer: " + retailer + " from the Select Retailers list view", "Successfully selected the retailer: " + retailer + " from the Select Retailers list view");
				}
			}
			//

			



		}

		[RegexStepDefinition(@"I click Done in the Select Retailers popup")]
		public void ClickDone()
		{
			Report.IsTrue(new SelectRetailers().ClickDone(), "Failed to click Done in the Select Retailers pop up!", "Successfully clicked Done in the Select Retailers pop up");
		}

		[RegexStepDefinition(@"I click Close in the Select Retailers popup")]
		public void ClickClose()
		{
			var selectRetailers = new SelectRetailers();
			Report.IsTrue(selectRetailers.ClickClose(), "Failed to click 'Close' in the select retailers window", "Successfully clicked 'Close' in the select retailers window");
		}

		[RegexStepDefinition(@"all retailers are selected in the Select Retailers window")]
		public void AllRetailersAreSelectedInSelectRetailersWindow()
		{
			var selSelectRetailers = new SelectRetailers();
			List<string> notSelected = selSelectRetailers.UnselectedRetailers();
			Report.IsTrue(!notSelected.Any(), "Some retailers were not selected: " + string.Join(", ", notSelected),
				"All retailers were selected as expected");
		}

		[RegexStepDefinition(@"I save all retailers in the Select Retailers window in alphabetical order as: (.*)")]
		public void SaveAllRetailersInSelectRetailersWindowAlphabetical(string savedAs)
		{
			var selSelectRetailers = new SelectRetailers();
			var allRetailers = selSelectRetailers.AllRetailers().OrderBy(x => x).ToList();
			Context.AddToContext(savedAs, allRetailers);
		}

		[RegexStepDefinition(@"In the 'Select Retailers' window I select the retailer: (.*)")]
		public void SelectTheRetailer(string retailer)
		{
			var selectRetailers = new SelectRetailers();			
			new Retailer().ClickAddRetailers();
			Delay.Seconds(1);
			
			if (!selectRetailers.WaitForContainerToBeVisible(30))
			{
				throw new Exception("Select retailers popup is not showing as expected");
			}

			if (retailer.ToLower().Contains("walmart") || retailer.ToLower().Contains("wal-mart"))
			{
				if (!selectRetailers.SelectRetailerContains("walmart"))
				{
					Report.IsTrue(selectRetailers.SelectRetailerContains("wal-mart"), $"Failed to select retailer: {retailer} !", $"Successfully selected retailer: {retailer}");
				}
				else
				{
					Report.Success($"Successfully selected retailer: {retailer}");
				}
			}
			else
			{
				Report.IsTrue(selectRetailers.SelectRetailer(retailer), $"Failed to select retailer: {retailer}!", $"Successfully selected retailer: {retailer}");
			}

			Report.IsTrue(selectRetailers.ClickDone(), "Failed to click the 'Done' button!", "Successfully clicked the 'Done' button");
		}

		[RegexStepDefinition(@"I confirm that (.*) is listed as a retailer on the Select Retailers pop up")]
		public void ConfirmXIsListedAsARetailer(string retailer)
		{
			Report.IsTrue(new SelectRetailers().GetListOfRetailers().Contains(retailer),
				"Retailer is not listed: " + retailer, "Retailer is listed as expected: " + retailer);
		}

		// Added 'should only' parameter to check an exclusive list of Retailers
		[RegexStepDefinition(@"In the 'Select retailers' window I (should|should only|should not) see the following retailers:")]
		public void ConfirmDislayedRetailers(string should, Table expected)
		{

			var popupIsDisplayed = new Retailer().SelectRetailsPopupIsDisplayed();
			var opened = false;

			if (popupIsDisplayed == false)
			{
				opened = new Retailer().ClickAddRetailers();
			}

			if (opened || popupIsDisplayed)
			{

				var showing = new SelectRetailers().GetListOfRetailers().Where(x => x.Trim() != "").ToList();
				List<string> checkedRetailers = showing;
				Report.Info("Retailers showing were: " + string.Join(", ", showing));
				bool expectedOrNot = should != "should not";
				foreach (TableRow row in expected.Rows)
				{
					Report.IsTrue(showing.Contains(row["Retailer"]) == expectedOrNot, (expectedOrNot ? "Did not find" : "Found") + " the retailer: " + row["Retailer"], "The retailer " + row["Retailer"] + (expectedOrNot ? " was" : " was not") + " showing, as expected!", false, false);
					if (showing.Contains(row["Retailer"]))
					{
						checkedRetailers.Remove(row["Retailer"]);
					}
				}
				if (should == "should only")
				{
					var itemList= expected.Rows.Select(x => x["Retailer"].ToList());
					var stringList = new List<string>();
					foreach(var item in itemList)
					{
						var intMax= item.Count();
						var emptystring = string.Empty;
						for(int i=0; i<intMax;i++)
						{
							emptystring = emptystring + item.ElementAt(i);
						}
						stringList.Add(emptystring);
											
					}	

					Report.IsTrue(checkedRetailers.Count == 0,"There were displayed Retailers not included in the expected list:: " + string.Join(", ", stringList),"As expected the only displayed Retailers were those in the list: " + string.Join(", ", stringList));
				}
			}

			else
			{
				Report.Failure($"Failed to click the 'Add Retailers Button'");
			}

		}

		[RegexStepDefinition(@"I check that Walmart and all of its affiliates are not available")]
		public void GivenICheckThatWalmartAndAllOfItsAffiliatesAreNotAvailable()
		{
			List<string> retailerList = new SelectRetailers().GetListOfRetailers();
			foreach (string myRetailer in retailerList)
			{
				Report.Info("Retailer = " + myRetailer);
				if (myRetailer.Contains("Walmart"))
				{
					Report.Failure("Unsuccessful: retailer: '" + myRetailer + "' available");
					Report.Screenshot();
					return;
				}
			}
			Report.Success("Walmart and all of its affiliates are not available");
			Report.Screenshot();
			Report.StartStep("In the Retailer page I click Done");
			Report.IsTrue(new SelectRetailers().ClickDone(), "Failed to click 'Done' in the Select Retailers window",
				"Successfully clicked 'Done' in the Select Retailers window");
		}

		[RegexStepDefinition(@"I select all retails in Retailers page table view")]
		public void GivenISelectAllRetailsInRetailersPageTableView()
		{
			Retailer newRetailerObject = new Retailer();
			Report.StartStep("In the Retailer page I check the top checkbox to select all retailers");
			Report.IsTrue(newRetailerObject.CheckSelectAllCheckboxInRetailersTableView(), "Failed to click top checkbox in the Retailers page table view",
				"Successfully clicked top checkbox in the Retailers page table view");
		}


		[RegexStepDefinition(@"I confirm the following retailers are selected in the Select Retailers window")]
		public void ConfirmSelectedRetailers(Table retailers)
		{
			var selSelectRetailers = new SelectRetailers();
			var expectedSelected = new List<string>();
			retailers.Rows.Cast<TableRow>().ToList().ForEach(x => expectedSelected.Add(x["Retailer"]));
			List<string> actualSelected = selSelectRetailers.SelectedRetailers();
			Report.IsTrue(expectedSelected.All(x => actualSelected.Contains(x)),
				"Not all of the expected retailers were selected!",
				"All of the expected retailers were selected");
		}

		[RegexStepDefinition(@"I confirm that the product names from the drop down for: (.*) for (.*) appear in alphabetical order")]
		public void ThenIConfirmThatTheProductNamesFromTheDropDownForAppearInAlphabeticalOrder(string dropDownTitle, string retailer)
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.ConfirmDropDownOptionsAreInAlphabeticalOrderForRetailer(dropDownTitle, retailer), "Drop down options were not in alphabetical order", "Drop down options were in alphabetical order");
		}

		[RegexStepDefinition(@"The following retailers in the Select Retailers popup list view (should|should not) be selected")]
		public void ThenTheFollowingRetailersInTheSelectRetailersPopupListViewShouldBeSelected(string shouldOrShouldNot, Table table)
		{
			var retailerObject = new Retailer();

			if (shouldOrShouldNot.ToLower() == "should not")
			{
				Report.IsTrue(!retailerObject.CheckThatTheFollowingRetailersAreSelectedInTheRetailersPopupList(table), "Unexpected retailers were not found checked", "All expected retailers were not checked");
			}
			else
			{
				Report.IsTrue(retailerObject.CheckThatTheFollowingRetailersAreSelectedInTheRetailersPopupList(table), "Unexpected retailers were found checked", "All expected retailers were checked");
			}
		}


		[RegexStepDefinition(@"I click the delete icon in the Retailer page")]
		public void ThenIClickTheDeleteIconInTheRetailerPage()
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.SelectTheDeleteSelectedRetailersButton(), "Failed to select the delete selected retailers button", "Successfully selected the delete selected retailers button");
		}

		[RegexStepDefinition(@"I check the checkbox Registration is for a Single Retail Recipient \(No Retailer \+1\) and will use Single-Retail Subscription program")]
		public void ThenICheckTheCheckboxRegistrationIsForASingleRetailRecipientNoRetailerAndWillUseSingle_RetailSubscriptionProgram()
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.CheckTheCheckboxRegistrationIsForASingleRetailRecipientNoRetailerAndWillUseSingle_RetailSubscriptionProgram(), "Failed to check the Single Retailer checkbox", "Successfully checked the Single Retailer checkbox");
		}


		[RegexStepDefinition(@"I select the following retailers in the Retailer page")]
		public void ThenISelectTheFollowingRetailersInTheRetailerPage(Table table)
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.SelectTheFollowingRetailersInTheRetailersPage(table), "Failed to select the following retailers", "Successfully selected the following retailers");
		}
		[RegexStepDefinition(@"I Confirm that on the top right corner the Select All option is (available|NOT available)")]
		public void IConfirmSelectAllOptionIstAvailable(string availableNotAvailable)
		{
			var selSelectRetailers = new SelectRetailers();
			bool value = availableNotAvailable == "available";
			Report.IsTrue(selSelectRetailers.SelectAllDisplayed() == value, $"Failure, Select All option {(value ? "Not available" : "available")} and should be {availableNotAvailable}", $"Success, Select All option {availableNotAvailable}");
		}

		[RegexStepDefinition(@"I confirm when I select the retailer: (.*) the retailers cannot be selected, checkboxes appear grayed out with red crossed out circle")]
		public void IConfirmRetailerCannotBeSelected(string retailer)
		{
			var selectRetailers = new SelectRetailers();
			Report.IsFalse(selectRetailers.SelectRetailer(retailer), $"Successfully selected retailer: {retailer}", $"Failed to select retailer: {retailer}!");
		}

		
		[RegexStepDefinition(@"I click the single retailer checkbox")]
		public void ClickTheSingleRetailerCheckbox()
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.ClickSingleRetailerCheckbox(), "Failed to click the Single Retailer checkbox", "Successfully clicked the Single Retailer checkbox");
		}

		[RegexStepDefinition(@"I confirm if the single retailer checkbox (is|is not) selected")]
		public void ConfirmIfSingleRetailerCheckboxisSelected(string is_isnot)
		{
			var retailer = new Retailer();
			bool expected = is_isnot == "is";
			Report.IsTrue(retailer.CheckSingleRetailerCheckboxSelected() == expected, $"Failure, Single retailer checkbox {(expected?"is not":"is")} selected", $"Success, Single retailer checkbox {is_isnot} selected");

		}
		[RegexStepDefinition(@"I confirm if the Single Retailer Checkbox is (selected|not selected)")]
		public void ConfirmSingleRetailerCheckboxisSelected(string condition)
		{
			var retailer = new Retailer();

			if (condition == "selected")
			{
				Report.IsTrue(retailer.CheckSingleRetailerCheckboxSelected(), "Single retailer checkbox is not selected, but should be", "Single retailer checkbox is selected as expected");
			}
			else
			{
				Report.IsFalse(retailer.CheckSingleRetailerCheckboxSelected(), "Single retailer checkbox is selected, but should not be", "Single retailer checkbox is not selected, as expected");

			}
		}

		[RegexStepDefinition(@"I confirm if the single retailer checkbox is displayed on the retailer page")]
		public void ConfirmIfSingleRetailerCheckboxIsDisplayed()
		{
			var retailer = new Retailer();
			Report.IsTrue(retailer.ConfirmSingleRetailerCheckboxDisplayed(), "The single retailer checkbox was not displayed on the page!", "The single retailer checkbox displayed on the page");
		}

		[RegexStepDefinition(@"I confirm the message on retailers page : (.*)")]
		public void ICheckThatTheDescriptionTextOnTheSupplierReportsPageIsCorrect(string expectedText)
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.HoverOverText(expectedText), "The expected text did not match the actual text", "The expected text did match the actual text");
		}

		[RegexStepDefinition(@"I confirm if the single retailer checkbox is (enabled|disabled)")]
		public void ConfirmIfSingleRetailerCheckboxIsEnabled(string enabledDisabled)
		{
			var retailerObject = new Retailer();
			bool value = enabledDisabled == "enabled";
			Report.IsTrue(retailerObject.SubscriptionCheckboxEnbable() == value, $"Failure, check box is {enabledDisabled} when it should {(value ? "enabled" : "disabled")}.", $"Success, checkbox is {enabledDisabled}.");
		}

		[RegexStepDefinition(@"I confirm the checkbox (.*) is (present|not present) for stand alone batteries in Retailer page")]
		public void ThenIConfirmNoRetailerRegistrationCheckbox(string value, string presentNotPresent)
		{
			var retailerObject = new Retailer();
			bool status = presentNotPresent == "present";
			Report.IsTrue(retailerObject.ConfirmRetailerRegistrationCheckbox(value) == status, $"Failed to confirm the checkbox is {presentNotPresent}.", $"Successfully confirmed that the checkbox is {presentNotPresent}.");
		}

		[RegexStepDefinition(@"I select the following retailers in the Select Retailers popup list view and check no more retailers can be selected:")]
		public void ThenInTheWindowICheckOnlyOneRetailerCanBeSelected(Table retailers)
		{
			var selSelectRetailers = new SelectRetailers();
			this.SelectRetailersInListView(retailers);
			Report.IsTrue(selSelectRetailers.OnlyOneRetailerCanBeSelected(retailers), "Failed to verify no more retailers can be selected", "Succesfully verified no more retailers can be selected");

		}

	}
}

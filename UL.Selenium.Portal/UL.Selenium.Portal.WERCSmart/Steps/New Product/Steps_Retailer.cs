using System.Collections.Generic;
using System.IO;
using System.Linq;
using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_Retailer
	{
		[StepDefinition(@"the selected retailers on the Retailer page should match the retailer list saved as (.*)")]
		public void SelectedRetailersOnRetailerPageShouldMatchSavedAs(string savedAs)
		{
			var retailerList = (List<string>)Context.GetFromContext(savedAs);
			if (retailerList == null)
			{
				Report.Failure("No retailer list saved as: " + savedAs + " was found in context!");
				return;
			}
			var actualRetailers = new Retailer().SelectedRetailers();
			bool match = !retailerList.Except(actualRetailers).Any() && retailerList.Count == actualRetailers.Count;
			if (match)
			{
				Report.Success("The actual list of retailers matched the expected retailers.");
				Report.Screenshot();
				return;
			}
			Report.Failure("The actual list of retailers did not match the expected retailers! The differences were: " + string.Join(", ", retailerList.Except(actualRetailers)));
			Report.Screenshot();
		}

		[StepDefinition(@"The selected retailers on the Retailer page (should|should not) be:")]
		public void SelectedRetailersShouldBe(string shouldOrShouldNot, Table retailers)
		{
			var expectedRetailers = new List<string>();
			retailers.Rows.Cast<TableRow>().ToList().ForEach(x => expectedRetailers.Add(x["Retailer"]));
			var actualRetailers = new Retailer().SelectedRetailers();

			if (shouldOrShouldNot.ToLower() == "should not")
			{
				Report.IsTrue((!actualRetailers.All(expectedRetailers.Contains)), "The selected retailers did match those expected. The selected retailers were: " + string.Join(", ", actualRetailers) + " The expected retailers were: " + string.Join(", ", expectedRetailers), " The selected retailers did not match as expected: " + string.Join(", ", actualRetailers));
			} else
			{
				Report.IsTrue(actualRetailers.All(expectedRetailers.Contains) && actualRetailers.Count == expectedRetailers.Count, "The selected retailers did not match those expected. The selected retailers were: " + string.Join(", ", actualRetailers) + " The expected retailers were: " + string.Join(", ", expectedRetailers), " The selected retailers matched as expected: " + string.Join(", ", actualRetailers));
			}
		}

		[StepDefinition(@"I click 'Add Retailers' in the Retailers page")]
		public void ClickAddRetailers()
		{
			Report.IsTrue(new Retailer().ClickAddRetailers(), "Failed to click Add Retailers in the Retailers page", "Clicked Add Retailers in the Retailers page");
		}

		[StepDefinition(@"I select any Walmart Affiliate automatically selects all from that group, then 'Wal-Mart/SAM'S CLUB' is displayed on the retailers page")]
		public void SelectWalmartAffiliate_SelectsAll_WalMartSAMsClub()
		{
			var retailerInfo = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("WM-BO","BONOBOS"),
				new KeyValuePair<string, string>("WM-CO","Walmart.com"),
				new KeyValuePair<string, string>("WM-HN","Hayneedle"),
				new KeyValuePair<string, string>("WM-JE","Jet"),
				new KeyValuePair<string, string>("WM-MC","MODCLOTH"),
				new KeyValuePair<string, string>("WM-MJ","Moosejaw"),
				new KeyValuePair<string, string>("WM-SC","Shoes.com"),
				new KeyValuePair<string, string>("WM","Walmart")
			};
			foreach (var retailer in retailerInfo)
			{
				ReportSettings.UseSubSteps = false;
				Report.StartStep("Selecting retailer: '" + retailer + "' selects all Wal-mart affiliates in 'Select a Retailer', then the retailer is set to: 'Wal-Mart/SAM'S CLUB'");
				ReportSettings.UseSubSteps = true;
				var selSelectRetailers = new SelectRetailers();
				var selNewProduct = new NewProduct();
				var selRetailer = new Retailer();
				if (!selSelectRetailers.RetailersShownInViewType("tile"))
				{
					Report.Info("Clicking 'logo tile view' option because Select Retailers is shown in list view");
					Report.IsTrue(selSelectRetailers.ClickRetailerOption("logo tile view"), "Failed to click 'logo tile view'", "Successfully clicked 'logo tile view'");
				}
				Report.StartStep(ReportSettings.StepCounter + " - I select retailer: " + retailer.Value);
				ReportSettings.StepCounter++;
				Report.Info("Clicking the checkbox for retailer with logo: " + retailer.Key);
				Report.IsTrue(selSelectRetailers.SelectRetailerByLogo(retailer.Key),
					"Failed to select retailer: " + retailer.Value,
					"Successfully selected retailer: " + retailer.Value);
				Report.StartStep(ReportSettings.StepCounter + " - I confirm all of the Walmart affiliated retailers are now selected");
				ReportSettings.StepCounter++;
				Report.Info("Comparing the selected retailer list with the expected retailer list");
				var allSelected = new List<string>();
				foreach (var selected in selSelectRetailers.SelectedRetailers(true))
				{
					var parts = selected.Split('/');
					var filename = parts[parts.Length - 1].Split('?')[0];
					allSelected.Add(Path.GetFileNameWithoutExtension(filename)?.ToLower());
				}
				var allExpected = retailerInfo.Select(x => x.Key.ToLower()).ToList();
				Report.IsTrue(!allSelected.Except(allExpected).Any() && allExpected.Count == allSelected.Count,
					"The selected retailers did not match the group of Walmart Affiliates: " + string.Join(", ", retailerInfo.Select(x => "'" + x.Value + "'").ToList()),
					"The selected retailers matched the group of Walmart Affiliates: ");
				Report.StartStep(ReportSettings.StepCounter + " - I click the Done button");
				ReportSettings.StepCounter++;
				Report.IsTrue(selSelectRetailers.ClickDone(),
					"Failed to click the 'Done' button!",
					"Successfully clicked the 'Done' button");
				Report.StartStep(ReportSettings.StepCounter + " - I confirm the only retailer selected is: 'Wal-Mart/SAM'S CLUB' ");
				ReportSettings.StepCounter++;
				var actualRetailers = selRetailer.SelectedRetailers();
				var expectedRetailers = new List<string> { @"Wal-Mart/SAM'S CLUB" };
				Report.IsTrue(actualRetailers.All(expectedRetailers.Contains) && actualRetailers.Count == expectedRetailers.Count,
					"The selected retailers did not match those expected. The selected retailers were: " + string.Join(", ", actualRetailers) + " The expected retailers were: " + string.Join(", ", expectedRetailers),
					" The selected retailers matched as expected: " + string.Join(", ", actualRetailers));
				Report.Info("Clicking 'Add New Retailer'");
				selRetailer.ClickAddRetailers();
				Report.Info("Refreshing the selected retailers with 'select all'");
				selSelectRetailers.ClickSelectAll();
				selSelectRetailers.ClickSelectAll();
			}
			new SelectRetailers().ClickClose();
		}

		[StepDefinition(@"In the Retailers tab, I select Private Label name as: (.*)")]
		public void ISelectPrivateLabelName(string option)
		{
			Report.IsTrue(new Retailer().SelectPrivateLabelName(option), "Failed to set the Private label name to be: " + option,
				"Successfully set private label name to be: " + option);
		}

		[StepDefinition(@"In the Retailers tab, I enter Private Label name as: (.*)")]
		public void IEnterPrivateLabelName(string option)
		{
			Report.IsTrue(new Retailer().EnterPrivateLabelName(option), "Failed to set the Private label name to be: " + option, "Successfully set private label name to be: " + option);
		}

		[StepDefinition(@"In the Retailers tab, for the retailer: (.*) I enter Private Label name: (.*)")]
		public void ForRetailerIEnterPrivateLabelName(string retailer, string option)
		{
			Report.IsTrue(new Retailer().EnterPrivateLabelName(option, retailer), "Failed to set the Private label name to be: " + option + " for retailer: " + retailer, "Successfully set private label name to be: " + option + " for retailer: " + retailer);
		}

		[StepDefinition(@"In the Retailers tab, I select Vendor id as: (.*)")]
		public void ISelectVendorId(string option)
		{
			Report.IsTrue(new Retailer().SelectVendorId(option), "Failed to set the vendor id to be: " + option,
				"Successfully set vendor id to be: " + option);
		}

		[StepDefinition(@"In the Retailers tab, for retailer: (.*) I select Vendor id as: (.*)")]
		public void ISelectVendorIdForRetailer(string retailer, string option)
		{
			Report.IsTrue(new Retailer().SelectVendorId(option, retailer),
				"Failed to set the vendor id to be: " + option + " for retailer: " + retailer,
				"Successfully set vendor id to be: " + option + " for retailer: " + retailer);
		}

		[StepDefinition(@"In the Retailers tab, I select the first Vendor option for retailer: (.*)")]
		public void ISelectFirstVendorIdForRetailer(string retailer)
		{
			Report.IsTrue(new Retailer().SelectVendorId("", retailer, true),
				"Failed to set the first vendor option for retailer: " + retailer,
				"Successfully set the first vendor option for retailer: " + retailer);
		}

		[StepDefinition(@"In the Retailers tab, I select the first Vendor option")]
		public void ISelectFirstVendorId()
		{
			Report.IsTrue(new Retailer().SelectVendorId("", true),
				"Failed to set the first vendor option ",
				"Successfully set the first vendor option");
		}

		[StepDefinition(@"On the Retailer page I delete the following retailers:")]
		public void DeleteRetailers(Table table)
		{
			var selRetailer = new Retailer();
			var deleteRetailers = new List<string>();
			table.Rows.Cast<TableRow>().ToList().ForEach(x => deleteRetailers.Add(x["Retailer"]));
			foreach (var retailer in deleteRetailers)
			{
				Report.Info("Clicking the select checkbox for retailer: " + retailer);
				Report.IsTrue(selRetailer.SelectRetailer(retailer),
					"Failed to select retailer: " + retailer,
					"Successfully selected retailer: " + retailer);
			}
			Report.Info("Clicking the delete icon for the selected retailers");
			Report.IsTrue(selRetailer.DeleteSelectedRetailers(),
				"Failed to delete the selected retailers",
				"Successfully deleted the selected retailers");
		}

		[StepDefinition(@"I should (see|not see) the following retailers:")]
		public void ShouldSeeRetailers(string condition, Table expected)
		{
			var selRetailer = new Retailer();
			var listRetailers = selRetailer.SelectedRetailers();
			if (condition == "see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Retailers"];
					Report.Info("Checking that I see the retailer '" + option + "'");
					Report.IsTrue(listRetailers.Contains(option.Trim()),
						"Retailers was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", listRetailers) + "'!",
						"Retailers was showing: '" + option + "', as expected!");
				}
			}
			if (condition == "not see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Retailers"];
					Report.Info("Checking that I do not see the retailer '" + option + "'");
					Report.IsFalse(listRetailers.Contains(option.Trim()),
						"Retailers were showing which should not be. The sections not allowed are: " + string.Join("; ", option) + ". Actual sections: " + string.Join("; ", option), "Sections were not showing as expected: " + string.Join("; ", option));
				}
			}
			Report.Screenshot();
		}

		[StepDefinition(@"If the UPCs Warning popup is displayed I click (.*)")]
		public void IfISeeUpcWarningPopupClick(string choice)
		{
			var noRetailerWarning = new NoRetailerWarningPopup();
			if (noRetailerWarning.WaitForContainerToBeVisible(10))
			{
				Report.IsTrue(noRetailerWarning.ClickChoice("Ok"), "Failed to click OK in the UPC Warning popup!", "Successfully clicked OK in the UPC Warning popup");
			}
			else
			{
				Report.Info("The UPC Warning popup was not displayed");
			}
		}

		[StepDefinition(@"I click continue then if the 'UPCs Warning' popup is displayed I click 'OK'")]
		public void ClickContinueDismissNoUpcPopup()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click continue");
			Report.IsTrue(new NewProduct().ClickContinue(false), "Failed to click continue", "Clicked continue");
			Report.StartStep("I click 'OK' in the 'UPCs Warning' popup if it is displayed");
			this.IfISeeUpcWarningPopupClick("Ok");
		}

		[StepDefinition(@"I confirm I see error messages for the following retailers")]
		public void ThenIConfirmISeeErrorMessagesForTheFollowingRetailers(Table table)
		{
			SelectRetailers SelectRetailersObject = new SelectRetailers();
			SelectRetailersObject.CheckIfRetailersInTableDisplayErrorMessage(table);
		}
		
		[StepDefinition(@"I confirm the following retailers are showing in the Retailer page")]
		public void ThenIConfirmTheFollowingRetailersAreShowingInTheRetailerPage(Table table)
		{
			Retailer RetailersObject = new Retailer();
			Report.IsTrue(RetailersObject.CheckForTheFollowingRetailersInRetailerPage(table), "Failed to find all retailers", "Successfully found all retailers");
		}

	}
}

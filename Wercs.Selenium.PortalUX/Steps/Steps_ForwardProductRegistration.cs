using System;
using System.Linq;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ForwardProductRegistration")]
	class StepsForwardProductRegistration
	{
		/// <summary>
		/// This is to verify the title of the page
		/// </summary>
		/// <param name="headerExpected"></param>
		[StepDefinition(@"I should see the header: (.*) on the Forward Product Registration window")]
		public void CorrectHeaderShowing(string headerExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				var showing = selForwardProductRegistration.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Forward Product Registration header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Forward Product Registration header was showing '" + headerExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// This is to verify sub header 3 which is Select Retailers
		/// </summary>
		/// <param name="subheaderExpected"></param>
		[StepDefinition(@"I should see the subheading 3: (.*) on the Forward Product Registration window")]
		public void CorrectSubHeader3Showing(string subheaderExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				var showing = selForwardProductRegistration.SubHeadings3Showing();
				Report.IsTrue(showing.Contains(subheaderExpected.Trim()),
					"Forward Product Registration subheader3 was not as expected! Expected: '" + subheaderExpected + "', but found: '" + string.Join("', '", showing) + "' instead!",
					"Forward Product Registration header was showing '" + subheaderExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// This is to verify sub header 4 which is You most recently did business with
		/// </summary>
		/// <param name="subheaderExpected"></param>
		[StepDefinition(@"I should see the subheading 4: (.*) on the Forward Product Registration window")]
		public void CorrectSubHeader4Showing(string subheaderExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				var showing = selForwardProductRegistration.SubHeadings4Showing();
				Report.IsTrue(showing.Contains(subheaderExpected.Trim()),
					"Forward Product Registration subheader 4 was not as expected! Expected: '" + subheaderExpected + "', but found: '" + string.Join("', '", showing) + "' instead!",
					"Forward Product Registration header was showing '" + subheaderExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should be sent to the Product Registration page with retailers list displayed")]
		public void ThenIShouldBeSentToTheProductRegistrationPageWithRetailersListDisplayed()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				Report.IsTrue(selForwardProductRegistration.Wait_for_load(), "Forward Product Registration window did not appear!", "Forward Product Registration window appeared successfully");
				Report.IsTrue(selForwardProductRegistration.ListOfRetailers() != null, "No retailers were found!", "Retailers were found in the list, as expected");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the text: (.*) in the 'Search by WPS ID or Product Name' field")]
		public void EnterTextInSearchByIDOrProductNameField(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EnterTextToSearchField(value),
				"Failed to enter text: " + value + " to the search field",
				"Successfully entered text: " + value + " to the search field");
			Delay.Seconds(2);
		}

		[StepDefinition(@"I click continue on the Forward Product Registration page")]
		public void ClickContinueForwardProductRegistration()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.ClickContinue() && GeneralUtilities.Wait_for_load_finish(),
				"Failed to click continue", "Successfully clicked continue");
		}

		[StepDefinition(@"I select the first product under the Select Products tab")]
		public void SelectTheFirstProduct()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.ClickTheFirstProductCheckbox(),
				"Failed to select the first returned product!",
				"Successfully selected the first returned product");
			Delay.Seconds(2);
		}
		[StepDefinition(@"I select the first product under the Select UPCs tab")]
		public void SelectTheFirstProductSelectUPCs()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SelectFirstProduct_SelectUPCs(),
				"Failed to select the first returned product!",
				"Successfully selected the first returned product");
			Delay.Seconds(1);
		}

		[StepDefinition(@"in the Select Retailers tab under Forward Product Registration I select the retailer: (.*)")]
		public void SelectRetailer(string retailer)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SelectRetailer(retailer),
				"Failed to select retailer: " + retailer,
				"Successfully selected retailer: " + retailer);
		}

		[StepDefinition(@"I confirm that all Walmart affiliate retail parters are selected")]
		public void AllWalmartAffiliatesSelected()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.AllWalMartAffiliatesSelected(),
				"Not all Walmart affiliate partners were selected!",
				"All Walart affiliate partners were selected");
		}

		[StepDefinition(@"I confirm the active Forward Product Registration tab is: (.*)")]
		public void ActiveTabIsCorrect(string expectedTab)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var actualTab = selForwardProdReg.ActiveTab();
			if (actualTab == null)
			{
				Report.Failure("Could not find an active tab in the Forward Product Registration page");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(actualTab == expectedTab,
				"The actual active tab did not match the expected tab! Expected: " + expectedTab + ". Actual: " + actualTab,
				"The actual active tab matched the expected tab: " + actualTab);
		}

		[StepDefinition(@"I select the Vendor option: (.*) for the first product displayed under the Select UPCs tab")]
		public void SelectVendor(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.FirstProductSelectVendor(value),
				"Failed to select vendor: " + value,
				"Successfully selected vendor: " + value);
		}

		[StepDefinition(@"I select the first UPC in the grid under the Select UPCs tab")]
		public void SelectFirstUPC()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SelectFirstUPC(),
				"Failed to select the first UPC",
				"Successfully selecte the first UPC");
		}

		[StepDefinition(@"I confirm that: (.*) is displayed in the Destination Retailers column under Select UPCs")]
		public void ConfirmDestinationRetailersColumnSelectUPCs(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var upcs = selForwardProdReg.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return;
			}
			Report.Info("There were: " + upcs.Count + " UPCs to check");
			if (upcs.All(x => x.UPCInfo.DestinationRetailers == value))
			{
				Report.Success("The Destination Retailers column was showing: " + value + " as expected");
				Report.Screenshot();
				return;
			}
			Report.Failure("The following UPCs were not showing the value: " + value + " under Destination Retailers! - " + string.Join(", ", upcs.Where(x => x.UPCInfo.DestinationRetailers != value).Select(x => x.UPCInfo.UPCNumber).ToList()));
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm that: (.*) is displayed in the Destination Retailers column under Product Results")]
		public void ConfirmDestinationRetailersColumnProductResults(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var prodResults = selForwardProdReg.GetProductResults();
			if (prodResults.Count == 0)
			{
				Report.Failure("No product rows were found on the Product Results page!");
				Report.Screenshot();
				return;
			}
			Report.Info("There were: " + prodResults.Count + " product results to check");
			if (prodResults.All(x => x.UPCs.All(y => y.DestinationRetailers == value)))
			{
				Report.Success("The Destination Retailers column was showing: " + value + " as expected");
				Report.Screenshot();
				return;
			}
			Report.Failure("The following product results were not showing the value: " + value + " under Destination Retailers! - " + string.Join(", ", prodResults.Where(x => x.UPCs.Any(y => y.DestinationRetailers != value)).Select(x => x.ProductHeader).ToList()));
			Report.Screenshot();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
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
			if (value.ToLower().Contains("saved as"))
			{
				var PI = (ProductInformation)Context.GetFromContext(value.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
				if (PI == null)
				{
					throw new Exception("Failed to find product: " + value);
				}

				value = PI.Id;
			}
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
			Report.IsTrue(selForwardProdReg.SelectProducts_ClickTheFirstProductCheckbox(),
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

		[StepDefinition(@"I confirm that the product checkbox is disabled while the page is working")]
		public void ConfirmProductCheckboxIsDisabledWhilePageIsWorking()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			if (Report.IsTrue(selForwardProdReg.SelectProducts_ProductCheckboxDisabled(true), "The product checkbox was not disabled after selecting it", "The product checkbox was disabled after selecting it"))
			{
				int counter = 0;
				while (counter < 120)
				{
					var disabled = selForwardProdReg.SelectProducts_ProductCheckboxIsDisabled();
					var loadingActive = GeneralUtilities.Loading_Active();
					if (disabled && loadingActive)
					{
						counter++;
						Delay.Seconds(0.5);
						continue;
					}
					if (!disabled && loadingActive)
					{
						Report.Failure("The select product option was re-enabled before the page finished working! It is possible to select the product twice");
						Report.Screenshot();
						return;
					}

					if (disabled)
					{
						Report.Failure("The select product was still disabled after the page finished loading");
						Report.Screenshot();
						return;
					}
					counter++;
					Delay.Seconds(0.5);
				}
				Report.IsFalse(selForwardProdReg.SelectProducts_ProductCheckboxIsDisabled() && GeneralUtilities.Loading_Active(), "The page did not refresh after 60 seconds", "The product selection was disabled until the page finished loading as expected");
			}
			// test case : confirm the right hand side is disabled while the page is working. I can't verify this manually..
		}

		[StepDefinition(@"I save first selectable Product ID as: (.*) under the Select Products tab")]
		public void SaveSelectableProductID(string savedAs)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var id = selForwardProdReg.SelectProducts_FirstProductID();
			if (id == null)
			{
				Report.Failure("Could not find the product ID for the first selectable product!");
				return;
			}
			Report.Info("Saving Product ID: " + id + " to context as: " + savedAs);
			Context.AddToContext(savedAs, id);
		}

		[StepDefinition(@"I select the product with ID saved as: (.*) under the Select Products tab")]
		public void SelectProductByIDSavedAs(string savedAs)
		{
			var selForwardProductReg = new ForwardProductRegistration();
			if (savedAs.ToLower().Contains("list"))
			{
				var ids = (List<string>)Context.GetFromContext(savedAs);
				if (ids == null)
				{
					Report.Failure("Could not find product IDs in context saved as: " + savedAs);
					return;
				}
				bool clicked = false;
				foreach (var id_ in ids)
				{
					Report.Info("Attempting to select product with id: " + id_);
					this.EnterTextInSearchByIDOrProductNameField(id_);
					if (selForwardProductReg.SelectProducts_ClickProductByID(id_))
					{
						Report.Success("Successfully selected product with ID: " + id_);
						Report.Screenshot();
						clicked = true;
						break;
					}
				}
				if (!clicked)
				{
					Report.Failure("Failed to select any of the products with ID in the list saved as: " + savedAs);
					Report.Screenshot();
				}
			}
			else
			{
				var id = Context.GetFromContext(savedAs)?.ToString();
				if (id == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				this.EnterTextInSearchByIDOrProductNameField(id);
				Report.Screenshot();
				Report.IsTrue(selForwardProductReg.SelectProducts_ClickProductByID(id),
					"Failed to select the product with ID: " + id + "!",
					"Successfully selected the product with ID: " + id);
			}
		}

		[StepDefinition(@"I confirm I am unable to select the product with ID saved as: (.*) under the Select Products tab")]
		public void ConfirmIAmUnableToSelectProductWithIDSavedAs(string savedAs)
		{
			var selForwardProductReg = new ForwardProductRegistration();
			if (savedAs.ToLower().Contains("list"))
			{
				var ids = (List<string>)Context.GetFromContext(savedAs);
				if (ids == null)
				{
					Report.Failure("Could not find product IDs in context saved as: " + savedAs);
					return;
				}

				foreach (var id_ in ids)
				{
					bool isChecked_ = selForwardProductReg.SelectProducts_ProductIsChecked(id_);
					Report.Info("Product with ID: " + id_ + " is " + (isChecked_ ? "selected" : "not selected"));
					Report.Info("Clicking the checkbox for product with ID: " + id_);
					Report.IsTrue(selForwardProductReg.SelectProducts_ClickProductByID(id_),
						"Failed to select the product with ID: " + id_ + "!",
						"Successfully selected the product with ID: " + id_);
					Report.IsTrue(selForwardProductReg.SelectProducts_ProductIsChecked(id_) == isChecked_,
						"I was able to " + (isChecked_ ? "deselect" : "select") + " product with ID: " + id_ + " when it should be disabled!",
						"I was not able to " + (isChecked_ ? "deselect" : "select") + " product with ID: " + id_ + " as expected");
					return;
				}
			}
			else
			{
				var id = Context.GetFromContext(savedAs)?.ToString();
				if (id == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				bool isChecked_ = selForwardProductReg.SelectProducts_ProductIsChecked(id);
				Report.Info("Product with ID: " + id + " is " + (isChecked_ ? "selected" : "not selected"));
				Report.Info("Clicking the checkbox for product with ID: " + id);
				Report.IsTrue(selForwardProductReg.SelectProducts_ClickProductByID(id),
					"Failed to select the product with ID: " + id + "!",
					"Successfully selected the product with ID: " + id);
				Report.IsTrue(selForwardProductReg.SelectProducts_ProductIsChecked(id) == isChecked_,
					"I was able to " + (isChecked_ ? "deselect" : "select") + " product with ID: " + id + " when it should be disabled!",
					"I was not able to " + (isChecked_ ? "deselect" : "select") + " product with ID: " + id + " as expected");
			}

		}

		[StepDefinition(@"I select the product with ID saved as: (.*) under the Select Products tab and the checkbox is disabled while the page is working")]
		public void SelectProductWithIDSavedAsSelectProductAndCheckboxIsDisabled(string savedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I select the product with ID saved as: " + savedAs + " under the Select Products tab");
			var selForwardProductReg = new ForwardProductRegistration();
			if (savedAs.ToLower().Contains("list"))
			{
				var ids = (List<string>)Context.GetFromContext(savedAs);
				if (ids == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				foreach (var id_ in ids)
				{
					Report.Info("Clicking product checkbox with ID: " + id_);
					if (selForwardProductReg.SelectProducts_ClickProductByID_(id_))
					{
						TestReport.StartStep("I confirm the checkbox is disabled while the page is working");
						this.ConfirmProductCheckboxIsDisabledWhilePageIsWorking();
						break;
					}
				}
			}
			else
			{
				var id = Context.GetFromContext(savedAs)?.ToString();
				if (id == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				Report.Info("Clicking product checkbox with ID: " + id);
				selForwardProductReg.SelectProducts_ClickProductByID_(id);
				TestReport.StartStep("I confirm the checkbox is disabled while the page is working");
				this.ConfirmProductCheckboxIsDisabledWhilePageIsWorking();
			}

		}

		[StepDefinition(@"I click the Add UPC button under the Select UPCs tab")]
		public void ClickAddUPCsButtonUnderSelectUPCsTab()
		{
			var selForwardProductReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProductReg.ClickAddUPC(),
				"Failed to click the Add UPC button!",
				"Successfully clicked the Add UPC button");
		}

		[StepDefinition(@"I click the Add To No Retailer button under the Select UPCs tab")]
		public void ClickAddToNoRetailerButtonUnderSelectUPCsTab()
		{
			var selForwardProductReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProductReg.ClickAddToNoRetailer(),
				"Failed to click the Add To No Retailer button!",
				"Successfully clicked the Add To No Retailer button");
		}

		[StepDefinition(@"I select the UPC row: 'No UPC'/ 'No Retailer'")]
		public void SelectUPCRowNoUPCNoRetailer()
		{
			Report.IsTrue(new ForwardProductRegistration().SelectUPCNoUPC(),
				"Failed to select UPC row: No UPC",
				"Successfully selected UPC row: No UPC");
		}

		[StepDefinition(@"I select the (true|false) radio for the 'Are Statements True' question under the Review and Submit tab")]
		public void SelectRadioAreStatementsTrueReviewSubmitTab(string option)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.ReviewAndSubmit_AreStatementsTrue(option),
				"Failed to set the 'Are Statements True' radio to: " + option,
				"Successfully set the 'Are Statements True' radio to: " + option);
		}

		[StepDefinition(@"In the Foward Product Registration Screen I should see product: (.*)")]
		public void ThenInTheFowardProductRegistrationScreenIShouldSeeProduct(string id)
		{
			if (id.ToLower().Contains("saved as"))
			{
				var PI = (ProductInformation)Context.GetFromContext(id.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
				if (PI == null)
				{
					throw new Exception("Failed to find product: " + id);
				}

				id = PI.Id;
			}
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SelectProducts_GetListOfIDs().Contains(id),
				"ID: " + id + " is not showing as expected", "ID: " + id + " is showing as expected");
		}

		[StepDefinition(@"In the Foward Product Registration Screen I Select the product: (.*)")]
		public void ThenInTheFowardProductRegistrationScreenISelectTheProduct(string id)
		{
			if (id.ToLower().Contains("saved as"))
			{
				var PI = (ProductInformation)Context.GetFromContext(id.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
				if (PI == null)
				{
					throw new Exception("Failed to find product: " + id);
				}

				id = PI.Id;
			}
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SelectProducts_ClickProductByID(id),
				"ID: " + id + " has not be selected as expected", "ID: " + id + " has been selected as expected");
		}

		[StepDefinition(@"In the Forward Product Registration Screen I select a retailer under Other Retailers and save as (.*)")]
		public void ThenInTheForwardProductRegistrationScreenISelectARetailerUnderOtherRetailersAndSaveAs(string saveAs)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var listOfRetailers = selForwardProdReg.GetListOfOtherRetailers();
			Random rnd = new Random();
			int index = rnd.Next(0, listOfRetailers.Count-1);

			Report.IsTrue(selForwardProdReg.SelectRetailer(listOfRetailers[index]),
				"Failed to select retailer: " + listOfRetailers[index], "Selected retailer: " + listOfRetailers[index]);

			Context.AddToContext(saveAs, listOfRetailers[index]);

		}

	}
}

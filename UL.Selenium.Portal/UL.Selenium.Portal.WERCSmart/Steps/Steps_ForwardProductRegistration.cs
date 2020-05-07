using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Text.RegularExpressions;
using UL.Automation.Reporting;
using UL.Selenium.Portal.WERCSmart.Classes;

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
			GeneralUtilities.Wait_for_load_finish();
			Report.Info("Checking that Forward Product Registration window appears");
			var selForwardProductRegistration = new ForwardProductRegistration();
			string showing = selForwardProductRegistration.HeaderShowing();
			Report.IsTrue(showing == headerExpected.Trim(),
				"Forward Product Registration header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
				"Forward Product Registration header was showing '" + headerExpected + "', as expected!");
			Report.Screenshot();
		}

		/// <summary>
		/// This is to verify sub header 3 which is Select Retailers
		/// </summary>
		/// <param name="subheaderExpected"></param>
		[StepDefinition(@"I should see the subheading 3: (.*) on the Forward Product Registration window")]
		public void CorrectSubHeader3Showing(string subheaderExpected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				List<string> showing = selForwardProductRegistration.SubHeadings3Showing();
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
			Report.StartStep(ReportSettings.StepCounter + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				List<string> showing = selForwardProductRegistration.SubHeadings4Showing();
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
			Report.StartStep(ReportSettings.StepCounter + " - Forward Product Registration window should appear");
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
			Delay.Seconds(3);
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

		[StepDefinition(@"In Forward Product Registration, I ensure that the Select UPCs table has a Transportation column")]
		public void IEnsureThatTheSelectUPCsTableHasATransportationColumn()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EnsureUPCsTableHasTransportationColumn(), "Failed to find Transportation column in Select UPCs table",
				"Successfully found Transportation column in Select UPCs table");
		}

		[StepDefinition(@"In Forward Product Registration, I ensure that (DOT|IATA|IMDG|TDG) is listed as (Shipping fully regulated|Shipping with limited quantity|Shipping with consumer commodity)")]
		public void IEnsureThatOptionIsListedAtLevel(string option, string level)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EnsureThatOptionIsListedAtLevel(option, level), "Failed to find option " + option + " listed at level " + level + ".",
				"Successfully found option " + option + " listed at level " + level + ".");
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
			string actualTab = selForwardProdReg.ActiveTab();
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
			if (value.ToLower() == "<first>")
			{
				value = selForwardProdReg.FirstProductSelectedVendor();
			}
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
				"Successfully selected the first UPC");
		}

		[StepDefinition(@"I select Edit for the first UPC in Select UPCs tab")]
		public void SelectEditForFirstUPC()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SelectEditForFirstUPC(),
				"Failed to select Edit for the first UPC",
				"Successfully selected Edit for the first UPC");
		}

		[StepDefinition(@"I confirm that Package Type is not shown")]
		public void ConfirmPackageTypeNotShown()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.ConfirmPackageTypeNotShown(),
				"The Package Type is erroneously shown!",
				"The Package Type is correctly not shown.");
		}

		[StepDefinition(@"I confirm that Transportation is shown")]
		public void ConfirmTransportationShown()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.ConfirmTransportationShown(),
				"Transportation is nowhere to be found!",
				"Transportation successfully found.");
		}

		[StepDefinition(@"In the Forwarding Edit popup, I confirm that (DOT|IATA|IMDG|TDG) is listed at (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void InTheForwardingEditPopupIConfirmThatOptionisListedatLevel(string option, string level)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EditPopupConfirmOptionAtLevel(option, level), "Option " + option + " was not found at transportation level " + level + ".",
				"Option " + option + " successfully found at level " + level + ".");
		}

		[StepDefinition(@"In the Forwarding Edit popup, I confirm that I cannot downgrade (DOT|IATA|IMDG|TDG) to (Shipping with limited quantity|Shipping fully regulated|Shipping with consumer commodity)")]
		public void InTheForwardingEditPopupIConfirmThatICannotDowngradeOptionToLevel(string option, string level)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EditPopupConfirmCannotDowngrade(option, level), "Failure. Option " + option + " can be downgraded to level " + level + ".",
				"Success. Option " + option + " cannot be downgraded to level " + level + ".");
		}

		[StepDefinition(@"In the Forwarding Edit popup, I upgrade (DOT|IATA|IMDG|TDG) to (Shipping with limited quantity|Shipping fully regulated|Shipping with consumer commodity)")]
		public void InTheForwardingEditPopupIUpgradeOptionToLevel(string option, string level)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EditUPCUpgradeOptionToLevel(option, level), "Failed to upgrade option " + option + " to level " + level + ".",
				"Successfully upgraded option " + option + " to level " + level + ".");
		}

		[StepDefinition(@"I click Save in the Edit UPC popup in Forwarding")]
		public void AndIClickSaveInTheEditUPCPopupInFowarding()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.ClickSave(), "Failed to click save in the Edit UPC popup in Forwarding.",
				"Successfully clicked save in the Edit UPC popup in Forwarding.");
		}

		[StepDefinition(@"In the Forwarding Edit popup, I set the size \(ounces\) attribute to (.*)")]
		public void InTheForwardingEditPopupISetTheSizeAttributeTo(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.SetSizeAttribute(value), "Failed to set the size attribute for the UPC",
				"Successfully set the size attribute for the UPC");
		}

		[StepDefinition(@"I click the 'select all' UPCs checkbox")]
		public void ClickSelectAllUpcsCheckbox()
		{
			Report.IsTrue(new ForwardProductRegistration().ClickSelectAllUpcs, "Failed to click select all UPCs", "Clicked select all UPCs");
		}

		[StepDefinition(@"I confirm that: (.*) is displayed in the Destination Retailers column under Select UPCs")]
		public void ConfirmDestinationRetailersColumnSelectUPCs(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			List<ForwardProductRegistration.SelectUPCs> upcs = selForwardProdReg.GetUPCs();
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
			List<ForwardProductRegistration.ProductResults> prodResults = selForwardProdReg.GetProductResults();
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
					bool disabled = selForwardProdReg.SelectProducts_ProductCheckboxIsDisabled();
					bool loadingActive = GeneralUtilities.Loading_Active();
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
			string id = selForwardProdReg.SelectProducts_FirstProductID();
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
				Report.Info($"Saved as contains the word list.");
				var ids = (List<string>)Context.GetFromContext(savedAs);
				if (ids == null)
				{
					Report.Failure("Could not find product IDs in context saved as: " + savedAs);
					return;
				}
				bool clicked = false;
				foreach (string id_ in ids)
				{
					Report.Info("Attempting to select product with id: " + id_);
					this.EnterTextInSearchByIDOrProductNameField(id_);
					int i = 0;
					bool found = false;
					while (i < 5 && found == false)
					{

						if (selForwardProductReg.GetTopProductNameFromSelectProductList().IsNullOrEmpty())
						{
							Report.Info($"No Product Name was found for the product with id: {id_}");
							Delay.Seconds(2);
							i++;

						}
						else
						{
							found = true;
							Report.Info($"Product Name was found for the product with id: {id_}");
						}
					}
					if (found == false)
					{
						Report.Failure($"The Product with {id_} was not found after searching for it.");
						return;
					}
					if (selForwardProductReg.SelectProducts_ClickProductByID(id_))
					{
						Report.Success("Successfully selected product with ID: " + id_);
						Report.Screenshot();
						clicked = true;
						Report.IsTrue(selForwardProductReg.CheckProductsRightPanel_CheckProductByID(id_), "The Product was not showing in the right panel", "The product was showing in the right panel");
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
				Report.Info($"Saved as does not contain the word list.");
				string id = Context.GetFromContext(savedAs)?.ToString();
				if (id == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				if (id.Contains("ProductInformation"))
				{
					Report.Info("text: 'ProductInformation' was contained in the string, searching context for product saved as: " + savedAs);

					try
					{
						var productToSearch = (ProductInformation)Context.GetFromContext(savedAs);
						id = productToSearch.Id;
					}
					catch (Exception)
					{
						//do nothing
					}
				}

				this.EnterTextInSearchByIDOrProductNameField(id);
				Report.Screenshot();
				Report.IsTrue(selForwardProductReg.SelectProducts_ClickProductByID(id),
					"Failed to select the product with ID: " + id + "!",
					"Successfully selected the product with ID: " + id);
				Report.IsTrue(selForwardProductReg.CheckProductsRightPanel_CheckProductByID(id), "The Product was not showing in the right panel", "The product was showing in the rigt panel");
				
			}
		}

		[StepDefinition(@"I select the product saved as: (.*) under the Select Products tab")]
		public void ISelectTheProductSavedAsUnderSelectProducts(string savedAs)
		{
			var selForwardProductReg = new ForwardProductRegistration();
			var info = (ProductInformation)Context.GetFromContext(savedAs);
			if (info == null)
			{
				Report.Failure("Could not find product in context saved as: " + savedAs);
				return;
			}
			this.EnterTextInSearchByIDOrProductNameField(info.Id);
			Report.Screenshot();
			Report.IsTrue(selForwardProductReg.SelectProducts_ClickProductByID(info.Id),
								"Failed to select the product with ID: " + info.Id + "!",
								"Successfully selected the product with ID: " + info.Id);
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

				foreach (string id_ in ids)
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
				string id = Context.GetFromContext(savedAs)?.ToString();
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select the product with ID saved as: " + savedAs + " under the Select Products tab");
			var selForwardProductReg = new ForwardProductRegistration();
			if (savedAs.ToLower().Contains("list"))
			{
				var ids = (List<string>)Context.GetFromContext(savedAs);
				if (ids == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				foreach (string id_ in ids)
				{
					Report.Info("Clicking product checkbox with ID: " + id_);
					if (selForwardProductReg.SelectProducts_ClickProductByID_(id_))
					{
						Report.StartStep("I confirm the checkbox is disabled while the page is working");
						this.ConfirmProductCheckboxIsDisabledWhilePageIsWorking();
						break;
					}
				}
			}
			else
			{
				string id = Context.GetFromContext(savedAs)?.ToString();
				if (id == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				Report.Info("Clicking product checkbox with ID: " + id);
				selForwardProductReg.SelectProducts_ClickProductByID_(id);
				Report.StartStep("I confirm the checkbox is disabled while the page is working");
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

		[StepDefinition(@"I click the Add Case UPC button under the Select UPCs tab")]
		public void ClickAddCaseUPCsButtonUnderSelectUPCsTab()
		{
			var selForwardProductReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProductReg.ClickAddCaseUPC(),
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

		[StepDefinition(@"In the Foward Product Registration Screen I (should|should not) see product: (.*)")]
		public void ThenInTheFowardProductRegistrationScreenIShouldSeeProduct(string shouldOrShouldNot, string id)
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

			if (shouldOrShouldNot.ToLower() == "should") {

				Report.IsTrue(selForwardProdReg.SelectProducts_GetListOfIDs().Contains(id),
					"ID: " + id + " is not showing as expected", "ID: " + id + " is showing as expected");

			} else if(shouldOrShouldNot.ToLower() == "should not") {

				Report.IsTrue(!selForwardProdReg.SelectProducts_GetListOfIDs().Contains(id),
					"ID: " + id + " is not showing as expected", "ID: " + id + " is showing as expected");

			}

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
			Report.IsTrue(selForwardProdReg.SelectProducts_ClickProductByID(id), "Failed to click product", "Successfully clicked product");
			int i = 0;

			while (i<5 && !selForwardProdReg.CheckProductsSelected_CheckProductSelectedByID(id))
			{
				Delay.Seconds(2);
				i++;
			}
			Report.IsTrue(selForwardProdReg.CheckProductsSelected_CheckProductSelectedByID(id),"ID: " + id + " has not be selected as expected", "ID: " + id + " has been selected as expected");
			
		}

		[StepDefinition(@"In the Forward Product Registration Screen I select a retailer under Other Retailers and save as (.*)")]
		public void ThenInTheForwardProductRegistrationScreenISelectARetailerUnderOtherRetailersAndSaveAs(string saveAs)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			List<string> listOfRetailers = selForwardProdReg.GetListOfOtherRetailers();

			string alreadySelectedRetailer = "CVS";

			if (Context.Contains("retailer"))
			{
				alreadySelectedRetailer = Context.GetFromContext("retailer").ToString();
			}


			string itemToRemove = listOfRetailers.SingleOrDefault(r => r == alreadySelectedRetailer);
			if (itemToRemove != null)
			{
				listOfRetailers.Remove(itemToRemove);
			}

			bool bSelected = false;
			string selectedRetailer = "";
			int i = 0;
			while (i < 5 && !bSelected)
			{
				var rnd = new Random();
				int index = rnd.Next(0, listOfRetailers.Count - 1);
				try
				{
					if (selForwardProdReg.SelectOtherRetailer(listOfRetailers[index]))
					{
						selectedRetailer = listOfRetailers[index];
						Report.Success("Selected retailer: " + selectedRetailer);
						bSelected = true;
					}
				}
				catch (Exception e)
				{
					Report.Info(e.Message);
				}

				i++;
			}


			if (bSelected)
			{
				Report.Info("Saving retailer: " + selectedRetailer + " to context as: " + saveAs);
				Context.AddToContext(saveAs, selectedRetailer);
			}
			else
			{
				throw new Exception("Failed to select a retailer");
			}



		}

		[StepDefinition(@"In the Forward Product Registration Screen I select a retailer not in the list of retailers saved as (.*) and save as (.*)")]
		public void InTheForwardProductRegistrationScreenSelectRetailerNotInListOfRetailers(string retailers, string saveAs)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var alreadySelectedRetailers = (List<string>)Context.GetFromContext(retailers);
			List<string> listOfRetailers = selForwardProdReg.GetListOfOtherRetailers();
			bool bSelected = false;
			string selectedRetailer = "";
			int i = 0;
			while (i < 5 && !bSelected)
			{
				//When Choosing Random, often selects a retailer wich requires extra details which are not given.

				var rnd = new Random();
				int index = rnd.Next(0, listOfRetailers.Count - 1);
				try
				{
					if (selForwardProdReg.SelectOtherRetailer(listOfRetailers[index]))
					{
						selectedRetailer = listOfRetailers[index];
						var abbr = new RetailerAbbreviations();
						string selectedAbbr = "";
						abbr.Map.TryGetValue(selectedRetailer, out selectedAbbr);
						if (alreadySelectedRetailers.Any() && alreadySelectedRetailers.Contains(selectedAbbr))
						{
							Report.Info("Selected Retailer already exists. Selected another one.");
						}
						else
						{
							Report.Success("Selected retailer: " + selectedRetailer);
							bSelected = true;
						}
					}
				}
				catch (Exception e)
				{
					Report.Info(e.Message);
				}

				i++;
			}


			if (bSelected)
			{
				Context.AddToContext(saveAs, selectedRetailer);
			}
			else
			{
				throw new Exception("Failed to select a retailer");
			}
		}

		[StepDefinition(@"I confirm that for UPC Number (.*) the retailer is displayed as (.*)")]
		public void ThenIConfirmThatForUPCNumberSavedAsTestCaseUPCTheRetailerIsDisplayedAsSavedAsTestCaseRetailer(string aUPCNumber, string aRetailer)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			if (aUPCNumber.ToLower().Contains("saved as"))
			{
				var upcSavedAs = aUPCNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim();
				Report.Info("Getting UPC number from context saved as: " + upcSavedAs);
				aUPCNumber = Context.GetFromContext(upcSavedAs)?.ToString();
				if (aUPCNumber == null)
				{
					Report.Failure("Failed to get UPC number from context!");
					return;
				}
			}
			Report.Info("UPC Number: " + aUPCNumber);
			if (aRetailer.ToLower().Contains("saved as"))
			{
				var retailerSavedAs = aRetailer.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim();
				Report.Info("Getting Retailer from context saved as: " + retailerSavedAs);
				aRetailer = Context.GetFromContext(retailerSavedAs)?.ToString();
				if (aRetailer == null)
				{
					Report.Failure("Failed to get Retailer from context!");
					return;
				}
			}
			Report.Info("The Retailer found in context is: " + aRetailer);
			//        var abbreviationMappings = new RetailerAbbreviations().Map;
			//        if (abbreviationMappings.ContainsKey(aRetailer))
			//        {
			//// then we need to convert from full retailer name to abbreviation because the UPC page displays the abbrv
			////aRetailer = abbreviationMappings.FirstOrDefault(x => x.Key == aRetailer).Value;
			//abbreviationMappings.TryGetValue(aRetailer, out string retailer);
			//if (retailer != null)
			//{
			//	aRetailer = retailer;
			//}
			//        }
			aRetailer = new RetailerAbbreviations().TryConvertToAbbreviation(aRetailer);
			Report.Info("The Retailer from context after trying to convert to abbreviation is: " + aRetailer);
			List<ForwardProductRegistration.ProductResults> listProductResults = selForwardProdReg.GetProductResults();
			foreach (var productResults in listProductResults)
			{
				var upcs = productResults.UPCs;
				if (upcs != null && upcs.Any())
				{
					if (upcs.Any(x => x.UPCNumber == aUPCNumber && x.DestinationRetailers.Contains(aRetailer)))
					{
						Report.Success("UPC number: " + aUPCNumber + " displayed retailer: " + aRetailer + " as expected");
						Report.Screenshot();
						return;
					}
				}
			}
			Report.Failure("Failed to find retailer: " + aRetailer + " for UPC number: " + aUPCNumber);
		}

		[StepDefinition(@"I confirm that there are NO Errors displayed for the Product")]
		public void ThenIConfirmThatThereAreNoErrorsDisplayedForTheProduct()
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(!selForwardProdReg.ErrorsDisplayed(), "Errors are showing", "Errors are not showing");

		}

		[StepDefinition(@"In the Add UPC modal window I enter the following information:")]
		public void InTheAddUPCWindowIEnterTheFollowingInfo(Table table)
		{
			var modal = new AddUPCModal();
			TableRow row = table.Rows[0];
			Report.IsTrue(modal.EnterUPCInformation(row), "Failed to enter information into the Add Case UPC modal window.",
							"Successfully entered information into the Add Case UPC modal window.");
		}

		[StepDefinition(@"In the UPC modal window I click Save")]
		public void InTheUPCModalWindowIClickSave()
		{
			var modal = new AddUPCModal();

			if (modal.ClickSave())
			{
				Report.Success("Successfully clicked Save in the Add Case UPC modal window.", false);
			}
			else
			{
				Report.Failure("Failed to click Save in the Add Case UPC modal window.", false);
			}

		}


		[StepDefinition(@"In the Add Case UPC modal window I enter the following information:")]
		public void InTheAddCaseUPCWindowIEnterTheFollowingInfo(Table table)
		{
			var modal = new AddCaseUPCModal();
			TableRow row = table.Rows[0];
			Report.IsTrue(modal.EnterCaseUPCInformation(row), "Failed to enter information into the Add Case UPC modal window.",
				"Successfully entered information into the Add Case UPC modal window.");
		}

		[StepDefinition(@"In the Case UPC modal window I click Save")]
		public void InTheCaseUPCModalWindowIClickSave()
		{
			var modal = new AddCaseUPCModal();
			Report.IsTrue(modal.ClickSave(), "Failed to click Save in the Add Case UPC modal window.",
			"Successfully clicked Save in the Add Case UPC modal window.");
		}
		[StepDefinition(@"I select the product with ID saved as: (.*) under the right hand panel of the Select Products tab")]
		public void ISelectTheProductSavedAsUnderSelectProductsRightPanel(string savedAs)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			var ids = (string)Context.GetFromContext(savedAs);
			Report.IsTrue(selForwardProdReg.SelectProductsRightPanel_ClickProductByID(ids), "The Product with ID: " + ids + " was not selected", "The Product with ID: " + ids + " was selected");


		}

		[StepDefinition(@"In the Forward Product Registration Screen I select the first retailer under Other Retailers")]
		public void ThenInTheForwardProductRegistrationScreenISelectTheFirstRetailerUnderOtherRetailers()
		{
			Report.IsTrue(new ForwardProductRegistration().SelectFirstOtherRetailer(), "Failed to select the first Retailer under 'Other Retailers'", "Succesfully selected the first retailer under 'Other Retailers'");
		}

		[StepDefinition(@"In the UPC modal window I click Cancel")]
		public void InTheUPCModalWindowIClickCancel()
		{
			var modal = new AddUPCModal();
			Report.IsTrue(modal.ClickCancel(), "Failed to click Cancel in the Add UPC modal window.",
			"Successfully clicked Cancel in the Add UPC modal window.");
		}

		[StepDefinition(@"If the Private Label textbox is showing in the Select UPCs screen, I enter the value: (.*)")]
		public void IfPrivateLabelShowingIEnterValue(string value)
		{
			var selForwardProdReg = new ForwardProductRegistration();
			Report.IsTrue(selForwardProdReg.EnterPrivateLabelIfExists(value), "Failed to enter value " + value + " for Private Label.",
				"Successfully entered value for Private Label.");
		}

		[StepDefinition(@"In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: (.*) under Other Retailers and save it as: (.*)")]  //maybe pick a specific alternative instead of avoiding all with additional data requirments
		public void ThenInTheForwardProductRegistrationScreenISelectTheFirstRetailerThatIsNotXUnderOtherRetailers(string presentRetailer, string savedAs)
		{
			Report.IsTrue(new ForwardProductRegistration().SelectFirstOtherRetailerThatIsNotXOrRequireAdditionalDetails(presentRetailer, savedAs), "Failed to select the first Retailer that is not " + presentRetailer + " or requires additional data under 'Other Retailers'", "Succesfully selected the first retailer that is not " + presentRetailer + "  or requires additional data under 'Other Retailers'");
		}

		[StepDefinition(@"I confirm that UPC information is displayed in the Select UPCs Table")]
		public void ConfirmUPCInfromationInSelectUPCsTable()
		{

			var selForwardProdReg = new ForwardProductRegistration();
			List<ForwardProductRegistration.SelectUPCs> upcs = selForwardProdReg.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return;
			}
			Report.Info("There were: " + upcs.Count + " UPCs to check");
			bool noGaps = true;
			int i = 1;
			foreach (var item in upcs)
			{
				if (item.UPCInfo.UPCNumber == null)
				{
					Report.Failure("Upc number was not found for UPC: " + i + ".");
					noGaps = false;
				}
				if (item.ContainerType == null)
				{
					Report.Failure("Container Type was not found for UPC: " + i + ".");
					noGaps = false;
				}
				if (item.Size == null)
				{
					Report.Failure("Size was not found for UPC: " + i + ".");
					noGaps = false;
				}
				if (item.UPCInfo.DestinationRetailers == null)
				{
					Report.Failure("Destination Retailers was not found for UPC: " + i + ".");
					noGaps = false;
				}

			}

			Report.IsTrue(noGaps, "The select UPCs table on the right side is missing UPC information", "The select UPCs table on the right side is not missing information");

		}

		[StepDefinition("I Check that the Truck Icon is (present|not present) next to the UPC saved as: (.*)")]
		public void ICheckTruckIconStatusForSavedAs(string presence, string savedAs)
		{
			bool presenceExpected = false;
			switch (presence)
			{
				case "present":
					presenceExpected = true;
					break;
				case "not present":
					break;
				default:
					Report.Error("presence can only be 'present' or 'not present'");
					return;

			}

			var upcNum = (string)Context.GetFromContext(savedAs);
			var selForwardProdReg = new ForwardProductRegistration();
			List<ForwardProductRegistration.SelectUPCs> upcs = selForwardProdReg.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return;
			}
			foreach (var item in upcs)
			{
				if (item.UPCInfo.UPCNumber == upcNum)
				{
					if (item.UPCInfo.TruckIcon == presenceExpected)
					{
						Report.Success("The Truck Icon was succesfully found to be " + presence + " for the UPC: " + upcNum + ".");
						return;
					}
					Report.Failure("The Truck Icon was incorrectly found to be " + presence + " for the UPC: " + upcNum + ".");
					return;
				}
			}

			Report.Failure("The UPC with number: " + upcNum + " was not found.");


		}


		[StepDefinition(@"I get the product ID for the product saved as: (.*) then I use this ID in the select Products & UPCs page")]
		public void IGetTheProducIDForSavedAsAndSearcForProduct(string savedAs)
		{
			Report.Info("input value is " + savedAs + " . Looking in context for a product information with this value");
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string iD = productDetails.Id;
			Report.IsTrue(iD.Any(), "iD was empty: " + iD, "iD contained: " + iD);

			Context.AddToContext("idStringSavedAs", iD);
			new StepsForwardProductRegistration().SelectProductByIDSavedAs("idStringSavedAs");
		}

		[StepDefinition(@"I select one of the following retailers: and saved the chosen retailer as: (.*)")]
		public void ISelectOneOfTheFollowingRetailers(string retailerSavedAs, Table table)
		{
			foreach (var row in table.Rows)
			{
				var retailerName = row["Retailer"];
				if (Context.GetFromContextRegex(retailerName, out var result))
				{
					Report.Info("Getting retailer from context: " + retailerName);
					retailerName = result.ToString();
				}
				if (new ForwardProductRegistration().SelectRetailer(retailerName))
				{
					Report.Success("The Retailer: " + retailerName + " was selected successfully");
					Context.AddToContext(retailerSavedAs, retailerName);
					return;
				}
				Report.Info("Could not find: " + retailerName + " in the list of retailers");
			}
			Report.Failure("None of the retailers in the table could be selected");
		}

		[StepDefinition(@"I select one of the following retailers from the table: that is also not in the list saved as: (.*) and save the chosen retailer as: (.*)")]
		public void ISelectOneOfTheFollowingRetailersThatIsNotX(string existingRetailer, string retailerSavedAs, Table table)
		{
			foreach (var row in table.Rows)
			{
				var retailerName = row["Retailer"];
				if (Context.GetFromContextRegex(retailerName, out var result))
				{
					Report.Info("Getting retailer from context: " + retailerName);
					retailerName = result.ToString();
				}
				var alreadySelectedRetailers = (List<string>)Context.GetFromContext(existingRetailer);
				var abbr = new RetailerAbbreviations();
				string selectedAbbr = "";
				abbr.Map.TryGetValue(retailerName, out selectedAbbr);
				if (alreadySelectedRetailers.Any() && alreadySelectedRetailers.Contains(selectedAbbr))
				{
					Report.Info("Selected Retailer already exists. Selected another one.");
				}


				if (!alreadySelectedRetailers.Contains(selectedAbbr))
				{
					if (new ForwardProductRegistration().SelectRetailer(retailerName))
					{
						Report.Success("The Retailer: " + retailerName + " was selected successfully");
						Context.AddToContext(retailerSavedAs, retailerName);
						return;
					}
					Report.Info("Could not find: " + retailerName + " in the list of retailers");
				}

			}
			Report.Failure("None of the retailers in the table could be selected");

		}

		[StepDefinition(@"I click Add Case UPC")]
		public void GivenIClickAddCaseUPC()
		{
			UPC UPCObject = new UPC();
			Report.IsTrue(UPCObject.ClickAddCaseUPCButton(), "Failed to click the 'Add Case UPC' button", "Successfully clicked the 'Add Case UPC' button");
		}

		[StepDefinition(@"I confirm no error is shown below the Individual UPC contained in the Case Pack field")]
		public void ThenIConfirmNoErrorIsShownBelowTheIndividualUPCContainedInTheCasePackField()
		{
			UPC UPCObject = new UPC();
			Report.IsFalse(UPCObject.CheckForErrorUnderneathIndividualUPCContainedInCasePackField(), "The error message was found", "The error message was not found");
		}

		[StepDefinition(@"I check if the textfields with the following placeholders display the error 'This is a required field.' bottom")]
		public void ThenICheckIfTheFollowingTextfieldsDisplayTheErrorThisIsARequiredField(Table table)
		{
			UPC UPCObject = new UPC();
			UPCObject.CheckIfTextfieldsWithPlaceholdersDisplayTheError(table);
		}

		[StepDefinition(@"I check if the dropdowns with the following default options display the error 'This is a required field.' bottom")]
		public void ThenICheckIfTheFollowingDropdownsDisplayTheErrorThisIsARequiredField_(Table table)
		{
			UPC UPCObject = new UPC();
			Report.IsTrue(UPCObject.CheckIfDropDownsWithDefaultOptionDisplayTheError(table), "At least one dropdown did not display an error", "All the dropdowns displayed their errors");
		}

		[StepDefinition(@"I select the first non Kit product from the list of IDs saved as: (.*) under the Select Products tab")]
		public void SelectNonKitProductByIDSavedAs(string savedAs)
		{

			var selForwardProductReg = new ForwardProductRegistration();
			Report.Info($"Attempting to select the first product from the list saved as: {savedAs} that is not a kit product");
			var ids = (List<string>)Context.GetFromContext(savedAs);
			if (ids == null)
			{
				Report.Failure("Could not find product IDs in context saved as: " + savedAs);
				return;
			}
			bool clicked = false;
			foreach (string id_ in ids)
			{
				Report.Info("Attempting to select product with id: " + id_);
				this.EnterTextInSearchByIDOrProductNameField(id_);
				if (selForwardProductReg.GetTopProductNameFromSelectProductList().IsNullOrEmpty())
				{
					Report.Info($"No Product Name was found for the product with id: {id_}");

				}
				else
				{
					if (selForwardProductReg.GetTopProductNameFromSelectProductList().ToLower().Contains("kit"))
					{
						Report.Info($"The Product Name for id: {id_} contained the word kit. Moving onto the next ID in the list saved as: {savedAs}");
					}
					else
					{
						if (selForwardProductReg.SelectProducts_ClickProductByID(id_))
						{
							Report.Success("Successfully selected product with ID: " + id_);
							Report.Screenshot();
							clicked = true;
							break;
						}
					}

				}


			}
			if (!clicked)
			{
				Report.Failure("Failed to select any of the products with ID in the list saved as: " + savedAs);
				Report.Screenshot();
			}


		}

		[StepDefinition(@"I wait for the Add Case UPC popup to appear")]
		public void IWaitForTheAddCaseUPCPopupToAppear()
		{
			Report.IsTrue(new AddCaseUPCModal().WaitForAddCaseUPCPopup(), "The Add Case UPC modal did not appear", "The Add case upc modal appeared");
		}

		[StepDefinition(@"If there is the option to select a vendor for the product with ID: (.*), I select the first option")]
		public void IfThereIsTheOptionToSelectVendorISelect(string id)
		{
			Report.Info("Checking to see if there is the option to select a Vendor");
			var frwdProdReg = new ForwardProductRegistration();
			if (id.ToLower().Contains("saved as"))
			{
				var PI = (ProductInformation)Context.GetFromContext(id.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
				if (PI == null)
				{
					throw new Exception("Failed to find product: " + id);
				}

				id = PI.Id;
			}
			Report.Info("Checking to see if there is the option to select a Vendor");
			if (!frwdProdReg.GivenProductCheckVendorSelect(id))
			{
				Report.Info($"There was no option for selecting a vendor for the product with ID: {id}");
				return;
			}
			Report.Info($"There the option for select vendor for ID: {id} was found!");
			string firstOption = frwdProdReg.GivenProductFirstAvailableVendor(id);
			Report.Info($"The first vendor option for ID: {id} was found as: {firstOption}");
			Report.Info($"Selecting the option: {firstOption} for ID: {id}");
			Report.IsTrue(frwdProdReg.GivenProductSelectVendor(id, firstOption), "Failed to select the option", "Successfully selected the option");
		}


	}
}

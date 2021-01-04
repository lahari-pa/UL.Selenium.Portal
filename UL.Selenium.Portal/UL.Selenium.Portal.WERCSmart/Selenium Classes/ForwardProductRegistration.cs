
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.SpecFlow.Classes;
using System;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ForwardProductRegistration : SeleniumBaseObject
	{
		// Again a pretty poor/generic ID, but it's the best we have....
		public const string BasePath = "//div[@id='dataentry']";
		protected override By ContainerElementLocator => By.XPath(BasePath);


		private IWebElement SelectAllUpcs => this.containerElement.FindElement(By.XPath(".//div[./h3[text()='Select UPCs']]//thead//input[@type='checkbox']"), 1);

		public bool ClickSelectAllUpcs => this.SelectAllUpcs.TryClick();

		public bool ErrorsExist()
		{
			ReadOnlyCollection<IWebElement> errors = this.containerElement.FindElements(By.XPath(".//i[contains(@class, 'exclamation')]"));
			return errors.Count > 0;
		}
		public bool ErrorsDisplayed()
		{
			try
			{
				bool errorsDisplayed = this.containerElement.FindElement(By.XPath(".//i[contains(@class, 'exclamation')]//ancestor::p//ancestor::div[@data-bind and @style]"), 2).Displayed;
				return errorsDisplayed;
			}
			catch (Exception)
			{
				return false;
			}
		}


		public List<string> ListOfRetailers()
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'wizard-step-panel')]/div[@role='tabpanel']/div//input[@type='checkbox']/../span"), 2);
			if (els.Count == 0)
			{
				return null;
			}

			return els.Select(x => x.Text.Trim()).ToList();
		}

		/// <summary>
		/// this is the title of the page Forward Product Registration
		/// </summary>
		/// <returns></returns>
		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//h2"), 2).Text.Trim();
		}

		/// <summary>
		/// This is the fourth area on the page You most recently did business with
		/// </summary>
		/// <returns></returns>
		public List<string> SubHeadings4Showing()
		{
			return this.containerElement.FindElements(By.XPath(".//h4"), 2).Select(x => x.Text.Trim()).ToList();
		}

		/// <summary>
		/// this is the third area on the page sub heading Select Retailers
		/// </summary>
		/// <returns></returns>
		public List<string> SubHeadings3Showing()
		{
			return this.containerElement.FindElements(By.XPath(".//h3"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public bool EnterTextToSearchField(string value)
		{
			IWebElement searchEl = this.containerElement.FindElement(By.XPath(".//input[@type='text' and contains(@placeholder,'Start typing Product name or WPSID')]"), 2);
			if (searchEl == null)
			{
				Report.Info("The search box element was not found");
				return false;
			}
			Report.Info("Attempting to enter text into the search field...");
			searchEl.EnterText(value);
			return searchEl.GetAttribute("value") == value && GeneralUtilities.Wait_for_load_finish();
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@data-bind='click: next']"), 2).TryClick();
		}

		public bool ClickHome()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='btn btn-success btn-lg']"), 2).TryClick();
		}

		public bool SelectProducts_ClickTheFirstProductCheckbox()
		{
			var productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2).ToList();
			if (productRows.Count == 0)
			{
				Report.Info("No product rows were returned!");
				return false;
			}
			foreach (IWebElement row in productRows)
			{
				if (row.FindElement(By.XPath(".//input[@type='checkbox']"), 2).TryClick())
				{
					return true;
				}
			}
			return false;
		}

		public List<string> SelectProducts_GetListOfIDs()
		{
			ReadOnlyCollection<IWebElement> products = this.containerElement.FindElements(By.XPath(".//tbody/tr/td//label[contains(@data-bind, 'wpsid')]"));
			return products.Select(x => x.GetValue()).ToList();
		}

		public bool SelectProducts_ClickProductByID(string id)
		{
			IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2).TryClick();
		}

		public bool CheckProductsSelected_CheckProductSelectedByID(string id)
		{
			IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2).Checked();
		}
		public bool SelectProducts_ClickProductByID_(string id)
		{
			IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			IWebElement inputEl = productRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
			if (inputEl == null)
			{
				return false;
			}
			inputEl.Click();
			Report.Screenshot();
			return true;
		}

		public string SelectProducts_FirstProductID()
		{
			var productRows = this.containerElement.FindElements(By.XPath(".//table[contains(@data-bind,'searchResults')]/tbody/tr"), 2).ToList();
			if (productRows.Count == 0)
			{
				Report.Info("No product rows were returned!");
				return null;
			}
			foreach (IWebElement row in productRows)
			{
				if (row.FindElement(By.XPath(".//input[@type='checkbox']"), 2) != null)
				{
					return row.FindElement(By.XPath(".//label[contains(@data-bind,'wpsid')]"), 2)?.Text;
				}
			}
			return null;
		}

		public bool SelectProducts_ProductIsChecked(string id)
		{
			IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2).Checked();
		}
		public bool SelectProducts_ProductCheckboxDisabled(bool disabledCheck)
		{
			ReadOnlyCollection<IWebElement> inputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox']"));
			if (!inputs.Any())
			{
				return false;
			}
			ReadOnlyCollection<IWebElement> disabledInputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox' and @disabled]"));
			int timer = 0;
			bool disabled = !disabledCheck;
			while (timer < 100 && disabled != disabledCheck)
			{
				if (disabledInputs.Any())
				{
					disabled = disabledCheck;
				}
				Delay.Seconds(0.1);
				disabledInputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox' and @disabled]"));
				timer++;
			}
			return disabled;
		}
		public bool SelectProducts_ProductCheckboxIsDisabled()
		{
			ReadOnlyCollection<IWebElement> inputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox']"));
			if (!inputs.Any())
			{
				return false;
			}
			ReadOnlyCollection<IWebElement> disabledInputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox' and @disabled]"));
			return disabledInputs.Any();
		}

		public List<string> GetListOfOtherRetailers()
		{
			ReadOnlyCollection<IWebElement> retailers = this.containerElement.FindElements(By.XPath(".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//span"));
			if (!retailers.Any())
			{
				return new List<string>();
			}
			else
			{
				return retailers.Select(x => x.GetValue()).ToList();
			}
		}

		public bool SelectOtherRetailer(string retailer)
		{
			IWebElement retailerInput = this.containerElement.FindElement(By.XPath(@".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//span[contains(text(),""" + retailer + @""")]/../input"), 2);

			if (retailerInput == null)
			{
				Report.Info("Retailer input could not be found");
				return false;
			}
			return retailerInput.TryCheck();
		}

		public bool SelectFirstOtherRetailer()
		{
			IWebElement retailerInput = this.containerElement.FindElement(By.XPath(".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//div[@class='control-indicator']"), 2);

			if (retailerInput == null)
			{
				Report.Info("The First Retailer could not be found");
				return false;
			}
			return retailerInput.TryClick();
		}
		public bool SelectFirstOtherRetailerThatIsNotXOrRequireAdditionalDetails(string presentRetailer, string savedAs)
		{
			//IWebElement retailerInput = this.containerElement.FindElement(By.XPath(".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//div[@class='control-indicator']"), 2);

			List<IWebElement> retailerInputs = this.containerElement.FindElements(By.XPath(".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//label//span"), 2).ToList();

			if (!retailerInputs.Any())
			{
				Report.Info("No retailers could be found under 'Other Retailers'.");
				return false;
			}

			string[] avoidRetailersArray = new string[] { presentRetailer, "Best Buy", "Dick's Sporting Goods", "Kroger", "Canadian Tire", "Albertsons Companies" };

			var retailer = retailerInputs.FirstOrDefault(x => !avoidRetailersArray.Contains(x.GetValue(true)));

			if (retailer != null)
			{
				string chosenRetailerName = retailer.Text;
				Report.Info("Selecting retailer: " + chosenRetailerName);
				Context.AddToContext(savedAs, chosenRetailerName);
				return retailer.FindElement(By.XPath(@".//following-sibling::div[@class='control-indicator']"), 2).TryClick();

			}

			return false;
			//string firstRetailerName = retailerInput.FindElement(By.XPath(".//ancestor::label//span"), 2).Text; //[text()='Ahold']
			//if (firstRetailerName == presentRetailer||firstRetailerName==""||firstRetailerName==""||firstRetailerName=="") //change to add avoided retailers
			//{

			//	IWebElement nextRetailerInput = retailerInput.FindElement(By.XPath($"//ancestor::label//span[not(text()='{presentRetailer}') and not(text()='Best Buy') and not(text()='DI') and not(text()='KG')]"), 2); //change to add accurate avoided retailers
			//	return nextRetailerInput.TryClick();

			//}
			//return retailerInput.TryClick();
		}





		public bool SelectRetailer(string retailer)
		{
			var retailers = this.containerElement.FindElements(By.XPath(@".//div[@class='col-sm-3 retailer-select' and .//span[contains(text(),""" + retailer + @""")]]"), 2).ToList();
			if (retailers.Count == 0)
			{
				Report.Info("No retailer tiles were found!");
				return false;
			}
			return retailers.First().FindElement(By.XPath(".//label"), 2).TryClick() && retailers.First().FindElement(By.XPath(".//input"), 2).Checked();
		}

		public bool AllWalMartAffiliatesSelected()
		{
			var retailers = this.containerElement.FindElements(By.XPath(@".//div[@class='col-sm-3 retailer-select' and .//span[contains(text(),""Wal-Mart/SAM'S CLUB"")]]"), 2).ToList();
			if (retailers.Count == 0)
			{
				Report.Info("There were no Walmart affiliate retailers displayed");
				return false;
			}
			var retailerInput = retailers.Select(x => x.FindElement(By.XPath(".//input"), 2)).ToList();
			return retailerInput.All(x => x.Checked());
		}

		public string ActiveTab()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='prog-step active']"), 2)?.Text;
		}

		public bool FirstProductSelectVendor(string option)
		{
			List<SelectProducts> products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Failure("No Product rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			Report.Info("Selecting vendor: " + option + " for the first product in the grid");
			products.First().SelectVendor = option;
			Delay.Seconds(1);
			string vendor = products.First().SelectVendor;
			return vendor == option;
		}

		public string FirstProductSelectedVendor()
		{
			List<SelectProducts> products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Failure("No Product rows were found in the grid");
				Report.Screenshot();
				return null;
			}
			var options = products.First().VendorOptions();
			if (options.Any())
			{
				return options.First(x => x != "Choose...");
			}
			return null;
		}

		public bool GivenProductCheckVendorSelect(string wantedID)
		{
			List<SelectProducts> products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Failure("No Product rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			bool foundProduct = false;
			SelectProducts wantedProduct = new SelectProducts();
			foreach (var product in products)
			{
				if (product.ID == wantedID)
				{
					wantedProduct = product;
					foundProduct = true;
					break;
				}
			}
			if (foundProduct == false)
			{
				Report.Failure($"There was no Product with ID: {wantedID} found");
				Report.Screenshot();
				return false;
			}
			Report.Info("Checking to see if the product found has the option to select a vendor");
			if (wantedProduct.SelectVendor == null)
			{
				Report.Info("The Select Vendor option was not found");
				return false;
			}
			Report.Info("The select vendor option was found");
			return true;

		}



		public bool GivenProductSelectVendor(string wantedID, string option)
		{
			List<SelectProducts> products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Failure("No Product rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			bool foundProduct = false;
			SelectProducts wantedProduct = new SelectProducts();
			foreach (var product in products)
			{
				if (product.ID == wantedID)
				{
					wantedProduct = product;
				}
			}
			if (foundProduct == false)
			{
				Report.Failure($"There was no Product with ID: {wantedID} found");
				Report.Screenshot();
				return false;
			}
			Report.Info("Selecting vendor: " + option + " for the first product in the grid");
			wantedProduct.SelectVendor = option;
			Delay.Seconds(1);
			string vendor = wantedProduct.SelectVendor;
			return vendor == option;
		}



		public string GivenProductFirstAvailableVendor(string wantedID)
		{
			List<SelectProducts> products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Failure("No Product rows were found in the grid");
				Report.Screenshot();
				return null;
			}
			bool foundProduct = false;
			SelectProducts wantedProduct = new SelectProducts();
			foreach (var product in products)
			{
				if (product.ID == wantedID)
				{
					wantedProduct = product;
				}
			}
			if (foundProduct == false)
			{
				Report.Failure($"There was no Product with ID: {wantedID} found");
				Report.Screenshot();
				return null;
			}
			var options = wantedProduct.VendorOptions();
			if (options.Any())
			{
				return options.First(x => x != "Choose...");
			}
			return null;
		}

		public bool SelectFirstUPC()
		{
			List<SelectUPCs> upcs = this.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			Report.Info("Selecting UPC: " + upcs.First().UPCInfo.UPCNumber);
			return upcs.First().SelectUPC();
		}

		public bool SelectEditForFirstUPC()
		{
			List<SelectUPCs> upcs = this.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			Report.Info("Selecting Edit for first UPC: " + upcs.First().UPCInfo.UPCNumber);
			return upcs.First().ClickEditForUPC();
		}

		public bool ConfirmPackageTypeNotShown()
		{
			var editUPCs = new EditUPC();
			return editUPCs.ConfirmPackageTypeNotShown();
		}

		public bool ConfirmTransportationShown()
		{
			var editUPCs = new EditUPC();
			return editUPCs.ConfirmTransportationShown();
		}

		public bool EditPopupConfirmOptionAtLevel(string option, string level)
		{
			var editUPCs = new EditUPC();
			return editUPCs.EditPopupConfirmOptionAtLevel(option, level);
		}

		public bool EditPopupConfirmCannotDowngrade(string option, string level)
		{
			var editUPCs = new EditUPC();
			return editUPCs.EditPopupConfirmCannotDowngrade(option, level);
		}

		public bool EditUPCUpgradeOptionToLevel(string option, string level)
		{
			var editUPCs = new EditUPC();
			return editUPCs.EditUPCUpgradeOptionToLevel(option, level);
		}

		public bool SetSizeAttribute(string value)
		{
			var editUPCs = new EditUPC();
			return editUPCs.SetSizeAttribute(value);
		}

		public bool ClickSave()
		{
			var editUPCs = new EditUPC();
			return editUPCs.ClickButton("Save");
		}

		public bool SelectUPCByNumber(string aUPCNumber)
		{
			var thisSelectUPCs = new SelectUPCs {
				UPCInfo = new UPC() { UPCNumber = aUPCNumber }
			};
			return thisSelectUPCs.SelectUPC();
		}

		public bool ClickActionByUPCNumber(string aUPCNumber, string action)
		{
			var thisUPC = new UPC() { UPCNumber = aUPCNumber };
			return thisUPC.ClickAction(action);
		}

		public bool SelectFirstProduct_SelectUPCs()
		{
			List<SelectProducts> products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Info("No products rows were displayed under Select Products & UPCs");
				return false;
			}
			return products.First().ClickProduct();
		}

		public List<SelectUPCs> GetUPCs()
		{
			var rUPCs = new List<SelectUPCs>();
			IList<IWebElement> upcRows = this.containerElement.FindElements(By.XPath(".//div[./h3[text()='Select UPCs']]//tbody/tr"), 2);
			foreach (IWebElement row in upcRows)
			{

				bool currentIcon = false;
				try
				{
					currentIcon = row.FindElement(By.XPath(".//i[@class='fa fa-truck']"), 2).Displayed;
				}
				catch (NullReferenceException e)
				{
					currentIcon = false;
				}

				rUPCs.Add(new SelectUPCs {
					UPCInfo = new UPC {
						DestinationRetailers = row.FindElement(By.XPath(".//span[@data-bind='text: identifier']"), 2)?.Text,
						UPCNumber = row.FindElement(By.XPath(".//span[contains(@data-bind,'upcNumber.field')]"), 2)?.Text,
						TruckIcon = currentIcon
					},
					ContainerType = row.FindElement(By.XPath(".//span[contains(@data-bind,'typeToString')]"), 2)?.Text,
					Size = row.FindElement(By.XPath(".//span[contains(@data-bind,'size.field')]"), 2)?.Text,
					Quantity = row.FindElement(By.XPath(".//span[contains(@data-bind,'text: quantity.field')]"), 2)?.Text,
					TransportationOption = row.FindElement(By.XPath(".//span[contains(@data-bind,'text: transportToString()')]"), 2)?.Text,
					UPCContained = row.FindElement(By.XPath(".//span[contains(@data-bind,'text: upcContained.field')]"), 2)?.Text
				});
			}
			return rUPCs;
		}

		public List<SelectProducts> GetProducts()
		{
			var rProducts = new List<SelectProducts>();
			IList<IWebElement> productRows = this.containerElement.FindElements(By.XPath(".//table[.//th[contains(text(),'Product Name')]]/tbody/tr"), 2);
			foreach (IWebElement row in productRows)
			{
				rProducts.Add(new SelectProducts {
					ID = row.FindElement(By.XPath(".//label[contains(@data-bind,'product.wpsid')]"), 2)?.Text,
					Name = row.FindElement(By.XPath(".//p[contains(@data-bind,'product.name')]"), 2)?.Text,
					InternalID = row.GetAttribute("id")
				});
			}
			return rProducts;
		}

		public List<ProductResults> GetProductResults()
		{
			var rProductResults = new List<ProductResults>();
			IList<IWebElement> productTables = this.containerElement.FindElements(By.XPath(".//div[@class='panel-body']//table"), 2);
			foreach (IWebElement product in productTables)
			{
				var upcRows = product.FindElements(By.XPath("./tbody/tr"), 2).ToList();
				var upcs = new List<UPC>();
				upcRows.ForEach(x => upcs.Add(new UPC {
					UPCNumber = x.FindElement(By.XPath(".//span[contains(@data-bind,'upcNumber')]"), 2)?.Text,
					DestinationRetailers = x.FindElement(By.XPath(".//span[contains(@data-bind,'identifier')]"), 2)?.Text
				}));
				rProductResults.Add(new ProductResults {
					ProductHeader = product.FindElement(By.XPath("./thead/tr"), 2)?.Text,
					UPCs = upcs
				});
			}
			return rProductResults;
		}

		public bool ClickAddUPC()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@id='add-new-row-btn' and contains(@data-bind,'addNewRow')]"), 2).TryClick();
		}

		public bool ClickAddCaseUPC()
		{
			return this.containerElement.FindElement(By.XPath("//button[@id='add-new-row-btn' and contains(@data-bind,'addNewPackRow')]"), 2).TryClick();
		}




		public bool ClickAddToNoRetailer()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@id='add-new-row-btn' and contains(@data-bind,'addToNoRetailer')]"), 2).TryClick();
		}

		public bool SelectUPCNoUPC()
		{
			return this.containerElement.FindElement(By.XPath(".//td[./following-sibling::td[./strong[text()='No UPC']]]/input"), 2).TryClick();
		}

		public bool ReviewAndSubmit_AreStatementsTrue(string value)
		{
			if (value.ToLower() != "true" && value.ToLower() != "false")
			{
				Report.Info("Are statements true option must be 'true' or 'false'");
				return false;
			}
			return this.containerElement.FindElement(By.XPath(".//input[@name='areStatementsTrue' and @value='" + value + "']"), 2).TryClick();
		}
		public bool SelectProductsRightPanel_ClickProductByID(string id)
		{
			IWebElement productRow = this.containerElement.FindElement(By.XPath($"//table[contains(@data-bind,'selectedProds')]//tr//td//label[contains(text(),'{id}')]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath($".//ancestor::tr//td//input[@type='checkbox']"), 2).TryClick();
		}

		public bool CheckProductsRightPanel_CheckProductByID(string id)
		{
			IWebElement productRow = this.containerElement.WaitUntilElementVisible(By.XPath($"//table[contains(@data-bind,'selectedProds')]//tr//td//label[contains(text(),'{id}')]"), 10);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow != null;
		}

		public bool EnterPrivateLabelIfExists(string value)
		{
			IWebElement privateLabelInput = this.containerElement.FindElement(By.XPath(@"//label[contains(text(), 'Private Label')]/following-sibling::input"), 2);
			if (privateLabelInput != null)
			{
				privateLabelInput.TryClick();
				Report.Info("Found private label input box. Attempting to enter text.");
				return privateLabelInput.TryEnterText(value);
			}
			else
			{
				Report.Info("Failed to find private label input box. Moving on.");
				return true;
			}
		}

		public string GetTopProductNameFromSelectProductList()
		{
			IWebElement productNameElement = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label]//td//label[@data-bind='text: name']"), 2);
			if (productNameElement == null)
			{
				Report.Info("Could not find the element for the ProductName");
				return null;
			}
			return productNameElement.Text;
		}

		public bool EnsureUPCsTableHasTransportationColumn()
		{
			IWebElement transColumn = this.containerElement.FindElement(By.XPath(@"//h3[contains(text(), 'Select UPCs')]/..//table//th[contains(text(), 'Transportation')]"), 2);
			return transColumn != null;
		}

		public bool EnsureThatOptionIsListedAtLevel(string option, string level)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(@"//span[contains(text(), '" + option + "')]/../div//span[contains(text(), '" + level + "')]"), 2);
			return elem != null;
		}

		public class SelectProducts : ForwardProductRegistration
		{
			public string ID { get; set; }
			public string Name { get; set; }
			public string InternalID { get; set; }
			public string SelectVendor {
				get
				{
					IWebElement row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
					IWebElement select = row.FindElement(By.XPath(".//select[contains(@data-bind,'vendors')]"), 2);
					if (select == null)
					{
						Report.Info("The Select Vendor element could not be found!");
						return null;
					}
					return select.SelectedOption();
				}
				set
				{
					IWebElement row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
					IWebElement select = row.FindElement(By.XPath(".//select[contains(@data-bind,'vendors')]"), 2);
					if (select == null)
					{
						Report.Info("The Select Vendor element could not be found!");
						return;
					}
					if (select.FindElements(By.XPath("./option"), 2).All(x => x.Text != value))
					{
						Report.Info("The specified vendor option was not available. Selecting the first vendor");
						return;
					}
					select.Select(value);
				}
			}
			public bool ClickProduct()
			{
				IWebElement row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
				return row.TryClick() && row.GetAttribute("class") == "active";
			}

			public List<string> VendorOptions()
			{
				IWebElement row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
				IWebElement select = row.FindElement(By.XPath(".//select[contains(@data-bind,'vendors')]"), 2);
				if (select == null)
				{
					Report.Info("The Select Vendor element could not be found!");
					return null;
				}
				return select.FindElements(By.XPath("./option"), 1)?.Select(x => x.Text).ToList();
			}



		}

		public class SelectUPCs : ForwardProductRegistration
		{
			public UPC UPCInfo { get; set; }
			public string ContainerType { get; set; }
			public string Size { get; set; }
			public string Quantity { get; set; }
			public string TransportationOption { get; set; }
			public string UPCContained { get; set; }
			public bool SelectUPC()
			{
				return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCInfo.UPCNumber + "']]/td/input"), 2).TryClick();
			}
			public bool ClickEditForUPC()
			{
				return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCInfo.UPCNumber + "']]/td/a"), 2).TryClick();

			}

		}

		public class ProductResults : ForwardProductRegistration
		{
			public string ProductHeader { get; set; }
			public List<UPC> UPCs { get; set; }

		}

		// Works on both Select UPCs tab and Product Results tab
		public class UPC : ForwardProductRegistration
		{
			public string UPCNumber { get; set; }
			public string DestinationRetailers { get; set; }
			public bool TruckIcon { get; set; }
			public bool SelectUPC()
			{
				return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCNumber + "']]/td//input[@class='checkbox']"), 2).TryClick();
			}
			public bool ClickAction(string action)
			{
				if (action.ToLower() == "edit")
				{
					return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCNumber + "']]/td/a[contains(@data-bind,'edit')]"), 2).TryClick();
				}
				if (action.ToLower() == "remove")
				{
					return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCNumber + "']]/td/a[contains(@data-bind,'remove') or contains(@data-bind,'delete')]"), 2).TryClick();
				}
				return false;
			}
		}

		public class EditUPC : SeleniumBaseObject
		{
			public const string BasePath =
				"//div[contains(@class, 'modal-dialog')]//h4[contains(text(), 'Edit UPC')]/../..";

			protected override By ContainerElementLocator => By.XPath(BasePath);

			public string UPCNumber {
				get
				{
					IWebElement input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='UPC Number']"), 2);
					if (input == null)
					{
						Report.Info("The UPC Number input could not be found!");
						return null;
					}

					return input.GetValue();
				}
				set
				{
					IWebElement input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='UPC Number']"), 2);
					if (input == null)
					{
						Report.Error("The UPC Number input could not be found!");
					}

					if (!input.TryEnterText(value))
					{
						Report.Error("Failed to enter text: " + value + " into UPC Number input");
					}
				}
			}

			public string Size {
				get
				{
					IWebElement input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and contains(@placeholder,'Size')]"), 2);
					if (input == null)
					{
						Report.Info("The Size input could not be found!");
						return null;
					}

					return input.GetValue();
				}
				set
				{
					IWebElement input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='Size (Weight Ounces)']"), 2);
					if (input == null)
					{
						Report.Error("The Size input could not be found!");
					}

					if (!input.TryEnterText(value))
					{
						Report.Error("Failed to enter text: " + value + " into Size input");
					}
				}
			}

			public string Type {
				get
				{
					IWebElement input = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'options: row.control.types()')]"), 2);
					if (input == null)
					{
						Report.Info("The Type select box could not be found!");
						return null;
					}

					return input.SelectedOption();
				}
				set
				{
					IWebElement input = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'options: row.control.types()')]"), 2);
					if (input == null)
					{
						Report.Error("The Type select box could not be found!");
					}

					input.Select(value);

					if (input.SelectedOption() != value)
					{
						Report.Error("Failed to select: " + value + " for Type");
					}
				}
			}

			public string Quantity {
				get
				{
					IWebElement input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='Quantity']"), 2);
					if (input == null)
					{
						Report.Info("The Quantity input could not be found!");
						return null;
					}

					return input.GetValue();
				}
				set
				{
					IWebElement input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='Quantity']"), 2);
					if (input == null)
					{
						Report.Error("The Quantity input could not be found!");
					}

					if (!input.TryEnterText(value))
					{
						Report.Error("Failed to enter text: " + value + " into Quantity input");
					}
				}
			}
			public string IndividualUPCContainedInTheCasePack {
				get
				{
					IWebElement input = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'options: row.control.notPackUpcs()')]"), 2);
					if (input == null)
					{
						Report.Info("The Individual UPC select box could not be found!");
						return null;
					}

					return input.SelectedOption();
				}
				set
				{
					IWebElement input = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'options: row.control.notPackUpcs()')]"), 2);
					if (input == null)
					{
						Report.Error("The Individual UPC select box could not be found!");
					}

					input.Select(value);

					if (input.SelectedOption() != value)
					{
						Report.Error("Failed to select: " + value + " for Individual UPC");
					}
				}
			}

			public string TransportationOptions {
				get
				{
					IWebElement input = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'options: row.control.transportOptions()')]"), 2);
					if (input == null)
					{
						Report.Info("The Transportation Options select box could not be found!");
						return null;
					}

					return input.SelectedOption();
				}
				set
				{
					IWebElement input = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'options: row.control.transportOptions()')]"), 2);
					if (input == null)
					{
						Report.Error("The Transportation Options select box could not be found!");
					}

					input.Select(value);

					if (input.SelectedOption() != value)
					{
						Report.Error("Failed to select: " + value + " for Transportation Option");
					}
				}
			}

			public List<string> Retailer {
				get
				{
					ReadOnlyCollection<IWebElement> inputs = this.containerElement.FindElements(By.XPath(
						".//input[@type='checkbox' and @id='chkAllRetailers']/..|.//input[@type='checkbox']/../span"));
					if (inputs.Count == 0)
					{
						Report.Info("No retailer checkboxes could not be found!");
						return null;
					}

					return inputs.Select(x => x.GetValue()).ToList();
				}
				set
				{
					ReadOnlyCollection<IWebElement> inputs = this.containerElement.FindElements(By.XPath(
						".//input[@type='checkbox' and @id='chkAllRetailers']/..|.//input[@type='checkbox']/../span"));
					if (inputs.Count == 0)
					{
						Report.Info("No retailer checkboxes could not be found!");
					}

					foreach (string thisRetailer in value)
					{
						IWebElement matchingRetailerInput = inputs.FirstOrDefault(x => x.GetValue() == thisRetailer);
						if (matchingRetailerInput == null)
						{
							Report.Error("Failed to find matching checkbox : " + thisRetailer);
						}
						else
						{
							if (!matchingRetailerInput.TryCheck())
							{
								Report.Error("Failed to select: " + thisRetailer);
							}
						}
					}
				}
			}

			public bool ClickButton(string button)
			{
				IList<IWebElement> buttons = this.containerElement.FindElements(By.XPath(".//button"), 2);
				if (buttons.Count == 0)
				{
					Report.Info("No buttons were found");
					return false;
				}

				IWebElement matchingButton = buttons.FirstOrDefault(x => x.GetValue().ToLower() == button.ToLower());

				if (matchingButton == null)
				{
					Report.Info("Buttons were found but not one that matched: " + button);
					return false;
				}

				return matchingButton.TryClick();

			}

			public bool ConfirmPackageTypeNotShown()
			{
				IWebElement packageType = this.containerElement.FindElement(By.XPath("//label[text()='Packaging Type']"), 2);
				if (packageType == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			public bool ConfirmTransportationShown()
			{
				Delay.Seconds(2);
				IWebElement transport = this.containerElement.FindElement(By.XPath("//label[text()='Transportation']"), 2);
				if (transport == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}

			public bool EditPopupConfirmOptionAtLevel(string option, string level)
			{
				Delay.Seconds(2);
				IWebElement transportOption = this.containerElement.FindElement(By.XPath("//label[text()='Transportation']/../div/div/span[text()='" + option + "']/preceding-sibling::input/../div/span[text()='" + level + "']/preceding-sibling::input"), 2);
				if (transportOption == null || !transportOption.Checked())
				{
					Report.Info("Option " + option + " was not selected!");
					return false;
				}
				return true;
			}

			public bool EditPopupConfirmCannotDowngrade(string option, string level)
			{
				IWebElement transportOption = this.containerElement.FindElement(By.XPath("//label[text()='Transportation']/../div/div/span[text()='" + option + "']/preceding-sibling::input/../div/span[text()='" + level + "']/preceding-sibling::input"), 2);
				if (transportOption == null)
				{
					Report.Info("Failed to find " + level + " for option " + option + ".");
					return false;
				}
				if (transportOption.Checked())
				{
					Report.Info("Level " + level + " was already selected for option " + option + ".");
					return false;
				}

				transportOption.TryClick();

				if (transportOption.Checked())
				{
					Report.Info("I was erroneously able to select " + level + " for option " + option + ".");
					return false;
				}

				return true;
			}

			public bool EditUPCUpgradeOptionToLevel(string option, string level)
			{
				IWebElement transportOption = this.containerElement.FindElement(By.XPath("//label[text()='Transportation']/../div/div/span[text()='" + option + "']/preceding-sibling::input/../div/span[text()='" + level + "']/preceding-sibling::input"), 2);
				if (transportOption == null)
				{
					Report.Info("Failed to find " + level + " for option " + option + ".");
					return false;
				}
				if (transportOption.Checked())
				{
					Report.Info("Level " + level + " was already selected for option " + option + ".");
					return false;
				}

				transportOption.TryClick();

				if (!transportOption.Checked())
				{
					Report.Info("I was unable to upgrade to " + level + " for option " + option + ".");
					return false;
				}

				return true;

			}

			public bool SetSizeAttribute(string value)
			{
				IWebElement size = this.containerElement.FindElement(By.XPath(@"//label[text()='Size (Ounces)']/following-sibling::input"), 2);
				return size.TryEnterText(value);
			}
		}

	}

	class AddUPCModal : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='modal-content']");

		public bool EnterUPCInformation(TableRow row)
		{
			if (row["UPC Number"].ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(row["UPC Number"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					row["UPC Number"] = savedUPC;
				}
				catch (Exception e)
				{
					Report.Info("Failed to find saved item in context: " + row["UPC Number"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
					throw;
				}
			}

			IWebElement upcNumber = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'UPC Number')]"), 2);
			if (upcNumber == null || !upcNumber.TryEnterText(row["UPC Number"]))
			{
				Report.Info("Failed to enter the UPC Number in the Add UPC modal window.");
				return false;
			}

			IWebElement type = this.containerElement.FindElement(By.XPath(@"//div//label[text() = 'Type']/following-sibling::select"), 2);
			if (type == null)
			{
				Report.Info("Failed to select type from the Type drop down in the Add UPC modal window.");
				return false;
			}
			else if (row["Type"] == "<first>")
			{
				var firstOption = type.FindElement(By.XPath("./option[not(text()='Type')]"), 1).Text;
				if (firstOption == null)
				{
					Report.Failure("There are no Container Types");
					return false;
				}
				else
				{
					type.Select(firstOption);
				}
			}

			else
			{
				type.Select(row["Type"]);
			}

			IWebElement size = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'Size (Ounces)')]"), 2);
			if (size == null || !size.TryEnterText(row["Size (Ounces)"]))
			{
				Report.Info("Failed to enter the Size (Ounces) in the Add UPC modal window.");
				return false;
			}

			if (row["Retailer"] == "Select all")
			{
				IWebElement retailer = this.containerElement.FindElement(By.XPath(@"//div//input[@id='chkAllRetailers']"), 2);
				if (retailer == null || !retailer.TryCheck())
				{
					Report.Info("Failed to check the Select all Retailes option.");
					return false;
				}
			}
			else
			{
				IWebElement retailer = this.containerElement.FindElement(By.XPath(@"//div//span[contains(text(), """ + row["Retailer"] + @""")]/preceding-sibling::input"), 2);
				if (retailer == null || !retailer.TryCheck())
				{
					Report.Info("Failed to check the retailer '" + row["Retailer"] + "'.");
					return false;
				}
			}


			Report.Info("Successfully entered all UPC information.");
			return true;
		}

		public bool ClickSave()
		{
			return this.containerElement.FindElement(By.XPath(@"//button[contains(text(), 'Save')]"), 2).TryClick();
		}
		public bool ClickCancel()
		{
			return this.containerElement.FindElement(By.XPath(@"//button[contains(text(), 'Cancel') and @class='btn btn-default pull-left']"), 2).TryClick();
		}
	}

	class AddCaseUPCModal : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='modal-content' and .//div[@class='modal-body']//div//div//div[@class='col-sm-6']//div//label[text()='Individual UPC contained in the Case Pack']]");


		public bool EnterCaseUPCInformation(TableRow row)
		{
			if (row["UPC Number"].ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(row["UPC Number"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					row["UPC Number"] = savedUPC;
				}
				catch (Exception e)
				{
					Report.Info("Failed to find saved item in context: " + row["UPC Number"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
					throw;
				}
			}

			IWebElement upcNumber = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'UPC Number')]"), 2);
			if (upcNumber == null || !upcNumber.TryEnterText(row["UPC Number"]))
			{
				Report.Info("Failed to enter the UPC Number in the Add Case UPC modal window.");
				return false;
			}

			IWebElement type = this.containerElement.FindElement(By.XPath(@"//div//label[text() = 'Type']/following-sibling::select"), 2);
			if (type == null)
			{
				Report.Info("Failed to select type from the Type drop down");
				return false;
			}
			else
			{
				type.Select(row["Type"]);
			}

			IWebElement size = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'Size (Weight Ounces)')]"), 2);
			if (size == null || !size.TryEnterText(row["Size (Weight Ounces)"]))
			{
				Report.Info("Failed to enter the Size (Weight Ounces) in the Add Case UPC modal window.");
				return false;
			}

			IWebElement quantity = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'Quantity')]"), 2);
			if (quantity == null || !quantity.TryEnterText(row["Quantity"]))
			{
				Report.Info("Failed to enter the Quantity in the Add Case UPC modal window.");
				return false;
			}

			IWebElement transportation = this.containerElement.FindElement(By.XPath(@"//div//label[text() = 'Transportation Options']/following-sibling::select"), 2);
			if (transportation == null)
			{
				Report.Info("Failed to select transportation option from the Transportation Options drop down");
				return false;
			}
			else
			{
				transportation.Select(row["Transportation Options"]);
			}

			IWebElement retailer = this.containerElement.FindElement(By.XPath(@"//div//span[contains(text(), """ + row["Retailer"] + @""")]/preceding-sibling::input"), 2);
			if (retailer == null || !retailer.TryCheck())
			{
				Report.Info("Failed to check the retailer '" + row["Retailer"] + "'.");
				return false;
			}

			Report.Info("Successfully entered all Case UPC information.");
			return true;
		}

		public bool ClickSave()
		{
			return this.containerElement.FindElement(By.XPath(@"//button[contains(text(), 'Save')]"), 2).TryClick();
		}

		public bool WaitForAddCaseUPCPopup()
		{
			return this.WaitForContainerToBeVisible(30);
		}
	}
}

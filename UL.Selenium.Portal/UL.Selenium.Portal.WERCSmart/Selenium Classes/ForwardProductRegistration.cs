
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ForwardProductRegistration : BaseObject
	{
		// Again a pretty poor/generic ID, but it's the best we have....
		public const string BasePath = "//div[@id='dataentry']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ErrorsExist()
		{
			var errors = this.containerElement.FindElements(By.XPath(".//i[contains(@class, 'exclamation')]"));
			return errors.Count > 0;
		}

		public List<string> ListOfRetailers()
		{
			var els = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'wizard-step-panel')]/div[@role='tabpanel']/div//input[@type='checkbox']/../span"), 2);
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
			var searchEl = this.containerElement.FindElement(By.XPath(".//input[@type='text' and contains(@placeholder,'Start typing Product name or WPSID')]"), 2);
			searchEl.EnterText(value);
			return searchEl.GetAttribute("value") == value && GeneralUtilities.Wait_for_load_finish();
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@data-bind='click: next']"), 2).TryClick();
		}

		public bool SelectProducts_ClickTheFirstProductCheckbox()
		{
			var productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2).ToList();
			if (productRows.Count == 0)
			{
				Report.Info("No product rows were returned!");
				return false;
			}
			foreach (var row in productRows)
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
			var products = this.containerElement.FindElements(By.XPath(".//tbody/tr/td//label[contains(@data-bind, 'wpsid')]"));
			return products.Select(x => x.GetValue()).ToList();
		}

		public bool SelectProducts_ClickProductByID(string id)
		{
			var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2).TryClick();
		}
		public bool SelectProducts_ClickProductByID_(string id)
		{
			var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			var inputEl = productRow.FindElement(By.XPath(".//input[@type='checkbox']"));
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
			foreach (var row in productRows)
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
			var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[.//label[text()='" + id + "']]"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2).Checked();
		}
		public bool SelectProducts_ProductCheckboxDisabled(bool disabledCheck)
		{
			var inputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox']"));
			if (!inputs.Any())
			{
				return false;
			}
			var disabledInputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox' and @disabled]"));
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
			var inputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox']"));
			if (!inputs.Any())
			{
				return false;
			}
			var disabledInputs = this.containerElement.FindElements(By.XPath(".//tbody/tr//input[@type='checkbox' and @disabled]"));
			return disabledInputs.Any();
		}

		public List<string> GetListOfOtherRetailers()
		{
			var retailers = this.containerElement.FindElements(By.XPath(".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//span"));
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
			var retailerInput = this.containerElement.FindElement(By.XPath(".//h4[text()='Other Retailers']/following-sibling::div[contains(@class, 'retailers-list')]/div//span[contains(text(),'" + retailer + "')]/../input"), 2);

			if (retailerInput == null)
			{
				Report.Info("Retailer input could not be found");
				return false;
			}
			return retailerInput.TryCheck();
		}

		public bool SelectRetailer(string retailer)
		{
			var retailers = this.containerElement.FindElements(By.XPath(@".//div[@class='col-sm-3 retailer-select' and .//span[contains(text(),""" + retailer + @""")]]"), 2).ToList();
			if (retailers.Count == 0)
			{
				Report.Info("No retailer tiles were found!");
				return false;
			}
			return retailers.First().FindElement(By.XPath(".//label")).TryClick() && retailers.First().FindElement(By.XPath(".//input")).Checked();
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
			var products = this.GetProducts();
			if (products.Count == 0)
			{
				Report.Failure("No Product rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			Report.Info("Selecting vendor: " + option + " for the first product in the grid");
			products.First().SelectVendor = option;
			Delay.Seconds(1);
			var vendor = products.First().SelectVendor;
			return vendor == option;
		}

		public bool SelectFirstUPC()
		{
			var upcs = this.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return false;
			}
			Report.Info("Selecting UPC: " + upcs.First().UPCInfo.UPCNumber);
			return upcs.First().SelectUPC();
		}

		public bool SelectUPCByNumber(string UPCNumber)
		{
			SelectUPCs thisSelectUPCs = new SelectUPCs {
				UPCInfo = new UPC() { UPCNumber = UPCNumber }
			};
			return thisSelectUPCs.SelectUPC();
		}

		public bool ClickActionByUPCNumber(string UPCNumber, string Action)
		{
			UPC thisUPC = new UPC() { UPCNumber = UPCNumber };
			return thisUPC.ClickAction(Action);
		}

		public bool SelectFirstProduct_SelectUPCs()
		{
			var products = this.GetProducts();
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
			var upcRows = this.containerElement.FindElements(By.XPath(".//div[./h3[text()='Select UPCs']]//tbody/tr"), 2);
			foreach (var row in upcRows)
			{
				rUPCs.Add(new SelectUPCs {
					UPCInfo = new UPC {
						DestinationRetailers = row.FindElement(By.XPath(".//span[@data-bind='text: identifier']"), 2)?.Text,
						UPCNumber = row.FindElement(By.XPath(".//span[contains(@data-bind,'upcNumber.field')]"), 2)?.Text
					},
					ContainerType = row.FindElement(By.XPath(".//span[contains(@data-bind,'typeToString')]"), 2)?.Text,
					Size = row.FindElement(By.XPath(".//span[contains(@data-bind,'size.field')]"), 2)?.Text
				});
			}
			return rUPCs;
		}

		public List<SelectProducts> GetProducts()
		{
			var rProducts = new List<SelectProducts>();
			var productRows = this.containerElement.FindElements(By.XPath(".//table[.//th[contains(text(),'Product Name')]]/tbody/tr"), 2);
			foreach (var row in productRows)
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
			var productTables = this.containerElement.FindElements(By.XPath(".//div[@class='panel-body']//table"), 2);
			foreach (var product in productTables)
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

		public class SelectProducts : ForwardProductRegistration
		{
			public string ID { get; set; }
			public string Name { get; set; }
			public string InternalID { get; set; }
			public string SelectVendor {
				get
				{
					var row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
					var select = row.FindElement(By.XPath(".//select[contains(@data-bind,'vendors')]"), 2);
					if (select == null)
					{
						Report.Info("The Select Vendor element could not be found!");
						return null;
					}
					return select.SelectedOption();
				}
				set
				{
					var row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
					var select = row.FindElement(By.XPath(".//select[contains(@data-bind,'vendors')]"), 2);
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
				var row = this.containerElement.FindElement(By.XPath(".//tr[@id='" + this.InternalID + "']"), 2);
				return row.TryClick() && row.GetAttribute("class") == "active";
			}


		}

		public class SelectUPCs : ForwardProductRegistration
		{
			public UPC UPCInfo { get; set; }
			public string ContainerType { get; set; }
			public string Size { get; set; }
			public bool SelectUPC()
			{
				return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCInfo.UPCNumber + "']]/td/input")).TryClick();
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
			public bool ClickAction(string action)
			{
				if (action.ToLower() == "edit")
				{
					return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCNumber + "']]/td/a[contains(@data-bind,'edit')]")).TryClick();
				}
				if (action.ToLower() == "remove")
				{
					return this.containerElement.FindElement(By.XPath(".//tr[.//span[contains(@data-bind,'upcNumber') and text()='" + this.UPCNumber + "']]/td/a[contains(@data-bind,'remove') or contains(@data-bind,'delete')]")).TryClick();
				}
				return false;
			}
		}

		public class EditUPC : BaseObject
		{
			public const string BasePath =
				"//div[contains(@class, 'modal-dialog')]//h4[contains(text(), 'Edit UPC')]/../..";

			[FindsBy(How = How.XPath, Using = BasePath)]
			protected override IWebElement containerElement { get; set; }

			public string UPCNumber {
				get
				{
					var input = this.containerElement.FindElement(
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
					var input = this.containerElement.FindElement(
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
					var input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='Size (Ounces)']"), 2);
					if (input == null)
					{
						Report.Info("The Size input could not be found!");
						return null;
					}

					return input.GetValue();
				}
				set
				{
					var input = this.containerElement.FindElement(
						By.XPath(".//input[@type='text' and @placeholder='Size (Ounces)']"), 2);
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
					var input = this.containerElement.FindElement(By.XPath(".//select"), 2);
					if (input == null)
					{
						Report.Info("The Type select box could not be found!");
						return null;
					}

					return input.SelectedOption();
				}
				set
				{
					var input = this.containerElement.FindElement(By.XPath(".//select"), 2);
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

			public List<string> Retailer {
				get
				{
					var inputs = this.containerElement.FindElements(By.XPath(
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
					var inputs = this.containerElement.FindElements(By.XPath(
						".//input[@type='checkbox' and @id='chkAllRetailers']/..|.//input[@type='checkbox']/../span"));
					if (inputs.Count == 0)
					{
						Report.Info("No retailer checkboxes could not be found!");
					}

					foreach (string thisRetailer in value)
					{
						var matchingRetailerInput = inputs.FirstOrDefault(x => x.GetValue() == thisRetailer);
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
				var buttons = this.containerElement.FindElements(By.XPath(".//button"), 2);
				if (buttons.Count == 0)
				{
					Report.Info("No buttons were found");
					return false;
				}

				var matchingButton = buttons.FirstOrDefault(x => x.GetValue().ToLower() == button.ToLower());

				if (matchingButton == null)
				{
					Report.Info("Buttons were found but not one that matched: " + button);
					return false;
				}

				return matchingButton.TryClick();

			}
		}

	}
}

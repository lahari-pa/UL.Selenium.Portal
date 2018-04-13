using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class NewProduct : BaseObject
	{
		// Again a pretty poor/generic ID AND CLASHES WITH FORWARD PRODUCT REGISTRATION!!!
		// but it's the best we have....
		public const string BasePath = "//div[@id='dataentry']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string GetHeader()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='product-header']/h2"), 2).Text;
		}

		public string GetProductId()
		{
			var el = containerElement.FindElement(By.XPath(".//div[@class='product-header']/h2"), 2).Text;
			var matches = Regex.Matches(el, @"\(([^)]*)\)");
			return matches[matches.Count - 1].Groups[1].Value;
		}

		public string GetProductName()
		{
			return GetHeader().Replace("(" + GetProductId() + ")", "").Trim();
		}

		public ProductInformation GetCurrentProductInformation()
		{
			return new ProductInformation(){Id=GetProductId(), Name=GetProductName()};
		}

		public string GetInitialStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//form//label[@class='control-label']"), 2).Text;
		}

		public List<string> RadioButtons()
		{
			return this.containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public string ErrorMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//p[@class='form-error']//span"), 2).Text;
		}

		public string GetCurrentProduct()
		{
			return this.containerElement.FindElement(By.XPath(".//h2[@class='product-name']"), 2).Text.Trim();
		}

		//New, Copy or UPC
		public void SelectTypeOfProductToCreate(string type = "New")
		{
			var option = containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2)
				.FirstOrDefault(x => x.Text.Contains(type));
			if (option == null)
			{
				return;
			}

			option.Click();
		}

		public void CreateNewProductOrCopy(bool newProduct = true)
		{
			var option = this.containerElement.FindElements(By.XPath(".//form//label[@class='radio']"), 2).FirstOrDefault(x => x.Text.StartsWith((newProduct ? "Yes" : "No")));
			if (option == null)
			{
				return;
			}

			option.Click();
		}

		public bool WaitForSection(string sectionHeader, int secondsToWait = 60)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				var addProductHeader = containerElement.FindElements(By.XPath(".//div[@class='panel-heading']//h3"))
					.FirstOrDefault(x => x.Text.Contains(sectionHeader));
				if (addProductHeader != null)
				{
					return true;
				}
				Delay.Seconds(Delay.SpeedFactor * 1);
				counter++;
			}

			return false;
		}

		//Valid tab names: Product Type, Product Characteristics, Recipient and UPC Details, Review and Submit
			public bool WaitForTab(string tabName, int secondsToWait = 30)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				var progWizard = containerElement.FindElement(By.XPath(".//div[@class='prog-wizard']"));
				if (progWizard != null)
				{
					var tab = containerElement.FindElements(By.XPath(".//div[contains(@class, 'progress')]//span[contains(@data-bind, 'description')]"), 2)
						.FirstOrDefault(x => x.Text.Contains(tabName));
					if (tab != null)
					{
						var containerDiv = tab.FindElement(By.XPath("./../../div"));
						string backGroundColour = containerDiv.GetCssValue("background-color");
						if (backGroundColour.Contains("255, 255, 255"))
						{
							return true;
						}
					}
				}
				Delay.Seconds(Delay.SpeedFactor * 1);
				counter++;
			}
			return false;
		}

		public bool ClickContinue()
		{
			try
			{
				var el = this.containerElement.FindElement(By.XPath(".//a[contains(@class,'continue-button')]"), 2);
				if (el == null)
				{
					return false;
				}

				el.Click();
				GeneralUtilities.Wait_for_load_finish();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string ProductName {
			get { return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Name') or contains(text(),'Product name')]/../following-sibling::div/input"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Name') or contains(text(),'Product name')]/../following-sibling::div/input"), 2).EnterText(value); }
		}

		public string TscaStatus {
			get
			{
				List<string> countries = new List<string>();
				var listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TSCA"))
					.FindElements(By.XPath("../..//input"));
				foreach (var item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label")).Text;
					}
				}

				return "";

			}
			set
			{
				var thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("TSCA")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				var optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}

		}

		public List<string>ProductsMayBeSold {
			get
			{
				List<string> countries = new List<string>();
				var listOfCountries = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Select countries the product may be sold in"))
					.FindElements(By.XPath("../..//input"));
				foreach (var country in listOfCountries)
				{
					if (country.Selected)
					{
						countries.Add(country.FindElement(By.XPath("../..//label")).Text);
					}
				}
				return countries;

			}
			set
			{
				foreach (var country in value)
				{
					var thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("Select countries the product may be sold in")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == country);
					var countryInput = thisLabel.FindElement(By.XPath(".//../input"));
					if (!countryInput.Selected)
					{
						countryInput.Click();
					}
				}
				
			}
		}

		public string IndicateHowBatteryIsPackaged {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Indicate how battery is packaged"));

				if (lbl != null)
				{
					var listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (var item in listOfItems)
					{
						if (item.Selected)
						{
							var selectedText = item.FindElement(By.XPath("../..//label/span")).Text;
							SafewareReporting.Report.Info(selectedText + " is selected.");
							return selectedText;
						}
					}
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}
				
				return "";

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Indicate how battery is packaged"));

				if (lbl != null)
				{ 
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label indicate how battery is packaged could not be found");
				}
			}
		}

		public string Dot {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("DOT"));

				if (lbl != null)
				{
					var listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (var item in listOfItems)
					{
						if (item.Selected)
						{
							var selectedText = item.FindElement(By.XPath("../..//label/span")).Text;
							SafewareReporting.Report.Info(selectedText + " is selected.");
							return selectedText;
						}
					}
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

				return "";

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("DOT"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label DOT could not be found");
				}
			}
		}

		public string Imdg {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("IMDG"));

				if (lbl != null)
				{
					var listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (var item in listOfItems)
					{
						if (item.Selected)
						{
							var selectedText = item.FindElement(By.XPath("../..//label/span")).Text;
							SafewareReporting.Report.Info(selectedText + " is selected.");
							return selectedText;
						}
					}
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

				return "";

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("IMDG"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label IMDG could not be found");
				}
			}
		}

		public string Iata {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("IATA"));

				if (lbl != null)
				{
					var listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (var item in listOfItems)
					{
						if (item.Selected)
						{
							var selectedText = item.FindElement(By.XPath("../..//label/span")).Text;
							SafewareReporting.Report.Info(selectedText + " is selected.");
							return selectedText;
						}
					}
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

				return "";

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("IATA"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label IATA could not be found");
				}
			}
		}

		public string Tdg {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TDG"));

				if (lbl != null)
				{
					var listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (var item in listOfItems)
					{
						if (item.Selected)
						{
							var selectedText = item.FindElement(By.XPath("../..//label/span")).Text;
							SafewareReporting.Report.Info(selectedText + " is selected.");
							return selectedText;
						}
					}
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

				return "";

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TDG"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label TDG could not be found");
				}
			}
		}
		public List<KeyValuePair<int, string>> TableHeaders(IWebElement table)
		{
			List<KeyValuePair<int, string>> th = new EditableList<KeyValuePair<int, string>>();
			var listOfHeaders = table.FindElements(By.XPath(".//th"));
			for (int i = 0; i < listOfHeaders.Count; i++)
			{
				th.Add(new KeyValuePair<int, string>(i + 1, listOfHeaders[i].Text));
			}

			return th;
		}

		public void DeleteEmptyBatteryRows()
		{
			IWebElement thisTable = containerElement.FindElement(By.XPath(".//table"));
			List<KeyValuePair<int, string>> th = TableHeaders(thisTable);

			var listOfRows = containerElement.FindElements(By.XPath(".//tbody//tr"));
			int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
			int removeIndex = th.FirstOrDefault(x => x.Value == "Remove").Key;

			bool emptyBatteryRowsExist = true;
			IWebElement removeButton = null;

			while (emptyBatteryRowsExist)
			{
				var listOfManufacturerTypes = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tbody//tr//td[" + batteryTypeIndex.ToString() + "]//select"));
				if (listOfManufacturerTypes != null)
				{
					var unselectedManufacturerTypes = listOfManufacturerTypes.Where(x => x.SelectedOption() == "Choose...");
					if (unselectedManufacturerTypes.Count() > 0)
					{
						removeButton = unselectedManufacturerTypes.FirstOrDefault().FindElement(By.XPath("../..//td[" + removeIndex.ToString() + "]//a"));
						removeButton.Click();
						Delay.Seconds(3);
					}
					else
					{
						emptyBatteryRowsExist = false;
					}
				}
				else
				{
					SafewareReporting.Report.Info("Failed to find any row.");
					emptyBatteryRowsExist = false;
				}
			}
			
		}

		public List<Battery> Batteries {
			get
			{
				List<Battery> listOfBatteries = new List<Battery>();
				IWebElement thisTable = containerElement.FindElement(By.XPath(".//table"));
				List <KeyValuePair<int, string>> th = TableHeaders(thisTable);

				var listOfRows = containerElement.FindElements(By.XPath(".//tbody//tr"));

				int batteryTypeIndex = th.FirstOrDefault(x => x.Value =="Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("required")).Key;
				int removeIndex = th.FirstOrDefault(x => x.Value == "Remove").Key;

				string batteryType = "";
				string manufacturer = "";
				int numberPerPackage = -1;
				int requiredToRun = -1;

				foreach (var thisRow in listOfRows)
				{
					batteryType = "";
					manufacturer = "";
					numberPerPackage = -1;
					requiredToRun = -1;

					batteryType = thisRow.FindElement(By.XPath(".//td[" + batteryTypeIndex.ToString() + "]//selected")).SelectedOption();
					manufacturer = thisRow.FindElement(By.XPath(".//td[" + manufacturerIndex.ToString() + "]")).Text;
					numberPerPackage = Convert.ToInt16(thisRow.FindElement(By.XPath(".//td[" + perPackageIndex.ToString() + "]")).Text);
					requiredToRun = Convert.ToInt16(thisRow.FindElement(By.XPath(".//td[" + batteriesRequiredIndex.ToString() + "]")).Text);

					listOfBatteries.Add(new Battery(){BatteryType = batteryType, Manufacturer = manufacturer,NumberPerPackage = numberPerPackage,RequiredToRun = requiredToRun});
				}

				//table/tbody//tr
				return listOfBatteries;
			}
			set
			{
				IWebElement thisTable = containerElement.FindElement(By.XPath(".//table"));
				List<KeyValuePair<int, string>> th = TableHeaders(thisTable);

				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("required")).Key;
				int removeIndex = th.FirstOrDefault(x => x.Value == "Remove").Key;

				foreach (var thisBattery in value)
				{
					var addRowButton = containerElement.FindElements(By.XPath(".//button"))
						.FirstOrDefault(x => x.Text.Contains("Add Row"));
					if (addRowButton != null)
					{
						addRowButton.Click();
					}
					else
					{
						throw new Exception("The add row button could not be found.");
					}
					Delay.Seconds(5);
					var listOfRows = containerElement.FindElements(By.XPath(".//tbody//tr"));
					var batteryType = listOfRows.FirstOrDefault().FindElement(By.XPath(".//td[" + batteryTypeIndex.ToString() + "]//select"));
					batteryType.Select(thisBattery.BatteryType);
					var manufacturer = listOfRows.FirstOrDefault().FindElement(By.XPath(".//td[" + manufacturerIndex.ToString() + "]"));
					manufacturer.Click();

					IWebElement enterTextInstructions = null;
					for (int i = 0; i < 30; i++)
					{
						try
						{
							enterTextInstructions = manufacturer.FindElement(By.XPath(".//span[contains(@class, 'select2')]"));
							if (enterTextInstructions != null)
							{
								break;
							}
						}
						catch (Exception e)
						{
							SafewareReporting.Report.Info(e.Message);
						}
						
						Delay.Seconds(1);
						i++;
					}

					if (enterTextInstructions == null)
					{
						throw new Exception("Enter manufacturer text instructions did not appear.");
					}

					var enterManufacturer = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//span[contains(@class, 'select2')]//input"));
					enterManufacturer.EnterText(thisBattery.Manufacturer);
					Delay.Seconds(5);

					var selectDropDown = enterManufacturer.FindElement(By.XPath("../following-sibling::span"));

					if (selectDropDown != null)
					{
						selectDropDown.FindElements(By.XPath(".//ul/li")).FirstOrDefault().Click();
						Delay.Seconds(3);
					}
					else
					{
						throw new Exception("Manufacturer drop down could not be found");
					}
					var perPackage = listOfRows.FirstOrDefault().FindElement(By.XPath(".//td[" + perPackageIndex.ToString() + "]//input"));
					perPackage.EnterText(thisBattery.NumberPerPackage.ToString());
					var batteriesRequired = listOfRows.FirstOrDefault().FindElement(By.XPath(".//td[" + batteriesRequiredIndex.ToString() + "]//input"));
					batteriesRequired.EnterText(thisBattery.RequiredToRun.ToString());
				}

			}
		}


		public bool ProductShippedDirectly {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is shipped directly"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x=>!x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No product shipped directly option is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is shipped directly"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool HasLcdOrPlasmaDisplay {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Plasma Display"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Has LD or Plasma Display option is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Plasma Display"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool ContainsCircuitBoard {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Contains Circuit Board"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Contains Circuit Board option is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Contains Circuit Board"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}
		

		public bool Prop65 {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Prop 65"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Prop65 option is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Prop 65"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool ProductHasTclp {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TCLP"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TCLP"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool RetailersPrivateLabelOrBrand {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Private Label or Brand"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Private Label or Brand"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool WaitForMetalSection(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var header = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div")).FirstOrDefault(x => x.Text.Contains("following metals"));
				if (header != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public List<MetalPresence> MetalPresence {
			get
			{
				List<MetalPresence> listOfMetals = new List<MetalPresence>();
				var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

				var listOfMetalRows = header.FindElements(By.XPath("../../following-sibling::div"));
				string metalName = "";
				string presence = "";
				foreach (var metalRow in listOfMetalRows)
				{
					try
					{
						metalName = "";
						presence = "";
						metalRow.ScrollElementIntoView();
						Delay.Seconds(1);
						metalName = metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label")).Text;
						var presenceA = metalRow.FindElements(By.XPath(".//div[@class='radio']//input"));

						var presenceB = presenceA.Where(x => x.Selected == true).ToList().FirstOrDefault();

						if (presenceB != null)
						{
							presence = presenceB.FindElement(By.XPath("../span")).Text;
							SafewareReporting.Report.Info("Adding metal: " + metalName + ": " + presence);
							listOfMetals.Add(new MetalPresence(metalName, presence));
						}
						else
						{
							listOfMetals.Add(new MetalPresence(metalName, "none"));
						}
							
					}
					catch (Exception e)
					{
						SafewareReporting.Report.Info(e.Message);
					}
					
				}

				return listOfMetals;
			}
			set
			{
				SafewareReporting.Report.Info(value.Count.ToString() + " metals to set.");
				var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

				foreach (MetalPresence thisMetal in value)
				{
					var metalLabel = header.FindElements(By.XPath("../../following::div//label[@class='control-label']")).FirstOrDefault(x=>x.GetValue().Trim()==thisMetal.Metal);
					var inputLabel = metalLabel.FindElements(By.XPath("../..//input/../span")).FirstOrDefault(x => x.Text == thisMetal.Presence);

					if (inputLabel != null)
					{
						try
						{
							var metalInput = inputLabel.FindElement(By.XPath("../input"));
							SafewareReporting.Report.Info("Attempting to set metal: " + thisMetal.Metal + " and value: " + thisMetal.Presence);
							metalInput.TryClick();
						}
						catch (Exception e)
						{
							SafewareReporting.Report.Error("Failed to click metal: " + thisMetal.Metal + " and value: " + thisMetal.Presence);
							throw;
						}
					}
					else
					{
						throw new Exception("Cannot find input for: " + thisMetal.Metal);
					}
				}

			}
		}

		public List<string> GetAllMetalNames()
		{
			List<string> listOfMetals = new List<string>();
			var circuitDiv =SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

			var listOfMetalRows = circuitDiv.FindElements(By.XPath("../../following-sibling::div"));
			string metalName = "";
			foreach (var metalRow in listOfMetalRows)
			{
				metalName = "";
				try
				{
					metalName = metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label")).Text;
					listOfMetals.Add(metalName);
				}
				catch (Exception e)
				{
				//	SafewareReporting.Report.Error(e.Message);
				}
				
			}
			return listOfMetals;
		}

		public bool SolelyForRetailersUse {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("solely for the Retailer's use"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + selectedOption);
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("solely for the Retailer's use"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public string ProductLineOrBrand 
	    {
		    set
			{
				var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
				el.SelectByValue(value);
		    }

	    }

        public string ProductType
        {
            set
            {
                var el = this.containerElement.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"), 2);
                el.Click();
                var inputField = this.containerElement.FindElement(By.XPath("//span[contains(@class,'select2-container')]//input"), 2);
                inputField.EnterText(value);
                GeneralUtilities.Wait_for_load_finish();

				var dropDownResults = this.containerElement.FindElements(By.XPath("//span[contains(@class,'select2-container')]//ul/li"), 2);
				var ddlEl = dropDownResults.FirstOrDefault(x => x.Text.Trim() == value);
				if (ddlEl == null)
				{
					return;
				}

				ddlEl.Click();
			}
		}

		public bool ClickAddUpcButton()
		{
			var el = containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public bool InputUpcInformation(UpcInformation info)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);

				var upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);
				upcNumberField.EnterText(info.UpcNumber);

				var containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
				containsType.Select(info.ContainerType);

				var sizeField = container.FindElement(By.XPath(".//input[@placeholder='Size']"), 2);
				sizeField.EnterText(info.Size);

				var dpciField = container.FindElement(By.XPath(".//input[contains(@data-bind,'value.field')]"), 2);
				dpciField.EnterText(info.Dpci);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool CommentsAreaShowing()
		{
			var el = containerElement.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"), 2);
			return el != null;
		}

		public bool InputCommentAreaText(string text)
		{
			try
			{
				if (!CommentsAreaShowing())
				{
					return false;
				}

				var el = containerElement.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"), 2);
				el.EnterText(text);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool DataAcceptanceScreenAppears()
		{
			var el = containerElement.FindElement(By.XPath(".//h3[text()='Data Acceptance']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Displayed;
		}

		public bool ClickSummaruButtonInDataAcceptance()
		{
			var el = containerElement.FindElement(By.XPath(".//a[text()='Summary']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}
	}

	public class ProductInformation
	{
		public string Name { get; set; }
		public string Id { get; set; }
	}

	public class Battery
	{
		public string BatteryType { get; set; }
		public string Manufacturer { get; set; }

		public int NumberPerPackage { get; set; }
		public int RequiredToRun { get; set; }	
	}

	public class MetalPresence
	{
		public string Metal { get; set; }
		public string Presence { get; set; }

		public MetalPresence(string metalName, string metalPresence)
		{
			Metal = metalName;
			Presence = metalPresence;
		}


	}

	public class UpcInformation
	{
		public string UpcNumber { get; set; }
		public string ContainerType { get; set; }
		public string Size { get; set; }
		public string Dpci { get; set; }
	}
}

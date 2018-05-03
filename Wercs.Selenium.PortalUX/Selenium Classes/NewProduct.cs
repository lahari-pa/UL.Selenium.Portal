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
using SafewareReporting;
using SafewareReporting.XML;
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

		public bool ClickTab(string tabName)
		{
			var tab = containerElement.FindElements(By.XPath(".//div[@class='prog-wizard']//div[contains(@class, 'prog-step')]//a/span"), 2)
				.FirstOrDefault(x => x.Text.Contains(tabName));

			if (tab != null)
			{
				return tab.FindElement(By.XPath("../../a")).TryClick();
			}

			return false;
		}

		public bool ClickSection(string section)
		{
			var sec = containerElement.FindElements(By.XPath(".//h3"), 2).FirstOrDefault(x=>x.Text.Contains(section));

			if (sec != null)
			{
				return sec.TryClick();
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

				el.TryClick();
				GeneralUtilities.WaitForRefreshToDisappear(el);
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

		public bool ProductClassifiedUnderOSHA
		{
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product has been classified using OSHA"))
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
					throw new Exception("No product has been classified using OSHA option is selected");
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
					.FirstOrDefault(x => x.Text.Contains("Product has been classified using OSHA"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();
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

		public string OSHA {
			get
			{
				return this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("OSHA")).FindElements(By.XPath("../following-sibling::div//label/input"))
					.FirstOrDefault(x => x.Selected).FindElement(By.XPath("./following-sibling::span")).Text;
				}
			set
			{
				var selectItem = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("OSHA")).FindElements(By.XPath("../following-sibling::div//label/span"))
					.FirstOrDefault(y => y.Text.Contains(value));

				if (selectItem != null)
				{
					selectItem.FindElement(By.XPath("../input")).TryClick();
				}
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

		public bool DeleteUPC(string upc)
		{
			if (upc.ToLower().Contains("saved as"))
			{
				upc = Context.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim()).ToString();
			}
			SafewareReporting.Report.Info("Attempting to delete: " + upc);
			var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var upcmatch = container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2)
				.FirstOrDefault(x => x.Text.Contains(upc));

			if (upcmatch != null)
			{
				if (!upcmatch.FindElement(By.XPath("../..//a[contains(@data-bind, 'Delete')]")).TryClick())
				{
					SafewareReporting.Report.Info("Failed to find delete button");
					return false;
				}

			}
			else
			{
				SafewareReporting.Report.Info("Failed to find matching row.");
				return false;
			}
			SafewareReporting.Report.Info("Successfully clicked delete button.");
			SafewareReporting.Report.Screenshot();
			Delay.Seconds(3);
			ModalDialog md = new ModalDialog();
			if (md.Wait_for_load(30))
			{
				SafewareReporting.Report.Screenshot();
				md.Click_OK();
				SafewareReporting.Report.Info("Clicked OK");
				SafewareReporting.Report.Screenshot();
				Delay.Seconds(2);
				return true;
			}
			return false;
		}

		public List<string> GetAllUPCs()
		{
			var container = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			return container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).Select(x => x.Text).ToList();
		}

		public bool InputUpcInformation(UpcInformation info)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);

				var upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

				if (info.UpcNumber.ToLower().Contains("saved as"))
				{
					var savedUPC = Context
						.GetFromContext(info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					info.UpcNumber = savedUPC;
				}
				upcNumberField.EnterText(info.UpcNumber);

				var containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
				containsType.Select(info.ContainerType);

				var sizeField = container.FindElement(By.XPath(".//input[@placeholder='Size']"), 2);
				sizeField.EnterText(info.Size);

				if (info.Dpci.Length> 0)
				{
					var dpciField = container.FindElement(By.XPath(".//input[contains(@data-bind,'value.field')]"), 2);
					dpciField.EnterText(info.Dpci);
				}


				if (info.Quantity.Length > 0)
				{
					var quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity']"), 2);
					quantityField.EnterText(info.Quantity);
				}
				
				return true;
			}
			catch (Exception ex)
			{
				SafewareReporting.Report.Info(ex.Message);
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

		public bool SelectYesAgreedRadio()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Yes, Agreed')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
			
		}

		public bool ClickAcceptButton()
		{
			var el = containerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

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

		// ========= Product Charactertistics Options ========= //

		public bool ProductIsRegulatedForTransport(string item)
		{
			//get
			//{
			//	var el = containerElement
			//		.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//input"), 2)
			//		.FirstOrDefault(x => x.Selected).FindElement(By.XPath("../span"));
			//	if (el != null)
			//	{
			//		return el.Text;
			//	}

			//	return "";
			//}
			//set
			//{
			//	var el = containerElement
			//		.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//span"), 2)
			//		.FirstOrDefault(x => x.Text.Contains(value)).FindElement(By.XPath("../input"));
			//	if (el != null)
			//	{
			//		el.TryClick();
			//	}
			//}

			try
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}


		/// <summary>
		/// Select all modes of transport that you've classified the product for checkbox options
		/// </summary>
		public bool AllModesOfTransport(string item)
		{
			try
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Select all modes of transport')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// Please select DOT Exceptions if applicable -- different method 
		/// </summary>
		public bool DotExcemptionIfApplicable(string item)
		{
			try
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[text()='Please select DOT Exceptions if applicable?']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// International Shipping when DOT Exemption taken radio option
		/// </summary>
		public string InternationalShippingDOTExemption {
			get
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[text()='International Shipping when DOT Exemption taken?']/../following-sibling::div//input"), 2)
					.FirstOrDefault(x => x.Selected).FindElement(By.XPath("../span"));
				if (el != null)
				{
					return el.Text;
				}

				return "";
			}
			set
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[text()='International Shipping when DOT Exemption taken?']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text.Contains(value)).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
				}
			}
		}


		public List<string> DOTExceptions {
			get
			{
				var selectedInputs = containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable')]/../following-sibling::div//input"), 2)
					.Where(x => x.Selected);
				List<string> selectedLabels = new List<string>();
				foreach (var input in selectedInputs)
				{
					selectedLabels.Add(input.FindElement(By.XPath("../span")).Text);
				}

				return selectedLabels;
			}
			set
			{
				foreach (string item in value)
				{
					var el = containerElement
						.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable')]/../following-sibling::div//span"), 2)
						.FirstOrDefault(x => x.Text.Contains(item)).FindElement(By.XPath("../input"));
					if (el != null)
					{
						el.TryClick();
					}
				}
				
			}
		}

		public string OtherDOTException {
			get
			{
				var el = containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Other DOT Exception')]/../following-sibling::div//input"), 2);
				return el.GetValue();
			}
			set
			{
				var el = containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Other DOT Exception')]/../following-sibling::div//input"), 2);
				el.EnterText(value);
			}
		}

		public string SpecialPermitNumbers {
			get
			{
				var el = containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Special Permit')]/../following-sibling::div//input"), 2);
				return el.GetValue();
			}
			set
			{
				var el = containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Special Permit')]/../following-sibling::div//input"), 2);
				el.EnterText(value);
			}
		}


		public List<string> ListOfPrimaryPhysicalStates()
		{
			return containerElement.FindElements(By.XPath(".//label[text()='Primary Physical State']/..//following-sibling::div//label//span"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool SelectPrimaryPhysicalState(string item)
		{
			try
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[text()='Primary Physical State']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectSecondaryPhysicalState(string item)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Secondary Physical State']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string WaterSolubility
		{
			get
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
				return el.SelectedOption();
			}
			set
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
				el.Select(value);
			}
		}

		/// <summary>
		/// When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then radio options
		/// </summary>
		public bool ProductHasFlammablePropellant(string item)
		{
			try
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[contains(text(),'flammable propellant')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Select the best Water Solubility description dropdown
		/// </summary>
		public bool SelectBestWaterSolubilityDescription(string item)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Refer to your Product Label. From the options, select those that appear on the Label checkbox options
		/// </summary>
		public List<string> ProductLabel {
			get
			{
				var selectedInputs = containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Refer to your Product Label')]/../following-sibling::div//input"), 2)
					.Where(x => x.Selected);
				List<string> selectedLabels = new List<string>();
				foreach (var input in selectedInputs)
				{
					selectedLabels.Add(input.FindElement(By.XPath("../span")).Text);
				}

				return selectedLabels;
			}
			set
			{
				foreach (string item in value)
				{
					var el = containerElement
						.FindElements(By.XPath(".//label[contains(text(),'Refer to your Product Label')]/../following-sibling::div//span"), 2)
						.FirstOrDefault(x => x.Text.Contains(item)).FindElement(By.XPath("../input"));
					if (el != null)
					{
						el.TryClick();
					}
				}

			}
		}


		public bool SetWaterSolutionQuestion
		{
			set
			{
				var btns = containerElement.FindElements(By.XPath(".//label[contains(text(),'When mixed with an equal')]/..//following-sibling::div//input/following-sibling::span"), 2);
				var button = btns.FirstOrDefault(x => x.GetValue().Trim() == (value ? "Yes" : "No"));
				if (button == null)
				{
					return;
				}

				//var el = button.FindElement(By.XPath("./preceding-sibling::input"), 2);
				button.TryClick();
			}
		}

		// ========= Add Ingredient Functions ========= //

		public bool AddIngredient(Ingredient ingredient)
		{
			var placeholderEl = containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
			placeholderEl.TryClick();
			IWebElement MatchedEntry = null;
			var inputEl = containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			if (ingredient.CASNumber != "" && ingredient.CASNumber != null)
			{
				inputEl.EnterText(ingredient.CASNumber);
				var searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				}

				// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
				// If no elements match this, then we will simply take the first element in the list

				var Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				if (Matches.Count == 0)
				{
					return false;
				}

				var MatchingCasValues = Matches.Where(x=>x.FindElement(By.XPath(".//span[2]"), 2).GetValue().Trim()==ingredient.CASNumber.Trim());
				
				if (MatchingCasValues.Count()==0)
				{
					MatchedEntry = Matches.FirstOrDefault();
					ingredient.CASNumber = MatchedEntry.FindElement(By.XPath(".//span[2]"), 2).GetValue();
					ingredient.ComponentName = MatchedEntry.FindElement(By.XPath(".//span[1]"), 2).GetValue();
				}
				else
				{
					// In this case we have entries with matching CAS Numbers, so we should double check that our product name matches?
					if (ingredient.ComponentName == "" || ingredient.ComponentName==null)
					{
						// No Component name was specified, so we just take the first value with a matching CAS Number!
						MatchedEntry = MatchingCasValues.FirstOrDefault();
					}
					else
					{
						// Component name was defined, so just check to see if there is a match
						var matchingNames = MatchingCasValues.FirstOrDefault(x => x.FindElement(By.XPath(".//span[1]"), 2).GetValue().Trim() == ingredient.ComponentName.Trim());
						if (matchingNames == null)
						{
							// No match was found, so just take the first entry!
							MatchedEntry = MatchingCasValues.FirstOrDefault();
						}
						else
						{
							// Matching entry was found, so taking this instead!
							MatchedEntry = matchingNames;
						}
					}
				}
			}
			else
			{
				// So in this case we want to try and find the entry by the name
				inputEl.EnterText(ingredient.ComponentName);

				var searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				}

				// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
				// If no elements match this, then we will simply take the first element in the list

				var Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);

				while (Matches.FirstOrDefault().FindElement(By.XPath(".//span[@class='component-name']"), 2) == null)
				{
					Delay.Seconds(Delay.SpeedFactor*1);
					Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				}

				var MatchingNameValue = Matches.FirstOrDefault(x => x.FindElement(By.XPath(".//span[@class='component-name']"), 2).GetValue().Trim() == ingredient.ComponentName.Trim());

				if (MatchingNameValue == null)
				{
					// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
					MatchedEntry = Matches.FirstOrDefault();
					ingredient.CASNumber = MatchedEntry.FindElement(By.XPath(".//span[2]"), 2).GetValue();
					ingredient.ComponentName = MatchedEntry.FindElement(By.XPath(".//span[1]"), 2).GetValue();
				}
				else
				{
					MatchedEntry = MatchingNameValue;
					// We have found a match by the component name! So we should update our CAS Number field
					ingredient.CASNumber = MatchingNameValue.FindElement(By.XPath(".//span[2]"), 2).GetValue();
				}
			}



			// So now we simple need to try and click this element! Easy right...

			if (MatchedEntry.TryClick())
			{
				// So we have now selected the element, so we need to try and get the first 'new' entry which contains this CAS Number, and hasn't had the Percentage field filled
				var rows = containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2);
				var matchingrow = rows.FirstOrDefault(x => x.FindElement(By.XPath(".//div[@class='cas-number']/small"), 2).GetValue().Trim() == ingredient.CASNumber);
				if (matchingrow == null)
				{
					return false;
				}

				// So we hopefully hgave our matching row now - so lets try and get the Precentage Concentration field
				var concInput = matchingrow.FindElement(By.XPath(".//input[contains(@class,'percent-comp')]"), 2);
				concInput.EnterText(ingredient.Percent);
				return true;
			}

			return false;
		}


		/// <summary>
		/// Select vendor id from dropdown
		/// </summary>
		public bool SelectVendorId(string item)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);

				var el = container.FindElement(By.XPath(".//label[text()='Select Vendor']/..//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SetFullNameOfProductForRetailer(string retailer, string name)
		{
			var el = containerElement.FindElement(By.XPath(".//input[@placeholder='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)' and (./ancestor::td//preceding-sibling::td[contains(text(),'" + retailer + "')]) ]"), 2);
			if (el == null)
			{
				Report.Error("Could not find the Full Product Name field!");
				return false;
			}

			el.EnterText(name);
			return el.GetValue() == name;

		}

		/// <summary>
		/// Select Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) from dropdown
		/// </summary>
		public bool SelectPrivateLabelName(string item)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);

				var el = container.FindElement(By.XPath(".//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/..//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		///Enter full name of product, as sold, via this retailer (e.g. Private Label Aspirin) from dropdown
		/// </summary>
		public bool EnterPrivateLabelName(string item)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);

				var el = container.FindElement(By.XPath(".//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/..//input"), 2);
				el.EnterText(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/*===== Safety Data Sheet Authoring ====*/

		public string PersonalProtectionEquipmentRecommended
		{
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Personal Protection Equipment"));

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
					.FirstOrDefault(x => x.Text.Contains("Personal Protection Equipment"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.TryClick();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label personal protection equipment recommended could not be found");
				}
			}
		}

		public string AutoignitionTemperature {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Autoignition Temperature"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}
				
			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Autoignition Temperature"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string MinimumIgnitionEnergy {
			get
			{
				var lbl = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Ignition"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Ignition"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}
		/// <summary>
		/// Specific Gravity text box 
		/// </summary>
		public string SpecificGravity {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Specific Gravity"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Specific Gravity"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// pH text box 
		/// </summary>
		public string PH {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("pH"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("pH"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// Boiling Point (in Celsius) text box 
		/// </summary>
		public string BoilingPoint {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Boiling Point (in Celsius)"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Boiling Point (in Celsius)"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// Flash Point (in Celsius) text box 
		/// </summary>
		public string FlashPoint {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Flash Point (in Celsius)"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Flash Point (in Celsius)"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// UN Number text box 
		/// </summary>
		public bool UNnumber(string text)
		{
			//get
			//{
			//	var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
			//		.FirstOrDefault(x => x.Text.Contains("UN Number"));

			//	if (lbl != null)
			//	{
			//		var input = lbl.FindElement(By.XPath("../..//input"));
			//		return input.Text;
			//	}
			//	else
			//	{
			//		throw new Exception("Label not found as expected.");
			//	}

			//}
			//set
			//{
			//	var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
			//		.FirstOrDefault(x => x.Text.Contains("UN Number"));

			//	if (lbl != null)
			//	{
			//		var input = lbl.FindElement(By.XPath("../..//input"));
			//		input.EnterText(value);
			//	}
			//	else
			//	{
			//		throw new Exception("Label not found as expected.");
			//	}

			//}

			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='UN Number']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Technical Name (if applicable) text box 
		/// </summary>
		public bool TechnicalName(string text)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Technical Name (if applicable)']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		/// <summary>
		/// VOC content in grams ozone per gram text box 
		/// </summary>
		public bool VocContentInGrams(string text)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		/// <summary>
		/// Proper Shipping Name dropdown
		/// </summary>
		public bool ProperShippingName(string item)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Proper Shipping Name']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Hazard Class (select) dropdown
		/// </summary>
		public bool HazardClassSelect(string item)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Hazard Class (select)']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// Packing Group (select) dropdown
		/// </summary>
		public bool PackingGroupSelect(string item)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//label[text()='Packing Group (select)']/..//following-sibling::div//select"), 2);
				GeneralUtilities.Wait_for_load_finish();
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}


		public string Viscosity {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Viscosity"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Viscosity"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// Flash Point Testing Method Used radio options
		/// </summary>
		public string FlashPointTestingMethodUsed {
			get
			{
				List<string> countries = new List<string>();
				var listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Flash Point Testing Method Used"))
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
				var thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("Flash Point Testing Method Used")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				var optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}

		}

		/// <summary>
		/// Product has been granted an Alternative Control Plan option
		/// </summary>
		public bool AlternateControlPlan {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product has been granted an Alternative Control Plan"))
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
					throw new Exception("No Product has been granted an Alternative Control Plan option is selected");
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
					.FirstOrDefault(x => x.Text.Contains("Product has been granted an Alternative Control Plan"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();
			}
		}

		/// <summary>
		/// Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation radio options
		/// </summary>
		public string ProductDoesNotContainGramsOfVoc {
			get
			{
				List<string> countries = new List<string>();
				var listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("California Consumer Products Regulation"))
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
				var thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("California Consumer Products Regulation")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				var optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}

		}

		/// <summary>
		/// Browse and upload for Volatile Organic Compounds
		/// </summary>
		public bool ClickBrowseForVolatileOrganicCompounds()
		{
			try
			{
				var el = this.containerElement.FindElement(By.XPath("//*[@id='collapse1']/div/form/div[2]/div[2]/div[1]/div/a"), 2);
				if (el == null)
				{
					return false;
				}
				el.TryClick();
				GeneralFunctions.EnterFilename("C:\\Dependencies\\WERCSmart\\testdoc.pdf");
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Product label specifies a dilution ratio option
		/// </summary>
		public bool ProductLabelDilutionRatio {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product label specifies a dilution ratio"))
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
					throw new Exception("No Product label specifies a dilution ratio option is selected");
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
					.FirstOrDefault(x => x.Text.Contains("Product label specifies a dilution ratio"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();
			}
		}


		/// <summary>
		/// Product's VOC content as sold text box 
		/// </summary>
		public string ProductsVocContentAsSold {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product's VOC content as sold"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product's VOC content as sold"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}


		/// <summary>
		/// Product's VOC content as used text box 
		/// </summary>
		public string ProductsVocContentAsUsed {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product's VOC content as used"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product's VOC content as used"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}


		/// <summary>
		/// Get Ecologo statement
		/// </summary>
		public string GetEcologoStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'UL ECOLOGO Readiness Assessment')]"), 2).Text;
		}


		/// <summary>
		/// Gets statement - Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		/// </summary>
		public string GetProductGrantedAlternativeControlPlanStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product has been granted an Alternative Control Plan')]"), 2).Text;
		}


		/// <summary>
		/// Gets statement - Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.
		/// </summary>
		public string GetProductDoesNotContainGramsOfVocStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product does not contain more than 0.05 grams of VOC per use')]"), 2).Text;
		}


		/// <summary>
		/// Gets statement - VOC content in grams ozone per gram
		/// </summary>
		public string GetVocContentInGramsStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'VOC content in grams ozone per gram')]"), 2).Text;
		}


		/// <summary>
		/// Gets error message for VOC content in grams ozone per gram
		/// </summary>
		public string GetErrorMessageForVocContentInGrams()
		{
			return this.containerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//span"), 2).Text;
		}


		public string Appearance {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Appearance"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//select"));
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Appearance"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//select"));
					input.Select(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string Odor {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//select"));
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//select"));
					input.Select(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string OdorThreshold {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor Threshold"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//select"));
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor Threshold"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//select"));
					input.Select(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string PartitionCoefficient {
			get
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Partition Coefficient"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Partition Coefficient"));

				if (lbl != null)
				{
					var input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public bool SetOptionInSection(string section, string value)
		{
			var xPath = @"(//span[(.//ancestor::div[@class='form-group']//label[contains(text(),""" + section + @""")]) and contains(text(),'" + value + "')]/parent::label | " +
			            @"//input[(.//ancestor::div[@class='form-group']//label[contains(text(),""" + section + @""")]) and @type='text'] | " +
			            @"//span[(.//ancestor::div[contains(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and contains(text(),'" + value + "') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			var el = containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Error("Could not the correct input in section: " + section);
				return false;
			}

			if (el.GetAttribute("type") == "text")
			{
				el.EnterText(value);
				return el.GetValue() == value;
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
		public string UpcNumber { get; set; } = "";
		public string ContainerType { get; set; } = "";
		public string Size { get; set; } = "";
		public string Dpci { get; set; } = "";
		public string Quantity { get; set; } = "";

	}

	public class Ingredient
	{
		public string ComponentName { get; set; }
		public string CASNumber { get; set; }
		public string Percent { get; set; }
		public bool PublicallyDisclosed { get; set; }
		public bool TradeSecret { get; set; }
		public string PublicName { get; set; }
	}
}

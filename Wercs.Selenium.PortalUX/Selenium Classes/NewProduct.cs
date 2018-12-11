using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using Org.BouncyCastle.Crypto.Engines;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;


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
			var matches = Regex.Matches(el, @"\(\d*\)");
			var bracketedValue = matches[matches.Count - 1].Groups[0].Value;
			return bracketedValue.Trim().Substring(1, bracketedValue.Length - 2);
		}

		public string GetProductName()
		{
			return GetHeader().Replace("(" + GetProductId() + ")", "").Trim();
		}

		public ProductInformation GetCurrentProductInformation()
		{
			return new ProductInformation() { Id = GetProductId(), Name = GetProductName() };
		}

		public string GetInitialStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//form//label[@class='control-label']"), 2).Text;
		}

		public List<string> RadioButtons()
		{
			return this.containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public List<string> Checkboxes()
		{
			return this.containerElement.FindElements(By.XPath(".//form//input[@type='checkbox']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public string ErrorMessage()
		{
			this.RefreshContainer();
			return this.containerElement.FindElement(By.XPath(".//p[@class='form-error']//span"), 2)?.Text;
		}

		public List<string> AllErrorMessages()
		{
			this.RefreshContainer();
			return this.containerElement.FindElements(By.XPath(".//p[@class='form-error']//span"), 2)?.Select(x => x.Text).ToList();
		}

		public string BatteyWarning()
		{
			this.RefreshContainer();
			return this.containerElement.FindElement(By.XPath(".//div[@class='WARNING']"), 2).Text;
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
			if (newProduct)
			{
				SelectTypeOfProductToCreate("New");
			}
			else
			{
				SelectTypeOfProductToCreate("Copy");
			}
		}

		public bool RefreshContainer()
		{
			containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return containerElement != null;
		}

		public bool WaitForSection(string sectionHeader, int secondsToWait = 60)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				RefreshContainer();
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

		public bool CountryofOriginExists()
		{
			IWebElement myLabel =
				containerElement.FindElement(By.XPath(".//label[contains(text(),'Country of Origin')]"), 2);

			if (myLabel == null)
			{
				Report.Info("'Select the product's Country of Origin' Not Available");
				return false;
			}
			Report.Info("'Select the product's Country of Origin' Available");
			return true;
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
			// if the tab is currently active, we don't need to click it
			var active = containerElement.FindElement(By.XPath($".//div[@class='prog-wizard']//div[contains(@class, 'in-progress active') and ./span[text()='{tabName}']]"), 2);
			if (active != null)
			{
				Report.Info($"Tab: {tabName} was already active");
				return true;
			}
			var tab = containerElement.FindElements(By.XPath(".//div[@class='prog-wizard']//div[contains(@class, 'prog-step')]//a/span"), 2)
				.FirstOrDefault(x => x.Text.Contains(tabName));
			if (tab != null)
			{
				Report.Info("Clicking tab: " + tabName);
				return tab.FindElement(By.XPath("../../a")).TryClick();
			}
			return false;
		}

		public bool ClickSection(string section)
		{
			for (int i = 0; i < 5; i++)
			{
				//var list = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//h3")).Select(x=>x.GetValue());
				var sec = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//h3"), 2).FirstOrDefault(x => x.GetValue().Contains(section));

				if (sec != null)
				{
					if (sec.TryClick())
					{
						return true;
					}
				}
				Delay.Seconds(1);
			}

			var h3 = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//h3"), 2);
			foreach (var item in h3)
			{
				Report.Info("Found: " + item.Text);
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
				if (el.TryClick())
				{
					GeneralUtilities.WaitForRefreshToDisappear(el);
					GeneralUtilities.Wait_for_load_finish();
					var attempt = 0;
					var ajax = true;
					while (attempt < 15 && ajax)
					{
						Report.Info("Attempt: " + attempt);
						if (!GeneralUtilities.AjaxPopupExists())
						{
							ajax = false;
						}
						else
						{
							Report.Error("Ajax error was displayed! Clicking Close.");
							GeneralUtilities.CloseAjaxPopup();
							el.TryClick();
							GeneralUtilities.WaitForRefreshToDisappear(el);
							GeneralUtilities.Wait_for_load_finish();
							attempt++;
							Delay.Seconds(2);
						}
					}
					return !ajax;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickCancelButton()
		{
			try
			{
				var el = this.containerElement.FindElement(By.XPath(".//a[contains(@class,'cancel-button')]"), 2);
				if (el == null)
				{
					return false;
				}
				return el.TryClick() && GeneralUtilities.WaitForRefreshToDisappear(el) && GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickSaveButton()
		{
			try
			{
				var listSaveButtons = this.containerElement.FindElements(By.XPath(".//a[contains(@class,'save-button')]"), 2);

				var el = listSaveButtons.FirstOrDefault(x => x.Displayed);
				if (el == null)
				{
					return false;
				}
				return el.TryClick() && GeneralUtilities.WaitForRefreshToDisappear(el) && GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickContinueNoError()
		{
			try
			{
				var el = this.containerElement.FindElement(By.XPath(".//a[contains(@class,'continue-button')]"), 2);
				if (el == null)
				{
					return false;
				}

				el.TryClick();
				if (!GeneralUtilities.WaitForRefreshToDisappear(el) && ErrorMessage() != null)
				{
					Report.Screenshot();
					return false;
				}

				GeneralUtilities.Wait_for_load_finish();
				return true;
			}
			catch (Exception)
			{
				Report.Error("Page loaded too quickly to check error message.");
				return true;
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

		public List<string> ProductsMayBeSold {
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
				List<KeyValuePair<int, string>> th = TableHeaders(thisTable);

				var listOfRows = containerElement.FindElements(By.XPath(".//tbody//tr"));

				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
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

					listOfBatteries.Add(new Battery() { BatteryType = batteryType, Manufacturer = manufacturer, NumberPerPackage = numberPerPackage, RequiredToRun = requiredToRun });
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
							Report.Info(e.Message);
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
					Delay.Seconds(2);
					int count = 0;
					bool foundResult = false;
					IWebElement selectDropDown = null;
					while (count < 30 && !foundResult)
					{
						selectDropDown = enterManufacturer.FindElement(By.XPath("../following-sibling::span"), 2);
						foundResult = selectDropDown != null;
						if (foundResult)
						{
							Report.Info("Found search results. Clicking the first option.");
							if (selectDropDown.FindElements(By.XPath(".//ul/li")).First().TryClick())
							{
								break;
							}
							Report.Info("Failed to click first search result option. Trying again...");
						}
						count++;
						Delay.Seconds(1);
					}
					if (!foundResult)
					{
						throw new Exception("Manufacturer drop down could not be found");
					}
					//var selectDropDown = enterManufacturer.FindElement(By.XPath("../following-sibling::span"));
					var perPackage = listOfRows.FirstOrDefault().FindElement(By.XPath(".//td[" + perPackageIndex.ToString() + "]//input"));
					perPackage.EnterText(thisBattery.NumberPerPackage.ToString());
					var batteriesRequired = listOfRows.FirstOrDefault().FindElement(By.XPath(".//td[" + batteriesRequiredIndex.ToString() + "]//input"));
					batteriesRequired.EnterText(thisBattery.RequiredToRun.ToString());
				}
			}
		}

		public bool ProductClassifiedUnderOSHA {
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
					.FirstOrDefault(x => x.Text.Contains("Prop 65") || x.Text.Contains("Proposition 65"))
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
					.FirstOrDefault(x => x.Text.Contains("Prop 65") || x.Text.Contains("Proposition 65"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();
				Report.Screenshot();

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
					var metalLabel = header.FindElements(By.XPath("../../following::div//label[@class='control-label']")).FirstOrDefault(x => x.GetValue().Trim() == thisMetal.Metal);
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
			var circuitDiv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

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

		public string ProductLineOrBrand {
			set
			{
				var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
				el.SelectByValue(value);
			}
		}

		public string ProductType {
			set
			{
				Report.Info("Setting product type");
				var el = this.containerElement.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"), 2);
				el.Click();
				var inputField = this.containerElement.FindElement(By.XPath("//span[contains(@class,'select2-container')]//input"), 2);
				inputField.EnterText(value);
				GeneralUtilities.Wait_for_load_finish();

				var dropDownResults = this.containerElement.FindElements(By.XPath("//span[contains(@class,'select2-container')]//ul/li"), 2);
				var ddlEl = dropDownResults.FirstOrDefault(x => x.Text.Trim() == value);
				// Check again ignoring the case
				if (ddlEl == null)
				{
					ddlEl = dropDownResults.FirstOrDefault(x => x.Text.Trim().ToLower() == value.ToLower());
					if (ddlEl == null)
					{
						//Check again accepting contains rather than full match
						ddlEl = dropDownResults.FirstOrDefault(x => x.Text.Trim().ToLower().Contains(value.ToLower()));
						if (ddlEl == null)
						{
							return;
						}
					}
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

		public List<string> GetAllUPCDestinationRetailers()
		{
			var container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			return container.FindElements(By.XPath(".//span[contains(@data-bind,'identifier')]"), 2).Select(x => x.Text).ToList();
		}

		public bool UPCPackageTypeFieldExists()
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				var packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
				if (packageTypeField == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public string GetValidOptionForUPCPackageType()
		{
			if (!this.UPCPackageTypeFieldExists())
			{
				Report.Info("Package type field does not exist");
				Report.Screenshot();
				return null;
			}
			var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			List<string> selectOptions = packageTypeField.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
			return selectOptions.FirstOrDefault(x => x != "Package Type");

		}

		public bool InputUpcInformation(UpcInformation info)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				var textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				var upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

				if (info.UpcNumber.ToLower().Contains("saved as"))
				{
					try
					{
						var savedUPC = Context
							.GetFromContext(info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						info.UpcNumber = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}

				}
				upcNumberField.EnterText(info.UpcNumber);
				var containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
				containsType.Select(info.ContainerType);
				var regex = @"(.*)\((.*)\)";
				var sizeField = (from input in textInputs
								 let match = Regex.Match(input.GetAttribute("placeholder"), regex)
								 where match.Success && match.Groups[1].Value.StartsWith("Size") && match.Groups[2].Value.Contains("Ounces")
								 select input).FirstOrDefault();
				if (sizeField == null)
				{
					Report.Info(@"Failed to find 'Size' input in the format ""Size (.. Ounces)""");
					return false;
				}
				sizeField.EnterText(info.Size);
				if (info.Dpci.Length > 0)
				{
					var dpciField = container.FindElement(By.XPath(".//input[contains(@data-bind,'value.field')]"), 2);
					dpciField.EnterText(info.Dpci);
				}
				if (info.Quantity.Length > 0)
				{
					var quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity']"), 2);
					quantityField.EnterText(info.Quantity);
				}

				if (info.PackageType.Length > 0)
				{
					var packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
					packageField.Select(info.PackageType);
				}
				return true;
			}
			catch (Exception ex)
			{
				SafewareReporting.Report.Info(ex.Message);
				return false;
			}
		}

		public List<string> GetUPCHeaders()
		{
			var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var rList = new List<string>();
			if (container != null)
			{
				rList = container.FindElement(By.XPath(".//th[@class='col-xs-5']")).GetValue().Replace("\r\n", "|").Split('|').Select(x => x.Trim()).Where(x => x != "UPC Number").ToList();
			}
			return rList;
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

		public List<string> Get3rdPartyPageAlerts()
		{
			var el = containerElement.FindElements(By.XPath(".//div[@class='alert alert-info']"), 2);
			if (el.Count > 0)
			{
				return containerElement.FindElements(By.XPath(".//div[@class='alert alert-info']"), 2).Select(x => x.GetValue()).ToList();
			}
			return new List<string>();
		}

		public bool ThirdPartyScreenAppears()
		{
			var el = containerElement.FindElement(By.XPath(".//h3[text()='Formulation > 3rd Party']"), 2);
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

		public bool YesAgreedIsSelected()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Yes, Agreed')]/../input"), 2);
			if (el == null)
			{
				return false;
			}
			return el.Selected;
		}

		public bool YesAgreedExists()
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Yes, Agreed')]/../input"), 2);
				if (el == null)
				{
					return false;
				}
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool AcceptRadioIsSelected()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Accept')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool SelectAcceptRadio()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Accept')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		public bool SelectGrantedRadio()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Granted')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public bool GrantedRadioIsSelected()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Granted')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool SelectDeclinedRadio()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Declined')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		public bool DeclinedRadioIsSelected()
		{
			var el = containerElement.FindElement(By.XPath(".//span[contains(text(), 'Declined')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool ClickAcceptButton()
		{
			var el = containerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
			if (el == null)
			{
				return false;
			}

			if (el.TryClick())
			{
				Delay.Seconds(1);
				Report.Info("Clicked accept button. Beginning wait for loading to finish");
				return GeneralUtilities.WaitForRefreshToDisappear(el, 120);
			}
			else
			{
				Report.Info("Failed to click accept button");
				return false;
			}
		}



		public bool AcceptButtonDisplayed()
		{
			var el = containerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
			return el != null && el.Displayed;
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
		/// Please select DOT Exceptions if applicable -- eg 173.120(a)(2), 173.120(a)(3)
		/// </summary>
		public bool DotExcemptionIfApplicable(string item)
		{
			try
			{
				var el = containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable?')]/../following-sibling::div//span"), 2)
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
					.FirstOrDefault(x => x.Text.ToLower() == item.ToLower()).FindElement(By.XPath("../input"));
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

		public string WaterSolubility {
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

		public bool SetWaterSolutionQuestion {
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

		public bool AddItemToKit(string product)
		{
			try
			{
				var placeholderEl = containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
				placeholderEl.TryClick();
				IWebElement MatchedEntry = null;
				var inputEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
				inputEl.EnterText(product);
				var searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				}
				var Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				var MatchingNameValue = Matches.FirstOrDefault(x => x.GetValue().Trim().ToLower() == product.Trim().ToLower());
				if (MatchingNameValue == null)
				{
					// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
					MatchedEntry = Matches.FirstOrDefault();
				}
				else
				{
					MatchedEntry = MatchingNameValue;
				}

				return MatchedEntry.TryClick();
			}
			catch (Exception e)
			{
				return false;
			}

		}

		// searches by name, matches by ID
		public bool AddItemToKitByNameAndID(ProductInformation product)
		{
			try
			{
				for (int j = 0; j < 5; j++)
				{
					var placeholderEl = containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
					placeholderEl.TryClick();
					IWebElement MatchedEntry = null;
					var inputEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
					inputEl.EnterText(product.Name);
					var searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}
					var Matches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					var MatchingByID = Matches.FirstOrDefault(x => x.GetValue().Trim().ToLower().Contains(product.Id.ToLower()));
					if (MatchingByID == null)
					{
						// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
						MatchedEntry = Matches.FirstOrDefault();
					}
					else
					{
						MatchedEntry = MatchingByID;
					}


					if (MatchedEntry != null)
					{
						Report.Info("Found matching search item, attempting to click");
						MatchedEntry.TryClick();
						Delay.Seconds(1);
						var listOfSelected = SeleniumBrowser.WebBrowser.FindElements(By.XPath(
							"//div[contains(text(), 'Select Existing Registrations')]/../..//table/tbody/tr//input/../..//span"));

						var matchingProduct = listOfSelected.FirstOrDefault(x => x.GetValue().Contains(product.Name));

						if (matchingProduct != null)
						{
							Report.Info("Matching product showing in table, attempting to check checkbox");
							var matchingCheckbox = matchingProduct.FindElement(By.XPath("../..//input"), 2);
							return matchingCheckbox.TryClick();
						}
					}
				}

				return false;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		// ========= Add Ingredient Functions ========= //

		public bool AddIngredient(Ingredient ingredient)
		{
			var placeholderEl = containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
			placeholderEl.TryClick();
			IWebElement clickResult;
			var inputEl = containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			// If the ingredient has a CAS number assigned, search by that string
			if (!string.IsNullOrEmpty(ingredient.CASNumber))
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
				var results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				if (!results.Any())
				{
					Report.Info("No results were returned on search");
					return false;
				}
				while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) == null)
				{
					Delay.Seconds(1);
					results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				}
				if (results.Count == 0)
				{
					return false;
				}
				// Find every result row returned which match the CAS we are looking for, exluding the 'loading' row which appears at the bottom
				var matchingCasResults = results.Where(x => !x.Text.ToLower().Contains("loading") && x.FindElement(By.XPath(".//span[@class='text-muted']"), 2).Text.Trim() == ingredient.CASNumber.Trim());
				if (!matchingCasResults.Any())
				{
					clickResult = results.FirstOrDefault();
					ingredient.CASNumber = clickResult.FindElement(By.XPath(".//span[2]"), 2).GetValue();
					ingredient.ComponentName = clickResult.FindElement(By.XPath(".//span[1]"), 2).GetValue();
					Report.Info("No CAS match was found! Clicking the first search result with CAS number: " + ingredient.CASNumber);
				}
				else
				{
					// In this case we have entries with matching CAS Numbers, so we should double check that our product name matches?
					if (string.IsNullOrEmpty(ingredient.ComponentName))
					{
						// No Component name was specified, so we just take the first value with a matching CAS Number!
						clickResult = matchingCasResults.FirstOrDefault();
						Report.Info("Clicking result in smart search with CAS number: " + clickResult.FindElement(By.XPath(".//span[@class='text-muted']")).Text);
					}
					else
					{
						// Component name was defined, so just check to see if there is a match
						var matchingNames = matchingCasResults.FirstOrDefault(x => x.FindElement(By.XPath(".//span[@class='component-name' and text() = '" + ingredient.ComponentName + "']"), 2) != null);
						if (matchingNames == null)
						{
							// No match was found, so just take the first entry!
							clickResult = matchingCasResults.FirstOrDefault();
							Report.Info("Clicking result in smart search with CAS number: " + clickResult.FindElement(By.XPath(".//span[@class='text-muted']")).Text);
						}
						else
						{
							// Matching entry was found, so taking this instead!
							clickResult = matchingNames;
							Report.Info("Found the matched search result. Clicking result in smart search with CAS number: " + ingredient.CASNumber + " and name: " + ingredient.ComponentName);
						}
					}
				}
			}
			else
			{
				Report.Info("No CAS Number was assigned to the ingredient, so searching for the chemical by Component Name instead");
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
				var results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				i = 0;
				while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='component-name']"), 2) == null && i < 20)
				{
					if (containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2)?.Text == "No results found")
					{
						Report.Info("There were no results returned searching by Name!");
						throw new Exception("Unable to add the ingredient because the search criteria did not yield any!");
					}
					i++;
					Delay.Seconds(1);
					results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				}
				// Avoiding null reference exception on .GetValue() - "Loading more results" row at the bottom (no span with component-name)
				var matchingNameResults = results.Where(x => !x.Text.ToLower().Contains("loading") && x.FindElement(By.XPath(".//span[@class='component-name']"), 2).Text.Trim() == ingredient.ComponentName.Trim());
				if (!matchingNameResults.Any())
				{
					// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
					clickResult = results.FirstOrDefault();
					ingredient.CASNumber = clickResult.FindElement(By.XPath(".//span[2]"), 2).GetValue();
					ingredient.ComponentName = clickResult.FindElement(By.XPath(".//span[1]"), 2).GetValue();
					Report.Info("There was no match on name, so selected the first search result with name: " + ingredient.ComponentName + " and CAS number: " + ingredient.CASNumber);
				}
				else
				{
					clickResult = matchingNameResults.FirstOrDefault();
					// We have found a match by the component name! So we should update our CAS Number field
					ingredient.CASNumber = clickResult.FindElement(By.XPath(".//following-sibling::span[@class='text-muted']"), 2).GetValue();
					Report.Info("Selecting the first search result which matched on chemical name: " + ingredient.ComponentName + " with CAS: " + ingredient.CASNumber);
				}
			}
			// Click the element we have identified as the best match
			if (clickResult.TryClick())
			{
				// So we have now selected the element, so we need to try and get the first 'new' entry which contains this CAS Number, and hasn't had the Percentage field filled
				bool success = true;
				var rows = containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2);
				var matchingrow = rows.FirstOrDefault(x => x.FindElement(By.XPath(".//div[@class='cas-number']/small"), 2).GetValue().Trim() == ingredient.CASNumber);
				if (matchingrow == null)
				{
					return false;
				}
				// Find the percentage field for the matched row
				var concInput = matchingrow.FindElement(By.XPath(".//input[contains(@class,'percent-comp')]"), 2);
				Report.Info("Entering percentage: " + ingredient.Percent);
				concInput.EnterText(ingredient.Percent);
				// Find the Publicly Disclosed field for the matched row
				var publicDisclosure = matchingrow.FindElement(By.XPath(".//td[@class='transparency']//input"), 2);
				if (publicDisclosure != null && ingredient.PublicallyDisclosed != publicDisclosure.Checked())
				{

					Report.Info("Setting Publicly Disclosed to: " + ingredient.PublicallyDisclosed);
					if (!publicDisclosure.TryCheck(ingredient.PublicallyDisclosed))
					{
						success = false;
					}
				}
				// Find the Trade Secret field for the matched row
				var tradeSecret = matchingrow.FindElement(By.XPath(".//td[@class='trade-secret']//input"), 2);
				if (tradeSecret != null && ingredient.TradeSecret != tradeSecret.Checked())
				{
					Report.Info("Setting Trade Secret to: " + ingredient.TradeSecret);
					if (!tradeSecret.TryCheck(ingredient.TradeSecret))
					{
						success = false;
					}
				}
				if (!string.IsNullOrEmpty(ingredient.PublicName))
				{
					var publicName = matchingrow.FindElement(By.XPath(".//td[@class='inci-name']//select"), 2);
					publicName.Select(ingredient.PublicName);
				}
				return success;
			}
			Report.Info("Failed to click the matched ingredient search result!");
			return false;
		}

		public string GetIngredientErrorMessage()
		{
			var el = containerElement.FindElement(By.XPath(".//div[contains(@class,'formulation-grid')]//div[@role='alert']//span[starts-with(@data-bind,'text')]"), 2);
			return el == null ? "" : el.Text;
		}


		/// <summary>
		/// Select first vendor id from dropdown
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


		/// <summary>
		/// Select vendor id from dropdown for a specific retailer
		/// </summary>
		public bool SelectVendorIdForRetailer(string retailer, string item, bool selectFirst = false)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				var el = container.FindElement(By.XPath($@".//tr[./td[text()=""{retailer}""]]//label[text()='Select Vendor']/..//select"), 2);
				if (el == null)
				{
					Report.Info("Vendor was not selectable for retailer: " + retailer);
					return false;
				}
				if (selectFirst)
				{
					var options = el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "Choose...").ToList();
					if (options.Count == 0)
					{
						Report.Info("There were no vendor options available for retailer " + retailer);
						return false;
					}
					Report.Info("Selecting the first vendor option for retailer: " + retailer);
					var firstOption = options.First();
					Report.Info("First vendor option is: " + firstOption);
					el.Select(firstOption);
					Delay.Seconds(1);
					return el.SelectedOption() == firstOption;
				}
				el.Select(item);
				Delay.Seconds(1);
				return el.SelectedOption() == item;
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

		public bool SetPrivateLabelName(string item, string retailer)
		{
			try
			{
				var el = containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']//tr[(.//td[text()='" + retailer + "'])]//input[starts-with(@placeholder,'Indicate full name of product')]"), 2);
				if (el == null)
				{
					Report.Error("Could not find the input field for retailer: " + retailer);
					return false;
				}
				el.EnterText(item);

				return el.GetValue() == item.Trim();
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

		public string PersonalProtectionEquipmentRecommended {
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

		public bool UploadFileForSection(string section, string pdfFilePath)
		{
			var el = containerElement.FindElement(By.XPath(".//span[text()='" + section + "']//parent::div//a[text()='Browse']"), 2);
			Report.Info("Clicking Browse for document type: " + section);
			Report.Screenshot();
			if (el == null)
			{
				Report.Error("The browse button was not found!! - Looking for xpath: //span[text()='" + section + "']//parent::div//a[text()='Browse']");
				return false;
			}

			if (!el.TryClick())
			{
				Report.Error("Failed to click the Browse button!");
				return false;
			}
			Delay.Seconds(2);
			Report.Info("Entering file name with path: " + pdfFilePath);
			Report.IsTrue(GeneralFunctions.EnterFilename(pdfFilePath), "Failed to enter file name!", "Successfully entered file name");
			int i = 0;
			var viewEl = this.containerElement.FindElement(By.XPath(".//span[text()='" + section + "']//parent::div//a[contains(text(), 'View')]"), 2);
			while ((viewEl == null || !viewEl.Displayed) && i < 10)
			{
				i++;
				Delay.Seconds(1);
				viewEl = this.containerElement.FindElement(By.XPath(".//span[text()='" + section + "']//parent::div//a[contains(text(), 'View')]"), 2);
			}
			return (viewEl != null && viewEl.Displayed);
		}
		//Use this when there are multiple instances of the label type on the documents page. EG. Product label (Generic Private Label and Volatile Organic Compounds)
		public bool UploadFileForSectionAndType(string label, string section, string pdfFilePath)
		{
			//var el = containerElement.FindElement(
			//By.XPath(
			//	".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div[//span[text()='" + label + "' and not(contains(@style, 'display: none;'))]]//a[text()='Browse']"),
			//2);
			var el = containerElement.FindElement(
				By.XPath(
					".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div//span[text()='" + label + "' and not(contains(@style, 'display: none;'))]/..//a[text()='Browse']"),
				2);
			if (el == null)
			{
				return false;
			}

			if (!el.TryClick())
			{
				return false;
			}

			GeneralFunctions.EnterFilename(pdfFilePath);

			int i = 0;
			while (containerElement.FindElement(By.XPath(".//span[contains(text(),'" + section + "')]//parent::div//a[text()='Remove']"), 2) == null && i < 10)
			{
				i++;
				Delay.Seconds(Delay.SpeedFactor * 1);
			}
			return true;
		}

		public string GetDocumentTypeForSection(string section)
		{
			try
			{
				var xpath = ".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div[//span[not(contains(@style, 'display: none;'))]]/div[not(contains(@style,'display: none;'))]/span[contains(@data-bind, 'text: Description')]";
				var labelType = containerElement.FindElement(By.XPath(xpath));
				if (labelType == null)
				{
					return null;
				}

				return labelType.Text;
			}
			catch (NoSuchElementException)
			{
				return null;
			}
		}

		public string SectionColour(string section)
		{
			var xPath = @"//div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]";
			var el = containerElement.FindElement(By.XPath(xPath), 2);
			var colour = el?.GetCssValue("color");

			return colour;
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

		public bool VOCConcentrationQuestionHasYesAndNo()
		{
			var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("VOC concentration"));

			if (lbl != null)
			{
				var inputs = lbl.FindElements(By.XPath("../..//input/../span"));
				var options = inputs.Select(x => x.GetValue()).ToList();
				return options.Contains("Yes") && options.Contains("No");
			}
			else
			{
				return false;
			}
		}

		public string VOCConcentrationError()
		{
			var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("VOC concentration"));

			if (lbl != null)
			{
				try
				{
					var error = lbl.FindElement(By.XPath("../..//input/../../../p//span"));
					if (error != null)
					{
						return error.Text;
					}
					else
					{
						return null;
					}
				}
				catch (Exception e)
				{
					return null;
				}

			}
			else
			{
				throw new Exception("Label not found as expected.");
			}

		}

		public List<string> DisplayedAlerts()
		{
			try
			{
				var errors = containerElement.FindElements(By.XPath("//div[contains(@class, 'alert')]"));
				return errors.Where(x => x.Displayed).ToList().Select(x => x.GetValue()).ToList();
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public string VOCContentsAsSoldError()
		{
			var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("Product's VOC content as sold"));

			if (lbl != null)
			{
				try
				{
					var error = lbl.FindElement(By.XPath("../..//input/../p//span"));
					if (error != null)
					{
						return error.Text;
					}
					else
					{
						return null;
					}
				}
				catch (Exception e)
				{
					return null;
				}

			}
			else
			{
				throw new Exception("Label not found as expected.");
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

		public string VOCContentsAsUsedError()
		{
			var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("Product's VOC content as used"));

			if (lbl != null)
			{
				try
				{
					var error = lbl.FindElement(By.XPath("../..//input/../p//span"));
					if (error != null)
					{
						return error.Text;
					}
					else
					{
						return null;
					}
				}
				catch (Exception e)
				{
					return null;
				}

			}
			else
			{
				throw new Exception("Label not found as expected.");
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
		/// Gets statement - Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?
		/// </summary>
		public string GetUseVocPercentageAllAreaStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'VOC percentages entered for all areas')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB
		/// </summary>
		public string GetAmountOfVocDefinedByCARBStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'excluding exempt compounds as defined by the CARB')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Verify VOC content is below the threshold of 0.02lb/start of CARB
		/// </summary>
		public string GetVOCContentBelowThresholdOfCARBStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'start of CARB')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Verify VOC content is below the threshold of 0.02lb/start of OTC
		/// </summary>
		public string GetVOCContentBelowThresholdOfOTCStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'start of OTC')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
		/// </summary>
		public string GetAmountOfVocByOTCRuleStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'OTC Model Rule')]"), 2).Text;
			//return el != null;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
		/// </summary>
		public bool GetAmountOfVocByOTCRuleNotStatement()
		{
			var el = containerElement.FindElement(By.XPath(".//label[contains(text(),'OTC Model Rule')]"), 2);
			return el != null;
		}

		/// <summary>
		/// Gets statement - VOC content in grams ozone per gram
		/// </summary>
		public string GetVocContentInGramsStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'VOC content in grams ozone per gram')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement Based on your selection, you have verified your product contains VOC with intended uses as follows... the CARB VOC compliance limit(s) for the intended use you identified is/are:
		/// </summary>
		public string GetCarbVocComplianceLimitStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field')]//b[contains(text(),'CARB VOC compliance limit')]"), 2)?.Text;
		}

		/// <summary>
		/// Gets error message for VOC content in grams ozone per gram
		/// </summary>
		public string GetErrorMessageForVocContentInGrams()
		{
			return this.containerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//span"), 2).Text;
		}

		// JS - consolidated  multiple methods to fetch CARB, MVOC etc. value text into one
		/// <summary>
		/// Gets value from Volatile Organic Compound Summary page below the state table. EG. CARB, HVOC, MVOC, OTC Model Rule, VOC Grams Ozone, VOC Analysis
		/// </summary>
		public string GetValueVOCSummary(string category)
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and contains(text(),'" + category + "')]//b"), 2)?.Text;
		}

		// JS - consolidated multiple methods to fetch statement text (eg. VOC limits, restrictive VOC limit etc) into one
		/// <summary>
		/// Gets statement text from VOC Summary page
		/// </summary>
		public string GetVocSummaryStatementText(string category)
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and contains(text(),'" + category + "')]"), 2)?.Text;
		}

		/// <summary>
		/// Gets VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states. statement
		/// </summary>
		public string VocWeightPercentageForEachStateStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'description') and contains(text(),'weight percentage of total formula')]"), 2).Text;
		}

		public List<string> GetVOCSummaryStatements()
		{
			var statements =
				containerElement.FindElements(By.XPath(".//div[contains(@class, 'success') and not(.//table)]"));
			return statements.Select(x => x.GetValue().Trim()).ToList();
		}

		public List<VocLimits> GetDisplayedVocLimits()
		{

			var retList = new List<VocLimits>();
			var tableElement = containerElement.FindElement(By.XPath(".//div[./div[text()='Limits']]/following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}
			var rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (var row in rows)
			{
				var use = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				var voccompliancelimit = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				var regulation = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				retList.Add(new VocLimits {
					Use = use,
					VocComplianceLimit = voccompliancelimit,
					Regulation = regulation
				});
			}
			return retList;
		}

		public List<VocLimitsWithUnits> GetDisplayedVocLimitsWithUnits()
		{

			var retList = new List<VocLimitsWithUnits>();
			var tableElement = containerElement.FindElement(By.XPath(".//table[@class='table table-hover table-fixed']"), 2);
			if (tableElement == null)
			{
				return null;
			}
			// James
			// Previously using static indices for each column in the table (Use | Compliance Limits | Units | Regulation)
			// but the 'units' column is sometimes ommited causing null ref exception
			var rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			// Fetch the indices for each column from the headings by name.
			var columnHeadings = tableElement.FindElements(By.XPath(".//thead//th"), 2).ToList();
			int getIndex;
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Use"));
			// If the returned index for any column name is -1, we return a null string for that property.
			var useInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "VOC Compliance Limit"));
			var complianceInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Units"));
			var unitsInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Regulation"));
			var regulationInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			foreach (var row in rows)
			{
				var use = useInd == null ? null : row.FindElement(By.XPath(".//td[" + useInd + "]"), 2).GetValue();
				var voccompliancelimit = complianceInd == null ? null : row.FindElement(By.XPath(".//td[" + complianceInd + "]"), 2).GetValue();
				var units = unitsInd == null ? null : row.FindElement(By.XPath(".//td[" + unitsInd + "]"), 2).GetValue();
				var regulation = regulationInd == null ? null : row.FindElement(By.XPath(".//td[" + regulationInd + "]"), 2).GetValue();
				retList.Add(new VocLimitsWithUnits() { Use = use, VocComplianceLimit = voccompliancelimit, Units = units, Regulation = regulation });
			}
			return retList;
		}

		public List<VocPercentForStates> GetDisplayedVocPercentForEachState()
		{

			var retList = new List<VocPercentForStates>();
			var tableElement = containerElement.FindElement(By.XPath("//div[text()='VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.']//parent::div//parent::div//following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}
			var rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (var row in rows)
			{
				var state = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				var regulation = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				var vocvalue = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				var statevocthreshold = row.FindElement(By.XPath(".//td[4]"), 2).GetValue();
				var message = row.FindElement(By.XPath(".//td[5]"), 2).GetValue();
				retList.Add(new VocPercentForStates {
					State = state,
					Regulation = regulation,
					VocValue = vocvalue,
					StateVocThreshold = statevocthreshold,
					Message = message
				});
			}

			return retList;

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

		public List<string> GetErrorsForSection(string section)
		{
			var els = containerElement.FindElements(By.XPath(@".//span[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2);
			return els.Count == 0 ? new List<string>() : els.Select(x => x.Text).ToList();
		}

		public bool SetAdditionalOptionInSection(string section, string value)
		{
			// In some cases the below step will not find the correct element - rather than changing this we will create this step which exclusively looks for checkboxes!
			var el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@".//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + @"') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input"), 2);
			if (el == null)
			{
				Report.Error("Could not find element");
				return false;
			}

			el.SendKeys(Keys.PageUp);
			Delay.Seconds(1);
			return el.TryClick();
		}

		public List<string> GetDisplayedSections()
		{
			var DisplayedSections = new List<string>();
			var els = containerElement.FindElements(By.XPath(@"//div[starts-with(@class,'form-group')]/div/label"), 2);
			DisplayedSections = els.Select(x => x.Text).ToList();
			return DisplayedSections;
		}

		public bool OptionExists(string section)
		{
			try
			{
				var xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
							@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
							@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
							@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
							@"//div[@class='dropzone' and (.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
							@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

				var el = containerElement.FindElement(By.XPath(xPath), 2);
				return el != null && el.Displayed;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool OptionExists(string section, string value)
		{
			var xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			var el = containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}

			if (el.TagName.ToLower() == "select")
			{
				return el.FindElements(By.XPath("//option")).Select(x => x.Text.Trim()).Contains(value);
			}

			return false;
		}

		public bool SectionExists(string section)
		{
			var xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" +
						section + @""")]) and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" +
						section + @""")]) and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" +
						section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" +
						section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" +
						section + @""")]) and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			var el = containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Info("Section unavailable: " + section);
				return false;
			}
			Report.Info("Section exists: " + section);
			return true;
		}

		public bool SetOptionInSectionSubSection(string section, string subSection, string value)
		{
			var xPath = $@"//div[preceding-sibling::div[./label[contains(text(),""{section}"")]]]//div[@class='form-subgroup' and preceding-sibling::div[.//span[contains(text(),'{subSection}')]]]//input[./following-sibling::span[contains(text(),'{value}')]]";
			var el = containerElement.FindElement(By.XPath(xPath), 10);
			if (el == null)
			{
				Report.Info($"Unable to find the input under section {section} and subsection {subSection} option {value}");
				return false;
			}
			if (el.GetAttribute("type") == "checkbox")
			{
				el.TryCheck();
				return el.Checked();
			}
			Report.Info("Method only applicable to checkbox type input");
			return false;
		}

		public bool CheckStandaloneCheckbox(string description)
		{
			var el = this.StandaloneCheckbox(description);
			return el.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public IWebElement StandaloneCheckbox(string description)
		{
			var el = containerElement.FindElement(By.XPath($@".//div[@class='checkbox' and (.//span[contains(text(),""{description}"")])]/label/input"), 2);
			if (el == null)
			{
				Report.Info($"Could not find checkbox with description: '{description}'");
				return null;
			}
			return el;
		}

		public bool SetOptionInSection(string section, string value)
		{
			var xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			var el = containerElement.FindElement(By.XPath(xPath), 10);


			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}

			el.ScrollElementIntoView();
			Report.Info("Entering value of: '" + value + "' in section: '" + section + "'");
			if (el.GetAttribute("type") == "text")
			{
				el.EnterText(value);
				return el.GetValue() == value;
			}
			if (el.TagName.ToLower() == "select")
			{
				int i = 0;
				while (i < 10)
				{
					try
					{
						el.Select(value);
						return el.SelectedOption() == value;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}
				}

				return el.SelectedOption() == value;
			}

			try
			{
				if (el.GetAttribute("type") == "checkbox")
				{
					el.TryCheck();
					return el.Checked();
				}

			}
			catch (Exception e)
			{

			}
			// don't click the label if it contains a web link
			if (el.FindElement(By.XPath("./span/a[contains(@href,'http')]"), 2) == null && el.TryClick())
			{
				Delay.Seconds(1);
				if (SelectedOptionsForSection(section).Contains(value))
				{
					return true;
				}
			}
			return el.FindElement(By.XPath("./input"), 10).TryClick();
		}


		// NB only works fr select/option
		public bool SetOptionInSectionByValue(string section, string value, string text)
		{
			var xPath = @"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])]";
			var el = containerElement.FindElement(By.XPath(xPath), 2);
			try
			{
				el.SelectByValue(value);
				Delay.Seconds(1);
				return el.SelectedOption() == text;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickSelectForSection(string section)
		{
			return containerElement.FindElement(By.XPath(@".//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2).TryClick();
		}


		public List<string> SelectedOptionsForSection(string section)
		{
			var matchingElements = containerElement.FindElements(By.XPath(@".//div[contains(@class,'form-group') and .//label[starts-with(text(),""" + section + @""")]]//*[name()='input' or name()='select']"), 2);
			if (matchingElements.Count == 0)
			{
				return new List<string>();
			}
			if (matchingElements.Count == 1 && matchingElements.FirstOrDefault().TagName.ToLower() == "select")
			{
				return new List<string> { matchingElements.FirstOrDefault().SelectedOption() };
			}

			// Assume we have 'input' tags

			if (matchingElements.FirstOrDefault().GetAttribute("type").ToLower() == "checkbox" || matchingElements.FirstOrDefault().GetAttribute("type").ToLower() == "radio")
			{
				// In this case, we should return all the selected options
				return matchingElements.Where(x => x.Checked()).Select(x => x.FindElement(By.XPath(".//following-sibling::span"), 2).Text.Trim()).ToList();
			}
			if (matchingElements.FirstOrDefault().GetAttribute("type").ToLower() == "text")
			{
				var rText = "";
				if (!matchingElements.First().Text.IsNullOrEmpty())
				{
					rText = matchingElements.First().Text;
				}
				else if (!matchingElements.First().GetValue().IsNullOrEmpty())
				{
					rText = matchingElements.First().GetValue();
				}
				return new List<string> { rText };
			}
			return null;
		}

		public bool SetAllCheckOptionsInSection(string section, bool check)
		{
			var xpath = @"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")])]/preceding-sibling::input";
			var els = containerElement.FindElements(By.XPath(xpath), 2);
			foreach (var el in els)
			{
				el.Check(check);
			}

			return true;
		}

		public string VocAnalysisDateStatement()
		{
			var vocAnalysisDateStatement =
				containerElement.FindElement(
					By.XPath(@"//div[contains(text(), 'VOC Analysis Date') and ancestor::div[@class='form-group has-success']]"));
			return vocAnalysisDateStatement == null ? null : vocAnalysisDateStatement.Text;
		}

		public int RadioButtonCountInSection(string section)
		{
			var xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='radio']";
			var radios = containerElement.FindElements(By.XPath(xpath), 2);
			return radios?.Count ?? 0;
		}

		public List<string> RadioButtonsInSection(string section)
		{
			var xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='radio']//span";
			var radios = containerElement.FindElements(By.XPath(xpath), 2);
			if (radios.Count == 0)
			{
				Report.Failure("There were no radios showing in section: " + section);
				return new List<string>();
			}
			return radios.Select(x => x.Text).ToList();
		}

		// Currently deals with select (option) and input (radio)
		public List<string> GetAllOptionsForSection(string section)
		{
			Delay.Seconds(1);
			Report.Info("Beginning get all options for section.");
			var optionsText = new List<string>();
			var matchingElements = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[contains(@class,'form-group') and .//label[contains(text(),'" + section + "')]]//*[name()='input' or name()='select']"), 2);
			if (matchingElements.Count == 1 && matchingElements.FirstOrDefault().TagName.ToLower() == "select")
			{
				optionsText = matchingElements.FirstOrDefault().FindElements(By.XPath(@"./option")).Select(x => x.Text).Where(x => x != "Choose...").ToList();
				// Occasionally needs some time to refresh the options in the drop down depending on the previous selection
				for (int i = 0; i < 5; i++)
				{
					optionsText = matchingElements.FirstOrDefault().FindElements(By.XPath(@"./option")).Select(x => x.Text).Where(x => x != "Choose...").ToList();
					if (optionsText.Count > 0)
					{
						break;
					}
					Delay.Seconds(1);
				}
				return optionsText;
			}
			Report.Info("Found " + matchingElements.Count.ToString());
			optionsText = matchingElements.Select(x => x.FindElement(By.XPath(@"./following-sibling::span"), 2).Text).ToList();
			Report.Info("Returning: " + string.Join(",", optionsText));
			return optionsText;
		}

		public List<string> RegulatoryInformationLabelLinks()
		{
			var linksText = new List<string>();
			linksText = containerElement.FindElements(By.XPath(".//a[@class='link-publication']")).Select(x => x.Text).ToList();
			return linksText;
		}

		public bool AddDocument(string documentName, string language)
		{
			var rowContainer = containerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			if (rowContainer == null)
			{
				return false;
			}

			//rowContainer.FindElement(By.XPath(".//input[@type='search']"), 2).TryClick();
			var selectEl = rowContainer.FindElement(By.XPath(".//div[@class='add-language']//select"), 10);
			selectEl.Select(language);

			return selectEl.SelectedOption() == language;

		}

		public List<string> GetSelectedLanguagesForDocument(string documentName)
		{
			var rowContainer = containerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			int i = 0;
			while (i < 10 && rowContainer == null)
			{
				Delay.Seconds(Delay.SpeedFactor * 2);
				rowContainer = containerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			}

			if (rowContainer == null)
			{
				return null;
			}

			var el = rowContainer.FindElements(By.XPath(".//span[@class='selection']//li[not(.//input)]"), 2);

			return el.Select(x => x.GetElementText().Replace("×", "").Trim()).ToList();
		}

		public bool TopEPARowIsEmpty()
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				return false;
			}
			var RowInputs = EPATable.FindElements(By.XPath(@".//input[@class='form-control']"));
			if (RowInputs.Count == 0)
			{
				Report.Failure("There were no EPA registration rows visible on the Pesticide Details page");
				return false;
			}
			if (RowInputs[0].GetAttribute("value") == "")
			{
				return true;
			}
			return false;
		}

		public bool EnterEPATopRow(string epaNumber)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				Report.Screenshot();
				return false;
			}

			var RowInputs = EPATable.FindElements(By.XPath(@".//input[@class='form-control']"));
			if (RowInputs.Count == 0)
			{
				Report.Failure("There were no EPA registration rows visible on the Pesticide Details page");
				Report.Screenshot();
				return false;
			}
			RowInputs[0].SendKeys(epaNumber);
			Delay.Seconds(1);
			return RowInputs[0].GetValue().Contains(epaNumber);
		}

		public bool RemoveEPATopRow()
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var removeEls = EPATable.FindElements(By.XPath(@".//a[@class='close']"), 2);
			if (removeEls.Count == 0)
			{
				Report.Failure("There were no EPA registration rows visible on the Pesticide Details page");
				Report.Screenshot();
				return false;
			}
			return removeEls[0].TryClick();
		}

		public bool AddEPARow()
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var NewRowButton = EPATable.FindElement(By.XPath(@".//button[@data-bind='click: addRow']"), 2);
			if (NewRowButton == null)
			{
				Report.Failure("The New Row Button is not visible on the EPA registration page");
				Report.Screenshot();
				return false;
			}
			Report.Info("Adding a new row to the EPA Registration table on the Pesticide Details - US page");
			return NewRowButton.TryClick();
		}

		public int CountPesticideRegRows()
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return 0;
			}
			var RowInputs = EPATable.FindElements(By.XPath(@".//ancestor::td[contains(@class,'col-xs')]/input"), 2);
			if (RowInputs.Count == 0)
			{
				Report.Failure("There were no State Pesticide Registration rows visible on the Pesticide State Registration Details page");
				Report.Screenshot();
				return 0;
			}
			Report.Info("There are " + RowInputs.Count + " State Pesticide Registration rows showing");
			return RowInputs.Count;
		}

		public bool AddSuffixToPesticideRegistrationNumRow(int row)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var RowInputs = EPATable.FindElements(By.XPath(@".//ancestor::td[contains(@class,'col-xs-4')]/input"), 2);
			if (RowInputs.Count == 0)
			{
				Report.Failure("There were no State Pesticide Registration rows visible on the Pesticide State Registration Details page");
				Report.Screenshot();
				return false;
			}
			var currentRow = RowInputs[row];
			currentRow.SendKeys("-edited");
			Delay.Seconds(1);
			return currentRow.GetValue().EndsWith("-edited");
		}

		public bool CheckPesticideRegNumIsEdited(int row)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var RowInputs = EPATable.FindElements(By.XPath(@".//ancestor::td[contains(@class,'col-xs-4')]/input"), 2);
			if (RowInputs.Count == 0)
			{
				Report.Failure("There were no State Pesticide Registration rows visible on the Pesticide State Registration Details page");
				Report.Screenshot();
				return false;
			}
			var currentRow = RowInputs[row];
			currentRow.ScrollElementIntoView();
			var rowText = currentRow.GetAttribute("value");
			Delay.Seconds(1);
			return rowText.EndsWith("-edited");
		}

		public bool ClickEPAKellyServicesLink()
		{
			var links = containerElement.FindElements(By.XPath(
				@".//div[@class='panel-heading']/following-sibling::div//span[contains(text(),'Update WERCSmart data with EPA data through Kelly Services')]"));
			if (links == null)
			{
				return false;
			}
			if (links.Count == 0)
			{
				return false;
			}
			bool clicked = links.FirstOrDefault().TryClick();
			GeneralUtilities.Wait_for_load_finish();
			RefreshContainer();
			return clicked;
		}

		public bool ExpirationDateRowHasData(int row)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var ExpirationDateInputs = EPATable.FindElements(By.XPath(@".//ancestor::td[contains(@class,'col-xs-2')]/div/input"));
			if (ExpirationDateInputs.Count == 0)
			{
				Report.Failure("There were no Pesticide State Registration Expiration Date rows visible");
				Report.Screenshot();
				return false;
			}
			var currentInput = ExpirationDateInputs[row];
			var expirationDateText = currentInput.GetAttribute("value");
			return expirationDateText != "";
		}

		public bool KellyDataIsTickedAtRow(int index)
		{
			RefreshContainer();
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var stateRow = EPATable.FindElements(By.XPath(@".//tr[contains(@data-bind, 'css')]"), 2)[index];
			var kellyDataCheck = stateRow.FindElement(By.XPath(@".//td[5]/div[@class='fa fa-check' and not(contains(@style, 'display: none'))]"), 2);
			if (kellyDataCheck == null)
			{
				return false;
			}
			kellyDataCheck.ScrollElementIntoView();
			return true;
		}

		public bool EditPesticideRegExpirationDate(string date, string state)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var expirationDateInputs = EPATable.FindElements(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/div/input[@type='text']"), 2);
			if (expirationDateInputs.Count == 0)
			{
				Report.Failure("Failed to find a match on the State text: '" + state + "'");
				Report.Screenshot();
				return false;
			}
			expirationDateInputs.FirstOrDefault().Clear();
			expirationDateInputs.FirstOrDefault().SendKeys(date);
			expirationDateInputs.FirstOrDefault().SendKeys(Keys.Enter);
			expirationDateInputs.FirstOrDefault().ScrollElementIntoView();
			Delay.Seconds(1);
			return expirationDateInputs.FirstOrDefault().GetValue() == date;
		}

		public bool KellyDataIsTickedForState(string state)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var kellyDataTick = EPATable.FindElement(By.XPath(
				@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/ancestor::tr/td/div[@class='fa fa-check' and not(contains(@style, 'display: none'))]"), 2);
			if (kellyDataTick != null)
			{
				kellyDataTick.ScrollElementIntoView();
				return true;
			}
			return false;
		}

		public string GetPesticideRegExpirationDate(string state)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return null;
			}
			var expirationDateInput = EPATable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/div/input[@type='text']"), 2);
			if (expirationDateInput == null)
			{
				Report.Failure("Failed to find a match on the State text: '" + state + "'");
				Report.Screenshot();
				return null;
			}
			expirationDateInput.ScrollElementIntoView();
			return expirationDateInput.GetValue();
		}

		public string GetPesticideRegKellyExpirationDate(string state)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return null;
			}
			var kellyExpirationDateInput = EPATable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/following-sibling::td/label"), 2);
			if (kellyExpirationDateInput == null)
			{
				Report.Failure("Failed to find a match on the State text: '" + state + "'");
				Report.Screenshot();
				return null;
			}
			return kellyExpirationDateInput.GetValue();
		}

		//public string GetEPATableError()
		//{
		//	return containerElement.FindElement(By.XPath(@".//div[@class ='panel-heading']/following-sibling::table/following-sibling::div/p[@class='form-error']/span"), 15)?.Text;
		//}

		public bool EPASelectExpirationDateFromCalendar(string state, DateTime date)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var calendarButton = EPATable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td//span[@class='input-group-addon']"), 2);
			if (!calendarButton.TryClick())
			{
				var inputEl = EPATable.FindElement(By.XPath(@"..//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td//input"), 2);
				if (!inputEl.TryClick())
				{
					Report.Failure("Could not click calender button for state: " + state);
					Report.Screenshot();
					return false;
				}
			}
			var activeDate = EPACalednarActiveDate();
			if (activeDate == null)
			{
				Report.Failure("Unable to locate the active date (Month Year) in the EPA calendar pop up for state: " + state);
				Report.Screenshot();
				return false;
			}
			var activeYear = int.Parse(activeDate[1]);
			var activeMonth = DateTime.ParseExact(activeDate[0], "MMMM", CultureInfo.CurrentCulture).Month;
			// Fail test if target date preceeds the default Month Year on the calendar
			if (date.Year < activeYear || date.Year == activeYear && date.Month < activeMonth)
			{
				Report.Failure("Target date must be equal or later than the current active date on the calendar");
				Report.Screenshot();
				return false;
			}
			// Perform loop until target year = active year and target month = active month
			while (date.Year > activeYear || date.Year == activeYear && date.Month > activeMonth)
			{
				// Click next month
				SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]//th[@class='next']"), 2).TryClick();
				activeDate = EPACalednarActiveDate();
				activeYear = int.Parse(activeDate[1]);
				activeMonth = DateTime.ParseExact(activeDate[0], "MMMM", CultureInfo.CurrentCulture).Month;
			}
			// Select day
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]//td[@class='day' and text()='" + date.Day + "']"), 2).TryClick();
		}

		public string[] EPACalednarActiveDate()
		{
			var calendarTable = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]"), 2);
			var datePicker = calendarTable?.FindElement(By.XPath(".//th[@class='datepicker-switch']"), 2);
			return datePicker?.Text.Split(' ');
		}

		public IWebElement StateEPARow(string state)
		{
			return this.EPATable().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
		}
		public string GetEPATableRowClassColour(string state)
		{
			var epaRow = this.EPATable().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
			if (epaRow == null)
			{
				Report.Failure("Unable to locate EPA table row for state: " + state);
				return null;
			}
			// Hack for screenshots - Don't scroll to row if we're looking at the top 4 states, because they are obscured by the banner
			if (new[] { "AK", "AL", "AR", "AZ" }.All(x => x != state))
			{
				epaRow.ScrollElementIntoView();
			}
			var colourCode = epaRow.GetAttribute("class");
			return colourCode?.Replace("rpds-", "");
		}

		public string GetEPATableRowBackgroundHex(string state)
		{
			var epaRow = this.EPATable().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
			if (epaRow == null)
			{
				Report.Failure("Unable to locate EPA table row for state: " + state);
				return null;
			}
			return epaRow.GetCssValue("background-color");
		}

		/// <summary>
		/// Set the option 'Pubic name' for named ingredient. Enter overload for a specific public name, otherwise the first name is selected
		/// </summary>
		public bool SelectIngredientPublicName(string chemicalName)
		{
			var row = this.IngredientRow(chemicalName);
			if (row == null)
			{
				Report.Info("The ingredient row was not found by chemical name: " + chemicalName);
				Report.Screenshot();
				return false;
			}
			var publicNameText = row.FindElements(By.XPath(".//td[contains(@class,'inci-name')]//option"), 2)?.Select(x => x.Text).Where(x => x != "Choose...").ToList();
			if (publicNameText == null)
			{
				return false;
			}
			Report.Info("Getting the first public name from options");
			var publicName = publicNameText[0];
			var publicNameOption = this.IngredientRow(chemicalName)?.FindElement(By.XPath(".//td[contains(@class,'inci-name')]//select[@class='form-control']"), 2);
			if (publicNameOption == null)
			{
				Report.Info("The ingredient row was not found by chemical name: " + chemicalName);
				Report.Screenshot();
				return false;
			}
			publicNameOption.Select(publicName);
			if (publicNameOption.SelectedOption() == publicName)
			{
				return true;
			}
			Report.Failure("The ingredient row for: " + chemicalName + " was found but the Public Name option was not changed");
			Report.Screenshot();
			return false;
		}

		/// <summary>
		/// Set the option 'Pubic name' for named ingredient. Enter overload for a specific public name, otherwise the first name is selected
		/// </summary>
		public bool SelectIngredientPublicName(string chemicalName, string publicName)
		{
			var publicNameOption = this.IngredientRow(chemicalName)?.FindElement(By.XPath(".//td[contains(@class,'inci-name')]//select[@class='form-control']"), 2);
			if (publicNameOption == null)
			{
				Report.Info("The ingredient row was not found by chemical name: " + chemicalName);
				Report.Screenshot();
				return false;
			}
			publicNameOption.Select(publicName);
			if (publicNameOption.SelectedOption() == publicName)
			{
				return true;
			}
			Report.Failure("The ingredient row for: " + chemicalName + " was found but the Public Name option was not changed");
			Report.Screenshot();
			return false;
		}

		public IWebElement IngredientRow(string chemicalName)
		{
			var rows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2);
			var matchingRow = rows.FirstOrDefault(x => x.FindElement(By.XPath(".//div[@class = 'chemical-name']"), 2).GetValue().Trim() == chemicalName);
			return matchingRow;
		}

		public int IngredientRowCount()
		{
			var rows = containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//td[@class='component-name']]"), 2);
			return rows.Count;
		}

		public bool ClickIngredientCheckbox(string input, string chemicalName)
		{
			var xPath = "";
			switch (input.ToLower())
			{
				case "publicly disclosed":
					xPath = ".//input[@class='public_disclosure']";
					break;
				case "trade secret":
					xPath = ".//input[@class='trade_secret']";
					break;
				default:
					Report.Info("invalid 'input' parameter was used. Valid inputs: 'Publicly Disclosed' or 'Trade Secret'");
					return false;
			}
			var inputEl = this.IngredientRow(chemicalName)?.FindElement(By.XPath(xPath));
			if (inputEl == null)
			{
				Report.Failure("Could not find the checkbox for input: " + input);
				Report.Screenshot();
				return false;
			}
			var ticked = inputEl.Checked();
			if (inputEl.TryClick())
			{
				if (inputEl.Checked() == ticked)
				{
					Report.Info($"Clicked the {input} checkbox but it was not successfully set to: {!ticked}");
					Report.Screenshot();
					return false;
				}
				Report.Info($"The {input} checkbox has been {(ticked ? "unchecked" : "checked")}");
				return true;
			}
			return false;
		}

		public bool SetIngredientPubliclyDisclosed(string chemicalName, bool checked_)
		{
			var publiclyDisclosedInput = IngredientRow(chemicalName).FindElement(By.XPath(".//input[@class='public_disclosure']"));
			if (publiclyDisclosedInput == null || !publiclyDisclosedInput.Displayed)
			{
				Report.Failure("The Publicly Disclosed checkbox was not displayed");
				Report.Screenshot();
				return false;
			}
			if (publiclyDisclosedInput.Checked() == checked_)
			{
				Report.Info("Publicly Disclosed checkbox was already in the required state");
				return true;
			}
			return publiclyDisclosedInput.TryCheck(checked_);
		}

		public bool SetIngredientTradeSecret(string chemicalName, bool checkedTrueFalse)
		{
			var tradeSecretInput = IngredientRow(chemicalName).FindElement(By.XPath(".//input[@class='trade_secret']"));
			if (tradeSecretInput == null)
			{
				Report.Failure("Could not find the Trade Secret checkbox");
				Report.Screenshot();
				return false;
			}
			var ticked = tradeSecretInput.Checked();

			if (ticked == checkedTrueFalse)
			{
				Report.Info("Trade Secret checkbox was already in the required state");
				return true;
			}
			else
			{
				tradeSecretInput.TryClick();

			}
			ticked = tradeSecretInput.Checked();

			if (ticked == checkedTrueFalse)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		// Checks the running total of publically disclosed ingredients (eg. "1 / 3")
		public bool PubliclyDisclosedTotalIsCorrect(string total)
		{
			try
			{
				var totalExpected = IngredientRowCount().ToString();
				var pubDisExpected = total;
				var pubDisSummary = containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span")).Text;
				var summaryActual = pubDisSummary.Split(new[] { " / " }, StringSplitOptions.None);
				Report.Info("Public Disclosure Total was showing as: " + summaryActual[0] + " out of a total " + summaryActual[1] + " ingredients");
				if (summaryActual[0] == pubDisExpected && summaryActual[1] == totalExpected)
				{
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string TransparencyScoreNumerator()
		{
			Report.Info("Beginning get Transparency score numerator");
			var pubDisSummaryspan = containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2);
			if (pubDisSummaryspan == null)
			{
				pubDisSummaryspan = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@id='transparency-score']/span"), 2);
				if (pubDisSummaryspan == null)
				{
					Report.Error("The transparency score is not found");
					return null;
				}
			}

			var pubDisSummary = pubDisSummaryspan.GetValue();
			var pattern = @"([0123456789\.]*)\s\/\s([0123456789\.]*)";
			var regMatch = Regex.Match(pubDisSummary, pattern);
			if (!regMatch.Success || regMatch.Groups.Count != 3)
			{
				return null;
			}
			return regMatch.Groups[1].ToString().Trim();
		}

		public string TransparencyScoreDenominator()
		{
			try
			{
				Report.Info("Beginning get Transparency score denominator");
				var pubDisSummary = containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2).Text;
				if (pubDisSummary == null)
				{
					pubDisSummary = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@id='transparency-score']/span"), 2).Text;
				}
				var pattern = @"([0123456789\.]*)\s\/\s([0123456789\.]*)";
				var regMatch = Regex.Match(pubDisSummary, pattern);
				if (!regMatch.Success || regMatch.Groups.Count != 3)
				{
					return null;
				}
				return regMatch.Groups[2].ToString();
			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return null;
			}

		}

		public string TransparencyScoreStatus()
		{
			var transparencyScoreEl = containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2);
			return transparencyScoreEl?.GetAttribute("class").Replace("label label-", "");
		}

		public bool ClickUseMyIngredients()
		{
			return containerElement.FindElement(By.XPath(".//button[starts-with(@data-bind,'click: openMyIngredients')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool ClickAddARetailers()
		{
			try
			{
				var button = containerElement.FindElement(By.XPath(".//a[@class='btn btn-success' and text()='Add Retailers']"));
				return button.TryClick();
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public List<string> SelectedRetailers()
		{
			try
			{
				var selectedRetailers = new List<string>();
				var selectedRetailersName = containerElement.FindElements(By.XPath(".//div[@class='grid-container']//tr[parent::tbody[@data-bind='foreach: field.field']]/td[@class='col-xs-3']"));
				foreach (var row in selectedRetailersName)
				{
					selectedRetailers.Add(row.Text);
				}
				return selectedRetailers;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public bool EnterAdditionalRequirement(string retailerName, string valueToEnter)
		{
			var selectedRetailersNames = containerElement.FindElements(By.XPath(".//div[@class='grid-container']//tr[parent::tbody[@data-bind='foreach: field.field']]/td[@class='col-xs-3']"));
			var matchingRetailer = selectedRetailersNames.FirstOrDefault(x => x.GetValue().Trim().ToLower() == retailerName.ToLower());
			if (matchingRetailer == null)
			{
				Report.Info("No matching retailer was found in selected retailers: " + retailerName);
				return false;
			}

			var additionalRequirementInput = matchingRetailer.FindElement(By.XPath("..//input[@type='text']"), 2);
			if (additionalRequirementInput == null)
			{
				Report.Info("No input was found for retailer: " + retailerName);
				return false;
			}

			additionalRequirementInput.EnterText(valueToEnter);

			return additionalRequirementInput.GetValue() == valueToEnter;

		}

		public string VOCContentInGPerL()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and starts-with(text(), 'VOC content in g/L')]/b")).Text;
		}

		public List<string> AllAdditionalStatements()
		{
			var xPath = ".//div[@data-bind='html: field.field' and parent::div[@class='col-sm-12']]";
			var statements = containerElement.FindElements(By.XPath(xPath), 2);
			if (statements.IsNullOrEmpty())
			{
				return new List<string>();
			}
			return statements.Select(x => x.Text.Trim()).ToList();
		}

		public List<string> AllAdditionalStatementParagraphs()
		{
			var xPath = @".//div[@data-bind='html: field.field' and parent::div[@class='col-sm-12']]/p";
			var paragraphs = containerElement.FindElements(By.XPath(xPath), 2);
			if (paragraphs.IsNullOrEmpty())
			{
				return new List<string>();
			}
			return paragraphs.Select(x => x.Text.Trim()).ToList();
		}

		// Click an individual checkbox by section and value. (check if unchecked, uncheck if checked). Report the checked state before and after.
		public bool ClickCheckbox(string section, string value)
		{
			var xPath = "//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),'" + section + "')]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox']";
			var box = containerElement.FindElement(By.XPath(xPath), 2);
			if (box.Checked())
			{
				Report.Info(string.Format("The checkbox for section '{0}' and option '{1}' is checked. It is now being unchecked", section, value));
				return box.TryClick();
			}
			Report.Info(string.Format("The checkbox for section '{0}' and option '{1}' is unchecked. It is now being checked", section, value));
			return box.TryClick();
		}

		// If a Shared Step does not specify a compulsory field input, fetch that section name so we can select an option and continue test after reporting the fail
		public string SectionWithRequiredFieldError()
		{
			try
			{
				var xPath = "//div[.//p[@class='form-error' and .//span[contains(text(),'This is a required field.')]] and @class='form-group has-feedback has-error']//label[@class='control-label']";
				var section = containerElement.FindElement(By.XPath(xPath), 2);
				section.ScrollElementIntoView();
				return section.Text;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public IWebElement EPATable()
		{
			return containerElement.FindElement(By.XPath(@".//div[@class ='panel-heading']/following-sibling::table"), 10);
		}

		public List<EPARegistration> EPARegistrationData {
			get
			{
				List<EPARegistration> rEPA = new List<EPARegistration>();
				var EPATable = this.EPATable();
				if (EPATable == null)
				{
					Report.Failure("The EPA Table was not visible on the page");
					Report.Screenshot();
					return null;
				}
				var regNo = "";
				var activeIngredient = "";
				var percentActiveIngredient = "";
				bool activeIngredientEditable;
				bool percentActiveIngredientEditable;
				int row;
				var EPARows = EPATable.FindElements(By.XPath(@".//tr[@class='rpds-rowcolor-0']"), 2);
				int i = 1;
				foreach (var EPARow in EPARows)
				{
					regNo = EPARow.FindElement(By.XPath("./td[@class='col-xs-5']/input"), 2).GetValue();
					activeIngredient = EPARow.FindElement(By.XPath("./td[@class='col-xs-3'][1]/div")).GetValue();
					percentActiveIngredient = EPARow.FindElement(By.XPath("./td[@class='col-xs-3'][2]/div")).GetValue();
					activeIngredientEditable = EPARow.FindElement(By.XPath("./td[@class='col-xs-3'][1]/input"), 2) != null;
					percentActiveIngredientEditable = EPARow.FindElement(By.XPath("./td[@class='col-xs-3'][2]/input"), 2) != null;
					row = i;
					rEPA.Add(new EPARegistration() {
						ActiveIngredient = activeIngredient,
						EPANumber = regNo,
						Row = row,
						PercentActiveIngredient =
							percentActiveIngredient,
						ActiveIngredientEditable = activeIngredientEditable,
						PercentActiveIngredientEditable = percentActiveIngredientEditable
					});
					i++;
				}
				return rEPA;
			}
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					var epaRegistration = value[i];
					AddEPARow();
					EnterEPATopRow(epaRegistration.EPANumber);
					epaRegistration.Row = i + 1;
				}
			}
		}

		public List<StatePesticideRegistration> GetStatePesticideRegistrationDetails()
		{
			List<StatePesticideRegistration> AllResults = new List<StatePesticideRegistration>();
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				Report.Screenshot();
				return AllResults;
			}
			var Rows = EPATable.FindElements(By.XPath(".//tbody/tr")).ToList();
			Report.Info("Getting state data for: " + Rows.Count + " rows");
			foreach (var thisRow in Rows)
			{
				var State = thisRow.FindElement(By.XPath(".//td[2]//div")).Text;
				var ExpirationDate = thisRow.FindElement(By.XPath(".//td[3]//input")).GetValue();
				var RegNo = thisRow.FindElement(By.XPath(".//td[1]//input"));
				var RegistrationNumber = RegNo.Text;
				if (RegistrationNumber.Length == 0)
				{
					RegistrationNumber = RegNo.GetAttribute("placeholder");
				}

				var KellyDate = "";
				if (thisRow.FindElement(By.XPath(".//td[4]//label")) != null)
				{
					KellyDate = thisRow.FindElement(By.XPath(".//td[4]//label")).Text;
				}

				var IsKellyData = false;
				if (thisRow.FindElements(By.XPath(".//td[5]//div")) != null)
				{
					IsKellyData = thisRow.FindElements(By.XPath(".//td[5]//div")).Count == 1;
				}

				AllResults.Add(new StatePesticideRegistration() {
					State = State,
					ExpirationDate = ExpirationDate,
					RegistrationNumber = RegistrationNumber,
					ExpirationDateByKelly = KellyDate,
					IsKellyData = IsKellyData
				});
			}
			return AllResults;
		}

		public string EPATableHeading()
		{
			var heading = containerElement.FindElement(By.XPath(@".//div[@class ='panel-heading' and ancestor::div[@class='form-group has-success']]/div"), 10);
			if (heading == null)
			{
				Report.Failure("Could not find EPA table header");
				return null;
			}
			return heading.Text;
		}

		public List<string> EPATableColumnHeadings()
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				return new List<string>();
			}
			var rList = new List<string>();
			var columnHeaders = epaTable.FindElements(By.XPath(".//th"), 2).ToList();
			columnHeaders.ForEach(x => rList.Add(x.Text));
			return rList;
			//return epaTable.FindElements(By.XPath(".//th"), 2).ToList().Select(x => x.GetAttribute("value")).ToList();
		}
		public bool SelectRetailer(string retailerName)
		{
			var xPath = @".//input[@type='checkbox' and parent::td/following-sibling::td[text() =""" + retailerName + @"""]]";
			var box = containerElement.FindElement(By.XPath(xPath), 2);
			return box.TryClick() && box.Checked();
		}

		public bool DeleteSelectedRetailers()
		{
			var xPath = ".//a[@class='btn delete-selected']/i";
			return containerElement.FindElement(By.XPath(xPath), 2).TryClick();
		}

		/// <summary>
		/// New Product - The Product. Return name and ID of all options under Product Line or Brand
		/// </summary>
		//public List<string> AllProductLineOrBrandOptions()
		//{
		//	var el = containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
		//	if (el == null)
		//	{
		//		Report.Failure("Could not locate the Product Line or Brand option");
		//		return new List<string>();
		//	}
		//	return el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "Choose...").ToList();
		//}

		/// <summary>
		/// New Product - The Product. Return name and ID of all options under Product Line or Brand
		/// </summary>
		public List<MyBrands.Brand> AllProductLineOrBrandOptions()
		{
			var rList = new List<MyBrands.Brand>();
			var el = containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
			if (el == null)
			{
				Report.Failure("Could not locate the Product Line or Brand option");
				return null;
			}
			var options = el.FindElements(By.XPath("./option"), 2).Where(x => x.Text != "Choose...").ToList();
			foreach (var option in options)
			{
				var brand = new MyBrands.Brand { ID = option.GetAttribute("value"), Name = option.Text };
				rList.Add(brand);
			}
			return rList;
		}

		public bool SetSubOptionInSection(string section, string subsection, string value)
		{
			var xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			var el = this.containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}
			Report.Info("Entering value of: '" + value + "' in section: '" + section + "'");

			if (el.GetAttribute("type") == "text")
			{
				el.EnterText(value);
				return el.GetValue() == value;
			}

			if (el.TagName.ToLower() == "select")
			{
				int i = 0;
				while (i < 10)
				{
					try
					{
						el.Select(value);
						return el.SelectedOption() == value;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}
				}

				return el.SelectedOption() == value;
			}

			if (el.GetAttribute("type") == "checkbox")
			{
				el.TryCheck(true);
				return el.Checked();
			}

			return el.TryClick();
		}

		public bool Ingredients_ClickRegulated(string ingredientName)
		{
			var row = IngredientRow(ingredientName);
			return row.FindElement(By.XPath(".//a[contains(@data-bind,'openRegulation')]"), 2).TryClick();
		}

		public bool IngredientOrderbY(string orderBy)
		{
			switch (orderBy.ToLower())
			{
				case "chemical name":
					return containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'ChemicalName')]"))
						.TryClick();
				case "cas number":
					return containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'CasNumber')]"))
						.TryClick();
				case "percent":
					return containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'Percent')]"))
						.TryClick();
				case "publicly disclosed":
					return containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'PubliclyDisclosed')]"))
						.TryClick();
				case "trade secret":
					return containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'TradeSecret')]"))
						.TryClick();
				case "public name":
					return containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'PublicName')]"))
						.TryClick();
				default:
					throw new Exception("Please provide header title");
			}

		}

		public List<Ingredient> GetIngredients()
		{
			List<Ingredient> Ingredients = new List<Ingredient>();
			var rows = containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//td[@class='component-name']]"), 2);
			foreach (var thisRow in rows)
			{
				Ingredient thisIngredient = new Ingredient();
				thisIngredient.ComponentName =
					thisRow.FindElement(By.XPath(".//td[@class='component-name']//div[@class='chemical-name']")).Text;
				thisIngredient.CASNumber = thisRow.FindElement(By.XPath(".//div[@class = 'cas-number']/small"), 2)?.Text;
				thisIngredient.Percent =
					thisRow.FindElement(By.XPath(".//td[@class='percent-comp']//input")).GetAttribute("value");
				thisIngredient.PublicallyDisclosed =
					thisRow.FindElement(By.XPath(".//td[@class='transparency']//input")).Checked();
				thisIngredient.TradeSecret =
					thisRow.FindElement(By.XPath(".//td[@class='trade-secret']//input")).Checked();
				thisIngredient.PublicName =
					thisRow.FindElement(By.XPath(".//td[@class='inci-name']//select")).SelectedOption();
				thisIngredient.TradeSecretEnabled = thisRow.FindElement(By.XPath(".//td[@class='trade-secret']//input")).Enabled;
				thisIngredient.PublicDisclosureEnabled = thisRow.FindElement(By.XPath(".//td[@class='transparency']//input")).Enabled;
				thisIngredient.PublicNameEnabled =
					thisRow.FindElement(By.XPath(".//td[@class='inci-name']//select")).Enabled;
				thisIngredient.Selected = thisRow.FindElement(By.XPath("./td[position()=1]/input[@type='checkbox']"), 2).Selected;
				Ingredients.Add(thisIngredient);
			}
			return Ingredients;
		}

		public bool ClickSelectIngredient(string name)
		{
			var row = containerElement.FindElement(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[@class='chemical-name' and contains(text(), '" + name + "')]]"), 2);
			if (row == null)
			{
				return false;
			}
			return row.FindElement(By.XPath("./td/input[@type='checkbox']"), 2).TryClick();
		}

		public List<string> GetIngredientPublicNameOptions(string chemicalName)
		{
			return IngredientRow(chemicalName).FindElements(By.XPath(".//select/option")).Select(x => x.Text).ToList();
		}

		public string GetPublicNameErrorMessage(string ingredient)
		{
			try
			{
				return IngredientRow(ingredient)
					.FindElement(By.XPath(".//td[@class='inci-name']//p[@class='form-error']/span")).Text;
			}
			catch (Exception e)
			{
				return "";
			}
		}

		public List<string> GetIngredientTableColumnHeaders()
		{
			return containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//thead//th"), 2).Select(x => x.Text).ToList();
		}

		//checkbox, textbox, select
		public bool IngredientTableCheckInputByColumnTitle(string columnTitle, string expectedInput)
		{
			var firstRow = containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2).FirstOrDefault();
			var cell = firstRow.FindElements(By.XPath(".//td")).FirstOrDefault();
			switch (columnTitle)
			{
				case "Percent":
					cell = firstRow.FindElement(By.XPath(".//td[@class='percent-comp']"));
					break;
				case "Publicly Disclosed?":
					cell = firstRow.FindElement(By.XPath(".//td[@class='transparency']"));
					break;
				case "Trade Secret?":
					cell = firstRow.FindElement(By.XPath(".//td[@class='trade-secret']"));
					break;
				case "Public Name":
					cell = firstRow.FindElement(By.XPath(".//td[@class='inci-name']"));
					break;
				default:
					throw new Exception("Please provide viable column names");
			}
			switch (expectedInput)
			{
				case "checkbox":
					return cell.FindElements(By.XPath(".//input[@type='checkbox']")).Count > 0;
				case "textbox":
					return cell.FindElements(By.XPath(".//input[@type='text']")).Count > 0;
				case "select":
					return cell.FindElements(By.XPath(".//select")).Count > 0;
				default:
					throw new Exception("Please provide suitable expected input");
			}
		}

		public Alert GetAlert()
		{
			Alert thisAlert = new Alert();

			thisAlert.Title = containerElement
				.FindElement(By.XPath(".//div[contains(@class,'alert')]/p[contains(@class, 'text-danger')]/strong"))
				.Text;
			thisAlert.SubTitle = containerElement
				.FindElement(By.XPath(".//div[contains(@class,'alert')]/p[contains(@class, 'text-danger')]")).GetInnerText();

			thisAlert.Text = containerElement
				.FindElement(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p"))
				.Text;

			thisAlert.Links = containerElement
				.FindElements(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p/a"))
				.Select(x => new Mailosaur.Link() {
					Href = x.GetAttribute("href"),
					Text = x.Text
				}).ToList();

			return thisAlert;
		}

		public bool ClickAlertLink(string linkText)
		{
			return containerElement
				.FindElements(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p/a"))
				.FirstOrDefault(x => x.Text == linkText).TryClick();
		}

		public void MoveToLabel(string section)
		{
			try
			{
				var xPath = @"(//label[starts-with(text(),""" + section + @""")]))";

				SeleniumBrowser.WebBrowser.FindElement(By.XPath(xPath), 2).TryClick();
			}
			catch (Exception e)
			{

			}
		}

		public bool SectionLogoDisplayed(string logo, int secondsToWait = 30)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				RefreshContainer();
				var headerLogo = containerElement.FindElements(By.XPath(".//div[@class='panel-heading']//h3/img"))
					.FirstOrDefault(x => x.GetAttribute("src").ToLower().Contains(logo.ToLower()));
				if (headerLogo != null)
				{
					return true;
				}
				Delay.Seconds(1);
				counter++;
			}
			return false;
		}

		public string ActivePanelHeading()
		{
			return containerElement.FindElement(By.XPath(".//div[@class='panel-heading']//h3"), 2).Text;
		}

		public bool ClickSelectAllIngredients()
		{
			return this.containerElement.FindElement(By.XPath(".//th[contains(text(), 'Select All')]/input[@type='checkbox']"), 2).TryClick();
		}

		public bool SelectAllIngredientsChecked()
		{
			return this.containerElement.FindElement(By.XPath(".//th[contains(text(), 'Select All')]/input[@type='checkbox']"), 2).Checked();
		}

		public bool DeleteIngredientsDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//td[@class='remove']/button[contains(text(), 'Delete')]"), 2);
			return el != null && el.Displayed;
		}
		public bool ClickDeleteIngredients()
		{
			var el = this.containerElement.FindElement(By.XPath(".//td[@class='remove']/button[contains(text(), 'Delete')]"), 2);
			return el.TryClick();
		}
	}

	public class ProductInformation
	{
		public string Name { get; set; }
		public string Id { get; set; }

		public List<Ingredient> ListOfIngredients { get; set; }
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
		public string PackageType { get; set; } = "";

	}

	public class Ingredient
	{
		public string ComponentName { get; set; }
		public string CASNumber { get; set; }
		public string Percent { get; set; }
		public bool PublicallyDisclosed { get; set; }
		public bool TradeSecret { get; set; }
		public string PublicName { get; set; }
		public bool TradeSecretEnabled { get; set; }
		public bool PublicDisclosureEnabled { get; set; }
		public bool PublicNameEnabled { get; set; }
		public bool Selected { get; set; }
	}

	public class VocLimits
	{
		public string Use { get; set; }
		public string VocComplianceLimit { get; set; }
		public string Regulation { get; set; }
	}

	public class VocLimitsWithUnits
	{
		public string Use { get; set; }
		public string VocComplianceLimit { get; set; }
		public string Units { get; set; }
		public string Regulation { get; set; }
	}

	public class VocPercentForStates
	{
		public string State { get; set; }
		public string Regulation { get; set; }
		public string VocValue { get; set; }
		public string StateVocThreshold { get; set; }
		public string Message { get; set; }
	}

	public class EPARegistration
	{
		public string EPANumber { get; set; }
		public string ActiveIngredient { get; set; }
		public string PercentActiveIngredient { get; set; }
		public bool ActiveIngredientEditable { get; set; }
		public bool PercentActiveIngredientEditable { get; set; }

		public int Row { get; set; }
		public bool ClickRemove()
		{
			var epaTable = new NewProduct().EPATable();
			if (epaTable == null)
			{
				return false;
			}
			var removeEls = epaTable.FindElements(By.XPath("//a[@class = 'close']"), 2);
			if (removeEls.Count < Row)
			{
				return false;
			}
			return removeEls[Row - 1].TryClick();
		}
	}

	public class Alert
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string Text { get; set; }

		public List<Mailosaur.Link> Links { get; set; }
	}

	public class StatePesticideRegistration
	{
		public string RegistrationNumber { get; set; }
		public string State { get; set; }
		public string ExpirationDate { get; set; }
		public string ExpirationDateByKelly { get; set; }
		public bool IsKellyData { get; set; }
	}

	class RegulatoryList : BaseDialog
	{
		public const string BasePath = "//div[@class='modal fade in']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string Heading()
		{
			return containerElement.FindElement(By.XPath(".//h3"), 2)?.Text;
		}

		public bool ClickClose()
		{
			return containerElement.FindElement(By.XPath(".//button[@class='close']"), 2).TryClick();
		}
		public class RegulatoryListItem
		{
			public string RegulatoryCode { get; set; }
			public string Classification { get; set; }
		}
		public List<RegulatoryListItem> GetRegulatoryListRows()
		{
			var rList = new List<RegulatoryListItem>();
			var rows = containerElement.FindElements(By.XPath(".//tbody/tr"));
			foreach (var row in rows)
			{
				rList.Add(new RegulatoryListItem {
					Classification = row.FindElement(By.XPath("./td[@class = 'col-xs-3']"), 2)?.Text,
					RegulatoryCode = row.FindElement(By.XPath("./td[@class = 'col-xs-9']"), 2)?.Text
				});
			}
			return rList;
		}
	}
}

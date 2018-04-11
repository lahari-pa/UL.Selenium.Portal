using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
				var AddProductHeader = containerElement.FindElements(By.XPath(".//div[@class='panel-heading']//h3"))
					.FirstOrDefault(x => x.Text.Contains(sectionHeader));
				if (AddProductHeader != null)
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
						var ContainerDiv = tab.FindElement(By.XPath("./../../div"));
						string backGroundColour = ContainerDiv.GetCssValue("background-color");
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

		public string TSCAStatus {
			get
			{
				List<string> Countries = new List<string>();
				var ListOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TSCA"))
					.FindElements(By.XPath("../..//input"));
				foreach (var item in ListOfOptions)
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
				List<string> Countries = new List<string>();
				var ListOfCountries = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Select countries the product may be sold in"))
					.FindElements(By.XPath("../..//input"));
				foreach (var Country in ListOfCountries)
				{
					if (Country.Selected)
					{
						Countries.Add(Country.FindElement(By.XPath("../..//label")).Text);
					}
				}
				return Countries;

			}
			set
			{
				foreach (var Country in value)
				{
					var ThisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("Select countries the product may be sold in")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == Country);
					var CountryInput = ThisLabel.FindElement(By.XPath(".//../input"));
					if (!CountryInput.Selected)
					{
						CountryInput.Click();
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
					var ThisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (ThisLabel != null)
					{
						var thisInput = ThisLabel.FindElement(By.XPath(".//../input"));
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

		public string DOT {
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
					var ThisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (ThisLabel != null)
					{
						var thisInput = ThisLabel.FindElement(By.XPath(".//../input"));
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

		public string IMDG {
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
					var ThisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (ThisLabel != null)
					{
						var thisInput = ThisLabel.FindElement(By.XPath(".//../input"));
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

		public string IATA {
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
					var ThisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (ThisLabel != null)
					{
						var thisInput = ThisLabel.FindElement(By.XPath(".//../input"));
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

		public string TDG {
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
					var ThisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (ThisLabel != null)
					{
						var thisInput = ThisLabel.FindElement(By.XPath(".//../input"));
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

			bool EmptyBatteryRowsExist = true;
			IWebElement removeButton = null;

			while (EmptyBatteryRowsExist)
			{
				var listOfManufacturerTypes = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tbody//tr//td[" + batteryTypeIndex.ToString() + "]//select"));
				if (listOfManufacturerTypes != null)
				{
					var UnselectedManufacturerTypes = listOfManufacturerTypes.Where(x => x.SelectedOption() == "Choose...");
					if (UnselectedManufacturerTypes.Count() > 0)
					{
						removeButton = UnselectedManufacturerTypes.FirstOrDefault().FindElement(By.XPath("../..//td[" + removeIndex.ToString() + "]//a"));
						removeButton.Click();
						Delay.Seconds(3);
					}
					else
					{
						EmptyBatteryRowsExist = false;
					}
				}
				else
				{
					SafewareReporting.Report.Info("Failed to find any row.");
					EmptyBatteryRowsExist = false;
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

					listOfBatteries.Add(new Battery(batteryType,manufacturer,numberPerPackage,requiredToRun));
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

					var SelectDropDown = enterManufacturer.FindElement(By.XPath("../following-sibling::span"));

					if (SelectDropDown != null)
					{
						SelectDropDown.FindElements(By.XPath(".//ul/li")).FirstOrDefault().Click();
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
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is shipped directly"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x=>!x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is shipped directly"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


			}
		}

		public bool HasLCDOrPlasmaDisplay {
			get
			{
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Plasma Display"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Plasma Display"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


			}
		}

		public bool ContainsCircuitBoard {
			get
			{
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Contains Circuit Board"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Contains Circuit Board"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


			}
		}
		

		public bool Prop65 {
			get
			{
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Prop 65"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Prop 65"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


			}
		}

		public bool ProductHasTCLP {
			get
			{
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TCLP"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TCLP"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


			}
		}

		public bool RetailersPrivateLabelOrBrand {
			get
			{
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Private Label or Brand"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Private Label or Brand"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


			}
		}

		public bool WaitForMetalSection(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var Header = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div")).FirstOrDefault(x => x.Text.Contains("following metals"));
				if (Header != null)
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
				List<MetalPresence> ListOfMetals = new List<MetalPresence>();
				var Header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

				var listOfMetalRows = Header.FindElements(By.XPath("../../following-sibling::div"));
				string MetalName = "";
				string Presence = "";
				foreach (var MetalRow in listOfMetalRows)
				{
					try
					{
						MetalName = "";
						Presence = "";
						MetalRow.ScrollElementIntoView();
						Delay.Seconds(1);
						MetalName = MetalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label")).Text;
						var PresenceA = MetalRow.FindElements(By.XPath(".//div[@class='radio']//input"));

						var PresenceB = PresenceA.Where(x => x.Selected == true).ToList().FirstOrDefault();

						if (PresenceB != null)
						{
							Presence = PresenceB.FindElement(By.XPath("../span")).Text;
							SafewareReporting.Report.Info("Adding metal: " + MetalName + ": " + Presence);
							ListOfMetals.Add(new MetalPresence(MetalName, Presence));
						}
						else
						{
							ListOfMetals.Add(new MetalPresence(MetalName, "none"));
						}
							
					}
					catch (Exception e)
					{
						SafewareReporting.Report.Info(e.Message);
					}
					
				}

				return ListOfMetals;
			}
			set
			{
				SafewareReporting.Report.Info(value.Count.ToString() + " metals to set.");
				var Header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

				foreach (MetalPresence thisMetal in value)
				{
					var MetalLabel = Header.FindElements(By.XPath("../../following-sibling::div//div[@class='radio']/../preceding-sibling::div/label")).FirstOrDefault(x=>x.Text==thisMetal.Metal);
					MetalLabel.ScrollElementIntoView();
					MetalLabel.ClickWithScroll();
					var InputLabel = MetalLabel.FindElements(By.XPath("../..//input/../span"))
						.FirstOrDefault(x => x.Text == thisMetal.Presence);

					if (InputLabel != null)
					{
						var MetalInput = InputLabel.FindElement(By.XPath("../input"));
						if (InputLabel != null)
						{
							try
							{
								SafewareReporting.Report.Info("Attempting to set metal: " + thisMetal.Metal + " and value: " + thisMetal.Presence);
								MetalInput.ClickWithScroll();
								Delay.Seconds(1);
								if (!MetalInput.Selected)
								{
									MetalInput.Click();
								}

								SafewareReporting.Report.Screenshot();
							}
							catch (Exception e)
							{
								SafewareReporting.Report.Error("Failed to click metal: " + thisMetal.Metal + " and value: " + thisMetal.Presence);
								throw;
							}
							
						}
						else
						{
							throw new Exception("Cannot find input for: " + thisMetal.Presence);
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
			List<string> ListOfMetals = new List<string>();
			var CircuitDiv =SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

			var listOfMetalRows = CircuitDiv.FindElements(By.XPath("../../following-sibling::div"));
			string MetalName = "";
			foreach (var MetalRow in listOfMetalRows)
			{
				MetalName = "";
				try
				{
					MetalName = MetalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label")).Text;
					ListOfMetals.Add(MetalName);
				}
				catch (Exception e)
				{
				//	SafewareReporting.Report.Error(e.Message);
				}
				
			}
			return ListOfMetals;
		}

		public bool SolelyForRetailersUse {
			get
			{
				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("solely for the Retailer's use"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (SelectOption != null)
				{
					string SelectedOption = SelectOption.FindElement(By.XPath(".//span")).Text.Trim();
					SafewareReporting.Report.Info("Selected option is: " + SelectedOption);
					if (SelectedOption.ToLower() == "yes")
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
				string ValueToSet = "Yes";
				if (!value)
				{
					ValueToSet = "No";
				}

				var SelectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("solely for the Retailer's use"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == ValueToSet);
				SelectOption.Click();


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
	}

	public class Battery
	{
		public string BatteryType { get; set; }
		public string Manufacturer { get; set; }

		public int NumberPerPackage { get; set; }
		public int RequiredToRun { get; set; }

		public Battery(string batType, string batManufacturer, int batNoPerPackage, int batRequiredToRun)
		{
			BatteryType = batType;
			Manufacturer = batManufacturer;
			NumberPerPackage = batNoPerPackage;
			RequiredToRun = batRequiredToRun;
		}

		
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
}

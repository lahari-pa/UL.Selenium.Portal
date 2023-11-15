using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using NPOI.OpenXmlFormats.Spreadsheet;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using Context = UL.Automation.SpecFlow.Classes.Context;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class ProductIncludesBattery : NewProduct
	{
		IWebElement BatteriesTable => this.ContainerElement.FindElement(By.XPath(".//table"), 2);

		public string IndicateHowBatteryIsPackaged {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Indicate how battery is packaged"));

				if (lbl != null)
				{
					System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (IWebElement item in listOfItems)
					{
						if (item.Selected)
						{
							string selectedText = item.FindElement(By.XPath("../..//label/span"), 2).Text;
							Report.Info(selectedText + " is selected.");
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
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Indicate how battery is packaged"));

				if (lbl != null)
				{
					IWebElement thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span"), 2).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						IWebElement thisInput = thisLabel.FindElement(By.XPath(".//../input"), 2);
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

		private List<IWebElement> BatteryRows => this.containerElement.FindElements(By.XPath(".//tbody//tr"), 2).ToList();

		private IWebElement EnterManufacturer => this.containerElement.WaitUntilElementVisible(By.XPath(".//span[contains(@class, 'select2')]//input"), 5);

		/// <summary>
		/// On the 'Contains Batteries' page.
		/// set = enters the battery information in the table for a list of Battery objects (value). Optional use of Manufacturer property = '&lt;any&gt;' selects a random manufacturer from the drop
		/// get = returns a list of Battery objects corresponding to the batteries displayed in the table
		///
		/// </summary>
		public List<Battery> Batteries {
			get
			{
				var listOfBatteries = new List<Battery>();
				IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"), 2);

				if (thisTable == null)
				{
					return null;
				}

				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);
				ReadOnlyCollection<IWebElement> listOfRows = this.containerElement.FindElements(By.XPath(".//tbody//tr"));
				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per Package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("Operate Product")).Key;
				foreach (IWebElement thisRow in listOfRows)
				{
					string batteryType = thisRow.FindElement(By.XPath(".//td[" + batteryTypeIndex.ToString() + "]//selected"), 2).SelectedOption();
					string manufacturer = thisRow.FindElement(By.XPath(".//td[" + manufacturerIndex.ToString() + "]"), 2).Text;
					int numberPerPackage = Convert.ToInt16(thisRow.FindElement(By.XPath(".//td[" + perPackageIndex.ToString() + "]"), 2).Text);
					int requiredToRun = Convert.ToInt16(thisRow.FindElement(By.XPath(".//td[" + batteriesRequiredIndex.ToString() + "]"), 2).Text);
					listOfBatteries.Add(new Battery() { BatteryType = batteryType, Manufacturer = manufacturer, NumberPerPackage = numberPerPackage, RequiredToRun = requiredToRun });
				}
				return listOfBatteries;
			}
			set
			{
				IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"), 2);
				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);
				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per Package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("Operate Product")).Key;
				int batteryCount = 1;
				foreach (Battery thisBattery in value)
				{
					IWebElement addRowButton = this.containerElement.FindElements(By.XPath(".//button"), 2).FirstOrDefault(x => x.Text.Contains("Add Another Battery"));
					if (addRowButton != null)
					{
						addRowButton.Click();
					}
					else
					{
						throw new Exception("The add row button could not be found.");
					}
					Delay.Seconds(1);
					IWebElement batteryType = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + batteryTypeIndex.ToString() + "]//select"), 2);
					batteryType.Select(thisBattery.BatteryType);
					IWebElement manufacturer = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + manufacturerIndex.ToString() + "]"), 2);
					if (manufacturer == null || !manufacturer.TryClick())
					{
						throw new Exception("Failed to click Manufacturer element");
					}
					IWebElement enterTextInstructions = manufacturer.WaitUntilElementVisible(By.XPath(".//span[contains(@class, 'select2')]"), 5);
					if (enterTextInstructions == null)
					{
						throw new Exception("Enter manufacturer text instructions did not appear.");
					}
					string alpha = "abcdefghijklmnopqrstuvwxyz";
					int count = 0;
					bool foundResult = false;
					while (!foundResult && count < alpha.Length - 1)
					{
						if (this.EnterManufacturer == null)
						{
							throw new Exception("Enter manufacturer element was not found!");
						}
						Report.Info("Entering text: " + alpha[count] + " into the search input");
						this.EnterManufacturer.TryEnterText(thisBattery.Manufacturer == "<any>" ? alpha[count].ToString() : thisBattery.Manufacturer);

						//possible update needed to get all results then select random or one without error? or just move to next alpha if error?
						IWebElement result = this.EnterManufacturer.FindElement(By.XPath("./parent::span/following-sibling::span/ul/li[not(contains(@class,'loading-results'))]"), 10);
						foundResult = result != null;
						if (foundResult)
						{
							Report.Info("Found search results. Clicking the first option.");
							string resultElText = result.Text;
							if (result.TryClick())
							{
								if (thisBattery.SavedAs != null)
								{
									Context.AddToContext("battery_manufacturer: " + thisBattery.SavedAs, resultElText);
								}
								break;
							}
							Report.Info("Failed to click first search result option. Attempting the next alpha");
						}
						count++;
					}
					if (!foundResult)
					{
						throw new Exception("Manufacturer drop down could not be found");
					}
					IWebElement perPackage = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + perPackageIndex + "]//input"), 2);
					perPackage.TryEnterText(thisBattery.NumberPerPackage.ToString());
					IWebElement batteriesRequired = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + batteriesRequiredIndex + "]//input"), 2);
					batteriesRequired.TryEnterText(thisBattery.RequiredToRun.ToString());
					batteryCount++;
				}
			}
		}
		public bool SetSelectBatteriesOptions(string batteryOption, string value)
		{
			List<KeyValuePair<int, string>> th = this.TableHeaders(this.BatteriesTable);
			int optionIndex = th.FirstOrDefault(x => x.Value.Contains(batteryOption)).Key;
			IWebElement optionField = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath($".//td[{optionIndex.ToString()}]//select"), 2);
			optionField.Select(value);
			string batteryType = optionField.SelectedOption();
			return batteryType == value;	
		}
		public bool EnterInputBatteriesOption(string batteryOption, string value)
		{
			List<KeyValuePair<int, string>> th = this.TableHeaders(this.BatteriesTable);
			int optionIndex = th.FirstOrDefault(x => x.Value.Contains(batteryOption)).Key;
			IWebElement optionField = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath($".//td[{optionIndex}]//input"), 2);
			return optionField.TryEnterText(value);
		}

		public bool SetBatteriesSearchSelectOption(string batteryOption, string value)
		{
			bool result = false;
			List<KeyValuePair<int, string>> th = this.TableHeaders(this.BatteriesTable);
			int optionIndex = th.FirstOrDefault(x => x.Value.Contains(batteryOption)).Key;
			IWebElement manufacturer = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath($".//td[{optionIndex.ToString()}]"), 2);
			if (manufacturer == null || !manufacturer.TryClick())
				{
					throw new Exception("Failed to click Manufacturer element");
				}
			if (new SearchBoxPrototype().SearchInputExists() == false)
			{
				throw new Exception("Enter manufacturer text instructions did not appear.");
			}
			new SearchBoxPrototype().SearchInputEnterText(value);
			if (new SearchBoxPrototype().SearchResultsExists() == false)
			{
				throw new Exception("There are no result options to select");
			}
			var homePage = new ChooseGoodGuide.ChooseGoodGuide_Homepage();
			Delay.Seconds(1);
			homePage.WaitLoading();
			Delay.Seconds(1);
			result = new SearchBoxPrototype().SearchResultClick(value);
			return result;
		}

		public void DeleteEmptyBatteryRows()
		{
			IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"), 2);
			
			if (thisTable == null)
			{
				return;
			}

			List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);
			int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
			int removeIndex = th.FirstOrDefault(x => x.Value == "Remove").Key;
			var modeldialog = new ModalDialog();

			bool emptyBatteryRowsExist = true;
			IWebElement removeButton = null;

			while (emptyBatteryRowsExist)
			{
				ReadOnlyCollection<IWebElement> listOfManufacturerTypes = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tbody//tr//td[" + batteryTypeIndex.ToString() + "]//select"));
				if (listOfManufacturerTypes != null)
				{
					IEnumerable<IWebElement> unselectedManufacturerTypes = listOfManufacturerTypes.Where(x => x.SelectedOption() == "Choose...");
					if (unselectedManufacturerTypes.Count() > 0)
					{
						removeButton = unselectedManufacturerTypes.FirstOrDefault().FindElement(By.XPath("../..//td[" + removeIndex.ToString() + "]//a"), 2);
						removeButton.Click();
						Delay.Seconds(3);
						modeldialog.ClickButton("YES");
						Delay.Seconds(3);
					}
					else
					{
						emptyBatteryRowsExist = false;
					}
				}
				else
				{
					Report.Info("Failed to find any row.");
					emptyBatteryRowsExist = false;
				}
			}

		}
	}
}

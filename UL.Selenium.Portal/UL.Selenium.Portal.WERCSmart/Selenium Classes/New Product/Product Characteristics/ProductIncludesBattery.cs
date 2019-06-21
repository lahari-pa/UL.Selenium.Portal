using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using NPOI.OpenXmlFormats.Spreadsheet;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using Context = NTTQA.Selenium.SpecFlow.Context;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class ProductIncludesBattery : NewProduct
	{
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

		private List<IWebElement> BatteryRows => this.containerElement.FindElements(By.XPath(".//tbody//tr"),2).ToList();

		private IWebElement EnterManufacturer => this.containerElement.WaitUntilElementVisible(By.XPath(".//span[contains(@class, 'select2')]//input"), 5);

		/// <summary>
		/// On the 'Contains Batteries' page.
		/// set = enters the battery information for a list of Battery objects (value). Optional use of Manufacturer property = '&lt;any&gt;'
		/// get = returns a list of Battery objects corresponding to the batteries displayed in the table
		///
		/// </summary>
		public List<Battery> Batteries {
			get
			{
				List<Battery> listOfBatteries = new List<Battery>();
				IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"));
				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);
				var listOfRows = this.containerElement.FindElements(By.XPath(".//tbody//tr"));
				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("required")).Key;
				foreach (var thisRow in listOfRows)
				{
					string batteryType = thisRow.FindElement(By.XPath(".//td[" + batteryTypeIndex.ToString() + "]//selected")).SelectedOption();
					string manufacturer = thisRow.FindElement(By.XPath(".//td[" + manufacturerIndex.ToString() + "]")).Text;
					int numberPerPackage = Convert.ToInt16(thisRow.FindElement(By.XPath(".//td[" + perPackageIndex.ToString() + "]")).Text);
					int requiredToRun = Convert.ToInt16(thisRow.FindElement(By.XPath(".//td[" + batteriesRequiredIndex.ToString() + "]")).Text);
					listOfBatteries.Add(new Battery() { BatteryType = batteryType, Manufacturer = manufacturer, NumberPerPackage = numberPerPackage, RequiredToRun = requiredToRun });
				}
				return listOfBatteries;}
			set
			{
				IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"));
				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);
				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("required")).Key;
				int batteryCount = 1;
				foreach (var thisBattery in value)
				{
					var addRowButton = this.containerElement.FindElements(By.XPath(".//button")).FirstOrDefault(x => x.Text.Contains("Add Row"));
					if (addRowButton != null)
					{
						addRowButton.Click();
					}
					else
					{
						throw new Exception("The add row button could not be found.");
					}
					Delay.Seconds(1);
					var batteryType = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + batteryTypeIndex.ToString() + "]//select"), 2);
					batteryType.Select(thisBattery.BatteryType);
					var manufacturer = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + manufacturerIndex.ToString() + "]"), 2);
					if (manufacturer == null || !manufacturer.TryClick())
					{
						throw new Exception("Failed to click Manufacturer element");
					}
					var enterTextInstructions = manufacturer.WaitUntilElementVisible(By.XPath(".//span[contains(@class, 'select2')]"), 5);
					if (enterTextInstructions == null)
					{
						throw new Exception("Enter manufacturer text instructions did not appear.");
					}
					var alpha = "abcdefghijklmnopqrstuvwxyz";
					var count = 0;
					var foundResult = false;
					while (count < 30 && !foundResult)
					{
						if (this.EnterManufacturer == null)
						{
							throw new Exception("Enter manufacturer element was not found!");
						}
						this.EnterManufacturer.TryEnterText(thisBattery.Manufacturer == "<any>" ? alpha[count].ToString() : thisBattery.Manufacturer);
						Delay.Seconds(1);
						var selectDropDown = this.EnterManufacturer.FindElement(By.XPath("../following-sibling::span"), 2);
						foundResult = selectDropDown != null;
						if (foundResult)
						{
							Report.Info("Found search results. Clicking the first option.");
							var resultEl = selectDropDown.FindElement(By.XPath(".//ul/li"), 2);
							var resultElText = resultEl?.Text;
							if (resultEl.TryClick())
							{
								if (thisBattery.SavedAs != null)
								{
									Context.AddToContext("battery_manufacturer: " + thisBattery.SavedAs, resultElText);
								}
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
					var perPackage = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + perPackageIndex + "]//input"));
					perPackage.TryEnterText(thisBattery.NumberPerPackage.ToString());
					var batteriesRequired = this.BatteryRows.FirstOrDefault()?.FindElement(By.XPath(".//td[" + batteriesRequiredIndex + "]//input"));
					batteriesRequired.TryEnterText(thisBattery.RequiredToRun.ToString());
					batteryCount++;
				}
			}
		}

		public void DeleteEmptyBatteryRows()
		{
			IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"));
			List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);
			int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
			int removeIndex = th.FirstOrDefault(x => x.Value == "Remove").Key;
			ModalDialog modeldialog = new ModalDialog();

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

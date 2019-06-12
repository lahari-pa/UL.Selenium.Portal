using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;

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
				IWebElement thisTable = this.containerElement.FindElement(By.XPath(".//table"));
				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable);

				int batteryTypeIndex = th.FirstOrDefault(x => x.Value == "Battery Type").Key;
				int manufacturerIndex = th.FirstOrDefault(x => x.Value == "Manufacturer").Key;
				int perPackageIndex = th.FirstOrDefault(x => x.Value.Contains("per package")).Key;
				int batteriesRequiredIndex = th.FirstOrDefault(x => x.Value.Contains("required")).Key;
				int removeIndex = th.FirstOrDefault(x => x.Value == "Remove").Key;

				foreach (var thisBattery in value)
				{
					var addRowButton = this.containerElement.FindElements(By.XPath(".//button"))
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
					var listOfRows = this.containerElement.FindElements(By.XPath(".//tbody//tr"));
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

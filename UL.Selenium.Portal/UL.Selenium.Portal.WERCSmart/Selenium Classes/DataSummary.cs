using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DataSummary : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='dataentry']");

		public bool WaitForSpinner()
		{
			IWebElement spinner = this.ContainerElement.FindElement(By.XPath(".//i[contains(@class,'fa-spinner')]"), 2);
			if (spinner == null)
			{
				return true;
			}

			while (spinner != null && spinner.Displayed)
			{
				spinner = this.ContainerElement.FindElement(By.XPath(".//i[contains(@class,'fa-spinner')]"), 2);
				Delay.Seconds(Delay.SpeedFactor * 1);
			}

			return true;
		}

		public List<Battery> GetDisplayedBatteries()
		{
			this.WaitForSpinner();
			var retList = new List<Battery>();
			IWebElement tableElement = this.ContainerElement.FindElement(By.XPath(".//h2[@class='summary-question' and contains(text(),'battery')]//following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}

			IList<IWebElement> rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (IWebElement row in rows)
			{
				string batteryType = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				string batteryManufacturer = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				string batteryCellsInPackage = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				string batteryCellsRequired = row.FindElement(By.XPath(".//td[4]"), 2).GetValue();
				retList.Add(new Battery() { BatteryType = batteryType, Manufacturer = batteryManufacturer, NumberPerPackage = Convert.ToInt32(batteryCellsInPackage), RequiredToRun = Convert.ToInt32(batteryCellsRequired) });
			}

			return retList;

		}

		/// <summary>
		/// Get Private label option
		/// </summary>
		/// <returns></returns>
		public string GetPrivateLabelStatement()
		{
			this.WaitForSpinner();
			return this.containerElement.FindElement(By.XPath(".//h3[@class='summary-question' and contains(text(),'Private Label')]/../p[1]"), 2).Text;
		}

		/// <summary>
		/// Get Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		/// </summary>
		public string GetAlternativeControlPlanQuestion()
		{
			this.WaitForSpinner();
			return this.containerElement.FindElement(By.XPath(".//h3[@class='summary-question' and contains(text(),'Alternative Control Plan')]/../p[1]"), 2).Text;
		}

		/// <summary>
		/// Get Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.
		/// </summary>
		public string GetGramsOfVocPerUseAsDefinedCaliforniaConsumerProductsQuestion()
		{
			this.WaitForSpinner();
			return this.containerElement.FindElement(By.XPath(".//h3[@class='summary-question' and contains(text(),'California Consumer Products Regulation')]/../p[1]"), 2).Text;
		}

		public List<string> GetInfoForSectionOption(string section, string option)
		{


			this.WaitForSpinner();
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(@".//h3[@class='summary-question' and contains(text(),""" + section + @""")]/../p[contains(text(),""" + option + @""")]"), 2);

			return els.Select(x => x.GetElementText()).ToList();
		}

		public bool ConfirmHeaders(ICollection<string> headers, string section)
		{
			IWebElement table = this.containerElement.FindElement(By.XPath(@"//h2[contains(text(), """ + section + @""")]/following-sibling::table"), 2);
			table.ScrollElementIntoView();
			IList<IWebElement> headersElems = table.FindElements(By.TagName("th"), 2);
			var foundHeaders = new List<string>();
			foreach (IWebElement elem in headersElems)
			{
				foundHeaders.Add(elem.Text);
			}
			foreach (string header in headers)
			{
				if (!foundHeaders.Contains(header))
				{
					Report.Info("Failed to find header '" + header + "'.");
					return false;
				}
				else
				{
					Report.Info("Successfully found header '" + header + "'.");
				}
			}

			return true;
		}

		public bool ConfirmCaseUPC(TableRows rows, string section)
		{
			IWebElement table = this.containerElement.FindElement(By.XPath(@"//h2[contains(text(), """ + section + @""")]/following-sibling::table"), 2);
			table.ScrollElementIntoView();

			IWebElement caseUPCIcon = table.FindElement(By.XPath("//i[@class='fa fa-truck']"), 2);
			if (caseUPCIcon == null)
			{
				Report.Info("Could not find the case UPC icon.");
				return false;
			}
			string caseUPCNumber = "";
			IWebElement caseUPC = table.FindElement(By.XPath("//i[@class='fa fa-truck']/.."), 2);
			if (caseUPC != null && caseUPC.Text != "")
			{
				Report.Info("Found case UPC number on the screen!");
				caseUPCNumber = caseUPC.Text.Trim();
			}
			else
			{
				Report.Info("Could not find case UPC number on the screen.");
				return false;
			}

			IWebElement caseUPCRow = table.FindElement(By.XPath("//i[@class='fa fa-truck']/../../.."), 2);
			IList<IWebElement> caseUPCValues = caseUPCRow.FindElements(By.TagName("div"), 2);

			bool found = false;
			foreach (TableRow row in rows)
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
				if (row["Associated UPC"].ToLower().Contains("saved as"))
				{
					try
					{
						string savedUPC = Context
							.GetFromContext(row["Associated UPC"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						row["Associated UPC"] = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + row["Associated UPC"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}
				}

				if (row["UPC Number"] == caseUPCNumber)
				{
					found = true;
					string[] rowValues = row.Values.ToArray();
					for (int i = 0; i < rowValues.Length; i++)
					{
						if (rowValues[i] != caseUPCValues[i].Text.Trim())
						{
							Report.Info("Values do not match: '" + rowValues[i] + "' and '" + caseUPCValues[i].Text.Trim() + "'.");
							return false;
						}
						else
						{
							Report.Info("Values match: '" + rowValues[i] + "' and '" + caseUPCValues[i].Text.Trim() + "'.");
						}
					}
				}
			}

			if (found == false)
			{
				Report.Info("Could not find the correct case UPC number.");
				return false;
			}

			return true;
		}

		public bool ConfirmUPC(TableRows rows, string section)
		{
			IWebElement table = this.containerElement.FindElement(By.XPath(@"//h2[contains(text(), """ + section + @""")]/following-sibling::table"), 2);
			table.ScrollElementIntoView();

			IWebElement upcRow = null;
			upcRow = table.FindElement(By.XPath("//i[@class='fa fa-truck']/../../../following-sibling::tr"), 2);
			if (upcRow == null)
			{
				upcRow = table.FindElement(By.XPath("//i[@class='fa fa-truck']/../../../preceding-sibling::tr"), 2);
				if (upcRow == null)
				{
					Report.Info("Could not find UPC row in table!");
					return false;
				}
			}
			IList<IWebElement> upcValues = upcRow.FindElements(By.TagName("div"), 2);
			string upcNumber = upcValues != null ? upcValues[0].Text : "";

			bool found = false;
			foreach (TableRow row in rows)
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
				if (row["Associated UPC"].ToLower().Contains("saved as"))
				{
					try
					{
						string savedUPC = Context
							.GetFromContext(row["Associated UPC"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						row["Associated UPC"] = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + row["Associated UPC"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}
				}

				if (upcNumber != "" && row["UPC Number"] == upcNumber)
				{
					found = true;
					string[] rowValues = row.Values.ToArray();
					for (int i = 0; i < rowValues.Length; i++)
					{
						if (rowValues[i] != upcValues[i].Text.Trim())
						{
							Report.Info("Values do not match: '" + rowValues[i] + "' and '" + upcValues[i].Text.Trim() + "'.");
							return false;
						}
						else
						{
							Report.Info("Values match: '" + rowValues[i] + "' and '" + upcValues[i].Text.Trim() + "'.");
						}
					}
				}
			}

			if (found == false)
			{
				Report.Info("Could not find the correct UPC number!");
				return false;
			}

			return true;
		}

		public bool ConfirmUPCInformation(string section, string header, string value, string upc)
		{
			IWebElement table = this.containerElement.FindElement(By.XPath(@"//div[@id='dataentry']//h2[contains(text(), 'Provide the product's UPC(s), including container type and size (ounces)')]/../../preceding-sibling::div[@class='form - group']//div[@class='summary - question - container - bottom']//table"), 2);
			table.ScrollElementIntoView();

			IWebElement headerRow = table.FindElement(By.XPath(@"//tr//div[contains(text(), """ + header + @""")]/../.."), 2);
			IList<IWebElement> headerValues = headerRow.FindElements(By.TagName("div"), 2);
			int index = 0;
			foreach (IWebElement head in headerValues)
			{
				if (head.Text == header)
				{
					break;
				}
				index++;
			}

			IWebElement upcRow = table.FindElement(By.XPath(@"//tr//div[contains(text(), """ + upc + @""")]/../.."), 2);
			IList<IWebElement> upcValues = upcRow.FindElements(By.TagName("div"), 2);

			IWebElement containerType = upcValues[index];
			if (containerType.Text == value)
			{
				return true;
			}

			return false;
		}

		public string SGetProductName()
		{
			IWebElement productName = this.containerElement.FindElement(
				By.XPath("//h2/small[contains(text(), 'Product Name')]/../span[not(contains(@style, 'none'))]"), 2);
			if (productName == null)
			{
				Report.Info("Could not find product name");
				return "";
			}

			return productName.GetValue();
		}

		public string GetDocumentForSection(string section, string option)
		{
			IWebElement document = this.containerElement.FindElement(By.XPath(".//div[@class='form-group has-success']//span[contains(text(), '" + section + "')]/../div/span[contains(text(),'" + option + "')]"), 2);
			if (document == null)
			{
				Report.Info("Could not find option " + option + " for section " + section);
				return "";
			}

			return document.GetValue();
		}

		public bool ClickViewForDocument(string section)
		{
			IWebElement button = this.containerElement.FindElement(By.XPath(".//div[@class='form-group has-success']//span[contains(text(), '" + section + "')]/../div/a[contains(text(),'View')]"), 2);
			if (button == null)
			{
				Report.Info("Could not find View button for section: " + section);
				return false;
			}

			return button.TryClick();
		}

		public List<Ingredients.Ingredient> GetIngredients()
		{
			Report.Info("Getting ingredients");
			IWebElement ingredientsTable = this.containerElement.FindElement(By.XPath(".//div[@class='summary-question-container-bottom'][1]"), 60);
			var listOfIngredients = new List<Ingredients.Ingredient>();
			if (ingredientsTable == null)
			{
				Report.Error("Failed to find ingredients table");
				return listOfIngredients;
			}

			ReadOnlyCollection<IWebElement> ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody//tr//td[1]//div[@data-bind='html: Data']"));

			if (ingredientsRows.Count == 0)
			{
				Report.Info("There are no ingredients in the able");
				return listOfIngredients;
			}
			else
			{
				Report.Info("Found " + ingredientsRows.Count.ToString() + " ingredients");
			}

			for (int i = 0; i < ingredientsRows.Count - 1; i++)
			{
				IWebElement row = ingredientsRows[i];
				ReadOnlyCollection<IWebElement> rowColumns = row.FindElements(By.XPath(".[1]//div[@data-bind='html: Data']"));
				var thisIngredient = new Ingredients.Ingredient();
				string CASAndNaME = rowColumns[0].GetValue();
				string pattern = @"([A-Za-z\d\-\,^\r]+)";
				Match regMatch = Regex.Match(CASAndNaME, pattern);
				if (!regMatch.Success)
				{
					throw new Exception("pattern not found");
				}
				string pattern2 = @"[\\r\\n\s]+(.*)";
				Match regMatch2 = Regex.Match(CASAndNaME, pattern2);
				if (!regMatch2.Success)
				{
					throw new Exception("pattern not found");
				}
				thisIngredient.CASNumber = regMatch.Value.Trim();
				thisIngredient.ComponentName = regMatch2.Value.Trim();
				thisIngredient.Percent = rowColumns[1].GetValue();
				thisIngredient.PublicallyDisclosed = rowColumns[2].GetValue() == "Yes";
				thisIngredient.TradeSecret = rowColumns[3].GetValue() == "Yes";
				thisIngredient.PublicName = rowColumns[4].GetValue();
				listOfIngredients.Add(thisIngredient);
			}
			return listOfIngredients;
		}

		public void ScrollToIngredients()
		{
			IWebElement ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);
			if (ingredientsTable == null)
			{
				Report.Error("Failed to find ingredients table");
			}

			ingredientsTable.TryClick();
		}

		public decimal GetTransparencyRatio()
		{
			try
			{
				IWebElement ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);

				if (ingredientsTable == null)
				{
					Report.Error("Failed to find ingredients table");
					return -1;
				}

				var ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr"), 2).ToList();

				if (ingredientsRows.Count == 0)
				{
					Report.Info("There are no ingredients in the able");
					return -1;
				}

				IWebElement ratioRow = ingredientsRows[(ingredientsRows.Count - 1)];
				string sRatio = ratioRow.FindElements(By.XPath(".//td"), 2)[2].GetValue();
				Report.Info("Ratio: " + sRatio);

				string pattern = @"(\d)\s\/\s(\d)";
				Match regMatch = Regex.Match(sRatio, pattern);
				if (!regMatch.Success || regMatch.Groups.Count != 3)
				{
					return -1;
				}
				string numerator = regMatch.Groups[1].ToString();
				string denominator = regMatch.Groups[2].ToString();

				float calcRatio = Convert.ToSingle(numerator) / Convert.ToSingle(denominator);
				return (decimal)calcRatio;
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return -1;
			}

		}

		public string SGetTransparencyRatio()
		{
			try
			{
				IWebElement ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);

				if (ingredientsTable == null)
				{
					Report.Error("Failed to find ingredients table");
					return null;
				}

				var ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr"), 2).ToList();

				if (ingredientsRows.Count == 0)
				{
					Report.Info("There are no ingredients in the able");
					return null;
				}

				IWebElement ratioRow = ingredientsRows[(ingredientsRows.Count - 1)];
				string sRatio = ratioRow.FindElements(By.XPath(".//td"), 2)[2].GetValue();
				Report.Info("Ratio is: " + sRatio);
				return sRatio.Trim();
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return null;
			}

		}

		public double GetTransparencyPercentage()
		{
			try
			{
				IWebElement ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);

				if (ingredientsTable == null)
				{
					Report.Error("Failed to find ingredients table");
					return -1;
				}

				var ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr"), 2).ToList();

				if (ingredientsRows.Count == 0)
				{
					Report.Info("There are no ingredients in the able");
					return -1;
				}

				IWebElement ratioRow = ingredientsRows[(ingredientsRows.Count - 1)];
				string sRatio = ratioRow.FindElements(By.XPath(".//td"), 2)[2].GetValue();
				Report.Info("Percentage: " + sRatio);

				string pattern = @"(\d+\.\d\d)";
				Match regMatch = Regex.Match(sRatio, pattern);
				if (!regMatch.Success || regMatch.Groups.Count != 2)
				{
					return -1;
				}
				string calcRatio = regMatch.Groups[1].ToString();
				double test = Convert.ToDouble(calcRatio);
				return test;
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return -1;
			}

		}

		public string SGetTransparencyPercentage()
		{
			try
			{
				IWebElement ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);

				if (ingredientsTable == null)
				{
					Report.Error("Failed to find ingredients table");
					return null;
				}

				var ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr"), 2).ToList();

				if (ingredientsRows.Count == 0)
				{
					Report.Info("There are no ingredients in the able");
					return null;
				}

				IWebElement ratioRow = ingredientsRows[(ingredientsRows.Count - 1)];
				string sRatio = ratioRow.FindElements(By.XPath(".//td"), 2)[2].GetValue();
				Report.Info("Percentage is: " + sRatio);
				return sRatio.Trim();
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return null;
			}

		}

		public bool ConfirmSectionHasFollowingValueInSummaryPage(string section, string value)
		{
			IWebElement sectionValue = this.ContainerElement.FindElement(By.XPath("//h3[text()='" + section + "']/following-sibling::p[@data-bind='html: Data']"), 2);

			if (sectionValue == null)
			{
				return false;
			}

			if (sectionValue.Text == value)
			{
				return true;
			}

			return false;
		}
	}
}

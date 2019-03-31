using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DataSummary : BaseObject
	{
		public const string BasePath = "//div[@id='dataentry']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WaitForSpinner()
		{
			var spinner = this.containerElement.FindElement(By.XPath(".//i[contains(@class,'fa-spinner')]"), 2);
			if (spinner == null)
			{
				return true;
			}

			while (spinner != null && spinner.Displayed)
			{
				spinner = this.containerElement.FindElement(By.XPath(".//i[contains(@class,'fa-spinner')]"), 2);
				Delay.Seconds(Delay.SpeedFactor * 1);
			}

			return true;
		}

		public List<Battery> GetDisplayedBatteries()
		{
			this.WaitForSpinner();
			var retList = new List<Battery>();
			var tableElement = this.containerElement.FindElement(By.XPath(".//h2[@class='summary-question' and contains(text(),'battery')]//following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}

			var rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (var row in rows)
			{
				var batteryType = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				var batteryManufacturer = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				var batteryCellsInPackage = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				var batteryCellsRequired = row.FindElement(By.XPath(".//td[4]"), 2).GetValue();
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
			var els = this.containerElement.FindElements(By.XPath(".//h3[@class='summary-question' and contains(text(),'" + section + "')]/../p[contains(text(),'" + option + "')]"), 2);

			return els.Select(x => x.GetElementText()).ToList();
		}

		public string sGetProductName()
		{
			var productName = this.containerElement.FindElement(
				By.XPath("//h2/small[contains(text(), 'Product Name')]/../span[not(contains(@style, 'none'))]"), 2);
			if (productName == null)
			{
				Report.Info("Could not find product name");
				return "";
			}

			return productName.GetValue();
		}

		public List<Ingredients.Ingredient> GetIngredients()
		{
			Report.Info("Getting ingredients");
			var ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 60);
			var listOfIngredients = new List<Ingredients.Ingredient>();
			if (ingredientsTable == null)
			{
				Report.Error("Failed to find ingredients table");
				return listOfIngredients;
			}

			var ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr"));

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
				var row = ingredientsRows[i];
				var rowColumns = row.FindElements(By.XPath(".//td"));
				Ingredients.Ingredient thisIngredient = new Ingredients.Ingredient();
				string CASAndNaME = rowColumns[0].GetValue();
				var pattern = @"([A-Za-z\d\-\,^\r]+)";
				var regMatch = Regex.Match(CASAndNaME, pattern);
				if (!regMatch.Success)
				{
					throw new Exception("pattern not found");
				}
				var pattern2 = @"[\\r\\n\s]+(.*)";
				var regMatch2 = Regex.Match(CASAndNaME, pattern2);
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
			var ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);
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
				var ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);

				if (ingredientsTable == null)
				{
					Report.Error("Failed to find ingredients table");
					return -1;
				}

				List<IWebElement> ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr")).ToList();

				if (ingredientsRows.Count == 0)
				{
					Report.Info("There are no ingredients in the able");
					return -1;
				}

				var ratioRow = ingredientsRows[(ingredientsRows.Count - 1)];
				string sRatio = ratioRow.FindElements(By.XPath(".//td"))[2].GetValue();
				Report.Info("Ratio: " + sRatio);

				var pattern = @"(\d)\s\/\s(\d)";
				var regMatch = Regex.Match(sRatio, pattern);
				if (!regMatch.Success || regMatch.Groups.Count != 3)
				{
					return -1;
				}
				string numerator = regMatch.Groups[1].ToString();
				string denominator = regMatch.Groups[2].ToString();

				var calcRatio = Convert.ToSingle(numerator) / Convert.ToSingle(denominator);
				return (decimal)calcRatio;
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return -1;
			}

		}

		public string sGetTransparencyRatio()
		{
			try
			{
				var ingredientsTable = this.containerElement.FindElement(By.XPath(".//h2[contains(text(),'Ingredients')]/../table"), 2);

				if (ingredientsTable == null)
				{
					Report.Error("Failed to find ingredients table");
					return null;
				}

				List<IWebElement> ingredientsRows = ingredientsTable.FindElements(By.XPath(".//tbody/tr")).ToList();

				if (ingredientsRows.Count == 0)
				{
					Report.Info("There are no ingredients in the able");
					return null;
				}

				var ratioRow = ingredientsRows[(ingredientsRows.Count - 1)];
				string sRatio = ratioRow.FindElements(By.XPath(".//td"))[2].GetValue();
				Report.Info("Ratio is: " + sRatio);
				return sRatio.Trim();
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return null;
			}

		}



	}
}

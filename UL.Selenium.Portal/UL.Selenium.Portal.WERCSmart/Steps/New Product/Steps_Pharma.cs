using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Xml;
using UL.Automation.Reporting;
using UL.Automation.Selenium.Classes;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.Utilities.Functions;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RetailerAbbreviations;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "Pharma")]
	class Steps_Pharma
	{

		[StepDefinition(@"I check for the following options in the Additonal Documents to Provide section")]
		public void ThenICheckForTheFollowingOptionsInTheAdditonalDocumentsToProvideSection(Table table)
		{
			Pharma pharmaObject = new Pharma();
			var optionsNotFoundList = pharmaObject.CheckForOptions(table);
			Report.IsTrue(optionsNotFoundList.Count == 0, "Failed to locate all options in the Additonal Documents to Provide section", "Successfully located all options in the Additonal Documents to Provide section");

			foreach (string option in optionsNotFoundList)
			{
				Report.Info("Option that was not found: " + option);
			}
		}

		[StepDefinition(@"I fill all empty fields in the Ingredients screen")]
		public void GivenIFillAllEmmptyFieldsInTheIngredientsScreen()
		{
			Delay.Seconds(10);
			Pharma pharmaObject = new Pharma();
			Report.IsTrue(pharmaObject.CheckAndFillEmptyFieldsInIngredientsScreen(), "Failed to fill in all empty fields", "Successfully filled in all empty fields");
		}


		[StepDefinition(@"I fill all empty fields in the SPL Information screen")]
		public void GivenIFillAllEmmptyFieldsInTheSPLInformationScreen()
		{
			Delay.Seconds(10);
			Pharma pharmaObject = new Pharma();
			Report.IsTrue(pharmaObject.CheckAndFillEmptyFieldsInSPLInformationScreen(), "Failed to fill in all empty fields", "Successfully filled in all empty fields");
		}


		[StepDefinition(@"I enter the NDC number: (.*)")]
		public void GivenIEnterNDC(string number)
		{
			Pharma pharmaObject = new Pharma();
			Report.IsTrue(pharmaObject.ClickNDCField(), "Failed to click on NDC field", "Successfully clicked on NDC field");
			Delay.Seconds(5);
			Report.IsTrue(pharmaObject.EnterNDCNumber(number), "Failed to enter NDC number", "Successfully entered NDC number");
			Delay.Seconds(5);
			Report.IsTrue(pharmaObject.SelectFirstNDCNumberOption(), "Failed to select first option in NDC dropdown results", "Successfully selected first option in NDC dropdown results");
			Delay.Seconds(5);
		}


		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following product name: '(.*)'")]
		public bool ThenIConfirmThatTheExcelFileSavedAsProductsInScopeReportForBBBContainsTheFollowingProductName(string fileName, string productName)
		{

			if (Report.IsTrue(!string.IsNullOrEmpty(fileName), "No matching file was found for name: " + fileName + "!", "File was found: " + fileName))
			{

				var ExcelUtils = new ExcelFunctions(fileName.ToString(), "Table");

				List<List<string>> excelRowList = new List<List<string>>();

				for (int i = 1; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					List<string> excelRow = ExcelUtils.Excel_GetRow(i);

					excelRowList.Add(excelRow);
				}

				foreach (List<string> excelRow in excelRowList)
				{

					if (excelRow[1] == productName)
					{
						return true;
					}
				}

				return false;

			}

			Report.Info("The following excel file: " + fileName + " was not found");
			return false;

		}

	}
}

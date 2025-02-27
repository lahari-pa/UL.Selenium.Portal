using Reqnroll;
using System.Collections.Generic;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "Pharma")]
	class Steps_Pharma
	{

		[RegexStepDefinition(@"I check for the following options in the Additonal Documents to Provide section")]
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

		[RegexStepDefinition(@"I fill all empty fields in the SPL Information screen")]
		public void GivenIFillAllEmmptyFieldsInTheSPLInformationScreen()
		{
			Pharma pharmaObject = new Pharma();
			Report.IsTrue(pharmaObject.CheckAndFillEmptyFieldsInSPLInformationScreen(), "Failed to fill in all empty fields", "Successfully filled in all empty fields");
		}

		[RegexStepDefinition(@"I fill all empty fields in the Pharma Ingredients screen")]
		public void GivenIFillAllEmptyFieldsInThePharmaIngredientsScreen()
		{
			Pharma pharmaObject = new Pharma();
			Report.IsTrue(pharmaObject.CheckAndFillEmptyFieldsInPharmaIngredientsScreen(), "Failed to fill in all empty fields", "Successfully filled in all empty fields");
		}



		[RegexStepDefinition(@"I enter the NDC number: (.*)")]
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


		[RegexStepDefinition(@"I confirm that the excel file saved as: (.*) contains the following product name: '(.*)'")]
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

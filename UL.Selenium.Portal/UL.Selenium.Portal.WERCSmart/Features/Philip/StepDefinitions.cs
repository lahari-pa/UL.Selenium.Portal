using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;


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

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{
		public object TheProduct { get; private set; }
		public string File { get; private set; }

		//128018

		[StepDefinition(@"I check for the following options in the Additonal Documents to Provide section")]
		public void ThenICheckForTheFollowingOptionsInTheAdditonalDocumentsToProvideSection(Table table)
		{
			WebElements webElementsObject = new WebElements();
			var optionsNotFoundList = webElementsObject.CheckForOptions(table);
			Report.IsTrue(optionsNotFoundList.Count == 0, "Failed to locate all options in the Additonal Documents to Provide section", "Successfully located all options in the Additonal Documents to Provide section");

			foreach (string option in optionsNotFoundList)
			{
				Report.Info("Option that was not found: " + option);
			}
		}



















		//128018












		[StepDefinition(@"I confirm that the excel file saved as: Products in Scope Report for BBB contains the following product name: '(.*)'")]
		public bool ThenIConfirmThatTheExcelFileSavedAsProductsInScopeReportForBBBContainsTheFollowingProductName(string productName)
		{

			string File = "BB_Report_DataUsageTier_4_7_2020.xlsx";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + File + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<List<string>> excelRowList = new List<List<string>>();
				for (int i = 1; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					List<string> excelRow = ExcelUtils.Excel_GetRow(i);

					excelRowList.Add(excelRow);
				}

				foreach (List<string>excelRow in excelRowList)
				{
					if (excelRow[1] == productName)
					{
						return true;
					}
				}

				return false;

			}

			Report.Info("The following excel file: " + File + " was not found");
			return false;

		}


		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following columnss:")]
		public bool ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<List<string>> str = new List<List<string>>();
				for (int i = 1; i < table.RowCount + 1; i++)
				{
					List<string> ColumnTitles = ExcelUtils.Excel_GetRow(i);

					str.Add(ColumnTitles);
				}

				Report.Info("hi");
				var abbr = new RetailerAbbreviations();
				string selectedAbbr = "";

				foreach (TableRow thisRow in table.Rows)
				{

					Report.Info("hi1");
					string retailer = thisRow["Retailer"];
					bool isFound = false;

					abbr.Map.TryGetValue(retailer, out selectedAbbr);
					Report.Info("hi1.1 " + retailer + " === " + selectedAbbr);
					foreach (List<string> listStr in str)
					{

						Report.Info("hi2 " + listStr[0] + " === " + retailer + " === " + selectedAbbr);
						if (listStr[0] == selectedAbbr)
						{
							Report.Info("hi2.1");
							isFound = true;
						}
					}
					if (!isFound)
					{
						Report.Info("hi3");
						Report.IsTrue(isFound, "", "");
					}
				}
				Report.Info("hi4");
				return true;
			}
			Report.Info("hi5");
			return false;
		}

		[StepDefinition(@"I fill all empty fields in the SPL Information screen")]
		public void GivenIFillAllEmmptyFieldsInTheSPLInformationScreen()
		{
			Delay.Seconds(5);
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckAndFillEmptyFieldsInSPLInformationScreen(), "Failed to fill in all empty fields", "Successfully filled in all empty fields");
		}



		[StepDefinition(@"I enter the NDC number: (.*)")]
		public void GivenIEnterNDC(string number)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ClickNDCField(), "Failed to click on NDC field", "Successfully clicked on NDC field");
			Delay.Seconds(5);
			Report.IsTrue(webElementsObject.EnterNDCNumber(number), "Failed to enter NDC number", "Successfully entered NDC number");
			Delay.Seconds(5);
			Report.IsTrue(webElementsObject.SelectFirstNDCNumberOption(), "Failed to select first option in NDC dropdown results", "Successfully selected first option in NDC dropdown results");
			Delay.Seconds(5);
		}


		[StepDefinition(@"I call Shared Step 57500a \(Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path\): (.*)")]
		public void GivenICallMySharedStepPrescriptionPharmaceuticalSolid(string type)
		{
			string name = "";
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			Report.StartStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			if (name == "")
			{
				char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
				name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			}
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info($"The TestCaseId was found as: {TReVorSettings.TestCaseId}");

			Context.AddToContext($"TestCase{TReVorSettings.TestCaseId}", prodDetails);
		}



		[StepDefinition(@"Confirm that there is a middle column called: (.*) between left column called: (.*) and right column called: (.*)")]
		public void GivenConfirmThatThereIsAMiddleColumnCalledBetweenLeftColumnCalledAndRightColumnCalled(string middleColumnName, string leftColumnName, string rightColumnName)
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ChcekForAColumnBetweenTwoColumns(middleColumnName, leftColumnName, rightColumnName), "Failed to find a middle column called: " + middleColumnName, "Successfully found a middle column called: " + middleColumnName);
		}

		[StepDefinition(@"Find productID that has the letter: (.*) in the CW column and save it as: (.*)")]
		public void ThenFindProductThatHasTheLetterInTheCWColumn(string letter, string saveAs)
		{
			WebElements WebElementsObject = new WebElements();
			string productID = WebElementsObject.FindProductIDWithSpecificLetterInCWColumn(letter);
			Context.AddToContext(saveAs, productID);
			Report.IsTrue(productID != null, "Failed to find a productID", "Successfully found a productID");
		}

		[StepDefinition(@"I open Power Designer Plus")]
		public void ThenIOpenPowerDesignerPlus()
		{
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
		}

		[StepDefinition(@"I search for productID saved as : (.*) in SHA")]
		public void ThenISearchForProductIDSavedAsProductIDInSHA(string saveAs)
		{
			Delay.Seconds(30);
		WebElements WebElementsObject = new WebElements();
		var productID = Context.GetFromContext(saveAs).ToString();
		Report.IsTrue(WebElementsObject.EnterProductWithIDInSHASearchField(productID), "Failed to enter productID: " + productID + " in search field", "Successfully enter productID: " + productID + " in search field");
		}

		[StepDefinition(@"I click the refresh button in SHA")]
		public void ThenIClickTheRefreshButtonInSHA()
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ClickSearchButtonInSHA(), "Failed to click search button in SHA", "Successfully clicked search button in SHA");
		}


		[StepDefinition(@"I click the Vendor Report section")]
		public void ThenIClickVendorSection()
		{
			Delay.Seconds(30);
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ClickVendorReportSection(), "Failed to click Vendor Report section", "Successfully clicked Vendor Report section");
		}

		[StepDefinition(@"I click section called: (.*) in the Vendor Report section")]
		public void ThenIClickASection(string sectionName)
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ClickASectionInVendorReportSection(sectionName), "Failed to click section called: " + sectionName, "Successfully clicked section called: " + sectionName);
		}

		[StepDefinition(@"I check that the following text: (.*) (should|should not) exist")]
		public void ThenCheckText(string text, string shouldOrShouldNot)
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.CheckForTheFollowingText(text, shouldOrShouldNot), "Failed to check if text " + shouldOrShouldNot + " exist", "Successfully checked if text " + shouldOrShouldNot + " exist");
		}

	}
}

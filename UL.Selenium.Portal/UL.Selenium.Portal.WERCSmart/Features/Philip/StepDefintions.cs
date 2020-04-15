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









		//120873

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

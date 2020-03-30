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

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{

		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following columnss:")]
		public bool ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<List<string>> str = new List<List<string>>();
				for (int i = 1; i < table.RowCount+1; i++)
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
					foreach (List<string>listStr in str)
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

		[StepDefinition(@"I Close 'Supplier Manager'")]
		public void ThenIClose()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.CloseDialog();
		}


		[StepDefinition(@"Confirm that '(.*)' shows (.*) marked with a '(.*)'")]
		public void ThenConfirmThatShowsTierTierAndTierMarkedWithA(string supplier, string tiers, string marked)
		{
			WebElements WebElementsObject = new WebElements();
			var arr = tiers.Split(',');
			WebElementsObject.ConfirmTier(supplier, arr, marked);
		}


		[StepDefinition(@"Select the 'Data Tier Consent' Tab")]
		public void ThenSelectTheTab()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickTab();
			Delay.Seconds(8);
		}


		[StepDefinition(@"Select the 'The WERCS LTD' - Staging")]
		public void ThenSelectThe_Staging()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickResult();
		}


		[StepDefinition(@"Search for '(.*)' Vendor")]
		public void ThenSearchForVendor(string text)
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.SearchText(text);
			WebElementsObject.ClickSearch();
		}


		[StepDefinition(@"I Click 'Suppliers'")]
		public void ThenIClick()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickSuppliers();
		}


		[StepDefinition(@"I (should|should not) see radio option: (.*)")]
		public void ISeeRadioOption(string shouldOrShouldNot, string radioButtonText)
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.FindRadioButton(shouldOrShouldNot, radioButtonText);
		}

		[StepDefinition(@"I check if AIS is not uploaded")]
		public void ICheckIfAISIsNotUploaded()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.CheckAIS();
		}

		[StepDefinition(@"I close annoying popup")]
		public void GivenICloseAnnoyingPopup()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.Closepopup();
		}


		[StepDefinition(@"Check popup date productID: (.*) productType:(.*) productAccessCode: (.*)")]
		public void ThenCheckPopupDate(string productID, string productType, string productAccessCode)
		{
			WebElements WebElementsObject = new WebElements();
			string testCaseId;
			var obj = Context.GetFromContext(productID);
			Report.Info("Attempting to convert Product to type ProductInformation");
			var Product = (ProductInformation)obj;
			Report.Info("Attempting to delete: " + Product.Name);
			testCaseId = Product.Id;
			Report.Info("ProductID: " + testCaseId + " ProductType: " + productType + " ProductAccessCode: " + productAccessCode);
			WebElementsObject.CheckPopUp();
		}


		[StepDefinition(@"Confirm that there is a CW column between Last Pub Date and GHS columns")]
		public void GivenConfirmThatThereIsACWColumnBetweenLastPubDateAndGHSColumns()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.CheckColumn();
		}

		[StepDefinition(@"Find product that has a Y in the CW column")]
		public void ThenFindProductThatHasAYInTheCWColumn()
		{
			WebElements WebElementsObject = new WebElements();
			var savedas = "TestCase" + WebElementsObject.FindProduct();
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info("Saving product: " + prodDetails.Id + ",  " + prodDetails.Name);
			Context.AddToContext(savedas, prodDetails);
			string idname = $"{savedas}_ID";
			Context.AddToContext(idname, prodDetails.Id);
			Report.Success("Product Information saved!");
		}

		[StepDefinition(@"Find product that has a N in the CW column")]
		public void ThenFindProductThatHasANInTheCWColumn()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.FindProductN();
		}


		[StepDefinition(@"I click vendor section")]
		public void ThenIClickVendorSection()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickVendorSection();
		}

		[StepDefinition(@"I click a section")]
		public void ThenIClickASection()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickASection();
		}

		[StepDefinition(@"check text")]
		public void ThenCheckText()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.CheckText();
		}

	}
}

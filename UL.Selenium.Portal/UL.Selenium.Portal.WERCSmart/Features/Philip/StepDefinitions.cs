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

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{

		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following product name: '(.*)'")]
		public bool ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingProductName(string savedAs, string productName)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<List<string>> rows = new List<List<string>>();

				for (int i = 0; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					List<string> row = ExcelUtils.Excel_GetRow(i);

					rows.Add(row);
				}

				foreach (List<string> row in rows)
				{

					foreach (string item in row)
					{

						if (item == productName)
						{
							return true;
						}

					}

				}

				return false;

			}

			Report.Failure("Excel data was not found");
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

			ReportSettings.UseSubSteps = true;
			var selStepsSha = new Steps_SHA();
			var selStepsStudio = new Steps_Studio();
			Report.StartStep("I navigate to Power Designer Plus");
			selStepsSha.GivenIClickTopMenuItemAndSubMenuItem("Authoring", "Power Designer Plus");
			GeneralUtilities.StudioWaitForSpinner();
			Report.Info("012");
			string id = savedas;
			Report.Info("123");
			//selStepsStudio.PowerDesignerPlusWelcomeIEnterSelectSourceProduct(id);
			Report.Info("456");
			Report.StartStep("I confirm CKLT (Checklist) is selected as the subformat");
			selStepsStudio.IConfirmTheSelectedSubformatInThePdPlusPopupIs("CKLT / Checklist");
			Report.Info("789");
			Report.StartStep("I click continue");
			selStepsStudio.ClickContinueInThePowerDesignerPlusPopup();
			Delay.Seconds(3);
			//selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			//selStepsStudio.InPDIEnsureSECT2318IsActive();
			//selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();


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

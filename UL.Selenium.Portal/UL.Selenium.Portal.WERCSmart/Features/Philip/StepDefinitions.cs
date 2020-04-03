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

		[StepDefinition(@"SPL Information screen")]
		public void GivenSPLInformationScreen()
		{
			Delay.Seconds(10);
			WebElements webElementsObject = new WebElements();
			webElementsObject.CheckFields();
		}


		[StepDefinition(@"I enter NDC: (.*)")]
		public void GivenIEnterNDC(string type)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ClickNDC(type), "Failed", "Successful");
			Delay.Seconds(5);
			Report.IsTrue(webElementsObject.EnterNDC(type), "Failed1", "Successful1");
			Delay.Seconds(5);
			Report.IsTrue(webElementsObject.ClickFirstItem(type), "Failed2", "Successful2");
			Delay.Seconds(5);
		}


		[StepDefinition(@"I call my Shared Step 2: (.*)")]
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

		[StepDefinition(@"Find product that has a (.*) in the CW column")]
		public void ThenFindProductThatHasAYInTheCWColumn(string letter)
		{
			WebElements WebElementsObject = new WebElements();
			var savedas = WebElementsObject.FindProduct(letter);
			WebElementsObject.SearchSHA(savedas);
			
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

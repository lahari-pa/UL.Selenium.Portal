using OpenQA.Selenium;
using UL.Automation.WebDriver.Classes;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Reporting.Functions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using TReVor.Api.Wrapper.Classes;
using System.IO;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.AdvancedReportsRules;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "FileOps")]
	class Steps_FileOps
	{
		[StepDefinition(@"I save the information for the first record in Retailer Product in Recert excel spreadsheet saved as: (.*) as: (.*) and (.*)")]
		public void ISaveTheInformationForTheFirstRecordInTheExcelSpreadSheetAs(string excel, string savedAs, string savedAs2)
		{
			string file = Context.GetFromContext(excel)?.ToString() ?? "";
			var ExcelUtils = new ExcelFunctions(file.ToString(), "Table");
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + excel);
				return;
			}
			var advRepProducts = new AdvancedReportingRetailerProductsInRecert();
			System.Collections.Generic.List<string> row = ExcelUtils.Excel_GetRow(1);
			if (row.Count != 4)
			{
				Report.Failure("Found an incorrect number of items in row!");
				return;
			}
			advRepProducts.WPSID = row[0];
			advRepProducts.ProductName = row[1];
			advRepProducts.Supplier = row[2];
			advRepProducts.RecertificationDate = row[3];

			Context.AddToContext(savedAs, advRepProducts);

			var prodInfo = new ProductInformation {
				Id = row[0],
				Name = row[1]
			};

			Context.AddToContext(savedAs2, prodInfo);
		}

		[StepDefinition(@"I save the information for the first record in 3rd Party Formula Use in Registrations excel spreadsheet saved as: (.*) as: (.*) and (.*)")]
		public void ISaveTheInformationForTheFirstRecordIn3rdPartyExcelAs(string excel, string savedAs, string savedAs2)
		{
			string file = Context.GetFromContext(excel)?.ToString() ?? "";
			var ExcelUtils = new ExcelFunctions(file.ToString(), "Table");
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + excel);
				return;
			}
			var advRep3rdParty = new AdvancedReporting3rdParty();
			System.Collections.Generic.List<string> row = ExcelUtils.Excel_GetRow(1);
			if (row.Count != 6)
			{
				Report.Failure("Found an incorrect number of items in row!");
				return;
			}
			advRep3rdParty.WPSID = row[0];
			advRep3rdParty.SupplierName = row[1];
			advRep3rdParty.ContactEmail = row[2];
			advRep3rdParty.LastOrderDate = row[3];
			advRep3rdParty.LastPublishedDate = row[4];
			advRep3rdParty.Status = row[5];

			Context.AddToContext(savedAs, advRep3rdParty);
			Report.Success("Saved 3rd Party information to context");

			var prodInfo = new ProductInformation {
				Id = row[0],
				Name = ""
			};

			Context.AddToContext(savedAs2, prodInfo);
			Report.Success("Saved product information to context");
		}
	}
}

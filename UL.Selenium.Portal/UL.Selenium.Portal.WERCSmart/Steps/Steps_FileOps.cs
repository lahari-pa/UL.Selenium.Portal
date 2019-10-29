using NTTQA.Selenium.Cache;
using OpenQA.Selenium;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.SpecFlow;
using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using TReVor.Api.Wrapper.Classes;
using System.IO;
using Castle.Core.Internal;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.AdvancedReportsRules;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "FileOps")]
	class Steps_FileOps
	{
		[StepDefinition(@"I save the information for the first record in Retailer Product in Recert excel spreadsheet saved as: (.*) as: (.*) and (.*)")]
		public void ISaveTheInformationForTheFirstRecordInTheExcelSpreadSheetAs(string excel, string savedAs, string savedAs2)
		{
			string file = Context.GetFromContext(excel)?.ToString() ?? "";
			var ExcelUtils = new ExcelUtilities(file.ToString(), "Table");
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
	}
}

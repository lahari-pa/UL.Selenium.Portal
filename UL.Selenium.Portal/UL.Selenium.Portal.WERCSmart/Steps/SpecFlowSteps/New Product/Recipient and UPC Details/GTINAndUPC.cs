using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Recipient_and_UPC_Details
{
	[Binding, Scope(Tag = "GTINAndUPC")]
	internal class GTINAndUPC
	{
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, upload file in section: 'Battery or Battery-Containing Product \(BCP\) Product Label per UPC'")]
		public void UploadFileForBatteryProductLabel()
		{
			string section = "Battery or Battery-Containing Product (BCP) Product Label per UPC";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, I click the Add UPC Button")]
		public void ClickAddUpcButton()
		{
			Report.IsTrue(new NewProduct().ClickAddUpcButton(), "Failed to click the 'Add' button!", "Successfully clicked the 'Add' button");
		}

		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Provide the product's UPC\(s\)- including container type and size \(ounces\)' enter UPC Number: (.*) enter Size: (.*) and enter Container Type: (.*)")]
		public void EnterUPCInformation(string upc, string size, string containerType)
		{

			if (upc.ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					upc = savedUPC;
				}
				catch (Exception e)
				{
					Report.Info("Failed to find saved item in context: " + upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
					throw;
				}

			}

			var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc,
					};

		
			var NP = new NewProduct();
				NP.WaitForContainerToBeVisible(30);
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
	}
}

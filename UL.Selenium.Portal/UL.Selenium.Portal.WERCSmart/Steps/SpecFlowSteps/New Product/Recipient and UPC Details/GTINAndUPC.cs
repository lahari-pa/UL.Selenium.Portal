using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

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

		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Provide the product's UPC\(s\)- including container type and size \(ounces\)' enter UPC Number: (.*) enter Size: (.*) enter Container Type: (.*) and enter Quantity: (.*)")]
		public void EnterUPCInformationWithQuantity(string upc, string size, string containerType, string quantity)
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
				Quantity = quantity,
			};


			var NP = new NewProduct();
			NP.WaitForContainerToBeVisible(30);
			Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
				"Successfully inputted UPC information!");
		}

		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, verify retailer '(.*)' (is|is not) present under the 'Destination Retailers' column")]
		public void RetailerUnderDestinationRetailers(string retailer, string is_isnot)
		{
			new StepsNewProduct().ConfirmRetailerIsPresentUnderTheDestinationRetailersColumnUPCTable(retailer, is_isnot);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, verify option '(.*)' (is|is not) present")]
		public void UPCOptionIsIsNotPresent(string option, string is_isnot)
		{
			bool expected = is_isnot == "is";
			List<string> upcOptions = new UPC().GetUPCOptions();
			Report.IsTrue(upcOptions.Contains(option) == expected,
				$"Failure, option {option} {(expected ? "is not" : "is")} displayed", $"Success, option {option} {is_isnot} displayed.");
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, under Transportation column the checkbox '(.*)' (is|is not) checked")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionUnderTransportationColumnTheCheckboxDOTIsChecked(string checkbox, string is_isnot)
		{
			new Steps_Prototype().TheCheckboxWithDescriptionIsIsNotChecked(checkbox, is_isnot);
		}

		// table format bellow 
		//|Container Type|
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, the following container types (should|should not) be displayed from the drop down list:")]
		public void GivenIShouldSeeContainerTypeFromTheDropDownList(string shouldOrNot, Table table)
		{
			List<string> containerTypes = new NewProduct().GetContainerOptions();
			if (shouldOrNot == "should")
			{
				foreach (TableRow Row in table.Rows)
				{
					Report.IsTrue(containerTypes.Contains(Row["Container Type"]), "Container type was not found", "Container Type was found on the upc page as expected");
				}
			}
			else if (shouldOrNot == "should not")
			{
				foreach (TableRow Row in table.Rows)
				{
					Report.IsTrue(!containerTypes.Contains(Row["Container Type"]), "Container type was found", "Container Type was not found on the upc page as expected");
				}
			}
			else
			{
				Report.Failure("input values must be either 'should' or 'should not'");
			}
		}

		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, an error message (should|should not) be displayed")]
		public void ConfirmNoErrorMessagesOnUPCPage(string condition)
		{
			new Steps_Prototype().NoErrorMessages(condition); 
		}
	}
}

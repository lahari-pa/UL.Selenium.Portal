using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.WebDriver.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Recipient_and_UPC_Details
{
	[Binding, Scope(Tag = "GTINAndUPC")]
	internal class GTINAndUPC
	{
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, upload file in section: 'Battery or Battery-Containing Product \(BCP\) Product Label per UPC'")]
		public void UploadFileForBatteryProductLabel()
		{
			string section = "Battery or Battery-Containing Product (BCP) Product Label per UPC";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, I click the Add UPC Button")]
		public void ClickAddUpcButton()
		{
			Report.IsTrue(new NewProduct().ClickAddUpcButton(), "Failed to click the 'Add' button!", "Successfully clicked the 'Add' button");
		}

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Provide the product's UPC\(s\)- including container type and size \(ounces\)' enter UPC Number: (.*) enter Size: (.*) and enter Container Type: (.*)")]
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

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Provide the product's UPC\(s\)- including container type and size \(ounces\)' enter UPC Number: (.*) enter Size: (.*) enter Container Type: (.*) and enter Quantity: (.*)")]
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

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, verify retailer '(.*)' (is|is not) present under the 'Destination Retailers' column")]
		public void RetailerUnderDestinationRetailers(string retailer, string is_isnot)
		{
			new StepsNewProduct().ConfirmRetailerIsPresentUnderTheDestinationRetailersColumnUPCTable(retailer, is_isnot);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, verify option '(.*)' (is|is not) present")]
		public void UPCOptionIsIsNotPresent(string option, string is_isnot)
		{
			bool expected = is_isnot == "is";
			List<string> upcOptions = new UPC().GetUPCOptions();
			Report.IsTrue(upcOptions.Contains(option) == expected,
				$"Failure, option {option} {(expected ? "is not" : "is")} displayed", $"Success, option {option} {is_isnot} displayed.");
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, under Transportation column the checkbox '(.*)' (is|is not) checked")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionUnderTransportationColumnTheCheckboxDOTIsChecked(string checkbox, string is_isnot)
		{
			new Steps_Prototype().TheCheckboxWithDescriptionIsIsNotChecked(checkbox, is_isnot);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, click 'sample file' link to download file")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionClickSampleFileLink()
		{
			string link = "sample file";
			new Steps_Prototype().ClickLinkElement(link);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, confirm 'sample file' is downloaded and save as: (.*)")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionFileIsDownloaded(string savedAs)
		{
			string fileName = "Sample.xlsx";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(fileName, savedAs);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, click 'Upload File' button and upload file saved as: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionClickButtonAndUploadFileSavedAs(string savedAs)
		{
			string button = "Upload File";
			var excelFile = Context.GetFromContext(savedAs).ToString();

			if (excelFile == null)
			{
				Report.Failure("The UPC spreadsheet could not be found");
				return;
			}
			new Steps_Prototype().ClickButton(button);
			Report.IsTrue(UploadDialog.UploadFile(excelFile), "Failed to enter file name!", "Successfully entered file name");

		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, confirm 'Add Multiple' modal window (should|should not) be displayed")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionAddMultipleIsDisplayed(string condition)
		{
			string modalTitle = "Add Multiple";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal (check|uncheck) All UPCs checkbox")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModalCheckAllUPCsCheckbox(string check_uncheck)
		{
			if (check_uncheck == "check")
			{
				if (!new MultipleUPC().AllUpcCheckboxSelected())
				{
					Report.IsTrue(new MultipleUPC().ClickSelectAllUpcsButton(), "The select all Upcs button was not clicked successfully", "The select all Upcs button was clicked successfully");
				}
				else
				{
					Report.Success("All UPCs Checkbos is already checked");
				}
			}
			else
			{
				if (new MultipleUPC().AllUpcCheckboxSelected())
				{
					Report.IsTrue(new MultipleUPC().ClickSelectAllUpcsButton(), "The select all Upcs button was not clicked successfully", "The select all Upcs button was clicked successfully");
				}
				else
				{
					Report.Success("All UPCs Checkbos is already unchecked");
				}
			}
		}

		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal confirm all UPCs are (selected|not selected)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionConfirmAllUPCsAreSelected(string condition)
		{
			new StepsUPC().ICheckAllRetailersSelectedStatus(condition);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal select Packaging Type: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModalSelectPackagingTypePlasticContainer(string value)
		{
			new StepsUPC().InTheAddMultipleDialogBoxSelectPackagingTypeX(value);
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal click 'Next' button")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModaClickNext()
		{
			new StepsUPC().InTheAddMultipleDialogBoxClickNext();
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal click 'Finish' button")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModaClickFinish()
		{
			new StepsUPC().InTheAddMultipleDialogBoxClickFinish();
		}
		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal (check|uncheck) retailer: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtSelectRetailerTarget(string check_uncheck, string retailer)
		{
			if (Report.IsTrue(new MultipleUPC().RetailerExists(retailer), $"Failed to find retailer '{retailer}'", $"Successfully found retailer '{retailer}'"))
			{
				if (check_uncheck == "check")
				{
					if (!new MultipleUPC().SelectedRetailer(retailer))
					{
						Report.IsTrue(new MultipleUPC().SelectRetailer(retailer), $"Failed to check retailer '{retailer}'", $"Successfully checked retailer '{retailer}'");
					}
					else
					{
						Report.Success($"Retailer '{retailer}' is already selected");
					}
				}
				else
				{
					if (new MultipleUPC().SelectedRetailer(retailer))
					{
						Report.IsTrue(new MultipleUPC().SelectRetailer(retailer), $"Failed to uncheck retailer '{retailer}'", $"Successfully unchecked retailer '{retailer}'");
					}
					else
					{
						Report.Success($"Retailer '{retailer}' is already deselected");
					}
				}
			}
		}

		[StepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, error message (should|should not) be displayed with text: 'You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please remove the instances of duplicate UPC\(s\) from the necessary registration data.'")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionErrorMessageShouldBeDisplayedWithText(string condition)
		{
			string alertText = "You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please remove the instances of duplicate UPC(s) from the necessary registration data.";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}



	}
}

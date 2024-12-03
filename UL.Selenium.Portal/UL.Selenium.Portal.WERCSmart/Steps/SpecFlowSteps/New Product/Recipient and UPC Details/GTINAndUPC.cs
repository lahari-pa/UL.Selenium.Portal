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
using UL.Selenium.Portal.RPS.Selenium_Classes;
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
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, I click the 'Add Part Number' button")]
		public void ClickAddPartNumberButton()
		{
			Report.IsTrue(new NewProduct().ClickAddPartNumber(), "Failed to click the 'Add Part Number' button!", "Successfully clicked the 'Add Part Number' button");
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

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Provide the product's UPC\(s\)- including container type and size \(ounces\)' enter UPC Number: (.*) enter Size: (.*) enter Container Type: (.*) and enter internal SKU: (.*)")]
		public void EnterUPCInformationWithSKU(string upc, string size, string containerType, string internalSKU)
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
				InternalSKU = internalSKU,
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

		// table format bellow 
		//|Container Type|
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, the following container types (should|should not) be displayed from the drop down list:")]
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

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, an error message (should|should not) be displayed")]
		public void ConfirmNoErrorMessagesOnUPCPage(string condition)
		{
			new Steps_Prototype().NoErrorMessages(condition);
		}

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, click 'sample file' link to download file")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionClickSampleFileLink()
		{
			string link = "sample file";
			new Steps_Prototype().ClickLinkElement(link);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, confirm 'sample file' is downloaded and save as: (.*)")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionFileIsDownloaded(string savedAs)
		{
			string fileName = "Sample.xlsx";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(fileName, savedAs);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, click 'Upload File' button and upload file saved as: (.*)")]
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
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, confirm 'Add Multiple' modal window (should|should not) be displayed")]
		public void ThenInTheU_S_DepartmentOfTransportationDOTClassificationSectionAddMultipleIsDisplayed(string condition)
		{
			string modalTitle = "Add Multiple";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal (check|uncheck) All UPCs checkbox")]
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

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal confirm all UPCs are (selected|not selected)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionConfirmAllUPCsAreSelected(string condition)
		{
			new StepsUPC().ICheckAllRetailersSelectedStatus(condition);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal select Packaging Type: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModalSelectPackagingTypePlasticContainer(string value)
		{
			new StepsUPC().InTheAddMultipleDialogBoxSelectPackagingTypeX(value);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal click 'Next' button")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModaClickNext()
		{
			new StepsUPC().InTheAddMultipleDialogBoxClickNext();
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal click 'Finish' button")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionAtModaClickFinish()
		{
			new StepsUPC().InTheAddMultipleDialogBoxClickFinish();
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, at 'Add Multiple' modal (check|uncheck) retailer: (.*)")]
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

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, error message (should|should not) be displayed with text: 'You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please remove the instances of duplicate UPC\(s\) from the necessary registration data.'")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionErrorMessageShouldBeDisplayedWithText(string condition)
		{
			string alertText = "You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please remove the instances of duplicate UPC(s) from the necessary registration data.";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}

		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, confirm the values on the new product screen are the same as the UPC Upload document saved in the Table called: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionConfirmTheValuesOnTheNewProductScreenAreTheSameAsTheUPCUploadDocumentSavedInTheTableCalledUPCTable(string tableSavedAs)
		{
			Report.StartStep("I confirm the UPC numbers and sizes are the same as the upload document");
			var listDisplayedUPCs = new UPC().UPCsNewProduct;
			if (Context.Contains(tableSavedAs))
			{
				var tableContent = (Table)Context.GetFromContext(tableSavedAs);
				int i = 0;

				bool successIsTrue = true;
				foreach (var row in tableContent.Rows)
				{
					var upcNumber = row["UPC"];

					var size = row["Size"];

					var displayedSize = listDisplayedUPCs[i].Size;

					upcNumber = Context.GetFromContextRegex(upcNumber)?.ToString() ?? upcNumber;

					var displayedUpcNumber = listDisplayedUPCs[i].UpcNumber;

					if (displayedUpcNumber != upcNumber)
					{
						Report.Failure($"The Value for UPC number did not match. The displayed value was: {displayedUpcNumber}. The UPC number in the document was: {upcNumber}.");
						successIsTrue = false;
					}
					if (displayedSize != size)
					{
						Report.Failure($"The Value for size did not match. The displayed value was: {displayedSize}. The Size in the document was: {size}.");
						successIsTrue = false;
					}
					i++;
				}
				Report.IsTrue(successIsTrue, "Not all Values matched the UPC upload document", "All Values matched the UPC upload document");
				return;
			}

			Report.Failure($"The table {tableSavedAs} was not found in context");
		}

		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, confirm Warning Icon (is|is not) displayed for UPC: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionConfirmWarningIconIsIsNotDisplayedForUPCRandomUPC(string is_isnot, string upcNumber)
		{
			upcNumber = (string)Context.GetFromContext(upcNumber);

			bool expected = is_isnot == "is";
			if (Report.IsTrue(new GTIN_UPC_TableRow(upcNumber) != null, $"Failure, row with '{upcNumber}' does not exist.", $"Success, row with '{upcNumber}' exists."))
			{
				Report.IsTrue(new GTIN_UPC_TableRow(upcNumber).WarningIconExists() == expected, $"Failure, Warning Icon {(expected ? "is not" : "is")} displayed.", $"Success, Warning Icon {is_isnot} displayed.");
			}
		}
		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, (check|uncheck) checkbox for UPC: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionSelectCheckboxForUPCRandomUPC(string check_uncheck, string upcNumber)
		{
			upcNumber = (string)Context.GetFromContext(upcNumber);
			if (check_uncheck == "check")
			{
				if (!new GTIN_UPC_TableRow(upcNumber).CheckboxSelected())
				{
					Report.IsTrue(new GTIN_UPC_TableRow(upcNumber).ClickCheckbox(), $"Failed to check UPC '{upcNumber}'", $"Successfully checked UPC '{upcNumber}'");
				}
				else
				{
					Report.Success($"UPC '{upcNumber}' is already selected");
				}
			}
			else
			{
				if (new GTIN_UPC_TableRow(upcNumber).CheckboxSelected())
				{
					Report.IsTrue(new GTIN_UPC_TableRow(upcNumber).ClickCheckbox(), $"Failed to uncheck UPC '{upcNumber}'", $"Successfully unchecked UPC '{upcNumber}'");
				}
				else
				{
					Report.Success($"UPC '{upcNumber}' is already deselected");
				}
			}
		}
		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, confirm UPC number saved as (.*) is duplicated and Warning Icons are displayed")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionConfirmUPCNumberSavedAsRandomUPCIsDuplicatedAndWarningIconsAreDisplayed(string upcNumber)
		{
			upcNumber = (string)Context.GetFromContext(upcNumber);
			List<string> expectedDuplicatedUPCs = new List<string>();
			expectedDuplicatedUPCs.Add(upcNumber);
			expectedDuplicatedUPCs.Add(upcNumber);
			Report.IsTrue(Enumerable.SequenceEqual(new GTIN_UPC_Table().DuplicatedUPCs(), expectedDuplicatedUPCs), $"Faild to confirm UPC {upcNumber} is duplicated", $"Successfully confirmed UPC {upcNumber} is duplicated");
		}
		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, check all UPCs with number: (.*)")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionCheckAllUPCsWithNumberRandomUPC(string upcNumber)
		{
			upcNumber = (string)Context.GetFromContext(upcNumber);
			Report.IsTrue(new GTIN_UPC_Table().CheckAllUpcWithNumber(upcNumber), $"Faild to select all UPCs with number {upcNumber}", $"Successfully selected all UPCs with number {upcNumber}");
		}
		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, click 'Delete Rows' button")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionClickButton()
		{
			new StepsUPC().IClickDeleteRows();
		}
		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, confirm Warning modal window (should|should not) be displayed")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionConfirmWarningModalWindowIsDisplayed(string condition)
		{
			string title = "Warning!";
			string text = "You are about to delete 2 UPC's.\r\nDo you want to proceed?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, title, text);
		}
		[RegexStepDefinition("In the Global Trade Item Number \\(GTIN\\) / Universal Product Code \\(UPC\\) Section, in Warning modal window click 'Ok' button")]
		public void ThenInTheGlobalTradeItemNumberGTINUniversalProductCodeUPCSectionInWarningModalWindowClickButton()
		{
			string title = "Warning!";
			string button = "Ok";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(title, button);
		}
		
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'GTIN/UPC (include check digit)' enter the value: (.*)")]
		public void EnterUPCGTIN(string option)
		{
			string section = "GTIN/UPC (include check digit)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Product Name on Label' enter the value: (.*)")]
		public void EnterUPCProductNameOnLabel(string option)
		{
			string section = "Product Name on Label";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Size \(Fluid Ounces\)' enter the value: (.*)")]
		public void EnterUPCSize(string option)
		{
			Report.IsTrue(new NewProduct().InputUPCSize(option), $"Failed to enter size: {option}", $"Entered size: {option}");
		}

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Internal SKU' enter the value: (.*)")]
		public void EnterInternalSKU(string option)
		{
			string section = "Internal SKU";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, section: 'Internal SKU' (should|should not) display error message: (.*)")]
		public void InternalSKUShouldShouldNotDisplayErrorMessage(string shouldShouldNot, string errorMessage)
		{
			string section = "Internal SKU";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, errorMessage);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Tablet or Capsule Count' enter the value: (.*)")]
		public void EnterTabletOrCapsuleCount(string option)
		{
			string section = "Tablet or Capsule Count";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, section: 'Tablet or Capsule Count' (is|is not) displayed")]
		public void TabletOrCapsuleIsDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			string section = "Tablet or Capsule Count";
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.UPCSectionFieldsAvailable(section) == expected, $"Failed to Confirm the '{section}' field {(expected ? "is not" : "is")} available", $"I Confirm the '{section}' field {is_isnot} available");
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, section: 'Part Number' (is|is not) displayed")]
		public void PartNumberIsDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			string section = "Part Number";
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.UPCSectionFieldsAvailable(section) == expected, $"Failed to Confirm the '{section}' field {(expected ? "is not" : "is")} available", $"I Confirm the '{section}' field {is_isnot} available");
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Part Number' enter the value: (.*)")]
		public void EnterPartNumber(string option)
		{
			string section = "Part Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Global Trade Item Number \(GTIN\) / Universal Product Code \(UPC\) Section, for section: 'Container Type' select the value: (.*)")]
		public void EnterContainerType(string option)
		{
			Report.IsTrue(new NewProduct().SelectContainerType(option),
				$"Failed to select: {option}", $"Selected: {option}");
		}
	}
}

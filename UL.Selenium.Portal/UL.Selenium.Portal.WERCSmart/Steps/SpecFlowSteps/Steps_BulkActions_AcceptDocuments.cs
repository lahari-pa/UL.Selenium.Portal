using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "BulkActions:AcceptDocuments")]

	class Steps_BulkActions_AcceptDocuments
	{
		[RegexStepDefinition(@"In the Document Acceptance section, verify text: 'When creating the registration you indicated a Safety Data Sheet \(SDS\), or your Retailer has required an authored SDS. The SDS that UL Information & Insights has written, based on your registration data, is now available. Please review the document.' (is|is not) displayed")]
		public void VerifyDocumentAcceptanceText(string is_isnot)
		{
			string text = "When creating the registration you indicated a Safety Data Sheet (SDS), or your Retailer has required an authored SDS. The SDS that UL Information & Insights has written, based on your registration data, is now available.  Please review the document. You may edit (reject) and upload revisions, or accept “as is”.";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);

		}
		[RegexStepDefinition(@"In the Document Acceptance section, click the (Approve SDS|Edit SDS) button")]
		public void DocumentAcceptanceClickButton(string button)
		{
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Document Acceptance section, confirm the 'Approve SDS' modal window (is|is not) displayed")]
		public void InTheDocumentAcceptanceTheApproveSDSModalIsDisplayed(string is_isnot)
		{
			string modalTitle = "Approve SDS";
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.ConfirmModalIsIsNotDisplayed(modalTitle, is_isnot);
		}
		[RegexStepDefinition(@"In the Document Acceptance section, confirm the 'Edit SDS' modal window (is|is not) displayed for product saved as: (.*)")]
		public void InTheDocumentAcceptanceTheEditSDSModalIsDisplayed(string is_isnot, string savedAs)
		{
			Report.Info("Attempting to get product from context");
			if (!Context.Contains(savedAs))
			{
				Report.Failure($"Context did not contain the Product saved as: {savedAs}");
			}
			else
			{
				Report.Info("Found in Context");
			}
			var obj = Context.GetFromContext(savedAs);
			Report.Info("Attempting to convert Product to type ProductInformation");
			var Product = (ProductInformation)obj;
			string modalTitle = "Edit SDS (" + Product.Id + ")";
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.ConfirmModalIsIsNotDisplayed(modalTitle, is_isnot);
		}
		[RegexStepDefinition(@"In the Document Acceptance section, in the 'Edit SDS' modal click '(Submit|Cancel)' footer button")]
		public void ModalSDSModalClickCancelFooterButton(string buttonLabel)
		{
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.DisplayedModalClickFooterButton(buttonLabel);
		}
		[RegexStepDefinition(@"In the Document Acceptance section, in the 'Approve SDS' modal click '(Submit|Cancel)' footer button")]
		public void ModalApproveSDSModalClickCancelFooterButton(string buttonLabel)
		{
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.DisplayedModalClickFooterButton(buttonLabel);
		}
		[RegexStepDefinition(@"In the Document Acceptance section, in the 'My Products' table the row with WPS ID and Product Name (is|is not) displayed for product saved as: (.*)")]
		public void MyProductTableRow(string is_isnot, string savedAs)
		{
			bool expected = is_isnot == "is";

			if (!Context.Contains(savedAs))
			{
				Report.Failure($"Context did not contain the Product saved as: {savedAs}");
			}
			else
			{
				Report.Info("Found in Context");
			}
			var obj = Context.GetFromContext(savedAs);
			Report.Info("Attempting to convert Product to type ProductInformation");
			var Product = (ProductInformation)obj;
			if (Report.IsTrue(new MyProductTableRow(Product.Id).MyProductTableRowExists() == expected, $"Failed to confirm row with product id {Product.Id} {is_isnot} displayed", $"Successfully confirmed row with product id {Product.Id} {is_isnot} displayed"))
			{
				if (is_isnot == "is")
				{
					if (Report.IsTrue(new MyProductTableRow(Product.Id).ProductNameExists(), $"Failed to confirm the product name exists in the row", $"Successfully confirmed the product name exists in the row"))
					{
						Report.IsTrue(new MyProductTableRow(Product.Id).GetProductName() == Product.Name, $"Failed to confirm the displayed product name is {Product.Name}", $"Successfully confirmed the displayed product name is {Product.Name}");
					}
				}
			}
		}
		[RegexStepDefinition(@"In the Document Acceptance section, in the 'Documents' table, click the 'View' link for document with Subformat: (.*) and Language: (.*)")]
		public void DocumentsTableClickTheView(string subFormat, string language)
		{
			if (Report.IsTrue(new DocumentsTableRow(subFormat, language).DocumentsTableRowExists(), $"Failed to confirm row with the subformat '{subFormat}' and the language '{language}' is displayed", $"Successfully confirmed row with the subformat '{subFormat}' and the language '{language}' is displayed"))
			{
				if (Report.IsTrue(new DocumentsTableRow(subFormat, language).ViewLinkExists(), $"Failed to confirm the 'View' link exists", $"Successfully confirmed the 'View' link exists"))
				{
					Report.IsTrue(new DocumentsTableRow(subFormat, language).ViewLinkClick(), $"Failed to click the 'View' link", $"Successfully clicked the 'View' link");
				}
			}
		}
		[RegexStepDefinition(@"In the Document Acceptance section, after clicking the 'View' link for document, PDF file is downloaded")]
		public void DocumentsTablePDFIsDownloaded()
		{
			string file = "published_by_wercs.pdf";
			string savedAs = "documentFile";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
	}
}

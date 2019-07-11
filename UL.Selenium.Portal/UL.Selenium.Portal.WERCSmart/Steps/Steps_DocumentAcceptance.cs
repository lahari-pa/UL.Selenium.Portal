using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "DocumentAcceptance")]
	class Steps_DocumentAcceptance
	{
		[StepDefinition(@"I confirm there are products listed under My Products on the Document Acceptance page and save as: (.*)")]
		public void ConfirmThereAreProductsListedUnderMyProducts(string savedAs)
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			var products = selDocumentAcceptance.GetProducts();
			Context.AddToContext(savedAs, products);
			Report.IsTrue(products.Any(),
				"No products were listed under My Products!",
				"There were products listed under My Products");
		}

		[StepDefinition(@"I select the first product from My Products saved as: (.*) which contains a document")]
		public void SelectFirstProductFromMyProductsWithDocument(string savedAs)
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			var products = (List<DocumentAcceptance.MyProductsItem>)Context.GetFromContext(savedAs);
			foreach (var product in products)
			{
				var documents = selDocumentAcceptance.GetDocuments();
				if (product.Click() && GeneralUtilities.Wait_for_load_finish() && documents.Any())
				{
					Report.Success("Selected product: " + product.ProductName + " (" + product.WPSID + ") which displayed document(s)");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to select a product which displayed a document");
			Report.Screenshot();
		}

		[StepDefinition(@"I save the displayed Documents on the Document Acceptance page as: (.*)")]
		public void SaveDisplayedDocumentsOnDocumentsAcceptancePage(string savedAs)
		{
			var selDocumentsAcceptance = new DocumentAcceptance();
			var documents = selDocumentsAcceptance.GetDocuments();
			Report.Info("Saving " + documents.Count + " documents to context as: " + savedAs);
			Context.AddToContext(savedAs, documents);
		}

		[StepDefinition(@"I confirm the Subformat column appears as part of the Documents Information")]
		public void ConfirmSubformatColumnAppearsUnderDocumentInformation()
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			Report.IsTrue(selDocumentAcceptance.DocumentsGridHeadings().Contains("Subformat"),
				"The Subformat column is not displayed in the Documents grid!",
				"The Subformat column is displayed in the Documents grid as expected");
		}

		[StepDefinition(@"I click on View under Actions for the first document from the list saved as: (.*)")]
		public void ClickViewUnderActionsForTheFirstDocumentDisplayed(string savedAs)
		{
			var documents = (List<DocumentAcceptance.DocumentsItem>)Context.GetFromContext(savedAs);
			if (documents == null)
			{
				Report.Failure("Unable to find the documents list in context saved as: " + savedAs);
				return;
			}
			var viewDocument = documents.First();
			Context.AddToContext("ViewDocument", viewDocument);
			Report.IsTrue(viewDocument.ClickAction("View"),
				"Failed to click 'view' for document: " + documents.First().FileName,
				"Successfully clicked 'view' for document: " + documents.First().FileName);
		}

		[StepDefinition(@"I confirm a new window opens displaying the document url: (.*)")]
		public void ConfirmANewWindowOpensDisplayingTheDocument(string option)
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			Report.IsTrue(selDocumentAcceptance.DocumentWindowOpen(option),
				"A window contianing the document did not open!",
				"A window containing the document opened as expected");
		}

		[StepDefinition(@"I close the document window: (.*)")]
		public void CloseTheDocumentWindow(string option)
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			Report.IsTrue(selDocumentAcceptance.CloseDocumentWindow(option),
				"Failed to close the document window",
				"Successfully closed the document window");
		}

		[StepDefinition(@"I switch to the main window")]
		public void ISwitchToMainWindow()
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			Report.IsTrue(selDocumentAcceptance.SwitchToMainWindow(),
				"Failed to switch to the main window",
				"Successfully switched to the main window");
		}

		[StepDefinition(@"I confirm the subformat type at the top of the document matches the vaulue in the Documents table for the first document I viewed")]
		public void ConfirmSubformatTypeInDocumentMatchesDocumentsTableValue()
		{
			var selDocumentsAcceptance = new DocumentAcceptance();
			var document = (DocumentAcceptance.DocumentsItem)Context.GetFromContext("ViewDocument");
			if (document == null)
			{
				Report.Failure("Unable to find the document in context saved as: ViewDocument");
				return;
			}
			var subFormat = document.Subformat;
			// download file to C:\temp\GetFile.pdf
			var address = @"C:\temp\GetFile.pdf";
			var documentText = selDocumentsAcceptance.DocumentText(address);
			var break_ = "";
		}
	}
}

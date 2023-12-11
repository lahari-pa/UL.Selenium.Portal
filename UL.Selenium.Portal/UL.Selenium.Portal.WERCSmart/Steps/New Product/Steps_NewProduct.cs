using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.GenerateIntentionallyBadData;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit;
using UL.Automation.Utilities.Helpers;
using Mailosaur;
using UL.Automation.Utilities.Helpers;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsNewProduct
	{
		private static NewProduct NewProduct => new NewProduct();

		[StepDefinition(@"I check if the logo is displayed for the following retailers")]
		public void ThenICheckIfTheLogoIsDisplayedForTheFollowingRetailers(Table table)
		{
			NewProduct newProductObject = new NewProduct();
			List<string> retailersThatAreNotDisplayingTheirLogo = newProductObject.CheckIfRetailerLogoIsDisplayed(table);
			Report.IsTrue(retailersThatAreNotDisplayingTheirLogo.Count == 0, "One or more retailers did not display their logos", "All retailers are displaying their logos");

			foreach (string retailer in retailersThatAreNotDisplayingTheirLogo)
			{
				Report.Info("Retailer that did not display their logo: " + retailer);
			}

		}

		[StepDefinition(@"I check if a checkmark image is displayed above the following retailers")]
		public void ThenICheckIfACheckmarkImageIsDisplayedAboveTheFollowingRetailers(Table table)
		{
			NewProduct newProductObject = new NewProduct();
			var retailersThatDoNotDisplayACheckmarkImageAboveTheirLogo = newProductObject.CheckIfCheckmarkImageIsDisplayedAboveRetailerLogo(table);
			Report.IsTrue(retailersThatDoNotDisplayACheckmarkImageAboveTheirLogo.Count == 0, "One or more retailers did not display a checkmark image above their logos", "All retailers are displaying checkmark images above their logos");

			foreach (string retailer in retailersThatDoNotDisplayACheckmarkImageAboveTheirLogo)
			{
				Report.Info("Retailer that did not display a checkmark image above: " + retailer);
			}
		}

		[StepDefinition(@"I check if a yellow triangle image is displayed above the following retailers")]
		public void ThenICheckIfAYellowTriangleImageIsDisplayedAboveTheFollowingRetailers(Table table)
		{
			NewProduct newProductObject = new NewProduct();
			var retailersThatDoNotDisplayAYellowImageAboveTheirLogo = newProductObject.CheckIfYellowTriangleImageIsDisplayedAboveRetailerLogo(table);
			Report.IsTrue(retailersThatDoNotDisplayAYellowImageAboveTheirLogo.Count == 0, "One or more retailers did not display a yellow triangle image above their logos", "All retailers are displaying yellow triangle images above their logos");

			foreach (string retailer in retailersThatDoNotDisplayAYellowImageAboveTheirLogo)
			{
				Report.Info("Retailer that did not display a yellow triangle image above: " + retailer);
			}
		}

		[StepDefinition(@"I check if a 'Scope' button is displayed below the following retailers")]
		public void ThenICheckIfAScopeButtonIsDisplayedBelowTheFollowingRetailers(Table table)
		{
			NewProduct newProductObject = new NewProduct();
			var retailersThatDoNotDisplayAScopeButtonBelowTheirLogo = newProductObject.CheckIfScopeButtonIsDisplayedBeloweRetailerLogo(table);
			Report.IsTrue(retailersThatDoNotDisplayAScopeButtonBelowTheirLogo.Count == 0, "One or more retailers did not display a 'Scope' button below their logos", "All retailers are displaying a 'Scope' button below their logos");

			foreach (string retailer in retailersThatDoNotDisplayAScopeButtonBelowTheirLogo)
			{
				Report.Info("Retailer that did not display a 'Scope' button below: " + retailer);
			}
		}

		[StepDefinition(@"I check if the retailer modal is displayed for the following retailer: (.*)")]
		public void ThenICheckIfTheRetailerModalIsDisplayedForTheFollowingRetailerCT(string retailer)
		{
			NewProduct newProductObject = new NewProduct();
			Report.IsTrue(newProductObject.ClickScopeButtonBelowRetailerLogo(retailer), "Failed to click 'Scope' button", "Successfully clicked 'Scope' button");
			Delay.Seconds(3);
			Report.IsTrue(newProductObject.CheckIfRetailerModalIsDisplayed(), "Failed to display retailer modal", "Successfully displayed retailer modal");
		}

		[StepDefinition(@"I check if the retailer modal is displaying the following text: (.*)")]
		public void ThenICheckIfTheRetailerModalIsDisplayingTheFollowingText(string retailerModalText)
		{
			NewProduct newProductObject = new NewProduct();
			Report.IsTrue(newProductObject.CheckRetailerModalText(retailerModalText), "The reatiler modal text did not match", "The retailer modal text did match");
		}

		[StepDefinition(@"I close the retailer modal")]
		public void ThenICloseTheRetailerModal()
		{
			NewProduct newProductObject = new NewProduct();
			Report.IsTrue(newProductObject.CloseRetailerModal(), "Failed to close retailer modal", "Successfully closed retailer modal");
		}

		[StepDefinition(@"I hover over the yellow triangle image for retailer: (.*)")]
		public void ThenIHoverOverTheYellowTriangleImage(string retailer)
		{
			NewProduct newProductObject = new NewProduct();
			Report.IsTrue(newProductObject.HoverOverYellowTriangleImage(retailer), "Failed to hover over the yellow triangle image", "Successfully hovered over the yellow triangle image");
		}


		[Then(@"I check if the text displayed over the yellow triangle image matches the following text: (.*)")]
		public void ThenICheckIfTheTextDisplayedOverTheYellowTriangleImageMatchesTheFollowingText(string textToMatch)
		{
			NewProduct newProductObject = new NewProduct();
			Report.IsTrue(newProductObject.CheckIfTextDisplayedOverYellowTriangleImageMatches(textToMatch), "The text over the yellow triangle image did not match the following text: " + textToMatch, "The text over the yellow trangle image did match the following text " + textToMatch);
		}



		#region  General New Product steps

		// Definitions, for consistency
		// * 'Tab' is the major step on the progress wizard [html: 'prog-step']
		//		eg. Product Type|Product Characteristics|Recipient and UPC Details|Review and Submit
		// * 'Page' is the minor step within a Tab [html: 'step-panel']
		//		eg. The Product, Product Information, Ingredients, Retailers...
		// * 'Section' is the individual input/ question within a Page [html: 'form-group']
		//		eg. 'Product name', 'Type of product', pH...

		[StepDefinition(@"In the New Product page I click tab: (Product Type|Physical and Chemical Properties|Product Characteristics|Retailer Association|Recipient and UPC Details|Review and Submit)")]
		public void GivenInTheNewProductPageIClickTab(string tabName)
		{
			try
			{
				NewProduct.Tab tab = NewProduct.MapTabs.FirstOrDefault(x => x.Value == tabName).Key;
				Report.IsTrue(NewProduct.ClickTab(tab), "Failed to click tab: " + tab, "Successfully clicked tab: " + tab);
			}
			catch (NullReferenceException)
			{
				Report.Failure("The parameter 'tab' did not match a valid tab title");
				throw;
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}

		}

		[StepDefinition(@"In the New Product page I (should|should not) be on tab: (Product Type|Product Characteristics|Recipient and UPC Details|Review and Submit)")]
		public void GivenInTheNewProductPageICpmfirmActiveTab(string present, string tabName)
		{
			try
			{
				bool showing = present == "should";
				NewProduct.Tab tab = NewProduct.MapTabs.FirstOrDefault(x => x.Value == tabName).Key;
				Report.IsTrue(!(NewProduct.IsActiveTab(tab) ^ showing), $"Failed, {present} be on tab {tabName}.", $"Success, {present} be on tab {tabName}.");
			}
			catch (NullReferenceException)
			{
				Report.Failure("The parameter 'tab' did not match a valid tab title");
				throw;
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the page heading: (.*)")]
		public void ClickPageHeading(string section)
		{
			Delay.Seconds(10);
			GeneralUtilities.Wait_for_load_finish();

			//if current section == section return
			if (NewProduct.ActivePanelHeadingText() == section)
			{
				Report.Info("The panel: " + section + " is already active");
				return;
			}
			Report.IsTrue(NewProduct.ClickSection(section), "Failed to click section: " + section, "Successfully clicked section: " + section);
			GeneralUtilities.Wait_for_load_finish();
			Delay.Seconds(10);
			//this.GivenIShouldSeeXPage(section);
		}

		[StepDefinition(@"the Product Editor page should be loaded")]
		public void ProductEditorShouldBeLoaded()
		{
			Report.IsTrue(NewProduct.WaitForContainerToBeVisible(), "The Product Registration page did not load!", "The Product Registration page loaded successfully!");
		}

		[StepDefinition(@"I click continue")]
		public void ClickContinue()
		{
			int i = 0;
			while (i < 5)
			{
				if (NewProduct.ClickContinue())
				{
					Report.Success("Clicked 'Continue' successfully");
					Report.Screenshot();
					return;

				}
				Report.Info($"Failed to click continue on attempt: {i + 1}");
				i++;
			}
			Report.Failure("Failed to click 'Continue'!");
			Report.Screenshot();
			//Report.IsTrue(NewProduct.ClickContinue(), "Failed to click 'Continue'!", "Clicked 'Continue' successfully");
		}

		[StepDefinition(@"in the (.*) page I click Continue")]
		public void GivenInTheNewProductPageIClickContinue(string page)
		{
			if (!NewProduct.WaitForContainerToBeVisible())
			{
				Report.Failure("New Product page is not loaded");
				return;
			}
			if (page.ToLower() != "new product" && !NewProduct.WaitForSection(page))
			{
				Report.Error($@"The page title did not match expected! Expected ""{page}""");
			}
			Report.Info("Clicking Continue");
			Report.IsTrue(NewProduct.ClickContinue(), "Failed to click continue in the new product page!", "Successfully clicked continue in the new product page");
			if (page == "The Product" && NewProduct.HeaderText == "The Product")
			{
				Report.Info("The active page is still 'The Product' after clicking continue");
				Report.Info("Checking for Raw Materials Warning pop up");
				var thisModalDialog = new ModalDialog();
				if (!thisModalDialog.WaitForContainerToBeVisible() || thisModalDialog.GetTitle() != "Warning")
				{
					Report.Failure("Failed to click continue to the next page!");
					return;
				}
				Report.IsTrue(thisModalDialog.Click_OK(), "Failed to click OK in the modal", "Clicked OK in the modal");
			}
		}

		[StepDefinition(@"I should see the (.*) Page")]
		[StepDefinition(@"I should see the (.*) Page for the New Product")]
		public void GivenIShouldSeeXPage(string page)
		{
			if (NewProduct.WaitForContainerToBeVisible())
			{
				Report.IsTrue(NewProduct.WaitForSection(page),$"{ page } is not showing when it was expected to", $"{page } is showing as expected");
				return;
			}
			Report.Failure("New product page was not visible");
			Report.Screenshot();
		}


		[StepDefinition(@"I wait (.*) seconds for the (.*) Page to load")]
		public void IWaitXSecondsForYPageToLoad(int seconds, string page)
		{
			if (NewProduct.WaitForContainerToBeVisible())
			{
				Report.IsTrue(NewProduct.WaitForSection(page,seconds), page + " is not showing when it was expected to", page + " is showing as expected");
				return;
			}
			Report.Failure("New product page was not visible");
			Report.Screenshot();
		}

		[StepDefinition(@"I should see an error message: (.*)")]
		public void ErrorMessageSpecific(string message)
		{
			Report.Info("Checking error message");
			List<string> errors = NewProduct.ErrorMessagesText;
			if (!errors.Any())
			{
				Report.Failure("No errors were found but expected error: " + message);
				Report.Screenshot();
				return;
			}
			Report.IsTrue(errors.Contains(message),
				$"Error message was not as expected! Expected: '{message}', but found: '{string.Join(", ", errors)}'!",
				$"Error message was showing: '{message}', as expected");
		}

		[StepDefinition(@"I should see a list style form error with text: (.*)")]
		public void ShouldSeeAlistFormError(string error)
		{
			var errorActual = new NewProduct().FormError();
			Report.IsTrue(errorActual.Contains(error), "The expected error was not found! The error text found was: " + errorActual, "Found expected error");
		}

		[StepDefinition(@"in page (.*) I should see error: (.*)")]
		public void InPageIShouldSeeError(string page, string error)
		{
			Report.Info("Checking error on page: " + page);
			this.ErrorMessageSpecific(error);
		}

		[StepDefinition(@"I should not see an error message: (.*)")]
		public void NotErrorMessageSpecific(string message)
		{
			List<string> errors = NewProduct.ErrorMessagesText;
			Report.IsTrue(!errors.Contains(message), "Error message was showing when it wasn't expected to! Error: " + message, "As expected, the error message was not showing. Error: " + message);
		}

		[StepDefinition(@"in page (.*) I should see no errors")]
		public void InPageIShouldSeeNoErrors(string page)
		{
			this.NoErrorMessages();
		}

		[StepDefinition(@"I should not see any error messages")]
		public void NoErrorMessages()
		{
			List<string> errors = NewProduct.ErrorMessagesText;
			if (!errors.Any())
			{
				Report.Success("As expected, the error message was not showing.");
				Report.Screenshot();
				return;
			}
			Report.Failure("Error message was showing when it wasn't expected to! Error(s): " + string.Join(", ", errors));
			Report.Screenshot();
		}

		[StepDefinition(@"I should see the header (.*)")]
		public void CorrectHeaderShouldBeShowing(string header)
		{
			if (!NewProduct.WaitForContainerToBeVisible())
			{
				throw new Exception("Page failed to load!");
			}
			string displayedHeader = NewProduct.HeaderText;
			Report.IsTrue(displayedHeader.Trim() == header.Trim(),
				"Header was not showing as expected! Expected: '" + header + "', but found: '" + displayedHeader + "'!",
				"Header was showing: '" + header + "', as expected!");
		}

		[StepDefinition(@"I click the (.*) input section in Optional Reports and Documents Available for Purchase and select (.*)")]
		public void IClickTheInputSectionAndSelect(string section, string selection)
		{
			var reports = new OptionalReports();

			Report.IsTrue(reports.SelectInputForSection(section, selection), "Failed to select input '" + selection + "' for section '" + section + "'.",
				"Successfully selected input '" + selection + "' for section '" + section + "'.");
		}

		[StepDefinition(@"The total for section (.*) in Optional Reports and Documents Available for Purchase should equal (.*)")]
		public void TotalForSectionShouldEqual(string section, string value)
		{
			var reports = new OptionalReports();

			Report.IsTrue(reports.CheckTotalForSection(section, value), "Failed to find the correct value '" + value + "' for section '" + section + "'.",
				"Successfully found correct value '" + value + "' for section '" + section + "'.");
		}

		[StepDefinition(@"I confirm the document type is: (.*) for section: (.*)")]
		public void ConfirmDocumentTypeForSection(string type, string section)
		{
			Report.IsTrue(new NewProduct().GetDocumentTypeForSection(section) == type,
				$"Document type for section: '{section}' did not match expected type! Expected: {type}",
				$"Document type for section: '{section}' matched the expected type");
		}

		#endregion

		#region Unsorted steps
		[StepDefinition(@"the product saved as: (.*) should be visible in editor")]
		public void CorrectProductVisibleInEditor(string savedAs)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Product saved as " + savedAs + " is visible in editor");
			try
			{
				Report.Info("Checking that the product saved as " + savedAs + " is visible in editor");
				var product = (ProductGridItem)Context.GetFromContext(savedAs);
				Report.Info("Checking that Product with ID: '" + product.ProductId + "' is visible!");
				string expectingToFind = product.ProductName + " (" + product.ProductId + ")";
				Report.Info("Expecting to find string: '" + expectingToFind + "'");
				var selNewProduct = new NewProduct();
				string currentlyShowing = selNewProduct.GetCurrentProduct();
				Report.Info("Found: '" + currentlyShowing + "'");
				Report.IsTrue(expectingToFind.Trim() == currentlyShowing.Trim(), "Value was not as expected!", "Product was showing correctly in the editor!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I create a shell product with name (.*) saved as (.*)")]
		public void CreateShellProduct(string name, string savedAs)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Creating shell product with name " + name + ", saved as " + savedAs);
			try
			{
				Report.Info("Creating shell product with name " + name + ", saved as " + savedAs);
				var selNewProduct = new NewProduct();
				if (!selNewProduct.WaitForContainerToBeVisible(10))
				{
					throw new Exception("Page failed to load!");
				}
				Report.Info("Selecting 'Yes, create a new product'");
				// Creates a New Product
				selNewProduct.CreateNewProductOrCopy(true);
				Report.Screenshot();
				Report.Info("Clicking continue");
				Report.IsTrue(selNewProduct.ClickContinue(), "Failed to click 'Continue'!");
				Report.Info("Inputting Name: '" + name + "'");
				new TheProduct().ProductName = name;
				Report.Info("Setting Product Type to be: 'Game System w/Battery'");
				new TheProduct().ProductType = "Game System w/Battery";
				Report.Screenshot();
				Report.Info("Clicking continue");
				Report.IsTrue(selNewProduct.ClickContinue(), "Failed to click 'Continue'!");
				Report.Info("Getting Product ID");
				string fullProductName = selNewProduct.HeaderText;
				// Product Name made out of the name + the Id - so if we remove the Name from the product we should be left with an ID!
				string productId = fullProductName.Replace(name, "").Replace("(", "").Replace(")", "").Trim();
				Report.Info("ProductID was: '" + productId + "'");
				var productEntry = new ProductGridItem {
					ProductId = productId,
					ProductName = name.Trim()
				};
				Context.AddToContext(savedAs, productEntry);
				Report.Success("Product created successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see battery manufacturer message: (.*)")]
		public void ThenIShouldSeeBatteryManufacturerMessage(string message)
		{
			Report.Info("Checking error message");
			var selNewProduct = new NewProduct();
			string found = selNewProduct.BatteyWarning();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Warning message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Warning message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I click Continue and should not see an error message")]
		public void NoErrorMessagesVisible()
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.ClickContinueNoError(), "An error message appeared when it should not", "No error message appeared as expected");
		}

		[StepDefinition(@"In the Review and Submit tab of the New Product Page for Volatile Organic Compounds I upload pdf file")]
		public void ThenInTheReviewAndSubmitTabOfTheNewProductPageForVolatileOrganicCompoundsIUploadPdfFile()
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.ClickBrowseForVolatileOrganicCompounds(), "Failed to upload ", "Successfully upload ");
		}

		[StepDefinition(@"I click the browse button for document type: (.*) and for control label: (.*) and upload PDF: (.*)")]
		public void UploadPDFFileSectionAndType(string type, string label, string pdfFile)
		{
			pdfFile = EmbeddedResourceHelpers.ExtractToFile(pdfFile, out string extractFile) ? extractFile : pdfFile;
			Report.IsTrue(new NewProduct().UploadFileForSectionAndType(type, label, pdfFile), "Failed to upload PDF file: " + pdfFile, "Successfully uploaded PDF file: " + pdfFile);

		}

		[StepDefinition(@"I click the browse button for label: (.*) and upload PDF: (.*)")]
		public void UploadPDFFile(string label, string pdfFile)
		{
			pdfFile = EmbeddedResourceHelpers.ExtractToFile(pdfFile, out string extractFile) ? extractFile : pdfFile;
			Report.IsTrue(new NewProduct().UploadFileForSection(label, pdfFile), "Failed to upload PDF file: " + pdfFile, "Successfully uploaded PDF file: " + pdfFile);
		}

		[StepDefinition(@"I click the browse button for document type: (.*) and for control label: (.*) and upload a PDF")]
		public void UploadPDFFileSectionAndTypeEmbedded(string type, string label)
		{
			var pdfFile = EmbeddedResourceHelpers.ExtractToFile("UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf", out string extractFile) ? extractFile : @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			Report.IsTrue(new NewProduct().UploadFileForSectionAndType(type, label, pdfFile), "Failed to upload PDF file: " + pdfFile, "Successfully uploaded PDF file: " + pdfFile);
		}

		[StepDefinition(@"I click the browse button for label: (.*) and upload a PDF")]
		public void UploadPDFFileEmbedded(string label, string pdfFile)
		{
			pdfFile = EmbeddedResourceHelpers.ExtractToFile("UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf", out string extractFile) ? extractFile : @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			Report.IsTrue(new NewProduct().UploadFileForSection(label, pdfFile), "Failed to upload PDF file: " + pdfFile, "Successfully uploaded PDF file: " + pdfFile);
		}

		//[Given(@"I Confirm that the Add Multiple window openswith the UPCs that were added in the document")]
		//public void GivenIConfirmThatTheAddMultipleWindowOpenswithTheUPCsThatWereAddedInTheDocument()
		//{
		// Report.IsTrue(new UPC().VerifyUPCsInAddMultipleWindow(), "UPCs were unable to be verirfied.", "UPCs have been verified successfully.");
		//}


		[StepDefinition(@"I purchase the following additional documents:")]
		public void ThenIPurchaseTheFollowingAdditionalDocuments(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				Report.IsTrue(new NewProduct().AddDocument(row["Document Name"], row["Language"]), "Failed to add document: " + row["Document Name"], "Succesfully added document: " + row["Document Name"], false, false);
			}

			Report.Screenshot();
		}

		[StepDefinition(@"the following additional documents should be selected:")]
		public void TheFollowingAdditionalDocumentsShouldBeSelected(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				Report.IsTrue(new NewProduct().AddDocument(row["Document Name"], row["Language"]), "Failed to add document: " + row["Document Name"], "Succesfully added document: " + row["Document Name"], false, false);
			}

			Report.Screenshot();
		}

		[StepDefinition(@"the following additional documents should be showing as selected:")]
		public void TheFollowingLanguagesShouldBeSelectedCorrectly(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				List<string> languagesShowing = new NewProduct().GetSelectedLanguagesForDocument(row["Document Name"]);
				IEnumerable<string> languagesExpected = row["Language"].Split(',').Select(x => x.Trim());

				Report.Info("Languages found for " + row["Document Name"] + ": " + string.Join(", ", languagesShowing));

				foreach (string lang in languagesExpected)
				{
					Report.IsTrue(languagesShowing.Contains(lang), "Failed to find " + lang + " in the list of selected languages!", "Successfully found " + lang + " in the list of selected languages!", false, false);
				}
			}

			Report.Screenshot();
		}

		[StepDefinition(@"I should see the statement (.*)")]
		public void CorrectInitialStatementShouldAppear(string statement)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see the statement " + statement);
			try
			{
				Report.Info("Checking that I see the statement '" + statement + "'");
				var selNewProduct = new NewProduct();
				string statementShowing = selNewProduct.TopSectionLabel();
				Report.IsTrue(statementShowing.Trim() == statement.Trim(),
					"Statement was not showing as expected! Expected: '" + statement + "', but found: '" + statementShowing + "'!",
					"Statement was showing: '" + statement + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Select the Create a New Registration radio button")]
		public void GivenISelectTheCreateANewRegistrationRadioButton()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I Select the Create a New Registration radio button");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForContainerToBeVisible(10), "New product page is not loaded", "New product page is loaded.");
				selNewProduct.SelectTypeOfProductToCreate("New");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click continue in the new product page - don't wait for loading button spinner")]
		// Use when expecting a pop up on click continue - we don't need to wait for the timeout on WaitForLoad
		public void NewProductPageIClickContinueNoSpinnerWait()
		{
			Report.Info("Clicking Continue");
			Report.IsTrue(new NewProduct().ClickContinue(false), "Failed to click continue in the new product page!", "Successfully clicked continue in the new product page");
		}

		[StepDefinition(@"I save the product information as: (.*)")]
		public void SaveProductInformation(string savedas)
		{
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info("Saving product: " + prodDetails.Id + ",  " + prodDetails.Name);
			Context.AddToContext(savedas, prodDetails);
			string idname = $"{savedas}_ID";
			Context.AddToContext(idname, prodDetails.Id);
			Report.Success("Product Information saved!");
		}

		//[StepDefinition(@"I save the product Id as: (.*)")]
		//public void SaveProductId(string savedas)
		//{
		//	ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
		//	string productID = prodDetails.Id;
		//	Report.Info("Saving product ID: "+productID);
		//	Context.AddToContext(savedas, productID);
		//	Report.Success("Product ID saved!");
		//}

		[StepDefinition(@"I save the context product information as: (.*) where id is: (.*) and product name is: (.*)")]
		public void GivenISaveTheContextProductInformationAsTestCaseWhereIdIsAndProductNameIsTest(string savedas, string id, string name)
		{
			var prodDetails = new ProductInformation() { Id = id, Name = name };
			Context.AddToContext(savedas, prodDetails);
			Report.Success("Product Information saved!");
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForOSHACompliantSDSISelect(string selection)
		{
			Report.IsTrue(NewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");
			Report.Info("Setting OSHA to: " + selection);
			NewProduct.OSHA = selection;
			Report.IsTrue(NewProduct.OSHA.Contains(selection),
				"Failed to set OSHA value to: " + selection,
				"Successfully set OSHA value to: " + selection);
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.PersonalProtectionEquipmentRecommended = selection;

			Report.IsTrue(selNewProduct.PersonalProtectionEquipmentRecommended.Contains(selection),
				"Failed to set Personal Protection Equipment Recommended value to: " + selection,
				"Successfully set Personal Protection Equipment Recommended value to: " + selection);
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Autoignition I enter: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForAutoignitionISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.AutoignitionTemperature = selection;

		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.MinimumIgnitionEnergy = selection;

		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Viscosity I enter: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.Viscosity = selection;

		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Appearance I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.Appearance = selection;

			Report.IsTrue(selNewProduct.Appearance.Contains(selection),
				"Failed to set Appearance value to: " + selection,
				"Successfully set Appearance value to: " + selection);
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Odor I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.Odor = selection;

			Report.IsTrue(selNewProduct.Odor.Contains(selection),
				"Failed to set Odor value to: " + selection,
				"Successfully set Odor value to: " + selection);
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Odor Threshold I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorThresholdISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.OdorThreshold = selection;

			Report.IsTrue(selNewProduct.OdorThreshold.Contains(selection),
				"Failed to set Odor Threshold value to: " + selection,
				"Successfully set Odor Threshold value to: " + selection);
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Partition Coefficient I enter: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForPartitionCoefficientISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ReviewAndSubmit), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.PartitionCoefficient = selection;

		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForProductIsRegulatedForTransportISelect(string selection)
		{
			//NewProduct selNewProduct = new NewProduct();
			//selNewProduct.ProductIsRegulatedForTransport = selection;
			//Report.IsTrue(selNewProduct.ProductIsRegulatedForTransport == selection, "Failed to select: " + selection,
			//	"Successfully selected: " + selection);

			Report.IsTrue(new NewProduct().ProductIsRegulatedForTransport(selection), "Failed to set the Regulated Transport option to: " + selection, "Successfully set the Regulated Transport to: " + selection);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, for Select all modes of transport I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForSelectAllModesOfTransportISelect(string selections)
		{
			Report.IsTrue(new NewProduct().AllModesOfTransport(selections), "Failed to set option to: " + selections, "Successfully set option to: " + selections);
		}

		/// <summary>
		/// Enter in Technical Name (if applicable) textbox
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I enter: (.*) in the Technical Name text field")]
		public void GivenInTheProductCharacteristicsTabIEnterInTheTechnicalNameTextField(string text)
		{
			Report.IsTrue(new NewProduct().TechnicalName(text), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		/// <summary>
		/// Select Proper Shipping Name from dropdown
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I set the Proper Shipping Name to be: (.*)")]
		public void GivenInTheProductCharacteristicsTabISetTheProperShippingNameToBe(string option)
		{
			Report.IsTrue(new NewProduct().ProperShippingName(option), "Failed to set the option to be: " + option, "Successfully set option to be: " + option);
		}

		[StepDefinition(@"In the product Characteristics tab, I set Packing Group to be: (.*)")]
		public void GivenInTheProductCharacteristicsTabISetPackingGroupToBe(string option)
		{
			Report.IsTrue(new NewProduct().PackingGroupSelect(option), "Failed to set the option to be: " + option, "Successfully set option to be: " + option);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForDOTExceptionsISelect(string selections)
		{

			Report.IsTrue(new NewProduct().DotExcemptionIfApplicable(selections), "Failed to set the DOT Excemption option to: " + selections, "Successfully set the Regulated Transport to: " + selections);
		}

		[StepDefinition(@"In the Product Characteristics tab of the New Product Page, for International Shipping when DOT Exemption taken I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForInternationalShippingWhenDOTExemptionTakenISelect(string selection)
		{
			var selNewProduct = new NewProduct {
				InternationalShippingDOTExemption = selection
			};
			Report.IsTrue(selNewProduct.InternationalShippingDOTExemption == selection, "Failed to select: " + selection,
				"Successfully selected: " + selection);
		}

		[StepDefinition(@"I delete UPC: (.*)")]
		public void GivenIDeleteUPC(string upc)
		{
			Delay.Seconds(30);
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.DeleteUPC(upc), "Failed to delete UPC:" + upc, "Successfully deleted: " + upc);
			Delay.Seconds(30);
		}

		[StepDefinition(@"In the list of UPCs I should not see UPC: (.*)")]
		public void ThenInTheListOfUPCsIShouldNotSeeUPCSavedAsUPC(string upc)
		{
			var selNewProduct = new NewProduct();
			if (upc.ToLower().Contains("saved as"))
			{
				upc = Context
					.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
					.ToString();
			}

			Report.IsTrue(!selNewProduct.GetAllUPCs().Contains(upc), "UPC: " + upc + " has not been deleted.",
				"UPC: " + upc + " has been deleted as expected.");
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, for Other DOT Exception I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForOtherDOTExceptionISelect(string selection)
		{
			var selNewProduct = new NewProduct {
				OtherDOTException = selection
			};
			Report.IsTrue(selNewProduct.OtherDOTException == selection, "Failed to select: " + selection,
				"Successfully selected: " + selection);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, I enter: (.*) in the Provide Special Permit numbers text field")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageIEnterInTheProvideSpecialPermitNumbersTextField(string permitNumber)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the Product Characteristics tab, I enter: " + permitNumber + " in the Relative Density text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.SpecialPermitNumbers = permitNumber;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// select product lable option for Refer to your Product Label. From the options, select those that appear on the Label.
		/// </summary>
		[StepDefinition(@"In the Regulatory Inforamtion tab, I select Product Lable as: (.*)")]
		public void GivenInTheRegulatoryInforamtionTabISelectProductLableAs(string selections)
		{
			var selNewProduct = new NewProduct();

			var itemsToSelect = selections.Split(',').ToList().Select(x => x.Trim()).ToList();
			selNewProduct.ProductLabel = itemsToSelect;

			List<string> itemsSelected = selNewProduct.ProductLabel;

			foreach (string item in itemsToSelect)
			{
				if (itemsSelected.Select(x => x.Contains(item)).Count() != 1)
				{
					throw new Exception("Failed to select: " + item);
				}
			}
			Report.Success("Successfully selected: " + selections);
		}

		/// <summary>
		/// Confirm Based on your selection, you have verified your product contains VOC with intended uses as follows. The Aerosol Coatings by the CARB VOC compliance limit(s) for the intended use you identified is/are: statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the bold VOC-OTC-CARB Compliance Limits statement: (.*)")]
		public void ConfirmISeeTheVOC_OTC_CARB_ComplianceLimitStatement(string statement)
		{

			string fullText = new NewProduct().BoldElementContainsFullText("Based on your selection, you have verified your product contains VOC with intended uses as follows.");
			Report.IsTrue(fullText.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + fullText + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm VOC Analysis Date (Today's Date)
		/// </summary>
		[StepDefinition(@"I confirm that I see todays VOC Analysis Date")]
		public void ThenIConfirmThatISeeTodaysVOCAnalysisDate()
		{
			string date = DateTime.Now.ToString("MM/dd/yyyy");
			var newProductpage = new NewProduct();
			string found = newProductpage.GetValueVOCSummary("VOC Analysis");

			Report.IsTrue(found.Trim() == date.Trim(),
				"date was not as expected! Expected: " + date + ", but found: " + found + "!",
				"statement was showing: " + date + ", as expected!");
		}

		[StepDefinition(@"I confirm that the VOC Analysis Date statement is showing")]
		public void ThenIConfirmThatTheVOCAnalysisDateIsShowing()
		{
			string vocDateStatement = new NewProduct().VocAnalysisDateStatement();
			Report.IsFalse(vocDateStatement == null, "The VOC Analysis Date Statement was not showing", "The VOC Analysis Date Statement was showing as expected: " + vocDateStatement);
		}

		/// <summary>
		/// Confirm error message for VOC content in grams ozone per gram statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following error message for VOC content in grams ozone per gram: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingErrorMessageForVOCContentInGramsOzonePerGram(string statement)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.GetErrorMessageForVocContentInGrams();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		//JS - consolidated HVOC, CARB etc value steps into one because they were calling identical code
		[StepDefinition(@"I confirm that I see the following (CARB|MVOC|HVOC|VOC Grams Ozone|OTC Model Rule) value: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingCARBValue(string category, string expectedValue)
		{
			var newProductpage = new NewProduct();
			string foundValue = newProductpage.GetValueVOCSummary(category);
			Report.IsTrue(foundValue?.Trim() == expectedValue.Trim(),
				"value was not as expected! Expected: " + expectedValue + ", but found: " + foundValue + "!",
				"value was showing: " + expectedValue + ", as expected!");
		}

		// JS - consolidated multiple steps to one which used the same code but different element text
		/// <summary>
		/// Confirm VOC Summary statement text matches expected
		/// </summary>
		[StepDefinition(@"I confirm statement: (.*) shows the text: (.*)")]
		public void IConfirmStatementShowsTheText(string category, string value)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.GetVocSummaryStatementText(category);
			Report.IsTrue(found.Trim() == value.Trim(),
				"Statement was not as expected! Expected: " + value + ", but found: " + found + "!",
				"Statement was showing: " + value + ", as expected!");
		}

		[StepDefinition(@"In the Product Characteristics tab of the New Product Page, for Product does not contain more than grams of VOC per use I select: (.*)")]
		public void ThenInTheProductCharacteristicsTabOfTheNewProductPageForProductDoesNotContainMoreThanGramsOfVOCPerUseISelect(string option)
		{

			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");


			selNewProduct.ProductDoesNotContainGramsOfVoc = option;

			Report.IsTrue(selNewProduct.ProductDoesNotContainGramsOfVoc == option,
				"Failed to set status: " + option,
				"Successfully set status: " + option);
		}

		/// <summary>
		/// Enter in VOC content in grams ozone per gram text field
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I enter: (.*) in the VOC content in grams ozone per gram text field")]
		public void ThenInTheProductCharacteristicsTabIEnterInTheVOCContentInGramsOzonePerGramTextField(string option)
		{
			Report.IsTrue(new NewProduct().VocContentInGrams(option), "Text: " + option + " was not successfully inputted into the comments field!", "Text: " + option + " was successfully inputted into the comments field!");
		}

		[StepDefinition(@"In the Product Characteristics tab of the New Product Page, for When the product has a flammable propellant I select: (.*)")]
		public void ThenInTheProductCharacteristicsTabOfTheNewProductPageForWhenTheProductHasAFlammablePropellantISelect(string option)
		{
			Report.IsTrue(new NewProduct().ProductHasFlammablePropellant(option), "Failed to set option to be: " + option, "Successfully set the option to be: " + option);
		}

		/// <summary>
		/// Confirm the ecologo statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following Ecologo statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingEcologoStatement(string statement)
		{
			string fullText = new NewProduct().LabelContainsFullText("UL ECOLOGO Readiness Assessment");
			Report.IsTrue(fullText.Trim() == statement.Trim(),
				"Ecologo statement was not as expected! Expected: " + statement + ", but found: " + fullText + "!",
				"Ecologo statement was showing: " + statement + ", as expected!");
		}

		[StepDefinition(@"I set the water mixture question to: (Yes|No)")]
		public void ThenISetTheWaterMixtureQuestionTo(string option)
		{
			new NewProduct().SetWaterSolutionQuestion = (option == "Yes");
			Report.Success("Set water mixture question to: " + option);
		}

		[StepDefinition(@"I should see the radio button: (.*)")]
		public void ShouldSeeTheRadioButton(string button)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see the radio button " + button);
			try
			{
				Report.Info("Checking that I see the radio button '" + button + "'");
				var selNewProduct = new NewProduct();
				List<string> radioButtonsShowing = selNewProduct.RadioButtons();
				Report.IsTrue(radioButtonsShowing.Contains(button.Trim()),
					"Radio Button was not showing as expected! Expected: '" + button + "', but found: '" + string.Join("', '", radioButtonsShowing) + "'!",
					"Radio Button was showing: '" + button + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following radio buttons:")]
		public void ShouldSeeTheRadioButton(Table expected)
		{
			var selNewProduct = new NewProduct();
			List<string> radioButtonsShowing = selNewProduct.RadioButtons();
			foreach (TableRow row in expected.Rows)
			{
				string button = row["Button"];
				Report.Info("Checking that I see the radio button '" + button + "'");
				Report.IsTrue(radioButtonsShowing.Contains(button.Trim()),
					"Radio Button was not showing as expected! Expected: '" + button + "', but found: '" + string.Join("', '", radioButtonsShowing) + "'!",
					"Radio Button was showing: '" + button + "', as expected!");
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I should see the following checkbox:")]
		public void ShouldSeeCheboxes(Table expected)
		{
			var selNewProduct = new NewProduct();
			List<string> checkboxShowing = selNewProduct.Checkboxes();
			foreach (TableRow row in expected.Rows)
			{
				string button = row["Checkbox"];
				Report.Info("Checking that I see the checkbox '" + button + "'");
				Report.IsTrue(checkboxShowing.Contains(button.Trim()),
					"Checkbox was not showing as expected! Expected: '" + button + "', but found: '" + string.Join("', '", checkboxShowing) + "'!",
					"Checkbox was showing: '" + button + "', as expected!");
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I should see (a total of|at least) (.*) radio buttons for the section: (.*)")]
		public void RadioButtonCountInSection(string condition, string count, string section)
		{
			var selNewProduct = new NewProduct();
			int expectedCount = Convert.ToInt32(count);
			int actualCount = selNewProduct.RadioButtonCountInSection(section);
			if (condition == "a total of")
			{
				Report.IsTrue(expectedCount == actualCount,
					"The number of radio buttons appearing in section: " + section + " did not match the expected count: " + count, "The number of radio buttons appearing in section: " + section + " matched the expected count: " + count);
			}
			if (condition == "at least")
			{
				Report.IsTrue(actualCount >= expectedCount, "Expected there to be at least: " + expectedCount + " radio buttons for section: " + section + " but there were: " + actualCount, "There were at least: " + expectedCount + " radio buttons for section: " + section + " as expected");
			}
		}

		[StepDefinition(@"The following radio buttons (should|should not) be displayed for section: (.*)")]
		public void CheckRadioButtonsInSectionAndOrder(string shouldOrNot, string section, Table expected)
		{
			var expectedRadioButtons = new List<string>();
			expected.Rows.Cast<TableRow>().ToList().ForEach(x => expectedRadioButtons.Add(x["Button"]));
			List<string> radioButtonsShowing = new NewProduct().RadioButtonsInSection(section);

			if (shouldOrNot == "should")
			{
				Report.IsTrue(expectedRadioButtons.All(x => radioButtonsShowing.Contains(x)),
					"The actual radio buttons for section: " + section + " were not as expected. Actual radios: " + string.Join(", ", radioButtonsShowing) + ". Expected: " + string.Join(", ", expectedRadioButtons),
					"The actual radio buttons for section: " + section + " were as expected: " + string.Join(", ", radioButtonsShowing));
			}
			else
			{
				Report.IsTrue(!expectedRadioButtons.Any(x => radioButtonsShowing.Contains(x)),
					"The actual radio buttons for section: " + section + " were not as expected. Actual radios: " + string.Join(", ", radioButtonsShowing) + ". Should not be showing: " + string.Join(", ", expectedRadioButtons),
					"The actual radio buttons for section: " + section + " were as expected: " + string.Join(", ", radioButtonsShowing));

			}

		}

		[StepDefinition(@"The following checkboxes (should|should not) be displayed for section: (.*)")]
		public void CheckCheboxesInSectionAndOrder(string shouldOrNot, string section, Table expected)
		{
			var expectedCheckboxes = new List<string>();
			expected.Rows.Cast<TableRow>().ToList().ForEach(x => expectedCheckboxes.Add(x["Checkbox"]));
			List<string> checkboxesShowing = new NewProduct().CheckboxesInSection(section);

			if (shouldOrNot == "should")
			{
				Report.IsTrue(expectedCheckboxes.All(x => checkboxesShowing.Contains(x)),
					"The actual checkboxes for section: " + section + " were not as expected. Actual radios: " + string.Join(", ", checkboxesShowing) + ". Expected: " + string.Join(", ", checkboxesShowing),
					"The actual checkboxes for section: " + section + " were as expected: " + string.Join(", ", checkboxesShowing));
			}
			else
			{
				Report.IsTrue(!expectedCheckboxes.Any(x => checkboxesShowing.Contains(x)),
					"The actual checkboxes for section: " + section + " were not as expected. Actual radios: " + string.Join(", ", checkboxesShowing) + ". Should not be showing: " + string.Join(", ", checkboxesShowing),
					"The actual checkboxes for section: " + section + " were as expected: " + string.Join(", ", checkboxesShowing));
			}

		}

		[StepDefinition(@"I click the 'Add' button")]
		public void ThenIClickTheAddUpcButton()
		{
			Report.IsTrue((new NewProduct()).ClickAddUpcButton(), "Failed to click the 'Add' button!", "Successfully clicked the 'Add' button");
		}

		[StepDefinition(@"I enter an intentionally bad UPC with the following fields and save bad UPC as badUPC")]
		public void ThenIEnterAnIntentionallyBadUPCWithContainerSizeAndContainerTypeCardboard(Table table)
		{
			string badUPC = GenerateBadUPC.Generate();
			Context.AddToContext("badUPC", badUPC);
			Report.Info($"Bad UPC: {0}", badUPC);
			this.ThenIAddTheFollowingIntoTheUpcFields(table);
		}


		[StepDefinition(@"I add the following into the UPC Fields")]
		public void ThenIAddTheFollowingIntoTheUpcFields(Table table)
		{
			UpcInformation upcInfo = table.CreateInstance<UpcInformation>();
			Report.Info("UPC Number: " + upcInfo.UpcNumber);
			Report.Info("Container Type: " + upcInfo.ContainerType);
			Report.Info("Capsule Count: " + upcInfo.CapsuleCount);
			Report.Info("Size: " + upcInfo.Size);
			Report.Info("DPCI: " + upcInfo.Dpci);
			Report.Info("Quantity: " + upcInfo.Quantity);
			Report.Info("PackageType: " + upcInfo.PackageType);
			Report.Info("ItemNumber: " + upcInfo.ItemNumber);
			Report.Info("Internal SKU: " + upcInfo.InternalSKU);


			if (upcInfo.UPCName.IsNullOrEmpty())
			{
				Report.Info("UPCName:" + upcInfo.UPCName);
			}

			Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");
		}

		[StepDefinition(@"I click 'Select all' under Destination Retailers in the UPC page")]
		public void ClickSelectAllUnderDestinationRetailers()
		{
			Report.IsTrue(new NewProduct().ClickSelectAllDestinationRetailers(), "Failed to click Select All", "Clicked Select All");
		}

		[StepDefinition(@"the comments field should appear")]
		public void ThenTheCommentsFieldShouldAppear()
		{
			Report.IsTrue(new NewProduct().CommentsAreaShowing(), "Comments field was not displayed!", "Comments field was displayed, as expected");
		}

		[StepDefinition(@"I check the Comment error message shows: (.*)")]
		public void CheckTheCommentErrorMessageShows(string expected)
		{
			var np = new NewProduct();
			Report.IsTrue(np.CommentErrorDisplayed(expected, out string actual), "The error text was " + actual + ", but expected " + expected, "The error text was " + actual + " as expected.");
		}

		[StepDefinition(@"I append the following into the comments field: (.*)")]
		public void ThenIAppendTheFollowingIntoTheCommentsFieldCommentsFieldText(string text)
		{
			Report.IsTrue(new NewProduct().InputCommentAreaText(text, append: true), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		[StepDefinition(@"I enter the following into the Other DOT Exception field: (.*)")]
		public void ThenIEnterTheFollowingIntoTheOtherDOTException(string text)
		{
			Report.IsTrue(new NewProduct().InputOtherDotException(text), "Text: " + text + " was not successfully inputted into the Other DOT Exception field!", "Text: " + text + " was successfully inputted into the Other DOT Exception field!");
		}

		[StepDefinition(@"I enter the following into the comments field: (.*)")]
		public void ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(string text)
		{
			Report.IsTrue(new NewProduct().InputCommentAreaText(text), "Text: " + text + " was not successfully inputted into the Optional Comments field!", "Text: " + text + " was successfully inputted into the Optional Comments field!");
		}

		[StepDefinition(@"The remaining characters counter displays: (.*)/(.*)")]
		public void ThenTheRemainingCharactersCounterDisplays(int charRemainExpected, int charMax)
		{
			Report.IsTrue(new NewProduct().CommentsCharactersRemaining(charRemainExpected, charMax, out int remainDisplay),
				"Remaining characters expected: " + charRemainExpected + " but found: " + remainDisplay,
				"Remaining characters is: " + remainDisplay + " as expected");
		}


		[Then(@"I enter (.*) characters into the comments field")]
		public void ThenIEnterCharactersIntoTheCommentsField(int charCount)
		{
			string str = GeneralUtilities.GenerateRandomString(charCount);

			this.ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(str);
		}

		[Then(@"I verify the comments field contains: (.*)")]
		public void ThenIVerifyTheCommentsFieldContains(string contents)
		{
			Report.IsTrue(new NewProduct().CommentsAreaContains(contents), "Comments area contains: " + contents + " but expected: " + contents, "Comments area contents match expectation");
		}


		[StepDefinition(@"The Data Acceptance page should appear")]
		public void ThenTheDataAcceptancePageShouldApprear()
		{
			Report.IsTrue(new NewProduct().DataAcceptanceScreenAppears(), "Data Acceptance page did not appear!", "As expected, Data Acceptance page loaded successfully!");
		}

		[StepDefinition(@"I confirm following statement displays under Data Acceptance: (.*)")]
		public void ThenIConfirmFollowingStatementDisplaysUnder_(string message)
		{
			Report.IsTrue(new NewProduct().CheckDataAcceptanceProblemMessageHasAppeared(message), "Failed to confirm following statement displays under Data Acceptance: " + message, "Succesfully confirmed following statement displays under Data Acceptance: " + message);
		}


		[StepDefinition(@"In the Data Acceptance page I select Agreed")]
		public void GivenInTheDataAcceptancePageISelectYesAgreed()
		{
			var thisNewProduct = new NewProduct();
			if (thisNewProduct.YesAgreedIsSelected())
			{
				Report.Info("Yes agreed is already selected");
			}
			else
			{
				thisNewProduct.SelectYesAgreedRadio();
			}
			Report.IsTrue(thisNewProduct.YesAgreedIsSelected(), "Failed to select Yes Agreed", "Yes Agreed is selected.");
		}

		[StepDefinition(@"In the Data Acceptance page I click on the Accept button")]
		public void GivenInTheDataAcceptancePageIClickOnTheAcceptButton()
		{
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(new NewProduct().ClickAcceptButton(), "Failed to click accept button", "Clicked accept button", true);
			GeneralUtilities.Wait_for_load_finish();
			Delay.Seconds(1);
		}

		[StepDefinition(@"In the Data Acceptance page I see the Accept button")]
		public void GivenInTheDataAcceptancePageISeeTheAcceptButton()
		{
			Report.IsTrue(new NewProduct().AcceptButtonDisplayed(),
				"The Accept button was not displayed!",
				"The Accept button was displayed as expected");
		}

		[StepDefinition(@"I click the Summary button in the Data Acceptance window")]
		public void GivenIClickTheSummaryButtonInTheDataAcceptanceWindow()
		{
			Report.IsTrue(new NewProduct().ClickSummaruButtonInDataAcceptance(), "Failed to click the Summary button!", "Successfully clicked the Summary button!");
		}

		[StepDefinition(@"I set the radio option in section: (.*) to: (.*)")]
		public void SetRadioOptionInSectionTo(string section, string option)
		{
			Report.IsTrue(new NewProduct().SelectRadio(section, option), "Failed to select radio option: " + option + " in section: " + section, "Successfully set radio option: " + option);
		}

		[StepDefinition(@"I verify the error messaging in Regulatory Documents to Provide:")]
		public void GivenIVerifyTheErrorMessagingInRegulatoryDocumentsToProvide(Table table)
		{
			bool response = new RegulatoryDocumentsToProvide().GetErrorForQuestion(table, out string actualMessage);
			Report.IsTrue(response, "Found " + actualMessage + " instead of the expected message.", "Found expected message");
		}

		[StepDefinition(@"I set the (.*) field to: (.*)")]
		[StepDefinition(@"I set the (.*) option to: (.*)")]
		public void SetTheSectionOptionTo(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			if (option.StartsWith("UPC"))
			{
				var value = Context.GetFromContext(option)?.ToString();
				if (value == null)
				{
					throw new Exception($"Could not find item in context: { value } for checking field input is correct value!");
				}
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), value.Trim()),
					$"Failed to set the input to {value.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {value.Trim()} in section: { section.Trim()}");
				Delay.Seconds(1);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
					$"Failed to set the input to {option.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {option.Trim()} in section: {section.Trim()}");
				Delay.Seconds(1);
			}
		}

		[StepDefinition(@"I set the (.*) field to exactly match: (.*)")]
		[StepDefinition(@"I set the (.*) option to exactly match: (.*)")]
		public void SetTheSectionOptionToExactlyMatch(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			if (option.StartsWith("UPC"))
			{
				var value = Context.GetFromContext(option)?.ToString();
				if (value == null)
				{
					throw new Exception("Could not find item in context: " + value + " for checking field input is correct value!");
				}
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
					"Failed to set the input to " + option.Trim() + " in section: " + section.Trim(),
					"Successfully set the input to " + option.Trim() + " in section: " + section.Trim());
				Delay.Seconds(1);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SetOptionInSectionToExactlyMatch(section.Trim(), option.Trim()),
					"Failed to set the input to " + option.Trim() + " in section: " + section.Trim(),
					"Successfully set the input to " + option.Trim() + " in section: " + section.Trim());
				Delay.Seconds(1);
			}
		}

		[StepDefinition(@"I set the (.*) option to: (.*) and save entry")]
		public void SetTheSectionOptionToAndSaveEntry(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
				"Failed to set the input to " + option.Trim() + " in section: " + section.Trim(),
				"Successfully set the input to " + option.Trim() + " in section: " + section.Trim());
			Delay.Seconds(1);
			Context.AddToContext(section, option);
			;
			Report.Info(option + " is saved to context as: " + section);

		}
		// JS a solution specifically for Transportation page where you have nested checkbox sections eg. DOT, IATA
		[StepDefinition(@"I select option: (.*) under section: (.*) and subsection: (.*)")]
		public void SetTheOptionSubOptionTo(string option, string section, string subSection)
		{
			Report.IsTrue(new NewProduct().SetOptionInSectionSubSection(section.Trim(), subSection.Trim(), option.Trim()),
				$"Failed to set the input to: '{option}' in section: '{section}' and subection: '{subSection}'",
				$"Successfully set the input to: '{option}' in section: '{section}' and subection: '{subSection}'");
		}

		[StepDefinition(@"In the Transportation Details 1 screen, I unselect all transportation options for (DOT|IATA|IMDG|TDG)")]
		public void InTheTransportationDetails1ScreenIUnselectAllTransportationOptionsFor(string option)
		{
			Report.IsTrue(new NewProduct().UnselectTransportationOptions(option), "Failed to unselect Transportation options for " + option + ".",
				"Successfully unselection Transportation options for " + option + ".");
		}

		[StepDefinition(@"I (see|only see|do not see) the following questions")]
		[StepDefinition(@"I (see|only see|do not see) the following sections")]
		public void CheckDisplayedSections(string condition, Table sections)
		{
			Report.Info("Beginning I " + condition + " the following sections");
			var expectedSections = new List<string>();
			foreach (TableRow Row in sections.Rows)
			{
				expectedSections.Add(Row["Section"]);
			}
			var expectedNormalised = expectedSections.Select(x => x.Replace(" ", "")).ToList();
			var ActualSections = new NewProduct().GetDisplayedSections().Select(x => x).ToList();
			var actualNormalised = ActualSections.Select(x => x.Replace(" ", "")).ToList();
			Report.Info("Actual sections: " + string.Join(",", ActualSections));
			Report.Info("Expected sections: " + string.Join(",", expectedSections));
			if (condition == "only see")
			{
				var mismatch = new List<string>();
				foreach (string section in ActualSections)
				{
					if (!expectedSections.Contains(section))
					{
						mismatch.Add(section);
					}
				}
				Report.IsTrue(expectedSections.All(ActualSections.Contains) && expectedSections.Count == ActualSections.Count, "The following sections were showing when they should not be: " + string.Join("; ", mismatch), "The only displayed sections were: '" + string.Join("; ", ActualSections) + "' as expected");
				return;
			}
			if (condition == "see")
			{
				Report.IsTrue(expectedNormalised.All(actualNormalised.Contains), "The displayed sections: '" + string.Join("; ", ActualSections) + "' did not match the expected sections: '" + string.Join("; ", expectedSections) + "'", "The displayed sections: '" + string.Join("; ", ActualSections) + "' matched the expected sections");
				return;
			}
			if (condition == "do not see")
			{
				Report.IsFalse(expectedSections.Any(ActualSections.Contains), "Sections were showing which should not be. The sections not allowed are: " + string.Join("; ", expectedSections) + ". Actual sections: " + string.Join("; ", ActualSections), "Sections were not showing as expected: " + string.Join("; ", expectedSections));
			}
		}

		[StepDefinition(@"the question: (.*) is displayed at position: (.*)")]
		public void CheckDisplayedSections(string section, string position)
		{
			var actualSections = new NewProduct().GetDisplayedSections().Select(x => x.Trim()).ToList();
			int index = position.All(char.IsDigit) ? int.Parse(position) - 1 : -1;
			if (index == -1)
			{
				Report.Failure("The specified question position must be numeric");
				return;
			}
			Report.IsTrue(actualSections[index].Trim() == section,
				"The section: " + section + " was not displayed at position: " + position + "!",
				"The section: " + section + " was displayed at position: " + position + " as expected");
		}

		[StepDefinition(@"I select the first option in section: (.*)")]
		public void SelectFirstOptionInSection(string section)
		{
			var myProduct = new NewProduct();
			List<string> options = myProduct.GetAllOptionsForSection(section);
			Report.IsTrue(myProduct.SetOptionInSection(section, options[0]), $"The option: { options[0] } could not be selected in section: { section }", $"The option: { options[0] } was selected in section: { section }");
		}


		[StepDefinition(@"If Section: (.*) is visible, I select the first option")]
		public void IfSectionIsVisibleISelectTheOption(string section, string option)
		{
			var myProduct = new NewProduct();
			if (myProduct.GetDisplayedSections().Contains(section))
			{
				Report.Info("Selecting the first option for section: " + section);
				//var options = myProduct.GetDropDownOptionsForSection(section);
				Report.IsTrue(myProduct.SetOptionInSection(section, option), $"The option: { option } could not be selected in section: { section }", $"The option: { option } was selected in section: { section}");
			}
			else
			{
				Report.Info($"The section: { section } was not showing so no option was selected");
			}
		}

		//[StepDefinition(@"I see the following questions")]
		//public void CheckDisplayedSectionsContain(Table sections)
		//{
		//	var ExpectedSections = new List<string>();
		//	foreach (var Row in sections.Rows)
		//	{
		//		ExpectedSections.Add(Row["Section"]);
		//	}
		//	var ActualSections = new NewProduct().GetDisplayedSections();
		//	Report.IsTrue(ExpectedSections.All(ActualSections.Contains), "The displayed sections: '" + string.Join(",", ActualSections) + "' did not match the expected sections: '" + string.Join(",", ExpectedSections) + "'");
		//}

		[StepDefinition(@"I check the 'I do not have exact' checkbox for field: (.*)")]
		public void SectExatcDataNotKnown(string section)
		{
			string option = "I do not have exact";
			Report.IsTrue(new NewProduct().SetAdditionalOptionInSection(section, option),
				"Failed to set the input to " + option + " in section: " + section,
				"Successfully set the input to " + option + " in section: " + section);
		}

		[StepDefinition(@"I set the radio button (.*) for field: (.*)")]
		public void SectRadioButtonInSection(string section, string option)
		{
			Report.IsTrue(new NewProduct().SetAdditionalOptionInSection(section, option),
				$"Failed to set the input to {option} in section: {section} ",
				$"Successfully set the input to {option} in section: {section}");
		}

			[StepDefinition(@"I set the below options for field: (.*)")]
		public void CheckAvailableOptionsInSection(string section, Table options)
		{
			foreach (TableRow row in options.Rows)
			{
				Report.IsTrue(new NewProduct().SetOptionInSection(section, row["Option"]), "Failed to set the input to " + row["Option"] + " in section: " + section, "Successfully set the input to " + row["Option"] + " in section: " + section, false, false);
			}

			Report.Screenshot();
		}

		// NB: The error messages should be delimited by the '|' character!
		[StepDefinition(@"(.*) (should|should not) be showing the error messages: (.*)")]
		public void ErrorMessagesAreShowingForItem(string section, string should, string pipeDelimitedErrorMessages)
		{
			Delay.Seconds(1);
			string[] errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			List<string> errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.Info("Error messages showing are: " + string.Join(", ", errorMessages));
			if (should == "should")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsTrue(errorMessages.Any(e => e.Contains(item)),
						"Failed to find the error message: " + item + " under section: " + section + "!",
						"Successfully found the error message: " + item + " for section: " + section, false, false);
				}
			}
			if (should == "should not")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsFalse(errorMessages.Contains(item.Trim()),
						"The error message: " + item + " was displayed under section" + section + " when it should not be.",
						"The error message: " + item + " was not displayed under section: " + section + " as expected", false, false);
				}
			}
			Report.Screenshot();
		}

		[StepDefinition(@"(.*) (should|should not) be showing the error messages with no special characters: (.*)")]
		public void ErrorMessagesAreShowingForItemNoSpecialChars(string section, string should, string pipeDelimitedErrorMessages)
		{
			Delay.Seconds(1);
			string[] errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			List<string> errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.Info("Error messages showing are: " + string.Join(", ", errorMessages));
			var strippedErrorMessages = new List<string>();
			foreach (string message in errorMessages)
			{
				string temp = this.RemoveSpecialCharacters(message);
				strippedErrorMessages.Add(temp);
			}
			if (should == "should")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsTrue(strippedErrorMessages.Any(e => e.Contains(this.RemoveSpecialCharacters(item))),
						"Failed to find the error message: " + item + " under section: " + section + "!",
						"Successfully found the error message: " + item + " for section: " + section, false, false);
				}
			}
			if (should == "should not")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsFalse(strippedErrorMessages.Contains(this.RemoveSpecialCharacters(item.Trim())),
						"The error message: " + item + " was displayed under section" + section + " when it should not be.",
						"The error message: " + item + " was not displayed under section: " + section + " as expected", false, false);
				}
			}
			Report.Screenshot();
		}

		public string RemoveSpecialCharacters(string str)
		{
			var sb = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					sb.Append(c);
				}
			}
			return sb.ToString();
		}

		// NB: Multiple values should be delimited by the '|' character!
		[StepDefinition(@"(.*) should be showing the value: (.*)")]
		public void CheckingFieldInputIsCorrect(string section, string value)
		{
			if (value.StartsWith("~saved as"))
			{
				string savedAs = value.Replace("~saved as", "").Trim();
				value = Context.GetFromContext(savedAs)?.ToString();
				if (value == null)
				{
					throw new Exception("Could not find item in context: " + savedAs + " for checking field input is correct value!");
				}
			}
			List<string> showing = new NewProduct().SelectedOptionsForSection(section);
			Report.Info("Value(s) showing were: " + string.Join(", ", showing));
			var expected = value.Split('|').Select(x => x.Trim()).ToList();
			foreach (string expec in expected)
			{
				Report.IsTrue(showing.Contains(expec), "Failed to find the selected value: " + expec + " in the section: " + section + "!", string.Format("Successfully found {0} in section: {1}", expec, section), false, false);
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm that: (.*) is not the only option for section: (.*)")]
		public void ConfirmThatIsNotTheOnlyOptionForSection(string option, string section)
		{
			var selNewProduct = new NewProduct();
			List<string> options = selNewProduct.GetAllOptionsForSection(section);
			if (!options.Contains(option))
			{
				Report.Failure($"Option: '{option}' was not available in section: '{section}'!");
				Report.Screenshot();
			}
			else if (options.Count == 1)
			{
				Report.Failure($"Option: '{option}' was the only available option in section: '{section}'!");
				Report.Screenshot();
			}
			else
			{
				Report.Success($"Option: '{option}' was not the only available option in section: {section} as expected");
				Report.Screenshot();
			}
		}

		[StepDefinition(@"I confirm the VOC limits table has an entry for Regulation: (OTC|CARB)")]
		public void VOCLimitsTableHasEntryForRegulation(string regulation)
		{
			var selNewProduct = new NewProduct();
			List<VocLimits> displayed = selNewProduct.GetDisplayedVocLimits();
			string expectedRegulation = "";
			if (regulation == "OTC")
			{
				expectedRegulation = "OTC Model rule limit";
			}
			if (regulation == "CARB")
			{
				expectedRegulation = "CARB limit";
			}
			Report.IsTrue(displayed.Any(x => x.Regulation == expectedRegulation),
				"There was no entry in the VOC limits table for regulation " + regulation + "!",
				"There was an entry in the VOC limits table for regulation " + regulation + " as expected");
		}

		[StepDefinition(@"I should see the following Voc Limits present:")]
		public void ThenIShouldSeeTheFollowingVocLimitsPresent(Table information)
		{
			IEnumerable<VocLimits> expected = information.CreateSet<VocLimits>();
			var voclimits = new NewProduct();
			List<VocLimits> displayed = voclimits.GetDisplayedVocLimits();
			foreach (VocLimits expectedinfo in expected)
			{
				Report.Info("Checking use: " + expectedinfo.Use + " and Voc Compliance Limit: " + expectedinfo.VocComplianceLimit + " and Regulation: " + expectedinfo.Regulation);
				IEnumerable<VocLimits> matchingType = displayed.Where(x => x.Use == expectedinfo.Use);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No Use data displayed: " + expectedinfo.Use + " were displayed!");
					continue;
				}

				bool passed = false;
				foreach (VocLimits matched in matchingType)
				{
					if (matched.Use.Contains(expectedinfo.Use) && matched.VocComplianceLimit == expectedinfo.VocComplianceLimit && matched.Regulation == expectedinfo.Regulation)
					{
						passed = true;
						break;
					}
				}

				Report.IsTrue(passed, "Voc Limit data was not found!", "Voc Limit data found!");
			}
		}

		[StepDefinition(@"I should see the following Voc Limits with units  present:")]
		public void VocLimitsWithUnits(Table information)
		{
			Delay.Seconds(3);
			IEnumerable<VocLimitsWithUnits> expected = information.CreateSet<VocLimitsWithUnits>();
			var voclimits = new NewProduct();
			List<VocLimitsWithUnits> displayed = voclimits.GetDisplayedVocLimitsWithUnits();
			foreach (VocLimitsWithUnits expectedinfo in expected)
			{
				Report.Info("Checking use: " + expectedinfo.Use + " and Voc Compliance Limit: " + expectedinfo.VocComplianceLimit + " and Units: " + expectedinfo.Units + " and Regulation: " + expectedinfo.Regulation);
				IEnumerable<VocLimitsWithUnits> matchingType = displayed.Where(x => x.Use == expectedinfo.Use);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No Use data displayed: " + expectedinfo.Use + " were displayed!");
					continue;
				}

				bool passed = false;
				foreach (VocLimitsWithUnits matched in matchingType)
				{
					if (matched.Use.Contains(expectedinfo.Use) && matched.VocComplianceLimit == expectedinfo.VocComplianceLimit && matched.Units == expectedinfo.Units && matched.Regulation == expectedinfo.Regulation)
					{
						passed = true;
						break;
					}
				}

				Report.IsTrue(passed, "Voc Limit with units data was not found!", "Voc Limit with units data found!");
			}
		}

		[StepDefinition(@"I should see the following Voc percent for each state:")]
		public void ThenIShouldSeeTheFollowingVocPercentForEachState(Table information)
		{
			//Delay.Seconds(5 * Delay.SpeedFactor);
			IEnumerable<VocPercentForStates> expected = information.CreateSet<VocPercentForStates>();
			var voclimits = new NewProduct();
			List<VocPercentForStates> displayed = voclimits.GetDisplayedVocPercentForEachState();
			foreach (VocPercentForStates expectedinfo in expected)
			{
				Report.Info("Checking State: " + expectedinfo.State + " and Regulation: " + expectedinfo.Regulation + " and VOC value: " + expectedinfo.VocValue + " and State VOC Threshold: " + expectedinfo.StateVocThreshold + " and Message: " + expectedinfo.Message);
				IEnumerable<VocPercentForStates> matchingType = displayed.Where(x => x.State == expectedinfo.State);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No State data displayed: " + expectedinfo.State + " were displayed!");
					continue;
				}
				bool passed = false;
				foreach (VocPercentForStates matched in matchingType)
				{
					if (matched.State.Contains(expectedinfo.State) && matched.Regulation == expectedinfo.Regulation && matched.VocValue == expectedinfo.VocValue && matched.StateVocThreshold == expectedinfo.StateVocThreshold && matched.Message == expectedinfo.Message)
					{
						passed = true;
						break;
					}
				}
				Report.IsTrue(passed, "Voc percent data did not match for state: " + expectedinfo.State, "Voc percent data matched for state: " + expectedinfo.State);
			}
		}

		[StepDefinition(@"I should Enter the following Voc percent for each state: (.*)")]
		public void ThenIShouldEnterTheFollowingVocPercentForEachState(string value )
		{
			Report.Info("I Enter manually under the 'VOC VALUE' Column a value for each of the listed States");
			var selNewProduct = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.IsTrue(selNewProduct.EnterVOCStateValue(value), "Failed to enter 'VOC value' Column a value for each of the listed States",
				"Successfully enetered 'VOC value' Column a value for each of the listed States");
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			MyNewProduct.SetTheSectionOptionTo("Your acknowledgement of this registration includes that your product", "Yes, I Acknowledge");
		}

		[StepDefinition(@"I should see data for States in the 'VOC Content as weight percentage of total formula' table")]
		public void DataForStatesInVOCContentAsWeightPercentageTable()
		{
			var selNewProduct = new NewProduct();
			List<VocPercentForStates> displayed = selNewProduct.GetDisplayedVocPercentForEachState();
			Report.IsTrue(displayed.Count > 0 && displayed.All(x => !x.State.IsNullOrEmpty() && !x.VocValue.IsNullOrEmpty() && !x.StateVocThreshold.IsNullOrEmpty()),
				"There was not data displayed for all states in the VOC Cotent As Weight table!",
				"There was data displayed for all states in the VOC Content As Weight table as expected");
		}

		/// <summary>
		/// Confirm the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule statement
		/// </summary>
		[StepDefinition(@"I confirm that I do not see the following VOC Content as defined by OTC Model Rule statement")]
		public void ThenIconfirmThatIDoNotSeeTheFollowingVOCContentAsDefinedByOTCModelRuleStatement()
		{

			var newProductpage = new NewProduct();
			bool found = newProductpage.GetAmountOfVocByOTCRuleNotStatement();

			Report.IsTrue(!found, "statement was displayed", "statement was not displayed", false);
		}

		/// <summary>
		/// Confirm the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Content as defined by OTC Model Rule statement: (.*)")]
		public void ThenIconfirmThatISeeTheFollowingVOCContentAsDefinedByOTCModelRuleStatement(string statement)
		{

			var newProductpage = new NewProduct();
			string found = newProductpage.GetAmountOfVocByOTCRuleStatement();

			Report.IsTrue(found.Equals(statement), "statement was not displayed", "statement was displayed");
		}

		/// <summary>
		/// Confirm Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Content as defined by CARB statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCContentAsDefinedByCARBStatement(string statement)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.GetAmountOfVocDefinedByCARBStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm Verify VOC content is below the threshold of 0.02lb/start of CARB statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Content below threshold CARB statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCContentBelowThresholdCARBStatement(string statement)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.GetVOCContentBelowThresholdOfCARBStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm Verify VOC content is below the threshold of 0.02lb/start of OTC statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Content below threshold OTC statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCContentBelowThresholdOTCStatement(string statement)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.GetVOCContentBelowThresholdOfOTCStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC percentages entered for all areas statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCPercentagesEnteredForAllAreasStatement(string statement)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.GetUseVocPercentageAllAreaStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states. statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC content as weight percentage for each state statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCContentAsWeightPercentageForEachStateStatement(string statement)
		{
			var newProductpage = new NewProduct();
			string found = newProductpage.VocWeightPercentageForEachStateStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		[StepDefinition(@"I confirm the Label Information section on the Regulatory Information 3 page contains a link for: (.*)")]
		public void IConfirmLabelInformationOnRegulatoryInformationPageContains(string labelLink)
		{
			var newProductPage = new NewProduct();
			List<string> labelLinksShowing = newProductPage.RegulatoryInformationLabelLinks();
			Report.IsTrue(labelLinksShowing.Contains(labelLink), "The link with text: '" + labelLink + "' was not found on the Regulatory Information 3 page", "The link with text: '" + labelLink + "' was found on the Regulatory Information 3 page as expected");
		}

		[StepDefinition(@"I Confirm that the (.*) field is available")]
		public void ConfirmUPCSectionFieldsAvailable(string field)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.UPCSectionFieldsAvailable(field), "Failed to Confirm the'" +field+"' field is available", "I Confirm the '" + field + "' field is available");
		}

		[StepDefinition(@"I confirm 'Quantity' is visible in the UPC header")]
		public void ConfirmQuantityIsVisibleInUPCHeader()
		{
			Report.IsTrue(new NewProduct().GetUPCHeaders().Contains("Quantity"), "The text 'Quantity' did not appear in the UPC header on the Universal Product Code page", "The text 'Quantity' appeared in the UPC header on the Universal Product Code page as expected");
		}

		[StepDefinition(@"The VOC intended use text is shown: (.*)")]
		public void VOCIntendedUseTextMatches(string text)
		{
			List<string> displayedStatements = new NewProduct().AllAdditionalStatements();
			Report.IsTrue(displayedStatements.Contains(text), "The VOC Intended Use text was not as expected: '" + text + "'", "The VOC Intended Use text matched as expected: '" + text + "'");
		}

		[StepDefinition(@"in the VOC Limits table, the (Use|VOC Compliance Limit|Regulation) column should contain the value: (.*)")]
		public void VOCLimitsTableContainsUse(string column, string valueExpected)
		{
			List<VocLimitsWithUnits> displayed = new NewProduct().GetDisplayedVocLimitsWithUnits();
			if (column == "Use")
			{
				Report.IsTrue(displayed.Any(x => x.Use == valueExpected),
					string.Format("The VOC Limits table did not contain an entry with use: '{0}'", valueExpected),
					string.Format("The VOC Limits table contained an entry with use: '{0}' as expected", valueExpected));
			}
			if (column == "VOC Compliance Limit")
			{
				Report.IsTrue(displayed.Any(x => x.VocComplianceLimit == valueExpected),
					string.Format("The VOC Limits table did not contain an entry with use: '{0}'", valueExpected),
					string.Format("The VOC Limits table contained an entry with use: '{0}' as expected", valueExpected));
			}

			if (column == "Regulation")
			{
				Report.IsTrue(displayed.Any(x => x.Regulation == valueExpected),
					string.Format("The VOC Limits table did not contain an entry with use: '{0}'", valueExpected),
					string.Format("The VOC Limits table contained an entry with use: '{0}' as expected", valueExpected));
			}
		}

		[StepDefinition(@"The VOC content in g/L message shows the value: (.*)")]
		public void VOCContentMessageShowsTheValue(string value)
		{
			string vocContentValue = new NewProduct().VOCContentInGPerL();
			Report.IsTrue(vocContentValue.Trim() == value, "The value for VOC content in g/L was not as expected. The value showing is: " + vocContentValue + " The expected value was: " + value, "The VOC content in g/L value was as expected: " + value);
		}

		[StepDefinition(@"The VOC Summary page contains the statement with the text: (.*)")]
		public void VOCSummaryContainsStatement(string value)
		{
			List<string> statements = new NewProduct().AllAdditionalStatements();
			Report.IsTrue(statements.Contains(value), "The statement with text: " + value + " was not showing on the VOC Summary page", "The statement with text: " + value + " was showing on the VOC summary page as expected.");
		}

		[StepDefinition(@"I confirm that statement with text: '(.*)' is not displayed")]

		public void StatementIsNotDisplayed(string statement)
		{
			List<string> allStatements = new NewProduct().AllAdditionalStatements();
			Report.IsTrue(!allStatements.Contains(statement), "Statement: " + statement + " was displayed when it was not expected!", "Statement: " + statement + " was not displayed as expected");
		}
		public void SelectTCLPElementOptionsToNo(List<string> elements)
		{
			var newProduct = new NewProduct();
			foreach (string section in elements)
			{
				Report.StartStep("I set the " + elements + " option to: No");
				Report.IsTrue(newProduct.SetOptionInSection(section, "No"),
					"Failed to set the input to 'No' in section: '" + section + "'",
					"Successfully set the input to 'No' in section: '" + section + "'");
			}
		}


		//Checks a new page has loaded on Continue click. If not, look for 'this is a required field' error. If yes, throw excpt. The test is now out of sync, so further steps will only report junk.
		[StepDefinition(@"I continue to the next screen in the product registration")]
		public void ContinueInTheProductRegistration()
		{
			var selNewProduct = new NewProduct();
			Report.Info("Checking new product is loaded");
			Report.IsTrue(selNewProduct.WaitForContainerToBeVisible(10),
				"The New Product page is not currently loaded",
				"The New Product page is loaded");
			string currentPage = selNewProduct.ActivePanelHeadingText();
			Report.Info("Current expanded section is: " + currentPage);
			Report.Info("Clicking continue");
			Report.IsTrue(selNewProduct.ClickContinue(),
				"Failed to click the Continue button",
				"Successfully clicked the Continue button");
			Report.Info("Checking for 'required field' error and if new page hasn't loaded");
			int wait = 0;
			while (wait < 30)
			{
				if (selNewProduct.ActivePanelHeadingText() != currentPage)
				{
					Report.Success("New page was loaded");
					Report.Screenshot();
					Report.Info("Current page is: " + selNewProduct.ActivePanelHeadingText());
					return;
				}
				wait++;
				Delay.Seconds(1);
			}
			Report.Info("New page did not load. Checking for 'required field' error message.");
			if (selNewProduct.ErrorMessageText == "This is a required field.")
			{
				string section = selNewProduct.SectionWithRequiredFieldError();
				Report.Failure("The 'Required Field' error was showing for question: " + section + ". Selecting the first option. Check the test case is complete and correct.");
				Report.Screenshot();
				Report.Info("Selecting the first option for the required field");
				string option = selNewProduct.GetAllOptionsForSection(section).First();

				selNewProduct.SetOptionInSection(section, option);
				Report.Info("Clicking continue");
				Report.IsTrue(selNewProduct.ClickContinue(),
					"Failed to click the Continue button",
					"Successfully clicked the Continue button");
				return;
			}
			Report.Failure("New page did not load as expected, however 'Required Field' error message was not displayed.");
			Report.Screenshot();
			throw new Exception("New page did not load on Continue.");
		}

		[StepDefinition(@"The message with text: (.*) is visble on the (.*) page")]
		public void MessageVisibleOnPage(string message, string page)
		{
			List<string> actualMessages = new NewProduct().AllAdditionalStatements();
			Report.IsTrue(actualMessages.Any(x => x.Contains(message)),
				$"The message: '{message}' was not visble on the '{page}' page.",
				$"The message: '{message}' was visble on the '{page}' page as expected.");
		}


		[StepDefinition(@"I confirm that only 'Active' brands saved in My Library - My Brands appear in the 'Product Line or Brand' drop down")]
		public void OnlyActiveBrandAppearInProductLineDropDown()
		{
			var activeBrands = (List<string>)Context.GetFromContext("Active Brands");
			if (activeBrands.IsNullOrEmpty())
			{
				Report.Failure("Saved brand name was not found in context. The test must call 'click save' in My Library - My Brands");
				return;
			}
			List<MyBrands.Brand> productLineOptions = new NewProduct().AllProductLineOrBrandOptions();

			//var namesAsList = new List<string>();
			//foreach (var item in productLineOptions)
			//{
			//	namesAsList.Add(item.Name);
			//}

			Report.IsTrue(!productLineOptions.Select(x => x.Name).ToList().Except(activeBrands).Any() && productLineOptions.Count == activeBrands.Count,
				"The 'Product Line or Brand' drop down options were not limited exclusively to saved active brands. The options showing were: " + string.Join(", ", productLineOptions.Select(x => x.Name).ToList()),
				"The 'Product Line or Brand' drop down options were limited exclusively to saved active brands as expected. The options showing were: " + string.Join(", ", productLineOptions.Select(x => x.Name).ToList()));





		}

		[StepDefinition(@"In the Create the kit page I search for and select: (.*)")]
		public void GivenInTheCreateTheKitPageISearchForAndSelect(string productToAdd)
		{
			if (productToAdd.ToLower().Contains("saved as"))
			{
				var productToAddPI = (ProductInformation)Context.GetFromContext(productToAdd.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());


				Report.Info($"Attempting to add by ID");
				Report.IsTrue(new NewProduct().AddItemToKitByID(productToAddPI),
					"Failed to add product: " + productToAddPI.Id + " to kit.",
					"Successfully added product: " + productToAddPI.Id + " to kit.");
			}
			else
			{
				Report.Info($"Attempting to add item to Kit.");
				Report.IsTrue(new NewProduct().AddItemToKit(productToAdd),
					"Failed to add product: " + productToAdd + " to kit.",
					"Successfully added product: " + productToAdd + " to kit.");
			}

		}

		[StepDefinition(@"In the Create the kit page I search for and select product saved as: (.*)")]
		public void GivenInTheCreateTheKitPageISearchForAndSelectSavedAs(ProductInformation product)
		{
			Report.IsTrue(new NewProduct().AddItemToKitByNameAndID(product),
				"Failed to add product: " + product.Id + " to kit.",
				"Successfully added product: " + product.Id + " to kit.");
		}

		[StepDefinition(@"In the Create the kit page I search for and select by id product saved as: (.*)")]
		public void GivenInTheCreateTheKitPageISearchForAndSelectByIdSavedAs(ProductInformation product)
		{
			Report.IsTrue(new NewProduct().AddItemToKitByID(product),
				"Failed to add product: " + product.Id + " to kit.",
				"Successfully added product: " + product.Id + " to kit.");
		}

		[StepDefinition(@"in the (.*) page I (should|should not) see the (.*) question")]
		public void ThenInThePageIShouldOrShouldNotSeeQuestion(string page, string shouldOrNot, string question)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForSection(page))
			{
				throw new Exception("Not on the right page");
			}

			Report.IsTrue(thisNewProduct.SectionExists(question) == (shouldOrNot == "should"),
				"Question is not showing as expected", "Question is showing or not as expected");
		}

		[StepDefinition(@"a (Danger & Warning|Warning) popup dialog should appear with the message: (.*)")]
		public void ThenAWarningPopupDialogShouldAppearWithTheMessage(string title, string message)
		{
			var thisModalDialog = new ModalDialog();
			Report.IsTrue(thisModalDialog.GetTitle() == title, "Title is not showing as " + title,
				"Title is showing as" + title);
			Report.IsTrue(thisModalDialog.GetText() == message, "Expected message: " + message + " but got: " + thisModalDialog.GetText(),
				"Title is showing as expected: " + message);
			Report.Info("Clicking OK in the popup");
			thisModalDialog.Click_OK();
			Delay.Seconds(1);
		}

		[StepDefinition(@"I should see an alert with title: (.*) subtitle: (.*) Text: (.*)")]
		public void ThenIShouldSeeAnAlertWithTitleSubtitleText(string title, string subtitle, string text)
		{
			var thisNewProduct = new NewProduct();
			Alert thisAlert = thisNewProduct.GetAlert();
			Report.IsTrue(thisAlert.Title == title, "Title is not as expected", "Title matches");
			Report.IsTrue(thisAlert.SubTitle.Contains(subtitle), "SubTitle is not as expected. Expected " + subtitle + " but got: " + thisAlert.SubTitle, "SubTitle matches");
			Report.IsTrue(thisAlert.Text == text, "Text is not as expected. Expected " + text + " but got: " + thisAlert.Text, "Text matches");
		}

		[StepDefinition(@"on the Neonicotinoid Warning Page I should see a link with text: (.*) which links to page: (.*)")]
		public void ThenOnTheNeonicotinoidWarningPageIShouldSeeALinkWithTextWhichLinksToPage(string linkText, string link)
		{
			var thisNewProduct = new NewProduct();
			Alert thisAlert = thisNewProduct.GetAlert();
			Report.IsTrue(thisAlert.Text.Contains(linkText), "Link text: " + linkText + " is not showing as expected.",
				"Link text is showing as expected.");

			Report.IsTrue(thisNewProduct.ClickAlertLink(linkText), "Failed to click link: " + linkText,
				"Successfully clicked link.");
			Delay.Seconds(3);

			Report.IsTrue(SeleniumBrowser.GetTabURLs().Contains(link), "Active page is not as expected",
				"Active page is as expected");
			SeleniumBrowser.CloseTabWithURL(link);
			Delay.Seconds(1);
		}

		[StepDefinition(@"I click the 'Use My Ingredients' button")]
		public void ClickUseMyIngredients()
		{
			Report.IsTrue(new NewProduct().ClickUseMyIngredients(),
				"Failed to click the 'Use My Ingredients' button",
				"Successfully clicked the 'Use My Ingredients' button");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I click OK in the My Ingredients dialog")]
		public void ClickOKMyIngredientsDialog()
		{
			Report.IsTrue(new MyIngredientsModal().Click_OK(), "Failed to click OK in the My Ingredients dialog", "Successfully clicked OK in the My Ingredients dialog");
		}

		[StepDefinition(@"I see the My Ingredients pop up")]
		public void MyIngredientsDialogAppears()
		{
			Report.IsTrue(new MyIngredientsModal().Exists, "The My Ingredients pop up did not appear", "The My Ingredients pop up appeared as expected");
		}

		[StepDefinition(@"I confirm My Ingredient saved as: (.*) appears in the Use My Ingredients popup")]
		public void MyIngredientsDialogContainsIngredient(string savedAs)
		{
			var ingredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			List<MyIngredients.IngredientItem> showingIngredients = new MyIngredientsModal().MyIngredients();
			IEnumerable<MyIngredients.IngredientItem> matchID = showingIngredients.Where(x => x.Index == ingredient.Index);
			if (matchID.Count() == 0)
			{
				Report.Failure("The saved ingredient at position: " + ingredient.Index + " was not found on the My Ingredients pop up");
				return;
			}
			Report.IsTrue(matchID.FirstOrDefault().ChemicalName == ingredient.ChemicalName,
				string.Format("The ingredient: '{0}' at position: '{1}' was not found in the My Ingredients pop up"
					, ingredient.ChemicalName, ingredient.Index),
				string.Format("The ingredient: '{0}' at position: '{1}' was found in the My Ingredients pop up as expected"
					, ingredient.ChemicalName, ingredient.Index));
			Report.IsTrue(matchID.FirstOrDefault().PublicallyDisclosed == ingredient.PublicallyDisclosed,
				string.Format("The Publically Disclosed checkbox was not as expected for ingredient: '{0}' at position: '{1}'. Expected: '{2}'"
					, ingredient.ChemicalName, ingredient.Index, ingredient.PublicallyDisclosed.ToString()),
				string.Format("The Publically Disclosed checkbox was '{0}' as expected for ingredient: '{1}' at position: '{2}'"
					, ingredient.PublicallyDisclosed.ToString(), ingredient.ChemicalName, ingredient.Index));
			Report.IsTrue(matchID.FirstOrDefault().TradeSecret == ingredient.TradeSecret,
				string.Format("The Trade Secret checkbox was not as expected for ingredient: '{0}' at position: '{1}'. Expected: '{2}'"
					, ingredient.ChemicalName, ingredient.Index, ingredient.TradeSecret.ToString()),
				string.Format("The Trade Secret checkbox was '{0}' as expected for ingredient: '{1}' at position: '{2}'"
					, ingredient.TradeSecret.ToString(), ingredient.ChemicalName, ingredient.Index));
			Report.IsTrue(matchID.FirstOrDefault().PublicName == ingredient.PublicName,
				string.Format("The Public Name was not as expected for ingredient: '{0}' at position: '{1}'. Expected: '{2}'"
					, ingredient.ChemicalName, ingredient.Index, ingredient.PublicName),
				string.Format("The Public Name was '{0}' as expected for ingredient: '{1}' at position: '{2}'"
					, ingredient.PublicName, ingredient.ChemicalName, ingredient.Index));
		}

		[StepDefinition(@"Field exists: (.*)")]
		public void ThenFieldExists(string field)
		{

			Report.IsTrue(new NewProduct().OptionExists(field),
				"Field does not exist: " + field,
				"Field exists: " + field);
			Delay.Seconds(1);
		}

		[StepDefinition(@"(.*) should not be showing any error messages")]
		public void ErrorMessagesShouldNotBeShowingForItem(string section)
		{
			Delay.Seconds(1);
			List<string> errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.IsTrue(errorMessages.Count == 0, "No error message should be showing for section: " + section + " but found: " + string.Join(", ", errorMessages),
				"As expected, no error messages were showing for section: " + section);
		}

		[StepDefinition(@"Section: (.*) should be showing an error message")]
		public void ErrorMessagesShouldBeShowingForItem(string section)
		{
			Delay.Seconds(1);
			List<string> errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.IsTrue(errorMessages.Any(), "No error message was displayed for section: " + section + " when there was expected to be!",
				"As expected, an error message were displayed for section: " + section);
		}

		[StepDefinition(@"For every field in the table I should (see|not see) the following error: (.*)")]
		public void ThenForEveryFieldInTheTableIShouldSeeTheFollowingError(string condition, string expectedError, Table table)
		{
			Delay.Seconds(3);
			bool see = false;
			if (condition == "see")
			{
				see = true;
			}
			else if (condition != "not see")
			{
				Report.Error("Condition must be either 'see' or 'not see'!");
				return;
			}
			foreach (TableRow thisRow in table.Rows)
			{
				this.ErrorMessagesAreShowingForItem(thisRow["Field"], see ? "should" : "should not", expectedError);
			}
		}

		[StepDefinition(@"For every field in the table I call Shared Step 56494 expecting error: (.*)")]
		public void ThenForEveryFieldInTheTableICallSharedStep56494ExpecingError(string error, Table table)
		{
			var thisStepShared = new Steps_Shared();
			foreach (TableRow thisRow in table.Rows)
			{
				var MyNewProduct = new NewProduct();
				MyNewProduct.MoveToLabel(thisRow["Field"]);
				thisStepShared.GivenICallSharedStep56494PesticideDetailsCanadaProvinceCodeconfirmationvalidationAndSelectionForProvince(thisRow["Field"], error);
			}
		}

		[StepDefinition(@"The following options (should|should not) be (displayed|displayed exclusively) for section: (.*)")]
		public void CheckOptionsInSection(string should, string exclusive, string section, Table expected)
		{
			var expectedOptions = new List<string>();
			List<string> displayedOptions = new List<string>();
			var differences = new List<string>();
			expected.Rows.Cast<TableRow>().ToList().ForEach(x => expectedOptions.Add(x["Option"]));
			var expectedOptionsLower = expectedOptions.Select(x => x.ToLower()).ToList();
			if(section == "Container Type")
			{
				displayedOptions = new NewProduct().GetAllOptionsForContainerTypeField();
			}
			else
			{
				displayedOptions = new NewProduct().GetAllOptionsForSection(section);
			}
			var displayedOptionsLower = displayedOptions.Select(x => x.ToLower()).ToList();
			if (exclusive == "displayed")
			{
				if (should == "should")
				{
					differences = expectedOptionsLower.Except(displayedOptionsLower).ToList();
					Report.IsTrue(expectedOptions.All(x => displayedOptionsLower.Contains(x.ToLower())),
						"All expected options were not displayed under section: " + section + ". The differences were: " + string.Join(", ", differences.Select(x => "'" + x + "'").ToList()) + ". The displayed options were: " + string.Join(", ", displayedOptions),
						"All expected options were displayed under section: " + section + ": " + string.Join(", ", displayedOptions));
				}
				else if (should == "should not")
				{
					Report.IsTrue(!expectedOptionsLower.Any(x => displayedOptionsLower.Contains(x)),
						$"The following options were available for section: '{section}' when they were not expected!: '{string.Join(", ", expectedOptions)}'",
						$"The following options were not available for section: '{section}' as expected: {string.Join(", ", expectedOptions)}");
				}
			}
			else if (exclusive == "displayed exclusively")
			{
				Report.Info("Expected options to be displayed are:");
				foreach (string option in expectedOptions)
				{
					Report.Info(option);
				}
				bool allMatch = true;
				foreach (string displayedOption in displayedOptionsLower)
				{
					bool match = false;
					foreach (string expectedOption in expectedOptionsLower)
					{
						if (expectedOption != displayedOption)
						{
							continue;
						}
						match = true;
						break;
					}
					if (match)
					{
						continue;
					}
					allMatch = false;
					Report.Failure("Option: " + displayedOption + " was displayed when it was not expected!");
					Report.Screenshot();
				}
				if (allMatch)
				{
					Report.Success("The displayed options matched the expected options exactly for section: " + section);
					Report.Screenshot();
				}
			}
		}

		[StepDefinition(@"The Product Development Manager options should comprise a list containing the domain @CVSHealth.com")]
		public void PDMOptionsShouldContainCVSEmailDomain()
		{
			List<string> displayedOptions = new NewProduct().GetAllOptionsForSection("Who is the Product Development Manager (PDM) for this product?");
			Report.IsTrue(displayedOptions.Where(x => x != "Choose...").ToList().All(x => x.ToLower().Contains("@cvshealth.com")),
				"Not all options in the PDM drop down contained the domain CVSHealth.com",
				"All options in the PDM drop down contained the domain CVSHealth.com as expected");
		}

		[StepDefinition(@"in the VOC Summary page I should see the following noneditable statements")]
		public void ThenInTheVOCSummaryPageIShouldSeeTheFollowingNoneditableStatements(Table table)
		{
			List<string> VOCSummaryStatements = new NewProduct().GetVOCSummaryStatements();
			var expectedStatements = table.Rows.Select(x => x["Statement"]).ToList();
			foreach (string statement in expectedStatements)
			{
				Report.IsTrue(VOCSummaryStatements.Contains(statement), "Expected statement: " + statement,
					"Statement: " + statement + " showing as expected");
			}
		}

		[StepDefinition(@"the VOC concentration question shows a yes and a no button")]
		public void ThenTheVOCConcentrationQuestionShowsAYesAndANoButton()
		{
			Report.IsTrue(new NewProduct().VOCConcentrationQuestionHasYesAndNo(), "Expected VOC Concentration to have yes and no",
				"VOC concentration has yes and no");
		}

		[StepDefinition(@"For the VOC concentration question field I should see the following error: (.*)")]
		public void ThenForTheVOCConcentrationQuestionFieldIShouldSeeTheFollowingError(string error)
		{
			string actualError = new NewProduct().VOCConcentrationError();
			if (actualError == null)
			{
				actualError = "null";
			}
			Report.IsTrue(actualError == error, "Error is not showing as expected. Expected: " + error + " but got: " + actualError,
				"Error is showing as expected");
		}

		[StepDefinition(@"For the VOC page I should see the following error: (.*)")]
		public void ThenForTheVOCPageIShouldSeeTheFollowingError(string error)
		{
			List<string> actualErrors = new NewProduct().DisplayedAlerts();
			if (actualErrors == null)
			{
				actualErrors = new List<string>();
			}
			Report.IsTrue(actualErrors.Contains(error), "Error is not showing as expected. Expected: " + error + " but got: " + string.Join(",", actualErrors),
				"Error is showing as expected");
		}

		[StepDefinition(@"I save the UPC number (.*) as: (.*)")]
		public void SaveUpcNumberAs(string upc, string savedAs)
		{
			Context.AddToContext(savedAs, upc);
			Report.Info("Saved UPC No: " + upc + " saved as: " + savedAs);
		}

		[StepDefinition(@"I click the dropdown box for section: (.*)")]
		public void ClickSelectForSection(string section)
		{
			Report.IsTrue(new NewProduct().ClickSelectForSection(section),
				"Failed to click drop down element for section: " + section,
				"Successfully clicked the drop down for section: " + section);
		}

		[StepDefinition(@"I should not see the (.*) Page")]
		public void GivenIShouldNotSeeXPage(string page)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(!selNewProduct.WaitForSection(page, 20),
				page + " is showing when it was not expected",
				page + " is not showing as expected");
		}

		[StepDefinition(@"I confirm the page heading shows the CVS Logo with the title 'CVS Own Brand Registration' below the logo")]
		public void CVSOwnBrandRegistrationPageIsDisplayedWithLogo()
		{
			ReportSettings.UseSubSteps = true;
			var selNewProduct = new NewProduct();
			Report.StartStep("I confirm the CVS Logo is displayed in the page heading");
			Report.IsTrue(selNewProduct.SectionLogoDisplayed("cvs-pharmacy"),
				"The CVS logo was not displayed in the page header!",
				"The CVS logo was displayed in the page header");
			Report.StartStep("I confirm the title of the page heading is 'CVS Own Brand Registration'");
			Report.IsTrue(selNewProduct.WaitForSection("CVS Own Brand Registration"),
				"The page header was not 'CVS Own Brand Registration'!",
				"The page header was 'CVS Own Brand Registration' as expected");
		}

		[StepDefinition(@"The displayed message text is comprised of the following paragraphs")]
		public void MessageTextContainsParagraphs(Table paragraphText)
		{
			ReportSettings.UseSubSteps = true;
			var expectedParagraphs = new List<string>();
			paragraphText.Rows.Cast<TableRow>().ToList().ForEach(x => expectedParagraphs.Add(x["Paragraph"]));
			List<string> actualParagraphs = new NewProduct().AllAdditionalStatementParagraphs();
			int count = 1;
			foreach (string para in actualParagraphs)
			{
				Report.StartStep("Checking paragraph: " + count + " matches expected text");
				Report.IsTrue(para.Trim() == expectedParagraphs[count - 1],
					"Paragraph " + count + " did not match the expected text: '" + para + "'",
					"Paragraph " + count + " matched the expected text: '" + para + "'");
				count++;
			}
		}
		[StepDefinition(@"The alert message (is|is not) displayed with text: (.*)")]
		public void AlertMessageDisplayed(string displayed, string alert)
		{
			bool expectDisplayed = false;
			switch (displayed)
			{
				case "is":
					expectDisplayed = true;
					break;
				case "is not":
					break;
				default:
					Report.Failure("Step parameter must be either 'is' or 'is not'");
					return;
			}
			List<string> actualAlerts = new NewProduct().DisplayedAlerts();
			if (actualAlerts == null)
			{
				Report.Failure("Error fetching alert messages!");
				return;
			}
			Report.IsTrue(actualAlerts.Contains(alert) == expectDisplayed,
				$"Alert message {(expectDisplayed ? "is not" : "is")} displayed when . Expected: " + alert + " but got: " + string.Join(",", actualAlerts),
				"Message: '" + alert + "' is displayed as expected");
		}


		[StepDefinition(@"If purchase details are showing click confirm order")]
		public void GivenIfPurchaseDetailsAreShowingClickConfirmOrder()
		{			
			Report.UseSubSteps = true;
			var MyStepsPaymentMethods = new Steps_PaymentMethods();
			var mySub = new PaymentMethods_Subscription_Billing();
			
			if (mySub.Purchase_Header_Correct())
			{			
				if (mySub.ConfirmOrderButtonExists())
				{
					Report.IsTrue(mySub.Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");
					GeneralUtilities.WaitForRefreshToDisappear(mySub._btn_confirm);
					GeneralUtilities.Wait_for_load_finish();
					Report.Screenshot();
				}
				else
				{
					Report.Info("Purchase details page is not showing"); 
				}

				Report.Info("Checking if thank you page is showing instead");

				var pmtk = new PaymentMethods_Thank_You();
				if (pmtk.WaitForContainerToExist())
				{					
					Report.StartSubStep("In the Thank You screen I confirm the following statement is shown");
					MyStepsPaymentMethods.ThenInTheThankYouScreenIConfirmTheFollowingStatementIsShownX("Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.");
				}
				else
				{
					Report.Info("Thank you page is not showing");				
				}
			}
			else
			{
				var sub = new SubscriptionEnrollment();

				if (sub.Get_Page_Header().Equals("Subscription  Upgrade"))
				{
					var MyStepsSubscriptonEnrollment = new StepsSubscriptionEnrollment();
					Report.StartSubStep("The Subscription Upgrade page should load");
					MyStepsSubscriptonEnrollment.ThenTheSubscriptionEnrollmentPageShouldLoad();
					Report.StartSubStep("I should see Proceed button enabled");
					MyStepsSubscriptonEnrollment.ThenIShouldSeeProceedButtonDisabled("enabled");
					Report.StartSubStep("I click on the Proceed button");
					MyStepsSubscriptonEnrollment.ClickProceedButton();
					var StepsSE_new = new StepsSubscriptionEnrollmentNew();
					Report.StartSubStep("In the Subscription Enrollment Modal, I click the Checkout button");
					StepsSE_new.InSubscriprionEnrollmentModalClickButton("Checkout");
					Report.StartSubStep("In the Payment Methods screen I click Continue");
					MyStepsPaymentMethods.ThenIClickContinue();
					Report.StartSubStep("In the Purchase Summary screen I click Confirm Order");
					MyStepsPaymentMethods.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
					Report.StartSubStep("In the Thank You screen I check the Header is correct"); 
					MyStepsPaymentMethods.ThenInTheThankYouScreenICheckTheHeaderIsCorrect();
				}
				else
				{
					Report.Error("Page header does not include or equal 'Subscription Uprgade'!");
					Report.Screenshot();
				}
			}
		}

		[StepDefinition(@"In the Purchase Summary page Confirm thank you message is shown if product details is not shown: (.*)")]
		public void ConfirmThankYouMessageIfProductDetailsNotPresent(string message)
		{
			var mySub = new PaymentMethods_Subscription_Billing();
			if (mySub.Product_Billing_Header_Displayed())
			{
				Report.StartStep(ReportSettings.StepCounter + " - If purchase details are showing click confirm order");
				Report.Info("The Product Billing section was displayed, so trying to click 'Confirm Order'");
				Report.IsTrue(mySub.Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");
				Delay.Seconds(10);
			}
			else
			{
				Report.StartStep(ReportSettings.StepCounter + " - In the Thank You screen I check the Confirmation statement is correct");
				try
				{
					var myPay = new PaymentMethods_Thank_You();
					Report.Info($"Thank You Text = {message}");
					Report.IsTrue(myPay.Thank_You_TextExists(message.Trim()), $"Displayed Text does not contain: '{message}'",
						$"Displayed Text contains: '{message}'");
				}
				catch (Exception ex)
				{
					Report.Failure(ex.Message);
					throw;
				}
			}
		}


		[StepDefinition(@"the 'Regulatory List' window opens")]
		public void RegulatoryListWindowOpens()
		{
			new RegulatoryList().WaitForContainerToBeVisible();
			string header = new RegulatoryList().Heading();
			if (header == null)
			{
				Report.Failure("Regulatory List pop up was not displayed");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(header == "Regulatory List", "The pop up header text was not 'Regulatory List' as expected!", "The pop up header text was 'Regulatory List' as expected");
		}

		[StepDefinition(@"I confirm that a list of regulations associated with the component is displayed")]
		public void ConfirmListOfRegulationsAssociatedWithComponentDisplayed()
		{
			var selRegulatoryList = new RegulatoryList();
			List<RegulatoryList.RegulatoryListItem> regulatoryListData = selRegulatoryList.GetRegulatoryListRows();
			if (regulatoryListData.Count > 0)
			{
				Report.IsTrue(!regulatoryListData.Any(x => x.Classification.IsNullOrEmpty() || x.RegulatoryCode.IsNullOrEmpty()),
					"There was some empty data in the Regulatory List pop up table",
					"There was data in the Regulatory List pop up table");
			}
		}

		[StepDefinition(@"I close the Regulatory List window")]
		public void CloseTheRegulatoryListWindow()
		{
			var selRegulatoryList = new RegulatoryList();
			Report.IsTrue(selRegulatoryList.ClickClose(),
				"Failed to close the Regulatory List pop up",
				"Successfully closed the Regulatory List pop up");
		}

		[StepDefinition(@"I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted (CARB|OTC) value: (.*)")]
		public void ConfirmExceedsStatementIsCorrectBasedOnCarb(string carbOtc, string value)
		{
			var selNewProduct = new NewProduct();
			string category;
			double complianceLimit;
			List<VocLimits> limits = selNewProduct.GetDisplayedVocLimits();
			if (limits.IsNullOrEmpty())
			{
				Report.Failure("Failed to find Compliance Limits on the VOC summary page");
				return;
			}
			switch (carbOtc)
			{
				case "CARB":
					category = "California Consumer Products Regulation";
					complianceLimit = Convert.ToDouble(limits.First(x => x.Regulation == "CARB limit").VocComplianceLimit.Trim());
					break;
				case "OTC":
					category = "Ozone Transport Commission";
					complianceLimit = Convert.ToDouble(limits.First(x => x.Regulation == "OTC Model rule limit").VocComplianceLimit.Trim());
					break;
				default:
					Report.Failure("Must specify VOC value type: CARB or OTC only");
					return;
			}
			string phrase = selNewProduct.GetVocSummaryStatementText(category);
			if (phrase == null)
			{
				Report.Failure("Unable to find statement phrase for: " + category + " on the VOC summary page");
				return;
			}
			Report.Info("The CARB exceeds phrase was showing: " + phrase);
			double valueNum = Convert.ToDouble(value);
			if (valueNum > complianceLimit)
			{
				Report.Info("The " + carbOtc + " is expected to exceed the compliance limit");
				Report.IsTrue(phrase.Contains("Exceeds the limits"),
					"The " + carbOtc + " exceeds/ does not exceed statement did not match the expected phrase! Expected 'Exceeds the limits..' but found: " + phrase + "'",
					"The " + carbOtc + " exceeds/ does not exceed statement matched the expected phrase");
				return;
			}
			Report.Info("The " + carbOtc + " is not expected to exceed the compliance limit");
			Report.IsTrue(phrase.Contains("Does not exceed the limits"),
				"The " + carbOtc + " exceeds/ does not exceed statement did not match the expected phrase! Expected 'Does not exceed the limits..' but found: '" + phrase + "'",
				"The " + carbOtc + " exceeds/ does not exceed statement matched the expected phrase");
		}

		[StepDefinition(@"I confirm the checkbox with description: (.*) is displayed")]
		public void IConfirmCheckboxWithDescriptionIsDisplayed(string description)
		{
			Report.IsTrue(new NewProduct().StandaloneCheckbox(description) != null,
				$"The checkbox with description: '{description}' was not displayed!",
				$"The checkbox with description: '{description}' was displayed as expected");
		}

		[StepDefinition(@"I (check|uncheck) the checkbox with description: (.*)")]
		public void ICheckTheCheckboxWithDescription(string check, string description)
		{
			var selNewProduct = new NewProduct();
			bool toCheck = false;
			if (check == "check")
			{
				toCheck = true;
			}
			else if (check == "uncheck")
			{
				toCheck = false;
			}
			else
			{
				throw new Exception("Specflow paramater must be equal to 'check' or 'uncheck'");
			}
			bool isChecked = selNewProduct.StandaloneCheckbox(description).Checked();
			if (isChecked == toCheck)
			{
				Report.Failure($"The checkbox was already {check}ed");
				return;
			}
			Report.IsTrue(selNewProduct.CheckStandaloneCheckbox(description),
				$"Failed to check the checkbox with description: '{description}'!",
				$"Successfully checked the checkbox with description: '{description}'");
			Report.IsTrue(selNewProduct.StandaloneCheckbox(description).Checked() == toCheck,
				$"The checkbox was is {check}ed after",
				$"The checkbox is {check}ed as expected");
		}

		[StepDefinition(@"section: (.*) is highlighed in red indicating an error")]
		public void SectionIsHighlightedInRedIndicatingAnError(string section)
		{
			var selNewProduct = new NewProduct();
			string colour = selNewProduct.SectionColour(section);
			// Not the best. Will break if the exact shade changes (hex #A9443F, rgb 169, 68, 66) and verified it is intended
			string expected = "(62, 62, 62, 1)";
			Report.IsTrue(colour.Contains(expected),
				$"Section '{section}' colour was not the expected red! The colour is: {colour}",
				$"Section '{section}' colour was red as expected");
		}

		[StepDefinition(@"I (should|should not) see following statement: (.*)")]
		public void SectionStatement(string shouldOrShouldNot, string option)
		{
			Report.Info("Checking statement");
			var selNewProduct = new NewProduct();
			List<string> found = selNewProduct.GetDisplayedSections();

			if (shouldOrShouldNot.ToLower() == "should")
			{
				Report.IsTrue(found.Contains(option),
				"statement was not as expected! Expected: " + option + ", but found: " + found + "!",
				"statement was showing: " + option + ", as expected!");
			}
			else if (shouldOrShouldNot.ToLower() == "should not")
			{
				Report.IsTrue(!found.Contains(option),
				"statement was not as expected! Not expected: " + option + ", but found: " + found + "!",
				"statement was not showing: " + option + ", as expected!");
			}

		}

		[StepDefinition(@"I click on the Notice of Adoption Article link")]
		public void IClickOnTheNoticeOfAdoptionArticleLink()
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.ClickAdoptionArticleLink(), "Failed to click Notice of Adoption Article link",
				"Successfully clicked Notice of Adoption Article link");
		}

		[StepDefinition(@"I confirm that a new Notice of Adoption Article tab opens and navigate to it")]
		public void ConfirmThatANewTabOpensAndNavigateToIt()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			UL.Automation.SpecFlow.Classes.Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h1[contains(text(),'Notice of Adoption Article')]"), 2) != null)
				{
					Report.Success("The Notice of Adoption Article page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
			Report.Screenshot();
		}

		[StepDefinition(@"I close the Notice of Adoption Article tab")]
		public void ICloseTheNoticeOfAdoptionArticleTab()
		{
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs();

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h1[contains(text(),'Notice of Adoption Article')]"), 2) != null)
				{
					Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
										"Closed tab with url: " + url);
				}
				return;
			}

			Report.Failure("Did not find Notice of Adoption Article page to close");
		}

		[StepDefinition(@"I Check the check box for the TDS/BDS current version question")]
		public void GivenICheckTheCheckBoxForTheTDSBDSCurrentVersionQuestion()
		{
			var selNewProduct = new NewProduct();
		}

		[StepDefinition(@"I confirm the product name: ""(.*)"" is displayed in the header")]
		public void ConfirmTheProductNameIsDisplayedInTheHeader(string name)
		{
			string header = NewProduct.HeaderText;
			MatchCollection matches = Regex.Matches(header, @"\(\d*\)");
			if (matches.Count == 0)
			{
				Report.Failure("Could not find product ID in the New Product header!");
				Report.Screenshot();
				return;
			}
			string bracketedValue = matches[matches.Count - 1].Groups[0].Value;
			string headerName = header.TrimEnd(bracketedValue).Trim();
			Report.IsTrue(headerName == name,
				$@"The name displayed in the header did not match the expected value! Expected: ""{name}"" but got: ""{headerName}""",
				$@"The name displayed in the header matcehd the expected value: ""{name}""");
		}

		[StepDefinition(@"I confirm that retailer ""(.*)"" (is|is not) present under the 'Destination Retailers' column in the UPC table")]
		public void ConfirmRetailerIsPresentUnderTheDestinationRetailersColumnUPCTable(string retailer, string isOrIsNot)
		{

			GeneralUtilities.Wait_for_load_finish();
			List<string> displayedRetailers = new NewProduct().GetAllUPCDestinationRetailers();

			if (isOrIsNot.ToLower() == "is not")
			{
				Report.IsTrue(!displayedRetailers.Contains(retailer),
				$@"Retailer ""{retailer}"" is present under Destination Retailers",
				$@"Retailer ""{retailer}"" is not present under Destination Retailers! Retailers are: {string.Join(", ", displayedRetailers.Select(x => $"'{x}'").ToList())}");
			}
			else
			{
				Report.IsTrue(displayedRetailers.Contains(retailer),
					$@"Retailer ""{retailer}"" is not present under Destination Retailers! Retailers are: {string.Join(", ", displayedRetailers.Select(x => $"'{x}'").ToList())}",
					$@"Retailer ""{retailer}"" is present under Destination Retailers");
			}
		}

		[StepDefinition(@"I click (Save|Cancel) in The Product Page")]
		public void ThenIClickSaveOrCancelInTheProductPage(string saveOrCancel)
		{
			var selNewProduct = new NewProduct();

			if (saveOrCancel.ToLower() == "save")
			{
				Report.IsTrue(selNewProduct.ClickSaveButton(),
					"Failed to click the save button",
					"Clicked the save button");
			}
			else
			{
				Report.IsTrue(selNewProduct.ClickCancelButton(),
					"Failed to click the cancel button",
					"Clicked the cancel button");
			}

		}

		[StepDefinition(@"I Change the Secondary Physical State drop down from its current selection to a new selection")]
		public void GivenIChangeTheSecondaryPhysicalStateDropDownFromItsCurrentSelectionToANewSelection()
		{
			Report.Info("Changing secondary physical state");
			var thisNewProduct = new NewProduct();
			string currentlySelected = thisNewProduct.SelectedOptionsForSection("Secondary Physical State").FirstOrDefault();
			List<string> available = thisNewProduct.GetAllOptionsForSection("Secondary Physical State");

			string newOption = available.FirstOrDefault(x => x != currentlySelected);

			Report.IsTrue(thisNewProduct.SelectSecondaryPhysicalState(newOption), "Failed to select: " + newOption,
				"Selected: " + newOption);

		}

		[StepDefinition(@"I select the first option in the 'Product Line or Brand' drop down and save as Brand{TestCaseId}")]
		public void SelectFirstOptionInBrandDropDown()
		{
			if (WercSmartSettings.TestCaseId == 0)
			{
				throw new Exception("Unable to locate a test case ID in global parameters which is required!");
			}
			Report.Info("Current test case ID: " + WercSmartSettings.TestCaseId);

			var newProduct = new NewProduct();
			List<MyBrands.Brand> options = newProduct.AllProductLineOrBrandOptions();
			if (options.Count == 0)
			{
				// test can't continue
				throw new Exception("No Brands were available to add to the product, which is required by the test!");
				// instead.. go to create a new brand (My Account - My Library)
			}
			Report.Info($"There are {options.Count} brand options. Selecting the first one");
			MyBrands.Brand brand = options.First();
			Report.Info($"Selecting the brand: {brand.Name}");
			Report.IsTrue(newProduct.SetOptionInSectionByValue("Product Line or Brand (optional)", brand.ID, brand.Name),
				$"Failed to set the Product Line or Brand option to: {brand.Name} ({brand.ID})!",
				$"Successfully set the Product Line or Brand option to: {brand.Name} ({brand.ID})");
			Report.Info($@"Saving brand ""{brand.Name}"" to context as: Brand{WercSmartSettings.TestCaseId}");
			Context.AddToContext($"Brand{WercSmartSettings.TestCaseId}", brand);
			Context.AddToContext($"BrandName{WercSmartSettings.TestCaseId}", brand.Name);
		}

		[StepDefinition(@"Data Acceptance page should not show")]
		public void DataAcceptancePageShouldNotShow()
		{
			bool pageHasDisappeared = false;
			var thisNewProduct = new NewProduct();
			for (int i = 0; i < 120; i++)
			{
				if (!thisNewProduct.YesAgreedExists())
				{
					pageHasDisappeared = true;
					break;
				}

				Delay.Seconds(1);
			}

			Report.IsTrue(pageHasDisappeared, "Data acceptance page is still showing",
				"Data acceptance page has gone as expected");
		}

		[StepDefinition(@"For retailer: (.*) I add additional requirements: (.*)")]
		public void ThenIAddAdditionaRequirmentsInfoForRetailer(string retailer, string additionalRequirements)
		{
			var thisNewProduct = new NewProduct();
			Report.IsTrue(thisNewProduct.EnterAdditionalRequirement(retailer, additionalRequirements),
				"Failed to enter additional requirements: " + additionalRequirements + " for retailer: " + retailer,
				"Added additional requirements for retailer: " + retailer);
			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("No Retailer/No UPC Product", "This Private Label");
		}

		//Item Description
		[StepDefinition(@"in the Purchase Summary Screen I should see the following:")]
		public void GivenInThePurchaseSummaryScreenIShouldSeeTheFollowing(Table table)
		{
			Delay.Seconds(1);
			GeneralUtilities.Wait_for_load_finish();

			var mySub = new PaymentMethods_Subscription_Billing();
			mySub.Wait_for_load();
			List<string> items = mySub.GetRowsBelowProduct();
			Report.IsTrue(items.Count() == table.Rows.Count, "Items count should be " + table.Rows.Count, "Items count is " + table.Rows.Count);
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(items.Contains(thisRow["Item Description"]),
					thisRow["Item Description"] + " is not showing as expected",
					thisRow["Item Description"] + " is showing as expected");
			}
		}

		[StepDefinition(@"I Confirm (.*) error message is shown below the (.*) field")]
		public void GivenIConfirmErrorMessageIsShownBelowField(string errorMessage, string field)
		{
			List<InputError> errorsList = new NewProduct().GetAllErrors();
			Report.IsTrue(errorsList.FirstOrDefault(x => x.InputName == field) != null,
				"An error is not showing on field: " + field, "An error is showing on field: " + field);

			Report.Info("Error message is showing as: " + errorsList.FirstOrDefault(x => x.InputName == field).ErrorMessage);

			Report.IsTrue(errorsList.FirstOrDefault(x => x.InputName == field && x.ErrorMessage.Trim() == errorMessage.Trim()) != null,
				"An error message is not showing as expected: " + errorMessage, "An error is showing as expected: " + errorMessage);
		}

		[StepDefinition(@"I enter UPC Number: (.*)")]
		public void GivenIEnterUPCNumberSavedAsUPC(string upcNumber)
		{
			Delay.Seconds(3);
			Report.IsTrue(new NewProduct().InputUPCNumber(upcNumber), "Failed to enter upc number", "Entered upc number");
		}

		[StepDefinition(@"I enter Zero Buffer UPC Number: (.*)")]
		public void GivenIEnterZeroBufferUPCNumberSavedAsUPC(string upcNumber)
		{
			Delay.Seconds(3);
			Report.IsTrue(new NewProduct().InputZeroBufferUPCNumber(upcNumber), "Failed to enter Zero Buffer UPC number", "Entered Zero Buffer UPC number");
		}
		[StepDefinition(@"I enter Zero Buffer Duplicate UPC Number: (.*)")]
		public void GivenIEnterZeroBufferDuplicateUPCNumberSavedAsUPC(string upcNumber)
		{
			Delay.Seconds(3);
			Report.IsTrue(new NewProduct().InputZeroBufferUPCDuplicateNumber(upcNumber), "Failed to enter Zero Buffer Duplicate UPC number", "Entered Zero Buffer Duplicate UPC number");
		}

		[StepDefinition(@"I Select a container type from the drop down list")]
		public void GivenISelectAContainerTypeFromTheDropDownList()
		{
			List<string> containerTypes = new NewProduct().GetContainerOptions();
			// the container type count must be greater than 1 or random number will throw argument out of range exception (cannot have a range between 1 and 0)
			if (containerTypes.Count <= 1)
			{
				Report.Failure("Expected > 1 options to appear under the container select");
				return;
			}
			var random = new Random();
			int randomNumber = random.Next(1, containerTypes.Count - 1);
			Report.IsTrue(new NewProduct().SelectContainerType(containerTypes[randomNumber]),
				"Failed to select: " + containerTypes[randomNumber], "Selected: " + containerTypes[randomNumber]);
		}

		[StepDefinition(@"I (should|should not) see following container type from the drop down list")]
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

		[StepDefinition(@"I enter Size Value: (.*)")]
		public void GivenIEnterSizeValue(string size)
		{
			Report.IsTrue(new NewProduct().InputUPCSize(size), "Failed to enter size: " + size, "Entered size: " + size);
		}

		[StepDefinition(@"I delete retailer (.*) from the UPC")]
		public void IDeleteRetailerFromTheUPC(string retailer)
		{
			Report.IsTrue(new UPC().DeleteRetailer(retailer), "Failed to delete retailer " + retailer + ".",
			"Successfully deleted retailer " + retailer + ".");
		}

		[StepDefinition(@"I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one")]
		public void GivenIConfirmThePackageTypeDropDownListShowsAPackagingTypeAvailableForSelection_DoNotSelectOne()
		{
			Report.IsTrue(new NewProduct().GetAllOptionsForUPCPackageType().Count > 0, "There are no packaging types",
				"Packaging types are showing");
		}

		[StepDefinition(@"I choose (ok|cancel) in the UPCs Warning modal window")]
		public void ChooseInTheUPCsWarningModalWindow(string choice)
		{
			Report.IsTrue(new NoRetailerWarningPopup().ClickChoice(choice), "Clicked " + choice + " in UPCs Warning modal", "Unable to click " + choice + " in UPCs Warning modal");
		}

		[StepDefinition(@"In the UPC page I (should|should not) see Add new Packaging Type link")]
		public void GivenInTheUPCPageIShouldSeeAddNewPackagingTypeLink(string shouldOrNot)
		{
			List<string> labelLinksShowing = new UPC().UpcPageLinks();
			if (shouldOrNot == "should")
			{
				Report.IsTrue(labelLinksShowing.Contains("Add new Packaging Type"), "Add new Packaging Type link was not found", "Add new Packaging Type was found on the upc page as expected");
			}
			else if (shouldOrNot == "should not")
			{
				Report.IsTrue(!labelLinksShowing.Contains("Add new Packaging Type"), "Add new Packaging Type link was found on the upc page, it should not have been", "Add new Packaging Type was not found on the upc page as expected");
			}
			else
			{
				Report.Failure("input values must be either 'should' or 'should not'");
			}
		}

		[StepDefinition(@"In the Regulatory Documents to Provide Page I check that the input field with label: (.*) is shown as (Red|Green)")]
		public void InTheRegulatoryDocumentsToProvidePageICheckThatAllInputFieldsAreRed(string fieldName, string expectedColor)
		{
			Report.IsTrue(new NewProduct().CheckInputFieldXIsColor(expectedColor, fieldName), "The input field color was not as expected", "The input field color was as expected");
		}
		[StepDefinition(@"I check that the input field with label: (.*) is shown as (Red|Green)")]
		public void ICheckThatAllInputFieldsAreRed(string fieldName, string expectedColor)
		{
			if (Report.IsTrue(new NewProduct().InputFieldExists(fieldName), "Feiled to find Input field", "Successfully found the Input field"))
			{ 
			Report.IsTrue(new NewProduct().CheckInputFieldColor(expectedColor, fieldName), "The input field color was not as expected", "The input field color was as expected");
			}
		}

		[StepDefinition(@"I confirm a warning message is shown above the UPC table that reads: (.*)")]
		public void ThenIConfirmAWarningMessageIsShownAboveTheUPCTableThatReads_(string warning)
		{
			Report.IsTrue(new NewProduct().CheckWarningMessageHasAppeared(warning), "Failed to confirm a warning message is shown above the UPC table that reads: " + warning, "Successfully confirmed a warning message is shown above the UPC table that reads:" + warning);
		}

		[StepDefinition(@"In the UPC screen I add a UPC: saved as UPC(.*), container type: (.*) and size: (.*), then I select all certifications")]
		public void InTheUPCScreenIAddUPCDetailsAndSelectAllCertifications(string upc, string containerType, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_,
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			Report.IsTrue(new NewProduct().SelectAllCertifications(), "Failed to select all certifications", "Successfully selected all certifications");

			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I set the Product's GTIN Brick Code to: (.*)")]
		public void ThenISetTheProductsGTINBrickCodeTo(string description)
		{
			var thisNewProduct = new NewProduct();
			new NewProduct().ProductGTINBrickCode = description;
			Report.IsTrue(thisNewProduct.ProductGTINBrickCode == description, "Failed to set the Product's GTIN Brick Code to be: " + description, "Successfully set the Product's GTIN Brick Code to be: " + description);
		}

		[StepDefinition(@"In the Recipient and Product Details tab, I (expand|collapse) the first UPC")]
		public void IExpandFirstUPC(string expandOrCollapse)
		{
			bool isOpen = new UPC().IsFirstUPCTabOpen();
			bool expand = expandOrCollapse == "expand";
			if (!(isOpen ^ expand))
			{
				Report.Info("First UPC tab is already in desired state");
				return;
			}
			else
			{
				Report.IsTrue(new UPC().ClickFirstUPCTab(), $"Failure, failed to {expandOrCollapse} first UPC", $"Success, succeeded to {expandOrCollapse} the first UPC");
			}
		}

		[StepDefinition(@"I check that (Item Number|Part Number|DPCI|OMSID) for retailer (.*) UPC item 1 (should|should not) match the UPC Upload document saved in the Table called: (.*)")]
		public void ICheckNumberForRetailerAgainstUPCUploadTable(string field, string retailer, string present, string tableSavedAs)
		{
			bool showing = present == "should";

			if (Context.Contains(tableSavedAs))
			{
				string retailerAbbr = new RetailerAbbreviations().TryConvertToAbbreviation($"{retailer}");
				string upcTableFieldName = $"{retailerAbbr}: {field}";

				var tableContent = (Table)Context.GetFromContext(tableSavedAs);
				string firstUPC = new UPC().GetExpandedUPC();
				string value = "";
				string test = "";
				foreach (TableRow row in tableContent.Rows)
				{

					test = (string)Context.GetFromContext($"{row["UPC"].ToString().Trim('%')}");
					if (test == firstUPC)
					{
						value = row[upcTableFieldName];
					}
				}


				string fieldValue = new UPC().GetValueOfRetailerFieldInActiveRow($"{retailerAbbr}", field);
				Report.IsTrue(!((value == fieldValue) ^ showing), $"Failure, table {field}: {value} and website {field}: {fieldValue} {present} match and do not.", $"Success, table {field}: {value} and website {field}: {fieldValue} {present} match and do.");
			}
		}

		[StepDefinition(@"I confirm that (Item Number|Part Number|DPCI|OMSID) label text for retailer (.*) UPC item 1 matches: (.*)")]
		public void IConfirmLabelTextForRetailerMatches(string field, string retailer, string expectedText)
		{
			string retailerAbbr = new RetailerAbbreviations().TryConvertToAbbreviation($"{retailer}");
			string fieldValue = new UPC().GetTextOfRetailerLabelInActiveRow($"{retailerAbbr}", field);
			Report.IsTrue(expectedText == fieldValue, $"Failure, expected text for {field}: {expectedText} and actual website text for {field}: {fieldValue} do not match.", $"Success, expected text for {field} and actual website text for {field} match.");
		}

		[StepDefinition(@"I confirm that (Item Number|Part Number|DPCI|OMSID) for retailer (.*) UPC (should|should not) be required")]
		public void IConfirmValueForRetailerIsRequired(string field, string retailer, string present)
		{
			bool showing = present == "should";
			string retailerAbbr = new RetailerAbbreviations().TryConvertToAbbreviation($"{retailer}");
			bool isRequired = new UPC().IsRequiredValueOfRetailerInActiveRow($"{retailerAbbr}", field);
			Report.IsTrue(!(showing ^ isRequired), $"Failure, {field} {present} be required but showed the opposite.", $"Success, {field} {present} be required.");
		}

		[StepDefinition(@"I click the 'Add Part Number' button")]
		public void ThenIClickTheAddPartNumber()
		{
			Report.IsTrue((new NewProduct()).ClickAddPartNumber(), "Failed to click the 'Add Part Number' button!", "Successfully clicked the 'Add Part Number' button");
		}

		[StepDefinition(@"In the Product Information - Pesticide shown, US only, Yes to CA Cleaning Disclosure, select No for everything else - Happy Path")]
		public void GivenICallSharedStepAdditionalProductInformation_PesticideShownUSOnlySelectNoForEverythingElse_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var myNewProductClass = new NewProduct();
			Report.StartStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep("I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field to: Yes ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"Yes");
			}
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"In the Restict Use page I select Do Not Restrict")]
		public void DoNotRestrictUse_Restrict()
		{
			ReportSettings.UseSubSteps = true;
			Report.Info("Selecting No in the Restrict Use section");
			var NewProductObject = new NewProduct();
			Report.IsTrue(NewProductObject.SelectRestrictUseOption(" – Formula is searchable in WERCSmart and does not require an access code"), "Failed to select restriction option", "Successfully selected restriction option");
			Report.StartStep("in the Restrict Use page I click continue");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Restrict Use");
		}
		[StepDefinition(@"I confirm the UPC table area is shown in red highlight")]
		public void ThenIConfirmTheUPCTableAreaIsShownInRedHighlight()
		{
			Report.IsTrue(new NewProduct().CheckUPCTableIsHighlightedRed(), "Failed to confirm the UPC table area is shown in red highlight", "Successfully confirmed the UPC table area is shown in red highlight");
		}


		[StepDefinition(@"I confirm the UPC Duplicate Warning Icon is visible")]
		public void ThenIConfirmTheUPCDuplicateWarningIconIsVisible()
		{
			Report.IsTrue(new NewProduct().CheckIfUPCDuplicateWarningAppears(), "Failed to find the UPC Duplicate Warning Messsage!", "Successfully found the UPC Duplicate Warning Message!");
		}

		[StepDefinition(@"I check that the Select Option warning is visible")]
		public void ThenICheckThatTheSelectAtLeastOneOfTheseOptionsWarningIsVisible()
		{
			Report.IsTrue(new NewProduct().CheckDataAcceptanceSelectOptionWarningIsVisible(), "Failed to find the Select Option Warning!", "Successfully found the Select Option Warning!");
		}
		[StepDefinition(@"I check that the Select Option warning is not visible")]
		public void ThenICheckThatTheSelectAtLeastOneOfTheseOptionsWarningIsNotVisible()
		{
			Report.IsTrue(new NewProduct().CheckDataAcceptanceSelectOptionWarningIsNotVisible(), "Failed to not the Select Option Warning!", "Successfully did not find the Select Option Warning!");
		}

		[StepDefinition(@"I check that there are no error messages present on the Data Acceptance Screen")]
		public void ThenICheckThatThereAreNoErrorMessagesPresentOnTheDataAcceptanceScreen()
		{
			Report.IsTrue(new NewProduct().CheckFixAllErrorsMessageIsNotVisible(), "Failed to check that there are no error messages present on the Data Acceptance Screen", "Successfully checked that there are no error messages present on the Data Acceptance Screen");
		}

		[StepDefinition(@"I confirm the email registered: (.*) is populated in the field under the Statement")]
		public void ThenIConfirmTheEmailRegisteredWERCSmart_ProductsAutomationAccountIsPopulatedInTheFieldUnderTheStatement(string accountSavedAs)
		{
			var newProduct = new NewProduct();
			//Get email address from account, check against displayed email.

			string email = newProduct.GetUserEmailAddress(accountSavedAs);

			string dataAcceptanceEmail = newProduct.CheckDataAcceptanceEmailIsPopulated();

			Report.IsTrue(new NewProduct().CheckEmailAddressAgainstDataAcceptanceEmail(email, dataAcceptanceEmail), "Failed to check user email: " + email + " against: " + dataAcceptanceEmail, "Successfully checked user email: " + email + " against: " + dataAcceptanceEmail);
		}

		[StepDefinition(@"In Regulatory Documents to Provide I see text:(.*)")]

		public void RegulatoryDocumentsText(string text)
		{
			List<string> getText = new List<string>();
			getText = new NewProduct().Get3rdPartyPageAlerts();
			Report.IsTrue(getText.Contains(text), $"Failed to confirm text '{text}' is shown", $"Successfully confirmed text '{text}' is shown");
		}


		#endregion
		[StepDefinition(@"In the California Cleaning Product Disclosure tab, I enter: (.*) in the Final Domestic Distributor")]
		public void GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInFinalDomesticDistributorTextField(string text)
		{
			Report.IsTrue(new NewProduct().FinalDomesticDistributor(text), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure tab, I enter: (.*) in the Company's Toll-Free Phone Number")]
		public void GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInTollFreePhoneNumberTextField(string text)
		{
			Report.IsTrue(new NewProduct().CompanyTollFreePhoneNumber(text), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure tab, I enter: (.*) in the Company Web Address")]
		public void GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInCompanyWebAddressTextField(string text)
		{
			Report.IsTrue(new NewProduct().CompanyWebAddress(text), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		[StepDefinition(@"I check for an error in the following fields in the 'Lithium Battery Transportation' Section")]
		public void GivenICheckForAnErrorInTheFollowingFields(Table table)
		{

			var NewProductObject = new NewProduct();
			Report.IsTrue(NewProductObject.CheckForErrorInTheFollowingFieldsInTheLithiumBatteryTransportationSection(table), "Failed to find an error in at least one of the fields", "Successfully found errors in all of the fields");

		}

		[StepDefinition(@"Data Accpetance Screen shows error with message: (.*)")]
		public void DataAcceptanceScreenShowsError(string expectedError)
		{
			Report.IsTrue(new NewProduct().DataAcceptanceShowsAlertX(expectedError), "The expected alert was not found", "The expected alert was found");
		}

		[StepDefinition(@"I unselect the option: (.*) under section: (.*) and subsection: (.*)")]
		public void ForTheOptionSubOptionUnselect(string option, string section, string subSection)
		{
			Report.IsTrue(new NewProduct().UnsetOptionInSectionSubSection(section.Trim(), subSection.Trim(), option.Trim()),
				$"Failed to unset the input to: '{option}' in section: '{section}' and subection: '{subSection}'",
				$"Successfully unset the input to: '{option}' in section: '{section}' and subection: '{subSection}'");
		}

		[StepDefinition(@"I unselect option: (.*) under section: (.*)")]
		public void ForTheOptionUnselect(string option, string section)
		{
			Report.IsTrue(new NewProduct().UnsetOptionInSection(section.Trim(), option.Trim()),
				$"Failed to unset the input to: '{option}' in section: '{section}'",
				$"Successfully unset the input to: '{option}' in section: '{section}'");
		}

		[Then(@"I check if alert message displays the following text: (.*)")]
		public void ThenICheckIfAlertMessageDisplaysTheFollowingText(string displayedText)
		{
			var NewProductObject = new NewProduct();
			Report.IsTrue(NewProductObject.CheckAlertMessageText(displayedText), "The alert message text did not match", "The alert message text did match");
		}

		[StepDefinition(@"I check the options in the dropdown menus for the following sections")]
		public void ThenICheckTheOptionsInTheDropdownMenusForTheFollowingSections(Table table)
		{
			NewProduct newProductObject = new NewProduct();
			newProductObject.CheckOptionsInDropDownMenusForTheFollowingSectinons(table);
		}

		[StepDefinition(@"I (should|shoult not) see the PNK section title in the Product Information with the following text: (.*)")]
		public void ThenIShouldSeeThePNKSectionTitleInTheAdditionalProductInformationWithTheFollowingText(string shouldOrShouldNot, string titleText)
		{
			NewProduct newProductObject = new NewProduct();
			newProductObject.CheckForPNKSectionTitleWithText(shouldOrShouldNot, titleText);
		}

		[StepDefinition(@"in page Pesticide Details - State Registration page I should see no error")]
		public void ThenInPagePesticideDetails_StateRegistrationPageIShouldSeeNoError()
		{
			PesticideDetailsState pesticideDetailsStateObject = new PesticideDetailsState();
			Report.IsTrue(pesticideDetailsStateObject.CheckIfThereIsNoErrorInThePesticideDetailsStateRegistration(), "Failed to display no error", "Successfully displayed no errors");
		}


		[StepDefinition(@"I set the following data: (.*) for the following state: (.*)")]
		public void GivenISetTheFollowingDataErtForTheFollowingStateMA(string date, string state)
		{
			PesticideDetailsState pesticideDetailsStateObject = new PesticideDetailsState();
			Report.IsTrue(pesticideDetailsStateObject.EnterExpirationDateForStatePesticideReigstration(date, state), "Failed to enter a date", "Successfully entered a date");
		}


		[StepDefinition(@"I enter the following EPA Pesticide Registration No\.: (.*)")]
		public void ThenIEnterTheFollowingEPAPesticideRegistrationNo_(string enterText)
		{
			PesticideDetailsState pesticideDetailsStateObject = new PesticideDetailsState();
			Report.IsTrue(pesticideDetailsStateObject.EnterEPAPesticideRegistrationNo(enterText), "Failed to enter text", "Successfully entered text");
		}

		[StepDefinition(@"I set first VOC option to: 'Yes'")]
		public void GivenISetFirstVOCOptionToYes1(string yesOrNo)
		{
			Ingredients ingredientsObject = new Ingredients();
			ingredientsObject.SetFirstVOCOption(yesOrNo);
		}

		[StepDefinition(@"In the Regulatory Documents to Prodivde page, I enter the value: (.*) into the WHMIS SDS Docmument Date Field")]
		public void InTheRegualtoryDocumentsToProvidePageIEnterValueIntoWHMISSDSDocumentDateField(string value)
		{
			Report.IsTrue(new NewProduct().EnterWHMISSDSDocumentDate(value), "Text: " + value + " was not successfully inputted into the field!", "Text: " + value + " was successfully inputted into the field!");

		}

		[StepDefinition(@"I check that the input field with label: (.*) has the following text: (.*)")]
		public void ICheckThatTheInputFieldWithLabelHasTheFollowingText(string fieldName, string text)
		{
			Report.IsTrue(new NewProduct().CheckInputFieldText(fieldName, text), "The input field text was not as expected", "The input field text was as expected");
		}

		[StepDefinition(@"I check that the input field with label: (.*) has the following placeholder: (.*)")]
		public void ICheckThatTheInputFieldWithLabelHasTheFollowingPlaceholder(string fieldName, string placeholder)
		{
			Report.IsTrue(new NewProduct().CheckInputFieldPlaceholder(fieldName, placeholder), "The input field placeholder was not as expected", "The input field placeholder was as expected");
		}


		[StepDefinition(@"I confirm the Regulatory Information 3 page contains the statement: (.*)")]
		public void IConfirmRegulatoryInformation3PageContainsStatement(string text)
		{
			var newProductPage = new NewProduct();
			string statementtextfound = newProductPage.GetRegulatoryInformation3Statement();
			Report.Info($"The expected Text was {text}");
			Report.Info($"The found text was {statementtextfound}");
			Report.IsTrue(statementtextfound == text, "The text found was not a match", "The text found matched the expected text");
		}

		[StepDefinition(@"I check the uploaded file name of document type: (.*) and for control label: (.*) matches: (.*)")]
		public void CheckUploadedFileNameForTypeAndLabel(string type, string label, string filename)
		{

			Report.IsTrue(new NewProduct().CheckFileNameForSectionAndType(type, label, filename), "File name did not match the expected", "The file name matched");

		}

		[StepDefinition(@"In the regulatory documents to provide screen I tick the box next to the question: 'I confirm I am providing the most current Safety Data Sheet \(SDS\), Article Information Sheet (AIS) and/or Product Label for this registration'")]
		public void SelectConfirmRegulatoryDocumentsConfirmationQuestion()
		{
			Report.IsTrue(new NewProduct().CheckRegulatoryDocumentsConfirmationBox(), "Failed to tick the confirmation option", "Successfully ticked the confirmation option");

		}

		[StepDefinition(@"I confirm that the the option: (.*) (.*) checked for the following section: (.*)")]
		public void ThenIConfirmThatTheTheOptionCheckedForTheFollowingSection(string option, string isOrIsNot, string section)
		{
			var newProductPage = new NewProduct();

			if (isOrIsNot.ToLower() == "is")
			{
				Report.IsTrue(newProductPage.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was not checked", "The option " + option + " was checked");
			}
			else
			{
				Report.IsTrue(!newProductPage.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was checked", "The option " + option + " was not checked");
			}
		}

		[StepDefinition(@"I confirm that the transportation option: (.*) that was selected is still the same")]
		public void ThenIConfirmThatThatTheTransportationOptionSelectedIsSame(string option)
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.GetTransportationOption(option), "The transportation option " + option + " selected was not same", "The transportation option " + option + " selected was still same");
			
		}
		[StepDefinition(@"I Change the Transportation option from the dropdown to: (.*)")]
		public void GivenInTheSupplierReportPageInTheSelectRetailerDropdownISelect(string option)
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.SelectTransportationOption(option),
				"Failed to select transportation option: " + option, "Successfully selected transportation option: " + option);
		}
		[StepDefinition(@"I click on the arrow next to the UPC data")]
		public void ThenIClickArrow()
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.ClickArrow(), "Failed to click the arrow next to the UPC data", "Succesfully clicked the arrow next to the UPC data");
		}

		[StepDefinition(@"I select the case UPC dropdown arrow to (expand|collapse) the UPC saved as: (.*)")]
		public void ThenISelectTheCaseUPCDropdownArrowForUPCSavedAsUPC(string expandOrCollapse, string savedAs)
		{
			var newProductPage = new NewProduct();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(newProductPage.SelectCaseUPCDropDownArrowForUPC(savedAs, expandOrCollapse), "Failed to select dropdown arrow with the UPC: " + savedAs, "Succesfully selected dropdown arrow with the UPC: " + savedAs);
		}

		[StepDefinition(@"I confirm the correct UPC: saved as (.*) is displayed in the UPC Number textfield")]
		public void ThenIConfirmTheCorrectUPCSavedAsUPCIsDisplayedInTheUPCNumberTextfield(string savedAs)
		{
			var newProductPage = new NewProduct();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(newProductPage.ConfirmUPCNumberIsDisplayedInUPCNumberField(savedAs), "Failed to confirm UPC Number field contains UPC: " + savedAs, "Successfully confirmed UPC Number field contains UPC: " + savedAs);
		}

		[StepDefinition(@"I confirm Individual UPC field does not display any options")]
		public void ThenIConfirmIndividualUPCFieldDoesNotDisplayAnyOptions()
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.CheckForOptionsInIndividualUPCField(), "Failed to confirm the Individual UPC field has no options", "Successfully confirmed the Individual UPC field has no options");
		}

		[StepDefinition(@"I confirm the (UPC|Name|Container|Size|Quantity|Individual UPC|Transport|Package) field is shown in the Universal Product Code \(UPC\) Page")]
		public void ThenIConfirmTheQuantityFieldIsShownInTheUniversalProductCodeUPCPage(string field)
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.ConfirmFieldExists(field), "Failed to confirm " + field + " field exists", "Successfully confirmed the " + field + " exists");
		}


		[StepDefinition(@"I confirm the (UPC|Name|Container|Size|Quantity|Individual UPC|Transport|Package) field is below the (UPC|Name|Container|Size|Quantity|Individual UPC|Transport|Package) field")]
		public void ThenIConfirmTheContainerTypeFieldIsBelowTheUPCNumberField(string lowerField, string upperField)
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.ConfirmLowerFieldIsBelowUpperField(lowerField, upperField), "Failed to confirm " + lowerField + " field is below " + upperField + " field", "Successfully confirmed the " + lowerField + " field is below " + upperField + " field");
		}


		[StepDefinition(@"I confirm that the truck icon is displaying next to the case UPC: saved as (.*)")]
		public void ThenIConfirmThatTheTruckIconIsDisplayingNextToTheCaseUPCSavedAsUPC(string savedAs)
		{
			var newProductPage = new NewProduct();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(newProductPage.ConfirmTruckIconIsDisplayingNextToUPC(savedAs), "Failed to confirm truck icon is displayd with the UPC: " + savedAs, "Successfuly confirmed truck icon is displayd with the UPC: " + savedAs);
		}


		[StepDefinition(@"I check if the case UPC details are collapsed for UPC: saved as (.*)")]
		public void ThenICheckIfTheCaseUPCDetailsAreCollapsedForUPCSavedAsUPC(string savedAs)
		{
			var newProductPage = new NewProduct();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(newProductPage.ConfirmCaseUPCDetailsAreCollapsedForUPC(savedAs), "Failed to confirm case UPC details are collapsed with the UPC: " + savedAs, "Succesfully confirmed case UPC details are collapsed with the UPC: " + savedAs);
		}

		[StepDefinition(@"I confirm the case dropdown with the following UPC: saved as (.*) (should|should not) be available for selection")]
		public void ThenIConfirmTheCaseDropdownWithTheFollowingUPCSavedAsUPCIsAvailableForSelection(string savedAs, string shouldOrShouldNot)
		{
			var newProductPage = new NewProduct();
			savedAs = Context.GetFromContext(savedAs).ToString();

			if (shouldOrShouldNot == "should")
			{
				Report.IsTrue(newProductPage.ConfirmCaseDropDownWithUPCIsAvailableForSelection(savedAs), "Failed to confirm that the dropdown with the UPC: " + savedAs + " is available for selection", "Confirmed that the dropdown with the UPC: " + savedAs + " is available for selection");
			}
			else
			{
				Report.IsTrue(!newProductPage.ConfirmCaseDropDownWithUPCIsAvailableForSelection(savedAs), "Failed to confirm that the dropdown with the UPC: " + savedAs + " is not available for selection", "Confirmed that the dropdown with the UPC: " + savedAs + " is not available for selection");
			}
		}

		[StepDefinition(@"I confirm a case dropdown contains the following UPC: saved as (.*)")]
		public void ThenIConfirmACaseDropdownContainsTheFollowingUPCSavedAsUPC(string savedAs)
		{
			var newProductPage = new NewProduct();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(newProductPage.ConfirmCaseDropDownContainsUPC(savedAs), "Failed to confirm that the dropdown contained the UPC: " + savedAs, "Confirmed that the dropdown contained the UPC: " + savedAs);
		}


		[StepDefinition(@"I check for a truck icon for UPC: saved as (.*)")]
		public void ThenICheckForATruckIconForUPCSavedAsUPC(string savedAs)
		{
			var UPCPage = new UPC();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(UPCPage.ConfirmTruckIconIsDisplayedForUPC(savedAs), "Failed to find truck icon for UPC: " + savedAs, "Successfully found truck icon for UPC: " + savedAs);
		}

		[StepDefinition(@"I confirm the Consent to Tier 2.1, 2.2, 4.2 Data shows the answer: (.*)")]
		public void GivenIConfirmTheConsentToTierDataShowsTheAnswerAccept(string answer)
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.ConfirmTierDataShowsCorrectAnswer(answer), "Failed to confirm the following answer: " + answer, "Successfully confirmed the following answer: " + answer);
		}

		[StepDefinition(@"I confirm the Formulation > Batteries displays the correct text")]
		public void GivenIConfirmTheFormulationBatteriesDisplaysTheCorrectText()
		{
			var newProductPage = new NewProduct();
			Report.IsTrue(newProductPage.CheckTextInForumulationBatteriesPage(), "The text in the Formulation > Batteries page displayed the incorrect text", "The text in the Formulation > Batteries page displayed the correct text");
		}

		[StepDefinition(@"In the Optional Reports and Documents Available for Purchase page, the footer text contains: (.*)")]
		public void InTheOptionalReportsAndDocumentsPageFooterTextContains(string expectedText)
		{
			Report.IsTrue(new NewProduct().ConfirmOptionalReportsFooterContains(expectedText), "Failed to find the text", "The text was found");

		}

		[StepDefinition(@"In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet \(SDS\)' I tick confirm")]
		public void InTheRegulatoryDocumentsToProvideScreenIfTheConfirmSDSQuestionIsSeenThenGrant()
		{

			var MyStepsNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();

			if (newProdClass.CheckBoxOptionExists("I confirm I am providing the most current Safety Data Sheet"))
			{
				Report.StartStep(@"In the regulatory documents to provide screen I tick the box next to the question: 'I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration'");
				MyStepsNewProduct.SelectConfirmRegulatoryDocumentsConfirmationQuestion();
			}
		}

		[StepDefinition(@"In the Product Information Page, for the Question 'Select Countries the product may be sold in' I uncheck 'United States' if it is already selected")]
		public void InTheProductInformationPageUnselectUS()
		{
			var MyNewProduct = new NewProduct();
			Report.StartStep("Make sure the United States check box is NOT selected, if it is uncheck it");
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}
		}
		[StepDefinition(@"In the Additional Documents to Provide screen I upload label for section 'Provide Full Product Label \(required\)'")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_VOC_ProductLabel()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			MyNewProduct.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I set the Product Identification \(Optional\) field to Proudct ID saved as: (.*)")]
		public void GivenISetTheProductIdentificationOptionalFieldToProudctIDSavedAs(string savedAs)
		{
			string id = "";

			if (Context.Contains(savedAs))
			{
				var MyNewProduct = new StepsNewProduct();
				id = Context.GetFromContext(savedAs).ToString();
				MyNewProduct.SetTheSectionOptionTo("Product Identification (Optional)", id);
			}
			else
			{
				Report.Failure("Product ID saved as: " + savedAs + " was not found in context");
			}
		}

		[StepDefinition(@"I Select a height from the drop down list")]
		public void GivenISelectAHeightFromTheDropDownList()
		{
			List<string> HeightList = new NewProduct().GetHeightOptions();
			// the container type count must be greater than 1 or random number will throw argument out of range exception (cannot have a range between 1 and 0)
			if (HeightList.Count <= 1)
			{
				Report.Failure("Expected > 1 options to appear under the height select");
				return;
			}
			var random = new Random();
			int randomNumber = random.Next(1, HeightList.Count - 1);
			Report.IsTrue(new NewProduct().SelectHeight(HeightList[randomNumber]),
				"Failed to select: " + HeightList[randomNumber], "Selected: " + HeightList[randomNumber]);
		}

		[StepDefinition(@"I confirm SKU field is blank")]
		public void GivenIConfirmSKUFieldIsBlank()
		{
			Report.IsTrue(new NewProduct().ConfirmSKUFieldWasBlank(), "Failed to find the SKU field is blank", "Successfully found the SKU field is blank");
		}
		[StepDefinition(@"I click ok")]
		public void IClickOK()
		{
			var thisModalDialog = new ModalDialog();
			Report.Info("Clicking OK in the popup");
			thisModalDialog.Click_OK();
			Delay.Seconds(1);
		}
	}

	//public class UPCWarning : SeleniumBaseObject
	//{
	//	public const string BasePath = "//div[@class='modal-content']//h4[@data-bind='text: title']/../..";

		//	protected override By ContainerElementLocator => By.XPath(BasePath);

		//	public bool ClickUPCWarningButton(string choice)
		//	{
		//		IWebElement modalWindow = this.containerElement.WaitUntilElementVisible(By.XPath(BasePath), 5);
		//		IWebElement modalTitle = modalWindow.FindElement(By.XPath(".//h4[@class='modal-title']"), 10);

		//		if (modalWindow is null || modalTitle is null)
		//		{
		//			Report.Failure("Could not locate UPC Warning modal window.");
		//			return false;
		//		}

		//		Report.IsTrue(modalTitle.Text == "UPCs Warning!", "Expected modal window title not found! Found: " + modalTitle.Text, "Modal window title '" + modalTitle.Text + "' located as expected.");
		//		switch (choice)
		//		{
		//			case "ok":
		//				IWebElement deleteBtn = modalWindow.FindElement(By.XPath("//button[contains(@data-bind,'clickedYes')]"), 2);
		//				return deleteBtn.TryClick();
		//			case "cancel":
		//				IWebElement cancelBtn = modalWindow.FindElement(By.XPath("//h4[@data-bind='text: title']//..//..//div[@class='modal-footer']//button"), 2);
		//				return cancelBtn.TryClick();
		//		}
		//		return false;
		//	}
		//}

	}




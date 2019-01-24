using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes.New_Product;


namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsNewProduct
	{
		[StepDefinition(@"the Product Type page should be loaded")]
		[StepDefinition(@"the Product Editor page should be loaded")]
		public void ProductTypePageLoaded()
		{

			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Product Type page should be loaded");
			try
			{
				Report.Info("Product Type page should be loaded");
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.Wait_for_load(10), "Product Type page did not load!", "Product Type page loaded successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the product saved as: (.*) should be visible in editor")]
		public void CorrectProductVisibleInEditor(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Product saved as " + savedAs + " is visible in editor");
			try
			{
				Report.Info("Checking that the product saved as " + savedAs + " is visible in editor");
				var product = (ProductGridItem)Context.GetFromContext(savedAs);
				Report.Info("Checking that Product with ID: '" + product.ProductId + "' is visible!");
				var expectingToFind = product.ProductName + " (" + product.ProductId + ")";
				Report.Info("Expecting to find string: '" + expectingToFind + "'");
				var selNewProduct = new NewProduct();
				var currentlyShowing = selNewProduct.GetCurrentProduct();
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Creating shell product with name " + name + ", saved as " + savedAs);
			try
			{
				Report.Info("Creating shell product with name " + name + ", saved as " + savedAs);
				var selNewProduct = new NewProduct();
				if (!selNewProduct.Wait_for_load(10))
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
				selNewProduct.ProductName = name;
				Report.Info("Setting Product Type to be: 'Game System w/Battery'");
				selNewProduct.ProductType = "Game System w/Battery";
				Report.Screenshot();
				Report.Info("Clicking continue");
				Report.IsTrue(selNewProduct.ClickContinue(), "Failed to click 'Continue'!");
				Report.Info("Getting Product ID");
				var fullProductName = selNewProduct.GetHeader();
				// Product Name made out of the name + the Id - so if we remove the Name from the product we should be left with an ID!
				var productId = fullProductName.Replace(name, "").Replace("(", "").Replace(")", "").Trim();
				Report.Info("ProductID was: '" + productId + "'");
				var productEntry = new ProductGridItem();
				productEntry.ProductId = productId;
				productEntry.ProductName = name.Trim();
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

		[StepDefinition(@"I click continue")]
		public void ClickContinue()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking continue");
			try
			{
				Report.Info("Clicking continue");
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.ClickContinue(), "Failed to click 'Continue'!", "Clicked continue successfully!");
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
			var found = selNewProduct.BatteyWarning();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Warning message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Warning message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I should see an error message: (.*)")]
		public void ErrorMessageSpecific(string message)
		{
			Report.Info("Checking error message");
			var selNewProduct = new NewProduct();
			var found = selNewProduct.ErrorMessage();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Error message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Error message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I should not see an error message: (.*)")]
		public void NotErrorMessageSpecific(string message)
		{
			Report.Info("Checking error message: " + message + " is not appearing");
			var selNewProduct = new NewProduct();
			var found = selNewProduct.ErrorMessage();

			Report.IsTrue(found == null || found.Trim() != message.Trim(),
				"Error message was showing when it wasn't expected to! Error: " + message,
				"As expected, the error message was not showing. Error: " + message);
		}

		[StepDefinition(@"I should not see any error messages")]
		public void NoErrorMessages()
		{
			Report.Info("Check no error messages are appearing");
			var selNewProduct = new NewProduct();
			var found = selNewProduct.ErrorMessage();

			Report.IsTrue(found == null,
				"Error message was showing when it wasn't expected to! Error: " + found,
				"As expected, the error message was not showing.");
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
			NewProduct selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.ClickBrowseForVolatileOrganicCompounds(), "Failed to upload ", "Successfully upload ");
		}

		[StepDefinition(@"I click the browse button for label: (.*) and upload PDF: (.*)")]
		public void UploadPDFFile(string label, string pdfFile)
		{
			Report.IsTrue(new NewProduct().UploadFileForSection(label, pdfFile), "Failed to upload PDF file: " + pdfFile, "Successfully uploaded PDF file: " + pdfFile);
		}

		[StepDefinition(@"I click the browse button for label: (.*) in section: (.*) and upload PDF: (.*)")]
		public void UploadPDFFileSectionAndType(string label, string section, string pdfFile)
		{
			Report.IsTrue(new NewProduct().UploadFileForSectionAndType(label, section, pdfFile), "Failed to upload PDF file: " + pdfFile, "Successfully uploaded PDF file: " + pdfFile);

		}

		[StepDefinition(@"I purchase the following additional documents:")]
		public void ThenIPurchaseTheFollowingAdditionalDocuments(Table table)
		{
			foreach (var row in table.Rows)
			{
				Report.IsTrue(new NewProduct().AddDocument(row["Document Name"], row["Language"]), "Failed to add document: " + row["Document Name"], "Succesfully added document: " + row["Document Name"], false, false);
			}

			Report.Screenshot();
		}

		[StepDefinition(@"the following additional documents should be selected:")]
		public void TheFollowingAdditionalDocumentsShouldBeSelected(Table table)
		{
			foreach (var row in table.Rows)
			{
				Report.IsTrue(new NewProduct().AddDocument(row["Document Name"], row["Language"]), "Failed to add document: " + row["Document Name"], "Succesfully added document: " + row["Document Name"], false, false);
			}

			Report.Screenshot();
		}

		[StepDefinition(@"the following additional documents should be showing as selected:")]
		public void TheFollowingLanguagesShouldBeSelectedCorrectly(Table table)
		{
			foreach (var row in table.Rows)
			{
				var languagesShowing = new NewProduct().GetSelectedLanguagesForDocument(row["Document Name"]);
				var languagesExpected = row["Language"].Split(',').Select(x => x.Trim());

				Report.Info("Languages found for " + row["Document Name"] + ": " + string.Join(", ", languagesShowing));

				foreach (var lang in languagesExpected)
				{
					Report.IsTrue(languagesShowing.Contains(lang), "Failed to find " + lang + " in the list of selected languages!", "Successfully found " + lang + " in the list of selected languages!", false, false);
				}
			}

			Report.Screenshot();
		}

		[StepDefinition(@"I should see the header (.*)")]
		public void CorrectHeaderShouldBeShowing(string header)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the header is showing " + header);
			try
			{
				Report.Info("Checking that the header is showing " + header);
				var selNewProduct = new NewProduct();

				if (!selNewProduct.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				var headerShowing = selNewProduct.GetHeader();
				Report.IsTrue(headerShowing.Trim() == header.Trim(),
					"Header was not showing as expected! Expected: '" + header + "', but found: '" + headerShowing + "'!",
					"Header was showing: '" + header + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the statement (.*)")]
		public void CorrectInitialStatementShouldAppear(string statement)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the statement " + statement);
			try
			{
				Report.Info("Checking that I see the statement '" + statement + "'");
				var selNewProduct = new NewProduct();
				var statementShowing = selNewProduct.GetInitialStatement();
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I Select the Create a New Registration radio button");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.Wait_for_load(10), "New product page is not loaded", "New product page is loaded.");
				selNewProduct.SelectTypeOfProductToCreate("New");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the (.*) page I click Continue")]
		public void GivenInTheNewProductPageIClickContinue(string page)
		{
			var selNewProduct = new NewProduct();
			if (!selNewProduct.Wait_for_load(10))
			{
				Report.Failure("New Product page is not loaded");
				return;
			}
			if (page.ToLower() != "new product" && !selNewProduct.WaitForSection(page))
			{
				Report.Error($@"The page title did not match expected! Expected ""{page}""");
			}

			string pageTitle = selNewProduct.GetHeader();
			Report.Info("Clicking Continue");
			Report.IsTrue(selNewProduct.ClickContinue(), "Failed to click continue in the new product page!", "Successfully clicked continue in the new product page");
			Delay.Seconds(0.2);
			if (pageTitle == "The Product")
			{
				try
				{
					ModalDialog thisModalDialog = new ModalDialog();
					if (thisModalDialog.Exists)
					{
						if (thisModalDialog.GetTitle() == "Warning")
						{
							if (thisModalDialog.GetText().Contains("You are registering a formula (Raw material)"))
							{
								thisModalDialog.Click_OK();
								Delay.Seconds(0.1);
							}
						}
					}
				}
				catch (Exception e)
				{
					//Do nothing
				}


			}

		}

		[StepDefinition(@"I save the product information as: (.*)")]
		public void SaveProductInformation(string savedas)
		{
			var prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info("Saving product: " + prodDetails.Id + ",  " + prodDetails.Name);
			Context.AddToContext(savedas, prodDetails);
			Report.Success("Product Information saved!");
		}

		[StepDefinition(@"I save the context product information as: (.*) where id is: (.*) and product name is: (.*)")]
		public void GivenISaveTheContextProductInformationAsTestCaseWhereIdIsAndProductNameIsTest(string savedas, string id, string name)
		{
			var prodDetails = new ProductInformation() { Id = id, Name = name };
			Context.AddToContext(savedas, prodDetails);
			Report.Success("Product Information saved!");
		}

		[StepDefinition(@"I should see the (.*) Page")]
		public void GivenIShouldSeeXPage(string page)
		{
			var selNewProduct = new NewProduct();
			if (selNewProduct.Wait_for_load())
			{
				Report.IsTrue(selNewProduct.WaitForSection(page),
					page + " is not showing when it was expected to",
					page + " is showing as expected");
				Report.Screenshot();
			}
			else
			{
				Report.Failure("New product page was not found");
			}
		}

		[StepDefinition(@"I should see the Additional Information Page")]
		public void GivenIShouldSeeTheAdditionalInformationPage()
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForSection("Additional Product Information"), "Additional product information is not showing",
				"The additional product information page is showing as expected");
		}

		[StepDefinition(@"In the Product Type tab of the New Product Page, I enter: (.*) in the Product Name text field")]
		public void GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheProductNameTextField(string productName)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Type tab of the New Product Page, I enter: " + productName + " in the Product Name text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.ProductName = productName;
				Delay.Seconds(1);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page I add the following batteries:")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageIAddTheFollowingBatteries(TechTalk.SpecFlow.Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page I add the following batteries:");
			try
			{
				List<Battery> listOfBatteries = new List<Battery>();
				//| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
				foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
				{
					Battery thisBattery = new Battery() {
						BatteryType = thisRow["Battery Type"],
						Manufacturer = thisRow["Manufacturer"],
						NumberPerPackage = Convert.ToInt16(thisRow["Number of batteries per package"].Trim()),
						RequiredToRun = Convert.ToInt16(thisRow["How many batteries required to run"].Trim())
					};
					listOfBatteries.Add(thisBattery);
				}
				var selNewProduct = new NewProduct();

				if (listOfBatteries.Count > 0)
				{
					selNewProduct.Batteries = listOfBatteries;
					selNewProduct.DeleteEmptyBatteryRows();
				}
				else
				{
					throw new Exception("There are no batteries to set");
				}


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for DOT I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForDotiSelect(string option)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");

			selNewProduct.Dot = option;

			Report.IsTrue(selNewProduct.Dot == option,
				"Failed to set battery packaged option: " + option,
				"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for IMDG I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForImdgiSelect(string option)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");

			selNewProduct.Imdg = option;

			Report.IsTrue(selNewProduct.Imdg == option,
				"Failed to set battery packaged option: " + option,
				"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for IATA I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForIataiSelect(string option)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");

			selNewProduct.Iata = option;

			Report.IsTrue(selNewProduct.Iata == option,
				"Failed to set battery packaged option: " + option,
				"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for TDG I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForTdgiSelect(string option)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");

			selNewProduct.Tdg = option;

			Report.IsTrue(selNewProduct.Tdg == option,
				"Failed to set battery packaged option: " + option,
				"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, for Indicate how battery is packaged I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForIndicateHowBatteryIsPackagedISelectX(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page, for Indicate how battery is packaged I select: " + option);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
					"Product characteristics tab is loaded.");

				selNewProduct.IndicateHowBatteryIsPackaged = option;

				Report.IsTrue(selNewProduct.IndicateHowBatteryIsPackaged == option,
					"Failed to set battery packaged option: " + option,
					"Successfully set battery packaged option: " + option);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, for U\.S\. Toxic Substances Control Act \(TSCA\) status I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForU_S_ToxicSubstancesControlActTSCAStatusISelectOption(string option)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");

			selNewProduct.TscaStatus = option;

			Report.IsTrue(selNewProduct.TscaStatus == option,
				"Failed to set TSCA status: " + option,
				"Successfully set TSCA status: " + option);
		}

		[StepDefinition(@"In the Additional Information Page for Product is solely for the Retailer's use I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductIsSolelyForTheRetailerSUseISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page for Product is solely for the Retailer's use I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");

				bool expected = (noOrYes == "Yes");


				selNewProduct.SolelyForRetailersUse = expected;

				Report.IsTrue(selNewProduct.SolelyForRetailersUse == expected,
					"Failed to set Product is solely for the Retailer's use: " + noOrYes,
					"Successfully set Product is solely for the Retailer's use: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I set all the metal presence value to: (Yes|No)")]
		public void GivenISetAllTheMetalPresenceValueTo(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I set all the metal presence values to: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForMetalSection(30), "Metal section has failed to load.",
					"Metal section has loaded");
				List<string> metals = selNewProduct.GetAllMetalNames();
				List<MetalPresence> listOfMetalSettings = new List<MetalPresence>();
				foreach (string thisMetal in metals)
				{
					listOfMetalSettings.Add(new MetalPresence(thisMetal, "No"));
				}

				selNewProduct.MetalPresence = listOfMetalSettings;

				var checkOutcome = selNewProduct.MetalPresence;

				foreach (MetalPresence thisMetalPresence in listOfMetalSettings)
				{
					if (checkOutcome.Select(x => x.Metal == thisMetalPresence.Metal && x.Presence == thisMetalPresence.Presence).Count() == 0)
					{
						Report.Error("Failed to set metal: " + thisMetalPresence.Metal + " to: " + thisMetalPresence.Presence);
					}
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Toxicity Characteristics Leaching Procedure page for Product has had TCLP; Report is available I select: (No|Yes)")]
		public void GivenInTheToxicityCharacteristicsLeachingProcedurePageForProductHasHadTclpReportIsAvailableISelect(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Toxicity Characteristics Leaching Procedure page for Product has had TCLP; Report is available I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product Characteristics tab has not loaded",
					"Product Characteristics tab is loaded.");

				bool expected = (noOrYes == "Yes");
				selNewProduct.ProductHasTclp = expected;

				Report.IsTrue(selNewProduct.ProductHasTclp == expected,
					"Failed to set Product has had TCLP: " + noOrYes,
					"Successfully set Product has had TCLP: " + noOrYes);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Additional Information Page for Product is retailers private label or brand I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductIsRetailersPrivateLabelOrBrandISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page for Product is retailers private label or brand I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");

				bool expected = (noOrYes == "Yes");


				selNewProduct.RetailersPrivateLabelOrBrand = expected;

				Report.IsTrue(selNewProduct.RetailersPrivateLabelOrBrand == expected,
					"Failed to set Product is retailers private label or brand: " + noOrYes,
					"Successfully set Product is retailers private label or brand: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for Has a LCD or Plasma Display I select: (No|Yes)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForHasAlcdOrPlasmaDisplayISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page for Has a LCD or Plasma Display I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
					"Product characteristics tab is loaded.");

				bool expected = (noOrYes == "Yes");

				selNewProduct.HasLcdOrPlasmaDisplay = expected;

				Report.IsTrue(selNewProduct.HasLcdOrPlasmaDisplay == expected,
					"Failed to set Has a LCD or Plasma Display value to: " + noOrYes,
					"Successfully set Has a LCD or Plasma Display value to: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for Contains Circuit Board I select: (No|Yes)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForContainsCircuitBoardISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page for Contains Circuit Board I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
					"Product characteristics tab is loaded.");

				bool expected = (noOrYes == "Yes");

				selNewProduct.ContainsCircuitBoard = expected;

				Report.IsTrue(selNewProduct.ContainsCircuitBoard == expected,
					"Failed to set Contains Circuit Board value to: " + noOrYes,
					"Successfully set Contains Circuit Board value to: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForOSHACompliantSDSISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.OSHA = selection;

			Report.IsTrue(selNewProduct.OSHA.Contains(selection),
				"Failed to set OSHA value to: " + selection,
				"Successfully set OSHA value to: " + selection);
		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
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
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.AutoignitionTemperature = selection;

		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.MinimumIgnitionEnergy = selection;

		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Viscosity I enter: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
				"Review and submit tab is loaded.");

			selNewProduct.Viscosity = selection;

		}

		[StepDefinition(@"in the Review and Submit tab of the New Product Page for Appearance I select: (.*)")]
		public void GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(string selection)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
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
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
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
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
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
			Report.IsTrue(selNewProduct.WaitForTab("Review and Submit"), "Review and submit has not loaded",
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
			NewProduct selNewProduct = new NewProduct();
			selNewProduct.InternationalShippingDOTExemption = selection;
			Report.IsTrue(selNewProduct.InternationalShippingDOTExemption == selection, "Failed to select: " + selection,
				"Successfully selected: " + selection);
		}

		[StepDefinition(@"In the New Product page I click tab: (.*)")]
		public void GivenInTheNewProductPageIClickTab(string tab)
		{
			NewProduct selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.ClickTab(tab), "Failed to click tab: " + tab, "Successfully clicked tab: " + tab);
			Delay.Seconds(1);
		}

		[StepDefinition(@"in the New Product page I click section: (.*)")]
		public void GivenInTheNewProductPageIClickSection(string section)
		{
			TestReport.UseSubSteps = true;
			NewProduct selNewProduct = new NewProduct();
			TestReport.StartStep("I click section header " + section);
			Report.IsTrue(selNewProduct.ClickSection(section), "Failed to click section: " + section, "Successfully clicked section: " + section);
			GeneralUtilities.Wait_for_load_finish();
			TestReport.StartStep("I should see page has loaded: " + section);
			GivenIShouldSeeXPage(section);
		}

		[StepDefinition(@"I delete UPC: (.*)")]
		public void GivenIDeleteUPC(string upc)
		{
			NewProduct selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.DeleteUPC(upc), "Failed to delete UPC:" + upc, "Successfully deleted: " + upc);
		}

		[StepDefinition(@"In the list of UPCs I should not see UPC: (.*)")]
		public void ThenInTheListOfUPCsIShouldNotSeeUPCSavedAsUPC(string upc)
		{
			NewProduct selNewProduct = new NewProduct();
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
			NewProduct selNewProduct = new NewProduct();
			selNewProduct.OtherDOTException = selection;
			Report.IsTrue(selNewProduct.OtherDOTException == selection, "Failed to select: " + selection,
				"Successfully selected: " + selection);
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page, I enter: (.*) in the Provide Special Permit numbers text field")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageIEnterInTheProvideSpecialPermitNumbersTextField(string permitNumber)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Characteristics tab, I enter: " + permitNumber + " in the Specific Gravity text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.SpecialPermitNumbers = permitNumber;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"in the Product Characteristics tab of the New Product Page for Prop65 I select: (No|Yes)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForPropISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page for Prop65 I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
					"Product characteristics tab is loaded.");

				bool expected = (noOrYes == "Yes");


				selNewProduct.Prop65 = expected;

				Report.IsTrue(selNewProduct.Prop65 == expected,
					"Failed to set Prop 65 value to: " + noOrYes,
					"Successfully set Prop 65 value to: " + noOrYes);


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
			NewProduct selNewProduct = new NewProduct();

			List<string> itemsToSelect = selections.Split(',').ToList().Select(x => x.Trim()).ToList();
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
		/// Confirm the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC-OTC-CARB statement1: (.*)")]
		public void GivenIConfirmThatISeeTheFollowingVOC_OTC_CARBStatement1(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetProductGrantedAlternativeControlPlanStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"Product has been granted an Alternative Control Plan statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"Product has been granted an Alternative Control Plan statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1 statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC-OTC-CARB statement2: (.*)")]
		public void GivenIConfirmThatISeeTheFollowingVOC_OTC_CARBStatement2(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetProductDoesNotContainGramsOfVocStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"Product has been granted an Alternative Control Plan statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"Product has been granted an Alternative Control Plan statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm VOC content in grams ozone per gram statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC-OTC-CARB statement3: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOC_OTC_CARBStatement3(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetVocContentInGramsStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm Based on your selection, you have verified your product contains VOC with intended uses as follows. The Aerosol Coatings by the CARB VOC compliance limit(s) for the intended use you identified is/are: statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC-OTC-CARB statement4: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOC_OTC_CARBStatement4(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetCarbVocComplianceLimitStatement();
			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm VOC Analysis Date (Today's Date)
		/// </summary>
		[StepDefinition(@"I confirm that I see todays VOC Analysis Date")]
		public void ThenIConfirmThatISeeTodaysVOCAnalysisDate()
		{
			var date = DateTime.Now.ToString("MM/dd/yyyy");
			var newProductpage = new NewProduct();
			var found = newProductpage.GetValueVOCSummary("VOC Analysis");

			Report.IsTrue(found.Trim() == date.Trim(),
				"date was not as expected! Expected: " + date + ", but found: " + found + "!",
				"statement was showing: " + date + ", as expected!");
		}

		[StepDefinition(@"I confirm that the VOC Analysis Date statement is showing")]
		public void ThenIConfirmThatTheVOCAnalysisDateIsShowing()
		{
			var vocDateStatement = new NewProduct().VocAnalysisDateStatement();
			Report.IsFalse(vocDateStatement == null, "The VOC Analysis Date Statement was not showing", "The VOC Analysis Date Statement was showing as expected: " + vocDateStatement);
		}

		/// <summary>
		/// Confirm error message for VOC content in grams ozone per gram statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following error message for VOC content in grams ozone per gram: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingErrorMessageForVOCContentInGramsOzonePerGram(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetErrorMessageForVocContentInGrams();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		//JS - consolidated HVOC, CARB etc value steps into one because they were calling identical code
		[StepDefinition(@"I confirm that I see the following (CARB|MVOC|HVOC|VOC Grams Ozone|OTC Model Rule) value: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingCARBValue(string category, string expectedValue)
		{
			var newProductpage = new NewProduct();
			var foundValue = newProductpage.GetValueVOCSummary(category);
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
			var found = newProductpage.GetVocSummaryStatementText(category);
			Report.IsTrue(found.Trim() == value.Trim(),
				"Statement was not as expected! Expected: " + value + ", but found: " + found + "!",
				"Statement was showing: " + value + ", as expected!");
		}

		/// <summary>
		/// select option for Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		/// </summary>
		[StepDefinition(@"In the VOC - OTC - CARB tab for Product has been granted an Alternative Control Plan I select: (No|Yes)")]
		public void GivenInTheVOC_OTC_CARBTabForProductHasBeenGrantedAnAlternativeControlPlanISelect(string noOrYes)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
				"Product type tab is loaded.");

			bool expected = (noOrYes == "Yes");

			selNewProduct.AlternateControlPlan = expected;

			Report.IsTrue(selNewProduct.AlternateControlPlan == expected,
				"Failed to set Product has been granted an Alternative Control Plan to: " + noOrYes,
				"Successfully set Product has been granted an Alternative Control Plan to: " + noOrYes);
		}

		[StepDefinition(@"In the Product Characteristics tab of the New Product Page, for Product does not contain more than grams of VOC per use I select: (.*)")]
		public void ThenInTheProductCharacteristicsTabOfTheNewProductPageForProductDoesNotContainMoreThanGramsOfVOCPerUseISelect(string option)
		{

			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");


			selNewProduct.ProductDoesNotContainGramsOfVoc = option;

			Report.IsTrue(selNewProduct.ProductDoesNotContainGramsOfVoc == option,
				"Failed to set status: " + option,
				"Successfully set status: " + option);
		}

		/// <summary>
		/// Enter in VOC content in grams ozone per gram text field
		/// </summary>
		[Then(@"In the product Characteristics tab, I enter: (.*) in the VOC content in grams ozone per gram text field")]
		public void ThenInTheProductCharacteristicsTabIEnterInTheVOCContentInGramsOzonePerGramTextField(string option)
		{
			Report.IsTrue(new NewProduct().VocContentInGrams(option), "Text: " + option + " was not successfully inputted into the comments field!", "Text: " + option + " was successfully inputted into the comments field!");
		}

		/// <summary>
		/// select option for Product label specifies a dilution ratio
		/// </summary>
		[StepDefinition(@"In the VOC - OTC - CARB tab for Product label specifies a dilution ratio I select: (No|Yes)")]
		public void GivenInTheVOC_OTC_CARBTabForProductLabelSpecifiesADilutionRatioISelectYes(string noOrYes)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
				"Product type tab is loaded.");

			bool expected = (noOrYes == "Yes");

			selNewProduct.ProductLabelDilutionRatio = expected;

			Report.IsTrue(selNewProduct.ProductShippedDirectly == expected,
				"Failed to set Product label specifies a dilution ratio to: " + noOrYes,
				"Successfully set Product label specifies a dilution ratio to: " + noOrYes);
		}

		/// <summary>
		/// Enter data in Product's VOC content as sold text box
		/// </summary>
		[StepDefinition(@"In the VOC - OTC - CARB tab, I enter: (.*) in the Product's VOC content as sold text field")]
		public void GivenInTheVOC_OTC_CARBTabIEnterInTheProductSVOCContentAsSoldTextField(string contentAsSold)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
				"Product type tab is loaded.");
			selNewProduct.ProductsVocContentAsSold = contentAsSold;
		}

		/// <summary>
		/// Enter data in Product's VOC content as used text box
		/// </summary>
		[StepDefinition(@"In the VOC - OTC - CARB tab, I enter: (.*) in the Product's VOC content as used text field")]
		public void GivenInTheVOC_OTC_CARBTabIEnterInTheProductSVOCContentAsUsedTextField(string contentAsUsed)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
				"Product type tab is loaded.");
			selNewProduct.ProductsVocContentAsUsed = contentAsUsed;
		}

		[StepDefinition(@"In the Additional Information Page for Product is shipped directly I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductIsShippedDirectlyISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page for Product is shipped directly I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");

				bool expected = (noOrYes == "Yes");


				selNewProduct.ProductShippedDirectly = expected;

				Report.IsTrue(selNewProduct.ProductShippedDirectly == expected,
					"Failed to set product shipped directly value to: " + noOrYes,
					"Successfully set product shipped directly value to: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Additional Information Page for Product has been classified using OSHA I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductHasBeenClassifiedOSHAISelectNoOrYes(string noOrYes)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Type"),
				"Product type has not loaded",
				"Product type tab is loaded.");

			bool expected = (noOrYes == "Yes");

			selNewProduct.ProductClassifiedUnderOSHA = expected;

			Report.IsTrue(selNewProduct.ProductClassifiedUnderOSHA == expected,
				"Failed to set product has been classified using OSHA value to: " + noOrYes,
				"Successfully set product has been classified using OSHA value to: " + noOrYes);
		}

		[StepDefinition(@"In the Additional Information Page the check box for: (.*) should be: (checked|unchecked)")]
		public void GivenInTheAdditionalInformationPageTheCheckBoxXShouldBeCheckedOrUnchecked(string country, string checkedOrUnchecked)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page the check box for: " + country + " should be: " + checkedOrUnchecked);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				List<string> countries = new List<string>() { country };

				bool expected = (checkedOrUnchecked == "checked");

				if (expected)
				{
					Report.IsTrue(selNewProduct.ProductsMayBeSold.Contains(country),
						"Products may be sold is not set up as expected", "Products may be sold is set up as expected.");
				}
				else
				{
					Report.IsTrue(!selNewProduct.ProductsMayBeSold.Contains(country),
						"Products may be sold is not set up as expected", "Products may be sold is set up as expected.");
				}


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Product Type tab of the New Product Page, I enter: (.*) in the Type of Product select field")]
		public void GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField(string typeOfProduct)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded", "Product type tab is loaded.");
			selNewProduct.ProductType = typeOfProduct;
			//If Type of Product hasn't updated, try again ignoring case
			//CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
		}

		[StepDefinition(@"I should only see the following options for Primary Physical State:")]
		public void PrimaryPhysicalOptionsShowingCorrectly(Table table)
		{
			var expected = new List<string>();
			table.Rows.ForEach(x => expected.Add(x["State"]));
			var found = new NewProduct().ListOfPrimaryPhysicalStates();
			Report.Info("Primary Physical States found: " + string.Join(", ", found));
			foreach (var state in expected)
			{
				if (Report.IsTrue(found.Contains(state), "Failed to find state: " + state + " in the list!", state + " was successfully found!"))
				{
					found.Remove(state);
				}
			}
			Report.IsTrue(found.Count == 0,
				$@"There were physical states displayed which were not expected! Only expected: ""{string.Join(", ", expected.Select(x => $"'{x}'").ToList())}"". Also displaued were: ""{string.Join(", ", found.Select(x => $"'{x}'").ToList())}""" + string.Join(", ", found),
				$@"Only the expected physical states: ""{string.Join(", ", expected.Select(x => $"'{x}'").ToList())}"" were displayed.");
		}

		[StepDefinition(@"I set the Primary Physical State to be: (.*)")]
		public void ThenISetThePrimayPhysicalStateToBe(string state)
		{
			Report.IsTrue(new NewProduct().SelectPrimaryPhysicalState(state), "Failed to set the primary physical state to be: " + state, "Successfully set the Primary Physical State to be: " + state);
		}

		[StepDefinition(@"I set the Secondary Physical State to be: (.*)")]
		public void ThenISetTheSecondaryPhysicalStateToBe(string state)
		{
			Report.IsTrue(new NewProduct().SelectSecondaryPhysicalState(state), "Failed to set the secondary physical state to be: " + state, "Successfully set the Secondary Physical State to be: " + state);
		}

		[StepDefinition(@"I set the water solubility description to: (.*)")]
		public void ThenISetTheWaterSolubilityDescriptionTo(string description)
		{
			NewProduct thisNewProduct = new NewProduct();
			new NewProduct().WaterSolubility = description;
			Report.IsTrue(thisNewProduct.WaterSolubility == description, "Failed to set the water solubility description to be: " + description, "Successfully set the water solubility description to be: " + description);
		}

		/// <summary>
		/// Enter data in Specific Gravity text field
		/// </summary>
		[StepDefinition(@"In the Product Characteristics tab, I enter: (.*) in the Specific Gravity text field")]
		public void GivenInTheProductCharacteristicsTabIEnterInTheSpecificGravityTextField(string specificGravity)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Characteristics tab, I enter: " + specificGravity + " in the Specific Gravity text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.SpecificGravity = specificGravity;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Enter data in pH text field
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I enter: (.*) in the pH text field")]
		public void GivenInTheProductCharacteristicsTabIEnterInThePHTextField(string pH)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Characteristics tab, I enter: " + pH + " in the Specific Gravity text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.PH = pH;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Enter data in Boiling Point (in Celsius) text field
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I enter: (.*) in the Boiling point \(in Celsius\) text field")]
		public void GivenInTheProductCharacteristicsTabIEnterInTheBoilingPointInCelsiusTextField(string boilingPointInCelsius)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Characteristics tab, I enter: " + boilingPointInCelsius + " in the Specific Gravity text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.BoilingPoint = boilingPointInCelsius;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Enter data in Flash point text field
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I enter: (.*) in the Flash point \(in Celsius\) text field")]
		public void GivenInTheProductCharacteristicsTabIEnterInTheFlashPointInCelsiusTextField(string flashPointInCelsius)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Characteristics tab, I enter: " + flashPointInCelsius + " in the Specific Gravity text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.FlashPoint = flashPointInCelsius;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Select an option from Flash Point Testing Method Used
		/// </summary>
		[StepDefinition(@"in the Product Characteristics tab, for Flash Point Testing Method Used status I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabForFlashPointTestingMethodUsedStatusISelect(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab, for Flash Point Testing Method Used status I select: " + option);
			try
			{
				var selNewProduct = new NewProduct();
				//Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				//	"Product characteristics tab is loaded.");


				selNewProduct.FlashPointTestingMethodUsed = option;

				Report.IsTrue(selNewProduct.FlashPointTestingMethodUsed == option,
					"Failed to set Flash point testing method used status: " + option,
					"Successfully set Flash point testing method used status: " + option);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Select an option for the best Water Solubility description dropdown
		/// </summary>
		[StepDefinition(@"I set the Select the best Water Solubility description to be: (.*)")]
		public void GivenISetTheSelectTheBestWaterSolubilityDescriptionToBe(string option)
		{
			Report.IsTrue(new NewProduct().SelectBestWaterSolubilityDescription(option), "Failed to set the best Water Solubility description to be: " + option, "Successfully set the best Water Solubility description to be: " + option);
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

			var newProductpage = new NewProduct();
			var found = newProductpage.GetEcologoStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"ecologo statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"ecologo statement was showing: " + statement + ", as expected!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the radio button " + button);
			try
			{
				Report.Info("Checking that I see the radio button '" + button + "'");
				var selNewProduct = new NewProduct();
				var radioButtonsShowing = selNewProduct.RadioButtons();
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
			var radioButtonsShowing = selNewProduct.RadioButtons();
			foreach (var row in expected.Rows)
			{
				var button = row["Button"];
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
			var checkboxShowing = selNewProduct.Checkboxes();
			foreach (var row in expected.Rows)
			{
				var button = row["Checkbox"];
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
			var expectedCount = Convert.ToInt32(count);
			var actualCount = selNewProduct.RadioButtonCountInSection(section);
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

		[StepDefinition(@"The following radio buttons should be displayed for section: (.*)")]
		public void CheckRadioButtonsInSectionAndOrder(string section, Table expected)
		{
			var expectedRadioButtons = new List<string>();
			expected.Rows.ForEach(x => expectedRadioButtons.Add(x["Button"]));
			var radioButtonsShowing = new NewProduct().RadioButtonsInSection(section);
			Report.IsTrue(expectedRadioButtons.All(x => radioButtonsShowing.Contains(x)),
				"The actual radio buttons for section: " + section + " were no as expected. Actual radios: " + string.Join(", ", radioButtonsShowing) + ". Expected: " + string.Join(", ", expectedRadioButtons),
				"The actual radio buttons for section: " + section + " were as expected: " + string.Join(", ", radioButtonsShowing));
		}

		[StepDefinition(@"I click the 'Add UPC' button")]
		public void ThenIClickTheAddUpcButton()
		{
			Report.IsTrue((new NewProduct()).ClickAddUpcButton(), "Failed to click the 'Add UPC' button!", "Successfully clicked the 'Add UPC' button");
		}

		[StepDefinition(@"I add the following into the UPC Fields")]
		public void ThenIAddTheFollowingIntoTheUpcFields(Table table)
		{
			var upcInfo = table.CreateInstance<UpcInformation>();
			Report.Info("UPC Number: " + upcInfo.UpcNumber);
			Report.Info("Container Type: " + upcInfo.ContainerType);
			Report.Info("Size: " + upcInfo.Size);
			Report.Info("DPCI: " + upcInfo.Dpci);
			Report.Info("Quantity: " + upcInfo.Quantity);

			Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");
		}

		[StepDefinition(@"the comments field should appear")]
		public void ThenTheCommentsFieldShouldAppear()
		{
			Report.IsTrue(new NewProduct().CommentsAreaShowing(), "Comments field was not displayed!", "Comments field was displayed, as expected");
		}

		[StepDefinition(@"I enter the following into the comments field: (.*)")]
		public void ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(string text)
		{
			Report.IsTrue(new NewProduct().InputCommentAreaText(text), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		[StepDefinition(@"The Data Acceptance page should appear")]
		public void ThenTheDataAcceptancePageShouldApprear()
		{
			Report.IsTrue(new NewProduct().DataAcceptanceScreenAppears(), "Data Acceptance page did not appear!", "As expected, Data Acceptance page loaded successfully!");
		}

		[StepDefinition(@"I confirm an error message is displayed with text: (.*)")]
		public void ThenIConfirmErrorMessageMatches(string errorMsg)
		{
			var erros = new NewProduct().AllErrorMessages();
			Report.IsTrue(erros.Contains(errorMsg), $"The error message {errorMsg} was not displayed!", $"The error message {errorMsg} was displayed as expected");
		}

		[StepDefinition(@"In the Data Acceptance page I select Yes, Agreed")]
		public void GivenInTheDataAcceptancePageISelectYesAgreed()
		{
			NewProduct thisNewProduct = new NewProduct();
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
			Report.IsTrue(new NewProduct().ClickAcceptButton(), "Failed to click accept button", "Clicked accept button", true);
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

		[StepDefinition(@"I set the (.*) field to: (.*)")]
		[StepDefinition(@"I set the (.*) option to: (.*)")]
		public void SetTheSectionOptionTo(string section, string option)
		{
			NewProduct thisNewProduct = new NewProduct();
			if (!thisNewProduct.Wait_for_load(3))
			{
				Report.Failure("The new product page is not showing");
			}
			Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
				"Failed to set the input to " + option.Trim() + " in section: " + section.Trim(),
				"Successfully set the input to " + option.Trim() + " in section: " + section.Trim());
			Delay.Seconds(1);
		}

		// JS a solution specifically for Transportation page where you have nested checkbox sections eg. DOT, IATA
		[StepDefinition(@"I select option: (.*) under section: (.*) and subsection: (.*)")]
		public void SetTheOptionSubOptionTo(string option, string section, string subSection)
		{
			Report.IsTrue(new NewProduct().SetOptionInSectionSubSection(section.Trim(), subSection.Trim(), option.Trim()),
				$"Failed to set the input to: '{option}' in section: '{section}' and subection: '{subSection}'",
				$"Successfully set the input to: '{option}' in section: '{section}' and subection: '{subSection}'");
		}

		[StepDefinition(@"I (see|only see|do not see) the following sections")]
		public void CheckDisplayedSections(string condition, Table sections)
		{
			Report.Info("Beginning I " + condition + " the following sections");
			var expectedSections = new List<string>();
			foreach (var Row in sections.Rows)
			{
				expectedSections.Add(Row["Section"]);
			}
			var expectedNormalised = expectedSections.Select(x => x.Replace(" ", "")).ToList();
			var ActualSections = new NewProduct().GetDisplayedSections().Select(x => x).ToList();
			var actualNormalised = ActualSections.Select(x => x.Replace(" ", "")).ToList();
			Report.Info("Actual sections: " + string.Join(",", ActualSections));
			if (condition == "only see")
			{
				List<string> mismatch = new List<string>();
				foreach (var section in ActualSections)
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
			var index = position.All(char.IsDigit) ? int.Parse(position) - 1 : -1;
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
			NewProduct myProduct = new NewProduct();
			var options = myProduct.GetAllOptionsForSection(section);
			Report.IsTrue(myProduct.SetOptionInSection(section, options[0]), "The option: " + options[0] + " could not be selected in section: " + section, "The option: " + options[0] + " was selected in section: " + section);
		}

		[StepDefinition(@"If Section: (.*) is visible, I select the first option")]
		public void IfSectionIsVisibleISelectTheOption(string section, string option)
		{
			NewProduct myProduct = new NewProduct();
			if (myProduct.GetDisplayedSections().Contains(section))
			{
				Report.Info("Selecting the first option for section: " + section);
				//var options = myProduct.GetDropDownOptionsForSection(section);
				Report.IsTrue(myProduct.SetOptionInSection(section, option), "The option: " + option + " could not be selected in section: " + section, "The option: " + option + " was selected in section: " + section);
			}
			else
			{
				Report.Info("The section: " + section + " was not showing so no option was selected");
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

		[StepDefinition(@"I set the below options for field: (.*)")]
		public void CheckAvailableOptionsInSection(string section, Table options)
		{
			foreach (var row in options.Rows)
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
			var errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			var errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.Info("Error messages showing are: " + string.Join(", ", errorMessages));
			if (should == "should")
			{
				foreach (var item in errorMessagesExpected)
				{
					Report.IsTrue(errorMessages.Any(e => e.Contains(item)),
						"Failed to find the error message: " + item + " under section: " + section + "!",
						"Successfully found the error message: " + item + " for section: " + section, false, false);
				}
			}
			if (should == "should not")
			{
				foreach (var item in errorMessagesExpected)
				{
					Report.IsFalse(errorMessages.Contains(item.Trim()),
						"The error message: " + item + " was displayed under section" + section + " when it should not be.",
						"The error message: " + item + " was not displayed under section: " + section + " as expected", false, false);
				}
			}
			Report.Screenshot();
		}

		// NB: Multiple values should be delimited by the '|' character!
		[StepDefinition(@"(.*) should be showing the value: (.*)")]
		public void CheckingFieldInputIsCorrect(string section, string value)
		{
			if (value.StartsWith("~saved as"))
			{
				var savedAs = value.Replace("~saved as", "").Trim();
				value = Context.GetFromContext(savedAs)?.ToString();
				if (value == null)
				{
					throw new Exception("Could not find item in context: " + savedAs + " for checking field input is correct value!");
				}
			}
			var showing = new NewProduct().SelectedOptionsForSection(section);
			Report.Info("Value(s) showing were: " + string.Join(", ", showing));
			var expected = value.Split('|').Select(x => x.Trim()).ToList();
			foreach (var expec in expected)
			{
				Report.IsTrue(showing.Contains(expec), "Failed to find the selected value: " + expec + " in the section: " + section + "!", string.Format("Successfully found {0} in section: {1}", expec, section), false, false);
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm that: (.*) is not the only option for section: (.*)")]
		public void ConfirmThatIsNotTheOnlyOptionForSection(string option, string section)
		{
			var selNewProduct = new NewProduct();
			var options = selNewProduct.GetAllOptionsForSection(section);
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
			var displayed = selNewProduct.GetDisplayedVocLimits();
			var expectedRegulation = "";
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
			var expected = information.CreateSet<VocLimits>();
			var voclimits = new NewProduct();
			var displayed = voclimits.GetDisplayedVocLimits();
			foreach (var expectedinfo in expected)
			{
				Report.Info("Checking use: " + expectedinfo.Use + " and Voc Compliance Limit: " + expectedinfo.VocComplianceLimit + " and Regulation: " + expectedinfo.Regulation);
				var matchingType = displayed.Where(x => x.Use == expectedinfo.Use);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No Use data displayed: " + expectedinfo.Use + " were displayed!");
					continue;
				}

				bool passed = false;
				foreach (var matched in matchingType)
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
			var expected = information.CreateSet<VocLimitsWithUnits>();
			var voclimits = new NewProduct();
			var displayed = voclimits.GetDisplayedVocLimitsWithUnits();
			foreach (var expectedinfo in expected)
			{
				Report.Info("Checking use: " + expectedinfo.Use + " and Voc Compliance Limit: " + expectedinfo.VocComplianceLimit + " and Units: " + expectedinfo.Units + " and Regulation: " + expectedinfo.Regulation);
				var matchingType = displayed.Where(x => x.Use == expectedinfo.Use);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No Use data displayed: " + expectedinfo.Use + " were displayed!");
					continue;
				}

				bool passed = false;
				foreach (var matched in matchingType)
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
			var expected = information.CreateSet<VocPercentForStates>();
			var voclimits = new NewProduct();
			var displayed = voclimits.GetDisplayedVocPercentForEachState();
			foreach (var expectedinfo in expected)
			{
				Report.Info("Checking State: " + expectedinfo.State + " and Regulation: " + expectedinfo.Regulation + " and VOC value: " + expectedinfo.VocValue + " and State VOC Threshold: " + expectedinfo.StateVocThreshold + " and Message: " + expectedinfo.Message);
				var matchingType = displayed.Where(x => x.State == expectedinfo.State);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No State data displayed: " + expectedinfo.State + " were displayed!");
					continue;
				}
				bool passed = false;
				foreach (var matched in matchingType)
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

		[StepDefinition(@"I should see data for States in the 'VOC Content as weight percentage of total formula' table")]
		public void DataForStatesInVOCContentAsWeightPercentageTable()
		{
			var selNewProduct = new NewProduct();
			var displayed = selNewProduct.GetDisplayedVocPercentForEachState();
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
			var found = newProductpage.GetAmountOfVocByOTCRuleNotStatement();

			Report.IsTrue(!found, "statement was displayed", "statement was not displayed", false);
		}

		/// <summary>
		/// Confirm the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Content as defined by OTC Model Rule statement: (.*)")]
		public void ThenIconfirmThatISeeTheFollowingVOCContentAsDefinedByOTCModelRuleStatement(string statement)
		{

			var newProductpage = new NewProduct();
			var found = newProductpage.GetAmountOfVocByOTCRuleStatement();

			Report.IsTrue(found.Equals(statement), "statement was not displayed", "statement was displayed");
		}

		/// <summary>
		/// Confirm Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Content as defined by CARB statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCContentAsDefinedByCARBStatement(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetAmountOfVocDefinedByCARBStatement();

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
			var found = newProductpage.GetVOCContentBelowThresholdOfCARBStatement();

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
			var found = newProductpage.GetVOCContentBelowThresholdOfOTCStatement();

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
			var found = newProductpage.GetUseVocPercentageAllAreaStatement();

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
			var found = newProductpage.VocWeightPercentageForEachStateStatement();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		[StepDefinition(@"I confirm the Label Information section on the Regulatory Information 3 page contains a link for: (.*)")]
		public void IConfirmLabelInformationOnRegulatoryInformationPageContains(string labelLink)
		{
			var newProductPage = new NewProduct();
			var labelLinksShowing = newProductPage.RegulatoryInformationLabelLinks();
			Report.IsTrue(labelLinksShowing.Contains(labelLink), "The link with text: '" + labelLink + "' was not found on the Regulatory Information 3 page", "The link with text: '" + labelLink + "' was found on the Regulatory Information 3 page as expected");
		}

		[StepDefinition(@"I confirm 'Quantity' is visible in the UPC header")]
		public void ConfirmQuantityIsVisibleInUPCHeader()
		{
			Report.IsTrue(new NewProduct().GetUPCHeaders().Contains("Quantity"), "The text 'Quantity' did not appear in the UPC header on the Universal Product Code page", "The text 'Quantity' appeared in the UPC header on the Universal Product Code page as expected");
		}

		[StepDefinition(@"The VOC intended use text is shown: (.*)")]
		public void VOCIntendedUseTextMatches(string text)
		{
			var displayedStatements = new NewProduct().AllAdditionalStatements();
			Report.IsTrue(displayedStatements.Contains(text), "The VOC Intended Use text was not as expected: '" + text + "'", "The VOC Intended Use text matched as expected: '" + text + "'");
		}

		[StepDefinition(@"in the VOC Limits table, the (Use|VOC Compliance Limit|Regulation) column should contain the value: (.*)")]
		public void VOCLimitsTableContainsUse(string column, string valueExpected)
		{
			var displayed = new NewProduct().GetDisplayedVocLimitsWithUnits();
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
			var vocContentValue = new NewProduct().VOCContentInGPerL();
			Report.IsTrue(vocContentValue.Trim() == value, "The value for VOC content in g/L was not as expected. The value showing is: " + vocContentValue + " The expected value was: " + value, "The VOC content in g/L value was as expected: " + value);
		}

		[StepDefinition(@"The VOC Summary page contains the statement with the text: (.*)")]
		public void VOCSummaryContainsStatement(string value)
		{
			var statements = new NewProduct().AllAdditionalStatements();
			Report.IsTrue(statements.Contains(value), "The statement with text: " + value + " was not showing on the VOC Summary page", "The statement with text: " + value + " was showing on the VOC summary page as expected.");
		}

		public void SelectTCLPElementOptionsToNo(List<string> elements)
		{
			var newProduct = new NewProduct();
			foreach (var section in elements)
			{
				TestReport.StartStep("I set the " + elements + " option to: No");
				Report.IsTrue(newProduct.SetOptionInSection(section, "No"),
					"Failed to set the input to 'No' in section: '" + section + "'",
					"Successfully set the input to 'No' in section: '" + section + "'");
			}
		}

		// Replace with 'ISeeXPage' if there is a problem with a required field missing from the test step
		[StepDefinition("I check the new page has loaded with no required field error. Navigating from: (.*) to: (.*)")]
		public void NewPageLoadedNoRequiredFieldError(string oldPage, string newPage)
		{
			var myNewProduct = new NewProduct();
			int wait = 0;
			while (wait < 5)
			{
				// If the new page has loaded we are happy to return
				if (myNewProduct.WaitForSection(newPage, 1))
				{
					Report.Success("The page: '" + newPage + "' has loaded");
					Report.Screenshot();
					return;
				}
				if (myNewProduct.ErrorMessage() == "This is a required field." && myNewProduct.WaitForSection(oldPage, 1))
				{
					var section = myNewProduct.SectionWithRequiredFieldError();
					Report.Failure("The 'Required Field' error was showing for question: " + section + ". Selecting the first option. Check the test case is complete and correct.");
					var options = myNewProduct.GetAllOptionsForSection(section);
					if (options.Contains("Yes") && options.Contains("No"))
					{
						myNewProduct.SetOptionInSection(section, "No");
					}
					else
					{
						SelectFirstOptionInSection(section);
					}
					Report.Info("Clicking continue");
					ClickContinue();
					if (myNewProduct.WaitForSection(newPage))
					{
						Report.Info("The new page has loaded");
						Report.Screenshot();
						return;
					}
				}
				wait++;
			}
			Report.Failure("Did not see the Required field error message, but the new page was not loaded");
			Report.Screenshot();
		}

		//Checks a new page has loaded on Continue click. If not, look for 'this is a required field' error. If yes, throw excpt. The test is now out of sync, so further steps will only report junk.
		[StepDefinition(@"I continue to the next screen in the product registration")]
		public void ContinueInTheProductRegistration()
		{
			var selNewProduct = new NewProduct();
			Report.Info("Checking new product is loaded");
			Report.IsTrue(selNewProduct.Wait_for_load(10),
				"The New Product page is not currently loaded",
				"The New Product page is loaded");
			var currentPage = selNewProduct.ActivePanelHeading();
			Report.Info("Current expanded section is: " + currentPage);
			Report.Info("Clicking continue");
			Report.IsTrue(selNewProduct.ClickContinue(),
				"Failed to click the Continue button",
				"Successfully clicked the Continue button");
			Report.Info("Checking for 'required field' error and if new page hasn't loaded");
			int wait = 0;
			while (wait < 30)
			{
				if (selNewProduct.ActivePanelHeading() != currentPage)
				{
					Report.Success("New page was loaded");
					Report.Screenshot();
					Report.Info("Current page is: " + selNewProduct.ActivePanelHeading());
					return;
				}
				wait++;
				Delay.Seconds(1);
			}
			Report.Info("New page did not load. Checking for 'required field' error message.");
			if (selNewProduct.ErrorMessage() == "This is a required field.")
			{
				var section = selNewProduct.SectionWithRequiredFieldError();
				Report.Failure("The 'Required Field' error was showing for question: " + section + ". Selecting the first option. Check the test case is complete and correct.");
				Report.Screenshot();
				Report.Info("Selecting the first option for the required field");
				var option = selNewProduct.GetAllOptionsForSection(section).First();
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
			var actualMessages = new NewProduct().AllAdditionalStatements();
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
			var productLineOptions = new NewProduct().AllProductLineOrBrandOptions();
			Report.IsTrue(!productLineOptions.Select(x => x.Name).ToList().Except(activeBrands).Any() && productLineOptions.Count == activeBrands.Count,
				"The 'Product Line or Brand' drop down options were not limited exclusively to saved active brands. The options showing were: " + string.Join(", ", productLineOptions),
				"The 'Product Line or Brand' drop down options were limited exclusively to saved active brands as expected. The options showing were: " + string.Join(", ", productLineOptions));
		}

		[StepDefinition(@"In the Create the kit page I search for and select: (.*)")]
		public void GivenInTheCreateTheKitPageISearchForAndSelect(string productToAdd)
		{
			Report.IsTrue(new NewProduct().AddItemToKit(productToAdd),
				"Failed to add product: " + productToAdd + " to kit.",
				"Successfully added product: " + productToAdd + " to kit.");
		}

		[StepDefinition(@"In the Create the kit page I search for and select product saved as: (.*)")]
		public void GivenInTheCreateTheKitPageISearchForAndSelectSavedAs(ProductInformation product)
		{
			Report.IsTrue(new NewProduct().AddItemToKitByNameAndID(product),
				"Failed to add product: " + product.Id + " to kit.",
				"Successfully added product: " + product.Id + " to kit.");
		}

		[StepDefinition(@"in the (.*) page I (should|should not) see the (.*) question")]
		public void ThenInThePageIShouldOrShouldNotSeeQuestion(string page, string shouldOrNot, string question)
		{
			NewProduct thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForSection(page))
			{
				throw new Exception("Not on the right page");
			}

			Report.IsTrue(thisNewProduct.SectionExists(question) == (shouldOrNot == "should"),
				"Question is not showing as expected", "Question is showing or not as expected");
		}

		[Then(@"a (Danger & Warning|Warning) popup dialog should appear with the message: (.*)")]
		public void ThenAWarningPopupDialogShouldAppearWithTheMessage(string title, string message)
		{
			ModalDialog thisModalDialog = new ModalDialog();
			Report.IsTrue(thisModalDialog.GetTitle() == title, "Title is not showing as " + title,
				"Title is showing as" + title);
			Report.IsTrue(thisModalDialog.GetText() == message, "Expected message: " + message + " but got: " + thisModalDialog.GetText(),
				"Title is showing as expected: " + message);
			Report.Info("Clicking OK in the popup");
			thisModalDialog.Click_OK();
			Delay.Seconds(1);
		}

		[Then(@"I should see an alert with title: (.*) subtitle: (.*) Text: (.*)")]
		public void ThenIShouldSeeAnAlertWithTitleSubtitleText(string title, string subtitle, string text)
		{
			NewProduct thisNewProduct = new NewProduct();
			Alert thisAlert = thisNewProduct.GetAlert();
			Report.IsTrue(thisAlert.Title == title, "Title is not as expected", "Title matches");
			Report.IsTrue(thisAlert.SubTitle.Contains(subtitle), "SubTitle is not as expected. Expected " + subtitle + " but got: " + thisAlert.SubTitle, "SubTitle matches");
			Report.IsTrue(thisAlert.Text == text, "Text is not as expected. Expected " + text + " but got: " + thisAlert.Text, "Text matches");
		}

		[Then(@"on the Neonicotinoid Warning Page I should see a link with text: (.*) which links to page: (.*)")]
		public void ThenOnTheNeonicotinoidWarningPageIShouldSeeALinkWithTextWhichLinksToPage(string linkText, string link)
		{
			NewProduct thisNewProduct = new NewProduct();
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
			var showingIngredients = new MyIngredientsModal().MyIngredients();
			var matchID = showingIngredients.Where(x => x.Index == ingredient.Index);
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

		[Then(@"Field exists: (.*)")]
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
			var errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.IsTrue(errorMessages.Count == 0, "No error message should be showing for section: " + section + " but found: " + string.Join(", ", errorMessages),
				"As expected, no error messages were showing for section: " + section);
		}

		[Then(@"For every field in the table I should see the following error: (.*)")]
		public void ThenForEveryFieldInTheTableIShouldSeeTheFollowingError(string expectedError, Table table)
		{
			Delay.Seconds(3);
			foreach (TableRow thisRow in table.Rows)
			{
				ErrorMessagesAreShowingForItem(thisRow["Field"], "should", expectedError);
			}
		}

		[Then(@"For every field in the table I call Shared Step 56494 expecting error: (.*)")]
		public void ThenForEveryFieldInTheTableICallSharedStep56494ExpecingError(string error, Table table)
		{
			Steps_Shared thisStepShared = new Steps_Shared();
			foreach (TableRow thisRow in table.Rows)
			{
				NewProduct MyNewProduct = new NewProduct();
				MyNewProduct.MoveToLabel(thisRow["Field"]);
				thisStepShared.GivenICallSharedStep56494PesticideDetailsCanadaProvinceCodeconfirmationvalidationAndSelectionForProvince(thisRow["Field"], error);
			}
		}

		[StepDefinition(@"The following options (should|should not) be (displayed|displayed exclusively) for section: (.*)")]
		public void CheckOptionsInSection(string should, string exclusive, string section, Table expected)
		{
			var expectedOptions = new List<string>();
			var differences = new List<string>();
			expected.Rows.ForEach(x => expectedOptions.Add(x["Option"]));
			var expectedOptionsLower = expectedOptions.Select(x => x.ToLower()).ToList();
			var displayedOptions = new NewProduct().GetAllOptionsForSection(section);
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
				differences = expectedOptionsLower.Except(displayedOptionsLower).ToList();
				Report.IsTrue(differences.Count == 0,
					$"The actual options for section: {section} did not match the expected options. The differences were: {string.Join(", ", differences.Select(x => "'" + x + "'").ToList())}",
					$"The actual options for section: {section} matched the expected options: {string.Join(", ", expectedOptions)}");
			}
		}

		[StepDefinition(@"The Product Development Manager options should comprise a list containing the domain @CVSHealth.com")]
		public void PDMOptionsShouldContainCVSEmailDomain()
		{
			var displayedOptions = new NewProduct().GetAllOptionsForSection("Who is the Product Development Manager (PDM) for this product?");
			Report.IsTrue(displayedOptions.Where(x => x != "Choose...").ToList().All(x => x.ToLower().Contains("@cvshealth.com")),
				"Not all options in the PDM drop down contained the domain CVSHealth.com",
				"All options in the PDM drop down contained the domain CVSHealth.com as expected");
		}

		[Then(@"in the VOC Summary page I should see the following noneditable statements")]
		public void ThenInTheVOCSummaryPageIShouldSeeTheFollowingNoneditableStatements(Table table)
		{
			List<string> VOCSummaryStatements = new NewProduct().GetVOCSummaryStatements();
			List<string> expectedStatements = table.Rows.Select(x => x["Statement"]).ToList();
			foreach (string statement in expectedStatements)
			{
				Report.IsTrue(VOCSummaryStatements.Contains(statement), "Expected statement: " + statement,
					"Statement: " + statement + " showing as expected");
			}
		}

		[Then(@"For the Product's VOC content as sold field I should see the following error: (.*)")]
		public void ThenForTheProductSVOCContentAsSoldFieldIShouldSeeTheFollowingError(string error)
		{
			string actualError = new NewProduct().VOCContentsAsSoldError();
			if (actualError == null)
			{
				actualError = "null";
			}
			Report.IsTrue(actualError == error, "Error is not showing as expected. Expected: " + error + " but got: " + actualError,
				"Error is showing as expected");
		}

		[Then(@"For the Product's VOC content as used field I should see the following error: (.*)")]
		public void ThenForTheProductSVOCContentAsUsedFieldIShouldSeeTheFollowingError(string error)
		{
			string actualError = new NewProduct().VOCContentsAsUsedError();
			if (actualError == null)
			{
				actualError = "null";
			}
			Report.IsTrue(actualError == error, "Error is not showing as expected. Expected: " + error + " but got: " + actualError,
				"Error is showing as expected");
		}

		[Then(@"For the Product's VOC content as sold field I should see not see an error")]
		public void ThenForTheProductSVOCContentAsSoldFieldIShouldSeeNotSeeAnError()
		{
			Report.IsTrue(new NewProduct().VOCContentsAsSoldError() == null, "Expected no error but got: " + new NewProduct().VOCContentsAsSoldError(),
				"Error is showing as expected");
		}

		[Then(@"For the Product's VOC content as used field I should see not see an error")]
		public void ThenForTheProductSVOCContentAsUsedFieldIShouldSeeNotSeeAnError()
		{
			Report.IsTrue(new NewProduct().VOCContentsAsUsedError() == null, "Expected no error but got: " + new NewProduct().VOCContentsAsUsedError(),
				"Error is showing as expected");
		}

		[Then(@"the VOC concentration question shows a yes and a no button")]
		public void ThenTheVOCConcentrationQuestionShowsAYesAndANoButton()
		{
			Report.IsTrue(new NewProduct().VOCConcentrationQuestionHasYesAndNo(), "Expected VOC Concentration to have yes and no",
				"VOC concentration has yes and no");
		}

		[Then(@"For the VOC concentration question field I should see the following error: (.*)")]
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

		[Then(@"For the VOC page I should see the following error: (.*)")]
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

		[Given(@"I save the UPC number (.*) as: (.*)")]
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
			TestReport.UseSubSteps = true;
			var selNewProduct = new NewProduct();
			TestReport.StartStep("I confirm the CVS Logo is displayed in the page heading");
			Report.IsTrue(selNewProduct.SectionLogoDisplayed("cvs-pharmacy"),
				"The CVS logo was not displayed in the page header!",
				"The CVS logo was displayed in the page header");
			TestReport.StartStep("I confirm the title of the page heading is 'CVS Own Brand Registration'");
			Report.IsTrue(selNewProduct.WaitForSection("CVS Own Brand Registration"),
				"The page header was not 'CVS Own Brand Registration'!",
				"The page header was 'CVS Own Brand Registration' as expected");
		}

		[StepDefinition(@"The displayed message text is comprised of the following paragraphs")]
		public void MessageTextContainsParagraphs(Table paragraphText)
		{
			TestReport.UseSubSteps = true;
			var expectedParagraphs = new List<string>();
			paragraphText.Rows.ForEach(x => expectedParagraphs.Add(x["Paragraph"]));
			var actualParagraphs = new NewProduct().AllAdditionalStatementParagraphs();
			int count = 1;
			foreach (var para in actualParagraphs)
			{
				TestReport.StartStep("Checking paragraph: " + count + " matches expected text");
				Report.IsTrue(para.Trim() == expectedParagraphs[count - 1],
					"Paragraph " + count + " did not match the expected text: '" + para + "'",
					"Paragraph " + count + " matched the expected text: '" + para + "'");
				count++;
			}
		}
		[Then(@"The alert message is displayed with text: (.*)")]
		public void AlertMessageDisplayed(string alert)
		{
			List<string> actualAlerts = new NewProduct().DisplayedAlerts();
			if (actualAlerts == null)
			{
				Report.Failure("Could not locate any alert messages on the page");
				return;
			}
			Report.IsTrue(actualAlerts.Contains(alert),
				"Message is not displayed as expected. Expected: " + alert + " but got: " + string.Join(",", actualAlerts),
				"Message: '" + alert + "' is displayed as expected");
		}

		[Given(@"If purchase details are showing click confirm order")]
		public void GivenIfPurchaseDetailsAreShowingClickConfirmOrder()
		{
			// if subscription upgrade - Proceed ?
			Steps_PaymentMethods MyStepsPaymentMethods = new Steps_PaymentMethods();
			MyStepsPaymentMethods.ThenIConfirmThePurchaseSummaryHeaderIsDisplayed();
			GeneralUtilities.StudioWaitForSpinner();
			MyStepsPaymentMethods.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
		}

		[StepDefinition(@"the 'Regulatory List' window opens")]
		public void RegulatoryListWindowOpens()
		{
			var header = new RegulatoryList().Heading();
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
			var regulatoryListData = selRegulatoryList.GetRegulatoryListRows();
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
			var limits = selNewProduct.GetDisplayedVocLimits();
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
			var phrase = selNewProduct.GetVocSummaryStatementText(category);
			if (phrase == null)
			{
				Report.Failure("Unable to find statement phrase for: " + category + " on the VOC summary page");
				return;
			}
			Report.Info("The CARB exceeds phrase was showing: " + phrase);
			var valueNum = Convert.ToDouble(value);
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
			var toCheck = false;
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
			var isChecked = selNewProduct.StandaloneCheckbox(description).Checked();
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
			var colour = selNewProduct.SectionColour(section);
			// Not the best. Will break if the exact shade changes (hex #A9443F, rgb 169, 68, 66) and verified it is intended
			var expected = "(169, 68, 66, 1)";
			Report.IsTrue(colour.Contains(expected),
				$"Section '{section}' colour was not the expected red! The colour is: {colour}",
				$"Section '{section}' colour was red as expected");
		}

		[StepDefinition(@"I should see following statement: (.*)")]
		public void SectionStatement(string option)
		{
			Report.Info("Checking statement");
			var selNewProduct = new NewProduct();
			var found = selNewProduct.GetDisplayedSections();

			Report.IsTrue(found.Contains(option),
				"statement was not as expected! Expected: " + option + ", but found: " + found + "!",
				"statement was showing: " + option + ", as expected!");
		}

		[Given(@"I Check the check box for the TDS/BDS current version question")]
		public void GivenICheckTheCheckBoxForTheTDSBDSCurrentVersionQuestion()
		{
			var selNewProduct = new NewProduct();
		}

		[StepDefinition(@"I confirm the product name: ""(.*)"" is displayed in the header")]
		public void ConfirmTheProductNameIsDisplayedInTheHeader(string name)
		{
			var header = new NewProduct().GetHeader();
			var matches = Regex.Matches(header, @"\(\d*\)");
			if (matches.Count == 0)
			{
				Report.Failure("Could not find product ID in the New Product header!");
				Report.Screenshot();
				return;
			}
			var bracketedValue = matches[matches.Count - 1].Groups[0].Value;
			var headerName = header.TrimEnd(bracketedValue).Trim();
			Report.IsTrue(headerName == name,
				$@"The name displayed in the header did not match the expected value! Expected: ""{name}"" but got: ""{headerName}""",
				$@"The name displayed in the header matcehd the expected value: ""{name}""");
		}

		[StepDefinition(@"I confirm that retailer ""(.*)"" is present under the 'Destination Retailers' column in the UPC table")]
		public void ConfirmRetailerIsPresentUnderTheDestinationRetailersColumnUPCTable(string retailer)
		{
			var displayedRetailers = new NewProduct().GetAllUPCDestinationRetailers();
			Report.IsTrue(displayedRetailers.Contains(retailer),
				$@"Retailer ""{retailer}"" is not present under Destination Retailers! Retailers are: {string.Join(", ", displayedRetailers.Select(x => $"'{x}'").ToList())}",
				$@"Retailer ""{retailer}"" is present under Destination Retailers");
		}

		[StepDefinition(@"I click (Save|Cancel) in The Product Page")]
		public void ThenIClickSaveOrCancelInTheProductPage(string saveOrCancel)
		{
			NewProduct selNewProduct = new NewProduct();

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

		[Given(@"I Change the Secondary Physical State drop down from its current selection to a new selection")]
		public void GivenIChangeTheSecondaryPhysicalStateDropDownFromItsCurrentSelectionToANewSelection()
		{
			Report.Info("Changing secondary physical state");
			NewProduct thisNewProduct = new NewProduct();
			string currentlySelected = thisNewProduct.SelectedOptionsForSection("Secondary Physical State").FirstOrDefault();
			List<string> available = thisNewProduct.GetAllOptionsForSection("Secondary Physical State");

			var newOption = available.FirstOrDefault(x => x != currentlySelected);

			Report.IsTrue(thisNewProduct.SelectSecondaryPhysicalState(newOption), "Failed to select: " + newOption,
				"Selected: " + newOption);

		}

		[StepDefinition(@"I select the first option in the 'Product Line or Brand' drop down and save as Brand{TestCaseId}")]
		public void SelectFirstOptionInBrandDropDown()
		{
			var testCaseId = GlobalParameters.TestCaseId;
			if (testCaseId == null)
			{
				throw new Exception("Unable to locate a test case ID in global parameters which is required!");
			}
			Report.Info("Current test case ID: " + testCaseId);
			var newProduct = new NewProduct();
			var options = newProduct.AllProductLineOrBrandOptions();
			if (options.Count == 0)
			{
				// test can't continue
				throw new Exception("No Brands were available to add to the product, which is required by the test!");
				// instead.. go to create a new brand (My Account - My Library)
			}
			Report.Info($"There are {options.Count} brand options. Selecting the first one");
			var brand = options.First();
			Report.Info($"Selecting the brand: {brand.Name}");
			Report.IsTrue(newProduct.SetOptionInSectionByValue("Product Line or Brand (optional)", brand.ID, brand.Name),
				$"Failed to set the Product Line or Brand option to: {brand.Name} ({brand.ID})!",
				$"Successfully set the Product Line or Brand option to: {brand.Name} ({brand.ID})");
			Report.Info($@"Saving brand ""{brand.Name}"" to context as: Brand{testCaseId}");
			Context.AddToContext($"Brand{testCaseId}", brand);
			Context.AddToContext($"BrandName{testCaseId}", brand.Name);
		}

		[StepDefinition(@"Data Acceptance page should not show")]
		public void DataAcceptancePageShouldNotShow()
		{
			bool pageHasDisappeared = false;
			NewProduct thisNewProduct = new NewProduct();
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
			NewProduct thisNewProduct = new NewProduct();
			Report.IsTrue(thisNewProduct.EnterAdditionalRequirement(retailer, additionalRequirements),
				"Failed to enter additional requirements: " + additionalRequirements + " for retailer: " + retailer,
				"Added additional requirements for retailer: " + retailer);
		}

		[StepDefinition(@"I confirm that you cannot add a new component to the formulation")]
		public void ThenIConfirmThatYouCannotAddANewComponentToTheFormulation()
		{
			NewProduct thisNewProduct = new NewProduct();
			TechTalk.SpecFlow.Table component = new TechTalk.SpecFlow.Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"});
			component.AddRow(new string[] {
				"RR-38669-6",
				"FLAVORS",
				"35",
				"Yes",
				"Undisclosed Ingredient"});
			var newProductIngredients = new Ingredients();

			string CASNo = "";
			if (component.Rows.First()["CASNumber"].Contains("WPS"))
			{
				string casSavedAs = "";
				if (Context.Contains(component.Rows.First()["CASNumber"].Split(' ')[2].Trim()))
				{
					ProductInformation CASProd =
						(ProductInformation)Context.GetFromContext(component.Rows.First()["CASNumber"].Split(' ')[2]
							.Trim());
					CASNo = "WPS" + CASProd.Id;
				}
			}
			else
			{
				CASNo = component.Rows.First()["CASNumber"];
			}
			var ingredient = new Ingredients.Ingredient();
			if (CASNo.Length > 0)
			{
				ingredient.CASNumber = CASNo;
			}
			if (component.ContainsColumn("ComponentName"))
			{
				ingredient.ComponentName = component.Rows.First()["ComponentName"];
			}
			if (component.ContainsColumn("Percentage"))
			{
				ingredient.Percent = component.Rows.First()["Percentage"];
			}
			if (component.ContainsColumn("Publicly Disclosed"))
			{
				ingredient.PublicallyDisclosed = component.Rows.First()["Publicly Disclosed"].ToLower() == "yes";
			}
			if (component.ContainsColumn("Public Name"))
			{
				ingredient.PublicName = component.Rows.First()["Public Name"];
			}
			Report.IsTrue(!newProductIngredients.AddIngredient(ingredient),
				"Successfully added ingredient",
				"As expected could not add ingredient");
		}

		[StepDefinition(@"I confirm that you cannot edit the Percentage value for any component shown")]
		public void ThenIConfirmThatYouCannotEditThePercentageValueForAnyComponentShown()
		{
			Report.IsTrue(!(new Ingredients().ConcentrationsAreEditable()),
				"Concentrations should not be editable but are", "As expected, concentrations are not editable");
		}

		[StepDefinition(@"I confirm that you cannot edit the Is this a trade secret entry for any component shown")]
		public void ThenIVonfirmThatYouCannotEditTheIsThisATradeSecretEntryForAnyComponentShown()
		{
			Report.IsTrue(!(new Ingredients().TradeSecretsAreEditable()),
				"Is this a Trade secret should not be editable but is", "As expected, is this a trade secret is not editable");
		}

		[StepDefinition(@"I confirm that you can edit the Publicly Disclosed entry for any component shown")]
		public void ThenIConfirmThatYouCanEditThePubliclyDisclosedEntryForAnyComponentShown()
		{
			Report.IsTrue(new Ingredients().PubliclyDisclosedAreEditable(),
				"Publicly disclosed should be editable but is not", "As expected, publicly disclosed is editable");
		}

		[StepDefinition(@"I edit the (first|second) component to show (.*) for Publicly disclosed")]
		public void ThenIEditTheComponentToShowYesForPubliclyDisclosed(string firstOrSecond, string yesOrNo)
		{
			var newProductIngredients = new Ingredients();

			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();

			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}
			string firstIngredientName = ListOfIngredients[0].ComponentName;
			if (firstOrSecond.ToLower() == "second")
			{
				firstIngredientName= ListOfIngredients[1].ComponentName;
			}


			newProductIngredients.SetIngredientPubliclyDisclosed(firstIngredientName, (yesOrNo.ToLower() == "yes"));
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm that for the first component an error is shown below the Public Name drop down which reads: (.*)")]
		public void ThenIConfirmThatForTheFirstComponentAnErrorIsShownBelowThePublicNameDropDownWhichReads(string expectedError)
		{
			var newProductIngredients = new Ingredients();

			if (!newProductIngredients.Exists)
			{
				Report.Failure("Ingredients page is not showing as expected. Navigating to it....");
				GivenInTheNewProductPageIClickSection("Ingredients");
			}
			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();

			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}

			string firstIngredientName = ListOfIngredients[0].ComponentName;
			string actualErrorMessage = newProductIngredients.GetPublicNameErrorMessage(firstIngredientName);
			Report.IsTrue(actualErrorMessage == expectedError,
				"Expected error message: " + expectedError + " but got: '" + actualErrorMessage + "'",
				"Error is showing as expected" + expectedError);
		}

		[StepDefinition(@"I confirm that for the first component shows no error below the Public Name drop down")]
		public void ThenIConfirmThatForTheFirstComponentShowsNoErrorBelowThePublicNameDropDown()
		{
			var newProductIngredients = new Ingredients();

			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();

			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}

			string firstIngredientName = ListOfIngredients[0].ComponentName;
			string actualErrorMessage = newProductIngredients.GetPublicNameErrorMessage(firstIngredientName);
			Report.IsTrue(actualErrorMessage == "",
				"Expected no error message but got: '" + actualErrorMessage + "'",
				"As expected, no error is showing");
		}


		[StepDefinition(@"I edit the (first|second) component to select: (.*) from the Public Name drop down and save choice as (.*)")]
		public void ThenIEditTheFirstComponentToSelectFromThePublicNameDropDown(string firstOrSecond, string option, string saveAs)
		{
			Report.Info("Beginning I edit the " + firstOrSecond + " component to select: " + option +
			            " from the Public Name drop down and save choice as " + saveAs);
			var newProductIngredients = new Ingredients();

			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();
			Report.Info("Found " + ListOfIngredients.Count + " ingredients");

			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}

			string firstIngredientName = ListOfIngredients[0].ComponentName;
			if (firstOrSecond.ToLower() == "second")
			{
				firstIngredientName = ListOfIngredients[1].ComponentName;
			}

			if (option.ToLower() == "<random>")
			{
				List<string> availableOptions = newProductIngredients.GetIngredientPublicNameOptions(firstIngredientName);
				List<string> filtered = availableOptions.Where(i => i != "Choose..." && i != "Undisclosed Ingredient").ToList();
				if (filtered.Count() == 0)
				{
					option = "Undisclosed Ingredient";
				}
				else
				{
					Random rnd = new Random();
					option = filtered[rnd.Next(0, filtered.Count()-1)];
				}

			}
			Report.Info("Beginning select ingredient: " + firstIngredientName + " with option: " + option);
			newProductIngredients.SelectIngredientPublicName(firstIngredientName, option);
			Context.AddToContext(saveAs, option);
			Report.Screenshot();
		}

	}
}

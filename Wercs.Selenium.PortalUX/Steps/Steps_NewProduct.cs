using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

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

		[StepDefinition(@"I should see an error message: (.*)")]
		public void ErrorMessage(string message)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the error message: " + message);
			try
			{
				Report.Info("Checking error message");
				var selNewProduct = new NewProduct();
				var found = selNewProduct.ErrorMessage();

				Report.IsTrue(found.Trim() == message.Trim(),
					"Error message was not as expected! Expected: " + message + ", but found: " + found + "!",
					"Error message was showing: " + message + ", as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
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

				Report.Info("Languages found for " + row["Document Name"] + ": " + string.Join(", ",languagesShowing));

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

		[StepDefinition(@"in the New Product page I click Continue")]
		public void GivenInTheNewProductPageIClickContinue()
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.Wait_for_load(10), "New product page is not loaded", "New product page is loaded.");
			selNewProduct.ClickContinue();
		}

		[StepDefinition(@"I should see the Select Retailers pop up")]
		[StepDefinition(@"the 'Select Retailers' window appears")]
		public void GivenIShouldSeeTheSelectRetailersPopUp()
		{
			var selSelectRetailers = new SelectRetailers();
			Report.IsTrue(selSelectRetailers.Wait_for_load(20), "Select retailers page is not loaded", "Select retailers page is loaded.");
		}

		
		[StepDefinition(@"In the 'Select Retailers' window I select the retailer: (.*)")]
		public void ThenISelectTheRetailer_InTheWindow(string retailer)
		{
			var selectRetailers = new SelectRetailers();
			Report.IsTrue(selectRetailers.SelectRetailer(retailer), "Failed to select retailer: " + retailer + "!", "Successfully selected retailer: " + retailer);
			Report.IsTrue(selectRetailers.ClickDone(), "Failed to click the 'Done' button!", "Successfully clicked the 'Done' button");
		}

		[StepDefinition(@"In the 'Select retailers' window I (should|should not) see the following retailers:")]
		public void CheckingCorrectRetailersAreShowing(string should, Table expected)
		{
			var showing = new SelectRetailers().GetListOfRetailers().Where(x=>x.Trim()!="");
			Report.Info("Retailers showing were: " + string.Join(", ",showing));
			bool expectedOrNot = should == "should";
			foreach (var row in expected.Rows)
			{
				Report.IsTrue(showing.Contains(row["Retailer"]) == expectedOrNot, (expectedOrNot ? "Did not find" : "Found") + " the retailer: " + row["Retailer"], "The retailer " + row["Retailer"] + (expectedOrNot ? " was": " was not") + " showing, as expected!", false, false);
			}
			Report.Screenshot();
		}

		/// <summary>
		/// Select an option for Indicate full name of product, as sold, via this retailer (e.g.Private Label Aspirin) dropdown
		/// </summary>
		[Then(@"In the Retailers tab, I select Private Label name as: (.*)")]
		public void ThenInTheRetailersTabISelectPrivateLabelNameAs(string option)
		{
			Report.IsTrue(new NewProduct().SelectPrivateLabelName(option), "Failed to set the Private label name to be: " + option, "Successfully set private label name to be: " + option);
		}

		/// <summary>
		/// Select an option for Indicate full name of product, as sold, via this retailer (e.g.Private Label Aspirin) dropdown
		/// </summary>
		[Then(@"In the Retailers tab, I enter Private Label name as: (.*)")]
		public void ThenInTheRetailersTabIEnterPrivateLabelNameAs(string option)
		{
			Report.IsTrue(new NewProduct().EnterPrivateLabelName(option), "Failed to set the Private label name to be: " + option, "Successfully set private label name to be: " + option);
		}


		/// <summary>
		/// Select an option for vendor id  dropdown
		/// </summary>
		[Then(@"In the Retailers tab, I select Vendor id as: (.*)")]
		public void ThenInTheRetailersTabISelectVendorIdAs(string option)
		{
			Report.IsTrue(new NewProduct().SelectVendorId(option), "Failed to set the vendor id to be: " + option, "Successfully set vendor id to be: " + option);
		}


		[StepDefinition(@"I save the product information as: (.*)")]
		public void SaveProductInformation(string savedas)
		{
			var prodDetails = new NewProduct().GetCurrentProductInformation();
			Context.AddToContext(savedas, prodDetails);
			Report.Success("Product Information saved!");
		}

		[StepDefinition(@"I should see the (.*) Page")]
		public void GivenIShouldSeeXPage(string pageShouldSee)
		{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForSection(pageShouldSee), pageShouldSee + " is not showing",
					pageShouldSee + " is showing as expected");
		}

		[StepDefinition(@"I should see the Additional Information Page")]
		public void GivenIShouldSeeTheAdditionalInformationPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the New Product page I click Continue");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForSection("Additional Product Information"), "Additional product information is not showing",
					"The additional product information page is showing as expected");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
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
				List<Battery> listOfBatteries= new List<Battery>();
				//| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
				foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
				{
					Battery thisBattery = new Battery(){
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

				selNewProduct.TscaStatus= option;

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
					if (checkOutcome.Select(x => x.Metal == thisMetalPresence.Metal && x.Presence == thisMetalPresence.Presence).Count()==0)
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

			selNewProduct.MinimumIgnitionEnergy  = selection;

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
		/// Enter in UN Number textbox
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I enter: (.*) in the UN Number text field")]
		public void GivenInTheProductCharacteristicsTabIEnterInTheUNNumberTextField(string text)
		{
			//var selNewProduct = new NewProduct();
			//Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
			//	"Product type tab is loaded.");
			//selNewProduct.UNnumber = option;

			Report.IsTrue(new NewProduct().UNnumber(text), "Text: " + text + " was not successfully inputted into the comments field!", "Text: " + text + " was successfully inputted into the comments field!");
		}

		/// <summary>
		/// Select Hazard Class from dropdown
		/// </summary>
		[StepDefinition(@"In the product Characteristics tab, I set Hazard Class to be: (.*)")]
		public void GivenInTheProductCharacteristicsTabISetHazardClassToBe(string option)
		{
			Report.IsTrue(new NewProduct().HazardClassSelect(option), "Failed to set the option to be: " + option, "Successfully set option to be: " + option);
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
			//NewProduct selNewProduct = new NewProduct();

			//List<string> itemsToSelect = selections.Split(',').ToList().Select(x=>x.Trim()).ToList();
			//selNewProduct.DOTExceptions = itemsToSelect;

			//List<string> itemsSelected = selNewProduct.DOTExceptions;

			//foreach (string item in itemsToSelect)
			//{
			//	if (itemsSelected.Select(x => x.Contains(item)).Count() != 1)
			//	{
			//		throw new Exception("Failed to select: " + item);
			//	}
			//}
			//Report.Success("Successfully selected: " + selections);

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
			NewProduct selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.ClickSection(section), "Failed to click section: " + section, "Successfully clicked section: " + section);
			Delay.Seconds(1);
			GivenIShouldSeeXPage(section);
		}

		[StepDefinition(@"I delete UPC: (.*)")]
		public void GivenIDeleteUPC(string upc)
		{
			NewProduct selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.DeleteUPC(upc), "Failed to delete UPC:" + upc, "Successfully deleted: " + upc);
		}

		[Then(@"In the list of UPCs I should not see UPC: (.*)")]
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
			var found = newProductpage.GetVocContentWithIntendedUsesAerosolCoatingStatement();

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
			var found = newProductpage.GetVocAnalysisDate();

			Report.IsTrue(found.Trim() == date.Trim(),
				"date was not as expected! Expected: " + date + ", but found: " + found + "!",
				"statement was showing: " + date + ", as expected!");
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

		/// <summary>
		/// Confirm VOC Grams Ozone/Grams Product
		/// </summary>
		[StepDefinition(@"I confirm that I see the following VOC Grams Ozone Grams Product: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingVOCGramsOzoneGramsProduct(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetVocGramOzone();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm HVOC value
		/// </summary>
		[StepDefinition(@"I confirm that I see the following HVOC: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingHVOC(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetHvocValue();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"value was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"value was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm MVOC value
		/// </summary>
		[StepDefinition(@"I confirm that I see the following MVOC: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingMVOC(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.GetMvocValue();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"value was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"value was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm limits statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following limits statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingLimitsStatement(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.LimitsSpecified();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
		}

		/// <summary>
		/// Confirm Based on the type of product, this must comply with the most restrictive VOC limit statement
		/// </summary>
		[StepDefinition(@"I confirm that I see the following comply with restrictive VOC statement: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingComplyWithRestrictiveVOCStatement(string statement)
		{
			var newProductpage = new NewProduct();
			var found = newProductpage.BasedOnTypeOfProductComplyWithVOCLimit();

			Report.IsTrue(found.Trim() == statement.Trim(),
				"statement was not as expected! Expected: " + statement + ", but found: " + found + "!",
				"statement was showing: " + statement + ", as expected!");
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
				List<string> countries = new List<string>(){country};

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
		}

		[StepDefinition(@"I should only see the following options for Primary Physical State:")]
		public void PrimaryPhysicalOptionsShowingCorrectly(Table expected)
		{
			var found = new NewProduct().ListOfPrimaryPhysicalStates();
			Report.Info("Primary Physical States found: " + string.Join(", ", found));

			foreach (var row in expected.Rows)
			{
				if (Report.IsTrue(found.Contains(row["State"]), "Failed to find state: " + row["State"] + " in the list!", row["State"] + " was successfully found!"))
				{
					found.Remove(row["State"]);
				}
			}

			Report.IsTrue(found.Count == 0, "Not all Physical States were found! Remaining were: " + string.Join(", ", found), "All primary physical states were found successfully!");
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

		[Then(@"I set the water solubility description to: (.*)")]
		public void ThenISetTheWaterSolubilityDescriptionTo(string description)
		{
			NewProduct thisNewProduct = new NewProduct();
			new NewProduct().WaterSolubility = description;
			Report.IsTrue(thisNewProduct.WaterSolubility==description, "Failed to set the water solubility description to be: " + description, "Successfully set the water solubility description to be: " + description);
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


		[Then(@"In the Product Characteristics tab of the New Product Page, for When the product has a flammable propellant I select: (.*)")]
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the correct Radio buttons");
			try
			{
				var selNewProduct = new NewProduct();
				var radioButtonsShowing = selNewProduct.RadioButtons();

				foreach (var row in expected.Rows)
				{
					var buttonText = row["Button"];
					Report.Info("Checking that I see the radio button '" + buttonText + "'");
					Report.IsTrue(radioButtonsShowing.Contains(buttonText.Trim()),
						"Radio Button was not showing as expected! Expected: '" + buttonText + "', but found: '" + string.Join("', '", radioButtonsShowing) + "'!",
						"Radio Button was showing: '" + buttonText + "', as expected!");
				}
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
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

		[Given(@"In the Data Acceptance page I select Yes, Agreed")]
		public void GivenInTheDataAcceptancePageISelectYesAgreed()
		{
			Report.IsTrue(new NewProduct().SelectYesAgreedRadio(), "Failed to select Yes Agreed", "Clicked Yes Agreed");
		}

		[Given(@"In the Data Acceptance page I click on the Accept button")]
		public void GivenInTheDataAcceptancePageIClickOnTheAcceptButton()
		{
			Report.IsTrue(new NewProduct().ClickAcceptButton(), "Failed to Click accept button", "Clicked accept button");
			GeneralUtilities.Wait_for_load_finish();
		}




		[StepDefinition(@"I click the Summary button in the Data Acceptance window")]
		public void GivenIClickTheSummaryButtonInTheDataAcceptanceWindow()
		{
			Report.IsTrue(new NewProduct().ClickSummaruButtonInDataAcceptance(), "Failed to click the Summary button!", "Successfully clicked the Summary button!");
		}

		[StepDefinition(@"I add the following ingredients:")]
		public void AddIngredients(Table ingredientInformation)
		{
			var Ingredients = ingredientInformation.CreateSet<Ingredient>();

			foreach (var item in Ingredients)
			{
				Report.IsTrue(new NewProduct().AddIngredient(item), "Failed to add ingredient: " + (item.CASNumber==""?item.ComponentName:item.CASNumber) + "!", "Successfully added ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber));
			}
		}

		[StepDefinition(@"I set the (.*) option to: (.*)")]
		[StepDefinition(@"I set the (.*) field to: (.*)")]
		public void SetTheSectionOptionTo(string section, string option)
		{
			Report.IsTrue(new NewProduct().SetOptionInSection(section, option), "Failed to set the input to " + option + " in section: " + section, "Successfully set the input to " + option + " in section: " + section);
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
		[StepDefinition(@"(.*) should be showing the error messages: (.*)")]
		public void ErrorMessagesAreShowingForItem(string section, string pipeDelimitedErrorMessages)
		{
			var errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			var errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.Info("Error messages showing are: " + string.Join(", ",errorMessages));
			foreach (var item in errorMessagesExpected)
			{
				Report.IsTrue(errorMessages.Contains(item.Trim()), "Failed to find the error message: " + item + "!", "Successfully found the error message: " + item + "!", false, false);
			}
			Report.Screenshot();
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

	}
}

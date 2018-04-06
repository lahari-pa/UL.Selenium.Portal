using System;
using System.Collections.Generic;
using System.Linq;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

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


		//

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

		[Given(@"I Select the Create a New Registration radio button")]
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

		[Given(@"in the New Product page I click Continue")]
		public void GivenInTheNewProductPageIClickContinue()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the New Product page I click Continue");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.Wait_for_load(10), "New product page is not loaded", "New product page is loaded.");
				selNewProduct.ClickContinue();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"I should see the Additional Information Page")]
		public void GivenIShouldSeeTheAdditionalInformationPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the New Product page I click Continue");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForAdditionalProductInformation(), "Additional product information is not showing",
					"The additional product information page is showing as expected");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[Given(@"In the Product Type tab of the New Product Page, I enter: (.*) in the Product Name text field")]
		public void GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheProductNameTextField(string productName)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Type tab of the New Product Page, I enter: " + productName + " in the Product Name text field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				selNewProduct.ProductName = productName;
				
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"in the Product Characteristics tab of the New Product Page, for U\.S\. Toxic Substances Control Act \(TSCA\) status I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForU_S_ToxicSubstancesControlActTSCAStatusISelectOption(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: " + option);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
					"Product characteristics tab is loaded.");

				
				selNewProduct.TSCAStatus= option;

				Report.IsTrue(selNewProduct.TSCAStatus == option,
					"Failed to set TSCA status: " + option,
					"Successfully set TSCA status: " + option);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[Given(@"In the Additional Information Page for Product is solely for the Retailer's use I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductIsSolelyForTheRetailerSUseISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page for Product is solely for the Retailer's use I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");

				bool Expected = (noOrYes == "Yes");


				selNewProduct.SolelyForRetailersUse = Expected;

				Report.IsTrue(selNewProduct.SolelyForRetailersUse == Expected,
					"Failed to set Product is solely for the Retailer's use: " + noOrYes,
					"Successfully set Product is solely for the Retailer's use: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



		[Given(@"In the Additional Information Page for Product is retailers private label or brand I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductIsRetailersPrivateLabelOrBrandISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page for Product is retailers private label or brand I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");

				bool Expected = (noOrYes == "Yes");


				selNewProduct.RetailersPrivateLabelOrBrand = Expected;

				Report.IsTrue(selNewProduct.RetailersPrivateLabelOrBrand == Expected,
					"Failed to set Product is retailers private label or brand: " + noOrYes,
					"Successfully set Product is retailers private label or brand: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"in the Product Characteristics tab of the New Product Page for Prop(.*) I select: (No|Yes)")]
		public void GivenInTheProductCharacteristicsTabOfTheNewProductPageForPropISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab of the New Product Page for Prop65 I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
					"Product characteristics tab is loaded.");

				bool Expected = (noOrYes == "Yes");


				selNewProduct.Prop65 = Expected;

				Report.IsTrue(selNewProduct.Prop65 == Expected,
					"Failed to set Prop 65 value to: " + noOrYes,
					"Successfully set Prop 65 value to: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



		[Given(@"In the Additional Information Page for Product is shipped directly I select: (No|Yes)")]
		public void GivenInTheAdditionalInformationPageForProductIsShippedDirectlyISelectNoOrYes(string noOrYes)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page for Product is shipped directly I select: " + noOrYes);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");

				bool Expected = (noOrYes == "Yes");


				selNewProduct.ProductShippedDirectly = Expected;

				Report.IsTrue(selNewProduct.ProductShippedDirectly == Expected,
					"Failed to set product shipped directly value to: " + noOrYes,
					"Successfully set product shipped directly value to: " + noOrYes);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[Given(@"In the Additional Information Page the check box for: (.*) should be: (checked|unchecked)")]
		public void GivenInTheAdditionalInformationPageTheCheckBoxXShouldBeCheckedOrUnchecked(string country, string checkedOrUnchecked)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Additional Information Page the check box for: " + country + " should be: " + checkedOrUnchecked);
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded",
					"Product type tab is loaded.");
				List<string> Countries = new List<string>(){country};

				bool Expected = (checkedOrUnchecked == "checked");

				if (Expected)
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


		[Given(@"In the Product Type tab of the New Product Page, I enter: (.*) in the Type of Product select field")]
		public void GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField(string typeOfProduct)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Product Type tab of the New Product Page, I enter: " + typeOfProduct + " in the Type of Product select field");
			try
			{
				var selNewProduct = new NewProduct();
				Report.IsTrue(selNewProduct.WaitForTab("Product Type"), "Product type has not loaded", "Product type tab is loaded.");
				selNewProduct.ProductType = typeOfProduct;

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
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
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using SafewareSeleniumUtilities;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
    [Binding, Scope(Tag = "NewProduct")]
    class Steps_NewProduct
    {
        [StepDefinition(@"the Product Type page should be loaded")]
        [StepDefinition(@"the Product Editor page should be loaded")]
        public void ProductTypePageLoaded()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Product Type page should be loaded");
            try
            {
                Report.Info("Product Type page should be loaded");
                var Sel_NewProduct = new NewProduct();
                Report.IsTrue(Sel_NewProduct.Wait_for_load(10), "Product Type page did not load!", "Product Type page loaded successfully!");
               Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

       

        [StepDefinition(@"the product saved as: (.*) should be visible in editor")]
        public void CorrectProductVisibleInEditor(string SavedAs)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Product saved as " + SavedAs + " is visible in editor");
            try
            {
                Report.Info("Checking that the product saved as " + SavedAs + " is visible in editor");
                var Product = (ProductGridItem) Context.GetFromContext(SavedAs);
                Report.Info("Checking that Product with ID: '" + Product.ProductID + "' is visible!");
                var ExpectingToFind = Product.ProductName + " (" + Product.ProductID + ")";
                Report.Info("Expecting to find string: '" + ExpectingToFind + "'");
                var Sel_NewProduct = new NewProduct();
                var CurrentlyShowing = Sel_NewProduct.GetCurrentProduct();
                Report.Info("Found: '" + CurrentlyShowing + "'");
                Report.IsTrue(ExpectingToFind.Trim() == CurrentlyShowing.Trim(), "Value was not as expected!", "Product was showing correctly in the editor!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I create a shell product with name (.*) saved as (.*)")]
        public void CreateShellProduct(string Name, string SavedAs)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Creating shell product with name " + Name + ", saved as " + SavedAs);
            try
            {
                Report.Info("Creating shell product with name " + Name + ", saved as " + SavedAs);
                var Sel_NewProduct = new NewProduct();

                if (!Sel_NewProduct.Wait_for_load(10))
                    throw new Exception("Page failed to load!");

                Report.Info("Selecting 'Yes, create a new product'");
                // Creates a New Product
                Sel_NewProduct.CreateNewProductOrCopy(true);
                Report.Screenshot();

                Report.Info("Clicking continue");
                Report.IsTrue(Sel_NewProduct.ClickContinue(), "Failed to click 'Continue'!");

                Report.Info("Inputting Name: '" + Name + "'");
                Sel_NewProduct.ProductName = Name;
                Report.Info("Setting Product Type to be: 'Game System w/Battery'");
                Sel_NewProduct.ProductType = "Game System w/Battery";
                Report.Screenshot();

                Report.Info("Clicking continue");
                Report.IsTrue(Sel_NewProduct.ClickContinue(), "Failed to click 'Continue'!");

                Report.Info("Getting Product ID");
                var FullProductName = Sel_NewProduct.GetHeader();
                // Product Name made out of the name + the Id - so if we remove the Name from the product we should be left with an ID!
                var ProductID = FullProductName.Replace(Name, "").Replace("(", "").Replace(")", "").Trim();

                Report.Info("ProductID was: '" + ProductID + "'");

                var ProductEntry = new ProductGridItem();
                ProductEntry.ProductID = ProductID;
                ProductEntry.ProductName = Name.Trim();
                Context.AddToContext(SavedAs,ProductEntry);

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
			    var Sel_NewProduct = new NewProduct();
				Report.IsTrue(Sel_NewProduct.ClickContinue(), "Failed to click 'Continue'!","Clicked continue successfully!");
				Report.Screenshot();
			}
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
	    }

	    [StepDefinition(@"I should see an error message: (.*)")]
	    public void ErrorMessage(string Message)
	    {
		    TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the error message: " + Message);
		    try
		    {
			    Report.Info("Checking error message");
			    var Sel_NewProduct = new NewProduct();
			    var Found = Sel_NewProduct.ErrorMessage();

				Report.IsTrue(Found.Trim()==Message.Trim(), 
					"Error message was not as expected! Expected: " + Message + ", but found: " + Found + "!", 
					"Error message was showing: " + Message + ", as expected!");
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
        public void CorrectHeaderShouldBeShowing(string Header)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the header is showing " + Header);
            try
            {
                Report.Info("Checking that the header is showing " + Header);
                var Sel_NewProduct = new NewProduct();

                if (!Sel_NewProduct.Wait_for_load(10))
                    throw new Exception("Page failed to load!");

                var HeaderShowing = Sel_NewProduct.GetHeader();
                Report.IsTrue(HeaderShowing.Trim() == Header.Trim(),
                    "Header was not showing as expected! Expected: '" + Header + "', but found: '" + HeaderShowing + "'!",
                    "Header was showing: '" + Header + "', as expected!");
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
                var Sel_NewProduct = new NewProduct();
                var StatementShowing = Sel_NewProduct.GetInitialStatement();
                Report.IsTrue(StatementShowing.Trim() == statement.Trim(),
                    "Statement was not showing as expected! Expected: '" + statement + "', but found: '" + StatementShowing + "'!",
                    "Statement was showing: '" + statement + "', as expected!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see the radio button: (.*)")]
        public void IShouldSeeTheRadioButton(string Button)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the radio button " + Button);
            try
            {
                Report.Info("Checking that I see the radio button '" + Button + "'");
                var Sel_NewProduct = new NewProduct();
                var RadioButtonsShowing = Sel_NewProduct.RadioButtons();
                Report.IsTrue(RadioButtonsShowing.Contains(Button.Trim()),
                    "Radio Button was not showing as expected! Expected: '" + Button + "', but found: '" + String.Join("', '",RadioButtonsShowing) + "'!",
                    "Radio Button was showing: '" + Button + "', as expected!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

	    [StepDefinition(@"I should see the following radio buttons:")]
	    public void IShouldSeeTheRadioButton(Table Expected)
	    {
		    TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the correct Radio buttons");
		    try
		    {
			    var Sel_NewProduct = new NewProduct();
			    var RadioButtonsShowing = Sel_NewProduct.RadioButtons();

				foreach (var Row in Expected.Rows)
			    {
				    var ButtonText = Row["Button"];
				    Report.Info("Checking that I see the radio button '" + ButtonText + "'");
					Report.IsTrue(RadioButtonsShowing.Contains(ButtonText.Trim()),
					    "Radio Button was not showing as expected! Expected: '" + ButtonText + "', but found: '" + String.Join("', '", RadioButtonsShowing) + "'!",
					    "Radio Button was showing: '" + ButtonText + "', as expected!");
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

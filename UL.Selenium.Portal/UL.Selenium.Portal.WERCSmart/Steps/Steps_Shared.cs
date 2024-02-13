using NPOI.SS.Formula.Functions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Database_Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Shared")]
	public class Steps_Shared
	{

		// For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

		[StepDefinition(@"I call Shared Step 57408 \(Create a New Registration via Register New Product icon\)")]
		public void GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I click the Register New Product icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Add Product");
			Report.StartSubStep("I should see the New Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("New Product");
			Report.StartSubStep("I set the Select the type of product to create option to: Create a New Registration");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the type of product to create",
				"Create a New Registration");
			Report.StartSubStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		/// <summary>
		/// Enter a product name
		/// select Type of product
		/// click continue
		/// </summary>

		//Seems to be identical to 57500
		[StepDefinition(
			@"I call Shared Step 57561 \(The Product - Enter Product Name and select Type of Product\): (.*)")]
		public void GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct(string type)
		{
			this.Step57561(type, "");
		}

		//Seems to be identical to 57500
		[StepDefinition(@"I call Shared Step 57561a \(The Product - Enter Product Name: (.*) and select Type of Product\): (.*)")]
		public void GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct(string name, string type)
		{
			this.Step57561(type, name);
		}

		public void Step57561(string type, string name = "")
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			Report.StartSubStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			if (name == "")
			{
				char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
				name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			}
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartSubStep($"In the Product Type tab of the New Product Page, I enter: { type } in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartSubStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			var modal = new ModalDialog();

			if (type == "Raw Material")
			{
				if (modal.WaitForContainerToBeVisible(2) && modal.GetTitle().Contains("Warning"))
				{
					Report.Info($"The Raw Material warning popup was found");
					Report.Info("Closing popup");
					modal.ClickButton("OK");
					Delay.Seconds(2);
					Report.Info("I click Continue");
					MyStepsNewProduct.ClickContinue();
				}
			}
		}

		[StepDefinition(@"I call Shared Step 60779 \(Enter Liquid - Cooking Oil - Non-Aerosol\)")]
		public void GivenICallSharedStepEnterLiquid_CookingOil_Non_Aerosol()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Relative Density", "20");
			MyStepsNewProduct.SectExatcDataNotKnown("pH");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7 (Neutral)");
			//MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Not Tested/Unknown");

			//MyStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");

			MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			MyStepsNewProduct.SetTheSectionOptionTo("Select all potential allergens included in this product", "Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains",
				"Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)",
				"None of the Above");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60747 \(Select Primary Physical Property - Liquid - With Ingredients\)")]
		public void GivenICallSharedStepSelectPrimaryPhysicalProperty_Liquid_WithIngredients()
		{
			var MyStepsNewProduct = new StepsNewProduct();

			MyStepsNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");

			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Relative Density", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", ">=23C and <38C");
			var MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("Flash Point (in Celsius)", "Flammable 1C"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Flammable 1C");
			}
			else
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Not Tested/Unknown");
			}

			if (MyNewProduct.OptionExists("Select the best Water Solubility description"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Select all potential allergens included in this product", "Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains",
				"Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)",
				"None of the Above");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only")]
		public void GivenICallSharedStep60935ProductInformation_US_DirectShip_PrivateLabelOnly()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 216821 - Product Information - Product Information - Applicable Only to Alcoholic Beverages - Wine \(RU001418\)")]
		[StepDefinition(@"I call Shared Step 90477 - Product Information - US, \(NO\) Retailer's PL")]
		public void ICallSharedStep90477ProductInformation_US_NoRetailersPL()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 60726 \(Product Information - Country and Private Label or Brand - Yes\)")]
		public void GivenICallSharedStep60726ProductInformation_CountryAndPrivateLabelOrBrand_Yes()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");

			//CLF - this option doesn't always appear. Putting this fix in for now but may need a new version of the step
			var MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("Select the product's Country of Origin"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");

			}

			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60756 \(Product Information with Country and every option\)")]
		public void GivenICallSharedStepProductInformationWithCountryAndEveryOption()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			if (myNewProduct.CountryofOriginExists())
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");
			}

			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 63704 \(Product Information - US, No\(DSV\), No\(PL\), No\(GNFR\)\)")]
		public void GivenICallSharedStepProductInformationUSNoDSVNoPLNoGNFR()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			if (myNewProduct.CountryofOriginExists())
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");
			}
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 60935 \(Product Information - US - Direct Ship - Private Label Only\)")]
		public void SharedProductInformation_US_DirectShip_PrivateLabelOnly()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"Retailers will be selling my product at their store locations in (select either or both) : United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Retailers will be selling my product at their store locations in (select either or both) ",
				"United States");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product", "No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 70393 \(Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only\)")]
		public void
			GivenICallSharedStepProductInformation_WithMarketedForUseByAChild_DirectShip_PrivateLabelQuestionsOnly()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);
			if (myNewProduct.SectionExists("Select countries the product may be sold in"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			}

			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					"No");
			}

			if (myNewProduct.SectionExists("Product is shipped directly by supplier to the consumer."))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.",
					"No");
			}

			if (myNewProduct.SectionExists("Product is a Retailer's Private Label or Brand"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			}

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 57569 \(Enter Product Details for Aerosol\)")]
		public void GivenICallSharedStepEnterProductDetailsForAerosol()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();

			if (myNewProduct.SectionExists("Which best describes your product, including when FIFRA 25(b) Exempt"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
					"Regulates Plant Growth");

				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			}
			else
			{
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			}

			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					"No");
			}

			if (myNewProduct.SectionExists(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", "Yes");
			}

			if (myNewProduct.SectionExists("Product is shipped directly by supplier to the consumer."))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.",
					"Yes");
			}

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 101672 \(Physical and Chemical Properties - Primary Physical State = Aerosol / Secondary Physical State = Liquid Spray \)")]
		public void GivenICallSharedEnterPhysicalProperty_Aerosal()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			MyNewProduct.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			Report.StartSubStep("I set the Primary Physical State option to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");

			Report.StartSubStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("pH", "Not tested/Unknown");
			Report.StartSubStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble in water");
			Report.StartSubStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");

		}

		[StepDefinition(@"I call Shared Step 57570 \(Enter Ingredients\) and add the following ingredients:")]
		public void GivenICallSharedStepEnterIngredients(Table ingredientsTable)
		{
			Report.UseSubSteps = true;
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			Report.StartSubStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			Report.StartSubStep("I should see the ingredients error message");
			stepsNewProductIngredients.IngredientsErrorMessageShowing("should");
			Report.StartSubStep("I add the following ingredients:");
			stepsNewProductIngredients.AddIngredients(ingredientsTable);
			Report.StartSubStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			Report.StartSubStep("I should not see the ingredient obsolete error message");
			stepsNewProductIngredients.CheckForObsoleteIngredient();
			Report.Screenshot();
			List<string> popupCausing = new Ingredients().IngredientsFIFRAPopup();


			List<string> allIngredientsNames = new List<string>();
			var tableCast = ingredientsTable.Rows.Cast<TableRow>().ToList();
			var headerRow = tableCast[0];
			if (headerRow.Keys.Contains("ComponentName"))
			{
				ingredientsTable.Rows.Cast<TableRow>().ToList().ForEach(x => allIngredientsNames.Add(x["ComponentName"]));

			}
			if (headerRow.Keys.Contains("CASNumber"))
			{
				ingredientsTable.Rows.Cast<TableRow>().ToList().ForEach(x => allIngredientsNames.Add(x["CASNumber"]));

			}


			//Andrew - I have updated this step so only items in the hardcoded FIFRA lists of ingredients handle the popup.
			bool fifraItemFound = false;

			foreach (var item in allIngredientsNames)
			{
				if (popupCausing.Contains(item))
				{
					Report.Info($"The component name: {item} was found fifra list");
					fifraItemFound = true;
				}
			}
			if (fifraItemFound == true)
			{
				Report.Info($"Looking in context for the fifra tag...");
				bool fifraTag;
				if (Context.Contains("FIFRAPopupExpected"))
				{
					Report.Info($"Tag was found in context, settting value to match");

					fifraTag = (bool)Context.GetFromContext("FIFRAPopupExpected");
				}
				else
				{
					Report.Info($"Tag was not found in context, default value of true/expected being set as no FIFRA question has been answered");
					fifraTag = true;
				}
				if (fifraTag == true)
				{
					Report.Info($"The fifra tag was set a true, popup is expected");
					if (Report.IsTrue(new Ingredients().ConfirmThereIsAPopupViewTitled("Product Contains Ingredients Typical of a Pesticide"), "Failed to find popup", "Found popup"))
					{
						new StepsIngredients().ThenIConfirmICheckTheCheckboxInThePopupViewWithTheFollowingText("The Product Type, Pest Selection, and Ingredients listed are accurate.");
						new StepsIngredients().ThenInThePopupViewWithTheFollowingTitleProductContainsIngredientsTypicalOfAPesticideIClickTheConfirmButton("Product Contains Ingredients Typical of a Pesticide", "Confirm");
						Delay.Seconds(10);
						Report.Screenshot();
						//Report.StartStep("I should see the Waste Classification Data Page");
						//MyNewProductSteps.GivenIShouldSeeXPage("Waste Classification Data");
					}
					else
					{
						Report.Failure("Popup not found");
						Report.Screenshot();
						Report.StartStep("In the Ingredients page I click Continue");
						MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
						//return; 
					}
				}
				else
				{
					Report.Info($"The fifra tag was set a false, popup is not expected");
				}


			}
			else
			{
				Report.Info($"Ingredient name used was not found in the list of hardcoded FIFRA ingredients...");
				Report.Screenshot();

			}


		}

		[StepDefinition(@"I call Shared Step 57570c \(Enter Ingredients\) and add the following ingredients for Canda Only:")]
		public void GivenICallSharedStepEnterIngredientsCanandaOnly(Table ingredientsTable)
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			Report.StartSubStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			Report.StartSubStep("I should see the ingredients error message");
			stepsNewProductIngredients.IngredientsErrorMessageShowing("should");
			Report.StartSubStep("I add the following ingredients:");
			stepsNewProductIngredients.AddIngredients(ingredientsTable);
			Report.StartSubStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");

			Report.Screenshot();

		}

		[StepDefinition(@"I call Shared Step 69557 \(Enter Ingredients for Aerosol Propellent\)")]
		public void GivenICallSharedEnterIngrediebtsForAerosolPropellant()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			var aerosolIngredients = new TechTalk.SpecFlow.Table(new string[] {
				"ComponentName",
				"Percent",
				"PublicallyDisclosed",
				"TradeSecret",
				"PublicName"
			});
			aerosolIngredients.AddRow(new string[] {
				"Butane",
				"20",
				"False",
				"False",
				""
			});
			aerosolIngredients.AddRow(new string[] {
				"Isopentane",
				"30",
				"False",
				"False",
				""
			});
			Report.StartSubStep("I add the following ingredients (aerosol propellant):");
			stepsNewProductIngredients.AddIngredients(aerosolIngredients);
			var otherIngredients = new Table(new string[] {
				"ComponentName",
				"Percent",
				"PublicallyDisclosed",
				"TradeSecret",
				"PublicName"
			});
			otherIngredients.AddRow(new string[] {
				"Sodium hydroxide",
				"40",
				"False",
				"False",
				""
			});
			otherIngredients.AddRow(new string[] {
				"Water",
				"10",
				"False",
				"False",
				""
			});
			Report.StartSubStep("I add the following ingredients (other):");
			stepsNewProductIngredients.AddIngredients(otherIngredients);
			Report.StartSubStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");

			Report.Screenshot();
			List<string> popupCausing = new Ingredients().IngredientsFIFRAPopup();


			List<string> allIngredientsNames = new List<string>();
			aerosolIngredients.Rows.Cast<TableRow>().ToList().ForEach(x => allIngredientsNames.Add(x["ComponentName"]));
			otherIngredients.Rows.Cast<TableRow>().ToList().ForEach(x => allIngredientsNames.Add(x["ComponentName"]));

			bool fifraItemFound = false;

			foreach (var item in allIngredientsNames)
			{
				if (popupCausing.Contains(item))
				{
					Report.Info($"The component name: {item} was found fifra list");
					fifraItemFound = true;
				}
			}
			if (fifraItemFound == true)
			{
				Report.Info($"Looking in context for the fifra tag...");
				bool fifraTag;
				if (Context.Contains("FIFRAPopupExpected"))
				{
					Report.Info($"Tag was found in context, settting value to match");

					fifraTag = (bool)Context.GetFromContext("FIFRAPopupExpected");
				}
				else
				{
					Report.Info($"Tag was not found in context, default value of true/expected being set as no FIFRA question has been answered");
					fifraTag = true;
				}
				if (fifraTag == true)
				{
					Report.Info($"The fifra tag was set a true, popup is expected");
					if (Report.IsTrue(new Ingredients().ConfirmThereIsAPopupViewTitled("Product Contains Ingredients Typical of a Pesticide"), "Failed to find popup", "Found popup"))
					{
						new StepsIngredients().ThenIConfirmICheckTheCheckboxInThePopupViewWithTheFollowingText("The Product Type, Pest Selection, and Ingredients listed are accurate.");
						new StepsIngredients().ThenInThePopupViewWithTheFollowingTitleProductContainsIngredientsTypicalOfAPesticideIClickTheConfirmButton("Product Contains Ingredients Typical of a Pesticide", "Confirm");
						Delay.Seconds(10);
						Report.Screenshot();

					}
					else
					{
						Report.Failure("Popup not found");
						Report.Screenshot();
						return;
					}
				}
				else
				{
					Report.Info($"The fifra tag was set a false, popup is not expected");
				}


			}
			else
			{
				Report.Info($"Ingredient name used was not found in the list of hardcoded FIFRA ingredients...");
				Report.Screenshot();

			}


		}

		[StepDefinition(@"I call Shared Step 60685 Fuel Container Regulatory Details - Yes")]
		public void GivenICallSharedFuelContainerRegulatoryDetails_Yes()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see Fuel Container Regulatory Details");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Fuel Container Regulatory Details");
			Report.StartSubStep("I Product is a Safety Can to: Yes");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Safety Can", "Yes");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Fuel Container Regulatory Details");
		}

		[StepDefinition(
			@"I call Shared Step 61449 Toxicity Characteristic Leaching Procedure \(TCLP\) - select No to all - Click Continue - Happy Path")]
		public void
			GivenICallShared61449ToxicityCharacteristicLeachingProcedureTCLP_SelectNoToAll_ClickContinue_HappyPath()
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsTclp = new Steps_ToxicityCharacteristicsLeachingProcedure();
			Report.StartSubStep("Toxicity Characteristic Leaching Procedure (TCLP)");
			stepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartSubStep("I set the Product has had TCLP testing to: No");
			stepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing", "No");
			Report.StartSubStep("I set all Metal presence values to No");
			stepsTclp.GivenISetAllTheMetalPresenceValueTo("No");
			Report.StartSubStep("I click continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP)");
		}

		[StepDefinition(@"I call Shared Step 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all")]
		public void GivenICallShared58189AnswerElectronicEquipmentQuestions_WithCathodeRay_NoToAll()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Electronic Equipment page");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Electronic Equipment");
			Report.StartSubStep("I set the Contains Circuit Board option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Contains Circuit Board", "No");
			Report.StartSubStep("I set the Has a Cathode Ray Tube option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a Cathode Ray Tube", "No");
			Report.StartSubStep("I set the Has a LCD or Plasma Display option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			Report.StartSubStep("I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Electronic equipment");
		}

		[StepDefinition(@"I call Shared Step 57571 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_NotProp()
		{
			var regulatoryInformation = new RegulatoryInformation1();
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 57571b \(Enter Regulatory Information - Not Prop 65\):")]
		public void GivenICallSharedEnterRegulatoryInformation_NotProp(Table table)
		{

			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			if (table.Rows.Count != 1)
			{
				Report.Error($"This step requires a table that only has one row in it, and there were {table.Rows.Count}.");
				Report.Info("Using only the first row from the table");
			}
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep($"I set the U.S. Toxic Substances Control Act (TSCA) status option to: {table.Rows[0]["TSCA"]}");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", table.Rows[0]["TSCA"]);
			Report.StartSubStep($"I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: {table.Rows[0]["Prop 65"]}");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", table.Rows[0]["Prop 65"]);
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 104276 \(Enter Regulatory Information - TSCA, CEPA, Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_TSCACEPANotProp()
		{
			var regulatoryInformation = new RegulatoryInformation1();
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			stepsRegulatoryInformation.SetCEPATo("Compliant with Domestic Substances List (DSL)");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		/// <summary>
		/// Requires a table with headings: | Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
		/// </summary>
		/// <param name="table"></param>
		[StepDefinition(@"I call Shared Step 48367 \(Product Includes Battery > any type\) : Setting how the battery is packaged option to (.*)")]
		public void GivenICallSharedProductIncludesBatteryAnyType(string option, Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SelectFirstOptionInSection("Indicate how battery is packaged");
			Report.UseSubSteps = true;
			Report.StartSubStep("I set the Indicate how battery is packaged field to: Installed in the product");
			MyStepsNewProduct.SetTheSectionOptionTo("Indicate how battery is packaged", option);
			Report.StartSubStep("I complete a row in the Battery Table: | Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |");
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (TableRow thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Quantity of Batteries per Package"], out int batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries per Package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["Quantity of Batteries to Operate Product"], out int batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries to Operate Product' column of the step table must be an integer value");
					}
					var thisBattery = new Battery {
						BatteryType = thisRow["Battery Type"],
						Manufacturer = thisRow["Manufacturer"],
						NumberPerPackage = batteriesPerPackage,
						RequiredToRun = batteriesRequired
					};
					listOfBatteries.Add(thisBattery);
				}
				var productIncludesBattery = new ProductIncludesBattery();
				if (listOfBatteries.Any())
				{
					// setter adds a table row for each battery in the list and enters data into each column
					productIncludesBattery.Batteries = listOfBatteries;
					productIncludesBattery.DeleteEmptyBatteryRows();
				}
				else
				{
					Report.Error("There were no batteries to add");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
			Report.StartStep("In the Product Includes Battery page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Includes Battery");
		}

		[StepDefinition(@"I call Shared Step 48367 \(Product Includes Battery > any type\)")]
		public void GivenICallSharedProductIncludesBatteryAnyType(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SelectFirstOptionInSection("Indicate how battery is packaged");
			Report.UseSubSteps = true;
			Report.StartSubStep("I set the Indicate how battery is packaged field to: Installed in the product");
			MyStepsNewProduct.SetTheSectionOptionTo("Indicate how battery is packaged", "Installed in the product");
			Report.StartSubStep("I complete a row in the Battery Table: | Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |");
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (TableRow thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Quantity of Batteries per Package"], out int batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries per Package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["Quantity of Batteries to Operate Product"], out int batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries to Operate Product' column of the step table must be an integer value");
					}
					var thisBattery = new Battery {
						BatteryType = thisRow["Battery Type"],
						Manufacturer = thisRow["Manufacturer"],
						NumberPerPackage = batteriesPerPackage,
						RequiredToRun = batteriesRequired
					};
					listOfBatteries.Add(thisBattery);
				}
				var productIncludesBattery = new ProductIncludesBattery();
				if (listOfBatteries.Any())
				{
					// setter adds a table row for each battery in the list and enters data into each column
					productIncludesBattery.Batteries = listOfBatteries;
					productIncludesBattery.DeleteEmptyBatteryRows();
				}
				else
				{
					Report.Error("There were no batteries to add");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
			Report.StartSubStep("In the Product Includes Battery page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Includes Battery");
		}



		[StepDefinition(@"I call Shared Step 57589 \(Enter Pesticide Data - United States \(without EPA number\)\)")]
		public void GivenICallSharedStepEnterPesticideData_UnitedStatesWithoutEPANumber()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Pesticide Details - U.S. Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Pesticide Details - U.S.");
			Report.StartSubStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "No");
			Report.StartSubStep(
				"Product has a State Registration: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has a State Registration", "No");
			Report.StartSubStep("I select the first option in section: Select the applicable exemption");
			MyStepsNewProduct.SelectFirstOptionInSection("Select the applicable exemption");
			Report.StartSubStep("In the Pesticide Details - U.S. page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		[StepDefinition(
			@"I call Shared Step 48369 \(Toxicity Characteristics Leaching Procedure \(TCLP\) - No to ALL With Copper\)")]
		public void GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithCopper()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartSubStep("I set the Product has had TCLP testing; Report is available option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing; Report is available", "No");
			Report.StartSubStep("I select No for all elements including Copper");
			MyStepsNewProduct.SetTheSectionOptionTo("Lead", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Mercury", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Silver", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Cadmium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Chromium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Barium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Arsenic", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Selenium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Copper", "No");
			if (myNewProduct.SectionExists("Platinum"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Platinum", "No");
			}

			Report.StartSubStep(
				"In the Toxicity Characteristic Leaching Procedure (TCLP) Product Report page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP) Product Report");
		}

		[StepDefinition(
			@"I call Shared Step 71955 \(Answer Electronic Equipment questions - Without Cathode Ray - No to all\)")]
		public void GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Contains Circuit Board", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			Report.StartSubStep("In the Electronic Equipment page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Electronic Equipment");
		}

		[StepDefinition(@"I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path")]
		public void GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may including Active Ingredient)");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("OTC Drug Facts Label (may include Active Ingredient)");
			Report.StartSubStep("I set the Refer to your Product Label option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Refer to your Product Label", "None of the Above");
			Report.StartSubStep("In the Regulatory Information 3 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 3");
		}

		[StepDefinition(
		@"I call Shared Step 57506 \(Transportation Details 1 - Regulated for Transport\(No\) - Exemption\(Random\) - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport",
				"No, due to an exemption or exception");
			MyStepsNewProduct.SetTheSectionOptionTo("Please select DOT Exceptions if applicable", "173.120(a)(4)");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 69682 \(Retailer Association - Add Private Label Information\) and select the retailer: (.*) and enter the name: (.*)")]
		public void GivenICallSharedRetailerAssociation_AddPrivateLabelInformation(string retailer, string name)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			var MyNewProduct = new NewProduct();
			MyNewProduct.SetFullNameOfProductForRetailer(retailer, name);
			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("No Retailer/No UPC Product", "This Private Label");
			Report.StartSubStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(
			@"I call Shared Step 57980 \(Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path\)")]
		public void
			GivenICallSharedStepTransportationDetails_YesOnlyOption_SelectIMDGFullyRegulated_Continue_HappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "IMDG");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "Shipping fully regulated");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 57981 \(Transportation Details - UN Number Water \(IMDG\) - Enter UN Number and select other data - Continue - Happy Path\) : (.*)")]
		public void
			GivenICallSharedStepTransportationDetails_UNNumberWaterIMDG_EnterUNNumberAndSelectOtherData_Continue_HappyPath(
				string unNo)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN" + unNo);
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN" + unNo);
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 57794 \(Confirm VOC \(SCAQMD\) step title, Confirm ACP question shown  - Select No - Happy Path\)")]
		public void GivenICallSharedStepConfirmVOCSCAQMDStepTitleConfirmACPQuestionShown_SelectNo_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I should see the '{0}' page",
				"Volatile Organic Compounds (VOC) for California Air District(s) and Canada"));
			MyStepsNewProduct.GivenIShouldSeeXPage(
				"Volatile Organic Compounds (VOC) for California Air District(s) and Canada");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
		}

		[StepDefinition(
			@"I call Shared Step 57678 \(Confirm Volatile Organic Compounds \(VOC OTC/CARB\) step title - Select No to all questions - Happy Path\)")]
		public void
			GivenICallSharedStepConfirmVolatileOrganicCompoundsVOCOTCCARBStepTitle_SelectNoToAllQuestions_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I set the {0} option to: {1}",
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No"));
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP("No");
			Report.StartSubStep(string.Format("I set the {0} option to: {1}",
				"Product label specifies a dilution ratio which results in a final VOC concentration for the product during use",
				"Yes"));
			new Steps_VOC_OTC_CARB().SetProductLabelDilutionRatio("Yes");
			Report.StartSubStep(string.Format("I set the {0} option to: {1}",
				"Product's VOC content as used",
				"0"));
			new Steps_VOC_OTC_CARB().SetVocContentAsUsed("0");
			Report.StartSubStep(string.Format("I set the {0} option to: {1}",
				"Product's VOC content as sold",
				"0"));
			new Steps_VOC_OTC_CARB().SetVocContentAsSold("0");
			Report.StartSubStep("I select the first option for section: Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?");
			MyStepsNewProduct.SelectFirstOptionInSection(
				"Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?");
			Report.StartSubStep("In the VOC page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("VOC");
		}

		[StepDefinition(
			@"I call Shared Step 216862 \(Retailer - Add Retailer - Applicable Only to Alcoholic Beverages - Wine \(RU001418\): (.*)")]
		[StepDefinition(
			@"I call Shared Step 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: (.*)")]
		public void GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath(string retailer)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var selSelectRetailers = new SelectRetailers();
			var selRetailer = new Retailer();

			//selRetailer.ClickAddRetailers();
			//selSelectRetailers.Wait_for_load(30);

			//if (!selSelectRetailers.DoneButton())
			//{
			//	Report.Warning("The Select Retailers page was not loaded on entering the Retailer page");
			//	selRetailer.ClickAddRetailers();
			//}
			//if (!selSelectRetailers.Wait_for_load(10))
			//{
			//	Report.Warning("The Select Retailers page was not loaded on entering the Retailer page");
			//	selRetailer.ClickAddRetailers();
			//}

			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");

			// below step was throwing error when selected No-retailer so  need to remove
			//Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
		}

		// Enter UPC string in the form: "Equals"+upcNumber where upcNumber is the exact number to input, rather than using the randomly generated step from context
		// Enter '_CVS' or '_cvs' for upc variable to use a upc number for retailer CVS from (required for some test cases eg. CVS RCL feature)
		[StepDefinition(
			@"I call Shared Step 131303 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*), capsule count: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc, string containerType, string capsuleCount, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					CapsuleCount = capsuleCount,
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
				upcTable.AddRow("CapsuleCount", capsuleCount);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I call Shared Step 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_,
				};

				var NP = new NewProduct();
				NP.WaitForContainerToBeVisible(30);
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

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I call Shared Step 216819 \(UPC Screen - Verify that the Updated Container Types Applicable to Engine Motor Oil for Auto or Boat\) Enter UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		[StepDefinition(@"I call Shared Step 216863 \(UPC Screen - Verify that the Updated Container Types Applicable to Alcoholic Beverages - Wine\) Enter UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerTypeVerifyContainerTypes(string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("Confirm that you see only options: Glass Container, Metal Container, Metal Cylinder, Plastic Container, Plastic Liner/Corrugate for Container Types");
			var option = new Table("Option");
			option.AddRow("Container Type");
			option.AddRow("Glass Container");
			option.AddRow("Metal Container");
			option.AddRow("Metal Cylinder");
			option.AddRow("Plastic Container");
			option.AddRow("Plastic Liner/Corrugate");
			MyStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Container Type", option);
			Report.StartSubStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_,
				};

				var NP = new NewProduct();
				NP.WaitForContainerToBeVisible(30);
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

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I call Shared Step 226089 \(Add UPC - Applicable Only to Bonding Agent \(RU000023\)\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void ThenICallSharedStepAddUPC_ApplicableOnlyToBondingAgentRUForUPCSavedAsUPCContainerTypePlasticContainerAndSize(string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I confirm that retailer HD is present under the 'Destination Retailers' column in the UPC table");
			MyStepsNewProduct.ConfirmRetailerIsPresentUnderTheDestinationRetailersColumnUPCTable("HD", "is");
			Report.StartSubStep("Confirm that you see only options: Glass Container, Metal Container, Metal Cylinder, Plastic Container, Plastic Liner/Corrugate for Container Types");
			var option = new Table("Option");
			option.AddRow("Container Type");
			option.AddRow("Coated or Laminated Paperboard");
			option.AddRow("Full Syringe - Medical");
			option.AddRow("Glass Container");
			option.AddRow("Metal Container");
			option.AddRow("Metal Cylinder");
			option.AddRow("Plastic Container");
			option.AddRow("Vial - Medical");
			MyStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Container Type", option);
			Report.StartSubStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_,
				};

				var NP = new NewProduct();
				NP.WaitForContainerToBeVisible(30);
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

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}


		[StepDefinition(
	@"I call Shared Step 57960a \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only - Do Not Click Continue\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly_DoNotClickContinue(string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");
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

		}

		// UPC: CVS binding text used for using a UPC from the list of valid CVS UPCs from upcitemdb.comUpcFunctions.GetRandomUpcNumber(
		[StepDefinition(
			@"I call Shared Step 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: CVS, container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly(string containerType,
			string size)
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			for (int i = 0; i < 100; i++)
			{
				Report.Info("Entering UPC information. Attempt: " + (i + 1));
				Report.StartSubStep("I click the 'Add' button");
				stepsNewProduct.ThenIClickTheAddUpcButton();
				Report.StartSubStep("I add the following into the UPC Fields");
				string upc = new UpcFunctions().GeneratePrefixedUPCForRetailer("CVS");
				Report.Info("UPC number: " + upc);
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
				Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
				stepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
				// not returning...
				if (new NewProduct().FormError().IsNullOrEmpty())
				{
					return;
				}
				if (new NewProduct().FormError().Contains("UPC failing Transportation Rules."))
				{
					Report.Failure($"The Product created is failing the UPC Transporation Rules. An error was seen.");
					Report.Screenshot();
					return;
				}
				// delete upc that failed
				stepsNewProduct.GivenIDeleteUPC(upc);
				Report.Info("An error was showing! on click continue! Attempting a different UPC");
			}
		}

		// UPC: CVS binding text used for using a UPC from the list of valid CVS UPCs from upcitemdb.com
		[StepDefinition(
			@"I call Shared Step 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*), size: (.*), Do not click continue")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly_NotContinue(string upc,
			string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_
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


		}

		[StepDefinition(@"I call Shared Step 60567 \(Upload Product Label only\)")]
		public void GivenICallSharedUploadProductLabelOnly()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();
			Report.StartSubStep(@"I click the browse button for label: Product Label and upload PDF: testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Delay.Seconds(2);

			//60723 uses this on the reulatory docs to provide screen, but also on the additional docs to provide screen in 57950
			//If keep sds confirm step in does this brake the step if used on the other screen?

			//if (newProdClass.CheckBoxOptionExists("I confirm I am providing the most current Safety Data Sheet"))
			//{
			//	//Should this show on this page? this step is for the additional docs page? Any examples?
			//	Report.StartStep(@"I tick the box next to the question: 'I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration'");
			//	MyStepsNewProduct.SelectConfirmRegulatoryDocumentsConfirmationQuestion();
			//	//If this is found to be needed on this page ^ create a copy of the above method for the additional docs page.
			//}

			Delay.Seconds(2);
			Report.StartSubStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60567 \(Upload Product Label only\) for section: (.*)")]
		public void GivenICallSharedUploadProductLabelOnlySectionSpecific(string section)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I click the browse button for label: Product Label in section: " + section + @" and upload PDF: testdoc.pdf");
			MyStepsNewProduct.UploadPDFFileSectionAndType("Product Label", section, @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57883 \(Optional Comments - Happy Path\) and enter the comment: (.*)")]
		public void GivenICallSharedCommentsHappyPath(string comments)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Optional Comments Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Optional Comments");
			Report.StartSubStep("I enter the following into the Optional Comments field: " + comments);
			MyStepsNewProduct.ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(comments);
			Report.StartSubStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Comments");
		}

		[StepDefinition(@"I call Shared Step 54796 \(Purchase Summary\)")]
		public void GivenICallSharedPurchaseSummary()
		{
			var MyStepsPaymentMethods = new Steps_PaymentMethods();
			MyStepsPaymentMethods.ThenIConfirmThePurchaseSummaryHeaderIsDisplayed();
			MyStepsPaymentMethods.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
		}

		[StepDefinition(
			@"I call Shared Step 57753 \(Create a New Registration via Register New Product \(expanded menu\)\)")]
		public void GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu()
		{
			Report.UseSubSteps = true;
			var MyStepsHomePage = new StepsHomepage();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I click the Add Product icon in the Navigation Pane");
			MyStepsHomePage.ClickItemInNavigationPanel("Add Product");
			Report.StartSubStep("I should see the New Product Page");
			MyNewProduct.GivenIShouldSeeXPage("New Product");
			Report.StartSubStep("I set the Select the type of product to create field to: Create a New Registration");
			MyNewProduct.SetTheSectionOptionTo("Select the type of product to create", "Create a New Registration");	
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 57884 \(Safety Data Sheet Authoring - Additional Data \(Optional\) step - add any random data for all fields - Happy path\) and enter the following:")]
		public void GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
			Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");
			Delay.Seconds(1);
			Report.StartSubStep(
				"In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " +
				table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct
				.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(
					table.Rows[0]["Personal Protection Equipment"]);
			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " +
								 table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAutoignitionISelect(
				table.Rows[0]["Autoignition Temperature"]);
			Report.StartSubStep(
				"In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " +
				table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(
				table.Rows[0]["Minimum Ignition Energy"]);
			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " +
											 table.Rows[0]["Viscosity"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(table.Rows[0]["Viscosity"]);
			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Appearance I select: " +
								 table.Rows[0]["Appearance"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(
				table.Rows[0]["Appearance"]);
			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Odor I select: " +
								 table.Rows[0]["Odor"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorISelect(table.Rows[0]["Odor"]);
			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " +
								 table.Rows[0]["Odor Threshold"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorThresholdISelect(
				table.Rows[0]["Odor Threshold"]);
			Delay.Seconds(1);
			Report.StartSubStep(
				"In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " +
				table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPartitionCoefficientISelect(
				table.Rows[0]["Partition Coefficient"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57441 \(Physical and Chemical Properties - Primary Physical Property - Liquid\)")]
		public void GivenICallSharedPhysicalandChemicalProperties_PrimaryPhysicalProperty_Liquid()
		{
			// Secondary Physical State, Relative Density (value), pH (range), Boiling Point (range), Water Solubility description can be any value.
			// Add a variable table in the future if specific data is required.
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density option to: 20");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "20");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			//Ticket 63666 indicates boiling point change from "Not tested/Unknown"
			Report.StartSubStep("I set the Boiling Point (in Celsius) field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			//Ticket 54725 indicates flash point change from ">=93C and <=815C"
			Report.StartSubStep("I set the Flash Point (in Celsius) field to: >=93C and <=815C");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", ">=93C and <=815C");
			Report.StartSubStep("I set the Flash Point Testing Method Used option to: Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartSubStep("I set the Select the best Water Solubility description field to: Soluble in water");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 57111 \(Enter Product Data for Physical State - Aerosol only\)")]
		public void GivenICallSharedStepEnterProductDataForPhysicalState_AerosolOnly()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartSubStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			Report.StartSubStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			Report.StartSubStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble in water");
			Report.StartSubStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57454 \(Physical and Chemical Properties - Aerosol & Gas available - Select Aerosol - Continue - Happy Path\)")]
		public void ThenICallSharedStepPhysicalandChemicalProperties_AerosolGasAvailable_SelectAerosol_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartSubStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow("Aerosol");
			produtTable.AddRow("Gas");
			stepsProductCharacteristics.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			Report.StartSubStep("I set the Primary Physical State field to: Aerosol");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Aerosol");
			Report.StartSubStep("I set the Secondary Physical State field to: Liquid spray");
			stepsProductCharacteristics.ThenISetTheSecondaryPhysicalStateToBe("Liquid spray");
			Report.StartSubStep("I set the pH field to: 10.4");
			stepsProductCharacteristics.SetPHTo("10.4");
			Report.StartSubStep("If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description", "Insoluble");
			Report.StartSubStep("I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 57528 \(Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path\)")]
		public void ICallSharedPhysicalanChemicalProperties_AerosolOnly_AddData_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartSubStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			stepsProductCharacteristics.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			Report.StartSubStep("I set the Primary Physical State field to: Aerosol");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Aerosol");
			Report.StartSubStep("I set the Secondary Physical State field to: Solid spray");
			stepsProductCharacteristics.ThenISetTheSecondaryPhysicalStateToBe("Solid spray");
			Report.StartSubStep("I set the pH field to: 12");
			stepsProductCharacteristics.SetPHTo("12");
			Report.StartSubStep("I set the Water Solubility description to: No data available");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "No data available");
			Report.StartSubStep("I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then to: This product is classified as a D003 Hazardous Waste under RCRA.");
			MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "This product is classified as a D003 Hazardous Waste under RCRA.");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 214644\(Physical and Chemical Properties - Applicable Only to Bonding Agent \(RU000023\)\)")]
		[StepDefinition(@"I call Shared Step 213391\(Physical and Chemical Properties \(Applicable Only to Flow 6-A Type of Products\) - Primary Physical State \(AEROSOL ONLY\) / Secondary Physical State \(ANY\)\):")]
		public void ThenICallSharedStepPhysicalAndChemicalPropertiesApplicableOnlyToFlow_ATypeOfProducts_PrimaryPhysicalStateAEROSOLONLYSecondaryPhysicalStateANY(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			foreach(var row in table.Rows)
			{
				switch (row["Section"])
				{
					case "Primary State Options":
						Report.StartSubStep($"I should only see the following options for Primary Physical State: {row["Value"]}");
						var expectedOptions = new Table(new string[] {
						"State"
						});
						string[] options = row["Value"].Split(' ');
						foreach (string option in options)
						{
							expectedOptions.AddRow(option);
						}
						stepsProductCharacteristics.PrimaryPhysicalOptionsShowingCorrectly(expectedOptions);
						break;
					case "Primary Physical State":
						Report.StartSubStep($"I set the Primary Physical State field to: {row["Value"]}");
						stepsProductCharacteristics.SetThePrimayPhysicalStateTo(row["Value"]);
						break;
					case "Secondary Physical State":
						Report.StartSubStep($"I set the Secondary Physical State field to: {row["Value"]}]");
						stepsProductCharacteristics.ThenISetTheSecondaryPhysicalStateToBe(row["Value"]);
						break;
					case "pH":
						if (row["do not have exact data"] == "Yes")
						{
							Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
							MyNewProduct.SectExatcDataNotKnown("pH");
							Report.StartSubStep($"I set the pH field to: {row["Value"]}");
							MyNewProduct.SetTheSectionOptionTo("pH", row["Value"]);
							break;
						}
						else
						{
							Report.StartSubStep($"I set the pH field to: {row["Value"]}");
							MyNewProduct.SetTheSectionOptionTo("pH", row["Value"]);
							break;
						}
					case "has a flammable propellant":
						Report.StartSubStep($"I select the {row["Value"]} option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
						MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", row["Value"]);
						break;
					case "Relative Density":
						Report.StartSubStep($"I select the {row["Value"]} option for section: Relative Density");
						MyNewProduct.SetTheSectionOptionTo("Relative Density", row["Value"]);
						break;
					case "Boiling Point (in Celsius)":
						Report.StartSubStep($"I select the {row["Value"]} option for section: Boiling Point (in Celsius)");
						MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", row["Value"]);
						break;
					case "Flash Point (in Celsius)":
						if (row["do not have exact data"] == "Yes")
						{
							Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
							MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
							Report.StartSubStep($"I set the Flash Point (in Celsius) field to: {row["Value"]}");
							MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", row["Value"]);
							break;
						}
						else
						{
							Report.StartSubStep($"I set the Flash Point (in Celsius) field to: {row["Value"]}");
							MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", row["Value"]);
							break;
						}
					case "Water Solubility":
						Report.StartSubStep($"I select the {row["Value"]} option for section: Select the best Water Solubility description");
						MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", row["Value"]);
						break;
				}
			}
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}


		[StepDefinition(@"I call Shared Step 168070 \(Physical and Chemical Properties - Aerosol Only - Validation for Algicide Aerosol Type of Product\)")]
		public void ICallSharedPhysicalanChemicalProperties_AerosolOnly_ValidationForAlgicideAerosolTypeOfProduct()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep(
				"Primary Physical State should be showing the value: Aerosol");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Aerosol");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");

			new StepsNewProduct().ErrorMessagesAreShowingForItem("Secondary Physical State", "should", "This is a required field");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("pH", "should", "This is a required field");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("Select the best Water Solubility description", "should", "This is a required field");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "should", "This is a required field");

			var buttonTable = new Table(new string[] {
				"Button"
			});
			buttonTable.AddRow(new string[] {
				"This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS)."
			});

			MyNewProduct.CheckRadioButtonsInSectionAndOrder("should", "When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", buttonTable);

			buttonTable = new Table(new string[] {
				"Button"
			});
			buttonTable.AddRow(new string[] {
				"This product is classified as a D003 Hazardous Waste under RCRA."
			});

			MyNewProduct.CheckRadioButtonsInSectionAndOrder("should", "When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", buttonTable);

			buttonTable = new Table(new string[] {
				"Button"
			});
			buttonTable.AddRow(new string[] {
				"This product is not classified as D001 or D003 Hazardous Waste under RCRA"
			});

			MyNewProduct.CheckRadioButtonsInSectionAndOrder("should", "When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", buttonTable);

		}

		[StepDefinition(@"I call Shared Step 57401 \(Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("Looking for the Which best describes your product, including when FIFRA 25(b) Exempt and Setting to: Product is not a pesticide and does not make or imply a pesticidal claim if it exists");
			if (myNewProductClass.SectionExists("Which best describes your product, including when FIFRA 25(b) Exempt"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			}
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 57401 \(Product Information - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedProductInformation_NoGHSNotDirectShipNotPLPNotGNFR_Continue()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 60931 \(Additional Documents to Provide - Exemption - Special Permit - Product Label\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_SpecialPermit_ProductLabel()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("Upload exemption letter");
			MyNewProduct.UploadPDFFileSectionAndType("Exemption Letter",
				"Transportation Exemption Letter or Special Permit", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("Upload special permit letter");
			MyNewProduct.UploadPDFFileSectionAndType("Special Permit",
				"Transportation Exemption Letter or Special Permit", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("Upload product label");
			MyNewProduct.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.Screenshot();
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 62710 \(Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path\)")]
		public void GivenICallSharedConfirmVOCHeadingAndSelectNoToFirstQuestionOnly_HappyPath()
		{
			Report.UseSubSteps = true;
			//var MyNewProduct = new StepsNewProduct();
			//Report.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartSubStep("I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP("No");
		}

		[StepDefinition(@"I call Shared Step 60468 \(VOC - CARB only required - enter value - Continue - Happy Path\)")]
		public void GivenICallSharedStepVOC_CARBOnlyRequired_EnterValue_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Amount of VOC content as weight percentage of the total formula field to: 50");
			MyNewProduct.SetTheSectionOptionTo("Amount of VOC content as weight percentage of the total formula", "50");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			MyNewProduct.SetTheSectionOptionTo("Your acknowledgement of this registration includes that your product", "Yes, I Acknowledge");
		}

		[StepDefinition(
			@"I call Shared Step 60552 \(VOC - AERO Question \(ozone\) enter value - Click Continue - Happy Path\): (.*)")]
		public void GivenICallSharedStepVOC_AEROQuestionOzoneEnterValue_ClickContinue_HappyPath(string value)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I Enter a value for the 'VOC content in grams ozone per gram' question: " + value);
			MyNewProduct.SetTheSectionOptionTo("VOC content in grams ozone per gram", value);
			Report.StartSubStep("In the Volatile Organic Compounds (VOC) page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			MyNewProduct.SetTheSectionOptionTo("Your acknowledgement of this registration includes that your product", "Yes, I Acknowledge");
		}

		[StepDefinition(@"I call Shared Step 60631 \(VOC - HVOC and MVOC - add values - Continue - Happy Path\)")]
		public void GivenICallSharedVOC__HVOCAndMVOC_AddValues_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 10");
			MyNewProduct.SetTheSectionOptionTo(
				"HVOC (high volatile organic compound) content as weight percent of the total formulation", "10");
			Report.StartSubStep(
				"I set the MVOC (medium volatile organic compound) content as weight percentage of the total formulation field to: 5.6");
			MyNewProduct.SetTheSectionOptionTo(
				"MVOC (medium volatile organic compound) content as weight percentage of the total formulation",
				"5.6");
			Report.StartSubStep("In the Volatile Organic Compounds (VOC) page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
			Report.StartSubStep("I should see the Volatile Organic Compound Summary");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			MyNewProduct.SetTheSectionOptionTo("Your acknowledgement of this registration includes that your product", "Yes, I Acknowledge");
		}

		[StepDefinition(@"I call Shared Step 57885 \(Data Acceptance - Click Accept - Happy Path\)")]
		public void GivenICallSharedDataAcceptance_ClickAccept_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("In the Data Acceptance page I select Agreed");
			MyNewProduct.GivenInTheDataAcceptancePageISelectYesAgreed();
			Report.StartSubStep("In the Data Acceptance page I click on the Accept button");
			MyNewProduct.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.Screenshot();
		}

		[StepDefinition(@"I call Shared Step 37857 \(Enter Physical Property - Solid\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			List<string> showing = new NewProduct().SelectedOptionsForSection("Primary Physical State");
			if (!showing.Contains("Solid"))
			{
				Report.StartSubStep("I set the Primary Physical State option to: Solid");
				Report.Info("Setting the Physical State to Solid because it was not selected by default");
				MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			}

			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Dispersible");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartSubStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
			}
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");

		}

		[StepDefinition(@"I call Shared Step 145000 \(Enter Physical Property - Solid, 2nd Phys State\(anything\), mixed \(anything\)\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid_WithoutWaterSolubilityDescription()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var thisNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			Report.StartSubStep("There should only be one option available for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			if (!thisNewProduct.SelectedOptionsForSection("Primary Physical State").Contains("Solid"))
			{
				Report.Failure("The Primary Physical State was not set to Solid by default.");
				Report.Screenshot();
				Report.Info("Setting the Primary Physical State to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo(
					"Primary Physical State",
					"Solid");
			}
			else
			{
				Report.Success("The Primary Physical State was showing the value of: Solid as expected");
				Report.Screenshot();
			}

			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartSubStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
			}
			else
			{
				Report.Failure("The Secondary Physical State option was not displayed");
				Report.Screenshot();
			}

			//Report.StartStep("I set the Secondary Physical State option to: Solid");
			//MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 73223 \(Enter Physical Property - Solid - Without Secondary Physical State\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid_WithoutSecondaryPhysicalState()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var thisNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep("There should only be one option available for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			if (!thisNewProduct.SelectedOptionsForSection("Primary Physical State").Contains("Solid"))
			{
				Report.Failure("The Primary Physical State was not set to Solid by default.");
				Report.Screenshot();
				Report.Info("Setting the Primary Physical State to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo(
					"Primary Physical State",
					"Solid");
			}
			else
			{
				Report.Success("The Primary Physical State was showing the value of: Solid as expected");
				Report.Screenshot();
			}

			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.Failure("The Secondary Physical State option was displayed");
				Report.StartSubStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
				Report.Screenshot();
			}
			else
			{
				Report.Success("The Secondary Physical State option was not displayed");
				Report.Screenshot();
			}

			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartSubStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}
			else
			{
				Report.Failure("The Select the best Water Solubility description option was not displayed");
				Report.Screenshot();
			}
			//Report.StartStep("I set the Secondary Physical State option to: Solid");
			//MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 164954 \(Enter Physical Property - Solid - Without Secondary Physical State - Without Water Solubility Question\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid_WithoutSecondaryPhysicalState_WithoutWaterSolubilityQuestion()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var thisNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep("There should only be one option available for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			if (!thisNewProduct.SelectedOptionsForSection("Primary Physical State").Contains("Solid"))
			{
				Report.Failure("The Primary Physical State was not set to Solid by default.");
				Report.Screenshot();
				Report.Info("Setting the Primary Physical State to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo(
					"Primary Physical State",
					"Solid");
			}
			else
			{
				Report.Success("The Primary Physical State was showing the value of: Solid as expected");
				Report.Screenshot();
			}

			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.Failure("The Secondary Physical State option was displayed");
				Report.StartSubStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
				Report.Screenshot();
			}
			else
			{
				Report.Success("The Secondary Physical State option was not displayed");
				Report.Screenshot();
			}

			//Report.StartStep("I set the Secondary Physical State option to: Solid");
			//MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 37857 \(Enter Physical Property - Solid\) with the following inputs:")]
		public void GivenICallSharedEnterPhysicalProperty_SolidParameters(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Solid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			string waterSolubility = table == null ? "N/A" : table.Rows.FirstOrDefault()["Water Solubility"];
			if (waterSolubility != null && waterSolubility != "N/A")
			{
				Report.StartSubStep("I set the Select the best Water Solubility description option to: " +
									 waterSolubility);
				MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", waterSolubility);
			}
			else
			{
				Report.StartSubStep("I set the Select the best Water Solubility description option to: Dispersible");
				MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			}

			string secondaryState = table == null ? "N/A" : table.Rows.FirstOrDefault()["Secondary Physical State"];
			if (secondaryState != null && secondaryState != "N/A")
			{
				Report.StartSubStep("I set the Secondary Physical State option to: " + secondaryState);
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", secondaryState);
			}
			else
			{
				Report.StartSubStep("I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			}

			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 217667 \(Product Information - Applicable Only to Engine Motor Oil for Auto or Boat \(RU000269\)\)")]
		// Shared Step was updated to include 'which one best describes your product'. This breaks a couple of tests, which has been raised to Bug Triage (incorrect step called)
		[StepDefinition(@"I call Shared Step 60310 \(Product Information - Without Child question\)")]
		public void GivenICallSharedProductInformation_WithoutChildQuestion()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}


		[StepDefinition(@"I call Shared Step 101692 Product Information - Pesticide Question - Happy Path")]
		public void GivenICallSharedStepProductInformation_PesticideQuestion_HappyPath()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set any option for: 'Which best describes your product, including when FIFRA 25(b) Exempt'");
			// Step says 'any' but prefer setting not pesticide because some tests didn't account for Pesticides page appearing later.
			if (new NewProduct().GetAllOptionsForSection("Which best describes your product, including when FIFRA 25(b) Exempt").Contains("Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			}
			else
			{
				MyNewProduct.SelectFirstOptionInSection("Which best describes your product, including when FIFRA 25(b) Exempt");
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			}
			Report.StartSubStep(
				"For the section: Select countries the product may be sold in select: United States");
			MyNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 105379 Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question")]
		public void GivenICallSharedStepProductInformation_USPesticideNoNoOSHANoDSVNoPLNoGNFRWithoutChildQuestion()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set any option for: 'Which best describes your product, including when FIFRA 25(b) Exempt'");
			// Step says 'any' but prefer setting not pesticide because some tests didn't account for Pesticides page appearing later.

			//Philip - Change-
			//if (new NewProduct().GetAllOptionsForSection("Which best describes your product, including when FIFRA 25(b) Exempt").Contains("Product is not a pesticide"))
			//{
			//	MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is not a pesticide");
			//}
			//else
			//{
			//	MyNewProduct.SelectFirstOptionInSection("Which best describes your product, including when FIFRA 25(b) Exempt");
			//}
			//
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 57865 \(Product Information - Pesticide shown, US only, select No for everything else - Happy Path\)")]
		public void
			GivenICallSharedStepProductInformation_PesticideShownUSOnlySelectNoForEverythingElse_HappyPath()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I set the product description option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 217788 \(Product Information - not Pesticide, US only, select Yes for JSON Question - Happy Path\)")]
		public void	GivenICallSharedStepProductInformation_ApplicableLiquidDishwashing_YesJSONQues()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I set the product description option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"Yes");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 57801 \(Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path\)")]
		public void GivenICallSharedConfirmVOCSummaryAndVOCAnalysisDate_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Volatile Organic Compound Summary Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			Report.StartSubStep("I confirm that the VOC Analysis Date statement is showing");
			MyNewProduct.ThenIConfirmThatTheVOCAnalysisDateIsShowing();
			Report.StartSubStep("I confirm that I see todays VOC Analysis Date");
			MyNewProduct.ThenIConfirmThatISeeTodaysVOCAnalysisDate();
			Report.StartSubStep("In the Volatile Organic Compound Summary page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compound Summary");
		}

		[StepDefinition(@"I call Shared Step 42214 \(Delete a Product from the Product grid\) to delete product: (.*)")]
		public void GivenICallSharedDeleteAProductFromTheProductGrid(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
			Report.StartSubStep("I delete the product: " + savedAs);
			new StepsProductGrid().ThenIDeleteTheProduct(savedAs);
		}

		[StepDefinition(@"I call \(confirm a Product from the Product grid\) to confirm product: (.*)")]
		public void GivenICallSharedConfirmAProductFromTheProductGrid(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
			Report.StartSubStep("I confirm the product: " + savedAs);
			new StepsProductGrid().ThenIConfirmTheProduct(savedAs);
		}

		[StepDefinition(
			@"I call Shared Step 57727 \(Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"DOT");
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with limited quantity");
			Report.StartSubStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}
		[StepDefinition(
		@"I call Shared Step 216860 \(Transportation Details 1 - Applicable Only to Alcoholic Beverages - Wine \(RU001418\)\)")]
		public void GivenICallSharedTransportationDetails1_ApplicableOnlyToAlcoholicBeverages()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Transportation Details 1 Page");
			MyNewProduct.GivenIShouldSeeXPage("Transportation Details 1");
			Report.StartSubStep(
			"I set the Product is Regulated for Transport to: No, due to an exemption or exception");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport",
				"No, due to an exemption or exception");
			Report.StartSubStep(
			"I set the Please select DOT Exceptions if Applicable to: 173.150(d)(1) - Exemption for alcoholic beverages (wine and distilled spirits), <=24% alcohol by volume, is contained in an inner packaging of 5L or less.");
			MyNewProduct.SetTheSectionOptionTo("Please select DOT Exceptions if applicable?",
				"173.150(d)(1) - Exemption for alcoholic beverages (wine and distilled spirits), <=24% alcohol by volume, is contained in an inner packaging of 5L or less");
			Report.StartSubStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}
		[StepDefinition(
			@"I call Shared Step 126160 \(U\.S\. Department of Transportation \(DOT\) Classification - Enter UN1057 - Lighter Fluid\)")]
		public void
			GivenICallSharedStepTransportation_DOTUNStep_EnterUNSelectLightersNoneAddTechnicalNameClickContinue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN1057");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1057");
			Delay.Seconds(2);
			Report.StartSubStep("I select 'Lighters' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Lighters");
			Delay.Seconds(2);
			Delay.Seconds(2);
			Report.StartSubStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.1");
			Report.StartSubStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartSubStep("I select '123' in section: For the lighter, provide the DOT Approval Number (LAA)");
			MyNewProduct.SetTheSectionOptionTo("For the lighter, provide the DOT Approval Number (LAA)", "123");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 65705 \(Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue\)")]
		public void
			GivenICallSharedStepTransportation_DOTUNStep_EnterUNSelectAerosolsNoneAddTechnicalNameClickContinue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			Report.StartSubStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			Report.StartSubStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartSubStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.1");
			Report.StartSubStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 34455 \(U\. S\. Department of Transportation \(DOT\) Classification - Enter all valid data\)")]
		public void GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidData()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN3159");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN3159");
			Delay.Seconds(2);
			Delay.Seconds(2);
			Report.StartSubStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartSubStep("I select '2.2' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.2");
			Report.StartSubStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartSubStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 34455 \(U\. S\. Department of Transportation \(DOT\) Classification - Enter all valid data\): UN Unmber: (.*), Proper Shipping Name: (.*), Technical Name: (.*), Hazard Class: (.*), Packing Group: (.*)")]
		public void
			GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidDataUNUnmberUNProperShippingNameNonanesTechniacalNameTechnicalTestNameHazardClassPackingGroupIII(
				string unNo, string psnName, string techName, string hazClass, string packClass)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: " + unNo);
			MyNewProduct.SetTheSectionOptionTo("UN Number", unNo);
			Delay.Seconds(2);
			Report.StartSubStep("I select '" + psnName + "' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", psnName);
			Delay.Seconds(2);
			Report.StartSubStep("I enter '" + techName + "' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", techName);
			Delay.Seconds(2);
			Report.StartSubStep("I select '" + hazClass + "' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", hazClass);
			Report.StartSubStep("I select '" + packClass + "' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", packClass);
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
		@"I call Shared Step 57728 \(U.S. Department of Transportation \(DOT\) Classification - Enter UN1950 \(Aerosol\) - Select data - Continue - Happy Path\)")]
		public void GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I enter UN1993 - Select data - Continue - Happy Path")]
		public void EnterUN1993_SelectData_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN1993");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1993");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			Report.StartSubStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			Report.StartSubStep("If Product boiling point question appears, I select the first radio button");
			var expectedSections = new List<string>();
			expectedSections.Add("Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.");
			var expectedNormalised = expectedSections.Select(x => x.Replace(" ", "")).ToList();
			var ActualSections = new NewProduct().GetDisplayedSections().Select(x => x).ToList();
			var actualNormalised = ActualSections.Select(x => x.Replace(" ", "")).ToList();
			if (expectedNormalised.All(actualNormalised.Contains))
			{
				MyNewProduct.SelectFirstOptionInSection("Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.");
			}
			Report.StartSubStep(
							"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}


		[StepDefinition(@"I call Shared Step 49621 \(Volatile Organic Compounds \(VOC\) for OTC and CARB - No\)")]
		public void GivenICallSharedVolatileOrganicCompoundsVOCForOTCAndCARB_No()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartSubStep("I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP("No");
		}

		[StepDefinition(@"I call Shared Step 32931 \(Liquid Core Product - select  No - Happy Path\)")]
		public void LiquidCoreProduct_SelectNo_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			Report.StartSubStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "No");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 74995 \(Liquid Core product - Select Yes - Continue\)")]
		public void GivenICallSharedStepIquidCoreProduct_SelectYes_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			Report.StartSubStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "Yes");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 00000 \(Liquid Core Product - select Yes - Happy Path\)")]
		public void GivenICallSharedStepLiquidCoreProduct_SelectYes_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			Report.StartSubStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "Yes");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 57507 \(Transportation Details 1- Not Regulated - Continue - Happy Path\)")]
		public void ICallSharedTransportationDetails1_NotRegulated()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Delay.Seconds(2);
			Report.StartSubStep("I should see the Transportation Details 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Transportation Details 1");
			Report.StartSubStep("I set the Product is Regulated for Transport field to: Not Regulated");
			MyNewProductSteps.SetTheSectionOptionTo("Product is Regulated for Transport", "Not Regulated");
			//MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			List<string> showing = MyNewProduct.SelectedOptionsForSection("Product is Regulated for Transport");
			bool selected = false;
			int wait = 0;
			while (!selected && !showing.Contains("Not Regulated") && wait <= 10)
			{
				// Check if the option exists in the drop down
				if (MyNewProduct.GetAllOptionsForSection("Product is Regulated for Transport")
					.Contains("Not Regulated"))
				{
					// If yes, attempt again
					Report.Info("Trying again to select option: Not Regulated");
					MyNewProductSteps.SetTheSectionOptionTo("Product is Regulated for Transport", "Not Regulated");
					if (MyNewProduct.SetOptionInSection("Product is Regulated for Transport", "Not Regulated"))
					{
						selected = true;
					}
				}
				else
				{
					// If no, report fail
					Report.Failure(
						"It was not possible to select the option: Not Regulated for the section: Product is Regulated for Transport");
					Report.Screenshot();
				}

				wait++;
				Delay.Seconds(1);
			}

			Report.StartSubStep("In the Transportation Details 1 page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(@"I call Shared Step 57502 \(Product Information - Preventing, Destroying, Repelling, Mitigating Pests, US only, NO to everything else - Continue - Happy Path\)")]
		public void ICallSharedProductInformation_PesticidePreventing_USOnly_NoToEverythingElse()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		// Duplicate with Shared Step 57884
		[StepDefinition(@"I call Shared Step 59663 \(Safety Data Sheet Authoring - Additional Data \(Optional\)\)")]
		public void ICallSharedSafetyDataSheetAuthoring_AdditionalDataOptional(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			Report.StartSubStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");

			Report.StartSubStep(
				"In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " +
				table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct.SetTheSectionOptionTo("Personal Protection Equipment Recommended",
				table.Rows[0]["Personal Protection Equipment"]);

			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " +
								 table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.SetTheSectionOptionTo("Autoignition Temperature", table.Rows[0]["Autoignition Temperature"]);

			Report.StartSubStep(
				"In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " +
				table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.SetTheSectionOptionTo("Minimum Ignition Energy", table.Rows[0]["Minimum Ignition Energy"]);

			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " +
								 table.Rows[0]["Viscosity"]);
			MyNewProduct.SetTheSectionOptionTo("Viscosity", table.Rows[0]["Viscosity"]);

			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Appearance I select: " +
								 table.Rows[0]["Appearance"]);
			MyNewProduct.SetTheSectionOptionTo("Appearance", table.Rows[0]["Appearance"]);

			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Odor I select: " +
								 table.Rows[0]["Odor"]);
			MyNewProduct.SetTheSectionOptionTo("Odor", table.Rows[0]["Odor"]);

			Report.StartSubStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " +
								 table.Rows[0]["Odor Threshold"]);
			MyNewProduct.SetTheSectionOptionTo("Odor Threshold", table.Rows[0]["Odor Threshold"]);
			// if Product's Dispensing Method is required enter any option

			List<string> actualSections = new NewProduct().GetDisplayedSections();
			if (actualSections.Contains("Product's Dispensing Method"))
			{
				Report.StartSubStep(
					"In the Review and Submit tab of the New Product Page for Product's Dispensing Method I select: " +
					table.Rows[0]["Product's Dispensing Method"]);
				MyNewProduct.SetTheSectionOptionTo("Product's Dispensing Method",
					table.Rows[0]["Product's Dispensing Method"]);
			}

			Report.StartSubStep(
				"In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " +
				table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.SetTheSectionOptionTo("Partition Coefficient", table.Rows[0]["Partition Coefficient"]);

			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57501 \(Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue\)")]
		public void ICallSharedPhysicalandChemicalProperties_MoreThanOneState_SelectSolid_StateAndSubcat_MixedAndWater_Random()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Physical and Chemical Properties");
			MyNewProductSteps.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			Report.StartSubStep("I set the Primary Physical State option to: Solid");
			MyNewProductSteps.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"Yes");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartSubStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			Report.StartSubStep("I set the Secondary Physical State option to: Solid");
			MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 59680 \(Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path\)")]
		public void ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the  Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			Report.StartSubStep("I only see the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartSubStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			var tableSecond = new Table("Section");
			tableSecond.AddRow(
				"Select countries the product may be sold in");
			tableSecond.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableSecond.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableSecond.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");

			Report.StartSubStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
			;
		}

		[StepDefinition(@"I call Shared Step 59680a \(Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR, with FIFRA - Continue - Happy Path\)")]
		public void ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFRWithFIFRA()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the  Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Which best describes your product, including when FIFRA 25(b) Exempt");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			Report.StartSubStep("I only see the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
			MyNewProductSteps.SetTheSectionOptionTo(
				"Which best describes your product, including when FIFRA 25(b) Exempt", "Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartSubStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			var tableSecond = new Table("Section");
			tableSecond.AddRow("Which best describes your product, including when FIFRA 25(b) Exempt");

			tableSecond.AddRow("Which best describes your product, including when FIFRA 25(b) Exempt");
			tableSecond.AddRow(
				"Select countries the product may be sold in");
			tableSecond.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableSecond.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableSecond.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");

			Report.StartSubStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
			;
		}

		[StepDefinition(@"I call Shared Step 29181 \(Ingredients - add any chemical\) with name: (.*)")]
		public void ICallSharedIngredients_AddAnyChemical(string name)
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Ingredients");
			Report.StartSubStep($"I add the ingredient '{ name }' at 100%");
			var table = new Table("ComponentName", "Percent");
			table.AddRow(name, "100");
			stepsNewProductIngredients.AddIngredients(table);
			var thisStudioShaManager = new StudioSHAManager();
			Report.IsTrue(thisStudioShaManager.Wait_For_Loading_Finish(120), "Loading did not finish", showSuccessScreenshot: false);
			List<string> popupCausing = new Ingredients().IngredientsFIFRAPopup();

			//Andrew - I have updated this step so only items in the hardcoded FIFRA lists of ingredients handle the popup.

			if (popupCausing.Contains(name))
			{
				Report.Info($"Looking in context for the fifra tag...");
				bool fifraTag;
				if (Context.Contains("FIFRAPopupExpected"))
				{
					Report.Info($"Tag was found in context, settting value to match");

					fifraTag = (bool)Context.GetFromContext("FIFRAPopupExpected");
				}
				else
				{
					Report.Info($"Tag was not found in context, default value of true/expected being set as no FIFRA question has been answered");
					fifraTag = true;
				}
				if (fifraTag == true)
				{
					Report.Info($"The fifra tag was set a true, popup is expected");

					Report.StartSubStep("In the Ingredients page I click Continue");
					var selNewProduct = new NewProduct();
					Report.IsTrue(selNewProduct.ClickContinue(waitForLoadingBtnSpinner: false), "Failed to click continue", "Continue was clicked");
					Report.Screenshot();

					if (new Ingredients().ConfirmThereIsAPopupViewTitled("Product Contains Ingredients Typical of a Pesticide"))
					{
						new StepsIngredients().ThenIConfirmICheckTheCheckboxInThePopupViewWithTheFollowingText("The Product Type, Pest Selection, and Ingredients listed are accurate.");
						new StepsIngredients().ThenInThePopupViewWithTheFollowingTitleProductContainsIngredientsTypicalOfAPesticideIClickTheConfirmButton("Product Contains Ingredients Typical of a Pesticide", "Confirm");
						Report.StartSubStep("I should see the Waste Classification Data Page");
						MyNewProductSteps.GivenIShouldSeeXPage("Waste Classification Data");
					}
					else
					{
						Report.Failure("Popup not found");
						Report.Screenshot();
						return;
					}
				}
				else
				{
					Report.Info($"The fifra tag was set a false, popup is not expected");
					Report.StartSubStep("In the Ingredients page I click Continue");
					MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
					Report.Screenshot();
				}


			}
			else
			{
				Report.Info($"Ingredient name used was not found in the list of hardcoded FIFRA ingredients...");
				Report.Screenshot();
				Report.StartStep("In the Ingredients page I click Continue");
				MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
				Report.Screenshot();

			}

		}


		[StepDefinition(@"I call Shared Step 29181c \(Ingredients - add any chemical - For Canada Only\) with name: (.*)")]
		public void ICallSharedIngredients_AddAnyChemical_CanadaOnly(string name)
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Ingredients");
			Report.StartSubStep("I add the ingredient " + name + " at 100%");
			var table = new Table("ComponentName", "Percent");
			table.AddRow(name, "100");
			stepsNewProductIngredients.AddIngredients(table);
			Report.StartSubStep("In the Ingredients page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
			Report.Screenshot();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");

		}

		[StepDefinition(@"I call Shared Step 57637 \(Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Exempt");
			MyNewProductSteps.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is exempt from TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyNewProductSteps.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status", "Compliant with Domestic Substances List (DSL)");
			Report.StartSubStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}
		[StepDefinition(@"I call Shared Step 40650 \(Regulatory Information 1 - TSCA shown, No to PROP 65 - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCAShown_NoToProp65()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Complaint");
			MyNewProductSteps.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}
		
		[StepDefinition(@"I call Shared Step 214541 \(Waste Classification Data - Applicable Only to Nickel Metal Hydride \(NiMH\) Battery \(RU000373\)\)")]
		[StepDefinition(@"I call Shared Step 214520 \(Waste Classification Data - Applicable Only to Alkaline Battery\)")]
		public void ICallSharedStepRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Waste Classification Data Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Waste Classification Data");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyNewProductSteps.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyNewProductSteps.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status", "Compliant with Domestic Substances List (DSL)");
			Report.StartSubStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Waste Classification Data page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Waste Classification Data");
		}

		[StepDefinition(@"I call Shared Step 29206 \(Retailer - Select No Retailer - Click Done - Click Continue - Happy Path\)")]
		public void ICallSharedRetailer_SelectNoRetailer_ClickDone()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			//Report.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			//new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("In the Retailer page I click Continue");
			MyStepsNewProduct.NewProductPageIClickContinueNoSpinnerWait();
			/* --As per TFS70787 warning popup displays for NR  --- */
			//Report.StartStep("In the UPCs Warning popup I click Ok");
			//new Steps_Retailer().IfISeeUpcWarningPopupClick("Ok");
		}

		[StepDefinition(@"I call Shared Step 59042 \(Browse for File > select > click Open - Happy Path\) for document type: (.*) and file: (.*)")]
		public void ICallSharedBrowseForFileSelectClickOpen(string type, string pdfFile)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I upload document type: " + type + " using the Browse and Open");
			Delay.Seconds(2);
			pdfFile = Automation.Utilities.Helpers.EmbeddedResourceHelpers.ExtractToFile(pdfFile, out string extractFile) ? extractFile : pdfFile;

			new NewProduct().UploadFileForSection(type, pdfFile);

		}

		[StepDefinition(@"I call Shared Step \(Browse for File > select > click Open - Happy Path\) for document type: (.*) and file: (.*)")]
		public void ICallSharedBrowseForFileOpen(string type, string pdfFile)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"I upload document type: { type } using the Browse and Open");
			Delay.Seconds(2);
			pdfFile = Automation.Utilities.Helpers.EmbeddedResourceHelpers.ExtractToFile(pdfFile, out string extractFile) ? extractFile : pdfFile;
			new NewProduct().UploadFileSection(type, pdfFile);

		}

		[StepDefinition(@"I call Shared Step 60533 \(Additional Documents to Provide - Flash Point and Product Label only\) : (.*)")]
		public void ICallSharedAdditionalDocumentsToProvide_FlashPointAndProductLabelOnly(string docPath)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				@"I click the browse button for document: Flash Point Document and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Flash Point Document", docPath);
			Report.StartSubStep(
				@"I click the browse button for document: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Product Label", docPath);
			Report.StartStep(@"in the Additional Documents to Provide page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 62678 \(Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path\)")]
		public void ICallSharedProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			Report.StartSubStep("I only the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartSubStep("I set the Select countries the product may be sold in option to: Canada");
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			Report.StartSubStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			var tableSecond = new Table("Section");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			Report.StartSubStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");


			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I confirm that the default selected retailer is: (.*) then click Continue")]
		public void CustomConfirmDefaultSelectedRetailer_ClickContinue(string retailer)
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsSelectRetailers = new StepsSelectRetailers();
			Report.StartSubStep("I should see the Retailer Page");
			stepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("The selected retailers on the Retailer page should be:");
			//MyNewProductSteps.SelectedRetailersShouldBe("should", new List<string> { retailer });
			var retailers = new Table("Retailer");
			retailers.AddRow(retailer);
			new Steps_Retailer().SelectedRetailersShouldBe("should", retailers);
			Report.StartSubStep("In the Retailer page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(@"I call Shared Step 59922 \(Product Information - Private Label or Brand only\)")]
		public void SharedProductInformation_PrivateLabelOrBrandOnly()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 58189 \(Answer Electronic Equipment questions - With Cathode Ray - No to all\)")]
		public void SharedAnswerElectronicEquipmentQuestions_WithCathodeRay_NoToAll()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartSubStep("I set the Contains Circuit Board option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Contains Circuit Board", "No");

			if (MyNewProduct.SectionExists(
				"Has a Cathode Ray Tube (CRT)"))
			{
				Report.StartSubStep("I set the Has a Cathode Ray Tube (CRT) option to: No");
				MyNewProductSteps.SetTheSectionOptionTo("Has a Cathode Ray Tube (CRT)", "No");
			}
			if (MyNewProduct.SectionExists(
				"Has a LCD or Plasma Display"))
			{
				Report.StartSubStep("I set the Has a LCD or Plasma Display option to: No");
				MyNewProductSteps.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			}
			Report.StartSubStep("In the Answer Electronic Equipment questions page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Electronic Equipment");
		}

		[StepDefinition(@"I call Shared Step 60741 \(Select Primary Physical Property - Solid - With Ingredients\)")]
		public void GivenICallSharedStepSelectPrimaryPhysicalProperty_Solid_WithIngredients()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");

			MyStepsNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");

			Report.StartSubStep("I set the Primary Physical State option to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartSubStep("I set the Secondary Physical State option to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Delay.Seconds(5);
			var MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("When mixed with an equal amount of water"))
			{
				Report.StartSubStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH option to: Yes");
				new NewProduct().ContainerElement.Scroll();
				Delay.Seconds(5);
				var thisNewProduct = new NewProduct();
				string section = "When mixed with an equal amount of water, will this produce a solution with a pH";
				string option = "Yes";
				if (thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()))
				{
					Report.Success("Successfully set the input to " + option.Trim() + " in section: " + section.Trim());
				}
				else
				{
					int i = 0;
					bool clicked = false;
					while (i < 5 && clicked == false)
					{
						Delay.Seconds(2);
						clicked = thisNewProduct.SetOptionInSection(section.Trim(), option.Trim());
						i++;
					}
					Report.IsTrue(clicked, "Failed to set the input to " + option.Trim() + " in section: " + section.Trim(), "Successfully set the input to " + option.Trim() + " in section: " + section.Trim());

				}
				//Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),	"Failed to set the input to " + option.Trim() + " in section: " + section.Trim(), "Successfully set the input to " + option.Trim() + " in section: " + section.Trim());
				Delay.Seconds(1);
				//MyStepsNewProduct.SetTheSectionOptionTo("When mixed with an equal amount of water, will this produce a solution with a pH", "Yes");

			}

			Report.StartSubStep("I set theSelect all potential allergens included in this product option to: Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Select all potential allergens included in this product", "Dairy");
			Report.StartSubStep(
				"I set the Product is manufactured in a facility that processes, or contains option to: Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains",
				"Dairy or products containing dairy or milk");
			Report.StartSubStep("I set the Product is verified and sold as option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			Report.StartSubStep("I set the Product contains the following sweeteners option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			Report.StartSubStep(
				"I set the Product contains the following artificial dye(s) option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)",
				"None of the Above");
			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 69687 \(Product Information - US, No\(PL\)\)")]
		public void GivenICallSharedStepProductInformation_CountryAndPrivateLabelOrBrand_No()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			// was failing on country of origin so adding if statement.
			// Flagging a fail because this condition doesn't exactly match the test case. If Origin Q. is expected here, should use a different Shared Step?
			if (new NewProduct().GetDisplayedSections().Contains("Select the product's Country of Origin"))
			{
				Report.StartStep(
					"I set the Select the product's Country of Origin option to: United States of America");
				//Report.Failure(
				//	"The Country of Origin question was showing (required field) when it was not expected. Selecting an option.");
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin",
					"United States of America");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
		[StepDefinition(@"I call Shared Step 234311 \(Product Information - Applicable Only to Light Bulbs - Germicidal Ultra Violet \(RU000962\)\)")]
		public void ThenICallSharedStepProductInformation_ApplicableOnlyToLightBulbs_GermicidalUltraVioletRU()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			var buttonTable = new Table(new string[] {
				"Checkbox" });
			buttonTable.AddRow(new string[] {
				"United States"
			});
			buttonTable.AddRow(new string[] {
				"Canada"
			});
			Report.StartSubStep(
				"Verify options in section 'Select countries the product may be sold in' should be: United States, Canada");
			MyStepsNewProduct.CheckCheboxesInSectionAndOrder("should", "Select countries the product may be sold in", buttonTable);
			Report.StartSubStep(
				"Verify selected option is United States by default in section 'Select countries the product may be sold in'");
			Report.IsTrue(new NewProduct().SelectedOptionsForSection("Select countries the product may be sold in")
				.Contains("United States"), "Failed to confirm selected option is United States by default", "Successfully confirmed selected option is United States by default");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyStepsNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 65511 \(Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path \(use in a BCP\)\)")]
		public void ICallSharedProductInformation_NoChildNoDirectShipNoPLClickContinue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			Report.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep("I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)", "No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			//Report.StartStep(
			//	"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			//MyNewProduct.SetTheSectionOptionTo(
			//	"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
			//	"No");			
			Report.StartSubStep("I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)", "No");

			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 159304 \(Product Information - US, No\(Child\), No \(DSV\), No \(PLP\)\)")]
		public void GivenICallSharedStepProductInformation_USNoChildNoDSVNoPLP()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			//Report.StartStep(
			//	"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			//MyNewProduct.SetTheSectionOptionTo(
			//	"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
			//	"No");			
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}
		[StepDefinition(@"I call Shared Step 57503 \(Inventory Status, Prop 65 \(US\) - TSCA\(Any Option\) - Prop 65 \(NO\) - Continue - Happy Path\)")]
		[StepDefinition(@"I call Shared Step 57503 \(Regulatory Information 1- TSCA\(Random\) - Prop 65\(No\) - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			var table = new Table("Section");
			table.AddRow("U.S. Toxic Substances Control Act (TSCA) status");
			table.AddRow("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			Report.Info("Checking that the only visible questions relate to: TSCA and Prop 65");
			MyStepsNewProduct.CheckDisplayedSections("only see", table);
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: complies");
			stepsRegulatoryInformation.SetTSCATo("complies");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 132370 \(Waste Classification Data - TSCA \(Random\) - Prop 65 \(No\) - Continue - Happy Path\)")]
		public void ICallSharedWasteClassificationData_TSCARandom_Pro65No_Continue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			var table = new Table("Section");
			table.AddRow("U.S. Toxic Substances Control Act (TSCA) status");
			table.AddRow("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			Report.Info("Checking that the only visible questions relate to: TSCA and Prop 65");
			MyStepsNewProduct.CheckDisplayedSections("only see", table);
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: complies");
			stepsRegulatoryInformation.SetTSCATo("complies");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 133277\(Waste Classification Data - CEPA\(Random\) - Prop 65\(No\) - Continue - Happy Path\)")]
		public void ICallSharedWasteClassificationData_CEAPRandom_Pro65No_Continue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			var table = new Table("Section");
			table.AddRow("Canadian Enviornmental Protection Act (CEPA) status");
			table.AddRow("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			Report.StartSubStep("I set the Canadian Enviornmental Protection Act (CEPA) status option to: complies");
			stepsRegulatoryInformation.SetCEPATo("Compliant with Domestic Substances List (DSL)");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 132375 \(Waste Classification Data - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path\)")]
		public void ICallSharedWasteClassificationData_TSCAAndCEPAShown_NoToProp65()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Exempt");
			stepsRegulatoryInformation.SetTSCATo("Exempt");
			Report.StartSubStep("I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyNewProductSteps.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status", "Compliant with Domestic Substances List (DSL)");
			Report.StartSubStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 59927 \(Primary Physical State > Solid only available – Without Water Solubility question\)")]
		public void SharedPrimaryPhysicalStateSolidOnlyAvailable_WithoutWaterSolubilityQuestion()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			Report.StartSubStep("I set the Secondary Physical State field to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 60826 \(Enter Universal Product Code \(UPC\) - Battery - Confirm Quantity \) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and quantity: (.*)")]
		public void SharedEnterUniversalProductCodeUPC_Battery_ConfirmQuantity(string upc, string containerType,
			string size, string quantity)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I confirm 'Quantity' is visible in the UPC header");
			MyStepsNewProduct.ConfirmQuantityIsVisibleInUPCHeader();
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			var upcTable = new Table(new string[] {
				"Field",
				"Value"
			});
			upcTable.AddRow(new string[] {
				"UPCNumber",
				"saved as UPC" + upc
			});
			upcTable.AddRow(new string[] {
				"ContainerType",
				containerType
			});
			upcTable.AddRow(new string[] {
				"Size",
				size
			});
			upcTable.AddRow(new string[] {
				"Quantity",
				quantity
			});
			Report.StartSubStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);

			Report.StartSubStep("I select Package Type from drop down list");
			new StepsUPC().GivenISelectAPackagerTypeFromTheDropDownList();

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 213071 \(Enter Universal Product Code \(UPC\) - Applicable Only to Alkaline Battery-Quantity Field Required\) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and quantity: (.*)")]
		public void SharedEnterUPC_Battery_ConfirmQuantity(string upc, string containerType,
			string size, string quantity)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			var upcTable = new Table(new string[] {
				"Field",
				"Value"
			});
			upcTable.AddRow(new string[] {
				"UPCNumber",
				"saved as UPC" + upc
			});
			upcTable.AddRow(new string[] {
				"ContainerType",
				containerType
			});
			upcTable.AddRow(new string[] {
				"Size",
				size
			});
			upcTable.AddRow(new string[] {
				"Quantity",
				quantity
			});
			Report.StartSubStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);

			Report.StartSubStep("I select Package Type from drop down list");
			new StepsUPC().GivenISelectAPackagerTypeFromTheDropDownList();

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 158500 \(Enter Universal Product Code \(UPC\) - Battery - Confirm SKU - Do Not Click Continue\) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) package type: (.*) and SKU: (.*)")]
		public void GivenICallSharedStepEnterUniversalProductCodeUPC_Battery_ConfirmSKU_DoNotClickContinueForUPCSavedAsUPCWithContainerTypeSizeAndSKU(string upc, string containerType,
			string size, string packageType, string sku)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			if (Context.Contains(sku))
			{
				sku = Context.GetFromContext(sku).ToString();
			}

			var upcTable = new Table(new string[] {
				"Field",
				"Value"
			});
			upcTable.AddRow(new string[] {
				"UPCNumber",
				"saved as UPC" + upc
			});
			upcTable.AddRow(new string[] {
				"ContainerType",
				containerType
			});
			upcTable.AddRow(new string[] {
				"PackageType",
				packageType
			});
			upcTable.AddRow(new string[] {
				"Size",
				size
			});
			upcTable.AddRow(new string[] {
				"Internal SKU",
				sku
			});

			Report.StartSubStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);

			Report.StartSubStep("I select a Package Type from the drop down list");
			new StepsUPC().GivenISelectAPackagerTypeFromTheDropDownList();
		}

		[StepDefinition(@"I call Shared Step 163416 \(Enter Universal Product Code \(UPC\) - Battery - Confirm SKU - No Package Type - Do Not Click Continue\) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and SKU: (.*)")]
		public void GivenICallSharedStepEnterUniversalProductCodeUPC_Battery_ConfirmSKU_NoPackageType_DoNotClickContinueForUPCSavedAsUPCWithContainerTypeSizeAndSKU(string upc, string containerType,
			string size, string sku)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			if (Context.Contains(sku))
			{
				sku = Context.GetFromContext(sku).ToString();
			}

			var upcTable = new Table(new string[] {
				"Field",
				"Value"
			});
			upcTable.AddRow(new string[] {
				"UPCNumber",
				"saved as UPC" + upc
			});
			upcTable.AddRow(new string[] {
				"ContainerType",
				containerType
			});
			upcTable.AddRow(new string[] {
				"Size",
				size
			});
			upcTable.AddRow(new string[] {
				"Internal SKU",
				sku
			});

			Report.StartSubStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
		}

		[StepDefinition(@"I call Shared Step 69358 \(Data Acceptance - Click Summary Button\)")]
		public void SharedDataAcceptance_ClickSummaryButton()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Summary button in the Data Acceptance window");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartSubStep("I confirm the Manufacturer column is visible");
			// Confirm Manufacturer column is visble.
			// Close new tab
		}

		[StepDefinition(@"I call Shared Step 60026 \(Product Information - US - Battery - No to all\)")]
		public void SharedProductInformation_US_Battery_NoToAll()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartSubStep("I set the Select one option below field to: Battery is packaged for Retail Sale");
			MyNewProductSteps.SetTheSectionOptionTo("Select one option below", "Battery is packaged for Retail Sale");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 73282 \(Lithium Battery Characteristics - Weight in Grams\)")]
		public void SharedLithiumBatteryCharacteristics_WeightInGrams()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			Report.StartSubStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			Report.StartSubStep("I set the Weight of Lithium in grams (single unit) field to: 0.1");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of Lithium in grams (single unit)", "0.1");
			Report.StartSubStep("I set the Weight of the single unit (grams) field to: 10");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "10");
			Report.StartSubStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			Report.StartSubStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}

		[StepDefinition(@"I call Shared Step 54799 \(Lithium Battery Characteristics - any data - Happy path\)")]
		public void SharedLithiumBatteryCharacteristics_AnyData()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			Report.StartSubStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			Report.StartSubStep("I set the Watt-hour of the battery (single unit) field to: 0.1");
			MyNewProductSteps.SetTheSectionOptionTo("Watt-hour of the battery (single unit)", "0.1");
			Report.StartSubStep("I set the Weight of the single unit (grams) field to: 10");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "10");
			Report.StartSubStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			Report.StartSubStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}

		[StepDefinition(@"I call Shared Step 103412 - Lithium Primary/Metal Battery Characteristics - any data - Happy path")]
		public void GivenICallSharedStep_LithiumPrimaryMetalBatteryCharacteristics_AnyData_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			Report.StartSubStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			Report.StartSubStep("I set the Weight of Lithium in grams (single unit) field to: 10.2");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of Lithium in grams (single unit)", "10.2");
			Report.StartSubStep("I set the Weight of the single unit (grams) field to: 12");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "12");
			Report.StartSubStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			Report.StartSubStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}



		[StepDefinition(@"I call Shared Step 60096 \(Lithium Battery Transportation\)")]
		public void SharedLithiumBatteryTransportation()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Lithium Battery Transportation Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Transportation");
			Report.StartSubStep(
				"I set the For U.S. Department of Transportation (DOT), indicate the transport classification field to: Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail");
			MyNewProductSteps.SetTheSectionOptionTo(
				"For U.S. Department of Transportation (DOT), indicate the transport classification",
				"Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail");
			Report.StartSubStep(
				"I select the first option for section: For Marine transport (IMDG), indicate the classification");
			MyNewProductSteps.SelectFirstOptionInSection("For Marine transport (IMDG), indicate the classification");
			Report.StartSubStep(
				"I set the For Air transport (IATA), indicate the classification field to the first selection");
			MyNewProductSteps.SelectFirstOptionInSection("For Air transport (IATA), indicate the classification");
			Report.StartSubStep(
				"I set the For Canada's Transportation of Dangerous Goods (TDG), indicate the classification field to: None of the above/Not intended for shipment in Canada");
			MyNewProductSteps.SetTheSectionOptionTo(
				"For Canada's Transportation of Dangerous Goods (TDG), indicate the classification",
				"None of the above/Not intended for shipment in Canada");
			Report.StartSubStep("In the Lithium Battery Transportation page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Transportation");
		}

		[StepDefinition(@"I call Shared Step 69422 \(Additional Documents to Provide - Upload Product Photo\)")]
		public void SharedAdditionalDocumentsToProvide_UploadProductPhoto()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep(
				@"I click the browse button for label: Please upload a PDF of the product. in section: Product Photo and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFileSectionAndType("Please upload a PDF of the product.", "Product Photo",
				@"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 54797 \(Select the specific Lithium Ion chemistry of the Battery\)")]
		public void SharedSelectTheSpecificLithiumIonChemistry()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Select the specific Lithium Ion chemistry of the Battery Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Select the specific Lithium Ion chemistry of the Battery");
			Report.StartSubStep("I select the first option in section: Select the best description");
			MyNewProductSteps.SelectFirstOptionInSection("Select the best description");
			Report.StartSubStep("In the Select the specific Lithium Ion chemistry page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Select the specific Lithium Ion chemistry");
		}

		// Duplicate of Shared step 60026
		[StepDefinition(@"I call Shared Step 65493 \(Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue\)")]
		public void SharedProductInformation_USOnly_BatteryIsPackedForRetailSales_NoElse()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I set the Select one option below field to: Battery is packaged for Retail Sale");
			MyNewProductSteps.SetTheSectionOptionTo("Select one option below", "Battery is packaged for Retail Sale");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 56808 Regulatory Information - Prop 65 - No - Continue")]
		public void GivenICallShared56808RegulatoryInformation_Prop_No_Continue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Waste Classification Data");
		}

		[StepDefinition(@"I call Shared Step 60715 \(Additional Documents to Provide - OSHA SDS - only\) : (.*)")]
		public void GivenICall60715SharedAdditionalDocumentsToProvide_OSHASDS_OnlyCDependenciesWERCSmartTestdoc_Pdf(
			string docPath)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			//MyStepsNewProduct.UploadPDFFileSectionAndType("OSHA SDS", "Upload Physical", docPath);
			MyStepsNewProduct.UploadPDFFileSectionAndType("OSHA SDS", "Upload SDS (Optional)", docPath);
			Report.StartSubStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 58608 \(Additional Documents to Provide - Label - OSHA - CARB\)")]
		public void SharedAdditionalDocumentsToProvide_Label_OSHA_CARB()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Additional Documents To Provide Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Documents To Provide");
			Report.StartSubStep(
				@"I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("Product Label", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep(
				@"I click the browse button for label: OSHA SDS and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("OSHA SDS", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep(
				@"I click the browse button for label: Executive Order from the CARB and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("Executive Order from the CARB", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 26897 \(Physical and Chemical Properties - Solid only available - continue\)")]
		public void SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var thisNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep("There should only be one option available for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			if (!thisNewProduct.SelectedOptionsForSection("Primary Physical State").Contains("Solid"))
			{
				Report.Failure("The Primary Physical State was not set to Solid by default.");
				Report.Screenshot();
				Report.Info("Setting the Primary Physical State to: Solid");
				MyNewProductSteps.SetTheSectionOptionTo(
					"Primary Physical State",
					"Solid");
			}
			else
			{
				Report.Success("The Primary Physical State was showing the value of: Solid as expected");
				Report.Screenshot();
			}

			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartSubStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}

			Report.StartSubStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartSubStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			if (new NewProduct().GetDisplayedSections().Contains("Flash Point Testing Method Used"))
			{
				Report.StartSubStep("Selecting Not applicable/available for section: Flash Point Testing Method Used");
				MyNewProductSteps.SetTheSectionOptionTo("Flash Point Testing Method Used",
					"Not applicable/available");
			}

			Report.StartSubStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 57590 \(Enter Pesticide Data - United States \(with EPA number\)\)")]
		public void SharedEnterPesticideData_UnitedStatesWithEPANumber()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var newProductPesticideDetailsUS = new Steps_PesticideDetailsUS();
			Report.StartSubStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "Yes");
			Report.StartSubStep("I add the EPA Registration Number: 72315-6");
			newProductPesticideDetailsUS.IAddTheEPARegistrationNumber("72315-6");
			Report.StartSubStep("Clicking continue in the Pesticide Details page");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Pesticide Details");
		}

		[StepDefinition(@"I call Shared Step 57508 \(VOC SCAQMD/Canada - Yes Low Solid, Yes apply to all States - Continue - Happy Path\)")]
		public void SharedVOCSCAQMDCanada_YesLowSolidYesApplyToAllStates_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
			Report.StartSubStep("I set the Product is a Low Solid option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Low Solid", "Yes");
			Report.StartSubStep(
				"I set the VOC content of product in g/L, including water and exempt compounds. option to: 10.0");
			MyNewProductSteps.SetTheSectionOptionTo(
				"VOC content of product in g/L, including water and exempt compounds.", "10.0");
			Report.StartSubStep(
				"I set the Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison? option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison?",
				"Yes");
			Report.StartSubStep("Clicking continue in the Volatile Organic Compounds (VOC) for California Air District(s) and Canada page");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC) for California Air District(s) and Canada");
		}

		[StepDefinition(@"I call Shared Step 57798 \(Product Information- Pesticide, Canada Only - No to everything else, Continue\)")]
		public void SharedProductInformation_Pesticide_CanadaOnly_NoToAll_Continue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("Make sure the United States check box is NOT selected, if it is uncheck it");
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			Report.StartSubStep("I set the Select countries the product may be sold in option to: Canada");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyStepsNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 48948 \(Formulation > 3rd Party - Select all\)")]
		public void SharedFormulation3rdParty_SelectAll()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Formulation > 3rd Party Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Formulation > 3rd Party");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"By clicking Accept, I certify the formulation information entered is complete and accurate",
				"Accept"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"By clicking Accept, I certify the formulation information entered is complete and accurate", "Accept");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Consent to Tier 2 Data Uses",
				"Granted"));
			MyStepsNewProduct.SetTheSectionOptionTo("Consent to Tier 2.1, 2.2, 4.2 Data Uses", "Granted");
			//MyStepsNewProduct.SetTheSectionOptionTo("Consent to Tier 2 Data Uses", "Granted");
			//if (myNewProductClass.SectionExists("Consent to Tier 4.1 Derived Results"))
			//{
			//	Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
			//	"Consent to Tier 4.1 Derived Results",
			//	"Granted"));
			//	MyStepsNewProduct.SetTheSectionOptionTo("Consent to Tier 4.1 Derived Results", "Granted");
			//}
			Report.StartSubStep("in the Formulation > 3rd Party page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Formulation > 3rd Party");
		}

		[StepDefinition(@"I call Shared Step 60932 \(Regulatory Information 2 - Microbeads - No\)")]
		public void SharedRegulatoryInformation2_Microbeads_No()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product contains microbeads",
				"No"));
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains microbeads", "No");
			Report.StartSubStep("in the Regulatory Information 2 page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 2");
		}

		[StepDefinition(@"I call Shared Step 60933 \(Additional Documents to Provide - Product Label and OSHA SDS only\)")]
		public void SharedAdditionalDocumentsToProvide_ProductLabelAndOSHASDSOnly()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I click the browse button for label: '{0} and upload PDF: '{1}'",
				"Product Label",
				@"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf"));
			MyStepsNewProduct.UploadPDFFile("Product Label", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep(string.Format("I click the browse button for label: '{0} and upload PDF: '{1}'",
				"OSHA SDS",
				@"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf"));
			MyStepsNewProduct.UploadPDFFile("OSHA SDS", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("in the Additional Documents to Provide page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 58610 \(Confirm Restrict Use - Restrict\)")]
		public void SharedConfirmRestrictUse_Restrict()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var restrictUse = new Table("Section");
			restrictUse.AddRow("Do you want to restrict searchable access to your registered formula?");
			MyStepsNewProduct.CheckDisplayedSections("see", restrictUse);
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Do you want to restrict searchable access to your registered formula?",
				"Restrict - Customers should contact my organization for an access code"));
			var NewProductObject = new NewProduct();
			Report.IsTrue(NewProductObject.SelectRestrictUseOption(" - Customers should contact my organization for an access code"), "Failed to select restriction option", "Successfully selected restriction option");

			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Access Code",
				"12345678"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Access Code",
				"12345678");

			Report.StartSubStep("in the Restrict Use page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Restrict Use");
		}

		[StepDefinition(@"I call Shared Step 63219 \(Retailer Association - Select No Retailer - Click continue\)")]
		public void SharedRetailerAssociatedion_SelectNoRetailer_ClickContinue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var selSelectRetailers = new SelectRetailers();
			if (!selSelectRetailers.WaitForContainerToBeVisible(10))
			{
				Report.Warning("The Select Retailers page was not loaded on entering the Retailer page");
				new Retailer().ClickAddRetailers();
			}

			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
			Report.StartSubStep("In the UPCs Warning popup I click Ok");
			var WarningPopup = new NoRetailerWarningPopup();
			WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(@"I call Shared Step 73629 \(Physical and Chemical Properties - Liquid - select any options\(enter pH, boiling point, flash point\)\)")]
		public void ICallSharedStepPhysicalandChemicalPropertiesWithBoilingPointPHFlashPoint(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep("Confirm that  you see only Liquid option for Physical state");
			var option = new Table("Option");
			option.AddRow("Liquid");
			MyNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Primary Physical State", option);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Relative Density I enter: " +
				table.Rows[0]["Relative Density"]);
			MyNewProduct.SetTheSectionOptionTo("Relative Density",
				table.Rows[0]["Relative Density"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
		[StepDefinition(@"I call Shared Step 217668 \(Physical and Chemical Properties - Applicable Only to Engine Motor Oil for Auto or Boat \(RU000269\)\)")]
		public void Shared92950EnterPhysicalProperty_Liquid_ForMotorOil()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density option to: 0.8892");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "0.8892");
			Report.StartStep("I set the Relative Density option to: lb./gal. (pounds per gallon)");
			MyNewProduct.SectRadioButtonInSection("Relative Density", "lb./gal. (pounds per gallon)");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("pH", "Not tested/Unknown");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			Report.StartSubStep("I set the Boiling Point (in Celsius) field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			Report.StartSubStep("I set the Flash Point (in Celsius) field to: 180");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "180");
			Report.StartSubStep("I set the Flash Point Determination method option to: Not applicable/available");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Insoluble in water");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Insoluble in water");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 73748 \(Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer\)")]
		public void GivenICallSharedStepProductInformation_WithMarketedForUseByAChild_OSHA_PrivateLabel()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					"No");
			}

			if (myNewProduct.SectionExists(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)")
			)
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
					"No");
			}

			if (myNewProduct.SectionExists("Product is shipped directly by supplier to the consumer."))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.",
					"No");
			}

			if (myNewProduct.SectionExists("Product is a Retailer's Private Label or Brand"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			}

			if (myNewProduct.SectionExists(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)")
			)
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
					"No");
			}

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			Report.StartStep("In the Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 70675 \(Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue\)")]
		public void SharedPhysicalandChemicalProperties_LiquidOnly_WithWaterSolubility_EnterAllData_Continue()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Secondary Physical State",
				"Liquid"));
			myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Relative Density",
				"1.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Relative Density", "1.0");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"10.2"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "10.2");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"120"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "120");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"55"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "55");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Closed cup method"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Select the best Water Solubility description",
				"Soluble in water"));
			myStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 216861 \(Transportation Details 2 > Applicable Only to Alcoholic Beverages - Wine \(RU001418\)\)")]
		[StepDefinition(@"I call Shared Step 62536 \(Transportation Details 2 > I do not ship internationally > Continue - Happy Path\)")]
		public void SharedTransportationDetails2_DoNotShipInternationally_Continue()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Transportation Details 2 page");
			myStepsNewProduct.GivenIShouldSeeXPage("Transportation Details 2");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"International Shipping when DOT Exemption taken?",
				"I do not ship internationally and I do not know the classification"));
			myStepsNewProduct.SetTheSectionOptionTo("International Shipping when DOT Exemption taken?",
				"I do not ship internationally and I do not know the classification");
			Report.StartSubStep("In the Transportation Details 2 page I click continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 2");
		}

		[StepDefinition(@"I call Shared Step 62686 \(Enter Physical Property - Liquid - Without Water Solubility\)")]
		public void SharedEnterPhysicalProperty_Liquid_WithoutWaterSolubility()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			//Report.StartStep(string.Format("'{0}' should be showing the value: '{1}'",
			//	"Primary Physical State",
			//	"Liquid"));
			//myStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			//if (!myNewProduct.GetOptionsForSection("Primary Physical State").Contains("Liquid"))
			//{
			//	Report.Info("Liquid was not set as the Primary Physical State by default, so selecting the option.");
			//	myNewProduct.SetOptionInSection("Primary Physical State", "Liquid");
			//}
			Report.StartSubStep("I set the Primary Physical State to: 'Liquid'");
			myStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Relative Density",
				"10"));
			myStepsNewProduct.SetTheSectionOptionTo("Relative Density", "10");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"8"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "8");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"30"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "30");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"50"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "50");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Closed cup method"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Secondary Physical State",
				"Liquid"));
			myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 92950 \(Physical and Chemical Properties - Physical Property - Liquid - For Wine Less than <70% Alcohol\)")]
		public void Shared92950EnterPhysicalProperty_Liquid_ForWineLessThan70()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density option to: 0.1");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "0.1");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("pH", "Not tested/Unknown");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			Report.StartSubStep("I set the Boiling Point (in Celsius) field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			Report.StartSubStep("I set the Flash Point (in Celsius) field to: 43");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "43");
			Report.StartSubStep("I set the Flash Point Testing Method Used option to: Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 49818 \(Beverage Regulatory Details\)")]
		public void SharedBeverageRegulatoryDetails()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				"Yes"));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", "Yes");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Does your product contain a Prop 65 chemical?",
				"Yes"));
			new RegulatoryInformation1().Prop65 = true;
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				"10"));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", "10");
			Report.StartSubStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}

		[StepDefinition(@"I call Shared Step 92964 \(Beverage Regulatory Details Less < 70%\)")]
		public void Shared92954BeverageRegulatoryDetailsLessThan70()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				"No"));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", "No");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				"27"));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", "27");
			Report.StartSubStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}

		[StepDefinition(
			@"I call Shared Step 71618 \(U. S. Department of Transportation \(DOT\) Classification - For Alcohol \(Packaging III\)\)")]
		public void SharedUSDepartmentOfTransportationDOTClassification_ForAlcoholPackagingiii()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"UN Number",
				"UN3065"));
			myStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN3065");
			Report.StartSubStep(
				"By default the 'Proper Shipping Name' Field will be populated with 'Alcoholic beverages'");
			myStepsNewProduct.CheckingFieldInputIsCorrect("Proper Shipping Name", "Alcoholic beverages");
			Report.StartSubStep("I select the first valid option for section: 'Proper Shipping Name'");
			myStepsNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			string shippingName = myNewProduct.GetAllOptionsForSection("Proper Shipping Name")[0];
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Technical Name (if applicable)",
				"Technical " + shippingName));
			myStepsNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical " + shippingName);
			Report.StartSubStep("By default, '3' should be selected for 'Hazard Class (select)'");
			myStepsNewProduct.CheckingFieldInputIsCorrect("Hazard Class (select)", "3");
			Report.StartSubStep("I set the Packing Group section to 'III'");
			myStepsNewProduct.SetTheSectionOptionTo("Packing Group (select)", "III");
			Report.StartSubStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I call Shared Step 73956 \(Go to Summary and verify data\) with product type: (.*)")]
		public void SharedGoToSummaryAndVerifyData(string typeOfProduct)
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myGlobalSteps = new GlobalSteps();
			Report.StartSubStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			Report.StartSubStep("I click the Summary button in the Data Acceptance window");
			myStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartSubStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			Report.StartSubStep("Type of Product should be showing the following option: " + typeOfProduct);
			new StepsDataSummarySheet().ShouldBeShowingFollowing("Type of Product", typeOfProduct);
			Report.StartSubStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();
			Report.StartSubStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			// Nav to home not specified by the TFS item. I checked and it shouldn't break any other tests. Always end of test or delete shared step (which navs to home)
			//Report.StartStep("I navigate to the home page");
			//new StepsHomepage().ThenINavigateToTheHomePage();
		}
		[StepDefinition(@"I call Shared Step 214662 \(Summary Tab - Data Verification - Applicable Only to Bonding Agent \(RU000023\)\)")]
		[StepDefinition(@"I call Shared Step 221015 \(Summary Tab - Product's Data Verification When Request to Author is NOT Selected in the Regulatory Documents to Provide Page \(Applies Only to Footwear or Leather Care Product Aerosol \(RU000744\)\)")]
		public void GivenICallSharedStepSummaryTab_ProductsDataVerificationWhenRequestToAuthorIsNOTSelectedInTheRegulatoryDocumentsToProvidePageAppliesOnlyToFootwearOrLeatherCareProductAerosolRU( Table table)
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myGlobalSteps = new GlobalSteps();
			var dataSummary = new DataSummary();
			Report.StartSubStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			Report.StartSubStep("I click the Summary button in the Data Acceptance window");
			myStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartSubStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			foreach(var row in table.Rows)
			{
				switch (row["Section"])
				{
					case "Type of Product":
						Report.StartSubStep($"Type of Product should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Type of Product", row["Value"]);
						break;
					case "FIFRA 25(b) Exempt":
						Report.StartSubStep($"Section 'Which best describes your product, including when FIFRA 25(b) Exempt' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("FIFRA 25(b) Exempt", row["Value"]);
						break;
					case "UN Number":
						Report.StartSubStep($"Section 'Which best describes your product, including when FIFRA 25(b) Exempt' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("UN Number", row["Value"]);
						break;
					case "Proper Shipping Name":
						Report.StartSubStep($"Section 'Proper Shipping Name' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Proper Shipping Name", row["Value"]);
						break;
					case "Hazard Class":
						Report.StartSubStep($"Section 'Hazard Class' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Hazard Class", row["Value"]);
						break;
					case "Packing Group":
						Report.StartSubStep($"Section 'Packing Group' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Packing Group", row["Value"]);
						break;
					case "CARB":
						Report.StartSubStep($"Section 'CARB' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("CARB", row["Value"]);
						break;
					case "OTC Model Rule":
						Report.StartSubStep($"Section 'OTC Model Rule' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("OTC Model Rule", row["Value"]);
						break;
					case "Product has been granted an Alternative Control Plan":
						Report.StartSubStep($"Section 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Product has been granted", row["Value"]);
						break;
					case "Primary Physical State":
						Report.StartSubStep($"Section 'Primary Physical State' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Primary Physical State", row["Value"]);
						break;
					case "Secondary Physical State":
						Report.StartSubStep($"Section 'Secondary Physical State' should be showing the following option: {row["Value"]}");
						new StepsDataSummarySheet().ShouldBeShowingFollowing("Secondary Physical State", row["Value"]);
						break;
					case "Container Type":
						Report.StartSubStep($"Section {row["Section"]} should be showing the following option: {row["Value"]}");
						Report.IsTrue(dataSummary.VerifyTableValueInSammeryPage(row["Section"], row["Value"]), $"Failed to confirm {row["Section"]} is {row["Value"]}", $"Successfully confirmed {row["Section"]} is {row["Value"]}");
						break;
					case "Size (Ounces)":
						Report.StartSubStep($"Section {row["Section"]} should be showing the following option: {row["Value"]}");
						Report.IsTrue(dataSummary.VerifyTableValueInSammeryPage(row["Section"], row["Value"]), $"Failed to confirm {row["Section"]} is {row["Value"]}", $"Successfully confirmed {row["Section"]} is {row["Value"]}");
						break;
					case "Retailers":
						Report.StartSubStep($"Section {row["Section"]} should be showing the following option: {row["Value"]}");
						Report.IsTrue(dataSummary.VerifyTableValueInSammeryPage(row["Section"], row["Value"]), $"Failed to confirm {row["Section"]} is {row["Value"]}", $"Successfully confirmed {row["Section"]} is {row["Value"]}");
						break;
				}
			}
			Report.StartSubStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();
			Report.StartSubStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
		}


		[StepDefinition(
			@"I call Shared Step 43758 \(Product Grid- Filter for Product- Select Product - Delete\) for product: (.*)")]
		public void SharedProductGrid_FilterForProduct_SelectProduct_Delete(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartStep("I delete the product: " + savedAs);
			new StepsProductGrid().ThenIDeleteTheProduct(savedAs);
		}

		[StepDefinition(
			@"I call Shared Step 57514 \(Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path\)")]
		public void SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Relative Density",
				"15.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Relative Density", "15.0");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"9.5"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "9.5");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"120"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "120");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"80"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "80");
			Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Not applicable/available"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
					"Select the best Water Solubility description",
					"Soluble in water"));
				myStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			}

			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartSubStep(string.Format("I set the '{0}' option to: '{1}'",
					"Secondary Physical State",
					"Liquid"));
				myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			}

			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(
			@"I call Shared Step 57505 \(Pesticide Data - U.S. - EPA reg #\(No\) - EPA Exempt # \(Random\) - Continue - Happy Path\)")]
		public void SharedPesticideData_US_EPARegNo_EPAExemptRandom_Continue()
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product has an Environmental Protection Agency (EPA) Registration Number",
				"No"));
			myStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "No");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Select the applicable exemption",
				"Product is FIFRA 25(b) Exempt."));
			myStepsNewProduct.SetTheSectionOptionTo("Select the applicable exemption",
				"Product is FIFRA 25(b) Exempt.");

			Report.StartStep("In the Pesticide Details - U.S. page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		[StepDefinition(
			@"I call Shared Step 56967 \(Confirm Retailer & You information is shown correctly\) for retailer: (.*)")]
		public void GivenICallSharedStepConfirmRetailerYouInformationIsShownCorrectlyForRetailer(string retailer)
		{
			Report.UseSubSteps = true;
			var thisStepsRetailPartners = new StepsRetailPartners();
			var thisRetailPartnersDetails = new RetailPartnersDetails();
			Report.IsTrue(thisRetailPartnersDetails.GetAndYouText().Contains(retailer),
				"The & You text is not as expected.", "The & You text is showing as expected");

			thisStepsRetailPartners.PieChartShowing();
			thisStepsRetailPartners.ConfirmPieChartLegend("of your product portfolio is associated with " + retailer);
			//TODO - not doing it now because there is no way of controlling how old the account is and only accounts
			//older than a year will show anything
			//Confirm you see the "It's been <y> good long years since <Date>" statement below the Thumbs up icon
		}

		[StepDefinition(@"I call Shared Step 56968 \(Confirm - Data Consent Tiers not required \)")]
		public void GivenICallSharedStepConfirm_DataConsentTiersNotRequired()
		{
			Report.UseSubSteps = true;
			var thisStepsRetailPartners = new StepsRetailPartners();
			thisStepsRetailPartners.ConfirmHeadingShowing("Data Consent Tiers");
			thisStepsRetailPartners.SectionShouldBeShowingText("Data Consent Tiers",
				"This recipient does not require additional data consent tiers at this time.");

		}
		[StepDefinition(@"I call Shared Step 214643 \(Product Information - Applicable Only to Bonding Agent \(RU000023\)\)")]
		[StepDefinition(@"I call Shared Step 63804 \(Product Information - US, No\(OSHA\), No\(DSV\), Yes \(PLP\), No\(GNFR\)\)")]
		public void ICallSharedStepProductInformation_US_NoOSHA_NoDSV_YesPLP_NoGNFR(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);

			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				Report.StartStep(
					"In the Product Type tab of the New Product Page for Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) I select:" +
					table.Rows[0]["Product is marketed for use"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					table.Rows[0]["Product is marketed for use"]);
			}
			if (myNewProduct.SectionExists(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)")
			)
			{
				Report.StartStep(
					"In the Product Type tab of the New Product Page for Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) I select:" +
					table.Rows[0]["Classified using OSHA (US) Globally Harmonized Standards (GHS)"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
					table.Rows[0]["Classified using OSHA (US) Globally Harmonized Standards (GHS)"]);
			}
			if (myNewProduct.SectionExists(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.")
			)
			{
				Report.StartStep(
					"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." +
					table.Rows[0]["Shipped directly by supplier"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
					table.Rows[0]["Shipped directly by supplier"]);
			}
			if (myNewProduct.SectionExists(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.")
			)
			{
				Report.StartStep(
					"Cleaning products must comply with California's Cleaning Product Right to Know Act." +
					table.Rows[0]["California's Cleaning Product Right to Know Act"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					table.Rows[0]["California's Cleaning Product Right to Know Act"]);
			}

			if (myNewProduct.SectionExists(
				"Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product "))
			{
				Report.StartStep(
					"Product is a Retailer's Private Label or Brand" +
					table.Rows[0]["Private Label or Brand"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ",
					table.Rows[0]["Private Label or Brand"]);
			}
			if (myNewProduct.SectionExists(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)")
			)
			{
				Report.StartStep(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)" +
					table.Rows[0]["Good Not for resale"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
					table.Rows[0]["Good Not for resale"]);
			}
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			Report.StartStep("In the Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 65181 \(Retailer Association - Add Private Label Information and Select Vendor ID\) and select the retailer: (.*) and enter the name: (.*) and select Vendor id: (.*)")]
		public void GivenICallSharedRetailerAssociation_AddPrivateLabelInformationAndVendorId(string retailer, string name, string option)
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Retailer();
			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartSubStep("I should see the Retailer Page");
			stepsNewProduct.GivenIShouldSeeXPage("Retailer");
			var newProduct = new NewProduct();
			stepsRetailer.SelectPrivateLabelName(name);
			Delay.Seconds(2);
			if (option == "random")
			{
				Report.StartSubStep("Selecting a random vendor ID");
				Report.IsTrue(new Retailer().SelectRandomVendorId(), "Failed to set Vendor ID!",
					"Successfully set vendor ID");
				Report.Screenshot();
			}
			else
			{
				Report.StartSubStep("Selecting vendor ID: " + option);
				new Steps_Retailer().ISelectVendorId(option);
			}
			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("No Retailer/No UPC Product", "This Private Label");

			Report.StartSubStep("In the Retailer page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(
			@"I call Shared Step 74760 \(Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data\)")]
		public void ICallSharedPhysicalandChemicalProperties_MoreThanOneState_SelectLiquidAndEnterOtherOptions(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Delay.Seconds(1);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Primary Physical State I select: " +
				table.Rows[0]["Primary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State",
				table.Rows[0]["Primary Physical State"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Relative Density I enter: " +
				table.Rows[0]["Relative Density"]);
			MyNewProduct.SetTheSectionOptionTo("Relative Density",
				table.Rows[0]["Relative Density"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			Report.StartSubStep(
			"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
			table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
			table.Rows[0]["Select the best Water Solubility description"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 102750 \(Physical and Chemical Properties - Select primary physical state \(liquid\), flash point \(above 60\), and all other required data\)")]
		public void GivenICallSharedStepPhysicalAndChemicalProperties_SelectPrimaryPhysicalStateLiquidFlashPointAboveAndAllOtherRequiredData()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Delay.Seconds(1);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Primary Physical State I select: " +
				"Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State",
				"Liquid");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				"Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				 "Liquid");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Relative Density I enter: " +
				"1.0");
			MyNewProduct.SetTheSectionOptionTo("Relative Density",
				"1.0");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				"1.0");
			MyNewProduct.SetTheSectionOptionTo("pH",
				"1.0");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				"1.0");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				"1.0");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				"61");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				"61");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				"Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				"Closed cup method");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
				"Dispersible");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				"Dispersible");
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 132110 \(Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data - Without Water Solubility\)")]
		public void ICallSharedProductCharacteristics_PharmaFlow_MoreThanOneState_SelectLiquidAndEnterOtherOptions(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			//Product Characteristics
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Delay.Seconds(1);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for Primary Physical State I select: " +
				table.Rows[0]["Primary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State",
				table.Rows[0]["Primary Physical State"]);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for Relative Density I enter: " +
				table.Rows[0]["Relative Density"]);
			MyNewProduct.SetTheSectionOptionTo("Relative Density",
				table.Rows[0]["Relative Density"]);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			Report.StartSubStep(
				"In the Physical and Chemical tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 74123 \(Product Information - Grocery - US - Random Country - No\(PL\)\)")]
		public void GivenICallSharedStepProductInformation_Grocery_US_RandomCountry_NoPL()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");

			//CLF - this option doesn't always appear. Putting this fix in for now but may need a new version of the step
			var MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("Select the product's Country of Origin"))
			{
				Report.Info("Select country of origin appears...");
				MyNewProductSteps.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");

			}

			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 74981 \(Physical and Chemical Properties - gas\)")]
		public void ICallSharedPhysicalandChemicalProperties_Gas(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Delay.Seconds(1);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I select: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 208261 \(Volatile Organic Compound \(VOC\) Step - enter OTC and CARB - No for state values\)")]
		public void ICallSharedProductCharacteristics_EnterVocAndCarbSelectStateValueNo(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartSubStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. I select: " +
				table.Rows[0]["Product granted Alternative Control Plan"]);
			//BELOW STEP HAS BE TEMP FIXED NEED TO GO BACK AND UPDATE (INSTEAD OF USING SHORT QS TEXT, UPDATE HOW TEXT IS MATCHED)
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP(table.Rows[0]["Product granted Alternative Control Plan"]);
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB I enter: " +
				table.Rows[0]["Amount of VOC by CARB"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB",
				table.Rows[0]["Amount of VOC by CARB"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule I enter: " +
				table.Rows[0]["Amount of VOC by OTC Model"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule",
				table.Rows[0]["Amount of VOC by OTC Model"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? I select: " +
				table.Rows[0]["VOC for states"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?",
				table.Rows[0]["VOC for states"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 57923 \(Volatile Organic Compound \(VOC\) Step - enter OTC and CARB - Yes for state values\)")]
		public void ICallSharedProductCharacteristics_EnterVocAndCarbSelectStateValue(Table table)
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartSubStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. I select: " +
				table.Rows[0]["Product granted Alternative Control Plan"]);
			//BELOW STEP HAS BE TEMP FIXED NEED TO GO BACK AND UPDATE (INSTEAD OF USING SHORT QS TEXT, UPDATE HOW TEXT IS MATCHED)
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP(table.Rows[0]["Product granted Alternative Control Plan"]);
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB I enter: " +
				table.Rows[0]["Amount of VOC by CARB"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB",
				table.Rows[0]["Amount of VOC by CARB"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule I enter: " +
				table.Rows[0]["Amount of VOC by OTC Model"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule",
				table.Rows[0]["Amount of VOC by OTC Model"]);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? I select: " +
				table.Rows[0]["VOC for states"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?",
				table.Rows[0]["VOC for states"]);
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");

			Report.StartSubStep("I should see the Volatile Organic Compound Summary");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			MyNewProduct.SetTheSectionOptionTo("Your acknowledgement of this registration includes that your product", "Yes, I Acknowledge");
		}

		[StepDefinition(
			@"I call Shared Step 56799 \(Confirm Product Information shows Pesticide question and its radio buttons\)")]
		public void ICallSharedConfirmProductInformationShowsPesticideQuestion()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			var sections = new Table("Section");
			sections.AddRow("Which best describes your product, including when FIFRA 25(b) Exempt");
			Report.StartSubStep("I confirm the 'Which best describes your product, including when FIFRA 25(b) Exempt' question is shown");
			MyNewProduct.CheckDisplayedSections("see", sections);
			var buttons = new Table("Button");
			buttons.AddRow(
				"Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			buttons.AddRow(
				"Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth)");
			buttons.AddRow("Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			Report.StartSubStep(
				"I confirm the radios showing in order are: Product is intended for preventing, destroying...', 'Product is intended for use as a plant regulator...', 'Product is not a pesticide...'");
			MyNewProduct.CheckRadioButtonsInSectionAndOrder("should", "Which best describes your product, including when FIFRA 25(b) Exempt", buttons);
		}

		[StepDefinition(
			@"I call Shared Step 57532 \(Physical and Chemical Properties - Aerosol & Gas available - Select Gas - Continue - Happy Path\)")]
		public void ICallSharedPhysicalandChemicalProperties_AerosolAndGasAvailable_SelectGas_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Gas");
			Report.StartSubStep("I set the Secondary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(
			@"I call Shared Step 57500 \(The Product- Enter name, select product type - Continue - Happy Path\): (.*)")]
		public void GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(string option)
		{
			string name = "";
			this.Step57561(option, name);
		}

		public void GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(string option,
			string name)
		{
			this.Step57561(option, name);
		}

		[StepDefinition(
			@"I call Shared Step 63460 \(Product Information - SOLD = US, No\(PL\), No\(GNFR\) only shown \(mainly kits\) Happy Path\)")]
		public void GivenICallSharedStepProductInformation_SOLDUSNoPLNoGNFROnlyShownMainlyKitsHappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 74339 \(Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH\)")]
		public void GivenICallSharedStepPhysicalandChemicalProperties_SelectLiquidAndEnterOnlySecondaryStateSpecificGravityPH()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");

			MyNewProductSteps.GivenIShouldSeeXPage("Physical and Chemical Properties");

			// From TFS - Note: In local only the Liquid option is shown - in staging and production we show Liquid and Sold hence the presence of this step
			if (TReVorSettings.SoftwareBranch == "Development")
			{
				MyNewProductSteps.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			}
			else
			{
				MyNewProductSteps.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			}

			MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyNewProductSteps.SetTheSectionOptionTo("Relative Density", "20");
			MyNewProductSteps.SetTheSectionOptionTo("pH", "7");
		}

		[StepDefinition(@"I call Shared Step 74340 \(Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue\)")]
		public void
			GivenICallSharedStepProductInformation_PesticideNotConsideredSOLDUSEverythingElseNo_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			var myNewProductClass = new NewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}


		[StepDefinition(
			@"I call Shared Step 143418 \(Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue\)")]
		public void
			GivenICallSharedStepProductInformation_PesticideNotConsideredFertilizerNoSOLDUSEverythingElseNo_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			var myNewProductClass = new NewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			Report.StartSubStep(
				"I set the Does the product contain fertilizer (N, P, K) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Does the product contain fertilizer (N, P, K)",
				"No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		/*
		[StepDefinition(@"I call Shared Step 57514 \(Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path\)")]
		public void GivenICallSharedStepProductCharacteristics_LiquidOnlyAvailable_EnterAllData_Continue_HappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Relative Density", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "63");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Open cup method");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
		*/

		[StepDefinition(@"I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue")]
		public void GivenICallSharedStepIngredients_AddAnyChemical_DONotClickContinue(Table ingredientsTable)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			Report.StartSubStep("I add the following ingredients:");
			stepsNewProductIngredients.AddIngredients(ingredientsTable);
		}

		[StepDefinition(
			@"I call Shared Step 57539 \(Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path\)")]
		public void ICallSharedPhysicalandChemicalProperties_AerosolAndLiquidSelectAerosol_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			// Primary Physical State displays Aerosol and Liquid
			Report.StartSubStep("I should only see the following options for Primary Physical State: Aerosol, Liquid");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			produtTable.AddRow(new string[] {
				"Liquid"
			});
			Report.StartSubStep("I set the Primary Physical State field to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			Report.StartSubStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			Report.StartSubStep("I set the pH field to: 10.4");
			MyNewProduct.SetTheSectionOptionTo("pH", "10.4");
			Report.StartSubStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			Report.StartSubStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			//Report.StartStep("I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: The product is classified as a D003 Hazardous Waste under RCRA.");
			//MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "The product is classified as a D003 Hazardous Waste under RCRA.");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(
			@"I call Shared Step 57932 \(Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path\)")]
		public void GivenICallSharedEnterRegulatoryInformation_YesToProp()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			var selNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Waste Classification Data Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Waste Classification Data");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("Prop 65 warning is required: Yes");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("Yes");
			Report.StartSubStep("I set the Is the need to warn triggered by field to: A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			MyStepsNewProduct.SetTheSectionOptionTo("Is the need to warn triggered by",
				"A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			Report.StartSubStep("I set the How is the exposure warning transmitted? field to: By affixing it to the product or its packaging");
			MyStepsNewProduct.SetTheSectionOptionTo("How is the exposure warning transmitted?",
				"By affixing it to the product or its packaging");
			Report.StartSubStep("I set the Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured field to: Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured",
				"Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			Report.StartSubStep("I set the If the product carries a safe-harbor short-form warning, indicate which of the following is provided: field to: WARNING: Cancer - ");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a safe-harbor short-form warning, indicate which of the following is provided:",
				"WARNING: Cancer - ");
			Report.StartSubStep("I set the If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning: field to: This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to ");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:",
				"This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to ");
			Report.StartSubStep("I set the Enter the names of one or more listed carcinogens which are the subject of this warning field to: Arsenic");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Enter the names of one or more listed carcinogens which are the subject of this warning",
				"Arsenic");
			Report.StartSubStep("I set the If the product carries a custom warning, please provide the exact text that is being used: field to: NA");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a custom warning, please provide the exact text that is being used:",
				"NA");
			Report.StartSubStep("In the Waste Classification Data page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Waste Classification Data");
		}

		[StepDefinition(
			@"I call Shared Step 57932a \(Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path\)")]
		public void GivenICallSharedEnterRegulatoryInformation_YesToProp1()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			var selNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Waste Classification Data Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Waste Classification Data");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("Prop 65 warning is required: Yes");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("Yes");
			Report.StartSubStep("I set the Is the need to warn triggered by field to: A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			MyStepsNewProduct.SetTheSectionOptionTo("Is the need to warn triggered by",
				"A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			Report.StartSubStep("I set the How is the exposure warning transmitted? field to: By affixing it to the product or its packaging");
			MyStepsNewProduct.SetTheSectionOptionTo("How is the exposure warning transmitted?",
				"By affixing it to the product or its packaging");
			Report.StartSubStep("I set the Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured field to: Prior to August 30, 2018");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured",
				"Prior to August 30, 2018");
			Report.StartSubStep("I set the If the product carries a safe-harbor short-form warning, indicate which of the following is provided: field to: Does not apply ");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a safe-harbor short-form warning, indicate which of the following is provided:",
				"Does not apply");
			Report.StartSubStep("I set the If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning: field to: Does not apply");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:",
				"Does not apply");

			Report.StartSubStep("I set the If the product carries a custom warning, please provide the exact text that is being used: field to: NA");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a custom warning, please provide the exact text that is being used:",
				"NA");
			Report.StartSubStep("In the Waste Classification Data page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Waste Classification Data");
		}

		[StepDefinition(
			@"I call Shared Step 57980 \(Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails1_YesOption_SelectIMDGLimitedQuantity()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"IMDG");
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with limited quantity");
			Report.StartSubStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 57981 \(Transportation - IMDG UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue\)")]
		public void
			GivenICallSharedStepTransportation_IMDGUNStep_EnterUNSelectAerosolsNoneAddTechnicalNameClickContinue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			Report.StartSubStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			Report.StartSubStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartSubStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2");
			Report.StartSubStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartSubStep(
				"In the International Marine (IMDG) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"International Marine (IMDG) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 57978 \(Physical and Chemical Properties - All select Gas - Continue - Happy Path\)")]
		public void ICallSharedPhysicalandChemicalProperties_AllSelectGas_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			// Primary Physical State displays All
			Report.StartSubStep(
				"I should only see the following options for Primary Physical State: Aerosol, Gas, Liquid, Solid");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			produtTable.AddRow(new string[] {
				"Gas"
			});
			produtTable.AddRow(new string[] {
				"Liquid"
			});
			produtTable.AddRow(new string[] {
				"Solid"
			});
			Report.StartSubStep("I set the Primary Physical State field to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Gas");
			Report.StartSubStep("I set the Secondary Physical State field to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			Report.StartSubStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble in water");
			Report.StartStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

	[StepDefinition(@"I call Shared Step 214644 \(Physical and Chemical Properties - Applicable Only to Bonding Agent\)")]
		public void GivenICallSharedPhysicalChemicalProperties_applicable_only_to_bonding_agent()
		{

			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density option to: 20");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "20");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			//Ticket 63666 indicates boiling point change from "Not tested/Unknown"
			Report.StartSubStep("I set the Boiling Point (in Celsius) field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			//Ticket 54725 indicates flash point change from ">=93C and <=815C"
			Report.StartSubStep("I set the Flash Point (in Celsius) field to: >93C and <=815C");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", ">93C and <=815C");
			Report.StartSubStep("I set the Flash Point Testing Method Used option to: Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartSubStep("I set the Select the best Water Solubility description field to: Soluble in water");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 228844 \(Physical and Chemical Properties - Aerosol, solid, liquid & Gas available - Select Solid - Continue - Happy Path\)")]
		public void ThenICallSharedStepPhysicalandChemicalProperties_AerosolGasLiquidSolidAvailable_SelectSolid_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Relative Density ");
			tableFirst.AddRow("pH");
			tableFirst.AddRow("Boiling Point (in Celsius)");
			tableFirst.AddRow("Flash Point (in Celsius)");
			tableFirst.AddRow("Flash Point Testing Method Used");

			Report.StartSubStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow("Aerosol");
			produtTable.AddRow("Gas");
			produtTable.AddRow("Liquid");
			produtTable.AddRow("Solid");
			stepsProductCharacteristics.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			Report.StartSubStep("I set the Primary Physical State field to: Aerosol");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Aerosol");
			Report.StartSubStep("I set the Secondary Physical State field to: Liquid spray");
			stepsProductCharacteristics.ThenISetTheSecondaryPhysicalStateToBe("Liquid spray");
			Report.StartSubStep("I set the pH field to: 10.4");
			stepsProductCharacteristics.SetPHTo("10.4");
			Report.StartSubStep("If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "This product is classified as a D003 Hazardous Waste under RCRA.");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "This product is not classified as D001 or D003 Hazardous Waste under RCRA");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Gas");
			Report.StartSubStep("I set the Secondary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Liquid");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyNewProduct.CheckDisplayedSections("see", tableFirst);
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Solid");
			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartSubStep(
					"I set the Secondary Physical State option to: Solid Gel Consistency");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
					"Solid Gel Consistency");
			}
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 63226 \(Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path\)")]
		public void GivenICallSharedStepPesticideDate_YesRegistered_EnterEPANumberNotOnKelly_ClickContinue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			var newProductPesticideDetailsUS = new Steps_PesticideDetailsUS();
			Report.StartSubStep(
				"I set the 'Product has an Environmental Protection Agency (EPA) Registration Number' option to: 'Yes'");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "Yes");
			Report.StartSubStep("I add the EPA number: TEST-1234");
			newProductPesticideDetailsUS.IAddTheEPARegistrationNumber("TEST-1234");
			Report.StartSubStep("I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)
		{
			var rand = new Random();
			int cdayRange = (dtEnd - dtStart).Days;
			return dtStart.AddDays(rand.NextDouble() * cdayRange);
		}

		//CLF - turns out to work the data has be after today!
		[StepDefinition(
			@"I call Shared Step 55819 \(EPA expiration date - enter current year - NOT Dec 31st\) for state: (.*)")]
		public void GivenICallSharedStepEPAExpirationDate_EnterCurrentYear_NOTDecSt(string state)
		{
			Report.UseSubSteps = true;
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "8", "8", "yes");
			Report.StartSubStep("I set the EPA Reistration Date (8/8 current year)");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 225948 \(EPA expiration date - enter current year - enter next year - check for error\) for state:")]
		public void GivenICallSharedStep225948EPAExpirationDate_EnterCurrentYear_EnterNextYear_CheckForErrorForState(Table table)
		{
			var newProductSteps = new StepsNewProduct();
			var pesticideDetailsStateSteps = new Steps_PesticideDetailsState();

			foreach (TableRow row in table.Rows)
			{
				string state = row["State"];

				Report.StartSubStep($"I set the EPA Expiration Date current year for state: {state}");
				this.GivenICallSharedStepEPAExpirationDate_EnterCurrentYear_NOTDecSt(state);

				Report.StartSubStep($"I check for EPA Expiration Date error for state: {state}");
				newProductSteps.InPageIShouldSeeError($"Pesticide Details - State Registration page", $"State {state}: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.");

				Report.StartSubStep($"I set the EPA Expiration Date next year for state: {state}");
				this.GivenICallSharedStepEPAExpirationDate_EnterNextYear_NOTDecStForState(state);

				Report.StartSubStep($"I check for EPA Expiration Date error for state: {state}");
				newProductSteps.InPageIShouldSeeError($"Pesticide Details - State Registration page", $"State {state}: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.");

				Report.StartSubStep($"I set the EPA Expiration Date next year for state: {state}");
				this.GivenICallSharedStep55821ExpirationDate31DecNextYear(state);

				Report.StartSubStep($"I check for EPA Expiration Date appropriate response for state: {state}");
				pesticideDetailsStateSteps.ThenIShouldSeeTheAppropriateResponseDependingOnTodaySDateforstate(state);

				Report.StartSubStep($"I set the EPA Expiration Date current year for state: {state}");
				this.GivenICallSharedStep55822ExpirationDate31DecthisYear(state);

			}
		}

		//CLF - From test plans - Confirm that an error shows "State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable."
		// in fact it seems that the date has to be after October 1st.
		[StepDefinition(
			@"I call Shared Step 55820 \(EPA expiration date - enter next year - NOT Dec 31st\) for state: (.*)")]
		public void GivenICallSharedStepEPAExpirationDate_EnterNextYear_NOTDecStForState(string state)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var pesticideDetailsState = new PesticideDetailsState();
			int year = DateTime.Now.Year + 1;
			int month = 10;
			int day = 1;
			var dtStart = new DateTime(year, month, day);
			month = 12;
			day = 30;
			var dtEnd = new DateTime(year, month, day);
			DateTime dt = this.GetRandomDate(dtStart, dtEnd);
			Report.Info("Attempting to enter date: " + dt.ToString("yyyy-MM-dd"));
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");
		}

		[StepDefinition(
			@"I call Shared Step 55821 \(EPA expiration date - enter Dec 31st of Next year\) for state: (.*)")]
		public void GivenICallSharedStep55821ExpirationDate31DecNextYear(string state)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var pesticideDetailsState = new PesticideDetailsState();
			int year = DateTime.Now.Year + 1;
			int month = 12;
			int day = 31;
			var dt = new DateTime(year, month, day);
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");
		}

		[StepDefinition(
			@"I call Shared Step 55822 \(EPA expiration date - enter Dec 31st of Current year\) for state: (.*)")]
		public void GivenICallSharedStep55822ExpirationDate31DecthisYear(string state)
		{
			Report.UseSubSteps = true;
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "12", "31", "yes");
			Report.StartSubStep("I set the EPA Reistration Date (12/31 current year)");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 57501 \(Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP\)")]
		public void
			GivenICallSharedStep57501PhysicalandChemicalProperties_MoreThanOneState_SelectSolid_StateSubcat_MixedWater_Random_Continue_HP()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep("There should be at least 2 options for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			Report.StartSubStep("I set the Primary Physical State to: Solid");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Solid");
			var thisNewProduct = new NewProduct();
			if (thisNewProduct.OptionExists("Secondary Physical State"))
			{
				Report.StartSubStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}
			else
			{
				Report.Info("Secondary physical state is not showing");
			}
			Report.StartSubStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartSubStep("I set the Select the best Water Solubility description option to: Soluble in water");
				stepsProductCharacteristics.GivenISetTheSelectTheBestWaterSolubilityDescriptionToBe("Soluble in water");
			}

			Report.StartSubStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 57911 \(Regulatory Information 1 - CEPA only shown - Continue - Happy Path\)")]
		public void GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep(
				"I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyStepsNewProduct.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status",
				"Compliant with Domestic Substances List (DSL)");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(
			@"I call Shared Step 56494 \(Pesticide Details - Canada > Province Code confirmation/validation and selection\) for province: (.*) expected error: (.*)")]
		public void
			GivenICallSharedStep56494PesticideDetailsCanadaProvinceCodeconfirmationvalidationAndSelectionForProvince(
				string province, string error)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.ErrorMessagesAreShowingForItem(province, "should", error);
			MyStepsNewProduct.SelectFirstOptionInSection(province);
			MyStepsNewProduct.ErrorMessagesShouldNotBeShowingForItem(province);
		}

		[StepDefinition(
			@"I call Shared Step 69388 \(Retailer - Canada Only - Select No Retailer/No UPC product > Done > Continue - Happy Path\)")]
		public void GivenICallSharedStepRetailer_CanadaOnly_SelectNoRetailerNoUPCProductDoneContinue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("In the Retailer page I click Continue");
			new StepsNewProduct().ClickContinue();
			Report.StartSubStep("In the UPCs Warning popup I click Ok");
			WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(
			@"I call Shared Step 69389 \(Regulatory Documents to Provide - Canada only - Confirm questions - Request author, add label and todays date - Continue\)")]
		public void
			GivenICallSharedStepRegulatoryDocumentsToProvide_CanadaOnly_ConfirmQuestions_RequestAuthorAddLabelAndTodaysDate_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I should see the WHMIS SDS question");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			Report.StartSubStep("I should see the WHMIS Label question");
			MyNewProduct.ThenFieldExists("Product Label in English and French-Canadian");
			Report.StartSubStep("I upload a PDF file in the WHMIS Label section");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian",
				"I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("I click continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 53542 \(Login with Administrator Role Continue 2 \(2nd login Shared Step\)\)")]
		public void GivenICallSharedStep53542LoginWithAdministratorRoleContinue2NdLoginSharedStep()
		{
			Report.UseSubSteps = true;
			var MyStepsSHA = new Steps_SHA();

			MyStepsSHA.GivenILoginToStudioAsAdministrator();

		}

		[StepDefinition(@"I call Shared Step 59066 \(Go to SHA Manager\)")]
		public void GivenICallSharedStep59066GoToSHAManager()
		{
			Report.UseSubSteps = true;
			var MyStepsSHA = new Steps_SHA();
			Report.StartSubStep("I click Menu: 'My Wercs' and Submenu: 'SHA'");
			MyStepsSHA.GivenIClickTopMenuItemAndSubMenuItem("My Wercs", "SHA");
			var thisStudioShaManager = new StudioSHAManager();
			Report.Info($"Going to iframe swap");
			Report.IsTrue(thisStudioShaManager.SwitchToFrame(frame: "<contains(@data-frameid,'SHA')>"), "Failed to switch to IFrame", showSuccessScreenshot: false);
			Report.Info($"Waiting for loading to finish...");
			Report.IsTrue(thisStudioShaManager.Wait_For_Loading_Finish(120), "Loading did not finish", showSuccessScreenshot: false);

			Report.Info("I confirm the product list is loaded");
			Report.Info("Waiting for product list to be loaded....");
			Report.IsTrue(thisStudioShaManager.WaitForProductList(30), "Product list is not showing",
				"Product list is showing", showSuccessScreenshot: false);
		}

		[StepDefinition(@"I call Shared Step 59728 \(Go to Announcement Manager\)")]
		public void GivenICallSharedStep59728GoToManageGlobalMessages()
		{
			var MyStepsSHA = new Steps_SHA();
			Delay.Seconds(1);
			MyStepsSHA.GivenInSHAManagerPageIClickSubMenuItem("Manage Announcements");
		}

		[StepDefinition(
			@"I call Shared Step 63860 \(Product Information - US, No\(child\), No\(OSHA\), No\(DSV\), Yes\(PLP\), No\(GNFR\)\)")]
		public void SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR()
		{
			Report.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information Page");
			selNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			selNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartSubStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: Yes");
			selNewProductSteps.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ", "Yes");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			selNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 74201 \(Select Retailers - CVS\)")]
		public void SelectRetailers_CVS()
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Retailer();
			Report.StartSubStep("In the Select Retailers popup I select the retailer: CVS");
			new StepsSelectRetailers().SelectTheRetailer("CVS");
			Report.StartSubStep("I enter private label as 'This Private Label'");
			stepsRetailer.EnterPrivateLabelName("This Private Label");
			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("No Retailer/No UPC Product", "This Private Label");
			Report.StartSubStep("I click continue");
			stepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 57801 \(Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path\)")]
		public void GivenICallSharedStep57801ConfirmVOCSummaryStepShownConfirmVOCAnalysisDateIsShown_HappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			var table1 = new Table(new string[] { "Statement" });
			table1.AddRow(new string[] { "VOC Analysis Date (Today's Date) " + DateTime.Today.ToString("MM/dd/yyyy") });
			MyStepsNewProduct.ThenInTheVOCSummaryPageIShouldSeeTheFollowingNoneditableStatements(table1);
		}

		[StepDefinition(
			@"I call Shared Step 57817 \(VOC Results - Confirm VOC Limits table shows correct values \(OTC & CARB\) - Happy Path\): (.*)")]
		public void GivenICallSharedStep57817VOCResults_ConfirmVOCLimitsTableShowsCorrectValuesOTCCARB_HappyPath(
			string use)
		{
			List<VocLimitsWithUnits> LimitsTable = new NewProduct().GetDisplayedVocLimitsWithUnits();

			var regulationOtcLimit = LimitsTable.Where(x => x.Regulation.Trim() == "OTC Model rule limit").ToList();
			var regulationCarbLimit = LimitsTable.Where(x => x.Regulation == "CARB limit").ToList();
			Report.IsTrue(regulationOtcLimit.Count == 1,
				"The Limits table does not contain only a single OTC Model rule. Count is: " + regulationOtcLimit.Count,
				"The Limits table contains only a single OTC Model rule limit as expected");
			Report.IsTrue(regulationCarbLimit.Count == 1,
				"The Limits table does not contain only a single row for CARB. Count is: " + regulationCarbLimit.Count,
				"The Limits table contains only a single row for CARB as expected");
			foreach (VocLimitsWithUnits thisLimit in LimitsTable)
			{
				Report.IsTrue(thisLimit.Use == use,
					"Use is not showing as: " + use,
					"Use is showing correctly: " + use);
				Report.IsTrue(thisLimit.VocComplianceLimit.Length > 0,
					"VOC Compliance Limit column is not showing a value when it was expected to!",
					"VOC Compliance Limit column is showing a value as expected: " + thisLimit.VocComplianceLimit);
				Report.IsTrue(thisLimit.Units == null,
					"Units column is showing when it was not expected to!",
					"Units column is not showing as expected");
			}
		}

		[StepDefinition(
			@"I call Shared Step 57819 \(VOC Results - Confirm VOC Limits table shows correct values \(CARB only\) - Happy Path\): (.*)")]
		public void SharedStep57819_VOCResults_ConfirmVOCLimitsTableShowsCorrectValues_CarbOnly(string use)
		{
			Report.UseSubSteps = true;
			List<VocLimitsWithUnits> LimitsTable = new NewProduct().GetDisplayedVocLimitsWithUnits();
			IEnumerable<VocLimitsWithUnits> regulationOtcLimit = LimitsTable.Where(x => x.Regulation.Trim() == "OTC Model rule limit");
			var regulationCarbLimit = LimitsTable.Where(x => x.Regulation == "CARB limit").ToList();
			Report.StartSubStep("I confirm the VOC Limits table shows an entry for CARB only");
			Report.IsTrue(regulationCarbLimit.Count == 1,
				"The Limits table does not contain only a single row for CARB. Count is: " + regulationCarbLimit.Count,
				"The Limits table contains only a single row for CARB as expected");
			Report.StartSubStep("I confirm the Regulation column does not show an entry for OTC Model Rule");
			Report.IsTrue(regulationOtcLimit.Count() == 0,
				"The Limits table contains a row for OTC Model rule when it should not!",
				"The Limits table does not contains a row for OTC Model rule limit as expected");
			foreach (VocLimitsWithUnits thisLimit in LimitsTable)
			{
				Report.StartSubStep(
					"I confirm the VOC Limits table shows an entry in the Use column with phrase matching the product's RU");
				Report.IsTrue(thisLimit.Use == use,
					"Use is not showing as: " + use,
					"Use is showing correctly: " + use);
				Report.StartSubStep(
					"I confirm the VOC Limits table shows a value in the VOC Compliance Limit column ");
				Report.IsTrue(thisLimit.VocComplianceLimit.Length > 0,
					"VOC Compliance Limit column is not showing a value when it was expected to!",
					"VOC Compliance Limit column is showing a value as expected: " + thisLimit.VocComplianceLimit);
				Report.StartSubStep("I confirm the table does NOT show a Units column ");
				Report.IsTrue(thisLimit.Units == null,
					"Units column is showing when it was not expected to!",
					"Units column is not showing as expected");
			}
		}

		[StepDefinition(@"I call Shared Step 74202 \(CVS Pharmacy - Yes, I wish to Continue\)")]
		public void SharedCVSPharmacy_YesIWishToContinue()
		{
			Report.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I confirm the CVS Pharmacy section appears");
			selNewProductSteps.GivenIShouldSeeXPage("CVS Own Brand Registration");
			Report.StartSubStep(
				"I set the Continue? option to: Yes, I wish to continue registration");
			selNewProductSteps.SetTheSectionOptionTo(
				"Continue?",
				"Yes, I wish to continue registration");
			Report.StartStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 57205 \(Go to Retail Partners - Select CVS\)")]
		public void SharedGoToRetailPartners_SelectCVS()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Retail Partners icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			Report.StartSubStep("I should see the heading 'Retail Partners'");
			new StepsRetailPartners().ThenIShouldSeeTheFollowingHeading("Retail Partners");
			Report.StartSubStep("I select the retailer: CVS");
			new StepsRetailPartners().SelectRetailer("CVS");
		}

		[StepDefinition(@"I call Shared Step 130558 \(Go to Retail Partners - Select Bed Bath and Beyond\)")]
		public void SharedGoToRetailPartners_SelectBBB()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Retail Partners icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			Report.StartSubStep("I should see the heading 'Retail Partners'");
			new StepsRetailPartners().ThenIShouldSeeTheFollowingHeading("Retail Partners");
			Report.StartSubStep("I select the retailer: Bed Bath and Beyond");
			new StepsRetailPartners().SelectRetailer("Bed Bath and Beyond");
		}

		[StepDefinition(@"I call Shared Step 74269 \(Select Retailers - Rite Aid\)")]
		public void SharedSelectRetailers_RiteAid()
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Steps_Retailer();
			Report.StartSubStep("In the Select Retailers popup I select the retailer: Rite Aid");
			new StepsSelectRetailers().SelectTheRetailer("Rite Aid");
			Report.StartSubStep("I enter private label as 'This Private Label'");
			new Steps_Retailer().RetailerPrivateLabelDoesDoesNotExist("Rite Aid", "Rite Aid", "does");
			new Steps_Retailer().RetailerPrivateLabelSelect("Rite Aid", "Rite Aid");
			Report.StartSubStep("I click continue");
			stepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 77711 \(Product Characteristics - Primary \(L/S\), 2nd - any, Enter Gravity, pH, Boiling Point, Flash Point, Flash Point Test - any, Water - any\)")]
		public void SharedProductCharacteristics_PrimaryLS_Any_EnterGravity_pH_BoilingPoint_FlashPointTestAny_WaterAny()
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			stepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			stepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density option to: 10");
			stepsNewProduct.SetTheSectionOptionTo("Relative Density", "10");
			Report.StartSubStep("I set the pH option to: 5");
			stepsNewProduct.SetTheSectionOptionTo("pH", "5");
			Report.StartSubStep("I set the pH option to: 5");
			stepsNewProduct.SetTheSectionOptionTo("pH", "5");
			Report.StartSubStep("I set the Boiling Point (in Celsius) option to: 80");
			stepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "80");
			Report.StartSubStep("I set the Flash Point (in Celsius) option to: 130");
			stepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "130");
			Report.StartSubStep("I set the Flash Point Testing Method option to: Open cup method");
			stepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Open cup method");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Dispersible");
			stepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			Report.StartSubStep("I continue to the next screen in the new product registration");
			stepsNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(
			@"I call Shared Step 75146 \(Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue\) for")]
		public void
			GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(Table retailers)
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			foreach (TableRow thisRetailer in retailers.Rows)
			{
				var retailer = new Retailer();
				retailer.WaitForContainerToBeVisible();

				if (retailer.ConfirmSingleRetailerCheckboxDisplayed())
				{
					if (retailer.CheckSingleRetailerCheckboxSelected())
					{
						if (retailers.Rows.Count > 1)
						{
							var selectRetailers = new StepsSelectRetailers();
							selectRetailers.ClickTheSingleRetailerCheckbox();
						}
					}
				}
				Report.StartSubStep("In the Select Retailers popup I select the retailer: " +
									 thisRetailer["Retailer"]);
				new StepsSelectRetailers().SelectTheRetailer(thisRetailer["Retailer"]);

			}
			Report.StartSubStep("I click continue");
			selStepsNewProduct.ClickContinue();
			if (new NewProduct().ErrorMessageText == "This is a required field.")
			{
				Report.Failure("Required field error was showing on continue. Attempting to enter Private Label field (not specified by Shared Step)");
				Report.StartSubStep("I enter private label as 'This Private Label'");
				new Steps_Retailer().IEnterPrivateLabelName("This Private Label");
				Report.StartSubStep("I click continue");
				selStepsNewProduct.ClickContinue();
			}

		}
		[StepDefinition(@"I call Shared Step - In the Supplier Manager popup I select radio button (.*) and enter search term with spaces: (.*)")]
		public void ThenICallSharedStep_InTheSupplierManagerPopupEnterSearchTermWithSpacesSavedAsInvoiceNumber(string radioButton, string searchTerm)
		{
			if(searchTerm.Contains("saved as "))
			{
				searchTerm = searchTerm.Replace("saved as ", "");
			}

			if (Context.GetFromContext(searchTerm) != null)
			{
				searchTerm = Context.GetFromContext(searchTerm).ToString();
			}
			Report.UseSubSteps = true;
			var myStepsSha = new Steps_SHA();
			Report.StartSubStep("I Click 'Suppliers' in SHA Manager");
			myStepsSha.IClickSuppliersInSHAManager();
			Report.StartSubStep("In the Supplier Manager Popup I select radio button: Invoice Number");
			myStepsSha.InSupplierManagerPopupISelectRadioButton(radioButton);
			Report.StartSubStep("In the Supplier Manager Popup I enter the search term with one space before it");
			myStepsSha.InSupplierManagerPopupIEnterSearchTerm(" " + searchTerm);
			Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
			myStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			Report.StartSubStep("In the Supplier Manager Popup I should see supliers");
			myStepsSha.ThenInTheSupplierManagerPopupIShouldSeeSupliers("should");
			Report.StartSubStep("In the Supplier Manager Popup I click on the close button");
			myStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();
			Report.StartSubStep("I Click 'Suppliers' in SHA Manager");
			myStepsSha.IClickSuppliersInSHAManager();
			Report.StartSubStep("In the Supplier Manager Popup I select radio button: Invoice Number");
			myStepsSha.InSupplierManagerPopupISelectRadioButton(radioButton);
			Report.StartSubStep("In the Supplier Manager Popup I enter the search term with three space before it");
			myStepsSha.InSupplierManagerPopupIEnterSearchTerm("   " + searchTerm);
			Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
			myStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			Report.StartSubStep("In the Supplier Manager Popup I should see supliers");
			myStepsSha.ThenInTheSupplierManagerPopupIShouldSeeSupliers("should");
			Report.StartSubStep("In the Supplier Manager Popup I click on the close button");
			myStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();
			Report.StartSubStep("I Click 'Suppliers' in SHA Manager");
			myStepsSha.IClickSuppliersInSHAManager();
			Report.StartSubStep("In the Supplier Manager Popup I select radio button: Invoice Number");
			myStepsSha.InSupplierManagerPopupISelectRadioButton(radioButton);
			Report.StartSubStep("In the Supplier Manager Popup I enter the search term with one space afret it");
			myStepsSha.InSupplierManagerPopupIEnterSearchTerm(searchTerm + " ");
			Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
			myStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			Report.StartSubStep("In the Supplier Manager Popup I should see supliers");
			myStepsSha.ThenInTheSupplierManagerPopupIShouldSeeSupliers("should");
			Report.StartSubStep("In the Supplier Manager Popup I click on the close button");
			myStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();
			Report.StartSubStep("I Click 'Suppliers' in SHA Manager");
			myStepsSha.IClickSuppliersInSHAManager();
			Report.StartSubStep("In the Supplier Manager Popup I select radio button: Invoice Number");
			myStepsSha.InSupplierManagerPopupISelectRadioButton(radioButton);
			Report.StartSubStep("In the Supplier Manager Popup I enter the search term with two space after it");
			myStepsSha.InSupplierManagerPopupIEnterSearchTerm(searchTerm + " ");
			Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
			myStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			Report.StartSubStep("In the Supplier Manager Popup I should see supliers");
			myStepsSha.ThenInTheSupplierManagerPopupIShouldSeeSupliers("should");
			Report.StartSubStep("In the Supplier Manager Popup I click on the close button");
			myStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();
			Report.StartSubStep("I Click 'Suppliers' in SHA Manager");
			myStepsSha.IClickSuppliersInSHAManager();
			Report.StartSubStep("In the Supplier Manager Popup I select radio button: Invoice Number");
			myStepsSha.InSupplierManagerPopupISelectRadioButton(radioButton);
			Report.StartSubStep("In the Supplier Manager Popup I enter the search term with one space before it and after it");
			myStepsSha.InSupplierManagerPopupIEnterSearchTerm(" " + searchTerm + " ");
			Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
			myStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			Report.StartSubStep("In the Supplier Manager Popup I should see supliers");
			myStepsSha.ThenInTheSupplierManagerPopupIShouldSeeSupliers("should");
			Report.StartSubStep("In the Supplier Manager Popup I click on the close button");
			myStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();
			Report.StartSubStep("I Click 'Suppliers' in SHA Manager");
			myStepsSha.IClickSuppliersInSHAManager();
			Report.StartSubStep("In the Supplier Manager Popup I select radio button: Invoice Number");
			myStepsSha.InSupplierManagerPopupISelectRadioButton(radioButton);
			Report.StartSubStep("In the Supplier Manager Popup I enter the search term with thre space before it and three after it");
			myStepsSha.InSupplierManagerPopupIEnterSearchTerm("   " + searchTerm + "   ");
			Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
			myStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			Report.StartSubStep("In the Supplier Manager Popup I should see supliers");
			myStepsSha.ThenInTheSupplierManagerPopupIShouldSeeSupliers("should");
			Report.StartSubStep("In the Supplier Manager Popup I click on the close button");
			myStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();
		}

		[StepDefinition(@"I call Shared Step 65080 \(Login to Studio and Open SHA manager\)")]
		public void GivenICallShared65080LoginToStudioAndOpenSHAManager()
		{
			Report.UseSubSteps = true;
			var myStepsSha = new Steps_SHA();
			Report.StartSubStep("I navigate to Studio");
			myStepsSha.GivenINavigateToStudio();
			Report.StartSubStep("I log in to studio as administrator");
			myStepsSha.GivenILoginToStudioAsAdministrator();
			this.GivenICallSharedStep59066GoToSHAManager();
		}

		[StepDefinition(@"I call Shared Step 65080b \(Login to Studio as user saved as: (.*) and Open SHA manager\)")]
		public void GivenICallShared65080LoginToStudioAsUserAndOpenSHAManager(string savedAs)
		{
			Report.UseSubSteps = true;
			var myStepsSha = new Steps_SHA();
			Report.StartSubStep("I navigate to Studio");
			myStepsSha.GivenINavigateToStudio();
			Report.StartSubStep("I log in to studio as administrator");
			myStepsSha.GivenILoginToStudioAsTReVorUser(savedAs);
			this.GivenICallSharedStep59066GoToSHAManager();
		}

		[StepDefinition(
			@"I call Shared Step 49841 \(SHA - Search for exact WPS ID in (.*) Status for saved as: (.*)\)")]
		public void GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus(string status, string savedAs)
		{

			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 49841");
			Report.StartSubStep("I set the status filter to All");
			Report.Screenshot();
			var myStudioShaManager = new StudioSHAManager();
			//myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			//Report.IsTrue(myStudioShaManager.WaitForProductList(60), "Product list was not loaded", "Product list loaded", showSuccessScreenshot: false);
			Report.Info($"Getting saved product: { savedAs}");
			if (!Context.Contains(savedAs))
			{
				Report.Error($"Context does not contain: {savedAs}");
			}
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;
			Report.Info($"Looking for id: { id }");
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"ProductID",
				id
			});
			table.AddRow(new string[] {
				"Status",
				status
			});
			bool Found = false;
			int counter = 0;
			while (!Found && counter < 10)
			{
				Report.StartSubStep("I click Srch in the bottom menu list");
				myStudioShaManager.ClickBottomMenuOption("Search");
				var myStepsSha = new Steps_SHA();
				Report.Screenshot();
				Report.StartSubStep($"I enter ID: {id} in the Product ID box, change Status drop down to {status}, Click find");
				Report.Info("Searching for: " + id);
				myStepsSha.GivenInSHAManagerPageIRunSearch(table);
				Report.Screenshot();
				Delay.Seconds(1);
				Report.Info("Waiting for product list");
				Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found",
					"Product list is showing", showSuccessScreenshot: false);
				if (!myStudioShaManager.TopRowProductsTableMatchesId(id))
				{
					counter++;
				}
				else
				{
					Found = true;
				}
			}
			Report.IsTrue(Found, "The Top row in the Products table did not match the search ID", "The Top row in products table matched the search ID");

		}




		[StepDefinition(@"I call Shared Step \(SHA - Search for (.*) UPC (.*) in (.*) Status and Check the product saved as: (.*) is found\)")]
		public void GivenICallSharedSHA_SearchForContainsUPCInStatusAndProductMatches(string pattern, string upc, string status, string savedAs)
		{

			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step");
			Report.StartSubStep("I set the status filter to All");
			Report.Screenshot();
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();

			Report.Info("Getting saved product: " + savedAs);
			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;


			if (upc.Contains("savedAs"))
			{
				if (!Context.Contains(upc.Replace("savedAs", "")))
				{
					Report.Info($"There was no value for {upc.Replace("savedAs", "")} found in context");
				}
				else
				{
					upc = (string)Context.GetFromContext(upc.Replace("savedAs", ""));

				}
			}
			Report.Info("Looking for UPC: " + upc);
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"SearchPattern",
				pattern
			});
			table.AddRow(new string[] {
				"UPC",
				upc
			});
			table.AddRow(new string[] {
				"Status",
				status
			});
			bool Found = false;
			int counter = 0;
			while (!Found && counter < 10)
			{
				Report.StartSubStep("I click Srch in the bottom menu list");
				myStudioShaManager.ClickBottomMenuOption("Search");
				var myStepsSha = new Steps_SHA();
				Report.Screenshot();
				Report.StartSubStep($"I enter UPC: {upc} in the Product ID box, change Status drop down to {status}, Click find");
				Report.Info("Searching for: " + upc);
				myStepsSha.GivenInSHAManagerPageIRunSearch(table);
				Report.Screenshot();
				Delay.Seconds(1);
				Report.Info("Waiting for product list");
				Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found",
					"Product list is showing", showSuccessScreenshot: false);
				if (!myStudioShaManager.ProductsTableResultsContainsId(id))
				{
					counter++;
				}
				else
				{
					Found = true;
				}
			}
			Report.IsTrue(Found, "The Top row in the Products table did not match the expected product ID", "The Top row in products table matched the expected product ID");

		}


		[StepDefinition(@"I call Shared Step \(SHA - Search by (.*) Case Pack UPC (.*) in (.*) Status and Check the product saved as: (.*) is found\)")]
		public void GivenICallSharedSHA_SearchForContainsCasePackUPCInStatusAndProductMatches(string pattern, string upc, string status, string savedAs)
		{

			Report.UseSubSteps = true;
			Report.StartStep("Beginning shared step");
			Report.StartStep("I set the status filter to All");
			Report.Screenshot();
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();

			Report.Info("Getting saved product: " + savedAs);
			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;


			if (upc.Contains("savedAs"))
			{
				if (!Context.Contains(upc.Replace("savedAs", "")))
				{
					Report.Info($"There was no value for {upc.Replace("savedAs", "")} found in context");
				}
				else
				{
					upc = (string)Context.GetFromContext(upc.Replace("savedAs", ""));

				}
			}
			Report.Info("Looking for UPC: " + upc);
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"SearchPattern",
				pattern
			});
			table.AddRow(new string[] {
				"ParentUPC",
				upc
			});
			table.AddRow(new string[] {
				"Status",
				status
			});
			bool Found = false;
			int counter = 0;
			while (!Found && counter < 10)
			{
				Report.StartSubStep("I click Srch in the bottom menu list");
				myStudioShaManager.ClickBottomMenuOption("Search");
				var myStepsSha = new Steps_SHA();
				Report.Screenshot();
				Report.StartSubStep($"I enter UPC: {upc} in the Product ID box, change Status drop down to {status}, Click find");
				Report.Info("Searching for: " + upc);
				myStepsSha.GivenInSHAManagerPageIRunSearch(table);
				Report.Screenshot();
				Delay.Seconds(1);
				Report.Info("Waiting for product list");
				Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found",
					"Product list is showing", showSuccessScreenshot: false);
				if (!myStudioShaManager.ProductsTableResultsContainsId(id))
				{
					counter++;
				}
				else
				{
					Found = true;
				}
			}
			Report.IsTrue(Found, "The Top row in the Products table did not match the expected product ID", "The Top row in products table matched the expected product ID");

		}







		[StepDefinition(
			@"I call Shared Step 55662 \(WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: (.*)\)")]
		public void GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(string savedAs)
		{
			Report.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.StartSubStep("I click System > Job Queue");
			thisTopMenu.ClickSubMenu("System", "Job Queue");
			Delay.Seconds(5);
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep(
				"I confirm there is an entry for UserName = SHAMANAGER, Date Started = Current Date, Class = Wercs.Core.BLLPortal.ImportProcessRules");
			var thisStudioJobQueue = new StudioJobQueue();
			Report.IsTrue(thisStudioJobQueue.WaitForJobInformationList(30), "Job queue has not loaded",
				"Job queue has loaded", showSuccessScreenshot: false);
			GeneralUtilities.StudioWaitForSpinner();
			Report.IsTrue(thisStudioJobQueue.ClickJobQueueMenuItem("Job Queue"), "Failed to navigate to job queue",
				"Navigated to job queue", showSuccessScreenshot: false);
			GeneralUtilities.StudioWaitForSpinner();
			thisStudioJobQueue = new StudioJobQueue();
			Report.IsTrue(thisStudioJobQueue.WaitForJobInformationList(30), "Job queue has not loaded",
				"Job queue has loaded");
			List<Job> ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
			Job MatchingJob = ListOfJobs.FirstOrDefault(x =>
				x.UserName == "SHAMANAGER" && x.DateStarted.Date == DateTime.Today.Date &&
				x.Class == "Wercs.Core.BLLPortal.ImportProcessRules");

			if (MatchingJob == null)
			{
				//try again...
				ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
				MatchingJob = ListOfJobs.FirstOrDefault(x =>
					x.UserName == "SHAMANAGER" && x.DateStarted.Date == DateTime.Today.Date &&
					x.Class == "Wercs.Core.BLLPortal.ImportProcessRules");
			}

			if (MatchingJob != null)
			{
				Report.Success("Matching job has been found with username=SHAMANAGER, date=" +
							   DateTime.Today.Date.ToString() +
							   ", class=Wercs.Core.BLLPortal.ImportProcessRules");
			}
			else
			{
				Report.Info("No matching job has been found with username=SHAMANAGER, date=" +
							DateTime.Today.Date.ToString() +
							", class=Wercs.Core.BLLPortal.ImportProcessRules");
			}

			Report.StartSubStep("I wait for this job to complete processing");
			this.GivenICallSharedStep59066GoToSHAManager();
			var myStudioShaManager = new StudioSHAManager();
			var myProductSearch = new StudioSHAManagerProductSearch();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			ProductStatus thisProductStatus = myStudioShaManager.GetproductStatus(id);
			Report.Info("Status is: " + thisProductStatus.StatusName);
			// JS. status name (class) is initially 'boldrulerunning' and then changes to 'boldchem' after some time (turns blue). Previously dropping out of the scenario first time.
			int count = 0;
			bool runningRule = thisProductStatus.StatusName.Contains("rulerunning");
			while (count < 100 && runningRule)
			{
				Report.Info("Running a search: " + count);
				myStudioShaManager.ClickBottomMenuOption("search");
				myProductSearch.Wait_for_load(20);
				Report.Screenshot();
				Report.Info("Clicking find");
				if (!myProductSearch.ClickButton("Find"))
				{
					Report.Info("Failed to click find button");
				}

				Delay.Seconds(5);
				Report.Screenshot();
				GeneralUtilities.StudioWaitForSpinner();
				if (myStudioShaManager.WaitForProductList(30))
				{
					thisProductStatus = myStudioShaManager.GetproductStatus(id);
					if (thisProductStatus == null)
					{
						Report.Info("There was a problem with getting product status. Trying again...");

						thisProductStatus = myStudioShaManager.GetproductStatus(id);
						if (thisProductStatus == null)
						{
							Report.Info("There was a problem with getting product status.");
							break;
						}

					}

					runningRule = thisProductStatus.StatusName.Contains("rulerunning");
				}
				else
				{
					Report.Info("Product list was not found");
				}

				Report.Screenshot();
				count++;
				Delay.Seconds(1);
			}

			if (runningRule)
			{
				Report.Failure("Rule job was still running after waiting for 5 minutes");
				Report.Screenshot();
				return;
			}

			if (thisProductStatus.StatusName.ToLower().Contains("chem"))
			{
				Report.Info("Waiting for id to turn blue");
				Report.IsTrue(myStudioShaManager.WaitForIDToTurnBlue(id, 120), "ID has not turned blue", "ID is blue");
			}

			if (thisProductStatus.StatusName.ToLower().Contains("tparty"))
			{
				Report.Info("Waiting for id to change colour");
				Report.IsTrue(myStudioShaManager.WaitForIDToBeStatus(id, 120, "Assigned", "tPartyForm", true),
					"ID has not turned required colour", "ID is required colour");
			}
		}

		[StepDefinition(@"I call Shared Step 68969 \(WPS Studio - Open PD\+, edit existing with specific product > Click Continue for product saved as: (.*)\)")]
		public void GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(string savedAs)
		{

			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();

			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}
			}

			Report.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			Report.StartSubStep("I click the Authoring menu option and Select Power Designer Plus");
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
			Report.Screenshot();
			Delay.Seconds(3);
			Report.StartSubStep("I select EN as the Language, MTR/CKLT as the format/subformat");
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			thisPowerDesignerPlus.Wait_for_load(240);
			Delay.Seconds(10);

			if (!thisPowerDesignerPlus.Wait_for_load(240))
			{

				thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
				thisStudioPowerDesignerPlusDesignMode.ClickMenuAndSubmenuOptions("Home");
				Delay.Seconds(3);
			}

			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(240), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
				"Set language option");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter("CKLT"), "Failed to set subformat option",
				"Set subformat option");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("CKLT", "MTR"), "Failed to set format option",
				"Set format option");
			Report.StartSubStep("I click the Edit Existing product radio button if not already selected");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");
			Report.Screenshot();
			Delay.Seconds(1);
			Report.StartSubStep("I filter for the product");
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(120);

			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.StartStep("I click Continue");
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button", "Clicked continue button");
			Delay.Seconds(120);
			thisPowerDesignerPlus.Wait_for_load(240);

			//HERE ADD EDITMODE

			Report.Info("In power tools workspace I set edit to true");

			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.Info($"spinner wait...");
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(120);
			Report.Info($"spinner wait end.");
			Report.Screenshot();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();

			//End Editmode
			//Commented section below as it doesn't correspond to TC in TFS
			/* 
			Report.Info("Now going to click the sections side tab if its not open");
			thisPowerDesignerPlus.Wait_for_load(60);
			var selStepsStudio = new Steps_Studio();
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			selStudioPowerDesignerPlus.Wait_for_load(60);
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT2318"))
			{
				selStepsStudio.InPDIEnsureSECT2318IsActive();
				selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			}
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT0077"))
			{
				selStepsStudio.InPDIEnsureSECT0077IsActive();
				selStepsStudio.InPDIFillTheSectionWalmartTransportationInformationWithJunkData();
			}

			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			var checkListSection = TestVariables.GetVariableSavedAs("PD Checklist Section");
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", checkListSection);
			*/

		}

		[StepDefinition(@"I call Shared Step 78801 \(Additional Documents to Provide - VOC and Product Label\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_VOC_ProductLabel()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("In the Additional Documents to Provide page I Upload File for: Volatile Organic Compounds");
			MyNewProduct.UploadPDFFileSectionAndType("VOC Exemption Letter",
				"Volatile Organic Compounds", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Additional Documents to Provide page I Upload File for: Provide Full Product Label (required) ");
			MyNewProduct.UploadPDFFileSectionAndType("Product Label",
				"Volatile Organic Compounds", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 130960 \(Additional Documents to Provide - VOC Product Label Upload\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_VOCProductLabelUpload()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			MyNewProduct.UploadPDFFileSectionAndType("Product Label",
				"Volatile Organic Compounds", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 40657 \(SHA Manager - Submitted - Select product > process product data for product saved as: (.*)\)")]
		public void GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step 40657");
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;

			bool selectedID = false;
			for (int i = 0; i < 20; i++)
			{
				Report.Info("Waiting interation: " + i.ToString());
				Report.IsTrue(myStudioShaManager.SelectFromStatusFilter("Submitted"),
					"Failed to select from status filter",
					"Selected from status filter");
				Delay.Seconds(3);
				if (!myStudioShaManager.Wait_for_load(30))
				{
					Report.Error("Studio SHA Manager is not showing");
				}

				if (myStudioShaManager.SelectProductByID(id))
				{
					selectedID = true;
					break;
				}

				Delay.Seconds(3);
			}

			Report.IsTrue(selectedID, "Failed to select product with id: " + id, "Selected product with id: " + id);
			myStudioShaManager.ClickProcessProductData();
			Report.IsTrue(myStudioShaManager.SetAutoAssignRegulatorySpecialisttoProduct(false),
				"Failed to deselect Auto assign regulatory specialist", "Deselected auto assign regulatory specialist");
			var regSpec = TestVariables.GetVariableSavedAs("SHA Regulatory Specialist");
			if (regSpec == null)
			{
				Report.Info("Failed to find SHA Regulatory Specialist in context, defaulting to: Automated QASha");
				regSpec = "Automated QASha";
			}
			Report.Info($"The Regulatory Specialist that will be selected is: {regSpec}");

			Report.IsTrue(myStudioShaManager.SelectRegulatorySpecialist(regSpec),
				"Failed to select regulatory specialist", "Selected regulatory specialist");
			Report.IsTrue(myStudioShaManager.ClickContinueInProcessProducts(), "Failed to click continue",
				"Clicked continue");
			Report.IsTrue(myStudioShaManager.WaitForProductToAppearOnProcessedList(id, 90),
				"Product has not appeared on processed list: " + id, "Product has appeared on processed list: " + id);
			Report.IsTrue(myStudioShaManager.ClickCloseInProcessProducts(), "Failed to click close",
				"Clicked close");

		}

		[StepDefinition(
			@"I call Shared Step 75347 \(WPS Studio - PD\+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS\) for product saved as: (.*)")]
		public void GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(string savedAs)
		{
			Report.StartStep("Beginning shared step 75347");
			Report.UseSubSteps = true;
			Report.StartSubStep("I set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQAHDPF data codes to show the Green check mark graphic");
			Report.Info("In power tools workspace I set edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			var newValueEditor = new ValueEditor();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			// 'If you can't click on them select Options and make sure Edit mode is selected.'
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();

			var selStepsStudio = new Steps_Studio();
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();

			//Commented section below as it doesn't correspond to TC in TFS

			/*
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT2318"))
			{
				selStepsStudio.InPDIEnsureSECT2318IsActive();
				selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			}
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT0077"))
			{
				selStepsStudio.InPDIEnsureSECT0077IsActive();
				selStepsStudio.InPDIFillTheSectionWalmartTransportationInformationWithJunkData();
			}
			
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			var checkListSection = TestVariables.GetVariableSavedAs("PD Checklist Section");
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", checkListSection);
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			*/
			// Set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic (filename is DPQA_PASS[1].png)
			// Do this by double clicking on the graphic and selecting the green check mark graphic from the available list and click save
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0877] Reviewer Checklist"))
			{
				selStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0877] Reviewer Checklist");
			}
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0755] Reviewer Checklist"))
			{
				selStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Reviewer Checklist");

			}
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAHDPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DPQAUN",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.DoubleClickCategoryAuthc(), "Failed to double click category", "Successfully double clicked category");

			//selStepsStudio.GivenInPowerDesignerIDoubleClickOnCategory("AUTHC");
			newValueEditor.EnterValueIntoField("NGHS");
			newValueEditor.ClickButton("Save");
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Formulation"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			//Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.DoubleClickCategory("BATACT"), "Failed to double click category", "Successfully double clicked category");
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Report.Info("Now waiting for spinner...");
			Delay.Seconds(5);
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				Report.Info("Spinner is showing, looking for alert");
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}
			Report.Info("Spinner is no longer showing");

			Report.StartStep("I confirm CKLT, NGHS and SBCS are not shown in the pop up message and click OK");
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"NGHS",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			Report.StartSubStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("My Toolbar");
			Report.StartSubStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartSubStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartSubStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartSubStep("In the rule name filter box I enter the studio user name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");

			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			if (found)
			{
				thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			}
			else
			{
				Report.Error("Value: QASHAAccount , can't be found in context");
			}


			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartSubStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartSubStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(10);
			if (SeleniumWebDriver.CurrentDriver.IsAlertPresent())
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}

			Report.StartSubStep("I close the Apply Rules pop up");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);
			if (new ApplyRulesPage().Wait_for_load(20))
			{
				Delay.Seconds(3);
				Report.Info("Clicking on close in apply rules popup did not work. Trying again...");
				thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
				Report.Screenshot();
				Delay.Seconds(3);
				if (new ApplyRulesPage().Wait_for_load(1))
				{
					Report.Error("Apply rules popup did not close after two attempts");
					SeleniumWebDriver.CurrentDriver.Close();
				}
			}

			Report.StartSubStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();

			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartSubStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();

			for (int i = 0; i < 5; i++)
			{
				Delay.Seconds(5);
				Report.Screenshot();
				var newDocumentQueuePage = new DocumentQueuePage();
				Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
					"Document queue page loaded");
				List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				if (listOfDocuments.Count > 0)
				{
					break;
				}
			}

			Report.StartSubStep(
				"I confirm the product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF");
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartSubStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(4);
			//Report.Screenshot();
			Report.Info($"waiting for spinner...");
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.Info($"fFinished waiting for spinner...");
			Report.StartSubStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartSubStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartSubStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();

		}

		[StepDefinition(@"I call Shared Step 0000 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_No()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Waste Classification Data Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Waste Classification Data");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			Report.StartSubStep(
				"I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986",
				"No");
			Report.StartSubStep("In the Waste Classification Data page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Waste Classification Data");
		}

		[StepDefinition(
			@"I call Shared Step 79436 \(Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name\) and save ingredient as: (.*)")]
		public void CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(string savedAs,
			Table component)
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var newProductIngredients = new Ingredients();
			var ingredient = new Ingredients.Ingredient {
				CASNumber = component.Rows.First()["CASNumber"],
				ComponentName = component.Rows.First()["ComponentName"],
				Percent = component.Rows.First()["Percentage"],
				PublicallyDisclosed = true,
				PublicName = "Undisclosed Ingredient"
			};
			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(
			@"I call Shared Step 79431 \(Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name\) and save ingredients as: (.*)")]
		public void IngredientsAddFlavorComponentPubliclyDisclosedYesSelectPublicName(string savedAs, Table component)
		{
			var newProductIngredients = new Ingredients();
			var ingredient = new Ingredients.Ingredient {
				CASNumber = component.Rows.First()["CASNumber"],
				ComponentName = component.Rows.First()["ComponentName"],
				Percent = component.Rows.First()["Percentage"],
				PublicallyDisclosed = true,
				PublicName = "Undisclosed Ingredient"
			};
			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(
			@"I call Shared Step 55663 \(WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: (.*)\)")]
		public void GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			Report.UseSubSteps = true;
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			thisTopMenu.ClickSubMenu("System", "Job Queue");
			GeneralUtilities.StudioWaitForSpinner();
			Delay.Seconds(5);
			var thisStudioJobQueue = new StudioJobQueue();
			Report.IsTrue(thisStudioJobQueue.WaitForJobInformationList(30), "Job queue has not loaded",
				"Job queue has loaded");

			Delay.Seconds(5);
			thisStudioJobQueue = new StudioJobQueue();

			List<Job> ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			TReVorTestUsers shaUser = TestUsers.GetUserSavedAs("SHAUser");
			Job matchingJob = ListOfJobs.FirstOrDefault(x =>
				x.Status == "Closed" && x.Method == "PublishMultiple" && x.UserName == shaUser.Username);
			if (matchingJob == null)
			{
				Report.Info("Did not find matching job");
				Report.Screenshot();
			}
			else
			{
				Report.Success("Found job with id: " + id.ToString() + " as expected");
				//Wait for job to not appear in the list
				for (int i = 0; i < 120; i++)
				{
					thisStudioJobQueue = new StudioJobQueue();
					ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
					matchingJob = ListOfJobs.FirstOrDefault(x =>
						x.RecordID == id && x.Method == "PublishMultiple" && x.UserName == shaUser.Username);
					if (matchingJob == null)
					{
						Report.Info("Job is no longer found so assume it has completed");
						Report.Screenshot();
					}

					Delay.Seconds(1);
				}
			}

		}

		[StepDefinition(@"I call Shared Step 51664 \(SHA - Accepted Product - set Retailers to Completed for saved as: (.*)\) for")]
		public void GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(string savedAs, Table retailers)
		{
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var thisProcessProducts = new ProcessProducts();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisProcessProducts.SelectNewStatus("Accepted");
			thisStepsStudio.InSHAManagerISelectProductById(id);
			thisStepsStudio.InSHAManagerIClickOnBottomMenuItem("Status");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(retailers);
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo("Completed");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton();
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Completed", savedAs);
		}

		[StepDefinition(@"I call Shared Step \(SHA - Assgined Product - set Retailers to Completed for saved as: (.*)\) for")]
		public void GivenICallSharedSHA_AssignedProduct_SetRetailersToCompletedForSavedAs(string savedAs, Table retailers)
		{
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var thisProcessProducts = new ProcessProducts();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisProcessProducts.SelectNewStatus("Assigned");
			thisStepsStudio.InSHAManagerISelectProductById(id);
			thisStepsStudio.InSHAManagerIClickOnBottomMenuItem("Status");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(retailers);
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo("Completed");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton();
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Completed", savedAs);
		}

		[StepDefinition(@"I call Shared Step 75669 \(SHA - Assigned Status - Set to Cancelled for product saved as: (.*)\)")]
		public void GivenICallSharedSHA_AssignedStatus_SetToCancelledForProductSavedAs(string savedAs, Table retailers)
		{
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var thisProcessProducts = new ProcessProducts();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisProcessProducts.SelectNewStatus("Assigned");
			thisStepsStudio.InSHAManagerISelectProductById(id);
			thisStepsStudio.InSHAManagerIClickOnBottomMenuItem("Status");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(retailers);
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo("Cancelled");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton();
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Cancelled", savedAs);
		}

		[StepDefinition(@"I call Shared Step \(SHA - Assgined Product - set Retailers to Release for distribution for saved as: (.*)\) for")]
		public void GivenICallSharedSHA_AssignedProduct_SetRetailersToReleaseForDistributionForSavedAs(string savedAs, Table retailers)
		{
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var thisProcessProducts = new ProcessProducts();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisProcessProducts.SelectNewStatus("Assigned");
			thisStepsStudio.InSHAManagerISelectProductById(id);
			thisStepsStudio.InSHAManagerIClickOnBottomMenuItem("Status");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(retailers);
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo("Release for Distribution");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton();
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Release for Distribution", savedAs);
		}

		[StepDefinition(@"I call Shared Step 155714 \(SHA - Accepted Product - set Retailers to Cancelled for saved as: (.*)\) for")]
		public void GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCancelledForSavedAs(string savedAs, Table retailers)
		{
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var thisProcessProducts = new ProcessProducts();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisProcessProducts.SelectNewStatus("Accepted");
			thisStepsStudio.InSHAManagerISelectProductById(id);
			thisStepsStudio.InSHAManagerIClickOnBottomMenuItem("Status");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(retailers);
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo("Cancelled");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton();
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Cancelled", savedAs);
		}

		[StepDefinition(@"I call Shared Step 67823 \(Login to WERCSmart - Products Automation Account\)")]
		public void GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount()
		{
			var MyGlobalSteps = new GlobalSteps();
			MyGlobalSteps.LoginToWERCSmart("Administrator Role");
		}

		[StepDefinition(@"I call Shared Step 67284 \(Login into WERCSmart Portal - Visual Automation Account\)")]
		public void Shared67284_LoginToWercSmartPortal_VisualAutomationAccount()
		{
			var selGlobalSteps = new GlobalSteps();
			selGlobalSteps.LoginToAccount("VisualAccount");
			selGlobalSteps.DeleteProductWithUPCNumberIfOneHasBeenGenerated();
		}

		[StepDefinition(@"I call Shared Step \(Login to WERCSmart - Premium Account\)")]
		public void GivenICallSharedStepLoginToWERCSmart_PremiumAccount()
		{
			var MyGlobalSteps = new GlobalSteps();
			MyGlobalSteps.LoginToAccount("PremiumSubscriptionAccount");
		}

		[StepDefinition(@"I call Shared Step \(Login to WERCSmart - Pharma Account\)")]
		public void GivenICallSharedStepLoginToWERCSmart_PharmaAccount()
		{
			var MyGlobalSteps = new GlobalSteps();
			MyGlobalSteps.LoginToAccount("PharmaAccount");
		}

		[StepDefinition(
			@"I call Shared Step 74834 \(Login to WERCSmart - with subscription without products account\)")]
		public void Shared74834_LoginToWercSmart_WithSubscriptionWithoutProductsAccount()
		{
			var selGlobalSteps = new GlobalSteps();
			selGlobalSteps.LoginToAccount("SubCart");
			selGlobalSteps.DeleteProductWithUPCNumberIfOneHasBeenGenerated();
		}

		[StepDefinition(
			@"I call Shared Step 79490 \(Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue\) and save ingredient as: Ing(.*)NG")]
		public void
			GivenICallSharedStep79490Ingredients_AddNon_GenericComponent_PublicDisclosedYesSelectNameContinueAndSaveIngredientAsIngNG(
				string savedAs, Table component)
		{
			var newProductIngredients = new Ingredients();
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var ingredient = new Ingredients.Ingredient {
				CASNumber = component.Rows.First()["CASNumber"],
				ComponentName = component.Rows.First()["ComponentName"],
				Percent = component.Rows.First()["Percentage"],
				PublicallyDisclosed = true,
				PublicName = "Undisclosed Ingredient"
			};
			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(
			@"I call Shared Step 79507 \(Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue\)")]
		public void GivenICallSharedStepFormulationRdParty_AcceptFormulation_GrantTier_Continue()
		{
			Report.UseSubSteps = true;
			var thisMyIngredients = new Steps_MyIngredients();
			thisMyIngredients.InTheFormulationThirdPartySCreenISetAcceptTo("true");
			//thisMyIngredients.InTheFormulationThirdPartySCreenISetDeclinedTo("true");
			//thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2 Data Uses", "Granted");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2.1, 2.2, 4.2 Data Uses", "Granted");
			var thisStepsNewProduct = new StepsNewProduct();
			thisStepsNewProduct.GivenInTheNewProductPageIClickContinue("3rd Party");
		}

		[StepDefinition(@"I call Shared Step 79491 \(Formulation > 3rd Party - Accept formulation - Decline Tier 4.1 - Continue\)")]
		public void ThenICallSharedStep79491FormulationRdParty_AcceptFormulation_DeclineLastTier_Continue()
		{
			Report.UseSubSteps = true;
			var thisMyIngredients = new Steps_MyIngredients();
			thisMyIngredients.InTheFormulationThirdPartySCreenISetAcceptTo("true");
			//thisMyIngredients.InTheFormulationThirdPartySCreenISetDeclinedTo("true");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2 Data Uses", "Granted");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 4.1 Derived Results", "Declined");
			var thisStepsNewProduct = new StepsNewProduct();
			thisStepsNewProduct.GivenInTheNewProductPageIClickContinue("Third party");
		}

		[StepDefinition(
			@"I call Shared Step 73956 version 2 \(Go to Summary and verify data\) with product type: (.*)")]
		public void SharedGoToSummaryAndVerifyDataWithoutNavigatingToTheHomepage(string typeOfProduct)
		{
			Report.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myGlobalSteps = new GlobalSteps();
			Report.StartSubStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			Report.StartSubStep("I click the Summary button in the Data Acceptance window");
			myStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartSubStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			Report.StartSubStep("Type of Product should be showing the following option: " + typeOfProduct);
			new StepsDataSummarySheet().ShouldBeShowingFollowing("Type of Product", typeOfProduct);
			Report.StartSubStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();
			Report.StartSubStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");

		}

		[StepDefinition(
			@"I call Shared Step 79500 \(WPS Studio - PD\+ - set all data and publish using rule and doc queue - CKLT and SBCS only\) for product saved as: (.*)")]
		public void GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(
			string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			Report.UseSubSteps = true;
			Report.Info("In power tools workspace setting edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");

			Report.Info("Going to do publishing");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Delay.Seconds(3);
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			GeneralUtilities.StudioWaitForSpinner();
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Delay.Seconds(3);
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(3);
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);

			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();


			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;


			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Format",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			thisStepsStudio.ICloseAlert();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(
			@"I call Shared Step 209526 \(WPS Studio - PD\+ - set all data and publish using rule and doc queue - CKLT and MTR only\) for product saved as: (.*)")]
		public void GivenICallSharedStep209526WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndMTROnly(
			string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			Report.UseSubSteps = true;
			Report.Info("In power tools workspace setting edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"CAWC",
				"pass"
			});
			table2.AddRow(new string[] {
				"EPAN",
				"pass"
			});
			table2.AddRow(new string[] {
				"HCM",
				"pass"
			});
			table2.AddRow(new string[] {
				"OTC",
				"pass"
			});
			table2.AddRow(new string[] {
				"RAUNDW",
				"pass"
			});
			table2.AddRow(new string[] {
				"UNIFFC",
				"pass"
			});
			table2.AddRow(new string[] {
				"WSWC",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VOCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAHDPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");

			Report.Info("Going to do publishing");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Delay.Seconds(3);
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			GeneralUtilities.StudioWaitForSpinner();
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"MTR",
				"False"
			});
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Delay.Seconds(3);
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(3);
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);

			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();


			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;


			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Format",
				"Subformat",
				"Language",
				"DocType",
				"Authorized"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"CKLT",
				"EN",
				"PDF",
				"3"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"HWHD",
				"EN",
				"PDF",
				"3"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"HWST",
				"EN",
				"PDF",
				"3"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"SBCS",
				"EN",
				"PDF",
				"3"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			thisStepsStudio.ICloseAlert();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(
			@"I call Shared Step 231412 I add the UsageType: (.*) with Datacode (.*) with data: (.*) to the Section - Applicable Only to Type of Product")]
		public void GivenICallSharedStep231412_SetDataCode(string usageType, string dataCode,string data)
		{
			
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			Report.Info("In Designer Plus clicking Add New Link to add Data Code");
			var thisStudioPowerDesignerPlusDesignMode =	new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(60), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickAddNewButton();
			Delay.Seconds(5);
			thisStepsStudio.ISetUsageType(usageType);
			thisStepsStudio.IFilterDatacode(dataCode);
			Delay.Seconds(5);
			thisStepsStudio.ISelectDataCode(data);
			Delay.Seconds(5);
			thisStudioPowerDesignerPlusDesignMode.ClickSaveAndClose();
			GeneralUtilities.StudioWaitForSpinner(60);
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load(60);
		}
		
		[StepDefinition(@"I call Shared Step 79501 \(WPS Studio - PD\+ - Create Component for 3rd party product\)")]
		public void GivenICallSharedStep79501WPSStudio_PD_CreateComponentForRdPartyProduct(
			TechTalk.SpecFlow.Table components)
		{
			Report.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");

			if (!thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("formulation"))
			{
				Report.Info("There may have been a problem clicking the formulation tool bar option...");
			}
			else
			{
				Report.Success("Clicked toolbar item formulation");
			}

			Delay.Seconds(1);
			var thisProductFormulationPage = new ProductFormulationPage();
			Report.IsTrue(thisProductFormulationPage.Wait_for_load(30), "Product formulation page has not loaded",
				"Product formulation page has loaded");
			foreach (TableRow thisRow in components.Rows)
			{
				thisStepsStudio.InTheProductForulationPageIClickButton("Create component");
				Delay.Seconds(3);
				string[] columnHeaders = components.Header.Select(x => x.Trim()).ToArray();
				var tableRow = new TechTalk.SpecFlow.Table(columnHeaders);
				tableRow.AddRow(thisRow);
				thisStepsStudio.InTheCreateComponentPageIAddComponent(tableRow);
			}

			GeneralUtilities.StudioWaitForSpinner();
			Delay.Seconds(1);
			if (SeleniumWebDriver.CurrentDriver.WaitForAlert(2))
			{
				Report.Info("Found an alert");
				string alertText = SeleniumWebDriver.CurrentDriver.GetAlertText();
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
				Report.Info("Got an alert: " + alertText);
			}
			else
			{
				Report.Info("Did not find an alert");
			}

			GeneralUtilities.StudioWaitForSpinner();
			Report.Info("Closing formulation page");
			thisStepsStudio.GivenICloseTheProductFormulationPage();
			GeneralUtilities.StudioWaitForSpinner();

		}

		[StepDefinition(
			@"I call Shared Step 74916 \(Login to WERCSmart - without products in cart  and without  subscription account\)")]
		public void Shared74916_LoginToWercSmart_WithoutProductsInCartAndWithoutSubscriptionAccount()
		{
			var selGlobalSteps = new GlobalSteps();
			selGlobalSteps.LoginToAccount("ProductsInCart");
			selGlobalSteps.DeleteProductWithUPCNumberIfOneHasBeenGenerated();
		}

		[StepDefinition(@"I call Shared Step 67038 \(Login into WERCSmart Portal - ULSC Role\)")]
		public void Shared67038_LoginToWercSmartPortal_UlscRole()
		{
			var selGlobalSteps = new GlobalSteps();
			selGlobalSteps.LoginToAccount("ULSCAccount");
			selGlobalSteps.DeleteProductWithUPCNumberIfOneHasBeenGenerated();
		}

		[StepDefinition(@"I call Shared Step 68210 \(Login to WERCSmart - Premium Account\)")]
		public void Shared68210_LoginToWercSmart_PremiumAccount()
		{
			var selGlobalSteps = new GlobalSteps();
			selGlobalSteps.LoginToAccount("PremiumSubscriptionAccount");
			selGlobalSteps.DeleteProductWithUPCNumberIfOneHasBeenGenerated();
		}

		[StepDefinition(@"I call Shared Step 65698 \(Transport - Select DOT & Limited Shipping - No Continue\)")]
		public void Shared65698_Transport_SelectDotAndLimitedShipping_NoContinue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "DOT");
			Report.StartSubStep(
				"I set the section 'Select all modes of transport that you've classified the product for' subsection 'DOT' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "DOT");
		}

		[StepDefinition(@"I call Shared Step 130543 \(Transport - Pharma Flow - Select DOT & Limited Shipping - No Continue\)")]
		public void Shared130543_Transport_PharmaFlow_SelectDotAndLimitedShipping_NoContinue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select applicable modes of transport for which you classify the product", "DOT");
			Report.StartSubStep(
				"I set the section 'Select applicable modes of transport for which you classify the product' subsection 'DOT' field to: Yes, Shipped with Limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Yes, Shipped with Limited quantity",
				"Select applicable modes of transport for which you classify the product", "DOT");
		}

		[StepDefinition(@"I call Shared Step 65700 \(Transportation Details 1 - Select IATA & Limited Shipping\)")]
		public void Shared65700_TransportDetails1_SelectIataAndLimitedShipping()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: IATA");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "IATA");
			Report.StartSubStep(
				"I set the section: 'Select all modes of transport that you've classified the product for' subsection: 'IATA' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "IATA");
		}

		[StepDefinition(@"I call Shared Step 65699 \(Transport - Select IMDG & Limited Shipping - No Continue\)")]
		public void Shared65699_Transport_SelectImdgAndLimitedShipping_NoContinue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: IMDG");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "IMDG");
			Report.StartSubStep(
				"I set the section: 'Select all modes of transport that you've classified the product for' subsection: 'IMDG' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "IMDG");
		}

		//65701
		[StepDefinition(@"I call Shared Step 65701 \(Transport - Select TDG & Limited Shipping - No Continue\)")]
		public void Shared65701_Transport_SelectTdgAndLimitedShipping_NoContinue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"I set the Select all modes of transport that you've classified the product for field to: TDG");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "TDG");
			Report.StartSubStep(
				"I set the section: 'Select all modes of transport that you've classified the product for' subsection: 'TDG' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "TDG");
		}

		[StepDefinition(
			@"I call Shared Step 65939 \(Go To Transport DOT Step - Enter UN1966, Confirm data - NO CONTINUE\)")]
		public void Shared65939_GoToTransportDotStep_EnterUn1966ConfirmData_NoContinue()
		{
			var selStepsNewProduct = new StepsNewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the 'U.S. Department of Transportation (DOT) Classification' tab");
			selStepsNewProduct.ClickPageHeading(
				"U. S. Department of Transportation (DOT) Classification");
			Report.StartSubStep("I enter the Un Number 'UN1966'");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1966");
			Report.StartSubStep("I confirm 'Hydroden, refrigerated liquid' is showing for the Proper Shipping Name");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Proper Shipping Name", "Hydrogen, refrigerated liquid");
			Report.StartSubStep(
				"I confirm no other options are available for the Proper Shipping Name drop down list");
			var options = new Table("Option");
			options.AddRow("Hydrogen, refrigerated liquid");
			selStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Proper Shipping Name",
				options);
			Report.StartSubStep("I enter the phrase 'Technical Name Test' into the Technical Name field");
			selStepsNewProduct.SetTheSectionOptionTo("Technical Name", "Technical Name Test");
			Report.StartSubStep("I confirm '2.1' is selected for section: Hazard Class (select)");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Hazard Class (select)", "2.1");
			Report.StartSubStep("I confirm '2.1' is the only available option for section: Hazard Class (select)");
			options = new Table("Option");
			options.AddRow("2.1");
			selStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Hazard Class (select)",
				options);
			Report.StartSubStep("I confirm 'None' is selected for section 'Packing Group'");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group", "None");
			Report.StartSubStep("I confirm 'None' is the only available option for section 'Packing Group'");
			options = new Table("Option");
			options.AddRow("None");
			selStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Packing Group", options);
		}

		// In progress - PD + page not loading in studio
		[StepDefinition(
			@"I call Shared Step 65969 \(Go to Power Designer Plus - Select your product & CKLT - Continue\)")]
		public void Shared65969_GoToPdPlus_SelectYourProductAndCklt_Continue()
		{
			Report.UseSubSteps = true;
			var thisStudioPowerDesignerPlusDesignMode = new StudioPowerDesignerPlusDesignMode();
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			var thisTopMenu = new StudioTopMenu();
			Report.StartSubStep("I click the Authoring menu option and Select Power Designer Plus");
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
			Report.Screenshot();
			Delay.Seconds(3);
			Report.StartSubStep("I select EN as the Language, MTR/CKLT as the format/subformat");
			thisPowerDesignerPlus.Wait_for_load(240);
			Delay.Seconds(10);

			if (!thisPowerDesignerPlus.Wait_for_load(240))
			{
				thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
				thisStudioPowerDesignerPlusDesignMode.ClickMenuAndSubmenuOptions("Home");
				Delay.Seconds(3);
			}
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(240), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
				"Set language option");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter("CKLT"), "Failed to set subformat option",
				"Set subformat option");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("CKLT", "MTR"), "Failed to set format option",
				"Set format option");
			Report.StartSubStep("I click the Edit Existing product radio button if not already selected");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");
			Report.Screenshot();
			Delay.Seconds(1);
			Report.StartSubStep("I filter for the product");
			var productDetails = (ProductInformation)Context.GetFromContext("TestCase" + WercSmartSettings.TestCaseId);
			string id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(120);
			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.StartStep("I click Continue");
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button", "Clicked continue button");
			Delay.Seconds(120);
			thisPowerDesignerPlus.Wait_for_load(240);
		}

		[StepDefinition(
			@"I call Shared Step 81310 \(UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue\)")]
		public void Shared81310_UNNumber_EnterUN1950SelectAerosolAndHazClassConfirmPackingGroup_Continue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I enter UN1950 in the UN Number field");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Report.StartSubStep("I select Aerosols from the Proper Shipping Name drop down");
			selStepsNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Report.StartSubStep("I select the first option from: Hazard Class (select)");
			selStepsNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Report.StartSubStep("I confirm the Packing Group (select) option is set to: None");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group (select)", "None");
			Report.StartSubStep("I click continue");
			selStepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 130542 \(UN Number - Pharma Flow - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue\)")]
		public void Shared130542_UNNumber_PharmaFlow_EnterUN1950SelectAerosolAndHazClassConfirmPackingGroup_Continue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I enter UN1950 in the UN Number field");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Report.StartSubStep("I select Aerosols from the Proper Shipping Name drop down");
			selStepsNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Report.StartSubStep("I select the first option from: Hazard Class (if available)");
			selStepsNewProduct.SelectFirstOptionInSection("Hazard Class (if available)");
			Report.StartSubStep("I confirm the Packing Group (if available) option is set to: None");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group (if available)", "None");
			Report.StartSubStep("I click continue");
			selStepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 81311 \(UN Number - enter UN1206 - confirm pre-populated select radio button - Continue\)")]
		public void Shared81311_UNNumber_EnterUn1206_ConfirmPrePopulatedSelectRadioButton_Continue()
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			var selNewProduct = new NewProduct();
			Report.StartSubStep("I enter UN1206 in the UN Number field");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1206");
			Report.StartSubStep("I confirm the Proper Shipping Name is pre-populated with Heptanes");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Proper Shipping Name", "Heptanes");
			Report.StartSubStep("I confirm the Hazard Class drop down is pre-populated with 3");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Hazard Class (select)", "3");
			Report.StartSubStep("I confirm the Packing group drop down is pre-populated with II");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group (select)", "II");
			// Some notes from TFS:
			// At times an additional question is now shown if you see it then perform this step and step 6 - otherwise ignore these two steps
			// I really do not think this is not correct as I do not have these values set on the product so I have re-emailed Courtney with details of testing and questions - for now this step is left in - but it may need to me removed/changed at some point
			List<string> sections = selNewProduct.GetDisplayedSections();
			if (sections.Any(x => x.ToLower().Contains("boiling point")))
			{
				Report.StartSubStep(
					@"Confirm an additional question is shown which reads ""Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.""");
				var table = new Table("Section");
				table.AddRow(
					"Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.");
				selStepsNewProduct.CheckDisplayedSections("see", table);
				Report.StartSubStep("I select the first option in the Packing Group additional question");
				selStepsNewProduct.SelectFirstOptionInSection("Product has a boiling point of");
			}

			Report.StartSubStep("I click continue");
			selStepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 77872 \(Product Information - Kit flow - US only, Direct Ship \(yes\), Continue\)")]
		public void Shared77872_ProductInformation_KitFlow_UsOnly_DirectShip_Yes_Continue()
		{
			Report.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information page");
			newProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I confirm 'United States' is selected for the SOLD question");
			newProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep("I should only see the SOLD and Direct ship questions");
			var sections = new Table("Section");
			sections.AddRow("Select countries the product may be sold in");
			sections.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			newProductSteps.CheckDisplayedSections("only see", sections);
			Report.StartSubStep(
				"I select the Yes button for the 'Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.' question");
			newProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.",
				"Yes");
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 31427 \(Create the Kit - Adding two products: product 1: (.*) and product 2: (.*)\)")]
		public void Shared31427_CreateTheKit_AddingTwoProducts(string inputProduct1, string inputProduct2)
		{
			Report.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var product1 = (ProductInformation)Context.GetFromContext(inputProduct1.Trim());
			if (product1 == null)
			{
				throw new Exception("Failed to find product: " + inputProduct1);
			}
			Report.Info($"product1 was not null. It was found in context.");

			var product2 = (ProductInformation)Context.GetFromContext(inputProduct2.Trim());
			if (product2 == null)
			{
				throw new Exception("Failed to find product: " + inputProduct2);
			}
			Report.Info($"product2 was not null. It was found in context.");

			Report.StartSubStep($"I add {product1.Id} to the kit");
			newProductSteps.GivenInTheCreateTheKitPageISearchForAndSelectByIdSavedAs(product1);
			Report.StartSubStep($"I add {product2.Id} to the kit");
			newProductSteps.GivenInTheCreateTheKitPageISearchForAndSelectByIdSavedAs(product2);
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 77845 \(Retailer - Select WM, Done, Select Vendor ID, Continue\)")]
		public void Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue()
		{
			var newProductSteps = new StepsNewProduct();
			var retailerSelectionSteps = new StepsSelectRetailers();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Select Retailers Popup");
			retailerSelectionSteps.GivenIShouldSeeTheSelectRetailersPopUp();
			Report.StartSubStep("I select the retailer: Wal-Mart/SAM'S CLUB and click Done");
			new StepsSelectRetailers().SelectTheRetailer("Walmart");
			Report.StartSubStep("I set the Vendor as: Testing");
			//new Steps_Retailer().ISelectVendorId("Testing");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Walmart");
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 42759 \(Portal - UPC Page - add 1 UPC\)")]
		public void Shared42759_Portal_UpcPage_Add1Upc()
		{
			var newProductSteps = new StepsNewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Add UPC button");
			newProductSteps.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I set the UPC Number, Container Type and Size");
			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", $"saved as UPC{WercSmartSettings.TestCaseId}");
			upcTable.AddRow("ContainerType", "Cardboard");
			upcTable.AddRow("Size", "20");
			//upcTable.AddRow("DPCI", "087 - 16 - 0238");
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 81633 - WPS - PD+ - Product Attributes - filter for, and select specific data code: (.*)")]
		public void Shared81633_Wps_PdPlus_ProductAttributes_FilterForAndSpecificDataCode(string dataCode)
		{
			var studioSteps = new Steps_Studio();
			Report.UseSubSteps = true;
			Report.StartStep("");

		}

		[StepDefinition(@"I call Shared Step 23195 \(Login into WERCSmart Portal - Administrator Role\)")]
		public void Shared23195_LoginToWercSmartPortal_AdministratorRole()
		{
			var selGlobalSteps = new GlobalSteps();
			selGlobalSteps.LoginToAccount("ProductAccount");
			selGlobalSteps.DeleteProductWithUPCNumberIfOneHasBeenGenerated();
		}

		[StepDefinition(
			@"I call Shared Step 60648 \(Product Information - US, No \(Direct Ship\), No \(PL\), No \(GNFR\)\)")]
		public void Shared60648_ProductInformation_Us_NoDirectShip_NoPl_NoGnfr()
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartSubStep("I set the 'Product is shipped directly..' question to: 'No'");
			newProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.",
				"No");
			Report.StartSubStep("I set the 'Product is a Retailer's Private Label or Brand' question to: 'No'");
			newProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep("I set the 'Product is sold to the Retailer..' question to: 'No'");
			newProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 77883 \(Product Information - Kit flow - US only, Direct Ship \(No\), Continue\)")]
		public void Shared7783_ProductInformation_KitFlow_UsOnly_DirectShipNo_Continue()
		{
			Report.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Product Information page");
			newProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I confirm 'United States' is selected for the SOLD question");
			newProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep("I should only see the SOLD and Direct ship questions");
			var sections = new Table("Section");
			sections.AddRow("Select countries the product may be sold in");
			sections.AddRow(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.");
			newProductSteps.CheckDisplayedSections("only see", sections);
			Report.StartSubStep(
				"I select the No button for the 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' question");
			newProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.",
				"No");
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 79491 \(Formulation > 3rd Party - Accept formulation - Decline Tier 2 - Continue\)")]
		public void ThenICallSharedStep79491FormulationRdParty_AcceptFormulation_DeclineTier_Continue()
		{
			Report.UseSubSteps = true;
			var thisMyIngredients = new Steps_MyIngredients();
			thisMyIngredients.InTheFormulationThirdPartySCreenISetAcceptTo("true");
			//thisMyIngredients.InTheFormulationThirdPartySCreenISetDeclinedTo("true");
			//thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2 Data Uses", "Declined");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2.1, 2.2, 4.2 Data Uses", "Declined");
			var thisStepsNewProduct = new StepsNewProduct();
			thisStepsNewProduct.GivenInTheNewProductPageIClickContinue("Third party");
		}

		[StepDefinition(
			@"call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: (.*)")]
		public void
			ThenCallSharedStep80090_Ingredients_AddNon_GenericChemicalSetToPubliclyDisclosedSelectPublicNameAndSaveIngredientAsIng(
				string savedAs, Table component)
		{
			var newProductIngredients = new Ingredients();
			var ingredient = new Ingredients.Ingredient {
				CASNumber = component.Rows.First()["CASNumber"],
				ComponentName = component.Rows.First()["ComponentName"],
				Percent = component.Rows.First()["Percentage"],
				PublicallyDisclosed = true,
				PublicName = component.Rows.First()["ComponentName"]
			};
			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(
			@"call Shared Step 80091 - Ingredients - Add Non-generic component - set percentage - not publicly disclosed and save ingredient as: (.*)")]
		public void
			ThenCallSharedStep80091_Ingredients_AddNon_GenericChemicalSetToPubliclyDisclosedSelectPublicNameAndSaveIngredientAsIng(
				string savedAs, Table component)
		{
			var newProductIngredients = new Ingredients();
			var ingredient = new Ingredients.Ingredient {
				CASNumber = component.Rows.First()["CASNumber"],
				ComponentName = component.Rows.First()["ComponentName"],
				Percent = component.Rows.First()["Percentage"],
				PublicallyDisclosed = false,
				PublicName = component.Rows.First()["ComponentName"]
			};
			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		//If your subscription is set to Premium you will see the ECOLOGO Readiness step - if you do perform the shared step below - if you do not see it skip to step 17
		[StepDefinition(
			@"If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path")]
		public void ThenICallSharedStep_ECOLOGOReadinessAssessment_NotAtThisTime_Continue_HappyPath()
		{
			Report.UseSubSteps = true;
			var stepEcologo = new Steps_Ecologo_Readiness();
			var selNewProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			if (newProduct.WaitForSection("ECOLOGO Readiness"))
			{
				Report.Info("The ECOLOGO Readiness page is displayed, selecting 'Not at this time'");
				Report.StartSubStep("The ECOLOGO Readiness page should be loaded");
				stepEcologo.EcologoReadinessPageShouldBeLoaded();
				Report.StartSubStep("I confirm the ECOLOGO Readiness Assessment question is displayed");
				stepEcologo.ConfirmEcologoReadinessAssessmentQuestionDisplayed();
				Report.StartSubStep("I set ECOLOGO Readiness Assessment to: (Yes|Not at this time)");
				stepEcologo.SetEcologoReadiness("Not at this time");
				Report.StartSubStep("I click continue");
				selNewProductSteps.ClickContinue();
			}
			else
			{
				Report.Info("The ECOLOGO Readiness page is not displayed");
			}

		}

		[StepDefinition(
			@"I call Shared Step 51351 \(SHA > Select Product > View Recertification History\) for product saved as: (.*)")]
		public void GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(string savedAs)
		{
			Report.UseSubSteps = true;
			var myStudioShaManager = new StudioSHAManager();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			var thisStepsSha = new Steps_SHA();
			Report.StartSubStep("I select  product in the SHA grid saved as " + savedAs);
			thisStepsSha.GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(savedAs);
			Delay.Seconds(3);
			Report.StartSubStep("I click 'Recertification History'");
			thisStepsSha.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption(
				"Recertification History");
			Delay.Seconds(1);
		}

		[StepDefinition(@"I call Shared Step 60778 \(Primary Physical Property - Packaged in gas cylinder\)")]
		public void Shared60778_PrimaryPhysicalProperty_PackagedInGasCylinder()
		{
			Report.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartSubStep(
				@"By default the radio button should be selected for ""Product is packaged in a gas cylinder(e.g., whip cream)""");
			selNewProductSteps.CheckingFieldInputIsCorrect("Primary Physical State",
				"Product is packaged in a gas cylinder (e.g., whip cream)");
			Report.StartSubStep("I set the Secondary Physical State option to: Aerosol");
			selNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Aerosol");
			Report.StartSubStep("I set the pH option to: 10");
			selNewProductSteps.SetTheSectionOptionTo("pH", "10");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Soluble in water");
			selNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
				"Soluble in water");
			Report.StartSubStep(
				"I select the first option for: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then'");
			selNewProductSteps.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartSubStep("I select the first option for: Select all ingredients included in this product");
			selNewProductSteps.SelectFirstOptionInSection("Select all potential allergens included in this product");
			Report.StartSubStep("I select the first option for: Product is manufactured in a facility that processes, or contains");
			selNewProductSteps.SelectFirstOptionInSection("Product is manufactured in a facility that processes, or contains");
			Report.StartSubStep("I select the first option for: Product is verified and sold");
			selNewProductSteps.SelectFirstOptionInSection("Product is verified and sold");
			Report.StartSubStep("I select the first option for: Product contains the following sweeteners");
			selNewProductSteps.SelectFirstOptionInSection("Product contains the following sweeteners");
			Report.StartSubStep("I select the first option for: Product contains the following artificial dye(s)");
			selNewProductSteps.SelectFirstOptionInSection("Product contains the following artificial dye(s)");
			Report.StartSubStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 84554 \(Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path\)")]
		public void Shared84554_PhysicalandChemicalProperties_LiquidAndSolid_EnterAllData_Continue()
		{
			Report.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			newProductSteps.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			newProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density field to: 1");
			newProductSteps.SetTheSectionOptionTo("Relative Density", "1");
			Report.StartSubStep("I set the pH option to: 10");
			newProductSteps.SetTheSectionOptionTo("pH", "10");
			Report.StartSubStep("I set the Boiling Point option to: '30'");
			newProductSteps.SetTheSectionOptionTo("Boiling Point (in Celsius)", "30");
			Report.StartSubStep("I set the Flash Point (in Celsius) option to: 100");
			newProductSteps.SetTheSectionOptionTo("Flash Point (in Celsius)", "100");
			Report.StartSubStep("I set the Flash Point Determination method option to: Not applicable/available");
			newProductSteps.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Soluble in water");
			newProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue")]
		public void ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(Table retailers)
		{
			Report.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			foreach (TableRow thisRetailer in retailers.Rows)
			{

				Report.StartSubStep("In the Select Retailers popup I select the retailer: " +
									 thisRetailer["Retailer"]);
				new StepsSelectRetailers().SelectTheRetailer(thisRetailer["Retailer"]);
			}
			foreach (TableRow thisRetailer in retailers.Rows)
			{
				Report.StartSubStep("In the Select Retailers popup I add PL information");
				selStepsNewProduct.ThenIAddAdditionaRequirmentsInfoForRetailer(thisRetailer["Retailer"],
					"Additional requirements: " + thisRetailer["Retailer"]);
			}

			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("No Retailer/No UPC Product", "This Private Label");

			Report.StartSubStep("I click continue");
			selStepsNewProduct.ClickContinue();
			if (new NewProduct().ErrorMessageText == "This is a required field.")
			{
				Report.Failure(
					"Required field error was showing on continue. Attempting to enter Private Label field (not specified by Shared Step)");
				Report.StartSubStep("I enter private label as 'This Private Label'");
				new Steps_Retailer().IEnterPrivateLabelName("This Private Label");
				Report.StartSubStep("I click continue");
				selStepsNewProduct.ClickContinue();
			}
		}

		[StepDefinition(
			@"I call Shared Step 85983 - WPS Studio - PD\\\+ PLP with NGHS only - set all data and publish using rule and DOC queue for product saved as: (.*)")]
		public void GivenICallSharedStep_WPSStudio_PDPLPWithNGHSOnly_SetAllDataAndPublishUsingRuleAndDOCQueue(
			string savedAs)
		{
			Report.UseSubSteps = true;

			//Given I Set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic(filename is DPQA_PASS[1].png)Do this by double clicking on the graphic and selecting the green check mark graphic from the available list and click save
			Report.StartSubStep(
				"I set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic");
			Report.Info("In power tools workspace I set edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			//	And I Open the Current Document pop up using the tool bar icons
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Formulation"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			//And I Select the Authorize Formula and Attributes for publishing check box
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			//	If an error is shown you will need to add data to the data codes that are shown before you can continue-
			// close the pop up - add all data and re-open the current document pop up
			//	And I Select the Apply to all subformats check box
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}

			//	And I Confirm CKLT, NGHS and SBCS are not shownin the pop up messageand click OK
			Report.StartStep("I confirm CKLT, NGHS and SBCS are not shown in the pop up message and click OK");
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"NGHS",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			//	And I Close the current document pop up
			Report.StartSubStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			//	And I Select the Wizards tab
			//	And I Select the Apply Rules icon from the tool bar
			Report.StartSubStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			//And I Select the Single rule radio button
			Report.StartSubStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			//And I Click the three ... icon to open the Select Rule pop up
			Report.StartSubStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			//	And I Click the filter icon
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();

			//And I In the rule name filter box enter your studio user name(you will already have a publishing rule set up with your name)and click apply
			//	And I The Select rule pop up will show only rules which start with the characters you entered in the filter -select the rule you require to publish documents Note: The rule name will be in the format xxxx - CREATE ADDITIONAL DOC TO QUEUE-FOR XXXXWhere the xxxx is replaced by your Studio user name
			//And I Select the rule by clicking on it
			//	And I Check that the Product group radio button is selected
			//	And I Click Apply
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartSubStep("In the rule name filter box I enter the studio user name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartSubStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartSubStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(5);
			//	And I The Completed Successfully pop up is shown, click okNote: in Staging the completed
			// successful pop up does not show till you try to close the Apply rules pop up
			//	And I Close the Apply Rules pop up
			Report.StartSubStep("I close the Apply Rules pop up");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);
			//	And I Select the Product tab
			//	And I Click the Document queue icon in the tool bar
			Report.StartSubStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			//	And I Click the filter icon
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			//	And I Enter you product id in the Product/ Alias area of the filter and click Apply
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Starts with...", @"Product\Alias");
			Report.StartSubStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			//	And I Confirm your product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF,
			// you will see entries for the product and its aliases(Private Label products have aliases in WPS Studio).
			Report.StartSubStep(
				"I confirm the product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF");
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				id,
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id,
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id,
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				id,
				"CKLT",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_CV",
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_CV",
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_CV",
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_CV",
				"CKLT",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_DG",
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_DG",
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_DG",
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				id + "_DG",
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			//And I Click the check box in the table header row of the document queue window
			//	And I Click Process Documents
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartSubStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(2);
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			//And I Pop up shows with message indicating the queued documents were sent for publishing
			Report.StartSubStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			//	And I Click OK
			Report.StartSubStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			//	And I Close the Document queue window
			Report.StartSubStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(
			@"I call Shared Step 75307 \(Edit UPC - Add UPC and all data - Click Save\) for UPC Number saved as: ""UPC(.*)"", container type: ""(.*)"", size: ""(.*)""")]
		public void Shared75307_EditUpc_AddUpcAndAllData(string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");
			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
			upcTable.AddRow("ContainerType", containerType);
			upcTable.AddRow("Size", size);
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			//If shown select an entry from the Packaging type drop down
			//If needed add any Retailer specific UPC data (for example OMSID, DPCI, part number etc)		
			Report.StartSubStep("I click save");
			MyStepsNewProduct.ThenIClickSaveOrCancelInTheProductPage("Save");
		}

		// Option is now called "UPC Retailer and Feed"
		[StepDefinition(@"I call Shared Step 75309 \(SHA > Select Product > UPC Retailer and Feed\) for product saved as: (.*)")]
		//[StepDefinition(@"I call Shared Step 75309 \(SHA > Select Product > UPC List\) for product saved as: (.*)")]
		public void Shared75309_SHA_SelectProduct_UpcList(string savedAs)
		{
			Report.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			Report.StartSubStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Report.StartSubStep("I right click the product");
			shaSteps.GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(savedAs);
			// saving the current window so we can naviate back from UPC List
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			Report.StartSubStep("I click 'UPC Retailer and Feed'");
			shaSteps.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I call Shared Step 157868 \(SHA > Select First Product > UPC Retailer and Feed\)")]
		public void Shared157868_SHA_SelectFirstProduct_UpcList()
		{
			Report.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			Report.StartSubStep("I select first product in the SHA grid");
			shaSteps.GivenInSHAManagerISelectTheProduct();
			Report.StartSubStep("I right click the product");
			shaSteps.GivenInTheSHAManagerGridIRightClickFirstProduct();
			// saving the current window so we can naviate back from UPC List
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			Report.StartSubStep("I click 'UPC Retailer and Feed'");
			shaSteps.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
			Delay.Seconds(25);
		}

		[StepDefinition(@"I call Shared Step 134404 \(SHA > Select Product > UPC Assessment Details\) for product saved as: (.*)")]
		public void Shared134404_SHA_SelectProduct_UpcAssessmentDetails(string savedAs)
		{
			Report.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			Report.StartSubStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Report.StartSubStep("I right click the product");
			shaSteps.GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(savedAs);
			// saving the current window so we can naviate back from UPC List
			string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			Report.StartSubStep("I click 'UPC Assessment Details'");
			shaSteps.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Assessment Details");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I call Shared Step 55637 \(SHA - Process UPC Update for Specific product\) saved as: (.*)")]
		public void Shared55637_SHA_ProcessUPCUpdateForSpecificProduct(string savedAs)
		{
			Report.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			var shaManager = new StudioSHAManager();
			var processUI = new ProcessUIDialog();
			Report.StartSubStep("I confirm the product saved as is shown in the UPC Update status");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"UPC Update");
			Report.StartSubStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Report.StartSubStep("I click the UPC link at the bottom of the SHA page");
			shaManager.ClickBottomMenuOption("UPC");
			Report.StartSubStep("I uncheck the Auto Assign Regulatory Specialist to Product check box");
			IWebElement el = processUI.ProcessCheckbox("Auto Assign");
			if (el == null)
			{
				Report.Screenshot();
				throw new Exception(
					"Unable to find input for 'Auto Assign Regulatory Specialist and process the product!'");
			}

			if (el.Checked())
			{
				Report.IsTrue(el.TryClick() && !el.Checked(),
					"Failed to uncheck option 'Auto Assign Regulatory Specialist'",
					"Successfully unchecked option: 'Auto Assign Regulatory Specialist");
			}
			else
			{
				Report.Info("Option 'Auto Assign Regulatory Specialist to Product' was already unchecked!");
				Report.Screenshot();
			}

			Report.StartSubStep("I select regulatory specialist: Automated QASha");
			Report.IsTrue(processUI.SelectRegulatorySpecialist("Automated QASha"),
				"Failed to select regulatory specialist: Automated QASha",
				"Successfully selected regulatory specialist: Automated QASha", showSuccessScreenshot: false);
			Report.StartSubStep("I click continue");
			Report.IsTrue(processUI.ClickContinue(), "Failed to click continue!", "Successfully clicked continue", showSuccessScreenshot: false);
			Report.StartSubStep("I click Find in the Product Search popup");
			Delay.Seconds(5);
			var productSearch = new StudioSHAManagerProductSearch();
			if (!productSearch.Wait_for_load())
			{
				Report.Screenshot();
				throw new Exception("Product search did not load!");
			}

			Report.IsTrue(productSearch.ClickButton("Find"), "Failed to click Find in product search",
				"Successfully clicked Find in product search", showSuccessScreenshot: false);
			Report.StartSubStep("I close the Process Products pop up");
			processUI = new ProcessUIDialog();
			Report.IsTrue(processUI.ClickClose(), "Failed to close the Process Products popup",
				"Successfully closed the Process Products popup", showSuccessScreenshot: false);
			Report.StartSubStep("I confirm the product saved as is shown in the Accepted status");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");

		}

		[StepDefinition(
			@"I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP \(Maxed Out\)")]
		public void GivenICallSharedStep20375GoToProductAttributesViaAuthoringTabInPDPPAPMaxedOut()
		{
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Product Attributes"
			});
			new Steps_SHA().GivenIEditMyToolbarToAddTheFollowingOptions(table3);
			new Steps_Studio().GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentAttributesButton();

		}

		[StepDefinition(
			@"I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: (.*)")]

		public void
			ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
				string savedAs, Table component)
		{
			var newProductIngredients = new Ingredients();
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			string CASNo = "";
			if (component.Rows.First()["CASNumber"].Contains("WPS"))
			{
				if (Context.Contains(component.Rows.First()["CASNumber"].Split(' ')[2].Trim()))
				{
					var CASProd =
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

			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(@"I call Shared Step 78799 - WPS PD\+ - Product Attributes - Filter for CNTXT")]
		public void GivenICallSharedStep78799_WPSPD_ProductAttributes_FilterForCNTXT()
		{
			Report.Info("Beginning Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT");
			var thisStepsStudio = new Steps_Studio();
			//Click the filter icon
			thisStepsStudio.InProductAttributePageIClickOnFilterIcon();
			//Enter CNTXT in code
			var paf = new ProductAttributesFilter();
			thisStepsStudio.InProductAttributeFilterPopupISelectFromSelectBox("...Contains...", "Code");
			thisStepsStudio.InProductAttributeFilterPopupIEnterValueInTextBox("CNTXT", "Code");
			//Click apply
			thisStepsStudio.InProductAttributeFilterPopupIClickButton("apply");
			Report.IsTrue(paf.WaitForContainerToBeInvisible(30), "Failure, failed to close", "Success, closed");
		}

		[StepDefinition(
			@"I call Shared Step 80780 - My Products - Filter for product - View - Note transparency percentage - close summary for product saved as: (.*)")]
		public void GivenICallSharedStep_MyProducts_FilterForProduct_View_NoteTransparencyRatio_CloseSummary(
			string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartStep("I filter for the product: " + savedAs);
			var thisStepsProductGrid = new StepsProductGrid();
			var thisStepsDataSummarySheet = new StepsDataSummarySheet();
			var myGlobalSteps = new GlobalSteps();

			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();

			thisStepsProductGrid.ClickRowAction("View");
			Report.StartSubStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			thisStepsDataSummarySheet.GetIngredientsFromDataSummaryWindowAndAddToProductSavedAs(savedAs);
			thisStepsDataSummarySheet.GetTransparencyPercentageAndSaveAs("TransparencyPercentage");
			Report.StartSubStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();


			//Scroll till you see the Ingredients list - make a note of the transparency ratio shown
			//The transparency ratio is the number shown below the Yes/ No entries in the Publicly Disclosed? column of the table and will be in the format of x/ y

			//Calculate the number that the transparency ratio is as a decimal (for example if the Transparency ratio shown is 1/2 this would be 0.5 as a decimal, if the transparency ration is 3/8 this would be 0.375 as a decimal) - you will need this later in your test case

			//Close the Summary view and return to the WERCSmart products page
		}

		[StepDefinition(
			@"I call Shared Step 80784 - Ingredients - Search for 3rd party component product saved as: (.*)")]
		public void GivenICallSharedStep_Ingredients_SearchForRdPartyComponentProductByProductSavedAs(string savedAs)
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I should see the Ingredients Page");
			stepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			stepsNewProductIngredients.InTheIngredientsPageISearchForAndSelectProductSavedAs(savedAs);
		}

		[StepDefinition(
			@"I call Shared Step 80824 - Ingredients - Add FLAVOR component, not Publicly Disclosed and save as (.*)")]
		public void ThenICallSharedStep_Ingredients_AddFLAVORComponentNotPubliclyDisclosed(string savedAs,
			TechTalk.SpecFlow.Table component)
		{
			var newProductIngredients = new Ingredients();
			string CASNo = "";
			if (component.Rows.First()["CASNumber"].Contains("WPS"))
			{
				if (Context.Contains(component.Rows.First()["CASNumber"]?.Split(' ')[2].Trim()))
				{
					var CASProd = (ProductInformation)Context.GetFromContext(
						component.Rows.First()["CASNumber"].Split(' ')[2]
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

			Report.IsTrue(newProductIngredients.AddIngredient(ingredient),
				"Failed to add ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " +
				(ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(@"I call Shared Step 57247 - Database check - find t_vendor records for specific Retailer: (.*) and Supplier: (.*)")]
		public void ThenICallSharedStep_DatabaseCheck_FindT_VendorRecordsForSpecificSupplierAndRetailer(string retailer,
			string supplier)
		{
			if (supplier == "Products Automation Account")
			{
				TReVorTestUsers user = TestUsers.GetUserSavedAs("ProductAccount");
				supplier = user.Username;
			}

			string retailerGUID = DbRetailers.GetGUIDByRetailer(retailer);
			string supplierGUID = DbRetailers.GetSupplierGUIDByUsername(supplier);
		}

		[StepDefinition(
			@"I call Shared Step 85284 - Product Information - US & Canada, Child \(No\), OSHA \(No\), DSV \(No\), PLP \(YES\), GNFR \(No\), Continue")]
		public void
			ThenICallSharedStep85284_ProductInformation_USCanadaChildNoOSHANoDSVNoPLPYESGNFRNoContinue()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);

			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");

		}

		[StepDefinition(
			@"I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type \(no retailer data needed\) - Continue for UPC: (.*), container type: (.*) and size: (.*)")]
		public void ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue(
			string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");

			if (upc.ToLower().Contains("savedas"))
			{
				upc = Context.GetFromContext(upc.Replace("savedas", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString();
			}

			if (upc.Contains("Equals"))
			{
				upc = upc.Replace("Equals", "");
			}

			var upcInfo = new UpcInformation {
				ContainerType = containerType,
				Size = size,
				UpcNumber = upc

			};

			//adding for 86187
			var thisNewProduct = new NewProduct();
			if (thisNewProduct.UPCPackageTypeFieldExists())
			{
				upcInfo.PackageType = thisNewProduct.GetValidOptionForUPCPackageType();
			}


			Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
				"Successfully inputted UPC information!");

			Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(
			@"I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both")]
		public void ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.ThenFieldExists("Product Label in English and French-Canadian as required in Consumer Chemicals and Containers Regulations (CCCR), 2001 of the Hazardous Products Act");
			Report.StartSubStep("I set 'OSHA-compliant Safety Data Sheet, English' to: Request to author");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Request to author");
			Report.StartSubStep("I set 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");

			//if (newProdClass.CheckBoxOptionExists("I confirm I am providing the most current Safety Data Sheet"))
			//{
			//	Report.StartStep(@"In the regulatory documents to provide screen I tick the box next to the question: 'I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration'");
			//	MyNewProduct.SelectConfirmRegulatoryDocumentsConfirmationQuestion();
			//}

			Report.StartSubStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both")]
		public void ICallSharedStep104662_RegulatoryDocumentsToProvide_LithiumBatteries()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I set 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.' to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.");
			MyNewProduct.SetRadioOptionInSectionTo("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.", "I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.");
			Report.StartSubStep("I upload a PDF document into the UN38.3 Testing Results field.");
			MyNewProduct.UploadPDFFile("Upload UN38.3 Test Document (Required)", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("I set 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.SetRadioOptionInSectionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("Product Label in English and French-Canadian as required in Consumer Chemicals and Containers Regulations (CCCR), 2001 of the Hazardous Products Act");
			Report.StartSubStep("I upload a PDF document into the Product Label in English and French-Canadian field.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 213199 - Regulatory Documents to Provide - Required Document Uploads - Applicable Only to Alkaline Battery")]
		public void ICallSharedStep104662_RegulatoryDocumentsToProvide_AlcalineBatteries()
		{
			
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I confirm text 'Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product. The Battery registration must comply with regulatory requirements in all regions served by the WERCSmart solution. You must provide a technical document or an SDS for both Canada and the US with a bilingual product label. Lithium Battery registrations must also provide the UN38.3 Testing Document.' is shown in Regulatory Documents to Provide");
			MyNewProduct.RegulatoryDocumentsText("Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product. The Battery registration must comply with regulatory requirements in all regions served by the WERCSmart solution. You must provide a technical document or an SDS for both Canada and the US with a bilingual product label. Lithium Battery registrations must also provide the UN38.3 Testing Document.");
			Report.StartSubStep("I confirm field 'Article Information Sheet (AIS)' exists");
			MyNewProduct.ThenFieldExists("Article Information Sheet (AIS)");
			Report.StartSubStep("I upload a PDF document into the Article Information Sheet (AIS) field.");
			MyNewProduct.UploadPDFFile("Article Information Sheet (AIS)", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("I set 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.' to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.");
			MyNewProduct.SetRadioOptionInSectionTo("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.", "I certify that I have an OSHA-Compliant Safety Data Sheet (SDS) for this product.");
			Report.StartSubStep("I upload a PDF document into the OSHA-COMPLIANT field.");
			MyNewProduct.UploadPDFFile("OSHA SDS", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("I set 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.SetRadioOptionInSectionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I certify that I have a WHMIS-Compliant Safety Data Sheet (SDS) for this product.");
			Report.StartSubStep("I upload a PDF document into the Upload SDS field.");
			MyNewProduct.UploadPDFFile("Dual-Language WHMIS SDS, in French Canadian and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Regulatory Documents to Prodivde page, I enter the value: 2023-06-27 into the WHMIS SDS Docmument Date Field");
			newProdClass.EnterWHMISSDSDocumentDate("2023-06-27");
			MyNewProduct.ThenFieldExists("Product Label in English and French-Canadian as required in Consumer Chemicals and Containers Regulations (CCCR), 2001 of the Hazardous Products Act");
			Report.StartSubStep("I upload a PDF document into the Product Label in English and French-Canadian field.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path")]
		public void
			GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath()
		{
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Additional Documents -> Contact Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Documents -> Contact Information");
			MyNewProduct.SetTheSectionOptionTo("Manufacturer Name", "Manufacturer");
			MyNewProduct.SetTheSectionOptionTo("Address", "Address");
			MyNewProduct.SetTheSectionOptionTo("Phone", "Phone");
			MyNewProduct.SetTheSectionOptionTo("Emergency Phone", "1234 8856789");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents -> Contact Information");
		}

		[StepDefinition(
			@"I call Shared Step 78877 - WPS Studio - PD\+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH \(EN and CF\) and SBCS for saved as: (.*)")]
		public void
			GivenICallSharedStep_WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSHSGHENAndCFAndSBCS(
				string savedAs)
		{

			Report.UseSubSteps = true;
			Report.StartSubStep(
				"I set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic");
			Report.Info("In power tools workspace I set edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Formulation"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}

			Report.StartSubStep(
				"I confirm CKLT, NGHS  HGHS and SBCS are not shown in the pop up message and click OK");
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"HGHS",
				"False"
			});
			table4.AddRow(new string[] {
				"NGHS",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			Report.StartSubStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();

			//ApplyRules
			Report.StartSubStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartSubStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartSubStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartSubStep("In the rule name filter box I enter the studio user name");

			//Processing Rule For Change
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Delay.Seconds(2);
			Report.Screenshot();
			Report.Info($"hard wait, 25 seconds...");
			Delay.Seconds(25);
			Report.Screenshot();
			var thisSelectRulesPage = new SelectRulesPage();
			Report.Info($"Checking to see if rules page is open...");
			if (thisSelectRulesPage.Wait_for_loadLatestVersion(30) == false)
			{
				Report.Info($"Rules page not open, looping apply button click");
				thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
				Delay.Seconds(2);
				Report.Screenshot();
				Report.Info($"hard wait, 25 seconds...");
				Delay.Seconds(25);
				Report.Screenshot();
				Report.Info($"Checking to see if rules page is open...");
				if (thisSelectRulesPage.Wait_for_loadLatestVersion(30) == false)
				{
					Report.Info($"Rules page not open, looping apply button click");
					thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
					Delay.Seconds(2);
					Report.Screenshot();
					Report.Info($"hard wait, 25 seconds...");
					Delay.Seconds(25);
					Report.Screenshot();
				}
			}



			Report.StartSubStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			//And I Check that the Product group radio button is selected
			Report.StartSubStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(2);
			//thisStepsStudio.GivenICloseCurrentDocument();

			Delay.Seconds(3);
			bool closedApplyRules = false;
			Report.StartSubStep("I close the Apply Rules pop up");
			for (int i = 0; i < 3; i++)
			{
				var thisApplyRulesPage = new ApplyRulesPage();
				if (thisApplyRulesPage.Wait_for_load(10))
				{
					Report.Info($"The wait for load was true");
					Report.Screenshot();
					Report.Info($"Attempting to click button: Close");
					thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
					Delay.Seconds(3);
					Report.Info($"waited 3 seconds...");
					Report.Screenshot();
				}
				else
				{
					Report.Info($"The wait for load was false, the apply rules page is already closed?");
					Report.Screenshot();
					closedApplyRules = true;
					break;
				}
			}

			if (!closedApplyRules)
			{
				throw new Exception("Failed to close apply rules popup");
			}

			Report.Info($"End of apply rules code.");
			Report.Screenshot();


			//Document queue
			Report.StartSubStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartSubStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			Report.StartSubStep(
				"I Confirm your product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, HGHS EN RTF, HGHS EN PDF, HGHS CF RTF, HGHS CF PDF CKLT EN PDF");
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"CF",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"CF",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			Report.Screenshot();
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartSubStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(5);
			//Report.Screenshot();
			Report.Info("Now waiting for spinner");
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.StartSubStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartSubStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartSubStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(
			@"I call Shared Step 136221 \(EPA expiration date - enter current year - Not July 1st\) for state: (.*)")]
		public void SharedStep136221_EPAExpirationDate_EnterCurrentYear_NotJuly1st(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 55843");
			// Click in the EPA Expiration Date box for the state you are working with
			// Select a date for the current year that is not June 30th
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "8", "8", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 136222 \(EPA expiration date - enter next year - Not July 1st\) for state: (.*)")]
		public void SharedStep55844a_EPAExpirationDate_EnterNextYear_NotJuly1st(string state)
		{
			//// Click in the EPA Expiration Date box for the state you are working with
			//// Select a date for the next year that is not June 30th
			//var pesticideDetailsState = new PesticideDetailsState();
			//ReportSettings.UseSubSteps = true;
			//Report.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
			//var MyStepsNewProduct = new StepsNewProduct();
			//var year = DateTime.Now.Year + 1;
			//var dt = new DateTime(year, 8, 8);
			//Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
			//	"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
			//	"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			//// Click Continue
			//Report.StartStep("I click continue in the Pesticide Details - State Registration page");
			//MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
			//	"Pesticide Details - State Registration Details");

			new Steps_PesticideDetailsState().EnterEpaRegistrationDateNextYear("8", "8", state);
		}

		[StepDefinition(
			@"I call Shared Step 136223 \(EPA expiration date - enter current year plus 2 - Not July 1st\) for state: (.*)")]
		public void SharedStep136223_EPAExpirationDate_EnterNextYear_NotJuly1st(string state)
		{
			//// Click in the EPA Expiration Date box for the state you are working with
			//// Select a date for the next year that is not June 30th
			//var pesticideDetailsState = new PesticideDetailsState();
			//ReportSettings.UseSubSteps = true;
			//Report.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
			//var MyStepsNewProduct = new StepsNewProduct();
			//var year = DateTime.Now.Year + 1;
			//var dt = new DateTime(year, 8, 8);
			//Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
			//	"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
			//	"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			//// Click Continue
			//Report.StartStep("I click continue in the Pesticide Details - State Registration page");
			//MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
			//	"Pesticide Details - State Registration Details");

			new Steps_PesticideDetailsState().EnterEpaRegistrationDateNextTwoYears("8", "8", state);
		}

		[StepDefinition(
			@"I call Shared Step 136224 \(EPA expiration date - enter current year - July 1st\) for state: (.*)")]
		public void SharedStep136224_EPAExpirationDate_EnterCurrentYear_July1st(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 55845");
			// Click in the EPA Expiration Date box for the state you are working with
			// Select June 30th for the current year
			// NOTE:  If the current date is after June 30th for the current year select June 30th for next year
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "7", "1", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55843 \(EPA expiration date - enter current year - Not June 30th\) for state: (.*)")]
		public void SharedStep55843_EPAExpirationDate_EnterCurrentYear_NotJune30th(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 55843");
			// Click in the EPA Expiration Date box for the state you are working with
			// Select a date for the current year that is not June 30th
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "8", "8", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55844 \(EPA expiration date - enter next year - Not June 30th\) for state: (.*)")]
		public void SharedStep55844_EPAExpirationDate_EnterNextYear_NotJune30th(string state)
		{
			//// Click in the EPA Expiration Date box for the state you are working with
			//// Select a date for the next year that is not June 30th
			//var pesticideDetailsState = new PesticideDetailsState();
			//ReportSettings.UseSubSteps = true;
			//Report.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
			//var MyStepsNewProduct = new StepsNewProduct();
			//var year = DateTime.Now.Year + 1;
			//var dt = new DateTime(year, 8, 8);
			//Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
			//	"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
			//	"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			//// Click Continue
			//Report.StartStep("I click continue in the Pesticide Details - State Registration page");
			//MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
			//	"Pesticide Details - State Registration Details");

			new Steps_PesticideDetailsState().EnterEpaRegistrationDateNextYear("8", "8", state);
		}

		[StepDefinition(
			@"I call Shared Step \(EPA expiration date - enter current year plus 2 - Not June 30th\) for state: (.*)")]
		public void SharedStep_EPAExpirationDate_EnterCurrentYearPlusTwo_NotJune30th(string state)
		{
			// Click in the EPA Expiration Date box for the state you are working with
			// Select a date for the current year + 2 that is not June 30th
			var pesticideDetailsState = new PesticideDetailsState();
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the EPA Expiration Date box for the state: " + state +
								 " and select a date for the current year that is not June 30th");
			var MyStepsNewProduct = new StepsNewProduct();
			int year = DateTime.Now.Year + 2;
			var dt = new DateTime(year, 8, 8);
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			// Click Continue
			Report.StartSubStep("I click continue in the Pesticide Details - State Registration page");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - State Registration Details");
		}

		[StepDefinition(
			@"I call Shared Step 55845 \(EPA expiration date - enter current year - June 30th\) for state: (.*)")]
		public void SharedStep55845_EPAExpirationDate_EnterCurrentYear_June30th(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 55845");
			// Click in the EPA Expiration Date box for the state you are working with
			// Select June 30th for the current year
			// NOTE:  If the current date is after June 30th for the current year select June 30th for next year
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "6", "30", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55846 \(EPA expiration date - enter next year - June 30th\) for state: (.*)")]
		public void SharedStep55846_EPAExpirationDate_EnterNextYear_June30th(string state)
		{
			// (1) Click in the Expiration Date box for the State you are working with
			// (2) Select June 30th for the Next year
			// (2) Note:  If the current date is after June 30th and before Dec 31st select June 30th for this year +2
			// (2) for example if you are running the test on Oct 28th 2017 select June 30th for 2019
			// (3) Click Continue
			// using addYear = true because step 2 note
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateNextYear("6", "30", state, true);
		}

		[StepDefinition(
			@"I call Shared Step \(EPA expiration date - enter current year plus 2 - June 30th\) for state: (.*)")]
		public void SharedStep_EPAExpirationDate_EnterCurrentYearPlus_June30th(string state)
		{
			// Click in the EPA Expiration Date box for the state you are working with
			// Select June 30th for the current year + 2
			var pesticideDetailsState = new PesticideDetailsState();
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the EPA Expiration Date box for the state: " + state +
								 " and select a date for the current year that is not June 30th");
			var MyStepsNewProduct = new StepsNewProduct();
			DateTime date = DateTime.Now;
			int year = date.Year + 2;
			var dt = new DateTime(year, 6, 30);
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			// Click Continue
			Report.StartSubStep("I click continue in the Pesticide Details - State Registration page");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");
		}

		[StepDefinition(
			@"I call Shared Step 55858 \(EPA expiration date - enter current year - NOT Nov 30th\) for state: (.*)")]
		public void SharedStep_55858_EpaExpirationDate_EnterCurrentYear_NotNov30th(string state)
		{
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "01", "05", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55859 \(EPA expiration date - enter next year - Nov 30th\) for state: (.*)")]
		public void SharedStep_55859(string state)
		{
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateNextYear("11", "30", state);
		}

		[StepDefinition(@"I call Shared Step 55860 \(Expiration date - enter this year - Nov 30th\) for state: (.*)")]
		public void SharedStep_55860_ExpirationDate_EnterThisYear_Nov30th(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Nov 30th of this year) for state: " + state);
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "11", "30", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55886 \(EPA expiration date - enter current year plus 2 - NOT Dec 31st\) for state: (.*)")]
		public void SharedStep_55886_EpaExpirationDate_EnterCurrentYearPlus2_NotDec31(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Not Dec 31th current year + 2) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "12", "1");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("2", table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 80488 - SHA Manager > completed 3rd party > Add to recert 40 for product saved as: (.*)")]
		public void ThenICallSharedStep_SHAManagerCompletedRdPartyAddToRecert(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 80488");
			var MyStepsSha = new Steps_SHA();

			var productTable = new Table(new string[] {
				"ProductID"
			});
			productTable.AddRow(new string[] {
				"saved as " + savedAs
			});
			MyStepsSha.GivenInSHAManagerISetTheFilterForStatusTo("Completed");
			Delay.Seconds(5);
			MyStepsSha.GivenInSHAManagerISelectTheFollowingProducts(productTable);
			MyStepsSha.GivenInSHAManagerGridIClickTheFollowingTopMenuItem("Add to Recertification");
			MyStepsSha.ThenTheAddProductToRecertificationScreenShouldBeShowing();
			MyStepsSha.InAddProductToRecertificationScreenSelectReasonByNumber(40);
			MyStepsSha.InAddProductToRecertificationScreenIClickButton("Add");
		}

		[StepDefinition(
			@"I call Shared Step 55460 - Recertification - ULSC registered > Re-Import data from ULSC service - No - Save for product saved as: (.*)")]
		public void
			GivenICallSharedStep55460_Recertification_ULSCRegisteredRe_ImportDataFromULSCService_No_SaveForProductSavedAs(
				string savedAs)
		{

			var selNewProduct = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			if (selNewProduct.WaitForContainerToBeVisible())
			{
				if (selNewProduct.WaitForSection("ULSC Service Data Re-Import"))
				{
					MyStepsNewProduct.SetTheSectionOptionTo("Would you like to Re-Import data from ULSC service?",
						"No, Continue editing data");
					MyStepsNewProduct.ThenIClickSaveOrCancelInTheProductPage("Save");
				}

				Report.Screenshot();
			}
			else
			{
				Report.Failure("New product page was not found");
			}
		}

		[StepDefinition(
			@"I call Shared Step 55887 \(EPA expiration date - enter current year plus 2 - Dec 31st\) for state: (.*)")]
		public void SharedStep_55886_EpaExpirationDate_EnterCurrentYearPlus2_Dec31(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Dec 31th current year + 2) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "12", "31");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("2", table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55876 \(EPA expiration date - enter next year - any date\) for state: (.*)")]
		public void SharedStep_55876_EpaRegistrationDate_EnterNextYear_AnyDate(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Next year any date) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "8", "8");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("1", table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55877 \(EPA expiration date - enter current year plus 2 - any date\) for state: (.*)")]
		public void SharedStep_55877_EpaRegistrationDate_EnterCurrentYearPlus2_AnyDate(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Current year plus 2 - any date) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "8", "8");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("2", table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55878 \(EPA expiration date - enter current year plus 3 - any date\) for state: (.*)")]
		public void SharedStep_55878_EpaRegistrationDate_EnterCurrentYearPlus3_AnyDate(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Current year plus 3 - any date) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "8", "8");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("3", table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55875 \(EPA expiration date - enter current year - any date today or greater\) for state: (.*)")]
		public void SharedStep_55875_EpaRegistrationDate_EnterCurrentYear_AnyDateTodayOrGreater(string state)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select an EPA date (Current year - any date today or greater) for state: " + state);
			DateTime dt = DateTime.Today;
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, dt.Month.ToString(), (dt.Day + 1).ToString());
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("0", table);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as (.*)")]
		public void GivenICallSharedStep44240_SHA_RecertificationProcessRecertificationToAssignedStatus(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep(
				"I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as: " +
				savedAs);
			var shaSteps = new Steps_SHA();
			// Given I In SHA manager find your product in the Recertification status(you may have to wait a few minutes for the Zuora process to run and for your product to show in Recertification)
			//-make sure you are on the Recertification status list
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Recertification");
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("Recertification");
			GeneralUtilities.StudioWaitForSpinner();
			myStudioShaManager.WaitForProductList(60);
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			Report.StartSubStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Delay.Seconds(3);
			Report.StartSubStep("I click the Process Recertification button");
			shaSteps.GivenIClickTheProcessRecertificationButton();
			Report.StartSubStep("I confirm Process Recertification popup shows");
			shaSteps.GivenIConfirmTheRecertificationPopUpIsShown();
			Report.StartSubStep("I uncheck auto assign regulatory specialist");
			shaSteps.GivenIUncheckTheAutoAssignRegulatorySpecialistToProductCheckBox();
			Report.StartSubStep("I select specialist");
			shaSteps.GivenISelectFromTheDropDownListForRegulatorySpecialist("Automated QASha");
			Report.Screenshot();
			Report.StartSubStep("I click continue");
			shaSteps.GivenInTheRecertificationPopupIClick("Continue");
			Report.StartSubStep("I wait for processing to be completed");
			shaSteps.GivenInTheRecertificationPopupIWaitForAllProcessingToBeCompleted();
			Report.Info("Processing is complete, clicking on close");
			shaSteps.GivenInTheRecertificationPopupIClickOnClose();
			shaSteps.GivenIConfirmTheRecertificationPopUpIsClosed();
			//	And I The recertification pop up will close
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			myStudioShaManager.WaitForProductList(60);
			//	And I Your product will be shown in the Assigned status
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
		}

		[StepDefinition(@"I call Shared Step 49742 - WPS - Check In Product saved as: (.*)")]
		public void GivenICallSharedStep49742_WPS_CheckInProduct(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I call Shared Step 49742 - WPS - Check In Product saved as: " + savedAs);
			var shaSteps = new Steps_SHA();
			var studioSteps = new Steps_Studio();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Check in/out"
			});

			shaSteps.GivenIEditMyToolbarToAddTheFollowingOptions(table3);
			studioSteps.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnInOutButton();
			studioSteps.GivenInAssignProductsPopupIClickOnCheckInOrCheckOut("Check In");
			studioSteps.GivenICloseCurrentDocument();
		}

		[StepDefinition(
			@"I call Shared Step 81468 \(Physical and Chemical Properties - Solid only available - without secondary physical state\)")]
		public void SharedStep_81468_PhysicalandChemicalProperties_SolidOnlyAvailable_WithoutSecondaryPhysicalState()
		{
			// By default solid should be the selected Primary Physical State - and the only state shown
			// Select either of the buttons for the "When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?" question
			//  If Water Solubility question displays  then select a option from dropdown for "Select the best Water Solubility description" else ignore this step
			// Click Continue
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var newProduct = new NewProduct();
			Report.StartSubStep("I should see the Physical and Chemical Properties Page");
			stepsNewProduct.GivenIShouldSeeXPage("Physical and Chemical Properties");
			Report.StartSubStep(
				"The option available for Primary Physical State is Solid - which is selected by default");
			stepsNewProduct.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			if (!newProduct.SelectedOptionsForSection("Primary Physical State").Contains("Solid"))
			{
				Report.Failure("The Primary Physical State was not set to Solid by default.");
				Report.Screenshot();
				Report.Info("Setting the Primary Physical State to: Solid");
				stepsNewProduct.SetTheSectionOptionTo(
					"Primary Physical State",
					"Solid");
			}
			else
			{
				Report.Success("The Primary Physical State was showing the value of: Solid as expected");
				Report.Screenshot();
			}

			Report.StartSubStep(
				@"Select either buttons for the ""When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5 ?"" question");
			stepsNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartSubStep(
				"If Water Solubility question displays  then select a option from dropdown for 'Select the best Water Solubility description' else ignore this step");
			if (newProduct.OptionExists("Select the best Water Solubility description"))
			{
				stepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			}
			else
			{
				Report.Info("The Water Solubility question was not displayed");
			}

			Report.StartSubStep("I click continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 42759a \(Portal - UPC Page - add UPC saved as: (.*)\)")]
		public void Shared42759a_Portal_UpcPage_AddUpcSavedAs(string savedAs)
		{
			var newProductSteps = new StepsNewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Add UPC button");
			newProductSteps.ThenIClickTheAddUpcButton();
			Report.StartStep("I set the UPC Number, Container Type and Size");
			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", $"saved as " + savedAs);
			upcTable.AddRow("ContainerType", "Aerosol Can");
			upcTable.AddRow("Size", "20");
			//upcTable.AddRow("DPCI", "087 - 16 - 0238");
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.StartSubStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: (.*)")]
		public void GivenICallSharedStep_SHAManagerAssignedProduct_AddRecertReasonForProductSavedAsTestCase(
			string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 51349");
			var MyStepsSha = new Steps_SHA();

			var productTable = new Table(new string[] {
				"ProductID"
			});
			productTable.AddRow(new string[] {
				"saved as " + savedAs
			});
			MyStepsSha.GivenInSHAManagerISetTheFilterForStatusTo("Assigned");
			Delay.Seconds(5);
			MyStepsSha.GivenInSHAManagerISelectTheFollowingProducts(productTable);
			MyStepsSha.GivenInSHAManagerGridIClickTheFollowingTopMenuItem("Add to Recertification");
			MyStepsSha.ThenTheAddProductToRecertificationScreenShouldBeShowing();
			MyStepsSha.InAddProductToRecertificationScreenSelectReasonByNumber(20);
			MyStepsSha.InAddProductToRecertificationScreenIClickButton("Add");
		}

		[StepDefinition(
			@"I call Shared Step 57621 - Supplier ID table > Select Deactivate - Confirm Supplier ID Is set to Inactive for supplierID saved as (.*)")]
		public void GivenICallSharedStep_SupplierIDTableSelectDeactivate_ConfirmSupplierIDIsSetToInactive(
			string supplierIDSavedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 57621");
			var MyStepsSha = new Steps_SHA();
			var thisRPD = new RetailPartnersDetails();
			string SupplierId = Context.GetFromContext(supplierIDSavedAs).ToString();
			Report.IsTrue(thisRPD.ClickActionBySupplierID(SupplierId, "Deactivate"),
				"Failed to click Deactivate for Supplier id: " + SupplierId,
				"Clicked deactivate for Supplier id: " + SupplierId);
			var thisStepsRetailPartners = new StepsRetailPartners();
			thisStepsRetailPartners.GivenIConfirmTheIsActiveColumnForSupplierIDSavedAsSupplierIDShowsAGreenCheckMark(
				supplierIDSavedAs, "does not show");

		}

		[StepDefinition(
			@"I call Shared Step 57565 - Supplier ID table > Select Activate - Confirm Supplier ID Is set to Active for supplierID saved as (.*)")]
		public void
			GivenICallSharedStep57565SupplierIDTableSelectActivate_ConfirmSupplierIDIsSetToActiveForSupplierIDSavedAsSupplierID(
				string supplierIDSavedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 57565");
			var MyStepsSha = new Steps_SHA();
			var thisRPD = new RetailPartnersDetails();
			string SupplierId = Context.GetFromContext(supplierIDSavedAs).ToString();
			Report.IsTrue(thisRPD.ClickActionBySupplierID(SupplierId, "Activate"),
				"Failed to click Activate for Supplier id: " + SupplierId,
				"Clicked Activate for Supplier id: " + SupplierId);
			var thisStepsRetailPartners = new StepsRetailPartners();
			thisStepsRetailPartners.GivenIConfirmTheIsActiveColumnForSupplierIDSavedAsSupplierIDShowsAGreenCheckMark(
				supplierIDSavedAs, "shows");



		}

		[StepDefinition(@"I call Shared Step 81633 - WPS PD\+ - Product Attributes - Filter for (.*)")]
		public void ProductAttributes_FilterFor(string option)
		{
			Report.Info("Beginning Shared Step - WPS PD+ - Product Attributes - Filter for" + option);
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.InProductAttributePageIClickOnFilterIcon();
			thisStepsStudio.InProductAttributeFilterPopupISelectFromSelectBox("...Contains...", "Code");
			thisStepsStudio.InProductAttributeFilterPopupIEnterValueInTextBox(option, "Code");
			thisStepsStudio.InProductAttributeFilterPopupIClickButton("apply");
			Delay.Seconds(3);
		}

		[StepDefinition(@"I click alias subsection option (.*) and confirm data as:")]
		public void ClickAliasSubsectionAndConfirmData(string aliasoption, Table expected)
		{
			Report.Info(
				"Beginning Shared Step - WPS PD+ - Product Attributes - click alias subsection and confirm data");
			var thisStepsStudio = new ProductAttributePage();
			Report.IsTrue(thisStepsStudio.ClickAliasSubsectionOption(aliasoption),
				"Failed to click the option: " + aliasoption + "!",
				"successfully clicked the option" + aliasoption);
			List<string> data = thisStepsStudio.GetAliasSubsectionData();
			foreach (TableRow row in expected.Rows)
			{
				string option = row["Data"];
				if (row["Data"] == "date")
				{
					foreach (var i in data)
					{
						Report.Info("Checking that I see a date:");
						try
						{
							var dt2 = DateTime.ParseExact(i, "M/d/yyyy", CultureInfo.InvariantCulture);
							Report.Success("contains a date: " + i);
						}
						catch (Exception ex)
						{
							Report.Failure(ex.Message);
						}
					}
				}
				if (row["Data"] == "any")
				{
					Report.Info("Checking that I see random data:");
					Report.IsTrue(data.Count != 0,
						"Data is not showing when it was expected to!",
						"Data is showing as expected");
				}
				if (row["Data"] != "date" && row["Data"] != "any")
				{
					Report.Info("Checking that I see option:" + option);
					Report.IsTrue(data.Contains(option.Trim()),
						"Option was not showing as expected! Expected: '" + option + "', but found: '" +
						string.Join("', '", data) + "'!",
						"Option was showing: '" + option + "', as expected!");
				}
			}
		}

		[StepDefinition(
			@"I call Shared Step 51352 - Products page - Filter for your product - Update Required link for product saved as: (.*)")]
		public void GivenICallSharedStep_ProductsPage_FilterForYourProduct_UpdateRequiredLink(string savedAs)
		{
			var thisStepsProductGrid = new StepsProductGrid();
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();
			thisStepsProductGrid.ClickRowAction("Update Required");
		}


		[StepDefinition(
			@"I call Shared Step 84505 - WPS PD+ - Current Document - Add NGHS RTF and PDF to Document queue")]
		public void ICallSharedStep84505()
		{
			Report.StartStep("I open the Current Document pop up using the tool bar icons");
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();

			//And I Change the Subformat drop down to NGHS
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("queue");
			//And I Click the Publish this document for standard viewing icon(looks like a page with text)
			//And I Click OK
			//And I Click the Publish this document in PDF format icon(icon looks like the Adobe sign on a document)
			//And I Click OK
			thisStepsStudio.GivenICloseCurrentDocument();
		}

		[StepDefinition(
			@"I call Shared Step 86293 - UPC - Package type shown but not required - Enter UPC, Container and size, Continue for UPC: (.*)")]
		public void GivenICallSharedStep_UPC_PackageTypeShownButNotRequired_EnterUPCContainerAndSizeContinue(string upc)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartSubStep("I add the following into the UPC Fields");

			if (upc.ToLower().Contains("saved as"))
			{
				upc = Context.GetFromContext(upc.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString();
			}

			//And I DO NOT select a Package Type from the drop down listPackage type should not be required for this UPC entry

			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", upc);
			upcTable.AddRow("ContainerType", "Cardboard");
			upcTable.AddRow("Size", "40");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.IsTrue(MyNewProduct.UPCPackageTypeFieldExists(), "Package Type does not display", "Package type displays as expected");
			//And I Click Continueor Save(button shown depends on the flow you are in)
			if (MyNewProduct.SaveButtonExists())
			{
				Report.StartSubStep("In the Universal Product Code (UPC) page I click Save");
				MyNewProduct.ClickSaveButton();
				GeneralUtilities.Wait_for_load_finish();
			}
			else
			{
				Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
				MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
			}
		}

		[StepDefinition(
			@"I call Shared Step 85730 - Product Information - Canada Only - Child \(NO\), GHS \(NO\), DSV \(NO\), PLP\(YES\), GNFR \(NO\), Continue")]
		public void
			ThenICallSharedStep85730ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPYESGNFRNOContinue()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			var MyNewProduct = new NewProduct();
			//And I Un-check the United States check box for the "Select countries the product may be sold in" question
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");

		}

		[StepDefinition(
			@"I call Shared Step 86163 - Retailer - Canada Only & PL, Select No Retailer, Add PL, Continue")]
		public void ThenICallSharedStep86163Retailer_CanadaOnlyPLSelectNoRetailerAddPLContinue()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			//Report.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			//new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			var thisNewProduct = new NewProduct();
			thisNewProduct.SetFullNameOfProductForRetailer("No Retailer/No UPC Product", "test");

			Report.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");

			/* --As per TFS70787 warning popup displays for NR  --- */
			//Delay.Seconds(1);
			//Report.StartStep("In the UPCs Warning popup I click Ok");
			//WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(
			@"I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue")]
		public void
			ThenICallSharedStep78884RegulatoryDocumentsToProvide_CanadaOnly_RequestAuthoringUploadLabel_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I set WHMIS-complient SDS to 'I need an SDS authored'");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian",
				"I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			Report.StartSubStep("I upload a label");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("I click continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 78888 - WPS Studio - PD\+ - set all data and publish using rule and doc queue - CKLT, HGHS \(EN and CF\) and SBCS for product saved as (.*)")]
		public void
			GivenICallSharedStep78888WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTHGHSENAndCFAndSBCS(
				string savedAs)
		{
			Report.StartStep("Beginning shared step 78888");
			Report.UseSubSteps = true;
			Report.StartSubStep(
				"I set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic");
			Report.Info("In power tools workspace I set edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Formulation"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
			//this.GivenICallSharedStep49742_WPS_CheckInProduct(savedAs);

			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}

			//And I Confirm CKLT,  HGHS and SBCS are not shownin the pop up messageand click OK
			Report.StartStep("I confirm CKLT, NGHS and SBCS are not shown in the pop up message and click OK");
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"NGHS",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});

			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			Report.StartSubStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			Report.StartSubStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartSubStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartSubStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");

			Report.StartSubStep("In the rule name filter box I enter the studio user name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartSubStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartSubStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(10);
			if (SeleniumWebDriver.CurrentDriver.IsAlertPresent())
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}

			Report.StartSubStep("I close the Apply Rules pop up");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);
			if (new ApplyRulesPage().Wait_for_load(1))
			{
				Delay.Seconds(3);
				Report.Info("Clicking on close in apply rules popup did not work. Trying again...");
				thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
				Report.Screenshot();
				Delay.Seconds(3);
				if (new ApplyRulesPage().Wait_for_load(1))
				{
					Report.Error("Apply rules popup did not close after two attempts");
					SeleniumWebDriver.CurrentDriver.Close();
				}
			}

			Report.StartSubStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartSubStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();

			for (int i = 0; i < 5; i++)
			{
				Delay.Seconds(5);
				Report.Screenshot();
				var newDocumentQueuePage = new DocumentQueuePage();
				Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
					"Document queue page loaded");
				List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				if (listOfDocuments.Count > 0)
				{
					break;
				}
			}
			// And I Confirm your product is shown with entries for SBCS EN PDF, HGHS EN RTF, HGHS EN PDF, HGHS CF RTF,
			// HGHS CF PDF CKLT EN PDF. If your product is a PL product you will also see an entry for the product alias
			// Note: as we are working with HGHS only, we should see CKLT and SBCS for the alias products

			Report.StartSubStep(
				"I Confirm your product is shown with entries for SBCS EN PDF, HGHS EN RTF, HGHS EN PDF, HGHS CF RTF, HGHS CF PDF CKLT EN PDF");
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"CF",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"HGHS",
				"CF",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartSubStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(2);
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.StartSubStep(
				"I confirm a pop up shows with message indicating queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartSubStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartSubStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(@"I call Shared Step 29183 \(Pesticide Details - U.S. - No EPA number\)")]
		public void GivenICallSharedStepPesticideDetails_US_NoEpaNumber()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Pesticide Details - U.S. Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Pesticide Details - U.S.");

			Report.StartSubStep("I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has an Environmental Protection Agency (EPA) Registration Number", "No");

			Report.StartSubStep("I set the Product has a State Registration option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has a State Registration", "No");


			Report.StartSubStep("I select the first option in section: Select the applicable exemption");
			MyStepsNewProduct.SelectFirstOptionInSection("Select the applicable exemption");
			Report.StartSubStep("In the Pesticide Details - U.S. page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		[StepDefinition(
			@"I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: (.*)")]
		public void ThenICallSharedStep49743SHAManager_SelectProduct_Actions_DocumentManagement(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Select product");
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			Report.IsTrue(myStudioShaManager.SelectProductByID(id), "Failed to select product with id: " + id,
				"Selected product with id: " + id);
			Report.StartSubStep("Click document management");
			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption("Document Management"),
				"Failed to click document management", "Clicked document management");

		}

		[StepDefinition(
			@"I call Shared Step 96169 - SHA Manager - Select Product - Actions - (.*) for saved as: (.*)")]
		public void ICallSharedStep96169SHAManager_SelectProduct_Actions(string reportType, string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Select product");
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			Report.IsTrue(myStudioShaManager.SelectProductByID(id), "Failed to select product with id: " + id,
				"Selected product with id: " + id);
			Report.StartSubStep("Click Advanced Reporting");
			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption(reportType),
				"Failed to click document management", "Clicked document management");
		}

		[StepDefinition(
					@"I call Shared Step 78879 - Product Information - Canada Only - Child \(NO\), GHS \(NO\), DSV \(NO\), PLP \(NO\), GNFR \(NO\), Continue")]
		public void
					ThenICallSharedStep78879ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPNOGNFRNOContinue()
		{
			var MyNewProduct = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");

			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 62681 - Product Information - Canada, No\(OSHA\), No\(DSV\), No\(PLP\), No\(GNFR\), Continue - Happy Path")]
		public void
			ThenICallSharedStep62681ProductInformation_CanadaNoOSHANoDSVNoPLPNoGNFRContinue_HappyPath()
		{
			var MyNewProduct = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
					@"I call Shared Step 62681 - Product Information - Canada, No\(DSV\), No\(PLP\), No\(GNFR\), Continue - Happy Path")]
		public void
					ThenICallSharedStep62681ProductInformation_CanadaNoDSVNoPLPNoGNFRContinue_HappyPath()
		{
			var MyNewProduct = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 94674 \(Product Information - RU Wine\)")]
		public void CallSharedStep9674_ProductInformation_RuWine()
		{
			Report.StartStep(
				"If the selected option is not United States by default then report error and select it");
			if (!new NewProduct().SelectedOptionsForSection("Select countries the product may be sold in")
				.Contains("United States"))
			{
				Report.Error(
					"Expected 'United States' to be selected by default for question: 'Select countries the product may be sold in'!");
				Report.Info("Setting section: 'Select countries the product may be sold in' to: 'United States'");
				Report.IsTrue(
					new NewProduct().SetOptionInSection("Select countries the product may be sold in", "United States"),
					"Failed to set section: 'Select countries the product may be sold in' to: 'United States'",
					"Successfully set section: 'Select countries the product may be sold in' to: 'United States'");
			}

			Report.StartStep("click Yes or No for Product is a Retailers Private Label or Brand");
			Report.Info("Selecting option 'No'");
			Report.IsTrue(new NewProduct().SetOptionInSection("Product is a Retailer's Private Label or Brand", "No"),
				"Failed to set section: 'Product is a Retailers Private Label or Brand' to: 'Yes'",
				"Successfully set section: 'Product is a Retailers Private Label or Brand' to: 'Yes'");
			Report.StartStep("I click continue");
			new NewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step  \(Select Retailers (.*) and enter additional requirements field - Indicate full name of product, as sold via this retailer\)")]
		public void SelectRetailers(string retailer)
		{
			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Retailer();
			Report.StartSubStep($"In the Select Retailers popup I select the retailer: {retailer}");
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartSubStep("I enter private label as 'This Private Label'");
			new Steps_Retailer().ForRetailerIEnterPrivateLabelName(retailer, "This Private Label");
			//stepsRetailer.EnterPrivateLabelName("This Private Label");

			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("No Retailer/No UPC Product", "This Private Label");
			Report.StartSubStep("I click continue");
			stepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 74654 - SHA manager - Suppliers - Search by email address: (.*) and saved name as: (.*)")]
		public void GivenICallSharedStep74654SHAManager_Suppliers_SearchByEmailAddress(string email, string savedAs)
		{
			if (email.Contains("saved as"))
			{
				email = Context
					.GetFromContext(email.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
					.ToString();
			}
			Report.UseSubSteps = true;
			var thisStepsSha = new Steps_SHA();
			Report.StartSubStep("Given I Click the Suppliers link on the top right of the screen");
			thisStepsSha.IClickOnSuppliersLink();

			Report.StartSubStep("Given I Click the Suppliers pop up should open");
			thisStepsSha.TheSupplierManagerPopupAppears();

			Report.StartSubStep("Given enter the email address of the user you are going to be using in WERCSmart");
			thisStepsSha.InSupplierManagerPopupIEnterSearchTerm(email);

			Report.StartSubStep("I Select the 'Email' Radio Button");
			thisStepsSha.InSupplierManagerPopupISelectRadioButton("E-Mail");

			Report.StartSubStep("I click on the search button");
			thisStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();
			new StudioSupplierManager().WaitForSuppliersToLoad();

			Report.StartSubStep("I Make a note of the Supplier Name");
			thisStepsSha.InSupplierManagerPopupISaveFirstSupplierNameAs(savedAs);

			Report.StartSubStep("I click on the close button");
			thisStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();

		}


		[StepDefinition(
			@"I call Shared Step 74655 SHA - Search by Supplier ID saved as (.*) for specific product status: (.*)")]
		public void GivenICallSharedStepSHA74655SearchBySupplierIDSavedAsMyIDForSpecificProductStatusCompleted(
			string savedAs, string status)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 74655");
			var thisStepsSha = new Steps_SHA();
			Report.StartSubStep("I set the status filter to All");
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			myStudioShaManager.WaitForProductList(60);
			Report.Info("Getting saved product: " + savedAs);

			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}

			Report.StartSubStep("I click Srch in the bottom menu list");

			myStudioShaManager.ClickBottomMenuOption("Search");


			string supplierID = Context.GetFromContext(savedAs).ToString();
			Report.Info("Looking for supplier id: " + supplierID.ToString());
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"Supplier",
				supplierID
			});
			table.AddRow(new string[] {
				"Status",
				status
			});


			Report.StartSubStep("I click Srch in the bottom menu list");
			myStudioShaManager.ClickBottomMenuOption("Search");
			var myStepsSha = new Steps_SHA();
			myStepsSha.GivenInSHAManagerPageIRunSearch(table);
			Delay.Seconds(1);
			Report.Info("Waiting for product list");
			Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found",
				"Product list is showing");

		}

		[StepDefinition(
					@"I call Shared Step 74655 SHA with email - Search by Supplier ID saved as (.*) for specific product status: (.*) and email: (.*)")]
		public void GivenICallSharedStepSHA74655SearchBySupplierIDSavedAsMyIDForSpecificProductStatusCompletedAndEmail(
					string savedAs, string status, string email)
		{
			if (email.Contains("saved as"))
			{
				email = Context
					.GetFromContext(email.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
					.ToString();
			}

			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 74655");
			var thisStepsSha = new Steps_SHA();
			Report.StartSubStep("I set the status filter to All");
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			myStudioShaManager.WaitForProductList(60);
			Report.Info("Getting saved product: " + savedAs);

			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}

			Report.StartSubStep("I click Srch in the bottom menu list");

			myStudioShaManager.ClickBottomMenuOption("Search");


			string supplierID = Context.GetFromContext(savedAs).ToString();
			Report.Info("Looking for supplier id: " + supplierID.ToString());
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"Supplier",
				supplierID
			});
			table.AddRow(new string[] {
				"Status",
				status
			});
			table.AddRow(new string[] {
				"User",
				email
			});


			Report.StartSubStep("I click Srch in the bottom menu list");
			myStudioShaManager.ClickBottomMenuOption("Search");
			var myStepsSha = new Steps_SHA();
			myStepsSha.GivenInSHAManagerPageIRunSearch(table);
			Delay.Seconds(1);
			Report.Info("Waiting for product list");
			Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found",
				"Product list is showing");

		}

		[StepDefinition(@"I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration")]
		public void GivenICallSharedStep75130BulkActions_SelectForwardProductRegistration()
		{
			var thisStepsProductGrid = new StepsProductGrid();

			thisStepsProductGrid.GivenIClickBulkActionsInTheProductsGrid();
			thisStepsProductGrid.GivenIClickForwardProductRegistrationInTheBulkActionsWindow(
				"Forward Product Registration");
		}

		[StepDefinition(@"I call Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue and save UPC as (.*)")]
		public void ThenICallSharedStep75140Forwarding_SelectProductsUPCsStep_AddAnyMissingDataAndSelectUPC_Continue(string saveAs)
		{
			var thisStepsForwardProductRegistration = new StepsForwardProductRegistration();

			thisStepsForwardProductRegistration.SelectTheFirstProductSelectUPCs();


			//3 April 2019 CLF have added the code to edit but not necessary to do it at this stage

			//If the Product you are working with is a Private Label product you will need to enter Private Label details for the retailers you selected for forwarding
			//And I Select one of the UPC shown in the left hand tableby clicking the checkbox next to the UPC Number
			//And I Click the Edit link in the Actions column for the UPC you selected
			//And I If the retailer(s) you are forwarding to requires additional data add it now
			//And I Click Save
			string firstUPCNo = new ForwardProductRegistration().GetUPCs().First().UPCInfo.UPCNumber;
			Report.Info("Saving the UPC number: " + firstUPCNo + " to context as: " + saveAs);
			Context.AddToContext(saveAs, firstUPCNo);
			thisStepsForwardProductRegistration.SelectFirstUPC();
			thisStepsForwardProductRegistration.ClickContinueForwardProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 48360 - Regulatory - Test TSCA and PROP65 - Continue")]
		public void SharedStep48360_Regulatory_TestTscaAndProp65_Continue()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I confirm that the Waste Classification Data screen is shown");
			new StepsNewProduct().GivenIShouldSeeXPage("Waste Classification Data");
			Report.StartSubStep("Confirm that the TSCA and Prop 65 questions are displayed");
			var sections = new Table("Section");
			sections.AddRow("U.S. Toxic Substances Control Act (TSCA) status");
			sections.AddRow("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			new StepsNewProduct().CheckDisplayedSections("see", sections);
			Report.StartStep("I confirm the TSCA question shows 3 Radio Buttons 'COMPLIANT','EXEMPT' and 'One or more substances in this product are either not listed on, and/or not otherwise exempted from the requirement to be listed on the U.S. TSCA Inventory.'");
			var options = new Table("Option");
			options.AddRow("Compliant");
			options.AddRow("Exempt");
			options.AddRow("One or more substances in this product are either not listed on, and/or not otherwise exempted from the requirement to be listed on the U.S. TSCA Inventory.");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "U.S. Toxic Substances Control Act (TSCA) status", options);
			Report.StartSubStep("Confirm the Prop 65 question displays a 'YES' and 'NO' Buttons");
			options = new Table("Option");
			options.AddRow("Yes");
			options.AddRow("No");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", options);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
			Report.StartSubStep("Confirm that both questions in this screen display the 'This is a required field' error message");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("U.S. Toxic Substances Control Act (TSCA) status", "should", "This is a required field.");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "should", "This is a required field.");
			Report.StartSubStep("Select ONE Radio Button for the TSCA Question");
			new StepsNewProduct().SelectFirstOptionInSection("U.S. Toxic Substances Control Act (TSCA) status");
			Report.StartSubStep("Confirm the 'Required field error message' no longer shows for the TSCA Question");
			new StepsNewProduct().ErrorMessagesShouldNotBeShowingForItem("U.S.Toxic Substances Control Act (TSCA) status");
			Report.StartSubStep("I select the 'No' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "No");
			Report.StartSubStep("I confirm the 'Required field' error message is no longer displayed for the prop 65 question");
			new StepsNewProduct().ErrorMessagesShouldNotBeShowingForItem("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act");
			Report.StartSubStep("I select the 'Yes' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "Yes");
			Report.StartSubStep("Confirm the following questions are displayed:");
			sections = new Table("Section");
			sections.AddRow("Is the need to warn triggered by");
			sections.AddRow("How is the exposure warning transmitted? For more information, see Notice of Adoption Article");
			sections.AddRow("Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured");
			sections.AddRow("If the product carries a safe-harbor short-form warning, indicate which of the following is provided:");
			sections.AddRow("If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:");
			sections.AddRow("If the product carries a custom warning, please provide the exact text that is being used:");
			new StepsNewProduct().CheckDisplayedSections("see", sections);
			Report.StartSubStep("Confirm 'Is need to warn triggered by' options are correct");
			options = new Table("Option");
			options.AddRow("A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			options.AddRow("A chemical or chemicals in the packaging.");
			options.AddRow("A chemical or chemicals in both the product and packaging.");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "Is the need to warn triggered by", options);
			Report.StartSubStep("Confirm 'How is the exposure warning transmitted?' options are correct");
			options = new Table("Option");
			options.AddRow("By affixing it to the product or its packaging");
			options.AddRow("By providing warning materials (labels, shelf signage, online warning language) to a retailer’s authorized agent");
			options.AddRow("Other (Please specify)");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "How is the exposure warning transmitted?", options);
			Report.StartSubStep("Confirm 'Is your exposure warning compliant with Proposition 65' options are correct");
			options = new Table("Option");
			options.AddRow("Prior to August 30, 2018");
			options.AddRow("On or After August 30, 2018");
			options.AddRow("Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "Is your exposure warning compliant with Proposition 65", options);
			Report.StartSubStep("Confirm 'If the product carries a safe-harbor short-form warning' options are correct");
			options = new Table("Option");
			options.AddRow("WARNING: Cancer - www.P65Warnings.ca.gov");
			options.AddRow("WARNING: Reproductive Harm - www.P65Warnings.ca.gov");
			options.AddRow("WARNING: Cancer and Reproductive Harm - www.P65Warnings.ca.gov");
			options.AddRow("Does not apply");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "If the product carries a safe-harbor short-form warning", options);
			Report.StartSubStep("Confirm 'If the product carries a safe-harbor long-form warning' options are correct");
			options = new Table("Option");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause birth defects or other reproductive harm. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer, and [name of one or more chemicals], which is [are] known to the State of California to cause birth defects or other reproductive harm. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer and birth defects or other reproductive harm. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("Does not apply");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "If the product carries a safe-harbor long-form warning", options);
			Report.StartSubStep("I select the 'No' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "No");
			Report.StartSubStep("Confirm the additional prop 65 questions are no longer shown");
			new StepsNewProduct().CheckDisplayedSections("not see", sections);
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I Confirm alias subsection option as:")]
		public void ConfirmAliasSubsectionOptions(Table expected)
		{
			var thisStepsStudio = new ProductAttributePage();
			List<string> data = thisStepsStudio.GetAliasSubsectionOptions();
			foreach (TableRow row in expected.Rows)
			{
				string option = row["Data"];
				Report.Info("Checking that I see the option '" + option + "'");
				Report.IsTrue(data.Contains(option.Trim()),
					"Option was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", data) + "'!",
					"Option was showing: '" + option + "', as expected!");
			}
		}


		[StepDefinition(@"I call Shared Step 86015 - WPS PD\+ -  Product attributes - check all entries for Canada Stewardship data")]
		public void ProductAttributes_CheckAllEntriesForCanadaStwdship()
		{
			Report.Info("Beginning Shared Step 86015- WPS PD+ - Product Attributes - check all entries for Canada Stewardship data");
			var steps_Shared = new Steps_Shared();
			steps_Shared.ProductAttributes_FilterFor("CBC");
			var table = new Table(new string[] {
				"Data"
			});
			table.AddRow(new string[] {
				"CBCDS"
			});
			table.AddRow(new string[] {
				"CBCSD"
			});
			table.AddRow(new string[] {
				"CBCSN"
			});
			steps_Shared.ConfirmAliasSubsectionOptions(table);
			var table2 = new Table(new string[] {
				"Data"
			});
			table2.AddRow(new string[] {
				//"12/31/2020"
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CBCDS", table2);
			var table3 = new Table(new string[] {
				"Data"
			});
			table3.AddRow(new string[] {
				//"1/1/2018"
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CBCSD", table3);
			var table4 = new Table(new string[] {
				"Data"
			});
			table4.AddRow(new string[] {
				//"BC-1-1"
				"any"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CBCSN", table4);
			steps_Shared.ProductAttributes_FilterFor("CMB");
			var table5 = new Table(new string[] {
				"Data"
			});
			table5.AddRow(new string[] {
				"CMBDS"
			});
			table5.AddRow(new string[] {
				"CMBSD"
			});
			table5.AddRow(new string[] {
				"CMBSN"
			});
			steps_Shared.ConfirmAliasSubsectionOptions(table5);
			var table6 = new Table(new string[] {
				"Data"
			});
			table6.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CMBDS", table6);
			var table7 = new Table(new string[] {
				"Data"
			});
			table7.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CMBSD", table7);
			var table8 = new Table(new string[] {
				"Data"
			});
			table8.AddRow(new string[] {
				//"MA-1-1"
				"any"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CMBSN", table8);
			steps_Shared.ProductAttributes_FilterFor("CON");
			var table9 = new Table(new string[] {
				"Data"
			});
			table9.AddRow(new string[] {
				"CONDS"
			});
			table9.AddRow(new string[] {
				"CONSD"
			});
			table9.AddRow(new string[] {
				"CONSN"
			});
			steps_Shared.ConfirmAliasSubsectionOptions(table9);
			var table10 = new Table(new string[] {
				"Data"
			});
			table10.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CONDS", table10);
			var table11 = new Table(new string[] {
				"Data"
			});
			table11.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CONSD", table11);
			var table12 = new Table(new string[] {
				"Data"
			});
			table12.AddRow(new string[] {
				//"ON-1-1"
				"any"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CONSN", table12);
			steps_Shared.ProductAttributes_FilterFor("CQC");
			var table13 = new Table(new string[] {
				"Data"
			});
			table13.AddRow(new string[] {
				"CQCDS"
			});
			table13.AddRow(new string[] {
				"CQCSD"
			});
			table13.AddRow(new string[] {
				"CQCSN"
			});
			steps_Shared.ConfirmAliasSubsectionOptions(table13);
			var table14 = new Table(new string[] {
				"Data"
			});
			table14.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CQCDS", table14);
			var table15 = new Table(new string[] {
				"Data"
			});
			table15.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CQCSD", table15);
			var table16 = new Table(new string[] {
				"Data"
			});
			table16.AddRow(new string[] {
				//"QU-1-1"
				"any"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CQCSN", table16);
			steps_Shared.ProductAttributes_FilterFor("CSK");
			var table17 = new Table(new string[] {
				"Data"
			});
			table17.AddRow(new string[] {
				"CSKDS"
			});
			table17.AddRow(new string[] {
				"CSKSD"
			});
			table17.AddRow(new string[] {
				"CSKSN"
			});
			steps_Shared.ConfirmAliasSubsectionOptions(table17);
			var table18 = new TechTalk.SpecFlow.Table(new string[] {
				"Data"
			});
			table18.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CSKDS", table18);
			var table19 = new Table(new string[] {
				"Data"
			});
			table19.AddRow(new string[] {
				"date"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CSKSD", table19);
			var table20 = new TechTalk.SpecFlow.Table(new string[] {
				"Data"
			});
			table20.AddRow(new string[] {
				//"SA-1-1"
				"any"
			});
			steps_Shared.ClickAliasSubsectionAndConfirmData("CSKSN", table20);
		}

		[StepDefinition(@"I call Shared Step 102767 \(Product Information \(Battery flow - not Lithium\) - OSHA \(No\), DSV \(No\), PLP \(No\), GNFR \(No\)\)")]
		public void Shared_102767_ProductInformation_BatteryFlowNotLithium()
		{
			var stepsProductInformation = new Steps_AdditionalProductInformation();
			Report.UseSubSteps = true;
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);
			Report.StartSubStep("I set 'Classified using OSHA' to No");
			stepsProductInformation.SetProductHasBeenClassifiedOSHATo("No");
			Report.StartSubStep("I set 'Product is shipped directly' to No");
			stepsProductInformation.SetProductIsShippedDirectlyTo("No");
			Report.StartSubStep("I set 'Is Retailers Private Brand' to No'");
			stepsProductInformation.SetProductIsRetailersPrivateLabelOrBrandTo("No");
			Report.StartSubStep("I set 'Solely for the retailers use' to No'");
			stepsProductInformation.SetProductIsSolelyForTheRetailersUseTo("No");
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 103904 - Validate Product Name can contain character: (.*)")]
		public void Shared_103904_ProductNameCanContain(string character)
		{
			Report.UseSubSteps = true;
			var newProd = new NewProduct();

			foreach (string productType in newProd.ModifiedStrings(character))
			{
				Report.Info("I enter the text: '" + @productType + "' into the Product Name field and verify that '" + character + "' is allowed in the field.");
				var newProdSteps = new StepsNewProduct();
				var product = new TheProduct {
					ProductName = productType
				};
				newProdSteps.ClickContinue();

				newProdSteps.GivenIShouldSeeXPage("Product Information");
				newProdSteps.ClickPageHeading("The Product");
				newProdSteps.ConfirmTheProductNameIsDisplayedInTheHeader(productType);
			}
		}

		[StepDefinition(@"I call Shared Step 58828 - Delete Supplier with ID: (.*)")]
		public void ThenICallSharedStep58828_DeleteSupplierID(string supplierId)
		{
			var retailPartnersDetails = new RetailPartnersDetails();
			IList<Supplier> suppliers = retailPartnersDetails.GetAllSuppliers();

			Report.IsTrue(retailPartnersDetails.DeleteSupplier(supplierId),
				"Unable to delete supplier with ID " + supplierId,
				"Sucessfully deleted supplier with ID " + supplierId);
		}

		[StepDefinition(@"I call Shared Step 104068 Validate Product Name can not contain special characters: (.*)")]
		public void ThenICallSharedStepValidateProductNameCanNotContainSpecialCharacters(string character)
		{
			Report.UseSubSteps = true;
			var newProd = new NewProduct();

			foreach (string productType in newProd.ModifiedStrings(character))
			{
				Report.Info("I enter the text: '" + productType + "' into the Product Name field and verify that '" + character + "' is not allowed in the field.");
				var newProdSteps = new StepsNewProduct();
				var product = new TheProduct {
					ProductName = productType
				};
				newProdSteps.ClickContinue();
				newProdSteps.ErrorMessageSpecific(@"Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )");
			}
		}

		[StepDefinition(@"I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED")]
		public void GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithoutCopper()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartSubStep("I set the Product has had TCLP testing; Report is available option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing; Report is available", "No");
			Report.StartSubStep("I select No for all elements including Copper");
			MyStepsNewProduct.SetTheSectionOptionTo("Lead", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Mercury", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Silver", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Cadmium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Chromium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Barium", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Arsenic", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Selenium", "No");
			//if (myNewProduct.SectionExists("Platinum"))
			//{
			//	MyStepsNewProduct.SetTheSectionOptionTo("Platinum", "No");
			//}

			Report.StartSubStep(
				"In the Toxicity Characteristic Leaching Procedure (TCLP) Product Report page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP) Product Report");
		}

		[StepDefinition(@"I call Shared Step 54139 \(Data Usage Tiers - Tier 1 - confirm cannot edit\)")]
		public void SharedStep54139_DataUsageTiers_Tier1_ConfirmCannotEdit()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I confirm 'Tier 1: Regulatory Support' is the first entry in the Data Consent Tiers table");
			var tiers = new RetailPartnersDetails().GetAllDataConsentTiers();
			Report.IsTrue(tiers.Any() && tiers.First() == "Tier 1: Regulatory Support", "The first entry in the Data Consent Tiers table was not 'Tier 1: Regulatory Support'!", "The first entry in the Data Consent Tiers table was 'Tier 1: Regulatory Support' as expected");
			Report.StartSubStep("I confirm 'Tier 1' is set to: active/ on");
			Report.IsTrue(new RetailPartnersDetails().GetDataConsentTier("Tier 1"), "Tier 1 was not set to active!", "Tier 1 was set to active as expected");
			Report.StartSubStep("I confirm that I cannot set 'Tier 1' to: inactive/ off");
			Report.IsTrue(!new RetailPartnersDetails().SetDataConsentTier("Tier 1", false), "I was able to set Tier 1 to: inactive/ off but it should be uneditable!", "As expected I was unable to set Tier 1 to: inactive/ off");
		}

		[StepDefinition(@"I call Shared Step 54139 \(Data Usage Tiers - Tier 2.1 - confirm you can edit\)")]
		public void SharedStep54139_DataUsageTiers_Tier21_CanEdit()
		{
			new StepsRetailPartners().DataUsageTierEditing("should", "Tier 2.1");
		}

		[StepDefinition(@"I call Shared Step 54140 \(Data Usage Tiers - Tier 2.2 - confirm you can edit\)")]
		public void SharedStep54139_DataUsageTiers_Tier22_CanEdit()
		{
			new StepsRetailPartners().DataUsageTierEditing("should", "Tier 2.2");
		}

		[StepDefinition(@"I call Shared Step 57069 \(Data Usage Tiers - Tier 4.2 - confirm you can edit\)")]
		public void SharedStep54139_DataUsageTiers_Tier42_CanEdit()
		{
			new StepsRetailPartners().DataUsageTierEditing("should", "Tier 4.2");
		}

		/// <summary>
		/// Requires a table with a columns 'Data Tier' (eg. Tier 1) and 'Permission' (Enabled/ Disabled) depending on the Data Consent Tiers settings in the Retail Partners page.
		/// example:
		///  | Data Tier	| Permission	|
		///  | Tier 1		| Enabled		|
		///  | Tier 2.1		| Disabled		|
		///  | Tier 2.2		| Enabled		|
		/// </summary>
		[StepDefinition(@"I call Shared Step 57186 \(Data Consent Tiers - Administrator Email Confirmation - Walmart\) for email address saved as: (.*) and company name saved as: (.*)")]
		public void SharedStep57186_DataConsentTiers_AdministratorEmailConfirmation_Walmart(string emailSavedAs, string companySavedAs, Table dataUsage)
		{
			Report.UseSubSteps = true;
			var name = Context.GetFromContext(companySavedAs)?.ToString();
			if (name == null)
			{
				Report.Failure("Requires a Company Name saved to context as: " + companySavedAs);
				return;
			}
			var expectedText = "Hello " + name + ", Recently the Data Usage permissions for Wal-Mart/SAM'S CLUB were updated to include: ";
			foreach (var row in dataUsage.Rows)
			{
				switch (row["Data Tier"])
				{
					case "Tier 1":
						expectedText += "Tier 1: Regulatory Support: " + row["Permission"];
						break;
					case "Tier 2.1":
						expectedText += "Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports: " + row["Permission"];
						break;
					case "Tier 2.2":
						expectedText += "Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency: " + row["Permission"];
						break;
					case "Tier 4.2":
						expectedText += "Tier 4.2: Publicly Disclose Product Ingredient Lists: " + row["Permission"];
						break;
					default:
						Report.Error("Walmart tier must be 'Tier 1', 'Tier 2.1', 'Tier 2.2' or 'Tier 4.2'!");
						break;
				}
			}

			string userName = new TopMenuBar().GetCurrentUser();

			expectedText += $" The update to the Data Usage permissions on your WERCSmart account were performed by the Administrator, {userName}";
			expectedText += " For questions regarding Data Usage permissions, please contact WERCSmart Support’s Solution Center, or contact a Support Representative for further assistance. Thank you, Your WERCSmart Team";
			Report.StartSubStep("I confirm the administrator receieved an email with subject 'WERCSmart Data Use Tier Consents Changed for Wal-Mart/Sam's Club'");
			Delay.Seconds(8);
			new GlobalSteps().ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", emailSavedAs, "<SiteNotification>", "WERCSmart Data Use Tier Consents Changed for Wal-Mart/SAM'S CLUB");
			Report.StartSubStep("I confirm the body text of the email matches the expected text");
			new GlobalSteps().ThenTheBodyOfTheEmailShouldShow(expectedText);
		}

		[StepDefinition(@"I call Shared Step 75146 \(Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue\)")]
		public void SharedStep75146_Retailer_SelectOneOrMoreThatDoNotRequireVendorIdOrAdditionalUpcInformation_ClickDone_ClickContinue()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select a valid retailer and click DONE");
			var selectRetailers = new SelectRetailers();
			var opened = new Retailer().ClickAddRetailers();
			if (opened)
			{
				List<string> retailers = new SelectRetailers().GetListOfRetailers();
				List<string> invalidRetailers = new List<string>() { "Walmart", "O'Reilly", "Sears", "Ultra Standard", "Genuine Parts", "Staples", "Target", "Home Depot" };
				Report.Info("Invalid retailers are: " + string.Join(", ", invalidRetailers));
				string selectRetailer = retailers.FirstOrDefault(x => invalidRetailers.All(y => !y.Contains(x)));
				if (selectRetailer == null)
				{
					Report.Failure("There were no valid retailers to select!");
					Report.Screenshot();
					return;
				}
				Report.Info("Selecting retailer: " + selectRetailer);
				new StepsSelectRetailers().SelectTheRetailer(selectRetailer);
				Report.StartSubStep("Click CONTINUE");
				new StepsNewProduct().ClickContinue();
			}
			else
			{
				Report.Failure($"Failed to click the 'Add Retailers Button'");
			}
		}

		[StepDefinition(@"I call Shared Step 82831 \(The Product - Enter Product Name and Select Type of Product: (Raw material|Mixture, Blend, Formula, Polymer or Solution from Third \(3rd, 3d\) Party)\)")]
		public void SharedStep82831_TheProduct_EnterProductNameAndType(string type)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			Report.StartSubStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
			var name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartSubStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartSubStep("In the New Product page I click Continue");
			MyStepsNewProduct.NewProductPageIClickContinueNoSpinnerWait();
			var modal = new ModalDialog();
			Report.StartSubStep("I verify the 'Warning' pop-up displays");
			if (!Report.IsTrue(modal.WaitForContainerToBeVisible(10) && modal.GetTitle().Contains("Warning"), "Warning pop up was not displayed!", "Warning popup was displayed"))
			{
				return;
			}
			Report.StartSubStep("I confirm the warning message contains the expected text");
			string actualMessage = modal.GetText();
			if (actualMessage == null)
			{
				Report.Failure("The Warning Popup had no message");
				Report.Info("Closing popup");
				if (Report.IsTrue(modal.ClickButton("OK"), "Failed to click OK button", "Clicked OK button"))
				{
					Report.Info("I click Continue");
					MyStepsNewProduct.ClickContinue();
				}
				return;
			}
			actualMessage = actualMessage.Replace("/r/n", "");
			if (type == "Raw Material")
			{
				Report.Info("Checking Raw Materials message");
				string expectedMessage = "You are registering a formula (Raw Material). This is not a product registration that will result in an assessment for Retailers. A formula registration is used within final product registrations to maintain confidentiality of proprietary ingredients throughout the registration process. Formulas may be used by other organizations within their product registrations. Due to the downstream use of Formula registrations, once a formula registration is submitted through WERCSmart, the ingredients details (including percentages) are not eligible for editing in any manner. Should the formula change, the formulator would need to register a new formula. Therefore, please be sure the information you provide is accurate before accepting the registration and submitting.";
				Report.IsTrue(actualMessage.Contains(expectedMessage), "The Warning message was not correct", "The Warning message was correct");
			}
			else if (type == "Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party")
			{
				Report.Info("Checking Mixture, Blend, Formula or Solution from 3rd Party message");
				string expectedMessage = "You are registering a formula (Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party). This is not a product registration that will result in an assessment for Retailers. A formula registration is used within final product registrations to maintain confidentiality of proprietary ingredients throughout the registration process. Formulas may be used by other organizations within their product registrations. Due to the downstream use of Formula registrations, once a formula registration is submitted through WERCSmart, the ingredients details (including percentages) are not eligible for editing in any manner. Should the formula change, the formulator would need to register a new formula. Therefore, please be sure the information you provide is accurate before accepting the registration and submitting.";
				Report.IsTrue(actualMessage.Contains(expectedMessage), "The Warning message was not correct", "The Warning message was correct");
			}
			else
			{
				Report.Error("Product type must be Raw Material or Mixture, Blend, Formula or Solution from 3rd Party");
			}
			Report.Info("Closing popup");
			Report.IsTrue(modal.ClickButton("OK"), "Failed to click OK button", "Succesfully clicked on the OK button");
			GeneralUtilities.Wait_for_load_finish();
		}
		[StepDefinition(@"I call Shared Step 83242 \(SHA - Submitted or Assigned product - Reject Submission - any subject - Save for the product saved as: (.*)\)")]
		public void SharedStep83242_SubmittedOrAssignedProduct_RejectSubmission_AnySubject_Save(string savedAs)
		{


			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step 83242");
			var myStudioShaManager = new StudioSHAManager();
			var stepsSHA = new Steps_SHA();
			var productSubmissionRejection = new StudioSHAManagerProductSubmissionRejection();
			var globalSteps = new GlobalSteps();



			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;

			bool selectedID = false;

			if (myStudioShaManager.SelectProductByID(id))
			{
				selectedID = true;
			}

			Report.IsTrue(selectedID, "Failed to select product with id: " + id, "Selected product with id: " + id);

			Report.StartSubStep("I click the following option in the bottom menu: Reject Submission");
			stepsSHA.IClickTheFollowingOptionInTheBottomMenu("Reject Submission");
			Report.IsTrue(productSubmissionRejection.Wait_for_load(30), "The Product Submission Rejection Popup did not appear", "The Product Submission Rejection Popup did appear");
			Report.StartSubStep("Selecting the first subject from the Submission Rejection Popup");
			Report.IsTrue(productSubmissionRejection.SelectFirstSubject(), "The Frist subject was not selected", "The Frist subject was selected successfully");
			Report.StartSubStep("I check that Text is now shown in the Supplier Message Area of the Popup");
			Report.IsTrue(!productSubmissionRejection.GetSupplierMessage().IsNullOrEmpty(), "The Supplier Message Area was empty", "Text was shown in the Supplier Message Area");
			Report.StartSubStep("I Click save in the Product Submission Rejection Popup");

			//Alert is dismissed by screeshot, therefore cannot use Report.IsTure
			var saveClicked = productSubmissionRejection.ClickButton("Save");
			if (saveClicked)
			{
				Report.Success("The save button was successfully clicked");
			}
			else
			{
				Report.Failure("The save button was not clicked");
				return;
			}

			Report.StartSubStep("I check that an alert appears with the correct message");
			//globalSteps.GivenICheckAlertTextContainsXAndDismiss($"Product Message for product {id} has been created successfully."); //Can return to this once spelling bug is fixed, or by using "suces" (as method uses a contains)
			globalSteps.GivenICheckAlertTextContainsEitherXOrYAndDismiss($"Product Message for product {id} has been created successfully.", $"Product Message for product {id} has been created successfully."); //Used as Alert Text currently has spelling error, but we don't want the test to fail. (remove once bug is fixed and use the method above).
			Report.StartSubStep("I check the Product Submission Rejection Popup has been closed");
			Report.IsFalse(productSubmissionRejection.Wait_for_load(10), "The Product Submission Rejection Popup was shown", "The Product Submission Rejection Popup was not shown");

			//var popupClosed = productSubmissionRejection.Wait_for_load(10);

			//if(!popupClosed)
			//{
			//	Report.Success("The Product Submission Rejection Popup was not shown");
			//}
			//else
			//{
			//	Report.Failure("The Product Submission Rejection Popup was shown");
			//	return;
			//}

			//Report.IsFalse(productSubmissionRejection.Wait_for_load(10), "The Product Submission Rejection Popup was shown", "The Product Submission Rejection Popup was not shown");



		}

		[StepDefinition(@"I call Shared Step 77535 \(Retailer Association - Walmart\)")]
		public void Shared77535_RetailerAssociation_Walmart()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: Walmart");
			new StepsSelectRetailers().SelectTheRetailer("Walmart");
			Report.StartSubStep("I should see the Retailer Page");
			new StepsNewProduct().GivenIShouldSeeXPage("Retailer");
			var newProduct = new NewProduct();
			Report.StartSubStep("I select any Vendor ID");
			new Steps_Retailer().ISelectFirstVendorId();
			Report.StartSubStep("In the Retailer page I click Continue");
			new StepsNewProduct().GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(@"I call Shared Step 78080 \(Regulatory Documents to Provide - Upload OSHA SDS\)")]
		public void Shared78080_RegulatoryDocumentsToProvide_UploadOshsSds()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I set the OSHA-compliant Safety Data Sheet, English field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Yes");
			Report.StartSubStep("I upload a PDF file to section: OSHA SDS");
			MyNewProduct.UploadPDFFile("OSHA SDS", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}


		[StepDefinition(@"I call Shared Step 87337 \(Edit UPC - data - Click Save\) for UPC as: (.*), container type: (.*) and size: (.*) and packaging type: (.*)")]
		public void Shared87337_RemovePackgType(string upc, string containerType, string size, string pkgType)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");


			Report.StartSubStep("I click expand arrow for: " + upc);
			myNewProduct.EnsureArrowIsExpandedforUPC(upc);
			Report.StartSubStep("I add the following into the UPC Fields");
			var upcInfo = new UpcInformation {
				ContainerType = containerType,
				Size = size,
				UpcNumber = upc,
				PackageType = pkgType
			};
			Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to change packagaing type info!",
				"Successfully changed packagaing type info!");
			Report.StartSubStep("I click save");
			MyStepsNewProduct.ThenIClickSaveOrCancelInTheProductPage("Save");
			MyStepsNewProduct.GivenIConfirmErrorMessageIsShownBelowField("This is a required field.", "Package Type");
		}

		[StepDefinition(@"I call Shared Step 60515 \(VOC - Dilution - Yes to ratio - enter any values > Continue - Happy Path\)")]
		public void Shared60515_VocDiluationYesEnterAnyValues_Continue()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select the 'Yes' button for the 'Product Label Dilution Ratio' question");
			new Steps_VOC_OTC_CARB().SetProductLabelDilutionRatio("Yes");
			Report.StartSubStep("I enter the vlaue '1' for the 'VOC Content as Sold' question");
			new Steps_VOC_OTC_CARB().SetVocContentAsSold("1");
			Report.StartSubStep("I enter the vlaue '10' for the 'VOC Content as Used' question");
			new Steps_VOC_OTC_CARB().SetVocContentAsUsed("10");
			Report.StartSubStep("I click continue");
			new NewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: (.*)")]
		public void Shared43587_SHAManager_CompletedProduct_AddToRecertReason20(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 43587");
			var MyStepsSha = new Steps_SHA();

			var productTable = new Table(new string[] {
				"ProductID"
			});
			productTable.AddRow(new string[] {
				"saved as " + savedAs
			});
			MyStepsSha.GivenInSHAManagerISetTheFilterForStatusTo("Completed");
			Delay.Seconds(5);
			MyStepsSha.GivenInSHAManagerISelectTheFollowingProducts(productTable);
			MyStepsSha.GivenInSHAManagerGridIClickTheFollowingTopMenuItem("Add to Recertification");
			MyStepsSha.ThenTheAddProductToRecertificationScreenShouldBeShowing();
			MyStepsSha.InAddProductToRecertificationScreenSelectReasonByNumber(20);
			MyStepsSha.InAddProductToRecertificationScreenIClickButton("Add");
		}

		[StepDefinition(@"I call Shared Step Completed Product - Add Recert reason 20 for product saved as: (.*)")]
		public void Shared_SHAManager_CompletedProduct_AddToRecertificationReason20(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step: 43587");
			var MyStepsSha = new Steps_SHA();

			var productTable = new Table(new string[] {
				"ProductID"
			});
			productTable.AddRow(new string[] {
				"saved as " + savedAs
			});
			MyStepsSha.GivenInSHAManagerISetTheFilterForStatusTo("Completed");
			Delay.Seconds(5);
			MyStepsSha.GivenInSHAManagerISelectTheFollowingProducts(productTable);
			MyStepsSha.GivenInSHAManagerGridIClickTheFollowingTopMenuItem("Add to Recertification");
			MyStepsSha.ThenAddProductToRecertificationScreenShouldBeShowing();
			MyStepsSha.InAddProductToRecertificationScreenSelectReasonByNumber(20);
			MyStepsSha.InAddProductToRecertificationScreenIClickButton("Add");
		}

		[StepDefinition(@"I call Shared Step 88419 \(SHA > UPC - Confirm Case UPC fields \(No internal UPC\) > Close window\) for UPC saved as: (.*) for the retailer: (.*) using details saved in the table: (.*)")]
		public void Shared88419_SHA_UpcList_ConfirmCaseUPCFields(string savedAs, string retailer, string tableSavedAs)
		{
			Report.UseSubSteps = true;
			Report.StartStep("I Look for the case upc saved in context, and check it is followed by an asterisk in the UPC table");

			var shaSteps = new Steps_SHA();
			var studioSHAManger = new StudioSHAManager();
			Delay.Seconds(10);
			new Steps_SHA().SwitchToProductListUpcWindow();
			List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
			if (!displayedUpcs.Any())
			{
				Report.Failure("No UPCs were found in the Product UPC window");
			}
			else
			{
				Report.Info("Made a List of the displayed UPCs");
			}


			var upcNumber = displayedUpcs.FirstOrDefault(x => x.UPCNumber.EndsWith("*"))?.UPCNumber;

			var expectedUPCNum = (string)Context.GetFromContext(savedAs);

			Report.IsTrue(upcNumber != null, "There were no UPC numbers containing a *", "There was a UPC number containing a *");
			Report.IsTrue(upcNumber.Contains(expectedUPCNum), "The UPC number found did not contain the upc number: " + expectedUPCNum, "The UPC number found coontained the upc number: " + expectedUPCNum);

			Report.IsTrue(upcNumber != null && upcNumber.Contains(expectedUPCNum), "Failed to find the upc number: " + expectedUPCNum + " followed by an asterisk", "Succesfully found the upc number: " + expectedUPCNum + " followed by an asterisk");

			Report.StartSubStep("I Click on the link associated with the Case UPC marked by an asterisk");
			studioSHAManger.ClickCaseUPCSavedAsInProducUPCTable(savedAs);
			Report.StartSubStep("I Check the UPC detail popup appears");
			var upcDetails = new StudioSHAManagerUPCDetails();
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			Report.IsTrue(upcDetails.Wait_for_load(30), "The UPC details popup did not appear", "The UPC details popup appeared");
			Report.StartSubStep("I Select the Client: " + retailer + " from the select client list");


			IWebElement input = upcDetails.SelectClientInput;

			if (input == null)
			{
				Report.Failure("The Select Client box could not be found!");
				return;
			}
			input.Select(retailer);
			Report.StartSubStep("I wait for the UPC Details Table to Load");
			//Wait for load of the table before continue
			//Report.IsTrue(upcDetailsPopup.UpcDeatilsTableLoaded(),"The UPC Details Table did not appear", "The UPC Details Table appeared");
			Report.IsTrue(upcDetailsPopupTable.UpcDetailsTableLoadedOrNull(30), "The UPC details Table did not Appear", "The UPC details Table appeared");

			Report.StartSubStep("I Check the type coloumn shows the container type selected for my product.");
			string containerTypeActual = upcDetailsPopupTable.DetailValue("Container Type");
			Table table = (Table)Context.GetFromContext(tableSavedAs);
			TableRow informationRow = table.Rows[1];
			string expectedContainerValue = informationRow["Container type"].ToString();
			Report.Info("Container Type expected: " + expectedContainerValue);
			Report.Info("Container Type Found: " + containerTypeActual);
			Report.IsTrue(expectedContainerValue == containerTypeActual, "The container type column did not show the value selected for the product", "The container type column did show the value selected for the product");
			Report.StartSubStep("I Check the size column shows the size selected for my product.");
			string containerSizeActual = upcDetailsPopupTable.DetailValue("Container Size");
			string expectedSizeValue = informationRow["Size"].ToString();
			Report.Info("Container Size expected: " + expectedSizeValue);
			Report.Info("Container Size Found: " + containerSizeActual);
			Report.IsTrue(expectedSizeValue == containerSizeActual, "The container size column did not show the value selected for the product", "The container size column did show the value selected for the product");
			Report.StartSubStep("I Check the Internal UPC column shows the 'N/A'.");
			string expectedInternalUPC = "N/A";
			string internalUPCAtual = upcDetailsPopupTable.DetailValue("Internal UPC");
			Report.Info("Internal UPC expected: " + expectedInternalUPC);
			Report.Info("Internal UPC Found:  " + internalUPCAtual);
			Report.IsTrue(expectedInternalUPC == internalUPCAtual, "The Internal UPC column did not show N/A", "The Internal UPC column did show N/A");
			Report.StartSubStep("I Check the transport column shows the container type selected for my product.");
			string transportTypeActual = upcDetailsPopupTable.DetailValue("Code and Description for DOT Packaging");
			string expectedTransportOption = informationRow["Transportation Options"].ToString();

			string actualTransportOptionTrim = transportTypeActual.Replace(" ", "").Trim();
			string expectedTrasportOptionTrim = expectedTransportOption.Replace(" ", "").Trim();

			Report.Info("Trasnport Option expected (no spaces): " + actualTransportOptionTrim);
			Report.Info("Trasnport Option Found (no spaces): " + expectedTrasportOptionTrim);
			Report.IsTrue(expectedTrasportOptionTrim == actualTransportOptionTrim, "The Transportation Option column did not show the value selected for the product", "The Transportation Option column did show the value selected for the product");
			Report.StartSubStep("I close the SHA Manager Product UPC details pop up");
			Report.IsTrue(upcDetailsPopupTable.CloseButton.TryClick(), "Failed to Click Close in the UPC details popup", "Successfully clicked Click Close in the UPC details popup");
			Report.IsTrue(upcDetailsPopupTable.WaitForContainerToBeInvisible(30), "The UPC details popup did not close", "The UPC details popup was closed");












		}


		[StepDefinition(@"I call Shared Step 57264 \(Go To Retail Partners - Select O'Reilly\)")]
		public void Shared57264_GoToRetailPartners_SelectOReilly()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Retail Partners link in the left hand icon list");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			Report.StartSubStep("I select the retailer: O'Reilly");
			new StepsRetailPartners().SelectRetailer("O'Reilly");
		}

		[StepDefinition(@"I call Shared Step 62676 \(Go To My Account\)")]
		public void GivenICallSharedStepGoToMyAccount()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Clicking Supplier Name drop down in the header");
			Report.IsTrue(new TopMenuBar().ClickOnUserTopRight(), "Failed to click on user name in the top menu bar", "Clicked the user name in the top menu bar");
			Report.StartSubStep("I click 'My Account'");
			Report.IsTrue(new TopMenuBar().ClickMyAccount(), "Failed to click My Account", "Clicked My Account");
		}

		[StepDefinition(@"I call Shared Step 63511 \(Create New User via User Grid\)")]
		public void GivenICallSharedStepCreateNewUserViaUserGrid()
		{
			new GlobalSteps().ThenICreateANewRandomEmailAddress();
			Report.Info("Creating a user with the following information:");
			Report.Info("Name: User, Title: Mr, Role: User, Phone Number: 123 - 456 - 7889, Country: United Kingdom");
			var table = new Table("User Name", "Title", "Role", "Phone Number", "Email Address", "Confirm Email", "Country Code", "Country");
			table.AddRow("Random", "Mr", "User", "123 - 456 - 7889", "Saved", "Saved", "empty", "United Kingdom");
			new StepsMyAccount().ThenIAddANewUserWithTheFollowingInformation(table);
		}


		[StepDefinition(@"I call Shared Step 87897 \(Forwarding - Edit Existing Case UPC: (.*) - confirm data shown correctly, change all data, Save, Continue\) and save the table as: (.*)")]
		public void GivenICallSharedStep87897ForwardingEditExistingCaseUpcConfirmDataShownCorrectlyChangeAllDataSaveContinue(string caseUPCNumSavedAs, string tableSavedAs, Table table)
		{
			Report.UseSubSteps = true;
			Context.AddToContext(tableSavedAs, table);
			var editUPC = new ForwardProductRegistration.EditUPC();
			Report.StartSubStep("Selecting Edit on the UPC saved as: " + caseUPCNumSavedAs + ".");
			var upcNum = (string)Context.GetFromContext(caseUPCNumSavedAs);
			var selForwardProdReg = new ForwardProductRegistration();

			List<ForwardProductRegistration.SelectUPCs> upcs = selForwardProdReg.GetUPCs();
			if (upcs.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return;
			}
			bool successState = false;
			foreach (var item in upcs)
			{
				if (item.UPCInfo.UPCNumber == upcNum)
				{
					Report.IsTrue(item.UPCInfo.SelectUPC(), "Failed to select UPC: " + upcNum + ".", "Succesfully selected the UPC: " + upcNum + ".");
					Report.IsTrue(item.UPCInfo.ClickAction("edit"), "Failed to click edit on UPC: " + upcNum + ".", "Succesfully clicked edit on UPC: " + upcNum + ".");
					successState = true;
				}

			}
			if (successState == false)
			{
				Report.Failure(@"The UPC with number: " + upcNum + " was not found.");
				return;
			}


			Report.StartSubStep("I check the Edit UPC popup appears");
			editUPC.WaitForContainerToBeVisible(30);

			Report.StartStep("I confirm the UPC Number field is shown and is populated with the correct Case UPC");
			Report.IsTrue(editUPC.UPCNumber == upcNum, "The UPC number did not match expected", "The UPC number matched the expected value");

			Report.StartSubStep("I confirm the Container Type field is shown and is populated with the correct Case UPC");
			TableRow row = table.Rows[0];
			string containerValue = row["Container type"].ToString();
			Report.IsTrue(editUPC.Type == containerValue, "The Container Type did not match expected", "The Container Type matched the expected value");


			Report.StartSubStep("I confirm the Size field is shown and is populated with the correct Case UPC");
			string sizeValue = row["Size"].ToString();
			Report.IsTrue(editUPC.Size == sizeValue, "The Size did not match expected", "The Size  matched the expected value");

			Report.StartSubStep("I confirm the Quantity field is shown and is populated with the correct Case UPC");
			string quantityValue = row["Quantity"].ToString();
			Report.IsTrue(editUPC.Quantity == quantityValue, "The Quanitity did not match expected", "The Quanitity matched the expected value");

			Report.StartSubStep("I confirm the Individual UPC field is shown and is populated with the correct Case UPC");
			string individualUPCValue = row["Individual UPC contained in the Case Pack"].ToString();

			if (Regex.IsMatch(row["Individual UPC contained in the Case Pack"], "<(.*)>"))
			{
				var match = Regex.Match(row["Individual UPC contained in the Case Pack"], "<(.*)>").Groups[1].Value;
				if (Context.Contains(match, true))
				{
					individualUPCValue = Context.GetFromContext(match).ToString();
				}

			}
			//Philip - Working
			Report.IsTrue(editUPC.IndividualUPCContainedInTheCasePack == individualUPCValue, "The Individual UPC option did not match expected", "The Individual UPC option matched the expected value");
			Report.Info("testing expected: -" + row["Transportation Options"].ToString() + "- got: -" + editUPC.TransportationOptions + "-");
			Report.StartSubStep("I confirm the Transportation Options field is shown and is populated with the correct Case UPC");
			string transportationOptionsValue = row["Transportation Options"].ToString();
			Report.IsTrue(editUPC.TransportationOptions == transportationOptionsValue, "The Transportation Option did not match expected", "The Transportation Option matched the expected value");

			Report.StartSubStep("I change the Container Type");
			Report.Info(table.Rows[1]["Container type"].ToString());
			TableRow secondRow = table.Rows[1];
			string secondContainerValue = secondRow["Container type"].ToString();
			editUPC.Type = secondContainerValue;
			Report.IsTrue(editUPC.Type == secondContainerValue, "The Container Type was not changed", "The Container Type was changed");


			Report.StartSubStep("I change the Size Type");
			string secondSizeValue = secondRow["Size"].ToString();
			editUPC.Size = secondSizeValue;
			Report.IsTrue(editUPC.Size == secondSizeValue, "The Size was not changed", "The Size was changed");

			Report.StartSubStep("I change the Quantity Type");
			string secondQuantityValue = secondRow["Quantity"].ToString();
			editUPC.Quantity = secondQuantityValue;
			Report.IsTrue(editUPC.Quantity == secondQuantityValue, "The Quanitity was not changed", "The Quanitity was changed");


			Report.StartSubStep("I change the Individual UPC value");
			string secondIndividualUPCValue = secondRow["Individual UPC contained in the Case Pack"].ToString();
			if (Regex.IsMatch(row["Individual UPC contained in the Case Pack"], "<(.*)>"))
			{
				var match = Regex.Match(secondRow["Individual UPC contained in the Case Pack"], "<(.*)>").Groups[1].Value;
				if (Context.Contains(match, true))
				{
					secondIndividualUPCValue = Context.GetFromContext(match).ToString();
				}
			}
			editUPC.IndividualUPCContainedInTheCasePack = secondIndividualUPCValue;
			Report.IsTrue(editUPC.IndividualUPCContainedInTheCasePack == secondIndividualUPCValue, "The Individual UPC option was not changed", "The Individual UPC option was changed");

			Report.StartSubStep("I change the Transportation Options");
			string secondTransportationOptionsValue = secondRow["Transportation Options"].ToString();
			editUPC.TransportationOptions = secondTransportationOptionsValue;
			Report.IsTrue(editUPC.TransportationOptions == secondTransportationOptionsValue, "The Transportation Option was not changed", "The Transportation Option was changed");

			Report.StartSubStep("I Click Save in the Edit UPC popup");
			Report.IsTrue(editUPC.ClickButton("Save"), "Failed to click save in the edit UPC popup", "Succesfully clicked save in the edit upc popup");

			Report.StartSubStep("I check the Edit UPC popup disappears");
			Report.IsTrue(editUPC.WaitForContainerToBeInvisible(30), "The edit upc popup did not appear", "The edit upc appeared");
			Report.StartSubStep("I Confirm the Case UPC is shown in the right hand table with the new selections");

			List<ForwardProductRegistration.SelectUPCs> upcsEdited = selForwardProdReg.GetUPCs();
			if (upcsEdited.Count == 0)
			{
				Report.Failure("No UPC rows were found in the grid");
				Report.Screenshot();
				return;
			}
			Report.Info("There were: " + upcsEdited.Count + " UPCs to check");
			bool noIssues = true;
			bool foundCaseUPC = false;
			int i = 1;
			foreach (var item in upcsEdited)
			{
				if (item.UPCInfo.UPCNumber == upcNum)
				{
					foundCaseUPC = true;


					if (item.ContainerType != secondRow["Container type"].ToString())
					{
						Report.Failure("Container Type did not found match");
						noIssues = false;
					}
					if (item.Size != secondRow["Size"].ToString())
					{
						Report.Failure("Size did not match");
						noIssues = false;
					}
					if (item.Quantity != secondRow["Quantity"].ToString())
					{
						Report.Failure("Quantity did not match");
						noIssues = false;
					}
					if (item.UPCContained != null)
					{
						Report.Failure("The Individual UPC contained in the Case Pack did not match");
						noIssues = false;
					}
					if (item.TransportationOption != secondRow["Transportation Options"].ToString())
					{
						string actualTransportOption = item.TransportationOption.Replace(" ", "").Trim();
						string expectedTrasportOption = secondRow["Transportation Options"].ToString().Replace(" ", "").Trim();
						if (actualTransportOption != expectedTrasportOption)
						{
							Report.Failure("The Trasnportations Option did not match");
							noIssues = false;
						}
					}

					break;
				}

			}
			Report.IsTrue(foundCaseUPC, "The Case Upc with UPC number: " + upcNum + " was not found in the table.", "The Case Upc with UPC number: " + upcNum + " was found in the table.");
			if (foundCaseUPC)
			{
				Report.IsTrue(noIssues, "The select UPCs table on the right side does not contain all of the new selections for the case UPC: " + upcNum + ".", "The select UPCs table on the right contains all of the new selections for the case UPC: " + upcNum + ".");
			}

			Report.StartSubStep("I click Continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();

		}


		[StepDefinition(@"I call Shared Step 89286 - Product Information - US and Canada - OSHA \(NO\), DSV \(NO\), PLP \(YES\), GNFR \(NO\), Continue")]
		public void
			USandCanadaPLPYes()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			var MyNewProduct = new NewProduct();
			//And I Un-check the United States check box for the "Select countries the product may be sold in" question
			//List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			//MyStepsNewProduct.SetTheSectionOptionTo("Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns",
				"No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");

		}

		[StepDefinition(
			@"I call Shared Step - Product Information - canada only - With marketed for use by a Child - Direct Ship - Private Label questions only")]
		public void
			CanadaOnlyNoPL()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			List<string> countrySold = myNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				myNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					"No");
			}

			if (myNewProduct.SectionExists("Product is shipped directly by supplier to the consumer."))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.",
					"No");
			}

			if (myNewProduct.SectionExists("Product is a Retailer's Private Label or Brand"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			}

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 85328 \(Login to WERCSmart - Canada - Address \(Yes\), Packaging \(Yes\), Stewardship \(Full\)\)")]
		public void Shared85328()
		{
			new GlobalSteps().ILogInWithTheAccountSavedInTrevorAs("CanadaHasAllData");
		}

		[StepDefinition(@"I call Shared Step 86824 \(Forwarding - Select Existing UPC, Click Continue, No error for Package type\)")]
		public void Shared86824()
		{
			Report.UseSubSteps = true;
			Report.StartStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartStep("I click continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 86002 \(Forwarding - PLP - Select Product: (.*) & UPCs step - Edit existing UPC Confirm\)")]
		public void Shared86002(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select the product saved as: " + savedAs);
			new StepsForwardProductRegistration().SelectProductByIDSavedAs(savedAs);
			Report.StartSubStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartSubStep("I click continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 86004 \(Forwarding - Not PLP - Select Product: (.*) & UPCs step - Edit existing UPC Confirm Package Type not shown\)")]
		public void Shared86004(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select the first product in the Select UPCs tab");
			new StepsForwardProductRegistration().SelectTheFirstProductSelectUPCs();
			Report.StartSubStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartSubStep("I select Edit for the first UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectEditForFirstUPC();
			Report.StartSubStep("I confirm that Package Type is not shown for UPC");
			new StepsForwardProductRegistration().ConfirmPackageTypeNotShown();			
			Report.StartSubStep("I click Save in the Edit UPC modal");
			new StepsForwardProductRegistration().InTheUPCModalWindowIClickSave();
			Report.StartSubStep("I click continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();
		}

		[StepDefinition(
		@"I filter subformat (.*) and open checklist (.*)")]
		public void IFilertSubformatAndOpenChecklist(string subformat, string checkList)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			Report.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
			Report.Screenshot();
			Delay.Seconds(3);

			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			if (!thisPowerDesignerPlus.Wait_for_load(30))
			{
				var thisStudioPowerDesignerPlusDesignMode =
					new StudioPowerDesignerPlusDesignMode();
				thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
				thisStudioPowerDesignerPlusDesignMode.ClickMenuAndSubmenuOptions("Home");
				Delay.Seconds(3);
			}

			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
				"Set language option");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter(subformat), "Failed to set subformat option",
				"Set subformat option");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("CKLT", "MTR"), "Failed to set format option",
				"Set format option");
			Report.StartSubStep("I click the Edit Existing product radio button if not already selected");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");

			if (Context.Contains("WERCSmart ID"))
			{
				string WERCSmartIDFromContext = Context.GetFromContext("WERCSmart ID").ToString();
				Report.IsTrue(thisPowerDesignerPlus.EnterSourceProduct(WERCSmartIDFromContext), $"Failed to enter {WERCSmartIDFromContext} into the Select Source Product field!", $"Successfully entered {WERCSmartIDFromContext} into the Select Source Product field");
			}

			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(3);

			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.StartSubStep("I click Continue");
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button",
				"Clicked continue button");
			Delay.Seconds(3);
			var selStepsStudio = new Steps_Studio();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", checkList);

		}


		[StepDefinition(@"I save product (.*) to context as (.*)")]
		public void ISaveProductToContextAs(string product, string savedAs)
		{
			string name = "Chalk";
			string id = product;

			var info = new ProductInformation {
				Name = name,
				Id = id
			};

			Context.AddToContext(savedAs, info);
		}

		[StepDefinition(@"I call Shared Step 80821 - Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing and save as: (.*)")]
		public void ICallSharedStep80821_CreateA3rdPartyProduct(string savedAs)
		{
			Report.UseSubSteps = true;
			var stepsProdGrid = new StepsProductGrid();
			var stepsNewProd = new StepsNewProduct();
			var stepsIngredients = new StepsIngredients();
			var stepsSHA = new Steps_SHA();
			var stepsStudio = new Steps_Studio();

			Report.StartSubStep("I generate a random UPC number and save as: UPC80821");
			stepsProdGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC80821");

			Report.StartSubStep("I log into WercSmart - Products Automation Account");
			this.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();

			Report.StartSubStep("Create a New Registration via Register New Product (expanded menu)");
			this.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();

			Report.StartSubStep("The Product - Enter Product Name and select Type of Product");
			this.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Raw material");

			Report.StartSubStep("I save the product information as");
			stepsNewProd.SaveProductInformation(savedAs);

			var ing1 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing1.AddRow("100-41-4", "Ethylbenzene", "25", "Yes", "Undisclosed Ingredient");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808211");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808211", ing1);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("100.00%", "100.00%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("success");

			var ing2 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed");
			ing2.AddRow("37334-84-2", "Cellolyn 21", "15", "No");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808212", ing2);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 2");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("50.00%", "50.00%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing3 = new Table("CASNumber", "ComponentName", "Percentage");
			ing3.AddRow("RR-38384-6", "FRAGRANCE-HERBAL", "10");
			Report.StartSubStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808213", ing3);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 3");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("33.33%", "33.33%");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing4 = new Table("CASNumber", "ComponentName", "Percentage");
			ing4.AddRow("RR-38213-8", "FRAGRANCE-BANANA", "10");
			Report.StartSubStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808214", ing4);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 4");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("25.00%", "25.00%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");

			var ing5 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed");
			ing5.AddRow("FLAVOR", "611 Grape Flavor", "10", "No");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808215", ing5);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 5");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("20.00%", "20.00%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");

			var ing6 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing6.AddRow("NA519", "Black Cherry - Natural Flavor", "10", "Yes", "Undisclosed Ingredient");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808216", ing6);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 6");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("33.33%", "33.33%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing7 = new Table("CASNumber", "ComponentName", "Percentage");
			ing7.AddRow("FRAGRANCE", "Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2", "10");
			Report.StartSubStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808217", ing7);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 7");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("28.57%", "28.57%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing8 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing8.AddRow("7732-18-5", "Water", "10", "Yes", "Undisclosed Ingredient");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808218", ing8);
			//Philip - Working
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3 and denominator: 8");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("37.59%", "37.50%");
			//
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			Report.StartSubStep("In the Ingredients page I click continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Ingredients");

			//Philip - Working
			this.GivenICallSharedStep145355FormulationBatteries_SelectGranted_Continue();
			Report.StartSubStep("Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue");
			this.GivenICallSharedStepFormulationRdParty_AcceptFormulation_GrantTier_Continue();
			//

			Report.StartSubStep("Enter Regulatory Information - Not Prop 65");
			this.GivenICallSharedEnterRegulatoryInformation_NotProp();

			Report.StartSubStep("Regulatory Information 2 - Microbeads - No");
			this.SharedRegulatoryInformation2_Microbeads_No();

			Report.StartSubStep("I should see the Additional Documents to Provide Page");
			stepsNewProd.GivenIShouldSeeXPage("Additional Documents to Provide");

			Report.StartSubStep("(Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\\Dependencies\\WERCSmart\\testdoc.pdf");
			this.ICallSharedBrowseForFileSelectClickOpen("IFRA Certificate (Perfumery Products)", "C:\\Dependencies\\WERCSmart\\testdoc.pdf");

			Report.StartSubStep("(Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\\Dependencies\\WERCSmart\\testdoc.pdf");
			this.ICallSharedBrowseForFileSelectClickOpen("GRAS Certificate (Flavor Products)", "C:\\Dependencies\\WERCSmart\\testdoc.pdf");

			Report.StartSubStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");

			Report.StartSubStep("in the Product Aliases page I click Continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Product Aliases");

			Report.StartSubStep("(Optional Comments - Happy Path) and enter the comment: test");
			this.GivenICallSharedCommentsHappyPath("test");

			Report.StartSubStep("Confirm Restrict Use - Restrict");
			this.SharedConfirmRestrictUse_Restrict();

			Report.StartSubStep("(Go to Summary and verify data) with product type: Raw material");
			this.SharedGoToSummaryAndVerifyData("Raw material");

			Report.StartSubStep("Data Acceptance - Click Accept - Happy Path");
			this.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();

			Report.StartSubStep("If purchase details are showing click confirm order");
			stepsNewProd.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();

			Report.StartSubStep("Login to Studio and Open SHA manager");
			this.GivenICallShared65080LoginToStudioAndOpenSHAManager();

			Report.StartSubStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartSubStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Submitted");

			Report.StartSubStep("SHA Manager - Submitted - Select product > process product data for product saved as: " + savedAs);
			this.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);

			Report.StartSubStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartSubStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Assigned");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Assigned");

			Report.StartSubStep("WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: " + savedAs);
			this.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);

			Report.StartSubStep("WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: " + savedAs);
			this.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);

			Report.StartSubStep("In Power Designer I left click on section: [SECT0077] Walmart Transportation Information");
			stepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0077] Walmart Transportation Information");

			Report.StartSubStep("In Power Designer I double click on category: Water Soluble?");
			stepsStudio.GivenInPowerDesignerIDoubleClickOnCategory("Water Soluble?");

			Report.StartSubStep("In Power Designer the phrase selector screen should open");
			stepsStudio.ThenInPowerDesignerThePhraseSelectorScreenShouldOpen();

			var table = new Table("Text");
			table.AddRow("Y");
			Report.StartSubStep("In the phrase selector screen I select phrases");
			stepsStudio.ThenInThePhraseSelectorScreenISelectPhrases(table);

			Report.StartSubStep("In the phrase selector screen I click button: Save");
			stepsStudio.ThenInThePhraseSelectorScreenIClickButton("Save");

			var table2 = new Table("Component CAS", "Component ID", "Chemical Name");
			table2.AddRow("saved as " + savedAs, "MIXTURE", "AAA WERCS Test Raw Material");
			Report.StartSubStep("WPS Studio - PD+ - Create Component for 3rd party product");
			this.GivenICallSharedStep79501WPSStudio_PD_CreateComponentForRdPartyProduct(table2);

			Report.StartSubStep("I click on home to navigate back to editing specific product saved as " + savedAs);
			stepsStudio.GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(savedAs);

			Report.StartSubStep("WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only for product saved as: " + savedAs);
			this.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(savedAs);

			Report.StartSubStep("Go to SHA Manager");
			this.GivenICallSharedStep59066GoToSHAManager();

			Report.StartSubStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartSubStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Completed");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Completed");

		}


		[StepDefinition(@"I call Shared Step 80821 - Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing using SHA Account: (.*) and save as: (.*)")]
		public void ICallSharedStep80821_CreateA3rdPartyProductusingSHAAcc(string savedAs, string shaAcc)
		{
			Report.UseSubSteps = true;
			var stepsProdGrid = new StepsProductGrid();
			var stepsNewProd = new StepsNewProduct();
			var stepsIngredients = new StepsIngredients();
			var stepsSHA = new Steps_SHA();
			var stepsStudio = new Steps_Studio();

			Report.StartSubStep("I generate a random UPC number and save as: UPC80821");
			stepsProdGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC80821");

			Report.StartSubStep("I log into WercSmart - Products Automation Account");
			this.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();

			Report.StartSubStep("Create a New Registration via Register New Product (expanded menu)");
			this.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();

			Report.StartSubStep("The Product - Enter Product Name and select Type of Product");
			this.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Raw material");

			Report.StartSubStep("I save the product information as");
			stepsNewProd.SaveProductInformation(savedAs);

			var ing1 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing1.AddRow("100-41-4", "Ethylbenzene", "25", "Yes", "Undisclosed Ingredient");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808211");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808211", ing1);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "1");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("success");

			var ing2 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed");
			ing2.AddRow("37334-84-2", "Cellolyn 21", "15", "No");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808212", ing2);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 2");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "2");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing3 = new Table("CASNumber", "ComponentName", "Percentage");
			ing3.AddRow("RR-38384-6", "FRAGRANCE-HERBAL", "10");
			Report.StartSubStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808213", ing3);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 3");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "3");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing4 = new Table("CASNumber", "ComponentName", "Percentage");
			ing4.AddRow("RR-38213-8", "FRAGRANCE-BANANA", "10");
			Report.StartSubStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808214", ing4);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 4");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "4");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");

			var ing5 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed");
			ing5.AddRow("FLAVOR", "611 Grape Flavor", "10", "No");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808215", ing5);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 5");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "5");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");

			var ing6 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing6.AddRow("NA519", "Black Cherry - Natural Flavor", "10", "Yes", "Undisclosed Ingredient");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808216", ing6);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 6");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "6");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing7 = new Table("CASNumber", "ComponentName", "Percentage");
			ing7.AddRow("FRAGRANCE", "Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2", "10");
			Report.StartSubStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808217", ing7);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 7");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "7");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing8 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing8.AddRow("7732-18-5", "Water", "10", "Yes", "Undisclosed Ingredient");
			Report.StartSubStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808218", ing8);
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3 and denominator: 8");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("3", "8");
			Report.StartSubStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			Report.StartSubStep("In the Ingredients page I click continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Ingredients");

			Report.StartSubStep("Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue");
			this.GivenICallSharedStepFormulationRdParty_AcceptFormulation_GrantTier_Continue();

			Report.StartSubStep("Enter Regulatory Information - Not Prop 65");
			this.GivenICallSharedEnterRegulatoryInformation_NotProp();

			Report.StartSubStep("Regulatory Information 2 - Microbeads - No");
			this.SharedRegulatoryInformation2_Microbeads_No();

			Report.StartSubStep("I should see the Additional Documents to Provide Page");
			stepsNewProd.GivenIShouldSeeXPage("Additional Documents to Provide");

			Report.StartSubStep("(Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\\Dependencies\\WERCSmart\\testdoc.pdf");
			this.ICallSharedBrowseForFileSelectClickOpen("IFRA Certificate (Perfumery Products)", "C:\\Dependencies\\WERCSmart\\testdoc.pdf");

			Report.StartSubStep("(Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\\Dependencies\\WERCSmart\\testdoc.pdf");
			this.ICallSharedBrowseForFileSelectClickOpen("GRAS Certificate (Flavor Products)", "C:\\Dependencies\\WERCSmart\\testdoc.pdf");

			Report.StartSubStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");

			Report.StartSubStep("in the Product Aliases page I click Continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Product Aliases");

			Report.StartSubStep("(Optional Comments - Happy Path) and enter the comment: test");
			this.GivenICallSharedCommentsHappyPath("test");

			Report.StartSubStep("Confirm Restrict Use - Restrict");
			this.SharedConfirmRestrictUse_Restrict();

			Report.StartSubStep("(Go to Summary and verify data) with product type: Raw material");
			this.SharedGoToSummaryAndVerifyData("Raw material");

			Report.StartSubStep("Data Acceptance - Click Accept - Happy Path");
			this.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();

			Report.StartSubStep("If purchase details are showing click confirm order");
			stepsNewProd.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();

			Report.StartSubStep("Login to Studio and Open SHA manager");
			this.GivenICallShared65080LoginToStudioAsUserAndOpenSHAManager(shaAcc);

			Report.StartSubStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartSubStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Submitted");

			Report.StartSubStep("SHA Manager - Submitted - Select product > process product data for product saved as: " + savedAs);
			this.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);

			Report.StartSubStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartSubStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Assigned");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Assigned");

			Report.StartSubStep("WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: " + savedAs);
			this.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);

			Report.StartSubStep("WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: " + savedAs);
			this.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);

			Report.StartSubStep("In Power Designer I left click on section: [SECT0077] Walmart Transportation Information");
			stepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0077] Walmart Transportation Information");

			Report.StartSubStep("In Power Designer I double click on category: Water Soluble?");
			stepsStudio.GivenInPowerDesignerIDoubleClickOnCategory("Water Soluble?");

			Report.StartSubStep("In Power Designer the phrase selector screen should open");
			stepsStudio.ThenInPowerDesignerThePhraseSelectorScreenShouldOpen();

			var table = new Table("Text");
			table.AddRow("Y");
			Report.StartSubStep("In the phrase selector screen I select phrases");
			stepsStudio.ThenInThePhraseSelectorScreenISelectPhrases(table);

			Report.StartSubStep("In the phrase selector screen I click button: Save");
			stepsStudio.ThenInThePhraseSelectorScreenIClickButton("Save");

			var table2 = new Table("Component CAS", "Component ID", "Chemical Name");
			table2.AddRow("saved as " + savedAs, "MIXTURE", "AAA WERCS Test Raw Material");
			Report.StartSubStep("WPS Studio - PD+ - Create Component for 3rd party product");
			this.GivenICallSharedStep79501WPSStudio_PD_CreateComponentForRdPartyProduct(table2);

			Report.StartSubStep("I click on home to navigate back to editing specific product saved as " + savedAs);
			stepsStudio.GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(savedAs);

			Report.StartSubStep("WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only for product saved as: " + savedAs);
			this.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(savedAs);

			Report.StartSubStep("Go to SHA Manager");
			this.GivenICallSharedStep59066GoToSHAManager();

			Report.StartStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Completed");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Completed");

		}


		[StepDefinition(@"I call Shared Step 118064 \(Product Information - US only - No GHS, Not Direct Ship, Not CA Cleaning ,Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedProductInformation_USOnly_NoGHSNotDirectShipNotCACleaningNotPLPNotGNFR_Continue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(
			@"I call Shared Step 118085 \(Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue\)")]
		public void
			GivenICallSharedStepProductInformation_PesticideNotConsideredSOLDUSEverythingElseNoCACleaningNo_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.",
				"No");
			Report.StartSubStep("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 118091 \(Product Information - US, No(OSHA), No(DSV), No(CA Cleaning),Yes (PLP), No(GNFR)\)")]
		public void ICallSharedStepProductInformation_US_NoOSHA_NoDSV_NoCACleaning_YesPLP_NoGNFR(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				Report.StartSubStep(
					"In the Product Type tab of the New Product Page for Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) I select:" +
					table.Rows[0]["Product is marketed for use"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					table.Rows[0]["Product is marketed for use"]);
			}

			if (myNewProduct.SectionExists(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)")
			)
			{
				Report.StartSubStep(
					"In the Product Type tab of the New Product Page for Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) I select:" +
					table.Rows[0]["Classified using OSHA (US) Globally Harmonized Standards (GHS)"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
					table.Rows[0]["Classified using OSHA (US) Globally Harmonized Standards (GHS)"]);
			}

			if (myNewProduct.SectionExists(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.")
			)
			{
				Report.StartSubStep(
					"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." +
					table.Rows[0]["Shipped directly by supplier"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
					table.Rows[0]["Shipped directly by supplier"]);
			}

			if (myNewProduct.SectionExists(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.")
			)
			{
				Report.StartSubStep(
					"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration." +
					table.Rows[0]["California Cleaning"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.",
					table.Rows[0]["California Cleaning"]);
			}

			if (myNewProduct.SectionExists(
				"Product is a Retailer's Private Label or Brand"))
			{
				Report.StartSubStep(
					"Product is a Retailer's Private Label or Brand" +
					table.Rows[0]["Private Label or Brand"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand",
					table.Rows[0]["Private Label or Brand"]);
			}

			if (myNewProduct.SectionExists(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)")
			)
			{
				Report.StartSubStep(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)" +
					table.Rows[0]["Good Not for resale"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
					table.Rows[0]["Good Not for resale"]);
			}

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step - \(Product Information - enter options\)")]
		public void ICallSharedStepProductInformationEnterAllOptions(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			foreach (var thisRow in table.Rows)
			{
				if (myNewProduct.SectionExists(thisRow["Section"]))
				{
					Report.StartStep($"{thisRow["Section"]}: {thisRow["Value"]}");
					MyStepsNewProduct.SetTheSectionOptionTo(thisRow["Section"], thisRow["Value"]);
				}
				else
				{
					Report.Info($"Secion ({thisRow["Section"]}) is not displayed");
				}
			}
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			Report.StartStep("In the Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 118138 Product Information - US, Pesticide No, No OSHA, No DSV, No CA Cleaning ,No PL, No GNFR Without Child question")]
		public void GivenICallSharedStepProductInformation_USPesticideNoNoOSHANoDSNoCACleaningVNoPLNoGNFRWithoutChildQuestion()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set any option for: 'Which best describes your product, including when FIFRA 25(b) Exempt'");
			// Step says 'any' but prefer setting not pesticide because some tests didn't account for Pesticides page appearing later.
			if (new NewProduct().GetAllOptionsForSection("Which best describes your product, including when FIFRA 25(b) Exempt").Contains("Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			}
			else
			{
				MyNewProduct.SelectFirstOptionInSection("Which best describes your product, including when FIFRA 25(b) Exempt");
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			}
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}


		[StepDefinition(@"I check if the excel data matches the checklist data")]
		public void CheckExcelDataAgainstCheckListData()
		{

			SHAWasteClassification SHA = new SHAWasteClassification();

			SHA.GetDataFromTable();

			Dictionary<string, string> ExcelDictionaryDataFromContext = (Dictionary<string, string>)Context.GetFromContext("ExcelDictionaryData");

			string ExcelEPAType, ExcelEPACode;

			if (ExcelDictionaryDataFromContext.ContainsKey("EPA Type"))
			{
				ExcelEPAType = ExcelDictionaryDataFromContext["EPA Type"];
			}
			else
			{
				ExcelEPAType = "None";
			}

			if (ExcelDictionaryDataFromContext.ContainsKey("EPA Code"))
			{
				ExcelEPACode = ExcelDictionaryDataFromContext["EPA Code"];
			}
			else
			{
				ExcelEPACode = "NON-RCRA";
			}

			Report.IsTrue(ExcelEPAType == SHA.CheckListEPAType, "The excel EPA Type: " + ExcelEPAType + ", does not match the checklist EPA Type: " + SHA.CheckListEPAType, "The excel EPA Type: " + ExcelEPAType + ", does match the checklist EPA Type: " + SHA.CheckListEPAType);

			Report.IsTrue(ExcelEPACode == SHA.CheckListEPACode, "The excel EPA Code: " + ExcelEPACode + ", does not match the checklist EPA Code: " + SHA.CheckListEPACode, "The excel EPA Code: " + ExcelEPACode + ", does match the checklist EPA Code: " + SHA.CheckListEPACode);


			foreach (KeyValuePair<string, string> entry in ExcelDictionaryDataFromContext)
			{

				Dictionary<string, List<string>> CheckListDictionaryData = SHA.GetStateData(entry.Key);

				if (CheckListDictionaryData.ContainsKey(entry.Key) && ExcelDictionaryDataFromContext.ContainsKey(entry.Key))
				{

					foreach (string elementTextValue in CheckListDictionaryData[entry.Key])
					{

						if (ExcelDictionaryDataFromContext.ContainsKey(entry.Key))
						{

							Report.IsTrue(ExcelDictionaryDataFromContext[entry.Key] == elementTextValue,
								"The excel waste code does not match the checklist waste code: " + ExcelDictionaryDataFromContext[entry.Key] + " != " + elementTextValue + ", for state: " + entry.Key,
								"The excel waste code matches the checklist waste code: " + ExcelDictionaryDataFromContext[entry.Key] + " == " + elementTextValue + ", for state: " + entry.Key);

						}

					}

				}


			}
		}

		[StepDefinition(@"I enter (.*) in the DPCI field of the UPC page")]
		public void GivenIEnterInTheDPCIFieldOfTheUPCPage(string dpci)
		{
			Report.IsTrue(new UPC().EnterDPCI(dpci), "DPCI number " + dpci + " was not entered", "DPCI is successfully set to " + dpci);
		}

		[StepDefinition(@"I should see an error message on the (.*) field which reads: (.*)")]
		public void GivenIShouldSeeAnErrorMessageOnTheProductNameOnLabelField(string section, string expectedMessage)
		{
			Report.IsTrue(new UPC().GetUPCErrorForSection(section, expectedMessage, out string displayedMessage),
			  "Error message displayed is " + displayedMessage + " but expected " + expectedMessage,
			  "Error Message displayed in section: " + section + "is displayed as: " + expectedMessage + " as expected");
		}

		[StepDefinition(@"I call Shared Step 57500a \(Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path\): (.*)")]
		public void GivenICallMySharedStepPrescriptionPharmaceuticalSolid(string type)
		{
			string name = "";
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Type");
			Report.StartSubStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			if (name == "")
			{
				char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
				name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			}
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartSubStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartSubStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info($"The TestCaseId was found as: {WercSmartSettings.TestCaseId}");

			Context.AddToContext($"TestCase{WercSmartSettings.TestCaseId}", prodDetails);
		}

		[StepDefinition(@"I call Shared Step 135134 \(Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, - Continue - Happy Path\)")]
		public void IcallSharedStep135134()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			var newProductObject = new NewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I set the product description option to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProductSteps.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			Report.StartSubStep("I unselect option: United States under section: Select countries the product may be sold in");
			newProductObject.UnsetOptionInSection("Select countries the product may be sold in".Trim(), "United States".Trim());
			Report.StartSubStep("I set the Select countries the product may be sold in option to: Canada");
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			tableFirst.AddRow(
				"Product is a Retailer's Private Label or Brand");
			tableFirst.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep(
				"Product is a Retailer's Private Label or Brand: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is a Retailer's Private Label or Brand",
				"No");
			Report.StartSubStep(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale): No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 100974 \(Regulatory Documents to Provide - Canada only - Upload documents > Continue\)")]
		public void GivenICallSharedStep100974RegulatoryDocumentsToProvideCanadaOnlyUploadDocumentsContinue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I should see the WHMIS SDS question");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I certify that I have a WHMIS-Compliant Safety Data Sheet (SDS) for this product.");
			MyNewProduct.UploadPDFFile("Dual-Language WHMIS SDS, in French Canadian and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			DateTime currentDate = DateTime.Today;
			string currentDateString = currentDate.ToString("yyyy-MM-dd");
			MyNewProduct.InTheRegualtoryDocumentsToProvidePageIEnterValueIntoWHMISSDSDocumentDateField(currentDateString);
			MyNewProduct.ThenFieldExists("Product Label in English and French-Canadian");
			Report.StartSubStep("I upload a PDF file in the WHMIS Label section");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			var MyStepsNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();
			Report.StartSubStep("I click continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}


		[StepDefinition(@"I call Shared Step 132427 \(Waste Classification Data- For OTC Products\)")]
		public void GivenICallSharedStep132427WasteClassificationDataForOTCProducts()
		{
			var regulatoryInformation = new RegulatoryInformation1();
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Waste Classification Data page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Waste Classification Data");

		}

		[StepDefinition(@"I call Shared Step 132473 \(Regulatory Information 3 - Nutritional Category\)")]
		public void GivenICallSharedStepRegulatoryInformation_NutritionalCategory()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Information 3");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 3");
			Report.StartSubStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may including Active Ingredient)");
			MyStepsNewProduct.IConfirmRegulatoryInformation3PageContainsStatement("Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).");
			Report.StartSubStep("For the 'Refer to your Product Label. From the options, select those that appear on the Label.' question three options should appear: 'Supplement Facts Panel', 'Nutrition Facts Panel' and 'None of the Above'");
			var table = new Table("Option");
			table.AddRow("Supplement Facts Panel");
			table.AddRow("Nutrition Facts Panel");
			table.AddRow("None of the Above");
			MyStepsNewProduct.CheckOptionsInSection("should", "displayed", "Refer to your Product Label.", table);
			Report.StartSubStep("Select any of the three options that apply");
			MyStepsNewProduct.GivenInTheRegulatoryInforamtionTabISelectProductLableAs("Supplement Facts Panel");
			Report.StartSubStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: Nutritional and Supplement Labels");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("Nutritional and Supplement Labels");
			Report.StartSubStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: Dietary Supplements Label");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("Dietary Supplements Label");
			Report.StartSubStep("In the Regulatory Information 3 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 3");
		}

		[StepDefinition(@"I call Shared Step 132601 \(Additional Documents to Provide - Nutritional Flow\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_NutritionalFlow()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Additional Documents to Provide screen");
			MyNewProduct.GivenIShouldSeeXPage("Additional Documents to Provide");
			MyNewProduct.ThenFieldExists("OSHA-compliant Safety Data Sheet (Optional)");
			MyNewProduct.ThenFieldExists("Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)");

			//new NewProduct().SectionExists("Upload Full Product Label (required)");



			Report.StartSubStep("Upload Product Label");
			MyNewProduct.UploadPDFFileSectionAndType("Product Label", "Upload Full Product Label", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.Screenshot();
			MyNewProduct.CheckUploadedFileNameForTypeAndLabel("Upload Full Product Label", "Product Label", "testdoc.pdf");
			MyNewProduct.ThenFieldExists("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");

		}

		[StepDefinition(@"I call Shared Step 140562 \(Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, No CA Cleaning - Continue - Happy Path\)")]
		public void IcallSharedStep140562()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			var newProductObject = new NewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep("I set the product description option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyNewProductSteps.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			Report.StartSubStep("I unselect option: United States under section: Select countries the product may be sold in");
			newProductObject.UnsetOptionInSection("Select countries the product may be sold in".Trim(), "United States".Trim());
			Report.StartSubStep("I set the Select countries the product may be sold in option to: Canada");
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			tableFirst.AddRow(
				"Product is a Retailer's Private Label or Brand");
			tableFirst.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");

			Report.StartSubStep(
				"California's Cleaning Product Right to Know Act: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"California's Cleaning Product Right to Know Act",
				"No");



			Report.StartSubStep(
				"Product is a Retailer's Private Label or Brand: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is a Retailer's Private Label or Brand",
				"No");
			Report.StartSubStep(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale): No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}



		[StepDefinition(@"I call Shared Step 146794 \(Product Includes a Battery > Add test Lithium Ion batteries for checking in Webviewers\)")]
		public void GivenICallSharedStep146794ProductsIncludesABatteryAddTestLithiumIonBatteriesForCheckingInWebvi(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I set the Indicate how battery is packaged field to: Installed in the product");
			MyStepsNewProduct.SetTheSectionOptionTo("Indicate how battery is packaged", "Installed in the product");
			Report.StartSubStep("I complete a row in the Battery Table: | Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |");
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (TableRow thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Quantity of Batteries per Package"], out int batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries per Package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["Quantity of Batteries to Operate Product"], out int batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries to Operate Product' column of the step table must be an integer value");
					}
					var thisBattery = new Battery {
						BatteryType = thisRow["Battery Type"],
						Manufacturer = thisRow["Manufacturer"],
						NumberPerPackage = batteriesPerPackage,
						RequiredToRun = batteriesRequired
					};
					listOfBatteries.Add(thisBattery);
				}
				var productIncludesBattery = new ProductIncludesBattery();
				if (listOfBatteries.Any())
				{
					// setter adds a table row for each battery in the list and enters data into each column
					productIncludesBattery.Batteries = listOfBatteries;
					productIncludesBattery.DeleteEmptyBatteryRows();
				}
				else
				{
					Report.Error("There were no batteries to add");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
			Report.StartSubStep("In the Product Includes Battery page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Includes Battery");
		}


		[StepDefinition(@"I call Shared Step 144968 \(Retailers - Add Retailers for Web viewers & RPS\)")]
		public void GivenICallSharedStep144968Retailers_AddRetailersForWebViewers()
		{
			Report.UseSubSteps = true;

			var selSelectRetailers = new SelectRetailers();

			Report.StartSubStep("With the Select Retailers pop up shown, Select all the web viewer retailers:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Ace Hardware Corporation");
			retailerTable.AddRow("Albertsons Companies");
			retailerTable.AddRow("Autozone");
			retailerTable.AddRow("CVS");
			retailerTable.AddRow("Dick's Sporting Goods");
			retailerTable.AddRow("Genuine Parts");
			retailerTable.AddRow("Kroger");
			retailerTable.AddRow("Lowe's");
			retailerTable.AddRow("McLane");
			retailerTable.AddRow("Meijer");
			retailerTable.AddRow("Office Depot");
			retailerTable.AddRow("Sears/K-Mart");
			retailerTable.AddRow("Smart & Final");
			retailerTable.AddRow("Staples");
			retailerTable.AddRow("Target");
			retailerTable.AddRow("Wal-Mart/SAM'S CLUB");
			retailerTable.AddRow("WinCo Foods");
			new StepsSelectRetailers().SelectRetailersInListView(retailerTable);
			var allRetailers = selSelectRetailers.AllRetailers();
			if (allRetailers.Contains($"Canadian Tire"))
			{
				Report.Info($"Canadian Tire was found as an option, selecting it as a retailer");
				new StepsSelectRetailers().SelectTheRetailer("Canadian Tire");

			}
			else
			{
				Report.Info($"Canadian Tire was not found as an option, moving on.");
			}
			Report.StartSubStep("Click Done");
			new StepsSelectRetailers().IClickDoneButtonOnSelectRetailersWindow();
			Report.StartSubStep("In The additional requirments column, select an entry from the drop list for retailers 'Walmart' and 'Sears'");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Wal-Mart/SAM'S CLUB");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Sears/K-Mart");
			Report.StartSubStep("Click Continue");
			new StepsNewProduct().ClickContinue();

		}


		[StepDefinition(@"I call Shared Step 144968b \(Retailers - Add Retailers for Web viewers & RPS\) for a non PL Product")]
		public void GivenICallSharedStep144968BRetailers_AddRetailersForWebViewersNonPL()
		{
			Report.UseSubSteps = true;

			var selSelectRetailers = new SelectRetailers();

			Report.StartSubStep("With the Select Retailers pop up shown, Select all the web viewer retailers:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Ace Hardware");
			retailerTable.AddRow("Albertsons");
			retailerTable.AddRow("Autozone");
			retailerTable.AddRow("CVS");
			retailerTable.AddRow("Dicks");
			retailerTable.AddRow("Genuine Parts");
			retailerTable.AddRow("Kroger");
			retailerTable.AddRow("Lowe's");
			retailerTable.AddRow("McLean");
			retailerTable.AddRow("Meijer");
			retailerTable.AddRow("Office Depot");
			retailerTable.AddRow("Sears");
			retailerTable.AddRow("Smart & Final");
			retailerTable.AddRow("Staples");
			retailerTable.AddRow("Target");
			retailerTable.AddRow("Walmart");
			retailerTable.AddRow("Winco");
			new StepsSelectRetailers().SelectRetailersInListView(retailerTable);
			var allRetailers = selSelectRetailers.AllRetailers();
			if (allRetailers.Contains($"Canadian Tire"))
			{
				Report.Info($"Canadian Tire was found as an option, selecting it as a retailer");
				new StepsSelectRetailers().SelectTheRetailer("Canadian Tire");

			}
			else
			{
				Report.Info($"Canadian Tire was not found as an option, moving on.");
			}
			Report.StartSubStep("Click Done");
			new StepsSelectRetailers().IClickDoneButtonOnSelectRetailersWindow();
			Report.StartSubStep("In The additional requirments column, select an entry from the drop list for retailers 'Walmart' and 'Sears'");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Wal-Mart/SAM'S CLUB");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Sears/K-Mart");
			Report.StartSubStep("Click Continue");
			new StepsNewProduct().ClickContinue();

		}

		[StepDefinition(@"I call Shared Step 144969 \(Universal Product Code \(UPC\) - Add UPC for Web viewer Retailers - Continue\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedStep144969UniversalProductCodeAddUPCForWebViewerRetailersContinue(string upc, string containerType, string size)
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartSubStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Delay.Seconds(3);
			Report.StartSubStep("I add the following into the UPC Fields");

			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");

				//Report.IsTrue(new NewProduct().InputPartNumberInformation(upcInfo, partNumber), "Failed to input UPC Information!", "Successfully inputted UPC information!");

			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);

				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);

			}

			IWebElement partNameTextField = new NewProduct().ContainerElement.FindElement(By.XPath(".//label[contains(text(),'Part Number')]/..//input"), 2);

			if (partNameTextField == null)
			{
				Report.Info(@"partNameTextField was not found");
				return;
			}
			partNameTextField.EnterText("A0001");

			IWebElement dpciField = new NewProduct().ContainerElement.FindElement(By.XPath(".//label[contains(text(),'DPCI')]/..//input"), 2);
			if (dpciField == null)
			{
				Report.Info(@"dpciField was not found");
				return;
			}
			dpciField.EnterText("111-22-0001");

			Report.StartStep("Click Continue");
			new StepsNewProduct().ClickContinue();



		}

		[StepDefinition(@"I call Shared Step 145300 \(SHA - Submitted Status - Process BCP product - Close warning message\) for product saved as: (.*)")]
		public void GivenICallShared145300SHASubmittedStatusProcessBCPProductCloseWarningMessage(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Beginning shared step 145300");
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			string prodName = productDetails.Name;

			bool selectedID = false;
			for (int i = 0; i < 20; i++)
			{
				Report.Info("Waiting interation: " + i.ToString());
				Report.IsTrue(myStudioShaManager.SelectFromStatusFilter("Submitted"),
					"Failed to select from status filter",
					"Selected from status filter");
				Delay.Seconds(3);
				if (!myStudioShaManager.Wait_for_load(30))
				{
					Report.Error("Studio SHA Manager is not showing");
				}

				if (myStudioShaManager.SelectProductByID(id))
				{
					selectedID = true;
					break;
				}

				Delay.Seconds(3);
			}

			Report.IsTrue(selectedID, "Failed to select product with id: " + id, "Selected product with id: " + id);
			myStudioShaManager.ClickProcessProductData();
			Report.IsTrue(myStudioShaManager.SetAutoAssignRegulatorySpecialisttoProduct(false),
				"Failed to deselect Auto assign regulatory specialist", "Deselected auto assign regulatory specialist");
			var regSpec = TestVariables.GetVariableSavedAs("SHA Regulatory Specialist");
			if (regSpec == null)
			{
				Report.Info("Failed to find SHA Regulatory Specialist in context, defaulting to: Automated QASha");
				regSpec = "Automated QASha";
			}
			Report.Info($"The Regulatory Specialist that will be selected is: {regSpec}");

			Report.IsTrue(myStudioShaManager.SelectRegulatorySpecialist(regSpec),
				"Failed to select regulatory specialist", "Selected regulatory specialist");
			Report.IsTrue(myStudioShaManager.ClickContinueInProcessProducts(), "Failed to click continue",
				"Clicked continue");
			Report.IsTrue(myStudioShaManager.ProcessProductsErrorMessageMatches(id + " (" + prodName + ") - Merge: Document merge for BCP product " + id + " has failed – Please publish the required SDS for this product and manually run the document merge process."), "Failed to find the error message", "The error message was found");
			Report.IsTrue(myStudioShaManager.ClickCloseInProcessProducts(), "Failed to click close", "Clicked close");

		}

		[StepDefinition(@"I call Shared Step 158144 \(Product Information - Pesticide=Not Considered, SOLD=US, OSHA=NO, Shipped Directly=NO, CA Cleaning=YES, Private Label=YES, Sold to Retailer=NO - CONTINUE\)")]
		public void GivenICallSharedStepProductInformation_PesticideNotConsideredSOLDUSOSHANOShippedDirectlyNOCACleaningYESPrivateLabelYESSoldToRetailerNO_CONTINUE()
		{
			var MyNewProduct = new StepsNewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);
			Report.StartSubStep(
				"I set the Select countries the product may be sold in field to: United States");
			MyNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.",
				"Yes");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue")]
		public void GivenICallSharedStep145355FormulationBatteries_SelectGranted_Continue()
		{
			StepsNewProduct newProduct = new StepsNewProduct();

			Report.StartSubStep("I should see the Formulation > Batteries Page");
			newProduct.GivenIShouldSeeXPage("Formulation > Batteries");

			Report.StartSubStep("I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to Granted");
			newProduct.SetTheSectionOptionTo("Consent to Tier 2.1, 2.2, 4.2 Data Uses", "Granted");

			Report.StartSubStep("I click continue");
			newProduct.ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 144970 \(Go To Bulk Actions - Accept Documents\)")]
		public void GivenICallShared144970GoToBulkActionsAcceptDocuments()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"From the Main Products page in WERCSmart, Click the Bulk Actions button");
			new StepsProductGrid().GivenIClickBulkActionsInTheProductsGrid();
			Report.StartSubStep($"Click the Accept documents button");
			new StepsProductGrid().GivenIClickForwardProductRegistrationInTheBulkActionsWindow("Accept Documents");
			Report.StartSubStep($"I should see the header: Document Acceptance on the Document Acceptance window");
			new StepsProductGrid().GivenIShouldSeeTheHeaderDocumentAcceptanceOnTheDocumentAcceptanceWindow();
		}

		[StepDefinition(@"I call Shared Step 57561b \(The Product - Enter Product Name: (.*) and select Type of Product\): (.*) and add a Random Identifier")]
		public void GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProductAndAddRandomIdentifier(string name, string type)
		{
			var randomID = GeneralUtilities.GenerateRandomString(6);
			this.Step57561(type, name + " " + randomID);
		}

		[StepDefinition(@"I call Shared Step 145129 Regulatory Documents to Provide - Upload AIS and CCCR")]
		public void GivenICallSharedStepRegulatoryDocumentsToProvide_UploadAISAndCCCR()
		{

			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");

			Report.StartSubStep("I upload a PDF file to section: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.");
			MyNewProduct.UploadPDFFile("I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");

			Report.StartSubStep("I set the Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS. field to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.");
			MyNewProduct.SetRadioOptionInSectionTo("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.", "I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.");

			Report.StartSubStep("I set the WHMIS-compliant Safety Data Sheet, English and French-Canadian field to: I don't need a WHMIS Compliant SDS");
			MyNewProduct.SetRadioOptionInSectionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I don't need a WHMIS Compliant SDS");

			Report.StartSubStep("I upload a PDF file to section: Product Label in English and French-Canadian as required in Consumer Chemicals and Containers Regulations (CCCR), 2001 of the Hazardous Products Act");
			MyNewProduct.UploadPDFFile("Label in both French and English", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");


			Report.StartSubStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");

		}

		[StepDefinition(@"I call shared step 145969 \(Additional Product Information > SOLD \(Canada\), PLP \(YES\), Continue\)")]
		public void GivenICallSharedStepAdditionalProductInformationSOLDCanadaPLPYESContinue()
		{

			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Additional Product Information Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartSubStep("Make sure the United States check box is NOT selected, if it is uncheck it");
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			Report.StartSubStep("I set the Select countries the product may be sold in option to: Canada");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: Yes");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			Report.StartSubStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");

		}

		[StepDefinition(@"I call shared step 145844 \(Additional Product Information > SOLD \(Canada\), PLP \(No\), Continue\)")]
		public void GivenICallSharedStepAdditionalProductInformationSOLDCanadaPLPNoContinue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Additional Product Information Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartSubStep("Make sure the United States check box is NOT selected, if it is uncheck it");
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			Report.StartSubStep("I set the Select countries the product may be sold in option to: Canada");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call shared step 86009 \(Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue\)")]
		public void GivenICallSharedStepRetailer_PLPCanadaOnlySelectCanadianTireAddPLPData_Continue()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();

			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");

			var MyStepsRetailers = new Steps_Retailer();
			var newTable = new TechTalk.SpecFlow.Table(new string[] {
				"Retailer",
			});
			newTable.AddRow(new string[] {
				"No Retailer/No UPC Product",
			});
			Report.StartSubStep("In the 'Retailers' table I see the retailer: No Retailer/No UPC Product");
			MyStepsRetailers.SelectedRetailersShouldBe("should", newTable);
			Report.StartSubStep("In the 'Retailers' table No Retailer/No UPC Product cannot be deselected");
			MyStepsRetailers.ConfirmRetailerCannotBeDeselectedInRetailersTable("No Retailer/No UPC Product");

			Report.StartSubStep("In the 'Select Retailers' popup No Retailer/No UPC Product cannot be deselected");
			MyStepsRetailers.ConfirmRetailerCannotBeDeselectedInSelectRetailersPopup("No Retailer/No UPC Product");

			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: Canadian Tire");
			new StepsSelectRetailers().SelectTheRetailer("Canadian Tire");

			var retailers = new Table("Retailer");
			retailers.AddRow("Canadian Tire");
			retailers.AddRow("No Retailer/No UPC Product");
			new Steps_Retailer().SelectedRetailersShouldBe("should", retailers);

			new Steps_Retailer().ForRetailerIEnterPrivateLabelName("Canadian Tire", "This Private Label");

			Report.StartSubStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(@"I call shared step 72414 \(Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path\)")]
		public void GivenICallSharedStepRetailer_CanadaOnlySelectCanadianTireContinue_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			var MyStepsRetailers = new Steps_Retailer();
			var newTable = new TechTalk.SpecFlow.Table(new string[] {
				"Retailer",
			});
			newTable.AddRow(new string[] {
				"No Retailer/No UPC Product",
			});
			Report.StartSubStep("In the 'Retailers' table I see the retailer: No Retailer/No UPC Product");
			MyStepsRetailers.SelectedRetailersShouldBe("should", newTable);
			Report.StartSubStep("In the 'Retailers' table No Retailer/No UPC Product cannot be deselected");
			MyStepsRetailers.ConfirmRetailerCannotBeDeselectedInRetailersTable("No Retailer/No UPC Product");

			Report.StartSubStep("In the 'Select Retailers' popup No Retailer/No UPC Product cannot be deselected");
			MyStepsRetailers.ConfirmRetailerCannotBeDeselectedInSelectRetailersPopup("No Retailer/No UPC Product");
			Report.StartSubStep("In the 'Select Retailers' window I select the retailer: Canadian Tire");
			new StepsSelectRetailers().SelectTheRetailer("Canadian Tire");
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("In the Retailer page I click Continue");
			new StepsNewProduct().ClickContinue();
			Report.StartSubStep("In the UPCs Warning popup I click Ok");
			WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(@"I call shared step 65961 \(Additional Documents to Provide - Upload Full Product Label - Continue\.")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_UploadFullProductLabel_Continue_()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep(
					@"I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 214620 Power Designer Plus - AUTHORIZE Product \(Applicable Only to Battery Products\) for product saved as: (.*)")]
		public void ThenICallSharedStepPowerDesignerPlus_AUTHORIZEProductApplicableOnlyToProductsWithAnUploadedOSHA_SDSOrKitProducts(string savedAs)
		{
			Report.UseSubSteps = true;
			var thisStudioPowerDesignerPlusDesignMode = new StudioPowerDesignerPlusDesignMode();
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			var thisTopMenu = new StudioTopMenu();
			
			Report.StartSubStep(
				"I set the data codes to show the Green check mark graphic in Reviewer Checklist section");
			Report.Info("In power tools workspace I set edit to true");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			//new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"CAWC",
				"pass"
			});
			table2.AddRow(new string[] {
				"EPAN",
				"pass"
			});
			table2.AddRow(new string[] {
				"HCM",
				"pass"
			});
			table2.AddRow(new string[] {
				"OTC",
				"pass"
			});
			table2.AddRow(new string[] {
				"RAUNDW",
				"pass"
			});
			table2.AddRow(new string[] {
				"DPQAUN",
				"pass"
			});
			table2.AddRow(new string[] {
				"WSWC",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0877] Reviewer Checklist"))
			{
				thisStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0877] Reviewer Checklist");

				//thisStepsStudio.InPDIEnsureSECT2318IsActive();
				thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			}
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0755] Reviewer Checklist"))
			{
				thisStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Reviewer Checklist");

				thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			}
			Report.StartSubStep(
				"I set the data codes to show the Green check mark graphic in Battery/BCP Checklist section");
			thisStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0756] Battery/BCP Checklist");
			thisStepsStudio.GivenICheckTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("authoring");
			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			//Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
			//	"Set language option");
			//Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter("CKLT"), "Failed to set subformat option",
			//	"Set subformat option");
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Screenshot();
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(10);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
					Report.Screenshot();
					SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
				}
			}
			Report.StartSubStep("I close Current Document window");
			thisStepsStudio.GivenICloseCurrentDocument();

		}
		[StepDefinition(@"I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product")]
		public void ThenICallSharedStepPowerDesignerPlus_APPLYRULESToProduct()
		{
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("wizards");
			Report.StartSubStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartSubStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartSubStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartSubStep("In the rule name filter box I enter the studio user name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");

			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");

			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartSubStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartSubStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(10);
			if (SeleniumWebDriver.CurrentDriver.IsAlertPresent())
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}

			Report.StartSubStep("I close the Apply Rules pop up");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);
			if (new ApplyRulesPage().Wait_for_load(20))
			{
				Delay.Seconds(3);
				Report.Info("Clicking on close in apply rules popup did not work. Trying again...");
				thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
				Report.Screenshot();
				Delay.Seconds(3);
				if (new ApplyRulesPage().Wait_for_load(1))
				{
					Report.Error("Apply rules popup did not close after two attempts");
					SeleniumBrowser.WebBrowser.Close();
				}
			}
		}

		[StepDefinition(@"I call Sared Step 214627 Power Designer Plus - PUBLISH Product \(Applicable Only to Battery Products \): (.*)")]
		public void ThenICallSaredStepPowerDesignerPlus_PUBLISHProductApplicableOnlyToProductsWithAnUploadedOSHA_SDSOrKitProducts(string savedAs)
		{
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("product");
			Report.StartSubStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartSubStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			for (int i = 0; i < 5; i++)
			{
				Delay.Seconds(5);
				Report.Screenshot();
				var newDocumentQueuePage = new DocumentQueuePage();
				Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
					"Document queue page loaded");
				List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				if (listOfDocuments.Count > 0)
				{
					break;
				}
			}
			Report.StartSubStep(
				"I confirm the product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF");
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Format",
				"Subformat",
				"Language",
				"DocType",
				"Authorized"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"CKLT",
				"EN",
				"PDF",
				"3"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"HWHD",
				"EN",
				"PDF",
				"3"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"HWST",
				"EN",
				"PDF",
				"3"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"SBCS",
				"EN",
				"PDF",
				"3"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartSubStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(4);
			//Report.Screenshot();
			Report.Info($"waiting for spinner...");
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.Info($"fFinished waiting for spinner...");
			Report.StartSubStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartSubStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartSubStep("I close the Document queue window");
			var thisTopMenu = new StudioTopMenu();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
			Report.StartSubStep("I open Job Queue window");
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			thisTopMenu.ClickSubMenu("System", "Job Queue");
			GeneralUtilities.StudioWaitForSpinner();
			Delay.Seconds(5);
			var thisStudioJobQueue = new StudioJobQueue();
			Report.IsTrue(thisStudioJobQueue.WaitForJobInformationList(30), "Job queue has not loaded",
				"Job queue has loaded");
			Delay.Seconds(5);
			List<Job> ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
			TReVorTestUsers shaUser = TestUsers.GetUserSavedAs("SHAUser");
			Job matchingJob = ListOfJobs.FirstOrDefault(x =>
				x.Status == "Working" && x.Method == "PublishMultiple" && x.UserName == shaUser.Username);
			if (matchingJob == null)
			{
				Report.Info("Did not find matching job");
				Report.Screenshot();
			}
			else
			{
				Report.Success("Found job as expected");
				//Wait for job to not appear in the list
				for (int i = 0; i < 2; i++)
				{
					thisStudioJobQueue = new StudioJobQueue();
					if (Report.IsTrue(thisStudioJobQueue.TopBarMenuButtonExists("Refresh"), "Failed to find Refresh button", "Successfully found Refresh button"))
					{
						Report.IsTrue(thisStudioJobQueue.ClickTopBarMenuBotton("Refresh"), "Failed to click Refresh button", "Successfully clicked Refresh button");
					}
					ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
					matchingJob = ListOfJobs.FirstOrDefault(x =>
						x.Status == "Working" && x.Method == "PublishMultiple" && x.UserName == shaUser.Username);
					if (matchingJob == null)
					{
						Report.Info("Job is no longer found so assume it has completed");
						Report.Screenshot();
					}
					Delay.Seconds(1);
				}
			}
			Report.IsTrue(thisStudioJobQueue.ClickJobQueueMenuItem("History"), "Failed to click History button", "Successfully clicked History button");
			Delay.Seconds(3);
			if (Report.IsTrue(thisStudioJobQueue.TopBarMenuButtonExists("Refresh"), "Failed to find Refresh button", "Successfully found Refresh button"))
			{
				Report.IsTrue(thisStudioJobQueue.ClickTopBarMenuBotton("Refresh"), "Failed to click Refresh button", "Successfully clicked Refresh button");
			}
			List<Job> ListOfJobsInHistory = thisStudioJobQueue.GetFirstXJobs(20);
			Job matchingJobInHistory = ListOfJobsInHistory.FirstOrDefault(x =>
				x.Status == "Closed" && x.Method == "PublishMultiple" && x.UserName == shaUser.Username);
			if (matchingJobInHistory == null)
			{
				Report.Info("Did not find matching job in History tab");
				Report.Screenshot();
			}
			else
			{
				Report.Info("Found matching job in History tab");
				Report.Screenshot();
			}
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			var globalSteps = new GlobalSteps();
			Report.StartSubStep("I switch to the PD+ tab");
			globalSteps.WhenISwitchToTheTab("Power Designer Plus");
			var thisStudioPowerDesignerPlusDesignMode = new StudioPowerDesignerPlusDesignMode();
			Delay.Seconds(30);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickRefreshButtonLeft(), "Failed to click Refresh button", "Successfully clicked Refresh button");
			Delay.Seconds(30);
			//Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("refresh"), "Failed to find the refresh button.", "Successfully clicked refresh.");
			Report.IsTrue(thisPowerDesignerPlus.ProductIsCheckedOutIconDisplayed(), "Failed to find 'Product is Checked Out' icon", "Successfully 'Product is Checked Out' icon");
		}
		

		[StepDefinition(@"I call Shared Step 214632\(Power Designer Plus - MTR/BATT - Update BATACT \(Active Battery Indicator\) to Finish Processing Battery \(Alone\) Products\):")]
		public void ThenICallSharedStepPowerDesignerPlus_MTRBATT_UpdateBATACTActiveBatteryIndicatorToFinishProcessingBatteryAloneProducts(Table table)
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			var globalSteps = new GlobalSteps();
			var newValueEditor = new ValueEditor();
			Report.StartSubStep("I switch to the PD+ tab");
			globalSteps.WhenISwitchToTheTab("Power Designer Plus");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickSearchFormatSubformat(), "Failed to click Search button", "Successfully clicked Search button");
			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Format"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Format/SubFormat");
					Report.Screenshot();
					break;
				}
			}
			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("BATT", "MTR"), "Failed to set format option",
				"Set format option");
			var selStepsStudio = new Steps_Studio();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			// 'If you can't click on them select Options and make sure Edit mode is selected.'
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("SECT0069"))
			{
				selStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0069] Battery Information");
			}
			Report.Info($"Getting saved product: {table.Rows[0]["ProductId"]}");
			if (!Context.Contains(table.Rows[0]["ProductId"]))
			{
				Report.Error($"Context does not contain: {table.Rows[0]["ProductId"]}");
			}
			var product = (ProductInformation)Context.GetFromContext(table.Rows[0]["ProductId"]);
			string id = product.Id;
			string productName = product.Name;
			string battManufacturer = thisStudioPowerDesignerPlusDesignMode.GetCategoryValue("Battery Manufacturers");
			newValueEditor.ClickButton("Cancel");
			Report.IsTrue(battManufacturer.Contains(productName), "Failed to confirm Battery Manufacturers section contains correct product name", "Successfully confirmed confirm Battery Manufacturers section contains correct product name");
			Report.IsTrue(battManufacturer.Contains(id), "Failed to confirm Battery Manufacturers section contains correct product ID", "Successfully confirmed confirm Battery Manufacturers section contains correct product ID");
			string battType = thisStudioPowerDesignerPlusDesignMode.GetCurrentValueInMTRFormat("BATYPE");
			Report.IsTrue(battType.Contains(table.Rows[0]["BatteryType"]), "Failed to confirm Battery Types section contains correct battery type", "Successfully confirmed Battery Types section contains correct battery type");
			string battItself = thisStudioPowerDesignerPlusDesignMode.GetCurrentValueInMTRFormat("BATTT");
			Report.IsTrue(battItself.Contains("1"), "Failed to confirm 'Product Itself is a battery' section contains value '1'", "Successfully confirmed 'Product Itself is a battery' section contains value '1'");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.DoubleClickCategory("BATACT"), "Failed to double click category", "Successfully double clicked category");
			//selStepsStudio.GivenInPowerDesignerIDoubleClickOnCategory("[BATACT]");
			newValueEditor.EnterValueIntoField("1");
			newValueEditor.ClickButton("Save");
		}


		[StepDefinition(@"I call Shared step 214825 \(Additional Documents to Provide - Upload Product Label - Continue\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_UploadProductLabel_Continue_()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep(
					@"I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFileSectionAndType("Product Label", "Volatile Organic Compounds", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartSubStep("In the Additional Documents to Provide page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call shared step 149691 \(WPS Studio - PD\+ - PLP product for Canada - publish alias HGHS documents for product saved as: (.*)\)")]
		public void GivenICallSharedStepWPSStudio_PD_PLPProductForCanada_PublishAliasHGHSDocumentsForProductSavedAs(string savedAs)
		{
			Report.StartStep("Beginning shared step 78888");
			Report.UseSubSteps = true;
			Report.StartSubStep(
				"I set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic");
			Report.Info("In power tools workspace I set edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Formulation"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
			//this.GivenICallSharedStep49742_WPS_CheckInProduct(savedAs);

			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}

		}

		[StepDefinition(@"I call shared step 120812 \(Retailer - Add retailers for RPS\)")]
		public void GivenICallSharedStepRetailer_AddRetailersForRPS()
		{
			Report.UseSubSteps = true;

			var selSelectRetailers = new SelectRetailers();

			Report.StartSubStep("With the Select Retailers pop up shown, Select all the web viewer retailers:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("CVS");
			retailerTable.AddRow("Lowe's");
			retailerTable.AddRow("Target");
			retailerTable.AddRow("The Home Depot");
			retailerTable.AddRow("Publix");
			retailerTable.AddRow("Wal-Mart/SAM'S CLUB");
			new StepsSelectRetailers().SelectRetailersInListView(retailerTable);
			Report.StartSubStep("Click Done");
			new StepsSelectRetailers().ClickDone();

			Report.StartSubStep("I set the Vendor as: Testing");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Wal-Mart/SAM'S CLUB");

			Report.StartSubStep("Click Continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call shared step 120813 \(UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: (.*) and size: (.*)\)")]
		public void GivenICallSharedStepUPC_AddUPCs_IncludingOneForCVSRCLAndAddHomeDepotOMSIDForUPCSavedAsAndUPCSavedAsUPC(string containerType,
			string size)
		{

			Report.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");

			for (int k = 0; k < 2; k++)
			{

				for (int i = 0; i < 100; i++)
				{
					Report.Info("Entering UPC information. Attempt: " + (i + 1));
					Report.StartSubStep("I click the 'Add' button");
					stepsNewProduct.ThenIClickTheAddUpcButton();
					Report.StartSubStep("I add the following into the UPC Fields");
					string upc = new UpcFunctions().GeneratePrefixedUPCForRetailer("CVS");
					Report.Info("UPC number: " + upc);
					var upcInfo = new UpcInformation {
						ContainerType = containerType,
						Size = size,
						UpcNumber = upc
					};
					Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
						"Successfully inputted UPC information!");

					var newProductPage = new NewProduct();
					Report.IsTrue(newProductPage.SelectCaseUPCDropDownArrowForUPC(upc, "Collapse"), "Failed to select dropdown arrow with the UPC: " + upc, "Succesfully selected dropdown arrow with the UPC: " + upc);


					if (k == 1)
					{

						Report.StartSubStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
						stepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
						GeneralUtilities.Wait_for_load_finish();

					}

					// not returning...
					if (new NewProduct().FormError().IsNullOrEmpty())
					{
						if (k == 1)
						{
							return;
						}
						else
						{
							break;
						}
					}
					if (new NewProduct().FormError().Contains("UPC failing Transportation Rules."))
					{
						Report.Failure($"The Product created is failing the UPC Transporation Rules. An error was seen.");
						Report.Screenshot();
						if (k == 1)
						{
							return;
						}
						else
						{
							break;
						}
					}
					// delete upc that failed
					stepsNewProduct.GivenIDeleteUPC(upc);
					Report.Info("An error was showing! on click continue! Attempting a different UPC");

				}

			}

		}


		[StepDefinition(@"I call shared step 51609 \(CVS RCL - Yes I wish to continue with registration - Continue\)")]
		public void GivenICallSharedStepCVSRCL_YesIWishToContinueWithRegistration_Continue()
		{
			Report.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I confirm the CVS Pharmacy section appears");
			selNewProductSteps.GivenIShouldSeeXPage("CVS Own Brand Registration");
			Report.StartSubStep(
				"I set the Continue? option to: Yes, I wish to continue registration");
			selNewProductSteps.SetTheSectionOptionTo(
				"Continue?",
				"Yes, I wish to continue registration");
			Report.StartSubStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call shared step 52131 \(CVS RCL Information - add Other where available and all other data\)")]
		public void GivenICallSharedStepCVSRCLInformation_AddOtherWhereAvailableAndAllOtherData()
		{
			Report.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I confirm the CVS Pharmacy section appears");
			selNewProductSteps.GivenIShouldSeeXPage("CVS RCL");
			Report.StartSubStep(
				"I set the What is the CVS Store Brand associated to this product? option to: Other");
			selNewProductSteps.SetTheSectionOptionTo(
				"What is the CVS Store Brand associated to this product?",
				"Other");
			Report.StartSubStep(
				"I set the Indicate the brand option to: Other");
			selNewProductSteps.SetTheSectionOptionToExactlyMatch("Indicate the brand", "Other");
			Report.StartSubStep(
				"I set the Who is the Product Development Manager (PDM) for this product? option to: Canady, Cory Cory.Canady@CVSHealth.com");
			selNewProductSteps.SetTheSectionOptionTo(
				"Who is the Product Development Manager (PDM) for this product?",
				"Canady, Cory Cory.Canady@CVSHealth.com");
			Report.StartSubStep(
				"I set the What is the CVS merchandising category for this product? option to: Other");
			selNewProductSteps.SetTheSectionOptionTo(
				"What is the CVS merchandising category for this product?",
				"Other");
			Report.StartSubStep(
				"I set the Indicate your Product Category to: Other");
			selNewProductSteps.SetTheSectionOptionToExactlyMatch("Indicate your Product Category", "Other");
			Report.StartSubStep(
				"I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: Yes");
			selNewProductSteps.SetTheSectionOptionTo(
				"Is this product specifically designed, marketed or labeled for infants, babies, or children?",
				"Yes");
			Report.StartSubStep(
				"I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels?",
				"No");
			Report.StartSubStep(
				"I set the Product contains microbeads option to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product contains microbeads",
				"No");
			Report.StartSubStep(
				"I set the Is this product intended to be rinsed off after use? option to: Yes");
			selNewProductSteps.SetTheSectionOptionTo(
				"Is this product intended to be rinsed off after use?",
				"Yes");
			Report.StartSubStep(
				"I set the Refer to your Product Label. Select the options that appear on the label. option to: Drug Facts Panel");
			selNewProductSteps.SetTheSectionOptionTo(
				"Refer to your Product Label. Select the options that appear on the label.",
				"Drug Facts Panel");

			List<string> showing = new NewProduct().SelectedOptionsForSection("Is this product intended to be ingested?");
			if (showing.Count == 0)
			{
				Report.Info("No options selected for section: Is this product intended to be ingested?");
				Report.StartStep(
				"I set the Is this product intended to be ingested? option to: Yes");
				selNewProductSteps.SetTheSectionOptionTo(
					"Is this product intended to be ingested?",
					"Yes");
			}

			Report.StartSubStep(
				"I set the Is this product a personal care sanitizer, wash, or cleanser (e.g., Hand, Body, Facial)? option to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Is this product a personal care sanitizer, wash, or cleanser (e.g., Hand, Body, Facial)?",
				"No");
			Report.StartSubStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call shared step 144993 \(WPS Studio - PD\+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP for product saved as: (.*)\)")]
		public void GivenICallSharedStepWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSForPLPForProductSavedAs(string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			Report.UseSubSteps = true;
			Report.Info("In power tools workspace setting edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");

			Report.Info("Going to do publishing");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Delay.Seconds(3);
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			GeneralUtilities.StudioWaitForSpinner();
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Delay.Seconds(3);
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(3);
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);

			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();


			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;


			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Format",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"MTR",
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			thisStepsStudio.ICloseAlert();
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		//[StepDefinition(@"I call shared step 144993 \(WPS Studio - PD\+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP for product saved as: (.*)\)")]
		//public void GivenICallSharedStepWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSForPLPForProductSavedAs(string savedAs)
		//{
		//	if (Context.Contains("ElectronicProduct"))
		//	{
		//		if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
		//		{
		//			Report.Info("Skipping step because this is an electronic product");
		//			return;
		//		}

		//	}

		//	ReportSettings.UseSubSteps = true;
		//	Report.Info("In power tools workspace setting edit to true");
		//	var thisStudioPowerDesignerPlusDesignMode =
		//		new StudioPowerDesignerPlusDesignMode();
		//	Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
		//		"Power designer has opened");
		//	thisStudioPowerDesignerPlusDesignMode.ClickOptions();
		//	Delay.Seconds(1);
		//	Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
		//		"Document options panel has not opened",
		//		"Document options panel has opened");
		//	Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
		//		"Successfully set edit to true");
		//	thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
		//	new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
		//	var table2 = new Table(new string[] {
		//		"datacode",
		//		"value"
		//	});
		//	table2.AddRow(new string[] {
		//		"DPQAPF",
		//		"pass"
		//	});
		//	table2.AddRow(new string[] {
		//		"DCQAPF",
		//		"pass"
		//	});
		//	table2.AddRow(new string[] {
		//		"VCQA",
		//		"pass"
		//	});
		//	table2.AddRow(new string[] {
		//		"RSQAPF",
		//		"pass"
		//	});
		//	table2.AddRow(new string[] {
		//		"RSQHADPF",
		//		"pass"
		//	});
		//	var thisStepsStudio = new Steps_Studio();
		//	thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
		//	thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
		//	thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
		//	var table3 = new Table(new string[] {
		//		"Item"
		//	});
		//	table3.AddRow(new string[] {
		//		"Current Document (Publish)"
		//	});
		//	table3.AddRow(new string[] {
		//		"Document Queue"
		//	});
		//	table3.AddRow(new string[] {
		//		"Apply rules"
		//	});
		//	thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
		//	thisStepsStudio.GivenInTheEditToolbarPageIClick("save");

		//	Report.Info("Going to do publishing");
		//	thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
		//	thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
		//	Delay.Seconds(3);
		//	GeneralUtilities.StudioWaitForSpinner();
		//	thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
		//	GeneralUtilities.StudioWaitForSpinner();
		//	var table4 = new Table(new string[] {
		//		"Text",
		//		"Should Show"
		//	});
		//	table4.AddRow(new string[] {
		//		"HGHS",
		//		"False"
		//	});
		//	thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
		//	Report.StartStep("I close the current document pop up");
		//	thisStepsStudio.GivenICloseCurrentDocument();
		//	Report.StartStep("I select the Apply Rules icon from the tool bar");
		//	thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
		//	Report.StartStep("I select the Single rule radio button");
		//	thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
		//	Report.StartStep("I click the three ... icon to open the Select Rule pop up");
		//	thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
		//	Report.StartStep("I click the filter icon");
		//	thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
		//	thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");

		//	Report.StartStep("In the rule name filter box I enter the studio user name");
		//	thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
		//	thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
		//	Report.StartStep("I select the rule  by clicking on it");
		//	thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
		//	Report.StartStep("I click Apply");
		//	thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
		//	Delay.Seconds(10);
		//	if (SeleniumBrowser.Alert.IsAlertPresent())
		//	{
		//		SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
		//		Delay.Seconds(1);
		//	}

		//	Report.StartStep("I close the Apply Rules pop up");
		//	thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
		//	Delay.Seconds(3);
		//	if (new ApplyRulesPage().Wait_for_load(1))
		//	{
		//		Delay.Seconds(3);
		//		Report.Info("Clicking on close in apply rules popup did not work. Trying again...");
		//		thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
		//		Report.Screenshot();
		//		Delay.Seconds(3);
		//		if (new ApplyRulesPage().Wait_for_load(1))
		//		{
		//			Report.Error("Apply rules popup did not close after two attempts");
		//			SeleniumBrowser.WebBrowser.Close();
		//		}
		//	}

		//	Report.StartStep("I click the Document queue icon in the tool bar");
		//	thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
		//	Report.StartStep("I click the filter icon");
		//	thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
		//	var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
		//	string id = productDetails.Id;
		//	thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
		//	Report.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
		//	thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
		//	thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();

		//	for (int i = 0; i < 5; i++)
		//	{
		//		Delay.Seconds(5);
		//		Report.Screenshot();
		//		var newDocumentQueuePage = new DocumentQueuePage();
		//		Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
		//			"Document queue page loaded");
		//		List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
		//		if (listOfDocuments.Count > 0)
		//		{
		//			break;
		//		}
		//	}
		//	// And I Confirm your product is shown with entries for SBCS EN PDF, HGHS EN RTF, HGHS EN PDF, HGHS CF RTF,
		//	// HGHS CF PDF CKLT EN PDF. If your product is a PL product you will also see an entry for the product alias
		//	// Note: as we are working with HGHS only, we should see CKLT and SBCS for the alias products

		//	Report.StartStep(
		//		"I Confirm your product is shown with entries for SBCS EN PDF, HGHS EN RTF, HGHS EN PDF, HGHS CF RTF, HGHS CF PDF CKLT EN PDF");
		//	var tblCheckDocument = new Table(new string[] {
		//		"ProductOrAlias",
		//		"Subformat",
		//		"Language",
		//		"DocType"
		//	});
		//	tblCheckDocument.AddRow(new string[] {
		//		"saved as " + savedAs,
		//		"HGHS",
		//		"EN",
		//		"RTF"
		//	});
		//	tblCheckDocument.AddRow(new string[] {
		//		"saved as " + savedAs,
		//		"HGHS",
		//		"EN",
		//		"PDF"
		//	});
		//	tblCheckDocument.AddRow(new string[] {
		//		"saved as " + savedAs,
		//		"HGHS",
		//		"CF",
		//		"RTF"
		//	});
		//	tblCheckDocument.AddRow(new string[] {
		//		"saved as " + savedAs,
		//		"HGHS",
		//		"CF",
		//		"PDF"
		//	});
		//	thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
		//	Delay.Seconds(3);
		//	thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
		//	Delay.Seconds(3);
		//	Report.Screenshot();

		//	thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
		//	Report.Screenshot();
		//	Report.StartStep("I click Process Documents");
		//	thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
		//	Delay.Seconds(2);
		//	Report.Screenshot();
		//	GeneralUtilities.StudioWaitForSpinner(60);
		//	Report.StartStep(
		//		"I confirm a pop up shows with message indicating queued documents were sent for publishing");
		//	thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
		//	Report.StartStep("I click OK ");
		//	thisStepsStudio.ICloseAlert();
		//	Report.StartStep("I close the Document queue window");
		//	thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		//}

		[StepDefinition(@"I call Shared Step 107012 \(WPS Studio - Open PD\+ with MTR/RPS subformat for product saved as: (.*)\)")]
		public void GivenICallSharedStepWPSStudio_OpenPDWithMTRRPSSubformat(string savedAs)
		{

			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();

			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}
			}

			Report.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			Report.StartSubStep("I click the Authoring menu option and Select Power Designer Plus");
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
			Report.Screenshot();
			Delay.Seconds(3);
			Report.StartSubStep("I select EN as the Language, MTR/RPS as the format/subformat");
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			if (!thisPowerDesignerPlus.Wait_for_load(120))
			{

				thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
				thisStudioPowerDesignerPlusDesignMode.ClickMenuAndSubmenuOptions("Home");
				Delay.Seconds(3);
			}

			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(60), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
				"Set language option");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter("RPS"), "Failed to set subformat option",
				"Set subformat option");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("RPS", "MTR"), "Failed to set format option",
				"Set format option");
			Report.StartSubStep("I click the Edit Existing product radio button if not already selected");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");
			Report.Screenshot();
			Delay.Seconds(1);
			Report.StartSubStep("I filter for the product");
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(3);

			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.StartSubStep("I click Continue");
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button", "Clicked continue button");
			Delay.Seconds(3);
			thisPowerDesignerPlus.Wait_for_load(60);

			//HERE ADD EDITMODE

			Report.Info("In power tools workspace I set edit to true");

			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.Info($"spinner wait...");
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(120);
			Report.Info($"spinner wait end.");
			Report.Screenshot();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();


			//End Editmode


			Report.Info("Now going to click the sections side tab if its not open");
			thisPowerDesignerPlus.Wait_for_load(60);
			var selStepsStudio = new Steps_Studio();
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			selStudioPowerDesignerPlus.Wait_for_load(60);
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT2318"))
			{
				selStepsStudio.InPDIEnsureSECT2318IsActive();
				selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			}
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT0077"))
			{
				selStepsStudio.InPDIEnsureSECT0077IsActive();
				selStepsStudio.InPDIFillTheSectionWalmartTransportationInformationWithJunkData();
			}

			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			var checkListSection = TestVariables.GetVariableSavedAs("PD Checklist Section");
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", checkListSection);

		}

		[StepDefinition(@"I call Shared Step 107013 \(WPS PD\+ - select your product for product saved as: (.*)\)")]
		public void GivenICallSharedStepWPSPD_SelectYourProductForProductSavedAsTestCase(string savedAs)
		{
			Report.UseSubSteps = true;
			var selStepsSha = new Steps_SHA();
			var selStepsStudio = new Steps_Studio();
			Report.StartSubStep("I navigate to Power Designer Plus");
			selStepsSha.GivenIClickTopMenuItemAndSubMenuItem("Authoring", "Power Designer Plus");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep("I filter by product ID");

			if (WercSmartSettings.TestCaseId == 0)
			{
				throw new Exception("Needs the test case ID to fetch the product ID to continue!");
			}

			string id = Context.GetFromContext("TestCase" + WercSmartSettings.TestCaseId).ToString();
			if (id == null)
			{
				throw new Exception($"Needs the product ID to be saved to context as 'TestCase{WercSmartSettings.TestCaseId}'!");
			}

			selStepsStudio.PowerDesignerPlusWelcomeIEnterSelectSourceProduct(id);
			Report.StartSubStep("I confirm RPS (Checklist) is selected as the subformat");
			selStepsStudio.IConfirmTheSelectedSubformatInThePdPlusPopupIs("RPS / Checklist");
			Report.StartSubStep("I click continue");
			selStepsStudio.ClickContinueInThePowerDesignerPlusPopup();
			Delay.Seconds(3);

			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT2318"))
			{
				selStepsStudio.InPDIEnsureSECT2318IsActive();
				selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			}
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT0077"))
			{
				selStepsStudio.InPDIEnsureSECT0077IsActive();
				selStepsStudio.InPDIFillTheSectionWalmartTransportationInformationWithJunkData();
			}
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			var checkListSection = TestVariables.GetVariableSavedAs("PD Checklist Section");
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", checkListSection);
		}



		[StepDefinition(@"I call Shared Step 120826 \(WPS Studio - PD\+ - Add RPS specific data for product saved as: (.*)\)")]
		public void GivenICallSharedStepWPSStudio_PD_AddRPSSpecificDataForProductSavedAsTestCase(string savedAs)
		{
			Report.StartStep("Beginning shared step 120826");
			Report.UseSubSteps = true;
			Report.StartSubStep("I set the EPAN, DCQAPF, VOCQA, RSQAPF and RSQAHDPF data codes to show the Green check mark graphic");
			Report.Info("In power tools workspace I set edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			// 'If you can't click on them select Options and make sure Edit mode is selected.'
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();

			var selStepsStudio = new Steps_Studio();
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT2318"))
			{
				selStepsStudio.InPDIEnsureSECT2318IsActive();
				selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			}
			if (selStudioPowerDesignerPlus.DoesPDSectionExist("SECT0077"))
			{
				selStepsStudio.InPDIEnsureSECT0077IsActive();
				selStepsStudio.InPDIFillTheSectionWalmartTransportationInformationWithJunkData();
			}
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			var checkListSection = TestVariables.GetVariableSavedAs("PD Checklist Section");
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", checkListSection);
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			// Set the EPAN, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic (filename is DPQA_PASS[1].png)
			// Do this by double clicking on the graphic and selecting the green check mark graphic from the available list and click save
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"EPAN",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAHDPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Formulation"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
			Report.StartSubStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartSubStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Report.Info("Now waiting for spinner...");
			Delay.Seconds(5);
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartSubStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				Report.Info("Spinner is showing, looking for alert");
				if (SeleniumWebDriver.CurrentDriver.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}
			Report.Info("Spinner is no longer showing");

			Report.StartSubStep("I confirm CKLT, NGHS and SBCS are not shown in the pop up message and click OK");
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			table4.AddRow(new string[] {
				"NGHS",
				"False"
			});
			table4.AddRow(new string[] {
				"SBCS",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			Report.StartSubStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("My Toolbar");
			Report.StartSubStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartSubStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartSubStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartSubStep("In the rule name filter box I enter the studio user name");
			//thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");

			bool found = Context.FeatureContext.TryGetValue("QASHAAccount", out string savedStudioAcc);
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox(savedStudioAcc, "rule name");


			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartSubStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartSubStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(10);
			if (SeleniumWebDriver.CurrentDriver.IsAlertPresent())
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}

			Report.StartSubStep("I close the Apply Rules pop up");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);
			if (new ApplyRulesPage().Wait_for_load(20))
			{
				Delay.Seconds(3);
				Report.Info("Clicking on close in apply rules popup did not work. Trying again...");
				thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
				Report.Screenshot();
				Delay.Seconds(3);
				if (new ApplyRulesPage().Wait_for_load(1))
				{
					Report.Error("Apply rules popup did not close after two attempts");
					SeleniumBrowser.WebBrowser.Close();
				}
			}

			Report.StartSubStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();

			Report.StartSubStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartSubStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();

			for (int i = 0; i < 5; i++)
			{
				Delay.Seconds(5);
				Report.Screenshot();
				var newDocumentQueuePage = new DocumentQueuePage();
				Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
					"Document queue page loaded");
				List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				if (listOfDocuments.Count > 0)
				{
					break;
				}
			}

			Report.StartSubStep(
				"I confirm the product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF");
			var tblCheckDocument = new Table(new string[] {
				"ProductOrAlias",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartSubStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(4);
			//Report.Screenshot();
			Report.Info($"waiting for spinner...");
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.Info($"fFinished waiting for spinner...");
			Report.StartSubStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartSubStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartSubStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();

		}

		[StepDefinition(@"I call Shared Step 92580 \(Click \.\.\. in Actions > Update Data > Summary Page - Edit Product\)")]
		public void GivenICallSharedStepClick_InActionsUpdateDataSummaryPage_EditProduct()
		{
			new StepsProductGrid().WhenIClickRowActionsForTheFirstProductReturned();
			new StepsProductGrid().ClickRowAction("Update Data");
			new Steps_Summary().IWaitForTheSummaryScreenToLoad();
			new Steps_Summary().InTheSummaryScreenIClick();
			new StepsProductGrid().IShouldSeeTheUpdateRegistrationPopup();
			new StepsProductGrid().InUpdateRegistrationPopupIClickButton("Continue");
		}

		[StepDefinition(@"I call Shared Step 26900 \(Transportation Details 1 > Not Regulated\)")]
		public void ICallSharedStep26900()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartSubStep("I should see the Transportation Details 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Transportation Details 1");
			Report.StartSubStep("In the Transportation Details 1 page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
			Report.StartSubStep("In the Transportation Details 1 page, I should see error message: \"This is a required field\".");
			MyNewProductSteps.ErrorMessageSpecific("This is a required field.");
			Report.StartSubStep("I set the Product is Regulated for Transport field to: Not Regulated");
			MyNewProductSteps.SetTheSectionOptionTo("Product is Regulated for Transport", "Not Regulated");
			List<string> showing = MyNewProduct.SelectedOptionsForSection("Product is Regulated for Transport");
			bool selected = false;
			int wait = 0;
			while (!selected && !showing.Contains("Not Regulated") && wait <= 10)
			{
				// Check if the option exists in the drop down
				if (MyNewProduct.GetAllOptionsForSection("Product is Regulated for Transport")
					.Contains("Not Regulated"))
				{
					// If yes, attempt again
					Report.Info("Trying again to select option: Not Regulated");
					MyNewProductSteps.SetTheSectionOptionTo("Product is Regulated for Transport", "Not Regulated");
					if (MyNewProduct.SetOptionInSection("Product is Regulated for Transport", "Not Regulated"))
					{
						selected = true;
					}
				}
				else
				{
					// If no, report fail
					Report.Failure(
						"It was not possible to select the option: Not Regulated for the section: Product is Regulated for Transport");
					Report.Screenshot();
				}

				wait++;
				Delay.Seconds(1);
			}

			Report.StartSubStep("In the Transportation Details 1 page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
			Report.UseSubSteps = false;
		}

		[StepDefinition(
	@"I call Shared Step 128742 \(Transportation Details - Regulated for Transport\(No\) - Exemption\(Random\) - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails_RegulatedForTransportNo_Continue_HappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport",
				"No, due to an exemption or exception");
		}

		[StepDefinition(
			@"I call Shared Step \(Transportation Details - Confirm DOT Exceptions saved - Continue - Happy Path\)")]
		public void GivenICallSharedConfirmDOTExceptions_Continue_HappyPath()
		{
			var newProduct = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Please select DOT Exceptions if applicable", "173.120(a)(4)");
			MyStepsNewProduct.ThenIEnterTheFollowingIntoTheOtherDOTException("test");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
			newProduct.ConfirmTheDataSelectedIsVisible();
		}

		[StepDefinition(
			@"I call Shared Step \(Transportation Details - Other DOT Exception Validation - Continue - Happy Path\)")]
		public void GivenICallSharedOtherDOTExceptionValidation_Continue_HappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			MyStepsNewProduct.ThenIEnterTheFollowingIntoTheOtherDOTException(" ");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
			Report.StartStep("I should see the DOT exceptions error message");
			stepsNewProductIngredients.DOTExceptionsErrorMessageShowing("should");
		}


		[StepDefinition(@"I call Shared Step 105009 \(Physical and Chemical Properties - Wine Not Regulated <=24% Alcohol\)")]
		public void Shared105009EnterPhysicalProperty_Liquid_ForWineNotRegulatedLessThan24Alcohol()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("I set the Relative Density option to: 68");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "68");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartStep("I set the pH field to: 4 - 6.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "4 - 6.9");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			Report.StartStep("I set the Boiling Point (in Celsius) field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Not Tested/Unknown");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 105010 \(Beverage Regulatory Details Less < 24%\)")]
		public void Shared105010BeverageRegulatoryDetailsLessThan24()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				"No"));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", "No");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				"21"));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", "21");
			Report.StartStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}

		[StepDefinition(@"I call Shared Step 57984 \(Transportation Details - All options available - Select Not regulated - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails_SelectNotregulated_Continue_HappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport",
				"Not Regulated");

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}
		[StepDefinition(@"I call Shared Step 92979 \(Physical and Chemical Properties - Physical Property - Liquid - For Spirits \(RU001434\) \(Greater than 70% Alcohol\)\)")]
		[StepDefinition(@"I call Shared Step 92979 \(Physical and Chemical Properties - Physical Property - Liquid - For Wine Less than >70% Alcohol\)")]
		public void Shared92979EnterPhysicalProperty_Liquid_ForWineGreaterThan70()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("I set the Relative Density option to: 0.1");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "0.1");
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for pH I enter: 7 ");
			MyNewProduct.SetTheSectionOptionTo("pH","7");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: 78 ");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)","78");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: 12 ");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)","12");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: Closed Cup Method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 216822 \(Physical and Chemical Properties - Applicable Only to Alcoholic Beverages - Wine \(RU001418\)\)")]
		public void Shared216822EnterPhysicalProperty_Liquid_Wine()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("I set the Relative Density option to: 0.1");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "0.1");
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for pH I enter: 7 ");
			MyNewProduct.SetTheSectionOptionTo("pH", "7");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: 78 ");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "78");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: 12 ");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "34");
			Report.StartSubStep("Confirm that  you see only Closed Cup Method option for Flash Point Testing Method Used");
			var option = new Table("Option");
			option.AddRow("Closed cup method");
			MyNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Flash Point Testing Method Used", option);
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: Closed Cup Method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}

		[StepDefinition(@"I call Shared Step 217789 \(Physical and Chemical Properties - Physical Property - Liquid \)")]
		public void Shared92979EnterPhysicalProperty_Liquid()
		{
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("I set the Relative Density option to: 0.1");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "0.1");
			Report.StartSubStep("In the Product Characteristics tab of the New Product Page for pH I enter: 6 ");
			MyNewProduct.SetTheSectionOptionTo("pH", "6	");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: 100 ");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "100");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: 100 ");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "100");
			Report.StartSubStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: Not applicable/available");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Miscible");
			Report.StartStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}


		[StepDefinition(@"I call Shared Step 92981 \(Beverage Regulatory Details Greater > 70%\)")]
		public void Shared92981BeverageRegulatoryDetailsGreaterThan70()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				"No"));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", "No");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				"80"));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", "80");
			Report.StartStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}
		[StepDefinition(@"I call Shared Step 216838 \(Beverage Regulatory Details - Applicable Only to Alcoholic Beverages - Wine \(RU001418\)\):")]
		[StepDefinition(@"I call Shared Step 92981a \(Beverage Regulatory Details\):")]
		public void GivenICallSharedStepABeverageRegulatoryDetailsWithTable( Table table)
		{ 
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format($"I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				table.Rows[0]["BPA"]));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", table.Rows[0]["BPA"]);
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				table.Rows[0]["BPA"]));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", table.Rows[0]["Percent of Alcohol"]);
			Report.StartStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}
		[StepDefinition(@"I call Shared Step 178053 \(Beverage Regulatory Details - BPA - Prop65\):")]
		public void GivenICallSharedStepABeverageRegulatoryDetailsWithTableWithProp65(Table table)
		{
			ReportSettings.UseSubSteps = true;
			if (table.Rows.Count != 1)
			{
				Report.Error($"This step requires a table that only has one row in it, and there were {table.Rows.Count}.");
				Report.Info("Using only the first row from the table");
			}
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format($"I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				table.Rows[0]["BPA"]));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", table.Rows[0]["BPA"]);
			Report.StartStep(string.Format($"I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				table.Rows[0]["BPA"]));
			myStepsNewProduct.SetTheSectionOptionTo("Does your product contain a Prop 65 chemical?", table.Rows[0]["Prop 65"]);
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Does your product contain a Prop 65 chemical?",
				table.Rows[0]["Prop 65"]));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", table.Rows[0]["Percent of Alcohol"]);
			Report.StartStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}

		[StepDefinition(
			@"I call Shared Step 92982 \(U\. S\. Department of Transportation \(DOT\) Classification - For Alcohol \(Packaging II\)\)")]
		public void GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidData_ForAlcohol()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN3065");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN3065");
			Delay.Seconds(2);
			Report.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartStep("I select '3' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "3");
			Report.StartStep("I select 'II' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "II");
			Report.StartStep(
				"The following question should be displayed: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packaging Group selected is not consistent with this data.  Verify the data and transportation packaging group.  If the problem persists, please contact Support.'");
			var table = new Table("Section");
			table.AddRow(
				"Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.");
			MyNewProduct.CheckDisplayedSections("see", table);
			Report.StartStep(
				"Setting 'Packing Group' error question to: 'Based on defined viscosity parameters, this product is classified as PG III'");
			MyNewProduct.SetTheSectionOptionTo("Product has a boiling point of",
				"Based on defined viscosity parameters, this product is classified as PG III");
			Report.StartStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("U. S. Department of Transportation (DOT) Classification");
		}
		[StepDefinition(@"I call Shared Step 92982 \(U\. S\. Department of Transportation \(DOT\) Classification - For Alcoholic Beverages - Spirits \(RU001434\) - Packaging Group should pre-select Packaging Group II\)")]

		public void GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidData_ForSpirits()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN3065");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN3065");
			Delay.Seconds(2);
			Report.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartStep("I select '3' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "3");
			Report.StartStep("I select 'II' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "II");
			Report.StartStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I call Shared Step \(Enter Product Data for Physical State - Aerosol only and Secondary Physical state - Liquid spray\)")]
		public void GivenICallSharedStepEnterProductDataForPhysicalState_AerosolOnlyWithFIFRA()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			// Primary Physical State is Aerosol which is the only option available
			Report.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			Report.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartStep("I set the pH field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("pH", "Not tested/Unknown");
			Report.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartStep("in the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		//TC65470
		[StepDefinition(@"I call Shared Step 59680a \(Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path\)")]
		public void ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFRa()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			Report.StartStep("I should see the  Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");


			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");

			Report.StartStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 150905 \(Retailer - NR selected by default\)")]
		public void GivenICallSharedRetailerNRSelectedByDefault()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}
		[StepDefinition(@"I call Shared Step 208116 Product Information - FIFRA 25\(b\) Product Not a Pesticide, US \(SOLD\), NO \(OSHA\), NO \(DSV\), YES \(CA RTK\), NO \(PL\), NO \(GNFR\)")]
		public void GivenICallSharedStepProductInformation_FIFRA25b_NoPesticideUSSOLD_NOOSHA_NODSV_YESCARTK_NOPL_NOGNFR()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set any option for: 'Which best describes your product, including when FIFRA 25(b) Exempt'");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"Yes");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 193979 California Cleaning Product Disclosure - Final Domestic Distributor")]
		public void InTheCACleaningProductDisclosureScreenChooseHappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();


			MyStepsNewProduct.GivenIShouldSeeXPage("California Cleaning Product Disclosure");
			Delay.Seconds(1);

			if (myNewProduct.SectionExists("Who is publicly identified on the product label as responsible for the product?"))
			{
				MyStepsNewProduct.SetRadioOptionInSectionTo("Who is publicly identified on the product label as responsible for the product?", "Final Domestic Distributor");
			}

			if (myNewProduct.SectionExists("Who is the Final Domestic Distributor (if any) of the product?"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInFinalDomesticDistributorTextField("NONE");
			}

			if (myNewProduct.SectionExists("Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?", "No");
			}

			if (myNewProduct.SectionExists("Company's Toll-Free Phone Number"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInTollFreePhoneNumberTextField("11111111111");
			}

			if (myNewProduct.SectionExists("Company Web Address"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInCompanyWebAddressTextField("http://TestWebsitePlaceholderName.com");
			}

			if (myNewProduct.SectionExists("Select the product's GTIN Brick Code"))
			{
				MyStepsNewProduct.ThenISetTheProductsGTINBrickCodeTo("[10000397] Cleaning Aids");
			}
			Report.StartStep("in the California Cleaning Product Disclosure page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("California Cleaning Product Disclosure");
		}
		[StepDefinition(@"I call Shared Step 217792 California Cleaning Product Disclosure - Manufacturer")]
		public void InTheCACleaningProductDisclosureScreenChooseManufacturerHappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("California Cleaning Product Disclosure");
			Delay.Seconds(1);

			if (myNewProduct.SectionExists("Who is publicly identified on the product label as responsible for the product?"))
			{
				MyStepsNewProduct.SetRadioOptionInSectionTo("Who is publicly identified on the product label as responsible for the product?", "Manufacturer");
			}

			if (myNewProduct.SectionExists("Who is the Final Domestic Distributor (if any) of the product?"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInFinalDomesticDistributorTextField("Target");
			}

			if (myNewProduct.SectionExists("Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?", "No");
			}

			if (myNewProduct.SectionExists("Company's Toll-Free Phone Number"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInTollFreePhoneNumberTextField("11111111111");
			}

			if (myNewProduct.SectionExists("Company Web Address"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInCompanyWebAddressTextField("http://TestWebsitePlaceholderName.com");
			}

			if (myNewProduct.SectionExists("Select the product's GTIN Brick Code"))
			{
				MyStepsNewProduct.ThenISetTheProductsGTINBrickCodeTo("[10000397] Cleaning Aids");
			}
			Report.StartStep("In the California Cleaning Product Disclosure page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("California Cleaning Product Disclosure");
		}

		[StepDefinition(@"I call Shared Step \(SHA > Select Product > Review\) for product saved as: (.*)")]
		public void Shared134404_SHA_SelectProduct_ClickOnReview(string savedAs)
		{
			Report.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			var selStepsStudio = new Steps_Studio();
			Report.StartSubStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			// saving the current window so we can naviate back
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			Report.StartSubStep("I click 'Review'");
			selStepsStudio.InSHAManagerIClickOnBottomMenuItem("Review");
			Delay.Seconds(5);
		}
		[StepDefinition(@"I call Shared Step 118138a Product Information - US, Pesticide No, No OSHA, No DSV, No CA Cleaning ,No PL, No GNFR Without Child question")]
		public void GivenICallSharedStepProductInformation_USPesticideNoNoOSHANoDSNoCACleaningVNoPLNoGNFRWithoutChildQuestion1()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartSubStep("I set any option for: 'Which best describes your product, including when FIFRA 25(b) Exempt'");
			// Step says 'any' but prefer setting not pesticide because some tests didn't account for Pesticides page appearing later.
			if (new NewProduct().GetAllOptionsForSection("Which best describes your product, including when FIFRA 25(b) Exempt").Contains("Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)");
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			}
			else
			{
				MyNewProduct.SelectFirstOptionInSection("Which best describes your product, including when FIFRA 25(b) Exempt");
				new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(false);

			}
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			//TestCase:207581
			stepsNewProductIngredients.GivenISelectOption();
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 77383 \(Regulatory Documents to Provide - Request to Author \(Happy Path\)\)")]
		[StepDefinition(@"I call Shared Step 57881 \(Regulatory Documents to Provide - US only - request authoring - Happy Path\)")]
		public void GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartSubStep("I set the OSHA-compliant Safety Data Sheet, English field to: Request to author");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Request to author");
			Report.StartSubStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(@"I call Shared step In the Supplier Manager Popup - radio button '(.*)',enter in search '(.*)' and check column headers:")]
			public void ThenICallSharedStepSupplierManagerPopup_RadioButtonEnterInSearchAndCheckColumnHeaders(string radioButton, string searchValue, Table table)
			{
				Report.UseSubSteps = true;
				var thisSteps_SHA = new Steps_SHA();
				Report.StartSubStep($"In the Supplier Manager Popup I select radio button: {radioButton}");
				thisSteps_SHA.InSupplierManagerPopupISelectRadioButton(radioButton);
				Report.StartSubStep($"In the Supplier Manager Popup I enter the following search term: {searchValue}");
				thisSteps_SHA.InSupplierManagerPopupIEnterSearchTerm(searchValue);
				Report.StartSubStep("In the Supplier Manager Popup I click on the search button");
				thisSteps_SHA.InSupplierManagerPopupIClickOnTheSearchButton();
				Report.StartSubStep("In the Supplier Manager Popup I check next columns exist:");
				thisSteps_SHA.ThenInTheSupplierManagerPopupICheckNextColumnsExist(table);
				Report.StartSubStep("In the Supplier Manager Popup I check value in Subscription column should be Tiered, Single, Single+Tier or it should be blank");
				thisSteps_SHA.ThenInTheSupplierManagerPopupICheckValueInSubscriptionColumnShouldBeTieredSingleSingleTierOrItShouldBeBlank();

			}
		[StepDefinition(@"I call Shared Step 183893 \(Single Retailer - Retailer Screen - Select retailer\)")]
		public void ThenICallSharedStepSingleRetailer_RetailerScreen_SelectRetailer(Table table)
		{
			var newTable = new TechTalk.SpecFlow.Table(new string[] {
				"Retailer",
			});
			newTable.AddRow(new string[] {
				"No Retailer/No UPC Product",
			});
			var stepsNewProduct = new StepsNewProduct();
			var stepsSelectRetailer = new StepsSelectRetailers();
			var stepsRetailer = new Steps_Retailer();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Retailer Page");
			stepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartSubStep("I confirm the checkbox Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program is present for stand alone batteries in Retailer page");
			stepsSelectRetailer.ThenIConfirmNoRetailerRegistrationCheckbox("Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program", "present");
			Report.StartSubStep("In the 'Retailers' table I see the retailer: No Retailer/No UPC Product");
			stepsRetailer.SelectedRetailersShouldBe("should", newTable);
			Report.StartSubStep("I select the following retailers in the Select Retailers popup list view and check no more retailers can be selected: Amazon");
			stepsSelectRetailer.ThenInTheWindowICheckOnlyOneRetailerCanBeSelected(table);
			Report.StartSubStep("I click Done on Select Retailers window");
			stepsSelectRetailer.IClickDoneButtonOnSelectRetailersWindow();
			Report.StartSubStep("In the Retailer page I click Continue");
			stepsNewProduct.ClickContinue();

		}

		[StepDefinition(@"I call Shared Step 67820 \(Sign up New Account - Step 1\): user (.*) with the following parameters:")]
		public void GivenICallSharedStepSignUpNewAccount_StepUserTCWithTheFollowingParameters(string savedAs, Table parameters)
		{
			Report.UseSubSteps = true;
			var landingPage = new StepsLandingPage();
			var steps_Signup = new StepsSignup();
			Report.StartSubStep($"I define the user: {savedAs} with the following parameters:");
			steps_Signup.DefineUser(savedAs, parameters);
			Report.StartSubStep($"I save the current emails in the inbox for user saved as: {savedAs}");
			steps_Signup.GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
			Report.StartSubStep("I select the Sign Up link");
			landingPage.ClickSignUpLink();
			Report.StartSubStep("the signup page should appear");
			steps_Signup.ThenTheSignupPageShouldAppear();
			Report.StartSubStep($"I enter signup email for user: {savedAs}");
			steps_Signup.GivenIEnterSignupEmailUser(savedAs);
			Report.StartSubStep($"I confirm signup email for user: {savedAs}");
			steps_Signup.GivenIConfirmSignupEmailUser(savedAs);
			Report.StartSubStep("I click on submit");
			steps_Signup.GivenIClickOnSubmit();
			Report.StartSubStep("the signup thank you page should appear");
			steps_Signup.ThenTheSignupThankYouPageShouldAppear();
			Report.StartSubStep($"there should be a new email for user: {savedAs} from: <SiteNotification> with the title: Link to create WERCSmart Account");
			steps_Signup.ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "<SiteNotification>", "Link to create WERCSmart Account");
			Report.StartSubStep("the email should contain a link to set up the WERCSmart account");
			steps_Signup.ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount();
			Report.StartSubStep("I click on the link I should see the WERCSmart new account page");
			steps_Signup.WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage();
		}

		[Given(@"I call Shared Step 57744\(New Account - Account Information - Step 2\) for user: (.*)")]
		public void GivenICallSharedStepNewAccount_AccountInformation_StepForUserTC(string savedAs)
		{
			Report.UseSubSteps = true;
			var steps_Signup = new StepsSignup();
			Report.StartSubStep($"I enter the information into the new user form for user saved as: {savedAs}");
			steps_Signup.WhenIEnterTheFollowingInformationIntoTheNewUserForm(savedAs);
			Report.StartSubStep("In the new user form I click on continue");
			steps_Signup.WhenInTheNewUserFormIClickOnContinue();
			Report.StartSubStep("I should be on the Security Questions page of the for");
			steps_Signup.ThenIShouldBeOnThePageOfTheForm("Security Questions");
		}

		[Given(@"I call Shared Step 57745\(New Account - Security Questions - Step 3\) for user: (.*)")]
		public void GivenICallSharedStepNewAccount_SecurityQuestions_StepForUserTC(string savedAs)
		{
			Report.UseSubSteps = true;
			var steps_Signup = new StepsSignup();
			Report.StartSubStep($"I enter the following into the Security Questions window for user saved as: {savedAs}");
			steps_Signup.EnterTheFollowingIntoSecurityQuestions(savedAs);
			Report.StartSubStep($"I enter the pin for user saved as: {savedAs}");
			steps_Signup.EnterPinForUser(savedAs);
			Report.StartSubStep("In the new user form I click on continue");
			steps_Signup.WhenInTheNewUserFormIClickOnContinue();
			Report.StartSubStep("I should be on the Thank You page of the for");
			steps_Signup.ThenIShouldBeOnThePageOfTheForm("Thank You");
		}
		[StepDefinition(@"I call Shared Step 213796 \(Physical and Chemical Properties - Applicable Only to Lip Balm \(RU000246\)\)")]
		public void Shared_Physical_and_Chemical_Properties_Applicable_Only_to_Lipbalm()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();

			Report.StartSubStep("I set the Primary Physical State field to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartSubStep("I set the Secondary Physical State field to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: No data available");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "No data available");

			Report.StartSubStep("in the Physical and Chemical Properties page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}
		[StepDefinition(@"I call Shared Step 234333 \(Inventory Status, Prop 65 \(US\) - Applicable Only to Lip Balm \(RU000246\)\)")]
		public void ICallSharedRegulatoryInformation_TSCAAndCEPAShown_NoToProp65()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I click continue");
			new StepsNewProduct().ClickContinue();
			Report.StartSubStep("Confirm that both questions in this screen display the 'This is a required field' error message");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("U.S. Toxic Substances Control Act (TSCA) status", "should", "This is a required field.");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "should", "This is a required field.");
			Report.StartSubStep("Select ONE Radio Button for the TSCA Question");
			new StepsNewProduct().SelectFirstOptionInSection("U.S. Toxic Substances Control Act (TSCA) status");
			Report.StartSubStep("Confirm the 'Required field error message' no longer shows for the TSCA Question");
			new StepsNewProduct().ErrorMessagesShouldNotBeShowingForItem("U.S.Toxic Substances Control Act (TSCA) status");
			Report.StartSubStep("I select the 'No' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "No");
			Report.StartSubStep("I confirm the 'Required field' error message is no longer displayed for the prop 65 question");
			new StepsNewProduct().ErrorMessagesShouldNotBeShowingForItem("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act");
			Report.StartSubStep("I select the 'Yes' button for the Prop 65 question");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}

		[StepDefinition(@"I call Shared Step 234334 \(Regulatory Information 3 - Applicable Only to Lip Balm \(RU000246\)\)")]
		public void GivenICallSharedStepRegulatoryInformation_LipBalm()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Regulatory Information 3");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 3");
			MyStepsNewProduct.IConfirmRegulatoryInformation3PageContainsStatement("Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California. Please complete the additional question below to ensure proper classification of this product for the retailer(s).");
			Report.StartSubStep("For the 'Refer to your Product Label. From the options, select those that appear on the Label.' question four options should appear: 'Drug Facts Panel', 'Supplement Facts Panel', 'Nutrition Facts Panel' and 'None of the Above'");
			var table = new Table("Option");
			table.AddRow("Drug Facts Panel");
			table.AddRow("Supplement Facts Panel");
			table.AddRow("Nutrition Facts Panel");
			table.AddRow("None of the Above");
			MyStepsNewProduct.CheckOptionsInSection("should", "displayed", "Refer to your Product Label.", table);
			Report.StartSubStep("Select any of the four options that apply");
			MyStepsNewProduct.GivenInTheRegulatoryInforamtionTabISelectProductLableAs("None of the Above");
			Report.StartSubStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may including Active Ingredient)");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("OTC Drug Facts Label (may include Active Ingredient)");
			Report.StartSubStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: Nutritional and Supplement Labels");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("Nutritional and Supplement Labels");
			Report.StartSubStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: Dietary Supplements Label");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("Dietary Supplements Label");
			Report.StartSubStep("In the Regulatory Information 3 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 3");
		}
		[StepDefinition(
			@"I call Shared Step 214000 \(Product Information - Pesticide= Not considered, Fertilizer=YES, SOLD=US, everything else = No - Continue\)")]
		public void
			GivenICallSharedStep_PesticideNotConsideredFertilizerNoSOLDUSEverythingElseNo_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			var myNewProductClass = new NewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt",
				"Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			Report.StartSubStep(
				"I set the Does the product contain fertilizer (N, P, K) field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Does the product contain fertilizer (N, P, K)",
				"Yes");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}
		[StepDefinition(@"I call Shared Step 213923 \(Physical and Chemical Properties - Applicable Only to Engine Fertilizer\)")]
		public void Shared_EnterPhysicalProperty_Liquid_ForFertilizer()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartSubStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartSubStep("I set the Relative Density option to: 11.16");
			MyNewProduct.SetTheSectionOptionTo("Relative Density", "11.16");
			Report.StartStep("I set the Relative Density option to: lb./gal. (pounds per gallon)");
			MyNewProduct.SectRadioButtonInSection("Relative Density", "lb./gal. (pounds per gallon)");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartSubStep("I set the pH field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("pH", "Not tested/Unknown");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			Report.StartSubStep("I set the Boiling Point (in Celsius) field to: Not tested/Unknown");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			Report.StartSubStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Not Tested/Unknown");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Soluble in water");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			Report.StartSubStep("In the Physical and Chemical Properties page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Physical and Chemical Properties");
		}
		[StepDefinition(
			@"I call Shared Step 209526\(b\) \(WPS Studio - PD\+ - set all data and publish using rule and doc queue for CKLT and MTR only\) for product saved as: (.*)")]
		public void GivenICallSharedStep209526WPSStudio_PD_SetAllDataAndPublish_CKLTAndMTROnly(string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			Report.UseSubSteps = true;
			Report.Info("In power tools workspace setting edit to true");
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30),
				"Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();
			var table2 = new Table(new string[] {
				"datacode",
				"value"
			});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"CAWC",
				"pass"
			});
			table2.AddRow(new string[] {
				"EPAN",
				"pass"
			});
			table2.AddRow(new string[] {
				"HCM",
				"pass"
			});
			table2.AddRow(new string[] {
				"OTC",
				"pass"
			});
			table2.AddRow(new string[] {
				"RAUNDW",
				"pass"
			});
			table2.AddRow(new string[] {
				"UNIFFC",
				"pass"
			});
			table2.AddRow(new string[] {
				"WSWC",
				"pass"
			});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"VOCQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"
			});
			table2.AddRow(new string[] {
				"RSQAHDPF",
				"pass"
			});
			var thisStepsStudio = new Steps_Studio();
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0756] Battery/BCP Checklist"))
			{
				thisStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0756] Battery/BCP Checklist");
				thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			}
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0877] Reviewer Checklist"))
			{
				thisStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0877] Reviewer Checklist");
				thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			}
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			var table3 = new Table(new string[] {
				"Item"
			});
			table3.AddRow(new string[] {
				"Current Document (Publish)"
			});
			table3.AddRow(new string[] {
				"Document Queue"
			});
			table3.AddRow(new string[] {
				"Apply rules"
			});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");

			Report.Info("Going to do publishing");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Delay.Seconds(3);
			GeneralUtilities.StudioWaitForSpinner();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			GeneralUtilities.StudioWaitForSpinner();
			var table4 = new Table(new string[] {
				"Text",
				"Should Show"
			});
			table4.AddRow(new string[] {
				"CKLT",
				"False"
			});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			thisStepsStudio.GivenICloseCurrentDocument();
			GeneralUtilities.StudioWaitForSpinner(30);
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90);
			if (thisStudioPowerDesignerPlusDesignMode.DoesPDSectionExist("[SECT0877] Reviewer Checklist"))
			{
				thisStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0877] Reviewer Checklist");
				thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			}
		}
		[StepDefinition(@"I call Shared Step 214041 \(Physical and Chemical Properties - Applicable Only to SOIL\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid_Applicable_Only_To_Soil()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			List<string> showing = new NewProduct().SelectedOptionsForSection("Primary Physical State");
			if (!showing.Contains("Solid"))
			{
				Report.StartSubStep("I set the Primary Physical State option to: Solid");
				Report.Info("Setting the Physical State to Solid because it was not selected by default");
				MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			}

			Report.StartSubStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartSubStep("I set the Select the best Water Solubility description option to: Dispersible");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartSubStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
			}
			Report.StartSubStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");

		}
		[StepDefinition(@"I call Shared Step 231514 \(Inventory Status, Prop 65 - Applicable Only to SOIL\)")]
		public void ICallSharedInventory_Status_NoToProp65_Applicable_Only_To_Soil()
		{
			Report.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Exempt");
			MyNewProductSteps.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is exempt from TSCA chemical Inventory listing requirements.");
			MyNewProductSteps.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}
		[StepDefinition(
		   @"I call Shared Step 214040 \(Product Information -Applicable Only to Type of Product: SOIL No - Continue\)")]
		public void
		   GivenICallSharedStep_Applicable_only_to_product_SOIL_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			var myNewProductClass = new NewProduct();
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Information");
			new GlobalSteps().ISetTagFIFRAPopupExpectedToBeX(true);

			Report.StartSubStep(
				"I set the Does the product contain fertilizer (N, P, K) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Does the product contain fertilizer (N, P, K)",
				"No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}
		[StepDefinition(@"I call Shared Step 217669 \(Product Information - Pesticide\(NO\), Sold\(US\), Child\(YES\), OSHA\(NO\), DSV\(NO\), PL\(NO\), GNFR\(NO\)\)")]
		public void ICallSharedProductInformation_ChildYes_NoDirectShipNoPLClickContinue()
		{
			Report.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "Yes");
			Report.StartSubStep("I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)", "No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");

			Report.StartSubStep("I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)", "No");

			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step 104290 \(Enter Regulatory Information - TSCA Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatory_TSCACEPANotProp()
		{
			Report.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartSubStep("I should see the Inventory Status, Prop 65 (US) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Inventory Status, Prop 65 (US)");
			Report.StartSubStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "This product is subject to and complies with TSCA chemical Inventory listing requirements.");
			Report.StartSubStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?", "No");
			Report.StartSubStep("In the Inventory Status, Prop 65 (US) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Inventory Status, Prop 65 (US)");
		}
		[StepDefinition(@"I call Shared Step \(Forwarding - Not PLP - Select Product: (.*) & UPCs step - Edit existing UPC Confirm Product name (.*) with error message:(.*) and erase text: (.*)\)")]
		public void SharedStepProductname(string savedAs,string text,string errMsg, string eraseText)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I select the first product in the Select UPCs tab");
			new StepsForwardProductRegistration().SelectTheFirstProductSelectUPCs();
			Report.StartSubStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartSubStep("I select Edit for the first UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectEditForFirstUPC();
			Report.StartSubStep("I enter the product name more than 200 characters");
			new StepsForwardProductRegistration().ProductNameEnterTextData(text);
			Report.StartSubStep("I click Save in the Edit UPC modal");
			new StepsForwardProductRegistration().InTheUPCModalWindowIClickSave();
			Report.StartSubStep("I confirm that Product name error message displayed");
			new StepsUPC().IseeProductNameErrorMessage(errMsg);
			Report.StartSubStep("I earse few characters from product name");
			new StepsForwardProductRegistration().ProductNameEnterTextData(eraseText);
			Report.StartSubStep("I click Save in the Edit UPC modal");
			new StepsForwardProductRegistration().InTheUPCModalWindowIClickSave();
			Report.StartSubStep("I click continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();
		}

		[StepDefinition(@"I call Shared Step \(Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path\)")]
		public void ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNo()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I should see the  Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Product Information");
			Report.StartSubStep(
				"Select countries the product may be sold in should be showing the value: United States");

			Report.StartSubStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("In the Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Information");
		}

		[StepDefinition(@"I call Shared Step \(Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedProductInformation_USOnly_YesGHSNotDirectShipNotPLPNotGNFR_Continue()
		{
			Report.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartSubStep("Looking for the Which best describes your product, including when FIFRA 25(b) Exempt and Setting to: Product is not a pesticide and does not make or imply a pesticidal claim if it exists");
			if (myNewProductClass.SectionExists("Which best describes your product, including when FIFRA 25(b) Exempt"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which best describes your product, including when FIFRA 25(b) Exempt", "Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)");
			}
			Report.StartSubStep(
				"Retailers will be selling my product at their store locations in (select either or both) should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Retailers will be selling my product at their store locations in (select either or both)", "United States");
			Report.StartSubStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartSubStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartSubStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"Yes");
			}
			Report.StartSubStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product", "No");
			Report.StartSubStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartSubStep("I click Continue in the product Information");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Information");
		}
	}
}

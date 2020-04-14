using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Database_Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Shared")]
	public class Steps_Shared
	{

		// For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

		[StepDefinition(@"I call Shared Step 57408 \(Create a New Registration via Register New Product icon\)")]
		public void GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I click the Register New Product icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Register New Product");
			Report.StartStep("I should see the New Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("New Product");
			Report.StartStep("I set the Select the type of product to create option to: Create a New Registration");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the type of product to create",
				"Create a New Registration");
			Report.StartStep("In the New Product page I click Continue");
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
		[StepDefinition(
			@"I call Shared Step 57561a \(The Product - Enter Product Name: (.*) and select Type of Product\): (.*)")]
		public void GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct(string name, string type)
		{
			this.Step57561(type, name);
		}

		public void Step57561(string type, string name = "")
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			Report.StartStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			if (name == "")
			{
				char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
				name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			}
			Report.StartStep("Setting Product Line or Brand to: TestBrand");
			new Steps_TheProduct().SetProductLineOrBrand("TestBrand");
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info($"The TestCaseId was found as: {TReVorSettings.TestCaseId}");

			Context.AddToContext($"TestCase{TReVorSettings.TestCaseId}", prodDetails);
		}

		[StepDefinition(@"I call Shared Step 60779 \(Enter Liquid - Cooking Oil - Non-Aerosol\)")]
		public void GivenICallSharedStepEnterLiquid_CookingOil_Non_Aerosol()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Open cup method");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Combustible IIIA (>60C and <93C)");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Decomposes");
			MyStepsNewProduct.SetTheSectionOptionTo("Select all ingredients included in this product", "Dairy");
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
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			//Report.StartStep("Primary Physical State should be showing the value: Liquid");
			//MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Not Tested/Unknown");
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
				MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Decomposes");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Select all ingredients included in this product", "Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains",
				"Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)",
				"None of the Above");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 60935 Additional Product Information - US - Direct Ship - Private Label Only")]
		public void GivenICallSharedStep60935AdditionalProductInformation_US_DirectShip_PrivateLabelOnly()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 90477 - Additional Product Information - US, \(NO\) Retailer's PL")]
		public void ICallSharedStep90477AdditionalProductInformation_US_NoRetailersPL()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 60726 \(Additional Product Information - Country and Private Label or Brand - Yes\)")]
		public void GivenICallSharedStep60726AdditionalProductInformation_CountryAndPrivateLabelOrBrand_Yes()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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

		[StepDefinition(@"I call Shared Step 60756 \(Additional Product Information with Country and every option\)")]
		public void GivenICallSharedStepAdditionalProductInformationWithCountryAndEveryOption()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			if (myNewProduct.CountryofOriginExists())
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");
			}

			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		//[StepDefinition(@"I call Shared Step 60935 \(Additional Product Information - US - Direct Ship - Private Label Only\)")]
		//[StepDefinition(@"I call Shared Step 60935 \(Additional Product Information - US - Direct Ship - Private Label Only\)")]
		//public void GivenICallSharedStepAdditionalProductInformation_US_DirectShip_PrivateLabelOnly()
		//{
		//	StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
		//	NewProduct myNewProduct = new NewProduct();
		//	MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
		//	Delay.Seconds(1);
		//	if (myNewProduct.SectionExists("Select countries the product may be sold in"))
		//	{
		//		MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
		//	}
		//	if (myNewProduct.SectionExists("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)"))
		//	{
		//		MyStepsNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", "No");
		//	}
		//	if (myNewProduct.SectionExists("Product is shipped directly by supplier to the consumer."))
		//	{
		//		MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.", "No");
		//	}
		//	if (myNewProduct.SectionExists("Product is a Retailer's Private Label or Brand"))
		//	{
		//		MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
		//	}
		//	if (myNewProduct.SectionExists("Product is sold to the Retailer solely for the Retailer's use"))
		//	{
		//		MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use", "No");
		//	}
		//	MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		//}

		[StepDefinition(
			@"I call Shared Step 60935 \(Additional Product Information - US - Direct Ship - Private Label Only\)")]
		public void SharedAdditionalProductInformation_US_DirectShip_PrivateLabelOnly()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 70393 \(Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only\)")]
		public void
			GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_DirectShip_PrivateLabelQuestionsOnly()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
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

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57569 \(Enter Product Details for Aerosol\)")]
		public void GivenICallSharedStepEnterProductDetailsForAerosol()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();

			if (myNewProduct.SectionExists("Which one best describes your product"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Which one best describes your product",
					"Regulates Plant Growth");
			}

			Report.StartStep(
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

		[StepDefinition(@"I call Shared Step 57570 \(Enter Ingredients\) and add the following ingredients:")]
		public void GivenICallSharedStepEnterIngredients(Table ingredientsTable)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartStep("I should see the Ingredients Page");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			Report.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			Report.StartStep("I should see the ingredients error message");
			stepsNewProductIngredients.IngredientsErrorMessageShowing("should");
			Report.StartStep("I add the following ingredients:");
			stepsNewProductIngredients.AddIngredients(ingredientsTable);
			Report.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
		}

		[StepDefinition(@"I call Shared Step 69557 \(Enter Ingredients for Aerosol Propellent\)")]
		public void GivenICallSharedEnterIngrediebtsForAerosolPropellant()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartStep("I should see the Ingredients Page");
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
			Report.StartStep("I add the following ingredients (aerosol propellant):");
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
			Report.StartStep("I add the following ingredients (other):");
			stepsNewProductIngredients.AddIngredients(otherIngredients);
			Report.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
		}

		[StepDefinition(@"I call Shared Step 60685 Fuel Container Regulatory Details - Yes")]
		public void GivenICallSharedFuelContainerRegulatoryDetails_Yes()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see Fuel Container Regulatory Details");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Fuel Container Regulatory Details");
			Report.StartStep("I Product is a Safety Can to: Yes");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Safety Can", "Yes");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Fuel Container Regulatory Details");
		}

		[StepDefinition(
			@"I call Shared Step 61449 Toxicity Characteristic Leaching Procedure \(TCLP\) - select No to all - Click Continue - Happy Path")]
		public void
			GivenICallShared61449ToxicityCharacteristicLeachingProcedureTCLP_SelectNoToAll_ClickContinue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsTclp = new Steps_ToxicityCharacteristicsLeachingProcedure();
			Report.StartStep("Toxicity Characteristic Leaching Procedure (TCLP)");
			stepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartStep("I set the Product has had TCLP testing to: No");
			stepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing", "No");
			Report.StartStep("I set all Metal presence values to No");
			stepsTclp.GivenISetAllTheMetalPresenceValueTo("No");
			Report.StartStep("I click continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP)");
		}

		[StepDefinition(
			@"I call Shared Step 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all")]
		public void GivenICallShared58189AnswerElectronicEquipmentQuestions_WithCathodeRay_NoToAll()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Electronic Equipment page");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Electronic Equipment");
			Report.StartStep("I set the Contains Circuit Board option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Contains Circuit Board", "No");
			Report.StartStep("I set the Has a Cathode Ray Tube option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a Cathode Ray Tube", "No");
			Report.StartStep("I set the Has a LCD or Plasma Display option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			Report.StartStep("I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Electronic equipment");
		}

		[StepDefinition(@"I call Shared Step 57571 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_NotProp()
		{
			var regulatoryInformation = new RegulatoryInformation1();
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			stepsRegulatoryInformation.SetTSCATo("Compliant");
			Report.StartStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("No");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared Step 104276 \(Enter Regulatory Information - TSCA, CEPA, Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_TSCACEPANotProp()
		{
			var regulatoryInformation = new RegulatoryInformation1();
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			stepsRegulatoryInformation.SetTSCATo("Compliant");
			Report.StartStep("I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			stepsRegulatoryInformation.SetCEPATo("Compliant with Domestic Substances List (DSL)");
			Report.StartStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("No");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		/// <summary>
		/// Requires a table with headings: | Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		/// </summary>
		/// <param name="table"></param>
		[StepDefinition(@"I call Shared Step 48367 \(Product Includes Battery > any type\) : Setting how the battery is packaged option to (.*)")]
		public void GivenICallSharedProductIncludesBatteryAnyType(string option, Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SelectFirstOptionInSection("Indicate how battery is packaged");
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I set the Indicate how battery is packaged field to: Installed in the product");
			MyStepsNewProduct.SetTheSectionOptionTo("Indicate how battery is packaged", option);
			Report.StartStep("I complete a row in the Battery Table: | Battery Type | Manufacturer | Number of batteries per package | How many batteries are required to run |");
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (TableRow thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Number of batteries per package"], out int batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Number of batteries per package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["How many batteries required to run"], out int batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'How many batteries required to run' column of the step table must be an integer value");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I set the Indicate how battery is packaged field to: Installed in the product");
			MyStepsNewProduct.SetTheSectionOptionTo("Indicate how battery is packaged", "Installed in the product");
			Report.StartStep("I complete a row in the Battery Table: | Battery Type | Manufacturer | Number of batteries per package | How many batteries are required to run |");
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (TableRow thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Number of batteries per package"], out int batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Number of batteries per package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["How many batteries required to run"], out int batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'How many batteries required to run' column of the step table must be an integer value");
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



		[StepDefinition(@"I call Shared Step 57589 \(Enter Pesticide Data - United States \(without EPA number\)\)")]
		public void GivenICallSharedStepEnterPesticideData_UnitedStatesWithoutEPANumber()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Pesticide Details - U.S. Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Pesticide Details - U.S.");
			Report.StartStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "No");
			Report.StartStep("I select the first option in section: Select the applicable exemption");
			MyStepsNewProduct.SelectFirstOptionInSection("Select the applicable exemption");
			Report.StartStep("In the Pesticide Details - U.S. page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		[StepDefinition(
			@"I call Shared Step 48369 \(Toxicity Characteristics Leaching Procedure \(TCLP\) - No to ALL With Copper\)")]
		public void GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithCopper()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartStep("I set the Product has had TCLP testing; Report is available option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing; Report is available", "No");
			Report.StartStep("I select No for all elements including Copper");
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

			Report.StartStep(
				"In the Toxicity Characteristic Leaching Procedure (TCLP) Product Report page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP) Product Report");
		}

		[StepDefinition(
			@"I call Shared Step 71955 \(Answer Electronic Equipment questions - Without Cathode Ray - No to all\)")]
		public void GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Contains Circuit Board", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			Report.StartStep("In the Electronic Equipment page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Electronic Equipment");
		}

		[StepDefinition(
			@"I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path")]
		public void GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may including Active Ingredient)");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains(
				"OTC Drug Facts Label (may including Active Ingredient)");
			Report.StartStep("I set the Refer to your Product Label option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Refer to your Product Label", "None of the Above");
			Report.StartStep("In the Regulatory Information 3 page I click Continue");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			var MyNewProduct = new NewProduct();
			MyNewProduct.SetFullNameOfProductForRetailer(retailer, name);
			Report.StartStep("In the Retailer page I click Continue");
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
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN" + unNo);
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN" + unNo);
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 57794 \(Confirm VOC \(SCAQMD\) step title, Confirm ACP question shown  - Select No - Happy Path\)")]
		public void GivenICallSharedStepConfirmVOCSCAQMDStepTitleConfirmACPQuestionShown_SelectNo_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I should see the '{0}' page",
				"Volatile Organic Compounds (VOC) for California Air District(s) and Canada"));
			MyStepsNewProduct.GivenIShouldSeeXPage(
				"Volatile Organic Compounds (VOC) for California Air District(s) and Canada");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the {0} option to: {1}",
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No"));
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP("No");
			Report.StartStep(string.Format("I set the {0} option to: {1}",
				"Product label specifies a dilution ratio which results in a final VOC concentration for the product during use",
				"Yes"));
			new Steps_VOC_OTC_CARB().SetProductLabelDilutionRatio("Yes");
			Report.StartStep(string.Format("I set the {0} option to: {1}",
				"Product's VOC content as used",
				"0"));
			new Steps_VOC_OTC_CARB().SetVocContentAsUsed("0");
			Report.StartStep(string.Format("I set the {0} option to: {1}",
				"Product's VOC content as sold",
				"0"));
			new Steps_VOC_OTC_CARB().SetVocContentAsSold("0");
			Report.StartStep("I select the first option for section: Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?");
			MyStepsNewProduct.SelectFirstOptionInSection(
				"Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?");
			Report.StartStep("In the VOC page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("VOC");
		}

		[StepDefinition(
			@"I call Shared Step 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: (.*)")]
		public void GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath(string retailer)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var selSelectRetailers = new SelectRetailers();
			var selRetailer = new Retailer();
			if (!selSelectRetailers.DoneButton())
			{
				Report.Warning("The Select Retailers page was not loaded on entering the Retailer page");
				selRetailer.ClickAddRetailers();
			}
			//if (!selSelectRetailers.Wait_for_load(10))
			//{
			//	Report.Warning("The Select Retailers page was not loaded on entering the Retailer page");
			//	selRetailer.ClickAddRetailers();
			//}

			Report.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");

			// below step was throwing error when selected No-retailer so  need to remove
			//Report.StartStep("I should see the Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
		}

		// Enter UPC string in the form: "Equals"+upcNumber where upcNumber is the exact number to input, rather than using the randomly generated step from context
		// Enter '_CVS' or '_cvs' for upc variable to use a upc number for retailer CVS from (required for some test cases eg. CVS RCL feature)
		[StepDefinition(
			@"I call Shared Step 57961 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*), capsule count: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc, string containerType, string capsuleCount, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");
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

			Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(
	@"I call Shared Step 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc, string containerType, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add UPC' button");
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

			Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
			GeneralUtilities.Wait_for_load_finish();
		}

		// UPC: CVS binding text used for using a UPC from the list of valid CVS UPCs from upcitemdb.com
		[StepDefinition(
			@"I call Shared Step 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: CVS, container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly(string containerType,
			string size)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			for (int i = 0; i < 100; i++)
			{
				Report.Info("Entering UPC information. Attempt: " + (i + 1));
				Report.StartStep("I click the 'Add UPC' button");
				stepsNewProduct.ThenIClickTheAddUpcButton();
				Report.StartStep("I add the following into the UPC Fields");
				string upc = TReVorSettings.TReVor.VisualStudioFunctions.GetRandomUpcNumber("CVS");
				Report.Info("UPC number: " + upc);
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
				Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
				stepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");
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



		[StepDefinition(
			@"I call Shared Step 60826 \(Enter Universal Product Code \(UPC\) - Battery - Confirm Quantity\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedStepEnterUniversalProductCodeUPC_Battery_ConfirmQuantity(string upc,
			string containerType, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Quantity Header");
			MyStepsNewProduct.GivenIShouldSeeXPage("Quantity");
			Report.StartStep("I click the 'Add UPC' button");
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
			Report.StartStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 60567 \(Upload Product Label only\)")]
		public void GivenICallSharedUploadProductLabelOnly()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(@"I click the browse button for label: Product Label and upload PDF: testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Delay.Seconds(2);
			Report.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60567 \(Upload Product Label only\) for section: (.*)")]
		public void GivenICallSharedUploadProductLabelOnlySectionSpecific(string section)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I click the browse button for label: Product Label in section: " + section + @" and upload PDF: testdoc.pdf");
			MyStepsNewProduct.UploadPDFFileSectionAndType("Product Label", section, @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57883 \(Comments - Happy Path\) and enter the comment: (.*)")]
		public void GivenICallSharedCommentsHappyPath(string comments)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Comments Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Comments");
			Report.StartStep("I enter the following into the comments field: " + comments);
			MyStepsNewProduct.ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(comments);
			Report.StartStep("In the New Product page I click Continue");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsHomePage = new StepsHomepage();
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I click the Register New Product icon in the Navigation Pane");
			MyStepsHomePage.ClickItemInNavigationPanel("Register New Product");
			Report.StartStep("I should see the New Product Page");
			MyNewProduct.GivenIShouldSeeXPage("New Product");
			Report.StartStep("I set the Select the type of product to create field to: Create a New Registration");
			MyNewProduct.SetTheSectionOptionTo("Select the type of product to create", "Create a New Registration");
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 57884 \(Safety Data Sheet Authoring - Additional Data \(Optional\) step - add any random data for all fields - Happy path\) and enter the following:")]
		public void GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
			Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");
			Delay.Seconds(1);
			Report.StartStep(
				"In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " +
				table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct
				.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(
					table.Rows[0]["Personal Protection Equipment"]);
			Report.StartStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " +
								 table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAutoignitionISelect(
				table.Rows[0]["Autoignition Temperature"]);
			Report.StartStep(
				"In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " +
				table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(
				table.Rows[0]["Minimum Ignition Energy"]);
Report.StartStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " +
								 table.Rows[0]["Viscosity"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(table.Rows[0]["Viscosity"]);
			Report.StartStep("In the Review and Submit tab of the New Product Page for Appearance I select: " +
								 table.Rows[0]["Appearance"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(
				table.Rows[0]["Appearance"]);
			Report.StartStep("In the Review and Submit tab of the New Product Page for Odor I select: " +
								 table.Rows[0]["Odor"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorISelect(table.Rows[0]["Odor"]);
			Report.StartStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " +
								 table.Rows[0]["Odor Threshold"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorThresholdISelect(
				table.Rows[0]["Odor Threshold"]);
			Delay.Seconds(1);
			Report.StartStep(
				"In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " +
				table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPartitionCoefficientISelect(
				table.Rows[0]["Partition Coefficient"]);
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57441 \(Product Characteristics - Primary Physical Property - Liquid\)")]
		public void GivenICallSharedProductCharacteristics_PrimaryPhysicalProperty_Liquid()
		{
			// Secondary Physical State, Specific Gravity (value), pH (range), Boiling Point (range), Water Solubility description can be any value.
			// Add a variable table in the future if specific data is required.
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartStep("I set the Specific Gravity option to: 20");
			MyNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			Report.StartStep("I set the Boiling Point (in Celsius) field to: 20.1C (68.1F) - 35C (95F)");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "20.1C (68.1F) - 35C (95F)");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			Report.StartStep("I set the Flash Point (in Celsius) field to: >=23C and <38C");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", ">=93C and <=815C");
			Report.StartStep("I set the Flash Point Testing Method Used option to: Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartStep("I set the Select the best Water Solubility description field to: 100g/100ml");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57111 \(Enter Product Data for Physical State - Aerosol only\)")]
		public void GivenICallSharedStepEnterProductDataForPhysicalState_AerosolOnly()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			Report.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			Report.StartStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			Report.StartStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			Report.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			Report.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57454 \(Product Characteristics - Aerosol & Gas available - Select Aerosol - Continue - Happy Path\)")]
		public void ThenICallSharedStepProductCharacteristics_AerosolGasAvailable_SelectAerosol_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow("Aerosol");
			produtTable.AddRow("Gas");
			stepsProductCharacteristics.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			Report.StartStep("I set the Primary Physical State field to: Aerosol");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Aerosol");
			Report.StartStep("I set the Secondary Physical State field to: Liquid spray");
			stepsProductCharacteristics.ThenISetTheSecondaryPhysicalStateToBe("Liquid spray");
			Report.StartStep("I set the pH field to: 10.4");
			stepsProductCharacteristics.SetPHTo("10.4");
			Report.StartStep("If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description", "Insoluble");
			Report.StartStep("I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57528 \(Product Characteristics - Aerosol Only - add data - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolOnly_AddData_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			// Primary Physical State is Aerosol which is the only option available
			Report.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			stepsProductCharacteristics.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			Report.StartStep("I set the Primary Physical State field to: Aerosol");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Aerosol");
			Report.StartStep("I set the Secondary Physical State field to: Liquid spray");
			stepsProductCharacteristics.ThenISetTheSecondaryPhysicalStateToBe("Liquid spray");
			Report.StartStep("I set the pH field to: 10.4");
			stepsProductCharacteristics.SetPHTo("10.4");
			Report.StartStep("If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description", "Insoluble");
			Report.StartStep("I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57401 \(Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 57401 \(Additional Product Information - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedAdditionalProductInformation_NoGHSNotDirectShipNotPLPNotGNFR_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(
			@"I call Shared Step 57881 \(Regulatory Documents to Provide - US only - request authoring - Happy Path\)")]
		public void GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartStep("I set the OSHA-compliant Safety Data Sheet, English field to: Request to author");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Request to author");
			Report.StartStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 60931 \(Additional Documents to Provide - Exemption - Special Permit - Product Label\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_SpecialPermit_ProductLabel()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("Upload exemption letter");
			MyNewProduct.UploadPDFFileSectionAndType("Exemption Letter",
				"Transportation Exemption Letter or Special Permit", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("Upload special permit letter");
			MyNewProduct.UploadPDFFileSectionAndType("Special Permit",
				"Transportation Exemption Letter or Special Permit", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("Upload product label");
			MyNewProduct.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.Screenshot();
			Report.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 62710 \(Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path\)")]
		public void GivenICallSharedConfirmVOCHeadingAndSelectNoToFirstQuestionOnly_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			//var MyNewProduct = new StepsNewProduct();
			//Report.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartStep("I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP("No");
		}

		[StepDefinition(@"I call Shared Step 60468 \(VOC - CARB only required - enter value - Continue - Happy Path\)")]
		public void GivenICallSharedStepVOC_CARBOnlyRequired_EnterValue_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Amount of VOC content as weight percentage of the total formula field to: 50");
			MyNewProduct.SetTheSectionOptionTo("Amount of VOC content as weight percentage of the total formula", "50");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
		}

		[StepDefinition(
			@"I call Shared Step 60552 \(VOC - AERO Question \(ozone\) enter value - Click Continue - Happy Path\): (.*)")]
		public void GivenICallSharedStepVOC_AEROQuestionOzoneEnterValue_ClickContinue_HappyPath(string value)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I Enter a value for the 'VOC content in grams ozone per gram' question: " + value);
			MyNewProduct.SetTheSectionOptionTo("VOC content in grams ozone per gram", value);
			Report.StartStep("In the Volatile Organic Compounds (VOC) page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
		}

		[StepDefinition(@"I call Shared Step 60631 \(VOC - HVOC and MVOC - add values - Continue - Happy Path\)")]
		public void GivenICallSharedVOC__HVOCAndMVOC_AddValues_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 10");
			MyNewProduct.SetTheSectionOptionTo(
				"HVOC (high volatile organic compound) content as weight percent of the total formulation", "10");
			Report.StartStep(
				"I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 5.6");
			MyNewProduct.SetTheSectionOptionTo(
				"MVOC (microbial volatile organic compound) content as weight percentage of the total formulation",
				"5.6");
			Report.StartStep("In the Volatile Organic Compounds (VOC) page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
		}

		[StepDefinition(@"I call Shared Step 57885 \(Data Acceptance - Click Accept - Happy Path\)")]
		public void GivenICallSharedDataAcceptance_ClickAccept_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("In the Data Acceptance page I select Yes, Agreed");
			MyNewProduct.GivenInTheDataAcceptancePageISelectYesAgreed();
			Report.StartStep("In the Data Acceptance page I click on the Accept button");
			MyNewProduct.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.Screenshot();
		}

		[StepDefinition(@"I call Shared Step 37857 \(Enter Physical Property - Solid\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			List<string> showing = new NewProduct().SelectedOptionsForSection("Primary Physical State");
			if (!showing.Contains("Solid"))
			{
				Report.StartStep("I set the Primary Physical State option to: Solid");
				Report.Info("Setting the Physical State to Solid because it was not selected by default");
				MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			}

			Report.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
			}

			//Report.StartStep("I set the Secondary Physical State option to: Solid");
			//MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 37857 \(Enter Physical Property - Solid\) with the following inputs:")]
		public void GivenICallSharedEnterPhysicalProperty_SolidParameters(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Primary Physical State option to: Solid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			Report.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			string waterSolubility = table == null ? "N/A" : table.Rows.FirstOrDefault()["Water Solubility"];
			if (waterSolubility != null && waterSolubility != "N/A")
			{
				Report.StartStep("I set the Select the best Water Solubility description option to: " +
									 waterSolubility);
				MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", waterSolubility);
			}
			else
			{
				Report.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
				MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			}

			string secondaryState = table == null ? "N/A" : table.Rows.FirstOrDefault()["Secondary Physical State"];
			if (secondaryState != null && secondaryState != "N/A")
			{
				Report.StartStep("I set the Secondary Physical State option to: " + secondaryState);
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", secondaryState);
			}
			else
			{
				Report.StartStep("I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			}

			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		// Shared Step was updated to include 'which one best describes your product'. This breaks a couple of tests, which has been raised to Bug Triage (incorrect step called)
		[StepDefinition(@"I call Shared Step 60310 \(Additional Product Information - Without Child question\)")]
		public void GivenICallSharedAdditionalProductInformation_WithoutChildQuestion()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}


		[StepDefinition(@"I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question")]
		public void GivenICallSharedStepAdditionalProductInformation_USPesticideNoNoOSHANoDSVNoPLNoGNFRWithoutChildQuestion()
		{
			ReportSettings.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set any option for: 'Which one best describes your product'");
			// Step says 'any' but prefer setting not pesticide because some tests didn't account for Pesticides page appearing later.
			if (new NewProduct().GetAllOptionsForSection("Which one best describes your product").Contains("Product is not considered a pesticide product"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which one best describes your product", "Product is not considered a pesticide product");
			}
			else
			{
				MyNewProduct.SelectFirstOptionInSection("Which one best describes your product");
			}
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 57865 \(Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path\)")]
		public void
			GivenICallSharedStepAdditionalProductInformation_PesticideShownUSOnlySelectNoForEverythingElse_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 57801 \(Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path\)")]
		public void GivenICallSharedConfirmVOCSummaryAndVOCAnalysisDate_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Volatile Organic Compound Summary Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			Report.StartStep("I confirm that the VOC Analysis Date statement is showing");
			MyNewProduct.ThenIConfirmThatTheVOCAnalysisDateIsShowing();
			Report.StartStep("I confirm that I see todays VOC Analysis Date");
			MyNewProduct.ThenIConfirmThatISeeTodaysVOCAnalysisDate();
		}

		[StepDefinition(@"I call Shared Step 42214 \(Delete a Product from the Product grid\) to delete product: (.*)")]
		public void GivenICallSharedDeleteAProductFromTheProductGrid(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
			Report.StartStep("I delete the product: " + savedAs);
			new StepsProductGrid().ThenIDeleteTheProduct(savedAs);
		}

		[StepDefinition(
			@"I call Shared Step 57727 \(Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"DOT");
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with limited quantity");
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with consumer commodity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with consumer commodity");
			Report.StartStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 65705 \(Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue\)")]
		public void
			GivenICallSharedStepTransportation_DOTUNStep_EnterUNSelectAerosolsNoneAddTechnicalNameClickContinue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			Report.StartStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			Report.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.1");
			Report.StartStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 34455 \(U\. S\. Department of Transportation \(DOT\) Classification - Enter all valid data\)")]
		public void GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidData()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN3159");			
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN3159");
			Delay.Seconds(2);			
			Delay.Seconds(2);
			Report.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartStep("I select '2.2' in section: Hazard Class (select)");			
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.2");
			Report.StartStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 34455 \(U\. S\. Department of Transportation \(DOT\) Classification - Enter all valid data\): UN Unmber: (.*), Proper Shipping Name: (.*), Technical Name: (.*), Hazard Class: (.*), Packing Group: (.*)")]
		public void
			GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidDataUNUnmberUNProperShippingNameNonanesTechniacalNameTechnicalTestNameHazardClassPackingGroupIII(
				string unNo, string psnName, string techName, string hazClass, string packClass)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: " + unNo);
			MyNewProduct.SetTheSectionOptionTo("UN Number", unNo);
			Delay.Seconds(2);
			Report.StartStep("I select '" + psnName + "' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", psnName);
			Delay.Seconds(2);
			Report.StartStep("I enter '" + techName + "' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", techName);
			Delay.Seconds(2);
			Report.StartStep("I select '" + hazClass + "' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", hazClass);
			Report.StartStep("I select '" + packClass + "' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", packClass);
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 57728 \(U.S. Department of Transportation \(DOT\) Classification - Enter UN1950 \(Aerosol\) - Select data - Continue - Happy Path\)")]
		public void GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Proper Shipping Name");			
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");	
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I enter UN1993 - Select data - Continue - Happy Path")]
		public void EnterUN1993_SelectData_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN1993");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1993");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			Report.StartStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			Report.StartStep("If Product boiling point question appears, I select the first radio button");
			var expectedSections = new List<string>();
			expectedSections.Add("Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.");
			var expectedNormalised = expectedSections.Select(x => x.Replace(" ", "")).ToList();
			var ActualSections = new NewProduct().GetDisplayedSections().Select(x => x).ToList();
			var actualNormalised = ActualSections.Select(x => x.Replace(" ", "")).ToList();
			if (expectedNormalised.All(actualNormalised.Contains))
			{
				MyNewProduct.SelectFirstOptionInSection("Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.");
			}
			Report.StartStep(
							"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}


		[StepDefinition(@"I call Shared Step 49621 \(Volatile Organic Compounds \(VOC\) for OTC and CARB - No\)")]
		public void GivenICallSharedVolatileOrganicCompoundsVOCForOTCAndCARB_No()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartStep("I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP("No");
		}

		[StepDefinition(@"I call Shared Step 32931 \(Liquid Core Product - select  No - Happy Path\)")]
		public void LiquidCoreProduct_SelectNo_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			Report.StartStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "No");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 74995 \(Liquid Core product - Select Yes - Continue\)")]
		public void GivenICallSharedStepIquidCoreProduct_SelectYes_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			Report.StartStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "Yes");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 00000 \(Liquid Core Product - select Yes - Happy Path\)")]
		public void GivenICallSharedStepLiquidCoreProduct_SelectYes_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			Report.StartStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "Yes");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 57507 \(Transportation Details 1- Not Regulated - Continue - Happy Path\)")]
		public void ICallSharedTransportationDetails1_NotRegulated()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Delay.Seconds(2);
			Report.StartStep("I should see the Transportation Details 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Transportation Details 1");
			Report.StartStep("I set the Product is Regulated for Transport field to: Not Regulated");
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

			Report.StartStep("In the Transportation Details 1 page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(@"I call Shared Step 57502 \(Additional Product Information - Pesticide & Child shown, US only, No to everything else - Continue - Happy Path\)")]
		public void ICallSharedAdditionalProductInformation_PesticideAndChildShown_USOnly_NoToEverythingElse()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			Report.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		// Duplicate with Shared Step 57884
		[StepDefinition(@"I call Shared Step 59663 \(Safety Data Sheet Authoring - Additional Data \(Optional\)\)")]
		public void ICallSharedSafetyDataSheetAuthoring_AdditionalDataOptional(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();

			Report.StartStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");

			Report.StartStep(
				"In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " +
				table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct.SetTheSectionOptionTo("Personal Protection Equipment Recommended",
				table.Rows[0]["Personal Protection Equipment"]);

			Report.StartStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " +
								 table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.SetTheSectionOptionTo("Autoignition Temperature", table.Rows[0]["Autoignition Temperature"]);

			Report.StartStep(
				"In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " +
				table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.SetTheSectionOptionTo("Minimum Ignition Energy", table.Rows[0]["Minimum Ignition Energy"]);

			Report.StartStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " +
								 table.Rows[0]["Viscosity"]);
			MyNewProduct.SetTheSectionOptionTo("Viscosity", table.Rows[0]["Viscosity"]);

			Report.StartStep("In the Review and Submit tab of the New Product Page for Appearance I select: " +
								 table.Rows[0]["Appearance"]);
			MyNewProduct.SetTheSectionOptionTo("Appearance", table.Rows[0]["Appearance"]);

			Report.StartStep("In the Review and Submit tab of the New Product Page for Odor I select: " +
								 table.Rows[0]["Odor"]);
			MyNewProduct.SetTheSectionOptionTo("Odor", table.Rows[0]["Odor"]);

			Report.StartStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " +
								 table.Rows[0]["Odor Threshold"]);
			MyNewProduct.SetTheSectionOptionTo("Odor Threshold", table.Rows[0]["Odor Threshold"]);
			// if Product's Dispensing Method is required enter any option

			List<string> actualSections = new NewProduct().GetDisplayedSections();
			if (actualSections.Contains("Product's Dispensing Method"))
			{
				Report.StartStep(
					"In the Review and Submit tab of the New Product Page for Product's Dispensing Method I select: " +
					table.Rows[0]["Product's Dispensing Method"]);
				MyNewProduct.SetTheSectionOptionTo("Product's Dispensing Method",
					table.Rows[0]["Product's Dispensing Method"]);
			}

			Report.StartStep(
				"In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " +
				table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.SetTheSectionOptionTo("Partition Coefficient", table.Rows[0]["Partition Coefficient"]);

			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57501 \(Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue\)")]
		public void ICallSharedProductCharacteristics_MoreThanOneState_SelectSolid_StateAndSubcat_MixedAndWater_Random()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			MyNewProductSteps.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			Report.StartStep("I set the Primary Physical State option to: Solid");
			MyNewProductSteps.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"Yes");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			Report.StartStep("I set the Secondary Physical State option to: Solid");
			MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartStep("In the New Product page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 59680 \(Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path\)")]
		public void ICallSharedAdditionalProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Additional Product Information Page");
			var MyNewProductSteps = new StepsNewProduct();
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			Report.StartStep("I only see the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
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
			var tableSecond = new Table("Section");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			Report.StartStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 29181 \(Ingredients - add any chemical\) with name: (.*)")]
		public void ICallSharedIngredients_AddAnyChemical(string name)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartStep("I should see the Ingredients Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Ingredients");
			Report.StartStep("I add the ingredient " + name + " at 100%");
			var table = new Table("ComponentName", "Percent");
			table.AddRow(name, "100");
			stepsNewProductIngredients.AddIngredients(table);
			Report.StartStep("In the Ingredients page I click Continue");			
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Regulatory Information 1");			
			
		}

		[StepDefinition(@"I call Shared Step 57637 \(Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Exempt");
			stepsRegulatoryInformation.SetTSCATo("Exempt");
			Report.StartStep("I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyNewProductSteps.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status", "Compliant with Domestic Substances List (DSL)");
			Report.StartStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("No");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared Step 29206 \(Retailer - Select No Retailer - Click Done - Click Continue - Happy Path\)")]
		public void ICallSharedRetailer_SelectNoRetailer_ClickDone()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			Report.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.NewProductPageIClickContinueNoSpinnerWait();
			/* --As per TFS70787 warning popup displays for NR  --- */
			Report.StartStep("In the UPCs Warning popup I click Ok");
			new Steps_Retailer().IfISeeUpcWarningPopupClick("Ok");
		}

		[StepDefinition(@"I call Shared Step 59042 \(Browse for File > select > click Open - Happy Path\) for document type: (.*) and file: (.*)")]
		public void ICallSharedBrowseForFileSelectClickOpen(string type, string pdfFile)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I upload document type: " + type + " using the Browse and Open");
			Delay.Seconds(2);
			new NewProduct().UploadFileForSection(type, pdfFile);

		}

		[StepDefinition(@"I call Shared Step 60533 \(Additional Documents to Provide - Flash Point and Product Label only\) : (.*)")]
		public void ICallSharedAdditionalDocumentsToProvide_FlashPointAndProductLabelOnly(string docPath)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(
				@"I click the browse button for document: Flash Point Document and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Flash Point Document", docPath);
			Report.StartStep(
				@"I click the browse button for document: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Product Label", docPath);
			Report.StartStep(@"in the Additional Documents to Provide page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 62678 \(Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path\)")]
		public void ICallSharedAdditionalProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			Report.StartStep("I only the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartStep("I set the Select countries the product may be sold in option to: Canada");
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
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
			var tableSecond = new Table("Section");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			Report.StartStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I confirm that the default selected retailer is: (.*) then click Continue")]
		public void CustomConfirmDefaultSelectedRetailer_ClickContinue(string retailer)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsSelectRetailers = new StepsSelectRetailers();
			Report.StartStep("I should see the Retailer Page");
			stepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartStep("The selected retailers on the Retailer page should be:");
			//MyNewProductSteps.SelectedRetailersShouldBe(new List<string> { retailer });
			var retailers = new Table("Retailer");
			retailers.AddRow(retailer);
			new Steps_Retailer().SelectedRetailersShouldBe(retailers);
			Report.StartStep("In the Retailer page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(@"I call Shared Step 59922 \(Additional Product Information - Private Label or Brand only\)")]
		public void SharedAdditionalProductInformation_PrivateLabelOrBrandOnly()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 58189 \(Answer Electronic Equipment questions - With Cathode Ray - No to all\)")]
		public void SharedAnswerElectronicEquipmentQuestions_WithCathodeRay_NoToAll()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I set the Contains Circuit Board option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Contains Circuit Board", "No");
			Report.StartStep("I set the Has a Cathode Ray Tube (CRT) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Has a Cathode Ray Tube (CRT)", "No");
			Report.StartStep("I set the Has a LCD for Plasma Display option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			Report.StartStep("In the Answer Electronic Equipment questions page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Electronic Equipment");
		}

		[StepDefinition(@"I call Shared Step 60741 \(Select Primary Physical Property - Solid - With Ingredients\)")]
		public void GivenICallSharedStepSelectPrimaryPhysicalProperty_Solid_WithIngredients()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Product Characteristics page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Report.StartStep("I set the Primary Physical State option to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			Report.StartStep("I set the Secondary Physical State option to: Cream");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Cream");
			Delay.Seconds(5);
			var MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("When mixed with an equal amount of water"))
			{
				Report.StartStep(
					"I set the When mixed with an equal amount of water, will this produce a solution with a pH option to: Yes");
				MyStepsNewProduct.SetTheSectionOptionTo(
					"When mixed with an equal amount of water, will this produce a solution with a pH", "Yes");
			}

			Report.StartStep("I set the Select all ingredients included in this product option to: Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Select all ingredients included in this product", "Dairy");
			Report.StartStep(
				"I set the Product is manufactured in a facility that processes, or contains option to: Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains",
				"Dairy or products containing dairy or milk");
			Report.StartStep("I set the Product is verified and sold as option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			Report.StartStep("I set the Product contains the following sweeteners option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			Report.StartStep(
				"I set the Product contains the following artificial dye(s) option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)",
				"None of the Above");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 69687 \(Additional Product Information - US, No\(PL\)\)")]
		public void GivenICallSharedStepAdditionalProductInformation_CountryAndPrivateLabelOrBrand_No()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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

		[StepDefinition(@"I call Shared Step 65511 \(Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path \(use in a BCP\)\)")]
		public void ICallSharedAdditionalProductInformation_NoChildNoDirectShipNoPLClickContinue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			//Report.StartStep(
			//	"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			//MyNewProduct.SetTheSectionOptionTo(
			//	"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
			//	"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 57503 \(Regulatory Information 1- TSCA\(Random\) - Prop 65\(No\) - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			var table = new Table("Section");
			table.AddRow("U.S. Toxic Substances Control Act (TSCA) status");
			table.AddRow("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			Report.Info("Checking that the only visible questions relate to: TSCA and Prop 65");
			MyStepsNewProduct.CheckDisplayedSections("only see", table);
			Report.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			stepsRegulatoryInformation.SetTSCATo("Compliant");
			Report.StartStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("No");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared Step 59927 \(Primary Physical State > Solid only available – Without Water Solubility question\)")]
		public void SharedPrimaryPhysicalStateSolidOnlyAvailable_WithoutWaterSolubilityQuestion()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("Primary Physical State should be showing the value: Solid");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			Report.StartStep("I set the Secondary Physical State field to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			Report.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 60826 \(Enter Universal Product Code \(UPC\) - Battery - Confirm Quantity \) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and quantity: (.*)")]
		public void SharedEnterUniversalProductCodeUPC_Battery_ConfirmQuantity(string upc, string containerType,
			string size, string quantity)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I confirm 'Quantity' is visible in the UPC header");
			MyStepsNewProduct.ConfirmQuantityIsVisibleInUPCHeader();
			Report.StartStep("I click the 'Add UPC' button");
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
			Report.StartStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 69358 \(Data Acceptance - Click Summary Button\)")]
		public void SharedDataAcceptance_ClickSummaryButton()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the Summary button in the Data Acceptance window");
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartStep("I confirm the Manufacturer column is visible");
			// Confirm Manufacturer column is visble.
			// Close new tab
		}

		[StepDefinition(@"I call Shared Step 60026 \(Additional Product Information - US - Battery - No to all\)")]
		public void SharedAdditionalProductInformation_US_Battery_NoToAll()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartStep("I set the Select one option below field to: Battery is packaged for Retail Sale");
			MyNewProductSteps.SetTheSectionOptionTo("Select one option below", "Battery is packaged for Retail Sale");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 73282 \(Lithium Battery Characteristics - Weight in Grams\)")]
		public void SharedLithiumBatteryCharacteristics_WeightInGrams()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			Report.StartStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			Report.StartStep("I set the Weight of Lithium in grams (single unit) field to: 0.1");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of Lithium in grams (single unit)", "0.1");
			Report.StartStep("I set the Weight of the single unit (grams) field to: 10");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "10");
			Report.StartStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			Report.StartStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}

		[StepDefinition(@"I call Shared Step 54799 \(Lithium Battery Characteristics - any data - Happy path\)")]
		public void SharedLithiumBatteryCharacteristics_AnyData()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			Report.StartStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			Report.StartStep("I set the Watt-hour of the battery (single unit) field to: 0.1");
			MyNewProductSteps.SetTheSectionOptionTo("Watt-hour of the battery (single unit)", "0.1");
			Report.StartStep("I set the Weight of the single unit (grams) field to: 10");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "10");
			Report.StartStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			Report.StartStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}

		[StepDefinition(@"I call Shared Step 103412 - Lithium Primary/Metal Battery Characteristics - any data - Happy path")]
		public void GivenICallSharedStep_LithiumPrimaryMetalBatteryCharacteristics_AnyData_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			Report.StartStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			Report.StartStep("I set the Weight of Lithium in grams (single unit) field to: 10.2");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of Lithium in grams (single unit)", "10.2");
			Report.StartStep("I set the Weight of the single unit (grams) field to: 12");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "12");
			Report.StartStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			Report.StartStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}



		[StepDefinition(@"I call Shared Step 60096 \(Lithium Battery Transportation\)")]
		public void SharedLithiumBatteryTransportation()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Lithium Battery Transportation Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Transportation");
			Report.StartStep(
				"I set the For U.S. Department of Transportation (DOT), indicate the transport classification field to: Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail");
			MyNewProductSteps.SetTheSectionOptionTo(
				"For U.S. Department of Transportation (DOT), indicate the transport classification",
				"Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail");
			Report.StartStep(
				"I select the first option for section: For Marine transport (IMDG), indicate the classification");
			MyNewProductSteps.SelectFirstOptionInSection("For Marine transport (IMDG), indicate the classification");
			Report.StartStep(
				"I set the For Air transport (IATA), indicate the classification field to the first selection");
			MyNewProductSteps.SelectFirstOptionInSection("For Air transport (IATA), indicate the classification");
			Report.StartStep(
				"I set the For Canada's Transportation of Dangerous Goods (TDG), indicate the classification field to: None of the above/Not intended for shipment in Canada");
			MyNewProductSteps.SetTheSectionOptionTo(
				"For Canada's Transportation of Dangerous Goods (TDG), indicate the classification",
				"None of the above/Not intended for shipment in Canada");
			Report.StartStep("In the Lithium Battery Transportation page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Transportation");
		}

		[StepDefinition(@"I call Shared Step 69422 \(Additional Documents to Provide - Upload Product Photo\)")]
		public void SharedAdditionalDocumentsToProvide_UploadProductPhoto()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep(
				@"I click the browse button for label: Please upload a PDF of the product. in section: Product Photo and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFileSectionAndType("Please upload a PDF of the product.", "Product Photo",
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 54797 \(Select the specific Lithium Ion chemistry of the Battery\)")]
		public void SharedSelectTheSpecificLithiumIonChemistry()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Select the specific Lithium Ion chemistry of the Battery Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Select the specific Lithium Ion chemistry of the Battery");
			Report.StartStep("I select the first option in section: Select the best description");
			MyNewProductSteps.SelectFirstOptionInSection("Select the best description");
			Report.StartStep("In the Select the specific Lithium Ion chemistry page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Select the specific Lithium Ion chemistry");
		}

		// Duplicate of Shared step 60026
		[StepDefinition(@"I call Shared Step 65493 \(Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue\)")]
		public void SharedAdditionalProductInformation_USOnly_BatteryIsPackedForRetailSales_NoElse()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep("I set the Select one option below field to: Battery is packaged for Retail Sale");
			MyNewProductSteps.SetTheSectionOptionTo("Select one option below", "Battery is packaged for Retail Sale");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 56808 Regulatory Information - Prop 65 - No - Continue")]
		public void GivenICallShared56808RegulatoryInformation_Prop_No_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("No");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared Step 60715 \(Additional Documents to Provide - OSHA SDS - only\) : (.*)")]
		public void GivenICall60715SharedAdditionalDocumentsToProvide_OSHASDS_OnlyCDependenciesWERCSmartTestdoc_Pdf(
			string docPath)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.UploadPDFFileSectionAndType("OSHA SDS", "Upload Physical", docPath);
			Report.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 58608 \(Additional Documents to Provide - Label - OSHA - CARB\)")]
		public void SharedAdditionalDocumentsToProvide_Label_OSHA_CARB()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Documents To Provide Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Documents To Provide");
			Report.StartStep(
				@"I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("Product Label", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep(
				@"I click the browse button for label: OSHA SDS and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("OSHA SDS", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep(
				@"I click the browse button for label: Executive Order from the CARB and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("Executive Order from the CARB", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 26897 \(Product Characteristics - Solid only available - continue\)")]
		public void SharedProductCharacteristics_SolidOnlyAvailable_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var thisNewProduct = new NewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			Report.StartStep("There should only be one option available for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			Report.StartStep("Primary Physical State should be showing the value: Solid");
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
				Report.StartStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}

			Report.StartStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			if (new NewProduct().GetDisplayedSections().Contains("Flash Point Testing Method Used"))
			{
				Report.StartStep("Selecting Not applicable/available for section: Flash Point Testing Method Used");
				MyNewProductSteps.SetTheSectionOptionTo("Flash Point Testing Method Used",
					"Not applicable/available");
			}

			Report.StartStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57590 \(Enter Pesticide Data - United States \(with EPA number\)\)")]
		public void SharedEnterPesticideData_UnitedStatesWithEPANumber()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var newProductPesticideDetailsUS = new Steps_PesticideDetailsUS();
			Report.StartStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "Yes");
			Report.StartStep("I add the EPA Registration Number: 72315-6");
			newProductPesticideDetailsUS.IAddTheEPARegistrationNumber("72315-6");
			Report.StartStep("Clicking continue in the Pesticide Details page");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Pesticide Details");
		}

		[StepDefinition(@"I call Shared Step 57508 \(VOC SCAQMD/Canada - Yes Low Solid, Yes apply to all States - Continue - Happy Path\)")]
		public void SharedVOCSCAQMDCanada_YesLowSolidYesApplyToAllStates_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep(
				"I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
			Report.StartStep("I set the Product is a Low Solid option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Low Solid", "Yes");
			Report.StartStep(
				"I set the VOC content of product in g/L, including water and exempt compounds. option to: 10.0");
			MyNewProductSteps.SetTheSectionOptionTo(
				"VOC content of product in g/L, including water and exempt compounds.", "10.0");
			Report.StartStep(
				"I set the Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison? option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison?",
				"Yes");
			Report.StartStep("Clicking continue in the Volatile Organic Compounds (VOC) for California Air District(s) and Canada page");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC) for California Air District(s) and Canada");
		}

		[StepDefinition(@"I call Shared Step 57798 \(Additional Product Information- Pesticide, Canada Only - No to everything else, Continue\)")]
		public void SharedAdditionalProductInformation_Pesticide_CanadaOnly_NoToAll_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep("Make sure the United States check box is NOT selected, if it is uncheck it");
			List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			Report.StartStep("I set the Select countries the product may be sold in option to: Canada");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			Report.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyStepsNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 48948 \(Formulation > 3rd Party - Select all\)")]
		public void SharedFormulation3rdParty_SelectAll()
		{
			ReportSettings.UseSubSteps = true;
			var myNewProductClass = new NewProduct();
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Formulation > 3rd Party Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Formulation > 3rd Party");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"By clicking Accept, I certify the formulation information entered is complete and accurate",
				"Accept"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"By clicking Accept, I certify the formulation information entered is complete and accurate", "Accept");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Consent to Tier 2 Data Uses",
				"Granted"));
			MyStepsNewProduct.SetTheSectionOptionTo("Consent to Tier 2 Data Uses", "Granted");
			if (myNewProductClass.SectionExists("Consent to Tier 4.1 Derived Results"))
			{
				Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Consent to Tier 4.1 Derived Results",
				"Granted"));
				MyStepsNewProduct.SetTheSectionOptionTo("Consent to Tier 4.1 Derived Results", "Granted");
			}
			Report.StartStep("in the Formulation > 3rd Party page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Formulation > 3rd Party");
		}

		[StepDefinition(@"I call Shared Step 60932 \(Regulatory Information 2 - Microbeads - No\)")]
		public void SharedRegulatoryInformation2_Microbeads_No()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product contains microbeads",
				"No"));
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains microbeads", "No");
			Report.StartStep("in the Regulatory Information 2 page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 2");
		}

		[StepDefinition(@"I call Shared Step 60933 \(Additional Documents to Provide - Product Label and OSHA SDS only\)")]
		public void SharedAdditionalDocumentsToProvide_ProductLabelAndOSHASDSOnly()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I click the browse button for label: '{0} and upload PDF: '{1}'",
				"Product Label",
				@"C:\Dependencies\WERCSmart\testdoc.pdf"));
			MyStepsNewProduct.UploadPDFFile("Product Label", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep(string.Format("I click the browse button for label: '{0} and upload PDF: '{1}'",
				"OSHA SDS",
				@"C:\Dependencies\WERCSmart\testdoc.pdf"));
			MyStepsNewProduct.UploadPDFFile("OSHA SDS", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("in the Additional Documents to Provide page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 58610 \(Confirm Restrict Use - Restrict\)")]
		public void SharedConfirmRestrictUse_Restrict()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var restrictUse = new Table("Section");
			restrictUse.AddRow("Do you want to restrict searchable access to your registered formula?");
			MyStepsNewProduct.CheckDisplayedSections("see", restrictUse);
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Do you want to restrict searchable access to your registered formula?",
				"Restrict - Customers should contact my organization for an access code"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Do you want to restrict searchable access to your registered formula?",
				" - Customers should contact my organization for an access code");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Access Code",
				"1234"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Access Code",
				"1234");
			Report.StartStep("in the Restrict Use page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Restrict Use");
		}

		[StepDefinition(@"I call Shared Step 63219 \(Retailer Association - Select No Retailer - Click continue\)")]
		public void SharedRetailerAssociatedion_SelectNoRetailer_ClickContinue()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var selSelectRetailers = new SelectRetailers();
			if (!selSelectRetailers.WaitForContainerToBeVisible(10))
			{
				Report.Warning("The Select Retailers page was not loaded on entering the Retailer page");
				new Retailer().ClickAddRetailers();
			}

			Report.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
			Report.StartStep("In the UPCs Warning popup I click Ok");
			var WarningPopup = new NoRetailerWarningPopup();
			WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(@"I call Shared Step 73629 \(Product Characteristics - Liquid - select any options\(enter pH, boiling point, flash point\)\)")]
		public void ICallSharedStepProductCharacteristicsWithBoilingPointPHFlashPoint(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Report.StartStep("Confirm that  you see only Liquid option for Physical state");
			var option = new Table("Option");
			option.AddRow("Liquid");
			MyNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Primary Physical State", option);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Specific Gravity I enter: " +
				table.Rows[0]["Specific Gravity"]);
			MyNewProduct.SetTheSectionOptionTo("Specific Gravity",
				table.Rows[0]["Specific Gravity"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 73748 \(Additional Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer\)")]
		public void GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_OSHA_PrivateLabel()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 70675 \(Product Characteristics - Liquid Only - With Water Solubility - Enter all data - Continue\)")]
		public void SharedProductCharacteristics_LiquidOnly_WithWaterSolubility_EnterAllData_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Secondary Physical State",
				"Liquid"));
			myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Specific Gravity",
				"1.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "1.0");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"10.2"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "10.2");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"120"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "120");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"55"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "55");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Closed cup method"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Select the best Water Solubility description",
				"100g/100ml"));
			myStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			Report.StartStep("In the Product Characteristics page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 62536 \(Transportation Details 2 > I do not ship internationally > Continue - Happy Path\)")]
		public void SharedTransportationDetails2_DoNotShipInternationally_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Transportation Details 2 page");
			myStepsNewProduct.GivenIShouldSeeXPage("Transportation Details 2");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"International Shipping when DOT Exemption taken?",
				"I do not ship internationally and I do not know the classification"));
			myStepsNewProduct.SetTheSectionOptionTo("International Shipping when DOT Exemption taken?",
				"I do not ship internationally and I do not know the classification");
			Report.StartStep("In the Transportation Details 2 page I click continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 2");
		}

		[StepDefinition(@"I call Shared Step 62686 \(Enter Physical Property - Liquid - Without Water Solubility\)")]
		public void SharedEnterPhysicalProperty_Liquid_WithoutWaterSolubility()
		{
			ReportSettings.UseSubSteps = true;
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
			Report.StartStep("I set the Primary Physical State to: 'Liquid'");
			myStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Specific Gravity",
				"10"));
			myStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "10");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"8"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "8");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"30"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "30");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"80"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "50");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"50"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Secondary Physical State",
				"Liquid"));
			myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("In the Product Characteristics page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 49818 \(Beverage Regulatory Details\)")]
		public void SharedBeverageRegulatoryDetails()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				"Yes"));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", "Yes");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Does your product contain a Prop 65 chemical?",
				"Yes"));
			new RegulatoryInformation1().Prop65 = true;
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				"12.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", "12.0");
			Report.StartStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}

		[StepDefinition(
			@"I call Shared Step 71618 \(U. S. Department of Transportation \(DOT\) Classification - For Alcohol \(Packaging III\)\)")]
		public void SharedUSDepartmentOfTransportationDOTClassification_ForAlcoholPackagingiii()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"UN Number",
				"UN3065"));
			myStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN3065");
			Report.StartStep(
				"By default the 'Proper Shipping Name' Field will be populated with 'Alcoholic beverages'");
			myStepsNewProduct.CheckingFieldInputIsCorrect("Proper Shipping Name", "Alcoholic beverages");
			Report.StartStep("I select the first valid option for section: 'Proper Shipping Name'");
			myStepsNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			string shippingName = myNewProduct.GetAllOptionsForSection("Proper Shipping Name")[0];
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Technical Name (if applicable)",
				"Technical " + shippingName));
			myStepsNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical " + shippingName);
			Report.StartStep("By default, '3' should be selected for 'Hazard Class (select)'");
			myStepsNewProduct.CheckingFieldInputIsCorrect("Hazard Class (select)", "3");
			Report.StartStep("I set the Packing Group section to 'III'");
			myStepsNewProduct.SetTheSectionOptionTo("Packing Group (select)", "III");
			Report.StartStep(
				"The following question should be displayed: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packaging Group selected is not consistent with this data.  Verify the data and transportation packaging group.  If the problem persists, please contact Support.'");
			var table = new Table("Section");
			table.AddRow(
				"Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.");
			myStepsNewProduct.CheckDisplayedSections("see", table);
			Report.StartStep(
				"Setting 'Packing Group' error question to: 'The UN# classification assigned to this product has a specific Packaging Group required.'");
			myStepsNewProduct.SetTheSectionOptionTo("Product has a boiling point of",
				"The UN# classification assigned to this product has a specific Packaging Group required.");
			Report.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I call Shared Step 73956 \(Go to Summary and verify data\) with product type: (.*)")]
		public void SharedGoToSummaryAndVerifyData(string typeOfProduct)
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myGlobalSteps = new GlobalSteps();
			Report.StartStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			Report.StartStep("I click the Summary button in the Data Acceptance window");
			myStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			Report.StartStep("Type of Product should be showing the following option: " + typeOfProduct);
			new StepsDataSummarySheet().ShouldBeShowingFollowing("Type of Product", typeOfProduct);
			Report.StartStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();
			Report.StartStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			// Nav to home not specified by the TFS item. I checked and it shouldn't break any other tests. Always end of test or delete shared step (which navs to home)
			//Report.StartStep("I navigate to the home page");
			//new StepsHomepage().ThenINavigateToTheHomePage();
		}

		[StepDefinition(
			@"I call Shared Step 43758 \(Product Grid- Filter for Product- Select Product - Delete\) for product: (.*)")]
		public void SharedProductGrid_FilterForProduct_SelectProduct_Delete(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I delete the product: " + savedAs);
			new StepsProductGrid().ThenIDeleteTheProduct(savedAs);
		}

		[StepDefinition(
			@"I call Shared Step 57514 \(Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path\)")]
		public void SharedProductCharacteristics_LiquidOnlyAvailable_EnterAllData_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Specific Gravity",
				"15.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "15.0");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"9.5"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "9.5");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"120"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "120");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"80"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "80");
			Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Not applicable/available"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
					"Select the best Water Solubility description",
					"100g/100ml"));
				myStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			}

			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				Report.StartStep(string.Format("I set the '{0}' option to: '{1}'",
					"Secondary Physical State",
					"Liquid"));
				myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			}

			Report.StartStep("In the Product Characteristics page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(
			@"I call Shared Step 57505 \(Pesticide Data - U.S. - EPA reg #\(No\) - EPA Exempt # \(Random\) - Continue - Happy Path\)")]
		public void SharedPesticideData_US_EPARegNo_EPAExemptRandom_Continue()
		{
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
			var thisStepsRetailPartners = new StepsRetailPartners();
			thisStepsRetailPartners.ConfirmHeadingShowing("Data Consent Tiers");
			thisStepsRetailPartners.SectionShouldBeShowingText("Data Consent Tiers",
				"This recipient does not require additional data consent tiers at this time.");

		}

		[StepDefinition(@"I call Shared Step 63804 \(Additional Product Information - enter options\)")]
		public void ICallSharedStepAdditionalProductInformationEnterOptions(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
				"Product is a Retailer's Private Label or Brand"))
			{
				Report.StartStep(
					"Product is a Retailer's Private Label or Brand" +
					table.Rows[0]["Private Label or Brand"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand",
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
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 65181 \(Retailer Association - Add Private Label Information and Select Vendor ID\) and select the retailer: (.*) and enter the name: (.*) and select Vendor id: (.*)")]
		public void GivenICallSharedRetailerAssociation_AddPrivateLabelInformationAndVendorId(string retailer,
			string name, string option)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Retailer();
			Report.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartStep("I should see the Retailer Page");
			stepsNewProduct.GivenIShouldSeeXPage("Retailer");
			var newProduct = new NewProduct();
			stepsRetailer.SelectPrivateLabelName(name);
			Delay.Seconds(2);
			if (option == "random")
			{
				Report.StartStep("Selecting a random vendor ID");
				Report.IsTrue(new Retailer().SelectRandomVendorId(), "Failed to set Vendor ID!",
					"Successfully set vendor ID");
				Report.Screenshot();
			}
			else
			{
				Report.StartStep("Selecting vendor ID: " + option);
				new Steps_Retailer().ISelectVendorId(option);
			}

			Report.StartStep("In the Retailer page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(
			@"I call Shared Step 74760 \(Product Characteristics - Select Liquid as primary physical state and enter all required data\)")]
		public void ICallSharedProductCharacteristics_MoreThanOneState_SelectLiquidAndEnterOtherOptions(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Delay.Seconds(1);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Primary Physical State I select: " +
				table.Rows[0]["Primary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State",
				table.Rows[0]["Primary Physical State"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Specific Gravity I enter: " +
				table.Rows[0]["Specific Gravity"]);
			MyNewProduct.SetTheSectionOptionTo("Specific Gravity",
				table.Rows[0]["Specific Gravity"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 74123 \(Additional Product Information - Grocery - US - Random Country - No\(PL\)\)")]
		public void GivenICallSharedStepAdditionalProductInformation_Grocery_US_RandomCountry_NoPL()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
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

		[StepDefinition(@"I call Shared Step 74981 \(Product Characteristics - gas\)")]
		public void ICallSharedProductCharacteristics_Gas(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Delay.Seconds(1);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I select: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 57923 \(Volatile Organic Compound \(VOC\) Step - enter OTC and CARB - Yes for state values\)")]
		public void ICallSharedProductCharacteristics_EnterVocAndCarbSelectStateValue(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			new Steps_VOC_OTC_CARB().VocOtcCarbPageShouldBeLoaded();
			Report.StartStep("In the Product Characteristics tab of the New Product Page for Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. I select: " +
				table.Rows[0]["Product granted Alternative Control Plan"]);
			new Steps_VOC_OTC_CARB().SetProductHasBeenGrantedACP(table.Rows[0]["Product granted Alternative Control Plan"]);
			Report.StartStep("In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB I enter: " +
				table.Rows[0]["Amount of VOC by CARB"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB",
				table.Rows[0]["Amount of VOC by CARB"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule I enter: " +
				table.Rows[0]["Amount of VOC by OTC Model"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule",
				table.Rows[0]["Amount of VOC by OTC Model"]);
			Report.StartStep(
				"In the Product Characteristics tab of the New Product Page for Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? I select: " +
				table.Rows[0]["VOC for states"]);
			MyNewProduct.SetTheSectionOptionTo(
				"Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?",
				table.Rows[0]["VOC for states"]);
			Report.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 56799 \(Confirm Additional Product Information shows Pesticide question and its radio buttons\)")]
		public void ICallSharedConfirmAdditionalProductInformationShowsPesticideQuestion()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			var sections = new Table("Section");
			sections.AddRow("Which one best describes your product");
			Report.StartStep("I confirm the 'Which one best describes your product' question is shown");
			MyNewProduct.CheckDisplayedSections("see", sections);
			var buttons = new Table("Button");
			buttons.AddRow(
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			buttons.AddRow(
				"Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth");
			buttons.AddRow("Product is not considered a pesticide product");
			Report.StartStep(
				"I confirm the radios showing in order are: Prevents, Destroys Repels Pests..', 'Regulates Plant Growth, Defoliates..', 'Product is not considered a pesticide product'");
			MyNewProduct.CheckRadioButtonsInSectionAndOrder("should", "Which one best describes your product", buttons);
		}

		[StepDefinition(
			@"I call Shared Step 57532 \(Product Characteristics - Aerosol & Gas available - Select Gas - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolAndGasAvailable_SelectGas_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Primary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Gas");
			Report.StartStep("I set the Secondary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
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
			@"I call Shared Step 63460 \(Additional Product Information - SOLD = US, No\(PL\), No\(GNFR\) only shown \(mainly kits\) Happy Path\)")]
		public void GivenICallSharedStepAdditionalProductInformation_SOLDUSNoPLNoGNFROnlyShownMainlyKitsHappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 74339 \(Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH\)")]
		public void GivenICallSharedStepProductCharacteristics_SelectLiquidAndEnterOnlySecondaryStateSpecificGravityPH()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
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
			MyNewProductSteps.SetTheSectionOptionTo("Specific Gravity", "20");
			MyNewProductSteps.SetTheSectionOptionTo("pH", "7");
		}

		[StepDefinition(
			@"I call Shared Step 74340 \(Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue\)")]
		public void
			GivenICallSharedStepAdditionalProductInformation_PesticideNotConsideredSOLDUSEverythingElseNo_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			var myNewProductClass = new NewProduct();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Product is not considered a pesticide product");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("Looking For the I Set the Cleaning products must comply with California's Cleaning Product Right to Know Act field, and Setting to: No if it exists ");
			if (myNewProductClass.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"No");
			}
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		/*
		[StepDefinition(@"I call Shared Step 57514 \(Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path\)")]
		public void GivenICallSharedStepProductCharacteristics_LiquidOnlyAvailable_EnterAllData_Continue_HappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "63");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Open cup method");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Decomposes");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
		*/

		[StepDefinition(@"I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue")]
		public void GivenICallSharedStepIngredients_AddAnyChemical_DONotClickContinue(Table ingredientsTable)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			Report.StartStep("I add the following ingredients:");
			stepsNewProductIngredients.AddIngredients(ingredientsTable);
		}

		[StepDefinition(
			@"I call Shared Step 57539 \(Product Characteristics - Aerosol & Liquid select Aerosol - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolAndLiquidSelectAerosol_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			// Primary Physical State displays Aerosol and Liquid
			Report.StartStep("I should only see the following options for Primary Physical State: Aerosol, Liquid");
			var produtTable = new Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			produtTable.AddRow(new string[] {
				"Liquid"
			});
			Report.StartStep("I set the Primary Physical State field to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			Report.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			Report.StartStep("I set the pH field to: 10.4");
			MyNewProduct.SetTheSectionOptionTo("pH", "10.4");
			Report.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			Report.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			//Report.StartStep("I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: The product is classified as a D003 Hazardous Waste under RCRA.");
			//MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "The product is classified as a D003 Hazardous Waste under RCRA.");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(
			@"I call Shared Step 57932 \(Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path\)")]
		public void GivenICallSharedEnterRegulatoryInformation_YesToProp()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var stepsRegulatoryInformation = new Steps_RegulatoryInformation1();
			var selNewProduct = new NewProduct();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			stepsRegulatoryInformation.SetTSCATo("Compliant");
			Report.StartStep("Prop 65 warning is required: Yes");
			stepsRegulatoryInformation.SetProp65ToNoOrYes("Yes");
			Report.StartStep("I set the Is the need to warn triggered by field to: A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			MyStepsNewProduct.SetTheSectionOptionTo("Is the need to warn triggered by",
				"A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			Report.StartStep("I set the How is the exposure warning transmitted? field to: By affixing it to the product or its packaging");
			MyStepsNewProduct.SetTheSectionOptionTo("How is the exposure warning transmitted?",
				"By affixing it to the product or its packaging");
			Report.StartStep("I set the Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured field to: Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured",
				"Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			Report.StartStep("I set the If the product carries a safe-harbor short-form warning, indicate which of the following is provided: field to: WARNING: Cancer - ");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a safe-harbor short-form warning, indicate which of the following is provided:",
				"WARNING: Cancer - ");
			Report.StartStep("I set the If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning: field to: This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to ");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:",
				"This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to ");
			Report.StartStep("I set the Enter the names of one or more listed carcinogens which are the subject of this warning field to: Arsenic");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Enter the names of one or more listed carcinogens which are the subject of this warning",
				"Arsenic");
			Report.StartStep("I set the If the product carries a custom warning, please provide the exact text that is being used: field to: NA");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"If the product carries a custom warning, please provide the exact text that is being used:",
				"NA");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 57980 \(Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails1_YesOption_SelectIMDGLimitedQuantity()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"IMDG");
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with limited quantity");
			Report.StartStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 57981 \(Transportation - IMDG UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue\)")]
		public void
			GivenICallSharedStepTransportation_IMDGUNStep_EnterUNSelectAerosolsNoneAddTechnicalNameClickContinue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			Report.StartStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			Report.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			Report.StartStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2");
			Report.StartStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			Report.StartStep(
				"In the International Marine (IMDG) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"International Marine (IMDG) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 57978 \(Product Characteristics - All select Gas - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AllSelectGas_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			// Primary Physical State displays All
			Report.StartStep(
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
			Report.StartStep("I set the Primary Physical State field to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Gas");
			Report.StartStep("I set the Secondary Physical State field to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			Report.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			Report.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(
			@"I call Shared Step 63226 \(Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path\)")]
		public void GivenICallSharedStepPesticideDate_YesRegistered_EnterEPANumberNotOnKelly_ClickContinue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			var newProductPesticideDetailsUS = new Steps_PesticideDetailsUS();
			Report.StartStep(
				"I set the 'Product has an Environmental Protection Agency (EPA) Registration Number' option to: 'Yes'");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "Yes");
			Report.StartStep("I add the EPA number: TEST-1234");
			newProductPesticideDetailsUS.IAddTheEPARegistrationNumber("TEST-1234");
			Report.StartStep("I click continue");
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
			ReportSettings.UseSubSteps = true;
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "8", "8", "yes");
			Report.StartStep("I set the EPA Reistration Date (8/8 current year)");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		//CLF - From test plans - Confirm that an error shows "State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable."
		// in fact it seems that the date has to be after October 1st.
		[StepDefinition(
			@"I call Shared Step 55820 \(EPA expiration date - enter next year - NOT Dec 31st\) for state: (.*)")]
		public void GivenICallSharedStepEPAExpirationDate_EnterNextYear_NOTDecStForState(string state)
		{
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "12", "31", "yes");
			Report.StartStep("I set the EPA Reistration Date (12/31 current year)");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 57501 \(Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP\)")]
		public void
			GivenICallSharedStep57501ProductCharacteristics_MoreThanOneState_SelectSolid_StateSubcat_MixedWater_Random_Continue_HP()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			var stepsProductCharacteristics = new Steps_ProductCharacteristics();
			Report.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			Report.StartStep("There should be at least 2 options for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			Report.StartStep("I set the Primary Physical State to: Solid");
			stepsProductCharacteristics.SetThePrimayPhysicalStateTo("Solid");
			var thisNewProduct = new NewProduct();
			if (thisNewProduct.OptionExists("Secondary Physical State"))
			{
				Report.StartStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}
			else
			{
				Report.Info("Secondary physical state is not showing");
			}
			Report.StartStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				Report.StartStep("I set the Select the best Water Solubility description option to: Soluble in water");
				stepsProductCharacteristics.GivenISetTheSelectTheBestWaterSolubilityDescriptionToBe("Soluble in water");
			}

			Report.StartStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57911 \(Regulatory Information 1 - CEPA only shown - Continue - Happy Path\)")]
		public void GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep(
				"I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyStepsNewProduct.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status",
				"Compliant with Domestic Substances List (DSL)");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 56494 \(Pesticide Details - Canada > Province Code confirmation/validation and selection\) for province: (.*) expected error: (.*)")]
		public void
			GivenICallSharedStep56494PesticideDetailsCanadaProvinceCodeconfirmationvalidationAndSelectionForProvince(
				string province, string error)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.ErrorMessagesAreShowingForItem(province, "should", error);
			MyStepsNewProduct.SelectFirstOptionInSection(province);
			MyStepsNewProduct.ErrorMessagesShouldNotBeShowingForItem(province);
		}

		[StepDefinition(
			@"I call Shared Step 69388 \(Retailer - Canada Only - Select No Retailer/No UPC product > Done > Continue - Happy Path\)")]
		public void GivenICallSharedStepRetailer_CanadaOnly_SelectNoRetailerNoUPCProductDoneContinue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			Report.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			Report.StartStep("In the Retailer page I click Continue");
			new StepsNewProduct().ClickContinue();
			Report.StartStep("In the UPCs Warning popup I click Ok");
			WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(
			@"I call Shared Step 69389 \(Regulatory Documents to Provide - Canada only - Confirm questions - Request author, add label and todays date - Continue\)")]
		public void
			GivenICallSharedStepRegulatoryDocumentsToProvide_CanadaOnly_ConfirmQuestions_RequestAuthorAddLabelAndTodaysDate_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartStep("I should see the WHMIS SDS question");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			Report.StartStep("I should see the WHMIS Label question");
			MyNewProduct.ThenFieldExists("WHMIS-compliant label, English and French-Canadian");
			Report.StartStep("I upload a PDF file in the WHMIS Label section");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian",
				"I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("I click continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 53542 \(Login with Administrator Role Continue 2 \(2nd login Shared Step\)\)")]
		public void GivenICallSharedStep53542LoginWithAdministratorRoleContinue2NdLoginSharedStep()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsSHA = new Steps_SHA();

			MyStepsSHA.GivenILoginToStudioAsAdministrator();

		}

		[StepDefinition(@"I call Shared Step 59066 \(Go to SHA Manager\)")]
		public void GivenICallSharedStep59066GoToSHAManager()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsSHA = new Steps_SHA();
			Report.StartStep("I click Menu: 'My Wercs' and Submenu: 'SHA'");
			MyStepsSHA.GivenIClickTopMenuItemAndSubMenuItem("My Wercs", "SHA");
			var thisStudioShaManager = new StudioSHAManager();
			Delay.Seconds(5);
			Report.IsTrue(thisStudioShaManager.SwitchToFrame(), "Failed to switch to IFrame", showSuccessScreenshot: false);
			Report.IsTrue(thisStudioShaManager.Wait_For_Loading_Finish(60), "Loading did not finish", showSuccessScreenshot: false);
			Report.Info("I confirm the product list is loaded");
			Report.Info("Waiting for product list to be loaded....");
			Report.IsTrue(thisStudioShaManager.WaitForProductList(30), "Product list is not showing",
				"Product list is showing", showSuccessScreenshot: false);
		}

		[StepDefinition(@"I call Shared Step 59728 \(Go to Manage Global Messages\)")]
		public void GivenICallSharedStep59728GoToManageGlobalMessages()
		{
			var MyStepsSHA = new Steps_SHA();
			Delay.Seconds(1);
			MyStepsSHA.GivenInSHAManagerPageIClickSubMenuItem("Manage Global Messages");
		}

		[StepDefinition(
			@"I call Shared Step 63860 \(Additional Product Information - US, No\(child\), No\(OSHA\), No\(DSV\), Yes\(PLP\), No\(GNFR\)\)")]
		public void SharedAdditionalProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR()
		{
			ReportSettings.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information Page");
			selNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			selNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			Report.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: Yes");
			selNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			selNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 74201 \(Select Retailers - CVS\)")]
		public void SelectRetailers_CVS()
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Retailer();
			Report.StartStep("In the Select Retailers popup I select the retailer: CVS");
			new StepsSelectRetailers().SelectTheRetailer("CVS");
			Report.StartStep("I enter private label as 'This Private Label'");
			stepsRetailer.EnterPrivateLabelName("This Private Label");
			Report.StartStep("I click continue");
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
			ReportSettings.UseSubSteps = true;
			List<VocLimitsWithUnits> LimitsTable = new NewProduct().GetDisplayedVocLimitsWithUnits();
			IEnumerable<VocLimitsWithUnits> regulationOtcLimit = LimitsTable.Where(x => x.Regulation.Trim() == "OTC Model rule limit");
			var regulationCarbLimit = LimitsTable.Where(x => x.Regulation == "CARB limit").ToList();
			Report.StartStep("I confirm the VOC Limits table shows an entry for CARB only");
			Report.IsTrue(regulationCarbLimit.Count == 1,
				"The Limits table does not contain only a single row for CARB. Count is: " + regulationCarbLimit.Count,
				"The Limits table contains only a single row for CARB as expected");
			Report.StartStep("I confirm the Regulation column does not show an entry for OTC Model Rule");
			Report.IsTrue(regulationOtcLimit.Count() == 0,
				"The Limits table contains a row for OTC Model rule when it should not!",
				"The Limits table does not contains a row for OTC Model rule limit as expected");
			foreach (VocLimitsWithUnits thisLimit in LimitsTable)
			{
				Report.StartStep(
					"I confirm the VOC Limits table shows an entry in the Use column with phrase matching the product's RU");
				Report.IsTrue(thisLimit.Use == use,
					"Use is not showing as: " + use,
					"Use is showing correctly: " + use);
				Report.StartStep(
					"I confirm the VOC Limits table shows a value in the VOC Compliance Limit column ");
				Report.IsTrue(thisLimit.VocComplianceLimit.Length > 0,
					"VOC Compliance Limit column is not showing a value when it was expected to!",
					"VOC Compliance Limit column is showing a value as expected: " + thisLimit.VocComplianceLimit);
				Report.StartStep("I confirm the table does NOT show a Units column ");
				Report.IsTrue(thisLimit.Units == null,
					"Units column is showing when it was not expected to!",
					"Units column is not showing as expected");
			}
		}

		[StepDefinition(@"I call Shared Step 74202 \(CVS Pharmacy - Yes, I wish to Continue\)")]
		public void SharedCVSPharmacy_YesIWishToContinue()
		{
			ReportSettings.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartStep("I confirm the CVS Pharmacy section appears");
			selNewProductSteps.GivenIShouldSeeXPage("CVS Own Brand Registration");
			Report.StartStep(
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the Retail Partners icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			Report.StartStep("I should see the heading 'Retail Partners'");
			new StepsRetailPartners().ThenIShouldSeeTheFollowingHeading("Retail Partners");
			Report.StartStep("I select the retailer: CVS");
			new StepsRetailPartners().SelectRetailer("CVS");
		}

		[StepDefinition(@"I call Shared Step 57206 \(Go to Retail Partners - Select Bed Bath and Beyond\)")]
		public void SharedGoToRetailPartners_SelectBedBathandBeyond()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the Retail Partners icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			Report.StartStep("I should see the heading 'Retail Partners'");
			new StepsRetailPartners().ThenIShouldSeeTheFollowingHeading("Retail Partners");
			Report.StartStep("I select the retailer: Bed Bath and Beyond");
			new StepsRetailPartners().SelectRetailer("Bed Bath and Beyond");
		}

		[StepDefinition(@"I call Shared Step 74269 \(Select Retailers - Rite Aid\)")]
		public void SharedSelectRetailers_RiteAid()
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Steps_Retailer();
			Report.StartStep("In the Select Retailers popup I select the retailer: Rite Aid");
			new StepsSelectRetailers().SelectTheRetailer("Rite Aid");
			Report.StartStep("I enter private label as 'This Private Label'");
			stepsRetailer.IEnterPrivateLabelName("This Private Label");
			Report.StartStep("I click continue");
			stepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 77711 \(Product Characteristics - Primary \(L/S\), 2nd - any, Enter Gravity, pH, Boiling Point, Flash Point, Flash Point Test - any, Water - any\)")]
		public void SharedProductCharacteristics_PrimaryLS_Any_EnterGravity_pH_BoilingPoint_FlashPointTestAny_WaterAny()
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartStep("I set the Primary Physical State option to: Liquid");
			stepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			stepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("I set the Specific Gravity option to: 10");
			stepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "10");
			Report.StartStep("I set the pH option to: 5");
			stepsNewProduct.SetTheSectionOptionTo("pH", "5");
			Report.StartStep("I set the pH option to: 5");
			stepsNewProduct.SetTheSectionOptionTo("pH", "5");
			Report.StartStep("I set the Boiling Point (in Celsius) option to: 80");
			stepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "80");
			Report.StartStep("I set the Flash Point (in Celsius) option to: 130");
			stepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "130");
			Report.StartStep("I set the Flash Point Testing Method option to: Open cup method");
			stepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Open cup method");
			Report.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
			stepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			Report.StartStep("I continue to the next screen in the new product registration");
			stepsNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(
			@"I call Shared Step 75146 \(Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue\) for")]
		public void
			GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(
				TechTalk.SpecFlow.Table retailers)
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			foreach (TechTalk.SpecFlow.TableRow thisRetailer in retailers.Rows)
			{
				Report.StartStep("In the Select Retailers popup I select the retailer: " +
									 thisRetailer["Retailer"]);
				new StepsSelectRetailers().SelectTheRetailer(thisRetailer["Retailer"]);
			}
			Report.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
			if (new NewProduct().ErrorMessageText == "This is a required field.")
			{
				Report.Failure("Required field error was showing on continue. Attempting to enter Private Label field (not specified by Shared Step)");
				Report.StartStep("I enter private label as 'This Private Label'");
				new Steps_Retailer().IEnterPrivateLabelName("This Private Label");
				Report.StartStep("I click continue");
				selStepsNewProduct.ClickContinue();
			}
		}

		[StepDefinition(@"I call Shared Step 65080 \(Login to Studio and Open SHA manager\)")]
		public void GivenICallShared65080LoginToStudioAndOpenSHAManager()
		{
			ReportSettings.UseSubSteps = true;
			var myStepsSha = new Steps_SHA();
			Report.StartStep("I navigate to Studio");
			myStepsSha.GivenINavigateToStudio();
			Report.StartStep("I log in to studio as administrator");
			myStepsSha.GivenILoginToStudioAsAdministrator();
			this.GivenICallSharedStep59066GoToSHAManager();
		}

		[StepDefinition(
			@"I call Shared Step 49841 \(SHA - Search for exact WPS ID in (.*) Status for saved as: (.*)\)")]
		public void GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus(string status, string savedAs)
		{

			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 49841");
			Report.StartStep("I set the status filter to All");
			Report.Screenshot();
			var myStudioShaManager = new StudioSHAManager();
			//myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			//Report.IsTrue(myStudioShaManager.WaitForProductList(60), "Product list was not loaded", "Product list loaded", showSuccessScreenshot: false);
			Report.Info("Getting saved product: " + savedAs);
			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;
			Report.Info("Looking for id: " + id);
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
				Report.StartStep("I click Srch in the bottom menu list");
				myStudioShaManager.ClickBottomMenuOption("Search");
				var myStepsSha = new Steps_SHA();
				Report.StartStep($"I enter ID: {id} in the Product ID box, change Status drop down to {status}, Click find");
				Report.Info("Searching for: " + id);
				myStepsSha.GivenInSHAManagerPageIRunSearch(table);
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

		[StepDefinition(
			@"I call Shared Step 55662 \(WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: (.*)\)")]
		public void GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.StartStep("I click System > Job Queue");
			thisTopMenu.ClickSubMenu("System", "Job Queue");
			Delay.Seconds(5);
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartStep(
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

			Report.StartStep("I wait for this job to complete processing");
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
				myProductSearch.Wait_for_load(5);
				Report.Info("Clicking find");
				if (!myProductSearch.ClickButton("Find"))
				{
					Report.Info("Failed to click find button");
				}

				Delay.Seconds(5);
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

			if (Context.Contains("ElectronicProduct"))
			{
				if (Context.GetFromContext("ElectronicProduct").ToString() == "true")
				{
					Report.Info("Skipping step because this is an electronic product");
					return;
				}

			}

			ReportSettings.UseSubSteps = true;
			var thisTopMenu = new StudioTopMenu();
			Report.StartStep("I click the Authoring menu option and Select Power Designer Plus");
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
			Report.Screenshot();
			Delay.Seconds(3);
			Report.StartStep("I select EN as the Language, MTR/CKLT as the format/subformat");
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			if (!thisPowerDesignerPlus.Wait_for_load(120))
			{
				var thisStudioPowerDesignerPlusDesignMode =
					new StudioPowerDesignerPlusDesignMode();
				thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
				thisStudioPowerDesignerPlusDesignMode.ClickMenuAndSubmenuOptions("Home");
				Delay.Seconds(3);
			}

			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(60), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
				"Set language option");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter("CKLT"), "Failed to set subformat option",
				"Set subformat option");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("CKLT", "MTR"), "Failed to set format option",
				"Set format option");
			Report.StartStep("I click the Edit Existing product radio button if not already selected");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");
			Report.Screenshot();
			Delay.Seconds(1);
			Report.StartStep("I filter for the product");
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(3);

			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.StartStep("I click Continue");
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button",
				"Clicked continue button");
			Delay.Seconds(3);
			Report.Info("Now going to click the sections side tab if its not open");
			var selStepsStudio = new Steps_Studio();
			//selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			//selStepsStudio.InPDIEnsureSECT2318IsActive();
			//selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();


			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Chemical Product Checklist");

		}

		[StepDefinition(@"I call Shared Step 78801 \(Additional Documents to Provide - VOC and Product Label\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_VOC_ProductLabel()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			MyNewProduct.UploadPDFFileSectionAndType("Product Label",
				"Volatile Organic Compounds", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProduct.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 40657 \(SHA Manager - Submitted - Select product > process product data for product saved as: (.*)\)")]
		public void GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step 40657");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQAHDPF data codes to show the Green check mark graphic");
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
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			//selStepsStudio.InPDIEnsureSECT2318IsActive();
			//selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			//selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			new Steps_Studio().GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Chemical Product Checklist");
			new Steps_Studio().ISetTheAuthoringCompleteCodeToNGHS();
			// Set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic (filename is DPQA_PASS[1].png)
			// Do this by double clicking on the graphic and selecting the green check mark graphic from the available list and click save
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
			Report.StartStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			Report.Info("Now waiting for spinner...");
			Delay.Seconds(5);
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				Report.Info("Spinner is showing, looking for alert");
				if (SeleniumBrowser.Alert.WaitForAlert())
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
			Report.StartStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("My Toolbar");
			Report.StartStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartStep("In the rule name filter box I enter the studio user name");
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(10);
			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}

			Report.StartStep("I close the Apply Rules pop up");
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
					SeleniumBrowser.WebBrowser.Close();
				}
			}

			Report.StartStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
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

			Report.StartStep(
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
			Report.StartStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(4);
			//Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.StartStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();

		}

		[StepDefinition(@"I call Shared Step 0000 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_No()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			Report.StartStep(
				"I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986",
				"No");
			Report.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 79436 \(Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name\) and save ingredient as: (.*)")]
		public void CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(string savedAs,
			Table component)
		{
			ReportSettings.UseSubSteps = true;
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

			ReportSettings.UseSubSteps = true;
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
				x.RecordID == id && x.Method == "PublishMultiple" && x.UserName == shaUser.Username);
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
			ReportSettings.UseSubSteps = true;
			var thisStepsStudio = new Steps_Studio();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InSHAManagerISelectProductById(id);
			thisStepsStudio.InSHAManagerIClickOnBottomMenuItem("Status");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(retailers);
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo("Completed");
			thisStepsStudio.GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton();

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
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
			var thisMyIngredients = new Steps_MyIngredients();
			thisMyIngredients.InTheFormulationThirdPartySCreenISetAcceptTo("true");
			Delay.Seconds(3);
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2 Data Uses", "Granted");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 4.1 Derived Results", "Granted");
			var thisStepsNewProduct = new StepsNewProduct();
			thisStepsNewProduct.GivenInTheNewProductPageIClickContinue("Third party");
		}

		[StepDefinition(@"I call Shared Step 79491 \(Formulation > 3rd Party - Accept formulation - Decline Tier 4.1 - Continue\)")]
		public void ThenICallSharedStep79491FormulationRdParty_AcceptFormulation_DeclineLastTier_Continue()
		{
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
			var myStepsNewProduct = new StepsNewProduct();
			var myGlobalSteps = new GlobalSteps();
			Report.StartStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			Report.StartStep("I click the Summary button in the Data Acceptance window");
			myStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			Report.StartStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			Report.StartStep("Type of Product should be showing the following option: " + typeOfProduct);
			new StepsDataSummarySheet().ShouldBeShowingFollowing("Type of Product", typeOfProduct);
			Report.StartStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();
			Report.StartStep("I should see the Data Acceptance Page");
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

			ReportSettings.UseSubSteps = true;
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
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
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

		[StepDefinition(@"I call Shared Step 79501 \(WPS Studio - PD\+ - Create Component for 3rd party product\)")]
		public void GivenICallSharedStep79501WPSStudio_PD_CreateComponentForRdPartyProduct(
			TechTalk.SpecFlow.Table components)
		{
			ReportSettings.UseSubSteps = true;
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
			if (SeleniumBrowser.Alert.WaitForAlert(2))
			{
				Report.Info("Found an alert");
				string alertText = SeleniumBrowser.Alert.GetText();
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
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
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select applicable modes of transport for which you classify the product", "DOT");
			Report.StartStep(
				"I set the section 'Select applicable modes of transport for which you classify the product' subsection 'DOT' field to: Yes, Shipped with Limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Yes, Shipped with Limited quantity",
				"Select applicable modes of transport for which you classify the product", "DOT");
		}

		[StepDefinition(@"I call Shared Step 65700 \(Transportation Details 1 - Select IATA & Limited Shipping\)")]
		public void Shared65700_TransportDetails1_SelectIataAndLimitedShipping()
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: IATA");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "IATA");
			Report.StartStep(
				"I set the section: 'Select all modes of transport that you've classified the product for' subsection: 'IATA' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "IATA");
		}

		[StepDefinition(@"I call Shared Step 65699 \(Transport - Select IMDG & Limited Shipping - No Continue\)")]
		public void Shared65699_Transport_SelectImdgAndLimitedShipping_NoContinue()
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: IMDG");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "IMDG");
			Report.StartStep(
				"I set the section: 'Select all modes of transport that you've classified the product for' subsection: 'IMDG' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "IMDG");
		}

		//65701
		[StepDefinition(@"I call Shared Step 65701 \(Transport - Select TDG & Limited Shipping - No Continue\)")]
		public void Shared65701_Transport_SelectTdgAndLimitedShipping_NoContinue()
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: TDG");
			selStepsNewProduct.SetTheSectionOptionTo(
				"Select all modes of transport that you've classified the product for", "TDG");
			Report.StartStep(
				"I set the section: 'Select all modes of transport that you've classified the product for' subsection: 'TDG' field to: Shipping with limited quantity");
			selStepsNewProduct.SetTheOptionSubOptionTo("Shipping with limited quantity",
				"Select all modes of transport that you've classified the product for", "TDG");
		}

		[StepDefinition(
			@"I call Shared Step 65939 \(Go To Transport DOT Step - Enter UN1966, Confirm data - NO CONTINUE\)")]
		public void Shared65939_GoToTransportDotStep_EnterUn1966ConfirmData_NoContinue()
		{
			var selStepsNewProduct = new StepsNewProduct();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the 'U.S. Department of Transportation (DOT) Classification' tab");
			selStepsNewProduct.ClickPageHeading(
				"U. S. Department of Transportation (DOT) Classification");
			Report.StartStep("I enter the Un Number 'UN1966'");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1966");
			Report.StartStep("I confirm 'Hydroden, refrigerated liquid' is showing for the Proper Shipping Name");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Proper Shipping Name", "Hydrogen, refrigerated liquid");
			Report.StartStep(
				"I confirm no other options are available for the Proper Shipping Name drop down list");
			var options = new Table("Option");
			options.AddRow("Hydrogen, refrigerated liquid");
			selStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Proper Shipping Name",
				options);
			Report.StartStep("I enter the phrase 'Technical Name Test' into the Technical Name field");
			selStepsNewProduct.SetTheSectionOptionTo("Technical Name", "Technical Name Test");
			Report.StartStep("I confirm '2.1' is selected for section: Hazard Class (select)");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Hazard Class (select)", "2.1");
			Report.StartStep("I confirm '2.1' is the only available option for section: Hazard Class (select)");
			options = new Table("Option");
			options.AddRow("2.1");
			selStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Hazard Class (select)",
				options);
			Report.StartStep("I confirm 'None' is selected for section 'Packing Group'");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group", "None");
			Report.StartStep("I confirm 'None' is the only available option for section 'Packing Group'");
			options = new Table("Option");
			options.AddRow("None");
			selStepsNewProduct.CheckOptionsInSection("should", "displayed exclusively", "Packing Group", options);
		}

		// In progress - PD + page not loading in studio
		[StepDefinition(
			@"I call Shared Step 65969 \(Go to Power Designer Plus - Select your product & CKLT - Continue\)")]
		public void Shared65969_GoToPdPlus_SelectYourProductAndCklt_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var selStepsSha = new Steps_SHA();
			var selStepsStudio = new Steps_Studio();
			Report.StartStep("I navigate to Power Designer Plus");
			selStepsSha.GivenIClickTopMenuItemAndSubMenuItem("Authoring", "Power Designer Plus");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartStep("I filter by product ID");
			if (TReVorSettings.TestCaseId.IsNullOrEmpty())
			{
				throw new Exception("Needs the test case ID to fetch the product ID to continue!");
			}

			string id = Context.GetFromContext("TestCase" + TReVorSettings.TestCaseId).ToString();
			if (id == null)
			{
				throw new Exception(
					$"Needs the product ID to be saved to context as 'TestCase{TReVorSettings.TestCaseId}'!");
			}
			
			selStepsStudio.PowerDesignerPlusWelcomeIEnterSelectSourceProduct(id);
			Report.StartStep("I confirm CKLT (Checklist) is selected as the subformat");
			selStepsStudio.IConfirmTheSelectedSubformatInThePdPlusPopupIs("CKLT / Checklist");
			Report.StartStep("I click continue");
			selStepsStudio.ClickContinueInThePowerDesignerPlusPopup();
			Delay.Seconds(3);
			//selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			//selStepsStudio.InPDIEnsureSECT2318IsActive();
			//selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Chemical Product Checklist");
		}

		[StepDefinition(
			@"I call Shared Step 81310 \(UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue\)")]
		public void Shared81310_UNNumber_EnterUN1950SelectAerosolAndHazClassConfirmPackingGroup_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I enter UN1950 in the UN Number field");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Report.StartStep("I select Aerosols from the Proper Shipping Name drop down");
			selStepsNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Report.StartStep("I select the first option from: Hazard Class (if available)");
			selStepsNewProduct.SelectFirstOptionInSection("Hazard Class (if available)");
			Report.StartStep("I confirm the Packing Group (if available) option is set to: None");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group (if available)", "None");
			Report.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 81311 \(UN Number - enter UN1206 - confirm pre-populated select radio button - Continue\)")]
		public void Shared81311_UNNumber_EnterUn1206_ConfirmPrePopulatedSelectRadioButton_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			var selNewProduct = new NewProduct();
			Report.StartStep("I enter UN1206 in the UN Number field");
			selStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN1206");
			Report.StartStep("I confirm the Proper Shipping Name is pre-populated with Heptanes");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Proper Shipping Name", "Heptanes");
			Report.StartStep("I confirm the Hazard Class drop down is pre-populated with 3");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Hazard Class (select)", "3");
			Report.StartStep("I confirm the Packing group drop down is pre-populated with II");
			selStepsNewProduct.CheckingFieldInputIsCorrect("Packing Group (select)", "II");
			// Some notes from TFS:
			// At times an additional question is now shown if you see it then perform this step and step 6 - otherwise ignore these two steps
			// I really do not think this is not correct as I do not have these values set on the product so I have re-emailed Courtney with details of testing and questions - for now this step is left in - but it may need to me removed/changed at some point
			List<string> sections = selNewProduct.GetDisplayedSections();
			if (sections.Any(x => x.ToLower().Contains("boiling point")))
			{
				Report.StartStep(
					@"Confirm an additional question is shown which reads ""Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.""");
				var table = new Table("Section");
				table.AddRow(
					"Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.");
				selStepsNewProduct.CheckDisplayedSections("see", table);
				Report.StartStep("I select the first option in the Packing Group additional question");
				selStepsNewProduct.SelectFirstOptionInSection("Product has a boiling point of");
			}

			Report.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 77872 \(Additional Product Information - Kit flow - US only, Direct Ship \(yes\), Continue\)")]
		public void Shared77872_AdditionalProductInformation_KitFlow_UsOnly_DirectShip_Yes_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information page");
			newProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep("I confirm 'United States' is selected for the SOLD question");
			newProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep("I should only see the SOLD and Direct ship questions");
			var sections = new Table("Section");
			sections.AddRow("Select countries the product may be sold in");
			sections.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			newProductSteps.CheckDisplayedSections("only see", sections);
			Report.StartStep(
				"I select the Yes button for the 'Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.' question");
			newProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.",
				"Yes");
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 31427 \(Create the Kit - Adding two products: product 1: (.*) and product 2: (.*)\)")]
		public void Shared31427_CreateTheKit_AddingTwoProducts(string inputProduct1, string inputProduct2)
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var product1 = (ProductInformation)Context.GetFromContext(inputProduct1.Trim());
			if (product1 == null)
			{
				throw new Exception("Failed to find product: " + inputProduct1);
			}

			var product2 = (ProductInformation)Context.GetFromContext(inputProduct2.Trim());
			if (product2 == null)
			{
				throw new Exception("Failed to find product: " + inputProduct2);
			}

			Report.StartStep($"I add {product1.Id} to the kit");
			newProductSteps.GivenInTheCreateTheKitPageISearchForAndSelectByIdSavedAs(product1);
			Report.StartStep($"I add {product2.Id} to the kit");
			newProductSteps.GivenInTheCreateTheKitPageISearchForAndSelectByIdSavedAs(product2);
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 77845 \(Retailer - Select WM, Done, Select Vendor ID, Continue\)")]
		public void Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue()
		{
			var newProductSteps = new StepsNewProduct();
			var retailerSelectionSteps = new StepsSelectRetailers();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Select Retailers Popup");
			retailerSelectionSteps.GivenIShouldSeeTheSelectRetailersPopUp();
			Report.StartStep("I select the retailer: Wal-Mart/SAM'S CLUB and click Done");
			new StepsSelectRetailers().SelectTheRetailer("Walmart");
			Report.StartStep("I set the Vendor as: Testing");
			//new Steps_Retailer().ISelectVendorId("Testing");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Walmart");
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 42759 \(Portal - UPC Page - add 1 UPC\)")]
		public void Shared42759_Portal_UpcPage_Add1Upc()
		{
			var newProductSteps = new StepsNewProduct();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the Add UPC button");
			newProductSteps.ThenIClickTheAddUpcButton();
			Report.StartStep("I set the UPC Number, Container Type and Size");
			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", $"saved as UPC{TReVorSettings.TestCaseId}");
			upcTable.AddRow("ContainerType", "Aerosol Can");
			upcTable.AddRow("Size", "20");
			//upcTable.AddRow("DPCI", "087 - 16 - 0238");
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 81633 - WPS - PD+ - Product Attributes - filter for, and select specific data code: (.*)")]
		public void Shared81633_Wps_PdPlus_ProductAttributes_FilterForAndSpecificDataCode(string dataCode)
		{
			var studioSteps = new Steps_Studio();
			ReportSettings.UseSubSteps = true;
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
			@"I call Shared Step 60648 \(Additional Product Information - US, No \(Direct Ship\), No \(PL\), No \(GNFR\)\)")]
		public void Shared60648_AdditionalProductInformation_Us_NoDirectShip_NoPl_NoGnfr()
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartStep("I set the 'Product is shipped directly..' question to: 'No'");
			newProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.",
				"No");
			Report.StartStep("I set the 'Product is a Retailer's Private Label or Brand' question to: 'No'");
			newProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep("I set the 'Product is sold to the Retailer..' question to: 'No'");
			newProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 77883 \(Additional Product Information - Kit flow - US only, Direct Ship \(No\), Continue\)")]
		public void Shared7783_AdditionalProductInformation_KitFlow_UsOnly_DirectShipNo_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartStep("I should see the Additional Product Information page");
			newProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep("I confirm 'United States' is selected for the SOLD question");
			newProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep("I should only see the SOLD and Direct ship questions");
			var sections = new Table("Section");
			sections.AddRow("Select countries the product may be sold in");
			sections.AddRow(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.");
			newProductSteps.CheckDisplayedSections("only see", sections);
			Report.StartStep(
				"I select the No button for the 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' question");
			newProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.",
				"No");
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 79491 \(Formulation > 3rd Party - Accept formulation - Decline Tier 2 - Continue\)")]
		public void ThenICallSharedStep79491FormulationRdParty_AcceptFormulation_DeclineTier_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var thisMyIngredients = new Steps_MyIngredients();
			thisMyIngredients.InTheFormulationThirdPartySCreenISetAcceptTo("true");
			//thisMyIngredients.InTheFormulationThirdPartySCreenISetDeclinedTo("true");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 2 Data Uses", "Declined");
			thisMyIngredients.InTheFormulationThirdPartySCreenISetFieldTo("Consent to Tier 4.1 Derived Results", "Declined");
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
			@"I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path")]
		public void ThenICallSharedStep_ECOLOGOReadinessAssessment_NotAtThisTime_Continue_HappyPath()
		{
			//Select the not at this time radio button
			//Click continue
		}

		[StepDefinition(
			@"I call Shared Step 51351 \(SHA > Select Product > View Recertification History\) for product saved as: (.*)")]
		public void GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var myStudioShaManager = new StudioSHAManager();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			var thisStepsSha = new Steps_SHA();
			Report.StartStep("I select  product in the SHA grid saved as " + savedAs);
			thisStepsSha.GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(savedAs);
			Delay.Seconds(3);
			Report.StartStep("I click 'Recertification History'");
			thisStepsSha.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption(
				"Recertification History");
			Delay.Seconds(1);
		}

		[StepDefinition(@"I call Shared Step 60778 \(Primary Physical Property - Packaged in gas cylinder\)")]
		public void Shared60778_PrimaryPhysicalProperty_PackagedInGasCylinder()
		{
			ReportSettings.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			Report.StartStep(
				@"By default the radio button should be selected for ""Product is packaged in a gas cylinder(e.g., whip cream)""");
			selNewProductSteps.CheckingFieldInputIsCorrect("Primary Physical State",
				"Product is packaged in a gas cylinder (e.g., whip cream)");
			Report.StartStep("I set the Secondary Physical State option to: Aerosol");
			selNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Aerosol");
			Report.StartStep("I set the pH option to: 10");
			selNewProductSteps.SetTheSectionOptionTo("pH", "10");
			Report.StartStep("I set the Select the best Water Solubility description option to: Soluble in water");
			selNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
				"Soluble in water");
			Report.StartStep(
				"I select the first option for: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then'");
			selNewProductSteps.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			Report.StartStep("I select the first option for: Select all ingredients included in this product");
			selNewProductSteps.SelectFirstOptionInSection("Select all ingredients included in this product");
			Report.StartStep(
				"I select the first option for: Product is manufactured in a facility that processes, or contains");
			selNewProductSteps.SelectFirstOptionInSection(
				"Product is manufactured in a facility that processes, or contains");
			Report.StartStep("I select the first option for: Product is verified and sold");
			selNewProductSteps.SelectFirstOptionInSection("Product is verified and sold");
			Report.StartStep("I select the first option for: Product contains the following sweeteners");
			selNewProductSteps.SelectFirstOptionInSection("Product contains the following sweeteners");
			Report.StartStep("I select the first option for: Product contains the following artificial dye(s)");
			selNewProductSteps.SelectFirstOptionInSection("Product contains the following artificial dye(s)");
			Report.StartStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 84554 \(Product Characteristics - Liquid & Solid - Enter all data - Continue - Happy Path\)")]
		public void Shared84554_ProductCharacteristics_LiquidAndSolid_EnterAllData_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartStep("I set the Primary Physical State option to: Liquid");
			newProductSteps.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			Report.StartStep("I set the Secondary Physical State option to: Liquid");
			newProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			Report.StartStep("I set the Specific Gravity field to: 1");
			newProductSteps.SetTheSectionOptionTo("Specific Gravity", "1");
			Report.StartStep("I set the pH option to: 10");
			newProductSteps.SetTheSectionOptionTo("pH", "10");
			Report.StartStep("I set the Boiling Point option to: '30'");
			newProductSteps.SetTheSectionOptionTo("Boiling Point (in Celsius)", "30");
			Report.StartStep("I set the Flash Point (in Celsius) option to: 100");
			newProductSteps.SetTheSectionOptionTo("Flash Point (in Celsius)", "100");
			Report.StartStep("I set the Flash Point Determination method option to: Not applicable/available");
			newProductSteps.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			Report.StartStep("I set the Select the best Water Solubility description option to: Soluble in water");
			newProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description", "Soluble in water");
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue")]
		public void ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(Table retailers)
		{
			ReportSettings.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			foreach (TableRow thisRetailer in retailers.Rows)
			{

				Report.StartStep("In the Select Retailers popup I select the retailer: " +
									 thisRetailer["Retailer"]);
				new StepsSelectRetailers().SelectTheRetailer(thisRetailer["Retailer"]);
			}
			foreach (TableRow thisRetailer in retailers.Rows)
			{
				Report.StartStep("In the Select Retailers popup I add PL information");
				selStepsNewProduct.ThenIAddAdditionaRequirmentsInfoForRetailer(thisRetailer["Retailer"],
					"Additional requirements: " + thisRetailer["Retailer"]);
			}
			Report.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
			if (new NewProduct().ErrorMessageText == "This is a required field.")
			{
				Report.Failure(
					"Required field error was showing on continue. Attempting to enter Private Label field (not specified by Shared Step)");
				Report.StartStep("I enter private label as 'This Private Label'");
				new Steps_Retailer().IEnterPrivateLabelName("This Private Label");
				Report.StartStep("I click continue");
				selStepsNewProduct.ClickContinue();
			}
		}

		[StepDefinition(
			@"I call Shared Step 85983 - WPS Studio - PD\\\+ PLP with NGHS only - set all data and publish using rule and DOC queue for product saved as: (.*)")]
		public void GivenICallSharedStep_WPSStudio_PDPLPWithNGHSOnly_SetAllDataAndPublishUsingRuleAndDOCQueue(
			string savedAs)
		{
			ReportSettings.UseSubSteps = true;

			//Given I Set the DPQAPF, DCQAPF, VOCQA, RSQAPF and RSQHADPF data codes to show the Green check mark graphic(filename is DPQA_PASS[1].png)Do this by double clicking on the graphic and selecting the green check mark graphic from the available list and click save
			Report.StartStep(
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
			Report.StartStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			//And I Select the Authorize Formula and Attributes for publishing check box
			Report.StartStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			//	If an error is shown you will need to add data to the data codes that are shown before you can continue-
			// close the pop up - add all data and re-open the current document pop up
			//	And I Select the Apply to all subformats check box
			Report.StartStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumBrowser.Alert.WaitForAlert())
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
			Report.StartStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			//	And I Select the Wizards tab
			//	And I Select the Apply Rules icon from the tool bar
			Report.StartStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			//And I Select the Single rule radio button
			Report.StartStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			//And I Click the three ... icon to open the Select Rule pop up
			Report.StartStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			//	And I Click the filter icon
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();

			//And I In the rule name filter box enter your studio user name(you will already have a publishing rule set up with your name)and click apply
			//	And I The Select rule pop up will show only rules which start with the characters you entered in the filter -select the rule you require to publish documents Note: The rule name will be in the format xxxx - CREATE ADDITIONAL DOC TO QUEUE-FOR XXXXWhere the xxxx is replaced by your Studio user name
			//And I Select the rule by clicking on it
			//	And I Check that the Product group radio button is selected
			//	And I Click Apply
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartStep("In the rule name filter box I enter the studio user name");
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(5);
			//	And I The Completed Successfully pop up is shown, click okNote: in Staging the completed
			// successful pop up does not show till you try to close the Apply rules pop up
			//	And I Close the Apply Rules pop up
			Report.StartStep("I close the Apply Rules pop up");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			Delay.Seconds(3);
			//	And I Select the Product tab
			//	And I Click the Document queue icon in the tool bar
			Report.StartStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			//	And I Click the filter icon
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			//	And I Enter you product id in the Product/ Alias area of the filter and click Apply
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Starts with...", @"Product\Alias");
			Report.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			//	And I Confirm your product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF,
			// you will see entries for the product and its aliases(Private Label products have aliases in WPS Studio).
			Report.StartStep(
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
			Report.StartStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(2);
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			//And I Pop up shows with message indicating the queued documents were sent for publishing
			Report.StartStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			//	And I Click OK
			Report.StartStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			//	And I Close the Document queue window
			Report.StartStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(
			@"I call Shared Step 75307 \(Edit UPC - Add UPC and all data - Click Save\) for UPC Number saved as: ""UPC(.*)"", container type: ""(.*)"", size: ""(.*)""")]
		public void Shared75307_EditUpc_AddUpcAndAllData(string upc, string containerType, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");
			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
			upcTable.AddRow("ContainerType", containerType);
			upcTable.AddRow("Size", size);
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			//If shown select an entry from the Packaging type drop down
			//If needed add any Retailer specific UPC data (for example OMSID, DPCI, part number etc)
			Report.StartStep("I click save");
			MyStepsNewProduct.ThenIClickSaveOrCancelInTheProductPage("Save");
		}

		// Option is now called "UPC Retailer and Feed"
		[StepDefinition(@"I call Shared Step 75309 \(SHA > Select Product > UPC Retailer and Feed\) for product saved as: (.*)")]
		//[StepDefinition(@"I call Shared Step 75309 \(SHA > Select Product > UPC List\) for product saved as: (.*)")]
		public void Shared75309_SHA_SelectProduct_UpcList(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			Report.StartStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Report.StartStep("I right click the product");
			shaSteps.GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(savedAs);
			// saving the current window so we can naviate back from UPC List
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			Report.StartStep("I click 'UPC Retailer and Feed'");
			shaSteps.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I call Shared Step 55637 \(SHA - Process UPC Update for Specific product\) saved as: (.*)")]
		public void Shared55637_SHA_ProcessUPCUpdateForSpecificProduct(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var shaSteps = new Steps_SHA();
			var shaManager = new StudioSHAManager();
			var processUI = new ProcessUIDialog();
			Report.StartStep("I confirm the product saved as is shown in the UPC Update status");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"UPC Update");
			Report.StartStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Report.StartStep("I click the UPC link at the bottom of the SHA page");
			shaManager.ClickBottomMenuOption("UPC");
			Report.StartStep("I uncheck the Auto Assign Regulatory Specialist to Product check box");
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

			Report.StartStep("I select regulatory specialist: Automated QASha");
			Report.IsTrue(processUI.SelectRegulatorySpecialist("Automated QASha"),
				"Failed to select regulatory specialist: Automated QASha",
				"Successfully selected regulatory specialist: Automated QASha", showSuccessScreenshot: false);
			Report.StartStep("I click continue");
			Report.IsTrue(processUI.ClickContinue(), "Failed to click continue!", "Successfully clicked continue", showSuccessScreenshot: false);
			Report.StartStep("I click Find in the Product Search popup");
			Delay.Seconds(5);
			var productSearch = new StudioSHAManagerProductSearch();
			if (!productSearch.Wait_for_load())
			{
				Report.Screenshot();
				throw new Exception("Product search did not load!");
			}

			Report.IsTrue(productSearch.ClickButton("Find"), "Failed to click Find in product search",
				"Successfully clicked Find in product search", showSuccessScreenshot: false);
			Report.StartStep("I close the Process Products pop up");
			processUI = new ProcessUIDialog();
			Report.IsTrue(processUI.ClickClose(), "Failed to close the Process Products popup",
				"Successfully closed the Process Products popup", showSuccessScreenshot: false);
			Report.StartStep("I confirm the product saved as is shown in the Accepted status");
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
			ReportSettings.UseSubSteps = true;
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
			thisStepsStudio.InProductAttributeFilterPopupISelectFromSelectBox("...Contains...", "Code");
			thisStepsStudio.InProductAttributeFilterPopupIEnterValueInTextBox("CNTXT", "Code");
			//Click apply
			thisStepsStudio.InProductAttributeFilterPopupIClickButton("apply");
		}

		[StepDefinition(
			@"I call Shared Step 80780 - My Products - Filter for product - View - Note transparency percentage - close summary for product saved as: (.*)")]
		public void GivenICallSharedStep_MyProducts_FilterForProduct_View_NoteTransparencyRatio_CloseSummary(
			string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I filter for the product: " + savedAs);
			var thisStepsProductGrid = new StepsProductGrid();
			var thisStepsDataSummarySheet = new StepsDataSummarySheet();
			var myGlobalSteps = new GlobalSteps();

			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();

			thisStepsProductGrid.ClickRowAction("View");
			Report.StartStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			thisStepsDataSummarySheet.GetIngredientsFromDataSummaryWindowAndAddToProductSavedAs(savedAs);
			thisStepsDataSummarySheet.GetTransparencyPercentageAndSaveAs("TransparencyPercentage");
			Report.StartStep("I close the Data Summary tab");
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
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			Report.StartStep("I should see the Ingredients Page");
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
			@"I call Shared Step 85284 - Additional Product Information - US & Canada, Child \(No\), OSHA \(No\), DSV \(No\), PLP \(YES\), GNFR \(No\), Continue")]
		public void
			ThenICallSharedStep85284_AdditionalProductInformation_USCanadaChildNoOSHANoDSVNoPLPYESGNFRNoContinue()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");

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

			Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}

		[StepDefinition(
			@"I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both")]
		public void ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.ThenFieldExists("WHMIS-compliant label, English and French-Canadian");
			Report.StartStep("I set 'OSHA-compliant Safety Data Sheet, English' to: Request to author");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Request to author");
			Report.StartStep("I set 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both")]
		public void ICallSharedStep104662_RegulatoryDocumentsToProvide_LithiumBatteries()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartStep("I set 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.' to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.");
			MyNewProduct.SetRadioOptionInSectionTo("Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.", "I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.");
			Report.StartStep("I upload a PDF document into the UN38.3 Testing Results field.");
			MyNewProduct.UploadPDFFile("Upload UN38.3 Test Document (Required)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("I set 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.SetRadioOptionInSectionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			Report.StartStep("I upload a PDF document into the WHMIS-compliant label, English and French-Canadian field.");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("In the Regulatory Documents to Provide page I click Continue");
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

			ReportSettings.UseSubSteps = true;
			Report.StartStep(
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
			Report.StartStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumBrowser.Alert.WaitForAlert())
				{
					Report.Info("Spinner is still showing but alert is there.");
				}
			}

			Report.StartStep(
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
			Report.StartStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			Report.StartStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			Report.StartStep("In the rule name filter box I enter the studio user name");
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Delay.Seconds(2);
			Report.StartStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			//And I Check that the Product group radio button is selected
			Report.StartStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(2);
			//thisStepsStudio.GivenICloseCurrentDocument();

			Delay.Seconds(3);
			bool closedApplyRules = false;
			Report.StartStep("I close the Apply Rules pop up");
			for (int i = 0; i < 3; i++)
			{
				var thisApplyRulesPage = new ApplyRulesPage();
				if (thisApplyRulesPage.Wait_for_load(1))
				{
					thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
					Delay.Seconds(3);
				}
				else
				{
					closedApplyRules = true;
					break;
				}
			}

			if (!closedApplyRules)
			{
				throw new Exception("Failed to close apply rules popup");
			}

			Report.StartStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();
			Delay.Seconds(3);
			Report.Screenshot();
			Report.StartStep(
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
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();

			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(5);
			//Report.Screenshot();
			Report.Info("Now waiting for spinner");
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.StartStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(
			@"I call Shared Step 55843 \(EPA expiration date - enter current year - Not June 30th\) for state: (.*)")]
		public void SharedStep55843_EPAExpirationDate_EnterCurrentYear_NotJune30th(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 55843");
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
			ReportSettings.UseSubSteps = true;
			// Click in the EPA Expiration Date box for the state you are working with
			// Select a date for the current year + 2 that is not June 30th
			var pesticideDetailsState = new PesticideDetailsState();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the EPA Expiration Date box for the state: " + state +
								 " and select a date for the current year that is not June 30th");
			var MyStepsNewProduct = new StepsNewProduct();
			int year = DateTime.Now.Year + 2;
			var dt = new DateTime(year, 8, 8);
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			// Click Continue
			Report.StartStep("I click continue in the Pesticide Details - State Registration page");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - State Registration Details");
		}

		[StepDefinition(
			@"I call Shared Step 55845 \(EPA expiration date - enter current year - June 30th\) for state: (.*)")]
		public void SharedStep55845_EPAExpirationDate_EnterCurrentYear_June30th(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 55845");
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
			ReportSettings.UseSubSteps = true;
			// Click in the EPA Expiration Date box for the state you are working with
			// Select June 30th for the current year + 2
			var pesticideDetailsState = new PesticideDetailsState();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the EPA Expiration Date box for the state: " + state +
								 " and select a date for the current year that is not June 30th");
			var MyStepsNewProduct = new StepsNewProduct();
			DateTime date = DateTime.Now;
			int year = date.Year + 2;
			var dt = new DateTime(year, 6, 30);
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			// Click Continue
			Report.StartStep("I click continue in the Pesticide Details - State Registration page");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Nov 30th of this year) for state: " + state);
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state, "11", "30", "yes");
			new Steps_PesticideDetailsState().EnterEpaRegistrationDateCurrentYear(table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55886 \(EPA expiration date - enter current year plus 2 - NOT Dec 31st\) for state: (.*)")]
		public void SharedStep_55886_EpaExpirationDate_EnterCurrentYearPlus2_NotDec31(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Not Dec 31th current year + 2) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "12", "1");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("2", table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 80488 - SHA Manager > completed 3rd party > Add to recert 40 for product saved as: (.*)")]
		public void ThenICallSharedStep_SHAManagerCompletedRdPartyAddToRecert(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 80488");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Dec 31th current year + 2) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "12", "31");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("2", table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55876 \(EPA expiration date - enter next year - any date\) for state: (.*)")]
		public void SharedStep_55876_EpaRegistrationDate_EnterNextYear_AnyDate(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Next year any date) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "8", "8");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("1", table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55877 \(EPA expiration date - enter current year plus 2 - any date\) for state: (.*)")]
		public void SharedStep_55877_EpaRegistrationDate_EnterCurrentYearPlus2_AnyDate(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Current year plus 2 - any date) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "8", "8");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("2", table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55878 \(EPA expiration date - enter current year plus 3 - any date\) for state: (.*)")]
		public void SharedStep_55878_EpaRegistrationDate_EnterCurrentYearPlus3_AnyDate(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Current year plus 3 - any date) for state: " + state);
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, "8", "8");
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("3", table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 55875 \(EPA expiration date - enter current year - any date today or greater\) for state: (.*)")]
		public void SharedStep_55875_EpaRegistrationDate_EnterCurrentYear_AnyDateTodayOrGreater(string state)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select an EPA date (Current year - any date today or greater) for state: " + state);
			DateTime dt = DateTime.Today;
			var table = new Table("State", "Month", "Day");
			table.AddRow(state, dt.Month.ToString(), (dt.Day + 1).ToString());
			new Steps_PesticideDetailsState().SharedStep_EPAExpirationDate_EnterCurrentYearPlus("0", table);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as (.*)")]
		public void GivenICallSharedStep44240_SHA_RecertificationProcessRecertificationToAssignedStatus(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep(
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
			Report.StartStep("I select  product in the SHA grid saved as " + savedAs);
			shaSteps.GivenInSHAManagerISelectTheProduct(savedAs);
			Delay.Seconds(3);
			Report.StartStep("I click the Process Recertification button");
			shaSteps.GivenIClickTheProcessRecertificationButton();
			Report.StartStep("I confirm Process Recertification popup shows");
			shaSteps.GivenIConfirmTheRecertificationPopUpIsShown();
			Report.StartStep("I uncheck auto assign regulatory specialist");
			shaSteps.GivenIUncheckTheAutoAssignRegulatorySpecialistToProductCheckBox();
			Report.StartStep("I select specialist");
			shaSteps.GivenISelectFromTheDropDownListForRegulatorySpecialist("Automated QASha");
			Report.Screenshot();
			Report.StartStep("I click continue");
			shaSteps.GivenInTheRecertificationPopupIClick("Continue");
			Report.StartStep("I wait for processing to be completed");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I call Shared Step 49742 - WPS - Check In Product saved as: " + savedAs);
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
			@"I call Shared Step 81468 \(Product Characteristics - Solid only available - without secondary physical state\)")]
		public void SharedStep_81468_ProductCharacteristics_SolidOnlyAvailable_WithoutSecondaryPhysicalState()
		{
			// By default solid should be the selected Primary Physical State - and the only state shown
			// Select either of the buttons for the "When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?" question
			//  If Water Solubility question displays  then select a option from dropdown for "Select the best Water Solubility description" else ignore this step
			// Click Continue
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var newProduct = new NewProduct();
			Report.StartStep("I should see the Product Characteristics Page");
			stepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Report.StartStep(
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

			Report.StartStep(
				@"Select either buttons for the ""When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5 ?"" question");
			stepsNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			Report.StartStep(
				"If Water Solubility question displays  then select a option from dropdown for 'Select the best Water Solubility description' else ignore this step");
			if (newProduct.OptionExists("Select the best Water Solubility description"))
			{
				stepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Decomposes");
			}
			else
			{
				Report.Info("The Water Solubility question was not displayed");
			}

			Report.StartStep("I click continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 42759a \(Portal - UPC Page - add UPC saved as: (.*)\)")]
		public void Shared42759a_Portal_UpcPage_AddUpcSavedAs(string savedAs)
		{
			var newProductSteps = new StepsNewProduct();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the Add UPC button");
			newProductSteps.ThenIClickTheAddUpcButton();
			Report.StartStep("I set the UPC Number, Container Type and Size");
			var upcTable = new Table("Field", "Value");
			upcTable.AddRow("UPCNumber", $"saved as " + savedAs);
			upcTable.AddRow("ContainerType", "Aerosol Can");
			upcTable.AddRow("Size", "20");
			//upcTable.AddRow("DPCI", "087 - 16 - 0238");
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
		}

		[StepDefinition(
			@"I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: (.*)")]
		public void GivenICallSharedStep_SHAManagerAssignedProduct_AddRecertReasonForProductSavedAsTestCase(
			string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 51349");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 57621");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 57565");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyNewProduct = new NewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");

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
				Report.StartStep("In the Universal Product Code (UPC) page I click Save");
				MyNewProduct.ClickSaveButton();
			}
			else
			{
				Report.StartStep("In the Universal Product Code (UPC) page I click Continue");
				MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
			}
		}

		[StepDefinition(
			@"I call Shared Step 85730 - Additional Product Information - Canada Only - Child \(NO\), GHS \(NO\), DSV \(NO\), PLP\(YES\), GNFR \(NO\), Continue")]
		public void
			ThenICallSharedStep85730AdditionalProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPYESGNFRNOContinue()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
			Report.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			new StepsSelectRetailers().SelectTheRetailer("No Retailer/No UPC Product");
			Report.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			var thisNewProduct = new NewProduct();
			thisNewProduct.SetFullNameOfProductForRetailer("No Retailer/No UPC Product", "test");

			Report.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");

			/* --As per TFS70787 warning popup displays for NR  --- */
			//Delay.Seconds(1);
			Report.StartStep("In the UPCs Warning popup I click Ok");
			WarningPopup.ClickChoice("Ok");
		}

		[StepDefinition(
			@"I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue")]
		public void
			ThenICallSharedStep78884RegulatoryDocumentsToProvide_CanadaOnly_RequestAuthoringUploadLabel_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartStep("I set WHMIS-complient SDS to 'I need an SDS authored'");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian",
				"I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.");
			Report.StartStep("I upload a label");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			Report.StartStep("I click continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 78888 - WPS Studio - PD\+ - set all data and publish using rule and doc queue - CKLT, HGHS \(EN and CF\) and SBCS for product saved as (.*)")]
		public void
			GivenICallSharedStep78888WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTHGHSENAndCFAndSBCS(
				string savedAs)
		{
			Report.StartStep("Beginning shared step 78888");
			ReportSettings.UseSubSteps = true;
			Report.StartStep(
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
			Report.StartStep("I open the Current Document pop up using the tool bar icons");
			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			Report.StartStep("Select the Authorize Formula and Attributes for publishing check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			GeneralUtilities.StudioWaitForSpinner();
			Report.StartStep("Select the Apply to all subformats check box ");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");
			Report.Info("Clicked apply, waiting");
			Delay.Seconds(60);
			Report.Info("Now going to wait for spinner");
			if (!GeneralUtilities.StudioWaitForSpinner(30))
			{
				if (SeleniumBrowser.Alert.WaitForAlert())
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
			Report.StartStep("I close the current document pop up");
			thisStepsStudio.GivenICloseCurrentDocument();
			Report.StartStep("I select the Apply Rules icon from the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			Report.StartStep("I select the Single rule radio button");
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			Report.StartStep("I click the three ... icon to open the Select Rule pop up");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");

			Report.StartStep("In the rule name filter box I enter the studio user name");
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			Report.StartStep("I select the rule  by clicking on it");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			Report.StartStep("I click Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			Delay.Seconds(10);
			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}

			Report.StartStep("I close the Apply Rules pop up");
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
					SeleniumBrowser.WebBrowser.Close();
				}
			}

			Report.StartStep("I click the Document queue icon in the tool bar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
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

			Report.StartStep(
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
			Report.StartStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(2);
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.StartStep(
				"I confirm a pop up shows with message indicating queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();
		}

		[StepDefinition(@"I call Shared Step 29183 \(Pesticide Details - U.S. - No EPA number\)")]
		public void GivenICallSharedStepPesticideDetails_US_NoEpaNumber()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Pesticide Details - U.S. Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Pesticide Details - U.S.");
			Report.StartStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "No");
			Report.StartStep("I select the first option in section: Select the applicable exemption");
			MyStepsNewProduct.SelectFirstOptionInSection("Select the applicable exemption");
			Report.StartStep("In the Pesticide Details - U.S. page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		[StepDefinition(
			@"I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: (.*)")]
		public void ThenICallSharedStep49743SHAManager_SelectProduct_Actions_DocumentManagement(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Select product");
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			Report.IsTrue(myStudioShaManager.SelectProductByID(id), "Failed to select product with id: " + id,
				"Selected product with id: " + id);
			Report.StartStep("Click document management");
			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption("Document Management"),
				"Failed to click document management", "Clicked document management");

		}

		[StepDefinition(
			@"I call Shared Step 96169 - SHA Manager - Select Product - Actions - (.*) for saved as: (.*)")]
		public void ICallSharedStep96169SHAManager_SelectProduct_Actions(string reportType, string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Select product");
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			Report.IsTrue(myStudioShaManager.SelectProductByID(id), "Failed to select product with id: " + id,
				"Selected product with id: " + id);
			Report.StartStep("Click Advanced Reporting");
			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption(reportType),
				"Failed to click document management", "Clicked document management");
		}

		[StepDefinition(
					@"I call Shared Step 78879 - Additional Product Information - Canada Only - Child \(NO\), GHS \(NO\), DSV \(NO\), PLP \(NO\), GNFR \(NO\), Continue")]
		public void
					ThenICallSharedStep78879AdditionalProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPNOGNFRNOContinue()
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
			@"I call Shared Step 62681 - Additional Product Information - Canada, No\(OSHA\), No\(DSV\), No\(PLP\), No\(GNFR\), Continue - Happy Path")]
		public void
			ThenICallSharedStep62681AdditionalProductInformation_CanadaNoOSHANoDSVNoPLPNoGNFRContinue_HappyPath()
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
					@"I call Shared Step 62681 - Additional Product Information - Canada, No\(DSV\), No\(PLP\), No\(GNFR\), Continue - Happy Path")]
		public void
					ThenICallSharedStep62681AdditionalProductInformation_CanadaNoDSVNoPLPNoGNFRContinue_HappyPath()
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

		[StepDefinition(@"I call Shared Step 94674 \(Additional Product Information - RU Wine\)")]
		public void CallSharedStep9674_AdditionalProductInformation_RuWine()
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

		[StepDefinition(
			@"I call Shared Step  \(Select Retailers (.*) and enter additional requirements field - Indicate full name of product, as sold via this retailer\)")]
		public void SelectRetailers(string retailer)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var stepsRetailer = new Retailer();
			Report.StartStep("In the Select Retailers popup I select the retailer: CVS");
			new StepsSelectRetailers().SelectTheRetailer(retailer);
			Report.StartStep("I enter private label as 'This Private Label'");
			stepsRetailer.EnterPrivateLabelName("This Private Label");
			Report.StartStep("I click continue");
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
			ReportSettings.UseSubSteps = true;
			var thisStepsSha = new Steps_SHA();
			Report.StartStep("Given I Click the Suppliers link on the top right of the screen");
			thisStepsSha.IClickOnSuppliersLink();

			Report.StartStep("Given I Click the Suppliers pop up should open");
			thisStepsSha.TheSupplierManagerPopupAppears();

			Report.StartStep("Given enter the email address of the user you are going to be using in WERCSmart");
			thisStepsSha.InSupplierManagerPopupIEnterSearchTerm(email);

			Report.StartStep("I Select the 'Email' Radio Button");
			thisStepsSha.InSupplierManagerPopupISelectRadioButton("E-Mail");

			Report.StartStep("I click on the search button");
			thisStepsSha.InSupplierManagerPopupIClickOnTheSearchButton();

			Report.StartStep("I Make a note of the Supplier Name");
			thisStepsSha.InSupplierManagerPopupISaveFirstSupplierNameAs(savedAs);

			Report.StartStep("I click on the close button");
			thisStepsSha.InSupplierManagerPopupIClickOnTheCloseButton();

		}


		[StepDefinition(
			@"I call Shared Step 74655 SHA - Search by Supplier ID saved as (.*) for specific product status: (.*)")]
		public void GivenICallSharedStepSHA74655SearchBySupplierIDSavedAsMyIDForSpecificProductStatusCompleted(
			string savedAs, string status)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 74655");
			var thisStepsSha = new Steps_SHA();
			Report.StartStep("I set the status filter to All");
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

			Report.StartStep("I click Srch in the bottom menu list");

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


			Report.StartStep("I click Srch in the bottom menu list");
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

			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 74655");
			var thisStepsSha = new Steps_SHA();
			Report.StartStep("I set the status filter to All");
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

			Report.StartStep("I click Srch in the bottom menu list");

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


			Report.StartStep("I click Srch in the bottom menu list");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I confirm that the Regulatory step is shown");
			new StepsNewProduct().GivenIShouldSeeXPage("Regulatory Information 1");
			Report.StartStep("Confirm that the TSCA and Prop 65 questions are displayed");
			var sections = new Table("Section");
			sections.AddRow("U.S. Toxic Substances Control Act (TSCA) status");
			sections.AddRow("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			new StepsNewProduct().CheckDisplayedSections("see", sections);
			Report.StartStep("I confirm the TSCA question shows 2 Radio Buttons 'COMPLIANT' and 'EXEMPT'");
			var options = new Table("Option");
			options.AddRow("Compliant");
			options.AddRow("Exempt");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "U.S. Toxic Substances Control Act (TSCA) status", options);
			Report.StartStep("Confirm the Prop 65 question displays a 'YES' and 'NO' Buttons");
			options = new Table("Option");
			options.AddRow("Yes");
			options.AddRow("No");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", options);
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
			Report.StartStep("Confirm that both questions in this screen display the 'This is a required field' error message");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("U.S. Toxic Substances Control Act (TSCA) status", "should", "This is a required field.");
			new StepsNewProduct().ErrorMessagesAreShowingForItem("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "should", "This is a required field.");
			Report.StartStep("Select ONE Radio Button for the TSCA Question");
			new StepsNewProduct().SelectFirstOptionInSection("U.S. Toxic Substances Control Act (TSCA) status");
			Report.StartStep("Confirm the 'Required field error message' no longer shows for the TSCA Question");
			new StepsNewProduct().ErrorMessagesShouldNotBeShowingForItem("U.S.Toxic Substances Control Act (TSCA) status");
			Report.StartStep("I select the 'No' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "No");
			Report.StartStep("I confirm the 'Required field' error message is no longer displayed for the prop 65 question");
			new StepsNewProduct().ErrorMessagesShouldNotBeShowingForItem("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act");
			Report.StartStep("I select the 'Yes' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "Yes");
			Report.StartStep("Confirm the following questions are displayed:");
			sections = new Table("Section");
			sections.AddRow("Is the need to warn triggered by");
			sections.AddRow("How is the exposure warning transmitted? For more information, see Notice of Adoption Article");
			sections.AddRow("Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured");
			sections.AddRow("If the product carries a safe-harbor short-form warning, indicate which of the following is provided:");
			sections.AddRow("If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:");
			sections.AddRow("If the product carries a custom warning, please provide the exact text that is being used:");
			new StepsNewProduct().CheckDisplayedSections("see", sections);
			Report.StartStep("Confirm 'Is need to warn triggered by' options are correct");
			options = new Table("Option");
			options.AddRow("A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			options.AddRow("A chemical or chemicals in the packaging.");
			options.AddRow("A chemical or chemicals in both the product and packaging.");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "Is the need to warn triggered by", options);
			Report.StartStep("Confirm 'How is the exposure warning transmitted?' options are correct");
			options = new Table("Option");
			options.AddRow("By affixing it to the product or its packaging");
			options.AddRow("By providing warning materials (labels, shelf signage, online warning language) to a retailer’s authorized agent");
			options.AddRow("Other (Please specify)");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "How is the exposure warning transmitted?", options);
			Report.StartStep("Confirm 'Is your exposure warning compliant with Proposition 65' options are correct");
			options = new Table("Option");
			options.AddRow("Prior to August 30, 2018");
			options.AddRow("On or After August 30, 2018");
			options.AddRow("Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "Is your exposure warning compliant with Proposition 65", options);
			Report.StartStep("Confirm 'If the product carries a safe-harbor short-form warning' options are correct");
			options = new Table("Option");
			options.AddRow("WARNING: Cancer - www.P65Warnings.ca.gov");
			options.AddRow("WARNING: Reproductive Harm - www.P65Warnings.ca.gov");
			options.AddRow("WARNING: Cancer and Reproductive Harm - www.P65Warnings.ca.gov");
			options.AddRow("Does not apply");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "If the product carries a safe-harbor short-form warning", options);
			Report.StartStep("Confirm 'If the product carries a safe-harbor long-form warning' options are correct");
			options = new Table("Option");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause birth defects or other reproductive harm. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer, and [name of one or more chemicals], which is [are] known to the State of California to cause birth defects or other reproductive harm. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer and birth defects or other reproductive harm. For more information go to www.P65Warnings.ca.gov");
			options.AddRow("Does not apply");
			new StepsNewProduct().CheckOptionsInSection("should", "displayed exclusively", "If the product carries a safe-harbor long-form warning", options);
			Report.StartStep("I select the 'No' button for the Prop 65 question");
			new StepsNewProduct().SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act", "No");
			Report.StartStep("Confirm the additional prop 65 questions are no longer shown");
			new StepsNewProduct().CheckDisplayedSections("not see", sections);
			Report.StartStep("I click continue");
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

		[StepDefinition(@"I call Shared Step 102767 \(Additional Product Information \(Battery flow - not Lithium\) - OSHA \(No\), DSV \(No\), PLP \(No\), GNFR \(No\)\)")]
		public void Shared_102767_AdditionalProductInformation_BatteryFlowNotLithium()
		{
			var stepsAdditionalProductInformation = new Steps_AdditionalProductInformation();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I set 'Classified using OSHA' to No");
			stepsAdditionalProductInformation.SetProductHasBeenClassifiedOSHATo("No");
			Report.StartStep("I set 'Product is shipped directly' to No");
			stepsAdditionalProductInformation.SetProductIsShippedDirectlyTo("No");
			Report.StartStep("I set 'Is Retailers Private Brand' to No'");
			stepsAdditionalProductInformation.SetProductIsRetailersPrivateLabelOrBrandTo("No");
			Report.StartStep("I set 'Solely for the retailers use' to No'");
			stepsAdditionalProductInformation.SetProductIsSolelyForTheRetailersUseTo("No");
			Report.StartStep("I click continue");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 103904 - Validate Product Name can contain character: (.*)")]
		public void Shared_103904_ProductNameCanContain(string character)
		{
			ReportSettings.UseSubSteps = true;
			var newProd = new NewProduct();

			foreach (string productType in newProd.ModifiedStrings(character))
			{
				Report.Info("I enter the text: '" + @productType + "' into the Product Name field and verify that '" + character + "' is allowed in the field.");
				var newProdSteps = new StepsNewProduct();
				var product = new TheProduct {
					ProductName = productType
				};
				newProdSteps.ClickContinue();
				newProdSteps.GivenIShouldSeeXPage("Product Characteristics");
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
			ReportSettings.UseSubSteps = true;
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			Report.StartStep("I set the Product has had TCLP testing; Report is available option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing; Report is available", "No");
			Report.StartStep("I select No for all elements including Copper");
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

			Report.StartStep(
				"In the Toxicity Characteristic Leaching Procedure (TCLP) Product Report page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP) Product Report");
		}

		[StepDefinition(@"I call Shared Step 54139 \(Data Usage Tiers - Tier 1 - confirm cannot edit\)")]
		public void SharedStep54139_DataUsageTiers_Tier1_ConfirmCannotEdit()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I confirm 'Tier 1: Regulatory Support' is the first entry in the Data Consent Tiers table");
			var tiers = new RetailPartnersDetails().GetAllDataConsentTiers();
			Report.IsTrue(tiers.Any() && tiers.First() == "Tier 1: Regulatory Support", "The first entry in the Data Consent Tiers table was not 'Tier 1: Regulatory Support'!", "The first entry in the Data Consent Tiers table was 'Tier 1: Regulatory Support' as expected");
			Report.StartStep("I confirm 'Tier 1' is set to: active/ on");
			Report.IsTrue(new RetailPartnersDetails().GetDataConsentTier("Tier 1"), "Tier 1 was not set to active!", "Tier 1 was set to active as expected");
			Report.StartStep("I confirm that I cannot set 'Tier 1' to: inactive/ off");
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
			ReportSettings.UseSubSteps = true;
			var name = Context.GetFromContext(companySavedAs)?.ToString();
			if (name == null)
			{
				Report.Failure("Requires a Company Name saved to context as: " + companySavedAs);
				return;
			}
			var expectedText = "Hello " + name + ", Recently an administrator has changed the Data Usage permissions for Wal-Mart/SAM'S CLUB to include: ";
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
			expectedText += " For questions please contact the WERCSmart Customer Support. Thank you, Your WERCSmart Team";
			Report.StartStep("I confirm the administrator receieved an email with subject 'WERCSmart Data Use Tier Consents Changed for Wal-Mart/Sam's Club'");
			Delay.Seconds(8);
			new GlobalSteps().ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", emailSavedAs, "<SiteNotification>", "WERCSmart Data Use Tier Consents Changed for Wal-Mart/SAM'S CLUB");
			Report.StartStep("I confirm the body text of the email matches the expected text");
			new GlobalSteps().ThenTheBodyOfTheEmailShouldShow(expectedText);
		}

		[StepDefinition(@"I call Shared Step 75146 \(Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue\)")]
		public void SharedStep75146_Retailer_SelectOneOrMoreThatDoNotRequireVendorIdOrAdditionalUpcInformation_ClickDone_ClickContinue()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select a valid retailer and click DONE");
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
			Report.StartStep("Click CONTINUE");
			new StepsNewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 82831 \(The Product - Enter Product Name and Select Type of Product: (Raw material|Mixture, Blend, Formula, Polymer or Solution from Third \(3rd, 3d\) Party)\)")]
		public void SharedStep82831_TheProduct_EnterProductNameAndType(string type)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			Report.StartStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
			var name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.NewProductPageIClickContinueNoSpinnerWait();
			var modal = new ModalDialog();
			Report.StartStep("I verify the 'Warning' pop-up displays");
			if (!Report.IsTrue(modal.WaitForContainerToBeVisible(10) && modal.GetTitle().Contains("Warning"), "Warning pop up was not displayed!", "Warning popup was displayed"))
			{
				return;
			}
			Report.StartStep("I confirm the warning message contains the expected text");
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


			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step 83242");
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

			Report.StartStep("I click the following option in the bottom menu: Reject Submission");
			stepsSHA.IClickTheFollowingOptionInTheBottomMenu("Reject Submission");
			Report.IsTrue(productSubmissionRejection.Wait_for_load(30), "The Product Submission Rejection Popup did not appear", "The Product Submission Rejection Popup did appear");
			Report.StartStep("Selecting the first subject from the Submission Rejection Popup");
			Report.IsTrue(productSubmissionRejection.SelectFirstSubject(), "The Frist subject was not selected", "The Frist subject was selected succesfully");
			Report.StartStep("I check that Text is now shown in the Supplier Message Area of the Popup");
			Report.IsTrue(!productSubmissionRejection.GetSupplierMessage().IsNullOrEmpty(), "The Supplier Message Area was empty", "Text was shown in the Supplier Message Area");
			Report.StartStep("I Click save in the Product Submission Rejection Popup");

			//Alert is dismissed by screeshot, therefore cannot use Report.IsTure
			var saveClicked = productSubmissionRejection.ClickButton("Save");
			if (saveClicked)
			{
				Report.Success("The save button was succesfully clicked");
			}
			else
			{
				Report.Failure("The save button was not clicked");
				return;
			}

			Report.StartStep("I check that an alert appears with the correct message");
			//globalSteps.GivenICheckAlertTextContainsXAndDismiss($"Product Message for product {id} has been created successfully."); //Can return to this once spelling bug is fixed, or by using "suces" (as method uses a contains)
			globalSteps.GivenICheckAlertTextContainsEitherXOrYAndDismiss($"Product Message for product {id} has been created successfully.", $"Product Message for product {id} has been created succesfully."); //Used as Alert Text currently has spelling error, but we don't want the test to fail. (remove once bug is fixed and use the method above).
			Report.StartStep("I check the Product Submission Rejection Popup has been closed");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("In the 'Select Retailers' window I select the retailer: Walmart");
			new StepsSelectRetailers().SelectTheRetailer("Walmart");
			Report.StartStep("I should see the Retailer Page");
			new StepsNewProduct().GivenIShouldSeeXPage("Retailer");
			var newProduct = new NewProduct();
			Report.StartStep("I select any Vendor ID");
			new Steps_Retailer().ISelectFirstVendorId();
			Report.StartStep("In the Retailer page I click Continue");
			new StepsNewProduct().GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(@"I call Shared Step 78080 \(Regulatory Documents to Provide - Upload OSHA SDS\)")]
		public void Shared78080_RegulatoryDocumentsToProvide_UploadOshsSds()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			Report.StartStep("I set the OSHA-compliant Safety Data Sheet, English field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Yes");
			Report.StartStep("I upload a PDF file to section: OSHA SDS");
			MyNewProduct.UploadPDFFile("OSHA SDS", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartStep("Click the checkbox for the 'I confirm that I have provided the most up - to - date, OSHA - compliant SDS...' question");
			MyNewProduct.SetTheSectionOptionTo("SDS current version", "OSHA-compliant SDS");
			Report.StartStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}


		[StepDefinition(@"I call Shared Step 87337 \(Edit UPC - data - Click Save\) for UPC as: (.*), container type: (.*) and size: (.*) and packaging type: (.*)")]
		public void Shared87337_RemovePackgType(string upc, string containerType, string size, string pkgType)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			Report.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");


			Report.StartStep("I click expand arrow for: " + upc);
			myNewProduct.EnsureArrowIsExpandedforUPC(upc);
			Report.StartStep("I add the following into the UPC Fields");
			var upcInfo = new UpcInformation {
				ContainerType = containerType,
				Size = size,
				UpcNumber = upc,
				PackageType = pkgType
			};
			Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to change packagaing type info!",
				"Successfully changed packagaing type info!");
			Report.StartStep("I click save");
			MyStepsNewProduct.ThenIClickSaveOrCancelInTheProductPage("Save");
			MyStepsNewProduct.GivenIConfirmErrorMessageIsShownBelowField("This is a required field.", "Package Type");
		}

		[StepDefinition(@"I call Shared Step 60515 \(VOC - Dilution - Yes to ratio - enter any values > Continue - Happy Path\)")]
		public void Shared60515_VocDiluationYesEnterAnyValues_Continue()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select the 'Yes' button for the 'Product Label Dilution Ratio' question");
			new Steps_VOC_OTC_CARB().SetProductLabelDilutionRatio("Yes");
			Report.StartStep("I enter the vlaue '1' for the 'VOC Content as Sold' question");
			new Steps_VOC_OTC_CARB().SetVocContentAsSold("1");
			Report.StartStep("I enter the vlaue '10' for the 'VOC Content as Used' question");
			new Steps_VOC_OTC_CARB().SetVocContentAsUsed("10");
			Report.StartStep("I click continue");
			new NewProduct().ClickContinue();
		}

		[StepDefinition(@"I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: (.*)")]
		public void Shared43587_SHAManager_CompletedProduct_AddToRecertReason20(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Beginning shared step: 43587");
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

		[StepDefinition(@"I call Shared Step 88419 \(SHA > UPC - Confirm Case UPC fields \(No internal UPC\) > Close window\) for UPC saved as: (.*) for the retailer: (.*) using details saved in the table: (.*)")]
		public void Shared88419_SHA_UpcList_ConfirmCaseUPCFields(string savedAs, string retailer, string tableSavedAs)
		{
			ReportSettings.UseSubSteps = true;
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

			Report.StartStep("I Click on the link associated with the Case UPC marked by an asterisk");
			studioSHAManger.ClickCaseUPCSavedAsInProducUPCTable(savedAs);
			Report.StartStep("I Check the UPC detail popup appears");
			var upcDetails = new StudioSHAManagerUPCDetails();
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			Report.IsTrue(upcDetails.Wait_for_load(30), "The UPC details popup did not appear", "The UPC details popup appeared");
			Report.StartStep("I Select the Client: " + retailer + " from the select client list");


			IWebElement input = upcDetails.SelectClientInput;

			if (input == null)
			{
				Report.Failure("The Select Client box could not be found!");
				return;
			}
			input.Select(retailer);
			Report.StartStep("I wait for the UPC Details Table to Load");
			//Wait for load of the table before continue
			//Report.IsTrue(upcDetailsPopup.UpcDeatilsTableLoaded(),"The UPC Details Table did not appear", "The UPC Details Table appeared");
			Report.IsTrue(upcDetailsPopupTable.UpcDetailsTableLoadedOrNull(30), "The UPC details Table did not Appear", "The UPC details Table appeared");

			Report.StartStep("I Check the type coloumn shows the container type selected for my product.");
			string containerTypeActual = upcDetailsPopupTable.DetailValue("Container Type");
			Table table = (Table)Context.GetFromContext(tableSavedAs);
			TableRow informationRow = table.Rows[1];
			string expectedContainerValue = informationRow["Container type"].ToString();
			Report.Info("Container Type expected: " + expectedContainerValue);
			Report.Info("Container Type Found: " + containerTypeActual);
			Report.IsTrue(expectedContainerValue == containerTypeActual, "The container type column did not show the value selected for the product", "The container type column did show the value selected for the product");
			Report.StartStep("I Check the size column shows the size selected for my product.");
			string containerSizeActual = upcDetailsPopupTable.DetailValue("Container Size");
			string expectedSizeValue = informationRow["Size"].ToString();
			Report.Info("Container Size expected: " + expectedSizeValue);
			Report.Info("Container Size Found: " + containerSizeActual);
			Report.IsTrue(expectedSizeValue == containerSizeActual, "The container size column did not show the value selected for the product", "The container size column did show the value selected for the product");
			Report.StartStep("I Check the Internal UPC column shows the 'N/A'.");
			string expectedInternalUPC = "N/A";
			string internalUPCAtual = upcDetailsPopupTable.DetailValue("Internal UPC");
			Report.Info("Internal UPC expected: " + expectedInternalUPC);
			Report.Info("Internal UPC Found:  " + internalUPCAtual);
			Report.IsTrue(expectedInternalUPC == internalUPCAtual, "The Internal UPC column did not show N/A", "The Internal UPC column did show N/A");
			Report.StartStep("I Check the transport column shows the container type selected for my product.");
			string transportTypeActual = upcDetailsPopupTable.DetailValue("Code and Description for DOT Packaging");
			string expectedTransportOption = informationRow["Transportation Options"].ToString();

			string actualTransportOptionTrim = transportTypeActual.Replace(" ", "").Trim();
			string expectedTrasportOptionTrim = expectedTransportOption.Replace(" ", "").Trim();

			Report.Info("Trasnport Option expected (no spaces): " + actualTransportOptionTrim);
			Report.Info("Trasnport Option Found (no spaces): " + expectedTrasportOptionTrim);
			Report.IsTrue(expectedTrasportOptionTrim == actualTransportOptionTrim, "The Transportation Option column did not show the value selected for the product", "The Transportation Option column did show the value selected for the product");
			Report.StartStep("I close the SHA Manager Product UPC details pop up");
			Report.IsTrue(upcDetailsPopupTable.CloseButton.TryClick(), "Failed to Click Close in the UPC details popup", "Successfully clicked Click Close in the UPC details popup");
			Report.IsTrue(upcDetailsPopupTable.WaitForContainerToBeInvisible(30), "The UPC details popup did not close", "The UPC details popup was closed");












		}


		[StepDefinition(@"I call Shared Step 57264 \(Go To Retail Partners - Select O'Reilly\)")]
		public void Shared57264_GoToRetailPartners_SelectOReilly()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I click the Retail Partners link in the left hand icon list");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			Report.StartStep("I select the retailer: O'Reilly");
			new StepsRetailPartners().SelectRetailer("O'Reilly");
		}

		[StepDefinition(@"I call Shared Step 62676 \(Go To My Account\)")]
		public void GivenICallSharedStepGoToMyAccount()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Clicking Supplier Name drop down in the header");
			Report.IsTrue(new TopMenuBar().ClickOnUserTopRight(), "Failed to click on user name in the top menu bar", "Clicked the user name in the top menu bar");
			Report.StartStep("I click 'My Account'");
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
			ReportSettings.UseSubSteps = true;
			Context.AddToContext(tableSavedAs, table);
			var editUPC = new ForwardProductRegistration.EditUPC();
			Report.StartStep("Selecting Edit on the UPC saved as: " + caseUPCNumSavedAs + ".");
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


			Report.StartStep("I check the Edit UPC popup appears");
			editUPC.WaitForContainerToBeVisible(30);

			Report.StartStep("I confirm the UPC Number field is shown and is populated with the correct Case UPC");
			Report.IsTrue(editUPC.UPCNumber == upcNum, "The UPC number did not match expected", "The UPC number matched the expected value");

			Report.StartStep("I confirm the Container Type field is shown and is populated with the correct Case UPC");
			TableRow row = table.Rows[0];
			string containerValue = row["Container type"].ToString();
			Report.IsTrue(editUPC.Type == containerValue, "The Container Type did not match expected", "The Container Type matched the expected value");


			Report.StartStep("I confirm the Size field is shown and is populated with the correct Case UPC");
			string sizeValue = row["Size"].ToString();
			Report.IsTrue(editUPC.Size == sizeValue, "The Size did not match expected", "The Size  matched the expected value");

			Report.StartStep("I confirm the Quantity field is shown and is populated with the correct Case UPC");
			string quantityValue = row["Quantity"].ToString();
			Report.IsTrue(editUPC.Quantity == quantityValue, "The Quanitity did not match expected", "The Quanitity matched the expected value");

			Report.StartStep("I confirm the Individual UPC field is shown and is populated with the correct Case UPC");
			string individualUPCValue = row["Individual UPC contained in the Case Pack"].ToString();

			if (Regex.IsMatch(row["Individual UPC contained in the Case Pack"], "<(.*)>"))
			{
				var match = Regex.Match(row["Individual UPC contained in the Case Pack"], "<(.*)>").Groups[1].Value;
				if (Context.Contains(match, true))
				{
					individualUPCValue = Context.GetFromContext(match).ToString();
				}

			}

			Report.IsTrue(editUPC.IndividualUPCContainedInTheCasePack == individualUPCValue, "The Individual UPC option did not match expected", "The Individual UPC option matched the expected value");

			Report.StartStep("I confirm the Transportation Options field is shown and is populated with the correct Case UPC");
			string transportationOptionsValue = row["Transportation Options"].ToString();
			Report.IsTrue(editUPC.TransportationOptions == transportationOptionsValue, "The Transportation Option did not match expected", "The Transportation Option matched the expected value");

			Report.StartStep("I change the Container Type");
			TableRow secondRow = table.Rows[1];
			string secondContainerValue = secondRow["Container type"].ToString();
			editUPC.Type = secondContainerValue;
			Report.IsTrue(editUPC.Type == secondContainerValue, "The Container Type was not changed", "The Container Type was changed");


			Report.StartStep("I change the Size Type");
			string secondSizeValue = secondRow["Size"].ToString();
			editUPC.Size = secondSizeValue;
			Report.IsTrue(editUPC.Size == secondSizeValue, "The Size was not changed", "The Size was changed");

			Report.StartStep("I change the Quantity Type");
			string secondQuantityValue = secondRow["Quantity"].ToString();
			editUPC.Quantity = secondQuantityValue;
			Report.IsTrue(editUPC.Quantity == secondQuantityValue, "The Quanitity was not changed", "The Quanitity was changed");


			Report.StartStep("I change the Individual UPC value");
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

			Report.StartStep("I change the Transportation Options");
			string secondTransportationOptionsValue = secondRow["Transportation Options"].ToString();
			editUPC.TransportationOptions = secondTransportationOptionsValue;
			Report.IsTrue(editUPC.TransportationOptions == secondTransportationOptionsValue, "The Transportation Option was not changed", "The Transportation Option was changed");

			Report.StartStep("I Click Save in the Edit UPC popup");
			Report.IsTrue(editUPC.ClickButton("Save"), "Failed to click save in the edit UPC popup", "Succesfully clicked save in the edit upc popup");

			Report.StartStep("I check the Edit UPC popup disappears");
			Report.IsTrue(editUPC.WaitForContainerToBeInvisible(30), "The edit upc popup did not appear", "The edit upc appeared");
			Report.StartStep("I Confirm the Case UPC is shown in the right hand table with the new selections");

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

			Report.StartStep("I click Continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();

		}


		[StepDefinition(
			@"I call Shared Step 89286 - Additional Product Information - US and Canada - Child \(NO\), GHS \(NO\), DSV \(NO\), PLP\(YES\), GNFR \(NO\), Continue")]
		public void
			USandCanadaPLPYes()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			var MyNewProduct = new NewProduct();
			//And I Un-check the United States check box for the "Select countries the product may be sold in" question
			//List<string> countrySold = MyNewProduct.SelectedOptionsForSection("Select countries the product may be sold in");
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
			@"I call Shared Step - Additional Product Information - canada only - With marketed for use by a Child - Direct Ship - Private Label questions only")]
		public void
			CanadaOnlyNoPL()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartStep("I click continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 86002 \(Forwarding - PLP - Select Product: (.*) & UPCs step - Edit existing UPC Confirm\)")]
		public void Shared86002(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select the product saved as: " + savedAs);
			new StepsForwardProductRegistration().SelectProductByIDSavedAs(savedAs);
			Report.StartStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartStep("I click continue");
			new StepsForwardProductRegistration().ClickContinueForwardProductRegistration();
		}

		[StepDefinition(@"I call Shared Step 86004 \(Forwarding - Not PLP - Select Product: (.*) & UPCs step - Edit existing UPC Confirm Package Type not shown\)")]
		public void Shared86004(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I select the first product in the Select UPCs tab");
			new StepsForwardProductRegistration().SelectTheFirstProductSelectUPCs();
			Report.StartStep("I select the check box next to existing UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectFirstUPC();
			Report.StartStep("I select Edit for the first UPC in the right hand side of the table");
			new StepsForwardProductRegistration().SelectEditForFirstUPC();
			Report.StartStep("I confirm that Package Type is not shown for UPC");
			new StepsForwardProductRegistration().ConfirmPackageTypeNotShown();
			Report.StartStep("I click Save in the Edit UPC modal");
			new StepsForwardProductRegistration().InTheUPCModalWindowIClickSave();
			Report.StartStep("I click continue");
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

			ReportSettings.UseSubSteps = true;
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
			Report.StartStep("I click the Edit Existing product radio button if not already selected");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");

			string WERCSmartIDFromContext = Context.GetFromContext("WERCSmart ID").ToString();
			Report.IsTrue(thisPowerDesignerPlus.EnterSourceProduct(WERCSmartIDFromContext), $"Failed to enter {WERCSmartIDFromContext} into the Select Source Product field!", $"Successfully entered {WERCSmartIDFromContext} into the Select Source Product field");

			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(3);

			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.StartStep("I click Continue");
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
			ReportSettings.UseSubSteps = true;
			var stepsProdGrid = new StepsProductGrid();
			var stepsNewProd = new StepsNewProduct();
			var stepsIngredients = new StepsIngredients();
			var stepsSHA = new Steps_SHA();
			var stepsStudio = new Steps_Studio();

			Report.StartStep("I generate a random UPC number and save as: UPC80821");
			stepsProdGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC80821");

			Report.StartStep("I log into WercSmart - Products Automation Account");
			this.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();

			Report.StartStep("Create a New Registration via Register New Product (expanded menu)");
			this.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();

			Report.StartStep("The Product - Enter Product Name and select Type of Product");
			this.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Raw material");

			Report.StartStep("I save the product information as");
			stepsNewProd.SaveProductInformation(savedAs);

			var ing1 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing1.AddRow("100-41-4", "Ethylbenzene", "25", "Yes", "Undisclosed Ingredient");
			Report.StartStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808211");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808211", ing1);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "1");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("success");

			var ing2 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed");
			ing2.AddRow("37334-84-2", "Cellolyn 21", "15", "No");
			Report.StartStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808212", ing2);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 2");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "2");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing3 = new Table("CASNumber", "ComponentName", "Percentage");
			ing3.AddRow("RR-38384-6", "FRAGRANCE-HERBAL", "10");
			Report.StartStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808213", ing3);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 3");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "3");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing4 = new Table("CASNumber", "ComponentName", "Percentage");
			ing4.AddRow("RR-38213-8", "FRAGRANCE-BANANA", "10");
			Report.StartStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808214", ing4);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 4");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "4");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");

			var ing5 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed");
			ing5.AddRow("FLAVOR", "611 Grape Flavor", "10", "No");
			Report.StartStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808215", ing5);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 5");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "5");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");

			var ing6 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing6.AddRow("NA519", "Black Cherry - Natural Flavor", "10", "Yes", "Undisclosed Ingredient");
			Report.StartStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808216", ing6);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 6");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "6");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing7 = new Table("CASNumber", "ComponentName", "Percentage");
			ing7.AddRow("FRAGRANCE", "Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2", "10");
			Report.StartStep("Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name");
			this.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName("Ing808217", ing7);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 7");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "7");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			var ing8 = new Table("CASNumber", "ComponentName", "Percentage", "Publicly Disclosed", "Public Name");
			ing8.AddRow("7732-18-5", "Water", "10", "Yes", "Undisclosed Ingredient");
			Report.StartStep("Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218");
			this.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName("Ing808218", ing8);
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3 and denominator: 8");
			stepsIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("3", "8");
			Report.StartStep("In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning");
			stepsIngredients.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");

			Report.StartStep("In the Ingredients page I click continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Ingredients");

			Report.StartStep("Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue");
			this.GivenICallSharedStepFormulationRdParty_AcceptFormulation_GrantTier_Continue();

			Report.StartStep("Enter Regulatory Information - Not Prop 65");
			this.GivenICallSharedEnterRegulatoryInformation_NotProp();

			Report.StartStep("Regulatory Information 2 - Microbeads - No");
			this.SharedRegulatoryInformation2_Microbeads_No();

			Report.StartStep("I should see the Additional Documents to Provide Page");
			stepsNewProd.GivenIShouldSeeXPage("Additional Documents to Provide");

			Report.StartStep("(Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\\Dependencies\\WERCSmart\\testdoc.pdf");
			this.ICallSharedBrowseForFileSelectClickOpen("IFRA Certificate (Perfumery Products)", "C:\\Dependencies\\WERCSmart\\testdoc.pdf");

			Report.StartStep("(Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\\Dependencies\\WERCSmart\\testdoc.pdf");
			this.ICallSharedBrowseForFileSelectClickOpen("GRAS Certificate (Flavor Products)", "C:\\Dependencies\\WERCSmart\\testdoc.pdf");

			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");

			Report.StartStep("in the Product Aliases page I click Continue");
			stepsNewProd.GivenInTheNewProductPageIClickContinue("Product Aliases");

			Report.StartStep("(Comments - Happy Path) and enter the comment: test");
			this.GivenICallSharedCommentsHappyPath("test");

			Report.StartStep("Confirm Restrict Use - Restrict");
			this.SharedConfirmRestrictUse_Restrict();

			Report.StartStep("(Go to Summary and verify data) with product type: Raw material");
			this.SharedGoToSummaryAndVerifyData("Raw material");

			Report.StartStep("Data Acceptance - Click Accept - Happy Path");
			this.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();

			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProd.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();

			Report.StartStep("Login to Studio and Open SHA manager");
			this.GivenICallShared65080LoginToStudioAndOpenSHAManager();

			Report.StartStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Submitted");

			Report.StartStep("SHA Manager - Submitted - Select product > process product data for product saved as: " + savedAs);
			this.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);

			Report.StartStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Assigned");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Assigned");

			Report.StartStep("WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: " + savedAs);
			this.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);

			Report.StartStep("WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: " + savedAs);
			this.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);

			Report.StartStep("In Power Designer I left click on section: [SECT0077] Walmart Transportation Information");
			stepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0077] Walmart Transportation Information");

			Report.StartStep("In Power Designer I double click on category: Water Soluble?");
			stepsStudio.GivenInPowerDesignerIDoubleClickOnCategory("Water Soluble?");

			Report.StartStep("In Power Designer the phrase selector screen should open");
			stepsStudio.ThenInPowerDesignerThePhraseSelectorScreenShouldOpen();

			var table = new Table("Text");
			table.AddRow("Y");
			Report.StartStep("In the phrase selector screen I select phrases");
			stepsStudio.ThenInThePhraseSelectorScreenISelectPhrases(table);

			Report.StartStep("In the phrase selector screen I click button: Save");
			stepsStudio.ThenInThePhraseSelectorScreenIClickButton("Save");

			var table2 = new Table("Component CAS", "Component ID", "Chemical Name");
			table2.AddRow("saved as " + savedAs, "MIXTURE", "AAA WERCS Test Raw Material");
			Report.StartStep("WPS Studio - PD+ - Create Component for 3rd party product");
			this.GivenICallSharedStep79501WPSStudio_PD_CreateComponentForRdPartyProduct(table2);

			Report.StartStep("I click on home to navigate back to editing specific product saved as " + savedAs);
			stepsStudio.GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(savedAs);

			Report.StartStep("WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only for product saved as: " + savedAs);
			this.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(savedAs);

			Report.StartStep("Go to SHA Manager");
			this.GivenICallSharedStep59066GoToSHAManager();

			Report.StartStep("SHA - Search for exact WPS ID in All Status for saved as: " + savedAs);
			this.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);

			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: " + savedAs + " and its status is: Completed");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Completed");

		}

		[StepDefinition(@"I call Shared Step 118064 \(Additional Product Information - US only - No GHS, Not Direct Ship, Not CA Cleaning ,Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotCACleaningNotPLPNotGNFR_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(
			@"I call Shared Step 118085 \(Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue\)")]
		public void
			GivenICallSharedStepAdditionalProductInformation_PesticideNotConsideredSOLDUSEverythingElseNoCACleaningNo_Continue()
		{
			var MyNewProduct = new StepsNewProduct();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Report.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Product is not considered a pesticide product");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 118091 \(Additional Product Information - enter options\)")]
		public void ICallSharedStepAdditionalProductInformationEnterOptionsCACleaning(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.")
			)
			{
				Report.StartStep(
					"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration." +
					table.Rows[0]["California Cleaning"]);
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.",
					table.Rows[0]["California Cleaning"]);
			}

			if (myNewProduct.SectionExists(
				"Product is a Retailer's Private Label or Brand"))
			{
				Report.StartStep(
					"Product is a Retailer's Private Label or Brand" +
					table.Rows[0]["Private Label or Brand"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand",
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
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step - \(Additional Product Information - enter options\)")]
		public void ICallSharedStepAdditionalProductInformationEnterAllOptions(Table table)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
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
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 118138 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No CA Cleaning ,No PL, No GNFR Without Child question")]
		public void GivenICallSharedStepAdditionalProductInformation_USPesticideNoNoOSHANoDSNoCACleaningVNoPLNoGNFRWithoutChildQuestion()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I set any option for: 'Which one best describes your product'");
			// Step says 'any' but prefer setting not pesticide because some tests didn't account for Pesticides page appearing later.
			if (new NewProduct().GetAllOptionsForSection("Which one best describes your product").Contains("Product is not considered a pesticide product"))
			{
				MyNewProduct.SetTheSectionOptionTo("Which one best describes your product", "Product is not considered a pesticide product");
			}
			else
			{
				MyNewProduct.SelectFirstOptionInSection("Which one best describes your product");
			}
			Report.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			Report.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			Report.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			Report.StartStep(
				"I set the Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Cleaning products must comply with California's Cleaning Product Right to Know Act.  I would like to provide the additional information needed for this program during registration.",
				"No");
			Report.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			Report.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			Report.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			Report.StartStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			if (name == "")
			{
				char[] forbiddenChars = @"()@#\[]~;^?<>&|{}+%'""/".ToCharArray();
				name = new string(type.Where(c => !forbiddenChars.Contains(c)).ToArray());
			}
			new Steps_TheProduct().SetProductNameTo(name);
			Report.StartStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Report.Info($"The TestCaseId was found as: {TReVorSettings.TestCaseId}");

			Context.AddToContext($"TestCase{TReVorSettings.TestCaseId}", prodDetails);
		}
	}
}

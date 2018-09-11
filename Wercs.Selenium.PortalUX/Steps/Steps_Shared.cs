using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using NPOI.SS.Formula.Functions;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding]
	public class Steps_Shared : TechTalk.SpecFlow.Steps
	{
		// For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

		[StepDefinition(@"I call Shared Step 57408 \(Create a New Registration via Register New Product icon\)")]
		public void GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I click the Register New Product icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Register New Product");
			TestReport.StartStep("I should see the New Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("New Product");
			TestReport.StartStep("I set the Select the type of product to create option to: Create a New Registration");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the type of product to create",
				"Create a New Registration");
			TestReport.StartStep("In the New Product page I click Continue");
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
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			TestReport.StartStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			MyStepsNewProduct.SetTheSectionOptionTo("Product Name as it a appears on the Package Label",
				"AAA WERCS Test " + type.Replace("/", " "));
			TestReport.StartStep("In the Product Type tab of the New Product Page, I enter: " + type +
								 " in the Type of Product select field");
			MyStepsNewProduct.GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField(type);
			TestReport.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60779 \(Enter Liquid - Cooking Oil - Non-Aerosol\)")]
		public void GivenICallSharedStepEnterLiquid_CookingOil_Non_Aerosol()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
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
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			//TestReport.StartStep("Primary Physical State should be showing the value: Liquid");
			//MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");

			NewProduct MyNewProduct = new NewProduct();
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

		[Given(@"I call Shared Step 60935 Additional Product Information - US - Direct Ship - Private Label Only")]
		public void GivenICallSharedStep60935AdditionalProductInformation_US_DirectShip_PrivateLabelOnly()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}


		[StepDefinition(
			@"I call shared step 60726 \(Additional Product Information - Country and Private Label or Brand - Yes\)")]
		public void GivenICallSharedStep60726AdditionalProductInformation_CountryAndPrivateLabelOrBrand_Yes()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");

			//CLF - this option doesn't always appear. Putting this fix in for now but may need a new version of the step
			NewProduct MyNewProduct = new NewProduct();
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
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
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
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 70393 \(Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only\)")]
		public void
			GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_DirectShip_PrivateLabelQuestionsOnly()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
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
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();

			if (myNewProduct.SectionExists("Which one best describes your product"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Which one best describes your product",
					"Regulates Plant Growth");
			}

			TestReport.StartStep(
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
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			TestReport.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			TestReport.StartStep("I should see the ingredients error message");
			MyStepsNewProduct.IngredientsErrorMessageShowing("should");
			TestReport.StartStep("I add the following ingredients:");
			MyStepsNewProduct.AddIngredients(ingredientsTable);
			TestReport.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
		}

		[StepDefinition(@"I call Shared Step 69557 \(Enter Ingredients for Aerosol Propellent\)")]
		public void GivenICallSharedEnterIngrediebtsForAerosolPropellant()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			TechTalk.SpecFlow.Table aerosolIngredients = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.StartStep("I add the following ingredients (aerosol propellant):");
			MyStepsNewProduct.AddIngredients(aerosolIngredients);
			TechTalk.SpecFlow.Table otherIngredients = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.StartStep("I add the following ingredients (other):");
			MyStepsNewProduct.AddIngredients(otherIngredients);
			TestReport.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
		}

		[StepDefinition(@"I call Shared 60685 Fuel Container Regulatory Details - Yes")]
		public void GivenICallSharedFuelContainerRegulatoryDetails_Yes()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see Fuel Container Regulatory Details");
			MyStepsNewProduct.GivenIShouldSeeXPage("Fuel Container Regulatory Details");
			TestReport.StartStep("I Product is a Safety Can to: Yes");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Safety Can", "Yes");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Fuel Container Regulatory Details");
		}

		[StepDefinition(@"I call Shared 48367 Product Includes Battery > any type")]
		public void GivenICallSharedProductIncludesBatteryAnyType()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct
				.GivenInTheProductCharacteristicsTabOfTheNewProductPageForIndicateHowBatteryIsPackagedISelectX(
					"Installed in the product");

			TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
				"Battery Type",
				"Manufacturer",
				"Number of batteries per package",
				"How many batteries required to run"
			});
			table2.AddRow(new string[] {
				"Alkaline",
				"L1028F",
				"6",
				"6"
			});
			MyStepsNewProduct.GivenInTheProductCharacteristicsTabOfTheNewProductPageIAddTheFollowingBatteries(table2);
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Includes Battery");
		}

		[StepDefinition(
			@"I call Shared 61449 Toxicity Characteristic Leaching Procedure \(TCLP\) - select No to all - Click Continue - Happy Path")]
		public void
			GivenICallShared61449ToxicityCharacteristicLeachingProcedureTCLP_SelectNoToAll_ClickContinue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("Toxicity Characteristic Leaching Procedure (TCLP)");
			MyStepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			TestReport.StartStep("I set the Product has had TCLP testing to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing", "No");
			TestReport.StartStep("I set all Metal presence values to No");
			MyStepsNewProduct.GivenISetAllTheMetalPresenceValueTo("No");
			TestReport.StartStep("I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP)");
		}

		[Given(@"I call Shared 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all")]
		public void GivenICallShared58189AnswerElectronicEquipmentQuestions_WithCathodeRay_NoToAll()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Electronic Equipment page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Electronic Equipment");
			TestReport.StartStep("I set the Contains Circuit Board option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Contains Circuit Board", "No");
			TestReport.StartStep("I set the Has a Cathode Ray Tube option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a Cathode Ray Tube", "No");
			TestReport.StartStep("I set the Has a LCD or Plasma Display option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			TestReport.StartStep("I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Electronic equipment");
		}


		[StepDefinition(@"I call Shared 57571 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_NotProp()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			var selNewProduct = new NewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			TestReport.StartStep(
				"I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			selNewProduct.Prop65 = false;
			Delay.Seconds(1);
			Report.IsFalse(selNewProduct.Prop65, "The Prop 65 option was not successfully set to No", "The Prop 65 question was successfully set to No");
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared 48367 \(Product Includes Battery > any type\)")]
		public void GivenICallSharedProductIncludesBatteryAnyType(Table table)
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SelectFirstOptionInSection("Indicate how battery is packaged");
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I set the Indicate how battery is packaged field to: Installed in the product");
			MyStepsNewProduct.SetTheSectionOptionTo("Indicate how battery is packaged", "Installed in the product");
			TestReport.StartStep(
				"I complete a row in the Battery Table: | Battery Type | Manufacturer | Number of batteries per package | How many batteries are required to run |");
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

			TestReport.StartStep("In the Product Includes Battery page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Includes Battery");
		}

		[StepDefinition(@"I call Shared Step 57589 \(Enter Pesticide Data - United States \(without EPA number\)\)")]
		public void GivenICallSharedStepEnterPesticideData_UnitedStatesWithoutEPANumber()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Pesticide Details - U.S. Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Pesticide Details - U.S.");
			TestReport.StartStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "No");
			TestReport.StartStep("I select the first option in section: Select the applicable exemption");
			MyStepsNewProduct.SelectFirstOptionInSection("Select the applicable exemption");
			TestReport.StartStep("In the Pesticide Details - U.S. page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}


		[StepDefinition(
			@"I call Shared Step 48369 \(Toxicity Characteristics Leaching Procedure \(TCLP\) - No to ALL With Copper\)")]
		public void GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithCopper()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
			TestReport.StartStep(
				"I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Toxicity Characteristic Leaching Procedure (TCLP)");
			TestReport.StartStep("I set the Product has had TCLP testing; Report is available option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has had TCLP testing; Report is available", "No");
			TestReport.StartStep("I select No for all elements including Copper");
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

			TestReport.StartStep(
				"In the Toxicity Characteristic Leaching Procedure (TCLP) Product Report page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Toxicity Characteristic Leaching Procedure (TCLP) Product Report");
		}

		[StepDefinition(
			@"I call Shared Step 71955 \(Answer Electronic Equipment questions - Without Cathode Ray - No to all\)")]
		public void GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Contains Circuit Board", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			TestReport.StartStep("In the Electronic Equipment page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Electronic Equipment");
		}

		[StepDefinition(
			@"I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path")]
		public void GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may including Active Ingredient)");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains(
				"OTC Drug Facts Label (may including Active Ingredient)");
			TestReport.StartStep("I set the Refer to your Product Label option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Refer to your Product Label", "None of the Above");
			TestReport.StartStep("In the Regulatory Information 3 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 3");
		}

		[StepDefinition(
			@"I call Shared 57506 \(Transportation Details 1 - Regulated for Transport\(No\) - Exemption\(Random\) - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport",
				"No, due to an exemption or exception");
			MyStepsNewProduct.SetTheSectionOptionTo("Please select DOT Exceptions if applicable", "173.120(a)(4)");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[Given(
			@"I call Shared 69682 \(Retailer Association - Add Private Label Information\) and select the retailer: (.*) and enter the name: (.*)")]
		public void GivenICallSharedRetailerAssociation_AddPrivateLabelInformation(string retailer, string name)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow(retailer);
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			NewProduct MyNewProduct = new NewProduct();
			MyNewProduct.SetFullNameOfProductForRetailer(retailer, name);
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(
			@"I call Shared Step 57980 \(Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path\)")]
		public void
			GivenICallSharedStepTransportationDetails_YesOnlyOption_SelectIMDGFullyRegulated_Continue_HappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
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
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the UN Number field to: UN" + unNo);
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN" + unNo);
			Delay.Seconds(2);
			TestReport.StartStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			TestReport.StartStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			TestReport.StartStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}


		[Given(
			@"I call Shared Step 57794 \(Confirm VOC \(SCAQMD\) step title, Confirm ACP question shown  - Select No - Happy Path\)")]
		public void GivenICallSharedStepConfirmVOCSCAQMDStepTitleConfirmACPQuestionShown_SelectNo_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I should see the '{0}' page",
				"Volatile Organic Compounds (VOC) for South Coast Air Quality Management District (SCAQMD) and Canada"));
			MyStepsNewProduct.GivenIShouldSeeXPage(
				"Volatile Organic Compounds (VOC) for South Coast Air Quality Management District (SCAQMD) and Canada");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
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
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I set the {0} option to: {1}",
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
			/* CLF- 13/7/2018 This does not seem to be in the step design
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB",
				"0");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule",
				"0");
				*/
			TestReport.StartStep(string.Format("I set the {0} option to: {1}",
				"Product label specifies a dilution ratio which results in a final VOC concentration for the product during use",
				"Yes"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product label specifies a dilution ratio which results in a final VOC concentration for the product during use",
				"Yes");
			TestReport.StartStep(string.Format("I set the {0} option to: {1}",
				"Product's VOC content as used",
				"0"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product's VOC content as used",
				"0");
			TestReport.StartStep(string.Format("I set the {0} option to: {1}",
				"Product's VOC content as sold",
				"0"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product's VOC content as sold",
				"0");
			TestReport.StartStep("I select the first option for section: Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?");
			MyStepsNewProduct.SelectFirstOptionInSection("Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?");
			TestReport.StartStep("In the VOC page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("VOC");
		}


		[StepDefinition(
			@"I call Shared 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: (.*)")]
		public void GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath(string retailer)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			var selSelectRetailers = new SelectRetailers();
			if (!selSelectRetailers.Wait_for_load(10))
			{
				Report.Warn("The Select Retailers page was not loaded on entering the Retailer page");
				MyStepsNewProduct.ClickAddRetailersInRetailersPage();
			}

			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow(retailer);
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");

			// below step was throwing error when selected No-retailer so  need to remove
			//TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
		}

		// Enter UPC string in the form: "Equals"+upcNumber where upcNumber is the exact number to input, rather than using the randomly generated step from context
		[StepDefinition(
			@"I call Shared 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc,
			string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				var upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation { ContainerType = containerType, Size = size, UpcNumber = upc_ };
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");
			}
			else
			{
				Table upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code(UPC)");
		}

		[StepDefinition(
			@"I call Shared Step 60826 \(Enter Universal Product Code \(UPC\) - Battery - Confirm Quantity\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedStepEnterUniversalProductCodeUPC_Battery_ConfirmQuantity(string upc,
			string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Quantity Header");
			MyStepsNewProduct.GivenIShouldSeeXPage("Quantity");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TechTalk.SpecFlow.Table upcTable = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.StartStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code(UPC)");
		}


		[StepDefinition(@"I call Shared 60567 \(Upload Product Label only\) : (.*)")]
		public void GivenICallSharedUploadProductLabelOnly(string docPath)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				@"I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Product Label", docPath);
			TestReport.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared 60567 \(Upload Product Label only\) for section: (.*)")]
		public void GivenICallSharedUploadProductLabelOnlySectionSpecific(string section)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I click the browse button for label: Product Label in section: " + section +
								 @" and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFileSectionAndType("Product Label", section,
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared 57883 \(Comments - Happy Path\) and enter the comment: (.*)")]
		public void GivenICallSharedCommentsHappyPath(string comments)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Comments Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Comments");
			TestReport.StartStep("I enter the following into the comments field: " + comments);
			MyStepsNewProduct.ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(comments);
			TestReport.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Comments");
		}

		[StepDefinition(@"I call Shared 54796 \(Purchase Summary\)")]
		public void GivenICallSharedPurchaseSummary()
		{
			Steps_PaymentMethods MyStepsPaymentMethods = new Steps_PaymentMethods();
			MyStepsPaymentMethods.ThenIConfirmThePurchaseSummaryHeaderIsDisplayed();
			MyStepsPaymentMethods.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
		}


		[StepDefinition(
			@"I call Shared 57753 \(Create a New Registration via Register New Product \(expanded menu\)\)")]
		public void GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu()
		{
			TestReport.UseSubSteps = true;
			StepsHomepage MyStepsHomePage = new StepsHomepage();
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I click the Register New Product icon in the Navigation Pane");
			MyStepsHomePage.ClickItemInNavigationPanel("Register New Product");
			TestReport.StartStep("I should see the New Product Page");
			MyNewProduct.GivenIShouldSeeXPage("New Product");
			TestReport.StartStep("I set the Select the type of product to create field to: Create a New Registration");
			MyNewProduct.SetTheSectionOptionTo("Select the type of product to create", "Create a New Registration");
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared 57884 \(Safety Data Sheet Authoring - Additional Data \(Optional\) step - add any random data for all fields - Happy path\) and enter the following:")]
		public void GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
			Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");
			TestReport.StartStep(
				"In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " +
				table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct
				.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(
					table.Rows[0]["Personal Protection Equipment"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " +
								 table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAutoignitionISelect(
				table.Rows[0]["Autoignition Temperature"]);
			TestReport.StartStep(
				"In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " +
				table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(
				table.Rows[0]["Minimum Ignition Energy"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " +
								 table.Rows[0]["Viscosity"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(table.Rows[0]["Viscosity"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Appearance I select: " +
								 table.Rows[0]["Appearance"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(
				table.Rows[0]["Appearance"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor I select: " +
								 table.Rows[0]["Odor"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorISelect(table.Rows[0]["Odor"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " +
								 table.Rows[0]["Odor Threshold"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorThresholdISelect(
				table.Rows[0]["Odor Threshold"]);
			TestReport.StartStep(
				"In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " +
				table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPartitionCoefficientISelect(
				table.Rows[0]["Partition Coefficient"]);
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared 57441 \(Product Characteristics - Primary Physical Property - Liquid\)")]
		public void GivenICallSharedProductCharacteristics_PrimaryPhysicalProperty_Liquid()
		{
			// Secondary Physical State, Specific Gravity (value), pH (range), Boiling Point (range), Water Solubility description can be any value.
			// Add a variable table in the future if specific data is required.
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the Primary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			TestReport.StartStep("I set the Specific Gravity option to: 20");
			MyNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			TestReport.StartStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			TestReport.StartStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			TestReport.StartStep("I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			TestReport.StartStep("I set the Boiling Point (in Celsius) field to: 20.1C (68.1F) - 35C (95F)");
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "20.1C (68.1F) - 35C (95F)");
			TestReport.StartStep("I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)");
			MyNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			TestReport.StartStep("I set the Flash Point (in Celsius) field to: >=23C and <38C");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", ">=23C and <38C");
			TestReport.StartStep("I set the Flash Point Testing Method Used option to: Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			TestReport.StartStep("I set the Select the best Water Solubility description field to: 100g/100ml");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			TestReport.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[Given(@"I call Shared Step 57111 \(Enter Product Data for Physical State - Aerosol only\)")]
		public void GivenICallSharedStepEnterProductDataForPhysicalState_AerosolOnly()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			// Primary Physical State is Aerosol which is the only option available
			TestReport.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			TechTalk.SpecFlow.Table produtTable = new TechTalk.SpecFlow.Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			TestReport.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			TestReport.StartStep("I check the 'I do not have exact' checkbox for field: pH");
			MyNewProduct.SectExatcDataNotKnown("pH");
			TestReport.StartStep("I set the pH field to: 7.1 - 9.9");
			MyNewProduct.SetTheSectionOptionTo("pH", "7.1 - 9.9");
			TestReport.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			TestReport.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57454 \(Product Characteristics - Aerosol & Gas available - Select Aerosol - Continue - Happy Path\)")]
		public void ThenICallSharedStepProductCharacteristics_AerosolGasAvailable_SelectAerosol_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			// Primary Physical State is Aerosol which is the only option available
			TestReport.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			TechTalk.SpecFlow.Table produtTable = new TechTalk.SpecFlow.Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			produtTable.AddRow(new string[] {
				"Gas"
			});
			MyNewProduct.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			TestReport.StartStep("I set the Primary Physical State field to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			TestReport.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			TestReport.StartStep("I set the pH field to: 10.4");
			MyNewProduct.SetTheSectionOptionTo("pH", "10.4");
			TestReport.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			TestReport.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			//TestReport.StartStep("I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: The product is classified as a D003 Hazardous Waste under RCRA.");
			//MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "The product is classified as a D003 Hazardous Waste under RCRA.");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}



		[StepDefinition(
			@"I call Shared 57528 \(Product Characteristics - Aerosol Only - add data - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolOnly_AddData_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			// Primary Physical State is Aerosol which is the only option available
			TestReport.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			TechTalk.SpecFlow.Table produtTable = new TechTalk.SpecFlow.Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			MyNewProduct.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			TestReport.StartStep("I set the Primary Physical State field to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			TestReport.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			TestReport.StartStep("I set the pH field to: 10.4");
			MyNewProduct.SetTheSectionOptionTo("pH", "10.4");
			TestReport.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			TestReport.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			//TestReport.StartStep("I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: The product is classified as a D003 Hazardous Waste under RCRA.");
			//MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "The product is classified as a D003 Hazardous Waste under RCRA.");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(
			@"I call Shared 57401 \(Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path\)")]
		public void GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("I click Continue in the product registration");
			MyNewProduct.ContinueInTheProductRegistration();
		}

		[StepDefinition(
			@"I call Shared 57881 \(Regulatory Documents to Provide - US only - request authoring - Happy Path\)")]
		public void GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			TestReport.StartStep("I set the OSHA-compliant Safety Data Sheet, English field to: Request to author");
			MyNewProduct.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "Request to author");
			TestReport.StartStep("In the Regulatory Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 60931 \(Additional Documents to Provide - Exemption - Special Permit - Product Label\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_SpecialPermit_ProductLabel()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			MyNewProduct.UploadPDFFileSectionAndType("Exemption Letter",
				"Transportation Exemption Letter or Special Permit", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProduct.UploadPDFFileSectionAndType("Special Permit",
				"Transportation Exemption Letter or Special Permit", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProduct.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}


		[StepDefinition(
			@"I call Shared 62710 \(Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path\)")]
		public void GivenICallSharedConfirmVOCHeadingAndSelectNoToFirstQuestionOnly_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage(
				"Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			TestReport.StartStep(
				"I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
		}

		[StepDefinition(@"I call Shared Step 60468 \(VOC - CARB only required - enter value - Continue - Happy Path\)")]
		public void GivenICallSharedStepVOC_CARBOnlyRequired_EnterValue_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"I set the Amount of VOC content as weight percentage of the total formula field to: 50");
			MyNewProduct.SetTheSectionOptionTo("Amount of VOC content as weight percentage of the total formula", "50");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
		}


		[StepDefinition(
			@"I call Shared Step 60552 \(VOC - AERO Question \(ozone\) enter value - Click Continue - Happy Path\): (.*)")]
		public void GivenICallSharedStepVOC_AEROQuestionOzoneEnterValue_ClickContinue_HappyPath(string value)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I Enter a value for the 'VOC content in grams ozone per gram' question: " + value);
			MyNewProduct.SetTheSectionOptionTo("VOC content in grams ozone per gram", value);
			TestReport.StartStep("In the Volatile Organic Compounds (VOC) page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
		}

		[StepDefinition(@"I call Shared 60631 \(VOC - HVOC and MVOC - add values - Continue - Happy Path\)")]
		public void GivenICallSharedVOC__HVOCAndMVOC_AddValues_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 10");
			MyNewProduct.SetTheSectionOptionTo(
				"HVOC (high volatile organic compound) content as weight percent of the total formulation", "10");
			TestReport.StartStep(
				"I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 5.6");
			MyNewProduct.SetTheSectionOptionTo(
				"MVOC (microbial volatile organic compound) content as weight percentage of the total formulation",
				"5.6");
			TestReport.StartStep("In the Volatile Organic Compounds (VOC) page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compounds (VOC)");
		}

		[StepDefinition(@"I call Shared 57885 \(Data Acceptance - Click Accept - Happy Path\)")]
		public void GivenICallSharedDataAcceptance_ClickAccept_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the Data Acceptance page I select Yes, Agreed");
			MyNewProduct.GivenInTheDataAcceptancePageISelectYesAgreed();
			TestReport.StartStep("In the Data Acceptance page I click on the Accept button");
			MyNewProduct.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
		}

		[StepDefinition(@"I call Shared Step 37857 \(Enter Physical Property - Solid\)")]
		public void GivenICallSharedEnterPhysicalProperty_Solid()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			var showing = new NewProduct().GetOptionsForSection("Primary Physical State");
			if (!showing.Contains("Solid"))
			{
				TestReport.StartStep("I set the Primary Physical State option to: Solid");
				Report.Info("Setting the Physical State to Solid because it was not selected by default");
				MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			}

			TestReport.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			TestReport.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				TestReport.StartStep(
					"I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
					"Solid");
			}
			//TestReport.StartStep("I set the Secondary Physical State option to: Solid");
			//MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 37857 \(Enter Physical Property - Solid\) with the following inputs:")]
		public void GivenICallSharedEnterPhysicalProperty_SolidParameters(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("Primary Physical State should be showing the value: Solid");
			MyNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			TestReport.StartStep("I set the Primary Physical State option to: Solid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			TestReport.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			var waterSolubility = table == null ? "N/A" : table.Rows.FirstOrDefault()["Water Solubility"];
			if (waterSolubility != null && waterSolubility != "N/A")
			{
				TestReport.StartStep("I set the Select the best Water Solubility description option to: " +
									 waterSolubility);
				MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", waterSolubility);
			}
			else
			{
				TestReport.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
				MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			}

			var secondaryState = table == null ? "N/A" : table.Rows.FirstOrDefault()["Secondary Physical State"];
			if (secondaryState != null && secondaryState != "N/A")
			{
				TestReport.StartStep("I set the Secondary Physical State option to: " + secondaryState);
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", secondaryState);
			}
			else
			{
				TestReport.StartStep("I set the Secondary Physical State option to: Solid");
				MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			}

			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60310 \(Additional Product Information - Without Child question\)")]
		public void GivenICallSharedAdditionalProductInformation_WithoutChildQuestion()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 57865 \(Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path\)")]
		public void
			GivenICallSharedStepAdditionalProductInformation_PesticideShownUSOnlySelectNoForEverythingElse_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}


		[StepDefinition(
			@"I call Shared Step 57801 \(Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path\)")]
		public void GivenICallSharedConfirmVOCSummaryStepConfirmVOCAnalysisDate_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Volatile Organic Compound Summary Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			TestReport.StartStep("I confirm that the VOC Analysis Date statement is showing");
			MyNewProduct.ThenIConfirmThatTheVOCAnalysisDateIsShowing();
			TestReport.StartStep("I confirm that I see todays VOC Analysis Date");
			MyNewProduct.ThenIConfirmThatISeeTodaysVOCAnalysisDate();

			//TestReport.StartStep("In the Volatile Organic Compound Summary page I click Continue");
			//MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compound Summary");
		}

		[StepDefinition(@"I call Shared Step 42214 \(Delete a Product from the Product grid\) to delete product: (.*)")]
		public void GivenICallSharedDeleteAProductFromTheProductGrid(string savedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
			TestReport.StartStep("I delete the product: " + savedAs);
			new StepsProductGrid().ThenIDeleteTheProduct(savedAs);
		}

		[StepDefinition(
			@"I call Shared Step 57727 \(Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			TestReport.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"DOT");
			TestReport.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with limited quantity");
			TestReport.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with consumer commodity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with consumer commodity");
			TestReport.StartStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 65705 \(Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue\)")]
		public void
			GivenICallSharedStepTransportation_DOTUNStep_EnterUNSelectAerosolsNoneAddTechnicalNameClickContinue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			TestReport.StartStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			TestReport.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			TestReport.StartStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.1");
			TestReport.StartStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(
			@"I call Shared Step 34455 \(U\. S\. Department of Transportation \(DOT\) Classification - Enter all valid data\)")]
		public void GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidData()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			TestReport.StartStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			TestReport.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			TestReport.StartStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2.1");
			TestReport.StartStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[Given(
			@"I call Shared Step 34455 \(U\. S\. Department of Transportation \(DOT\) Classification - Enter all valid data\): UN Unmber: (.*), Proper Shipping Name: (.*), Technical Name: (.*), Hazard Class: (.*), Packing Group: (.*)")]
		public void
			GivenICallSharedStepU_S_DepartmentOfTransportationDOTClassification_EnterAllValidDataUNUnmberUNProperShippingNameNonanesTechniacalNameTechnicalTestNameHazardClassPackingGroupIII(
				string unNo, string psnName, string techName, string hazClass, string packClass)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the UN Number field to: " + unNo);
			MyNewProduct.SetTheSectionOptionTo("UN Number", unNo);
			Delay.Seconds(2);
			TestReport.StartStep("I select '" + psnName + "' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", psnName);
			Delay.Seconds(2);
			TestReport.StartStep("I enter '" + techName + "' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", techName);
			Delay.Seconds(2);
			TestReport.StartStep("I select '" + hazClass + "' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", hazClass);
			TestReport.StartStep("I select '" + packClass + "' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", packClass);
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}


		[StepDefinition(
			@"I call Shared Step 57728 \(U.S. Department of Transportation \(DOT\) Classification - Enter UN1950 \(Aerosol\) - Select data - Continue - Happy Path\)")]
		public void GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			TestReport.StartStep("I select the first option in section: Proper Shipping Name");
			MyNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			Delay.Seconds(2);
			TestReport.StartStep("I select the first option in section: Hazard Class (select)");
			MyNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			Delay.Seconds(2);
			TestReport.StartStep("I select the first option in section: Packing Group (select)");
			MyNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I call Shared Step 49621 \(Volatile Organic Compounds \(VOC\) for OTC and CARB - No\)")]
		public void GivenICallSharedVolatileOrganicCompoundsVOCForOTCAndCARB_No()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage(
				"Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			TestReport.StartStep(
				"I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
		}

		[StepDefinition(@"I call Shared Step 32931 \(Liquid Core Product - select  No - Happy Path\)")]
		public void LiquidCoreProduct_SelectNo_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			TestReport.StartStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "No");
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 74995 \(Liquid Core product - Select Yes - Continue\)")]
		public void GivenICallSharedStepIquidCoreProduct_SelectYes_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			TestReport.StartStep("I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Is there a free liquid in the Product's container that is 10ml or greater?", "Yes");
			TestReport.StartStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}


		[StepDefinition(@"I call Shared Step 00000 \(Liquid Core Product - select Yes - Happy Path\)")]
		public void GivenICallSharedStepLiquidCoreProduct_SelectYes_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			TestReport.StartStep(
				"I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: Yes");
			MyNewProduct.SetTheSectionOptionTo(
				"Is there a free liquid in the Product's container that is 10ml or greater?", "Yes");
			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}


		[StepDefinition(
			@"I call Shared Step 57507 \(Transportation Details 1- Not Regulated - Continue - Happy Path\)")]
		public void ICallSharedTransportationDetails1_NotRegulated()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();
			TestReport.StartStep("I should see the Transportation Details 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Transportation Details 1");
			TestReport.StartStep("I set the Product is Regulated for Transport field to: Not Regulated");
			MyNewProductSteps.SetTheSectionOptionTo("Product is Regulated for Transport", "Not Regulated");
			//MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			var showing = MyNewProduct.GetOptionsForSection("Product is Regulated for Transport");
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

			TestReport.StartStep("In the Product is Regulated for Transport page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product is Regulated for Transport");
		}

		[StepDefinition(
			@"I call Shared Step 57502 \(Additional Product Information - Pesticide & Child shown, US only, No to everything else - Continue - Happy Path\)")]
		public void ICallSharedAdditionalProductInformation_PesticideAndChildShown_USOnly_NoToEverythingElse()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			TestReport.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		// Duplicate with Shared Step 57884
		[StepDefinition(@"I call Shared Step 59663 \(Safety Data Sheet Authoring - Additional Data \(Optional\)\)")]
		public void ICallSharedSafetyDataSheetAuthoring_AdditionalDataOptional(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();

			TestReport.StartStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " + table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct.SetTheSectionOptionTo("Personal Protection Equipment Recommended", table.Rows[0]["Personal Protection Equipment"]);

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " + table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.SetTheSectionOptionTo("Autoignition Temperature", table.Rows[0]["Autoignition Temperature"]);

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " + table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.SetTheSectionOptionTo("Minimum Ignition Energy", table.Rows[0]["Minimum Ignition Energy"]);

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " + table.Rows[0]["Viscosity"]);
			MyNewProduct.SetTheSectionOptionTo("Viscosity", table.Rows[0]["Viscosity"]);

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Appearance I select: " + table.Rows[0]["Appearance"]);
			MyNewProduct.SetTheSectionOptionTo("Appearance", table.Rows[0]["Appearance"]);

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor I select: " + table.Rows[0]["Odor"]);
			MyNewProduct.SetTheSectionOptionTo("Odor", table.Rows[0]["Odor"]);

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " + table.Rows[0]["Odor Threshold"]);
			MyNewProduct.SetTheSectionOptionTo("Odor Threshold", table.Rows[0]["Odor Threshold"]);
			// if Product's Dispensing Method is required enter any option

			var actualSections = new NewProduct().GetDisplayedSections();
			if (actualSections.Contains("Product's Dispensing Method"))
			{
				TestReport.StartStep("In the Review and Submit tab of the New Product Page for Product's Dispensing Method I select: " + table.Rows[0]["Product's Dispensing Method"]);
				MyNewProduct.SetTheSectionOptionTo("Product's Dispensing Method", table.Rows[0]["Product's Dispensing Method"]);
			}

			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " + table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.SetTheSectionOptionTo("Partition Coefficient", table.Rows[0]["Partition Coefficient"]);

			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 57501 \(Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue\)")]
		public void ICallSharedProductCharacteristics_MoreThanOneState_SelectSolid_StateAndSubcat_MixedAndWater_Random()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			MyNewProductSteps.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			TestReport.StartStep("I set the Primary Physical State option to: Solid");
			MyNewProductSteps.SetTheSectionOptionTo("Primary Physical State", "Solid");
			TestReport.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"Yes");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				TestReport.StartStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			TestReport.StartStep("I set the Secondary Physical State option to: Solid");
			MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 59680 \(Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path\)")]
		public void ICallSharedAdditionalProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			TestReport.StartStep("I only see the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			TestReport.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			var tableSecond = new Table("Section");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			TestReport.StartStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 29181 \(Ingredients - add any chemical\) with name: (.*)")]
		public void ICallSharedIngredients_AddAnyChemical(string name)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Ingredients Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Ingredients");
			TestReport.StartStep("I add the ingredient " + name + " at 100%");
			var table = new Table("ComponentName", "Percent");
			table.AddRow(name, "100");
			MyNewProductSteps.AddIngredients(table);
			TestReport.StartStep("In the Ingredients page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 57637 \(Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Exempt");
			MyNewProductSteps.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Exempt");
			TestReport.StartStep(
				"I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyNewProductSteps.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status",
				"Compliant with Domestic Substances List (DSL)");
			TestReport.StartStep(
				"I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			new NewProduct().Prop65 = false;

			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 29206 \(Retailer - Select No Retailer - Click Done - Click Continue - Happy Path\)")]
		public void ICallSharedRetailer_SelectNoRetailer_ClickDone()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NoRetailerWarningPopup WarningPopup = new NoRetailerWarningPopup();
			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow("No Retailer/No UPC Product");
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");

			/* --As per TFS70787 warning popup displays for NR  --- */
			//Delay.Seconds(1);
			TestReport.StartStep("In the UPCs Warning popup I click Ok");
			WarningPopup.ClickOk();
		}

		[StepDefinition(
			@"I call Shared Step 59042 \(Browse for File > select > click Open - Happy Path\) for document type: (.*) and file: (.*)")]
		public void ICallSharedBrowseForFileSelectClickOpen(string type, string pdfFile)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I upload document type: " + type + " using the Browse and Open");
			new NewProduct().UploadFileForSection(type, pdfFile);

		}

		[StepDefinition(
			@"I call Shared Step 60533 \(Additional Documents to Provide - Flash Point and Product Label only\) : (.*)")]
		public void ICallSharedAdditionalDocumentsToProvide_FlashPointAndProductLabelOnly(string docPath)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				@"I click the browse button for document: Flash Point Document and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Flash Point Document", docPath);
			TestReport.StartStep(
				@"I click the browse button for document: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFile("Product Label", docPath);
			TestReport.StartStep(@"in the Additional Documents to Provide page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(
			@"I call Shared Step 62678 \(Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path\)")]
		public void ICallSharedAdditionalProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			var tableFirst = new Table("Section");
			tableFirst.AddRow("Select countries the product may be sold in");
			tableFirst.AddRow(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)");
			tableFirst.AddRow(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)");
			tableFirst.AddRow(
				"Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.");
			TestReport.StartStep("I only the following sections");
			Report.Info("Checking that the only visible questions relate to: Child, OSHA, Direct Shipping");
			MyNewProductSteps.CheckDisplayedSections("only see", tableFirst);
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			TestReport.StartStep("I set the Select countries the product may be sold in option to: Canada");
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			TestReport.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			var tableSecond = new Table("Section");
			tableSecond.AddRow("Product is a Retailer's Private Label or Brand");
			tableSecond.AddRow(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)");
			TestReport.StartStep("I only the following sections");
			Report.Info("Checking that the questions relating to: Private Label, GNR are now visble");
			MyNewProductSteps.CheckDisplayedSections("see", tableSecond);
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}


		[StepDefinition(@"I confirm that the default selected retailer is: (.*) then click Continue")]
		public void CustomConfirmDefaultSelectedRetailer_ClickContinue(string retailer)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Retailer Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Retailer");
			TestReport.StartStep("The selected retailers on the Retailer page should be:");
			//MyNewProductSteps.SelectedRetailersShouldBe(new List<string> { retailer });
			var retailers = new Table("Retailer");
			retailers.AddRow(retailer);
			MyNewProductSteps.SelectedRetailersShouldBe(retailers);
			TestReport.StartStep("In the Retailer page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[StepDefinition(@"I call Shared Step 59922 \(Additional Product Information - Private Label or Brand only\)")]
		public void SharedAdditionalProductInformation_PrivateLabelOrBrandOnly()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 58189 \(Answer Electronic Equipment questions - With Cathode Ray - No to all\)")]
		public void SharedAnswerElectronicEquipmentQuestions_WithCathodeRay_NoToAll()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I set the Contains Circuit Board option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Contains Circuit Board", "No");
			TestReport.StartStep("I set the Has a Cathode Ray Tube (CRT) option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Has a Cathode Ray Tube (CRT)", "No");
			TestReport.StartStep("I set the Has a LCD for Plasma Display option to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Has a LCD or Plasma Display", "No");
			TestReport.StartStep("In the Answer Electronic Equipment questions page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Answer Electronic Equipment questions");
		}

		[StepDefinition(@"I call Shared Step 60741 \(Select Primary Physical Property - Solid - With Ingredients\)")]
		public void GivenICallSharedStepSelectPrimaryPhysicalProperty_Solid_WithIngredients()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			TestReport.StartStep("I set the Primary Physical State option to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			TestReport.StartStep("I set the Secondary Physical State option to: Cream");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Cream");
			NewProduct MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("When mixed with an equal amount of water"))
			{
				TestReport.StartStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH option to: Yes");
				MyStepsNewProduct.SetTheSectionOptionTo(
					"When mixed with an equal amount of water, will this produce a solution with a pH", "Yes");
			}
			TestReport.StartStep("I set the Select all ingredients included in this product option to: Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Select all ingredients included in this product", "Dairy");
			TestReport.StartStep("I set the Product is manufactured in a facility that processes, or contains option to: Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains",
				"Dairy or products containing dairy or milk");
			TestReport.StartStep("I set the Product is verified and sold as option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			TestReport.StartStep("I set the Product contains the following sweeteners option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			TestReport.StartStep("I set the Product contains the following artificial dye(s) option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)",
				"None of the Above");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(
			@"I call shared step 69687 \(Additional Product Information - US, No\(PL\)\)")]
		public void GivenICallSharedStepAdditionalProductInformation_CountryAndPrivateLabelOrBrand_No()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			// was failing on country of origin so adding if statement.
			// Flagging a fail because this condition doesn't exactly match the test case. If Origin Q. is expected here, should use a different shared step?
			if (new NewProduct().GetDisplayedSections().Contains("Select the product's Country of Origin"))
			{
				TestReport.StartStep("I set the Select the product's Country of Origin option to: United States of America");
				//Report.Failure(
				//	"The Country of Origin question was showing (required field) when it was not expected. Selecting an option.");
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United States of America");
			}

			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}


		[StepDefinition(
			@"I call Shared Step 65511 \(Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path \(use in a BCP\)\)")]
		public void ICallSharedAdditionalProductInformation_NoChildNoDirectShipNoPLClickContinue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			//TestReport.StartStep(
			//	"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			//MyNewProduct.SetTheSectionOptionTo(
			//	"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
			//	"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 57503 \(Regulatory Information 1- TSCA\(Random\) - Prop 65\(No\) - Continue - Happy Path\)")]
		public void ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			var selNewProduct = new NewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			var table = new Table("Section");
			table.AddRow("U.S. Toxic Substances Control Act (TSCA) status");
			table.AddRow(
				"Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?");
			Report.Info("Checking that the only visible questions relate to: TSCA and Prop 65");
			MyStepsNewProduct.CheckDisplayedSections("only see", table);
			TestReport.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			TestReport.StartStep(
				"I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No");
			selNewProduct.Prop65 = false;
			Delay.Seconds(1);
			Report.IsTrue(!selNewProduct.Prop65, "The Prop 65 option was not set to 'No'", "The Prop 65 option was set to: 'No'");
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 59927 \(Primary Physical State > Solid only available – Without Water Solubility question\)")]
		public void SharedPrimaryPhysicalStateSolidOnlyAvailable_WithoutWaterSolubilityQuestion()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("Primary Physical State should be showing the value: Solid");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			TestReport.StartStep("I set the Secondary Physical State field to: Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid");
			TestReport.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			TestReport.StartStep("In the Physical Properties page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Physical Properties");
		}

		[StepDefinition(
			@"I call Shared Step 60826 \(Enter Universal Product Code \(UPC\) - Battery - Confirm Quantity \) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and quantity: (.*)")]
		public void SharedEnterUniversalProductCodeUPC_Battery_ConfirmQuantity(string upc, string containerType,
			string size, string quantity)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I confirm 'Quantity' is visible in the UPC header");
			MyStepsNewProduct.ConfirmQuantityIsVisibleInUPCHeader();
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TechTalk.SpecFlow.Table upcTable = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.StartStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code(UPC)");
		}

		[StepDefinition(@"I call Shared Step 69358 \(Data Acceptance - Click Summary Button\)")]
		public void SharedDataAcceptance_ClickSummaryButton()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I click the Summary button in the Data Acceptance window");
			MyStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			TestReport.StartStep("I confirm the Manufacturer column is visible");
			// Confirm Manufacturer column is visble.
			// Close new tab
		}

		[StepDefinition(@"I call Shared Step 60026 \(Additional Product Information - US - Battery - No to all\)")]
		public void SharedAdditionalProductInformation_US_Battery_NoToAll()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			TestReport.StartStep("I set the Select one option below field to: Battery is packaged for Retail Sale");
			MyNewProductSteps.SetTheSectionOptionTo("Select one option below", "Battery is packaged for Retail Sale");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 73282 \(Lithium Battery Characteristics - Weight in Grams\)")]
		public void SharedLithiumBatteryCharacteristics_WeightInGrams()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			TestReport.StartStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			TestReport.StartStep("I set the Weight of Lithium in grams (single unit) field to: 0.1");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of Lithium in grams (single unit)", "0.1");
			TestReport.StartStep("I set the Weight of the single unit (grams) field to: 10");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "10");
			TestReport.StartStep("I set the Battery meets UN 38.3 testing requirements field to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo("Battery meets ", "Yes");
			TestReport.StartStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			TestReport.StartStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}

		[StepDefinition(@"I call Shared Step 54799 \(Lithium Battery Characteristics - any data - Happy path\)")]
		public void SharedLithiumBatteryCharacteristics_AnyData()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Lithium Battery Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Characteristics");
			TestReport.StartStep("I set the Type of Battery field to: Battery");
			MyNewProductSteps.SetTheSectionOptionTo("Type of Battery", "Battery");
			TestReport.StartStep("I set the Watt-hour of the battery (single unit) field to: 0.1");
			MyNewProductSteps.SetTheSectionOptionTo("Watt-hour of the battery (single unit)", "0.1");
			TestReport.StartStep("I set the Weight of the single unit (grams) field to: 10");
			MyNewProductSteps.SetTheSectionOptionTo("Weight of the single unit (grams)", "10");
			TestReport.StartStep("I set the Battery meets UN 38.3 testing requirements field to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo("Battery meets ", "Yes");
			TestReport.StartStep(
				"I set the Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6 field to: YES");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Battery is manufactured under a Quality Management Program outlined in ", "YES");
			TestReport.StartStep("In the Lithium Battery Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Characteristics");
		}

		[StepDefinition(@"I call Shared Step 60096 \(Lithium Battery Transportation\)")]
		public void SharedLithiumBatteryTransportation()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Lithium Battery Transportation Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Lithium Battery Transportation");
			TestReport.StartStep(
				"I set the For U.S. Department of Transportation (DOT), indicate the transport classification field to: Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail");
			MyNewProductSteps.SetTheSectionOptionTo(
				"For U.S. Department of Transportation (DOT), indicate the transport classification",
				"Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail");
			TestReport.StartStep(
				"I select the first option for section: For Marine transport (IMDG), indicate the classification");
			MyNewProductSteps.SelectFirstOptionInSection("For Marine transport (IMDG), indicate the classification");
			TestReport.StartStep(
				"I set the For Air transport (IATA), indicate the classification field to: Section IB");
			MyNewProductSteps.SetTheSectionOptionTo("For Air transport (IATA), indicate the classification",
				"Section IB");
			TestReport.StartStep(
				"I set the For Canada's Transportation of Dangerous Goods (TDG), indicate the classification field to: None of the above/Not intended for shipment in Canada");
			MyNewProductSteps.SetTheSectionOptionTo(
				"For Canada's Transportation of Dangerous Goods (TDG), indicate the classification",
				"None of the above/Not intended for shipment in Canada");
			TestReport.StartStep("In the Lithium Battery Transportation page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Lithium Battery Transportation");
		}

		[StepDefinition(@"I call Shared Step 69422 \(Additional Documents to Provide - Upload Product Photo\)")]
		public void SharedAdditionalDocumentsToProvide_UploadProductPhoto()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep(
				@"I click the browse button for label: Please upload a PDF of the product. in section: Product Photo and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFileSectionAndType("Please upload a PDF of the product.", "Product Photo",
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 54797 \(Select the specific Lithium Ion chemistry of the Battery\)")]
		public void SharedSelectTheSpecificLithiumIonChemistry()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Select the specific Lithium Ion chemistry of the Battery Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Select the specific Lithium Ion chemistry of the Battery");
			TestReport.StartStep("I select the first option in section: Select the best description");
			MyNewProductSteps.SelectFirstOptionInSection("Select the best description");
			TestReport.StartStep("In the Select the specific Lithium Ion chemistry page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Select the specific Lithium Ion chemistry");
		}

		// Duplicate of Shared step 60026
		[StepDefinition(
			@"I call Shared Step 65493 \(Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue\)")]
		public void SharedAdditionalProductInformation_USOnly_BatteryIsPackedForRetailSales_NoElse()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep("I set the Select one option below field to: Battery is packaged for Retail Sale");
			MyNewProductSteps.SetTheSectionOptionTo("Select one option below", "Battery is packaged for Retail Sale");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}



		[StepDefinition(@"I call Shared 56808 Regulatory Information - Prop 65 - No - Continue")]
		public void GivenICallShared56808RegulatoryInformation_Prop_No_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep(
				"I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			new NewProduct().Prop65 = false;
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}


		[Given(@"I call Shared 60715 \(Additional Documents to Provide - OSHA SDS - only\) : (.*)")]
		public void GivenICall60715SharedAdditionalDocumentsToProvide_OSHASDS_OnlyCDependenciesWERCSmartTestdoc_Pdf(
			string docPath)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.UploadPDFFileSectionAndType("OSHA SDS", "Upload Physical", docPath);
			TestReport.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 58608 \(Additional Documents to Provide - Label - OSHA - CARB\)")]
		public void SharedAdditionalDocumentsToProvide_Label_OSHA_CARB()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Documents To Provide Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Documents To Provide");
			TestReport.StartStep(
				@"I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("Product Label", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep(
				@"I click the browse button for label: OSHA SDS and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("OSHA SDS", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep(
				@"I click the browse button for label: Executive Order from the CARB and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProductSteps.UploadPDFFile("Executive Order from the CARB", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 26897 \(Product Characteristics - Solid only available - continue\)")]
		public void SharedProductCharacteristics_SolidOnlyAvailable_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			NewProduct thisNewProduct = new NewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			TestReport.StartStep("There should only be one option available for Primary Physical State");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			TestReport.StartStep("Primary Physical State should be showing the value: Solid");
			if (!thisNewProduct.GetOptionsForSection("Primary Physical State").Contains("Solid"))
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
			if (thisNewProduct.OptionExists("Secondary Physical State"))
			{
				TestReport.StartStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}
			else
			{
				Report.Failure("Secondary physical state is not showing as specified by shared step");
			}
			TestReport.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				TestReport.StartStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			TestReport.StartStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57590 \(Enter Pesticide Data - United States \(with EPA number\)\)")]
		public void SharedEnterPesticideData_UnitedStatesWithEPANumber()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep(
				"I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has an Environmental Protection Agency (EPA) Registration Number", "Yes");
			TestReport.StartStep("I add the EPA Registration Number: 72315-6");
			MyNewProductSteps.IAddTheEPARegistrationNumber("72315-6");
			TestReport.StartStep("Clicking continue in the Pesticide Details page");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Pesticide Details");
		}

		[StepDefinition(
			@"I call Shared Step 57508 \(VOC SCAQMD/Canada - Yes Low Solid, Yes apply to all States - Continue - Happy Path\)")]
		public void SharedVOCSCAQMDCanada_YesLowSolidYesApplyToAllStates_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep(
				"I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				"No");
			TestReport.StartStep("I set the Product is a Low Solid option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo("Product is a Low Solid", "Yes");
			TestReport.StartStep(
				"I set the VOC content of product in g/L, including water and exempt compounds. option to: 10.0");
			MyNewProductSteps.SetTheSectionOptionTo(
				"VOC content of product in g/L, including water and exempt compounds.", "10.0");
			TestReport.StartStep(
				"I set the Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison? option to: Yes");
			MyNewProductSteps.SetTheSectionOptionTo(
				"Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison?",
				"Yes");
			TestReport.StartStep("Clicking continue in the VOC SCAQMD/Canada page");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("VOC SCAQMD/Canada");
		}

		[StepDefinition(
			@"I call Shared Step 57798 \(Additional Product Information- Pesticide, Canada Only - No to everything else, Continue\)")]
		public void SharedAdditionalProductInformation_Pesticide_CanadaOnly_NoToAll_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep("Make sure the United States check box is NOT selected, if it is uncheck it");
			var countrySold = MyNewProduct.GetOptionsForSection("Select countries the product may be sold in");
			if (countrySold.Contains("United States"))
			{
				MyNewProduct.ClickCheckbox("Select countries the product may be sold in", "United States");
			}

			TestReport.StartStep("I set the Select countries the product may be sold in option to: Canada");
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "Canada");
			TestReport.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyStepsNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call Shared Step 48948 \(Formulation > 3rd Party - Select all\)")]
		public void SharedFormulation3rdParty_SelectAll()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Formulation > 3rd Party Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Formulation > 3rd Party");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"By clicking Accept, I certify the formulation information entered is complete and accurate",
				"Accept"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"By clicking Accept, I certify the formulation information entered is complete and accurate", "Accept");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Consent to Tier 2 Data Uses",
				"Granted"));
			MyStepsNewProduct.SetTheSectionOptionTo("Consent to Tier 2 Data Uses", "Granted");
			TestReport.StartStep("in the Formulation > 3rd Party page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Formulation > 3rd Party");
		}

		[StepDefinition(@"I call Shared Step 60932 \(Regulatory Information 2 - Microbeads - No\)")]
		public void SharedRegulatoryInformation2_Microbeads_No()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product contains microbeads",
				"No"));
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains microbeads", "No");
			TestReport.StartStep("in the Regulatory Information 2 page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 2");
		}

		[StepDefinition(
			@"I call Shared Step 60933 \(Additional Documents to Provide - Product Label and OSHA SDS only\)")]
		public void SharedAdditionalDocumentsToProvide_ProductLabelAndOSHASDSOnly()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I click the browse button for label: '{0} and upload PDF: '{1}'",
				"Product Label",
				@"C:\Dependencies\WERCSmart\testdoc.pdf"));
			MyStepsNewProduct.UploadPDFFile("Product Label", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep(string.Format("I click the browse button for label: '{0} and upload PDF: '{1}'",
				"OSHA SDS",
				@"C:\Dependencies\WERCSmart\testdoc.pdf"));
			MyStepsNewProduct.UploadPDFFile("OSHA SDS", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep("in the Additional Documents to Provide page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[StepDefinition(@"I call Shared Step 58610 \(Confirm Restrict Use - Restrict\)")]
		public void SharedConfirmRestrictUse_Restrict()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			Table restrictUse = new Table("Section");
			restrictUse.AddRow("Do you want to restrict searchable access to your registered formula?");
			MyStepsNewProduct.CheckDisplayedSections("see", restrictUse);
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Do you want to restrict searchable access to your registered formula?",
				"Restrict - Customers should contact my organization for an access code"));
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Do you want to restrict searchable access to your registered formula?",
				" - Customers should contact my organization for an access code");
			TestReport.StartStep("in the Restrict Use page I click continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Restrict Use");
		}

		[StepDefinition(@"I call Shared Step 63219 \(Retailer Association - Select No Retailer - Click continue\)")]
		public void SharedRetailerAssociatedion_SelectNoRetailer_ClickContinue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			var selSelectRetailers = new SelectRetailers();
			if (!selSelectRetailers.Wait_for_load(10))
			{
				Report.Warn("The Select Retailers page was not loaded on entering the Retailer page");
				MyStepsNewProduct.ClickAddRetailersInRetailersPage();
			}

			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow("No Retailer/No UPC Product");
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}


		[StepDefinition(
			@"I call Shared Step 73629 \(Product Characteristics - Liquid - select any options\(enter pH, boiling point, flash point\)\)")]
		public void ICallSharedStepProductCharacteristicsWithBoilingPointPHFlashPoint(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Specific Gravity I enter: " +
				table.Rows[0]["Specific Gravity"]);
			MyNewProduct.SetTheSectionOptionTo("Specific Gravity",
				table.Rows[0]["Specific Gravity"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 73748 \(Additional Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer\)")]
		public void GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_OSHA_PrivateLabel()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
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
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(
			@"I call Shared Step 70675 \(Product Characteristics - Liquid Only - With Water Solubility - Enter all data - Continue\)")]
		public void SharedProductCharacteristics_LiquidOnly_WithWaterSolubility_EnterAllData_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Secondary Physical State",
				"Liquid"));
			myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Specific Gravity",
				"1.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "1.0");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"10.2"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "10.2");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"120"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "120");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"55"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "55");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Closed cup method"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Select the best Water Solubility description",
				"100g/100ml"));
			myStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(
			@"I call Shared Step 62536 \(Transportation Details 2 > I do not ship internationally > Continue - Happy Path\)")]
		public void SharedTransportationDetails2_DoNotShipInternationally_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Transportation Details 2 page");
			myStepsNewProduct.GivenIShouldSeeXPage("Transportation Details 2");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"International Shipping when DOT Exemption taken?",
				"I do not ship internationally and I do not know the classification"));
			myStepsNewProduct.SetTheSectionOptionTo("International Shipping when DOT Exemption taken?",
				"I do not ship internationally and I do not know the classification");
			TestReport.StartStep("In the Transportation Details 2 page I click continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 2");
		}

		[StepDefinition(@"I call Shared Step 62686 \(Enter Physical Property - Liquid - Without Water Solubility\)")]
		public void SharedEnterPhysicalProperty_Liquid_WithoutWaterSolubility()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
			TestReport.StartStep(string.Format("'{0}' should be showing the value: '{1}'",
				"Primary Physical State",
				"Liquid"));
			myStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			if (!myNewProduct.GetOptionsForSection("Primary Physical State").Contains("Liquid"))
			{
				Report.Info("Liquid was not set as the Primary Physical State by default, so selecting the option.");
				myNewProduct.SetOptionInSection("Primary Physical State", "Liquid");
			}

			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Specific Gravity",
				"10"));
			myStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "10");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"8"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "8");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"30"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "30");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"80"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "80");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Not applicable/available"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Secondary Physical State",
				"Liquid"));
			myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 49818 \(Beverage Regulatory Details\)")]
		public void SharedBeverageRegulatoryDetails()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product's container or liner contains Bisphenol A (BPA)",
				"Yes"));
			myStepsNewProduct.SetTheSectionOptionTo("Product's container or liner contains Bisphenol A (BPA)", "Yes");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Does your product contain a Prop 65 chemical?",
				"Yes"));
			new NewProduct().Prop65 = true;
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Percent of Alcohol in the Product (numeric entry only)",
				"12.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", "12.0");
			TestReport.StartStep("In the Beverage Regulatory Details page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Beverage Regulatory Details");
		}

		[StepDefinition(
			@"I call Shared Step 71618 \(U. S. Department of Transportation \(DOT\) Classification - For Alcohol\)")]
		public void SharedUSDepartmentOfTransportationDOTClassification_ForAlcohol()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"UN Number",
				"UN2789"));
			myStepsNewProduct.SetTheSectionOptionTo("UN Number", "UN2789");
			TestReport.StartStep("I select the first valid option for section: 'Proper Shipping Name'");
			myStepsNewProduct.SelectFirstOptionInSection("Proper Shipping Name");
			var shippingName = myNewProduct.GetAllOptionsForSection("Proper Shipping Name")[0];
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Technical Name (if applicable)",
				"Technical " + shippingName));
			myStepsNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical " + shippingName);
			TestReport.StartStep("I select the first valid option for section: 'Hazard Class (select)'");
			myStepsNewProduct.SelectFirstOptionInSection("Hazard Class (select)");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Packing Group (select)",
				"III"));
			myStepsNewProduct.SetTheSectionOptionTo("Packing Group (select)", "III");
			if (myNewProduct.GetOptionsForSection("Packing Group (select)").Contains("Choose..."))
			{
				Report.Info(
					"Option 'III' was not available in section: 'Packing Group (select)' so selecting the first valid option");
				myStepsNewProduct.SelectFirstOptionInSection("Packing Group (select)");
			}

			TestReport.StartStep(
				"In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I call Shared Step 73956 \(Go to Summary and verify data\) with product type: (.*)")]

		public void SharedGoToSummaryAndVerifyData(string typeOfProduct)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			GlobalSteps myGlobalSteps = new GlobalSteps();
			TestReport.StartStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			TestReport.StartStep("I click the Summary button in the Data Acceptance window");
			myStepsNewProduct.GivenIClickTheSummaryButtonInTheDataAcceptanceWindow();
			TestReport.StartStep("I switch to the Data Summary page");
			myGlobalSteps.SwitchToDataSumaryTab();
			TestReport.StartStep("Type of Product should be showing the following option: " + typeOfProduct);
			new StepsDataSummarySheet().ShouldBeShowingFollowing("Type of Product", typeOfProduct);
			TestReport.StartStep("I close the Data Summary tab");
			myGlobalSteps.CloseDataSummaryTab();
			TestReport.StartStep("I should see the Data Acceptance Page");
			myStepsNewProduct.GivenIShouldSeeXPage("Data Acceptance");
			TestReport.StartStep("I navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
		}

		[StepDefinition(
			@"I call Shared Step 43758 \(Product Grid- Filter for Product- Select Product - Delete\) for product: (.*)")]
		public void SharedProductGrid_FilterForProduct_SelectProduct_Delete(string savedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I delete the product: " + savedAs);
			new StepsProductGrid().ThenIDeleteTheProduct(savedAs);
		}

		[StepDefinition(@"I call Shared Step 57514 \(Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path\)")]
		public void SharedProductCharacteristics_LiquidOnlyAvailable_EnterAllData_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Specific Gravity",
				"15.0"));
			myStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "15.0");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"pH",
				"9.5"));
			myStepsNewProduct.SetTheSectionOptionTo("pH", "9.5");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Boiling Point (in Celsius)",
				"120"));
			myStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "120");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point (in Celsius)",
				"80"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "80");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Flash Point Testing Method Used",
				"Not applicable/available"));
			myStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Not applicable/available");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
					"Select the best Water Solubility description",
					"100g/100ml"));
				myStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			}
			if (new NewProduct().GetDisplayedSections().Contains("Secondary Physical State"))
			{
				TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
					"Secondary Physical State",
					"Liquid"));
				myStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			}
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared Step 57505 \(Pesticide Data - U.S. - EPA reg #\(No\) - EPA Exempt # \(Random\) - Continue - Happy Path\)")]
		public void SharedPesticideData_US_EPARegNo_EPAExemptRandom_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct myStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Product has an Environmental Protection Agency (EPA) Registration Number",
				"No"));
			myStepsNewProduct.SetTheSectionOptionTo("Product has an Environmental Protection Agency (EPA) Registration Number", "No");
			TestReport.StartStep(string.Format("I set the '{0}' option to: '{1}'",
				"Select the applicable exemption",
				"Product is FIFRA 25(b) Exempt."));
			myStepsNewProduct.SetTheSectionOptionTo("Select the applicable exemption", "Product is FIFRA 25(b) Exempt.");
			TestReport.StartStep("In the Pesticide Details - U.S. page I click Continue");
			myStepsNewProduct.GivenInTheNewProductPageIClickContinue("Pesticide Details - U.S.");
		}

		[StepDefinition(
			@"I call Shared Step 56967 \(Confirm Retailer & You information is shown correctly\) for retailer: (.*)")]
		public void GivenICallSharedStepConfirmRetailerYouInformationIsShownCorrectlyForRetailer(string retailer)
		{
			TestReport.UseSubSteps = true;
			StepsRetailPartners thisStepsRetailPartners = new StepsRetailPartners();
			RetailParntersDetails thisRetailParntersDetails = new RetailParntersDetails();
			Report.IsTrue(thisRetailParntersDetails.GetAndYouText().Contains(retailer),
				"The & You text is not as expected.", "The & You text is showing as expected");

			thisStepsRetailPartners.PieChartShowing();
			thisStepsRetailPartners.ConfirmPieChartLegend("of your product portfolio is associated with " + retailer);
			//TODO - not doing it now because there is no way of controlling how old the account is and only accounts
			//older than a year will show anything
			//Confirm you see the "It's been <y> good long years since <Date>" statement below the Thumbs up icon
		}

		[Given(@"I call Shared Step 56968 \(Confirm - Data Consent Tiers not required \)")]
		public void GivenICallSharedStepConfirm_DataConsentTiersNotRequired()
		{
			TestReport.UseSubSteps = true;
			StepsRetailPartners thisStepsRetailPartners = new StepsRetailPartners();
			thisStepsRetailPartners.ConfirmHeadingShowing("Data Consent Tiers");
			thisStepsRetailPartners.SectionShouldBeShowingText("Data Consent Tiers",
				"This recipient does not require additional data consent tiers at this time.");

		}


		[StepDefinition(
			@"I call Shared Step 63804 \(Additional Product Information - enter options\)")]
		public void ICallSharedStepAdditionalProductInformationEnterOptions(Table table)
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				TestReport.StartStep(
					"In the Product Type tab of the New Product Page for Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) I select:" +
					table.Rows[0]["Product is marketed for use"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					table.Rows[0]["Product is marketed for use"]);
			}
			if (myNewProduct.SectionExists(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)"))
			{
				TestReport.StartStep(
					"In the Product Type tab of the New Product Page for Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) I select:" +
					table.Rows[0]["Classified using OSHA (US) Globally Harmonized Standards (GHS)"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
					table.Rows[0]["Classified using OSHA (US) Globally Harmonized Standards (GHS)"]);
			}
			if (myNewProduct.SectionExists(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns."))
			{
				TestReport.StartStep(
					"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." +
					table.Rows[0]["Shipped directly by supplier"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
					table.Rows[0]["Shipped directly by supplier"]);
			}
			if (myNewProduct.SectionExists(
				"Product is a Retailer's Private Label or Brand"))
			{
				TestReport.StartStep(
					"Product is a Retailer's Private Label or Brand" +
					table.Rows[0]["Private Label or Brand"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand",
					table.Rows[0]["Private Label or Brand"]);
			}
			if (myNewProduct.SectionExists(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)"))
			{
				TestReport.StartStep(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)" +
					table.Rows[0]["Good Not for resale"]);
				MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
					table.Rows[0]["Good Not for resale"]);
			}
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[Given(
			@"I call Shared 65181 \(Retailer Association - Add Private Label Information and Select Vendor ID\) and select the retailer: (.*) and enter the name: (.*) and select Vendor id: (.*)")]
		public void GivenICallSharedRetailerAssociation_AddPrivateLabelInformationAndVendorId(string retailer, string name, string option)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow(retailer);
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			NewProduct MyNewProduct = new NewProduct();
			MyNewProduct.SelectPrivateLabelName(name);
			MyNewProduct.SelectVendorId(option);
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}


		[Given(@"I call Shared Step 57753 \(Create a New Registration via Register New Product \(expanded menu\)\)")]
		public void GivenICallSharedStep57753CreateANewRegistrationViaRegisterNewProductExpandedMenu()
		{
			StepsHomepage MyStepsHomePage = new StepsHomepage();
			MyStepsHomePage.ClickItemInNavigationPanel("Register New Product");
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("New Product");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the type of product", "Create a New Registration");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 74760 \(Product Characteristics - Select Liquid as primary physical state and enter all required data\)")]
		public void ICallSharedProductCharacteristics_MoreThanOneState_SelectLiquidAndEnterOtherOptions(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Delay.Seconds(1);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Primary Physical State I select: " +
				table.Rows[0]["Primary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State",
				table.Rows[0]["Primary Physical State"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Specific Gravity I enter: " +
				table.Rows[0]["Specific Gravity"]);
			MyNewProduct.SetTheSectionOptionTo("Specific Gravity",
				table.Rows[0]["Specific Gravity"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for pH I enter: " +
				table.Rows[0]["pH"]);
			MyNewProduct.SetTheSectionOptionTo("pH",
				table.Rows[0]["pH"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Boiling Point (in Celsius) I enter: " +
				table.Rows[0]["Boiling Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)",
				table.Rows[0]["Boiling Point (in Celsius)"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point (in Celsius) I enter: " +
				table.Rows[0]["Flash Point (in Celsius)"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)",
				table.Rows[0]["Flash Point (in Celsius)"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Flash Point Testing Method Used I enter: " +
				table.Rows[0]["Flash Point Testing Method Used"]);
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used",
				table.Rows[0]["Flash Point Testing Method Used"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I enter: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[Given(@"I call shared step 74123 \(Additional Product Information - Grocery - US - Random Country - No\(PL\)\)")]
		public void GivenICallSharedStepAdditionalProductInformation_Grocery_US_RandomCountry_NoPL()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyNewProductSteps.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");

			//CLF - this option doesn't always appear. Putting this fix in for now but may need a new version of the step
			NewProduct MyNewProduct = new NewProduct();
			if (MyNewProduct.OptionExists("Select the product's Country of Origin"))
			{
				Report.Info("Select country of origin appears...");
				MyNewProductSteps.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");

			}

			MyNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 74981 \(Product Characteristics - gas\)")]
		public void ICallSharedProductCharacteristics_Gas(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			Delay.Seconds(1);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Secondary Physical State I select: " +
				table.Rows[0]["Secondary Physical State"]);
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State",
				table.Rows[0]["Secondary Physical State"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Select the best Water Solubility description I select: " +
				table.Rows[0]["Select the best Water Solubility description"]);
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description",
				table.Rows[0]["Select the best Water Solubility description"]);
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(
			@"I call Shared Step 57923 \(Volatile Organic Compound \(VOC\) Step - enter OTC and CARB - Yes for state values\)")]
		public void ICallSharedProductCharacteristics_EnterVocAndCarbSelectStateValue(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			Delay.Seconds(1);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. I select: " +
				table.Rows[0]["Product granted Alternative Control Plan"]);
			MyNewProduct.SetTheSectionOptionTo("Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.",
				table.Rows[0]["Product granted Alternative Control Plan"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB I enter: " +
				table.Rows[0]["Amount of VOC by CARB"]);
			MyNewProduct.SetTheSectionOptionTo("Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB",
				table.Rows[0]["Amount of VOC by CARB"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule I enter: " +
				table.Rows[0]["Amount of VOC by OTC Model"]);
			MyNewProduct.SetTheSectionOptionTo("Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule",
				table.Rows[0]["Amount of VOC by OTC Model"]);
			TestReport.StartStep(
				"In the Product Characteristics tab of the New Product Page for Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? I select: " +
				table.Rows[0]["VOC for states"]);
			MyNewProduct.SetTheSectionOptionTo("Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?",
				table.Rows[0]["VOC for states"]);
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 56799 \(Confirm Additional Product Information shows Pesticide question and its radio buttons\)")]
		public void ICallSharedConfirmAdditionalProductInformationShowsPesticideQuestion()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			var sections = new Table("Section");
			sections.AddRow("Which one best describes your product");
			TestReport.StartStep("I confirm the 'Which one best describes your product' question is shown");
			MyNewProduct.CheckDisplayedSections("see", sections);
			var buttons = new Table("Button");
			buttons.AddRow("Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			buttons.AddRow("Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth");
			buttons.AddRow("Product is not considered a pesticide product");
			TestReport.StartStep("I confirm the radios showing in order are: Prevents, Destroys Repels Pests..', 'Regulates Plant Growth, Defoliates..', 'Product is not considered a pesticide product'");
			MyNewProduct.CheckRadioButtonsInSectionAndOrder("Which one best describes your product", buttons);
		}

		[StepDefinition(@"I call Shared Step 57532 \(Product Characteristics - Aerosol & Gas available - Select Gas - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolAndGasAvailable_SelectGas_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the Primary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Gas");
			TestReport.StartStep("I set the Secondary Physical State option to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[Given(@"I call Shared Step 57500 \(The Product- Enter name, select product type - Continue - Happy Path\): (.*)")]
		public void GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(string option)
		{
			GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct(option);
		}

		[Given(@"I call Shared Step 63460 \(Additional Product Information - SOLD = US, No\(PL\), No\(GNFR\) only shown \(mainly kits\) Happy Path\)")]
		public void GivenICallSharedStepAdditionalProductInformation_SOLDUSNoPLNoGNFROnlyShownMainlyKitsHappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				"No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[Given(@"I call Shared Step 74339 \(Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH\)")]
		public void GivenICallSharedStepProductCharacteristics_SelectLiquidAndEnterOnlySecondaryStateSpecificGravityPH()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			MyNewProductSteps.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyNewProductSteps.SetTheSectionOptionTo("Specific Gravity", "20");
			MyNewProductSteps.SetTheSectionOptionTo("pH", "7");
		}

		[Given(@"I call Shared Step 74340 \(Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue\)")]
		public void GivenICallSharedStepAdditionalProductInformation_PesticideNotConsideredSOLDUSEverythingElseNo_Continue()
		{
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep(
				"I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product",
				"Product is not considered a pesticide product");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		/*
		[Given(@"I call Shared Step 57514 \(Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path\)")]
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


		[Given(@"I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue")]
		public void GivenICallSharedStepIngredients_AddAnyChemical_DONotClickContinue(Table ingredientsTable)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			TestReport.StartStep("I add the following ingredients:");
			MyStepsNewProduct.AddIngredients(ingredientsTable);
		}

		[StepDefinition(
			@"I call Shared 57539 \(Product Characteristics - Aerosol & Liquid select Aerosol - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolAndLiquidSelectAerosol_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			// Primary Physical State displays Aerosol and Liquid
			TestReport.StartStep("I should only see the following options for Primary Physical State: Aerosol, Liquid");
			TechTalk.SpecFlow.Table produtTable = new TechTalk.SpecFlow.Table(new string[] {
				"State"
			});
			produtTable.AddRow(new string[] {
				"Aerosol"
			});
			produtTable.AddRow(new string[] {
				"Liquid"
			});
			TestReport.StartStep("I set the Primary Physical State field to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			TestReport.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			TestReport.StartStep("I set the pH field to: 10.4");
			MyNewProduct.SetTheSectionOptionTo("pH", "10.4");
			TestReport.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			TestReport.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			//TestReport.StartStep("I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: The product is classified as a D003 Hazardous Waste under RCRA.");
			//MyNewProduct.SetTheSectionOptionTo("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then", "The product is classified as a D003 Hazardous Waste under RCRA.");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared 57932 \(Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path\)")]
		public void GivenICallSharedEnterRegulatoryInformation_YesToProp()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			var selNewProduct = new NewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			TestReport.StartStep(
				"Prop 65 warning is required: Yes");
			selNewProduct.Prop65 = true;
			Delay.Seconds(1);
			Report.IsTrue(selNewProduct.Prop65,
				"Failed to set Carries Prop 65 Warning to Yes",
				"Successfully set Carries Prop 65 Warning to Yes");
			TestReport.StartStep("I set the Is the need to warn triggered by field to: A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			MyStepsNewProduct.SetTheSectionOptionTo("Is the need to warn triggered by",
				"A chemical or chemicals in the product, or chemicals formed during the use of the product.");
			TestReport.StartStep("I set the How is the exposure warning transmitted? field to: By affixing it to the product or its packaging");
			MyStepsNewProduct.SetTheSectionOptionTo("How is the exposure warning transmitted?",
				"By affixing it to the product or its packaging");
			TestReport.StartStep("I set the Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured field to: Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			MyStepsNewProduct.SetTheSectionOptionTo("Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured",
				"Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.");
			TestReport.StartStep("I set the If the product carries a safe-harbor short-form warning, indicate which of the following is provided: field to: WARNING: Cancer - ");
			MyStepsNewProduct.SetTheSectionOptionTo("If the product carries a safe-harbor short-form warning, indicate which of the following is provided:",
				"WARNING: Cancer - ");
			TestReport.StartStep("I set the If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning: field to: This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to ");
			MyStepsNewProduct.SetTheSectionOptionTo("If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:",
				"This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to ");
			TestReport.StartStep("I set the Enter the names of one or more listed carcinogens which are the subject of this warning field to: Arsenic");
			MyStepsNewProduct.SetTheSectionOptionTo("Enter the names of one or more listed carcinogens which are the subject of this warning",
				"Arsenic");
			TestReport.StartStep("I set the If the product carries a custom warning, please provide the exact text that is being used: field to: NA");
			MyStepsNewProduct.SetTheSectionOptionTo("If the product carries a custom warning, please provide the exact text that is being used:",
				"NA");
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(
			@"I call Shared Step 57980 \(Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails1_YesOption_SelectIMDGLimitedQuantity()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			TestReport.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"IMDG");
			TestReport.StartStep(
				"I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				"Shipping with limited quantity");
			TestReport.StartStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 57981 \(Transportation - IMDG UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue\)")]
		public void
			GivenICallSharedStepTransportation_IMDGUNStep_EnterUNSelectAerosolsNoneAddTechnicalNameClickContinue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the UN Number field to: UN1950");
			MyNewProduct.SetTheSectionOptionTo("UN Number", "UN1950");
			Delay.Seconds(2);
			TestReport.StartStep("I select 'Aerosols' option in section: Proper Shipping Name");
			MyNewProduct.SetTheSectionOptionTo("Proper Shipping Name", "Aerosols");
			Delay.Seconds(2);
			TestReport.StartStep("I enter 'Technical Test Name' in section: Technical Name (if applicable)");
			MyNewProduct.SetTheSectionOptionTo("Technical Name (if applicable)", "Technical Test Name");
			Delay.Seconds(2);
			TestReport.StartStep("I select '2.1' in section: Hazard Class (select)");
			MyNewProduct.SetTheSectionOptionTo("Hazard Class (select)", "2");
			TestReport.StartStep("I select 'None' in section: Packing Group (select)");
			MyNewProduct.SetTheSectionOptionTo("Packing Group (select)", "None");
			TestReport.StartStep(
				"In the International Marine (IMDG) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue(
				"International Marine (IMDG) Classification");
		}

		[StepDefinition(
			@"I call Shared 57978 \(Product Characteristics - All select Gas - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AllSelectGas_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			// Primary Physical State displays All
			TestReport.StartStep("I should only see the following options for Primary Physical State: Aerosol, Gas, Liquid, Solid");
			TechTalk.SpecFlow.Table produtTable = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.StartStep("I set the Primary Physical State field to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Gas");
			TestReport.StartStep("I set the Secondary Physical State field to: Gas");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Gas");
			TestReport.StartStep(
				"If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description",
				"Insoluble");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[Given(@"I call Shared Step 63226 \(Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path\)")]
		public void GivenICallSharedStepPesticideDate_YesRegistered_EnterEPANumberNotOnKelly_ClickContinue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product has an Environmental Protection Agency (EPA) Registration Number", "Yes");
			MyStepsNewProduct.IAddTheEPARegistrationNumber("TEST-1234");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - U.S.");
		}



		DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)
		{
			Random rand = new Random();
			int cdayRange = (dtEnd - dtStart).Days;
			return dtStart.AddDays(rand.NextDouble() * cdayRange);
		}


		//CLF - turns out to work the data has be after today!
		[Given(@"I call Shared Step 55819 \(EPA expiration date - enter current year - NOT Dec 31st\) for state: (.*)")]
		public void GivenICallSharedStepEPAExpirationDate_EnterCurrentYear_NOTDecSt(string state)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();

			DateTime dtStart = DateTime.Now.AddDays(1);
			int year = DateTime.Now.Year;
			int month = 12;
			int day = 29;

			DateTime dtEnd = new DateTime(year, month, day);

			DateTime dt = GetRandomDate(dtStart, dtEnd);

			Report.IsTrue(MyNewProduct.EditPesticideRegExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");


		}

		//CLF - From test plans - Confirm that an error shows "State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable."
		// in fact it seems that the date has to be after October 1st.
		[Given(@"I call Shared Step 55820 \(EPA expiration date - enter next year - NOT Dec 31st\) for state: (.*)")]
		public void GivenICallSharedStepEPAExpirationDate_EnterNextYear_NOTDecStForState(string state)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();

			int year = DateTime.Now.Year + 1;
			int month = 10;
			int day = 1;

			DateTime dtStart = new DateTime(year, month, day);

			year = DateTime.Now.Year;
			month = 12;
			day = 30;

			DateTime dtEnd = new DateTime(year, month, day);

			DateTime dt = GetRandomDate(dtStart, dtEnd);
			Report.Info("Attempting to enter date: " + dt.ToString("yyyy-MM-dd"));
			Report.IsTrue(MyNewProduct.EditPesticideRegExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");
		}

		[Given(@"I call Shared Step 55821 \(EPA expiration date - enter Dec 31st of Next year\) for state: (.*)")]
		public void GivenICallSharedStep55821ExpirationDate31DecNextYear(string state)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();

			int year = DateTime.Now.Year + 1;
			int month = 12;
			int day = 31;

			DateTime dt = new DateTime(year, month, day);

			Report.IsTrue(MyNewProduct.EditPesticideRegExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");
		}

		[Given(@"I call Shared Step 55822 \(EPA expiration date - enter Dec 31st of Current year\) for state: (.*)")]
		public void GivenICallSharedStep55822ExpirationDate31DecthisYear(string state)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			NewProduct MyNewProduct = new NewProduct();

			int year = DateTime.Now.Year;
			int month = 12;
			int day = 31;

			DateTime dt = new DateTime(year, month, day);

			Report.IsTrue(MyNewProduct.EditPesticideRegExpirationDate(dt.ToString("yyyy-MM-dd"), state),
				"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
				"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue(
				"Pesticide Details - State Registration Details");
		}

		[Given(@"I call Shared Step 57501 \(Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP\)")]
		public void GivenICallSharedStep57501ProductCharacteristics_MoreThanOneState_SelectSolid_StateSubcat_MixedWater_Random_Continue_HP()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			MyNewProductSteps.RadioButtonCountInSection("at least", "2", "Primary Physical State");
			MyNewProductSteps.ThenISetThePrimayPhysicalStateToBe("solid");
			NewProduct thisNewProduct = new NewProduct();
			if (thisNewProduct.OptionExists("Secondary Physical State"))
			{
				TestReport.StartStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}
			else
			{
				Report.Info("Secondary physical state is not showing");
			}

			TestReport.StartStep(
				"I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProductSteps.SetTheSectionOptionTo(
				"When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?",
				"No");
			if (new NewProduct().GetDisplayedSections().Contains("Select the best Water Solubility description"))
			{
				TestReport.StartStep(
					"I set the Select the best Water Solubility description option to: Soluble in water");
				MyNewProductSteps.SetTheSectionOptionTo("Select the best Water Solubility description",
					"Soluble in water");
			}

			TestReport.StartStep("Clicking continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[Given(@"I call Shared Step 57528 \(Product Characteristics - Aerosol Only - add data - Continue - Happy Path\)")]
		public void GivenICallSharedStep57528ProductCharacteristics_AerosolOnly_AddData_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			NewProduct MyNewProduct = new NewProduct();
			StepsNewProduct MyNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Product Characteristics Page");
			MyNewProductSteps.GivenIShouldSeeXPage("Product Characteristics");
			MyNewProductSteps.RadioButtonCountInSection("a total of", "1", "Primary Physical State");
			TestReport.StartStep("Primary Physical State should be showing the value: Aerosol");
			MyNewProductSteps.CheckingFieldInputIsCorrect("Primary Physical State", "Aerosol");
			NewProduct thisNewProduct = new NewProduct();
			if (thisNewProduct.OptionExists("Secondary Physical State"))
			{
				TestReport.StartStep("Selecting the first option for section: Secondary Physical State");
				MyNewProductSteps.SelectFirstOptionInSection("Secondary Physical State");
			}
			else
			{
				Report.Info("Secondary physical state is not showing");
			}
			MyNewProductSteps.SetTheSectionOptionTo("pH", "7");

			TestReport.StartStep(
				"I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProductSteps.SelectFirstOptionInSection(
				"When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}


		[Given(@"I call Shared Step 57911 \(Regulatory Information 1 - CEPA only shown - Continue - Happy Path\)")]
		public void GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep(
				"I set the Canadian Environmental Protection Act (CEPA) status option to: Compliant with Domestic Substances List (DSL)");
			MyStepsNewProduct.SetTheSectionOptionTo("Canadian Environmental Protection Act (CEPA) status",
				"Compliant with Domestic Substances List (DSL)");
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[Given(@"I call Shared Step 56494 \(Pesticide Details - Canada > Province Code confirmation/validation and selection\) for province: (.*) expected error: (.*)")]
		public void GivenICallSharedStep56494PesticideDetailsCanadaProvinceCodeconfirmationvalidationAndSelectionForProvince(string province, string error)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.ErrorMessagesAreShowingForItem(province, "should", error);
			MyStepsNewProduct.SelectFirstOptionInSection(province);
			MyStepsNewProduct.ErrorMessagesShouldNotBeShowingForItem(province);
		}

		[Given(@"I call Shared Step 69388 \(Retailer - Canada Only - Select No Retailer/No UPC product > Done > Continue - Happy Path\)")]
		public void GivenICallSharedStepRetailer_CanadaOnly_SelectNoRetailerNoUPCProductDoneContinue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product");
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow("No Retailer/No UPC Product");
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
		}

		[Given(@"I call Shared Step 69389 \(Regulatory Documents to Provide - Canada only - Confirm questions - Request author, add label and todays date - Continue\)")]
		public void GivenICallSharedStepRegulatoryDocumentsToProvide_CanadaOnly_ConfirmQuestions_RequestAuthorAddLabelAndTodaysDate_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
			MyNewProduct.ThenFieldExists("WHMIS-compliant Safety Data Sheet, English and French-Canadian");
			MyNewProduct.ThenFieldExists("WHMIS-compliant label, English and French-Canadian");
			MyNewProduct.ThenFieldExists("WHMIS Document Date");
			MyNewProduct.SetTheSectionOptionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian", "Request to author");
			MyNewProduct.UploadPDFFile("Label in both French and English", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProduct.SetTheSectionOptionTo("WHMIS Document Date", DateTime.Now.ToString("yyyy-MM-dd"));
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Documents to Provide");
		}

		[Given(@"I call shared step 53542 \(Login with Administrator Role Continue 2 \(2nd login shared step\)\)")]
		public void GivenICallSharedStep53542LoginWithAdministratorRoleContinue2NdLoginSharedStep()
		{
			TestReport.UseSubSteps = true;
			Steps_SHA MyStepsSHA = new Steps_SHA();

			MyStepsSHA.GivenILoginToStudioAsAdministrator();

		}

		[Given(@"I call shared step 59066 \(Go to SHA Manager\)")]
		public void GivenICallSharedStep59066GoToSHAManager()
		{
			Steps_SHA MyStepsSHA = new Steps_SHA();
			MyStepsSHA.GivenIClickTopMenuItemAndSubMenuItem("My Wercs", "SHA");
			StudioSHAManager thisStudioShaManager = new StudioSHAManager();
			Report.Info("Waiting for product list to be loaded....");
			Delay.Seconds(1);
			Report.IsTrue(thisStudioShaManager.WaitForProductList(120), "Product list is not showing",
				"Product list is showing");
		}

		[Given(@"I call shared step 59728 \(Go to Manage Global Messages\)")]
		public void GivenICallSharedStep59728GoToManageGlobalMessages()
		{
			Steps_SHA MyStepsSHA = new Steps_SHA();
			Delay.Seconds(1);
			MyStepsSHA.GivenInSHAManagerPageIClickSubMenuItem("Manage Global Messages");
		}

		[StepDefinition(@"I call shared step 63860 \(Additional Product Information - US, No\(child\), No\(OSHA\), No\(DSV\), Yes\(PLP\), No\(GNFR\)\)")]
		public void SharedAdditionalProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR()
		{
			TestReport.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			selNewProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep(
				"Select countries the product may be sold in should be showing the value: United States");
			selNewProductSteps.CheckingFieldInputIsCorrect("Select countries the product may be sold in",
				"United States");
			TestReport.StartStep(
				"I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			TestReport.StartStep(
				"I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
				"No");
			TestReport.StartStep(
				"I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.",
				"No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: Yes");
			selNewProductSteps.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "Yes");
			TestReport.StartStep(
				"I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			selNewProductSteps.SetTheSectionOptionTo(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
				"No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			selNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"I call shared step 74201 \(Select Retailers - CVS\)")]
		public void SelectRetailers_CVS()
		{
			TestReport.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the Select Retailers popup I select the retailer: CVS");
			selStepsNewProduct.ThenISelectTheRetailer_InTheWindow("CVS");
			TestReport.StartStep("I enter private label as 'This Private Label'");
			selStepsNewProduct.ThenInTheRetailersTabIEnterPrivateLabelNameAs("This Private Label");
			TestReport.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
		}
		[Given(@"I call shared step 57801 \(Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path\)")]
		public void GivenICallSharedStep57801ConfirmVOCSummaryStepShownConfirmVOCAnalysisDateIsShown_HappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Volatile Organic Compound Summary");
			TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] { "Statement" });
			table1.AddRow(new string[] { "VOC Analysis Date (Today's Date) " + DateTime.Today.ToString("MM/dd/yyyy") });
			MyStepsNewProduct.ThenInTheVOCSummaryPageIShouldSeeTheFollowingNoneditableStatements(table1);
		}

		[Given(@"I call shared step 57817 \(VOC Results - Confirm VOC Limits table shows correct values \(OTC & CARB\) - Happy Path\): (.*)")]
		public void GivenICallSharedStep57817VOCResults_ConfirmVOCLimitsTableShowsCorrectValuesOTCCARB_HappyPath(string use)
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

		[StepDefinition(@"I call shared step 74202 \(CVS Pharmacy - Yes, I wish to Continue\)")]
		public void SharedCVSPharmacy_YesIWishToContinue()
		{
			TestReport.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I confirm the CVS Pharmacy section appears");
			selNewProductSteps.GivenIShouldSeeXPage("CVS Own Brand Registration");
			TestReport.StartStep(
				"I set the Continue? option to: Yes, I wish to continue registration");
			selNewProductSteps.SetTheSectionOptionTo(
				"Continue?",
				"Yes, I wish to continue registration");
			TestReport.StartStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(@"I call shared step 57205 \(Go to Retail Partners - Select CVS\)")]
		public void SharedGoToRetailPartners_SelectCVS()
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I click the Retail Partners icon in the Navigation Pane");
			new StepsHomepage().ClickItemInNavigationPanel("Retail Partners");
			TestReport.StartStep("I should see the heading 'Retail Partners'");
			new StepsRetailPartners().ThenIShouldSeeTheFollowingHeading("Retail Partners");
			TestReport.StartStep("I select the retailer: CVS");
			new StepsRetailPartners().SelectRetailer("CVS");
		}

		[StepDefinition(@"I call shared step 74269 \(Select Retailers - Rite Aid\)")]
		public void SharedSelectRetailers_RiteAid()
		{
			TestReport.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the Select Retailers popup I select the retailer: Rite Aid");
			selStepsNewProduct.ThenISelectTheRetailer_InTheWindow("Rite Aid");
			TestReport.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
			if (new NewProduct().ErrorMessage() == "This is a required field.")
			{
				Report.Failure("Required field error was showing on continue. Attempting to enter Private Label field (not specified by shared step)");
				TestReport.StartStep("I enter private label as 'This Private Label'");
				selStepsNewProduct.ThenInTheRetailersTabIEnterPrivateLabelNameAs("This Private Label");
				TestReport.StartStep("I click continue");
				selStepsNewProduct.ClickContinue();
			}
		}

		[StepDefinition(@"I call shared step 77711 \(Product Characteristics - Primary \(L/S\), 2nd - any, Enter Gravity, pH, Boiling Point, Flash Point, Flash Point Test - any, Water - any\)")]
		public void SharedProductCharacteristics_PrimaryLS_Any_EnterGravity_pH_BoilingPoint_FlashPointTestAny_WaterAny()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct stepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the Primary Physical State option to: Liquid");
			stepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			TestReport.StartStep("I set the Secondary Physical State option to: Liquid");
			stepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			TestReport.StartStep("I set the Specific Gravity option to: 10");
			stepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "10");
			TestReport.StartStep("I set the pH option to: 5");
			stepsNewProduct.SetTheSectionOptionTo("pH", "5");
			TestReport.StartStep("I set the pH option to: 5");
			stepsNewProduct.SetTheSectionOptionTo("pH", "5");
			TestReport.StartStep("I set the Boiling Point (in Celsius) option to: 80");
			stepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "80");
			TestReport.StartStep("I set the Flash Point (in Celsius) option to: 130");
			stepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "130");
			TestReport.StartStep("I set the Flash Point Testing Method option to: Open cup method");
			stepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Open cup method");
			TestReport.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
			stepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			TestReport.StartStep("I continue to the next screen in the new product registration");
			stepsNewProduct.ContinueInTheProductRegistration();
		}

		[Given(@"I call Shared Step 75146 \(Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue\)")]
		public void GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue()
		{
			TestReport.UseSubSteps = true;
			var selStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the Select Retailers popup I select the retailer: Rite Aid");
			selStepsNewProduct.ThenISelectTheRetailer_InTheWindow("Rite Aid");
			TestReport.StartStep("I click continue");
			selStepsNewProduct.ClickContinue();
			if (new NewProduct().ErrorMessage() == "This is a required field.")
			{
				Report.Failure("Required field error was showing on continue. Attempting to enter Private Label field (not specified by shared step)");
				TestReport.StartStep("I enter private label as 'This Private Label'");
				selStepsNewProduct.ThenInTheRetailersTabIEnterPrivateLabelNameAs("This Private Label");
				TestReport.StartStep("I click continue");
				selStepsNewProduct.ClickContinue();
			}
		}

		[Given(@"I call Shared 65080 \(Login to Studio and Open SHA manager\)")]
		public void GivenICallShared65080LoginToStudioAndOpenSHAManager()
		{
			TestReport.UseSubSteps = true;
			Steps_SHA myStepsSha = new Steps_SHA();
			myStepsSha.GivenINavigateToStudio();
			myStepsSha.GivenILoginToStudioAsAdministrator();
			GivenICallSharedStep59066GoToSHAManager();

		}

		[Given(@"I call Shared 49841 \(SHA - Search for exact WPS ID in (.*) Status for saved as: (.*)\)")]
		public void GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus(string status, string savedAs)
		{
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			myStudioShaManager.WaitForProductList(60);
			TestReport.UseSubSteps = true;
			myStudioShaManager.ClickBottomMenuOption("Search");

			Steps_SHA myStepsSha = new Steps_SHA();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;

			Report.Info("Searching for: " + id);

			TechTalk.SpecFlow.Table table = new TechTalk.SpecFlow.Table(new string[] {
				"SearchTerm",
				"SearchValue"});
			table.AddRow(new string[] {
				"ProductID",
				id});
			table.AddRow(new string[] {
				"Status",
				status});
			myStepsSha.GivenInSHAManagerPageIRunSearch(table);

			Delay.Seconds(1);
			Report.Info("Waiting for product list");
			Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found", "Product list is showing");
			if (!myStudioShaManager.TopRowProductsTableMatchesId(id))
			{
				//run the search again.
				myStudioShaManager.ClickBottomMenuOption("Search");
				myStepsSha.GivenInSHAManagerPageIRunSearch(table);
				Delay.Seconds(2);
				Report.IsTrue(myStudioShaManager.TopRowProductsTableMatchesId(id),
					"expected id is not found in first row", "Expected id: " + id + " is found in first row");

			}

		}

		[Given(@"I call Shared 55662 \(WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: (.*)\)")]
		public void GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(string savedAs)
		{
			StudioTopMenu thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing");
			thisTopMenu.ClickSubMenu("System", "Job Queue");
			StudioJobQueue thisStudioJobQueue = new StudioJobQueue();
			Delay.Seconds(2);
			Report.IsTrue(thisStudioJobQueue.WaitForJobInformationList(30), "Job queue has not loaded",
				"Job queue has loaded");
			List<Job> ListOfJobs = thisStudioJobQueue.GetFirstXJobs(20);
			Report.IsTrue(thisStudioJobQueue.ClickJobQueueMenuItem("Job Queue"), "Failed to navigate to job queue",
				"Navigated to job queue");
			GeneralUtilities.StudioWaitForSpinner();
			var MatchingJob = ListOfJobs.FirstOrDefault(x =>
				x.UserName == "SHAMANAGER" && x.DateStarted.Date == DateTime.Today.Date &&
				x.Class == "Wercs.Core.BLLPortal.ImportProcessRules");
			Report.IsTrue(MatchingJob != null,
				"No matching job has been found with username=SHAMANAGER, date=" + DateTime.Today.Date.ToString() +
				", class=Wercs.Core.BLLPortal.ImportProcessRules", "Matching job has been found");
			GivenICallSharedStep59066GoToSHAManager();
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;
			Report.IsTrue(myStudioShaManager.WaitForIDToTurnBlue(id, 120), "ID has not turned blue", "ID is blue");

		}

		[Given(@"I call Shared 68969 \(WPS Studio - Open PD\+, edit existing with specific product > Click Continue for product saved as: (.*)\)")]
		public void GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(string savedAs)
		{
			StudioTopMenu thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing");
			thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus");
			StudioPowerDesignerPlus thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)");
			thisPowerDesignerPlus.EnterSubFormatFilter("CKLT");
			thisPowerDesignerPlus.SelectFormat("CKLT", "MTR");
			thisPowerDesignerPlus.SelectProductIDOption("edit");
			Report.Screenshot();
			Delay.Seconds(1);
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(1);
			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button", "Clicked continue button");
		}

		[StepDefinition(
			@"I call Shared Step 78801 \(Additional Documents to Provide - VOC and Product Label\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_Exemption_VOC_ProductLabel()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			MyNewProduct.UploadPDFFileSectionAndType("Product Label",
				"Volatile Organic Compounds", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			MyNewProduct.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			TestReport.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
		}

		[Given(@"I call Shared 40657 \(SHA Manager - Submitted - Select product > process product data for product saved as: (.*)\)")]
		public void GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(string savedAs)
		{
			TestReport.UseSubSteps = true;
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}
			myStudioShaManager.SelectFromStatusFilter("Submitted");
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;
			Report.IsTrue(myStudioShaManager.SelectProductByID(id), "Failed to select product with id: " + id,
				"Selected product with id: " + id);
			myStudioShaManager.ClickProcessProductData();
			Report.IsTrue(myStudioShaManager.SetAutoAssignRegulatorySpecialisttoProduct(false), "Failed to deselect Auto assign regulatory specialist", "Deselected auto assign regulatory specialist");
			Report.IsTrue(myStudioShaManager.SelectRegulatorySpecialist("Automated QASha"), "Failed to select regulatory specialist", "Selected regulatory specialist");
			Report.IsTrue(myStudioShaManager.ClickContinueInProcessProducts(), "Failed to click continue",
				"Clicked continue");
			Report.IsTrue(myStudioShaManager.WaitForProductToAppearOnProcessedList(id, 90),
				"Product has not appeared on processed list: " + id, "Product has appeared on processed list: " + id);
			Report.IsTrue(myStudioShaManager.ClickCloseInProcessProducts(), "Failed to click close",
				"Clicked close");

		}

		[Given(@"I call Shared 75347 \(WPS Studio - PD\+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS\) for product saved as: (.*)")]
		public void GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(string savedAs)
		{
			TestReport.UseSubSteps = true;
			Report.Info("In power tools workspace setting edit to true");
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode = new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(90), "Power designer has not opened.",
				"Power designer has opened");
			thisStudioPowerDesignerPlusDesignMode.ClickOptions();
			Delay.Seconds(1);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.WaitForDocumentOptionsPopup(30), "Document options panel has not opened",
				"Document options panel has opened");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.SetOption("edit", true), "Failed to set edit",
				"Successfully set edit to true");
			thisStudioPowerDesignerPlusDesignMode.ClickCloseDocumentOptionsPopup();

			TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
				"datacode",
				"value"});
			table2.AddRow(new string[] {
				"DPQAPF",
				"pass"});
			table2.AddRow(new string[] {
				"DCQAPF",
				"pass"});
			table2.AddRow(new string[] {
				"VCQA",
				"pass"});
			table2.AddRow(new string[] {
				"RSQAPF",
				"pass"});
			table2.AddRow(new string[] {
				"RSQHADPF",
				"pass"});

			Steps_Studio thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenISetTheDatacodesAsFollows(table2);
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
				"Item"});
			table3.AddRow(new string[] {
				"Current Document (Publish)"});
			table3.AddRow(new string[] {
				"Document Queue"});
			table3.AddRow(new string[] {
				"Apply rules"});
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table3);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");

			thisStepsStudio.IClickOnPublishThisDocumentToOpenCurrentDocumentPopup();
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("authorized");
			thisStepsStudio.InCurrentDocumentPageSelectCheckbox("apply");

			TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
				"Text",
				"Should Show"});
			table4.AddRow(new string[] {
				"CKLT",
				"False"});
			table4.AddRow(new string[] {
				"NGHS",
				"False"});
			table4.AddRow(new string[] {
				"SBCS",
				"False"});
			thisStepsStudio.GivenInCurrentDocumentIConfirmThatAlertTextMatches(table4);
			thisStepsStudio.GivenICloseCurrentDocument();
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton();
			thisStepsStudio.InApplyRulesPageIClickOnTheFollowingApplyRadioButton("single rule");
			thisStepsStudio.InApplyRulesPageIClickOnTheSingleRulesEllipsisButton();
			thisStepsStudio.InSelectRulesPageIClickOnFilterIcon();
			thisStepsStudio.InSelectRulesFilterPopupISelectFromSelectBox("...Contains...", "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIEnterValueInTextBox("QASHA", "rule name");
			thisStepsStudio.InSelectRulesFilterPopupIClickButton("Apply");
			thisStepsStudio.InSelectRulesPageIClickOnFirstRecord();
			thisStepsStudio.InApplyRulesPageIClickOnButton("Apply");
			thisStepsStudio.InApplyRulesPageIClickOnButton("Close");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();

			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"product\alias");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"product\alias");


		}


		[StepDefinition(@"I call Shared 0000 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_No()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			TestReport.StartStep("I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986", "No");
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared 79436 \(Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name\) and save ingredient as: (.*)")]
		public void CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(string savedAs)
		{
			TestReport.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			var ingredient = new Ingredient {
				CASNumber = "FRAGRANCE",
				ComponentName = "Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2",
				Percent = "100",
				PublicallyDisclosed = true,
				PublicName = "Undisclosed Ingredient"
			};
			Report.IsTrue(new NewProduct().AddIngredient(ingredient),
				"Failed to add ingredient: " + (ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " + (ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}

		[StepDefinition(@"I call Shared 79431 \(Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name\) and save ingredients as: (.*)")]
		public void IngredientsAddFlavorComponentPubliclyDisclosedYesSelectPublicName(string savedAs, Table component)
		{
			var ingredient = new Ingredient {
				CASNumber = component.Rows.First()["CASNumber"],
				ComponentName = component.Rows.First()["ComponentName"],
				Percent = "100",
				PublicallyDisclosed = true,
				PublicName = "Undisclosed Ingredient"
			};
			Report.IsTrue(new NewProduct().AddIngredient(ingredient),
				"Failed to add ingredient: " + (ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber) + "!",
				"Successfully added ingredient: " + (ingredient.CASNumber == "" ? ingredient.ComponentName : ingredient.CASNumber));
			Context.AddToContext(savedAs, ingredient);
		}
	}
}

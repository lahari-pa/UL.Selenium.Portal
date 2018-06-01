using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.Formula.Functions;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Selenium_Classes;

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
			MyStepsNewProduct.SetTheSectionOptionTo("Select the type of product to create", "Create a New Registration");
			TestReport.StartStep("In the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57561 \(The Product - Enter Product Name and select Type of Product\): (.*)")]
		public void GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct(string type)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the The Product Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			TestReport.StartStep("I set the Product Name as it a appears on the Package Label option to: " + type);
			MyStepsNewProduct.SetTheSectionOptionTo("Product Name as it a appears on the Package Label",
				"AAA WERCS Test " + type.Replace("/", " "));
			TestReport.StartStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
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
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains", "Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)", "None of the Above");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}


		[StepDefinition(@"I call Shared Step 60741 \(Select Primary Physical Property - Solid - With Ingredients\)")]
		public void GivenICallSharedStepSelectPrimaryPhysicalProperty_Solid_WithIngredients()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Solid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Cream");
			MyStepsNewProduct.SetTheSectionOptionTo("When mixed with an equal amount of water, will this produce a solution with a pH", "Yes");
			MyStepsNewProduct.SetTheSectionOptionTo("Select all ingredients included in this product", "Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains", "Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)", "None of the Above");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}


		[StepDefinition(@"I call Shared Step 60747 \(Select Primary Physical Property - Liquid - With Ingredients\)")]
		public void GivenICallSharedStepSelectPrimaryPhysicalProperty_Liquid_WithIngredients()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Characteristics");
			MyStepsNewProduct.SetTheSectionOptionTo("Primary Physical State", "Liquid");
			MyStepsNewProduct.CheckingFieldInputIsCorrect("Primary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			MyStepsNewProduct.SetTheSectionOptionTo("Specific Gravity", "20");
			MyStepsNewProduct.SetTheSectionOptionTo("pH", "7");
			MyStepsNewProduct.SectExatcDataNotKnown("Boiling Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Boiling Point (in Celsius)", "Not tested/Unknown");
			MyStepsNewProduct.SectExatcDataNotKnown("Flash Point (in Celsius)");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			MyStepsNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "<23C");
			NewProduct thisNewProduct = new NewProduct();
			if (thisNewProduct.OptionExists("Select the best Water Solubility description"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Decomposes");
			}
			
			MyStepsNewProduct.SetTheSectionOptionTo("Select all ingredients included in this product", "Dairy");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is manufactured in a facility that processes, or contains", "Dairy or products containing dairy or milk");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is verified and sold as", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following sweeteners", "None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Product contains the following artificial dye(s)", "None of the Above");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}


		[StepDefinition(@"I call Shared Step 60756 \(Additional Product Information with Country and every option\)")]
		public void GivenICallSharedStepAdditionalProductInformationWithCountryAndEveryOption()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");
			MyStepsNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57570 \(Enter Ingredients\) and add the following ingredients:")]
		public void GivenICallSharedStepEnterIngredients(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Ingredients Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			TestReport.StartStep("In the Ingredients page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			TestReport.StartStep("I should see the ingredients error message");
			MyStepsNewProduct.IngredientsErrorMessageShowing("should");
			//	MyStepsNewProduct.IngredientsErrorMessageShowingCorrectText(
			//		"ALERT! The ingredient table does not include a compressed gas(Bag-On-Valve) or a propellant.Please update your ingredients to include the propellant before proceeding.");
			TechTalk.SpecFlow.Table ingredientInformation = new TechTalk.SpecFlow.Table(new string[] {
				"ComponentName",
				"Percent",
				"PublicallyDisclosed",
				"TradeSecret",
				"PublicName"});
			foreach (var row in table.Rows)
			{
				ingredientInformation.AddRow(new string[] {
					row["ComponentName"],
					row["Percent"],
					row["PublicallyDisclosed"],
					row["TradeSecret"],
					row["PublicName"]});
			}
			TestReport.StartStep("I add the following ingredients:");
			MyStepsNewProduct.AddIngredients(ingredientInformation);
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
				"PublicName"});
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
				"PublicName"});
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

		[StepDefinition(@"I call Shared 57571 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_NotProp()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Regulatory Information 1 Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			TestReport.StartStep("I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S. Toxic Substances Control Act (TSCA) status", "Compliant");
			TestReport.StartStep("I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No");
			MyStepsNewProduct.SetTheSectionOptionTo("Product, including container and/or packaging, contains a chemical on California's Prop 65 list", "No");
			TestReport.StartStep("In the Regulatory Information 1 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

		[StepDefinition(@"I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path")]
		public void GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may including Active Ingredient)");
			MyStepsNewProduct.IConfirmLabelInformationOnRegulatoryInformationPageContains("OTC Drug Facts Label (may including Active Ingredient)");
			TestReport.StartStep("I set the Refer to your Product Label option to: None of the Above");
			MyStepsNewProduct.SetTheSectionOptionTo("Refer to your Product Label", "None of the Above");
			TestReport.StartStep("In the Regulatory Information 3 page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 3");
		}

		[StepDefinition(@"I call Shared 57506 \(Transportation Details 1 - Regulated for Transport\(No\) - Exemption\(Random\) - Continue - Happy Path\)")]
		public void GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "No, due to an exemption or exception");
			MyStepsNewProduct.SetTheSectionOptionTo("Please select DOT Exceptions if applicable", "173.120(a)(4)");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(@"I call Shared 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: (.*)")]
		public void GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath(string retailer)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("In the 'Select Retailers' window I select the retailer: " + retailer);
			MyStepsNewProduct.ThenISelectTheRetailer_InTheWindow(retailer);
			TestReport.StartStep("I should see the Retailer Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Retailer");
			TestReport.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Retailer");
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared 57960 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc, string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TechTalk.SpecFlow.Table upcTable = new TechTalk.SpecFlow.Table(new string[] {
				"Field",
				"Value"});
			upcTable.AddRow(new string[] {
				"UPCNumber",
				"saved as UPC"+upc});
			upcTable.AddRow(new string[] {
				"ContainerType",
				containerType});
			upcTable.AddRow(new string[] {
				"Size",
				size});
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
			MyStepsNewProduct.UploadPDFFileSectionAndType("Product Label", "Upload Full Product Label", docPath);
			TestReport.StartStep(@"in the New Product page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
		
		[StepDefinition(@"I call Shared 60567 \(Upload Product Label only\) for section: (.*)")]
		public void GivenICallSharedUploadProductLabelOnlySectionSpecific(string section)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I click the browse button for label: Product Label in section: " + section + @" and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf");
			MyStepsNewProduct.UploadPDFFileSectionAndType("Product Label", section, @"C:\Dependencies\WERCSmart\testdoc.pdf");
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


		[StepDefinition(@"I call Shared 57753 \(Create a New Registration via Register New Product \(expanded menu\)\)")]
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
		public void GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(Table table)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Data (Optional)");
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: " + table.Rows[0]["Personal Protection Equipment"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(table.Rows[0]["Personal Protection Equipment"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " + table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAutoignitionISelect(table.Rows[0]["Autoignition Temperature"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " + table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(table.Rows[0]["Minimum Ignition Energy"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " + table.Rows[0]["Viscosity"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(table.Rows[0]["Viscosity"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Appearance I select: " + table.Rows[0]["Appearance"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(table.Rows[0]["Appearance"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor I select: " + table.Rows[0]["Odor"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorISelect(table.Rows[0]["Odor"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " + table.Rows[0]["Odor Threshold"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorThresholdISelect(table.Rows[0]["Odor Threshold"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " + table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPartitionCoefficientISelect(table.Rows[0]["Partition Coefficient"]);
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
			TestReport.StartStep("I set the Flash Point (in Celsius) field to: Combustible II (>=38C and <=60C)");
			MyNewProduct.SetTheSectionOptionTo("Flash Point (in Celsius)", "Combustible II (>=38C and <=60C)");
			TestReport.StartStep("I set the Flash Point Testing Method Used option to: Closed cup method");
			MyNewProduct.SetTheSectionOptionTo("Flash Point Testing Method Used", "Closed cup method");
			TestReport.StartStep("I set the Select the best Water Solubility description field to: 100g/100ml");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "100g/100ml");
			TestReport.StartStep("I set the Secondary Physical State option to: Liquid");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid");
			TestReport.StartStep("In the Product Characteristics page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Product Characteristics");
		}

		[StepDefinition(@"I call Shared 57528 \(Product Characteristics - Aerosol Only - add data - Continue - Happy Path\)")]
		public void ICallSharedProductCharacteristics_AerosolOnly_AddData_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			// Primary Physical State is Aerosol which is the only option available
			TestReport.StartStep("I should only see the following options for Primary Physical State: Aerosol");
			TechTalk.SpecFlow.Table produtTable = new TechTalk.SpecFlow.Table(new string[] {
				"State"});
			produtTable.AddRow(new string[] {
				"Aerosol"});
			MyNewProduct.PrimaryPhysicalOptionsShowingCorrectly(produtTable);
			TestReport.StartStep("I set the Primary Physical State field to: Aerosol");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Aerosol");
			TestReport.StartStep("I set the Secondary Physical State field to: Liquid spray");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Liquid spray");
			TestReport.StartStep("I set the pH field to: 10.4");
			MyNewProduct.SetTheSectionOptionTo("pH", "10.4");
			TestReport.StartStep("If Section: Select the best Water Solubility description is visible, I select the first option");
			MyNewProduct.IfSectionIsVisibleISelectTheOption("Select the best Water Solubility description", "Insoluble");
			TestReport.StartStep("I select the first option for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
			MyNewProduct.SelectFirstOptionInSection("When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then");
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
			TestReport.StartStep("Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			TestReport.StartStep("I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)", "No");
			TestReport.StartStep("I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.", "No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep("I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)", "No");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
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
			@"I call Shared 62710 \(Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path\)")]
		public void GivenICallSharedConfirmVOCHeadingAndSelectNoToFirstQuestionOnly_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			TestReport.StartStep("I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.", "No");
		}

		[StepDefinition(@"I call Shared 60631 \(VOC - HVOC and MVOC - add values - Continue - Happy Path\)")]
		public void GivenICallSharedVOC__HVOCAndMVOC_AddValues_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 10");
			MyNewProduct.SetTheSectionOptionTo("HVOC (high volatile organic compound) content as weight percent of the total formulation", "10");
			TestReport.StartStep("I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 5.6");
			MyNewProduct.SetTheSectionOptionTo("MVOC (microbial volatile organic compound) content as weight percentage of the total formulation", "5.6");
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
			TestReport.StartStep("I set the Primary Physical State option to: Solid");
			MyNewProduct.SetTheSectionOptionTo("Primary Physical State", "Solid");
			TestReport.StartStep("I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No");
			MyNewProduct.SetTheSectionOptionTo("When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?", "No");
			TestReport.StartStep("I set the Select the best Water Solubility description option to: Dispersible");
			MyNewProduct.SetTheSectionOptionTo("Select the best Water Solubility description", "Dispersible");
			TestReport.StartStep("I set the Secondary Physical State option to: Solid Gel Consistency");
			MyNewProduct.SetTheSectionOptionTo("Secondary Physical State", "Solid Gel Consistency");
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 60310 \(Additional Product Information - Without Child question\)")]
		public void GivenICallSharedAdditionalProductInformation_WithoutChildQuestion()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("Select countries the product may be sold in should be showing the value: United States");
			MyNewProduct.CheckingFieldInputIsCorrect("Select countries the product may be sold in", "United States");
			TestReport.StartStep("I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)", "No");
			TestReport.StartStep("I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.", "No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep("I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)", "No");
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
			TestReport.StartStep("In the Volatile Organic Compound Summary page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Volatile Organic Compound Summary");
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
		public void GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity_Continue_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I set the Product is Regulated for Transport field to: Yes");
			MyNewProduct.SetTheSectionOptionTo("Product is Regulated for Transport", "Yes");
			TestReport.StartStep("I set the Select all modes of transport that you've classified the product for field to: DOT");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for", "DOT");
			TestReport.StartStep("I set the Select all modes of transport that you've classified the product for field to: Shipping with limited quantity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for", "Shipping with limited quantity");
			TestReport.StartStep("I set the Select all modes of transport that you've classified the product for field to: Shipping with consumer commodity");
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for", "Shipping with consumer commodity");
			TestReport.StartStep("In the Transportation Details 1 page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Transportation Details 1");
		}

		[StepDefinition(
			@"I call Shared Step 57728 \(U.S. Department of Transportation \(DOT\) Classification - Enter UN1950 \(Aerosol\) - Select data - Continue - Happy Path\)")]
		public void GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData_Continue()
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
			TestReport.StartStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("U. S. Department of Transportation (DOT) Classification");
		}

		[StepDefinition(@"I call Shared Step 49621 \(Volatile Organic Compounds \(VOC\) for OTC and CARB - No\)")]
		public void GivenICallSharedVolatileOrganicCompoundsVOCForOTCAndCARB_No()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page");
			MyNewProduct.GivenIShouldSeeXPage("Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)");
			TestReport.StartStep("I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.", "No");
		}

		[StepDefinition(@"I call Shared Step 32931 \(Liquid Core Product - select  No - Happy Path\)")]
		public void LiquidCoreProduct_SelectNo_HappyPath()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Liquid Core Product Page");
			MyNewProduct.GivenIShouldSeeXPage("Liquid Core Product");
			TestReport.StartStep("I set the Is there a free liquid in the Product's container that is 10ml or greater? field to: No");
			MyNewProduct.SetTheSectionOptionTo("Is there a free liquid in the Product's container that is 10ml or greater?", "No");
			TestReport.StartStep("In the U. S. Department of Transportation (DOT) Classification page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("Liquid Core Product");
		}

		[StepDefinition(@"I call Shared Step 57507 \(Transportation Details 1- Not Regulated - Continue - Happy Path\)")]
		public void ICallSharedTransportationDetails1_NotRegulated_Continue_HappyPath()
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
				if (MyNewProduct.GetAllOptionsForSection("Product is Regulated for Transport").Contains("Not Regulated"))
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
					Report.Failure("It was not possible to select the option: Not Regulated for the section: Product is Regulated for Transport");
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
		public void ICallSharedAdditionalProductInformation_PesticideAndChildShown_USOnly_NoToEverythingElse_Continue()
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Additional Product Information Page");
			MyNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			TestReport.StartStep("I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			MyNewProduct.SetTheSectionOptionTo("Which one best describes your product", "Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)");
			TestReport.StartStep("I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)", "No");
			TestReport.StartStep("I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)", "No");
			TestReport.StartStep("I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.", "No");
			TestReport.StartStep("I set the Product is a Retailer's Private Label or Brand field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			TestReport.StartStep("I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No");
			MyNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)", "No");
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
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPersonalProtectionEquipmentRecommendedISelect(table.Rows[0]["Personal Protection Equipment"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Autoignition I enter: " + table.Rows[0]["Autoignition Temperature"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAutoignitionISelect(table.Rows[0]["Autoignition Temperature"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: " + table.Rows[0]["Minimum Ignition Energy"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForMinimumIgnitionEnergyISelect(table.Rows[0]["Minimum Ignition Energy"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Viscosity I enter: " + table.Rows[0]["Viscosity"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForViscosityISelect(table.Rows[0]["Viscosity"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Appearance I select: " + table.Rows[0]["Appearance"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForAppearanceISelect(table.Rows[0]["Appearance"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor I select: " + table.Rows[0]["Odor"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorISelect(table.Rows[0]["Odor"]);
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Odor Threshold I select: " + table.Rows[0]["Odor Threshold"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForOdorThresholdISelect(table.Rows[0]["Odor Threshold"]);
			// if Product's Dispensing Method is required enter any option
			var actualSections = new NewProduct().GetDisplayedSections();
			if (actualSections.Contains("Product's Dispensing Method"))
			{
				TestReport.StartStep("In the Review and Submit tab of the New Product Page for Product's Dispensing Method I select: " + table.Rows[0]["Product's Dispensing Method"]);
				MyNewProduct.SetTheSectionOptionTo("Product's Dispensing Method", table.Rows[0]["Product's Dispensing Method"]);
			}
			TestReport.StartStep("In the Review and Submit tab of the New Product Page for Partition Coefficient I enter: " + table.Rows[0]["Partition Coefficient"]);
			MyNewProduct.GivenInTheReviewAndSubmitTabOfTheNewProductPageForPartitionCoefficientISelect(table.Rows[0]["Partition Coefficient"]);
			TestReport.StartStep("In the New Product page I click Continue");
			MyNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
	}
}

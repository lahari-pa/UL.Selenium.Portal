using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.Formula.Functions;
using SeleniumUtilities;
using TechTalk.SpecFlow;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding]
	public class Steps_Shared
	{
		// For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

		[StepDefinition(@"I call Shared Step 57408 \(Create a New Registration via Register New Product icon\)")]
		public void GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			new StepsHomepage().ClickItemInNavigationPanel("Register New Product");
			MyStepsNewProduct.GivenIShouldSeeXPage("New Product");
			MyStepsNewProduct.SetTheSectionOptionTo("Select the type of product to create", "Create a New Registration");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}

		[StepDefinition(@"I call Shared Step 57561 \(The Product - Enter Product Name and select Type of Product\)")]
		public void GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("The Product");
			MyStepsNewProduct.SetTheSectionOptionTo("Product Name as it a appears on the Package Label",
				"Cooking oil - Non-Aerosol");
			MyStepsNewProduct.GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField("Cooking oil - Non-Aerosol");
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

		[StepDefinition(@"I call Shared Step 57570 \(Enter Ingredients\)")]
		public void GivenICallSharedStepEnterIngredients()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Ingredients");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
			MyStepsNewProduct.IngredientsErrorMessageShowing("should");
			MyStepsNewProduct.IngredientsErrorMessageShowingCorrectText(
				"ALERT! The ingredient table does not include a compressed gas(Bag-On-Valve) or a propellant.Please update your ingredients to include the propellant before proceeding.");
			TechTalk.SpecFlow.Table ingredientInformation = new TechTalk.SpecFlow.Table(new string[] {
				"ComponentName",
				"Percent",
				"PublicallyDisclosed",
				"TradeSecret",
				"PublicName"});
			ingredientInformation.AddRow(new string[] {
				"Butane",
				"100",
				"false",
				"false",
				""});
			MyStepsNewProduct.AddIngredients(ingredientInformation);
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Ingredients");
		}

		[Given(@"I call Shared 57571 \(Enter Regulatory Information - Not Prop 65\)")]
		public void GivenICallSharedEnterRegulatoryInformation_NotProp()
		{
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Regulatory Information 1");
			MyStepsNewProduct.SetTheSectionOptionTo("U.S.Toxic Substances Control Act (TSCA) status", "Compliant");
			MyStepsNewProduct.SetTheSectionOptionTo("Product, including container and/or packaging, contains a chemical on California's Prop 65 list", "No");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Regulatory Information 1");
		}

	}
}

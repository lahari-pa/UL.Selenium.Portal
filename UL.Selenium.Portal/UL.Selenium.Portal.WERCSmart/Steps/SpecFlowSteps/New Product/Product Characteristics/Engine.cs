using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Engine")]
	internal class Engine
	{
		[RegexStepDefinition(@"I enter the text of EPA Certificate of Conformity and EPA Label showing Emission Control Information field to: (.*)")]
		public void GivenEnterEPACertificateOfConformityAndEPALabelShowingEmissionControlInformationValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate of Conformity and EPA Label showing Emission Control Information field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate of Conformity and EPA Label showing Emission Control Information", value);
		}

		[RegexStepDefinition(@"I enter the text of EPA Certificate Number field to: (.*)")]
		public void GivenEnterEPACertificateNumberValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate Number field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate Number", value);
		}

		[RegexStepDefinition(@"I enter the text of Engine Date of Manufacture field to: (.*)")]
		public void GivenEnterEngineDateOfManufactureValue(string value)
		{
			Report.Info($"I set the text of Engine Date of Manufacture field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Date of Manufacture", value);
		}
		[RegexStepDefinition(@"I enter the text of Engine Manufacturer field to: (.*)")]
		public void GivenEnterEngineManufacturerValue(string value)
		{
			Report.Info($"I set the text of Engine Manufacturer field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Manufacturer", value);
		}
		[RegexStepDefinition(@"I enter the text of EPA Engine Family field to: (.*)")]
		public void GivenEnterEPAEngineFamilyValue(string value)
		{
			Report.Info($"I set the text of EPA Engine Family field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Engine Family", value);
		}
		[RegexStepDefinition(@"I enter the text of Model Year field to: (.*)")]
		public void GivenEnterModelYearValue(string value)
		{
			Report.Info($"I set the text of Model Year field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Model Year", value);
		}
		[RegexStepDefinition(@"I enter the text of Engine Model field to: (.*)")]
		public void GivenEnterEngineModelValue(string value)
		{
			Report.Info($"I set the text of Engine Model field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Model", value);
		}
		[RegexStepDefinition(@"I enter the text of Engine Make field to: (.*)")]
		public void GivenEnterEngineMakeValue(string value)
		{
			Report.Info($"I set the text of Engine Make field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Make", value);
		}
		[RegexStepDefinition(@"I enter the text of EPA Certificate Expiration Date field to: (.*)")]
		public void GivenEnterEPACertificateExpirationDateValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate Expiration Date field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate Expiration Date", value);
		}
		[RegexStepDefinition(@"I enter the text of EPA Certificate Effective Date field to: (.*)")]
		public void GivenEnterEPACertificateEffectiveDateValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate Effective Date field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate Effective Date", value);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.NewProduct;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Engine")]
	internal class Engine
	{
		[StepDefinition(@"I enter the text of EPA Certificate of Conformity and EPA Label showing Emission Control Information field to: (.*)")]
		public void GivenEnterEPACertificateOfConformityAndEPALabelShowingEmissionControlInformationValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate of Conformity and EPA Label showing Emission Control Information field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate of Conformity and EPA Label showing Emission Control Information", value);
		}

		[StepDefinition(@"I enter the text of EPA Certificate Number field to: (.*)")]
		public void GivenEnterEPACertificateNumberValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate Number field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate Number", value);
		}

		[StepDefinition(@"I enter the text of Engine Date of Manufacture field to: (.*)")]
		public void GivenEnterEngineDateOfManufactureValue(string value)
		{
			Report.Info($"I set the text of Engine Date of Manufacture field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Date of Manufacture", value);
		}
		[StepDefinition(@"I enter the text of Engine Manufacturer field to: (.*)")]
		public void GivenEnterEngineManufacturerValue(string value)
		{
			Report.Info($"I set the text of Engine Manufacturer field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Manufacturer", value);
		}
		[StepDefinition(@"I enter the text of EPA Engine Family field to: (.*)")]
		public void GivenEnterEPAEngineFamilyValue(string value)
		{
			Report.Info($"I set the text of EPA Engine Family field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Engine Family", value);
		}
		[StepDefinition(@"I enter the text of Model Year field to: (.*)")]
		public void GivenEnterModelYearValue(string value)
		{
			Report.Info($"I set the text of Model Year field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Model Year", value);
		}
		[StepDefinition(@"I enter the text of Engine Model field to: (.*)")]
		public void GivenEnterEngineModelValue(string value)
		{
			Report.Info($"I set the text of Engine Model field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Model", value);
		}
		[StepDefinition(@"I enter the text of Engine Make field to: (.*)")]
		public void GivenEnterEngineMakeValue(string value)
		{
			Report.Info($"I set the text of Engine Make field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Engine Make", value);
		}
		[StepDefinition(@"I enter the text of EPA Certificate Expiration Date field to: (.*)")]
		public void GivenEnterEPACertificateExpirationDateValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate Expiration Date field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate Expiration Date", value);
		}
		[StepDefinition(@"I enter the text of EPA Certificate Effective Date field to: (.*)")]
		public void GivenEnterEPACertificateEffectiveDateValue(string value)
		{
			Report.Info($"I set the text of EPA Certificate Effective Date field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("EPA Certificate Effective Date", value);
		}
	}
}

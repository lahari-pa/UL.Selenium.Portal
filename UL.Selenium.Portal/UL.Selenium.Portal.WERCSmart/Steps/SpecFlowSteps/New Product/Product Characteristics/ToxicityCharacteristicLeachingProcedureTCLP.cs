using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP")]
	class WERCSmart_Distributor_NewProducts_ProductType_ToxicityCharacteristicLeachingProcedureTCLP
	{
		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: (Yes|No)")]
		public void SelectProductTLCPTestingReportAvailable(string option)
		{
			string section = "Product has had TCLP testing; Report is available";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Lead': to: (I don't know|No|Yes|Yes, below RCRA limit \(5.0 ppm\))")]
		public void SelectLead(string option)
		{
			string section = "Lead";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Mercury': to: (I don't know|No|Yes|Yes, below RCRA limit \(0.2 ppm\))")]
		public void SelectMercury(string option)
		{
			string section = "Mercury";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Silver': to: (I don't know|No|Yes|Yes, below RCRA limit \(5.0 ppm\))")]
		public void SelectSilver(string option)
		{
			string section = "Silver";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Cadmium': to: (I don't know|No|Yes|Yes, below RCRA limit \(1.0 ppm\))")]
		public void SelectCadmium(string option)
		{
			string section = "Cadmium";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Chromium': to: (I don't know|No|Yes|Yes, below RCRA limit \(5.0 ppm\))")]
		public void SelectChromium(string option)
		{
			string section = "Chromium";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Barium': to: (I don't know|No|Yes|Yes, below RCRA limit \(100.0 ppm\))")]
		public void SelectBarium(string option)
		{
			string section = "Barium";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Arsenic': to: (I don't know|No|Yes|Yes, below RCRA limit \(5.0 ppm\))")]
		public void SelectArsenic(string option)
		{
			string section = "Arsenic";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Selenium': to: (I don't know|No|Yes|Yes, below RCRA limit \(1.0 ppm\))")]
		public void SelectSelenium(string option)
		{
			string section = "Selenium";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Toxicity Characteristic Leaching Procedure \(TCLP\) Section, set the radio option in section: 'Copper': to: (No|Yes)")]
		public void SelectCopper(string option)
		{
			string section = "Copper";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1")]
	class WERCSmart_Distributor_NewProducts_TransportationDetails1
	{
		[StepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: (Yes|No, due to an exemption or exception|Not Regulated)")]
		public void SetProductIsRegulatedForTransport(string option)
		{
			string section = "Product is Regulated for Transport";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: (DOT|IMDG|IATA|TDG)")]
		public void SetSelectAllModesOfTransport(string option)
		{
			string section = "Select all modes of transport that you've classified the product for";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: (Shipping with limited quantity|Shipping fully regulated|Shipping with consumer commodity)")]
		public void SetSelectAllModesOfTransport2(string option)
		{
			string section = "Select all modes of transport that you've classified the product for";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Provide Special Permit numbers \(if applicable\)': to: (.*)")]
		public void SetProvideSpecialPermitNumbers(string option)
		{
			string section = "Provide Special Permit numbers (if applicable)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable\?': to: (.*)")]
		public void SetSelectDOTExceptions(string option)
		{
			string section = "Please select DOT Exceptions if applicable?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Other DOT Exception': to: (.*)")]
		public void SetOtherDOTExceptions(string option)
		{
			string section = "Other DOT Exception";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}

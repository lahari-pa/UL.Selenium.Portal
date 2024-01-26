using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RestrictUse")]
	internal class RestrictUse
	{

		[StepDefinition(@"I enter the text of formula registration is an Exclusive 3rd Party Formula field to: (.*)")]
		public void GivenEnterFormulaRegistrationIsAnExclusive3rdPartyFormulaValue(string value)
		{
			Report.Info($"I set the text of formula registration is an Exclusive 3rd Party Formula field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("This formula registration is an Exclusive 3rd Party Formula and can only be used by this account. This formula cannot be used by Divisions of the same account- nor is this available to any other account holder. Once this formula is submitted- this cannot be changed or adjusted. Please be aware of this restriction before finalizing your submission.", value);
		}

		[StepDefinition(@"I enter the text of Access Code field to: (.*)")]
		public void GivenEnterAccessCodeValue(string value)
		{
			Report.Info($"I set the text of Access Code field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Access Code", value);
		}

		[StepDefinition(@"I enter the text of restrict searchable access field to: (.*)")]
		public void GivenEnterRestrictSearchableAccessValue(string value)
		{
			Report.Info($"I set the text of restrict searchable access field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Do you want to restrict searchable access to your registered formula?", value);
		}

	}
}

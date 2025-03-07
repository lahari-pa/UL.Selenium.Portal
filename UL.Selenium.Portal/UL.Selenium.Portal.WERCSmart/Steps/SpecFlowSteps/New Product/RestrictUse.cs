using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RestrictUse")]
	internal class RestrictUse
	{

		[RegexStepDefinition(@"In the Restrict Use Section, I enter the text of formula registration is an Exclusive 3rd Party Formula field to: (.*)")]
		public void GivenEnterFormulaRegistrationIsAnExclusive3rdPartyFormulaValue(string value)
		{
			Report.Info($"I set the text of formula registration is an Exclusive 3rd Party Formula field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("This formula registration is an Exclusive 3rd Party Formula and can only be used by this account. This formula cannot be used by Divisions of the same account- nor is this available to any other account holder. Once this formula is submitted- this cannot be changed or adjusted. Please be aware of this restriction before finalizing your submission.", value);
		}

		[RegexStepDefinition(@"In the Restrict Use Section, I enter the text of Access Code field to: (.*)")]
		public void GivenEnterAccessCodeValue(string value)
		{
			Report.Info($"I set the text of Access Code field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Access Code", value);
		}

		[RegexStepDefinition(@"In the Restrict Use Section, I enter the text of restrict searchable access field to: (.*)")]
		public void GivenEnterRestrictSearchableAccessValue(string value)
		{
			Report.Info($"I set the text of restrict searchable access field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Do you want to restrict searchable access to your registered formula?", value);
		}

		[RegexStepDefinition(@"In the Restrict Use Section, set the option in section: 'Do you want to restrict searchable access to your registered formula\?': to: (Do Not Restrict|Restrict|Exclusive Use)")]
		public void SetOptionForRestrictSearchableAccess(string option)
		{
			string section = "Do you want to restrict searchable access to your registered formula?";
			if (option == "Restrict")
			{
				option = " - Customers should contact my organization for an access code";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			if (option == "Do Not Restrict")
			{
				option = " – Formula is searchable in WERCSmart and does not require an access code";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			if (option == "Exclusive Use")
			{
				option = " – This formula is established for use in my own account only and is not to be used by any other account";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
		}

	}
}

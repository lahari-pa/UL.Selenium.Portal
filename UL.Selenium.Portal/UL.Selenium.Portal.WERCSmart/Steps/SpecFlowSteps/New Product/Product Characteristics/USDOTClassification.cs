using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDOTClassification")]
	class WERCSmart_Distributor_NewProducts_USDOTClassification
	{
		[StepDefinition(@"In the U. S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'What type of product is this\?': to: (Equipment|Engine|Vehicle)")]
		public void SetWhatTypeOfProduct(string option)
		{
			string section = "What type of product is this?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[StepDefinition(@"In the U. S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'What powers the product\?': to: (Internal combustion engine and battery|Fuel cell and battery|Battery only)")]
		public void SetWhatPowersOfProduct(string option)
		{
			string section = "What powers the product?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the U. S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'How is the item transported for DOT\?': to: (.*)")]
		public void SetWhatIsTheItemTransportedForDOT(string option)
		{
			string section = "How is the item transported for DOT?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
	}
}

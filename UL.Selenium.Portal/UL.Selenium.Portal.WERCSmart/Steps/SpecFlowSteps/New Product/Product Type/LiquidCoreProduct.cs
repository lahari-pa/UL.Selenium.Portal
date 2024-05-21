using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope (Tag = "LiquidCoreProduct")]
	class LiquidCoreProduct
	{
		[StepDefinition(@"In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater\?' to: (Yes|No)")]
		public void LiquidCoreProductSelectYesOrNo(string option)
		{
			string section = "Is there a free liquid in the Product's container that is 10ml or greater?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}

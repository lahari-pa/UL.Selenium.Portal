using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "RegulatoryDocumentsToProvide")]
	class RegulatoryDocumentsToProvide
	{
		[StepDefinition(@"In the Regulatory Documents to Provide Section, set the option in section: 'OSHA-compliant Safety Data Sheet, English' to: (Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it. OSHA Hazard Communication|Request to author)")]
		public void OSHACompliantSafteyDataSheetEnglish(string option)
		{
			string section = "OSHA-compliant Safety Data Sheet, English";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}

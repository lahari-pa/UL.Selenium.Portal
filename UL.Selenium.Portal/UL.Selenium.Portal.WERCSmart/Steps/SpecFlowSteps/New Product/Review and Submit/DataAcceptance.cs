using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance")]
	class WERCSmart_Distributor_NewProducts_ReviewAndSubmit_DataAcceptance
	{
		[StepDefinition(@"In the Data Acceptance Section, (check|uncheck) 'Agreed' checkbox")]
		public void CheckUncheckAgreedCheckbox(string checked_unchecked)
		{
			string checkbox = "Agreed";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(checked_unchecked, checkbox);
		}
		[StepDefinition(@"In the Data Acceptance Section, click 'Summary' button")]
		public void ClickSummaryButton()
		{
			string button = "Summary";
			new Steps_Prototype().ClickButton(button);
		}
	}
}

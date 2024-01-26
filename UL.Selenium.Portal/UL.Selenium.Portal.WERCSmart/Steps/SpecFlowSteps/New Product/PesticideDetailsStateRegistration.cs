using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsStateRegistration")]
	class WERCSmart_Distributor_NewProducts_ProductCharacteristics_PesticideDetailsStateRegistration
	{
		[StepDefinition(@"In the Pesticide Details - State Registration Details Section, click 'Update WERCSmart data with EPA data through Kelly Solutions' link")]
		public void ClickLinkUpdateWithKellySolutions()
		{
			string linkText = "Update WERCSmart data with EPA data through Kelly Solutions";
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[StepDefinition(@"In the Pesticide Details - State Registration Details section, set the following date: (.*) for the state: (.*)")]
		public void EnterDateForState(string date, string state)
		{
		new Steps_Prototype().GivenISetTheFollowingDataErtForTheFollowingStateMA(date, state);
		}

		[StepDefinition(@"In the Pesticide Details - State Registration Details section, select the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) for the state: (.*)")]
		public void SelectStatusForState(string status, string state)
		{
		new Steps_Prototype().GivenISetTheFollowingStatus(status, state);
		}
		[StepDefinition(@"In the Pesticide Details - State Registration Details section, verify State Expiration Date is prefilled for the state: (.*)")]
		public void VerifyStateExpirationDate(string state)
		{
			new Steps_Prototype().VerifyDateIsPrefilled(state);
		}

		[StepDefinition(@"In the Pesticide Details - State Registration Details section, verify the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) is selected for the state: (.*)")]
		public void VerifySelectedStatusForState(string status, string state)
		{
			new Steps_Prototype().StatusIsSelectedForTheState(status, state);
		}

		[StepDefinition(@"In Pesticide Details - State Registration Details page I verify row color highlighting indicates item is expiring in less then (31|90) for state: (.*)")]
		public void VerifyHighlightedColor(string days, string state)
		{
			new Steps_Prototype().VerifyRowColor(days, state);
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details section I verify check mark in Expiration Imported column (should|should not) be displayed for state: (.*)")]
		public void VerifyCheckMarkinExpirationImported(string condition, string state)
		{
			new Steps_Prototype().VerifyCheckMerk(condition, state);
		}
		[StepDefinition(@"In the Pesticide Details - State Registration Details section, select the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) for all states with no status preselected")]
		public void SelectStatusForAllStates(string status)
		{
			new Steps_Prototype().GivenISetTheFollowingStatusForAllStates(status);
		}
		[StepDefinition(@"In the Pesticide Details - State Registration Details section, click 'Select All' for the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) for all states")]
		public void SelecAllStatusForAllStates(string status)
		{
			new Steps_Prototype().GivenIClickSelectAllForAllStates(status);
		}
	}
}

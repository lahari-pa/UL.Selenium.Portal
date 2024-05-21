using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

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
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).EnterDate(date), $"Failed to enter a State Expiration Date {date} for state {state}", $"Successfully entered a State Expiration Date {date} for state {state}");
		}

		[StepDefinition(@"In the Pesticide Details - State Registration Details section, select the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) for the state: (.*)")]
		public void SelectStatusForState(string status, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).EnterStatus(status), $"Failed to select status {status} for state {state}", $"Successfully selected status {status} for state {state}");
		}
		[StepDefinition(@"In the Pesticide Details - State Registration Details section, verify State Expiration Date is prefilled for the state: (.*)")]
		public void VerifyStateExpirationDate(string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).DateIsPrefilled(state), $"Failed to confirm State Expiration Date for state {state} is prefilled", $"Successfully confirmed State Expiration Date for state {state} is prefilled");
		}

		[StepDefinition(@"In the Pesticide Details - State Registration Details section, verify the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) is selected for the state: (.*)")]
		public void VerifySelectedStatusForState(string status, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).SelectedStatusForState(status), $"Failed to confirm status {status} is selected for state {state}", $"Successfully confirmed status {status} is selected for state {state}");
		}

		[StepDefinition(@"In Pesticide Details - State Registration Details page I verify row color highlighting indicates item is expiring in less then (31|90) for state: (.*)")]
		public void VerifyHighlightedColor(string days, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).ColorHighlighting(days), $"Failed to confirm row color highlighting indicates item is expiring in less then {days} for state {state}", $"Successfully confirmed row color highlighting indicates item is expiring in less then {days} for state {state}");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details section I verify check mark in Expiration Imported column (is|is not) displayed for state: (.*)")]
		public void VerifyCheckMarkinExpirationImported(string is_isnot, string state)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).VerifyExpirationImportedMark() == expected, $"Failure, check mark in Expiration Imported column {(expected ? "is not" : "is")} displayed for state {state}.", $"Success, check mark in Expiration Imported column {is_isnot} displayed for state {state}.");
		}
		[StepDefinition(@"In the Pesticide Details - State Registration Details section, select the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) for all states with no status preselected")]
		public void SelectStatusForAllStates(string status)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationTable().SelectOneStatusForAllStatesWithNoSelectedStatus(status), $"Failed to select status {status} for states with no status selected", $"Successfully selected status {status} for all states with no status selected");
		}
		[StepDefinition(@"In the Pesticide Details - State Registration Details section, click 'Select All' for the status: (Registered|Restricted, Not Registered|No State Registration Required|Pending State Registration) for all states")]
		public void SelecAllStatusForAllStates(string status)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationTable().ClickSelectAllForStatus(status), $"Failed to click 'Select All' for {status}", $"Successfully clicked 'Select All' for status {status}");
		}
	}
}

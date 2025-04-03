using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "ForwardProductRegistrationPage")]
	internal class Steps_ForwardProductRegistrationPage
	{
		#region Prototype Steps

		#endregion

		#region Wizard Tabs List Steps
		[RegexStepDefinition(@"On the Forward Product Registration page, confirm wizard tabs list (does|does not) exists")]
		public void ForwardProductRegistrationConfirmWizardTabsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list {does_doesnot} exist.", $"Success, confirmed wizard tabs list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, confirm (Select Products|Select Retailers|Select UPCs|Product Results|Review & Submit) wizard tab (does_does not) exist")]
		public void ForwardProductRegistrationConfirmWizardTabExists(string tabLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list does exist.", $"Success, confirmed wizard tabs list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.WizardTabExists(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab {does_doesnot} exist.", $"Success, confirmed '{tabLabel}' wizard tab {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, confirm (Select Products|Select Retailers|Select UPCs|Product Results|Review & Submit) wizard tab (is|is not) active")]
		public void ForwardProductRegistrationConfirmWizardTabIsIsNotActive(string tabLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list does exist.", $"Success, confirmed wizard tabs list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.WizardTabExists(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab does exist.", $"Success, confirmed '{tabLabel}' wizard tab does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.WizardTabActive(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab {is_isnot} active.", $"Success, confirmed '{tabLabel}' wizard tab {is_isnot} active.");
				}
			}
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, click (Select Products|Select Retailers|Select UPCs|Product Results|Review & Submit) wizard tab")]
		public void ForwardProductRegistrationClickWizardTab(string tabLabel)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list does exist.", $"Success, confirmed wizard tabs list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.WizardTabExists(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab does exist.", $"Success, confirmed '{tabLabel}' wizard tab does exist."))
				{
					Report.IsTrue(forwardProductRegistration.WizardTabClick(tabLabel), $"Failure, failed to click '{tabLabel}' wizard tab.", $"Success, clicked '{tabLabel}' wizard tab.");
				}
			}
		}
		#endregion

		#region Continue Button Steps
		[RegexStepDefinition(@"On the Forward Product Registration Page, confirm the 'Continue' Button (does|does not) exist")]
		public void ForwardProductRegistrationConfirmContinueButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			string buttonLabel = "Continue";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button {does_doesnot} exist.", $"Success, confirmed '{buttonLabel}' button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, click the 'Continue' Button")]
		public void ForwardProductRegistrationClickContinueButton()
		{
			string buttonLabel = "Continue";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button does exist.", $"Success, confirmed '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(forwardProductRegistration.LabeledButtonClick(buttonLabel), $"Failure, failed to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
			}
		}
		#endregion

		#region Select Products Steps
		#region Search by WPS ID or Product Name Steps
		[RegexStepDefinition(@"In the Select Products Tab, confirm 'Search by WPSID or Product Name' Text Input (does|does not) exist")]
		public void SelectProductsTabConfirmTextInputExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			string sectionLabel = "Search by WPSID or Product Name";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SectionTextInputExists(sectionLabel), $"Failure, failed to confirm '{sectionLabel}' text input {does_doesnot} exist.", $"Success, confirmed '{sectionLabel}' text input {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Products Tab, click 'Search by WPSID or Product Name' Text Input")]
		public void SelectProductsTabClickTextInput()
		{
			string sectionLabel = "Search by WPSID or Product Name";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SectionTextInputExists(sectionLabel), $"Failure, failed to confirm '{sectionLabel}' text input does exist.", $"Success, confirmed '{sectionLabel}' text input does exist."))
			{
				Report.IsTrue(forwardProductRegistration.SectionTextInputClick(sectionLabel), $"Failure, failed to click '{sectionLabel}' text input.", $"Success, clicked '{sectionLabel}' text input.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, in 'Search by WPSID or Product Name' Text Input enter text: (.*)")]
		public void SelectProductsTabClickTextInput(string inputText)
		{
			string sectionLabel = "Search by WPSID or Product Name";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SectionTextInputExists(sectionLabel), $"Failure, failed to confirm '{sectionLabel}' text input does exist.", $"Success, confirmed '{sectionLabel}' text input does exist."))
			{
				Report.IsTrue(forwardProductRegistration.SectionTextInputEnterText(sectionLabel, inputText), $"Failure, in '{sectionLabel}' text input failed to enter text: '{inputText}'.", $"Success, in '{sectionLabel}' text input entered text: '{inputText}'.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result list (does|does not) exist")]
		public void SelectProductsTabConfirmProductUPCSearchResultListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list {does_doesnot} exist.", $"Success, confirmed product upc search result list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' Product Name (does|does not) exist")]
		public void SelectProductsTabConfirmProductUPCSearchResultProductNameExists(string productName, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if(Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByProductNameExists(productName), $"Failure, failed to confirm product upc search result with '{productName}' product name {does_doesnot} exist.", $"Success, confirmed product upc search result with '{productName}' product name {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, click product upc search result with '(.*)' Product Name")]
		public void SelectProductsTabClickProductUPCSearchResultProductName(string productName)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if(Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByProductNameExists(productName), $"Failure, failed to confirm product upc search result with '{productName}' product name does exist.", $"Success, confirmed product upc search result with '{productName}' product name does exist."))
				{
					Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByProductName(productName).Click(), $"Failure, failed to click product upc search result with '{productName}' product name.", $"Success, clicked product upc search result with '{productName}' product name.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' Product Name checkbox (is|is not) checked")]
		public void SelectProductsTabConfirmProductUPCSearchResultProductNameChecked(string productName, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByProductNameExists(productName), $"Failure, failed to confirm product upc search result with '{productName}' product name does exist.", $"Success, confirmed product upc search result with '{productName}' product name does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByProductName(productName).CheckboxChecked(), $"Failure, failed to confirm product upc search result with '{productName}' product name checkbox {is_isnot} checked.", $"Success, confirmed product upc search result with '{productName}' product name checkbox {is_isnot} checked.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' WPSID (does|does not) exist")]
		public void SelectProductsTabConfirmProductUPCSearchResultWPSIDExists(string wpsid, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByWPSIDExists(wpsid), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID {does_doesnot} exist.", $"Success, confirmed product upc search result with '{wpsid}' WPSID {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, click product upc search result with '(.*)' WPSID")]
		public void SelectProductsTabClickProductUPCSearchResultWPSID(string wpsid)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByWPSIDExists(wpsid), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID does exist.", $"Success, confirmed product upc search result with '{wpsid}' WPSID does exist."))
				{
					Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByWPSID(wpsid).Click(), $"Failure, failed to click product upc search result with '{wpsid}' WPSID.", $"Success, clicked product upc search result with '{wpsid}' WPSID.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' WPSID checkbox (is|is not) checked")]
		public void SelectProductsTabConfirmProductUPCSearchResultWPSIDChecked(string wpsid, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByWPSIDExists(wpsid), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID does exist.", $"Success, confirmed product upc search result with '{wpsid}' WPSID does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByWPSID(wpsid).CheckboxChecked(), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID checkbox {is_isnot} checked.", $"Success, confirmed product upc search result with '{wpsid}' WPSID checkbox {is_isnot} checked.");
				}
			}
		}
		#endregion

		#region Selected Products List Steps
		[RegexStepDefinition(@"In the Select Products Tab, confirm Selected Products list (does|does not) exist")]
		public void SelectProductsTabConfirmSelectedProductsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list {does_doesnot} exist.", $"Success, confirmed selected products list {does_doesnot} exist.");
		}
		#endregion
		#endregion
	}
}

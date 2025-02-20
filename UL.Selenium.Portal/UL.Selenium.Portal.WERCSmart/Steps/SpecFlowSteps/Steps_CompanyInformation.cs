using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:MyAccount:CompanyInformation")]

	class Steps_CompanyInformation
	{
		[RegexStepDefinition(@"In the Company Information section, click the 'Edit' link for the (Billing Address|Shipping Address|Canada Supplier Address|Stewardship Numbers) section")]
		public void ClickTheEditLink(string section)
		{
			string linkText = "Edit";
			if (Report.IsTrue(new CompanyInformation().LinkElementExists(section, linkText), $"Failed to find the 'Edit' link for the '{section}' section", $"Successfully found the 'Edit' link for the '{section}' section"))
			{
				Report.IsTrue(new CompanyInformation().ClickLinkElement(section, linkText), $"Failed to click the 'Edit' link for the '{section}' section", $"Successfully clicked the 'Edit' link for the '{section}' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the 'Edit' link for the 'Company' section")]
		public void ClickTheCompanyEditLink()
		{
			string linkText = "Edit";
			if (Report.IsTrue(new CompanyInformation().CompanyEditLinkExists(linkText), $"Failed to find the 'Edit' link for the 'Company' section", $"Successfully found the 'Edit' link for the 'Company' section"))
			{
				Report.IsTrue(new CompanyInformation().CompanyClickEditLink(linkText), $"Failed to click the 'Edit' link for the 'Company' section", $"Successfully clicked the 'Edit' link for the 'Company' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the (Save|Cancel) button for the (Billing Address|Shipping Address|Canada Supplier Address|Stewardship Numbers) section")]
		public void ClickTheSaveCancelButton(string button, string section)
		{
			if (Report.IsTrue(new CompanyInformation().LinkElementExists(section, button), $"Failed to find the '{button}' button for the '{section}' section", $"Successfully found the '{button}' button for the '{section}' section"))
			{
				Report.IsTrue(new CompanyInformation().ClickLinkElement(section, button), $"Failed to click the '{button}' button for the '{section}' section", $"Successfully clicked the '{button}' button for the '{section}' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the (Save|Cancel) button for the 'Company' section")]
		public void ClickTheCompanySaveCancelButton(string button)
		{
			if (Report.IsTrue(new CompanyInformation().CompanyEditLinkExists(button), $"Failed to find the '{button}' button for the 'Company' section", $"Successfully found the '{button}' button for the 'Company' section"))
			{
				Report.IsTrue(new CompanyInformation().CompanyClickEditLink(button), $"Failed to click the '{button}' button for the 'Company' section", $"Successfully clicked the '{button}' button for the 'Company' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, the 'Are you sure you wish to cancel\?' modal window (should|should not) be displayed with text 'If you cancel, any changes will be lost. Continue\?'")]
		public void TheUserDetailsModalIsDisplayed(string condition)
		{
			string modalTitle = "×\r\nAre you sure you wish to cancel?";
			string text = "If you cancel, any changes will be lost. Continue?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, modalTitle, text);
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Are you sure you wish to cancel\?' modal click the button (Yes|No)")]
		public void TheInUserDetailsModalClickButton(string button)
		{
			string modalTitle = "Are you sure you wish to cancel?";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(modalTitle, button);
		}
		[RegexStepDefinition(@"In the Company Information section, verify the (Company Name|Contact Email|Contact|Supplier Type|Country|Address|City|State|Zip|Country Code|Company Phone) is (.*)")]
		public void VerifyCompanyInformation(string field, string value)
		{
			string section = "Company Name";
			if (Report.IsTrue(new CompanyInformationSection(section).FindCompanyData(field, value), $"Failed to find the '{field}' is '{value}'", $"Successfully found the 'the '{field}' is '{value}'"))
			{
				Report.IsTrue(new CompanyInformationSection(section).VerifyCompanyData(field, value), $"Failed to confirm the '{field}' is displayed with value: '{value}'", $"Successfully confirmed the '{field}' is displayed with value: '{value}'");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, in the '(Billing Address|Shipping Address|Canada Supplier Address)' verify the (Country|Address|City|State|Zip|Country Code|Company Phone|Province|Postal Code) is (.*)")]
		public void VerifyCompanyInformationBillingAddress(string section, string field, string value)
		{
			if (Report.IsTrue(new CompanyInformationSection(section).FindCompanyData(field, value), $"Failed to find the '{field}' is '{value}'", $"Successfully found the 'the '{field}' is '{value}'"))
			{
				Report.IsTrue(new CompanyInformationSection(section).VerifyCompanyData(field, value), $"Failed to confirm the '{field}' is displayed with value: '{value}'", $"Successfully confirmed the '{field}' is displayed with value: '{value}'");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Company' section for the (Company Name|Address|Address 2|Address 3|City|Zip|Country Code|Company Phone|State) enter text (.*)")]
		public void EnterTextForCompanyAddress(string field, string value)
		{
			string section = "Company Name";
			if (Report.IsTrue(new CompanyInformationSection(section).AddressInputFieldExists(field), $"Failed to find the '{field}' input field", $"Successfully found the 'the '{field}' input field."))
			{
				Report.IsTrue(new CompanyInformationSection(section).AddressInputFieldEnterText(field, value), $"Failed to enter '{value}' in the '{field}' input field.", $"Successfully entered '{value}' in the '{field}' input field.");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, in the '(Billing Address|Shipping Address|Canada Supplier Address)' for the (Address|Address 2|City|Zip|Country Code|Company Phone|Postal Code|State) enter text (.*)")]
		public void EnterTextForCompanyInformationAddress(string section, string field, string value)
		{
			if (Report.IsTrue(new CompanyInformationSection(section).AddressInputFieldExists(field), $"Failed to find the '{field}' input field", $"Successfully found the 'the '{field}' input field."))
			{
				Report.IsTrue(new CompanyInformationSection(section).AddressInputFieldEnterText(field, value), $"Failed to enter '{value}' in the '{field}' input field.", $"Successfully entered '{value}' in the '{field}' input field.");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Company' section for the (Country|Supplier Type|State) select option (.*)")]
		public void SelectStateOptionForCompanyAddress(string field, string value)
		{
			string section = "Company Name";
			if (Report.IsTrue(new CompanyInformationSection(section).AddressSelectFieldExists(field), $"Failed to find the '{field}' select field", $"Successfully found the 'the '{field}' select field."))
			{
				Report.IsTrue(new CompanyInformationSection(section).AddressSelectFieldSelectOption(field, value), $"Failed to select '{value}' in the '{field}' field.", $"Successfully selected '{value}' in the '{field}' field.");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, in the '(Billing Address|Shipping Address|Canada Supplier Address)' for the (Country|State|Province) select option (.*)")]
		public void SelectOptionForCompanyInformationAddress(string section, string field, string value)
		{
			if (Report.IsTrue(new CompanyInformationSection(section).AddressSelectFieldExists(field), $"Failed to find the '{field}' select field", $"Successfully found the 'the '{field}' select field."))
			{
				Report.IsTrue(new CompanyInformationSection(section).AddressSelectFieldSelectOption(field, value), $"Failed to select '{value}' in the '{field}' field.", $"Successfully selected '{value}' in the '{field}' field.");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, verify the '(User|Division) Accounts' number is (.*)")]
		public void VerifyTheUserOrDivisionAccountsNumber(string accountType, string expectedNumber)
		{
			if (Report.IsTrue(new CompanyInformation().AccountsNumberExists(accountType), $"Failed to find the '{accountType} Accounts' number", $"Successfully found the '{accountType} Accounts' number"))
			{
				string getAccountsNumber = new CompanyInformation().GetAccountsNumber(accountType);
				Report.IsTrue(getAccountsNumber.Trim() == expectedNumber, $"Found: {getAccountsNumber} '{accountType} Accounts', when {expectedNumber} were expected!", $"Successfully found: {getAccountsNumber} '{accountType} Accounts'");
			}
		}
		[RegexStepDefinition(@"In the Company Information Section, the statement 'Are you a registered or voluntary steward in the any of the following provinces\? Enter your steward number for all applicable provinces.' (is|is not) displayed")]
		public void VerifyStewardshipNumbersStatement(string is_isnot)
		{
			string text = "Are you a registered or voluntary steward in the any of the following provinces?  Enter your steward number for all applicable provinces.";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);

		}
		[RegexStepDefinition(@"In the Company Information Section, the checkbox 'I have no Stewardship Numbers' (is|is not) checked")]
		public void TheCheckboxIsIsNotChecked(string is_isnot)
		{
			string checkbox = "I have no Stewardship Numbers";
			new Steps_Prototype().TheCheckboxWithDescriptionIsIsNotChecked(checkbox, is_isnot);
		}
		[RegexStepDefinition(@"In the Company Information Section, uncheck the checkbox 'I have no Stewardship Numbers'")]
		public void CheckUncheckTheCheckbox()
		{
			string check_uncheck = "uncheck";
			string checkbox = "I have no Stewardship Numbers";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(check_uncheck, checkbox);
		}
		[RegexStepDefinition(@"In the Company Information Section, click the checkbox 'I have no Stewardship Numbers'")]
		public void ClickTheCheckbox()
		{
			string checkbox = "I have no Stewardship Numbers";
			new Steps_Prototype().ClickTheCheckboxWithDescription(checkbox);
		}
		[RegexStepDefinition(@"In the Company Information section, the 'Clear Stewardship Data\?' modal window (should|should not) be displayed with text 'You have indicated that you have no stewardship numbers. Any information previously entered in the stewardship table will be cleared. Is this correct\? Do you wish to proceed\?'")]
		public void ClearStewardshipDataModalIsDisplayed(string condition)
		{
			string modalTitle = "×\r\nClear Stewardship Data?";
			string text = "You have indicated that you have no stewardship numbers. Any information previously entered in the stewardship table will be cleared. Is this correct? Do you wish to proceed?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, modalTitle, text);
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Clear Stewardship Data\?' modal click the button (Yes|No)")]
		public void ClearStewardshipDataModalClickButton(string button)
		{
			string modalTitle = "Clear Stewardship Data?";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(modalTitle, button);
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Stewardship' table, for Province (British Columbia|Saskatchewan|Manitoba|Ontario|Quebec) in the (Stewardship|Issue Date|Expire Date) column the displayed value is (.*)")]
		public void CheckDataInTheStewardshipNumbersTable(string province, string columnName, string value)
		{
			Report.IsTrue(new CompanyInfoStewardshipTableRow(province).CheckTableData(columnName, value), $"Failed to confirm the displayed value is '{value}' in the '{columnName}' column for {province} province", $"Successfully confirmed the displayed value is '{value}' in the '{columnName}' column for {province} province");
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Stewardship' table, for Province (British Columbia|Saskatchewan|Manitoba|Ontario|Quebec) in the (Stewardship|Issue Date|Expire Date) column enter value (.*)")]
		public void EnterDataInTheStewardshipNumbersTable(string province, string columnName, string value)
		{
			Report.IsTrue(new CompanyInfoStewardshipTableRow(province).EnterTableData(columnName, value), $"Failed to enter '{value}' in the '{columnName}' column for {province} province", $"Successfully entered '{value}' in the '{columnName}' column for {province} province");
		}
	}
	
}

	

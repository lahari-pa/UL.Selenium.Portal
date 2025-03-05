using NPOI.POIFS.Properties;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "MyAccount:PaymentMethods")]
	class StepsPaymentMethods
	{
		[RegexStepDefinition(@"In the Payment Methods section, text 'Select your default payment method' (is|is not) displayed")]
		public void SelectYourDefaultPaymentMethodIsDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			string text = "Select your default payment method";
			if (Report.IsTrue(new PaymentMethods_new().PageSubHeaderLabelExists(), $"Failed to find the sub-header", $"Successfully found the sub-header"))
			{
				Report.IsTrue(new PaymentMethods_new().PageSubHeaderLabelGet() == text == expected, $"Failed to confirm the sub-header {(expected ? "is not" : "is")} displayed with text '{text}'", $"Successfully confirmed the sub-header {is_isnot} displayed with text '{text}'");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, the warning message (should|should not) be displayed with text (.*)")]
		public void TextForAnnualRenewalsIsDisplayed(string condition, string text)
		{
			new Steps_Prototype().AlertMessageDisplayed(condition, text);
		}
		[RegexStepDefinition(@"In the Payment Methods section, the default method is (Credit Card|Wire Transfer)")]
		public void VerifyDefaultPaymentMethod(string defaultMethod)
		{
			if (Report.IsTrue(new PaymentMethods_new().DefaultMethodExists(), $"Failed to find the default method.", $"Successfully found the default method."))
			{
				Report.IsTrue(new PaymentMethods_new().GetDefaultMethod().Contains(defaultMethod), $"Failed to confirm the default method is '{defaultMethod}'.", $"Successfully confirmed the default method is '{defaultMethod}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, verify the (Credit Card|ACH|PayPal) button (is|is not) displayed under 'Add a New Payment Method' section")]
		public void VerifyAddNewMethodIsDisplayed(string button, string is_isnot)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new PaymentMethods_new().AddNewMethodButtonExists(button)==expected, $"Failed to confirm the '{button}' button {(expected ? "is not" : "is")} found.", $"Successfully confirmed the '{button}' button {is_isnot} found."))
			{
				Report.IsTrue(new PaymentMethods_new().AddNewMethodButtonDisplayed(button) == expected, $"Failed to confirm the '{button}' button {(expected ? "is not" : "is")} displayed.", $"Successfully confirmed the '{button}' button {is_isnot} displayed.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, click the (Credit Card|ACH|PayPal) button under 'Add a New Payment Method' section")]
		public void ClickAddNewMethod(string button)
		{
			if (Report.IsTrue(new PaymentMethods_new().AddNewMethodButtonExists(button), $"Failed to find the '{button}' button.", $"Successfully found the '{button}' button."))
			{
				Report.IsTrue(new PaymentMethods_new().AddNewMethodButtonClick(button), $"Failed to click the '{button}' button.", $"Successfully clicked the '{button}' button.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, click the 'Change' button for Contact Information")]
		public void ClickChangeButton()
		{
			string button = "Change";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Payment Methods section, the Account Name is (.*)")]
		public void VerifyAccountName(string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().AccountNameExists(), $"Failed to find the Account Name.", $"Successfully found the Account Name."))
			{
				Report.IsTrue(new PaymentMethods_new().GetAccountName() == value, $"Failed to confirm the Account Name is '{value}'.", $"Successfully confirmed the Account Name is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, the Last Name is (.*)")]
		public void VerifyLastName(string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().LastNameExists(), $"Failed to find the Last Name.", $"Successfully found the Last Name."))
			{
				Report.IsTrue(new PaymentMethods_new().GetLastName() == value, $"Failed to confirm the Last Name is '{value}'.", $"Successfully confirmed the Last Name is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, the First Name is (.*)")]
		public void VerifyFirstName(string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().FirstNameExists(), $"Failed to find the First Name.", $"Successfully found the First Name."))
			{
				Report.IsTrue(new PaymentMethods_new().GetFirstName() == value, $"Failed to confirm the First Name is '{value}'.", $"Successfully confirmed the First Name is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, the Email is (.*)")]
		public void VerifyEmail(string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().EmailExists(), $"Failed to find the Email.", $"Successfully found the Email."))
			{
				Report.IsTrue(new PaymentMethods_new().GetEmail() == value, $"Failed to confirm the Email is '{value}'.", $"Successfully confirmed the Email is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the Address 1 is (.*)")]
		public void VerifyAddress1(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().Address1Exists(addressType), $"Failed to find the Address 1.", $"Successfully found the Address 1."))
			{
				Report.IsTrue(new PaymentMethods_new().GetAddress1(addressType) == value, $"Failed to confirm the Address 1 is '{value}'.", $"Successfully confirmed the Address 1 is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the Address 2 is (.*)")]
		public void VerifyAddress2(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().Address2Exists(addressType), $"Failed to find the Address 2.", $"Successfully found the Address 2."))
			{
				Report.IsTrue(new PaymentMethods_new().GetAddress2(addressType) == value, $"Failed to confirm the Address 2 is '{value}'.", $"Successfully confirmed the Address 2 is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the City is (.*)")]
		public void VerifyCity(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().CityStatePostalExists(addressType), $"Failed to find the City.", $"Successfully found the City."))
			{
				Report.IsTrue(new PaymentMethods_new().GetCityStatePostal(addressType).Contains(value), $"Failed to confirm the City is '{value}'.", $"Successfully confirmed the City is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the State is (.*)")]
		public void VerifyState(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().CityStatePostalExists(addressType), $"Failed to find the State.", $"Successfully found the State."))
			{
				Report.IsTrue(new PaymentMethods_new().GetCityStatePostal(addressType).Contains(value), $"Failed to confirm the State is '{value}'.", $"Successfully confirmed the State is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the Postal Code is (.*)")]
		public void VerifyPostalCode(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().CityStatePostalExists(addressType), $"Failed to find the Postal Code.", $"Successfully found the Postal Code."))
			{
				Report.IsTrue(new PaymentMethods_new().GetCityStatePostal(addressType).Contains(value), $"Failed to confirm the Postal Code is '{value}'.", $"Successfully confirmed the Postal Code is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the Country is (.*)")]
		public void VerifyCountry(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().CountryExists(addressType), $"Failed to find the Postal Code.", $"Successfully found the Postal Code."))
			{
				Report.IsTrue(new PaymentMethods_new().GetCountry(addressType) == value, $"Failed to confirm the Country is '{value}'.", $"Successfully confirmed the Country is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) the Phone is (.*)")]
		public void VerifyPhone(string addressType, string value)
		{
			if (Report.IsTrue(new PaymentMethods_new().PhoneExists(addressType), $"Failed to find the Phone.", $"Successfully found the Phone."))
			{
				Report.IsTrue(new PaymentMethods_new().GetPhone(addressType) == value, $"Failed to confirm the Phone is '{value}'.", $"Successfully confirmed the Phone is '{value}'.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the 'Edit Address' modal window, set (Account Name|First Name|Last Name|Email Address) to (.*)")]
		public void UpdateContactInformation(string section, string option)
		{
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) of 'Edit Address' modal, for (Address Line 1|Address Line 2|City|Zip|Phone) enter (.*)")]
		public void EnterOptionForyAddressTextInput(string addressType,string section, string value)
		{
			if (Report.IsTrue(new EditAddress(addressType).TextInputExists(section), $"Failed to find the '{section}' text input", $"Successfully found the '{section}' text input."))
			{
				Report.IsTrue(new EditAddress(addressType).TextInputEnter(section, value), $"Failed to enter '{value}' in the '{section}' input.", $"Successfully entered '{value}' in the '{section}' field.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the (Billing Address|Shipping Address) of 'Edit Address' modal, for (State|Country) select (.*)")]
		public void SelectOptionForAddress(string addressType, string section, string value)
		{
			if (Report.IsTrue(new EditAddress(addressType).SelectInputExists(section), $"Failed to find the '{section}' select input", $"Successfully found the '{section}' select input."))
			{
				Report.IsTrue(new EditAddress(addressType).SelectInputEnter(section, value), $"Failed to select '{value}' in the '{section}' input.", $"Successfully selected '{value}' in the '{section}' field.");
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the 'Edit Address' modal window (check|uncheck) checkbox 'Shipping Address is the same as billing address'")]
		public void InTheEditAddressModalCheckbox(string check_uncheck)
		{
			string checkbox = "Shipping Address is the same as billing address";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(check_uncheck, checkbox);
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the 'Edit Address' modal click the (Cancel|Save) button")]
		public void EditAddressClickButton(string button)
		{
			string modalTitle = "Edit Address";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(modalTitle, button);
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the 'Add Credit Card' modal window, set (Month|Year|Card Number|CVV|Cardholder Name|Postal Code) to (.*)")]
		public void AddCreditCardInformation(string section, string option)
		{
			if (section == "Month" | section == "Year")
			{
				Report.Info("Switching to iFrame");
				WebDriverWait iFrameWait = new(SeleniumWebDriver.CurrentDriver, TimeSpan.FromSeconds(120));
				_ = iFrameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("z_hppm_iframe")));
				Report.IsTrue(new PaymentMethods_new().SelectOptionInSectionJs(section, option), $"Failed to select option {option} for section {section}", $"Successfully selected option {option} for section {section}");
				Report.Info("Exiting iFrame");
				SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
			}
			else
			{
				Report.Info("Switching to iFrame");
				WebDriverWait iFrameWait = new(SeleniumWebDriver.CurrentDriver, TimeSpan.FromSeconds(120));
				_ = iFrameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("z_hppm_iframe")));
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
				Report.Info("Exiting iFrame");
				SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the 'Add ACH Account' modal window, set (ABA\/Routing Number|Bank Account Number|Account Type|Bank Name|Account Holder Name) to (.*)")]
		public void AddACHAccountInformation(string section, string option)
		{
			if (section == "Account Type")
			{
				Report.Info("Switching to iFrame");
				WebDriverWait iFrameWait = new(SeleniumWebDriver.CurrentDriver, TimeSpan.FromSeconds(120));
				_ = iFrameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("z_hppm_iframe")));
				Report.IsTrue(new PaymentMethods_new().SelectOptionInSectionJs(section, option), $"Failed to select option {option} for section {section}" , $"Successfully selected option {option} for section {section}");
				Report.Info("Exiting iFrame");
				SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
			}
			else
			{
				Report.Info("Switching to iFrame");
				WebDriverWait iFrameWait = new(SeleniumWebDriver.CurrentDriver, TimeSpan.FromSeconds(120));
				_ = iFrameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("z_hppm_iframe")));
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
				Report.Info("Exiting iFrame");
				SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
			}
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the '(Add Credit Card|Add ACH Account)' modal click the (Save|Close) button")]
		public void AddCreditCardClickButton(string modalTitle, string button)
		{
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(modalTitle, button);
		}
		[RegexStepDefinition(@"In the Payment Methods section, in the modal window click the Submit button")]
		public void AddCreditCardClickSubmitButton()
		{
			Report.IsTrue(new PaymentMethods().ClickSubmitButton(), "Failed to click Submit button", "Successfully clicked Submit button");

		}
	}
	
}

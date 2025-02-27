using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PaymentMethods_new : SeleniumBaseObject
	{
		#region Constants
		protected override By ContainerElementLocator => By.Id("paymentMethodsContainer");
		private IWebElement PageHeader => this.ContainerElement.FindElement(By.XPath($".//div[@class='header-with-back']"), 1);
		private IWebElement PageHeaderBackButton => this.PageHeader.FindElement(By.XPath($".//a[@class=''back-btn]"), 1);
		private IWebElement PageHeaderLabel => this.PageHeader.FindElement(By.XPath($".//h2"), 1);
		private IWebElement PageSubHeaderLabel => this.ContainerElement.FindElement(By.XPath($".//h2[@class='ws-panel-title']"), 1);

		private string _paymentMethodButtonLabel;
		private IWebElement PaymentMethodButton => this.ContainerElement.FindElement(By.XPath($".//a[contains(@class,'big-link')]//div[text()='{_paymentMethodButtonLabel}']"), 1);
		private IWebElement DefaultMethod => this.ContainerElement.FindElement(By.XPath($".//div[@class='card payment-method' and div//span[text()='Default']]//h4"), 2);
		private IWebElement AddNewMethodButton(string button) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='Add a New Payment Method']]//button[normalize-space()='{button}']"), 2);
		private IWebElement AccountName() => this.ContainerElement.FindElement(By.XPath($".//div[contains(@data-bind, 'AccountName')]"), 2);
		private IWebElement LastName() => this.ContainerElement.FindElement(By.XPath($".//div[contains(@data-bind, 'LastName')]"), 2);
		private IWebElement FirstName() => this.ContainerElement.FindElement(By.XPath($".//div[contains(@data-bind, 'FirstName')]"), 2);
		private IWebElement Email() => this.ContainerElement.FindElement(By.XPath($".//div[contains(@data-bind, 'Email')]"), 2);
		private IWebElement Address1(string addressType) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='{addressType}']]//div[contains(@data-bind, 'Address1')]"), 2);
		private IWebElement Address2(string addressType) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='{addressType}']]//div[contains(@data-bind, 'Address2')]"), 2);
		private IWebElement CityStatePostal(string addressType) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='{addressType}']]//div[contains(@data-bind, 'cityStatePostal')]"), 2);
		private IWebElement Country(string addressType) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='{addressType}']]//div[contains(@data-bind, 'Country')]"), 2);
		private IWebElement Phone(string addressType) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='{addressType}']]//div[contains(@data-bind, 'Phone')]"), 2);


		#endregion

		#region Methods
		public bool PageHeaderLabelExists()
		{
			Report.Info($"Attempting to confirm the page header label exists.");
			return this.PageHeaderLabel != null;
		}

		public string PageHeaderLabelGet()
		{
			Report.Info($"Attempting to get the page header label.");
			return this.PageHeaderLabel.Text;
		}

		public bool PageHeaderBackButtonExists()
		{
			Report.Info($"Attempting to confirm the page header back button exists.");
			return this.PageHeaderBackButton != null;
		}

		public bool PageHeaderBackButtonClick()
		{
			Report.Info($"Attempting to click the page header back button.");
			return this.PageHeaderBackButton.TryClick();
		}

		public bool PageSubHeaderLabelExists()
		{
			Report.Info($"Attempting to confirm page sub header label exists.");
			return this.PageSubHeaderLabel != null;
		}

		public string PageSubHeaderLabelGet()
		{
			Report.Info($"Attempting to get the page sub header label.");
			return this.PageSubHeaderLabel.Text;
		}

		public bool PaymentMethodButtonExists(string paymentMethodButtonLabel)
		{
			Report.Info($"Attempting to confirm '{paymentMethodButtonLabel}' button exists.");
			_paymentMethodButtonLabel = paymentMethodButtonLabel;
			return this.PaymentMethodButton != null;
		}
		public bool PaymentMethodButtonClick(string paymentMethodButtonLabel)
		{
			Report.Info($"Attempting to click '{paymentMethodButtonLabel}' button.");
			_paymentMethodButtonLabel = paymentMethodButtonLabel;
			return this.PaymentMethodButton.TryClick();
		}
		public bool DefaultMethodExists()
		{
			Report.Info($"Attempting to confirm the default payment method exists.");
			return this.DefaultMethod != null;
		}
		public string GetDefaultMethod()
		{
			Report.Info($"Attempting to get the default payment method.");
			return this.DefaultMethod.Text;
		}
		public bool AddNewMethodButtonExists(string button)
		{
			Report.Info($"Attempting to confirm the '{button}' button exists under 'Add a New Payment Method' section");
			return this.AddNewMethodButton(button) != null;
		}
		public bool AddNewMethodButtonDisplayed(string button)
		{
			Report.Info($"Attempting to confirm the '{button}' button is displayed under 'Add a New Payment Method' section");
			return this.AddNewMethodButton(button).Displayed;
		}
		public bool AddNewMethodButtonClick(string button)
		{
			Report.Info($"Attempting to click the '{button}' button under 'Add a New Payment Method' section");
			return this.AddNewMethodButton(button).TryClick();
		}
		public bool AccountNameExists()
		{
			Report.Info($"Attempting to confirm the Account Name exists.");
			return this.AccountName() != null;
		}
		public string GetAccountName()
		{
			Report.Info($"Attempting to get the Account Name.");
			return this.AccountName().Text;
		}
		public bool LastNameExists()
		{
			Report.Info($"Attempting to confirm the Last Name exists.");
			return this.LastName() != null;
		}
		public string GetLastName()
		{
			Report.Info($"Attempting to get the Last Name.");
			return this.LastName().Text;
		}
		public bool FirstNameExists()
		{
			Report.Info($"Attempting to confirm the First Name exists.");
			return this.FirstName() != null;
		}
		public string GetFirstName()
		{
			Report.Info($"Attempting to get the First Name.");
			return this.FirstName().Text;
		}
		public bool EmailExists()
		{
			Report.Info($"Attempting to confirm the Email exists.");
			return this.Email() != null;
		}
		public string GetEmail()
		{
			Report.Info($"Attempting to get the Email.");
			return this.Email().Text;
		}
		public bool Address1Exists(string addressType)
		{
			Report.Info($"Attempting to confirm the Address 1 exists.");
			return this.Address1(addressType) != null;
		}
		public string GetAddress1(string addressType)
		{
			Report.Info($"Attempting to get the Address 1.");
			return this.Address1(addressType).Text;
		}
		public bool Address2Exists(string addressType)
		{
			Report.Info($"Attempting to confirm the Address 2 exists.");
			return this.Address2(addressType) != null;
		}
		public string GetAddress2(string addressType)
		{
			Report.Info($"Attempting to get the Address 2.");
			return this.Address2(addressType).Text;
		}
		public bool CityStatePostalExists(string addressType)
		{
			Report.Info($"Attempting to confirm City, State, Postal Code exists.");
			return this.CityStatePostal(addressType) != null;
		}
		public string GetCityStatePostal(string addressType)
		{
			Report.Info($"Attempting to get City, State, Postal Code.");
			return this.CityStatePostal(addressType).Text;
		}
		public bool CountryExists(string addressType)
		{
			Report.Info($"Attempting to confirm the Country exists.");
			return this.Country(addressType) != null;
		}
		public string GetCountry(string addressType)
		{
			Report.Info($"Attempting to get the Country.");
			return this.Country(addressType).Text;
		}
		public bool PhoneExists(string addressType)
		{
			Report.Info($"Attempting to confirm the Phone exists.");
			return this.Phone(addressType) != null;
		}
		public string GetPhone(string addressType)
		{
			Report.Info($"Attempting to get the Phone.");
			return this.Phone(addressType).Text;
		}
		#endregion
	}
	class EditAddress : SeleniumBaseObject
	{
		#region Constants
		private string _addressType;
		protected override By ContainerElementLocator => By.XPath($"//div[h4[text()='{_addressType}']]");
		IWebElement TextInput(string section) => this.ContainerElement.FindElement(By.XPath($".//div[label[text()='{section}']]//input"));
		IWebElement SelectInput(string section) => this.ContainerElement.FindElement(By.XPath($".//div[label[text()='{section}']]//select"));

		#endregion

		#region Mathods
		public EditAddress(string addressType)
		{
			Report.Info($"Attempt to get '{addressType}' section");
			_addressType = addressType;
		}
		public bool TextInputExists(string section)
		{
			Report.Info($"Attempting to confirm the text input exists for {section} section.");
			return this.TextInput(section) != null;
		}
		public bool TextInputEnter(string section, string value)
		{
			Report.Info($"Attempting to enter text for {section} section.");
			return this.TextInput(section).TryEnterText(value);
		}
		public bool SelectInputExists(string section)
		{
			Report.Info($"Attempting to confirm the select input exists for {section} section.");
			return this.SelectInput(section) != null;
		}
		public bool SelectInputEnter(string section, string value)
		{
			Report.Info($"Attempting to select option for {section} section.");
			this.SelectInput(section).Select(value);
			return this.SelectInput(section).SelectedOption() == value;
		}
		#endregion

	}
}

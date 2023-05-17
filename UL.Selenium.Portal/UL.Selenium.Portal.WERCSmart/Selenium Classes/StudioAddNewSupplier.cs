using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using System.Net.Mail;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UL.Automation.Utilities.Mailosaur.Shared.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioAddNewSupplier : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id = 'dialog-supplier-manager-add-newsupplier']");
		IWebElement AcceptButton => this.FindElement(By.Id("btnAddNewSupplierSupplierAccount"), 2);
		IWebElement CompanyNameInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierName']"), 2);
		IWebElement SellerIdInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierVendorID']"), 2);
		IWebElement CountryInput => this.FindElement(By.XPath("//select[@id = 'ddNewSupplierCountries']"), 2);
		IWebElement CountryCodeInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierCountryCode']"), 2);
		IWebElement PhoneInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierSupplierPhone']"), 2);
		IWebElement AddressInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierAddressOne']"), 2);
		IWebElement CityInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierCity']"), 2);
		IWebElement StateInput => this.FindElement(By.XPath("//select[@id = 'ddNewSupplierState']"), 2);
		IWebElement PostalCodeInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierZip']"), 2);
		IWebElement ContactNameInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierContactName']"), 2);
		IWebElement ContactEmailInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierContactEmail']"), 2);
		IWebElement ContactPhoneInput => this.FindElement(By.XPath("//input[@id = 'txtNewSupplierContactPhone']"), 2);

		public bool InAddNewSupplierClickAcceptButton()
		{
			if (this.AcceptButton == null)
			{
				Report.Info($"No Accept button has been found");
				return false;
			}

			return this.AcceptButton.TryClick();
		}
		public bool InAddNewSupplierEnterCompanyName( string value)
		{

			if (this.CompanyNameInput == null)
			{
				Report.Info($"Failed to find field Company Name");
				return false;
			}
			return this.CompanyNameInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterSellerId(string value)
		{
			if (this.SellerIdInput == null)
			{
				Report.Info($"Failed to find field Supplier Seller ID");
				return false;
			}
			return this.SellerIdInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterCountry(string value)
		{
			if (this.CountryInput == null)
			{
				Report.Info($"Failed to find field Country");
				return false;
			}
			return this.CountryInput.JsSelectElementByText(value);
		}
		public bool InAddNewSupplierEnterCountryCode(string value)
		{

			if (this.CountryCodeInput == null)
			{
				Report.Info($"Failed to find field Country");
				return false;
			}
			return this.CountryCodeInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterSupplierPhone(string value)
		{
			if (this.PhoneInput == null)
			{
				Report.Info($"Failed to find field Supplier Phone");
				return false;
			}
			return this.PhoneInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterAddress(string value)
		{
			if (this.AddressInput == null)
			{
				Report.Info($"Failed to find field Address");
				return false;
			}
			return this.AddressInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterCity(string value)
		{
			if (this.CityInput == null)
			{
				Report.Info($"Failed to find field City");
				return false;
			}
			return this.CityInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterState(string value)
		{
			if (this.StateInput == null)
			{
				Report.Info($"Failed to find field State");
				return false;
			}
			return this.StateInput.JsSelectElementByText(value);
		}

		public bool InAddNewSupplierEnterPostalCode(string value)
		{
			if (this.PostalCodeInput == null)
			{
				Report.Info($"Failed to find field Postal Code");
				return false;
			}
			return this.PostalCodeInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterContactName(string value)
		{
			if (this.ContactNameInput == null)
			{
				Report.Info($"Failed to find field Contact Name");
				return false;
			}
			return this.ContactNameInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterContactEmail(string value)
		{
			if (this.ContactEmailInput == null)
			{
				Report.Info($"Failed to find field Contact Email");
				return false;
			}
			if (value == "random")
			{
				var mailboxActions = new MailboxActions("<random>");
				string email = mailboxActions.CreateRandomEmail("<random>");
				return this.ContactEmailInput.TryEnterText(email);

			}
			else
			{
				return this.ContactEmailInput.TryEnterText(value);
			}
		}
		public bool InAddNewSupplierEnterContactPhone(string value)
		{
			if (this.ContactPhoneInput == null)
			{
				Report.Info($"Failed to find field Contact Phone");
				return false;
			}
			return this.ContactPhoneInput.TryEnterText(value);
		}

	}
}


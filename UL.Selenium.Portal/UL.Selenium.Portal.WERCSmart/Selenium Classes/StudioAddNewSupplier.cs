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

		public bool InAddNewSupplierClickAcceptButton()
		{
			IWebElement AcceptButton = this.ContainerElement.FindElement(By.Id("btnAddNewSupplierSupplierAccount"), 2);
			if (AcceptButton == null)
			{
				Report.Info($"No Accept button has been found");
				return false;
			}

			if (AcceptButton.TryClick())
			{
				return true;
			}
			return false;
		}
		public bool InAddNewSupplierEnterCompanyName( string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierName']"));

			if (FieldInput == null)
				{
				Report.Info($"Failed to find field Company Name");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterSellerId(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierVendorID']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Supplier Seller ID");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterCountry(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//select[@id = 'ddNewSupplierCountries']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Country");
				return false;
			}
			return FieldInput.JsSelectElementByText(value);
		}
		public bool InAddNewSupplierEnterCountryCode(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierCountryCode']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Country");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterSupplierPhone(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierSupplierPhone']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Supplier Phone");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterAddress(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierAddressOne']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Address");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterCity(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierCity']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field City");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterState(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//select[@id = 'ddNewSupplierState']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field State");
				return false;
			}
			return FieldInput.JsSelectElementByText(value);
		}

		public bool InAddNewSupplierEnterPostalCode(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierZip']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Postal Code");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}

		public bool InAddNewSupplierEnterContactName(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierContactName']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Contact Name");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}
		public bool InAddNewSupplierEnterContactEmail(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierContactEmail']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Contact Email");
				return false;
			}
			if (value == "random")
			{
				var mailboxActions = new MailboxActions("<random>");
				string email = mailboxActions.CreateRandomEmail("<random>");
				return FieldInput.TryEnterText(email);

			}
			else
			{
				return FieldInput.TryEnterText(value);
			}
		}
		public bool InAddNewSupplierEnterContactPhone(string value)
		{
			IWebElement FieldInput = this.ContainerElement.FindElement(By.XPath("//input[@id = 'txtNewSupplierContactPhone']"));

			if (FieldInput == null)
			{
				Report.Info($"Failed to find field Contact Phone");
				return false;
			}
			return FieldInput.TryEnterText(value);
		}

	}
}


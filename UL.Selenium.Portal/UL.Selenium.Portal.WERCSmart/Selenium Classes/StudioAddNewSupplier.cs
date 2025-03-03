using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.Utilities.Mailosaur.Shared.Classes;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

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
		private IWebElement CancelButton => this.FindElement(By.XPath("//table[@class= 'new-supplier']//button[contains(text(), 'Cancel')]"), 2);
		private IWebElement NewSupplierButton => this.FindElement(By.XPath("//button[contains(text(), 'New Supplier')]"), 2);
		private IWebElement CloseSupplierManagerwindow => this.FindElement(By.XPath("//span[contains(text(),'Supplier Manager')]//parent::div/a"), 2);

		public bool InAddNewSupplierClickAcceptButton()
		{
			return this.AcceptButton.TryClick();
		}
		public bool AcceptButtonExists()
		{
			Report.Info("Attempting to confirm Accept Button exists.");
			return this.AcceptButton != null;
		}
		public bool InAddNewSupplierEnterCompanyName(string value)
		{
			return this.CompanyNameInput.TryEnterText(value);
		}
		public bool CompanyNameInputExists()
		{
			Report.Info("Attempting to confirm Company Name input exists.");
			return this.CompanyNameInput != null;
		}

		public bool InAddNewSupplierEnterSellerId(string value)
		{
			return this.SellerIdInput.TryEnterText(value);
		}

		public bool SellerIdInputExists()
		{
			Report.Info("Attempting to confirm Seller ID input exists.");
			return this.SellerIdInput != null;
		}
		public bool InAddNewSupplierEnterCountry(string value)
		{
			return this.CountryInput.JsSelectElementByText(value);
		}
		public bool CountryInputExists()
		{
			Report.Info("Attempting to confirm Country input exists.");
			return this.CountryInput != null;
		}
		public bool InAddNewSupplierEnterCountryCode(string value)
		{
			return this.CountryCodeInput.TryEnterText(value);
		}
		public bool CountryCodeInputExists()
		{
			Report.Info("Attempting to confirm Country Code input exists.");
			return this.CountryCodeInput != null;
		}
		public bool InAddNewSupplierEnterSupplierPhone(string value)
		{
			return this.PhoneInput.TryEnterText(value);
		}
		public bool SupplierPhoneInputExists()
		{
			Report.Info("Attempting to confirm Supplier Phone input exists.");
			return this.PhoneInput != null;
		}
		public bool InAddNewSupplierEnterAddress(string value)
		{
			return this.AddressInput.TryEnterText(value);
		}
		public bool AddressInputExists()
		{
			Report.Info("Attempting to confirm Address input exists.");
			return this.AddressInput != null;
		}

		public bool InAddNewSupplierEnterCity(string value)
		{
			return this.CityInput.TryEnterText(value);
		}
		public bool CityInputExists()
		{
			Report.Info("Attempting to confirm City input exists.");
			return this.CityInput != null;
		}
		public bool InAddNewSupplierEnterState(string value)
		{
			return this.StateInput.JsSelectElementByText(value);
		}
		public bool StateInputExists()
		{
			Report.Info("Attempting to confirm State input exists.");
			return this.StateInput != null;
		}

		public bool InAddNewSupplierEnterPostalCode(string value)
		{
			return this.PostalCodeInput.TryEnterText(value);
		}
		public bool PostalCodeInputExists()
		{
			Report.Info("Attempting to confirm Postal Code input exists.");
			return this.PostalCodeInput != null;
		}
		public bool InAddNewSupplierEnterContactName(string value)
		{
			return this.ContactNameInput.TryEnterText(value);
		}
		public bool ContactNameInputExists()
		{
			Report.Info("Attempting to confirm Contact Name input exists.");
			return this.ContactNameInput != null;
		}
		public bool InAddNewSupplierEnterContactEmail(string value)
		{
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
		public bool ContactEmailInputExists()
		{
			Report.Info("Attempting to confirm Contact Email input exists.");
			return this.ContactEmailInput != null;
		}
		public bool InAddNewSupplierEnterContactPhone(string value)
		{
			return this.ContactPhoneInput.TryEnterText(value);
		}
		public bool ContactPhoneInputExists()
		{
			Report.Info("Attempting to confirm Contact Phone input exists.");
			return this.ContactPhoneInput != null;
		}
		public bool InAddNewSupplierClickCancelButton()
		{
			return this.CancelButton.TryClick();
		}
		public bool CancelButtonExists()
		{
			Report.Info("Attempting to confirm Cancel Button exists.");
			return this.CancelButton != null;
		}
		public bool ClickNewSupplierButton()
		{
			return this.NewSupplierButton.TryClick();
		}
		public bool NewSupplierButtonExists()
		{
			Report.Info("Attempting to confirm New Supplier Button exists.");
			return this.NewSupplierButton != null;
		}
		public bool CloseSupplierManagerButton()
		{
			return this.CloseSupplierManagerwindow.TryClick();
		}
		public bool CloseSupplierManagerButtonExists()
		{
			Report.Info("Attempting to confirm Supplier Manager close Button exists.");
			return this.CloseSupplierManagerwindow != null;
		}
	}
}


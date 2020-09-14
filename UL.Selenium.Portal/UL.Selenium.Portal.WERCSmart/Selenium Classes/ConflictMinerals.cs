using System;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ConflictMinerals : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='container-fluid']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public string VerificationCode {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='VerificationCode']"), 2).GetValue().Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='VerificationCode']"), 2).EnterText(value);
		}


		public string EmailAddress {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='UserName']"), 2).GetValue().Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='UserName']"), 2).EnterText(value);
		}

		public string Password {
			set
			{

				Delay.Seconds(1);
				IWebElement password = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='Password']"), 2);
				password.EnterText(value);
				Delay.Seconds(1);

			}
			get => SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='Password']"), 2).GetValue();
		}

		public bool ErrorMessageShowing()
		{
			try
			{
				IWebElement error = SeleniumBrowser.WebBrowser.FindElements(By.XPath(
						".//div[@class='validation-summary-errors']/span"), 2)
					.FirstOrDefault(x => x.Text.Contains("Log in was unsuccessful"));
				if (error != null)
				{
					return true;
				}
			}
			catch (Exception)
			{

			}
			return false;

		}

		public string NewEmail {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).EnterText(value);
		}

		public string CompanyName {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtCompanyName']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtCompanyName']"), 2).EnterText(value);
		}

		public string Address1 {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress1']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress1']"), 2).EnterText(value);
		}

		public string Address2 {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress2']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress2']"), 2).EnterText(value);
		}

		public string Address3 {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress3']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress3']"), 2).EnterText(value);
		}
		public string City {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtCity']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtCity']"), 2).EnterText(value);
		}
		public string State {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtState']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtState']"), 2).EnterText(value);
		}

		public string PostalCode {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtPostalCode']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtPostalCode']"), 2).EnterText(value);
		}



		public string Contact {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtContactName']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtContactName']"), 2).EnterText(value);
		}

		public string ContactEmail => this.containerElement.FindElement(By.XPath(".//input[@id='txtContactEmail']"), 2).GetValue().Trim();

		public string ContactPhoneNumber {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtContactPhone']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtContactPhone']"), 2).EnterText(value);
		}

		public string ContactAdditionalEmails {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAdditionalEmail']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAdditionalEmail']"), 2).EnterText(value);
		}

		public string ContactPassword {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2).EnterText(value);
		}

		public string ContactReEnterPassword {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtRePassword']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtRePassword']"), 2).EnterText(value);
		}

		public string ContactCity {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer1']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer1']"), 2).EnterText(value);
		}

		public string ContactModel {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer2']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer2']"), 2).EnterText(value);
		}
		public string ContactSport {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer3']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer3']"), 2).EnterText(value);
		}
		public string ContactFood {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).EnterText(value);
		}
		public string ContactVacation {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).EnterText(value);
		}

		public string ContactIdentityPassword {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).EnterText(value);
		}

		public string Country {
			get
			{
				IWebElement countrySelect = this.containerElement.FindElement(By.XPath(".//select[@id='Countries']"), 2);
				return countrySelect.SelectedOption();
			}
			set
			{
				IWebElement countrySelect = this.containerElement.FindElement(By.XPath(".//select[@id='Countries']"), 2);
				countrySelect.Select(value);
			}
		}

		public string PhoneNumber {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtPhone']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtPhone']"), 2).EnterText(value);
		}

		public string EmergencyPhoneNumber {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtEmergencyPhone']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtEmergencyPhone']"), 2).EnterText(value);
		}

		public string Fax {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtFax']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtFax']"), 2).EnterText(value);
		}

		public bool AcceptTermsOfUse {
			get => this.containerElement.FindElement(By.XPath(".//*[@id='Accepted']"), 2).Checked();
			set
			{
				IWebElement chkAccepted = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//*[@id='Accepted']"), 2);
				chkAccepted.Check(value);
			}
		}

		public bool ClickLogin()
		{
			IWebElement loginButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdLogIn']"), 2);
			if (loginButton != null)
			{
				return loginButton.TryClick();
			}

			return false;
		}

		public bool ClickContinue()
		{
			Delay.Seconds(1);
			IWebElement continueButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//*[@type='submit']"), 2);
			if (continueButton != null)
			{
				return continueButton.TryClick();
			}

			return false;
		}

		public bool ClickCongratulationsLogin()
		{
			IWebElement loginButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//button[@id='cmdSupplierLogin']"), 2);
			if (loginButton != null)
			{
				return loginButton.TryClick();
			}

			return false;
		}

		public bool ClickCreateCompanyAccount()
		{
			ReadOnlyCollection<IWebElement> listOfAs = this.containerElement.FindElements(By.XPath(".//a"));

			IWebElement createCompanyLink = listOfAs.FirstOrDefault(x => x.Text.Contains("Create Company Account"));
			if (createCompanyLink != null)
			{
				return createCompanyLink.TryClick();
			}

			return false;
		}



		public bool ClickSignIn()
		{
			IWebElement signInLink = this.containerElement.FindElement(By.XPath(".//a[@id='loginLink']"), 2);

			if (signInLink != null)
			{
				return signInLink.TryClick();
			}
			return false;
		}

		public bool ClickNext()
		{
			IWebElement nextButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdNext']"), 2);

			if (nextButton != null)
			{
				return nextButton.TryClick();
			}
			return false;
		}

		public bool ClickBack()
		{
			IWebElement backButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdBack']"), 2);

			if (backButton != null)
			{
				return backButton.TryClick();
			}
			return false;
		}

		public bool ClickCancel()
		{
			IWebElement cancelButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdCancel']"), 2);

			if (cancelButton != null)
			{
				return cancelButton.TryClick();
			}
			return false;
		}

		public bool ClickVerify()
		{
			Delay.Seconds(1);
			IWebElement verifyButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//*[@id='cmdVerify']"), 2);

			if (verifyButton != null)
			{
				return verifyButton.TryClick();
			}
			return false;
		}

		public bool WaitForCreateCompanyAccountFormPage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement CompanyNameField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='txtCompanyName']"), 2);

				if (CompanyNameField != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public bool WaitForCongratulationsPage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement Contents = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@class='legends']"), 2).FirstOrDefault(x => x.Text.Contains("Congratulations! You have successfully"));

				if (Contents != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public bool WaitForEnterVerificationCodePage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					IWebElement VerificationField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//*[@id='VerificationCode']"), 2);
					if (VerificationField != null)
					{
						return true;
					}
				}
				catch (Exception)
				{
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public bool WaitForTermsOfUsePage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					IWebElement AcceptedCheckField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='Accepted']"), 2);

					if (AcceptedCheckField != null)
					{
						return true;
					}
				}
				catch (Exception)
				{
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public bool WaitForDashboardPage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					IWebElement h1Dashboard = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//h1"), 2).FirstOrDefault(x => x.Text.Contains("Dashboard"));

					if (h1Dashboard != null)
					{
						return true;
					}
				}
				catch (Exception)
				{

				}

				Delay.Seconds(1);
			}

			return false;
		}

		public bool WaitForCompanyContactFormPage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement ContactNameField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='txtContactName']"), 2);

				if (ContactNameField != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public bool WaitForVerifyNewCompanyAccountPage(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement emailField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='txtEmail']"), 2);

				if (emailField != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public string GetCompanyNameSignedIn()
		{
			IWebElement username = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[contains(@class, 'username')]"), 2);
			if (username != null)
			{
				return username.Text;
			}

			return "";

		}

		public string GetEmailSignedIn()
		{
			IWebElement username = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//i[@class='fa fa-user']"), 2);
			if (username != null)
			{
				return username.GetValue();
			}

			return "";

		}

		public bool GoodGuideDashboardLoads()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//header//p[contains(text(),'GoodGuide')]"), 2) != null;
		}

		public bool UlToysDashboardLoads()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h2[text()='My Company Details']"), 30) != null;
		}
	}
}

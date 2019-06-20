using System;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ConflictMinerals : BaseObject
	{
		public const string BasePath = "//div[@class='container-fluid']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string VerificationCode {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='VerificationCode']"), 2).GetValue().Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='VerificationCode']"), 2).EnterText(value); }
		}


		public string EmailAddress {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='UserName']"), 2).GetValue().Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='UserName']"), 2).EnterText(value); }
		}

		public string Password {
			set
			{

				Delay.Seconds(1);
				var password = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='Password']"), 2);
				password.EnterText(value);
				Delay.Seconds(1);

			}
			get { return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='Password']"), 2).GetValue(); }
		}

		public bool ErrorMessageShowing()
		{
			try
			{
				var error = SeleniumBrowser.WebBrowser.FindElements(By.XPath(
						".//div[@class='validation-summary-errors']/span"))
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
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).EnterText(value); }
		}

		public string CompanyName {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtCompanyName']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtCompanyName']"), 2).EnterText(value); }
		}

		public string Address1 {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress1']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress1']"), 2).EnterText(value); }
		}

		public string Address2 {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress2']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress2']"), 2).EnterText(value); }
		}

		public string Address3 {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress3']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAddress3']"), 2).EnterText(value); }
		}
		public string City {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtCity']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtCity']"), 2).EnterText(value); }
		}
		public string State {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtState']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtState']"), 2).EnterText(value); }
		}

		public string PostalCode {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtPostalCode']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtPostalCode']"), 2).EnterText(value); }
		}



		public string Contact {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtContactName']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtContactName']"), 2).EnterText(value); }
		}

		public string ContactEmail {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtContactEmail']"), 2).GetValue().Trim(); }

		}

		public string ContactPhoneNumber {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtContactPhone']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtContactPhone']"), 2).EnterText(value); }
		}

		public string ContactAdditionalEmails {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAdditionalEmail']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAdditionalEmail']"), 2).EnterText(value); }
		}

		public string ContactPassword {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2).EnterText(value); }
		}

		public string ContactReEnterPassword {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtRePassword']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtRePassword']"), 2).EnterText(value); }
		}

		public string ContactCity {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer1']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer1']"), 2).EnterText(value); }
		}

		public string ContactModel {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer2']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer2']"), 2).EnterText(value); }
		}
		public string ContactSport {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer3']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer3']"), 2).EnterText(value); }
		}
		public string ContactFood {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).EnterText(value); }
		}
		public string ContactVacation {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).EnterText(value); }
		}

		public string ContactIdentityPassword {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).EnterText(value); }
		}

		public string Country {
			get
			{
				var countrySelect = this.containerElement.FindElement(By.XPath(".//select[@id='Countries']"), 2);
				return countrySelect.SelectedOption();
			}
			set
			{
				var countrySelect = this.containerElement.FindElement(By.XPath(".//select[@id='Countries']"), 2);
				countrySelect.Select(value);
			}
		}

		public string PhoneNumber {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtPhone']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtPhone']"), 2).EnterText(value); }
		}

		public string EmergencyPhoneNumber {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtEmergencyPhone']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtEmergencyPhone']"), 2).EnterText(value); }
		}

		public string Fax {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtFax']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtFax']"), 2).EnterText(value); }
		}

		public bool AcceptTermsOfUse {
			get { return this.containerElement.FindElement(By.XPath(".//*[@id='Accepted']"), 2).Checked(); }
			set
			{
				var chkAccepted = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//*[@id='Accepted']"), 2);
				chkAccepted.Check(value);
			}
		}

		public bool ClickLogin()
		{
			var loginButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdLogIn']"));
			if (loginButton != null)
			{
				return loginButton.TryClick();
			}

			return false;
		}

		public bool ClickContinue()
		{
			Delay.Seconds(1);
			var continueButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//*[@type='submit']"));
			if (continueButton != null)
			{
				return continueButton.TryClick();
			}

			return false;
		}

		public bool ClickCongratulationsLogin()
		{
			var loginButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//button[@id='cmdSupplierLogin']"));
			if (loginButton != null)
			{
				return loginButton.TryClick();
			}

			return false;
		}

		public bool ClickCreateCompanyAccount()
		{
			var listOfAs = this.containerElement.FindElements(By.XPath(".//a"));

			var createCompanyLink = listOfAs.FirstOrDefault(x => x.Text.Contains("Create Company Account"));
			if (createCompanyLink != null)
			{
				return createCompanyLink.TryClick();
			}

			return false;
		}



		public bool ClickSignIn()
		{
			var signInLink = this.containerElement.FindElement(By.XPath(".//a[@id='loginLink']"));

			if (signInLink != null)
			{
				return signInLink.TryClick();
			}
			return false;
		}

		public bool ClickNext()
		{
			var nextButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdNext']"));

			if (nextButton != null)
			{
				return nextButton.TryClick();
			}
			return false;
		}

		public bool ClickBack()
		{
			var backButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdBack']"));

			if (backButton != null)
			{
				return backButton.TryClick();
			}
			return false;
		}

		public bool ClickCancel()
		{
			var cancelButton = this.containerElement.FindElement(By.XPath(".//input[@id='cmdCancel']"));

			if (cancelButton != null)
			{
				return cancelButton.TryClick();
			}
			return false;
		}

		public bool ClickVerify()
		{
			Delay.Seconds(1);
			var verifyButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//*[@id='cmdVerify']"));

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
				var CompanyNameField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='txtCompanyName']"));

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
				var Contents = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@class='legends']")).FirstOrDefault(x => x.Text.Contains("Congratulations! You have successfully"));

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
					var VerificationField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//*[@id='VerificationCode']"));
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
					var AcceptedCheckField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='Accepted']"));

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
					var h1Dashboard = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//h1")).FirstOrDefault(x => x.Text.Contains("Dashboard"));

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
				var ContactNameField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='txtContactName']"));

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
				var emailField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='txtEmail']"));

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
			var username = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[contains(@class, 'username')]"), 2);
			if (username != null)
			{
				return username.Text;
			}

			return "";

		}

		public string GetEmailSignedIn()
		{
			var username = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//i[@class='fa fa-user']"), 2);
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

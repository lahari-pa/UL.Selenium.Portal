using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class NewUser : BaseObject
	{
		public const string BasePath = "//body[@class='login-body']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		[FindsBy(How = How.XPath, Using = "//input[@id='regFirstName']")]
		private IWebElement _iFirstName;

		[FindsBy(How = How.XPath, Using = "//input[@id='regPassword']")]
		private IWebElement _iPassword;

		[FindsBy(How = How.XPath, Using = "//input[@id='regConfirmPass']")]
		private IWebElement _iConfirmPassword;

		[FindsBy(How = How.XPath, Using = "//label[@for='regLastName']/../input")] private IWebElement _iLastName;

		[FindsBy(How = How.XPath, Using = "//input[@id='regAddress']")]
		private IWebElement _iAddress1;

		[FindsBy(How = How.XPath, Using = "//input[@id='regAddress2']")]
		private IWebElement _iAddress2;

		[FindsBy(How = How.XPath, Using = "//input[@id='regCity']")]
		private IWebElement _iCity;

		[FindsBy(How = How.XPath, Using = "//input[@id='regState']")]
		private IWebElement _iState;

		[FindsBy(How = How.XPath, Using = "//input[@id='ddState']")]
		private IWebElement _ddState;

		[FindsBy(How = How.XPath, Using = "//input[@id='regZip']")]
		private IWebElement _iZip;

		[FindsBy(How = How.XPath, Using = "//input[@id='regCompanyName']")]
		private IWebElement _iCompanyName;

		[FindsBy(How = How.XPath, Using = "//input[@id='regCompanyPhone']")]
		private IWebElement _iCompanyPhone;

		[FindsBy(How = How.XPath, Using = "//input[@id='txtCountryCode']")]
		private IWebElement _iCountryCode;

		[FindsBy(How = How.XPath, Using = "//input[@id='txtEmergencyPhone']")]
		private IWebElement _iEmergencyPhone;

		[FindsBy(How = How.XPath, Using = "//input[@id='ddSupplierType']")]
		private IWebElement _ddSupplierType;

		[FindsBy(How = How.XPath, Using = "//a[@id='carouselContinue']")]
		private IWebElement _btnContinue;

		[FindsBy(How = How.XPath, Using = "//a[@id='carouselCancel']")]
		private IWebElement _btnCancel;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer1']")]
		private IWebElement _iSecQ1;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint1']")]
		private IWebElement _iHintQ1;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer2']")]
		private IWebElement _iSecQ2;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint2']")]
		private IWebElement _iHintQ2;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
		private IWebElement _iSecQ3;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
		private IWebElement _iHintQ3;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
		private IWebElement _iSecQ4;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
		private IWebElement _iHintQ4;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
		private IWebElement _iSecQ5;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
		private IWebElement _iHintQ5;

		[FindsBy(How = How.XPath, Using = "//input[@id='secQuestionPassword']")]
		private IWebElement _iSecPassword;

		[FindsBy(How = How.XPath, Using = "//div[@class='item active']/h4")]
		private IWebElement _pageHeader;






		public string Country {
			get
			{
				var CountryDropDown = containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
				return CountryDropDown.GetValue();

			}
			set
			{
				Delay.Seconds(1);
				Select_Country(value);
				Report.Success("Entered country: " + value);
			}
		}
		public void Select_Country(string country)
		{

			var CountryDropDown = containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
			if (CountryDropDown == null)
			{ throw new Exception("Country drop down control could not be found!"); }

			CountryDropDown.Click();

			var SelectElement = CountryDropDown.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == country);
			if (SelectElement == null)
			{ throw new Exception("Country not present in container!"); }

			SelectElement.Click();
		}

		public string First_name {
			get { return _iFirstName.GetValue(); }
			set
			{
				_iFirstName.EnterText(value);
				Report.Success("Entered country: " + value);
			}
		}



		public string Last_name {
			get
			{
				return _iLastName.GetValue();
			}
			set
			{
				_iLastName.EnterText(value);
				Report.Success("Entered last name: " + value);
			}
		}

		public string Password {
			get
			{
				return _iPassword.GetValue();
			}
			set
			{
				_iPassword.EnterText(value);
				Report.Success("Entered password: " + value);
			}
		}

		public string ConfirmPassword {
			get
			{
				return _iConfirmPassword.GetValue();
			}
			set
			{
				_iConfirmPassword.EnterText(value);
				Report.Success("Entered confirm password: " + value);
			}
		}

		public string Address1 {
			get
			{
				return _iAddress1.GetValue();
			}
			set
			{
				_iAddress1.EnterText(value);
				Report.Success("Entered address line 1: " + value);
			}
		}

		public string Address2 {
			get
			{
				return _iAddress2.GetValue();
			}
			set
			{
				_iAddress2.EnterText(value);
				Report.Success("Entered address line 2: " + value);
			}
		}

		public string City {
			get
			{
				return _iCity.GetValue();
			}
			set
			{
				_iCity.EnterText(value);
				Report.Success("Entered city: " + value);
			}
		}

		public string State {
			get
			{
				return _iState.GetValue();
			}
			set
			{
				_iState.EnterText(value);
				Report.Success("Entered state: " + value);
			}
		}

		public string Zip {
			get
			{
				return _iZip.GetValue();
			}
			set
			{
				_iZip.EnterText(value);
				Report.Success("Entered zip: " + value);
			}
		}

		public string CompanyName {
			get
			{
				return _iCompanyName.GetValue();
			}
			set
			{
				_iCompanyName.EnterText(value);
				Report.Success("Entered company name: " + value);
			}
		}

		public string CompanyPhone {
			get
			{
				return _iCompanyPhone.GetValue();
			}
			set
			{
				_iCompanyPhone.EnterText(value);
				Report.Success("Entered company phone: " + value);
			}
		}

		public string CountryCode {
			get
			{
				var CountryCode = containerElement.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
				return CountryCode != null ? CountryCode.GetValue() : "";
			}
			set
			{
				var CountryCode = containerElement.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
				CountryCode.EnterText(value);
				Report.Success("Entered country code: " + value);
			}
		}

		public string EmergencyPhoneNumber {
			get
			{
				return _iEmergencyPhone.GetValue();
			}
			set
			{
				_iEmergencyPhone.EnterText(value);
				Report.Success("Entered emergency phone number: " + value);
			}
		}

		public void SelectSupplierType(string supplierType)
		{
			_ddSupplierType = containerElement.FindElement(By.XPath("//select[@id='ddSupplierType']"), 2);
			if (_ddSupplierType == null)
			{ throw new Exception("Supplier type control could not be found!"); }

			_ddSupplierType.ScrollElementIntoView();

			var SelectElement = _ddSupplierType.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == supplierType);
			if (SelectElement == null)
			{ throw new Exception("Supplier type was not present in container!"); }

			SelectElement.Click();
			Report.Success("Entered supplier type: " + supplierType);
		}

		public void SelectUSState(string usState)
		{
			_ddState = containerElement.FindElement(By.XPath("//select[@id='ddState']"));
			Report.Info("Beginning select US state: " + usState);
			if (_ddState == null)
			{ throw new Exception("US state drop down control could not be found!"); }

			var SelectElement = _ddState.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == usState);
			if (SelectElement == null)
			{ throw new Exception("US State was not present in container!"); }

			SelectElement.Click();
			Report.Success("Selected US State: " + usState);
		}

		public bool ClickContinue()
		{
			try
			{
				_btnContinue.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void ClickCancel()
		{
			_btnCancel.Click();
		}

		public string CurrentPageTitle()
		{
			var HeaderTitle = containerElement.FindElement(By.XPath("//div[@class='item active']/h4"), 2);
			return HeaderTitle == null ? "" : HeaderTitle.Text;
		}

		public bool WaitForPageTitle(string waitingForTitle, int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				if (CurrentPageTitle() == waitingForTitle)
				{ return true; }
				i++;
				Delay.Seconds(1);
			}
			return false;
		}

		public void EnterQuestionAnswer(string number, string answer)
		{
			var el = containerElement.FindElement(By.XPath(".//input[@id='secAnswer" + number + "']"), 2);
			if (el != null)
			{ el.EnterText(answer); }
		}

		public void EnterQuestionHint(string number, string answer)
		{
			var el = containerElement.FindElement(By.XPath(".//input[@id='secHint" + number + "']"), 2);
			if (el != null)
			{ el.EnterText(answer); }
		}

		public string Pin {
			get { return containerElement.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).GetValue(); }
			set { containerElement.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).EnterText(value); }
		}

	}
}

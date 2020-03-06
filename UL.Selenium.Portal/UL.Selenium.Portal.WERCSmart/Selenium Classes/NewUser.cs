using System;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class NewUser : SeleniumBaseObject
	{
		public const string BasePath = "//body[@class='login-body']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		[FindsBy(How = How.XPath, Using = "//input[@id='regFirstName']")]
		private IWebElement _iFirstName;

		[FindsBy(How = How.XPath, Using = "//input[@id='regPassword']")]
		private IWebElement _iPassword;

		[FindsBy(How = How.XPath, Using = "//input[@id='regConfirmPass']")]
		private IWebElement _iConfirmPassword;

		[FindsBy(How = How.XPath, Using = "//label[@for='regLastName']/../input")]
		private IWebElement _iLastName;

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

		[FindsBy(How = How.XPath, Using = "//*[@id='question1Answer_error']")]
		private IWebElement _iSecE1;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint1']")]
		private IWebElement _iHintQ1;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer2']")]
		private IWebElement _iSecQ2;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint2']")]
		private IWebElement _iHintQ2;

		[FindsBy(How = How.XPath, Using = "//*[@id='question2Answer_error']")]
		private IWebElement _iSecE2;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
		private IWebElement _iSecQ3;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
		private IWebElement _iHintQ3;

		[FindsBy(How = How.XPath, Using = "//*[@id='question3Answer_error']")]
		private IWebElement _iSecE3;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer4']")]
		private IWebElement _iSecA4;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint4']")]
		private IWebElement _iHintQ4;

		[FindsBy(How = How.XPath, Using = "//*[@id='question4Answer_error']")]
		private IWebElement _iSecE4;

		[FindsBy(How = How.XPath, Using = "//input[@id='secAnswer5']")]
		private IWebElement _iSecQ5;

		[FindsBy(How = How.XPath, Using = "//input[@id='secHint5']")]
		private IWebElement _iHintQ5;

		[FindsBy(How = How.XPath, Using = "//input[@id='question5Answer_error']")]
		private IWebElement _iSecE5;

		[FindsBy(How = How.XPath, Using = "//input[@id='secQuestionPassword']")]
		private IWebElement _iSecPassword;

		[FindsBy(How = How.XPath, Using = "//div[@class='item active']/h4")]
		private IWebElement _pageHeader;

		[FindsBy(How = How.XPath, Using = "//p[@id='country_error']//span")]
		private IWebElement _countryError;

		[FindsBy(How = How.XPath, Using = "//p[@id='firstName_error']//span")]
		private IWebElement _firstNameError;

		[FindsBy(How = How.XPath, Using = "//p[@id='lastName_error']//span")]
		private IWebElement _lastNameError;

		[FindsBy(How = How.XPath, Using = "//p[@id='passwordError']//span")]
		private IWebElement _passwordError;

		[FindsBy(How = How.XPath, Using = "//p[@id='confirmPassword_error']//span")]
		private IWebElement _confirmPasswordError;

		[FindsBy(How = How.XPath, Using = "//p[@id='address_error']//span")]
		private IWebElement _address1Error;

		[FindsBy(How = How.XPath, Using = "//p[@id='city_error']//span")]
		private IWebElement _cityError;

		[FindsBy(How = How.XPath, Using = "//p[@id='state_error']//span")]
		private IWebElement _stateError;

		[FindsBy(How = How.XPath, Using = "//p[@id='zip_error']//span")]
		private IWebElement _zipError;

		[FindsBy(How = How.XPath, Using = "//p[@id='companyName_error']//span")]
		private IWebElement _companyNameError;

		[FindsBy(How = How.XPath, Using = "//p[@id='companyPhone_error']//span")]
		private IWebElement _companyPhoneError;

		[FindsBy(How = How.XPath, Using = "//p[@id='countryCode_error']//span")]
		private IWebElement _countryCodeError;

		[FindsBy(How = How.XPath, Using = "//p[@id='emergencyPhone_error']//span")]
		private IWebElement _emergencyPhoneError;

		[FindsBy(How = How.XPath, Using = "//p[@id='supplierType_error']//span")]
		private IWebElement _supplierTypeError;

		[FindsBy(How = How.XPath, Using = "//p[@id='cityBornInAnswer_error']//span")]
		private IWebElement _cityBornError;

		[FindsBy(How = How.XPath, Using = "//p[@id='firstCarModelAnswer_error']//span")]
		private IWebElement _firstCarModelError;

		[FindsBy(How = How.XPath, Using = "//p[@id='bestFriendAnswer_error']//span")]
		private IWebElement _bestFriendAnswerError;

		[FindsBy(How = How.XPath, Using = "//p[@id='firstJobCityAnswer_error']//span")]
		private IWebElement _firstJobCityAnswerError;

		[FindsBy(How = How.XPath, Using = "//p[@id='mascotAnswer_error']//span")]
		private IWebElement _mascotAnswerError;

		[FindsBy(How = How.XPath, Using = "//p[@id='password_error']//span")]
		private IWebElement _pINAnswerError;

		private IWebElement ClickNextButton => this.containerElement.FindElement(By.Id("carouselNext"),1);

		private IWebElement ClickSuccessButton => this.containerElement.FindElement(By.XPath(@".//a[contains(@class, 'btn-success')]"), 1);
		
		public string CountryErrorValue {
			get
			{
				if (this._countryError != null)
				{
					return this._countryError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string GetSecurityQuestionError(int i)
		{
			string xPath = "//*[@id='question" + i + "Answer_error']";
			IWebElement we = this.containerElement.FindElement(By.XPath(xPath), 2);
			return we?.GetValue();
		}

		public string FirstNameErrorValue {
			get
			{
				if (this._firstNameError != null)
				{
					return this._firstNameError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string LastNameErrorValue {
			get
			{
				if (this._lastNameError != null)
				{
					return this._lastNameError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string PasswordErrorValue {
			get
			{
				if (this._passwordError != null)
				{
					return this._passwordError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}
		public string ConfirmPasswordErrorValue {
			get
			{
				if (this._confirmPasswordError != null)
				{
					return this._confirmPasswordError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string Address1ErrorValue {
			get
			{
				if (this._address1Error != null)
				{
					return this._address1Error.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CityErrorValue {
			get
			{
				if (this._cityError != null)
				{
					return this._cityError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string StateErrorValue {
			get
			{
				if (this._stateError != null)
				{
					return this._stateError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string ZipErrorValue {
			get
			{
				if (this._zipError != null)
				{
					return this._zipError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CompanyErrorValue {
			get
			{
				if (this._companyNameError != null)
				{
					return this._companyNameError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CompanyPhoneErrorValue {
			get
			{
				if (this._companyPhoneError != null)
				{
					return this._companyPhoneError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CountryCodeErrorValue {
			get
			{
				if (this._countryCodeError != null)
				{
					return this._countryCodeError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string EmergencyPhoneNumberErrorValue {
			get
			{
				if (this._emergencyPhoneError != null)
				{
					return this._emergencyPhoneError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string SupplierTypeErrorValue {
			get
			{
				if (this._supplierTypeError != null)
				{
					return this._supplierTypeError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CityBornErrorValue {
			get
			{
				if (this._cityBornError != null)
				{
					return this._cityBornError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string FirstCarModelErrorValue {
			get
			{
				if (this._firstCarModelError != null)
				{
					return this._firstCarModelError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string BestFriendErrorValue {
			get
			{
				if (this._bestFriendAnswerError != null)
				{
					return this._bestFriendAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string FirstJobErrorValue {
			get
			{
				if (this._firstJobCityAnswerError != null)
				{
					return this._firstJobCityAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string HighSchoolMascotErrorValue {
			get
			{
				if (this._mascotAnswerError != null)
				{
					return this._mascotAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string PINErrorValue {
			get
			{
				if (this._pINAnswerError != null)
				{
					return this._pINAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string Country {
			get
			{
				IWebElement countryDropDown = this.containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
				return countryDropDown.GetValue();

			}
			set
			{
				this.Select_Country(value);
				Report.Success("Entered country: " + value);
			}
		}
		public void Select_Country(string country)
		{

			IWebElement countryDropDown = this.containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
			if (countryDropDown == null)
			{ throw new Exception("Country drop down control could not be found!"); }

			countryDropDown.Click();			
			
			IWebElement selectElement = countryDropDown.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == country);
			if (selectElement == null)
			{ throw new Exception("Country not present in container!"); }

			selectElement.Click();
		}

		public string FirstName {
			get => this._iFirstName.GetValue();
			set
			{
				this._iFirstName.EnterText(value);
				Report.Success("Entered country: " + value);
			}
		}



		public string LastName {
			get => this._iLastName.GetValue();
			set
			{
				this._iLastName.EnterText(value);
				Report.Success("Entered last name: " + value);
			}
		}

		public string Password {
			get => this._iPassword.GetValue();
			set
			{
				this._iPassword.EnterText(value);
				Report.Success("Entered password: " + value);
			}
		}

		public string ConfirmPassword {
			get => this._iConfirmPassword.GetValue();
			set
			{
				this._iConfirmPassword.EnterText(value);
				Report.Success("Entered confirm password: " + value);
			}
		}

		public string Address1 {
			get => this._iAddress1.GetValue();
			set
			{
				this._iAddress1.EnterText(value);
				Report.Success("Entered address line 1: " + value);
			}
		}

		public string Address2 {
			get => this._iAddress2.GetValue();
			set
			{
				this._iAddress2.EnterText(value);
				Report.Success("Entered address line 2: " + value);
			}
		}

		public string City {
			get => this._iCity.GetValue();
			set
			{
				this._iCity.EnterText(value);
				Report.Success("Entered city: " + value);
			}
		}

		public string State {
			get => this._iState.GetValue();
			set
			{
				this._iState.EnterText(value);
				Report.Success("Entered state: " + value);
			}
		}

		public string Zip {
			get => this._iZip.GetValue();
			set
			{
				this._iZip.EnterText(value);
				Report.Success("Entered zip: " + value);
			}
		}

		public string CompanyName {
			get => this._iCompanyName.GetValue();
			set
			{
				this._iCompanyName.EnterText(value);
				Report.Success("Entered company name: " + value);
			}
		}

		public string CompanyPhone {
			get => this._iCompanyPhone.GetValue();
			set
			{
				this._iCompanyPhone.EnterText(value);
				Report.Success("Entered company phone: " + value);
			}
		}

		public string CountryCode {
			get
			{
				IWebElement countryCode = this.containerElement.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
				return countryCode != null ? countryCode.GetValue() : "";
			}
			set
			{
				IWebElement countryCode = this.containerElement.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
				countryCode.EnterText(value);
				Report.Success("Entered country code: " + value);
			}
		}

		public string EmergencyPhoneNumber {
			get => this._iEmergencyPhone.GetValue();
			set
			{
				this._iEmergencyPhone.EnterText(value);
				Report.Success("Entered emergency phone number: " + value);
			}
		}

		public void SelectSupplierType(string supplierType)
		{
			IWebElement ddSupplierType = this.containerElement.FindElement(By.XPath("//select[@id='ddSupplierType']"), 2);
			if (ddSupplierType == null)
			{
				throw new Exception("Supplier type control could not be found!");
			}

			ddSupplierType.ScrollElementIntoView();

			IWebElement selectElement = ddSupplierType.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == supplierType);
			if (selectElement == null)
			{ throw new Exception("Supplier type was not present in container!"); }

			selectElement.Click();
			Report.Success("Entered supplier type: " + supplierType);
		}

		public void SelectUsState(string usState)
		{
			this._ddState = this.containerElement.FindElement(By.XPath("//select[@id='ddState']"));
			Report.Info("Beginning select US state: " + usState);
			if (this._ddState == null)
			{ throw new Exception("US state drop down control could not be found!"); }

			IWebElement selectElement = this._ddState.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == usState);
			if (selectElement == null)
			{ throw new Exception("US State was not present in container!"); }

			selectElement.Click();
			Report.Success("Selected US State: " + usState);
		}

		public bool ClickContinue()
		{
			try
			{
				this._btnContinue.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickNext()
		{
			return this.ClickNextButton.TryClick();
		}
		public bool ClickSuccess()
		{
			return this.ClickSuccessButton.TryClick();
		}
		public void ClickCancel()
		{
			this._btnCancel.Click();
		}

		public bool ThankYou()
		{
			return this.containerElement.WaitUntilElementVisible(By.XPath(".//h3[text()='Thank You']"), 5) != null;
		}

		public string CurrentPageTitle()
		{
			IWebElement headerTitle = this.containerElement.FindElement(By.XPath("//div[@class='item active']/h4"), 2);
			return headerTitle == null ? "" : headerTitle.Text;
		}

		public bool WaitForPageTitle(string waitingForTitle, int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				if (this.CurrentPageTitle() == waitingForTitle)
				{ return true; }
				i++;
				Delay.Seconds(1);
			}
			return false;
		}

		public void EnterQuestionAnswer(string number, string answer)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@id='secAnswer" + number + "']"), 2);
			if (el != null)
			{ el.EnterText(answer); }
		}

		public void EnterQuestionHint(string number, string answer)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@id='secHint" + number + "']"), 2);
			if (el != null)
			{ el.EnterText(answer); }
		}

		public string Pin {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).GetValue();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).EnterText(value);
		}

	}
}

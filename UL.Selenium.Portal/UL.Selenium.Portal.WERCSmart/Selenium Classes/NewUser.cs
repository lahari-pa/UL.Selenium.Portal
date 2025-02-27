using OpenQA.Selenium;
using System;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class NewUser : SeleniumBaseObject
	{
		public const string BasePath = "//body[@class='login-body']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		private IWebElement IFirstName => this.FindElement(By.XPath(".//input[@id='regFirstName']"), 1);
		private IWebElement IPassword => this.FindElement(By.XPath(".//input[@id='regPassword']"), 1);
		private IWebElement IConfirmPassword => this.FindElement(By.XPath(".//input[@id='regConfirmPass']"), 1);
		private IWebElement ILastName => this.FindElement(By.XPath(".//label[@for='regLastName']/../input"), 1);
		private IWebElement IAddress1 => this.FindElement(By.XPath(".//input[@id='regAddress']"), 1);
		private IWebElement IAddress2 => this.FindElement(By.XPath(".//input[@id='regAddress2']"), 1);
		private IWebElement ICity => this.FindElement(By.XPath(".//input[@id='regCity']"), 1);
		private IWebElement IState => this.FindElement(By.XPath(".//input[@id='regState']"), 1);
		private IWebElement DdState => this.FindElement(By.XPath(".//input[@id='ddState']"), 1);
		private IWebElement IZip => this.FindElement(By.XPath(".//input[@id='regZip']"), 1);
		private IWebElement ICompanyName => this.FindElement(By.XPath(".//input[@id='regCompanyName']"), 1);
		private IWebElement ICompanyPhone => this.FindElement(By.XPath(".//input[@id='regCompanyPhone']"), 1);
		private IWebElement ICountryCode => this.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 1);
		private IWebElement IEmergencyPhone => this.FindElement(By.XPath(".//input[@id='txtEmergencyPhone']"), 1);
		private IWebElement DdSupplierType => this.FindElement(By.XPath(".//input[@id='ddSupplierType']"), 1);
		private IWebElement BtnContinue => this.FindElement(By.XPath(".//a[@id='carouselContinue']"), 1);
		private IWebElement BtnCancel => this.FindElement(By.XPath(".//a[@id='carouselCancel']"), 1);
		private IWebElement ISecQ1 => this.FindElement(By.XPath(".//input[@id='secAnswer1']"), 1);
		private IWebElement ISecE1 => this.FindElement(By.XPath(".//*[@id='question1Answer_error']"), 1);
		private IWebElement IHintQ1 => this.FindElement(By.XPath(".//input[@id='secHint1']"), 1);
		private IWebElement ISecQ2 => this.FindElement(By.XPath(".//input[@id='secAnswer2']"), 1);
		private IWebElement IHintQ2 => this.FindElement(By.XPath(".//input[@id='secHint2']"), 1);
		private IWebElement ISecE2 => this.FindElement(By.XPath(".//*[@id='question2Answer_error']"), 1);
		private IWebElement ISecQ3 => this.FindElement(By.XPath(".//input[@id='secAnswer3']"), 1);
		private IWebElement IHintQ3 => this.FindElement(By.XPath(".//input[@id='secHint3']"), 1);
		private IWebElement ISecE3 => this.FindElement(By.XPath(".//*[@id='question3Answer_error']"), 1);
		private IWebElement ISecA4 => this.FindElement(By.XPath(".//input[@id='secAnswer4']"), 1);
		private IWebElement IHintQ4 => this.FindElement(By.XPath(".//input[@id='secHint4']"), 1);
		private IWebElement ISecE4 => this.FindElement(By.XPath(".//*[@id='question4Answer_error']"), 1);
		private IWebElement ISecQ5 => this.FindElement(By.XPath(".//input[@id='secAnswer5']"), 1);
		private IWebElement IHintQ5 => this.FindElement(By.XPath(".//input[@id='secHint5']"), 1);
		private IWebElement ISecE5 => this.FindElement(By.XPath(".//input[@id='question5Answer_error']"), 1);
		private IWebElement ISecPassword => this.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 1);
		private IWebElement PageHeader => this.FindElement(By.XPath(".//div[@class='item active']/h4"), 1);
		private IWebElement CountryError => this.FindElement(By.XPath(".//p[@id='country_error']//span"), 1);
		private IWebElement FirstNameError => this.FindElement(By.XPath(".//p[@id='firstName_error']//span"), 1);
		private IWebElement LastNameError => this.FindElement(By.XPath(".//p[@id='lastName_error']//span"), 1);
		private IWebElement PasswordError => this.FindElement(By.XPath(".//p[@id='passwordError']//span"), 1);
		private IWebElement ConfirmPasswordError => this.FindElement(By.XPath(".//p[@id='confirmPassword_error']//span"), 1);
		private IWebElement Address1Error => this.FindElement(By.XPath(".//p[@id='address_error']//span"), 1);
		private IWebElement CityError => this.FindElement(By.XPath(".//p[@id='city_error']//span"), 1);
		private IWebElement StateError => this.FindElement(By.XPath(".//p[@id='state_error']//span"), 1);
		private IWebElement ZipError => this.FindElement(By.XPath(".//p[@id='zip_error']//span"), 1);
		private IWebElement CompanyNameError => this.FindElement(By.XPath(".//p[@id='companyName_error']//span"), 1);
		private IWebElement CompanyPhoneError => this.FindElement(By.XPath(".//p[@id='companyPhone_error']//span"), 1);
		private IWebElement CountryCodeError => this.FindElement(By.XPath(".//p[@id='countryCode_error']//span"), 1);
		private IWebElement EmergencyPhoneError => this.FindElement(By.XPath(".//p[@id='emergencyPhone_error']//span"), 1);
		private IWebElement SupplierTypeError => this.FindElement(By.XPath(".//p[@id='supplierType_error']//span"), 1);
		private IWebElement CityBornError => this.FindElement(By.XPath(".//p[@id='cityBornInAnswer_error']//span"), 1);
		private IWebElement FirstCarModelError => this.FindElement(By.XPath(".//p[@id='firstCarModelAnswer_error']//span"), 1);
		private IWebElement BestFriendAnswerError => this.FindElement(By.XPath(".//p[@id='bestFriendAnswer_error']//span"), 1);
		private IWebElement FirstJobCityAnswerError => this.FindElement(By.XPath(".//p[@id='firstJobCityAnswer_error']//span"), 1);
		private IWebElement MascotAnswerError => this.FindElement(By.XPath(".//p[@id='mascotAnswer_error']//span"), 1);
		private IWebElement PINAnswerError => this.FindElement(By.XPath(".//p[@id='password_error']//span"), 1);

		private IWebElement ClickNextButton => this.FindElement(By.Id("carouselNext"), 1);

		public IWebElement ClickSuccessButton => this.FindElement(By.XPath(@".//a[contains(@class, 'btn-success')]"), 1);


		public string CountryErrorValue
		{
			get
			{
				if (this.CountryError != null)
				{
					return this.CountryError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string GetSecurityQuestionError(int i)
		{
			string xPath = $"//*[@id='question{i}Answer_error']";
			IWebElement we = this.FindElement(By.XPath(xPath), 2);
			return we?.GetValue();
		}

		public string FirstNameErrorValue
		{
			get
			{
				if (this.FirstNameError != null)
				{
					return this.FirstNameError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string LastNameErrorValue
		{
			get
			{
				if (this.LastNameError != null)
				{
					return this.LastNameError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string PasswordErrorValue
		{
			get
			{
				if (this.PasswordError != null)
				{
					return this.PasswordError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}
		public string ConfirmPasswordErrorValue
		{
			get
			{
				if (this.ConfirmPasswordError != null)
				{
					return this.ConfirmPasswordError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string Address1ErrorValue
		{
			get
			{
				if (this.Address1Error != null)
				{
					return this.Address1Error.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CityErrorValue
		{
			get
			{
				if (this.CityError != null)
				{
					return this.CityError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string StateErrorValue
		{
			get
			{
				if (this.StateError != null)
				{
					return this.StateError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string ZipErrorValue
		{
			get
			{
				if (this.ZipError != null)
				{
					return this.ZipError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CompanyErrorValue
		{
			get
			{
				if (this.CompanyNameError != null)
				{
					return this.CompanyNameError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CompanyPhoneErrorValue
		{
			get
			{
				if (this.CompanyPhoneError != null)
				{
					return this.CompanyPhoneError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CountryCodeErrorValue
		{
			get
			{
				if (this.CountryCodeError != null)
				{
					return this.CountryCodeError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string EmergencyPhoneNumberErrorValue
		{
			get
			{
				if (this.EmergencyPhoneError != null)
				{
					return this.EmergencyPhoneError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string SupplierTypeErrorValue
		{
			get
			{
				if (this.SupplierTypeError != null)
				{
					return this.SupplierTypeError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string CityBornErrorValue
		{
			get
			{
				if (this.CityBornError != null)
				{
					return this.CityBornError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string FirstCarModelErrorValue
		{
			get
			{
				if (this.FirstCarModelError != null)
				{
					return this.FirstCarModelError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string BestFriendErrorValue
		{
			get
			{
				if (this.BestFriendAnswerError != null)
				{
					return this.BestFriendAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string FirstJobErrorValue
		{
			get
			{
				if (this.FirstJobCityAnswerError != null)
				{
					return this.FirstJobCityAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string HighSchoolMascotErrorValue
		{
			get
			{
				if (this.MascotAnswerError != null)
				{
					return this.MascotAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string PINErrorValue
		{
			get
			{
				if (this.PINAnswerError != null)
				{
					return this.PINAnswerError.GetValue();
				}
				else
				{
					return "";
				}
			}
		}

		public string Country
		{
			get
			{
				IWebElement countryDropDown = this.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
				return countryDropDown.GetValue();

			}
			set
			{
				this.Select_Country(value);
				Report.Success($"Entered country: {value}");
			}
		}
		public void Select_Country(string country)
		{

			IWebElement countryDropDown = this.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
			if (countryDropDown == null)
			{ throw new Exception("Country drop down control could not be found!"); }

			countryDropDown.Click();

			IWebElement selectElement = countryDropDown.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == country);
			if (selectElement == null)
			{ throw new Exception("Country not present in container!"); }

			selectElement.Click();
		}

		public string FirstName
		{
			get => this.IFirstName.GetValue();
			set
			{
				this.IFirstName.EnterText(value);
				Report.Success($"Entered country: {value}");
			}
		}



		public string LastName
		{
			get => this.ILastName.GetValue();
			set
			{
				this.ILastName.EnterText(value);
				Report.Success($"Entered last name: {value}");
			}
		}

		public string Password
		{
			get => this.IPassword.GetValue();
			set
			{
				this.IPassword.EnterText(value);
				Report.Success("Entered password: *******");
			}
		}

		public string ConfirmPassword
		{
			get => this.IConfirmPassword.GetValue();
			set
			{
				this.IConfirmPassword.EnterText(value);
				Report.Success("Entered confirm password: *******");
			}
		}

		public string Address1
		{
			get => this.IAddress1.GetValue();
			set
			{
				this.IAddress1.EnterText(value);
				Report.Success($"Entered address line 1: {value}");
			}
		}

		public string Address2
		{
			get => this.IAddress2.GetValue();
			set
			{
				this.IAddress2.EnterText(value);
				Report.Success($"Entered address line 2: {value}");
			}
		}

		public string City
		{
			get => this.ICity.GetValue();
			set
			{
				this.ICity.EnterText(value);
				Report.Success($"Entered city: {value}");
			}
		}

		public string State
		{
			get => this.IState.GetValue();
			set
			{
				this.IState.EnterText(value);
				Report.Success($"Entered state: {value}");
			}
		}

		public string Zip
		{
			get => this.IZip.GetValue();
			set
			{
				this.IZip.EnterText(value);
				Report.Success($"Entered zip: {value}");
			}
		}

		public string CompanyName
		{
			get => this.ICompanyName.GetValue();
			set
			{
				this.ICompanyName.EnterText(value);
				Report.Success($"Entered company name: {value}");
			}
		}

		public string CompanyPhone
		{
			get => this.ICompanyPhone.GetValue();
			set
			{
				this.ICompanyPhone.EnterText(value);
				Report.Success($"Entered company phone: {value}");
			}
		}

		public string CountryCode
		{
			get
			{
				IWebElement countryCode = this.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
				return countryCode != null ? countryCode.GetValue() : "";
			}
			set
			{
				IWebElement countryCode = this.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
				countryCode.EnterText(value);
				Report.Success($"Entered country code: {value}");
			}
		}

		public string EmergencyPhoneNumber
		{
			get => this.IEmergencyPhone.GetValue();
			set
			{
				this.IEmergencyPhone.EnterText(value);
				Report.Success($"Entered emergency phone number: {value}");
			}
		}

		public void SelectSupplierType(string supplierType)
		{
			IWebElement ddSupplierType = this.FindElement(By.XPath("//select[@id='ddSupplierType']"), 2);
			if (ddSupplierType == null)
			{
				throw new Exception("Supplier type control could not be found!");
			}

			ddSupplierType.ScrollElementIntoView();

			IWebElement selectElement = ddSupplierType.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == supplierType);
			if (selectElement == null)
			{ throw new Exception("Supplier type was not present in container!"); }

			selectElement.Click();
			Report.Success($"Entered supplier type: {supplierType}");
		}

		public void SelectUsState(string usState)
		{
			//this._dState = this.containerElement.FindElement(By.XPath("//select[@id='ddState']"));
			IWebElement dState = this.FindElement(By.XPath(".//select[@id='ddState']"));
			Report.Info("Beginning select US state: " + usState);
			if (dState == null)
			{ throw new Exception("US state drop down control could not be found!"); }

			IWebElement selectElement = dState.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == usState);
			if (selectElement == null)
			{ throw new Exception("US State was not present in container!"); }

			selectElement.Click();
			Report.Success($"Selected US State: {usState}");
		}

		public bool ClickContinue()
		{
			try
			{
				this.BtnContinue.Click();
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
			this.BtnCancel.Click();
		}

		public bool ThankYou()
		{
			return this.containerElement.WaitUntilElementVisible(By.XPath(".//h3[text()='Thank You']"), 5) != null;
		}

		public string CurrentPageTitle()
		{
			IWebElement headerTitle = this.FindElement(By.XPath("//div[@class='item active']/h4"), 2);
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
			IWebElement el = this.FindElement(By.XPath($".//input[@id='secAnswer{number}']"), 2);
			if (el != null)
			{ el.EnterText(answer); }
		}

		public void EnterQuestionHint(string number, string answer)
		{
			IWebElement el = this.FindElement(By.XPath($".//input[@id='secHint{number}']"), 2);
			if (el != null)
			{ el.EnterText(answer); }
		}

		public string Pin
		{
			get => this.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).GetValue();
			set => this.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).TryEnterTextAndTab(value);
		}

		public bool ClickPinBox()
		{
			var el = this.FindElement(By.XPath(".//input[@id='secQuestionPassword']"));
			if (el == null)
			{
				Report.Info($"el was null");
				return false;

			}
			return el.TryClick();
		}
	}
}

using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class ChooseGoodGuide_AccountCreation : ConflictMinerals
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//div[@class='container-fluid']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickCreateCompanyAccount =>
			this.containerElement.FindElement(By.XPath(".//a[text()='Create Company Account']"), 2).TryClick();

		public string Email {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).GetValue();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).EnterText(value);
		}

		public bool ClickNext =>
			this.containerElement.FindElement(By.XPath(".//input[@id='cmdNext']"), 2).TryClick();

		public new bool ClickCancel => this.containerElement.FindElement(By.XPath(".//input[@id='cmdCancel']"), 2).TryClick();

		public string WhatCityWereYouBornIn {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer1']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer1']"), 2).EnterText(value); }
		}

		public string WhatWasTheModelOfYourFirstCar {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer2']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer2']"), 2).EnterText(value); }
		}

		public string WhatIsYourFavouriteSport {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer3']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer3']"), 2).EnterText(value); }
		}
		public string WhatIsYourFavouriteFoodOrDrink {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).EnterText(value);
		}

		public string WhatIsYourFavouriteVacationDestination {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).EnterText(value);
		}

		public string EnterSecurePassword {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).Text.Trim();
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).EnterText(value);
		}
	}
}

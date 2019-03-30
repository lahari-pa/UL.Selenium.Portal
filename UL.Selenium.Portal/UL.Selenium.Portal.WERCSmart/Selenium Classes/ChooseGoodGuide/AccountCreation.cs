using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes.ChooseGoodGuide
{
	class ChooseGoodGuide_AccountCreation : ConflictMinerals
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//div[@class='container-fluid']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickCreateCompanyAccount()
		{
			return containerElement.FindElement(By.XPath(".//a[text()='Create Company Account']"), 2).TryClick();
		}

		public string Email {
			get { return containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).GetValue(); }
			set { containerElement.FindElement(By.XPath(".//input[@id='txtEmail']"), 2).EnterText(value); }
		}

		public bool ClickNext()
		{
			return containerElement.FindElement(By.XPath(".//input[@id='cmdNext']"), 2).TryClick();
		}

		public bool ClickCancel()
		{
			return containerElement.FindElement(By.XPath(".//input[@id='cmdCancel']"), 2).TryClick();
		}

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
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer4']"), 2).EnterText(value); }
		}

		public string WhatIsYourFavouriteVacationDestination {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtAnswer5']"), 2).EnterText(value); }
		}

		public string EnterSecurePassword {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtPhonePassword']"), 2).EnterText(value); }
		}
	}
}

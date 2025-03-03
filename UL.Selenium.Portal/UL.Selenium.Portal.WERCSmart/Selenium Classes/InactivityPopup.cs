using OpenQA.Selenium;
using System;
using System.Diagnostics;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class InactivityPopup : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='LogOutModal']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		private IWebElement YesButton => this.containerElement.FindElement(By.XPath($@".//button[text() = ""Yes""]"), 1);

		private IWebElement NoButton => this.containerElement.FindElement(By.XPath(@".//a[@class= 'btn btn-default' and text() = ""No""]"), 1);

		public bool IsVisible()
		{
			//this.containerElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(BasePath), 2);
			return this.containerElement.GetAttribute("class") != "modal fade";
		}

		public bool ClickYes() => this.YesButton.TryClick();

		public bool ClickNo() => this.NoButton.TryClick();


		public bool WaitUntilDisplayed(int timeout, out int secondsWaited)
		{
			var timer = new Stopwatch();
			timer.Start();
			bool res = this.WaitForContainerToBeVisible(timeout);
			timer.Stop();
			secondsWaited = Convert.ToInt32(timer.Elapsed.TotalSeconds);
			return res;
		}

	}
}

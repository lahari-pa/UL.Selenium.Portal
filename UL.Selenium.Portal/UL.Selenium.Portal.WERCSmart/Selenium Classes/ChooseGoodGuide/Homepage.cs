using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class ChooseGoodGuide_Homepage : SeleniumBaseObject
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//body";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		protected IWebElement PaceProgress => this.containerElement.FindElement(By.XPath(".//div[@class='pace-progress']"));
		public bool ClickGetStarted()
		{
			return this.containerElement.FindElement(By.XPath(".//a[text()='Get Started NOW']"), 2).TryClick();
		}

		public string GetPaceProgress()
		{
			return this.PaceProgress.GetAttribute("data-progress-text");
		}
		public bool GetPaceProgressExists()
		{
			return this.PaceProgress != null;
		}
		public void WaitLoading()
		{
			if (!this.GetPaceProgressExists())
			{
				Report.Info("Cannot get Pace Progress line");
				Delay.Seconds(1);
			}
			int timeoutCounter = 0;
			string currentPaceProgress = this.GetPaceProgress();
			while (currentPaceProgress != "100%" && timeoutCounter < 120)
			{

				Delay.Seconds(Delay.SpeedFactor);
				currentPaceProgress = this.GetPaceProgress();
				timeoutCounter++;
				Report.Info($"Waiting for loading bar. current pace progress: {currentPaceProgress} | seconds waited: {timeoutCounter}"); 
			}
			if (timeoutCounter == 120)
			{
				Report.Error("Failed to load page or data within 2 minutes");
			}
		}
	}
}

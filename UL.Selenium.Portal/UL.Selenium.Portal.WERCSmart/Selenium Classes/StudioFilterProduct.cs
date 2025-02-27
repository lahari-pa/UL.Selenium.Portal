using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioFilterProduct : BaseObject
	{
		public const string BasePath = "//form[@id='Form1']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			ReadOnlyCollection<string> urls = SeleniumWebDriver.CurrentDriver.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumWebDriver.CurrentDriver.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			string current = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Context.AddToContext("BaseWindow", current);

			foreach (string handle in urls)
			{
				if (SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Title.Contains("Select product"))
				{
					SeleniumWebDriver.CurrentDriver.Manage().Window.Maximize();
					Report.Success("Found window containing title: Select product");
					Report.Screenshot();
					break;
				}
			}

			IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe"));
			SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
			this.containerElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}

		public bool ClickFilterButton()
		{
			IWebElement button = this.containerElement.FindElement(By.XPath(".//a[@id='srAliases_lnkFilter']"));
			return button.TryClick();
		}

		public bool SelectItemInResults()
		{
			ReadOnlyCollection<IWebElement> rows = this.containerElement.FindElements(By.XPath(
				".//table[@id='srAliases_tblSelectRecord']/tbody/tr[not(@id='srAliases_rowTitle') and not(@id='srAliases_rowHeader')]"));

			return true;
		}
	}
}

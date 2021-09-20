using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.SpecFlow.Classes;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioFilterProduct : BaseObject
	{
		public const string BasePath = "//form[@id='Form1']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
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

			string current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("BaseWindow", current);

			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Select product"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Select product");
					Report.Screenshot();
					break;
				}
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
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

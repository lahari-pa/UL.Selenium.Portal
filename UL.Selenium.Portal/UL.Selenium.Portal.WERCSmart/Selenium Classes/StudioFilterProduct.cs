using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioFilterProduct : BaseObject
	{
		public const string BasePath = "//form[@id='Form1']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
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

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("BaseWindow", current);

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Select product"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Select product");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}

		public bool ClickFilterButton()
		{
			var button = this.containerElement.FindElement(By.XPath(".//a[@id='srAliases_lnkFilter']"));
			return button.TryClick();
		}

		public bool SelectItemInResults()
		{
			var rows = this.containerElement.FindElements(By.XPath(
				".//table[@id='srAliases_tblSelectRecord']/tbody/tr[not(@id='srAliases_rowTitle') and not(@id='srAliases_rowHeader')]"));

			return true;
		}
	}
}

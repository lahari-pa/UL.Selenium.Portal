using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text.pdf.parser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class StudioProductAttributeScreen : BaseObject
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
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Product Attribute Screen"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Product Attribute Screen");
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
			var button = containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_imgFilter']"));
			return button.TryClick();
		}

		public bool ResultsAreFound()
		{
			var codeTDsFindElements = containerElement.FindElements(By.XPath(
				".//table[@id='AttributesGrid_tblSelectRecord']/tbody/tr[not(@id='AttributesGrid_rowHeader') and not(@id='AttributesGrid_rowTitle')]//tr[not(contains(@class, 'FixedHeader'))]/td[1]"));
			return codeTDsFindElements.Count > 0;
		}

		public bool SelectItemByCode(string Code)
		{
			var codeTDsFindElements = containerElement.FindElements(By.XPath(
				".//table[@id='AttributesGrid_tblSelectRecord']/tbody/tr[not(@id='AttributesGrid_rowHeader') and not(@id='AttributesGrid_rowTitle')]//tr[not(contains(@class, 'FixedHeader'))]/td[1]"));

			var matchingTD = codeTDsFindElements.FirstOrDefault(x => x.GetValue() == Code);
			if (matchingTD == null)
			{
				Report.Info("Could not find matching item for: " + Code);
				return false;
			}

			return matchingTD.TryClick();
		}

		public List<string> GetDataText()
		{
			List<string> returnList= new List<string>();
			var dataAreaSelect = containerElement.FindElement(By.XPath(".//select[@id='lbData']"),2);

			if(dataAreaSelect==null)
			{
				Report.Info("Could not find data area values");
			}
			else
			{
				var options = dataAreaSelect.FindElements(By.XPath(".//option"));
				if (options == null)
				{
					Report.Info("Found data area but could not find data area values");
				}
				else
				{
					returnList = options.Select(x => x.GetValue()).ToList();
				}
			}

			return returnList;
		}
	}
}

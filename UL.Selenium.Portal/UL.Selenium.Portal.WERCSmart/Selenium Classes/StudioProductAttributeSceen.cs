using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioProductAttributeScreen : BaseObject
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
				if (SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Title.Contains("Product Attribute Screen"))
				{
					SeleniumWebDriver.CurrentDriver.Manage().Window.Maximize();
					Report.Success("Found window containing title: Product Attribute Screen");
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
			IWebElement button = this.containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_imgFilter']"));
			return button.TryClick();
		}

		public bool ResultsAreFound()
		{
			Delay.Seconds(1);
			ReadOnlyCollection<IWebElement> codeTDsFindElements = this.containerElement.FindElements(By.XPath(
				".//table[@id='AttributesGrid_tblSelectRecord']/tbody/tr[not(@id='AttributesGrid_rowHeader') and not(@id='AttributesGrid_rowTitle')]//tr[not(contains(@class, 'FixedHeader'))]/td[1]"));
			return codeTDsFindElements.Count > 0;
		}

		public bool SelectItemByCode(string code)
		{
			ReadOnlyCollection<IWebElement> codeTDsFindElements = this.containerElement.FindElements(By.XPath(
				".//table[@id='AttributesGrid_tblSelectRecord']/tbody/tr[not(@id='AttributesGrid_rowHeader') and not(@id='AttributesGrid_rowTitle')]//tr[not(contains(@class, 'FixedHeader'))]/td[1]"));

			IWebElement matchingTD = codeTDsFindElements.FirstOrDefault(x => x.GetValue() == code);
			if (matchingTD == null)
			{
				Report.Info("Could not find matching item for: " + code);
				return false;
			}

			return matchingTD.TryClick();
		}

		public List<string> GetDataText()
		{
			var returnList = new List<string>();
			IWebElement dataAreaSelect = this.containerElement.FindElement(By.XPath(".//select[@id='lbData']"), 2);

			if (dataAreaSelect == null)
			{
				Report.Info("Could not find data area values");
			}
			else
			{
				ReadOnlyCollection<IWebElement> options = dataAreaSelect.FindElements(By.XPath(".//option"));
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

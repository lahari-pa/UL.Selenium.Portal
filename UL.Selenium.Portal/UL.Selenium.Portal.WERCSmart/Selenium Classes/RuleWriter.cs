using OpenQA.Selenium;
//using OpenQA.Selenium.DevTools.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class RuleWriter : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[//div[@id='Widget1HEA' and contains(text(),'Rule Writer')]]");

		private string _buttonString;

		private IWebElement Button => ContainerElement.FindElement(By.XPath($"//body[//div[@id='Widget1HEA' and contains(text(),'Rule Writer')]]//div[@class='widgetStyleContents']//iframe[@id='Widget1FRAME']"), 2);

		public bool ClickButton(string buttonName)
		{
			_buttonString = buttonName;
			if (Button == null)
			{
				Report.Error($"Could not find a button with the name {buttonName}");
				return false;
			}
			return Button.TryClick();
		}

		public bool ClickAllRulesButton()
		{
			//switch to iframe needed or? revert go back to parent needed?
			
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("Widget1FRAME");
			IWebElement el= SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//input[@type='button' and @title='All Rules']"), 10);
			if (el == null)
			{
				Report.Error($"Could not find a button with the name All Rules");
				return false;
			}
			return el.TryClick();

		}
	}
}

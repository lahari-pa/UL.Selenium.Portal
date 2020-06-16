using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	class WebElements : SeleniumBaseObject
	{

		public const string BasePath = "";

		protected override By ContainerElementLocator => throw new System.NotImplementedException();

		public bool ConfirmOptionIsCheckedInSection(string option, string section)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[text()='" + section + "']/../following-sibling::div//span[text()='" + option + "']/preceding-sibling::input"), 2);
			if (optionEl.Checked())
			{
				return true;
			}

			return false;
		}

		public bool ConfirmSectionIsAvailableForSelection(string sectionName)
		{
			IList <IWebElement> options = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//label[text()=\"" + sectionName + "\"]/../following-sibling::div//div[@data-toggle='buttons']//input"), 2);

			if (options.Count != 2)
			{
				Report.Info("The amount of options found were not as expected");
				return false;
			}

			foreach (IWebElement el in options)
			{
				if ((el.Text.ToLower() != "no") && (el.Text.ToLower() != "yes"))
				{
					Report.Info("An option with an unexpected name was found");
					return false;
				}

				if (!el.TryClick())
				{
					Report.Info("At least one option was not clickable");
					return false;
				}

			}

			return true;
		}
	}
}

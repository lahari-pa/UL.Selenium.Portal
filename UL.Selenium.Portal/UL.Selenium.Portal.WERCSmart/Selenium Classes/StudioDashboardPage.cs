using OpenQA.Selenium;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DashboardPage : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='dashboard-container']");
	}
}

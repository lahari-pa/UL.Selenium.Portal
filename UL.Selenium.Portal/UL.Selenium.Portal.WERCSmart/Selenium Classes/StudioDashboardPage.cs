using OpenQA.Selenium;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.Selenium.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DashboardPage : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='dashboard-container']");
	}
}

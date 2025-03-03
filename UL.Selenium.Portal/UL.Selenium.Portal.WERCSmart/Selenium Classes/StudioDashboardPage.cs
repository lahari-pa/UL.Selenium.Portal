using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DashboardPage : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='dashboard-container']");
	}
}

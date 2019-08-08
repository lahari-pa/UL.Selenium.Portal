using NTTQA.Selenium.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DeleteActiveProducts : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='delete-active-products-grid']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

	}
}

using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	public class CreateTheKit : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='col-md-12 rpds-grid']");
		private IWebElement SearchInput => this.ContainerElement.FindElement(By.XPath($".//span[@class='selection']"), 2);

		public bool SearchInputExists()
		{
			return this.SearchInput != null;
		}
		public bool SearchInputClick()
		{
			return this.SearchInput.TryClick();
		}

	}
}

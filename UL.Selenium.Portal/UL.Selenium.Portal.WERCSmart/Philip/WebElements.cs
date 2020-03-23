using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	class WebElements : SeleniumBaseObject
	{

		public const string BasePath = "";

		protected override By ContainerElementLocator => throw new System.NotImplementedException();

		public bool CheckColumn()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//div[text()='CW']/../preceding-sibling::th//div[text()='Last Pub Date']"), 2);
			IWebElement el1 = this.containerElement.FindElement(By.XPath("//div[text()='CW']/../preceding-sibling::th//div[text()='GHS']"), 2);
			if (el != null && el1 != null)
			{
				return true;
			}
			return false;
		}

		public bool FindProduct()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//td[@aria-describedby='list_Waste'][@title='Y']/preceding-sibling::td[@aria-describedby='list_Product']"), 2);
			if (el != null)
			{
				return true;
			}
			return false;
		}

		public bool FindProductN()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//td[@aria-describedby='list_Waste'][@title='N']/preceding-sibling::td[@aria-describedby='list_Product']"), 2);
			if (el != null)
			{
				return true;
			}
			return false;
		}

		public bool ClickVendorSection()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//span[text()='[SECT0770] Vendor Report']"), 2);
			return el.TryClick();
		}

		public bool ClickASection()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//span[text()='[TXALL]']"), 2);
			return el.TryDoubleClick();
		}

		public bool CheckText()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//td[contains(text(), 'There is no (or limited) data available for any components and waste code has been assigned as a conservative approach due to lack of significant data showing non-hazardous')]"), 2);
			if (el != null)
			{
				return true;
			}

			return false;
		}
	}
}

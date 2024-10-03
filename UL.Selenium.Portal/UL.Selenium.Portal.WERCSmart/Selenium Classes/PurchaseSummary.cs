using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.WebDriver.BaseClasses;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PurchaseSummary : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-body']");

		IWebElement ProductBillingTable => this.ContainerElement.FindElement(By.XPath(".//table[thead//th[text()= 'Item Description']]"));

		public bool ProductBillingTableExists()
		{
			return this.ProductBillingTable != null;	
		}

		public bool ProductBillingTableIsDisplayed()
		{
			return this.ProductBillingTable.Displayed;
		}

	}
}

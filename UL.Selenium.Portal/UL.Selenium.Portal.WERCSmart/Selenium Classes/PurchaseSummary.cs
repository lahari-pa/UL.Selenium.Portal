using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PurchaseSummary : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-body']");

		IWebElement ProductBillingTable => this.ContainerElement.FindElement(By.XPath(".//table[thead//th[text()= 'Item Description']]"));
		IWebElement ProductName => this.ContainerElement.FindElement(By.XPath(".//table//b"));
		IWebElement TableRow(string itemDescription) => this.ContainerElement.FindElement(By.XPath($".//table//tr[td[contains(text(), '{itemDescription}')]]"));
		IWebElement RetailerName(string itemDescription) => this.TableRow(itemDescription).FindElement(By.XPath(".//td[3]"));
		IWebElement Amount(string itemDescription) => this.TableRow(itemDescription).FindElement(By.XPath(".//td[5]"));

		public bool ProductBillingTableExists()
		{
			return this.ProductBillingTable != null;
		}

		public bool ProductBillingTableIsDisplayed()
		{
			return this.ProductBillingTable.Displayed;
		}

		public string GetProductName()
		{
			return this.ProductName.Text;
		}
		public bool TableRowExists(string itemDescription)
		{
			return this.TableRow(itemDescription) != null;
		}
		public string GetRetailerName(string itemDescription)
		{
			return this.RetailerName(itemDescription).Text;
		}
		public string GetAmount(string itemDescription)
		{
			return this.Amount(itemDescription).Text;
		}

	}
}

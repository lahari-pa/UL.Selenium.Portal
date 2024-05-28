using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.WebDriver.BaseClasses;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class GTIN_UPC_TableRow : SeleniumBaseObject
    {
		public string upcNumber;
		public GTIN_UPC_TableRow(string upcNumber)
		{
			this.upcNumber = upcNumber;
		}
		protected override By ContainerElementLocator => By.XPath($"//table[@class = 'table table-hover upc-table']");
		List<IWebElement> UPCsRows => this.ContainerElement.FindElements(By.XPath("//tbody//tr")).ToList();


	}
}

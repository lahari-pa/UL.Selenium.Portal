using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class InventoryStatusProp65 : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'panel-group')]");
		private IWebElement FieldErrorMessage(string errormessage) => this.FindElement(By.XPath($"//p[contains(@class,'form-error')]//span[contains(text(), '{errormessage}')]"), 1);


		public bool InventoryErrorMessageExists(string errormessage)
		{
			Report.Info($"Inventory status pop 65 Attempting to confirm '{errormessage}' error message exists.");
			return this.FieldErrorMessage(errormessage).Displayed;
		}

	}

}

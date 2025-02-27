using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	public class TransportationDetails1 : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-collapse collapse in']");
		private IWebElement ShippingMethod(string section, string option) => this.ContainerElement.FindElement(By.XPath($"//div[label//span[text() = '{section}']]/following-sibling::div//label[span[text()='{option}']]//input"), 2);

		public bool ShippingMethodExists(string section, string option)
		{
			return this.ShippingMethod(section, option) != null;
		}
		public bool ShippingMethodSelect(string section, string option)
		{
			return this.ShippingMethod(section, option).TryClick();
		}
		public bool ShippingMethodSelected(string section, string option)
		{
			return this.ShippingMethod(section, option).Checked();
		}
	}
}

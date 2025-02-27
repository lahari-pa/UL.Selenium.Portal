using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	public class VOCForCaliforniaAirDistrict : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-collapse collapse in']");
		private IWebElement VocInfo(string areaVocInfo) => this.ContainerElement.FindElement(By.XPath($".//td[div[text()='{areaVocInfo}']]/following-sibling::td//input"), 2);

		public bool VocInfoExists(string areaVocInfo)
		{
			return this.VocInfo(areaVocInfo) != null;
		}
		public bool VocInfoEnterText(string areaVocInfo, string text)
		{
			return this.VocInfo(areaVocInfo).TryEnterText(text);
		}
	}
}

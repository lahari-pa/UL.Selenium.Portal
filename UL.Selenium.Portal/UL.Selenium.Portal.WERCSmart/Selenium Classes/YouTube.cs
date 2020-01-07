using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class YouTube : BaseObject
	{
		[FindsBy(How = How.Id, Using = "primary")]
		protected override IWebElement containerElement { get; set; }

		public string VideoTitle()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@id='info']//h1[starts-with(@class,'title')]"), 2)?.Text;
		}

		public bool VideoDisplayed()
		{
			IWebElement videoEl = this.containerElement.FindElement(By.XPath(".//div[@id='player']//video"), 2);
			return videoEl != null && videoEl.Displayed;
		}
	}
}

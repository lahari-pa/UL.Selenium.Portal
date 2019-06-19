using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class WercSmartSolutionsArticle : BaseObject
	{
		public const string BasePath = "//div[@class='c-wrapper']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string ArticleId()
		{
			return this.containerElement.FindElement(By.XPath("./section[starts-with(@cass,'main content']"), 2).GetAttribute("@id");
		}

		public string ArticleHeading()
		{
			return this.containerElement.FindElement(By.XPath(".//*[@class='heading']"), 2)?.Text.Trim();
		}
	}

	class SubscriptionEnrollmentManagement : WercSmartSolutionsArticle
	{
		public bool ClickViewVideo()
		{
			return this.containerElement.FindElement(By.XPath(".//p[contains(text(),'To view a video describing an overview of the WERCSmart Subscription')]/a"), 2).TryClick();
		}
	}
}

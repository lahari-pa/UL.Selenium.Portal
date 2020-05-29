using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class WercSmartSolutionsArticle : SeleniumBaseObject
	{
		//public const string BasePath = "//div[@class='c-wrapper']";
		//[FindsBy(How = How.XPath, Using = BasePath)]
		//protected override IWebElement containerElement { get; set; }

		protected override By ContainerElementLocator => By.XPath("//div[@class='c-wrapper']");

		private IWebElement Article => this.containerElement.FindElement(By.XPath(".//article[@id='article-body']"), 1);

		private IWebElement IntroductoryVideo => this.Article.FindElement(By.XPath(".//a[@href and text()='WERCSmart Introductory Video']"), 1);

		public string ArticleId()
		{
			return this.containerElement.FindElement(By.XPath("./section[starts-with(@cass,'main content']"), 2).GetAttribute("@id");
		}

		public string ArticleHeading()
		{
			var foundText = this.containerElement.FindElement(By.XPath(".//*[@class='heading']"), 2)?.Text.Trim();
			var finalText= foundText.Replace("\r\nPrint", "");
			return finalText;
		}

		public bool ClickIntroductoryVideo => this.IntroductoryVideo.TryClick();

		public bool IntroductoryVideoDisplayed => this.IntroductoryVideo != null && this.IntroductoryVideo.Displayed;


	}

	class SubscriptionEnrollmentManagement : WercSmartSolutionsArticle
	{
		public bool ClickViewVideo()
		{
			return this.containerElement.FindElement(By.XPath(".//p[contains(text(),'To view a video describing an overview of the WERCSmart Subscription')]/a"), 2).TryClick();
		}
	}

	class WercSmartFreshDesk : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='page']");

		private IWebElement PageNavBar => this.containerElement.FindElement(By.XPath("./nav[@class='page-tabs']"), 1);

		public string ActivePage => this.PageNavBar.FindElement(By.XPath("./div/a[@class='active']"), 1)?.Text;

	}
}

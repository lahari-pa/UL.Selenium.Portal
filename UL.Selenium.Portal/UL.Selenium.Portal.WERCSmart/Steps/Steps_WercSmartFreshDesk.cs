using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Freshdesk")]
	class Steps_WercSmartFreshDesk
	{
		[RegexStepDefinition(@"I confirm the WERCSmart FreshDesk 'Solutions' page is loaded")]
		public void ConfirmFreshDeskSolutionsPageIsLoaded()
		{
			Report.IsTrue(new WercSmartFreshDesk().WaitForContainerToBeVisible(), "WERCSmart FreshDesk 'Solutions' page did not load!)", "WERCSmart FreshDesk 'Solutions' page loaded");
		}

		[RegexStepDefinition(@"I confirm there is an article displayed containing the 'WERCSmart Introductory Video'")]
		public void ConfirmArticleDisplayedContainingWercSmartIntroductoryVideo()
		{
			Report.IsTrue(new WercSmartSolutionsArticle().ArticleHeading() != null, "An article was not displayed!");
			Report.IsTrue(new WercSmartSolutionsArticle().IntroductoryVideoDisplayed, "The WERCSmart Introductory Video was not displayed!", "The WERCSmart Introductory Video was displayed within the article");
		}


	}
}

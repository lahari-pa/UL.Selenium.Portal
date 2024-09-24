using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using Reqnroll;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "LandingPage")]
	class Steps_LandingPage
	{

		[RegexStepDefinition(@"In the Retail Product Suite Home page, I click on the (.*) heading")]
		public void GivenInTheRetailProductSuiteHomePageIClickOnTheRecentActivitiesHeading(string headingItem)
		{
			Report.IsTrue(new Home().ClickHeadingItemWithNameInRPS(headingItem), "Failed to click on heading item: " + headingItem, @"Successfully clicked on heading item: " + headingItem);
		}

		[RegexStepDefinition(@"I see my username in the heading")]
		public void GivenISeeMyUsernameInTheHeading()
		{

			Report.IsTrue(new Home().ISeeMyUsernameInTheHeadingBanner("rps.cv.xvxblauh@mailosaur.io"), "Failed to find my username", @"Successfully found my username");
		}

		[RegexStepDefinition(@"I click on my username in the heading banner")]
		public void GivenIClickOnMyUsernameInTheHeadingBanner()
		{
			Report.IsTrue(new Home().ClickUsernameInHeadingBanner(), "Failed to click on my username", @"Successfully clicked my username");
		}

		[RegexStepDefinition(@"I confirm I see the option: (.*)")]
		public void GivenIConfirmISeeTheOptionSignOut(string option)
		{
			Report.IsTrue(new Home().ISeeTheFollowingOption(option), "Failed to find option: " + option, @"Successfully found option: " + option);
		}

		[RegexStepDefinition(@"I confirm I click the option: (.*)")]
		public void GivenIConfirmIClickTheOptionSignOut(string option)
		{
			Report.IsTrue(new LandingPage().IClickTheFollowingOption(option), "Failed to click option: " + option, @"Successfully clicked option: " + option);
		}

		[RegexStepDefinition(@"I click anywhere")]
		public void GivenIClickAnywhere()
		{
			new Home().IClickAnywhere();
		}
		[RegexStepDefinition(@"I confirm I am still on the main RPS page")]
		public void GivenIConfirmIAmStillOnTheHomePage()
		{
			Report.IsTrue(new Home().IAmOnTheMainRPSPage(), "Failed to find the main page", @"Successfully founded the main page");
		}

		[RegexStepDefinition(@"I click the I'D LIKE TO LEARN MORE button at the top of the page")]
		public void GivenIClickTheIDLIKETOLEARNMOREButtonAtTheTopOfThePage()
		{
			Report.IsTrue(new LandingPage().ClickIDLIKETOLEARNMOREBUTTONAtTopOfPage(), "Failed to click I'd like to learn button", @"Successfully clicked I'd like to learn button");
		}

		[RegexStepDefinition(@"I click the I'D LIKE TO LEARN MORE button at the bottom of the page")]
		public void GivenIClickTheIDLIKETOLEARNMOREButtonAtTheBottomOfThePage()
		{
			Report.IsTrue(new LandingPage().ClickIDLIKETOLEARNMOREBUTTONATBottomOfPage(), "Failed to click I'd like to learn button", @"Successfully clicked I'd like to learn button");
		}

		[RegexStepDefinition(@"I click the UL Logo in the header area")]
		public void GivenIClickTheULLogo()
		{
			Report.IsTrue(new Home().ClickULLogoInTheHeaderArea(), "Failed to click UL Logo", @"Successfully clicked UL Logo");
			Delay.Seconds(10);
		}

		[RegexStepDefinition(@"I click the UL Logo in the footer area")]
		public void GivenIClickTheULLogoInTheFooterArea()
		{
			Report.IsTrue(new LandingPage().ClickULLogoInTheFooterArea(), "Failed to click UL Logo", @"Successfully clicked UL Logo");
		}

		[RegexStepDefinition(@"In the upper right corner I locate and click the UL logo")]
		public void GivenIInTheUpperRightCornerLocateTheULLogo()
		{
			Report.IsTrue(new LandingPage().ClickUlLogoInTopRight(), "Failed to click the UL Logo!", "Successfully clicked the UL Logo!");
		}

		[RegexStepDefinition(@"In the upper right corner I locate and click the UL logo in RPS")]
		public void GivenIInTheUpperRightCornerLocateTheULLogoInRPS()
		{
			Report.IsTrue(new LandingPage().ClickUlLogoInTopRightInRPS(), "Failed to click the UL Logo!", "Successfully clicked the UL Logo!");
		}

		[RegexStepDefinition(@"I verify that the (Request more information|I'd like to learn more) link for section: (.*) has a subject line containing: (.*)")]
		public void CheckMoreInformationLinksAreCorrect(string link, string header, string subject)
		{
			string subjectLine = null;
			if (link == "I'd like to learn more")
			{
				subjectLine = new LandingPage().SubjectLineLetsTalkLink();
			}
			if (link == "Request more information")
			{
				subjectLine = new LandingPage().SubjectLineRequestMoreInformationLink(header);
			}
			if (Report.IsTrue(!subjectLine.IsNullOrEmpty(), "Failed to find a valid matching mail link!", "Successfully found a valid matching mail link!", false, false))
			{
				Report.IsTrue(subjectLine.Contains(subject), "Subject line for section " + header + " was '" + subjectLine + "', not '" + subject + "' as expected!", "Subject line contained '" + subject + "', as expected", false, false);
			}
		}

		[RegexStepDefinition(@"I verify that WERCSmart Product Suite logo is showing")]
		public void VerifyWERCSmartProductSuiteLogoShowing()
		{
			var header = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//*[contains(@class,'bar-top')]//a[contains(@class,'brand')]"), 2).GetValue();
			Report.IsTrue(header == "WERCSmart® Product Suite", "Failed to find the WERCSmart Product Suite logo!", "Successfully found the WERCSmart Product Suite logo!");
		}

		[RegexStepDefinition(@"I verify that there is a (Sign In Link|UL Logo) in the upper-right corner")]
		public void VerifyUpperRightScreenElements(string element)
		{
			IWebElement el = null;
			var lp = new LandingPage();
			switch (element)
			{
				case "Sign In Link":
					el = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@"//*[contains(@class,'bar-top')]//button[text()='Sign In']"), 2);
					break;
				case ("UL Logo"):
					el = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@"//*[contains(@class,'bar-top')]//a[@href and contains(@class,'ul-logo')]"), 2);
					break;
			}

			Report.IsTrue(el != null, "Failed to find the " + element + "!", "Successfully found the " + element);
		}

		[RegexStepDefinition(@"I verify that there is a section titled (Good business with I'd like to learn more button|Instant Access displaying a graph|Let's talk with I'd like to learn more button)")]
		public void VerifySections(string element)
		{
			IWebElement el = null;
			switch (element)
			{
				case "Good business with I'd like to learn more button":
					el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//h2[starts-with(text(),'Good business')]//ancestor::div[starts-with(@class,'row')]"), 2);
					if (Report.IsTrue(el != null, "Failed to find section titled Good business!", "Successfully found section titled Good business", false, false))
					{
						var buttonEl = el.FindElement(By.XPath(@".//a[contains(text(),'like to learn more')]"), 2);
						Report.IsTrue(buttonEl != null, "Failed to find button for I'd like to learn more", "Successfully found button for I'd like to learn more");
					}
					return;

				case ("Instant Access displaying a graph"):
					el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//h2[starts-with(text(),'Instant Access')]//ancestor::div[starts-with(@class,'row')]"), 2);
					if (Report.IsTrue(el != null, "Failed to find section titled Instant Access!", "Successfully found section titled Instant Access", false, false))
					{
						var graphEl = el.FindElements(By.XPath(@".//div"), 2).FirstOrDefault(x => !string.IsNullOrEmpty(x.GetCssValue("background")));
						Report.IsTrue(graphEl != null, "Failed to find graph!", "Successfully found graph!");
					}

					return;

				case ("Let's talk with I'd like to learn more button"):
					el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//h2[starts-with(text(),""Let's talk"")]//ancestor::div[starts-with(@class,""row"")]"), 2);
					if (Report.IsTrue(el != null, "Failed to find section titled Let's talk!", "Successfully found section titled Let's talk", false, false))
					{
						var buttonEl = el.FindElement(By.XPath(@".//button[contains(text(),'like to learn more')]"), 2);
						Report.IsTrue(buttonEl != null, "Failed to find button for I'd like to learn more", "Successfully found button for I'd like to learn more");
					}

					return;
			}
		}

		[RegexStepDefinition(@"I verify that under offerings there is a section for (UL Audit|UL PurView|Item Scan) with 'request more information' button")]
		public void VerifyOfferingsSection(string heading)
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//h2[starts-with(text(),'Offerings')]//ancestor::div[starts-with(@class,'row')]"), 2);
			if (Report.IsTrue(el != null, "Failed to find section for Offerings", "Successfully found section for Offerings", false, false))
			{
				var sectionEl = el.FindElement(By.XPath(string.Format(@"./following-sibling::div[1]//div[starts-with(@class,'col') and (.//h3[contains(text(),'{0}')])]", heading)), 2);
				if (Report.IsTrue(sectionEl != null, "Failed to find heading " + heading, "Successfully found heading " + heading, false, false))
				{
					var buttonEl = sectionEl.FindElement(By.XPath(".//button[starts-with(text(),'Request more information')]"), 2);
					Report.IsTrue(buttonEl != null, "Failed to find button with text Request more information", "Successfully found button with text Request more information");
				}
			}
		}

		[RegexStepDefinition(@"I verify that in the footer there is a (UL Logo|About UL WERCSmart Link|Contact Us Link|Sign In button)")]
		public void CheckFooterContent(string element)
		{
			var selLandingFooter = new LandingPage.Footer();
			switch (element)
			{
				case "UL Logo":
					Report.IsTrue(selLandingFooter.UlLogoDisplayed(),
						"Failed to find the UL Logo in the footer!",
						"Successfully found the UL Logo in the footer");
					break;
				case "About UL WERCSmart Link":
					Report.IsTrue(selLandingFooter.AboutUlWercSmartDisplayed(),
						"Failed to find the About UL WERCSmart link in the footer!",
						"Successfully found the About UL WERCSmart link in the footer");
					break;
				case "Contact Us Link":
					Report.IsTrue(selLandingFooter.ContactUsDisplayed(),
						"Failed to find the Contact Us link in the footer!",
						"Successfully found the Contact Us link in the footer");
					break;
				case "Sign In button":
					Report.IsTrue(selLandingFooter.SignInDisplayed(),
						"Failed to find the Sign In button in the footer!",
						"Successfully found the Sign In button in the footer");
					break;
				default:
					Report.Failure("Specified element to check was outside bounds of test code!");
					return;
			}
		}

		[RegexStepDefinition(@"I verify that the following items are displayed in the Landing Page Footer:")]
		public void VerifyItemsDisplayedInLandingFooter(Table items)
		{
			ReportSettings.UseSubSteps = true;
			foreach (var item in items.Rows)
			{
				var elName = item["Item"];
				Report.StartStep($"I verify that {elName} is displayed in the Landing Page Footer");
				CheckFooterContent(elName);
			}
		}
		[RegexStepDefinition(@"I click on the ""I'd like to learn more"" button in the (Good business|Let's talk) section")]
		public void IClickIdLikeToLearnMoreButtonInGoodBusinessSection(string section)
		{
			var el = SeleniumBrowser.WebBrowser.FindElement(By.XPath($@"//h2[contains(text(),""{section}"")]//ancestor::div[starts-with(@class,'row')]"), 2);
			if (Report.IsTrue(el != null, $"Failed to find section titled {section}!", $"Successfully found section titled {section}", false, false))
			{
				IWebElement buttonEl = null;
				if (section == "Good business")
				{
					buttonEl = el.FindElement(By.XPath(@".//a[contains(text(),'like to learn more')]"), 2);
				}
				if (section == "Let's talk")
				{
					buttonEl = el.FindElement(By.XPath(@".//a[contains(text(),'like to learn more')]"), 2);
				}
				Report.IsTrue(buttonEl.TryClick(),
					"Failed to click button for I'd like to learn more",
					"Successfully clicked button for I'd like to learn more");
			}
		}

		[RegexStepDefinition(@"I click the footer link: (About UL WERCSmart|Contact Us|Sign In)")]
		public void ClickFooterLink(string link)
		{
			var selLandingPageFooter = new LandingPage.Footer();
			switch (link)
			{
				case "About UL WERCSmart":
					Report.IsTrue(selLandingPageFooter.ClickAboutUlWercSmart(), "Failed to click the About UL WERCSmart footer link!", "Successfully clicked the About UL WERCSmart footer link");
					break;
				case "Contact Us":
					Report.IsTrue(selLandingPageFooter.ClickContactUs(), "Failed to click the Contact Us footer link!", "Successfully clicked the Contact Us footer link");
					break;
				case "Sign In":
					Report.IsTrue(selLandingPageFooter.ClickSignIn(), "Failed to click the Sign In footer link!", "Successfully clicked the Sign In footer link");
					break;
				default:
					Report.Failure("The specified link was outside the bounds of the test code!");
					break;
			}
		}

		[RegexStepDefinition(@"I verify that the Contact Us button in the footer is a valid email link")]
		public void VerifyFooterContactUsButtonIsValidEmailLink()
		{
			var selLandingPageFooter = new LandingPage.Footer();
			if (Report.IsTrue(selLandingPageFooter.ContactUsDisplayed(), "Contact Us button was not found in the footer", "Contact Us button was found in the footer", false, false))
			{
				Report.IsTrue(selLandingPageFooter.ValidContactUsEmailLink(),
					"Contact Us button in the footer was not a valid email link!",
					"Contact Us button in the footer was a valid email link");
			}
		}

		[RegexStepDefinition(@"I click 'Sign In'")]
		public void ClickSignIn()
		{
			Report.IsTrue(new LandingPage().ClickSignIn(), "Failed to click Sign In", "Clicked Sign In");
		}

		[RegexStepDefinition(@"I click 'Sign In' in RPS")]
		public void ClickSignInInRPS()
		{
			Report.IsTrue(new LandingPage().ClickSignInInRPS(), "Failed to click Sign In in RPS", "Clicked Sign In in RPS");
		}

		[RegexStepDefinition(@"I confirm the Landing Page has loaded")]
		public void ConfirmLandingPageHasLoaded()
		{
			var landing = new LandingPage();
			Report.IsTrue(new LandingPage().WaitForContainerToBeVisible(), "Landing Page did not load!", "Landing Page loaded");
		}

        [RegexStepDefinition(@"I confirm the footer shows background color: grey")]
        public void ConfirmPageBannerColorIsNavyBlue()
        {

            string expectedColorString = "rgba(51, 51, 51, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
			string foundColorCode = new LandingPage.Footer().GetFooterBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }


    }
}

using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "LandingPage")]
    class Steps_LandingPage
    {
        [StepDefinition(@"In the upper right corner I locate and click the UL logo")]
        public void GivenIInTheUpperRightCornerLocateTheULLogo()
        {
            Report.IsTrue(new LandingPage().ClickUlLogoInTopRight(), "Failed to click the UL Logo!", "Successfully clicked the UL Logo!");
        }

        [StepDefinition(@"I click the UL Logo in the (bottom|upper right) of the page")]
        public void ClickULLogoInLocation(string location)
        {
            switch (location)
            {
                case ("bottom"):
                    {
                        Report.IsTrue(SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//footer//div[contains(@class,'footer-logo')]"), 2).TryClick(), "Failed to click the UL Logo at the bottom of the page!", "Successfully clicked the UL Logo at the bottom of the page!");
                        return;
                    }
                default:
                    {
                        Report.IsTrue(new LandingPage().ClickUlLogoInTopRight(), "Failed to click the UL Logo in the upper-right of the page!", "Successfully clicked the UL Logo in the upper-right of the page!");
                        return;
                    }
            }
        }

        [StepDefinition(@"I verify that the (Request more information|I'd like to learn more) link for section: (.*) has a subject line containing: (.*)")]
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

        [StepDefinition(@"I verify that WERCSmart Product Suite logo is showing")]
        public void VerifyWERCSmartProductSuiteLogoShowing()
        {
            var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='bar-top']//a[starts-with(@class,'brand')]"), 2).GetValue();
            Report.IsTrue(header == "WERCSmart® Product Suite", "Failed to find the WERCSmart Product Suite logo!", "Successfully found the WERCSmart Product Suite logo!");
        }

        [StepDefinition(@"I verify that there is a (Sign In Link|UL Logo) in the upper-right corner")]
        public void VerifyUpperRightScreenElements(string element)
        {
            IWebElement el = null;
            switch (element)
            {
                case "Sign In Link":
                    el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//div[@class='bar-top']//div[starts-with(@class,'btn-toolbar')]//button[text()='Sign In']"), 2);
                    break;
                case ("UL Logo"):
                    el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//div[@class='bar-top']//div[starts-with(@class,'btn-toolbar')]//a[@href and contains(@class,'ul-logo')]"), 2);
                    break;
            }

            Report.IsTrue(el != null, "Failed to find the " + element + "!", "Successfully found the " + element);
        }

        [StepDefinition(@"I verify that there is a section titled (Good business with I'd like to learn more button|Instant Access displaying a graph|Let's talk with I'd like to learn more button)")]
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

        [StepDefinition(@"I verify that under offerings there is a section for (UL Audit|UL PurView|Item Scan) with 'request more information' button")]
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

        [StepDefinition(@"I verify that in the footer there is a (UL Logo|About UL WERCSmart Link|Contact Us Link|Sign In button)")]
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

        [StepDefinition(@"I verify that the following items are displayed in the Landing Page Footer:")]
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
        [StepDefinition(@"I click on the ""I'd like to learn more"" button in the (Good business|Let's talk) section")]
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

        [StepDefinition(@"I click the footer link: (About UL WERCSmart|Contact Us|Sign In)")]
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

        [StepDefinition(@"I verify that the Contact Us button in the footer is a valid email link")]
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

        [StepDefinition(@"I click 'Sign In'")]
        public void ClickSignIn()
        {
            Report.IsTrue(new LandingPage().ClickSignIn(), "Failed to click Sign In", "Clicked Sign In");
        }

        [StepDefinition(@"I confirm the Landing Page has loaded")]
        public void ConfirmLandingPageHasLoaded()
        {
            Report.IsTrue(new LandingPage().WaitForContainerToBeVisible(), "Landing Page did not load!", "Landing Page loaded");
        }
    }
}

using System.Text.RegularExpressions;
using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class LandingPage : SeleniumBaseObject
    {
        #region Page Objects
        private const string BasePath = "//body[starts-with(@class,'logged-out')]";

        protected override By ContainerElementLocator => By.XPath(BasePath);

        private IWebElement ToolbarRight => FindElement(By.XPath(".//div[@id='navbarSupportedContent']"), 1);

        private IWebElement UlLogo => this.ToolbarRight.FindElement(By.XPath(".//a[@class = 'pull-right ul-logo']"), 1);

        private IWebElement OfferingsRequestMoreInfoButton(string section) => FindElement(By.XPath($".//div[@class = 'row offerings'][last()]/div[(./h3[contains(text(),'{section}')])]/button"), 1);

        private IWebElement LetsTalkLearnMoreButton => FindElement(By.XPath(@".//div[./h2[contains(text(),""Let's talk"")]]/button"), 2);

        private IWebElement SignIn => this.ToolbarRight.FindElement(By.XPath(".//button[contains(text(),'Sign In')]"), 1);
        #endregion

        #region Methods
        public bool ClickUlLogoInTopRight() => this.UlLogo.TryClick();

        public string SubjectLineRequestMoreInformationLink(string section)
        {
            var el = this.OfferingsRequestMoreInfoButton(section);
            if (el == null)
            {
                return null;
            }
            if (ValidButtonEmailLink(el))
            {
                var regexMatch = Regex.Match(el.GetAttribute("onclick"), @"subject=(.*)'");
                return regexMatch.Groups[1].Value.Replace(@"%20", " ");
            }
            return null;
        }

        public string SubjectLineLetsTalkLink()
        {
            var el = this.LetsTalkLearnMoreButton;
            if (el == null)
            {
                return null;
            }
            if (Regex.Match(el.GetAttribute("onclick"), @"location.href='mailto:(.*)?subject=(.*)'").Success)
            {
                var regexMatch = Regex.Match(el.GetAttribute("onclick"), @"subject=(.*)'");
                return regexMatch.Groups[1].Value.Replace(@"%20", " ");
            }
            return null;
        }

        public bool ValidButtonEmailLink(IWebElement el)
        {
            return Regex.Match(el.GetAttribute("onclick"), @"location.href='mailto:(.*)?subject=(.*)'").Success;
        }

        public bool ClickSignIn()
        {
            return this.SignIn.TryClick();
        }
        #endregion

        public class Footer : SeleniumBaseObject
        {
            #region Page Objects
            protected override By ContainerElementLocator => By.XPath(BasePath + "//footer");

            private IWebElement UlLogo() => FindElement(By.XPath(".//div[contains(@class,'footer-logo')]"), 2);

            private IWebElement AboutUlWercSmart() => FindElement(By.XPath(".//a[text() = 'About UL WERCSmart']"), 2);

            private IWebElement ContactUs() => FindElement(By.XPath(".//a[text() = 'Contact Us']"), 2);

            private IWebElement SignIn() => FindElement(By.XPath(".//button[contains(text(), 'Sign In')]"), 2);
            #endregion

            #region Methods
            public bool UlLogoDisplayed()
            {
                var el = this.UlLogo();
                return el != null && el.Displayed;
            }

            public bool AboutUlWercSmartDisplayed()
            {
                var el = this.AboutUlWercSmart();
                return el != null && el.Displayed;
            }

            public bool ContactUsDisplayed()
            {
                var el = this.ContactUs();
                return el != null && el.Displayed;
            }

            public bool SignInDisplayed()
            {
                var el = this.SignIn();
                return el != null && el.Displayed;
            }

            public bool ClickUlLogo()
            {
                return this.UlLogo().TryClick();
            }

            public bool ClickAboutUlWercSmart()
            {
                return this.AboutUlWercSmart().TryClick();
            }

            public bool ClickContactUs()
            {
                return this.ContactUs().TryClick();
            }

            public bool ClickSignIn()
            {
                return this.SignIn().TryClick();
            }

            public bool ValidContactUsEmailLink()
            {
                return Regex.Match(this.ContactUs().GetAttribute("href"), @"mailto:(.*)?subject=(.*)").Success;
            }

            #endregion
        }
    }
}

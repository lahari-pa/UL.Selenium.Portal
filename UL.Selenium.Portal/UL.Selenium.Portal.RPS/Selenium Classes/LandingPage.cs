using OpenQA.Selenium;
using System.Text.RegularExpressions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class LandingPage : SeleniumBaseObject
    {
        #region Page Objects
        private const string BasePath = "//body[starts-with(@class,'  pace-done')]";

        protected override By ContainerElementLocator => By.XPath(BasePath);

        private IWebElement ToolbarRight => FindElement(By.XPath(".//*[@id='navbarSupportedContent']|.//div[@class='btn-toolbar pull-right']"), 1);

        private IWebElement UlLogo => this.ToolbarRight.FindElement(By.XPath(".//a[contains(@class, 'ul-logo')]"), 1);

        private IWebElement UlLogoInRPS => this.FindElement(By.XPath("//a[@class='pull-right ul-logo']"), 1);

        private IWebElement OfferingsRequestMoreInfoButton(string section) => FindElement(By.XPath($".//div[@class = 'row offerings'][last()]/div[(./h3[contains(text(),'{section}')])]/button"), 1);

        private IWebElement LetsTalkLearnMoreButton => FindElement(By.XPath(@".//div[./h2[contains(text(),""Let's talk"")]]/button"), 2);

        private IWebElement SignIn => this.ToolbarRight.FindElement(By.XPath(".//button[contains(text(),'Sign In')]"), 1);

        private IWebElement SignInRPS => this.FindElement(By.XPath(".//button[contains(text(),'Sign In')][1]"), 1);





        private IWebElement HeadingItem => this.FindElement(By.XPath(".//ul[@id='topMenu']//li"), 1);

        private IWebElement NavBarOption => this.FindElement(By.XPath(".//ul[@class='nav navbar-nav ml-auto']"), 1);

        private IWebElement ULLogoInFooter => this.FindElement(By.XPath(".//a[@aria-label='UL Logo']"), 1);

        private IWebElement SignOutInHeadingBanner => this.FindElement(By.XPath(".//a[@id='logoutDialog']"), 1);

        private IWebElement TopOfPageIDLIKETOLEARNMOREButton => this.FindElement(By.XPath(".//div[@class='col-md-6']//a"), 1);

        private IWebElement BottomOfPageIDLIKETOLEARNMOREButton => this.FindElement(By.XPath(".//div[@class='col-md-6 lets-talk']//button"), 1);



        #endregion

        #region Methods
        public bool ClickUlLogoInBottom() => this.UlLogo.TryClick();
        public bool ClickUlLogoInTopRight() => this.UlLogo.TryClick();
        public bool ClickUlLogoInTopRightInRPS() => this.UlLogoInRPS.TryClick();


        public bool ClickHeadingItemWithName(string headerItem) => this.HeadingItem.FindElement(By.XPath(@"//a[text()='" + headerItem + "']"), 2).TryClick();

        public bool IClickTheFollowingOption(string option) => this.NavBarOption.FindElement(By.XPath(@"//a[text()='" + option + "']"), 2).TryClick();

        public bool ClickULLogoInTheFooterArea() => this.ULLogoInFooter.TryClick();

        public bool ClickSignOutInHeadingBanner() => this.SignOutInHeadingBanner.TryClick();

        public bool ClickIDLIKETOLEARNMOREBUTTONAtTopOfPage() => this.TopOfPageIDLIKETOLEARNMOREButton.TryClick();

        public bool ClickIDLIKETOLEARNMOREBUTTONATBottomOfPage() => this.BottomOfPageIDLIKETOLEARNMOREButton.TryClick();



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

        public bool ClickSignInInRPS()
        {
            return this.SignInRPS.TryClick();
        }
        #endregion

        public class Footer : SeleniumBaseObject
        {
            #region Page Objects
            protected override By ContainerElementLocator => By.XPath(BasePath + "//footer");

            private IWebElement UlLogo() => FindElement(By.XPath(".//div//img[contains(@src,'ul-logo')]"), 2);

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

            public string GetFooterBackgroundColor()
            {
                var Path = BasePath.Insert(BasePath.Length, "//footer");
                IWebElement footerEl = FindElement(By.XPath(Path), 2);
                if (footerEl == null)
                {
                    Report.Error("The Footer Element was null");
                    return null;
                }
                string rbgaCssValue = footerEl.GetCssValue("background-color");
                return rbgaCssValue;
            }

            #endregion
        }
    }
}

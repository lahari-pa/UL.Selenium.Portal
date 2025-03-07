using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class Login : SeleniumBaseObject
    {
        #region Page Objects

        protected override By ContainerElementLocator => By.XPath(@"//div[@class='body-container']");

        private IWebElement SignInButton => ContainerElement.FindElement(By.XPath(".//div[@id='navbarSupportedContent']//button[contains(text(), 'Sign In']"), 1);

        #endregion

        #region Methods

        public bool ClickSignIn => SignInButton.TryClick();

        #endregion

        class LogInModal : BaseModalDialog
        {
            #region Page Objects
            protected override By ContainerElementLocator => By.Id("loginModal");

            private IWebElement LoginButton => ContainerElement.WaitUntilElementVisible(By.Id("cmdLogIn"), 1);

            private IWebElement UserNameInput => ContainerElement.WaitUntilElementVisible(By.Id("UserName"), 1);

            private IWebElement PasswordInput => ContainerElement.WaitUntilElementVisible(By.Id("Password"), 1);

            private IWebElement ValidationErrors => ContainerElement.WaitUntilElementVisible(By.XPath(".//div[@class='validation-summary-errors']"), 3);

            private IWebElement UserNameLabel => this.UserNameInput.FindElement(By.XPath("./preceding-sibling::label[position()=1]"), 1);

            private IWebElement PasswordLabel => this.PasswordInput.FindElement(By.XPath("./preceding-sibling::label[position()=1]"), 1);

            #endregion

            #region Methods
            public bool UserNameLabelDisplayed() => this.UserNameLabel != null && this.UserNameLabel.Text.ToLower() == "user name";

            public bool PasswordLabelDisplayed() => this.PasswordLabel != null && this.PasswordLabel.Text == "Password";

            public bool LoginButtonTextDisplayed() => this.LoginButton?.GetValue() == "Log In";

            public bool CloseButtonTextDisplayed() => this.ButtonWithTextDisplayed("Close");

            public bool ClickCloseButton() => this.ClickButtonByText("Close");

            public bool ClickLoginButton => this.LoginButton.TryClick();

            public bool EnterUserName(string text) => this.UserNameInput.TryEnterText(text) && this.UserNameInput.GetValue() == text;

            public bool EnterPassword(string text) => this.PasswordInput.TryEnterText(text) && this.PasswordInput.GetValue() == text;

            public List<string> LogInErrors() => this.ValidationErrors.FindElements(By.XPath("./ul/li"), 1)?.Select(x => x.Text).ToList();
            #endregion
        }
    }
    public class LandingPlatform : SeleniumBaseObject
    {
        protected override By ContainerElementLocator => By.Id("container");

        private IWebElement EmailInput => ContainerElement.FindElement(By.Id("signInName"), 2);
        private IWebElement PasswordInput => ContainerElement.FindElement(By.Id("password"), 2);
        private IWebElement EmailReadOnly => ContainerElement.FindElement(By.Id("readonlyEmailAnchor"), 2);

        private IWebElement PageHeader => ContainerElement.FindElement(By.XPath(".//div[@class='content-box']/descendant::h1"), 1);
        private IWebElement SubHeader => ContainerElement.FindElement(By.XPath(".//div[@class='content-box']/descendant::h2"), 1);

        private IWebElement SignInOrNextBtn => ContainerElement.FindElement(By.Id("continue"), 1);
        private IWebElement Loading => ContainerElement.FindElement(By.Id("api"), 2);

        public bool EnterEmailId(string email)
        {
            if (PageHeader?.Text != "UL Solutions Account" && SubHeader?.Text != "Sign in to your account")
            {
                Report.Error($"Expected 'UL Solutions Account' but displayed :'{PageHeader.Text}', Expected 'Sign in to your account' but displayed :'{SubHeader.Text}'");
            }

            if (!LoadingWait())
            {
                Report.Info("Still Loading...");
                return false;
            }

            Report.Info($"Entering Email Address: '{email}");
            EmailInput.EnterText(email);

            Report.Screenshot();

            Report.Info("Clicking Next button");

            return SignInOrNextBtn.TryClick();
        }

        public bool SignIn(string email, string password)
        {
            WaitForContainerToBeVisible();

            if (!EnterEmailId(email))
            {
                Report.Info("Not able to sign in");
                return false;
            }

            if (!OverLayer())
            {
                Report.Info("Still Overlay...");
                return false;
            }

            if (PageHeader?.Text != "UL Solutions Account" && SubHeader?.Text != "Enter your password")
            {
                Report.Error("Header or Sub-header text are mismatched");
            }

            if (!LoadingWait())
            {
                Report.Info("Still Loading...");
                return false;
            }

            if (!string.Equals(EmailReadOnly?.Text.Replace("arrow_back", "", StringComparison.CurrentCultureIgnoreCase), email,
                    StringComparison.CurrentCultureIgnoreCase))
            {
                Report.Info($"Entered {email} mail is not shown {EmailReadOnly?.Text}");
                return false;
            }


            Report.Info($"Entering Password: '{password}");
            PasswordInput.EnterText(password);
            Report.Screenshot();

            Report.Info("Clicking sign-in button");
            SignInOrNextBtn.TryClick();

            return new TopBar().WaitForContainerToBeVisible();
        }

        public bool OverLayer(int attempt = 60)
        {
            Report.Info("Verify the Overlay...");

            IWebElement overLay = WebDriver.FindElement(By.Id("simplemodal-overlay"), 2);

            int counter = 0;

            while (overLay != null && counter < attempt)
            {
                overLay = WebDriver.FindElement(By.Id("simplemodal-overlay"), 2);
                WaitForContainerToBeInvisible(3);
                counter++;
            }

            return overLay == null;
        }

        public bool LoadingWait(int attempt = 60)
        {
            Report.Info("Verify the Loading...");

            string loadWheel = Loading?.GetAttribute("class");

            int counter = 0;

            while (loadWheel != string.Empty && counter < attempt)
            {
                loadWheel = Loading?.GetAttribute("class");
                WaitForContainerToBeInvisible(2);
                counter++;
            }

            return loadWheel == string.Empty;
        }
    }
    public class CookiesFooter : SeleniumBaseObject
    {
        protected override By ContainerElementLocator => By.XPath(".//div[@id='truste-consent-track' and not(contains(@style,'display: none;'))]");

        private IWebElement AcceptCookiesBtn => ContainerElement.FindElement(By.XPath(".//button[text()='Accept All Cookies']"), 1);

        public bool AcceptCookiesClick()
        {
            Report.Info("Attempting to Click Accept Cookies Button");
            AcceptCookiesBtn.TryClick();
            return true;
        }

        public bool AcceptCookies()
        {
            Delay.Seconds(2);

            if (ContainerVisible())
            {
                if (!AcceptCookiesClick())
                {
                    Report.Info("Failed to Click Accept Cookies Button");
                    Report.Screenshot();
                    return false;
                }
                Delay.Seconds(2);
                if (ContainerVisible())
                {
                    Report.Info("Failed to Remove Cookies Bar");
                    Report.Screenshot();
                    return false;
                }
                Report.Success("Cookies Accepted");
                Report.Screenshot();
                return true;
            }
            Report.Info("Cookies Bar not Showing");
            return true;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class BaseModalDialog : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class= 'modal fade in' and @role = 'dialog']");

        private IWebElement TitleByClass => this.containerElement.FindElement(By.ClassName("modal-title"), 1);

        private IWebElement TitleById => this.containerElement.FindElement(By.Id("dlgTitle"), 1);

        private IWebElement ButtonWithText(string btnText) => FindElement(By.XPath($".//button[text()='{btnText}']"), 1);

        private IWebElement CloseTopRightX => this.containerElement.FindElement(By.XPath(".//button[@class='close']"), 1);

        private IWebElement BodyElement => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-body']"), 2);
        #endregion

        #region Methods
        public string TitleText => this.TitleById?.Text ?? this.TitleByClass?.Text;

        public bool ClickButtonByText(string text) => this.ButtonWithText(text).TryClick();

        public bool ButtonWithTextDisplayed(string text)
        {
            var el = this.ButtonWithText(text);
            return el != null && el.Displayed;
        }

        public bool ClickCloseTopRightX() => this.CloseTopRightX.TryClick();

        public string GetBodyText()
        {
            var el = this.BodyElement;
            if(el==null)
            {
                Report.Info($"The body element was null");
                return null;
            }
            return el.Text;
        }

        public bool BodyTextMatches(string expectedText)
        {
            string textFound = this.GetBodyText();
            if(textFound == null)
            {
                Report.Info($"The text was null");
                return false;
            }
            return textFound == expectedText;
        }

        #endregion
    }

    class LogInModal : BaseModalDialog
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.Id("loginModal");
        
        private IWebElement LoginButton => this.containerElement.WaitUntilElementVisible(By.Id("cmdLogIn"), 1);
        
        private IWebElement UserNameInput => this.containerElement.WaitUntilElementVisible(By.Id("UserName"), 1);

        private IWebElement PasswordInput => this.containerElement.WaitUntilElementVisible(By.Id("Password"), 1);

        private IWebElement ValidationErrors => this.containerElement.WaitUntilElementVisible(By.XPath(".//div[@class='validation-summary-errors']"), 3);

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

    class SelectChartModal : BaseModalDialog
    {
        #region Page Objects
        private List<IWebElement> DisplayedListItems => FindElements(By.XPath("//ul[@class='list-group']/li[not(@style = 'display: none;')]"), 1).ToList();

        private List<IWebElement> DisplayedListItemTitles => this.DisplayedListItems.Select(x => x.FindElement(By.XPath("./a/span"), 1)).ToList();
        #endregion

        #region Methods
        public List<string> DisplayedListOptions() => this.DisplayedListItems.Select(x => x.Text).ToList();

        public bool ClickListItem(string item)
        {
            try
            {
                return DisplayedListItemTitles.FirstOrDefault(x => x.Text == item).TryClick();
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    class NoValudUPCsModal: BaseModalDialog
    {
        #region Page Objects

        #endregion

        #region Methods

        #endregion

    }
}

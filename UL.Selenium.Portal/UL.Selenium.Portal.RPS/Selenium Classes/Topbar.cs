using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class TopBar : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class='bar-top']");

        private IWebElement RightToolBar => FindElement(By.XPath(".//div[@class='btn-toolbar pull-right']"), 1);

        private IWebElement UserAccount => this.RightToolBar.FindElement(By.Id("dAcccount"), 1);

        private IWebElement UlLogo => this.RightToolBar.FindElement(By.XPath(".//a[contains(@class,'ul-logo')]"), 1);

        private IWebElement SignOut => this.RightToolBar.FindElement(By.Id("logoutDialog"), 1);

        private IWebElement BrandNameLeft=> FindElement(By.XPath(".//a[@class='brand pull-left']"), 1);
        #endregion

        #region Methods
        public string UserAccountText() => this.UserAccount?.Text;

        public bool ClickUserAccount() => this.UserAccount.TryClick();

        public bool ClickUlLogo() => this.UlLogo.TryClick();

        public bool ClickBrandName() => this.BrandNameLeft.TryClick();

        public bool UlLogoDisplayed() => this.UlLogo != null && this.UlLogo.Displayed;

        public bool BrandNameDisplayed() => this.BrandNameLeft != null && this.BrandNameLeft.Displayed;

        public bool ClickSignOut() => this.SignOut.TryClick();

        public bool SignOutDisplayed() => this.SignOut != null && this.SignOut.Displayed;

        public string GetBrandName()
        {
            
            string fullStr = this.BrandNameLeft.Text;
            return fullStr;
        }

        public string GetBradNameFontColor()
        {
            IWebElement brandNameElement = this.BrandNameLeft;
            if(brandNameElement==null)
            {
                Report.Error("The Brand Name Element was null");
                return null;
            }
            
            string rbgaCssValue = brandNameElement.GetCssValue("color");
            return rbgaCssValue;
        }

        public string GetUserAccountFontColor()
        {
            IWebElement userAccountElement = this.UserAccount;
            if (userAccountElement == null)
            {
                Report.Error("The User Account Element was null");
                return null;
            }
            
            string rbgaCssValue = userAccountElement.GetCssValue("color");
            return rbgaCssValue;
        }

        public string GetTopBarBackgroundColor()
        {
            IWebElement topBarEl = this.containerElement;
            if (topBarEl == null)
            {
                Report.Error("The Top Bar Element was null");
                return null;
            }

            string rbgaCssValue = topBarEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public void RefocusGraph()
        {
            var action = new Actions(SeleniumBrowser.WebBrowser);
            try
            {
                action.MoveToElement(this.containerElement).Perform();
            }
            catch
            {
                Report.Info("Failed to move to element");
            }
        }

        #endregion
    }
}

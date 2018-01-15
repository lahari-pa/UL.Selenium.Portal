using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class Signup : BaseObject
    {
        public const string BasePath = "//div[@class='login-wrapper']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public void Enter_Email(string Email)
        {
            containerElement.FindElement(By.XPath("//input[@id='txtEmail']")).EnterText(Email, true,0.05);
        }

        public void Enter_ConfirmEmail(string Email)
        {
            containerElement.FindElement(By.XPath("//input[@id='txtConfirm']")).EnterText(Email, true,0.05);
        }

        public bool Click_Submit()
        {
            try
            {
                containerElement.FindElements(By.XPath("//a")).FirstOrDefault(x => x.Text == "Submit").Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void Click_Cancel()
        {
            containerElement.FindElements(By.XPath("//a")).FirstOrDefault(x => x.Text == "Cancel").Click();
        }

        public bool Enter_Email_Error_Exists()
        {
            return (containerElement.FindElements(By.XPath("//p[@id='txtEmail_error']/span")).Count > 0);
        }

        public string Get_Email_Error()
        {
            return containerElement.FindElements(By.XPath("//p[@id='txtEmail_error']/span"))[0].Text;
        }

        public bool Confirm_Email_Error_Exists()
        {
            return (containerElement.FindElements(By.XPath("//p[@id='confirmEmail_error']/span")).Count > 0);
        }

        public string Get_Confirm_Email_Error()
        {
            return containerElement.FindElements(By.XPath("//p[@id='confirmEmail_error']/span"))[0].Text;
        }

        public bool Sign_Up_Thank_You_Page_Exists(int SecondsToWait=30)
        {
            IWebElement element = element = containerElement.FindElement(By.XPath(".//div[@class='item active']//a[@class= 'btnL btn btn-success']"), 2);

            int i = 0;
            while (element == null && i < SecondsToWait)
            {
                Delay.Seconds(Delay.SpeedFactor * 1);
                element = containerElement.FindElement(By.XPath(".//div[@class='item active']//a[@class= 'btnL btn btn-success']"), 2);
                i++;
            }

            return element != null && element.Displayed;
        }

        public void Click_Login_On_Sign_Up_Thank_You_Page()
        {
            containerElement.FindElement(By.XPath("//div[@class='item active']//a[@class= 'btnL btn btn-success']")).Click();
        }
    }
}

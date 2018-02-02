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
    class ForgottenPassword : BaseObject
    {
        public const string BasePath = "//div[@id='loginModal']";

        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }


        public void Click_Continue()
        {
			this.containerElement.FindElement(By.XPath(".//a[@id='carouselContinue']"),2).Click();
        }

        public void Click_Cancel()
        {
            IList<IWebElement> listOfAElements =
				this.containerElement.FindElements(By.XPath(".//div[@class='carousel slide carousel-wizard'//a]"),2);

            listOfAElements.FirstOrDefault(x => x.Text == "Cancel").Click();
        }

        public void Enter_Email(string email)
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
					this.containerElement.FindElement(By.XPath("//input[@id='forgotEmail']"), 2).EnterText(email, true);
                    return;
                }
                catch (Exception)
                {
                    Delay.Seconds(Delay.SpeedFactor*1);
                    count++;
                }

                throw new Exception("Could not enter email!");
            }
            
        }

        public bool Login_Button_Exists()
        {
            return this.containerElement.FindElement(By.XPath("//a[@id='btnLogin']"),2).Displayed;
        }

        public void Click_Login_Button()
        {
			this.containerElement.FindElement(By.XPath("//a[@id='btnLogin']"),2).Click();
        }

        public List<string> GetErrors()
        {
            try
            {
                return this.containerElement.FindElements(By.XPath("//p[@id='email_error']/span"), 2).Select(x => x.GetValue().Trim()).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
           

        }
    }
}

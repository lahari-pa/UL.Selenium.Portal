using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class Login : BaseObject
    {
        public const string BasePath = "//div[@class='login-wrapper']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

	    public void ClickOutside()
	    {
		    var el = containerElement.FindElement(By.XPath(".//div[contains(@class,'login-body')]"), 2);
		    var ActionClass = new Actions(GlobalParameters.Browser.WebBrowser);
		    ActionClass.MoveToElement(el,-100,-100).Click().Perform();
		}

        public void Change_Language(string Language)
        {

            var LanguageDropDown = containerElement.FindElement(By.XPath(".//div[@class='btn-group btn-language']"), 2);
            if (LanguageDropDown == null)
                throw new Exception("Language Button container could not be found!");
            var Button = LanguageDropDown.FindElement(By.XPath(".//button"), 2);
            if (Button.Text.Trim() == Language)
                return;

            Button.Click();
            var SelectElement = LanguageDropDown.FindElements(By.XPath(".//ul//a"), 2).FirstOrDefault(x => x.Text == Language);
            if(SelectElement==null)
                throw new Exception("Language not present in container!");

            SelectElement.Click();
        }

        public string Form_Header_Text()
        {
            return containerElement.FindElement(By.XPath("//div[@id='loginModal']//div[@class='panel-body']/h3"), 2).Text;
        }

        public string Email_Header_Text()
        {
            return containerElement.FindElement(By.XPath(".//label[@for='loginEmail']"), 2).Text;
        }

        public string Password_Header_Text()
        {
            return containerElement.FindElement(By.XPath(".//label[@for='loginPassword']"), 2).Text;
        }

        public string Forgotten_Password_Text()
        {
            return containerElement.FindElement(By.XPath(".//a[@id='btnForgotPassword']"), 2).Text;
        }

        public string Login_Button_Text()
        {
            return containerElement.FindElement(By.XPath(".//form[@class='login-form']//button"), 2).Text;
        }

        public string Email_Field
        {
            get { return containerElement.FindElement(By.XPath(".//input[@name='loginEmail']"), 2).Text; }
            set { containerElement.FindElement(By.XPath(".//input[@name='loginEmail']"), 2).EnterText(value); }
        }

        public string Password_Field
        {
            get { return containerElement.FindElement(By.XPath(".//input[@name='loginPassword']"), 2).Text; }
            set { containerElement.FindElement(By.XPath(".//input[@name='loginPassword']"), 2).EnterText(value); }
        }

        public void Click_Login()
        {
            containerElement.FindElement(By.XPath(".//form[@class='login-form']//button"), 2).Click();
        }

        public void Click_Forgotten_Password()
        {
            IList<IWebElement> ListOfATags = containerElement.FindElements(By.XPath(".//form[@class='login-form']//a"));
            ListOfATags.FirstOrDefault(x => x.Text == "Forgot your Password?").Click();
        }

        public void Click_New_To_Wercsmart()
        {
            IList<IWebElement> ListOfATags = containerElement.FindElements(By.XPath(".//form[@class='login-form']//a"));
            ListOfATags.FirstOrDefault(x => x.Text == "New to WERCSmart? Sign Up").Click();
        }

        public string Email_Validation()
        {
            return containerElement.FindElement(By.XPath(".//p[@id='loginEmail_error']//span"), 2).Text;
        }

        public string Password_Validation()
        {
            return containerElement.FindElement(By.XPath(".//p[@id='loginPassword_error']//span"), 2).Text;
        }

    }
}

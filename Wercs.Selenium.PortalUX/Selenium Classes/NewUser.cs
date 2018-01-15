using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class NewUser : BaseObject
    {
        public const string BasePath = "//body[@class='login-body']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='regFirstName']")]
        private IWebElement iFirstName;

        [FindsBy(How = How.XPath, Using = "//input[@id='regPassword']")]
        private IWebElement iPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id='regConfirmPass']")]
        private IWebElement iConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//label[@for='regLastName']/../input")] private IWebElement iLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id='regAddress']")]
        private IWebElement iAddress1;

        [FindsBy(How = How.XPath, Using = "//input[@id='regAddress2']")]
        private IWebElement iAddress2;

        [FindsBy(How = How.XPath, Using = "//input[@id='regCity']")]
        private IWebElement iCity;

         [FindsBy(How = How.XPath, Using = "//input[@id='regState']")]
        private IWebElement iState;

        [FindsBy(How = How.XPath, Using = "//input[@id='ddState']")]
        private IWebElement ddState;

        [FindsBy(How = How.XPath, Using = "//input[@id='regZip']")]
        private IWebElement iZip;

        [FindsBy(How = How.XPath, Using = "//input[@id='regCompanyName']")]
        private IWebElement iCompanyName;

        [FindsBy(How = How.XPath, Using = "//input[@id='regCompanyPhone']")]
        private IWebElement iCompanyPhone;

        [FindsBy(How = How.XPath, Using = "//input[@id='txtCountryCode']")]
        private IWebElement iCountryCode;

        [FindsBy(How = How.XPath, Using = "//input[@id='txtEmergencyPhone']")]
        private IWebElement iEmergencyPhone;

        [FindsBy(How = How.XPath, Using = "//input[@id='ddSupplierType']")]
        private IWebElement ddSupplierType;

        [FindsBy(How = How.XPath, Using = "//a[@id='carouselContinue']")]
        private IWebElement btnContinue;

        [FindsBy(How = How.XPath, Using = "//a[@id='carouselCancel']")]
        private IWebElement btnCancel;

        [FindsBy(How = How.XPath, Using = "//input[@id='secAnswer1']")]
        private IWebElement iSecQ1;

        [FindsBy(How = How.XPath, Using = "//input[@id='secHint1']")]
        private IWebElement iHintQ1;

        [FindsBy(How = How.XPath, Using = "//input[@id='secAnswer2']")]
        private IWebElement iSecQ2;

        [FindsBy(How = How.XPath, Using = "//input[@id='secHint2']")]
        private IWebElement iHintQ2;

        [FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
        private IWebElement iSecQ3;

        [FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
        private IWebElement iHintQ3;

        [FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
        private IWebElement iSecQ4;

        [FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
        private IWebElement iHintQ4;

        [FindsBy(How = How.XPath, Using = "//input[@id='secAnswer3']")]
        private IWebElement iSecQ5;

        [FindsBy(How = How.XPath, Using = "//input[@id='secHint3']")]
        private IWebElement iHintQ5;

        [FindsBy(How = How.XPath, Using = "//input[@id='secQuestionPassword']")]
        private IWebElement iSecPassword;

        [FindsBy(How = How.XPath, Using = "//div[@class='item active']/h4")]
        private IWebElement PageHeader;






        public string Country
        {
            get {
                var CountryDropDown = containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
                return CountryDropDown.GetValue(); 

            }
            set
            {
                Select_Country(value); 
                Report.Success("Entered country: " + value);
            }
        }
        public void Select_Country(string Country)
        {

            var CountryDropDown = containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
            if (CountryDropDown == null)
                throw new Exception("Country drop down control could not be found!");

            CountryDropDown.Click();
            
            var SelectElement = CountryDropDown.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == Country);
            if (SelectElement == null)
                throw new Exception("Country not present in container!");

            SelectElement.Click();
        }

        public string First_name
        {
            get { return iFirstName.GetValue(); }
            set
            {
                iFirstName.EnterText(value);
                Report.Success("Entered country: " + value);
            }
        }



        public string Last_name
        {
            get
            {
                return iLastName.GetValue();
            }
            set
            {
                iLastName.EnterText(value);
                Report.Success("Entered last name: " + value);
            }
        }

        public string Password
        {
            get
            {
                return iPassword.GetValue();
            }
            set
            {
                iPassword.EnterText(value);
                Report.Success("Entered password: " + value);
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return iConfirmPassword.GetValue();
            }
            set
            {
                iConfirmPassword.EnterText(value);
                Report.Success("Entered confirm password: " + value);
            }
        }

        public string Address1
        {
            get
            {
                return iAddress1.GetValue();
            }
            set
            {
                iAddress1.EnterText(value);
                Report.Success("Entered address line 1: " + value);
            }
        }

        public string Address2
        {
            get
            {
                return iAddress2.GetValue();
            }
            set
            {
                iAddress2.EnterText(value);
                Report.Success("Entered address line 2: " + value);
            }
        }

        public string City
        {
            get
            {
                return iCity.GetValue();
            }
            set
            {
                iCity.EnterText(value);
                Report.Success("Entered city: " + value);
            }
        }

        public string State
        {
            get
            {
                return iState.GetValue();
            }
            set
            {
                iState.EnterText(value);
                Report.Success("Entered state: " + value);
            }
        }

        public string Zip
        {
            get
            {
                return iZip.GetValue();
            }
            set
            {
                iZip.EnterText(value);
                Report.Success("Entered zip: " + value);
            }
        }

        public string CompanyName
        {
            get
            {
                return iCompanyName.GetValue();
            }
            set
            {
                iCompanyName.EnterText(value);
                Report.Success("Entered company name: " + value);
            }
        }

        public string CompanyPhone
        {
            get
            {
                return iCompanyPhone.GetValue();
            }
            set
            {
                iCompanyPhone.EnterText(value);
                Report.Success("Entered company phone: " + value);
            }
        }

        public string CountryCode
        {
            get
            {
                var CountryCode = containerElement.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
                return CountryCode != null ? CountryCode.GetValue() : "";
            }
            set
            {
                var CountryCode = containerElement.FindElement(By.XPath(".//input[@id='txtCountryCode']"), 2);
                CountryCode.EnterText(value);
                Report.Success("Entered country code: " + value);
            }
        }

        public string EmergencyPhoneNumber
        {
            get
            {
                return iEmergencyPhone.GetValue();
            }
            set
            {
                iEmergencyPhone.EnterText(value);
                Report.Success("Entered emergency phone number: " + value);
            }
        }

        public void SelectSupplierType(string SupplierType)
        {
            ddSupplierType = containerElement.FindElement(By.XPath("//select[@id='ddSupplierType']"),2);
            if (ddSupplierType == null)
                throw new Exception("Supplier type control could not be found!");

            ddSupplierType.ScrollElementIntoView();
            
            var SelectElement = ddSupplierType.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == SupplierType);
            if (SelectElement == null)
                throw new Exception("Supplier type was not present in container!");

            SelectElement.Click();
            Report.Success("Entered supplier type: " + SupplierType);
        }

        public void SelectUSState(string USState)
        {
            ddState = containerElement.FindElement(By.XPath("//select[@id='ddState']"));
            Report.Info("Beginning select US state: " + USState);
            if (ddState == null)
                throw new Exception("US state drop down control could not be found!");

            var SelectElement = ddState.FindElements(By.XPath(".//option"), 2).FirstOrDefault(x => x.Text == USState);
            if (SelectElement == null)
                throw new Exception("US State was not present in container!");

            SelectElement.Click();
            Report.Success("Selected US State: " + USState);
        }

        public bool ClickContinue()
        {
            try
            {
                btnContinue.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClickCancel()
        {
            btnCancel.Click();
        }

        public string CurrentPageTitle()
        {
            var HeaderTitle = containerElement.FindElement(By.XPath("//div[@class='item active']/h4"),2);
            return HeaderTitle==null?"":HeaderTitle.Text;
        }

        public bool WaitForPageTitle(string WaitingForTitle, int SecondsToWait)
        {
            for (int i = 0; i < SecondsToWait; i++)
            {
                if (CurrentPageTitle() == WaitingForTitle)
                    return true;
                i++;
                Delay.Seconds(1);
            }
            return false;
        }

        public void EnterQuestionAnswer(string Number, string Answer)
        {
            var el = containerElement.FindElement(By.XPath(".//input[@id='secAnswer" + Number + "']"), 2);
            if(el!=null)
                el.EnterText(Answer);
        }

        public void EnterQuestionHint(string Number, string Answer)
        {
            var el = containerElement.FindElement(By.XPath(".//input[@id='secHint" + Number + "']"), 2);
            if (el != null)
                el.EnterText(Answer);
        }

        public string Pin
        {
            get { return containerElement.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).GetValue(); }
            set { containerElement.FindElement(By.XPath(".//input[@id='secQuestionPassword']"), 2).EnterText(value);}
        }

    }
}

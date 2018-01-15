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
    class NewProduct : BaseObject
    {
        // Again a pretty poor/generic ID AND CLASHES WITH FORWARD PRODUCT REGISTRATION!!!
        // but it's the best we have....
        public const string BasePath = "//div[@id='dataentry']";

        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public string GetHeader()
        {
            return containerElement.FindElement(By.XPath(".//div[@class='product-header']/h2"), 2).Text;
        }

        public string GetInitialStatement()
        {
            return containerElement.FindElement(By.XPath(".//form//label[@class='control-label']"), 2).Text;
        }

        public List<string> RadioButtons()
        {
            return containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2).Select(x => x.Text.Trim()).ToList();
        }

	    public string ErrorMessage()
	    {
		    return containerElement.FindElement(By.XPath(".//p[@class='form-error']//span"), 2).Text;
	    }

        public string GetCurrentProduct()
        {
            return containerElement.FindElement(By.XPath(".//h2[@class='product-name']"), 2).Text.Trim();
        }

        public void CreateNewProductOrCopy(bool NewProduct = true)
        {
            var Option = containerElement.FindElements(By.XPath(".//form//label[@class='radio']"), 2).FirstOrDefault(x => x.Text.StartsWith((NewProduct ? "Yes" : "No")));
            if (Option == null)
                return;
            Option.Click();
        }

        public bool ClickContinue()
        {
            try
            {
                var el = containerElement.FindElement(By.XPath(".//a[contains(@class,'continue-button')]"), 2);
                if (el == null)
                    return false;
                el.Click();
                GeneralUtilities.Wait_for_load_finish();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string ProductName
        {
            get { return containerElement.FindElement(By.XPath(".//label[contains(text(),'Product name')]/../following-sibling::div/input"), 2).Text.Trim(); }
            set { containerElement.FindElement(By.XPath(".//label[contains(text(),'Product name')]/../following-sibling::div/input"), 2).EnterText(value); }
        }

        public string ProductType
        {
            set
            {
                var el = containerElement.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"), 2);
                el.Click();
                var InputField = containerElement.FindElement(By.XPath("//span[contains(@class,'select2-container')]//input"), 2);
                InputField.EnterText(value);
                GeneralUtilities.Wait_for_load_finish();

                var DropDownResults = containerElement.FindElements(By.XPath("//span[contains(@class,'select2-container')]//ul/li"), 2);
                var ddlEl = DropDownResults.FirstOrDefault(x => x.Text.Trim() == value);
                if (ddlEl == null)
                    return;
                ddlEl.Click();
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;


namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class HelpAndSupport : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class='freshwidget-container responsive']//div[@class='freshwidget-dialog']");
        
        private IWebElement PopupHeader => ContainerElement.FindElement(By.XPath($""), 2);

        private IWebElement xIconEl => ContainerElement.FindElement(By.Id("freshwidget-close"), 3);



        #endregion

        public string GetHelpAndSupportPopupTitle()
        {
           
            Report.Info("Switching to iFrame");      
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement==null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement TitleElement = HeaderElement.FindElement(By.XPath("//h3[@class='ellipsis lead pull-left form-title']"), 2);
            if (TitleElement == null)
            {
                Report.Info("The title element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            string foundText = TitleElement.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText;
        }

        public bool ConfirmHelpAndSupportFormContentsLoaded()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"),2);
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.WaitUntilElementVisible(By.Id("fd_feedback_widget"), 30);

            if (HeaderElement == null)
            {
                Report.Info("The contents was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmSearchArticlesPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string elText = searchPanelEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return elText=="Search Articles";
        }

        public bool ConfirmSearchIconPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchIconEl = HeaderElement.FindElement(By.XPath("//div[@class='feedback-search-icon text-center']"), 2);
            if (searchIconEl == null)
            {
                Report.Info("The search Icon element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }            
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmCustomerContactEntryFieldPresent()
         {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactEl = mainContentEl.FindElement(By.XPath("//input[@class='span12 email required']"), 2);
            if (customerContactEl == null)
            {
                Report.Info("The Customer Contact Input element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }           
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmCustomerContactLabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactTextEl = mainContentEl.FindElement(By.XPath("//label[contains(@class,'required control-label requester-label') and @for='helpdesk_ticket_email']"), 2);
            if (customerContactTextEl == null)
            {
                Report.Info("The Customer Contact Label element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = customerContactTextEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == "Customer Contact";
        }

        public bool ConfirmSubjectEntryFieldPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            if (customerContactEl == null)
            {
                Report.Info("The Subject Input element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmSubjectLabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactTextEl = mainContentEl.FindElement(By.XPath("//label[contains(@class,'required control-label subject-label') and @for='helpdesk_ticket_subject']"), 2);
            if (customerContactTextEl == null)
            {
                Report.Info("The Subject Label element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = customerContactTextEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == "Subject";
        }

        public bool ConfirmTextDescriptionInputPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement textDescriptionEl = mainContentEl.FindElement(By.XPath("//div[@class='control-group default_description']"), 2);
            if (textDescriptionEl == null)
            {
                Report.Info("The Text Description Input element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
            
        }

        public bool ConfirmNeedAnIngredientInputPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement needAnIngredientEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_custom_field_cf_ingredient_add_request_551112"), 2);
            if (needAnIngredientEl == null)
            {
                Report.Info("The Need An Ingredient Input element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
            
        }

        public bool ConfirmNeedAnIngredientTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement needAnIngredientLabelEl = mainContentEl.FindElement(By.XPath("//label[.//input[contains(@id,'helpdesk_ticket_custom_field_cf_ingredient_add_request_551112')]"), 2);
            if (needAnIngredientLabelEl == null)
            {
                Report.Info("The Need An ingredient label element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = needAnIngredientLabelEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText.ToLower().Contains("need an ingredient");
        }

        public bool CheckHelpAndSupportPopupContainsScrollBar()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            bool startVis = customerContactEl.VisibleInViewport();
            if (!startVis)
            {
                Report.Info("Scrolling to the top of the popup");
                customerContactEl.SendKeys(Keys.PageUp);
                Delay.Seconds(2);
                startVis = customerContactEl.VisibleInViewport();
                if (!startVis)
                {
                    Report.Info($"The customer Conact element was not visible, could not perform scroll check");
                    SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                    return false;
                }
            }
            Report.Info("Scrolling to the bottom of the popup, then checking if the customer contact element is no longer visible");    
            customerContactEl.SendKeys(Keys.PageDown);
            Delay.Seconds(3);
            bool endvis = customerContactEl.VisibleInViewport();
            if(endvis)
            {
                Report.Info($"The customer contact input field was still visible");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            Report.Info($"The customer contact input field was no longer visible");
            return true;

            //IJavaScriptExecutor jse = (IJavaScriptExecutor)SeleniumWebDriver.CurrentDriver;
            //Boolean VertscrollStatus = (Boolean)jse.ExecuteScript("return document.documentElement.scrollHeight>document.documentElement.clientHeight;");

            //IWebElement mainContentEl2 = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal modal-widget modal-panel-active']"), 2);
            //string JS_ELEMENT_IS_SCROLLABLE = "return arguments[0].scrollHeight > arguments[0].offsetHeight;";
            //IJavaScriptExecutor jse=(IJavaScriptExecutor)SeleniumWebDriver.CurrentDriver;
            //bool isScrollable = (bool)jse.ExecuteScript(JS_ELEMENT_IS_SCROLLABLE, mainContentEl2);
            //SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();

            //return isScrollable;

        }

        public bool ConfirmPriorityDropFieldPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_priority"), 2);
            if (priorityDropField == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;

        }

        public bool ConfirmOpenPriorityDropFieldPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_priority"), 2);
            if (priorityDropField == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            priorityDropField.TryClick();
            Delay.Seconds(5);
            Report.Screenshot();
            IWebElement dropDown = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("select2-drop"), 2);
            if (dropDown == null)
            {
                Report.Info("The Open Priority Drop menu element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }            
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            ContainerElement.TryClick();
            Delay.Seconds(3);
            return true;

        }

        public bool ConfirmPriorityLabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement priorityFieldLabel = mainContentEl.FindElement(By.XPath("//label[contains(@class,'control-label priority-label')]"), 2);
            if (priorityFieldLabel == null)
            {
                Report.Info("The Priority Field label element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = priorityFieldLabel.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == "Priority";
        }

        public string GetCurrentPriority()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("select2-chosen-1"), 2);
            if (priorityDropField == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            string currentOption = priorityDropField.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return currentOption;

        }

        public bool ConfirmPriorityLabelContainsOption(string expectedOption)
        {
                       
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            mainContentEl.TryClick();
            IWebElement priorityFieldLabel = mainContentEl.FindElement(By.XPath("//div[@class='select2-container dropdown']"), 2);
            if (priorityFieldLabel == null)
            {
                                
                Report.Info("The Priority Field dropdown element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;

            }
            List<IWebElement> proityFoundOptions = priorityFieldLabel.FindElements(By.XPath("//select[@class='dropdown select2-offscreen']//option"), 2).ToList();
            if (proityFoundOptions.IsNullOrEmpty())
            {
                Report.Info("The Priority Field dropdown element was not null or empty");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement foundOptionEl = proityFoundOptions.First(x => x.Text == expectedOption);
            bool wasFound= !foundOptionEl.IsNullOrEmpty();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return wasFound;
            
        }

        public bool CaptchaContainsIAmNotARobot()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"),2);
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);

            IWebElement secondFrame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@id='captcha_wrap']//iframe"), 2);
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(secondFrame);

            IWebElement thirdFrame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@id='recaptcha']//iframe"),2);           
            /////div[@class='g-recaptcha ']//div//iframe
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(thirdFrame);      
            

            //IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            //if (mainContentEl == null)
            //{
            //    Report.Info("The Main Entry Form was not found");
            //    SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            //    return false;
            //}
            IWebElement captchaTextEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("recaptcha-anchor-label"), 2);
            if (captchaTextEl == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();

                return false;
            }
            string captchaText = captchaTextEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();

            return captchaText == "I'm not a robot";


        }

        public bool ConfirmSubmitButtonPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement footerEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-footer feedback-footer modal-body-change']"), 2);
            if (footerEl == null)
            {
                Report.Info("The Footer Element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement submitButtonEl = footerEl.FindElement(By.Id("helpdesk_ticket_submit"), 2);
            if (submitButtonEl == null)
            {
                Report.Info("The Submit Button element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            if (submitButtonEl.GetAttribute("value") != "Submit")
            {
                Report.Info("The Submit button did not contain text 'Submit'");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            Report.Info("The Submit button did contain text 'Submit'");
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmXIconPresent()
        {
            IWebElement el = this.xIconEl;
            return el != null;
          
        }

        public void ClickXIcon()
        {                     
            this.xIconEl.JsClick();
        }

        public bool ScrollToTopOfPopup()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            customerContactEl.SendKeys(Keys.PageUp);
            bool startVis = customerContactEl.VisibleInViewport();
            if (!startVis)
            {
                Report.Info("Scrolling to the top of the popup");
                customerContactEl.SendKeys(Keys.PageUp);
                Delay.Seconds(2);
                startVis = customerContactEl.VisibleInViewport();
                if (!startVis)
                {
                    Report.Info($"The customer Conact element was not visible, could not scroll");
                    SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                    return false;
                }
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
          

        }

        public bool ScrollToBottomOfPopup()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            customerContactEl.SendKeys(Keys.PageDown);
            Delay.Seconds(2);
            bool startVis = customerContactEl.VisibleInViewport();
            if (startVis)
            {
                Report.Info("Scrolling to the Bottom of the popup");
                customerContactEl.SendKeys(Keys.PageDown);
                Delay.Seconds(2);
                startVis = customerContactEl.VisibleInViewport();
                if (startVis)
                {
                    Report.Info($"The customer Conact element was visible, could not scroll");
                    SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                    return false;
                }
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;


        }


        public void ClickAndDragScrollBarDown()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return;
            }
            IWebElement searchIconEl = HeaderElement.FindElement(By.XPath("//div[@class='feedback-search-icon text-center']"), 2);
            if (searchIconEl == null)
            {
                Report.Info("The search Icon element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return;
            }
           

            Actions actions = new Actions(SeleniumWebDriver.CurrentDriver);
            Delay.Seconds(2);
            actions.MoveToElement(searchIconEl);
            //actions.MoveByOffset(25, 280);
            actions.MoveByOffset(25, 180);
            //actions.ContextClick();
            //actions.ClickAndHold();
            actions.ClickAndHold();
            actions.Perform();
            Report.Screenshot();

            int i = 10;
            while (i < 100)
            {

                actions = new Actions(SeleniumWebDriver.CurrentDriver);
                actions.ClickAndHold();
                actions.Perform();

                Actions actions2 = new Actions(SeleniumWebDriver.CurrentDriver);                
                actions2.MoveByOffset(0, i);                
                actions2.Perform();
                i= i + 20;
                Report.Screenshot();
                Delay.Seconds(2);
                actions.Release();
                actions.Perform();
                Delay.Seconds(2);

            }     
            
            Report.Info("Finished attempting to drag the scroll bar down");
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();

        }


        public void ClickAndDragScrollBarUp()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement footerEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-footer feedback-footer modal-body-change']"), 2);
            if (footerEl == null)
            {
                Report.Info("The Footer Element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return;
            }
            IWebElement submitButtonEl = footerEl.FindElement(By.Id("helpdesk_ticket_submit"), 2);
            if (submitButtonEl == null)
            {
                Report.Info("The Submit Button element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return;
            }
            if (submitButtonEl.GetAttribute("value") != "Submit")
            {
                Report.Info("The Submit button did not contain text 'Submit'");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return;
            }


            Actions actions = new Actions(SeleniumWebDriver.CurrentDriver);
            Delay.Seconds(2);
            actions.MoveToElement(submitButtonEl);
            //actions.MoveByOffset(25, 280);
            actions.MoveByOffset(50, -180);
            //actions.ContextClick();            
            actions.ClickAndHold();
            actions.Perform();
            Report.Screenshot();

            int i = 10;
            while (i < 100)
            {

                actions = new Actions(SeleniumWebDriver.CurrentDriver);
                actions.ClickAndHold();
                actions.Perform();

                Actions actions2 = new Actions(SeleniumWebDriver.CurrentDriver);
                actions2.MoveByOffset(0, -i);
                actions2.Perform();
                i = i + 20;
                Report.Screenshot();
                Delay.Seconds(2);
                actions.Release();
                actions.Perform();
                Delay.Seconds(2);

            }

            Report.Info("Finished attempting to drag the scroll bar down");
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();

        }

        public bool CheckIfContactElVisisble()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            bool startVis = customerContactEl.VisibleInViewport();           
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return startVis;         

           

        }

        public bool CheckIfPrioritytElVisisble()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_priority"), 2);
            bool startVis = priorityDropField.VisibleInViewport();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return startVis;

        }

        public bool ClickSearchArticlesLink()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = searchPanelEl.TryClick();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return clicked;
        }

        public bool CheckSidePanelIsOpen()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']"), 15);
            if (sidePanelEl == null)
            {
                Report.Info("The side panel element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }           
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }


        public bool ConfirmSidePanelSearchText(string expected)
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelSearchInputEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//form[@class='hc-search-form']//input"), 15);
            if (sidePanelSearchInputEl == null)
            {
                Report.Info("The side panel search input element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }                    
            string foundText = sidePanelSearchInputEl.GetAttribute("placeholder");
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == expected;
        }


        public bool ConfirmSidePanelMainBodyText(string expected)
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//h2"), 15);
            if (sidePanelMainBodyEl == null)
            {
                Report.Info("The side panel main body element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = sidePanelMainBodyEl.Text;
            foundText= foundText.Replace("\r\n"," ");
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == expected;
        }

        public bool ConfirmSidePanelMainBodyLinkText(string expected)
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyLinkEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//a"), 15);
            if (sidePanelMainBodyLinkEl == null)
            {
                Report.Info("The side panel main body link element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = sidePanelMainBodyLinkEl.Text;
            foundText = foundText.Replace("\r\n", " ");
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == expected;
        }

        public bool ConfirmSidePanelMainBodyLinkIsLink()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyLinkEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//a"), 15);
            if (sidePanelMainBodyLinkEl == null)
            {
                Report.Info("The side panel main body link element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            Actions actions = new Actions(SeleniumWebDriver.CurrentDriver);
            Delay.Seconds(2);
            actions.MoveToElement(sidePanelMainBodyLinkEl);                  
           
            actions.Perform();
            Report.Info($"MANUAL CHECK SEE SCREENSHOT FOR LINE UNDER THE LINK TEXT");
            Report.Screenshot();

            string foundText = sidePanelMainBodyLinkEl.GetAttribute("href");
            
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return !foundText.IsNullOrEmpty();
        }

        public bool ClickOrBrowseArticlesLink()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyLinkEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//a"), 15);
            if (sidePanelMainBodyLinkEl == null)
            {
                Report.Info("The side panel main body link element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = sidePanelMainBodyLinkEl.TryClick();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return clicked;
        }

        public bool ClickCloseSeearch()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement closeSearchEl = HeaderElement.FindElement(By.XPath("//span[@class='search-help close-article']"), 15);
            if (closeSearchEl == null)
            {
                Report.Info("The Close Search element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = closeSearchEl.TryClick();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return clicked;
        }

        public bool CloseSearchPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement closeSearchEl = HeaderElement.FindElement(By.XPath("//span[@class='search-help close-article']"), 15);
            if (closeSearchEl == null)
            {
                Report.Info("The Close Search element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;
        }

        public bool ClickSubmit()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-footer feedback-footer modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The footer element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sumbitButtonEl = HeaderElement.FindElement(By.Id("helpdesk_ticket_submit"), 15);
            if (sumbitButtonEl == null)
            {
                Report.Info("The Sumbit Button element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = sumbitButtonEl.TryClick();
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return clicked;
        }

        public string GetCustomerContactErrorText()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement customerContactErrorEl = mainContentEl.FindElement(By.XPath("//div[@id='helpdesk_ticket_email-error']"), 2);
            if (customerContactErrorEl == null)
            {
                Report.Info("The Customer Contact error element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            string foundText = customerContactErrorEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText;
        }

        public string GetSubjectErrorText()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement subjectErrorEl = mainContentEl.FindElement(By.XPath("//div[@id='helpdesk_ticket_subject-error']"), 2);
            if (subjectErrorEl == null)
            {
                Report.Info("The Subject error element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            string foundText = subjectErrorEl.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText;
        }


        public bool ConfirmIAmADropDownFieldPresent()
        {

            Report.Info("Switching to iFrame");
            GeneralUtilities.SwitchToFrame($"<contains(@title,'Feedback Form')>");
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement iAmADropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_custom_field_cf_customer_type_551112"), 2);
            if (iAmADropField == null)
            {
                Report.Info("The I am a Drop Field element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return true;

        }

        public bool ConfirmOpenIAmADropDownFieldPresent()
        {

            Report.Info("Switching to iFrame");
            GeneralUtilities.SwitchToFrame($"<contains(@title,'Feedback Form')>");
            // IWebElement HeaderElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement iAmADropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_custom_field_cf_customer_type_551112"), 2);
            if (iAmADropField == null)
            {
                Report.Info("The I am a Drop Field element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            iAmADropField.TryClick();
            Delay.Seconds(5);
            Report.Screenshot();
            IWebElement dropDown = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("select2-drop"), 2);
            if (dropDown == null)
            {
                Report.Info("The Open Priority Drop menu element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            ContainerElement.TryClick();
            Delay.Seconds(3);
            return true;

        }

        public bool ConfirmIAmALabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            GeneralUtilities.SwitchToFrame($"<contains(@title,'Feedback Form')>");
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement iAmAFieldLabel = mainContentEl.FindElement(By.XPath("//label[contains(@class,'required control-label cf_customer_type_551112-label')]"), 2);
            if (iAmAFieldLabel == null)
            {
                Report.Info("The Priority Field label element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = iAmAFieldLabel.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return foundText == "I am a...";
        }

        public string GetHeader()
        {

            Report.Info("Switching to iFrame");
            GeneralUtilities.SwitchToFrame($"<contains(@title,'Feedback Form')>");
            IWebElement mainContentEl = SeleniumWebDriver.CurrentDriver.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement header = mainContentEl.FindElement(By.XPath("//h3[@class='ellipsis lead pull-left form-title']"), 2);
            if (header == null)
            {
                Report.Info("The header element was not found");
                SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
                return null;
            }
            string headerValue = header.Text;
            SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
            return headerValue;

        }

    }

}
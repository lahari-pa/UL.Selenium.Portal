using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class HelpAndSupport : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class='freshwidget-container responsive']//div[@class='freshwidget-dialog']");
        
        private IWebElement PopupHeader => this.containerElement.FindElement(By.XPath($""), 2);

        private IWebElement xIconEl => this.containerElement.FindElement(By.Id("freshwidget-close"), 3);



        #endregion

        public string GetHelpAndSupportPopupTitle()
        {
           
            Report.Info("Switching to iFrame");      
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement==null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement TitleElement = HeaderElement.FindElement(By.XPath("//h3[@class='ellipsis lead pull-left form-title']"), 2);
            if (TitleElement == null)
            {
                Report.Info("The title element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            string foundText = TitleElement.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText;
        }

        public bool ConfirmHelpAndSupportFormContentsLoaded()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"),2);
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.Id("fd_feedback_widget"), 30);

            if (HeaderElement == null)
            {
                Report.Info("The contents was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmSearchArticlesPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string elText = searchPanelEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return elText=="Search Articles";
        }

        public bool ConfirmSearchIconPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchIconEl = HeaderElement.FindElement(By.XPath("//div[@class='feedback-search-icon text-center']"), 2);
            if (searchIconEl == null)
            {
                Report.Info("The search Icon element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }            
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmCustomerContactEntryFieldPresent()
         {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactEl = mainContentEl.FindElement(By.XPath("//input[@class='span12 email required']"), 2);
            if (customerContactEl == null)
            {
                Report.Info("The Customer Contact Input element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }           
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmCustomerContactLabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactTextEl = mainContentEl.FindElement(By.XPath("//label[contains(@class,'required control-label requester-label') and @for='helpdesk_ticket_email']"), 2);
            if (customerContactTextEl == null)
            {
                Report.Info("The Customer Contact Label element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = customerContactTextEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText == "Customer Contact";
        }

        public bool ConfirmSubjectEntryFieldPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            if (customerContactEl == null)
            {
                Report.Info("The Subject Input element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
        }

        public bool ConfirmSubjectLabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement customerContactTextEl = mainContentEl.FindElement(By.XPath("//label[contains(@class,'required control-label subject-label') and @for='helpdesk_ticket_subject']"), 2);
            if (customerContactTextEl == null)
            {
                Report.Info("The Subject Label element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = customerContactTextEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText == "Subject";
        }

        public bool ConfirmTextDescriptionInputPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement textDescriptionEl = mainContentEl.FindElement(By.XPath("//div[@class='control-group default_description']"), 2);
            if (textDescriptionEl == null)
            {
                Report.Info("The Text Description Input element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
            
        }

        public bool ConfirmNeedAnIngredientInputPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement needAnIngredientEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_custom_field_cf_please_provide_details_of_your_ingredient_request_551112"), 2);
            if (needAnIngredientEl == null)
            {
                Report.Info("The Need An Ingredient Input element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
            
        }

        public bool ConfirmNeedAnIngredientTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement needAnIngredientLabelEl = mainContentEl.FindElement(By.XPath("//label[contains(@class,'control-label cf_please_provide_details_of_your_ingredient_request_551112-label')]"), 2);
            if (needAnIngredientLabelEl == null)
            {
                Report.Info("The Need An ingredient label element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = needAnIngredientLabelEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText.Contains("Need an Ingredient");
        }

        public bool CheckHelpAndSupportPopupContainsScrollBar()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
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
                    SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
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
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            Report.Info($"The customer contact input field was no longer visible");
            return true;

            //IJavaScriptExecutor jse = (IJavaScriptExecutor)SeleniumBrowser.WebBrowser;
            //Boolean VertscrollStatus = (Boolean)jse.ExecuteScript("return document.documentElement.scrollHeight>document.documentElement.clientHeight;");

            //IWebElement mainContentEl2 = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal modal-widget modal-panel-active']"), 2);
            //string JS_ELEMENT_IS_SCROLLABLE = "return arguments[0].scrollHeight > arguments[0].offsetHeight;";
            //IJavaScriptExecutor jse=(IJavaScriptExecutor)SeleniumBrowser.WebBrowser;
            //bool isScrollable = (bool)jse.ExecuteScript(JS_ELEMENT_IS_SCROLLABLE, mainContentEl2);
            //SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

            //return isScrollable;

        }

        public bool ConfirmPriorityDropFieldPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_priority"), 2);
            if (priorityDropField == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;

        }

        public bool ConfirmOpenPriorityDropFieldPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_priority"), 2);
            if (priorityDropField == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            priorityDropField.TryClick();
            Delay.Seconds(5);
            Report.Screenshot();
            IWebElement dropDown = SeleniumBrowser.WebBrowser.FindElement(By.Id("select2-drop"), 2);
            if (dropDown == null)
            {
                Report.Info("The Open Priority Drop menu element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }            
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            this.containerElement.TryClick();
            Delay.Seconds(3);
            return true;

        }

        public bool ConfirmPriorityLabelTextPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement priorityFieldLabel = mainContentEl.FindElement(By.XPath("//label[contains(@class,'control-label priority-label')]"), 2);
            if (priorityFieldLabel == null)
            {
                Report.Info("The Priority Field label element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = priorityFieldLabel.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText == "Priority";
        }

        public string GetCurrentPriority()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("select2-chosen-1"), 2);
            if (priorityDropField == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            string currentOption = priorityDropField.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return currentOption;

        }

        public bool ConfirmPriorityLabelContainsOption(string expectedOption)
        {
                       
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            mainContentEl.TryClick();
            IWebElement priorityFieldLabel = mainContentEl.FindElement(By.XPath("//div[@class='select2-container dropdown']"), 2);
            if (priorityFieldLabel == null)
            {
                                
                Report.Info("The Priority Field dropdown element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;

            }
            List<IWebElement> proityFoundOptions = priorityFieldLabel.FindElements(By.XPath("//select[@class='dropdown` select2-offscreen']//option"), 2).ToList();
            if (proityFoundOptions.IsNullOrEmpty())
            {
                Report.Info("The Priority Field dropdown element was not null or empty");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement foundOptionEl = proityFoundOptions.First(x => x.Text == expectedOption);
            bool wasFound= !foundOptionEl.IsNullOrEmpty();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return wasFound;
            
        }

        public bool CaptchaContainsIAmNotARobot()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"),2);
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);

            IWebElement secondFrame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='captcha_wrap']//iframe"), 2);
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(secondFrame);

            IWebElement thirdFrame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='recaptcha']//iframe"),2);           
            /////div[@class='g-recaptcha ']//div//iframe
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(thirdFrame);      
            

            //IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            //if (mainContentEl == null)
            //{
            //    Report.Info("The Main Entry Form was not found");
            //    SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            //    return false;
            //}
            IWebElement captchaTextEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("recaptcha-anchor-label"), 2);
            if (captchaTextEl == null)
            {
                Report.Info("The Priority Drop Field element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

                return false;
            }
            string captchaText = captchaTextEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

            return captchaText == "I'm not a robot";


        }

        public bool ConfirmSubmitButtonPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement footerEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-footer feedback-footer modal-body-change']"), 2);
            if (footerEl == null)
            {
                Report.Info("The Footer Element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement submitButtonEl = footerEl.FindElement(By.Id("helpdesk_ticket_submit"), 2);
            if (submitButtonEl == null)
            {
                Report.Info("The Submit Button element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            if (submitButtonEl.GetAttribute("value") != "Submit")
            {
                Report.Info("The Submit button did not contain text 'Submit'");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            Report.Info("The Submit button did contain text 'Submit'");
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
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
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
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
                    SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                    return false;
                }
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
          

        }

        public bool ScrollToBottomOfPopup()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
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
                    SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                    return false;
                }
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;


        }


        public void ClickAndDragScrollBarDown()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return;
            }
            IWebElement searchIconEl = HeaderElement.FindElement(By.XPath("//div[@class='feedback-search-icon text-center']"), 2);
            if (searchIconEl == null)
            {
                Report.Info("The search Icon element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return;
            }
           

            Actions actions = new Actions(SeleniumBrowser.WebBrowser);
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

                actions = new Actions(SeleniumBrowser.WebBrowser);
                actions.ClickAndHold();
                actions.Perform();

                Actions actions2 = new Actions(SeleniumBrowser.WebBrowser);                
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
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

        }


        public void ClickAndDragScrollBarUp()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement footerEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-footer feedback-footer modal-body-change']"), 2);
            if (footerEl == null)
            {
                Report.Info("The Footer Element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return;
            }
            IWebElement submitButtonEl = footerEl.FindElement(By.Id("helpdesk_ticket_submit"), 2);
            if (submitButtonEl == null)
            {
                Report.Info("The Submit Button element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return;
            }
            if (submitButtonEl.GetAttribute("value") != "Submit")
            {
                Report.Info("The Submit button did not contain text 'Submit'");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return;
            }


            Actions actions = new Actions(SeleniumBrowser.WebBrowser);
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

                actions = new Actions(SeleniumBrowser.WebBrowser);
                actions.ClickAndHold();
                actions.Perform();

                Actions actions2 = new Actions(SeleniumBrowser.WebBrowser);
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
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

        }

        public bool CheckIfContactElVisisble()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement customerContactEl = mainContentEl.FindElement(By.Id("helpdesk_ticket_subject"), 2);
            bool startVis = customerContactEl.VisibleInViewport();           
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return startVis;         

           

        }

        public bool CheckIfPrioritytElVisisble()
        {
            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }

            IWebElement priorityDropField = mainContentEl.FindElement(By.Id("s2id_helpdesk_ticket_priority"), 2);
            bool startVis = priorityDropField.VisibleInViewport();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return startVis;

        }

        public bool ClickSearchArticlesLink()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement searchPanelEl = HeaderElement.FindElement(By.XPath("//div[@class='pull-right search-panel']"), 2);
            if (searchPanelEl == null)
            {
                Report.Info("The search panel element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = searchPanelEl.TryClick();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return clicked;
        }

        public bool CheckSidePanelIsOpen()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']"), 15);
            if (sidePanelEl == null)
            {
                Report.Info("The side panel element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }           
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
        }


        public bool ConfirmSidePanelSearchText(string expected)
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelSearchInputEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//form[@class='hc-search-form']//input"), 15);
            if (sidePanelSearchInputEl == null)
            {
                Report.Info("The side panel search input element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }                    
            string foundText = sidePanelSearchInputEl.GetAttribute("placeholder");
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText == expected;
        }


        public bool ConfirmSidePanelMainBodyText(string expected)
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//h2"), 15);
            if (sidePanelMainBodyEl == null)
            {
                Report.Info("The side panel main body element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = sidePanelMainBodyEl.Text;
            foundText= foundText.Replace("\r\n"," ");
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText == expected;
        }

        public bool ConfirmSidePanelMainBodyLinkText(string expected)
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyLinkEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//a"), 15);
            if (sidePanelMainBodyLinkEl == null)
            {
                Report.Info("The side panel main body link element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            string foundText = sidePanelMainBodyLinkEl.Text;
            foundText = foundText.Replace("\r\n", " ");
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText == expected;
        }

        public bool ConfirmSidePanelMainBodyLinkIsLink()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyLinkEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//a"), 15);
            if (sidePanelMainBodyLinkEl == null)
            {
                Report.Info("The side panel main body link element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            Actions actions = new Actions(SeleniumBrowser.WebBrowser);
            Delay.Seconds(2);
            actions.MoveToElement(sidePanelMainBodyLinkEl);                  
           
            actions.Perform();
            Report.Info($"MANUAL CHECK SEE SCREENSHOT FOR LINE UNDER THE LINK TEXT");
            Report.Screenshot();

            string foundText = sidePanelMainBodyLinkEl.GetAttribute("href");
            
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return !foundText.IsNullOrEmpty();
        }

        public bool ClickOrBrowseArticlesLink()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sidePanelMainBodyLinkEl = HeaderElement.FindElement(By.XPath("//div[@class='modal-panel suggest-panel feedback-suggest-change']//div[@id='panel-info']//a"), 15);
            if (sidePanelMainBodyLinkEl == null)
            {
                Report.Info("The side panel main body link element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = sidePanelMainBodyLinkEl.TryClick();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return clicked;
        }

        public bool ClickCloseSeearch()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement closeSearchEl = HeaderElement.FindElement(By.XPath("//span[@class='search-help close-article']"), 15);
            if (closeSearchEl == null)
            {
                Report.Info("The Close Search element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = closeSearchEl.TryClick();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return clicked;
        }

        public bool CloseSearchPresent()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header feedback-header modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The header element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement closeSearchEl = HeaderElement.FindElement(By.XPath("//span[@class='search-help close-article']"), 15);
            if (closeSearchEl == null)
            {
                Report.Info("The Close Search element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return true;
        }

        public bool ClickSubmit()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-footer feedback-footer modal-body-change']"), 2);
            if (HeaderElement == null)
            {
                Report.Info("The footer element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            IWebElement sumbitButtonEl = HeaderElement.FindElement(By.Id("helpdesk_ticket_submit"), 15);
            if (sumbitButtonEl == null)
            {
                Report.Info("The Sumbit Button element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return false;
            }
            bool clicked = sumbitButtonEl.TryClick();
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return clicked;
        }

        public string GetCustomerContactErrorText()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement customerContactErrorEl = mainContentEl.FindElement(By.XPath("//div[@id='helpdesk_ticket_email-error']"), 2);
            if (customerContactErrorEl == null)
            {
                Report.Info("The Customer Contact error element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            string foundText = customerContactErrorEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText;
        }

        public string GetSubjectErrorText()
        {

            Report.Info("Switching to iFrame");
            IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[@title='Feedback Form']"));
            SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
            // IWebElement HeaderElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-header-bg']//h3[@class='ellipsis lead pull-left form-title']"), 2);
            IWebElement mainContentEl = SeleniumBrowser.WebBrowser.FindElement(By.Id("fd_feedback_widget"), 2);
            if (mainContentEl == null)
            {
                Report.Info("The Main Entry Form was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            IWebElement subjectErrorEl = mainContentEl.FindElement(By.XPath("//div[@id='helpdesk_ticket_subject-error']"), 2);
            if (subjectErrorEl == null)
            {
                Report.Info("The Subject error element was not found");
                SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
                return null;
            }
            string foundText = subjectErrorEl.Text;
            SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
            return foundText;
        }


    }

}
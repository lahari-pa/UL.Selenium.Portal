using Reqnroll;
using System.Collections.Generic;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "HelpAndSupport")]
    class Steps_HelpAndSupport
    {
        [RegexStepDefinition(@"I Confirm the Help & Support Popup is displayed")]
        public void HelpAndSupportPopupDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new HelpAndSupport().WaitForContainerToBeVisible(), "Help & Support Popup did not load", "Help & Support Popup loaded");
            Report.IsTrue(new HelpAndSupport().GetHelpAndSupportPopupTitle() == "Help & Support", "The Popup did not have the title: 'Help & Support", "The Popup did contain the title: 'Help & Support");
            Report.IsTrue(new HelpAndSupport().ConfirmHelpAndSupportFormContentsLoaded(), "The Help & Support main contents was not loaded", "The Help & Support main contents was loaded");
        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup is not displayed")]
        public void HelpAndSupportPopupNotDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new HelpAndSupport().WaitForContainerToBeInvisible(), "Help & Support Popup was showing", "Help & Support Popup was not showing");

        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the text 'Search Articles' in the header")]
        public void ConfirmTheHelpAndSupportPopupContainsTheTextSearchArticlesInTheHeader()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSearchArticlesPresent(), "The Help & Support Popup header did not contain 'Search Articles'", "The Help & Support Popup header did contain 'Search Articles'");

        }


        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the Search Icon in the header")]
        public void ConfirmTheHelpAndSupportPopupContainsTheSearchIconInTheHeader()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSearchIconPresent(), "The Help & Support Popup did not contain the search Icon", "The Help & Support header did contain the search Icon");

        }


        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the Customer Contact Input Field")]
        public void ConfirmTheHelpAndSupportPopupContainsTheCustomerContactInputField()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmCustomerContactEntryFieldPresent(), "The Help & Support Popup did not contain the Customer Contact Input Field", "The Help & Support Popup did contain the Customer Contact Input Field");
            Report.IsTrue(new HelpAndSupport().ConfirmCustomerContactLabelTextPresent(), "The Help & Support Popup did not contain the label text 'Customer Contact'", "The Help & Support Popup did contain the label text 'Customer Contact'");
        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the Subject Input Field")]
        public void ConfirmTheHelpAndSupportPopupContainsTheSubjectInputField()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSubjectEntryFieldPresent(), "The Help & Support Popup did not contain the Subject Input Field", "The Help & Support Popup did contain the Subject Input Field");
            Report.IsTrue(new HelpAndSupport().ConfirmSubjectLabelTextPresent(), "The Help & Support Popup did not contain the label text 'Subject'", "The Help & Support Popup did contain the label text 'Subject'");


        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the Text Decription Field")]
        public void ConfirmTheHelpAndSupportPopupContainsTheTextDescriptionField()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmTextDescriptionInputPresent(), "The Help & Support Popup did not contain the Text Description Field", "The Help & Support Popup did contain the Text Description Field");

        }


        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the Need an Ingredient area")]
        public void ConfirmTheHelpAndSupportPopupContainsTheNeedAnIngredientArea()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmNeedAnIngredientInputPresent(), "The Help & Support Popup did not contain the Need an Ingredient area", "The Help & Support Popup did contain the Need an Ingredient area");
            Report.IsTrue(new HelpAndSupport().ConfirmNeedAnIngredientTextPresent(), "The Help & Support Popup did not contain the label text 'Need an Ingredient'", "The Help & Support Popup did contain the label text 'Need an Ingredient'");
            new HelpAndSupport().CheckHelpAndSupportPopupContainsScrollBar();

        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup can be scrolled to the bottom")]
        public void ConfirmTheHelpAndSupportPopupCanBeScrolledToTheBottom()
        {
            Report.IsTrue(new HelpAndSupport().CheckHelpAndSupportPopupContainsScrollBar(), "The Help & Support Popup was not correctly scrolled to the bottom", "The Help & Support Popup was correctly scrolled to the bottom");

        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the Priority Input Field")]
        public void ConfirmTheHelpAndSupportPopupContainsThePriorityInputField()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmPriorityDropFieldPresent(), "The Help & Support Popup did not contain the Priority Input Field", "The Help & Support Popup did contain the Priority Input Field");
            Report.IsTrue(new HelpAndSupport().ConfirmPriorityLabelTextPresent(), "The Help & Support Popup did not contain the label text 'Priority'", "The Help & Support Popup did contain the label text 'Priority'");
            Delay.Seconds(5);
            Report.IsTrue(new HelpAndSupport().ConfirmOpenPriorityDropFieldPresent(), "The Help & Support Popup did not contain the open Priority drop down menu", "The Help & Support Popup did contain the open Priority drop down menu");


        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the currently selected Priority option of: (.*)")]
        public void ConfirmTheHelpAndSupportPopupContainsThePriorityInputField(string expectedPriority)
        {
            Report.IsTrue(new HelpAndSupport().GetCurrentPriority() == expectedPriority, "The Help & Support Popup did not contain the expected currently selected Priority", "The Help & Support Popup did contain the expected currently selected Priority");


        }

        [RegexStepDefinition(@"I Confirm in the Help & Support Popup, the Priority Drop down displays the following options:")]
        public void ConfirmTheHelpAndSupportPopupPriorityOptions(Table table)
        {
            Delay.Seconds(5);
            List<string> options = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                options.Add(thisRow["Options"]);
            }
            foreach (var option in options)
            {
                Report.IsTrue(new HelpAndSupport().ConfirmPriorityLabelContainsOption(option), "The Help & Support Popup priority drop down did not contain the expected option: " + option, "The Help & Support Popup priority drop down did contain the expected option: " + option);

            }


        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the a captcha with text 'I'm not a robot'")]
        public void ConfirmTheHelpAndSupportPopupContainCaptchaWithImNotARobot()
        {
            Report.IsTrue(new HelpAndSupport().CaptchaContainsIAmNotARobot(), "The Help & Support Popup did not contain a captcha with text 'I'm not a robot'", "The Help & Support Popup did contain a captcha with text 'I'm not a robot'");


        }


        [RegexStepDefinition(@"I Confirm the Help & Support Popup footer contains a Submit Button")]
        public void ConfirmTheHelpAndSupportPopupFooterContainsASubmitButton()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSubmitButtonPresent(), "The Help & Support Popup footer did not contain a submit button", "The Help & Support Popup footer did contain a submit button");

        }


        [RegexStepDefinition(@"I Confirm the Help & Support Popup Contains an X Icon")]
        public void ConfirmTheHelpAndSupportPopupContainsXIcon()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmXIconPresent(), "The Help & Support Popup did not contain an X Icon", "The Help & Support Popup did contain an X Icon");

        }

        [RegexStepDefinition(@"In the Help & Support Popup I click the X Icon")]
        public void ClickTheIconInTheHelpAndSupportPopup()
        {
            Report.Info("Attempting to click the X Icon in the Help & Support Popup");
            new HelpAndSupport().ClickXIcon();
        }

        [RegexStepDefinition(@"In The Help & Support Popup I perform 107996 MANUAL LAYOUT CHECKS using screenshots")]
        public void InTheHelpAndSupportPopupPerform107996MANUALLAYOUTCHECKS()
        {
            ReportSettings.UseSubSteps = true;
            //scroll to the top of the popup
            Report.StartStep("Scrolling to the top of the popup");
            Report.IsTrue(new HelpAndSupport().ScrollToTopOfPopup(), "Failed to scroll to the top of the popup", "Successfully scrolled to the top of the popup");

            Report.StartStep("The RPS Homepage Screen is showing in the background");
            Report.Screenshot();

            Report.StartStep("In the Popup There is a X Icon at the top left of the popup");
            Report.Screenshot();

            Report.StartStep("The title Help & Support is showing in the top left of the popup header");
            Report.Screenshot();

            Report.StartStep("The text: 'Search Articles' was in the top right of the popup header");
            Report.Screenshot();

            Report.StartStep("To the right of the text: 'Search Articles' is the search icon");
            Report.Screenshot();

            Report.StartStep("Below the heading area I see the field: Customer Contact");
            Report.Screenshot();

            Report.StartStep("Below the heading area I see the field: Subject");
            Report.Screenshot();

            Report.StartStep("Below the heading area I see the field: Descritption Text");
            Report.Screenshot();

            //scroll to bottom of popup
            Report.StartStep("Scrolling to the Bottom of the popup");
            Report.IsTrue(new HelpAndSupport().ScrollToBottomOfPopup(), "Failed to scroll to the bottom of the popup", "Successfully scrolled to the bottom of the popup");

            Report.StartStep("Below the heading area I see the field: Need an ingredient");
            Report.Screenshot();

            Report.StartStep("Below the heading area I see the field: Priority");
            Report.Screenshot();

            Report.StartStep("Below the heading area I see a Captcha");
            Report.Screenshot();

            Report.StartStep("In the Popup footer I see the Submit button");
            Report.Screenshot();

            Report.StartStep("To the right of the popup there is a scroll/slide bar");
            Report.Screenshot();

            Report.StartStep("Belowthe Priority field I see the I am a field with a drop down list");
            Report.Screenshot();

        }

        [RegexStepDefinition(@"In the Help & Support Popup I click the scroll bar")]
        public void ClickScrollBarInTheHelpAndSupportPopup()
        {
            Report.Info("Attempting to click the Scroll bar in the Help & Support Popup");
            new HelpAndSupport().ClickAndDragScrollBarDown();
        }

        [RegexStepDefinition(@"In the Help & Support Popup I Check that the mouse can drag the scroll bar up and down")]
        public void CheckMouseCanDragScrollBarInTheHelpAndSupportPopup()
        {

            Report.Info("Attempting to drag the Scroll bar down in the Help & Support Popup");
            new HelpAndSupport().ClickAndDragScrollBarDown();
            Report.IsTrue(!new HelpAndSupport().CheckIfContactElVisisble(), "The Help & Support Popup did  show the Customer Contact Input Field on screen", "The Help & Support Popup did not show the Customer Contact Input Field on screen");
            Report.IsTrue(new HelpAndSupport().CheckIfPrioritytElVisisble(), "The Help & Support Popup did not show the Priority Input Field on screen", "The Help & Support Popup did show the Priority Input Field on screen");

            Report.Info("Attempting to drag the Scroll bar up in the Help & Support Popup");
            new HelpAndSupport().ClickAndDragScrollBarUp();
            Report.IsTrue(new HelpAndSupport().CheckIfContactElVisisble(), "The Help & Support Popup did not show the Customer Contact Input Field on screen", "The Help & Support Popup did show the Customer Contact Input Field on screen");
            Report.IsTrue(!new HelpAndSupport().CheckIfPrioritytElVisisble(), "The Help & Support Popup did show the Priority Input Field on screen", "The Help & Support Popup did not show the Priority Input Field on screen");



        }

        [RegexStepDefinition(@"In the Help & Support Popup I Click the search articles link")]
        public void InTheHelpAndSupportPopupIClickSearchArticlesLink()
        {
            Report.IsTrue(new HelpAndSupport().ClickSearchArticlesLink(), "Failed to click the link", "Succesfully clicked the link");

        }

        [RegexStepDefinition(@"In the Help & Support Popup I Check that the side panel is open")]
        public void InTheHelpAndSupportPopupICheckTheSidePanelIsOpen()
        {
            Report.IsTrue(new HelpAndSupport().CheckSidePanelIsOpen(), "The side panel was not open", "The side panel was open");


        }

        [RegexStepDefinition(@"In the Help & Support Popup I confirm that the the side panel input box contains placeholder text: (.*)")]
        public void InTheHelpAndSupportPopupICheckSidePanelInputPlaceholderText(string exptected)
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSidePanelSearchText(exptected), "The side panel input placeholder text did not match", "The side panel input placeholder text did match");

        }

        [RegexStepDefinition(@"In the Help & Support Popup I confirm that the the side panel Main body contains text: (.*)")]
        public void InTheHelpAndSupportPopupICheckSidePanelMainBodyText(string exptected)
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSidePanelMainBodyText(exptected), "The side panel main body text did not match", "The side panel main body text did match");

        }

        [RegexStepDefinition(@"In the Help & Support Popup I confirm that the the side panel Main body link contains text: (.*)")]
        public void InTheHelpAndSupportPopupICheckSidePanelMainBodyLinkText(string exptected)
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSidePanelMainBodyLinkText(exptected), "The side panel main body link text did not match", "The side panel main body link text did match");

        }

        [RegexStepDefinition(@"MANUAL STEP - In the Help & Support Popup I confirm that the the side panel Main body link is a link")]
        public void InTheHelpAndSupportPopupICheckSidePanelMainBodyLinkIsALink()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmSidePanelMainBodyLinkIsLink(), "The side panel main body link text did not contain a link", "The side panel main body link text contained a link");

        }

        [RegexStepDefinition(@"In the Help & Support Popup I Click the or Browse articles link")]
        public void InTheHelpAndSupportPopupIClickOrBrowseArticlesLink()
        {
            Report.IsTrue(new HelpAndSupport().ClickOrBrowseArticlesLink(), "Failed to click the or Browse articles Link", "Successfully clicked the or Browse articles Link");

        }


        [RegexStepDefinition(@"In the Help & Support Popup The Close Search button is present")]
        public void InTheHelpAndSupportPopupTheCloseSearchButtonIsPresent()
        {
            Report.IsTrue(new HelpAndSupport().CloseSearchPresent(), "The Close search button was not found", "The close search button was found");



        }

        [RegexStepDefinition(@"In the Help & Support Popup I Click the close search button")]
        public void InTheHelpAndSupportPopupIClickTheCloseSearchButton()
        {
            Report.IsTrue(new HelpAndSupport().ClickCloseSeearch(), "Failed to click the Close Search Button", "Successfully clicked Close Search Button");
        }

        [RegexStepDefinition(@"In The Help & Support Popup I perform 108014 MANUAL LAYOUT CHECKS using screenshots")]
        public void InTheHelpAndSupportPopupPerform108014MANUALLAYOUTCHECKS()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the new panel and the top of the pop up, I confirm I see: Search ");
            Report.Screenshot();

            Report.StartStep("In the new panel, below the search field, I confirm I see: Search our Knowledge base");
            Report.Screenshot();

            Report.StartStep("In the new panel below Search our knowledge base, I confirm I see: or Browse articles");
            Report.Screenshot();

            Report.StartStep("I confirm or Browse articles is shown with a blue underline indicating it is a link");
            Report.Screenshot();

            Report.StartStep("In the Help & Support pop up, where I initially saw Search articles, I confirm I see: Close search");
            Report.Screenshot();

        }

        [RegexStepDefinition(@"In The Help & Support Popup I perform 108015 MANUAL LAYOUT CHECKS using screenshots")]
        public void InTheHelpAndSupportPopupPerform108015MANUALLAYOUTCHECKS()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I confirm there is an error displaying below the customer contact field that reads: Please enter a valid email address.");
            Report.Screenshot();

            Report.StartStep("I confirm there is an error displaying below the Subject field: This field is required.");
            Report.Screenshot();



        }



        [RegexStepDefinition(@"In the Help & Support Popup I Click the Submit button")]
        public void InTheHelpAndSupportPopupIClickTheSubmitButton()
        {
            Report.IsTrue(new HelpAndSupport().ClickSubmit(), "Failed to click the Submit Button", "Successfully clicked Submit Button");
        }

        [RegexStepDefinition(@"In the Help & Support Popup I confirm there is an error displaying below the customer contact field that reads: (.*)")]
        public void InTheHelpAndSupportPopupIConfirmThereIsAnErrorBelowTheCustomerContactField(string errorText)
        {
            string foundText = new HelpAndSupport().GetCustomerContactErrorText();
            Report.Info($"The found error text was: {foundText}");
            Report.IsTrue(foundText == errorText, "The error text found was not a match", "The error text found was a match");
        }

        [RegexStepDefinition(@"In the Help & Support Popup I confirm there is an error displaying below the Subject field: (.*)")]
        public void InTheHelpAndSupportPopupIConfirmThereIsAnErrorBelowTheSubjectField(string errorText)
        {
            string foundText = new HelpAndSupport().GetSubjectErrorText();
            Report.Info($"The found error text was: {foundText}");
            Report.IsTrue(foundText == errorText, "The error text found was not a match", "The error text found was a match");
        }

        [RegexStepDefinition(@"I Confirm the Help & Support Popup contains the I am a dropdown Field")]
        public void ConfirmTheHelpAndSupportPopupContainsTheIAmADropdownField()
        {
            Report.IsTrue(new HelpAndSupport().ConfirmIAmADropDownFieldPresent(), "The Help & Support Popup did not contain the I am a dropdown Field", "The Help & Support Popup did contain the I am a dropdown Field");
            Report.IsTrue(new HelpAndSupport().ConfirmIAmALabelTextPresent(), "The Help & Support Popup did not contain the label text 'I am a'", "The Help & Support Popup did contain the label text 'I am a'");
            Delay.Seconds(5);
            Report.IsTrue(new HelpAndSupport().ConfirmOpenIAmADropDownFieldPresent(), "The Help & Support Popup did not contain the open I am a drop down menu", "The Help & Support Popup did contain the open I am a drop down menu");
        }

        [RegexStepDefinition(@"In the Help & Support pop up, I confirm the heading shows: (.*)")]
        public void ConfirmTheHelpAndSupportPopupHeadingShowsHelpAndSupport(string heading)
        {

            Report.IsTrue(new HelpAndSupport().GetHeader() == heading, "The Help & Support Popup does not contain Help & support heading", "The Help & Support Popup contain Help & support heading");

        }



    }


}

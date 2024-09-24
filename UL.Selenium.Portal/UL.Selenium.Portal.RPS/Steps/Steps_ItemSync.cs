using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "ItemSync")]
    class Steps_ItemSync
    {
        [RegexStepDefinition(@"I confirm the ItemSync manual entry screen is shown with the title: (.*)")]
        public void ConfirmItemSyncManualEntryScreenShownWithTitle(string title)
        {
            Report.IsTrue(new ItemSync().GetCurrentPageTitle() == "Add UPC", "The Page title was not as expected", "The page title was as expected");
            Report.IsTrue(new ItemSync().UPCInputBoxPresent(),"The UPC input box was not present","The UPC input box was present");
        }

        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen is shown")]
        public void ConfirmItemSyncUploadAFileScreenIsShown()
        {
            Report.IsTrue(new ItemSync().ContainsMainTextBox(), "The Main Text Box was not found", "The MainText box was found");
            Report.IsTrue(new ItemSync().ContainsUploadBoxSection(), "The Upload Box was not found as an element", "The upload box was found  as an element"); 
            Report.IsTrue(new ItemSync().UploadBoxSectionDisplayed(), "The Upload Box was not displayed", "The upload box was displayed"); 

        }

        [RegexStepDefinition(@"I wait for the ItemSync Upload a File screen to load")]
        public void WaitForUploadAFileScreenToLoad()
        {
            Report.IsTrue(new ItemSync().WaitUntilUploadAFilePageLoaded(), "The page did not load", "The page has loaded");
        }

        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen displays the message: (.*)")]
        public void ConfirmItemSyncUploadAFileScreenDisplaysTheMessage(string expectedText)
        {
            Report.IsTrue(new ItemSync().MainTextBoxContainsText(expectedText), "The screen did not display the expected text", "The screen did display the expected text");
        }


        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen shows a File Upload Area")]
        public void ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea()
        {
            Report.IsTrue(new ItemSync().ContainsUploadBoxSection(), "The Upload Box was not found", "The upload box was found");
            Report.IsTrue(new ItemSync().UploadBoxSectionDisplayed(), "The Upload Box was not displayed", "The upload box was displayed");

        }

        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen does not show a File Upload Area")]
        public void ConfirmItemSyncUploadAFileScreenDoesNotShowAFileUploadArea()
        {
            if (new ItemSync().ContainsUploadBoxSection())
            {
                Report.IsTrue(!new ItemSync().UploadBoxSectionDisplayed(), "The Upload Box was not displayed", "The upload box was displayed");

            }
            Report.Success("The Upload Box was not found");
        }


        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen, File Upload Area shows a drag and drop area")]
        public void ConfirmItemSyncUploadAFileScreenFileUploadAreaShowsDragAndDropArea()
        {
            Report.IsTrue(new ItemSync().GetUploadBoxElementClass().Contains("dropzone"), "The Upload Box area did not contain a drag and drop area", "The Upload Box area did contain a drag and drop area");
        }

        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen, File Upload Area shows The Description Text: (.*)")]
        public void ConfirmItemSyncUploadAFileScreenFileUploadAreaShowsDescriptionText(string expectedText)
        {
            Report.IsTrue(new ItemSync().UploadBoxDescriptionContains(expectedText), "The Upload Box area did not contain the description text", "The Upload Box area did contain the description text");
        }


        [RegexStepDefinition(@"I confirm the ItemSync Upload a File screen, File Upload Area contains a browse Link")]
        public void ConfirmItemSyncUploadAFileScreenFileUploadAreaContainsABrowseLink()
        {
            Report.Failure($"Need to revisit this step. The test case indicates that the 'Drag file here or browse' text should be a link, but the browse button is the whole box");

        }

        [RegexStepDefinition(@"I check file browser")]
        public void ICheckFileBrowser()
        {
            // new ItemSync().DebugFileBrowser();
            Report.Failure($"Reporting out Failure while I am unsure how to check file browser is open, is checking upload section exists sufficent (correct xpath attribute checked?)");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I click the File Upload area and open the File: (.*)")]
        public void UploadPDFFileSectionAndType(string fileName)
        
        {
            Report.IsTrue(GeneralUtilities.DeleteFileFromDownloadsFolder(fileName), "", "");
            string path = "UL.Selenium.Portal.RPS.Dependencies.CSV." + fileName;

            EmbeddedResources.ExtractToFile(path, out string destination);


            //fileName = EmbeddedResources.ExtractToFile(destination, out string extractFile) ? extractFile : fileName;
            Report.IsTrue(new ItemSync().UploadFileToUploadAFileArea(destination,fileName), "Failed to upload file: " + destination, "Successfully uploaded file: " + destination);

        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm below the user message area, I see a file icon")]
        public void InTheItemSyncUploadFileScreenIConfirmBelowUserMessageAreaISeeFileIcon()

        {            
            Report.IsTrue(new ItemSync().FileIconDisplayed(), "Failed to find the file icon", "Successfully found the file icon");

        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm The selected filename shows as: (.*)")]
        public void InTheItemSyncUploadFileScreenIConfirmSelectedFileName(string fileName)

        {
            Report.IsTrue(new ItemSync().CheckUploadedFileName(fileName), "The Filename did not match", "The filename was a match!");

        }
        

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I see the upload button")]
        public void InTheItemSyncUploadFileScreenIConfirmISeeUploadButton()

        {
            Report.IsTrue(new ItemSync().UploadButtonDisplayed(), "Failed to find the Upload Button", "Successfully found the Upload Button");

        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I see the Upload Loading indicator")]
        public void InTheItemSyncUploadFileScreenISeeTheUploadLoadingIndicator()
        {
            Report.IsTrue(new ItemSync().UploadingLoadingIconPresent(), "Failed to find the loading indicator", "Successfully found the loading indicator");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I click the 'Upload' button")]
        public void InTheItemSyncUploadAFileScreenIClickTheUploadButton()
        {

            Report.IsTrue(new ItemSync().UploadButtonClicked(), "Faild to Click the upload button", "Successfully clicked the upload button");
        }


        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I wait for the Upload Loading indicator to finish")]
        public void InTheItemSyncUploadFileScreenIWaitForTheUploadLoadingIndicatorToFinish()
        {
            Report.IsTrue(new ItemSync().WaitForUploadLoadToFinish(), "Was still loading after 60 seconds", "Loading has finished");

        }

        [RegexStepDefinition(@"I wait for the ItemSync Manual Entry screen to load")]
        public void WaitFoItemSyncManualEntryScreenToLoad()
        {
            Report.IsTrue(new ItemSync().WaitUntilManuaEntryPageLoaded(), "The page did not load", "The page has loaded");
        }


        [RegexStepDefinition(@"In the ItemSync manual entry screen, I see a Text entry field with the default text: 'Enter your UPC'")]
        public void InTheItemSyncManualEntryScreenISeeEntryFieldWithTextEnterYourUPC()
        {
            Report.IsTrue(new ItemSync().UPCInputBoxPresent(), "The UPC input box was not present", "The UPC input box was present");
            //Check found default text
            Report.IsTrue(new ItemSync().UPCInputBoxDefaultTextMatches("Enter your UPC"), "Default text was not a match", "The default text was a match!");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm I see an 'ADD' button")]
        public void InTheItemSyncManualEntryScreenIConfirmISeeAnADDButton()
        {
            Report.IsTrue(new ItemSync().UPCInputAddButton != null, "Failed to find the add button", "Successfully found the add button");
        }



        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I Click the 'ADD' button")]
        public void InTheItemSyncManualEntryScreenIClickTheADDButton()
        {
            Report.IsTrue(new ItemSync().ClickUPCInputAddButton(), "Failed to click the add button", "Successfully clicked the add button");
            
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I enter: (.*) into the UPC entry field")]
        public void InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(string value)
        {
            Report.IsTrue(new ItemSync().UPCInputBoxEnterText(value), "Failed to enter text", "Successfully entered text");
            
        }

        

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm the message: (.*) is shown")]
        public void InTheItemSyncManualEntryScreenIConfirmTheMessageIsShown(string value)
        {
            Report.IsTrue(new ItemSync().CheckUPCInputWarningText(value), "The message was not shown", "The Message was shown");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screenm I confirm I see a UPC Grid")]
        public void InTheItemSyncManualEntryScreenIConfirmISeeUPCGrid()
        {
            Report.IsTrue(new ItemSync().UPCTableGridFound(), "The grid was not found", "The Grid was found");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screenm I confirm I do not see a UPC Grid")]
        public void InTheItemSyncManualEntryScreenIConfirmIDoNotSeeUPCGrid()
        {
            Report.IsFalse(new ItemSync().UPCTableGridFound(), "The Grid was found", "The grid was not found");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screenm I confirm the UPC Grid contains one column and its heading is 'UPC'")]
        public void InTheItemSyncManualEntryScreenIConfirmTheUPCGridContainsOneColumnAndItsHeadingIsUPC()
        {
            Report.IsTrue(new ItemSync().CheckUPCOnlyNamedHeading(), "The Gird either contained no columns, or more than the expected UPC heading", "The Grid Grid contains one column and its heading is 'UPC'");

        }

        


        [RegexStepDefinition(@"In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: (.*)")]
        public void InTheItemSyncManualEntryScreenIConfirmTheUPCGridContainsUPCSavedAs(string savedAs)
        {

            string value = savedAs;
            
            if(value.ToLower().Contains("saved as"))
            {
                value= value.Replace("saved as ", "");
                Report.Info($"value: {value}");
                value = (string)Context.GetFromContext(value);
            }
                        
            Report.IsTrue(new ItemSync().CheckUPCFoundInGrid(value), "Failed to find UPC in grid", "Successfully found the UPC in the Grid");

        }


        [RegexStepDefinition(@"In the ItemSync Manual Entry screen I confirm the UPC Grid does not contain the UPC: (.*)")]
        public void InTheItemSyncManualEntryScreenIConfirmTheUPCGridDoesNotContainUPCSavedAs(string savedAs)
        {

            string value = savedAs;

            if (value.ToLower().Contains("saved as"))
            {
                value = value.Replace("saved as ", "");
                Report.Info($"value: {value}");
                value = (string)Context.GetFromContext(value);
            }

            Report.IsFalse(new ItemSync().CheckUPCFoundInGrid(value), "The UPC was in the grid", "The UPC was not in grid");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen I confirm that to the right of the UPC: (.*) I see a 'Remove' Icon")]
        public void InTheItemSyncManualEntryScreenIConfirmToTheRightOfUPCXISeeRemoveIcon(string savedAs)
        {

            string value = savedAs;

            if (value.ToLower().Contains("saved as"))
            {
                value = value.Replace("saved as ", "");
                Report.Info($"value: {value}");
                value = (string)Context.GetFromContext(value);
            }

            Report.IsTrue(new ItemSync().CheckRemoveIconForUPC(value), "Failed to find remove icon for the upc", "Successfully found the Remove icon for the UPC");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen I confirm that to the right of the UPC: (.*) I Click the 'Remove' Icon")]
        public void InTheItemSyncManualEntryScreenIConfirmToTheRightOfUPCXIClickRemove(string savedAs)
        {

            string value = savedAs;

            if (value.ToLower().Contains("saved as"))
            {
                value = value.Replace("saved as ", "");
                Report.Info($"value: {value}");
                value = (string)Context.GetFromContext(value);
            }

            Report.IsTrue(new ItemSync().ClickRemoveIconForUPC(value), "Failed to click remove icon for the upc", "Successfully clicked the Remove icon for the UPC");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm I see an 'Upload' button")]
        public void InTheItemSyncManualEntryScreenIConfirmISeeAnUploadButton()
        {
            Report.IsTrue(new ItemSync().ManualUploadButton != null, "Failed to find the Upload button", "Successfully found the Upload button");
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I Click the Upload Button")]
        public void InTheItemSyncManualEntryScreenIClickTheUploadButton()
        {
            Report.IsTrue(new ItemSync().ClickUploadButtonManualUpload(), "Failed to Click upload button", "Successfully clicked the Upload button");
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I see the Upload Loading indicator")]
        public void InTheItemSyncManualEntryScreenISeeTheUploadLoadingIndicator()
        {
            Report.IsTrue(new ItemSync().UploadingLoadingIconPresent(), "Failed to find the loading indicator", "Successfully found the loading indicator");
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm I see the UPCs remaining count")]
        public void InTheItemSyncManualEntryScreenIConfirmISeeTheUPCsRemainingCount()
        {
            Report.IsTrue(new ItemSync().UPCsRemainingCountFound(), "Failed to find the UPC Remaining element", "Successfully found the UPCs Remaining element");
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm the UPCs Remaining count is shown in the format: xxx UPCs Remaining")]
        public void InTheItemSyncManualEntryScreenIConfirmUPCsRemainingFormatAsExpected()
        {
            Report.IsTrue(new ItemSync().UPCsRemainingCheckFormat(), "Format was incorrect", "Format was correct");
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm the number shown in the UPCs Remaining count is: (.*)")]
        public void InTheItemSyncManualEntryScreenIConfirmUPCs(string upcValue)
        {
            Report.IsTrue(new ItemSync().UPCNumberRemaining(upcValue), "Format was incorrect", "Format was correct");
        }



        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm the ADD button is greyed out and I cannot add any more UPCs to the grid")]
        public void InTheItemSyncManualEntryScreenIConfirmConfirmTheAddButtonIsGreyedOutAndCannotAddAnyMoreUPCs()
        {
            Report.IsTrue(new ItemSync().AddUPCButtonDisabled(), "Add Button was not disabled", "Add Button was disabled");

            new Global_Steps().GivenIGenerateARandomUPCNumberAndSaveAs("currentRandomUPC");
            string upcNum = (string)Context.GetFromContext("currentRandomUPC");
            new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(upcNum);
            new ItemSync().ClickUPCInputAddButton();
            this.InTheItemSyncManualEntryScreenIConfirmTheUPCGridDoesNotContainUPCSavedAs("saved as currentRandomUPC");

        }


        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm the table footer is showing")]
        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm the table footer is showing")]
        public void InTheItemSyncManualEntryScreenIConfirmFooterShowingInTable()
        {
            Report.IsTrue(new ItemSync().UPCTableFooterFound(), "UPC Table footer was not showing", "UPC Table footer was showing");
        }



        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm I can scroll up and down through the UPC grid List")]
        public void InTheItemSyncManualEntryScreenIConfirmICanScrollUpAndDownTheUPCGridList()
        {
            Report.IsTrue(new ItemSync().ScrollToBpttomOfUPCGrid(), "Failed To Scroll to the Bottom of The UPC Grid", "Succesfully Scrolled to the Bottom of The UPC Grid");

            Report.IsTrue(new ItemSync().ScrollToTopOfUPCGrid(), "Failed To Scroll to the Top of The UPC Grid", "Succesfully Scrolled to the Top of The UPC Grid");
        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm the Entry field and the ADD button are still shown at all times while scrolling the UPC grid")]
        public void InTheItemSyncManualEntryScreenIConfirmISeeEntryFieldAndAddButtonWhileScrolling()
        {      

            var rows = new ItemSync().GetAllUPCTableRows();
            if (rows.IsNullOrEmpty())
            {
                Report.Failure($"No rows were found in the UPC table");
                return;
            }
            foreach(var row in rows)
            {
                row.ScrollElementIntoView();
                Report.IsTrue(row.VisibleInViewport(), "Failed to scroll the element into place", "Successfully scrolled the element into place");
                Report.IsTrue(new ItemSync().UPCInputBoxPresent(), "The UPC input box was not present", "The UPC input box was present");
                this.InTheItemSyncManualEntryScreenIConfirmISeeAnADDButton();
            }
      
        }
        

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm I see the error with the message (.*)")]
        public void InTheItemSyncManualEntryScreenIConfirmISeeTheUPCInputError(string value)
        {
            Report.IsTrue(new ItemSync().UPCInputErrorTextMatches(value), "Failed To Find the error text", "Successfully found error text");

        }

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm I do not see the error with the message (.*)")]
        public void InTheItemSyncManualEntryScreenIConfirmIDoNotSeeTheUPCInputError(string value)
        {
            Report.IsTrue(!new ItemSync().UPCInputErrorTextMatches(value), "Found error text","Did not Find the error text");

        }

        

        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I Clear the text in the UPC field")]
        public void InTheItemSyncManualEntryScreenIClearTheTextInTheUPCField()
        {
            Report.IsTrue(new ItemSync().ClearUPCField(), "Failed to clear text", "Successfully Cleared text");

        }


        [RegexStepDefinition(@"In the ItemSync Manual Entry screen, I confirm that the UPC Details Results Table has the following columns:")]
        public void InItemSyncManualEntryScreeenIConfirmUPCResultsColumnsNames(Table table)
        {
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new ItemSync().ResultsGridGetHeadings();
            var differences = expectedHeadings.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedHeadings.Count() == foundHeadings.Count(), "The headings found were not as expected", "The headings found matched the expected headings");
        }
    

        [RegexStepDefinition(@"I Confirm the Item Sync Results Page shows the title 'UPC Details'")]
        public void IConfirmTheItemSyncResultsPageShowsTheTitle()
        {
            Report.IsTrue(new ItemSync().GetCurrentPageTitle() == "UPC Details", "The Page title was not as expected", "The page title was as expected");
        }

        

        [RegexStepDefinition(@"I Confirm the Item Sync Results Page shows the Buttons: in order")]
        public void IConfirmTheItemSyncResultsPageShowsTheButtonsInOrder(Table table)
        {


            List<string> expectingButtons = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectingButtons.Add(thisRow["Buttons"]);
            }

            Report.IsTrue(new ItemSync().ConfirmActionButtonsFoundInOrder(expectingButtons), "The buttons did not match", "The buttons matched");


        }


        [RegexStepDefinition(@"I Confirm the Item Sync Results Page shows the UPC results grid")]
        public void IConfirmTheItemSyncResultsPageShowsTheUPCResultsGrid()
        {

           Report.IsTrue(new ItemSync().ConfirmUPCDetailsResultsTableShown(),"Failed to find the grid","The Results grid was found");

        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm that the UPC Details Results Table footer has the following page navigation icons:")]
        public void InItemSyncScreeenIConfirmFooterPageNavigationIcons(Table table)
        {
            List<string> expectedIcons = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedIcons.Add(thisRow["Icons"]);
            }
            List<string> foundIcons = new ItemSync().GetFooterPageNavigationIcons();

            Report.Info($"The found icons are: {string.Join(",", foundIcons)}");
            Report.Info($"The expected icons are: {string.Join(",", expectedIcons)}");

            var differences = expectedIcons.Except(foundIcons);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedIcons.Count() == foundIcons.Count(), "The Footer Icons found were not as expected", "The Footer Icons found matched the expected icons");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm that the UPC Details Results Table footer diplays hover over text for the following icons:")]
        public void InItemSyncScreeenIConfirmFooterPageNavigationIconsDisplayHoverOverText(Table table)
        {
            List<string> expectedIcons = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedIcons.Add(thisRow["Icons"]);
            }
            foreach(var icon in expectedIcons)
            {
                Report.Info($"Looking for hover over text for the button: {icon}");
                Report.IsTrue(new ItemSync().ConfirmFooterNavigationIconHoverOver(icon), "The hover over text was not found for the button: " + icon, "Hover over text was as expected for button: " + icon);
            }

        }
       

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I click the: (.*) Icon in the UPC Details Reults Table Footer.")]
        public void InItemSyncScreeenIConfirmFooterClickXIcon(string wantedIcon)
        {

            Report.IsTrue(new ItemSync().ClickXIconInFooter(wantedIcon), "Failed to click Icon", "Successfully clicked icon");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm I see the items per page drop down selector")]
        public void InItemSyncScreeenIConfirmISeetheItemsPerpageDropDownSelector()
        {

            Report.IsTrue(new ItemSync().ItemsPerPageFoundInFooter(), "Failed to find to items per page drop down selector", "Sucessfully found the items per page drop down selector");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm I see the items per page selector is set to: (.*)")]
        public void InItemSyncScreeenIConfirmISeetheItemsPerpageSelector(string currentValue)
        {

            string foundItemsPerPage = new ItemSync().CurrentItemsPerPageOption();

            Report.IsTrue(foundItemsPerPage==currentValue, "Failed to find the items per page drop down selector", "Sucessfully found the items per page drop down selector");
        }


        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm the possible items per page options are:")]
        public void InItemSyncScreeenIConfirmISeeItemsPerPageOptions(Table table)
        {

            List<string> expectedOptions = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedOptions.Add(thisRow["Options"]);
            }

            List<string> foundOptions = new ItemSync().ItemsPerPageOptions();



            Report.Info($"The found icons are: {string.Join(",", foundOptions)}");
            Report.Info($"The expected icons are: {string.Join(",", foundOptions)}");

            var differences = expectedOptions.Except(foundOptions);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedOptions.Count() == foundOptions.Count(), "The Items Per page Options found were not as expected", "The Items Per page Options found were as expected");

        }



        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I select the items per page option: (.*)")]
        public void InItemSyncScreeenISelectItemsPerPageOption(string value)
        {

            Report.IsTrue(new ItemSync().SelectItemsPerPageOptions(value), "Failed to find the items per page drop down selector", "Sucessfully found the items per page drop down selector");
        }


        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm the number of rows in the UPC Details Results table is: (.*)")]
        public void InItemSyncScreenIConfirmTheNumberOfRowsInTable(string value)
        {

            var foundRows = new ItemSync().GetAllUPCDetailsResultsRows();

            Report.Info($"The number of found rows was: {foundRows.Count()}");

            Report.IsTrue(foundRows.Count().ToString()==value, "The number of rows was not a match","The number of rows was a match");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm I see the grid count indicator")]
        public void InItemSyncScreenIConfirmICanSeeGridCountIndicator()
        {

            Report.IsTrue(new ItemSync().GridCountIndicatorShown(), "The grid count indicator was not shown", "The grid count indicator was shown");
        }

        [RegexStepDefinition(@"In the ItemSync Upload a File screen, I confirm the grid count indicator is shown in the format: View 1 - 10 of x")]
        public void InItemSyncScreenIConfirmThGridCountIndicatorisInFormat()
        {

            Report.IsTrue(new ItemSync().CheckGridCountIndicatorFormat(), "The grid count indicator format was not correct", "The grid count indicator format was as expected");
        }
    }
}


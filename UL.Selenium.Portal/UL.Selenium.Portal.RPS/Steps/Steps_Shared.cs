using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "Shared")]
    class Steps_Shared
    {
        [StepDefinition(@"I call Shared Step 104950 \(RPS Login - Base functionality\) for TReVor account: (.*)")]
        public void Shared104950(string savedAs)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I navigate to the landing page");
            new Global_Steps().NavigateToTheLandingPage();
            Report.StartStep("I confirm the Landing Page has loaded");
            new Steps_LandingPage().ConfirmLandingPageHasLoaded();
            var user = TestUsers.GetUserSavedAs(savedAs);
            if (user == null)
            {
                throw new Exception("Failed to find user saved as: " + savedAs);
            }
            Report.StartStep("I click Sign In");
            new Steps_LandingPage().ClickSignIn();
            Report.StartStep("I enter the account username for: " + savedAs);
            new Steps_Login().EnterUserNameForTrevorTestUser(user);
            Report.StartStep("I enter the account password for: " + savedAs);
            new Steps_Login().EnterPasswordForTrevorTestUser(user);
            Report.StartStep("I click Log In");
            new Steps_Login().ClickLogIn();
            GeneralUtilities.WaitForLoadingToFinish();
            Context.AddToContext("ActiveUser", user);
        }

        [StepDefinition(@"I call Shared Step 106194 \(RPS Sign out\)")]
        public void SharedStep106194()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Top Bar, I click on the logged in user name");
            new Steps_TopBar().ClickUserNameButtonTopBar();
            Report.StartStep("In the drop down menu, I click: Sign Out");
            new Steps_TopBar().ClickSignOut();
        }

        [StepDefinition(@"I call Shared Step 134361 \(RPS Login - User does not have access to ItemSync\)")]
        public void Shared134361()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I navigate to the landing page");
            new Global_Steps().NavigateToTheLandingPage();
            Report.StartStep("I confirm the Landing Page has loaded");
            new Steps_LandingPage().ConfirmLandingPageHasLoaded();
            string savedAs = "RPS.HD";
            var user = TestUsers.GetUserSavedAs(savedAs);
            if (user == null)
            {
                throw new Exception("Failed to find user saved as: " + savedAs);
            }
            Report.StartStep("I click Sign In");
            new Steps_LandingPage().ClickSignIn();
            Report.StartStep("I enter the account username for: " + savedAs);
            new Steps_Login().EnterUserNameForTrevorTestUser(user);
            Report.StartStep("I enter the account password for: " + savedAs);
            new Steps_Login().EnterPasswordForTrevorTestUser(user);
            Report.StartStep("I click Log In");
            new Steps_Login().ClickLogIn();
            GeneralUtilities.WaitForLoadingToFinish();
            Context.AddToContext("ActiveUser", user);
        }


        [StepDefinition(@"I call Shared Step 134359 \(RPS Login - User has Standard ItemSync Access\)")]
        public void Shared134359()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I navigate to the landing page");
            new Global_Steps().NavigateToTheLandingPage();
            Report.StartStep("I confirm the Landing Page has loaded");
            new Steps_LandingPage().ConfirmLandingPageHasLoaded();
            string savedAs = "RPS.LW";
            var user = TestUsers.GetUserSavedAs(savedAs);
            if (user == null)
            {
                throw new Exception("Failed to find user saved as: " + savedAs);
            }
            Report.StartStep("I click Sign In");
            new Steps_LandingPage().ClickSignIn();
            Report.StartStep("I enter the account username for: " + savedAs);
            new Steps_Login().EnterUserNameForTrevorTestUser(user);
            Report.StartStep("I enter the account password for: " + savedAs);
            new Steps_Login().EnterPasswordForTrevorTestUser(user);
            Report.StartStep("I click Log In");
            new Steps_Login().ClickLogIn();
            GeneralUtilities.WaitForLoadingToFinish();
            Context.AddToContext("ActiveUser", user);
        }

        [StepDefinition(@"I call Shared Step 134362 \(RPS Login - User has Subscription ItemSync access\)")]
        public void Shared134362()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I navigate to the landing page");
            new Global_Steps().NavigateToTheLandingPage();
            Report.StartStep("I confirm the Landing Page has loaded");
            new Steps_LandingPage().ConfirmLandingPageHasLoaded();
            string savedAs = "RPS.99";
            var user = TestUsers.GetUserSavedAs(savedAs);
            if (user == null)
            {
                throw new Exception("Failed to find user saved as: " + savedAs);
            }
            Report.StartStep("I click Sign In");
            new Steps_LandingPage().ClickSignIn();
            Report.StartStep("I enter the account username for: " + savedAs);
            new Steps_Login().EnterUserNameForTrevorTestUser(user);
            Report.StartStep("I enter the account password for: " + savedAs);
            new Steps_Login().EnterPasswordForTrevorTestUser(user);
            Report.StartStep("I click Log In");
            new Steps_Login().ClickLogIn();
            GeneralUtilities.WaitForLoadingToFinish();
            Context.AddToContext("ActiveUser", user);
        }


        [StepDefinition(@"I call Shared Step 106517 \(Home > Replace an original widget\) for widget: (.*)")]
        public void SharedStep106517(string widget)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget);
            new Steps_Home().ClickDropDownToggle(widget);
            Report.StartStep("I click 'Replace'");
            new Steps_Home().ClickDropdownOptionWidget("Replace", widget);
            Report.StartStep("I select the first option in the list on the Select Chart Type popup");
            new Steps_Home().ClickFirstListOption("NewWidget");
            Report.StartStep("Confirm Select Chart Type popup closes");
            new Steps_Home().ConfirmSelectChartTypePopupCloses();
            Report.StartStep("I confirm that the Home page refreshes");
            new Steps_Home().HomeTabLoaded();
            Report.StartStep($"I confirm the widget: {widget} is no longer displayed");
            new Steps_Home().ConfirmWidgetDisplayedOrNot(widget, "is not");
            Report.StartStep("I confirm the widget I selected in the Select Chart Type popup is displayed");
            new Steps_Home().ConfirmWidgetDisplayedOrNot("%NewWidget%", "is");
        }

        [StepDefinition(@"I call Shared Step 70474 \(Verify Chart functionality\) for widget: (.*)")]
        public void SharedStep70475(string widget)
        {
            ReportSettings.UseSubSteps = true;

            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
            Report.StartStep("I save the current graph view titles for the widget to context as: CurrentGraphViewFullTitles");
            List<string> graphViewTitlesFull = new WidgetPage.Widget(widget).CurrentChartFullTitlesGraphView();
            Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Data View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Data");
            Report.StartStep("I save the current data view titles for the widget to context as: CurrentDataViewFullTitles");
            List<string> dataViewTitlesFull = new List<string>();
            dataViewTitlesFull = new WidgetPage.Widget(widget).GetCurrentDataTitlesWithCount();
            Context.AddToContext("CurrentDataViewFullTitles", dataViewTitlesFull);
            Report.StartStep("I confirm the data shown in the data view matches the Graph I saw earlier");
            var differences = graphViewTitlesFull.Except(dataViewTitlesFull);
            if (differences.Any())
            {

                if (differences.First().Contains("..."))
                {
                    Report.Info("Some of the titles found on the graph view contained '...', using an additional method to check the shorted titles are a match");
                    new WidgetPage.Widget(widget).ComparePieChartDataToShortGraphTitles(graphViewTitlesFull, dataViewTitlesFull);

                }
                else
                {
                    Report.IsTrue(!differences.Any(), "The titles found for both views did not match", "The titles found for both view matched");
                }
            }
            else
            {
                Report.IsTrue(!differences.Any(), "The titles found for both views did not match", "The titles found for both view matched");
            }
            List<string> dataViewNamesOnly = new WidgetPage.Widget(widget).GetCurrentDataTitles();
            Context.AddToContext("CurrentDataViewNamesOnly", dataViewNamesOnly);
            List<string> dataViewCountsOnly = new WidgetPage.Widget(widget).GetCurrentDataTitlesCountOnly();
            Context.AddToContext("CurrentDataViewCountsOnly", dataViewCountsOnly);

            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
            new Steps_Home().ClickDropDownToggle(widget);
            new Steps_Home().ClickDropdownOptionWidget("Export", widget);
            int i = 0;
            bool fileGot = false;
            while (i < 5 && fileGot == false)
            {

                try
                {
                    new Global_Steps().SaveDownloads();
                    new Global_Steps().ConfirmNewFile("ExportFile");
                    new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
                    fileGot = true;

                }
                catch
                {
                    i++;
                    Report.Info("Failed to get file, trying again");
                    Delay.Seconds(5);
                }
            }
            if (fileGot == false)
            {
                Report.Failure("Did not find the file");
                return;
            }

            FileInfo fileName = (FileInfo)Context.GetFromContext("ExportFile");
            string filepath = fileName.FullName;
            Context.AddToContext("CurrentOutputCSV", filepath);
            Context.AddToContext("CurrentValuesDictionary", GeneralUtilities.ConvertTwoListsToDictonary(dataViewNamesOnly, dataViewCountsOnly));

            Report.StartStep("I Check that the CSV downloaded contains the expected data");
            new Global_Steps().ICheckCSVContainsValues("CurrentOutputCSV", "CurrentValuesDictionary");
            Report.StartStep($"I Delete the file saved as: CurrentOutputCSV");
            new Global_Steps().DeleteFile("CurrentOutputCSV");
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
            Report.StartStep("Currently Missing the Print Steps Due to Selenium Limitations");
            Report.StartStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download PNG image");
            new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download PNG image");
            Report.StartStep($"I confirm that a file is produced called chart.png and save as savedasPNG70474");
            new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.png", "savedasPNG70474");
            Report.StartStep($"I open the file saved as: savedasPNG70474 and take a screenshot");
            new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasPNG70474");
            Report.StartStep($"I Close the window that was opened");
            new Global_Steps().ThenCloseTheWindowThatOpened();
            Report.StartStep($"I Delete the file saved as: savedasPNG70474 ");
            new Global_Steps().DeleteFile("savedasPNG70474");
            Report.StartStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download JPEG image");
            new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download JPEG image");
            Report.StartStep($"I confirm that a file is produced called chart.jpeg and save as savedasJPEG70474");
            new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.jpeg", "savedasJPEG70474");
            Report.StartStep($"I open the file saved as: savedasJPEG70474 and take a screenshot");
            new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasJPEG70474");
            Report.StartStep($"I Close the window that was opened");
            new Global_Steps().ThenCloseTheWindowThatOpened();
            Report.StartStep($"I Delete the file saved as: savedasJPEG70474 ");
            new Global_Steps().DeleteFile("savedasJPEG70474");
            Report.StartStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download PDF document");
            new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download PDF document");
            Report.StartStep($"I confirm that a file is produced called chart.pdf and save as savedasPDF70474");
            new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.pdf", "savedasPDF70474");
            Report.StartStep($"I open the file saved as: savedasPDF70474 and take a screenshot");
            new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasPDF70474");
            Report.StartStep($"I Close the window that was opened");
            new Global_Steps().ThenCloseTheWindowThatOpened();
            Report.StartStep($"I Delete the file saved as: savedasPDF70474 ");
            new Global_Steps().DeleteFile("savedasPDF70474");
            Report.StartStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download SVG vector image");
            new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download SVG vector image");
            Report.StartStep($"I confirm that a file is produced called chart.svg and save as savedasSVG70474");
            new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.svg", "savedasSVG70474");
            Report.StartStep($"I open the file saved as: savedasSVG70474 and take a screenshot");
            new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasSVG70474");
            Report.StartStep($"I Close the window that was opened");
            new Global_Steps().ThenCloseTheWindowThatOpened();
            Report.StartStep($"I Delete the file saved as: savedasSVG70474 ");
            new Global_Steps().DeleteFile("savedasSVG70474");

        }

        [StepDefinition(@"I call Shared Step 111976 \(Click WERCSmart® Product Suite Logo - Confirm Home page shown\)")]
        public void SharedStep111976()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Top Bar,  I check that the WERCSmart® Product Suite Logo is showing ");
            new Steps_TopBar().ProductSuiteLogoDisplayed();
            Report.StartStep("I click the WERCSmart® Product Suite logo ");
            new Steps_TopBar().ClickProductSuiteLogo();
            Report.StartStep("I confirm I am redirected to the Home tab");
            new Steps_Home().HomeTabLoaded();
        }

        [StepDefinition(@"I call Shared Step 70484 \(Chart Drill-down Export\) for widget: (.*)")]
        public void SharedStep70484(string widget)
        {
            ReportSettings.UseSubSteps = true;

            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
            Report.StartStep("I save the current graph view titles for the widget to context as: CurrentGraphViewFullTitles");
            List<string> graphViewTitlesFull = new WidgetPage.Widget(widget).CurrentChartFullTitlesGraphView();
            Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);
            string chartType = new WidgetPage.Widget(widget).Type;
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Data View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Data");
            Report.StartStep("I save the current data view titles for the widget to context as: CurrentDataViewFullTitles");
            List<string> dataViewTitlesFull = new List<string>();
            dataViewTitlesFull = new WidgetPage.Widget(widget).GetCurrentDataTitlesWithCount();
            Context.AddToContext("CurrentDataViewFullTitles", dataViewTitlesFull);
            Report.StartStep("I confirm the data shown in the data view matches the Graph I saw earlier");
            var differences = graphViewTitlesFull.Except(dataViewTitlesFull);
            if (differences.Any())
            {

                if (differences.First().Contains("..."))
                {
                    Report.Info("Some of the titles found on the graph view contained '...', using an additional method to check the shorted titles are a match");
                    new WidgetPage.Widget(widget).ComparePieChartDataToShortGraphTitles(graphViewTitlesFull, dataViewTitlesFull);

                }
                else
                {
                    Report.IsTrue(!differences.Any(), "The titles found for both views did not match", "The titles found for both view matched");
                }
            }
            else
            {
                Report.IsTrue(!differences.Any(), "The titles found for both views did not match", "The titles found for both view matched");
            }
            List<string> dataViewNamesOnly = new WidgetPage.Widget(widget).GetCurrentDataTitles();
            Context.AddToContext("CurrentDataViewNamesOnly", dataViewNamesOnly);
            List<string> dataViewCountsOnly = new WidgetPage.Widget(widget).GetCurrentDataTitlesCountOnly();
            Context.AddToContext("CurrentDataViewCountsOnly", dataViewCountsOnly);
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
            new Steps_Home().ClickDropDownToggle(widget);
            new Steps_Home().ClickDropdownOptionWidget("Export", widget);
            new Global_Steps().SaveDownloads();
            new Global_Steps().ConfirmNewFile("ExportFile");
            new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
            FileInfo fileName = (FileInfo)Context.GetFromContext("ExportFile");
            string filepath = fileName.FullName;
            Context.AddToContext("CurrentOutputCSV", filepath);
            Context.AddToContext("CurrentValuesDictionary", GeneralUtilities.ConvertTwoListsToDictonary(dataViewNamesOnly, dataViewCountsOnly));
            Report.StartStep("I Check that the CSV downloaded contains the expected data");
            new Global_Steps().ICheckCSVContainsValues("CurrentOutputCSV", "CurrentValuesDictionary");
            Report.StartStep($"I Delete the file saved as: CurrentOutputCSV");
            new Global_Steps().DeleteFile("CurrentOutputCSV");
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
            Report.StartStep("I Select the First Area/Section of the Chart");
            if (widget == "Supplier Subscription Status")
            {

                Report.Info("The widget that is being interacted with is the 'Supplier Subscription Status' widget, there for we will use steps that account for the supplier List appearing on the first drill down");
                new Global_Steps().ForSupplierSubscriptionStatusIPerformChartDrillDownExport();
                Report.Info("The steps for the 'Supplier Subscription Status' widget are finished");
                return;

            }
            new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(widget, "CurrentChartTitles", "<first>");
            Report.StartStep("I confirm that if a chart is shown I see the same type of chart as shown in the initial display of the widget");
            string newChartType = new WidgetPage.Widget(widget).Type;
            Report.IsTrue(chartType == newChartType, "The type of chart found was not the same as the previous chart type before the section was clicked", "The type of chart found was the same as the previous chart type before the section was clicked");
            Report.StartStep("I save the current graph view titles for the widget to context as: CurrentGraphViewFullTitles");
            graphViewTitlesFull = new WidgetPage.Widget(widget).CurrentChartFullTitlesGraphView();
            Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);
            Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);



            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Data View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Data");
            Report.StartStep("I save the current data view titles for the widget to context as: CurrentDataViewFullTitles");
            dataViewTitlesFull = new List<string>();
            dataViewTitlesFull = new WidgetPage.Widget(widget).GetCurrentDataTitlesWithCount();
            Context.AddToContext("CurrentDataViewFullTitles", dataViewTitlesFull);
            Report.StartStep("I confirm the data shown in the data view matches the Graph I saw earlier");
            differences = graphViewTitlesFull.Except(dataViewTitlesFull);
            if (differences.Any())
            {

                if (differences.First().Contains("..."))
                {
                    Report.Info("Some of the titles found on the graph view contained '...', using an additional method to check the shorted titles are a match");
                    new WidgetPage.Widget(widget).ComparePieChartDataToShortGraphTitles(graphViewTitlesFull, dataViewTitlesFull);

                }
                else
                {
                    Report.IsTrue(!differences.Any(), "The titles found for both views did not match", "The titles found for both view matched");
                }
            }
            else
            {
                Report.IsTrue(!differences.Any(), "The titles found for both views did not match", "The titles found for both view matched");
            }
            dataViewNamesOnly = new WidgetPage.Widget(widget).GetCurrentDataTitles();
            Context.AddToContext("CurrentDataViewNamesOnly", dataViewNamesOnly);
            dataViewCountsOnly = new WidgetPage.Widget(widget).GetCurrentDataTitlesCountOnly();
            Context.AddToContext("CurrentDataViewCountsOnly", dataViewCountsOnly);
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
            new Steps_Home().ClickDropDownToggle(widget);
            new Steps_Home().ClickDropdownOptionWidget("Export", widget);
            new Global_Steps().SaveDownloads();
            new Global_Steps().ConfirmNewFile("ExportFile");
            new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
            fileName = (FileInfo)Context.GetFromContext("ExportFile");
            filepath = fileName.FullName;
            Context.AddToContext("CurrentOutputCSV", filepath);
            Context.AddToContext("CurrentValuesDictionary", GeneralUtilities.ConvertTwoListsToDictonary(dataViewNamesOnly, dataViewCountsOnly));
            Report.StartStep("I Check that the CSV downloaded contains the expected data");
            new Global_Steps().ICheckCSVContainsValues("CurrentOutputCSV", "CurrentValuesDictionary");
            Report.StartStep($"I Delete the file saved as: CurrentOutputCSV");
            new Global_Steps().DeleteFile("CurrentOutputCSV");
            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
            new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
            Report.StartStep("I Select the First Area/Section of the Chart");
            new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatProductDataSeen(widget, "CurrentChartTitles", "<first>");
            Report.StartStep("I Confirm the Products List Is Showing");
            new Steps_Home().WaitForAllWidgets();
            new Steps_Home().ProductContentDisplayedForTitle("is", widget);
            Report.StartStep("I confirm I see a Back button to the top right of the Widget Main Body area");
            Report.IsTrue(new Home.Widget(widget).ProductsListBackButtonDisplayed(), "The Back button was not displayed", "The back button was displayed");


            Report.StartStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
            new Steps_Home().ClickDropDownToggle(widget);
            new Steps_Home().ClickDropdownOptionWidget("Export", widget);
            new Global_Steps().SaveDownloads();
            new Global_Steps().ConfirmNewFile("ExportFile");
            new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
            fileName = (FileInfo)Context.GetFromContext("ExportFile");
            filepath = fileName.FullName;
            Context.AddToContext("CurrentOutputCSV", filepath);


            Report.StartStep("I Get the current Product List Items, save them to context as 'CurrentProductListItems' and then check they match the csv export saved as 'CurrentOutputCSV'");
            var CurrentProductListItems = new Home.Widget(widget).GetCurrentProductListItems();
            Context.AddToContext("CurrentProductListItems", CurrentProductListItems);

            if (new WidgetPage.Widget(widget).GetTypeOfGraph() == "Pie Chart")
            {
                new Global_Steps().ICheckProductListPieCSVContainsValues("CurrentOutputCSV", "CurrentProductListItems");
            }
            if (new WidgetPage.Widget(widget).GetTypeOfGraph() == "Bar Graph")
            {
                new Global_Steps().ICheckProductListBarCSVContainsValues("CurrentOutputCSV", "CurrentProductListItems");
            }
            Report.StartStep($"I Delete the file saved as: CurrentOutputCSV");
            new Global_Steps().DeleteFile("CurrentOutputCSV");
            Report.StartStep("In the widget main body area, I click: Back");

            Report.IsTrue(new Home.Widget(widget).ProductsListBackButtonDisplayed(), "Failed to find the Products list back button", "Successfully found the Products list back button");
            Report.IsTrue(new Home.Widget(widget).ClickProductsListBackButton(), "Failed to click the back button", "Successfully clicked the back button");
            Report.IsTrue(new Home.Widget(widget).WaitUntilGraphXIsDisplayed(), "The graph content did not appear", "The graph content was shown");
            new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickBackTheTitlesChange("currentTitles", widget);




        }

        [StepDefinition(@"I call Shared Step 109167 \(Product Information pop up - layout verification\)")]
        public void SharedStep109167()
        {
            ReportSettings.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad();

            Report.StartStep("In the Product Information pop up, I confirm heading text reads: Product Information");
            Report.IsTrue(new ProductInformation().HeadingTextMatches("Product Information"), "The heading text was not as expected", "The heading was as expected");
            Report.StartStep("In the Product Information pop up heading area,  I confirm the x (close icon) is shown");
            Report.IsTrue(new ProductInformation().CrossCloseIconExists() && new ProductInformation().CloseButtonExists(), "The Close buttons were not found", "The Close buttons were found");
            Report.StartStep("In the Product Information pop up - main body area, I confirm product details are:");
            List<string> mainBodyHeaders = new List<string> { "Product :", "Supplier :", "Supplier Contact :" };
            Report.IsTrue(new ProductInformation().ProductTopDataHeadingsPresent(mainBodyHeaders), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("Below the product details, I confirm I see 4 headings:");
            List<string> sectionHeadings = new List<string> { "Product Data Codes", "Transportation Data", "Storage Data", "Battery Data" };
            Report.IsTrue(new ProductInformation().ProductInformatinSectionsPresent(sectionHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("I confirm that each heading shows and downward arrow to the right:");
            Report.Info("Checking to see if the sections are all inactive (down arrow)");
            foreach (var section in sectionHeadings)
            {
                Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive(section), "The Section: " + section + " was found to be active which was not expected", "The Section: " + section + " was found to be inactive as expected");
            }
        }

        [StepDefinition(@"I call Shared Step 109168 \(Product Information pop up - Expand Product Data codes - confirm rows\)")]
        public void SharedStep109168()
        {
            ReportSettings.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad(); 

            Report.StartStep("In the Product Information pop up, I click the Product Data Codes heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Data Codes"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Data Codes"), "The section was not expanded", "The section was expanded");
            Report.StartStep("I confirm that an additional area is shown below the Product Data Codes heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Data Codes"), "The additional area is shown below the Product Data Codes heading was not showing", "The additional area is shown below the Product Data Codes heading was showing");
            
            List<string> expectedHeadings = new List<string> { "Supplier Contact Name", "US EPA Waste Number", "Flash point °C", "Flash point (°C) DEGREES" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().ProductDataCodesHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the Product Data Codes heading");
            Report.StartStep("I confirm the additional area below the Product Data Codes heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Data Codes"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Data Codes"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Data Codes"), "The additional area is shown below the Product Data Codes heading was showing", "The additional area is shown below the Product Data Codes heading was not showing");

        }

        [StepDefinition(@"I call Shared Step 109169 \(Product Information pop up - Expand Transportation Data - confirm rows\)")]
        public void SharedStep109169()
        {
            ReportSettings.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad();

            Report.StartStep("In the Product Information pop up, I click the Transportation Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation Data"), "The section was not expanded", "The section was expanded");
            Report.StartStep("I confirm that an additional area is shown below the Transportation Data heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation Data"), "The additional area is shown below the Transportation Data heading was not showing", "The additional area is shown below the Transportation Data heading was showing");
            List<string> expectedHeadings = new List<string> { "Emergency Response Guide Number", "Hazard Class", "UN-No.", "Packing Group", "DOT Vessel Limited Quantity w/units (BASIC RETAILER)", "DOT Marine Pollutant?", "Marine pollutant <5L/5KG", "Miscible in Water?" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().TransporationDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the Transportation Data heading");
            Report.StartStep("I confirm the additional area below the Transportation Data heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Transportation Data"), "The additional area is shown below the Transportation Data heading was showing", "The additional area is shown below the Transportation Data heading was not showing");

        }

        [StepDefinition(@"I call Shared Step 109170 \(Product Information pop up - Expand Storage Data - confirm rows\)")]
        public void SharedStep109170()
        {
            ReportSettings.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad();
            Report.StartStep("In the Product Information pop up, I click the Storage Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage Data"), "The section was not expanded", "The section was expanded");
            Report.StartStep("I confirm that an additional area is shown below the Storage Data heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage Data"), "The additional area is shown below the Storage Data heading was not showing", "The additional area is shown below the Storage Data heading was showing");
            List<string> expectedHeadings = new List<string> { "Uniform Fire Code", "International Fire Code", "Health Hazards", "Flammability", "Stability", "Physical and Chemical Hazards" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().StorageHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the Storage Data heading");
            Report.StartStep("I confirm the additional area below the Storage Data heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Storage Data"), "The additional area is shown below the Storage Data heading was showing", "The additional area is shown below the Storage Data heading was not showing");

        }

        [StepDefinition(@"I call Shared Step 109171 \(Product Information pop up - Expand Battery Data - confirm rows\)")]
        public void SharedStep109171()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Product Information pop up, I click the Battery Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery Data"), "The section was not expanded", "The section was expanded");
            Report.StartStep("I confirm that an additional area is shown below the Battery Data heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery Data"), "The additional area is shown below the Battery Data heading was not showing", "The additional area is shown below the Battery Data heading was showing");
            List<string> expectedHeadings = new List<string> { "Does the product contain a battery or is it shipped with a battery?", "Product Itself is a Battery", "How Battery Resides in Product", "Watt hours for Li Batteries", "Weight of battery", "Quantity (grams) of Lithium present in battery", "Number of Batteries", "UN38.3 tested?", "IATA quality management system", "Number of batteries/cells used to run equipment" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().BatteryHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the  Battery Data heading");
            Report.StartStep("I confirm the additional area below the  Battery Data heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Battery Data"), "The additional area is shown below the Battery Data heading was showing", "The additional area is shown below the Battery Data heading was not showing");

        }

        [StepDefinition(@"I call Shared Step 109172 \(Product information pop up - Only 1 section expands at a time\)")]
        public void SharedStep109172()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Product Information pop up, I click the Product Data Codes heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Data Codes"), "Failed to Click the section", "Successfully clicked the section");
            Report.StartStep("I confirm that an additional area is shown below the Product Data Codes heading");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Data Codes"), "The section was not expanded", "The section was expanded");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Data Codes"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
            Report.StartStep("In the Product Information pop up, I click the Transportation Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.StartStep("I confirm that an additional area is shown below the Transportation Data heading");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation Data"), "The section was not expanded", "The section was expanded");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation Data"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
            Report.StartStep("I confirm the Product Data Codes expanded data is no longer shown");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Data Codes"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Data Codes"), "The additional area is shown below the heading was showing", "The additional area is shown below the heading was not showing");
            Report.StartStep("In the Product Information pop up, I click the Storage Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.StartStep("I confirm that an additional area is shown below the Storage Data heading");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage Data"), "The section was not expanded", "The section was expanded");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage Data"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
            Report.StartStep("I confirm the Transportation Data expanded data is no longer shown");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Transportation Data"), "The additional area is shown below the heading was showing", "The additional area is shown below the heading was not showing");
            Report.StartStep("In the Product Information pop up, I click the Battery Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.StartStep("I confirm that an additional area is shown below the Battery Data heading");
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery Data"), "The section was not expanded", "The section was expanded");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery Data"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
            Report.StartStep("I confirm the Storage Data expanded data is no longer shown");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Storage Data"), "The additional area is shown below the heading was showing", "The additional area is shown below the heading was not showing");

        }

        [StepDefinition(@"I call Shared Step 108597 \(Widget data view - Contact Supplier - email verification\) for widget: (.*)")]
        public void SharedStep108597(string widget)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I the widget main body area, I click on the first section of the chart ");
            new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(widget, "CurrentChartTitles", "<first>");
            new Steps_Home().WaitForAllWidgets();
            Report.StartStep("I the widget main body area, I click on the first section of the chart ");
            new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatProductDataSeen(widget, "CurrentChartTitles", "<first>");
            Report.StartStep("I Confirm the Products List Is Showing");
            new Steps_Home().WaitForAllWidgets();
            Report.Error("MANUAL REVIEW REQUIRED FOR THIS STEP AS IT IS OUTSIDE OF THE SCOPE OF AUTOMATION");
            //We can not currently/wont automate this because we don't access outlook in automation and also do not want to send emails etc.

            

        }

        [StepDefinition(@"I call Shared Step 106605 \(Dashboard - Remove Widget\) for widget: (.*)")]
        public void SharedStep106605(string widget)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I click the dropdown toggle for the widget");
            new Steps_Home().ClickDropDownToggle(widget);
            Report.StartStep("I click 'Remove' in the dropdown menu for the saved widget");
            new Steps_Home().ClickDropdownOptionWidget("Remove", widget);
            Report.StartStep("I confirm the widget is no longer displayed");
            new Steps_Home().ConfirmWidgetDisplayedOrNot(widget, "is not");
        }

        [StepDefinition(@"I call Shared Step 54484 \(Dashboard - Gauge - Reset Dashboard - confrim page refreshes\)")]
        public void SharedStep54484()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I click the Gauge button in the navigation bar");
            new NavBarTools().ClickGauge();
            Report.StartStep("I click the Reset Dashboard dropdown option below the navigation bar Gauge button");
            new Steps_Navigation().ClickResetDashboardDropdown("Reset Dashboard");
            Report.StartStep("I confirm the Dashboard tab has loaded");
            new Steps_Dashboard().HomeTabLoaded();
            var table = new Table("Widget");
            table.AddRow("Generic Bucket Code by RU");
            table.AddRow("RCRA by RU Category");
            table.AddRow("RU Category by Supplier");
            table.AddRow("RU Category by RU");
            table.AddRow("Product Recertification Status");
            table.AddRow("Product Status");
            table.AddRow("Product Hold Status");
            table.AddRow("Supplier Subscription Status");
            new Steps_Home().ConfirmDisplayedWidgets(table);
        }

        [StepDefinition(@"I call Shared Step 106623 \(Dashboard - Gauge - Re-add removed widget\) for widget: (.*)")]
        public void SharedStep106623(string widget)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("I click the Gauge button in the navigation bar");
            new NavBarTools().ClickGauge();
            Report.StartStep("I confirm menu options shows the following Options");
            var table = new Table("Option");
            table.AddRow(widget);
            table.AddRow("Reset Dashboard");
            table.AddRow("Refresh All Widgets");
            new Steps_Navigation().ConfirmDropDownOptionsNavBarGauge(table);
            Report.StartStep("");
            new NavBarTools().SelectDropDownOption(widget);
            Report.StartStep("I confirm the widget is now shown");
            new Steps_Home().ConfirmWidgetDisplayedOrNot(widget, "is");

        }

        [StepDefinition(@"I call Shared Step 111155 \(Table Heading or sub heading - confirm column resize anchor - resize column\) On the: (.*) page, for the column: (.*)")]
        public void SharedStep111155(string pageName,string column)
        {
            ReportSettings.UseSubSteps = true;




            if (pageName == "Recent Activities")
            {


                if (column == "Product ID" || column == "UPC Number")
                {
                    IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
                    Report.StartStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
                    Report.IsTrue(new RecentActivities().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
                    Report.StartStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
                    Report.StartStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
                    Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
                    Report.IsTrue(new RecentActivities().MakeColumnSmaller(column, row), "Failed to shrink the column", "Successfully shrunk the column");
                    Report.StartStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
                    Report.IsTrue(new RecentActivities().MakeColumnBigger(column, row), "Failed to expand the column", "Successfully expanded the column");

                }
                else
                {

                    Report.StartStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
                    Report.IsTrue(new RecentActivities().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
                    Report.StartStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
                    Report.StartStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
                    Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
                    Report.IsTrue(new RecentActivities().MakeColumnSmaller(column), "Failed to shrink the column", "Successfully shrunk the column");
                    Report.StartStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
                    Report.IsTrue(new RecentActivities().MakeColumnBigger(column), "Failed to expand the column", "Successfully expanded the column");
                }
                return;
            }

            if(pageName=="Drum Log")
            {
                if (column == "Scan Date" || column == "Date In Drum" || column == "Date Removed" || column == "Found/NotFound" || column == "Manufacturer" || column == "Name" || column == "Product" || column == "UPC" || column == "Volume" || column == "Actions")
                {
                    IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
                    Report.StartStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
                    Report.IsTrue(new DrumLog().CheckFirstExpandedRowColumnContainsResizeAnchor(row, column), "the column did not contain a resize anchor icon", "The column contains a resize anchor icon");
                    Report.StartStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
                    Report.StartStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
                    Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
                    Report.IsTrue(new DrumLog().MakeColumnSmaller(column, row), "Failed to shrink the column", "Successfully shrunk the column");
                    Report.StartStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
                    Report.IsTrue(new DrumLog().MakeColumnBigger(column, row), "Failed to expand the column", "Successfully expanded the column");

                }
                else
                {

                    Report.StartStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
                    Report.IsTrue(new DrumLog().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
                    Report.StartStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
                    Report.StartStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
                    Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
                    Report.IsTrue(new DrumLog().MakeColumnSmaller(column), "Failed to shrink the column", "Successfully shrunk the column");
                    Report.StartStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
                    Report.IsTrue(new DrumLog().MakeColumnBigger(column), "Failed to expand the column", "Successfully expanded the column");

                }


                return;
            }

            Report.Failure("Unable to find page");


        }

        [StepDefinition(@"I call Shared Step 106809 \(Breadcrumbs - Supplier Name field - confirm shown correctly and remove\) for text: (.*)")]
        public void SharedStep106809(string value)
        {
            if (value.Contains("SavedProduct"))
            {
                value = (string)Context.GetFromContext(value);
            }
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Filters: breadcrumb area I confirm I see the 'Supplier:' breadcrumb button");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel("Supplier:");
            Report.StartStep($"I confirm the Supplier breadcrumb shows the text: '{value}' that I entered into the more filters Supplier field");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(value);
            Report.StartStep($"I click the x at the far right of the Supplier breadcrumb button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX("supplier");
            Report.StartStep("I confirm the Supplier breadcrumb button is no longer shown");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel("Supplier:");

        }



        [StepDefinition(@"I call Shared Step 106777 \(Breadcrumbs - Status Name field - confirm shown correctly and remove\) for text: (.*)")]
        public void SharedStep106777(string value)
        {

            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Filters: breadcrumb area I confirm I see the 'Status:' breadcrumb button");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel("Status:");
            Report.StartStep($"I confirm the Supplier breadcrumb shows the text: '{value}' that I entered into the more filters Status field");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(value);
            Report.StartStep($"I click the x at the far right of the Status breadcrumb button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX("status");
            Report.StartStep("I confirm the Supplier breadcrumb button is no longer shown");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel("Status:");

        }


        [StepDefinition(@"I call Shared Step 107729 \(Breadcrumbs - General shared step - confirm shown correctly and remove\) for filter: (.*) and text: (.*)")]
        public void SharedStep107729(string filter,string value)
        {

            ReportSettings.UseSubSteps = true;
            Report.StartStep($"In the Filters: breadcrumb area I confirm I see the '{filter}:' breadcrumb button");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(filter+":");
            Report.StartStep($"I confirm the {filter} breadcrumb shows the text: '{value}' that I entered into the more filters Status field");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(value);

            Report.StartStep($"I click the x at the far right of the {filter} breadcrumb button");
            if (filter == "Retail Unique Identifier" || filter == "Retailer Identification Number")
            {
                string filterID = "upcItemNum";
                new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX(filterID);
            }
            else if (filter == "End Date")
            {
                string filterID = "endDate";
                new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX(filterID);
            }
            else if (filter == "Start Date")
            {
                string filterID = "startDate";
                new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX(filterID);
            }
            else
            {
                new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX(filter.ToLower());
            }

            Report.StartStep($"I confirm the {filter} breadcrumb button is no longer shown");
            new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel(filter + ":");

        }

        [StepDefinition(@"I call Shared Step 106901 \(More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data\) for status: (.*)")]
        public void SharedStep106901(string status)
        {

            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Recent Activities page, I click on the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartStep("In the recent activities Page, The More Filters Popup is showing");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I select the status I am working with");
            new Steps_RecentActivities().InTheRecentActivitiesPageISelectStatusOption(status);
            Report.StartStep("In the More Filters pop up, I click: Apply Filter");
            new Steps_RecentActivities().InTheRecentActivitiesPageMoreFiltersPopupClickApplyFilterButton();
            Report.StartStep("In the recent activities Page, The More Filters Popup is not showing");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersPopupIsNotShowing();
            new Steps_RecentActivities().HomeTabLoaded();

            Report.StartStep("In the recent activities Page, I confirm for all products the Action column does not include option: 'View Data'");
            new Steps_RecentActivities().InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnDoesNotContainGivenOption("View Data");

        }

        [StepDefinition(@"I call Shared Step 111879 \(Product Information pop up - when no data available\)")]
        public void SharedStep111879(string status)
        {



        }

        [StepDefinition(@"I call Shared Step 108016 \(Help & Support pop up - X to close\)")]
        public void SharedStep1080164()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("In the Help & Support pop up, I click the X icon");
            new Steps_HelpAndSupport().ClickTheIconInTheHelpAndSupportPopup();
            Report.StartStep("I confirm the Help & Support pop up is closed");
            new Steps_HelpAndSupport().HelpAndSupportPopupNotDisplayed();
            Report.StartStep("I confirm I see the Retail Product Suite Home page");
            new Steps_Home().HomeTabLoaded();
             
        }

        [StepDefinition(@"I call Shared Step 98339 \(RPS Lowe's Login\)")]
        public void Shared104950()
        {
            ReportSettings.UseSubSteps = true;
            string savedAs = "RPS.LW";
            Report.StartStep("I navigate to the landing page");
            new Global_Steps().NavigateToTheLandingPage();
            Report.StartStep("I confirm the Landing Page has loaded");
            new Steps_LandingPage().ConfirmLandingPageHasLoaded();
            var user = TestUsers.GetUserSavedAs(savedAs);
            if (user == null)
            {
                throw new Exception("Failed to find user saved as: " + savedAs);
            }
            Report.StartStep("I click Sign In");
            new Steps_LandingPage().ClickSignIn();
            Report.StartStep("I enter the account username for: " + savedAs);
            new Steps_Login().EnterUserNameForTrevorTestUser(user);
            Report.StartStep("I enter the account password for: " + savedAs);
            new Steps_Login().EnterPasswordForTrevorTestUser(user);
            Report.StartStep("I click Log In");
            new Steps_Login().ClickLogIn();
            GeneralUtilities.WaitForLoadingToFinish();
            Context.AddToContext("ActiveUser", user);
        }

        [StepDefinition(@"I call Shared Step 125598 \(ItemSync - Upload a File - Remove icon - page refreshes\)")]
        public void Shared125598()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"I confirm to the right of the filename I see a Remove icon (garbage can)");
            Report.IsTrue(new ItemSync().RemoveIconDisplayed(), "The remove icon was not shown", "The remove icon was shown");
            Report.StartStep($"I click the Remove icon");
            Report.IsTrue(new ItemSync().RemoveIconClick(), "The remove icon was not clicked", "The remove icon was clicked");
            Report.StartStep($"I confirm the filename is no longer shown");
            Report.IsTrue(!new ItemSync().CheckAnyFileNameDisplayed(), "A Filename was still displayed", "No file name was showing");
            Report.StartStep($"I confirm the page refreshes to show the drag and drop area");
            new Steps_ItemSync().ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea();

        }


        [StepDefinition(@"I call Shared Step 125671 \(ItemSync - Invalid File pop-up\)")]
        public void Shared125671()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"I confirm I see the 'No Valid UPCs' pop-up");
            var element = new BaseModalDialog().WaitForContainerToBeVisible(30);
            Report.IsTrue(element == true, "A modal popup was not found", "A modal pop was found") ;        
            var title = new BaseModalDialog().TitleText;
            Report.IsTrue(title == "No Valid UPCs", "The title was not 'No Valid UPCs'", "The title was correctly 'No Valid UPCs'");

            Report.StartStep($"I confirm the Pop-up text shows: The file you uploaded contains no valid UPCs. Please make changes to the file you submitted, or upload a new file.");
            Report.IsTrue(new BaseModalDialog().BodyTextMatches("The file you uploaded contains no valid UPCs. Please make changes to the file you submitted, or upload a new file."), "Text did not match", "The body text was a match");

            Report.StartStep($"I confirm the Pop-up shows a Close button");
            Report.IsTrue(new BaseModalDialog().ButtonWithTextDisplayed("Close"), "A Close button was not found in the popup", "A Close button was found in the popup");

            Report.StartStep($"I click the Close Button");
            Report.IsTrue(new BaseModalDialog().ClickButtonByText("Close"), "Failed to Click the Close Button", "Successfully clicked the Close Button");

            Report.StartStep($"I confirm I do not see 'No Valid UPCs' pop-up");
            element = new BaseModalDialog().WaitForContainerToBeInvisible(30);
            Report.IsTrue(element == true, "A modal pop was found", "A modal popup was not found");

            Report.StartStep($"I confirm the ItemSync Upload a File screen shows a File Upload Area");
            new Steps_ItemSync().ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea();




        }

        [StepDefinition(@"I call Shared Step 125689 \(ItemSync - UPC Limit Exceeded pop-up\)")]
        public void Shared125689()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"I confirm I see the 'UPC Limit Exceeded' pop-up");
            var element = new BaseModalDialog().WaitForContainerToBeVisible(30);
            Report.IsTrue(element == true, "A modal popup was not found", "A modal pop was found");
            var title = new BaseModalDialog().TitleText;
            Report.IsTrue(title == "UPC Limit Exceeded", "The title was not 'UPC Limit Exceeded'", "The title was correctly 'UPC Limit Exceeded'");



            Report.StartStep($"I confirm the Pop-up text shows: The file you uploaded contains more than 1000 UPCs. Please remove UPCs from the file you submitted, or upload a new file.");
            var textBody = new BaseModalDialog().GetBodyText();
            Report.Info($"Found text: {textBody}");
            Report.IsTrue(new BaseModalDialog().BodyTextMatches("The file you uploaded contains more than 1000 UPCs. Please remove UPCs from the file you submitted, or upload a new file."), "Text did not match", "The body text was a match");
            


            Report.StartStep($"I confirm the Pop-up shows a Close button");
            Report.IsTrue(new BaseModalDialog().ButtonWithTextDisplayed("Close"), "A Close button was not found in the popup", "A Close button was found in the popup");

            Report.StartStep($"I click the Close Button");
            Report.IsTrue(new BaseModalDialog().ClickButtonByText("Close"), "Failed to Click the Close Button", "Successfully clicked the Close Button");

            Report.StartStep($"I confirm I do not see 'UPC Limit Exceeded' pop-up");
            element = new BaseModalDialog().WaitForContainerToBeInvisible(30);
            Report.IsTrue(element == true, "A modal pop was found", "A modal popup was not found");

            Report.StartStep($"I confirm the ItemSync Upload a File screen shows a File Upload Area");
            new Steps_ItemSync().ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea();



        }



        [StepDefinition(@"I call Shared Step 126165 \(RPS - ItemSync - Go to Manual Entry screen\)")]
        public void Shared126165()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"In the Retail Product Suite, In the Menu options banner, I click on: ItemSync ");
            new Steps_Navigation().ClickTab("ItemSync");
            Report.StartStep($"In the ItemSync menu options list, I select: Manual Entry");
            new Steps_Navigation().ClickSubTab("Manual Entry");
            Report.StartStep($"I confirm the screen refreshes and I see the ItemSync Manual Entry screen");
            new Steps_ItemSync().WaitFoItemSyncManualEntryScreenToLoad();


        }

        [StepDefinition(@"I call Shared Step 125709 \(ItemSync - Manual Entry - Add UPC\)")]
        public void Shared125709()
        {
            ReportSettings.UseSubSteps = true;

            new Global_Steps().GivenIGenerateARandomUPCNumberAndSaveAs("currentRandomUPC");
            string upcNum= (string)Context.GetFromContext("currentRandomUPC");
            Report.StartStep($"In the ItemSync Manual Entry screen, In the text entry field, I enter a valid UPC");           
            new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(upcNum);
            Report.StartStep($"In the ItemSync Manual Entry screen, I click the 'ADD' button");
            new Steps_ItemSync().InTheItemSyncManualEntryScreenIClickTheADDButton();

        }


        [StepDefinition(@"I call Shared Step 125709 \(ItemSync - Manual Entry - Add UPC\) for UPC: (.*)")]
        public void Shared125709GivenUPC(string savedAs)
        {
           ReportSettings.UseSubSteps = true;

           string value = savedAs;

           if (value.ToLower().Contains("array"))
           {
               string[] stringArray = (string[])Context.GetFromContext(value);
               foreach(var item in stringArray)
               {
                    new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(item);
                    Report.StartStep($"In the ItemSync Manual Entry screen, I click the 'ADD' button");
                    new Steps_ItemSync().InTheItemSyncManualEntryScreenIClickTheADDButton();
                }
                return;

           }

           if (value.ToLower().Contains("saved as"))
           {
               value = value.Replace("saved as ", "");
               Report.Info($"value: {value}");
               value = (string)Context.GetFromContext(value);
           }
           

           Report.StartStep($"In the ItemSync Manual Entry screen, In the text entry field, I enter a valid UPC");
           string upcNum = value; 
           new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(upcNum);
           Report.StartStep($"In the ItemSync Manual Entry screen, I click the 'ADD' button");
           new Steps_ItemSync().InTheItemSyncManualEntryScreenIClickTheADDButton();

        }

        [StepDefinition(@"I call Shared Step 125737 \(ItemSync > Upload File to Results page\)")]
        public void Shared125737()
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"In the Retail Product Suite, In the Menu options banner, I click on: ItemSync");
            new Steps_Navigation().ClickTab("ItemSync");
            Report.StartStep($"In the ItemSync menu options list, I select: Upload a File");
            new Steps_Navigation().ClickSubTab("Upload a File");
            Report.StartStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
            new Steps_ItemSync().WaitForUploadAFileScreenToLoad();

            //Report.StartStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
            //Report.Failure($"There is no way for us to drag and drop so we must use the file selector instead, need to check if this is suitable.");
            Report.StartStep($"In the ItemSync Upload a File screen, I click the File Upload area and open the File: 'TestMultipleUPCs.csv'");
            new Steps_ItemSync().UploadPDFFileSectionAndType("TestMultipleUPCs.csv");
            Report.StartStep($"In the Upload a File screen, I click the 'Upload' button");
            new Steps_ItemSync().InTheItemSyncUploadAFileScreenIClickTheUploadButton();
            Report.StartStep($"When the 'working' indicator is not longer shown, I confirm the page transitions to the Results page");
            new Steps_ItemSync().WaitFoItemSyncManualEntryScreenToLoad();
            new Steps_ItemSync().IConfirmTheItemSyncResultsPageShowsTheTitle();
            Report.IsTrue(new ItemSync().ConfirmUPCDetailsResultsTableShown(),"Failed to find the table","The Results table was found");

        }

        [StepDefinition(@"I call Shared Step 125737 \(ItemSync > Upload File to Results page\) for file: (.*)")]
        public void Shared125737FileX(string fileName)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"In the Retail Product Suite, In the Menu options banner, I click on: ItemSync");
            new Steps_Navigation().ClickTab("ItemSync");
            Report.StartStep($"In the ItemSync menu options list, I select: Upload a File");
            new Steps_Navigation().ClickSubTab("Upload a File");
            Report.StartStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
            new Steps_ItemSync().WaitForUploadAFileScreenToLoad();

            //Report.StartStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
            //Report.Failure($"There is no way for us to drag and drop so we must use the file selector instead, need to check if this is suitable.");
            Report.StartStep($"In the ItemSync Upload a File screen, I click the File Upload area and open the File: '{fileName}'");
            new Steps_ItemSync().UploadPDFFileSectionAndType(fileName);
            Report.StartStep($"In the Upload a File screen, I click the 'Upload' button");
            new Steps_ItemSync().InTheItemSyncUploadAFileScreenIClickTheUploadButton();
            Report.StartStep($"When the 'working' indicator is not longer shown, I confirm the page transitions to the Results page");
            new Steps_ItemSync().WaitFoItemSyncManualEntryScreenToLoad();
            new Steps_ItemSync().IConfirmTheItemSyncResultsPageShowsTheTitle();
            Report.IsTrue(new ItemSync().ConfirmUPCDetailsResultsTableShown(), "Failed to find the table", "The Results table was found");

        }







    }
}

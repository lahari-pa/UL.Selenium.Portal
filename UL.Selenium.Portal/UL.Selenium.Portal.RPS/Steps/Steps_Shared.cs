using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Automation.Reporting.Classes;
using System.Threading;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "Shared")]
	class Steps_Shared
	{
		[RegexStepDefinition(@"I call Shared Step 104950 \(RPS Login - Base Functionality\) for TReVor account: (.*)")]
		public void GivenICallSharedStepRPSLogin_BaseFunctionalityForTReVorAccountRPS_CV(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the landing page");
			new Global_Steps().NavigateToTheLandingPage();
			Report.StartSubStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();
			if (!TReVor.Integrations.Classes.TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.StartSubStep("I enter the account username for: " + savedAs);
			new Steps_Login().EnterUserNameForTrevorTestUser(user);
			Report.StartSubStep("I enter the account password for: " + savedAs);
			new Steps_Login().EnterPasswordForTrevorTestUser(user);
			Report.StartSubStep("I click Log In");
			new Steps_Login().ClickLogIn();
			GeneralUtilities.WaitForLoadingToFinish();
			Context.AddToContext("ActiveUser", user);
		}

		[RegexStepDefinition(@"I call Shared Step 106194 \(RPS Sign out\)")]
		public void SharedStep106194()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("In the Top Bar, I click on the logged in user name");
			new Steps_TopBar().ClickUserNameButtonTopBar();
			Report.StartSubStep("In the drop down menu, I click: Sign Out");
			new Steps_TopBar().ClickSignOut();
		}


		[RegexStepDefinition(@"I call Shared Step 134361 \(RPS Login - User does not have access to ItemSync\)")]
		public void Shared134361()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the landing page");
			new Global_Steps().NavigateToTheLandingPage();
			Report.StartSubStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();
			string savedAs = "RPS.HD";
			if (TReVor.Integrations.Classes.TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.StartSubStep("I enter the account username for: " + savedAs);
			new Steps_Login().EnterUserNameForTrevorTestUser(user);
			Report.StartSubStep("I enter the account password for: " + savedAs);
			new Steps_Login().EnterPasswordForTrevorTestUser(user);
			Report.StartSubStep("I click Log In");
			new Steps_Login().ClickLogIn();
			GeneralUtilities.WaitForLoadingToFinish();
			Context.AddToContext("ActiveUser", user);
		}


		[RegexStepDefinition(@"I call Shared Step 134359 \(RPS Login - User has Standard ItemSync Access\)")]
		public void Shared134359()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the landing page");
			new Global_Steps().NavigateToTheLandingPage();
			Report.StartSubStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();
			string savedAs = "RPS.LW";
			if (TReVor.Integrations.Classes.TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.StartSubStep("I enter the account username for: " + savedAs);
			new Steps_Login().EnterUserNameForTrevorTestUser(user);
			Report.StartSubStep("I enter the account password for: " + savedAs);
			new Steps_Login().EnterPasswordForTrevorTestUser(user);
			Report.StartSubStep("I click Log In");
			new Steps_Login().ClickLogIn();
			GeneralUtilities.WaitForLoadingToFinish();
			Context.AddToContext("ActiveUser", user);
		}

		[RegexStepDefinition(@"I call Shared Step 134362 \(RPS Login - User has Subscription ItemSync access\)")]
		public void Shared134362()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the landing page");
			new Global_Steps().NavigateToTheLandingPage();
			Report.StartSubStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();
			string savedAs = "RPS.99";
			if (TReVor.Integrations.Classes.TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.StartSubStep("I enter the account username for: " + savedAs);
			new Steps_Login().EnterUserNameForTrevorTestUser(user);
			Report.StartSubStep("I enter the account password for: " + savedAs);
			new Steps_Login().EnterPasswordForTrevorTestUser(user);
			Report.StartSubStep("I click Log In");
			new Steps_Login().ClickLogIn();
			GeneralUtilities.WaitForLoadingToFinish();
			Context.AddToContext("ActiveUser", user);
		}


		[RegexStepDefinition(@"I call Shared Step 106517 \(Home > Replace an original widget\) for widget: (.*)")]
		public void SharedStep106517(string widget)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget);
			new Steps_Home().ClickDropDownToggle(widget);
			Delay.Seconds(5);
			Report.StartSubStep("I click 'Replace'");
			new Steps_Home().ClickDropdownOptionWidget("Replace", widget);
			Report.StartSubStep("I select the first option in the list on the Select Chart Type popup");
			new Steps_Home().ClickFirstListOption("NewWidget");
			Report.StartSubStep("Confirm Select Chart Type popup closes");
			new Steps_Home().ConfirmSelectChartTypePopupCloses();
			Report.StartSubStep("I confirm that the Home page refreshes");
			new Steps_Home().HomeTabLoaded();
			Report.StartSubStep($"I confirm the widget: {widget} is no longer displayed");
			new Steps_Home().ConfirmWidgetDisplayedOrNot(widget, "is not");
			Report.StartSubStep("I confirm the widget I selected in the Select Chart Type popup is displayed");
			new Steps_Home().ConfirmWidgetDisplayedOrNot("%NewWidget%", "is");
		}

		[RegexStepDefinition(@"I call Shared Step 70474 \(Verify Chart functionality\) for widget: (.*)")]
		public void SharedStep70475(string widget)
		{
			Report.UseSubSteps = true;

			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
			Report.StartSubStep("I save the current graph view titles for the widget to context as: CurrentGraphViewFullTitles");
			List<string> graphViewTitlesFull = new WidgetPage.Widget(widget).CurrentChartFullTitlesGraphView();
			Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Data View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Data");
			Report.StartSubStep("I save the current data view titles for the widget to context as: CurrentDataViewFullTitles");
			List<string> dataViewTitlesFull = new List<string>();
			dataViewTitlesFull = new WidgetPage.Widget(widget).GetCurrentDataTitlesWithCount();
			Context.AddToContext("CurrentDataViewFullTitles", dataViewTitlesFull);
			Report.StartSubStep("I confirm the data shown in the data view matches the Graph I saw earlier");
			var differences = graphViewTitlesFull.Except(dataViewTitlesFull);
			if (differences.Any())
			{

				if (differences.Any(x => x.Contains("...")))
				{
					Report.Info("Some of the titles found on the graph view contained '...', using an additional method to check the shorted titles are a match");
					new WidgetPage.Widget(widget).ComparePieChartDataToShortGraphTitles(graphViewTitlesFull, dataViewTitlesFull);

				}
				else
				{
					Report.IsTrue(!differences.Any(), "The titles found for both views did not match2", "The titles found for both view matched");
				}
			}
			else
			{
				Report.IsTrue(!differences.Any(), "The titles found for both views did not match1", "The titles found for both view matched");
			}
			List<string> dataViewNamesOnly = new WidgetPage.Widget(widget).GetCurrentDataTitles();
			Context.AddToContext("CurrentDataViewNamesOnly", dataViewNamesOnly);
			List<string> dataViewCountsOnly = new WidgetPage.Widget(widget).GetCurrentDataTitlesCountOnly();
			Context.AddToContext("CurrentDataViewCountsOnly", dataViewCountsOnly);

			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
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

			Report.StartSubStep("I Check that the CSV downloaded contains the expected data");
			new Global_Steps().ICheckCSVContainsValues("CurrentOutputCSV", "CurrentValuesDictionary");
			Report.StartSubStep($"I Delete the file saved as: CurrentOutputCSV");
			new Global_Steps().DeleteFile("CurrentOutputCSV");
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
			Report.StartSubStep("Currently Missing the Print Steps Due to Selenium Limitations");
			Report.StartSubStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download PNG image");
			new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download PNG image");
			Report.StartSubStep($"I confirm that a file is produced called chart.png and save as savedasPNG70474");
			new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.png", "savedasPNG70474");
			Report.StartSubStep($"I open the file saved as: savedasPNG70474 and take a screenshot");
			new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasPNG70474");
			Report.StartSubStep($"I Close the window that was opened");
			new Global_Steps().ThenCloseTheWindowThatOpened();
			Report.StartSubStep($"I Delete the file saved as: savedasPNG70474 ");
			new Global_Steps().DeleteFile("savedasPNG70474");
			Report.StartSubStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download JPEG image");
			new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download JPEG image");
			Report.StartSubStep($"I confirm that a file is produced called chart.jpeg and save as savedasJPEG70474");
			new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.jpeg", "savedasJPEG70474");
			Report.StartSubStep($"I open the file saved as: savedasJPEG70474 and take a screenshot");
			new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasJPEG70474");
			Report.StartSubStep($"I Close the window that was opened");
			new Global_Steps().ThenCloseTheWindowThatOpened();
			Report.StartSubStep($"I Delete the file saved as: savedasJPEG70474 ");
			new Global_Steps().DeleteFile("savedasJPEG70474");
			Report.StartSubStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download PDF document");
			new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download PDF document");
			Report.StartSubStep($"I confirm that a file is produced called chart.pdf and save as savedasPDF70474");
			new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.pdf", "savedasPDF70474");
			Report.StartSubStep($"I open the file saved as: savedasPDF70474 and take a screenshot");
			new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasPDF70474");
			Report.StartSubStep($"I Close the window that was opened");
			new Global_Steps().ThenCloseTheWindowThatOpened();
			Report.StartSubStep($"I Delete the file saved as: savedasPDF70474 ");
			new Global_Steps().DeleteFile("savedasPDF70474");
			Report.StartSubStep($"I Click the hamburger menu for the widget: {widget} and select the option: Download SVG vector image");
			new Steps_Home().IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget, "Download SVG vector image");
			Report.StartSubStep($"I confirm that a file is produced called chart.svg and save as savedasSVG70474");
			new Global_Steps().ConfirmFileAppearsInDownloadsFolder("chart.svg", "savedasSVG70474");
			Report.StartSubStep($"I open the file saved as: savedasSVG70474 and take a screenshot");
			new Global_Steps().IOpenTheFileSavedAsAndTakeAScreenShot("savedasSVG70474");
			Report.StartSubStep($"I Close the window that was opened");
			new Global_Steps().ThenCloseTheWindowThatOpened();
			Report.StartSubStep($"I Delete the file saved as: savedasSVG70474 ");
			new Global_Steps().DeleteFile("savedasSVG70474");

		}

		[RegexStepDefinition(@"I call Shared Step 111976 \(Click UL Solutions Logo - Confirm Home page shown\)")]
		public void GivenICallSharedStepClickWERCSmartProductSuiteLogo_ConfirmHomePageShownA()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("In the Top Bar,  I check that the WERCSmart® Product Suite Logo is showing ");
			new Steps_TopBar().ProductSuiteLogoDisplayedInRPS();
			Report.StartSubStep("I click the UL logo ");
			new Steps_TopBar().ClickUlLogo();
			Report.StartSubStep("I confirm I am redirected to the Home tab");
			new Steps_Home().HomeTabLoadedInRPS();
		}

		[RegexStepDefinition(@"I call Shared Step 70484 \(Chart Drill-down Export\) for widget: (.*)")]
		public void SharedStep70484(string widget)
		{
			Report.UseSubSteps = true;

			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
			Report.StartSubStep("I save the current graph view titles for the widget to context as: CurrentGraphViewFullTitles");
			List<string> graphViewTitlesFull = new WidgetPage.Widget(widget).CurrentChartFullTitlesGraphView();
			Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);
			string chartType = new WidgetPage.Widget(widget).Type;
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Data View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Data");
			Report.StartSubStep("I save the current data view titles for the widget to context as: CurrentDataViewFullTitles");
			List<string> dataViewTitlesFull = new List<string>();
			dataViewTitlesFull = new WidgetPage.Widget(widget).GetCurrentDataTitlesWithCount();
			Context.AddToContext("CurrentDataViewFullTitles", dataViewTitlesFull);
			Report.StartSubStep("I confirm the data shown in the data view matches the Graph I saw earlier");
			var differences = graphViewTitlesFull.Except(dataViewTitlesFull);
			if (differences.Any())
			{

				if (differences.Any(x => x.Contains("...")))
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
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
			new Steps_Home().ClickDropDownToggle(widget);
			new Steps_Home().ClickDropdownOptionWidget("Export", widget);
			Delay.Seconds(3);
			new Global_Steps().SaveDownloads();
			new Global_Steps().ConfirmNewFile("ExportFile");
			new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
			FileInfo fileName = (FileInfo)Context.GetFromContext("ExportFile");
			string filepath = fileName.FullName;
			Context.AddToContext("CurrentOutputCSV", filepath);
			Context.AddToContext("CurrentValuesDictionary", GeneralUtilities.ConvertTwoListsToDictonary(dataViewNamesOnly, dataViewCountsOnly));
			Report.StartSubStep("I Check that the CSV downloaded contains the expected data");
			new Global_Steps().ICheckCSVContainsValues("CurrentOutputCSV", "CurrentValuesDictionary");
			Report.StartSubStep($"I Delete the file saved as: CurrentOutputCSV");
			new Global_Steps().DeleteFile("CurrentOutputCSV");
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
			Report.StartSubStep("I Select the First Area/Section of the Chart");
			if (widget == "Supplier Subscription Status")
			{

				Report.Info("The widget that is being interacted with is the 'Supplier Subscription Status' widget, there for we will use steps that account for the supplier List appearing on the first drill down");
				new Global_Steps().ForSupplierSubscriptionStatusIPerformChartDrillDownExport();
				Report.Info("The steps for the 'Supplier Subscription Status' widget are finished");
				return;

			}
			new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(widget, "CurrentChartTitles", "<first>");
			Report.StartSubStep("I confirm that if a chart is shown I see the same type of chart as shown in the initial display of the widget");
			string newChartType = new WidgetPage.Widget(widget).Type;
			Report.IsTrue(chartType == newChartType, "The type of chart found was not the same as the previous chart type before the section was clicked", "The type of chart found was the same as the previous chart type before the section was clicked");
			Report.StartSubStep("I save the current graph view titles for the widget to context as: CurrentGraphViewFullTitles");
			graphViewTitlesFull = new WidgetPage.Widget(widget).CurrentChartFullTitlesGraphView();
			Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);
			Context.AddToContext("CurrentGraphViewFullTitles", graphViewTitlesFull);



			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Data View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Data");
			Report.StartSubStep("I save the current data view titles for the widget to context as: CurrentDataViewFullTitles");
			dataViewTitlesFull = new List<string>();
			dataViewTitlesFull = new WidgetPage.Widget(widget).GetCurrentDataTitlesWithCount();
			Context.AddToContext("CurrentDataViewFullTitles", dataViewTitlesFull);
			Report.StartSubStep("I confirm the data shown in the data view matches the Graph I saw earlier");
			differences = graphViewTitlesFull.Except(dataViewTitlesFull);
			if (differences.Any())
			{

				if (differences.Any(x => x.Contains("...")))
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
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
			new Steps_Home().ClickDropDownToggle(widget);
			new Steps_Home().ClickDropdownOptionWidget("Export", widget);
			new Global_Steps().SaveDownloads();
			new Global_Steps().ConfirmNewFile("ExportFile");
			new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
			fileName = (FileInfo)Context.GetFromContext("ExportFile");
			filepath = fileName.FullName;
			Context.AddToContext("CurrentOutputCSV", filepath);
			Context.AddToContext("CurrentValuesDictionary", GeneralUtilities.ConvertTwoListsToDictonary(dataViewNamesOnly, dataViewCountsOnly));
			Report.StartSubStep("I Check that the CSV downloaded contains the expected data");
			new Global_Steps().ICheckCSVContainsValues("CurrentOutputCSV", "CurrentValuesDictionary");
			Report.StartSubStep($"I Delete the file saved as: CurrentOutputCSV");
			new Global_Steps().DeleteFile("CurrentOutputCSV");
			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Graph View and confirm a graph appears");
			new Steps_Home().ForWidgetISwitchToView(widget, "Graph");
			Report.StartSubStep("I Select the First Area/Section of the Chart");
			new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatProductDataSeen(widget, "CurrentChartTitles", "<first>");
			Report.StartSubStep("I Confirm the Products List Is Showing");
			new Steps_Home().WaitForAllWidgets();
			new Steps_Home().ProductContentDisplayedForTitle("is", widget);
			Report.StartSubStep("I confirm I see a Back button to the top right of the Widget Main Body area");
			Report.IsTrue(new Home.Widget(widget).ProductsListBackButtonDisplayed(), "The Back button was not displayed", "The back button was displayed");


			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
			new Steps_Home().ClickDropDownToggle(widget);
			new Steps_Home().ClickDropdownOptionWidget("Export", widget);
			new Global_Steps().SaveDownloads();
			new Global_Steps().ConfirmNewFile("ExportFile");
			new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
			fileName = (FileInfo)Context.GetFromContext("ExportFile");
			filepath = fileName.FullName;
			Context.AddToContext("CurrentOutputCSV", filepath);


			Report.StartSubStep("I Get the current Product List Items, save them to context as 'CurrentProductListItems' and then check they match the csv export saved as 'CurrentOutputCSV'");
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
			Report.StartSubStep($"I Delete the file saved as: CurrentOutputCSV");
			new Global_Steps().DeleteFile("CurrentOutputCSV");
			Report.StartSubStep("In the widget main body area, I click: Back");

			Report.IsTrue(new Home.Widget(widget).ProductsListBackButtonDisplayed(), "Failed to find the Products list back button", "Successfully found the Products list back button");
			Report.IsTrue(new Home.Widget(widget).ClickProductsListBackButton(), "Failed to click the back button", "Successfully clicked the back button");
			Report.IsTrue(new Home.Widget(widget).WaitUntilGraphXIsDisplayed(), "The graph content did not appear", "The graph content was shown");
			new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickBackTheTitlesChange("currentTitles", widget);




		}

		[RegexStepDefinition(@"I call Shared Step 70484 \(Chart Drill-down Export\) for the saved widget")]
		public void SharedStep70484Saved()
		{
			Home.Widget widget = new Home().GetWidget("%ThisWidget%");
			SharedStep70484(widget.Title);
		}

		[RegexStepDefinition(@"I call Shared Step 109167 \(Product Information pop up - layout verification\)")]
		public void SharedStep109167()
		{
			Report.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartSubStep("In the Product Information pop up, I confirm heading text reads: Product Information");
			Report.IsTrue(new ProductInformation().HeadingTextMatches("Product Information"), "The heading text was not as expected", "The heading was as expected");
			Report.StartSubStep("In the Product Information pop up heading area,  I confirm the x (close icon) is shown");
			Report.IsTrue(new ProductInformation().CrossCloseIconExists() && new ProductInformation().CloseButtonExists(), "The Close buttons were not found", "The Close buttons were found");
			Report.StartSubStep("In the Product Information pop up - main body area, I confirm product details are:");
			List<string> mainBodyHeaders = new List<string> { "Product :", "Supplier :", "Supplier Contact :" };
			Report.IsTrue(new ProductInformation().ProductTopDataHeadingsPresent(mainBodyHeaders), "The headings were not as expected", "The headings were as expected");
			Report.StartSubStep("Below the product details, I confirm I see 4 headings:");
			List<string> sectionHeadings = new List<string> { "Product Details", "Transportation", "Storage", "Battery" };
			Report.IsTrue(new ProductInformation().ProductInformatinSectionsPresent(sectionHeadings), "The headings were not as expected", "The headings were as expected");
		}

		[RegexStepDefinition(@"I call Shared Step 109168 \(Product Information pop up - Expand Product Details - confirm rows\)")]
		public void SharedStep109168()
		{
			Report.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
            Report.StartSubStep("In the Product Information pop up, I click the Collapse All");
			new Steps_ProductInformation().InTheProductInformationPopupPopupIClickCollapseAll();
            Report.StartSubStep("In the Product Information pop up, I click the Product Details heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartSubStep("I confirm that an additional area is shown below the Product Data Codes heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Data Codes heading was not showing", "The additional area is shown below the Product Data Codes heading was showing");

			List<string> expectedHeadings = new List<string> { "Supplier Contact Name", "US EPA Waste Number", "Flash point °C", "Flash point (°C) DEGREES" };
			Report.StartSubStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().ProductDataCodesHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Product Data Codes heading");
			Report.StartSubStep("I confirm the additional area below the Product Data Codes heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Data Codes heading was showing", "The additional area is shown below the Product Data Codes heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 109169 \(Product Information pop up - Expand Transportation - confirm rows\)")]
		public void SharedStep109169()
		{
			Report.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
            Report.StartSubStep("In the Product Information pop up, I click the Collapse All");
            new Steps_ProductInformation().InTheProductInformationPopupPopupIClickCollapseAll();
            Report.StartSubStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.StartSubStep("I confirm that an additional area is shown below the Transportation heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation heading was not showing", "The additional area is shown below the Transportation heading was showing");
			List<string> expectedHeadings = new List<string> { "Emergency Response Guide Number", "Hazard Class", "UN-No.", "Packing Group", "DOT Vessel Limited Quantity w/units (BASIC RETAILER)", "DOT Marine Pollutant?", "Marine pollutant <5L/5KG", "Miscible in Water?" };
			Report.StartSubStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().TransporationDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartSubStep("In the Product Information pop up, I click the Transportation heading");
			Report.StartSubStep("I confirm the additional area below the Transportation heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation Data heading was showing", "The additional area is shown below the Transportation Data heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 109170 \(Product Information pop up - Expand Storage - confirm rows\)")]
		public void SharedStep109170()
		{
			Report.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
            Report.StartSubStep("In the Product Information pop up, I click the Collapse All");
            new Steps_ProductInformation().InTheProductInformationPopupPopupIClickCollapseAll();
            Report.StartSubStep("In the Product Information pop up, I click the Storage heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was not expanded", "The section was expanded");
			Report.StartSubStep("I confirm that an additional area is shown below the Storage heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage"), "The additional area is shown below the Storage heading was not showing", "The additional area is shown below the Storage heading was showing");
			List<string> expectedHeadings = new List<string> { "Uniform Fire Code", "International Fire Code", "Health Hazards", "Flammability", "Stability", "Physical and Chemical Hazards" };
			Report.StartSubStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().StorageHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartSubStep("In the Product Information pop up, I click the Storage heading");
			Report.StartSubStep("I confirm the additional area below the Storage heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Storage"), "The additional area is shown below the Storage heading was showing", "The additional area is shown below the Storage Data heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 109171 \(Product Information pop up - Expand Battery - confirm rows\)")]
		public void SharedStep109171()
		{
			Report.UseSubSteps = true;
            Report.StartSubStep("In the Product Information pop up, I click the Collapse All");
            new Steps_ProductInformation().InTheProductInformationPopupPopupIClickCollapseAll();
            Report.StartSubStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.StartSubStep("I confirm that an additional area is shown below the Battery heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was not showing", "The additional area is shown below the Battery heading was showing");
			List<string> expectedHeadings = new List<string> { "Does the product contain a battery or is it shipped with a battery?", "Product Itself is a Battery", "How Battery Resides in Product", "Watt hours for Li Batteries", "Weight of battery", "Quantity (grams) of Lithium present in battery", "Number of Batteries", "UN38.3 tested?", "IATA quality management system", "Number of batteries/cells used to run equipment" };
			Report.StartSubStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().BatteryHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartSubStep("In the Product Information pop up, I click the  Battery heading");
			Report.StartSubStep("I confirm the additional area below the  Battery heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was showing", "The additional area is shown below the Battery heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 109172 \(Product information pop up - Only 1 section expands at a time\)")]
		public void SharedStep109172()
		{
			Report.UseSubSteps = true;
            Report.StartSubStep("In the Product Information pop up, I click the Collapse All");
            new Steps_ProductInformation().InTheProductInformationPopupPopupIClickCollapseAll();
            Report.StartSubStep("In the Product Information pop up, I click the Product Data Codes heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Report.StartSubStep("I confirm that an additional area is shown below the Product Details heading");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
			Report.StartSubStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Report.StartSubStep("I confirm that an additional area is shown below the Transportation heading");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
			Report.StartSubStep("In the Product Information pop up, I click the Storage heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage"), "Failed to Click the section", "Successfully clicked the section");
			Report.StartSubStep("I confirm that an additional area is shown below the Storage heading");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
			Report.StartSubStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Report.StartSubStep("I confirm that an additional area is shown below the Battery heading");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the heading was not showing", "The additional area is shown below the heading was showing");
		}

		[RegexStepDefinition(@"I call Shared Step 108597 \(Widget data view - Contact Supplier - email verification\) for widget: (.*)")]
		public void SharedStep108597(string widget)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I the widget main body area, I click on the first section of the chart ");
			new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(widget, "CurrentChartTitles", "<first>");
			new Steps_Home().WaitForAllWidgets();
			Report.StartSubStep("I the widget main body area, I click on the first section of the chart ");
			new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatProductDataSeen(widget, "CurrentChartTitles", "<first>");
			Report.StartSubStep("I Confirm the Products List Is Showing");
			new Steps_Home().WaitForAllWidgets();
			Report.Error("MANUAL REVIEW REQUIRED FOR THIS STEP AS IT IS OUTSIDE OF THE SCOPE OF AUTOMATION");
			//We can not currently/wont automate this because we don't access outlook in automation and also do not want to send emails etc.



		}

		[RegexStepDefinition(@"I call Shared Step 106605 \(Dashboard - Remove Widget\) for widget: (.*)")]
		public void SharedStep106605(string widget)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the dropdown toggle for the widget");
			new Steps_Home().ClickDropDownToggle(widget);
			Report.StartSubStep("I click 'Remove' in the dropdown menu for the saved widget");
			new Steps_Home().ClickDropdownOptionWidget("Remove", widget);
			Report.StartSubStep("I confirm the widget is no longer displayed");
			new Steps_Home().ConfirmWidgetDisplayedOrNot(widget, "is not");
		}

		[RegexStepDefinition(@"I call Shared Step 106605 \(Dashboard - Remove Widget\) for all widgets except: (.*)")]
		public void SharedStep106605ForAllExcept(string widget)
		{
			Report.UseSubSteps = true;
			Report.Info($"Attempting to remove all widgets except the {widget} widget.");
			foreach (var iWidgetTitle in new Home().WidgetTitles)
			{
				if (iWidgetTitle != widget)
				{
					SharedStep106605(iWidgetTitle);

				}
			}
		}

		[RegexStepDefinition(@"I call Shared Step 106605 \(Dashboard - Remove Widget\) for all widgets except the saved widget")]
		public void SharedStep106605ForAllExceptSavedWidget()
		{
			Home.Widget widget = new Home().GetWidget("%ThisWidget%");
			SharedStep106605ForAllExcept(widget.Title);
		}

		[RegexStepDefinition(@"I call Shared Step 54484 \(Dashboard - Gauge - Reset Dashboard - confrim page refreshes\)")]
		public void SharedStep54484()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Gauge button in the navigation bar");
			new NavBarTools().ClickGauge();
			Report.StartSubStep("I click the Reset Dashboard dropdown option below the navigation bar Gauge button");
			new Steps_Navigation().ClickResetDashboardDropdown("Reset Dashboard");
			Report.StartSubStep("I confirm the Dashboard tab has loaded");
			new Steps_Dashboard().HomeTabLoaded();
		}

		[RegexStepDefinition(@"I call Shared Step 106623 \(Dashboard - Gauge - Re-add removed widget\) for widget: (.*)")]
		public void SharedStep106623(string widget)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I click the Gauge button in the navigation bar");
			new NavBarTools().ClickGauge();
			Report.StartSubStep("I confirm menu options shows the following Options");
			var table = new Table("Option");
			table.AddRow(widget);
			table.AddRow("Reset Dashboard");
			table.AddRow("Refresh All Widgets");
			new Steps_Navigation().ConfirmDropDownOptionsNavBarGauge(table);
			Report.StartSubStep("");
			new NavBarTools().SelectDropDownOption(widget);
			Report.StartSubStep("I confirm the widget is now shown");
			new Steps_Home().ConfirmWidgetDisplayedOrNot(widget, "is");

		}

		[RegexStepDefinition(@"I call Shared Step 111155 \(Table Heading or sub heading - confirm column resize anchor - resize column\) On the: (.*) page, for the column: (.*)")]
		public void SharedStep111155(string pageName, string column)
		{
			Report.UseSubSteps = true;




			if (pageName == "Recent Activities")
			{


				if (column == "Product ID" || column == "UPC Number")
				{
					IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
					Report.StartSubStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
					Report.IsTrue(new RecentActivities().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
					Report.StartSubStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
					Report.StartSubStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
					Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
					Report.IsTrue(new RecentActivities().MakeColumnSmaller(column, row), "Failed to shrink the column", "Successfully shrunk the column");
					Report.StartSubStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
					Report.IsTrue(new RecentActivities().MakeColumnBigger(column, row), "Failed to expand the column", "Successfully expanded the column");

				}
				else
				{

					Report.StartSubStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
					Report.IsTrue(new RecentActivities().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
					Report.StartSubStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
					Report.StartSubStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
					Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
					Report.IsTrue(new RecentActivities().MakeColumnSmaller(column), "Failed to shrink the column", "Successfully shrunk the column");
					Report.StartSubStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
					Report.IsTrue(new RecentActivities().MakeColumnBigger(column), "Failed to expand the column", "Successfully expanded the column");
				}
				return;
			}

			if (pageName == "Drum Log")
			{
				if (column == "Scan Date" || column == "Date In Drum" || column == "Date Removed" || column == "Found/NotFound" || column == "Manufacturer" || column == "Name" || column == "Product" || column == "UPC" || column == "Volume" || column == "Actions")
				{
					IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
					Report.StartSubStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
					Report.IsTrue(new DrumLog().CheckFirstExpandedRowColumnContainsResizeAnchor(row, column), "the column did not contain a resize anchor icon", "The column contains a resize anchor icon");
					Report.StartSubStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
					Report.StartSubStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
					Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
					Report.IsTrue(new DrumLog().MakeColumnSmaller(column, row), "Failed to shrink the column", "Successfully shrunk the column");
					Report.StartSubStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
					Report.IsTrue(new DrumLog().MakeColumnBigger(column, row), "Failed to expand the column", "Successfully expanded the column");

				}
				else
				{

					Report.StartSubStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
					Report.IsTrue(new DrumLog().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
					Report.StartSubStep("~~MANUAL REVIEW~~ I move my mouse over the column resize anchor and confirm the mouse pointer changes to show <-||->");
					Report.StartSubStep("I confirm I can re-size the column by selecting the column resize anchor and moving my mouse left so that the column name is only partially shown");
					Report.Info("Due to a selenium limitation we are unable to resize the column to be too small so that the heading text is hidden. This may need manual review");
					Report.IsTrue(new DrumLog().MakeColumnSmaller(column), "Failed to shrink the column", "Successfully shrunk the column");
					Report.StartSubStep("I confirm I can re-select the column size anchor for the column I am working with, and I can resize the column again");
					Report.IsTrue(new DrumLog().MakeColumnBigger(column), "Failed to expand the column", "Successfully expanded the column");

				}


				return;
			}

			Report.Failure("Unable to find page");


		}

		[RegexStepDefinition(@"I call Shared Step 106809 \(Breadcrumbs - Supplier Name field - confirm shown correctly and remove\) for text: (.*)")]
		public void SharedStep106809(string value)
		{
			if (value.Contains("SavedProduct"))
			{
				value = (string)Context.GetFromContext(value);
			}
			Report.UseSubSteps = true;
			Report.StartSubStep("In the Filters: breadcrumb area I confirm I see the 'Supplier Name:' breadcrumb button");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel("Supplier Name:");
			Report.StartSubStep($"I confirm the Supplier breadcrumb shows the text: '{value}' that I entered into the more filters Supplier Name field");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(value);
			Report.StartSubStep($"I click the x at the far right of the Supplier breadcrumb button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX("Supplier Name");
			Report.StartSubStep("I confirm the Supplier breadcrumb button is no longer shown");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel("does not", "Supplier Name:");

		}



		[RegexStepDefinition(@"I call Shared Step 106777 \(Breadcrumbs - Status Name field - confirm shown correctly and remove\) for text: (.*)")]
		public void SharedStep106777(string value)
		{

			Report.UseSubSteps = true;
			Report.StartSubStep("In the Filters: breadcrumb area I confirm I see the 'Status:' breadcrumb button");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel("Status:");
			Report.StartSubStep($"I confirm the Supplier breadcrumb shows the text: '{value}' that I entered into the more filters Status field");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(value);
			Report.StartSubStep($"I click the x at the far right of the Status breadcrumb button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheBreadCrumbX("status");
			Report.StartSubStep("I confirm the Supplier breadcrumb button is no longer shown");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel("does not", "Status:");

		}


		[RegexStepDefinition(@"I call Shared Step 107729 \(Breadcrumbs - General shared step - confirm shown correctly and remove\) for filter: (.*) and text: (.*)")]
		public void SharedStep107729(string filter, string value)
		{

			Report.UseSubSteps = true;
			Report.StartSubStep($"In the Filters: breadcrumb area I confirm I see the '{filter}:' breadcrumb button");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(filter + ":");
			Report.StartSubStep($"I confirm the {filter} breadcrumb shows the text: '{value}' that I entered into the more filters Status field");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(value);

			Report.StartSubStep($"I click the x at the far right of the {filter} breadcrumb button");
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

			Report.StartSubStep($"I confirm the {filter} breadcrumb button is no longer shown");
			new Steps_RecentActivities().IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel("does not", filter + ":");

		}


		[RegexStepDefinition(@"I call Shared Step 111879 \(Product Information pop up - when no data available\)")]
		public void SharedStep111879(string status)
		{



		}

		[RegexStepDefinition(@"I call Shared Step 108016 \(Help & Support pop up - X to close\)")]
		public void SharedStep1080164()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("In the Help & Support pop up, I click the X icon");
			new Steps_HelpAndSupport().ClickTheIconInTheHelpAndSupportPopup();
			Report.StartSubStep("I confirm the Help & Support pop up is closed");
			new Steps_HelpAndSupport().HelpAndSupportPopupNotDisplayed();
			Report.StartSubStep("I confirm I see the Retail Product Suite Home page");
			new Steps_Home().HomeTabLoaded();

		}

		[RegexStepDefinition(@"I call Shared Step 98339 \(RPS Lowe's Login\)")]
		public void Shared104950()
		{
			Report.UseSubSteps = true;
			string savedAs = "RPS.LW";
			Report.StartSubStep("I navigate to the landing page");
			new Global_Steps().NavigateToTheLandingPage();
			Report.StartSubStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();
			if (TReVor.Integrations.Classes.TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.StartSubStep("I enter the account username for: " + savedAs);
			new Steps_Login().EnterUserNameForTrevorTestUser(user);
			Report.StartSubStep("I enter the account password for: " + savedAs);
			new Steps_Login().EnterPasswordForTrevorTestUser(user);
			Report.StartSubStep("I click Log In");
			new Steps_Login().ClickLogIn();
			GeneralUtilities.WaitForLoadingToFinish();
			Context.AddToContext("ActiveUser", user);
		}

		[RegexStepDefinition(@"I call Shared Step 125598 \(ItemSync - Upload a File - Remove icon - page refreshes\)")]
		public void Shared125598()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"I confirm to the right of the filename I see a Remove icon (garbage can)");
			Report.IsTrue(new ItemSync().RemoveIconDisplayed(), "The remove icon was not shown", "The remove icon was shown");
			Report.StartSubStep($"I click the Remove icon");
			Report.IsTrue(new ItemSync().RemoveIconClick(), "The remove icon was not clicked", "The remove icon was clicked");
			Report.StartSubStep($"I confirm the filename is no longer shown");
			Report.IsTrue(!new ItemSync().CheckAnyFileNameDisplayed(), "A Filename was still displayed", "No file name was showing");
			Report.StartSubStep($"I confirm the page refreshes to show the drag and drop area");
			new Steps_ItemSync().ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea();

		}


		[RegexStepDefinition(@"I call Shared Step 125671 \(ItemSync - Invalid File pop-up\)")]
		public void Shared125671()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"I confirm I see the 'No Valid UPCs' pop-up");
			var element = new BaseModalDialog().WaitForContainerToBeVisible(30);
			Report.IsTrue(element == true, "A modal popup was not found", "A modal pop was found");
			var title = new BaseModalDialog().TitleText;
			Report.IsTrue(title == "No Valid UPCs", "The title was not 'No Valid UPCs'", "The title was correctly 'No Valid UPCs'");

			Report.StartSubStep($"I confirm the Pop-up text shows: The file you uploaded contains no valid UPCs. Please make changes to the file you submitted, or upload a new file.");
			Report.IsTrue(new BaseModalDialog().BodyTextMatches("The file you uploaded contains no valid UPCs. Please make changes to the file you submitted, or upload a new file."), "Text did not match", "The body text was a match");

			Report.StartSubStep($"I confirm the Pop-up shows a Close button");
			Report.IsTrue(new BaseModalDialog().ButtonWithTextDisplayed("Close"), "A Close button was not found in the popup", "A Close button was found in the popup");

			Report.StartSubStep($"I click the Close Button");
			Report.IsTrue(new BaseModalDialog().ClickButtonByText("Close"), "Failed to Click the Close Button", "Successfully clicked the Close Button");

			Report.StartSubStep($"I confirm I do not see 'No Valid UPCs' pop-up");
			element = new BaseModalDialog().WaitForContainerToBeInvisible(30);
			Report.IsTrue(element == true, "A modal pop was found", "A modal popup was not found");

			Report.StartSubStep($"I confirm the ItemSync Upload a File screen shows a File Upload Area");
			new Steps_ItemSync().ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea();




		}

		[RegexStepDefinition(@"I call Shared Step 125689 \(ItemSync - UPC Limit Exceeded pop-up\)")]
		public void Shared125689()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"I confirm I see the 'UPC Limit Exceeded' pop-up");
			var element = new BaseModalDialog().WaitForContainerToBeVisible(30);
			Report.IsTrue(element == true, "A modal popup was not found", "A modal pop was found");
			var title = new BaseModalDialog().TitleText;
			Report.IsTrue(title == "UPC Limit Exceeded", "The title was not 'UPC Limit Exceeded'", "The title was correctly 'UPC Limit Exceeded'");



			Report.StartSubStep($"I confirm the Pop-up text shows: The file you uploaded contains more than 1000 UPCs. Please remove UPCs from the file you submitted, or upload a new file.");
			var textBody = new BaseModalDialog().GetBodyText();
			Report.Info($"Found text: {textBody}");
			Report.IsTrue(new BaseModalDialog().BodyTextMatches("The file you uploaded contains more than 1000 UPCs. Please remove UPCs from the file you submitted, or upload a new file."), "Text did not match", "The body text was a match");



			Report.StartSubStep($"I confirm the Pop-up shows a Close button");
			Report.IsTrue(new BaseModalDialog().ButtonWithTextDisplayed("Close"), "A Close button was not found in the popup", "A Close button was found in the popup");

			Report.StartSubStep($"I click the Close Button");
			Report.IsTrue(new BaseModalDialog().ClickButtonByText("Close"), "Failed to Click the Close Button", "Successfully clicked the Close Button");

			Report.StartSubStep($"I confirm I do not see 'UPC Limit Exceeded' pop-up");
			element = new BaseModalDialog().WaitForContainerToBeInvisible(30);
			Report.IsTrue(element == true, "A modal pop was found", "A modal popup was not found");

			Report.StartSubStep($"I confirm the ItemSync Upload a File screen shows a File Upload Area");
			new Steps_ItemSync().ConfirmItemSyncUploadAFileScreenShowsAFileUploadArea();



		}



		[RegexStepDefinition(@"I call Shared Step 126165 \(RPS - ItemSync - Go to Manual Entry screen\)")]
		public void Shared126165()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"In the Retail Product Suite, In the Menu options banner, I click on: ItemSync ");
			new Steps_Navigation().ClickTab("ItemSync");
			Report.StartSubStep($"In the ItemSync menu options list, I select: Manual Entry");
			new Steps_Navigation().ClickSubTab("Manual Entry");
			Report.StartSubStep($"I confirm the screen refreshes and I see the ItemSync Manual Entry screen");
			new Steps_ItemSync().WaitFoItemSyncManualEntryScreenToLoad();


		}

		[RegexStepDefinition(@"I call Shared Step 125709 \(ItemSync - Manual Entry - Add UPC\)")]
		public void Shared125709()
		{
			Report.UseSubSteps = true;

			new Global_Steps().GivenIGenerateARandomUPCNumberAndSaveAs("currentRandomUPC");
			string upcNum = (string)Context.GetFromContext("currentRandomUPC");
			Report.StartSubStep($"In the ItemSync Manual Entry screen, In the text entry field, I enter a valid UPC");
			new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(upcNum);
			Report.StartSubStep($"In the ItemSync Manual Entry screen, I click the 'ADD' button");
			new Steps_ItemSync().InTheItemSyncManualEntryScreenIClickTheADDButton();

		}


		[RegexStepDefinition(@"I call Shared Step 125709 \(ItemSync - Manual Entry - Add UPC\) for UPC: (.*)")]
		public void Shared125709GivenUPC(string savedAs)
		{
			Report.UseSubSteps = true;

			string value = savedAs;

			if (value.ToLower().Contains("array"))
			{
				string[] stringArray = (string[])Context.GetFromContext(value);
				foreach (var item in stringArray)
				{
					new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(item);
					Report.StartSubStep($"In the ItemSync Manual Entry screen, I click the 'ADD' button");
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


			Report.StartSubStep($"In the ItemSync Manual Entry screen, In the text entry field, I enter a valid UPC");
			string upcNum = value;
			new Steps_ItemSync().InTheItemSyncManualEntryScreenIEnterTextIntoTheUPCEntryField(upcNum);
			Report.StartSubStep($"In the ItemSync Manual Entry screen, I click the 'ADD' button");
			new Steps_ItemSync().InTheItemSyncManualEntryScreenIClickTheADDButton();

		}

		[RegexStepDefinition(@"I call Shared Step 125737 \(ItemSync > Upload File to Results page\)")]
		public void Shared125737()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"In the Retail Product Suite, In the Menu options banner, I click on: ItemSync");
			new Steps_Navigation().ClickTab("ItemSync");
			Report.StartSubStep($"In the ItemSync menu options list, I select: Upload a File");
			new Steps_Navigation().ClickSubTab("Upload a File");
			Report.StartSubStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
			new Steps_ItemSync().WaitForUploadAFileScreenToLoad();

			//Report.StartSubStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
			//Report.Failure($"There is no way for us to drag and drop so we must use the file selector instead, need to check if this is suitable.");
			Report.StartSubStep($"In the ItemSync Upload a File screen, I click the File Upload area and open the File: 'TestMultipleUPCs.csv'");
			new Steps_ItemSync().UploadPDFFileSectionAndType("TestMultipleUPCs.csv");
			Report.StartSubStep($"In the Upload a File screen, I click the 'Upload' button");
			new Steps_ItemSync().InTheItemSyncUploadAFileScreenIClickTheUploadButton();
			Report.StartSubStep($"When the 'working' indicator is not longer shown, I confirm the page transitions to the Results page");
			new Steps_ItemSync().WaitFoItemSyncManualEntryScreenToLoad();
			new Steps_ItemSync().IConfirmTheItemSyncResultsPageShowsTheTitle();
			Report.IsTrue(new ItemSync().ConfirmUPCDetailsResultsTableShown(), "Failed to find the table", "The Results table was found");

		}

		[RegexStepDefinition(@"I call Shared Step 125737 \(ItemSync > Upload File to Results page\) for file: (.*)")]
		public void Shared125737FileX(string fileName)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"In the Retail Product Suite, In the Menu options banner, I click on: ItemSync");
			new Steps_Navigation().ClickTab("ItemSync");
			Report.StartSubStep($"In the ItemSync menu options list, I select: Upload a File");
			new Steps_Navigation().ClickSubTab("Upload a File");
			Report.StartSubStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
			new Steps_ItemSync().WaitForUploadAFileScreenToLoad();

			//Report.StartSubStep($"I drag and drop a file with multiple UPCs into the file upload area of the Upload a File screen.");
			//Report.Failure($"There is no way for us to drag and drop so we must use the file selector instead, need to check if this is suitable.");
			Report.StartSubStep($"In the ItemSync Upload a File screen, I click the File Upload area and open the File: '{fileName}'");
			new Steps_ItemSync().UploadPDFFileSectionAndType(fileName);
			Report.StartSubStep($"In the Upload a File screen, I click the 'Upload' button");
			new Steps_ItemSync().InTheItemSyncUploadAFileScreenIClickTheUploadButton();
			Report.StartSubStep($"When the 'working' indicator is not longer shown, I confirm the page transitions to the Results page");
			new Steps_ItemSync().WaitFoItemSyncManualEntryScreenToLoad();
			new Steps_ItemSync().IConfirmTheItemSyncResultsPageShowsTheTitle();
			Report.IsTrue(new ItemSync().ConfirmUPCDetailsResultsTableShown(), "Failed to find the table", "The Results table was found");

		}

		[RegexStepDefinition(@"I call Shared Step 146363 \(Status Webviewer - Page formatting\)")]
		public void GivenICallSharedStepStatusWebviewer_PageFormatting()
		{

			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheSearchBoxIsShown();
			new Steps_Navigation().GivenIConfirmStatuWebviewerPageIConfirmBackgroundColorIsGrey();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheSearchBoxTextReadsUPCProductNameSuppliesWPSID("UPC / Product Name / Supplier / WPSID");

			var table = new Table("Button");
			table.AddRow("More Filters");
			table.AddRow("Reset");

			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheToTheRightOfTheSearchBoxISeeTheFollowingButtons(table);

			table = new Table("Trend");
			table.AddRow("UPCs");
			table.AddRow("PRODUCTS");
			table.AddRow("SUPPLIERS");

			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmToTheRightOfTheButtonsISeeThreeTrends(table);
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmBelowTheFiltersAndTrendGraphicsISeeTheProductGrid();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheMainTableHeadingRowBackgroundColorIsGrey();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmDataRowsAreShown();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmBelowTheProductGridThePageFooterIsShown();

		}

		[RegexStepDefinition(@"I call Shared Step 146631 \(RPS - Go to Status Web Viewer\)")]
		public void GivenICallSharedStepRPS_GoToStatusWebViewer()
		{
			new Steps_Navigation().ClickTab("web viewers", "No");
			new Steps_Home().InTheWebViewersDropDownMenuISelect("Target_status");
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			Report.IsTrue(new Home().WaitForContainerToBeVisible(), "Web Viewers page content did not load", "Web Viewers page content loaded");
		}

		[RegexStepDefinition(@"I call Shared Step 153163 \(RPS - Go to Logistics/Store Web Viewer\): (.*)")]
		public void GivenICallSharedStepRPS_GoToLogisticsStoreWebViewer(string menu_link)
		{
			new Steps_Navigation().ClickTab("web viewers", "No");
			new Steps_Home().InTheWebViewersDropDownMenuISelect(menu_link);
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			new Home().WaitWidgetSpinnerFinish();
			//new Steps_Navigation().ConfirmActiveTab("web viewers");
			//Report.IsTrue(new Home().WaitForContainerToBeVisible(), "Web Viewers page content did not load", "Web Viewers page content loaded");
		}

		[RegexStepDefinition(@"I call Shared Step 153955 \(Logistics Webviewer - Page formatting\)")]
		public void GivenICallSharedStepLogisticsWebviewer_PageFormatting()
		{
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheSearchBoxIsShown();
			new Steps_Navigation().GivenIConfirmStatuWebviewerPageIConfirmBackgroundColorIsGrey();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheSearchBoxTextReadsUPCProductNameSuppliesWPSID("Product Name / UPC Number / Supplier Name / WPS ID");

			var table = new Table("Button");
			table.AddRow("More Filters");
			table.AddRow("Reset");

			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheToTheRightOfTheSearchBoxISeeTheFollowingButtons(table);

			table = new Table("Trend");
			table.AddRow("UPCs");
			table.AddRow("PRODUCTS");
			table.AddRow("SUPPLIERS");

			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmToTheRightOfTheButtonsISeeThreeTrends(table);
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmBelowTheFiltersAndTrendGraphicsISeeTheProductGrid();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmTheMainTableHeadingRowBackgroundColorIsGrey();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmDataRowsAreShown();
			new Steps_Navigation().GivenInTheStatusWebviewPageIConfirmBelowTheProductGridThePageFooterIsShown();
		}

		

        [RegexStepDefinition(@"I call Shared Step 151361 \(Product Lookup - Select Columns - Add new Column to pop up - Click Apply\) category: (.*), filter: (.*)")]
        public void ThenICallSharedStepProductLookup_SelectColumns_AddNewColumnToPopUp_ClickApply(string category, string filter)
        {
            Report.UseSubSteps = true;
            Report.StartSubStep("In the product lookup Page, In the Products table I click the Select Columns Button");
            new Steps_ProductLookUP().InTheProductLookupPageInProductsTableIClickSelectColumns();
            Report.StartSubStep("I confirm the Columns Selector pop up is shown");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmSelectorColumnPopupIsDisplayed(), "Failed to display  Column selector popup", "Successfully displayed Column selector popup");
            Report.StartSubStep("I confirm below the pop up header I see 3 panels: Applied Columns, Filter Categories, Filters");
            new Steps_ProductLookUP().InTheColumnSelectorPopUpIVerify3Panels();
            Report.StartSubStep("I confirm I see 1 or more entries show in the Applied Columns panel");
            new Steps_ProductLookUP().Confirm1OrMoreEntriesIsDisplayedInAppliedColumn(1);
            Report.StartSubStep("I select a category from the filter categories list ");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectCategoryFromFilterCategory(category), "Failed to select a filter", "Successfully selected the filter");

            Report.StartSubStep("I confirm the selected category is highlighted in blue");
            new Steps_ProductLookUP().ConfirmSelectedCategoryBackgroundColorIsBlue(category);
            Report.StartSubStep("I confirm in the Filters Panel a list of filters populate");
            new Steps_ProductLookUP().ConfirmListOfFiltersPopulate();

            Report.StartSubStep("I click on the filter that I want to apply and make a note of the selected filter");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectFilterFromFiltersPanel(filter), "Failed to select a filter from filter panel", "Successfully selected the filter from filter panel");

            Report.StartSubStep("I confirm each selected filter is highlighted in blue");
            new Steps_ProductLookUP().ConfirmSelectedFilterBackgroundColorIsBlue(filter);

            Report.StartSubStep("I confirm the reset to default button now shows in the pop up footer area to the left of close & apply buttons");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmResetToDefaultIsDisplayedInTheSelectorColumnPopup(), "Failed to display reset to default button", "Successfully displayed reset to default button");

            Report.StartSubStep("I click on the filter that I want to apply and make a note of the selected filter");
            new Steps_ProductLookUP().ThenIClickTheApplyButtonInTheSelectorColumnPopup();
        }




        [RegexStepDefinition(@"I call Shared Step 148760 \(Product Lookup - Select Columns - Add new Column to pop up - Do not click Apply\) category: (.*), filter: (.*)")]
		public void ThenICallSharedStepProductLookup_SelectColumns_AddNewColumnToPopUp_DoNotClickApply(string category, string filter)
		{
            Report.UseSubSteps = true;
            Report.StartSubStep("In the product lookup Page, In the Products table I click the Select Columns Button");
            new Steps_ProductLookUP().InTheProductLookupPageInProductsTableIClickSelectColumns();
            Report.StartSubStep("I confirm the Columns Selector pop up is shown");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmSelectorColumnPopupIsDisplayed(), "Failed to display  Column selector popup", "Successfully displayed Column selector popup");
            Report.StartSubStep("I confirm below the pop up header I see 3 panels: Applied Columns, Filter Categories, Filters");
            new Steps_ProductLookUP().InTheColumnSelectorPopUpIVerify3Panels();
            Report.StartSubStep("I confirm I see 1 or more entries show in the Applied Columns panel");
            new Steps_ProductLookUP().Confirm1OrMoreEntriesIsDisplayedInAppliedColumn(1);
            Report.StartSubStep("I select a category from the filter categories list ");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectCategoryFromFilterCategory(category), "Failed to select a filter", "Successfully selected the filter");

            Report.StartSubStep("I confirm the selected category is highlighted in blue");
            new Steps_ProductLookUP().ConfirmSelectedCategoryBackgroundColorIsBlue(category);
            Report.StartSubStep("I confirm in the Filters Panel a list of filters populate");
            new Steps_ProductLookUP().ConfirmListOfFiltersPopulate();

            Report.StartSubStep("I click on the filter that I want to apply and make a note of the selected filter");
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectFilterFromFiltersPanel(filter), "Failed to select a filter from filter panel", "Successfully selected the filter from filter panel");

            Report.StartSubStep("I confirm each selected filter is highlighted in blue");
            new Steps_ProductLookUP().ConfirmSelectedFilterBackgroundColorIsBlue(filter);

            Report.StartSubStep("I confirm a new filter was added to the applied columns panel");
            new Steps_ProductLookUP().ConfirmFilterAddedIsDisplayedToAppliedColumnsPanel(filter);


        }

		
        [RegexStepDefinition(@"I call Shared Step 148793 \(RPS/WV any page - check for showAllStatuses : (true|false)\)")]
		public void GivenICallSharedStepRPSWVCheckShowAllStatuses(string true_false)
		{
			bool expected = true_false == "true";
			var driver = SeleniumWebDriver.CurrentDriver;
			new Steps_SuperTable().InTableHeaderClickButtonAndSaveAs("Reset", "dtNow");
			DateTime dtNow = (DateTime)Context.GetFromContext("dtNow");
			Report.IsTrue(GeneralUtilities.NetworkRequestAtTimeConfirmAttributeValue("POST", dtNow, "showAllStatuses", true_false), $"Failure, showAllStatus:{(expected ? "false" : "true")}.", $"Success, showAllStatuses:{true_false}.");
		}




		[RegexStepDefinition(@"I call Shared Step 154003 \(RPS & WV - Warning message when > 100,000 records\)")]
		public void ThenICallSharedStepWarningMessage_WhenMoreThan_100000Records()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the Page footer area I confirm Rows per page selector displays");
			new Steps_RecentActivities().InProductsTableFooterIConfirmRowsPerPageSelectorDisplays("10");
			Report.StartStep("I confirm the last page icon in the footer area");
			new Steps_RecentActivities().IConfirmLastPageIconIsDisplayedInFooterArea();
			Report.StartStep("In the page footer, I change the page number");
			new Steps_RecentActivities().InProductsTableFooterIChangePageNumber("10000");
			Report.StartStep("I confirm the 10000th page of products is shown");
			Delay.Seconds(20);
			new Steps_RecentActivities().InProductsTableFooterIConfirmPageNumber("10000");
			Report.StartStep("I click the next page icon in page footer");
			new Steps_RecentActivities().InProductsTableFooterClickNextPageButton();

			Report.StartStep("I confirm the Too Many Pages pop up is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopupIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up, I confirm the heading reads Too Many Pages");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpHeadingIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up, at the far right of the pop up heading area, I confirm I see the X icon");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagePopUpXIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up in the heading area, I click the X icon");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagePopUpIClickXButton();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();

			Report.StartStep("I click the next page icon in page footer");
			new Steps_RecentActivities().InProductsTableFooterClickNextPageButton();

			Report.StartStep("In the Too Many Pages pop up, below the pop up heading I confirm I see the message");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpMessageIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up, I confirm I see the pop up footer area");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpISeeFooterArea();
			Report.StartStep("In the Too Many Pages pop up footer area, I confirm I see two buttons:Show Filters, Close");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpButtonsAreDisplayed();

			Report.StartStep("In the Too Many Rows pop up footer area, I click in the Close button");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIClickCloseButton();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();
			Report.StartStep("In the Products table footer I click on the last page icon");
			new Steps_RecentActivities().InProductsTableFooterAndClickLastPageButton();

			Report.StartStep("I confirm the Too Many Pages pop up is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopupIsDisplayed();
			Report.StartStep("In the Too Many Rows pop up footer area, I click Show Filters");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIClickShowFilters();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();

			Report.StartStep("I confirm the More Filters pop up is shown");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I click: Close");
			new Steps_MoreFilters().GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();
			Report.StartStep("I confirm the More Filters pop up closes");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();

			Report.StartStep("In the page footer page navigation area, I type a number which will take me to a page past the 100,000 limit");
			new Steps_RecentActivities().InProductsTableFooterIChangePageNumber("10008");
			Delay.Seconds(20);
			Report.StartStep("I confirm the Too Many Pages pop up is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopupIsDisplayed();
			Report.StartStep("In the Too Many Rows pop up footer area, I click in the Close button");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIClickCloseButton();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();

		}

		[RegexStepDefinition(@"I call Shared Step 154005 \(RPS & WV > Warning re 100,000 and More Filters applied\)")]
		public void ThenICallSharedStepWarningMessage_WhenMoreThan_100000Records_AndMoreFiltersApplied()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("I click on the More Filters button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
			Report.StartStep("The More Filters Popup is showing");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I select the Recommended Use from the drop down list");
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectStatusOption("Recommended Use");
			Report.StartStep("In the More Filters pop up, I select Has any value paramater value");
			Delay.Seconds(10);
			new Steps_MoreFilters().InTheRecentActivitiesPageMoreFiltersPopUpISelectHasAnyValueParameter();
			Report.StartStep("In the More Filters pop up, I click: Apply Filter");
			new Steps_MoreFilters().InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
			Delay.Seconds(10);
			Report.StartStep("The More Filters Popup is not showing");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();

			Report.StartStep("In the Page footer area I confirm Rows per page selector displays");
			new Steps_RecentActivities().InProductsTableFooterIConfirmRowsPerPageSelectorDisplays("10");
			Report.StartStep("I confirm the last page icon in the footer area");
			new Steps_RecentActivities().IConfirmLastPageIconIsDisplayedInFooterArea();
			Report.StartStep("In the page footer, I change the page number");
			new Steps_RecentActivities().InProductsTableFooterIChangePageNumber("10000");
			Report.StartStep("I confirm the 10000th page of products is shown");
			Delay.Seconds(20);
			new Steps_RecentActivities().InProductsTableFooterIConfirmPageNumber("10000");
			Report.StartStep("I click the next page icon in page footer");
			new Steps_RecentActivities().InProductsTableFooterClickNextPageButton();

			Report.StartStep("I confirm the Too Many Pages pop up is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopupIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up, I confirm the heading reads Too Many Pages");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpHeadingIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up, at the far right of the pop up heading area, I confirm I see the X icon");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagePopUpXIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up in the heading area, I click the X icon");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagePopUpIClickXButton();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();

			Report.StartStep("I click the next page icon in page footer");
			new Steps_RecentActivities().InProductsTableFooterClickNextPageButton();

			Report.StartStep("In the Too Many Pages pop up, below the pop up heading I confirm I see the message");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpMessageIsDisplayed();
			Report.StartStep("In the Too Many Pages pop up, I confirm I see the pop up footer area");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpISeeFooterArea();
			Report.StartStep("In the Too Many Pages pop up footer area, I confirm I see two buttons:Show Filters, Close");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpButtonsAreDisplayed();

			Report.StartStep("In the Too Many Rows pop up footer area, I click in the Close button");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIClickCloseButton();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();
			Report.StartStep("In the Products table footer I click on the last page icon");
			new Steps_RecentActivities().InProductsTableFooterAndClickLastPageButton();
			Report.StartStep("I confirm the Too Many Pages pop up is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopupIsDisplayed();
			Report.StartStep("In the Too Many Rows pop up footer area, I click Show Filters");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIClickShowFilters();
			Report.StartStep("I confirm the Too Many Pages pop up closes");
			new Steps_RecentActivities().InTheRecentActivitiesPageTooManyPagesPopUpIsClosed();
			Report.StartStep("I confirm the More Filters pop up is shown");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters popup I see the Selected Filters area");
			new Steps_MoreFilters().GivenInTheMoreFiltersPopupIDoNotSeeTheSelectedFiltersArea("see");
			Report.StartStep("In the More Filters pop up, I click: Close");
			new Steps_MoreFilters().GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();
			Report.StartStep("I confirm the More Filters pop up closes");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
			Report.StartStep("In the Products table the total number of pages is correct");
			new Steps_RecentActivities().InTheRecentActivitiesPageInProductsTableTotalNoPagesCorrect();
		}


		[RegexStepDefinition(@"I call Shared Step 153272 \(RPS & WV > Find UPC prefix > Search > Confirm\)")]
		public void ThenICallSharedStep_FindUpcPrefix_Search()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the page footer, I change the page number other than 1");
			new Steps_RecentActivities().InProductsTableFooterIChangePageNumber("4");
			Delay.Seconds(10);
			Report.StartStep("Select first 4 digits of UPC  shown on the page and save as: savedAs ");
			new Steps_ProductLookUP().SelectFirstFourDigitsOfUPCAndSaveTheNumber("savedAs");

			Report.StartStep("In the page navigation area, click the First page icon");
			new Steps_RecentActivities().InProductsTableFooterClickFirstPageButton();
			Delay.Seconds(10);
			Report.StartStep("I Enter first 4 digits of UPC Number : savedAs in Search field ");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProductByPartialUPCNumber("savedAs");

			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the UPC Number I saved: savedAs is shown in Product Table");
			new Steps_ProductLookUP().InTheProductLookUpSearchTheProductByUPCNumberOrWPSOrSupplierName("savedAs");

		}

		[RegexStepDefinition(@"I call Shared Step 153276 \(RPS & WV > Search field > UPC ignores leading zeroes\)")]
		public void ThenICallSharedStep_FindUpcIgnoresLeading_Zeroes_Search()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;


			Report.StartStep("I Enter UPC : (.*) in Search field");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProduct("8121");
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the UPC Number I saved: savedAs is shown in Product Table");
			new Steps_ProductLookUP().InTheProductLookUpSearchTheProductByUPCNumberOrWPSOrSupplierName("savedAs");

		}

		[RegexStepDefinition(@"I call Shared Step 153277 \(RPS & WV > Search field > Enter key or wait return results\)")]
		public void ThenICallSharedStep_SearchField_EnterKey_Or_WaitForReturnResults()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the search field enter a product ID, product name or UPC and click Enter button");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProductAndClickEnter("1625737");
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the product I searched for is shown with the ID");
			new Steps_ProductLookUP().CheckProductsGridDisplaysProductWithID("1625737");
			Report.StartStep("I click Reset button");
			new Steps_ProductLookUP().InProductsTableIClickReset();
			Report.StartStep("In the search field enter a product ID, product name or UPC - I do not hit my enter key but just wait");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProduct("1625737");
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the product I searched for is shown with the ID");
			new Steps_ProductLookUP().CheckProductsGridDisplaysProductWithID("1625737");

		}

		[RegexStepDefinition(@"I call Shared Step 149247 \(Canadian Tire - Product Information pop up - Expand Transportation Data - Confirm rows\)")]
		public void SharedStep149247()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Transportation heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation heading was not showing", "The additional area is shown below the Transportation heading was showing");
			List<string> expectedHeadings = new List<string> { "ERG Code", "Hazard Class", "HAZARD CLASS IMDG INTERNATIONAL VESSEL(BASIC RETAILER)", "HAZARD CLASS INTERNATIONAL AIR CARGO(BASIC RETAILER)", "HAZARD CLASS INTERNATIONAL AIR PASSENGER(BASIC RETAILER)", "IATA Air Cargo Proper Shipping Description(BASIC RETAILER)", "IATA Air Cargo Proper Shipping Name w/TN(BASIC RETAILER)", "IATA Air Cargo Proper Shipping Name w/TN(base classification)(BASIC RETAILER)", "IATA Air Passenger Proper Shipping Description(BASIC RETAILER)", "IATA Air Passenger Proper Shipping Name w/TN(BASIC RETAILER)", "IATA Air Passenger Proper Shipping Name w/TN(base classification) (BASIC RETAILER", "IATA Cargo UN Code(BASIC RETAILER)", "Packing Group", "IATA Passenger UN Code(BASIC RETAILER)", "Subsidiary class", "Transport hazard class(es)", "IMDG International Vessel UN Code(BASIC RETAILER)", "Packing Group", "IMDG SPECIAL PROVISIONS", "Subsidiary class", "IMDG Technical Name", "IMDG Vessel Proper Shipping Description(BASIC RETAILER)", "IMDG Vessel Proper Shipping Name w/TN(BASIC RETAILER)", "IMDG Vessel Proper Shipping Name w/TN(base classification)(BASIC RETAILER)", "International Cargo Aircraft(Y/N)", "International Passenger Aircraft(Y/N)", "Limited quantity", "Packing Group", "Proper Shipping Name", "Proper Shipping Name", "Pseudoephedrine Restriction", "Subsidiary class", "TDG", "TDG ERAP Index", "TDG Marine Pollutant", "TDG Special Provisions", "TDG Technical Name", "UN-No.", "WHMIS Hazard Class" };
			Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().TransporationDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.StartStep("I confirm the additional area below the Transportation heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation Data heading was showing", "The additional area is shown below the Transportation Data heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 149197 \(Canadian Tire - Product Information pop up - Expand Waste - Confirm rows\)")]
		public void SharedStep149197()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I click the Waste Data heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Waste Data"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Waste Data"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Waste heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Waste Data"), "The additional area is shown below the Waste heading was not showing", "The additional area is shown below the Waste heading was showing");
			List<string> expectedHeadings = new List<string> { "CEPA Hazardous waste", "CEPA Schedule I - List of Toxic Substances" };
			Report.IsTrue(new ProductInformation().WasteDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Waste data heading");
			Report.StartStep("I confirm the additional area below the Waste data heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Waste Data"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Waste Data"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Waste Data"), "The additional area is shown below the Waste Data heading was showing", "The additional area is shown below the Waste Data heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 149119 \(Canadian Tire - Product Information pop up - Expand Regulatory Data - Confirm rows\)")]
		public void SharedStep149119()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I click the Regulatory Data heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Regulatory Data"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Regulatory Data"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Regulatory Data heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Regulatory Data"), "The additional area is shown below the Regulatory Data heading was not showing", "The additional area is shown below the Regulatory Data heading was showing");
			List<string> expectedHeadings = new List<string> { "Canada Export/Import Persistent Organic Pollutant Code", "Canada Vendor Responsible for Blue Box Fees", "Canadian 2 - Butoxyethanol Regulation", "Canadian Consumer Products Containing Lead(Contact with Mouth) Regulations","Canadian Export Control List", "Canadian Halocarbon Regulation","DSL Portal Question - Vendor Answered", "Canadian National Pollutant Release Inventory(NPRI) - 2017", "Canadian PCP Number", "Canadian Phosphorus", "Canadian Phthalates Regulation", "Canadian Priority Substance List", "Canadian Products Containing Mercury Regulations","Canadian Prohibition of Certain Toxic Substances",
															   "Canadian Significant New Activity(SNAc)", "Canadian Surface Coating Code of Practice for 2 - Butanone, oxime(Butanone oxime)","Canadian Surface Coating Regulation","Canadian Surface Coating Regulation",
															   "Canadian Surface Coating Regulation", "Canadian Surface Coating Regulation", "Canadian Surface Coating Regulation","Canadian Surface Coating Regulation" };
			Report.IsTrue(new ProductInformation().RegulatoryDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Regulatory Data heading");
			Report.StartStep("I confirm the additional area below the Regulatory Data heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Regulatory Data"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Regulatory Data"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Regulatory Data"), "The additional area is shown below the Regulatory Data heading was showing", "The additional area is shown below the Regulatory Data heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 149021 \(Canadian Tire - Product Information pop up - Expand Product Data - Confirm rows\)")]
		public void SharedStep149021()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Product Details heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Details heading was not showing", "The additional area is shown below the Product Details heading was showing");
			List<string> expectedHeadings = new List<string> { "Is this an aerosol?", "Boiling point / boiling range °C", "Canada SDS revision date", "Canadian Tire Storage Code", "Does Product Contain More than 100mg/kg environmentally hazardous substances?", "Flash point °C", "Flash point °C", " Model Year", "Is this a Safety Can? A safety can is no larger than 5 gallons, and contains a flash-arresting screen, spring closed lid and a pressure relieving spout cover?" };
			Report.IsTrue(new ProductInformation().ProductDataCodesHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.StartStep("I confirm the additional area below the Product Details heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Details heading was showing", "The additional area is shown below the Product Details heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 149027 \(Canadian Tire - Product Information pop up - Expand Battery data codes - Confirm rows\)")]
		public void SharedStep149027()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery Data"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery Data"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Battery heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery Data"), "The additional area is shown below the Battery heading was not showing", "The additional area is shown below the Battery heading was showing");
			List<string> expectedHeadings = new List<string> { "Does the product contain a battery or is it shipped with a battery?", "Battery Types", "Battery, Cell, Button Cell Lithium Battery", "How Battery Resides in Product", "Watt hours for Li Batteries", "Quantity(grams) of Lithium present in battery", "Product Itself is a Battery", "Number of Batteries", "UN38.3 Tested ?", "Weight of battery" };
			Report.IsTrue(new ProductInformation().BatteryHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.StartStep("I confirm the additional area below the Battery heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery Data"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery Data"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Battery Data"), "The additional area is shown below the Battery heading was showing", "The additional area is shown below the Battery heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 149077 \(Canadian Tire - Product Information pop up - Expand Pesticide - Confirm rows\)")]
		public void SharedStep149077()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I click the Pesticide heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Pesticide"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Pesticide"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Pesticide heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Pesticide"), "The additional area is shown below the Pesticide heading was not showing", "The additional area is shown below the Pesticide heading was showing");
			List<string> expectedHeadings = new List<string> { "Alberta Pesticide Schedule Number", "British  Columbia Stewardship Expiration Date", "British Columbia Pesticide Class", "British Columbia Stewardship Issue Date", "British Columbia Stewardship Number", "Canadian Pesticide Danger Poison Label", "Laborador Pesticide Terms", "Manitoba Pesticide Class", "Manitoba Stewardship Expiration Date", "Manitoba Stewardship Issue Date", "Manitoba Stewardship Number", "New Brunswick Pesticide Act", "Newfoundland and Labrador Pesticide Act", "Nova Scotia Pesticide Act", "Ontario Pesticide Class", "Ontario Stewardship Expiration Date", "Ontario Stewardship Issue Date", "Ontario Stewardship Number", "Prince Edward Island Pesticide Act", "Quebec Pesticide Class", "Quebec Stewardship Expiration Date", "Quebec Stewardship Issue Date", "Quebec Stewardship Number", "Saskatchewan Stewardship Expiration Date", "Saskatchewan Stewardship Issue Date", "Saskatchewan Stewardship Number", "Saskatchewan Stewardship Number" };
			Report.IsTrue(new ProductInformation().PesticideHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Pesticide heading");
			Report.StartStep("I confirm the additional area below the Pesticide heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Pesticide"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Pesticide"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Pesticide"), "The additional area is shown below the Pesticide heading was showing", "The additional area is shown below the Pesticide heading was not showing");

		}
		[RegexStepDefinition(@"I call Shared Step 110820 \(View Data - Product Information pop up - Expand Transportation Data \(Longer version\) - confirm rows\)")]
		public void SharedStep110820()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Transportation heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation heading was not showing", "The additional area is shown below the Transportation heading was showing");
			List<string> expectedHeadings = new List<string> { "Emergency Response Guide Number", "Hazard Class", "UN-No.", "Packing Group", "DOT Vessel Limited Quantity w/units (BASIC RETAILER)", "DOT Marine Pollutant?", "Marine pollutant <5L/5KG", "Miscible in Water?", "Need Info?", "DOT Ground Proper Shipping Name w/TN", "Proper Shipping Name", "Limited Quantity Flag - Ground", "Fully Regulated DOT", "Limited Quantity Flag - Air", "Limited Quantity Flag - Vessel" };
			Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().TransporationDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.StartStep("I confirm the additional area below the Transportation heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation Data heading was showing", "The additional area is shown below the Transportation Data heading was not showing");
		}

		[RegexStepDefinition(@"I call Shared Step 163151 \(Product Information pop up - New version - Battery Data - confirm rows\)")]
		public void SharedStep163151()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Battery heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was not showing", "The additional area is shown below the Battery heading was showing");
			List<string> expectedHeadings = new List<string> { "Does the product contain a battery or is it shipped with a battery?", "Product Itself is a Battery", "How Battery Resides in Product", "Watt hours for Li Batteries", "Weight of battery", "Quantity(grams) of Lithium present in battery", "Number of Batteries", "UN38.3 tested ?", "IATA quality management system", "Number of batteries / cells used to run equipment " };
			Report.IsTrue(new ProductInformation().BatteryHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.StartStep("I confirm the additional area below the Battery heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was showing", "The additional area is shown below the Battery heading was not showing");
		}

		[RegexStepDefinition(@"I call Shared Step 152620 \(View Data - Product Information pop up - Product Details - Confirm rows\)")]
		public void SharedStep152620()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Product Details heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Details heading was not showing", "The additional area is shown below the Product Details heading was showing");
			List<string> expectedHeadings = new List<string> { "Supplier Contact Name", "US EPA Waste Number", "Flash point °C", "Flash point (°C) DEGREES" };
			Report.IsTrue(new ProductInformation().ProductDataCodesHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.StartStep("I confirm the additional area below the Product Details heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Details heading was showing", "The additional area is shown below the Product Details heading was not showing");
		}

		[RegexStepDefinition(@"I call Shared Step 163160 \(Product Information pop up - New Version - Disposal - Confirm rows\)")]
		public void SharedStep163130()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the Product Information pop up, I click the Disposal heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Disposal"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Disposal"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Disposal heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Disposal"), "The additional area is shown below the Disposal heading was not showing", "The additional area is shown below the Disposal heading was showing");
			List<string> expectedHeadings = new List<string> {"US EPA Waste Number","Alaska Waste Codes","Alabama Waste Codes","Arkansas Waste Codes","Arizona Waste Codes","California Waste Codes",
				"Colorado Waste Codes","Connecticut Waste Codes","Delaware Waste Codes","Florida Waste Codes","Georgia Waste Codes","Hawaii Waste Codes","Iowa Waste Codes","Idaho Waste Codes","Illinois Waste Codes","Indiana Waste Codes",
				"Kansas Waste Codes","Kentucky Waste Codes", "Louisiana Waste Codes","Massachusetts Waste Codes","Maryland Waste Codes","Maine  Waste Codes","Michigan Waste Codes","Minnesota Waste Codes","Missouri Waste Codes",
				"Mississippi Waste Codes","Montana Waste Codes","North Carolina Waste Codes","North Dakota Waste Codes","Nebraska Waste Codes","New Hampshire Waste Codes","New Jersey Waste Codes","New Mexico Waste Codes",
				"Nevada Waste Codes","New York Waste Codes","Ohio Waste Codes","Oklahoma Waste Codes","Oregon Waste Codes","Pennsylvania Waste Codes","Rhode Island Waste Codes","South Carolina Waste Codes","South Dakota Waste Codes","Tennessee Waste Codes",
				"Texas Waste Codes","Utah Waste Codes","Virginia Waste Codes","Vermont Waste Codes","Washington State Waste Codes","Wisconsin Waste Codes","West Virginia Waste Codes","Wyoming Waste Codes"};
			Report.IsTrue(new ProductInformation().DisposalHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Disposal heading");
			Report.StartStep("I confirm the additional area below the Disposal heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Disposal"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Disposal"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Disposal"), "The additional area is shown below the Disposal heading was showing", "The additional area is shown below the Disposal heading was not showing");
		}

		[RegexStepDefinition(@"I call Shared Step 163153 \(Product Information pop up - New version - Storage Data - Confirm rows\)")]
		public void SharedStep163153()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the Product Information pop up, I click the Storage Data heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage Data"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage Data"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Storage Data heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage Data"), "The additional area is shown below the Storage Data heading was not showing", "The additional area is shown below the Storage heading was showing");
			List<string> expectedHeadings = new List<string> { "Uniform Fire Code", "International Fire Code", "Health Hazards", "Flammability", "Stability", "Physical and Chemical Hazards" };
			Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().StorageHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Storage Data heading");
			Report.StartStep("I confirm the additional area below the Storage Data heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage Data"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage Data"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Storage Data"), "The additional area is shown below the Storage Data heading was showing", "The additional area is shown below the Storage Data heading was not showing");

		}

		[RegexStepDefinition(@"I call Shared Step 153375 \(RPS > Actions > View Data > Collapse All\)")]
		public void SharedStep153375()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the product table, I select a product to work with");
			Report.StartStep("In the product table, in the Actions column, I click: View Data");
			Report.IsTrue(new ProductLookUp().ClickActionForFirstResultInGrid("View Data"), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
			Report.StartStep("I confirm the Product Information pop up is shown");
			Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible(), "The product Information popup did not load", "The Product Information popup was loaded");
			Report.IsTrue(new ProductInformation().ProductInformationPopUpIsDisplayed(), "Product Information pop up is not displayed", "Successfully Product Information pop up is displayed");
			Report.StartStep("I confirm the data sections shown are all expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I click the button: Collapse All");
			Report.IsTrue(new ProductInformation().ClickCollapseAll(), "Failed to Click the Collpase All", "Successfully clicked the Collapse ALl");
			Report.StartStep("I confirm all data areas are collapsed");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.StartStep("I confirm I see the sections headings only");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.StartStep("I click the button: Collapse All");
			Report.IsTrue(new ProductInformation().ClickCollapseAll(), "Failed to Click the Collpase All", "Successfully clicked the Collapse ALl");
			Report.StartStep("I confirm the data areas remain collapsed");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.StartStep("I Close the Product Information Popup");
			Report.IsTrue(new ProductInformation().ClickCloseButton(), "Failed to click the close button", "Successfully clicked the close button");


		}

		[RegexStepDefinition(@"I call Shared Step 151306 \(View Data - Product Information pop up - Product Data Codes > Collapse and Expand\)")]
		public void SharedStep151306()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I confirm the Product Details area is shown as expanded by default");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.StartStep("I confirm that the data area is no longer shown below the Product Details  heading");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Details heading was showing", "The additional area is shown below the Product Details heading was not showing");
			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Product Details heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Details heading was not showing", "The additional area is shown below the Product Details heading was showing");


		}

		[RegexStepDefinition(@"I call Shared Step 152628 \(View Data - Product Information pop up - Transportation Data > Collapse and Expand\)")]
		public void SharedStep152628()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the Product Information pop up, I confirm the Transportation data area is shown as collapsed by default");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Transportation heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation heading was not showing", "The additional area is shown below the Transportation heading was showing");
			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.StartStep("I confirm that the data area is no longer shown below the Transportation  heading");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation heading was showing", "The additional area is shown below the Transportation heading was not showing");
			Report.StartStep("In the Product Information pop up, I click the Transportation heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Transportation"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Transportation heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Transportation"), "The additional area is shown below the Transportation heading was not showing", "The additional area is shown below the Transportation heading was showing");

		}


		[RegexStepDefinition(@"I call Shared Step 152629 \(View Data - Product Information pop up - Storage Data > Collapse and Expand\)")]
		public void SharedStep152629()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I confirm the Storage data area is shown as collapsed by default");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was expanded", "The section was not expanded");
			Report.StartStep("In the Product Information pop up, I click the Storage heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Storage heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage"), "The additional area is shown below the Storage heading was not showing", "The additional area is shown below the Storage heading was showing");
			Report.StartStep("In the Product Information pop up, I click the Storage heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.StartStep("I confirm that the data area is no longer shown below the Storage  heading");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Storage"), "The additional area is shown below the Storage heading was showing", "The additional area is shown below the Storage heading was not showing");
			Report.StartStep("In the Product Information pop up, I click the Storage heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Storage"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Storage heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Storage"), "The additional area is shown below the Storage heading was not showing", "The additional area is shown below the Storage heading was showing");


		}


		[RegexStepDefinition(@"I call Shared Step 152630 \(View Data - Product Information pop up - Battery Data > Collapse and Expand\)")]
		public void SharedStep152630()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I confirm the Battery data area is shown as collapsed by default");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Battery heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was not showing", "The additional area is shown below the Battery heading was showing");
			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.StartStep("I confirm that the data area is no longer shown below the Battery  heading");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was showing", "The additional area is shown below the Battery heading was not showing");
			Report.StartStep("In the Product Information pop up, I click the Battery heading");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Battery"), "Failed to Click the section", "Successfully clicked the section");
			Delay.Seconds(1);
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Battery heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Battery"), "The additional area is shown below the Battery heading was not showing", "The additional area is shown below the Battery heading was showing");


		}

		[RegexStepDefinition(@"I call Shared Step 211934 \(Product Information - For Retailer Uploaded\) for TReVor account: (.*)")]
		public void SharedStep211934(string retailer)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.StartStep("In the Product Information pop up, I confirm heading text reads: Product Information");
			Report.IsTrue(new ProductInformation().HeadingTextMatches("Product Information"), "Heading text is not displayed as expected", "Successfully displayed heading text: Product Information");
			Report.StartStep("In the Product Information pop up heading area,  I confirm the x (close icon) is shown");
			Report.IsTrue(new ProductInformation().CrossCloseIconExists(), "Failed to display x (close icon) button", "Successfully x (close icon) button is displayed");
			Report.StartStep("In the Product Information pop up - main body area, I confirm product details are shown as follows:");
			List<string> mainBodyHeaders = new List<string> { "Product :", "Supplier :", "Supplier Contact :" };
			Report.IsTrue(new ProductInformation().ProductTopDataHeadingsPresent(mainBodyHeaders), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("Below the product details area, I confirm I see two buttons: Collapse All, Expand All");
			Report.IsTrue(new ProductInformation().CollapseAllButtonExists(), "Failed to display Collapse All button", "Successfully Collapse All button is displayed");
			Report.IsTrue(new ProductInformation().ExpandAllButtonExists(), "Failed to display Expand All button", "Successfully Expand All button is displayed");
			Report.StartStep("I click the button: Collapse All");
			Report.IsTrue(new ProductInformation().ClickCollapseAll(), "Failed to Click the Collpase All", "Successfully clicked the Collapse ALl");
			Report.StartStep("Below the product details, I confirm I see 4 headings:");
			List<string> sectionHeadings = new List<string> { "Product Details", "Battery", "Pesticide", "Regulatory Data", "Waste Data", "Transportation" };
			Report.IsTrue(new ProductInformation().ProductInformatinSectionsPresent(sectionHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("I click the button: Expand All");
			Report.IsTrue(new ProductInformation().ClickCollapseAll(), "Failed to Click the Expand All", "Successfully clicked the Expand ALl");
			Report.StartStep("I confirm each heading shows a data area below it");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Pesticide"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Regulatory Data"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Waste Data"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.StartStep("In the Product Information pop up footer area, I confirm I see 1 button: Close");
			Report.IsTrue(new ProductInformation().CloseButtonExists(), "Failed to display close button", "Successfully close button is displayed");
		}




		[RegexStepDefinition(@"I call Shared Step 153315 \(RPS & WV > Search text only cleared on Reset\)")]
		public void ThenICallSharedStep_SearchText_Only_ClearedonReset()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("I Enter product ID  in Search field");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProduct("1625737");
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the product I searched for is shown");
			new Steps_ProductLookUP().CheckProductsGridDisplaysProductWithID("1625737");
			Report.StartStep("I confirm the text I entered into the search field is still shown");
			new Steps_ProductLookUP().InTheProductLookUpSearchFieldTextIEnteredIsStillShown("1625737");

			Report.StartStep("In the recent activities page, I click on the More Filters button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
			Report.StartStep("In the recent activities page, The More Filters Popup is showing");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I select the status I am working with");
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectStatusOption("Status");
			Report.StartStep("In the More Filters pop up, I select the parameter I am working with");
			Delay.Seconds(10);
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectParameterOption("Completed");
			Report.StartStep("In the More Filters pop up, I click: Close");
			new Steps_MoreFilters().GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();
			Report.StartStep("I confirm the More Filters pop up closes");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
			Report.StartStep("I confirm the text I entered into the search field is still shown");
			new Steps_ProductLookUP().InTheProductLookUpSearchFieldTextIEnteredIsStillShown("1625737");

			Report.StartStep("In the recent activities page, I click on the More Filters button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
			Report.StartStep("In the recent activities page, The More Filters Popup is showing");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I select the status I am working with");
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectStatusOption("Status");
			Report.StartStep("In the More Filters pop up, I select the parameter I am working with");
			Delay.Seconds(10);
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectParameterOption("Completed");
			Report.StartStep("In the More Filters pop up, I click: Remove all filters");
			new Steps_MoreFilters().GivenInTheMoreFiltersPopupClickResetAllFilters();
			Report.StartStep("In the More Filters pop up, I click: Close");
			new Steps_MoreFilters().GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();
			Report.StartStep("I confirm the More Filters pop up closes");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
			Report.StartStep("I confirm the text I entered into the search field is still shown");
			new Steps_ProductLookUP().InTheProductLookUpSearchFieldTextIEnteredIsStillShown("1625737");

			Report.StartStep("In the recent activities page, I click on the More Filters button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
			Report.StartStep("In the recent activities page, The More Filters Popup is showing");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I select the status I am working with");
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectStatusOption("Status");
			Report.StartStep("In the More Filters pop up, I select the parameter I am working with");
			Delay.Seconds(10);
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectParameterOption("Completed");
			Report.StartStep($"In the Recent Activities page, In the More Filters popup I click the Apply Filters button");
			new Steps_MoreFilters().InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
			Report.StartStep("I confirm the More Filters pop up closes");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
			Report.StartStep("I confirm the text I entered into the search field is still shown");
			new Steps_ProductLookUP().InTheProductLookUpSearchFieldTextIEnteredIsStillShown("1625737");
			Report.StartStep("I click Reset button");
			new Steps_ProductLookUP().InProductsTableIClickReset();
			Delay.Seconds(10);
			Report.StartStep("I confirm the text I entered into the search field is not shown");
			new Steps_ProductLookUP().InTheProductLookUpSearchFieldTextIEnteredIsStillShown("");

		}

		[RegexStepDefinition(@"I call Shared Step 153316 \(RPS & WV - Search text is taken into consideration by More Filters\)")]
		public void ThenICallSharedStep_SearchText_IntoConsideration_ByMoreFilters()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the search field I enter a partial Product name into the search field");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProductAndClickEnter("For WVs");
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the product(s) shown contain the name I entered above");
			new Steps_ProductLookUP().CheckProductsGridDisplaysProductISearched("For WVs");
			Report.StartStep("I take note of the number of products in the footer area and save as: savedAs");
			new Steps_RecentActivities().ThenInTheRecentActivitiesPageITakeNoteOfTheNumberOfProductsInTheFooterAreaAndSaveAsProductAmount("savedAs");
			Report.StartStep("In the recent activities page, I click on the More Filters button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
			Report.StartStep("In the recent activities page, The More Filters Popup is showing");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartStep("In the More Filters pop up, I select the status I am working with");
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectStatusOption("Status");
			Report.StartStep("In the More Filters pop up, I select the parameter I am working with");
			Delay.Seconds(10);
			new Steps_MoreFilters().InTheRecentActivitiesPageISelectParameterOption("Completed");
			Report.StartStep($"In the Recent Activities page, In the More Filters popup I click the Apply Filters button");
			new Steps_MoreFilters().InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
			Report.StartStep("I confirm the More Filters pop up closes");
			new Steps_MoreFilters().InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
			Report.StartStep("I check if the number of products in the footer area is less than amount saved");
			new Steps_RecentActivities().GivenInTheRecentActivitesPageICheckIfTheNumberOfProductsInTheFooterAreaMatchesAmountSavedAsProductAmount("is less than", "savedAs");

		}

		[RegexStepDefinition(@"I call Shared Step 163970 \(RPS & WV - Applied filter - Main search field apply search - results grid shows correct results\)")]
		public void ThenICallSharedStep_AppliedFiler_ResultGridShowsCorrectResult()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the search field I enter a partial Product name into the search field");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProductAndClickEnter("For WVs");
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the product(s) shown contain the name I entered above");
			new Steps_ProductLookUP().CheckProductsGridDisplaysProductISearched("For WVs");


		}

		[RegexStepDefinition(@"I call Shared Step 153278 \(RPS & WV > Search > No Smart Search shown\)")]
		public void SharedStep153278()
		{
			Report.StartStep("In the search field I start typing a Product ID, Name or UPC into the Search field");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProductAndClickEnter("For WVs");
			Report.StartStep("As I type in the search field, I confirm that no smart search list is shown below the search field");
			new Steps_ProductLookUP().InTheProductLookupPageIConfirmThatTableDoesNotShowDataRows();
			Report.StartStep("I confirm the page refreshes");
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("I confirm the product(s) shown contain the name I entered above");
			new Steps_ProductLookUP().CheckProductsGridDisplaysProductISearched("For WVs");

		}
		[RegexStepDefinition(@"I call Shared Step 153374 \(RPS - Actions - View Data > Expand All\)")]
		public void SharedStep153274()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();
			Report.StartStep("In the product table, I select a product to work with");
			Report.StartStep("In the product table, in the Actions column, I click: View Data");
			Report.IsTrue(new ProductLookUp().ClickActionForFirstResultInGrid("View Data"), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
			Report.StartStep("I confirm the Product Information pop up is shown");
			Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible(), "The product Information popup did not load", "The Product Information popup was loaded");
			Report.IsTrue(new ProductInformation().ProductInformationPopUpIsDisplayed(), "Product Information pop up is not displayed", "Successfully Product Information pop up is displayed");
			Report.StartStep("I confirm the data sections shown are all expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Det.ails"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I click the button: Collapse All");
			Report.IsTrue(new ProductInformation().ClickCollapseAll(), "Failed to Click the Collpase All", "Successfully clicked the Collapse ALl");
			Report.StartStep("I confirm all data areas are collapsed");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was expanded", "The section was not expanded");
			Report.StartStep("I click the button: Expand All");
			Report.IsTrue(new ProductInformation().ClickExpandAll(), "Failed to Click the Expand All", "Successfully clicked the Expand ALl");
			Report.StartStep("I confirm I see the sections headings");
			Report.StartStep("I confirm all four sections are expanded to show their data");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I click the button: Expand All");
			Report.IsTrue(new ProductInformation().ClickExpandAll(), "Failed to Click the Expand All", "Successfully clicked the Expand ALl");
			Report.StartStep("I confirm I see the sections headings");
			Report.StartStep("I confirm all four sections are expanded to show their data");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Transportation"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Storage"), "The section was not expanded", "The section was expanded");
			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Battery"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I Close the Product Information Popup");
			Report.IsTrue(new ProductInformation().ClickCloseButton(), "Failed to click the close button", "Successfully clicked the close button");


		}

		[RegexStepDefinition(@"I call Shared Step 146584 \(WPS Studio - PD\+ - Current Document > List of Published > Open NGHS - keep window open\)")]
		public void SharedStep146584()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the Toolbar area click the Publish this Document icon");
			Report.IsTrue(new StudioPowerDesignerPlus().InTheStudioClickDocumentIcon(), "Failed to click the document icon", "Successfully clicked the document icon");
			Report.StartStep("Confirm the Current Document pop up is shown");
			Report.IsTrue(new StudioDocuments().Wait_for_load(), "Failed to load Current document pop up", "Successfully loaded current document popup");
			Report.IsTrue(new StudioDocuments().CurrentDocumentPopupIsDisplayed(), "Failed to display Current document pop up", "Successfully displayed current document popup");
			Report.StartStep("Click the List of Published Documents icon");
			Report.IsTrue(new StudioDocuments().InTheStudioClickListOfPublishedDocumentIcon(), "Failed to click the publish document icon", "Successfully clicked the publish document icon");

			Report.StartStep("Confirm the Published Documents pop up is shown");
			Report.IsTrue(new PublishedDocuments().Wait_for_load(), "Failed to load Published document pop up", "Successfully loaded Published document popup");
			Report.IsTrue(new PublishedDocuments().PublishedDocumentsPopUpIsDisplayed(), "Failed to display Published document pop up", "Successfully displayed Published document popup");

			Report.StartStep("Double click on the entry for 'MTR / NGHS' in 'EN'");
			Report.IsTrue(new PublishedDocuments().ClickOnNGHSEntry(), "Failed to click the NGHS entry", "Successfully clicked the NGHS entry");

			Report.StartStep("Confirm a new window is opened with the NGHS document opened");
			Report.IsTrue(new NGHSDocument().Wait_for_load(), "Failed to load NGHS document pop up", "Successfully loaded NGHS document popup");
			Report.IsTrue(new NGHSDocument().NGHSDocumentIsDisplayed(), "Failed to display NGHS document pop up", "Successfully displayed NGHS document popup");
			Report.StartStep("Make a note of the entry in the document for Product Code");
			string ProductCode = new StudioDocuments().TakeNoteOfProductCode("savedAs");
			Report.Info(ProductCode);

		}

		[RegexStepDefinition(@"I call Shared Step 153152 \(RPS/WV : Search for specific product\) WPSId: (.*)")]
		public void SharedStep153152(string productID)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Enter the WPS ID of the product you are working with into the Search field");
			new Steps_ProductLookUP().InTheProductLookUpSearchtheProduct(productID);
			new Global_Steps().IConfirmPageHasLoaded();
			Report.StartStep("Confirm the product you are working with is shown in the product grid");
			Report.IsTrue(new ProductLookUp().ProductsCount() == 1, "There was not just one product in the Grid", "There was only one product found in the Grid");
			Report.StartStep("Make a note of the Product name as you see in the Product Info Column of the product grid");
			string productName = new ProductLookUp().TakeNoteOfProductName("savedAs");
			Report.Info(productName);
		}

		[RegexStepDefinition(@"I call Shared Step 149250 \(Any Page - Actions: Open Document Link \(not PLP\)\)")]
		public void SharedStep149250()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("For the product you are working with, in the Actions Column: Click the Documents (or SDS + Documents) link ");
			new Steps_RecentActivities().InTheProductTableIClickDocumentsLink();
			Report.StartStep("Confirm the Documents list pop up is shown");
			new Steps_RecentActivities().InTheProductTableDocumentsPopupDisplayed();
			Report.StartStep("Confirm the Product Name for the product you are working with is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageDocuemntsPopUpIConfirmProductNameIsDisplayed();
			Report.StartStep("Confirm the Product name shown in the document pop up matches the product name you noted in the Product Info column of the product grid");
			new Steps_ProductLookUP().InTheDocumentationPopUpProductNameisDisplayedSameAsSavedValue("savedAs");
		}

		[RegexStepDefinition(@"I call Shared Step 149035 \(Webviewer: Documents > SDS US compare to NGHS\)")]
		public void SharedStep149035()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("In the documents list, confirm you see the document type label: SDS");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyDocuemntTypeLabelSDSIsDisplayed();
			Report.StartStep("Confirm the filename shown to the left of the SDS label is the same as the product ID you noted for the product in Studio followed by .PDF");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotesInStudio("savedAs");
			Report.StartStep("Confirm the SDS filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();
			Report.StartStep("Click on the SDS filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the NGHS file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsNGHSFileOpenedInStudio();

		}

		[RegexStepDefinition(@"I call Shared Step 146422 \(SHA Manager > Document Management > Primary 1, Source 0, document\)")]
		public void SharedStep146422()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the Document List pop up, select the row that shows Primary = 1, Source = 0");
			Report.IsTrue(new PublishedDocuments().SelectPrimary1Source0Entry(), "Failed to select the  row that shows Primary = 1, Source = 0", "Successfully selected the  row that shows Primary = 1, Source = 0");
			Report.StartStep("Make a note of the filename as you will check this later in the webviewer");
			string FileName = new StudioDocuments().TakeNoteOfFileName("savedAs");
			Report.Info(FileName);
			Report.StartStep("Double click on the filename for the row you selected");
			Report.IsTrue(new PublishedDocuments().ClickOnPrimary1Source0Entry(), "Failed to click the  row that shows Primary = 1, Source = 0", "Successfully clicked the  row that shows Primary = 1, Source = 0");
			Report.StartStep("Confirm the file opens in a new window/app");
			Report.StartStep("Confirm the file that opens is for your product");
			Report.IsTrue(new NGHSDocument().Wait_for_document_load(), "Failed to load  document", "Successfully loaded document");
			Report.IsTrue(new NGHSDocument().DocumentIsDisplayed(), "Failed to display document", "Successfully displayed document");


		}


		[RegexStepDefinition(@"I call Shared Step 149246 \(Webviewer: Documents >US SDS compare to Uploaded SDS\)")]
		public void SharedStep149246()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("In the documents list, confirm you see the document type label: SDS");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyDocuemntTypeLabelSDSIsDisplayed();
			Report.StartStep("Confirm the filename shown to the left of the SDS file label matches the filename you noted in SHA manager earlier");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotedInStudio("savedAs");
			Report.StartStep("Confirm the SDS filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();
			Report.StartStep("Click on the SDS filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the NGHS file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsNGHSFileOpenedInStudio();

		}

		[RegexStepDefinition(@"I call Shared Step 149196 \(Any Page - Actions: Open Document Link for PLP\)")]
		public void SharedStep149196()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("For the product you are working with, in the Actions Column: Click the Documents (or SDS + Documents) link ");
			new Steps_RecentActivities().InTheProductTableIClickDocumentsLink();
			Report.StartStep("Confirm the Documents list pop up is shown");
			new Steps_RecentActivities().InTheProductTableDocumentsPopupDisplayed();
			Report.StartStep("Confirm the Product Name for the product you are working with is shown");
			new Steps_RecentActivities().InTheRecentActivitiesPageDocuemntsPopUpIConfirmProductNameIsDisplayed();
			Report.StartStep("Confirm the Product name shown in the document pop up matches the product name you noted in the Product Info column of the product grid");
			new Steps_ProductLookUP().InTheDocumentationPopUpProductNameisDisplayedSameAsSavedValue("savedAs");
		}

		[RegexStepDefinition(@"I call Shared Step 146583 \(WPS Studio - PD\+ - Select Alias product for retailer\) WPSID: (.*) Retailer: (.*)")]
		public void SharedStep146583(string productID, string retailer)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Click the three dots search icon next to the Product ID");
			Report.IsTrue(new StudioDocuments().Click3DotsNextToSerachIcon(), "Failed to click button", "Successfully clicked the  button");
			Report.StartStep("Confirm the Select Product pop up is shown");
			Report.IsTrue(new SelectProduct().Wait_for_load(), "Failed to load Select Product pop up", "Successfully loaded Select Product popup");
			Report.IsTrue(new SelectProduct().SelectProductPopupIsDisplayed(), "Failed to display popup", "Successfully displayed popup");
			Report.StartStep("Confirm an entry shows for the main product and each of the alias/retailers present on your product");
			Report.IsTrue(new SelectProduct().VerifyEntryForEachProduct(productID), "Failed to display retailers for each product", "Successfully displayed retailers for each product");

			Report.StartStep("Make a note of the Alias product name (this is the PLP name we will see in the webviewer)");
			string aliasProdutId = new SelectProduct().TakeNoteOfAliasPrroductID("savedAs", retailer);
			Report.Info(aliasProdutId);
			Report.StartStep("Select the Product ID/Alias ID combination for the retailer you are working with");
			Report.Info("Attempting to select the product");
			new SelectProduct().SelectAliasId(retailer);
			Report.StartStep("Confirm the Select Product pop up is closed");
			Report.IsTrue(new SelectProduct().SelectProductPopupIsNotDisplayed(), "Failed to not display popup", "Successfully popup is closed");
			Report.StartStep("Confirm the Alias Product you selected is shown in the Product ID field");
			new Steps_RecentActivities().GivenInDocumentsPageICheckIfTheAliasNameMatchesProductSavedAsProductID("savedAs", retailer);
		}

		[RegexStepDefinition(@"I call Shared Step 148846 \(Webviewer: Documents > Kit > Merged SDS > Keep pop up open\)")]
		public void SharedStep148846()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm the Document List pop up shows the following products and their documentsMain Product, Input child product 1, Input child product 2, Input child product 3");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("Confirm the filename shown is the same as the WPS ID for your product followed by .PDF");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotedInStudio("savedAs");
			Report.StartStep("Confirm the document type label shows: SDS");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyDocuemntTypeLabelSDSIsDisplayed();
			Report.StartStep("Confirm the filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();
			Report.StartStep("Click on the  filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the  file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsNGHSFileOpenedInStudio();
			Report.StartStep("Close the new browser window that opened");
			new Global_Steps().ICloseBrowser();

		}

		[RegexStepDefinition(@"I call Shared Step 146585 \(WPS Studio - PD\+ - Current Document > List of Published > Open Summary Sheet - keep window open\)")]
		public void SharedStep146585()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the Toolbar area click the Publish this Document icon");
			Report.IsTrue(new StudioPowerDesignerPlus().InTheStudioClickDocumentIcon(), "Failed to click the document icon", "Successfully clicked the document icon");
			Report.StartStep("Confirm the Current Document pop up is shown");
			Report.IsTrue(new StudioDocuments().Wait_for_load(), "Failed to load Current document pop up", "Successfully loaded current document popup");
			Report.IsTrue(new StudioDocuments().CurrentDocumentPopupIsDisplayed(), "Failed to display Current document pop up", "Successfully displayed current document popup");
			Report.StartStep("Click the List of Published Documents icon");
			Report.IsTrue(new StudioDocuments().InTheStudioClickListOfPublishedDocumentIcon(), "Failed to click the publish document icon", "Successfully clicked the publish document icon");

			Report.StartStep("Confirm the Published Documents pop up is shown");
			Report.IsTrue(new PublishedDocuments().Wait_for_load(), "Failed to load Published document pop up", "Successfully loaded Published document popup");
			Report.IsTrue(new PublishedDocuments().PublishedDocumentsPopUpIsDisplayed(), "Failed to display Published document pop up", "Successfully displayed Published document popup");

			Report.StartStep("Double click on the entry for 'MTR / SBCS' in 'EN'");
			Report.IsTrue(new PublishedDocuments().ClickOnSBCSEntry(), "Failed to click the SBCS entry", "Successfully clicked the SBCS entry");

			Report.StartStep("Confirm a new window is opened with the Summary Sheet document opened");
			Report.IsTrue(new SummarySheetDocument().Wait_for_load(), "Failed to load Summary Sheet document pop up", "Successfully loaded Summary Sheet document popup");
			Report.IsTrue(new SummarySheetDocument().SummarySheetDocumentIsDisplayed(), "Failed to display Summary Sheet document pop up", "Successfully displayed Summary Sheet document popup");
			Report.StartStep("Make a note of the entry in the document for Product Code");
			string ProductCode = new StudioDocuments().TakeNoteOfProductCode("savedAs");
			Report.Info(ProductCode);

		}

		[RegexStepDefinition(@"I call Shared Step 148764 \(WPS Studio - Report writer - find UN38.3 document name\) for WPSID:(.*)")]
		public void SharedStep148764(string WPSID)
		{
			var thisTopMenu = new StudioTopMenu();
			Report.StartStep("Click the Distribution Menu");
			Report.StartStep("In the Distribution Menu drop down: Select Report writer");
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Distribution", "Report Writer"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
			Report.Screenshot();
			Delay.Seconds(3);
			Report.StartStep("Click the SQL tab header");
			Report.IsTrue(new ReportWriter().WaitUntilTableIsLoaded(), "Failed to load Report writer table", "Report Writer tab is loaded successfully");
			Report.IsTrue(new ReportWriter().ClickSqlTab(), "Failed to click SQL tab", "Successfully clicked SQL tab");
			Report.StartStep("In the SQL Statement window enter the text");
			new ReportWriter().EnterSqlStatement("select * from t_documents where f_alias =" + WPSID + "and f_doc_type = '72'");
			Report.StartStep("Click Execute");
			Report.IsTrue(new ReportWriter().ClickExecute(), "Failed to click the Execute button", "Successfully clicked the Execute button");
			Report.StartStep("Make a note of the filename shown under f_file_name");
			new ReportWriter().TakeNoteOfFileName("savesAs");
			Report.StartStep("Close the Report writer module");
			Report.IsTrue(new ReportWriter().CloseReportWriterTab(), "Failed to close Report Writer tab", "Successfully closed Report Writer tab");


		}

		[RegexStepDefinition(@"I call Shared Step 148765 \(WPS Studio - PD\+ - related documents - Open UN38.3 document\)")]
		public void SharedStep148765()
		{

			Report.StartStep("In the My Toolbar area: Click the Related document icon");
			Report.IsTrue(new StudioPowerDesignerPlus().InTheStudioClickRelatedDocumentIcon(), "Failed to click the document icon", "Successfully clicked the document icon");
			Report.StartStep("Confirm the Related Documents pop up is shown");
			Report.IsTrue(new RelatedDocuments().Wait_for_load(), "Failed to load Current document pop up", "Successfully loaded current document popup");
			Report.StartStep("Confirm you see an entry for the filename you made a note of earlier in the report writer module");
			Report.IsTrue(new RelatedDocuments().Wait_for_load(), "Failed to load related document pop up", "Successfully loaded related document popup");
			Report.IsTrue(new RelatedDocuments().FileNameNotedEarlierIsDisplayed("savedAs"), "Failed to verify to display filename noted earlier", "Successfully displayed the filename notes earlier");
			Report.StartStep("Double click on the entry for the filename you made a note of earlier");
			Report.IsTrue(new RelatedDocuments().ClickFileNameNotedEarlier("savedAs"), "Failed to click fileName", "Successfully clicked fileName");
			Report.StartStep("Confirm a new browser window opens with the document shown");
			Report.IsTrue(new RelatedDocuments().Wait_for_document_load(), "Failed to load document", "Successfully loaded document");
			Report.IsTrue(new RelatedDocuments().DocumentIsDisplayed(), "Failed to display document", "Successfully displayed document");
		}

		[RegexStepDefinition(@"I call Shared Step 149110 \(Webviewer: Documents > Battery > UN38.3 compare to Studio related document\)")]
		public void SharedStep149110()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();

			Report.StartStep("In the documents list, confirm you see the document type label: UN38.3");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelUN383IsDisplayed(), "Failed to display the label", "Successfully displayed the label");

			Report.StartStep("Confirm the filename shown to the left of the UN38.3 Test Document file label is the same as you saw earlier in :Report writer");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotedInStudio("savedAs");

			Report.StartStep("Confirm the UN38.3 Testing Document filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();

			Report.StartStep("Click on the UN38.3 Testing Document filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();

			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");

			Report.StartStep("Confirm the file that is opened is the same as the UN38.3 document you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsNGHSFileOpenedInStudio();

		}

		[RegexStepDefinition(@"I call Shared Step 149071 \(Webviewer: Documents > SDS Summary Sheet compare to SBCS\)")]
		public void SharedStep149071()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();

			Report.StartStep("In the documents list, confirm you see the document type label: SDS Summary Sheet");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelSDSSummarySheetIsDisplayed(), "Failed to display the label", "Successfully displayed the label");

			Report.StartStep("Confirm the filename shown to the left of the SDS label is the same as the product ID you noted for the product in Studio followed by .PDF");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotedInStudio("savedAs");

			Report.StartStep("Confirm the SDS Summary Sheet filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();

			Report.StartStep("Click on the SDS Summary Sheet filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();

			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");

			Report.StartStep("Confirm the file that is opened is the same as the SBCS file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsSDSSummarySheetFileOpenedInStudio();

		}

		[RegexStepDefinition(@"I call Shared Step 146592 \(Webviewer: Documents > No documents shown\)")]
		public void SharedStep146592()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm the Product name is shown.  If you are working with a Private Label product make sure the product name shown is the PLP name for the specific retailer you are working with");
			new Steps_RecentActivities().InTheRecentActivitiesPageDocuemntsPopUpIConfirmProductNameIsDisplayed();
			Report.StartStep("Confirm you see the message: No documents found for this UPC");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyDocumentNotFoundIsDisplayed();
			Report.StartStep("Confirm below the product name you do not see any filenames or document type labels");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelIsNotDisplayed(), "Displayed the label", "Successfully did not display the label");
			Report.StartStep("Close the Documents List pop up");
			new Steps_RecentActivities().ICloseTheDocumentListPopUp();

		}

		[RegexStepDefinition(@"I call Shared Step 146626 \(WPS Studio - PD\+ > Related Documents > Consumer Label > SHAMANAGER user\)")]
		public void SharedStep146626()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the PD+ Toolbar click on the Related documents icon");
			Report.IsTrue(new StudioPowerDesignerPlus().InTheStudioClickRelatedDocumentIcon(), "Failed to click the document icon", "Successfully clicked the document icon");
			Report.StartStep("Confirm the Related Documents pop up is shown");
			Report.IsTrue(new RelatedDocuments().Wait_for_load(), "Failed to load Related document pop up", "Successfully loaded Related document popup");
			Report.IsTrue(new RelatedDocuments().RelatedDocumentsIsDisplayed(), "Failed to display Related document pop up", "Successfully displayed Related document popup");
			Report.StartStep("Confirm you see an entry for Document Type = Consumer Label User Updated = SHAMANAGER");
			Report.IsTrue(new RelatedDocuments().UserUpdatedSHAMANAGERIsDisplayed(), "Failed to verify to entry for Document Type = Consumer Label User Updated = SHAMANAGER", "Successfully displayed entry for Document Type = Consumer Label User Updated = SHAMANAGER");
			Report.StartStep("Make a note of the filename shown in the File Name column");
			new RelatedDocuments().MakeANoteOfFileNameWithUserTypeSHAMANAGER("savedAs");
			Report.StartStep("Double click on the entry for Document Type = Consumer Label User Updated = SHAMANAGER");
			Report.IsTrue(new RelatedDocuments().DoubleClickEntryForUserTypeSHAMANAGER(), "Failed to click entry for Document Type = Consumer Label User Updated = SHAMANAGER", "Successfully clicked entry for Document Type = Consumer Label User Updated = SHAMANAGER");
			Report.StartStep("Confirm a new window opens with the Document shown");
			Report.IsTrue(new RelatedDocuments().Wait_for_document_load(), "Failed to load document", "Successfully loaded document");
			Report.IsTrue(new RelatedDocuments().DocumentIsDisplayed(), "Failed to display document", "Successfully displayed document");

		}

		[RegexStepDefinition(@"I call Shared Step 149121 \(Webviewer: Documents  > Consumer Label compare with Studio related document\)")]
		public void SharedStep149121()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("In the documents list, confirm you see the document type label: Consumer Label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyDocuemntTypeLabelConsumerlabelIsDisplayed();
			Report.StartStep("Confirm the filename shown to the left of the Consumer Label file label is the same as you saw earlier in: Studio");
			new Steps_RecentActivities().IConfirmTheFileNameShownLeftOfConsumerlabelIsSameAsNotedInStudio("savedAs");
			Report.StartStep("Confirm the Consumer Label filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();
			Report.StartStep("Click on the Consumer Label filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the file you opened in Studio related documents earlier");
			new Steps_RecentActivities().FileOpenedIsSameAsConsumerLabelFileOpenedInStudio();

		}

		[RegexStepDefinition(@"I call Shared Step 220438 \(Webviewer: Documents - US SDS opens directly - compare to Uploaded SDS\)")]
		public void SharedStep220438()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartSubStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartSubStep("Confirm the file that is opened is the same as the file you opened in SHA Manager earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsSDSFileOpenedInStudio();
			Report.StartSubStep($"Close the new browser window that opened");
			new Global_Steps().ICloseBrowser();

		}

		[RegexStepDefinition(@"I call Shared Step 220316 \(Webviewer: Documents - SDS US opens directly - compare to NGHS\)")]
		public void SharedStep220316()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartSubStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartSubStep("Confirm the file that is opened is the same as the file you opened in SHA Manager earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsNGHSFileOpenedInStudio();
			Report.StartSubStep($"Close the new browser window that opened");
			new Global_Steps().ICloseBrowser();

		}

		[RegexStepDefinition(@"I call Shared Step 148839 \(SHA Manager - Open Merged SDS for BCP\) with WPSID: (.*)")]
		public void SharedStep148839(string wpsid)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the Document List pop up, I confirm I see a file which has the namexxxxxxxx.pdf where xxxxxxxx is the WPS ID of the product I am working with");
			Report.IsTrue(new PublishedDocuments().SelectFileNameWithWPSID(wpsid), "Failed to select the  row that shows wpsid", "Successfully selected the  row that shows wpsid");
			Report.StartStep("Double click on the filename for the row you selected");
			Report.IsTrue(new PublishedDocuments().ClickOnPrimary1Source0Entry(), "Failed to click the  row that shows Primary = 1, Source = 0", "Successfully clicked the  row that shows Primary = 1, Source = 0");
			Report.StartStep("Confirm the file opens in a new window/app");
			Report.StartStep("Confirm the file that opens is for your product");
			Report.IsTrue(new NGHSDocument().Wait_for_document_load(), "Failed to load  document", "Successfully loaded document");
			Report.IsTrue(new NGHSDocument().DocumentIsDisplayed(), "Failed to display document", "Successfully displayed document");


		}


		[RegexStepDefinition(@"I call Shared Step 148960 \(Webviewer: Documents > Compare SDS with Merged SDS in SHA manager for BCP\)")]
		public void SharedStep148960()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("Confirm the document type label shows: SDS");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyDocuemntTypeLabelSDSIsDisplayed();
			Report.StartStep("Confirm the filename shown is a clickable link");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyFileNameIsClickable();
			Report.StartStep("Click on the  filename link");
			new Steps_RecentActivities().InTheDocumentationPopUpClickOnFileName();
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the  file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsNGHSFileOpenedInStudio();
			Report.StartStep("Close the new browser window that opened");
			new Global_Steps().ICloseBrowser();

		}

		[RegexStepDefinition(@"I call Shared Step 108297 \(Drum Log - Export to Excel - Export All Drums - open file\)")]
		public void SharedStep108297()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			Report.StartStep("In the Drum Log page, I click on the Export to Excel button");
			Report.IsTrue(new DrumLog().ClickExportToExcelButton(), "Failed to click Export to Excel button", "Successfully clicked Export to Excel button");

			Report.StartStep("In the Export pop up, I click the  Export All Drums button");
			Report.IsTrue(new DrumLog().ClickExportAllDrumsButton(), "Failed to click Export All Drums button", "Successfully clicked Export All Drums button");

			Report.StartStep("I Check that there is a new csv file downloaded and save the file path as: (.*)");
			new Global_Steps().CheckNewCsvFileDownloadedAndSaveAs("drumlogfile");

		}

		[RegexStepDefinition(@"I call Shared Step 108298 \(Drum Log - Export to Excel - Export all Drums with UPCs - open file\)")]
		public void SharedStep108298()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			Report.StartStep("In the Drum Log page, I click on the Export to Excel button");
			Report.IsTrue(new DrumLog().ClickExportToExcelButton(), "Failed to click Export to Excel button", "Successfully clicked Export to Excel button");

			Report.StartStep("In the Export pop up, I click the  Export All Drums button");
			Report.IsTrue(new DrumLog().ClickExportAllDrumsWithUPCButton(), "Failed to click Export All Drums with UPCs button", "Successfully clicked Export All Drums with UPCs button");

			Report.StartStep("I Check that there is a new csv file downloaded and save the file path as: drumlogfile");
			new Global_Steps().CheckNewCsvFileDownloadedAndSaveAs("drumlogfile");

		}

		[RegexStepDefinition(@"I call Shared Step 146627 \(Recent Activities - Export - Open File\)")]
		public void SharedStep146627()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			Report.StartStep("In the recent activities Page, I click the Export To Excel Button");
			new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheExportToExcelButton();
			Thread.Sleep(50000);
			Report.StartStep("I Check that there is a new csv file downloaded and save the file path as: (.*)");
			new Global_Steps().CheckNewCsvFileDownloadedAndSaveAs("recentactivitiesfile");

		}

		[RegexStepDefinition(@"I call Shared Step 110819 \(Home Depot & CVS Only - Product Information pop up - Expand Product Details - Confirm rows\)")]
		public void SharedStep110819()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			new ProductInformation().WaitForProductInformationToLoad();

			Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was not expanded", "The section was expanded");
			Report.StartStep("I confirm that an additional area is shown below the Product Details heading");
			Report.IsTrue(new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Transportation heading was not showing", "The additional area is shown below the Transportation heading was showing");
			List<string> expectedHeadings = new List<string> { "Supplier Contact Name", "US EPA Waste Number", "Flash point °C", "Flash point (°C) DEGREES", "MSDS?" };
			Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
			Report.IsTrue(new ProductInformation().ProductDataCodesHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
			Report.StartStep("In the Product Information pop up, I click the Product Details heading");
			Report.StartStep("I confirm the additional area below the Product Details heading is no longer shown");
			Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
			Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
			Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Transportation Data heading was showing", "The additional area is shown below the Transportation Data heading was not showing");

		}


		[RegexStepDefinition(@"I call Shared Step 150041 \(WPS Studio - PD\+ - Current Document > List of Published > Open HGHS in EN and CF keep windows open\)")]
		public void SharedStep150041()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("In the Toolbar area click the Publish this Document icon");
			Report.IsTrue(new StudioPowerDesignerPlus().InTheStudioClickDocumentIcon(), "Failed to click the document icon", "Successfully clicked the document icon");
			Report.StartStep("Confirm the Current Document pop up is shown");
			Report.IsTrue(new StudioDocuments().Wait_for_load(), "Failed to load Current document pop up", "Successfully loaded current document popup");
			Report.IsTrue(new StudioDocuments().CurrentDocumentPopupIsDisplayed(), "Failed to display Current document pop up", "Successfully displayed current document popup");
			Report.StartStep("Click the List of Published Documents icon");
			Report.IsTrue(new StudioDocuments().InTheStudioClickListOfPublishedDocumentIcon(), "Failed to click the publish document icon", "Successfully clicked the publish document icon");
			Report.StartStep("Confirm the Published Documents pop up is shown");
			Report.IsTrue(new PublishedDocuments().Wait_for_load(), "Failed to load Published document pop up", "Successfully loaded Published document popup");
			Report.IsTrue(new PublishedDocuments().PublishedDocumentsPopUpIsDisplayed(), "Failed to display Published document pop up", "Successfully displayed Published document popup");
			Report.StartStep("Double click on the entry for 'MTR / HGHS' in 'EN'");
			Report.IsTrue(new PublishedDocuments().ClickOnHGHSENEntry(), "Failed to click the HGHS EN entry", "Successfully clicked the HGHS EN entry");
			Report.StartStep("Confirm a new window is opened with the HGHS EN document opened");
			Report.IsTrue(new HGHSDocument().Wait_for_load(), "Failed to load HGHS document pop up", "Successfully loaded HGHS document popup");
			Report.IsTrue(new HGHSDocument().HGHSENDocumentIsDisplayed(), "Failed to display HGHS document pop up", "Successfully displayed HGHS document popup");
			Report.StartStep("Make a note of the entry in the document for Product Code");
			string ProductCodeEN = new StudioDocuments().TakeNoteOfProductCode("savedAsEN");
			new Global_Steps().SwitchToWindowWithTitle("Published Documents");
			Report.StartStep("Double click on the entry for 'MTR / HGHS' in 'CF'");
			Report.IsTrue(new PublishedDocuments().ClickOnHGHSCFEntry(), "Failed to click the HGHS CF entry", "Successfully clicked the HGHS CF entry");
			Report.StartStep("Confirm a new window is opened with the HGHS  CF document opened");
			Report.IsTrue(new HGHSDocument().Wait_for_load(), "Failed to load HGHS document pop up", "Successfully loaded HGHS document popup");
			Report.IsTrue(new HGHSDocument().HGHSCFDocumentIsDisplayed(), "Failed to display HGHS document pop up", "Successfully displayed HGHS document popup");
			Report.StartStep("Make a note of the entry in the document for Product Code");
			string ProductCodeCF = new StudioDocuments().TakeNoteOfProductCode("savedAsCF");

		}

		[RegexStepDefinition(@"I call Shared Step 149205 \(Webviewer: Documents > SDS, Canada GHS, English compare to HGHS\)")]
		public void SharedStep149205()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("In the documents list, confirm you see the document type label: SDS, Canada GHS, English");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelSDSCanadaGHSEnglishIsDisplayed(), "Failed to display document type label", "Successfully displayed document type label");
			Report.StartStep("Confirm the filename shown to the left of the SDS, Canada GHS, English label is the same as the product ID you noted for the product in Studio followed by .PDF");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotesInStudio("savedAsEN");
			Report.StartStep("Confirm the SDS, Canada GHS, English filename shown is a clickable link");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSCanadaGHSEnglishFileNameIsClickable(), "Failed to verify that file name is clickable", "Successfully verified that file name is clickable");
			Report.StartStep("Click on the SDS, Canada GHS, English filename link");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpClickSDSCanadaGHSEnglishFileName(), "Failed to click file name", "Successfully clicked file name");
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the HGHS file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsHGHSFileOpenedInStudio();


		}

		[RegexStepDefinition(@"I call Shared Step 146328 \(Webviewer: Documents > SDS, Canada GHS, French compare to HGHS in CF\)")]
		public void SharedStep146328()
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;

			Report.StartStep("Confirm below the Product name you see a list showing one or more filename followed by a document type label");
			new Steps_RecentActivities().InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed();
			Report.StartStep("In the documents list, confirm you see the document type label: SDS, Canada GHS, French");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelSDSCanadaGHSFrenchIsDisplayed(), "Failed to display document type label", "Successfully displayed document type label");
			Report.StartStep("Confirm the filename shown to the left of the SDS, Canada GHS, French label is the same as the product ID you noted for the product in Studio followed by .PDF");
			new Steps_RecentActivities().InTheDocumentationPopUpConfirmTheFileNameAsNotesInStudio("savedAsCF");
			Report.StartStep("Confirm the SDS, Canada GHS, French filename shown is a clickable link");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSCanadaGHSFrenchFileNameIsClickable(), "Failed to verify that file name is clickable", "Successfully verified that file name is clickable");
			Report.StartStep("Click on the SDS, Canada GHS, French filename link");
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpClickSDSCanadaGHSFrenchFileName(), "Failed to click file name", "Successfully clicked file name");
			Report.StartStep("Confirm the file is opened and is the correct document type");
			Report.IsTrue(new RecentActivities.DocumentsPopup().DocumentIsDisplayed(), "Failed to open file", "Successfully opened the file");
			Report.StartStep("Confirm the file that is opened is the same as the HGHS file you opened in Studio earlier in your test case");
			new Steps_RecentActivities().FileOpenedIsSameAsHGHSFileOpenedInStudio();


		}

        [RegexStepDefinition(@"I call Shared Step 165091 \(Logistics Viewer - View Data - Additional Data - Confirm rows \(Target Specific - Target HQ Viewer\)\)")]
        public void SharedStep165091()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad();
            Report.StartStep("In the Product Information pop up, I click the Additional Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Additional Data"), "Failed to Click the section", "Successfully clicked the section");
            Delay.Seconds(1);
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Additional Data"), "The section was not expanded", "The section was expanded");

            Report.StartStep("In the Product Information popup Additional Data heading I confirm background color: Orange");
			new Steps_ProductInformation().ConfirmAdditionalDataBackgroundColorIsOrange();
            Report.StartStep("In the Additional Data heading I confirm font color: white");
            new Steps_ProductInformation().ConfirmAdditionalDataHeadingColorIsWhite();
            Report.StartStep("I confirm that an additional area is shown below the Additional Data heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Additional Data"), "The additional area is shown below the Additional Data heading was not showing", "The additional area is shown below the Additional Data heading was showing");
			List<string> expectedHeadings = new List<string> { "WHMIS Hazard Class","California Proposition 65","Contains Ingredient(s) on PROP65","EPA Pesticide Registration Number","State Pesticide Registration Number","State Pesticide Expiration Date","SCAQ Message","CARB Message","OTC Message","Aerosol Coating Message","California Hazardous Waste","Description","DOT EX-Number","DOT Special Permit Number","Packaging Exceptions","Hazard Class",
				                                               "Packing Group","UN-No.","Vessel Stowage Location Code","Reportable Quantity (RQ) (RQ/% in mixture)","Non-Bulk Packaging","ERG Code","Emergency Response Guide Number","DOT T-Number","Microbead product","Is this product a \"rinse off\" type product?","Microbead product WS","US EPA Waste Number","Target Flammability-UPC Level","Waste Type Attribute","pH","Physical state" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().AdditionalDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the Additional Data heading");
            Report.StartStep("I confirm the additional area below the Additional Data heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Additional Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Additional Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Additional Data"), "The additional area is shown below the Additional Data heading was showing", "The additional area is shown below the Additional Data heading was not showing");
        }


        [RegexStepDefinition(@"I call Shared Step 163203 \(Status/Store Viewer - View Data - Additional Data - Confirm rows \(Target specific\)\)")]
        public void SharedStep163203()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad();
            Report.StartStep("In the Product Information pop up, I click the Additional Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Additional Data"), "Failed to Click the section", "Successfully clicked the section");
            Delay.Seconds(1);
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Additional Data"), "The section was not expanded", "The section was expanded");

            Report.StartStep("In the Product Information popup Additional Data heading I confirm background color: Orange");
            new Steps_ProductInformation().ConfirmAdditionalDataBackgroundColorIsOrange();
            Report.StartStep("In the Additional Data heading I confirm font color: white");
            new Steps_ProductInformation().ConfirmAdditionalDataHeadingColorIsWhite();
            Report.StartStep("I confirm that an additional area is shown below the Additional Data heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Additional Data"), "The additional area is shown below the Additional Data heading was not showing", "The additional area is shown below the Additional Data heading was showing");
            List<string> expectedHeadings = new List<string> {"Waste Type Attribute", "US EPA Waste Number", "Target Flammability-UPC Level","pH","Physical state" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().AdditionalDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the Additional Data heading");
            Report.StartStep("I confirm the additional area below the Additional Data heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Additional Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Additional Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Additional Data"), "The additional area is shown below the Additional Data heading was showing", "The additional area is shown below the Additional Data heading was not showing");
        }

        [RegexStepDefinition(@"I call Shared Step 162795 \(View Data - Product Information Pop up - Additional Data Codes - Confirm row \(Target Specific\)\)")]
        public void SharedStep162795()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            new ProductInformation().WaitForProductInformationToLoad();
            Report.StartStep("In the Product Information pop up, I click the Additional Data heading");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Additional Data"), "Failed to Click the section", "Successfully clicked the section");
            Delay.Seconds(1);
            Report.IsTrue(new ProductInformation().ProductInformationSectionIsActive("Additional Data"), "The section was not expanded", "The section was expanded");

            Report.StartStep("In the Product Information popup Additional Data heading I confirm background color: Orange");
            new Steps_ProductInformation().ConfirmAdditionalDataBackgroundColorIsOrange();
            Report.StartStep("In the Additional Data heading I confirm font color: white");
            new Steps_ProductInformation().ConfirmAdditionalDataHeadingColorIsWhite();
            Report.StartStep("I confirm that an additional area is shown below the Additional Data heading");
            Report.IsTrue(new ProductInformation().SectionDataTablePresent("Additional Data"), "The additional area is shown below the Additional Data heading was not showing", "The additional area is shown below the Additional Data heading was showing");
            List<string> expectedHeadings = new List<string> { "Waste Type Attribute", "US EPA Waste Number", "Target Flammability-UPC Level", "pH", "Physical state" };
            Report.StartStep($"I confirm the additional rows shown are: {string.Join(",", expectedHeadings)}");
            Report.IsTrue(new ProductInformation().AdditionalDataHeadingsPresent(expectedHeadings), "The headings were not as expected", "The headings were as expected");
            Report.StartStep("In the Product Information pop up, I click the Additional Data heading");
            Report.StartStep("I confirm the additional area below the Additional Data heading is no longer shown");
            Report.IsTrue(new ProductInformation().ClickProductInformationSection("Additional Data"), "Failed to Click the section", "Successfully clicked the section");
            Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Additional Data"), "The section was expanded", "The section was not expanded");
            Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Additional Data"), "The additional area is shown below the Additional Data heading was showing", "The additional area is shown below the Additional Data heading was not showing");
        }

        [RegexStepDefinition(@"I call Shared Step 108305 \(Drum Log - Select Row and Expand > Actions - View Data\)")]
        public void SharedStep108305()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            
            Report.StartStep("In the Drum Log page, I expand the first row of the products table");
			new Steps_DrumLog().InTheDrumLogPageIExpandFirstRow();

            Report.StartStep("In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.");
            new Steps_DrumLog().InTheDrumLogPageCheckFirstRowExpandedAdditionalRows();
			new Steps_DrumLog().HomeTabLoaded();

            Report.StartStep("In the expanded data row I am working with, in the Actions column, I click: View Data ");
            new Steps_DrumLog().InTheDrumLogPageInProductsTableIClickViewDataForFirstProduct();

        }


        [RegexStepDefinition(@"I call Shared Step 153264 \(RPS & WV > Product Info > Recertification tags check\)")]
        public void SharedStep153264()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartStep("I confirm the Product Info column shows the Recertification tag");
            Report.StartStep("I confirm the Recertification tag is shown after the Product name and before the UPC line");
            Report.StartStep("I confirm the Recertification tag is shown in blue bold font");
			new Steps_SuperTable().InTheRecentActivitesPageInProductTableFirstResultShowsTag("1", "blue", "Recertification","does","Product Name");

        }

        [RegexStepDefinition(@"I call Shared Step 153383 \(RPS & WV > Retailer Uploaded tag\)")]
        public void SharedStep153383()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartStep("In the Search field I enter 91000");
			new Steps_SuperTable().InTableNavigationAreaSearchInputEnter("91000");
            Report.StartStep("I confirm that one or more product is shown which has a WPS ID which starts with 91000");
			new Steps_SuperTable().InProductInfoCellInRowValueDoesDoesNotMatch("1", "WPSID", "does", "91000");
            Report.StartStep("In the Product Info column, I confirm I see the tag \"Retailer Uploaded\" after the Product Name");
            Report.StartStep("I confirm the Retailer Uploaded tag is shown in bold, blue font\r\n");
            new Steps_SuperTable().InTheRecentActivitesPageInProductTableFirstResultShowsTag("1", "blue", "Retailer Uploaded", "does", "Product Name");

        }

 


    }
}

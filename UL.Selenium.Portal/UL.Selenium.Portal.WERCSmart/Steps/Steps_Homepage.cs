using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Homepage")]
	class StepsHomepage
	{
		[StepDefinition(@"the WERCSmart homepage should load")]
		[StepDefinition(@"the WERCSmart homepage should be loaded")]
		public void ThenTheWercSmartHomepageShouldLoad()
		{
			Report.IsTrue(new Homepage().WaitForContainerToBeVisible(), "WERCSmart Homepage failed to load!", "WERCSmart homepage loaded successfully!");
			GeneralUtilities.Wait_for_load_finish();
			Report.Screenshot();
		}


		[StepDefinition(@"I stay on the homepage with no activity until the inactivity popup appears")]
		public void ThenStayOnTheHomepageWithNoActivityForMinutes()
		{
			try
			{
				// In order to do this we have to keep the SeleniumWebDriver Busy - cannot let it be idle for 10 minutes otherwise we will hit an error when we attempt to do something!

				Report.Info("Staying on the homepage with no activity until the inactivity popup appears");
				var selInactivityPopup = new InactivityPopup();
				selInactivityPopup.WaitForContainerToBeVisible(900);
				while (!selInactivityPopup.IsVisible())
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
				}
				Report.Success("Inactivity Popup appeared!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the Inactivity popup is displayed after waiting (.*) minutes accurate to the nearest (.*) minutes")]
		public void ConfirmTheInactivityPopupDisplayedAfterWait(int expectedWait, int marginOfError)
		{
			// check if popup wasn't displayed after 'expected wait + margin' (test upper limit)
			if (!new InactivityPopup().WaitUntilDisplayed((expectedWait * 60) + (marginOfError * 60), out int actualWait))
			{
				Report.Failure($"The Inactivity popup did not load after {expectedWait + marginOfError} minutes!");
				Report.Screenshot();
				return;
			}
			// check if pop up was displayed before 'expected wait - margin' (test lower limit)
			Report.IsTrue(actualWait >= (expectedWait * 60) - (marginOfError * 60),
				"The Inactivity popup did not load within the expected time frame! It was loaded after " + actualWait / 60 + " minutes",
				"The Inactivity popup loaded within the expected time frame. It was loaded after: " + actualWait / 60 + " minutes");
		}

		[StepDefinition(@"I confirm the Inactivity pop is closed")]
		public void ConfirmInactivityPopupIsClosed()
		{
			Report.IsTrue(new InactivityPopup().WaitForContainerToBeInvisible(), "The Inactivity popup was not closed!", "The Inactivity popup was closed.");
		}

		[StepDefinition(@"Click (Yes|No) on the inactivity popup")]
		public void GivenClickOnInactivityPopup(string button)
		{
			Report.Info("Clicking " + button + " on inactivity popup");
			var selInactivityPopup = new InactivityPopup();
			bool clicked = false;
			switch (button)
			{
				case ("Yes"):
					clicked = selInactivityPopup.ClickYes();
					break;
				case ("No"):
					clicked = selInactivityPopup.ClickNo();
					break;
				default:
					Report.Error("Button parameter must be 'Yes' or 'No'!");
					return;
			}
			Report.IsTrue(clicked, $"Failed to click the '{button}' button", $"Successfully clicked the '{button}' button");
		}



		[StepDefinition(@"I should see the (.*) in the (header bar|user dropdown|navigation bar|main window|home page header|products grid)")]
		[StepDefinition(@"I should see (.*) in the (header bar|user dropdown|navigation bar|main window|home page header|products grid)")]
		public void ThenIShouldSeeTheUlwercSmartLogoInTheHeaderBar(string item, string area)
		{
			try
			{
				switch (area)
				{
					case ("header bar"):
						{
							var selTopMenuBar = new TopMenuBar();
							switch (item.ToLower())
							{
								case ("user icon"):
									Report.IsTrue(selTopMenuBar.UserIconShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("notification icon"):
									Report.IsTrue(selTopMenuBar.NotificationIconShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("ul/wercsmart logo"):
									Report.IsTrue(selTopMenuBar.WercSmartLogoShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
							}
							break;
						}
					case ("user dropdown"):
						{
							var selTopMenuBar = new TopMenuBar();
							switch (item.ToLower())
							{
								case ("my account"):
									Report.IsTrue(selTopMenuBar.MyAccountOptionPresent(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("sign out"):
									Report.IsTrue(selTopMenuBar.SignOutOptionPresent(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
							}
							break;
						}
					case ("navigation bar"):
						{
							var selNav = new NavigationBar();
							switch (item.ToLower())
							{
								case ("navigation menu icon"):
									{
										Report.IsTrue(selNav.NavigationIconShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
										break;
									}
							}
							break;
						}
					case ("main window"):
						{
							var selHomepage = new Homepage();
							switch (item.ToLower())
							{
								case ("register product hyperlink"):
									Report.IsTrue(selHomepage.QuickLinkButtonShowing("Register Product"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									Report.IsTrue(selHomepage.QuickLinkHoveringChangeColour("Register Product"), item + " did not change colour when hovering!", item + " changed colour when hovering!");
									break;
								case ("wercslink hyperlink"):
									Report.IsTrue(selHomepage.QuickLinkButtonShowing("WERCSLink"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									Report.IsTrue(selHomepage.QuickLinkHoveringChangeColour("WERCSLink"), item + " did not change colour when hovering!", item + " changed colour when hovering!");
									break;
								case ("subheading product information"):
									Report.IsTrue(selHomepage.TopGridHeaderPresent("Product Information"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("subheading alerts"):
									Report.IsTrue(selHomepage.TopGridHeaderPresent("Alerts"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("subheading announcements"):
									Report.IsTrue(selHomepage.TopGridHeaderPresent("Announcements"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("subheading product information expanded"):
									Report.IsTrue(selHomepage.TopGridHeaderPresent("Product Information"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("subheading alerts expanded"):
									Report.IsTrue(selHomepage.TopGridHeaderPresent("Alerts"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									Report.IsTrue(selHomepage.TopGridMoreOptionShowing("Alerts"), item + " was not displaying the 'MORE...' option!", item + " was correctly displaying the 'MORE...' option!");
									break;
								case ("subheading announcements expanded"):
									Report.IsTrue(selHomepage.TopGridHeaderPresent("Announcements"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
							}
							break;
						}
					case ("home page header"):
						{
							var selHomePageHeader = new HomePageHeader();
							switch (item.ToLower())
							{
								case ("register product hyperlink"):
									Report.IsTrue(selHomePageHeader.QuickLinkButtonShowing("Register Product"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("register goodguide hyperlink"):
									Report.IsTrue(selHomePageHeader.QuickLinkButtonShowing("Register GoodGuide"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("register purview hyperlink"):
									Report.IsTrue(selHomePageHeader.QuickLinkButtonShowing("Register PurView"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
								case ("wercslink hyperlink"):
									Report.IsTrue(selHomePageHeader.QuickLinkButtonShowing("WERCSLink"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
							}
							break;
						}
					case ("products grid"):
						{
							var selProdGrid = new ProductsGrid();
							switch (item.ToLower())
							{
								case ("subheading my products"):
									Report.IsTrue(selProdGrid.HeadingShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
							}
							break;
						}
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the triangle next to Product Information to (expand|collapse) the section")]
		public void WhenIClickOnTheTraingleNextToProductInformation(string expandCollapse)
		{
			Report.Info("Clicking on Triangle next to Product Information to " + expandCollapse + " the section");
			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.ClickArrowNextToProductInformation(expandCollapse == "expand"), "Failed to click the traiangle next to Product Information to " + expandCollapse, "Successfully clicked the triangle next to Product Information to " + expandCollapse);
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"the (Product Information|Alerts|Announcements) dialog should be (visible|hidden)")]
		public void ThenProductInformationDialogShouldBe(string dialog, string visibility)
		{
			try
			{
				Report.Info("Checking if " + dialog + " dialog is visible");
				var selHomepage = new Homepage();
				bool showing = false;
				switch (dialog)
				{
					case ("Product Information"):
						showing = selHomepage.ProductInformationSectionVisible();
						break;
					case ("Alerts"):
						showing = selHomepage.AlertsSectionVisible();
						break;
					case ("Announcements"):
						showing = selHomepage.AnnouncementsSectionVisible();
						break;
				}

				Report.IsTrue((visibility == "visible") == showing,
					dialog + " dialog was not " + visibility + "!",
					dialog + " dialog was " + visibility + ", as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I (should|should not) see a Pie Chart and Legend under Product Information")]
		public void ThenIShouldSeeAPieChartAndLegend(string shouldornot)
		{
			bool expected = shouldornot == "should";
			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.PieChartShowingInProductInformation() == expected, "Pie Chart " + (expected ? "was not" : "was") + " showing!", "Pie Chart " + (expected ? "was" : "was not") + " showing, as expected!");
			Report.IsTrue(selHomepage.PieChartLegendShowingInProductInformation() == expected, "Pie Chart legend " + (expected ? "was not" : "was") + " not showing!", "Pie Chart legend " + (expected ? "was" : "was not") + " showing, as expected!");
		}

		[StepDefinition(@"I should see the following states in the Legend:")]
		public void ThenIShouldSeeTheFollowingStatesInTheLegend(Table table)
		{
			try
			{
				Report.Info("Checking contents of Pie Chart Legend");
				var selHomepage = new Homepage();
				foreach (TableRow row in table.Rows)
				{
					Report.IsTrue(selHomepage.EntryShowingInPieChartLegend(row["State"], row["Colour"]), "Legend entry was not showing correctly!", "Entry was showing correctly in the legend!");
				}
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I see notifications in the (Alerts|Announcement) Panel")]
		public void GivenISeeNotificationsInThePanel(string panel)
		{
			try
			{
				Report.Info("Checking that notifications exist in the " + panel + " Panel");
				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.NotificationsExistInPanel(panel), "No notifications were found in " + panel + " Panel!", "Notifications were found in the " + panel + " Panel!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"clicking on the top (Alert|Announcement) should direct me to the My Messages page")]
		public void ThenClickingOnTheTopShouldDirectMeToTheMyMessagesPage(string panel)
		{
			try
			{
				Report.Info("Clicking on the top Alert");
				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.ClickOnFirst(panel), "Could not click on the top " + panel.ToLower() + "!", "Clicked on the top " + panel.ToLower() + " successfully!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();

				// ===== NEED TO KNOW WHERE THIS GOES BEFORE DOING THE NEXT PART ===== //
				Report.Warning("Functionality does not work - change this when it does!");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that I am taken to the My Messages (Alerts|Announcements) page")]
		public void ThenIConfirmThatIAmTakenToTheMyMessagesAlertsPage(string page)
		{
			try
			{
				// ===== NEED TO KNOW WHERE THIS GOES BEFORE DOING THE NEXT PART ===== //
				Report.Warning("Functionality does not work - change this when it does!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I navigate to the home page")]
		public void ThenINavigateToTheHomePage()
		{
			try
			{
				Report.Info("Navigating to the Home Page");
				var selNav = new NavigationBar();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(selNav.Click_Icon("Home"), "Failed to click the home icon!", "Successfully clicked the Home icon!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}

		}

		[StepDefinition(@"I click the Home navigation icon and (accept|dismiss) the alert popup")]
		public void ThenINavigateToTheHomePage(string alertAction)
		{
			try
			{
				Report.Info("Navigating to the Home Page");
				var selNav = new NavigationBar();
				Report.IsTrue(selNav.Click_Icon("Home"), "Failed to click the home icon!", "Successfully clicked the Home icon!", false, false);
				// Screenshot throws exception while an alert is open - selenium utils needs updating
				//Report.Screenshot();
				SeleniumBrowser.Alert.WaitForAlert(5);
				if (alertAction == "accept")
				{
					Report.Info("Accepting the pop up alert");
					SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				}

				if (alertAction == "dismiss")
				{
					Report.Info("Dismissing the pop up alert");
					SeleniumBrowser.WebBrowser.SwitchTo().Alert().Dismiss();
				}
				GeneralUtilities.Wait_for_load_finish();
				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.WaitForContainerToBeVisible(),
					"Homepage did not load after clicking the Home icon!",
					"Homepage successfully loaded after clicking the home icon");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Home navigation icon")]
		public void ClickTheHomeNavigationIcon()
		{
			try
			{
				Report.Info("Navigating to the Home Page");
				var selNav = new NavigationBar();
				Report.IsTrue(selNav.Click_Icon("Home"), "Failed to click the home icon!", "Successfully clicked the Home icon!");
				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.WaitForContainerToBeVisible(),
					"Homepage did not load after clicking the Home icon!",
					"Homepage successfully loaded after clicking the home icon");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
			
		}

		[StepDefinition(@"I should see the following filter options below My Products")]
		public void GivenIShouldSeeTheFollowingFilterOptionsBelowMyProducts(Table table)
		{
			try
			{
				Report.Info("Checking 'My Products' Filter Options");
				var selProdGrid = new ProductsGrid();
				foreach (TableRow row in table.Rows)
				{
					Report.IsTrue(selProdGrid.FilterOptionShowingCorrectly(row["Options"], row["Colour"]), "Filter option: '" + row["Options"] + "' was not showing correctly!", "Filter option: '" + row["Options"] + "' was showing correctly!");
				}

				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click More below the (Alerts|Announcements) Panel")]
		public void ThenIClickBelowTheAlertsPanel(string panel)
		{
			try
			{
				Report.Info("Clicking More below the " + panel + " Panel");
				var selHome = new Homepage();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(selHome.ClickMoreForPanel(panel), "Failed to click 'More' below the " + panel + " panel!", "Successfully clicked 'More' below the " + panel + " panel!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I (expand|collapse) the Navigation Menu")]
		public void ThenIClickTheNavigationMenuIcon(string expand)
		{
			try
			{
				Report.Info("Attempting to click the Navigation Menu Icon");
				var selNav = new NavigationBar();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(selNav.NavigationIconClick(expand == "expand"), "Failed to " + expand + " the Navigation Menu Icon!", "Successfully " + (expand == "expand" ? "expanded" : "collapsed") + " the Navigation Menu Icon!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the Navigation Menu should be (expanded|collapsed)")]
		public void NavigationMenuExpandedCollapsed(string expanded)
		{
			Report.IsTrue(new NavigationBar().NavigationMenuExpanded() == (expanded == "expanded"), "Navigation bar was not " + expanded + ", when expected!", "Navigation bar was " + expanded + ", as expected!");
		}

		[StepDefinition(@"the following (icons|icons and labels) should be found in the (navigation bar)")]

		public void TheFollowingAreShowingInThe(string lookingfor, string area, TechTalk.SpecFlow.Table expected)
		{
			foreach (TableRow row in expected.Rows)
			{
				switch (area)
				{
					case ("navigation bar"):
						{
							Report.IsTrue(new NavigationBar().ItemShowingInNavigationPanel(row["Item"], lookingfor != "icons and labels"),
								row["Item"] + " was not found in the Navigation Bar!",
								row["Item"] + " was successfully found in the Navigation Bar!", false, false);
							break;
						}
				}
			}
			Report.Screenshot();
		}

		[StepDefinition(@"the navigation labels should be hidden")]
		public void NavigationLabelsShouldBeHidden()
		{
			Report.IsTrue(new NavigationBar().AllNavigationLabelsAreHidden(),
				"The navigation labels (Home, Register New Product..) were not hidden!",
				"The navigation labels (Home, Register New Product..) were hidden as expected");
		}

		[StepDefinition(@"I click the User Icon")]
		public void ThenIClickTheUserIcon()
		{
			Report.StartStep(ReportSettings.StepCounter + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				Report.Info("Clicking the User Icon");
				var selTopHeader = new TopMenuBar();
				selTopHeader.ClickOnUserTopRight();
				Report.Success("Clicked on the User Icon!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on (My Account|Sign Out)")]
		[StepDefinition(@"I navigate to (My Account)")]
		public void ThenIClickOnUserItem(string userItem)
		{
			Report.IsTrue(userItem == "My Account" ? new TopMenuBar().ClickMyAccount() : new TopMenuBar().ClickSignOut(),
				"Failed to click on user item: " + userItem,
				"Clicked on user item " + userItem + "!");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"there should be products available in the Products Grid")]
		public void ThenThereShouldBeProductsAvailableInTheProductsTable()
		{
			Report.IsTrue(new ProductsGrid().ProductsPresent(), "Products were not present in the grid!", "There were products present in the grid, as expected!");
		}

		[StepDefinition(@"I click on the Notification Icon")]
		public void GivenIClickOnTheNotificationIcon()
		{
			Report.StartStep(ReportSettings.StepCounter + " - Click on Notification Icon");
			try
			{
				Report.Info("Clicking on Notification Icon");
				var selTopMenuBar = new TopMenuBar();
				selTopMenuBar.ClickNotificationIcon();
				Report.Success("Successfully clicked on the Notification Icon!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the Notification page should appear")]
		public void ThenTheNotificationPageShouldAppear()
		{
			Report.StartStep(ReportSettings.StepCounter + " - Notification Page Should Appear");
			try
			{
				Report.Info("Checking that the Notification Page appears");
				Report.Failure("Notification screen not showing/developed - so failing the step!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that the (.*) page is loaded")]
		public void ThenConfirmThatYouAreTakenToTheSpecifiedPage(string pageTitle)
		{
			switch (pageTitle)
			{
				case "UL Solution Center":
					var selUlSolution = new UlSolutionCenter();
					Report.IsTrue(selUlSolution.Wait_for_load(),
						"The UL Solutions Center page did not load!",
						"The UL Solutions Center page loaded as expected");
					break;
				default:
					Report.Info("A valid page navigation was not specified");
					return;
			}
		}

		//[Then(@"Confirm that freshdesk opens in another tab")]
		//public void ThenConfirmThatFreshdeskOpensInAnotherTab()
		//{
		//	Report.StartStep(ReportSettings.StepCounter + " - Confirm that freshdesk opens in another tab");
		//	Delay.Seconds(5);
		//	try
		//	{
		//		string freshdeskUrl = @"https://wercsmarttest.freshdesk.com/support/solutions";
		//		List<string> listOfTabs = SeleniumBrowser.GetTabURLs();
		//		Report.IsTrue(listOfTabs.Contains(freshdeskUrl),
		//			"Fresh desk url: " + freshdeskUrl + " was not found. Tabs open: " + string.Join(",", listOfTabs),
		//			" As expected, tab is open with url: " + freshdeskUrl);
		//		Report.Screenshot();
		//		Report.Info("Closing Freshdesk");
		//		SeleniumBrowser.CloseTabWithURL(freshdeskUrl);
		//		Delay.Seconds(3);

		//	}
		//	catch (Exception ex)
		//	{
		//		Report.Failure(ex.Message);
		//		throw;
		//	}
		//}

		[StepDefinition(@"Confirm that freshdesk opens in another tab")]
		public void ConfirmThatFreshdeskOpensInAnotherTab()
		{
			Report.StartStep(ReportSettings.StepCounter + " - Confirm that freshdesk opens in another tab");
			Delay.Seconds(5);
			if (TReVorSettings.SoftwareBranch == "Development")
			{
				string freshdeskUrl = @"https://wercsmarttest.freshdesk.com/support/solutions";
				List<string> listOfTabs = SeleniumBrowser.GetTabURLs();
				Report.IsTrue(listOfTabs.Contains(freshdeskUrl),
					"Fresh desk url: " + freshdeskUrl + " was not found. Tabs open: " + string.Join(",", listOfTabs),
					" As expected, tab is open with url: " + freshdeskUrl);
				Report.Screenshot();
				Report.Info("Closing Freshdesk");
				SeleniumBrowser.CloseTabWithURL(freshdeskUrl);
				Delay.Seconds(3);
			}
			if (TReVorSettings.SoftwareBranch == "Staging")
			{
				string freshdeskUrl = @"https://wercsmarttest.freshdesk.com/support/solutions";
				List<string> listOfTabs = SeleniumBrowser.GetTabURLs();
				Report.IsTrue(listOfTabs.Contains(freshdeskUrl),
					"Fresh desk url: " + freshdeskUrl + " was not found. Tabs open: " + string.Join(",", listOfTabs),
					" As expected, tab is open with url: " + freshdeskUrl);
				Report.Screenshot();
				Report.Info("Closing Freshdesk");
				SeleniumBrowser.CloseTabWithURL(freshdeskUrl);
				Delay.Seconds(3);
			}
			if (TReVorSettings.SoftwareBranch == "Production")
			{
				string freshdeskUrl = @"https://wercsmart.freshdesk.com/en/support/solutions";
				List<string> listOfTabs = SeleniumBrowser.GetTabURLs();
				Report.IsTrue(listOfTabs.Contains(freshdeskUrl),
					"Fresh desk url: " + freshdeskUrl + " was not found. Tabs open: " + string.Join(",", listOfTabs),
					" As expected, tab is open with url: " + freshdeskUrl);
				Report.Screenshot();
				Report.Info("Closing Freshdesk");
				SeleniumBrowser.CloseTabWithURL(freshdeskUrl);
				Delay.Seconds(3);
			}
			if (TReVorSettings.SoftwareBranch == "Local Production")
			{
				string freshdeskUrl = @"https://wercsmarttest.freshdesk.com/support/solutions";
				List<string> listOfTabs = SeleniumBrowser.GetTabURLs();
				Report.IsTrue(listOfTabs.Contains(freshdeskUrl),
					"Fresh desk url: " + freshdeskUrl + " was not found. Tabs open: " + string.Join(",", listOfTabs),
					" As expected, tab is open with url: " + freshdeskUrl);
				Report.Screenshot();
				Report.Info("Closing Freshdesk");
				SeleniumBrowser.CloseTabWithURL(freshdeskUrl);
				Delay.Seconds(3);
			}
		}

		[StepDefinition(@"I should see the empty shopping cart pop up")]
		public void ThenIShouldSeeTheEmptyShoppingCartPopUp()
		{
			var selEmptyCart = new EmptyCart();
			Report.IsTrue(selEmptyCart.Exists, "The shopping cart pop up is not showing as expected.",
				"As expected, the shopping cart popup is showing.");
		}

		[StepDefinition(@"I close the Empty Cart pop up")]
		public void GivenIClickOnCloseInTheShoppingCart()
		{
			var selEmptyCart = new EmptyCart();
			Report.IsTrue(selEmptyCart.ClickClose() && GeneralUtilities.Wait_for_load_finish(),
				"Failed to close the Empty Cart pop up!",
				"Successfully closed the Empty Cart pop up");
		}

		[StepDefinition(@"the Empty Cart pop up message reads: (.*)")]
		public void EmptyCartPopUpText(string value)
		{
			string actualMessage = new EmptyCart().BodyMessage();
			Report.IsTrue(actualMessage == value,
				"The Empty Cart pop up message text did not match the expected value. Expected: '" + value + "'. Actual: '" + actualMessage + "'",
				"The Emoty Cart pop up message text matched the expected value: '" + value + "'");
		}

		//Adding My Products|Add Product icon in Navigation page due to the new changes in Integration environment
		[When(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		[StepDefinition(@"I click the (Home|My Products|Add Product|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		[StepDefinition(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		[StepDefinition(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		public void ClickItemInNavigationPanel(string item)
		{
			try
			{
				Report.Info("Selecting " + item + " in the Navigation Pane");
				var selNav = new NavigationBar();
				selNav.Click_Icon(item);
				Report.Success("Successfully clicked item " + item);
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) link in the expanded navigation side menu")]
		public void ClickItemInNavigationSideMenu(string item)
		{
			Report.Info("Selecting " + item + " in the Navigation Pane");
			var selNav = new NavigationBar();
			Report.IsTrue(selNav.Click_ExpandedMenuLink(item),
				$"Failed to click the {item} link in the expanded navigation menu!",
				$"Successfully clicked the {item} link in the expanded navigation menu");
		}


		[StepDefinition(@"I click the (Home|Register New Product|Prescription Pharmaceutical|My Messages|Retail Partners|My Reports|Supplier Reports|UL Solution Center|Shopping Cart|Support|ULSC - Data Management) icon in the QuickLinks Pane")]
		public void ClickItemInQuickLinks(string item)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Selecting " + item + " in the Navigation Pane");
			try
			{
				Report.Info("Selecting " + item + " in the Navigation Pane");
				var selHomePageNavBar = new NavigationBar();
				Report.IsTrue(selHomePageNavBar.Click_Icon(item), "Failed to click item: '" + item + "'!", "Successfully clicked item: '" + item + "'!", showSuccessScreenshot: false);
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Clicking the close button on cart is empty popup
		/// </summary>
		[StepDefinition(@"I click on the close button on Cart is Empty")]
		public void ClickCloseOnCartisEmpty()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I click the close button");
			var selCartEmpty = new CartIsEmptyDialog();
			selCartEmpty.ClickClose();

			Report.Success("close button clicked! on the homepage");
		}

		/// <summary>
		/// This is to verify the title of the page
		/// </summary>
		/// <param name="headerExpected"></param>
		[StepDefinition(@"I should see the header: (.*) on the Cart is Empty window")]
		public void CorrectHeaderShowing(string headerExpected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Cart is Empty window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Cart is Empty window appears");
				var selCartEmpty = new CartIsEmptyDialog();
				string showing = selCartEmpty.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Cart is Empty header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Cart is Empty header was showing '" + headerExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the WERCSmart logo")]
		public void ClickWercSmartLogo()
		{
			Report.IsTrue(new TopMenuBar().ClickWercsSmartLogo(),
				"Failed to click the WERCSmart logo",
				"Successfully clicked the WERCSmart logo");
		}

		[StepDefinition(@"I should see the following states in the following order in the Legend:")]
		public void ThenIShouldSeeTheFollowingStatesInTheFollowingOrderInTheLegend(Table table)
		{
			try
			{
				Report.Info("Checking order of states in the Pie Chart Legend");
				var selHomepage = new Homepage();
				List<string> ListOfStates = selHomepage.PieChartLegendItems();
				var ExpectedStates = table.Rows.Select(x => x["State"]).ToList();
				int i = 0;
				foreach (string expectedState in ExpectedStates)
				{
					Report.IsTrue(expectedState == ListOfStates[i],
						"Expected: " + expectedState + " but got: " + ListOfStates[i],
						"As expected, " + expectedState + " is showing in the right order");
					i++;
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following filters in the following order under My products:")]
		public void GivenIShouldSeeTheFollowingFiltersInTheFollowingOrderUnderMyProducts(Table table)
		{
			try
			{
				Report.Info("Checking order of states in the Pie Chart Legend");
				var selProductsGrid = new ProductsGrid();
				List<string> ListOfFilters = selProductsGrid.GetAllFilters();
				var ExpectedFilters = table.Rows.Select(x => x["Filter"]).ToList();
				int i = 0;
				foreach (string expectedFilter in ExpectedFilters)
				{
					Report.IsTrue(expectedFilter == ListOfFilters[i],
						"Expected: " + expectedFilter + " but got: " + ListOfFilters[i],
						"As expected, " + expectedFilter + " is showing in the right order");
					i++;
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the announcements area I should see my saved messages")]
		public void ThenInTheAnnouncementsAreaIShouldSeeMySavedMessages()
		{
			var myHomepage = new Homepage();
			var ListOfMessages = (List<Message>)Context.GetFromContext("Messages");
			List<string> MessagesOnHomepage = myHomepage.GetAnnouncements();
			foreach (string thisMessage in ListOfMessages.Select(x => x.MessageBody).ToList())
			{
				int counter = 0;
				bool found = false;
				Report.Info("Looking for message: " + thisMessage + " in announcements");
				// The refresh from SHA to WS can take several minutes so do a loop. waits 25 mins, 10s refresh
				while (counter < 150 && !found)
				{
					if (MessagesOnHomepage.Contains(thisMessage))
					{
						found = true;
					}
					else
					{
						Delay.Seconds(10);
						counter++;
						SeleniumBrowser.WebBrowser.Navigate().Refresh();
						GeneralUtilities.Wait_for_load_finish();
						MessagesOnHomepage = myHomepage.GetAnnouncements();
					}
				}
				Report.IsTrue(found, $@"""{thisMessage}"" was not displayed in Announcements after waiting for 30 minutes!",
					thisMessage + $@"After waiting {counter * 10} seconds, the message ""{thisMessage}"" was displayed in Announcements as expected.");
			}
			int ActualMessageCount = myHomepage.GetAnnouncementCount();
			Report.IsTrue(ActualMessageCount == MessagesOnHomepage.Count,
				"Listed count is: " + ActualMessageCount.ToString() + " but number of messages is: " +
				MessagesOnHomepage.Count.ToString(),
				"As expected, message count is showing as: " + ActualMessageCount.ToString());
		}

		[StepDefinition(@"I click on the Live Help button on the upper right")]
		public void GivenIClickOnTheLiveHelpButtonOnTheUpperRight()
		{
			var myTopMenuBar = new TopMenuBar();
			Report.IsTrue(myTopMenuBar.ClickLiveHelp(), "Failed to click live help", "Clicked live help");
		}

		[StepDefinition(@"I should see the Live Help dialog")]
		public void ThenIShouldSeeTheLiveHelpDialog()
		{
			Report.IsTrue(new LiveHelp().Wait_for_load(), "Live Help dialog is not showing",
				"Live Help dialog is showing as expected");
		}

		[StepDefinition(@"In the Live Help dialog I should see a small icon with three lines in the upper left hand corner")]
		public void ThenIShouldSeeThreeLinesIcon()
		{
			Report.IsTrue(new LiveHelp().VerifyThreeLinesIcon(), "Three lines icon is not present in the upper left hand corner",
				"Three lines icon is present in the upper left hand corner");
		}

		[StepDefinition(@"In the Live Help dialog I should see an x in the upper right hand corner")]
		public void ThenIShouldSeeAnXInTheUpperRightHandCorner()
		{
			Report.IsTrue(new LiveHelp().VerifyX(), "X is not present in the upper right hand corner",
				"X is present in the upper right hand corner");
		}

		[StepDefinition(@"In the Live Help dialog I should see the text 'Inbox' at the top of the chat window")]
		public void ThenIShouldSeeInbox()
		{
			Report.IsTrue(new LiveHelp().VerifyInboxText(), "Inbox text is not present", "Inbox text is present");
		}

		[StepDefinition(@"In the Live Help dialog I should see the description text: (.*) at the top of the chat window")]
		public void ThenIShouldSeeDescriptionText(string expectedText)
		{
			Report.IsTrue(new LiveHelp().VerifyDescText(expectedText), "Description text is not present", "Description text is present");
		}

		[StepDefinition(@"In the Live Help dialog I should see the following text in the message area: (.*)")]
		public void ThenIShouldSeeTheFollowingTextInTheMessageArea(string message)
		{
			Report.IsTrue(new LiveHelp().VerifyMessageText(message), "Text is not present in the message area: " + message,
				"Text is present in the message area: " + message);
		}

		[StepDefinition(@"In the Live Help dialog I should see the following text in the lower part of the chat window: (.*)")]
		public void ThenIShouldSeeTheFollowingTextInTheLowerPartOfTheChatWindow(string text)
		{
			Report.IsTrue(new LiveHelp().VerifyLowerText(text), "Text '" + text + "' does not appear in the lower part of the message area",
				"Text appears correctly in the lower part of the chat window: " + text);
		}

		[StepDefinition(@"In the Live Help dialog I should see the following placeholder text in the text entry field: (.*)")]
		public void ThenIShouldSeeTheFollowingPlaceholder(string text)
		{
			Report.IsTrue(new LiveHelp().VerifyPlaceholder(text), "Placeholder '" + text + "' does not appear in the text entry area",
				"Placeholder appears correctly in the text entry area: " + text);
		}

		[StepDefinition(@"In the Live Help dialog I should see the (.*) icon in the lower right hand corner")]
		public void ThenIShouldSeeTheIconInTheLowerRightHandCorner(string icon)
		{
			Report.IsTrue(new LiveHelp().VerifyIcon(icon), icon + " icon not found in the lower right hand corner",
				icon + " icon found in the lower right hand corner");
		}

		[StepDefinition(@"In the Live Help dialog I click on the x to close")]
		public void GivenInTheLiveHelpDialogIClickOnTheXToClose()
		{
			Report.IsTrue(new LiveHelp().ClickCloseX(), "Failed to click x to close", "Clicked x to close");
		}

		[StepDefinition(@"the hover over text is as expected for the following navigation icons")]
		public void HoverOverIconsAndConfirmTheTitleAppears(Table icons)
		{
			foreach (TableRow row in icons.Rows)
			{
				string icon = row["Icon"];
				string text = row["Text"];
				Report.IsTrue(new NavigationBar().IconTextDisplayedOnHover(icon, text),
					"Title text: " + text + " did not appear on hover for icon: " + icon,
					"Title text: " + text + " appeared on hover for icon: " + icon + " as expected", false, false);
			}
		}

		[StepDefinition(@"I save the list of Product IDs displayed on the page as: (.*)")]
		public void SaveListOfIDsDisplayedOnThePageAs(string savedAs)
		{
			var selProductsGrid = new ProductsGrid();
			List<string> prodIDs = selProductsGrid.AllIDsInGrid();
			Report.Info("Saving a total of: " + prodIDs.Count + " to context saved as: " + savedAs);
			Context.AddToContext(savedAs, prodIDs);
			if (prodIDs.Count()==0)
			{
				Report.Failure("There was no products IDs found to be displayed");				
				
			}
			
		}

		[StepDefinition(@"If there are no Products in the status 'Sending to Retailers' I create one with SHA account: (.*)")]
		public void IfNoProductsInSendingToRetailersCreateProduct(string shaAcc)
		{
			var selProductsGrid = new ProductsGrid();
			List<string> prodIDs = selProductsGrid.AllIDsInGrid();			
			if (prodIDs.Count() == 0)
			{
				Report.Info("There was no products IDs found to be displayed");
				new Steps_ProductSetup().GivenICreateReleasedForDistProductUsingTestCase75335UsingShaAcc(shaAcc, "ReleasedProd1");
				// Then return to grid and filter by status...
				new GlobalSteps().NavigateToLandingPage();
				new GlobalSteps().LoginToWERCSmartAdmin("WERCs Product Account");
				new GlobalSteps().ThenTheHomeScreenShouldLoad();
				new StepsProductGrid().WhenIFilterTheProductsByNotYetSubmitted("Sending to Retailers");
				var selProductsGrid2 = new ProductsGrid();
				List<string> prodIDsbackup = selProductsGrid2.AllIDsInGrid();				
				if (prodIDsbackup.Count() == 0)
				{
					Report.Failure("There was still no product IDs found to be displayed");

				}
				else
				{
					Report.Success("There was at least one product id found in the grid.");
				}
			}
			else
			{
				Report.Info($"Count was not 0... No need to create a product, moving on...");				

			}
		}


		[StepDefinition(@"I navigate to the WERCSmart site")]
		public void INavigateToWERCSmart()
		{
			Report.Info("Navigating to the WERCSmart Landing Page");
			var thisGlobalSteps = new GlobalSteps();
			thisGlobalSteps.NavigateToLandingPage();
		}
		[StepDefinition(@"I click the Home navigation icon and an alert appears")]
		public void ThenIClickTheHomeNavigationIconAndAlertAppears()
		{

			Report.Info("Navigating to the Home Page");
			var selNav = new NavigationBar();
			Report.IsTrue(selNav.Click_Icon("Home"), "Failed to click the home icon!", "Successfully clicked the Home icon!", false, false);
			SeleniumBrowser.Alert.WaitForAlert(5);

		}

		[StepDefinition(@"I confirm the Inactivity popup is displayed after waiting (.*) minutes accurate to the nearest (.*) minutes and no screenshot is taken")]
		public void ConfirmTheInactivityPopupDisplayedAfterWaitNoScreenShot(int expectedWait, int marginOfError)
		{
			// check if popup wasn't displayed after 'expected wait + margin' (test upper limit)
			if (!new InactivityPopup().WaitUntilDisplayed((expectedWait * 60) + (marginOfError * 60), out int actualWait))
			{
				Report.Failure($"The Inactivity popup did not load after {expectedWait + marginOfError} minutes!");

				return;
			}
			// check if pop up was displayed before 'expected wait - margin' (test lower limit)
			Report.IsTrue(actualWait >= (expectedWait * 60) - (marginOfError * 60),
				"The Inactivity popup did not load within the expected time frame! It was loaded after " + actualWait / 60 + " minutes",
				"The Inactivity popup loaded within the expected time frame. It was loaded after: " + actualWait / 60 + " minutes", false, false);
		}
		[StepDefinition(@"Click (Yes|No) on the inactivity popup and no screenshot is taken")]
		public void GivenClickOnInactivityPopupNoScreenshot(string button)
		{
			Report.Info("Clicking " + button + " on inactivity popup");
			var selInactivityPopup = new InactivityPopup();
			bool clicked = false;
			switch (button)
			{
				case ("Yes"):
					clicked = selInactivityPopup.ClickYes();
					break;
				case ("No"):
					clicked = selInactivityPopup.ClickNo();
					break;
				default:
					Report.Error("Button parameter must be 'Yes' or 'No'!");
					return;
			}
			Report.IsTrue(clicked, $"Failed to click the '{button}' button", $"Successfully clicked the '{button}' button", false, false);
		}

		[StepDefinition(@"Click (Yes|No) on the inactivity popup but dont take a screenshot")]
		public void GivenClickOnInactivityPopupNoScreenShot(string button)
		{
			Report.Info("Clicking " + button + " on inactivity popup");
			var selInactivityPopup = new InactivityPopup();
			bool clicked = false;
			switch (button)
			{
				case ("Yes"):
					clicked = selInactivityPopup.ClickYes();
					break;
				case ("No"):
					clicked = selInactivityPopup.ClickNo();
					break;
				default:
					Report.Error("Button parameter must be 'Yes' or 'No'!");
					return;
			}
			if (clicked)
			{
				Report.Success($"Successfully clicked the '{button}' button");
			}
			if (!clicked)
			{
				Report.Failure($"Failed to click the '{button}' button", false);
			}

		}

		[StepDefinition(@"I confirm the Inactivity pop is closed but dont take a screenshot")]
		public void ConfirmInactivityPopupIsClosedNoScreenShot()
		{
			Report.IsTrue(new InactivityPopup().WaitForContainerToBeInvisible(), "The Inactivity popup was not closed!", "The Inactivity popup was closed.", false, false);
		}

		[StepDefinition(@"I confirm the Inactivity pop is open but dont take a screenshot")]
		public void ConfirmInactivityPopupIsOpendNoScreenShot()
		{
			Report.IsTrue(new InactivityPopup().WaitForContainerToBeVisible(), "The Inactivity popup was not open.", "The Inactivity popup was open", false, false);
		}

		[StepDefinition(@"I take a ScreenShot")]
		public void ITakeAScreenShot()
		{
			Report.Info("I take a screenshot");
			Report.Screenshot();
		}

		[StepDefinition(@"I Check the Alert with text: (.*) has the ID: (.*)")]
		public void ICheckAlertWithTextXHasIDY(string alertText, string expxectedAlertID)
		{
			try
			{
				Report.Info("Finding Alert with Text: " + alertText);
				var selHomepage = new Homepage();
				string actualID = new Homepage().GetAllAlertsAndGetAlertWithTextXAndReturnID(alertText);
				Report.Info("Actual AlertID: " + actualID);
				Report.Info("Expected AlertID: " + expxectedAlertID);
				Report.IsTrue(actualID == expxectedAlertID, "The Alert ID was not as expected!", "The Alert ID was as expected!");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the 'Resolve' button that is associated to the AGHS alert in the 'Alerts' window")]
		public void GivenIClickTheButtonThatIsAssociatedToTheAGHSAlertInTheWindow()
		{
			Homepage HomePageObject = new Homepage();
			Report.IsTrue(HomePageObject.ClickResolveButton(), "Failed to click 'Resolve' button", "Successfully clicked 'Resolve' button");
		}

		[Then(@"I should see the button: (.*) for alert: (.*)")]
		public void ThenIShouldSeeTheButtonForAlert(string button, string alert)
		{
			var Alert = new Alerts(alert);
			Report.IsTrue(Alert.AlertsButtonIsDisplayed(button, alert), $"Failed to find button {button} for alert {alert}", $"Successfully found button {button} for alert {alert}");


		}


		[StepDefinition(@"If The Data Consent Requests modal is showing, navigate to the Retailer Partners page and add required tiers")]
		public void IfDataConsentRequestsModalIsShowingAddRequiredTiers()
		{
			Report.Info("I wait for the Data Consent Requests Modal to appear");
			if(new ModalDialog().WaitForContainerToBeVisible(5))
			{
				Report.Info("A modal was found checking the modal is the Data Consent Requests modal");
				if(new ModalDialog().GetTitle().ToLower()=="data consent requests")
				{
					Report.Info("Attempting to click the button with text: 'GO TO MY RETAILERS");
					new ModalDialog().ClickButton("GO TO MY RETAILERS");
					Delay.Seconds(15);
					new StepsRetailPartners().GivenIfISeeTheRetailPartnersPageISetAllDataConsentTiersToTrueForAllRetailersInTheTopSection();
					
				}
				else
				{
					Report.Info("The modal found was not the data consent requests modal");
					return;
				}
			}
			else
			{
				Report.Info("No modal was found, continuing as normal");
				return;
			}
		}

		[StepDefinition(@"I confirm ID/Product Name column displays the product name wrapped within the area of the column")]
		public void ThenIConfirmIDProductNameColumnDisplaysTheProductNameWrappedWithinTheAreaOfTheColumn()
		{
			var homePage = new Homepage();
			if (Report.IsTrue(homePage.ProdNameExists(), "Failed to find Product Name field", "Successfully found Product Name field"))
			{
				Report.IsTrue(homePage.ProductNameWrapped(), "Failed to confirm Product Name is wrapped within the area of the column ID/Product Name", "Successfully confirmed Product Name is wrapped within the area of the column ID/Product Name");
			}
		}

	}
}

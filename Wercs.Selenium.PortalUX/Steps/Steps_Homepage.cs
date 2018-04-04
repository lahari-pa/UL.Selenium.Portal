using System;
using System.Collections.Generic;
using System.Reflection;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;

using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Homepage")]
	class StepsHomepage
	{
		[StepDefinition(@"the WERCSmart homepage should load")]
		[StepDefinition(@"the WERCSmart homepage should be loaded")]
		public void ThenTheWercSmartHomepageShouldLoad()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				Report.Info("Making sure that the WERCSmart homepage is loaded");
				var selHomepage = new Homepage();


				Report.IsTrue(selHomepage.Wait_for_load(), "WERCSmart Homepage failed to load!", "WERCSmart homepage loaded successfully!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I stay on the homepage with no activity until the inactivity popup appears")]
		public void ThenStayOnTheHomepageWithNoActivityForMinutes()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Stay on the homepage with no activity until the inactivity popup appears");
			try
			{
				// In order to do this we have to keep the SeleniumWebDriver Busy - cannot let it be idle for 10 minutes otherwise we will hit an error when we attempt to do something!

				Report.Info("Staying on the homepage with no activity until the inactivity popup appears");
				var selInactivityPopup = new InactivityPopup();

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

		[StepDefinition(@"Click (Yes|No) on the inactivity popup")]
		public void GivenClickOnInactivityPopup(string button)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click " + button + " on inactivity popup");
			try
			{
				Report.Info("Clicking " + button + " on inactivity popup");
				var selInactivityPopup = new InactivityPopup();

				switch (button)
				{
					case ("Yes"):
						selInactivityPopup.ClickYes();
						break;
					default:
						selInactivityPopup.ClickNo();
						break;
				}

				Report.Success(button + " was clicked successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



		[StepDefinition(@"I should see the (.*) in the (header bar|user dropdown|navigation bar|main window|home page header|products grid)")]
		[StepDefinition(@"I should see (.*) in the (header bar|user dropdown|navigation bar|main window|home page header|products grid)")]
		public void ThenIShouldSeeTheUlwercSmartLogoInTheHeaderBar(string item, string area)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - " + item + " should be showing in the " + area);
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
								case ("subheading your products"):
									Report.IsTrue(selProdGrid.HeaderShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
									break;
							}
							break;
						}
				}
				Report.Screenshot();
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking on Triangle next to Product Information");
			try
			{
				Report.Info("Clicking on Triangle next to Product Information to " + expandCollapse + " the section");
				var selHomepage = new Homepage();
				selHomepage.ClickArrowNextToProductInformation(expandCollapse == "expand");
				GeneralUtilities.Wait_for_load_finish();
				Delay.Seconds(Delay.SpeedFactor * 2);
				Report.Screenshot();
				Report.Success("Triangle clicked successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the (Product Information|Alerts|Announcements) dialog should be (visible|hidden)")]
		public void ThenProductInformationDialogShouldBe(string dialog, string visibility)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking if " + dialog + " dialog is " + visibility);
			try
			{
				Report.Info("Checking if " + dialog + " dialog is visible");
				var selHomepage = new Homepage();
				var showing = false;
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

		[StepDefinition(@"I should see a Pie Chart and Legend under Product Information")]
		public void ThenIShouldSeeAPieChartAndLegend()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking if Pie Chart and Legend are visible");
			try
			{
				Report.Info("Checking if Pie Chart and Legend are visible");
				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.PieChartShowingInProductInformation(), "Pie Chart was not showing!", "Pie Chart was showing as expected!");
				Report.IsTrue(selHomepage.PieChartLegendShowingInProductInformation(), "Pie Chart legend was not showing!", "Pie Chart legend was showing as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following states in the Legend:")]
		public void ThenIShouldSeeTheFollowingStatesInTheLegend(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking contents of Pie Chart Legend");
			try
			{
				Report.Info("Checking contents of Pie Chart Legend");
				var selHomepage = new Homepage();
				foreach (var row in table.Rows)
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that notifications exist in the " + panel + " Panel");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Selecting top " + panel);
			try
			{
				Report.Info("Clicking on the top Alert");
				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.ClickOnFirst(panel), "Could not click on the top " + panel.ToLower() + "!", "Clicked on the top " + panel.ToLower() + " successfully!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();

				// ===== NEED TO KNOW WHERE THIS GOES BEFORE DOING THE NEXT PART ===== //
				Report.Warn("Functionality does not work - change this when it does!");

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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - My Messages " + page + " Page should load");
			try
			{
				// ===== NEED TO KNOW WHERE THIS GOES BEFORE DOING THE NEXT PART ===== //
				Report.Warn("Functionality does not work - change this when it does!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigating to the Home Page");
			try
			{
				Report.Info("Navigating to the Home Page");
				var selNav = new NavigationBar();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(selNav.Click_Icon("Home"), "Failed to click the home icon!", "Successfully clicked the Home icon!");
				Report.Screenshot();
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking 'My Products' Filter Options");
			try
			{
				Report.Info("Checking 'My Products' Filter Options");
				var selProdGrid = new ProductsGrid();
				foreach (var row in table.Rows)
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking More below the " + panel + " Panel");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - " + (expand == "expand" ? "Expand" : "Collapse") + " the Navigation Menu");
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

		[StepDefinition(@"the following (icons|icons and labels) should be found in the (header bar|user dropdown|navigation bar)")]

		public void TheFollowingAreShowingInThe(string lookingfor, string area, TechTalk.SpecFlow.Table expected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking correct elements are found in " + area);
			try
			{
				Report.Info("Checking that the correct elements are present in the " + area);
				bool iconsOnly = lookingfor != "icons and labels";
				foreach (var row in expected.Rows)
				{
					switch (area)
					{
						case ("navigation bar"):
							{
								var selNav = new NavigationBar();
								Report.IsTrue(selNav.ItemShowingInNavigationPanel(row["Item"], iconsOnly),
									row["Item"] + " was not found in the Navigation Bar!",
									row["Item"] + " was successfully found in the Navigation Bar!");
								break;
							}
					}
				}
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the User Icon")]
		public void ThenIClickTheUserIcon()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
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
		public void ThenIClickOnUserItem(string userItem)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking user item " + userItem);
			try
			{
				Report.Info("Clicking user item " + userItem);
				var selTopHeader = new TopMenuBar();
				switch (userItem)
				{
					case ("My Account"):
						selTopHeader.ClickMyAccount();
						break;
					case ("Sign Out"):
						selTopHeader.ClickSignOut();
						break;
				}

				GeneralUtilities.Wait_for_load_finish();
				Report.Success("Clicked on user item " + userItem + "!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"there should be products available in the Products Grid")]
		public void ThenThereShouldBeProductsAvailableInTheProductsTable()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Products Present In Products Grid");
			try
			{
				Report.Info("Checking that there are products available in the Products Grid");
				var selProdGrid = new ProductsGrid();
				Report.IsTrue(selProdGrid.ProductsPresent(), "Products were not present in the grid!", "There were products present in the grid, as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the Notification Icon")]
		public void GivenIClickOnTheNotificationIcon()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click on Notification Icon");
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
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Notification Page Should Appear");
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

	    [Then(@"Confirm that you are taken to the (.*) page")]
	    public void ThenConfirmThatYouAreTakenToTheSpecifiedPage(string pageTitle)
	    {
		    TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm that you are taken to the " + pageTitle + " page");
			Delay.Seconds(5);
		    try
		    {
			    switch (pageTitle)
			    {
				    case "UL Solution Center":
					    UlSolutionCenter ULSolution = new UlSolutionCenter();
					    Report.IsTrue(ULSolution.Exists, "UL Solutions page does not exist as expected.", "UL Solutions page exists as expected.");
					    break;
				    default:
					    break;
			    }
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
	    }

	    [Then(@"Confirm that freshdesk opens in another tab")]
	    public void ThenConfirmThatFreshdeskOpensInAnotherTab()
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm that freshdesk opens in another tab");
			Delay.Seconds(5);
		    try
		    {
			    string FreshdeskURL = @"https://wercsmarttest.freshdesk.com/support/solutions";
			    List<string> ListOfTabs = SeleniumBrowser.GetTabURLs();
			    Report.IsTrue(ListOfTabs.Contains(FreshdeskURL),
				    "Fresh desk url: " + FreshdeskURL + " was not found. Tabs open: " + string.Join(",", ListOfTabs),
				    " As expected, tab is open with url: " + FreshdeskURL);
				Report.Screenshot();
				Report.Info("Closing Freshdesk");
			    SeleniumBrowser.CloseTabWithURL(FreshdeskURL);
			    Delay.Seconds(3);

		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}

	    [Then(@"I should see the empty shopping cart pop up")]
	    public void ThenIShouldSeeTheEmptyShoppingCartPopUp()
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the empty shopping cart pop up");
		    Delay.Seconds(5);
		    try
		    {

			    ShoppingCart ThisShoppingCart = new ShoppingCart();
			    Report.IsTrue(ThisShoppingCart.Exists, "The shopping cart pop up is not showing as expected.",
				    "As expected, the shopping cart popup is showing.");
			    Report.Screenshot();
			    
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}

	    [Given(@"I click on Close in the shopping cart")]
	    public void GivenIClickOnCloseInTheShoppingCart()
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click on Close in the shopping cart");
		    Delay.Seconds(5);
		    try
		    {
			    ShoppingCart ThisShoppingCart = new ShoppingCart();
				// TODO: Does this function need re-including?
			    // ThisShoppingCart.ClickClose();
			    Delay.Seconds(2);

		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}

		[When(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		[Then(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		[Given(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		[StepDefinition(@"I click the (Home|Register New Product|My Messages|Retail Partners|UL Solution Center|Shopping Cart|Support) icon in the Navigation Pane")]
		public void ClickItemInNavigationPanel(string item)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Selecting " + item + " in the Navigation Pane");
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

		[StepDefinition(@"I click the (Home|Register New Product|My Messages|Retail Partners|Supplier Reports|UL Solution Center|Shopping Cart|Support|ULSC - Data Management) icon in the QuickLinks Pane")]
		public void ClickItemInQuickLinks(string item)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Selecting " + item + " in the Navigation Pane");
			try
			{
				Report.Info("Selecting " + item + " in the Navigation Pane");
				var selHomePageNavBar = new NavigationBar();
				Report.IsTrue(selHomePageNavBar.Click_Icon(item), "Failed to click item: '" + item + "'!", "Successfully clicked item: '" + item + "'!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the close button");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Cart is Empty window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Cart is Empty window appears");
				var selCartEmpty = new CartIsEmptyDialog();
				var showing = selCartEmpty.HeaderShowing();
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
	}
}

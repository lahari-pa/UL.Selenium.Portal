using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using SeleniumUtilities;

using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
    [Binding, Scope(Tag = "Homepage")]
    class Steps_Homepage
    {
        [StepDefinition(@"the WERCSmart homepage should load")]
        [StepDefinition(@"the WERCSmart homepage should be loaded")]
		public void ThenTheWERCSmartHomepageShouldLoad()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                Report.Info("Making sure that the WERCSmart homepage is loaded");
                var Sel_Homepage = new Homepage();
				

                Report.IsTrue(Sel_Homepage.Wait_for_load(),"WERCSmart Homepage failed to load!", "WERCSmart homepage loaded successfully!");
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
			    var Sel_InactivityPopup = new InactivityPopup();

				while (!Sel_InactivityPopup.IsVisible())
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
	    public void GivenClickOnInactivityPopup(string Button)
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click " + Button + " on inactivity popup");
		    try
		    {
			   Report.Info("Clicking " + Button + " on inactivity popup");
			    var Sel_InactivityPopup = new InactivityPopup();

			    switch (Button)
			    {
					case ("Yes"):
						Sel_InactivityPopup.ClickYes();
						break;
					default:
						Sel_InactivityPopup.ClickNo();
						break;
			    }

			    Report.Success(Button + " was clicked successfully!");
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
        public void ThenIShouldSeeTheULWERCSmartLogoInTheHeaderBar(string item, string area)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - " + item + " should be showing in the " + area);
            try
            {
                switch (area)
                {
                    case ("header bar"):
                    {
                        var Sel_TopMenuBar = new TopMenuBar();
                        switch (item.ToLower())
                        {
                            case ("user icon"):
                                Report.IsTrue(Sel_TopMenuBar.UserIconShowing(), item + " was not present in the " + area + "!",item + " was present in the " + area + ", as expected");
                                break;
                            case ("notification icon"):
                                Report.IsTrue(Sel_TopMenuBar.NotificationIconShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            case ("ul/wercsmart logo"):
                                Report.IsTrue(Sel_TopMenuBar.WERCSmartLogoShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                        }
                        break;
                    }
                    case ("user dropdown"):
                    {
                        var Sel_TopMenuBar = new TopMenuBar();
                        switch (item.ToLower())
                        {
                            case ("my account"):
                                Report.IsTrue(Sel_TopMenuBar.MyAccountOptionPresent(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            case ("sign out"):
                                Report.IsTrue(Sel_TopMenuBar.SignOutOptionPresent(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                        }
                        break;
                    }
                    case ("navigation bar"):
                    {
                        var Sel_Nav = new NavigationBar();
                        switch (item.ToLower())
                        {
                            case ("navigation menu icon"):
                            {
                                Report.IsTrue(Sel_Nav.NavigationIconShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            }
                        }
                        break;
                    }
                    case ("main window"):
                    {
                        var Sel_Homepage = new Homepage();
                        switch (item.ToLower())
                        {
                            case ("register product hyperlink"):
                                Report.IsTrue(Sel_Homepage.QuickLinkButtonShowing("Register Product"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                Report.IsTrue(Sel_Homepage.QuickLinkHoveringChangeColour("Register Product"), item + " did not change colour when hovering!", item + " changed colour when hovering!");
                                break;
                            case ("register goodguide hyperlink"):
                                Report.IsTrue(Sel_Homepage.QuickLinkButtonShowing("Register GoodGuide"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                Report.IsTrue(Sel_Homepage.QuickLinkHoveringChangeColour("Register GoodGuide"), item + " did not change colour when hovering!", item + " changed colour when hovering!");
                                break;
                            case ("register purview hyperlink"):
                                Report.IsTrue(Sel_Homepage.QuickLinkButtonShowing("Register PurView"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                Report.IsTrue(Sel_Homepage.QuickLinkHoveringChangeColour("Register PurView"), item + " did not change colour when hovering!", item + " changed colour when hovering!");
                                break;
                            case ("wercslink hyperlink"):
                                Report.IsTrue(Sel_Homepage.QuickLinkButtonShowing("WERCSLink"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                Report.IsTrue(Sel_Homepage.QuickLinkHoveringChangeColour("WERCSLink"), item + " did not change colour when hovering!", item + " changed colour when hovering!");
                                break;
                            case ("subheading product information"):
                                Report.IsTrue(Sel_Homepage.TopGridHeaderPresent("PRODUCT INFORMATION"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            case ("subheading alerts"):
                                Report.IsTrue(Sel_Homepage.TopGridHeaderPresent("ALERTS"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                Report.IsTrue(Sel_Homepage.TopGridMoreOptionShowing("Alerts"), item + " was not displaying the 'MORE...' option!", item + " was correctly displaying the 'MORE...' option!");
                                break;
                            case ("subheading announcements"):
                                Report.IsTrue(Sel_Homepage.TopGridHeaderPresent("ANNOUNCEMENTS"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                Report.IsTrue(Sel_Homepage.TopGridMoreOptionShowing("Announcements"), item + " was not displaying the 'MORE...' option!", item + " was correctly displaying the 'MORE...' option!");
                                break;
                            }
                        break;
                    }
                    case ("home page header"):
                    {
                        var Sel_HomePageHeader = new HomePageHeader();
                        switch (item.ToLower())
                        {
                            case ("register product hyperlink"):
                                Report.IsTrue(Sel_HomePageHeader.QuickLinkButtonShowing("Register Product"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            case ("register goodguide hyperlink"):
                                Report.IsTrue(Sel_HomePageHeader.QuickLinkButtonShowing("Register GoodGuide"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            case ("register purview hyperlink"):
                                Report.IsTrue(Sel_HomePageHeader.QuickLinkButtonShowing("Register PurView"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                            case ("wercslink hyperlink"):
                                Report.IsTrue(Sel_HomePageHeader.QuickLinkButtonShowing("WERCSLink"), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
                                break;
                        }
                        break;
                    }
                    case ("products grid"):
                    {
                        var Sel_ProdGrid = new ProductsGrid();
                        switch (item.ToLower())
                        {
                            case ("subheading your products"):
                                Report.IsTrue(Sel_ProdGrid.HeaderShowing(), item + " was not present in the " + area + "!", item + " was present in the " + area + ", as expected");
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

        [StepDefinition(@"I click on the red triangle next to Product Information to (expand|collapse) the section")]
        public void WhenIClickOnTheRedTraingleNextToProductInformation(string ExpandCollapse)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking on Red Triangle next to Product Information");
            try
            {
                Report.Info("Clicking on Red Triangle next to Product Information to " + ExpandCollapse + " the section");
                var Sel_Homepage = new Homepage();
                Sel_Homepage.ClickRedArrowNextToProductInformation(ExpandCollapse=="expand");
                GeneralUtilities.Wait_for_load_finish();
                Delay.Seconds(Delay.SpeedFactor*2);
                Report.Screenshot();
                Report.Success("Red Triangle clicked successfully!");
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
                var Sel_Homepage = new Homepage();
                var Showing = false;
                switch (dialog)
                {
                    case ("Product Information"):
                        Showing = Sel_Homepage.ProductInformationSectionVisible();
                        break;
                    case ("Alerts"):
                        Showing = Sel_Homepage.AlertsSectionVisible();
                        break;
                    case ("Announcements"):
                        Showing = Sel_Homepage.AnnouncementsSectionVisible();
                        break;
                }

                Report.IsTrue((visibility=="visible")== Showing,
                    dialog + " dialog was not " + visibility  + "!",
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
                var Sel_Homepage = new Homepage();
                Report.IsTrue(Sel_Homepage.PieChartShowingInProductInformation(), "Pie Chart was not showing!", "Pie Chart was showing as expected!");
                Report.IsTrue(Sel_Homepage.PieChartLegendShowingInProductInformation(), "Pie Chart legend was not showing!", "Pie Chart legend was showing as expected!");
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
                var Sel_Homepage = new Homepage();
                foreach (var Row in table.Rows)
                {
                    Report.IsTrue(Sel_Homepage.EntryShowingInPieChartLegend(Row["State"], Row["Colour"]), "Legend entry was not showing correctly!", "Entry was showing correctly in the legend!");
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
        public void GivenISeeNotificationsInThePanel(string Panel)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that notifications exist in the " + Panel + " Panel");
            try
            {
                Report.Info("Checking that notifications exist in the " + Panel + " Panel");
                var Sel_Homepage = new Homepage();
                Report.IsTrue(Sel_Homepage.NotificationsExistInPanel(Panel), "No notifications were found in " + Panel + " Panel!", "Notifications were found in the " + Panel + " Panel!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"clicking on the top (Alert|Announcement) should direct me to the My Messages page")]
        public void ThenClickingOnTheTopShouldDirectMeToTheMyMessagesPage(string Panel)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Selecting top " + Panel);
            try
            {
                Report.Info("Clicking on the top Alert");
                var Sel_Homepage = new Homepage();
                Report.IsTrue(Sel_Homepage.ClickOnFirst(Panel), "Could not click on the top " + Panel.ToLower() + "!", "Clicked on the top " + Panel.ToLower() + " successfully!");
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
        public void ThenIConfirmThatIAmTakenToTheMyMessagesAlertsPage(string Page)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - My Messages " + Page + " Page should load");
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
                var Sel_Nav = new NavigationBar();
                GeneralUtilities.Wait_for_load_finish();
                Report.IsTrue(Sel_Nav.Click_Icon("Home"), "Failed to click the home icon!", "Successfully clicked the Home icon!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see the following filter options below Your Products")]
        public void GivenIShouldSeeTheFollowingFilterOptionsBelowYourProducts(Table table)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking 'Your Products' Filter Options");
            try
            {
                Report.Info("Checking 'Your Products' Filter Options");
                var Sel_ProdGrid = new ProductsGrid();
                foreach (var Row in table.Rows)
                    Report.IsTrue(Sel_ProdGrid.FilterOptionShowingCorrectly(Row["Options"], Row["Colour"]), "Filter option: '" + Row["Options"] + "' was not showing correctly!", "Filter option: '" + Row["Options"] + "' was showing correctly!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }
        
        [StepDefinition(@"I click More below the (Alerts|Announcements) Panel")]
        public void ThenIClickBelowTheALERTSPanel(string Panel)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking More below the " + Panel + " Panel");
            try
            {
                Report.Info("Clicking More below the " + Panel + " Panel");
                var Sel_Home = new Homepage();
                GeneralUtilities.Wait_for_load_finish();
                Report.IsTrue(Sel_Home.ClickMoreForPanel(Panel), "Failed to click 'More' below the " + Panel + " panel!", "Successfully clicked 'More' below the " + Panel + " panel!");
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
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - " + (expand=="expand"?"Expand":"Collapse") + " the Navigation Menu");
            try
            {
                Report.Info("Attempting to click the Navigation Menu Icon");
                var Sel_Nav = new NavigationBar();
                GeneralUtilities.Wait_for_load_finish();
                Report.IsTrue(Sel_Nav.NavigationIconClick(expand=="expand"),"Failed to " + expand + " the Navigation Menu Icon!","Successfully " + (expand == "expand" ? "expanded" : "collapsed") + " the Navigation Menu Icon!");
                GeneralUtilities.Wait_for_load_finish();
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I following should be found in the (header bar|user dropdown|navigation bar)")]
        public void TheFollowingAreShowingInThe(string Area, TechTalk.SpecFlow.Table Expected)
        {
           TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking correct elements are found in " + Area);
            try
            {
                Report.Info("Checking that the correct elements are presebt in the " + Area);
                foreach (var Row in Expected.Rows)
                {
                    switch (Area)
                    {
                        case ("navigation bar"):
                        {
                            var Sel_Nav = new NavigationBar();
                            Report.IsTrue(Sel_Nav.ItemShowingInNavigationPanel(Row["Item"]), 
                                Row["Item"] + " was not found in the Navigation Bar!", 
                                Row["Item"] + " was successfully found in the Navigation Bar!");
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
                var Sel_TopHeader = new TopMenuBar();
                Sel_TopHeader.ClickOnUserTopRight();
                Report.Success("Clicked on the User Icon!");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I click on (My Account|Sign Out)")]
        public void ThenIClickOnUserItem(string UserItem)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking user item " + UserItem);
            try
            {
                Report.Info("Clicking user item " + UserItem);
                var Sel_TopHeader = new TopMenuBar();
                switch (UserItem)
                {
                    case ("My Account"):
                        Sel_TopHeader.ClickMyAccount();
                        break;
                    case ("Sign Out"):
                        Sel_TopHeader.ClickSignOut();
                        break;
                }

                GeneralUtilities.Wait_for_load_finish();
                Report.Success("Clicked on user item " + UserItem + "!");
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
                var Sel_ProdGrid = new ProductsGrid();
                Report.IsTrue(Sel_ProdGrid.ProductsPresent(),"Products were not present in the grid!","There were products present in the grid, as expected!");
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
                var Sel_TopMenuBar = new TopMenuBar();
                Sel_TopMenuBar.ClickNotificationIcon();
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
                var Sel_Nav = new NavigationBar();
                Sel_Nav.Click_Icon(item);
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

        [StepDefinition(@"I click the (Register Product|Register PurView|UL Solution Center|WERCSLink) icon in the QuickLinks Pane")]
        public void ClickItemInQuickLinks(string item)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Selecting " + item + " in the Navigation Pane");
            try
            {
                Report.Info("Selecting " + item + " in the Navigation Pane");
                var Sel_HomePage = new Homepage();
                Report.IsTrue(Sel_HomePage.ClickQuickLink(item),"Failed to click item: '" + item + "'!", "Successfully clicked item: '" + item + "'!");
                GeneralUtilities.Wait_for_load_finish();
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

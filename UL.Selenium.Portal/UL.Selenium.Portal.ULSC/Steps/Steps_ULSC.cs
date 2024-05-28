using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using UL.Selenium.Portal.ULSC.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps;
using System.Collections.ObjectModel;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Reporting;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;

namespace UL.Selenium.Portal.ULSC.Steps
{
	[Binding, Scope(Tag = "ULSC")]
	class StepsUlsc
	{

		[RegexStepDefinition(@"I should see the following option (.*)")]
		public void ThenIShouldSeeTheFollowingOption(string option)
		{
			Report.StartStep(ReportSettings.StepCounter +  " - Checking that the option " + option + " is showing");
			try
			{
				var selUlSolutionCenter = new UlSolutionCenter();

				if (!selUlSolutionCenter.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				List<string> optionShowing = selUlSolutionCenter.OptionShowing();

				Report.IsTrue(optionShowing.Contains(option.Trim()),
					"Option: " + option + " was not showing in the list of options! Options showing were: " + string.Join(", ", optionShowing),
					"Option: " + option + " was showing correctly in the list of options!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Clicking the learn more button on the UL Solution Center page
		/// </summary>
		//[RegexStepDefinition(@"I click the Learn More button")]
		//public void ClickLearnMorebutton()
		//{
		//	Report.StartStep(ReportSettings.StepCounter + " - Clicking 'Learn More button'");
		//	try
		//	{
		//		Report.Info("Clicking 'Learn More button'");

		//		var selUlSolutionCenter = new UlSolutionCenter();

		//		if (!selUlSolutionCenter.Wait_for_load(10))
		//		{
		//			throw new Exception("Page failed to load!");
		//		}


		//		selUlSolutionCenter.ClickMoreInformation();
		//		Report.Success("More Information link clicked!");
		//		Report.Info("Switching to new window");

		//		Context.AddToContext("MainWindowHandle", SeleniumBrowser.WebBrowser.CurrentWindowHandle);

		//		var windowHandles = SeleniumBrowser.WebBrowser.WindowHandles;
		//		var newTab = windowHandles.FirstOrDefault(x => x != SeleniumBrowser.WebBrowser.CurrentWindowHandle);
		//		SeleniumBrowser.WebBrowser.SwitchTo().Window(newTab);
		//		Report.Success("Window switched successfully!");
		//		Report.Screenshot();
		//	}
		//	catch (Exception ex)
		//	{
		//		Report.Failure(ex.Message);
		//		throw;
		//	}
		// }

		[RegexStepDefinition(@"I navigate to Studio for ULSC")]
		public void GivenINavigateToStudioULSC()
		{
			SeleniumBrowser.WebBrowser.Url = TestVariables.GetVariableSavedAs("TestUrl");
			SeleniumBrowser.WebBrowser.WaitForPageLoad();

		}

		[RegexStepDefinition(@"I login to Studio as ULSC")]
		public void GivenILoginToStudioAsULSCUser()
		{
			var thisStudioLogin = new StudioLogin();
			TReVorTestUsers ulscUser = TestUsers.GetUserSavedAs("ULSC_StudioUser");
			thisStudioLogin.Username = ulscUser.Username;
			thisStudioLogin.Password = ulscUser.Password;
			thisStudioLogin.ClickSignIn();
			Delay.Seconds(3);
			var thisStudioDesktop = new StudioDesktop();
			Report.IsTrue(thisStudioDesktop.Wait_for_load(30), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
			Report.Info("Studio desktop is loaded");
			var thisStudioTopMenu = new StudioTopMenu();
			Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");
		}

		[RegexStepDefinition(@"the ULSC Login page should open in a new tab")]
		public void GivenTheULSCLoginPageShouldOpenInANewTab()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//img[@alt='UL Secure Connect']"), 2) != null)
				{
					Report.Success("UL Secure Connect page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
			Report.Screenshot();
		}

		[RegexStepDefinition(@"In the ULSC Login page I enter Username and password for the following account: (.*)")]
		public void GivenInTheULSCLoginPageIEnterUsernameAndPasswordForTheFollowingAccountTest(string accountSavedAs)
		{
			var thisULSCLogin = new ULSCLogin();
			TReVorTestUsers user = TestUsers.GetUserSavedAs(accountSavedAs);
			if (Report.IsTrue(user != null, "Failed to find user saved as: " + accountSavedAs, "Successfully found user saved as: " + accountSavedAs, true))
			{
				thisULSCLogin.Username = user.Username;
				thisULSCLogin.Password = user.Password;
			}
		}

		[RegexStepDefinition(@"I the ULSC Login page I click Login")]
		public void GivenITheULSCLoginPageIClickLogin()
		{
			var thisULSCLogin = new ULSCLogin();
			Report.IsTrue(thisULSCLogin.ClickLogIn(), "Failed to click login in the ULSC login page",
				"Clicked login on the ULSC login page");
		}

		[RegexStepDefinition(@"I should see the WERCSLink dashboard")]
		public void GivenIShouldSeeTheWERCSLinkDashboard()
		{
			var thisWercsLinkDashboard = new WERCSLinkDashboard();
			Report.IsTrue(thisWercsLinkDashboard.Wait_for_load(60), "WERCSlink dashboard has not opened.",
				"WERCSlink dasboard is showing as expected");
		}

		[RegexStepDefinition(@"In the WERCSLink dashboard I click menu item: (.*) and submenu item: (.*)")]
		public void GivenInTheWERCSLinkDashboardIClickMenuItemAndSubmenuItem(string menu, string submenu)
		{
			//WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			//Report.IsTrue(thisWercsLinkDashboard.ClickMenuAndSubMenuOption(menu, submenu), "Failed to click menu item: " + menu + " and submenu item: " + submenu,
			//	"Clicked menu item: " + menu + " and submenu item: " + submenu);

			// trying this...
			// first check if we are on 'Services page already and click' you have to click the menu item twice to get the sub items expanded
			SideBarNavigation.NavLink thisLink = new SideBarNavigation().GetNavLink(menu);
			if (thisLink == null)
			{
				Report.Failure("There was no menu item with title: " + menu);
				Report.Screenshot();
				return;
			}
			Report.Info("Clicking menu item: " + menu);
			if (!new SideBarNavigation().ClickNavItem(thisLink))
			{
				Report.Failure("Failed to click menu item: " + menu + "!");
				Report.Screenshot();
				return;
			}
			Delay.Seconds(2);
			thisLink = new SideBarNavigation().GetNavLink(menu);
			if (thisLink.SubLinks.Any())
			{
				Report.Info("Menu item: " + menu + " is already expanded. Clicking sub menu item: " + submenu);
				SideBarNavigation.NavSubLink subMatch = thisLink.SubLinks.First(x => x.Title == submenu);
				if (subMatch == null)
				{
					Report.Failure("No sub link was found with title: " + submenu);
					Report.Screenshot();
					return;
				}
				Report.IsTrue(new SideBarNavigation().ClickNavItem(subMatch), "Failed to click sub menu item: " + subMatch + "!", "Successfully clicked sub menu item: " + submenu);
			}
			else if (new SideBarNavigation().ClickNavItem(thisLink))
			{
				Report.Info($"Clicked menu item: '{menu}'. Finding proceeding sub menu items");
				// get link item again for loaded sub links
				Delay.Seconds(2);
				thisLink = new SideBarNavigation().GetNavLink(menu);
				if (thisLink.SubLinks.Any())
				{
					Report.Info("Clicking sub menu item: " + submenu);
					SideBarNavigation.NavSubLink subMatch = thisLink.SubLinks.First(x => x.Title == submenu);
					if (subMatch == null)
					{
						Report.Failure("No sub link was found with title: " + submenu);
						Report.Screenshot();
						return;
					}
					Report.IsTrue(new SideBarNavigation().ClickNavItem(subMatch), "Failed to click sub menu item: " + subMatch + "!", "Successfully clicked sub menu item: " + submenu);
					return;
				}
				Report.Failure("No sub links were found after clicking menu item: " + menu);
				Report.Screenshot();
				return;
			}
			Report.Failure("Failed to click menu item: " + menu);
			Report.Screenshot();
		}

		//[RegexStepDefinition(@"In the WERCSLink dashboard I click left menu link: (.*)")]
		//public void GivenInTheWERCSLinkDashboardIClickLeftMenuLink(string menu)
		//{
		//	WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
		//	Report.IsTrue(thisWercsLinkDashboard.ClickLeftLink(menu), "Failed to click left menu link " + menu,
		//		"Clicked menu item: " + menu);
		//}

		[RegexStepDefinition(@"I Confirm the WerCSMart Product Information page is shown in new window/tab")]
		public void GivenIConfirmTheWerCSMartProductInformationPageIsShownInNewWindowTab()
		{
			Delay.Seconds(30);
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='products-information']"), 2) != null)
				{
					Report.Success("Product information page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screenshots) were:", false);
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
			int counter = 1;
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				Report.Info("Tab " + counter.ToString());
				Report.Info("Url: " + url);
				Report.Screenshot();
				counter++;
			}
		}

		[RegexStepDefinition(@"I close the tab with the (.*) page")]
		public void GivenICloseTheTabWithTheProductInformationPage(string page)
		{
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				switch (page)
				{
					case "The Product":
						var selNewProduct = new NewProduct();
						if (selNewProduct.WaitForContainerToBeVisible())
						{
							if (selNewProduct.WaitForSection(page))
							{
								Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
									"Closed tab with url: " + url);
								return;
							}
						}
						break;
					case "Product Information":
						if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='products-information']"), 2) != null)
						{
							Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
								"Closed tab with url: " + url);
							return;
						}
						break;
					case "New Product":
						var selNewProductnp = new NewProduct();
						if (selNewProductnp.WaitForContainerToBeVisible())
						{

							Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
								"Closed tab with url: " + url);
							return;
						}
						break;
					case "ULGHS.COM":
						string targetURL = TestVariables.GetVariableSavedAs("ULGHS.COM");
						if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
						{
							Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
								"Closed tab with url: " + url);
							return;
						}
						break;
					case "Data Management":
						string targetURLDM = TestVariables.GetVariableSavedAs("studio");
						if (SeleniumBrowser.WebBrowser.Url.Contains(targetURLDM))
						{
							Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
								"Closed tab with url: " + url);
							return;
						}
						break;
					default:
						throw new Exception("Page name you have provided is not valid");

				}

			}

			//We may be on the wrong page, just find one for WERCSmart
			Report.Failure("Failed to find expected tab");
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				if (SeleniumBrowser.WebBrowser.Title.Contains("WERCSmart"))
				{
					string ulrToClose = SeleniumBrowser.GetActiveTabURL();
					Report.Info("Attemping to close: " + ulrToClose);
					Report.IsTrue(SeleniumBrowser.CloseTabWithURL(ulrToClose), "Failed to close tab with url: " + ulrToClose,
						"Closed tab with url: " + ulrToClose);
					return;
				}
			}
		}

		[RegexStepDefinition(@"I navigate to tab with title: (.*)")]
		public void GivenINavigateToTabWithTitle(string tabTitle)
		{
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				if (SeleniumBrowser.WebBrowser.Title.Contains(tabTitle))
				{
					Report.Info("Switched to url: " + url);
					return;
				}
			}

			Report.Error("Failed to switch to tab with title: " + tabTitle);
		}

		[RegexStepDefinition(@"In the WERCSLink page - Click the (.*) link from the (.*) area of the Services page")]
		public void GivenInTheWERCSLinkPage_ClickTheMyProductLinkFromTheWERCSmartAreaOfTheServicesPage(string link, string area)
		{
			var thisWercsLinkDashboard = new WERCSLinkDashboard();

			switch (area)
			{
				case "WERCSmart":
					Report.IsTrue(thisWercsLinkDashboard.ClickMainPageLink(link), "Failed to click link: " + link,
						"Clicked " + link);
					break;
				case "WERCS Studio":
					Report.IsTrue(thisWercsLinkDashboard.ClickMainPageLink(link), "Failed to click link: " + link,
						"Clicked " + link);
					break;
				default:
					throw new Exception("You must provide a valid page area");

			}

		}

		[RegexStepDefinition(@"I Confirm a new window opens with the WERCSmart New Product page shown")]
		public void GivenIConfirmANewWindowOpensWithTheWERCSmartNewProductPageShown()
		{
			Delay.Seconds(30);
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='dataentry']"), 2) != null)
				{
					Report.Success("New product page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screen shots) were:");
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
			int counter = 1;
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				Report.Info("Tab " + counter.ToString());
				Report.Info("Url: " + url);
				Report.Screenshot();
				counter++;
			}
		}

		[RegexStepDefinition(@"I confirm that the WERCSLink header appears at the top left")]
		public void GivenIConfirmThatTheWERCSLinkHeaderAppearsAtTheTopLeft()
		{
			Report.IsTrue(new TopBarNavigation().TopLeftTitleExists("WERCSLink"), "Failed to find top left title WERCSLink",
				"Found top left title: WERCSLink");
		}

		// using new class
		[RegexStepDefinition(@"I confirm that the following WERCSLink menu items are showing")]
		public void GivenIConfirmThatTheFollowingWERCSLinkMenuItemsAreShowing(Table table)
		{
			var menuItems = new SideBarNavigation().GetNavLinks().Select(x => x.Title).ToList();
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(menuItems.Contains(thisRow["Menu item"]), "Failed to find menu item: " + thisRow["Menu item"],
					"Found left menu item: " + thisRow["Menu item"]);
			}
		}

		[RegexStepDefinition(@"I confirm the following sub links are displayed below the WERCSLink menu item: (.*):")]
		public void ConfirmWercsLinkMenuItemDisplaysSubItems(string menuItem, Table table)
		{
			SideBarNavigation.NavLink thisMenuItem = new SideBarNavigation().GetNavLink(menuItem);
			if (thisMenuItem == null)
			{
				Report.Failure($"The menu item: {menuItem} was not displayed!");
				Report.Screenshot();
				return;
			}
			foreach (TableRow row in table.Rows)
			{
				if (thisMenuItem.SubLinks.All(x => x.Title != row["Sub link"]))
				{
					Report.Failure("The sub link: " + row["Sub link"] + " was not displayed below menu item: " + menuItem + "!");
					Report.Screenshot();
					return;
				}
				Report.Info("Sub link: " + row["Sub link"] + " was displayed");
			}
			Report.Success("The correct sub item links were displayed below the menu item: " + menuItem);
			Report.Screenshot();
		}

		[RegexStepDefinition(@"I click the link: (.*) below the WERCSLink menu item: (.*)")]
		public void ClickSubLinkItem(string subLink, string menuItem)
		{
			SideBarNavigation.NavLink thisMenuItem = new SideBarNavigation().GetNavLink(menuItem);
			if (thisMenuItem == null)
			{
				Report.Failure($"The menu item: {menuItem} was not displayed!");
				Report.Screenshot();
				return;
			}
			SideBarNavigation.NavSubLink thisSubLink = thisMenuItem.SubLinks.First(x => x.Title == subLink);
			if (thisSubLink == null)
			{
				Report.Failure("The sub link with title: " + subLink + " was not displayed under the primary link: " + menuItem);
				Report.Screenshot();
				return;
			}
			Report.IsTrue(new SideBarNavigation().ClickNavItem(thisSubLink), $"Failed to click sub link: {subLink}!", $"Successfully clicked sub link: {subLink}");
		}

		[RegexStepDefinition(@"I confirm that the Services page displays the following sections:")]
		public void ConfirmServicesPageDisplaysSections(Table table)
		{
			List<string> sections = new Services().SectionHeadings();
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(sections.Contains(thisRow["Section"]), "Failed to find Services section: " + thisRow["Section"],
					"Found Services section: " + thisRow["Section"]);
			}
		}

		[RegexStepDefinition(@"I confirm that the Services page contains a section with the WERCSmart logo, name and Registered trade mark")]
		public void ConfirmServicesPageContainsASectionWithWercSmartLogoNameAndRegisteredTrademark()
		{
			List<string> images = new Services().SectionImages("WERCSmart®");
			if (images != null)
			{
				Report.IsTrue(images.Contains("wercsmart-logo"), "The WercSmart Logo was not displayed for section with heading: WercSmart name and registered trademark!",
					"The WercSmart logo was displayed in the section with heading: WercSmart name and registered trademark as expected");
				return;
			}
			Report.Failure("The Services section: WERCSmart was not found!");
			Report.Screenshot();
		}

		[RegexStepDefinition(@"I confirm that the Services section: (.*) contains the description text: (.*)")]
		public void ConfirmThatInServicesSectionContainsDescriptionText(string heading, string expectedText)
		{
			string actualText = new Services().SectionDescription(heading);
			string normalisedActual = Regex.Replace(actualText, @"\s+", "");
			string normalisedExpected = Regex.Replace(expectedText, @"\s+", "");
			Report.IsTrue(normalisedActual == normalisedExpected,
				$"Expected text ({expectedText}) did not match actual text ({actualText}) for section: {heading}!", "Expected description text matched actual text for section: " + heading);
		}

		[RegexStepDefinition(@"I confirm that the following links are displayed in the Services section: (.*):")]
		public void ConfirmLinksAreDisplayedInServicesSection(string section, Table table)
		{
			List<Services.ServiceLink> links = new Services().SectionLinks(section);
			foreach (TableRow row in table.Rows)
			{
				string expectedTitle = row["Link title"];
				string expectedIcon = row["Link icon"];
				if (Report.IsTrue(links.Any(x => x.Title == expectedTitle), "No link with title: " + expectedTitle + " was displayed in Services section: " + section, "Link with title: " + expectedTitle + " was displayed in Services section: " + section + " as expected"))
				{
					Report.IsTrue(links.Any(x => x.Icon == expectedIcon), "No link with icon: " + expectedIcon + " was displayed in Services section: " + section, "Link with icon: " + expectedIcon + " was displayed in Services section: " + section + " as expected");
				}
			}
		}

		[RegexStepDefinition(@"I confirm that the following subheadings are displayed in the Services section: (.*)")]
		public void GivenIConfirmThatInTheWERCSmartAreaTheFollowingSubheadingsAppear(string section, Table table)
		{
			List<string> subheadings = new Services().SectionSubHeadings(section);
			foreach (TableRow thisRow in table.Rows)
			{
				string matchingSubheading = subheadings.FirstOrDefault(x => x == thisRow["Subheading"]);
				Report.IsTrue(matchingSubheading != null, "Failed to find matching subheading: " + thisRow["Subheading"],
					"Found matching subheading: " + thisRow["Subheading"]);
			}
		}

		[RegexStepDefinition(@"I confirm the following images are displayed in the Services section: (.*)")]
		public void GivenIConfirmThatInTheWERCSmartAreaTheFollowingImagesAppear(string section, Table table)
		{
			List<string> images = new Services().SectionImages(section);

			foreach (TableRow thisRow in table.Rows)
			{
				string matchingImage = images.FirstOrDefault(x => x == thisRow["Image"]);
				Report.IsTrue(matchingImage != null, "Failed to find matching image: " + thisRow["Image"],
					"Found matching image: " + thisRow["Image"]);
			}
		}

		[RegexStepDefinition(@"I confirm a new window opens with the ULGHS.com page shown")]
		public void GivenIConfirmANewWindowOpensWithTheULGHSPageShown()
		{
			Delay.Seconds(30);
			string targetURL = TestVariables.GetVariableSavedAs("ULGHS.COM");
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);

				if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
				{
					Report.Success("Self-Service GHS SDS page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screen shots) were:");
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
			int counter = 1;
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				Report.Info("Tab " + counter.ToString());
				Report.Info("Url: " + url);
				Report.Screenshot();
				counter++;
			}
		}

		[RegexStepDefinition(@"I Confirm New window opens with the Studio Data Management window open \(Welcome page shows\) and that NO script errors display")]
		public void GivenIConfirmNewWindowOpensWithTheStudioDataManagementWindowOpenWelcomePageShowsAndThatNOScriptErrorsDisplay()
		{
			Delay.Seconds(30);
			string targetURL = TestVariables.GetVariableSavedAs("Studio");
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);

				if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
				{
					Report.Success("Studio Data management page opened. Successfully switched to that tab.");
					var thisStudioPowerDesignerPlus = new StudioPowerDesignerPlus();

					Report.IsTrue(thisStudioPowerDesignerPlus.Wait_for_load(120),
						"Waiting for power designer load failed", "Welcome page loaded as expected");

					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screen shots) were:");
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
			int counter = 1;
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				Report.Info("Tab " + counter.ToString());
				Report.Info("Url: " + url);
				Report.Screenshot();
				counter++;
			}
		}

		[RegexStepDefinition(@"I Close the Data Management window")]
		public void GivenICloseTheDataManagementWindow()
		{
			Context.ScenarioContext.Pending();
		}

		[RegexStepDefinition(@"I navigate to WERCSmart")]
		public void GivenINavigateToWERCSmart()
		{
			Report.Info("Getting test variable saved as 'WercSmart_TestUrl'");
			string url = TestVariables.GetVariableSavedAs("WercSmart_TestUrl");
			if (url == null)
			{
				throw new Exception("WercSmart test url not found in trevor!");
			}
			Report.Info("Navigating to: " + url);
			SeleniumBrowser.WebBrowser.Url = url;
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
			//var Branch = TReVorSettings.SoftwareBranch;
			//string regexPattern = @"^.*(?=(\/))";
			//Regex regex = new Regex(regexPattern);
			//Match match = regex.Match(Branch);
			//if (match.Success)
			//{
			//	var url = TestVariables.GetVariableSavedAs("TestURL", "3", match.Value);
			//	SeleniumBrowser.WebBrowser.Url = url;
			//	SeleniumBrowser.WebBrowser.WaitForPageLoad();
			//}
			//else
			//{
			//	throw new Exception("Wercsmart URL could not be found");
			//}
		}

		[RegexStepDefinition(@"I Confirm New window opens with the error message: (.*)")]
		public void GivenIConfirmNewWindowOpensWithErrorMessages(string errorMessage)
		{
			Delay.Seconds(30);
			string currentURL = SeleniumBrowser.WebBrowser.Url;
			string targetURL = "ULSC";
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);

				if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
				{
					Report.Success("Additional tab opened. Successfully switched to that tab.");
					var thisStudioPowerDesignerPlus = new StudioPowerDesignerPlus();

					IWebElement body = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//body"), 2);
					Report.IsTrue(body.GetElementText().Trim() == errorMessage,
						"Expected error message: " + errorMessage + " but got: " + body.GetElementText(),
						"As expected, error message is showing: " + errorMessage);

					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screen shots) were:");
			var OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
			int counter = 1;
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				Report.Info("Tab " + counter.ToString());
				Report.Info("Url: " + url);
				Report.Screenshot();
				counter++;
			}
		}

		[RegexStepDefinition(@"I confirm the left hand navigation is displayed under WercsLink")]
		public void ConfirmLeftHandNavigationDisplayed()
		{
			Report.IsTrue(new SideBarNavigation().GetNavLinks().Any(x => !string.IsNullOrEmpty(x.Title)),
				"The left hand navigation did not load with any items!",
				"The left hand navigation loaded with items as expected");
		}

		[RegexStepDefinition(@"I confirm the following widget panels are (displayed|not displayed) on the Key Performance Indicators page:")]
		[RegexStepDefinition(@"I confirm the following widget panels are (displayed|not displayed) on the Dashboard page:")]
		public void ConfirmWidgetPanelsDisplayedOnTheDashboard(string displayed, Table table)
		{
			var expectedWidgets = new List<string>();
			table.Rows.Cast<TableRow>().ToList().ForEach(x => expectedWidgets.Add(x["Widget"]));
			Report.Info("Expected widgets are: " + string.Join(", ", expectedWidgets));
			List<string> actualWidgets = new Dashboard().WidgetTitles();
			Report.Info("Actual widgets are: " + string.Join(", ", actualWidgets));
			switch (displayed)
			{
				case "displayed":
					Report.IsTrue(expectedWidgets.All(x => actualWidgets.Contains(x)),
						"Expected to see the following widgets: " + string.Join(", ", expectedWidgets) + " But found: " + string.Join(", ", actualWidgets),
						"The following widgets were displayed as expected: " + string.Join(", ", expectedWidgets));
					break;
				case "not displayed":
					Report.IsTrue(expectedWidgets.All(x => !actualWidgets.Contains(x)),
						"Widgets were displayed which were not expected! ",
						"None of the listed widgets were displayed as expected");
					break;
				default:
					Report.Error("Step parameter must be set to either 'displayed' or 'not displayed'!");
					return;
			}


		}

		[RegexStepDefinition(@"I Confirm the Layout shows a header, left hand navigation, Message center and KPI areas")]
		public void ConfirmDashboardLayout_Header_LeftHandNavigation_MessageCenter_KPIAreas()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I confirm the WERCSLink header is displayed");
			this.GivenIConfirmThatTheWERCSLinkHeaderAppearsAtTheTopLeft();
			Report.StartStep("I confirm the left hand navigation is displayed under WercsLink");
			this.ConfirmLeftHandNavigationDisplayed();
			Report.StartStep("I confirm the Message widget panel is displayed on the Dashboard:");
			var table = new Table("Widget");
			table.AddRow("Message Center");
			this.ConfirmWidgetPanelsDisplayedOnTheDashboard("displayed", table);
			Report.StartStep("I confirm the KPI widget panels are displayed on the Dashboard");
			var kpiTitles = new List<string> { "Products By Retailer and Status", "RUs by Category", "Products by Recertification Reason", "Products by RU", "RUs by Category by Retailer", "Subscription Status" };
			table = new Table("Widget");
			foreach (string title in kpiTitles)
			{
				table.AddRow(title);
			}
			this.ConfirmWidgetPanelsDisplayedOnTheDashboard("displayed", table);
		}

		[RegexStepDefinition(@"I confirm the WERCSLink sidebar menu icon is displayed")]
		public void IConfirmTheWercsLinkSidebarMenuIconIsDisplayed()
		{
			Report.IsTrue(new TopBarNavigation().WercsLinkNavigationButtonDisplayed(), "The WERCSLink sidebar menu icon was not displayed!", "The WERCSLink sidebar menu icon was displayed as expected");
		}

		[RegexStepDefinition(@"I click the WERCSLink sidebar menu icon")]
		public void IClickTheWercsLinkSidebarMenuIcon()
		{
			Report.IsTrue(new TopBarNavigation().ClickWercsLinkNavigationButton(), "Failed to click the WERCSLink sidebard navigation button", "Successfully clicked the WERCSLink sidebard navigation button");
		}

		[RegexStepDefinition(@"I confirm the left hand navigation list is (collapsed|expanded)")]
		public void ConfirmLeftNavigationCollapsesWithTitlesNotDisplayed(string navState)
		{
			List<SideBarNavigation.NavLink> sideBarItems = new SideBarNavigation().GetNavLinks();
			switch (navState)
			{
				case "collapsed":
					Report.IsTrue(sideBarItems.All(x => !x.TitleDisplayed), "The side bar navigation list was not collapsed - titles were displayed!", "The side bar navigation list was collapsed as expected");
					break;
				case "expanded":
					Report.IsTrue(sideBarItems.All(x => x.TitleDisplayed), "The side bar navigation list was not expanded - titles were not displayed!", "The side bar navigation list was expanded as expected");
					break;
				default:
					Report.Error("Step variable must be either 'collapsed' or 'expanded'!");
					break;
			}
		}

		[RegexStepDefinition(@"I confirm the user button in the header displays the logged in username")]
		public void ConfirmUserButtonDisplaysLoggedInUserName()
		{
			TReVorTestUsers user = TestUsers.GetUserSavedAs("WercsUser");
			if (user == null)
			{
				Report.Failure("No ULCS WercsUser found for current branch in TReVor");
				return;
			}
			string username = user.Username;
			string displayedUser = new TopBarNavigation().UserButtonText();
			Report.IsTrue(displayedUser == username, "Expected username in the header to be: " + user + " but was: " + displayedUser + "!", "Username: " + username + " was displayed in the header as expected");
		}

		[RegexStepDefinition(@"I click the user button in the header")]
		public void ClickHeaderUserButton()
		{
			Report.IsTrue(new TopBarNavigation().ClickUserButton(), "Failed to click the user button in the header!", "Successfully clicked the user button in the header");
		}

		[RegexStepDefinition(@"I confirm the Reset Dashboard icon is displayed next to the user button in the header")]
		public void ConfirmResetDashboardIconDisplayed()
		{
			Report.IsTrue(new TopBarNavigation().ResetDashboardIconDisplayed(), "The Reset Dashboard icon was not displayed in the header!", "The Reset Dashboard icon was displyed in the header as expected");
		}

		[RegexStepDefinition(@"I click the Reset Dashboard icon next to the user button in the header")]
		public void ClickResetDashboardIcon()
		{
			Report.IsTrue(new TopBarNavigation().ClickResetDashboardIcon(), "Failed to click the Reset Dashboard icon in the header!", "Successfully clicked the Reset Dashboard icon in the header");
		}

		[RegexStepDefinition(@"I confirm the Reset Dashboard dropdown item is displayed underneath the header icon")]
		public void ConfirmResetDashboardDropDownItemDisplayed()
		{
			Report.IsTrue(new TopBarNavigation().ResetDashboardDropdownItemDisplayed(), "The Reset Dashboard dropdown item was not displayed under the header icon!", "The Reset Dashboard dropdown item was displyed under the header icon as expected");
		}

		[RegexStepDefinition(@"I confirm a new tab opens with url: (.*)")]
		public void ConfirmNewTabOpenWithUrl(string url)
		{
			new GlobalSteps().SwitchToTheTab(url);
		}

		[RegexStepDefinition(@"I confirm the Sign Out dropdown item is (displayed|not displayed)")]
		public void ConfirmSignOutDropdownDisplayed(string visibility)
		{
			if (visibility == "displayed")
			{
				Report.IsTrue(new TopBarNavigation().SignOutDropDownItemDisplayed(), "The Sign Out dropdown item was not displayed when it was expected to be!", "The Sign Out dropdown item was displayed as expected");
			}
			else if (visibility == "not displayed")
			{
				Report.IsTrue(!new TopBarNavigation().SignOutDropDownItemDisplayed(), "The Sign Out dropdown item was displayed when it was not expected to be!", "The Sign Out dropdown item was not displayed as expected");
			}
			else
			{
				Report.Error("Step parameter must be either 'displayed' or 'not displayed'!");
			}
		}

		[RegexStepDefinition(@"I confirm the UL Logo is displayed next to the user button in the header")]
		public void ConfirmTheUlLogoIsDisplayedHeader()
		{
			Report.IsTrue(new TopBarNavigation().ULLogoDisplayed(), "The UL Logo was not displayed in the header!", "The UL logo was displayed in the header as expected");
		}

		[RegexStepDefinition(@"I click the UL Logo next to the user button in the header")]
		public void ClickTheUlLogoHeader()
		{
			Report.IsTrue(new TopBarNavigation().ClickULLogo(), "Failed to click the UL Logo in the header!", "Successfully clicked the UL logo in the header");
			Delay.Seconds(10);
		}

		[RegexStepDefinition(@"I click the side bar navigation link: (.*)")]
		public void ClickSideBarLink(string title)
		{
			SideBarNavigation.NavLink menuItem = new SideBarNavigation().GetNavLink(title);
			if (menuItem == null)
			{
				throw new Exception("There was no side bar displayed with title: " + title);
			}
			Report.IsTrue(new SideBarNavigation().ClickNavItem(menuItem), "Failed to click the side bar link: " + title, "Successfully cliked the side bar link: " + title);
		}

		[RegexStepDefinition(@"I confirm the WERCSLink Additional Services page loads")]
		public void ConfirmAdditionalServicesPageLoads()
		{
			bool anyServices = new WERCSLinkDashboard().AnyServicesGrid();
			int i = 0;
			while (!anyServices && i < 60)
			{
				anyServices = new WERCSLinkDashboard().AnyServicesGrid();
				Delay.Seconds(1);
				i++;
			}
			Report.IsTrue(anyServices, $"Additional  Services pas was not loaded!", $"Additional Services page was loaded");
		}

		[RegexStepDefinition(@"I confirm the WERCSLink Recent Activities page loads")]
		public void ConfirmRecentActivitiesPageLoads()
		{
			bool loaded = new WERCSLinkDashboard().StatusCheckPageDisplayed("Recent Activities");
			int i = 0;
			while (!loaded && i < 60)
			{
				loaded = new WERCSLinkDashboard().StatusCheckPageDisplayed("Recent Activities");
				Delay.Seconds(1);
				i++;
			}
			Report.IsTrue(loaded, "The Recent Activities page was not loaded!", "The Recent Activies Page was loaded as expected");
		}

		[RegexStepDefinition(@"I confirm the WERCSLink Product Lookup page loads")]
		public void ConfirmProductLookupPageLoads()
		{
			bool loaded = new WERCSLinkDashboard().StatusCheckPageDisplayed("Product Lookup");
			int i = 0;
			while (!loaded && i < 60)
			{
				loaded = new WERCSLinkDashboard().StatusCheckPageDisplayed("Product Lookup");
				Delay.Seconds(1);
				i++;
			}
			Report.IsTrue(loaded, "The Product Lookup page was not loaded!", "The Product Lookup Page was loaded as expected");
		}

		// There is no title or disctinct ids to work with, so just confirm that any widgets are loaded (eg. RUs)
		[RegexStepDefinition(@"I confirm the WERCSLink Key Performance Indicators page loads")]
		public void ConfirmKeyPerformanceIndicatorsPageLoads()
		{
			List<string> widgets = new Dashboard().WidgetTitles();
			Report.IsTrue(widgets.Any(), "The Key Performance Indicators page did not load with widgets!", "The Key Performance Indictors page loaded with widgets");
		}

		[RegexStepDefinition(@"I confirm the following links are displayed below menu item: (.*) and sub item (.*)")]
		public void ConfirmFollowingSubSubLinksDisplayedBelowWercSmartSubLink(string menuItem, string subLink, Table table)
		{
			SideBarNavigation.NavLink link = new SideBarNavigation().GetNavLink(menuItem);
			if (link == null)
			{
				Report.Failure("Menu item: " + menuItem + " was not displayed in the nav side bar!");
				Report.Screenshot();
				return;
			}
			List<SideBarNavigation.NavSubSubLink> subSubLinks = link.SubLinks.First(x => x.Title == subLink)?.SubSubLinks;
			if (subSubLinks == null)
			{
				Report.Failure("No sub link matching title: '" + subLink + "' with sub sub link was found!");
				Report.Screenshot();
				return;
			}
			foreach (TableRow row in table.Rows)
			{
				if (subSubLinks.All(x => x.Title != row["Link"]))
				{
					Report.Failure("Link: " + row["Link"] + " was not displayed below the sub link: " + subLink + "!");
					Report.Screenshot();
					return;
				}
				Report.Info("The link " + row["Link"] + " was displayed a level below link: " + subLink);
			}
			Report.Success("The correct links were displayed below the sub link: " + subLink);
			Report.Screenshot();
		}

		[RegexStepDefinition(@"I click the link: (.*) below menu item: (.*) and sub item (.*)")]
		public void ClickLinkBelowWercSmartSubLink(string subSub, string menu, string sub)
		{
			SideBarNavigation.NavLink thisMenuItem = new SideBarNavigation().GetNavLink(menu);
			if (thisMenuItem == null)
			{
				Report.Failure($"The menu item: {menu} was not displayed!");
				Report.Screenshot();
				return;
			}
			SideBarNavigation.NavSubLink thisSubLink = thisMenuItem.SubLinks.First(x => x.Title == sub);
			if (thisSubLink == null)
			{
				Report.Failure("The link with title: " + sub + " was not displayed under the menu item: " + menu);
				Report.Screenshot();
				return;
			}
			SideBarNavigation.NavSubSubLink thisSubSubLink = thisSubLink.SubSubLinks.First(x => x.Title == subSub);
			if (thisSubSubLink == null)
			{
				Report.Failure("The link with title: " + subSub + " was not displayed under the sub menu item: " + sub);
				Report.Screenshot();
				return;
			}
			Report.IsTrue(new SideBarNavigation().ClickNavItem(thisSubSubLink), "Failed to click the link with title: " + subSub, "Successfully clicked link with title: " + subSub);
		}

		[RegexStepDefinition(@"I confirm that the drop down button with three dots is displayed for dashboard widget: (.*)")]
		public void ConfirmVerticalDotDropDownButtonIsDisplayed(string widget)
		{
			Report.IsTrue(new Dashboard().WidgetDropDownMenuToggleDisplayed(widget), "", "");
		}

		[RegexStepDefinition(@"I click the drop down button with three dots for dashboard widget: (.*)")]
		public void ClickVerticalDotDropDownButton(string widget)
		{
			Report.IsTrue(new Dashboard().ClickWidgetDropDownMenuToggle(widget), "", "");
		}

		[RegexStepDefinition(@"I confirm that the 'Remove' drop down item is (displayed|not displayed) for widget: (.*)")]
		public void ConfirmRemoveDropDownItemIsDisplayed(string displayed, string widgetTitle)
		{
			switch (displayed)
			{
				case "displayed":
					Report.IsTrue(new Dashboard().RemoveDropDownItemDisplayed(widgetTitle), "The 'Remove' drop down item was not displayed for widget: " + widgetTitle + "!", "The 'Remove' drop down item was displayed as expected");
					break;
				case "not displayed":
					Report.IsTrue(!new Dashboard().RemoveDropDownItemDisplayed(widgetTitle), "The 'Remove' drop down item was displayed for widget: " + widgetTitle + " when it was not expected to be!", "The 'Remove' drop down item was not displayed as expected");
					break;
				default:
					Report.Error("The step parameter must be set to either 'displayed' or 'not displayed'!");
					return;
			}
		}

		[RegexStepDefinition(@"I click the 'Remove' drop down item for widget: (.*)")]
		public void ClickRemoveDropDownItem(string widgetTitle)
		{
			Report.IsTrue(new Dashboard().ClickRemoveDropDownItem(widgetTitle), "Failed to click 'Remove' drop down item!", "Successfully clicked 'Remove' drop down item");
		}

		[RegexStepDefinition(@"I confirm the WERCSLink: (.*) page has loaded")]
		public void ConfirmWercsLinkPageHasLoaded(string page)
		{
			switch (page)
			{
				case "Dashboard":
					Report.IsTrue(new Dashboard().Wait_For_Load(), "The Dashboard page did not load!", "The Dashboard page loaded");
					break;
				case "Key Performance Indicators":
					Report.IsTrue(new KeyPerformanceIndicators().Wait_For_Load(), "The KPI page did not load!", "The KPI page loaded");
					break;
				case "Services":
					Report.IsTrue(new Services().Wait_For_Load(), "The Services page did not load!", "The Services page loaded");
					break;
				default:
					Report.Info("Step parameter did not match any valid page! Pages are: Dashboard, Key Performance Indicators, Services");
					return;
			}
		}

		[RegexStepDefinition(@"I Confirm the 'Enter WPS ID or Product Name' filter input is displayed in the Message Center widget")]
		public void ConfirmFilterInputIsDisplayedInTheMessageCenterWidget()
		{
			Dashboard.MessageCenter messageCenter = new Dashboard().GetMessageCenter();
			Report.IsTrue(messageCenter.FilterPlaceholder == "Enter WPS ID or Product Name", "The 'Enter WPS ID or Product Name' input was not displayed!", "The 'Enter WPS ID or Product Name' input was displayed as expected");
		}

		[RegexStepDefinition(@"I confirm that the: (.*) dashboard widget contains a (pie|bar) chart")]
		public void ConfirmDashboardWidgetContainsChart(string widget, string chartType)
		{
			if (new Dashboard().WidgetContainer(widget) == null)
			{
				Report.Failure("Widget: " + widget + " was not found on the dashboard!");
				Report.Screenshot();
				return;
			}
			Dashboard.WidgetGraph graph = new Dashboard().GetGraph(widget);
			if (graph == null)
			{
				Report.Failure("No graph was displayed for widget: " + widget);
				Report.Screenshot();
				return;
			}
			switch (chartType)
			{
				case "pie":
					Report.IsTrue(graph.Type == Dashboard.GraphType.Pie, "The graph type was not pie!", "The graph type was pie as expected");
					break;
				case "bar":
					Report.IsTrue(graph.Type == Dashboard.GraphType.Bar, "The graph type was not bar!", "The graph type was bar as expected");
					break;
				default:
					Report.Error("Step parameter must be set to either 'bar' or 'pie'!");
					return;
			}

		}

		[RegexStepDefinition(@"I confirm that the Subscription Status widget displays centered heading with text: (.*)")]
		public void ConfirmSubscriptionStatusWidgetDisplaysCenteredHeading(string headingText)
		{
			Dashboard.SubscriptionStatus subscriptionStatus = new Dashboard().GetSubscriptionStatus();
			if (subscriptionStatus == null)
			{
				Report.Failure("No Subscription Status widget was found!");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(subscriptionStatus.CenterHeading == headingText, "Heading text did not match expected: " + headingText + "!", "Heading text matched expected");
		}
	}

}

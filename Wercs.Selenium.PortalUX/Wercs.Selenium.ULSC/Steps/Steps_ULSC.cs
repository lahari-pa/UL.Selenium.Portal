using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.ULSC.Steps
{
	[Binding, Scope(Tag = "ULSC")]
	class StepsUlsc
	{

		[StepDefinition(@"I should see the following option (.*)")]
		public void ThenIShouldSeeTheFollowingOption(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount, "Checking that the option " + option + " is showing");
			try
			{
				var selUlSolutionCenter = new UlSolutionCenter();

				if (!selUlSolutionCenter.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				var optionShowing = selUlSolutionCenter.OptionShowing();

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
		//[StepDefinition(@"I click the Learn More button")]
		//public void ClickLearnMorebutton()
		//{
		//	TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking 'Learn More button'");
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

		[Given(@"I navigate to Studio for ULSC")]
		public void GivenINavigateToStudioULSC()
		{
			SeleniumBrowser.WebBrowser.Url = TReVor.TestVariables.GetVariableSavedAs("TestUrl");
			SeleniumBrowser.WebBrowser.WaitForPageLoad();

		}

		[Given(@"I login to Studio as ULSC")]
		public void GivenILoginToStudioAsULSCUser()
		{
			StudioLogin thisStudioLogin = new StudioLogin();
			var ulscUser = TReVor.TestUsers.GetUserSavedAs("StudioUser");
			thisStudioLogin.Username = ulscUser.Username;
			thisStudioLogin.Password = ulscUser.Password;
			thisStudioLogin.ClickSignIn();
			Delay.Seconds(3);
			StudioDesktop thisStudioDesktop = new StudioDesktop();
			Report.IsTrue(thisStudioDesktop.Wait_for_load(30), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
			Report.Info("Studio desktop is loaded");
			StudioTopMenu thisStudioTopMenu = new StudioTopMenu();
			Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");
		}

		[Given(@"the ULSC Login page should open in a new tab")]
		public void GivenTheULSCLoginPageShouldOpenInANewTab()
		{
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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

		[StepDefinition(@"In the ULSC Login page I enter Username and password for the following account: (.*)")]
		public void GivenInTheULSCLoginPageIEnterUsernameAndPasswordForTheFollowingAccountTest(string accountSavedAs)
		{
			ULSCLogin thisULSCLogin = new ULSCLogin();
			var user = TReVor.TestUsers.GetUserSavedAs(accountSavedAs);
			if (Report.IsTrue(user != null, "Failed to find user saved as: " + accountSavedAs, "Successfully found user saved as: " + accountSavedAs, true))
			{
				thisULSCLogin.Username = user.Username;
				thisULSCLogin.Password = user.Password;
			}
		}

		[StepDefinition(@"I the ULSC Login page I click Login")]
		public void GivenITheULSCLoginPageIClickLogin()
		{
			ULSCLogin thisULSCLogin = new ULSCLogin();
			Report.IsTrue(thisULSCLogin.ClickLogIn(), "Failed to click login in the ULSC login page",
				"Clicked login on the ULSC login page");
		}

		[StepDefinition(@"I should see the WERCSLink dashboard")]
		public void GivenIShouldSeeTheWERCSLinkDashboard()
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			Report.IsTrue(thisWercsLinkDashboard.Wait_for_load(60), "WERCSlink dashboard has not opened.",
				"WERCSlink dasboard is showing as expected");
		}

		[StepDefinition(@"In the WERCSLink dashboard I click menu item: (.*) and submenu item: (.*)")]
		public void GivenInTheWERCSLinkDashboardIClickMenuItemAndSubmenuItem(string menu, string submenu)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			Report.IsTrue(thisWercsLinkDashboard.ClickMenuAndSubMenuOption(menu, submenu), "Failed to click menu item: " + menu + " and submenu item: " + submenu,
				"Clicked menu item: " + menu + " and submenu item: " + submenu);
		}

		[StepDefinition(@"In the WERCSLink dashboard I click left menu link: (.*)")]
		public void GivenInTheWERCSLinkDashboardIClickLeftMenuLink(string menu)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			Report.IsTrue(thisWercsLinkDashboard.ClickLeftLink(menu), "Failed to click left menu link " + menu,
				"Clicked menu item: " + menu);
		}

		[StepDefinition(@"I Confirm the WerCSMart Product Information page is shown in new window/tab")]
		public void GivenIConfirmTheWerCSMartProductInformationPageIsShownInNewWindowTab()
		{
			Delay.Seconds(30);
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
			Report.Failure("Failed to find the correct tab! The available tabs (with screenshots) were:");
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
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

		[StepDefinition(@"I close the tab with the (.*) page")]
		public void GivenICloseTheTabWithTheProductInformationPage(string page)
		{
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				switch (page)
				{
					case "The Product":
						var selNewProduct = new NewProduct();
						if (selNewProduct.Wait_for_load())
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
						if (selNewProductnp.Wait_for_load())
						{

							Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
								"Closed tab with url: " + url);
							return;
						}
						break;
					case "ULGHS.COM":
						string targetURL = TReVor.TestVariables.GetVariableSavedAs("ULGHS.COM");
						if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
						{
							Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
								"Closed tab with url: " + url);
							return;
						}
						break;
					case "Data Management":
						string targetURLDM = TReVor.TestVariables.GetVariableSavedAs("studio");
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
				if(SeleniumBrowser.WebBrowser.Title.Contains("WERCSmart"))
				{
					string ulrToClose = SeleniumBrowser.GetActiveTabURL();
					Report.Info("Attemping to close: " + ulrToClose);
					Report.IsTrue(SeleniumBrowser.CloseTabWithURL(ulrToClose), "Failed to close tab with url: " + ulrToClose,
						"Closed tab with url: " + ulrToClose);
					return;
				}
			}
		}

		[StepDefinition(@"I navigate to tab with title: (.*)")]
		public void GivenINavigateToTabWithTitle(string tabTitle)
		{
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				if (SeleniumBrowser.WebBrowser.Title.Contains(tabTitle))
				{
					Report.Info("Switched to url: " + url);
					return;
				}
			}

			Report.Error("Failed to switch to tab with title: " +tabTitle);
		}

		[StepDefinition(@"In the WERCSLink page - Click the (.*) link from the (.*) area of the Services page")]
		public void GivenInTheWERCSLinkPage_ClickTheMyProductLinkFromTheWERCSmartAreaOfTheServicesPage(string link, string area)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();

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

		[StepDefinition(@"I Confirm a new window opens with the WERCSmart New Product page shown")]
		public void GivenIConfirmANewWindowOpensWithTheWERCSmartNewProductPageShown()
		{
			Delay.Seconds(30);
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
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

		[StepDefinition(@"I confirm that the WERCSLink header appears at the top left")]
		public void GivenIConfirmThatTheWERCSLinkHeaderAppearsAtTheTopLeft()
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			Report.IsTrue(thisWercsLinkDashboard.TopLeftTitleExists("WERCSLink"), "Failed to find top left title WERCSLink",
				"Found top left title: WERCSLink");
		}

		[StepDefinition(@"I confirm that the following WERCSLink menu items are showing")]
		public void GivenIConfirmThatTheFollowingWERCSLinkMenuItemsAreShowing(Table table)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			List<string> menuItems = thisWercsLinkDashboard.getLeftMenuItems();

			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Report.IsTrue(menuItems.Contains(thisRow["Menu item"]), "Failed to find menu item: " + thisRow["Menu item"],
					"Found left menu item: " + thisRow["Menu item"]);
			}

		}

		[StepDefinition(@"I confirm that the WERCSLink screen shows the following sections")]
		public void GivenIConfirmThatTheWERCSLinkScreenShowsTheFollowingSections(Table table)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			List<string> sections = thisWercsLinkDashboard.getSectionTitles();

			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Report.IsTrue(sections.Contains(thisRow["Section"]), "Failed to find menu item: " + thisRow["Section"],
					"Found left menu item: " + thisRow["Section"]);
			}
		}

		[StepDefinition(@"I confirm the WERCSmart area shows the WERCSmart logo, name and Registered trade mark")]
		public void GivenIConfirmTheWERCSmartAreaShowsTheWERCSmartLogoNameAndRegisteredTradeMark()
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			List<string> images = thisWercsLinkDashboard.getSectionImages("WERCSmart®");
			Report.IsTrue(images.Contains("wercsmart-logo"), "Logo is not showing as expected",
				"Logo is showing as expected");
			List<string> titles = thisWercsLinkDashboard.getSectionTitles();
			Report.IsTrue(titles.Contains("WERCSmart®"), "Wercsmart title and registered trademark is not showing as expected",
				"Wercsmart title and registered title is showing as expected");
		}

		[StepDefinition(@"I confirm that in the (.*) area the description text reads (.*)")]
		public void GivenIConfirmThatInTheAreaTheDescriptionTextReads(string section, string expectedText)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			string actualText = thisWercsLinkDashboard.getSectionBlurb(section);
			Report.IsTrue(actualText == expectedText,
				"Expected text was: " + expectedText + " actual text was: " + actualText);
		}

		[StepDefinition(@"I confirm that in the (.*) area the following links exist:")]
		public void GivenIConfirmThatInTheWERCSmartAreaTheFollowingLinksExist(string section, Table table)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			List<WERCSLinkLink> links = thisWercsLinkDashboard.getSectionLinks(section);

			//| Link title | Link icon |
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				var matchingLink = links.FirstOrDefault(x => x.LinkTitle == thisRow["Link title"]);
				Report.IsTrue(matchingLink!=null, "Failed to find matching link: " + thisRow["Link title"],
					"Found matching link: " + thisRow["Link title"]);

				if (matchingLink != null)
				{
					Report.IsTrue(matchingLink.Icon==thisRow["Link icon"], "Failed to find matching icon: " + thisRow["Link icon"],
						"Found matching icon: " + thisRow["Link icon"]);

				}
			}
		}

		[StepDefinition(@"I confirm that in the (.*) area the following subheadings appear:")]
		public void GivenIConfirmThatInTheWERCSmartAreaTheFollowingSubheadingsAppear(string section, Table table)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			List<string> subheadings = thisWercsLinkDashboard.getSectionSubheadings(section);

			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				var matchingSubheading = subheadings.FirstOrDefault(x => x == thisRow["Subheading"]);
				Report.IsTrue(matchingSubheading != null, "Failed to find matching subheading: " + thisRow["Subheading"],
					"Found matching subheading: " + thisRow["Subheading"]);
			}
		}

		[StepDefinition(@"I confirm that in the (.*) area the following images appear:")]
		public void GivenIConfirmThatInTheWERCSmartAreaTheFollowingImagesAppear(string section, Table table)
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			List<string> images = thisWercsLinkDashboard.getSectionImages(section);

			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				var matchingImage = images.FirstOrDefault(x => x == thisRow["Image"]);
				Report.IsTrue(matchingImage != null, "Failed to find matching image: " + thisRow["Image"],
					"Found matching image: " + thisRow["Image"]);
			}
		}

		[StepDefinition(@"I confirm a new window opens with the ULGHS.com page shown")]
		public void GivenIConfirmANewWindowOpensWithTheULGHSPageShown()
		{
			Delay.Seconds(30);
			string targetURL = TReVor.TestVariables.GetVariableSavedAs("ULGHS.COM");
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);

				if(SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
				{
					Report.Success("Self-Service GHS SDS page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screen shots) were:");
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
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

		[StepDefinition(@"I Confirm New window opens with the Studio Data Management window open \(Welcome page shows\) and that NO script errors display")]
		public void GivenIConfirmNewWindowOpensWithTheStudioDataManagementWindowOpenWelcomePageShowsAndThatNOScriptErrorsDisplay()
		{
			Delay.Seconds(30);
			string targetURL = TReVor.TestVariables.GetVariableSavedAs("Studio");
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);

				if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
				{
					Report.Success("Studio Data management page opened. Successfully switched to that tab.");
					StudioPowerDesignerPlus thisStudioPowerDesignerPlus = new StudioPowerDesignerPlus();

					Report.IsTrue(thisStudioPowerDesignerPlus.Wait_for_load(120),
						"Waiting for power designer load failed", "Welcome page loaded as expected");

					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs (with screen shots) were:");
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();
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

		[StepDefinition(@"I Close the Data Management window")]
		public void GivenICloseTheDataManagementWindow()
		{
			ScenarioContext.Current.Pending();
		}

		
	}
}

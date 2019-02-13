using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using NTTQA_TReVor_Module.Cache;
using OpenQA.Selenium;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;


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
			SeleniumBrowser.WebBrowser.Url = TestVariables.GetVariableSavedAs("TestUrl");
			SeleniumBrowser.WebBrowser.WaitForPageLoad();

		}

		[Given(@"I login to Studio as ULSC")]
		public void GivenILoginToStudioAsULSCUser()
		{
			StudioLogin thisStudioLogin = new StudioLogin();
			var ulscUser = TestUsers.GetUserSavedAs("StudioUser");
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
			var user = TestUsers.GetUserSavedAs(accountSavedAs);
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

			Report.Error("Failed to switch to tab with title: " + tabTitle);
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
			var menuItems = new WERCSLinkDashboard().GetSideBarNavLinks().Select(x => x.Title).ToList();
			foreach (var thisRow in table.Rows)
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
				Report.IsTrue(matchingLink != null, "Failed to find matching link: " + thisRow["Link title"],
					"Found matching link: " + thisRow["Link title"]);

				if (matchingLink != null)
				{
					Report.IsTrue(matchingLink.Icon == thisRow["Link icon"], "Failed to find matching icon: " + thisRow["Link icon"],
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
			string targetURL = TestVariables.GetVariableSavedAs("ULGHS.COM");
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
			string targetURL = TestVariables.GetVariableSavedAs("Studio");
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

		[Given(@"I navigate to WERCSmart")]
		public void GivenINavigateToWERCSmart()
		{
			var Branch = GlobalParameters.Branch;
			string regexPattern = @"^.*(?=(\/))";
			Regex regex = new Regex(regexPattern);
			Match match = regex.Match(Branch);
			if (match.Success)
			{
				var url = TestVariables.GetVariableSavedAs("TestURL", "3", match.Value);
				SeleniumBrowser.WebBrowser.Url = url;
				SeleniumBrowser.WebBrowser.WaitForPageLoad();
			}
			else
			{
				throw new Exception("Wercsmart URL could not be found");
			}
		}

		[Then(@"I Confirm New window opens with the error message: (.*)")]
		public void GivenIConfirmNewWindowOpensWithErrorMessages(string errorMessage)
		{
			Delay.Seconds(30);
			string currentURL = SeleniumBrowser.WebBrowser.Url;
			string targetURL = "ULSC";
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
			{
				//Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);

				if (SeleniumBrowser.WebBrowser.Url.Contains(targetURL))
				{
					Report.Success("Additional tab opened. Successfully switched to that tab.");
					StudioPowerDesignerPlus thisStudioPowerDesignerPlus = new StudioPowerDesignerPlus();

					var body = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//body"), 2);
					Report.IsTrue(body.GetElementText().Trim() == errorMessage,
						"Expected error message: " + errorMessage + " but got: " + body.GetElementText(),
						"As expected, error message is showing: " + errorMessage);

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

		[StepDefinition(@"I confirm the left hand navigation is displayed under WercsLink")]
		public void ConfirmLeftHandNavigationDisplayed()
		{
			Report.IsTrue(new WERCSLinkDashboard().GetSideBarNavLinks().Any(x => !string.IsNullOrEmpty(x.Title)),
				"The left hand navigation did not load with any items!",
				"The left hand navigation loaded with items as expected");
		}

		[StepDefinition(@"I confirm the following widget panels are displayed on the Dashboard:")]
		public void ConfirmWidgetPanelsDisplayedOnTheDashboard(Table table)
		{
			var expectedWidgets = new List<string>();
			table.Rows.ForEach(x => expectedWidgets.Add(x["Widget"]));
			var actualWidgets = new WERCSLinkDashboard().DashboardWidgetTitles();
			var success = true;
			foreach (var widget in expectedWidgets)
			{
				if (actualWidgets.Contains(widget))
				{
					continue;
				}
				success = false;
				Report.Failure("Widget: " + widget + " was not displayed!");
				Report.Screenshot();
			}
			if (success)
			{
				Report.Success("All expected widgets were displayed: " + string.Join(", ", expectedWidgets));
				Report.Screenshot();
			}
			//Report.IsTrue(expectedWidgets.All(x => actualWidgets.Contains(x)),
			//	"Expected to see the following widgets: " + string.Join(", ", expectedWidgets + " But found: " + string.Join(", ", actualWidgets)),
			//	"The following widgets were displayed as expected: " + string.Join(", ", expectedWidgets));
		}

		[StepDefinition(@"I Confirm the Layout shows a header, left hand navigation, Message center and KPI areas")]
		public void ConfirmDashboardLayout_Header_LeftHandNavigation_MessageCenter_KPIAreas()
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I confirm the WERCSLink header is displayed");
			this.GivenIConfirmThatTheWERCSLinkHeaderAppearsAtTheTopLeft();
			TestReport.StartStep("I confirm the left hand navigation is displayed under WercsLink");
			this.ConfirmLeftHandNavigationDisplayed();
			TestReport.StartStep("I confirm the Message widget panel is displayed on the Dashboard:");
			var table = new Table("Widget");
			table.AddRow("Message Center");
			this.ConfirmWidgetPanelsDisplayedOnTheDashboard(table);
			TestReport.StartStep("I confirm the KPI widget panels are displayed on the Dashboard");
			var kpiTitles = new List<string> { "Products By Retailer and Status", "RUs by Category", "Products by Recertification Reason", "Products by RU", "RUs by Category by Retailer", "Subscription Status" };
			table = new Table("Widget");
			foreach (var title in kpiTitles)
			{
				table.AddRow(title);
			}
			this.ConfirmWidgetPanelsDisplayedOnTheDashboard(table);
		}

		[StepDefinition(@"I confirm the WERCSLink sidebar menu icon is displayed")]
		public void IConfirmTheWercsLinkSidebarMenuIconIsDisplayed()
		{
			Report.IsTrue(new WERCSLinkDashboard().WercsLinkNavigationButtonDisplayed(), "The WERCSLink sidebar menu icon was not displayed!", "The WERCSLink sidebar menu icon was displayed as expected");
		}

		[StepDefinition(@"I click the WERCSLink sidebar menu icon")]
		public void IClickTheWercsLinkSidebarMenuIcon()
		{
			Report.IsTrue(new WERCSLinkDashboard().ClickWercsLinkNavigationButton(), "Failed to click the WERCSLink sidebard navigation button", "Successfully clicked the WERCSLink sidebard navigation button");
		}

		[StepDefinition(@"I confirm the left hand navigation list is (collapsed|expanded)")]
		public void ConfirmLeftNavigationCollapsesWithTitlesNotDisplayed(string navState)
		{
			var sideBarItems = new WERCSLinkDashboard().GetSideBarNavLinks();
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

		[StepDefinition(@"I confirm the user button in the header displays the logged in username")]
		public void ConfirmUserButtonDisplaysLoggedInUserName()
		{
			var user = TestUsers.GetUserSavedAs("WercsUser");
			if (user == null)
			{
				Report.Failure("No ULCS WercsUser found for current branch in TReVor");
				return;
			}
			var username = user.Username;
			var displayedUser = new WERCSLinkDashboard().UserButtonText();
			Report.IsTrue(displayedUser == username, "Expected username in the header to be: " + user + " but was: " + displayedUser + "!", "Username: " + username + " was displayed in the header as expected");
		}

		[StepDefinition(@"I click the user button in the header")]
		public void ClickHeaderUserButton()
		{
			Report.IsTrue(new WERCSLinkDashboard().ClickUserButton(), "Failed to click the user button in the header!", "Successfully clicked the user button in the header");
		}

		[StepDefinition(@"I confirm the Reset Dashboard icon is displayed next to the user button in the header")]
		public void ConfirmResetDashboardIconDisplayed()
		{
			Report.IsTrue(new WERCSLinkDashboard().ResetDashboardIconDisplayed(), "The Reset Dashboard icon was not displayed in the header!", "The Reset Dashboard icon was displyed in the header as expected");
		}

		[StepDefinition(@"I click the Reset Dashboard icon next to the user button in the header")]
		public void ClickResetDashboardIcon()
		{
			Report.IsTrue(new WERCSLinkDashboard().ClickResetDashboardIcon(), "Failed to click the Reset Dashboard icon in the header!", "Successfully clicked the Reset Dashboard icon in the header");
		}

		[StepDefinition(@"I confirm the Reset Dashboard dropdown item is displayed underneath the header icon")]
		public void ConfirmResetDashboardDropDownItemDisplayed()
		{
			Report.IsTrue(new WERCSLinkDashboard().ResetDashboardDropdownItemDisplayed(), "The Reset Dashboard dropdown item was not displayed under the header icon!", "The Reset Dashboard dropdown item was displyed under the header icon as expected");
		}

		[StepDefinition(@"I confirm a new tab opens with url: (.*)")]
		public void ConfirmNewTabOpenWithUrl(string url)
		{
			new GlobalSteps().SwitchToTheTab(url);
		}

		[StepDefinition(@"I confirm the Sign Out dropdown item is (displayed|not displayed)")]
		public void ConfirmSignOutDropdownDisplayed(string visibility)
		{
			if (visibility == "displayed")
			{
				Report.IsTrue(new WERCSLinkDashboard().SignOutDropDownItemDisplayed(), "The Sign Out dropdown item was not displayed when it was expected to be!", "The Sign Out dropdown item was displayed as expected");
			}
			else if (visibility == "not displayed")
			{
				Report.IsTrue(!new WERCSLinkDashboard().SignOutDropDownItemDisplayed(), "The Sign Out dropdown item was displayed when it was not expected to be!", "The Sign Out dropdown item was not displayed as expected");
			}
			else
			{
				Report.Error("Step parameter must be either 'displayed' or 'not displayed'!");
			}
		}

		[StepDefinition(@"I confirm the UL Logo is displayed next to the user button in the header")]
		public void ConfirmTheUlLogoIsDisplayedHeader()
		{
			Report.IsTrue(new WERCSLinkDashboard().ULLogoDisplayed(), "The UL Logo was not displayed in the header!", "The UL logo was displayed in the header as expected");
		}

		[StepDefinition(@"I click the UL Logo next to the user button in the header")]
		public void ClickTheUlLogoHeader()
		{
			Report.IsTrue(new WERCSLinkDashboard().ClickULLogo(), "Failed to click the UL Logo in the header!", "Successfully clicked the UL logo in the header");
			Delay.Seconds(10);
		}
	}

}

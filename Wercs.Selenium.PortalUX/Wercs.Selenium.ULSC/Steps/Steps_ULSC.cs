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
				Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='products-information']"), 2) != null)
				{
					Report.Success("Product information page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab! The available tabs were:");
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs().ToList();

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				Report.Info("url: " + url);
				Report.Screenshot();
			}
		}

		[StepDefinition(@"I close the tab with the Product Information page")]
		public void GivenICloseTheTabWithTheProductInformationPage()
		{
			{
				List<string> OpenBrowsers =
					SeleniumBrowser.GetTabURLs().ToList();

				foreach (string url in OpenBrowsers)
				{
					SeleniumBrowser.SwitchToTabWithURL(url);
					if (new PortalUX.Selenium_Classes.Homepage().Wait_for_load())
					{
						Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
							"Closed tab with url: " + url);
						return;
					}
				}

				//We may be on the wrong page, just find one for WERCSmart
				Report.Error("Failed to find expected tab");
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

		[StepDefinition(@"In the WERCSLink page - Click the My Product link from the WERCSmart area of the Services page")]
		public void GivenInTheWERCSLinkPage_ClickTheMyProductLinkFromTheWERCSmartAreaOfTheServicesPage()
		{
			WERCSLinkDashboard thisWercsLinkDashboard = new WERCSLinkDashboard();
			Report.IsTrue(thisWercsLinkDashboard.ClickMainPageLink("My Products"), "Failed to click link: My Products",
				"Clicked My Products");
		}

	}
}

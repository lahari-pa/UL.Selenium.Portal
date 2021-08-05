using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using UL.Automation.Utilities.Functions;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RuleWriter;

[assembly: Apartment(ApartmentState.STA)]

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding]
	public class GlobalSteps
	{
		[BeforeFeature(Order = 1)]
		public static void SetTestURL()
		{
			SeleniumBrowser.BaseTestUrl = TestVariables.GetVariableSavedAs("TestURL");
		}

		[BeforeFeature(Order = 2)]
		public static void BeforeTestKillChrome()
		{
			Process.GetProcessesByName("chromedriver").ToList().ForEach(x => x.Kill());
		}

		[AfterFeature(Order = 1)]
		public static void CloseChrome()
		{
			//Process.GetProcessesByName("chrome").ToList().ForEach(x => x.Kill());
			Process.GetProcessesByName("chromedriver").ToList().ForEach(x => x.Kill());
		}



		[StepDefinition(@"I login as the administrator")]
		public void GivenILoginAsTheAdministrator()
		{
			this.LoginToAccount("ProductAccount");
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - (WERCs Visual Account|WERCs Premium Subscription Account|WERCs Product Account|WERCs ULSC Account|NoPLProducts Account|Password Reset|WERCs Web Viewers)")]
		public void LoginToWERCSmartAdmin(string type)
		{
			switch (type)
			{
				case ("WERCs Visual Account"):
					this.LoginToAccount("VisualAccount");
					break;
				case ("WERCs Premium Subscription Account"):
					this.LoginToAccount("PremiumSubscriptionAccount");
					break;
				case ("WERCs Product Account"):
					this.LoginToAccount("ProductAccount");
					break;
				case ("WERCs ULSC Account"):
					this.LoginToAccount("ULSCAccount");
					break;
				case ("NoPLProducts Account"):
					this.LoginToAccount("NoPLProducts Account");
					break;
				case ("Password Reset"):
					this.LoginToAccount("PasswordResetAccount");
					break;
				case ("WERCs Web Viewers"):
					this.LoginToAccount("FeedToWebViewers");
					break;
			}
		}

		[StepDefinition(@"I retrieve the email address for account: (.*) and save as: (.*)")]
		public void IRetrieveTheEmailAddressForAccount(string type, string saveAs)
		{
			string email = "";
			switch (type)
			{
				case ("WERCs Visual Account"):
					email = this.GetEmailForAccount("VisualAccount");
					break;
				case ("WERCs Premium Subscription Account"):
					email = this.GetEmailForAccount("PremiumSubscriptionAccount");
					break;
				case ("WERCs Product Account"):
					email = this.GetEmailForAccount("ProductAccount");
					break;
				case ("WERCs ULSC Account"):
					email = this.GetEmailForAccount("ULSCAccount");
					break;
				case ("NoPLProducts Account"):
					email = this.GetEmailForAccount("NoPLProducts Account");
					break;
			}

			if (email == "")
			{
				Report.Failure("Could not find email for account " + type);
				return;
			}

			Context.AddToContext(saveAs, email);
		}


		[StepDefinition(@"I login into the WERCSmart Portal - (data consent Account|Division Account|Administrator Role|Canada has all data account|WebViewers Account)")]
		[StepDefinition(@"I Login into WERCSmart Portal - (data consent Account|Division Account|Administrator Role|Canada has all data account|WebViewers Account)")]
		public void LoginToWERCSmart(string type)
		{
			//if alredy logged in, logout
			if (new TopMenuBar().LoggedIn())
			{
				new TopMenuBar().ClickSignOut();
				Delay.Seconds(3);
			}
			switch (type)
			{
				case ("data consent Account"):
					this.LoginToAccount("DataConsentAccount");
					break;
				case ("Division Account"):
					this.LoginToAccount("DivisionAccount");
					break;
				case ("Administrator Role"):
					this.LoginToAccount("ProductAccount");
					break;
				case ("Canada has all data account"):
					this.LoginToAccount("CanadaHasAllData");
					break;
				case ("WebViewers Account"):
					this.LoginToAccount("FeedToWebViewers");
					break;
			}
		}

		[StepDefinition(@"I log in with the (subscription|without subscription) without products account")]
		public void LoginWithSubscriptionType(string type)
		{
			switch (type)
			{
				case ("subscription"):
					this.LoginToAccount("SubCart");
					break;
				case ("without subscription"):
					this.LoginToAccount("ProductsInCart");
					break;
			}
		}

		[StepDefinition(@"I log in with the account saved in TReVor as: (.*)")]
		public void ILogInWithTheAccountSavedInTrevorAs(string accountSavedAs)
		{
			this.LoginToAccount(accountSavedAs);
		}

		[StepDefinition(@"The home screen should load")]
		public void ThenTheHomeScreenShouldLoad()
		{
			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.WaitForContainerToBeVisible(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
			GeneralUtilities.Wait_for_load_finish();

		}

		public string GetEmailForAccount(string accountSavedAs)
		{
			TReVorTestUsers user = TestUsers.GetUserSavedAs(accountSavedAs);
			if (user == null)
			{
				string Branch = TReVorSettings.SoftwareBranch;
				string regexPattern = @"^.*(?=(\/))";
				var regex = new Regex(regexPattern);
				Match match = regex.Match(Branch);
				if (match.Success)
				{
					user = TestUsers.GetUserSavedAs(accountSavedAs, "3", match.Value);
				}
				else
				{
					throw new Exception("User: " + accountSavedAs + " could not be found");
				}
			}

			return user.Username;
		}

		public void LoginToAccount(string accountSavedAs, bool attemptOnce = false)
		{
			TReVorTestUsers user = TestUsers.GetUserSavedAs(accountSavedAs);

			if (new TopMenuBar().LoggedIn())
			{
				Report.Info("Logged in, logging out");
				Report.IsTrue(new TopMenuBar().ClickSignOut(), "Failed to click Sign Out");
			}

			if (user == null)
			{
				string Branch = TReVorSettings.SoftwareBranch;
				string regexPattern = @"^.*(?=(\/))";
				var regex = new Regex(regexPattern);
				Match match = regex.Match(Branch);
				if (match.Success)
				{
					user = TestUsers.GetUserSavedAs(accountSavedAs, "3", match.Value);
				}
				else
				{
					throw new Exception("User: " + accountSavedAs + " could not be found");
				}
			}
			if (Report.IsTrue(user != null, "Failed to find user saved as: " + accountSavedAs, "Successfully found user saved as: " + accountSavedAs, true))
			{
				if (attemptOnce)
				{
					this.AttemptToLoginWithEmailAndPassword(user.Username, user.Password);
					new StepsHomepage().IfDataConsentRequestsModalIsShowingAddRequiredTiers();
					return;
				}
				this.GivenILogInWithEmailXAndPasswordY(user.Username, user.Password);
				new StepsHomepage().IfDataConsentRequestsModalIsShowingAddRequiredTiers();
			}
		}

		/// <summary>
		/// Requires a user object of type User (WercSmart.Classes.User) not TestUser (TReVor)
		/// </summary>
		[StepDefinition(@"I log in as the user saved as: (.*)")]
		public void LoginToCurrentNewUser(string savedAs)
		{
			//var newUser = (User)Context.GetFromContext(savedAs);
			var newUser = (WERCSmartUser)Context.GetFromContext(savedAs);

			//give savedAs and get the password and email
			string email = newUser.Email;
			string password = newUser.Password;

			Report.Info("Clicking 'Log In' on the Landing Page");
			Report.IsTrue(new LandingPage().Click_Login(), "Failed to click Log In", "Successfully clicked Log In");
			new StepsLogin().GivenIPopulateTheInputFieldWith("email", email);
			new StepsLogin().GivenIPopulateTheInputFieldWith("password", password);
			Report.Screenshot();
			new StepsLogin().IClickTheLoginButton();
			Report.IsTrue(new Login().WaitForContainerToBeInvisible(), "Did not redirect from Log in page!");



		}




		[StepDefinition(@"I log in with email: (.*) and password: (.*)")]
		// requires the user to be on the landing page
		public void GivenILogInWithEmailXAndPasswordY(string username, string password)
		{
			Report.Info("Beginning I login with email and password");
			var selLandingPage = new LandingPage();
			if (!selLandingPage.WaitForContainerToBeVisible(120))
			{
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//p[contains(text(),'HTTP Error 503')]"), 120) != null)
				{
					throw new Exception("HTTP Server error 503 was thrown!");
				}
				throw new Exception("Landing page did not load!");
			}
			Report.Info("Clicking 'Log In' on the Landing Page");
			Report.IsTrue(selLandingPage.Click_Login(), "Failed to click Log In", "Successfully clicked Log In");
			var selTopMenuBar = new TopMenuBar();
			var selHomepage = new Homepage();
			int i = 0;


		

			while ((!selHomepage.WaitForContainerToBeVisible(2) || !selTopMenuBar.Wait_for_load(3)) && i < 4)
			{
				Report.Info("========== Login Attempt: " + i + " ==========");
				var selLogin = new Login();
				if (!Report.IsTrue(selLogin.WaitForContainerToBeVisible(), "Login page did not load!", "Login page loaded successfully!"))
				{
					break;
				}
				Report.Info("Entering Email: '" + username + "'");
				selLogin.EmailField = username;
				Report.Info("Entering Password: '" + password + "'");
				selLogin.PasswordField = password;
				Report.Info("Clicking login");
				Report.IsTrue(selLogin.Click_Login(), "Failed to click log in button");
				selHomepage = new Homepage();

				//wait 5 seconds max for the consent page/handle
				new StepsSignup().IfHomePageDoesNotLoadAcceptTermsOfUse();

				if (selHomepage.WaitForContainerToBeVisible())
				{
					Report.Success("Successfully logged in!");
					GeneralUtilities.Wait_for_load_finish();
					return;
				}
				var modalDialog = new ModalDialog();
				if (modalDialog.WaitForContainerToBeVisible(4))
				{
					modalDialog.Click_Closex();
					Delay.Seconds(Delay.SpeedFactor * 1);

					selHomepage = new Homepage();
					if (selHomepage.WaitForContainerToBeVisible(15))
					{
						Report.Success("Successfully logged in!");
						GeneralUtilities.Wait_for_load_finish();

						return;
					}
				}
				i++;
			}
			// JS - we already attempted in a loop 3 times- why are we repeating the code here?

			//var selLogin2 = new Login();
			//if (!Report.IsTrue(selLogin2.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!"))
			//{
			//	Report.Failure("Failed to log in!");
			//	return;
			//}
			//Report.Info("Entering Email: '" + username + "'");
			//selLogin2.EmailField = username;

			//Report.Info("Entering Password: '" + password + "'");
			//selLogin2.PasswordField = password;
			//Report.Info("Clicking login");
			//selLogin2.Click_Login();
			//selHomepage = new Homepage();
			//if (selHomepage.Wait_for_load(30))
			//{
			//	Report.Success("Successfully logged in!");
			//	GeneralUtilities.Wait_for_load_finish();
			//	return;
			//}
			//Report.Failure("Failed to log in!");
		}

		[StepDefinition(@"I attempt to log in with email: (.*) and password: (.*)")]
		// only do one attempt - used for reset passwords
		public void AttemptToLoginWithEmailAndPassword(string email, string password)
		{
			Report.Info("Beginning I login with email and password");
			var selLandingPage = new LandingPage();
			if (!selLandingPage.WaitForContainerToBeVisible(5))
			{
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//p[contains(text(),'HTTP Error 503')]"), 2) != null)
				{
					throw new Exception("HTTP Server error 503 was thrown!");
				}
				throw new Exception("Landing page did not load!");
			}

			Report.Info("Clicking 'Log In' on the Landing Page");
			Report.IsTrue(selLandingPage.Click_Login(), "Failed to click Log In", "Successfully clicked Log In");
			var selHomepage = new Homepage();
			var selLogin = new Login();
			if (!Report.IsTrue(selLogin.WaitForContainerToBeVisible(), "Login page did not load!", "Login page loaded successfully!"))
			{
				return;
			}

			Report.Info("Entering Email: '" + email + "'");
			selLogin.EmailField = email;
			Report.Info("Entering Password: '" + password + "'");
			selLogin.PasswordField = password;
			Report.Info("Clicking login");
			Report.IsTrue(selLogin.Click_Login(), "Failed to click the log in button");
			selLogin = new Login();
			// check we have redirected from the log in page
			if (!selLogin.WaitForContainerToBeInvisible())
			{
				if (!selLogin.Password_Error_Text().IsNullOrEmpty())
				{
					Report.Failure("Failed to log in - password error message was displayed");
					Report.Screenshot();
					return;
				}
				Report.Failure("Failed to log in");
				Report.Screenshot();
				return;
			}
			selHomepage = new Homepage();
			// check for home page

			new StepsSignup().IfHomePageDoesNotLoadAcceptTermsOfUse();

			if (selHomepage.WaitForContainerToBeVisible())
			{
				Report.Success("Successfully logged in!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
				return;
			}
			// dismiss modal dialog if it exists
			var modalDialog = new ModalDialog();
			if (modalDialog.Wait_for_load(1))
			{
				Report.Info("Closing modal dialog");
				modalDialog.Click_Closex();
				selHomepage = new Homepage();
				if (selHomepage.WaitForContainerToBeVisible())
				{
					Report.Success("Successfully logged in!");
					GeneralUtilities.Wait_for_load_finish();
					return;
				}
			}
			Report.Failure("Failed to log in");
			Report.Screenshot();
		}

		[StepDefinition(@"I logout")]
		public void GivenILogout()
		{
			var thisTopMenuBar = new TopMenuBar();
			Report.IsTrue(thisTopMenuBar.ClickSignOut(), "Failed to click sign out", "Successfully clicked sign out");
		}

		[StepDefinition(@"I create a new email address and save as: (.*)")]
		public void GivenICreateANewEmailAddressAndSaveAs(string saveAs)
		{
			string myDate = System.DateTime.Now.ToString("HHmmddMMyy");

			string myEmail = MailosaurFunctions.CreateEmail(myDate);
			UL.Automation.SpecFlow.Classes.Context.AddToContext(saveAs, myEmail);
			Report.Info("Saved email: " + myEmail);
		}

		[StepDefinition(@"If not already created, I create a user: (.*) with the following parameters:")]
		public void GivenIfNotAlreadyCreatedICreateAUserXWithTheFollowingParameters(string savedAs, Table parameters)
		{
			Report.StartStep(ReportSettings.StepCounter + "- If not already created, I create a user: '" + savedAs + "'");

			if (savedAs == "New_Sub")
			{
				savedAs = "New_Sub" + "_" + System.DateTime.Now.ToString("HHmmddMMyy");
				Context.FeatureContext.Add("CurrentAccount", savedAs);
			}

			try
			{
				if (!Context.FeatureContext.ContainsKey(savedAs))
				{
					Report.Info("Setting up account details for user: '" + savedAs + "'");
					WERCSmartUser account = parameters.CreateInstance<WERCSmartUser>();
					account.Email = MailosaurFunctions.CreateEmail(account.Email);
					account.Identifier = savedAs;
					UL.Automation.SpecFlow.Classes.Context.AddToContext(savedAs, account, true);
					Report.Success("Account details saved!");

					var mySignUp = new StepsSignup();
					var myLogin = new StepsLogin();
					var myLanding = new StepsLandingPage();
					var myHome = new StepsHomepage();

					mySignUp.GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
					myLogin.GivenIClickOnTheNewToWercsmartLink();
					mySignUp.ThenTheSignupPageShouldAppear();
					mySignUp.GivenIEnterSignupEmailUser(savedAs);
					mySignUp.GivenIConfirmSignupEmailUser(savedAs);
					mySignUp.GivenIClickOnSubmit();
					mySignUp.ThenTheSignupThankYouPageShouldAppear();
					mySignUp.ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "<SiteNotification>", "Link to create WERCSmart Account");
					mySignUp.ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount();
					mySignUp.WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage();
					mySignUp.WhenIEnterTheFollowingInformationIntoTheNewUserForm(savedAs);
					mySignUp.WhenInTheNewUserFormIClickOnContinue();
					mySignUp.ThenIShouldBeOnThePageOfTheForm("Security Questions");
					mySignUp.EnterTheFollowingIntoSecurityQuestions(savedAs);
					mySignUp.EnterPinForUser(savedAs);
					mySignUp.WhenInTheNewUserFormIClickOnContinue();
					myLanding.ClickTheLoginButton();
					myLogin.GivenILoginAsUser(savedAs);
					mySignUp.GivenIfTermsOfUsePageAppearsIAccept();
					myHome.ThenTheWercSmartHomepageShouldLoad();
				}
				Report.Info(savedAs + " Created");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I wait for (.*) seconds")]
		public void WhenIWaitForSeconds(int seconds)
		{
			for (int i = 0; i < seconds; i++)
			{
				Delay.Seconds(1);
				if (i % 60 == 0)
				{
					Report.Info("Waited for: " + i + " seconds");
				}
			}

			Report.Info("Waited for: " + seconds + " seconds");
		}

		[StepDefinition(@"I scroll to the (top|bottom) of the page")]
		public void ThenIScrollToTheOfThePage(string location)
		{
			Report.Info("Attempting to scroll to the " + location + " of the page");
			if (location == "top")
			{
				GeneralUtilities.ScrollToTopOfPage();
			}
			else if (location == "bottom")
			{
				GeneralUtilities.ScrollToBottomOfPage();
			}
			else
			{
				Report.Error("Step parameter must be 'top' or 'bottom'");
				return;
			}
			Report.Screenshot();
			Report.Success("Scrolled to the " + location + " of the page!");
		}

		[StepDefinition(@"I navigate to the landing page")]
		public void NavigateToLandingPage()
		{
			Report.StartStep(ReportSettings.StepCounter + " - Navigate to landing page");
			try
			{
				Report.Info("Navigating to the landing page");
				Report.Info("Checking the number of tabs that are open in the current window");
				ReadOnlyCollection<string> currentTabs = SeleniumBrowser.WebBrowser.WindowHandles;
				if (currentTabs.Count() == 1)
				{
					Report.Info("There was only 1 tab open, attempting to close and reopen chrome");
					Report.Info("Chrome Quit - Closing the chrome window");
					SeleniumBrowser.StopBrowser();
					//Report.Info("Attempting to initialize the chrome driver");
					//var chromeDriverService = ChromeDriverService.CreateDefaultService();
					Report.Info("Attempting to Open a chrome window");
					//SeleniumBrowser.WebBrowser =  new ChromeDriver(chromeDriverService, new ChromeOptions());
					//Report.Info("Attempting to maximize the window");
					SeleniumBrowser.StartBrowser(WebDriverType.Chrome);
					//SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
				}


				SeleniumBrowser.Navigate(SeleniumBrowser.BaseTestUrl);
				Delay.Seconds(1);
				ReadOnlyCollection<string> allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
				if (SeleniumBrowser.Alert.IsAlertPresent())
				{
					Report.Info("Alert is present, accepting");
					Report.Screenshot();
					SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
					Delay.Seconds(1);
					allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
					SeleniumBrowser.WebBrowser.SwitchTo().Window(allWindows[0]);
					Delay.Seconds(4);
					SeleniumBrowser.Navigate(SeleniumBrowser.BaseTestUrl);
					Delay.Seconds(4);
					allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
					if (SeleniumBrowser.Alert.IsAlertPresent())
					{
						Report.Info("Alert is present, accepting");
						Report.Screenshot();
						SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
						Delay.Seconds(1);
						allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
						SeleniumBrowser.WebBrowser.SwitchTo().Window(allWindows[0]);
						Delay.Seconds(2);
						allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
						if (allWindows.Count == 1)
						{
							Report.Success("Successfully navigated to the landing page!");
							Report.Screenshot();
							return;

						}
					}


				}

				try
				{
					allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
					Report.Info("Current tabs/windows open:");
					foreach (string windowHandle in allWindows)
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Window(windowHandle);
						Report.Info("url: " + SeleniumBrowser.GetActiveTabURL());
					}

					foreach (string windowHandle in allWindows)
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Window(windowHandle);

						if (SeleniumBrowser.GetActiveTabURL().Contains(SeleniumBrowser.BaseTestUrl))
						{
							Report.Info("Current url: " + SeleniumBrowser.GetActiveTabURL());
							SeleniumBrowser.Navigate(SeleniumBrowser.BaseTestUrl);
							Report.Success("Successfully navigated to the landing page!");
							Report.Screenshot();
							return;
						}
					}
				}
				catch (Exception e)
				{
					Report.Info(e.Message);
				}

				allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
				if (allWindows.Count > 1)
				{
					for (int i = 1; i < allWindows.Count + 1; i++)
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Window(allWindows[i]);
						SeleniumBrowser.WebBrowser.Close();
					}
				}
				allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
				if (allWindows.Count > 1)
				{
					Report.Error("Failed to navigate to landing page");
					Report.Screenshot();
					return;
				}
				else
				{
					Report.Success("Successfully navigated to the landing page!");
					Report.Screenshot();
					return;

				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I navigate to the URL: (.*)")]
		public void NavigateToTheUrl(string url)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Navigate to URL: " + url);
			try
			{
				Report.Info("Navigating to the URL: " + url);
				SeleniumBrowser.WebBrowser.Navigate().GoToUrl(url);
				Report.Success("Successfully navigated to the URL: " + url + "!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I check that the current URL contains: (.*)")]
		public void CurrentUrlContains(string url)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Checking that the current URL contains: " + url);
			try
			{
				Report.Info("Checking that the current URL contains: " + url);
				string currentUrl = SeleniumBrowser.WebBrowser.Url;
				Report.Info("Current URL is: " + currentUrl);
				Report.IsTrue(currentUrl.Contains(url),
					"Current URL was: " + currentUrl + ", which did not contain: " + url + "!",
					"Curreent URL contained " + url + ", as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I close the window that opened")]
		public void ThenCloseTheWindowThatOpened()
		{
			Delay.Seconds(5);
			Report.StartStep(ReportSettings.StepCounter + " - Closing current window");
			try
			{
				object mainWindowHandle = UL.Automation.SpecFlow.Classes.Context.GetFromContext("MainWindowHandle");

				if (mainWindowHandle == null)
				{
					throw new Exception("No Main Window Handle found in context!");
				}
				// if current window = main window then return
				Report.Info("Attempting to close the current window");
				SeleniumBrowser.WebBrowser.Close();
				Report.Info("Current window closed, switching to the MainWindowHandle");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(mainWindowHandle.ToString());
				Report.Success("Browser window switched successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"UNDER DEVELOPMENT")]
		public void Underdevelopment()
		{
			Report.StartStep(ReportSettings.StepCounter + " - UNDER DEVELOPMENT");
			try
			{
				Report.Warning("AREA UNDER DEVELOPMENT");
				Report.Failure("AREA UNDER DEVELOPMENT");
				var selBulkActions = new BulkActions();
				if (selBulkActions.WaitForContainerToBeVisible(5))
				{
					Report.Info("Closing Bulk Actions window as result is not yet developed");
					selBulkActions.ClickClose();
					Report.Screenshot();
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I save the current emails in the inbox for address saved as: (.*)")]
		public void GivenISaveTheCurrentEmailsInTheInboxForRandom(string savedas)
		{
			Report.StartStep(ReportSettings.StepCounter + "- I save the current emails in this inbox so I can locate the new one when it arrives");
			try
			{
				string emailAddress = UL.Automation.SpecFlow.Classes.Context.GetFromContext(savedas).ToString();
				Report.Info("Storing inbox for address: " + emailAddress);
				MailosaurFunctions.StoreCurrentInbox(emailAddress);
				Report.Success("Inbox stored successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition("I Save the email for the TReVor: (.*) Test user as: (.*)")]
		public void ISaveTheEmailForTheTReVorTestUserAs(string userSavedAs, string emailSaveAs)
		{

			try
			{

				TReVorTestUsers user = TestUsers.GetUserSavedAs(userSavedAs);
				if (user == null)
				{
					Report.Failure("Failed to find a user stored in TReVor: " + userSavedAs);
					return;
				}

				Report.Success($"Found the User stored as {userSavedAs} in Trevor");
				Report.Info($"Saving the Email: {user.Username} to context");
				Context.AddToContext(emailSaveAs, user.Username);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Creating and saving an email address to be used in other steps within a test case
		/// </summary>
		/// <param name="createdEmail"></param>
		/// <param name="savedAs"></param>
		[StepDefinition(@"I create an email (.*) and save it as (.*)")]
		public void CreateAndSaveNewEmailAddress(string createdEmail, string savedAs)
		{
			Report.StartStep(ReportSettings.StepCounter + "- I created an email and saved to use in other locations");
			try
			{
				string email = MailosaurFunctions.CreateEmail(createdEmail);
				UL.Automation.SpecFlow.Classes.Context.AddToContext(savedAs, email);
				Report.Info("Email address created: " + email);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}

		}

		[StepDefinition(@"I create a new email address")]
		public void ThenICreateANewEmailAddress()
		{
			Report.StartStep(ReportSettings.StepCounter + " I create a new email address");
			try
			{

				string myDate = System.DateTime.Now.ToString("HHmmddMMyy");

				string myEmail = MailosaurFunctions.CreateEmail(myDate);

				if (myEmail == "")
				{
					throw new Exception("Failed to Create a New Email Address");
				}

				if (Context.ScenarioContext.ContainsKey("CurrentEmail"))
				{
					Context.ScenarioContext.Remove("CurrentEmail");
				}

				Context.ScenarioContext.Add("CurrentEmail", myEmail);
				Report.Success("Email Address Created and Saved in Scenario Context");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I create a new random email address")]
		public void ThenICreateANewRandomEmailAddress()
		{
			Report.StartStep(ReportSettings.StepCounter + " I create a new email address");
			try
			{

				string myEmail = MailosaurFunctions.CreateEmail("<random>");

				if (myEmail == "")
				{
					throw new Exception("Failed to Create a New Email Address");
				}
				Context.AddToContext("CurrentEmail", myEmail);
				Report.Success("Email Address Created and Saved in Scenario Context");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		//[StepDefinition(@"in the received email I should see the title: (.*)")]
		//public void ThenInTheReceivedEmailIShouldSeeTheTitleWERCSmartPasswordReset(string expectedTitle)
		//{

		//}

		[StepDefinition(@"there (should|should not) be a new email for email Address saved as: (.*) from: (.*) with the title: (.*)")]
		public void ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle(string shouldOrNot, string savedAs, string emailFrom, string title)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Checking whether there is a new email for email Address: " + savedAs + " from " + emailFrom + " with title: " + title);
			try
			{
				if (emailFrom.ToLower() == "<sitenotification>")
				{
					emailFrom = TestVariables.GetVariableSavedAs("NotificationEmail");
				}

				string email = string.Empty;
				if (savedAs == "ForgotPW_SecQs")
				{
					var user = (WERCSmartUser)UL.Automation.SpecFlow.Classes.Context.GetFromContext(savedAs);
					email = user.Email;
				}
				else
				{
					email = UL.Automation.SpecFlow.Classes.Context.GetFromContext(savedAs).ToString();
				}
				Delay.Seconds(10);


				if (MailosaurFunctions.WaitForInboxDifferences(email))
				{
					List<Mailosaur.Email> differences = MailosaurFunctions.GetInboxDifferences(email);
					Report.Info("Found " + differences.Count() + " emails");

					Mailosaur.Email matchingEmail = differences.FirstOrDefault(x => x.From.FirstOrDefault().Address.ToLower() == emailFrom.ToLower() && x.Subject == title);
					Report.Info("Checking if an email that matches the criteria was found...");

					if (shouldOrNot == "should")
					{
						Report.IsTrue(matchingEmail != null, "A matching email has not been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has been found.");
					}
					else
					{
						Report.IsTrue(matchingEmail == null, "A matching email has been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has not been found.");
					}

					if (matchingEmail != null)
					{
						using (var sw = new StreamWriter(@"C:\temp\testemail.html"))
						{
							sw.Write(matchingEmail.Html.Body);
							sw.Flush();
							sw.Close();
						}
					}

					Context.AddToContext("Matching", matchingEmail);
				}
				else
				{

					if (shouldOrNot == "should not")
					{
						Report.Success("As expected, no email has been received");
					}
					else
					{
						throw new Exception("Expected email did not arrive");
					}

				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"For product saved as: (.*) there (should|should not) be a new email for email Address saved as: (.*) from: (.*) with the title: (.*)")]
		public void ThenForProductSavedAsThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle(string productSavedAs, string shouldOrNot, string savedAs, string emailFrom, string title)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Checking whether there is a new email for email Address: " + savedAs + " from " + emailFrom + " with title: " + title);
			try
			{
				if (emailFrom.ToLower() == "<sitenotification>")
				{
					emailFrom = TestVariables.GetVariableSavedAs("NotificationEmail");
				}

				string email = string.Empty;
				if (savedAs == "ForgotPW_SecQs")
				{
					var user = (WERCSmartUser)UL.Automation.SpecFlow.Classes.Context.GetFromContext(savedAs);
					email = user.Email;
				}
				else
				{
					email = UL.Automation.SpecFlow.Classes.Context.GetFromContext(savedAs).ToString();
				}
				Delay.Seconds(10);

		
				if (MailosaurFunctions.WaitForInboxDifferences(email))
				{
					List<Mailosaur.Email> differences = MailosaurFunctions.GetInboxDifferences(email);
					Report.Info("Found " + differences.Count() + " emails");
			
					if (title.Contains(productSavedAs) || title.Contains("<" + productSavedAs + ">"))
					{
						if (!Context.Contains(productSavedAs))
						{
							Report.Error("Context does not contain: " + productSavedAs);
						}

						var product = (ProductInformation)Context.GetFromContext(productSavedAs);
						string id = product.Id;
				
						if (title.Contains("<" + productSavedAs + ">"))
						{
							title = title.Replace("<" + productSavedAs + ">", id);
						} else
						{
							title = title.Replace(productSavedAs, id);
						}
					}

					Mailosaur.Email matchingEmail = differences.FirstOrDefault(x => x.From.FirstOrDefault().Address.ToLower() == emailFrom.ToLower() && x.Subject == title);

					if (shouldOrNot == "should")
					{
						Report.IsTrue(matchingEmail != null, "A matching email has not been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has been found.");
					}
					else
					{
						Report.IsTrue(matchingEmail == null, "A matching email has been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has not been found.");
					}

					if (matchingEmail != null)
					{
						using (var sw = new StreamWriter(@"C:\temp\testemail.html"))
						{
							sw.Write(matchingEmail.Html.Body);
							sw.Flush();
							sw.Close();
						}
					}

					Context.AddToContext("Matching", matchingEmail);
				}
				else
				{

					if (shouldOrNot == "should not")
					{
						Report.Success("As expected, no email has been received");
					}
					else
					{
						throw new Exception("Expected email did not arrive");
					}

				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Asserting text in body of email
		/// </summary>
		/// <param name="bodyText"></param>
		[StepDefinition(@"For product saved as: (.*) the html of the email should show: (.*)")]
		public void ThenTheHTMLOfTheEmailShouldShow(string productSavedAs, string bodyText)
		{
			Report.StartStep(ReportSettings.StepCounter + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");

				string emailBody = email.Html.ToString();

				var product = (ProductInformation)Context.GetFromContext(productSavedAs);
				string id = product.Id;

				if (emailBody.Contains("<" + productSavedAs + ">"))
				{
					emailBody = emailBody.Replace("<" + productSavedAs + ">", id);
				}
				else
				{
					emailBody = emailBody.Replace(productSavedAs, id);
				}

				string bodyDecode = System.Net.WebUtility.HtmlDecode(emailBody);

				Report.Info("Expected email body text: " + bodyText);
				Report.Info("Actual email body text: " + emailBody);

				string actualTrimmed = "";

				foreach (char c in bodyText.ToCharArray())
				{
					if (c != '<')
					{
						actualTrimmed = actualTrimmed + c;
					}
				}

				string expectedTrimmed = emailBody;

				foreach (char c in emailBody.ToCharArray())
				{
					if (c != '<')
					{
						expectedTrimmed = expectedTrimmed + c;
					}
				}

				actualTrimmed = actualTrimmed.TrimStart();
				actualTrimmed = actualTrimmed.TrimEnd();
				actualTrimmed = actualTrimmed.Replace(@" ", @"");

				expectedTrimmed = Regex.Replace(emailBody, @"<[^>]*>", string.Empty);
				expectedTrimmed = Regex.Replace(expectedTrimmed, @"\s+", "");
				expectedTrimmed = expectedTrimmed.TrimStart();
				expectedTrimmed = expectedTrimmed.TrimEnd();
				expectedTrimmed = expectedTrimmed.Replace(@" ", @"");

				Report.IsTrue(expectedTrimmed.Contains(actualTrimmed), "Body text did not match correctly!", "Body text matched correctly!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the html of the email should show: (.*)")]
		public void ThenTheHTMLOfTheEmailShouldShow(string bodyText)
		{
			Report.StartStep(ReportSettings.StepCounter + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");

				string emailBody = email.Html.ToString();
				string bodyDecode = System.Net.WebUtility.HtmlDecode(emailBody);

				Report.Info("Expected email body text: " + bodyText);
				Report.Info("Actual email body text: " + emailBody);

				string actualTrimmed = "";

				foreach (char c in emailBody.ToCharArray())
				{
					if (c != '<')
					{
						actualTrimmed = actualTrimmed + c;
					}
				}

				actualTrimmed = actualTrimmed.Replace(@"/p>", @" ");
				actualTrimmed = actualTrimmed.Replace(@"p>", @"");

				string expectedTrimmed = bodyText;

				actualTrimmed = actualTrimmed.TrimStart();
				actualTrimmed = actualTrimmed.TrimEnd();

				expectedTrimmed = expectedTrimmed.TrimStart();
				expectedTrimmed = expectedTrimmed.TrimEnd();

				actualTrimmed = actualTrimmed.Replace(@" ", @"");
				expectedTrimmed = actualTrimmed.Replace(@" ", @"");

				Report.IsTrue(actualTrimmed.Contains(expectedTrimmed), "Body text did not match correctly!", "Body text matched correctly!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the body of the email should show: (.*)")]
		public void ThenTheBodyOfTheEmailShouldShow(string bodyText)
		{
			Report.StartStep(ReportSettings.StepCounter + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
				// string emailBody = MailosaurFunctions.GetEmailBody(email);
				string emailBody = MailosaurFunctions.GetEmailBody(email);

				//Report.Info("Body of the Email was: " + emailBody);
				// html codes are coming through from mailosaur eg. for '+' character
				string bodyDecode = System.Net.WebUtility.HtmlDecode(emailBody);
				Report.Info("Expected email body text: " + bodyText);
				Report.Info("Body of the Email was: " + emailBody);
				//string actualTrimmed = bodyDecode.Replace(" ", "");
				string actualTrimmed = Regex.Replace(bodyDecode, @"\r|\n| ", "");
				string expectedTrimmed = bodyText.Replace(" ", "");
				Report.IsTrue(actualTrimmed.Contains(expectedTrimmed), "Body text did not match correctly!", "Body text matched correctly!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Asserting text in body of email
		/// </summary>
		/// <param name="bodyText"></param>
		[StepDefinition(@"the body of the email should contain: (.*)")]
		public void ThenTheBodyOfTheEmailShouldContainX(string bodyText)
		{
			Report.StartStep(ReportSettings.StepCounter + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
				string emailBody = MailosaurFunctions.GetEmailBody(email);
				// html codes are coming through from mailosaur eg. for '+' character
				string bodyDecode = System.Net.WebUtility.HtmlDecode(emailBody);
				Report.Info("Body of the Email was: " + emailBody);
				string actualTrimmed = Regex.Replace(bodyDecode, @"\r|\n| ", "");
				string expectedTrimmed = bodyText.Replace(" ", "");
				Report.IsTrue(actualTrimmed.Contains(expectedTrimmed), "Body text did not match correctly!", "Body text matched correctly!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Back button click in the browser
		/// </summary>
		[StepDefinition(@"I click the back button in the browser")]
		public void GivenIClickOnBackButtonInBrowser()
		{
			Report.StartStep(ReportSettings.StepCounter + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				SeleniumBrowser.WebBrowser.Navigate().Back();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Switching to a new tab in the chrome browser
		/// </summary>
		/// <param name="url"></param>
		[StepDefinition(@"I switch to the tab: (.*)")]
		public void SwitchToTheTab(string url)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Switch to Tab: " + url);
			try
			{
				Report.Info("Switch to Tab: " + url);
				string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				UL.Automation.SpecFlow.Classes.Context.AddToContext("MainWindowHandle", currentHandle);
				System.Collections.ObjectModel.ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				foreach (string handle in allHandles)
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
					SeleniumBrowser.WebBrowser.WaitForPageLoad();
					if (SeleniumBrowser.WebBrowser.Url == url)
					{
						Report.Success("Successfully Switch to Tab: " + url + "!");
						Report.Screenshot();
						return;
					}
				}
				Report.Screenshot();
				throw new Exception("Failed to find tab with url: " + url);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I save the current window as: (.*)")]
		public void SaveTheCurrentWindowAs(string savedAs)
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			UL.Automation.SpecFlow.Classes.Context.AddToContext(savedAs, currentHandle);
		}

		[StepDefinition(@"I close the window saved as: (.*)")]
		public void SwitchBackToMainWindow(string savedAs)
		{
			string handleToClose = UL.Automation.SpecFlow.Classes.Context.GetFromContext(savedAs)?.ToString();
			if (handleToClose == null)
			{
				Report.Failure("Unable to find window saved as: " + savedAs + " in context to close!");
				return;
			}
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			string handleMatch = allHandles.First(x => x == handleToClose);
			if (handleMatch == null)
			{
				Report.Failure("There was no window matching open matching: " + savedAs);
				return;
			}
			Report.Info("Found window to close: " + savedAs);
			SeleniumBrowser.WebBrowser.SwitchTo().Window(handleMatch);
			Report.Screenshot();
			Report.Info("Closing window");
			SeleniumBrowser.WebBrowser.Close();
			Report.Screenshot();
		}

		[StepDefinition(@"I switch to the Data Summary page")]
		public void SwitchToDataSumaryTab()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			UL.Automation.SpecFlow.Classes.Context.AddToContext("MainWindowHandle", currentHandle);
			System.Collections.ObjectModel.ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				Delay.Seconds(5);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h1[text()='Summary']"), 20) != null)
				{
					Report.Success("Tab was switched successfully!");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
			Report.Screenshot();
		}

		[StepDefinition(@"I switch to Data Acceptance page")]
		public void ThenISwitchToDataAcceptancePage()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			UL.Automation.SpecFlow.Classes.Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h3[text()='Data Acceptance']"), 2) != null)
				{
					Report.Success("Tab was switched successfully!");
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
		}

		[StepDefinition(@"I close the Data Summary tab")]
		public void CloseDataSummaryTab()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			string mainHandle = UL.Automation.SpecFlow.Classes.Context.GetFromContext("MainWindowHandle").ToString();
			SeleniumBrowser.WebBrowser.Close();
			SeleniumBrowser.WebBrowser.SwitchTo().Window(mainHandle);
		}

		[StepDefinition(@"If a modal dialog opens I skip it")]
		public void GivenIfAModalDialogOpensISkipIt()
		{
			var thisModalDialog = new ModalDialog();
			if (thisModalDialog.Wait_for_load(3))
			{
				Report.Info("modal dialog is opened. ");
				Report.IsTrue(thisModalDialog.Click_Skip(), "Failed to click skip button", "Clicked skip button");
			}
		}

		[StepDefinition(@"If a modal dialog opens I close it")]
		public void GivenIfAModalDialogOpensICloseIt()
		{
			var thisModalDialog = new ModalDialog();
			if (thisModalDialog.Wait_for_load(5))
			{
				Report.Info("modal dialog is opened. ");
				Report.IsTrue(thisModalDialog.Click_Closex(), "Failed to click close button", "Clicked close button");
			}
		}

		[StepDefinition(@"I wait for a modal dialog to open")]
		public void WaitForAModalDialogToOpen()
		{
			var thisModalDialog = new ModalDialog();
			if (thisModalDialog.Wait_for_load(30))
			{
				Report.Success("Modal dialog is opened.");

			}
			else
			{
				Report.Failure("A modal dialog is not open.");

			}
		}

		[StepDefinition(@"in the modal dialog I click the ""(.*)"" button")]
		public void GivenInTheModalDialogIClickButton(string button)
		{

			Report.IsTrue(new ModalDialog().ClickButton(button),
				$@"Failed to click ""{button}"" button",
				$@"Successfully clicked the ""{button}"" button");
		}

		[StepDefinition(@"I click the Terms of Use link in the footer")]
		public void ClickTermsOfUseFooter()
		{
			Report.IsTrue(new Homepage().ClickTermsOfUse(),
				"Failed to click the Terms Of Use link",
				"Successfully clicked the Terms Of Use link");
		}

		[StepDefinition(@"I confirm the WERCSmart Terms of Use page opened in a new tab and navigate to it")]
		public void SwitchToTermsOfUseTab()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			UL.Automation.SpecFlow.Classes.Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h2[contains(text(),'Terms of Use')]"), 2) != null)
				{
					Report.Success("The Terms Of Use page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
			Report.Screenshot();
		}

		[StepDefinition("I (accept|dismiss) the alert pop up")]
		public void ConfirmThealertPopup(string action)
		{
			if (action == "accept")
			{
				Report.Info("Accepting the pop up alert");
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}

			if (action == "dismiss")
			{
				Report.Info("Dismissing the pop up alert");
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Dismiss();
			}
		}

		[StepDefinition(@"I delete Products with the UPC number if one has been created for this test")]
		public void DeleteProductWithUPCNumberIfOneHasBeenGenerated()
		{
			string testCaseId = TReVorSettings.TestCaseId;
			if (testCaseId != null && UL.Automation.SpecFlow.Classes.Context.GetFromContext($"UPC{testCaseId}") != null)
			{
				new StepsProductGrid().DeleteAllProductsMatchingCriteria("UPC Number", UL.Automation.SpecFlow.Classes.Context.GetFromContext($"UPC{testCaseId}").ToString());
			}
		}

		[StepDefinition("I save the TReVor test user: (.*) to context as 'TReVorTestUser'")]
		public void ISaveTheWercSmartUserStoredInTrevorAs(string savedAs)
		{
			TReVorTestUsers user = TestUsers.GetUserSavedAs(savedAs);
			if (user == null)
			{
				Report.Failure("Failed to find a user stored in TReVor: " + savedAs);
				return;
			}
			UL.Automation.SpecFlow.Classes.Context.AddToContext("TReVorTestUser", new User { Password = user.Password, Email = user.Username });
		}

		[StepDefinition(@"I update the password for the following TReVor test users:")]
		public void IUpdateThePasswordForTheFollowingTrevorTestUsers(Table users)
		{
			var usersSavedAs = new List<string>();
			ReportSettings.UseSubSteps = true;
			users.Rows.Cast<TableRow>().ToList().ForEach(x => usersSavedAs.Add(x["User"]));
			Report.Info("Updating password for the following users: " + string.Join(", ", usersSavedAs.Select(x => $"'{x}'")));
			foreach (string savedAs in usersSavedAs)
			{
				Report.StartStep($"I update the password for user: {savedAs}");
				this.ILogInWithTheAccountSavedInTrevorAs(savedAs);
				var selMyAccount = new StepsMyAccount();
				Report.Info("Navigating to My Account from the homepage");
				selMyAccount.GivenINavigateToTheMyAccountPage();
				Report.Info("Clicking Reset Password for the current logged in user");
				selMyAccount.GivenIGoToActionInUserGrid("Reset Password");
				Report.Info("Updating the password for test user " + savedAs);
				selMyAccount.IUpdateThePasswordForTrevorTestUser(savedAs);
				Report.Info("Logging out");
				this.GivenILogout();
				Report.Info("Checking I can log in with the new credentials");
				TestUsers.RefreshUsers();
				this.ILogInWithTheAccountSavedInTrevorAs(savedAs);
				Report.Info("Logging out");
				this.GivenILogout();
			}
		}

		[StepDefinition(@"I update the password for all TReVor Test Users within the current branch")]
		public void IUpdateThePasswordForAllTrevorTestUsersWithinCurrentBranch()
		{
			ReportSettings.UseSubSteps = true;
			List<TReVorTestUsers> users = TestUsers.Users;
			IEnumerable<TReVorTestUsers> allUsers = users.Where(x => x.SoftwareId == TReVorSettings.EditionInformation.SoftwareId && x.BranchName == TReVorSettings.SoftwareBranch);
			var usersSavedAs = allUsers.Select(x => x.SavedAs).ToList();
			Report.Info("Updating password for the following users: " + string.Join(", ", usersSavedAs.Select(x => $"'{x}'")));
			foreach (string savedAs in usersSavedAs)
			{
				TReVorTestUsers user = TestUsers.GetUserSavedAs(savedAs);
				if (!user.Username.Contains("@"))
				{
					Report.Info($"The email did not contain an '@' so continuing to the next user.");
					continue;
				}
				if (user.SavedAs == "PayPal")
				{
					Report.Info($"We do not need to update the PayPal password");
					continue;
				}
				Report.StartStep($"I update the password for user: {savedAs}");
				//this.ILogInWithTheAccountSavedInTrevorAs(savedAs);
				this.LoginToAccount(savedAs, true);
				string alert = new RetailPartners().WarningMessage();
				if (alert != null && alert.Contains("The recipients listed below have additional Data Consent requests"))
				{
					Report.Info("Account needs to be reviewed - data consent requests. Continuing to the next account");
					Report.Info("Logging out");
					this.GivenILogout();
					continue;
				}
				if (!new Homepage().WaitForContainerToBeVisible())
				{
					// if 90 day expiry attempt to reset it
					var passwordExpired = new PasswordExpired();
					if (passwordExpired.Wait_for_load())
					{
						string message = passwordExpired.TopMessage();
						if (message != null && message.Contains("Your password has expired after 90 days for security reasons"))
						{
							Report.Info("The password expired after 90 days.");
							Report.Info("Attempting to reset password");
							string currentPassword = user.Password;
							Report.Info("Entering original password: " + currentPassword);
							passwordExpired.OriginalPassword = currentPassword;
							string newPassword = "";
							// If the current password ends in a character, append with a 1 for the new password
							if (!char.IsDigit(currentPassword.Last()))
							{
								newPassword = currentPassword + "1";
							}
							else
							{
								char[] passwordChr = currentPassword.ToCharArray();
								string result = string.Join("", passwordChr.Select(x => char.IsDigit(x) ? x.ToString() : "|")).Split('|').LastOrDefault().Trim();
								newPassword = currentPassword.TrimEnd(result.ToCharArray()) + (Convert.ToInt32(result) + 1);
							}
							Report.Info("Entering New Password: " + newPassword);
							passwordExpired.NewPassword = newPassword;
							Report.Info("Entering Verify Password: " + newPassword);
							passwordExpired.VerifyPassword = newPassword;
							Report.Info("Clicking continue");
							passwordExpired.ClickContinue();
							GeneralUtilities.Wait_for_load_finish();
							// Thank You page
							if (passwordExpired.TopHeading().Contains("Thank You"))
							{
								Report.Info("Updating the password in TReVor Test Users");
								TReVorSettings.TReVor.CacheFunctions.UpdateTestUserPassword(savedAs, newPassword);
								Report.Info("Navigating to the landing page");
								SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
								Report.Info("Checking I can log in with the new credentials");
								TestUsers.RefreshUsers();
								this.ILogInWithTheAccountSavedInTrevorAs(savedAs);
								Report.Info("Logging out");
								this.GivenILogout();
								SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
								continue;
							}
							Report.Failure("Failed to update password in 90 day expiry page");
							Report.Screenshot();
							continue;
						}
						// then we're on the log in screen (incorrect password)
						Report.Info("Navigating to the landing page");
						SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
						continue;
					}
					// The home page didn't load and it wasn't due to password expiry so dead end.
					Report.Failure("Failed to log in with user: " + savedAs + ". Did not find the top menu bar!");
					if (new TopMenuBar().Wait_for_load())
					{
						Report.Info("Logging out");
						this.GivenILogout();
					}
					else
					{
						Report.Info("Unable to log out so navigating to the test url");
						SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
					}
					continue;
				}
				var selMyAccount = new StepsMyAccount();
				Report.Info("Navigating to My Account from the homepage");
				selMyAccount.GivenINavigateToTheMyAccountPage();
				Report.Info("Clicking Reset Password for the current logged in user");
				selMyAccount.GivenIGoToActionInUserGrid("Reset Password");
				Report.Info("Updating the password for test user " + savedAs);
				selMyAccount.IUpdateThePasswordForTrevorTestUser(savedAs);
				Report.Info("Logging out");
				this.GivenILogout();
				if (!new LandingPage().WaitForContainerToBeVisible())
				{
					Report.Info("Directed to an unexpected WercSmart landing page!");
					Report.Info("Navigating to the landing page");
					new GlobalSteps().NavigateToLandingPage();
				}
				Report.Info("Checking I can log in with the new credentials");
				TestUsers.RefreshUsers();
				this.ILogInWithTheAccountSavedInTrevorAs(savedAs);
				Report.Info("Logging out");
				this.GivenILogout();
				SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
			}
		}

		[StepDefinition(@"I save to context name: (.*) and value: (.*)")]
		public void GivenISaveToContextNameAndValue(string name, string value)
		{
			var newProductInformation = new ProductInformation {
				Id = value,
				Name = value
			};
			Context.AddToContext(name, newProductInformation);
		}

		[StepDefinition(@"I add to context name: (.*) and value: (.*)")]
		public void GivenIAddToContextNameAndValue(string name, string value)
		{
			Context.AddToContext(name, value);
		}

		[StepDefinition(@"I check alert text contains (.*) and dismiss")]
		public void GivenICheckAlertTextContainsXAndDismiss(string searchText)
		{
			//Putting this in because standard get alert functionality does not work in this page.
			if (!SeleniumBrowser.Alert.WaitForAlert(10))
			{
				try
				{
					SeleniumBrowser.Alert.ReloadAlert(searchText);
				}
				catch (Exception ex)
				{
					Report.Failure("Failed to reload alert. Exception: " + ex);
					return;
				}
			}
			if (!SeleniumBrowser.Alert.WaitForAlert())
			{
				Report.Error("Alert did not appear");
			}
			string alertTextFull = SeleniumBrowser.Alert.GetText();
			//string alertText = alertTextFull.Replace("\r\n", string.Empty);


			string alertText = GeneralUtilities.RemoveLineBreaks(alertTextFull);

			if (alertText == null)
			{
				Report.Failure("Text was not displayed", false);
			}
			if (alertText.Contains(searchText))
			{
				Report.Info("Alert text was as expected");

			}
			else
			{
				Report.Failure($"Alert text was not as expected. Found: {alertText}", false);
			}

			//Report.IsTrue(alertText.Contains(searchText), "Alert text was not as expected. Found: " + alertText,
			//	"Alert text was as expected");

			Report.Screenshot();

			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}

		}

		[StepDefinition(@"I save to context name: (.*) and string value: (.*)")]
		public void GivenISaveToContextNameAndStringValue(string name, string value)
		{
			UL.Automation.SpecFlow.Classes.Context.AddToContext(name, value);
		}

		[StepDefinition(@"I move the mouse pointer by an offset of (.*) in x and (.*) in y")]
		public void MoveMousePointerByOffset(string offsetX, string offsetY)
		{
			if (!int.TryParse(offsetX, out int offsetXNum))
			{
				Report.Failure("The offset parameter must be parsable as an integer!");
				return;
			}
			if (!int.TryParse(offsetY, out int offsetYNum))
			{
				Report.Failure("The offset parameter must be parsable as an integer!");
				return;
			}
			Report.Info($"Doing action: Move By Offset ({offsetX}, {offsetY})");
			var action = new Actions(SeleniumBrowser.WebBrowser);
			action.MoveByOffset(offsetXNum, offsetYNum).Build().Perform();
			Report.Info("Action performed");
		}

		//[StepDefinition(@"I get the list of CVS UPC numbers from upcitemdb.com and save as: (.*)")]
		//public void GetTheListOfCvsUpcNumbers(string savedAs)
		//{

		//}

		[StepDefinition(@"I close the current tab")]
		public void GivenICloseTheCurrentTab()
		{
			Delay.Seconds(5);
			SeleniumBrowser.CloseTabWithURL(SeleniumBrowser.GetActiveTabURL());
		}

		[StepDefinition(@"I close the current window")]
		public void CloseCurrentWindow()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		[StepDefinition(@"I switch to the tab with title: (.*)")]
		public void SwitchToTabWithTitle(string title)
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Report.Info("Saving current window to context as MainWindowHandle");

			Context.AddToContext("MainWindowHandle", currentHandle);
			int i = 1;
			Report.Info("Attempting up to 10 times to find wanted tab");
			while (i < 11)
			{
				ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				foreach (string handle in allHandles)
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
					string currentTitle = SeleniumBrowser.WebBrowser.Title;
					if (currentTitle == title)
					{
						Report.Success("Tab with title was switched to");
						Report.Screenshot();
						return;
					}
				}
				Report.Info($"Did not find the tab:{title} on attempt: {i}");
				Delay.Seconds(1);
				i++;

			}

			throw new Exception("Failed to find window with title: " + title);
		}

		[StepDefinition(@"I confirm that I see the following text in the modal window popup: (.*)")]
		public void IConfirmThatISeeTheFollowingTextInTheModalWindow(string text)
		{
			var modal = new ModalDialog();

			Report.IsTrue(modal.GetText() == text, "Failed to find text '" + text + "' in modal window. Found text '" + modal.GetText() + "' instead.",
				"Successfully found text '" + text + "' in modal window.");
		}

		[StepDefinition(@"I check that the alert displayed contains text: (.*)")]
		public void ICheckThatTheAlertDisplayedContainsText(string expected)
		{
			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				Report.Info("Alert is present");
				Report.Screenshot();
				string text = GeneralUtilities.StripSpecialChars(SeleniumBrowser.WebBrowser.SwitchTo().Alert().Text);
				expected = GeneralUtilities.StripSpecialChars(expected);
				Report.IsTrue(text.Contains(expected), "Failed to find alert text: '" + expected + "'. Instead found: '" + text + "'.",
					"Successfully found alert text: '" + expected + "'.");
			}
		}

		[StepDefinition(@"I save the username for TReVor test user: (.*) to context as: (.*)")]
		public void SaveUsernameOfTrevorUser(string trevorSavedAs, string usernameSavedAs)
		{
			TReVorTestUsers user = TestUsers.GetUserSavedAs(trevorSavedAs);
			if (user != null)
			{
				Report.Info("Adding username context: " + user.Username);
				Context.AddToContext(usernameSavedAs, user.Username);
			}
		}

		[StepDefinition(@"I check alert text contains either: (.*) or: (.*) and dismiss")]
		public void GivenICheckAlertTextContainsEitherXOrYAndDismiss(string searchTextMain, string searchTextAlternative)
		{
			//Putting this in because standard get alert functionality does not work in this page.
			if (!SeleniumBrowser.Alert.WaitForAlert(10))
			{
				SeleniumBrowser.Alert.ReloadAlert(searchTextMain);
			}
			if (!SeleniumBrowser.Alert.WaitForAlert(10))
			{
				SeleniumBrowser.Alert.ReloadAlert(searchTextAlternative);
			}
			if (!SeleniumBrowser.Alert.WaitForAlert())
			{
				Report.Error("Alert did not appear");
			}
			string alertText = SeleniumBrowser.Alert.GetText();
			if (alertText == null)
			{
				Report.Failure("Text was not displayed", false);
			}
			if (alertText.Contains(searchTextMain))
			{
				Report.Info($"Alert text was as expected, and contained: {searchTextMain}");

			}
			if (alertText.Contains(searchTextAlternative))
			{
				Report.Info($"Alert text was as expected, and contained: {searchTextAlternative}");

			}
			else
			{
				Report.Failure($"Alert text was not as expected. Found: {alertText}", false);
			}

			//Report.IsTrue(alertText.Contains(searchText), "Alert text was not as expected. Found: " + alertText,
			//	"Alert text was as expected");

			Report.Screenshot();

			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}

		}


		[StepDefinition("I find an existing UPC number in trevor account saved as: (.*) using feature context: (.*)")]
		public void FindExistingUpcNumberInTrevorAccountUsingFeatureContext(string trevorSavedAs, string upcSavedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I look in feature context for: " + upcSavedAs);
			if (Context.Contains(upcSavedAs, true))
			{
				Report.Info("Found an existing UPC in context");
				var upc = Context.GetFromContext(upcSavedAs).ToString();
				Report.Info("Saving UPC : " + upc + " to scenario context");
				Context.AddToContext(upcSavedAs, upc);
				return;
			}
			Report.Info("UPC did not exist in feature context");
			// fall back to searching SHA manager
			Report.StartStep("I search for a UPC in SHA Manager associated with trevor user account: " + trevorSavedAs + " and save to context as: " + upcSavedAs);
			new Steps_SHA().NavigateToShaSaveUpcToContext(upcSavedAs, trevorSavedAs);
			// check if SHA search was successful
			if (Context.Contains(upcSavedAs))
			{
				// add to feature context
				var upc = Context.GetFromContext(upcSavedAs).ToString();
				Context.AddToContext(upcSavedAs, upc, true);
				return;
			}
			// fall back to creating a new product
			Report.StartStep("Logging in to WercSmart");
			new GlobalSteps().NavigateToLandingPage();
			this.ILogInWithTheAccountSavedInTrevorAs(trevorSavedAs);
			Report.StartStep("Creating a new product: Chalk");
			new Steps_ProductSetup().GivenICreateProductUsingTestCase75335("Chalk", upcSavedAs, "ExistingUPCProduct");
			// check if new product UPC was successful
			if (Context.Contains(upcSavedAs))
			{
				// add to feature context
				var createdUpc = Context.GetFromContext(upcSavedAs).ToString();
				Context.AddToContext(upcSavedAs, createdUpc, true);
				return;
			}
			Report.Failure("Failed to get an existing UPC!");
		}

		[StepDefinition(@"I Look for an Alert every minute for a max of: (.*) minutes and when an alert is found I wait for the landing page for a max of: (.*) minutes")]
		public void LookForAlertForXMinutesAndWaitForLandingPageForY(int alertWaitMinutes, int landingPageWaitMinutes)
		{

			bool alertAppeared = false;
			bool landingPageAppeared = false;

			for (int i = 0; i < alertWaitMinutes; i++)
			{
				if (SeleniumBrowser.Alert.WaitForAlert(60))
				{
					Report.Success("The Alert Appeared");
					alertAppeared = true;
					if (i == 0)
					{
						Report.Info("Waited for 1 minute or less before Alert appeared");
					}
					else
					{
						Report.Info("Alert appeared within: " + (i + 1) + " minutes");
					}
					for (int j = 0; j < landingPageWaitMinutes; j++)
					{
						if (new LandingPage().WaitForContainerToBeVisible(60))
						{
							Report.Success("The landing Page Appeared");
							landingPageAppeared = true;
							if (j == 0)
							{
								Report.Info("Waited for 1 minute or less before landing Page appeared");
							}
							else
							{
								Report.Info("landing Page appeared within: " + (j + 1) + " minutes");
							}
							return;
						}
					}
					if (landingPageAppeared == false)
					{
						Report.Failure("The Landing Page did not appear after: " + landingPageWaitMinutes + " minutes");
						return;
					}
				}
			}

			if (alertAppeared == false)
			{
				Report.Failure("The Alert did not appear after: " + alertWaitMinutes + " minutes");
			}
		}

		[StepDefinition(@"I Look for an Alert every minute for a max of: (.*) minutes")]
		public void LookForAlertForXMinutes(int alertWaitMinutes)
		{

			bool alertAppeared = false;
			Report.Info("Starting wait for Alert");
			for (int i = 0; i < alertWaitMinutes; i++)
			{
				if (SeleniumBrowser.Alert.WaitForAlert(60))
				{
					Report.Success("The Alert Appeared");
					alertAppeared = true;
					if (i == 0)
					{
						Report.Info("Waited for 1 minute or less before Alert appeared");
						return;
					}
					else
					{
						Report.Info("Alert appeared within: " + (i + 1) + " minutes");
						return;
					}
				}
			}

			if (!alertAppeared)
			{
				Report.Failure("The Alert did not appear after: " + alertWaitMinutes + " minutes");
			}
		}

		[StepDefinition(@"I Look for an Alert for a max: (.*) minutes")]
		public void LookForAlertForXMinutesTotal(int alertWaitMinutes)
		{

			bool alertAppeared = false;
			Report.Info("Starting wait for Alert");
			int i = 60 * alertWaitMinutes;
			if (SeleniumBrowser.Alert.WaitForAlert(i))
			{
				Report.Success("The Alert Appeared");
				alertAppeared = true;
				return;
			}

			if (!alertAppeared)
			{
				Report.Failure("The Alert did not appear after: " + alertWaitMinutes + " minutes");
			}
		}

		[StepDefinition(@"I Look for an Alert for a max: (.*) Seconds")]
		public void LookForAlertForXSecondsTotal(int alertWaitSeconds)
		{

			bool alertAppeared = false;
			Report.Info("Starting wait for Alert");
			int i = alertWaitSeconds;
			if (SeleniumBrowser.Alert.WaitForAlert(i))
			{

				Report.Success("The Alert Appeared");
				alertAppeared = true;
				return;
			}

			if (!alertAppeared)
			{
				Report.Failure("The Alert did not appear after: " + alertWaitSeconds + " seconds", false);
			}
		}

		[StepDefinition(@"I Look for the Landing Page every minute for a max of: (.*) minutes")]
		public void LookForLandingPageForXMinutes(int landingPageWaitMinutes)
		{
			bool landingPageAppeared = false;
			for (int j = 0; j < landingPageWaitMinutes; j++)
			{
				if (new LandingPage().WaitForContainerToBeVisible(60))
				{
					Report.Success("The landing Page Appeared");
					landingPageAppeared = true;
					if (j == 0)
					{
						Report.Info("Waited for 1 minute or less before landing Page appeared");
					}
					else
					{
						Report.Info("landing Page appeared within: " + (j + 1) + " minutes");
					}
					return;
				}
			}
			if (landingPageAppeared == false)
			{
				Report.Failure("The Landing Page did not appear after: " + landingPageWaitMinutes + " minutes");
			}
		}

		[StepDefinition(@"I Look for the Landing Page for: (.*) minutes")]
		public void LookForLandingPageForXMinutesTotal(int landingPageWaitMinutes)
		{
			bool landingPageAppeared = false;
			int i = 60 * landingPageWaitMinutes;
			if (new LandingPage().WaitForContainerToBeVisible(i))
			{
				Report.Success("The landing Page Appeared");
				landingPageAppeared = true;
				return;
			}

			if (landingPageAppeared == false)
			{
				Report.Failure("The Landing Page did not appear after: " + landingPageWaitMinutes + " minutes");
			}
		}

		[StepDefinition(@"I Look for an Alert every minute for: (.*) minutes and when an alert is found I wait for the landing page for: (.*) minutes")]
		public void LookForAlertForXMinutesAndWaitForLandingPageForYTotal(int alertWaitMinutes, int landingPageWaitMinutes)
		{

			bool alertAppeared = false;
			bool landingPageAppeared = false;
			int i = 60 * alertWaitMinutes;
			int j = 60 * landingPageWaitMinutes;


			if (SeleniumBrowser.Alert.WaitForAlert(i))
			{
				Report.Success("The Alert Appeared");
				alertAppeared = true;

				if (new LandingPage().WaitForContainerToBeVisible(j))
				{
					Report.Success("The landing Page Appeared");
					landingPageAppeared = true;
					return;
				}

				if (landingPageAppeared == false)
				{
					Report.Failure("The Landing Page did not appear after: " + landingPageWaitMinutes + " minutes", false);
					return;
				}
			}

			if (alertAppeared == false)
			{
				Report.Failure("The Alert did not appear after: " + alertWaitMinutes + " minutes");
			}
		}

		[StepDefinition(@"I close the current window and switch to the main window in Studio")]
		public void IClosetheCurrentWindowAndSwitchToMainWindowInStudio()
		{
			Report.Info("Closing window");
			SeleniumBrowser.WebBrowser.Close();
			Report.Info("Returning to the main window");
			try
			{
				var handle = Context.GetFromContext("MainWindowHandle").ToString();
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				// required to switch to the frame and refresh container
				new StudioSHAManager().Wait_for_load();
				//switch to correct iFrame? if elements are returning as null etc after swithcing back to SHA products grid, may need to switch to correct IFrame again. Here or in methods?
			}
			catch (Exception ex)
			{
				Report.Failure("Failed to navigate back to main window using MainWindowHandle context");
				Report.Failure("Exception: " + ex.Message);
				throw;
			}
		}

		[StepDefinition("I Check that both an alert and inactivity prompt are on screen")]
		public void ICheckThatBothAnAlertAndInactivityPromptAreOnScreen()
		{
			bool bothOnSceen = true;
			if (!new InactivityPopup().WaitForContainerToBeVisible(10))
			{
				Report.Failure($"The Inactivity prompt was not on screen", false);
				bothOnSceen = false;
			}
			else
			{
				Report.Success($"The Inactivity prompt was on screen");
			}
			if (!SeleniumBrowser.Alert.WaitForAlert(5))
			{
				Report.Failure($"The Alert was not on screen", false);
				bothOnSceen = false;
			}
			else
			{
				Report.Success($"The Alert was on screen");
			}

			Report.IsTrue(bothOnSceen, "Both The Alert and Prompt were not on screen at the same time", " Both the Alert and Prompt were on screen at the same time");

		}

		[StepDefinition(@"I confirm the Inactivity popup is displayed after waiting (.*) minutes accurate to the nearest (.*) minutes")]
		public void ConfirmTheUnsavedChangesAlertDisplayedAfterWait(int expectedWait, int marginOfError)
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

		[StepDefinition(@"I Check there should be a new suspension notification email for user: (.*) for the Product saved as: (.*) with the suspension subject of: (.*) and check it does not contain text from the table:")]
		public void ICheckThereIsANewEmailForUserXFromYAndSpecificTitle(string emailSavedAs, string productSavedAs, string subject, Table stringTable)
		{
			ReportSettings.UseSubSteps = true;
			var productDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			string productID = productDetails.Id;
			string emailSuspensionTitle = "Notification - Product " + productID + " - " + subject;

			Report.StartStep($"I confirm the administrator receieved an email with subject '{emailSuspensionTitle}'");
			Delay.Seconds(5);
			new GlobalSteps().ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", emailSavedAs, "<SiteNotification>", emailSuspensionTitle);
			Report.StartStep("I confirm the body text of the email does not contain the blurb text");
			new GlobalSteps().ThenTheTextOfTheEmailShouldNotShow(stringTable);

			//do 2 x checks for the 2 differnt bullet points of the blurp text or one string and find format that works (e.g white space removal etc)
		}

		[StepDefinition(@"the text of the email should not show: (.*)")]
		public void ThenTheTextOfTheEmailShouldNotShow(Table stringTable)
		{
			Report.StartStep(ReportSettings.StepCounter + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
				string emailText = email.Text.ToString();
				string actualTrimmed = Regex.Replace(emailText, @"\r|\n| ", "");

				foreach (var row in stringTable.Rows)
				{
					string checkText = row["SearchText"];
					string expectedTrimmed = checkText.Replace(" ", "");
					Report.Info("Text that should not be present: " + checkText);
					Report.Info("Body of the Email was: " + emailText);
					Report.IsTrue(!actualTrimmed.Contains(expectedTrimmed), "Body text did contain the given text", "Body text did not contain the given text");
				}



			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the text of the email should show: (.*)")]
		public void ThenTheTextOfTheEmailShouldShow(string bodyText)
		{
			Report.StartStep(ReportSettings.StepCounter + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
				string emailText = email.Text.ToString();
				string actualTrimmed = Regex.Replace(emailText, @"\r|\n| ", "");
				string expectedTrimmed = Regex.Replace(bodyText, @"\r|\n| ", "");
				Report.Info("Expected email body text: " + expectedTrimmed);
				Report.Info("Body of the Email was: " + actualTrimmed);
				Report.IsTrue(actualTrimmed.Contains(expectedTrimmed), "Body text did not match correctly!", "Body text matched correctly!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I create a upc number for CVS")]
		public void CreateCVSUPC()
		{
			string upc = TReVorSettings.TReVor.VisualStudioFunctions.GetRandomUpcNumber("CVS");
		}

		[StepDefinition(@"I Wait for a modal popup to appear")]
		public void IWaitForModalPopupToBeVisible()
		{
			Report.IsTrue(new ModalDialog().WaitForContainerToBeVisible(30), "The Modal did not appear", "The modal appeared");
		}
		[StepDefinition(@"I Wait for a modal popup to disappear")]
		public void IWaitForModalPopupToBeInVisible(int timeout = 30)
		{
			Report.IsTrue(new ModalDialog().WaitForContainerToBeInvisible(timeout), "The Modal was still showing", "The modal was gone");
		}

		[StepDefinition(@"I save the following text: (.*) as (.*)")]
		public void SaveTextToContextAs(string text, string savedAs)
		{
			Context.AddToContext(savedAs, text);
		}

		[StepDefinition(@"I Delete the file with name: (.*) from the downloads folder")]
		public void DeleteFileFromDownloadsFolder(string fileName)
		{
			Report.IsTrue(GeneralUtilities.DeleteFileFromDownloadsFolder(fileName), "", "");
		}

		[StepDefinition(@"I Delete the directory and its contents with name: (.*) from the downloads folder")]
		public void DeleteDirectoryAndItsContentsFromDownloadsFolder(string directoryName)
		{
			string rootFolder = @"" + KnownFolders.GetPath(KnownFolder.Downloads) + "\\" + directoryName + "\\";

			if (System.IO.Directory.Exists(rootFolder))
			{
				System.IO.Directory.Delete(rootFolder, true);
				Report.Success("Directory with name: " + directoryName + " was successfully deleted");
			} else
			{
				Report.Failure("Directory with name: " + directoryName + " was not found");
			}
		}

		[StepDefinition(@"I save the product ID: (.*) to a context under type 'ProductInformation' as: (.*)")]
		public void SaveProductIDAsProductInformationNamed(string prodID, string savedAs)
		{
			var createdProduct = new ProductInformation();
			createdProduct.Id = prodID;
			Context.AddToContext(savedAs, createdProduct);
		}

		[StepDefinition(@"Saving the product ID: (.*) and Name: (.*) to a context under type 'ProductInformation' as: (.*)")]
		public void SaveProductIDAndNameAsProductInformationNamed(string prodID, string prodName, string savedAs)
		{
			var createdProduct = new ProductInformation();
			createdProduct.Id = prodID;
			createdProduct.Name = prodName;
			Context.AddToContext(savedAs, createdProduct);
		}

		[StepDefinition(@"I confirm that a file is produced called (.*) and save as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Confirm File is downloaded with name: " + file);
			try
			{
				Delay.Seconds(10);
				Report.Info("Confirm a file is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				Report.Info("Downloads folder: " + downloadsFolder);
				string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
				if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
				{
					Context.AddToContext(savedAs, dir.FirstOrDefault());
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I delete the file saved as (.*)")]
		public void DeleteFileSavedAs(string savedAs)
		{
			string file = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + savedAs);
				return;
			}
			Report.Info("Deleting file: " + file);
			File.Delete(file);
		}

		[StepDefinition(@"I Check that the file saved as: (.*) contains text")]
		public void CheckThatFileSavedAsContainsText(string fileSavedAs)
		{
		
			var thisSHADocument = new SHADocumentList();
			Delay.Seconds(3);
			Report.Screenshot();

			if (fileSavedAs.ToLower().Contains("savedas"))
			{
				fileSavedAs = (string)Context.GetFromContext(fileSavedAs);
			}

			PdfReader reader = new PdfReader(fileSavedAs);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			var pdfText = text;
			Report.Info($"The Found PDF Text was: {pdfText}");
			Report.IsTrue(pdfText!=null, "PDF does not contains text","PDF does contain text");		

		}

		[StepDefinition(@"I Check that the pdf file saved as: (.*) contains the text: (.*)")]
		public void CheckThatPDFFileSavedAsContainsX(string fileSavedAs,string searchText)
		{

			var thisSHADocument = new SHADocumentList();
			Delay.Seconds(3);
			Report.Screenshot();

			if (fileSavedAs.ToLower().Contains("savedas"))
			{
				fileSavedAs = (string)Context.GetFromContext(fileSavedAs);
			}

			PdfReader reader = new PdfReader(fileSavedAs);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			var pdfText = text;
			Report.Info($"The Found PDF Text was: {pdfText}");
			Report.IsTrue(pdfText.Contains(searchText), "PDF does not contain the text", "PDF does contain the text");

		}


		[StepDefinition(@"I save the current window handle to context as: (.*)")]
		public void SaveTheCurrentWindowHandleToContextAs(string saveAs)
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext(saveAs, currentHandle);		
		}

		[StepDefinition(@"I switch to the window with handle saved as: (.*)")]
		public void SwitchToTheWindowWithHandleSavedAs(string savedAs)
		{
			string handle = (string)Context.GetFromContext(savedAs);
			SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
			Delay.Seconds(2);
		}

		[StepDefinition(@"I close All the current windows")]
		public void CloseAllTheCurrentWindows()
		{
			
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach(var handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				Delay.Seconds(1);
				SeleniumBrowser.WebBrowser.Close();

			}
		
		}


		[StepDefinition(@"I close All the current windows except the Main Window")]
		public void CloseAllTheCurrentWindowsExceptTheMainWindow()
		{

			string mainHandle = (string)Context.GetFromContext("MainWindowHandle");
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
			{
				if(handle ==mainHandle)
				{
					Report.Info($"Main Handle");
					//do nothing
				}
				else
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);					
					SeleniumBrowser.WebBrowser.Close();
				}
				

			}
			SeleniumBrowser.WebBrowser.SwitchTo().Window(mainHandle);


		}

		[StepDefinition(@"An alert is displayed with the message: (.*)")]
		public void AnAlertIsDisplayedWithTheMessage(string message)
		{
			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				string alertText = SeleniumBrowser.WebBrowser.SwitchTo().Alert().Text;
				Report.IsTrue(message == alertText, "Alert text does not match! Expected: " + message + ". Actual: " + alertText + ".",
					"Successfully found text in alert!");
			}
			else
			{
				Report.Failure("Alert not present!");
			}

		}

		[StepDefinition(@"I Update the TestUser: (.*) to include the name of the product saved as: (.*)")]
		public void UpdateTestVariableWithProductName(string testVariable, string savedAs)
		{
			ProductInformation myProduct = (ProductInformation)Context.GetFromContext(savedAs);
			string myproductName = myProduct.Name;
			TReVorTestUsers user = TestUsers.GetUserSavedAs(testVariable);
			string currentProductList = user.Username;
			string updatedProductList = currentProductList + "*" + myproductName;
			TReVorSettings.TReVor.CacheFunctions.UpdateTestUsername(testVariable, updatedProductList);
			TestUsers.RefreshUsers();
			//Webviewer Products
		}


		[StepDefinition(@"I confirm the UPC Retailer and Feed page opened in a new tab and navigate to it")]
		public void SwitchToUPCRetailerAndFeedTab()
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			UL.Automation.SpecFlow.Classes.Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				Report.Info("Switching tab");
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h1[contains(text(), 'WERCSmart Product ID')]"), 2) != null)
				{
					Report.Success("The UPC Retailer and Feed page opened in a new tab. Successfully switched to that tab.");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
			Report.Screenshot();
			Delay.Seconds(10);
		}


		[StepDefinition(@"I switch to the '(.*)' tab")]
		public void WhenISwitchToTheTab(string tabName)
		{
			GeneralUtilities.SwitchToDefaultContent();
			Delay.Seconds(Delay.SpeedFactor * 1);
			StudioNavBar SNB = new StudioNavBar();
			bool success = SNB.GetTabNum(tabName, out int index);
			if (success)
			{
				Report.IsTrue(SNB.ClickSwitchTabs(tabName), $"Failed to switch to the tab {tabName}", $"Successfully switched to the tab {tabName}", true);
				GeneralUtilities.SwitchToFrame($"<contains(@data-frameid,'{tabName}')>");
			}
			else
			{
				Report.Failure($"There was no such Tab named {tabName}");
			}
		}

		[StepDefinition(@"the Security Manager page should load")]
		public void ThenTheSecurityManagerPageShouldLoad()
		{
			SecurityManager sm = new SecurityManager();
			Delay.Seconds(1);
			Report.IsTrue(sm.WaitForContainerToBeVisible(), "Failed, could not find the Security Manager page.", "Successfully found the Security Manager page.", true);
		}

		[StepDefinition(@"the Rule Writer page should load")]
		public void ThenTheRuleWriterPageShouldLoad()
		{
			RuleWriter rw = new RuleWriter();
			Delay.Seconds(1);
			GeneralUtilities.SwitchToFrame($"<contains(@data-frameid,'Rule Writer')>");
			Report.IsTrue(rw.FoundContainerEl(), "Failed, could not find the Rule Writer page.", "Successfully found the Rule Writer page.", true);
			
			
		}

		[StepDefinition(@"the Material Management Dashboard page should load")]
		public void ThenTheDashboardPageShouldLoad()
		{
			DashboardPage dashboardPage = new DashboardPage();

			int i = 0;
			while (dashboardPage.ContainerElement == null && i < 20)
			{
				dashboardPage = new DashboardPage();
				i++;
				Delay.Seconds(1);
			}
			Report.IsTrue(dashboardPage.WaitForContainerToBeVisible(timeout: 30), "Failed to find the Dashboard page", "Successfully found the Dashboard page.", true);
		}

		[StepDefinition(@"the '(.*)' window (should|should not) load")]
		public void ThenTheWindowShouldLoad(string windowName, string shouldOrShouldNot)
		{
			windowName = GeneralUtilities.ReplaceWithContext(windowName);
			if (shouldOrShouldNot == "should")
			{
				Report.IsTrue(StudioUtilites.SwitchToWindow(windowName), "Failed to switch Windows", "Successfully switched windows", throwException: true);
				Report.IsTrue(StudioUtilites.SwitchToWindow("UL Wercs Studio", false), "Failed to switch Windows", "Successfully switched windows");
			}
			else
			{
				Report.IsFalse(StudioUtilites.SwitchToWindow(windowName), "Failed, the window did exist.", "Successfully could not switch windows", throwException: true);
				Report.IsTrue(StudioUtilites.SwitchToWindow("UL Wercs Studio", false), "Failed to switch Windows", "Successfully switched windows");
			}
		}

		[StepDefinition(@"I switch to the '(.*)' window")]
		public void GivenISwitchToTheWindow(string windowName)
		{
			windowName = GeneralUtilities.ReplaceWithContext(windowName);
			Report.IsTrue(StudioUtilites.SwitchToWindow(windowName), "Failed to switch Windows", "Successfully switched windows", true);
		}


		[StepDefinition(@"I close the '(.*)' window")]
		public void ThenCloseTheSpecifiedWindow(string windowName)
		{
			try
			{
				string mainWindowHandle = (string)Context.GetFromContext("BaseWindow");
				if (mainWindowHandle == null)
				{
					throw new Exception("No Main Window Handle found in context!");
				}
				windowName = GeneralUtilities.ReplaceWithContext(windowName);
				bool found = StudioUtilites.SwitchToWindow(windowName);
				Report.IsTrue(found, "Failed to switch Windows", "Successfully switched windows");
				if (found)
				{
					Report.Info("Attempting to close the current window");
					WebDriver.CurrentDriver.Close();
					Report.Info("Current window closed, switching to the BaseWindow");
					WebDriver.CurrentDriver.SwitchTo().Window(mainWindowHandle);
					Report.Success("Browser window switched successfully!");
					Report.Screenshot();
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I verify the following users exist and if not I create them using (.*)")]
		public void WhenIVerifyTheFollowingUsersExist(string savedAs, Table table)
		{
			ReportSettings.UseSubSteps = true;
			bool found = Context.FeatureContext.TryGetValue("TryGetUsers", out var result);
			bool TestFinished = result != null && (bool)result == false;
			if (!found || TestFinished)
			{
				if (!Context.FeatureContext.ContainsKey("TryGetUsers"))
				{
					Context.FeatureContext.Add("TryGetUsers", false);
				}
				else
				{
					Context.FeatureContext["TryGetUsers"] = false;
				}
				//Attempt to log in as each user in the table, and if they cant log in create them.
				List<TableRow> usersToCreate = new List<TableRow>();
				var header = new Steps_Header();
				var LS = new LoginScreen();
				var S_SM = new Steps_SecurityManager();
				foreach (var iuser in table.Rows)
				{
					var user = iuser["username"];

					TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(user);
					bool credentialsFound = trevuser != null;

					//navigate to SHA
					ReportSettings.UseSubSteps = true;
					var myStepsSha = new Steps_SHA();
					Report.StartStep("I navigate to Studio");
					myStepsSha.GivenINavigateToStudio();

					if (credentialsFound)
					{
						Report.StartSubStep($"Given I attempt to login as stored user {user}");

						Report.IsTrue(LS.LoginAsUser(user), "Failed to enter login information for user: " + user, "Successfully entered login information for  user: " + user);

						if (LS.DispayErrorMessage("Invalid login"))
						{
							Report.Info($"Need to create user: {user}");
							usersToCreate.Add(iuser);
						}
						else
						{
							Report.Info("User already created, logging out.");

							//Report.StartSubStep("Then I switch to the 'Material Management' tab");
							//this.WhenISwitchToTheTab("Material Management");
							Report.StartSubStep("When I click to open the 'My Wercs' menu and select 'Log Out'");

							header.WhenIClickToOpenTheMenuAndSelect("My Wercs", "Log Out");
						}
					}
					else
					{
						Report.Error($"Could not find the credentials needed from TReVor for: '{user}'. Please manually add the credentials needed to TReVor.");
						Report.EndScenario();
						return;
					}
				}
				if (usersToCreate.Count > 0)
				{
					Report.StartSubStep($"Attempt to log in as {savedAs}");
					//bool success = TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var credentials);

					TReVorTestUsers trevuser2 = TestUsers.GetUserSavedAs(savedAs);
					bool success = trevuser2 != null;

					if (Report.IsTrue(success && new LoginScreen().LoginAsUser(savedAs), "Failed to login to WERKSmart as user: " + savedAs, "Successfully logged into WERKSmart as user: " + savedAs))
					{
						


						Report.StartSubStep("When I click to open the 'Management' menu and select 'Security Manager'");
						header.WhenIClickToOpenTheMenuAndSelect("Management", "Security Manager");

						Report.StartSubStep("Then I switch to the 'Security Manager' tab");
						this.WhenISwitchToTheTab("Security Manager");

						Report.StartSubStep("Then the Security Manager page should load");
						this.ThenTheSecurityManagerPageShouldLoad();

						Report.StartSubStep("When In Security Manager, I click the 'Users and roles' button");
						S_SM.WhenInSecurityManagerIClickTheButton("Users and roles");

						Report.StartSubStep("Then the 'Users and Roles' window should load");
						this.ThenTheWindowShouldLoad("Users and Roles", "should");

						foreach (var iuser in usersToCreate)
						{
							var user = iuser["username"];

							Report.StartSubStep($"Given I switch to the 'Users and Roles' window");
							this.GivenISwitchToTheWindow("Users and Roles");


							Report.StartSubStep($"When Under 'User Name' I search for the username stored in '{user}'");
							S_SM.WhenISearchForTheUserNameForTheStoredUserSCREENSECURITY("User Name", user);

							Report.StartSubStep($"Then Under 'User Name' I double click the username stored in '{user}'");
							SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();

							TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(user);
							bool credentialsFound = trevuser != null;

							if (credentialsFound)
							{
								if (SM_UAR.DoubleClickUserName("User Name", user))
								{
									//Case where the user exists
									Report.StartSubStep($"Then I close the 'Edit' window");
									this.ThenCloseTheSpecifiedWindow("Edit");
									continue;
								}
								else
								{
									//Case where the user doesnt exist

									
									Report.StartSubStep("Then in the 'Users and Roles' window, I click the 'Add Row' button");
									S_SM.ThenInTheWindowIClickTheAddEditDeleteButton("Users and Roles", "Add Row");

									Report.StartSubStep("Then the 'Add' window should load");
									this.ThenTheWindowShouldLoad("Add", "should");

									Report.StartSubStep("Given I switch to the 'Add' window");
									this.GivenISwitchToTheWindow("Add");

									var first = iuser["FirstName"];
									var last = iuser["LastName"];
									var role = iuser["Role"];
									var EmailAdd = iuser["EmailAddress"];

									Report.StartSubStep($"Then in the 'Add' window, I enter the First Name '{first}'");
									SecurityManager_AddUser SM_AU = new SecurityManager_AddUser();
									Report.IsTrue(SM_AU.EnterFirstName(first), "Failed to enter the first name.", "Successfully entyered the first name.");

									Report.StartSubStep($"Then in the 'Add' window, I enter the Last Name '{last}'");
									Report.IsTrue(SM_AU.EnterLastName(last), "Failed to enter the last name.", "successfully entered the last name.");

									//15 char limit on user name
									Report.StartSubStep($"Then in the 'Add' window, I enter the Username '{trevuser.Username}'");
									Report.IsTrue(SM_AU.EnterUserName(trevuser.Username), "Failed to enter the username.", "successfully entered the username.");

									Report.StartSubStep($"Then in the 'Add' window, I enter the Email Address '{EmailAdd}'");
									Report.IsTrue(SM_AU.EnterEmail(EmailAdd), "Failed to enter the email address.", "Successfully entered the email address.");
									Delay.Seconds(5);

									Report.StartSubStep($"Then in the 'Add' window, I select the role '{role}'");
									var roleSelected = Report.IsTrue(SM_AU.SelectRole(role), $"Failed to select the role {role}", $"Successfully selected the role {role}", throwException: true);

									Report.StartSubStep($"Then in the'Add' window, I click to select the back up user");
									Report.IsTrue(SM_AU.ClickBackupUserBttn(), "Failed, could not click the back up user button.", "Success, could click the back up user button.");

									Report.StartSubStep("Then the 'Select user' window should load");
									this.ThenTheWindowShouldLoad("Select user", "should");

									Report.StartSubStep("Given I switch to the 'Select user' window");
									this.GivenISwitchToTheWindow("Select user");

									Report.StartSubStep("When in the 'Select user' window, I click the filter button");
									SecurityManager_SelectUser SM_SU = new SecurityManager_SelectUser();
									Report.IsTrue(SM_SU.ClickFilterBtn(), "Failed to click the filter button", "Successfully clicked the filter button");

									Report.StartSubStep($"Then in the 'Select user' window, I filter for 'User Name' 'Starts with...' '{savedAs}'");
									Report.IsTrue(SM_SU.SelectFilterType("User Name", "Starts with..."), "Failed could not select the dropdown.", "Success, could select the dropdown");
									Report.IsTrue(SM_SU.EnterFilterText("User Name", trevuser2.Username), $"Failed to enter the user {trevuser2.Username}");

									Report.StartSubStep("Then in the 'Select user' window, I click to apply the filter.");
									Report.IsTrue(SM_SU.ClickApplyFilterBtn(), "Could not click to apply the filter.");

									Report.StartSubStep($"Then in the 'Select user' window, I select the 'User Name' stored in '{savedAs}'");
									Report.IsTrue(SM_SU.SelectItem("User Name", trevuser2.Username), "Failed to select the 'User Name' stored in '{savedAs}'");

									Report.StartSubStep("Given I switch to the 'Add' window");
									this.GivenISwitchToTheWindow("Add");

									Report.StartSubStep($"Then in the 'Add' window, I click to select the plant for the user");
									Report.IsTrue(SM_AU.ClickPlantBttn(), "Failed, could not click the plant button.", "Success, could click the plant button.");

									Report.StartSubStep("Then the 'Select location' window should load");
									this.ThenTheWindowShouldLoad("Select location", "should");

									Report.StartSubStep("Given I switch to the 'Select location' window");
									this.GivenISwitchToTheWindow("Select location");

									Report.StartSubStep("When in the 'Select location' window, I select the 'Plant ID' 'WERCS'");
									SecurityManager_SelectLocation SM_SL = new SecurityManager_SelectLocation();
									Report.IsTrue(SM_SL.SelectItem("Plant ID", "WERCS"), "Failed to select the item 'WERCS' under 'Plant ID'", "Successfully selected the item 'WERCS' under 'Plant ID'");

									Report.StartSubStep("Given I switch to the 'Add' window");
									this.GivenISwitchToTheWindow("Add");

									Report.StartSubStep($"Then in the 'Add' window, I enter the password saved in '{user}'");
									Report.IsTrue(SM_AU.EnterPassword(trevuser.Password), $"Failed to enter the password for {user}", $"Successfully entered the password for {user}");

									Report.StartSubStep($"Then in the 'Add' window, I confirm the password saved in '{user}'");
									Report.IsTrue(SM_AU.ConfirmPassword(trevuser.Password), $"Failed to confirm the password for {user}", $"Successfully confirmed the password for {user}");

									Report.StartSubStep("Then in the 'Add' window, I click the Save button");
									Report.IsTrue(SM_AU.ClickSaveBttn(), $"Failed to click the save button", $"Successfully clicked the save button.", throwException: true);

									Report.StartSubStep("Then the 'Add' window should not load");
									this.ThenTheWindowShouldLoad("Add", "should not");
								}


							}
							else
							{
								Report.Error($"Could not find the Credentials for {user}");
								Report.EndScenario();
								return;
							}
						}
						Report.StartSubStep("Given I close the 'Users and Roles' Window");
						this.ThenCloseTheSpecifiedWindow("Users and Roles");

						Report.StartSubStep($"Given I switch to the 'UL Wercs Studio' window");
						this.GivenISwitchToTheWindow("UL Wercs Studio");

						Report.StartSubStep("Then I switch to the 'Security Manager' tab");
						this.WhenISwitchToTheTab("Security Manager");

						Report.StartSubStep("When I click to open the 'My Wercs' menu and select 'Log Out'");
						header.WhenIClickToOpenTheMenuAndSelect("My Wercs", "Log Out");
					}
				}
				if (!Context.FeatureContext.ContainsKey("TryGetUsers"))
				{
					Context.FeatureContext.Add("TryGetUsers", true);
				}
				else
				{
					Context.FeatureContext["TryGetUsers"] = true;
				}
			}
			else
			{
				Report.Info("Test for users already ran for this feature, skipping.");
			}
			Report.Info($"Navigating to WS Landing page...");
			new GlobalSteps().NavigateToLandingPage();

			Report.StartStep($"Setting the current SHA User to feature context...");		

			string firstuser = table.Rows[0]["username"];

			if (!Context.FeatureContext.ContainsKey("QASHAAccount"))
			{
			Report.Info($"key QASHAAccount did not exist...");
			Context.FeatureContext.Add("QASHAAccount", firstuser);
			}
			else
			{
				Report.Info($"key QASHAAccount did  exist, updating instead");
				Context.FeatureContext["QASHAAccount"] = firstuser;

			}			

			Report.Info($"Finished setting the Feature SHA user");
		}

		[StepDefinition(@"I Create SHA processing Rules for the accounts listed in the table:")]
		public void ICreateProcessingRulesForSHAAccountsListed(Table table)
		{
			ReportSettings.UseSubSteps = true;
			var header = new Steps_Header();
			var LS = new LoginScreen();
			var S_SM = new Steps_SecurityManager();
			var S_RW = new Steps_RuleWriter();
			//do a foreach user in table (create list of strings from table etc)


			var exampleUser = table.Rows[0]["username"];

			TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(exampleUser);
			bool credentialsFound = trevuser != null;

			//navigate to SHA
			ReportSettings.UseSubSteps = true;
			var myStepsSha = new Steps_SHA();
			Report.StartStep("I navigate to Studio");
			myStepsSha.GivenINavigateToStudio();

			Report.IsTrue(LS.LoginAsUser(exampleUser), "Failed to enter login information for user: " + exampleUser, "Successfully entered login information for  user: " + exampleUser);


			//string exampleUser = "test";

			Report.StartSubStep("When I click to open the 'Management' menu and select 'Rule Writer'");
			header.WhenIClickToOpenTheMenuAndSelect("Management", "Rule Writer");

			Report.StartSubStep("Then I switch to the 'Rule Writer' tab");
			this.WhenISwitchToTheTab("Rule Writer");

			Report.StartSubStep("Then the Rule Writer page should load");
			this.ThenTheRuleWriterPageShouldLoad();

			// Click all rules

			Report.StartSubStep("When In Security Manager, I click the 'All Rules' button");
			S_RW.WhenInRuleWriterIClickTheAllRulesButton();

			Report.StartSubStep("Then the 'Rules Editor' window should load");
			this.ThenTheWindowShouldLoad("Rules Editor", "should");

			Report.StartSubStep($"Given I switch to the 'Rules Editor' window");
			this.GivenISwitchToTheWindow("Rules Editor");

			Report.StartSubStep("When in the 'Rules Editor' window, I click the filter button");
			RuleWriter_RulesEditor RW_RE = new RuleWriter_RulesEditor();
			Report.IsTrue(RW_RE.ClickFilterBtn(), "Failed to click the filter button", "Successfully clicked the filter button");

			Report.StartSubStep($"Then in the 'Rules Editor' window, I filter for 'Name' 'Starts with...' 'BevB -'");
			Report.IsTrue(RW_RE.SelectFilterType("Name", "Starts with..."), "Failed could not select the dropdown.", "Success, could select the dropdown");
			Report.IsTrue(RW_RE.EnterFilterText("Name", "BevB -"), $"Failed to enter the user 'BevB -'");
			Report.StartSubStep("Then in the 'Rules Editor' window, I click to apply the filter.");
			Report.IsTrue(RW_RE.ClickApplyFilterBtn(), "Could not click to apply the filter.");
			Report.StartSubStep($"Then in the 'Rule Editor' window, I Look for the Rule with Name: 'BevB -' ");
			Report.IsTrue(RW_RE.FindItem("Name", "BevB -"), "Failed to find the 'Name' BevB -'");

			var baseRuleRow= RW_RE.GetRuleRowFromTable("Name", "BevB -");

			if (baseRuleRow.IsNullOrEmpty())
			{
				Report.Failure($"The base rule row element was null");
				Report.Screenshot();
				return;
			}

			S_RW.WhenInRuleWriterIRightClickTheRulAndSelectNew("BevB -");
				

			Report.StartSubStep($"Given I switch to the 'New Rule' window");
			this.GivenISwitchToTheWindow("New Rule");


			Report.StartSubStep("When in the 'New Rule' window, I click the 'Type D' Option");
			RuleWriter_NewRule RW_NR = new RuleWriter_NewRule();
			Report.IsTrue(RW_NR.SelectGivenRuleType("Type D"), "Failed to click the Rule Type", "Successfully clicked the Rule Type");

			Report.StartSubStep("When in the 'New Rule' window, I click the Copy selected rule button");
			Report.IsTrue(RW_NR.ClickCopySelectedRule(), "Failed to click the copy selected rule button", "Successfully clicked the Copy selected rule button");
			Report.IsTrue(RW_NR.CopyRuleActive(), "Failed to activate the copy selected rule option", "Successfully activated the copy selected rule option");
			Report.StartSubStep($"When in the 'New Rule' window, I enter the value '{exampleUser}- additional doc' into the Name text box");
			Report.IsTrue(RW_NR.EnterNameText(exampleUser+"- additional doc"), "Failed to enter text", "Successfully entered text");
			Report.StartSubStep("When in the 'New Rule' window, I click the OK button");
			Report.IsTrue(RW_NR.ClickOKButton(), "Failed to click OK", "Successfully clicked OK");

			Report.StartSubStep("Then the 'Rule View' window should load");
			this.ThenTheWindowShouldLoad("Rule View", "should");

			Report.StartSubStep($"Given I switch to the 'Rule View' window");
			this.GivenISwitchToTheWindow("Rule View");
			RuleWriter_RuleView RW_RV = new RuleWriter_RuleView();

			Report.StartSubStep($"In the Rule View popup I get the text found in the 'Will contain the results of' box");
			string foundText= RW_RV.GetContainedResultsText();
			Report.Info($"Found Text was {foundText}");
			if(Report.IsTrue(foundText== "UD_RUNSQLD('[SP_CREATE_DOC_QUEUE] '@' ,'BEVB' ')","Found text was not as expected","The found text was as expected"))
			{
				string newText = foundText.Replace("BEVB", exampleUser);
				Report.IsTrue(RW_RV.ClearThenEnterTextIntoContainedResultsBox(newText), "Failed to enter text", "Enter Text was performed successfully");

				Report.IsTrue(RW_RV.ClickSaveButton(), "Failed to click save", "Successfully clicked save");
				Report.IsTrue(RW_RV.WaitForRulesEditorToBeGone(), "The Rule view was still showing...", "The rule view was no longer showing.");

				Report.StartSubStep("Then the 'Rules Editor' window should load");
				this.ThenTheWindowShouldLoad("Rules Editor", "should");

				Report.StartSubStep($"Given I switch to the 'Rules Editor' window");
				this.GivenISwitchToTheWindow("Rules Editor");

				Report.StartSubStep("Given I close the 'Rules Editor' Window");
				this.ThenCloseTheSpecifiedWindow("Rules Editor");
				

				Report.StartSubStep($"Given I switch to the 'UL Wercs Studio' window");
				this.GivenISwitchToTheWindow("UL Wercs Studio");

				Report.StartSubStep("Then I switch to the 'Rule Writer' tab");
				this.WhenISwitchToTheTab("Rule Writer");

				Report.StartSubStep("When I click to open the 'My Wercs' menu and select 'Log Out'");
				header.WhenIClickToOpenTheMenuAndSelect("My Wercs", "Log Out");
				return;
			}
			else
			{
				Report.Info($"The found text was not as expected so the rule will not be valid");
			}


			



		}

	}


}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using NTTQA_TReVor_Module.Cache;
using NTTQA_TReVor_Module.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Steps;

[assembly: Apartment(ApartmentState.STA)]

namespace WERCSmart
{
	[Binding]
	public class GlobalSteps
	{
		[BeforeFeature(Order = 1)]
		public static void SetTestURL()
		{
			GlobalParameters.TestUrl = TestVariables.GetVariableSavedAs("TestURL");
		}



		[StepDefinition(@"I login as the administrator")]
		[StepDefinition(@"I login as the administrator")]
		[When(@"I login as the administrator")]
		[Then(@"I login as the administrator")]
		public void GivenILoginAsTheAdministrator()
		{
			LoginToAccount("ProductAccount");
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - (WERCs Visual Account|WERCs Premium Subscription Account|WERCs Product Account|WERCs ULSC Account)")]
		public void LoginToWERCSmartAdmin(string type)
		{
			switch (type)
			{
				case ("WERCs Visual Account"):
					LoginToAccount("VisualAccount");
					break;
				case ("WERCs Premium Subscription Account"):
					LoginToAccount("PremiumSubscriptionAccount");
					break;
				case ("WERCs Product Account"):
					LoginToAccount("ProductAccount");
					break;
				case ("WERCs ULSC Account"):
					LoginToAccount("ULSCAccount");
					break;
			}
		}


		[StepDefinition(@"I login into the WERCSmart Portal - (data consent Account|Division Account|Administrator Role|Canada has all data account)")]
		[StepDefinition(@"I Login into WERCSmart Portal - (data consent Account|Division Account|Administrator Role|Canada has all data account)")]
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
					LoginToAccount("DataConsentAccount");
					break;
				case ("Division Account"):
					LoginToAccount("DivisionAccount");
					break;
				case ("Administrator Role"):
					LoginToAccount("ProductAccount");
					break;
				case ("Canada has all data account"):
					LoginToAccount("CanadaHasAllData");
					break;
			}
		}

		[StepDefinition(@"I log in with the (subscription|without subscription) without products account")]
		public void LoginWithSubscriptionType(string type)
		{
			switch (type)
			{
				case ("subscription"):
					LoginToAccount("SubCart");
					break;
				case ("without subscription"):
					LoginToAccount("ProductsInCart");
					break;
			}
		}

		[StepDefinition(@"I log in with the account saved in TReVor as: (.*)")]
		public void ILogInWithTheAccountSavedInTrevorAs(string accountSavedAs)
		{
			LoginToAccount(accountSavedAs);
		}

		[Then(@"The home screen should load")]
		public void ThenTheHomeScreenShouldLoad()
		{
			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
			GeneralUtilities.Wait_for_load_finish();
		}

		public void LoginToAccount(string accountSavedAs)
		{
			if (SeleniumUtilities.Context.Contains("CurrentLogin"))
			{
				accountSavedAs = SeleniumUtilities.Context.GetFromContext("CurrentLogin").ToString();
				Report.Info("Already logged in as " + accountSavedAs + " so changing login to that");
			}
			else
			{
				SeleniumUtilities.Context.AddToContext("CurrentLogin", accountSavedAs);
			}
			var user = TestUsers.GetUserSavedAs(accountSavedAs);

			if (new TopMenuBar().LoggedIn())
			{
				Report.Info("Logged in, logging out");
				Report.Screenshot();
				new TopMenuBar().ClickSignOut();
				Delay.Seconds(3);
				Report.Screenshot();
			}

			if (user == null)
			{
				var Branch = GlobalParameters.Branch;
				string regexPattern = @"^.*(?=(\/))";
				Regex regex = new Regex(regexPattern);
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
				GivenILogInWithEmailXAndPasswordY(user.Username, user.Password);
			}
		}

		[StepDefinition(@"I log in with email: (.*) and password: (.*)")]
		public void GivenILogInWithEmailXAndPasswordY(string username, string password)
		{
			Report.Info("Beginning I login with email and password");
			var selLandingPage = new LandingPage();
			if (!selLandingPage.Wait_for_load(5))
			{
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//p[contains(text(),'HTTP Error 503')]"), 2) != null)
				{
					throw new Exception("HTTP Server error 503 was thrown!");
				}
				throw new Exception("Landing page did not load!");
			}
			Report.Info("Clicking 'Log In' on the Landing Page");
			selLandingPage.Click_Login();
			var selTopMenuBar = new TopMenuBar();
			var selHomepage = new Homepage();
			int i = 0;
			while ((!selHomepage.Wait_for_load(1) || !selTopMenuBar.Wait_for_load(1)) && i < 5)
			{
				Report.Info("========== Login Attempt: " + i + " ==========");
				var selLogin = new Login();
				if (!Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!"))
				{
					break;
				}
				Report.Info("Entering Email: '" + username + "'");
				selLogin.EmailField = username;
				Delay.Seconds(1);
				Report.Info("Entering Password: '" + password + "'");
				selLogin.PasswordField = password;
				Report.Info("Clicking login");
				selLogin.Click_Login();
				selHomepage = new Homepage();
				if (selHomepage.Wait_for_load(60))
				{
					Report.Success("Successfully logged in!");
					GeneralUtilities.Wait_for_load_finish();
					return;
				}
				var modalDialog = new ModalDialog();
				if (modalDialog.Wait_for_load(1))
				{
					modalDialog.Click_Closex();
					Delay.Seconds(Delay.SpeedFactor * 1);

					selHomepage = new Homepage();
					if (selHomepage.Wait_for_load(10))
					{
						Report.Success("Successfully logged in!");
						GeneralUtilities.Wait_for_load_finish();

						return;
					}
				}
				i++;
				Delay.Seconds(1);
			}
			var selLogin2 = new Login();
			if (!Report.IsTrue(selLogin2.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!"))
			{
				Report.Failure("Failed to log in!");
				return;
			}
			Report.Info("Entering Email: '" + username + "'");
			selLogin2.EmailField = username;

			Report.Info("Entering Password: '" + password + "'");
			selLogin2.PasswordField = password;
			Report.Info("Clicking login");
			selLogin2.Click_Login();
			selHomepage = new Homepage();
			if (selHomepage.Wait_for_load(30))
			{
				Report.Success("Successfully logged in!");
				GeneralUtilities.Wait_for_load_finish();
				return;
			}
			Report.Failure("Failed to log in!");
		}

		[StepDefinition(@"I logout")]
		public void GivenILogout()
		{
			TopMenuBar thisTopMenuBar = new TopMenuBar();
			Report.IsTrue(thisTopMenuBar.ClickSignOut(), "Failed to click sign out", "Successfully clicked sign out");
		}

		[StepDefinition(@"I create a new email address and save as: (.*)")]
		public void GivenICreateANewEmailAddressAndSaveAs(string saveAs)
		{
			string myDate = System.DateTime.Now.ToString("HHmmddMMyy");

			string myEmail = EmailFunctions.CreateEmail(myDate);
			SeleniumUtilities.Context.AddToContext(saveAs, myEmail);
			Report.Info("Saved email: " + myEmail);
		}

		[StepDefinition(@"If not already created, I create a user: (.*) with the following parameters:")]
		public void GivenIfNotAlreadyCreatedICreateAUserXWithTheFollowingParameters(string savedAs, Table parameters)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- If not already created, I create a user: '" + savedAs + "'");

			if (savedAs == "New_Sub")
			{
				savedAs = "New_Sub" + "_" + System.DateTime.Now.ToString("HHmmddMMyy");
				FeatureContext.Current.Add("CurrentAccount", savedAs);
			}

			try
			{
				if (!FeatureContext.Current.ContainsKey(savedAs))
				{
					Report.Info("Setting up account details for user: '" + savedAs + "'");
					var account = parameters.CreateInstance<WERCSmartUser>();
					account.Email = EmailFunctions.CreateEmail(account.Email);
					account.Identifier = savedAs;
					SeleniumUtilities.Context.AddToContext(savedAs, account, true);
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

		[When(@"I wait for (.*) seconds")]
		public void WhenIWaitForSeconds(int p0)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I wait for " + p0.ToString() + " seconds.");
			try
			{
				Delay.Seconds(p0);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I scroll to the (top|bottom) of the page")]
		public void ThenIScrollToTheOfThePage(string topbottom)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Scroll to " + topbottom + " of page");
			try
			{
				Report.Info("Attempting to scroll to the " + topbottom + " of the page");
				if (topbottom == "top")
				{ GeneralUtilities.ScrollToTopOfPage(); }
				else
				{ GeneralUtilities.ScrollToBottomOfPage(); }

				Report.Screenshot();
				Report.Success("Scrolled to the " + topbottom + " of the page!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I navigate to the landing page")]
		public void NavigateToLandingPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigate to landing page");
			try
			{
				Report.Info("Navigating to the landing page");
				SeleniumBrowser.Navigate(GlobalParameters.TestUrl);
				Delay.Seconds(1);
				var allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
				if (SeleniumBrowser.Alert.IsAlertPresent())
				{
					Report.Info("Alert is present, accepting");
					Report.Screenshot();
					SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
					Delay.Seconds(1);
					allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
					SeleniumBrowser.WebBrowser.SwitchTo().Window(allWindows[0]);
					Delay.Seconds(1);

					if (allWindows.Count == 1)
					{
						Report.Success("Successfully navigated to the landing page!");
						Report.Screenshot();
						return;

					}
				}

				try
				{
					allWindows = SeleniumBrowser.WebBrowser.WindowHandles;
					Report.Info("Current tabs/windows open:");
					foreach (var windowHandle in allWindows)
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Window(windowHandle);
						Report.Info("url: " + SeleniumBrowser.GetActiveTabURL());
					}

					foreach (var windowHandle in allWindows)
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Window(windowHandle);

						if (SeleniumBrowser.GetActiveTabURL().Contains(GlobalParameters.TestUrl))
						{
							Report.Info("Current url: " + SeleniumBrowser.GetActiveTabURL());
							SeleniumBrowser.Navigate(GlobalParameters.TestUrl);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigate to URL: " + url);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the current URL contains: " + url);
			try
			{
				Report.Info("Checking that the current URL contains: " + url);
				var currentUrl = SeleniumBrowser.WebBrowser.Url;
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Closing current window");
			try
			{
				var mainWindowHandle = SeleniumUtilities.Context.GetFromContext("MainWindowHandle");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - UNDER DEVELOPMENT");
			try
			{
				Report.Warn("AREA UNDER DEVELOPMENT");
				Report.Failure("AREA UNDER DEVELOPMENT");
				var selBulkActions = new BulkActions();
				if (selBulkActions.Wait_for_load(5))
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I save the current emails in this inbox so I can locate the new one when it arrives");
			try
			{
				var emailAddress = SeleniumUtilities.Context.GetFromContext(savedas).ToString();
				Report.Info("Storing inbox for address: " + emailAddress);
				EmailFunctions.StoreCurrentInbox(emailAddress);
				Report.Success("Inbox stored successfully!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I created an email and saved to use in other locations");
			try
			{
				var email = EmailFunctions.CreateEmail(createdEmail);
				SeleniumUtilities.Context.AddToContext(savedAs, email);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I create a new email address");
			try
			{
				string myDate = System.DateTime.Now.ToString("HHmmddMMyy");

				string myEmail = EmailFunctions.CreateEmail(myDate);

				if (myEmail == "")
				{
					throw new Exception("Failed to Create a New Email Address");
				}
				ScenarioContext.Current.Add("CurrentEmail", myEmail);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking whether there is a new email for email Address: " + savedAs + " from " + emailFrom + " with title: " + title);
			try
			{
				if (emailFrom.ToLower() == "<sitenotification>")
				{
					emailFrom = TestVariables.GetVariableSavedAs("NotificationEmail");
				}

				var email = string.Empty;
				if (savedAs == "ForgotPW_SecQs")
				{
					var user = (WERCSmartUser)SeleniumUtilities.Context.GetFromContext(savedAs);
					email = user.Email;
				}
				else
				{
					email = SeleniumUtilities.Context.GetFromContext(savedAs).ToString();
				}

				if (EmailFunctions.WaitForInboxDifferences(email))
				{
					var differences = EmailFunctions.GetInboxDifferences(email);
					Report.Info("Found " + differences.Count() + " emails");

					var matchingEmail = differences.FirstOrDefault(x => x.From.FirstOrDefault().Address.ToLower() == emailFrom.ToLower() && x.Subject == title);


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

					SeleniumUtilities.Context.AddToContext("Matching", matchingEmail);
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
		[StepDefinition(@"the body of the email should show: (.*)")]
		public void ThenTheBodyOfTheEmailShouldShow(string bodyText)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)SeleniumUtilities.Context.GetFromContext("Matching");
				var emailBody = EmailFunctions.getEmailBody(email);
				Report.Info("Body of the Email was: " + emailBody);
				Report.IsTrue(emailBody == bodyText, "Body text did not match correctly!", "Body text matched correctly!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)SeleniumUtilities.Context.GetFromContext("Matching");
				var emailBody = EmailFunctions.getEmailBody(email);
				Report.Info("Body of the Email was: " + emailBody);
				Report.IsTrue(emailBody.Contains(bodyText), "Body text did not match correctly!", "Body text matched correctly!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Switch to Tab: " + url);
			try
			{
				Report.Info("Switch to Tab: " + url);
				var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				SeleniumUtilities.Context.AddToContext("MainWindowHandle", currentHandle);
				var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				foreach (var handle in allHandles)
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
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			SeleniumUtilities.Context.AddToContext(savedAs, currentHandle);
		}

		[StepDefinition(@"I close the window saved as: (.*)")]
		public void SwitchBackToMainWindow(string savedAs)
		{
			var handleToClose = SeleniumUtilities.Context.GetFromContext(savedAs)?.ToString();
			if (handleToClose == null)
			{
				Report.Failure("Unable to find window saved as: " + savedAs + " in context to close!");
				return;
			}
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			var handleMatch = allHandles.First(x => x == handleToClose);
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
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			SeleniumUtilities.Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			SeleniumUtilities.Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			var mainHandle = SeleniumUtilities.Context.GetFromContext("MainWindowHandle").ToString();
			SeleniumBrowser.WebBrowser.Close();
			SeleniumBrowser.WebBrowser.SwitchTo().Window(mainHandle);
		}

		[Given(@"If a modal dialog opens I skip it")]
		public void GivenIfAModalDialogOpensISkipIt()
		{
			ModalDialog thisModalDialog = new ModalDialog();
			if (thisModalDialog.Wait_for_load(3))
			{
				Report.Info("modal dialog is opened. ");
				Report.IsTrue(thisModalDialog.Click_Skip(), "Failed to click skip button", "Clicked skip button");
			}
		}

		[Given(@"If a modal dialog opens I close it")]
		public void GivenIfAModalDialogOpensICloseIt()
		{
			ModalDialog thisModalDialog = new ModalDialog();
			if (thisModalDialog.Wait_for_load(3))
			{
				Report.Info("modal dialog is opened. ");
				Report.IsTrue(thisModalDialog.Click_Closex(), "Failed to click close button", "Clicked close button");
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
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			SeleniumUtilities.Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
			var testCaseId = GlobalParameters.TestCaseId;
			if (testCaseId != null && SeleniumUtilities.Context.GetFromContext($"UPC{testCaseId}") != null)
			{
				new StepsProductGrid().DeleteAllProductsMatchingCriteria("UPC Number", SeleniumUtilities.Context.GetFromContext($"UPC{testCaseId}").ToString());
			}
		}

		[StepDefinition("I save the TReVor test user: (.*) to context as 'TReVorTestUser'")]
		public void ISaveTheWercSmartUserStoredInTrevorAs(string savedAs)
		{
			var user = TestUsers.GetUserSavedAs(savedAs);
			if (user == null)
			{
				Report.Failure("Failed to find a user stored in TReVor: " + savedAs);
				return;
			}
			SeleniumUtilities.Context.AddToContext("TReVorTestUser", new User { Password = user.Password, Email = user.Username });
		}

		[StepDefinition(@"I update the password for the following TReVor test users:")]
		public void IUpdateThePasswordForTheFollowingTrevorTestUsers(Table users)
		{
			var usersSavedAs = new List<string>();
			TestReport.UseSubSteps = true;
			users.Rows.ForEach(x => usersSavedAs.Add(x["User"]));
			Report.Info("Updating password for the following users: " + string.Join(", ", usersSavedAs.Select(x => $"'{x}'")));
			foreach (var savedAs in usersSavedAs)
			{
				TestReport.StartStep($"I update the password for user: {savedAs}");
				ILogInWithTheAccountSavedInTrevorAs(savedAs);
				var selMyAccount = new StepsMyAccount();
				Report.Info("Navigating to My Account from the homepage");
				selMyAccount.GivenINavigateToTheMyAccountPage();
				Report.Info("Clicking Reset Password for the current logged in user");
				selMyAccount.GivenIGoToActionInUserGrid("Reset Password");
				Report.Info("Updating the password for test user " + savedAs);
				selMyAccount.IUpdateThePasswordForTrevorTestUser(savedAs);
				Report.Info("Logging out");
				GivenILogout();
				Report.Info("Checking I can log in with the new credentials");
				TestUsers.RefreshTestUserCache();
				ILogInWithTheAccountSavedInTrevorAs(savedAs);
				Report.Info("Logging out");
				GivenILogout();
			}
		}

		[StepDefinition(@"I update the password for all TReVor Test Users within the current branch")]
		public void IUpdateThePasswordForAllTrevorTestUsersWithinCurrentBranch()
		{
			TestReport.UseSubSteps = true;
			var allUsers = TestUsers.GetAllUsers();
			var usersSavedAs = allUsers.Select(x => x.SavedAs).ToList();
			Report.Info("Updating password for the following users: " + string.Join(", ", usersSavedAs.Select(x => $"'{x}'")));
			foreach (var savedAs in usersSavedAs)
			{
				var user = TestUsers.GetUserSavedAs(savedAs);
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
				TestReport.StartStep($"I update the password for user: {savedAs}");
				ILogInWithTheAccountSavedInTrevorAs(savedAs);
				var alert = new RetailPartners().WarningMessage();
				if (alert != null && alert.Contains("The recipients listed below have additional Data Consent requests"))
				{
					Report.Info("Account needs to be reviewed - data consent requests. Continuing to the next account");
					Report.Info("Logging out");
					GivenILogout();
					continue;
				}
				if (!new Homepage().Wait_for_load())
				{
					Report.Failure("Failed to log in with user: " + savedAs + ". Did not find the top menu bar!");
					if (new TopMenuBar().Wait_for_load())
					{
						Report.Info("Logging out");
						GivenILogout();
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
				GivenILogout();
				if (!new LandingPage().Wait_for_load())
				{
					Report.Info("Directed to an unexpected WercSmart landing page!");
					Report.Info("Navigating to the landing page");
					new GlobalSteps().NavigateToLandingPage();
				}
				Report.Info("Checking I can log in with the new credentials");
				TestUsers.RefreshTestUserCache();
				ILogInWithTheAccountSavedInTrevorAs(savedAs);
				Report.Info("Logging out");
				GivenILogout();
				SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
			}
		}

		[Given(@"I save to context name: (.*) and value: (.*)")]
		public void GivenISaveToContextNameAndValue(string name, string value)
		{
			ProductInformation newProductInformation = new ProductInformation();
			newProductInformation.Id = value;
			newProductInformation.Name = value;
			SeleniumUtilities.Context.AddToContext(name, newProductInformation);
		}

		[Given(@"I check alert text contains (.*) and dismiss")]
		public void GivenICheckAlertTextContainsXAndDismiss(string searchText)
		{
			//Putting this in because standard get alert functionality does not work in this page.
			if (!SeleniumBrowser.Alert.WaitForAlert(10))
			{
				SeleniumBrowser.Alert.ReloadAlert(searchText);
			}
			if (!SeleniumBrowser.Alert.WaitForAlert())
			{
				Report.Error("Alert did not appear");
			}
			string alertText = SeleniumBrowser.Alert.GetText();
			Report.IsTrue(alertText.Contains(searchText), "Alert text was not as expected. Found: " + alertText,
				"Alert text was as expected");
			Report.Screenshot();
			SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
		}

		[Given(@"I save to context name: (.*) and string value: (.*)")]
		public void GivenISaveToContextNameAndStringValue(string name, string value)
		{
			SeleniumUtilities.Context.AddToContext(name, value);
		}

		[StepDefinition(@"I move the mouse pointer by an offset of (.*) in x and (.*) in y")]
		public void MoveMousePointerByOffset(string offsetX, string offsetY)
		{
			if (!int.TryParse(offsetX, out var offsetXNum))
			{
				Report.Failure("The offset parameter must be parsable as an integer!");
				return;
			}
			if (!int.TryParse(offsetY, out var offsetYNum))
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
			SeleniumBrowser.CloseTabWithURL(SeleniumBrowser.GetActiveTabURL());
		}

		[StepDefinition(@"I close the current window")]
		public void CloseCurrentWindow()
		{
			SeleniumBrowser.WebBrowser.Close();
		}




	}
}

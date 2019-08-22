using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using Castle.Core.Internal;
using NTTQA.Selenium.Cache;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using NTTQA.Selenium.TReVor;
using NTTQA.Selenium.UniversalFunctions;

[assembly: Apartment(ApartmentState.STA)]

namespace UL.Selenium.Portal.WERCSmart.Steps
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
		public void GivenILoginAsTheAdministrator()
		{
			this.LoginToAccount("ProductAccount");
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - (WERCs Visual Account|WERCs Premium Subscription Account|WERCs Product Account|WERCs ULSC Account|NoPLProducts Account)")]
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

		[Then(@"The home screen should load")]
		public void ThenTheHomeScreenShouldLoad()
		{
			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.WaitForContainerToBeVisible(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
			GeneralUtilities.Wait_for_load_finish();
		}

		public void LoginToAccount(string accountSavedAs, bool attemptOnce = false)
		{
			TestUser user = TestUsers.GetUserSavedAs(accountSavedAs);
			if (new TopMenuBar().LoggedIn())
			{
				Report.Info("Logged in, logging out");
				Report.IsTrue(new TopMenuBar().ClickSignOut(), "Failed to click Sign Out");
			}
			if (user == null)
			{
				string Branch = GlobalParameters.Branch;
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
					return;
				}
				this.GivenILogInWithEmailXAndPasswordY(user.Username, user.Password);
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
			var selTopMenuBar = new TopMenuBar();
			var selHomepage = new Homepage();
			int i = 0;
			while ((!selHomepage.WaitForContainerToBeVisible(1) || !selTopMenuBar.Wait_for_load(1)) && i < 4)
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
				if (selHomepage.WaitForContainerToBeVisible())
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
					if (selHomepage.WaitForContainerToBeVisible(10))
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

			string myEmail = EmailFunctions.CreateEmail(myDate);
			NTTQA.Selenium.SpecFlow.Context.AddToContext(saveAs, myEmail);
			Report.Info("Saved email: " + myEmail);
		}

		[StepDefinition(@"If not already created, I create a user: (.*) with the following parameters:")]
		public void GivenIfNotAlreadyCreatedICreateAUserXWithTheFollowingParameters(string savedAs, Table parameters)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- If not already created, I create a user: '" + savedAs + "'");

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
					account.Email = EmailFunctions.CreateEmail(account.Email);
					account.Identifier = savedAs;
					NTTQA.Selenium.SpecFlow.Context.AddToContext(savedAs, account, true);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigate to landing page");
			try
			{
				Report.Info("Navigating to the landing page");
				SeleniumBrowser.Navigate(GlobalParameters.TestUrl);
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
					foreach (string windowHandle in allWindows)
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Window(windowHandle);
						Report.Info("url: " + SeleniumBrowser.GetActiveTabURL());
					}

					foreach (string windowHandle in allWindows)
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Closing current window");
			try
			{
				object mainWindowHandle = NTTQA.Selenium.SpecFlow.Context.GetFromContext("MainWindowHandle");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I save the current emails in this inbox so I can locate the new one when it arrives");
			try
			{
				string emailAddress = NTTQA.Selenium.SpecFlow.Context.GetFromContext(savedas).ToString();
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
				string email = EmailFunctions.CreateEmail(createdEmail);
				NTTQA.Selenium.SpecFlow.Context.AddToContext(savedAs, email);
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
				Context.ScenarioContext.Add("CurrentEmail", myEmail);
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

				string email = string.Empty;
				if (savedAs == "ForgotPW_SecQs")
				{
					var user = (WERCSmartUser)NTTQA.Selenium.SpecFlow.Context.GetFromContext(savedAs);
					email = user.Email;
				}
				else
				{
					email = NTTQA.Selenium.SpecFlow.Context.GetFromContext(savedAs).ToString();
				}

				if (EmailFunctions.WaitForInboxDifferences(email))
				{
					List<Mailosaur.Email> differences = EmailFunctions.GetInboxDifferences(email);
					Report.Info("Found " + differences.Count() + " emails");

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

					NTTQA.Selenium.SpecFlow.Context.AddToContext("Matching", matchingEmail);
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
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
				string emailBody = EmailFunctions.getEmailBody(email);
				//Report.Info("Body of the Email was: " + emailBody);
				// html codes are coming through from mailosaur eg. for '+' character
				string bodyDecode = System.Net.WebUtility.HtmlDecode(emailBody);
				Report.Info("Expected email body text: " + bodyText);
				Report.Info("Body of the Email was: " + emailBody);
				string actualTrimmed = bodyDecode.Replace(" ", "");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
				string emailBody = EmailFunctions.getEmailBody(email);
				// html codes are coming through from mailosaur eg. for '+' character
				string bodyDecode = System.Net.WebUtility.HtmlDecode(emailBody);
				Report.Info("Body of the Email was: " + emailBody);
				string actualTrimmed = bodyDecode.Replace(" ", "");
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
				string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				NTTQA.Selenium.SpecFlow.Context.AddToContext("MainWindowHandle", currentHandle);
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
			NTTQA.Selenium.SpecFlow.Context.AddToContext(savedAs, currentHandle);
		}

		[StepDefinition(@"I close the window saved as: (.*)")]
		public void SwitchBackToMainWindow(string savedAs)
		{
			string handleToClose = NTTQA.Selenium.SpecFlow.Context.GetFromContext(savedAs)?.ToString();
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
			NTTQA.Selenium.SpecFlow.Context.AddToContext("MainWindowHandle", currentHandle);
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
			NTTQA.Selenium.SpecFlow.Context.AddToContext("MainWindowHandle", currentHandle);
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
			string mainHandle = NTTQA.Selenium.SpecFlow.Context.GetFromContext("MainWindowHandle").ToString();
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
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			NTTQA.Selenium.SpecFlow.Context.AddToContext("MainWindowHandle", currentHandle);
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
			string testCaseId = GlobalParameters.TestCaseId;
			if (testCaseId != null && NTTQA.Selenium.SpecFlow.Context.GetFromContext($"UPC{testCaseId}") != null)
			{
				new StepsProductGrid().DeleteAllProductsMatchingCriteria("UPC Number", NTTQA.Selenium.SpecFlow.Context.GetFromContext($"UPC{testCaseId}").ToString());
			}
		}

		[StepDefinition("I save the TReVor test user: (.*) to context as 'TReVorTestUser'")]
		public void ISaveTheWercSmartUserStoredInTrevorAs(string savedAs)
		{
			TestUser user = TestUsers.GetUserSavedAs(savedAs);
			if (user == null)
			{
				Report.Failure("Failed to find a user stored in TReVor: " + savedAs);
				return;
			}
			NTTQA.Selenium.SpecFlow.Context.AddToContext("TReVorTestUser", new User { Password = user.Password, Email = user.Username });
		}

		[StepDefinition(@"I update the password for the following TReVor test users:")]
		public void IUpdateThePasswordForTheFollowingTrevorTestUsers(Table users)
		{
			var usersSavedAs = new List<string>();
			TestReport.UseSubSteps = true;
			users.Rows.ForEach(x => usersSavedAs.Add(x["User"]));
			Report.Info("Updating password for the following users: " + string.Join(", ", usersSavedAs.Select(x => $"'{x}'")));
			foreach (string savedAs in usersSavedAs)
			{
				TestReport.StartStep($"I update the password for user: {savedAs}");
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
				TestUsers.RefreshTestUserCache();
				this.ILogInWithTheAccountSavedInTrevorAs(savedAs);
				Report.Info("Logging out");
				this.GivenILogout();
			}
		}

		[StepDefinition(@"I update the password for all TReVor Test Users within the current branch")]
		public void IUpdateThePasswordForAllTrevorTestUsersWithinCurrentBranch()
		{
			TestReport.UseSubSteps = true;
			List<TestUser> users = TestUsers.GetAllUsers();
			IEnumerable<TestUser> allUsers = users.Where(x => x.SoftwareId == GlobalParameters.EditionDetails.SoftwareId && x.BranchName == GlobalParameters.Branch);
			var usersSavedAs = allUsers.Select(x => x.SavedAs).ToList();
			Report.Info("Updating password for the following users: " + string.Join(", ", usersSavedAs.Select(x => $"'{x}'")));
			foreach (string savedAs in usersSavedAs)
			{
				TestUser user = TestUsers.GetUserSavedAs(savedAs);
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
								Api.UpdateTestUserPassword(savedAs, newPassword);
								Report.Info("Navigating to the landing page");
								SeleniumBrowser.WebBrowser.Navigate().GoToUrl(TestVariables.GetVariableSavedAs("TestURL"));
								Report.Info("Checking I can log in with the new credentials");
								TestUsers.RefreshTestUserCache();
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
				TestUsers.RefreshTestUserCache();
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
				catch(Exception ex)
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
			

			string alertText= GeneralUtilities.RemoveLineBreaks(alertTextFull);

			if (alertText == null)
			{
				Report.Failure("Text was not displayed", false);
			}
			if(alertText.Contains(searchText))
			{
				Report.Info("Alert text was as expected");

			}
			else
			{
				Report.Failure($"Alert text was not as expected. Found: {alertText}", false);
			}

			//Report.IsTrue(alertText.Contains(searchText), "Alert text was not as expected. Found: " + alertText,
			//	"Alert text was as expected");

			Report.Screenshot(true);

			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}

		}

		[StepDefinition(@"I save to context name: (.*) and string value: (.*)")]
		public void GivenISaveToContextNameAndStringValue(string name, string value)
		{
			NTTQA.Selenium.SpecFlow.Context.AddToContext(name, value);
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
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				string currentTitle = SeleniumBrowser.WebBrowser.Title;
				if (currentTitle == title)
				{
					Report.Success("Tab with title was loaded");
					Report.Screenshot();
					return;
				}
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
			TestUser user = TestUsers.GetUserSavedAs(trevorSavedAs);
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

			Report.Screenshot(true);

			if (SeleniumBrowser.Alert.IsAlertPresent())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}

		}
		

		[StepDefinition("I find an existing UPC number in trevor account saved as: (.*) using feature context: (.*)")]
		public void FindExistingUpcNumberInTrevorAccountUsingFeatureContext(string trevorSavedAs, string upcSavedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I look in feature context for: " + upcSavedAs);
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
			TestReport.StartStep("I search for a UPC in SHA Manager associated with trevor user account: " + trevorSavedAs + " and save to context as: " + upcSavedAs);
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
            TestReport.StartStep("Logging in to WercSmart");
			this.ILogInWithTheAccountSavedInTrevorAs(trevorSavedAs);
			TestReport.StartStep("Creating a new product: Chalk");
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

		[StepDefinition("I test the element is within window method")]
		public void TestScrollMethod()
		{
			var element= new Homepage().TopGridHeader("Product Information");
			Report.IsTrue(GeneralUtilities.ElementWithinBrowserWindow(element), "Element wasn't within the window", "Element was within the window");
			GeneralUtilities.ScrollToBottomOfPage();
			Report.IsTrue(!GeneralUtilities.ElementWithinBrowserWindow(element), "Element was within the window", "Element was not within the window");
		}

	}
}

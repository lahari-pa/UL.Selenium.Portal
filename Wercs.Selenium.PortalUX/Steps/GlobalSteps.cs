using System;
using System.Reflection;
using System.Threading;
using SafewareReporting;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using System.IO;
using System.Linq;
using ResourcePool;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Steps;

[assembly: Apartment(ApartmentState.STA)]

namespace WERCSmart
{

	[Binding]
	public class GlobalSteps
	{
		[StepDefinition(@"I login into the WERCSmart Portal - Administrator Role")]
		[StepDefinition(@"I login as the administrator")]
		[StepDefinition(@"I login as the administrator")]
		[When(@"I login as the administrator")]
		[Then(@"I login as the administrator")]
		public void GivenILoginAsTheAdministrator()
		{
			TestReport.BeginTestModule(ResourcePool.GlobalParameters.StepCount + " - Log into WERCSmart Portal as Administrator");
			try
			{
				var selLandingPage = new LandingPage();
				if (selLandingPage.Wait_for_load(10))
				{
					Report.Info("Clicking 'Log In' on the Landing Page");
					selLandingPage.Click_Login();
				}

				var selLogin = new Login();
				Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");
				Report.Info("Entering Email: '" + GlobalParameters.Admin1 + "'");
				selLogin.EmailField = GlobalParameters.Admin1;
				Report.Info("Entering Password: '" + GlobalParameters.AdminPassword1 + "'");
				selLogin.PasswordField = GlobalParameters.AdminPassword1;
				Report.Info("Clicking login");
				selLogin.Click_Login();

				//var Sel_TOU = new TermsOfUse();
				//if (Sel_TOU.Wait_for_load(10))
				// Sel_TOU.Accept();

				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - WERCs Visual Account")]
		public void GivenLoginIntoWERCSmartPortal_AdministratorRole()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal as Visual Account into the WERCs Account");
			try
			{
				Report.Info("Clicking 'Log In' on the Landing Page");
				var selLandingPage = new LandingPage();
				selLandingPage.Click_Login();

				var selLogin = new Login();
				Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");
				var username = @"automatedcompany1.kxxyxunf@mailosaur.io";
				var password = "Welcome1!";

				Report.Info("Entering Email: '" + username + "'");
				selLogin.EmailField = username;
				Report.Info("Entering Password: '" + password + "'");
				selLogin.PasswordField = password;
				Report.Info("Clicking login");
				selLogin.Click_Login();

				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account")]
		public void GivenLoginIntoWERCSmartPortal_AutomatedPremium()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal asPremium Subscription Account into the WERCs Account");
			try
			{
				Report.Info("Clicking 'Log In' on the Landing Page");
				var selLandingPage = new LandingPage();
				selLandingPage.Click_Login();

				var selLogin = new Login();
				Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");
				var username = @"AutomatedPremium.kxxyxunf@mailosaur.io";
				var password = "Welcome1!";

				Report.Info("Entering Email: '" + username + "'");
				selLogin.EmailField = username;
				Report.Info("Entering Password: '" + password + "'");
				selLogin.PasswordField = password;
				Report.Info("Clicking login");
				selLogin.Click_Login();

				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - WERCs Product Account")]
		public void GivenLoginIntoWERCSmartPortal_AdminRoleProducts()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal as Administrator into the WERCs Account");
			try
			{
				var selLandingPage = new LandingPage();
				if (selLandingPage.Wait_for_load(10))
				{
					Report.Info("Clicking 'Log In' on the Landing Page");
					selLandingPage.Click_Login();
				}

				var selLogin = new Login();
				Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");
				var username = @"AllRetailersProductsCompany.kxxyxunf@mailosaur.io";
				var password = "Welcome1!";

				Report.Info("Entering Email: '" + username + "'");
				selLogin.EmailField = username;
				Report.Info("Entering Password: '" + password + "'");
				selLogin.PasswordField = password;
				Report.Info("Clicking login");
				selLogin.Click_Login();

				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account")]
		public void GivenLoginIntoWERCSmartPortal_AdminUlscRole()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal as Administrator into the WERCs ULSC Account");
			try
			{
				var selLandingPage = new LandingPage();
				if (selLandingPage.Wait_for_load(10))
				{
					Report.Info("Clicking 'Log In' on the Landing Page");
					selLandingPage.Click_Login();
				}

				var selLogin = new Login();
				Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");
				var username = @"automatedULSC.kxxyxunf@mailosaur.io ";
				var password = "Welcome1!";

				Report.Info("Entering Email: '" + username + "'");
				selLogin.EmailField = username;
				Report.Info("Entering Password: '" + password + "'");
				selLogin.PasswordField = password;
				Report.Info("Clicking login");
				selLogin.Click_Login();

				var selHomepage = new Homepage();
				Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I logout")]
		public void GivenILogout()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				TopMenuBar thisTopMenuBar = new TopMenuBar();
				Assert.That(thisTopMenuBar.ClickSignOut());
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"If not already created, I create a user: (.*) with the following parameters:")]
		public void GivenIfNotAlreadyCreatedICreateAUserXWithTheFollowingParameters(string savedAs, Table parameters)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- If not already created, I create a user: '" + savedAs + "'");

			if (savedAs == "New_Sub")
			{
				savedAs = "New_Sub" + "_" + System.DateTime.Now.ToString("HHmmddMMyy");
			}

			try
			{
				if (!FeatureContext.Current.ContainsKey(savedAs))
				{
					Report.Info("Setting up account details for user: '" + savedAs + "'");
					var account = parameters.CreateInstance<WERCSmartUser>();
					account.Email = EmailFunctions.CreateEmail(account.Email);
					account.Identifier = savedAs;
					Context.AddToContext(savedAs, account, true);
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
					mySignUp.ThenIShouldBeOnTheSecurityQuestionsPageOfTheForm();
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
				Report.Success("Successfully navigated to the landing page!");
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
				{ Report.Error("No Main Window Handle found!"); }
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
				var emailAddress = Context.GetFromContext(savedas).ToString();
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
				Context.AddToContext(savedAs, email);
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

		[StepDefinition(@"there (should|should not) be a new email for email Address saved as: (.*) from: (.*) with the title: (.*)")]
		public void ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle(string shouldOrNot, string savedAs, string emailFrom, string title)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a new email for email Address: " + savedAs + " from " + emailFrom + " with title: " + title);
			try
			{
				if (emailFrom.ToLower() == "<sitenotification>")
				{
					if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("SiteType"))
					{
						var SiteType = System.Configuration.ConfigurationManager.AppSettings["SiteType"];
						switch (SiteType.ToLower())
						{
							case ("staging"):
								emailFrom = "ulscn.notifications@ulnotification.com";
								break;
							case ("production"):
								emailFrom = "wercsmart.notifications@ulnotification.com";
								break;
							case ("local prod"):
								emailFrom = "WERCSmartCustomer@ul.com";
								break;
							default: //Local
								emailFrom = "wercsmartcustomer@ul.com";
								break;
						}
					}
					else
					{
						emailFrom = "wercsmartcustomer@ul.com";
					}
				}

				var Email = string.Empty;
				if (savedAs == "ForgotPW_SecQs")
				{
					var user = (WERCSmartUser)Context.GetFromContext(savedAs);
					Email = user.Email;
				}
				else
				{
					Email = Context.GetFromContext(savedAs).ToString();
				}

				if (EmailFunctions.WaitForInboxDifferences(Email))
				{
					var differences = EmailFunctions.GetInboxDifferences(Email);
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
		[StepDefinition(@"the body of the email should show: (.*)")]
		public void ThenTheBodyOfTheEmailShouldShow(string bodyText)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking body text of email");
			try
			{
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
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
				var email = (Mailosaur.Email)Context.GetFromContext("Matching");
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
				var CurrentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", CurrentHandle);
				var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				foreach (var handle in allHandles)
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
					if (SeleniumBrowser.WebBrowser.Url != url)
					{
						Report.Success("Successfully Switch to Tab: " + url + "!");
						Report.Screenshot();
						return;
					}
				}

				Report.Failure("Failed to find tab with url: " + url);
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

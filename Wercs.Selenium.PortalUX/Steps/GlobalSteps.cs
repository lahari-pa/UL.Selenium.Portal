using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Threading;
using SafewareReporting;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using ResourcePool;
using SafewareReportingPlugin;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Steps;

[assembly: Apartment(ApartmentState.STA)]

namespace WERCSmart
{
	[Binding]
	public class GlobalSteps
	{
		[BeforeTestRun(Order = 1)]
		public static void SetTestURL()
		{
			if (ConfigurationManager.AppSettings.AllKeys.Contains("SiteType"))
			{
				switch (ConfigurationManager.AppSettings["SiteType"].ToLower())
				{
					case ("local"):
					case ("development"):
					{
						GlobalParameters.TestUrl = @"https://wps.thewercs.com/dbsplit/dev/Wercs.SHA.MVCWebV1/";
						GlobalParametersPortal.SHAUrl = @"http://wercsdeviis01.thewercs.local/Releases/6.1.v25/WPSV3/logon.aspx?ReturnUrl=%2fReleases%2f6.1.v25%2fWPSV3%2fprivate%2fdesktop.aspx";
							break;
					}
					case ("staging"):
					{
						GlobalParameters.TestUrl = @"https://staging.thewercs.com";
						GlobalParametersPortal.SHAUrl = @"";
						break;
					}
						
					default:
					{
						GlobalParameters.TestUrl = @"https://wps.thewercs.com/dbsplit/dev/Wercs.SHA.MVCWebV1/";
						GlobalParametersPortal.SHAUrl = @"http://wercsdeviis01.thewercs.local/Releases/6.1.v25/WPSV3/logon.aspx?ReturnUrl=%2fReleases%2f6.1.v25%2fWPSV3%2fprivate%2fdesktop.aspx";
						break;
					}
				}
			}
		}



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
				GivenILogInWithEmailXAndPasswordY(GlobalParameters.Admin1, GlobalParameters.AdminPassword1);
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
			var username = @"automatedcompany1.kxxyxunf@mailosaur.io";
			var password = "Welcome1!";
			GivenILogInWithEmailXAndPasswordY(username, password);
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account")]
		public void GivenLoginIntoWERCSmartPortal_AutomatedPremium()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal asPremium Subscription Account into the WERCs Account");
			try
			{
				var username = @"AutomatedPremium.kxxyxunf@mailosaur.io";
				var password = "Welcome1!";
				GivenILogInWithEmailXAndPasswordY(username, password);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"I Login into WERCSmart Portal - data consent Account")]
		public void GivenILoginIntoWERCSmartPortal_DataConsentAccount()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal using data consent Account");
			try
			{

				var username = @"dataconsent.kxxyxunf@mailosaur.io";
				var password = "Welcome1!";
				GivenILogInWithEmailXAndPasswordY(username, password);
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
				var username = @"AllRetailersProductsCompany.kxxyxunf@mailosaur.io"; /*@"AllRetailersProductsCompany.kxxyxunf@mailosaur.io";*/
																					 //var username = @"dataconsentalwaysdisplay.kxxyxunf@mailosaur.io";
				var password = "Welcome1!";
				GivenILogInWithEmailXAndPasswordY(username, password);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Login into WERCSmart Portal - Division Account")]
		public void GivenLoginIntoWERCSmartPortal_DivisionAccount()
		{
			var username = @"automateddivision.kxxyxunf@mailosaur.io";
			var password = "Welcome1!";
			GivenILogInWithEmailXAndPasswordY(username, password);
		}

		[Then(@"The home screen should load")]
		public void ThenTheHomeScreenShouldLoad()
		{
			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
			GeneralUtilities.Wait_for_load_finish();
		}




		[StepDefinition(@"I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account")]
		public void GivenLoginIntoWERCSmartPortal_AdminUlscRole()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal as Administrator into the WERCs ULSC Account");
			try
			{
				var username = @"automatedULSC.kxxyxunf@mailosaur.io ";
				var password = "Welcome1!";
				GivenILogInWithEmailXAndPasswordY(username, password);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I log in with email: (.*) and password: (.*)")]
		public void GivenILogInWithEmailXAndPasswordY(string username, string password)
		{
			var selLandingPage = new LandingPage();
			if (selLandingPage.Wait_for_load(10))
			{
				Report.Info("Clicking 'Log In' on the Landing Page");
				selLandingPage.Click_Login();
			}

			var selLogin = new Login();
			Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");

			Report.Info("Entering Email: '" + username + "'");
			selLogin.EmailField = username;
			Report.Info("Entering Password: '" + password + "'");
			selLogin.PasswordField = password;
			Report.Info("Clicking login");
			selLogin.Click_Login();

			var selHomepage = new Homepage();
			Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
			GeneralUtilities.Wait_for_load_finish();
			GivenIfAModalDialogOpensICloseIt();
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

		[StepDefinition(@"I create a new email address and save as: (.*)")]
		public void GivenICreateANewEmailAddressAndSaveAs(string saveAs)
		{
			string myDate = System.DateTime.Now.ToString("HHmmddMMyy");

			string myEmail = EmailFunctions.CreateEmail(myDate);
			Context.AddToContext(saveAs, myEmail);
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
					mySignUp.ThenIShouldBeOnThePageOfTheForm("Security questions");
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

		//[StepDefinition(@"in the received email I should see the title: (.*)")]
		//public void ThenInTheReceivedEmailIShouldSeeTheTitleWERCSmartPasswordReset(string expectedTitle)
		//{

		//}


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
						var siteType = System.Configuration.ConfigurationManager.AppSettings["SiteType"];
						switch (siteType.ToLower())
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

				var email = string.Empty;
				if (savedAs == "ForgotPW_SecQs")
				{
					var user = (WERCSmartUser)Context.GetFromContext(savedAs);
					email = user.Email;
				}
				else
				{
					email = Context.GetFromContext(savedAs).ToString();
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
				var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
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

		[StepDefinition(@"I switch to the Data Summary page")]
		public void SwitchToDataSumaryTab()
		{
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h2[text()='Summary']"), 2) != null)
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
			Context.AddToContext("MainWindowHandle", currentHandle);
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
			var mainHandle = Context.GetFromContext("MainWindowHandle").ToString();
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
			Context.AddToContext("MainWindowHandle", currentHandle);
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
	}
}

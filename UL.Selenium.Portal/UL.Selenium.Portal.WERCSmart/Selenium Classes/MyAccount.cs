using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using UL.Automation.Utilities;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RetailerAbbreviations;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{

	class MyAccount : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='mainBody']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'page-inner-header')]/h2"), 2).Text;
		}

		public string GetAdminEmail()
		{
			return this.containerElement.FindElement(By.XPath("//span[contains(@data-bind,'userEmail')]"), 2).Text;
		}

		public List<string> Subheadings()
		{
			return this.containerElement.FindElements(By.XPath(".//h2"), 2).Select(x => x.GetValue().Trim()).ToList();
		}

		public string GetCompanyName()
		{
			IWebElement companyNameH3 = this.containerElement.FindElement(By.XPath(".//div[@id='basic-user-info']/h3"), 2);
			return companyNameH3?.Text;
		}

		public bool SaveUserGrid(string saveAs)
		{
			try
			{
				int pageNo = 1;
				int pageCount = this.GetPage("last");
				var listOfUsers = new List<User>();
				while (pageNo <= pageCount)
				{
					Delay.Seconds(4 * Delay.SpeedFactor);

					IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
					ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

					foreach (IWebElement userRow in listOfUsersRows)
					{
						Delay.Seconds(2);
						Report.Info("Starting a new user");
						var thisUser = new User {
							Username = userRow.FindElement(By.XPath(".//td[1]"), 2).Text,
							Email = userRow.FindElement(By.XPath(".//td[2]"), 2).Text,
							Role = userRow.FindElement(By.XPath(".//td[3]"), 2).Text,
							IsActive = userRow.FindElement(By.XPath(".//td[4]"), 2).Text == "Yes"
						};
						Delay.Seconds(1);
						ReadOnlyCollection<IWebElement> checkboxes = userRow.FindElements(By.XPath(".//td[5]/div[@class='checkbox']"));
						foreach (IWebElement checkbox in checkboxes)
						{
							switch (checkbox.FindElement(By.XPath("./label"), 2).Text.Trim())
							{
								case "Chemical Assessment":
									thisUser.ChemicalAssessment = checkbox.FindElement(By.XPath(".//input"), 2).Selected;
									break;
								case "Product Submission":
									thisUser.ProductSubmission = checkbox.FindElement(By.XPath(".//input"), 2).Selected;
									break;
								default:
									throw new Exception(
										"There's a checkbox other than Chemical Assessment and Product Submissions. You need to update the function SaveUserGrid");
							}
						}
						listOfUsers.Add(thisUser);
					}

					IWebElement myNext = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

					if (myNext == null)
					{
						Report.Info("On Last Page");
						Report.Screenshot();
						break;
					}
					Report.Info("Trying to click the next page button");
					if (!myNext.TryClick())
					{
						throw new Exception("Failed to click move to next page");
					}
					pageNo++;
					Delay.Seconds(4);
					Report.Screenshot();

				}

				Context.AddToContext(saveAs, listOfUsers);
				return true;
			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return false;
			}


		}

		public List<User> UserGrid()
		{
			try
			{
				IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
				ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				var listOfUsers = new List<User>();

				foreach (IWebElement userRow in listOfUsersRows)
				{
					var thisUser = new User {
						Username = userRow.FindElement(By.XPath(".//td[1]"), 2).Text,
						Email = userRow.FindElement(By.XPath(".//td[2]"), 2).Text,
						Role = userRow.FindElement(By.XPath(".//td[3]"), 2).Text,
						IsActive = userRow.FindElement(By.XPath(".//td[4]"), 2).Text == "Yes"
					};
					ReadOnlyCollection<IWebElement> checkboxes = userRow.FindElements(By.XPath(".//td[5]/div[@class='checkbox']"));
					foreach (IWebElement checkbox in checkboxes)
					{
						switch (checkbox.FindElement(By.XPath("./label"), 2).Text.Trim())
						{
							case "Chemical Assessment":
								thisUser.ChemicalAssessment = checkbox.FindElement(By.XPath(".//input"), 2).Selected;
								break;
							case "Product Submission":
								thisUser.ProductSubmission = checkbox.FindElement(By.XPath(".//input"), 2).Selected;
								break;
							default:
								throw new Exception(
									"There's a checkbox other than Chemical Assessment and Product Submissions. You need to update the function SaveUserGrid");
						}
					}
					listOfUsers.Add(thisUser);
				}
				return listOfUsers;

			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return null;
			}
		}

		//Valid Actions: Details, Deactivate, Reset Password
		public bool ForUserClickAction(string username, string action)
		{
			IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
			ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));
			var listOfUsers = listOfUsersRows.Select(x => x.FindElement(By.XPath(".//td[1]/span"), 2).Text).ToList();
			if (!listOfUsers.Contains(username))
			{
				Report.Error("Username: " + username + " does not show in the list. The full list is: " +
											  string.Join(",", listOfUsers));
				return false;
			}
			IWebElement actionsButtonTd = userAccountsDiv.FindElement(By.XPath(".//tbody/tr/td[./span[contains(text(),'" + username + "')]]"), 2);
			if (actionsButtonTd == null)
			{
				IList<IWebElement> actionTds = userAccountsDiv.FindElements(By.XPath(".//tbody/tr/td[./span]"), 2);
				actionsButtonTd = actionTds.First(x => x.Text.Replace(" ", "") == username.Replace(" ", ""));
			}
			IWebElement actionsButton = actionsButtonTd?.FindElement(By.XPath("..//td//button"), 2);
			if (!actionsButton.TryClick())
			{
				Report.Error("Failed to click actions button!");
				return false;
			}
			Report.Info("Clicked actions button");
			//Actions drop down menu should now open
			IWebElement dropDownMenu = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@aria-expanded='true']/following-sibling::ul[@class='dropdown-menu']"), 2);
			var actionLink = (IWebElement)dropDownMenu?.FindElements(By.XPath("./li"), 2).FirstOrDefault(x => x.Text == action);
			if (!actionLink.TryClick())
			{
				Report.Error("Failed to click action: " + action);
				return false;
			}
			Report.Info("Clicked action: " + action);
			return true;
		}

		//Add New User link
		[FindsBy(How = How.XPath, Using = ".//div[@id='user-list-Container']/h2/a")]
		private IWebElement _linkNewUser;

		public bool Add_New_User_click()
		{
			Report.Info("Attempting to Click Add New User Link");
			this._linkNewUser.Click();
			return true;
		}

		public bool User_Added_Check(string userName, string emailAddress, string role)
		{
			Report.Info("Beginning User_Added_Check");

			int pageNo = 1;
			int pageCount = this.GetPage("last");
			while (pageNo <= pageCount)
			{
				Delay.Seconds(1.5 * Delay.SpeedFactor);

				IWebElement myPageNumber = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + userName);

				IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
				ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				foreach (IWebElement userRow in listOfUsersRows)
				{
					string myUsername = userRow.FindElement(By.XPath(".//td[1]"), 2).Text;

					if (myUsername == userName)
					{
						Report.Info("Row Found");
						string myEmail = userRow.FindElement(By.XPath(".//td[2]"), 2).Text;
						if (myEmail != emailAddress)
						{
							Report.Info("Incorrect Email Address for User: " + userName + ": " + emailAddress);
							Report.Screenshot();
							return false;
						}

						string myRole = userRow.FindElement(By.XPath(".//td[3]"), 2).Text;
						if (myRole != role)
						{
							Report.Info("Incorrect Role for User: " + userName + ": " + role);
							Report.Screenshot();
							return false;
						}

						Report.Success("User: " + userName + " Created");
						return true;
					}

					Report.Info("Row Not Found");
				}

				IWebElement myNext = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

				if (myNext == null)
				{
					Report.Info("On Last Page");
					Report.Screenshot();
					break;
				}
				Report.Info("User Not Found On Page " + myPageNumber.Text + ", Navigating to Next Page");
				myNext.ScrollElementIntoView();
				if (!myNext.TryClick())
				{
					Delay.Seconds(5);
					myNext = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();
					if (myNext == null)
					{
						Report.Info("On Last Page");
						Report.Screenshot();
						break;
					}
					myNext.ScrollElementIntoView();
					if (!myNext.TryClick())
					{
						throw new Exception("Failed to click move to next page");
					}
				}
				pageNo++;
				Delay.Seconds(1);
			}
			Report.Info("User: " + userName + " Has Not Been Created");
			Report.Screenshot();
			return false;
		}

		public bool Is_User_Active(string userName, string active)
		{
			Report.Info("Beginning Is_User_Active");

			IWebElement myFirstPageNo = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']//li//a[contains(text(), '1'])"), 10).FirstOrDefault();

			myFirstPageNo.TryClick();

			int pageNo = 1;

			while (pageNo < 10)
			{
				Delay.Seconds(1.5 * Delay.SpeedFactor);

				IWebElement myPageNumber = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + userName);

				IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
				ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				foreach (IWebElement userRow in listOfUsersRows)
				{
					string myUsername = userRow.FindElement(By.XPath(".//td[1]"), 2).Text;

					if (myUsername == userName)
					{
						Report.Info("Row Found");

						string myActive = userRow.FindElement(By.XPath(".//td[4]"), 2).Text;

						string myNewAct = string.Empty;

						if (active == "Active")
						{
							myNewAct = "Yes";
						}
						if (active == "Not Active")
						{
							myNewAct = "No";
						}

						if (myActive == myNewAct)
						{
							Report.Success("User is " + active);
							return true;
						}
						Report.Info("User is " + active);
						return false;
					}
					Report.Info("Row Not Found");
				}

				IWebElement myNext = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

				if (myNext == null)
				{
					Report.Info("On Last Page");
					Report.Screenshot();
					break;
				}
				Report.Info("User Not Found On Page " + myPageNumber.Text + ", Navigating to Next Page");
				myNext.Click();
				pageNo++;
			}
			Report.Info("User: " + userName + " Has Not Been Created");
			Report.Screenshot();
			return false;


		}

		public bool Is_User_In_Grid(string userName)
		{
			Report.Info("Beginning Is_User_Active");

			IWebElement myFirstPageNo = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']//li//a[contains(text(), '1'])"), 10).FirstOrDefault();

			myFirstPageNo.TryClick();

			int pageNo = 1;

			while (pageNo < 10)
			{
				Delay.Seconds(10* Delay.SpeedFactor);

				IWebElement myPageNumber = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + userName);

				IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
				ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));
				Report.Info($"the number of rows found was: {listOfUsersRows.Count()}");
				foreach (IWebElement userRow in listOfUsersRows)
				{
					Report.Info($"Looking for username...");
					IWebElement nameEl = userRow.FindElement(By.XPath(".//td[1]"), 2);
					if(nameEl.IsNullOrEmpty())
					{
						Report.Info($"nameEl was null or empty.");
						return false;
					}
					string myUsername = nameEl.Text;
					Report.Info($"Checking to see if name matches...");
					if (myUsername == userName)
					{
						Report.Info("The User I just created was found in the Grid");
						return true;
					}
					Report.Info("Row Not Found");
				}

				IWebElement myNext = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

				if (myNext == null)
				{
					Report.Info("On Last Page");
					Report.Screenshot();
					break;
				}
				Report.Info("User Not Found On Page " + myPageNumber.Text + ", Navigating to Next Page");
				myNext.Click();
				pageNo++;
			}
			Report.Info("User: " + userName + " was not found in the Grid");
			Report.Screenshot();
			return false;


		}

		public bool Select_ActivateDeactivate(string userName, string activate)
		{
			Report.Info("Beginning Select_ActivateDeactivate");
			IWebElement myFirstPageNo = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']//li//a[contains(text(), '1')]"), 10).FirstOrDefault();
			if (myFirstPageNo == null)
			{
				//Do Nothing, assume already on page 1
			}
			else
			{
				//if there are 10 or more pages the first element should be page 1 unless its already selected then the text will be 10 
				if (myFirstPageNo.Text == "1")
				{
					myFirstPageNo.TryClick();
				}
			}					

			int pageNo = 1;

			while (pageNo < 10)
			{
				Delay.Seconds(10 * Delay.SpeedFactor);

				IWebElement myPageNumber = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + userName);

				IWebElement userAccountsDiv = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
				ReadOnlyCollection<IWebElement> listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));
				Report.Info($"There was {listOfUsersRows.Count()} rows found");


				foreach (IWebElement userRow in listOfUsersRows)
				{
					Delay.Seconds(3);
					Report.Info($"Looking for username...");
					IWebElement nameEl = userRow.FindElement(By.XPath(".//td[1]"), 2);
					if (nameEl.IsNullOrEmpty())
					{
						Report.Info($"nameEl was null or empty.");
						return false;
					}
					string myUsername = nameEl.Text;
					Report.Info($"Checking to see if name matches...");


					if (myUsername == userName)
					{
						Report.Info("Row Found");

						IWebElement selEl = userRow.FindElement(By.XPath(".//button"), 2);
						if(selEl.IsNullOrEmpty())
						{
							Report.Info($"selEl was null or empty");
							return false;

						}	
						Report.Info($"Attempting to click the element");
						bool userSelected = selEl.TryClick();
						if (userSelected)
						{
							return userRow.FindElement(By.XPath(".//a[@id='activeDeactivateUser']"), 2).TryClick();
						}
						else
						{
							Report.Info("Could not select user");
							return false;
						}
					}
					Report.Info("Row Not Found");
				}

				IWebElement myNext = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

				if (myNext == null)
				{
					Report.Info("On Last Page");
					Report.Screenshot();
					break;
				}
				Report.Info("User Not Found On Page " + myPageNumber.Text + ", Navigating to Next Page");
				myNext.Click();
				pageNo++;
			}
			Report.Info("User: " + userName + " Has Not Been Created");
			Report.Screenshot();
			return false;
		}

		//New Subscription Button
		[FindsBy(How = How.XPath, Using = ".//div/a[text()='Enroll']")]
		//New Subscription Enroll
		private IWebElement _btnNewSub;

		public bool New_Subscription_click()
		{
			Report.Info("Attempting to Click New Subscription Button");
			var testel = this.containerElement.FindElement(By.XPath($".//div[contains(@data-bind,'subscriptionModel.isSubscription()==false')]/a[text()='Enroll']"), 2);
			return testel.TryClick();
		}

		public bool ConfirmSubscriptionLevel(string subscription)
		{
			IWebElement subLevel = this.containerElement.FindElement(By.XPath(@"//div[@class='col-sm-3 subscription']//h3"), 2);
			if (subLevel == null)
			{
				Report.Info("Failed to find subscription level element");
				return false;
			}

			return subLevel.Text.Trim() == subscription;

		}


		//Accounts Navigation
		[FindsBy(How = How.Id, Using = "myAccounts_navigation")]
		private IWebElement _nav_accounts;

		public bool Accounts_Navigation(string nav_option)
		{
			Report.Info("Navigating to the page - " + nav_option);
			IWebElement myNav = this._nav_accounts.FindElement(By.XPath(".//li/a[text()='" + nav_option + "']"), 2);
			bool navigated;
			if (myNav == null)
			{
				Report.Info("Failed to Find Navigation Option: " + nav_option);
				Report.Screenshot();
				return false;
			}
			Report.Info("Navigation Option Found - Attempting to Click Link");
			myNav.TryClick();
			GeneralUtilities.Wait_for_load_finish();
			switch (nav_option)
			{
				case "Company Information":
					var myComp = new MyAccount_CompanyInfo();
					navigated = myComp.Exists;
					break;
				case "Subscription Information":
					var mySub = new MyAccount_SubscriptionInfo();
					navigated = mySub.Exists;
					break;
				case "Payment Methods":
					var myPay = new PaymentMethods();
					navigated = myPay.Exists;
					break;
				case "Order History":
					var myOrder = new MyAccount_OrderHistory();
					navigated = myOrder.Exists;
					break;
				case "My Library":
					var myLibrary = new MyAccount_MyLibrary();
					navigated = myLibrary.Exists;
					break;
				default:
					Report.Info("The specified navigation option: " + nav_option + " was not valid");
					return false;
			}
			return navigated;
		}

		public string Get_State_Code(string state)
		{
			Report.Info("Beginning Get_State_Code: " + state);

			string myState = string.Empty;

			switch (state)
			{
				case "Alabama":
					myState = "AL";
					break;
				case "Alaska":
					myState = "AK";
					break;
				case "Arizona":
					myState = "AZ";
					break;
				case "Arkansas":
					myState = "AR";
					break;
				case "California":
					myState = "CA";
					break;
				case "Colorado":
					myState = "CO";
					break;
				case "Conneticut":
					myState = "CT";
					break;
				case "Deleware":
					myState = "DE";
					break;
				case "District of Columbia":
					myState = "DC";
					break;
				case "Florida":
					myState = "FL";
					break;
				case "Georgia":
					myState = "GA";
					break;
				case "Hawaii":
					myState = "HI";
					break;
				case "Idaho":
					myState = "ID";
					break;
				case "Illinois":
					myState = "IL";
					break;
				case "Indiana":
					myState = "IN";
					break;
				case "Iowa":
					myState = "IA";
					break;
				case "Kansas":
					myState = "KS";
					break;
				case "Kentucky":
					myState = "KY";
					break;
				case "Louisiana":
					myState = "LA";
					break;
				case "Maine":
					myState = "ME";
					break;
				case "Maryland":
					myState = "MD";
					break;
				case "Massachusetts":
					myState = "MA";
					break;
				case "Michigan":
					myState = "MI";
					break;
				case "Minnesota":
					myState = "MN";
					break;
				case "Mississippi":
					myState = "MS";
					break;
				case "Missouri":
					myState = "MO";
					break;
				case "Montana":
					myState = "MT";
					break;
				case "Nebraska":
					myState = "NE";
					break;
				case "Nevada":
					myState = "NV";
					break;
				case "New Hampshire":
					myState = "NH";
					break;
				case "New Jersey":
					myState = "NJ";
					break;
				case "New Mexico":
					myState = "NM";
					break;
				case "New York":
					myState = "NY";
					break;
				case "North Carolina":
					myState = "NC";
					break;
				case "North Dakota":
					myState = "ND";
					break;
				case "Ohio":
					myState = "OH";
					break;
				case "Oklahoma":
					myState = "OK";
					break;
				case "Oregon":
					myState = "OR";
					break;
				case "Pennsylvania":
					myState = "PA";
					break;
				case "Rhode Island":
					myState = "RI";
					break;
				case "South Carolina":
					myState = "SC";
					break;
				case "South Dakota":
					myState = "SD";
					break;
				case "Tennessee":
					myState = "TN";
					break;
				case "Texas":
					myState = "TX";
					break;
				case "Utah":
					myState = "UT";
					break;
				case "Vermont":
					myState = "VT";
					break;
				case "Virginia":
					myState = "VA";
					break;
				case "Washington":
					myState = "WA";
					break;
				case "West Virginia":
					myState = "WV";
					break;
				case "Wisconsin":
					myState = "WI";
					break;
				case "Wyoming":
					myState = "WY";
					break;
				default:
					Report.Error("Unable to Find Correct State");
					return "";
			}

			Report.Success("State Code Found: " + myState);
			return myState;
		}

		public bool Invoice_Email_Arrived(string invoice_no, string email_address)
		{
			Report.Info("Beginning Invoice_Email_Arrived: " + invoice_no);

			if (!MailosaurFunctions.CheckEmailHasArrived("Invoice " + invoice_no + " is attached", email_address))
			{
				Report.Info("Invoice Email has Not Arrived");
				return false;
			}

			Report.Success("Invoice Email is Correct");
			return true;
		}

		public bool IClickOnAccountFilter(string filter)
		{
			return this.containerElement.FindElement(By.XPath(".//ul[@role='tablist']//a[text()='" + filter + "']"), 2).TryClick();
		}

		public bool IClickOnAccountActiveFilter()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='accepted']"), 2).TryClick();
		}

		public bool IClickOnAccountInActiveFilter()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='not-submitted']"), 2).TryClick();
		}


		public bool DivisionGridShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@id='division-accounts-grid']//table"), 2) != null;
		}

		public string UserAccountsActivePage()
		{
			IWebElement userGrid = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
			if (userGrid == null)
			{
				return null;
			}
			IWebElement pageEl = userGrid.FindElement(By.XPath(".//li[@class='active']/span"), 2);
			if (pageEl == null)
			{
				return null;
			}
			pageEl.ScrollElementIntoView();
			return userGrid.FindElement(By.XPath(".//li[@class='active']/span"), 2).Text;
		}

		public bool UserGridNavigation(string navOption)
		{
			bool success = false;
			int i = 0;
			while (success == false && i < 5)
			{
				Report.Info("Navigating in the user grid with action - " + navOption);
				IWebElement userGrid = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
				if (userGrid == null)
				{
					Report.Info("Could not locate the user grid");
					return false;
				}
				IWebElement navEl = null;
				switch (navOption)
				{
					case "next":
						navEl = userGrid.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
						break;
					case "previous":
						navEl = userGrid.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
						break;
					case "...":
						navEl = userGrid.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
						break;
					default:
						Report.Info("An invalid navigation option was provided. Must either be 'next' or 'previous'");
						return false;
				}
				if (navEl == null)
				{
					Report.Info("Could not locate the navigation button element");
					return false;
				}
				navEl.ScrollElementIntoView();
				if (navEl.TryClick())
				{
					Report.Info("Successfully clicked the found element");
					success = true;
				}
				else
				{
					Report.Info($"Failed to click the element on try: {i+1}");
					i++;
				}
			}
			return success;
			

			
		}

		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				IWebElement activePageControl = this.containerElement.FindElement(By.XPath(".//div[@id='user-accounts']//ul[starts-with(@class,'pagination')]/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				IList<IWebElement> lastControl = this.containerElement.FindElements(By.XPath(".//div[@id='user-accounts']//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
				if (lastControl.Count == 0)
				{
					Report.Info("Last page is: 1");
					return 1;
				}
				int temp = int.Parse(lastControl.Last().Text);
				return int.Parse(lastControl.Last().Text);
			}
			return 1;
		}

		public int GetHighestPageNo()
		{
			IList<IWebElement> pageNumbers = this.containerElement.FindElements(By.XPath(".//div[@id='user-accounts']//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
			var intPageNos = pageNumbers.Select(x => Convert.ToInt16(x.GetValue())).ToList();
			return intPageNos.OrderByDescending(x => x).FirstOrDefault();


		}

		public IWebElement UserGridNavPageInput()
		{
			return this.containerElement.FindElement(By.XPath(".//input[@type='number']"), 2);
		}

		public bool UserGridNavPageInputShowing()
		{
			return this.UserGridNavPageInput() != null;
		}

		public void KeyToUserGridNavPageInput(string action)
		{
			IWebElement inputEl = this.UserGridNavPageInput();
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return;
			}
			inputEl.ScrollElementIntoView();
			switch (action)
			{
				case "up":
					inputEl.SendKeys(Keys.ArrowUp);
					break;
				case "down":
					inputEl.SendKeys(Keys.ArrowDown);
					break;
				case "enter":
					inputEl.SendKeys(Keys.Enter);
					break;
				default:
					Report.Failure("The action requested was beyond those specified: 'up', 'down', or 'enter'");
					break;
			}
		}

		public void NumToUserGridNavPageInput2(string pageNumber)
		{
			IWebElement inputEl = this.UserGridNavPageInput();
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return;
			}
			inputEl.EnterText(pageNumber);
		}


		public void NumToUserGridNavPageInput(string pageNumber)
		{
			int i = 0;
			while (i < 5)
			{
				try
				{
					IWebElement inputEl = this.UserGridNavPageInput();
					if (inputEl == null)
					{
						Report.Info("The Num input was not displayed. Clicking the '...' navigation element");
						this.UserGridNavigation("...");
						inputEl = this.UserGridNavPageInput();
						if (inputEl == null)
						{
							return; 
						}
						Report.Info("Entering page number: " + pageNumber);
						//inputEl.EnterText(pageNumber);
						//inputEl.Clear();
						string text = inputEl.GetAttribute("value");
						int textLength = text.Length;
						int count = 0;
						while (count < textLength)
						{
							inputEl.SendKeys(Keys.Delete);
							count++;
						}
						inputEl.SendKeys(pageNumber);
						return;
					}
					inputEl.EnterText(pageNumber);
					return;
				}
				catch (StaleElementReferenceException ex)
				{
					Report.Info("inputEl threw a stale element reference exeption");
					i++;
					Delay.Seconds(1);
					Report.Info($"Attempting to Find the inputEl again if the number of attempts has not exceeded 5");

				}
				catch (Exception ex)
				{
					Report.Info("Exception: " + ex.Message);
					return;
				}

			}
			return;


		}
	

		public string CurrentPageUserGridNavPageInput()
		{
			IWebElement inputEl = this.UserGridNavPageInput();
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return null;
			}
			return inputEl.GetAttribute("value");
		}

		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-3 subscription']")]
		private IWebElement _subscriptioncontainer;

		public string SubscriptionLevel()
		{
			return this._subscriptioncontainer.FindElement(By.XPath(".//h3[position()=1]"), 2).Text;
		}

		public bool ClickSubscriptionAction(string action)
		{
			switch (action.ToLower())
			{
				case "upgrade":
					return this._subscriptioncontainer.FindElement(By.XPath(".//a[text()='Upgrade']"), 2).TryClick();
				case "renew":
					return this._subscriptioncontainer.FindElement(By.XPath(".//a[text()='Renew']"), 2).TryClick();
				default:
					return false;
			}
		}
		public bool ClickHowToSubscribeLink()
		{
			return this._subscriptioncontainer.FindElement(By.XPath(".//a[./small[contains(text(),'How to Subscribe')]]"), 2).TryClick();
		}

		public bool ClickOnEditButtonInCompanyInformationPageInStewardshipNumbersSection()
		{
			IWebElement EditButton = this.containerElement.FindElement(By.XPath(".//a[@id='edit-stewardship']"), 2);
			return EditButton.TryClick();
		}

		public bool FillInStewardshipData(Table table)
		{

			IList<IWebElement> Textboxes = this.containerElement.FindElements(By.XPath(".//table[@class='table table-bordered']//input[@type='text']"), 2);
			List<string> StewardshipList = new List<string>();
			List<string> IssueDateList = new List<string>();
			List<string> ExpireDateList = new List<string>();

			bool issueDateFilled;
			bool expireDateFilled;

			foreach (TableRow row in table.Rows)
			{

				StewardshipList.Add(row["Stewardship"]);

			    issueDateFilled = false;
				expireDateFilled = false;

				if (row["Issue Date"] == "Today")
				{
					var input = DateTime.Now.ToString("yyyy-MM-dd");
					IssueDateList.Add(input);
					issueDateFilled = true;
				}
				else if (row["Issue Date"] == "Tomorrow")
				{
					var input = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
					IssueDateList.Add(input);
					issueDateFilled = true;
				}


				if (row["Expire Date"] == "Today")
				{
					var input = DateTime.Now.ToString("yyyy-MM-dd");
					ExpireDateList.Add(input);
					expireDateFilled = true;
				}
				else if (row["Expire Date"] == "Tomorrow")
				{
					var input = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
					ExpireDateList.Add(input);
					expireDateFilled = true;
				}


				if (!issueDateFilled)
				{
					IssueDateList.Add(row["Issue Date"]);
				}

				if (!expireDateFilled)
				{
					ExpireDateList.Add(row["Expire Date"]);
				}

			}

			int k = 0;
			int textboxesPerRow = 3;
			bool textEntered = true;
			for (int i = 0; i < StewardshipList.Count() * 3; i += textboxesPerRow)
			{

				if (Textboxes[i].TryEnterText(StewardshipList[k]) == false)
				{
					Report.Info($"Failed to enter Stewardship Info into row");
					textEntered = false;
				}
				if (Textboxes[i + 1].TryEnterText(IssueDateList[k]) == false)
				{
					Report.Info($"Failed to enter Issue Date into row");
					textEntered = false;

				}
				if (Textboxes[i + 2].TryEnterText(ExpireDateList[k]) == false)
				{
					Report.Info($"Failed to enter Expire Data into row");
					textEntered = false;

				}

				k++;

			}

			return textEntered;
		}

		public bool ClickSaveButtonForStewardshipNumbers()
		{
			//Data entry in automation causes the datepickers to stay open, Automation does not click save if date pickers are open, so first need to click off the date pickers to close them. Clicking the container in this case fixes the issue.
			this.containerElement.Click();			
			IWebElement SaveButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@data-bind='with: stewardshipNumberModel']//a[@class='btn btn-xs btn-success pull-right marLeft-5']"), 2);
			return SaveButton.TryClick();
		}

		public bool CheckStewardshipNumbersTableDataAfterItHasBeenSaved(Table table)
		{
			Delay.Seconds(5);
			IList<IWebElement> TableData = this.containerElement.FindElements(By.XPath(".//table[@class='table table-bordered']//input[@type='text']/preceding-sibling::p"), 2);
			List<string> StewardshipList = new List<string>();
			List<string> IssueDateList = new List<string>();
			List<string> ExpireDateList = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				StewardshipList.Add(row["Stewardship"]);
				IssueDateList.Add(row["Issue Date"]);
				if (row["Expire Date"] == "Tomorrow")
				{
					string input = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
					ExpireDateList.Add(input);
				}
				else
				{					
					ExpireDateList.Add(row["Expire Date"]);
				}
			}

			int k = 0;
			int textboxesPerRow = 3;
			for (int i = 0; i < TableData.Count() - 1; i += textboxesPerRow)
			{
				Report.Info($"Expected data was: {TableData[i].Text}, {TableData[i+1].Text}, {TableData[i+2].Text}");
				Report.Info($"Found data was: {StewardshipList[k]}, {IssueDateList[k]}, {ExpireDateList[k]}");
				if (!((TableData[i].Text == StewardshipList[k]) &&
					(TableData[i + 1].Text == IssueDateList[k]) &&
					(TableData[i + 2].Text == ExpireDateList[k])))
				{
					return false;
				}

				k++;
			}

			return true;
		}

		public bool SearchForHeadingInCompanyInformationPageWithName(string headingName)
		{
			IWebElement heading = this.FindElement(By.XPath(".//*[text()='Stewardship Numbers']"), 2);

			if (heading != null)
			{
				return true;
			}

			return false;
		}

		public bool CheckForTableInCompanyInformationPageInStewardshipNumbersSection()
		{
			IWebElement table = this.FindElement(By.XPath(".//*[text()='Stewardship Numbers']/following-sibling::div//table"), 2);

			if (table != null)
			{
				return true;
			}

			return false;
		}

		public int CheckNumberOfColumnsInTableInCompanyInformationPageInStewardshipNumbersSection()
		{
			IList<IWebElement> tableColumns = this.FindElements(By.XPath(".//*[text()='Stewardship Numbers']/following-sibling::div//table//th"), 2);

			return tableColumns.Count();
		}

		public bool CheckIfColumnNamesMatchInCompanyInformationPageInStewardshipNumbersSection(Table table)
		{
			IList<IWebElement> columnNames = this.FindElements(By.XPath(".//*[text()='Stewardship Numbers']/following-sibling::div//table//th"), 2);

			foreach (TableRow row in table.Rows)
			{
				bool foundMatch = false;

				foreach (IWebElement element in columnNames)
				{
					if (row["Column Name"] == element.Text)
					{
						foundMatch = true;
					}
				}

				if (!foundMatch)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckProvinceNamesInCompanyInformationPageInStewardshipNumbersSection(Table table)
		{
			IList<IWebElement> provinceNames = this.FindElements(By.XPath(".//*[text()='Stewardship Numbers']/following-sibling::div//table//tbody//td[1]"), 2);

			foreach (TableRow row in table.Rows)
			{
				bool foundMatch = false;

				foreach (IWebElement element in provinceNames)
				{
					if (row["Province Name"] == element.Text)
					{
						foundMatch = true;
					}
				}

				if (!foundMatch)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckForEditButtonCheckProvinceNamesInCompanyInformationPageInStewardshipNumbersSection()
		{
			IWebElement EditButton = this.FindElement(By.XPath(".//a[@id='edit-stewardship']"), 2);

			if (EditButton != null)
			{
				return true;
			}

			return false;
		}

		public bool ClickOnEditButtonInCompanyInformationPageInBillingAddressSection()
		{
			Delay.Seconds(5);
			IWebElement EditButton = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: billingAddressModel']//a[text()='Edit']"), 2);
			return EditButton.TryClick();
		}

		public bool ClickSaveInChangeUserPasswordWindow()
		{
			IWebElement SaveButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h3[text()='Change User Password']/../following-sibling::div/following-sibling::div//a[text()='Save']"), 2);
			return SaveButton.TryClick();
		}

		public bool ClickCloseInChangeUserPasswordWindow()
		{
			IWebElement CloseButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h3[text()='Change User Password']/../following-sibling::div/following-sibling::div//button[text()='Close']"), 2);
			return CloseButton.TryClick();
		}

		public bool PasswordTooRecentPopupPresent()
		{
			IWebElement tooRecentPopup = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@style='display: block;']//div[@class='modal-content' and .//div[@class='modal-body'] and .//p[text()='This password was used too recently.']]"), 2);
			return tooRecentPopup != null;
		}

		public bool ClickCloseInPasswordTooRecentPopup()
		{
			IWebElement tooRecentPopupClose = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@style='display: block;']//div[@class='modal-content' and .//div[@class='modal-body'] and .//p[text()='This password was used too recently.']]//button[text()='Close']"), 2);
			return tooRecentPopupClose.TryClick();
		}

		public bool SearchForUserSavedAs()
		{
			IWebElement searchBar = this.containerElement.FindElement(By.XPath("//input[@id='userSearch']"), 2);
			IWebElement searchButton = this.containerElement.FindElement(By.XPath("//input[@id='userSearch']/following-sibling::span"), 2);

			string email = Context.GetFromContext("CurrentEmail").ToString();

			searchBar.TryEnterText(email);
			searchButton.TryClick();
			Delay.Seconds(5);

			IList<IWebElement> userEmails = this.containerElement.FindElements(By.XPath("//div[@id='user-accounts-grid']//td[@data-bind='text: Email']"), 2);
			string[] userEmailArr = new string[userEmails.Count];

			for (int i = 0; i < userEmails.Count; i++)
			{
				userEmailArr[i] = userEmails[i].Text;
			}

			for (int i = 0; i < userEmailArr.Count(); i++)
			{
				if (userEmailArr[i] == email)
				{
					return true;
				}
			}

			return false;
		}

		public bool EnterSearchTextAndClickFind(string value)
		{
			IWebElement searchBar = this.containerElement.FindElement(By.XPath("//input[@id='userSearch']"), 2);
			IWebElement searchButton = this.containerElement.FindElement(By.XPath("//input[@id='userSearch']/following-sibling::span"), 2);

			bool textEntered = searchBar.TryEnterText(value);
			bool searchClicked = searchButton.TryClick();
			Delay.Seconds(5);
			return searchClicked && textEntered;
		}

	}

	class MyAccount_CompanyInfo : BaseObject
	{
		[FindsBy(How = How.Id, Using = "companyInfoContainer")]
		protected override IWebElement containerElement { get; set; }

		public string ReturnUserOrDivisionAccountsNumber(string accountType)
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(normalize-space(),'" + accountType + " Accounts')]/span"), 2).GetElementText();
		}

		public string ReturnCompanyName()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[contains(@data-bind, 'companyName.field')]"), 2).GetValue();
		}
		public string ReturnAdminName()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'userName.field')]"), 2).GetValue();
		}
		public string ReturnEmailAddress()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'userEmail.field')]"), 2).GetValue();
		}
		public string ReturnSupplierType()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'selectedSupplierType.field')]"), 2).GetValue();
		}
		public string ReturnCountry()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'countryName()')]"), 2).GetValue();
		}
		public string ReturnAddress()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'address1.field')]"), 2).GetValue();
		}
		public string ReturnCity()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'city.field')]"), 2).GetValue();
		}
		public string ReturnState()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'state.field')]"), 2).GetValue();
		}
		public string ReturnZip()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'zipCode.field')]"), 2).GetValue();
		}
		public string ReturnCountryCode()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'countryCode.field')]"), 2).GetValue();
		}
		public string ReturnCompanyPhone()
		{
			return this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'phone.field')]"), 2).GetValue();
		}

		public bool Company_Information_Correct(string companyName, string adminName, string emailAddress,
			string supplierType, string country, string address, string city, string state, string zipCode,
			string countryCode, string companyPhone)
		{
			Report.Info("Beginning Company_Information_Correct");

			if (!this.Exists)
			{
				Report.Info("Failed to Open Company Information Page");
				Report.Screenshot();
				return false;
			}

			//Company Name
			string myCompName = this.ReturnCompanyName();
			if (myCompName != companyName)
			{
				Report.Info("Incorrect Company Name");
				Report.Info("Expected: '" + companyName + "'");
				Report.Info("Returned: '" + myCompName + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Company Name: '" + myCompName + "'");

			//Admin Name
			string myAdminName = this.ReturnAdminName();
			if (myAdminName != adminName)
			{
				Report.Info("Incorrect Admin Name");
				Report.Info("Expected: '" + adminName + "'");
				Report.Info("Returned: '" + myAdminName + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Admin Name: '" + myAdminName + "'");

			//Email Address
			string myEmail = this.ReturnEmailAddress();
			if (myEmail != emailAddress)
			{
				Report.Info("Incorrect Email Address");
				Report.Info("Expected: '" + emailAddress + "'");
				Report.Info("Returned: '" + myEmail + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Email Address: '" + myEmail + "'");

			//Supplier Type
			string mySupplier = this.ReturnSupplierType();
			if (mySupplier != supplierType)
			{
				Report.Info("Incorrect Supplier Type");
				Report.Info("Expected: '" + supplierType + "'");
				Report.Info("Returned: '" + mySupplier + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Supplier Type: '" + mySupplier + "'");

			//Country
			string myCountry = this.ReturnCountry();
			if (myCountry != country)
			{
				Report.Info("Incorrect Country");
				Report.Info("Expected: '" + country + "'");
				Report.Info("Returned: '" + myCountry + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Country: '" + myCountry + "'");

			//Address
			string myAddress = this.ReturnAddress();
			if (myAddress != address)
			{
				Report.Info("Incorrect Address");
				Report.Info("Expected: '" + address + "'");
				Report.Info("Returned: '" + myAddress + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Address: '" + myAddress + "'");

			//City
			string myCity = this.ReturnCity();
			if (myCity != city)
			{
				Report.Info("Incorrect City");
				Report.Info("Expected: '" + city + "'");
				Report.Info("Returned: '" + myCity + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct City: '" + myCity + "'");

			//State
			string myState = this.ReturnState();
			if (myState != state)
			{
				Report.Info("Incorrect State");
				Report.Info("Expected: '" + state + "'");
				Report.Info("Returned: '" + myState + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct State: '" + myState + "'");

			//Zip Code
			string myZip = this.ReturnZip();
			if (myZip != zipCode)
			{
				Report.Info("Incorrect Zip Code");
				Report.Info("Expected: '" + zipCode + "'");
				Report.Info("Returned: '" + myZip + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Zip Code: '" + myZip + "'");

			//Country Code
			string myCC = this.ReturnCountryCode();
			if (myCC != countryCode)
			{
				Report.Info("Incorrect Country Code");
				Report.Info("Expected: '" + countryCode + "'");
				Report.Info("Returned: '" + myCC + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Country Code: '" + myCC + "'");

			//Company Phone
			string myPhone = this.ReturnCompanyPhone();
			if (myPhone != companyPhone)
			{
				Report.Info("Incorrect Company Phone");
				Report.Info("Expected: '" + companyPhone + "'");
				Report.Info("Returned: '" + myPhone + "'");
				Report.Screenshot();
				return false;
			}
			Report.Info("Correct Company Phone: '" + myPhone + "'");

			Report.Success("Company Information Correct");
			return true;
		}

		public bool EnterStewardshipInfo(string field, string option1)
		{
			try
			{
				IWebElement matchingRow = this.containerElement.FindElement(By.XPath(".//tr[contains(td,'" + field + "')]"), 2);

				IWebElement stweardshipInput = matchingRow.FindElement(By.XPath(".//input[contains(@data-bind,'StewardNumber.field')]"), 2);

				IWebElement issueDate = matchingRow.FindElement(By.XPath(".//input[contains(@data-bind,'IssueDate.field')]"), 2);

				IWebElement expireDate = matchingRow.FindElement(By.XPath(".//input[contains(@data-bind,'ExpireDate.field')]"), 2);

				if (stweardshipInput == null)
				{
					Report.Failure("Not able to find Stewardship input field");
					Report.Screenshot();
					return false;
				}
				stweardshipInput.EnterText(option1);

				if (issueDate == null)
				{
					Report.Failure("not able to find the issue date field");
					Report.Screenshot();
					return false;
				}
				TimeZone tz = TimeZone.CurrentTimeZone;
				DateTime ut = tz.ToUniversalTime(DateTime.Now);
				var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
				var esttime = TimeZoneInfo.ConvertTimeFromUtc(ut, est);
				var option2 = esttime.ToString("yyyy-MM-dd");
				issueDate.Clear();
				issueDate.EnterText(option2);
				issueDate.SendKeys(Keys.Enter);

				if (expireDate == null)
				{
					Report.Failure("not able to find the expire date field");
					Report.Screenshot();
					return false;
				}
				DateTime today = DateTime.Now;
				DateTime yearAhead = today.AddYears(1);
				var option3 = yearAhead.ToString("yyyy-MM-dd");
				expireDate.Clear();
				expireDate.EnterText(option3);
				expireDate.SendKeys(Keys.Enter);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool StewardshipEdit_click()
		{
			GeneralUtilities.Wait_for_load_finish();
			IWebElement StwdshipEdit = this.containerElement.FindElement(By.Id("edit-stewardship"), 2);
			Report.Info("Attempting to Click Edit Stewardship Button");

			if (StwdshipEdit == null)
			{
				Report.Failure("Not able to find Stewardship edit field");
				Report.Screenshot();
				return false;
			}
			return StwdshipEdit.TryClick();
		}

		public bool NoStewardshipCheckbox_click()
		{
			IWebElement StwdshipChkbox = this.containerElement.FindElement(By.XPath("//div[@class='checkbox']//input"), 2);
			Report.Info("Attempting to Click no Stewardship checkbox");

			if (StwdshipChkbox == null)
			{
				Report.Failure("Not able to find checkbox");
				Report.Screenshot();
				return false;
			}
			return StwdshipChkbox.TryClick();
		}

		//public bool StewardshipSave_click()
		//{
		//	IWebElement StwdshipSave = this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'stewardshipNumberModel')]//a[contains(text(),'Save')]"), 2);
		//	Report.Info("Attempting to Click Save on Stewardship information");

		//	if (StwdshipSave == null)
		//	{
		//		Report.Failure("Not able to find Stewardship Save button");
		//		Report.Screenshot();
		//		return false;
		//	}
		//	return StwdshipSave.TryClick();
		//}

		public bool StewardshipSaveOrCancel_Click(string option)
		{
			IWebElement StwdshipSave = this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'stewardshipNumberModel')]//a[contains(text(),'" + option + "')]"), 2);
			Report.Info("Attempting to Click option on Stewardship information");

			if (StwdshipSave == null)
			{
				Report.Failure("Not able to find option");
				Report.Screenshot();
				return false;
			}
			return StwdshipSave.TryClick();
		}

		public List<string> StewardshipFieldsNoData()
		{
			string xPath = @".//input[contains(@data-bind,'StewardNumber.field')] | " +
						@".//input[contains(@data-bind,'IssueDate.field')] | " +
						@".//input[contains(@data-bind,'ExpireDate.field')]";
			return this.containerElement.FindElements(By.XPath(xPath), 2).Select(x => x.GetValue().Trim()).ToList();
		}

		public bool Canada_Supplier_Edit_click()
		{
			IWebElement CanSuppEdit = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: canadaAddressModel']//a[contains(text(),'Add New')]"), 2);
			Report.Info("Attempting to Click Edit Canada Supplier Address Button");

			if (CanSuppEdit == null)
			{
				Report.Failure("Not able to find Canada Supplier Address add new field");
				Report.Screenshot();
				return false;
			}
			
			return CanSuppEdit.TryClick();
		}

		public bool Canada_Supplier_Save_click()
		{
			IWebElement CanSuppSave = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: canadaAddressModel']//a[contains(text(),'Save')]"), 2);
			Report.Info("Attempting to Click Save on Stewardship information");

			if (CanSuppSave == null)
			{
				Report.Failure("Not able to find Canada Supplier Address Save button");
				Report.Screenshot();
				return false;
			}
			return CanSuppSave.TryClick();
		}

		public bool Add_Canada_Supplier_Address(string address, string province, string city, string postalCode, string companyPhone, string country,
			string countryCode)
		{

			IWebElement SuppAddress = this.containerElement.FindElement(By.XPath(".//input[contains(@data-bind,'supplierAddress.field')]"), 2);

			IWebElement SuppProvince = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'supplierProvince.field')]"), 2);

			IWebElement SuppCity = this.containerElement.FindElement(By.XPath(".//input[contains(@data-bind,'supplierCity.field')]"), 2);

			IWebElement SuppPostalCode = this.containerElement.FindElement(By.XPath(".//input[contains(@data-bind,'supplierZipCode.field')]"), 2);

			IWebElement SuppCompanyPhone = this.containerElement.FindElement(By.XPath(".//input[contains(@data-bind,'supplierPhone.field')]"), 2);

			IWebElement SuppCountry = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind,'supplierCountry.field')]"), 2);

			IWebElement SuppCountryCode = this.containerElement.FindElement(By.XPath(".//input[contains(@data-bind,'supplierCountryCode.field')]"), 2);

			Report.Info("Entering User Information");

			if (SuppAddress == null)
			{
				Report.Failure("Not able to find address input field");
				Report.Screenshot();
				return false;
			}
			SuppAddress.EnterText(address);

			if (SuppProvince == null)
			{
				Report.Failure("Not able to find province input field");
				Report.Screenshot();
				return false;
			}
			SuppProvince.Select(province);

			if (SuppCity == null)
			{
				Report.Failure("Not able to find city input field");
				Report.Screenshot();
				return false;
			}
			SuppCity.EnterText(city);

			if (SuppPostalCode == null)
			{
				Report.Failure("Not able to find postal code input field");
				Report.Screenshot();
				return false;
			}
			SuppPostalCode.EnterText(postalCode);

			if (SuppCompanyPhone == null)
			{
				Report.Failure("Not able to find company phone input field");
				Report.Screenshot();
				return false;
			}
			SuppCompanyPhone.EnterText(companyPhone);

			if (SuppCountry == null)
			{
				Report.Failure("Not able to find country field");
				Report.Screenshot();
				return false;
			}
			SuppCountry.Select(country);

			if (SuppCountryCode == null)
			{
				Report.Failure("Not able to find country code input field");
				Report.Screenshot();
				return false;
			}
			SuppCountryCode.EnterText(countryCode);
			return true;
		}

		public bool SelectAStateAsAnOptionInCompanyInformationPageBillingAddressSection(string state)
		{
			IWebElement StateOption = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: billingAddressModel']//select[@class='form-control'][@tabindex='2']//option[text()='" + state + "']"), 2);
			return StateOption.TryClick();
		}

		public bool ClickSaveButtonInCompanyInformationPageBillingAddressSection()
		{
			IWebElement SaveButton = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: billingAddressModel']//a[@class='btn btn-xs btn-success pull-right marLeft-5']"), 2);
			return SaveButton.TryClick();
		}

		public bool ClickEditButtonAsAnOptionInCompanyInformationPageShippingAddressSection()
		{
			IWebElement EditButton = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: shippingAddressModel']//a[text()='Edit']"), 2);
			return EditButton.TryClick();
		}

		public bool SelectAStateAsAnOptionInCompanyInformationPageShippingAddressSection(string state)
		{
			IWebElement StateOption = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: shippingAddressModel']//select[@class='form-control'][@tabindex='2']//option[text()='" + state + "']"), 2);
			return StateOption.TryClick();
		}

		public bool ClickSaveButtonAsAnOptionInCompanyInformationPageShippingAddressSection()
		{
			IWebElement SaveButton = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: shippingAddressModel']//a[@class='btn btn-xs btn-success pull-right marLeft-5']"), 2);
			return SaveButton.TryClick();
		}

		public bool FindStateWithNameInBillingAddressSection(string state)
		{
			Delay.Seconds(5);
			var abbr = new StateAbbreviations();
			string selectedAbbr = "";
			abbr.Map.TryGetValue(state, out selectedAbbr);

			IWebElement stateText = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: billingAddressModel']//span[@data-bind='visible: !isInEditMode(), text: state.field']"), 2);

			if (stateText.Text == selectedAbbr)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool FindStateWithNameInShippingAddressSection(string state)
		{
			Delay.Seconds(5);
			var abbr = new StateAbbreviations();
			string selectedAbbr = "";
			abbr.Map.TryGetValue(state, out selectedAbbr);

			IWebElement stateText = this.containerElement.FindElement(By.XPath(".//div[@data-bind='with: shippingAddressModel']//span[@data-bind='visible: !isInEditMode(), text: state.field']"), 2);

			if (stateText.Text == selectedAbbr)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ConfirmErrorInStewardshipInfoTable(string error, string province)
		{
			Delay.Seconds(5);
			IWebElement ErrorMessage = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//td[text()='" + province + "']/following-sibling::td//span[text()='" + error + "']"), 2);

			if (error == "No Error")
			{
				if (ErrorMessage == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (ErrorMessage == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
	}

	class MyAccount_SubscriptionInfo : BaseObject
	{
		[FindsBy(How = How.Id, Using = "SubscriptionInfoContainer")]
		protected override IWebElement containerElement { get; set; }


		public bool Status_Information_Correct(string form_no, string art_no, string en_art_no)
		{
			Report.Info("Beginning Status_Information_Correct");

			IWebElement myText = this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-4']/p[@class='spaced-text']"), 2);

			Report.Info(myText.Text.Trim());

			var Expected = new List<string> {
				form_no == "0" ? "" : form_no + " Formulated",
				art_no == "0" ? "" : art_no + " Articles",
				en_art_no == "0" ? "" : en_art_no + " Enhanced Articles"
			};		

			string newString = "";
			for(int x=0; x<Expected.Count(); x++)
			{
				if (x== Expected.Count() - 1)
				{
					newString = newString + Expected[x];
				}
				else
				{
					newString = newString + Expected[x]+ ", ";
				}
			}

			string ExpectedText = newString;
			


			Report.Info("Expected string: " + ExpectedText);

			if (!myText.Text.Trim().Contains(ExpectedText))
			{
				Report.Info("Incorrect Status Information");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Status Information");
			return true;
		}

		//Subscription History Table
		[FindsBy(How = How.XPath, Using = ".//div[@class='panel panel-default ws-panel subscription-history']/div/table")]
		private IWebElement _tbl_sub_history;

		public bool Subscription_Level_Status(string status)
		{
			Report.Info("Beginning Subscription_Level_Status");

			IWebElement mySub = this._tbl_sub_history.FindElement(By.XPath(".//tbody/tr/td[contains(text(), '" + status + "')]"), 2);

			if (mySub == null)
			{
				Report.Info("Failed to Find Subscription Level Status");
				Report.Screenshot();
				return false;
			}
			//Report.Info("Subscription Level Status Found: " + mySub.Text.Trim());
			//if (!mySub.Text.Trim().Contains(status))
			//{
			//	Report.Info("Subscription Level Status is Incorrect");
			//	Report.Screenshot();
			//	return false;
			//}
			Report.Success("Subscription Level Status is Correct");
			return true;
		}

		public bool Subscription_Quantity(string qty, string status)
		{
			Report.Info("Beginning Subscription_Quantity");

			IWebElement mySub = this._tbl_sub_history.FindElement(By.XPath(".//tbody/tr/td[contains(text(), '" + status + "')]"), 2);

			IWebElement myQty = mySub.FindElement(By.XPath("../td[5]"), 2);

			if (myQty == null)
			{
				Report.Info("Failed to Find Quantity");
				Report.Screenshot();
				return false;
			}
			Report.Info("Quantity Found: " + myQty.Text);
			if (myQty.Text != qty)
			{
				Report.Info("Quantity is Incorrect");
				Report.Screenshot();
				return false;
			}
			Report.Success("Quantity is Correct");
			return true;
		}

		//UPGRADE Button
		[FindsBy(How = How.XPath, Using = ".//div/a[text()='Upgrade']")]
		private IWebElement _btnUpgrade;

		public bool ConfirmThatInTheMiddleOfThePageYouSeeTheUpgradeButton()
		{
			Report.Info("Beginning ConfirmThatInTheMiddleOfThePageYouSeeTheUpgradeButton");
			if(this._btnUpgrade == null)
			{
				Report.Info("Upgrade Button was not Found!");
				return false;
			}
			Report.Info("Upgrade Button Found!");
			return true;
		}

		public bool Upgrade_click()
		{
			Report.Info("Attempting to Click UPGRADE Button");
			this._btnUpgrade.Click();
			return true;
		}

		public bool Click_Upgrade_Button()
		{
			Report.Info("Beginning Click_Upgrade_Button");

			if (!this.Upgrade_click())
			{
				Report.Info("Failed to Click UPGRADE Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Info("UPGRADE Button Clicked");
			Report.Screenshot();

			var myUpgrade = new SubscriptionUpgrade();
			if (!myUpgrade.Exists)
			{
				Report.Info("Failed to Navigate to Subscription Upgrade Screen");
				Report.Screenshot();
				return false;
			}
			Report.Success("Successfully Navigated to Subscription Upgrade Screen");
			Report.Screenshot();
			return true;
		}

		public string Get_Status()
		{
			Report.Info("Beginning to get status");

			IWebElement myStatus = this.containerElement.FindElement(By.XPath(".//p[@class='spaced-text']//span[contains(@class,'text-bold text-uppercase')]"), 2);

			if (myStatus == null)
			{
				Report.Info("Failed to Find Status");
				Report.Screenshot();
				return "";
			}
			Report.Info("Status Found: " + myStatus.Text);
			Report.Screenshot();
			return myStatus.Text;
		}


		public string Get_GracePeriod()
		{
			Report.Info("Beginning to get grace period");

			IWebElement myGracePeriod = this.containerElement.FindElement(By.XPath(".//p[@class='spaced-text']//span[contains(@data-bind,'model.gracePeriod')]"), 2);

			if (myGracePeriod == null)
			{
				Report.Info("Failed to Find grace period");
				Report.Screenshot();
				return "";
			}
			Report.Info("grace period Found: " + myGracePeriod.Text);
			Report.Screenshot();
			return myGracePeriod.Text;
		}
	}
	class MyAccount_OrderHistory : BaseObject
	{
		[FindsBy(How = How.Id, Using = "orderHistoryContainer")]
		protected override IWebElement containerElement { get; set; }


		public bool Order_History_Select(string history_type)
		{
			Report.Info("Beginning Order_History_Select");

			IWebElement myType = null;

			switch (history_type)
			{
				case "WERCSmart":
					myType = this.containerElement.FindElement(By.XPath(".//div[@id='selectorGroup']/label/input[@value='WERCS']"), 2);
					break;
				case "Subscription":
					myType = this.containerElement.FindElement(By.XPath(".//div[@id='selectorGroup']/label/input[@value='SUBSCRIPTION']"), 2);
					break;
				default:
					throw new Exception("Failed to Find Correct Option Name");
			}

			if (myType == null)
			{
				Report.Info("Failed to Find " + history_type + " Radio Button");
				Report.Screenshot();
				return false;
			}
			Report.Info(history_type + " Found - Attempting to Select");
			myType.Click();
			Delay.Seconds(1 * Delay.SpeedFactor);
			return true;
		}

		public string Get_Invoice_Number(string submitted_by)
		{
			Report.Info("Beginning Get_Invoice_Number");

			IWebElement myCompany = this.containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='" + submitted_by + "']"), 2);

			if (myCompany == null)
			{
				Report.Info("Failed to Find Row");
				Report.Screenshot();
				return "";
			}
			Report.Info("Row Found");

			IWebElement myInvoice = myCompany.FindElement(By.XPath("../td[1]/span[1]"), 2);
			if (myInvoice == null)
			{
				Report.Info("Failed to Find Invoice Number");
				Report.Screenshot();
				return "";
			}
			Report.Info("Invoice Number Found: " + myInvoice.Text);
			Report.Screenshot();
			return myInvoice.Text;
		}

		public string Get_Invoice_Date(string submitted_by)
		{
			Report.Info("Beginning Get_Invoice_Date");

			IWebElement myCompany = this.containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='" + submitted_by + "']"), 2);

			if (myCompany == null)
			{
				Report.Info("Failed to Find Row");
				Report.Screenshot();
				return "";
			}
			Report.Info("Row Found");

			IWebElement myDate = myCompany.FindElement(By.XPath("../td[2]"), 2);
			if (myDate == null)
			{
				Report.Info("Failed to Find Invoice Date");
				Report.Screenshot();
				return "";
			}
			Report.Info("Invoice Date Found: " + myDate.Text);
			return myDate.Text;
		}

	}
	public class MyAccount_MyLibrary : BaseObject
	{
		[FindsBy(How = How.Id, Using = "myLibraryContainer")]
		protected override IWebElement containerElement { get; set; }

		public bool ClickTab(string heading)
		{
			return this.containerElement.FindElement(By.XPath(".//li[@role='presentation']/a[text() = '" + heading + "']"), 2).TryClick();
		}

		public string ActiveTab()
		{
			return this.containerElement.FindElement(By.XPath(".//a[parent::li[@role='presentation' and @class='active']]"), 2).Text;
		}

		public List<string> AllTabs()
		{
			return this.containerElement.FindElements(By.XPath(".//li[@role='presentation']/a"), 2).Select(x => x.Text).ToList();
		}
	}
	class MyPackagingTypes : MyAccount_MyLibrary
	{
		public bool Active { get; set; }
		public bool AddNew()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class = 'btn btn-default pull-right' and text() = 'Add New' and not(ancestor::div[@id='brandContainer'])]"), 2).TryClick();
		}
		public bool ClickDelete()
		{
			return this.containerElement.FindElement(By.XPath(".//ul[@class='dropdown-menu' and preceding-sibling::*[@aria-expanded='true']]//a[contains(text(),'Delete')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickEdit()
		{
			return this.containerElement.FindElement(By.XPath(".//ul[@class='dropdown-menu' and preceding-sibling::*[@aria-expanded='true']]//a[contains(text(),'Edit')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickActions(PackagingTypeItem packagingType)
		{
			return this.containerElement.FindElement(By.XPath(".//div[@role='group' and ./ancestor::tr[.//div[text()='" + packagingType.Name + "'] and .//small[text()='" + packagingType.ID + "']]]/button"), 2).TryClick();
		}
		//when appears=true, bool PackagingTypeAppearsInGrid. when appears=false, bool PackagingTypeDoesNotAppearInGrid
		public bool PackagingTypeInGrid(bool appears, PackagingTypeItem packagingType)
		{
			int pageNumber = this.GetPage("current");
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return false;
			}
			int lastPageNumber = this.GetPage("last");
			while (pageNumber <= lastPageNumber)
			{
				IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: products']/tr"), 2);
				foreach (IWebElement row in rows)
				{
					string thisID = row.FindElement(By.XPath("./td/div/small"), 2).Text;
					string thisName = row.FindElement(By.XPath("./td/div[@data-bind='text:Name']"), 2).Text;
					if (thisID == packagingType.ID && thisName == packagingType.Name)
					{
						return appears;
					}
				}
				if (this.NextDisabled())
				{
					return !appears;
				}
				this.Navigation("next");
				pageNumber = this.GetPage("current");
			}
			return !appears;
		}
		public bool NextDisabled()
		{
			IWebElement pagingControl = this.containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']"), 2);
			if (pagingControl == null)
			{
				Report.Failure("Unable to find the paging control on grid navigation");
				return false;
			}
			return pagingControl.FindElement(By.XPath(".//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}
		public bool Navigation(string navOption)
		{
			IWebElement pagingControl = this.containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']"), 2);
			if (pagingControl == null)
			{
				Report.Failure("Unable to find the paging control on grid navigation");
				return false;
			}
			switch (navOption.ToLower())
			{
				case "next":
					return pagingControl.FindElement(By.XPath(".//a[@class='page-link next']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
				case "previous":
					return pagingControl.FindElement(By.XPath(".//a[@class='page-link previous']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
			}
			Report.Failure("Unable to apply navigation option: " + navOption);
			return false;
		}
		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				IWebElement activePageControl = this.containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return Convert.ToInt32(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				IList<IWebElement> lastControl = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[@class='page-link']"), 2);
				if (lastControl.Count == 0)
				{
					Report.Info("Last page is: 1");
					return 1;
				}
				return Convert.ToInt32(lastControl.Last().Text);
			}
			return 1;
		}

		public PackagingTypeItem GetRandomPackagingTypeInGrid()
		{
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: products']/tr"), 2);

			if (rows.Count == 0)
			{
				return null;
			}
			var r = new Random();
			int rInt = r.Next(1, rows.Count + 1); //for ints
			string thisID = rows[rInt - 1].FindElement(By.XPath("./td/div/small"), 2).Text;
			string thisName = rows[rInt - 1].FindElement(By.XPath("./td/div[@data-bind='text:Name']"), 2).Text;

			var thisItem = new PackagingTypeItem {
				ID = thisID,
				Name = thisName
			};
			return thisItem;
		}
		public class PackagingTypeItem
		{
			public string ID { get; set; }
			public string Name { get; set; }
			public string Date { set; get; }
		}
	}
	public class MyBrands : MyAccount_MyLibrary
	{
		public bool Active { get; set; }
		public bool AddNew()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class = 'btn btn-default pull-right' and text() = 'Add New' and ancestor::div[@id='brandContainer']]"), 2).TryClick();
		}
		public void EnterBrandName(string value)
		{
			IWebElement inputEl = this.containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//input[@type='text']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find input element for Brand Name");
				return;
			}
			inputEl.EnterText(value);
		}
		public bool ActiveIsChecked()
		{
			IWebElement inputEl = this.containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//input[@type='checkbox' and @data-bind='checked:IsActive']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find 'Active?' checkbox input element in My Brands page");
				return false;
			}
			return inputEl.Checked();
		}
		public bool ClickActive()
		{
			IWebElement inputEl = this.containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//input[@type='checkbox' and @data-bind='checked:IsActive']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find 'Active?' checkbox input element in My Brands page");
				return false;
			}
			return inputEl.TryClick();
		}
		public bool ClickSave()
		{
			IWebElement row = this.containerElement.FindElement(By.XPath(".//tr[.//a[@data-bind='click: save']]"), 2);
			var allRows = this.containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr"), 2).ToList();
			if (row == null)
			{
				Report.Failure("Could not find a row in the My Brands grid with the 'save' button");
				return false;
			}
			IWebElement rowName = row.FindElement(By.XPath(".//input[@type='text']"), 2);
			int rowIndex = allRows.IndexOf(row);
			Context.AddToContext("Saved brand name", rowName?.GetAttribute("value"));
			Context.AddToContext("Saved brand row index", rowIndex);
			return row.FindElement(By.XPath(".//a[@data-bind='click: save']"), 2).TryClick();
		}
		public bool ClickCancel()
		{
			return this.containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//a[@data-bind='click: cancel']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickEdit(int row, string brandName)
		{
			return this.containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr[" + row + "][.//span[text()='" + brandName + "']]//a[contains(@data-bind,'click: edit')]"), 2).TryClick();
						
		}
		public List<string> SavedBrands()
		{
			return this.containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: productLines']//span[@data-bind='text:Phrase']"), 2).Select(x => x.Text).ToList();
		}
		public List<string> ActiveSavedBrands()
		{
			return this.containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr[.//span[@class='plus-container' and text()='Yes']]//span[@data-bind='text:Phrase']"), 2).Select(x => x.Text).ToList();
		}
		public string BrandName(int rowIndex)
		{
			Report.Info("Getting Brand name at row position: " + rowIndex);
			IWebElement row = this.containerElement.FindElement(By.XPath("//tbody[@data-bind='foreach: productLines']/tr[" + rowIndex + "]"), 2);
			if (row == null)
			{
				Report.Failure("There was no row showing at position: " + rowIndex);
				return null;
			}
			return row.FindElement(By.XPath(".//span[@data-bind = 'text:Phrase']"), 2).Text;
		}
		public string IsActiveText(int row, string brandName)
		{
			Report.Info("Getting 'Active?' text at row number: " + row);
			IWebElement textEl = this.containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr[" + row + "][.//span[text()='" + brandName + "']]//span[starts-with(@data-bind,'text: IsActive')]"), 2);
			if (textEl == null)
			{
				Report.Failure("Unable to locate 'Active?' text element for the My Brands row at index: " + row);
				return null;
			}
			return textEl.Text;
		}

		public class Brand
		{
			public string Name { get; set; }
			public string ID { get; set; }
		}
	}
	class MyIngredients : MyAccount_MyLibrary
	{
		public bool EnterTextSearch(string value)
		{
			//refocus in case previous search results are open
			this.containerElement.Click();
			IWebElement placeholderEl = this.containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
			if (!placeholderEl.TryClick())
			{
				Report.Info("Could not find the search field element");
				return false;
			}
			IWebElement inputEl = this.containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find the search field input");
				return false;
			}
			inputEl.EnterText(value);
			IWebElement searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			IList<IWebElement> results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
			while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 0.5) == null && i < 20)
			{
				results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 0.5);
				i++;
			}
			if (results.Count == 0)
			{
				Report.Info("There were no results showing for search term: " + value);
			}
			else
			{
				Report.Info("There were " + results.Count + " results for search term: " + value);
			}
			return true;
		}
		public bool ClickSearchResult(string name, string cas)
		{
			IList<IWebElement> resultsName = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]//span[@class='component-name']"), 2);
			if (resultsName.Count == 0 && GeneralUtilities.Wait_for_load_finish())
			{
				Report.Info("Unable to locate any search results with chemical name!");
				return false;
			}
			IWebElement nameMatch = resultsName.FirstOrDefault(x => x.GetValue().Trim().ToLower() == name.Trim().ToLower());
			if (nameMatch == null)
			{
				Report.Info("There was no match on name, so picking on CAS Number: " + cas);
				IList<IWebElement> resultsCAS = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]//span[@class='text-muted']"), 2);
				if (resultsCAS.Count == 0)
				{
					Report.Info("Unable to locate any search results with chemical name!");
					return false;
				}
				IWebElement casMatch = resultsCAS.FirstOrDefault(x => x.GetValue().Trim().ToLower() == cas.Trim().ToLower());
				if (casMatch == null)
				{
					IList<IWebElement> results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					string firstName = results.FirstOrDefault().FindElement(By.XPath(".//span[1]"), 2).GetValue();
					Report.Info("There was no match on name, so selected the first search result with name: " + firstName);
					return results.FirstOrDefault().TryClick();
				}
				return casMatch.FindElement(By.XPath("./ancestor::li[1]"), 2).TryClick();
			}
			Report.Info("Selecting the first search result which matched on chemical name: " + name);
			return nameMatch.FindElement(By.XPath("./ancestor::li[1]"), 2).TryClick();
		}
		public List<SearchResult> SearchResults()
		{
			var rList = new List<SearchResult>();
			var results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option') and not(@aria-disabled)]"), 2).ToList();
			foreach (IWebElement result in results)
			{
				rList.Add(new SearchResult {
					CAS = result.FindElement(By.XPath(".//span[@class='text-muted']"), 2).Text,
					Name = result.FindElement(By.XPath(".//span[@class='component-name']"), 2).Text
				});
			}
			return rList;
		}
		public bool ClickSave()
		{
			return this.containerElement.FindElements(By.XPath(".//a[text()='Save']"), 2).First(x => x.Displayed).TryClick();
		}
		public bool ClickDeleteChecked()
		{
			return this.containerElement.FindElement(By.XPath(".//button[starts-with(@data-bind, 'click: model.deleteChecked')]|.//button[contains(text(),'Delete checked')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool NextDisabled()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@id='settings']//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}
		public bool Navigation(string navOption)
		{

			switch (navOption.ToLower())
			{
				case "next":
					return this.containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link next']"), 2).TryClick();
				case "previous":
					return this.containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link prev']"), 2).TryClick();
			}
			Report.Failure("Unable to apply navigation option: " + navOption);
			return false;
		}
		public bool ClickPage(string page)
		{
			if (this.GetPage("current") == int.Parse(page))
			{
				return false;
			}
			Report.Info("Clicking page: " + page);
			return this.containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
		}
		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				IWebElement activePageControl = this.containerElement.FindElement(By.XPath(".//div[@id='settings']//ul[starts-with(@class,'pagination')]/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Info("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				IList<IWebElement> lastControl = this.containerElement.FindElements(By.XPath(".//div[@id='settings']//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
				if (lastControl.Count == 0)
				{
					Report.Info("Last page is: 1");
					return 1;
				}
				return int.Parse(lastControl.Last().Text);
			}
			return 1;
		}
		public int IngredientCount()
		{
			return this.containerElement.FindElements(By.XPath(".//tbody[not(starts-with(@data-bind,'foreach:'))]/tr"), 2).Count;
		}
		public List<string> PublicNameOptions(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElements(By.XPath(".//tbody/tr[" + ingredient.Row + "]//select[contains(@data-bind,'value: publicName')]/option"), 2).Select(x => x.Text).ToList();

		}
		public bool ClickPubliclyDisclosed(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[contains(@data-bind,'checked: isDisclosed')]"), 2).TryClick();
		}
		public bool ClickTradeSecret(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[contains(@data-bind,'checked: isTradeSecret')]"), 2).TryClick();
		}
		public string PublicName(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//select[contains(@data-bind,'value: publicName')]"), 2).SelectedOption();
		}
		public void EnterPublicName(IngredientItem ingredient, string name)
		{
			this.ClickPage(ingredient.Page.ToString());
			this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//select[contains(@data-bind,'value: publicName')]"), 2).Select(name);
		}
		public bool ClickRemove(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//button[@title='Remove']"), 2).TryClick();
		}
		public bool Selected(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[@data-bind='checked: isChecked']"), 2).Checked();
		}
		public bool ClickSelect(IngredientItem ingredient)
		{
			this.ClickPage(ingredient.Page.ToString());
			return this.containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[@data-bind='checked: isChecked']"), 2).TryClick();
		}

		public bool AddIngredientToMyIngredients(string ingredientName,string cas)
		{
			this.EnterTextSearch(ingredientName);
			return this.ClickSearchResult(ingredientName, cas);
		}

		public List<IngredientItem> IngredientsLibrary()
		{
			var selMyIngredients = new MyIngredients();
			var rList = new List<IngredientItem>();
			selMyIngredients.ClickPage("1");
			Delay.Seconds(1);
			int pageNumber = selMyIngredients.GetPage("current");
			Report.Info("Current page number : " + pageNumber);
			int ingredientNumber = 1;
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return rList;
			}
			int lastPageNumber = selMyIngredients.GetPage("last");
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				int rowCount = selMyIngredients.IngredientCount();
				for (int i = 1; i <= rowCount; i++)
				{
					rList.Add(selMyIngredients.GetIngredient(i, ingredientNumber));
					ingredientNumber++;
				}
				if (selMyIngredients.NextDisabled())
				{
					Report.Info("Found a total of: " + rList.Count + " ingredients");
					selMyIngredients.ClickPage("1");
					return rList;
				}
				selMyIngredients.Navigation("next");
				pageNumber = selMyIngredients.GetPage("current");
			}
			Report.Info("Found a total of: " + rList.Count + " ingredients");
			Report.Screenshot();
			selMyIngredients.ClickPage("1");
			return rList;
		}
		public IngredientItem GetIngredient(int row, int index)
		{
			var rIngredient = new IngredientItem {
				Row = row,
				Page = this.GetPage("current"),
				Index = index
			};
			IWebElement tableRow = this.containerElement.FindElement(By.XPath(".//div[@id='settings']//tbody/tr[" + row + "]"), 2);
			if (tableRow == null)
			{
				return new IngredientItem();
			}
			rIngredient.ChemicalName = tableRow.FindElement(By.XPath(".//span[@data-bind='text: component.name']"), 2).Text;
			rIngredient.CASNumber = tableRow.FindElement(By.XPath(".//span[@data-bind='text: component.cas']"), 2).Text;
			rIngredient.PublicallyDisclosed = tableRow.FindElement(By.XPath(".//input[contains(@data-bind, 'checked: isDisclosed')]"), 2).Checked();
			rIngredient.TradeSecret = tableRow.FindElement(By.XPath(".//input[contains(@data-bind, 'checked: isTradeSecret')]"), 2).Checked();
			rIngredient.PublicName = tableRow.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]"), 2).SelectedOption();
			return rIngredient;
		}
		public bool EditIngredient(IngredientItem ingredient)
		{
			Report.Info("Clicking Page: " + ingredient.Page);
			this.ClickPage(ingredient.Page.ToString());
			IWebElement ingredientRow = this.containerElement.FindElement(By.XPath(".//div[@id='settings']//tbody/tr[" + ingredient.Row + "]"), 2);
			var edited = new List<bool>();
			if (ingredientRow == null)
			{
				Report.Failure("Row: " + ingredient.Row + " was not visible");
				return false;
			}
			IWebElement publicallyDislosed = ingredientRow.FindElement(By.XPath(".//input[contains(@data-bind,'checked: isDisclosed')]"), 2);
			if (publicallyDislosed == null)
			{
				Report.Failure("Could not find Publicly Dislosed checkbox");
				return false;
			}
			Report.Info("Ingredient: " + ingredient.Index + ". Setting Publicly Disclosed checbox to: " + ingredient.PublicallyDisclosed);
			edited.Add(publicallyDislosed.Checked() == ingredient.PublicallyDisclosed || publicallyDislosed.TryClick());
			IWebElement tradeSecret = ingredientRow.FindElement(By.XPath(".//input[contains(@data-bind,'checked: isTradeSecret')]"), 2);
			if (tradeSecret == null)
			{
				Report.Failure("Could not find Trade Secret checkbox");
				return false;
			}
			Report.Info("Ingredient: " + ingredient.Index + ". Setting Trade Secret checbox to: " + ingredient.TradeSecret);
			edited.Add(tradeSecret.Checked() == ingredient.TradeSecret || tradeSecret.TryClick());
			IWebElement publicName = ingredientRow.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]"), 2);
			if (publicName == null)
			{
				Report.Failure("Could not find Public Name option");
				return false;
			}
			Report.Info("Ingredient: " + ingredient.Index + ". Setting Public Name to: " + ingredient.PublicName);
			publicName.Select(ingredient.PublicName);
			Delay.Seconds(1);
			edited.Add(publicName.SelectedOption() == ingredient.PublicName);
			return edited.All(e => e);
		}
		public int GetHighestPageNo()
		{
			IList<IWebElement> pageNumbers = this.containerElement.FindElements(By.XPath(".//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
			var intPageNos = pageNumbers.Select(x => Convert.ToInt16(x.GetValue())).ToList();
			return intPageNos.OrderByDescending(x => x).FirstOrDefault();

		}

		

		public class SearchResult
		{
			public string Name { get; set; }
			public string CAS { get; set; }
		}
		public class IngredientItem : MyIngredients
		{
			public string ChemicalName { get; set; }
			public string CASNumber { get; set; }
			public bool PublicallyDisclosed { get; set; }
			public bool TradeSecret { get; set; }
			public string PublicName { get; set; }
			public int Row { get; set; }
			public int Page { get; set; }
			// ID is for our reference to distinguish Ingredient items (sequence ordered from smallest to largest page#, row#)
			public int Index { get; set; }
		}
	}
	// My Distributors
}

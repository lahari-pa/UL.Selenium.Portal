using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Org.BouncyCastle.Asn1.Mozilla;
using SafewareReporting;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Classes;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{

	class MyAccount : BaseObject
	{
		public const string BasePath = "//div[@id='mainBody']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'page-inner-header')]/h2"), 2).Text;
		}

		public List<string> Subheadings()
		{
			return this.containerElement.FindElements(By.XPath(".//h2"), 2).Select(x => x.GetValue().Trim()).ToList();
		}

		public string GetCompanyName()
		{
			var companyNameH3 = this.containerElement.FindElement(By.XPath("//div[@class='col-sm-3 basic-info']/h3"), 2);
			if (companyNameH3 != null)
			{
				string innerText = companyNameH3.GetInnerHTML();
				string regExPattern = @"\<.*\>.*\<\/.*\>";
				Regex rgx = new Regex(regExPattern);
				return rgx.Replace(innerText, "").Trim();
			}
			else
			{
				return "";
			}
		}

		public bool SaveUserGrid(string saveAs)
		{
			try
			{
				var userAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));
				var listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				List<User> listOfUsers = new List<User>();

				foreach (var userRow in listOfUsersRows)
				{
					User thisUser = new User();
					thisUser.Username = userRow.FindElement(By.XPath(".//td[1]")).Text;
					thisUser.Email = userRow.FindElement(By.XPath(".//td[2]")).Text;
					thisUser.Role = userRow.FindElement(By.XPath(".//td[3]")).Text;
					thisUser.IsActive = userRow.FindElement(By.XPath(".//td[4]")).Text == "Yes";
					var checkboxes = userRow.FindElements(By.XPath(".//td[5]/div[@class='checkbox']"));
					foreach (var checkbox in checkboxes)
					{
						switch (checkbox.FindElement(By.XPath("./label")).Text.Trim())
						{
							case "Chemical Assessment":
								thisUser.ChemicalAssessment = checkbox.FindElement(By.XPath(".//input")).Selected;
								break;
							case "Product Submission":
								thisUser.ProductSubmission = checkbox.FindElement(By.XPath(".//input")).Selected;
								break;
							default:
								throw new Exception(
									"There's a checkbox other than Chemical Assessment and Product Submissions. You need to update the function SaveUserGrid");
						}
					}
					listOfUsers.Add(thisUser);
				}
				Context.AddToContext(saveAs, listOfUsers);
				return true;
			}
			catch (Exception e)
			{
				SafewareReporting.Report.Error(e.Message);
				return false;
			}


		}

		//Valid Actions: Details, Desctivate, Reset Password
		public bool ForUserClickAction(string username, string action)
		{
			var userAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));

			var listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

			List<string> listOfUsers = listOfUsersRows.Select(x => x.FindElement(By.XPath(".//td[1]")).Text).ToList();

			if (!listOfUsers.Contains(username))
			{
				SafewareReporting.Report.Error("Username: " + username + " does not show in the list. The full list is: " +
											  string.Join(",", listOfUsers));
				return false;
			}

			IWebElement actionsButtonTd =
				(IWebElement)userAccountsDiv.FindElement(By.XPath(".//tbody/tr/td[contains(text(),'" + username + "')]"));
			IWebElement actionsButton = (IWebElement)actionsButtonTd.FindElement(By.XPath("..//td//button"));

			//IWebElement UserRow = ((IWebElement)ListOfUsersRows.Select(x => x.FindElements(By.XPath(".//td[1]")).FirstOrDefault(y => y.Text==username)));

			//IWebElement ActionsButton = UserRow.FindElement(By.XPath(".//td[contains(@class, 'actions')]/button"));



			if (actionsButton != null)
			{
				actionsButton.ClickWithScroll();
				Delay.Seconds(2);
			}
			else
			{
				SafewareReporting.Report.Error("Actions elipsis is not found");
				return false;
			}

			//Actions drop down menu should now open

			var dropDownMenu =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//button[@aria-expanded='true']/following-sibling::ul[@class='dropdown-menu']"));

			IWebElement actionLink = (IWebElement)dropDownMenu.FindElements(By.XPath("./li")).FirstOrDefault(x => x.Text == action);

			if (actionLink != null)
			{
				actionLink.ClickWithScroll();
				Delay.Seconds(2);
			}
			else
			{
				SafewareReporting.Report.Error("Actions link is not found");
				return false;
			}

			return true;
		}

		//Add New User link
		[FindsBy(How = How.XPath, Using = ".//div[@id='user-list-Container']/h2/a")]
		private IWebElement _linkNewUser;

		public bool Add_New_User_click()
		{
			Report.Info("Attempting to Click Add New User Link");
			_linkNewUser.Click();
			return true;
		}

		public bool User_Added_Check(string userName, string emailAddress, string role)
		{
			Report.Info("Beginning User_Added_Check");

			int pageNo = 1;

			while (pageNo <= GetPage("last"))
			{
				Delay.Seconds(1.5 * Delay.SpeedFactor);

				IWebElement myPageNumber = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + userName);

				var userAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));
				var listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				foreach (var userRow in listOfUsersRows)
				{
					string myUsername = userRow.FindElement(By.XPath(".//td[1]")).Text;

					if (myUsername == userName)
					{
						Report.Info("Row Found");
						string myEmail = userRow.FindElement(By.XPath(".//td[2]")).Text;
						if (myEmail != emailAddress)
						{
							Report.Info("Incorrect Email Address for User: " + userName + ": " + emailAddress);
							Report.Screenshot();
							return false;
						}

						string myRole = userRow.FindElement(By.XPath(".//td[3]")).Text;
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

				IWebElement myNext = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

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

		public bool Is_User_Active(string userName, string active)
		{
			Report.Info("Beginning Is_User_Active");

			IWebElement myFirstPageNo = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='1']"), 10).FirstOrDefault();

			myFirstPageNo.Click();

			int pageNo = 1;

			while (pageNo < 10)
			{
				Delay.Seconds(1.5 * Delay.SpeedFactor);

				IWebElement myPageNumber = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + userName);

				var userAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));
				var listOfUsersRows = userAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				foreach (var userRow in listOfUsersRows)
				{
					string myUsername = userRow.FindElement(By.XPath(".//td[1]")).Text;

					if (myUsername == userName)
					{
						Report.Info("Row Found");

						string myActive = userRow.FindElement(By.XPath(".//td[4]")).Text;

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

				IWebElement myNext = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='Next']"), 10).FirstOrDefault();

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
		[FindsBy(How = How.XPath, Using = ".//div/a[text()='New Subscription']")]
		private IWebElement _btnNewSub;

		public bool New_Subscription_click()
		{
			Report.Info("Attempting to Click New Subscription Button");
			_btnNewSub.Click();
			return true;
		}

		//Accounts Navigation
		[FindsBy(How = How.Id, Using = "myAccounts_navigation")]
		private IWebElement _nav_accounts;

		public bool Accounts_Navigation(string nav_option)
		{
			Report.Info("Navigating to the page - " + nav_option);
			IWebElement myNav = _nav_accounts.FindElement(By.XPath(".//li/a[text()='" + nav_option + "']"), 2);
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

			if (!EmailFunctions.CheckEmailHasArrived("Invoice " + invoice_no + " is attached", email_address))
			{
				Report.Info("Invoice Email has Not Arrived");
				return false;
			}

			Report.Success("Invoice Email is Correct");
			return true;
		}

		public bool IClickOnAccountFilter(string filter)
		{
			return containerElement.FindElement(By.XPath(".//ul[@role='tablist']//a[text()='" + filter + "']"), 2).TryClick();
		}

		public bool DivisionGridShowing()
		{
			return containerElement.FindElement(By.XPath(".//div[@id='division-accounts-grid']//table"), 2) != null;
		}

		public string UserAccountsActivePage()
		{
			var userGrid = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
			if (userGrid == null)
			{
				return null;
			}
			var pageEl = userGrid.FindElement(By.XPath(".//li[@class='active']/span"), 2);
			if (pageEl == null)
			{
				return null;
			}
			pageEl.ScrollElementIntoView();
			return userGrid.FindElement(By.XPath(".//li[@class='active']/span"), 2).Text;
		}

		public bool UserGridNavigation(string navOption)
		{
			Report.Info("Navigating in the user grid with action - " + navOption);
			var userGrid = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"), 2);
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
			return navEl.TryClick();
		}

		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				var activePageControl = containerElement.FindElement(By.XPath(".//div[@id='user-accounts']//ul[starts-with(@class,'pagination')]/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				var lastControl = containerElement.FindElements(By.XPath(".//div[@id='user-accounts']//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
				if (lastControl.Count == 0)
				{
					Report.Info("Last page is: 1");
					return 1;
				}
				return int.Parse(lastControl.Last().Text);
			}
			return 1;
		}

		public IWebElement UserGridNavPageInput()
		{
			return containerElement.FindElement(By.XPath(".//input[@type='number']"), 2);
		}

		public bool UserGridNavPageInputShowing()
		{
			return this.UserGridNavPageInput() != null;
		}

		public void KeyToUserGridNavPageInput(string action)
		{
			var inputEl = UserGridNavPageInput();
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

		public void NumToUserGridNavPageInput(string pageNumber)
		{
			var inputEl = UserGridNavPageInput();
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return;
			}
			inputEl.EnterText(pageNumber);
		}

		public string CurrentPageUserGridNavPageInput()
		{
			var inputEl = UserGridNavPageInput();
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
	}
	class MyAccount_CompanyInfo : BaseObject
	{
		[FindsBy(How = How.Id, Using = "companyInfoContainer")]
		protected override IWebElement containerElement { get; set; }

		public string ReturnUserOrDivisionAccountsNumber(string accountType)
		{
			return containerElement.FindElement(By.XPath(".//a[contains(normalize-space(),'" + accountType + " Accounts')]/span"), 2).GetElementText();
		}

		public string ReturnCompanyName()
		{
			return containerElement.FindElement(By.XPath(".//h3[contains(@data-bind, 'companyName.field')]"), 2).GetValue();
		}
		public string ReturnAdminName()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'userName.field')]"), 2).GetValue();
		}
		public string ReturnEmailAddress()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'userEmail.field')]"), 2).GetValue();
		}
		public string ReturnSupplierType()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'selectedSupplierType.field')]"), 2).GetValue();
		}
		public string ReturnCountry()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'countryName()')]"), 2).GetValue();
		}
		public string ReturnAddress()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'address1.field')]"), 2).GetValue();
		}
		public string ReturnCity()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'city.field')]"), 2).GetValue();
		}
		public string ReturnState()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'state.field')]"), 2).GetValue();
		}
		public string ReturnZip()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'zipCode.field')]"), 2).GetValue();
		}
		public string ReturnCountryCode()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'countryCode.field')]"), 2).GetValue();
		}
		public string ReturnCompanyPhone()
		{
			return containerElement.FindElement(By.XPath(".//span[contains(@data-bind, 'phone.field')]"), 2).GetValue();
		}

		public bool Company_Information_Correct(string companyName, string adminName, string emailAddress,
			string supplierType, string country, string address, string city, string state, string zipCode,
			string countryCode, string companyPhone)
		{
			Report.Info("Beginning Company_Information_Correct");

			if (!Exists)
			{
				Report.Info("Failed to Open Company Information Page");
				Report.Screenshot();
				return false;
			}

			//Company Name
			string myCompName = ReturnCompanyName();
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
			string myAdminName = ReturnAdminName();
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
			string myEmail = ReturnEmailAddress();
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
			string mySupplier = ReturnSupplierType();
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
			string myCountry = ReturnCountry();
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
			string myAddress = ReturnAddress();
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
			string myCity = ReturnCity();
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
			string myState = ReturnState();
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
			string myZip = ReturnZip();
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
			string myCC = ReturnCountryCode();
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
			string myPhone = ReturnCompanyPhone();
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





	}
	class MyAccount_SubscriptionInfo : BaseObject
	{
		[FindsBy(How = How.Id, Using = "SubscriptionInfoContainer")]
		protected override IWebElement containerElement { get; set; }


		public bool Status_Information_Correct(string form_no, string art_no, string en_art_no)
		{
			Report.Info("Beginning Status_Information_Correct");

			IWebElement myText = containerElement.FindElement(By.XPath(".//div[@class='col-sm-4']/p[@class='spaced-text']"), 2);

			Report.Info(myText.Text.Trim());

			var Expected = new List<string>();
			Expected.Add(form_no == "0" ? "" : form_no + " Formulated");
			Expected.Add(art_no == "0" ? "" : art_no + " Articles");
			Expected.Add(en_art_no == "0" ? "" : en_art_no + " Enhanced Articles");
			var ExpectedText = string.Join(", ", Expected.Where(x => x != ""));

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

			IWebElement mySub = _tbl_sub_history.FindElement(By.XPath(".//tbody/tr/td[contains(text(), '" + status + "')]"), 2);

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

			IWebElement mySub = _tbl_sub_history.FindElement(By.XPath(".//tbody/tr/td[contains(text(), '" + status + "')]"), 2);

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

		public bool Upgrade_click()
		{
			Report.Info("Attempting to Click UPGRADE Button");
			_btnUpgrade.Click();
			return true;
		}

		public bool Click_Upgrade_Button()
		{
			Report.Info("Beginning Click_Upgrade_Button");

			if (!Upgrade_click())
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
					myType = containerElement.FindElement(By.XPath(".//div[@id='selectorGroup']/label/input[@value='WERCS']"), 2);
					break;
				case "Subscription":
					myType = containerElement.FindElement(By.XPath(".//div[@id='selectorGroup']/label/input[@value='SUBSCRIPTION']"), 2);
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

			IWebElement myCompany = containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='" + submitted_by + "']"), 2);

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

			IWebElement myCompany = containerElement.FindElement(By.XPath(".//tbody/tr/td[text()='" + submitted_by + "']"), 2);

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
	class MyAccount_MyLibrary : BaseObject
	{
		[FindsBy(How = How.Id, Using = "myLibraryContainer")]
		protected override IWebElement containerElement { get; set; }

		public bool ClickTab(string heading)
		{
			return containerElement.FindElement(By.XPath(".//li[@role='presentation']/a[text() = '" + heading + "']"), 2).TryClick();
		}

		public string ActiveTab()
		{
			return containerElement.FindElement(By.XPath(".//a[parent::li[@role='presentation' and @class='active']]"), 2).Text;
		}

		public List<string> AllTabs()
		{
			return containerElement.FindElements(By.XPath(".//li[@role='presentation']/a")).Select(x => x.Text).ToList();
		}
	}
	class MyPackagingTypes : MyAccount_MyLibrary
	{
		public bool Active { get; set; }
		public bool AddNew()
		{
			return containerElement.FindElement(By.XPath(".//a[@class = 'btn btn-default pull-right' and text() = 'Add New' and not(ancestor::div[@id='brandContainer'])]"), 2).TryClick();
		}
		public bool ClickDelete()
		{
			return containerElement.FindElement(By.XPath(".//ul[@class='dropdown-menu' and preceding-sibling::*[@aria-expanded='true']]//a[contains(text(),'Delete')]")).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickEdit()
		{
			return containerElement.FindElement(By.XPath(".//ul[@class='dropdown-menu' and preceding-sibling::*[@aria-expanded='true']]//a[contains(text(),'Edit')]")).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickActions(PackagingTypeItem packagingType)
		{
			return containerElement.FindElement(By.XPath(".//div[@role='group' and ./ancestor::tr[.//div[text()='" + packagingType.Name + "'] and .//small[text()='" + packagingType.ID + "']]]/button"), 2).TryClick();
		}
		//when appears=true, bool PackagingTypeAppearsInGrid. when appears=false, bool PackagingTypeDoesNotAppearInGrid
		public bool PackagingTypeInGrid(bool appears, PackagingTypeItem packagingType)
		{
			int pageNumber = GetPage("current");
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return false;
			}
			int lastPageNumber = GetPage("last");
			while (pageNumber <= lastPageNumber)
			{
				var rows = containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: products']/tr"), 2);
				foreach (var row in rows)
				{
					var thisID = row.FindElement(By.XPath("./td/div/small"), 2).Text;
					var thisName = row.FindElement(By.XPath("./td/div[@data-bind='text:Name']"), 2).Text;
					if (thisID == packagingType.ID && thisName == packagingType.Name)
					{
						return appears;
					}
				}
				if (NextDisabled())
				{
					return !appears;
				}
				Navigation("next");
				pageNumber = GetPage("current");
			}
			return !appears;
		}
		public bool NextDisabled()
		{
			var pagingControl = containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']"), 2);
			if (pagingControl == null)
			{
				Report.Failure("Unable to find the paging control on grid navigation");
				return false;
			}
			return pagingControl.FindElement(By.XPath(".//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}
		public bool Navigation(string navOption)
		{
			var pagingControl = containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']"), 2);
			if (pagingControl == null)
			{
				Report.Failure("Unable to find the paging control on grid navigation");
				return false;
			}
			switch (navOption.ToLower())
			{
				case "next":
					return pagingControl.FindElement(By.XPath(".//a[@class='page-link next']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
				case "previous":
					return pagingControl.FindElement(By.XPath(".//a[@class='page-link previous']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
			}
			Report.Failure("Unable to apply navigation option: " + navOption);
			return false;
		}
		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				var activePageControl = containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return Convert.ToInt32(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				var lastControl = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[@class='page-link']"), 2);
				if (lastControl.Count == 0)
				{
					Report.Info("Last page is: 1");
					return 1;
				}
				return Convert.ToInt32(lastControl.Last().Text);
			}
			return 1;
		}
		public class PackagingTypeItem
		{
			public string ID { get; set; }
			public string Name { get; set; }
			public string Date { set; get; }
		}
	}
	class MyBrands : MyAccount_MyLibrary
	{
		public bool Active { get; set; }
		public bool AddNew()
		{
			return containerElement.FindElement(By.XPath(".//a[@class = 'btn btn-default pull-right' and text() = 'Add New' and ancestor::div[@id='brandContainer']]"), 2).TryClick();
		}
		public void EnterBrandName(string value)
		{
			var inputEl = containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//input[@type='text']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find input element for Brand Name");
				return;
			}
			inputEl.EnterText(value);
		}
		public bool ActiveIsChecked()
		{
			var inputEl = containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//input[@type='checkbox' and @data-bind='checked:IsActive']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find 'Active?' checkbox input element in My Brands page");
				return false;
			}
			return inputEl.Checked();
		}
		public bool ClickActive()
		{
			var inputEl = containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//input[@type='checkbox' and @data-bind='checked:IsActive']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find 'Active?' checkbox input element in My Brands page");
				return false;
			}
			return inputEl.TryClick();
		}
		public bool ClickSave()
		{
			var row = containerElement.FindElement(By.XPath(".//tr[.//a[@data-bind='click: save']]"), 2);
			var allRows = containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr"), 2).ToList();
			if (row == null)
			{
				Report.Failure("Could not find a row in the My Brands grid with the 'save' button");
				return false;
			}
			var rowName = row.FindElement(By.XPath(".//input[@type='text']"), 2);
			var rowIndex = allRows.IndexOf(row);
			Context.AddToContext("Saved brand name", rowName?.GetAttribute("value"));
			Context.AddToContext("Saved brand row index", rowIndex);
			return row.FindElement(By.XPath(".//a[@data-bind='click: save']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickCancel()
		{
			return containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']//a[@data-bind='click: cancel']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickEdit(int row, string brandName)
		{
			return containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr[" + row + "][.//span[text()='" + brandName + "']]//a[contains(@data-bind,'click: edit')]"), 2).TryClick();

		}
		public List<string> SavedBrands()
		{
			return containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: productLines']//span[@data-bind='text:Phrase']"), 2).Select(x => x.Text).ToList();
		}
		public List<string> ActiveSavedBrands()
		{
			return containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr[.//span[@class='plus-container' and text()='Yes']]//span[@data-bind='text:Phrase']"), 2).Select(x => x.Text).ToList();
		}
		public string BrandName(int rowIndex)
		{
			Report.Info("Getting Brand name at row position: " + rowIndex);
			var row = containerElement.FindElement(By.XPath("//tbody[@data-bind='foreach: productLines']/tr[" + rowIndex + "]"), 2);
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
			var textEl = containerElement.FindElement(By.XPath(".//tbody[@data-bind='foreach: productLines']/tr[" + row + "][.//span[text()='" + brandName + "']]//span[starts-with(@data-bind,'text: IsActive')]"), 2);
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
			containerElement.Click();
			var placeholderEl = containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
			if (!placeholderEl.TryClick())
			{
				Report.Info("Could not find the search field element");
				return false;
			}
			var inputEl = containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			if (inputEl == null)
			{
				Report.Failure("Could not find the search field input");
				return false;
			}
			inputEl.EnterText(value);
			var searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			var results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
			while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 0.5) == null && i < 20)
			{
				results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 0.5);
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
			var resultsName = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]//span[@class='component-name']"), 2);
			if (resultsName.Count == 0 && GeneralUtilities.Wait_for_load_finish())
			{
				Report.Info("Unable to locate any search results with chemical name!");
				return false;
			}
			var nameMatch = resultsName.FirstOrDefault(x => x.GetValue().Trim().ToLower() == name.Trim().ToLower());
			if (nameMatch == null)
			{
				Report.Info("There was no match on name, so picking on CAS Number: " + cas);
				var resultsCAS = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]//span[@class='text-muted']"), 2);
				if (resultsCAS.Count == 0)
				{
					Report.Info("Unable to locate any search results with chemical name!");
					return false;
				}
				var casMatch = resultsCAS.FirstOrDefault(x => x.GetValue().Trim().ToLower() == cas.Trim().ToLower());
				if (casMatch == null)
				{
					var results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					var firstName = results.FirstOrDefault().FindElement(By.XPath(".//span[1]"), 2).GetValue();
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
			var results = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option') and not(@aria-disabled)]"), 2).ToList();
			foreach (var result in results)
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
			return containerElement.FindElement(By.XPath(".//a[@data-bind= 'click: saveIngredients']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool ClickDeleteChecked()
		{
			return containerElement.FindElement(By.XPath(".//button[starts-with(@data-bind, 'click: model.deleteChecked')]|.//button[contains(text(),'Delete checked')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}
		public bool NextDisabled()
		{
			return containerElement.FindElement(By.XPath(".//div[@id='settings']//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}
		public bool Navigation(string navOption)
		{

			switch (navOption.ToLower())
			{
				case "next":
					return containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link next']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
				case "previous":
					return containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link prev']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
			}
			Report.Failure("Unable to apply navigation option: " + navOption);
			return false;
		}
		public bool ClickPage(string page)
		{
			if (GetPage("current") == int.Parse(page))
			{
				return false;
			}
			Report.Info("Clicking page: " + page);
			return containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
		}
		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				var activePageControl = containerElement.FindElement(By.XPath(".//div[@id='settings']//ul[starts-with(@class,'pagination')]/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				var lastControl = containerElement.FindElements(By.XPath(".//div[@id='settings']//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
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
			return containerElement.FindElements(By.XPath(".//tbody[not(starts-with(@data-bind,'foreach:'))]/tr"), 2).Count;
		}
		public List<string> PublicNameOptions(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElements(By.XPath(".//tbody/tr[" + ingredient.Row + "]//select[contains(@data-bind,'value: publicName')]/option"), 2).Select(x => x.Text).ToList();

		}
		public bool ClickPubliclyDisclosed(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[contains(@data-bind,'checked: isDisclosed')]"), 2).TryClick();
		}
		public bool ClickTradeSecret(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[contains(@data-bind,'checked: isTradeSecret')]"), 2).TryClick();
		}
		public string PublicName(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//select[contains(@data-bind,'value: publicName')]"), 2).SelectedOption();
		}
		public void EnterPublicName(IngredientItem ingredient, string name)
		{
			ClickPage(ingredient.Page.ToString());
			containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//select[contains(@data-bind,'value: publicName')]"), 2).Select(name);
		}
		public bool ClickRemove(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//button[@title='Remove']"), 2).TryClick();
		}
		public bool Selected(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[@data-bind='checked: isChecked']"), 2).Checked();
		}
		public bool ClickSelect(IngredientItem ingredient)
		{
			ClickPage(ingredient.Page.ToString());
			return containerElement.FindElement(By.XPath(".//tbody/tr[" + ingredient.Row + "]//input[@data-bind='checked: isChecked']"), 2).TryClick();
		}
		public List<IngredientItem> IngredientsLibrary()
		{
			var selMyIngredients = new MyIngredients();
			var rList = new List<IngredientItem>();
			selMyIngredients.ClickPage("1");
			int pageNumber = selMyIngredients.GetPage("current");
			var ingredientNumber = 1;
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return rList;
			}
			int lastPageNumber = selMyIngredients.GetPage("last");
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				var rowCount = selMyIngredients.IngredientCount();
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
			IngredientItem rIngredient = new IngredientItem();
			rIngredient.Row = row;
			rIngredient.Page = GetPage("current");
			rIngredient.Index = index;
			var tableRow = containerElement.FindElement(By.XPath(".//div[@id='settings']//tbody/tr[" + row + "]"), 2);
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
			ClickPage(ingredient.Page.ToString());
			var ingredientRow = containerElement.FindElement(By.XPath(".//div[@id='settings']//tbody/tr[" + ingredient.Row + "]"), 2);
			var edited = new List<bool>();
			if (ingredientRow == null)
			{
				Report.Failure("Row: " + ingredient.Row + " was not visible");
				return false;
			}
			var publicallyDislosed = ingredientRow.FindElement(By.XPath(".//input[contains(@data-bind,'checked: isDisclosed')]"), 2);
			if (publicallyDislosed == null)
			{
				Report.Failure("Could not find Publicly Dislosed checkbox");
				return false;
			}
			Report.Info("Ingredient: " + ingredient.Index + ". Setting Publicly Disclosed checbox to: " + ingredient.PublicallyDisclosed);
			edited.Add(publicallyDislosed.Checked() == ingredient.PublicallyDisclosed || publicallyDislosed.TryClick());
			var tradeSecret = ingredientRow.FindElement(By.XPath(".//input[contains(@data-bind,'checked: isTradeSecret')]"), 2);
			if (tradeSecret == null)
			{
				Report.Failure("Could not find Trade Secret checkbox");
				return false;
			}
			Report.Info("Ingredient: " + ingredient.Index + ". Setting Trade Secret checbox to: " + ingredient.TradeSecret);
			edited.Add(tradeSecret.Checked() == ingredient.TradeSecret || tradeSecret.TryClick());
			var publicName = ingredientRow.FindElement(By.XPath(".//select[contains(@data-bind,'value: publicName')]"), 2);
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

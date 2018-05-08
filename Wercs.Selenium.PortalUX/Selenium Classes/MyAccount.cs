using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Classes;
using Global = SeleniumUtilities.Global;


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
				Global.Browser.FindElement(
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
			Report.Info("Beginning Accounts_Navigation - Navigating to " + nav_option);

			IWebElement myNav = _nav_accounts.FindElement(By.XPath(".//li/a[text()='" + nav_option + "']"), 2);

			if (myNav == null)
			{
				Report.Info("Failed to Find Navigation Option");
				Report.Screenshot();
				return false;
			}
			Report.Info("Navigation Option Found - Attempting to Click Link");
			myNav.Click();
			Delay.Seconds(10 * Delay.SpeedFactor);

			switch (nav_option)
			{
				case "Company Information":
					var myComp = new MyAccount_CompanyInfo();
					if (!myComp.Exists)
					{
						Report.Info("Failed to Navigate to " + nav_option);
					}
					Report.Success(nav_option + " Opened Successfully");
					break;
				case "Subscription Information":
					var mySub = new MyAccount_SubscriptionInfo();
					if (!mySub.Exists)
					{
						Report.Info("Failed to Navigate to " + nav_option);
					}
					Report.Success(nav_option + " Opened Successfully");
					break;
				case "Payment Methods":
					var myPay = new PaymentMethods();
					if (!myPay.Exists)
					{
						Report.Info("Failed to Navigate to " + nav_option);
					}
					Report.Success(nav_option + " Opened Successfully");
					break;
				case "Order History":
					var myOrder = new MyAccount_OrderHistory();
					if (!myOrder.Exists)
					{
						Report.Info("Failed to Navigate to " + nav_option);
					}
					Report.Success(nav_option + " Opened Successfully");
					break;
				case "My Library":
					var myLibrary = new MyAccount_MyLibrary();
					if (!myLibrary.Exists)
					{
						Report.Info("Failed to Navigate to " + nav_option);
					}
					Report.Success(nav_option + " Opened Successfully");
					break;
				default:
					throw new Exception("Failed to Find Correct Option Name");
			}

			Report.Success("Account Navigation Successful");
			return true;
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

	}

	class MyAccount_CompanyInfo : BaseObject
	{
		[FindsBy(How = How.Id, Using = "companyInfoContainer")]
		protected override IWebElement containerElement { get; set; }

		public string ReturnUserOrDivisionAccountsNumber(string accountType)
		{
			return containerElement.FindElement(By.XPath(".//a[contains(normalize-space(),'" + accountType + " Accounts')]/span"), 2).GetElementText();
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

			if (!myText.Text.Trim()
				.Contains(form_no + " Formulated, " + art_no + " Articles, " + en_art_no + " Enhanced Articles"))
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








	}


}

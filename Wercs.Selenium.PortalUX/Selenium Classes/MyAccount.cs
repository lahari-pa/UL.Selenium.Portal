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


	}
}

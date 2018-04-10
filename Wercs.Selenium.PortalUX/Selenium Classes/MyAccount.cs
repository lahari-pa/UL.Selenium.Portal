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
				var UserAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));
				var ListOfUsersRows = UserAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				List<User> ListOfUsers = new List<User>();

				foreach (var UserRow in ListOfUsersRows)
				{
					User ThisUser = new User();
					ThisUser.Username = UserRow.FindElement(By.XPath(".//td[1]")).Text;
					ThisUser.Email = UserRow.FindElement(By.XPath(".//td[2]")).Text;
					ThisUser.Role = UserRow.FindElement(By.XPath(".//td[3]")).Text;
					ThisUser.IsActive = UserRow.FindElement(By.XPath(".//td[4]")).Text == "Yes";
					var Checkboxes = UserRow.FindElements(By.XPath(".//td[5]/div[@class='checkbox']"));
					foreach (var Checkbox in Checkboxes)
					{
						switch (Checkbox.FindElement(By.XPath("./label")).Text.Trim())
						{
							case "Chemical Assessment":
								ThisUser.ChemicalAssessment = Checkbox.FindElement(By.XPath(".//input")).Selected;
								break;
							case "Product Submission":
								ThisUser.ProductSubmission = Checkbox.FindElement(By.XPath(".//input")).Selected;
								break;
							default:
								throw new Exception(
									"There's a checkbox other than Chemical Assessment and Product Submissions. You need to update the function SaveUserGrid");
						}
					}
					ListOfUsers.Add(ThisUser);
				}
				Context.AddToContext(saveAs, ListOfUsers);
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
			var UserAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));

			var ListOfUsersRows = UserAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

			List<string> ListOfUsers = ListOfUsersRows.Select(x => x.FindElement(By.XPath(".//td[1]")).Text).ToList();

			if (!ListOfUsers.Contains(username))
			{
				SafewareReporting.Report.Error("Username: " + username + " does not show in the list. The full list is: " +
											  string.Join(",", ListOfUsers));
				return false;
			}

			IWebElement ActionsButtonTd =
				(IWebElement)UserAccountsDiv.FindElement(By.XPath(".//tbody/tr/td[contains(text(),'" + username + "')]"));
			IWebElement ActionsButton = (IWebElement)ActionsButtonTd.FindElement(By.XPath("..//td//button"));

			//IWebElement UserRow = ((IWebElement)ListOfUsersRows.Select(x => x.FindElements(By.XPath(".//td[1]")).FirstOrDefault(y => y.Text==username)));

			//IWebElement ActionsButton = UserRow.FindElement(By.XPath(".//td[contains(@class, 'actions')]/button"));



			if (ActionsButton != null)
			{
				ActionsButton.ClickWithScroll();
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

			IWebElement ActionLink = (IWebElement)dropDownMenu.FindElements(By.XPath("./li")).FirstOrDefault(x => x.Text == action);

			if (ActionLink != null)
			{
				ActionLink.ClickWithScroll();
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
		private IWebElement _link_new_user;

		public bool Add_New_User_click()
		{
			Report.Info("Attempting to Click Add New User Link");
			_link_new_user.Click();
			return true;
		}

		public bool User_Added_Check(string user_name, string email_address, string role)
		{
			Report.Info("Beginning User_Added_Check");

			int Page_No = 1;

			while (Page_No < 10)
			{
				Delay.Seconds(1.5 * Delay.SpeedFactor);

				IWebElement myPageNumber = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + user_name);

				var UserAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));
				var ListOfUsersRows = UserAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				foreach (var UserRow in ListOfUsersRows)
				{
					string myUsername = UserRow.FindElement(By.XPath(".//td[1]")).Text;

					if (myUsername == user_name)
					{
						Report.Info("Row Found");
						string myEmail = UserRow.FindElement(By.XPath(".//td[2]")).Text;
						if (myEmail != email_address)
						{
							Report.Info("Incorrect Email Address for User: " + user_name + ": " + email_address);
							Report.Screenshot();
							return false;
						}

						string myRole = UserRow.FindElement(By.XPath(".//td[3]")).Text;
						if (myRole != role)
						{
							Report.Info("Incorrect Role for User: " + user_name + ": " + role);
							Report.Screenshot();
							return false;
						}

						Report.Success("User: " + user_name + " Created");
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
				Page_No++;
			}
			Report.Info("User: " + user_name + " Has Not Been Created");
			Report.Screenshot();
			return false;
		}

		public bool Is_User_Active(string user_name, string active)
		{
			Report.Info("Beginning Is_User_Active");

			IWebElement myFirstPageNo = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[text()='1']"), 10).FirstOrDefault();

			myFirstPageNo.Click();

			int Page_No = 1;

			while (Page_No < 10)
			{
				Delay.Seconds(1.5 * Delay.SpeedFactor);

				IWebElement myPageNumber = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/span[@class='current']"), 10).FirstOrDefault();

				Report.Info("Searching on Page " + myPageNumber.Text + " For User: " + user_name);

				var UserAccountsDiv = containerElement.FindElement(By.XPath(".//div[@id='user-accounts-grid']"));
				var ListOfUsersRows = UserAccountsDiv.FindElements(By.XPath(".//tbody/tr"));

				foreach (var UserRow in ListOfUsersRows)
				{
					string myUsername = UserRow.FindElement(By.XPath(".//td[1]")).Text;

					if (myUsername == user_name)
					{
						Report.Info("Row Found");

						string myActive = UserRow.FindElement(By.XPath(".//td[4]")).Text;

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
				Page_No++;
			}
			Report.Info("User: " + user_name + " Has Not Been Created");
			Report.Screenshot();
			return false;


		}

		//New Subscription Button
		[FindsBy(How = How.XPath, Using = ".//div/a[text()='New Subscription']")]
		private IWebElement _btn_new_sub;

		public bool New_Subscription_click()
		{
			Report.Info("Attempting to Click New Subscription Button");
			_btn_new_sub.Click();
			return true;
		}


	}
}

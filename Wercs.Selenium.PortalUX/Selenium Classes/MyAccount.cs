using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
	}
}

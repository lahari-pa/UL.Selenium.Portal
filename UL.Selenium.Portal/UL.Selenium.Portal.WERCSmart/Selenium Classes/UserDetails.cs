using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class UserDetails : BaseObject
	{
		public const string BasePath = "//div[@id='add-user-dialog']";
		protected override IWebElement containerElement { get; set; }

		[FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Name')]/following-sibling::input")]
		private IWebElement _sName;

		[FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Title')]/following-sibling::input")]
		private IWebElement _sTitle;

		[FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Phone Number')]/following-sibling::input")]
		private IWebElement _sPhoneNumber;

		[FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Email Address')]/following-sibling::input")]
		private IWebElement _sEmailAddress;

		[FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Confirm Email Address')]/following-sibling::input")]
		private IWebElement _sConfirmEmail;

		[FindsBy(How = How.XPath, Using = "//input[contains(@placeholder, 'Country Code')]")]
		private IWebElement _sCountryCode;

		[FindsBy(How = How.XPath, Using = "//label[@class='checkbox-inline']/input[contains(@data-bind, 'purview')]")]
		private IWebElement _bPurview;

		[FindsBy(How = How.XPath, Using = "//label[@class='checkbox-inline']/input[contains(@data-bind, 'Notifications')]")]
		private IWebElement _bNotificatinos;



		public string Name {
			get => this._sName.GetValue();
			set
			{
				this._sName.EnterText(value);
				Report.Success("Entered name: " + value);
			}
		}

		public string Title {
			get => this._sTitle.GetValue();
			set
			{
				this._sTitle.EnterText(value);
				Report.Success("Entered title: " + value);
			}
		}

		public string UserRole {
			get
			{
				//var test = containerElement.FindElement(By.XPath(".//label[contains(text(),'User Role')]"));
				//var test2 = test.FindElement(By.XPath("following-sibling::select"));
				//this.RefreshPageObject();
				this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				IWebElement el = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind, 'userRole')]"));
				return el.GetValue();
			}
			set
			{
				//var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'User Role')]/following-sibling::select"), 2);
				this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				IWebElement el = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind, 'userRole')]"), 2);
				el.Select(value);
			}
		}

		public string PhoneNumber {
			get => this._sPhoneNumber.GetValue();
			set
			{
				this._sPhoneNumber.EnterText(value);
				Report.Success("Entered title: " + value);
			}
		}

		public string EmailAddress {
			get => this._sEmailAddress.GetValue();
			set
			{
				this._sEmailAddress.EnterText(value);
				Report.Success("Entered email address: " + value);
			}
		}

		public string ConfirmEmailAddress {
			get => this.containerElement.FindElement(By.Id("txtConfirm"), 2).GetValue();
			set
			{
				this.containerElement.FindElement(By.Id("txtConfirm"), 2).EnterText(value);
				Report.Success("Entered confirm email address: " + value);
			}
		}

		public string Country {
			get
			{
				//var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Country')]/following-sibling::select"), 2);
				this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				IWebElement el = this.containerElement.FindElement(By.XPath(".//select[@id='regCountry']"));
				return el.GetValue();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
				el.Select(value);
			}
		}

		public string CountryCode {
			get
			{
				this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				return this._sCountryCode.GetValue();
			}

		}

		public bool SendNotifications {
			get => this._bNotificatinos.Selected;
			set => this._bNotificatinos.Click();
		}

		public bool Purview {
			get => this._bPurview.Selected;
			set => this._bPurview.Click();
		}

		public bool ClickButton(string sButtonName)
		{
			ReadOnlyCollection<IWebElement> buttons = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//a[@id='carouselContinue']"));
			IWebElement thisButton = buttons.FirstOrDefault(x => x.Text.ToLower().Trim() == sButtonName.ToLower());
			return thisButton.TryClick();
		}

		public bool ClickButtonOnAddUserDialog(string buttonToClick)
		{
			IWebElement addUserDialog = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='add-user-dialog']"));
			ReadOnlyCollection<IWebElement> buttons = addUserDialog.FindElements(By.XPath(".//button"));
			IWebElement matchingButton = buttons.FirstOrDefault(x => x.Text.ToLower().Trim() == buttonToClick.ToLower());
			if (matchingButton != null)
			{
				return matchingButton.TryClick();
			}
			return false;
		}

		//Phone Number Error
		[FindsBy(How = How.Id, Using = "phone_error")]
		private IWebElement _errorPhone;

		public bool Add_New_User(string username, string title, string role, string phoneNo, string emailAddress,
			string confirm, string country)
		{
			Report.Info("Beginning Add_New_User: " + username);

			Report.Info("Entering User Information");
			this.Name = username;
			this.Title = title;
			this.UserRole = role;
			this.PhoneNumber = phoneNo;
			this.EmailAddress = emailAddress;
			this.ConfirmEmailAddress = confirm;
			this.Country = country.ToUpper();

			Report.Info("User Details Entered");
			Report.Screenshot();

			if (!this.ClickButton("Create"))
			{
				Report.Info("Failed to Click Create Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(1);
			GeneralUtilities.Wait_for_load_finish();

			var myDlg = new AddUserThankYouDialog();
			myDlg.WaitForContainerToBeVisible(60);
			if (!myDlg.Add_User_Thank_You())
			{
				Report.Info("Failed to Add User");
				return false;
			}
			Report.Success("User Added");
			return true;
		}

	}

	class AddUserThankYouDialog : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='add-user-dialog']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		//Close Button
		private IWebElement BtnClose => this.containerElement.FindElement(By.XPath(".//div/button[text()='Close']"), 5);

		public bool Close_click()
		{
			Report.Info("Attempting to Click Close Button");
			return this.BtnClose.TryClick();
		}

		public bool Add_User_Thank_You()
		{
			Report.Info("Beginning Add_User_Thank_You");
			//containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			IWebElement myText = this.containerElement.FindElements(By.XPath(".//div/p[@class='marBot-20']"), 10).FirstOrDefault();

			if (myText == null)
			{
				Report.Info("Failed to Find Thank You Text");
				Report.Screenshot();
				return false;
			}

			if (myText.Text ==
				"The user account has been created and the user has been notified via email of their account information.")
			{
				Report.Success("Thank You Text Correct - User Has Been Created");
				Report.Screenshot();

				if (!this.Close_click())
				{
					Report.Info("Failed to Click Close Button");
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(2 * Delay.SpeedFactor);
				Report.Success("Close Button Clicked");
				Report.Screenshot();
				return true;
			}
			Report.Info("Thank You Text Incorrect: " + myText.Text);
			Report.Screenshot();
			return false;
		}

		public bool Updated_User_Thank_You_Close()
		{
			Report.Info("Beginning Add_User_Thank_You");
			IWebElement myText = this.containerElement.FindElements(By.XPath(".//div/p[@class='marBot-20']"), 10).FirstOrDefault();
			if (myText == null)
			{
				Report.Info("Failed to Find Thenk You Text");
				Report.Screenshot();
				return false;
			}
			Report.IsTrue(myText.Text == "The user account has been updated.", "Thank You Text Incorrect: " + myText.Text, "Thank You Text Correct: The user acount has been updated.");
			return this.Close_click();
		}
	}
}

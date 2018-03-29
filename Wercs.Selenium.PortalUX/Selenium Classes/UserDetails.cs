using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
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
			get
			{
				return this._sName.GetValue();
			}
			set
			{
				this._sName.EnterText(value);
				Report.Success("Entered name: " + value);
			}
		}

		public string Title {
			get
			{
				return this._sTitle.GetValue();
			}
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
				containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				var el = this.containerElement.FindElement(By.XPath(".//select[contains(@data-bind, 'userRole')]"));
				return el.GetValue();
			}
			set
			{
				var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'User Role')]/following-sibling::select"), 2);
				el.SelectByValue(value);
			}
		}

		public string PhoneNumber {
			get
			{
				return this._sPhoneNumber.GetValue();
			}
			set
			{
				this._sPhoneNumber.EnterText(value);
				Report.Success("Entered title: " + value);
			}
		}

		public string EmailAddress {
			get
			{
				return this._sEmailAddress.GetValue();
			}
			set
			{
				this._sEmailAddress.EnterText(value);
				Report.Success("Entered email address: " + value);
			}
		}

		public string ConfirmEmailAddress {
			get
			{
				return this._sConfirmEmail.GetValue();
			}
			set
			{
				this._sConfirmEmail.EnterText(value);
				Report.Success("Entered confirm email address: " + value);
			}
		}

		public string Country {
			get
			{
				//var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Country')]/following-sibling::select"), 2);
				containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				var el = this.containerElement.FindElement(By.XPath(".//select[@id='regCountry']"));
				return el.GetValue();
			}
			set
			{
				var el = this.containerElement.FindElement(By.XPath(".//select[@id='regCountry']"), 2);
				el.SelectByValue(value);
			}
		}

		public string CountryCode {
			get
			{
				containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				return this._sCountryCode.GetValue();
			}

		}

		public bool SendNotifications {
			get { return this._bNotificatinos.Selected; }
			set { this._bNotificatinos.Click(); }
		}

		public bool Purview {
			get { return this._bPurview.Selected; }
			set { this._bPurview.Click(); }
		}

		public bool ClickButton(string sButtonName)
		{
			var Buttons = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//a[@id='carouselContinue']"));

			var ThisButton = Buttons.FirstOrDefault(x => x.Text.ToLower().Trim() == sButtonName.ToLower());

			if (ThisButton != null)
			{
				ThisButton.ClickWithScroll();
				Delay.Seconds(2);
				return true;
			}

			return false;
		}

		public bool ClickButtonOnAddUserDialog(string ButtonToClick)
		{
			var AddUserDialog = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='add-user-dialog']"));
			var Buttons = AddUserDialog.FindElements(By.XPath(".//button"));
			var MatchingButton = Buttons.FirstOrDefault(x => x.Text.ToLower().Trim() == ButtonToClick.ToLower());
			if (MatchingButton != null)
			{
				MatchingButton.ClickWithScroll();
				Delay.Seconds(1);
				return true;
			}

			return false;
		}
	}
}

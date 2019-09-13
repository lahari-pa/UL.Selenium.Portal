using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class TopMenuBar : BaseObject
	{
		public const string BasePath = "//div[@class='navbar navbar-inverse navbar-fixed-top']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool AccountOptionsVisible()
		{
			return this.containerElement.FindElement(By.XPath("//ul[@class='dropdown-menu']"), 2).Displayed;
		}

		public bool MyAccountOptionPresent()
		{
			return this.containerElement.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[text()='My Account']"), 2) != null;
		}

		public bool SignOutOptionPresent()
		{
			return this.containerElement.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[text()='Sign Out']"), 2) != null;
		}

		public bool ClickOnUserTopRight()
		{
			return this.containerElement.FindElement(By.XPath("//a[contains(@class,'dropdown-toggle oDrop')]"), 2).TryClick();
		}

		public bool ClickOnHelpTopRight()
		{
			return this.containerElement.FindElement(By.XPath("//a[contains(@class,'dropdown-toggle live-help')]"), 2).TryClick();
		}

		public bool ClickSignOut()
		{
			return this.SelectAccountOption("Sign Out");
		}

		public bool ClickMyAccount()
		{
			return this.SelectAccountOption("My Account");
		}

		//Valid options: "My Account", "Sign Out"
		public bool SelectAccountOption(string option)
		{
			try
			{
				//show account options
				if (!this.AccountOptionsVisible())
				{
					this.ClickOnUserTopRight();
				}
				//if (!AccountOptionsVisible())
				//{
				//	throw new Exception("Account options are not visible as expected");
				//}

				int i = 0;
				while (i < 10)
				{
					IList<IWebElement> aTags = this.containerElement.FindElements(By.XPath("//ul[@class='dropdown-menu']/li/a"));
					if (aTags.FirstOrDefault(x => x.Text == option.Trim()).TryClick())
					{
						return true;
					}
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
				}

				return false;
			}
			catch (Exception)
			{
				Report.Info("There was a problem with the SelectAccountOption function for option: " + option);
				return false;
			}

		}

		public bool WercSmartLogoShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']/h1"), 2) != null;
		}

		public bool ClickWercsSmartLogo()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']/h1"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool NotificationIconShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//i[@class='fa fa-bell']"), 2) != null;
		}

		public void ClickNotificationIcon()
		{
			this.containerElement.FindElement(By.XPath("..//i[@class='fa fa-bell']/.."), 2).Click();
		}

		public bool UserIconShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//i[@class='fa fa-user']"), 2) != null;
		}

		public string GetCurrentUser()
		{
			Report.Info("Beginning get current user");
			IWebElement ddt = this.containerElement.FindElement(By.XPath("//a[contains(@class,'dropdown-toggle oDrop')]"), 2);
			ddt.ScrollElementIntoView();
			return ddt.GetValue();

		}

		public bool ClickLiveHelp()
		{
			return this.containerElement.FindElement(By.XPath(".//a[(.//i[@id='live-help'])]"), 2).TryClick();
		}

		public bool LoggedIn()
		{
			try
			{
				IWebElement ddt = this.containerElement.FindElement(By.XPath("//a[contains(@class,'dropdown-toggle oDrop')]"), 2);
				if (ddt == null)
				{
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}

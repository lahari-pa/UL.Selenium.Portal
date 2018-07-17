using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class LiveHelp : BaseObject
	{
		public const string BasePath = "//div[@id='lc_chat_layout']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool EnterName(string name)
		{
			try
			{
				var NameInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='lc_chat_name']"));
				NameInput.TryClick();
				if (NameInput == null)
				{
					Report.Error("Failed to find name");
				}
				else
				{
					NameInput.EnterText(name);
					return this.GetName() == name;
				}
			}
			catch (Exception e)
			{
				return false;
			}

			return false;

		}

		public string GetName()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='lc_chat_name']")).GetValue();
		}

		public bool EnterEmail(string email)
		{
			SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='lc_chat_email']")).EnterText(email);
			return this.GetEmail() == email;
		}

		public string GetEmail()
		{ 
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='lc_chat_email']")).GetValue(); 
		}

		public bool ClickSubmit()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@id='lc_precaht_submit']")).TryClick();
		}

		public string GetFormText()
		{
			return containerElement.FindElement(By.XPath(".//div[@id='lc_prechat_form']/p")).GetValue().Trim();

		}

		public bool ClickCloseX()
		{
			return containerElement.FindElement(By.XPath(".//span[@id='lc-close']")).TryClick();
		}


	}
}

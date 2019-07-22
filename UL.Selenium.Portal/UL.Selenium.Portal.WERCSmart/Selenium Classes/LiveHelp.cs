using System;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class LiveHelp : BaseObject
	{
		public const string BasePath = "//div[@class='h-conv ember-view']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load()
		{
			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}

		public bool VerifyThreeLinesIcon()
		{
			var icon = this.containerElement.FindElement(By.XPath(".//span[@class='ic-chat']//i"));
			return icon != null;
		}

		public bool VerifyX()
		{
			var x = this.containerElement.FindElement(By.XPath(".//div[@class='minimize']//i"));
			return x != null;
		}

		public bool VerifyInboxText()
		{
			string text = this.containerElement.FindElement(By.XPath(".//h1[@class='list-title ']")).Text;
			return text == "Inbox";
		}

		public bool VerifyMessageText(string message)
		{
			string text = this.containerElement.FindElement(By.XPath(".//div[@class='h-message-text']")).Text;
			return text == message;
		}

		public bool VerifyLowerText(string text)
		{
			string foundText = this.containerElement.FindElement(By.XPath(".//a[@class='product']")).Text;
			return foundText == text;
		}

		public bool VerifyPlaceholder(string text)
		{
			string placeholder = this.containerElement.FindElement(By.XPath(".//div[@id='app-conversation-editor']")).GetAttribute("data-placeholder");
			return placeholder == text;
		}

		public bool VerifyIcon(string icon)
		{
			IWebElement foundIcon = null;
			if (icon == "paperclip")
			{
				foundIcon = this.containerElement.FindElement(By.XPath(".//i[@class='icon-ic_attachment']"));
				return foundIcon != null;
			}
			else if (icon == "smiley")
			{
				foundIcon = this.containerElement.FindElement(By.XPath(".//i[@class='icon-ic_smiley']"));
				return foundIcon != null;
			}
			else
			{
				return false;
			}
		}

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
			catch (Exception)
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
			return this.containerElement.FindElement(By.XPath(".//div[@id='lc_prechat_form']/p")).GetValue().Trim();

		}

		public bool ClickCloseX()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='minimize']//i")).TryClick();
		}


	}
}

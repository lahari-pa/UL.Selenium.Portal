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
			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}

		public bool VerifyThreeLinesIcon()
		{
			return this.containerElement.FindElement(By.XPath(".//span[@class='ic-chat']//i"), 5) != null;
		}

		public bool VerifyX()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='minimize']//i"), 2) != null;
		}

		public bool VerifyInboxText()
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//h1[@class='list-title ']"), 2);
			return elem != null && elem.Text == "Inbox";
		}

		public bool VerifyMessageText(string message)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//div[@class='h-message-text']"), 2);
			return elem != null && elem.Text == message;
		}

		public bool VerifyLowerText(string text)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//a[@class='product']"), 2);
			return elem != null && elem.Text == text;
		}

		public bool VerifyPlaceholder(string text)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//div[@id='app-conversation-editor']"), 2);
			return elem != null && elem.GetAttribute("data-placeholder") == text;
		}

		public bool VerifyIcon(string icon)
		{
			if (icon == "paperclip")
			{
				return this.containerElement.FindElement(By.XPath(".//i[@class='icon-ic_attachment']"), 2) != null;
			}
			else if (icon == "smiley")
			{
				return this.containerElement.FindElement(By.XPath(".//i[@class='icon-ic_smiley']"), 2) != null;
			}
			else
			{
				return false;
			}
		}

		public bool ClickCloseX()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='minimize']//i"), 2).TryClick();
		}


	}
}

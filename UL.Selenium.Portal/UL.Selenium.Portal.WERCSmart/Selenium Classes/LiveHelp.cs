using System;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class LiveHelp : SeleniumBaseObject
	{
		private const string _basePath = "//div[@class='h-conv ember-view']";

		protected override By ContainerElementLocator => By.XPath(_basePath);

		public bool Wait_for_load()
		{
			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"), 5);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			return base.WaitForContainerToBeVisible();
		}

		public bool VerifyThreeLinesIcon()
		{
			return this.containerElement.FindElement(By.XPath(".//span[@class='ic-chat']//i"), 2) != null;
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
			if (icon == "smiley")
			{
				return this.containerElement.FindElement(By.XPath(".//i[@class='icon-ic_smiley']"), 2) != null;
			}
			return false;
		}

		public bool ClickCloseX()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='minimize']//i"), 2).TryClick();
		}


	}
}

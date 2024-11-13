using System;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
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
			IWebElement frame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//iframe"), 5);
			SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(frame);
			return base.WaitForContainerToBeVisible();
		}

		public bool VerifyThreeLinesIcon()
		{
			IWebElement threeLinesIcon = this.containerElement.FindElement(By.XPath(".//img[@class='animated zoomIn faster']"), 5);
			return threeLinesIcon != null;
		}

		public bool VerifyX()
		{
			IWebElement xIcon = this.containerElement.FindElement(By.XPath("./../../preceding-sibling::div[contains(@class,'d_hotline minimize')]//i"), 5);
			return xIcon != null;
		}

		public bool VerifyInboxText()
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//h1[@class]"), 2);
			var textFound = elem.Text;
			return elem != null && elem.Text == "Inbox";
		}

		public bool VerifyDescText(string expectedDesc)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//p[contains(@class,'channel-desc')]"), 2);
			if(elem == null)
			{
				Report.Info($"Description element was found to be null");
				return false;
			}
			var textFound = elem.Text;
			return textFound == expectedDesc;
		}

		public bool VerifyMessageText(string message)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'h-message-text')]"), 2);
			return elem != null && elem.Text == message;
		}

		public bool VerifyLowerText(string text)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//a[@class='product']"), 2);
			return elem != null && elem.Text == text;
		}

		public bool VerifyPlaceholder(string text)
		{
			IWebElement elem = this.containerElement.FindElement(By.XPath(".//div[@id='app-conversation-editor']"), 5);
			return elem != null && elem.GetAttribute("placeholder") == text;
		}

		public bool VerifyIcon(string icon)
		{
			if (icon == "paperclip")
			{
				IWebElement paperclipIcon = this.containerElement.FindElement(By.XPath(".//i[@class='icons icon-ic_attachment']"), 2);
				return paperclipIcon != null;
			}
			if (icon == "smiley")
			{
				IWebElement smileyIcon = this.containerElement.FindElement(By.XPath(".//i[@class='icons icon-ic_smiley']"), 2);
				return smileyIcon != null;
			}
			return false;
		}

		public bool ClickCloseX()
		{
			IWebElement closeXButton = this.containerElement.FindElement(By.XPath("./../../preceding-sibling::div[contains(@class,'d_hotline minimize')]//i"), 2);
			return closeXButton.TryClick();
		}


	}
}

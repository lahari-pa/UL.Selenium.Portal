using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class StudioDesktop : SeleniumBaseObject
	{
		public const string BasePath = "//iframe[@id='dashboard']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		//events, announcements, regulatory, technical
		public bool ClickSection(string section)
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("dashboard");
			return SeleniumBrowser.WebBrowser
				.FindElement(By.XPath(".//div[@id='sections-index']//li[@class='" + section.ToLower() + "']//a"))
				.TryClick();
		}



		


	}

	public class PasswordExpireNotice:StudioDesktop
	{

		public bool WaitForLoad()
		{
			var el = SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath(".//div[@class='modal-title' and text()='Password Expiration Notice']"), 2);
			return el != null;
		}

		public bool ClickButton(string buttonName)
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath($".//button[text()='{buttonName}']"), 2).TryClick();
		}
	}

	public class ResetYourPasswordPopup : SeleniumBaseObject
	{

		protected override By ContainerElementLocator => By.XPath("//div[@class='logon-container' and //h1[text()='Change your password']]");

		private List<IWebElement> TableDataRows => ContainerElement.FindElements(By.XPath($".//div[@class='row']"), 2).ToList();

		private IWebElement WantedRow(string rowTitle) => ContainerElement.FindElement(By.XPath($".//div[@class='row']//div[@class='c5']//label[text()='{rowTitle}']"), 2);

		private IWebElement WantedInput(IWebElement row) => row.FindElement(By.XPath($"./ancestor::div[@class='c5']//following::div[@class='c7']//input"), 2);

		private IWebElement SubmitButton => ContainerElement.FindElement(By.XPath($"//div[@class='action-bar']//input[@type='submit']"), 2);


		public IWebElement GetInputForWantedRow(string rowTitle)
		{
			var el = WantedRow(rowTitle);
			if(el ==null)
			{
				Report.Info($"el was null");
				return null;
			}
			var inputElement = this.WantedInput(el);
			if (inputElement == null)
			{
				Report.Info($"inputElement was null");
				return null;
			}
			return inputElement;
		}

		public bool EnterTextIntoInput(string rowTitle, string value)
		{
			var el = this.GetInputForWantedRow(rowTitle);
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}

			return el.TryEnterText(value);

		}

		public bool ClickSubmit()
		{
			var el = this.SubmitButton;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}

			return el.TryClick();

		}




	}


}

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ModalDialog : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'modal-dialog') and not(ancestor::div[@id='select-retailers-dialog' or @id='LogOutModal']) and (.//parent::div[contains(@style,'display: block')])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Click_OK()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "OK").TryClick();
		}

		public bool Click_Cancel()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "CANCEL").TryClick();
		}

		public bool Click_Close()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "close").TryClick();
		}

		public bool Click_Skip()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "SKIP").TryClick();
		}

		public bool Click_Closex()
		{
			return this.containerElement.FindElements(By.XPath("//button[@class='close']//span"), 2).FirstOrDefault(x => x.Text.Contains("×")).TryClick();
		}

		public bool CancelButtonExists()
		{
			try
			{
				var CancelButton = this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
					.FirstOrDefault(x => x.Text == "CANCEL");
				return (CancelButton.Enabled && CancelButton.Displayed);
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public string GetText()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}

		public List<string> GetAllText()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).Where(x => x.Displayed).Select(x => x.Text).ToList();
		}

		public string GetTitle()
		{
			return this.containerElement.FindElements(By.XPath("//*[@class='modal-title']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}

		public void EnterLoginPassword(string password)
		{
			containerElement.FindElement(By.XPath(".//input[@name='loginPassword']"), 2).EnterText(password);
		}

		public void EnterNewPassword(string password)
		{
			containerElement.FindElement(By.XPath(".//input[@id='newPassword']"), 2).EnterText(password);
		}

		public void EnterVerifyPassword(string password)
		{
			containerElement.FindElement(By.XPath(".//input[@id='verifyPassword']"), 2).EnterText(password);
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/a"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "continue").TryClick();
		}

		public bool ClickSave()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/a"), 2)
				.FirstOrDefault(x => x.Text.ToLower() == "save").TryClick();
		}

		public bool ClickButton(string button)
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2).FirstOrDefault(x => x.Text == button).TryClick();
		}
	}
}

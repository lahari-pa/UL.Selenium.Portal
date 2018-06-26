using System;
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


		public void Click_OK()
		{
			this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x =>x.Text == "OK").TryClick();
		}

		public bool Click_Cancel()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "CANCEL").TryClick();
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

		public string GetTitle()
		{
			return this.containerElement.FindElements(By.XPath("//*[@class='modal-title']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}
	}
}

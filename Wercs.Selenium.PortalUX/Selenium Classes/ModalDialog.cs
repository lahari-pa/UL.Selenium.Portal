using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ModalDialog : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'modal-dialog') and not(ancestor::div[@id='select-retailers-dialog' or @id='LogOutModal'])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public void Click_OK()
		{
			this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x =>x.Text == "OK").TryClick();
		}

		public void Click_Cancel()
		{
			this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "CANCEL").TryClick();
		}

		public string GetText()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-body']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}

		public string GetTitle()
		{
			return this.containerElement.FindElements(By.XPath("//h4[@class='modal-title']")).FirstOrDefault(x => x.Displayed)
				.Text;
		}
	}
}

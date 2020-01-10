using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
}

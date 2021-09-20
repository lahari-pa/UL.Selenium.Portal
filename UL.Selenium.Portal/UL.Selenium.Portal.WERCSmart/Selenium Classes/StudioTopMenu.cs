using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class StudioTopMenu : BaseObject
	{
		public const string BasePath = "//div[@id='navmenu']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			//get the window
			StudioUtilites.SwitchToWindow("Wercs Studio");
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}


		//My Wercs, UL Secure Connect, Authoring, Management, Distribution, System, Window, Help
		public bool ClickTopMenuItem(string item)
		{
			IWebElement navBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='navmenu']"));
			navBar.ScrollElementIntoView();
			ReadOnlyCollection<IWebElement> ListOfOptions = this.containerElement.FindElements(By.XPath(".//li//a"));
			return ListOfOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == item.Trim().ToLower()).TryClick();

		}

		public bool ClickSubMenu(string menuItem, string submenuItem)
		{

			IWebElement navBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='navmenu']"));
			navBar.ScrollElementIntoView();
			ReadOnlyCollection<IWebElement> ListOfOptions = this.containerElement.FindElements(By.XPath(".//li//a"));
			IWebElement topMenuItem = ListOfOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == menuItem.Trim().ToLower());
			if (topMenuItem.TryClick())
			{
				ReadOnlyCollection<IWebElement> ListOfSubMenuOptions = topMenuItem.FindElements(By.XPath(".//following-sibling::ul/li/a"));
				return ListOfSubMenuOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == submenuItem.Trim().ToLower()).TryClick();
			}
			return false;
		}

	}
}

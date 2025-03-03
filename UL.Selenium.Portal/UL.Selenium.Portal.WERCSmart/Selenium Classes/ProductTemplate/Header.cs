using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ProductTemplate
{
	class Header : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath(@"//header[@class='sticky-top']");
		private IWebElement LogoutButton => this.FindElement(By.XPath(".//button[text()='Logout']"), 1);
		#endregion

		#region Methods
		public bool LogoutButtonExists()
		{
			Report.Info($"Attempting to confirm Logout button exists.");
			return this.LogoutButton != null;
		}

		public bool LogoutButtonClick()
		{
			Report.Info($"Attempting to click the Logout button.");
			return this.LogoutButton.TryClick();
		}
		#endregion
	}
}

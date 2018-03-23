using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ForwardProductRegistration : BaseObject
	{
		// Again a pretty poor/generic ID, but it's the best we have....
		public const string BasePath = "//div[@id='dataentry']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public List<string> ListOfRetailers()
		{
			var els = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'wizard-step-panel')]/div[@role='tabpanel']/div//input[@type='checkbox']/../span"), 2);
			if (els.Count == 0)
			{
				return null;
			}

			return els.Select(x => x.Text.Trim()).ToList();
		}

		/// <summary>
		/// this is the title of the page Forward Product Registration
		/// </summary>
		/// <returns></returns>
		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//h2"), 2).Text.Trim();
		}

		/// <summary>
		/// This is the fourth area on the page You most recently did business with
		/// </summary>
		/// <returns></returns>
		public List<string> SubHeadings4Showing()
		{
			return this.containerElement.FindElements(By.XPath(".//h4"), 2).Select(x => x.Text.Trim()).ToList();
		}

		/// <summary>
		/// this is the third area on the page sub heading Select Retailers
		/// </summary>
		/// <returns></returns>
		public List<string> SubHeadings3Showing()
		{
			return this.containerElement.FindElements(By.XPath(".//h3"), 2).Select(x => x.Text.Trim()).ToList();
		}

	}
}

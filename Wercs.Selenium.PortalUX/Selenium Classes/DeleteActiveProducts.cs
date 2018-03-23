using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class DeleteActiveProducts : BaseObject
	{
		public const string BasePath = "//div[@id='delete-active-products-grid']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		/// <summary>
		/// this is the title of the page Delete Active Product
		/// </summary>
		/// <returns></returns>
		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath("..//h2"), 2).Text.Trim();
		}

		/// <summary>
		/// this is the third area on the page sub heading Products
		/// </summary>
		/// <returns></returns>
		public List<string> SubHeadings3Showing()
		{
			return this.containerElement.FindElements(By.XPath(".//h3"), 2).Select(x => x.Text.Trim()).ToList();
		}

	}
}

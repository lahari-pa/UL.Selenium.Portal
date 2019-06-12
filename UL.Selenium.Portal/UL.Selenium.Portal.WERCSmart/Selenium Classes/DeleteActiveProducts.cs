using NTTQA.Selenium.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DeleteActiveProducts : BaseObject
	{
		public const string BasePath = "//div[@id='delete-active-products-grid']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

	}
}

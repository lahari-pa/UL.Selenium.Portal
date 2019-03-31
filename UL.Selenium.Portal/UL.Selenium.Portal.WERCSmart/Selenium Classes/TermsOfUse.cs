using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class TermsOfUse : BaseObject
	{
		public const string BasePath = "//div[@id='termsOfUserContainer']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Accept()
		{
			var checkBox = this.containerElement.FindElement(By.XPath(".//input[@id='Accepted']"), 2);
			if (checkBox == null)
			{
				return;
			}

			checkBox.ScrollElementIntoView();
			checkBox.Check(true);

			var acceptBtn = this.containerElement.FindElement(By.XPath(".//button[@value='Continue' and @type='submit']"), 2);
			acceptBtn.Click();
		}

	}
}

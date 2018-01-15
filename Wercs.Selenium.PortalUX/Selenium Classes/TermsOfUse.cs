using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class TermsOfUse : BaseObject
	{
		public const string BasePath = "//div[@id='termsOfUserContainer']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Accept()
		{
			var CheckBox = containerElement.FindElement(By.XPath(".//input[@id='Accepted']"), 2);
			if (CheckBox == null)
				return;
			CheckBox.Check(true);

			var AcceptBtn = containerElement.FindElement(By.XPath(".//button[@value='Continue' and @type='submit']"), 2);
			AcceptBtn.Click();
		}

	}
}

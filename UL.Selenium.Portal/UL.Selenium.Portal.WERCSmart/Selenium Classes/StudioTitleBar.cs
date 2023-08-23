using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioTitleBar : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@aria-describedby='Widget3']");
		private IWebElement CloseButton => this.ContainerElement.FindElement(By.XPath("//button"));

		public bool CloseJobQueueWindow()
		{
			return this.CloseButton.TryClick();
		}

	}
}

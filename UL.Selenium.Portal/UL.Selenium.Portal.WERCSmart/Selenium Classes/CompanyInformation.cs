using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;


namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class CompanyInformation : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		IWebElement EditLink(string section) => this.ContainerElement.FindElement(By.XPath($"//div[h3[text()='{section}']]//a[text()='Edit']"));
		IWebElement CompanyEditLink(string section) => this.ContainerElement.FindElement(By.XPath($"//div[@class='row'][div//h3[text()='{section}']]//a[text()='Edit']"));
		 
		public bool EditLinkExists(string section)
		{
			Report.Info($"Attempt to find the 'edit' link for section '{section}'");
			return this.EditLink(section) != null;
		}
		public bool ClickEditLink(string section)
		{
			Report.Info($"Attempt to click the 'edit' link for section '{section}'");
			return this.EditLink(section).TryClick();
		}
		public bool CompanyEditLinkExists(string section)
		{
			Report.Info($"Attempt to find the 'edit' link for section '{section}'");
			return this.CompanyEditLink(section) != null;
		}
		public bool CompanyClickEditLink(string section)
		{
			Report.Info($"Attempt to click the 'edit' link for section '{section}'");
			return this.CompanyEditLink(section).TryClick();
		}
	}
}

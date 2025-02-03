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
		IWebElement LinkElement(string section, string link) => this.ContainerElement.FindElement(By.XPath($".//div[h3[text()='{section}']]//a[text()='{link}']"));
		IWebElement CompanyLinkElement(string link) => this.ContainerElement.FindElement(By.XPath($".//div[@class='row'][div//span[normalize-space(text()) = 'Company Name']]//a[text()='{link}']"));

		public bool LinkElementExists(string section, string linkText)
		{
			Report.Info($"Attempt to find the '{linkText}' link for section '{section}'");
			return this.LinkElement(section, linkText) != null;
		}
		public bool ClickLinkElement(string section, string linkText)
		{
			Report.Info($"Attempt to click the '{linkText}' link for section '{section}'");
			return this.LinkElement(section, linkText).TryClick();
		}
		public bool CompanyEditLinkExists(string linkText)
		{
			Report.Info($"Attempt to find the '{linkText}' link for section 'Company'");
			return this.CompanyLinkElement(linkText) != null;
		}
		public bool CompanyClickEditLink(string linkText)
		{
			Report.Info($"Attempt to click the '{linkText}' link for section 'Company'");
			return this.CompanyLinkElement(linkText).TryClick();
		}
	}
}

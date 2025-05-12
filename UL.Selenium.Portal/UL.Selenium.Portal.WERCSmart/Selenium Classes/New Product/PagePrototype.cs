using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	internal class PagePrototype
	{

	}

	public class SearchBoxResultNew (IWebElement containerElement)
	{

	}

	public class SearchBox : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath($"//span[contains(@class,'select2-container--open')][.//input[@type='search']]");
		private IWebElement SearchInput => this.FindElement(By.XPath(".//input[@type='search']"), 1);
		#endregion

		#region Class Methods

		#endregion
	}


}

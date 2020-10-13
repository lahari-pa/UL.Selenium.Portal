using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.SpecFlow.Classes;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.Selenium.Functions;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	public class WebElements : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='dataentry']");

		public bool ConfirmDocumentPurposeTypeOption(string option)
		{
			IList <IWebElement> optionEl = this.containerElement.FindElements(By.XPath(@"//select[@id='docType']//option"), 2);
			foreach (var optionStr in optionEl)
			{
				if (optionStr.Text == option)
				{
					return true;
				}
			}

			return false;
		}
	}
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ForwardProductRegistrationPage : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.Id("dataentry");
		private IWebElement PageHeader => this.FindElement(By.XPath(".//div[@class='product-header']//h2[text()]"), 1);
		private List<IWebElement> WizardTabsList => this.FindElements(By.XPath(".//div[contains(@class,'prog-step')]//a[normalize-space()]"),1).ToList();
		private IWebElement WizardTab(string tabLabel) => this.WizardTabsList.FirstOrDefault(x=>x.Text.Equals(tabLabel));
		#endregion

		#region Class Methods
		public bool PageHeaderExists()
		{
			Report.Info($"Attempting to confirm page header exists.");
			return this.PageHeader != null;
		}

		public string PageHeaderText()
		{
			Report.Info($"Attempting to get page header text.");
			return this.PageHeader.Text;
		}


		#endregion
	}
}

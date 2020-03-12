using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Features.PhilipsFolder
{
	class PhilipsWebElements : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => throw new NotImplementedException();

		public bool FindColumnWithTable(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement SupplierError = this.containerElement.FindElement(By.XPath("//th[contains(text(),'" + row["Column Name"] + "')]"), 2);

				if (SupplierError == null)
				{
					return false;
				}
			}
			return true;
		}

		public bool ClickCheckBoxWithLabel(string label)
		{
			IWebElement checkBox = this.containerElement.FindElement(By.XPath("//input[@id='show-only-discontinued-products']"), 2);
			return checkBox.TryCheck();
		}
	}

}

using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
	class GTIN_UPC_TableRow : SeleniumBaseObject
	{
		public string upcNumber;
		public GTIN_UPC_TableRow(string upcNumber)
		{
			this.upcNumber = upcNumber;
		}
		protected override By ContainerElementLocator => By.XPath($"//table[@class = 'table table-hover upc-table']//tr[td[span[text()='{this.upcNumber}']]]");
		IWebElement WarningIcon => this.ContainerElement.FindElement(By.XPath(".//i[@title = 'This GTIN/UPC is duplicated.']"));
		IWebElement Checkbox => this.ContainerElement.FindElement(By.XPath($".//input[@type='checkbox']"));

		public bool WarningIconExists()
		{
			Report.Info("Attempt to confirm Warning Icon exists");
			return this.WarningIcon != null;
		}
		public bool CheckboxExists()
		{
			Report.Info("Attempt to confirm Warning Icon exists");
			return this.Checkbox != null;
		}
		public bool ClickCheckbox()
		{
			Report.Info("Attempt to click chckbox");
			return this.Checkbox.TryClick();
		}
		public bool CheckboxSelected()
		{
			return this.Checkbox.Selected;
		}
	}
	class GTIN_UPC_Table : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath($"//table[@class = 'table table-hover upc-table']");
		List<IWebElement> UPCRowsList => this.ContainerElement.FindElements(By.XPath(".//tbody//tr")).ToList();

		public List<string> DuplicatedUPCs()
		{
			List<string> duplacatedUPCs = new List<string>();
			foreach (IWebElement upc in this.UPCRowsList)
			{
				IWebElement UPCNumber = upc.FindElement(By.XPath(".//td//span[contains(@data-bind, 'upcNumber.field')]"));
				IWebElement WarningIcon = upc.FindElement(By.XPath(".//i[@title = 'This GTIN/UPC is duplicated.']"));
				string upcNumber = UPCNumber.Text;
				if (WarningIcon.Displayed)
				{
					duplacatedUPCs.Add(upcNumber);
				}
			}
			return duplacatedUPCs;
		}
		public bool CheckAllUpcWithNumber(string upcNumber)
		{
			bool result = false;
			foreach (IWebElement upc in this.UPCRowsList)
			{
				IWebElement UPCNumber = upc.FindElement(By.XPath(".//td//span[contains(@data-bind, 'upcNumber.field')]"));
				IWebElement Checkbox = upc.FindElement(By.XPath(".//input[@type='checkbox']"));
				string getUpcNumber = UPCNumber.Text;
				if (getUpcNumber == upcNumber && !Checkbox.Selected)
				{
					result = Checkbox.TryClick();
				}
			}
			return result;
		}
	}
}

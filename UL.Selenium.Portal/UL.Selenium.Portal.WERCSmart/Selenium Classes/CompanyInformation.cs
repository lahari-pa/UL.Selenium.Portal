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
		IWebElement AccountsNumber(string accountType) => this.ContainerElement.FindElement(By.XPath($".//a[contains(normalize-space(),'{accountType} Accounts')]/span"), 2);

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
		public bool AccountsNumberExists(string accountType)
		{
			Report.Info($"Attempt to find the '{accountType} Accounts' number");
			return this.AccountsNumber(accountType) != null;
		}
		public string GetAccountsNumber(string accountType)
		{
			Report.Info($"Attempt to get the '{accountType} Accounts' number");
			return this.AccountsNumber(accountType).Text;
		}
	}

	class CompanyInformationSection : SeleniumBaseObject
	{
		#region Page Objects
		private string _label;
		protected override By ContainerElementLocator => By.XPath($".//div[h3[text()='{_label}']] | //div[@class='row'][div//span[normalize-space(text()) = '{_label}']]");
		IWebElement DataField(string field, string value) => this.FindElement(By.XPath($".//span[normalize-space() = '{field}']//preceding-sibling::*[self::span or self::h3][normalize-space()='{value}'] | .//span[normalize-space() = '{field}']//following-sibling::*//span[normalize-space()='{value}'] | .//span[normalize-space() = '{field}']//following-sibling::span[normalize-space()='{value}']"));
		IWebElement AddressInputField(string field) => this.FindElement(By.XPath($".//span[normalize-space() = '{field}']/following-sibling::div[1]//input"));
		IWebElement AddressSelectField(string field) => this.FindElement(By.XPath($".//span[normalize-space() = '{field}']/following-sibling::div[1]//select"));

		#endregion

		#region Methods

		public CompanyInformationSection(string label)
		{
			Report.Info($"Attempt to get '{label}' section");
			_label = label;
		}
		public bool FindCompanyData(string field, string value)
		{
			Report.Info($"Attempt to find the '{field}' is '{value}'.");
			return this.DataField(field, value) != null;
		}
		public bool VerifyCompanyData(string field, string value)
		{
			Report.Info($"Attempt to verify that '{field}' is '{value}'.");
			return this.DataField(field, value).Displayed;
		}
		public bool AddressInputFieldExists(string field)
		{
			Report.Info($"Attempt to get input field for '{field}'.");
			return this.AddressInputField(field) != null;
		}
		public bool AddressInputFieldEnterText(string field, string value)
		{
			Report.Info($"Attempt to enter '{value}' into the '{field}' input field.");
			return this.AddressInputField(field).TryEnterText(value);
		}
		public bool AddressSelectFieldExists(string field)
		{
			Report.Info($"Attempt to get select field for '{field}'.");
			return this.AddressSelectField(field) != null;
		}
		public bool AddressSelectFieldSelectOption(string field, string value)
		{
			Report.Info($"Attempt to select '{value}' for the '{field}' field.");
			this.AddressSelectField(field).Select(value);
			return this.AddressSelectField(field).SelectedOption() == value;
		}
		#endregion
	}
	class CompanyInfoStewardshipTable : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath($"//table");
		List<IWebElement> Columns => this.FindElements(By.XPath($".//thead//tr/th")).ToList();

		#endregion

		#region Methods
		public bool ColumnExists(string columnName)
		{
			Report.Info($"Attempt to get column '{columnName}'");
			return this.Columns.Find(column => column.Text.Equals(columnName)) != null;

		}
		public int GetColumnIndex(string columnName)
		{
			Report.Info($"Attempt to get the '{columnName}' column index");
			return this.Columns.FindIndex(column => column.Text.Equals(columnName));
		}

		#endregion

	}
	class CompanyInfoStewardshipTableRow : SeleniumBaseObject
	{
		#region Page Objects
		private string _province;
		protected override By ContainerElementLocator => By.XPath($"//tbody//tr[td[text()='{_province}']]");

		#endregion

		#region Methods

		public CompanyInfoStewardshipTableRow(string province)
		{
			Report.Info($"Attempt to get '{province}' row in the 'Stewardship Numbers' table");
			_province = province;
		}
		public bool CheckTableData(string columnName, string value)
		{
			if (new CompanyInfoStewardshipTable().ColumnExists(columnName))
			{
				int columnIndex = new CompanyInfoStewardshipTable().GetColumnIndex(columnName);
				IWebElement Cell = this.ContainerElement.FindElement(By.XPath($".//td[{columnIndex+1}]/p[contains(@data-bind, 'text')]"));
				return Cell.Text.Contains(value);
			}
			else
			{
				Report.Info($"Cannot find the '{columnName}' column");
				return false;
			}
		}
		public bool EnterTableData(string columnName, string value)
		{
			bool result = false;
			if (new CompanyInfoStewardshipTable().ColumnExists(columnName))
			{
				int columnIndex = new CompanyInfoStewardshipTable().GetColumnIndex(columnName);
				IWebElement Cell = this.ContainerElement.FindElement(By.XPath($".//td[{columnIndex+1}]//input"));
				IWebElement OutsideClick = this.ContainerElement.FindElement(By.XPath($"//body"));
				result = Cell.TryEnterText(value);
				OutsideClick.Click();
				return result;
			}
			else
			{
				Report.Info($"Cannot find the '{columnName}' column");
				return false;
			}
		}

		#endregion

	}
}

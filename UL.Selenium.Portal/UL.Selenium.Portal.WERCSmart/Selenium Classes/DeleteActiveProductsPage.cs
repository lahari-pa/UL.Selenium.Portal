using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Functions;



namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class DeleteActiveOrdersPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		IWebElement InputText(string text) => this.ContainerElement.FindElement(By.XPath($"//input[contains(@placeholder,'{text}')]"), 2);

		private IWebElement SupplierIDDropdown => this.ContainerElement.FindElement(By.XPath($".//div[contains(@class,'search-group')]//select[contains(@placeholder,'Supplier ID')]"), 1);
		private List<IWebElement> SupplierIDDropdownOptionsList => this.SupplierIDDropdown.FindElements(By.XPath("//option"), 1).ToList();
		private IWebElement SupplierIDDropdownOption(string dropdownOption) => this.SupplierIDDropdownOptionsList.Where(x => x.Text.Trim() == dropdownOption).FirstOrDefault();

		IWebElement Table => this.ContainerElement.FindElement(By.XPath("//table[contains(@class,'products-table')]"), 2);

		#endregion

		#region Page Methods

		public void EnterText(string fieldname, string text)
		{
			this.InputText(fieldname).TryClick();
			this.InputText(fieldname).ClearTextBox();
			Report.Info("Enter the value for search");
			this.InputText(fieldname).EnterText(text);
		}

		public bool ClickStatusFilter(string option)
		{
			IList<IWebElement> allFilters = this.ContainerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
			IWebElement requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
			return requiredFilter.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool VerifyTheTextProductsWhichHaveActivity()
		{
			IWebElement ProductsWhichHaveActivity = this.ContainerElement.FindElement(By.XPath($"//p[text()='Products which have had no activity for 1 year or more are eligible for deletion on this screen']"), 2);
			return ProductsWhichHaveActivity.Displayed;
		}

		public bool ClickIAgreeCheckboxInMakeObsoletePopUp()
		{
			IWebElement AgreeCheckbox = this.ContainerElement.FindElement(By.XPath($"//div[contains(@class,'alert-danger')]//input[@type='checkbox']"), 2);
			return AgreeCheckbox.TryClick();
		}

		#region Supplier id dropdown

		public bool SupplierIDDropdownExists()
		{
			Report.Info($"Attempting to confirm SupplierID exists");
			return this.SupplierIDDropdown != null;
		}

		public bool SupplierIDDropdownClick()
		{
			Report.Info($"Attempting to click SupplierID dropdown");
			return this.SupplierIDDropdown.TryClick();
		}


		public bool SupplierIDDropdownOptionExists(string dropdownOption)
		{
			Report.Info($"Attempting to confirm SupplierID dropdown contains '{dropdownOption}' option.");
			return this.SupplierIDDropdownOption(dropdownOption) != null;
		}

		public bool SupplierIDDropdownOptionClick(string dropdownOption)
		{
			Report.Info($"Attempting to click Supplier ID dropdown '{dropdownOption}' option.");
			return this.SupplierIDDropdownOption(dropdownOption).TryClick();
		}

		#endregion


		public bool TableExists()
		{
			Report.Info("Starting looking for Table");
			return this.Table != null;
		}

		public bool SelectProductBasedOnProductName(string productName)
		{
			IWebElement ProductCheckbox(string productName) => this.FindElement(By.XPath($".//table[contains(@class,'products-table')]//tr//td[contains(@data-bind,'Product.Name')][contains(text(),'{productName}')]//ancestor::tr//td//input[@type='checkbox']"), 2);
			return ProductCheckbox(productName).TryClick();

		}

		public bool SelectProductBasedOnWPSID(string wpsid)
		{
			IWebElement ProductCheckbox(string wpsid) => this.FindElement(By.XPath($".//table[contains(@class,'products-table')]//tr//td[contains(@data-bind,'Product.ProductID')][contains(text(),'{wpsid}')]//ancestor::tr//td//input[@type='checkbox']"), 2);
			return ProductCheckbox(wpsid).TryClick();

		}

		public bool SelectProductBasedOnUPCNUmber(string upc)
		{
			IWebElement ProductCheckbox(string upc) => this.FindElement(By.XPath($".//table[contains(@class,'products-table')]//tr//td//ul[contains(@data-bind,'Product.UPCs')]//li//span[contains(text(),'{upc}')]//ancestor::tr//td//input[@type='checkbox']"), 2);
			return ProductCheckbox(upc).TryClick();

		}

		public bool SelectAllProductsCheckbox()
		{
			IWebElement AllProductCheckbox = this.FindElement(By.XPath($".//table[contains(@class,'products-table')]//td//input[contains(@data-bind,'checkAll')]"), 2);
			return AllProductCheckbox.TryClick();

		}

		#endregion


	}



}

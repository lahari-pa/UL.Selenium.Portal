using NPOI.HSSF.Record;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SubscriptionInformation : SeleniumBaseObject
	{
		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		IWebElement CompanyName(string companyName) => this.FindElement(By.XPath($".//h3[text()='{companyName}']"));
		IWebElement DataField(string field, string value) => this.FindElement(By.XPath($".//span[normalize-space() = '{field}']//following-sibling::span[normalize-space()='{value}']"));
		IWebElement SubscriptionInfoRow(string option) => this.ContainerElement.FindElement(By.XPath($".//div[@class='row'][div//strong[text()='{option}']]"), 2);
		IWebElement Text() => this.FindElement(By.XPath($".//p[@class='spaced-text']"));
		IWebElement DataOption(string field) => this.FindElement(By.XPath($".//p[@class='spaced-text']//span[normalize-space() = '{field}']"));
		IWebElement NumberOfSubmittedOrInCart(string submittedOrInCart) => this.FindElement(By.XPath($".//h4[normalize-space(text()) ='{submittedOrInCart}']//span"));
		IWebElement NumberOfProducts(string submittedOrInCart, string productType) => this.FindElement(By.XPath($".//div[h4[normalize-space(text()) ='{submittedOrInCart}']]//li[normalize-space(text()) ='{productType}']//span"));

		#endregion

		#region Methods
		public bool CompanyNameExists(string companyName)
		{
			Report.Info($"Attempt to find the company name");
			return this.CompanyName(companyName) != null;
		}
		public bool CompanyNameDisplayed(string companyName)
		{
			Report.Info($"Attempt to check the company name is '{companyName}'");
			return this.CompanyName(companyName).Displayed;
		}
		public bool DataFieldExists(string field, string value)
		{
			Report.Info($"Attempt to find the '{field}' is '{value}'.");
			return this.DataField(field, value) != null;
		}
		public bool DataOptionExists(string field)
		{
			Report.Info($"Attempt to find the field '{field}'.");
			return this.DataOption(field) != null;
		}
		public bool VerifyDataFieldValueIsDisplayed(string field, string value)
		{
			Report.Info($"Attempt to verify that '{field}' is '{value}'.");
			return this.DataField(field, value).Displayed;
		}
		public bool VerifySubscriptionInfoValues(string option, string value)
		{
			if (this.SubscriptionInfoRow(option) == null)
			{
				Report.Info($"There is no Subscription row with '{option}' data");
				return false;
			}
			else
			{
				IWebElement OptionValue(string value) => this.SubscriptionInfoRow(option).FindElement(By.XPath($".//div[contains(text(),'{value}')]"));
				return OptionValue(value) != null;
			}
		}
		public bool TextExists()
		{
			Report.Info($"Attempt to find text");
			return this.Text() != null;
		}
		public string GetText()
		{
			return this.Text().Text;
		}
		public bool NumberOfSubmittedOrInCartExists(string submittedOrInCart)
		{
			Report.Info($"Attempt to find number of the {submittedOrInCart} products");
			return this.NumberOfSubmittedOrInCart(submittedOrInCart) != null;
		}
		public string GetNumberOfSubmittedOrInCart(string submittedOrInCart)
		{
			Report.Info($"Attempt to get number of the {submittedOrInCart} products");
			return this.NumberOfSubmittedOrInCart(submittedOrInCart).Text;
		}
		public bool NumberOfProductsExists(string submittedOrInCart, string productType)
		{
			Report.Info($"Attempt to find number of {productType} products under the '{submittedOrInCart}' section");
			return this.NumberOfProducts(submittedOrInCart, productType) != null;
		}
		public string GetNumberOfProducts(string submittedOrInCart, string productType)
		{
			Report.Info($"Attempt to get number of {productType} products under the '{submittedOrInCart}' section");
			return this.NumberOfProducts(submittedOrInCart, productType).Text;
		}
		#endregion




	}
}

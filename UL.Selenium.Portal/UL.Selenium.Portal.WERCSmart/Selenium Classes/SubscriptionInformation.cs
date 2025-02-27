using OpenQA.Selenium;
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
	class SubscriptionHistoryTableRow : SeleniumBaseObject
	{
		#region Page Objects
		private string _subscriptionStatus;

		protected override By ContainerElementLocator => By.XPath($"//tbody//tr[td[normalize-space()='{_subscriptionStatus}']]");
		IWebElement EffectiveStart => this.ContainerElement.FindElement(By.XPath(".//td[comment()[contains(., 'Start')]]"));
		IWebElement EffectiveEnd => this.ContainerElement.FindElement(By.XPath(".//td[comment()[contains(., 'End')]]"));
		IWebElement BillCycle => this.ContainerElement.FindElement(By.XPath(".//td[comment()[contains(., 'BillCycle')]]"));
		IWebElement Quantity => this.ContainerElement.FindElement(By.XPath(".//td[comment()[contains(., 'Quantity')]]"));
		IWebElement AnnualPrice => this.ContainerElement.FindElement(By.XPath(".//td[comment()[contains(., 'AnnualPrice')]]"));

		#endregion

		#region Methods
		public SubscriptionHistoryTableRow(string subscriptionStatus)
		{
			Report.Info($"Attempt to get '{subscriptionStatus}' section");
			_subscriptionStatus = subscriptionStatus;
		}
		public bool EffectiveStartExists()
		{
			Report.Info($"Attempt to find the 'Effective Start' date");
			return this.EffectiveStart != null;
		}
		public string GetEffectiveStartDate()
		{
			Report.Info($"Attempt to get the 'Effective Start' date");
			return this.EffectiveStart.Text;
		}
		public bool EffectiveEndExists()
		{
			Report.Info($"Attempt to find the 'Effective End' date");
			return this.EffectiveEnd != null;
		}
		public string GetEffectiveEndDate()
		{
			Report.Info($"Attempt to get the 'Effective End' date");
			return this.EffectiveEnd.Text;
		}
		public bool BillCycleExists()
		{
			Report.Info($"Attempt to find the 'Bill Cycle' value");
			return this.BillCycle != null;
		}
		public string GetBillCycle()
		{
			Report.Info($"Attempt to get the 'Bill Cycle' value");
			return this.BillCycle.Text;
		}
		public bool QuantityExists()
		{
			Report.Info($"Attempt to find the 'Quantity' value");
			return this.Quantity != null;
		}
		public string GetQuantity()
		{
			Report.Info($"Attempt to get the 'Quantity' value");
			return this.Quantity.Text;
		}
		public bool AnnualPriceExists()
		{
			Report.Info($"Attempt to find the 'Annual Price' value");
			return this.AnnualPrice != null;
		}
		public string GetAnnualPrice()
		{
			Report.Info($"Attempt to get the 'Annual Price' value");
			return this.AnnualPrice.Text;
		}
		#endregion

	}
}

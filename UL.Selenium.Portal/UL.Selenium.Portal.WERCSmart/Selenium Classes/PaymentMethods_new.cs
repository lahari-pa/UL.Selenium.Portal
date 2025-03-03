using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PaymentMethods_new : SeleniumBaseObject
	{
		#region Constants
		protected override By ContainerElementLocator => By.Id("paymentMethodsContainer");
		private IWebElement PageHeader => this.ContainerElement.FindElement(By.XPath($".//div[@class='header-with-back']"), 1);
		private IWebElement PageHeaderBackButton => this.PageHeader.FindElement(By.XPath($".//a[@class=''back-btn]"), 1);
		private IWebElement PageHeaderLabel => this.PageHeader.FindElement(By.XPath($".//h2"), 1);
		private IWebElement PageSubHeaderLabel => this.ContainerElement.FindElement(By.XPath($".//h2[@class='ws-panel-title']"), 1);

		private string _paymentMethodButtonLabel;
		private IWebElement PaymentMethodButton => this.ContainerElement.FindElement(By.XPath($".//a[contains(@class,'big-link')]//div[text()='{_paymentMethodButtonLabel}']"), 1);
		#endregion

		#region Methods
		public bool PageHeaderLabelExists()
		{
			Report.Info($"Attempting to confirm the page header label exists.");
			return this.PageHeaderLabel != null;
		}

		public string PageHeaderLabelGet()
		{
			Report.Info($"Attempting to get the page header label.");
			return this.PageHeaderLabel.Text;
		}

		public bool PageHeaderBackButtonExists()
		{
			Report.Info($"Attempting to confirm the page header back button exists.");
			return this.PageHeaderBackButton != null;
		}

		public bool PageHeaderBackButtonClick()
		{
			Report.Info($"Attempting to click the page header back button.");
			return this.PageHeaderBackButton.TryClick();
		}

		public bool PageSubHeaderLabelExists()
		{
			Report.Info($"Attempting to confrim page sub header label exists.");
			return this.PageSubHeaderLabel != null;
		}

		public string PageSubHeaderLabelGet()
		{
			Report.Info($"Attempting to get the page sub header label.");
			return this.PageSubHeaderLabel.Text;
		}

		public bool PaymentMethodButtonExists(string paymentMethodButtonLabel)
		{
			Report.Info($"Attempting to confrim '{paymentMethodButtonLabel}' button exists.");
			_paymentMethodButtonLabel = paymentMethodButtonLabel;
			return this.PaymentMethodButton != null;
		}

		public bool PaymentMethodButtonClick(string paymentMethodButtonLabel)
		{
			Report.Info($"Attempting to click '{paymentMethodButtonLabel}' button.");
			_paymentMethodButtonLabel = paymentMethodButtonLabel;
			return this.PaymentMethodButton.TryClick();
		}
		#endregion
	}
}

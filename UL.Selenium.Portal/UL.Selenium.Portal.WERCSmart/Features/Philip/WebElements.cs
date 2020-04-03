using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using System.Collections.Generic;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	class WebElements : SeleniumBaseObject
	{

		public const string BasePath = "";

		protected override By ContainerElementLocator => throw new System.NotImplementedException();

		public bool ClickNDC(string text)
		{

			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[contains(@class,'select2-selection select2-selection--single')]"), 2);

			return el.TryClick();

		}
		public bool ClickFirstItem(string text)
		{

			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//ul[@class='select2-results__options']//li[1]"), 2);

			return el.TryClick();

		}
		
		public bool EnterNDC(string text)
		{

			IWebElement el1 = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@class='select2-search__field']"), 2);

			el1.TryEnterText(text);
			if (el1.Text == text)
			{
				return true;
			}
			return false;
		}
		public void CheckFields()
		{
			IList<IWebElement>el = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//input[@type='text']"), 2);
			foreach (IWebElement ell in el)
			{
				if (ell.Text == "")
				{
					ell.TryEnterText("Test");
				}
			}
		}
		public bool CloseDialog()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@aria-labelledby='ui-dialog =-title-dialog-supplier-manager']//span[text()='close']"), 2);
			return el.TryClick();
		}
		public bool ConfirmTier(string retailer, string[] arr, string marked)
		{

			IList<IWebElement> el = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//td[contains(text(), '" + retailer + "')]//following-sibling::td"), 2);

			foreach (string str in arr)
			{
				switch (str.ToLower())
				{
					case "tier 1":

						if (el[1].Text != marked)
						{
							return false;
						}

						break;

					case "tier 2.1":

						if (el[2].Text != marked)
						{
							return false;
						}

						break;

					case "tier 2.2":

						if (el[3].Text != marked)
						{
							return false;
						}

						break;

					case "tier 3":

						if (el[4].Text != marked)
						{
							return false;
						}

						break;

					case "tier 4.1":

						if (el[5].Text != marked)
						{
							return false;
						}

						break;

					case "tier 4.2":

						if (el[6].Text != marked)
						{
							return false;
						}

						break;

					default:
						return false;
						break;
				}

			}
			return true;
		}
		public bool ClickTab()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[text()='Data Tier Consent']"), 2);
			return el.TryClick();
		}
		public bool ClickResult()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@title='The WERCS LTD - STAGING']"), 2);
			return el.TryClick();
		}
		public bool SearchText(string text)
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='textSupplierSearch']"), 2);
			return el.TryEnterText(text);
		}
		public bool ClickSearch()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@id='supplierSearchButton']"), 2);
			return el.TryClick();
		}

		public bool ClickSuppliers()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[text()='Suppliers']"), 2);
			return el.TryClick();
		}
		public bool FindRadioButton(string shouldOrShouldNot, string radioButtonText)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//input[@type='radio']//following-sibling::span[text()='" + radioButtonText + "']"), 2);

			if (shouldOrShouldNot.ToLower() == "should")
			{
				if (el == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else if (shouldOrShouldNot.ToLower() == "should not")
			{
				if (el == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			return false;

		}

		public bool CheckAIS()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//label[contains(text(), 'Article Information Sheet (AIS)')]/..//following-sibling::div//div[@class='dropzone']//strong[contains(text(), 'Drop .pdf file here or click \"Browse\"')]"), 2);
			if (el == null)
			{ return false; }
			else
			{ return true; }
		}

		public bool Closepopup()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@data-bind='click: redirectToRetailers']"), 2);
			return el.TryClick();
		}
		public void CheckPopUp()
		{
			Delay.Seconds(5);
			IWebElement productID = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: html']//br[1]/preceding-sibling::text()[1]"), 2);
			IWebElement productType = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: html']//br[1]/following-sibling::text()[1]"), 2);
			IWebElement productAccessCode = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: html']//br[2]/following-sibling::text()[1]"), 2);
		}

		public bool CheckColumn()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//div[text()='CW']/../preceding-sibling::th//div[text()='Last Pub Date']"), 2);
			IWebElement el1 = this.containerElement.FindElement(By.XPath("//div[text()='CW']/../preceding-sibling::th//div[text()='GHS']"), 2);
			if (el != null && el1 != null)
			{
				return true;
			}
			return false;
		}

		public string FindProduct(string letter)
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@aria-describedby='list_Waste'][@title='" + letter +"']/preceding-sibling::td[@aria-describedby='list_Product']//span"), 2);
			return el.Text;
		}

		public void SearchSHA(string search)
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='ucSelectProdselectProdTB']"), 2);
			IWebElement el1 = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@class='button-icon icon-refresh'][1]"), 2);
			el.TryEnterText(search);
			el1.TryClick();
		}

		public bool FindProductN()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@aria-describedby='list_Waste'][@title='N']/preceding-sibling::td[@aria-describedby='list_Product']"), 2);
			if (el != null)
			{
				return true;
			}
			return false;
		}

		public bool ClickVendorSection()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//span[text()='[SECT0770] Vendor Report']"), 2);
			return el.TryClick();
		}

		public bool ClickASection()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//span[text()='[TXALL]']"), 2);
			return el.TryDoubleClick();
		}

		public bool CheckText()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//td[contains(text(), 'There is no (or limited) data available for any components and waste code has been assigned as a conservative approach due to lack of significant data showing non-hazardous')]"), 2);
			if (el != null)
			{
				return true;
			}

			return false;
		}
	}
}

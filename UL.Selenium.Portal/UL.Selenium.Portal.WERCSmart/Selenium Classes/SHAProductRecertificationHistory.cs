using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ProductRecertificationHistory : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='dialog-recertificationHistory']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement popupEditor = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}
			return false;
		}

		public void WaitForTableLoad(double timeout = 10)
		{
			Delay.Seconds(2);
			this.containerElement.WaitUntilElementInvisible(By.Id("load_listProdRecertHistory"), timeout);
		}

		//Close, Export
		public bool ClickButton(string button)
		{
			IList<IWebElement> varButtons = this.containerElement.FindElements(By.XPath("..//button/span"), 2);
			IWebElement matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		public List<string> GetHeaders()
		{
			//Report.Info("Beginning get headers");
			return SeleniumWebDriver.CurrentDriver
				.FindElements(By.XPath("//div[@id='dialog-recertificationHistory']/table//th"), 2).ToList()
				.Select(x => x.GetValue()).ToList();

		}

		public bool SelectItem(string columnHeader, string value)
		{
			Report.Info("Selecting item: " + value + " in column: " + columnHeader);
			List<string> rawHeaders = this.GetHeaders();
			var headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
			int indexOfHeader = 0;
			for (int i = 0; i < headers.Count; i++)
			{
				if (headers[i] == columnHeader)
				{
					indexOfHeader = i + 1;
					break;
				}
			}

			var listOfColumnItems = this.containerElement
				.FindElements(By.XPath(".//table[@id='listProdRecertHistory']//tr/td[" + indexOfHeader + "]"), 2)
				.ToList();

			var sValues = listOfColumnItems.Select(x => x.GetValue().Trim()).ToList();
			IWebElement matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

			if (matchingItem == null)
			{
				Report.Info("Could not find matching item");
				return false;
			}
			else
			{
				Report.Info("Trying to select");
				listOfColumnItems = this.containerElement
					.FindElements(By.XPath(".//tbody[@id='sortable-list2']/tr/td[" + indexOfHeader + "]"), 2).ToList();

				matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

				Delay.Seconds(1);
				matchingItem.TryClick();
				Delay.Seconds(2);

			}

			return true;
		}

		public List<Product> GetProducts()
		{
			List<string> rawHeaders = this.GetHeaders();
			var headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
			int indexOfID = 0;
			int indexOfProductName = 0;
			int indexOfActive = 0;
			int indexOfDate = 0;
			int indexOfReason = 0;

			for (int i = 0; i < headers.Count; i++)
			{
				if (headers[i] == "Product ID")
				{
					indexOfID = i + 1;
				}

				if (headers[i] == "Product Name")
				{
					indexOfProductName = i + 1;
				}

				if (headers[i] == "Active")
				{
					indexOfActive = i + 1;
				}

				if (headers[i] == "Date")
				{
					indexOfDate = i + 1;
				}

				if (headers[i] == "Recertification Reason")
				{
					indexOfReason = i + 1;
				}
			}

			IList<IWebElement> selectedRows = this.containerElement.FindElements(By.XPath(".//table[@id='listProdRecertHistory']//tr"), 2);
			var listOfProducts = new List<Product>();
			if (selectedRows == null)
			{
				Report.Info("No rows are showing");
				return listOfProducts;
			}

			foreach (IWebElement thisRow in selectedRows)
			{
				var thisProduct = new Product();
				thisProduct.ID = thisRow.FindElement(By.XPath(".//td[" + indexOfID + "]"), 2).GetValue();
				thisProduct.Name = thisRow.FindElement(By.XPath(".//td[" + indexOfProductName + "]"), 2).GetValue();
				thisProduct.Active = thisRow.FindElement(By.XPath(".//td[" + indexOfActive + "]"), 2).GetValue() ==
									 "true";
				string rD = thisRow.FindElement(By.XPath(".//td[" + indexOfDate + "]"), 2).GetValue();
				if (rD.Trim().Length > 0)
				{
					thisProduct.RecertificationDate = Convert.ToDateTime(rD);
				}

				thisProduct.RecertificationReason =
					thisRow.FindElement(By.XPath(".//td[" + indexOfReason + "]"), 2).GetValue();
				listOfProducts.Add(thisProduct);
			}

			return listOfProducts;
		}
	}
}

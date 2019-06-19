using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type
{
	class TheProduct : NewProduct
	{
		private IWebElement ProductNameInput => this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Name') or contains(text(),'Product name')]/../following-sibling::div/input"), 2);

		private IWebElement ProductLineInput => this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);

		private IWebElement ProductTypeSearch => this.containerElement.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"), 2);

		private IWebElement ProductTypeSearchInput => this.containerElement.WaitUntilElementVisible(By.XPath(".//span[contains(@class,'select2-container')]//input[@type='search']"), 2);

		private IEnumerable<IWebElement> ProductTypeSearchResults => this.containerElement.FindElements(By.XPath("//span[contains(@class,'select2-container')]//ul/li"), 2);

		public string ProductName
		{
			get => this.ProductNameInput?.GetValue();
			set => this.ProductNameInput?.EnterText(value);
		}

		public string ProductLineOrBrand
		{
			get => this.ProductLineInput.SelectedOption();
			set => this.ProductLineInput.SelectByValue(value);
		}

		public string ProductType
		{
			get => this.ProductTypeSearch?.Text;
			set
			{
				this.ProductTypeSearch.TryClick();
				this.ProductTypeSearchInput.TryEnterText(value);
				GeneralUtilities.Wait_for_load_finish();
				var searchResult = this.ProductTypeSearchResults.FirstOrDefault(x=>x.Text==value);
				// Check again ignoring the case
				if (searchResult == null)
				{
					searchResult = this.ProductTypeSearchResults.FirstOrDefault(x => x.Text.ToLower() == value.ToLower());
					if (searchResult == null)
					{
						//Check again accepting contains rather than full match
						searchResult = this.ProductTypeSearchResults.FirstOrDefault(x => x.Text.ToLower().Contains(value.ToLower()));
						if (searchResult == null)
						{
							return;
						}
					}
				}
				searchResult.TryClick();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ProductsGrid : BaseObject
	{
		public const string BasePath = "//div[@id='products-grid']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool HeaderShowing()
		{
			var el = this.containerElement.FindElements(By.XPath("./h3"), 2);
			return el.FirstOrDefault(x => x.Text.Trim() == "YOUR PRODUCTS") != null;
		}

		public bool ProductsPresent()
		{
			var productsGrid = this.containerElement.FindElement(By.XPath(".//table"), 2);
			if (productsGrid == null)
			{
				return false;
			}

			return productsGrid.FindElements(By.XPath(".//tbody/tr"), 2).Count != 0;
		}

		public int ProductsCount()
		{
			var productsGrid = this.containerElement.FindElement(By.XPath(".//table"), 2);
			if (productsGrid == null)
			{
				return 0;
			}

			return productsGrid.FindElements(By.XPath(".//tbody/tr"), 2).Count;
		}

		public bool FilterOptionShowingCorrectly(string option, string colourExpected)
		{
			var allFilters = this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
			var requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
			if (requiredFilter == null)
			{
				return false;
			}
			// So the filter exists, now we check the colour

			var colourShowingRaw = requiredFilter.GetCssValue("border-bottom-color");
			var colourShowing = "";

			switch (colourShowingRaw)
			{
				case ("rgba(160, 137, 179, 1)"):
					colourShowing = "Light Purple";
					break;
				case ("rgba(239, 157, 14, 1)"):
					colourShowing = "Yellow";
					break;
				case ("rgba(0, 152, 255, 1)"):
					colourShowing = "Blue";
					break;
				case ("rgba(30, 143, 31, 1)"):
					colourShowing = "Green";
					break;
				case ("rgba(75, 82, 87, 1)"):
					colourShowing = "Dark Grey";
					break;
				case ("rgba(207, 58, 83, 1)"):
					colourShowing = "Red";
					break;
			}

			return (colourShowing == colourExpected);

		}

		public bool ClickFilterOption(string option)
		{
			try
			{
				var allFilters = this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
				var requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
				if (requiredFilter == null)
				{
					return false;
				}

				requiredFilter.Click();
				GeneralUtilities.Wait_for_load_finish();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool MoreFiltersOptionPresent()
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2) != null;
		}

		public bool ProductIdNameFieldPresent()
		{
			return this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2) != null;
		}

		public bool BulkActionsOptionPresent()
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'Bulk Actions')]"), 2) != null;
		}

		public void Click_BulkActions()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'Bulk Actions')]"), 2).Click();
		}

		public bool GridHeaderShowing(string header)
		{
			var allGridHeaders = this.containerElement.FindElements(By.XPath(".//table//th"), 2);
			return allGridHeaders.Select(x => x.Text.Trim()).Contains(header);
		}

		public string GetIdInFirstGridRow()
		{
			return this.containerElement.FindElement(By.XPath(".//tbody//tr/td[1]//small"), 2).Text;
		}

		public bool NavigateToNextPage()
		{
			var el = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'panel-footer')]//li/a[contains(@class,'next')]"), 2);
			if (el == null)
			{
				return false;
			}

			el.Click();
			return true;
		}

		public string ProductIdField {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2).Text; }
			set
			{
				var el = this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2);
				el.EnterText(value);
				el.SendKeys(Keys.Return);
			}
		}

		public bool ClickActionsForFirstResultInGrid()
		{
			try
			{
				var button = this.containerElement.FindElement(By.XPath(".//table//tbody//tr[1]//button[contains(@class,'ellipsis-button')]"), 2);
				button.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public List<string> ActionsAvailableInDropDown()
		{
			var dropDownContents = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a"), 2);
			if (dropDownContents.Count == 0)
			{
				return null;
			}

			return dropDownContents.Select(x => x.Text.Trim()).ToList();
		}

		public bool ClickRowAction(string action)
		{
			var dropDownContents = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a"), 2);
			if (dropDownContents.Count == 0)
			{
				return false;
			}

			var el = dropDownContents.FirstOrDefault(x => x.Text.Trim() == action);
			if (el == null)
			{
				return false;
			}

			el.Click();
			return true;
		}

		public ProductGridItem FirstProductInGrid()
		{
			var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);

			var productElement = new ProductGridItem();
			productElement.ProductId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim();
			productElement.ProductName = productRow.FindElement(By.XPath(".//div/p"), 2).Text.Trim();
			productElement.DateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim();
			return productElement;
		}
	}

	public class ProductGridItem
	{
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public string DateCreated { get; set; }
	}

	class BulkActions : BaseObject
	{
		// Really rubbish identifier - but it's the best we have at the moment!
		public const string BasePath = "//h3[text()='Bulk Actions']/../..";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public List<string> OptionsAvailable()
		{
			return this.containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).Select(x => x.Text.Trim().Replace("\r\n", " ")).ToList();
		}

		public bool OptionChangesOnHover(string option)
		{
			var el = this.containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).FirstOrDefault(x => x.Text.Trim().Replace("\r\n", " ") == option);
			return el.HoveringChangesColour();
		}

		public bool ClickOption(string option)
		{
			try
			{
				var el = this.containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).FirstOrDefault(x => x.Text.Trim().Replace("\r\n", " ").Contains(option));
				if (el == null)
				{
					return false;
				}

				el.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void ClickClose()
		{
			this.containerElement.FindElement(By.XPath(".//button[@class='close']"), 2).Click();
		}
	}

	class DeleteDialog : BaseObject
	{
		public const string BasePath = "//h3[text()='Delete Product']/../..";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void ClickDelete()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Delete']"), 2).Click();
		}

		public void ClickCancel()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Cancel']"), 2).Click();
		}
	}

	/// <summary>
	/// Bulk Actions - Sync ULSC Products dialog
	/// </summary>
	class SyncULSCProductsDialog : BaseObject
	{
		public const string BasePath = "//h3[text()='Sync Products to ULSC']/../..";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		/// <summary>
		/// this is the title of the dialog Sync Products to ULSC
		/// </summary>
		/// <returns></returns>
		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//h3"), 2).Text.Trim();
		}

		/// <summary>
		/// clicks the sync all button on the ulsc sync popup
		/// </summary>
		public void ClickSyncAll()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Sync All']"), 2).Click();
		}

		/// <summary>
		/// clicks the cancel button on the ulsc sync popup
		/// </summary>
		public void ClickCancel()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Cancel']"), 2).Click();
		}
	}
}

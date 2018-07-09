using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
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

		public bool ClickMoreFilters()
		{
			return containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2).TryClick();
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
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2).GetValue(); }
			set
			{
				var el = this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2);
				el.EnterText(value);
				el.SendKeys(Keys.Return);
				GeneralUtilities.Wait_for_load_finish();
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

		public bool ClickActions(int row)
		{
			return containerElement.FindElement(By.XPath(".//table//tbody//tr[" + row + "]//button[contains(@class,'ellipsis-button')]"), 2).TryClick();

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

		public bool RowsAreFoundInProductGrid()
		{
			try
			{
				var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);
				return (productRow != null);
			}
			catch (Exception e)
			{
				return false;
				throw;
			}
		}

		public string UpcNumber {
			get
			{
				var el = containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']"), 2);
				return el == null ? "" : el.GetValue();
			}
			set
			{
				var el = containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']"), 2);
				if (el == null)
				{
					Report.Error("UPC Number field could not be found!");
					return;
				}
				el.EnterText(value);
			}
		}

		public bool ClickUpcNumberSearchButton()
		{
			var el = containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in UPC Field could not be found!");
				return false;
			}

			return el.TryClick();
		}

		public bool ClickProductIdNameSearchButton()
		{
			var el = containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID/ Name']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in UPC Field could not be found!");
				return false;
			}

			return el.TryClick();
		}

		public bool DeleteAllPresentRows()
		{
			var rows = containerElement.FindElements(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
			if (rows.Count == 0)
			{
				Report.Info("No rows were found to delete!");
				return true;
			}

			foreach (var row in rows)
			{
				var toggleButton = row.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 2);
				if (toggleButton == null)
				{
					continue;
				}

				if (toggleButton.TryClick())
				{
					var deleteButton = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[contains(text(),'Delete')]"), 2);
					if (deleteButton.TryClick())
					{
						var delDialog = new DeleteDialog();
						delDialog.Wait_for_load();
						delDialog.ClickDelete();
						GeneralUtilities.Wait_for_load_finish();
					}
				}
			}

			return true;
		}

		public bool DeleteFirstRow()
		{
			var row = containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);

			var toggleButton = row.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 2);

			if (toggleButton.TryClick())
			{
				var deleteButton = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[contains(text(),'Delete')]"), 2);
				if (deleteButton.TryClick())
				{
					var delDialog = new DeleteDialog();
					delDialog.Wait_for_load();
					delDialog.ClickDelete();
					GeneralUtilities.Wait_for_load_finish();
				}
			}

			return true;
		}

		public string ActivePage()
		{
			var el = containerElement.FindElement(By.XPath(".//li[@class='active']/span"), 2);
			if (el == null)
			{
				return null;
			}
			//el.ScrollElementIntoView();
			return el.Text;
		}

		public bool GridNavigation(string navOption)
		{
			Report.Info("Navigating in the products grid with action - " + navOption);
			RefreshContainer();
			IWebElement navEl;
			switch (navOption)
			{
				case "next":
					navEl = containerElement.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
					break;
				case "previous":
					navEl = containerElement.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
					break;
				case "...":
					navEl = containerElement.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
					break;
				default:
					Report.Info("An invalid navigation option was provided. Must either be 'next' or 'previous'");
					return false;
			}
			if (navEl == null)
			{
				Report.Info("Could not locate the navigation button element for: " + navOption);
				return false;
			}
			//navEl.ScrollElementIntoView();
			return navEl.TryClick();
		}

		public IWebElement GridNavigationInput()
		{
			return containerElement.FindElement(By.XPath(".//input[@type='number']"), 2);
		}

		public bool GridNavigationInputDisplayed()
		{
			if (GridNavigationInput() == null)
			{
				GridNavigation("...");
			}
			return GridNavigationInput() != null;
		}

		public void KeyToGridNavigationInput(string action)
		{
			var inputEl = GridNavigationInput();
			if (inputEl == null)
			{
				GridNavigation("...");
				inputEl = GridNavigationInput();
			}
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return;
			}
			switch (action)
			{
				case "up":
					inputEl.SendKeys(Keys.ArrowUp);
					break;
				case "down":
					inputEl.SendKeys(Keys.ArrowDown);
					break;
				case "enter":
					inputEl.SendKeys(Keys.Enter);
					break;
				default:
					Report.Failure("The action requested was beyond those specified: 'up', 'down', or 'enter'");
					break;
			}
		}

		public void NumToGridNavigationInput(string pageNumber)
		{
			try
			{
				var inputEl = GridNavigationInput();
				if (inputEl == null)
				{
					Report.Failure("The navigation input box could not be found");
					return;
				}

				inputEl.EnterText(pageNumber);
			}
			catch (StaleElementReferenceException)
			{
				this.RefreshContainer();
				GridNavigation("...");
				GridNavigationInput().EnterText(pageNumber);
			}

		}

		public string CurrentPageGridNavigationInput()
		{
			var inputEl = GridNavigationInput();
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return null;
			}
			return inputEl.GetAttribute("value");
		}

		public bool RefreshContainer()
		{
			containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return containerElement != null;
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

		public bool ClickDelete()
		{
			return containerElement.FindElement(By.XPath(".//button[text()='Delete']"), 2).TryClick();
		}

		public bool ClickCancel()
		{
			return containerElement.FindElement(By.XPath(".//button[text()='Cancel']"), 2).TryClick();
		}

		public string ItemRemovedText()
		{
			var itemName = containerElement.FindElement(By.XPath(".//strong[@data-bind='text:itemObj.Name']"), 2);
			var itemID = containerElement.FindElement(By.XPath(".//span[@data-bind='text:itemObj.ProductID']"), 2);
			if (itemName == null || itemID == null)
			{
				return null;
			}
			return itemName.Text + "(" + itemID.Text + ")";
		}
	}

	/// <summary>
	/// Bulk Actions - Sync ULSC Products dialog
	/// </summary>
	class SyncUlscProductsDialog : BaseObject
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

	class MoreFilters : ProductsGrid
	{
		public List<string> Options(string filter)
		{
			IWebElement el;
			switch (filter)
			{
				case "Brand":
					el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
					if (el == null)
					{
						return new List<string>();
					}
					return el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "All Brands").ToList();
				case "Retailer":
					el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
					if (el == null)
					{
						return new List<string>();
					}
					return el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "All Retailers").ToList();
				case "Additional Programs":
					el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
					if (el == null)
					{
						return new List<string>();
					}
					return el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "None").ToList();
				default:
					return new List<string>();
			}
		}
		public string Brand {
			get
			{
				var el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
				return el == null ? null : el.SelectedOption();
			}
			set
			{
				var el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
				el?.Select(value);
			}
		}
		public string Retailer {
			get
			{
				var el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
				return el == null ? null : el.SelectedOption();
			}
			set
			{
				var el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
				el?.Select(value);
			}
		}
		public string AdditionalPrograms {
			get
			{
				var el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
				return el == null ? null : el.SelectedOption();
			}
			set
			{
				var el = containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
				el?.Select(value);
			}
		}
	}
}

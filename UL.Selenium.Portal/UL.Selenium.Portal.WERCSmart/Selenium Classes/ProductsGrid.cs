using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class ProductsGrid : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='products-grid']");

		#region web elements

		private IWebElement GridNavigationInput() => this.containerElement.FindElement(By.XPath(".//input[@type='number']"), 2);

		private IWebElement ProductTable => this.containerElement.FindElement(By.XPath(".//table[contains(@class, 'products-table')]"), 1);

		private List<IWebElement> ProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody/tr"), 1).ToList();

		private IWebElement ProductsHeading => this.containerElement.FindElement(By.XPath("./h2[contains(@class,'title')]"), 1);

		private List<IWebElement> ProductTableHeadings => this.ProductTable.FindElements(By.XPath(".//th"), 2).ToList();

		#endregion

		public string HeadingText => this.ProductsHeading?.Text;

		public bool HeadingShowing() => this.ProductsHeading != null;

		public bool ProductsPresent() => this.ProductRows != null && this.ProductRows.Count > 0;

		public int ProductsCount()
		{
			var productRows = this.ProductRows;
			if (productRows == null || !productRows.Any())
			{
				return 0;
			}
			return productRows.Count(x => x.Displayed);
		}

		public string GetIdInFirstGridRow() => this.ProductRows.FirstOrDefault()?.FindElement(By.XPath(".//small"), 2)?.Text;

		public List<string> GetAllFilters()
		{
			return this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"))
				.Select(x => x.Text).ToList();
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

		public bool ClickStatusFilter(string option)
		{
			var allFilters = this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
			var requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
			return requiredFilter.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool MoreFiltersOptionPresent()
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2) != null;
		}

		public bool ClickMoreFilters()
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2).TryClick();
		}

		public bool MoreFiltersExpanded()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2);
			var expandedAttr = el?.GetAttribute("aria-expanded");
			bool.TryParse(expandedAttr, out bool result);
			return expandedAttr != null && result;
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

		public bool GridHeaderShowing(string header) => this.ProductTableHeadings.Select(x => x.Text.Trim()).Contains(header);

		public List<string> AllIDsInGrid()
		{
			return this.containerElement.FindElements(By.XPath(".//tbody//tr/td//small"), 2).Select(x => x.Text).ToList();
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
				var button = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath(".//button[contains(@class,'ellipsis-button')]"), 1);
				return button.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickActions(int row)
		{
			return this.containerElement.FindElement(By.XPath(".//table//tbody//tr[" + row + "]//button[contains(@class,'ellipsis-button')]"), 2).TryClick();

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
			return el.TryClick();
		}

		public string GetFirstProductIDNotNeedsAttention()
		{
			var productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (var row in productRows)
			{
				if (row.FindElement(By.XPath(".//li[@class='abr']"), 2) != null)
				{
					return row.FindElement(By.XPath(".//small"), 2)?.Text.Trim();
				}
			}

			return null;
		}

		public ProductGridItem FirstProductInGrid()
		{
			if (this.containerElement.FindElements(By.XPath(".//tbody/tr")).Count == 0)
			{
				Report.Error("No rows have been found!");
				return null;
			}
			Delay.Seconds(5);
			var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);
			if (productRow == null || !productRow.Displayed)
			{
				return null;
			}
			var productId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim();
			var dateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim();
			var retailers = new List<string>();
			var retailersAbrv = new List<string>();
			var retailersLi = productRow.FindElements(By.XPath(".//li")).Where(x => x.Displayed);

			foreach (var retailerLi in retailersLi)
			{
				var retailerLiButton = retailerLi.FindElement(By.XPath("./button"), 2);
				if (!retailerLi.GetAttribute("title").IsNullOrEmpty())
				{
					retailers.Add(retailerLi.GetAttribute("title")?.Trim());
				}
				else if (retailerLiButton != null && !retailerLiButton.GetAttribute("title").IsNullOrEmpty())
				{
					retailers.Add(retailerLiButton.GetAttribute("title")?.Trim());
				}
				else
				{
					retailers.Add(retailerLi.GetAttribute("data-original-title")?.Trim());
				}
				retailersAbrv.Add(retailerLi.Text.Trim());
			}
			var labelBrandTag = productRow.FindElement(By.XPath(".//div/p/span"), 2);
			var productElement = new ProductGridItem() {
				ProductId = productId,
				ProductName = labelBrandTag != null ?
					productRow.FindElement(By.XPath(".//div/p"), 2).Text.TrimEnd(labelBrandTag.Text.ToCharArray()).Trim() :
					productRow.FindElement(By.XPath(".//div/p"), 2).Text.Trim(),
				DateCreated = dateCreated,
				Retailers = retailers,
				RetailerAbrv = retailersAbrv,
				NameLabel = labelBrandTag?.Text
			};
			return productElement;
		}

		public bool SelectShowArchivedRetailers()
		{
			var inputShowArchivedRetailers =
				this.containerElement.FindElement(By.XPath(".//input[@id='show-archived-retailers']"), 3);
			if (inputShowArchivedRetailers == null)
			{
				Report.Info("Could not find show archived retailers input box to click");
				return false;
			}

			return inputShowArchivedRetailers.TryCheck();
		}

		public bool DeselectShowArchivedRetailers()
		{
			var inputShowArchivedRetailers =
				this.containerElement.FindElement(By.XPath(".//input[@id='show-archived-retailers']"), 3);
			if (inputShowArchivedRetailers == null)
			{
				Report.Info("Could not find show archived retailers input box to click");
				return false;
			}

			return inputShowArchivedRetailers.TryCheck(false);
		}

		public ProductGridItem FirstProductInGridWithRetailers()
		{
			if (this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2).Count == 0)
			{
				Report.Error("No rows have been found!");
				return null;
			}
			var productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (var row in productRows)
			{
				if (row.FindElement(By.XPath(".//ul[@class='list-inline retailers']/li"), 2) == null)
				{
					continue;
				}
				var productElement = new ProductGridItem { ProductId = row.FindElement(By.XPath(".//small"), 2).Text.Trim(), ProductName = row.FindElement(By.XPath(".//div/p"), 2).Text.Trim(), DateCreated = row.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim(), Retailers = row.FindElements(By.XPath(".//li")).Where(x => x.Displayed).Select(x => x.Text).ToList() };
				return productElement;
			}
			return null;
		}

		public List<ProductGridItem> GetAllItemsInGrid()
		{
			if (this.containerElement.FindElements(By.XPath(".//tbody/tr")).Count == 0)
			{
				Report.Error("No rows have been found!");
				return null;
			}

			List<ProductGridItem> ListProductGridItems = new List<ProductGridItem>();
			var productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (var row in productRows)
			{
				if (row.FindElement(By.XPath(".//ul[@class='list-inline retailers']/li[contains(@class,'abr')]"), 2) != null)
				{
					var productRow = row;
					if (productRow == null || !productRow.Displayed)
					{
						return null;
					}
					var labelBrandTag = productRow.FindElement(By.XPath(".//div/p/span"), 2);
					var productElement = new ProductGridItem() {
						ProductId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim(),
						ProductName = labelBrandTag != null ?
							productRow.FindElement(By.XPath(".//div/p"), 2).Text.TrimEnd(labelBrandTag.Text.ToCharArray()).Trim() :
							productRow.FindElement(By.XPath(".//div/p"), 2).Text.Trim(),
						DateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim(),
						Retailers = productRow.FindElements(By.XPath(".//li")).Where(x => x.Displayed).Select(x => x.Text).ToList(),
						NameLabel = labelBrandTag?.Text
					};
					ListProductGridItems.Add(productElement);

				}
			}
			return ListProductGridItems;
		}

		public ProductGridItem ProductInRow(int row)
		{
			var productRow = this.containerElement.FindElement(By.XPath($".//tbody/tr[{row}]"), 2);
			if (productRow == null || !productRow.Displayed)
			{
				return null;
			}

			var thisProduct = new ProductGridItem() {
				ProductId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim(),
				ProductName = productRow.FindElement(By.XPath(".//div/p"), 2).Text.Trim(),
				DateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim(),
				Retailers = productRow.FindElements(By.XPath(".//li")).Where(x => x.Displayed).Select(x => x.Text).ToList()
			};
			return thisProduct;
		}

		public bool RowsAreFoundInProductGrid()
		{
			try
			{
				var productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);
				return (productRow != null);
			}
			catch (Exception)
			{
				return false;
				throw;
			}
		}

		public string UpcNumber {
			get
			{
				var el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']"), 2);
				return el == null ? "" : el.GetValue();
			}
			set
			{
				var el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']"), 2);
				if (el == null)
				{
					Report.Error("UPC Number field could not be found!");
					return;
				}

				el.EnterText(value);
			}
		}

		public bool ClickClear()
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(@class,'clear-filters')]"), 2).TryClick();
		}

		public bool ClickUpcNumberSearchButton()
		{
			var el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in UPC Field could not be found!");
				return false;
			}

			return el.TryClick();
		}

		public bool ClickProductIdNameSearchButton()
		{
			var el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID/ Name']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in UPC Field could not be found!");
				return false;
			}

			return el.TryClick();
		}

		public bool DeleteAllPresentRows()
		{
			var rows = this.containerElement.FindElements(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
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
						delDialog.WaitForContainerToBeVisible();
						delDialog.ClickDelete();
						GeneralUtilities.Wait_for_load_finish();
					}
				}
			}

			return true;
		}

		public bool DeleteFirstRow()
		{
			var row = this.containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
			var toggleButton = row.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 2);
			if (toggleButton.TryClick())
			{
				var deleteButton = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[contains(text(),'Delete')]"), 2);
				if (deleteButton == null)
				{
					Report.Info("Failed to find 'delete' element");
					return false;
				}
				if (deleteButton.TryClick())
				{
					var delDialog = new DeleteDialog();
					delDialog.WaitForContainerToBeVisible();
					if (delDialog.ClickDelete())
					{
						Report.Info("Clicked 'delete'");
						Delay.Seconds(5);
						GeneralUtilities.Wait_for_load_finish();
						Delay.Seconds(1);
						Report.Info("Checking the products grid is empty");
						row = this.containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
						return row == null;
					}
					Report.Info("Failed to click 'Delete' in popup dialog");
					return false;
				}
				Report.Info("Failed to click delete button from row actions");
				return false;
			}
			Report.Info("Failed to click actions dropdown button");
			return false;
		}

		public string ActivePage()
		{
			var el = this.containerElement.FindElement(By.XPath(".//li[@class='active']/span"), 2);
			return el?.Text;
		}

		public string LastPage()
		{
			var lastControl = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[@class='page-link']"), 2);
			if (lastControl.Count == 0)
			{
				Report.Info("Last page is: 1");
				return "1";
			}

			return lastControl.Last().Text;
		}

		public bool ClickPage(string page)
		{
			if (this.ActivePage() == page)
			{
				return false;
			}

			Report.Info("Clicking page: " + page);
			return this.containerElement.FindElement(By.XPath(".//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
		}

		public bool GridNavigation(string navOption)
		{
			Report.Info("Navigating in the products grid with action - " + navOption);
			IWebElement navEl;
			switch (navOption)
			{
				case "next":
					navEl = this.containerElement.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
					break;
				case "previous":
					navEl = this.containerElement.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
					break;
				case "...":
					navEl = this.containerElement.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
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

		public bool NextDisabled()
		{
			return this.containerElement.FindElement(By.XPath(".//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}

		public bool GridNavigationInputDisplayed()
		{
			if (this.GridNavigationInput() == null)
			{
				this.GridNavigation("...");
			}

			return this.GridNavigationInput() != null;
		}

		public void KeyToGridNavigationInput(string action)
		{
			var inputEl = this.GridNavigationInput();
			if (inputEl == null)
			{
				this.GridNavigation("...");
				inputEl = this.GridNavigationInput();
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

		public bool NumToGridNavigationInput(string pageNumber)
		{
			try
			{
				var inputEl = this.GridNavigationInput();
				if (inputEl == null)
				{
					Report.Info("The Num input was not displayed. Clicking the '...' navigation element");
					this.GridNavigation("...");
					inputEl = this.GridNavigationInput();
					if (inputEl == null)
					{
						return false;
					}
					Report.Info("Entering page number: " + pageNumber);
					inputEl.EnterText(pageNumber);
					return true;
				}
				inputEl.EnterText(pageNumber);
				return true;
			}
			catch (Exception ex)
			{
				Report.Info("Exception: " + ex.Message);
				return false;
			}

		}

		public string CurrentPageGridNavigationInput()
		{
			var inputEl = this.GridNavigationInput();
			if (inputEl == null)
			{
				Report.Failure("The navigation input box could not be found");
				return null;
			}

			return inputEl.GetAttribute("value");
		}

		public List<ProductGridItem> GetAllProducts(bool firstPage = false)
		{
			var rList = new List<ProductGridItem>();
			var lastPageText = this.LastPage();
			if (!int.TryParse(lastPageText, out int lastPage))
			{
				return null;
			}

			var activeText = this.ActivePage();
			if (!int.TryParse(activeText, out int activePage))
			{
				return null;
			}

			if (firstPage)
			{

			}

			while (activePage <= lastPage)
			{
				Report.Info("Getting products on page: " + activePage);
				var productCount = this.ProductsCount();
				Report.Info("There are " + productCount + " products on this page");
				for (int i = 1; i <= productCount; i++)
				{
					var thisProduct = this.ProductInRow(i);
					rList.Add(thisProduct);
				}

				if (!this.NextDisabled() && this.GridNavigation("next"))
				{
					Report.Info("Getting produts from the next page");
					GeneralUtilities.Wait_for_load_finish();
					activePage++;
					continue;
				}

				break;
			}

			Report.Info("Returning to the first page in the products grid");
			this.ClickPage("1");
			GeneralUtilities.Wait_for_load_finish();
			return rList;
		}

		public bool ClickFirstActionsEditUpc()
		{
			var lastPageText = this.LastPage();
			if (!int.TryParse(lastPageText, out int lastPage))
			{
				return false;
			}

			var activeText = this.ActivePage();
			if (!int.TryParse(activeText, out int activePage))
			{
				return false;
			}

			bool clicked = false;
			while (activePage <= lastPage)
			{
				Report.Info("Looking for product with 'Edit UPC' Actions on page: " + activePage);
				var el = this.containerElement.FindElement(By.XPath(".//button[contains(@class,'ellipsis')]/following-sibling::ul/li//a[not(@style='display: none;') and text()='Edit UPCs']"), 2);
				if (el == null)
				{
					Report.Info("No Edit UPC actions on page " + activePage + ". Clicking next.");
					if (!this.NextDisabled() && this.GridNavigation("next"))
					{
						GeneralUtilities.Wait_for_load_finish();
						activePage++;
						continue;
					}

					break;
				}

				Report.Info("Clicking More Actions");
				var actionsEl = el.FindElement(By.XPath("./../../preceding-sibling::button"), 2);
				if (actionsEl.TryClick())
				{
					Report.Info("Clicking Edit UPCs");
					clicked = el.TryClick();
					GeneralUtilities.Wait_for_load_finish();
				}

				break;
			}

			if (!clicked)
			{
				Report.Info("Returning to the first page in the products grid");
				this.ClickPage("1");
				GeneralUtilities.Wait_for_load_finish();
				return false;
			}

			return true;
		}


		public string GetRetailersStatusByID(string ID)
		{
			var listOfProducts = this.containerElement.FindElements(By.XPath(".//td//small"));
			var matchingProduct = listOfProducts.FirstOrDefault(x => x.GetValue().Contains(ID));
			if (matchingProduct == null)
			{
				Report.Error("No matching product has been found for ID: " + ID);
				return "";
			}

			var retailerLi =
				matchingProduct.FindElement(By.XPath("../../..//ul[@class='list-inline retailers']/li"), 2);

			if (retailerLi == null)
			{
				Report.Error("No matching retailer colour has been found for ID: " + ID);
				return "";
			}

			string borderColour = retailerLi.GetCssValue("border-color");

			switch (borderColour)
			{
				case "rgb(30, 143, 31)":
					return "Accepted by Retailers";
				case "rgb(239, 157, 14)":
					return "Assessment in Progress";
				case "rgb(75, 82, 87)":
					return "Not Yet Submitted";
				case "rgb(0, 152, 255)":
					return "Sending to Retailers";
				case "rgb(207, 58, 83)":
					return "Needs Your Attention";
				default:
					return "";
			}

		}

		public bool AllRetailersAreShowingStatus(string expectedStatus)
		{
			var listOfRetailers = this.containerElement.FindElements(By.XPath(".//table[contains(@class, 'products-table')]//tr//ul[@class='list-inline retailers']/li"));

			foreach (var thisItem in listOfRetailers)
			{
				string borderColour = thisItem.GetCssValue("border-color");
				string foundStatus = "";
				switch (borderColour)
				{
					case "rgb(30, 143, 31)":
						foundStatus = "Accepted by Retailers";
						break;
					case "rgb(239, 157, 14)":
						foundStatus = "Assessment in Progress";
						break;
					case "rgb(75, 82, 87)":
						foundStatus = "Not Yet Submitted";
						break;
					case "rgb(0, 152, 255)":
						foundStatus = "Sending to Retailers";
						break;
					case "rgb(207, 58, 83)":
						foundStatus = "Needs Your Attention";
						break;
					default:
						foundStatus = "";
						break;
				}

				if (foundStatus != expectedStatus)
				{
					return false;
				}
			}

			return true;
		}

		public bool ClickRetailerFirstRow(string retailer)
		{
			var row = this.containerElement.FindElement(By.XPath("//tbody/tr[position() = 1]"), 2);
			if (row == null)
			{
				Report.Info("No rows were found in the products grid");
				return false;
			}
			if (retailer.ToLower() == "all")
			{
				// NB TryClick seems to refocus the page which closes the popup, so use the standard Click method
				row.FindElement(By.XPath(@"//button[@title='All Retailers']"), 2).Click();
				return true;
			}
			return row.FindElement(By.XPath($@".//li[@title=""{retailer}""]/span"), 2).TryClick();
		}

		public bool RetailerPopupDisplayed()
		{
			Report.Info("Checking if Retailer popup is displayed");
			// The ID is generated every time the popup is opened. Fetch from the button's attribute (only exists when popup is open)
			var popoverId = this.containerElement.FindElement(By.XPath("//li[@class='more-retailers']/button"), 2).GetAttribute("aria-describedby");
			if (popoverId.IsNullOrEmpty())
			{
				return false;
			}
			Report.Info("Popup id is: " + popoverId);
			// Use the ID to find the popup container (if it exists)
			var popover = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id= '" + popoverId + "']"), 2);
			return popover != null;
		}

		public void ClickContainer()
		{
			this.containerElement.Click();
		}
	}

	public class ProductGridItem : ProductsGrid
	{
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public string DateCreated { get; set; }
		public List<string> Retailers { get; set; }
		public List<string> RetailerAbrv { get; set; }

		public string NameLabel { get; set; }
	}

	class BulkActions : SeleniumBaseObject
	{
		// Really rubbish identifier - but it's the best we have at the moment!
		protected override By ContainerElementLocator => By.XPath("//h3[text()='Bulk Actions']/../..");

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

	class DeleteDialog : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//h3[text()='Delete Product']/../..");

		public bool ClickDelete()
		{
			return this.containerElement.FindElement(By.XPath(".//button[text()='Delete']"), 2).TryClick();
		}

		public bool ClickCancel()
		{
			return this.containerElement.FindElement(By.XPath(".//button[text()='Cancel']"), 2).TryClick();
		}

		public string ItemRemovedText()
		{
			var itemName = this.containerElement.FindElement(By.XPath(".//strong[@data-bind='text:itemObj.Name']"), 2);
			var itemID = this.containerElement.FindElement(By.XPath(".//span[@data-bind='text:itemObj.ProductID']"), 2);
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
	class SyncUlscProductsDialog : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//h3[text()='Sync Products to ULSC']/../..");

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
					el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
					if (el == null)
					{
						return new List<string>();
					}

					return el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "All Brands").ToList();
				case "Retailer":
					el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
					if (el == null)
					{
						return new List<string>();
					}

					return el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "All Retailers").ToList();
				case "Additional Programs":
					el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
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
				var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
				return el?.SelectedOption();
			}
			set
			{
				var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
				el?.Select(value);
			}
		}

		public string Retailer {
			get
			{
				var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
				return el == null ? null : el.SelectedOption();
			}
			set
			{
				var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
				el?.Select(value);
			}
		}

		public string AdditionalPrograms {
			get
			{
				var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
				return el?.SelectedOption();
			}
			set
			{
				var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
				el?.Select(value);
			}
		}

		public bool MoreFiltersDisplayed()
		{
			var moreFilters = new List<IWebElement>() {
				this.containerElement.FindElement(By.XPath(".//label[@id='brandAddOn']"), 2),
				this.containerElement.FindElement(By.XPath(".//label[@id='retailerAddOn']"), 2),
				this.containerElement.FindElement(By.XPath(".//label[@id='additionalProgramAddOn']"), 2)
			};
			return moreFilters.All(x => x.Displayed);
		}

		public List<string> MoreFilterLabels()
		{
			return this.containerElement.FindElements(By.XPath(".//div[@id='more-filters-panel']//label")).Select(x => x.Text).ToList();
		}

		public bool SelectBrandByValue(MyBrands.Brand brand)
		{
			var el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
			if (el == null)
			{
				return false;
			}
			el.SelectByValue(brand.ID);
			return el.SelectedOption() == brand.Name;
		}
	}

	class RemoveUpcUpdate : ModalDialog
	{
		public List<string> AlertWarningRows()
		{
			return this.containerElement.FindElements(By.XPath(".//div[@class='alert alert-warning']/p"), 2).Select(x => x.Text).ToList();
		}
	}

}

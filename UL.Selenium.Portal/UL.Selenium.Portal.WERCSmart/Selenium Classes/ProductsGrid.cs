using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Automation.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;


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
			List<IWebElement> productRows = this.ProductRows;
			if (productRows == null || !productRows.Any())
			{
				return 0;
			}
			return productRows.Count(x => x.Displayed);
		}

		public bool ConfirmNameMatches(string name)
		{
			string match = this.GetNameInFirstGridRow().Trim();
			// if product label, strip 'PL' from the name.
			if (match.Contains("PL"))
			{
				match = match.Trim(new char[] { 'P', 'L', ' ' });
			}
			return match == name.Trim();
		}

		public bool ConfirmIsPrivateLabel(string pl)
		{
			string match = this.GetNameInFirstGridRow().Trim();
			if (pl.ToLower().Trim() == "y")
			{
				if (match.Contains("PL"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (match.Contains("PL"))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		public bool ConfirmProductHasRetailer(string retailer)
		{
			return this.GetRetailerInFirstGridRow().Trim() == retailer.Trim();
		}

		public string GetIdInFirstGridRow() => this.ProductRows.FirstOrDefault()?.FindElement(By.XPath(".//small"), 2)?.Text;

		public string GetNameInFirstGridRow() => this.ProductRows.FirstOrDefault()?.FindElement(By.XPath(".//p"), 2)?.Text;

		public string GetRetailerInFirstGridRow() => this.ProductRows.FirstOrDefault()?.FindElement(By.XPath(".//li/span"), 2).Text;

		public List<string> GetAllFilters()
		{
			return this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2)
				.Select(x => x.Text).ToList();
		}

		public bool FilterOptionShowingCorrectly(string option, string colourExpected)
		{
			IList<IWebElement> allFilters = this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
			IWebElement requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
			if (requiredFilter == null)
			{
				return false;
			}
			// So the filter exists, now we check the colour

			string colourShowingRaw = requiredFilter.GetCssValue("border-bottom-color");
			string colourShowing = "";

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
			IList<IWebElement> allFilters = this.containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
			IWebElement requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
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
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2);
			string expandedAttr = el?.GetAttribute("aria-expanded");
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
			IWebElement el = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'panel-footer')]//li/a[contains(@class,'next')]"), 2);
			if (el == null)
			{
				return false;
			}

			el.Click();
			return true;
		}

		public string ProductIdField {
			get => this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2).GetValue();
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2);
				el.EnterText(value);
				el.SendKeys(Keys.Return);
				GeneralUtilities.Wait_for_load_finish();
			}
		}

		public string ProductSkuField {
			get => this.containerElement.FindElement(By.XPath(".//input[@aria-describedby='internalProdIDAddOn']"), 2).GetValue();
			set
			{

				IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@aria-describedby='internalProdIDAddOn']"), 2);

				el.EnterText(value);

				el.SendKeys(Keys.Return);

				GeneralUtilities.Wait_for_load_finish();
			}
		}

		public bool ClickActionsForFirstResultInGrid()
		{
			try
			{
				IWebElement button = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath(".//button[contains(@class,'ellipsis-button')]"), 1);
				return button.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickActionsForProduct(string productId)
		{
			try
			{
				IWebElement button = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath("//td//div//small[contains(text(), '" + productId + "')]/../..//following-sibling::td//div//button[contains(@class, 'ellipsis-button')]"), 1);
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
			IList<IWebElement> dropDownContents = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a"), 2);
			if (dropDownContents.Count == 0)
			{
				return null;
			}

			return dropDownContents.Select(x => x.Text.Trim()).ToList();
		}

		public bool ClickRowAction(string action)
		{
			IList<IWebElement> dropDownContents = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a"), 2);
			if (dropDownContents.Count == 0)
			{
				return false;
			}

			IWebElement el = dropDownContents.FirstOrDefault(x => x.Text.Trim() == action);
			if (el == null)
			{
				return false;
			}
			return el.TryClick();
		}

		public string GetFirstProductIDNotNeedsAttention()
		{
			IList<IWebElement> productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (IWebElement row in productRows)
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
			if (this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2).Count == 0)
			{
				Report.Error("No rows have been found!");
				return null;
			}
			Delay.Seconds(5);
			IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);
			if (productRow == null || !productRow.Displayed)
			{
				return null;
			}
			string productId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim();
			string dateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim();
			var retailers = new List<string>();
			var retailersAbrv = new List<string>();
			IEnumerable<IWebElement> retailersLi = productRow.FindElements(By.XPath(".//li"), 2).Where(x => x.Displayed);

			foreach (IWebElement retailerLi in retailersLi)
			{
				IWebElement retailerLiButton = retailerLi.FindElement(By.XPath("./button"), 2);
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
			IWebElement labelBrandTag = productRow.FindElement(By.XPath(".//div/p/span"), 2);
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
		public bool IsShowArchivedRetailersChecked()
		{
			IWebElement inputShowArchivedRetailers = this.containerElement.FindElement(By.XPath(".//input[@id='show-archived-retailers']"), 3);
			if (inputShowArchivedRetailers == null)
			{
				Report.Info("Could not find show archived retailers input box to check it's status");
				return false;
			}

			return inputShowArchivedRetailers.Checked();
		}

		public bool SelectShowArchivedRetailers()
		{
			IWebElement inputShowArchivedRetailers =
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
			IWebElement inputShowArchivedRetailers =
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
			IList<IWebElement> productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			for (int i = 0; i < productRows.Count; i++)
			{
				IWebElement row = productRows[i];

				//check more than 1 retailer (not just NR)

				IWebElement masterEl = row.FindElement(By.XPath(".//ul[@class='list-inline retailers']"), 2);
				List<IWebElement> nonArchRetailers = masterEl.FindElements(By.XPath(".//li[not(@class='abr archived hidden')]"), 2).ToList();
				if(nonArchRetailers.Count()==1)
				{
					string retailerFound = nonArchRetailers.First().Text;
					if(retailerFound=="NR")
					{
						continue;
					}
				}

				IWebElement retElem = row.FindElement(By.XPath(".//ul[@class='list-inline retailers']/li"), 2);
				if (retElem == null)
				{
					continue;
				}

				string borderColour = retElem.GetCssValue("border-color");
				if (borderColour == "rgb(207, 58, 83)")
				{
					continue;
				}
				var productElement = new ProductGridItem { ProductId = row.FindElement(By.XPath(".//small"), 2).Text.Trim(), ProductName = row.FindElement(By.XPath(".//div/p"), 2).Text.Trim(), DateCreated = row.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim(), Retailers = row.FindElements(By.XPath(".//li"), 2).Where(x => x.Displayed).Select(x => x.Text).ToList() };
				return productElement;
			}
			return null;
		}

		public List<ProductGridItem> GetAllItemsInGrid()
		{
			if (this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2).Count == 0)
			{
				Report.Error("No rows have been found!");
				return null;
			}

			var ListProductGridItems = new List<ProductGridItem>();
			IList<IWebElement> productRows = this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2);
			foreach (IWebElement row in productRows)
			{
				if (row.FindElement(By.XPath(".//ul[@class='list-inline retailers']/li[contains(@class,'abr')]"), 2) != null)
				{
					IWebElement productRow = row;
					if (productRow == null || !productRow.Displayed)
					{
						return null;
					}
					IWebElement labelBrandTag = productRow.FindElement(By.XPath(".//div/p/span"), 2);
					var productElement = new ProductGridItem() {
						ProductId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim(),
						ProductName = labelBrandTag != null ?
							productRow.FindElement(By.XPath(".//div/p"), 2).Text.TrimEnd(labelBrandTag.Text.ToCharArray()).Trim() :
							productRow.FindElement(By.XPath(".//div/p"), 2).Text.Trim(),
						DateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim(),
						Retailers = productRow.FindElements(By.XPath(".//li"), 2).Where(x => x.Displayed).Select(x => x.Text).ToList(),
						NameLabel = labelBrandTag?.Text
					};
					ListProductGridItems.Add(productElement);

				}
			}
			return ListProductGridItems;
		}

		public ProductGridItem ProductInRow(int row)
		{
			IWebElement productRow = this.containerElement.FindElement(By.XPath($".//tbody/tr[{row}]"), 2);
			if (productRow == null || !productRow.Displayed)
			{
				return null;
			}

			var thisProduct = new ProductGridItem() {
				ProductId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim(),
				ProductName = productRow.FindElement(By.XPath(".//div/p"), 2).Text.Trim(),
				DateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim(),
				Retailers = productRow.FindElements(By.XPath(".//li"), 2).Where(x => x.Displayed).Select(x => x.Text).ToList()
			};
			return thisProduct;
		}

		public bool RowsAreFoundInProductGrid()
		{
			try
			{
				IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);
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
				IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']"), 2);
				return el == null ? "" : el.GetValue();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']"), 2);
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

		public bool ClickProductIDIngredientIDSKUSearchButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID, Ingredient ID, SKU']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in Product ID, Ingredient ID, SKU' Field could not be found!");
				return false;
			}

			return el.TryClick();
		}
		public bool ClickUpcNumberSearchButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='UPC Number']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in UPC Field could not be found!");
				return false;
			}

			return el.TryClick();
		}

		public bool ClickProductIdNameSearchButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID/ Name']/..//span[contains(@data-bind,'searchProducts')]"), 2);
			if (el == null)
			{
				Report.Error("Search button in UPC Field could not be found!");
				return false;
			}

			return el.TryClick();
		}

		public bool DeleteAllPresentRows()
		{
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
			if (rows.Count == 0)
			{
				bool rowsFound = false;
				if(rowsFound==false)
				{
					GeneralUtilities.Wait_for_load_finish();
					IList<IWebElement> newrows = this.containerElement.FindElements(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
					if(newrows.Count==0)
					{
						Report.Info("No rows were found to delete! Waiting for 10 seconds");

					}
					else
					{
						Report.Info("Rows were found");
						rowsFound = true;
					}					
				}

				if(rowsFound == false)
				{
					Report.Info("Afterwaiting for loading to finish No rows were found to delete! Moving on.");
					return true;
				}	
				
			}
			rows = this.containerElement.FindElements(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
			foreach (IWebElement row in rows)
			{
				IWebElement toggleButton = row.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 2);
				if (toggleButton == null)
				{
					continue;
				}

				if (toggleButton.TryClick())
				{
					IWebElement deleteButton = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[contains(text(),'Delete')]"), 2);
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
			IWebElement row = this.containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
			IWebElement toggleButton = row.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 2);
			if (toggleButton.TryClick())
			{
				IWebElement deleteButton = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[contains(text(),'Delete')]"), 2);
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
						new DashboardPage().RefreshPageObject();
						Delay.Seconds(10);
						GeneralUtilities.Wait_for_load_finish();
						//Delay.Seconds(3);
						Report.Info("Checking the products grid is empty");
						int x = 0;
						while(x<10)
						{
							var modalD = new ModalDialog();
							if (modalD.ContainerVisible())
							{
								delDialog.ClickDelete();
							}
							row = this.containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
							if(row==null)
							{
								Report.Info($"The products grid was emtpy");
								return true;
							}
							try
							{

								toggleButton = row.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 2);
								toggleButton.TryClick();
								deleteButton = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']//a[contains(text(),'Delete')]"), 10);
								deleteButton.TryClick();
								delDialog.WaitForContainerToBeVisible();
								Delay.Seconds(10);
								GeneralUtilities.Wait_for_load_finish();
								if (modalD.ContainerVisible())
								{
									delDialog.ClickDelete();
								}
								row = this.containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
								if (row == null)
								{
									Report.Info($"The products grid was emtpy");
									return true;
								}

								Report.Info("The products grid was not empty, waiting 10 more seconds and checking again");
								Delay.Seconds(15);
								x++;
							}
							catch
							{
								Report.Info($"Exception thrown during product deletion. Checking to see if product was removed between attempts");
								row = this.containerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]//tbody//tr"), 2);
								if (row == null)
								{
									Report.Info($"The products grid was emtpy");
									return true;
								}
								Report.Info($"The Products grid was still not empty after all attempts");
								return false;
							}

						}

						Report.Info($"The Products grid was still not empty after all attempts");
						return false;						
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
			IWebElement el = this.containerElement.FindElement(By.XPath(".//li[@class='active']/span"), 2);
			return el?.Text;
		}

		public string LastPage()
		{
			IList<IWebElement> lastControl = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[@class='page-link']"), 2);
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
			int i = 0;
			while (i < 6)
			{
				try
				{
					switch (navOption)
					{
						case "next":
							navEl = this.containerElement.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
							break;
						case "previous":
							navEl = this.containerElement.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
							break;
						case "...":
							//navEl = this.containerElement.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
							navEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
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
					if (navOption == "...")
					{
						Report.Info("Attempting to click the '...' button, after scrolling it into view");
						Delay.Seconds(1);
						navEl.ScrollElementIntoView();
						Delay.Seconds(1);
						navEl.ClickLocation();
						if (this.GridNavigationInput() == null)
						{
							return false;
						}
						else
						{
							return true;
						}

					}

					navEl.ScrollElementIntoView();
					Delay.Seconds(1);
					bool clickSuccess = navEl.TryClick();
					Delay.Seconds(1);
					int x = 0;
					while(clickSuccess==false&&x<6)
					{
						navEl.ScrollElementIntoView();
						Delay.Seconds(1);
						clickSuccess = navEl.TryClick();
						Delay.Seconds(1);
						x++;

					}
					return clickSuccess;
				}
				catch (StaleElementReferenceException ex)
				{
					Report.Info("navEl threw a stale element reference exeption");
					i++;
					Delay.Seconds(1);
					Report.Info($"Attempting to Find the navEl: {navOption} if the number of attempts has not exceeded 5");

				}
				catch (Exception ex)
				{
					Report.Info($"Threw an expection of type:{ex.Message}");
					return false;
				}
			}
			return false;

						
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
			IWebElement inputEl = this.GridNavigationInput();
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
			int i = 0;
			while (i < 5)
			{
				try
				{
					IWebElement inputEl = this.GridNavigationInput();
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
						//inputEl.EnterText(pageNumber);
						//inputEl.Clear();
						string text = inputEl.GetAttribute("value");
						int textLength = text.Length;
						int count = 0;
						while (count < textLength)
						{
							inputEl.SendKeys(Keys.Delete);
							count++;
						}
						inputEl.SendKeys(pageNumber);
						return true;
					}
					inputEl.EnterText(pageNumber);
					return true;
				}
				catch (StaleElementReferenceException ex)
				{
					Report.Info("inputEl threw a stale element reference exeption");
					i++;
					Delay.Seconds(1);
					Report.Info($"Attempting to Find the inputEl again if the number of attempts has not exceeded 5");

				}
				catch (Exception ex)
				{
					Report.Info("Exception: " + ex.Message);
					return false;
				}

			}
			return false;


		}

		public string CurrentPageGridNavigationInput()
		{
			IWebElement inputEl = this.GridNavigationInput();
			if (inputEl == null)
			{
				Report.Error("The navigation input box could not be found");
				return null;
			}

			return inputEl.GetAttribute("value");
		}

		public List<ProductGridItem> GetAllProducts(bool firstPage = false)
		{
			Report.Info("Getting all products in the grid");
			var rList = new List<ProductGridItem>();
			string lastPageText = this.LastPage();
			if (!int.TryParse(lastPageText, out int lastPage))
			{
				Report.Error("Failed to get last page as an int!");
				return null;
			}
			Report.Info("There are " + lastPage + " pages of products");
			string activeText = this.ActivePage();
			if (!int.TryParse(activeText, out int activePage))
			{
				Report.Error("Failed to get current page as an int!");
				return null;
			}
			while (activePage <= lastPage)
			{
				Report.Info("Getting products on page: " + activePage);
				try
				{
					int productCount = this.ProductsCount();
					for (int i = 1; i <= productCount; i++)
					{
						ProductGridItem thisProduct = this.ProductInRow(i);
						rList.Add(thisProduct);
					}
					if (!this.NextDisabled() && this.GridNavigation("next"))
					{
						GeneralUtilities.Wait_for_load_finish();
						activePage++;
						continue;
					}
					if (activePage != lastPage)
					{
						Report.Error("Next is disabled but not on the last page of the products grid!");
					}
					break;
				}
				catch (Exception e)
				{
					Report.Error(e.Message);
					throw;
				}
			}
			Report.Info("Returning to the first page in the products grid");
			this.ClickPage("1");
			GeneralUtilities.Wait_for_load_finish();
			return rList;
		}

		public bool ClickFirstActionsEditUpc()
		{
			string lastPageText = this.LastPage();
			if (!int.TryParse(lastPageText, out int lastPage))
			{
				return false;
			}

			string activeText = this.ActivePage();
			if (!int.TryParse(activeText, out int activePage))
			{
				return false;
			}

			bool clicked = false;
			while (activePage <= lastPage)
			{
				Report.Info("Looking for product with 'Edit UPC' Actions on page: " + activePage);
				IWebElement el = this.containerElement.FindElement(By.XPath(".//button[contains(@class,'ellipsis')]/following-sibling::ul/li//a[not(@style='display: none;') and text()='Edit UPCs']"), 2);
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
				IWebElement actionsEl = el.FindElement(By.XPath("./../../preceding-sibling::button"), 2);
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


		public string GetRetailersStatusByID(string anID)
		{
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listOfProducts = this.containerElement.FindElements(By.XPath(".//td//small"));
			IWebElement matchingProduct = listOfProducts.FirstOrDefault(x => x.GetValue().Contains(anID));
			if (matchingProduct == null)
			{
				Report.Error("No matching product has been found for ID: " + anID);
				return "";
			}

			IWebElement retailerLi =
				matchingProduct.FindElement(By.XPath("../../..//ul[@class='list-inline retailers']/li"), 2);

			if (retailerLi == null)
			{
				Report.Error("No matching retailer colour has been found for ID: " + anID);
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
			ReadOnlyCollection<IWebElement> listOfRetailers = this.containerElement.FindElements(By.XPath(".//table[contains(@class, 'products-table')]//tr//ul[@class='list-inline retailers']/li"));

			foreach (IWebElement thisItem in listOfRetailers)
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

		public bool AtLeastOneRetailerPerProductShowingStatus(string expectedStatus)
		{
			ReadOnlyCollection<IWebElement> listOfRows = this.containerElement.FindElements(By.XPath(".//table[contains(@class, 'products-table')]//tr//ul[@class='list-inline retailers']"));
			foreach (var row in listOfRows)
			{

				ReadOnlyCollection<IWebElement> listOfRetailers = row.FindElements(By.XPath(".//li"));
				bool oneExpectedFound = false;
				foreach (IWebElement thisItem in listOfRetailers)
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
						Report.Info($"The retailer was not the expected status");
					}
					else
					{
						Report.Info($"The retailer was in the expected status");
						oneExpectedFound = true;
					}
				}

				if (oneExpectedFound == false)
				{
					Report.Info($"No retailers in row contained the expected status/color...");
					return false;
				}				
			}

			return true;
		}


		public bool ClickRetailerFirstRow(string retailer)
		{
			IWebElement row = this.containerElement.FindElement(By.XPath("//tbody/tr[position() = 1]"), 2);
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
			string popoverId = this.containerElement.FindElement(By.XPath("//li[@class='more-retailers']/button"), 2).GetAttribute("aria-describedby");
			if (popoverId.IsNullOrEmpty())
			{
				return false;
			}
			Report.Info("Popup id is: " + popoverId);
			// Use the ID to find the popup container (if it exists)
			IWebElement popover = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id= '" + popoverId + "']"), 2);
			return popover != null;
		}

		public bool WaitForRetailerPopupToBeDisplayed()
		{
			Report.Info("Checking if Retailer popup is displayed");
			// The ID is generated every time the popup is opened. Fetch from the button's attribute (only exists when popup is open)
			string popoverId = this.containerElement.FindElement(By.XPath("//li[@class='more-retailers']/button"), 2).GetAttribute("aria-describedby");
			if (popoverId.IsNullOrEmpty())
			{
				return false;
			}
			Report.Info("Popup id is: " + popoverId);
			// Use the ID to find the popup container (if it exists)
			int x = 0;
			bool popupdisplayed = false;
			while (x<30&& popupdisplayed==false)
			{
				IWebElement popover = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id= '" + popoverId + "']"), 2);
				popupdisplayed = popover != null;
				x++;
				Delay.Seconds(2);
			}
			return popupdisplayed;
			
		}

		public bool WaitForRetailerPopupToNotBeDisplayed()
		{
			Report.Info("Checking if Retailer popup is displayed");
			// The ID is generated every time the popup is opened. Fetch from the button's attribute (only exists when popup is open)
			string popoverId = this.ContainerElement.FindElement(By.XPath("//li[@class='more-retailers']/button"), 2).GetAttribute("aria-describedby");
			if (popoverId.IsNullOrEmpty())
			{
				return true;
			}
			Report.Info("Popup id is: " + popoverId);
			// Use the ID to find the popup container (if it exists)
			int x = 0;
			bool popupdisplayed = true;
			while (x < 30 && popupdisplayed == true)
			{
				IWebElement popover = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id= '" + popoverId + "']"), 2);
				popupdisplayed = popover != null;
				x++;
				Delay.Seconds(2);
			}
			if (popupdisplayed == true)
			{
				return false;
			}
			else
			{
				return true;
			}
			

		}

		public void ClickContainer()
		{
			this.ContainerElement.ScrollElementIntoView();
			this.ContainerElement.TryClick();
		}

		public bool SelectItemsOnPage(string option)
		{
			try
			{
				IList<IWebElement> ItemsOnPageSelect = this.containerElement.FindElements(By.XPath(".//div[@class='panel-footer clearfix']//select//option"), 2);
				IWebElement match = ItemsOnPageSelect.FirstOrDefault(x => x.GetValue() == option);
				if (match == null)
				{
					Report.Info("Option was not found");
					return false;
				}
				return match.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool GetGridNavDots()
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
				if (el == null)
				{
					Report.Info("Option was not found");
					return false;
				}
				return el.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void ConfirmRetailersMatchInMyProductsSection(string savedAs)
		{
			Delay.Seconds(5);
			string strVersionOfRemainingRetailerNames = Context.GetFromContext("ListOfRemainingRetailerNamesInTextForm").ToString();
			List<string> ListOfRemainingRetailerNamesFromTheUPCPage = strVersionOfRemainingRetailerNames.Split(',').ToList();

			List<string> ListOfRetailersThatWereSupposedToDisplayButDidNot = new List<string>();

			var ProductID = Context.GetFromContext("ProductID");
			IList<IWebElement> ListOfDisplayedAbreviatedRetailerNamesInTheProductGrid = this.FindElements(By.XPath("//small[text()='" + ProductID + "']/../../following-sibling::td/following-sibling::td/following-sibling::td/following-sibling::td//span[@data-bind='text: Identifier']"), 2);


			foreach (string RetailerName in ListOfRemainingRetailerNamesFromTheUPCPage)
			{
				bool foundMatch = false;

				foreach (IWebElement DisplayedRetailerName in ListOfDisplayedAbreviatedRetailerNamesInTheProductGrid)
				{
					if (RetailerName == DisplayedRetailerName.GetValue())
					{
						foundMatch = true;
					}
				}

				if (!foundMatch)
				{
					ListOfRetailersThatWereSupposedToDisplayButDidNot.Add(RetailerName);
				}

			}

			if (ListOfRetailersThatWereSupposedToDisplayButDidNot.Count() > 0)
			{
				Report.Failure("The following retailers: " + ListOfRetailersThatWereSupposedToDisplayButDidNot.ToString() + " did not show in the Product Grid but were supposed to.");
				return;
			}

			Report.Success("All retailers that were supposed to show up in the Product Grid did.");
			return;
		}

		public bool ConfirmYouWouldLikeToDeleteButton()
		{
			IWebElement ConfirmYouWouldLikeToDeleteButton = this.FindElement(By.XPath("//div[@class='modal-footer']//button[@data-bind='click: function(){ resolve(false); }, text: noText']"), 2);
			return ConfirmYouWouldLikeToDeleteButton.TryClick();
		}

		public ProductGridItem FirstProductNotRecertInGrid()
		{
			if (this.containerElement.FindElements(By.XPath(".//tbody/tr"), 2).Count == 0)
			{
				Report.Error("No rows have been found!");
				return null;
			}
			Delay.Seconds(5);

			//IWebElement productRow = this.containerElement.FindElement(By.XPath(".//tbody//tr//li[@class and not(@class='update')]//ancestor::tr"), 2);
			List<IWebElement> productRows = this.containerElement.FindElements(By.XPath(".//tbody//tr[.//li[@class and not(@class='update')]]"), 2).ToList();
			//get all rows in a list of webelements
			//if the first one does not have the archeived tag then go
			//if not try second row in list and so on
			//checking the archieved tag -			
			
			foreach(var row in productRows)
			{
				bool notArchieved = false;
				List<IWebElement> retailersymbolEL = row.FindElements(By.XPath(".//td[5]//ul//li"), 2).ToList();
				foreach (var el in retailersymbolEL)
				{
					string classFound = el.GetAttribute("class");
					Report.Info($"The class for the el was: {classFound}");
					if (el.GetAttribute("class").Contains("archived"))
					{
						notArchieved = false;
						Report.Info("One of the retailers was archived for the product moving to the next row.");
						break;
					}
				}
				if(!notArchieved)
				{

					Report.Info($"The product did not contain any archived retailers, using this product");
					IWebElement productRow = row;
					if (productRow == null || !productRow.Displayed)
					{
						return null;
					}
					string productId = productRow.FindElement(By.XPath(".//small"), 2).Text.Trim();
					string dateCreated = productRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim();
					var retailers = new List<string>();
					var retailersAbrv = new List<string>();
					IEnumerable<IWebElement> retailersLi = productRow.FindElements(By.XPath(".//li"), 2).Where(x => x.Displayed);

					foreach (IWebElement retailerLi in retailersLi)
					{
						IWebElement retailerLiButton = retailerLi.FindElement(By.XPath("./button"), 2);
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
					IWebElement labelBrandTag = productRow.FindElement(By.XPath(".//div/p/span"), 2);
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
			}
			Report.Info($"All Products Found had either archieved retailers or were in recertification");
			return null;

		}

		public int CheckTheAmountOfProductsInProductsGrid()
		{
			IList<IWebElement> productList = this.containerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: products']//tr"), 2);
			return productList.Count;
		}

		public bool ArchiveAlert(string response)
		{
			SeleniumWebDriver.CurrentDriver.WaitForAlert();
			if (response.ToLower() == "ok")
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
			}
			else if (response.ToLower() == "cancel")
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Dismiss();
			}
			return !SeleniumWebDriver.CurrentDriver.WaitForAlert(10);
		}

		public string GetArchiveAlertText()
		{
			if(!SeleniumWebDriver.CurrentDriver.WaitForAlert(30))
			{
				Report.Info($"Alert did not appear!");
				return null;
			}
			string alertTextFound = SeleniumWebDriver.CurrentDriver.GetAlertText();
			return alertTextFound;



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
			IWebElement el = this.containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).FirstOrDefault(x => x.Text.Trim().Replace("\r\n", " ") == option);
			return el.HoveringChangesColour();
		}

		public bool ClickOption(string option)
		{
			try
			{
				IWebElement el = this.containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).FirstOrDefault(x => x.Text.Trim().Replace("\r\n", " ").Contains(option));
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
			IWebElement itemName = this.containerElement.FindElement(By.XPath(".//strong[@data-bind='text:itemObj.Name']"), 2);
			IWebElement itemID = this.containerElement.FindElement(By.XPath(".//span[@data-bind='text:itemObj.ProductID']"), 2);
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
				IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
				return el?.SelectedOption();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
				el?.Select(value);
			}
		}

		public string Retailer {
			get
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
				return el?.SelectedOption();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: retailers"")]"), 2);
				el?.Select(value);
			}
		}

		public string AdditionalPrograms {
			get
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
				return el?.SelectedOption();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: additionalPrograms"")]"), 2);
				el?.Select(value);
			}
		}


		public string ProductIDIngredientIDSKU
		{
			get
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID, Ingredient ID, SKU']"), 2);
				return el == null ? "" : el.GetValue();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID, Ingredient ID, SKU']"), 2);
				if (el == null)
				{
					Report.Error("Product ID, Ingredient ID, SKU field could not be found!");
					return;
				}

				el.EnterText(value);
			}
		}

		public bool ProductIDIngredientIDSKUFieldIsFound()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Product ID, Ingredient ID, SKU']"), 15);
			if (el ==null)
			{
				Report.Info($"el was null");
				return false;
			}
			Report.Info($"el was found");
			return true;
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
			return this.containerElement.FindElements(By.XPath(".//div[@id='more-filters-panel']//label"), 2).Select(x => x.Text).ToList();
		}

		public bool SelectBrandByValue(MyBrands.Brand brand)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(@".//select[contains(@data-bind,""options: productLineModel.productLines"")]"), 2);
			if (el == null)
			{
				return false;
			}
			el.SelectByValue(brand.ID);
			return el.SelectedOption() == brand.Name;
		}

		public bool ClickShowOnlyDiscontinuedProductsCheckbox()
		{
			IWebElement checkBox = this.containerElement.FindElement(By.XPath("//input[@id='show-only-discontinued-products']"), 2);
			return checkBox.TryClick();
		}

		public bool CheckIfProductIsMissing(string wpsID)
		{
			IWebElement product = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@data-bind='text: Product.ProductID'][text()='" + wpsID + "']"), 2);
			if (product == null)
			{ 
				return true;
			}

			return false;

		}

		public class FilterInformation
		{
			public string Name { get; set; }

			public string Id { get; set; }

			public string UPC { get; set; }

			public string Brand { get; set; }


			//public List<string> Retailers { get; set; }
			public string Retailer { get; set; }


			public string AdditionalPrograms { get; set; }


			public string Status { get; set; }


			


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

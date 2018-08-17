using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using iTextSharp.text.pdf;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ProductGrid")]
	class StepsProductGrid
	{
		[StepDefinition(@"I should see an option for (More Filters|Product ID/Name|Bulk Actions)")]
		public void GivenIShouldSeeAnOptionFor(string field)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that option " + field + " is present");
			try
			{
				Report.Info("Checking that option " + field + " is present");
				var selProdGrid = new ProductsGrid();

				switch (field)
				{
					case ("More Filters"):
						Report.IsTrue(selProdGrid.MoreFiltersOptionPresent(), field + " option was not showing as expected!", field + " option was showing as expected!");
						break;
					case ("Product ID/Name"):
						Report.IsTrue(selProdGrid.ProductIdNameFieldPresent(), field + " option was not showing as expected!", field + " option was showing as expected!");
						break;
					case ("Bulk Actions"):
						Report.IsTrue(selProdGrid.BulkActionsOptionPresent(), field + " option was not showing as expected!", field + " option was showing as expected!");
						break;
				}
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the Product Grid should have the following headers:")]
		public void GivenTheProductGridShouldHaveTheFollowingHeaders(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking Product Grid Headers");
			try
			{
				Report.Info("Checking Product Grid Headers");
				var selProdGrid = new ProductsGrid();
				foreach (var row in table.Rows)
				{ Report.IsTrue(selProdGrid.GridHeaderShowing(row["Header"]), "Header " + row["Header"] + " was not showing as expected!", "Header " + row["Header"] + " was showing as expected!"); }
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I can navigate between pages using the pagniation buttons at the bottom of the grid")]
		public void GivenICanNavigateBetweenPagesUsingThePagniationButtonsAtTheBottomOfTheGrid()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking Pagniation");
			try
			{
				Report.Info("Checking Pagniation");
				Report.Info("Getting the first product from the first screen");
				var selProdGrid = new ProductsGrid();
				var firstId = selProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of: '" + firstId + "'");
				Report.Screenshot();
				Report.Info("Clicking the next button");
				selProdGrid.NavigateToNextPage();

				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
				var secondId = selProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of '" + secondId + "' from the next page");
				Report.IsTrue(firstId != secondId, "Product IDs were identical, so pagniation is not working!", "Product IDs are different, so pagination is working");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I search for the first product in the table")]
		public void GivenISearchForTheFirstProductInTheTable()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Searching for First Product In Grid");
			try
			{
				Report.Info("Searching for First Product In Grid");
				Report.Info("Getting the first product from the screen");
				var selProdGrid = new ProductsGrid();
				var firstId = selProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of: '" + firstId + "'");
				Context.AddToContext("SearchedID", firstId);
				selProdGrid.ProductIdField = firstId;
				GeneralUtilities.Wait_for_load_finish();
				Report.Success("Searched for the first element in the grid");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I search for the product saved as: (.*)")]
		public void GivenISearchForTheProductSavedAs(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Searching for Product Saved as " + savedAs);
			try
			{
				Report.Info("Searching for Product Saved as " + savedAs);
				var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
				Report.Info("Searching for product with ID: '" + productToSearch.ProductId + "'");
				var selProdGrid = new ProductsGrid();
				selProdGrid.ProductIdField = productToSearch.ProductId;
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(selProdGrid.ProductsCount() == 1, "No products were returned for ID: '" + productToSearch.ProductId + "'!", "Product was returned!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I clear the Search Criteria")]
		public void ClearSearchCriteria()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clearing Previous Search");
			try
			{
				Report.Info("Clearing Search Criteria");
				var selProdGrid = new ProductsGrid();
				selProdGrid.ProductIdField = "";
				GeneralUtilities.Wait_for_load_finish();
				Report.Success("Cleared Search Criteria");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the Delete Dialog")]
		public void ConfirmDeleteDialog()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirming the delete dialog");
			try
			{
				Report.Info("Confirming the delete dialog");
				var selDeleteConfirm = new DeleteDialog();
				if (!selDeleteConfirm.Wait_for_load())
				{ throw new Exception("Delete Dialog did not load!"); }

				selDeleteConfirm.ClickDelete();
				GeneralUtilities.Wait_for_load_finish();
				Report.Success("Delete confirmed!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I cancel the Delete Dialog")]
		public void CancelDeleteDialog()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Canceling the delete dialog");
			try
			{
				Report.Info("Canceling the delete dialog");
				var selDeleteConfirm = new DeleteDialog();
				if (!selDeleteConfirm.Wait_for_load())
				{ throw new Exception("Delete Dialog did not load!"); }

				selDeleteConfirm.ClickCancel();
				GeneralUtilities.Wait_for_load_finish();
				Report.Success("Delete confirmed!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I (should|should not) see the product returned in the search results")]
		public void ThenIShouldSeeTheProductReturnedInTheSearchResults(string shouldOrNot)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Correct product " + shouldOrNot + " be returned in the search grid");
			try
			{
				Report.Info("Correct product " + shouldOrNot + " be returned in the search grid");
				var searchedId = Context.GetFromContext("SearchedID").ToString();
				Report.Info("ID searched for: '" + searchedId + "'");
				var selProdGrid = new ProductsGrid();
				Report.IsTrue(selProdGrid.ProductsCount() == 1, "More than one entry was found!", "Only one entry was found, as expected!");
				Report.IsTrue(selProdGrid.GetIdInFirstGridRow() == searchedId, "ID returned was not the same as that searched for!", "ID returned was the same as that searched for");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should only see one product in the grid, with Product ID matching that saved as: (.*)")]
		public void IShouldOnlySeeOneProductWithUPC(string savedAs)
		{
			var selProductsGrid = new ProductsGrid();
			var searchID = Context.GetFromContext(savedAs)?.ToString();
			if (searchID == null)
			{
				Report.Failure("Could not find UPC number in context saved as: " + savedAs);
				return;
			}
			var firstID = selProductsGrid.GetIdInFirstGridRow();
			var productsCount = selProductsGrid.ProductsCount();
			Report.IsTrue(productsCount == 1 && firstID == searchID,
				"Product with ID: " + searchID + " was not the only result returned! There were " + productsCount + " products in the grid and the first ID showing was: " + firstID,
				"Product with ID: " + searchID + " was the only result returned as expected");
		}

		[StepDefinition(@"I (should|should not) see products in the Product Grid")]
		public void ProductsPresentInGrid(string shouldOrNot)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Products " + shouldOrNot + " be returned in the search grid");
			try
			{
				Report.Info("Products " + shouldOrNot + " be returned in the search grid");
				var selProdGrid = new ProductsGrid();
				bool productsExpected = shouldOrNot == "should";

				Report.IsTrue((selProdGrid.ProductsCount() != 0) == productsExpected,
					"Results grid " + (productsExpected ? "was not" : "was") + " showing products!",
					"Results grid " + (productsExpected ? "was" : "was not") + " showing products, as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I filter the products by: (All|Not Yet Submitted|Assessment in Progress|Sending to Retailers|Accepted by Retailers|Needs Your Attention)")]
		public void WhenIFilterTheProductsByNotYetSubmitted(string filter)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Filtering Product Grid by " + filter);
			try
			{
				Report.Info("Filtering Product Grid by " + filter);
				var selProdGrid = new ProductsGrid();
				Report.IsTrue(selProdGrid.ClickStatusFilter(filter), "Failed to click filter option: '" + filter + "'", "Successfully filtered grid by: '" + filter + "'");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I save the ProductID and Name of the first Product in the grid as: (.*)")]
		public void SaveFirstProductInGrid(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Saving Product ID and Name of First Product as " + savedAs);
			try
			{
				Report.Info("Saving Product ID and Name of First Product as " + savedAs);
				var selProdGrid = new ProductsGrid();
				var productElement = selProdGrid.FirstProductInGrid();
				Context.AddToContext(savedAs, productElement);
				Report.Success("Got the first Product in Grid (ID: " + productElement.ProductId + ") and saved to: " + savedAs);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click Row Actions for the first product returned")]
		[StepDefinition(@"I click Row Actions for the most recent product returned")]
		public void WhenIClickRowActionsForTheFirstProductReturned()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking 'Row Actions' for first product returned");
			try
			{
				Report.Info("Clicking 'Row Actions' for first product returned");
				var selProdGrid = new ProductsGrid();
				if (selProdGrid.ProductsCount() == 0)
				{
					Report.Failure("No products present! Cannot click Row Actions!");
					return;
				}
				Report.Info("Found products in grid, clicking first action button...");
				Report.IsTrue(selProdGrid.ClickActionsForFirstResultInGrid(), "Failed to click first Action Button!", "Successfully clicked the first Action Button!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the Row Action: (.*)")]
		public void ClickRowAction(string action)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking on Row Action: " + action);
			try
			{
				Report.Info("Clicking on Row Action: " + action);
				var selProdGrid = new ProductsGrid();
				Report.IsTrue(selProdGrid.ClickRowAction(action),
					"Failed to click Row Action: '" + action + "'!",
					"Successfully clicked Row Action: '" + action + "'!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following options")]
		public void ThenIShouldSeeTheFollowingOptions(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - The following Row Actions should show");
			try
			{
				Report.Info("Checking Row Actions");
				var selProdGrid = new ProductsGrid();
				if (selProdGrid.ProductsCount() == 0)
				{
					Report.Failure("No products present! Cannot click examine Row Actions!");
					return;
				}

				var rowActions = selProdGrid.ActionsAvailableInDropDown();
				Report.IsTrue(rowActions != null, "No row actions were found!", "Row actions were found!");

				foreach (var row in table.Rows)
				{ Report.IsTrue(rowActions.Contains(row["Option"].Trim()), row["Option"] + " was not found in the list of Row Actions!", row["Option"] + " was found in the list of Row Actions!"); }

				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click Bulk Actions in the Products Grid")]
		public void GivenIClickBulkActionsInTheProductsGrid()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking Bulk Actions in Products Grid");
			try
			{
				Report.Info("Clicking Bulk Actions in Products Grid");
				var selProdGrid = new ProductsGrid();
				selProdGrid.Click_BulkActions();
				Report.Success("Bulk Actions clicked successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see a popup with header Bulk Actions")]
		public void ThenIShouldSeeAPopupWithHeaderBulkActions()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking Bulk Actions popup appears");
			try
			{
				Report.Info("Checking Bulk Actions popup appears");
				var selBulkActions = new BulkActions();
				selBulkActions.Wait_for_load();
				Report.Success("Bulk Actions window opened successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following options available in the Bulk Actions window")]
		public void ThenIShouldSeeTheFollowingOptionsAvailableInTheBulkActionsWindow(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking Bulk Actions Options");
			try
			{
				Report.Info("Checking Bulk Actions Options");
				var selBulkActions = new BulkActions();
				var availableOptions = selBulkActions.OptionsAvailable();
				foreach (var row in table.Rows)
				{
					if (Report.IsTrue(availableOptions.Contains(row["Options"]), "Option: '" + row["Options"] + "' was not found in the actions list!", "Option: '" + row["Options"] + "' was found in the list of actions!"))
					{ Report.IsTrue(selBulkActions.OptionChangesOnHover(row["Options"]), "Option '" + row["Options"] + "' did not alter when hovered over!", "Option '" + row["Options"] + "' changed on hover as expected!"); }
				}

				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click (Forward Product Registration|Sync Products|Accept Documents|Download Reports|Delete Products) in the Bulk Actions window")]
		public void GivenIClickForwardProductRegistrationInTheBulkActionsWindow(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking " + option + " in the Bulk Actions window");
			try
			{
				Report.Info("Clicking " + option + " in the Bulk Actions window");
				var selBulkActions = new BulkActions();
				Report.IsTrue(selBulkActions.ClickOption(option), "Failed to click option: '" + option + "'", "Successfully clicked option: '" + option + "'");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Clicking the x to close the Bulk Actions popup
		/// </summary>
		[StepDefinition(@"I click on the close button on Bulk Actions")]
		public void ClickCloseOnBulkActions()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the close button");
			var selBulkActions = new BulkActions();
			selBulkActions.ClickClose();

			Report.Success("close button clicked! on the homepage");
		}

		/// <summary>
		/// Clicking the cancel on the uslc sync popup
		/// </summary>
		[StepDefinition(@"I click on the cancel button on the ULSC Sync popup")]
		public void ClickCancelUlscSyncPopup()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the cancel button");
			var selUlscSyncPopup = new SyncUlscProductsDialog();
			selUlscSyncPopup.ClickCancel();

			Report.Success("cancel button clicked! on the homepage");
		}

		/// <summary>
		/// This is to verify the title of the page
		/// </summary>
		/// <param name="headerExpected"></param>
		[StepDefinition(@"I should see the header: (.*) on the Sync Products to ULSC window")]
		public void CorrectHeaderShowing(string headerExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Sync Products to ULSC window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Sync Products to ULSC window appears");
				var selUlscSyncPopup = new SyncUlscProductsDialog();
				var showing = selUlscSyncPopup.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Sync Products to ULSC header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Sync Products to ULSC header was showing '" + headerExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"I generate a random UPC number and save as: (.*)")]
		public void GivenIGenerateARandomUPCNumberAndSaveAs(string savedAs)
		{
			string uPCNo = GlobalFunctions.GenerateUPCNumber();
			Context.AddToContext(savedAs, uPCNo);
			Report.Info("Generated UPC No: " + uPCNo);
		}


		[StepDefinition(@"I delete all products with (UPC Number): (.*)")]
		public void DeleteAllProductsMatchingCriteria(string option, string value)
		{
			var productGrid = new ProductsGrid();
			if (Report.IsTrue(productGrid.ClickMoreFilters(), "Failed to click the 'More Filters' option in the product grid", "Successfully clicked the 'More Filters' option in the product grid!", false, false))
			{
				switch (option)
				{
					case ("UPC Number"):
						{
							if (value.ToLower().Contains("saved as"))
							{
								value = Context.GetFromContext(value.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
									.ToString();
							}
							productGrid.UpcNumber = value;
							if (!Report.IsTrue(productGrid.UpcNumber == value, "Value: " + value + " was not inputted into the " + option + " field correctly!", "Value: " + value + " was correctly inputted into the " + option + " field", false, false))
							{
								// Return so that we don't start removing all elements in the datagrid!
								return;
							}

							if (!Report.IsTrue(productGrid.ClickUpcNumberSearchButton(), "Failed to click the UPC Search button!", "Successfully clicked the UPC Search button!", false, false))
							{
								// Again, return just in case we don't have the correct results in the search grid!
								return;
							}

							GeneralUtilities.Wait_for_load_finish();
							break;
						}
				}

				Report.Info("Attempting to delete all matching products");
				Report.Screenshot();
				// Assume that the options have been inputted successfully!
				Report.IsTrue(productGrid.DeleteAllPresentRows(), "Failed to delete all products!", "All matching products deleted successfully!");
			}
		}

		[StepDefinition(@"I delete the product: (.*)")]
		public void ThenIDeleteTheProduct(string savedas)
		{
			var Product = (ProductInformation)Context.GetFromContext(savedas);
			Report.Info("Attempting to delete: " + Product.Name);
			var ProductGrid = new ProductsGrid();
			ProductGrid.ProductIdField = Product.Id;
			if (Report.IsTrue(ProductGrid.ProductIdField == Product.Id, "Value: " + Product.Id + " was not inputted into the Product Id field correctly!", "Value: " + Product.Id + " was correctly inputted into the Product Id field", false, false))
			{
				if (Report.IsTrue(ProductGrid.ClickProductIdNameSearchButton(), "Failed to click the search button", "Successfully clicked the search button!", false, false))
				{
					GeneralUtilities.Wait_for_load_finish();
					if (!ProductGrid.RowsAreFoundInProductGrid())
					{

					}
					var firstProduct = ProductGrid.FirstProductInGrid();
					if (Report.IsTrue(firstProduct.ProductName.StartsWith(Product.Name) && firstProduct.ProductId == Product.Id, "First product did not match the required paremeters!", "Product was showing at the top of the grid, as expected!"))
					{
						Report.IsTrue(ProductGrid.DeleteFirstRow(), "Failed to delete product in first row!", "Successfully deleted product in first row!");
					}
				}
			}
		}


		[StepDefinition(@"The current page in the products grid is: (.*)")]
		public void CurrentPageProductsGrid(string expectedPage)
		{
			var currentPage = new ProductsGrid().ActivePage();
			Report.IsTrue(currentPage == expectedPage,
				"The current page in the products grid did not match the expected page",
				"The current page in the products grid matched the expected page");
		}
		[StepDefinition(@"I click (next|previous|...) in the products grid")]
		public void NavigateInProductsGrid(string navOption)
		{
			Report.IsTrue(new ProductsGrid().GridNavigation(navOption),
				"Failed to navigate in the products grid with action: " + navOption,
				"Successfully navigated in the products grid with action: " + navOption);
		}
		[StepDefinition(@"I should see the products grid navigation input with up and down arrows")]
		public void PageInputNumber()
		{
			Report.IsTrue(new ProductsGrid().GridNavigationInputDisplayed(),
				"The products grid page navigation number input was not visible",
				"The products grid page navigation number input was visible as expected");
		}
		[StepDefinition(@"I type the number (.*) into the products grid page navigation box and press the enter key")]
		public void TypeNumberGridNavigationInputAndPressEnter(string pageNum)
		{
			var selProductsGrid = new ProductsGrid();
			Report.Info("Entering text: " + pageNum + " into the user grid page navigation input");
			selProductsGrid.NumToGridNavigationInput(pageNum);
			Report.Info("Pressing the enter key");
			selProductsGrid.KeyToGridNavigationInput("enter");
		}
		[StepDefinition(@"I enter the (up|down) arrow into the products grid page navigation input then the correct page is shown")]
		public void EnterArrowUserGridNavigationBox(string direction)
		{
			var selProductsGrid = new ProductsGrid();
			var pageNavigationValue = selProductsGrid.CurrentPageGridNavigationInput();
			TestReport.StartStep(GlobalParameters.StepCount + " - I enter the " + direction + " arrow into the page navigation box");
			Report.Info("Entering the " + direction + " arrow key to the products grid page navigation input");
			selProductsGrid.KeyToGridNavigationInput(direction);
			Report.Info("Pressing the enter key");
			selProductsGrid.KeyToGridNavigationInput("enter");
			var iteration = direction == "up" ? "increased" : "decreased";
			GlobalParameters.StepCount++;
			TestReport.StartStep(GlobalParameters.StepCount + " - I confirm the page number has " + iteration + " by 1");
			var currentPage = Convert.ToInt32(selProductsGrid.ActivePage());
			int difference = direction == "up" ? 1 : -1;
			Report.IsTrue(currentPage == Convert.ToInt32(pageNavigationValue) + difference,
				string.Format("The active page did not {0} by 1 after entering the '{1}' arrow into the page navigation box at position '{2}'",
					iteration.Remove(iteration.Length - 1), direction, pageNavigationValue),
				string.Format("The active page correctly {0} by 1 after entering the '{1}' arrow into the page navigation box at position '{2}'",
					iteration, direction, pageNavigationValue));
		}

		[StepDefinition(@"I click More Filters in the products grid")]
		public void ClickMoreFilters()
		{
			Report.IsTrue(new ProductsGrid().ClickMoreFilters(),
				"Failed to click 'More Filters' in the products grid",
				"Successfully clicked 'More Filters' in the products grid");
		}

		[StepDefinition(@"I select the (.*) option in the (Brand|Retailer|Additional Programs) More Filters drop down")]
		public void SetMoreFilterOption(string option, string filter)
		{
			var selMoreFilters = new MoreFilters();
			Context.AddToContext("Filter Option", option);
			Report.Info("Selecting option: " + option + " for filter drop down: " + filter);
			if (filter == "Brand")
			{
				selMoreFilters.Brand = option;
				GeneralUtilities.Wait_for_load_finish();
			}
			if (filter == "Retailer")
			{
				selMoreFilters.Retailer = option;
				GeneralUtilities.Wait_for_load_finish();
			}
			if (filter == "Additional Programs")
			{
				selMoreFilters.AdditionalPrograms = option;
				GeneralUtilities.Wait_for_load_finish();
			}
		}



		[StepDefinition(@"I edit the product with ID: (.*)")]
		public void EditFirstProductForRetailer(string id)
		{
			var selProductsGrid = new ProductsGrid();
			selProductsGrid.ProductIdField = id;
			Report.IsTrue(selProductsGrid.ClickActionsForFirstResultInGrid() && selProductsGrid.ClickRowAction("Edit"),
				"Failed to edit the product with ID: " + id,
				"Successfully edited the product with ID: " + id);
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I edit the first product in results")]
		public void EditFirstProductInResults()
		{
			var selProductsGrid = new ProductsGrid();
			Report.IsTrue(selProductsGrid.ClickActionsForFirstResultInGrid() && selProductsGrid.ClickRowAction("Edit"),
				"Failed to edit the first product",
				"Successfully edited first product");
			GeneralUtilities.Wait_for_load_finish();
		}

		[Then(@"A Summary page should open in a new browser tab")]
		public void ThenASummaryPageShouldOpenInANewBrowserTab()
		{
			List<string> OpenBrowsers =
				SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()))
					.ToList();
			for (int i = 0; i < 30; i++)
			{
				OpenBrowsers = SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()))
					.ToList();
				if (OpenBrowsers.Count > 1)
				{
					break;
				}
			}
			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				if (new SummaryPage().Wait_for_load())
				{
					Report.Success("Summary window is showing");
					Report.Screenshot();
					return;
				}
			}

			Report.Failure("Summary window is not showing");
			Report.Screenshot();
		}

		[Then(@"I should not seen an Accept button")]
		public void ThenIShouldNotSeenAnAcceptButton()
		{
			SummaryPage thisSummaryPage = new SummaryPage();
			Report.IsTrue(!thisSummaryPage.ListOfButtons().Contains("Accept"), "Accept button is showing",
				"Accept button is not showing");
		}

		[Given(@"I close the browser tab with the Summary page")]
		public void GivenICloseTheBrowserTabWithTheSummaryPage()
		{
			List<string> OpenBrowsers =
				SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()))
					.ToList();
			for (int i = 0; i < 30; i++)
			{
				OpenBrowsers = SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()))
					.ToList();
				if (OpenBrowsers.Count > 1)
				{
					break;
				}
			}

			foreach (string url in OpenBrowsers)
			{
				SeleniumBrowser.SwitchToTabWithURL(url);
				if (new SummaryPage().Wait_for_load())
				{
					Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close tab with url: " + url,
						"Closed tab with url: " + url);
					return;
				}
			}

			Report.Failure("Did not find Summary page to close");
		}

		[Given(@"I save the number of items in the pie chart")]
		public void GivenISaveTheNumberOfItemsInThePieChart()
		{
			Homepage myHomepage = new Homepage();
			int currentProductCount = myHomepage.PieChartProductsTotal();
			Context.AddToContext("ProductCount", currentProductCount);
			Report.IsTrue(currentProductCount > -1, "Failed to get current product count",
				"Current product count is: " + currentProductCount.ToString());
		}

		[Then(@"the number of items in the pie chart should be one less than the figure I saved")]
		public void ThenTheNumberOfItemsInThePieChartShouldBeOneLessThanTheFigureISaved()
		{
			Homepage myHomepage = new Homepage();
			int currentProductCount = myHomepage.PieChartProductsTotal();
			int savedProductcount = Convert.ToInt16(Context.GetFromContext("ProductCount"));
			Report.IsTrue(currentProductCount == (savedProductcount - 1),
				"Current count is: " + currentProductCount.ToString() + " saved count is: " +
				savedProductcount.ToString(),
				"As expected, current product count (" + currentProductCount.ToString() +
				" is one less than saved count");
		}

		[Given(@"I should see the header: Document Acceptance on the Document Acceptance window")]
		public void GivenIShouldSeeTheHeaderDocumentAcceptanceOnTheDocumentAcceptanceWindow()
		{
			Report.IsTrue(new DocumentAcceptance().Wait_for_load(),
				"Document Acceptance page is not showing as expected.", "Document Acceptance page is showing");
		}

		[Given(@"I should see the header: Delete Active Products on the Delete Active Product window")]
		public void GivenIShouldSeeTheHeaderDeleteActiveProductsOnTheDeleteActiveProductWindow()
		{
			Report.IsTrue(new DeleteActiveProducts().Wait_for_load(),
				"Delete Active Products page is not showing as expected.", "Delete Active Products page is showing");
		}

		[Then(@"I should see the header: Message Center on the Message Center window")]
		public void ThenIShouldSeeTheHeaderMessageCenterOnTheMessageCenterWindow()
		{
			Report.IsTrue(new MessageCenter().Wait_for_load(),
				"Message centre page is not showing as expected.", "Message centre page is showing");
		}

		[StepDefinition(@"I click Row Actions for the first product not in the 'Needs Your Attention' status")]
		public void ClickRowActionsForTheFirstProductNotNeedsYourAttention()
		{
			Report.Info("Getting product ID for first product without the Needs Your Attention status");
			var selProdGrid = new ProductsGrid();
			if (selProdGrid.ProductsCount() == 0)
			{
				Report.Failure("No products present! Cannot click Row Actions!");
				Report.Screenshot();
				return;
			}
			string productID = selProdGrid.GetFirstProductIDNotNeedsAttention();
			if (productID == null)
			{
				Report.Failure("No products were found that were not in the Needs Your Attention status");
				Report.Screenshot();
				return;
			}
			Report.Info("Filtering on product id: " + productID);
			selProdGrid.ProductIdField = productID;
			Report.Info("clicking Actions for first row in the grid");
			Report.IsTrue(selProdGrid.ClickActionsForFirstResultInGrid(), "Failed to click first Action Button!", "Successfully clicked the first Action Button!");
		}

		[StepDefinition(@"I search for UPC number saved as: (.*)")]
		public void SearchForUPCSavedAs(string savedAs)
		{
			var upc = Context.GetFromContext(savedAs)?.ToString();
			if (upc == null)
			{
				Report.Failure("Could not find UPC number in context saved as: " + savedAs);
				return;
			}
			var selProductGrid = new ProductsGrid();
			selProductGrid.UpcNumber = upc;
			if (!Report.IsTrue(selProductGrid.UpcNumber == upc,
				"Value: " + upc + " was not inputted into the UPC field correctly!",
				"Value: " + upc + " was correctly inputted into the UPC field", false, false))
			{
				return;
			}
			if (!Report.IsTrue(selProductGrid.ClickUpcNumberSearchButton(),
				"Failed to click the UPC Search button!",
				"Successfully clicked the UPC Search button!", false, false))
			{
				return;
			}
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I enter combinations of More Filters and should see the product ID: (.*) only for the correct combinations")]
		public void EnterCombinationsOfMoreFilters(string savedAs, Table moreFilters)
		{
			TestReport.UseSubSteps = true;
			var selProductsGrid = new ProductsGrid();
			var selMoreFilters = new MoreFilters();
			var filters = new List<KeyValuePair<string, string>>();
			foreach (var row in moreFilters.Rows)
			{
				filters.Add(new KeyValuePair<string, string>(
					row["Filter"],
					row["Match"]));
			}
			// Cycles through every possible combination of 2 filters
			TestReport.StartStep("I enter combinations of 2 filters selected");
			Report.Info("Testing against reference product with filter values: " + string.Join(", ", filters.Select(x => x.Key + " = " + x.Value).ToList()));
			int N = 4;
			int Q = 2;
			for (int i = 0; i < N - 1; i++)
			{
				// The filter at index i and j are the targets for this action
				// Fix i and iterate j to the end then repeat for i + 1 etc
				for (int j = i + 1; j < N - i; j++)
				{
					var filtersToDo = new List<KeyValuePair<string, string>>{
						filters[i],
						filters[j]};
					// A true match is the filter option which matches the target product
					bool[] match = { true, true };
					int z = 0;
					// For every filter pair, there are 2^Q = 4 combinations of true/false filter options
					// eg. T/T, T/F, F/T, F/F
					for (int k = 0; k < Math.Pow(2, Q); k++)
					{
						// Only expect to see the product returned if every match condition is true
						bool productReturned = match.All(x => x);
						for (int l = 0; l < filtersToDo.Count; l++)
						{
							var filter = filtersToDo[l];
							var filterType = filter.Key;
							var options = filterType == "UPC" ? new List<string> { "0718103888608" } : selMoreFilters.Options(filterType);
							var option = match[l] ? filter.Value : options.First(x => x != filter.Value);
							switch (filterType)
							{
								case "UPC":
									selProductsGrid.UpcNumber = option;
									selProductsGrid.ClickUpcNumberSearchButton();
									break;
								case "Brand":
									selMoreFilters.Brand = option;
									break;
								case "Retailer":
									selMoreFilters.Retailer = option;
									break;
								case "Additional Programs":
									selMoreFilters.AdditionalPrograms = option;
									break;
							}
							Report.Info("I set the " + filterType + " to: " + option);
						}
						GeneralUtilities.Wait_for_load_finish();
						Report.Info("Looking for product ID: " + savedAs);
						Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(savedAs) == productReturned,
							"The product ID: " + savedAs + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
							"The product ID: " + savedAs + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
						Report.Info("Clearing search criteria");
						selProductsGrid.UpcNumber = "";
						selProductsGrid.ClickUpcNumberSearchButton();
						selProductsGrid.ClickClear();
						GeneralUtilities.Wait_for_load_finish();
						// Alternate between flipping the first and second 'match' condition
						z = 1 - z;
						match[z] = !match[z];
					}
				}
			}
			TestReport.StartStep("I enter combinations of 3 filters selected");
			Report.Info("Testing against reference product with filter values: " + string.Join(", ", filters.Select(x => x.Key + " = " + x.Value).ToList()));
			// Cycles through every combination of 3 filters
			Q = 3;
			for (int i = 0; i < N; i++)
			{
				var filtersToDo = filters.Where(x => filters.IndexOf(x) != i).ToList();
				bool[] match = { true, true, true };
				int z = 1;
				int k = 0;
				for (int j = 0; j < Math.Pow(2, Q); j++)
				{
					bool productReturned = match.All(x => x);
					for (int l = 0; l < filtersToDo.Count; l++)
					{
						var filter = filtersToDo[l];
						var filterType = filter.Key;
						var options = filterType == "UPC" ? new List<string> { "0718103888608" } : selMoreFilters.Options(filterType);
						var option = match[l] ? filter.Value : options.First(x => x != filter.Value);
						switch (filterType)
						{
							case "UPC":
								selProductsGrid.UpcNumber = option;
								break;
							case "Brand":
								selMoreFilters.Brand = option;
								break;
							case "Retailer":
								selMoreFilters.Retailer = option;
								break;
							case "Additional Programs":
								selMoreFilters.AdditionalPrograms = option;
								break;
						}
						Report.Info("I set the " + filterType + " to: " + option);
					}
					GeneralUtilities.Wait_for_load_finish();
					Report.Info("Looking for product ID: " + savedAs);
					Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(savedAs) == productReturned,
						"The product ID: " + savedAs + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
						"The product ID: " + savedAs + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
					Report.Info("Clearing search criteria");
					selProductsGrid.UpcNumber = "";
					selProductsGrid.ClickClear();
					GeneralUtilities.Wait_for_load_finish();
					match[k] = !match[k];
					k = k + z;
					z = k % 2 == 0 || k == 0 ? z * -1 : z;
				}
			}
			TestReport.StartStep("I enter combinations of 4 filters selected");
			Report.Info("Testing against reference product with filter values: " + string.Join(", ", filters.Select(x => x.Key + " = " + x.Value).ToList()));
			// Cycles through every combination of 4 filters
			Q = 4;
			for (int i = Q - 1; i < N; i++)
			{
				bool[] match = { true, true, true, true };
				int z = 1;
				int k = 0;
				for (int j = 0; j < Math.Pow(2, Q); j++)
				{
					bool productReturned = match.All(x => x);
					for (int l = 0; l < filters.Count; l++)
					{
						var filter = filters[l];
						var filterType = filter.Key;
						var options = filterType == "UPC" ? new List<string> { "0718103888608" } : selMoreFilters.Options(filterType);
						var option = match[l] ? filter.Value : options.First(x => x != filter.Value);
						switch (filterType)
						{
							case "UPC":
								selProductsGrid.UpcNumber = option;
								break;
							case "Brand":
								selMoreFilters.Brand = option;
								break;
							case "Retailer":
								selMoreFilters.Retailer = option;
								break;
							case "Additional Programs":
								selMoreFilters.AdditionalPrograms = option;
								break;
						}
						Report.Info("I set the " + filterType + " to: " + option);
					}
					GeneralUtilities.Wait_for_load_finish();
					Report.Info("Looking for product ID: " + savedAs);
					Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(savedAs) == productReturned,
						"The product ID: " + savedAs + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
						"The product ID: " + savedAs + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
					Report.Info("Clearing search criteria");
					selProductsGrid.UpcNumber = "";
					selProductsGrid.ClickClear();
					GeneralUtilities.Wait_for_load_finish();
					match[k] = !match[k];
					k = k + z;
					z = k % 3 == 0 || k == 0 ? z * -1 : z;
				}
			}
		}

		[StepDefinition(@"I confirm the product exists with Product ID: (.*) and Name: (.*)")]
		public void ProductExistsWithIDAndName(string id, string name)
		{
			var selProdGrid = new ProductsGrid();
			selProdGrid.ProductIdField = id;
			GeneralUtilities.Wait_for_load_finish();
			var firstProduct = selProdGrid.FirstProductInGrid();
			Report.IsTrue(firstProduct != null && firstProduct.ProductName == name,
				"Product with ID: " + id + " and name: " + name + " was not returned in the product grid",
				"Product with ID: " + id + " and name: " + name + " was returned in the product grid");
			selProdGrid.ProductIdField = "";
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I enter combinations of Status and More Filters and should see the product ID: (.*) only for the correct combinations")]
		public void EnterCombinationsOfStatusAndMoreFilters(string id, Table statusAndFilters)
		{
			var selProductsGrid = new ProductsGrid();
			var selMoreFilters = new MoreFilters();
			var filters = new List<KeyValuePair<string, string>>();
			var statuses = new List<string> {
				"Not Yet Submitted",
				"Assessment in Progress",
				"Sending to Retailers",
				"Accepted by Retailers",
				"Needs Your Attention"
			};
			foreach (var row in statusAndFilters.Rows)
			{
				filters.Add(new KeyValuePair<string, string>(
					row["Filter"],
					row["Match"]));
			}
			var status = filters.FirstOrDefault(x => x.Key == "Status");
			filters.RemoveAll(x => x.Key == "Status");
			for (int i = 0; i < filters.Count; i++)
			{
				var filtersToDo = new List<KeyValuePair<string, string>>{
					status,
					filters[i]};
				bool[] match = { true, true };
				int z = 0;
				// For every filter pair, there are 2^Q = 4 combinations of true/false filter options
				// eg. T/T, T/F, F/T, F/F
				for (int k = 0; k < Math.Pow(2, 2); k++)
				{
					// Only expect to see the product returned if every match condition is true
					bool productReturned = match.All(x => x);
					for (int l = 0; l < filtersToDo.Count; l++)
					{
						var filter = filtersToDo[l];
						var filterType = filter.Key;
						var options = filterType == "Status" ? statuses : selMoreFilters.Options(filterType);
						var option = match[l] ? filter.Value : options.First(x => x != filter.Value);
						switch (filterType)
						{
							case "Status":
								selProductsGrid.ClickStatusFilter(option);
								break;
							case "Brand":
								selMoreFilters.Brand = option;
								break;
							case "Retailer":
								selMoreFilters.Retailer = option;
								break;
							case "Additional Programs":
								selMoreFilters.AdditionalPrograms = option;
								break;
						}
						Report.Info("I set the " + filterType + " to: " + option);
					}
					GeneralUtilities.Wait_for_load_finish();
					Report.Info("Looking for product ID: " + id);
					Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(id) == productReturned,
						"The product ID: " + id + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
						"The product ID: " + id + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
					Report.Info("Clearing search criteria");
					selProductsGrid.ClickStatusFilter("All");
					selProductsGrid.ClickClear();
					GeneralUtilities.Wait_for_load_finish();
					// Alternate between flipping the first and second 'match' condition
					z = 1 - z;
					match[z] = !match[z];
				}
			}
		}

		[StepDefinition(@"the 'More Filters' options (are|are not) displayed")]
		public void TheMoreFiltersOptionsDisplayed(string displayed)
		{
			if (displayed == "are")
			{
				Report.IsTrue(new MoreFilters().MoreFiltersDisplayed(),
					"More Filters options were not displayed when they were expected to be!",
					"More Filters options were displayed as expected");
			}
			if (displayed == "are not")
			{
				Report.IsFalse(new MoreFilters().MoreFiltersDisplayed(),
					"More Filters options were displayed when they were not expected to be!",
					"More Filters options were not displayed as expected");
			}
		}
	}
}

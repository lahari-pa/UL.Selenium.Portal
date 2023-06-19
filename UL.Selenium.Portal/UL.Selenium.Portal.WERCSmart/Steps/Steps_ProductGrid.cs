using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Automation.Reporting.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ProductGrid")]
	public class StepsProductGrid
	{
		[StepDefinition(@"I should see an option for (More Filters|Product ID/Name|Bulk Actions)")]
		public void GivenIShouldSeeAnOptionFor(string field)
		{
			Report.StartStep(Report.Details.StepIndex + $" - Checking that option {field} is present");
			try
			{
				Report.Info($"Checking that option { field } is present");
				var selProdGrid = new ProductsGrid();

				switch (field)
				{
					case ("More Filters"):
						Report.IsTrue(selProdGrid.MoreFiltersOptionPresent(), $"{field} option was not showing as expected!, {field} option was showing as expected!");
						break;
					case ("Product ID/Name"):
						Report.IsTrue(selProdGrid.ProductIdNameFieldPresent(), $"{ field}  option was not showing as expected!", $"{field} option was showing as expected!");
						break;
					case ("Bulk Actions"):
						Report.IsTrue(selProdGrid.BulkActionsOptionPresent(), $"{field} option was not showing as expected!", $"{field} option was showing as expected!");
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
			Report.StartStep(Report.Details.StepIndex + " - Checking Product Grid Headers");
			try
			{
				Report.Info("Checking Product Grid Headers");
				var selProdGrid = new ProductsGrid();
				foreach (TableRow row in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - Checking Pagniation");
			try
			{
				Report.Info("Checking Pagniation");
				Report.Info("Getting the first product from the first screen");
				var selProdGrid = new ProductsGrid();
				string firstId = selProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of: '" + firstId + "'");
				Report.Screenshot();
				Report.Info("Clicking the next button");
				selProdGrid.NavigateToNextPage();

				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
				string secondId = selProdGrid.GetIdInFirstGridRow();
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
			Report.StartStep(Report.Details.StepIndex + " - Searching for First Product In Grid");
			try
			{
				Report.Info("Searching for First Product In Grid");
				Report.Info("Getting the first product from the screen");
				var selProdGrid = new ProductsGrid();
				string firstId = selProdGrid.GetIdInFirstGridRow();
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

		[StepDefinition(@"I filter for the product saved as: (.*)")]
		[StepDefinition(@"I search for the product saved as: (.*)")]
		public void GivenISearchForTheProductSavedAs(string savedAs)
		{
			Delay.Seconds(30);
			Report.StartStep(Report.Details.StepIndex + " - Searching for Product Saved as " + savedAs);
			try
			{
				Report.Info("Searching for Product Saved as " + savedAs);

				if (!Context.Contains(savedAs))
				{
					Report.Failure("The reference: " + savedAs + " was not found in context");
					return;
				}

				string id = "";

				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					id = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}

				//if we didn't get the id try a different object type
				if (id == "")
				{
					try
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
					catch (Exception)
					{
						//do nothing
					}

				}

				if (id == "")
				{
					try
					{
						id = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{

					}
				}

				Report.Info("Searching for product with ID: '" + id + "'");
				var selProdGrid = new ProductsGrid {
					ProductIdField = id
				};
				GeneralUtilities.Wait_for_load_finish();
				Delay.Seconds(10);

				bool oneFound = false;
				int x = 0;
				while (oneFound == false && x < 20)
				{
					oneFound = selProdGrid.ProductsCount() == 1;
					Report.Info($"Number of products found was: {selProdGrid.ProductsCount()}");
					Delay.Seconds(5);
					x++;
				}

				Report.IsTrue(selProdGrid.ProductsCount() == 1, "No products were returned for ID: '" + id + "'!", "Product was returned!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I filter for the product with SKU saved as: (.*)")]
		[StepDefinition(@"I search for the product with SKU saved as: (.*)")]
		public void GivenISearchForTheProductWithSKUSavedAs(string savedAs)
		{
			Report.StartStep(Report.Details.StepIndex + " - Searching for Product Saved as " + savedAs);
			try
			{
				Report.Info("Searching for Product Saved as " + savedAs);
				if (!Context.Contains(savedAs))
				{
					Report.Failure("The reference: " + savedAs + " was not found in context");
					return;
				}
				string sku = "";
				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					sku = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}
				if (sku == "")
				{
					try
					{
						sku = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{
					}
				}

				bool expanded = new ProductsGrid().MoreFiltersExpanded();
				if (!expanded)
				{
					Report.Info("More Filters was collapsed so expanding it");
					new ProductsGrid().ClickMoreFilters();
				}

				Report.Info("Searching for product with SKU: '" + sku + "'");
				var selProdGrid = new ProductsGrid {
					ProductSkuField = sku
				};

				GeneralUtilities.Wait_for_load_finish();
				Delay.Seconds(10);
				Report.IsTrue(selProdGrid.ProductsCount() == 1, "No products were returned for ID: '" + sku + "'!", "Product was returned!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the follow product doesn't exist in the product grid: (.*)")]
		public void GivenISearchForTheProductSavedAsAndConfirmItDoesNotExist(string savedAs)
		{
			Report.StartStep(Report.Details.StepIndex + " - Searching for Product Saved as " + savedAs);
			try
			{
				Report.Info("Searching for Product Saved as " + savedAs);

				if (!Context.Contains(savedAs))
				{
					Report.Failure("The reference: " + savedAs + " was not found in context");
					return;
				}

				string id = "";

				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					id = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}

				//if we didn't get the id try a different object type
				if (id == "")
				{
					try
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
					catch (Exception)
					{
						//do nothing
					}

				}

				if (id == "")
				{
					try
					{
						id = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{

					}
				}

				Report.Info("Searching for product with ID: '" + id + "'");
				var selProdGrid = new ProductsGrid {
					ProductIdField = id
				};
				GeneralUtilities.Wait_for_load_finish();
				Delay.Seconds(10);
				Report.IsTrue(selProdGrid.ProductsCount() == 0, "A product was returned for ID: '" + id + "'!", "No product were returned!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I search for the product: (.*)")]
		public void SearchForTheProduct(string product)
		{
			Report.Info("Searching for product with ID: '" + product + "'");
			var selProdGrid = new ProductsGrid {
				ProductIdField = product
			};
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(selProdGrid.ProductsCount() > 0, "No products were returned for ID: '" + product + "'!", "Product was returned!");
		}


		[StepDefinition(@"I confirm that the product returned has the same name as the product saved as: (.*)")]
		public void ConfirmThatProductHasSameName(string savedAs)
		{
			if (!Context.Contains(savedAs))
			{
				Report.Failure("The reference: " + savedAs + " was not found in context");
			}

			string id = "";
			string name = "";

			try
			{
				var product = (ProductGridItem)Context.GetFromContext(savedAs);
				id = product.ProductId;
				name = product.ProductName;
			}
			catch (Exception)
			{
				//do nothing
			}

			//if we didn't get the id try a different object type
			if (id == "")
			{
				try
				{
					var product = (ProductInformation)Context.GetFromContext(savedAs);
					id = product.Id;
					name = product.Name;
				}
				catch (Exception)
				{
					//do nothing
				}

			}

			if (id == "")
			{
				try
				{
					id = Context.GetFromContext(savedAs).ToString();
				}
				catch (Exception)
				{
					//do nothing
				}
			}

			var selProdGrid = new ProductsGrid {
				ProductIdField = id
			};

			Report.IsTrue(selProdGrid.ConfirmNameMatches(name), "Failed to find matching name '" + name + "'.",
				"Successfully found matching name '" + name + "'.");
		}

		[StepDefinition(@"I confirm that the product returned has the retailer: (.*)")]
		public void ConfirmThatProductHasRetailer(string retailer)
		{
			var selProdGrid = new ProductsGrid();
			Report.IsTrue(selProdGrid.ConfirmProductHasRetailer(retailer), "Failed to find retailer '" + retailer + "' on first product returned.",
				"Successfully found retailer '" + retailer + "' on first product returned.");
		}

		[StepDefinition(@"I clear the Search Criteria")]
		public void ClearSearchCriteria()
		{
			var selProdGrid = new ProductsGrid();
			bool expanded = selProdGrid.MoreFiltersExpanded();
			if (!expanded)
			{
				Report.Info("More Filters was collapsed so expanding it");
				selProdGrid.ClickMoreFilters();
			}
			Report.Info("Clicking Clear");
			selProdGrid.ClickClear();
			GeneralUtilities.Wait_for_load_finish();
			Report.Info("Collapsing More Filters");
			selProdGrid.ClickMoreFilters();
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm the Delete Dialog")]
		public void ConfirmDeleteDialog()
		{
			var selDeleteConfirm = new DeleteDialog();
			if (!selDeleteConfirm.WaitForContainerToBeVisible())
			{ throw new Exception("Delete Dialog did not load!"); }
			Report.IsTrue(selDeleteConfirm.ClickDelete(), "Failed to click Delete", "Clicked Delete");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I cancel the Delete Dialog")]
		public void CancelDeleteDialog()
		{
			var selDeleteConfirm = new DeleteDialog();
			if (!selDeleteConfirm.WaitForContainerToBeVisible())
			{ throw new Exception("Delete Dialog did not load!"); }
			Report.IsTrue(selDeleteConfirm.ClickCancel(), "Failed to click cancel", "Clicked cancel");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I (should|should not) see the product returned in the search results")]
		public void ThenIShouldSeeTheProductReturnedInTheSearchResults(string shouldOrNot)
		{
			Report.Info("Correct product " + shouldOrNot + " be returned in the search grid");
			string searchedId = Context.GetFromContext("SearchedID")?.ToString();
			if (searchedId == null)
			{
				Report.Failure("Context did not contain string for saved as: SearchedID");
				return;
			}
			Report.Info("ID searched for: '" + searchedId + "'");
			var selProdGrid = new ProductsGrid();
			Report.IsTrue(selProdGrid.ProductsCount() == 1, "More than one entry was found!", "Only one entry was found, as expected!");
			Report.IsTrue(selProdGrid.GetIdInFirstGridRow() == searchedId, "ID returned was not the same as that searched for!", "ID returned was the same as that searched for");
		}

		[StepDefinition(@"I should only see one product in the grid, with Product ID matching that saved as: (.*)")]
		public void IShouldOnlySeeOneProductWithUPC(string savedAs)
		{
			var selProductsGrid = new ProductsGrid();
			string id = "";

			if (id == "")
			{
				try
				{
					if (Context.GetFromContext(savedAs).ToString().Contains("ProductInformation"))
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
				}
				catch (Exception)
				{
					//do nothing
				}

			}

			if (id == "")
			{
				try
				{
					id = Context.GetFromContext(savedAs).ToString();
				}
				catch (Exception)
				{

				}
			}

			if (id == null)
			{
				Report.Failure("Could not find UPC number in context saved as: " + savedAs);
				return;
			}
			string firstId = selProductsGrid.GetIdInFirstGridRow();
			int productsCount = selProductsGrid.ProductsCount();

			Report.IsTrue(productsCount == 1 && firstId == id,
				"Product with ID: " + id + " was not the only result returned! There were " + productsCount + " products in the grid and the first ID showing was: " + firstId,
				"Product with ID: " + id + " was the only result returned as expected");
		}

		[StepDefinition(@"I (should|should not) see products in the Product Grid")]
		public void ProductsPresentInGrid(string shouldOrNot)
		{
			Report.Info("Products " + shouldOrNot + " be returned in the search grid");
			var selProdGrid = new ProductsGrid();
			bool productsExpected = shouldOrNot == "should";
			Report.IsTrue((selProdGrid.ProductsCount() != 0) == productsExpected,
				"Results grid " + (productsExpected ? "was not" : "was") + " showing products!",
				"Results grid " + (productsExpected ? "was" : "was not") + " showing products, as expected!");
		}

		[StepDefinition(@"I filter the products by: (All|Not Yet Submitted|Assessment in Progress|Sending to Retailers|Accepted by Retailers|Needs Your Attention)")]
		public void WhenIFilterTheProductsByNotYetSubmitted(string filter)
		{
			Report.Info("Filtering Product Grid by " + filter);
			var selProdGrid = new ProductsGrid();
			Report.IsTrue(selProdGrid.ClickStatusFilter(filter), "Failed to click filter option: '" + filter + "'", "Successfully filtered grid by: '" + filter + "'");
		}

		[StepDefinition(@"I save the ProductID and Name of the first Product in the grid as: (.*)")]
		public void SaveFirstProductInGrid(string savedAs)
		{
			Report.Info("Saving Product ID and Name of First Product as " + savedAs);
			var selProdGrid = new ProductsGrid();
			ProductGridItem productElement = selProdGrid.FirstProductInGrid();
			Context.AddToContext(savedAs, productElement);
			Report.Success("Got the first Product in Grid (ID: " + productElement.ProductId + ") and saved to: " + savedAs);
		}

		[StepDefinition(@"I click Row Actions for the first product returned")]
		[StepDefinition(@"I click Row Actions for the most recent product returned")]
		public void WhenIClickRowActionsForTheFirstProductReturned()
		{
			Report.StartStep(Report.Details.StepIndex + " - Clicking 'Row Actions' for first product returned");
			try
			{
				Report.Info("Clicking 'Row Actions' for first product returned");
				var selProdGrid = new ProductsGrid();

				if (selProdGrid.ProductsCount() == 0)
				{
					Report.Warning("No products present! Cannot click Row Actions!");
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

		[StepDefinition(@"I click Row Actions for product saved as: (.*)")]
		public void IClickRowActionsForTheProductSavedAs(string savedAs)
		{
			Report.StartStep(Report.Details.StepIndex + " - Clicking 'Row Actions' for product saved as " + savedAs + ".");
			try
			{
				var product = (ProductGridItem)Context.GetFromContext(savedAs);
				Report.Info("Clicking 'Row Actions' for product saved as " + savedAs);
				var selProdGrid = new ProductsGrid();
				if (selProdGrid.ProductsCount() == 0)
				{
					Report.Failure("No products present! Cannot click Row Actions!");
					return;
				}
				Report.Info("Found products in grid, clicking action button...");
				Report.IsTrue(selProdGrid.ClickActionsForProduct(product.ProductId), "Failed to click Action Button!", "Successfully clicked the Action Button!");
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
			Report.StartStep(Report.Details.StepIndex + " - Clicking on Row Action: " + action);
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
			Delay.Seconds(10);
		}

		[StepDefinition(@"I should (see|only see|not see) the following Actions options")]
		public void ThenIShouldSeeTheFollowingOptions(string seeCondition, Table table)
		{
			Report.Info("Checking Row Actions");
			var selProdGrid = new ProductsGrid();
			if (selProdGrid.ProductsCount() == 0)
			{
				Report.Failure("No products present! Cannot click examine Row Actions!");
				Report.Screenshot();
				return;
			}
			List<string> rowActions = selProdGrid.ActionsAvailableInDropDown();
			if (rowActions == null)
			{
				Report.Failure("No row actions were found!");
				Report.Screenshot();
				return;
			}
			var expectedActions = new List<string>();
			table.Rows.Cast<TableRow>().ToList().ForEach(x => expectedActions.Add(x["Option"]));

			switch (seeCondition)
			{
				case "see":
					Report.IsTrue(expectedActions.All(rowActions.Contains),
						$@"Not all of the expected row actions were displayed! Expected: {string.Join(", ", expectedActions)}. Found: {string.Join(", ", rowActions)}",
						"All of the expected row actions were displayed: " + string.Join(", ", expectedActions));
					break;
				case "only see":
					Report.IsTrue(expectedActions.All(rowActions.Contains) && expectedActions.Count == rowActions.Count,
						$@"The displayed actions did not match exactly to the expected actions! Expected only: {string.Join(", ", expectedActions)}. Found: {string.Join(", ", rowActions)}",
						"The displayed actions matched exactly to the expected actions");
					break;
				case "not see":
					Report.IsTrue(!expectedActions.Any(rowActions.Contains),
						$"The following row actions should not be displayed but they were found! => {string.Join(", ", expectedActions)}. Found: {string.Join(", ", rowActions)}",
						"The following row actions were not displayed as expected: " + string.Join(", ", expectedActions));
					break;
				default:
					Report.Info("The 'showing' criteria did not match! Must be: see, only see, not see");
					return;
			}
		}

		[StepDefinition(@"I click Bulk Actions in the Products Grid")]
		public void GivenIClickBulkActionsInTheProductsGrid()
		{
			Report.StartStep(Report.Details.StepIndex + " - Clicking Bulk Actions in Products Grid");
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
			Report.StartStep(Report.Details.StepIndex + " - Checking Bulk Actions popup appears");
			try
			{
				Report.Info("Checking Bulk Actions popup appears");
				var selBulkActions = new BulkActions();
				selBulkActions.WaitForContainerToBeVisible();
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
			Report.StartStep(Report.Details.StepIndex + " - Checking Bulk Actions Options");
			try
			{

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
			Report.Info("Clicking " + option + " in the Bulk Actions window");
			var selBulkActions = new BulkActions();
			Report.IsTrue(selBulkActions.ClickOption(option) && GeneralUtilities.Wait_for_load_finish(),
				"Failed to click option: '" + option + "'",
				"Successfully clicked option: '" + option + "'");
		}

		/// <summary>
		/// Clicking the x to close the Bulk Actions popup
		/// </summary>
		[StepDefinition(@"I click on the close button on Bulk Actions")]
		public void ClickCloseOnBulkActions()
		{
			Report.StartStep(Report.Details.StepIndex + " - I click the close button");
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
			Report.StartStep(Report.Details.StepIndex + " - I click the cancel button");
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
			Report.StartStep(Report.Details.StepIndex + " - Sync Products to ULSC window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Sync Products to ULSC window appears");
				var selUlscSyncPopup = new SyncUlscProductsDialog();
				string showing = selUlscSyncPopup.HeaderShowing();
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

		[StepDefinition("I generate a unique UPC number and save as: (.*)")]
		public void GenerateUniqueUpcNumber(string savedAs)
		{
			var grid = new ProductsGrid();
			for (int i = 0; i < 6; i++)
			{
				Report.Info("Generating upc attempt " + (i + 1));
				//string uPCNo = new UpcFunctions().GenerateUPC();
				string uPCNo = GeneralFunctions.GenerateUPCNumber();
				Report.Info("Generated UPC No: " + uPCNo);
				Report.Info("Searching for generated upc number");
				grid.UpcNumber = uPCNo;
				Report.Info("Clicking search");
				if (grid.ClickUpcNumberSearchButton())
				{
					GeneralUtilities.Wait_for_load_finish();
					Report.Info("Clicked search");
					if (grid.ProductsPresent())
					{
						Report.Info("There were products in the grid!");
						continue;
					}
					Report.Success("Successfully generated a unique UPC number");
					Context.AddToContext(savedAs, uPCNo);
					this.ClearSearchCriteria();
					return;
				}
				Report.Failure("Failed to click 'search' for UPC field");
			}
			Report.Failure("Failed to generate a unique UPC number after 5 attempts!");
		}

		[StepDefinition(@"I generate a random UPC number and save as: (.*) and (keep|delete) duplicate UPC products")]
		public void GivenIGenerateARandomUPCNumberAndSaveAs(string savedAs, string keepOrDelete)
		{
			bool delete = keepOrDelete == "delete";
			Report.UseSubSteps = delete;
			Report.StartStep("I generate a random UPC number and save as: " + savedAs);
			this.GivenIGenerateARandomUPCNumberAndSaveAs(savedAs);
			if (delete)
			{
				Report.StartStep("I delete all products with UPC Number: saved as " + savedAs);
				this.DeleteAllProductsMatchingCriteria("UPC Number", "saved as " + savedAs);
			}
		}

		[StepDefinition(@"I generate a random UPC number and save as: (.*)")]
		public void GivenIGenerateARandomUPCNumberAndSaveAs(string savedAs)
		{
			//string uPCNo = new UpcFunctions().GenerateUPC();
			string uPCNo = GeneralFunctions.GenerateUPCNumber();
			Context.AddToContext(savedAs, uPCNo);
			//Report.Info("Generated UPC No: " + uPCNo);
			//Delay.Seconds(2);
			Report.Info(uPCNo);
			Delay.Seconds(1);

		}

		[StepDefinition(@"Generate a random SKU number \(12 random digits\) and save as: (.*)")]
		public void ThenGenerateARandomSKUNumberRandomDigitsAndSaveAsRandomSKU_(string savedAs)
		{
			//string uPCNo = new UpcFunctions().GenerateUPC();
			string uPCNo = GeneralFunctions.GenerateUPCNumber();
			Context.AddToContext(savedAs, uPCNo);
			//Report.Info("Generated UPC No: " + uPCNo);
			//Delay.Seconds(2);
			Report.Info(uPCNo);
			Delay.Seconds(1);
		}

		[StepDefinition(@"I generate a random Product ID and save as: (.*)")]
		public void GivenIGenerateARandomProductIDAndSaveAs(string savedAs)
		{
			//string uPCNo = new UpcFunctions().GenerateUPC();
			string uPCNo = GeneralFunctions.GenerateUPCNumber();
			Context.AddToContext(savedAs, uPCNo);
			//Report.Info("Generated UPC No: " + uPCNo);
			//Delay.Seconds(2);
			Report.Info(uPCNo);
			Delay.Seconds(1);
		}

		[StepDefinition(@"I generate a random Ingredient ID and save as: (.*)")]
		public void GivenIGenerateARandomIngredientIDAndSaveAs(string savedAs)
		{
			//string uPCNo = new UpcFunctions().GenerateUPC();
			string uPCNo = GeneralFunctions.GenerateUPCNumber();
			Context.AddToContext(savedAs, uPCNo);
			//Report.Info("Generated UPC No: " + uPCNo);
			//Delay.Seconds(2);
			Report.Info(uPCNo);
			Delay.Seconds(1);
		}

		[StepDefinition(@"I generate (.*) random UPC numbers and save all to list named: (.*)")]
		public void GivenIGenerateXRandomUPCNumbersAndSaveAs(int x, string savedAs)
		{
			var listOfUPCs = new List<string>();
			for (int i = 0; i < x; i++)
			{
				string thisUPCName = savedAs + "_" + i.ToString();
				this.GivenIGenerateARandomUPCNumberAndSaveAs(thisUPCName);
				listOfUPCs.Add(thisUPCName);
			}
			Context.AddToContext(savedAs, listOfUPCs);
		}

		[StepDefinition(@"I create a new excel document called (.*) and save as (.*)")]
		public void ICreateANewExcelDocumentCalledAndSaveAs(string excelName, string saveAs)
		{
			var excel = ExcelFunctions.CreateSpreadsheet(excelName);
			Context.AddToContext(saveAs, excel);
		}

		[StepDefinition(@"I save the list of UPCs saved as (.*) to excel spreadsheet saved as (.*)")]
		public void ISaveTheListOfUPCsSavedAsToExcelSpreadsheetSavedAs(string listSavedAs, string excelSavedAs)
		{
			var listOfUPCs = (List<string>)Context.GetFromContext(listSavedAs);
			var excel = (ExcelFunctions)Context.GetFromContext(excelSavedAs);
			foreach (string upc in listOfUPCs)
			{
				var tinyList = new List<string> {
					upc
				};
				excel.AddRow(tinyList);
			}
		}

		[StepDefinition(@"I delete all products in contextual list of UPCs: (.*)")]
		public void IDeleteAllProductsInContextualListOfUPCs(string savedAs)
		{
			var listOfUPCs = (List<string>)Context.GetFromContext(savedAs);
			foreach (var str in listOfUPCs)
			{
				this.DeleteAllProductsMatchingCriteria("UPC Number", (string)Context.GetFromContext(str));
			}
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
			Report.Info("Attempting to get product from context");
			if (!Context.Contains(savedas))
			{
				Report.Failure($"Context did not contain the Product saved as: {savedas}");
			}
			else
			{
				Report.Info("Found in Context");
			}
			var obj = Context.GetFromContext(savedas);
			Report.Info("Attempting to convert Product to type ProductInformation");
			var Product = (ProductInformation)obj;
			Report.Info("Attempting to delete: " + Product.Name);
			var ProductGrid = new ProductsGrid {
				ProductIdField = Product.Id
			};
			if (Report.IsTrue(ProductGrid.ProductIdField == Product.Id, "Value: " + Product.Id + " was not inputted into the Product Id field correctly!", "Value: " + Product.Id + " was correctly inputted into the Product Id field", false, false))
			{
				if (Report.IsTrue(ProductGrid.ClickProductIdNameSearchButton(), "Failed to click the search button", "Successfully clicked the search button!", false, false))
				{
					GeneralUtilities.Wait_for_load_finish();
					if (!ProductGrid.RowsAreFoundInProductGrid())
					{
						Report.Failure($"No products with ID '{Product.Id}' were found in the grid!");
						return;
					}
					ProductGridItem firstProduct = ProductGrid.FirstProductInGrid();
					if (Report.IsTrue(firstProduct.ProductName.StartsWith(Product.Name) && firstProduct.ProductId == Product.Id, "First product did not match the required paremeters!", "Product was showing at the top of the grid, as expected!"))
					{
						Report.IsTrue(ProductGrid.DeleteFirstRow(), "Failed to delete product in first row!", "Successfully deleted product in first row!");
					}
				}
			}
		}

		//confirm method
		[StepDefinition(@"I confirm the product: (.*)")]
		public void ThenIConfirmTheProduct(string savedas)
		{
			Report.Info("Attempting to get product from context");
			if (!Context.Contains(savedas))
			{
				Report.Failure($"Context did not contain the Product saved as: {savedas}");
			}
			else
			{
				Report.Info("Found in Context");
			}
			var obj = Context.GetFromContext(savedas);
			Report.Info("Attempting to convert Product to type ProductInformation");
			var Product = (ProductInformation)obj;
			Report.Info("Attempting to delete: " + Product.Name);
			var ProductGrid = new ProductsGrid {
				ProductIdField = Product.Id
			};
			if (Report.IsTrue(ProductGrid.ProductIdField == Product.Id, "Value: " + Product.Id + " was not inputted into the Product Id field correctly!", "Value: " + Product.Id + " was correctly inputted into the Product Id field", false, false))
			{
				if (Report.IsTrue(ProductGrid.ClickProductIdNameSearchButton(), "Failed to click the search button", "Successfully clicked the search button!", false, false))
				{
					GeneralUtilities.Wait_for_load_finish();
					if (!ProductGrid.RowsAreFoundInProductGrid())
					{
						Report.Failure($"No products with ID '{Product.Id}' were found in the grid!");
						return;
					}

					Report.Info($"Products with ID '{Product.Id}' were found in the grid!");
				}
			}
		}

		[StepDefinition(@"The current page in the products grid is: (.*)")]
		public void CurrentPageProductsGrid(string expectedPage)
		{
			string currentPage = new ProductsGrid().ActivePage();
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
			Report.IsTrue(selProductsGrid.NumToGridNavigationInput(pageNum), "Failed to enter page number: " + pageNum + " into navigation input");
			Report.Info("Pressing the enter key");
			selProductsGrid.KeyToGridNavigationInput("enter");
		}

		[StepDefinition(@"I enter the (up|down) arrow into the products grid page navigation input then the correct page is shown")]
		public void EnterArrowUserGridNavigationBox(string direction)
		{
			var selProductsGrid = new ProductsGrid();
			string pageNavigationValue = selProductsGrid.CurrentPageGridNavigationInput();
			if (pageNavigationValue == null)
			{
				Report.Info("The Navigation Input was not showing");
			}
			Report.StartStep(Report.Details.StepIndex + " - I enter the " + direction + " arrow into the page navigation box");
			Report.Info("Entering the " + direction + " arrow key to the products grid page navigation input");
			selProductsGrid.KeyToGridNavigationInput(direction);
			Report.Info("Pressing the enter key");
			selProductsGrid.KeyToGridNavigationInput("enter");
			string iteration = direction == "up" ? "increased" : "decreased";
			Report.Details.StepIndex++;
			Report.StartStep(Report.Details.StepIndex + " - I confirm the page number has " + iteration + " by 1");
			int currentPage = Convert.ToInt32(selProductsGrid.ActivePage());
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
			Delay.Seconds(4);
			Report.IsTrue(new ProductsGrid().ClickMoreFilters(),
				"Failed to click 'More Filters' in the products grid",
				"Successfully clicked 'More Filters' in the products grid");
		}

		[StepDefinition(@"I select the (.*) option in the (Brand|Retailer|Additional Programs) More Filters drop down")]
		public void SetMoreFilterOption(string option, string filter)
		{
			var selMoreFilters = new MoreFilters();
			if (option.StartsWith("~saved as"))
			{
				string savedAs = option.Replace("~saved as", "").Trim();
				option = Context.GetFromContext(savedAs)?.ToString();
				if (option == null)
				{
					throw new Exception("Could not find item in context: " + savedAs + " for more filters option!");
				}
			}
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

		[StepDefinition(@"I select the More Filters - Brand saved as: (.*) by ID")]
		public void SelectMoreFiltersBrandSavedAs(string savedAs)
		{
			var selMoreFilters = new MoreFilters();
			var brand = (MyBrands.Brand)Context.GetFromContext(savedAs);
			if (brand == null)
			{
				throw new Exception("Could not find brand saved as: " + savedAs + " in context!");
			}
			Report.IsTrue(selMoreFilters.SelectBrandByValue(brand), $"Failed to select brand: {brand.Name} ({brand.ID})", $"Successfully selected brand: {brand.Name} ({brand.ID})");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I edit the product with ID: (.*)")]
		public void EditFirstProductForRetailer(string id)
		{
			var selProductsGrid = new ProductsGrid {
				ProductIdField = id
			};
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

		[StepDefinition(@"A Summary page should open in a new browser tab")]
		public void ThenASummaryPageShouldOpenInANewBrowserTab()
		{
			var OpenBrowsers =
				SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()))
					.ToList();
			for (int i = 0; i < 30; i++)
			{
				OpenBrowsers = SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()))
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

		[StepDefinition(@"I should not seen an Accept button")]
		public void ThenIShouldNotSeenAnAcceptButton()
		{
			var thisSummaryPage = new SummaryPage();
			Report.IsTrue(!thisSummaryPage.ListOfButtons().Contains("Accept"), "Accept button is showing",
				"Accept button is not showing");
		}

		[StepDefinition(@"I close the browser tab with the Summary page")]
		public void GivenICloseTheBrowserTabWithTheSummaryPage()
		{
			var OpenBrowsers =
				SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()))
					.ToList();
			for (int i = 0; i < 30; i++)
			{
				OpenBrowsers = SeleniumBrowser.GetTabURLs().Where(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()))
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

		[StepDefinition(@"I save the number of items in the pie chart")]
		public void GivenISaveTheNumberOfItemsInThePieChart()
		{
			var myHomepage = new Homepage();
			int currentProductCount = myHomepage.PieChartProductsTotal();
			Context.AddToContext("ProductCount", currentProductCount);
			Report.IsTrue(currentProductCount > -1, "Failed to get current product count",
				"Current product count is: " + currentProductCount.ToString());
		}

		[StepDefinition(@"the number of items in the pie chart should be one less than the figure I saved")]
		public void ThenTheNumberOfItemsInThePieChartShouldBeOneLessThanTheFigureISaved()
		{
			var myHomepage = new Homepage();
			int currentProductCount = myHomepage.PieChartProductsTotal();
			int savedProductcount = Convert.ToInt16(Context.GetFromContext("ProductCount"));
			Report.IsTrue(currentProductCount == (savedProductcount - 1),
				"Current count is: " + currentProductCount.ToString() + " saved count is: " +
				savedProductcount.ToString(),
				"As expected, current product count (" + currentProductCount.ToString() +
				" is one less than saved count");
		}

		[StepDefinition(@"I should see the header: Document Acceptance on the Document Acceptance window")]
		public void GivenIShouldSeeTheHeaderDocumentAcceptanceOnTheDocumentAcceptanceWindow()
		{
			Report.IsTrue(new DocumentAcceptance().WaitForContainerToBeVisible(),
				"Document Acceptance page is not showing as expected.", "Document Acceptance page is showing");
		}

		[StepDefinition(@"I should see the header: Delete Active Products on the Delete Active Product window")]
		public void GivenIShouldSeeTheHeaderDeleteActiveProductsOnTheDeleteActiveProductWindow()
		{
			Report.IsTrue(new DeleteActiveProducts().WaitForContainerToBeVisible(),
				"Delete Active Products page is not showing as expected.", "Delete Active Products page is showing");
		}

		[StepDefinition(@"I should see the header: Message Center on the Message Center window")]
		public void ThenIShouldSeeTheHeaderMessageCenterOnTheMessageCenterWindow()
		{
			Report.IsTrue(new MessageCenter().WaitForContainerToBeVisible(),
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
			selProdGrid.ClickProductIdNameSearchButton();
			Report.Info("clicking Actions for first row in the grid");
			Report.IsTrue(selProdGrid.ClickActionsForFirstResultInGrid(), "Failed to click first Action Button!", "Successfully clicked the first Action Button!");
		}

		[StepDefinition(@"I search for UPC number saved as: (.*)")]
		public void SearchForUPCSavedAs(string savedAs)
		{
			string upc = Context.GetFromContext(savedAs)?.ToString();
			if (upc == null)
			{
				Report.Failure("Could not find UPC number in context saved as: " + savedAs);
				return;
			}
			var selProductGrid = new ProductsGrid {
				UpcNumber = upc
			};
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
		public void EnterCombinationsOfMoreFilters(string id, Table moreFilters)
		{
			var test = Context.GetFromContext(id);
			//if (Context.GetFromContextRegex(id, out var result))
			if (test != null)
			{
				Report.Info("Getting ID from context: " + id);
				id = test.ToString();
			}
			Report.UseSubSteps = true;
			var selProductsGrid = new ProductsGrid();
			var selMoreFilters = new MoreFilters();
			var filters = new List<KeyValuePair<string, string>>();
			foreach (TableRow row in moreFilters.Rows)
			{
				if (Context.GetFromContextRegex(row["Match"], out var matchResult))
				{
					row["Match"] = matchResult.ToString();
				}
				filters.Add(new KeyValuePair<string, string>(
					row["Filter"],
					row["Match"]));
			}
			// Cycles through every possible combination of 2 filters
			Report.StartSubStep("I enter combinations of 2 filters selected");
			Report.Info("Testing against reference product with filter values: " + string.Join(", ", filters.Select(x => x.Key + " = " + x.Value).ToList()));
			int N = 4;
			int Q = 2;
			for (int i = 0; i < N - 1; i++)
			{
				// The filter at index i and j are the targets for this action
				// Fix i and iterate j from i + 1 to the end then repeat for i++ etc
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
							KeyValuePair<string, string> filter = filtersToDo[l];
							string filterType = filter.Key;
							List<string> options = new List<string>();
							string upc = filter.Value;
							if (filterType == "UPC")
							{
								if (Context.GetFromContextRegex(filter.Value, out var upcResult))
								{
									Report.Info("Getting UPC from context: " + upc);
									upc = upcResult.ToString();
								}
								Report.Info("UPC: " + upc);
								options.Add(upc);
							}
							else
							{
								options = selMoreFilters.Options(filterType);
							}

							string option = match[l] ? filter.Value : options.First(x => x != filter.Value);
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
						Delay.Seconds(10);
						GeneralUtilities.Wait_for_load_finish();
						Report.Info("Looking for product ID: " + id);
						Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(id) == productReturned,
							"The product ID: " + id + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
							"The product ID: " + id + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
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
			Report.StartSubStep("I enter combinations of 3 filters selected");
			Report.Info("Testing against reference product with filter values: " + string.Join(", ", filters.Select(x => x.Key + " = " + x.Value).ToList()));
			// Cycles through every combination of 3 filters
			Q = 3;
			// The filters at every index apart from i are the target for this action.
			// Iterate i to the end to get all combinations of 3 filters
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
						KeyValuePair<string, string> filter = filtersToDo[l];
						string filterType = filter.Key;
						List<string> options = filterType == "UPC" ? new List<string> { filter.Value } : selMoreFilters.Options(filterType);
						string option = match[l] ? filter.Value : options.First(x => x != filter.Value);
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
					Report.Info("Looking for product ID: " + id);
					Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(id) == productReturned,
						"The product ID: " + id + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
						"The product ID: " + id + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
					Report.Info("Clearing search criteria");
					selProductsGrid.UpcNumber = "";
					selProductsGrid.ClickClear();
					GeneralUtilities.Wait_for_load_finish();
					match[k] = !match[k];
					k = k + z;
					z = k % 2 == 0 || k == 0 ? z * -1 : z;
				}
			}
			Report.StartSubStep("I enter combinations of 4 filters selected");
			Report.Info("Testing against reference product with filter values: " + string.Join(", ", filters.Select(x => x.Key + " = " + x.Value).ToList()));
			// Cycles through every combination of 4 filters
			Q = 4;
			// only executes one loop
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
						KeyValuePair<string, string> filter = filters[l];
						string filterType = filter.Key;
						List<string> options = filterType == "UPC" ? new List<string> { filter.Value } : selMoreFilters.Options(filterType);
						string option = match[l] ? filter.Value : options.First(x => x != filter.Value);
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
					Report.Info("Looking for product ID: " + id);
					Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(id) == productReturned,
						"The product ID: " + id + (productReturned ? " did not appear " : " appeared") + " when it " + (productReturned ? "should have" : "should not not have"),
						"The product ID: " + id + (productReturned ? " appeared" : " did not appear") + " in the grid as expected");
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
			var result = Context.GetFromContext(id);
			//if (Context.GetFromContextRegex(id, out var result))
			if (result != null)
			{
				Report.Info("Getting ID from context: " + id);
				id = result.ToString();
			}
			Report.Info("Product ID: " + id);
			var selProdGrid = new ProductsGrid {
				ProductIdField = id
			};
			GeneralUtilities.Wait_for_load_finish();
			ProductGridItem firstProduct = selProdGrid.FirstProductInGrid();
			Report.IsTrue(firstProduct != null && firstProduct.ProductName == name,
				"Product with ID: " + id + " and name: " + name + " was not returned in the product grid",
				"Product with ID: " + id + " and name: " + name + " was returned in the product grid");
			selProdGrid.ProductIdField = "";
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I enter combinations of Status and More Filters and should see the product ID: (.*) only for the correct combinations")]
		public void EnterCombinationsOfStatusAndMoreFilters(string id, Table statusAndFilters)
		{
			var test = Context.GetFromContext(id);
			//if (Context.GetFromContextRegex(id, out var result))
			if (test != null)
			{
				Report.Info("Getting ID from context: " + id);
				id = test.ToString();
			}

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
			foreach (TableRow row in statusAndFilters.Rows)
			{
				filters.Add(new KeyValuePair<string, string>(
					row["Filter"],
					row["Match"]));
			}
			KeyValuePair<string, string> status = filters.FirstOrDefault(x => x.Key == "Status");
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
						KeyValuePair<string, string> filter = filtersToDo[l];
						string filterType = filter.Key;
						List<string> options = filterType == "Status" ? statuses : selMoreFilters.Options(filterType);
						string option = match[l] ? filter.Value : options.First(x => x != filter.Value);
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

		[StepDefinition(@"I should see the following options for the (Retailer|Brand|Additional Programs) filter")]
		public void ShouldSeeTheFollowingOptionsMoreFilters(string filter, Table table)
		{
			List<string> displayedOptions = new MoreFilters().Options(filter);
			var expectedOptions = new List<string>();
			table.Rows.Cast<TableRow>().ToList().ForEach(x => expectedOptions.Add(x["Option"]));
			Report.IsTrue(expectedOptions.All(x => displayedOptions.Contains(x)) && expectedOptions.Count == displayedOptions.Count,
				$"The displayed options for filter {filter} did not match the expected options! Expected: {string.Join(", ", expectedOptions.Select(x => $"'{x}'").ToList())}. Actual: {string.Join(", ", displayedOptions.Select(x => $"'{x}'").ToList())}",
				$"The displayed options for filter: {filter}' matched the expected options.");
			var diff = expectedOptions.Except(displayedOptions);
			var diff2 = displayedOptions.Except(expectedOptions);

		}

		[StepDefinition(@"I confirm retailers list based on environment")]
		public void SeeFollowingOptionsMoreFilters()
		{
			if (TReVorSettings.SoftwareBranch == "Development")
			{
				Report.UseSubSteps = true;
				var MyNewProduct = new StepsProductGrid();
				Report.StartSubStep("I should only see the following retailers");
				var productTable = new TechTalk.SpecFlow.Table(new string[] {
				"Option"
			});
				productTable.AddRow(new string[] {
				"Ace Hardware Corporation"
			});
				productTable.AddRow(new string[] {
				"Ahold | DelHaize USA"
			});
				productTable.AddRow(new string[] {
				"Albertsons Companies"
			});
				productTable.AddRow(new string[] {
				"Amazon"
			});
				productTable.AddRow(new string[] {
				"Autozone"
			});
				productTable.AddRow(new string[] {
				"Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)"
			});
				productTable.AddRow(new string[] {
				"Best Buy"
			});
				productTable.AddRow(new string[] {
				"Canadian Tire"
			});
				productTable.AddRow(new string[] {
				"Costco"
			});
				productTable.AddRow(new string[] {
				"CVS"
			});
				productTable.AddRow(new string[] {
				"Dick's Sporting Goods"
			});
				productTable.AddRow(new string[] {
				"Dollar General"
			});
				productTable.AddRow(new string[] {
				"Dollar Tree Stores, Inc. / Greenbrier International, Inc"
			});
				productTable.AddRow(new string[] {
				"Essendant"
			});
				productTable.AddRow(new string[] {
				"Family Dollar"
			});
				productTable.AddRow(new string[] {
				"Genuine Parts"
			});
				productTable.AddRow(new string[] {
				"Harbor Freight Tools"
			});
				productTable.AddRow(new string[] {
				"HD Supply"
			});
				productTable.AddRow(new string[] {
				"HEB"
			});
				productTable.AddRow(new string[] {
				"HyVee"
			});
				productTable.AddRow(new string[] {
				"Kohl's"
			});
				productTable.AddRow(new string[] {
				"Kroger"
			});
				productTable.AddRow(new string[] {
				"Lowe's"
			});
				productTable.AddRow(new string[] {
				"McLane"
			});
				productTable.AddRow(new string[] {
				"Meijer"
			});
				productTable.AddRow(new string[] {
				"New Egg"
			});
				productTable.AddRow(new string[] {
				"No Retailer/No UPC Product"
			});
				productTable.AddRow(new string[] {
				"Northgate Market"
			});
				productTable.AddRow(new string[] {
				"Office Depot"
			});
				productTable.AddRow(new string[] {
				"Optoro"
			});
				productTable.AddRow(new string[] {
				"O'Reilly"
			});
				productTable.AddRow(new string[] {
				"Petco"
			});
				productTable.AddRow(new string[] {
				"Price Chopper"
			});
				productTable.AddRow(new string[] {
				"Publix"
			});
				productTable.AddRow(new string[] {
				"Rite Aid"
			});
				productTable.AddRow(new string[] {
				"Save Mart Supermarkets"
			});
				productTable.AddRow(new string[] {
				"Schnuck's"
			});
				productTable.AddRow(new string[] {
				"Sears/K-Mart"
			});
				productTable.AddRow(new string[] {
				"Smart & Final"
			});
				productTable.AddRow(new string[] {
				"Staples"
			});
				productTable.AddRow(new string[] {
				"SuperValu"
			});
				productTable.AddRow(new string[] {
				"Target"
			});
				productTable.AddRow(new string[] {
				"The Home Depot"
			});
				productTable.AddRow(new string[] {
				"TopCo"
			});
				productTable.AddRow(new string[] {
				"Tractor Supply"
			});
				productTable.AddRow(new string[] {
				"Ultra/Standard"
			});
				productTable.AddRow(new string[] {
				"Unified"
			});
				productTable.AddRow(new string[] {
				"Wakefern"
			});
				productTable.AddRow(new string[] {
				"Walgreens"
			});
				productTable.AddRow(new string[] {
				"Wal-Mart/SAM'S CLUB"
			});
				productTable.AddRow(new string[] {
				"WinCo Foods"
			});
				MyNewProduct.ShouldSeeTheFollowingOptionsMoreFilters("Retailer", productTable);
			}
			if (TReVorSettings.SoftwareBranch == "QA")
			{
				Report.UseSubSteps = true;
				var MyNewProduct = new StepsProductGrid();
				Report.StartSubStep("I should only see the following retailers");
				var productTable = new TechTalk.SpecFlow.Table(new string[] {
				"Option"
			});
				productTable.AddRow(new string[] {
				"Ace Hardware Corporation"
			});
				productTable.AddRow(new string[] {
				"Ahold | DelHaize USA"
			});
				productTable.AddRow(new string[] {
				"Albertsons Companies"
			});
				productTable.AddRow(new string[] {
				"Amazon"
			});
				productTable.AddRow(new string[] {
				"Autozone"
			});
				productTable.AddRow(new string[] {
				"Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)"
			});
				productTable.AddRow(new string[] {
				"Best Buy"
			});
				productTable.AddRow(new string[] {
				"Canadian Tire"
			});
				//	productTable.AddRow(new string[] {
				//	"Costco"
				//});
				productTable.AddRow(new string[] {
				"CVS"
			});
				productTable.AddRow(new string[] {
				"Dick's Sporting Goods"
			});
				productTable.AddRow(new string[] {
				"Dollar General"
			});
				productTable.AddRow(new string[] {
				"Dollar Tree Stores, Inc. / Greenbrier International, Inc"
			});
				productTable.AddRow(new string[] {
				"Essendant"
			});
				productTable.AddRow(new string[] {
				"Family Dollar"
			});
				productTable.AddRow(new string[] {
				"Genuine Parts"
			});
				productTable.AddRow(new string[] {
				"Harbor Freight Tools"
			});
				productTable.AddRow(new string[] {
				"HD Supply"
			});
				productTable.AddRow(new string[] {
				"HEB"
			});
				productTable.AddRow(new string[] {
				"HyVee"
			});
				productTable.AddRow(new string[] {
				"Kohl's"
			});
				productTable.AddRow(new string[] {
				"Kroger"
			});
				productTable.AddRow(new string[] {
				"Lowe's"
			});
				productTable.AddRow(new string[] {
				"McLane"
			});
				productTable.AddRow(new string[] {
				"Meijer"
			});
				productTable.AddRow(new string[] {
				"New Egg"
			});
				productTable.AddRow(new string[] {
				"No Retailer/No UPC Product"
			});
				productTable.AddRow(new string[] {
				"Northgate Market"
			});
				productTable.AddRow(new string[] {
				"Office Depot"
			});
				productTable.AddRow(new string[] {
				"Optoro"
			});
				productTable.AddRow(new string[] {
				"O'Reilly"
			});
				productTable.AddRow(new string[] {
				"Petco"
			});
				productTable.AddRow(new string[] {
				"Price Chopper"
			});
				productTable.AddRow(new string[] {
				"Publix"
			});
				productTable.AddRow(new string[] {
				"Rite Aid"
			});
				productTable.AddRow(new string[] {
				"Save Mart Supermarkets"
			});
				productTable.AddRow(new string[] {
				"Schnuck's"
			});
				productTable.AddRow(new string[] {
				"Sears/K-Mart"
			});
				productTable.AddRow(new string[] {
				"Smart & Final"
			});
				productTable.AddRow(new string[] {
				"Staples"
			});
				productTable.AddRow(new string[] {
				"Target"
			});
				productTable.AddRow(new string[] {
				"The Home Depot"
			});
				productTable.AddRow(new string[] {
				"TopCo"
			});
				productTable.AddRow(new string[] {
				"Tractor Supply"
			});
				productTable.AddRow(new string[] {
				"Ultra/Standard"
			});
				productTable.AddRow(new string[] {
				"Unified"
			});
				productTable.AddRow(new string[] {
				"United Natural Foods, Inc."
			});
				productTable.AddRow(new string[] {
				"Wakefern"
			});
				productTable.AddRow(new string[] {
				"Walgreens"
			});
				productTable.AddRow(new string[] {
				"Wal-Mart/SAM'S CLUB"
			});
				productTable.AddRow(new string[] {
				"WinCo Foods"
			});
				MyNewProduct.ShouldSeeTheFollowingOptionsMoreFilters("Retailer", productTable);
			}
			if (TReVorSettings.SoftwareBranch == "Staging")
			{
				Report.UseSubSteps = true;
				var MyNewProduct = new StepsProductGrid();
				Report.StartSubStep("I should only see the following retailers");
				var productTable = new TechTalk.SpecFlow.Table(new string[] {
				"Option"
			});
				productTable.AddRow(new string[] {
				"Ace Hardware Corporation"
			});
				productTable.AddRow(new string[] {
				"Ahold | DelHaize USA"
			});
				productTable.AddRow(new string[] {
				"Albertsons Companies"
			});
				productTable.AddRow(new string[] {
				"Amazon"
			});
				productTable.AddRow(new string[] {
				"Autozone"
			});
				productTable.AddRow(new string[] {
				"Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)"
			});
				productTable.AddRow(new string[] {
				"Best Buy"
			});
				productTable.AddRow(new string[] {
				"Canadian Tire"
			});
				//	productTable.AddRow(new string[] {
				//	"Costco"
				//});
				productTable.AddRow(new string[] {
				"CVS"
			});
				productTable.AddRow(new string[] {
				"Dick's Sporting Goods"
			});
				productTable.AddRow(new string[] {
				"Dollar General"
			});
				productTable.AddRow(new string[] {
				"Dollar Tree Stores, Inc. / Greenbrier International, Inc"
			});
				productTable.AddRow(new string[] {
				"Essendant"
			});
				productTable.AddRow(new string[] {
				"Family Dollar"
			});
				productTable.AddRow(new string[] {
				"Genuine Parts"
			});
				productTable.AddRow(new string[] {
				"Harbor Freight Tools"
			});
				productTable.AddRow(new string[] {
				"HD Supply"
			});
				productTable.AddRow(new string[] {
				"HEB "
			});
				productTable.AddRow(new string[] {
				"HyVee"
			});
				productTable.AddRow(new string[] {
				"Kohl's"
			});
				productTable.AddRow(new string[] {
				"Kroger"
			});
				productTable.AddRow(new string[] {
				"Lowe's"
			});
				productTable.AddRow(new string[] {
				"McLane"
			});
				productTable.AddRow(new string[] {
				"Meijer"
			});
				productTable.AddRow(new string[] {
				"New Egg"
			});
				productTable.AddRow(new string[] {
				"No Retailer/No UPC Product"
			});
				productTable.AddRow(new string[] {
				"Northgate Market"
			});
				productTable.AddRow(new string[] {
				"Office Depot"
			});
				productTable.AddRow(new string[] {
				"Optoro "
			});
				productTable.AddRow(new string[] {
				"O'Reilly"
			});
				productTable.AddRow(new string[] {
				"Petco"
			});
				productTable.AddRow(new string[] {
				"Price Chopper "
			});
				productTable.AddRow(new string[] {
				"Publix "
			});
				productTable.AddRow(new string[] {
				"Rite Aid"
			});
				productTable.AddRow(new string[] {
				"Save Mart Supermarkets"
			});
				productTable.AddRow(new string[] {
				"Schnuck's"
			});
				productTable.AddRow(new string[] {
				"Sears/K-Mart"
			});
				productTable.AddRow(new string[] {
				"Smart & Final"
			});
				productTable.AddRow(new string[] {
				"Staples"
			});
				productTable.AddRow(new string[] {
				"SuperValu"
			});
				productTable.AddRow(new string[] {
				"Target"
			});
				productTable.AddRow(new string[] {
				"The Home Depot"
			});
				productTable.AddRow(new string[] {
				"TopCo"
			});
				productTable.AddRow(new string[] {
				"Tractor Supply"
			});
				productTable.AddRow(new string[] {
				"Ultra/Standard"
			});
				productTable.AddRow(new string[] {
				"Unified"
			});
				productTable.AddRow(new string[] {
				"Wakefern"
			});
				productTable.AddRow(new string[] {
				"Walgreens"
			});
				productTable.AddRow(new string[] {
				"Wal-Mart/SAM'S CLUB"
			});
				productTable.AddRow(new string[] {
				"WinCo Foods"
			});
				MyNewProduct.ShouldSeeTheFollowingOptionsMoreFilters("Retailer", productTable);
			}
			if (TReVorSettings.SoftwareBranch == "Local Production")
			{
				Report.UseSubSteps = true;
				var MyNewProduct = new StepsProductGrid();
				Report.StartSubStep("I should only see the following retailers");
				var productTable = new TechTalk.SpecFlow.Table(new string[] {
				"Option"
			});
				productTable.AddRow(new string[] {
				"Ace Hardware Corporation"
			});
				productTable.AddRow(new string[] {
				"Ahold | DelHaize USA"
			});
				productTable.AddRow(new string[] {
				"Albertsons Companies"
			});
				productTable.AddRow(new string[] {
				"Amazon"
			});
				productTable.AddRow(new string[] {
				"Autozone"
			});
				productTable.AddRow(new string[] {
				"Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)"
			});
				productTable.AddRow(new string[] {
				"Best Buy"
			});
				productTable.AddRow(new string[] {
				"Canadian Tire"
			});
				productTable.AddRow(new string[] {
				"Costco"
			});
				productTable.AddRow(new string[] {
				"CVS"
			});
				productTable.AddRow(new string[] {
				"Dick's Sporting Goods"
			});
				productTable.AddRow(new string[] {
				"Dollar General"
			});
				productTable.AddRow(new string[] {
				"Dollar Tree Stores, Inc. / Greenbrier International, Inc"
			});
				productTable.AddRow(new string[] {
				"Essendant"
			});
				productTable.AddRow(new string[] {
				"Family Dollar"
			});
				productTable.AddRow(new string[] {
				"Genuine Parts"
			});
				productTable.AddRow(new string[] {
				"Harbor Freight Tools"
			});
				productTable.AddRow(new string[] {
				"HD Supply"
			});
				productTable.AddRow(new string[] {
				"HEB "
			});
				productTable.AddRow(new string[] {
				"HyVee"
			});
				productTable.AddRow(new string[] {
				"Kohl's"
			});
				productTable.AddRow(new string[] {
				"Kroger"
			});
				productTable.AddRow(new string[] {
				"Lowe's"
			});
				productTable.AddRow(new string[] {
				"McLane"
			});
				productTable.AddRow(new string[] {
				"Meijer"
			});
				productTable.AddRow(new string[] {
				"New Egg"
			});
				productTable.AddRow(new string[] {
				"No Retailer/No UPC Product"
			});
				productTable.AddRow(new string[] {
				"Northgate Market"
			});
				productTable.AddRow(new string[] {
				"Office Depot"
			});
				productTable.AddRow(new string[] {
				"Optoro "
			});
				productTable.AddRow(new string[] {
				"O'Reilly"
			});
				productTable.AddRow(new string[] {
				"Petco"
			});
				productTable.AddRow(new string[] {
				"Price Chopper "
			});
				productTable.AddRow(new string[] {
				"Publix "
			});
				productTable.AddRow(new string[] {
				"Rite Aid"
			});
				productTable.AddRow(new string[] {
				"Save Mart Supermarkets"
			});
				productTable.AddRow(new string[] {
				"Schnuck's"
			});
				productTable.AddRow(new string[] {
				"Sears/K-Mart"
			});
				productTable.AddRow(new string[] {
				"Smart & Final"
			});
				productTable.AddRow(new string[] {
				"Staples"
			});
				productTable.AddRow(new string[] {
				"SuperValu"
			});
				productTable.AddRow(new string[] {
				"Target"
			});
				productTable.AddRow(new string[] {
				"The Home Depot"
			});
				productTable.AddRow(new string[] {
				"TopCo"
			});
				productTable.AddRow(new string[] {
				"Tractor Supply"
			});
				productTable.AddRow(new string[] {
				"Ultra/Standard"
			});
				productTable.AddRow(new string[] {
				"Unified"
			});
				productTable.AddRow(new string[] {
				"Wakefern"
			});
				productTable.AddRow(new string[] {
				"Walgreens"
			});
				productTable.AddRow(new string[] {
				"Wal-Mart/SAM'S CLUB"
			});
				productTable.AddRow(new string[] {
				"WinCo Foods"
			});
				MyNewProduct.ShouldSeeTheFollowingOptionsMoreFilters("Retailer", productTable);
			}
		}

		[StepDefinition(@"I confirm the filter with label: ""(.*)"" is displayed and default option: ""(.*)""")]
		public void ConfirmFilterDisplayedWithLabelAndDefaultOption(string label, string option)
		{
			var selMoreFilters = new MoreFilters();
			List<string> displayedLabels = selMoreFilters.MoreFilterLabels();
			Report.IsTrue(displayedLabels.Contains(label),
				$@"The label ""{label}"" was not displayed under More Filters! Displayed labels: {string.Join(", ", displayedLabels.Select(x => $"'{x}'"))}",
				$@"The label ""{label}"" was displayed under More Filters as expected");
			string labelOption = null;
			switch (label)
			{
				case "Retailer":
					labelOption = selMoreFilters.Retailer;
					break;
				case "Brand":
					labelOption = selMoreFilters.Brand;
					break;
				case "Additional Programs":
					labelOption = selMoreFilters.AdditionalPrograms;
					break;
			}
			if (labelOption == null)
			{
				Report.Failure($@"Specified label: ""{label}"" was unexpected! Expect 'Retailer', 'Brand' or 'Additional Programs'");
				return;
			}
			Report.Info("Label option for label  is: " + labelOption);
			Report.IsTrue(labelOption == option,
				$@"The option for label ""{label}"" was did not match the expected value! Expected ""{option}""  but found ""{labelOption}""",
				$@"The option for label ""{label}"" matched the expected value: ""{option}""");
		}

		[StepDefinition(@"I confirm all products in the grid contain either the the text ""(.*)"" or ""All"" under the 'Retailers' column")]
		public void ConfirmAllProductsInGridContainTextInRetailersColumn(string retailer)
		{
			List<ProductGridItem> allProducts = new ProductsGrid().GetAllProducts();
			var idsFail = allProducts.Where(x => !x.Retailers.Contains(retailer) && !x.Retailers.Contains($"{retailer}**") && !x.Retailers.Contains("All")).Select(x => x.ProductId).ToList();
			Report.IsTrue(idsFail.Count == 0,
				$@"Not all products in the grid contained either ""{retailer}"" or ""All"". Product Ids: {string.Join(", ", idsFail.Select(x => $"'{x}'").ToList())}",
				$@"All products in the grid contained either ""{retailer}"" or ""All""");
		}

		[StepDefinition(@"I click the first instance of Actions - Edit UPC in the products grid")]
		public void ClickFirstInstanceOfActionsEditUpcInProductsGrid()
		{
			Report.IsTrue(new ProductsGrid().ClickFirstActionsEditUpc(),
				"Failed to click Actions - Edit UPC",
				"Successfully clicked Actions - Edit UPC");
		}

		[StepDefinition(@"For product saved as: (.*) the status is: (.*)")]
		public void GivenForProductSavedAsTestCaseTheStatusIs(string savedAs, string status)
		{
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;

			var thisProductsGrid = new ProductsGrid();

			string statusColour = thisProductsGrid.GetRetailersStatusByID(id);

			if (status.ToLower() == "completed")
			{
				status = "Accepted by Retailers";
			}

			Report.IsTrue(statusColour == status, "Status is not correct. Expected: " + status + " but found: " + statusColour, "Status is as expected");
		}

		[StepDefinition(@"I confirm the Remove UPC Update popup displays the warning: (.*)")]
		public void IConfirmTheRemoveUpcUpdatePopupDisplaysTheWarning(string expectedWarning)
		{

			var removeUpc = new RemoveUpcUpdate();
			if (!removeUpc.WaitForContainerToBeVisible())
			{
				Report.Failure("The UPC Update popup was not displayed!");
				Report.Screenshot();
				return;
			}
			List<string> displayedWarnings = removeUpc.AlertWarningRows();
			if (displayedWarnings.Count == 0)
			{
				Report.Failure("The UPC Update popup did not contain any body error text!");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(displayedWarnings.Contains(expectedWarning),
				$@"The expected warning: ""{expectedWarning}"" was not displayed in the Remove UPC Update popup! Displayed warnings: {string.Join(", ", displayedWarnings.Select(x => $@"""{x}""").ToList())}",
				$@"The warning: ""{expectedWarning}"" was displayed as expected on the UPC Update popup");
		}

		[StepDefinition(@"I confirm the Remove UPC Update popup displays the name and ID for product saved as: (.*)")]
		public void IConfirmTheRemoveUpcUpdatePopupDisplaysTheNameAndIDForProductSavedAs(string savedAs)
		{
			var removeUpc = new RemoveUpcUpdate();
			if (!removeUpc.WaitForContainerToBeVisible())
			{
				Report.Failure("The UPC Update popup was not displayed!");
				Report.Screenshot();
				return;
			}
			List<string> displayedWarnings = removeUpc.AlertWarningRows();
			if (displayedWarnings.Count == 0)
			{
				Report.Failure("The UPC Update popup did not contain any body error text!");
				Report.Screenshot();
				return;
			}
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			if (product == null)
			{
				Report.Failure("Unable to find product saved in context as: " + savedAs);
				return;
			}
			Report.IsTrue(displayedWarnings.Any(x => x.Contains(product.Name) && x.Contains($"({product.Id})")),
				$@"The product name: ""{product.Name}"" and ID: ""{product.Id}"" were not dipslayed in the the Remove UPC Update popup! Displayed warnings: {string.Join(", ", displayedWarnings.Select(x => $@"""{x}""").ToList())}",
				$@"The product name: ""{product.Name}"" and ID: ""{product.Id}"" were displayed as expected on the UPC Update popup");
		}

		[StepDefinition(@"I confirm the Remove UPC Update popup has closed")]
		public void IConfirmTheUpcUpdatePopupHasClosed()
		{
			var upcUpdate = new RemoveUpcUpdate();
			if (!Report.IsTrue(upcUpdate.WaitForContainerToBeInvisible(), "The modal dialog did not close!", "The modal dialog closed as expected"))
			{
				if (upcUpdate.GetTitle() == "Remove UPC Update")
				{
					Report.Failure("The Remove UPC Update popup is still displayed");
				}
			}
		}

		[StepDefinition(@"I click 'All' under Retailers for the first product returned")]
		public void ClickAllRetailersForFirstProduct()
		{
			Delay.Seconds(3);
			Report.IsTrue(new ProductsGrid().ClickRetailerFirstRow("All"),
				"Failed to click 'All' under Retailers for the first product!",
				"Successfully clicked 'All' under Retailers for the first product");
		}

		[StepDefinition(@"I confirm the Retailers popup is (displayed|not displayed)")]
		public void ConfirmRetailerPopupIsDisplayedNotDisplayed(string isDisplayed)
		{
			bool displayed = new ProductsGrid().RetailerPopupDisplayed();
			switch (isDisplayed)
			{
				case "displayed":
					Report.IsTrue(displayed,
						"The retailers popup was not displayed when it was expected to be!",
						"The retailers popup was displayed as expected");
					return;
				case "not displayed":
					Report.IsTrue(!displayed,
						"The retailers popup was displayed when it was not expected to be!",
						"The retailers popup was not displayed as expected");
					return;
				default:
					Report.Info("The parameter did not match expected: 'displayed' or 'not displayed'");
					return;
			}
		}

		[StepDefinition(@"In The products Grid I Wait for the Retailers Popup to (appear|disappear)")]
		public void InTheProductsGridIWaitForRetailersPopupToAppearOrDisappear(string status)
		{

			switch (status)
			{
				case "appear":
					Report.IsTrue(new ProductsGrid().WaitForRetailerPopupToBeDisplayed(), "The retailers popup was not displayed when it was expected to be!", "The retailers popup was displayed as expected");
					return;
				case "disappear":
					Report.IsTrue(new ProductsGrid().WaitForRetailerPopupToNotBeDisplayed(), "The retailers popup was displayed when it was not expected to be!", "The retailers popup was not displayed as expected");
					return;
				default:
					Report.Info("The parameter did not match expected: 'appear' or 'disappear'");
					return;
			}
		}

		[StepDefinition(@"I click the products grid container")]
		public void ClickProductsGridContainer()
		{
			Report.Info("Refocus by clicking container element for products grid");
			new ProductsGrid().ClickContainer();
			Report.Screenshot();
		}

		[StepDefinition(@"I should (see|not see) the Archive Retailers Popup")]
		public void GivenIShouldSeeTheArchiveRetailersPopup(string condition)
		{
			var thisModalDialog = new ModalDialog();
			if (condition == "see")
			{
				if (thisModalDialog.WaitForContainerToBeVisible(5))
				{
					Report.IsTrue(thisModalDialog.GetTitle() == "Archive Retailers", "Dialog is not showing as expected",
						"Dialog is showing as expected");
					return;
				}
				else
				{
					Report.Failure("Archive Retailers dialog is not showing");
					return;
				}
			}
			if (condition == "not see")
			{
				if (thisModalDialog.WaitForContainerToBeVisible(5))
				{
					Report.IsTrue(thisModalDialog.GetTitle() != "Archive Retailers",
						"Dialog is showing", "Dialog is not showing");
					return;
				}
				else
				{
					Report.Success("Archive Retailers dialog is not showing");
					return;
				}
			}

		}

		[StepDefinition(@"In the Archive Retailers popup, I select the the checkbox next to the the first retailer and save the retailer as: (.*)")]
		public void GivenIInTheArchiveRetailersPopupSelectTheTheCheckboxNextToTheRetailerSYouWantToArchive(string savedAs)
		{
			var thisModalDialog = new ModalDialog();
			List<string> retailers = thisModalDialog.GetRetailers();
			string retailerToArchive = retailers[0];
			Report.IsTrue(thisModalDialog.SelectRetailer(retailerToArchive), "Failed to select: " + retailerToArchive,
				"Selected: " + retailerToArchive);
			Context.AddToContext(savedAs, retailerToArchive);
		}

		[StepDefinition(@"In the Archive Retailers popup, I select the checkbox next to the retailer (.*)")]
		public void InTheArchiveRetailersPopupSelectTheCheckboxNextToTheRetailer(string retailer)
		{
			var thisModalDialog = new ModalDialog();
			Report.IsTrue(thisModalDialog.SelectRetailer(retailer), "Failed to select: " + retailer,
				"Successfully selected: " + retailer);
		}

		[StepDefinition(@"In the Archive Retailers popup click on: (.*)")]
		public void GivenInTheArchiveRetailersPopupClickOn(string buttonToClick)
		{
			var thisModalDialog = new ModalDialog();
			Report.IsTrue(thisModalDialog.ClickButton(buttonToClick), "Failed to click " + buttonToClick, "Successfully clicked " + buttonToClick, showSuccessScreenshot: false);
			Delay.Seconds(3);
		}

		[StepDefinition(@"I handle the Alert for Archive by answering (Ok|Cancel)")]
		public void HandleTheAlertForArchiveByAnswering(string response)
		{
			Report.IsTrue(new ProductsGrid().ArchiveAlert(response), $"Selected {response} in Archive Alert.", $"Unable to select {response} in Archive alert.");
			string s = response;
		}

		[StepDefinition(@"I check that the Alert for Archiving a Retailers shows the text: (.*)")]
		public void CheckArchiveRetailerAlertText(string val)
		{
			Report.IsTrue(new ProductsGrid().GetArchiveAlertText() == val, "The alert text did not match", "The alert text was a match", showSuccessScreenshot: false);
		}

		[StepDefinition(@"I ensure that the check box next to Show Archived Retailers is unselected")]
		public void EnsureShowArchivedRetailersCheckboxIsUnchecked()
		{
			var thisProductsGrid = new ProductsGrid();
			bool status = thisProductsGrid.IsShowArchivedRetailersChecked();
			if (status)
			{
				Report.Info($"The checkbox was checked, we need to uncheck it now");
				Report.Screenshot();
				this.GivenISelectTheCheckBoxNextToShowArchivedRetailers("Select");
				Report.IsTrue(!thisProductsGrid.IsShowArchivedRetailersChecked(), "The checkbox was still checked", "The checkbox was unchecked");
			}
			else
			{
				Report.Success($"The checkbox was already unchecked. No action needed");
				Report.Screenshot();
			}

		}

		[StepDefinition(@"I (Select|Deselect) the check box next to Show Archived Retailers")]
		public void GivenISelectTheCheckBoxNextToShowArchivedRetailers(string selectOrDeselect)
		{
			var thisProductsGrid = new ProductsGrid();

			if (selectOrDeselect.ToLower() == "select")
			{
				Report.IsTrue(thisProductsGrid.SelectShowArchivedRetailers(),
					"Failed to click show archived retailers checkbox", "Clicked show archived retailers checkbox");
			}
			else
			{
				Report.IsTrue(thisProductsGrid.DeselectShowArchivedRetailers(),
					"Failed to deselect show archived retailers checkbox", "Deselected show archived retailers checkbox");
			}


		}

		[StepDefinition(@"I save the ProductID and Name of the first Product in the grid with a retailer as: (.*)")]
		public void SaveFirstProductInGridWithARetailer(string savedAs)
		{
			Report.Info("Saving Product ID and Name of First Product as " + savedAs);
			var selProdGrid = new ProductsGrid();
			ProductGridItem productElement = selProdGrid.FirstProductInGridWithRetailers();
			if (productElement == null)
			{
				Report.Failure("No results were returned in the grid");
				Report.Screenshot();
				return;
			}
			Context.AddToContext(savedAs, productElement);
			Report.Success("Got the first Product in Grid (ID: " + productElement.ProductId + ") and saved to: " + savedAs);
			Report.Info("Filtering on product id: " + productElement.ProductId);
			selProdGrid.ProductIdField = productElement.ProductId;
			selProdGrid.ClickProductIdNameSearchButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.Screenshot();
		}

		[StepDefinition(@"I save the ProductID and Name of the first Product in the grid with a retailer as Product Information, saved as: (.*)")]
		public void SaveFirstProductInGridWithARetailerAsProductInformation(string savedAs)
		{
			Report.Info("Saving Product ID and Name of First Product as " + savedAs);
			var selProdGrid = new ProductsGrid();
			ProductGridItem productElement = selProdGrid.FirstProductInGridWithRetailers();
			if (productElement == null)
			{
				Report.Failure("No results were returned in the grid");
				Report.Screenshot();
				return;
			}
			var productInformation = new ProductInformation() { Id = productElement.ProductId, Name = productElement.ProductName };
			Context.AddToContext(savedAs, productInformation);
			Report.Success("Got the first Product in Grid (ID: " + productElement.ProductId + ") and saved to: " + savedAs);
			Report.Info("Filtering on product id: " + productElement.ProductId);
			selProdGrid.ProductIdField = productElement.ProductId;
			selProdGrid.ClickProductIdNameSearchButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.Screenshot();
		}

		[StepDefinition(@"I check for all items in the grid that the retailers are alphabetically listed")]
		public void GivenISaveTheProductIDAndNameOfTheFirstProductInTheGridWithMoreThanOneRetailerAs()
		{

			try
			{
				var selProdGrid = new ProductsGrid();
				List<ProductGridItem> allItems = selProdGrid.GetAllItemsInGrid();
				foreach (ProductGridItem thisItem in allItems)
				{
					Report.IsTrue(thisItem.Retailers.OrderBy(x => x).SequenceEqual(thisItem.Retailers),
						"Item: " + thisItem.ProductId + " does not have retailers alphabetically listed",
						"Item: " + thisItem.ProductId + " has retailers alphabetically listed");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I Confirm that two asterisks are visible in the retailer\(s\) saved as: (.*) that are archived icons that display")]
		public void GivenIConfirmThatTwoAsterisksAreVisibleInTheRetailerSThatAreArchivedIconsThatDisplay(string savedAs)
		{
			if (Context.Contains(savedAs))
			{
				string archivedRetailer = Context.GetFromContext(savedAs).ToString();
				var selProdGrid = new ProductsGrid();
				ProductGridItem productElement = selProdGrid.FirstProductInGrid();
				List<string> retailers = productElement.Retailers;
				string abbreviatedRetailer = "";
				if (retailers.Contains(archivedRetailer))
				{
					for (int i = 0; i < retailers.Count; i++)
					{
						if (retailers[i] == archivedRetailer)
						{
							abbreviatedRetailer = productElement.RetailerAbrv[i];
						}
					}
				}

				if (abbreviatedRetailer.Length > 0)
				{
					Report.IsTrue(abbreviatedRetailer.Contains("**"), "Retailer is not showing as expected",
						"Retailer is showing as expected");
				}
				else
				{
					Report.Error("Retailer is not showing as expected");
				}

			}
			else
			{
				Report.Error("No retailer is saved into context");
			}

		}

		[StepDefinition(@"I Confirm that the retailer\(s\) saved as: (.*) are not displayed for the first product in the grid.")]
		public void ConfirmRetailersNotDisplayedForFirstProductInGrid(string savedAs)
		{
			if (Context.Contains(savedAs))
			{
				string archivedRetailer = Context.GetFromContext(savedAs).ToString();
				var selProdGrid = new ProductsGrid();
				ProductGridItem productElement = selProdGrid.FirstProductInGrid();
				List<string> retailers = productElement.Retailers;
				if (retailers.Contains(archivedRetailer))
				{
					Report.Failure($"The archieved retailer was still found under the product.");
					return;
				}
				Report.Success($"The arhcieved retailer was not found for the product in the product.");
				return;



			}
			else
			{
				Report.Error("No retailer is saved into context");
			}

		}



		[StepDefinition(@"I should see the View UPCs page")]
		public void WhenIShouldSeeTheViewUPCsPage()
		{
			Context.ScenarioContext.Pending();
		}

		[StepDefinition(@"I should see the Update Registration popup")]
		public void IShouldSeeTheUpdateRegistrationPopup()
		{
			var thisModalDialog = new ModalDialog();
			Report.IsTrue(thisModalDialog.WaitForContainerToBeVisible(30), "Modal dialog has not opened as expected",
				"Modal dialog is showing");
			Report.IsTrue(thisModalDialog.GetTitle() == "Update Registration",
				"Update registration is not showing as expected", "Update registration dialog is showing as expected");
		}

		[StepDefinition(@"In the Update Registration popup I click on button (Cancel|View|Yes|Continue)")]
		public void InUpdateRegistrationPopupIClickButton(string button)
		{
			var thisModalDialog = new ModalDialog();
			Report.IsTrue(thisModalDialog.WaitForContainerToBeVisible(30), "Modal dialog has not opened as expected",
				"Modal dialog is showing");
			Report.IsTrue(thisModalDialog.ClickButton(button.ToUpper()),
				"Failed to click button: " + button.ToUpper(), "Clicked " + button.ToUpper());
			Delay.Seconds(1);
		}

		[StepDefinition(@"I confirm that the label: '(.*)' is displayed next to the Product Name for the top result in the grid")]
		public void ConfirmThatTheProductNameLabelIsDisplayed(string label)
		{
			Report.Info("Getting first product in the grid");
			ProductGridItem product = new ProductsGrid().FirstProductInGrid();
			if (product == null)
			{
				Report.Failure("No products were found in the grid!");
				Report.Screenshot();
				return;
			}
			Report.Info("Checking the top product Name label");
			Report.IsTrue(product.NameLabel == label, $"The '{label}' label was not displayed next to the product name for the top result!", $"The '{label}' label was displayed next to the product name for the top result");
		}

		[StepDefinition(@"I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers")]
		public void GivenIConfirmTheProductsShownAreGreen()
		{
			Report.IsTrue(new ProductsGrid().AllRetailersAreShowingStatus("Accepted by Retailers"), "All products are not showing as Accepted By Retailers", "All products are showing as Accepted By Retailers");
		}


		[StepDefinition(@"I Confirm the Products shown display at least one retailer with the Green Colour Status - which is the Accepted by Retailers")]
		public void GivenIConfirmTheProductsShownHaveAtLeastOneGreen()
		{
			Report.IsTrue(new ProductsGrid().AtLeastOneRetailerPerProductShowingStatus("Accepted by Retailers"), "All products are not showing as Accepted By Retailers for at least one of their retailers", "All products are showing as Accepted By Retailers for at least one of their retailers");
		}

		[StepDefinition(@"I Confirm the Products shown display the Blue Colour Status - which is the Sending to Retailers")]
		public void GivenIConfirmTheProductsShownAreBlue()
		{
			Report.IsTrue(new ProductsGrid().AllRetailersAreShowingStatus("Sending to Retailers"), "All products are not showing as Accepted By Retailers", "All products are showing as Accepted By Retailers");
		}

		[StepDefinition(@"I edit the product saved as: (.*)")]
		public void EditProductSavedAs(string productSavedAs)
		{
			var productInformation = (ProductInformation)Context.GetFromContext(productSavedAs);
			var editID = productInformation.Id;
			this.EditFirstProductForRetailer(editID);
		}

		[StepDefinition(@"I save the ProductID of the first Product in the grid as: (.*)")]
		public void SaveFirstProductIDInGrid(string savedAs)
		{
			Report.Info("Saving the ID of First Product as " + savedAs);
			var selProdGrid = new ProductsGrid();
			ProductGridItem productElement = selProdGrid.FirstProductInGrid();
			string firstProductID = productElement.ProductId;

			Context.AddToContext(savedAs, firstProductID);
			Report.Success("Got the first Product ID in Grid (ID: " + firstProductID + ") and saved to: " + savedAs);
		}

		[StepDefinition(@"If my products grid does not contain enough products then I add them until it displays '...' grid navigation option")]
		public void AddProductsInMyProductsGrid()
		{
			Report.UseSubSteps = true;
			var selProdGrid = new ProductsGrid();
			var newStepsProd = new Steps_ProductSetup();
			var homePage = new StepsHomepage();
			var productsGrid = new ProductsGrid();
			Report.Info("setting the Items on Page to '10'");
			Report.IsTrue(productsGrid.SelectItemsOnPage("10"), "Failed to set items on page to 10", "successfully set the items on page to 10");
			try
			{
				if (selProdGrid.ProductsCount() >= 10 && selProdGrid.GetGridNavDots())
				{
					Report.Info("My products grid already contains more than 10 products along with '...' grid navigation option for pagination!");
				}
				else
				{
					for (int id = 0; id <= 91; id++)
					{
						Report.Info("Adding product-" + (id + 1) + " in my products grid");
						newStepsProd.TaketoProductTypeandSave("sample product-" + (id + 1), "chalkproduct");
					}
					homePage.ThenINavigateToTheHomePage();
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
			}
		}
		[StepDefinition(@"I generate: (.*) random UPC numbers and save them starting with: (.*)")]
		public void GivenIGenerateXRandomUPCNumberAndSaveAs(int numbersWanted, string savedAs)
		{
			int i = 1;
			while (i <= numbersWanted)
			{
				//string uPCNo = new UpcFunctions().GenerateUPC();
				string uPCNo = GeneralFunctions.GenerateUPCNumber();
				Context.AddToContext(savedAs + i, uPCNo);
				Report.Info("Generated UPC No " + i + ": " + uPCNo);
				Delay.Seconds(0.5);
				i++;
			}

		}

		[StepDefinition(@"I confirm the Rejected Registration popup displays the warning: (.*)")]
		public void IConfirmTheRejectedRegistrationPopupDisplaysTheWarning(string expectedWarning)
		{
			var modalDialog = new ModalDialog();

			if (!modalDialog.WaitForContainerToBeVisible())
			{
				Report.Failure("The Rejected Registration popup was not displayed!");
				Report.Screenshot();
				return;
			}
			List<string> displayedWarnings = modalDialog.AlertWarningRows();
			if (displayedWarnings.Count == 0)
			{
				Report.Failure("The Rejected Registration popup did not contain any body error text!");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(displayedWarnings.Contains(expectedWarning),
				$@"The expected warning: ""{expectedWarning}"" was not displayed in the Rejected Registration popup! Displayed warnings: {string.Join(", ", displayedWarnings.Select(x => $@"""{x}""").ToList())}",
				$@"The warning: ""{expectedWarning}"" was displayed as expected on the Rejected Registration popup");
		}

		[StepDefinition(@"I confirm the Rejected Registration popup has closed")]
		public void IConfirmTheRejectedRegistrationPopupHasClosed()
		{
			var modalDialog = new ModalDialog();

			if (!Report.IsTrue(modalDialog.WaitForContainerToBeInvisible(), "The modal dialog did not close!", "The modal dialog closed as expected"))
			{
				if (modalDialog.GetTitle() == "Rejected Registration")
				{
					Report.Failure("The Rejected Registration popup is still displayed");
				}
			}
		}

		[StepDefinition(@"in the Rejected Registration modal dialog I click Continue")]
		public void GivenInTheModalDialogIClickButton()
		{

			Report.IsTrue(new ModalDialog().Click_Continue(), "Failed to click the Continue button", "Successfully clicked Continue");

		}

		[StepDefinition(@"In the Products Grid I delete All products")]
		public void InTheProductsGridIDeleteAllProducts()
		{
			Report.IsTrue(new ProductsGrid().DeleteAllPresentRows(), "Failed to delete all products!", "All matching products deleted successfully!");
		}

		[StepDefinition(@"I navigate to the Homepage and then In the Products Grid I delete All products")]
		public void INavigateToTheHomepageThenInTheProductsGridIDeleteAllProducts()
		{

			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();
			Report.IsTrue(new ProductsGrid().DeleteAllPresentRows(), "Failed to delete all products!", "All matching products deleted successfully!");
		}


		[StepDefinition(@"I save the ProductID of the first Product in the grid no in recertification as: (.*)")]
		public void SaveFirstProductIDInGridNotRecert(string savedAs)
		{
			Report.Info("Saving the ID of First Product as " + savedAs);
			var selProdGrid = new ProductsGrid();
			ProductGridItem productElement = selProdGrid.FirstProductNotRecertInGrid();
			string firstProductID = productElement.ProductId;

			Context.AddToContext(savedAs, firstProductID);
			Report.Success("Got the first Product ID in Grid (ID: " + firstProductID + ") and saved to: " + savedAs);
		}


		[StepDefinition(@"I click the 'Show Only Discontinued Products' checkbox in the 'My Products' grid")]
		public void ThenIClickTheShowOnlyDiscontinuedProductsCheckboxInTheMyProductsGrid()
		{
			MoreFilters moreFiltersObject = new MoreFilters();
			Report.IsTrue(moreFiltersObject.ClickShowOnlyDiscontinuedProductsCheckbox(), "Failed to click checkbox", "Successfully clicked checkbox");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I confirm that only discontinued products appear in the 'My Products' grid")]
		public void ThenIConfirmThatOnlyDiscontinuedProductsAppearInTheMyProductsGrid()
		{
			MoreFilters moreFiltersObject = new MoreFilters();
			Report.Info("There were " + moreFiltersObject.CheckTheAmountOfProductsInProductsGrid() + " discontinued products displayed");
		}

		[StepDefinition(@"I confirm that only Single-Retailer products appear in the 'My Products' grid")]
		public void OnlySingleRetailerProductsAppear()
		{
			var newProdGrid = new ProductsGrid();
			if (Report.IsTrue(newProdGrid.ProductListExists(), "Failed to get Products list", "Successfully got Products list"))
			{
				Report.IsTrue(newProdGrid.OnlySingleRetailerProductsInProductGrid(), "Failed to confirm only only Products with Single Retailer next to the Product ID show in My Products", "Successfully confirmed only only Products with Single Retailer next to the Product ID show in My Productst");
			}
		}

		[StepDefinition(@"I click the (.*) checkbox in the 'My Products' grid")]
		public void ThenIClickTheCheckboxInTheMyProductsGrid(string checkbox)
		{
			MoreFilters moreFiltersObject = new MoreFilters();
			if (Report.IsTrue(moreFiltersObject.CheckboxExists(checkbox), $"Failed to find checkbox {checkbox}", $"Successfully found checkbox {checkbox}"))
			{
				Report.IsTrue(moreFiltersObject.ClickCheckboxInProductGrig(checkbox), $"Failed to click checkbox {checkbox}", $"Successfully clicked checkbox {checkbox}");
				Delay.Seconds(5);
			}
		}

		[StepDefinition(@"In Product Grid I confirm if the checkbox (.*) is (selected|not selected)")]
		public void ConfirmCheckboxInProductGridIsSelected(string checkbox, string condition)
		{
			MoreFilters moreFiltersObject = new MoreFilters();

			if (condition == "selected")
			{
				Report.IsTrue(moreFiltersObject.CheckCheckboxIsSelected(checkbox), $"{checkbox} checkbox is not selected, but should be", $"{checkbox} checkbox is selected as expected");
				Report.Screenshot();
			}
			else
			{
				Report.IsFalse(moreFiltersObject.CheckCheckboxIsSelected(checkbox), $"{checkbox} checkbox is selected, but should not be", $"{checkbox} checkbox is not selected, as expected");
				Report.Screenshot();
			}
		}

		[StepDefinition(@"I click the Clear button in the More Filters section")]
		public void ThenIClickClearInTheMyProductsGrid()
		{
			MoreFilters moreFiltersObject = new MoreFilters();
			if (Report.IsTrue(moreFiltersObject.ClearButtonExists(), "Failed to find The Clear Button", "Successfully found The Clear Button"))
			{
				Report.IsTrue(moreFiltersObject.ClickClearFilterButtonInMoreFilters(), "Failed to click The Clear Button", "Successfully clicked The Clear Button");
				Delay.Seconds(5);
			}
		}
		[StepDefinition(@"I confirm More Filters section (is|is not) expended")]
		public void ThenIConfirmMoreFiltersSectionIsExpended(string condition)
		{
			MoreFilters moreFiltersObject = new MoreFilters();

			if (condition == "is")
			{
				Report.IsTrue(moreFiltersObject.MoreFiltersExpanded(), "Failed to confirm More Filters section is expended", "Successfully confirmed More Filters section is expended");
				Report.Screenshot();
			}
			else
			{
				Report.IsFalse(moreFiltersObject.MoreFiltersExpanded(), "Failed to confirm More Filters section is not expended", "Successfully confirmed More Filters section is not expended");
				Report.Screenshot();
			}

		}


		[StepDefinition(@"I confirm that all products appear in the 'My Products' grid")]
		public void ThenIConfirmThatAllProductsAppearInTheMyProductsGrid()
		{
			MoreFilters moreFiltersObject = new MoreFilters();
			Report.Info("There were " + moreFiltersObject.CheckTheAmountOfProductsInProductsGrid() + " products displayed");
			Report.Screenshot();
		}


		[StepDefinition(@"I make sure product saved as: (.*) (should|should not) missing from the product list")]
		public void ThenIMakeSureProductSavedAsSelectedProductIsMissingFromTheProductList(string savedAs, string shouldOrShouldNot)
		{
			Delay.Seconds(10);
			GeneralUtilities.Wait_for_load_finish();
			MoreFilters moreFiltersObject = new MoreFilters();
			DeleteActiveProducts deleteActiveProductsObject = new DeleteActiveProducts();
			savedAs = deleteActiveProductsObject.GetProductIDFromContext(savedAs);

			if (shouldOrShouldNot.ToLower() == "should")
			{
				Report.IsTrue(moreFiltersObject.CheckIfProductIsMissing(savedAs.ToString()), "The following product WPS ID: " + savedAs + " should be missing but it was found in the product list", "The following product WPS ID: " + savedAs + " was expected to be missing from the product list and it was");
			}
			else if (shouldOrShouldNot.ToLower() == "should not")
			{
				Report.IsTrue(!moreFiltersObject.CheckIfProductIsMissing(savedAs.ToString()), "The following product WPS ID: " + savedAs + " should not be missing but it was found in the product list", "The following product WPS ID: " + savedAs + " was expected to be found in the product list and it was");
			}
		}

		[StepDefinition(@"I make sure products saved as: (.*) are missing from the product list")]
		public void ThenIMakeSureProductsSavedAsSelectedProductsAreMissingFromTheProductList(string savedAs)
		{
			MoreFilters moreFiltersObject = new MoreFilters();
			var list = Context.GetFromContext(savedAs).ToString();
			string[] listSplit = list.Split(',');

			foreach (string listItem in listSplit)
			{
				Report.IsTrue(moreFiltersObject.CheckIfProductIsMissing(listItem), "The following product WPS ID: " + savedAs + " should be missing but it was found in the product list", "The following product WPS ID: " + savedAs + " was expected to be missing from the product list and it was");
			}
		}

		[StepDefinition(@"Check popup date productID: (.*) productType: (.*) productAccessCode: (.*)")]
		public void ThenCheckPopupDate(string productID, string productType, string productAccessCode)
		{

			RetailPartners retailPartnersObject = new RetailPartners();
			string savedAs = productID;
			try
			{

				if (!Context.Contains(savedAs))
				{
					Report.Failure("The reference: " + savedAs + " was not found in context");
					return;
				}

				string id = "";

				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					id = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}

				//if we didn't get the id try a different object type
				if (id == "")
				{
					try
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
					catch (Exception)
					{
						//do nothing
					}

				}

				if (id == "")
				{
					try
					{
						id = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{

					}
				}

				Report.Info("ProductID: " + id + " ProductType: " + productType + " ProductAccessCode: " + productAccessCode);
				Report.IsTrue(new ModalDialog().CheckProductInformationIn3rdPartyAccessCodeWindowInProductsGrid(id, productType, productAccessCode), "Failed to match product information", "Successfully matched product information");

			}
			catch (Exception ex)
			{

				Report.Failure(ex.Message);
				throw;
			}

		}

		[StepDefinition(@"I confirm I see the Product ID, Ingredient ID, SKU field above the Product Grid")]
		public void IConfirmProductIDIngredientIDSKUFieldIsFound()
		{
			var selProductGridMoreFilters = new MoreFilters();

			Report.IsTrue(selProductGridMoreFilters.ProductIDIngredientIDSKUFieldIsFound(), "The field was not found", "The field was found");
		}



		[StepDefinition(@"In the Product ID, Ingredient ID, SKU filter field I search for: (.*)")]
		public void GivenInTheProductIDIngredientIDSKUFilterFieldISearchFor(string savedAs)
		{

			try
			{
				Report.Info("Searching for Product Saved as " + savedAs);

				if (!Context.Contains(savedAs))
				{
					Report.Failure("The reference: " + savedAs + " was not found in context");
					return;
				}

				string id = "";

				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					id = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}

				//if we didn't get the id try a different object type
				if (id == "")
				{
					try
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
					catch (Exception)
					{
						//do nothing
					}

				}

				if (id == "")
				{
					try
					{
						id = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{

					}
				}

				var selProductGridMoreFilters = new MoreFilters();

				selProductGridMoreFilters.ProductIDIngredientIDSKU = id;
				Report.IsTrue(selProductGridMoreFilters.ProductIDIngredientIDSKU == id,
				"Value: " + id + " was not inputted into the Product ID, Ingredient ID, SKU field correctly!",
				"Value: " + id + " was correctly inputted into the Product ID, Ingredient ID, SKU field", false, false);

				//Report.IsTrue(new ProductsGrid().InProductIDIngredientIDSKUFilterFieldSearchFollowingText(id),
				//"Failed to enter text in 'Product ID, Ingredient ID, SKU' above the products grid",
				//"Successfully entered text in 'Product ID, Ingredient ID, SKU' above the products grid");

				Report.IsTrue(new ProductsGrid().ClickProductIDIngredientIDSKUSearchButton(),
					"Failed to select search button next to 'Product ID, Ingredient ID, SKU' above the products grid",
					"Successfully selected search button next to 'Product ID, Ingredient ID, SKU' above the products grid");

				GeneralUtilities.Wait_for_load_finish();
				Delay.Seconds(10);

				Report.Info("ID searched for: '" + id + "'");
				var selProdGrid = new ProductsGrid();
				Report.IsTrue(selProdGrid.ProductsCount() == 1, "More than one entry was found!", "Only one entry was found, as expected!");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}

		}

		[StepDefinition(@"I enter (.*) differnt but valid random filter combinations in the Products Grid and expect to see the product saved as: (.*) each time")]
		public void IEnterXValidFilterCombinationsAndSeeExpectedProduct(int totalCombinations, string savedAs)
		{
			//Andrew - This step is currently not finished 
			//1566006

			//Using our product filter data saved in context (valid filters that will find the product) enter in valid filter data for each of the randomly selected filters in the array.
			//once filters entered, wait for grid to load fully
			//search the results displayed for our product ID (from context), may need to check all pages etc.
			//If found, Report a success and continue the remaining loops. If not  = fail but dont return at this point.

			int x = 0;
			while (x < totalCombinations)
			{
				Random random = new Random();
				int filtersToUse = random.Next(2, 5);
				//update so 5 = count of possible filters +1

				string[] chosenFilters = new string[filtersToUse];

				var possibleFilters = new List<string> {
				"UPC",
				"Brand",
				"Retailer",
				"Additional Programs"};

				for (int b = 0; b < filtersToUse; b++)
				{
					bool addedToArray = false;
					int y = 0;
					while (addedToArray == false && y < 30)
					{
						//if filtersToUse == possibleFilters.Count() then just grab all filters (no point being randomly selected)
						//remove +1 from randomInt as possible filters is zero base? 0-3
						int randomInt = random.Next(0, possibleFilters.Count());
						bool foundInArray = chosenFilters.Contains(possibleFilters[randomInt]);
						if (foundInArray == false)
						{
							chosenFilters[b] = possibleFilters[randomInt];
							addedToArray = true;
						}

						y++;

					}
					if (addedToArray == false)
					{
						Report.Failure($"Failed to add filter to the array of filters");
						return;
					}


				}

				var selProductsGrid = new ProductsGrid();
				var selMoreFilters = new MoreFilters();

				MoreFilters.FilterInformation filterInfo = new MoreFilters.FilterInformation();
				var obj = (MoreFilters.FilterInformation)Context.GetFromContext(savedAs);
				filterInfo = obj;



				foreach (var item in chosenFilters)
				{
					string optionSelected = "";
					switch (item)
					{
						case "UPC":
							selProductsGrid.UpcNumber = filterInfo.UPC;
							selProductsGrid.ClickUpcNumberSearchButton();
							optionSelected = filterInfo.UPC;
							Delay.Seconds(10);
							GeneralUtilities.Wait_for_load_finish();
							break;
						case "Brand":
							selMoreFilters.Brand = filterInfo.Brand;
							optionSelected = filterInfo.Brand;
							break;
						case "Retailer":
							selMoreFilters.Retailer = filterInfo.Retailer;
							optionSelected = filterInfo.Retailer;
							break;
						case "Additional Programs":
							selMoreFilters.AdditionalPrograms = filterInfo.AdditionalPrograms;
							optionSelected = filterInfo.AdditionalPrograms;
							break;
					}
					Report.Info("I set the " + item + " to: " + optionSelected);


				}

				Delay.Seconds(10);
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Looking for product ID: " + filterInfo.Id);
				Report.IsTrue(selProductsGrid.AllIDsInGrid().Contains(filterInfo.Id) == true,
					"The product ID: " + filterInfo.Id + (true ? " did not appear " : " appeared") + " when it " + (true ? "should have" : "should not not have"),
					"The product ID: " + filterInfo.Id + (true ? " appeared" : " did not appear") + " in the grid as expected");
				Report.Info("Clearing search criteria");
				selProductsGrid.UpcNumber = "";
				selProductsGrid.ClickUpcNumberSearchButton();
				selProductsGrid.ClickClear();
				GeneralUtilities.Wait_for_load_finish();


			}



		}

		[StepDefinition(@"I create a object of FilterInformation from the table below: and save it as: (.*)")]
		public void CreateFilterInformationObjectFromTable(string savedAs, Table table)
		{
			MoreFilters.FilterInformation filterInfo = new MoreFilters.FilterInformation();
			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "Brand")
				{
					filterInfo.Brand = row["Variable"];
				}
			}
			Report.IsTrue(filterInfo.Brand != null, "did not set filter: 'Brand'", "Succesffully set filter: 'Brand'");

			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "Retailer")
				{
					filterInfo.Retailer = row["Variable"];
				}
			}
			Report.IsTrue(filterInfo.Retailer != null, "did not set filter: 'Retailer'", "Succesffully set filter: 'Retailer'");

			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "Additional Programs")
				{
					filterInfo.AdditionalPrograms = row["Variable"];
				}
			}
			Report.IsTrue(filterInfo.AdditionalPrograms != null, "did not set filter: 'Additional Programs'", "Succesffully set filter: 'Additional Programs'");

			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "UPC")
				{
					if (row["Variable"].Contains("UPC Saved As"))
					{
						string UPCSavedAs = row["Variable"];
						string edited = UPCSavedAs.Replace("UPC Saved As", "").Trim();
						string foundUPC = (string)Context.GetFromContext(edited);
						if (foundUPC.IsNullOrEmpty())
						{
							Report.Failure($"The UPC was not found in context...");
							return;
						}
						filterInfo.UPC = foundUPC;
					}
					else
					{
						filterInfo.UPC = row["Variable"];

					}

				}
			}

			Report.IsTrue(filterInfo.UPC != null, "did not set filter: 'UPC'", "Succesffully set filter: 'UPC'");

			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "ID")
				{
					if (row["Variable"].Contains("ID Saved As"))
					{
						string UPCSavedAs = row["Variable"];
						string edited = UPCSavedAs.Replace("ID Saved As", "").Trim();
						var foundInfo = (ProductInformation)Context.GetFromContext(edited);
						if (foundInfo.IsNullOrEmpty())
						{
							Report.Failure($"The product Information was not found in context...");
							return;
						}
						filterInfo.Id = foundInfo.Id;
					}
					else
					{
						filterInfo.Id = row["Variable"];

					}

				}
			}
			Report.IsTrue(filterInfo.Id != null, "did not set filter: 'Id'", "Succesffully set filter: 'Id'");

			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "Status")
				{
					filterInfo.Status = row["Variable"];
				}
			}
			Report.IsTrue(filterInfo.Status != null, "did not set filter: 'Status'", "Succesffully set filter: 'Status'");

			foreach (var row in table.Rows)
			{
				if (row["FilterType"] == "Name")
				{
					filterInfo.Name = row["Variable"];
				}
			}
			Report.IsTrue(filterInfo.Name != null, "did not set filter: 'Name'", "Succesffully set filter: 'Name'");

			Context.AddToContext(savedAs, filterInfo);
		}


		[StepDefinition(@"I search the Products grid for the Name: (.*) and save the first grid item ID as: (.*) and UPC as: (.*)")]
		public void SearchProductsGridForProductByNameAndSaveIDAndUPC(string name, string iDSavedAs, string uPCSavedAs)
		{
			Report.UseSubSteps = true;
			Report.StartStep("Searching for product: " + name);
			var selProdGrid = new ProductsGrid {
				ProductIdField = name
			};
			GeneralUtilities.Wait_for_load_finish();
			ProductGridItem productElement = selProdGrid.FirstProductInGrid();
			ProductInformation productInfo = new ProductInformation {
				Id = productElement.ProductId
			};
			if (productElement != null)
			{
				Report.StartStep("Saving the top product as: " + iDSavedAs);
				Context.AddToContext(iDSavedAs, productInfo);
				Report.Info("Saved product to context");

				Context.AddToContext("ProductGridItemInfo", productElement);
				Report.Info("Saved ProductGridItemInfo to context");

				var SPG = new StepsProductGrid();
				SPG.IClickRowActionsForTheProductSavedAs("ProductGridItemInfo");
				SPG.ClickRowAction("View UPCs");
				new GlobalSteps().SwitchToTabWithTitle("View UPCs");
				Delay.Seconds(5);
				new Steps_ViewUpcs().SaveFirstUpcNumberToContext(uPCSavedAs);
				new GlobalSteps().SwitchToTabWithTitle("WERCSmart Version 2.0");
				Report.Info("Saved UPC number to context");
			}
			else
			{
				Report.Info("No Product was found by name: " + name);
			}
			selProdGrid.ProductIdField = string.Empty;
		}


		[StepDefinition(@"I filter for the ingredient saved as: (.*)")]
		[StepDefinition(@"I search for the ingredient saved as: (.*)")]
		public void GivenISearchForTheIngredientSavedAs(string savedAs)
		{
			Report.StartStep(Report.Details.StepIndex + " - Searching for Ingredient Saved as " + savedAs);
			try
			{
				Report.Info("Searching for Ingredient Saved as " + savedAs);

				if (!Context.Contains(savedAs))
				{
					Report.Failure("The reference: " + savedAs + " was not found in context");
					return;
				}

				string id = "";

				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					id = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}

				//if we didn't get the id try a different object type
				if (id == "")
				{
					try
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
					catch (Exception)
					{
						//do nothing
					}

				}

				if (id == "")
				{
					try
					{
						id = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{

					}
				}

				Report.Info("Searching for Ingredient with ID: '" + id + "'");
				var selProdGrid = new ProductsGrid {
					ProductIdField = id
				};
				GeneralUtilities.Wait_for_load_finish();
				Delay.Seconds(10);
				Report.IsTrue(selProdGrid.ProductsCount() == 1, "No ingredients were returned for ID: '" + id + "'!", "Product was returned!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that when hover over on the Single Retailer : (.*) message is showing")]
		public void IConfirmTheMessageForSingleRetailer(string message)
		{
			try
			{
				var selMoreFilters = new MoreFilters();
				string MessageShowing = selMoreFilters.ConfirmMessageForSingleRetailerRA();
				Report.IsTrue(MessageShowing == message,
					$"Tier information was showing: '{ MessageShowing }', but was expected to show: '{ message }'",
					$"Tier information was showing: '{ MessageShowing }', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I confirm that the indicator Single Retailer RA is showing above No Retailer and Rite Aid")]
		public void IConfirmForTheIndicatorSingleRetailerRA()
		{
			var selMoreFilters = new MoreFilters();
			Report.IsTrue(selMoreFilters.ConfirmTheIndicatorSingleRetailerRA(), "The indicator Single Retailer RA is not showing above No Retailer and Rite Aid", "The indicator Single Retailer RA is showing above No Retailer and Rite Aid");
		}

		[StepDefinition(@"I Click on the ADDITIONAL PROGRAMS drop down and confirm options should be available under Additional Programs")]
		public void IClickOnAdditionalPrograms()
		{
			var selMoreFilters = new MoreFilters();
			Report.IsTrue(selMoreFilters.ClickAdditionalPrograms(), "Failed to click on Additional Programs dropdown", "Successfully clicked Additional programs dropdown");
			Report.IsTrue(selMoreFilters.ConfirmAdditionalProgramsDropdownOpen(), "Failed to dispaly Additional Programs dropdown", "Successfully Additional programs dropdown displayed");
			List<string> isStringContained = selMoreFilters.GetDataOfAdditionalPrograms();
			Report.IsTrue(isStringContained.All(x => (new[] { "None", "California Cleaning SB 258", "California Cosmetic Fragrance/Flavor SB 312", "Distributor Product - Approved", "Distributor Product - Pending Approval", "Distributor Product - Rejected", "Target Sustainability Product Index" }).Contains(x)), "Failed to find the expected option under Additional Programs", "Successfully found the expected options under Additional programs");

		}
	}
}

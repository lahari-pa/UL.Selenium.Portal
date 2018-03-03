using System;
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
				Report.Screenshot();
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Cancelling the delete dialog");
			try
			{
				Report.Info("Cancelling the delete dialog");
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
				Report.IsTrue(selProdGrid.ClickFilterOption(filter), "Failed to click filter option: '" + filter + "'", "Successfully filtered grid by: '" + filter + "'");
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

		[StepDefinition(@"I click (Forward Product Registration|Sync Products to WERCSlink|Accept Documents|Download Reports|Delete Products) in the Bulk Actions window")]
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
	}
}

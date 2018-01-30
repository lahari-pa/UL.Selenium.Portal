using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using SafewareSeleniumUtilities;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ProductGrid")]
	class Steps_ProductGrid
	{
		[StepDefinition(@"I should see an option for (More Filters|Product ID/Name|Bulk Actions)")]
		public void GivenIShouldSeeAnOptionFor(string field)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that option " + field + " is present");
			try
			{
				Report.Info("Checking that option " + field + " is present");
				var Sel_ProdGrid = new ProductsGrid();

				switch (field)
				{
					case ("More Filters"):
						Report.IsTrue(Sel_ProdGrid.MoreFiltersOptionPresent(), field + " option was not showing as expected!", field + " option was showing as expected!");
						break;
					case ("Product ID/Name"):
						Report.IsTrue(Sel_ProdGrid.ProductIDNameFieldPresent(), field + " option was not showing as expected!", field + " option was showing as expected!");
						break;
					case ("Bulk Actions"):
						Report.IsTrue(Sel_ProdGrid.BulkActionsOptionPresent(), field + " option was not showing as expected!", field + " option was showing as expected!");
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
				var Sel_ProdGrid = new ProductsGrid();
				foreach (var Row in table.Rows)
				{ Report.IsTrue(Sel_ProdGrid.GridHeaderShowing(Row["Header"]), "Header " + Row["Header"] + " was not showing as expected!", "Header " + Row["Header"] + " was showing as expected!"); }
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
				var Sel_ProdGrid = new ProductsGrid();
				var FirstID = Sel_ProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of: '" + FirstID + "'");
				Report.Screenshot();
				Report.Info("Clicking the next button");
				Sel_ProdGrid.NavigateToNextPage();

				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
				var SecondID = Sel_ProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of '" + SecondID + "' from the next page");
				Report.IsTrue(FirstID != SecondID, "Product IDs were identical, so pagniation is not working!", "Product IDs are different, so pagination is working");
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
				var Sel_ProdGrid = new ProductsGrid();
				var FirstID = Sel_ProdGrid.GetIdInFirstGridRow();
				Report.Info("Got an ID of: '" + FirstID + "'");
				Context.AddToContext("SearchedID", FirstID);
				Sel_ProdGrid.ProductIDField = FirstID;
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
				var ProductToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
				Report.Info("Searching for product with ID: '" + ProductToSearch.ProductID + "'");
				var Sel_ProdGrid = new ProductsGrid();
				Sel_ProdGrid.ProductIDField = ProductToSearch.ProductID;
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(Sel_ProdGrid.ProductsCount() == 1, "No products were returned for ID: '" + ProductToSearch.ProductID + "'!", "Product was returned!");
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
				var Sel_ProdGrid = new ProductsGrid();
				Sel_ProdGrid.ProductIDField = "";
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
				var Sel_DeleteConfirm = new DeleteDialog();
				if (!Sel_DeleteConfirm.Wait_for_load())
				{ throw new Exception("Delete Dialog did not load!"); }

				Sel_DeleteConfirm.ClickDelete();
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
				var Sel_DeleteConfirm = new DeleteDialog();
				if (!Sel_DeleteConfirm.Wait_for_load())
				{ throw new Exception("Delete Dialog did not load!"); }

				Sel_DeleteConfirm.ClickCancel();
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
				var SearchedID = Context.GetFromContext("SearchedID").ToString();
				Report.Info("ID searched for: '" + SearchedID + "'");
				var Sel_ProdGrid = new ProductsGrid();
				Report.IsTrue(Sel_ProdGrid.ProductsCount() == 1, "More than one entry was found!", "Only one entry was found, as expected!");
				Report.IsTrue(Sel_ProdGrid.GetIdInFirstGridRow() == SearchedID, "ID returned was not the same as that searched for!", "ID returned was the same as that searched for");
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
				var Sel_ProdGrid = new ProductsGrid();
				bool ProductsExpected = shouldOrNot == "should";

				Report.IsTrue((Sel_ProdGrid.ProductsCount() != 0) == ProductsExpected,
					"Results grid " + (ProductsExpected ? "was not" : "was") + " showing products!",
					"Results grid " + (ProductsExpected ? "was" : "was not") + " showing products, as expected!");
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
				var Sel_ProdGrid = new ProductsGrid();
				Report.IsTrue(Sel_ProdGrid.ClickFilterOption(filter), "Failed to click filter option: '" + filter + "'", "Successfully filtered grid by: '" + filter + "'");
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
				var Sel_ProdGrid = new ProductsGrid();
				var ProductElement = Sel_ProdGrid.FirstProductInGrid();
				Context.AddToContext(savedAs, ProductElement);
				Report.Success("Got the first Product in Grid (ID: " + ProductElement.ProductID + ") and saved to: " + savedAs);
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
				var Sel_ProdGrid = new ProductsGrid();
				if (Sel_ProdGrid.ProductsCount() == 0)
				{
					Report.Failure("No products present! Cannot click Row Actions!");
					return;
				}
				Report.Info("Found products in grid, clicking first action button...");
				Report.IsTrue(Sel_ProdGrid.ClickActionsForFirstResultInGrid(), "Failed to click first Action Button!", "Successfully clicked the first Action Button!");
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
				var Sel_ProdGrid = new ProductsGrid();
				Report.IsTrue(Sel_ProdGrid.ClickRowAction(action),
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
				var Sel_ProdGrid = new ProductsGrid();
				if (Sel_ProdGrid.ProductsCount() == 0)
				{
					Report.Failure("No products present! Cannot click examine Row Actions!");
					return;
				}

				var RowActions = Sel_ProdGrid.ActionsAvailableInDropDown();
				Report.IsTrue(RowActions != null, "No row actions were found!", "Row actions were found!");

				foreach (var Row in table.Rows)
				{ Report.IsTrue(RowActions.Contains(Row["Option"].Trim()), Row["Option"] + " was not found in the list of Row Actions!", Row["Option"] + " was found in the list of Row Actions!"); }

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
				var Sel_ProdGrid = new ProductsGrid();
				Sel_ProdGrid.Click_BulkActions();
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
				var Sel_BulkActions = new BulkActions();
				Sel_BulkActions.Wait_for_load();
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
				var Sel_BulkActions = new BulkActions();
				var AvailableOptions = Sel_BulkActions.OptionsAvailable();
				foreach (var Row in table.Rows)
				{
					if (Report.IsTrue(AvailableOptions.Contains(Row["Options"]), "Option: '" + Row["Options"] + "' was not found in the actions list!", "Option: '" + Row["Options"] + "' was found in the list of actions!"))
					{ Report.IsTrue(Sel_BulkActions.OptionChangesOnHover(Row["Options"]), "Option '" + Row["Options"] + "' did not alter when hovered over!", "Option '" + Row["Options"] + "' changed on hover as expected!"); }
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
				var Sel_BulkActions = new BulkActions();
				Report.IsTrue(Sel_BulkActions.ClickOption(option), "Failed to click option: '" + option + "'", "Successfully clicked option: '" + option + "'");
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

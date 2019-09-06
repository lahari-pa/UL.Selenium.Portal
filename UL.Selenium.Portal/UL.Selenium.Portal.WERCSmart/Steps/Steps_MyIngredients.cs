using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "MyIngredients")]
	class Steps_MyIngredients
	{
		[StepDefinition(@"I enter the text: (.*) into the My Ingredients search field")]
		public void EnterTextInSearch(string value)
		{
			Report.IsTrue(new MyIngredients().EnterTextSearch(value),
				"Failed to enter search term: " + value + " in My Ingredients search",
				"Successfully entered search term: " + value + " in My Ingredients search");
		}

		[StepDefinition(@"I select the smart search result with name: (.*) and CAS: (.*)")]
		public void SelectSearchResult(string name, string cas)
		{
			Report.IsTrue(new MyIngredients().ClickSearchResult(name, cas),
				"Failed to select search result with name: " + name + " and CAS: " + cas,
				"Successully selected search result with name: " + name + " and CASL " + cas);
		}

		[StepDefinition(@"I add the following ingredients and save them to context as: (.*)")]
		public void AddIngredientItems(string savedAs, Table ingredients)
		{
			TestReport.UseSubSteps = true;
			var ingredientsContext = new List<MyIngredients.IngredientItem>();
			var selMyIngredients = new MyIngredients();
			List<MyIngredients.IngredientItem> allIngredients = selMyIngredients.IngredientsLibrary();
			foreach (TableRow row in ingredients.Rows)
			{
				TestReport.StartStep("I add the ingredient: " + row["Chemical Name"] + " to My Library");
				Report.Info("I enter the text: " + row["Chemical Name"] + " into the My Ingredients search field");
				this.EnterTextInSearch(row["Chemical Name"]);
				Report.Info("I select '" + row["Chemical Name"] + "' from the smart search results");
				this.SelectSearchResult(row["Chemical Name"], row["CAS"]);
				List<MyIngredients.IngredientItem> allIngredientsUpdate = selMyIngredients.IngredientsLibrary();
				ingredientsContext.Add(allIngredientsUpdate.First(r => allIngredients.All(p => r.Index != p.Index)));
				allIngredients = allIngredientsUpdate;
			}
			Context.AddToContext(savedAs, ingredientsContext);
		}

		[StepDefinition(@"I click Save in the My Ingredients tab")]
		public void ClickSaveMyIngredients()
		{
			Report.IsTrue(new MyIngredients().ClickSave(),
				"Failed to click Save in the My Ingredients tab",
				"Successfully clicked Save in the My Ingredients tab");
			GeneralUtilities.Wait_for_load_finish();
		}
		[StepDefinition(@"I save the current list of ingredients in My Library to context as: (.*)")]
		public void AddMyIngredientsToContext(string savedAs)
		{
			Context.AddToContext(savedAs, new MyIngredients().IngredientsLibrary());
		}

		// Note pre-requisite is saving list of ingredients to Context prior to searching - AddMyIngredientsToContext()
		[StepDefinition(@"I save the ingredient I added in My Library to context as: (.*)")]
		public void AddNewIngredientToContext(string savedAs)
		{
			var selMyIngredients = new MyIngredients();
			var rList = new List<MyIngredients.IngredientItem>();
			int pageNumber = selMyIngredients.GetPage("current");
			var previous = (List<MyIngredients.IngredientItem>)Context.GetFromContext("My Library Ingredients");
			Report.Info("Comparing against the previous set of ingredients. Count: " + previous.Count);
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return;
			}
			int lastPageNumber = selMyIngredients.GetPage("last");
			int ingredientNumber = 1;
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				int rowCount = selMyIngredients.IngredientCount();
				for (int i = 1; i <= rowCount; i++)
				{
					rList.Add(selMyIngredients.GetIngredient(i, ingredientNumber));
					ingredientNumber++;
				}
				if (selMyIngredients.NextDisabled())
				{
					Report.Info("There were a total of: " + rList.Count + " ingredients");
					if (rList.Count == previous.Count + 1)
					{
						Context.AddToContext("My_Ingredient_" + savedAs, rList.First(r => previous.All(p => r.Index != p.Index)));
						selMyIngredients.ClickPage("1");
						return;
					}
					Report.Failure("Attempted to add the new ingredient to context, but the list of ingredients has not increased by 1");
					selMyIngredients.ClickPage("1");
					return;
				}
				selMyIngredients.Navigation("next");
				pageNumber = selMyIngredients.GetPage("current");
			}
			Report.Info("A total of: " + rList.Count + " ingredients were found");
			selMyIngredients.ClickPage("1");
			if (rList.Count == previous.Count + 1)
			{
				Context.AddToContext("My Ingredient Addition", rList.First(r => previous.All(p => r.Index != p.Index)));
				return;
			}
			Report.Failure("Attempted to add the new ingredient to context, but the list of ingredients has not increased by 1");
		}

		[StepDefinition("I remove My Ingredient in My Library saved as: (.*)")]
		public void RemoveIngredientIAddedToMyLibraryFromContext(string savedAs)
		{
			if (Context.GetFromContext("My_Ingredient_" + savedAs) == null)
			{
				Report.Failure("There was no ingredient in context saved as: " + savedAs);
				return;
			}
			var ingredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			Report.IsTrue(new MyIngredients().ClickRemove(ingredient),
				"Failed to remove ingredient from My Library",
				"Successfully removed ingredient from My Library");
		}

		[StepDefinition(@"I confirm the component name in the delete product popup matches the ingredient saved as: (.*)")]
		public void DeleteMyIngredientDialogComponentNameMatchesLastAdded(string savedAs)
		{
			if (Context.GetFromContext("My_Ingredient_" + savedAs) == null)
			{
				Report.Failure("There was no ingredient in context saved as: " + savedAs);
				return;
			}
			var savedIngredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			string actualName = new MyIngredientsModal().IngredientToRemove();
			Report.IsTrue(actualName.Contains(savedIngredient.ChemicalName.Trim()),
				"The 'Remove Component from My Ingredients' dialog message did not contain the Chemical name: " + savedIngredient.ChemicalName,
				"The 'Remove Component from My Ingredients' dialog message contained the Chemical name: " + savedIngredient.ChemicalName + " as expected");
		}

		[StepDefinition("I click: (YES|NO) in the 'Remove Component from My Ingredients' pop up")]
		public void ClickOptionInRemoveComponentDialog(string option)
		{
			Report.IsTrue(new MyIngredientsModal().ClickButton(option),
				"Failed to click button: " + option + " in the 'Remove Component from My Ingredients' pop up",
				"Successfully clicked button: " + option + " in the 'Remove Component from My Ingredients' pop up");
		}

		[StepDefinition("I confirm My Ingredient saved as: (.*) in My Library has been removed from the grid")]
		public void ConfirmIngredientHasBeenRemoved(string savedAs)
		{
			if (Context.GetFromContext("My_Ingredient_" + savedAs) == null)
			{
				Report.Failure("There was no ingredient in context saved as: " + savedAs);
				return;
			}
			TestReport.UseSubSteps = true;
			var savedIngredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			TestReport.StartStep("Adding current list of ingredients to context");
			List<MyIngredients.IngredientItem> currentIngredients = new MyIngredients().IngredientsLibrary();
			TestReport.StartStep("Checking the ingredient I originally added has now been removed from the grid");
			Report.IsTrue(!currentIngredients.Contains(savedIngredient),
				"The removed ingredient: " + savedIngredient.ChemicalName + " was still showing in the ingredients grid at position: " + savedIngredient.Index,
				"The removed ingredient: " + savedIngredient.ChemicalName + " was no longer showing in the ingredients grid at position: " + savedIngredient.Index + " as expected");
		}

		[StepDefinition(@"I click the (Trade Secret|Publicly Disclosed) checkbox for My Ingredient saved as: (.*)")]
		public void SelectTradeSecretCheckbox(string checkbox, string savedAs)
		{
			if (Context.GetFromContext("My_Ingredient_" + savedAs) == null)
			{
				Report.Failure("There was no ingredient in context saved as: " + savedAs);
				return;
			}
			var ingredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			if (checkbox == "Trade Secret")
			{
				if (new MyIngredients().ClickTradeSecret(ingredient))
				{
					Report.Success("Successfully clicked the Trade Secret checkbox for ingredient: " + ingredient.ChemicalName + " on row: " + ingredient.Row);
					Report.Screenshot();
					ingredient.TradeSecret = !ingredient.TradeSecret;
					Context.AddToContext("My_Ingredient_" + savedAs, ingredient);
					return;
				}
				Report.Failure("Failed to click the Trade Secret checkbox for ingredient: " + ingredient.ChemicalName + " on row: " + ingredient.Row);
				Report.Screenshot();
				return;
			}
			if (checkbox == "Publicly Disclosed")
			{
				if (new MyIngredients().ClickPubliclyDisclosed(ingredient))
				{
					Report.Success("Successfully clicked the Publicly Disclosed checkbox for ingredient: " + ingredient.ChemicalName + " on row: " + ingredient.Row);
					Report.Screenshot();
					ingredient.PublicallyDisclosed = !ingredient.PublicallyDisclosed;
					Context.AddToContext("My_Ingredient_" + savedAs, ingredient);
					return;
				}
				Report.Failure("Failed to click the Publicly Disclosed checkbox for ingredient: " + ingredient.ChemicalName + " on row: " + ingredient.Row);
				Report.Screenshot();
				return;
			}
			Report.Failure("The checkbox paramater must be either Trade Secret or Publicly Disclosed");
		}

		[StepDefinition(@"I set the Public Name to be: (.*) for My Ingredient saved as: (.*)")]
		public void SetPublicNameForIngredient(string publicName, string savedAs)
		{
			if (Context.GetFromContext("My_Ingredient_" + savedAs) == null)
			{
				Report.Failure("There was no ingredient in context saved as: " + savedAs);
				return;
			}
			var ingredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			var selMyIngredients = new MyIngredients();
			selMyIngredients.EnterPublicName(ingredient, publicName);
			Delay.Seconds(1);
			Report.IsTrue(selMyIngredients.PublicName(ingredient) == publicName,
				"Failed to set the Public name for ingredient: " + ingredient.ChemicalName + " to value: " + publicName,
				"Successfully set the Public name for ingredient: " + ingredient.ChemicalName + " to value: " + publicName);
			ingredient.PublicName = publicName;
			Context.AddToContext("My_Ingredient_" + savedAs, ingredient);
		}

		[StepDefinition(@"I (select|deselect) the ingredient in My Library at index: (.*) from ingredients saved as: (.*)")]
		public void SelectIngredientMyLibrary(string select, string index, string savedAs)
		{
			if (Context.GetFromContext(savedAs) == null)
			{
				Report.Failure("There was no ingredient list in context saved as: " + savedAs);
				return;
			}
			var ingredients = (List<MyIngredients.IngredientItem>)Context.GetFromContext(savedAs);
			MyIngredients.IngredientItem ingredient = ingredients.FirstOrDefault(x => x.Index == int.Parse(index));
			var selMyIngredients = new MyIngredients();
			Report.IsTrue(selMyIngredients.ClickSelect(ingredient),
				"Failed to click the input checkbox to select ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index,
				"Successfully clicked the input checkbox to select ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index);
			Delay.Seconds(1);
			bool selected = select == "select";
			Report.IsTrue(selMyIngredients.Selected(ingredient) == selected,
				"The selected checkbox was not successfully " + select + "ed.",
				"The selected checkbox was successfully " + select + "ed.");
		}

		[StepDefinition(@"I edit the ingredients: (.*) and save the edited ingredients to context as: (.*)")]
		public void EditMyLibraryIngredients(string savedAs, string savedAsEdit, Table ingredientFields)
		{
			if (Context.GetFromContext(savedAs) == null)
			{
				Report.Failure("There was no ingredient list in context saved as: " + savedAs);
				return;
			}
			TestReport.UseSubSteps = true;
			var ingredients = (List<MyIngredients.IngredientItem>)Context.GetFromContext(savedAs);
			var selMyIngredients = new MyIngredients();
			//| Index | Click Publicly Disclosed | Click Trade Secret | Public Name Index |
			string index = "";
			string publicNameChange = "";
			var contextList = new List<MyIngredients.IngredientItem>();
			foreach (TableRow row in ingredientFields.Rows)
			{
				index = row["Index"];
				if (index == null || !index.All(char.IsDigit))
				{
					continue;
				}
				if (int.Parse(index) > ingredients.Count)
				{
					Report.Failure("The ingredient index: " + index + " exceeded the ingredients count (index out of range)");
					continue;
				}
				MyIngredients.IngredientItem ingredient = ingredients[int.Parse(index) - 1];
				if (ingredient == null)
				{
					Report.Failure("The ingredient to edit at index: " + index + " did not exist in the saved list of ingredients: " + savedAs);
					continue;
				}
				TestReport.StartStep("I edit the ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index);
				if (row["Click Trade Secret"].ToLower() == "y")
				{
					ingredient.TradeSecret = !ingredient.TradeSecret;
				}
				if (row["Click Publicly Disclosed"].ToLower() == "y")
				{
					ingredient.PublicallyDisclosed = !ingredient.PublicallyDisclosed;
				}
				// Get all Public Name options, pick at index. if out of range, pick first.
				List<string> options = selMyIngredients.PublicNameOptions(ingredient);
				string selectedOption = selMyIngredients.PublicName(ingredient);
				int optionIndex = options.IndexOf(selectedOption);
				publicNameChange = row["Public Name Change"];
				if (publicNameChange != null && (string.Equals(publicNameChange, "+") || string.Equals(publicNameChange, "-") || string.Equals(publicNameChange, "=")))
				{
					if (string.Equals(publicNameChange, "+"))
					{
						ingredient.PublicName = optionIndex + 1 == options.Count ? options.First() : options[optionIndex + 1];
					}
					else if (string.Equals(publicNameChange, "-"))
					{
						ingredient.PublicName = optionIndex == 0 ? options.Last() : options[optionIndex - 1];
					}
					contextList.Add(ingredient);
					Report.IsTrue(selMyIngredients.EditIngredient(ingredient),
						"Failed to edit ingredient: " + ingredient.ChemicalName + " at index: " + ingredient.Index,
						"Successfully edited ingredient: " + ingredient.ChemicalName + " at index: " + ingredient.Index);
				}
				else
				{
					contextList.Add(ingredient);
					Report.Warn("The Public Name Change value was null or did not match '+', '-' or '='");
					Report.IsTrue(selMyIngredients.EditIngredient(ingredient),
						"Failed to edit ingredient: " + ingredient.ChemicalName + " at index: " + ingredient.Index,
						"Successfully edited ingredient: " + ingredient.ChemicalName + " at index: " + ingredient.Index);
				}
			}
			Context.AddToContext(savedAsEdit, contextList);
		}

		[StepDefinition(@"I confirm that all changes in edited ingredients: (.*) were saved")]
		public void EditedIngredientsWereSaved(string savedAs)
		{
			if (Context.GetFromContext(savedAs) == null)
			{
				Report.Failure("There was no ingredient list in context saved as: " + savedAs);
				return;
			}
			var expectedIngredients = (List<MyIngredients.IngredientItem>)Context.GetFromContext(savedAs);
			var selMyIngredients = new MyIngredients();
			List<MyIngredients.IngredientItem> actualIngredients = selMyIngredients.IngredientsLibrary();
			Report.Info("Comparing current My Library ingredients against saved edited list.");
			Report.Info("Found " + actualIngredients.Count + " ingredients");
			foreach (MyIngredients.IngredientItem ingredient in expectedIngredients)
			{
				selMyIngredients.ClickPage(ingredient.Page.ToString());
				bool publicallyDisclosedMatch = ingredient.PublicallyDisclosed == expectedIngredients.First(e => e.Index == ingredient.Index).PublicallyDisclosed;
				bool tradeSecretMatch = ingredient.TradeSecret == expectedIngredients.First(e => e.Index == ingredient.Index).TradeSecret;
				bool publicNameMatch = ingredient.PublicName == expectedIngredients.First(e => e.Index == ingredient.Index).PublicName;
				if (publicallyDisclosedMatch && tradeSecretMatch && publicNameMatch)
				{
					Report.Success("Ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index + " was successfully saved and matched the edited state. Publicly Disclosed = " + ingredient.PublicallyDisclosed + ". Trade Secret = " + ingredient.TradeSecret + ". Public Name = " + ingredient.PublicName);
					Report.Screenshot();
				}
				else
				{
					if (!publicallyDisclosedMatch)
					{
						Report.Failure("Ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index + ". The Publically Disclosed checkbox was not successfully saved and did not match the edited state: " + ingredient.PublicallyDisclosed);
						Report.Screenshot();
					}
					if (!tradeSecretMatch)
					{
						Report.Failure("Ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index + ". The Trade Secret checkbox was not successfully saved and did not match the edited state: " + ingredient.TradeSecret);
						Report.Screenshot();
					}
					if (!publicNameMatch)
					{
						Report.Failure("Ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index + ". The Public Name option was not successfully saved and did not match the edited state: " + ingredient.PublicName);
						Report.Screenshot();
					}
				}
			}
		}

		[StepDefinition(@"I remove all ingredients in the list saved as: (.*)")]
		public void DeleteIngredientsInContextList(string savedAs)
		{
			TestReport.UseSubSteps = true;
			if (Context.GetFromContext(savedAs) == null)
			{
				Report.Failure("There was no ingredient list in context saved as: " + savedAs);
				return;
			}
			var ingredients = (List<MyIngredients.IngredientItem>)Context.GetFromContext(savedAs);
			var selMyIngredients = new MyIngredients();
			var selMyIngredientsModal = new MyIngredientsModal();
			foreach (MyIngredients.IngredientItem ingredient in ingredients)
			{
				Report.IsTrue(selMyIngredients.ClickSelect(ingredient),
					"Failed to click select for ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index,
					"Successfully clicked select for ingredient: " + ingredient.ChemicalName + " at position: " + ingredient.Index);
			}
			Report.IsTrue(selMyIngredients.ClickDeleteChecked(),
				"Failed to click 'Delete Checked' button",
				"Successfully clicled 'Delete Checked' button");
			Report.IsTrue(selMyIngredientsModal.ClickButton("YES"),
				"Failed to click the YES button in the Remove Ingredients pop up",
				"Successfully clicked the YES button in the Remove Ingredients pop up");
		}

		[StepDefinition(@"I click the (Next|Previous) button in the My Ingredients grid navigation")]
		public void ClickNavigationButton(string navOption)
		{
			Report.IsTrue(new MyIngredients().Navigation(navOption),
				"Failed to click the " + navOption + " navigation button in the My Ingredients tab",
				"Successfully clicked the " + navOption + " navigation button in the My Ingredients tab");
		}

		[StepDefinition(@"I confirm the navigation button is enabled in the My Ingredients grid")]
		public void NaviageionOptionsEnabled()
		{
			Report.IsFalse(new MyIngredients().NextDisabled(),
				"The Next navigation button was disabled in the My Ingredients tab",
				"The Next navigation button was enabled in the My Ingredients tab as expected");
		}

		[StepDefinition(@"I confirm the current active page number in the My Ingredients grid is: (.*)")]
		public void ConfirmPageNumber(string expectedPage)
		{
			string actualPage = new MyIngredients().GetPage("current").ToString();
			Report.IsTrue(string.Equals(expectedPage, actualPage),
				"The current active page did not match the expected value. Active page was: " + actualPage + ". Expected page was: " + expectedPage,
				"The current active page matched the expected value: " + actualPage);
		}

		[StepDefinition(@"I confirm the ingredients for page (.*) saved as: (.*) are displayed")]
		public void IngredientsPageIsDisplayed(string page, string savedAs)
		{
			if (Context.GetFromContext(savedAs) == null)
			{
				Report.Failure("There was no ingredient list in context saved as: " + savedAs);
				return;
			}
			var selMyIngredients = new MyIngredients();
			var ingredients = (List<MyIngredients.IngredientItem>)Context.GetFromContext(savedAs);
			ingredients = ingredients.Where(i => i.Page == int.Parse(page)).OrderBy(i => i.Index).ToList();
			for (int i = 1; i <= ingredients.Count; i++)
			{
				MyIngredients.IngredientItem ingredient = ingredients[i - 1];
				MyIngredients.IngredientItem showingingredient = selMyIngredients.GetIngredient(i, ingredient.Index);
				bool match = showingingredient.ChemicalName == ingredient.ChemicalName && showingingredient.PublicallyDisclosed == ingredient.PublicallyDisclosed && showingingredient.TradeSecret == showingingredient.TradeSecret && showingingredient.PublicName == ingredient.PublicName;
				Report.IsTrue(match,
					"Ingredient at row: " + ingredient.Row + " on page: " + page + " did not match the expected ingredient",
					"Ingredient at row: " + ingredient.Row + " on page: " + page + " matched the expected ingredient");
			}
		}

		[StepDefinition(@"I click page number: (.*) in the My Ingredients grid navigation")]
		public void ClickPageNumber(string page)
		{
			Report.IsTrue(new MyIngredients().ClickPage(page), "Failed to click page number: " + page, "Successfully clicked page number: " + page);
		}

		[StepDefinition(@"I confirm that the smart search results contain a chemical with CAS: (.*) and Name: (.*)")]
		public void SmartSearchResultsContainChemical(string cas, string name)
		{
			List<MyIngredients.SearchResult> searchResults = new MyIngredients().SearchResults();
			Report.IsTrue(searchResults.Any(x => x.CAS == cas && x.Name == name),
				"No search results were returned with CAS: " + cas + " and name: " + name + " in the top " + searchResults.Count + " results.",
				"There was a search result with CAS: " + cas + " and name: " + name + " returned as expected");
		}

		[StepDefinition(@"The Formulation 3rd Party Step is shown")]
		public void TheFormulationThirdPartyStepIsShown()
		{
			var thisNewProduct = new NewProduct();
			Report.IsTrue(thisNewProduct.ThirdPartyScreenAppears(), "The third party screen has not appeared", "The third party step is shown as expected");
		}

		[StepDefinition(@"In the Formulation 3rd Party screen I set Accept to (true|false)")]
		public void InTheFormulationThirdPartySCreenISetAcceptTo(string trueOrFalse)
		{
			var thisNewProduct = new NewProduct();

			if (thisNewProduct.AcceptRadioIsSelected() == (trueOrFalse.ToLower() == "true"))
			{
				Report.Success("Accept is already set to: " + trueOrFalse);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SelectAcceptRadio(), "Failed to set accept radio", "Set accept radio to: " + trueOrFalse);
			}

		}

		[StepDefinition(@"In the Formulation 3rd Party screen I set Granted to (true|false)")]
		public void InTheFormulationThirdPartySCreenISetGrantedTo(string trueOrFalse)
		{
			var thisNewProduct = new NewProduct();

			if (thisNewProduct.GrantedRadioIsSelected() == (trueOrFalse.ToLower() == "true"))
			{
				Report.Success("Granted is already set to: " + trueOrFalse);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SelectGrantedRadio(), "Failed to set granted radio", "Set granted radio to: " + trueOrFalse);
			}

		}

		[StepDefinition(@"In the Formulation 3rd Party screen I set Decline to (true|false)")]
		public void InTheFormulationThirdPartySCreenISetDeclinedTo(string trueOrFalse)
		{
			var thisNewProduct = new NewProduct();

			if (thisNewProduct.DeclinedRadioIsSelected() == (trueOrFalse.ToLower() == "true"))
			{
				Report.Success("Declined is already set to: " + trueOrFalse);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SelectDeclinedRadio(), "Failed to set declined radio", "Set declined radio to: " + trueOrFalse);
			}

		}
	}
}

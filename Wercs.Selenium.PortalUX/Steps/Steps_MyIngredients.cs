using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
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

		[StepDefinition(@"I select '(.*)' from the smart search results")]
		public void SelectSearchResult(string result)
		{
			Report.IsTrue(new MyIngredients().ClickSearchResult(result),
				"Failed to select search result with name: " + result,
				"Successully selected search result with name: " + result);
		}

		[StepDefinition(@"I click Save in the My Ingredients tab")]
		public void ClickSaveMyIngredients()
		{
			Report.IsTrue(new MyIngredients().ClickSave(),
				"Failed to click Save in the My Ingredients tab",
				"Successfully clicked Save in the My Ingredients tab");
		}
		[StepDefinition(@"I save the current list of ingredients in My Library to context")]
		public void AddMyIngredientsToContext()
		{
			Context.AddToContext("My Library Ingredients", new MyIngredients().IngredientsLibrary());
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
				var rowCount = selMyIngredients.IngredientCount();
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
						var result = rList.First(r => previous.All(p => r.ID != p.ID));
						Context.AddToContext("My_Ingredient_" + savedAs, rList.First(r => previous.All(p => r.ID != p.ID)));
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
				Context.AddToContext("My Ingredient Addition", rList.First(r => previous.All(p => r.ID != p.ID)));
				return;
			}
			Report.Failure("Attempted to add the new ingredient to context, but the list of ingredients has not increased by 1");
		}

		[StepDefinition("I remove My Ingredient in My Library saved as: (.*)")]
		public void RemoveIngredientIAddedToMyLibraryFromContext(string savedAs)
		{
			var ingredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			Report.IsTrue(ingredient.ClickRemove(),
				"Failed to remove ingredient from My Library",
				"Successfully removed ingredient from My Library");
		}

		[StepDefinition(@"I confirm the component name in the delete product popup matches the ingredient saved as: (.*)")]
		public void DeleteMyIngredientDialogComponentNameMatchesLastAdded(string savedAs)
		{
			var savedIngredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			var actualName = new MyIngredientsModal().IngredientToRemove();
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
			TestReport.UseSubSteps = true;
			var savedIngredient = (MyIngredients.IngredientItem)Context.GetFromContext("My_Ingredient_" + savedAs);
			TestReport.StartStep("Adding current list of ingredients to context");
			var currentIngredients = new MyIngredients().IngredientsLibrary();
			TestReport.StartStep("Checking the ingredient I originally added has now been removed from the grid");
			Report.IsTrue(!currentIngredients.Contains(savedIngredient),
				"The removed ingredient: " + savedIngredient.ChemicalName + " was still showing in the ingredients grid at position: " + savedIngredient.ID,
				"The removed ingredient: " + savedIngredient.ChemicalName + " was no longer showing in the ingredients grid at position: " + savedIngredient.ID + " as expected");
		}

		[StepDefinition(@"I click the (Trade Secret|Publicly Disclosed) checkbox for My Ingredient saved as: (.*)")]
		public void SelectTradeSecretCheckbox(string checkbox, string savedAs)
		{
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
	}
}

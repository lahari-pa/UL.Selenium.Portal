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
			var selMyIngredients = new MyIngredients();
			var rList = new List<MyIngredients.IngredientItem>();
			int pageNumber = selMyIngredients.GetPage("current");
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return;
			}
			int lastPageNumber = selMyIngredients.GetPage("last");
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				var rowCount = selMyIngredients.IngredientCount();
				for (int i = 1; i <= rowCount; i++)
				{
					rList.Add(selMyIngredients.GetIngredient(i));
				}
				if (selMyIngredients.NextDisabled())
				{
					Report.Info("Adding a total of: " + rList.Count + " ingredients to test context");
					Context.AddToContext("My Library Ingredients", rList);
					return;
				}
				selMyIngredients.Navigation("next");
				pageNumber = selMyIngredients.GetPage("current");
			}
			Report.Info("Adding a total of: " + rList.Count + " ingredients to test context");
			Context.AddToContext("My Library Ingredients", rList);
		}

		[StepDefinition(@"I save the ingredient I added in My Library to context")]
		public void AddNewIngredientToContext()
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
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				var rowCount = selMyIngredients.IngredientCount();
				for (int i = 1; i <= rowCount; i++)
				{
					rList.Add(selMyIngredients.GetIngredient(i));
				}
				if (selMyIngredients.NextDisabled())
				{
					Report.Info("There were a total of: " + rList.Count + " ingredients");
					if (rList.Count == previous.Count + 1)
					{
						Context.AddToContext("My Ingredient Addition", rList.Except(previous).FirstOrDefault());
						return;
					}
					Report.Failure("Attempted to add the new ingredient to context, but the list of ingredients has not increased by 1");
					return;
				}
				selMyIngredients.Navigation("next");
				pageNumber = selMyIngredients.GetPage("current");
			}
			Report.Info("A total of: " + rList.Count + " ingredients were found");
			if (rList.Count == previous.Count + 1)
			{
				Context.AddToContext("My Ingredient Addition", rList.Except(previous).FirstOrDefault());
				return;
			}
			Report.Failure("Attempted to add the new ingredient to context, but the list of ingredients has not increased by 1");
		}

		[StepDefinition("I remove the last ingredient I added to My Library")]
		public void RemoveIngredientIAddedToMyLibraryFromContext()
		{
			var ingredient = (MyIngredients.IngredientItem)Context.GetFromContext("My Ingredient Addition");
			Report.IsTrue(ingredient.ClickRemove(),
				"Failed to remove ingredient from My Library",
				"Successfully removed ingredient from My Library");
		}

		[StepDefinition(@"I confirm the component name in the delete product popup matches the last ingredient I added")]
		public void DeleteMyIngredientDialogComponentNameMatchesLastAdded()
		{
			var savedIngredient = (MyIngredients.IngredientItem)Context.GetFromContext("My Ingredient Addition");
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

		[StepDefinition("I confirm the ingredient I added to My Library has been removed from the ingredients grid")]
		public void ConfirmIngredientHasBeenRemoved()
		{
			TestReport.UseSubSteps = true;
			var savedIngredient = (MyIngredients.IngredientItem)Context.GetFromContext("My Ingredient Addition");
			TestReport.StartStep("Adding current list of ingredients to context");
			AddMyIngredientsToContext();
			TestReport.StartStep("Checking the ingredient I originally added has now been removed from the grid");
			var currentIngredients = (List<MyIngredients.IngredientItem>)Context.GetFromContext("My Library Ingredients");
			Report.IsTrue(!currentIngredients.Contains(savedIngredient),
				"The removed ingredient was still showing in the ingredients grid",
				"The removed ingredient was no longer showing in the ingredients grid");
		}
	}
}

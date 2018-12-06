using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsNewProductIngredients
	{
		[StepDefinition(@"I click the (Trade Secret|Publicly Disclosed) checkbox for ingredient: (.*)")]
		public void ClickTheCheckboxForIngredient(string input, string name)
		{
			switch (input)
			{
				case "Trade Secret":
					Report.IsTrue(new NewProduct().ClickIngredientCheckbox("Trade Secret", name), "The Trade Secret checkbox was not clicked successfully", "The Trade Secret checkbox was clicked successfully");
					break;
				case "Publicly Disclosed":
					Report.IsTrue(new NewProduct().ClickIngredientCheckbox("Publicly Disclosed", name), "The Publicly Disclosed checkbox was not clicked successfully", "The Publicly Disclosed checkbox was clicked successfully");
					break;
				default:
					Report.Failure("Invalid input parameter used! Valid options: 'Trade Secret' or 'Publicly Disclosed'");
					return;
			}
		}

		[StepDefinition(@"for ingredient: (.*) the (Trade Secret|Publicly Disclosed|Public Name) field is (enabled|disabled)")]
		public void ForIngredientTheTradeSecretCheckboxIsDisabledOrEnabled(string ingredient, string checkbox, string enabledOrDisabled)
		{
			var thisNewProduct = new NewProduct();
			switch (checkbox)
			{
				case "Publicly Disclosed":
					Report.IsTrue(
						thisNewProduct.GetIngredients().FirstOrDefault(x => x.ComponentName == ingredient).PublicDisclosureEnabled ==
						(enabledOrDisabled.ToLower() == "enabled"), "Public Disclosure checkbox is not showing as expected.",
						"Public Disclosure is showing as expected.");
					break;
				case "Trade Secret":
					Report.IsTrue(
						thisNewProduct.GetIngredients().FirstOrDefault(x => x.ComponentName == ingredient).TradeSecretEnabled ==
						(enabledOrDisabled.ToLower() == "enabled"), "Trade secret checkbox is not showing as expected.",
						"Trade secret is showing as expected.");
					break;
				case "Public Name":
					Report.IsTrue(thisNewProduct.GetIngredients().FirstOrDefault(x => x.ComponentName == ingredient).PublicNameEnabled ==
								  (enabledOrDisabled.ToLower() == "enabled"), "Public name select box is not showing as expected.",
						"Public name select box is showing as expected.");
					break;

				default:
					Report.Failure("Step requires a valid field option: 'Publicly Disclosed', 'Trade Secret' or 'Public Name'");
					return;
			}
		}

		[StepDefinition(@"for ingredient: (.*) I set (Public Disclosure|Trade Secret) checkbox to checked: (true|false)")]
		public void ForIngredientISetPublicDisclosureCheckboxToCheckedTrueFalse(string ingredient, string checkbox, string checkedTrueFalse)
		{
			switch (checkbox)
			{
				case "Public Disclosure":
					Report.IsTrue(new NewProduct().SetIngredientPubliclyDisclosed(ingredient, checkedTrueFalse == "true"),
						"Failed to set public disclosure checkbox to: " + checkedTrueFalse + " for ingredient: " + ingredient,
						"Successfully set public disclosure checkbox to: " + checkedTrueFalse);
					break;
				case "Trade Secret":
					Report.IsTrue(new NewProduct().SetIngredientTradeSecret(ingredient, checkedTrueFalse == "true"),
						"Failed to set public disclosure checkbox to: " + checkedTrueFalse + " for ingredient: " + ingredient,
						"Successfully set public disclosure checkbox to: " + checkedTrueFalse);
					break;
				default:
					throw new Exception("Please provide valid checkbox name");

			}
		}

		[StepDefinition(@"for ingredient: (.*) the Public Name selectbox shows names")]
		public void ForIngredientThePublicNameSelectboxShowsNames(string ingredient)
		{
			Report.IsTrue(new NewProduct().GetIngredientPublicNameOptions(ingredient).Count > 1,
				"No options are showing in public name select box", "options are showing in public name select box");
		}

		[StepDefinition(@"for ingredient: (.*) I should see an error below the public name column which reads: (.*)")]
		public void ForIngredientIShouldSeeAnErrorBelowThePublicNameColumn(string ingredient, string error)
		{
			string actualError = new NewProduct().GetPublicNameErrorMessage(ingredient);
			Report.IsTrue(actualError == error, "Expected error: " + error + " but got: " + actualError,
				"Error was as expected: " + error);
		}

		[StepDefinition(@"for ingredient: (.*) I select Public Name: (.*)")]
		public void ForIngredientISelectPublicName(string ingredient, string publicName)
		{
			Report.IsTrue(new NewProduct().SelectIngredientPublicName(ingredient, publicName), "Failed to set public name for ingredient: " + ingredient + " to: " + publicName, "Successfully set public name for ingredient: " + ingredient + " to: " + publicName);
		}

		[StepDefinition(@"I confirm the following column titles and inputs are displayed in the ingredients table")]
		public void ConfirmTheFollowingColumnTitlesAndInputsAreDisplayedInTheIngredientsTable(Table table)
		{
			NewProduct thisNewProduct = new NewProduct();
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(
					thisNewProduct.IngredientTableCheckInputByColumnTitle(thisRow["Column"], thisRow["Input"]),
					"Column input did not apppear as expected: " + thisRow["Column"] + ":" + thisRow["Input"],
					"Column input appeared as expected: " + thisRow["Column"] + ":" + thisRow["Input"]);
			}
		}

		[StepDefinition(@"I click 'Select all' in the Ingredients table")]
		public void ClickSelectAllInTheIngredientsTable()
		{
			Report.IsTrue(new NewProduct().ClickSelectAllIngredients(), "Failed to click 'Select All' in the ingredients table", "Successfully clicked 'Select All' in the ingredients table");
		}

		[StepDefinition(@"I confirm the 'Select all' checkbox in the Ingredients table is (checked|unchecked)")]
		public void ConfirmSelectAllIngredientsIsCheckedUnchecked(string expectChecked)
		{
			switch (expectChecked)
			{
				case "checked":
					Report.IsTrue(new NewProduct().SelectAllIngredientsChecked(), "The 'Select all' checkbox was not checked when it was expected to be!", "The 'Select all' checkbox was checked as expected");
					return;
				case "unchecked":
					Report.IsTrue(!new NewProduct().SelectAllIngredientsChecked(), "The 'Select all' checkbox was checked when it was expected to be unchecked!", "The 'Select all' checkbox was unchecked as expected");
					return;
				default:
					Report.Failure("Invalid expected step variable was specified! Must be 'checked' or 'unchecked'!");
					return;
			}
		}

		[StepDefinition(@"I confirm the 'Delete' button is available in the Ingredients table")]
		public void ConfirmTheDeleteButtonIsDisplayed()
		{
			Report.IsTrue(new NewProduct().DeleteIngredientsDisplayed(), "The Delete button is not displayed!", "The Delete button is displayed as expected");
		}

		[StepDefinition(@"I click the 'Delete' button in the Ingredients table")]
		public void ClickDeleteTheIngredients()
		{
			Report.IsTrue(new NewProduct().ClickDeleteIngredients(), "Failed to click 'Delete'", "Successfully clicked 'Delete'");
		}

		[StepDefinition(@"I confirm that all ingredients in the table are selected")]
		public void ConfirmAllIngredientsAreSelected()
		{
			var ingredients = new NewProduct().GetIngredients();
			var notSelected = ingredients.Where(x => !x.Selected).ToList();
			Report.IsTrue(ingredients.All(x => x.Selected), "Not all of the ingredients were selected! => " + string.Join(", ", notSelected.Select(x => x.ComponentName)), "All of the ingredients in the table were selected as expected");
		}

		[StepDefinition("I (select|deselect) the following ingredients:")]
		public void SelectDeselectIngredients(string doSelect, Table table)
		{
			var selNewProduct = new NewProduct();
			bool actionSelect;
			var ingredientsToAction = new List<string>();
			table.Rows.ForEach(x => ingredientsToAction.Add(x["Name"]));
			if (doSelect == "select")
			{
				actionSelect = true;
			}
			else if (doSelect == "deselect")
			{
				actionSelect = false;
			}
			else
			{
				Report.Failure("Invalid step parameter specified! Must be 'select' or 'deselect'!");
				return;
			}
			foreach (var row in table.Rows)
			{
				var ingredient = row["Name"];
				selNewProduct.ClickSelectIngredient(ingredient);
			}
			var ingredients = selNewProduct.GetIngredients();
			Report.IsTrue(ingredients.Where(x => ingredientsToAction.Contains(x.ComponentName)).All(x => x.Selected != actionSelect), $"Not all of the ingredients were successfully {doSelect}ed", $"All of the listed ingredients were successfully {doSelect}ed");
		}

		[StepDefinition("I confirm the following ingredients are (selected|unselected):")]
		public void ConfirmIngredientsAreSelectedDeselected(string expectSelected, Table table)
		{
			var ingredients = new NewProduct().GetIngredients();
			var ingredientsToCheck = new List<string>();
			table.Rows.ForEach(x => ingredientsToCheck.Add(x["Name"]));
			if (expectSelected == "selected")
			{
				Report.IsTrue(ingredients.Where(x => ingredientsToCheck.Contains(x.ComponentName)).All(x => x.Selected), "Not all of the listed ingredients were selected as was expected! => " + string.Join(", ", ingredientsToCheck), "All of the listed ingredients were selected as expected");
			}
			else if (expectSelected == "unselected")
			{
				Report.IsTrue(ingredients.Where(x => ingredientsToCheck.Contains(x.ComponentName)).All(x => !x.Selected), "Not all of the listed ingredients were unselected as was expected! => " + string.Join(", ", ingredientsToCheck), "All of the listed ingredients were unselected as expected");
			}
			else
			{
				Report.Failure("Invalid step parameter! Must be 'selected' or 'unselected'!");
			}
		}

		[StepDefinition("I confirm the 'Remove selected components' popup is displayed with message: (.*)")]
		public void ConfirmRemoveSelectedComponentsPopupIsDisplayed(string expectedText)
		{
			var selModal = new ModalDialog();
			if (!selModal.Wait_for_load())
			{
				Report.Failure("No modal popup was loaded!");
				Report.Screenshot();
				return;
			}
			var actualText = selModal.GetText();
			var header = selModal.GetTitle();
			if (Report.IsTrue(header.Trim() == "Remove selected components?", "The Remove selected components popup was not displayed!"))
			{
				Report.IsTrue(actualText == expectedText, $"The 'Remove selected components?' popup did not display the correct message! Expected: '{expectedText}' but found: '{actualText}'", "The 'Remove selected components?' popup was displayed correctly");
			}
		}

		[StepDefinition(@"I confirm there are a total of: (.*) ingredients in the table")]
		public void ConfirmIngredientsCount(string total)
		{
			var selNewProduct = new NewProduct();
			var ingredients = selNewProduct.GetIngredients();
			if (!int.TryParse(total, out int expectedCount))
			{
				Report.Failure("Specifiied parameter must be parsable to an int!");
				return;
			}
			Report.IsTrue(ingredients.Count == expectedCount, $"The ingredients count was not correct! Expected: {expectedCount} but found: {ingredients.Count}", "The ingredients count was correct: " + expectedCount);
		}
	}
}

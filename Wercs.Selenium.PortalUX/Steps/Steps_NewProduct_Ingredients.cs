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
		[StepDefinition(@"I add the following ingredients:")]
		public void AddIngredients(Table ingredientInformation)
		{
			var Ingredients = ingredientInformation.CreateSet<Ingredient>();

			foreach (var item in Ingredients)
			{
				Report.IsTrue(new NewProduct().AddIngredient(item), "Failed to add ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber) + "!", "Successfully added ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber));
			}
		}

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

		[StepDefinition(@"I confirm the (Publicly Disclosed|Trade Secret) checkbox is: (checked|unchecked) for ingredient: (.*)")]
		public void IngredientsConfirmCheckboxState(string option, string checkState, string chemicalName)
		{
			var ingredients = new NewProduct().GetIngredients();
			var thisIngredient = ingredients.First(x => x.ComponentName == chemicalName);
			if (thisIngredient == null)
			{
				Report.Failure("Could not find ingredient with name: " + chemicalName + "!");
				return;
			}
			var expectChecked = false;
			if (checkState == "checked")
			{
				expectChecked = true;
			}
			else if (checkState != "unchecked")
			{
				Report.Failure("Valid 'check state' parameter must be either 'checked' or 'unchecked'!");
				return;
			}
			switch (option)
			{
				case "Trade Secret":
					Report.IsTrue(thisIngredient.TradeSecret == expectChecked, "The Trade Secret checkbox should be: " + expectChecked + " but it was " + thisIngredient.TradeSecret, "The Trade Secret checbox was: " + expectChecked + " as expected");
					break;
				case "Publicly Disclosed":
					Report.IsTrue(thisIngredient.PublicallyDisclosed == expectChecked, "The Publicly Disclosed checkbox should be: " + expectChecked + " but it was " + thisIngredient.PublicallyDisclosed, "The Publicly Disclosed checbox was: " + expectChecked + " as expected");
					break;
				default:
					Report.Failure("Valid 'option' parameter must be either 'Trade Secret' or 'Publicly Disclosed'");
					return;
			}
		}

		[StepDefinition(@"I click the Publicly Disclosed checkbox for ingredient saved as: (.*)")]
		public void ClickPubliclyDisclosedIngredientSavedAs(string savedAs)
		{
			var selNewProduct = new NewProduct();
			var ingredients = selNewProduct.GetIngredients();
			var ingredientSavedAs = Context.GetFromContext(savedAs);
			if (ingredientSavedAs == null)
			{
				Report.Failure("Could not find ingredient in context saved as: " + savedAs);
				return;
			}
			var ingredient = (Ingredient)ingredientSavedAs;
			var targetIngredient = ingredients.First(x => x.CASNumber == ingredient.CASNumber && x.ComponentName == ingredient.ComponentName);
			if (targetIngredient == null)
			{
				Report.Failure("Could not find the ingredient on the page which matched the target ingredient: " + ingredient.ComponentName + "(" + ingredient.CASNumber + ")");
				Report.Screenshot();
				return;
			}
			var disclosed = targetIngredient.PublicallyDisclosed;
			Report.Info("Setting Publicly Disclosed as: " + (disclosed ? "false" : "true"));
			Report.IsTrue(selNewProduct.SetIngredientPubliclyDisclosed(ingredient.ComponentName, !disclosed),
				"Failed to set Publicly Disclosed checkbox to: " + (disclosed ? "false" : "true"),
				"Successfully set the Publicly Disclosed checkbox to: " + (disclosed ? "false" : "true"));
		}

		[StepDefinition(@"for ingredient: (.*) I confirm the Public Name selectbox contains names for selection")]
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

		[StepDefinition(@"I select the first Public Name dropdown option for ingredient: (.*)")]
		public void IngredientSelectPublicName(string chemicalName)
		{
			Report.IsTrue(new NewProduct().SelectIngredientPublicName(chemicalName), "The Public Name option for ingredient: " + chemicalName + " was not changed", "The Public Name for ingredient: " + chemicalName + " was succesfully changed");
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
			switch (doSelect)
			{
				case "select":
					actionSelect = true;
					break;
				case "deselect":
					actionSelect = false;
					break;
				default:
					Report.Failure("Invalid step parameter specified! Must be 'select' or 'deselect'!");
					return;
			}
			foreach (var row in table.Rows)
			{
				selNewProduct.ClickSelectIngredient(row["Name"]);
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

		[StepDefinition(@"I (should|should not) see the ingredients error message")]
		public void IngredientsErrorMessageShowing(string should)
		{
			bool expected;
			switch (should)
			{
				case "should":
					expected = true;
					break;
				case "should not":
					expected = false;
					break;
				default:
					Report.Failure("Invalid step parameter! Must be 'should' or 'should not'!");
					return;
			}
			Report.IsTrue(expected != new NewProduct().GetIngredientErrorMessage().IsNullOrEmpty(),
				$"{(expected ? "Did not expect" : "Expected")} to see the ingredients error message!",
				$"Ingredients error message {(expected ? "was" : "was not")} showing as expected");
		}

		[StepDefinition(@"The ingredients error message should be showing: (.*)")]
		public void IngredientsErrorMessageShowingCorrectText(string text)
		{
			var showing = new NewProduct().GetIngredientErrorMessage();
			Report.IsTrue(showing.Trim() == text.Trim(),
				$"Ingredients error message was not as expected. Expected: {text.Trim()} but found {showing.Trim()}",
				$"Ingredients error message was showing {text.Trim()} as expected!");
		}

		[StepDefinition(@"I confirm there are (.*) Publicly Disclosed ingredients in the Total section")]
		public void IngredientsPubliclyDisclosedTotalIsCorrect(string total)
		{
			Report.IsTrue(new NewProduct().PubliclyDisclosedTotalIsCorrect(total), "The Publicly Disclosed summary text did not match the expected: " + total, "The Publicaly Disclosed summary text matched the expected: " + total);
		}

		[StepDefinition(@"In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: (.*) and denominator: (.*)")]
		public void IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing(string numerator, string denominator)
		{
			var selNewProduct = new NewProduct();

			if (numerator.ToLower().Contains("saved as"))
			{
				numerator = Context.GetFromContext(numerator.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim()).ToString();
			}
			Report.IsTrue(selNewProduct.TransparencyScoreNumerator() == numerator,
				"The Transparency Score numerator did not match the expected: " + numerator + " it is showing as: " + selNewProduct.TransparencyScoreNumerator(),
				"The Transparency Score numerator matched the expected: " + numerator);
			Report.IsTrue(selNewProduct.TransparencyScoreDenominator() == denominator,
				"The Transparency Score denominator did not match the expected: " + denominator,
				"The Transparency Score denominator matched the expected: " + denominator);
		}

		[StepDefinition(@"In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a (warning|success|danger|info)")]
		public void IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed(string flag)
		{
			//orange is warning, red is danger, green is success, blue is info
			if (flag == "warning")
			{
				Report.IsTrue(new NewProduct().TransparencyScoreStatus() == "warning",
					"The Transparency Score label was not highlighted orange (warning) as expected",
					"The Transparency Score label was highlighted orange (warning) as expected");
			}
			if (flag == "success")
			{
				Report.IsTrue(new NewProduct().TransparencyScoreStatus() == "success",
					"The Transparency Score label was not highlighted green (success)!",
					"The Transparency Score label was highlighted green (success) as expected");
			}
			if (flag == "danger")
			{
				Report.IsTrue(new NewProduct().TransparencyScoreStatus() == "danger",
					"The Transparency Score label was not highlighted red (warning)!",
					"The Transparency Score label was highlighted red (warning) as expected");
			}
			if (flag == "info")
			{
				Report.IsTrue(new NewProduct().TransparencyScoreStatus() == "info",
					"The Transparency Score label was not highlighted blue (info)",
					"The Transparency Score label was highlighted blue (info) as expected");
			}
		}

		[StepDefinition(@"In the ingredients table I click (CAS Number|Chemical Name|Percent|Publicly Disclosed|Trade Secret|Public Name) to order")]
		public void WhenInTheIngredientsTableIClickCASNumberChemicalNameToOrder(string orderBy)
		{
			Report.IsTrue(new NewProduct().IngredientOrderbY(orderBy),
				"Failed to click " + orderBy, "Successfully clicked " + orderBy);
		}

		[StepDefinition(@"In the ingredients table the ingredients should be in the following order")]
		public void ThenInTheIngredientsTableTheIngredientsShouldBeInTheFollowingOrder(Table table)
		{
			var thisNewProduct = new NewProduct();
			var listOfIngedients = thisNewProduct.GetIngredients();
			if (listOfIngedients.Count == 0)
			{
				Report.Failure("There were no ingredients showing in the table!");
				Report.Screenshot();
				return;
			}
			int i = 0;
			foreach (var thisRow in table.Rows)
			{
				Report.IsTrue(listOfIngedients[i].ComponentName.Contains(thisRow["Name"]),
					"Expected to see: " + thisRow["Name"] + " but got: " + listOfIngedients[i].ComponentName,
					" As expected, ingredient: " + thisRow["Name"] + " is showing");
				i++;
			}
		}

		[StepDefinition(@"I click the Regulated button for ingredient: (.*) in the Ingredients table")]
		public void ClickRegulatedButtonForIngredient(string name)
		{
			var selNewProduct = new NewProduct();
			Report.IsTrue(selNewProduct.Ingredients_ClickRegulated(name),
				"Failed to click the Regulated button for ingredient: " + name,
				"Successfully clicked the Regulated button for ingredient: " + name);
		}

		[StepDefinition(@"In the ingredients page I search for and select product saved as: (.*)")]
		public void InTheIngredientsPageISearchForAndSelectProductSavedAs(string savedAs)
		{
			var selNewProduct = new NewProduct();
			var id = "";
			if (Context.Contains(savedAs))
			{
				var thisProduct = (ProductInformation)Context.GetFromContext(savedAs);
				id = thisProduct.Id;
			}
			var thisIngredient = new Ingredient {
				CASNumber = "WPS" + id
			};
			selNewProduct.AddIngredient(thisIngredient);
		}
	}
}

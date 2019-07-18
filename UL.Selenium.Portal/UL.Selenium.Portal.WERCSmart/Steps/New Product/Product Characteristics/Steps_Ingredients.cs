using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsIngredients
	{
		[StepDefinition(@"I add the following ingredients:")]
		public void AddIngredients(Table ingredientInformation)
		{
			var newProductIngredients = new Ingredients();
			var Ingredients = ingredientInformation.CreateSet<Ingredients.Ingredient>();
			foreach (var item in Ingredients)
			{
				Report.IsTrue(newProductIngredients.AddIngredient(item), "Failed to add ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber) + "!", "Successfully added ingredient: " + (item.CASNumber == "" ? item.ComponentName : item.CASNumber));
			}
		}

		[StepDefinition(@"I click the (Trade Secret|Publicly Disclosed) checkbox for ingredient: (.*)")]
		public void ClickTheCheckboxForIngredient(string input, string name)
		{
			var newProductIngredients = new Ingredients();
			switch (input)
			{
				case "Trade Secret":
					Report.IsTrue(newProductIngredients.ClickIngredientCheckbox("Trade Secret", name), "The Trade Secret checkbox was not clicked successfully", "The Trade Secret checkbox was clicked successfully");
					break;
				case "Publicly Disclosed":
					Report.IsTrue(newProductIngredients.ClickIngredientCheckbox("Publicly Disclosed", name), "The Publicly Disclosed checkbox was not clicked successfully", "The Publicly Disclosed checkbox was clicked successfully");
					break;
				default:
					Report.Failure("Invalid input parameter used! Valid options: 'Trade Secret' or 'Publicly Disclosed'");
					return;
			}
		}

		[StepDefinition(@"for ingredient: (.*) the (Trade Secret|Publicly Disclosed|Public Name) field is (enabled|disabled)")]
		public void ForIngredientTheTradeSecretCheckboxIsDisabledOrEnabled(string ingredient, string checkbox, string enabledOrDisabled)
		{
			var newProductIngredients = new Ingredients();
			switch (checkbox)
			{
				case "Publicly Disclosed":
					Report.IsTrue(
						newProductIngredients.GetIngredients().FirstOrDefault(x => x.ComponentName == ingredient).PublicDisclosureEnabled ==
						(enabledOrDisabled.ToLower() == "enabled"), "Public Disclosure checkbox is not showing as expected.",
						"Public Disclosure is showing as expected.");
					break;
				case "Trade Secret":
					Report.IsTrue(
						newProductIngredients.GetIngredients().FirstOrDefault(x => x.ComponentName == ingredient).TradeSecretEnabled ==
						(enabledOrDisabled.ToLower() == "enabled"), "Trade secret checkbox is not showing as expected.",
						"Trade secret is showing as expected.");
					break;
				case "Public Name":
					Report.IsTrue(newProductIngredients.GetIngredients().FirstOrDefault(x => x.ComponentName == ingredient).PublicNameEnabled ==
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
			var newProductIngredients = new Ingredients();
			switch (checkbox)
			{
				case "Public Disclosure":
					Report.IsTrue(newProductIngredients.SetIngredientPubliclyDisclosed(ingredient, checkedTrueFalse == "true"),
						"Failed to set public disclosure checkbox to: " + checkedTrueFalse + " for ingredient: " + ingredient,
						"Successfully set public disclosure checkbox to: " + checkedTrueFalse);
					break;
				case "Trade Secret":
					Report.IsTrue(newProductIngredients.SetIngredientTradeSecret(ingredient, checkedTrueFalse == "true"),
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
			var ingredients = new Ingredients().GetIngredients();
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
			var newProductIngredients = new Ingredients();
			var ingredients = newProductIngredients.GetIngredients();
			var ingredientSavedAs = Context.GetFromContext(savedAs);
			if (ingredientSavedAs == null)
			{
				Report.Failure("Could not find ingredient in context saved as: " + savedAs);
				return;
			}
			var ingredient = (Ingredients.Ingredient)ingredientSavedAs;
			var targetIngredient = ingredients.First(x => x.CASNumber == ingredient.CASNumber && x.ComponentName == ingredient.ComponentName);
			if (targetIngredient == null)
			{
				Report.Failure("Could not find the ingredient on the page which matched the target ingredient: " + ingredient.ComponentName + "(" + ingredient.CASNumber + ")");
				Report.Screenshot();
				return;
			}
			var disclosed = targetIngredient.PublicallyDisclosed;
			Report.Info("Setting Publicly Disclosed as: " + (disclosed ? "false" : "true"));
			Report.IsTrue(newProductIngredients.SetIngredientPubliclyDisclosed(ingredient.ComponentName, !disclosed),
				"Failed to set Publicly Disclosed checkbox to: " + (disclosed ? "false" : "true"),
				"Successfully set the Publicly Disclosed checkbox to: " + (disclosed ? "false" : "true"));
		}

		[StepDefinition(@"for ingredient: (.*) I confirm the Public Name selectbox contains names for selection")]
		public void ForIngredientThePublicNameSelectboxShowsNames(string ingredient)
		{
			Report.IsTrue(new Ingredients().GetIngredientPublicNameOptions(ingredient).Count > 1,
				"No options are showing in public name select box", "options are showing in public name select box");
		}

		[StepDefinition(@"for ingredient: (.*) I should see an error below the public name column which reads: (.*)")]
		public void ForIngredientIShouldSeeAnErrorBelowThePublicNameColumn(string ingredient, string error)
		{
			string actualError = new Ingredients().GetPublicNameErrorMessage(ingredient);
			Report.IsTrue(actualError == error, "Expected error: " + error + " but got: " + actualError,
				"Error was as expected: " + error);
		}

		[StepDefinition(@"for ingredient: (.*) I select Public Name: (.*)")]
		public void ForIngredientISelectPublicName(string ingredient, string publicName)
		{
			Report.IsTrue(new Ingredients().SelectIngredientPublicName(ingredient, publicName), "Failed to set public name for ingredient: " + ingredient + " to: " + publicName, "Successfully set public name for ingredient: " + ingredient + " to: " + publicName);
		}

		[StepDefinition(@"I select the first Public Name dropdown option for ingredient: (.*)")]
		public void IngredientSelectPublicName(string chemicalName)
		{
			Report.IsTrue(new Ingredients().SelectIngredientPublicName(chemicalName), "The Public Name option for ingredient: " + chemicalName + " was not changed", "The Public Name for ingredient: " + chemicalName + " was succesfully changed");
		}

		[StepDefinition(@"I confirm the following column titles and inputs are displayed in the ingredients table")]
		public void ConfirmTheFollowingColumnTitlesAndInputsAreDisplayedInTheIngredientsTable(Table table)
		{
			var newProductIngredients = new Ingredients();
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(newProductIngredients.ConfirmTableInputMatchByColumnTitle(thisRow["Column"], thisRow["Input"]),
					"Column input did not apppear as expected: " + thisRow["Column"] + ":" + thisRow["Input"],
					"Column input appeared as expected: " + thisRow["Column"] + ":" + thisRow["Input"]);
			}
		}

		[StepDefinition(@"I click 'Select all' in the Ingredients table")]
		public void ClickSelectAllInTheIngredientsTable()
		{
			Report.IsTrue(new Ingredients().ClickSelectAllIngredients(), "Failed to click 'Select All' in the ingredients table", "Successfully clicked 'Select All' in the ingredients table");
		}

		[StepDefinition(@"I confirm the 'Select all' checkbox in the Ingredients table is (checked|unchecked)")]
		public void ConfirmSelectAllIngredientsIsCheckedUnchecked(string expectChecked)
		{
			var newProductIngredients = new Ingredients();
			switch (expectChecked)
			{
				case "checked":
					Report.IsTrue(newProductIngredients.SelectAllIngredientsChecked(), "The 'Select all' checkbox was not checked when it was expected to be!", "The 'Select all' checkbox was checked as expected");
					return;
				case "unchecked":
					Report.IsTrue(!newProductIngredients.SelectAllIngredientsChecked(), "The 'Select all' checkbox was checked when it was expected to be unchecked!", "The 'Select all' checkbox was unchecked as expected");
					return;
				default:
					Report.Failure("Invalid expected step variable was specified! Must be 'checked' or 'unchecked'!");
					return;
			}
		}

		[StepDefinition(@"I confirm the 'Delete' button (is|is not) available in the Ingredients table")]
		public void ConfirmTheDeleteButtonIsDisplayed(string isIsNot)
		{
			if (isIsNot == "is")
			{
				Report.IsTrue(new Ingredients().DeleteIngredientsDisplayed(), "The Delete button is not displayed!", "The Delete button is displayed as expected");
			}
			else
			{
				Report.IsTrue((!new Ingredients().DeleteIngredientsDisplayed()), "The Delete button is displayed!", "The Delete button is not displayed as expected");
			}

		}

		[StepDefinition(@"I click the 'Delete' button in the Ingredients table")]
		public void ClickDeleteTheIngredients()
		{
			Report.IsTrue(new Ingredients().ClickDeleteIngredients(), "Failed to click 'Delete'", "Successfully clicked 'Delete'");
		}

		[StepDefinition(@"I confirm that all ingredients in the table are selected")]
		public void ConfirmAllIngredientsAreSelected()
		{
			var ingredients = new Ingredients().GetIngredients();
			var notSelected = ingredients.Where(x => !x.Selected).ToList();
			Report.IsTrue(ingredients.All(x => x.Selected), "Not all of the ingredients were selected! => " + string.Join(", ", notSelected.Select(x => x.ComponentName)), "All of the ingredients in the table were selected as expected");
		}

		[StepDefinition("I (select|deselect) the following ingredients:")]
		public void SelectDeselectIngredients(string doSelect, Table table)
		{
			var newProductIngredients = new Ingredients();
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
				newProductIngredients.ClickSelectIngredient(row["Name"]);
			}
			var ingredients = newProductIngredients.GetIngredients();
			Report.IsTrue(ingredients.Where(x => ingredientsToAction.Contains(x.ComponentName)).All(x => x.Selected != actionSelect), $"Not all of the ingredients were successfully {doSelect}ed", $"All of the listed ingredients were successfully {doSelect}ed");
		}

		[StepDefinition("I confirm the following ingredients are (selected|unselected):")]
		public void ConfirmIngredientsAreSelectedDeselected(string expectSelected, Table table)
		{
			var ingredients = new Ingredients().GetIngredients();
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

			var ingredients = new Ingredients().GetIngredients();
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
			Report.IsTrue(expected != new Ingredients().GetIngredientErrorMessage().IsNullOrEmpty(),
				$"{(expected ? "Did not expect" : "Expected")} to see the ingredients error message!",
				$"Ingredients error message {(expected ? "was" : "was not")} showing as expected");
		}

		[StepDefinition(@"The ingredients error message should be showing: (.*)")]
		public void IngredientsErrorMessageShowingCorrectText(string text)
		{
			var showing = new Ingredients().GetIngredientErrorMessage();
			Report.IsTrue(showing.Trim() == text.Trim(),
				$"Ingredients error message was not as expected. Expected: {text.Trim()} but found {showing.Trim()}",
				$"Ingredients error message was showing {text.Trim()} as expected!");
		}

		[StepDefinition(@"I confirm there are (.*) Publicly Disclosed ingredients in the Total section")]
		public void IngredientsPubliclyDisclosedTotalIsCorrect(string total)
		{
			Report.IsTrue(new Ingredients().PubliclyDisclosedTotalIsCorrect(total), "The Publicly Disclosed summary text did not match the expected: " + total, "The Publicaly Disclosed summary text matched the expected: " + total);
		}

		[StepDefinition(@"In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: (.*) and denominator: (.*)")]
		public void IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing(string numerator, string denominator)
		{
			var newProductIngredients = new Ingredients();
			var actualNumerator = newProductIngredients.TransparencyScoreNumerator();
			var actualDenominator = newProductIngredients.TransparencyScoreDenominator();
			if (numerator.ToLower().Contains("saved as"))
			{
				numerator = Context.GetFromContext(numerator.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim()).ToString();
			}
			Report.IsTrue(actualNumerator == numerator,
				"The Transparency Score numerator did not match the expected: " + numerator + " it is showing as: " + actualNumerator,
				"The Transparency Score numerator matched the expected: " + numerator);
			Report.IsTrue(actualDenominator == denominator,
				"The Transparency Score denominator did not match the expected: " + denominator + ". Showing was: " + actualDenominator,
				"The Transparency Score denominator matched the expected: " + denominator);
		}

		[StepDefinition(@"In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a (warning|success|danger|info)")]
		public void IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed(string flag)
		{
			var status = new Ingredients().TransparencyScoreStatus();
			//orange is warning, red is danger, green is success, blue is info
			if (flag == "warning")
			{
				Report.IsTrue(status == "warning",
					"The Transparency Score label was not highlighted orange (warning) as expected",
					"The Transparency Score label was highlighted orange (warning) as expected");
			}
			if (flag == "success")
			{
				Report.IsTrue(status == "success",
					"The Transparency Score label was not highlighted green (success)!",
					"The Transparency Score label was highlighted green (success) as expected");
			}
			if (flag == "danger")
			{
				Report.IsTrue(status == "danger",
					"The Transparency Score label was not highlighted red (warning)!",
					"The Transparency Score label was highlighted red (warning) as expected");
			}
			if (flag == "info")
			{
				Report.IsTrue(status == "info",
					"The Transparency Score label was not highlighted blue (info)",
					"The Transparency Score label was highlighted blue (info) as expected");
			}
		}

		[StepDefinition(@"In the ingredients table I click (CAS Number|Chemical Name|Percent|Publicly Disclosed|Trade Secret|Public Name) to order")]
		public void WhenInTheIngredientsTableIClickCASNumberChemicalNameToOrder(string orderBy)
		{
			Report.IsTrue(new Ingredients().IngredientOrderbY(orderBy),
				"Failed to click " + orderBy, "Successfully clicked " + orderBy);
		}

		[StepDefinition(@"In the ingredients table the ingredients should be in the following order")]
		public void ThenInTheIngredientsTableTheIngredientsShouldBeInTheFollowingOrder(Table table)
		{
			var listOfIngedients = new Ingredients().GetIngredients();
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
			Report.IsTrue(new Ingredients().ClickRegulated(name),
				"Failed to click the Regulated button for ingredient: " + name,
				"Successfully clicked the Regulated button for ingredient: " + name);
		}

		[StepDefinition(@"In the ingredients page I search for and select product saved as: (.*)")]
		public void InTheIngredientsPageISearchForAndSelectProductSavedAs(string savedAs)
		{
			var newProductIngredients = new Ingredients();
			var id = "";
			if (Context.Contains(savedAs))
			{
				var thisProduct = (ProductInformation)Context.GetFromContext(savedAs);
				id = thisProduct.Id;
			}
			var thisIngredient = new Ingredients.Ingredient {
				CASNumber = "WPS" + id
			};
			newProductIngredients.AddIngredient(thisIngredient);
		}

		[StepDefinition(@"I enter text: (.*) in the component search box")]
		public void EnterTextComponentSearchBox(string value)
		{
			var newProductIngredients = new Ingredients();
			newProductIngredients.ClickComponentSearchPlaceholder();
			Report.IsTrue(newProductIngredients.EnterTextSearchComponent(value), $"Failed to enter text '{value}' in the component search box!", $"Successully entered text '{value}' in the component search box");
		}

		[StepDefinition(@"I select the component search result with (name|CAS) matching text: (.*) and save ingredient as: (.*)")]
		public void SearchForAndSelectComponentIngredients(string identifier, string value, string savedAs)
		{
			var newProductIngredients = new Ingredients();
			var thisCas = "";
			var thisName = "";
			switch (identifier)
			{
				case "name":
					Report.Info("Searching for component with name: " + value);
					thisName = value;
					break;
				case "CAS":
					Report.Info("Searching for component with CAS: " + value);
					thisCas = value;
					break;
				default:
					Report.Failure("Invalid 'identifier' parameter provided! Must be 'name' or 'CAS'!");
					return;
			}

			var thisIngredient = new Ingredients.Ingredient {
				CASNumber = thisCas,
				ComponentName = thisName
			};
			Report.Info($"Clicking the first search result matching: {thisName} [{thisCas}]");
			Report.IsTrue(newProductIngredients.ClickIngredientFromSearchResults(thisIngredient, out Ingredients.Ingredient clickedIngredient), "Failed to click ingredient!", "Successfully clicked ingredient");
			Report.Info("Saving clicked ingredient to context. Saved as: " + savedAs);
			Context.AddToContext(savedAs, clickedIngredient);
		}

		[StepDefinition(@"I confirm that a 'Sustainability Hint' button is displayed under ingredient saved as: (.*) with hover over text: (.*)")]
		public void ConfirmSustainabilityHintMatchesText(string savedAs, string text)
		{
			TestReport.StartStep($"I confirm that a Sustainability Hint button is displayed under ingredient saved as: {savedAs} with the correct hover over text");
			var newProductIngredients = new Ingredients();
			var ingredient = (Ingredients.Ingredient)Context.GetFromContext(savedAs);
			if (ingredient == null)
			{
				Report.Failure("Unable to find ingredient in context saved as: " + savedAs);
				return;
			}
			var actualText = newProductIngredients.IngredientGenericWarningPopoverText(ingredient, "Sustainability Hint");
			if (actualText == null)
			{
				Report.Failure("No Sustainability Hint message was found for ingredient saved as: " + savedAs + "!");
				return;
			}
			Report.IsTrue(actualText.Replace(" ", "") == text.Replace(" ", ""),
				$"The Sustainability Hint hover over message did not match the expected text! Expected: '{text}' but found: '{actualText}'",
				"The Sustainability Hint hover over message matched the expected text: " + text);
		}

		[StepDefinition(@"I confirm that the 'Sustainability Hint' button (is displayed|is not displayed) under ingredient saved as: (.*)")]
		public void ConfirmSustainabilityHintIsDisplayed(string expectDisplayed, string savedAs)
		{
			var newProductIngredients = new Ingredients();
			var ingredient = (Ingredients.Ingredient)Context.GetFromContext(savedAs);
			if (ingredient == null)
			{
				Report.Failure("Unable to find ingredient in context saved as: " + savedAs);
				return;
			}
			var actualText = newProductIngredients.IngredientGenericWarningPopoverText(ingredient, "Sustainability Hint");
			if (expectDisplayed == "is displayed")
			{
				Report.IsTrue(actualText != null, "");
				return;
			}
			if (expectDisplayed == "is not displayed")
			{
				Report.IsTrue(actualText == null, "");
				return;
			}
			Report.Failure("Invalid step variable was provided! Must be either 'is displayed' or 'is not displayed'");
		}

		[StepDefinition(@"I click on the Sustainability Hint button under ingredient saved as: (.*)")]
		public void ClickOnSustainabilityHintButton(string savedAs)
		{
			var ingredient = (Ingredients.Ingredient)Context.GetFromContext(savedAs);
			if (ingredient == null)
			{
				Report.Failure("Unable to find ingredient in context saved as: " + savedAs);
				return;
			}
			Report.IsTrue(new Ingredients().ClickIngredientGenericWarningButton(ingredient, "Sustainability Hint"),
				"Failed to click the Sustainability Hint button for ingredient saved as: " + savedAs, "Successfully clicked the Sustainability Hint button for the ingredient saved as: " + savedAs);
		}

		[StepDefinition(@"I confirm a 'Sustainability Hint' popover element is open under ingredient saved as: (.*)")]
		public void ConfirmSutainabilityHintPopoverIsActive(string savedAs)
		{
			var ingredient = (Ingredients.Ingredient)Context.GetFromContext(savedAs);
			if (ingredient == null)
			{
				Report.Failure("Unable to find ingredient in context saved as: " + savedAs);
				return;
			}
			Report.IsTrue(new Ingredients().IngredientGernicWarningPopoverIsActive(ingredient, "Sutainability "), "The Sustainability Hint popover was not open!", "The Sustainability Hint popover was open as expected");
		}

		[StepDefinition(@"I confirm that you cannot add a new component to the formulation")]
		public void ThenIConfirmThatYouCannotAddANewComponentToTheFormulation()
		{
			NewProduct thisNewProduct = new NewProduct();
			TechTalk.SpecFlow.Table component = new TechTalk.SpecFlow.Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"});
			component.AddRow(new string[] {
				"RR-38669-6",
				"FLAVORS",
				"35",
				"Yes",
				"Undisclosed Ingredient"});
			var newProductIngredients = new Ingredients();

			string CASNo = "";
			if (component.Rows.First()["CASNumber"].Contains("WPS"))
			{
				if (Context.Contains(component.Rows.First()["CASNumber"].Split(' ')[2].Trim()))
				{
					ProductInformation CASProd =
						(ProductInformation)Context.GetFromContext(component.Rows.First()["CASNumber"].Split(' ')[2]
							.Trim());
					CASNo = "WPS" + CASProd.Id;
				}
			}
			else
			{
				CASNo = component.Rows.First()["CASNumber"];
			}
			var ingredient = new Ingredients.Ingredient();
			if (CASNo.Length > 0)
			{
				ingredient.CASNumber = CASNo;
			}
			if (component.ContainsColumn("ComponentName"))
			{
				ingredient.ComponentName = component.Rows.First()["ComponentName"];
			}
			if (component.ContainsColumn("Percentage"))
			{
				ingredient.Percent = component.Rows.First()["Percentage"];
			}
			if (component.ContainsColumn("Publicly Disclosed"))
			{
				ingredient.PublicallyDisclosed = component.Rows.First()["Publicly Disclosed"].ToLower() == "yes";
			}
			if (component.ContainsColumn("Public Name"))
			{
				ingredient.PublicName = component.Rows.First()["Public Name"];
			}
			Report.IsTrue(!newProductIngredients.AddIngredient(ingredient),
				"Successfully added ingredient",
				"As expected could not add ingredient");
		}

		[StepDefinition(@"I confirm that you cannot edit the Percentage value for any component shown")]
		public void ThenIConfirmThatYouCannotEditThePercentageValueForAnyComponentShown()
		{
			Report.IsTrue(!(new Ingredients().ConcentrationsAreEditable()),
				"Concentrations should not be editable but are", "As expected, concentrations are not editable");
		}

		[StepDefinition(@"I confirm that you cannot edit the Is this a trade secret entry for any component shown")]
		public void ThenIConfirmThatYouCannotEditTheIsThisATradeSecretEntryForAnyComponentShown()
		{
			Report.IsTrue(!(new Ingredients().TradeSecretsAreEditable()),
				"Is this a Trade secret should not be editable but is", "As expected, is this a trade secret is not editable");
		}

		[StepDefinition(@"I confirm that you can edit the Publicly Disclosed entry for any component shown")]
		public void ThenIConfirmThatYouCanEditThePubliclyDisclosedEntryForAnyComponentShown()
		{
			Report.IsTrue(new Ingredients().PubliclyDisclosedAreEditable(),
				"Publicly disclosed should be editable but is not", "As expected, publicly disclosed is editable");
		}

		[StepDefinition(@"I edit the (first|second) component to show (.*) for Publicly disclosed")]
		public void ThenIEditTheComponentToShowYesForPubliclyDisclosed(string firstOrSecond, string yesOrNo)
		{
			var newProductIngredients = new Ingredients();
			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();
			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}
			string firstIngredientName = ListOfIngredients[0].ComponentName;
			if (firstOrSecond.ToLower() == "second")
			{
				firstIngredientName = ListOfIngredients[1].ComponentName;
			}
			newProductIngredients.SetIngredientPubliclyDisclosed(firstIngredientName, (yesOrNo.ToLower() == "yes"));
			Report.Screenshot();
		}

		[StepDefinition(@"I change the percent field to (.*)")]
		public void IChangeThePercentFieldTo(string value)
		{
			var newProductIngredients = new Ingredients();
			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();
			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}
			string firstIngredientName = ListOfIngredients[0].ComponentName;
			Report.IsTrue(newProductIngredients.SetPercentageValue(firstIngredientName, value), "Could not set percentage value to " + value, "Successfully set percentage value to " + value);
		}

		[StepDefinition(@"I confirm that for the first component an error is shown below the Public Name drop down which reads: (.*)")]
		public void ThenIConfirmThatForTheFirstComponentAnErrorIsShownBelowThePublicNameDropDownWhichReads(string expectedError)
		{
			if (!new Ingredients().WaitForContainerToBeVisible())
			{
				Report.Failure("Ingredients page is not showing as expected. Navigating to it....");
				new StepsNewProduct().ClickPageHeading("Ingredients");
			}
			List<Ingredients.Ingredient> ListOfIngredients = new Ingredients().GetIngredients();
			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}
			var firstIngredientName = ListOfIngredients[0].ComponentName;
			var actualErrorMessage = new Ingredients().GetPublicNameErrorMessage(firstIngredientName);
			Report.IsTrue(actualErrorMessage == expectedError,
				"Expected error message: " + expectedError + " but got: '" + actualErrorMessage + "'",
				"Error is showing as expected" + expectedError);
		}

		[StepDefinition(@"I confirm that for the first component shows no error below the Public Name drop down")]
		public void ThenIConfirmThatForTheFirstComponentShowsNoErrorBelowThePublicNameDropDown()
		{
			var newProductIngredients = new Ingredients();
			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();
			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}
			var firstIngredientName = ListOfIngredients[0].ComponentName;
			var actualErrorMessage = newProductIngredients.GetPublicNameErrorMessage(firstIngredientName);
			Report.IsTrue(actualErrorMessage == "",
				"Expected no error message but got: '" + actualErrorMessage + "'",
				"As expected, no error is showing");
		}

		[StepDefinition(@"I edit the (first|second) component to select: (.*) from the Public Name drop down and save choice as (.*)")]
		public void ThenIEditTheFirstComponentToSelectFromThePublicNameDropDown(string firstOrSecond, string option, string saveAs)
		{
			Report.Info("Beginning I edit the " + firstOrSecond + " component to select: " + option + " from the Public Name drop down and save choice as " + saveAs);
			var newProductIngredients = new Ingredients();
			List<Ingredients.Ingredient> ListOfIngredients = newProductIngredients.GetIngredients();
			Report.Info("Found " + ListOfIngredients.Count + " ingredients");
			if (ListOfIngredients.Count == 0)
			{
				Report.Failure("No ingredients have been found to edit");
			}
			var firstIngredientName = ListOfIngredients[0].ComponentName;
			if (firstOrSecond.ToLower() == "second")
			{
				firstIngredientName = ListOfIngredients[1].ComponentName;
			}

			if (option.ToLower() == "<random>")
			{
				var availableOptions = newProductIngredients.GetIngredientPublicNameOptions(firstIngredientName);
				var filtered = availableOptions.Where(i => i != "Choose..." && i != "Undisclosed Ingredient").ToList();
				if (!filtered.Any())
				{
					option = "Undisclosed Ingredient";
				}
				else
				{
					var rnd = new Random();
					option = filtered[rnd.Next(0, filtered.Count() - 1)];
				}
			}
			Report.Info("Beginning select ingredient: " + firstIngredientName + " with option: " + option);
			newProductIngredients.SelectIngredientPublicName(firstIngredientName, option);
			Context.AddToContext(saveAs, option);
			Report.Info("Added to context name: " + saveAs + " value: " + option);
			Report.Screenshot();
		}

	}
}

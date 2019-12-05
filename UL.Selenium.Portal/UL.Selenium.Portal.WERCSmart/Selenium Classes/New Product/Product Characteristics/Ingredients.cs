using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	internal class Ingredients : NewProduct
	{
		public bool AddIngredient(Ingredient ingredient)
		{
			try
			{
				IWebElement placeholderEl = this.containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
				placeholderEl.TryClick();
				IWebElement clickResult;
				IWebElement inputEl = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'component-search')]//input[@class='select2-search__field']"), 2);
				// If the ingredient has a CAS number assigned, search by that string
				if (!string.IsNullOrEmpty(ingredient.CASNumber))
				{
					inputEl.EnterText(ingredient.CASNumber);
					IWebElement searching =
						this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.containerElement.FindElement(
							By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}

					// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
					// If no elements match this, then we will simply take the first element in the list
					IList<IWebElement> results =
						this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					if (!results.Any() || results.Any(x => x.GetValue() == "No results found"))
					{
						Report.Info("No results were returned on search");
						return false;
					}
					i = 0;
					while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) == null && i < 10)
					{
						Delay.Seconds(1);
						results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
						i++;
					}
					if (!results.Any())
					{
						return false;
					}
					// Find every result row returned which match the CAS we are looking for, exluding the 'loading' row which appears at the bottom
					IEnumerable<IWebElement> matchingCasResults = results.Where(x =>
						!x.Text.ToLower().Contains("loading") &&
						x.FindElement(By.XPath(".//span[@class='text-muted']"), 2).Text.Trim() ==
						ingredient.CASNumber.Trim());
					if (!matchingCasResults.Any())
					{
						clickResult = results.FirstOrDefault();
						ingredient.CASNumber = clickResult.FindElement(By.XPath(".//span[2]"), 2).GetValue();
						ingredient.ComponentName = clickResult.FindElement(By.XPath(".//span[1]"), 2).GetValue();
						Report.Info("No CAS match was found! Clicking the first search result with CAS number: " +
									ingredient.CASNumber);
					}
					else
					{
						// In this case we have entries with matching CAS Numbers, so we should double check that our product name matches?
						if (string.IsNullOrEmpty(ingredient.ComponentName))
						{
							// No Component name was specified, so we just take the first value with a matching CAS Number!
							clickResult = matchingCasResults.FirstOrDefault();
							Report.Info("Clicking result in smart search with CAS number: " +
										clickResult.FindElement(By.XPath(".//span[@class='text-muted']")).Text);
						}
						else
						{
							// Component name was defined, so just check to see if there is a match
							IWebElement matchingNames = matchingCasResults.FirstOrDefault(x =>
								x.FindElement(
									By.XPath(".//span[@class='component-name' and text() = '" +
											 ingredient.ComponentName + "']"), 2) != null);
							if (matchingNames == null)
							{
								// No match was found, so just take the first entry!
								clickResult = matchingCasResults.FirstOrDefault();
								Report.Info("Clicking result in smart search with CAS number: " +
											clickResult.FindElement(By.XPath(".//span[@class='text-muted']")).Text);
							}
							else
							{
								// Matching entry was found, so taking this instead!
								clickResult = matchingNames;
								Report.Info(
									"Found the matched search result. Clicking result in smart search with CAS number: " +
									ingredient.CASNumber + " and name: " + ingredient.ComponentName);
							}
						}
					}
				}
				else
				{
					Report.Info(
						"No CAS Number was assigned to the ingredient, so searching for the chemical by Component Name instead");
					inputEl.EnterText(ingredient.ComponentName);
					IWebElement searching =
						this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.containerElement.FindElement(
							By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}

					// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
					// If no elements match this, then we will simply take the first element in the list
					IList<IWebElement> results =
						this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					i = 0;
					while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='component-name']"), 2) ==
						   null && i < 20)
					{
						if (this.containerElement
								.FindElement(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2)?.Text ==
							"No results found")
						{
							Report.Info("There were no results returned searching by Name!");
							throw new Exception(
								"Unable to add the ingredient because the search criteria did not yield any!");
						}

						i++;
						Delay.Seconds(1);
						results = this.containerElement.FindElements(
							By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					}

					// Avoiding null reference exception on .GetValue() - "Loading more results" row at the bottom (no span with component-name)
					IEnumerable<IWebElement> matchingNameResults = results.Where(x =>
						!x.Text.ToLower().Contains("loading") &&
						x.FindElement(By.XPath(".//span[@class='component-name']"), 2).Text.Trim() ==
						ingredient.ComponentName.Trim());
					if (!matchingNameResults.Any())
					{
						// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
						clickResult = results.FirstOrDefault();
						ingredient.CASNumber = clickResult.FindElement(By.XPath(".//span[2]"), 2).GetValue();
						ingredient.ComponentName = clickResult.FindElement(By.XPath(".//span[1]"), 2).GetValue();
						Report.Info("There was no match on name, so selected the first search result with name: " +
									ingredient.ComponentName + " and CAS number: " + ingredient.CASNumber);
					}
					else
					{
						clickResult = matchingNameResults.FirstOrDefault();
						// We have found a match by the component name! So we should update our CAS Number field
						ingredient.CASNumber = clickResult
							.FindElement(By.XPath(".//following-sibling::span[@class='text-muted']"), 2).GetValue();
						Report.Info("Selecting the first search result which matched on chemical name: " +
									ingredient.ComponentName + " with CAS: " + ingredient.CASNumber);
					}
				}

				// Click the element we have identified as the best match
				if (clickResult.TryClick())
				{
					// So we have now selected the element, so we need to try and get the first 'new' entry which contains this CAS Number, and hasn't had the Percentage field filled
					bool success = true;
					IList<IWebElement> rows = this.containerElement.FindElements(
						By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2);
					IWebElement matchingrow = rows.FirstOrDefault(x =>
						x.FindElement(By.XPath(".//div[@class='cas-number']/small"), 2).GetValue().Trim() ==
						ingredient.CASNumber);
					if (matchingrow == null)
					{
						return false;
					}

					// Find the percentage field for the matched row
					IWebElement concInput = matchingrow.FindElement(By.XPath(".//input[contains(@class,'percent-comp')]"), 2);
					Report.Info("Entering percentage: " + ingredient.Percent);
					concInput.EnterText(ingredient.Percent);
					// Find the Publicly Disclosed field for the matched row
					IWebElement publicDisclosure = matchingrow.FindElement(By.XPath(".//td[@class='transparency']//input"), 2);
					if (publicDisclosure != null && ingredient.PublicallyDisclosed != publicDisclosure.Checked())
					{

						Report.Info("Setting Publicly Disclosed to: " + ingredient.PublicallyDisclosed);
						if (!publicDisclosure.TryCheck(ingredient.PublicallyDisclosed))
						{
							success = false;
						}
					}

					// Find the Trade Secret field for the matched row
					IWebElement tradeSecret = matchingrow.FindElement(By.XPath(".//td[@class='trade-secret']//input"), 2);
					if (tradeSecret != null && ingredient.TradeSecret != tradeSecret.Checked())
					{
						Report.Info("Setting Trade Secret to: " + ingredient.TradeSecret);
						if (!tradeSecret.TryCheck(ingredient.TradeSecret))
						{
							success = false;
						}
					}

					if (!string.IsNullOrEmpty(ingredient.PublicName))
					{
						IWebElement publicName = matchingrow.FindElement(By.XPath(".//td[@class='inci-name']//select"), 2);
						publicName.Select(ingredient.PublicName);
					}

					return success;
				}

				Report.Info("Failed to click the matched ingredient search result!");
				return false;
			}
			catch (Exception ex)
			{
				Report.Info("The ingredient could not be created: " + ex.Message);
				return false;
			}

		}

		public bool AddCACleaningIngredient(CACleaningIngredient ingredient)
		{
			bool pass = false;

			var genericIngParts = new Ingredient {
				ComponentName = ingredient.ComponentName,
				CASNumber = ingredient.CASNumber,
				Percent = ingredient.Percent,
				PublicallyDisclosed = ingredient.PublicallyDisclosed,
				TradeSecret = ingredient.TradeSecret,
				PublicName = ingredient.PublicName
			};
			this.AddIngredient(genericIngParts);

			pass = this.ISelectIngredientType(ingredient.ComponentName, ingredient.IngredientType);

			if (!pass)
			{
				Report.Info("Failed to set Ingredient Type");
				return false;
			}

			var tableFunctionalPurpose = new Table("Functional Purpose");
			string[] funcPurposes = ingredient.FunctionalPurpose.Split(',');
			foreach (string funcPurpose in funcPurposes)
			{
				pass = this.ISelectFunctionalPurpose(ingredient.ComponentName, funcPurpose.Trim());
				if (!pass)
				{
					Report.Info("Failed to set Functional Purpose");
					return false;
				}
			}

			if (ingredient.Clean)
			{
				pass = this.SelectClean(ingredient.ComponentName);
				if (!pass)
				{
					Report.Info("Failed to set Clean checkbox");
					return false;
				}
			}

			if (ingredient.Certified)
			{
				pass = this.SelectCertified(ingredient.ComponentName);
				if (!pass)
				{
					Report.Info("Failed to set Certified checkbox");
					return false;
				}
			}

			return true;
		}

		public int IngredientRowCount()
		{
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//td[@class='component-name']]"), 2);
			return rows.Count;
		}

		public bool ClickIngredientCheckbox(string input, string chemicalName)
		{
			string xPath = "";
			switch (input.ToLower())
			{
				case "publicly disclosed":
					xPath = ".//input[@class='public_disclosure']";
					break;
				case "trade secret":
					xPath = ".//input[@class='trade_secret']";
					break;
				default:
					Report.Info("invalid 'input' parameter was used. Valid inputs: 'Publicly Disclosed' or 'Trade Secret'");
					return false;
			}
			IWebElement inputEl = this.IngredientRow(chemicalName)?.FindElement(By.XPath(xPath));
			if (inputEl == null)
			{
				Report.Failure("Could not find the checkbox for input: " + input);
				Report.Screenshot();
				return false;
			}
			bool ticked = inputEl.Checked();
			if (inputEl.TryClick())
			{
				if (inputEl.Checked() == ticked)
				{
					Report.Info($"Clicked the {input} checkbox but it was not successfully set to: {!ticked}");
					Report.Screenshot();
					return false;
				}
				Report.Info($"The {input} checkbox has been {(ticked ? "unchecked" : "checked")}");
				return true;
			}
			return false;
		}

		public bool SetIngredientPubliclyDisclosed(string chemicalName, bool checked_)
		{
			IWebElement publiclyDisclosedInput = this.IngredientRow(chemicalName).FindElement(By.XPath(".//input[@class='public_disclosure']"));
			if (publiclyDisclosedInput == null || !publiclyDisclosedInput.Displayed)
			{
				Report.Failure("The Publicly Disclosed checkbox was not displayed");
				Report.Screenshot();
				return false;
			}
			if (publiclyDisclosedInput.Checked() == checked_)
			{
				Report.Info("Publicly Disclosed checkbox was already in the required state");
				return true;
			}
			return publiclyDisclosedInput.TryCheck(checked_);
		}

		public bool SetPercentageValue(string ingredient, string value)
		{
			IWebElement percentageInput = this.IngredientRow(ingredient).FindElement(By.XPath(".//input[@class='form-control percent-comp']"));
			if (percentageInput == null)
			{
				Report.Failure("Could not find the percentage input");
				return false;
			}

			return percentageInput.TryEnterTextAndTab(value);

		}

		public bool SetIngredientTradeSecret(string chemicalName, bool checkedTrueFalse)
		{
			IWebElement tradeSecretInput = this.IngredientRow(chemicalName).FindElement(By.XPath(".//input[@class='trade_secret']"));
			if (tradeSecretInput == null)
			{
				Report.Failure("Could not find the Trade Secret checkbox");
				Report.Screenshot();
				return false;
			}
			bool ticked = tradeSecretInput.Checked();

			if (ticked == checkedTrueFalse)
			{
				Report.Info("Trade Secret checkbox was already in the required state");
				return true;
			}
			else
			{
				tradeSecretInput.TryClick();

			}
			ticked = tradeSecretInput.Checked();

			if (ticked == checkedTrueFalse)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool PubliclyDisclosedTotalIsCorrect(string total)
		{
			try
			{
				string totalExpected = this.IngredientRowCount().ToString();
				string pubDisExpected = total;
				string pubDisSummary = this.containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span")).Text;
				string pubDisSummaryInt = pubDisSummary.Replace("%","");
				double percentFoundAsDouble = Convert.ToDouble(pubDisSummaryInt);
				double percentExpectedAsDouble = Convert.ToDouble(pubDisExpected) / Convert.ToDouble(totalExpected)*100;

				Report.Info($"Percent Found was: {percentFoundAsDouble}");
				Report.Info($"Percent Expected is: {percentExpectedAsDouble}");

				if(percentFoundAsDouble==percentExpectedAsDouble)
				{
					return true;
				}
				return false;
				
			}
			catch (Exception)
			{
				return false;
			}
		}

		public List<Ingredient> GetIngredients()
		{
			var Ingredients = new List<Ingredient>();
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//td[@class='component-name']]"), 2);
			foreach (IWebElement thisRow in rows)
			{
				var thisIngredient = new Ingredient {
					ComponentName =
					thisRow.FindElement(By.XPath(".//td[@class='component-name']//div[@class='chemical-name']")).Text,
					CASNumber = thisRow.FindElement(By.XPath(".//div[@class = 'cas-number']/small"), 2)?.Text,

					Percent =
					thisRow.FindElement(By.XPath(".//td[@class='percent-comp']//input|.//td[@class='percent-comp']//span")).GetAttribute("value"),
					PublicallyDisclosed =
					thisRow.FindElement(By.XPath(".//td[@class='transparency']//input")).Checked(),
					TradeSecret =
					thisRow.FindElement(By.XPath(".//td[@class='trade-secret']//input|.//td[@class='trade-secret']//span")).Checked(),
					PublicName =
					thisRow.FindElement(By.XPath(".//td[@class='inci-name']//select")).SelectedOption()
				};
				try
				{
					thisIngredient.TradeSecretEnabled = thisRow.FindElement(By.XPath(".//td[@class='trade-secret']//input")).Enabled;
				}
				catch (Exception)
				{
					thisIngredient.TradeSecretEnabled = false;
				}

				thisIngredient.PublicDisclosureEnabled = thisRow.FindElement(By.XPath(".//td[@class='transparency']//input")).Enabled;
				thisIngredient.PublicNameEnabled =
					thisRow.FindElement(By.XPath(".//td[@class='inci-name']//select")).Enabled;
				thisIngredient.Selected = thisRow.FindElement(By.XPath("./td[position()=1]/input[@type='checkbox']"), 2).Selected;
				Ingredients.Add(thisIngredient);
			}
			return Ingredients;
		}

		public bool ClickSelectIngredient(string name)
		{
			IWebElement row = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[@class='chemical-name' and contains(text(), '" + name + "')]]"), 2);
			if (row == null)
			{
				return false;
			}
			return row.FindElement(By.XPath("./td/input[@type='checkbox']"), 2).TryClick();
		}

		/// <summary>
		/// In the ingredients page, click the first search result matching on CAS, then name, from inputted ingredient. output the ingredient which was clicked
		/// </summary>
		public bool ClickIngredientFromSearchResults(Ingredient ingredient, out Ingredient ingredient_)
		{
			ingredient_ = new Ingredient();
			IWebElement resultMatch;
			//var inputEl = containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			IWebElement searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			while (searching != null && i < 10)
			{
				Delay.Seconds(1);
				i++;
				searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			}
			if (!string.IsNullOrEmpty(ingredient.CASNumber))
			{
				// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
				IList<IWebElement> results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				if (!results.Any())
				{
					Report.Info("No results were returned on search");
					return false;
				}
				int j = 0;
				bool resultFound = false;
				while (!resultFound && j < 10)
				{
					resultFound = results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) != null;
					Delay.Seconds(1);
					results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					j++;
				}
				if (!resultFound)
				{
					return false;
				}
				// Find every result row returned which match the CAS we are looking for, exluding the 'loading' row which appears at the bottom
				IEnumerable<IWebElement> matchingCasResults = results.Where(x => !x.Text.ToLower().Contains("loading") && x.FindElement(By.XPath(".//span[@class='text-muted']"), 2).Text.Trim().StartsWith(ingredient.CASNumber.Trim()));
				if (!matchingCasResults.Any())
				{
					return false;
				}
				// Add match to output ingredient
				resultMatch = matchingCasResults.FirstOrDefault();
				ingredient_.CASNumber = resultMatch.FindElement(By.XPath(".//span[@class='text-muted']"), 2)?.Text;
				ingredient_.ComponentName = resultMatch.FindElement(By.XPath(".//span[@class='component-name']"), 2)?.Text;
				return resultMatch.TryClick();
			}
			if (!string.IsNullOrEmpty(ingredient.ComponentName))
			{
				Report.Info("No CAS Number was assigned to the ingredient, so searching for the chemical by Component Name instead");
				IList<IWebElement> results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				i = 0;
				while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='component-name']"), 2) == null && i < 20)
				{
					if (this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2)?.Text == "No results found")
					{
						Report.Info("There were no results returned searching by Name!");
						return false;
					}
					i++;
					Delay.Seconds(1);
					results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				}
				// Avoiding null reference exception on .GetValue() - "Loading more results" row at the bottom (no span with component-name)
				IEnumerable<IWebElement> matchingNameResults = results.Where(x => !x.Text.ToLower().Contains("loading") && x.FindElement(By.XPath(".//span[@class='component-name']"), 2).Text.Trim().Contains(ingredient.ComponentName.Trim()));
				if (!matchingNameResults.Any())
				{
					return false;
				}
				resultMatch = matchingNameResults.FirstOrDefault();
				Report.Info("Selecting the first search result which matched on chemical name: " + ingredient.ComponentName + " with CAS: " + ingredient.CASNumber);
				ingredient_.CASNumber = resultMatch.FindElement(By.XPath(".//span[@class='text-muted']"), 2)?.Text;
				ingredient_.ComponentName = resultMatch.FindElement(By.XPath(".//span[@class='component-name']"), 2)?.Text;
				return resultMatch.TryClick();
			}
			return false;
		}

		/// <summary>
		/// In the ingredients page, enter text to the component search box
		/// </summary>
		public bool EnterTextSearchComponent(string value)
		{
			Report.Info("Entering text to the search box input");
			IWebElement inputEl = this.containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			if (inputEl == null)
			{
				Report.Info("Could not find the search input element!");
				return false;
			}
			inputEl.EnterText(value);
			Delay.Seconds(1);
			return inputEl.GetValue() == value;
		}

		public bool ClickComponentSearchPlaceholder()
		{
			Report.Info("Clicking the search box");
			IWebElement placeholderEl = this.containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
			return placeholderEl.TryClick();
		}

		public string IngredientGenericWarningPopoverText(Ingredient ingredient, string title)
		{
			string cas = ingredient.CASNumber;
			string name = ingredient.ComponentName;
			IWebElement popover;
			if (cas.IsNullOrEmpty())
			{
				if (name.IsNullOrEmpty())
				{
					return null;
				}
				popover = this.containerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
				if (popover != null && popover.Text.Contains("Sustainability Hint"))
				{
					return popover.GetAttribute("data-content");
				}
				return null;
			}
			popover = this.containerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
			if (popover != null && popover.Text.Contains("Sustainability Hint"))
			{
				return popover.GetAttribute("data-content");
			}
			return null;
		}

		public bool ClickIngredientGenericWarningButton(Ingredient ingredient, string title)
		{
			IWebElement button;
			string cas = ingredient.CASNumber;
			string name = ingredient.ComponentName;
			if (cas.IsNullOrEmpty())
			{
				if (name.IsNullOrEmpty())
				{
					return false;
				}
				button = this.containerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']"), 2);
				if (button != null && button.Text.Contains("Sustainability Hint"))
				{
					return button.FindElement(By.XPath("./a"), 2).TryClick();
				}
				return false;
			}
			button = this.containerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']"), 2);
			if (button != null && button.Text.Contains("Sustainability Hint"))
			{
				return button.FindElement(By.XPath("./a"), 2).TryClick();
			}
			return false;
		}

		public bool IngredientGernicWarningPopoverIsActive(Ingredient ingredient, string title)
		{
			string cas = ingredient.CASNumber;
			string name = ingredient.ComponentName;
			IWebElement popover;
			string popoverId = "";
			if (cas.IsNullOrEmpty())
			{
				if (name.IsNullOrEmpty())
				{
					return false;
				}
				popover = this.containerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
				if (popover != null && popover.Text.Contains("Sustainability Hint"))
				{
					popoverId = popover.GetAttribute("aria-describedby");
					return !popoverId.IsNullOrEmpty() && popoverId.StartsWith("popover");
				}
				return false;
			}
			popover = this.containerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
			if (popover != null && popover.Text.Contains("Sustainability Hint"))
			{
				popoverId = popover.GetAttribute("aria-describedby");
				return !popoverId.IsNullOrEmpty() && popoverId.StartsWith("popover");
			}
			return false;
		}

		public string GetIngredientErrorMessage()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'formulation-grid')]//div[@role='alert']//span[starts-with(@data-bind,'text')]"), 2);
			return el?.Text;
		}

		/// <summary>
		/// Set the option 'Pubic name' for named ingredient. Enter overload for a specific public name, otherwise the first name is selected
		/// </summary>
		public bool SelectIngredientPublicName(string chemicalName)
		{
			IWebElement row = this.IngredientRow(chemicalName);
			if (row == null)
			{
				Report.Info("The ingredient row was not found by chemical name: " + chemicalName);
				Report.Screenshot();
				return false;
			}
			var publicNameText = row.FindElements(By.XPath(".//td[contains(@class,'inci-name')]//option"), 2)?.Select(x => x.Text).Where(x => x != "Choose...").ToList();
			if (publicNameText == null)
			{
				return false;
			}
			Report.Info("Getting the first public name from options");
			string publicName = publicNameText[0];
			IWebElement publicNameOption = this.IngredientRow(chemicalName)?.FindElement(By.XPath(".//td[contains(@class,'inci-name')]//select[@class='form-control']"), 2);
			if (publicNameOption == null)
			{
				Report.Info("The ingredient row was not found by chemical name: " + chemicalName);
				Report.Screenshot();
				return false;
			}
			publicNameOption.Select(publicName);
			if (publicNameOption.SelectedOption() == publicName)
			{
				return true;
			}
			Report.Failure("The ingredient row for: " + chemicalName + " was found but the Public Name option was not changed");
			Report.Screenshot();
			return false;
		}

		/// <summary>
		/// Set the option 'Pubic name' for named ingredient. Enter overload for a specific public name, otherwise the first name is selected
		/// </summary>
		public bool SelectIngredientPublicName(string chemicalName, string publicName)
		{
			IWebElement publicNameOption = this.IngredientRow(chemicalName)?.FindElement(By.XPath(".//td[contains(@class,'inci-name')]//select[@class='form-control']"), 2);
			if (publicNameOption == null)
			{
				Report.Info("The ingredient row was not found by chemical name: " + chemicalName);
				Report.Screenshot();
				return false;
			}
			publicNameOption.Select(publicName);
			if (publicNameOption.SelectedOption() == publicName)
			{
				return true;
			}
			Report.Failure("The ingredient row for: " + chemicalName + " was found but the Public Name option was not changed");
			Report.Screenshot();
			return false;
		}

		public IWebElement IngredientRow(string chemicalName)
		{
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2);
			IWebElement matchingRow = rows.FirstOrDefault(x => x.FindElement(By.XPath(".//div[@class = 'chemical-name']"), 2).GetValue().Trim() == chemicalName);
			return matchingRow;
		}

		// Checks the running total of publically disclosed ingredients (eg. "1 / 3")
		public string TransparencyScoreNumerator()
		{
			Report.Info("Beginning get Transparency score numerator");
			IWebElement pubDisSummaryspan = this.containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2);
			if (pubDisSummaryspan == null)
			{
				pubDisSummaryspan = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@id='transparency-score']/span"), 2);
				if (pubDisSummaryspan == null)
				{
					Report.Error("The transparency score is not found");
					return null;
				}
			}

			string pubDisSummary = pubDisSummaryspan.GetValue();
			string pattern = @"([0123456789\.]*)\s\/\s([0123456789\.]*)";
			Match regMatch = Regex.Match(pubDisSummary, pattern);
			if (!regMatch.Success || regMatch.Groups.Count != 3)
			{
				return null;
			}
			return regMatch.Groups[1].ToString().Trim();
		}

		public string TransparencyScoreDenominator()
		{
			try
			{
				Report.Info("Beginning get Transparency score denominator");
				string pubDisSummary = this.containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2).Text;
				if (pubDisSummary == null)
				{
					pubDisSummary = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@id='transparency-score']/span"), 2).Text;
				}
				string pattern = @"([0123456789\.]*)\s\/\s([0123456789\.]*)";
				Match regMatch = Regex.Match(pubDisSummary, pattern);
				if (!regMatch.Success || regMatch.Groups.Count != 3)
				{
					return null;
				}
				return regMatch.Groups[2].ToString();
			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return null;
			}

		}

		public string TransparencyScoreStatus()
		{
			IWebElement transparencyScoreEl = this.containerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2);
			return transparencyScoreEl?.GetAttribute("class").Replace("label label-", "");
		}

		public bool ClickRegulated(string ingredientName)
		{
			IWebElement row = this.IngredientRow(ingredientName);
			return row.FindElement(By.XPath(".//a[contains(@data-bind,'openRegulation')]"), 2).TryClick();
		}

		public bool IngredientOrderbY(string orderBy)
		{
			switch (orderBy.ToLower())
			{
				case "chemical name":
					return this.containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'ChemicalName')]"))
						.TryClick();
				case "cas number":
					return this.containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'CasNumber')]"))
						.TryClick();
				case "percent":
					return this.containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'Percent')]"))
						.TryClick();
				case "publicly disclosed":
					return this.containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'PubliclyDisclosed')]"))
						.TryClick();
				case "trade secret":
					return this.containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'TradeSecret')]"))
						.TryClick();
				case "public name":
					return this.containerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'PublicName')]"))
						.TryClick();
				default:
					throw new Exception("Please provide header title");
			}

		}

		public string GetPublicNameErrorMessage(string ingredient)
		{
			try
			{
				return this.IngredientRow(ingredient)
					.FindElement(By.XPath(".//td[@class='inci-name']//p[@class='form-error']/span")).Text;
			}
			catch (Exception)
			{
				return "";
			}
		}

		public List<string> GetIngredientTableColumnHeaders()
		{
			return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//thead//th"), 2).Select(x => x.Text).ToList();
		}

		//checkbox, textbox, select
		public bool ConfirmTableInputMatchByColumnTitle(string columnTitle, string expectedInput)
		{
			IWebElement firstRow = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2).FirstOrDefault();
			IWebElement cell = firstRow.FindElements(By.XPath(".//td")).FirstOrDefault();
			switch (columnTitle)
			{
				case "Percent":
					cell = firstRow.FindElement(By.XPath(".//td[@class='percent-comp']"));
					break;
				case "Publicly Disclosed?":
					cell = firstRow.FindElement(By.XPath(".//td[@class='transparency']"));
					break;
				case "Trade Secret?":
					cell = firstRow.FindElement(By.XPath(".//td[@class='trade-secret']"));
					break;
				case "Public Name":
					cell = firstRow.FindElement(By.XPath(".//td[@class='inci-name']"));
					break;
				default:
					throw new Exception("Please provide viable column names");
			}
			switch (expectedInput)
			{
				case "checkbox":
					return cell.FindElements(By.XPath(".//input[@type='checkbox']")).Count > 0;
				case "textbox":
					return cell.FindElements(By.XPath(".//input[@type='text']")).Count > 0;
				case "select":
					return cell.FindElements(By.XPath(".//select")).Count > 0;
				default:
					throw new Exception("Please provide suitable expected input");
			}
		}

		public bool ClickSelectAllIngredients()
		{
			return this.containerElement.FindElement(By.XPath(".//th[contains(text(), 'Select All')]/input[@type='checkbox']"), 2).TryClick();
		}

		public bool SelectAllIngredientsChecked()
		{
			return this.containerElement.FindElement(By.XPath(".//th[contains(text(), 'Select All')]/input[@type='checkbox']"), 2).Checked();
		}

		public bool DeleteIngredientsDisplayed()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//td[@class='remove']/button[contains(text(), 'Delete')]"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickDeleteIngredients()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//td[@class='remove']/button[contains(text(), 'Delete')]"), 2);
			return el.TryClick();
		}

		public List<string> GetIngredientPublicNameOptions(string chemicalName)
		{
			return this.IngredientRow(chemicalName).FindElements(By.XPath(".//select/option")).Select(x => x.Text).ToList();
		}

		public bool ConcentrationsAreEditable()
		{
			return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//input[contains(@class,'percent-comp')]"), 2).FirstOrDefault() != null;

		}

		public bool TradeSecretsAreEditable()
		{
			return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//td[@class='trade-secret']//input"), 2).FirstOrDefault() != null;

		}

		public bool PubliclyDisclosedAreEditable()
		{
			return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//input[@class='public_disclosure']"), 2).FirstOrDefault() != null;

		}


		public class Ingredient
		{
			public string ComponentName { get; set; } = "";
			public string CASNumber { get; set; } = "";
			public string Percent { get; set; } = "";
			public bool PublicallyDisclosed { get; set; } = false;
			public bool TradeSecret { get; set; } = false;
			public string PublicName { get; set; } = "";
			public bool TradeSecretEnabled { get; set; } = false;
			public bool PublicDisclosureEnabled { get; set; } = false;
			public bool PublicNameEnabled { get; set; } = false;
			public bool Selected { get; set; } = false;

			public string GetDetails()
			{
				return "Component Name " + this.ComponentName + " CAS Number: " + this.CASNumber + " Percent: " + this.Percent +
					" Publicly disclosed: " + this.PublicallyDisclosed.ToString() + " Trade secret: " +
					this.TradeSecret.ToString() + " Public name: " + this.PublicName + " Trade secret enabled: " +
					this.TradeSecretEnabled + " Public disclosure enabled: " + this.PublicDisclosureEnabled +
					" Public name enabled: " + this.PublicNameEnabled + " Selected: " + this.Selected.ToString();
			}
		}

		public class CACleaningIngredient
		{
			public string ComponentName { get; set; } = "";
			public string CASNumber { get; set; } = "";
			public string Percent { get; set; } = "";
			public bool PublicallyDisclosed { get; set; } = false;
			public bool TradeSecret { get; set; } = false;
			public string PublicName { get; set; } = "";
			public string IngredientType { get; set; } = "";
			public string FunctionalPurpose { get; set; } = "";
			public bool Clean { get; set; } = false;
			public bool Certified { get; set; } = false;
			public bool TradeSecretEnabled { get; set; } = false;
			public bool PublicDisclosureEnabled { get; set; } = false;
			public bool PublicNameEnabled { get; set; } = false;
			public bool Selected { get; set; } = false;
		}

		public bool IngredientMatchesFirstOption(string inputOption)
		{
			IWebElement resultMatch;
			IList<IWebElement> results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
			if (!results.Any())
			{
				Report.Info("No results were returned on search");
				return false;
			}
			int j = 0;
			bool resultFound = false;
			while (!resultFound && j < 10)
			{
				resultFound = results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) != null;
				Delay.Seconds(1);
				results = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				j++;
			}
			if (!resultFound)
			{
				return false;
			}
			// Find every result row returned which match the CAS we are looking for, exluding the 'loading' row which appears at the bottom
			IEnumerable<IWebElement> matchingCasResults = results.Where(x => !x.Text.ToLower().Contains("loading") && x.FindElement(By.XPath(".//span[@class='component-name']"), 2).Text.Trim().StartsWith(inputOption.Trim()));
			if (!matchingCasResults.Any())
			{
				return false;
			}
			resultMatch = matchingCasResults.FirstOrDefault();
			string firstOption = resultMatch.FindElement(By.XPath(".//span[@class='component-name']"), 2)?.Text;
			Report.Info($"First option was {firstOption}");
			Report.Info($"Input option was {inputOption}");

			if (firstOption == inputOption)
			{
				Report.Success("The first option matched the input option");
				return true;
			}
			else
			{
				Report.Failure("The first option did not match the input option");
				return false;
			}



		}

		public bool ISelectIngredientType(string ingredienName, string ingredientType)
		{
			IWebElement wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredienName}']]"), 2);
			IWebElement ingredientTypeBox = wantedRow.FindElement(By.XPath(".//td//select[contains(@data-bind,'ingredientType')]"), 2);
			if (ingredientTypeBox == null)
			{
				Report.Failure("Could not find the Ingredient Type Input Box");
				return false;
			}
			ingredientTypeBox.Select(ingredientType);
			if (ingredientTypeBox.SelectedOption() == ingredientType)
			{
				Report.Info($"The correct Type was selectd. The Option selected was: {ingredientTypeBox.SelectedOption()}");
				return true;
			}
			Report.Info($"Failed to select the correct Type. The Option selected was: {ingredientTypeBox.SelectedOption()}");
			return false;

		}

		public bool ISelectAllFunctionalPurpose(string ingredientName)
		{
			IWebElement wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			IWebElement functionalPurposeBox = wantedRow.FindElement(By.XPath(".//td//select[contains(@data-bind,'functionalPurpose')]"), 2);
			if (functionalPurposeBox == null)
			{
				Report.Info("Could not find the Functional Purpose Input Box");
				return false;
			}
			bool selectedOptionSuccessfull = true;
			List<IWebElement> allOptions = functionalPurposeBox.FindElements(By.XPath(".//option[not(text()='Choose...')]"), 2).ToList();
			var allOptionsStr = new List<string>();
			foreach (var el in allOptions)
			{
				allOptionsStr.Add(el.Text);
			}
			Context.AddToContext(ingredientName + "FunctionalPurposesList", allOptionsStr);

			if (!allOptionsStr.Any())
			{
				Report.Info("Could not find any Functional purpose options to select");
				return false;
			}
			foreach (var option in allOptionsStr)
			{
				functionalPurposeBox.Select(option);
				List<IWebElement> currentlySelectedOptionsEl = wantedRow.FindElements(By.XPath($".//td//span[@class='selection']//li"), 2).ToList();

				var currentlySelectedOptionsStr = new List<string>();
				foreach (var item in currentlySelectedOptionsEl)
				{
					currentlySelectedOptionsStr.Add(item.Text);
				}
				
				if (currentlySelectedOptionsStr.Contains("×" + option))
				{
					Report.Info($"The correct Purpose was selectd.");
				}
				else
				{
					Report.Info("Failed to select the correct Purpose");
					selectedOptionSuccessfull = false;
				}

			}
			return selectedOptionSuccessfull;


		}

		public bool ISelectFunctionalPurpose(string ingredientName, string functionalPurpose)
		{
			IWebElement wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			IWebElement functionalPurposeBox = wantedRow.FindElement(By.XPath(".//td//select[contains(@data-bind,'functionalPurpose')]"), 2);
			if (functionalPurposeBox == null)
			{
				Report.Info("Could not find the Functional Purpose Input Box");
				return false;
			}
			bool selectedOptionSuccessfull = true;
			var selectedOptionsStr = new List<string>();

			if (functionalPurpose == "NA")
			{
				Report.Info("The Option to Choose was set to NA, No Funcional Purpose will be selected");
				return selectedOptionSuccessfull = true;

			}

			functionalPurposeBox.Select(functionalPurpose);

			List<IWebElement> selectedOptionsEl = wantedRow.FindElements(By.XPath($".//td//span[@class='selection']//li"), 2).ToList();


			foreach (var item in selectedOptionsEl)
			{
				selectedOptionsStr.Add(item.Text);
			}

			if (selectedOptionsStr.Contains("×" + functionalPurpose))
			{
				Report.Info($"The correct Purpose was selected.");
			}
			else
			{
				Report.Info("Failed to select the correct Purpose");
				selectedOptionSuccessfull = false;
			}
			return selectedOptionSuccessfull;
		}

		public bool SelectClean(string ingredientName)
		{
			IWebElement wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			IWebElement cleanCheckbox = wantedRow.FindElement(By.XPath(".//td//input[contains(@data-bind,'caClean')]"), 2);
			if (cleanCheckbox == null)
			{
				Report.Info("Could not find the Clean Check Box");
				return false;
			}

			return cleanCheckbox.TryClick();

		}

		public bool SelectCertified(string ingredientName)
		{
			IWebElement wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			IWebElement certifiedCheckBox = wantedRow.FindElement(By.XPath(".//td//input[contains(@data-bind,'caCertified')]"), 2);
			if (certifiedCheckBox == null)
			{
				Report.Info("Could not find the Certified Check Box");
				return false;
			}

			return certifiedCheckBox.TryClick();
		}

		internal bool TransparencyScorePercent(float p0, out float trScore)
		{
			IWebElement transparency = this.FindElement(By.XPath("//*[@id='transparency-score']/span"), 2);
			if (!float.TryParse(transparency.Text.Remove(transparency.Text.Length - 1), out trScore))
			{
				Report.Failure("Transparency score could not be evaluated to an integer value. Displayed value is: " + transparency.Text);
				return false;
			}
			return trScore == p0;
		}
	}
}

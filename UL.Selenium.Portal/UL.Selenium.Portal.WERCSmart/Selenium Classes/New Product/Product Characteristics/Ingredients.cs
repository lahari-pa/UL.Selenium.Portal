using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	internal class Ingredients : NewProduct
	{
		public bool AddIngredient(Ingredient ingredient)
		{
			try
			{
				IWebElement placeholderEl = this.ContainerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
				placeholderEl.TryClick();
				IWebElement clickResult;
				IWebElement inputEl = this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'component-search')]//input[@class='select2-search__field']"), 2);
				// If the ingredient has a CAS number assigned, search by that string
				if (!string.IsNullOrEmpty(ingredient.CASNumber))
				{
					inputEl.EnterText(ingredient.CASNumber);
					var homePage = new ChooseGoodGuide.ChooseGoodGuide_Homepage();
					homePage.WaitLoading();
					IWebElement searching =
						this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					Report.Info($"Pre-Search");
					Report.Screenshot();
					while (searching != null && i < 30)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.ContainerElement.FindElement(
							By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}
					Report.Info($"After Search");
					Report.Screenshot();

					// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
					// If no elements match this, then we will simply take the first element in the list
					IList<IWebElement> results =
						this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					if (!results.Any() || results.Any(x => x.GetValue() == "No results found"))
					{
						Report.Info("No results were returned on search");
						return false;
					}
					i = 0;
					while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) == null && i < 10)
					{
						Delay.Seconds(1);
						results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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
										clickResult.FindElement(By.XPath(".//span[@class='text-muted']"), 2).Text);
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
											clickResult.FindElement(By.XPath(".//span[@class='text-muted']"), 2).Text);
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
					var homePage = new ChooseGoodGuide.ChooseGoodGuide_Homepage();
					homePage.WaitLoading();
					IWebElement searching =
						this.ContainerElement.FindElement(By.XPath(".//li[@class='select2-results__option loading-results']//div[contains(text(),'Searching')]"), 2);
					int i = 0;
					while (searching != null && i < 30)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.ContainerElement.FindElement(
							By.XPath("//li[@class='select2-results__option loading-results']//div[contains(text(),'Searching')]"), 2);
					}

					// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
					// If no elements match this, then we will simply take the first element in the list
					IList<IWebElement> results =
						this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					i = 0;
					
					while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='component-name']"), 2) ==
						   null && i < 20)
					{
						if (this.ContainerElement
								.FindElement(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2)?.Text ==
							"No results found")
						{
							Report.Info("There were no results returned searching by Name!");
							throw new Exception(
								"Unable to add the ingredient because the search criteria did not yield any!");
						}

						i++;
						Delay.Seconds(1);
						results = this.ContainerElement.FindElements(
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
					// If access code validation use default 'WPS1434087'
					var validationModal = new ModalDialog();
					if (validationModal.WaitForContainerToBeVisible(5))
					{
						bool test1 = validationModal.EnterValidation("WPS1434087");
						bool test2 = validationModal.Click_Validate();
						Delay.Seconds(2);
					}
					// So we have now selected the element, so we need to try and get the first 'new' entry which contains this CAS Number, and hasn't had the Percentage field filled
					bool success = true;
					IList<IWebElement> rows = this.ContainerElement.FindElements(
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

					if (!string.IsNullOrEmpty(ingredient.GenericName))
					{
						IWebElement genericName = matchingrow.FindElement(By.XPath(".//td[@class='newcol']//input[@data-bind='value: GenericName.field']"), 2);
						genericName.Select(ingredient.GenericName);
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

			var ing = new Ingredient {
				ComponentName = ingredient.ComponentName,
				CASNumber = ingredient.CASNumber,
				Percent = ingredient.Percent,
				PublicallyDisclosed = ingredient.PublicallyDisclosed,
				TradeSecret = ingredient.TradeSecret,
				PublicName = ingredient.PublicName,
				GenericName = ingredient.GenericName
			};
			this.AddIngredient(ing);

			string component;
			string componentType;

			if (ingredient.ComponentName == "")
			{
				component = ingredient.CASNumber;
				componentType = @"CASNumber";

			}
			else
			{
				component = ingredient.ComponentName;
				componentType = @"ComponentName";
			}

			pass = this.ISelectIngredientType(component, ingredient.IngredientType, componentType);

			if (!pass)
			{
				Report.Info("Failed to set Ingredient Type");
				return false;
			}

			if (ingredient.TradeSecret)
			{

				pass = this.ISetGenericName(component, ingredient.IngredientType, ingredient.GenericName, componentType);

				if (!pass)
				{
					Report.Info("Failed to set Generic Name");
					return false;
				}

			}

			if (ingredient.FunctionalPurpose.Length > 0)
			{
				var tableFunctionalPurpose = new Table("Functional Purpose");
				string[] funcPurposes = ingredient.FunctionalPurpose.Split(',');
				foreach (string funcPurpose in funcPurposes)
				{
					pass = this.ISelectFunctionalPurpose(component, funcPurpose.Trim(), componentType);
					if (!pass)
					{
						Report.Info("Failed to set Functional Purpose");
						return false;
					}
				}
			}

			if (ingredient.Certified)
			{
				pass = this.SelectCertified(component, componentType);
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
			IList<IWebElement> rows = this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//td[@class='component-name']]"), 2);
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
			IWebElement publiclyDisclosedInput = this.IngredientRow(chemicalName).FindElement(By.XPath(".//input[@class='public_disclosure']"), 2);
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
			IWebElement percentageInput = this.IngredientRow(ingredient).FindElement(By.XPath(".//input[@class='form-control percent-comp']"), 2);
			if (percentageInput == null)
			{
				Report.Failure("Could not find the percentage input");
				return false;
			}

			return percentageInput.TryEnterTextAndTab(value);

		}

		public bool SetIngredientTradeSecret(string chemicalName, bool checkedTrueFalse)
		{
			IWebElement tradeSecretInput = this.IngredientRow(chemicalName).FindElement(By.XPath(".//input[@class='trade_secret']"), 2);
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
				string pubDisSummary = this.ContainerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2).Text;
				string pubDisSummaryInt = pubDisSummary.Replace("%", "");
				double percentFoundAsDouble = Convert.ToDouble(pubDisSummaryInt);
				double percentExpectedAsDouble = Convert.ToDouble(pubDisExpected) / Convert.ToDouble(totalExpected) * 100;

				Report.Info($"Percent Found was: {percentFoundAsDouble}");
				Report.Info($"Percent Expected is: {percentExpectedAsDouble}");

				if (percentFoundAsDouble == percentExpectedAsDouble)
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
			IList<IWebElement> rows = this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//td[@class='component-name']]"), 2);
			foreach (IWebElement thisRow in rows)
			{
				var thisIngredient = new Ingredient {
					ComponentName =
					thisRow.FindElement(By.XPath(".//td[@class='component-name']//div[@class='chemical-name']"), 2).Text,
					CASNumber = thisRow.FindElement(By.XPath(".//div[@class = 'cas-number']/small"), 2)?.Text,

					Percent =
					thisRow.FindElement(By.XPath(".//td[@class='percent-comp']//input|.//td[@class='percent-comp']//span"), 2).GetAttribute("value"),
					PublicallyDisclosed =
					thisRow.FindElement(By.XPath(".//td[@class='transparency']//input"), 2).Checked(),
					TradeSecret =
					thisRow.FindElement(By.XPath(".//td[@class='trade-secret']//input|.//td[@class='trade-secret']//span"), 2).Checked(),
					PublicName =
					thisRow.FindElement(By.XPath(".//td[@class='inci-name']//select"), 2).SelectedOption()
				};
				try
				{
					thisIngredient.TradeSecretEnabled = thisRow.FindElement(By.XPath(".//td[@class='trade-secret']//input"), 2).Enabled;
				}
				catch (Exception)
				{
					thisIngredient.TradeSecretEnabled = false;
				}

				thisIngredient.PublicDisclosureEnabled = thisRow.FindElement(By.XPath(".//td[@class='transparency']//input"), 2).Enabled;
				thisIngredient.PublicNameEnabled =
					thisRow.FindElement(By.XPath(".//td[@class='inci-name']//select"), 2).Enabled;
				thisIngredient.Selected = thisRow.FindElement(By.XPath("./td[position()=1]/input[@type='checkbox']"), 2).Selected;
				Ingredients.Add(thisIngredient);
			}
			return Ingredients;
		}

		public bool ClickSelectIngredient(string name)
		{
			IWebElement row = this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[@class='chemical-name' and contains(text(), '" + name + "')]]"), 2);
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
			//var inputEl = ContainerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			IWebElement searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			while (searching != null && i < 10)
			{
				Delay.Seconds(1);
				i++;
				searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			}
			if (!string.IsNullOrEmpty(ingredient.CASNumber))
			{
				// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
				IList<IWebElement> results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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
					results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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
				IList<IWebElement> results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				i = 0;
				while (results.FirstOrDefault().FindElement(By.XPath(".//span[@class='component-name']"), 2) == null && i < 20)
				{
					if (this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2)?.Text == "No results found")
					{
						Report.Info("There were no results returned searching by Name!");
						return false;
					}
					i++;
					Delay.Seconds(1);
					results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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
			ChooseGoodGuide_Homepage homepage = new ChooseGoodGuide_Homepage();
			Report.Info("Entering text to the search box input");
			IWebElement inputEl = this.ContainerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			if (inputEl == null)
			{
				Report.Info("Could not find the search input element!");
				return false;
			}
			inputEl.EnterText(value);
			homepage.WaitLoading();
			return inputEl.GetValue() == value;
		}

		public bool ClickComponentSearchPlaceholder()
		{
			Report.Info("Clicking the search box");
			IWebElement placeholderEl = this.ContainerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 2);
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
				popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
				if (popover != null && popover.Text.Contains("Sustainability Hint"))
				{
					return popover.GetAttribute("data-content");
				}
				return null;
			}
			popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
			if (popover != null && popover.Text.Contains("Sustainability Hint"))
			{
				return popover.GetAttribute("data-content");
			}
			return null;
		}

		public string IngredientGenericWarningPopoverTextScreenabilityAlert(Ingredient ingredient, string title)
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
				popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
				if (popover != null && popover.Text.Contains("Screenability Alert"))
				{
					return popover.GetAttribute("data-content");
				}
				return null;
			}
			popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
			if (popover != null && popover.Text.Contains("Screenability Alert"))
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
				button = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']"), 2);
				if (button != null && button.Text.Contains("Sustainability Hint"))
				{
					return button.FindElement(By.XPath("./a"), 2).TryClick();
				}
				return false;
			}
			button = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']"), 2);
			if (button != null && button.Text.Contains("Sustainability Hint"))
			{
				return button.FindElement(By.XPath("./a"), 2).TryClick();
			}
			return false;
		}

		public bool ClickIngredientGenericWarningButtonScreenabilityAlert(Ingredient ingredient, string title)
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
				button = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']"), 2);
				if (button != null && button.Text.Contains("Screenability Alert"))
				{
					return button.FindElement(By.XPath("./a"), 2).TryClick();
				}
				return false;
			}
			button = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']"), 2);
			if (button != null && button.Text.Contains("Screenability Alert"))
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
				popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
				if (popover != null && popover.Text.Contains("Sustainability Hint"))
				{
					popoverId = popover.GetAttribute("aria-describedby");
					return !popoverId.IsNullOrEmpty() && popoverId.StartsWith("popover");
				}
				return false;
			}
			popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
			if (popover != null && popover.Text.Contains("Sustainability Hint"))
			{
				popoverId = popover.GetAttribute("aria-describedby");
				return !popoverId.IsNullOrEmpty() && popoverId.StartsWith("popover");
			}
			return false;
		}

		public bool IngredientGernicWarningPopoverIsActiveScreenabilityAlert(Ingredient ingredient, string title)
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
				popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='chemical-name' and contains(text(),'{name}')]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
				if (popover != null && popover.Text.Contains("Screenability Alert"))
				{
					popoverId = popover.GetAttribute("aria-describedby");
					return !popoverId.IsNullOrEmpty() && popoverId.StartsWith("popover");
				}
				return false;
			}
			popover = this.ContainerElement.FindElement(By.XPath($".//tr[.//div[@class='cas-number' and ./small[contains(text(),'{cas}')]]]//div[@class='generic-warning']/a[@data-toggle='popover']"), 2);
			if (popover != null && popover.Text.Contains("Screenability Alert"))
			{
				popoverId = popover.GetAttribute("aria-describedby");
				return !popoverId.IsNullOrEmpty() && popoverId.StartsWith("popover");
			}
			return false;
		}
		public string GetDOTExceptionErrorMessage()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath("//span[contains(text(),'Please select at least one option from above.')]"), 2);
			return el?.Text;
		}
		public string GetIngredientErrorMessage()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'formulation-grid')]//div[@role='alert']//span[starts-with(@data-bind,'text')]"), 2);
			return el?.Text;
		}

		public List<string> GetAvailableIngredientsCASNumber()
		{
		
			List<IWebElement> Ingredients = this.ContainerElement.FindElements(By.XPath(".//tr//td[@class='component-name']//small[contains(text(),'')]")).ToList();
			return Ingredients.Select(x => x.GetValue()).ToList();
		
		}

		public bool ClickRemoveByCasNumber(string number)
		{

			IWebElement el = this.ContainerElement.FindElement(By.XPath($"//tr[.//td//div[small[contains(text(),'{number}')]]]//td[@class='remove delete-row']"));
			Report.Info("Attempting to click remove based on the cas number");
			return el.TryClick();
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
			IList<IWebElement> rows = this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2);
			IWebElement matchingRow = rows.FirstOrDefault(x => x.FindElement(By.XPath(".//div[@class = 'chemical-name']"), 2).GetValue().Trim() == chemicalName);
			return matchingRow;
		}

		// Checks the running total of publically disclosed ingredients (eg. "1 / 3")
		public string TransparencyScoreNumerator()
		{
			Report.Info("Beginning get Transparency score numerator");
			IWebElement pubDisSummaryspan = this.ContainerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2);
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
				string pubDisSummary = this.ContainerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2).Text;
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
			IWebElement transparencyScoreEl = this.ContainerElement.FindElement(By.XPath(".//td[@id='transparency-score']/span"), 2);
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
					return this.ContainerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'ChemicalName')]"), 2)
						.TryClick();
				case "cas number":
					return this.ContainerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'CasNumber')]"), 2)
						.TryClick();
				case "percent":
					return this.ContainerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'Percent')]"), 2)
						.TryClick();
				case "publicly disclosed":
					return this.ContainerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'PubliclyDisclosed')]"), 2)
						.TryClick();
				case "trade secret":
					return this.ContainerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'TradeSecret')]"), 2)
						.TryClick();
				case "public name":
					return this.ContainerElement
						.FindElement(By.XPath(
							"//div[contains(@class, 'formulation-grid')]//span[contains(@data-bind, 'PublicName')]"), 2)
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
					.FindElement(By.XPath(".//td[@class='inci-name']//p[@class='form-error']/span"), 2).Text;
			}
			catch (Exception)
			{
				return "";
			}
		}

		public List<string> GetIngredientTableColumnHeaders()
		{
			return this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//thead//th"), 2).Select(x => x.Text).ToList();
		}

		//checkbox, textbox, select
		public bool ConfirmTableInputMatchByColumnTitle(string columnTitle, string expectedInput)
		{
			IWebElement firstRow = this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr"), 2).FirstOrDefault();
			IWebElement cell = firstRow.FindElements(By.XPath(".//td"), 2).FirstOrDefault();
			switch (columnTitle)
			{
				case "Percent":
					cell = firstRow.FindElement(By.XPath(".//td[@class='percent-comp']"), 2);
					break;
				case "Publicly Disclosed?":
					cell = firstRow.FindElement(By.XPath(".//td[@class='transparency']"), 2);
					break;
				case "Trade Secret?":
					cell = firstRow.FindElement(By.XPath(".//td[@class='trade-secret']"), 2);
					break;
				case "Public Name":
					cell = firstRow.FindElement(By.XPath(".//td[@class='inci-name']"), 2);
					break;
				default:
					throw new Exception("Please provide viable column names");
			}
			switch (expectedInput)
			{
				case "checkbox":
					return cell.FindElements(By.XPath(".//input[@type='checkbox']"), 2).Count > 0;
				case "textbox":
					return cell.FindElements(By.XPath(".//input[@type='text']"), 2).Count > 0;
				case "select":
					return cell.FindElements(By.XPath(".//select"), 2).Count > 0;
				default:
					throw new Exception("Please provide suitable expected input");
			}
		}

		public bool ClickSelectAllIngredients()
		{
			return this.ContainerElement.FindElement(By.XPath(".//th[contains(text(), 'Select All')]/input[@type='checkbox']"), 2).TryClick();
		}

		public bool SelectAllIngredientsChecked()
		{
			return this.ContainerElement.FindElement(By.XPath(".//th[contains(text(), 'Select All')]/input[@type='checkbox']"), 2).Checked();
		}

		public bool DeleteIngredientsDisplayed()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//td[@class='remove']/button[contains(text(), 'Delete')]"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickDeleteIngredients()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//td[@class='remove']/button[contains(text(), 'Delete')]"), 2);
			return el.TryClick();
		}

		public List<string> GetIngredientPublicNameOptions(string chemicalName)
		{
			return this.IngredientRow(chemicalName).FindElements(By.XPath(".//select/option"), 2).Select(x => x.Text).ToList();
		}

		public bool ConcentrationsAreEditable()
		{
			return this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//input[contains(@class,'percent-comp')]"), 2).FirstOrDefault() != null;

		}

		public bool TradeSecretsAreEditable()
		{
			return this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//td[@class='trade-secret']//input"), 2).FirstOrDefault() != null;

		}

		public bool PubliclyDisclosedAreEditable()
		{
			return this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//input[@class='public_disclosure']"), 2).FirstOrDefault() != null;

		}

		public string GetIngredientPublicName(string chemicalName)
		{
			try
			{
				IWebElement publicNameOption = this.IngredientRow(chemicalName)?.FindElement(By.XPath(".//td[contains(@class,'inci-name')]//select[@class='form-control']"), 2);
				return publicNameOption.GetAttribute("title");
			}
			catch (Exception)
			{
				return "";
			}
		}
		public string GetIngredientPercentage(string chemicalName)
		{
			try
			{
				IWebElement percentage = this.IngredientRow(chemicalName)?.FindElement(By.XPath(".//td[contains(@class,'percent-comp')]//input[@class='form-control percent-comp']"), 2);
				return percentage.GetValue();
			}
			catch (Exception)
			{
				return "";
			}
		}
		public IList<IWebElement> CheckRetailerList()
		{
			IList < IWebElement >  retailer = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//div[@id='products-grid']//table/tbody/tr/td//li[@class='aip']"));
			return retailer;
		}
		public class Ingredient
		{
			public string ComponentName { get; set; } = "";
			public string CASNumber { get; set; } = "";
			public string Percent { get; set; } = "";
			public bool PublicallyDisclosed { get; set; } = false;
			public bool TradeSecret { get; set; } = false;
			public string PublicName { get; set; } = "";
			public string GenericName { get; set; } = "";
			public bool TradeSecretEnabled { get; set; } = false;
			public bool PublicDisclosureEnabled { get; set; } = false;
			public bool PublicNameEnabled { get; set; } = false;
			public bool GenericNameEnabled { get; set; } = false;
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

		public class CACleaningIngredient : Ingredient
		{
			public string IngredientType { get; set; } = "";
			public string FunctionalPurpose { get; set; } = "";
			public bool Clean { get; set; } = false;
			public bool Certified { get; set; } = false;
		}

		public bool IngredientMatchesFirstOption(string inputOption)
		{
			IWebElement resultMatch;
			IList<IWebElement> results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
			if (!results.Any())
			{
				Report.Info("No results were returned on search");
				return false;
			}
			int j = 0;
			bool resultFound = false;
			while (!resultFound && j < 10)
			{
				var homepage = new ChooseGoodGuide_Homepage();
				homepage.WaitLoading(); 
				resultFound = results.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) != null;
				Delay.Seconds(1);
				results = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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

		public bool ISelectIngredientType(string ingredientName, string ingredientType, string componentNameOrCASNumber)
		{
			IWebElement wantedRow;
			if (componentNameOrCASNumber == "ComponentName")
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			}
			else
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//small[text()='{ingredientName}']]"), 2);

			}

			IWebElement ingredientTypeBox = wantedRow.FindElement(By.XPath(".//td//select[contains(@data-bind,'ingredientType')]"), 2);

			if (ingredientTypeBox == null)
			{
				Report.Failure("Could not find the Ingredient Type Input Box");
				return false;
			}
			ingredientTypeBox.Select(ingredientType);
			ingredientTypeBox.SendKeys(Keys.Tab);
			Delay.Seconds(1);
			if (ingredientTypeBox.SelectedOption() == ingredientType)
			{
				Report.Info($"The correct Type was selectd. The Option selected was: {ingredientTypeBox.SelectedOption()}");
				return true;
			}
			Report.Info($"Failed to select the correct Type. The Option selected was: {ingredientTypeBox.SelectedOption()}");
			return false;

		}

		public bool ISetGenericName (string ingredientName, string ingredientType, string ingredientGenericName, string componentNameOrCASNumber)
		{
			IWebElement wantedRow;
			if (componentNameOrCASNumber == "ComponentName")
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			}
			else
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//small[text()='{ingredientName}']]"), 2);

			}

			IWebElement ingredientTypeBox = wantedRow.FindElement(By.XPath(".//td//input[@data-bind='value: GenericName.field']"), 2);

			if (ingredientTypeBox == null)
			{
				Report.Failure("Could not find the Generic Name Input Box");
				return false;
			}

			if (ingredientTypeBox.TryEnterText(ingredientGenericName))
			{
				Report.Info($"Successfully entered Generic Name");
				return true;
			}
			Report.Info($"Failed to enter Generic Name");
			return false;

		}

		public bool ISelectAllFunctionalPurpose(string ingredientName, string componentNameOrCASNumber)
		{
			IWebElement wantedRow;
			if (componentNameOrCASNumber == "ComponentName")
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			}
			else
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//small[text()='{ingredientName}']]"), 2);

			}

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

				if (currentlySelectedOptionsStr.Contains("x" + option))
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

		public bool ISelectFunctionalPurpose(string ingredientName, string functionalPurpose, string componentNameOrCASNumber)
		{
			IWebElement wantedRow;
			if (componentNameOrCASNumber == "ComponentName")
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			}
			else
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//small[text()='{ingredientName}']]"), 2);

			}
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
				Report.Info("The Option to Choose was set to NA, No Functional Purpose will be selected");
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

		public bool SelectClean(string ingredientName, string componentNameOrCASNumber)
		{
			IWebElement wantedRow;
			if (componentNameOrCASNumber == "ComponentName")
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			}
			else
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//small[text()='{ingredientName}']]"), 2);

			}
			IWebElement cleanCheckbox = wantedRow.FindElement(By.XPath(".//td//input[contains(@data-bind,'caClean')]"), 2);
			if (cleanCheckbox == null)
			{
				Report.Info("Could not find the Clean Check Box");
				return false;
			}

			return cleanCheckbox.TryClick();

		}

		public bool SelectCertified(string ingredientName, string componentNameOrCASNumber)
		{
			IWebElement wantedRow;
			if (componentNameOrCASNumber == "ComponentName")
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//div[text()='{ingredientName}']]"), 2);
			}
			else
			{
				wantedRow = this.FindElement(By.XPath($".//div[contains(@class,'col-md-12 formulation-grid')]//table//tbody//tr[.//small[text()='{ingredientName}']]"), 2);

			}

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
			IWebElement transparency = this.FindElement(By.XPath(".//*[@id='transparency-score']/span"), 2);
			if (!float.TryParse(transparency.Text.Remove(transparency.Text.Length - 1), out trScore))
			{
				Report.Failure("Transparency score could not be evaluated to an integer value. Displayed value is: " + transparency.Text);
				return false;
			}
			return trScore == p0;
		}

		public bool CheckTopSearchfieldDropdownItemsCASNumber(string casNumber)
		{
			IWebElement topSearchfieldDropdownItemCASNumber = this.FindElement(By.XPath(".//ul[@class='select2-results__options']//span[@class='text-muted'][1]"), 2);

			if (topSearchfieldDropdownItemCASNumber.Text == casNumber)
			{
				return true;
			}

			return false;
		}

		public bool SetFirstVOCOption(string yesOrNo)
		{
			IWebElement option;
			if (yesOrNo.ToLower() == "yes")
			{
				option = this.FindElement(By.XPath("//a[text()='Alternative Control Plan']/../..//label[contains(text(),'Product has been granted an ')]/../following-sibling::div//input[@value='1']"), 2);
			}
			else
			{
				option = this.FindElement(By.XPath("//a[text()='Alternative Control Plan']/../..//label[contains(text(),'Product has been granted an ')]/../following-sibling::div//input[@value='0']"), 2);
			}

			return option.TryClick();
		}

		public bool ClickTheFollowingButtonInThePopupView(string popupTitle, string buttonTitle)
		{
			IWebElement button = this.ContainerElement.FindElement(By.XPath("//div[@class='modal-content']//h4[text()='" + popupTitle + "']/../following-sibling::div[@class='modal-footer']//button[text()='" + buttonTitle + "']"), 2);
			return button.TryClick();
		}

		public bool CheckForTheFollowingButtonsInThePopupView(string popupTitle, Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement button = this.ContainerElement.FindElement(By.XPath("//div[@class='modal-content']//h4[text()='" + popupTitle + "']/../following-sibling::div[@class='modal-footer']//button[text()='" + row["Button"] + "']"), 2);
				if (button == null)
				{
					return false;
				}
			}

			return true;
		}

		public bool ClickOkInThePopupWithTheFollowingText(string text)
		{
			IWebElement okButton = this.ContainerElement.FindElement(By.XPath($"//div[@data-bind='html:okMessageText']/../../..//div[@class='modal-footer']//button[text()='Ok']"), 2);
			return okButton.TryClick();
		}

		public bool CheckACheckboxWithTheFollowingText(string text)
		{
			IWebElement checkbox = this.ContainerElement.FindElement(By.XPath($"//span[text()='{text}']/preceding-sibling::input"), 2);
			return checkbox.TryCheck();
		}

		public bool ConfirmACheckboxWithTheFollowingTextExists(string text)
		{
			IWebElement checkbox = this.ContainerElement.FindElement(By.XPath("//span[text()='" + text + "']/preceding-sibling::input"), 2);

			if (checkbox == null)
			{
				return false;
			}

			return true;
		}

		public bool CheckForTheFollowingTableColumnDataInPopupView(Table table)
		{
			IList<string> casNum = this.ContainerElement.FindElements(By.XPath("//div[@class='modal-content']//table[@class='table table-hover']//td[1]"), 2).Select(x=>x.GetValue()).ToList();
			IList<string> name = this.ContainerElement.FindElements(By.XPath("//div[@class='modal-content']//table[@class='table table-hover']//td[2]"), 2).Select(x => x.GetValue()).ToList();
			IList<string> activeOrInert = this.ContainerElement.FindElements(By.XPath("//div[@class='modal-content']//table[@class='table table-hover']//td[3]"), 2).Select(x => x.GetValue()).ToList();

			foreach (TableRow row in table.Rows)
			{
				if (!casNum.Contains(row["CAS Number"]))
				{
					Report.Info("CAS Number did not match");
					return false;
				}
				if (!name.Contains(row["Name"]))
				{
					Report.Info("Name did not match");
					return false;
				}
				if (!activeOrInert.Contains(row["Active or Inert"]))
				{
					Report.Info("Active or Inert Number did not match");
					return false;
				}

			}

			return true;


		}

		public bool CheckForTheFollowingTableColumnTitlesInPopupView(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement title = this.ContainerElement.FindElement(By.XPath("//div[@class='modal-content']//table[@class='table table-hover']//th[text()='" + row["Titles"] + "']"), 2);
				if (title == null)
				{
					return false;
				}
			}

			return true;
		}

		public bool ConfirmTheFollowingTextIsInThePopupView(string popupTitle, string text)
		{
			IList<IWebElement> textEl = this.ContainerElement.FindElements(By.XPath("//div[@class='modal-content']//h4[contains(text(), \"" + popupTitle + "\")]/../following-sibling::div//p"), 2);

			foreach (IWebElement el in textEl)
			{
				Report.Info("Found '" + el.Text + "' expected '" + text + "'");
				if (el.Text.Contains(text))
				{
					return true;
				}
			}

			return false;
		}

		public bool ConfirmThereIsAPopupViewTitled(string popupTitle)
		{
			IWebElement title = this.ContainerElement.FindElement(By.XPath("//div[@class='modal-content']//h4[contains(text(), '" + popupTitle + "')]"), 2);
			if(title.IsNullOrEmpty())
			{
				Report.Info($"The title element was found to be null or empty");
				return false;
			}
			Report.Info("found '" + title.Text + "' expected '" + popupTitle + "'");
			if (title.Text != popupTitle)
			{
				return false;
			}

			return true;
		}

		public bool SelectXForComponentNumber(string number)
		{
			IList<IWebElement> xButtons = this.ContainerElement.FindElements(By.XPath("//a[@aria-label='Delete component']"), 2);
			int numberInt = int.Parse(number);
			return xButtons[numberInt - 1].TryClick();
		}

		public bool CheckForCheckBoxWithTextInMessageAtTheTopOfIngredientsPage(string text)
		{
			IWebElement alertMessage1 = this.ContainerElement.FindElement(By.XPath("//div[@class='alert alert-info alert-dismissible']//label//input"), 2);
			return alertMessage1.TryCheck();
		}

		public bool CloseCACleaningIngredientsPopupWindow()
		{
			IWebElement closeButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div/following-sibling::div//button"), 2);
			return closeButton.TryClick();
		}
		public bool CheckForTwoErrorMessagesInPopupWithTitle(Table table, string popupTitle)
		{
			List<string> errors = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				if (row["Error"] == "Generic")
				{
					errors.Add("GenericInUse");
				}
				else if (row["Error"] == "Percent")
				{
					errors.Add("LessThan100Percent");
				}
				else if (row["Error"] == "Publicly Disclosed or Trade Secret")
				{
					errors.Add("PublicDisclosureOrTradeSecretIssue");
				}
				else if (row["Error"] == "Ingredient Type")
				{
					errors.Add("IngredientTypeMissing");
				}
				else if (row["Error"] == "Functional Purpose")
				{
					errors.Add("FragranceComponentFunctionalPurposeMismatch");
				}
				else if (row["Error"] == "Publicly Disclosed")
				{
					errors.Add("NonFunctionalIngredientDisclosureIssue");
				}
				else if (row["Error"] == "Public Name")
				{
					errors.Add("CAHCPPublicDisclosureIssues");
				}
				else if (row["Error"] == "Ingredient Type with Functional Purpose")
				{
					errors.Add("NonFunctionalIngredientTypeOrFunctionalPurposeMismatch");
				}
				else if (row["Error"] == "Third Party")
				{
					errors.Add("PVBOTThirdPartyError");
				}
				else
				{
					return false;
				}
			}

			foreach (string error in errors)
			{
				IWebElement errorEl = this.ContainerElement.FindElement(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div[@data-bind='visible: model." + error + "'][@style='display: none;']"), 2);
				if (errorEl != null)
				{
					return false;
				}
			}

			return true;
		}

		public int GetTotalErrorMessagesCountFromPopup()
		{
			List<IWebElement> errorEls = this.ContainerElement.FindElements(By.XPath($"//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div[not(@style='display: none;') and (@class='alert alert-danger')]"), 2).ToList();
			if(errorEls.IsNullOrEmpty())
			{
				Report.Error($"The errorEls list was null or empty");
				return 0;
			}
			return errorEls.Count();

		}


		public bool CheckErrorMessagofTypeFromTableeAgainstPopupWithTitle(Table table,string errorType, string popupTitle)
		{

			string errorTypeID = null;
			
			if (errorType == "Generic")
			{
				errorTypeID = "GenericInUse";
			}
			else if (errorType == "Percent")
			{
				errorTypeID = "LessThan100Percent";
			}
			else if (errorType == "Publicly Disclosed or Trade Secret")
			{
				errorTypeID = "PublicDisclosureOrTradeSecretIssue";
			}
			else if (errorType == "Ingredient Type")
			{
				errorTypeID = "IngredientTypeMissing";
			}
			else if (errorType == "Functional Purpose")
			{
				errorTypeID = "FragranceComponentFunctionalPurposeMismatch";
			}
			else if (errorType == "Publicly Disclosed")
			{
				errorTypeID = "NonFunctionalIngredientDisclosureIssue";
			}
			else if (errorType == "Public Name")
			{
				errorTypeID = "CAHCPPublicDisclosureIssues";
			}
			else if (errorType == "Ingredient Type with Functional Purpose")
			{
				errorTypeID = "NonFunctionalIngredientTypeOrFunctionalPurposeMismatch";
			}
			else if (errorType == "Third Party")
			{
				errorTypeID = "PVBOTThirdPartyError";
			}
			else
			{
				Report.Info($"errorType was not one of the expected options, could not assign errorTypeID");
				return false;
			}			

			IWebElement errorEl = this.ContainerElement.FindElement(By.XPath($"//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div[@data-bind='visible: model.{errorTypeID}']"), 2);
			if(errorEl.IsNullOrEmpty())
			{
				Report.Info($"The error was found to not be displayed");
				return false;
			}
			if (errorEl.GetAttribute("style").IsNullOrEmpty())
			{
				Report.Info("correct error type found, going to text check");
				string fullString = errorEl.Text;
				var foundStringList = fullString.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
				if(table.RowCount==foundStringList.Count())
				{
					Report.Info($"The number of rows in the table containg the expected error matched the number of sections in the found error message");

				}
				else
				{
					Report.Info($"The number of sections betweent the found and expected error did not match");
					return false;
				}
				int i = 0;
				bool allSectionsmatch = true;
				foreach (TableRow thisRow in table.Rows)
				{
					string expectedString = thisRow["ErrorSections"];
					string foundString = foundStringList[i];
					Report.Info($"The found error section {i + 1} was: {foundString}");
					Report.Info($"The expected error section {i + 1} was: {expectedString}");
					if(expectedString==foundString)
					{
						Report.Info($"The found sections in postion {i+1} matched");
					}
					else
					{
						Report.Info($"The found sections in postion {i+1} did not match");
						allSectionsmatch = false;
					}
					i++;

				}
				return allSectionsmatch;
			}
			else
			{
				Report.Info($"The error was found to not be displayed");
				return false;

			}
			
		}

		public bool CheckForErrorMessagesInPopupWithTitle(string popupTitle)
		{
			IList<IWebElement> errorMessages = this.ContainerElement.FindElements(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div"), 2);
			if (errorMessages[1].Text.Contains("Generic ingredients are not permitted as they cannot be screened for Chemicals of Concern. Each ingredient must use any of the following: Valid Chemical Abstract Service identifier(CAS number); or Valid 3rd - Party Formula registration(CAS begins with \"WPS\"); or Valid CAS Addition(CAS begins with NA) Please note that use of an ingredient with a CAS beginning with NA may result in a suspension of the registration requiring more information or details. You should always use a valid CAS number or 3rd - Party Formula before using an NA option."))
			{
				Report.Info("true");
			}
			else
			{
				Report.Info("false " + errorMessages[1].Text);
				Report.Info("false " + errorMessages[2].Text);
				Report.Info("false " + errorMessages[3].Text);
				Report.Info("false " + errorMessages[4].Text);
			}
			return true;
		}

		public bool CheckForMessageAtTheTopOfIngredientsPage()
		{
			IWebElement alertMessage = this.ContainerElement.FindElement(By.XPath("//div[@class='alert alert-info alert-dismissible']"), 2);
			if (alertMessage.Text.Contains("Note: there are special requirements for formulations that must be met in order to generate a California Cleaning Right to Know ingredient disclosure report. Formulations CANNOT contain:")
				&& alertMessage.Text.Contains("Any generic ingredient names (e.g., fragrance). Each generic ingredient name must be replaced by either a registered 3rd-Party component, or a list of the specific ingredients that comprise the generic mixture.")
				&& alertMessage.Text.Contains("An indication of the ingredient being EITHER \"Publicly Disclosed\" or \"Trade Secret\".")
				&& alertMessage.Text.Contains("For each Publicly Disclosed ingredient, select a Public Name.")
				&& alertMessage.Text.Contains("For each Trade Secret ingredient, provide a public name that is only as generic as necessary to protect its confidential identity."))
			{
				return true;
			}

			return false;
		}

		public bool ClickCloseInPopupWithTitle(string title)
		{
			IWebElement continueButton = this.ContainerElement.FindElement(By.XPath("//h4[text()='" + title + "']/../following-sibling::div[@class='modal-footer']//button"), 2);
			return continueButton.TryClick();
		}
		public bool CheckDeleteRowsWarningPopupContainsText(string lineOne, string lineTwo)
		{
			IWebElement lineOneEl = this.ContainerElement.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[1]"), 2);
			IWebElement lineTwoEl = this.ContainerElement.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[2]"), 2);

			if (lineOneEl.Text == lineOne && lineTwoEl.Text == lineTwo)
			{
				return true;
			}

			return false;
		}
	
		public bool ClickCloseButtonInFunctionalPurposeDropdownMenu()
		{
			IWebElement closeButton = this.ContainerElement.FindElement(By.XPath("//div[@class='select2-link2 select2-close']//button"), 2);
			if (closeButton == null)
			{
				return false;
			}
			return closeButton.TryClick();
		}

		public bool ConfirmTheFollowingFunctionalPurposeIsDisplayed(string functionalPurpose)
		{
			IList<IWebElement> functionalPurposesEl = this.ContainerElement.FindElements(By.XPath("//ul[@class='select2-selection__rendered']//li"), 2);
			if (functionalPurposesEl == null)
			{
				return false;
			}
			foreach (IWebElement el in functionalPurposesEl)
			{
				if (el.Text.Contains(functionalPurpose))
				{
					return true;
				}
			}
			return false;
		}

		public bool SelectTheFollowingFunctionalPurpose(string functionalPurpose)
		{
			IWebElement functionalPurposeEl = this.ContainerElement.FindElement(By.XPath("//li[@role='treeitem'][text()='" + functionalPurpose + "']"), 2);
			if (functionalPurposeEl == null)
			{
				return false;
			}
			return functionalPurposeEl.TryClick();
		}

		public bool ConfirmDropDownMenuOpensInIngredientsPage(string displayOrNotDisplayed)
		{
			IWebElement dropDownMenu = this.ContainerElement.FindElement(By.XPath("//ul[@class='select2-results__options']"), 2);

			if (displayOrNotDisplayed == "displays")
			{
				if (dropDownMenu != null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (dropDownMenu == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public bool SelectChooseOptionForFunctionalPurposeInIngredientsPage()
		{
			IWebElement chooseOption = this.ContainerElement.FindElement(By.XPath("//li[@class='select2-selection__choice']"), 2);
			if (chooseOption == null)
			{
				return false;
			}
			return chooseOption.TryClick();
		}

		public bool ConfirmCBDRegistrationPopupInIndredientsPageContainsCorrectText()
		{
			IList<IWebElement> popupMainText = this.ContainerElement.FindElements(By.XPath(@"//div[@class='alert alert-warning'][@data-bind='visible: model.HasError']//p[not(@style='display: none;')]"), 2);
			IList<IWebElement> popupListElText = this.ContainerElement.FindElements(By.XPath(@"//div[@class='alert alert-warning'][@data-bind='visible: model.HasError']//ul//li"), 2);

			if (popupMainText[0].Text.Contains("This product contains a cannabidiol (CBD) ingredient and may be subject to FDA restrictions when included in a Final Product Registration that is marketed for therapeutic or medical uses although they have not been approved by the FDA. Note that assessments conducted by UL do not include:")
				&& popupMainText[1].Text.Contains("UL's assessment includes a full review of the Product Ingredients and Type of Product to ensure the Final Product is correctly identified as a CBD-related product. Please be sure that you've properly indicated the proper Product Type based on the ingredients you've provided.")
				&& popupMainText[2].Text.Contains("For information about FDA’s approach to CBD-containing products, visit their website")
				&& popupListElText[0].Text.Contains("Marketing messages")
				&& popupListElText[1].Text.Contains("Labeling for benefit statements")
				&& popupListElText[2].Text.Contains("Health claims"))
			{
				return true;
			}
			else if (!popupMainText[0].Text.Contains("This product contains a cannabidiol (CBD) ingredient and may be subject to FDA restrictions when included in a Final Product Registration that is marketed for therapeutic or medical uses although they have not been approved by the FDA. Note that assessments conducted by UL do not include:"))
			{
				Report.Failure("The first line did not display the correct text");
			}
			else if (popupMainText[1].Text.Contains("UL's assessment includes a full review of the Product Ingredients and Type of Product to ensure the Final Product is correctly identified as a CBD-related product. Please be sure that you've properly indicated the proper Product Type based on the ingredients you've provided."))
			{
				Report.Failure("The second line did not display the correct text");
			}
			else if (popupMainText[2].Text.Contains("For information about FDA’s approach to CBD-containing products, visit their website"))
			{
				Report.Failure("The third line did not display the correct text");
			}
			else if (popupListElText[0].Text.Contains("Marketing messages"))
			{
				Report.Failure("The first list item did not display the correct text");
			}
			else if (popupListElText[1].Text.Contains("Labeling for benefit statements"))
			{
				Report.Failure("The second list item did not display the correct text");
			}
			else if (popupListElText[2].Text.Contains("Health claims"))
			{
				Report.Failure("The third list item did not display the correct text");
			}

			return false;
		}

		public bool ClickLinkInCBDRegistrationPopupInIndredientsPage()
		{
			IWebElement link = this.ContainerElement.FindElement(By.XPath(@"//div[@class='alert alert-warning'][@data-bind='visible: model.HasError']//p//a"), 2);

			if (link == null)
			{
				Report.Info("No link was found");
				return false;
			}

			return link.TryClick();
		}

		public bool CloseCBDRegistrationGuidancePopupInIngredientsPage()
		{
			IWebElement closeButton = this.ContainerElement.FindElement(By.XPath(@"//h4[text()='CBD Registration Guidance']/../..//div[@class='modal-footer']//button[@class='btn btn-default']"), 2);
			return closeButton.TryClick();
		}
		
		public bool CheckGenericNameFieldIsDisplayingForIngredient(string ingredient, string displayedOrNotDisplayed)
		{
			IWebElement genericNameField = this.ContainerElement.FindElement(By.XPath(@"//div[@class='chemical-name'][text()='" + ingredient + "']/../following-sibling::td//input[@data-bind='value: GenericName.field']"), 2);

			if (displayedOrNotDisplayed == "displayed")
			{
				if (genericNameField != null)
				{
					return true;
				}
			}
			else if (displayedOrNotDisplayed == "not displayed")
			{
				if (genericNameField == null)
				{
					return true;
				}
			}

			return false;
		}

		public bool CheckIngredientTypeDropDownIsDisplayingForIngredient(string ingredient, string displayedOrNotDisplayed)
		{

			IList <IWebElement> thList = this.ContainerElement.FindElements(By.XPath(@"//div[@class='chemical-name'][text()='" + ingredient + "']/../../../preceding-sibling::thead//th"), 2);
			int ingredientIndex = -1;

			foreach (IWebElement el in thList)
			{
				if (el.Text == "Ingredient Type")
				{
					ingredientIndex = thList.IndexOf(el);
				}
			}

			if (ingredientIndex < 0)
			{
				Report.Info("Failed to find Ingredient Type index");
				return false;
			}

			ingredientIndex += 1;

			IList <IWebElement> ingredientTypeDropDownList = this.ContainerElement.FindElements(By.XPath(@"//div[@class='chemical-name'][text()='" + ingredient + "']/../../td[" + ingredientIndex + "]//select//option"), 2);

			if (displayedOrNotDisplayed == "displayed")
			{
				if (ingredientTypeDropDownList.Count > 0)
				{
					return true;
				}
			}
			else if (displayedOrNotDisplayed == "not displayed")
			{
				if (ingredientTypeDropDownList.Count == 0)
				{
					return true;
				}
			}

			return false;
		}

		public bool EnterTextInIngredientReferenceNumberField(string text)
		{
			IWebElement field = this.ContainerElement.FindElement(By.XPath(@"//input[@data-bind='textInput: field.field, attr: { placeholder: placeholder }, enable: isReadonly() === false']"), 2);
			return field.TryEnterText(text);
		}	

		public List<string> IngredientsFIFRAPopup()
		{

			//This acts as a hardcoded list of ingredient names that cause a check for the Pesticide popup after pressing continue on the ingredients page
			//Items in this list of currently consists of ingredients used in automation that currently reside in the SHA FIFRA or FIFRAR list of components.
			//As it stands this list does not dynamically update to any changes to these component lists will need to manually input. 
			List<string> ingredients = new List<string>();
			ingredients.Add("Acetone");
			ingredients.Add("Chlorine");
			ingredients.Add("Chlorine dioxide");
			ingredients.Add("Sodium hydroxide");
			ingredients.Add("Lanolin");
			ingredients.Add("Glycerin");
			ingredients.Add("Vitamin E");
			ingredients.Add("Propane");
			ingredients.Add("7647-14-5");
			//The following may be only on fifra for staging AZ?
			ingredients.Add("Butane");
			ingredients.Add("Sodium chloride");
			ingredients.Add("Ethanol");
			ingredients.Add("Cocoa butter");
			ingredients.Add("Alcohol");
			ingredients.Add("Glycerol");
			ingredients.Add("Hydrogen peroxide");
			ingredients.Add("Copper");
			ingredients.Add("Citric acid");
			ingredients.Add("Nitrogen"); 











			return ingredients;
		}
		public bool ConfirmProductName()
		{
			IWebElement prodele = this.ContainerElement.FindElement(By.XPath(@"//h2[@class='product-name']"), 2);
			if (prodele.Displayed)
			{
				string ProductTitle = prodele.GetAttribute("title");
				Report.Info("Product Name : " + ProductTitle);
			}
			return true;
		}

		public bool ProductNameWithThreeDots()
		{
			IWebElement prodele = this.ContainerElement.FindElement(By.XPath(@"//h2[@class='product-name']"), 2);
			if (prodele.Displayed)
			{
				string cssvalue = prodele.GetCssValue("text-overflow");
				Report.Info(cssvalue);
				if (cssvalue == "ellipsis")
				{
					Report.Info("Product Name ends with 3 dots");
				}
			}
			return true;
		}


		public bool MouseHoverOnElement()
		{
			IWebElement prodele = this.ContainerElement.FindElement(By.XPath(@"//h2[@class='product-name']"), 2);
			prodele.Hover();
			return true;
		}
		public bool GetTheWPSIDForTheValidationOfProductNameFor449Characters()
		{
			IWebElement prodele = this.ContainerElement.FindElement(By.XPath(@"//h2[@class='product-name']"), 2);
			if (prodele.Displayed)
			{
				string ProductTitle = prodele.GetAttribute("title");
				string result = ProductTitle.Substring(449);
				Report.Info("WPS ID : " + result);
			}
			return true;
		}
		public bool IngredientsFieldAvailable(string field)
		{
			try
			{
				IWebElement Field = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'" + field + "')]"), 2);
				return Field != null;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool FieldAvailableInSummaryPage(string value)
		{
			try
			{
				IWebElement Value = this.ContainerElement.FindElement(By.XPath(".//p[contains(text(),'" + value + "')]"), 2);	
				return Report.IsTrue(Value.Displayed, "Failure, no text displayed.", $"Success, '{Value.Text}' displayed.");
			}
			catch (Exception)
			{
				return false;
			}
		}
		
		public bool TotalPercentage(string value)
		{
			try
			{
				IWebElement Value = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'" + value + "')]"), 2);
				return Report.IsTrue(Value.Displayed, "Failure, no text displayed.", $"Success, Total percentage : '{Value.Text}'%");
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool SelectOption()
		{
			IWebElement closeButton = this.ContainerElement.FindElement(By.XPath(@"(//span[text()='No'])[3]"), 2);
			return closeButton.TryClick();
		}
	}

}

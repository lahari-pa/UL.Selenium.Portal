using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "CACleaning")]
	class Steps_CACleaning
	{

		[RegexStepDefinition(@"I confirm I see the error message types in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle, Table table)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CheckForTwoErrorMessagesInPopupWithTitle(table, popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

		[RegexStepDefinition(@"I confirm I see the error message with text: and of type: (.*) in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheErrorOfTypeXandItMatchesTextFoundInTableForPopupWithGivenTitle(string errorType,string popupTitle,Table table)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CheckErrorMessagofTypeFromTableeAgainstPopupWithTitle(table, errorType, popupTitle), "Failed to find matching error message in popup with title " + popupTitle, "Successfully found matching error message in popup with title " + popupTitle);
		}

		[RegexStepDefinition(@"I confirm that the number of errors found in the Ingredients Popup matches the expectation of: (.*)")]
		public void ThenIConfirmErrorCountInIngredientsPopupMatchesExpected(int expectedCount)
		{
			var newProductIngredients = new Ingredients();
			Report.Info($"The found number of errors was: {newProductIngredients.GetTotalErrorMessagesCountFromPopup()}");
			Report.Info($"The expected number of errors was: {expectedCount}");
			Report.IsTrue(newProductIngredients.GetTotalErrorMessagesCountFromPopup() == expectedCount, "The counts did not match", "The number of found errors matched the expected");
		}




		[RegexStepDefinition(@"I click the 'x' button for component number (.*)")]
		public void ThenIClickTheButtonForComponentNumber(string number)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.SelectXForComponentNumber(number), "Failed to select 'x' button", "Successfully selected 'x' button");
		}

		[RegexStepDefinition(@"I check for a truck icon for UPC: saved as (.*)")]
		public void ThenICheckForATruckIconForUPCSavedAsUPC(string savedAs)
		{
			var newProductIngredients = new Ingredients();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(newProductIngredients.ConfirmTruckIconIsDisplayedForUPC(savedAs), "Failed to find truck icon for UPC: " + savedAs, "Successfully found truck icon for UPC: " + savedAs);
		}


		[RegexStepDefinition(@"I click the close button for the CA Cleaning Ingredients Popup")]
		public void ThenIClickTheCloseButtonForThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow()
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CloseCACleaningIngredientsPopupWindow(), "Failed to click close button for popup", "Successfully clicked close button for popup");
		}


		[RegexStepDefinition(@"I confirm there is a message displayed at the top of the Ingredients page")]
		public void GivenIConfirmThereIsAMessageDisplayedAtTheTopOfTheIngredientsPage()
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CheckForMessageAtTheTopOfIngredientsPage(), "Failed to find message at the top of the ingredients page", "Successfully found message at the top of the ingredients page");
		}

		[RegexStepDefinition(@"I confirm there is a checkbox with the following text: (.*) in the message displayed at the top of the Ingredients page")]
		public void GivenIConfirmThereIsACheckboxWithTheFollowingTextDonTShowThisAgainInTheMessageDisplayedAtTheTopOfTheIngredientsPage(string label)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CheckForCheckBoxWithTextInMessageAtTheTopOfIngredientsPage(label), "Failed to find checkbox in message at the top of the ingredients page with the following text: " + label, "Successfully found checkbox in message at the top of the ingredients page with the following text: " + label);
		}

		[RegexStepDefinition(@"I confirm I see the four error messages in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheFourErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CheckForErrorMessagesInPopupWithTitle(popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

		[RegexStepDefinition(@"I click the close button in the Functional Purpose dropdown menu")]
		public void ThenIClickTheCloseButtonInTheFunctionalPurposeDropdownMenu()
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.ClickCloseButtonInFunctionalPurposeDropdownMenu(), "Failed to click the close button", "Successfully clicked the close button");
		}


		[RegexStepDefinition(@"I confirm the following Functional Purpose is displayed: (.*)")]
		public void ThenIConfirmTheFollowingFunctionalPurposeIsDisplayed(string functionalPurpose)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.ConfirmTheFollowingFunctionalPurposeIsDisplayed(functionalPurpose), "Failed to confirm the following functional purposed is displayed: " + functionalPurpose, "Successfully confirmed the following functional purposed is displayed: " + functionalPurpose);
		}


		[RegexStepDefinition(@"I select the following Functional Purpose: (.*)")]
		public void ThenISelectTheFollowingFunctionalPurpose(string functionalPurpose)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.SelectTheFollowingFunctionalPurpose(functionalPurpose), "Failed to select the following functional purpose: " + functionalPurpose, "Successfully selected the following functional purpose: " + functionalPurpose);
		}


		[RegexStepDefinition(@"I confirm a dropdown menu (displays|is not displayed) in the Ingredients page")]
		public void ThenIConfirmADropdownMenuOpens(string displayOrNotDisplayed)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.ConfirmDropDownMenuOpensInIngredientsPage(displayOrNotDisplayed), "Failed to confirm dropdown menu " + displayOrNotDisplayed, "Successfully confirmed dropdown menu " + displayOrNotDisplayed);
		}

		[RegexStepDefinition(@"I click the Choose\.\.\. option for Functional Purpose in the Ingredients page")]
		public void ThenIClickTheChoose_OptioninTheIngredientsPage()
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.SelectChooseOptionForFunctionalPurposeInIngredientsPage(), "Failed to click the Choose... option", "Successfully clicked the Choose... option");
		}

	}
}

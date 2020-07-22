using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "CACleaning")]
	class Steps_CACleaning
	{

		[StepDefinition(@"I confirm I see the error message types in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle, Table table)
		{
			CACleaning caCleaning = new CACleaning();
			Report.IsTrue(caCleaning.CheckForTwoErrorMessagesInPopupWithTitle(table, popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

		[StepDefinition(@"I click the 'x' button for component number (.*)")]
		public void ThenIClickTheButtonForComponentNumber(string number)
		{
			CACleaning caCleaning = new CACleaning();
			Report.IsTrue(caCleaning.SelectXForComponentNumber(number), "Failed to select 'x' button", "Successfully selected 'x' button");
		}

		[StepDefinition(@"I check for a truck icon for UPC: saved as (.*)")]
		public void ThenICheckForATruckIconForUPCSavedAsUPC(string savedAs)
		{
			CACleaning caCleaning = new CACleaning();
			savedAs = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(caCleaning.ConfirmTruckIconIsDisplayedForUPC(savedAs), "Failed to find truck icon for UPC: " + savedAs, "Successfully found truck icon for UPC: " + savedAs);
		}


		[StepDefinition(@"I click the close button for the CA Cleaning Ingredients Popup")]
		public void ThenIClickTheCloseButtonForThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow()
		{
			CACleaning caCleaning = new CACleaning();
			Report.IsTrue(caCleaning.CloseCACleaningIngredientsPopupWindow(), "Failed to click close button for popup", "Successfully clicked close button for popup");
		}


		[StepDefinition(@"I confirm there is a message displayed at the top of the Ingredients page")]
		public void GivenIConfirmThereIsAMessageDisplayedAtTheTopOfTheIngredientsPage()
		{
			CACleaning caCleaning = new CACleaning();
			Report.IsTrue(caCleaning.CheckForMessageAtTheTopOfIngredientsPage(), "Failed to find message at the top of the ingredients page", "Successfully found message at the top of the ingredients page");
		}

		[StepDefinition(@"I confirm there is a checkbox with the following text: (.*) in the message displayed at the top of the Ingredients page")]
		public void GivenIConfirmThereIsACheckboxWithTheFollowingTextDonTShowThisAgainInTheMessageDisplayedAtTheTopOfTheIngredientsPage(string label)
		{
			CACleaning caCleaning = new CACleaning();
			Report.IsTrue(caCleaning.CheckForCheckBoxWithTextInMessageAtTheTopOfIngredientsPage(label), "Failed to find checkbox in message at the top of the ingredients page with the following text: " + label, "Successfully found checkbox in message at the top of the ingredients page with the following text: " + label);
		}



		[StepDefinition(@"I confirm I see the four error messages in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheFourErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle)
		{
			CACleaning caCleaning = new CACleaning();
			Report.IsTrue(caCleaning.CheckForErrorMessagesInPopupWithTitle(popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

	}
}

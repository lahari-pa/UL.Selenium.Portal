using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;


using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Xml;
using UL.Automation.Reporting;
using UL.Automation.Selenium.Classes;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.Utilities.Functions;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RetailerAbbreviations;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{
		public object TheProduct { get; private set; }
		public string File { get; private set; }

		//[StepDefinition(@"I confirm there is a checkbox displayed in the message at the top of the Ingredients page")]
		//public void GivenIConfirmThereIsAMessageDisplayedAtTheTopOfTheIngredientsPage()
		//{
		//	WebElements webElementsObject = new WebElements();
		//	Report.IsTrue(webElementsObject.CheckForMessageAtTheTopOfIngredientsPage(), "Failed to find message at the top of the ingredients page", "Successfully found message at the top of the ingredients page");
		//}

		[StepDefinition(@"I click the close button for the popup with the following title: (.*)")]
		public void ThenIClickTheCloseButtonForThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CloseCACleaningIngredientsPopupWindow(popupTitle), "Failed to click close button for popup with title: " + popupTitle, "Successfully clicked close button for popup with title: " + popupTitle);
		}


		[StepDefinition(@"I confirm there is a message displayed at the top of the Ingredients page")]
		public void GivenIConfirmThereIsAMessageDisplayedAtTheTopOfTheIngredientsPage()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForMessageAtTheTopOfIngredientsPage(), "Failed to find message at the top of the ingredients page", "Successfully found message at the top of the ingredients page");
		}

		//[StepDefinition(@"I confirm there is a checkbox with the following text: (.*) in the message displayed at the top of the Ingredients page")]
		//public void GivenIConfirmThereIsACheckboxWithTheFollowingTextDonTShowThisAgainInTheMessageDisplayedAtTheTopOfTheIngredientsPage(string label)
		//{
		//	WebElements webElementsObject = new WebElements();
		//	Report.IsTrue(webElementsObject.CheckForCheckBoxWithTextInMessageAtTheTopOfIngredientsPage(label), "Failed to find checkbox in message at the top of the ingredients page with the following text: " + label, "Successfully found checkbox in message at the top of the ingredients page with the following text: " + label);
		//}

		[StepDefinition(@"I confirm I see the error message types in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(Table table, string popupTitle)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTwoErrorMessagesInPopupWithTitle(popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

		[StepDefinition(@"I confirm I see the four error messages in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheFourErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForErrorMessagesInPopupWithTitle(popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

		[StepDefinition(@"I Check the Delete Rows Warning Popup contains the following text, Line One: (.*), Line Two: (.*)")]
		public void ThenICheckTheDeleteRowsWarningPopupContainsTheFollowingTextYouAreAboutToDelete(string lineOne, string lineTwo)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckDeleteRowsWarningPopupContainsText(lineOne, lineTwo), "Failed to confirm the following text in the Delete Rows Warning Popup: " + lineOne + lineTwo, "Successfully confirmed the following text in the Delete Rows Warning Popup: " + lineOne + lineTwo);
		}


		[StepDefinition(@"I check for the following text: (.*) in the Optional Reports and Documents Available for Purchase Page")]
		public void ThenICheckForTheFollowingTextInTheOptionalReportsAndDocumentsAvailableForPurchasePage(string text)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingTextInTheOptionReportsPage(text), "Failed to confirm the following text: " + text + " in the Optional Reports page", "Successfully confirmed the following text: " + text + " in the Optional Reports page");
		}

		[StepDefinition(@"I confirm the correct UPC: saved as (.*) is displayed in the UPC Number textfield")]
		public void ThenIConfirmTheCorrectUPCSavedAsUPCIsDisplayedInTheUPCNumberTextfield(string savedAs)
		{
			savedAs = Context.GetFromContext(savedAs).ToString();
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmUPCNumberIsDisplayedInUPCNumberField(savedAs), "Failed to confirm UPC Number field contains UPC: " + savedAs, "Successfully confirmed UPC Number field contains UPC: " + savedAs);
		}


		[StepDefinition(@"I confirm the Container Type field is below the UPC Number field")]
		public void ThenIConfirmTheContainerTypeFieldIsBelowTheUPCNumberField()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmContainerTypeFieldIsBelowUPCNumberField(), "Failed to confirm Container Type field is below UPC Number field", "Successfully confirmed Container Type field is below UPC Number field");
		}


		[StepDefinition(@"I confirm that the truck icon is displaying next to the case UPC: saved as (.*)")]
		public void ThenIConfirmThatTheTruckIconIsDisplayingNextToTheCaseUPCSavedAsUPC(string savedAs)
		{
			savedAs = Context.GetFromContext(savedAs).ToString();
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmTruckIconIsDisplayingNextToUPC(savedAs), "Failed to confirm truck icon is displayd with the UPC: " + savedAs, "Successfuly confirmed truck icon is displayd with the UPC: " + savedAs);
		}


		[StepDefinition(@"I check if the case UPC details are collapsed for UPC: saved as (.*)")]
		public void ThenICheckIfTheCaseUPCDetailsAreCollapsedForUPCSavedAsUPC(string savedAs)
		{
			savedAs = Context.GetFromContext(savedAs).ToString();
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmCaseUPCDetailsAreCollapsedForUPC(savedAs), "Failed to confirm case UPC details are collapsed with the UPC: " + savedAs, "Succesfully confirmed case UPC details are collapsed with the UPC: " + savedAs);
		}


		[StepDefinition(@"I select the case UPC dropdown arrow to (expand|collapse) the UPC saved as: (.*)")]
		public void ThenISelectTheCaseUPCDropdownArrowForUPCSavedAsUPC(string expandOrCollapse, string savedAs)
		{ 
			savedAs = Context.GetFromContext(savedAs).ToString();
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectCaseUPCDropDownArrowForUPC(savedAs, expandOrCollapse), "Failed to select dropdown arrow with the UPC: " + savedAs, "Succesfully selected dropdown arrow with the UPC: " + savedAs);
		}


		[StepDefinition(@"I confirm the case dropdown with the following UPC: saved as (.*) (should|should not) be available for selection")]
		public void ThenIConfirmTheCaseDropdownWithTheFollowingUPCSavedAsUPCIsAvailableForSelection(string savedAs, string shouldOrShouldNot)
		{
			savedAs = Context.GetFromContext(savedAs).ToString();
			WebElements webElementsObject = new WebElements();

			if (shouldOrShouldNot == "should")
			{
				Report.IsTrue(webElementsObject.ConfirmCaseDropDownWithUPCIsAvailableForSelection(savedAs), "Failed to confirm that the dropdown with the UPC: " + savedAs + " is available for selection", "Confirmed that the dropdown with the UPC: " + savedAs + " is available for selection");
			} else
			{
				Report.IsTrue(!webElementsObject.ConfirmCaseDropDownWithUPCIsAvailableForSelection(savedAs), "Failed to confirm that the dropdown with the UPC: " + savedAs + " is not available for selection", "Confirmed that the dropdown with the UPC: " + savedAs + " is not available for selection");
			}
		}


		[StepDefinition(@"I confirm a case dropdown contains the following UPC: saved as (.*)")]
		public void ThenIConfirmACaseDropdownContainsTheFollowingUPCSavedAsUPC(string savedAs)
		{
			savedAs = Context.GetFromContext(savedAs).ToString();
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmCaseDropDownContainsUPC(savedAs), "Failed to confirm that the dropdown contained the UPC: " + savedAs, "Confirmed that the dropdown contained the UPC: " + savedAs);
		}


		[StepDefinition(@"I confirm that the the option: (.*) (.*) checked for the following section: (.*)")]
		public void ThenIConfirmThatTheTheOptionCheckedForTheFollowingSection(string option, string isOrIsNot, string section)
		{
			WebElements webElementsObject = new WebElements();

			if (isOrIsNot.ToLower() == "is")
			{
				Report.IsTrue(webElementsObject.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was not checked", "The option " + option + " was checked");
			} else
			{
				Report.IsTrue(!webElementsObject.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was checked", "The option " + option + " was not checked");
			}
		}

		[StepDefinition(@"I confirm that the following section is available for selection: (.*)")]
		public void ThenIConfirmThatTheFollowingSectionIsAvailableForSelection(string sectionName)
		{
			WebElements webElementsObject = new WebElements();
			webElementsObject.ConfirmSectionIsAvailableForSelection(sectionName);
		}


		[StepDefinition(@"I click close for the warning popup titled: (.*)")]
		public void ThenIClickContinueForTheWarningPopupTitledCaliforniaCleaningRightToKnow(string title)
		{
			WebElements webElementsObject = new WebElements();
			webElementsObject.ClickCloseInPopupWithTitle(title);
		}


	}
}

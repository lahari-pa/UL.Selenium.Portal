using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SummaryPage")]
	class Steps_Summary
	{
		[StepDefinition(@"in the Summary page I save the UPC number to context as: (.*)")]
		public void SaveUPCToContext(string savedAs)
		{
			string upc = new SummaryPage().UPCNumber();
			Report.Info("Adding UPC number: " + upc + " to context as: " + savedAs);
			Context.AddToContext(savedAs, upc);
		}

		[StepDefinition(@"in the Summary page I save the Product ID to context as: (.*)")]
		public void SaveProductIDToContext(string savedAs)
		{
			string productID = new SummaryPage().ProductID();
			Report.Info("Adding Product ID: " + productID + " to context as: " + savedAs);
			Context.AddToContext(savedAs, productID);
		}

		[StepDefinition(@"in the Summary page the UPC number should match that saved as: (.*)")]
		public void SummaryPageUPCShouldMatchSavedAs(string savedAs)
		{
			string actualUPC = new SummaryPage().UPCNumber();
			string expectedUPC = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(expectedUPC == actualUPC,
				"The actual UPC number did not match the expected value! Expected: " + expectedUPC + ". Actual: " + actualUPC,
				"The actual UPC number matched the expected value: " + expectedUPC);
		}

		[StepDefinition(@"the Summary page loads with no errors")]
		public void TheSummaryPageLoadsWithNoErrors()
		{
			var selSummaryPage = new SummaryPage();
			Report.IsTrue(GeneralUtilities.WaitForSpinnerToDisappear(selSummaryPage.LoadingSpinner()),
				"The Summary page did not complete loading",
				"The Summary page completed loading");

		}

		[StepDefinition(@"In the Data Summary page I confirm that the following items are included in the kit:")]
		public void ThenInTheDataSummaryPageIConfirmThatTheFollowingItemsAreIncludedInTheKit(Table table)
		{
			var selSummaryPage = new SummaryPage();
			List<string> kitContents = selSummaryPage.GetKitContents();
			foreach (TableRow row in table.Rows)
			{
				string kit = row["Kit items"];
				if (kit.ToLower().Contains("saved as"))
				{
					var piKit = (ProductInformation)Context.GetFromContext(kit
						.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
					kit = piKit.Id;
				}

				Report.IsTrue(kitContents.FirstOrDefault(x => x.Contains(kit)) != null, "Expecting kit list to show: " + kit,
					kit + " is showing as expected");
			}
		}

		//| Question | Answer | True or False |
		[StepDefinition(@"In the Data Summary page I confirm the following questions and answers")]
		public void ThenInTheDataSummaryPageIConfirmTheFollowingQuestionsAndAnswers(Table table)
		{
			var selSummaryPage = new SummaryPage();
			foreach (TableRow row in table.Rows)
			{
				string answer = selSummaryPage.GetAnswerToQuestion(row["Question"]);
				if (row["True or False"] == "True")
				{
					Report.IsTrue(answer == row["Answer"], "Expected answer: " + row["Answer"] + " but got: " + answer);
				}
				else
				{
					Report.IsTrue(answer != row["Answer"], "Expected answer: " + row["Answer"] + " but got: " + answer);
				}
			}
		}

		[StepDefinition(@"In the Data Summary page I confirm that I do not see any errors")]
		public void ThenInTheDataSummaryPageIConfirmThatIDoNotSeeAnyErrors()
		{
			//Under construction
		}

		//| Document  | Language |
		[StepDefinition(@"In the Summary document I confirm that the following Additional documents are showing")]
		public void GivenInTheSummaryDocumentIConfirmThatTheFollowingAdditionalDocumentsAreShowing(Table table)
		{
			Context.ScenarioContext.Pending();
		}

		[StepDefinition(@"I navigate to the View tab for product saved as: (.*) and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'")]
		public void INavigateToTheViewTabAndCheckForUPCNameColoumn(string savedAs)
		{
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string tabtitle = productDetails.Name + " (" + productDetails.Id + ")";
			new GlobalSteps().SwitchToTabWithTitle(tabtitle);
			new Steps_Summary().TheSummaryPageLoadsWithNoErrors();

			Report.IsTrue(new SummaryPage().DoesUPCHeadingsContain("UPC Name"), "Failed to find the Heading name 'UPC Name'", "Successfully found the Heading name 'UPC Name'");


			new GlobalSteps().ThenCloseTheWindowThatOpened();
		}

		[StepDefinition(@"I Switch to the View tab for product saved as: (.*)")]
		public void INavigateToTheViewTabForProductSavedAs(string savedAs)
		{
			Delay.Seconds(20);
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string tabtitle = productDetails.Name + " (" + productDetails.Id + ")";
			new GlobalSteps().SwitchToTabWithTitle(tabtitle);
			new Steps_Summary().TheSummaryPageLoadsWithNoErrors();
		}

		[StepDefinition(@"I Check that the Summary page Ingredients table contains the coloumns labeled:")]
		public void INavigateToTheViewTabAndCheckForIngredientsColumnsFromATable(Table table)
		{

			foreach (TableRow row in table.Rows)
			{
				string headingName = row["Heading"];

				Report.IsTrue(new SummaryPage().DoesIngredientHeadingsContain(headingName), "Failed to find the Heading name: " + headingName, "Successfully found the Heading name: " + headingName);
			}

		}
		[StepDefinition(@"I Check that the Ingredients table on the Summary page for the ingredient: (.*) contains the Ingredient Type: (.*)")]
		public void ICheckThatTheIngredientsTableForIngredientXContainsOnlyYTypes(string ingredient, string type)
		{
			Report.IsTrue(new SummaryPage().IngredientTypesMatch(ingredient, type), "The Ingredient Type wwas not a match", "The ingredient Type was a match");
		}

		[StepDefinition(@"I Check that the Ingredients table on the Summary page for the ingredient: (.*) contains only the following Functional Purposes saved as: (.*)")]
		public void ICheckThatTheIngredientsTableForIngredientXContainsOnlyYPurposes(string ingredient, string listSavedAs)
		{
			var chosenPurposes = (List<string>)Context.GetFromContext(listSavedAs);
			Report.IsTrue(new SummaryPage().FunctionalPurposesMatch(ingredient, chosenPurposes), "The Functional Purposes were not an exact match", "The Functional Purposes were an exact match");
		}

		[StepDefinition(@"For the following ingredients I check that the Ingredients table on the summary page contains only the Ingredient Types and Functional Purposes listed:")]
		public void ForTheFollowingIngredientsICheckThatTheIngredientsTableOnTheSummaryPageContainsOnlyTheIngredientsTypesAndFunctionalPurposesListed(Table table)
		{

			foreach (TableRow row in table.Rows)
			{
				this.ICheckThatTheIngredientsTableForIngredientXContainsOnlyYTypes(row["Ingredient"], row["Ingredient Type"]);
				this.ICheckThatTheIngredientsTableForIngredientXContainsOnlyYPurposes(row["Ingredient"], row["Functional Purpose"]);
			}

		}

		[StepDefinition(@"In the section 'Select all modes of transport that you've classified the product for', I see (DOT|IATA|IMDG|TDG) listed at (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void InTheSectionSelectAllModesISeeOptionListedAtLevel(string option, string transLevel)
		{
			Report.IsTrue(new SummaryPage().CheckProductLevelTransportation(option, transLevel), "Failed to find option " + option + " listed in the summary screen as " + transLevel + ".",
				"Successfully found option " + option + " listed in the summary screen as " + transLevel + ".");
		}

		[StepDefinition(@"I ensure that the UPC table displays a column called '(.*)'")]
		public void IEnsureThatTheProviceProductUPCTableDisplaysAColumnCalled(string colName)
		{
			Report.IsTrue(new SummaryPage().DoesUPCHeadingsContain(colName), "Failed to find column name " + colName + " in UPC Table",
				"Successfully found column name " + colName + " in UPC Table.");
		}

		[StepDefinition(@"In the Summary screen UPC table, I ensure that (DOT|IATA|IMDG|TDG) is listed as (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void InTheSummaryScreenUPCTableIEnsureThatOptionsIsListedAsLevel(string option, string level)
		{
			Report.IsTrue(new SummaryPage().DoesUPCTransportationColumnContain(option, level), "Failed to find option " + option + " at level " + level + " in the UPC Transportation column.",
				"Successfully found option " + option + " at level " + level + " in the UPC Transportation column.");
		}

		[StepDefinition(@"I wait for the Summary Screen to Load")]
		public void IWaitForTheSummaryScreenToLoad()
		{
			Report.IsTrue(new UpdateDataSummaryPage().WaitForSummaryPageToLoad(60),"The page did not load","The page loaded");
		}

		[StepDefinition(@"In the Summary screen, I click the Edit Product Button")]
		public void InTheSummaryScreenIClick()
		{
			Report.IsTrue(new UpdateDataSummaryPage().ClickEditProduct(), "Failed to click the button", "Succesfully clicked the button");
		}
	}
}

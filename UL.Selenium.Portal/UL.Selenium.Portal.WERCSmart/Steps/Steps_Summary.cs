using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

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

			Report.IsTrue(new SummaryPage().DoesUPCHeadingsContain("UPC Name"), "Failed to find the Heading name 'UPC Name'", "Succesfully found the Heading name 'UPC Name'");


			new GlobalSteps().ThenCloseTheWindowThatOpened();
		}

	}
}

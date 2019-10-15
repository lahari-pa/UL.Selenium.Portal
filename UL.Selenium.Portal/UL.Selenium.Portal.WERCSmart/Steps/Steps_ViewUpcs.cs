using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;




namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ViewUpcs")]
	class Steps_ViewUpcs
	{
		[StepDefinition(@"I save the UPCs associated to the product as: (.*)")]
		public void SaveUpcsToContext(string savedAs)
		{
			var upcNumbers = new List<string>();
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			foreach (ViewUpcs.ProductUpc upc in upcs)
			{
				upcNumbers.Add(upc.UpcNumber);
			}
			Report.Info("there are " + upcNumbers.Count + " upc numbers to save");
			Report.Info("Saving to context as: " + savedAs);
			Context.AddToContext(savedAs, upcNumbers);
		}

		[StepDefinition(@"I confirm that the number of UPCs equals the number saved as: (.*)")]
		public void ConfirmThatNumberOfUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of UPCs did not match the number saved!",
				"Number of UPCs matches number saved.");
		}

		[StepDefinition(@"I confirm that the number of normal UPCs equals the number saved as: (.*)")]
		public void ConfirmThatNumberOfNormalUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().NormalUPCs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of normal UPCs did not match the number saved!",
				"Number of normal UPCs matches number saved.");
		}

		[StepDefinition(@"I confirm that the number of Case UPCs equal the number saved as: (.*)")]
		public void ConfirmThatNumberOfCaseUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().CaseUPCs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of Case UPCs did not match the number saved!",
				"Number of Case UPCs matches number saved.");
		}

		[StepDefinition(@"I save the first UPC associated to the product as: (.*)")]
		public void SaveFirstUpcToContext(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			if (!upcs.Any())
			{
				Report.Failure("No UPC numbers were found!");
				return;
			}
			Report.Info("UPC number: " + upcs.First());
			Context.AddToContext(savedAs, upcs.First());
		}

		[StepDefinition(@"I navigate to the View UPC tab and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'")]
		public void INavigateToTheViewUPCTabAndCheckForUPCNameColoumn()
		{
			new GlobalSteps().SwitchToTabWithTitle("View UPCs");

			Report.IsTrue(new ViewUpcs().DoesUPCHeadingsContain("UPC Name"),"Failed to find the Heading name 'UPC Name'", "Succesfully found the Heading name 'UPC Name'");				   


			new GlobalSteps().ThenCloseTheWindowThatOpened();
		}

		[StepDefinition(@"the View UPC page loads with no errors")]
		public void TheViewUPCPageLoadsWithNoErrors()
		{
			var upcviewpg= new ViewUpcs();
			Report.IsTrue(GeneralUtilities.WaitForSpinnerToDisappear(upcviewpg.LoadingSpinner()),
				"The View UPC page did not complete loading",
				"The View UPC page completed loading");

		}



	}

}

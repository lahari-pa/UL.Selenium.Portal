using Reqnroll;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ViewUpcs")]
	class Steps_ViewUpcs
	{
		[RegexStepDefinition(@"I save the UPCs associated to the product as: (.*)")]
		public void SaveUpcsToContext(string savedAs)
		{
			this.TheViewUPCPageLoadsWithNoErrors();
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

		[RegexStepDefinition(@"I confirm that the number of UPCs equals the number saved as: (.*)")]
		public void ConfirmThatNumberOfUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of UPCs did not match the number saved!",
				"Number of UPCs matches number saved.");
		}

		[RegexStepDefinition(@"I confirm that the number of normal UPCs equals the number saved as: (.*)")]
		public void ConfirmThatNumberOfNormalUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().NormalUPCs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of normal UPCs did not match the number saved!",
				"Number of normal UPCs matches number saved.");
		}

		[RegexStepDefinition(@"I confirm that the number of Case UPCs equal the number saved as: (.*)")]
		public void ConfirmThatNumberOfCaseUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().CaseUPCs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of Case UPCs did not match the number saved!",
				"Number of Case UPCs matches number saved.");
		}

		[RegexStepDefinition(@"I save the first UPC associated to the product as: (.*)")]
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

		[RegexStepDefinition(@"I confirm the UPC number saved as: (.*) is displayed as a Case UPC")]
		public void ConfirmUpcNumberIsDisplayedAsCaseUpc(string savedAs)
		{
			if (!Context.Contains(savedAs))
			{
				return;
			}
			var upc = Context.GetFromContext(savedAs);
			var caseUpcs = new ViewUpcs().CaseUPCs();
			Report.IsTrue(caseUpcs.Any(x => x.UpcNumber == upc), "");

		}

		[RegexStepDefinition(@"I save all UPC information on the 'View UPCs' page as: (.*)")]
		public void SaveAllViewUpcInformationAs(string savedAs)
		{
			var upcs = new ViewUpcs().Upcs();
			if (upcs is null)
			{
				Report.Error("No UPC data was displayed!");
				return;
			}
			Context.AddToContext(savedAs, upcs);
		}

		/// <summary>
		/// Requires a table with columns: | UPC Number | Container Type | Size Ounces | Retailers | Associated UPC | Quantity | Transport |
		/// </summary>
		[RegexStepDefinition(@"I verify the Case UPC data is correct in the View UPCs window:")]
		public void VerifyCaseUpcData(Table table)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			foreach (var row in table.Rows)
			{
				var thisUpc = row["UPC Number"];
				thisUpc = Context.GetFromContextRegex(thisUpc)?.ToString() ?? thisUpc;
				var matchingUpc = upcs.FirstOrDefault(x => x.UpcNumber == thisUpc);
				Report.StartStep("I confirm that I see the Case UPC Number");
				Report.Info("Expected Case UPC: " + thisUpc);
				if (matchingUpc == null)
				{
					Report.Failure("The Case UPC Number was not displayed!");
					continue;
				}
				Report.Success("The Case UPC Number was displayed");
				Report.Screenshot();
				Report.StartStep("I confirm the truck icon is shown next to the Case UPC Number (this indicates we have a Case UPC) ");
				Report.IsTrue(matchingUpc.TruckIcon, $"The truck icon was not shown next to the Case UPC number: {thisUpc}!", $"The truck icon was displayed by Case UPC Number: {thisUpc}");
				Report.StartStep("I Confirm you see the UPC Number you selected as the Individual UPC contained in the Case Pack shown under the Associated UPC column for the Case UPC");
				var associatedUpc = row["Associated UPC"];
				associatedUpc = Context.GetFromContextRegex(associatedUpc)?.ToString() ?? associatedUpc;
				Report.IsTrue(matchingUpc.AssociatedUpc == associatedUpc, "The Associated UPC value did not match the entered Individual UPC " + associatedUpc, "The Associated UPC value matched the entered Individual UPC");
				Report.StartStep("I Confirm that I see the value I entered in the Container Type column for the Case UPC");
				Report.IsTrue(matchingUpc.ContainerType == row["Container Type"], $"The Container Type column did not match expected value for the Case UPC: {thisUpc}! Expected: {row["Container Type"]} but got: {matchingUpc.ContainerType}", $"The Container Type column matched the expected value for the Case UPC: {thisUpc}");
				Report.StartStep("I Confirm that I see the value I entered in the Size column for the Case UPC");
				Report.IsTrue(matchingUpc.SizeOunces == row["Size Ounces"], $"The Size (Ounces) column did not match expected value for the Case UPC: {thisUpc}! Expected: {row["Size Ounces"]} but got: {matchingUpc.SizeOunces}", $"The Size (Ounces) column matched the expected value for the Case UPC: {thisUpc}");
				Report.StartStep("I Confirm that I see the value I entered in the Quantity column for the Case UPC");
				Report.IsTrue(matchingUpc.Quantity == row["Quantity"], $"The Quantity column did not match expected value for the Case UPC: {thisUpc}! Expected: {row["Quantity"]} but got: {matchingUpc.Quantity}", $"The Quantity column matched the expected value for the Case UPC: {thisUpc}");
				Report.StartStep("I Confirm that I see the value I entered in Transportation Options for the Case UPC");
				Report.IsTrue(matchingUpc.Transport == row["Transport"], $"The Transport column did not match expected value for the Case UPC: {thisUpc}! Expected: {row["Transport"]} but got: {matchingUpc.Transport}", $"The Transport column matched the expected value for the Case UPC: {thisUpc}");
				Report.StartStep("I Confirm that the Retailer column shows the retailer you selected for the Case UPC");
				Report.IsTrue(matchingUpc.Retailers.Contains(row["Retailer"]), "Retailers column did not contain retailer: " + row["Retailer"] + "!", "Retailers column contained retailer: " + row["Retailer"]);
			}
		}

		[RegexStepDefinition(@"I verify the Regular UPC data is correct in the View UPCs window:")]
		public void VerifyRegularUpcData(Table table)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			foreach (var row in table.Rows)
			{
				var thisUpc = row["UPC Number"];
				if (Context.GetFromContextRegex(thisUpc, out var result))
				{
					thisUpc = result.ToString();
				}
				var matchingUpc = upcs.FirstOrDefault(x => x.UpcNumber == thisUpc);
				Report.StartStep("I confirm that I see the Regular UPC Number in the UPC Number column");
				Report.Info("Expected regular UPC: " + thisUpc);
				if (matchingUpc == null)
				{
					Report.Failure("The regular UPC Number was not displayed!");
					continue;
				}
				Report.Success("The regular UPC Number was displayed");
				Report.Screenshot();
				Report.StartStep("I Confirm that the regular UPC row does not show the truck icon");
				Report.IsTrue(!matchingUpc.TruckIcon, $"The truck icon was shown next to the regular UPC number: {thisUpc}!", $"The truck icon was not displayed by the regular UPC Number: {thisUpc}");
				Report.StartStep("I Confirm that the Associated column for the regular UPC is blank");
				Report.IsTrue(matchingUpc.AssociatedUpc.IsNullOrEmpty(), "The Associated UPC column was not blank!", "The Associated UPC column was blank");
				Report.StartStep("I Confirm that I see the value I entered in the Container Type column for the regular UPC");
				Report.IsTrue(matchingUpc.ContainerType == row["Container Type"], $"The Container Type column did not match expected value for the regular UPC: {thisUpc}! Expected: {row["Container Type"]} but got: {matchingUpc.ContainerType}", $"The Container Type column matched the expected value for the regular UPC: {thisUpc}");
				Report.StartStep("I Confirm that I see the value I entered in the Size column for the regular UPC");
				Report.IsTrue(matchingUpc.SizeOunces == row["Size Ounces"], $"The Size (Ounces) column did not match expected value for the regular UPC: {thisUpc}! Expected: {row["Size Ounces"]} but got: {matchingUpc.SizeOunces}", $"The Size (Ounces) column matched the expected value for the regular UPC: {thisUpc}");
				Report.StartStep("I Confirm that the Quantity and Transport columns for the regular UPC are blank");
				Report.IsTrue(matchingUpc.Transport.IsNullOrEmpty() && matchingUpc.Quantity.IsNullOrEmpty(), $"Transport and Quanity columns were not empty for the regular UPC! Displayed were Transport: {matchingUpc.Transport}, Quantity: {matchingUpc.Quantity}", "Transport and Quantity columns were empty for the regular UPC");
				Report.StartStep("I Confirm that the Retailer column shows the retailer you selected for the regular UPC");
				Report.IsTrue(matchingUpc.Retailers.Contains(row["Retailer"]), "Retailers column did not contain retailer: " + row["Retailer"] + "!", "Retailers column contained retailer: " + row["Retailer"]);
			}
		}

		[RegexStepDefinition(@"I confirm the UPC Duplicate Warning Icon is visible")]
		public void ThenIConfirmTheUPCDuplicateWarningIconIsVisible()
		{
			Report.IsTrue(new UPC().CheckIfUPCDuplicateWarningAppears(), "Failed to find the UPC Duplicate Warning Messsage!", "Successfully found the UPC Duplicate Warning Message!");
		}

		[RegexStepDefinition(@"the View UPC page loads with no errors")]
		public void TheViewUPCPageLoadsWithNoErrors()
		{
			var upcviewpg = new ViewUpcs();
			Report.IsTrue(GeneralUtilities.WaitForSpinnerToDisappear(upcviewpg.LoadingSpinner()),
				"The View UPC page did not complete loading",
				"The View UPC page completed loading");

		}

		[RegexStepDefinition(@"I navigate to the View UPC tab and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'")]
		public void INavigateToTheViewUPCTabAndCheckForUPCNameColoumn()
		{
			new GlobalSteps().SwitchToTabWithTitle("View UPCs");
			this.TheViewUPCPageLoadsWithNoErrors();
			Report.IsTrue(new ViewUpcs().DoesUPCHeadingsContain("UPC Name"), "Failed to find the Heading name 'UPC Name'", "Succesfully found the Heading name 'UPC Name'");
			new GlobalSteps().ThenCloseTheWindowThatOpened();
		}

		[RegexStepDefinition(@"I check for the appropriate alert: (.*)")]
		public void GivenICheckForTheAppropriateAlert(string alertText)
		{
			UPC UPCObject = new UPC();
			Report.IsTrue(UPCObject.CheckForAlertWithThisTextInUPCPage(alertText), "The appropriate alert: " + alertText + ", was not shown", "The appropriate alert: " + alertText + ", was shown");
		}

		[RegexStepDefinition(@"I check if the Regulatory Documents page is shown")]
		public void ThenICheckIfTheRegulatoryDocumentsPageIsShown()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			MyNewProduct.GivenIShouldSeeXPage("Regulatory Documents to Provide");
		}

		[RegexStepDefinition(@"I click (.*) for the UPCs Warning! popup (.*)")]
		public void ThenIClickNOForTheUPCsWarning(string yesOrNoButton, string savedAs)
		{
			UPC UPCObject = new UPC();
			Report.IsTrue(UPCObject.ClickYesOrNoForUPCWarningPopUp(yesOrNoButton, savedAs), "Failed to click " + yesOrNoButton + " for the UPC warning pop up", "Successfully clicked " + yesOrNoButton + " for the UPC warning pop up");
		}

		[RegexStepDefinition(@"I confirm I would like to delete product")]
		public void ThenIConfirmIWouldLikeToDeleteProduct()
		{
			ProductsGrid ProductsGridObject = new ProductsGrid();
			Report.IsTrue(ProductsGridObject.ConfirmYouWouldLikeToDeleteButton(), "Failed to delete the product", "Successfully deleted the product");
		}

		[RegexStepDefinition(@"I confirm the retailers are removed (.*)")]
		public void ThenIConfirmTheRetailersAreRemoved(string savedAs)
		{
			ProductsGrid ProductsGridObject = new ProductsGrid();
			ProductsGridObject.ConfirmRetailersMatchInMyProductsSection(savedAs);
			new GlobalSteps().SwitchToTabWithTitle("View UPCs");
			this.TheViewUPCPageLoadsWithNoErrors();
			Report.IsTrue(new ViewUpcs().DoesUPCHeadingsContain("UPC Name"), "Failed to find the Heading name 'UPC Name'", "Succesfully found the Heading name 'UPC Name'");
			new GlobalSteps().ThenCloseTheWindowThatOpened();
		}

		[RegexStepDefinition(@"I save the first UPC number associated to the product as: (.*)")]
		public void SaveFirstUpcNumberToContext(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			if (!upcs.Any())
			{
				Report.Failure("No UPC numbers were found!");
				return;
			}
			Report.Info("UPC number: " + upcs[0].UpcNumber);
			Context.AddToContext(savedAs, upcs[0].UpcNumber);
		}
	}







}

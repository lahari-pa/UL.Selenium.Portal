using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenQA.Selenium;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes.New_Product;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_PesticideDetailsUS
	{
		[StepDefinition(@"I add the EPA registration number: (.*)")]
		public void IAddTheEPARegistrationNumber(string epaNumber)
		{
			// New EPA rows are always added to the top of the stack, so check if top row has any data before entering the test value
			var epaRegistrations = new PesticideDetailsUS().EPARegistrationData;
			if (!epaRegistrations.First().EPANumber.IsNullOrEmpty())
			{
				Report.Info("Adding a new EPA row because there is pre-existing data");
				var thisEpaRegistration = new PesticideDetailsUS.EPARegistration { EPANumber = epaNumber, Row = epaRegistrations.Count + 1};
				new PesticideDetailsUS().EPARegistrationData = new List<PesticideDetailsUS.EPARegistration> {thisEpaRegistration};
				Report.IsTrue(new PesticideDetailsUS().EPARegistrationData.First().EPANumber == epaNumber, "Failed to add new EPA row with number: " + epaNumber, "Successfully added EPA row with registration number: " + epaNumber);
			}
			//if (!new PesticideDetailsUS().TopEPARowIsEmpty())
			//{
			//	Report.Info("Adding a new EPA row because there is pre-existing data");
			//	var thisEpaRegistration = new PesticideDetailsUS.EPARegistration {EPANumber = epaNumber};
			//	Report.IsTrue(new PesticideDetailsUS().ClickAddRow(),
			//		"New EPA Row was not added successfully",
			//		"New EPA Row was added successfully");
			//	Report.Info("Entering the EPA number: " + epaNumber);
			//	Report.IsTrue(new PesticideDetailsUS().EditRegistrationNumber(epaNumber, 0),
			//		"The EPA Number " + epaNumber + " was not successfully added to the top EPA table row",
			//		"The EPA Number " + epaNumber + " was successfully added to the top EPA table row");
			//}
			else
			{
				Report.Info("Entering the EPA number: " + epaNumber);
				Report.IsTrue(epaRegistrations.First().EditRegistration(epaNumber), "The EPA Number " + epaNumber + " was not successfully added to the top EPA table row", "The EPA Number " + epaNumber + " was successfully added to the top EPA table row");
				//Report.IsTrue(new PesticideDetailsUS().EnterEPATopRow(epaNumber),
				//	"The EPA Number " + epaNumber + " was not successfully added to the top EPA table row",
				//	"The EPA Number " + epaNumber + " was successfully added to the top EPA table row");
			}
		}

		[StepDefinition("I confirm data for EPA Registration: (.*) is complete")]
		public void ConfirmDataForEPARegistrationIsComplete(string epaNumber)
		{
			var epaRegistrations = new PesticideDetailsUS().EPARegistrationData;
			TestReport.StartStep("I confirm that the EPA Registration No column of the table shows the EPA number previously entered");
			Report.IsTrue(epaRegistrations.Any(x => x.EPANumber == epaNumber),
				"The EPA Registration No. column did not contain an entry with the manually entered value: " + epaNumber,
				"As expected the EPA Registration No. column contains an entry with the manually entered value: " + epaNumber);
			TestReport.StartStep("I confirm that data is present in the Active Ingredient column for EPA registration: " + epaNumber);
			var editedEPA = epaRegistrations.FirstOrDefault(x => x.EPANumber == epaNumber);
			if (editedEPA == null)
			{
				Report.Failure("There were no rows in the EPA Registration table with the user added EPA Number: " + epaNumber);
				Report.Screenshot();
			}
			else
			{
				Report.IsTrue(!editedEPA.ActiveIngredient.IsNullOrEmpty(),
					"There was no data in the Active Ingredient field for EPA Number: " + epaNumber,
					"As expected there was data: '" + editedEPA.ActiveIngredient + "' in the Active Ingredient field for EPA Number: " + epaNumber);
			}
			TestReport.StartStep("I confirm that data is present in the Percent of Active Ingredient column for EPA registration: " + epaNumber);
			if (editedEPA == null)
			{
				Report.Failure("There were no rows in the EPA Registration table with the user added EPA Number: " + epaNumber);
				Report.Screenshot();
			}
			else
			{
				Report.IsTrue(!editedEPA.PercentActiveIngredient.IsNullOrEmpty(),
					"There was no data in the Percentage Active Ingredient field for EPA Number: " + epaNumber,
					"As expected there was data: '" + editedEPA.PercentActiveIngredient + "' in the Percentage Active Ingredient field for EPA Number: " + epaNumber);
			}
			TestReport.StartStep("I confirm that the Active Ingredient and Percent of Active Ingredient columns are un-editable");
			if (editedEPA == null)
			{
				Report.Failure("There were no rows in the EPA Registration table with the user added EPA Number: " + epaNumber);
				Report.Screenshot();
			}
			else
			{
				Report.IsTrue(!editedEPA.ActiveIngredientEditable,
					"The Active Ingredient field for EPA: " + epaNumber + " registration was editable when it was not expected to be.",
					"The Active Ingredient field for EPA: " + epaNumber + " was un-editable as expected");
				Report.IsTrue(!editedEPA.PercentActiveIngredientEditable,
					"The Percent of Active Ingredient field for EPA: " + epaNumber + " registration was editable when it was not expected to be.",
					"The Precent of Active Ingredient field for EPA: " + epaNumber + " was un-editable as expected");
			}
		}

		[StepDefinition(@"I confirm the EPA Registration Table is empty")]
		public void ConfirmEPATableIsEmpty()
		{
			var displayedEPARegistrations = new PesticideDetailsUS().EPARegistrationData;
			Report.IsTrue(displayedEPARegistrations.Count == 0, "There were rows in the EPA Table when it was expected to be empty", "The EPA Table was empty as expected, with a row count of 0");
		}

		[StepDefinition(@"I confirm the EPA Registration Table contains a total of (.*) rows")]
		public void ConfirmEPARegistrationRowCount(string count)
		{
			if (!int.TryParse(count, out var expectedCount))
			{
				Report.Failure("The expected row count must be numeric");
				return;
			}
			var actualCount = new PesticideDetailsUS().EPARegistrationData.Count;
			Report.IsTrue(expectedCount == actualCount,
				"The actual EPA Registration row count did not match the expected count. Expected: " + expectedCount + ". Actual: " + actualCount,
				"The actual EPA Registration row count was: " + actualCount + " as expected.");
		}

		[StepDefinition(@"I click Remove for the item on the first EPA Registration Table row")]
		public void RemoveFirstEPARegistration()
		{
			//Report.IsTrue(new PesticideDetailsUS().RemoveEPATopRow(), "Failed to click 'Remove' on the top row of the EPA table", "Successfully clicked 'Remove' on the top row of the EPA table");
			var epaRegistrations = new PesticideDetailsUS().EPARegistrationData;
			if (epaRegistrations.Count == 0)
			{
				Report.Failure("There were no rows in the Pesticide Details - EPA Registration table!");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(epaRegistrations.First().ClickRemove(),
				"Failed to click 'Remove' on the top row of the EPA table", "Successfully clicked 'Remove' on the top row of the EPA table");
			// click ok dialog
			GeneralUtilities.Wait_for_load_finish();
			var modal = new ModalDialog();
			if (modal.Wait_for_load(2) && modal.GetTitle() == "Remove Item")
			{
				Report.Info("Clicking 'YES' in the Remove Item dialog");
				Report.IsTrue(modal.ClickButton("YES"), "Failed to click YES in the 'Remove Item' popup", "Successfully clicked YES in the 'Remove Item' popup");
			}


		}

		[StepDefinition(@"I click Add Row in the EPA Registration Table")]
		public void ClickAddRowEPATable()
		{
			Report.IsTrue(new PesticideDetailsUS().ClickAddRow(),
				"Failed to click Add Row in the EPA Table",
				"Successfully clicked Add Row in the EPA Table");
		}

		[StepDefinition(@"I confirm the EPA Registration table contains the heading: (.*)")]
		public void EPATableHeadingExpected(string expectedHeading)
		{
			var actualHeading = new NewProduct().TableHeading();
			Report.IsTrue(string.Equals(actualHeading.Trim(), expectedHeading.Trim()),
				"The table heading did not match the expected text: " + expectedHeading + ". Displayed heading: " + actualHeading,
				"The table heading matched the expected text: " + expectedHeading);
		}

		[StepDefinition(@"I confirm the EPA Pesticide Registration table is (shown|not shown)")]
		public void EPAPesticideTableIsShownOrNot(string shown)
		{
			var selNewProduct = new NewProduct();
			if (shown == "shown")
			{
				Report.IsTrue(selNewProduct.Table() != null, "The EPA Registration Number Table was not showing", "The EPA Registration Number Table was showing as expected");
			}
			if (shown == "not shown")
			{
				Report.IsTrue(selNewProduct.Table() == null, "The EPA Registration Number Table was showing when it should not be.", "The EPA Registration Number Table was not showing as expected");
			}
		}

		[StepDefinition(@"I confirm the following columns are displayed in the EPA Registration table")]
		public void ConfirmDisplayedColumnsInEPATable(Table columns)
		{
			var expectedColumns = new List<string>();
			columns.Rows.ForEach(x => expectedColumns.Add(x["Column Heading"]));
			var actualColumns = new NewProduct().TableColumnHeadings();
			Report.IsTrue(expectedColumns.All(x => actualColumns.Contains(x)),
				"The expected columns were not displayed in the EPA table. Expected: " + string.Join(", ", expectedColumns) + ". Actual: " + string.Join(", ", actualColumns),
				"The expected columns were displayed in the EPA table: " + string.Join(", ", expectedColumns));
		}
	}
}

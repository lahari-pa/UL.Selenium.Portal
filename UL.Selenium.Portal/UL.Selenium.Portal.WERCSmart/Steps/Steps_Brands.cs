using System;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Brands")]
	class Steps_Brands
	{
		[StepDefinition(@"I enter the Brand Name: (.*) in the input field on the expanded row")]
		public void EnterBrandNameExpandedRow(string name)
		{
			Report.Info("Entering '" + name + "' in the 'Product Line/ Brand Name' column in the grid");
			new MyBrands().EnterBrandName(name);
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm the 'Active' input is checked on the expanded row in the My Brands grid")]
		public void ActiveIsCheckedExpandedRow()
		{
			Report.IsTrue(new MyBrands().ActiveIsChecked(),
				"The 'Active?' input box was not checked for the expanded (editing) row but it was expected to be",
				"The 'Active?' input box was checked for the expanded (editing) row as expected");
		}

		[StepDefinition(@"I click Save on the expanded row in the My Brands grid")]
		public void ClickSaveMyBrandsGrid()
		{
			Report.IsTrue(new MyBrands().ClickSave(),
				"Failed to click Save in the My Brands grid",
				"Successfully clicked Save in the My Brands grid");
		}

		[StepDefinition(@"I click Cancel on the expanded row in the My Brands grid")]
		public void ClickCancelMyBrandsGrid()
		{
			Report.IsTrue(new MyBrands().ClickCancel(),
				"Failed to click Cancel in the My Brands grid",
				"Successfully clicked Cancel in the My Brands grid");
		}

		[StepDefinition("I confirm a brand with name: (.*) is present in the My Brands grid")]
		public void BrandNameExistsMyBrandsGrid(string brandName)
		{
			Report.Info("Fetching all brands saved in the My Brands grid");
			List<string> displayedBrands = new MyBrands().SavedBrands();
			Report.IsTrue(displayedBrands.Contains(brandName),
				"The brand: " + brandName + " was not present in the My Brands grid. The saved brands are: " + string.Join(", ", displayedBrands.Select(x => "'" + x + "'").ToList()),
				"The brand: " + brandName + " was present in the My Brands grid as expected");
		}

		[StepDefinition("I confirm that the text '(Yes|No)' is displayed under the 'Active' column for the last saved brand")]
		public void ActiveValueIsYesForLastBrand(string active)
		{
			//Requires Context on latest brand save
			int savedRowIndex = Convert.ToInt32(Context.GetFromContext("Saved brand row index")) + 1;
			string savedBrandName = Context.GetFromContext("Saved brand name").ToString();
			//Matching on both row index and brand name in case there are previously added duplicates
			string actualActive = new MyBrands().IsActiveText(savedRowIndex, savedBrandName);
			Report.IsTrue(actualActive.Trim().ToLower() == active.ToLower(),
				"The 'Active?' text did not match the expected value for the last saved Brand : " + savedBrandName + ". Expected: " + active + " but found: " + actualActive,
				"The 'Active?' text: '" + actualActive + "' matched the expected value for the last saved Brand: " + savedBrandName);
		}

		[StepDefinition(@"I confirm the last saved brand appears in the My Brands grid")]
		public void SavedBrandAppearsInGrid()
		{
			int savedRowIndex = Convert.ToInt32(Context.GetFromContext("Saved brand row index")) + 1;
			string savedBrandName = Context.GetFromContext("Saved brand name").ToString();
			var selMyBrands = new MyBrands();
			string brandName = selMyBrands.BrandName(savedRowIndex);
			Report.IsTrue(brandName == savedBrandName,
				"The saved brand: '" + savedBrandName + "' was not appearing in the Brands Grid. The brands displayed are: " + string.Join(", ", selMyBrands.SavedBrands()),
				"The saved brand: " + savedBrandName + " was appearing in the Brands Grid as expected");
		}

		[StepDefinition(@"I click Edit in the My Brands grid for the last saved brand")]
		public void ClickEditMyBrandsGrid()
		{
			int savedRowIndex = Convert.ToInt32(Context.GetFromContext("Saved brand row index")) + 1;
			string savedBrandName = Context.GetFromContext("Saved brand name").ToString();
			Report.IsTrue(new MyBrands().ClickEdit(savedRowIndex, savedBrandName),
				"Failed to click 'Edit' for the saved Brand: " + savedBrandName + " at row: " + savedRowIndex,
				"Successfully clicked 'Edit' for the saved Brand: " + savedBrandName + " at row: " + savedRowIndex);
		}

		[StepDefinition(@"I (select|deselect) the 'Active' checkbox on the expanded row in the My Brands grid")]
		public void CheckActiveCheckboxExpandedRow(string selectOrNot)
		{
			bool select = selectOrNot == "select";
			var selMyBrands = new MyBrands();
			if (select && selMyBrands.ActiveIsChecked())
			{
				Report.Failure("Cannot select the 'Active' box because it was already checked!");
				return;
			}
			if (!select && !selMyBrands.ActiveIsChecked())
			{
				Report.Failure("Cannot deselect the 'Active' box because it was not checked!");
				return;
			}
			Report.IsTrue(selMyBrands.ClickActive(),
				"Failed to click 'Acitve?' checkbox for expanded row",
				"Successfully clicked 'Acitve?' checkbox for expanded row");
			Report.IsTrue(select == selMyBrands.ActiveIsChecked(),
				"The 'Active?' checkbox has not been " + selectOrNot + "ed!",
				"The 'Active?' checkbox has been successfully " + selectOrNot + "ed.");
		}

		[StepDefinition(@"I save the active brands list to context")]
		public void SaveActiveBrandsListToContext()
		{
			List<string> activeBrands = new MyBrands().ActiveSavedBrands();
			if (activeBrands.Count == 0)
			{
				Report.Failure("There were no active brands to save in the My Brands grid");
				return;
			}
			Context.AddToContext("Active Brands", activeBrands);
		}
	}
}

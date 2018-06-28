using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Brands")]
	class Steps_Brands
	{
		[StepDefinition(@"I click 'Add New' in the (My Packaging Types|My Brands) section of My Library")]
		public void ClickAddNewMyLibrary(string tab)
		{
			if (tab == "My Packaging Types")
			{
				Report.IsTrue(new MyPackagingTypes().AddNew(),
					"Failed to click 'Add New' under My Packaging Types",
					"Successfully clicked 'Add New' under My Packaging Types");
				GeneralUtilities.Wait_for_load_finish();
				return;
			}

			if (tab == "My Brands")
			{
				Report.IsTrue(new MyBrands().AddNew(),
					"Failed to click 'Add New' under My Brands",
					"Successfully clicked 'Add New' under My Brands");
				return;
			}
			Report.Failure("Unable to 'Add New' for specified section: " + tab);
		}

		[StepDefinition(@"I enter the Brand Name: (.*) in the input field on the expanded row")]
		public void EnterBrandNameMyLibrary(string name)
		{
			Report.Info("Entering '" + name + "' in the 'Product Line/ Brand Name' column in the grid");
			new MyBrands().EnterBrandName(name);
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm the 'Active' input is checked on the expanded row in the My Brands grid")]
		public void ActiveIsCheckedInMyBrands()
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
			var displayedBrands = new MyBrands().AllSavedBrands();
			Report.IsTrue(displayedBrands.Contains(brandName),
				"The brand: " + brandName + " was not present in the My Brands grid. The saved brands are: " + string.Join(", ", displayedBrands.Select(x => "'" + x + "'").ToList()),
				"The brand: " + brandName + " was present in the My Brands grid as expected");
		}

		[StepDefinition("I confirm that the text '(Yes|No)' is displayed under the 'Active' column for the last saved brand")]
		public void ActiveValueIsYesForLastBrand(string active)
		{
			//Requires Context on latest brand save
			var savedRowIndex = Convert.ToInt32(Context.GetFromContext("Saved brand row index")) + 1;
			var savedBrandName = Context.GetFromContext("Saved brand name").ToString();
			//Matching on both row index and brand name in case there are previously added duplicates
			var actualActive = new MyBrands().IsActiveTextForBrand(savedRowIndex, savedBrandName);
			Report.IsTrue(actualActive.Trim().ToLower() == active.ToLower(),
				"The 'Active?' text did not match the expected value for the last saved Brand : " + savedBrandName + ". Expected: " + active + " but found: " + actualActive,
				"The 'Active?' text: '" + actualActive + "' matched the expected value for the last saved Brand: " + savedBrandName);
		}

		[StepDefinition(@"I confirm the last saved brand appears in the My Brands grid")]
		public void SavedBrandAppearsInGrid()
		{
			var savedRowIndex = Convert.ToInt32(Context.GetFromContext("Saved brand row index")) + 1;
			var savedBrandName = Context.GetFromContext("Saved brand name").ToString();
			var selMyBrands = new MyBrands();
			var brandName = selMyBrands.BrandNameAtRowIndex(savedRowIndex);
			Report.IsTrue(brandName == savedBrandName,
				"The saved brand: '" + savedBrandName + "' was not appearing in the Brands Grid. The brands displayed are: " + string.Join(", ", selMyBrands.AllSavedBrands()),
				"The saved brand: " + savedBrandName + " was appearing in the Brands Grid as expected");
		}
	}
}

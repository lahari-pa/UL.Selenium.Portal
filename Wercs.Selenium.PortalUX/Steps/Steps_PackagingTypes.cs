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
	[Binding, Scope(Tag = "PackagingTypes")]
	class Steps_PackagingTypes
	{
		[StepDefinition(@"I click Add Row in the Bill Of Materials grid")]
		public void ClickAddRowBillOfMaterials()
		{
			Report.IsTrue(new PackagingType().ClickAddRow(),
				"Failed to click Add Row in the Bill of Materials grid",
				"Successfully clicked Add Row in the Bill of Materials grid");
		}

		[StepDefinition(@"I select the option: (.*) for the (.*) field in the table")]
		public void SelectOptionForFieldInTable(string option, string field)
		{
			Report.IsTrue(new PackagingType().SelectOptionForField(option, field),
				string.Format("The option '{0}' was not successfully selected for field: '{1}'",
					option, field),
				string.Format("The option '{0}' was successfully selected for field: '{1}'",
					option, field));
		}

		[StepDefinition(@"I save the Packaging Type details as: (.*)")]
		public void SavePackagingTypeDetails(string savedAs)
		{
			Report.IsTrue(new PackagingType().SavePackagingDetails(savedAs),
				"Failed to save Packaging Type details to context",
				"Saved Packaging Type details to context",
				false, false);
		}

		[StepDefinition(@"I confirm that the Packaging Type saved as: (.*) (appears|does not appear) in the My Packaging Types grid")]
		public void PackagingTypeSavedAsAppearsInGrid(string savedAs, string appearsOrNot)
		{
			var appears = appearsOrNot == "appears";
			var packagingType = new MyPackagingTypes.PackagingTypeItem {
				ID = Context.GetFromContext("PackagingTypeID_" + savedAs).ToString(),
				Name = Context.GetFromContext("PackagingTypeName_" + savedAs).ToString()
			};
			var reverseAppears = appears ? "does not appear" : "appears";
			Report.IsTrue(new MyPackagingTypes().PackagingTypeInGrid(appears, packagingType),
				"The saved Packaging Type with name: " + packagingType.Name + " and ID: " + packagingType.ID + " " + reverseAppears + " in the My Packaging Types grid",
				"The saved Packaging Type  with name: " + packagingType.Name + " and ID: " + packagingType.ID + " " + appearsOrNot + " in the My Packaging Types grid as expected");
		}

		[StepDefinition(@"I delete Packaging Type saved as: (.*)")]
		public void DeletePackagingType(string savedAs)
		{
			var selPackagingTypes = new MyPackagingTypes();
			var packagingType = new MyPackagingTypes.PackagingTypeItem {
				ID = Context.GetFromContext("PackagingTypeID_" + savedAs).ToString(),
				Name = Context.GetFromContext("PackagingTypeName_" + savedAs).ToString()
			};
			TestReport.StartStep("I click 'Actions' (...) for the created Package Type");
			Report.IsTrue(selPackagingTypes.ClickActions(packagingType),
				string.Format("Failed to click 'Actions' (...) for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name),
				string.Format("Successfully clicked 'Actions' (...) for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name));
			TestReport.StartStep("I click delete for the created Package Type");
			Report.IsTrue(selPackagingTypes.ClickDelete(),
				string.Format("Failed to click delete for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name),
				string.Format("Successfully clicked delete for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name));
		}

		[StepDefinition("I click (Delete|Cancel) in the Delete Product pop up")]
		public void ClickOptionInDeleteProductPopUp(string button)
		{
			var delDialog = new DeleteDialog();
			delDialog.Wait_for_load();
			if (button.ToLower() == "delete")
			{
				Report.IsTrue(delDialog.ClickDelete(),
					"Failed to click Delete in the Delete Product Pop Up",
					"Successfully clicked Delete in the Delete Product Pop Up");
				GeneralUtilities.Wait_for_load_finish();
				return;
			}
			if (button.ToLower() == "cancel")
			{
				Report.IsTrue(delDialog.ClickCancel(),
					"Failed to click Cencel in the Delete Product Pop Up",
					"Successfully clicked Cancel in the Delete Product Pop Up");
				GeneralUtilities.Wait_for_load_finish();
				return;
			}
			Report.Failure("Action must either be 'Delete' or 'Cancel' in the Delete Product Pop Up. Clicking 'Cancel'");
			Report.IsTrue(delDialog.ClickCancel(),
				"Failed to click Cencel in the Delete Product Pop Up",
				"Successfully clicked Cancel in the Delete Product Pop Up");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I confirm the name and ID for Packaging Type saved as: (.*) appear in the Delete Product pop up")]
		public void PackagingTypeDetailsAppearInDeleteProductPopUp(string savedAs)
		{
			var packagingType = new MyPackagingTypes.PackagingTypeItem {
				ID = Context.GetFromContext("PackagingTypeID_" + savedAs).ToString(),
				Name = Context.GetFromContext("PackagingTypeName_" + savedAs).ToString()
			};
			var delDialog = new DeleteDialog();
			var itemText = delDialog.ItemRemovedText();
			TestReport.StartStep("I confirm the name for the saved Packaging Group appears in the popup");
			Report.IsTrue(itemText.Contains(packagingType.Name),
				"The Packaging Group Name " + packagingType.Name + " did not appear in the Delete Product Pop Up dialog",
				"The Packaging Group Name " + packagingType.Name + " appeared in the Delete Product Pop Up dialog as expected");
			TestReport.StartStep("I confirm the ID for the saved Packaging Group appears in the popup");
			Report.IsTrue(itemText.Contains(packagingType.ID),
				"The Packaging Group ID " + packagingType.ID + " did not appear in the Delete Product Pop Up dialog",
				"The Packaging Group ID " + packagingType.ID + " appeared in the Delete Product Pop Up dialog as expected");
		}

		[StepDefinition(@"I edit Packaging Type saved as: (.*)")]
		public void EditPackagingType(string savedAs)
		{
			var selPackagingTypes = new MyPackagingTypes();
			var packagingType = new MyPackagingTypes.PackagingTypeItem {
				ID = Context.GetFromContext("PackagingTypeID_" + savedAs).ToString(),
				Name = Context.GetFromContext("PackagingTypeName_" + savedAs).ToString()
			};
			TestReport.StartStep("I click 'Actions' (...) for the created Package Type");
			Report.IsTrue(selPackagingTypes.ClickActions(packagingType),
				string.Format("Failed to click 'Actions' (...) for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name),
				string.Format("Successfully clicked 'Actions' (...) for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name));
			TestReport.StartStep("I click 'edit' for the created Package Type");
			Report.IsTrue(selPackagingTypes.ClickEdit(),
				string.Format("Failed to click 'edit' for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name),
				string.Format("Successfully clicked 'edit' for Packaging Type with ID '{0}' and name '{1}'",
					packagingType.ID, packagingType.Name));
		}
	}
}

using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
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

		[StepDefinition(@"I confirm that the 'Add Row' button is displayed")]
		public void ConfirmTheAddRowButtonIsDisplayed()
		{
			Report.IsTrue(new PackagingType().AddRowDisplayed(), "The Add Row button was not displayed!", "The Add Row Button is displayed as expected");
		}

		[StepDefinition(@"I confirm that the following table headings are displayed:")]
		public void ConfirmTheFollowingTableHeadingsAreDisplayed(Table table)
		{
			foreach (var row in table.Rows)
			{
				var heading = row["Heading"];
				if (heading == null)
				{
					Report.Failure("The table step parameter must contain the column: 'Heading'");
					return;
				}
				var actualHeadings = new PackagingType().TableHeadings();
				Report.IsTrue(actualHeadings.Contains(heading), "The table heading: " + heading + " was not displayed!", "The table heading: " + heading + " was displayed as expected");

			}
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

		[Given(@"Save the top packaging id as (.*) if there are no packaging types listed add a new packing type as follows")]
		public void GivenSaveTheTopPackagingIdAsMPIIfThereAreNoPackackingTypesListedAddANewPackingTypeAsFollows(string saveAs, Table table)
		{
			StepsMyAccount myAccountSteps = new StepsMyAccount();
			StepsNewProduct newProductSteps = new StepsNewProduct();

			MyPackagingTypes thisMyAccount_MyLibrary = new MyPackagingTypes();

			/*
			MyPackagingTypes.PackagingTypeItem thisPTI = thisMyAccount_MyLibrary.GetRandomPackagingTypeInGrid();
			if (thisPTI != null)
			{
				Context.AddToContext("PackagingTypeID_" + saveAs, thisPTI.ID);
				Context.AddToContext("PackagingTypeName_" + saveAs, thisPTI.Name);
				Report.Success("Saved details for packing type with id: " + thisPTI.ID);
				return;
			}
			*/
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			//| Name | Materials   | Weight | Contact with food or drink | CONEG Certificate | CONEG contain | Recyclable Number | Email         |
			newProductSteps.SetTheSectionOptionTo("Package Type Name", table.Rows[0]["Name"]);
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			this.SavePackagingTypeDetails(saveAs);
			this.ClickAddRowBillOfMaterials();
			this.SelectOptionForFieldInTable(table.Rows[0]["Materials"], "My Packaging Materials");
			this.SelectOptionForFieldInTable(table.Rows[0]["Weight"], "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any", table.Rows[0]["Contact with food or drink"]);
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG", table.Rows[0]["CONEG Certificate"]);
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain the following", table.Rows[0]["CONEG contain"]);
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable Number", table.Rows[0]["Recyclable Number"]);
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
		}

		[StepDefinition(@"I click the CONEG browse button and upload PDF: (.*)")]
		public void UploadDPFForCONEG(string pdfFile)
		{
			Report.IsTrue(new PackagingType().UploadFileForSection("CONEG Certificate", pdfFile), "Failed to upload CONEG pdf", "Uploaded CONEG pdf");
		}

	}
}

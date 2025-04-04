using NPOI.SS.Util;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Ingredients;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "BulkActions:InternalInformationRevisions")]
	class Steps_BulkActions_InternalInformationRevisions
	{
		[RegexStepDefinition(@"In the Internal Information Revisions section, verify text: 'Products that need to have a combination of the Product Identifier and \/ or the Brand Name revised. No data changes that may impact the assessment would be available. Upon completion, submission of the registration is necessary but no UL assessment will occur.' (is|is not) displayed")]
		public void VerifyInternalInfoRevisionsText(string is_isnot)
		{
			string text = "Products that need to have a combination of the Product Identifier and / or the Brand Name revised. No data changes that may impact the assessment would be available. Upon completion, submission of the registration is necessary but no UL assessment will occur.";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, for the '(Product Identifier|Ingredient Identifier)' search field enter text: (.*)")]
		public void EnterTextIntoProductIdentifier(string section, string text)
		{
			if (Report.IsTrue(new InternalInformationRevisions().SearchInputExists(section), $"Failed to confirm the 'Search' input exists for the {section}", $"Successfully confirmed the 'Search' input exists for the {section}"))
			{
				Report.IsTrue(new InternalInformationRevisions().SearchInputEnterText(section, text), $"Failed to enter text into 'Search' input for the {section}", $"Successfully entered text into 'Search' input for the {section}");
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, for the 'Brand' dropdown select option: (.*)")]
		public void SelectBrandDropdown(string option)
		{
			string section = " Brand";
			if (Report.IsTrue(new InternalInformationRevisions().SearchBrandSelectExists(), $"Failed to confirm the 'Search' input exists for the 'Brand'", $"Successfully confirmed the 'Search' input exists for the 'Brand'"))
			{
				Report.IsTrue(new InternalInformationRevisions().SearchBrandSelectOption(option), $"Failed to select option for the 'Brand'", $"Successfully selected option for the 'Brand'");
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, click the 'Clear Filters' button")]
		public void ClickTheClearFiltersButton()
		{
			string button = "Clear Filters";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, for (Product Identifier|Ingredient Identifier), click the 'Search' button")]
		public void ClickTheSearchButton(string label)
		{
			if (Report.IsTrue(new InternalInformationRevisions().SearchButtonExists(label), $"Failed to confirm the 'Search' button exists for the {label}", $"Successfully confirmed the 'Search' button exists for the {label}"))
			{
				Report.IsTrue(new InternalInformationRevisions().SearchButtonClick(label), $"Failed to click the 'Search' button for the {label}", $"Successfully clicked the 'Search' button for the {label}");
			}
		}
		#region Products Table Footer Steps
		#region Items On Page Dropdown Steps
		[RegexStepDefinition(@"In the Internal Information Revisions section, confirm Items On Page dropdown (does|does not) exist")]
		public void ProductsPageConfirmItemsOnPageDropdownDoesDoesNotExist(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductsTableFooter.ItemsOnPageSelectExists(), $"Failure, failed to confirm Items On Page dropdown {does_doesnot} exist.", $"Success, confirmed Items On Page dropdown {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, Items On Page dropdown (10|25|50|75|100) option (does|does not) exists")]
		public void ProductPageItemsOnPageDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductsTableFooter.ItemsOnPageSelectOptionExists(optionLabel), $"Failure, failed to confirm Items On Page dropdown {optionLabel} option {does_doesnot} exist.", $"Success, confirmed Items On Page {optionLabel} option {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, click Items On Page dropdown (10|25|50|75|100) option")]
		public void ProductPageClickItemsOnPageDropdownOption(string optionLabel)
		{
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectOptionExists(optionLabel), $"Failure, failed to confirm Items On Page dropdown {optionLabel} option does exist.", $"Success, confirmed Items On Page {optionLabel} option does exist."))
			{
				Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectOptionClick(optionLabel), $"Failure, failed to click Items On Page dropdown {optionLabel} option.", $"Success, clicked Items On Page dropdown {optionLabel} option.");
			}
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, confirm Items On Page dropdown (10|25|50|75|100) option (is|is not) selected")]
		public void ProductPageConfirmItemsOnPageDropdownOptionIsIsNotSelected(string optionExpected, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectOptionExists(optionExpected), $"Failure, failed to confirm Items On Page dropdown {optionExpected} option does exist.", $"Success, confirmed Items On Page {optionExpected} option does exist."))
			{
				string optionCurrent = myProductsTableFooter.ItemsOnPageSelectValue();
				Report.IsTrue(expected == optionCurrent.Equals(optionExpected), $"Failure, failed to confirm Items On Page dropdown {optionExpected} option {is_isnot} selected.", $"Success, confirmed Items On Page dropdown {optionExpected} option {is_isnot} selected.");
			}
		}
		#endregion

		#region Pagiation Button Steps
		[RegexStepDefinition(@"In the Internal Information Revisions section, confirm (.*) Pagination button (does|does not) exist")]
		public void ProductsPageConfirmPagiationButtonDoesDoesNotExist(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {does_doesnot} exist.", $"Success, confirmed {buttonLabel} pagination button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, click (.*) Pagination button")]
		public void ProductsPageClickPagiationButton(string buttonLabel)
		{
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(myProductTableFooter.PaginationButtonClick(buttonLabel), $"Failure, failed to click {buttonLabel} pagination button.", $"Success, click {buttonLabel} pagination button currently selected.");
			}
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, confirm (Prev|Next) Pagination button (is|is not) disabled")]
		public void ProductsPageConfirmPagiationButtonIsIsNotDisabled(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonDisabled(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} disabled.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} disabled.");
			}
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, confirm (.*) Pagination button (is|is not) currently selected")]
		public void ProductsPageConfirmPagiationButtonIsIsNotSelected(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonCurrent(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} currently selected.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} currently selected.");
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, confirm row with product Id (.*) (does|does not) exists")]
		public void ProductsTableRowWithIdExists(string productId, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists() == expected, $"Failure, failed to confirm row with '{productId}' as Product ID {does_doesnot} exist.", $"Success, confirmed row with '{productId}' as Product ID {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, confirm in the row with product Id (.*) the Name is: (.*)")]
		public void ProductsTableRowWithIdCheckName(string productId, string productName)
		{
			if(Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ProductName == productName, $"Failure, failed to confirm for the row with '{productId}' as Product ID, the Name is: {productName}", $"Success, confirmed for the row with '{productId}' as Product ID, the Name is: {productName}");

			}
		}

		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, click the (Edit|Save|Cancel) action for the row with product Id (.*)")]
		public void ProductsTableRowWithIdClickAction(string actionLink, string productId)
		{
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ActionLinkExists(actionLink), $"Failure, failed to find the '{actionLink}' action for row with Id {productId}", $"Success, found the '{actionLink}' action for row with Id {productId}"))
				{
					Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ActionLinkClick(actionLink), $"Failure, failed to click the '{actionLink}' action for row with Id {productId}", $"Success, clicked the '{actionLink}' action for row with Id {productId}");
				}
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, the (Edit|Save|Cancel) action (is|is not) displayed for the row with product Id (.*)")]
		public void ProductsTableRowWithIdActionIsDisplayed(string actionLink, string is_isnot, string productId)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ActionLinkExists(actionLink) == expected, $"Failure, failed to confirm the '{actionLink}' action {is_isnot} displayed for row with Id {productId}", $"Success, confirmed the '{actionLink}' action {is_isnot} for row with Id {productId}");	
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, enter the Ingredient Identifier: (.*) for the row with product Id (.*)")]
		public void TableRowWithIdEnterIngredientIdintidier(string ingredientIdentifier, string productId)
		{
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).IngredientIdentifierInputExists(), $"Failure, failed to find the Ingredient Identifier input for row with Id {productId}", $"Success, found the Ingredient Identifier input for row with Id {productId}"))
				{
					Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).IngredientIdentifierInputEnterText(ingredientIdentifier), $"Failure, failed to enter text into the Ingredient Identifier input for row with Id {productId}", $"Success, entered text into the Ingredient Identifier input for row with Id {productId}");
				}
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, the Ingredient Identifier input (is|is not) displayed for the row with product Id (.*)")]
		public void TableRowWithIdIngredientIdintidierIsDisplayed(string is_isnot, string productId)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).IngredientIdentifierInputExists() == expected, $"Failure, failed to confirm the Ingredient Identifier input {is_isnot} displayed for row with Id {productId}", $"Success, confirmed the Ingredient Identifier input {is_isnot} displayed for row with Id {productId}");
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, enter the Product Identifier: (.*) for the row with product Id (.*)")]
		public void ProductsTableRowWithIdEnterProductIdentifier(string productIdentifier, string productId)
		{
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ProductIdentifierInputExists(), $"Failure, failed to find the Product Identifier input for row with Id {productId}", $"Success, found the Product Identifier input for row with Id {productId}"))
				{
					Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ProductIdentifierInputEnterText(productIdentifier), $"Failure, failed to enter text into the Product Identifier input for row with Id {productId}", $"Success, entered text into the Product Identifier input for row with Id {productId}");
				}
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, the Product Identifier input (is|is not) displayed for the row with product Id (.*)")]
		public void ProductsTableRowWithIdProductIdentifierIsDisplayed(string is_isnot, string productId)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).ProductIdentifierInputExists() == expected, $"Failure, failed to confirm the Product Identifier {is_isnot} displayed for row with Id {productId}", $"Success, confirmed the Product Identifier {is_isnot} displayed for row with Id {productId}");
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, select the Brand Name: (.*) for the row with product Id (.*)")]
		public void ProductsTableRowWithIdEnterBrandName(string brandName, string productId)
		{
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).BrandSelectExists(), $"Failure, failed to find the Brand Name for row with Id {productId}", $"Success, found the Brand Name for row with Id {productId}"))
				{
					Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).BrandSelectOption(brandName), $"Failure, failed to select Brand Name for row with Id {productId}", $"Success, selected Brand Name for row with Id {productId}");
				}
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the Products table, the Brand Name input (is|is not) displayed for the row with product Id (.*)")]
		public void ProductsTableRowWithIdBrandNameIsDisplayed(string is_isnot, string productId)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).InternalInfoRevisionsProductsTableRowExists(), $"Failure, failed to confirm row with '{productId}' as Product ID exist.", $"Success, confirmed row with '{productId}' as Product ID exist."))
			{
				Report.IsTrue(new InternalInformationRevisions().InternalInfoRevisionsProductsTableRowSearchById(productId).BrandSelectExists() == expected, $"Failure, failed to find the Brand Name for row with Id {productId}", $"Success, found the Brand Name for row with Id {productId}");
			}
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, the 'Are you sure you wish to cancel\?' modal (should|should not) be displayed with text: 'If you cancel, any changes will be lost. Continue\?'")]
		public void ProductsTableCancelPopupIsDisplayed(string condition)
		{
			string title = "Are you sure you wish to cancel?";
			string text = "If you cancel, any changes will be lost. Continue?";
			new Steps_ModalDialogPrototype().ConfirmModalTitleandModalText(condition, title, text);
		}
		[RegexStepDefinition(@"In the Internal Information Revisions section, in the 'Are you sure you wish to cancel\?' modal click the (YES|NO) button")]
		public void ProductsTableCancelPopupClickButton(string button)
		{
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.DisplayedModalClickFooterButton(button);
		}
		#endregion
		#endregion

	}
}

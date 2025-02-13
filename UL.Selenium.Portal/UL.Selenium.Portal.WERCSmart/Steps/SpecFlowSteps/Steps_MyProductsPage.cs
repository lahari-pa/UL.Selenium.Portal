using NPOI.SS.Formula.Functions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using TReVor.Integrations.Classes.Configuration;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Database_Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using Microsoft.VisualBasic;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "MyProductsPage")]
	internal class Steps_MyProductsPage
	{
		#region Prototype Steps
		#region Button Prototype Steps
		[RegexStepDefinition(@"On the My Products page, confirm (.*) button (does|does not) exists")]
		public void MyProductsPageConfirmButtonExists(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button {does_doesnot} exist.", $"Success, confirmed '{buttonLabel}' button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, click the (.*) button")]
		public void MyProductsPageClickButton(string buttonLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if(Report.IsTrue(myProductsPage.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button does exist.", $"Success, confirmed '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(myProductsPage.LabeledButtonClick(buttonLabel), $"Failure, failed to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
			}
		}
		#endregion

		#region Checkbox Prototype Steps
		[RegexStepDefinition(@"On the My Products page, confirm (.*) checkbox (does|does not) exists")]
		public void MyProductsPageConfirmCheckboxExists(string checkboxLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox {does_doesnot} exist.", $"Success, confirmed '{checkboxLabel}' checkbox {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, click the (.*) checkbox")]
		public void MyProductsPageClickCheckbox(string checkboxLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox does exist.", $"Success, confirmed '{checkboxLabel}' checkbox does exist."))
			{
				Report.IsTrue(myProductsPage.CheckboxClick(checkboxLabel), $"Failure, failed to click '{checkboxLabel}' checkbox.", $"Success, clicked '{checkboxLabel}' checkbox.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm the (.*) checkbox (is|is not) checked")]
		public void MyProductsPageCheckboxChecked(string checkboxLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox does exist.", $"Success, confirmed '{checkboxLabel}' checkbox does exist."))
			{
				Report.IsTrue(expected == myProductsPage.CheckboxChecked(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox {is_isnot} checked.", $"Success, confirmed '{checkboxLabel}' checkbox {is_isnot} checked.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, (check|uncheck) the (.*) checkbox")]
		public void MyProductsPageCheckUnCheckCheckbox(string check_uncheck, string checkboxLabel)
		{
			bool expected = check_uncheck == "check";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox does exist.", $"Success, confirmed '{checkboxLabel}' checkbox does exist."))
			{
				if(expected != myProductsPage.CheckboxChecked(checkboxLabel))
				{
					Report.IsTrue(myProductsPage.CheckboxClick(checkboxLabel), $"Failure, failed to click '{checkboxLabel}' checkbox.", $"Success, clicked '{checkboxLabel}' checkbox.");
				}
				Report.IsTrue(expected == myProductsPage.CheckboxChecked(checkboxLabel), $"Failure, failed to {check_uncheck} '{checkboxLabel}' checkbox.", $"Success, {check_uncheck}ed '{checkboxLabel}' checkbox.");
			}
		}
		#endregion

		#region Labeled Dropdown Prototype Steps
		[RegexStepDefinition(@"On the My Products page, confirm (.*) dropdown (does|does not) exists")]
		public void MyProductsPageConfirmLabeledDropdownExists(string dropdownLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown {does_doesnot} exist.", $"Success, confirmed '{dropdownLabel}' dropdown {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, click the (.*) dropdown")]
		public void MyProductsPageClickLabeledDropdown(string dropdownLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				Report.IsTrue(myProductsPage.LabeledDropdownClick(dropdownLabel), $"Failure, failed to click '{dropdownLabel}' dropdown.", $"Success, clicked '{dropdownLabel}' dropdown.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm the (.*) dropdown current value is: (.*)")]
		public void MyProductsPageConfirmLabeledDropdownValue(string dropdownLabel, string expectedValue)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				string dropdownValue = myProductsPage.LabeledDropdownValue(dropdownLabel);
				Report.IsTrue(dropdownValue.Equals(expectedValue), $"Failure, '{dropdownLabel}' dropdown value '{dropdownValue}' is not expected value '{expectedValue}'.", $"Success, '{dropdownLabel}' dropdown value '{dropdownValue}' is same as expected.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm the (.*) dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmLabeledDropdownOptionExists(string dropdownLabel, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				Report.IsTrue(expected == myProductsPage.LabeledDropdownOptionExists(dropdownLabel, optionLabel),$"Failure, failed to confirm '{dropdownLabel}' dropdown '{optionLabel}' {does_doesnot} exist.",$"Success, confirmed '{dropdownLabel}' dropdown '{optionLabel}' option {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, click the (.*) dropdown (.*) option")]
		public void MyProductsPageConfirmLabeledDropdownOptionClick(string dropdownLabel, string optionLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				Report.IsTrue(myProductsPage.LabeledDropdownOptionClick(dropdownLabel, optionLabel), $"Failure, failed to click '{dropdownLabel}' dropdown '{optionLabel}'.", $"Success, clicked '{dropdownLabel}' dropdown '{optionLabel}' option.");
			}
		}
		#endregion

		#region Text Search Prototype Steps
		[RegexStepDefinition(@"On the My Products page, confirm (.*) text search (does|does not) exists")]
		public void MyProductsPageConfirmTextSearchExists(string textSearchLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			bool textSearchExists = new TextSearch(textSearchLabel) != null;
			Report.IsTrue(expected == textSearchExists, $"Failure, failed to confirm '{textSearchLabel}' text search {does_doesnot} exist.", $"Success, confirmed '{textSearchLabel}' text search {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, confirm (.*) text search input (does|does not) exists")]
		public void MyProductsPageConfirmTextSearchInputExists(string textSearchLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if(Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				Report.IsTrue(expected == textSearch.TextInputExists(),$"Failure, failed to confirm '{textSearchLabel}' text search input {does_doesnot} exist.",$"Success, confirmed '{textSearchLabel}' text search input {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, click (.*) text search input")]
		public void MyProductsPageTextSearchInputClick(string textSearchLabel)
		{
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				if(Report.IsTrue(textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input does exist.", $"Success, confirmed '{textSearchLabel}' text search input does exist."))
				{
					Report.IsTrue(textSearch.TextInputClick(), $"Failure, failed to click '{textSearchLabel}' text search input.", $"Success, clicked '{textSearchLabel}' text search input.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page, in (.*) text search input, enter text: (.*)")]
		public void MyProductsPageTextSearchInputEnterText(string textSearchLabel, string inputText)
		{
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				if (Report.IsTrue(textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input does exist.", $"Success, confirmed '{textSearchLabel}' text search input does exist."))
				{
					Report.IsTrue(textSearch.TextInputEnterText(inputText), $"Failure, in '{textSearchLabel}' text search input failed to enter '{inputText}' text.", $"Success, in '{textSearchLabel}' text search input entered '{inputText}' text.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm (.*) text search input (does|does not) have value: (.*)")]
		public void MyProductsPageTextSearchInputCompareText(string textSearchLabel, string does_doesnot, string expectedText)
		{
			bool expected = does_doesnot == "does";
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				if (Report.IsTrue(textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input does exist.", $"Success, confirmed '{textSearchLabel}' text search input does exist."))
				{
					string inputText = textSearch.TextInputTextGet();
					Report.IsTrue(expected == inputText.Equals(expectedText), $"Failure, in '{textSearchLabel}' text search input {does_doesnot} have value '{expectedText}'{(!expected?".":$" but '{inputText}'.")}", $"Success, in '{textSearchLabel}' text search input {does_doesnot} have value '{expectedText}'{(expected ? "." : $" but '{inputText}'.")}");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm (.*) text search button (does|does not) exists")]
		public void MyProductsPageConfirmTextSearchButtonExists(string textSearchLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				Report.IsTrue(expected == textSearch.SearchButtonExists(), $"Failure, failed to confirm '{textSearchLabel}' text search button {does_doesnot} exist.", $"Success, confirmed '{textSearchLabel}' text search button {does_doesnot} exist.");
			}
		}
		#endregion
		#endregion

		#region Page Info Icon Steps
		[RegexStepDefinition(@"On the My Products page, confirm page info icon (does|does not) exists")]
		public void MyProductsPageConfirmInfoIconExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.PageInfoIconExists(), $"Failure, failed to confirm page info icon {does_doesnot} exist.", $"Success, confirmed page info icon {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, hover over page info icon")]
		public void MyProductsPageConfirmInfoIconHover()
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.PageInfoIconExists(), $"Failure, failed to confirm page info icon does exist.", $"Success, confirmed page info icon does exist."))
			{
				myProductsPage.PageInfoIconHover();
				Report.Success("Hovering over page info icon.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm page info text (is|is not) displayed")]
		public void MyProductsPageConfirmInfoTextDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.PageInfoIconExists(), $"Failure, failed to confirm page info icon does exist.", $"Success, confirmed page info icon does exist."))
			{
				Report.IsTrue(myProductsPage.PageInfoIconTextDisplayed(), $"Failure, failed to confirm page info text {is_isnot} displayed.", $"Success, confirmed page info text {is_isnot} displayed.");
			}
		}
		#endregion

		#region Status Filter List Steps
		[RegexStepDefinition(@"On the My Products page, status filter list (does|does not) exists")]
		public void MyProductsPageConfirmStatusFilterListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == (myProductsPage.StatusFilterListGet() != null), $"Failure, failed to confirm status filter list {does_doesnot} exist.", $"Success, confirmed status filter list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, status filter (.*) (does|does not) exists")]
		public void MyProductsPageConfirmStatusFilterExists(string statusFilerLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue((myProductsPage.StatusFilterListGet() != null), $"Failure, failed to confirm status filter list does exist.", $"Success, confirmed status filter list does exist."))
			{
				Report.IsTrue(expected == myProductsPage.StatusFilterExists(statusFilerLabel), $"Failure, failed to confirm status filter {statusFilerLabel} {does_doesnot} exist.", $"Success, confirmed status filter {statusFilerLabel} {does_doesnot} exist.");
			}
		}
		#endregion

		#region My Products Table Header Steps
		[RegexStepDefinition(@"On the My Products page, confirm Bulk Actions button (does|does not) exists")]
		public void MyProductsPageConfirmBulkActionsButtonExists(string does_doesnot)
		{
			string buttonLabel = "Bulk Actions";
			this.MyProductsPageConfirmButtonExists(buttonLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click Bulk Actions button.")]
		public void MyProductsPageClickBulkActionsButton()
		{
			string buttonLabel = "Bulk Actions";
			this.MyProductsPageClickButton(buttonLabel);
		}
		#endregion

		#region Bulk Actions Modal Steps
		[RegexStepDefinition(@"Confirm Bulk Actions modal (does|does not) exists")]
		public void MyProductsPageConfirmBulkActionsModalExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == (bulkActionsModal != null), $"Failure, failed to confirm Bulk Actions modal {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Close button (does|does not) exists")]
		public void BulkActionsModalConfirmCloseButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal close button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal close button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, Click close button")]
		public void BulkActionsModalClickCloseButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if(Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal close button does exist.", $"Success, confirmed Bulk Actions modal close button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal close button.", $"Success, clicked Bulk Actions modal clased button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Forward Product Registration button (does|does not) exists")]
		public void BulkActionsModalConfirmForwardProductRegistrationButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Forward Product Registration button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Forward Product Registration button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Forward Product Registration button")]
		public void BulkActionsModalClickForwardProductRegistrationButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Forward Product Registration button does exist.", $"Success, confirmed Bulk Actions modal Forward Product Registration button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Forward Product Registration button.", $"Success, clicked Bulk Actions modal Forward Product Registration button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Accept Documents button (does|does not) exists")]
		public void BulkActionsModalConfirmAcceptDocumentsButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Accept Documents button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Accept Documents button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Accept Documents button")]
		public void BulkActionsModalClickAcceptDocumentsButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Accept Documents button does exist.", $"Success, confirmed Bulk Actions modal Accept Documents button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Accept Documents button.", $"Success, clicked Bulk Actions modal Accept Documents button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Delete Products button (does|does not) exists")]
		public void BulkActionsModalConfirmDeleteProductsButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Delete Products button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Delete Products button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Delete Products button")]
		public void BulkActionsModalClickDeleteProductsButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Delete Products button does exist.", $"Success, confirmed Bulk Actions modal Delete Products button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Delete Products button.", $"Success, clicked Bulk Actions modal Delete Products button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Internal Information Revision button (does|does not) exists")]
		public void BulkActionsModalConfirmInternalInformationRevisionButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Internal Information Revision button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Internal Information Revision button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Internal Information Revision button")]
		public void BulkActionsModalClickInternalInformationRevisionButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Internal Information Revision button does exist.", $"Success, confirmed Bulk Actions modal Internal Information Revision button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Internal Information Revision button.", $"Success, clicked Bulk Actions modal Internal Information Revision button.");
			}
		}
		#endregion
	}
}

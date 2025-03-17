using iText.Kernel.XMP;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "ModalDialogPrototype")]
	internal class Steps_ModalDialogPrototype
	{
		[RegexStepDefinition(@"Confirm modal (is|is not) displayed")]
		public void ConfirmModalIsIsNotDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			ModalDialogPrototype modalDialogPrototype = new ModalDialogPrototype();
			Report.IsTrue(expected == !modalDialogPrototype.IsNullOrEmpty(), $"Failure, failed to confirm modal {is_isnot} displayed.", $"Success, confirmed modal {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In the displayed modal, confirm the modal title (is|is not) '(.*)'")]
		public void DisplayedModalConfirmModalTitle(string is_isnot, string modalTitleExpected)
		{
			bool expected = is_isnot == "is";
			ModalDialogPrototype modalDialogPrototype = new ModalDialogPrototype();
			string modalTitleDisplayed = modalDialogPrototype.TitleGet();
			Report.IsTrue(expected == modalTitleDisplayed.Equals(modalTitleExpected), $"Failure, failed to confirm displayed modal title '{modalTitleDisplayed}' {is_isnot} '{modalTitleExpected}'.", $"Success, confirmed displayed modal title '{modalTitleDisplayed}' {is_isnot} '{modalTitleExpected}'.");
		}

		[RegexStepDefinition(@"In the displayed modal, click the header close button")]
		public void DisplayedModalClickHeaderCloseButton()
		{
			ModalDialogPrototype modalDialogPrototype = new ModalDialogPrototype();
			if(Report.IsTrue(modalDialogPrototype.HeaderCloseButtonExists(),$"Failure, in the displayed modal failed to confirm header close button exists.",$"Success, in the displayed modal confirmed header close button exists."))
			{
				Report.IsTrue(modalDialogPrototype.HeaderCloseButtonClick(), $"Failure, in the displayed modal failed to click the header close button.", $"Success, in the displayed modal clicked the header close button.");
			}
		}

		#region Step Prototypes
		//[RegexStepDefinition(@"Confirm '(.*)' modal (is|is not) displayed")]
		public void ConfirmModalIsIsNotDisplayed(string modalTitleExpected, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ModalDialogPrototype modalDialogPrototype = new ModalDialogPrototype();
			bool modalDisplayed = modalDialogPrototype.IsModalDisplayed();

			if (Report.IsTrue(modalDisplayed == expected, $"Failed: expected that the modal {is_isnot} displayed, but it does not match with the actual results. Modal Displayed is: {modalDisplayed}.", $"Successfully confirmed that the modal {is_isnot} displayed."))
			{
				if (Report.IsTrue(modalDialogPrototype.ModalTitleExists(), "Failed to confirm that the Modal Title exists on the page!", "Successfully confirmed that the Modal Title exists on the page!")) 
				{
					string modalTitleDisplayed = modalDialogPrototype.TitleGet();
					Report.IsTrue(expected == modalTitleDisplayed.Equals(modalTitleExpected), $"Failure, failed to confirm displayed modal title '{modalTitleDisplayed}' {is_isnot} '{modalTitleExpected}'.", $"Success, confirmed displayed modal title '{modalTitleDisplayed}' {is_isnot} '{modalTitleExpected}'.");
				}
			}
		}

		//[RegexStepDefinition(@"In the displayed modal, confirm '(.*)' footer button (does|does not) exist")]
		public void DisplayedModalConfirmFooterButtonDoesDoesNotExist(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ModalDialogPrototype modalDialogPrototype = new ModalDialogPrototype();
			Report.IsTrue(expected == modalDialogPrototype.FooterButtonExists(buttonLabel),$"Failure, in the displayed modal failed to confirm '{buttonLabel}' footer button {does_doesnot} exist.",$"Success, in the displayed modal confirmed '{buttonLabel}' footer button {does_doesnot} exist.");
		}

		//[RegexStepDefinition(@"In the displayed modal, click '(.*)' footer button")]
		public void DisplayedModalClickFooterButton(string buttonLabel)
		{
			ModalDialogPrototype modalDialogPrototype = new ModalDialogPrototype();
			if(Report.IsTrue(modalDialogPrototype.FooterButtonExists(buttonLabel), $"Failure, in the displayed modal failed to confirm '{buttonLabel}' footer button does exist.", $"Success, in the displayed modal confirmed '{buttonLabel}' footer button does exist."))
			{
				Report.IsTrue(modalDialogPrototype.FooterButtonClick(buttonLabel),$"Failure, in the displayed modal failed to click the '{buttonLabel}' footer button.",$"Success, in the displayed modal clicked the '{buttonLabel}' footer button.");
			}
		}
		#endregion
	}
}

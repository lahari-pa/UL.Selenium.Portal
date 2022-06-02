using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SubEnrollmentNew")]
	class StepsSubscriptionEnrollmentNew
	{
		[StepDefinition(@"I confirm the (.*) section (does|does not) exist")]
		public void IConfirmSectionDoesDoesNotExist(string sectionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(new SubscriptionEnrollment_new().EnrollmentSectionExists(sectionLabel) == expected, $"Failed, '{sectionLabel}' section {(expected?"does not":"does")} exist and {(expected?"should":"should not")}.",$"Success, '{sectionLabel}' section {does_doesnot} exist.");
		}

		[StepDefinition(@"In the (.*) section, I confirm the (.*) heading (does|does not) exist")]
		public void InSectionConfirmHeadingDoesDoesNotExist(string sectionLabel, string headingText, string does_doesnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if(Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel) == expected, $"Failed, '{sectionLabel}' section {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.", $"Success, '{sectionLabel}' section {does_doesnot} exist."))
			{
				Report.IsTrue(subEnrollment.EnrollmentSectionHeadingExists(sectionLabel, headingText), $"Failure, in '{sectionLabel}' section, '{headingText}' heading {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.", $"Success, in '{sectionLabel}' section, '{headingText}' heading {does_doesnot} exist.");
			}
		}

		[StepDefinition(@"In the (.*) section, I confirm the (.*) panel (does|does not) exist")]
		public void InSectionConfirmPanelDoesDoesNotExist(string sectionLabel, string panelLabel, string does_doesnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel) == expected, $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel {does_doesnot} exist.");
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the text area containins: (.*)")]
		public void InSectionPanelConfirmTextAreaDoesDoesNotExist(string sectionLabel, string panelLabel, string panelText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if(Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if(Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if(Report.IsTrue(subEnrollment.EnrollmentPanelBodyTextAreaExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel text area does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel text area does exist."))
					{
						Report.IsTrue(subEnrollment.EnrollmentPanelBodyTextAreaTextGet(sectionLabel, panelLabel) == panelText, $"Failure, panel text displayed: '{panelText}' but should have displayed: '{subEnrollment.EnrollmentPanelBodyTextAreaTextGet(sectionLabel, panelLabel)}'.", $"Success, panel text displayed correctly.");
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confrim the selector displays: (.*)")]
		public void InSelectionPanelConfirmSelectorDisplays(string sectionLabel, string panelLabel, string selectorText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if(Report.IsTrue(subEnrollment.EnrollmentPanelSelectorExists(sectionLabel, panelLabel),$"Failure, in '{sectionLabel}' section '{panelLabel}' panel selector does not exist and should.",$"Success, in '{sectionLabel}' section '{panelLabel}' panel selector exists."))
					{
						Report.IsTrue(subEnrollment.EnrollmentPanelSelectorValueGet(sectionLabel, panelLabel) == selectorText, $"Failure '{sectionLabel}' section '{panelLabel}' panel selector text is '{subEnrollment.EnrollmentPanelSelectorValueGet(sectionLabel, panelLabel)}' and should be '{selectorText}'.", $"Success, '{sectionLabel}' section '{panelLabel}' panel selector text is correct.");
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the list contains: (.*)")]
		public void InSectionPabelConfirmListContains(string sectionLabel, string panelLabel, string panelListText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemExists(sectionLabel, panelLabel, panelListText), $"Failed, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item exists.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel (.*) list item, I click the info button")]
		public void InSectionPanelListItemClickInfoButton(string sectionLabel, string panelLabel, string panelListText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if(Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemExists(sectionLabel, panelLabel, panelListText), $"Failed, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item exists."))
					{
						Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoButtonClick(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, failed to click info button.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, clicked info button.");
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel (.*) list item, I confrim the info text area (is|is not) displayed")]
		public void InSectionPanelListItemInfoTextIsIsNotDisplayed(string sectionLabel, string panelLabel, string panelListText, string is_isnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = is_isnot == "is";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemExists(sectionLabel, panelLabel, panelListText), $"Failed, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item exists."))
					{
						if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaExists(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area exists."))
						{
							Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaIsDisplayed(sectionLabel, panelLabel, panelListText) == expected, $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area {(expected?"is not":"is")} displayed and {(expected?"should":"should not")}.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area {is_isnot} displayed.");
						}

					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel (.*) list item, I confrim the info text area displays: (.*)")]
		public void InSectionPanelListItemInfoTextDisplays(string sectionLabel, string panelLabel, string panelListText, string infoText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemExists(sectionLabel, panelLabel, panelListText), $"Failed, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item exists."))
					{
						if(Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaExists(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area exists."))
						{
							Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaIsDisplayed(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area is not displayed.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area is displayed.");
							string displayedInfoText = subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaTextGet(sectionLabel, panelLabel, panelListText);
							Report.IsTrue(displayedInfoText.Trim().Contains(infoText.Trim()), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text displayed, '{displayedInfoText}', does not match expected '{infoText}'.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text displayed matches expected.");
						}
						
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel (.*) list item, I click the (.*) link")]
		public void InSectionPanelListItemInfoTextClickLink(string sectionLabel, string panelLabel, string panelListText, string linkLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemExists(sectionLabel, panelLabel, panelListText), $"Failed, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item exists."))
					{
						if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaExists(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area exists."))
						{
							Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaIsDisplayed(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area is not displayed.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area is displayed.");
							if(Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaLinkExists(sectionLabel, panelLabel, panelListText, linkLabel), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the '{linkLabel}' link does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the '{linkLabel}' link exists."))
							{
								Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaLinkClick(sectionLabel, panelLabel, panelListText, linkLabel), $"Failure, in the '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, failed to click '{linkLabel}' link.", $"Success, in the '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, clicked '{linkLabel}' link.");
							}

						}
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the (.*) footer (does|does not) exist")]
		public void InSectionPanelConfirmFooterDoesDoesNotExist(string sectionLabel, string panelLabel, string footerText, string does_doesnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentPanelFooterExists(sectionLabel, panelLabel, footerText),$"Faiure, in '{sectionLabel}' section '{panelLabel}' panel, '{footerText}' footer {(expected?"does not":"does")} exist.",$"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{footerText}' footer {does_doesnot} exist.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section, I confirm the text area displays: (.*)")]
		public void InSectionConfirmTextAreaDisplays(string sectionLabel, string sectionText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if(Report.IsTrue(subEnrollment.EnrollmentSectionTextAreaExists(sectionLabel),$"Failure, '{sectionLabel}' section text area does not exist.",$"Success, '{sectionLabel}' section text area does exist."))
				{
					string displayedText = subEnrollment.EnrollmentSectionTextAreaTextGet(sectionLabel);
					Report.IsTrue(displayedText.Contains(sectionText), $"Failure, '{sectionLabel}' section text area displayed text: '{displayedText}' does not match expected text: '{sectionText}'.", $"Success, '{sectionLabel}' section text area text is correct.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section text area, I click on the (.*) link")]
		public void InSectionTextAreaClickLink(string sectionLabel, string linkLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentSectionTextAreaExists(sectionLabel), $"Failure, '{sectionLabel}' section text area does not exist.", $"Success, '{sectionLabel}' section text area does exist."))
				{
					if(Report.IsTrue(subEnrollment.EnrollmentSectionTextAreaLinkExists(sectionLabel, linkLabel),$"Failure, '{sectionLabel}' section text area '{linkLabel}' link does not exist.",$"Success, '{sectionLabel}' section text area '{linkLabel}' link does exist."))
					{
						Report.IsTrue(subEnrollment.EnrollmentSectionTextAreaLinkClick(sectionLabel, linkLabel), $"Failure, failed to click '{sectionLabel}' section text area '{linkLabel}' link.", $"Success, clicked '{sectionLabel}' section text area '{linkLabel}' link.");
					}
				}
			}
		}

		[StepDefinition(@"I confirm the Agency Service Agreement modal (is|is not) displayed")]
		public void ConfirmAgencyServiceAgreementModalIsDisplayed(string is_isnot)
		{
			var asam = new AgencyServiceAgreementModal();
			bool expected = is_isnot == "is";
			Report.IsTrue(asam.WaitForContainerToBeVisible(10) == expected,$"Failure, Agency Service Agreement Modal does not exist.",$"Success, Agency Service Agreement Modal does exist.");
		}

		[StepDefinition(@"In the Agency Service Agreement modal, I confirm the title displays: (.*)")]
		public void ConfirmAgencyServiceAgreementModalTitleDisplays(string modalTitle)
		{
			var asam = new AgencyServiceAgreementModal();
			Report.IsTrue(asam.ModalTitleExists(modalTitle), $"Failure, modal title doe snot display correctly.", $"Success, modal title displays correctly.");
		}

		[StepDefinition(@"In the Agency Service Agreement modal, I confirm the body text displays: (.*)")]
		public void ConfirmAgencyServiceAgreementModalBodyTextDisplays(string expectedText)
		{
			var asam = new AgencyServiceAgreementModal();
			string displayedText = asam.ModalBodyTextGet();
			Report.IsTrue(displayedText.Trim() == expectedText.Trim(), $"Failure, displayed text: '{displayedText}' does not match expected text: '{expectedText}'.", $"Success, displayed text matches expected text.");
		}

		[StepDefinition(@"In the Agency Service Agreement modal, I click the (.*) button")]
		public void InAgencyServiceAgreementModalClickButton(string buttonLabel)
		{
			var asam = new AgencyServiceAgreementModal();
			if(Report.IsTrue(asam.ModalButtonExists(buttonLabel),$"Failure, in the Agency Service Agreement modal, I confirm '{buttonLabel}' button does not exists.",$"Success, in the Agency Service Agreement modal, I confirm '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(asam.ModalButtonClick(buttonLabel), $"Failure, in the Agency Service Agreement modal, failed to click '{buttonLabel}' button.", $"Success, in the Agency Service Agreement modal, successfully clicked '{buttonLabel}' button.");
			}
		}

		[StepDefinition(@"I confrim the (.*) footer exists and displays the text: (.*)")]
		public void ConfirmFooterExistsAndDisplaysText(string footerLabel, string footerTextAreaText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if(Report.IsTrue(subEnrollment.EnrollmentFooterExists(),$"Failure, enrollment footer does not exist.",$"Success, enrollment footer exists."))
			{
				if(Report.IsTrue(subEnrollment.EnrollmentFooterLabelExists(footerLabel),$"Failure, in the enrollment footer '{footerLabel}' label does not exist.",$"Success, in fhte enrollment footer '{footerLabel}' label does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentFooterTextAreaExists(footerTextAreaText), $"Failure, in the enrollment footer text area containing: '{footerTextAreaText}' does not exist.", $"Success, in the enrollment footer text area containing: '{footerTextAreaText}' exists.");
				}
			}
		}

		[StepDefinition(@"In the enrollment footer, I confirm the (.*) calculator displayes: (.*)")]
		public void InEnrollmentFooterConfirmCalculatorDisplays(string footerCalculatorLabel, string footerCalculatorValue)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentFooterExists(), $"Failure, enrollment footer does not exist.", $"Success, enrollment footer exists."))
			{
				if(Report.IsTrue(subEnrollment.EnrollmentFooterCalculatorExists(footerCalculatorLabel),$"Failure, '{footerCalculatorLabel}' calculator does not exist.",$"Success, '{footerCalculatorLabel}' exists."))
				{
					string footerCaluculatorResultDisplayed = subEnrollment.EnrollmentFooterCalculatorResultGet(footerCalculatorLabel);
					Report.IsTrue(footerCaluculatorResultDisplayed == footerCalculatorValue, $"Failure, '{footerCalculatorLabel}' calculator value displayed: '{footerCaluculatorResultDisplayed}' does not match expected: '{footerCalculatorValue}'.", $"Success, '{footerCalculatorLabel}' calculator displayed value: '{footerCalculatorValue}' matches expected.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section I confirm the (.*) panel (is|is not) grayed out")]
		public void InSectionConfirmPanelIsIsNotGrayedOut(string sectionLabel, string panelLabel, string is_isnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = is_isnot == "is";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentPanelIsGrayedOut(sectionLabel, panelLabel) == expected, $"Failure, '{sectionLabel}' section '{panelLabel}' panel {(expected ? "is not" : "is")} grayed out.", $"Success, '{sectionLabel}' section '{panelLabel}' panel {is_isnot} grayed out.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section I confirm the (.*) panel (does|does not) have the message: (.*)")]
		public void InSectionConfirmPanelIsIsNotGrayedOut(string sectionLabel, string panelLabel, string does_doesnot, string messageText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentPanelHasMessage(sectionLabel, panelLabel, messageText) == expected, $"Failure, '{sectionLabel}' section '{panelLabel}' panel {(expected ? "does not" : "does")} have message '{messageText}'.", $"Success, '{sectionLabel}' section '{panelLabel}' panel {does_doesnot} have message '{messageText}'.");
				}
			}
		}
	}
}

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
			Report.IsTrue(new SubscriptionEnrollment_new().EnrollmentSectionExists(sectionLabel) == expected, $"Failed, '{sectionLabel}' section {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.", $"Success, '{sectionLabel}' section {does_doesnot} exist.");
		}

		[StepDefinition(@"In the (.*) section, I confirm the (.*) heading (does|does not) exist")]
		public void InSectionConfirmHeadingDoesDoesNotExist(string sectionLabel, string headingText, string does_doesnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel) == expected, $"Failed, '{sectionLabel}' section {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.", $"Success, '{sectionLabel}' section {does_doesnot} exist."))
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
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyTextAreaExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel text area does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel text area does exist."))
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
					if (Report.IsTrue(subEnrollment.EnrollmentPanelSelectorExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel selector does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel selector exists."))
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
					if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemExists(sectionLabel, panelLabel, panelListText), $"Failed, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item does not exist and should.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{panelListText}' list item exists."))
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
							Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaIsDisplayed(sectionLabel, panelLabel, panelListText) == expected, $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area {(expected ? "is not" : "is")} displayed and {(expected ? "should" : "should not")}.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area {is_isnot} displayed.");
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
						if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaExists(sectionLabel, panelLabel, panelListText), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the info text area exists."))
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
							if (Report.IsTrue(subEnrollment.EnrollmentPanelBodyListItemInfoTextAreaLinkExists(sectionLabel, panelLabel, panelListText, linkLabel), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the '{linkLabel}' link does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel '{panelListText}' list item, the '{linkLabel}' link exists."))
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
					Report.IsTrue(subEnrollment.EnrollmentPanelFooterExists(sectionLabel, panelLabel, footerText) == expected, $"Faiure, in '{sectionLabel}' section '{panelLabel}' panel, '{footerText}' footer {(expected ? "does not" : "does")} exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, '{footerText}' footer {does_doesnot} exist.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confrim the radio (is|is not) selected")]
		public void InSectionPanelConfirmRadioIsIsNotSelected(string sectionLabel, string panelLabel, string is_isnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = is_isnot == "is";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if(Report.IsTrue(subEnrollment.EnrollmentPanelRadioExists(sectionLabel, panelLabel),$"Failure, in '{sectionLabel}' section '{panelLabel}' panel, the radio button does not exist.",$"Success, in '{sectionLabel}' section '{panelLabel}' panel, the radio button does exist."))
					{
						Report.IsTrue(subEnrollment.EnrollmentPanelRadioIsSelected(sectionLabel, panelLabel) == expected, $"Failure, in '{sectionLabel}' section '{panelLabel}' panel, the radio button {(expected ? "is not" : "is")} selected.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, the radio button {is_isnot} selected.");
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I click the radio button")]
		public void InSectionPanelClickRadioButton(string sectionLabel, string panelLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentPanelRadioExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section '{panelLabel}' panel, the radio button does not exist.", $"Success, in '{sectionLabel}' section '{panelLabel}' panel, the radio button does exist."))
					{
						Report.IsTrue(subEnrollment.EnrollmentPanelRadioClick(sectionLabel, panelLabel), $"Failure, failed to click '{sectionLabel}' section '{panelLabel}' panel radio button.", $"Success, clicked '{sectionLabel}' section '{panelLabel}' panel radio button.");
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section, I confirm the text area displays: (.*)")]
		public void InSectionConfirmTextAreaDisplays(string sectionLabel, string sectionText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentSectionTextAreaExists(sectionLabel), $"Failure, '{sectionLabel}' section text area does not exist.", $"Success, '{sectionLabel}' section text area does exist."))
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
					if (Report.IsTrue(subEnrollment.EnrollmentSectionTextAreaLinkExists(sectionLabel, linkLabel), $"Failure, '{sectionLabel}' section text area '{linkLabel}' link does not exist.", $"Success, '{sectionLabel}' section text area '{linkLabel}' link does exist."))
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
			Report.IsTrue(asam.WaitForContainerToBeVisible(10) == expected, $"Failure, Agency Service Agreement Modal does not exist.", $"Success, Agency Service Agreement Modal does exist.");
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
			if (Report.IsTrue(asam.ModalButtonExists(buttonLabel), $"Failure, in the Agency Service Agreement modal, I confirm '{buttonLabel}' button does not exists.", $"Success, in the Agency Service Agreement modal, I confirm '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(asam.ModalButtonClick(buttonLabel), $"Failure, in the Agency Service Agreement modal, failed to click '{buttonLabel}' button.", $"Success, in the Agency Service Agreement modal, successfully clicked '{buttonLabel}' button.");
			}
		}

		[StepDefinition(@"I confrim the (.*) footer exists and displays the text: (.*)")]
		public void ConfirmFooterExistsAndDisplaysText(string footerLabel, string footerTextAreaText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentFooterExists(), $"Failure, enrollment footer does not exist.", $"Success, enrollment footer exists."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentFooterLabelExists(footerLabel), $"Failure, in the enrollment footer '{footerLabel}' label does not exist.", $"Success, in fhte enrollment footer '{footerLabel}' label does exist."))
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
				if (Report.IsTrue(subEnrollment.EnrollmentFooterCalculatorExists(footerCalculatorLabel), $"Failure, '{footerCalculatorLabel}' calculator does not exist.", $"Success, '{footerCalculatorLabel}' exists."))
				{
					string footerCaluculatorResultDisplayed = subEnrollment.EnrollmentFooterCalculatorResultGet(footerCalculatorLabel);
					Report.IsTrue(footerCaluculatorResultDisplayed == footerCalculatorValue, $"Failure, '{footerCalculatorLabel}' calculator value displayed: '{footerCaluculatorResultDisplayed}' does not match expected: '{footerCalculatorValue}'.", $"Success, '{footerCalculatorLabel}' calculator displayed value: '{footerCalculatorValue}' matches expected.");
				}
			}
		}

		[StepDefinition(@"In the enrollment footer, I click the (.*) button")]
		public void InEnrollmentFooterClickButton(string buttonLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentFooterExists(), $"Failure, enrollment footer does not exist.", $"Success, enrollment footer exists."))
			{
				if(Report.IsTrue(subEnrollment.EnrollmentFooterButtonExists(buttonLabel),$"Failure, in enrollment footer '{buttonLabel}' button does not exist.",$"Success, in enrollment footer '{buttonLabel}' button exists."))
				{
					Report.IsTrue(subEnrollment.EnrollmentFooterButtonClick(buttonLabel), $"Failure, in enrollment footer failed to click '{buttonLabel}' button.", $"Success, in enrollment footer clicked '{buttonLabel}' button.");
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

		[StepDefinition(@"In the Subscription Enrollment screen, I confirm heading: (.*)")]
		public void InSubscriptionEnrollmentScreenConfirmHeading(string pageHeading)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentPageHeaderExists(), $"Failure, enrollment page header does not exist.", $"Success, enrollment page header exists."))
			{
				string pageHeadingDisplayed = subEnrollment.EnrollmentPageHeaderGet();
				Report.IsTrue(pageHeadingDisplayed.Trim() == pageHeading.Trim(), $"Failure, enrollment page header displayed: '{pageHeadingDisplayed}' does not match expected: '{pageHeading}'.", $"Success, enrollment page header displayed: '{pageHeading}' matches expected.");
			}
		}

		[StepDefinition(@"In the Subscription Enrollment page, I confirm an alert message with the text: (.*)")]
		public void InSubscriptionEnrollmentPageConfrimAlertMessageWithText(string messageText)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentAlertsExist(), $"Failure, no enrollment alerts exist.", $"Success, enrollment alerts exist."))
			{
				Report.IsTrue(subEnrollment.EnrollmentAlertsContain(messageText.Trim()), $"Failure, '{messageText}' alert message does not exist.", $"Success, '{messageText}' alert message exists.");
			}
		}

		[StepDefinition(@"In the (.*) section, I confirm the (.*) panel drop down (does|does not) exist")]
		public void InSectionConfirmPanelDropDoesDoesDoesNotExist(string sectionLabel, string panelLabel, string does_doesnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentPanelSelectorExists(sectionLabel, panelLabel) == expected, $"Failure, '{sectionLabel}' section '{panelLabel}' panel selector {(expected ? "does not" : "does")} exist.", $"Success, '{sectionLabel}' section '{panelLabel}' panel selector {does_doesnot} exust.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the (.*) selector option (does|does not) exist")]
		public void InSectionPanelConfirmSelectorOptionDoesDoesNotExist(string sectionLabel, string panelLabel, string optionLabel, string does_doesnot)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			bool expected = does_doesnot == "does";
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					Report.IsTrue(subEnrollment.EnrollmentPanelSelectorOptionExists(sectionLabel, panelLabel, optionLabel) == expected, $"Failure, '{sectionLabel}' section '{panelLabel}' panel '{optionLabel}' selector option {(expected ? "does not" : "does")} exist.", $"Success, '{sectionLabel}' section '{panelLabel}' panel '{optionLabel}' selector option {does_doesnot} exust.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the following selector options (do|do not) exist:")]
		public void InSectionPanelIConfirmFollowingSelectorOptionsDoDoNotExist(string sectionLabel, string panelLabel, string do_donot, Table selectorOptionsTable)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			string does_doesnot = do_donot.Replace("do", "does");
			foreach(TableRow selectorOptionRow in selectorOptionsTable.Rows)
			{
				this.InSectionPanelConfirmSelectorOptionDoesDoesNotExist(sectionLabel, panelLabel, selectorOptionRow[0], does_doesnot);
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the (.*) selector option is selected")]
		public void InSectionPanelIConfirmSelectorOptionIsSelected(string sectionLabel, string panelLabel, string optionLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					bool expected = true;
					if(Report.IsTrue(subEnrollment.EnrollmentPanelSelectorOptionExists(sectionLabel, panelLabel, optionLabel) == expected, $"Failure, '{sectionLabel}' section '{panelLabel}' panel '{optionLabel}' selector option {(expected ? "does not" : "does")} exist.", $"Success, '{sectionLabel}' section '{panelLabel}' panel '{optionLabel}' selector option does not exist."))
					{
						if(Report.IsTrue(subEnrollment.EnrollmentPanelSelectorClick(sectionLabel, panelLabel),$"Failure, failed to click selector.",$"Success, clicked selector."))
						{
							Report.IsTrue(subEnrollment.EnrollmentPanelSelectorOptionClick(sectionLabel, panelLabel, optionLabel), $"Failure, failed to click '{optionLabel}' option.", $"Success, clicked '{optionLabel}' option.");
						}
					}
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I select the (.*) selector option")]
		public void InSectionPanelISelectSelectorOption(string sectionLabel, string panelLabel, string optionLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					string optionLabelDisplayed = subEnrollment.EnrollmentPanelSelectorValueGet(sectionLabel, panelLabel);
					Report.IsTrue(optionLabelDisplayed.Trim() == optionLabel.Trim(), $"Failure, '{sectionLabel}' section '{panelLabel}' panel selector option displyed: '{optionLabelDisplayed}' does not match expected: '{optionLabel}'.", $"Success, '{sectionLabel}' section '{panelLabel}' panel selector option displayed '{optionLabelDisplayed}' matches expected.");
				}
			}
		}

		[StepDefinition(@"In the (.*) section (.*) panel, I confirm the panel sub label text is: (.*)")]
		public void InSectionPanelConfirmPanelSubLabelText(string sectionLabel, string panelLabel, string panelSubLabel)
		{
			var subEnrollment = new SubscriptionEnrollment_new();
			if (Report.IsTrue(subEnrollment.EnrollmentSectionExists(sectionLabel), $"Failed, '{sectionLabel}' section does not exist and should.", $"Success, '{sectionLabel}' section does exist."))
			{
				if (Report.IsTrue(subEnrollment.EnrollmentPanelExists(sectionLabel, panelLabel), $"Failure, in '{sectionLabel}' section, '{panelLabel}' panel does not exist and should.", $"Success, in '{sectionLabel}' section, '{panelLabel}' panel does exist."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentPanelSubLabelExists(sectionLabel, panelLabel), $"Failure, '{sectionLabel}' section '{panelLabel}' panel sub label does not exist.", $"Success, '{sectionLabel}' section '{panelLabel}' panel exists."))
					{
						string panelSubLabelDisplayed = subEnrollment.EnrollmentPanelSubLabelGet(sectionLabel, panelLabel);
						Report.IsTrue(panelSubLabelDisplayed.Trim() == panelSubLabel.Trim(), $"Failure, '{sectionLabel}' section '{panelLabel}' panel sub label displyed: '{panelSubLabelDisplayed}' does not match expected: '{panelSubLabel}'.", $"Success, '{sectionLabel}' section '{panelLabel}' panel sub label displayed '{panelSubLabelDisplayed}' matches expected.");
					}
				}
			}
		}

		[StepDefinition(@"In the Subscription Enrollment Modal, I click the (.*) button")]
		public void InSubscriprionEnrollmentModalClickButton(string buttonLabel)
		{
			var sem = new SubscriptionEnrollmentModal();
			if (Report.IsTrue(sem.ModalButtonExists(buttonLabel), $"Failure, in the Subscription Enrollment modal, I confirm '{buttonLabel}' button does not exists.", $"Success, in the Subscription Enrollment modal, I confirm '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(sem.ModalButtonClick(buttonLabel), $"Failure, in the Subscription Enrollment modal, failed to click '{buttonLabel}' button.", $"Success, in the Subscription Enrollment modal, successfully clicked '{buttonLabel}' button.");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SubscriptionEnrollment_new : SeleniumBaseObject
	{
		#region Constants
		protected override By ContainerElementLocator => By.Id("enrollment");
		private IWebElement EnrollmentPageHeader => this.ContainerElement.FindElement(By.XPath($".//h2"),1);
		private List<IWebElement> EnrollmentAlertMessages => this.ContainerElement.FindElements(By.XPath($".//div[@class ='alert alert-warning' and not(starts-with(@style,'display: none'))]/p"), 1).ToList();

		#region Section Level
		private string _sectionLabel;
		private IWebElement EnrollmentSection => this.ContainerElement.FindElement(By.XPath($".//div[contains(@class,'row')][.//h3[normalize-space(text())='{_sectionLabel}']]"), 1);
		private string _headingText;
		private IWebElement EnrollmentSectionHeading => this.EnrollmentSection.FindElement(By.XPath($".//strong[text()='{_headingText}']"), 1);
		private IWebElement EnrollmentSectionTextArea => this.EnrollmentSection.FindElement(By.XPath($".//div[@class='col-sm-12']//p"), 1);
		private string _sectionLinkLabel;
		private IWebElement EnrollmentSectionTextAreaLink => this.EnrollmentSectionTextArea.FindElement(By.XPath($".//a[text()='{_sectionLinkLabel}']"), 1);
		#endregion
		#region PanelLevel
		private string _panelLabel;
		private IWebElement EnrollmentPanel => this.EnrollmentSection.FindElement(By.XPath($".//div[contains(@class,'ws-subscription')][ .//div[@class='agency-header'][normalize-space(text()) = '{_panelLabel}'] | .//label[normalize-space(text())='{_panelLabel}']]"), 1);
		private IWebElement EnrollmentPanelSubLabel => this.EnrollmentPanel.FindElement(By.XPath($".//div[@class='agency-header']//span[text()]"), 1);
		private IWebElement EnrollmentPanelBody => this.EnrollmentPanel.FindElement(By.XPath(".//div[contains(@class,'panel-body')]"), 1);
		private IWebElement EnrollmentPanelBodyTextArea => this.EnrollmentPanelBody.FindElement(By.XPath($".//div[contains(@class,'small')] | .//p"), 1);
		private string _panelListText;
		private IWebElement EnrollmentPanelBodyListItem => this.EnrollmentPanelBody.FindElement(By.XPath($".//li[normalize-space(text())='{_panelListText}']"), 1);
		private IWebElement EnrollmentPanelBodyListItemInfoButton => this.EnrollmentPanelBodyListItem.FindElement(By.XPath($".//a[@data-toggle]"), 1);
		private IWebElement EnrollmentPanelBodyListItemInfoTextArea => this.EnrollmentPanelBodyListItem.FindElement(By.XPath($".//div[contains(@class,'info-bubble')]"), 1);
		private string _linkLabel;
		private IWebElement EnrollmentPanelBodyListItemInfoTextAreaLink => this.EnrollmentPanelBodyListItemInfoTextArea.FindElement(By.XPath($".//a[text()='{_linkLabel}']"),1);
		private IWebElement EnrollmentPanelSelector => this.EnrollmentPanel.FindElement(By.XPath(".//select"), 1);
		private string _optionLabel;
		private IWebElement EnrollmentPanelSelectorOption => this.EnrollmentPanelSelector.FindElement(By.XPath($".//option[text()='{_optionLabel}']"), 1);
		private IWebElement EnrollmentPanelRadio => this.EnrollmentPanel.FindElement(By.XPath(".//div[@class='subs__indicator']"), 1);
		private string _footerText;
		private IWebElement EnrollmentPanelFooter => this.EnrollmentPanel.FindElement(By.XPath($".//div[contains(@class,'panel-footer')][contains(.,'{_footerText}')]"), 1);
		private bool EnrollmentPanelGrayedOut => this.EnrollmentPanel.FindElement(By.XPath($".//ancestor-or-self::div[contains(@style,'opacity:')]"), 1) != null;
		private string _enrollmentPanelMessageText;
		private bool EnrollmentPanelMessageExists => this.EnrollmentPanel.FindElement(By.XPath($".//ancestor-or-self::div//h3[@style='color:blue;']//strong[text()='{_enrollmentPanelMessageText}']"), 1) != null;
		#endregion

		#region Footer Level
		private IWebElement EnrollmentFooter => this.ContainerElement.FindElement(By.XPath($".//div[contains(@class,'panel panel-footer')]"), 1);
		private string _footerLabel;
		private IWebElement EnrollmentFooterLabel => this.EnrollmentFooter.FindElement(By.XPath($".//h3[text()='{_footerLabel}']"), 1);
		private string _footerTextAreaText;
		private IWebElement EnrollmentFooterTextArea => this.EnrollmentFooter.FindElement(By.XPath($".//p[text()='{_footerTextAreaText}']"), 1);
		private string _footerCalculatorLabel;
		private IWebElement EnrollmentFooterCalculator => this.EnrollmentFooter.FindElement(By.XPath($".//div[@class='calculator-total'][.//p[text()='{_footerCalculatorLabel}: ']]"), 1);
		private IWebElement EnrollmentFooterCalculatorResult => this.EnrollmentFooterCalculator.FindElement(By.XPath($".//strong"), 1);
		private string _footerButtonLabel;
		private IWebElement EnrollmentFooterButton => this.EnrollmentFooter.FindElement(By.XPath($".//button[text()='{_footerButtonLabel}']"), 1);
		#endregion
		#endregion

		#region Methods
		public bool EnrollmentPageHeaderExists()
		{
			Report.Info($"Attempting to confirm enrollment page header exists.");
			return this.EnrollmentPageHeader != null;
		}

		public string EnrollmentPageHeaderGet()
		{
			Report.Info($"Attempting to get enrollment page header text.");
			return this.EnrollmentPageHeader.Text;
		}

		public bool EnrollmentAlertsExist()
		{
			Report.Info($"Attempting to confirm enrollment alerts exist.");
			return this.EnrollmentAlertMessages.Count != 0;
		}

		public bool EnrollmentAlertsContain(string alertMessage)
		{
			Report.Info($"Attempting to confirm '{alertMessage}' message exists.");
			return this.EnrollmentAlertMessages.Where(x => x.Displayed).ToList().Select(x => x.GetValue().Trim() == alertMessage).FirstOrDefault();
		}

		#region SectionLevel
		public bool EnrollmentSectionExists(string sectionLabel)
		{
			Report.Info($"Attempting to confirm '{sectionLabel}' section exists.");
			_sectionLabel = sectionLabel;
			return this.EnrollmentSection != null;
		}
		public bool EnrollmentSectionHeadingExists(string sectionLabel, string headingText)
		{
			Report.Info($"Attempting to confirm '{sectionLabel}' section title exists.");
			_sectionLabel = sectionLabel;
			_headingText = headingText;
			return this.EnrollmentSectionHeading != null;
		}
		public bool EnrollmentSectionTextAreaExists(string sectionLabel)
		{
			Report.Info($"Attempting to confirm '{sectionLabel}' section text area exists.");
			_sectionLabel = sectionLabel;
			return this.EnrollmentSectionTextArea != null;
		}

		public string EnrollmentSectionTextAreaTextGet(string sectionLabel)
		{
			Report.Info($"Attempting to get '{sectionLabel}' section text area text.");
			_sectionLabel = sectionLabel;
			return this.EnrollmentSectionTextArea.Text;
		}

		public bool EnrollmentSectionTextAreaLinkExists(string sectionLabel, string sectionLinkLabel)
		{
			Report.Info($"Attempting to confirm '{sectionLabel}' section text area '{sectionLinkLabel}' link exists.");
			_sectionLabel = sectionLabel;
			_sectionLinkLabel = sectionLinkLabel;
			return this.EnrollmentSectionTextAreaLink != null;
		}

		public bool EnrollmentSectionTextAreaLinkClick(string sectionLabel, string sectionLinkLabel)
		{
			Report.Info($"Attempting to click '{sectionLabel}' section text area '{sectionLinkLabel}' link.");
			_sectionLabel = sectionLabel;
			_sectionLinkLabel = sectionLinkLabel;
			return this.EnrollmentSectionTextAreaLink.TryClick();
		}
		#endregion
		#region PanelLevel
		public bool EnrollmentPanelExists(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanel != null;
		}

		public bool EnrollmentPanelSubLabelExists(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to confrim '{panelLabel}' panel sub label exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelSubLabel != null;
		}

		public string EnrollmentPanelSubLabelGet(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to get '{panelLabel}' panel sub label.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelSubLabel.Text;
		}

		public bool EnrollmentPanelBodyTextAreaExists(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attemting to confirm '{panelLabel}' text area exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelBodyTextArea != null;
		}

		public string EnrollmentPanelBodyTextAreaTextGet(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to get '{panelLabel}' text area text.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelBodyTextArea.Text;
		}

		public bool EnrollmentPanelBodyListItemExists(string sectionLabel, string panelLabel, string panelListText)
		{
			Report.Info($"Attempting to confirm '{panelListText}' list item exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			return this.EnrollmentPanelBodyListItem != null;
		}

		public bool EnrollmentPanelBodyListItemInfoButtonExists(string sectionLabel, string panelLabel, string panelListText)
		{
			Report.Info($"Attempting to confirm '{panelListText}' list item info button exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			return this.EnrollmentPanelBodyListItemInfoButton != null;
		}

		public bool EnrollmentPanelBodyListItemInfoButtonClick(string sectionLabel, string panelLabel, string panelListText)
		{
			Report.Info($"Attempting to click '{panelListText}' list item info button.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			this.EnrollmentPanelBodyListItemInfoButton.ScrollElementIntoView();
			return this.EnrollmentPanelBodyListItemInfoButton.JsClick();
		}

		public bool EnrollmentPanelBodyListItemInfoTextAreaExists(string sectionLabel, string panelLabel, string panelListText)
		{
			Report.Info($"Attempting to confirm '{panelListText}' list item info text exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			return this.EnrollmentPanelBodyListItemInfoTextArea != null;
		}

		public bool EnrollmentPanelBodyListItemInfoTextAreaIsDisplayed(string sectionLabel, string panelLabel, string panelListText)
		{
			Report.Info($"Attempting to confirm '{panelListText}' list item info text is displayed.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			return this.EnrollmentPanelBodyListItemInfoTextArea.Displayed;
		}

		public string EnrollmentPanelBodyListItemInfoTextAreaTextGet(string sectionLabel, string panelLabel, string panelListText)
		{
			Report.Info($"Attempting to get '{panelListText}' list item info text.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			return this.EnrollmentPanelBodyListItemInfoTextArea.GetTextContent().Replace("\n", "").Replace("\t","").Replace("\r", " ");
		}

		public bool EnrollmentPanelBodyListItemInfoTextAreaLinkExists(string sectionLabel, string panelLabel, string panelListText, string linkLabel)
		{
			Report.Info($"Attempting to confirm '{linkLabel}' link exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			_linkLabel = linkLabel;
			return this.EnrollmentPanelBodyListItemInfoTextAreaLink != null;
		}

		public bool EnrollmentPanelBodyListItemInfoTextAreaLinkClick(string sectionLabel, string panelLabel, string panelListText, string linkLabel)
		{
			Report.Info($"Attempting to click '{linkLabel}' link.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_panelListText = panelListText;
			_linkLabel = linkLabel;
			return this.EnrollmentPanelBodyListItemInfoTextAreaLink.TryClick();
		}

		public bool EnrollmentPanelSelectorExists(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel selector exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelSelector != null;
		}

		public string EnrollmentPanelSelectorValueGet(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to get '{panelLabel}' panel selector current value.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelSelector.GetValue();
		}

		public bool EnrollmentPanelSelectorClick(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to click '{panelLabel}' panel selector.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelSelector.TryClick();
		}

		public bool EnrollmentPanelSelectorOptionExists(string sectionLabel, string panelLabel, string optionLabel)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel '{optionLabel}' option exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_optionLabel = optionLabel;
			return this.EnrollmentPanelSelectorOption != null;
		}

		public bool EnrollmentPanelSelectorOptionClick(string sectionLabel, string panelLabel, string optionLabel)
		{
			Report.Info($"Attempting to click '{panelLabel}' panel '{optionLabel}' option.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_optionLabel = optionLabel;
			return this.EnrollmentPanelSelectorOption.TryClick();
		}
		
		public bool EnrollmentPanelRadioExists(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel radio button exists.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelRadio != null;
		}

		public bool EnrollmentPanelRadioIsSelected(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel radio button is selected.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			var test = this.EnrollmentPanelRadio.GetCssValue("box-shadow");
			return this.EnrollmentPanelRadio.GetCssValue("box-shadow") != "none";
		}

		public bool EnrollmentPanelRadioClick(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to click '{panelLabel}' radio button.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelRadio.JsClick();
		}

		public bool EnrollmentPanelFooterExists(string sectionLabel, string panelLabel, string footerText)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel has '{footerText}' footer.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_footerText = footerText;
			return this.EnrollmentPanelFooter != null;
		}

		public bool EnrollmentPanelIsGrayedOut(string sectionLabel, string panelLabel)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel is grayed out.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			return this.EnrollmentPanelGrayedOut;
		}

		public bool EnrollmentPanelHasMessage(string sectionLabel, string panelLabel, string enrollmentPanelMessage)
		{
			Report.Info($"Attempting to confirm '{panelLabel}' panel has '{enrollmentPanelMessage}' message.");
			_sectionLabel = sectionLabel;
			_panelLabel = panelLabel;
			_enrollmentPanelMessageText = enrollmentPanelMessage;
			return this.EnrollmentPanelMessageExists;
		}
		#endregion
		#region Footer Methods
		public bool EnrollmentFooterExists()
		{
			Report.Info($"Attempting to confirm enrollment page footer exists.");
			return this.EnrollmentFooter != null;
		}

		public bool EnrollmentFooterLabelExists(string footerLabel)
		{
			Report.Info($"Attempting to confirm '{footerLabel}' label exists.");
			_footerLabel = footerLabel;
			return this.EnrollmentFooterLabel != null;
		}

		public bool EnrollmentFooterTextAreaExists(string footerTextAreaText)
		{
			Report.Info($"Attempting to confrim footer text area exists with text: '{footerTextAreaText}'.");
			_footerTextAreaText = footerTextAreaText;
			return this.EnrollmentFooterTextArea != null;
		}

		public bool EnrollmentFooterCalculatorExists(string footerCalculatorLabel)
		{
			Report.Info($"Attempting to confirm '{footerCalculatorLabel}' calcualtor exists.");
			_footerCalculatorLabel = footerCalculatorLabel;
			return this.EnrollmentFooterCalculator != null;
		}

		public string EnrollmentFooterCalculatorResultGet(string footerCalculatorLabel)
		{
			Report.Info($"Attempting to get '{footerCalculatorLabel}' calcualtor result.");
			_footerCalculatorLabel = footerCalculatorLabel;
			return this.EnrollmentFooterCalculatorResult.Text;
		}

		public bool EnrollmentFooterButtonExists(string footerButtonLabel)
		{
			Report.Info($"Attempting to confirm '{footerButtonLabel}' button exists.");
			_footerButtonLabel = footerButtonLabel;
			return this.EnrollmentFooterButton != null;
		}

		public bool EnrollmentFooterButtonClick(string footerButtonLabel)
		{
			Report.Info($"Attempting to click '{footerButtonLabel}' button.");
			_footerButtonLabel = footerButtonLabel;
			return this.EnrollmentFooterButton.TryClick();
		}
		#endregion
		#endregion
	}

	class AgencyServiceAgreementModal : SeleniumBaseObject
	{
		#region Constants
		protected override By ContainerElementLocator => By.Id("showAgencyServiceAgreement");
		string _modalTitle;
		private IWebElement ModalTitle => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-header']//h3[text()='{_modalTitle}']"),1);
		private IWebElement ModalHeaderCloseButton => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-header']//button[@class='close']"), 1);
		private IWebElement ModalBody => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-body']"), 1);
		private string _buttonLabel;
		private IWebElement ModalButton => this.ContainerElement.FindElement(By.XPath($".//button[text()='{_buttonLabel}']"), 1);
		#endregion

		#region Methods
		public bool ModalTitleExists(string modalTitle)
		{
			Report.Info($"Attempting to confirm {modalTitle} modal exists.");
			_modalTitle = modalTitle;
			return this.ModalTitle != null;
		}

		public bool ModalHeaderCloseButtonExists()
		{
			Report.Info($"Attempting to confirm modal header close button exists.");
			return this.ModalHeaderCloseButton != null;
		}

		public bool ModalHeaderCloseButtonClick()
		{
			Report.Info($"Attempting to click modal header close button.");
			return this.ModalHeaderCloseButton.TryClick();
		}

		public bool ModalBodyExists()
		{
			Report.Info($"Attempting to confirm modal body exists.");
			return this.ModalBody != null;
		}

		public string ModalBodyTextGet()
		{
			Report.Info($"Attemoting to get modal body text.");
			return this.ModalBody.Text;
		}

		public bool ModalButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exists.");
			_buttonLabel = buttonLabel;
			return this.ModalButton != null;
		}

		public bool ModalButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			_buttonLabel = buttonLabel;
			return this.ModalButton.TryClick();
		}
		#endregion
	}

	class SubscriptionEnrollmentModal : SeleniumBaseObject
	{
		#region Constants
		protected override By ContainerElementLocator => By.Id("subscriptionSummary");
		string _modalTitle;
		private IWebElement ModalTitle => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-header']//h2[text()='{_modalTitle}']"), 1);
		private IWebElement ModalHeaderCloseButton => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-header']//button[@class='close']"), 1);
		private IWebElement ModalBody => this.ContainerElement.FindElement(By.XPath($".//div[@class='modal-body']"), 1);
		private string _buttonLabel;
		private IWebElement ModalButton => this.ContainerElement.FindElement(By.XPath($".//button[text()='{_buttonLabel}']"), 1);
		#endregion

		#region Methods
		public bool ModalTitleExists(string modalTitle)
		{
			Report.Info($"Attempting to confirm {modalTitle} modal exists.");
			_modalTitle = modalTitle;
			return this.ModalTitle != null;
		}

		public bool ModalHeaderCloseButtonExists()
		{
			Report.Info($"Attempting to confirm modal header close button exists.");
			return this.ModalHeaderCloseButton != null;
		}

		public bool ModalHeaderCloseButtonClick()
		{
			Report.Info($"Attempting to click modal header close button.");
			return this.ModalHeaderCloseButton.TryClick();
		}

		public bool ModalBodyExists()
		{
			Report.Info($"Attempting to confirm modal body exists.");
			return this.ModalBody != null;
		}

		public bool ModalButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exists.");
			_buttonLabel = buttonLabel;
			return this.ModalButton != null;
		}

		public bool ModalButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			_buttonLabel = buttonLabel;
			return this.ModalButton.TryClick();
		}
		#endregion
	}
}

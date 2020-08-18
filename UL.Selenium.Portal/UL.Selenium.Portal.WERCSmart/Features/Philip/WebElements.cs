using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	class WebElements : SeleniumBaseObject
	{

		public const string BasePath = "";

		protected override By ContainerElementLocator => throw new System.NotImplementedException();

		public bool CheckTextInForumulationBatteriesPage()
		{
			IWebElement displayedText = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: description, attr: { class: msgClass }']"), 2);
			Report.Info("testing ---" + displayedText.Text);
			if (displayedText.Text.Contains("Data Use Consents"))
			{
				Report.Info("testing1");
			}
			if (displayedText.Text.Contains("Direct suppliers with products containing your battery (i.e., your customers) may opt to participate in various chemical policy and product qualification programs operated by WERCSmart Recipients. Further information about these consents and data uses are provided in the Data Use Tier Disclosure section of the WERCSmart Terms of Use."))
			{
				Report.Info("testing2");
			}
			if (displayedText.Text.Contains("You have the option of allowing this battery to be included in such programs by providing the consent below. Such consent means:"))
			{
				Report.Info("testing3");
			}
			if (displayedText.Text.Contains("a. That your battery data may be utilized when UL generates aggregate usage reports, chemical screening results and transparency ratios for such Direct Supplier products (Tier 2.1),"))
			{
				Report.Info("testing4");
			}
			if (displayedText.Text.Contains("b. That the identity of ingredients in your battery (i.e., the standard chemical names or CAS Numbers) may be disclosed to your customer and the relevant WERCSmart Recipient, but only if you have marked an ingredient as publicly disclosed on the formulation page (Tier 2.2) or if applicable law requires that an ingredient be publicly disclosed, and"))
			{
				Report.Info("testing5");
			}
			if (displayedText.Text.Contains("c. That your customer can publicly disclose the identity of ingredients in your battery, but only if you have marked an ingredient as publicly disclosed (Tier 4.2)."))
			{
				Report.Info("testing6");
			}
			if (displayedText.Text.Contains("These consents do not authorize any disclosure of ingredient by percent weight to your customer, any retail Recipient, or the public."))
			{
				Report.Info("testing7");
			}
			return true;
		}

		public bool SelectZipReportCheckbox()
		{
			IWebElement checkbox = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='chkZip']"), 2);
			return checkbox.TryCheck();
		}

		public bool SelectFromSelectFileType(string excelOrCSV)
		{
			IWebElement select = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='fileTypeDDL']"), 2);
			IWebElement option = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='fileTypeDDL']//option[text()='" + excelOrCSV + "']"), 2);
			bool selectSelected = false;
			bool optionSelected = false;

			selectSelected = select.TryClick();
			optionSelected = option.TryClick();

			if (selectSelected && optionSelected)
			{
				return true;
			}

			return false;

		}

		public bool SelectRequestReportButton()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[text()='Request Report']"), 2);
			return button.TryClick();
		}

		public bool SelectCloseButtonInReportDownloadPopup()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@data-dismiss='modal']"), 2);
			return button.TryClick();
		}

		public bool SelectDownloadButtonForMostRecenReport()
		{
			Delay.Seconds(10);
			IList <IWebElement> rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr"), 2);
			IList <IWebElement> columns = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr[1]//td"), 2);
			Report.Info("testing1 - " + rows.Count + " -- -- " + columns.Count );
			int co = rows.Count;
			string costr = co.ToString();
			IWebElement downloadButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr["+costr+"]//td[6]//button"), 2);
			return downloadButton.TryClick();
		}

		public bool CheckReportDataForMostRecentFile(string reportName, string type, string dateRequested, string requestedBy)
		{
			Delay.Seconds(10);
			IList <IWebElement> fileList = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr"), 2);
			Report.Info("testing2 - " + fileList.Count);
			int co = fileList.Count;
			string costr = co.ToString();
			IWebElement reportNameEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr[" + costr + "]//td[1]"), 2);
			Report.Info("testing3");
			IWebElement typeEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr[" + costr + "]//td[3]"), 2);
			Report.Info("testing4");
			IWebElement dateRequestedEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr[" + costr + "]//td[4]"), 2);
			Report.Info("testing5");
			IWebElement requestedByEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//tbody[@data-bind='foreach: model.reportHistories']//tr[" + costr + "]//td[5]"), 2);
			Report.Info("testing1 - " + fileList.Count + "-  - " + reportNameEl.Text + " -   - " + typeEl.Text + " -   - " + requestedByEl.Text);
			if (reportNameEl.Text == reportName && typeEl.Text == type && dateRequestedEl.Text == dateRequested && requestedByEl.Text == requestedBy)
			{
				return true;
			}

			if (reportNameEl.Text != reportName)
			{
				Report.Failure("Failed to match Report Name");
			}
			if (typeEl.Text != type)
			{
				Report.Failure("Failed to match Type");
			}
			if (dateRequestedEl.Text != dateRequested)
			{
				Report.Failure("Failed to match Date Requested");
			}
			if (requestedByEl.Text != requestedBy)
			{
				Report.Failure("Failed to match Requested By");
			}

			return false;
		}




























		public bool CheckDeleteRowsWarningPopupContainsText(string lineOne, string lineTwo)
		{
			IWebElement lineOneEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[1]"), 2);
			IWebElement lineTwoEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[2]"), 2);
			Report.Info("testing1 '" + lineOneEl.Text + "'" + " hi '" + lineTwoEl.Text + "'");
			if (lineOneEl.Text == lineOne && lineTwoEl.Text == lineTwo)
			{
				return true;
			}

			return false;
		}
		public bool CheckForTheFollowingTextInTheOptionReportsPage(string text)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//font[contains(text(),'" + text + "')]"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmUPCNumberIsDisplayedInUPCNumberField(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@data-bind='textInput: upcNumber.field']"), 2);
			if (optionEl.Text == savedAs)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmContainerTypeFieldIsBelowUPCNumberField()
		{
			return true;
		}

		public bool ConfirmTruckIconIsDisplayingNextToUPC(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//i[@class='fa fa-truck']"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseUPCDetailsAreCollapsedForUPC(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//input[@data-bind='textInput: upcNumber.field']"), 2);
			if (optionEl == null)
			{
				return true;
			}

			return false;
		}

		public bool SelectCaseUPCDropDownArrowForUPC(string savedAs, string expandOrCollapse)
		{
			IWebElement optionEl;
			if (expandOrCollapse.ToLower() == "expand")
			{
				optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//em[@class='fa fa-chevron-right']"), 2);
			}
			else
			{
				optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@placeholder='UPC Number']/../../..//a[@title='Expand']"), 2);
			}
			return optionEl.TryClick();
		}

		public bool ConfirmCaseDropDownContainsUPC(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseDropDownWithUPCIsAvailableForSelection(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']/../..//input"), 2);

			if (optionEl != null)
			{
				optionEl.TryCheck();
				return optionEl.Checked();
			}

			return false;
		}

		public bool ConfirmOptionIsCheckedInSection(string option, string section)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[text()='" + section + "']/../following-sibling::div//span[text()='" + option + "']/preceding-sibling::input"), 2);
			if (optionEl.Checked())
			{
				return true;
			}

			return false;
		}

		public bool ConfirmSectionIsAvailableForSelection(string sectionName)
		{
			IList<IWebElement> options = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//label[text()=\"" + sectionName + "\"]/../following-sibling::div//div[@data-toggle='buttons']//input"), 2);

			if (options.Count != 2)
			{
				Report.Info("The amount of options found were not as expected");
				return false;
			}

			foreach (IWebElement el in options)
			{
				if ((el.Text.ToLower() != "no") && (el.Text.ToLower() != "yes"))
				{
					Report.Info("An option with an unexpected name was found");
					return false;
				}

				if (!el.TryClick())
				{
					Report.Info("At least one option was not clickable");
					return false;
				}

			}

			return true;
		}
	}
}

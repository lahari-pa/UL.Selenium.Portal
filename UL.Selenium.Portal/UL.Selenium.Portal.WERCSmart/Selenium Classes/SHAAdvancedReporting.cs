using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;
using System.Collections.ObjectModel;
using System;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SHAAdvancedReporting : SeleniumBaseObject
	{
		public const string BasePath = "//span[@id='ui-dialog-title-dialog-AdvancedReports']/../..";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement popupEditor = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;

		}

		public bool WaitForPreparingReportPopup()
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");

			int counter = 0;
			while (counter < 10)
			{
				Report.Info("Checking to see if Preparing Report popup has disappeared. Try " + counter + ".");
				IWebElement popup = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//div//div//span[contains(text(), 'Preparing report...')]/../.."), 2);
				if (popup.GetCssValue("display") == "none")
				{
					Report.Info("Exiting iFrame");
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return true;
				}
				Delay.Seconds(10);
				counter++;
			}

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return false;
		}

		public bool ClickReport(string report)
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement reportButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//table//td[contains(text(), """ + report + @""")]"), 2);

			bool canClick = reportButton.TryClick();

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return canClick;
		}

		public bool ClickReportNoSwitchBack(string report)
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement reportButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//table//td[contains(text(), """ + report + @""")]"), 2);

			bool canClick = reportButton.TryClick();

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return canClick;
		}

		public bool ClickSubmit()
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement submitButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//form[@id='panel']//input[@name='Submit']"), 2);

			bool canClick = submitButton.TryClick();

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return canClick;
		}

		public bool VerifyPopupTitle(string title, out string output)
		{
			IWebElement actualTitle = this.FindElement(By.Id("ui-dialog-title-preparing-file-modal"), 10);
			output = actualTitle.Text;
			return output == title;
		}

		internal bool CheckReportDescription(string report, string description, out string actualDescription)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement container = frame.FindElement(By.XPath(@"//*[@id='gbox_listAdvancedReports']"));
			string path = @"//*[@id='listAdvancedReports']//td[contains(text(),'" + report + "')]//..//td[@aria-describedby='listAdvancedReports_Description']";

			IWebElement tableDescription = container.FindElement(By.XPath(path), 2);
			actualDescription = tableDescription.Text.Trim();

			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return actualDescription == description;
		}

		internal bool VerifyReportSelectable(string reportName, bool expected)
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement reportButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//table//td[contains(text(), """ + reportName + @""")]"), 2);

			bool canClick = reportButton.TryClick();

			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return canClick == expected;
		}

		internal bool ReportDescriptionNotAvailable(string reportDescription)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement container = frame.FindElement(By.XPath(@"//*[@id='gbox_listAdvancedReports']"));
			string path = @"//*[@id='listAdvancedReports']//td[contains(text(),'" + reportDescription + "')]//..//td[@aria-describedby='listAdvancedReports_Description']";

			IWebElement tableDescription = container.FindElement(By.XPath(path), 2);

			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return tableDescription == null;
		}

		public bool EnterEndDate(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement endDateField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='End Date']//ancestor::td//following-sibling::td//input"), 2);
			if (endDateField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}
			endDateField.JsEnterText(value);
			Delay.Seconds(1);
			Report.Screenshot();

			bool matching = false;

			if (endDateField.GetValue() == value)
			{
				matching = true;
			}

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return matching;
		}

		public bool EnterStartDate(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement startDateField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='Start Date']//ancestor::td//following-sibling::td//input"), 2);
			if (startDateField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}
			startDateField.JsEnterText(value);
			Delay.Seconds(1);
			Report.Screenshot();
			bool matching = false;

			if (startDateField.GetValue() == value)
			{
				matching = true;
			}

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return matching;


		}

		public bool ReportDescriptionIsCorrect(string reportName, string expectedText)
		{
			Report.Info($"Finding the Report Descritpion for: {reportName}");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement descriptionTextFoundEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath($@"//td[text()='{reportName}']//following-sibling::td"), 2);
			string descriptionTextFoundStr = descriptionTextFoundEl.Text;
			Report.Info($"Expected Text: {expectedText}");
			Report.Info($"Found Text: {descriptionTextFoundStr}");
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return descriptionTextFoundStr == expectedText;


		}

		public bool EnterWPSID(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement startDateField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='WPSID']//ancestor::td//following-sibling::td//input"), 2);
			if (startDateField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}
			startDateField.JsEnterText(value);
			Delay.Seconds(1);
			Report.Screenshot();
			bool matching = false;

			if (startDateField.GetValue() == value)
			{
				matching = true;
			}

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return matching;

		}

		public bool ChooseRetailer(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			//IWebElement retailerOption = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='WPSID']//ancestor::td//following-sibling::td//input"), 2);
			IWebElement retailerOption = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@".//span[text()='Retailer']/ancestor::td/following-sibling::td//div//select"), 2);
			if (retailerOption == null)
			{
				Report.Info("Failed to select Retailer from the Retialer Options drop down");
				return false;
			}
			else
			{
				
				retailerOption.Select(value);				
				return retailerOption.SelectedOption() == value;
			}




		}
		public IWebElement CloseButton => this.FindElement(By.XPath(".//button//span[text()='Close']"), 2);
		
		




	}

	class AdvancedReportingDateForm : SeleniumBaseObject
	{
		public const string BasePath = "//*[@id='panel']";

		IWebElement Field { get; set; }


		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool EnterStartEndDates(string start, string end)
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			ReadOnlyCollection<IWebElement> fields = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//input"));

			if (fields.Count < 2)
			{
				Report.Info("The Date fields were unable to be located.");
				return false;
			}

			Report.IsTrue(this.ReplaceAllTextInElementWith(start, fields[0]), "Start Date field was not able to be updated", "Start Date field was updated successfully");
			Report.IsTrue(this.ReplaceAllTextInElementWith(end, fields[1]), "End Date field was not able to be updated", "End Date field was updated successfully");

			fields[0].TryClick();
			fields[1].TryClick();
			fields[2].TryClick();

			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();



			return true;
		}

		private bool ReplaceAllTextInElementWith(string replace, IWebElement element)
		{
			this.Field = element;
			string fieldText = this.Field.GetInnerText();
			this.Field.JsEnterText(replace);
			return !(replace == this.Field.GetInnerText());
		}

		
	}
}

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

		public bool ReportDescriptionIsCorrect(string reportName,string expectedText)
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
	}
}

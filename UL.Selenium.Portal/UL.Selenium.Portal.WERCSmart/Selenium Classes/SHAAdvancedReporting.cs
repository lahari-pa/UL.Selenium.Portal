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

		public bool ClickSubmit()
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement submitButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//form[@id='panel']//input"), 2);

			bool canClick = submitButton.TryClick();

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			return canClick;
		}

		public bool ClickClose()
		{
			IWebElement closeButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//div[@id='dialog-AdvancedReports']/following-sibling::div[contains(@class, 'ui-dialog-buttonpane')]//span"));

			bool canClick = closeButton.TryClick();

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

	class AdvancedReportingDropDownForm : SeleniumBaseObject
	{
		public const string BasePath = "//*[@id='panel']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool SelectOption(string option)
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement select = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select"));

			if (select != null)
			{
				select.Select(option);
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return true;
			}
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return false;
		}

		public bool ClickSubmit()
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement submit = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input"));
			if (submit.TryClick())
			{
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return true;
			}
			else
			{
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return false;
			}

		}
	}

	class AdvancedReportingRetailerProductsInRecert
	{
		public string WPSID { get; set; }

		public string ProductName { get; set; }

		public string Supplier { get; set; }

		public string RecertificationDate { get; set; }
	}
}

using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Automation.Reporting.Functions;
using System;
using TechTalk.SpecFlow;
using NPOI.SS.UserModel;
using Gherkin.Events.Args.Pickle;
using UL.Automation.Reporting.SpecFlow.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SupplierReports : SeleniumBaseObject
	{
		public const string BasePath = "//div[contains(@class, 'main-wrapper')]";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool SelectReport(string report)
		{
			return this.containerElement.FindElements(By.XPath(".//div[@id='reportList']//tr/td//span"))
				.FirstOrDefault(x => x.Text == report).FindElement(By.XPath("./../../a")).TryClick();
		}

		// This gets the title of the right side frame on the page
		public string GetCurrentSubTitle()
		{
			string thing = this.containerElement.FindElement(By.XPath(".//div[@id='rptname']//h3"))?.Text;
			return thing;
		}


		// This gets the left (main) title of the page
		public string GetCurrentTitle()
		{
			return this.containerElement.FindElement(By.XPath("..//h2"))?.Text;
		}

		public string GetSubheadingText()
		{ 

			IWebElement el = this.containerElement.FindElement(By.XPath("//div[@class='product-header']//p"), 2);

			if (el == null)
			{
				return null;
			}

			return el.Text;

		}

		public string GetCurrentSubText()
		{
			return this.containerElement.FindElement(By.XPath(".//form[@id='panel']//p"))?.Text;
		}

		public bool ClickDownload()
		{
			return this.containerElement.FindElement(By.XPath("//form[@id='panel']//button")).TryClick();
		}

		public List<string> GetReportList()
		{
			return this.containerElement.FindElements(By.XPath("//div[@id='reportList']//tr/td//span")).Select(x => x.Text.Trim())
				.ToList();
		}

		//eg 1459158
		public bool SelectSpecificProduct(string searchTerm)
		{
			this.containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]")).TryClick();
			Delay.Seconds(1);
			ReadOnlyCollection<IWebElement> Searches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//input"));
			IWebElement Search = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@type='search']"), 2);

			if (Search == null)
			{
				return false;
			}

			Search.EnterText(searchTerm);
			Delay.Seconds(1);
			IWebElement searching =
				this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			while (searching != null && i < 10)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
				searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"),
					2);
			}

			IList<IWebElement> Matches =
			SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);

			/*
			while (Matches.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) == null)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"),
					2);
			}
			*/

			if (Matches.Count == 0)
			{
				return false;
			}

			IEnumerable<IWebElement> MatchingValues = Matches.Where(x => x.GetValue().Trim().Contains(searchTerm.Trim()));

			if (MatchingValues.Count() == 0)
			{
				return false;
			}
			else
			{
				IWebElement MatchedEntry = MatchingValues.FirstOrDefault();
				return MatchedEntry.TryClick();
			}
		}

		public bool SelectRandomProduct()
		{
			bool found = false;
			int count = 1;
			while (!found && count < 10)
			{
				Report.Info("Entering text: " + count + " into the search input");
				if (this.SelectSpecificProduct(count.ToString()))
				{
					found = true;
					return true;
				}
				count++;
			}
			Report.Info("Failed to enter text into the search input");
			return false;
		}

		public bool SelectRetailer(string retailer)
		{
			IWebElement selectionBox = this.containerElement.FindElement(By.XPath(".//select[@id='retailerProgram']"), 2);

			if (selectionBox == null)
			{
				return false;
			}

			selectionBox.Select(retailer);
			return selectionBox.SelectedOption() == retailer;
		}

		public bool DescriptionTextMatches(string expectedText)
		{
			//first try no remove white spaces
			string actualText = this.containerElement.FindElement(By.XPath(".//p[@data-bind='text: Description']"), 2).Text;

			if (actualText == null)
			{
				return false;
			}

			Report.Info($"The expected Text was: {expectedText}");
			Report.Info($"The actual text found is: {actualText}");
			if (actualText == null)
			{
				Report.Failure("Could not find the description text");
				return false;
			}
			if (actualText == expectedText)
			{
				return true;
			}
			return false;
		}

		internal bool EnterWPSID(string wpsid)
		{
			this.FindElement(By.XPath("//*[@id='panel']//span[@role='combobox']"), 2).TryClick();
			this.FindElement(By.XPath("//input[@class='select2-search__field']"), 2).TryEnterText(wpsid);
			return this.FindElement(By.XPath("//*[@class='select2-results__option select2-results__option--highlighted']"), 2).TryClick();
		}

		public bool ReportHistoryTablePresent()
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			return tableEl != null;
			
		}

		public bool ReportHistoryTableRowsPresent()
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			List<IWebElement> rows = tableEl.FindElements(By.XPath("//tbody//tr"), 5).ToList();
			bool rowsFound = rows.Any();
			return rowsFound;

		}

		public string ReportHistroryLatestReportName()
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			var firstRow = tableEl.FindElement(By.XPath("//tr"), 2);
			if(firstRow==null)
			{
				Report.Info($"The first row element was null");
					return null;
			}
			var nameEl = firstRow.FindElement(By.XPath("//td[@data-bind='text:ReportName']"), 2);
			return nameEl.Text;

		}

		public string ReportHistroryLatestReportFileType()
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			var firstRow = tableEl.FindElement(By.XPath("//tr"), 2);
			if (firstRow == null)
			{
				Report.Info($"The first row element was null");
				return null;
			}
			var typeEl = firstRow.FindElement(By.XPath("//td[@data-bind='text:FileType']"), 2);
			return typeEl.Text;

		}

		public string ReportHistroryLatestReportFileColumnData(string column)
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			var firstRow = tableEl.FindElement(By.XPath("//tr"), 2);
			if (firstRow == null)
			{
				Report.Info($"The first row element was null");
				return null;
			}
			var dataEl = firstRow.FindElement(By.XPath($"//td[@data-bind='text:{column}']"), 2);
			return dataEl.Text;

		}

		public bool ReportHistroryLatestReportFileActionsColumnContainsButton(string buttonName)
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			var firstRow = tableEl.FindElement(By.XPath("//tr"), 2);
			if (firstRow == null)
			{
				Report.Info($"The first row element was null");
				return false;
			}
			var actionsEl = firstRow.FindElement(By.XPath($"//td[.//button]"), 2);
			var wantedButtonEl = actionsEl.FindElement(By.XPath($"//button[text()='{buttonName}']"), 2);

			return wantedButtonEl != null;

		}

		public bool ReportHistroryLatestReportFileActionsColumnClickButton(string buttonName)
		{
			var tableEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table"), 15);
			var firstRow = tableEl.FindElement(By.XPath("//tr"), 2);
			if (firstRow == null)
			{
				Report.Info($"The first row element was null");
				return false;
			}
			var actionsEl = firstRow.FindElement(By.XPath($"//td[.//button]"), 2);
			var wantedButtonEl = actionsEl.FindElement(By.XPath($"//button[text()='{buttonName}']"), 2);
			if(wantedButtonEl==null)
			{
				Report.Info($"The wanted button element was not found");
				return false;
			}
			return wantedButtonEl.TryClick();

		}

		/// <summary>
		/// direction should only be ascending or descending
		/// </summary>
		/// <param name="column"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		public bool ReportHistroryTableFilterByColumn(string column, string direction)
		{
			string wantedID = "";
			switch (direction)
			{
				case "ascending":
					wantedID = "_asc";
					break;
				case "descending":
					wantedID = "_desc";
					break;
				default:
					Report.Error(" variable must be either 'ascending' or 'descending'!");
					return false;
					
			}

			var tableHeaderEl = this.containerElement.FindElement(By.XPath("//div[@id='ReportHistoryTable']//table//thead"), 15);

			if (tableHeaderEl == null)
			{
				Report.Info("TableHeaderEl returned null");
				return false;
			}

			var wantedTitleMasterEl = tableHeaderEl.FindElement(By.XPath($"//th[contains(@data-bind,'{column}')]"), 15);
			var directionTitleEl = tableHeaderEl.FindElement(By.XPath($"//span[@id='{column}{wantedID}']"), 15);

			if (wantedTitleMasterEl == null)
			{
				Report.Info("WantedTitleMasterEl returned null");
				return false;
			}

			if (directionTitleEl == null)
			{
				Report.Info("DirectionTitleEl returned null");
				return false;
			}

			if (directionTitleEl.GetAttribute("style") == "display: none;")
			{
				int x = 0;
				directionTitleEl = tableHeaderEl.FindElement(By.XPath($"//span[@id='{column}{wantedID}']"), 15);
				bool correctDirection = directionTitleEl.GetAttribute("style") != "display: none;";
				while (x < 5 && correctDirection==false)
				{
					wantedTitleMasterEl.TryClick();
					correctDirection = directionTitleEl.GetAttribute("style") != "display: none;";
					GeneralUtilities.Wait_for_load_finish();
					Delay.Seconds(2);
					GeneralUtilities.Wait_for_load_finish();
					//int y = 0;
					//bool loadingActive = GeneralUtilities.Loading_Active();
					//while (y<10 && !GeneralUtilities.Wait_for_load_finish())
					//{
					//	Delay.Seconds(2);
					//	y++;
					//}

					//Delay.Seconds(8);
					x++;
				}
				
			}

			directionTitleEl = tableHeaderEl.FindElement(By.XPath($"//span[@id='{column}{wantedID}']"), 15);
			return directionTitleEl.GetAttribute("style") != "display: none;";

		}

		public string GetCurrentDescriptionText()
		{
			string descriptionText = this.containerElement.FindElement(By.XPath(".//p[@data-bind='text: Description']"))?.Text;
			return descriptionText;
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

		public bool SelectZipReportCheckbox()
		{
			IWebElement checkbox = this.ContainerElement.FindElement(By.XPath("//input[@id='chkZip']"), 2);
			return checkbox.TryCheck();
		}

		public bool SelectRequestReportButton()
		{
			IWebElement button = this.ContainerElement.FindElement(By.XPath("//button[text()='Request Report']"), 2);
			return button.TryClick();
		}

		public bool SelectCloseButtonInReportDownloadPopup()
		{
			IWebElement button = this.ContainerElement.FindElement(By.XPath("//a[@data-dismiss='modal']"), 2);
			return button.TryClick();
		}

		public bool CheckForDownloadButtonForTheMostRecentReport()
		{
			Report.Info("Check for download button for report with the following time: " + Context.GetFromContext("LastReportDownloadTime").ToString());
			IWebElement downloadButton = this.ContainerElement.FindElement(By.XPath("//div[@class='pull-right col-xs-9']//tbody//tr//td[@data-bind='text:DateRequested'][contains(text(),'" + Context.GetFromContext("LastReportDownloadTime").ToString() + "')]/..//button"), 2);
			if (downloadButton != null)
			{
				return true;
			}
			return false;
		}

		public bool SelectDownloadButtonForTheMostRecentReport()
		{
			Report.Info("Downloading report with the following time: " + Context.GetFromContext("LastReportDownloadTime").ToString());
			IWebElement downloadButton = this.ContainerElement.FindElement(By.XPath("//div[@class='pull-right col-xs-9']//tbody//tr//td[@data-bind='text:DateRequested'][contains(text(),'" + Context.GetFromContext("LastReportDownloadTime").ToString() + "')]/..//button"), 2);
			return downloadButton.TryClick();
		}

		public bool CheckReportDataForMostRecentFile(string reportName, string type, string dateRequested, string requestedBy)
		{
			Delay.Seconds(10);
			IList<IWebElement> fileList = this.ContainerElement.FindElements(By.XPath("//div[@class='pull-right col-xs-9']//tbody//tr//td[@data-bind='text:DateRequested'][contains(text(),'" + Context.GetFromContext("LastReportDownloadTime").ToString() + "')]/..//td"), 2);
			string reportNameStr = fileList[0].Text;
			string reportTypeStr = fileList[2].Text;
			string reportDateRequestedStr = fileList[3].Text;
			string reportRequestedByStr = fileList[4].Text;

			if (reportNameStr == reportName && reportTypeStr == type && reportDateRequestedStr.Contains(Context.GetFromContext(dateRequested).ToString()) && reportRequestedByStr == requestedBy)
			{
				return true;
			}

			if (reportNameStr != reportName)
			{ 
				Report.Failure("Failed to match Report Name");
			}
			if (reportTypeStr != type)
			{
				Report.Failure("Failed to match Type");
			}
			if (!reportDateRequestedStr.Contains(Context.GetFromContext("LastReportDownloadTime").ToString()))
			{
				Report.Failure("Failed to match Date Requested");
			}
			if (reportRequestedByStr != requestedBy)
			{
				Report.Failure("Failed to match Requested By");
			}

			return false;
		}

		public bool FindReportDownloadPopupWithTheFollowingText(string text)
		{
			IWebElement textEl = this.ContainerElement.FindElement(By.XPath("//h3[text()='Report Download']/../following-sibling::div//div[@id='report-success-message']//p"), 2);

			if (textEl.Text == text)
			{
				return true;
			}

			return false;
		}

	}
}

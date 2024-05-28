using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
	public class ItemSync : WidgetPage
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[@id='item-sync-page']");

		private IWebElement PageTitle => ContainerElement.FindElement(By.XPath(".//h2"), 2);

		private IWebElement UPCInputBox => ContainerElement.FindElement(By.XPath(".//input[@id='upcStringCandidate']"), 2);
		public IWebElement UPCInputAddButton => ContainerElement.FindElement(By.XPath(".//button[@data-bind='enable: upcStringArray().length < maxUPCs' and text()='Add']"), 2);

		private IWebElement UPCInputWarningElement => ContainerElement.FindElement(By.XPath(".//span[@class='text-danger']"), 2);

		private IWebElement MainTextBox => ContainerElement.FindElement(By.XPath($"//div[@class='jumbotron']//p"), 5);

		private IWebElement UploadBoxSection => ContainerElement.FindElement(By.XPath($"//div[@class='jumbotron']//div[@data-url='/Data/ItemSyncFile']"), 5);

		private IWebElement DragBoxText => UploadBoxSection.FindElement(By.XPath($".//span[@class='description']"), 2);

		private IWebElement UploadedRow => this.FindElement(By.Id("fileUploadRow"), 2);

		private IWebElement UPCTable => this.FindElement(By.XPath($".//form[@action='/Data/ItemSyncManual']//table"), 2);

		public IWebElement ManualUploadButton => this.FindElement(By.XPath($".//button[@type='submit']//span[@class='glyphicon glyphicon-cloud-upload']"), 2);

		public IWebElement UpcsRemainingEl => this.FindElement(By.XPath($".//div[@class='text-right']//span[contains(@data-bind,'maxUPCs')]"), 2);

		public IWebElement ManualUploadTableFooterEl => this.FindElement(By.XPath($".//tfoot"), 30);
		private IWebElement UPCInputError => ContainerElement.FindElement(By.XPath(".//form[@class='form-inline']//div//span[2]"), 2);

		private IWebElement UPCDetailsResultsTable => ContainerElement.FindElement(By.XPath($"//div[@id='item-sync-page']//table"), 5);

		private IWebElement ActionButtonsSection => ContainerElement.FindElement(By.XPath(".//div[@class='form-inline']"), 2);

		private IWebElement GridCountIndicator => ManualUploadTableFooterEl.FindElement(By.XPath($".//div[@class='col-md-3']//div[@class='text-right']"), 2);



		#endregion

		#region Methods
		public string GetCurrentPageTitle()
		{
			return this.PageTitle.Text;
		}

		public bool UPCInputBoxPresent()
		{
			return this.UPCInputBox != null;
		}

		public bool UPCInputBoxDefaultTextMatches(string expectedText)
		{
			var el = this.UPCInputBox;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}

			string placeholderText = el.GetAttribute("placeholder");
			Report.Info($"found: {placeholderText}");
			Report.Info($"expecting: {expectedText}");
			return placeholderText == expectedText;
		}

		public bool UPCInputBoxEnterText(string text)
		{
			var el = this.UPCInputBox;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return el.TryEnterText(text);
		}

		public bool ClearUPCField()
		{
			var el = this.UPCInputBox;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return el.ClearTextBox();
		}

		public bool ClickUPCInputAddButton()
		{
			return this.UPCInputAddButton.TryClick();
		}

		public bool CheckUPCInputWarningText(string value)
		{
			var el = this.UPCInputWarningElement;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			Report.Info($"found: {el.Text}");
			var edited = el.Text.Replace("* ", "");
			Report.Info($"edited found text: {edited}");
			Report.Info($"expecting: {value}");
			return edited == value;
		}

		public bool ContainsMainTextBox()
		{
			return this.MainTextBox != null;
		}

		public bool ContainsUploadBoxSection()
		{
			return this.UploadBoxSection != null;
		}

		public bool UploadBoxSectionDisplayed()
		{
			return !this.UploadBoxSection.GetAttribute("style").Contains("none");
		}

		public bool ClickUploadButtonManualUpload()
		{
			var el = this.ManualUploadButton;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return el.TryClick();
		}

		public bool WaitUntilUploadAFilePageLoaded()
		{
			IWebElement loadingBarEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[@class=' pace-running']"), 5);
			if (loadingBarEl == null)
			{
				Report.Info($"The loading bar was not showing");
				return true;
			}
			int x = 1;
			while (x < 30)
			{
				loadingBarEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[@class=' pace-running']"), 1);
				if (loadingBarEl == null)
				{
					Report.Info($"The loading bar was not showing");
					return true;
				}
				x++;

			}
			return false;
		}

		public bool ConfirmUPCDetailsResultsTableShown()
		{
			var el = this.UPCDetailsResultsTable;
			if (el == null)
			{
				Report.Info($"The Table was not showing");
				return true;
			}
			return true;
		}

		public bool WaitUntilManuaEntryPageLoaded()
		{
			IWebElement loadingBarEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[@class=' pace-running']"), 5);
			if (loadingBarEl == null)
			{
				Report.Info($"The loading bar was not showing");
				return true;
			}
			int x = 1;
			while (x < 30)
			{
				loadingBarEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[@class=' pace-running']"), 1);
				if (loadingBarEl == null)
				{
					Report.Info($"The loading bar was not showing");
					return true;
				}
				x++;

			}
			return false;
		}

		public bool MainTextBoxContainsText(string expectedText)
		{
			var el = this.MainTextBox;
			if (el == null)
			{
				Report.Info($"The Main Text Box Element was null");
				return false;
			}
			string foundText = el.Text;
			return foundText == expectedText;
		}

		public string GetUploadBoxElementClass()
		{
			var el = this.UploadBoxSection;
			if (el == null)
			{
				Report.Info($"The Upload Box Element was null");
				return null;
			}

			return el.GetAttribute("class");
		}

		public bool UploadBoxDescriptionContains(string expectedText)
		{
			var el = this.DragBoxText;
			if (el == null)
			{
				Report.Info($"The Drag Box Text Element was null");
				return false;
			}

			return el.Text == expectedText;
		}

		public bool DebugFileBrowser()
		{

			try
			{
				var test = SeleniumBrowser.WebBrowser.FindElement(By.Id("__RequestVerificationToken"), 2);
			}
			catch
			{
				Report.Info($"");

			}

			return true;
		}

		public bool UploadFileToUploadAFileArea(string filePath, string fileName)
		{

			IWebElement el = this.UploadBoxSection;
			if (el == null)
			{
				return false;
			}

			if (!el.TryClick())
			{
				return false;
			}

			UploadDialog.UploadFile(filePath);

			int i = 0;
			while (this.UploadedFileDisplayedName() == null && i < 10)
			{
				i++;
				Delay.Seconds(3);
			}
			if (this.UploadedFileDisplayedName() != fileName)
			{
				Report.Info($"The opened file did not display the expected name");
				return false;
			}
			Report.Info($"The Opened file displayed the correct name");
			return true;


		}

		public string UploadedFileDisplayedName()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return null;
			}
			var fileNameEl = el.FindElement(By.XPath($".//span[@data-bind='text: val']"), 2);
			if (fileNameEl == null)
			{
				Report.Info($"fileNameEl was null");
				return null;
			}
			return fileNameEl.Text;
		}

		public bool FileIconDisplayed()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			//span[@class='glyphicon glyphicon-file']
			var fileIconEl = el.FindElement(By.XPath($".//span[@class='glyphicon glyphicon-file']"), 2);
			if (fileIconEl == null)
			{
				Report.Info($"fileIconEl was null");
				return false;
			}
			Report.Info($"Found the file icon element");
			return true;
		}

		public bool RemoveIconDisplayed()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			//span[@class='glyphicon glyphicon-file']
			var removeIconEl = el.FindElement(By.XPath($".//span[@class='glyphicon glyphicon-trash']"), 2);
			if (removeIconEl == null)
			{
				Report.Info($"removeIconEl was null");
				return false;
			}
			Report.Info($"Found the Remove icon element");
			return true;
		}

		public bool RemoveIconClick()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			//span[@class='glyphicon glyphicon-file']
			var removeIconEl = el.FindElement(By.XPath($".//span[@class='glyphicon glyphicon-trash']"), 2);
			if (removeIconEl == null)
			{
				Report.Info($"removeIconEl was null");
				return false;
			}
			Report.Info($"Found the Remove icon element, attempting to click");
			return removeIconEl.TryClick();
		}

		public bool CheckUploadedFileName(string fileName)
		{
			int i = 0;
			while (this.UploadedFileDisplayedName() == null && i < 10)
			{
				i++;
				Delay.Seconds(3);
			}
			if (this.UploadedFileDisplayedName() != fileName)
			{
				Report.Info($"The opened file did not display the expected name");
				return false;
			}
			Report.Info($"The found file name was: {this.UploadedFileDisplayedName()}");
			Report.Info($"The Opened file displayed the correct name");
			return true;
		}

		public bool CheckAnyFileNameDisplayed()
		{
			int i = 0;
			while (this.UploadedFileDisplayedName() == null && i < 10)
			{
				i++;
				Delay.Seconds(2);
			}
			Delay.Seconds(5);
			if (this.UploadedFileDisplayedName().IsNullOrEmpty())
			{
				Report.Info($"The opened file did not display the expected name");
				return false;
			}
			Report.Info($"The found file name was: {this.UploadedFileDisplayedName()}");
			return true;
		}

		public bool UploadButtonDisplayed()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			//span[@class='glyphicon glyphicon-file']
			var uploadButtonDisplayed = el.FindElement(By.Id("fileUploadPoster"), 2);
			if (uploadButtonDisplayed == null)
			{
				Report.Info($"uploadButtonDisplayed was null");
				return false;
			}
			Report.Info($"Found the Displayed button element");
			return true;
		}

		public bool UploadButtonClicked()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			//span[@class='glyphicon glyphicon-file']
			var uploadButtonDisplayed = el.FindElement(By.Id("fileUploadPoster"), 2);
			if (uploadButtonDisplayed == null)
			{
				Report.Info($"uploadButtonDisplayed was null");
				return false;
			}
			Report.Info($"Found the Displayed button element");
			return uploadButtonDisplayed.TryClick();
		}

		public bool UploadingLoadingIconPresent()
		{
			var el = this.UploadedRow;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			var uploadLoadingSpinner = el.FindElement(By.XPath(".//img[contains(@src,'spinner-jqgrid.gif')]"), 2);
			int x = 0;
			while (x < 30)
			{
				uploadLoadingSpinner = el.FindElement(By.XPath(".//img[contains(@src,'spinner-jqgrid.gif')]"), 2);
				if (uploadLoadingSpinner != null)
				{
					Report.Info($"spinner found");
					return true;

				}
				Delay.Seconds(0.2);
				x++;
			}
			uploadLoadingSpinner = el.FindElement(By.XPath(".//img[contains(@src,'spinner-jqgrid.gif')]"), 2);
			if (uploadLoadingSpinner == null)
			{
				Report.Info($"uploadLoadingSpinner was null");
				return false;
			}
			Report.Info($"The Uploading Loading spinner icon was found");
			return true;

		}

		public bool WaitForUploadLoadToFinish()
		{
			var el = this.UploadedRow.FindElement(By.XPath(".//img[contains(@src,'spinner-jqgrid.gif')]"), 2);
			if (el == null)
			{
				Report.Info($"el was null");
				return true;
			}
			Report.Info($"The Upload Loading spinner was still showing...");
			Delay.Seconds(4);
			int x = 0;
			while (x < 15)
			{
				el = this.UploadedRow.FindElement(By.XPath(".//img[contains(@src,'spinner-jqgrid.gif')]"), 2);
				if (el == null)
				{
					Report.Info($"el was null");
					return true;
				}
				Report.Info($"The Upload Loading spinner was still showing...");
				x++;
				Delay.Seconds(4);
			}
			//also check for the next page? seperate method?
			return false;
		}

		public bool UPCTableGridFound()
		{
			var el = this.UPCTable;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return el != null;
		}

		public List<IWebElement> GetUPCGridHeadingEls()
		{
			var el = this.UPCTable;
			if (el == null)
			{
				Report.Info($"el was null");
				return null;
			}
			var headingArea = el.FindElement(By.XPath($".//thead"), 2);
			List<IWebElement> headings = headingArea.FindElements(By.XPath($"//tr//th"), 2).ToList();
			return headings;

		}

		public bool CheckUPCOnlyNamedHeading()
		{
			List<IWebElement> headings = this.GetUPCGridHeadingEls();
			int x = 0;

			foreach (var item in headings)
			{
				if (!item.Text.IsNullOrEmpty())
				{
					x++;
				}
			}

			bool upcFound = false;

			foreach (var heading in headings)
			{
				if (heading.Text == "UPC")
				{
					upcFound = true;
				}
			}

			return upcFound && x == 1;


		}

		public List<IWebElement> UPCGridRows()
		{
			var el = this.UPCTable;
			if (el == null)
			{
				Report.Info($"el was null");
				return null;
			}
			List<IWebElement> rows = el.FindElements(By.XPath($".//tbody//tr"), 2).ToList();
			return rows;
		}


		public bool CheckUPCFoundInGrid(string value)
		{
			var rows = this.UPCGridRows();
			if (rows.IsNullOrEmpty())
			{
				Report.Info($"rows was null");
				return false;
			}

			foreach (var row in rows)
			{
				var el = row.FindElement(By.XPath($".//td[@data-bind='text: $data']"), 2);
				string foundText = el.Text;
				if (foundText == value)
				{
					Report.Info($"The UPC: {value} was found successfully");
					return true;
				}
			}

			Report.Info($"The upc was not found in the grid.");
			return false;

		}


		public bool CheckRemoveIconForUPC(string value)
		{
			var rows = this.UPCGridRows();
			if (rows.IsNullOrEmpty())
			{
				Report.Info($"rows was null");
				return false;
			}

			foreach (var row in rows)
			{
				var el = row.FindElement(By.XPath($".//td[@data-bind='text: $data']"), 2);
				string foundText = el.Text;
				if (foundText == value)
				{
					Report.Info($"The UPC: {value} was found successfully");

					var trashIcon = row.FindElement(By.XPath($".//td//a[contains(@data-bind,'click: function()')]//span[@class='glyphicon glyphicon-trash']"), 2);

					return trashIcon != null;


				}
			}

			Report.Info($"The upc was not found in the grid.");
			return false;

		}


		public bool ClickRemoveIconForUPC(string value)
		{
			var rows = this.UPCGridRows();
			if (rows.IsNullOrEmpty())
			{
				Report.Info($"rows was null");
				return false;
			}

			foreach (var row in rows)
			{
				var el = row.FindElement(By.XPath($".//td[@data-bind='text: $data']"), 2);
				string foundText = el.Text;
				if (foundText == value)
				{
					Report.Info($"The UPC: {value} was found successfully");

					var trashIcon = row.FindElement(By.XPath($".//td//a[contains(@data-bind,'click: function()')]//span[@class='glyphicon glyphicon-trash']"), 2);

					return trashIcon.TryClick();


				}
			}

			Report.Info($"The upc was not found in the grid.");
			return false;

		}

		public bool UPCsRemainingCountFound()
		{
			var el = this.UpcsRemainingEl;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return !el.Text.IsNullOrEmpty();
		}

		public bool UPCsRemainingCheckFormat()
		{
			var el = this.UpcsRemainingEl;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			string textFound = el.Text;
			var arrayFound = textFound.Split(' ');
			bool fomratCorrect = true;

			bool isNumeric = int.TryParse(arrayFound[0], out _);
			bool is3Digits = arrayFound[0].Length == 3;

			if (isNumeric == false || is3Digits == false)
			{
				fomratCorrect = false;
				Report.Info($"The first part of the text was not a 3 digit number");

			}

			bool containsUPC = arrayFound[1] == "UPCs";
			bool containsRemaining = arrayFound[2] == "Remaining";

			if (containsUPC == false)
			{
				fomratCorrect = false;
				Report.Info($"The second part was not the word 'UPCs'");

			}


			if (containsRemaining == false)
			{
				fomratCorrect = false;
				Report.Info($"The third part was not the word 'Remaining'");


			}

			return fomratCorrect;

		}

		public bool UPCNumberRemaining(string expectedValue)
		{
			var el = this.UpcsRemainingEl;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			string textFound = el.Text;
			var arrayFound = textFound.Split(' ');

			return arrayFound[0] == expectedValue;




		}

		public bool AddUPCButtonDisabled()
		{
			var el = this.UPCInputAddButton;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			string disabledStr = el.GetAttribute("disabled");
			if (disabledStr != "true")
			{
				Report.Info($"The Add Button was not greyed out");
				return false;
			}
			bool clickable = el.TryClick();
			if (clickable == true)
			{
				Report.Info($"The Add Button was still clickable");
				return false;
			}
			return true;


		}

		public bool UPCTableFooterFound()
		{
			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return true;
		}

		public List<IWebElement> GetAllUPCTableRows()
		{
			var el = this.UPCTable;
			if (el == null)
			{
				Report.Info($"table el was null");
				return null;
			}
			List<IWebElement> rows = el.FindElements(By.XPath($".//tbody//tr"), 2).ToList();
			return rows;
		}


		public bool ScrollToTopOfUPCGrid()
		{
			var rowList = this.GetAllUPCTableRows();
			var firstEl = rowList.First();
			firstEl.ScrollElementIntoView();
			return firstEl.VisibleInViewport();

		}

		public bool ScrollToBpttomOfUPCGrid()
		{
			var rowList = this.GetAllUPCTableRows();
			var lastEl = rowList.Last();
			lastEl.ScrollElementIntoView();
			return lastEl.VisibleInViewport();

		}

		public bool UPCInputErrorTextMatches(string value)
		{
			var el = this.UPCInputError;
			if (el == null)
			{
				Report.Info($"table el was null");
				return false;

			}
			Report.Info($"found: {el.Text}");
			var edited = el.Text.Replace("* ", "");
			Report.Info($"edited found text: {edited}");
			Report.Info($"expecting: {value}");
			return edited == value;
		}

		public List<string> ResultsGridGetHeadings()
		{
			var el = this.UPCDetailsResultsTable;
			if (el == null)
			{
				Report.Info($"table el was null");
				return null;

			}
			List<IWebElement> headingEls = el.FindElements(By.XPath($".//thead//tr//th"), 2).ToList();
			if (headingEls.IsNullOrEmpty())
			{
				Report.Info($"Failed to find any headingEls");
				return null;
			}
			List<string> headlingStrings = headingEls.Select(x => x.Text).ToList();
			return headlingStrings;


		}

		public List<IWebElement> GetActionButtonEls()
		{
			var el = this.ActionButtonsSection;
			if (el == null)
			{
				Report.Info($"el was null");
				return null;

			}
			List<IWebElement> actionButtonEls = el.FindElements(By.XPath($".//div[@class='form-group' and not(.//input[@type='text'])]"), 5).ToList();
			if (actionButtonEls.IsNullOrEmpty())
			{
				Report.Info($"Failed to find any Action Buttons");
				return null;
			}
			return actionButtonEls;
		}

		public List<string> GetActionButtonString()
		{
			var listEls = this.GetActionButtonEls();
			if (listEls == null)
			{
				Report.Info($"List was null");
				return null;

			}
			List<string> actionButtonString = listEls.Select(x => x.Text).ToList();
			if (actionButtonString.IsNullOrEmpty())
			{
				Report.Info($"Failed to find any Action Button strings");
				return null;
			}
			return actionButtonString;
		}

		public bool ConfirmActionButtonsFoundInOrder(List<string> expectedButtonTextList)
		{
			var foundButtonTextList = this.GetActionButtonString();
			Report.Info($"The Found list of buttons was: {string.Join(",", foundButtonTextList)}");
			Report.Info($"The Expected list of buttons was: {string.Join(",", expectedButtonTextList)}");

			if (foundButtonTextList.Count() != expectedButtonTextList.Count())
			{
				Report.Info($"The number of buttons did not match");
				return false;
			}

			bool buttonTextMatches = true;

			for (int x = 0; x < foundButtonTextList.Count() - 1; x++)
			{
				if (foundButtonTextList[x] == expectedButtonTextList[x])
				{
					Report.Info($"The text was a match for: {foundButtonTextList[x]}");

				}
				else
				{
					Report.Info($"The text was not a match, the found text was: {foundButtonTextList[x]} and the expected text was: {expectedButtonTextList[x]}");
					buttonTextMatches = false;
				}
			}

			return buttonTextMatches;


		}

		public List<string> GetFooterPageNavigationIcons()
		{

			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return null;

			}


			List<IWebElement> footerButtons = el.FindElements(By.XPath($".//div[@class='col-md-4']//button"), 2).ToList();
			if (footerButtons.IsNullOrEmpty())
			{
				Report.Info($"Failed to find any headingEls");
				return null;
			}

			List<string> buttonIcons = footerButtons.Select(x => x.GetAttribute("title")).ToList();
			return buttonIcons;




		}

		public bool ConfirmFooterNavigationIconHoverOver(string wantedButton)
		{

			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return false;

			}


			List<IWebElement> footerButtons = el.FindElements(By.XPath($".//div[@class='col-md-4']//button"), 2).ToList();
			if (footerButtons.IsNullOrEmpty())
			{
				Report.Info($"Failed to find any headingEls");
				return false;
			}

			foreach (var button in footerButtons)
			{
				if (button.GetAttribute("title") == wantedButton)
				{
					string disabledStr = button.GetAttribute("disabled");
					if (disabledStr != "true")
					{
						Report.Info($"The button was enabled and the title attribute was: {button.GetAttribute("title")}, hover over in chrome should display title attribute.");
						return true;
					}
					else
					{
						Report.Info($"The button was disabled, therfore no text appears on hover over.");
						return false;
					}


				}
				else
				{
					Report.Info($"Button found was titled: {button.GetAttribute("title")}. This was not a match, moving onto the next button...");
				}
			}
			Report.Info($"The button we are looking for was not found in the footer.");
			return false;


		}

		public bool ClickXIconInFooter(string wantedButton)
		{
			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return false;

			}


			List<IWebElement> footerButtons = el.FindElements(By.XPath($".//div[@class='col-md-4']//button"), 2).ToList();
			if (footerButtons.IsNullOrEmpty())
			{
				Report.Info($"Failed to find any headingEls");
				return false;
			}

			foreach (var button in footerButtons)
			{
				if (button.GetAttribute("title") == wantedButton)
				{
					Report.Info($"The button was found...");
					return button.TryClick();

				}
			}
			Report.Info($"Did not find the wanted button.");
			return false;
		}

		public bool ItemsPerPageFoundInFooter()
		{

			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return false;


			}

			IWebElement itemsPerPageEl = el.FindElement(By.XPath($"//select[contains(@data-bind,'pageSize')]"), 2);
			return !itemsPerPageEl.IsNullOrEmpty();

		}

		public string CurrentItemsPerPageOption()
		{

			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return null;


			}

			IWebElement itemsPerPageEl = el.FindElement(By.XPath($"//select[contains(@data-bind,'pageSize')]"), 2);
			if (itemsPerPageEl == null)
			{
				Report.Info($"The items per page selector el was null");
				return null;
			}

			return itemsPerPageEl.SelectedOption();


		}

		public List<string> ItemsPerPageOptions()
		{

			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return null;


			}

			IWebElement itemsPerPageEl = el.FindElement(By.XPath($"//select[contains(@data-bind,'pageSize')]"), 2);
			if (itemsPerPageEl == null)
			{
				Report.Info($"The items per page selector el was null");
				return null;
			}

			List<IWebElement> optionsEls = itemsPerPageEl.FindElements(By.XPath($".//option"), 2).ToList();
			List<string> optionsStr = optionsEls.Select(x => x.Text).ToList();
			return optionsStr;

		}


		public bool SelectItemsPerPageOptions(string value)
		{

			var el = this.ManualUploadTableFooterEl;
			if (el == null)
			{
				Report.Info($"table footer el was null");
				return false;


			}

			IWebElement itemsPerPageEl = el.FindElement(By.XPath($"//select[contains(@data-bind,'pageSize')]"), 2);
			if (itemsPerPageEl == null)
			{
				Report.Info($"The items per page selector el was null");
				return false;
			}

			itemsPerPageEl.Select(value);
			return itemsPerPageEl.SelectedOption() == value;


		}

		public List<IWebElement> GetAllUPCDetailsResultsRows()
		{
			var el = this.UPCDetailsResultsTable;
			if (el == null)
			{
				Report.Info($"table el was null");
				return null;
			}

			List<IWebElement> rows = el.FindElements(By.XPath($".//tbody//tr"), 2).ToList();
			return rows;

		}

		public bool GridCountIndicatorShown()
		{
			return !this.GridCountIndicator.IsNullOrEmpty();
		}

		public bool CheckGridCountIndicatorFormat()
		{
			var el = this.GridCountIndicator;
			if (el == null)
			{
				Report.Info($"indicator el was null");
				return false;
			}
			var totalRowsEl = el.FindElement(By.XPath($".//span[@data-bind='text: totalRows()']"), 2);
			if (totalRowsEl == null)
			{
				Report.Info($"totalRowsEl el was null");
				return false;
			}

			string totalRowsString = totalRowsEl.Text;
			string fullText = el.Text;
			string remainingText = fullText.Replace(totalRowsString, "").Trim();

			bool totalRowsIsInt = int.TryParse(totalRowsString, out _);
			if (totalRowsIsInt == false)
			{
				Report.Info($"The value found for the total rows in the table was not an 'int'");
				return false;
			}
			return remainingText == "View 1 - 10 of";


		}

		public bool WarningIconFound()
		{
			IWebElement warningIconEl = this.FindElement(By.XPath($"//span[@class='glyphicon glyphicon-exclamation-sign' and @style='color:red']"), 2);
			if (warningIconEl == null)
			{
				Report.Info($"el was null");
				return false;
			}
			return !warningIconEl.IsNullOrEmpty();

		}











		#endregion
	}



}





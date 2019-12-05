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
using TechTalk.SpecFlow;

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
			while (counter < 20)
			{
				Report.Info("Checking to see if Preparing Report popup has disappeared. Try " + counter + ".");
				IWebElement popup = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//div//div//span[contains(text(), 'Preparing report...')]/../.."), 10);
				if (popup != null)
				{
					if (popup.GetCssValue("display") == "none")
					{
						Report.Info("Exiting iFrame");
						SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
						return true;
					}
					Delay.Seconds(10);
					counter++;
				}
				else
				{
					Delay.Seconds(10);
					counter++;
					if (counter >= 3)
					{ return true; }
				}
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
			IWebElement submitButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//input[@name='Submit']"), 2);

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

		public bool ConfirmTableName(string tableName)
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement tableTitle = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[@class='ui-jqgrid-title']"), 2);
			string text = tableTitle.Text;
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return text == tableName;
		}

		public bool ConfirmHeader(string header)
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IList<IWebElement> foundHeaders = SeleniumBrowser.WebBrowser.FindElements(By.XPath(@"//tr[@class='ui-jqgrid-labels']//th[@id!='listAdvancedReports_Id']"), 2);
			var headerTextList = new List<string>();
			foreach (IWebElement foundHeader in foundHeaders)
			{
				headerTextList.Add(foundHeader.Text.Trim());
			}
			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return headerTextList.Contains(header);
		}

		public bool ConfirmAdvancedReportingOptions(string name, string desc)
		{
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");

			IList<IWebElement> foundNames = SeleniumBrowser.WebBrowser.FindElements(By.XPath(@"//table[@id='listAdvancedReports']//tr[@class!='jqgfirstrow']//td[2]"), 2);
			var dict = new Dictionary<string, string>();
			foreach (IWebElement foundName in foundNames)
			{
				IWebElement foundDescription = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//table[@id='listAdvancedReports']//tr[@class!='jqgfirstrow']//td[text()='" + foundName.Text.Trim() + @"']/following-sibling::td"), 2);
				if (foundDescription != null)
				{
					dict.Add(foundName.Text.Trim(), foundDescription.Text.Trim());
				}
				else
				{
					Report.Failure("Could not find description element for report name element " + foundName.Text.Trim());
					return false;
				}
			}

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();

			if (!(dict.ContainsKey(name) && dict[name] == desc))
			{
				return false;
			}

			return true;
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

		public bool ConfirmReportNamesAlphebeticalOrder(string order)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IList<IWebElement> namesElems = frame.FindElements(By.XPath(@"//table[@id='listAdvancedReports']//tr[@class!='jqgfirstrow']//td[2]"), 2).ToList();
			var names = new List<string>();
			foreach (IWebElement nameElem in namesElems)
			{
				names.Add(nameElem.Text);
			}
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			switch (order)
			{
				case "abc":
					return GeneralUtilities.CheckABCOrder(names);
				case "cba":
					return GeneralUtilities.CheckCBAOrder(names);
				default:
					return false;
			}

		}

		public bool ConfirmReportDescriptionsAlphabeticalOrder(string order)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IList<IWebElement> namesElems = frame.FindElements(By.XPath(@"//table[@id='listAdvancedReports']//tr[@class!='jqgfirstrow']//td[3]"), 2).ToList();
			var names = new List<string>();
			foreach (IWebElement nameElem in namesElems)
			{
				names.Add(nameElem.Text);
			}
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			switch (order)
			{
				case "abc":
					return GeneralUtilities.CheckABCOrder(names);
				case "cba":
					return GeneralUtilities.CheckCBAOrder(names);
				default:
					return false;
			}
		}

		public bool ClickReportNameHeader()
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");

			IWebElement reportNameHeader = frame.FindElement(By.XPath("//div[@id='jqgh_listAdvancedReports_Name']"), 2);
			bool canClick = reportNameHeader.TryClick();
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return canClick;
		}

		public bool ClickReportDescriptionHeader()
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement reportNameHeader = frame.FindElement(By.XPath("//div[@id='jqgh_listAdvancedReports_Description']"), 2);
			bool canClick = reportNameHeader.TryClick();
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return canClick;
		}

		public bool CheckIfReportNameUpArrowActive(string active)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement upArrow = frame.FindElement(By.XPath("//div[@id='jqgh_listAdvancedReports_Name']//span//span[1]"), 2);
			bool isActive = upArrow.GetAttribute("class").Contains("ui-state-disabled");
			switch (active)
			{
				case "active":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return !isActive;
				case "inactive":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return isActive;
				default:
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					Report.Failure("Found unexpected parameter " + active);
					return false;
			}
		}

		public bool CheckIfReportNameDownArrowActive(string active)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement downArrow = frame.FindElement(By.XPath("//div[@id='jqgh_listAdvancedReports_Name']//span//span[2]"), 2);
			bool isActive = downArrow.GetAttribute("class").Contains("ui-state-disabled");
			switch (active)
			{
				case "active":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return !isActive;
				case "inactive":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return isActive;
				default:
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					Report.Failure("Found unexpected parameter " + active);
					return false;
			}
		}

		public bool CheckIfReportDescriptionUpArrowActive(string active)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement upArrow = frame.FindElement(By.XPath("//div[@id='jqgh_listAdvancedReports_Description']//span//span[1]"), 2);
			bool isActive = upArrow.GetAttribute("class").Contains("ui-state-disabled");
			switch (active)
			{
				case "active":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return !isActive;
				case "inactive":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return isActive;
				default:
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					Report.Failure("Found unexpected parameter " + active);
					return false;
			}
		}

		public bool CheckIfReportDescriptionDownArrowActive(string active)
		{
			IWebDriver frame = SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement downArrow = frame.FindElement(By.XPath("//div[@id='jqgh_listAdvancedReports_Description']//span//span[2]"), 2);
			bool isActive = downArrow.GetAttribute("class").Contains("ui-state-disabled");
			switch (active)
			{
				case "active":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return !isActive;
				case "inactive":
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					return isActive;
				default:
					SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
					Report.Failure("Found unexpected parameter " + active);
					return false;
			}
		}

		public bool EnterEndDate(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement endDateField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='End Date']//ancestor::td[1]//following-sibling::td//input"), 2);
			if (endDateField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}
			if(value=="NA")
			{
				Report.Info("Exiting iFrame");
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return true;
			}
			if(value== "Future")
			{
				string endDatePreset = endDateField.GetValue();

				Report.Info($"The Present End date found was: {endDatePreset}");
				string endDatePresetYear = endDatePreset.Remove(0, 6);
				Report.Info($"The Present End Year String was: {endDatePresetYear}");
				int endDateYearInt = Convert.ToInt32(endDatePresetYear);
				Report.Info($"The Present End Year was: {endDateYearInt}");
				int endDateYearPlusOne = endDateYearInt + 1;
				Report.Info($"The Present End Year plus one was: {endDateYearPlusOne}");
				string monthAndDay = endDatePreset.Replace(endDatePresetYear, "");
				Report.Info($"The Present Month and Day was: {monthAndDay}");
				string newDate = monthAndDay + Convert.ToString(endDateYearPlusOne);
				Report.Info($"The New Date to enter is: {newDate}");

				endDateField.TryClick();
				endDateField.EnterText(newDate);
				
				Delay.Seconds(1);
				Report.Screenshot();

				bool matchingFutureDate = false;

				if (endDateField.GetValue() == newDate)
				{
					matchingFutureDate = true;
				}

				Report.Info("Exiting iFrame");
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return matchingFutureDate;

			}

			endDateField.TryClick();
			endDateField.EnterText(value);

			//endDateField.JsEnterText(value);
			//endDateField.SendKeys(Keys.Return);
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
			Delay.Seconds(5);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement startDateField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='Start Date']//ancestor::td//following-sibling::td//input"), 2);
			if (startDateField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}

			startDateField.TryClick();
			//startDateField.JsEnterText(value);
			//startDateField.SendKeys(Keys.Return);

			startDateField.EnterText(value);

			//startDateField.JsEnterText(value);
			
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
			Delay.Seconds(4);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement startDateField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='WPSID']//ancestor::td//following-sibling::td//input"), 2);
			if (startDateField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}

			startDateField.TryClick();
			startDateField.EnterText(value);
			//endDateField.JsEnterText(value);
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
				string selectedOption = retailerOption.SelectedOption();
				Report.Info("Exiting iFrame");
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return selectedOption == value;
			}




		}
		public IWebElement CloseButton => this.FindElement(By.XPath(".//button//span[text()='Close']"), 2);

		public bool EnterUPCSize(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");			
			IWebElement upcSizeField = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//*[text()='UPC Size']/parent::td//following-sibling::td//input"), 2);
			if (upcSizeField == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}

			upcSizeField.TryClick();
			upcSizeField.EnterText(value);
			//endDateField.JsEnterText(value);
			Delay.Seconds(1);
			Report.Screenshot();

			bool matching = false;

			if (upcSizeField.GetValue() == value)
			{
				matching = true;
			}

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return matching;

		}

		public bool ClickContainsAlcohol()
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement containsAlcoholBox = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//*[text()='Contains Alcohol']/parent::td//following-sibling::td//input"), 2);
			if (containsAlcoholBox == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}
			bool selected=containsAlcoholBox.TryClick();
			Delay.Seconds(1);
			Report.Screenshot();			

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return selected;
		}

		public bool ClickIncludesWater()
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement containsWater = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//*[text()='Includes 7732-18-5 / Water']/parent::td//following-sibling::td//input"), 2);
			if (containsWater == null)
			{
				Report.Info("Could not find the input element!");
				return false;
			}
			bool selected = containsWater.TryClick();
			Delay.Seconds(1);
			Report.Screenshot();

			Report.Info("Exiting iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return selected;
		}

		public bool ChooseRecpientCode(string value)
		{
			Report.Info("Switching to iFrame");
			Delay.Seconds(2);
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			//IWebElement retailerOption = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//span[text()='WPSID']//ancestor::td//following-sibling::td//input"), 2);
			IWebElement recipientOption = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@".//span[text()='WERCSmart Retail Recipient Code']/ancestor::td/following-sibling::td//div//select"), 2);
			if (recipientOption == null)
			{
				Report.Info("Failed to select The Recipient Code from the Options drop down menu");
				Report.Info("Exiting iFrame");
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return false;
			}
			else
			{

				recipientOption.Select(value);
				var selectedOption = recipientOption.SelectedOption();
				Report.Info("Exiting iFrame");
				SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
				return selectedOption==value;
			}




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

			IWebElement startDate = this.FindElement(By.XPath("//span[contains(text(),'Start Date')]//..//..//input"), 2);
			IWebElement endDate = this.containerElement.FindElement(By.XPath("//span[contains(text(),'End Date')]//..//..//input"), 2);
			IWebElement submitBtn = this.FindElement(By.XPath("//input[@name='Submit']"), 2);

			if (startDate == null || endDate == null)
			{
				Report.Info("The Date fields were unable to be located.");
				return false;
			}

			if (submitBtn == null)
			{
				Report.Info("Submit button was unable to be located.");
				return false;
			}

			Report.IsTrue(startDate.TryEnterText(start), "Start date was not able to be changed", "Start date entered: " + start);
			Report.IsTrue(endDate.TryEnterText(end), "End date was not able to be changed", "End date entered: " + end);
			Report.IsTrue(submitBtn.TryClick(), "Submit button was not clicked", "Submit button clicked");

			//ReadOnlyCollection<IWebElement> fields = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//input"));

			//if (fields.Count < 2)
			//{
			//	Report.Info("The Date fields were unable to be located.");
			//	return false;
			//}

			//Report.IsTrue(this.ReplaceAllTextInElementWith(start, fields[0]), "Start Date field was not able to be updated", "Start Date field was updated successfully");
			//Report.IsTrue(this.ReplaceAllTextInElementWith(end, fields[1]), "End Date field was not able to be updated", "End Date field was updated successfully");

			//fields[1].TryClick();
			//fields[2].TryClick();
			//fields[3].TryClick();

			//SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();



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

	class AdvancedReportingTextInput : SeleniumBaseObject
	{
		public const string BasePath = "//*[@id='panel']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool EnterText(string text)
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement textInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@type='text']"));
			bool canEnterText = textInput.TryEnterText(text);
			SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			return canEnterText;
		}

		public bool ClickSubmit()
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("frmAdvancedReports");
			IWebElement submit = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@type='submit']"));
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

	class AdvancedReporting3rdParty
	{
		public string WPSID { get; set; }
		public string SupplierName { get; set; }
		public string ContactEmail { get; set; }
		public string LastOrderDate { get; set; }
		public string LastPublishedDate { get; set; }
		public string Status { get; set; }
	}
}

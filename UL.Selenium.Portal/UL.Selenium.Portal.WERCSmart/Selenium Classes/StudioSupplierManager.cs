using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using System.Net.Mail;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioSupplierManager : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-supplier-manager']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public bool EnterSearchTerm(string searchTerm)
		{
			IWebElement searchInput = this.containerElement.FindElement(By.XPath(".//input[@id='textSupplierSearch']"), 2);
			if (searchInput == null)
			{
				Report.Info("No search input has been found");
				return false;
			}

			return searchInput.TryEnterText(searchTerm);
		}

		public bool WaitForSuppliersToLoad()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//div[@class='loading ui-state-default ui-state-active' and @style='display: block;']"), 2);
			if(el==null)
			{
				Report.Success($"Loading... was not showing");
				return true;

			}
			int x = 0;
			bool loaded = false;
			while (x<12&&loaded==false)
			{
				el = this.containerElement.FindElement(By.XPath(".//div[@class='loading ui-state-default ui-state-active' and @style='display: block;']"), 2);
				loaded = el.IsNullOrEmpty();
				x++;
				Delay.Seconds(5);
			}
			return loaded;
		}

		public bool ClickSearchButton()
		{
			IWebElement searchButton = this.containerElement.FindElement(By.XPath(".//button[@id='supplierSearchButton']"), 2);
			if (searchButton == null)
			{
				Report.Info("No search input has been found");
				return false;
			}

			if (searchButton.TryClick())
			{
				Delay.Seconds(5);
				return true;
			}

			return false;

		}

		public bool SelectSupplierSearchTypeRadio(string radio)
		{
			IWebElement matchingRadio = this.containerElement.FindElement(By.XPath(".//input[@type='radio'][following-sibling::text()[position()=1][contains(., '" + radio + "')]]"), 2);
			if (matchingRadio == null)
			{
				Report.Info("No matching radio has been found");
				return false;
			}

			return matchingRadio.TryCheck();
		}

		public List<string> GetSupplierIDs()
		{
			var suppliers = new List<string>();
			IWebElement searchTable = this.containerElement.FindElement(By.XPath(".//table[@id='listSupplierInfo']"), 5);
			if (searchTable == null)
			{
				Report.Info("No supplier table has been found");
				return suppliers;
			}

			ReadOnlyCollection<IWebElement> rows = searchTable.FindElements(By.XPath(".//tr[not(contains(@class, 'firstrow'))]"));

			suppliers = rows.Select(x => x.GetAttribute("id")).ToList();

			return suppliers;

		}

		public List<string> GetSupplierNames()
		{
			var suppliers = new List<string>();
			IWebElement searchTable = this.containerElement.FindElement(By.XPath(".//table[@id='listSupplierInfo']"), 5);
			if (searchTable == null)
			{
				Report.Info("No supplier table has been found");
				return suppliers;
			}

			ReadOnlyCollection<IWebElement> rows = searchTable.FindElements(By.XPath(".//tr[not(contains(@class, 'firstrow'))]//td[2]"));

			suppliers = rows.Select(x => x.GetAttribute("title")).ToList();

			return suppliers;

		}

		public bool ClickClose()
		{
			IWebElement closeButton = this.containerElement.FindElement(By.XPath("./../..//span[text()='Result Clear Shopping Cart All Users']/../following-sibling::div[@class='ui-dialog-buttonpane ui-widget-content ui-helper-clearfix']//button"), 2);
			if (closeButton == null)
			{
				Report.Info("Could not find close button");
				return false;
			}

			return closeButton.TryClick();
		}

		public bool ClickFirstSupplier()
		{
			Delay.Seconds(10);
			IWebElement firstSupplier = this.containerElement.FindElement(By.XPath("//table[@id='listSupplierInfo']//tr[not(@class='jqgfirstrow')]"), 2);
			//int i = 0;
			//while (firstSupplier == null)
			//{
			//	Delay.Seconds(1);
			//	i++;

			//	if (i == 30)
			//	{
			//		break;
			//	}
			//}
			return firstSupplier.TryClick();

		}

		public bool ClickCategory(string category)
		{
			List<IWebElement> categories = this.containerElement.FindElements(By.XPath($".//li[contains(@class,'ui-state-default ui-corner-top')]"), 2).ToList();

			if (categories == null)
			{
				Report.Info($"Did not find any categories");
				return false;
			}

			IWebElement foundCategory = categories.First(x => x.Text == category);
			if (foundCategory == null)
			{
				Report.Info($"Did not find the category: {category}");
				return false;
			}
			Report.Info($"Found the category: {category}, attempting to click the category");
			return foundCategory.TryClick();

			//IWebElement firstSupplier = this.containerElement.FindElement(By.XPath(".//ul[@class='ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all']//a[text()='" + category + "']"), 2);
			//return firstSupplier.TryClick();

		}

		public bool ClickClearCartForAllUsers()
		{
			IWebElement clearCartForAllUsersButton = this.containerElement.FindElement(By.XPath(".//button[@id='clearCartButton']"), 2);
			return clearCartForAllUsersButton.TryClick();
		}

		public IWebElement CategoryHeaders => this.containerElement.WaitUntilElementVisible(By.XPath($".//ul[contains(@class,'ui-tabs-nav')]"), 2);

		public bool CheckCategoriesPresent()
		{
			IWebElement categoryHeaders = this.containerElement.WaitUntilElementVisible(By.XPath($"//div[@id='dialog-supplier-manager']//ul[contains(@class,'ui-tabs-nav')]"), 30);
			if (categoryHeaders == null)
			{
				return false;
			}
			return true;

		}

		public bool CheckForSupplierManagerColumn(string columnTitle)
		{
			IWebElement subscriptionStatusColumn = this.containerElement.FindElement(By.XPath($".//th//div[contains(text(), '{columnTitle}')]"), 2);

			if (subscriptionStatusColumn == null)
			{
				return false;
			}
			return true;
		}

		public bool CheckForSupplierManagerColumnValue(string columnTitle, string status)
		{
			IWebElement subscriptionStatus = this.containerElement.FindElement(By.XPath($".//td[@aria-describedby='listSupplierInfo_{columnTitle}']"), 2);
			string statusText = subscriptionStatus.Text;
			return statusText == status;
		}

		public bool CheckForSubscriptionTabColor(string color)
		{
			switch (color)
			{
				case "black":
					color = "rgba(85, 85, 85, 1)";
					break;
				case "blue":
					color = "rgba(0, 0, 255, 1)";
					break;
				case "red":
					color = "rgba(255, 0, 0, 1)";
					break;
				case "yellow":
					color = "rgba(255, 255, 0, 1)";
					break;
				default:
					break;
			}
			string fontColor = this.containerElement.FindElement(By.XPath($"//li/a[contains(text(), 'Subscription')]"), 2).GetCssValue("color").ToString();
			return color == fontColor;
		}

		public bool CheckForSubscriptionTabBackgroundColor(string color)
		{
			string style = this.containerElement.FindElement(By.XPath($"//li/a[contains(text(), 'Subscription')]"), 2).GetAttribute("style");
			return style.Contains("background-color") && style.Contains(color);
		}

		public bool CategoryIsActive(string category)
		{
			List<IWebElement> categories = this.containerElement.FindElements(By.XPath($".//li[contains(@class,'ui-state-default ui-corner-top')]"), 2).ToList();
			IWebElement foundCategory = categories.First(x => x.Text == category);
			if (foundCategory == null)
			{
				Report.Info("Did not find the catagory, the element was null");
				return false;
			}
			if (foundCategory.GetAttribute("class").Contains("active"))
			{
				return true;
			}
			return false;
		}


		public List<string> ColumnValues(string columnTitle)
		{
			List<IWebElement> tableHeaders = this.containerElement.FindElements(By.XPath($".//table[@class='DataTierConsentGrid']//tr[@class='AltItem']//th"), 2).ToList();
			List<string> tableHeaderStrings = new List<string>();

			foreach (var item in tableHeaders)
			{
				tableHeaderStrings.Add(item.Text);
			}

			if (columnTitle == "Retailer")
			{
				columnTitle = "";
			}
			int i = 1;
			int titlePosition = 0;
			bool titleFound = false;
			Report.Info($"Looking for the postion of column with title: {columnTitle}");
			foreach (var title in tableHeaderStrings)
			{
				if (title == columnTitle)
				{
					titlePosition = i;
					titleFound = true;
					Report.Info($"The title was found at position: {titlePosition}");
					break;
				}
				i++;

			}
			if (titleFound == false)
			{
				Report.Info("The title was not found in the table");
				return null;
			}
			Report.Info("Starting to look for differences in the column and the expected values");
			List<IWebElement> tableRows = this.containerElement.FindElements(By.XPath($".//table[@class='DataTierConsentGrid']//tbody//tr"), 2).ToList();
			List<string> tableRowStrings = new List<string>();
			foreach (var row in tableRows)
			{
				string rowText = row.FindElement(By.XPath($".//td[{titlePosition}]"), 2).Text;
				tableRowStrings.Add(rowText);
			}
			return tableRowStrings;
		}

		public bool ColumnContains(string columnTitle, List<string> expectedValues)
		{
			var differenceQuery1 = expectedValues.Except(this.ColumnValues(columnTitle));
			var differnceQuery2 = this.ColumnValues(columnTitle).Except(expectedValues);
			var resultingDiff = differenceQuery1.Concat(differnceQuery2).ToList();
			return resultingDiff.Count() == 0;
		}

		public bool ColumnIncludes(string columnTitle, List<string> expectedValues)
		{
			var differenceQuery1 = expectedValues.Except(this.ColumnValues(columnTitle));
			return differenceQuery1.IsNullOrEmpty();
		}

		public bool DataConsentTableIsPresent()
		{
			IWebElement dataTierTable = this.containerElement.WaitUntilElementVisible(By.XPath($"//div[@id='dialog-supplier-manager']//table[@class='DataTierConsentGrid']"), 30);
			if (dataTierTable == null)
			{
				return false;
			}
			return true;
		}

		public bool DataConsentTiersTableContainsHeaders(List<string> expectedHeaders)
		{

			List<IWebElement> tableHeaders = this.containerElement.FindElements(By.XPath($".//table[@class='DataTierConsentGrid']//tr[@class='AltItem']//th"), 2).ToList();
			List<string> tableHeaderStrings = new List<string>();
			foreach (var item in tableHeaders)
			{
				tableHeaderStrings.Add(item.Text);
			}
			int i = 0;
			bool headersCorrect = true;
			if (expectedHeaders.Count != tableHeaderStrings.Count)
			{
				Report.Info("The number of headers found did not match the expected number of headers");
				return false;
			}
			foreach (var item in tableHeaderStrings)
			{
				Report.Info($"The header found was: {item}");
				Report.Info($"The header expected was: {expectedHeaders[i]}");
				if (item != expectedHeaders[i])
				{
					headersCorrect = false;
					Report.Info($"The header found was not as expected");
				}
				else
				{
					Report.Info($"The header was as expected");
				}
				i++;
			}
			return headersCorrect;



		}

		public bool EmailColumnContainsEmailAddresses()
		{

			var tableRowStrings = this.ColumnValues("Email");
			bool emailValid = true;
			int y = 1;
			foreach (var email in tableRowStrings)
			{
				if (string.IsNullOrWhiteSpace(email))
				{
					Report.Info($"The email in row: {y} was returned as blank");
					emailValid = false;
				}
				try
				{
					MailAddress m = new MailAddress(email);
					Report.Info($"The email in row: {y} was a valid email address");

				}
				catch
				{
					Report.Info($"The email in row: {y} was not a vaid email address");
					emailValid = false;
				}
				y++;

			}

			return emailValid;
		}

		public bool DateColumnContainsValidmmddyyyy()
		{
			var tableRowStrings = this.ColumnValues("Date");
			bool dateValid = true;
			foreach (var date in tableRowStrings)
			{

				string pattern = @"^(0?[1-9]|1[012])[\-](0?[1-9]|[12][0-9]|3[01])[\-](19|20)\d\d$";
				Regex rg = new Regex(pattern);
				Match match = rg.Match(date);
				if (match.Success)
				{
					Report.Info($"The date: {date} is in the valid format of mm-dd-yyyy");
				}
				else
				{
					Report.Info($"The date: {date} was not is the valid format of mm-dd-yyyy");
					dateValid = false;
				}


			}
			return dateValid;
		}

		public bool ConfirmTierHasCorrectMarkingForRetailer(string retailer, string[] tierArray, string mark)
		{

			IList<IWebElement> rowElementsArray = this.containerElement.FindElements(By.XPath("//td[contains(text(), '" + retailer + "')]//following-sibling::td"), 2);

			foreach (string str in tierArray)
			{
				switch (str.ToLower())
				{
					case "tier 1":

						if (rowElementsArray[0].Text != mark)
						{
							return false;
						}

						break;

					case "tier 2.1":

						if (rowElementsArray[1].Text != mark)
						{
							return false;
						}

						break;

					case "tier 2.2":

						if (rowElementsArray[2].Text != mark)
						{
							return false;
						}

						break;

					case "tier 3":

						if (rowElementsArray[3].Text != mark)
						{
							return false;
						}

						break;

					case "tier 4.1":

						if (rowElementsArray[4].Text != mark)
						{
							return false;
						}

						break;

					case "tier 4.2":

						if (rowElementsArray[5].Text != mark)
						{
							return false;
						}

						break;

					default:
						Report.Info("Was not one of the expected tiers: " + str);
						return false;
				}

			}
			return true;
		}
		public bool ClickTabWithName(string tabName)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//a[text()='" + tabName + "']"), 2);
			return el.TryClick();
		}
		public bool ClickResultWithName(string resultName)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//td[@title='" + resultName + "']"), 2);
			return el.TryClick();
		}
		public bool SearchTheFollowingText(string searchText)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//input[@id='textSupplierSearch']"), 2);
			return el.TryEnterText(searchText);
		}

		public bool ClickSuppliersButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//a[text()='Suppliers']"), 2);
			return el.TryClick();
		}

		public bool CloseSupplierManager()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//div[@id='dialog-supplier-manager']/preceding-sibling::div//a"), 2);
			return el.TryClick();
		}

		public bool ConfirmCBDRegistrationPopupInIndredientsPageContainsCorrectText()
		{
			IWebElement popupText = this.containerElement.FindElement(By.XPath(@"//div[@class='alert alert-warning'][@data-bind='visible: model.HasError']"), 2);
			IList<IWebElement> popupListText = this.containerElement.FindElements(By.XPath(@"//div[@class='alert alert-warning'][@data-bind='visible: model.HasError']//ul//li"), 2);
			if (popupText.Text.Contains("This product contains a cannabidiol (CBD) ingredient and may be subject to FDA restrictions when included in a Final Product Registration that is marketed for therapeutic or medical uses although they have not been approved by the FDA. Note that assessments conducted by UL do not include:")
				&& popupText.Text.Contains("UL's assessment includes a full review of the Product Ingredients and Type of Product to ensure the Final Product is correctly identified as a CBD-related product. Please be sure that you've properly indicated the proper Product Type based on the ingredients you've provided.")
				&& popupText.Text.Contains("For information about FDA’s approach to CBD-containing products, visit their website")
				&& popupListText[0].Text.Contains("Marketing messages")
				&& popupListText[1].Text.Contains("Labeling for benefit statements")
				&& popupListText[2].Text.Contains("Health claims"))
			{
				return true;
			}
			else if (!popupText.Text.Contains("This product contains a cannabidiol (CBD) ingredient and may be subject to FDA restrictions when included in a Final Product Registration that is marketed for therapeutic or medical uses although they have not been approved by the FDA. Note that assessments conducted by UL do not include:"))
			{
				Report.Failure("The first line did not display the correct text");
			}
			else if (popupText.Text.Contains("UL's assessment includes a full review of the Product Ingredients and Type of Product to ensure the Final Product is correctly identified as a CBD-related product. Please be sure that you've properly indicated the proper Product Type based on the ingredients you've provided."))
			{
				Report.Failure("The second line did not display the correct text");
			}
			else if (popupText.Text.Contains("For information about FDA’s approach to CBD-containing products, visit their website"))
			{
				Report.Failure("The third line did not display the correct text");
			}
			else if (popupListText[0].Text.Contains("Marketing messages"))
			{
				Report.Failure("The first list item did not display the correct text");
			}
			else if (popupListText[1].Text.Contains("Labeling for benefit statements"))
			{
				Report.Failure("The second list item did not display the correct text");
			}
			else if (popupListText[2].Text.Contains("Health claims"))
			{
				Report.Failure("The third list item did not display the correct text");
			}

			return false;
		}

		public bool CloseCBDRegistrationGuidancePopupInIngredientsPage()
		{
			IWebElement closeButton = this.containerElement.FindElement(By.XPath(@"//h4[text()='CBD Registration Guidance']/../..//div[@class='modal-footer']//button[@class='btn btn-default']"), 2);
			return closeButton.TryClick();
		}

	}
}

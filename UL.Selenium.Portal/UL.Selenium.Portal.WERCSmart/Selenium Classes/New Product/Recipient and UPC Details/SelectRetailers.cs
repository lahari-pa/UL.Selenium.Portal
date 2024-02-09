using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class SelectRetailers : NewProduct
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='select-retailers-dialog']");
		List<IWebElement> ListOfRetailers => this.ContainerElement.FindElements(By.XPath(".//div[@class='col-sm-12 list-view']"), 2).ToList();

		public bool SelectRetailer(string retailer)
		{
			IWebElement retailerInput = this.ContainerElement.FindElements(By.XPath("//label/span")).FirstOrDefault(x => x.Text.Trim() == retailer).FindElement(By.XPath("../input"), 2);
			if (retailerInput != null && retailerInput.TryClick())
			{
				return retailerInput.Selected;
			}
			Report.Error($"Could not find retailer: {retailer}");
			return false;
		}

		public bool SelectRetailerContains(string retailer)
		{
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> retailers = this.ContainerElement.FindElements(By.XPath("//label/span"));
			IWebElement matchingRetailer = retailers.FirstOrDefault(x => x.Text.Trim().ToLower().Contains(retailer));

			if (matchingRetailer == null)
			{
				Report.Info("No matching retailer was found");
				return false;
			}
			IWebElement retailerInput = matchingRetailer.FindElement(By.XPath("../input"), 2);
			if (retailerInput != null && retailerInput.TryClick())
			{
				return retailerInput.Selected;
			}
			Report.Error("Could not find retailer: " + retailer);
			return false;
		}

		// This is required for selecting the 'Walmart affiliate' retailers, which all have the same name/span text (Wal-Mart/SAM'S CLUB)
		public bool SelectRetailerByLogo(string retailerCode)
		{
			IWebElement el = this.ContainerElement.FindElements(By.XPath(".//div[starts-with(@class,'col-sm-3')]/div[starts-with(@class,'control')]"), 2).FirstOrDefault(x => x.GetCssValue("background-image").ToLower().Contains(retailerCode.ToLower()));
			if (el == null)
			{
				return false;
			}
			return el.FindElement(By.XPath("./div[@class='checkbox']"), 2).TryClick();
		}

		public List<string> GetListOfRetailers()
		{
			return this.ContainerElement.FindElements(By.XPath(".//label/span")).Select(x => x.Text).ToList();
		}

		public bool ClickSelectAll()
		{
			return this.ContainerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Select all')]")).FirstOrDefault().TryClick();
		}

		public bool DoneButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Done')]"), 2);
			if (el == null)
			{
				return false;
			}

			return true;
		}

		public bool ClickDone()
		{
			return this.ContainerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Done')]")).FirstOrDefault().TryClick();
		}

		public bool ClickClose()
		{
			return this.ContainerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//i[@class='fa fa-close']")).FirstOrDefault().TryClick();
		}

		public List<string> SelectedRetailers(bool useLogoCode = false)
		{
			var allSelected = this.ContainerElement.FindElements(By.XPath(".//input[@type = 'checkbox']"), 2).Where(x => x.Checked()).ToList();
			if (allSelected.IsNullOrEmpty())
			{
				return new List<string>();
			}
			allSelected.LastOrDefault().ScrollElementIntoView();
			return useLogoCode ?
				allSelected.Select(x => x.FindElement(By.XPath("./../../../../div[starts-with(@class,'control-group')]")).GetCssValue("background-image").Replace(@"""", "").Replace("url(", "").Replace(")", "")).ToList()
				: allSelected.Select(x => x.FindElement(By.XPath("./following-sibling::span[contains(@data-bind,'retailer.description')]")).Text).ToList();
		}

		public List<string> AllRetailers()
		{
			var allRetailers = this.ContainerElement.FindElements(By.XPath(".//input[@type = 'checkbox']"), 2).ToList();
			if (allRetailers.IsNullOrEmpty())
			{
				return new List<string>();
			}
			allRetailers.LastOrDefault().ScrollElementIntoView();
			return allRetailers.Select(x => x.FindElement(By.XPath("./following-sibling::span")).Text).Distinct().ToList();
		}

		public bool ClickRetailerOption(string option)
		{
			IWebElement toggleEl = this.ContainerElement.FindElement(By.XPath(".//a[@class='small-link' and contains(@data-bind,'toggleRetailerListView')]"), 2);
			switch (option.ToLower())
			{
				case "list view":
					if (toggleEl != null && toggleEl.Text.ToLower().Contains("logo tile view"))
					{
						Report.Info("The Select Retailers option was already set to: " + option);
						return true;
					}
					return toggleEl.TryClick();
				case "logo tile view":
					if (toggleEl != null && toggleEl.Text.ToLower().Contains("list view"))
					{
						Report.Info("The Select Retailers option was already set to: " + option);
						return true;
					}
					return toggleEl.TryClick();
				case "select all":
					return this.ContainerElement.FindElement(By.XPath(".//a[@class='small-link' and contains(@data-bind,'selectAll')]"), 2).TryClick();
				default:
					return false;
			}
		}
		public bool SelectAllDisplayed()
		{
			IWebElement selectAll = this.ContainerElement.FindElement(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Select all')]"), 2);
			Report.Info("Attempting to confirm 'Select All' option is displayed.");
			return selectAll.Displayed;
		}

		public bool RetailersShownInViewType(string viewType)
		{
			switch (viewType)
			{
				case "list":
					return this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'list-view') and .//input[@type='checkbox']]"), 2) != null;
				case "tile":
					return this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'control-group') and .//input[@type='checkbox']]"), 2) != null;
			}

			Report.Info("List type must be specified as either 'list' or 'tile'");
			return false;
		}

		public bool SelectRetailerFromListView(string retailer)
		{
			return this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'list-view') and .//span[text()=\"" + retailer + "\"]]//input"), 2).TryClick();
		}

		public List<string> UnselectedRetailers()
		{
			IList<IWebElement> checkboxes = this.ContainerElement.FindElements(By.XPath(".//label[@class='checkbox']/input"), 2);
			return checkboxes.All(x => x.Checked()) ? new List<string>() :
				checkboxes.Where(x => !x.Checked()).Select(x => x.FindElement(By.XPath("./following-sibling::span"), 2)?.Text).ToList();
		}


		public void CheckIfRetailersInTableDisplayErrorMessage(Table table)
		{
			IList<IWebElement> AllRetailerErrorMessages = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//span[@data-bind='html: $data']/../../../preceding-sibling::td[1]"), 2);
			List<string> ReatilersThatDidNotDisplayErrorMessages = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				bool foundMatch = false;

				foreach (IWebElement element in AllRetailerErrorMessages)
				{
					if (row["Retailer"] == element.Text)
					{
						foundMatch = true;
					}
				}

				if (!foundMatch)
				{
					ReatilersThatDidNotDisplayErrorMessages.Add(row["Retailer"]);
				}

			}

			if (ReatilersThatDidNotDisplayErrorMessages.Count() > 0)
			{
				Report.Failure("The following retailers: " + ReatilersThatDidNotDisplayErrorMessages.ToString() + " did not display the error messages they were supposed to.");
				return;
			}

			Report.Success("All retailers in the table displayed their proper error messages");
			return;
		}

		public bool OnlyOneRetailerCanBeSelected(Table retailers)
		{
			var retailersToSelect = new List<string>();
			retailers.Rows.Cast<TableRow>().ToList().ForEach(x => retailersToSelect.Add(x["Retailer"]));
			IWebElement RetailerName;
			IWebElement Checkbox;
			bool retailerIsSelected;
			var retailersList = new List<string>();

			foreach (var element in this.ListOfRetailers)
			{
				RetailerName = element.FindElement(By.XPath(".//span[contains(@data-bind,'retailer.description')]"));
				if (RetailerName == null)
				{
					Report.Info("Failed to find retailer name");
				}
				Checkbox = element.FindElement(By.XPath("//input[@disabled]"));
				string getRetailerName = RetailerName.Text;
				retailerIsSelected = retailersToSelect.Contains(getRetailerName);
				retailersList.Add(getRetailerName);
				if (!retailerIsSelected)
				{
					if (Checkbox == null)
					{
						Report.Info($"Checkbox is not disabled for retailer{getRetailerName}");
						return false;
					}
				}
			}
			return true;
		}
	}

	class NoRetailerWarningPopup : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='modal fade in']");

		public bool ClickChoice(string choice)
		{
			choice = Regex.Replace(choice, "([A-Z])([A-Z]+)($|[A-Z])",
			m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
			choice = char.ToUpper(choice[0]) + choice.Substring(1);

			try
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath("//div[@class='modal fade in']//button[contains(text(), '" + choice + "')]"), 2);
				if (el == null)
				{
					return false;
				}
				return el.TryClick() && GeneralUtilities.WaitForRefreshToDisappear(el) && GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception)
			{
				return false;
			}
		}

	}
}

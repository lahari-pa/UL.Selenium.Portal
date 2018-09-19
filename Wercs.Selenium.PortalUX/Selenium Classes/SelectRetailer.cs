using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;
using SafewareReporting;
using Global = SeleniumUtilities.Global;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class SelectRetailers : BaseObject
	{
		public const string BasePath = "//div[@id='select-retailers-dialog']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool SelectRetailer(string retailer)
		{
			var retailerInput = containerElement.FindElements(By.XPath("//label/span")).FirstOrDefault(x => x.Text.Trim() == retailer).FindElement(By.XPath("../input"), 2);
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
			var el = containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col-sm-3')]/div[starts-with(@class,'control')]"), 2).FirstOrDefault(x => x.GetCssValue("background-image").ToLower().Contains(retailerCode.ToLower()));
			if (el == null)
			{
				return false;
			}
			return el.FindElement(By.XPath("./div[@class='checkbox']"), 2).TryClick();
		}

		public List<string> GetListOfRetailers()
		{
			return containerElement.FindElements(By.XPath("//label/span")).Select(x => x.Text).ToList();
		}

		public bool ClickSelectAll()
		{
			return containerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Select all')]")).FirstOrDefault().TryClick();
		}

		public bool ClickDone()
		{
			return containerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Done')]")).FirstOrDefault().TryClick();
		}

		public bool ClickClose()
		{
			return containerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//i[@class='fa fa-close']")).FirstOrDefault().TryClick();
		}

		public List<string> SelectedRetailers(bool useLogoCode = false)
		{
			var allSelected = containerElement.FindElements(By.XPath(".//input[@type = 'checkbox']"), 2).Where(x => x.Checked()).ToList();
			if (allSelected.IsNullOrEmpty())
			{
				return new List<string>();
			}
			allSelected.LastOrDefault().ScrollElementIntoView();
			if (useLogoCode)
			{
				return allSelected.Select(x => x.FindElement(By.XPath("./../../../../div[starts-with(@class,'control-group')]")).GetCssValue("background-image").Replace(@"""", "").Replace("url(", "").Replace(")", "")).ToList();
			}
			return allSelected.Select(x => x.FindElement(By.XPath("./following-sibling::span[contains(@data-bind,'retailer.description')]")).Text).ToList();
		}

		public List<string> AllRetailers()
		{
			var allRetailers = containerElement.FindElements(By.XPath(".//input[@type = 'checkbox']"), 2).ToList();
			if (allRetailers.IsNullOrEmpty())
			{
				return new List<string>();
			}
			allRetailers.LastOrDefault().ScrollElementIntoView();
			return allRetailers.Select(x => x.FindElement(By.XPath("./following-sibling::span")).Text).Distinct().ToList();

		}

		public bool ClickRetailerOption(string option)
		{
			var toggleEl = containerElement.FindElement(By.XPath(".//a[@class='small-link' and contains(@data-bind,'toggleRetailerListView')]"), 2);
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
					return containerElement.FindElement(By.XPath(".//a[@class='small-link' and contains(@data-bind,'selectAll')]"), 2).TryClick();
				default:
					return false;
			}
		}

		public bool RetailersShownInViewType(string viewType)
		{
			if (viewType == "list")
			{
				return containerElement.FindElement(By.XPath(".//div[contains(@class,'list-view') and .//input[@type='checkbox']]"), 2) != null;
			}
			if (viewType == "tile")
			{
				return containerElement.FindElement(By.XPath(".//div[contains(@class,'control-group') and .//input[@type='checkbox']]"), 2) != null;
			}
			Report.Info("List type must be specified as either 'list' or 'tile'");
			return false;
		}
		public bool SelectRetailerFromListView(string retailer)
		{
			return containerElement.FindElement(By.XPath(".//div[contains(@class,'list-view') and .//span[text()='"+ retailer +"']]//input"), 2).TryClick();
		}

		public List<string> RetailersNotSelected()
		{
			return containerElement.FindElements(By.XPath(".//input[@type = 'checkbox']"), 2).Where(x => !x.Checked()).Select(x => x.FindElement(By.XPath("./following-sibling::span")).Text).ToList();
		}
	}

	class NoRetailerWarningPopup : BaseDialog
	{
		public const string BasePath = "//div[@class='modal fade in']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickOk()
		{
			//return containerElement.FindElements(By.XPath("//div[@class='modal fade in']//button[contains(text(), 'Ok')]")).FirstOrDefault().TryClick();
			try
			{
				var el = this.containerElement.FindElement(By.XPath("//div[@class='modal fade in']//button[contains(text(), 'Ok')]"), 2);
				if (el == null)
				{
					return false;
				}

				el.TryClick();
				Report.Screenshot();
				GeneralUtilities.WaitForRefreshToDisappear(el);
				GeneralUtilities.Wait_for_load_finish();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

	}
}

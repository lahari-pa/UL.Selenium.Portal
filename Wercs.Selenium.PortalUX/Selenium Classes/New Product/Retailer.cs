using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes.New_Product
{
	class Retailer : NewProduct
	{
		public bool ClickAddRetailers()
		{
			try
			{
				var button = this.containerElement.FindElement(By.XPath(".//a[@class='btn btn-success' and text()='Add Retailers']"));
				return button.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public List<string> SelectedRetailers()
		{
			try
			{
				var selectedRetailers = new List<string>();
				var selectedRetailersName = this.containerElement.FindElements(By.XPath(".//div[@class='grid-container']//tr[parent::tbody[@data-bind='foreach: field.field']]/td[@class='col-xs-3']"));
				foreach (var row in selectedRetailersName)
				{
					selectedRetailers.Add(row.Text);
				}
				return selectedRetailers;
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// Select Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) from dropdown.
		/// </summary>
		public bool SelectPrivateLabelName(string item)
		{
			try
			{
				var container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				var el = container.FindElement(By.XPath(".//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/..//select"), 2);
				if (el == null)
				{
					Report.Error("The Private Label select element could not be found");
					return false;
				}
				el.Select(item);
				Delay.Seconds(1);
				return el.SelectedOption() == item;
			}
			catch (Exception ex)
			{
				Report.Error(ex.Message);
				return false;
			}
		}

		/// <summary>
		///Enter full name of product, as sold, via this retailer (e.g. Private Label Aspirin) via text input.
		/// </summary>
		public bool EnterPrivateLabelName(string item)
		{
			try
			{
				var container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				var el = container.FindElement(By.XPath(".//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/..//input"), 2);
				if (el == null)
				{
					Report.Error("The Private Label input element could not be found");
					return false;
				}
				el.EnterText(item);
				Delay.Seconds(1);
				return el.GetValue() == item.Trim();
			}
			catch (Exception ex)
			{
				Report.Error(ex.Message);
				return false;
			}
		}

		/// <summary>
		///Enter full name of product, as sold, via this retailer (e.g. Private Label Aspirin) via text input. Overload string for specific retailer
		/// </summary>
		public bool EnterPrivateLabelName(string item, string retailer)
		{
			try
			{
				var el = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']//tr[(.//td[text()='" + retailer + "'])]//input[starts-with(@placeholder,'Indicate full name of product')]"), 2);
				if (el == null)
				{
					Report.Error("Could not find the input field for retailer: " + retailer);
					return false;
				}
				el.EnterText(item);
				Delay.Seconds(1);
				return el.GetValue() == item.Trim();
			}
			catch (Exception ex)
			{
				Report.Error(ex.Message);
				return false;
			}
		}

		/// <summary>
		/// Select first vendor id from dropdown
		/// </summary>
		public bool SelectVendorId(string item)
		{
			try
			{
				var container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				var el = container.FindElement(By.XPath(".//label[text()='Select Vendor']/..//select"), 2);
				if (el == null)
				{
					Report.Error("Could not find the Vendor ID select input element");
					return false;
				}
				el.Select(item);
				Delay.Seconds(1);
				return el.SelectedOption() == item;
			}
			catch (Exception ex)
			{
				Report.Error(ex.Message);
				return false;
			}
		}

		/// <summary>
		/// Select vendor id from dropdown for a specific retailer. Overloads for string specific retailer, bool select the first available option
		/// </summary>
		public bool SelectVendorId(string item, string retailer, bool selectFirst = false)
		{
			try
			{
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				var el = container.FindElement(By.XPath($@".//tr[./td[text()=""{retailer}""]]//label[text()='Select Vendor']/..//select"), 2);
				if (el == null)
				{
					if (retailer.ToLower().Contains("walmart") || retailer.ToLower().Contains("wal-mart"))
					{
						retailer = "Walmart";
						el = container.FindElement(By.XPath($@".//tr[.//*[contains(text(),'Walmart')]]//label[text()='Select Vendor']/..//select"), 2);
						if (el == null)
						{
							retailer = "Wal-Mart";
							el = container.FindElement(By.XPath($@".//tr[.//*[contains(text(),'Wal-Mart')]]//label[text()='Select Vendor']/..//select"), 2);
						}
					}
				}

				if (el == null)
				{
					Report.Info("Vendor was not selectable for retailer: " + retailer);
					return false;
				}
				if (selectFirst)
				{
					var options = el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "Choose...").ToList();
					if (options.Count == 0)
					{
						Report.Info("There were no vendor options available for retailer " + retailer);
						return false;
					}
					Report.Info("Selecting the first vendor option for retailer: " + retailer);
					var firstOption = options.First();
					Report.Info("First vendor option is: " + firstOption);
					el.Select(firstOption);
					Delay.Seconds(1);
					return el.SelectedOption() == firstOption;
				}
				el.Select(item);
				Delay.Seconds(1);
				return el.SelectedOption() == item;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectRetailer(string retailerName)
		{
			var xPath = @".//input[@type='checkbox' and parent::td/following-sibling::td[text() =""" + retailerName + @"""]]";
			var box = this.containerElement.FindElement(By.XPath(xPath), 2);
			return box.TryClick() && box.Checked();
		}

		public bool DeleteSelectedRetailers()
		{
			var xPath = ".//a[@class='btn delete-selected']/i";
			return this.containerElement.FindElement(By.XPath(xPath), 2).TryClick();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class Retailer : NewProduct
	{
		public bool CheckForTheFollowingRetailersInRetailerPage(Table table)
		{
			IList<IWebElement> retailerList = this.containerElement.FindElements(By.XPath("//table[@class='table table-striped table-hover table-fixed marTop-20']//tbody//td[@class='col-xs-3']"), 2);
			List<string> retailerListText = new List<string>();

			if (table.RowCount != retailerList.Count)
			{
				Report.Info("The amount of retailers found are not equal to the amount of retailers in the table");
				return false;
			}

			foreach (var retailerName in retailerList)
			{
				retailerListText.Add(retailerName.Text);
			}

			foreach (TableRow row in table.Rows)
			{
				if (!retailerListText.Contains(row["Retailer"]))
				{
					return false;
				}
			}

			return true;
		}

		public bool ClickAddRetailers()
		{
			try
			{
				IWebElement button = this.containerElement.FindElement(By.XPath(".//a[@class='btn btn-success' and text()='Add Retailers']"), 2);
				
				if (button == null)
				{
					return false;
				}
				return button.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectRetailsPopupIsDisplayed()
		{
			try
			{
				IWebElement poup = this.containerElement.FindElement(By.XPath(".//h4[contains(text(),'Select Retailers')]"), 2);

				if (poup != null)
				{
					return true;
				}

				return false;
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
				ReadOnlyCollection<IWebElement> selectedRetailersName = this.containerElement.FindElements(By.XPath(".//div[@class='grid-container']//tr[parent::tbody[@data-bind='foreach: field.field']]/td[@class='col-xs-3']"));
				
				if (selectedRetailersName == null)
				{
					return null;
				}
				foreach (IWebElement row in selectedRetailersName)
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

		public bool ConfirmRetailerCannotBeDeselectedInRetailersTable(string retailer)
		{
			IWebElement retailerEl = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']//td[text()='" + retailer + "']/preceding-sibling::td//input[@disabled='disabled']"), 2);

			if (retailerEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmRetailerCannotBeDeselectedInSelectRetailersPopup(string retailer)
		{
			IWebElement retailerEl = this.containerElement.FindElement(By.XPath(".//div[@class='row retailers-list']//span[text()='" + retailer + "']/preceding-sibling::input[@checked][@disabled='disabled']"), 2);

			if (retailerEl != null)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Select Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) from dropdown.
		/// </summary>
		public bool SelectPrivateLabelName(string item)
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				IWebElement el = container.FindElement(By.XPath(".//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/..//select"), 2);
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
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				IWebElement el = container.FindElement(By.XPath(".//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/..//input"), 2);
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
				IWebElement el = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']//tr[(.//td[text()='" + retailer + "'])]//input[starts-with(@placeholder,'Indicate full name of product')]"), 2);
				
				if (el == null)
				{
					return false;
				}
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

		public bool ChoosePrivateLabelName(string item, string retailer)
		{
			try
			{
				IList <IWebElement> elList = this.containerElement.FindElements(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']//tr[(.//td[contains(text(), '" + retailer + "')])]//label[text()='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)']/following-sibling::select//option"), 2);

				if (elList.Count == 0)
				{
					Report.Error("Could not find the input field for retailer: " + retailer);
					return false;
				}

				foreach (IWebElement el in elList)
				{
					if (el.Text.Contains(item))
					{
						return el.TryClick();
					}
				}
				Delay.Seconds(1);
			}
			catch (Exception ex)
			{
				Report.Error(ex.Message);
				return false;
			}

			return false;
		}

		/// <summary>
		/// Select first vendor id from dropdown
		/// </summary>
		public bool SelectVendorId(string item, bool selectFirst = false)
		{
			try
			{

				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);

				if (container == null)
				{
					Report.Error("Could not find the container element");
					return false;
				}

				IWebElement el = container.FindElement(By.XPath(".//label[text()='Select Vendor']/..//select"), 2);

				if (el == null)
				{
					Report.Error("Could not find the Vendor ID select input element");
					return false;
				}
				if (selectFirst)
				{
					var options = el.FindElements(By.XPath("./option"), 2).Select(x => x.Text).Where(x => x != "Choose...").ToList();
					if (options.Count == 0)
					{
						Report.Info("There were no vendor options available");
						return false;
					}
					Report.Info("Selecting the first vendor option");
					string firstOption = options.First();
					Report.Info("First vendor option is: " + firstOption);
					el.Select(firstOption);
					Delay.Seconds(1);
					return el.SelectedOption() == firstOption;
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

		public bool SelectRandomVendorId()
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				IWebElement el = container.FindElement(By.XPath(".//label[text()='Select Vendor']/..//select"), 2);
				if (el == null)
				{
					Report.Error("Could not find the Vendor ID select input element");
					return false;
				}

				var vendorOptions = el.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
				var r = new Random();
				int rInt = r.Next(1, vendorOptions.Count - 1);
				Report.Info("Attempting to select vendor: " + vendorOptions[rInt]);
				el.Select(vendorOptions[rInt]);
				Delay.Seconds(1);
				return el.SelectedOption() == vendorOptions[rInt];
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
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-striped table-hover table-fixed marTop-20']"), 2);
				IWebElement el = container.FindElement(By.XPath($@".//tr[./td[text()=""{retailer}""]]//label[text()='Select Vendor']/..//select"), 2);
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
					string firstOption = options.First();
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
			string xPath = @".//input[@type='checkbox' and parent::td/following-sibling::td[text() =""" + retailerName + @"""]]";
			IWebElement box = this.containerElement.FindElement(By.XPath(xPath), 2);
			return box.TryClick() && box.Checked();
		}

		public bool DeleteSelectedRetailers()
		{
			string xPath = ".//a[@class='btn delete-selected']/i";
			return this.containerElement.FindElement(By.XPath(xPath), 2).TryClick();
		}

		public bool ConfirmDropDownOptionsAreInAlphabeticalOrderForRetailer(string dropDownTitle, string retailer)
		{
			IList<IWebElement> options = this.containerElement.FindElements(By.XPath("//label[contains(text(), '" + dropDownTitle + "')]/following-sibling::select//option"), 2);
			List<string> optionsNames = new List<string>();

			//Remove the default "Choose..." option
			options.RemoveAt(0);

			foreach (var option in options)
			{
				optionsNames.Add(option.Text);
			}

			optionsNames.Sort();

			for (int i = 1; i < options.Count - 1; i++)
			{
				if (options[i].Text != optionsNames[i])
				{
					return false;
				}
			}

			return true;
		}

		public bool SelectTheDeleteSelectedRetailersButton()
		{
			IWebElement deleteButton = this.containerElement.FindElement(By.XPath("//a[@class='btn delete-selected']"), 2);
			return deleteButton.TryClick();
		}

		public bool SelectTheFollowingRetailersInTheRetailersPage(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement checkBox = this.containerElement.FindElement(By.XPath("//td[text()='" + row["Retailers"] + "']/preceding-sibling::td//input"), 2);
				if (checkBox.TryCheck() == false)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckThatTheFollowingRetailersAreSelectedInTheRetailersPopupList(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement retailerCheckBox = this.containerElement.FindElement(By.XPath("//span[text()='" + row["Retailers"] + "']/preceding-sibling::input"), 2);
				if (retailerCheckBox.Checked())
				{
					return true;
				}
			}

			return false;
		}

		public bool SetRetailerCheck()
		{
			IWebElement ele = this.ContainerElement.FindElement(By.XPath(".//input[@id='single-retailer']"));
			
			if (ele.Selected)
			{
				Report.Info("Uncheck the checkbox");
				ele.TryClick();
				return true;
			}
			else if(!ele.Selected)
			{
				Report.Info("check the checkbox");
				ele.TryClick();
				return true;
			}
			return false;
		}

		public bool SubscriptionCheckboxSelectable(bool value)
		{
			IWebElement retailerCheckbox = this.ContainerElement.FindElement(By.XPath(".//input[@id='single-retailer']"));
			if (retailerCheckbox.Enabled==value)
			{
				retailerCheckbox.TryClick();
				Report.Info("Allowed to select the checkbox");
				return value;
			}
			else if (!retailerCheckbox.Enabled == value)
			{
				Report.Info("Not Allowed to select the checkbox");
				return value;
			}
			return true;		
		}

	}
}

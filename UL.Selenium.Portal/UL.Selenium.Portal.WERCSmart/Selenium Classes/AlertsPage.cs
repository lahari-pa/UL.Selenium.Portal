using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Functions;



namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class AlertsPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-body']");
		IWebElement WpsId => this.ContainerElement.FindElement(By.XPath("//input[contains(@data-bind,'wpsId')]"), 2);
		IWebElement NotificationDate => this.ContainerElement.FindElement(By.XPath("//input[contains(@data-bind,'date.field')]"), 2);
		IWebElement ProductName => this.ContainerElement.FindElement(By.XPath("//input[contains(@data-bind,'productName.field')]"), 2);
		private IWebElement SelectDropdown(string label_name) => this.ContainerElement.FindElement(By.XPath($".//label[contains(text(),'{label_name}')]/..//following-sibling::select"), 1);
		private IWebElement Buttons(string buttonLabel) => this.FindElement(By.XPath($".//button[contains(@class,'btn')][text()='{buttonLabel}']"), 1);
		IWebElement MoreFiltersButton => this.ContainerElement.FindElement(By.XPath(".//a[contains(@class,'btn')]//span[text()='More Filters']"), 2);

		#endregion

		#region Page Methods

		public bool WpsIdFieldExists()
		{
			Report.Info("Starting looking for Wps Id field");
			return this.WpsId != null;
		}

		public void WpsIdText(string wpsId)
		{
			this.WpsId.EnterText(wpsId);
		}

		public bool NotificationDateFieldExists()
		{
			Report.Info("Starting looking for NotificationDate field");
			return this.NotificationDate != null;
		}

		public void NotificationDateText(string date)
		{
			this.NotificationDate.EnterText(date);
		}


		public bool ProductNameFieldExists()
		{
			Report.Info("Starting looking for ProductName field");
			return this.ProductName != null;
		}

		public void ProductNameText(string productname)
		{
			this.ProductName.EnterText(productname);
		}

		public bool SelectOptionExists(string label)
		{
			Report.Info($"Attempting to confirm {label}  select option exists.");
			return this.SelectDropdown(label) != null;
		}

		public bool SelectDropdownValue(string label, string item)
		{
			try
			{
				this.SelectDropdown(label).Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exists.");
			return this.Buttons(buttonLabel) != null;
		}

		public bool ButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			return this.Buttons(buttonLabel).TryClick();
		}

		public bool MoreFiltersButtonExists()
		{
			Report.Info($"Attempting to confirm More Filters button exists.");
			return this.MoreFiltersButton != null;
		}

		public bool MoreFiltersButtonClick()
		{
			Report.Info($"Attempting to click More Filters Button button.");
			return this.MoreFiltersButton.TryClick();
		}

		public bool CheckArchivedCheckbox()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(@".//label[contains(text(),'archived messages')]/following-sibling::input[@type='checkbox']"), 2);
			return el.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public IWebElement ArchivedCheckbox()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(@".//label[contains(text(),'archived messages')]/following-sibling::input[@type='checkbox']"), 2);
			if (el == null)
			{
				Report.Info($"Could not find checkbox");
				return null;

			}
			return el;
		}

		//Valid Actions: Details, Resolve
		public bool ForProductClickAction(string name, string action)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]"), 2);
			ReadOnlyCollection<IWebElement> listOfProcuttsRows = productsTable.FindElements(By.XPath(".//tbody/tr"));
			var listOfProducts = listOfProcuttsRows.Select(x => x.FindElement(By.XPath(".//td[2]/span"), 2).Text).ToList();
			if (!listOfProducts.Contains(name))
			{
				Report.Error($"Product Name:{name} does not show in the list. The full list is: " +
											  string.Join(",", listOfProducts));
				return false;
			}
			IWebElement actionsButtonTd = productsTable.FindElement(By.XPath(".//tbody/tr/td[./span[contains(text(),'" + name + "')]]"), 2);
			if (actionsButtonTd == null)
			{
				IList<IWebElement> actionTds = productsTable.FindElements(By.XPath(".//tbody/tr/td[./span]"), 2);
				actionsButtonTd = actionTds.First(x => x.Text.Replace(" ", "") == name.Replace(" ", ""));
			}
			IWebElement actionsButton = actionsButtonTd?.FindElement(By.XPath("..//td//button"), 2);
			if (!actionsButton.TryClick())
			{
				Report.Error("Failed to click actions button!");
				return false;
			}
			Report.Info("Clicked actions button");
			//Actions drop down menu should now open
			IWebElement dropDownMenu = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//button[@aria-expanded='true']/following-sibling::ul[contains(@class,'dropdown-menu')]"), 2);
			var actionLink = (IWebElement)dropDownMenu?.FindElements(By.XPath("./li/a"), 2).FirstOrDefault(x => x.Text == action);
			if (!actionLink.TryClick())
			{
				Report.Error($"Failed to click action: {action}");
				return false;
			}
			Report.Info($"Clicked action: {action}");
			return true;
		}

		//Valid Actions: Details, Resolve
		public string GetTypeForAProduct(string name)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]"), 2);
			ReadOnlyCollection<IWebElement> listOfProcuttsRows = productsTable.FindElements(By.XPath(".//tbody/tr"));
			var listOfProducts = listOfProcuttsRows.Select(x => x.FindElement(By.XPath(".//td[2]/span"), 2).Text).ToList();
			if (!listOfProducts.Contains(name))
			{
				Report.Error($"Product Name:{name} does not show in the list. The full list is: " +
											  string.Join(",", listOfProducts));
			}
			IWebElement typeFieldTd = productsTable.FindElement(By.XPath(".//tbody/tr/td[./span[contains(text(),'" + name + "')]]"), 2);
			IWebElement typeValue = typeFieldTd?.FindElement(By.XPath("..//td[4]/span[1]"), 2);
			return typeValue.Text;

		}

		public string GetResolvePageTitle()
		{
			IWebElement resolvepagetitle = this.FindElement(By.XPath("//div[contains(@class,'inner-header')]//h2"), 2);
			return resolvepagetitle.Text;

		}

		public bool DetailsPopUpDisplayed()
		{
			IWebElement DisplayPopup = this.FindElement(By.XPath("//div[contains(@class,'modal-content')]//h4[text()='Notification Details']"), 2);

			Report.Info($"Verifying detailspop up is displayed");
			return DisplayPopup.Displayed;
		}

		public bool ClickCloseInDetailsPopUp()
		{
			IWebElement CloseButton = this.FindElement(By.XPath("//div[contains(@class,'modal-footer')]//button[text()='Close']"), 2);
			Report.Info($"Clicking close button");
			return CloseButton.TryClick();
		}

		#endregion



	}


}

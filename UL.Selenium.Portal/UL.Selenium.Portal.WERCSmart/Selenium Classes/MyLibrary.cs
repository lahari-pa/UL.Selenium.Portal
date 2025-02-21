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
	public class MyLibraryPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		IWebElement InputText(string text) => this.ContainerElement.FindElement(By.XPath($"//input[contains(@placeholder,'{text}')]"), 2);

		IWebElement SearchButon(string idname) => this.ContainerElement.FindElement(By.XPath($"//div[contains(@id,'{idname}')]//div[@class='input-group']//span[contains(@data-bind,'Click')]"), 2);

		IWebElement Section(string name) => this.ContainerElement.FindElement(By.XPath($"//div[@class='panel-heading']//h3[text()='{name}']"), 2);

		IWebElement Table(string idname) => this.ContainerElement.FindElement(By.XPath($"//div[contains(@id,'{idname}')]//table"), 2);

		IWebElement LinkElement(string tablename, string linkText) => this.ContainerElement.FindElement(By.XPath($".//div[contains(@id,'{tablename}')]//a[text()='{linkText}'] | .//div[contains(@id,'{tablename}')]//a//span[text()='{linkText}']"), 2);
		#endregion

		#region Page Methods
		public bool ForProductClickAction(string name, string action)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]"), 2);
			ReadOnlyCollection<IWebElement> listOfProcuttsRows = productsTable.FindElements(By.XPath(".//tbody//tr"));
			var listOfProducts = listOfProcuttsRows.Select(x => x.FindElement(By.XPath(".//td//div[contains(@data-bind,'Name')]"), 2).Text).ToList();
			if (!listOfProducts.Contains(name))
			{
				Report.Error($"Product Name:{name} does not show in the list. The full list is: " +
											  string.Join(",", listOfProducts));
				return false;
			}
			IWebElement actionsButtonTd = productsTable.FindElement(By.XPath($".//tbody[contains(@data-bind,'products')]//tr//td[div[contains(@data-bind,'Name')][contains(text(),'{name}')]]"), 2);
			if (actionsButtonTd == null)
			{
				IList<IWebElement> actionTds = productsTable.FindElements(By.XPath(".//tbody[contains(@data-bind,'products')]//tr//td//div[contains(@data-bind,'Name')]"), 2);
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
			var actionLink = (IWebElement)dropDownMenu?.FindElements(By.XPath(".//li//a[contains(@data-bind,'click')]"), 2).FirstOrDefault(x => x.Text == action);
			if (!actionLink.TryClick())
			{
				Report.Error($"Failed to click action: {action}");
				return false;
			}
			Report.Info($"Clicked action: {action}");
			return true;
		}

		public bool SectionExists(string sectionname)
		{
			Report.Info($"Starting looking for {sectionname} section");
			return this.Section(sectionname) != null;
		}

		public void EnterText(string fieldname, string text)
		{
			this.InputText(fieldname).ClearTextBox();
			Report.Info("Enter the value for search");
			this.InputText(fieldname).EnterText(text);
		}
		public bool ClickSearch(string tablename)
		{
			return this.SearchButon(tablename).TryClick();
		}

		public bool ProductNameDisplayed(string name)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]"), 2);
			IWebElement productName = productsTable.FindElement(By.XPath($".//tbody[contains(@data-bind,'products')]//tr//td//div[contains(@data-bind,'Name')][contains(text(),'{name}')]"), 2);
			return productName.Displayed;
		}

		public void EnterValueforPPM(string option, string value)
		{
			IWebElement ppmfield = this.FindElement(By.XPath($"//div[@class='form-group cb-ctl has-success']//span[text()='{option}']/ancestor::div[@class='checkbox']/parent::div//input[@type='text']"), 2);
			ppmfield.EnterText(value);
		}


		public bool EnterMyPackagingMaterials(string row, string value)
		{
			IWebElement PackagingMaterialsfield = this.FindElement(By.XPath($"//table//tbody//tr[contains(@class,'rpds')][{row}]//td//select[@class ='form-control']"), 2);
			try
			{
				PackagingMaterialsfield.Select(value);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void EnterMyPackagingWeight(string row, string value)
		{
			IWebElement MyPackagingWeightTextField = this.FindElement(By.XPath($"//table//tbody//tr[contains(@class,'rpds')][{row}]//td//input[@type ='text']"), 2);
			MyPackagingWeightTextField.EnterText(value);
		}

		public bool ProductTableExists(string tablename)
		{
			Report.Info("Starting looking for Table");
			return this.Table(tablename) != null;
		}

		public bool ForBrandsClickEditInAction(string name)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath("//div[@id='brandContainer']//table[contains(@class,'products-table')]"), 2);
			ReadOnlyCollection<IWebElement> listOfProcuttsRows = productsTable.FindElements(By.XPath(".//tbody//tr"));
			var listOfProducts = listOfProcuttsRows.Select(x => x.FindElement(By.XPath(".//td//span[contains(@data-bind,'Phrase')]"), 2).Text).ToList();
			if (!listOfProducts.Contains(name))
			{
				Report.Error($"Product Name:{name} does not show in the list. The full list is: " +
											  string.Join(",", listOfProducts));
				return false;
			}
			IWebElement actionsButtonTd = productsTable.FindElement(By.XPath($".//tbody[contains(@data-bind,'productLines')]//tr//td[span[contains(@data-bind,'Phrase')][contains(text(),'{name}')]]"), 2);
			if (actionsButtonTd == null)
			{
				IList<IWebElement> actionTds = productsTable.FindElements(By.XPath(".//tbody[contains(@data-bind,'productLines')]//tr//td[span[contains(@data-bind,'Phrase')]"), 2);
				actionsButtonTd = actionTds.First(x => x.Text.Replace(" ", "") == name.Replace(" ", ""));
			}
			IWebElement editButton = actionsButtonTd?.FindElement(By.XPath("..//td//a[text()='Edit']"), 2);
			if (!editButton.TryClick())
			{
				Report.Error("Failed to click Edit button!");
				return false;
			}
			Report.Info("Clicked Edit button");
			return true;
		}

		public bool LinkElementClick(string tableName, string linkText)
		{
			return this.LinkElement(tableName, linkText).TryClick();
		}

		public bool LinkElementExists(string tableName, string linkText)
		{
			return this.LinkElement(tableName, linkText) != null;
		}

		public void EnterProductLine(string value)
		{
			IWebElement ProductLineTextField = this.FindElement(By.XPath($"//div[contains(@id,'brand')]//input[contains(@data-bind,'Phrase')]"), 2);
			ProductLineTextField.ClearTextBox();
			ProductLineTextField.EnterText(value);
		}

		public bool CheckActiveCheckbox()
		{
			IWebElement el = this.FindElement(By.XPath(@"//div[contains(@id,'brand')]//input[@type='checkbox']"), 2);
			return el.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public IWebElement ActiveCheckbox()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(@"//div[contains(@id,'brand')]//input[@type='checkbox']"), 2);
			if (el == null)
			{
				Report.Info($"Could not find checkbox");
				return null;
			}
			return el;
		}

		public bool ActiveDisplaysYesOrNo()
		{
			List<IWebElement> activeElement = this.FindElements(By.XPath("//tbody[contains(@data-bind,'productLines')]//tr//td//span[contains(@data-bind,'IsActive')]"), 2).ToList();
			foreach (var element in activeElement)
			{
				string getActiveName = element.Text;
				if (getActiveName == "Yes" || getActiveName == "No")
				{
					Report.Info($"Active value is Yes or No");
					return true;
				}
				return false;
			}
			Report.Info($"Failed to find Active column value");
			return false;


		}

		public bool GetProductLineValue(string name)
		{
			List<IWebElement> productLineElement = this.FindElements(By.XPath("//tbody[contains(@data-bind,'productLines')]//tr//td//span[contains(@data-bind,'Phrase')]"), 2).ToList();
			foreach (var element in productLineElement)
			{
				string getProductLineName = element.Text;
				if (getProductLineName == name)
				{
					Report.Info($"ProductLine value is updated");
					return true;
				}
				return false;
			}
			Report.Info($"Failed to find ProductLine column value");
			return false;


		}

		public bool ForDistributorClickAction(string name, string action)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//div[@id='distributor']//table"), 2);
			ReadOnlyCollection<IWebElement> listOfProcuttsRows = productsTable.FindElements(By.XPath(".//tbody//tr"));
			var listOfProducts = listOfProcuttsRows.Select(x => x.FindElement(By.XPath(".//td[2]"), 2).Text).ToList();// Hard coded the row as td as it does not have any class to define it uniquely.
			if (!listOfProducts.Contains(name))
			{
				Report.Error($"Product Name:{name} does not show in the list. The full list is: " +
											  string.Join(",", listOfProducts));
				return false;
			}
			IWebElement actionsButtonTd = productsTable.FindElement(By.XPath($".//tbody[contains(@data-bind,'DistList')]//tr//td[2]"), 2);
			if (actionsButtonTd == null)
			{
				IList<IWebElement> actionTds = productsTable.FindElements(By.XPath(".//tbody[contains(@data-bind,'DistList')]/tr//td[2]"), 2);
				actionsButtonTd = actionTds.First(x => x.Text.Replace(" ", "") == name.Replace(" ", ""));
			}
			IWebElement actionsButton = actionsButtonTd?.FindElements(By.XPath("..//td//a"), 2).FirstOrDefault(x => x.Text == action);
			if (!actionsButton.TryClick())
			{
				Report.Error($"Failed to click action: {action}");
				return false;
			}
			Report.Info($"Clicked action: {action}");
			return true;
		}


		#endregion



	}


}

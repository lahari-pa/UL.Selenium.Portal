using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.ReqnrollHelpers.Classes;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.WebDriver.Functions;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static iText.IO.Codec.TiffWriter;



namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class MyLibraryPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		IWebElement InputText(string text) => this.ContainerElement.FindElement(By.XPath($"//input[contains(@placeholder,'{text}')]"), 2);

		IWebElement SearchButon => this.ContainerElement.FindElement(By.XPath("//div[@class='input-group']//span[contains(@data-bind,'searchProducts')]"), 2);

		IWebElement Section(string name) => this.ContainerElement.FindElement(By.XPath($"//div[@class='panel-heading']//h3[text()='{name}']"), 2);

		#endregion

		#region Page Methods
		public bool ForProductClickAction(string name, string action)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]"), 2);
			ReadOnlyCollection<IWebElement> listOfProcuttsRows = productsTable.FindElements(By.XPath(".//tbody/tr"));
			var listOfProducts = listOfProcuttsRows.Select(x => x.FindElement(By.XPath(".//td[1]//div[2]"), 2).Text).ToList();
			if (!listOfProducts.Contains(name))
			{
				Report.Error($"Product Name:{name} does not show in the list. The full list is: " +
											  string.Join(",", listOfProducts));
				return false;
			}
			IWebElement actionsButtonTd = productsTable.FindElement(By.XPath($".//tbody/tr/td[./div[contains(text(),'{name}')]]"), 2);
			if (actionsButtonTd == null)
			{
				IList<IWebElement> actionTds = productsTable.FindElements(By.XPath(".//tbody/tr/td//div[2]"), 2);
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
		public bool ClickSearch()
		{
			return this.SearchButon.TryClick();
		}

		public bool ProductNameDisplayed(string name)
		{
			IWebElement productsTable = this.ContainerElement.FindElement(By.XPath(".//table[contains(@class,'products-table')]"), 2);
			IWebElement productName = productsTable.FindElement(By.XPath($".//tbody/tr/td[./div[contains(text(),'{name}')]]"), 2);
			return productName.Displayed;
		}



		#endregion



	}


}

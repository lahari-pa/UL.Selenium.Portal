using UL.Automation.Selenium.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.Generic;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DeleteActiveProducts : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='delete-active-products-grid']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickAcceptButtonInMakeObsoletePopup(string acceptOrCancel)
		{
			IWebElement button = this.containerElement.FindElement(By.XPath("//h3[text()='Make Obsolete']/../following-sibling::div/following-sibling::div//button[text()='" + acceptOrCancel + "']"), 2);
			return button.TryClick();
		}

		public bool SelectCheckboxForProductWithWPSID(string wpsID)
		{
			IWebElement checkbox = this.containerElement.FindElement(By.XPath("//td[@data-bind='text: Product.ProductID'][text()='" + wpsID + "']/preceding-sibling::td//input"), 2);
			return checkbox.TryCheck();
		}

		public bool ClickFilterButtonInDeleteActiveProductsPage()
		{
			IWebElement filterButton = this.containerElement.FindElement(By.XPath("//button[@data-bind='click: searchProducts']"), 2);
			return filterButton.TryClick();
		}

		public bool EnterTextInSearchBarInDeleteActiveProductsPage(string wpsID)
		{
			IWebElement searchBar = this.containerElement.FindElement(By.XPath("//input[@data-bind='textInput: wpsID']"), 2);
			return searchBar.TryEnterText(wpsID);
		}

		public bool SelectCheckBoxNextToWPSIDLabel(string selectOrDeselect)
		{
			IWebElement checkbox = this.containerElement.FindElement(By.XPath("//th[contains(text(), 'WPS ID')]/..//input[@type='checkbox']"), 2);

			if (selectOrDeselect.ToLower() == "select")
			{

				checkbox.TryCheck();
				if (checkbox.Checked())
				{
					return true;
				}

			}
			else if (selectOrDeselect.ToLower() == "deselect")
			{

				checkbox.TryClick();
				if (!checkbox.Checked())
				{
					return true;
				}

			}

			return false;

		}

		public bool ConfirmAllProductsInListAreChecked(string selectedOrDeselected)
		{
			IList<IWebElement> checkboxList = this.containerElement.FindElements(By.XPath("//input[@type='checkbox']"), 2);

			foreach (IWebElement checkBox in checkboxList)
			{
				if (selectedOrDeselected.ToLower() == "selected")
				{
					if (!checkBox.Checked())
					{
						return false;
					}
				}
				else
				{
					if (checkBox.Checked())
					{
						return false;
					}
				}
			}

			return true;
		}

		public bool ClickMakeObsoleteButton()
		{
			IWebElement button = this.containerElement.FindElement(By.XPath("//button[contains(text(), 'Make Obsolete')]"), 2);
			return button.TryClick();
		}

		public bool SelectCheckBoxInMakeObsoletePopup()
		{
			IWebElement checkBox = this.containerElement.FindElement(By.XPath("//div[@class='modal-content']//input[@type='checkbox']"), 2);
			return checkBox.TryCheck();
		}

		public bool SelectRandomCheckBoxes(string savedAs)
		{
			IList<IWebElement> checkboxList = this.containerElement.FindElements(By.XPath("//input[@type='checkbox']"), 2);
			IList<IWebElement> productIDList = this.containerElement.FindElements(By.XPath("//input[@type='checkbox']/../following-sibling::td[@data-bind='text: Product.ProductID']"), 2);
			List<string> productsChecked = new List<string>();
			List<int> indexesChecked = new List<int>();

			Random rnd = new Random();

			for (int i = 0; i < 3; i++)
			{

				int randIndex = rnd.Next(1, checkboxList.Count);

				if (!indexesChecked.Contains(randIndex))
				{

					if (checkboxList[randIndex].TryCheck())
					{
						if (productsChecked.Count == 0)
						{
							productsChecked.Add(productIDList[randIndex].Text);
						}
						else
						{
							productsChecked.Add("," + productIDList[randIndex].Text);
						}
						indexesChecked.Add(randIndex);
					}

				}
				else
				{
					i--;
				}

			}

			Context.AddToContext(savedAs, productsChecked.ToString());

			return true;
		}

		public string GetProductIDFromContext(string savedAs)
		{

			Report.Info("Searching for Product Saved as " + savedAs);

			if (!Context.Contains(savedAs))
			{
				Report.Failure("The reference: " + savedAs + " was not found in context");
				return "";
			}

			string id = "";

			try
			{
				var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
				id = productToSearch.ProductId;
			}
			catch (Exception)
			{
				//do nothing
			}

			//if we didn't get the id try a different object type
			if (id == "")
			{
				try
				{
					var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
					id = productDetails.Id;
				}
				catch (Exception)
				{
					//do nothing
				}

			}

			if (id == "")
			{
				try
				{
					id = Context.GetFromContext(savedAs).ToString();
				}
				catch (Exception)
				{

				}
			}

			return id;

		}
	}
}

using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	class WebElements : SeleniumBaseObject
	{

		public const string BasePath = "";

		protected override By ContainerElementLocator => throw new System.NotImplementedException();

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

		public bool ClickAcceptButtonInMakeObsoletePopup(string acceptOrCancel)
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h3[text()='Make Obsolete']/../following-sibling::div/following-sibling::div//button[text()='" + acceptOrCancel + "']"), 2);
			return button.TryClick();
		}

		public bool SelectCheckboxForProductWithWPSID(string wpsID)
		{
			IWebElement checkbox = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@data-bind='text: Product.ProductID'][text()='" + wpsID + "']/preceding-sibling::td//input"), 2);
			return checkbox.TryCheck();
		}

		public bool ClickFilterButtonInDeleteActiveProductsPage()
		{
			IWebElement filterButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@data-bind='click: searchProducts']"), 2);
			return filterButton.TryClick();
		}

		public bool EnterTextInSearchBarInDeleteActiveProductsPage(string wpsID)
		{
			IWebElement searchBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@data-bind='textInput: wpsID']"), 2);
			return searchBar.TryEnterText(wpsID);
		}

		public bool SelectCheckBoxNextToWPSIDLabel(string selectOrDeselect)
		{
			IWebElement checkbox = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//th[contains(text(), 'WPS ID')]/..//input[@type='checkbox']"), 2);

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
			IList <IWebElement> checkboxList = this.containerElement.FindElements(By.XPath("//input[@type='checkbox']"), 2);

			foreach (IWebElement checkBox in checkboxList)
			{
				if (selectedOrDeselected.ToLower() == "selected")
				{
					if (!checkBox.Checked())
					{
						return false;
					}
				} else
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
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[contains(text(), 'Make Obsolete')]"), 2);
			return button.TryClick();
		}

		public bool SelectCheckBoxInMakeObsoletePopup()
		{
			IWebElement checkBox = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='modal-content']//input[@type='checkbox']"), 2);
			return checkBox.TryCheck();
		}

		public bool SelectRandomCheckBoxes(string savedAs)
		{
			IList<IWebElement> checkboxList = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//input[@type='checkbox']"), 2);
			IList<IWebElement> productIDList = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//input[@type='checkbox']/../following-sibling::td[@data-bind='text: Product.ProductID']"), 2);
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
						} else
						{
							productsChecked.Add("," + productIDList[randIndex].Text);
						}
						indexesChecked.Add(randIndex);
					}

				} else
				{
					i--;
				}

			}

			Context.AddToContext(savedAs, productsChecked.ToString());

			return true;
		}

		public bool CheckIfProductIsMissing(string wpsID)
		{
			IWebElement product = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@data-bind='text: Product.ProductID'][text()='" + wpsID + "']"), 2);
			if (product == null)
			{
				return true;
			}

			return false;

		}







		public bool CloseDialog()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@aria-labelledby='ui-dialog =-title-dialog-supplier-manager']//span[text()='close']"), 2);
			return el.TryClick();
		}
		public bool ConfirmTier(string retailer, string[] arr, string marked)
		{

			IList<IWebElement> el = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//td[contains(text(), '" + retailer + "')]//following-sibling::td"), 2);

			foreach (string str in arr)
			{
				switch (str.ToLower())
				{
					case "tier 1":

						if (el[1].Text != marked)
						{
							return false;
						}

						break;

					case "tier 2.1":

						if (el[2].Text != marked)
						{
							return false;
						}

						break;

					case "tier 2.2":

						if (el[3].Text != marked)
						{
							return false;
						}

						break;

					case "tier 3":

						if (el[4].Text != marked)
						{
							return false;
						}

						break;

					case "tier 4.1":

						if (el[5].Text != marked)
						{
							return false;
						}

						break;

					case "tier 4.2":

						if (el[6].Text != marked)
						{
							return false;
						}

						break;

					default:
						return false;
						break;
				}

			}
			return true;
		}
		public bool ClickTab()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[text()='Data Tier Consent']"), 2);
			return el.TryClick();
		}
		public bool ClickResult()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@title='The WERCS LTD - STAGING']"), 2);
			return el.TryClick();
		}
		public bool SearchText(string text)
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='textSupplierSearch']"), 2);
			return el.TryEnterText(text);
		}
		public bool ClickSearch()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@id='supplierSearchButton']"), 2);
			return el.TryClick();
		}

		public bool ClickSuppliers()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[text()='Suppliers']"), 2);
			return el.TryClick();
		}
		public bool FindRadioButton(string shouldOrShouldNot, string radioButtonText)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//input[@type='radio']//following-sibling::span[text()='" + radioButtonText + "']"), 2);

			if (shouldOrShouldNot.ToLower() == "should")
			{
				if (el == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else if (shouldOrShouldNot.ToLower() == "should not")
			{
				if (el == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			return false;

		}

		public bool CheckAIS()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//label[contains(text(), 'Article Information Sheet (AIS)')]/..//following-sibling::div//div[@class='dropzone']//strong[contains(text(), 'Drop .pdf file here or click \"Browse\"')]"), 2);
			if (el == null)
			{ return false; }
			else
			{ return true; }
		}

		public bool Closepopup()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@data-bind='click: redirectToRetailers']"), 2);
			return el.TryClick();
		}











		public void CheckPopUp()
		{
			Delay.Seconds(5);
			IWebElement productID = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: html']//br[1]/preceding-sibling::text()[1]"), 2);
			IWebElement productType = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: html']//br[1]/following-sibling::text()[1]"), 2);
			IWebElement productAccessCode = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@data-bind='html: html']//br[2]/following-sibling::text()[1]"), 2);
		}

		public bool ChcekForAColumnBetweenTwoColumns(string middleColumn, string leftColumn, string rightColumn)
		{
			IWebElement middleColumnFromLeftColumn = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[text()='" + middleColumn + "']/../preceding-sibling::th//div[text()='" + leftColumn + "']"), 2);
			IWebElement middleColumnFromRightColumn = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[text()='" + middleColumn + "']/../following-sibling::th//div[text()='" + rightColumn + "']"), 2);

			if (middleColumnFromLeftColumn != null && middleColumnFromRightColumn != null)
			{
				return true;
			}

			return false;
		}

		public string FindProductIDWithSpecificLetterInCWColumn(string letter)
		{
			IWebElement productID = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@aria-describedby='list_Waste'][@title='" + letter + "']/preceding-sibling::td[@aria-describedby='list_Product']//span"), 2);
			return productID.Text;
		}

		public bool EnterProductWithIDInSHASearchField(string productID)
		{
			IWebElement searchField = this.containerElement.FindElement(By.XPath("//input[@id='ucSelectProdselectProdTB']"), 2);
			searchField.TryClick();
			return searchField.TryEnterTextAndTab(productID);
		}

		public bool ClickSearchButtonInSHA()
		{
			IWebElement searchButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@class='button-icon icon-refresh'][1]"), 2);
			return searchButton.TryClick();
		}

		public bool ClickVendorReportSection()
		{
			IWebElement vendorReportSection = this.containerElement.FindElement(By.XPath("//span[text()='[SECT0770] Vendor Report']"), 2);
			return vendorReportSection.TryClick();
		}

		public bool ClickASectionInVendorReportSection(string sectionName)
		{
			IWebElement section = this.containerElement.FindElement(By.XPath("//span[text()='[" + sectionName + "]']"), 2);
			return section.TryDoubleClick();
		}

		public bool CheckForTheFollowingText(string text, string shouldOrShouldNot)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//td[contains(text(), '" + text + "')]"), 2);

			if (shouldOrShouldNot.ToLower() == "should")
			{

				if (el != null)
				{
					return true;
				}

				return false;

			}
			else if (shouldOrShouldNot.ToLower() == "should not")
			{

				if (el == null)
				{
					return true;
				}

				return false;

			}

			return false;

		}
	}
}

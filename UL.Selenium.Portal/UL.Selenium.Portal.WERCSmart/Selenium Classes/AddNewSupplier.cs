using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Automation.Utilities.Helpers;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class AddNewSupplier : ModalDialog
	{

		private IWebElement CompanyInput => this.containerElement.FindElement(By.XPath("//select[@id='description' and ./preceding-sibling::label[text()='Company or Brand Name']]"), 2);
		private IWebElement EnterText => SeleniumWebDriver.CurrentDriver.FindElement(By.Id("textSupplierSearch"), 2);
		private IWebElement SearchButton => SeleniumWebDriver.CurrentDriver.FindElement(By.Id("supplierSearchButton"), 2);

		public bool EnterSupplierID(string supplierID)
		{
			Delay.Seconds(2);

			IWebElement SupplierID = this.containerElement.FindElement(By.XPath("//input[@id='supplierID']"), 2);

			if (supplierID == null)
			{
				return false;
			}

			SupplierID.EnterText(supplierID);
			return SupplierID.GetValue() == supplierID;
		}


		public bool EnterSupplierIDExists()
		{
			IWebElement SupplierID = this.containerElement.FindElement(By.XPath("//input[@id='supplierID' and ./preceding-sibling::label[text()='Supplier ID']]"), 2);

			if (SupplierID == null)
			{
				return false;
			}

			return (SupplierID.Enabled && SupplierID.Displayed);
			
		}

		public bool SupplierIDErrorExists()
		{
			IWebElement SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='vendorID_error']"), 2);

			if (SupplierError == null)
			{
				return false;
			}

			return (SupplierError.Enabled && SupplierError.Displayed);
		}

		public string GetSupplierError()
		{
			IWebElement SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='vendorID_error']"), 2);

			if (SupplierError == null)
			{
				return null;
			}

			return SupplierError.GetValue();
		}

		public bool CompanyNameErrorExists()
		{
			Delay.Seconds(2);

			IWebElement SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='description_error']"), 2);

			if (SupplierError == null)
			{
				return false;
			}

			return (SupplierError.Enabled && SupplierError.Displayed && SupplierError.Text != string.Empty);
		}

		public string GetCompanyNameError()
		{
			IWebElement SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='description_error']/span"), 2);

			if (SupplierError == null)
			{
				return null;
			}

			return SupplierError.GetValue();
		}

		public bool EnterCompanyOrBrandName(string companyOrBrandName)
		{
			IWebElement Company = this.containerElement.FindElement(By.XPath("//select[@id='description']"), 2);
			Company.Select(companyOrBrandName);
			return Company.SelectedOption() == companyOrBrandName;
		}

		public bool EnterCompanyOrBrandNameExists()
		{
			try
			{
				var el = this.CompanyInput;
				if (el == null)
				{
					return false;
				}
				return el.Enabled && el.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public List<string> CompanyOrBrandNameOptions()
		{
			var el = this.CompanyInput;
			if (el == null)
			{
				return null;
			}
			var optionEls = el.FindElements(By.XPath("./option"), 1)?.Where(x => !x.GetAttribute("value").IsNullOrEmpty());
			return optionEls.Any() ? optionEls.Select(x => x.Text).ToList() : null;
		}

		public bool SetDefault(bool bDefault)
		{
			IWebElement IsDefault = this.containerElement.FindElement(By.XPath("//input[@type='checkbox']"), 2);
			IsDefault.Check(bDefault);
			return IsDefault.Checked() == bDefault;

		}

		public bool IsDefaultExists()
		{
			try
			{
				IWebElement IsDefault = this.containerElement.FindElement(By.XPath("//input[@type='checkbox']"), 2);
				return (IsDefault.Enabled && IsDefault.Displayed);
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool ClickSave()
		{
			return this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2).FirstOrDefault(x => x.Text == "SAVE").TryClick();
		}


		public bool SaveButtonExists()
		{
			try
			{
				IWebElement SaveButton = this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
					.FirstOrDefault(x => x.Text == "SAVE");
				return (SaveButton.Enabled && SaveButton.Displayed);
			}
			catch (Exception)
			{
				return false;
			}

		}
		public string GetRandomCompanyName()
		{
			string number = MiscHelpers.RandomDigits(4);
			string companyName = "ABC" + number;
			return companyName;
		}

		public void EnterSearchTextInSupplyManager(string savedAs)
		{
			this.EnterText.EnterText(savedAs);
		}

		public void ClickSearchButtonInSupplyManager()
		{
			this.SearchButton.TryClick();
		}

		public IWebElement IfSupplierExists(string supplierName)
		{
			IWebElement NewSupplier = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//table[@id='listSupplierInfo']//td[contains(@title,'{supplierName}')]"), 2);
			return NewSupplier;
		}

		public bool ClickNewSupplierInSupplyManager(string supplierName)
		{
		IWebElement NewSupplier = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//table[@id='listSupplierInfo']//td[contains(@title,'{supplierName}')]"), 2);
		return NewSupplier.TryClick();
		}

		public List<string> AllTabs()
		{
			return SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//div[@id='tabs']/ul/li"), 2).Select(x => x.Text).ToList();
		}

		public List<string> FetaureToggle()
		{
			return SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//form[@id='frmFeatures']//td"), 2).Select(x => x.Text).ToList();
		}

		public bool ClickSelectedTab(string selectTab)
		{
			return SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//div[@id='tabs']/ul/li/a[contains(text(),'{selectTab}')]"), 2).TryClick();
		}

		public bool ClickNewlyAddedSupplierInSupplyManagerWithEmailSearch()
		{
			IWebElement NewSupplier = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//table[@id='listSupplierInfo']"), 2);
			return NewSupplier.TryClick();
		}

		public bool ClickEmailRadioButtonForSearch()
		{
			IWebElement EmailRadioButton = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@id='dialog-supplier-manager']/input[4]"), 2);
			return EmailRadioButton.TryClick();
		}

		public bool EditButton()
		{
			IWebElement EditButton = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//button[@id='btnEdit']"));
				return EditButton.TryClick();
		}

		public bool SaveButton()
		{
			IWebElement saveButton = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//button[@id='btnSubmit']"));
			return saveButton.TryClick();
		}

		public bool BackButton()
		{
			IWebElement BackButton = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//button[@id='btnBack']"));
			return BackButton.TryClick();
		}

		public bool ToggleButton(string toggleName)
		{
			IWebElement Toggle = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//td/label[contains(text(),'"+ toggleName + "')]/../following-sibling::td//span[@class='slider round']"), 2);	
			return Toggle.TryClick();
		}
		public string IsToggleButtonEnabled(string toggleName)
		{
			IWebElement IsToggleEnabled = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//td/label[contains(text(),'" + toggleName + "')]/../following-sibling::td//span[@class='slider round']"),2);
			string color = IsToggleEnabled.GetCssValue("background-color");
			return color.ToString();		
		}
	}
}

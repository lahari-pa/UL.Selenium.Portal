using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class AddNewSupplier : ModalDialog
	{

		private IWebElement CompanyInput => this.containerElement.FindElement(By.XPath("//select[@id='description' and ./preceding-sibling::label[text()='Company or Brand Name']]"), 2);

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

	}
}

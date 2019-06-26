using System;
using System.Linq;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class AddNewSupplier : ModalDialog
	{
		public bool EnterSupplierID(string supplierID)
		{
			var SupplierID = this.containerElement.FindElement(By.XPath("//input[@id='supplierID']"), 2);
			SupplierID.EnterText(supplierID);
			return SupplierID.GetValue() == supplierID;
		}


		public bool EnterSupplierIDExists()
		{
			try
			{
				var SupplierID = this.containerElement.FindElement(By.XPath("//input[@id='supplierID' and ./preceding-sibling::label[text()='Supplier ID']]"), 2);
				return (SupplierID.Enabled && SupplierID.Displayed);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SupplierIDErrorExists()
		{
			try
			{
				var SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='vendorID_error']"), 2);
				return (SupplierError.Enabled && SupplierError.Displayed);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string GetSupplierError()
		{
			try
			{
				var SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='vendorID_error']/span"), 2);
				return SupplierError.GetValue();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public bool CompanyNameErrorExists()
		{
			try
			{
				var SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='description_error']"), 2);
				return (SupplierError.Enabled && SupplierError.Displayed);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string GetCompanyNameError()
		{
			try
			{
				var SupplierError = this.containerElement.FindElement(By.XPath("//p[@id='description_error']/span"), 2);
				return SupplierError.GetValue();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public bool EnterCompanyOrBrandName(string companyOrBrandName)
		{
			var Company = this.containerElement.FindElement(By.XPath("//select[@id='description']"), 2);
			Company.Select(companyOrBrandName);
			return Company.SelectedOption() == companyOrBrandName;
		}

		public bool EnterCompanyOrBrandNameExists()
		{
			try
			{
				var companyInput = this.containerElement.FindElement(By.XPath("//select[@id='description' and ./preceding-sibling::label[text()='Company or Brand Name']]"), 2);
				if (companyInput == null)
				{
					return false;
				}
				return companyInput.Enabled && companyInput.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SetDefault(bool bDefault)
		{
			var IsDefault = this.containerElement.FindElement(By.XPath("//input[@type='checkbox']"), 2);
			IsDefault.Check(bDefault);
			return IsDefault.Checked() == bDefault;

		}

		public bool IsDefaultExists()
		{
			try
			{
				var IsDefault = this.containerElement.FindElement(By.XPath("//input[@type='checkbox']"), 2);
				return (IsDefault.Enabled && IsDefault.Displayed);
			}
			catch (Exception)
			{
				return false;
			}

		}

		public void ClickSave()
		{
			this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
				.FirstOrDefault(x => x.Text == "SAVE").TryClick();
		}


		public bool SaveButtonExists()
		{
			try
			{
				var SaveButton = this.containerElement.FindElements(By.XPath("//div[@class='modal-footer']/button"), 2)
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

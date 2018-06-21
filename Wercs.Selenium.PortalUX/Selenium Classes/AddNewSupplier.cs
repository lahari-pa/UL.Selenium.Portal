using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class AddNewSupplier: ModalDialog
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
				var SupplierID = this.containerElement.FindElement(By.XPath("//input[@id='supplierID']"), 2);
				return (SupplierID.Enabled && SupplierID.Displayed);
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool EnterCompanyOrBrandName(string companyOrBrandName)
		{
			var Company = this.containerElement.FindElement(By.XPath("//input[@id='description']"), 2);
			Company.EnterText(companyOrBrandName);
			return Company.GetValue() == companyOrBrandName;
		}

		public bool EnterCompanyOrBrandNameExists()
		{
			try
			{
				var Company = this.containerElement.FindElement(By.XPath("//input[@id='description']"), 2);
				return (Company.Enabled && Company.Displayed);
			}
			catch (Exception e)
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
			catch (Exception e)
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
			catch (Exception e)
			{
				return false;
			}

		}

	}
}

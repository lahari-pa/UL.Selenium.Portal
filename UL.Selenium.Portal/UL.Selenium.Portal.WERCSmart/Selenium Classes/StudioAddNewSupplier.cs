using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using System.Net.Mail;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioAddNewSupplier : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.Id(@"dialog-supplier-manager-add-newsupplier");

		public bool InAddNewSupplierClickAcceptButton()
		{
			IWebElement AcceptButton = this.ContainerElement.FindElement(By.Id("btnAddNewSupplierSupplierAccount"), 2);
			if (AcceptButton == null)
			{
				Report.Info($"No Accept button has been found");
				return false;
			}

			if (AcceptButton.TryClick())
			{
				return true;
			}
			return false;
		}
		public bool InAddNewSupplierEnterData(string fieldName, string value)
		{
			IWebElement FieldName;
			IWebElement FieldInput;
			string getFieldName;

			List<IWebElement> GetAddNewSupplierFields = this.ContainerElement.FindElements(By.XPath("//table[@class='new-supplier']//tr"), 2).ToList();

			foreach(var field in GetAddNewSupplierFields)
			{
				FieldName = this.ContainerElement.FindElement(By.XPath($"//label[contains(text(), '{fieldName}')]"), 2);
				getFieldName = FieldName.Text;
				if(FieldName == null)
				{
					Report.Info($"Failed to find field {fieldName}");
				}
				 
				if(getFieldName == fieldName)
				{
					FieldInput = this.ContainerElement.FindElement(By.XPath("//input"));
					return FieldInput.TryEnterText(value);

				}

			}
			return false;
		}

	}
}


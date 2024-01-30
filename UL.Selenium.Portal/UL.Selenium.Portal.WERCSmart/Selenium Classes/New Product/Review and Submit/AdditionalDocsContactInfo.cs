using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	public class AdditionalDocsContactInfo : SeleniumBaseObject
	{

		protected override By ContainerElementLocator => By.XPath("//div[@class='panel panel-default panel-table']");

		private IWebElement SubFormatTypeDD => this.ContainerElement.FindElement(By.XPath(".//select[@class='form-control']"), 2);

		private IWebElement Address1 => this.ContainerElement.FindElement(By.XPath(".//td[2]//input[@class='form-control']"), 2);
		private IWebElement Address2 => this.ContainerElement.FindElement(By.XPath(".//td[3]//input[@class='form-control']"), 2);
		private IWebElement Phone => this.ContainerElement.FindElement(By.XPath(".//td[4]//input[@class='form-control']"), 2);
		private IWebElement EmergencyPhone => this.ContainerElement.FindElement(By.XPath(".//td[5]//input[@class='form-control']"), 2);
		private IWebElement Email => this.ContainerElement.FindElement(By.XPath(".//td[4]//input[@class='form-control']"), 2);
		private IWebElement RemoveButton => this.ContainerElement.FindElement(By.XPath(".//td[@class='remove delete-row col-xs-1']"), 2);
		private IWebElement AddRowButton => this.ContainerElement.FindElement(By.XPath(".//td[@class='col-xs-12']//button[@class='btn btn-primary']"), 2); 

		public bool SubFormatTypeDropDownExists()
		{
			Report.Info("Checking to see if the Sub Format Type dropdown exists"); 
			return this.SubFormatTypeDD != null;
		}
		
		 public bool SelectSubFormatType(string value)
		{
			try
			{
				Report.Info("Selecting text from the Sub Format Type Drown down");
				this.SubFormatTypeDD.Select(value);
				return true;
			}
			catch (Exception)
			{
				Report.Info("Could not select an option from the Sub Format Type drop drop"); 
				return false;
			}
		}

		public bool EnterTextAddress1(string text)
		{
			if(this.Address1 != null)
			{
				Report.Info("Attempting to enter text in the first Address textbox");
				return this.Address1.TryEnterText(text); 
			}
			Report.Info("Could not find the first address textbox");
			return false;
		}

		public bool EnterTextAddress2(string text)
		{
			if (this.Address2 != null)
			{
				Report.Info("Attempting to enter text in the second Address textbox");
				return this.Address2.TryEnterText(text);
			}
			Report.Info("Could not find the second address textbox");
			return false;
		}

		public bool EnterTextPhone(string text)
		{
			if (this.Phone != null)
			{
				Report.Info("Attempting to enter text in the Phone textbox");
				return this.Phone.TryEnterText(text);
			}
			Report.Info("Could not find the phone textbox");
			return false;
		}


		public bool EnterTextEmergencyPhone(string text)
		{
			if (this.EmergencyPhone != null)
			{
				Report.Info("Attempting to enter text in the Emergency Phone textbox");
				return this.EmergencyPhone.TryEnterText(text);
			}
			Report.Info("Could not find the Emergency Phone textbox");
			return false;
		}


		public bool EnterTextEmail(string text)
		{
			if (this.Email != null)
			{
				Report.Info("Attempting to enter text in the Email textbox");
				return this.Email.TryEnterText(text);
			}
			Report.Info("Could not find the Email textbox");
			return false;
		}

		public bool ClickRemoveButton()
		{
			if (this.RemoveButton == null)
			{
				Report.Info("Cound not find the remove button");
				return false;
			}
			return this.RemoveButton.TryClick();
		}

		public bool ClickAddRowButton()
		{
			if (this.AddRowButton == null)
			{
				Report.Info("Cound not find the Add Row button");
				return false;
			}
			return this.AddRowButton.TryClick();
		}



	}

}

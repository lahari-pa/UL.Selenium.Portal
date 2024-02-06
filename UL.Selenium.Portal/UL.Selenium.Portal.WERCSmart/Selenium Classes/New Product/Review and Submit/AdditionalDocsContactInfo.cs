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
			if (this.SubFormatTypeDropDownExists())
			{
				if (this.SubFormatTypeDD.FindElements(By.XPath("./option"), 2).All(x => x.Text != value))
				{
					Report.Info("The value was not available in the drop down options!");
					return false;
				}
				Report.Info("Selecting value from the Sub Format Type Drown down");
				this.SubFormatTypeDD.Select(value);
				string selectedValue=this.SubFormatTypeDD.Selected.ToString();
				Report.Info($"Checking if the selected value: {selectedValue} matches the expected value: {value}");
				return selectedValue == value; 
			}			
				Report.Info("Sub Format Drop Down does not exist");
				return false;		
		}

		public bool Address1Exsits()
		{
			Report.Info("Checking to see if the first address textbox exists");
			return this.Address1 != null;
		}

		public bool EnterTextAddress1(string text)
		{

			Report.Info("Attempting to enter text in the first Address textbox");
			return this.Address1.TryEnterText(text); 	
		}

		public bool Address2Exsits()
		{
			Report.Info("Checking to see if the second Address textbox exists");
			return this.Address2 != null;
		}

		public bool EnterTextAddress2(string text)
		{
			
			Report.Info("Attempting to enter text in the second Address textbox");
			return this.Address2.TryEnterText(text);
			
		}

		public bool PhoneExsits()
		{
			Report.Info("Checking to see if the Phone textbox exists");
			return this.Phone != null;
		}

		public bool EnterTextPhone(string text)
		{
		
			Report.Info("Attempting to enter text in the Phone textbox");
			return this.Phone.TryEnterText(text);
			
		}

		public bool EmergencyPhoneExsits()
		{
			Report.Info("Checking to see if the Emergency Phone textbox exists");
			return this.EmergencyPhone != null;
		}

		public bool EnterTextEmergencyPhone(string text)
		{
			
			Report.Info("Attempting to enter text in the Emergency Phone textbox");
			return this.EmergencyPhone.TryEnterText(text);
		
		}

		public bool EmailExsits()
		{
			Report.Info("Checking to see if the Email textbox exists");
			return this.Email != null;
		}

		public bool EnterTextEmail(string text)
		{
			
			Report.Info("Attempting to enter text in the Email textbox");
			return this.Email.TryEnterText(text);
			
		}

		public bool RemoveButtonExsits()
		{
			Report.Info("Checking to see if the Remove button exists");
			return this.RemoveButton != null;
		}

		public bool ClickRemoveButton()
		{			
			Report.Info("Attempting to click the Remove button");
			return this.RemoveButton.TryClick();		
		}

		public bool AddRowButtonExsits()
		{
			Report.Info("Checking to see if the Add Row button exists");
			return this.AddRowButton != null;
		}

		public bool ClickAddRowButton()
		{
			Report.Info("Attempting to click the Add Row button");
			return this.AddRowButton.TryClick();
		}



	}

}

using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SHAWasteClassification : SeleniumBaseObject
	{
		public const string BasePath = "//body";

		public string CheckListEPAType, CheckListEPACode;
		public Dictionary<string, List<string>> StateCode;

		protected override By ContainerElementLocator => By.XPath(BasePath);



		public void GetDataFromTable()
		{

			IWebElement USEPAWasteNumber;
			IWebElement USEPAWasteHazard;
			try
			{
				USEPAWasteNumber = this.FindElement(By.XPath("//table[@class='CanvasSS     XTABLE        ']//font[@face='Arial']//span[@name='EPAN']"));
				USEPAWasteHazard = this.FindElement(By.XPath("//font[@face='Arial']//span[@name='EPAH']"));
			}
			catch (NoSuchElementException)
			{
				return;
			}

			if (USEPAWasteHazard.Text != null)
			{
				this.CheckListEPAType = USEPAWasteHazard.Text;
			}

			if (USEPAWasteNumber.Text != null)
			{
				this.CheckListEPACode = USEPAWasteNumber.Text;
			}

		}

		public Dictionary<string, List<string>> GetStateData(string state)
		{
			this.StateCode = new Dictionary<string, List<string>>();

			IList<IWebElement> StateElements = this.FindElements(By.XPath("//table[@class='CanvasSS     XTABLE        ']//span[contains(text(),\"" + state + " Waste Code\")]/../../..//following-sibling::td[@align='Center']/font/span"));

			List<string> listOfStateElements = new List<string>();

			foreach (IWebElement element in StateElements)
			{
				if (StateElements.Count() > 1)
				{
					if (element.Text != null)
					{
						listOfStateElements.Add(StateElements[StateElements.Count() - 1].Text);
					}
				}
				else
				{
					if (element.Text != null)
					{
						listOfStateElements.Add(element.Text);
					}
				}
			}

			this.StateCode.Add(state, listOfStateElements);

			return this.StateCode;
		}

	}

}

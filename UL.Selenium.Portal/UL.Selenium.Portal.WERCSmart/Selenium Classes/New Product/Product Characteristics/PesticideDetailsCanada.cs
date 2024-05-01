using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class PesticideDetailsCanadaTableRow : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-collapse collapse in']");
		List<IWebElement> PCNFields => this.ContainerElement.FindElements(By.XPath("//tbody//tr")).ToList();
		private IWebElement Row { get; set; }

		IWebElement InputField => this.Row.FindElement(By.XPath(".//input"));
		IWebElement RemoveIcon => this.Row.FindElement(By.XPath(".//i"));
		public PesticideDetailsCanadaTableRow(int rowNumber)
		{
			if (rowNumber < this.PCNFields.Count)
			{
				this.Row = this.PCNFields[rowNumber - 1];
			}
			else
			{
				this.Row = null;
			}
		}
		public bool RowNumberExists()
		{
			return this.Row != null;
		}
		public bool EnterPCN(string value)
		{
			return this.InputField.TryEnterText(value);
		}
		public bool ClickRemoveIcon()
		{
			return this.RemoveIcon.TryClick();
		}
	}

}

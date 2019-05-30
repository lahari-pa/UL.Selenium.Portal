using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class RegulatoryInformation1 : NewProduct
	{
		public string TscaStatus {
			get
			{
				var listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TSCA"))
					.FindElements(By.XPath("../..//input"));
				foreach (var item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label")).Text;
					}
				}
				return "";
			}
			set
			{
				var thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("TSCA")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				var optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}
		}
	}
}

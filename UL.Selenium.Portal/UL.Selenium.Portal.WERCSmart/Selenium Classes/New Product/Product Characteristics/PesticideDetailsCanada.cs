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
	 class PesticideDetailsCanada : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-collapse collapse in']");
		List<IWebElement> PCNFields => this.ContainerElement.FindElements(By.XPath("//tbody//tr")).ToList();

		public bool EnterPCN(int rowNumber, string value)
		{
			IWebElement InputField;
			bool result = false;
			int i = 0;
			if(this.PCNFields.Count < rowNumber-1)
			{
				Report.Info($"There is no row # {rowNumber} in the table 'Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product'");
			}
			else
			{
				foreach (IWebElement element in this.PCNFields)
				{
					if(i == rowNumber - 1)
					{
						InputField = element.FindElement(By.XPath(".//input"));
						if(InputField == null)
						{
							Report.Info("Cannot find input field");
						}
						else
						{
							result = InputField.TryEnterText(value);
						}
						break;
					}
					i++;
				}

			}
			return result;
		}
		public bool ClickRemoveIcon(int rowNumber)
		{

			IWebElement RemoveIcon;
			bool result = false;
			int i = 0;
			if (this.PCNFields.Count < rowNumber - 1)
			{
				Report.Info($"There is no row # {rowNumber} in the table 'Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product'");
			}
			else
			{
				foreach (IWebElement element in this.PCNFields)
				{
					if (i == rowNumber - 1)
					{
						RemoveIcon = element.FindElement(By.XPath(".//i"));
						if (RemoveIcon == null)
						{
							Report.Info("Cannot find remove icon");
						}
						else
						{
							result = RemoveIcon.TryClick();
						}
						break;
					}
					i++;
				}

			}
			return result;
		}
	}
}

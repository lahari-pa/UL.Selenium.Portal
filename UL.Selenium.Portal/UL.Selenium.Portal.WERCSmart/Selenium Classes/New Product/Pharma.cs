using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class Pharma : NewProduct
	{

		public List<string> CheckForOptions(Table table)
		{
			List<string> optionsNotFoundList = new List<string>();
			foreach (TableRow row in table.Rows)
			{
				IWebElement el = this.containerElement.FindElement(By.XPath("//label[contains(text(),'" + row["Option"] + "')]"), 2);

				if (el == null)
				{
					optionsNotFoundList.Add(row["Option"]);
				}
			}

			return optionsNotFoundList;
		}

		public bool ClickNDCField()
		{

			IWebElement el = this.containerElement.FindElement(By.XPath("//span[contains(@class,'select2-selection select2-selection--single')]"), 2);

			return el.TryClick();

		}
		public bool SelectFirstNDCNumberOption()
		{

			IWebElement el = this.containerElement.FindElement(By.XPath("//ul[@class='select2-results__options']//li[1]"), 2);

			return el.TryClick();

		}

		public bool EnterNDCNumber(string number)
		{

			IWebElement el1 = this.containerElement.FindElement(By.XPath("//input[@class='select2-search__field']"), 2);

			el1.TryEnterText(number);
			if (el1.Text == number)
			{
				return true;
			}
			return false;
		}
		public bool CheckAndFillEmptyFieldsInSPLInformationScreen()
		{
			IList<IWebElement> allFieldsOnPage = this.containerElement.FindElements(By.XPath("//input[@type='text']"), 2);

			foreach (IWebElement field in allFieldsOnPage)
			{
				bool enteredText = false;

				if (field.Text == "")
				{
					enteredText = field.TryEnterText("Test");

					if (!enteredText)
					{
						return false;
					}

				}
			}

			return true;
		}

	}
}

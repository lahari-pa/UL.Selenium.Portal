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

			IWebElement el = this.containerElement.FindElement(By.XPath("//input[@class='select2-search__field']"), 2);

			return el.TryEnterText(number);

		}
		
		public bool CheckAndFillEmptyFieldsInPharmaIngredientsScreen()
		{
			IList<IWebElement> allFieldsOnPage = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//span[contains(text(),'For all components entered percentage should be greater than 0. Formulation must total or exceed 100%.')]/../preceding-sibling::input"), 2);

			foreach (IWebElement field in allFieldsOnPage)
			{
				bool enteredText = false;

				if (field.Text.Length < 1)
				{

					enteredText = field.TryEnterText("1");

					if (!enteredText)
					{
						return false;
					}

				}
			}

			return true;
		}

		public bool CheckAndFillEmptyFieldsInSPLInformationScreen()
		{
			IList<IWebElement> allFieldsOnPage = this.containerElement.FindElements(By.XPath("//span[contains(text(),'This is a required field')]/../preceding-sibling::input"), 2);
	
			foreach (IWebElement field in allFieldsOnPage)
			{
				bool enteredText = false;
			
				if (field.Text.Length < 1)
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

		public bool CheckAndFillEmptyFieldsInIngredeientsScreen()
		{
			IList<IWebElement> allFieldsOnPage = this.containerElement.FindElements(By.XPath("//span[contains(text(),'For all components entered percentage should be greater than 0. Formulation must total or exceed 100%.')]/../preceding-sibling::input"), 2);

			foreach (IWebElement field in allFieldsOnPage)
			{
				bool enteredText = false;

				if (field.Text.Length < 1)
				{

					enteredText = field.TryEnterText("1");

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

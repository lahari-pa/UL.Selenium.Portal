using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Extensions;


namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class OptionalReports : NewProduct
	{
		public bool SelectInputForSection(string section, string selection)
		{
			IWebElement sectionHeader = this.ContainerElement.FindElement(By.XPath($@".//div[span[contains(text(), '{section}')]]"), 2);
			if (sectionHeader == null)
			{
				Report.Info($"Could not find section title {section} on page.");
				return false;
			}

			IWebElement input = sectionHeader.FindElement(By.XPath($@"./following-sibling::div//input"), 2);
			if (input == null)
			{
				Report.Info($"Could not find input field for section '{section}'.");
				return false;
			}

			bool clickInput = input.TryClick();

			if (!clickInput)
			{
				Report.Info($"Failed to click input for section '{section}'.");
				return false;
			}

			IWebElement select = this.ContainerElement.FindElement(By.XPath($@"//span[@class='select2-container select2-container--default select2-container--open']//li[contains(text(), '{selection}')]"), 2);

			if (select == null)
			{
				Report.Info($"Could not find input field for section '{selection}'.");
				return false;
			}

			return select.TryClick();
		}

		public bool CheckTotalForSection(string section, string value)
		{
			IWebElement total = this.ContainerElement.FindElement(By.XPath($@".//div[div[span[contains(text(), '{section}')]]]/following-sibling::div//span[contains(@data-bind, 'total')]"), 2);
			if (total == null)
			{
				Report.Info($"Could not find Total text for section '{section}'.");
				return false;
			}

			if (total.Text == value)
			{
				return true;
			}
			else
			{
				Report.Info($"Failed to find text '{value} ' in section '{section}'. Found text: '{total.Text}'.");
				return false;
			}
		}
	}
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.GenerateIntentionallyBadData;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit;
using UL.Automation.Utilities.Helpers;
using Mailosaur;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "StepsPrototype")]
	class Steps_Prototype
	{
		[StepDefinition(@"I set the radio option in section: (.*) to: (.*)")]
		public void SetRadioOptionInSectionTo(string section, string option)
		{
			Report.IsTrue(new NewProduct().SelectRadio(section, option),
				$"Failed to select radio option in section: '{section}' to option: '{option}'",
				$"Successfully set radio option: '{option}'");
		}

		[StepDefinition(@"I set the (.*) field to: (.*)")]
		[StepDefinition(@"I set the (.*) option to: (.*)")]
		public void SetTheSectionOptionTo(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			if (option.StartsWith("UPC"))
			{
				var value = Context.GetFromContext(option)?.ToString();
				if (value == null)
				{
					throw new Exception($"Could not find item in context: { value } for checking field input is correct value!");
				}
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), value.Trim()),
					$"Failed to set the input to {value.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {value.Trim()} in section: { section.Trim()}");
				Delay.Seconds(1);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
					$"Failed to set the input to {option.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {option.Trim()} in section: {section.Trim()}");
				Delay.Seconds(1);
			}
		}

		public void ClickContinue()
		{
			Report.IsTrue(new NewProduct().ClickContinue(), "Failed to click 'Continue'!", "Clicked 'Continue' successfully");
		}

		public void ClickLinkElement(string linkText)
		{
			if (Report.IsTrue(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}"))
			{
				Report.IsTrue(new NewProduct().LinkElementClick(linkText), $"Failed to click link element with text {linkText}", $"Successfully clicked link element with text {linkText}");
			}
		}
	}
}

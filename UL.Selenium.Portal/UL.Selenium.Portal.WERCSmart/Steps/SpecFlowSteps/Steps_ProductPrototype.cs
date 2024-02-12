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
using ReportDetails = UL.Automation.Reporting.Classes.ReportDetails;
using System.IO;
using System.Drawing.Imaging;
using BoDi;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Steps_ProductPrototype")]
	class Steps_ProductPrototype
	{
		[StepDefinition(@"In section: (.*), set select option: (.*)")]
		public void InSectionSetOption(string section, string option)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			if(Report.IsTrue(productPrototype != null,$"Failure, '{section}' section does not exist.",$"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.OptionExists(option),$"Failure, '{option}' radio option does not exist.",$"Success, '{option}' radio option exists."))
				{
					Report.IsTrue(productPrototype.OptionSelect(option),$"Failure, failed to select '{option}' option.",$"Success, selected '{option}' option.");
				}
			}
		}

		[StepDefinition(@"In section: (.*), confirm option: (.*) (is|is not) selected")]
		public void InSectionConfirmOptionIsIsNotSelected(string section, string option, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.OptionExists(option), $"Failure, '{option}' radio option does not exist.", $"Success, '{option}' radio option exists."))
				{
					Report.IsTrue(productPrototype.OptionSelected(option) == expected, $"Failure, failed to confirm '{option}' option {is_isnot} selected.", $"Success, confirmed '{option}' option {is_isnot} selected.");
				}
			}
		}

		[StepDefinition(@"In section: (.*), enter text: (.*)")]
		public void InSectionEnterText(string section, string text)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype.ContainerVisible(), $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.TextInputExists(), $"Failure, text input does not exist.", $"Success, text input exists."))
				{
					Report.IsTrue(productPrototype.TextInputEnterText(text), $"Failure, failed to enter '{text}' input text.", $"Success, entered '{text}' input text.");
				}
			}
		}

		[StepDefinition(@"In section: (.*), confirm text: (.*) (is|is not) displayed")]
		public void InSectionConfirmTextIsIsNotDisplayed(string section, string text, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.TextInputExists(), $"Failure, text input does not exist.", $"Success, text input exists."))
				{
					Report.IsTrue(string.Equals(productPrototype.TextInputGetText(),text) == expected, $"Failure, failed to confirm '{text}' input text {is_isnot} displayed.", $"Success, confirmed '{text}' input text {is_isnot} displayed.");
				}
			}
		}

		[StepDefinition(@"In section: (.*), click search text box")]
		public void InSectionEnterSearchText(string section)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists.");
			Report.IsTrue(productPrototype.SearchInputSpanExists(), $"Failure, search input span does not exist.", $"Success, search input span exists.");
			Report.IsTrue(productPrototype.SearchInputSpanClick(), $"Failure, failed to click search input span.", $"Success, clicked search input span.");
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
		}

		[StepDefinition(@"In search input pop-up, enter text: (.*)")]
		public void InSearchPopUpEnterText(string searchText)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
			Report.IsTrue(searchBoxPrototype.SearchInputEnterText(searchText),$"Failure, failed to enter '{searchText}' in search input box.",$"Success, entered '{searchText}' in search input box.");
		}

		[StepDefinition(@"In search input pop-up, search alert '(.*)' (is|is not) displayed")]
		public void InSearchPopUpAlertIsIsNotDisplayed(string alertText, string is_isnot)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			bool expected = is_isnot == "is";
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
			Report.IsTrue(searchBoxPrototype.SearchResultAlertExists(alertText) == expected, $"Failure, failed to confirm search alert '{alertText}' {is_isnot} displayed.", $"Success, confirmed search alert '{alertText}' {is_isnot} displayed.");
		}

		[StepDefinition(@"In the search input pop-up, '(.*)' search result (is|is not) displayed")]
		public void InSearchPopUpResultIsIsNotDisplayed(string searchText, string is_isnot)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			bool expected = is_isnot == "is";
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(searchBoxPrototype.SearchResultTextExists(searchText) == expected, $"Failure, '{searchText}' search result {(expected?"is not":"is")} displayed.", $"Success, '{searchText}' search result {is_isnot} displayed.");
		}

		[StepDefinition(@"In the search input pop-up, search and select: (.*)")]
		public void InSearchPopUpSearchAndSelect(string searchText)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
			Report.IsTrue(searchBoxPrototype.SearchInputEnterText(searchText), $"Failure, failed to enter '{searchText}' in search input box.", $"Success, entered '{searchText}' in search input box.");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(searchBoxPrototype.SearchResultTextExists(searchText), $"Failure, '{searchText}' search result is not displayed.", $"Success, '{searchText}' search result is displayed.");
			Report.IsTrue(searchBoxPrototype.SearchResultTextGet(searchText).Click(), $"Failure, failed to click '{searchText}' search result.", $"Success, clicked '{searchText}' search result.");
			searchBoxPrototype.WaitForContainerToBeInvisible();
		}

		[StepDefinition(@"In section (.*), error message '(.*)' (is|is not) displayed")]
		public void InSectionErrorMessageIsIsNotDisplayed(string section, string errorMessage, string is_isnot)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			bool expected = is_isnot == "is";
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				Report.IsTrue(productPrototype.ErrorMessageExists(errorMessage) == expected, $"Failure, '{errorMessage}' error message {(expected ? "is not" : "is")} displayed.", $"Success, '{errorMessage}' error message {is_isnot} displayed.");
			}
		}
	}
}

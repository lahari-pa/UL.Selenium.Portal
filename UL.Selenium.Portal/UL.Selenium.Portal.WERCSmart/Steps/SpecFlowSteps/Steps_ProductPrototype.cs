using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Steps_ProductPrototype")]
	class Steps_ProductPrototype
	{
		[RegexStepDefinition(@"In section: (.*), set select option: (.*)")]
		public void InSectionSetOption(string section, string option)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.OptionExists(option), $"Failure, '{option}' option does not exist.", $"Success, '{option}' option exists."))
				{
					Report.IsTrue(productPrototype.OptionSelect(option), $"Failure, failed to select '{option}' option.", $"Success, selected '{option}' option.");
				}
			}
		}
		[RegexStepDefinition(@"In section: (.*), verify option: (.*) (is|is not) displayed")]
		public void InSectionVerifyOption(string section, string option, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				Report.IsTrue(productPrototype.OptionExists(option) == expected, $"Failure, '{option}' option {(expected ? "is not" : "is")} displayed for section {section}.", $"Success, '{option}' option {is_isnot} displayed for section {section}.");
			}
		}

		[RegexStepDefinition(@"In section: (.*), set option: (.*) so it (is|is not) selected")]
		public void InSectionSetOptionIsIsNotSelected(string section, string option, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.OptionExists(option), $"Failure, '{option}' radio option does not exist.", $"Success, '{option}' radio option exists."))
				{
					Report.IsTrue(productPrototype.OptionSetSelect(expected, option), $"Failure, failed to set '{option}' option so it {is_isnot} selected.", $"Success, set '{option}' option so it {is_isnot} selected.");
				}
			}
		}

		[RegexStepDefinition(@"In section: (.*), confirm option: (.*) (is|is not) selected")]
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
		[RegexStepDefinition(@"In section: (.*), confirm option(.*) (is|is not) highlighted with color: (.*)")]
		public void InSectionOptionBackground(string section, string option, string is_isnot, string color)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.OptionExists(option), $"Failure, '{option}' option does not exist.", $"Success, '{option}' option exists."))
				{
					Report.IsTrue(productPrototype.GetOptionColorBackground(option) == color == expected, $"Failure, failed to confirm '{option}' option's background color {is_isnot} '{color}'.", $"Success, confirmed '{option}' option's background color {is_isnot} '{color}'");
				}
			}
		}
		[RegexStepDefinition(@"In section: (.*), get background color for option (.*) and save it as: (.*)")]
		public void InSectionGetOptionBackgroundColor(string section, string option, string saveAs)
		{
			string color;
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.OptionExists(option), $"Failure, '{option}' option does not exist.", $"Success, '{option}' option exists."))
				{
					color = productPrototype.GetOptionColorBackground(option);
					Report.IsTrue(!color.IsNullOrEmpty(), $"Failure, failed to get option's background color", $"Successfully got option's background color");
					Context.AddToContext(saveAs, color);
				}
			}
		}

		[RegexStepDefinition(@"In section: (.*), enter text: (.*)")]
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

		[RegexStepDefinition(@"In section: (.*), confirm text: (.*) (is|is not) displayed")]
		public void InSectionConfirmTextIsIsNotDisplayed(string section, string text, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.TextInputExists(), $"Failure, text input does not exist.", $"Success, text input exists."))
				{
					Report.IsTrue(string.Equals(productPrototype.TextInputGetText(), text) == expected, $"Failure, failed to confirm '{text}' input text {is_isnot} displayed.", $"Success, confirmed '{text}' input text {is_isnot} displayed.");
				}
			}
		}
		[RegexStepDefinition(@"For section: (.*), confirm text: (.*) (is|is not) displayed as option")]
		public void InSectionConfirmTextIsIsNotDisplayedAsOption(string section, string text, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ProductPrototype productPrototype = new ProductPrototype(section);
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				if (Report.IsTrue(productPrototype.TextFieldExists(), $"Failure, text field does not exist.", $"Success, text field exists."))
				{
					Report.IsTrue(string.Equals(productPrototype.TextFieldGetText(), text) == expected, $"Failure, failed to confirm '{text}' text {is_isnot} displayed.", $"Success, confirmed '{text}' text {is_isnot} displayed.");
				}
			}
		}
		[RegexStepDefinition(@"In section: (.*), click search text box")]
		public void InSectionClickSearchText(string section)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists.");
			Report.IsTrue(productPrototype.SearchInputSpanExists(), $"Failure, search input span does not exist.", $"Success, search input span exists.");
			Report.IsTrue(productPrototype.SearchInputSpanClick(), $"Failure, failed to click search input span.", $"Success, clicked search input span.");
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
		}

		[RegexStepDefinition(@"In search input pop-up, enter text: (.*)")]
		public void InSearchPopUpEnterText(string searchText)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
			Report.IsTrue(searchBoxPrototype.SearchInputEnterText(searchText), $"Failure, failed to enter '{searchText}' in search input box.", $"Success, entered '{searchText}' in search input box.");
		}

		[RegexStepDefinition(@"In search input pop-up, search alert '(.*)' (is|is not) displayed")]
		public void InSearchPopUpAlertIsIsNotDisplayed(string alertText, string is_isnot)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			bool expected = is_isnot == "is";
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
			Report.IsTrue(searchBoxPrototype.SearchResultAlertExists(alertText) == expected, $"Failure, failed to confirm search alert '{alertText}' {is_isnot} displayed.", $"Success, confirmed search alert '{alertText}' {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In the search input pop-up, '(.*)' search result (is|is not) displayed")]
		public void InSearchPopUpResultIsIsNotDisplayed(string searchText, string is_isnot)
		{
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			bool expected = is_isnot == "is";
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(searchBoxPrototype.SearchResultTextExists(searchText) == expected, $"Failure, '{searchText}' search result {(expected ? "is not" : "is")} displayed.", $"Success, '{searchText}' search result {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In the search input pop-up, search and select: (.*)")]
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

		[RegexStepDefinition(@"In section (.*), error message '(.*)' (is|is not) displayed")]
		public void InSectionErrorMessageIsIsNotDisplayed(string section, string errorMessage, string is_isnot)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			bool expected = is_isnot == "is";
			if (Report.IsTrue(productPrototype != null, $"Failure, '{section}' section does not exist.", $"Success, '{section}' section exists."))
			{
				Report.IsTrue(productPrototype.ErrorMessageExists(errorMessage) == expected, $"Failure, '{errorMessage}' error message {(expected ? "is not" : "is")} displayed.", $"Success, '{errorMessage}' error message {is_isnot} displayed.");
			}
		}
		[RegexStepDefinition(@"The (.*) question (is|is not) displayed")]
		public void ThenInThePageIShouldOrShouldNotSeeQuestion(string question, string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new ProductPrototype(question).WaitForContainerToBeVisible() == expected,
				$"Failure, question {question} {(expected ? "is not" : "is")} displayed", $"Success, question {question} {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"Expand the (.*) panel")]
		public void ExpandPanel(string panelLabel)
		{
			PanelPrototype panelPrototype = new PanelPrototype(panelLabel);
			if (Report.IsTrue(panelPrototype.PanelExpandButtonExists(), $"Failure, '{panelLabel}' panel does not exist.", $"Success, '{panelLabel}' panel exists."))
			{
				Report.IsTrue(panelPrototype.PanelExpandButtonClick(), $"Failure, failed to click '{panelLabel}' panel.", $"Success, clicked '{panelLabel}' panel.");
				//Report.IsTrue(!panelPrototype.PanelExpandButtonExists(), $"Failure, failed to expand '{panelLabel}' panel.", $"Success, expanded '{panelLabel}' panel.");
			}
		}

		[RegexStepDefinition(@"In the (.*) section, for field '(.*)' error message '(.*)' (is|is not) displayed")]
		public void InSectionForfieldErrorMessageIsIsNotDisplayed(string section, string field, string errorMessage, string is_isnot)
		{
			ProductPrototype productPrototype = new ProductPrototype(section);
			bool expected = is_isnot == "is";
			Report.IsTrue(productPrototype.ErrorMessageForField(field, errorMessage) == expected, $"Failure, '{errorMessage}' error message {(expected ? "is not" : "is")} displayed.", $"Success, '{errorMessage}' error message {is_isnot} displayed.");
		}

	}
}

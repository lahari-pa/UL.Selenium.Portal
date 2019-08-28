using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Text.RegularExpressions;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "DataSummarySheet")]
	class StepsDataSummarySheet
	{
		// 'battery_manufacturer: (.*)' set in row["Manufacturer] will fetch value from context
		[StepDefinition(@"I should see the following batteries present:")]
		public void ThenIShouldSeeTheFollowingBatteriesPresent(Table information)
		{
			IEnumerable<Battery> expected = information.CreateSet<Battery>();
			var dataSummarySheet = new DataSummary();
			List<Battery> displayed = dataSummarySheet.GetDisplayedBatteries();
			foreach (Battery expectedBattery in expected)
			{
				Report.Info("Checking battery saved as: " + expectedBattery.SavedAs);
				if (expectedBattery.Manufacturer.ToLower().StartsWith("saved as"))
				{
					expectedBattery.Manufacturer = Context.GetFromContext("battery_manufacturer: " + expectedBattery.SavedAs)?.ToString();
				}
				if (expectedBattery.Manufacturer == null)
				{
					throw new Exception("Failed to get manufacturer from context!");
				}
				Report.Info("Expected Type: " + expectedBattery.BatteryType);
				Report.Info("Expected Manufacturer: " + expectedBattery.Manufacturer);
				Report.Info("Expected Number per package: " + expectedBattery.NumberPerPackage);
				Report.IsTrue(displayed.Any(x => x.BatteryType == expectedBattery.BatteryType &&
												 x.Manufacturer == expectedBattery.Manufacturer &&
												 x.NumberPerPackage == expectedBattery.NumberPerPackage &&
												 x.RequiredToRun == expectedBattery.RequiredToRun),
					"Battery saved as " + expectedBattery.SavedAs + " was not found on the summary page!",
					"Battery saved as " + expectedBattery.SavedAs + " was found on the summary page");
			}
		}


		[StepDefinition(@"I confirm that I see the following option for private label question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForPrivateLabelQuestion(string message)
		{
			var dataSummarySheet = new DataSummary();
			string found = dataSummarySheet.GetPrivateLabelStatement();

			Report.IsTrue(found.Trim() == message.Trim(),
				"private label option was not as expected! Expected: " + message + ", but found: " + found + "!",
				"private label option was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I confirm that I see the following option for Product has been granted an Alternative Control Plan question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForProductHasBeenGrantedAnAlternativeControlPlanQuestion(string message)
		{
			var dataSummarySheet = new DataSummary();
			string found = dataSummarySheet.GetAlternativeControlPlanQuestion();

			Report.IsTrue(found.Trim() == message.Trim(),
				"option was not as expected! Expected: " + message + ", but found: " + found + "!",
				"option was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I confirm that I see the following option for Product does not contain more than grams of VOC per use question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForProductDoesNotContainMoreThanGramsOfVOCPerUseQuestion(string message)
		{
			var dataSummarySheet = new DataSummary();
			string found = dataSummarySheet.GetGramsOfVocPerUseAsDefinedCaliforniaConsumerProductsQuestion();

			Report.IsTrue(found.Trim() == message.Trim(),
				"option was not as expected! Expected: " + message + ", but found: " + found + "!",
				"option was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"Product Name should be showing value: (.*)")]
		public void ProductNameShouldBeShowingFollowing(string option)
		{
			var dataSummarySheet = new DataSummary();


			string found = dataSummarySheet.SGetProductName();

			Report.IsTrue(found.Contains(option),
				"Expected: " + option + " but got: " + found,
				"Got value: " + option + " as expected.");

			//Report.IsTrue(found.Contains(option), "Failed to find the option: " + option + "!", "Successfully found the option: " + option + "!", false, false);
		}

		[StepDefinition(@"(.*) document section should be showing the following document: (.*)")]
		public void DocumentSectionShouldBeShowingTheFollowingDocument(string section, string option)
		{
			var dataSummarySheet = new DataSummary();

			string found = dataSummarySheet.GetDocumentForSection(section, option);

			Report.IsTrue(found.Contains(option),
				"Expected: " + option + " but got: " + found + " for section " + section + ".",
				"Got value: " + option + " as expected for section " + section + ".");
		}

		[StepDefinition(@"I click the View button for section: (.*)")]
		public void IClickTheViewButtonForDocument(string section)
		{
			var dataSummarySheet = new DataSummary();

			Report.IsTrue(dataSummarySheet.ClickViewForDocument(section),
				"Failed to click the View button for section " + section + ".",
				"Successfully clicked the View button for section " + section + ".");
		}

		[StepDefinition(@"(.*) should be showing the following option: (.*)")]
		public void ShouldBeShowingFollowing(string section, string option)
		{
			var dataSummarySheet = new DataSummary();


			List<string> found = dataSummarySheet.GetInfoForSectionOption(section, option);

			Report.IsTrue(found.Contains(option),
					"option was not as expected! Expected: " + option + " in section: " + section + " but got: " + string.Join(",", found),
					"option was showing: " + option + " in section: " + section);

			//Report.IsTrue(found.Contains(option), "Failed to find the option: " + option + "!", "Successfully found the option: " + option + "!", false, false);
		}

		[StepDefinition(@"The Data Summary section (.*) should be showing the following UPC table:")]
		public void ShouldBeShowingTheFollowingTable(string section, Table table)
		{
			var dataSummarySheet = new DataSummary();

			ICollection<string> headers = table.Header;

			Report.IsTrue(dataSummarySheet.ConfirmHeaders(headers, section), "Could not find the appropriate headers",
				"Found all the appropriate headers");
			TableRows rows = table.Rows;
			Report.IsTrue(dataSummarySheet.ConfirmCaseUPC(rows, section), "Could not find Case UPC information.",
				"Successfully found Case UPC information.");
			Report.IsTrue(dataSummarySheet.ConfirmUPC(rows, section), "Could not find UPC information.",
				"Successfully found UPC information.");
		}

		[StepDefinition(@"I confirm that the Data Summary section (.*) shows the value for (.*) saved as: (.*) for UPC saved as: (.*)")]
		public void IConfirmThatTheDataSummarySectionShowsValueSavedAs(string section, string header, string savedAs, string upc)
		{
			var dataSummarySheet = new DataSummary();
			string value = Context.GetFromContext(savedAs)?.ToString() ?? "";
			upc = Context.GetFromContext(upc)?.ToString() ?? "";

			Report.IsTrue(dataSummarySheet.ConfirmUPCInformation(section, header, value, upc), "Failed to find value " + value + " for header " + header + " in Data Summary screen.",
					"Successfully found value " + value + " for header " + header + " in Data Summary screen.");
		}

		[StepDefinition(@"The data summary window should be showing")]
		public void TheDataSummaryWindowShouldBeShowing()
		{
			var dataSummarySheet = new DataSummary();
			Report.IsTrue(dataSummarySheet.WaitForSpinner(), "Data summary screen is not showing",
				"Data summary screen is showing");
		}

		[StepDefinition(@"Get Ingredients from Data Summary Window and add to product saved as (.*)")]
		public void GetIngredientsFromDataSummaryWindowAndAddToProductSavedAs(string savedAs)
		{
			if (Context.Contains(savedAs))
			{
				var thisProductInformation = (ProductInformation)Context.GetFromContext(savedAs);
				thisProductInformation.ListOfIngredients = new DataSummary().GetIngredients();
			}
			else
			{
				Report.Failure("Product saved as: " + savedAs + " was not found.");
			}
		}

		[StepDefinition(@"Get transparency ratio and save as (.*)")]
		public void GetTransparencyRatioAndSaveAs(string saveAs)
		{
			decimal transparencyRatio = new DataSummary().GetTransparencyRatio();
			if (transparencyRatio > -1)
			{
				Context.AddToContext(saveAs, transparencyRatio);
			}

			Report.IsTrue(transparencyRatio > -1, "Failed to get tranparency ratio", "Saved transparency ratio");
		}

		[StepDefinition(@"Confirm that transparency ratio is (.*) / (.*)")]
		public void GivenConfirmThatTransparencyRatioSavedAsTRAfterIs(string numerator, string denominator)
		{
			var thisDataSummary = new DataSummary();
			string actualRatio = thisDataSummary.SGetTransparencyRatio();
			string pattern = @"([0123456789\.]*)\s*\/\s*([0123456789\.]*)";
			System.Text.RegularExpressions.Match regMatch = System.Text.RegularExpressions.Regex.Match(actualRatio, pattern);
			if (!regMatch.Success || regMatch.Groups.Count != 3)
			{
				Report.Failure("Actual ratio was not as expected. It is: " + actualRatio);
			}
			Report.IsTrue(regMatch.Groups[1].ToString() == numerator, "Numerator was expected to be: " + numerator + " but is: " + regMatch.Groups[1].ToString(), "As expected, numerator is: " + numerator);
			Report.IsTrue(regMatch.Groups[2].ToString() == denominator, "Denominator was expected to be: " + denominator + " but is: " + regMatch.Groups[1].ToString(), "As expected, denominator is: " + denominator);

		}

		[StepDefinition(@"I confirm that the Transparency Ratio underneath Ingredients equals: (.*)")]
		public void IConfirmThatTheTransparencyRatioEquals(string savedAs)
		{
			string transRatio = Context.GetFromContext(savedAs)?.ToString();
			string pattern = @"(\d)\s\/\s(\d)";
			Match regMatch = Regex.Match(transRatio, pattern);
			string numerator = regMatch.Groups[1].ToString();
			string denominator = regMatch.Groups[2].ToString();

			var thisDataSummary = new DataSummary();
			string pattern2 = @"([0123456789\.]*)\s*\/\s*([0123456789\.]*)";
			string actualRatio = thisDataSummary.SGetTransparencyRatio();
			Match regMatch2 = Regex.Match(actualRatio, pattern2);
			if (!regMatch2.Success || regMatch2.Groups.Count != 3)
			{
				Report.Failure("Actual ratio was not as expected. It is: " + actualRatio);
			}
			Report.IsTrue(regMatch2.Groups[1].ToString() == numerator, "Numerator was expected to be: " + numerator + " but is: " + regMatch.Groups[1].ToString(), "As expected, numerator is: " + numerator);
			Report.IsTrue(regMatch2.Groups[2].ToString() == denominator, "Denominator was expected to be: " + denominator + " but is: " + regMatch.Groups[1].ToString(), "As expected, denominator is: " + denominator);
		}

		[StepDefinition(@"I take a screenshot of the ingredients")]
		public void GivenITakeAScreenshotOfTheIngredients()
		{
			var thisDataSummary = new DataSummary();
			thisDataSummary.WaitForSpinner();
			thisDataSummary.ScrollToIngredients();
			Report.Screenshot();
		}

		[Then(@"In the Data Summary window the (first|second) component should have Public Name: (.*) and Publicly Disclosed: (Yes|No)")]
		public void ThenInTheDataSummaryWindowTheSecondComponentShouldHavePublicNameAndPubliclyDisclosed(string firstOrSecond, string publicName, string publiclyDisclosed)
		{
			var thisDataSummary = new DataSummary();
			List<Ingredients.Ingredient> listOfIngredients = thisDataSummary.GetIngredients();
			Ingredients.Ingredient thisIngredient = listOfIngredients[0];
			if (firstOrSecond.ToLower() == "second")
			{
				thisIngredient = listOfIngredients[1];
			}

			if (publicName.ToLower().Contains("saved as"))
			{
				publicName = Context.GetFromContext(publicName.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim()).ToString();
			}
			Report.Info("Looking for " + firstOrSecond + " component with public name: " + publicName + " and publicly disclosed: " + publiclyDisclosed);
			Report.Info(listOfIngredients.Count.ToString() + " ingredients found:");
			for (int i = 0; i < listOfIngredients.Count; i++)
			{
				Report.Info((i + 1).ToString() + ": " + listOfIngredients[i].GetDetails());
			}
			Report.IsTrue(thisIngredient.PublicallyDisclosed == (publiclyDisclosed == "Yes"),
				"For ingredient: " + thisIngredient.CASNumber + " expected publicly disclosed: " + publiclyDisclosed,
				"As expected, for ingredient " + thisIngredient.ComponentName + " publicly Disclosed is showing as: " + publiclyDisclosed);

			Report.IsTrue(thisIngredient.PublicName == publicName,
				"For ingredient: " + thisIngredient.ComponentName + " expected public name: " + publicName + " but got: " + thisIngredient.PublicName,
				"As expected, for ingredient " + thisIngredient.ComponentName + " public name is showing as: " + publicName);
		}

	}
}

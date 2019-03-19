using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Universal_Functions;
using NTTQA_Reporting_Module.Reporting.Core;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes.New_Product;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "DataSummarySheet")]
	class StepsDataSummarySheet
	{
		[StepDefinition(@"I should see the following batteries present:")]
		public void ThenIShouldSeeTheFollowingBatteriesPresent(Table information)
		{
			var expected = information.CreateSet<Battery>();
			var dataSummarySheet = new DataSummary();
			var displayed = dataSummarySheet.GetDisplayedBatteries();
			foreach (var expectedBattery in expected)
			{
				Report.Info("Checking battery with type: " + expectedBattery.BatteryType + " and Manufacturer: " + expectedBattery.Manufacturer);
				var matchingType = displayed.Where(x => x.BatteryType == expectedBattery.BatteryType);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No batteries of type: " + expectedBattery.BatteryType + " were displayed!");
					continue;
				}

				bool passed = false;
				foreach (var matched in matchingType)
				{
					if (matched.Manufacturer.Contains(expectedBattery.Manufacturer) && matched.NumberPerPackage == expectedBattery.NumberPerPackage && matched.RequiredToRun == expectedBattery.RequiredToRun)
					{
						passed = true;
						break;
					}
				}

				Report.IsTrue(passed, "Battery was not found on the data summary screen!", "Battery was successfully found on the data summary screen!");
			}
		}


		[StepDefinition(@"I confirm that I see the following option for private label question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForPrivateLabelQuestion(string message)
		{
			var dataSummarySheet = new DataSummary();
			var found = dataSummarySheet.GetPrivateLabelStatement();

			Report.IsTrue(found.Trim() == message.Trim(),
				"private label option was not as expected! Expected: " + message + ", but found: " + found + "!",
				"private label option was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I confirm that I see the following option for Product has been granted an Alternative Control Plan question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForProductHasBeenGrantedAnAlternativeControlPlanQuestion(string message)
		{
			var dataSummarySheet = new DataSummary();
			var found = dataSummarySheet.GetAlternativeControlPlanQuestion();

			Report.IsTrue(found.Trim() == message.Trim(),
				"option was not as expected! Expected: " + message + ", but found: " + found + "!",
				"option was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I confirm that I see the following option for Product does not contain more than grams of VOC per use question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForProductDoesNotContainMoreThanGramsOfVOCPerUseQuestion(string message)
		{
			var dataSummarySheet = new DataSummary();
			var found = dataSummarySheet.GetGramsOfVocPerUseAsDefinedCaliforniaConsumerProductsQuestion();

			Report.IsTrue(found.Trim() == message.Trim(),
				"option was not as expected! Expected: " + message + ", but found: " + found + "!",
				"option was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"(.*) should be showing the following option: (.*)")]
		public void ShouldBeShowingFollowing(string section, string option)
		{
			var dataSummarySheet = new DataSummary();
			var found = dataSummarySheet.GetInfoForSectionOption(section, option);

			Report.IsTrue(found.Contains(option),
					"option was not as expected! Expected: " + option + " in section: " + section,
					"option was showing: " + option + " in section: " + section);

			//Report.IsTrue(found.Contains(option), "Failed to find the option: " + option + "!", "Successfully found the option: " + option + "!", false, false);
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
				ProductInformation thisProductInformation = (ProductInformation)Context.GetFromContext(savedAs);
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
			var transparencyRatio = new DataSummary().GetTransparencyRatio();
			if (transparencyRatio > -1)
			{
				Context.AddToContext(saveAs, transparencyRatio);
			}

			Report.IsTrue(transparencyRatio > -1, "Failed to get tranparency ratio", "Saved transparency ratio");
		}

		[StepDefinition(@"Confirm that transparency ratio is (.*) / (.*)")]
		public void GivenConfirmThatTransparencyRatioSavedAsTRAfterIs(string numerator, string denominator)
		{
			DataSummary thisDataSummary = new DataSummary();
			string actualRatio = thisDataSummary.sGetTransparencyRatio();
			string pattern = @"([0123456789\.]*)\s*\/\s*([0123456789\.]*)";
			var regMatch = System.Text.RegularExpressions.Regex.Match(actualRatio, pattern);
			if (!regMatch.Success || regMatch.Groups.Count != 3)
			{
				Report.Failure("Actual ratio was not as expected. It is: " + actualRatio);
			}
			Report.IsTrue(regMatch.Groups[1].ToString() == numerator, "Numerator was expected to be: " + numerator + " but is: " + regMatch.Groups[1].ToString(), "As expected, numerator is: " + numerator);
			Report.IsTrue(regMatch.Groups[2].ToString() == denominator, "Denominator was expected to be: " + denominator + " but is: " + regMatch.Groups[1].ToString(), "As expected, denominator is: " + denominator);

		}

		[StepDefinition(@"I take a screenshot of the ingredients")]
		public void GivenITakeAScreenshotOfTheIngredients()
		{
			DataSummary thisDataSummary = new DataSummary();
			thisDataSummary.WaitForSpinner();
			thisDataSummary.ScrollToIngredients();
			Report.Screenshot();
		}

		[Then(@"In the Data Summary window the (first|second) component should have Public Name: (.*) and Publicly Disclosed: (Yes|No)")]
		public void ThenInTheDataSummaryWindowTheSecondComponentShouldHavePublicNameAndPubliclyDisclosed(string firstOrSecond, string publicName, string publiclyDisclosed)
		{
			DataSummary thisDataSummary = new DataSummary();
			List<Ingredients.Ingredient> listOfIngredients = thisDataSummary.GetIngredients();
			var thisIngredient = listOfIngredients[0];
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
				Report.Info((i+1).ToString() + ": " + listOfIngredients[i].getDetails());
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

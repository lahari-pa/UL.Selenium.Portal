using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "NewProduct")]
	public class Steps_ProductCharacteristics
	{
		[StepDefinition(@"I set 'Specific Gravity' to: (.*)")]
		public void SetSpecificGravityTo(string specificGravity)
		{
			Report.IsTrue(new ProductCharacteristics().WaitForTab("Product Type"), "Product type has not loaded","Product Type tab is loaded.");
			Report.Info("Entering text: " + specificGravity + " to the Specific Gravity field");
			new ProductCharacteristics().SpecificGravity = specificGravity;
			Report.IsTrue(new ProductCharacteristics().SpecificGravity == specificGravity, "Failed to set Specific Gravity", "Successfully set Specific Gravity");
		}

		[StepDefinition(@"I set 'pH' to: (.*)")]
		public void SetPHTo(string pH)
		{
			Report.IsTrue(new ProductCharacteristics().WaitForTab("Product Type"), "Product type has not loaded", "Product type tab is loaded.");
			Report.Info("Entering text: " + pH + " to the pH field");
			new ProductCharacteristics().PH = pH;
			Report.IsTrue(new ProductCharacteristics().PH == pH, "Failed to set pH", "Successfully set pH");
		}

		[StepDefinition(@"I set 'Boiling point \(in Celsius\)' to: (.*)")]
		public void SetBoilingPointInCelsiusTo(string boilingPointInCelsius)
		{
			Report.IsTrue(new ProductCharacteristics().WaitForTab("Product Type"), "Product type has not loaded", "Product type tab is loaded.");
			Report.Info("Entering text: " + boilingPointInCelsius + " to the Boiling Point field");
			new ProductCharacteristics().BoilingPoint = boilingPointInCelsius;
			Report.IsTrue(new ProductCharacteristics().BoilingPoint == boilingPointInCelsius, "Failed to set Boiling Point", "Successfully set Boiling Point");
		}

		[StepDefinition(@"I set 'Flash point \(in Celsius\)' to: (.*)")]
		public void SetFlashPointInCelsiusTo(string flashPointInCelsius)
		{
			Report.IsTrue(new ProductCharacteristics().WaitForTab("Product Type"), "Product type has not loaded", "Product type tab is loaded.");
			Report.Info("Entering text: " + flashPointInCelsius + " to the Flash Point field");
			new ProductCharacteristics().FlashPoint = flashPointInCelsius;
			Report.IsTrue(new ProductCharacteristics().FlashPoint == flashPointInCelsius, "Failed to set Flash Point", "Successfully set Flash Point");
		}

		[StepDefinition(@"I should only see the following options for Primary Physical State:")]
		public void PrimaryPhysicalOptionsShowingCorrectly(Table table)
		{
			var expected = new List<string>();
			table.Rows.ForEach(x => expected.Add(x["State"]));
			var found = new NewProduct().ListOfPrimaryPhysicalStates();
			Report.Info("Primary Physical States found: " + string.Join(", ", found));
			foreach (var state in expected)
			{
				if (Report.IsTrue(found.Contains(state), "Failed to find state: " + state + " in the list!", state + " was successfully found!"))
				{
					found.Remove(state);
				}
			}
			Report.IsTrue(found.Count == 0,
				$@"There were physical states displayed which were not expected! Only expected: ""{string.Join(", ", expected.Select(x => $"'{x}'").ToList())}"". Also displaued were: ""{string.Join(", ", found.Select(x => $"'{x}'").ToList())}""" + string.Join(", ", found),
				$@"Only the expected physical states: ""{string.Join(", ", expected.Select(x => $"'{x}'").ToList())}"" were displayed.");
		}

		[StepDefinition(@"I set the Primary Physical State to be: (.*)")]
		public void SetThePrimayPhysicalStateTo(string state)
		{
			Report.Info("Selecting the radio input: " + state);
			new ProductCharacteristics().PrimaryPhysicalState = state;
			Report.IsTrue(new ProductCharacteristics().PrimaryPhysicalState == state, "Failed to set the primary physical state", "Successfully set the Primary Physical State");
		}

		[StepDefinition(@"I set the Secondary Physical State to be: (.*)")]
		public void ThenISetTheSecondaryPhysicalStateToBe(string state)
		{
			Report.IsTrue(new NewProduct().SelectSecondaryPhysicalState(state), "Failed to set the secondary physical state to be: " + state, "Successfully set the Secondary Physical State to be: " + state);
		}

		[StepDefinition(@"I set the water solubility description to: (.*)")]
		public void ThenISetTheWaterSolubilityDescriptionTo(string description)
		{
			NewProduct thisNewProduct = new NewProduct();
			new NewProduct().WaterSolubility = description;
			Report.IsTrue(thisNewProduct.WaterSolubility == description, "Failed to set the water solubility description to be: " + description, "Successfully set the water solubility description to be: " + description);
		}

		[StepDefinition(@"in the Product Characteristics tab, for Flash Point Testing Method Used status I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabForFlashPointTestingMethodUsedStatusISelect(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - in the Product Characteristics tab, for Flash Point Testing Method Used status I select: " + option);
			try
			{
				var selNewProduct = new NewProduct();
				//Report.IsTrue(selNewProduct.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				//	"Product characteristics tab is loaded.");


				selNewProduct.FlashPointTestingMethodUsed = option;

				Report.IsTrue(selNewProduct.FlashPointTestingMethodUsed == option,
					"Failed to set Flash point testing method used status: " + option,
					"Successfully set Flash point testing method used status: " + option);


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I set the Select the best Water Solubility description to be: (.*)")]
		public void GivenISetTheSelectTheBestWaterSolubilityDescriptionToBe(string option)
		{
			Report.IsTrue(new NewProduct().SelectBestWaterSolubilityDescription(option), "Failed to set the best Water Solubility description to be: " + option, "Successfully set the best Water Solubility description to be: " + option);
		}

	}
}

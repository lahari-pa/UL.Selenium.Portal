using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "NewProduct")]
	public class Steps_ProductCharacteristics
	{
		private ProductCharacteristics ProductCharacteristics => new ProductCharacteristics();

		[RegexStepDefinition(@"I set 'Relative Density' to: (.*)")]
		public void SetSpecificGravityTo(string specificGravity)
		{
			Report.IsTrue(this.ProductCharacteristics.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product Type tab is loaded.");
			Report.Info("Entering text: " + specificGravity + " to the Relative Density field");
			this.ProductCharacteristics.SpecificGravity = specificGravity;
			Report.IsTrue(this.ProductCharacteristics.SpecificGravity == specificGravity, "Failed to set Relative Density", "Successfully set Relative Density");
		}

		[RegexStepDefinition(@"I set 'pH' to: (.*)")]
		public void SetPHTo(string pH)
		{
			Report.IsTrue(this.ProductCharacteristics.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			Report.Info("Entering text: " + pH + " to the pH field");
			this.ProductCharacteristics.PH = pH;
			Report.IsTrue(this.ProductCharacteristics.PH == pH, "Failed to set pH", "Successfully set pH");
		}

		[RegexStepDefinition(@"I set 'Boiling point \(in Celsius\)' to: (.*)")]
		public void SetBoilingPointInCelsiusTo(string boilingPointInCelsius)
		{
			Report.IsTrue(this.ProductCharacteristics.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			Report.Info("Entering text: " + boilingPointInCelsius + " to the Boiling Point field");
			this.ProductCharacteristics.BoilingPoint = boilingPointInCelsius;
			Report.IsTrue(this.ProductCharacteristics.BoilingPoint == boilingPointInCelsius, "Failed to set Boiling Point", "Successfully set Boiling Point");
		}

		[RegexStepDefinition(@"I set 'Flash point \(in Celsius\)' to: (.*)")]
		public void SetFlashPointInCelsiusTo(string flashPointInCelsius)
		{
			Report.IsTrue(this.ProductCharacteristics.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			Report.Info("Entering text: " + flashPointInCelsius + " to the Flash Point field");
			this.ProductCharacteristics.FlashPoint = flashPointInCelsius;
			Report.IsTrue(this.ProductCharacteristics.FlashPoint == flashPointInCelsius, "Failed to set Flash Point", "Successfully set Flash Point");
		}

		[RegexStepDefinition(@"I should only see the following options for Primary Physical State:")]
		public void PrimaryPhysicalOptionsShowingCorrectly(Table table)
		{
			var expected = new List<string>();
			table.Rows.Cast<TableRow>().ToList().ForEach(x => expected.Add(x["State"]));
			List<string> found = new NewProduct().ListOfPrimaryPhysicalStates();
			Report.Info("Primary Physical States found: " + string.Join(", ", found));
			foreach (string state in expected)
			{
				if (Report.IsTrue(found.Contains(state), $"Failed to find state: { state } in the list!", $"{ state } was successfully found!"))
				{
					found.Remove(state);
				}
			}
			Report.IsTrue(found.Count == 0,
				$@"There were physical states displayed which were not expected! Only expected: ""{string.Join(", ", expected.Select(x => $"'{x}'").ToList())}"". Also displaued were: ""{string.Join(", ", found.Select(x => $"'{x}'").ToList())}""" + string.Join(", ", found),
				$@"Only the expected physical states: ""{string.Join(", ", expected.Select(x => $"'{x}'").ToList())}"" were displayed.");
		}

		[RegexStepDefinition(@"I set the Primary Physical State to be: (.*)")]
		public void SetThePrimayPhysicalStateTo(string state)
		{
			Report.Info($"Selecting the radio input: { state}");
			this.ProductCharacteristics.PrimaryPhysicalState = state;
			Report.IsTrue(new ProductCharacteristics().PrimaryPhysicalState == state, "Failed to set the primary physical state", "Successfully set the Primary Physical State");
		}

		[RegexStepDefinition(@"I set the Secondary Physical State to be: (.*)")]
		public void ThenISetTheSecondaryPhysicalStateToBe(string state)
		{
			Report.IsTrue(new NewProduct().SelectSecondaryPhysicalState(state), "Failed to set the secondary physical state to be: " + state, "Successfully set the Secondary Physical State to be: " + state);
		}

		[RegexStepDefinition(@"I set the water solubility description to: (.*)")]
		public void ThenISetTheWaterSolubilityDescriptionTo(string description)
		{
			var thisNewProduct = new NewProduct();
			new NewProduct().WaterSolubility = description;
			Report.IsTrue(thisNewProduct.WaterSolubility == description, "Failed to set the water solubility description to be: " + description, "Successfully set the water solubility description to be: " + description);
		}

		[RegexStepDefinition(@"in the Product Characteristics tab, for Flash Point Testing Method Used status I select: (.*)")]
		public void GivenInTheProductCharacteristicsTabForFlashPointTestingMethodUsedStatusISelect(string option)
		{
			var selNewProduct = new NewProduct();
			selNewProduct.FlashPointTestingMethodUsed = option;
			Report.IsTrue(selNewProduct.FlashPointTestingMethodUsed == option,
				"Failed to set Flash point testing method used status: " + option,
				"Successfully set Flash point testing method used status: " + option);
		}

		[RegexStepDefinition(@"I set the Select the best Water Solubility description to be: (.*)")]
		public void GivenISetTheSelectTheBestWaterSolubilityDescriptionToBe(string option)
		{
			Report.IsTrue(new NewProduct().SelectBestWaterSolubilityDescription(option), "Failed to set the best Water Solubility description to be: " + option, "Successfully set the best Water Solubility description to be: " + option);
		}

	}
}

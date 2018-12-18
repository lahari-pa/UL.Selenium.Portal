using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "UPC")]
	class StepsUPC
	{

		[StepDefinition(@"I click the 'Add Case UPC' button")]
		public void ThenIClickTheAddCaseUpcButton()
		{
			Report.IsTrue((new UPC()).ClickAddCaseUpcButton(), "Failed to click the 'Add Case UPC' button!", "Successfully clicked the 'Add Case UPC' button");
		}

		[StepDefinition(@"I should (see|not see) the following UPC options:")]
		public void ShouldSeeTheUPCOptions(string condition, Table expected)
		{
			var selNewProduct = new UPC();
			var upcOptions = selNewProduct.GetUPCOptions();
			if (condition == "see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Option"];
					Report.Info("Checking that I see the option '" + option + "'");
					Report.IsTrue(upcOptions.Contains(option.Trim()),
						"Option was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", upcOptions) + "'!",
						"Option was showing: '" + option + "', as expected!");
				}
			}
			if (condition == "not see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Option"];
					Report.Info("Checking that I see the option '" + option + "'");
					Report.IsFalse(upcOptions.Contains(option.Trim()),
						"Options were showing which should not be. The sections not allowed are: " + string.Join("; ", option) + ". Actual sections: " + string.Join("; ", option), "Sections were not showing as expected: " + string.Join("; ", option));
				}
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I enter the text: (.*) in the 'Select Existing Registrations to include in the Kit' field")]
		public void EnterTextInSearchByIDOrProductNameField(string value)
		{
			var selUPC = new UPC();
			Report.IsTrue(selUPC.EnterTextToSearchField(value),
				"Failed to enter text: " + value + " to the search field",
				"Successfully entered text: " + value + " to the search field");
			Delay.Seconds(2);
		}

		[StepDefinition(@"I save first selectable Product ID as: (.*) under the Select Products tab")]
		public void SaveSelectableProductID(string savedAs)
		{
			var selKit = new UPC();
			var id = selKit.SelectProducts_FirstProductID();
			if (id == null)
			{
				Report.Failure("Could not find the product ID for the first selectable product!");
				return;
			}
			Report.Info("Saving Product ID: " + id + " to context as: " + savedAs);
			Context.AddToContext(savedAs, id);
		}

		[StepDefinition(@"I select the product with ID saved as: (.*) under the Select Products tab")]
		public void SelectProductByIDSavedAs(string savedAs)
		{
			var selForwardProductReg = new UPC();
			if (savedAs.ToLower().Contains("list"))
			{
				var ids = (List<string>)Context.GetFromContext(savedAs);
				if (ids == null)
				{
					Report.Failure("Could not find product IDs in context saved as: " + savedAs);
					return;
				}
				bool clicked = false;
				foreach (var id_ in ids)
				{
					Report.Info("Attempting to select product with id: " + id_);
					EnterTextInSearchByIDOrProductNameField(id_);
					if (selForwardProductReg.SelectProducts_ClickProductByID(id_))
					{
						Report.Success("Successfully selected product with ID: " + id_);
						Report.Screenshot();
						clicked = true;
						break;
					}
				}
				if (!clicked)
				{
					Report.Failure("Failed to select any of the products with ID in the list saved as: " + savedAs);
					Report.Screenshot();
				}
			}
			else
			{
				var id = Context.GetFromContext(savedAs)?.ToString();
				if (id == null)
				{
					Report.Failure("Could not find product ID in context saved as: " + savedAs);
					return;
				}
				EnterTextInSearchByIDOrProductNameField(id);
				Report.Screenshot();
				Report.IsTrue(selForwardProductReg.SelectProducts_ClickProductByID(id),
					"Failed to select the product with ID: " + id + "!",
					"Successfully selected the product with ID: " + id);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;


namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Cart")]
	class Steps_Cart
	{
		[StepDefinition(@"I click the (.*) input section in Optional Reports and Documents Available for Purchase and select (.*)")]
		public void IClickTheInputSectionAndSelect(string section, string selection)
		{
			var reports = new OptionalReports();

			Report.IsTrue(reports.SelectInputForSection(section, selection), "Failed to select input '" + selection + "' for section '" + section + "'.",
				"Successfully selected input '" + selection + "' for section '" + section + "'.");
		}

		[StepDefinition(@"The total for section (.*) should equal (.*)")]
		public void TotalForSectionShouldEqual(string section, string value)
		{
			var reports = new OptionalReports();

			Report.IsTrue(reports.CheckTotalForSection(section, value), "Failed to find the correct value '" + value + "' for section '" + section + "'.",
				"Successfully found correct value '" + value + "' for section '" + section + "'.");
		}

		[StepDefinition(@"In the Purchase Summary screen I click Remove for product (.*)")]
		public void InThePurchaseSummaryScreenIClickRemove(string product)
		{
			var newProduct = new NewProduct();

			if (product.ToLower().Contains("saved as"))
			{
				object savedAsItem = Context.GetFromContext(product.Replace("saved as", "").Trim());
				if (savedAsItem.GetType() == typeof(string))
				{
					product = savedAsItem.ToString();
				}
				else
				{
					product = ((ProductInformation)savedAsItem).Id;
				}
			}

			Report.IsTrue(newProduct.PurchaseSummaryClickRemove(product), "Failed to click Remove for product '" + product + "'.",
				"Successfully clicked Remove for product '" + product + "'.");
		}

	}
}

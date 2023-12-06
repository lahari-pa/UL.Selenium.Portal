using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	internal class BeverageRegulatoryDetails
	{

		[StepDefinition(@"I enter the text of Does your product contain a Prop 65 chemical field to: (Yes|No)")]
		public void GivenEnterProductContainAProp65ChemicalValue(string value)
		{
			Report.Info("I set the text of Does your product contain a Prop 65 chemical field to: " + value);
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Does your product contain a Prop 65 chemical?", value);
		}

		[StepDefinition(@"I enter the text of Percent of Alcohol in the Product field to: (.*)")]
		public void GivenEnterPercentOfAlcoholInTheProductValue(string value)
		{
			Report.Info("I set the text of Does your product contain a Prop 65 chemica field to: " + value);
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Percent of Alcohol in the Product (numeric entry only)", value);
		}

	}
}

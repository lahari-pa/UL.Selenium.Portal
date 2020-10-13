using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

	namespace UL.Selenium.Portal.WERCSmart.Philip
{

	[Binding, Scope(Tag = "StepDefinitions")]
	class Stepdefinitions
	{

		[Given(@"I confirm the drop down for Document Purpose type Shows: (.*)")]
		public void GivenIConfirmTheDropDownForDocumentPurposeTypeShows(string option)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmDocumentPurposeTypeOption(option), "Failed to display option: " + option, "Successfully displayed option: " + option);
		}


	}
}

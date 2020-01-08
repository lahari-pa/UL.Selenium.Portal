using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "RegulatoryDocsToProvide")]
	class Steps_RegulatoryDocumentsToProvide
	{
		[StepDefinition(@"in Regulatory Documents to Provide I select: (.*) for the: (.*) question")]
		public void GivenISelectForTheQuestion_(string answer, string question)
		{
			var regDocs = new RegulatoryDocumentsToProvide();
			Report.IsTrue(regDocs.SetAnswerToQuestion(question, answer), string.Format("Unable to set question: {0} to answer: {1}", question, answer), string.Format("Successfully set question: {0} to answer: {1}", question, answer));
		}

	}
}

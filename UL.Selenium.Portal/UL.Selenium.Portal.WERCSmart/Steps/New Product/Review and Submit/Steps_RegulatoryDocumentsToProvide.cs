using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "RegulatoryDocsToProvide")]
	class Steps_RegulatoryDocumentsToProvide
	{
		[RegexStepDefinition(@"in Regulatory Documents to Provide I select: (.*) for the: (.*) question")]
		public void GivenISelectForTheQuestion_(string answer, string question)
		{
			var regDocs = new RegulatoryDocumentsToProvide();
			Report.IsTrue(regDocs.SetAnswerToQuestion(question, answer), string.Format("Unable to set question: {0} to answer: {1}", question, answer), string.Format("Successfully set question: {0} to answer: {1}", question, answer));
		}

	}
}

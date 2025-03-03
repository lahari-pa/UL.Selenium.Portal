using Reqnroll;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding]
	public class Steps_Flow2A
	{
		[Given(@"I call Shared step 65961 \(Additional Documents to Provide - Upload Full Product Label - Continue\)")]
		public void GivenICallSharedStepAdditionalDocumentsToProvide_UploadFullProductLabel_Continue()
		{
			ReportSettings.UseSubSteps = true;
			var MyNewProductSteps = new StepsNewProduct();
			Report.StartStep(
					@"I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			MyNewProductSteps.UploadPDFFileSectionAndType("Please upload a PDF of the product label (full label).",
				"Provide Full Product Label (required)", @"UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
			Report.StartStep("In the Additional Documents to Provide page I click Continue");
			MyNewProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");

		}


	}
}

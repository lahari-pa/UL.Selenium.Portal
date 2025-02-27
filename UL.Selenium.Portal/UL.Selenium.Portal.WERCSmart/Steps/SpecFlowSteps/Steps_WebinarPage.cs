using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "WebinarPage")]
	class Steps_WebinarPage
	{
		[RegexStepDefinition(@"In the Webinar Page, click the 'UL Solutions Training Website' link")]
		public void ClickTheULSolutionsTrainingWebsiteLink()
		{
			string linkText = "UL Solutions Training Website";
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the Webinar Page, the statement Verify the text (is|is not) displayed")]
		public void VerifyTextInWebinarPage(string is_isnot)
		{
			string text = "Regulatory compliance for consumer products is one of the many ways UL Solutions puts safety first. The WERCSmart regulatory compliance portal webinar will illustrate the registration process for your products. WERCSmart benefits your organization by providing a centralized database for your product details and documents. During the webinar, you'll also understand how the data derived from your registration is used by your retail partners or recipients.";
			string text2 = "In the Introduction to WERCSmart training, we will review key concepts, guiding you through successful registrations. You'll also obtain valuable information such as:";
			string text3 = "At any time, our team of professional support representatives and resources are here to assist you. Happy Learning!";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text2, is_isnot);
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text3, is_isnot);
		}

	}
}

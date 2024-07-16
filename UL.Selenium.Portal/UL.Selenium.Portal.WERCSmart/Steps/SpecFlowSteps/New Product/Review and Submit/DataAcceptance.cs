using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance")]
	class WERCSmart_Distributor_NewProducts_ReviewAndSubmit_DataAcceptance
	{
		[RegexStepDefinition(@"In the Data Acceptance Section, (check|uncheck) 'Agreed' checkbox")]
		public void CheckUncheckAgreedCheckbox(string checked_unchecked)
		{
			string checkbox = "Agreed";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(checked_unchecked, checkbox);
		}
		[RegexStepDefinition(@"In the Data Acceptance Section, click 'Summary' button")]
		public void ClickSummaryButton()
		{
			string button = "Summary";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Data Acceptance Section, click 'Accept' button")]
		public void ClickAcceptButton()
		{
			string button = "Accept";
			new Steps_Prototype().ClickButton(button);
			/*
			Report.UseSubSteps = true;
			var MyStepsPaymentMethods = new Steps_PaymentMethods();
			var mySub = new PaymentMethods_Subscription_Billing();
			var sub = new SubscriptionEnrollment();
			
			if (sub.Get_Page_Header().Equals("Subscription  Upgrade"))
			{
				var MyStepsSubscriptonEnrollment = new StepsSubscriptionEnrollment();
				Report.StartSubStep("The Subscription Upgrade page should load");
				MyStepsSubscriptonEnrollment.ThenTheSubscriptionEnrollmentPageShouldLoad();
				Report.StartSubStep("I should see Proceed button enabled");
				MyStepsSubscriptonEnrollment.ThenIShouldSeeProceedButtonDisabled("enabled");
				Report.StartSubStep("I click on the Proceed button");
				MyStepsSubscriptonEnrollment.ClickProceedButton();
				var StepsSE_new = new StepsSubscriptionEnrollmentNew();
				Report.StartSubStep("In the Subscription Enrollment Modal, I click the Checkout button");
				StepsSE_new.InSubscriprionEnrollmentModalClickButton("Checkout");
				Report.StartSubStep("In the Payment Methods screen I click Continue");
				MyStepsPaymentMethods.ThenIClickContinue();
				Report.StartSubStep("In the Purchase Summary screen I click Confirm Order");
				MyStepsPaymentMethods.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
				Report.StartSubStep("In the Thank You screen I check the Header is correct");
				MyStepsPaymentMethods.ThenInTheThankYouScreenICheckTheHeaderIsCorrect();
			}
			*/
		}
		[RegexStepDefinition(@"In the Data Acceptance Section, I confirm text 'Data Acceptance' text (should|should not) be displayed")]
		public void GivenIConfirmTheFormulation3rdPartyDataUseConsentsDisplaysTheCorrectText(string condition)
		{
			string section = "Data Acceptance";
			string[] correctText =
			{
			"UL’s WERCSmart recipients rely on UL WERCSmart assessments that are performed based on the data you provide about a product. Inaccurate registration data may lead to fines and unsafe working conditions (e.g. related to handling, storage, transportation and disposal of the product) and, ultimately, your organization may incur liability.",
			"By submitting this registration, you confirm that data provided is accurate and complete. If you also provided a Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label, you confirm the document is compliant with the respective regulations for the region(s) selected for sale of the product. You also confirm the document(s) provided are the most current version and the documents accurately reflect the product being registered.",
			"Should UL have any questions regarding your registration, the data will be suspended or rejected and you will be notified via electronic mail (e-mail). To avoid delays, please verify your contact information is accurate below, as well as within the My Account area of UL’s WERCSmart product."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText, condition);

		}
	}
}

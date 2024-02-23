using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance")]
	class WERCSmart_Distributor_NewProducts_ReviewAndSubmit_DataAcceptance
	{
		[StepDefinition(@"In the Data Acceptance Section, (check|uncheck) 'Agreed' checkbox")]
		public void CheckUncheckAgreedCheckbox(string checked_unchecked)
		{
			string checkbox = "Agreed";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(checked_unchecked, checkbox);
		}
		[StepDefinition(@"In the Data Acceptance Section, click 'Summary' button")]
		public void ClickSummaryButton()
		{
			string button = "Summary";
			new Steps_Prototype().ClickButton(button);
		}
		[StepDefinition(@"In the Data Acceptance Section, click 'Accept' button")]
		public void ClickAcceptButton()
		{
			string button = "Accept";
			new Steps_Prototype().ClickButton(button);
		}
		[StepDefinition(@"In the Data Acceptance Section, I confirm text 'Data Acceptance' text (should|should not) be displayed")]
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

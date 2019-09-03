using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_Ecologo_Readiness
	{

		private readonly EcologoReadiness _ecologoReadiness = new EcologoReadiness();

		[StepDefinition(@"The ECOLOGO Readiness page should be loaded")]
		public void EcologoReadinessPageShouldBeLoaded()
		{
			Report.Info("Expected page heading is: " + this._ecologoReadiness.PanelTitle);
			Report.IsTrue(this._ecologoReadiness.IsActivePanel, "The Ecologo Readiness page did not load!", "The Ecologo Readiness page loaded");
		}

		[StepDefinition("@I set the ECOLOGO Readiness Assessment question to: (Yes|Not at this time)")]
		public void SetEcologoReadinessAssessmentQuestion(string value)
		{
            Report.Info("The label text for Ecologo Readiness Assessment question is: " + this._ecologoReadiness.EcologoReadinessAssesmentQuestion);
            Report.Info("Setting radio to: " + value);
			this._ecologoReadiness.EcologoReadinessAssesment = value;
			Report.IsTrue(this._ecologoReadiness.EcologoReadinessAssesment == value, "Failed to set Ecologo Readiness question to: " + value, "Set Ecologo Readiness question to: " + value);
		}

		[StepDefinition(@"I confirm the ECOLOGO Readiness Assessment question is displayed")]
		public void ConfirmEcologoReadinessAssessmentQuestionDisplayed()
		{
            Report.Info("The ECOLOGO Readiness Assessment question has expected text: " + this._ecologoReadiness.EcologoReadinessAssesmentQuestion);
			Report.IsTrue(this._ecologoReadiness.EcologoReadinessQuestionDisplayed, "The ECOLOGO Readiness question was not displayed!", "The ECOLOGO Readiness question was displayed");
		}
		
		[StepDefinition("@I confirm the ECOLOGO Readiness Assessment question shows the following options:")]
		public void ConfirmEcologoReadinessQuestionOptions(Table values)
        {
            var expectedOptions = new List<string>();
	        foreach (var row in values.Rows)
	        {
                Report.Info("Expect option: " + row["Option"]);
				expectedOptions.Add(row["Option"]);
			}
	        Report.Info("The label text for Ecologo Readiness Assessment question is: " + this._ecologoReadiness.EcologoReadinessAssesmentQuestion);
            Report.Info("Getting radio input labels for the question");
	        var actualOptions = this._ecologoReadiness.EcologoReadinessAssesmentOptions;
            Report.Info("Displayed options are: " + string.Join(", ", actualOptions));
			Report.IsTrue(!actualOptions.Except(expectedOptions).Any(), "The displayed options did not match the expected options!", "The displayed options matched the expected options");
		}

	}
}

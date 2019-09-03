using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.io;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class EcologoReadiness : NewProduct
	{
		public new string PanelTitle = "ECOLOGO Readiness";

		public string EcologoReadinessAssesmentQuestion = "Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment. This report will indicate if the product is eligible to be awarded an ECOLOGO Certification, an established symbol of reduced environmental impact. Would you like to receive this assessment?";

        // Question is displayed
        public bool EcologoReadinessQuestionDisplayed => this.SectionExists(EcologoReadinessAssesmentQuestion);
        
		// Options for question
		public List<string> EcologoReadinessAssesmentOptions => this.RadioButtonsInSection(EcologoReadinessAssesmentQuestion);


		// Set/ get question options
		public string EcologoReadinessAssesment {
			get => this.CheckedInputForLabel(EcologoReadinessAssesmentQuestion);
            set => this.SelectRadio(EcologoReadinessAssesmentQuestion, value);
		}
	}
}

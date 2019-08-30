using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_VOC_OTC_CARB
	{
        private readonly VocOtcCarb _vocOtcCarb = new VocOtcCarb();

        [StepDefinition(@"The VOC OTC CARB page should be loaded")]
        public void VocOtcCarbPageShouldBeLoaded()
        {
            Report.Info("Expected page heading is: " + this._vocOtcCarb.PanelTitle);
	        Report.IsTrue(this._vocOtcCarb.IsActivePanel, "The VOC OTC CARB page did not load!", "The VOC OTC CARB page loaded");
        }

        [StepDefinition(@"I set 'Product has been granted an Alternative Control' to: (Yes|No)")]
        public void SetProductHasBeenGrantedACP(string option)
        {
	        bool isGranted = false;
	        switch (option.ToLower())
	        {
		        case "yes":
			        isGranted = true;
			        break;
		        case "no":
			        break;
		        default:
                    throw new Exception("Step parameter must be either 'Yes' or 'No'!");
	        }
            this._vocOtcCarb.GrantedAlternativeControlPlan = isGranted;
            Delay.Seconds(1);
			Report.IsTrue(this._vocOtcCarb.GrantedAlternativeControlPlan == isGranted, "Failed to set 'Granted an ACP' to: " + option, "Set 'Granted an ACP' to: " + option);
        }

        [StepDefinition(@"I set 'Product label dilution ratio' to: (Yes|No)")]
        public void SetProductLabelDilutionRatio(string option)
        {
	        bool dilutionRatio = false;
	        switch (option.ToLower())
	        {
		        case "yes":
			        dilutionRatio = true;
			        break;
		        case "no":
			        break;
		        default:
			        throw new Exception("Step parameter must be either 'Yes' or 'No'!");
	        }
	        this._vocOtcCarb.LabelDilutionRatio = dilutionRatio;
            Delay.Seconds(1);
			Report.IsTrue(this._vocOtcCarb.LabelDilutionRatio == dilutionRatio, "Failed to set 'Product Label Specifies Dilution Ratio' to: " + option, "Set 'Product Label Specifies Dilution Ratio' to: " + option);

		}

        [StepDefinition(@"I set 'VOC Content As Sold' to: (.*)")]
        public void SetVocContentAsSold(string value)
        {
	        this._vocOtcCarb.VocContentAsSold = value;
            Delay.Seconds(1);
			Report.IsTrue(this._vocOtcCarb.VocContentAsSold == value,
				"Failed to set 'VOC Content As Sold' to: " + value,
				"Set 'VOC Content As Sold' to: " + value);

        }

        [StepDefinition(@"I set 'VOC Content As Used' to: (.*)")]
        public void SetVocContentAsUsed(string value)
        {
	        this._vocOtcCarb.VocContentAsUsed = value;
	        Delay.Seconds(1);
	        Report.IsTrue(this._vocOtcCarb.VocContentAsUsed == value,
		        "Failed to set 'VOC Content As Used' to: " + value,
		        "Set 'VOC Content As Used' to: " + value);

        }

        [StepDefinition(@"I set 'HVOC content' to: (.*)")]
        public void SetHvocContent(string value)
        {
	        this._vocOtcCarb.HvocContent = value;
	        Delay.Seconds(1);
	        Report.IsTrue(this._vocOtcCarb.HvocContent == value,
		        "Failed to set 'HVOC content' to: " + value,
				"Set 'HVOC content' to: " + value);
		}

        [StepDefinition(@"I set 'MVOC content' to: (.*)")]
        public void SetMvocContent(string value)
        {
	        this._vocOtcCarb.MvocContent = value;
	        Delay.Seconds(1);
	        Report.IsTrue(this._vocOtcCarb.MvocContent == value,
				"Failed to set 'MVOC content' to: " + value,
				"Set 'MVOC content' to: " + value);
		}
	}
}

using Mailosaur.Operations;
using NPOI.SS.Formula.Functions;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "SPLInformation")]
	 class SPLInformation
	{
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'Manufacturer' contains value: (.*)")]
		public void VerifyManufacturer(string value)
		{
			string section = "Manufacturer";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'Distributor' contains value: (.*)")]
		public void VerifyDistributor(string value)
		{
			string section = "Distributor";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: (.*)")]
		public void VerifyPrescriptionDosageForm(string value)
		{
			string section = "Prescription Dosage Form";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'DEA Schedule' contains value: (.*)")]
		public void VerifyDEASchedule(string value)
		{
			string section = "DEA Schedule";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'Marketing Category' contains value: (.*)")]
		public void VerifyMarketingCategory(string value)
		{
			string section = "Marketing Category";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'Marketing End Date' contains value: (.*)")]
		public void VerifyMarketingEndDate(string value)
		{
			string section = "Marketing End Date";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the SPL Information Section, verify section: 'NDA Number' contains value: (.*)")]
		public void VerifyNDANumber(string value)
		{
			string section = "NDA Number";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
	}
}

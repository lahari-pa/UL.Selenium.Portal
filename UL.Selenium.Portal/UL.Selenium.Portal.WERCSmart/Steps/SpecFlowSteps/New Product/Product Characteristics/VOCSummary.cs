using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{

	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary")]
	class WERCSmart_Distributor_NewProducts_VOCSummary
	{
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'CARB' value: (.*)")]
		public void CARBValue(string value)
		{
			string section = "CARB";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'MVOC' value: (.*)")]
		public void MVOCValue(string value)
		{
			string section = "MVOC";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'HVOC' value: (.*)")]
		public void HVOCValue(string value)
		{
			string section = "HVOC";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC Grams Ozone' value: (.*)")]
		public void VOCGramsOzoneValue(string value)
		{
			string section = "VOC Grams Ozone";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'OTC Model Rule' value: (.*)")]
		public void OTCModelRuleValue(string value)
		{
			string section = "OTC Model Rule";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see todays 'VOC Analysis Date'")]
		public void VOCAnalsisDate()
		{
			new Steps_Prototype().ThenIConfirmThatISeeTodaysVOCAnalysisDate();
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC content in g/L, including water and exempt compounds' value: (.*)")]
		public void VOCContentingLIncludingWater(string value)
		{
			string section = "VOC content in g/L, including water and exempt compounds";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC content in g/L' value: (.*)")]
		public void VOCContentingL(string value)
		{
			string section = "VOC content in g/L";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
			[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC percent as sold' value: (.*)")]
		public void VOCPercentAsSold(string value)
		{
			string section = "VOC percent as sold";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC percent diluted for use' value: (.*)")]
		public void VOCPercentDilutedForUse(string value)
		{
			string section = "VOC percent diluted for use";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'")]
		public void SetYesIAcknowledge()
		{
			string section = "Your acknowledgement of this registration includes that your product";
			new Steps_Prototype().SetTheSectionOptionTo(section, "Yes, I Acknowledge");
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm 'Limits' table (should|should not) exists")]
		public void VOCLimitsTableExists(string condition)
		{
			string tableName = "Limits";
			new Steps_Prototype().ThenIConfirmThatTableExists(tableName, condition);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm 'VOC Content \(g/L minus water and exempt compounds for high solids; g\/L with water and exempts for low solids\)' table (should|should not) exists")]
		public void VOCContentTableExists(string condition)
		{
			string tableName = "VOC Content (g/L minus water and exempt compounds for high solids; g/L with water and exempts for low solids)";
			new Steps_Prototype().ThenIConfirmThatTableExists(tableName, condition);
		}
		[StepDefinition(@"In the Volatile Organic Compound Summary Section, confirm 'VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.' table (should|should not) exists")]
		public void VOCContentAsWeightTableExists(string condition)
		{
			string tableName = "VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.";
			new Steps_Prototype().ThenIConfirmThatTableExists(tableName, condition);
		}
	}	
}

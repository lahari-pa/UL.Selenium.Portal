using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Commons.Utils;
using NPOI.SS.Formula.Functions;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{

	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary")]
	class WERCSmart_Distributor_NewProducts_VOCSummary
	{
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'CARB' value: (.*)")]
		public void CARBValue(string value)
		{
			string section = "CARB";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'MVOC' value: (.*)")]
		public void MVOCValue(string value)
		{
			string section = "MVOC";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'HVOC' value: (.*)")]
		public void HVOCValue(string value)
		{
			string section = "HVOC";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC Grams Ozone' value: (.*)")]
		public void VOCGramsOzoneValue(string value)
		{
			string section = "VOC Grams Ozone";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'OTC Model Rule' value: (.*)")]
		public void OTCModelRuleValue(string value)
		{
			string section = "OTC Model Rule";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see todays 'VOC Analysis Date'")]
		public void VOCAnalysisDate()
		{
			string date = DateTime.Now.ToString("MM/dd/yyyy");
			var newProductpage = new NewProduct();
			string found = newProductpage.GetValueVOCSummary("VOC Analysis");

			Report.IsTrue(found.Trim() == date.Trim(),
				$"date was not as expected! Expected: {date}, but found: {found}!",
				$"statement was showing: {date}, as expected!");
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC content in g/L, including water and exempt compounds' value: (.*)")]
		public void VOCContentingLIncludingWater(string value)
		{
			string section = "VOC content in g/L, including water and exempt compounds";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC content in g/L' value: (.*)")]
		public void VOCContentingL(string value)
		{
			string section = "VOC content in g/L";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
			[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC percent as sold' value: (.*)")]
		public void VOCPercentAsSold(string value)
		{
			string section = "VOC percent as sold";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm that I see the following 'VOC percent diluted for use' value: (.*)")]
		public void VOCPercentDilutedForUse(string value)
		{
			string section = "VOC percent diluted for use";
			new Steps_Prototype().ThenIConfirmThatISeeTheFollowingCARBValue(section, value);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'")]
		public void SetYesIAcknowledge()
		{
			string section = "Your acknowledgement of this registration includes that your product (exceeds/does not exceed) the limits specified by the noted regulations and understand these statements of exceeding, or not exceeding, will be provided to the recipients for which the product is registered and assessed.  Recipients may take action based on these statements.";
			new Steps_Prototype().SetTheSectionOptionTo(section, "Yes, I Acknowledge");
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm 'Limits' table (should|should not) exists")]
		public void VOCLimitsTableExists(string condition)
		{
			string tableName = "Limits";
			new Steps_Prototype().ThenIConfirmThatTableExists(tableName, condition);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm 'VOC Content \(g/L minus water and exempt compounds for high solids; g\/L with water and exempts for low solids\)' table (should|should not) exists")]
		public void VOCContentTableExists(string condition)
		{
			string tableName = "VOC Content (g/L minus water and exempt compounds for high solids; g/L with water and exempts for low solids)";
			new Steps_Prototype().ThenIConfirmThatTableExists(tableName, condition);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm 'VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.' table (should|should not) exists")]
		public void VOCContentAsWeightTableExists(string condition)
		{
			string tableName = "VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.";
			new Steps_Prototype().ThenIConfirmThatTableExists(tableName, condition);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Based on the type of product, this must comply with the most restrictive VOC limit.' (is|is not) displayed")]
		public void StatementBasedOnTheTypeOfProduct(string is_isnot)
		{
			string text = "Based on the type of product, this must comply with the most restrictive VOC limit.";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Exceeds the limits specified in the California Consumer Products Regulation' (is|is not) displayed")]
		public void StatementExceedsTheLimitsSpecifiedTnTheCalifornia(string is_isnot)
		{
			string text = "Exceeds the limits specified in the California Consumer Products Regulation";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Exceeds the limits specified by the Ozone Transport Commission' (is|is not) displayed")]
		public void StatementExceedsTheLimitsOzoneTransport(string is_isnot)
		{
			string text = "Exceeds the limits specified by the Ozone Transport Commission";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified in the California Consumer Products Regulation' (is|is not) displayed")]
		public void StatementDoesNotExceedTheLimitsSpecifiedTnTheCalifornia(string is_isnot)
		{
			string text = "Does not exceed the limits specified in the California Consumer Products Regulation";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified by the Ozone Transport Commission' (is|is not) displayed")]
		public void StatementDoesNotExceedTheLimitsOzoneTransport(string is_isnot)
		{
			string text = "Does not exceed the limits specified by the Ozone Transport Commission";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Based on your previous selections, the product is an architectural coating with the following intended use. The SCAQMD VOC compliant limits for this intended use are:' (is|is not) displayed")]
		public void StatementBasedOnYourPrevious(string is_isnot)
		{
			string text = "Based on your previous selections, the product is an architectural coating with the following intended use. The SCAQMD VOC compliant limits for this intended use are:";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified by the California Air District\(s\)' (is|is not) displayed")]
		public void StatementDoesNotExceedTheLimitsCaliforniaAirDistrict(string is_isnot)
		{
			string text = "Does not exceed the limits specified by the California Air District(s)";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}
		//| State | Regulation  | VOC Value | State VOC Threshold | Message |
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, for the table 'VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.' confirm the following values displays in the table:")]
		public void ConfirmValuesInVocContentTable(Table table)
		{
			new Steps_Prototype().ThenIShouldSeeTheFollowingVocPercentForEachState(table);
		}
		[RegexStepDefinition(@"In the Volatile Organic Compound Summary Section, confirm the statement 'Alternative Control Plan' (is|is not) displayed")]
		public void ConfirmStatementAlternativeControlPlanIsOrIsNotDisplayed(string is_isnot)
		{
			string text = "Alternative Control Plan";
			new Steps_Prototype().ConfirmTextIsIsNotDisplayed(text, is_isnot);
		}

	}	
}

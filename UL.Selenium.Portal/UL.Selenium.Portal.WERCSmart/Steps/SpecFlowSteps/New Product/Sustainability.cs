using NPOI.POIFS.Crypt.Dsig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using static NPOI.HSSF.Util.HSSFColor;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	internal class Sustainability
	{
		[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Sustainabilit")]

		[StepDefinition(@"I enter the text of Sustainability Information field to: (.*)")]
		public void GivenEnterSustainabilityInformationValue(string value)
		{
			Report.Info($"I set the text of Sustainability Information field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Sustainability Information", value);
		}

		[StepDefinition(@"I enter the text of not granted consent to requested Data Use Tiers field to: (.*)")]
		public void GivenEnterNotGrantedConsentToRequestedDataUseTiersValue(string value)
		{
			Report.Info($"I set the text of not granted consent to requested Data Use Tiers field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("You have not granted consent to requested Data Use Tiers for this component. Your customer's products will not be fully screened and evaluated by any relevant WERCSmart Recipient chemical policy or product qualification program. The results for each program is displayed above. If you wish to update your consents for this component- please go to Product Characteristics / Formulation > Third-Party.", value);
		}

		[StepDefinition(@"I enter the text of products sold on the U.S. Retail Market field to: (.*)")]
		public void GivenEnterProductsSoldOnTheUSRetailMarketValue(string value)
		{
			Report.Info($"I set the text of products sold on the U.S. Retail Market field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("If your customers use this component in products sold on the U.S. Retail Market- they are required to register their products in WERCSmart. In addition to regulatory evaluations- a growing number of WERCSmart Recipients conduct chemical policy or product qualification assessments of the products they sell", value);
		}
	}

}

using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOCForCaliforniaAirDistrict")]
	class WERCSmart_Distributor_NewProducts_VOCForCaliforniaAirDistrict
	{
		[RegexStepDefinition(@"In the VOC for California Air District\(s\) Section, for (.*) area enter 'VOC info' value: (.*)")]
		public void EnterVOCInfo(string area, string value)
		{
			var vocForCaliforniaAirDistrict = new VOCForCaliforniaAirDistrict();
			if (Report.IsTrue(vocForCaliforniaAirDistrict.VocInfoExists(area), $"Failed to confirm VOC Info input field exists for area {area}", $"Successfully confirmed VOC Info input field exists for area {area}"))
			{
				Report.IsTrue(vocForCaliforniaAirDistrict.VocInfoEnterText(area, value), $"Failed to enter VOC Info value for area {area}", $"Successfully entered VOC Info value for area {area}");
			}
		}
	}
}

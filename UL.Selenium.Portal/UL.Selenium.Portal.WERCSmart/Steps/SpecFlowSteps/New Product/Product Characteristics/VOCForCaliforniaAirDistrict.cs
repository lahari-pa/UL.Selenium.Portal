using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOCForCaliforniaAirDistrict")]
	class WERCSmart_Distributor_NewProducts_VOCForCaliforniaAirDistrict
	{
		[StepDefinition(@"In the VOC for California Air District\(s\) Section, for (.*) area enter 'VOC info' value: (.*)")]
		public void EnterVOCInfo(string area, string value)
		{
			new Steps_Prototype().EnterVOCInfoValue(area, value);
		}
	}
}

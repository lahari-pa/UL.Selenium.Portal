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
		[StepDefinition(@"In the VOC for California Air District\(s\) Section, enter the value in section: 'VOC info' for Canada: (.*)")]
		public void SEnterVOCInfo(string option)
		{
			string section = "Canada";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}

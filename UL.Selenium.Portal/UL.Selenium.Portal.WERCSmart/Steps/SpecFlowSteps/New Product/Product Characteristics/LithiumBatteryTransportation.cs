using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:LithiumBatteryTransportation")]
	class WERCSmart_Distributor_NewProducts_LithiumBatteryTransportation
	{
		[StepDefinition(@"In the Lithium Battery Transportation Section, set the radio option in section: 'For U.S. Department of Transportation \(DOT\), indicate the transport classification': to: (Fully-regulated dangerous goods: UN3090, Lithium metal batteries, 9|Fully-regulated dangerous goods: UN3091, Lithium metal batteries contained in equipment, 9|Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9|Meets the requirements of 49CFR173.185\(c\)\(iv\) to be transported as non-dangerous goods for road and rail|Meets the requirements of 49CFR173.185\(c\)\(i\) to be transported as non-dangerous goods for road, rail, air, and vessel|Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9|Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9)")]
		public void SelectDOT(string option)
		{
			string section = "For U.S. Department of Transportation (DOT), indicate the transport classification";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Lithium Battery Transportation Section, set the radio option in section: 'For Marine transport \(IMDG\), indicate the classification': to: (Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods|Fully-regulated dangerous goods: UN3090, Lithium metal batteries, 9|Fully-regulated dangerous goods: UN3091, Lithium metal batteries contained in equipment, 9|Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9|Fully-regulated dangerous goods: UN3480, Lithium ion batteries, 9|Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9|Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9|None of the above\/Not intended for shipment under IMDG)")]
		public void SelectIMDG(string option)
		{
			string section = "For Marine transport (IMDG), indicate the classification";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Lithium Battery Transportation Section, set the radio option in section: 'For Air transport \(IATA\), indicate the classification': to: (Section I|Section II|Section IA|Section IB|None of the above\/Not intended for shipment under IATA)")]
		public void SelectIATA(string option)
		{
			string section = "For Air transport (IATA), indicate the classification";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Lithium Battery Transportation Section, set the radio option in section: 'For Canada's Transportation of Dangerous Goods \(TDG\), indicate the classification': to: (Fully-regulated dangerous goods: UN3091, Lithium metal batteries contained in equipment, 9|Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9|Fully-regulated dangerous goods: UN3480, Lithium ion batteries, 9	|Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9|Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods.|None of the above\/Not intended for shipment in Canada)")]
		public void SelectTDG(string option)
		{
			string section = "For Canada's Transportation of Dangerous Goods (TDG), indicate the classification";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Lithium Battery Transportation Section, the text message (should|should not) be displayed with text: 'Need help\? Regulatory services are included in Premium Subscription. Upgrade now\!'")]
		public void LithiumBatteryTransportationTextInAlertMessage(string condition)
		{
			string alertText = "Need help? Regulatory services are included in Premium Subscription. Upgrade now!";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}
		[StepDefinition(@"In the Lithium Battery Transportation Section, the text message (should|should not) be displayed with text: 'Confirm that this product is manufactured in a facility that meets criteria outline in IATA 3.9.2.6€.'")]
		public void LithiumBatteryTransportationTextMessage(string condition)
		{
			string alertText = "Confirm that this product is manufactured in a facility that meets criteria outline in IATA 3.9.2.6€.";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Recipient_and_UPC_Details
{
	[Binding, Scope(Tag = "SafetyDataSheetAuthoring")]
	class SafetyDataSheetAuthoring
	{

		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), set the option in section: 'Personal Protection Equipment Recommended \(select\)' to: (Mask|Gloves|Apron|Goggles)")]
		public void SelectPersonalProtectionEquipment(string option)
		{
			string section = "Personal Protection Equipment Recommended (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), for the section: 'Autoignition Temperature \(°C\)' enter text: (.*)")]
		public void EnterAutoignitionTemperature(string text)
		{
			string section = "Autoignition Temperature (°C)";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), for the section: 'Minimum Ignition Energy \(mJ\)' enter text: (.*)")]
		public void EnterMiniumIgnitionEngergy(string text)
		{
			string section = "Minimum Ignition Energy (mJ)";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), for the section: 'Viscosity' enter text: (.*)")]
		public void EnterViscosity(string text)
		{
			string section = "Viscosity";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}


		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), set the option in section: 'Appearance' to: (Amber|Beige|Black|Black grey|Blue|Blue black|Blue green|Bluish gray|Bronze|Brown|Bullet-shaped|Burnt Sienna|Carmine|Chrome|Clear|Clear Blue|"+
		"Clear to hazy, colorless|Clear to opalescent|Clear to slightly hazy, dark blue|Clear to slightly hazy, dark green|Clear to slightly hazy, orange|Clear to slightly hazy, yellow|Clear to translucent|Clear to yellow|Clear white to straw colored viscous liquid|"+
		"Clear with black solid residue which disperses throughout upon agitation|Clear, amber|Cloudy|Colorless to brown|Copper|Cream|Crystalline|Cyan|Dark liquid to semi-solid sediment, brown to black in color|Deep blue|Flesh|Fluorescent yellow|Fuchsia|Gold|Golden yellow|"+
		"Grass green|Gray|Green|Greenish blue|Greenish-yellow gas|Magenta|Maroon|Metallic|Multiple Colors|Off white|Oily|Orange|Pale purple|Peach|Pink|Purple|Red|Red brown|Reddish brown|Rust red|Silver|Slight pink|Straw-colored|Tan|Teal|Translucent|Turquoise|Ultramarine|Varies|"+
		"Vermillion|Waxy stick|White|White intact tablets with no capping or delamination, no rust|Yellow|Yellow-orange)")]
		public void SelectAppearance(string option)
		{
			string section = "Appearance";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), set the option in section: 'Odor' to: (Acetic|Acidic|Acrid|Alcohol|Almond|Amine|Ammonia|Apple|Baby Powder|Banana|Banana coconut|Bergamot and Juniper Type|Berry|Bitter|Bitter almonds|"+
		"Black currant|Bleach|Bubble gum|Burnt|Buttery|Cedar|Cherry|Chlorine|Chocolate|Choking effect|Cinnamon|Citrus|Clover-like|Coconut|Cotton|Cucumber|Earthy|Ether|Fat|Fish|Floral|Formaldehyde|Fruity|Garlic|Gasoline|Grape|Grass|Green|Green Tea|Herbaceous|Honey|Hyacinth|"+
		"Kerosene|Ketones|Latex|Lavender|Lemon|Lilac|Lime|Magnolia|Melon|Menthol|Milk and Honey Type|Mint-like|Moldy|Multiple Fragrances|Musky|Musty|Nutty|Ocean|Odorless|Of vinegar|Orange|Petroleum|Phenolic|Pine|Pleasant|Pomegranate|Pungent|Rain|Rose|Rotten fish like|Rubbing alcohol|"+
		"Silicone|Slight fermentation|Slight nitric|Smoky|Spearmint|Strawberry|Sulphurous|Sweet|Tar like|Typical|Vanilla|Vegetable fatty odor|Vinegar-like|Waxy|Wintergreen oil|Witch hazel|Woody)")]
		public void SelectOdor(string option)
		{
			string section = "Odor";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		
		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), set the option in section: 'Odor Threshold' to: (0.010 - 2.014 ppm \(phosphine\)|0.02 - 0.126 ppm \(Fluorine\)|0.042 ppm \(EPA\)|0.13 ppm \(Hydrogen sulfide\)|0.29 - 0.97 ppm \(Nitric oxide\)|0.51 ppm \(PH3\)|1680 mg/m3 \(Bromodichloromethane\)|"+
		@"0.51 ppm \(PH3\)|2.5 ppm \(Diborane\)|2-5 ppm \(Hydrogen Bromide\)|No data available|No information available|Not applicable)")]
		public void SelectOdorThreshold(string option)
		{
			string section = "Odor Threshold";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		

		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), for the section: 'Partition Coefficient' enter text: (.*)")]
		public void EnterPartitionCoefficienty(string text)
		{
			string section = "Partition Coefficient";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Safety Data Sheet Authoring - Additional Data \(Optional\), for the section: 'Product's Dispensing Method' select option: (Aerosol|Bag-On-Value|Pump|None of the Above/Not Applicable)")]
		public void EnterProductDispensingMethod(string option)
		{
			string section = "Product's Dispensing Method";
			new StepsNewProduct().SetTheSectionOptionTo("Product's Dispensing Method", option);
		}



	}
}

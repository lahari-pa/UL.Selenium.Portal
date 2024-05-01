@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@run_Flow16
@UPC
@SHA
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:LithiumBatteryTransportation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulated_Batteries
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
Feature: Flow 16

@TestCase:59273
Scenario: [59273] Alkaline Battery - RU000344
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59273
	Then In the Product Grid, delete all products with UPC Number: saved as UPC59273

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alkaline battery_#59273
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Alkaline battery
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase59273

	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue     | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	|CAS number		 | 1313-13-9       | 50      |				       |          |             |
	|CAS number		 | 7782-42-5       | 25      |                     |          |             |
	|CAS number		 | 7440-66-6       | 25      |                     |          |             |
	Then in the Ingredients page, I click Continue

	Then I should be on the Formulation > Batteries Page
	And In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then in the Formulation > Batteries page, I click Continue

	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Exempt (DSL and/or NDSL)
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No 
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: The Home Depot
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 213071 (Enter Universal Product Code (UPC) - Applicable Only to Alkaline Battery-Quantity Field Required) for UPC saved as: UPC59273 with container type: Plastic Container size: 20 and quantity: 2
	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC59273 enter Size: 20 enter Container Type: Plastic Container and enter Quantity: 2
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given I call Shared Step 213199 - Regulatory Documents to Provide - Required Document Uploads - Applicable Only to Alkaline Battery
	Then I should be on the Regulatory Documents to Provide Page
	And In the Regulatory Documents to Provide Section, I confirm text 'Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product...' should be displayed
	And In the Regulatory Documents to Provide Section, upload file in section: 'I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.'
	And In the Regulatory Documents to Provide Section, set the radio option in section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS. When providing an SDS it must be both U.S. and Canada formats.' to: I certify that I have an OSHA-Compliant Safety Data Sheet (SDS) for this product.
	And In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	And In the Regulatory Documents to Provide Section, set the radio option in section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I certify that I have a WHMIS-Compliant Safety Data Sheet (SDS) for this product.
	And In the Regulatory Documents to Provide Section, upload file in section: 'Dual-Language WHMIS SDS, in French Canadian and English'
	And In the Regulatory Documents to Provide Section, for section 'Dual-Language WHMIS SDS, in French Canadian and English': enter WHMIS SDS Docmument Date: 2024-06-27
	And In the Regulatory Documents to Provide Section, upload file in section: 'Label in both French and English'
	Then in the Regulatory Documents to Provide page, I click Continue

	Then in the Additional Documents to Provide page, I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59273

@TestCase:59274
Scenario: [59274] Battery Containing Mercury - RU000729
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59274
	Given I delete all products with UPC Number: saved as UPC59274
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery Containing Mercury
	Then I save the product information as: TestCase59274
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Mercury oxide | 15.2    | false               | false       |            |
		| Formaldehyde  | 14.7    | false               | false       |            |
		| Aqua          | 70.1    | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59274 with container type: Metal Container size: 40.0 and quantity: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 230                      | 55.4                    | 33.3      | Black      | Acidic | No data available | 1.44                  |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59274. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Battery Containing Mercury
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59274
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59274
@TestCase:59276
Scenario: [59276] Lead Acid Battery - No Acid Included - RU001225
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59276
	Given I delete all products with UPC Number: saved as UPC59276
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid Battery - No Acid Included
	Then I save the product information as: TestCase59276
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lead sulfate  | 50      | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59276 with container type: Metal Container size: 40.0 and quantity: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 230                      | 55.4                    | 33.3      | Black      | Acidic | No data available | 1.44                  |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59276. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lead Acid Battery - No Acid Included
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59276
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59276
@ignore
#Removed from regression 2023/11	
@TestCase:59277
Scenario: [59277] Magnesium Battery - RU000728
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59277
	Given I delete all products with UPC Number: saved as UPC59277
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Magnesium Battery
	Given I save the product information as: TestCase59277
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Magnesium     | 50      | false               | false       |            |
		| Sulfuric acid | 50      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59277 with container type: Metal Container size: 40.0 and quantity: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Mask                          | 555                      | 65.0                    | 2.9009    | Black      | Acidic | No data available | 1.104                 |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59277. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Magnesium Battery
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59277
	
@TestCase:59278
Scenario: [59278] Nickel Metal Hydride (NiMH) Battery - RU000373
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59278
	Given I delete all products with UPC Number: saved as UPC59278
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	Given I save the product information as: TestCase59278
	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Nickel        | 9       | false               | false       |            |
		| Lanthanum     | 1       | false               | false       |            |
		| Aqua          | 90      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59278 with container type: Metal Container size: 40.0 and quantity: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
    Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Mask                          | 1000                     | 55.0                    | 10.77611  | Black      | Acidic | No data available | 9.1000223             |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59278. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Nickel Metal Hydride (NiMH) Battery
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59278
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59278
#Removed from regression: 2023/06
@ignore
@TestCase:59279
Scenario: [59279] Nickel-Cadmium Battery - RU000346
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59279
	Given I delete all products with UPC Number: saved as UPC59279
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel-Cadmium Battery
	Given I save the product information as: TestCase59279
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Nickel          | 11.12   | false               | false       |            |
		| Cadmium sulfide | 12.75   | false               | false       |            |
		| Aqua            | 76.13   | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59279 with container type: Metal Container size: 40.0 and quantity: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 772                      | 0.223                   | 4.79701   | Black      | Acidic | No data available | 1.0009                |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59279. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Nickel-cadmium battery
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59279
	
@TestCase:59280
Scenario: [59280] Silver Battery - RU000698
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59280
	Given I delete all products with UPC Number: saved as UPC59280
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Silver Battery
	Given I save the product information as: TestCase59280
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Silver Oxide  | 19.52   | false               | false       |            |
		| Zinc          | 5.18    | false               | false       |            |
		| Aqua          | 75.3    | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59280 with container type: Metal Container size: 10.0 and quantity: 1
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 555.1                    | 0.5                     | 5.701     | Black      | Acidic | No data available | 2.1008                |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59280. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Silver Battery
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59280
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59280
@TestCase:59281
Scenario: [59281] Water-Charged Cell - RU001543
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59281
	Given I delete all products with UPC Number: saved as UPC59281
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Water-Charged Cell
	Given I save the product information as: TestCase59281
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 7647-14-5     | 33.33   | false               | false       |            |
		| Copper        | 4.70    | false               | false       |            |
		| Magnesium     | 5.30    | false               | false       |            |
		| Aqua          | 56.67   | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59281 with container type: Metal Container size: 30.0 and quantity: 50
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 555.1                    | 0.5                     | 5.701     | Black      | Acidic | No data available | 2.1008                |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59281. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Water-Charged Cell
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59281
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59281
@TestCase:59282
Scenario: [59282] Zinc Air - RU001205
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59282
	Given I delete all products with UPC Number: saved as UPC59282
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Zinc Air
	Given I save the product information as: TestCase59282
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Zinc          | 30      | false               | false       |            |
		| Carbon        | 15      | false               | false       |            |
		| Aqua          | 55      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59282 with container type: Metal Container size: 40.0 and quantity: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Goggles                       | 950                      | 0.7                     | 10.001    | Black      | Acidic | No data available | 9.189                 |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59282. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Zinc Air
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59282
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59282
#Removed from regression: 2023/06
@ignore
@TestCase:59275
Scenario: [59275] Carbon Zinc Battery - RU000727
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59275
	Given I delete all products with UPC Number: saved as UPC59275
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Carbon Zinc Battery
	Given I save the product information as: TestCase59275
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Zinc          | 30      | false               | false       |            |
		| Carbon        | 15      | false               | false       |            |
		| Aqua          | 55      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59275 with container type: Metal Container size: 20.0 and quantity: 10
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Goggles                       | 950                      | 0.200                   | 2.999     | Black      | Acidic | No data available | 9.229                 |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 59275. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Carbon Zinc Battery
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59275

#Removed from regression 2024/03
@ignore
@TestCase:97484
Scenario: [97484] Stand alone Lead Acid non spill-able Battery
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lead sulfate  | 50      | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I confirm the Formulation > Batteries displays the correct text
    Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
    Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 230                      | 55.4                    | 33.3      | Black      | Acidic | No data available | 1.44                  |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lead Acid (Non-Spillable) Battery
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase97484
	
@TestCase:97470
Scenario: [97470] Stand alone Lead Acid Battery
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead acid battery
	Then I save the product information as: TestCase97470
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lead sulfate  | 50      | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
		And I should see the Formulation > Batteries Page
    Given I confirm the Formulation > Batteries displays the correct text
    Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
    Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 230                      | 55.4                    | 33.3      | Black      | Acidic | No data available | 1.44                  |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lead acid battery
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase97470
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase97470
	
@TestCase:110324
Scenario: [110324] Alkaline Battery - Check Regulatory Documents To Provide Error Messaging - RU000344
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC110324
	Given I delete all products with UPC Number: saved as UPC110324
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
	Then In the Product Grid, delete all products with UPC Number: saved as UPC110324
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Nickel Metal Hydride (NiMH) Battery_#110324
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Nickel Metal Hydride (NiMH) Battery
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase59273

	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	|   CASNumber         | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| 7439-89-6           | 30      | false               | false       |            |
	#	| 12054-48-7          | 45      | false               | false       |            |
	#	| 7440-50-8           | 13      | false               | false       |            |
	#	| 1310-58-3           | 12      | false               | false       |            |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue     | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	|CAS number		 | 1313-13-9       | 50      |				       |          |             |
	|CAS number		 | 7782-42-5       | 25      |                     |          |             |
	|CAS number		 | 7440-66-6       | 25      |                     |          |             |
	Then in the Ingredients page, I click Continue

	Then I should be on the Formulation > Batteries Page
	And In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then in the Formulation > Batteries page, I click Continue

	#Given I call Shared Step 214520 (Waste Classification Data - Applicable Only to Alkaline Battery)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Exempt (DSL and/or NDSL)
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No 
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: The Home Depot
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: The Home Depot
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC110324 with container type: Plastic Container size: 75.0 and quantity: 2
	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC110324 enter Size: 20 enter Container Type: Plastic Container and enter Quantity: 2
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

	#Given I call Shared Step 213199 - Regulatory Documents to Provide - Required Document Uploads - Applicable Only to Alkaline Battery
	Then I should be on the Regulatory Documents to Provide Page
	And In the Regulatory Documents to Provide Section, I confirm text 'Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product...' should be displayed
	And In the Regulatory Documents to Provide Section, upload file in section: 'I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.'
	And In the Regulatory Documents to Provide Section, set the radio option in section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS. When providing an SDS it must be both U.S. and Canada formats.' to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	And In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	And In the Regulatory Documents to Provide Section, set the radio option in section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I don't need a WHMIS Compliant SDS
	And In the Regulatory Documents to Provide Section, upload file in section: 'Dual-Language WHMIS SDS, in French Canadian and English'
	And In the Regulatory Documents to Provide Section, for section 'Dual-Language WHMIS SDS, in French Canadian and English': enter WHMIS SDS Docmument Date: 2024-06-27
	And In the Regulatory Documents to Provide Section, upload file in section: 'Label in both French and English'
	Then in the Regulatory Documents to Provide page, I click Continue


	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		|   CASNumber         | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 7439-89-6           | 30      | false               | false       |            |
		| 12054-48-7          | 45      | false               | false       |            |
		| 7440-50-8           | 13      | false               | false       |            |
		| 1310-58-3           | 12      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 214541 (Waste Classification Data - Applicable Only to Nickel Metal Hydride (NiMH) Battery (RU000373))
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: The Home Depot
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC110324 with container type: Plastic Container size: 75.0 and quantity: 2
	Given I should see the Regulatory Documents to Provide Page
	Given In Regulatory Documents to Provide I see text:Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product. The Battery registration must comply with regulatory requirements in all regions served by the WERCSmart solution. You must provide a technical document or an SDS for both Canada and the US with a bilingual product label. Lithium Battery registrations must also provide the UN38.3 Testing Document.
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf	
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I don't need a WHMIS Compliant SDS
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue

	Then in the Additional Documents to Provide page, I click Continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273

	Given I should see the Additional Documents to Provide Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59273
@TestCase:122366
Scenario:[122366] Battery Containing Product (BCP) (Transportation override at UPC level- New Feature)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC122366
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery-Containing Product
	Then I save the product information as: TestCase122366
	#Then I call Shared Step 63704 (Product Information - US, No(DSV), No(PL), No(GNFR))
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I should see the Product Includes Battery Page
	Then In the Product Includes Battery Section, set the radio option in section: 'Indicate how battery is packaged': to: The battery is shipped with but not included in my product.
	Given In the Product Includes Battery Section enter the values in the table:
		| Battery Type    | Grams Lithium    | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As       |
		| Lithium Primary | > 1 g and <= 2 g | wercs        | 4                                 | 4                                        | lithiumbattery |
	Then in the Product Includes Battery page, I click Continue

	Given I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Lead': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Mercury': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Silver': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Cadmium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Chromium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Barium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Arsenic': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Selenium': to: No
	Then in the Toxicity Characteristic Leaching Procedure (TCLP) page, I click Continue

	Then I should see the Electronic Equipment Page
	And In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: No
	And In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	Then in the Electronic Equipment page, I click Continue

	#Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Lithium Battery Transportation Page
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For U.S. Department of Transportation (DOT), indicate the transport classification': to: Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For Marine transport (IMDG), indicate the classification': to: Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For Air transport (IATA), indicate the classification': to: Section I
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For Canada's Transportation of Dangerous Goods (TDG), indicate the classification': to: Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9
	Then in the Lithium Battery Transportation page, I click Continue

	Then I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Walgreens
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC122366, container type: Plastic Container and size: 12 click continue
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify option 'Packaging Type' is not present
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC122366 enter Size: 12 and enter Container Type: Plastic Container
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Then I should see the Optional Comments Page
	Then in the Optional Comments page, I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then The Purchase Summary Page is displayed
	Then In the Purchase Summary Page, click the 'Home' button

	@TestCase:220789

	Scenario: [220789] Carbon Zinc Battery - RU000727
	
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC220789
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Carbon Zinc Battery
	Then I save the product information as: TestCase220789
	Then I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent  | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100      | false               | false       |            |
	Then I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
	Then I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I call Shared Step 150905 (Retailer - NR selected by default)
	Then I call Shared Step 145129 Regulatory Documents to Provide - Upload AIS and CCCR
	Then in the Additional Documents to Provide page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Then in the Optional Comments page I click Continue
	Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase220789)
	Then I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase220789)
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I call Shared Step 214620 Power Designer Plus - AUTHORIZE Product (Applicable Only to Battery Products) for product saved as: TestCase220789
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase220789
	Then I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase220789)
	Then I call Shared Step 214632(Power Designer Plus - MTR/BATT - Update BATACT (Active Battery Indicator) to Finish Processing Battery (Alone) Products):
	| ProductId      | BatteryType    |
	| TestCase220789 | Carbon zinc    |
	Then I switch to the 'SHA' tab
	Then I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase220789)
	Then In SHA Manager I confirm product Id color is blue for product saved as: TestCase220789

	@TestCase:220191

	Scenario: [220191] Nickel-Cadmium Battery - RU000346
	
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC220191
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel-Cadmium Battery
	Then I save the product information as: TestCase220191
	Then I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent  | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100      | false               | false       |            |
	Then I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
	Then I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I call Shared Step 150905 (Retailer - NR selected by default)
	Then I call Shared Step 145129 Regulatory Documents to Provide - Upload AIS and CCCR
	Then in the Additional Documents to Provide page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Then in the Optional Comments page I click Continue
	Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#Then I call Shared Step 54796 (Purchase Summary)
	Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase220191)
	Then I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase220191)
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I call Shared Step 214620 Power Designer Plus - AUTHORIZE Product (Applicable Only to Battery Products) for product saved as: TestCase220191
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase220191
	Then I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase220191)
	Then I call Shared Step 214632(Power Designer Plus - MTR/BATT - Update BATACT (Active Battery Indicator) to Finish Processing Battery (Alone) Products):
	| ProductId      | BatteryType    |
	| TestCase220191 | Nickel cadmium |
	Then I switch to the 'SHA' tab
	Then I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase220191)
	Then In SHA Manager I confirm product Id color is blue for product saved as: TestCase220191

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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulated_Batteries
Feature: Flow 16

@TestCase:59273
Scenario: [59273] Alkaline Battery - RU000344
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59273
	Given I delete all products with UPC Number: saved as UPC59273
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
	Then I save the product information as: TestCase59273
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 7439-96-5     | 60      | false               | false       |            |
		| 7782-42-5     | 10      | false               | false       |            |
		| 7440-66-6     | 25      | false               | false       |            |
		| 1310-58-3     | 5       | false               | false       |            |
	# removed Shared Step 57571
	And I should see the Formulation > Batteries Page
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 214520 (Waste Classification Data - Applicable Only to Alkaline Battery)
	#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 213071 (Enter Universal Product Code (UPC) - Applicable Only to Alkaline Battery-Quantity Field Required) for UPC saved as: UPC59273 with container type: Plastic Container size: 20 and quantity: 2
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 213199 - Regulatory Documents to Provide - Required Document Uploads - Applicable Only to Alkaline Battery
	Given I should see the Additional Documents to Provide Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273

@TestCase:59274
Scenario: [59274] Battery Containing Mercury - RU000729
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59274
	Given I delete all products with UPC Number: saved as UPC59274
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery Containing Mercury
	Then I save the product information as: TestCase59274
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59274

@TestCase:59276
Scenario: [59276] Lead Acid Battery - No Acid Included - RU001225
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59276
	Given I delete all products with UPC Number: saved as UPC59276
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid Battery - No Acid Included
	Then I save the product information as: TestCase59276
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59276
	
@TestCase:59277
Scenario: [59277] Magnesium Battery - RU000728
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59277
	Given I delete all products with UPC Number: saved as UPC59277
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Magnesium Battery
	Given I save the product information as: TestCase59277
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I save the product information as: TestCase59278
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59278

#Removed from regression: 2023/06
@ignore
@TestCase:59279
Scenario: [59279] Nickel-Cadmium Battery - RU000346
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59279
	Given I delete all products with UPC Number: saved as UPC59279
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
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
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Silver Battery
	Given I save the product information as: TestCase59280
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59280
	
@TestCase:59281
Scenario: [59281] Water-Charged Cell - RU001543
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59281
	Given I delete all products with UPC Number: saved as UPC59281
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Water-Charged Cell
	Given I save the product information as: TestCase59281
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59281
	
@TestCase:59282
Scenario: [59282] Zinc Air - RU001205
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59282
	Given I delete all products with UPC Number: saved as UPC59282
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Zinc Air
	Given I save the product information as: TestCase59282
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59282

#Removed from regression: 2023/06
@ignore
@TestCase:59275
Scenario: [59275] Carbon Zinc Battery - RU000727
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59275
	Given I delete all products with UPC Number: saved as UPC59275
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Carbon Zinc Battery
	Given I save the product information as: TestCase59275
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	
@TestCase:97484
Scenario: [97484] Stand alone Lead Acid non spill-able Battery
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lead sulfate  | 50      | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
	And I should see the Formulation > Batteries Page
	Then In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Declined
	Then In the Formulation > Batteries Section, I confirm displayed text is correct
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
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase97470
	
@TestCase:110324
Scenario: [110324] Alkaline Battery - Check Regulatory Documents To Provide Error Messaging - RU000344
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC110324
	Given I delete all products with UPC Number: saved as UPC110324
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
	Then I save the product information as: TestCase59273
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
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
	Given I should see the Additional Documents to Provide Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273

@TestCase:122366
Scenario:[122366] Battery Containing Product (BCP) (Transportation override at UPC level- New Feature)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC122366
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery-Containing Product
	Then I save the product information as: TestCase122366
	Then I call Shared Step 63704 (Product Information - US, No(DSV), No(PL), No(GNFR))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product.
		Given I add the following batteries:
	 | Battery Type    | Manufacturer                                                  | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As       |
	 | Lithium Primary | Pau Lithium Primary Battery by The WERCS LTD (WPS ID 1549664) | 4                               | 4                                  | lithiumbattery |
	Given I click continue
	And I set 'Product has had TCLP; Report is available' to: No
	And I set the Lead option to: No
	And I set the Mercury option to: No
	And I set the Silver option to: No
	And I set the Cadmium option to: No
	And I set the Chromium option to: No
	And I set the Barium option to: No
	And I set the Arsenic option to: No
	And I set the Selenium option to: No
	Given I click continue
	Then I should see the Electronic Equipment Page
	And I set 'Contains Circuit Board' to: No
	And I set 'Has a LCD or Plasma Display' to: No
	Given I click continue
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	And In the 'Select Retailers' window I select the retailer: Walgreens
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC122366, container type: Plastic Container and size: 12 click continue
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

	@TestCase:220789

	Scenario: [220789] Carbon Zinc Battery - RU000727
	
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC220789
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
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
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
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

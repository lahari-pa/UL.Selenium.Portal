@Shared
@NewProduct
@Homepage
@wercsmart
@run_Batteries
@PhysicalAndChemicalProp
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulated_Batteries
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@AdditionalDocsContactInfo

Feature: Batteries

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
@tfs_design
@ignore
@TestCase:97488
Scenario: [97488] Stand alone Lithium Battery vehicle
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium battery vehicle
	Then I save the product information as: TestCase97488
	#And I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type   | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
		| Lthium Primary | <any>        | 6                               | 6                                  |
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Lithium
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Lithium       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 60096 (Lithium Battery Transportation)
	And I click continue
	And If the UPCs Warning popup is displayed I click OK
	And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
	And I click continue
	And I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I click continue
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97488

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
#Removed from regression: 2024/02
@ignore
@TestCase:97489
Scenario: [97489] Stand alone Magnesium Battery
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Magnesium Battery
	Then I save the product information as: TestCase97489
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Magnesium
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Magnesium     | 100     | false               | false       |            |
	Given I click continue
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And If the UPCs Warning popup is displayed I click OK
	Given I should see the Regulatory Documents to Provide Page
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload a PDF
	Given I click the browse button for document type: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and for control label: Article Information Sheet (AIS) and upload a PDF
	Given I click continue
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I click continue
	And I should see the Data Acceptance Page
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97489

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
@TestCase:97495
Scenario: [97495] Stand alone Nickel-Cadmium Battery
	Given I log in with the account saved in TReVor as: ProductAccount	
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Then I should see the The Product Page	
	#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel-cadmium battery
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Nickel-cadmium battery
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Nickel-cadmium battery
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel-cadmium battery
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase97495	
	Then I should see the Product Information Page
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue
	Then I should see the Regulatory Documents to Provide Page	
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload a PDF
	When In the Regulatory Documents to Provide Section, set the radio option in section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	When In the Regulatory Documents to Provide Section, set the radio option in section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS. When providing an SDS it must be both U.S. and Canada formats.' to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and for control label: Article Information Sheet (AIS) and upload a PDF
	Then in the Regulatory Documents to Provide page, I click Continue	
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Then I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Nickel        | 100     | false               | false       |            |
	Given I click continue
	Given I should see the Formulation > Batteries Page
	#Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Then In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Given I click continue

	#And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given For 'U.S. Toxic Substances Control Act (TSCA) status' I select: This product is exempt from TSCA chemical Inventory listing requirements.
	Given For Canadian Environmental Protection Act (CEPA) status I select: Compliant with Domestic Substances List (DSL)
	Given I set 'Prop65' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should see the Retailer Page
	Then in the Retailer page, I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |

	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 200
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 1.005
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 20
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Blue
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	And I click continue
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And I navigate to the home page	
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97495

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
@TestCase:97494
Scenario: [97494] Stand alone Nickel Metal Hydride Battery
	Given I log in with the account saved in TReVor as: ProductAccount	
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel Metal Hydride (NiMH) Battery
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Nickel Metal Hydride (NiMH) Battery
	Then I set 'Type of Product' to: Nickel Metal Hydride (NiMH) Battery
	Then in the New Product page, I click Continue
	Then I save the product information as: TestCase97494
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should see the Product Information Page
	When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue
	Then I should see the Regulatory Documents to Provide Page	
	Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload a PDF
	When In the Regulatory Documents to Provide Section, set the radio option in section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	When In the Regulatory Documents to Provide Section, set the radio option in section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS. When providing an SDS it must be both U.S. and Canada formats.' to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for document type: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and for control label: Article Information Sheet (AIS) and upload a PDF
	Then in the Regulatory Documents to Provide page, I click Continue	
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Then I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Nickel        | 100     | false               | false       |            |
	Given I click continue
	Given I should see the Formulation > Batteries Page
	#Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Then In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Given I click continue
	#And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given For 'U.S. Toxic Substances Control Act (TSCA) status' I select: This product is exempt from TSCA chemical Inventory listing requirements.
	Given For Canadian Environmental Protection Act (CEPA) status I select: Compliant with Domestic Substances List (DSL)
	Given I set 'Prop65' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue	
	#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should see the Retailer Page
	Then in the Retailer page, I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 300
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 1.005
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 20
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	And I click continue
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97494

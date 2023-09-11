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
@run_Flow4
Feature: Flow 4

@ignore
@TestCase:57922
Scenario: [57922] Odor Remover/Eliminator - Aerosol (RU001086) - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Odor Remover/Eliminator - Aerosol
	Then I save the product information as: TestCase57922
	Given I call Shared Step 118085 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I call Shared Step 130960 (Additional Documents to Provide - VOC Product Label Upload)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Odor Remover/Eliminator - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57922

@ignore
@TestCase:57924
Scenario: [57924] Penetrants (RU000801) - Flow 4AL - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Penetrants
	Then I save the product information as: TestCase57924
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Penetrants
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57924

@ignore
@TestCase:57925
Scenario: [57925] Floor Maintenance Product - Non-Aerosol (RU001433) 4-L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Maintenance Product - Non-Aerosol
	Then I save the product information as: TestCase57925
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Floor Maintenance Product - Non-Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57925

@TestCase:57927
Scenario: [57927] Floor Wax - Wood (RU000790) 4LS - 4S
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax - Wood
	Then I save the product information as: TestCase57927
	Given I call Shared Step 118085 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Floor Wax - Wood
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57927

@ignore
@TestCase:57931
Scenario: [57931] Hair Styling Product - Mousse (RU000669) - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Mousse
	Then I save the product information as: TestCase57931
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Product - Mousse
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57931

@ignore
@TestCase:57933
Scenario: [57933] Hair Styling Product - Aerosol and Pump Spray - Flow 4AL - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Aerosol and Pump Spray
	Then I save the product information as: TestCase57933
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Product - Aerosol and Pump Spray
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57933

@TestCase:57950
Scenario: [57950] Conditioner - Leave In (RU001272) 4-L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner - Leave In (Liquid, Non Aerosol)
	Then I save the product information as: TestCase57950
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Conditioner - Leave In (Liquid, Non Aerosol)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57950

@TestCase:57952
Scenario: [57952] Hair Styling Gel- (RU000749) 4LS - 4S
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Gel
	Then I save the product information as: TestCase57952
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Gel
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57952

@TestCase:57958
Scenario: [57958] Adhesive - Aerosol Web Spray (RU000909) - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Adhesive - Aerosol Web Spray
	Then I save the product information as: TestCase57958
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Adhesive - Aerosol Web Spray
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57958

@ignore
@TestCase:57977
Scenario: [57977] Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding(RU000912) - 4AL - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding
	Then I save the product information as: TestCase57977
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57977

@ignore
@TestCase:57982
Scenario: [57982] Bonding agent (RU000023) - 4All - 4G
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bonding agent
	Then I save the product information as: TestCase57982
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57978 (Physical and Chemical Properties - All select Gas - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation - IMDG UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bonding agent
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57982

@TestCase:57983
Scenario: [57983] Lubricant, Multi-Purpose, Not for Personal Use (RU000674) 4L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lubricant, Multi-Purpose, Not for Personal Use
	Then I save the product information as: TestCase57983
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lubricant, Multi-Purpose, Not for Personal Use
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57983

@OnlyInStaging
@TestCase:57985
Scenario: [57985] Footwear or Leather Care Product - Aerosol (RU000744) - Testing New Flow Update
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Aerosol
	Then I save the product information as: TestCase57985
	Then I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Then I call Shared Step 213391(Physical and Chemical Properties (Applicable Only to Flow 6-A Type of Products) - Primary Physical State (AEROSOL ONLY) / Secondary Physical State (ANY)):
		| Section                    | do not have exact data | Value                                                                                                 |
		| Primary Physical State     |                        | Aerosol                                                                                               |
		| Secondary Physical State   |                        | Solid spray                                                                                           |
		| pH                         |  Yes                   | Not tested/Unknown                                                                                    |
		| has a flammable propellant |                        | This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS). |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber	     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 1174921-73-3   | 37.5    | false               | false       |            |
		| 106-97-8       | 25.5    | false               | false       |            |
		| 74-98-6        | 25.5    | false               | false       |            |
		| 141-78-6       | 11.5    | false               | false       |            |
	Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65):
		| TSCA																		                  | Prop 65 |
		| This product is subject to and complies with TSCA chemical Inventory listing requirements.  | No      |
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 75                    | 15                         | Yes            |
	Then I confirm that I see the following CARB value: 75
	Then I confirm that I see the following OTC Model Rule value: 15
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then I should see data for States in the 'VOC Content as weight percentage of total formula' table
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| New York        | State Allowable Limit | 15        | 75                  | Does not exceed the State Limits |
	Then I should see the following Voc Limits present:
	| Use									     | VOC Compliance Limit | Regulation           |
	| Footwear or Leather Care Product - Aerosol | 75                   | OTC Model rule limit |
	| Footwear or Leather Care Product - Aerosol | 75                   | CARB limit           |
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the Ozone Transport Commission
	Then I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 221015 (Summary Tab - Product's Data Verification When Request to Author is NOT Selected in the Regulatory Documents to Provide Page (Applies Only to Footwear or Leather Care Product Aerosol (RU000744))
	| Section                                    | Value                                                                                                                                                                                |
	| Type of Product                            | Footwear or Leather Care Product - Aerosol                                                                                                                                           |
	| FIFRA 25(b) Exempt						 | Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial) |
	| UN Number                                  | UN1950                                                                                                                                                                               |
	| Proper Shipping Name                       | Aerosols                                                                                                                                                                             |
	| Hazard Class                               | 2.1                                                                                                                                                                                  |
	| Packing Group                              | None                                                                                                                                                                                 |
	| CARB									     | 75                                                                                                                                                                                   |
	| OTC Model Rule							 | 15                                                                                                                                                                                   |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57985

@TestCase:57988
Scenario: [57988] Anti-Static Product - Non-Aerosol (RU000667) 4-L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Non-Aerosol
	Then I save the product information as: TestCase57988
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Non-Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57988


@TestCase:57990
Scenario: [57990] Footwear or Leather Care Product - Solid (RU000745)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Solid
	Then I save the product information as: TestCase57990
	Then I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65):
		| TSCA																		 | Prop 65 |
		| This product is exempt from TSCA chemical Inventory listing requirements.  | No      |
	Then I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| Yes                                      | 5                     | 5                          | Yes            |
	Then I confirm that I see the following CARB value: 5
	Then I confirm that I see the following OTC Model Rule value: 5
	Then I should see data for States in the 'VOC Content as weight percentage of total formula' table
	Then I should see the following Voc Limits present:
	| Use									   | VOC Compliance Limit | Regulation           |
	| Footwear or Leather Care Product - Solid | 55                   | OTC Model rule limit |
	| Footwear or Leather Care Product - Solid | 55                   | CARB limit           |
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the Ozone Transport Commission
	Then I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Then I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Chrome     | Magnolia | No data available | 1                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear or Leather Care Product - Solid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57990

@TestCase:57991
Scenario: [57991] Glue sticks for glue guns- (RU000300) - 4S
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Glue sticks for glue guns
	Then I save the product information as: TestCase57991
	Given I generate a random UPC number and save as: UPC57991
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 24937-78-8	   | 40   | false               | false       |            |
		| 68131-77-1	   | 45   | false               | false       |            |
		| 8002-74-2        | 15   | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 10                     | 10                        | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I click continue
	Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC57991, container type: Plastic Container and size: 13.2
	Given I should see following container type from the drop down list
	|Container Type|
	|Cardboard|
	|Cardboard with Gas Cylinder|
	|Clay-Coated News Board|
	|Coated or Laminated Paperboard|
	|Empty Syringe - Medical|
	|Full Syringe - Medical|
	|Glass Container|
	|Metal Container|
	|Metal Cylinder|
	|Other |
	|Paper bag|
	|Plastic bag|
	|Plastic Container|
	|Plastic Liner/Corrugate|
	|Vial - Medical|
	|Wooden box|
	|Wooden crate|
	And I confirm that retailer "WG" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue	
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given I call Shared step 214825 (Additional Documents to Provide - Upload Product Label - Continue)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given in the Optional Comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Glue sticks for glue guns
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57991

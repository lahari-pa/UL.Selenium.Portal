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
@PaymentMethods
@SHA
@CreateProducts
@Studio
@ProductSetUp
@run_Transportation

Feature: Transportation

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1106
Scenario: [65702] Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for IATA and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
#And I call Shared Step 118085 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the International Air Transport (IATA) Classification Page
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And I click continue
And Copy information from my U.S. Department of Transportation data should not be showing any error messages
And Technical Name (if applicable) should not be showing any error messages
And UN Number should be showing the error messages: This is a required field.
And Proper Shipping Name should be showing the error messages: This is a required field.
And Hazard Class (select) should be showing the error messages: This is a required field.
And Packing Group (select) should be showing the error messages: This is a required field.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65702

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1107
Scenario: [65703] Transportation - Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for IMDG and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
#And I call Shared Step 118085 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65699 (Transport - Select IMDG & Limited Shipping - No Continue)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the International Marine (IMDG) Classification Page
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And I click continue
And Copy information from my U.S. Department of Transportation data should not be showing any error messages
And Technical Name (if applicable) should not be showing any error messages
And UN Number should be showing the error messages: This is a required field.
And Proper Shipping Name should be showing the error messages: This is a required field.
And Hazard Class (select) should be showing the error messages: This is a required field.
And Packing Group (select) should be showing the error messages: This is a required field.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65703

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1108
Scenario: [65706] Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for TDG and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
#And I call Shared Step 118085 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65701 (Transport - Select TDG & Limited Shipping - No Continue)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And I click continue
And Copy information from my U.S. Department of Transportation data should not be showing any error messages
And Technical Name (if applicable) should not be showing any error messages
And UN Number should be showing the error messages: This is a required field.
And Proper Shipping Name should be showing the error messages: This is a required field.
And Hazard Class (select) should be showing the error messages: This is a required field.
And Packing Group (select) should be showing the error messages: This is a required field.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65706

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1109
Scenario: [65754] Transportation - Copy information from my U.S. Department of Transportation data check box &  IATA data
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
#And I call Shared Step 118085 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the International Air Transport (IATA) Classification Page
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1950
And Proper Shipping Name should be showing the value: Choose...
And The following options should not be displayed for section: Proper Shipping Name
| Option   |
| Aerosols |
And Hazard Class (select) should be showing the value: 2.1
And I set the Proper Shipping Name field to: Aerosols, flammable
And Hazard Class (select) should be showing the value: 2.1
And I set the Proper Shipping Name field to: Aerosols, non-flammable, containing substances in Division 6.1, Packing Group III
And Hazard Class (select) should be showing the value: 2.2
And Packing Group (select) should be showing the value: None
And The following options should be displayed exclusively for section: Packing Group (select)
| Option |
| None   |
And I call Shared Step 65939 (Go To Transport DOT Step - Enter UN1966, Confirm data - NO CONTINUE)
And I click continue
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
#Confirm that ^ checkbox is selected (failing currently)?
And UN Number should be showing the value: UN1950
And I uncheck the checkbox with description: Copy information from my U.S. Department of Transportation data
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1966
And Proper Shipping Name should be showing the value: Hydrogen, refrigerated liquid
And Technical Name should be showing the value: Technical Name Test
And Hazard Class (select) should be showing the value: 2.1
And Packing Group should be showing the value: None
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65754

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1110
Scenario: [65940] Transportation - Copy information from my U.S. Department of Transportation data check box &  IMDG data
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
#And I call Shared Step 118085 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65699 (Transport - Select IMDG & Limited Shipping - No Continue)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the International Marine (IMDG) Classification Page
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1950
And Proper Shipping Name should be showing the value: Aerosols
And Hazard Class (select) should be showing the value: 2
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option |
| 2      |
And Packing Group (select) should be showing the value: None
And The following options should be displayed exclusively for section: Packing Group (select)
| Option |
| None   |
And I call Shared Step 65939 (Go To Transport DOT Step - Enter UN1966, Confirm data - NO CONTINUE)
And I click continue
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And UN Number should be showing the value: UN1950
And I uncheck the checkbox with description: Copy information from my U.S. Department of Transportation data
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1966
And Proper Shipping Name should be showing the value: Hydrogen, refrigerated liquid
And Technical Name should be showing the value: Technical Name Test
And Hazard Class (select) should be showing the value: 2.1
And Packing Group should be showing the value: None
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65940

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1111
Scenario: [65944] Transportation - Copy information from my U.S. Department of Transportation data check box &  TDG data
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65701 (Transport - Select TDG & Limited Shipping - No Continue)
And I click continue
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number field to: UN1975
And Proper Shipping Name should be showing the value: Nitric oxide and dinitrogen tetroxide mixtures
And The following options should be displayed exclusively for section: Proper Shipping Name
| Option                                         |
| Nitric oxide and dinitrogen tetroxide mixtures |
And I set the Technical Name field to: Technical Test Name
And Hazard Class (select) should be showing the value: 2.3
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option |
| 2.3    |
And Packing Group (select) should be showing the value: None
And The following options should be displayed exclusively for section: Packing Group (select)
| Option |
| None   |
And I click continue
And I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1975
And Proper Shipping Name should be showing the value: Nitric oxide and dinitrogen tetroxide mixture
And Hazard Class (select) should be showing the value: 2.3, (5.1), (8)
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option          |
| 2.3, (5.1), (8) |
And Packing Group (select) should be showing the value: None
And The following options should be displayed exclusively for section: Packing Group (select)
| Option |
| None   |
And I call Shared Step 65939 (Go To Transport DOT Step - Enter UN1966, Confirm data - NO CONTINUE)
And I click continue
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And UN Number should be showing the value: UN1975
And I uncheck the checkbox with description: Copy information from my U.S. Department of Transportation data
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1966
And Proper Shipping Name should be showing the value: Hydrogen, refrigerated liquid
And Technical Name should be showing the value: Technical Name Test
And Hazard Class (select) should be showing the value: 2.1
And Packing Group should be showing the value: None
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65944


# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:1112
Scenario: [65947] Transportation - Copy information from DOT for all modes - confirm data is shown in WPS Studio correctly
#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I log in with the account saved in TReVor as: ProductAccount
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
And I should see the Physical and Chemical Properties Page
And The following options should be displayed for section: Primary Physical State  
| Option |
| Liquid |
| Solid  |
And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 10
And I set the pH option to: 10.5
And I set the Boiling Point (in Celsius) option to: 120
And I set the Flash Point (in Celsius) option to: 23
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Insoluble
And I click continue
Then I call Shared Step 143418 (Additional Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I set the Select all modes of transport that you've classified the product for field to: IMDG
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: IMDG
And I set the Select all modes of transport that you've classified the product for field to: IATA
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: IATA
And I set the Select all modes of transport that you've classified the product for field to: TDG
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: TDG
And I click continue
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number field to: UN2762
And The following options should be displayed exclusively for section: Proper Shipping Name
| Option                                               |
| Organochlorine pesticides, liquid, flammable, toxic |
And I set the Technical Name field to: Technical Name UN2762
And Hazard Class (select) should be showing the value: 3
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option |
| 3      |
And I set the Packing Group (select) field to: II
And I select the first option in section: Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
And I click continue
And I should see the International Air Transport (IATA) Classification Page
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN2762
And The following options should be displayed exclusively for section: Proper Shipping Name
| Option                                               |
| Organochlorine pesticide, liquid, flammable, toxic |
And Technical Name should be showing the value: Technical Name UN2762
And Hazard Class (select) should be showing the value: 3
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option |
| 3      |
And Packing Group (select) should be showing the value: II
And I confirm that: II is not the only option for section: Packing Group (select)
And I select the first option in section: Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
And I click continue

And I should see the International Marine (IMDG) Classification Page
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN2762
And The following options should be displayed exclusively for section: Proper Shipping Name
| Option                                               |
| Organochlorine pesticide, liquid, flammable, toxic |
And Technical Name should be showing the value: Technical Name UN2762
And Hazard Class (select) should be showing the value: 3
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option |
| 3      |
And Packing Group (select) should be showing the value: II
And I confirm that: II is not the only option for section: Packing Group (select)
And I select the first option in section: Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
And I click continue

And I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN2762
And The following options should be displayed exclusively for section: Proper Shipping Name
| Option                                               |
| Organochlorine pesticide, liquid, flammable, toxic |
And Technical Name should be showing the value: Technical Name UN2762
And The following options should be displayed exclusively for section: Hazard Class (select)
| Option    |
| 3, (6.1) |
And Packing Group (select) should be showing the value: II
And I confirm that: II is not the only option for section: Packing Group (select)
And I click continue

And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
And I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order

And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase65947)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Assigned

##Scenario: Test
#Given I save to context name: TestCase65947 and value: 1549266 
#Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase65947)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase65947)
And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for DOTUN
And I click alias subsection option DOT UN number base classification and confirm data as:
| Data           |
| UN2762         |
#And I click alias subsection option DOTUNNUM and confirm data as:
#| Data         |
#| 2762         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for UNT
And I click alias subsection option UN-No. and confirm data as:
| Data           |
| UN2762         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for UNM
And I click alias subsection option UN-No. and confirm data as:
| Data           |
| UN2762         |
#And I click alias subsection option UNMNUM and confirm data as:
#| Data         |
#| 2762         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for UNI
And I click alias subsection option UN-No. and confirm data as:
| Data           |
| UN2762         |
#And I click alias subsection option UNIFFC and confirm data as:
#| Data                  |
#| Irritant: Liquid      |
#| Flammable Liquid: I-C |
#And I click alias subsection option UNINUM and confirm data as:
#| Data           |
#| 2762         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for HCT
And I click alias subsection option Hazard Class and confirm data as:
| Data           |
| 3         |
#And I click alias subsection option Haz Class - Target Only - Blank if ORM-D and confirm data as:
#| Data           |
#| 3         |
#And I click alias subsection option TDG Hazard Class w/o end letters for rule and confirm data as:
#| Data           |
#| 3         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for HCM
And I click alias subsection option Hazard Class and confirm data as:
| Data           |
| 3         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for HCI
And I click alias subsection option Hazard Class and confirm data as:
| Data           |
| 3         |
#And I click alias subsection option HAZARD CLASS IATA AIR CARGO and confirm data as:
#| Data           |
#| 3         |
#And I click alias subsection option HAZARD CLASS INTERNATIONAL AIR CARGO (BASIC RETAILER) and confirm data as:
#| Data           |
#| 3         |
#And I click alias subsection option HCIPR and confirm data as:
#| Data           |
#| 3         |
#And I click alias subsection option HCIV and confirm data as:
#| Data           |
#| 3         |
#And I click alias subsection option HAZARD CLASS IATA AIR PASSENGER and confirm data as:
#| Data           |
#| 3         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for DOTHAZ
And I click alias subsection option DOTHAZ and confirm data as:
| Data           |
| 3         |
#And I click alias subsection option SPDOTHAZ and confirm data as:
#| Data           |
#| 3         |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for SNAME
And I click alias subsection option SNAME and confirm data as:
| Data           |
| Organochlorine pesticides, liquid, flammable, toxic  |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for PGT
And I click alias subsection option PGT and confirm data as:
| Data           |
| II |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for PGI
And I click alias subsection option Packing Group and confirm data as:
| Data           |
| II |
#And I click alias subsection option PGIEX and confirm data as:
#| Data           |
#| The UN# classification assigned to this product has a specific Packaging Group required. |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for PGM
And I click alias subsection option Packing Group and confirm data as:
| Data           |
| II |
#And I click alias subsection option PGMEX and confirm data as:
#| Data           |
#| The UN# classification assigned to this product has a specific Packaging Group required. |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for DOTPG
And I click alias subsection option DOT Packing Group base classification and confirm data as:
| Data           |
| II |
#And I click alias subsection option SPDOTPG and confirm data as:
#| Data           |
#| II |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for IMSN
And I click alias subsection option IMSN and confirm data as:
| Data           |
| Organochlorine pesticide, liquid, flammable, toxic |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for TDSN
And I click alias subsection option TDSN and confirm data as:
| Data           |
| Organochlorine pesticide, liquid, flammable, toxic |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for IMDGCP
And I click alias subsection option IMDGCP and confirm data as:
| Data           |
| 1 |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for IATACP
And I click alias subsection option IATACP and confirm data as:
| Data           |
| 1 |
Given I call Shared Step 81633 - WPS PD+ - Product Attributes - Filter for TDGCP
And I click alias subsection option TDGCP and confirm data as:
| Data           |
| 1 |


@ScenarioId:10101
Scenario: [126286] Transportation Details DOT - UN1057 Prompts the 'For the Lighter, Provide the DOT Approval Number' Field

Given I call Shared Step 67284 (Login into WERCSmart Portal - Visual Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): LIGHTER FLUID
Given I generate a random UPC number and save as: UPC126286
Then I save the product information as: TestCase126286
Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Then I click continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber  | ComponentName                                                               | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 68410-97-9 | Distillates, petroleum, light distillate hydrotreating process, low-boiling | 70      |                     |            |             |
| 64742-49-0 | Naphtha, petroleum, hydrotreated light                                      | 30      |                     |            |             |
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Then in page U. S. Department of Transportation (DOT) Classification I should see no errors
And I click the page heading: U. S. Department of Transportation (DOT) Classification
And For the lighter, provide the DOT Approval Number (LAA) should be showing the value: 123
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase126286

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
@StepsPrototype
@ProductSetUp
@run_Transportation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation



Feature: Transportation


Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto28 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |


# Assigned to Beverly Barrett
# Created by Beverly Barrett
@TestCase:65702
Scenario: [65702] Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for IATA and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I click the Add Product icon in the Navigation Pane
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Given in the New Product page I click Continue
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Given I generate a random UPC number and save as: UPC65702
Then I save the product information as: TestCase65702
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
@TestCase:65703
Scenario: [65703] Transportation - Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for IMDG and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I click the Add Product icon in the Navigation Pane
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Given in the New Product page I click Continue
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Given I generate a random UPC number and save as: UPC65703
Then I save the product information as: TestCase65703
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
@TestCase:65706
Scenario: [65706] Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for TDG and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Given I generate a random UPC number and save as: UPC65706
Then I save the product information as: TestCase65706
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
@TestCase:65754
Scenario: [65754] Transportation - Copy information from my U.S. Department of Transportation data check box &  IATA data
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I click the Add Product icon in the Navigation Pane
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Given in the New Product page I click Continue
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Given I generate a random UPC number and save as: UPC65754
Then I save the product information as: TestCase65754
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
@TestCase:65940
Scenario: [65940] Transportation - Copy information from my U.S. Department of Transportation data check box &  IMDG data
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Given I generate a random UPC number and save as: UPC65940
Then I save the product information as: TestCase65940
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
And UN Number should be showing the value: UN1966
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
@TestCase:65944
Scenario: [65944] Transportation - Copy information from my U.S. Department of Transportation data check box &  TDG data
    #Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
    Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
    #Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue
    #And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
    Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
    Then in the The Product page, I click Continue
    Given I generate a random UPC number and save as: UPC65944
    Then I save the product information as: TestCase65944
	#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: (Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)|Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth)|Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial))
	Then In the Product Information Section, set the option in section: 'Select countries the product may be sold in' to: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then in the Product Information page, I click Continue
    #And I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
    #| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
    #| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	And I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
	Then In the Physical and Chemical Properties Section, for section: 'Specific Gravity' enter text: 1
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 85
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point \(in Celsius\)' enter text: 65
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Cloth not soluble
	Then in the Product Characteristics page, I click Continue
    #And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
    Given I should be on the Ingredients Page
    #Then In the Ingredients section, add the following ingredients:
    #| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    #| component name | Chlorine       | 100     |                     |               |             |
	Then In the component search box, enter text: Chlorine
	Then In the component search box, click result where component name contains: Chlorine
    Then In the Ingredients Table row with component name: Chlorine, in percentage column text input enter: 100
    Then in the Ingredients page, I click Continue
    #And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
    And I should be on the Transportation Details 1 Page
    And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes

    #And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
    Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
    Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity

    #And I call Shared Step 65701 (Transport - Select TDG & Limited Shipping - No Continue)
    Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: TDG
    Then In the Transportation Details 1 Section, set the option for TDG mode of transport to: Shipping with limited quantity
    Then in the Transportation Details 1 page, I click Continue
    And I should be on the U.S. Department of Transportation (DOT) Classification Page
    #And I set the UN Number field to: UN1975
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1975

    #And Proper Shipping Name should be showing the value: Nitric oxide and dinitrogen tetroxide mixtures
    And In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Nitric oxide and dinitrogen tetroxide  mixtures

    #And The following options should be displayed exclusively for section: Proper Shipping Name
    #| Option                                         |
    #| Nitric oxide and dinitrogen tetroxide mixtures |

    #And I set the Technical Name field to: Technical Test Name
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Technical Name (if applicable)': to: Technical Test Name

    #And Hazard Class (select) should be showing the value: 2.3
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.3

    #And The following options should be displayed exclusively for section: Hazard Class (select)
    #| Option |
    #| 2.3    |


    #And Packing Group (select) should be showing the value: None
	And In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'Packing Group (select)' contains value: None

    #And The following options should be displayed exclusively for section: Packing Group (select)
    #| Option |
    #| None   |

    #And I click continue
    And Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue

    #And I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
    And I should be on the Canada - Transportation of Dangerous Goods (TDG) Classification Page

    #And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
    And In the Canada - Transportation of Dangerous Goods \(TDG\) Classification Section, I check checkbox 'Copy information from my U.S. Department of Transportation data'


    #And UN Number should be showing the value: UN1975
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'UN Number' contains value: UN1975

    #And Proper Shipping Name should be showing the value: Nitric oxide and dinitrogen tetroxide mixture
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Proper Shipping Name' contains value: Nitric oxide and dinitrogen tetroxide mixture

    #And Hazard Class (select) should be showing the value: 2.3, (5.1), (8)
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Hazard Class (select)' contains value: 2.3, (5.1), (8)

    #And The following options should be displayed exclusively for section: Hazard Class (select)
    #| Option          |
    #| 2.3, (5.1), (8) |

    #And Packing Group (select) should be showing the value: None
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Packing Group (select)' contains value: None

    #And The following options should be displayed exclusively for section: Packing Group (select)
    #| Option |
    #| None   |

    #And I call Shared Step 65939 (Go To Transport DOT Step - Enter UN1966, Confirm data - NO CONTINUE)
    And I click the page heading: Transportation Details 1
    Then I should be on the U.S. Department of Transportation (DOT) Classification Page
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1966
    And In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Hydrogen, refrigerated liquid
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Technical Name (if applicable)': to: Technical Test Name
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
	And In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'Packing Group (select)' contains value: None
    #And I click continue
    Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
    And I should be on the Canada - Transportation of Dangerous Goods (TDG) Classification Page
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, I check checkbox 'Copy information from my U.S. Department of Transportation data'
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'UN Number' contains value: UN1966
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Proper Shipping Name' contains value: Hydrogen, refrigerated liquid
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Hazard Class (select)' contains value: 2.1
    And In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Packing Group (select)' contains value: None

    And I navigate to the home page
    #And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65944
	Then In the Product Grid, delete the product saved as: TestCase65944


# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ignore
@TestCase:65947
Scenario: [65947] Transportation - Copy information from DOT for all modes - confirm data is shown in WPS Studio correctly
#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
And I should see the Physical and Chemical Properties Page
And The following options should be displayed for section: Primary Physical State  
| Option |
| Liquid |
| Solid  |
And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Relative Density option to: 10
And I set the pH option to: 10.5
And I set the Boiling Point (in Celsius) option to: 120
And I set the Flash Point (in Celsius) option to: 23
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Insoluble
And I click continue
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
And I should see the U.S. Department of Transportation (DOT) Classification Page
And I set the UN Number field to: UN2762
And The following options should be displayed exclusively for section: Proper Shipping Name
| Option                                              |
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
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

And I should see the Additional Documents to Provide Page
And I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order

And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto28 and Open SHA manager)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase65947)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Assigned

##Scenario: Test
#Given I save to context name: TestCase65947 and value: 1549266 
#Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto28 and Open SHA manager)
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


@TestCase:126286
Scenario: [126286] Transportation Details DOT - UN1057 Prompts the 'For the Lighter, Provide the DOT Approval Number' Field

Given I call Shared Step 67284 (Login into WERCSmart Portal - Visual Automation Account)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): LIGHTER FLUID
Given I generate a random UPC number and save as: UPC126286
Then I save the product information as: TestCase126286
#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I should see the Product Information Page
Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page I click Continue
Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber  | ComponentName                                                               | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 68410-97-9 | Distillates, petroleum, light distillate hydrotreating process, low-boiling | 70      |                     |            |             |
| 64742-49-0 | Naphtha, petroleum, hydrotreated light                                      | 30      |                     |            |             |
#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Then in page U.S. Department of Transportation (DOT) Classification I should see no errors
And I click the page heading: U.S. Department of Transportation (DOT) Classification
And For the lighter, provide the DOT Approval Number (LAA) should be showing the value: 123
#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase126286
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase126286

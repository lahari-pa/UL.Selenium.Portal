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
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@ignore
@run_EPAState4

Feature:  EPA State Expiry Date Validation 4 (Suite ID: 56545)

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56622
Scenario: [56622] Pesticide Data - EPA Expiration date validation (Rhode Island - Nov 30th for current year, until Sept 1st, then Nov 30th of this or next year)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#And I In the shared steps below select Pet Shampoo with Pest Control as your product type
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	#And I We will be working with RI (Rhode Island) for the next set of steps
	And I call Shared Step 55858 (EPA expiration date - enter current year - NOT Nov 30th) for state: RI
	Then in page Pesticide Details - State Registration page I should see error: State RI: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
	And I call Shared Step 55859 (EPA expiration date - enter next year - Nov 30th) for state: RI
	#And I If the current date is after Sept 1st then Confirm that no error is shown for the States - if the current date is before Sept 1st then the error "SaveState RI: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable" will be shown
	And If the current date is after (MM/DD): 09/01 then I confirm no error is shown for the State: RI - else I confirm the following error is displayed: State RI: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
	And I call Shared Step 55860 (Expiration date - enter this year - Nov 30th) for state: RI
	And I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56622

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56624
Scenario: [56624] Pesticide Data - EPA Expiration date validation (Vermont - Nov 30th for current year, until Sept 1st, then Nov 30th of this or next year)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55858 (EPA expiration date - enter current year - NOT Nov 30th) for state: VT
	Then in page Pesticide Details - State Registration page I should see error: State VT: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
	And I call Shared Step 55859 (EPA expiration date - enter next year - Nov 30th) for state: VT
	And If the current date is after (MM/DD): 09/01 then I confirm no error is shown for the State: VT - else I confirm the following error is displayed: State VT: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
	And I call Shared Step 55860 (Expiration date - enter this year - Nov 30th) for state: VT
	And I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56624

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56625
Scenario: [56625] Pesticide Data - EPA Expiration date validation (South Carolina - Aug 31st until June 1st then Aug 31st for this or next year)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I select expiration date (current year - Not August 31st) for state: SC
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State SC: Valid dates are August 31 of current calendar year until June 1, at which time August 31 of either the current or the following calendar year would be acceptable.
	And I select expiration date (next year - Not August 31st) for state: SC
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State SC: Valid dates are August 31 of current calendar year until June 1, at which time August 31 of either the current or the following calendar year would be acceptable.
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| SC    | 31  | 08    | no              |
	And I click continue
	And If the current date is after (MM/DD): 08/31 then I confirm the error is displayed: 'The expiration date must be a valid future date' - else I confirm that no error is shown and the 'Transportation Details 1' page has loaded
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56625

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56627
Scenario: [56627] Pesticide Data - EPA Expiration date validation (North Dakota - December 31st no more than 2 years out but must be ODD number)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ND
	Then in page Pesticide Details - State Registration page I should see error: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ND
	Then in page Pesticide Details - State Registration page I should see error: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| ND    | 1   | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ND
	And If the current year is an even number - Confirm that an error shows: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
	And If the current year is an odd number - Confirm that an error shows: NONE
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ND
	And If the next year is an even number - Confirm that an error shows: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
	And If the next year is an odd number - Confirm that an error shows: NONE
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| ND    | 31   | 12    |
	And I click continue
	And If the current year is an even number - Confirm that an error shows: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
	And If the current year is an odd number I confirm that no error is displayed and the 'Transportation Details 1' page has loaded
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56627

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56629
Scenario: [56629] Pesticide Data - EPA Expiration date validation (Florida - December 31st no more than 2 years out but must be EVEN number)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: FL
	Then in page Pesticide Details - State Registration page I should see error: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: FL
	Then in page Pesticide Details - State Registration page I should see error: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| FL    | 1   | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: FL
	And If the current year is an odd number - Confirm that an error shows: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
	And If the current year is an even number - Confirm that an error shows: NONE
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: FL
	And If the next year is an odd number - Confirm that an error shows: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
	And If the next year is an even number - Confirm that an error shows: NONE
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| FL    | 31  | 12    |
	And I click continue
	And If the current year is an odd number - Confirm that an error shows: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
	And If the current year is an even number I confirm that no error is displayed and the 'Transportation Details 1' page has loaded
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56629

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56635
Scenario: [56635] Pesticide Data - EPA Expiration date validation (Arizona - Dec 31st no more than 2 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AZ
	Then in page Pesticide Details - State Registration page I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AZ
	Then in page Pesticide Details - State Registration page I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
	And I call Shared Step 55886 (EPA expiration date - enter current year plus 2 - NOT Dec 31st) for state: AZ
	Then in page Pesticide Details - State Registration page I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AZ
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AZ
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55887 (EPA expiration date - enter current year plus 2 - Dec 31st) for state: AZ
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 3:
		| State | Day | Month |
		| AZ    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56635


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56636
Scenario: [56636] Pesticide Data - EPA Expiration date validation (Illinois - Dec 31st no more than 2 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IL
	Then in page Pesticide Details - State Registration page I should see error: State IL: Valid dates are December 31 no more than two (2) calendar years out.
	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IL
	Then in page Pesticide Details - State Registration page I should see error: State IL: Valid dates are December 31 no more than two (2) calendar years out.
	And I call Shared Step 55886 (EPA expiration date - enter current year plus 2 - NOT Dec 31st) for state: IL
	Then in page Pesticide Details - State Registration page I should see error: State IL: Valid dates are December 31 no more than two (2) calendar years out.
	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IL
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IL
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55887 (EPA expiration date - enter current year plus 2 - Dec 31st) for state: IL
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 3:
		| State | Day | Month |
		| IL    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State IL: Valid dates are December 31 no more than two (2) calendar years out.
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56636

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56637
Scenario: [56637] Pesticide Data - EPA Expiration date validation (Hawaii - Dec 31st no more than 3 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: HI
	Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 no more than three (3) calendar years out.
	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: HI
	Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 no more than three (3) calendar years out.
	And I call Shared Step 55886 (EPA expiration date - enter current year plus 2 - NOT Dec 31st) for state: HI
	Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 no more than three (3) calendar years out.
	And I select EPA expiration date - enter current year plus 3:
		| State | Day | Month |
		| HI    | 1   | 10    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 no more than three (3) calendar years out.
	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: HI
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: HI
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55887 (EPA expiration date - enter current year plus 2 - Dec 31st) for state: HI
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 3:
		| State | Day | Month |
		| HI    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 4:
		| State | Day | Month |
		| HI    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 no more than three (3) calendar years out.
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56637

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56639
Scenario: [56639] Pesticide Data - EPA Expiration date validation (Connecticut - Dec 31st no more than 5 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CT
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CT
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I call Shared Step 55886 (EPA expiration date - enter current year plus 2 - NOT Dec 31st) for state: CT
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I select EPA expiration date - enter current year plus 3:
		| State | Day | Month |
		| CT    | 1   | 10    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I select EPA expiration date - enter current year plus 4:
		| State | Day | Month |
		| CT    | 1   | 10    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I select EPA expiration date - enter current year plus 5:
		| State | Day | Month |
		| CT    | 1   | 10    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CT
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CT
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55887 (EPA expiration date - enter current year plus 2 - Dec 31st) for state: CT
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 3:
		| State | Day | Month |
		| CT    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 4:
		| State | Day | Month |
		| CT    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 5:
		| State | Day | Month |
		| CT    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 6:
		| State | Day | Month |
		| CT    | 31  | 12    |
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 no more than five (5) calendar years out at any given time.
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56639

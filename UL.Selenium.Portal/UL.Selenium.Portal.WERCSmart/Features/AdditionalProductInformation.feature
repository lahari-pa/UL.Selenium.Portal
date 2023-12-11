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
@SummaryPage
@SHA
@UPC
@run_AdditionalProductInformation

Feature: Product Information

@TestCase:31352
Scenario: [31352] Product Information - navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase31352
And I should see the Product Information Page
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31352


@TestCase:31359
Scenario: [31359] Product Information - validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase31359
When I click continue
And Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) should be showing the error messages: This is a required field.
And Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31359


@TestCase:85242
Scenario: [85242] Product Information with marketed child question- navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase85242
And I should see the Product Information Page
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85242


@TestCase:85244
Scenario: [85244] Product Information with marketed child question- validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase85244
When I click continue
And Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) should be showing the error messages: This is a required field.
And Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) should be showing the error messages: This is a required field.
And Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85244


@TestCase:85367
Scenario: [85367] Which one best describes your product question- navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase85367
And I should see the Product Information Page
And I should see following statement: Which best describes your product, including when FIFRA 25(b) Exempt
And I should see the following radio buttons:
| Button                             |
| Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)          |
| Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth) |
| Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial) |
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85367

@ignore
#Removed from regression 2023/11
@TestCase:85368
Scenario: [85368] Which one best describes your product question- validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase85368
When I click continue
And Which best describes your product, including when FIFRA 25(b) Exempt should be showing the error messages: This is a required field.
And Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) should be showing the error messages: This is a required field.
And Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85368


@TestCase:85488
Scenario: [85488] Private Label and Goods Not for Resale question - navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase85488
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I should see following statement: Product is a Retailer's Private Label or Brand
And I should see following statement: Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85488



@TestCase:85489
Scenario: [85489] Private Label and Goods Not for Resale question - validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase85489
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
When I click continue
And Product is a Retailer's Private Label or Brand should be showing the error messages: This is a required field.
And Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85489


@TestCase:133161
Scenario: [133161] Fertilizer - P, N, or K question
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Given I should see the Product Information Page
	Given I set the Does the product contain fertilizer (N, P, K)? option to: No
	And I should not see following statement: Phosphates /Phosphorous (“P”)
	And I should not see following statement: Nitrogen /Nitrates (“N”)
	And I should not see following statement: Potassium(“K”)
	Given I set the Does the product contain fertilizer (N, P, K)? option to: Yes
	And I should see following statement: Phosphates /Phosphorous (“P”)
	And I should see following statement: Nitrogen /Nitrates (“N”)
	And I should see following statement: Potassium(“K”)
	Then I should see the PNK section title in the Product Information with the following text: Provide the amount (Percent) of each of the following within the product
	And I see the following sections
		| Section                       |
		| Phosphates /Phosphorous (“P”) |
		| Nitrogen /Nitrates (“N”)      |
		| Potassium(“K”)                |
	Then I set the Phosphates /Phosphorous (“P”) field to: 1000000
	Then I set the Nitrogen /Nitrates (“N”) field to: 10.1232123 
	Then I set the Potassium(“K”) field to: 100
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.
	And Phosphates /Phosphorous (“P”) should be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
	And Nitrogen /Nitrates (“N”) should be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
	And Potassium(“K”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
	Then I set the Phosphates /Phosphorous (“P”) field to: 35.24
	Then I set the Nitrogen /Nitrates (“N”) field to: .05
	And Phosphates /Phosphorous (“P”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
	And Nitrogen /Nitrates (“N”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
	And Potassium(“K”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place

# Created by Saikiran Chittampally
@TestCase:211384
Scenario: [211384] Product Information Screen - General Validation for N, P, K, and Slow Release Agent Questions
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Add Product icon in the Navigation Pane
	And the Product Editor page should be loaded
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Plant Food
	Then I save the product information as: TestCase211384
	Given I should see the Product Information Page
	Given I set the Does the product contain fertilizer (N, P, K) option to: Yes
	Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
	Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
	Given I set the Product is a Retailer's Private Label or Brand option to: No
	Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.	
	And I see the following sections
		| Section                       |
		| Phosphates /Phosphorous (“P”) |
		| Nitrogen /Nitrates (“N”)      |
		| Potassium(“K”)                |
		| Slow-Release Agent            |
	Then I set the Phosphates /Phosphorous (“P”) field to: 14
	Then I set the Nitrogen /Nitrates (“N”) field to: 8
	Then I set the Potassium(“K”) field to: 14
	Then I set the Slow-Release Agent field to: 3
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: The Product
	Then I set 'Type of Product' to: Soil Conditioner
	And I click continue
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: The Product
	Then I set 'Type of Product' to: Soil (No Additives, Fertilizers, or Inhibitors)
	And I click continue
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: The Product
	Then I set 'Type of Product' to: Fertilizer
	And I click continue
	And I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then I click continue
	Then I should see the Physical and Chemical Properties Page
	Then I click the My Products icon in the Navigation Pane
	Given I delete the product: TestCase211384

#Created by Saikiran Chittampally
@TestCase:217076
Scenario: [217076] Product Information Screen - Error Messages for NPK and Slow Release Agent
	Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	Then I click the Add Product icon in the Navigation Pane
	And the Product Editor page should be loaded
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I save the product information as: TestCase217076
	Given I should see the Product Information Page
	And I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Given I set the Does the product contain fertilizer (N, P, K) option to: Yes
	Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
	Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
	Given I set the Product is a Retailer's Private Label or Brand option to: No
	Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.	
	Then If a modal dialog opens I close it
	Then I should see an error message: You have indicated the product is a type that may contain, or is, a fertilizer. Be sure to provide percentages for Nitrogen, Phosphates, Potassium and Slow-Release Agent. If there is no Slow-Release Agent in the product, you must enter "0" as the percentage.
	And I see the following sections
		| Section                       |
		| Phosphates /Phosphorous (“P”) |
		| Nitrogen /Nitrates (“N”)      |
		| Potassium(“K”)                |
		| Slow-Release Agent            |
	Then I set the Phosphates /Phosphorous (“P”) field to: 20.85
	Then I set the Nitrogen /Nitrates (“N”) field to: 0
	Then I set the Potassium(“K”) field to: 100
	Then I set the Slow-Release Agent field to: 35.75
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.	
	Then I should see an error message: You have indicated the product contains a Slow Release Agent but no Nitrogen/Nitrates (N). Nitrogen/Nitrates (N) is required when Slow Release Agent is present.
	Then I set the Nitrogen /Nitrates (“N”) field to: 12.89
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.	
	Then I should see the Physical and Chemical Properties Page
	Then I click the My Products icon in the Navigation Pane
	Given I delete the product: TestCase217076

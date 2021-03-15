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

Feature: Additional Product Information

@ScenarioId:1162
Scenario: [31352] Additional Product Information - navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase31352
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |
And I should see the Additional Product Information Page
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31352


@ScenarioId:1163
Scenario: [31359] Additional Product Information - validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase31359
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |
When I click continue
And Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) should be showing the error messages: This is a required field.
And Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31359


@ScenarioId:1164
Scenario: [85242] Additional Product Information with marketed child question- navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase85242
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
And I should see the Additional Product Information Page
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85242


@ScenarioId:1165
Scenario: [85244] Additional Product Information with marketed child question- validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase85244
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
When I click continue
And Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) should be showing the error messages: This is a required field.
And Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) should be showing the error messages: This is a required field.
And Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85244


@ScenarioId:1166
Scenario: [85367] Which one best describes your product question- navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase85367
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
And I should see the Additional Product Information Page
And I should see following statement: Which best describes your product, including when FIFRA 25(b) Exempt
And I should see the following radio buttons:
| Button                             |
| Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)          |
| Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth |
| Product is not considered a pesticide product |
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85367


@ScenarioId:1167
Scenario: [85368] Which one best describes your product question- validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase85368
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
When I click continue
And Which best describes your product, including when FIFRA 25(b) Exempt should be showing the error messages: This is a required field.
And Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) should be showing the error messages: This is a required field.
And Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85368


@ScenarioId:1168
Scenario: [85488] Private Label and Goods Not for Resale question - navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase85488
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I should see following statement: Product is a Retailer's Private Label or Brand
And I should see following statement: Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85488



@ScenarioId:1169
Scenario: [85489] Private Label and Goods Not for Resale question - validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase85489
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 3                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
When I click continue
And Product is a Retailer's Private Label or Brand should be showing the error messages: This is a required field.
And Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85489


@ScenarioId:8231
Scenario: [133161] Fertilizer - P, N, or K question

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
| 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Appreciable                                  | 2                |
Given I should see the Additional Product Information Page
Given I set the Does the product contain fertilizer (N, P, K)? option to: No
And I should not see following statement: Phosphates /Phosphorous (“P”)
And I should not see following statement: Nitrogen /Nitrates (“N”)
And I should not see following statement: Potassium(“K”)
Given I set the Does the product contain fertilizer (N, P, K)? option to: Yes
And I should see following statement: Phosphates /Phosphorous (“P”)
And I should see following statement: Nitrogen /Nitrates (“N”)
And I should see following statement: Potassium(“K”)
Then I should see the PNK section title in the Additional Product Information with the following text: Provide the amount (Percent) of each of the following within the product
And I see the following sections
| Section                       |
| Phosphates /Phosphorous (“P”) |
| Nitrogen /Nitrates (“N”)      |
| Potassium(“K”)                |
Then I set the Phosphates /Phosphorous (“P”) field to: 1000000
Then I set the Nitrogen /Nitrates (“N”) field to: 10.1232123 
Then I set the Potassium(“K”) field to: 100
Then I click continue
And Phosphates /Phosphorous (“P”) should be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Nitrogen /Nitrates (“N”) should be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Potassium(“K”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
Then I set the Phosphates /Phosphorous (“P”) field to: 35.24
Then I set the Nitrogen /Nitrates (“N”) field to: .05
And Phosphates /Phosphorous (“P”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Nitrogen /Nitrates (“N”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Potassium(“K”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place



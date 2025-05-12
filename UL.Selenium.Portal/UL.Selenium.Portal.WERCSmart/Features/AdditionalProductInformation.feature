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
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@SideMenu

Feature: Product Information

@TestCase:31352
Scenario: [31352] Product Information - navigation
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Deodorant - Non-aerosol_#31352
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Deodorant - Non-aerosol
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase31352
	And I should see the Product Information Page
	Then In the Product Information Section, for question 'Retailers will be selling my product at their store locations' confirm the info icon 'i' is displayed
	Then In the Product Information Section, for question 'Retailers will be selling my product at their store locations' when hovering over the 'i' icon, the displayed text is: The selection of the region where your retailer will be selling your product impacts the data collected within the registration. United States and Canada have varying regulations with regard to VOC, Waste, as well as Safety Data Sheet requirements. Be sure to select the appropriate region for the retailers who will be receiving your product´s assessment/classification information.
	Then In the Product Information Section, confirm the question: 'Retailers will be selling my product at their store locations in (select either or both)' is displayed
	Then In the Product Information Section, confirm the question: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' is displayed
	Then In the Product Information Section, confirm the question: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' is displayed
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31352
	Then I navigate to the Home Page
	Then I delete the product: TestCase31352

#Removed from regression 03/19/25
@ignore
@TestCase:133161
Scenario: [133161] Product Information Screen - Fertilizer - N, P, or K question
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Fertilizer
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Fertilizer
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase133161
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the question: 'Which best describes your product, including when FIFRA 25(b) Exempt' is displayed
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth)
	Then In the Product Information Section, confirm the question: 'Does the product contain fertilizer (N, P, K)?' is displayed
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: No
	Then In the Product Information Section, confirm the question: 'Nitrogen /Nitrates (“N”)' is not displayed
	Then In the Product Information Section, confirm the question: 'Phosphates /Phosphorous (“P”)' is not displayed
	Then In the Product Information Section, confirm the question: 'Phosphates /Phosphorous (“P”)' is not displayed
	Then In the Product Information Section, confirm the question: 'Potassium(“K”)' is not displayed
	Then In the Product Information Section, confirm the question: 'Slow-Release Agent' is not displayed
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, the statement 'Provide the amount (Percent) of each of the following within the product.' is displayed
	Then In the Product Information Section, confirm the question: 'Nitrogen /Nitrates (“N”)' is displayed
	Then In the Product Information Section, confirm the question: 'Phosphates /Phosphorous (“P”)' is displayed
	Then In the Product Information Section, confirm the question: 'Phosphates /Phosphorous (“P”)' is displayed
	Then In the Product Information Section, confirm the question: 'Potassium(“K”)' is displayed
	Then In the Product Information Section, confirm the question: 'Slow-Release Agent' is displayed
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 10.121253
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 1000000
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 100
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 25
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then In the Product Information Section, the section: 'Nitrogen /Nitrates (“N”)' should be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, the section: 'Phosphates /Phosphorous (“P”)' should be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, the section: 'Potassium(“K”)' should not be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, the section: 'Slow-Release Agent' should not be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 0.05
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 35.24
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then In the Product Information Section, the section: 'Nitrogen /Nitrates (“N”)' should not be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, the section: 'Phosphates /Phosphorous (“P”)' should not be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, the section: 'Potassium(“K”)' should not be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then In the Product Information Section, the section: 'Slow-Release Agent' should not be showing error message: Invalid number. 3 total spaces maximum and 2 decimal places
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase133161

# Created by Saikiran Chittampally
@TestCase:211384
Scenario: [211384] Product Information Screen - General Validation for N, P, K, and Slow Release Agent Questions
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then In the Side Menu, click Labeled Link with Add Product title
	And the Product Editor page should be loaded
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Plant Food
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Plant Food
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Plant Food
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase211384
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 2
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 1
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 3
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 5
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: The Product
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Soil Conditioner (no VOC or Pesticide)
	Then in the The Product page, I click Continue
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: The Product
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Soil (No Additives, Fertilizers, or Inhibitors)
	Then in the The Product page, I click Continue
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: The Product
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Fertilizer
	Then in the The Product page, I click Continue
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase211384

#Created by Saikiran Chittampally
@TestCase:217076
Scenario: [217076] Product Information Screen - Error Messages for NPK and Slow Release Agent
	Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Fertilizer
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Fertilizer
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase217076
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'X' button
	Then In the Product Information Section, the section: 'Nitrogen /Nitrates (“N”)' should be showing error message: You have indicated the product is a type that may contain, or is, a fertilizer. Be sure to provide percentages for Nitrogen, Phosphates, Potassium and Slow-Release Agent. If there is no Slow-Release Agent in the product, you must enter "0" as the percentage.
	Then In the Product Information Section, the section: 'Phosphates /Phosphorous (“P”)' should be showing error message: You have indicated the product is a type that may contain, or is, a fertilizer. Be sure to provide percentages for Nitrogen, Phosphates, Potassium and Slow-Release Agent. If there is no Slow-Release Agent in the product, you must enter "0" as the percentage.
	Then In the Product Information Section, the section: 'Potassium(“K”)' should be showing error message: You have indicated the product is a type that may contain, or is, a fertilizer. Be sure to provide percentages for Nitrogen, Phosphates, Potassium and Slow-Release Agent. If there is no Slow-Release Agent in the product, you must enter "0" as the percentage.
	Then In the Product Information Section, the section: 'Slow-Release Agent' should be showing error message: You have indicated the product is a type that may contain, or is, a fertilizer. Be sure to provide percentages for Nitrogen, Phosphates, Potassium and Slow-Release Agent. If there is no Slow-Release Agent in the product, you must enter "0" as the percentage.
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 0
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 20.85
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 100
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 35.75
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then In the Product Information Section, the section: 'Nitrogen /Nitrates (“N”)' should be showing error message: You have indicated the product contains a Slow Release Agent but no Nitrogen/Nitrates (N). Nitrogen/Nitrates (N) is required when Slow Release Agent is present.
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 12.89
	Then In the Product Information Section, the section: 'Nitrogen /Nitrates (“N”)' should not be showing error message: You have indicated the product contains a Slow Release Agent but no Nitrogen/Nitrates (N). Nitrogen/Nitrates (N) is required when Slow Release Agent is present.
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	Then I click the My Products icon in the Navigation Pane
	Given I delete the product: TestCase217076


	
	# Created by Saikiran Chittampally
@TestCase:213920
Scenario: [213920] Product Information Screen - Warning Message >= 50% for NPK Product Types
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then In the Side Menu, click Labeled Link with Add Product title
	And the Product Editor page should be loaded
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Fertilizer
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Fertilizer
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase213920
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, the statement 'Provide the amount (Percent) of each of the following within the product.' is displayed
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 205.36
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 25
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 71.25
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 400.36
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'X' button
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: Product Information
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 0
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 0
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	Then I click the My Products icon in the Navigation Pane
	Given I delete the product: TestCase213920

	# Created by Saikiran Chittampally
@TestCase:213919
Scenario: [213919] Product Information Screen - Warning Message < 50% for NPK Product Types
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then In the Side Menu, click Labeled Link with Add Product title
	And the Product Editor page should be loaded
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Soil Conditioner (no VOC or Pesticide)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Soil Conditioner (no VOC or Pesticide)
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Soil Conditioner (no VOC or Pesticide)
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase213919
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: No
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should not be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.'
	Then I should see the Physical and Chemical Properties Page
	And I click the page heading: Product Information
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 10
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 25
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 36.36
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 0
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.'
	Then In the Product Information Section, in the Warning modal window click the 'Ok' button
	Then I should see the Physical and Chemical Properties Page
	Then I click the My Products icon in the Navigation Pane
	Given I delete the product: TestCase213919

@Shared
@LandingPage
@Login
@Homepage
@wercsmart
@NewProduct
@run_Cart
@SubEnrollment
@Cart
@PaymentMethods
@ProductGrid
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@SideMenu

Feature: Cart

#Background:
## THIS IS IN THE PRODUCTION BRANCH (MAYBE, HOPEFULLY)
#Given I go to the WERCSmart Log in
@mytag
@TestCase:66635
Scenario: [66635] Left hand navigation - Shopping Cart navigation - Products
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Shopping Cart icon in the Navigation Pane

@TestCase:63323
Scenario: [63323] Remove single product from cart
	Given I log in with the account saved in TReVor as: CartNoProducts
       Then The home screen should load
       #Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	   Then In the Side Menu, click Labeled Link with Add Product title
		Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
		Then in the New Product page, I click Continue

      # Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	  Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#63323
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	  Then I save the product information as: TestCase63323
	   #Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	   Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	   #Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	   Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue


	   Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
             | ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
             | Water         | 100     | false               | false       |            |
    #Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

       Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
       #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	   Given I should see the Regulatory Documents to Provide Page
	   Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	   Then in the Regulatory Documents to Provide page I click Continue

	   Given in the Additional Documents to Provide page I click Continue
       Given I click the Australia GHS SDS input section in Optional Reports and Documents Available for Purchase and select English (U.S)
       Given I click the Australia GHS SDS input section in Optional Reports and Documents Available for Purchase and select English (Australian)
       Given The total for section Australia GHS SDS in Optional Reports and Documents Available for Purchase should equal $400.00
       Given in the Optional Reports and Documents Available for Purchase page I click Continue
       Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
       Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
             | Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
             | Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
       #Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	   Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	   #Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	   Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	   Given In the Purchase Summary screen I click Remove for product saved as TestCase63323
	   Then I wait for a modal dialog to open
       Given in the modal dialog I click the "CANCEL" button
       Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed
       Given In the Purchase Summary screen I click Remove for product saved as TestCase63323
	   Then I wait for a modal dialog to open
       Given in the modal dialog I click the "REMOVE" button
       Then The home screen should load
       And I search for the product saved as: TestCase63323
       And I click Row Actions for the first product returned
       And I should see the following Actions options
             | Option    |
             | Submit    |
             | Edit      |
             | Delete    |
             | View UPCs |
       Given I click the Shopping Cart icon in the Navigation Pane
       Then I confirm that I see the following text in the modal window popup: There are no items in the shopping cart.
       Then If a modal dialog opens I close it
       #Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63323
	   Then In the Side Menu, click Labeled Link with My Products title
       Then In the Product Grid, delete the product saved as: TestCase63323

@ignore
@TestCase:74837
Scenario: [74837] Shopping Cart navigation with subscription without products
	Given I log in with the subscription without products account
	Then The home screen should load
	Given I click the Shopping Cart icon in the Navigation Pane
	Then I should see the empty shopping cart pop up
	And the Empty Cart pop up message reads: There are no items in the shopping cart.
	Given I close the Empty Cart pop up
	Then The home screen should load

@ignore
@TestCase:74919
Scenario: [74919] Shopping cart navigation with products in cart without subscription
	Given I log in with the without subscription without products account
	Then The home screen should load
	Given I click the Shopping Cart icon in the Navigation Pane
	Then the Subscription Enrollment page should load
	And I see the alert message with text: Subscription enrollment is required to submit your registration for assessment. Please enroll at this time. Once you purchase your subscription, the registration data will transfer for assessment. under Subscription Enrollment

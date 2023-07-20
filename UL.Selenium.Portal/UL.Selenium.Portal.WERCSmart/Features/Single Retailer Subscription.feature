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
@SHA
@PaymentMethods
@ForwardProductRegistration
@Homepage
@RetailPartners
@MyAccount
@MyMessages
@DeleteActiveProducts
@UPC
@SupplierAccounts
@SubEnrollmentNew
Feature: Single Retailer Subscription

@TestCase:200502

Scenario: [200502] Single Retailer - Supplier Manager - Search and Result Table Revisions

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I click on the Suppliers link on the top right of the screen
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I check next radio buttons:
| Radio Button   |
| Company        |
| User Name      |
| E-Mail         |
| Phone          |
| Invoice Number |
And I call Shared step In the Supplier Manager Popup - radio button 'Company',enter in search 'Company' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'User Name',enter in search 'User Name' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'E-Mail',enter in search 'E-Mail' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'Phone',enter in search '999-999-9999' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'Invoice Number',enter in search 'Invoice Number' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |


@TestCase:200434

Scenario: [200434] Single Retailer - Not Available for Forwarding

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: Product200434
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer |
| Amazon   |
Then I generate a random UPC number and save as: UPC200434
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC200434, container type: any and size: 20
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And in the Additional Documents to Provide page I click Continue
And in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And If purchase details are showing click confirm order
And In the Thank You screen I click Home
Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In the SHA manager grid I see the WPS ID I have saved as product: Product200434 and if status is Submitted, I change status to Assigned, then confirm status is Assigned
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: Product200434)
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: Product200434)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: Product200434)
And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: Product200434
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: Product200434)
And I call Shared Step 59066 (Go to SHA Manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: Product200434)
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: Product200434) for
| Retailer |
| Amazon   |
And I navigate to the landing page
Given I log in with the account saved in TReVor as: SingleRetailerAccount
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as Product200434 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should not see product: saved as Product200434

@TestCase:200449

Scenario: [200449] Single Retailer - Not Available for Forwarding

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: Product200449
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer |
| Amazon   |
Then I generate a random UPC number and save as: UPC200449
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC200449, container type: any and size: 20
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And in the Additional Documents to Provide page I click Continue
And in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And If purchase details are showing click confirm order
And In the Thank You screen I click Home
Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In the SHA manager grid I see the WPS ID I have saved as product: Product200449 and if status is Submitted, I change status to Assigned, then confirm status is Assigned
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: Product200449)
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: Product200449)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: Product200449)
And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: Product200449
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: Product200449)
And I call Shared Step 59066 (Go to SHA Manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: Product200449)
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: Product200449) for
| Retailer |
| Amazon   |
And I navigate to the landing page
Given I log in with the account saved in TReVor as: SingleRetailerAccount
And I search for the product saved as: Product200449
And I click Row Actions for the first product returned
And I should not see the following Actions options
| Option             |
| Archive Retailers  |

@TestCase:184385

Scenario: [184385] My Retail Partners:  Data Tier Consent - Products in Scope - Report Show Single Retailer Products

Given I log in with the account saved in TReVor as: DoubleSubscriptionAccount
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: Product184385SRS
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer   |
| Rite Aid   |
Then I generate a random UPC number and save as: UPC183646
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC183646, container type: any and size: 20
Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Then in the Additional Documents to Provide page I click Continue
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Then I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then If purchase details are showing click confirm order
Then In the Thank You screen I click Home
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: Product184385T
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I click the single retailer checkbox
Then I confirm if the Single Retailer Checkbox is not selected
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer   |
| Rite Aid   |
Then I generate a random UPC number and save as: UPC183646_1
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC183646_1, container type: any and size: 20
Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Then in the Additional Documents to Provide page I click Continue
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Then I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then If purchase details are showing click confirm order
Then In the Thank You screen I click Home
Then I click the Retail Partners icon in the Navigation Pane
Then I select the retailer: Rite Aid
Then I click the Products in Scope button and confirm that a file is produced called RA_Report_DataUsageTier_<Date>.xlsx and save as File184385
Then I verify sheet Table in downloaded file RA_Report_DataUsageTier_<Date>.xlsx saved as File184385 contains data:
| WPS ID           | Internal ID | Product Name | Formula ID | Retailer | Product Type | Included in Consent | Excluded from Consent | Single-Retail Subscription |
| Product184385SRS |             | Chalk        |            | Rite Aid | Chalk        |                     | EXCLUDED              | Enrolled / Exempt          |
| Product184385T   |             | Chalk        |            | Rite Aid | Chalk        | YES                 |                       |                            |
Then I click the Home icon in the Navigation Pane

# Created by Saikiran Chittampally
@TestCase:181949
Scenario: [181949] Single Retailer Checkbox and Hover message

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase181949
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should see the Retailer Page
Then I confirm if the single retailer checkbox is displayed on the retailer page
Then I confirm the message on retailers page : Single-Retailer subscription permits the registration to be part of an annual subscription that permits only one (1) active retailer + "No Retailer" to be associated to a product registration. The Single-Retailer registration is not permitted to have more than ten (10) active GTIN/UPCs associated. Single-Retailer subscription is a discounted annual rate. You may convert, at a future time, the registration to a Tiered Subscription (formula, enhanced, article) and your annual amount will be pro-rated.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase181949

	# Created by Saikiran Chittampally
@TestCase:182705
Scenario: [182705] Single Retailer Checkbox - Not Visible in Battery Flow 
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline Battery
Then I save the product information as: TestCase182705
Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water      | 100     | false               | false       |            |
Given I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
Then I should see the Retailer Page
Given I confirm the checkbox Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program is not present for stand alone batteries in Retailer page 
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase182705

# Created by Saikiran Chittampally
@TestCase:182824
Scenario: [182824] Single Retailer - UPC Screen and Retailer Screen Checks

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC182824
Given I generate a random UPC number and save as: UPC1828241
Given I generate a random UPC number and save as: UPC1828242
Given I generate a random UPC number and save as: UPC1828243
Given I generate a random UPC number and save as: UPC1828244
Given I generate a random UPC number and save as: UPC1828245
Given I generate a random UPC number and save as: UPC1828246
Given I generate a random UPC number and save as: UPC1828247
Given I generate a random UPC number and save as: UPC1828248
Given I generate a random UPC number and save as: UPC1828249
Given I generate a random UPC number and save as: UPC1828240
Then I save the product information as: TestCase182824
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer |
| Amazon   |
Then I should see the Universal Product Code (UPC) Page
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC182824, container type: Plastic Container and size: 4
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828241, container type: Plastic Container and size: 6
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828242, container type: Plastic Container and size: 7
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828243, container type: Plastic Container and size: 3
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828244, container type: Plastic Container and size: 4
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828245, container type: Plastic Container and size: 5
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828246, container type: Plastic Container and size: 6
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828247, container type: Plastic Container and size: 7
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828248, container type: Plastic Container and size: 8
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828249, container type: Plastic Container and size: 9
And I should not see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
		| Upload File  |
Given in the Universal Product Code (UPC) page I click Continue
And In the New Product page I click tab: Recipient and UPC Details
And I click the page heading: Retailer
Given I click the single retailer checkbox
Then I confirm if the Single Retailer Checkbox is not selected
And I click Save in The Product Page
And I should see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828240, container type: Plastic Container and size: 9
Then In the Universal Product Code (UPC) page I click Save
And In the New Product page I click tab: Recipient and UPC Details
And I click the page heading: Retailer
Given I confirm if the single retailer checkbox is disabled
And I click the page heading: Universal Product Code (UPC)
Given I delete UPC: saved as UPC1828240
Then In the Universal Product Code (UPC) page I click Save
And In the New Product page I click tab: Recipient and UPC Details
And I click the page heading: Retailer
Given I click the single retailer checkbox
Then I confirm if the Single Retailer Checkbox is selected
And I click Save in The Product Page
Then I should see the Universal Product Code (UPC) Page
And I should not see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
		| Upload File  |
Then In the Universal Product Code (UPC) page I click Save
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase182824


@TestCase:201584

Scenario: [201584] Single Retailer - Behaviors and Restrictions - Managing Product Counts

Given I log in with the account saved in TReVor as: DoubleSubscriptionAccount
Then I navigate to the MyAccount page
Then In the My Account screen I navigate to the Subscription Information page
Then In the Subscription Information screen I verify section Submitted is present with product types:
| Product types     |
| Articles          |
| Enhanced Articles |
| Formulated        |
| Single Retailer   |
Then I get the count of products in section Submitted and save as: ProductsCount
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer   |
| Rite Aid   |
Then I generate a random UPC number and save as: UPC183646
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC183646, container type: any and size: 20
Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Then in the Additional Documents to Provide page I click Continue
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Then I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then If purchase details are showing click confirm order
Then In the Thank You screen I click Home
Then I navigate to the MyAccount page
Then In the My Account screen I navigate to the Subscription Information page
Then I verify the products count encreased for type Single Retailer in section Submitted then was before saved as: ProductsCount

@TestCase:202464

Scenario: [202464] Single-Retailer Subscription: Subscription Header Revision

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I navigate to the MyAccount page
Then In MyAccount page I verify Subscription section exist with options:
| options         |
| Level           |
| Agent Support   |
| Formulated      |
| Enhanced        |
| Article         |
| Single-Retailer |
Then In MyAccount page I get Subscription detailes and save data as: MyAccountSubscription
Then In the My Account page I navigate to the Subscription Information page
Then I verify Subscription details on Subscription Information page match with saved as: MyAccountSubscription


@TestCase:202477

Scenario: [202477] Single Retailer Subscription - Subscription Information Screen

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I navigate to the MyAccount page
Then In the My Account page I navigate to the Subscription Information page
Then In the Subscription Information I see option Single Retailer under Submitted section
Then In the Subscription Information I see option Single Retailer under In Cart section
Then In the Subscription Information in Subscription History under Subscription Level Status I see option Single Retailer
Then I logout


@TestCase:202543

Scenario: [202543] Single Retailer Subscription - More Filters - Show Only Single Retailer Products Checkbox Filter

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I click More Filters in the products grid
Then I confirm More Filters section is expended
Then I click the Show Only Single Retailer Products checkbox in the 'My Products' grid
Then In Product Grid I confirm if the checkbox Show Only Single Retailer Products is selected
Then I confirm that only Single-Retailer products appear in the 'My Products' grid
Then I click the Clear button in the More Filters section
Then In Product Grid I confirm if the checkbox Show Only Single Retailer Products is not selected
Then I confirm that all products appear in the 'My Products' grid
Then I click More Filters in the products grid
Then I confirm More Filters section is not expended

@TestCase:202551

Scenario: [202551] Single Retailer Subscription - Product Transfer from Single to Tiered Subscription

Given I log in with the account saved in TReVor as: DoubleSubscriptionAccount
Then I click More Filters in the products grid
Then I click the Show Only Single Retailer Products checkbox in the 'My Products' grid
Then In Product Grid I confirm if the checkbox Show Only Single Retailer Products is selected
Then I confirm that only Single-Retailer products appear in the 'My Products' grid
Then I filter the products by: Assessment in Progress
Then I save the ProductID and Name of the first Product in the grid as: FirstProduct
Then I click Row Actions for product saved as: FirstProduct
Then I click on the Row Action: Transfer to Tiered Subscription
Then I confirm the pop up shows the heading: Transfer Single Retailer product to Tiered Subscription
Then I verify text in Transfer to Tiered Subscription popup contains Product ID saved as: FirstProduct
Then In the popup with the following title: Transfer Single Retailer product to Tiered Subscription I click the Cancel button
Then I filter the products by: Assessment in Progress
Then I search for the product saved as: FirstProduct
Then I confirm that only Single-Retailer products appear in the 'My Products' grid
Then I click Row Actions for product saved as: FirstProduct
Then I click on the Row Action: Transfer to Tiered Subscription
Then I confirm the pop up shows the heading: Transfer Single Retailer product to Tiered Subscription
Then I verify text in Transfer to Tiered Subscription popup contains Product ID saved as: FirstProduct
Then In the popup with the following title: Transfer Single Retailer product to Tiered Subscription I click the Transfer button
Then An alert is displayed with the message: Success! Product has been transferred to Tiered Subscription.
Then I accept the alert pop up
Then I filter the products by: All
Then I click the Show Only Single Retailer Products checkbox in the 'My Products' grid
Then In Product Grid I confirm if the checkbox Show Only Single Retailer Products is not selected
Then I search for the product saved as: FirstProduct
Then I confirm that the indicator Single Retailer RA is not showing under the Retailers column
Then I click Row Actions for product saved as: FirstProduct
And I should not see the following Actions options
| Option                           |
| Transfer to Tiered Subscription  |

@OnlyInIntegration
@TestCase:202359

Scenario: [202359] Single Retail Subscription - Subscription Screen Options Available and Not Available

Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
When I search with email in the supplier manager window: SingleRetailerAccount@kxxyxunf.mailosaur.net
Then In the Supplier Manager Popup I click on the first supplier returned
Then Select the 'Company Information' Tab in Supplier Manager
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn on toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I click on button: Save
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned on
Then I navigate to the landing page
Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I navigate to the MyAccount page
Then In the Subscription Information screen I click the Upgrade button
Then In the Subscription page I confirm the Single Retailer Subscription heading does exist
Then In the Subscription page I confirm the Formulated, Enhanced & Articles subheader does exist
Then In the Subscription page I confirm the Single Retailer Subscription column contains text: When registering a type of product (formulated, enhanced, or article, excluding batteries) that is designated to be sold by a single retailer, this option provides discounted pricing. WERCSmart Agency services are available at an additional cost.
Then In the Subscription page I confirm the Single Retailer radio icon does exist
Then In the Subscription page I confirm the Single Retailer column contains text: 'Create and Manage Product Data Submit registration to single retailer + No Retailer'
Then I click the Home icon in the Navigation Pane
Then I open the new tab in browser
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
When I search with email in the supplier manager window: SingleRetailerAccount@kxxyxunf.mailosaur.net
Then In the Supplier Manager Popup I click on the first supplier returned
Then Select the 'Company Information' Tab in Supplier Manager
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn off toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I click on button: Save
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned off
Then I click top menu item: My Wercs and submenu item: Log Out
Then I switch to the tab with title: WERCSmart Version 2.0
Then I navigate to the MyAccount page
Then In the Subscription Information screen I click the Upgrade button
Then In the Subscription page I confirm the Single Retailer Subscription heading does not exist
Then In the Subscription page I confirm the Formulated, Enhanced & Articles subheader does not exist
Then In the Subscription page I confirm the Single Retailer radio icon does not exist
Then I logout
Then I navigate to the landing page
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
When I search with email in the supplier manager window: SingleRetailerAccount@kxxyxunf.mailosaur.net
Then In the Supplier Manager Popup I click on the first supplier returned
Then Select the 'Company Information' Tab in Supplier Manager
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn on toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I click on button: Save
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned on

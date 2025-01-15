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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@ProductSetUp
@DataSummarySheet
@SHA
@run_ReleaseDay
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct

Feature: Release Day

@SHA
@ForwardProductRegistration

@ignore
@TestCase:99052
Scenario: [99052] UPC Validation of duplicate and Buffered zero duplicate not allowed
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I log in with the account saved in TReVor as: ProductAccount
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I click the Add Product icon in the Navigation Pane
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
Given in the New Product page I click Continue
# I In the shared step below select "Chalk" as you Product Type
# I Make a note of the WPS ID shown at the top of the screen
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase99052
#Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

#Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

#Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
# I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
Then I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer |
| CVS      |
| Amazon   |
# I For this test we need a UPC number that is 12 digits long, go to this site https://www.gs1.org/services/check-digit-calculator enter 11 digits and click CalculateUse the 12 digit code shown on the site in the steps below
Then I generate a random UPC number and save as: UPC99052
Then I generate a random UPC number and save as: UPC99052-2
# I Enter the "UPC Number" you generated in step 11
Then I click the 'Add' button
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC99052, container type: Cardboard, size: 10, Do not click continue
# I Click the "Add UPC" button again
Then I click the 'Add' button
# In the UPC Number field enter the same UPC as you used in step 13
Then I enter UPC Number: saved as UPC99052
# I Confirm a warning message is shown above the UPC table that reads:"You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please either remove the instances of duplicate UPC(s) from the necessary registration data."
And I confirm a warning message is shown above the UPC table that reads: You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please either remove the instances of duplicate UPC(s) from the necessary registration data.
# Confirm the UPC table area is shown in red highlight
Then I confirm the UPC table area is shown in red highlight
# I Confirm the Warning icon (little red triangle with a while !) is shown next to the Retailer ids for the first UPC you added
Then I confirm the UPC Duplicate Warning Icon is visible
# I Select any option from the "Container Type" drop down for the second UPC table entry
Then I Select a container type from the drop down list
# I Enter the "Size (Ounces)" for the second UPC table entry
Then I enter Size Value: 10
Then I click continue
# I Confirm that you are not able to pass the page with the errors shown
Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Then I confirm a warning message is shown above the UPC table that reads: You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please either remove the instances of duplicate UPC(s) from the necessary registration data.
Then I confirm the UPC table area is shown in red highlight
Then I confirm the UPC Duplicate Warning Icon is visible
# I Change the UPC number in the UPC record you are working with, by adding a zero to the front of the UPC numberThis makes the UPC a buffered zero UPC duplicate
Then I enter Zero Buffer UPC Number: saved as UPC99052
# I Confirm the UPC area is still shown with the red highlight
Then I confirm the UPC table area is shown in red highlight
Then I click continue
# I Confirm that you are not able to pass the page with the errors shown
Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Then I confirm a warning message is shown above the UPC table that reads: You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please either remove the instances of duplicate UPC(s) from the necessary registration data.
Then I confirm the UPC table area is shown in red highlight
Then I confirm the UPC Duplicate Warning Icon is visible
# I Change the UPC number in the UPC record you are working with, by adding another zero to the front of the UPC number (making the UPC number 14 digits in length)This makes the UPC a buffered zero UPC duplicate
Then I enter Zero Buffer Duplicate UPC Number: saved as UPC99052
Then I click continue
# I Confirm that you are not able to pass the page with the errors shown
Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Then I confirm a warning message is shown above the UPC table that reads: You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please either remove the instances of duplicate UPC(s) from the necessary registration data.
Then I confirm the UPC table area is shown in red highlight
Then I confirm the UPC Duplicate Warning Icon is visible
# I Change the UPC to a Unique UPC number - you can use https://www.upcdatabase.com for your UPC this time
Then I enter UPC Number: saved as UPC99052-2
Then I click continue
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

# I The "Additional Documents to Provide" step is shown
Then I should see the Additional Documents to Provide Page
And I click continue
# I Confirm the "Optional Reports and Documents Available for Purchase" step is shown- Click Continue
Then I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Case 99502
Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

# I Confirm the Data Acceptance step is shown with No errors
Then I should see the Data Acceptance Page

Then I check that there are no error messages present on the Data Acceptance Screen
#And I Confirm the following statement displays under 'Data Acceptance' - "In case of any problem with this product we will communicate to the following email address. Please update this email address if you want us to use a different email"
Then I confirm following statement displays under Data Acceptance: In case of any problem with this product we will communicate to the following email address. Please update this email address if you want us to use a different email
#Checking that the select option warning is visible
Then I check that the Select Option warning is visible

Then I confirm the email registered: ProductAccount is populated in the field under the Statement

Then In the Data Acceptance page I select Agreed

Then I check that the Select Option warning is not visible

Then I check that there are no error messages present on the Data Acceptance Screen

# https://trevor.global.ul.com/captures/chrome_tOijJ2hD6F.png Error Checking
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase99052

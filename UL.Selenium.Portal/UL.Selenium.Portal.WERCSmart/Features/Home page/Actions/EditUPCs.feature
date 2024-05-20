@Shared
@wercsmart
@run_ActionsEditUPCs
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@ReviewDocuments
@SHA
@SummaryPage
@UPC
@PaymentMethods
@ProductSetUp
@ViewUpcs
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients

Feature: EditUPCs

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto1  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

@tfs_design
@ignore
@TestCase:56220
Scenario: [56220] My Products grid Actions - Edit UPCs
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Sending to Retailers
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: UPC Update
	And UNDER DEVELOPMENT

#Remove from regression: 2023/04
@ignore
@TestCase:64528
Scenario: [64528] Edit UPCs - Click Link check status in SHA
	Given I create a product and take to completed using Test Case 75335 Using SHA Account: SHAQAAuto1 and save as: ProductSetup64528
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64528
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64528)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64528 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64528
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64528 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)

#Remove from regression: 2023/04
@ignore
@TestCase:64529
Scenario: [64529] Edit UPCs - Home - Actions links should show Process UPC Update and Remove UPC Update
	Given I create a product and take to completed using Test Case 75335 Using SHA Account: SHAQAAuto1 and save as: ProductSetup64529
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64529
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64529)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64529 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64529
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64529 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64529
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option             |
		| Discontinue        |
		| View               |
		| View UPCs          |
		| Process UPC Update |
		| Remove UPC Update  |
		| Monitor Progress   |

@TestCase:64530
Scenario: [64530] Process UPC Update
	Given I create a product and take to completed using Test Case 75335 Using SHA Account: SHAQAAuto1 and save as: ProductSetup64530
	Given I generate a random UPC number and save as: UPC64530
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	And I search for the product saved as: ProductSetup64530
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I search for the product saved as: ProductSetup64530
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Process UPC Update
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I call Shared Step 75307 (Edit UPC - Add UPC and all data - Click Save) for UPC Number saved as: "UPC64530", container type: "Plastic Container", size: "10"
	And I should see the Data Acceptance Page
	Then In the Data Acceptance page I select Agreed
	And In the Data Acceptance page I click on the Accept button
	And the Purchase Summary should load
	And I navigate to the home page
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64530 and its status is: Recertification
	And I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: ProductSetup64530
	And I confirm UPC number saved as: "UPC64530" is displayed in the SHA Manager Product UPC list
	And I close the window that opened

@TestCase:64531
Scenario: [64531] Remove UPC Update - Cancel
	Given I create a product and take to completed using Test Case 75335 Using SHA Account: SHAQAAuto1 and save as: ProductSetup64531
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64531
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64531)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64531 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64531
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64531 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64531
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Remove UPC Update
	And I confirm the Remove UPC Update popup displays the warning: Are you sure you want to restore the following Product ?
	And I confirm the Remove UPC Update popup displays the name and ID for product saved as: ProductSetup64531
	Given in the modal dialog I click cancel
	And I confirm the Remove UPC Update popup has closed
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option             |
		| Discontinue        |
		| View               |
		| View UPCs          |
		| Process UPC Update |
		| Remove UPC Update  |
		| Monitor Progress   |

@TestCase:64532
Scenario: [64532] Remove UPC Update - Remove
	Given I create a product and take to completed using Test Case 75335 Using SHA Account: SHAQAAuto1 and save as: ProductSetup64532
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64532
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64532)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64532 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64532
	#20/03/2019 CLF Changed recertification from 2.0 Specific UPC Update to 2.0 UPC Update
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64532 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64532
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Remove UPC Update
	And in the modal dialog I click the "REMOVE" button
	And I confirm the Remove UPC Update popup has closed
	#Andrew Fix - Adding in step for reopening actions menu before checking for the removal of options.
	And I click Row Actions for the first product returned
	And I should not see the following Actions options
		| Option             |
		| Process UPC Update |
		| Remove UPC Update  |
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64532)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64532 and its font is not red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64532
	And I confirm there is no product entry listed with Recertification Reason: 2.0 Specific UPC Update
	Given I Close the Product Recertification History pop up

@OnlyInIntegration
@TestCase:112568
Scenario: [112568] Edit - Product rejected from submitted in SHA - Message is displayed about Rejected Registrations and SDS Restrictions
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase75142)
	And I call Shared Step 83242 (SHA - Submitted or Assigned product - Reject Submission - any subject - Save for the product saved as: TestCase75142)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: New
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then I filter for the product saved as: TestCase75142
	And I edit the product saved as: TestCase75142
	Then I confirm the Rejected Registration popup displays the warning: Please be aware that rejected registrations will not permit any changes to the Safety Data Sheet (SDS) option. Upon rejection, if you want to change your Safety Data Sheet selection (i.e. Select Authoring instead of providing a Document, you will need to DELETE the rejected registration and create a new registration to submit, with your proper selection.
	Given in the modal dialog I click cancel
	Then I confirm the Rejected Registration popup has closed
	And I edit the product saved as: TestCase75142
	Then I confirm the Rejected Registration popup displays the warning: Please be aware that rejected registrations will not permit any changes to the Safety Data Sheet (SDS) option. Upon rejection, if you want to change your Safety Data Sheet selection (i.e. Select Authoring instead of providing a Document, you will need to DELETE the rejected registration and create a new registration to submit, with your proper selection.
	Given in the Rejected Registration modal dialog I click Continue
	And I should see the The Product Page

@OnlyInIntegration
@ignore
#Removed from regression 2023/11
@TestCase:120790
  Scenario:[120790] "U" for UPC Update for Submitted Status
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC120790
	Given I generate a random UPC number and save as: UPC120790B
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase120790
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC120790, container type: Plastic Container and size: 12
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
    Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC120790B, container type: Plastic Container and size: 12
	Then I click Save in The Product Page
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And If purchase details are showing click confirm order
	And I navigate to the home page
	And I wait for 30 seconds
	And I navigate to the home page
	Given I search for the product saved as: TestCase120790
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	And I delete UPC: saved as UPC120790
	Then In the list of UPCs I should not see UPC: saved as UPC120790
	Then In the Universal Product Code (UPC) page I click Save
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given I navigate to the home page
    And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
    Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120790)
    Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120790 and its status is: Submitted
	Then I confirm that there is a 'U' next to the following product saved as: TestCase120790

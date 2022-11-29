@Shared
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

@Portal_ULSC
@ULSC

@run_ULSC_productcreation

Feature: ULSC Product creation

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\ULSC - Product processing in Portal for use in test cases

@TReVorId:22179
Scenario: [88606] ULSC Automation user - Create (in Portal) a new simple product (Chalk) and submit thru to Completed status (NGHS only)
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 54595 - WERCSLink Dashboard > Services > My Products
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I In the shared step below select Chalk as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): (.*)
And I Make a note of the WPS ID shown at the top of the screen
And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
And I In the shared step below add Chlorine (CAS Number 7782-50-5) to your formulation, this will ensure we have data from WPS to push down to ULSC.
And I call Shared Step 29181 (Ingredients - add any chemical) with name: (.*)
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC88606, container type: (.*) and size: (.*)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I The Additional documents to provide step is shown
And I Click 'Continue'
And I The Optional Reports and Documents Available for Purchase step is shown
And I Click 'Continue'
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Requires Table |
| Parameters     |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: (.*)
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I Depending on your subscription you will either see the Purchase summary success message or you will see the Purchase summary with you product details shown.  If the product details are shown click Confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I In the shared step below filter for your product using the WPS ID you noted earlier
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm your product is shown in the "Submitted Status"
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: (.*))
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product is shown in the "Assigned Status" (WPS ID displays in Green Color)
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: (.*))
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: (.*))
And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: (.*)
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: (.*))
And I IN SHA Manager - use the step below to search for your product
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the product is shown in Accepted status Note: If the retailer you selected does not have a feed then the retailer will be shown in Completed status
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: (.*))

@wercsmart
@SHA
@NewProduct
@ProductGrid
@ProductSetUp
@PaymentMethods
@run_Recertification

Feature: Recertification - Process Recertification

@TReVorId:21864
Scenario: [42273] Recertification > Process recertification > Process 1 product
#Given I If you do not have the test product in your account mentioned in the Description then use these two test cases
#to create a product and get it to the correct status:1. Use test case 75335 to create a new product and process it thru to
#Completed Status2. Use Test case 75410 to get the same product from Completed to Recertification
#Given I save to context name: TestCase42273 and value: 1555525
Given I create a product with name: 42273 and take to completed using Test Case 75335 and save as: TestCase42273
Given I take a product from completed to recertification using Test Case 75410 saved: TestCase42273
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase42273)
And In SHA Manager I set the filter for status to : Recertification
And In SHA Manager I select the first product saved as: TestCase42273
And I Click the Process Recertification button
And I Confirm the Recertification pop up is shown
And I Uncheck the Auto Assign Regulatory Specialist to Product check box
And I Select Automated QASha from the drop down list for Select Regulatory Specialist
And In the Recertification popup I click Continue
And In the Recertification popup the Continue button will no longer be shown
And in the Recertification popup I wait for all processing to be completed
And in the Recertification popup I should see the following products as successfully assigned
| ProductID              |
| saved as TestCase42273 |
And In the Recertification popup I click Cancel
And I Confirm the Recertification pop up is closed
And In the SHA Manager Grid I run a search for product saved as: TestCase42273 and its status is: Assigned
#Automation can stop here.


@TReVorId:21863
Scenario: [51296] Product in Assigned status - add to recertification
Given I create a product with name: TestCase51296 and take to completed using Test Case 75651 and save as: TestCase51296
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase51296)
And I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase51296
#And I Confirm the Product now shows with all details apart from the Product ID shown in RED font
And In the SHA Manager Grid I run a search for product saved as: TestCase51296 and its status is: Assigned
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase51296 and its font is red indicating a recertification
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase51296
#And I Confirm the Product Recertification History pop up shows
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                  |
| saved as TestCase51296 | true   | 20. Completed Product-Full Update (N/C) |
And I Close the Product Recertification History pop up
Given I navigate to the landing page
And I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
#And I call Shared Step 67284 (Login into WERCSmart Portal - Visual Automation Account)
And I call Shared Step 51352 - Products page - Filter for your product - Update Required link for product saved as: TestCase51296
#And I If you are using a ULSC registered supplier you will see the Re-Import data from ULSC services page - Select No, continue editing data and click Save
#And I The Product Type step is shown
And In the New Product page I click tab: Review and Submit
And in the New Product page I click section: Safety Data Sheet Authoring - Additional Data (Optional)
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 5
And I click Save in The Product Page
#And in the New Product page I click Continue
And in the New Product page I click section: Data Acceptance
#And I Confirm no errors are shown
And In the Data Acceptance page I click on the Accept button
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
#And I Confirm your product is shown with an entry for "Recertification"
#And I Confirm you see the SDS fee in the cart (as recert reason 20 has an SDS fee associated to it)
Given If purchase details are showing click confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase51296)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase51296 and its status is: Recertification
#And I Confirm your product is shown in the Recertification status without the red recertification font color
#And I Change the status drop down from ALL to RECERTIFICATION
And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase51296
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase51296)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase51296 and its status is: Assigned
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase51296
#And I Confirm the Product Recertification History pop up shows
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                  | Date                  |
| saved as TestCase51296 | false  | 20. Completed Product-Full Update (N/C) | Within a day of today |
#And I Confirm the entry you noted in step 37 not shows False in the Active column and contains a date/time under the date column


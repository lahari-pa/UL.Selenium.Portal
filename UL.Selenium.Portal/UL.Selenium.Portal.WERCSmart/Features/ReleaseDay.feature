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

Feature: Release Day

@SHA
@ForwardProductRegistration
@75321


@singlerun
@ScenarioId:1160
@ScenarioId:1160
Scenario: [78414] Submit Product, Reject from Submitted in SHA, Resubmit from Portal.  SHA shows in Submitted status
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
And I call Shared Step 83242 (SHA - Submitted or Assigned product - Reject Submission - any subject - Save for the product saved as: TestCase75142)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: New
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then I filter for the product saved as: TestCase75142
And I edit the product saved as: TestCase75142
Given In the New Product page I click tab: Review and Submit
Then I click the page heading: Comments
And I should see the Comments Page
Then I click continue
And I should see the Data Acceptance Page
And In the Data Acceptance page I click on the Accept button
Given In the Thank You screen I confirm the following statement is shown: Thank you
Then In the Thank You screen I click Home
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: Submitted

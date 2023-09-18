@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@NewDistributor
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@Studio
@SHA
@UPC
@MyAccount
@PaymentMethods
@run_Distributor
@ProductSetUp

Feature: Distributor


#Feed setup needs to be done to create distributor request in all local environments
#In order to manually create a distributor use query - update t_product set F_STATUS = 8 where F_PRODUCT = ''

@tfs_design
#Removed from regression: 2023/05
@ignore
@TestCase:122365
Scenario: [122365] Create a distributor request and process it to completed
	Given I generate a random UPC number and save as: UPC86463
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
	Given I create a Chalk product and take to completed for distributor and save as: TestCase0001
	Given I save to context name: UPC86463 and value: 635039847816
	Given I save to context name: TestCase0001 and value: 1616035
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: DistributorAccount
	Then the WERCSmart homepage should load
	Given I create a distibutor request as TestCase0002 and send to manufacturer
	And I click the Register New Product icon in the Navigation Pane
	And I should see the header New Product
	And I set the radio option in section: Select the type of product to create: to: Request a UPC from a Manufacturer
	Given I click continue
	And I should see the Distributor Request - UPC Selection Page
	And I set the Enter Manufacturer's Contact Email option to: User_574c25cd650f.kxxyxunf@mailosaur.io
	And I set the Provide Manufacturer's Uniform Product Code (UPC) for the Product option to: UPC86463
	And I click outside of the login popup
	And I click outside Provide manufacturer UPC textbox
	Given I click continue
	And I save the product information as: TestCase0002
	And I click on I understand checkbox and then Send to Manufacturer
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
	Then the WERCSmart homepage should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Distributors tab in the My Library page
	Given I search for the product in My Distributor: TestCase0001
	And I click Approve for the most recent product returned in my dist
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: DistributorAccount
	Then the WERCSmart homepage should load
	And I search for the product saved as: TestCase0002
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit
	And I should see the Distributor Request - UPC Selection Page
	And I click Save in The Product Page
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I call Shared Step for dist - UPC - Add UPCName, Container type, Size and Package type (no retailer data needed) - Continue for UPC Name: test, container type: Metal Container and size: 5
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase0002)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase0002 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase0002)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase0002)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase0002 and its status is: Accepted or Completed

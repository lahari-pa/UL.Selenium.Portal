@Shared
@wercsmart
@run_Alerts
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
@PaymentMethods
@ProductSetUp
@CreateProducts

Feature: Alerts

#Design => Ready
@tfs_design
@TestCase:56280
Scenario: [56280] - Document is created and is ready for review
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I log in with the account saved in TReVor as: ProductAccount
Then I should see the button: Resolve for alert: AGHS document is created and is ready for review
Then I should see the button: Details for alert: AGHS document is created and is ready for review
Given I click the 'Resolve' button that is associated to the AGHS alert in the 'Alerts' window
Then I confirm that the Document Acceptance page is showing
Then I navigate to the home page

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
@Studio
@run_Suspended

Feature: Suspended (Suite ID: 69545)

@SHA
Scenario: [69547] Suspend a Product - Formula - Other
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Formula – Other
And In the Suspended dialog in the Supplier Message field I should see: The issue with the composition data is: _________
And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
And In the Suspended dialog in the Internal Product Note field I should see: The issue with the composition data is: _________
And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
And In the Suspended dialog I click Save
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
And In the SHA manager grid I right click against product saved as: ID
And In the SHA manager grid when the right click context menu is open I select option: Notification History
Then In the Notification History Screen I confirm that one of the rows is as follows:
| Type      | Notification Date | Subject         |
| Suspended | Today             | Formula – Other |
And In the Notification History Screen I click on the most recent notification
And In the Notification History Detail Screen I confirm that details are as follows
| Subject         | Message                | Notification Date |
| Formula – Other | supplier message input | Today             |

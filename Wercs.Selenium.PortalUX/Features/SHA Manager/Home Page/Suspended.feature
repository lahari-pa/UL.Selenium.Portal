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
@run_Suspended

Feature: Suspended

Scenario: [69547] Suspend a Product - Formula - Other
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I Select the checkbox of a product
And I Select Suspended (in bottom menu)
And I Select the All checkbox
And I From the Select Regulatory Specialist drop down chooseyour name
And I From the Select Subject drop down choose Formula - Other
And I Confirm that you see The issue with the composition data is: ____________ in the Supplier Message
And I Add text to the Supplier Message input field
And I Add different text to the Internal Product Note input field
And I Click Save
And I Right Click on the product you selected
And I ChooseNotification History
And I Confirm that under the Type column you see Suspended
And I Confirm that under Notification Date you see today's date
And I Confirm that under Subject, you see Formula - Other
And I Select the notification
And I Confirm that in the Message area you see: The issue with composition data is: and the extra text you added.
And I Close the Notification History for Product # popup by clicking the Close button

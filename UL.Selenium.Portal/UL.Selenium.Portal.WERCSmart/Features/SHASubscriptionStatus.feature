@Shared
@SHA
@run_SHASubscriptionStatus
Feature: SHASubscriptionStatus

@TestCase:142233
Scenario: [142233] Subscription Status - Cancelled
	Given I Save the email for the TReVor: CancelledSubscriptionAccount Test user as: CancelledSubscriptionAccountEmail
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click on the Suppliers link on the top right of the screen
	Given In the Supplier Manager Popup I enter the following search term: saved as CancelledSubscriptionAccountEmail
	Given In the Supplier Manager Popup I select radio button: E-Mail
	Given In the Supplier Manager Popup I click on the search button
	Given In the Supplier Manager Popup I click on the first supplier returned
	Given I ensure that there is a SubscriptionStatus column in the Supplier Manager popup
	Given I ensure that I see the status Cancelled under the SubscriptionStatus column
	Given I ensure that the Subscription tab has red font

@TestCase:142277
Scenario: [142277] Subscription Status - Not Subscribed
	Given I Save the email for the TReVor: VisualAccount Test user as: VisualAccountEmail
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click on the Suppliers link on the top right of the screen
	Given In the Supplier Manager Popup I enter the following search term: saved as VisualAccountEmail
	Given In the Supplier Manager Popup I select radio button: E-Mail
	Given In the Supplier Manager Popup I click on the search button
	Given In the Supplier Manager Popup I click on the first supplier returned
	Given I ensure that there is a SubscriptionStatus column in the Supplier Manager popup
	Given I ensure that I see the status Not Subscribed under the SubscriptionStatus column
	Given I ensure that the Subscription tab has yellow font

@TestCase:142278
Scenario: [142278] Subscription Status - Past Due
	Given I Save the email for the TReVor: PastDueSubscriptionAccount Test user as: PastDueSubscriptionAccountEmail
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click on the Suppliers link on the top right of the screen
	Given In the Supplier Manager Popup I enter the following search term: saved as PastDueSubscriptionAccountEmail
	Given In the Supplier Manager Popup I select radio button: E-Mail
	Given In the Supplier Manager Popup I click on the search button
	Given In the Supplier Manager Popup I click on the first supplier returned
	Given I ensure that there is a SubscriptionStatus column in the Supplier Manager popup
	Given I ensure that I see the status Past Due under the SubscriptionStatus column
	Given I ensure that the Subscription tab has yellow background color
	Given I ensure that the Subscription tab has black font

@TestCase:142282
Scenario: [142282] Subscription Status - 3rd Party
	Given I Save the email for the TReVor: 3rdPartySubscriptionAccount Test user as: 3rdPartySubscriptionAccountEmail
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click on the Suppliers link on the top right of the screen
	Given In the Supplier Manager Popup I enter the following search term: saved as 3rdPartySubscriptionAccountEmail
	Given In the Supplier Manager Popup I select radio button: E-Mail
	Given In the Supplier Manager Popup I click on the search button
	Given In the Supplier Manager Popup I click on the first supplier returned
	Given I ensure that there is a SubscriptionStatus column in the Supplier Manager popup
	Given I ensure that I see the status 3rdParty under the SubscriptionStatus column
	Given I ensure that the Subscription tab has blue font

@TestCase:142283
Scenario: [142283] Subscription Status - Active
	Given I Save the email for the TReVor: ProductAccount Test user as: ProductAccountEmail
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click on the Suppliers link on the top right of the screen
	Given In the Supplier Manager Popup I enter the following search term: saved as ProductAccountEmail
	Given In the Supplier Manager Popup I select radio button: E-Mail
	Given In the Supplier Manager Popup I click on the search button
	Given In the Supplier Manager Popup I click on the first supplier returned
	Given I ensure that there is a SubscriptionStatus column in the Supplier Manager popup
	Given I ensure that I see the status Active under the SubscriptionStatus column
	Given I ensure that the Subscription tab has black font

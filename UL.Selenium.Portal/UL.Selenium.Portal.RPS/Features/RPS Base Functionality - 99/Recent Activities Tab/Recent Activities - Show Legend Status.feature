@RPS
@Login
@run_RecentActivites_ShowLegendStatus
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@RecentActivities
@RPSSHA

Feature: Recent Activities - Show Legend Status

@ScenarioId:9374
Scenario: [70328] Base Functionality - Recent Activities - Show Legend Status
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, I click the Legend Status Button
And In the recent activities Page, The Status Column Key Popup is showing
Then In the recent activities Page, In the Status Column Key popup I Confirm the header text reads: Status Column Key
And In the recent activities Page, In the Status Column Key popup I Confirm the 'x' Close icon is shown
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Accepted has description text: Analysis complete; data queued to feed to retailer
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Assigned has description text: Registration is with a Reviewer
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Cancelled has description text: Lack of response from supplier to a hold on registration (>30 days)
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Completed has description text: Analysis released to retailer; registration finalized
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Hold has description text: Issue with the information submitted; awaiting supplier action
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: New has description text: Registration process initiated; registration remains un-submitted
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Recertification has description text: Supplier action required; registration requires updated information
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Release for Distribution has description text: Analysis complete; data queued to feed to retailer (2nd step)
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: Submitted has description text: Registration has been paid for; processing initiated
Then In the recent activities Page, In the Status Column Key popup I Confirm the section: UPC Update has description text: Registration has had a UPC added or is sending an existing a UPC to a new retailer and is under minor review
Then In the recent activities Page, In the Status Column Key popup footer I click Close
And In the recent activities Page, The Status Column Key popup is not showing
Then I confirm the Recent Activities tab has loaded
Then I Check that the current page title is 'Recent Activities'
Then I Check that the Recent Activities Products Table is showing
And I call Shared Step 106194 (RPS Sign out)


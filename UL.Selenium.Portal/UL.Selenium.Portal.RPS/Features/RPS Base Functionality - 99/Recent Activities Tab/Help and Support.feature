@RPS
@Login
@run_HelpAndSupport
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@HelpAndSupport


Feature: Help and Support

@ScenarioId:9751
Scenario: [107996] Base Functionality - Help & Support - layout - needs parameter updates
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
#Then I confirm the Home tab has loaded
Given I click the main tab: Help & Support
Then I Confirm the Help & Support Popup is displayed
Then In the Help & Support pop up, I confirm the heading shows: Help & Support
Then I Confirm the Help & Support Popup contains the text 'Search Articles' in the header
Then I Confirm the Help & Support Popup contains the Search Icon in the header
#^Add location check to manual step
Then I Confirm the Help & Support Popup contains the Customer Contact Input Field
#^Add location check to manual step (below header)
Then I Confirm the Help & Support Popup contains the Subject Input Field
#^Add location check to manual step (below header)
Then I Confirm the Help & Support Popup contains the Text Decription Field
#^Add location check to manual step (below header)
Then I Confirm the Help & Support Popup can be scrolled to the bottom
#^Manual check that can see a scroll bar on right.
Then I Confirm the Help & Support Popup contains the Priority Input Field
#^Add location check to manual step (below header)
Then I Confirm the Help & Support Popup contains the currently selected Priority option of: Low
Then I Confirm in the Help & Support Popup, the Priority Drop down displays the following options:
| Options |
| Low     |
| Medium  |
| High    |
| Urgent  |
#^Manual check that can see a scroll bar on right.
Then I Confirm the Help & Support Popup contains the I am a dropdown Field
Then I Confirm the Help & Support Popup contains the a captcha with text 'I'm not a robot'
Then I Confirm the Help & Support Popup footer contains a Submit Button
Then I Confirm the Help & Support Popup Contains an X Icon
Then In The Help & Support Popup I perform 107996 MANUAL LAYOUT CHECKS using screenshots
And I call Shared Step 108016 (Help & Support pop up - X to close)

Examples:
	| Scenario Name                                                                           | Retailer |
    | [#107996a] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.LW   |
	| [#107996b] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.CV   |
#   | [#107996c] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.HD   |
	| [#107996d] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.SF   |
#	| [#107996e] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.TG   |
#   | [#107996f] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.PX   |
	| [#107996g] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.WM   |
	| [#107996h] Base Functionality - Help & Support - layout - needs parameter updates       | RPS.CT   |
	



@ScenarioId:9790
Scenario: [108014] Base Functionality - Help & Support - Search Articles panel layout
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Help & Support
Then I Confirm the Help & Support Popup is displayed
And In the Help & Support Popup I Click the search articles link
And In the Help & Support Popup I Check that the side panel is open
Then In The Help & Support Popup I perform 108014 MANUAL LAYOUT CHECKS using screenshots
Then In the Help & Support Popup I confirm that the the side panel input box contains placeholder text: Search
#^Add location check to manual step (Top of popup)
Then In the Help & Support Popup I confirm that the the side panel Main body contains text: Search our Knowledge base
#^Add location check to manual step (Below the search field)
Then In the Help & Support Popup I confirm that the the side panel Main body link contains text: or Browse articles
#^Add location check to manual step (Below Search our Knowledge base)
Then MANUAL STEP - In the Help & Support Popup I confirm that the the side panel Main body link is a link
#^Contains Manual Check of Screenshot for link underline
Then In the Help & Support Popup I Click the or Browse articles link
Then I switch to the window with the title: Solutions : UL WERCSmart
Then I Close the browser tab with the title: Solutions : UL WERCSmart
Then In the Help & Support Popup The Close Search button is present
And In the Help & Support Popup I Click the close search button
Then I Confirm the Help & Support Popup is displayed
And I call Shared Step 108016 (Help & Support pop up - X to close)

@ScenarioId:10039
Scenario: [108015] Base Functionality - Help & Support - required data
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Help & Support
Then I Confirm the Help & Support Popup is displayed
Then In the Help & Support Popup I Click the Submit button
Then In the Help & Support Popup I confirm there is an error displaying below the customer contact field that reads: Please enter a valid email address.
Then In the Help & Support Popup I confirm there is an error displaying below the Subject field: This field is required.
Then In The Help & Support Popup I perform 108015 MANUAL LAYOUT CHECKS using screenshots
And I call Shared Step 108016 (Help & Support pop up - X to close)
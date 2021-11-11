@RPS
@Login
@run_LandingPage
@TopBar
@LandingPage
@Home

Feature: Landing Page

@ScenarioId:9730
Scenario: [70245] UL Logo
Given I click the UL Logo in the upper right of the page
And I verify that a tab opens with url: https://msc.ul.com/en/
Then I close the tab with url: https://msc.ul.com/en/
Then I click the UL Logo in the bottom of the page
And I verify that no tab opens

# Assigned to Abbie Zullo
# Created by Abbie Zullo

@ScenarioId:6439
Scenario: [70246] Request More Information
Given I verify that the Request more information link for section: UL Audit has a subject line containing: I would like to learn more about UL Audit
And I verify that the Request more information link for section: UL PurView has a subject line containing: I would like to learn more about UL Purview
And I verify that the Request more information link for section: Item Scan has a subject line containing: I would like to learn more about UL Item Scan

# Assigned to Abbie Zullo
# Created by Abbie Zullo

@ScenarioId:9729
Scenario: [70243] Landing Page
Given I verify that WERCSmart Product Suite logo is showing
Then I verify that there is a Sign In Link in the upper-right corner
And I verify that there is a UL Logo in the upper-right corner
And I verify that there is a section titled Good business with I'd like to learn more button
And I verify that there is a section titled Instant Access displaying a graph
And I verify that under offerings there is a section for UL Audit with 'request more information' button
And I verify that under offerings there is a section for UL PurView with 'request more information' button
And I verify that under offerings there is a section for Item Scan with 'request more information' button
And I verify that there is a section titled Let's talk with I'd like to learn more button
And I verify that the following items are displayed in the Landing Page Footer:
| Item                    |
| UL Logo                 |
| About UL WERCSmart Link |
| Contact Us Link         |
| Sign In button          |

# Assigned to Abbie Zullo
# Created by Abbie Zullo

@ScenarioId:6436
Scenario: [70244] I'd Like to Learn More
And I click on the "I'd like to learn more" button in the Good business section
And I verify that a tab opens with url: https://msc.ul.com/en/
Then I close the tab with url: https://msc.ul.com/en/
And I verify that the I'd like to learn more link for section: Let's talk has a subject line containing: Retail Product Suite
# I confirm that email address shown in the "To..." address is: ul.psiinfo@ul.com

# Assigned to Abbie Zullo
# Created by Abbie Zullo

@ScenarioId:9731
Scenario: [70247] Footer
And I verify that the following items are displayed in the Landing Page Footer:
| Item                    |
| UL Logo                 |
| About UL WERCSmart Link |
| Contact Us Link         |
| Sign In button          |
And I click the footer link: About UL WERCSmart
And I verify that a tab opens with url: https://ulwercsmart.com/
Then I close the tab with url: https://ulwercsmart.com/
And I verify that the Contact Us button in the footer is a valid email link

@ScenarioId:6437
Scenario: [73218] Sign In / Sign Out
Given I save TReVor test user: RPS.99 to Context as the active user
Given I confirm the Landing Page has loaded
Given I click 'Sign In'
Given I confirm the 'Welcome' login popup is displayed
Given I click 'Log in'
Then I confirm the required field error is displayed for both User Name and Password
Given I enter incorrect credentials for User name and Password fields
Given I click 'Log in'
Then I confirm the error is displayed indicating Account does not exist or password is incorrect
Given I enter the User Name for the active user
And I enter an incorrect Password
Given I click 'Log in'
Then I confirm the error is displayed indicating Account does not exist or password is incorrect
Given I enter the Password for the active user
Given I click 'Log in'
Then I confirm the Home tab has loaded
Given I confirm the user displayed in the top bar matches the active logged in user
And I click the user button in the top bar
And I click 'Sign Out' under the user button
Then I confirm the Landing Page has loaded

@ScenarioId:6438
Scenario: [106340] Sign In - Welcome pop up Layout and Close button
Given I confirm the Landing Page has loaded
Given I click 'Sign In'
Given I confirm the 'Welcome' login popup is displayed
Given I confirm the 'User Name' and 'Password' fields are displayed
Given I confirm the 'Close' and 'Log In' buttons are displayed
And I click the Close button
Then I confirm the Landing Page has loaded

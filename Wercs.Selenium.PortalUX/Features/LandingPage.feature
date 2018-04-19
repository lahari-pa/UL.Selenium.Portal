@LandingPage
@Signup
@wercsmart
@Homepage
@run_LandingPage

Feature: Landing Page
@singlerun
Scenario: [50769] Navigation
#Given I navigate to the URL: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/
Then I should see the following menu options in the header:
| Option        |
| Manufacturers |
| Retailers     |
| Subscription  |
Given I select the Manufacturers link
Then I confirm I am taken to the Manufacturers page
Given I select the Retailers link
Then I confirm I am taken to the Retailers page
Given I select the Subscription link
Then I confirm I am taken to the Subscription page

Scenario: [50770] Sign Up Link
Given I select the Sign Up link
Then the signup page should appear
And I click the back button in the browser
And the landing page should load

Scenario: [59830] TimeOut Feature
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Given I stay on the homepage with no activity until the inactivity popup appears
# are you still active message appears
Then Click Yes on the inactivity popup
# popup goes away
And the WERCSmart homepage should load
Given I stay on the homepage with no activity until the inactivity popup appears
# are you still active message appears
Then Click No on the inactivity popup
# You are logged out of the site
And the landing page should load


@LandingPage
@Signup
@wercsmart
@Homepage
@run_LandingPage
Feature: Landing Page

#does not work in staging as of 09-17-2018
#added comment
@ScenarioId:456
Scenario: [50769] Navigation
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

@singlerun
@ScenarioId:457
Scenario: [50770] Sign Up Link
	Given I select the Sign Up link
	Then the signup page should appear
	And I click the back button in the browser
	And the landing page should load

@ScenarioId:460
Scenario: [59830] TimeOut Feature
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
	Then Click Yes on the inactivity popup
Then I confirm the Inactivity pop is closed
	And the WERCSmart homepage should load
Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
	Then Click No on the inactivity popup
	And the landing page should load

#verify the wait time is 15 min for each click on popup (yes/no)
@tfsdesign
@ScenarioId:458
Scenario: [50772] Get Started Now Button
	Given I click the Get Started Now link
	Then the login page should appear

#does not work in staging as of 09-17-2018
@tfsdesign
@ScenarioId:459
Scenario: [50775] Terms of Use
	Given I click the Terms of Use link in the Landing Page footer
	Then I confirm the WERCSmart Terms of Use page has loaded

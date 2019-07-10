@LandingPage
@Signup
@wercsmart
@Homepage
@run_LandingPage
Feature: Landing Page

#does not work in staging as of 09-17-2018
#added comment
@TReVorId:6874
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
@TReVorId:21932
Scenario: [50770] Sign Up Link
	Given I select the Sign Up link
	Then the signup page should appear
	And I click the back button in the browser
	And the landing page should load

@TReVorId:7799
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

#verify the wait time is 15 min for each click on popup (yes/no)
@tfsdesign
@TReVorId:18980
Scenario: [50772] Get Started Now Button
	Given I click the Get Started Now link
	Then the login page should appear

#does not work in staging as of 09-17-2018
@tfsdesign
@TReVorId:18981
Scenario: [50775] Terms of Use
	Given I click the Terms of Use link in the Landing Page footer
	Then I confirm the WERCSmart Terms of Use page has loaded

@Shared
@LandingPage
@Signup
@wercsmart
@Homepage
@run_LandingPage
Feature: Landing Page

#does not work in staging as of 09-17-2018
#added comment

@TestCase:59830
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

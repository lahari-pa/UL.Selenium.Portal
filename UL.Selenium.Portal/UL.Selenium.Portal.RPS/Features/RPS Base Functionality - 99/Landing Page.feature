@RPS
@Login
@run_LandingPage
@TopBar
@LandingPage
@Shared
@Home

Feature: Landing Page

@ScenarioId:11264
Scenario: [169067] Logged in page banner - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	Given I click the UL Logo in the header area
	And I verify that a tab opens with url: https://www.ul.com/
	Then I close the tab with url: https://www.ul.com/
	Given I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169650] Closing browser logs user out
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	Then I close the tab with url: https://int-rps.wercsmart.com/
	Given I navigate to the URL: https://int-rps.wercsmart.com/
	Given I confirm user is not logged in

@ScenarioId:9730
Scenario: [70245] UL Logo
	Given I click the UL Logo in the header area
	And I verify that a tab opens with url: https://www.ul.com/
	Then I close the tab with url: https://www.ul.com/
	Given I click the UL Logo in the footer area
	And I verify that no tab opens

# Removed from regression: 2024/08
@ignore
@ScenarioId:6438
Scenario: [106340] Sign In - Welcome pop up Layout and Close button
	Given I confirm the Landing Page has loaded
	Given I click 'Sign In'
	Given I confirm the 'Welcome' login popup is displayed
	Given I confirm the 'User Name' and 'Password' fields are displayed
	Given I confirm the 'Close' and 'Log In' buttons are displayed
	And I click the Close button
	Then I confirm the Landing Page has loaded

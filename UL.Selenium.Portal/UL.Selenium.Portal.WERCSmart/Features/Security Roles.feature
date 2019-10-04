@Shared
@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@run_SecurityRoles
Feature: Security Roles

@ScenarioId:806
Scenario: [52978] Log Into Account
	#Given I go to the WERCSmart Log in
	Given I login as the administrator
	Then I should see username: WERCS Test_Automation_ProductsAccount in the right corner
	Given I navigate to the MyAccount page
	Given I save all the users in the User Grid
	Then In Your Company User Accounts the user WERCS Test_Automation_ProductsAccount is associated with the administrator email address
	Given I click the User Icon
	And I click on Sign Out

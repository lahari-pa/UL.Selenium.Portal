@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@SHA
@wercsmart
@RetailPartners
@CreateProducts
@Studio
@ProductSetUp
@run_SHAAccountDebug
@UPC


Feature: SHAAccountDebug

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto7  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto9  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto11 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto12 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto13 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

		


		
		


		
		


@ScenarioId:11198
Scenario: [999999] Basic Test For Running Feature Outline

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

Then the WERCSmart homepage should load

Given I expand the Navigation Menu

Then the Navigation Menu should be expanded

Given I collapse the Navigation Menu

Then the Navigation Menu should be collapsed

And there should be products available in the Products Grid

Given I search for the first product in the table

Then I should see the product returned in the search results


@ScenarioId:11189
Scenario: [888888] SHA Acc Test Debug

Given I Create SHA processing Rules for the accounts listed in the table:
| username   |
| SHAQAAuto1 |


Scenario:  [755435] Account Lockout and Account Issue Testing
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)


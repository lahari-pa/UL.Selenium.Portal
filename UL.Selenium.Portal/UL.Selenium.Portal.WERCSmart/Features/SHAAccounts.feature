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
@run_AccHasFullStwdData
@UPC


Feature: AccHasFullStwdData

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto1  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto2  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto3  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto4  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto5  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto6  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto7  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto8  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto9  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto10 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto11 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto12 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto13 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto14 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto15 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto16 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto17 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto18 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto19 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto20 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto21 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto22 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto23 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto24 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto25 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto26 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto27 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto28 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto29 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto30 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		| SHAQAAuto31 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |
		



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

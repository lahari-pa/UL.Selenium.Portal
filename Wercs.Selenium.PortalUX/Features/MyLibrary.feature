@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@run_MyLibrary

Feature: MyLibrary

Scenario: [64884] My Library

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

Given I click on My Account

Given In the My Account screen I navigate to the My Library page

Then I should see the following tabs in the My Library page
| Tab                |
| My Packaging Types |
| My Brands          |
| My Distributors    |
| My Ingredients     |


@Homepage
@Login
@MyAccount
@wercsmart

@run_MyAccount

Feature: MyAccount

Background:

Scenario: [61796] Account User Name in Header
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then I should see username for user saved as: SignupUser in the right corner
Given I click on My Account
And I should see the heading: My Account on the My Account page
Given I save all the users in the User Grid
Given I go to Details in User Grid for the current user
Given In the UserDetails screen I save the current User as: ThisUser
Given In the UserDetails page I set Name to be: Richard Smith
Given In the UserDetails page I click Save
#Given I click Save in My Account
Then In the User Grid the user saved as: ThisUser has been replaced by: Richard Smith
Then I should see user name: Richard Smith in the header next to the user icon
Given I click on My Account
Given I go to Details in User Grid for the current user
Given In the UserDetails page I set Name to be: saved as ThisUser

Scenario: [63514] Create a New User on the User Grid
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Given I click on My Account
Then I create a new email address
Then I add a new user with the following information
| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
Then I confirm the new user is Active

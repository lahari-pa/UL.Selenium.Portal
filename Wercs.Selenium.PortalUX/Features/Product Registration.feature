@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@wercsmart
@run_ProductRegistration

Feature: Product Registration

Background:
Given I login into the WERCSmart Portal - Administrator Role

Scenario: [31343] New Product screen navigation
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I should see the following radio buttons:
| Button                             |
| Create a New Registration          |
| Copy from an Existing Registration |
| Request a UPC from a Manufacturer  |

#Old version of this test. Changed 6/2/2018
#| Yes, create a new product    |
#| No, copy an existing product |
#| No, copy from ULSC service   |

Scenario: [31344] New Product Screen validation
Given I click the Register New Product icon in the Navigation Pane
When I click continue
Then I should see an error message: This is a required field.

Scenario: Create a new product
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
Given I click the Register New Product icon in the Navigation Pane
When I click continue



@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@SubEnrollment
@run_Flow31_Seasonings

Feature: [64739] Flow 31 - Seasonings


Scenario: Scenario: [60737] Seasonings, Spices or Flavoring for Food - Salts (Solid)- RU001246
	# ====== Logging in as the correct user ====== #
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# ====== Just checks that the correct page loads ====== #
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60737
Given I delete all products with UPC Number: saved as UPC60737

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts

Then I save the product information as: TestCase60737

Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)

Given I call Shared Step 60756 (Additional Product Information with Country and every option)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false               | false       |            |

#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60737, container type: Aerosol Can and size: 20

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Then the Subscription Enrollment page should load

#CLF 30/5/2018 Subsciptional Enrollment page shows rather than Purchase summary
#Given I call Shared 54796 (Purchase Summary)
Given I navigate to the home page
Then I delete the product: TestCase60737



Scenario: Scenario: [60738] Seasonings, Spices or Flavoring for Food - Salts (Liquid)- RU001246
	# ====== Logging in as the correct user ====== #
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# ====== Just checks that the correct page loads ====== #
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60738
Given I delete all products with UPC Number: saved as UPC60738

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts

Then I save the product information as: TestCase60738

Given I call Shared Step 60747 (Select Primary Physical Property - Liquid - With Ingredients)

Given I call Shared Step 60756 (Additional Product Information with Country and every option)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false               | false       |            |

#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60738, container type: Aerosol Can and size: 20

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Then the Subscription Enrollment page should load

#CLF 30/5/2018 Subsciptional Enrollment page shows rather than Purchase summary
#Given I call Shared 54796 (Purchase Summary)
Given I navigate to the home page
Then I delete the product: TestCase60738


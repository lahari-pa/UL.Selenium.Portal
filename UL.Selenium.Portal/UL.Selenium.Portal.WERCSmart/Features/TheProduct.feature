@Shared
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
@SummaryPage
@run_TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
Feature: The Product

#Removed from regression 2024/03
@ignore
@TestCase:31347
Scenario: [31347] The Product validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given in the New Product page I click Continue
	#TODO: update below step for product name validation
	#And Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS) should be showing the error messages: This is a required field.
	And Type of Product (select) should be showing the error messages: This is a required field.

# Assigned to Beverly Barrett
# Created by Beverly Barrett
## Need tests for Cannot contain = ^ ? \ ~ [ ] | { } +
#Removed from regression 2024/03
@ignore
@TestCase:84643
Scenario: [84643] Product Name - can contain special characters - , character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: ,
	Then I save the product information as: TestCase84643
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84643

#Removed from regression 2024/03
@ignore
@TestCase:84644
Scenario: [84644] Product Name - can contain special characters - . character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: .
	Then I save the product information as: TestCase84644
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84644

#Removed from regression 2024/03
@ignore
@TestCase:84595
Scenario: [84595] Product Name - can contain special characters - & character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: &
	Then I save the product information as: TestCase84595
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84595

#Removed from regression 2024/03
@ignore
@TestCase:104073
Scenario: [104073] Product Name - can contain special characters - " character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: "
	Then I save the product information as: TestCase104073
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104073

#Removed from regression 2024/03
@ignore
@TestCase:104074
Scenario: [104074] Product Name - can contain special characters - ' character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: '
	Then I save the product information as: TestCase104074
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104074

#Removed from regression 2024/03
@ignore
@TestCase:104075
Scenario: [104075] Product Name - can contain special characters - % character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: %
	Then I save the product information as: TestCase104075
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104075

#Removed from regression 2024/03
@ignore
@TestCase:84624
Scenario: [84624] Product Name - can contain special characters - @ character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: @
	Then I save the product information as: TestCase84624
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84624

#Removed from regression 2024/03
@ignore
@TestCase:84629
Scenario: [84629] Product Name - can contain special characters - # character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: #
	Then I save the product information as: TestCase84629
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84629

#Removed from regression 2024/03
@ignore
@TestCase:84630
Scenario: [84630] Product Name - can contain special characters - $ character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: $
	Then I save the product information as: TestCase84630
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84630

#Removed from regression 2024/03
@ignore
@TestCase:84635
Scenario: [84635] Product Name - can contain special characters - ( character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: (
	Then I save the product information as: TestCase84635
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84635

#Removed from regression 2024/03
@ignore
@TestCase:84636
Scenario: [84636] Product Name - can contain special characters - ) character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: )
	Then I save the product information as: TestCase84636
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84636

#Removed from regression 2024/03
@ignore
@TestCase:84637
Scenario: [84637] Product Name - can contain special characters - _ character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: _
	Then I save the product information as: TestCase84637
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84637

#Removed from regression 2024/03
@ignore
@TestCase:84638
Scenario: [84638] Product Name - can contain special characters - "-" character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: -
	Then I save the product information as: TestCase84638
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84638

#Removed from regression 2024/03
@ignore
@TestCase:84639
Scenario: [84639] Product Name - can contain special characters - : character testing
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: :
	Then I save the product information as: TestCase84639
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84639

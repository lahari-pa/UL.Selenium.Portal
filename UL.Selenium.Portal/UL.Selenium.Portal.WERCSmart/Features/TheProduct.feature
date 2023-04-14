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
Feature: The Product

@TestCase:31346
Scenario: [31346] The Product navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I should see the The Product Page
	And I should see following statement: Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS)
	And I should see following statement: Product Line or Brand (optional)
	And I should see following statement: Type of Product (select)

@TestCase:31347
Scenario: [31347] The Product validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given in the New Product page I click Continue
	#TODO: update below step for product name validation
	#And Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS) should be showing the error messages: This is a required field.
	And Type of Product (select) should be showing the error messages: This is a required field.

# Assigned to Beverly Barrett
# Created by Beverly Barrett
## Need tests for Cannot contain = ^ ? \ ~ [ ] | { } +
@TestCase:84643
Scenario: [84643] Product Name - can contain special characters - , character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: ,
	Then I save the product information as: TestCase84643
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84643

@TestCase:84644
Scenario: [84644] Product Name - can contain special characters - . character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: .
	Then I save the product information as: TestCase84644
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84644

@TestCase:84595
Scenario: [84595] Product Name - can contain special characters - & character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: &
	Then I save the product information as: TestCase84595
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84595

@TestCase:104073
Scenario: [104073] Product Name - can contain special characters - " character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: "
	Then I save the product information as: TestCase104073
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104073

@TestCase:104074
Scenario: [104074] Product Name - can contain special characters - ' character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: '
	Then I save the product information as: TestCase104074
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104074

@TestCase:104075
Scenario: [104075] Product Name - can contain special characters - % character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: %
	Then I save the product information as: TestCase104075
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104075

@TestCase:84624
Scenario: [84624] Product Name - can contain special characters - @ character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: @
	Then I save the product information as: TestCase84624
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84624

@TestCase:84629
Scenario: [84629] Product Name - can contain special characters - # character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: #
	Then I save the product information as: TestCase84629
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84629

@TestCase:84630
Scenario: [84630] Product Name - can contain special characters - $ character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: $
	Then I save the product information as: TestCase84630
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84630

@TestCase:84635
Scenario: [84635] Product Name - can contain special characters - ( character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: (
	Then I save the product information as: TestCase84635
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84635

@TestCase:84636
Scenario: [84636] Product Name - can contain special characters - ) character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: )
	Then I save the product information as: TestCase84636
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84636

@TestCase:84637
Scenario: [84637] Product Name - can contain special characters - _ character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: _
	Then I save the product information as: TestCase84637
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84637

@TestCase:84638
Scenario: [84638] Product Name - can contain special characters - "-" character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: -
	Then I save the product information as: TestCase84638
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84638

@TestCase:84639
Scenario: [84639] Product Name - can contain special characters - : character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	And I call Shared Step 103904 - Validate Product Name can contain character: :
	Then I save the product information as: TestCase84639
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84639

#Remove from regression: 2023/04
@ignore
@TestCase:84640
Scenario: [84640] Product Name - can not contain special characters - ; character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	Then I call Shared Step 104068 Validate Product Name can not contain special characters: ;

#Remove from regression: 2023/04
@ignore
@TestCase:84641
Scenario: [84641] Product Name - can not contain special characters - < character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	Then I call Shared Step 104068 Validate Product Name can not contain special characters: <

#Remove from regression: 2023/04
@ignore
@TestCase:84642
Scenario: [84642] Product Name - can not contain special characters - > character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	Then I call Shared Step 104068 Validate Product Name can not contain special characters: >

#Remove from regression: 2023/04
@ignore
@TestCase:84631
Scenario: [84631] Product Name - can not contain special characters - ! character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	Then I call Shared Step 104068 Validate Product Name can not contain special characters: !

#Remove from regression: 2023/04
@ignore
@TestCase:84632
Scenario: [84632] Product Name - can not contain special characters - * character testing
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I set 'Type of Product' to: Bubble solution
	Then I call Shared Step 104068 Validate Product Name can not contain special characters: *

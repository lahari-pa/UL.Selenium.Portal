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

@TReVorId:20203
Scenario: [31346] The Product navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I should see the The Product Page
And I should see following statement: Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS)
And I should see following statement: Product Line or Brand (optional)
And I should see following statement: Type of Product (select)

@TReVorId:20206
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

@TReVorId:20261
Scenario: [84595] Product Name - can contain special characters - & character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: &The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "&The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod&uct Name
And I click continue
And I confirm the product name: "The Prod&uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name&
And I click continue
And I confirm the product name: "The Product Name&" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The & Product & Name &
And I click continue
And I confirm the product name: "The & Product & Name &" is displayed in the header
Then I save the product information as: TestCase84595
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84595

@TReVorId:20262
Scenario: [84624] Product Name - can contain special characters - @ character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: @The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "@The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod@uct Name
And I click continue
And I confirm the product name: "The Prod@uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name@
And I click continue
And I confirm the product name: "The Product Name@" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The @ Product @ Name @
And I click continue
And I confirm the product name: "The @ Product @ Name @" is displayed in the header
Then I save the product information as: TestCase84624
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84624

@TReVorId:20263
Scenario: [84629] Product Name - can contain special characters - # character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: #The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "#The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod#uct Name
And I click continue
And I confirm the product name: "The Prod#uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name#
And I click continue
And I confirm the product name: "The Product Name#" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The # Product # Name #
And I click continue
And I confirm the product name: "The # Product # Name #" is displayed in the header
Then I save the product information as: TestCase84629
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84629

@TReVorId:20264
Scenario: [84630] Product Name - can contain special characters - $ character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: $The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "$The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod$uct Name
And I click continue
And I confirm the product name: "The Prod$uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name$
And I click continue
And I confirm the product name: "The Product Name$" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The $ Product $ Name $
And I click continue
And I confirm the product name: "The $ Product $ Name $" is displayed in the header
Then I save the product information as: TestCase84630
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84630

@TReVorId:20265
Scenario: [84631] Product Name - can contain special characters - ! character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: !The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "!The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod!uct Name
And I click continue
And I confirm the product name: "The Prod!uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name!
And I click continue
And I confirm the product name: "The Product Name!" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The ! Product ! Name !
And I click continue
And I confirm the product name: "The ! Product ! Name !" is displayed in the header
Then I save the product information as: TestCase84631
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84631

@TReVorId:20266
Scenario: [84632] Product Name - can contain special characters - * character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: *The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "*The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod*uct Name
And I click continue
And I confirm the product name: "The Prod*uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name*
And I click continue
And I confirm the product name: "The Product Name*" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The * Product * Name *
And I click continue
And I confirm the product name: "The * Product * Name *" is displayed in the header
Then I save the product information as: TestCase84632
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84632

@TReVorId:20267
Scenario: [84635] Product Name - can contain special characters - ( character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: (The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "(The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod(uct Name
And I click continue
And I confirm the product name: "The Prod(uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name(
And I click continue
And I confirm the product name: "The Product Name(" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The ( Product ( Name (
And I click continue
And I confirm the product name: "The ( Product ( Name (" is displayed in the header
Then I save the product information as: TestCase84635
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84635

@TReVorId:20268
Scenario: [84636] Product Name - can contain special characters - ) character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: )The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: ")The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod)uct Name
And I click continue
And I confirm the product name: "The Prod)uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name)
And I click continue
And I confirm the product name: "The Product Name)" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The ) Product ) Name )
And I click continue
And I confirm the product name: "The ) Product ) Name )" is displayed in the header
Then I save the product information as: TestCase84636
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84636

@TReVorId:20269
Scenario: [84637] Product Name - can contain special characters - _ character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: _The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "_The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod_uct Name
And I click continue
And I confirm the product name: "The Prod_uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name_
And I click continue
And I confirm the product name: "The Product Name_" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The _ Product _ Name _
And I click continue
And I confirm the product name: "The _ Product _ Name _" is displayed in the header
Then I save the product information as: TestCase84637
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84637

@TReVorId:20270
Scenario: [84638] Product Name - can contain special characters - "-" character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: -The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "-The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod-uct Name
And I click continue
And I confirm the product name: "The Prod-uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name-
And I click continue
And I confirm the product name: "The Product Name-" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The - Product - Name -
And I click continue
And I confirm the product name: "The - Product - Name -" is displayed in the header
Then I save the product information as: TestCase84638
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84638

@TReVorId:20271
Scenario: [84639] Product Name - can contain special characters - : character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: :The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: ":The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod:uct Name
And I click continue
And I confirm the product name: "The Prod:uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name:
And I click continue
And I confirm the product name: "The Product Name:" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The : Product : Name :
And I click continue
And I confirm the product name: "The : Product : Name :" is displayed in the header
Then I save the product information as: TestCase84639
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84639

@TReVorId:20272
Scenario: [84640] Product Name - can contain special characters - ; character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: ;The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: ";The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod;uct Name
And I click continue
And I confirm the product name: "The Prod;uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name;
And I click continue
And I confirm the product name: "The Product Name;" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The ; Product ; Name ;
And I click continue
And I confirm the product name: "The ; Product ; Name ;" is displayed in the header
Then I save the product information as: TestCase84640
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84640

@TReVorId:20273
Scenario: [84641] Product Name - can contain special characters - < character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: <The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: "<The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod<uct Name
And I click continue
And I confirm the product name: "The Prod<uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name<
And I click continue
And I confirm the product name: "The Product Name<" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The < Product < Name <
And I click continue
And I confirm the product name: "The < Product < Name <" is displayed in the header
Then I save the product information as: TestCase84641
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84641

@TReVorId:20274
Scenario: [84642] Product Name - can contain special characters - > character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: >The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: ">The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod>uct Name
And I click continue
And I confirm the product name: "The Prod>uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name>
And I click continue
And I confirm the product name: "The Product Name>" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The > Product > Name >
And I click continue
And I confirm the product name: "The > Product > Name >" is displayed in the header
Then I save the product information as: TestCase84642
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84642

@TReVorId:20275
Scenario: [84643] Product Name - can contain special characters - , character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: ,The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: ",The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod,uct Name
And I click continue
And I confirm the product name: "The Prod,uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name,
And I click continue
And I confirm the product name: "The Product Name," is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The , Product , Name ,
And I click continue
And I confirm the product name: "The , Product , Name ," is displayed in the header
Then I save the product information as: TestCase84643
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84643

@TReVorId:20276
Scenario: [84644] Product Name - can contain special characters - . character testing
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I set the Product Name as it a appears on the Package Label field to: .The Product Name
And In the Product Type tab of the New Product Page, I enter: Bubble solution in the Type of Product select field
And I click continue
And I confirm the product name: ".The Product Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Prod.uct Name
And I click continue
And I confirm the product name: "The Prod.uct Name" is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The Product Name.
And I click continue
And I confirm the product name: "The Product Name." is displayed in the header
And in the New Product page I click section: The Product
And I set the Product Name as it a appears on the Package Label field to: The . Product . Name .
And I click continue
And I confirm the product name: "The . Product . Name ." is displayed in the header
Then I save the product information as: TestCase84644
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84644

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
@UPC
@SHA
@run_Flow8

Feature: The Product Screen

# Created by Saikiran Chittampally
@TestCase:83844
Scenario: [83844] The Product - Product Name - Validate Name with 449 Characters Limit
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC83844
	Given I delete all products with UPC Number: saved as UPC83844
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561a (The Product - Enter Product Name: 1ProductNameShouldBe449CharactersLongToGenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujjhycyyy and select Type of Product): bubble solution
	Then I save the product information as: TestCase83844
	Then I Confirm the Product name is shown at the top of the page
	Then I Confirm the Product name shows on 1 line only and shows (3-dots) ... at the end of the characters
	Then I Confirm the Product Name is shown in full in the hover over pop up
	Then I Confirm the WPS ID for the Product is shown at the end of the Product Name in brackets (parenthesis)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase83844

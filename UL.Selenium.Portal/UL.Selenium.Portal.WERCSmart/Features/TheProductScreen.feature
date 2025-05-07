@SummaryPage
@run_Flow8
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
@run_RetailerSelection
@UPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct


	Feature: The Product Screen

	# Created by Saikiran Chittampally
	@TestCase:83844
	Scenario: [83844] The Product - Product Name - Validate Name with 449 Characters Limit
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561a (The Product - Enter Product Name: 1 ProductNameShould Be449Characters Long To GenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujjh and select Type of Product): bubble solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: 1 ProductNameShould Be449Characters Long To GenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujjh
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase83844
	Then I Confirm the Product name is shown at the top of the page
	Then I Confirm the Product name shows on 1 line only and shows (3-dots) ... at the end of the characters
	Then I Confirm the Product Name is shown in full in the hover over pop up
	Then I Confirm the WPS ID for the Product is shown at the end of the Product Name in brackets (parenthesis)
	Then I navigate to the Home Page
	Then I search for the product saved as: TestCase83844
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase83844
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase83844
	#Then I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561a (The Product - Enter Product Name: 1ProductNameShouldBe449CharactersLongToGenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujgfthyjh and select Type of Product): bubble solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: 1ProductNameShouldBe449CharactersLongToGenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujgfthyjh
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase83844
	Then I Confirm the Product name is shown at the top of the page
	Then I Confirm the Product name shows on 1 line only and shows (3-dots) ... at the end of the characters
	Then I Confirm the Product Name is shown in full in the hover over pop up
	Then I Confirm the WPS ID for the Product is shown at the end of the Product Name in brackets (parenthesis)
	Then I navigate to the Home Page
	Then I search for the product saved as: TestCase83844
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase83844
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase83844
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561a (The Product - Enter Product Name: More1 ProductNameShould Be449Characters Long To GenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujjh and select Type of Product): bubble solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: More1 ProductNameShould Be449Characters Long To GenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujjh
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase83844
	Then I should see an error message: This field has a maximum length of 449 characters.
	Then I check that the input field with label: Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS) is shown as Red
	Then I set 'Product Name' to: 1ProductNameShouldBe449CharactersLongToGenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujgfthyjh
	Then I check that the input field with label: Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS) is shown as Green
	Then in the New Product page I click Continue
	Then I save the product information as: TestCase83844
	Then I should see the Product Information Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase83844
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase83844

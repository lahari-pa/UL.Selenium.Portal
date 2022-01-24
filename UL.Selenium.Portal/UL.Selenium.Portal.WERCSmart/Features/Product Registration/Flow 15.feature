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
@run_Flow15

Feature: Flow 15

@ScenarioId:698
Scenario: [58760] Light Bulbs - Light Emitting Diodes (LED) - RU000948
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I generate a random UPC number and save as: UPC58760
Given I delete all products with UPC Number: saved as UPC58760
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Light Bulbs - Light Emitting Diodes (LED)
Then I save the product information as: TestCase58760
And I call Shared Step 69687 (Product Information - US, No(PL))
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58760, container type: Plastic Container and size: 22
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58760. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Light Bulbs - Light Emitting Diodes (LED)
Given I navigate to the home page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase58760

@ScenarioId:697
Scenario: [58759] Servers, Small-Scale - RU001183
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I generate a random UPC number and save as: UPC58759
Given I delete all products with UPC Number: saved as UPC58759
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Servers, Small-Scale
Then I save the product information as: TestCase58759
# Shared 60935 replacing 57865 in test case
And I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
| Alkaline     | <any>        | 4                               | 2                                  |
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58759, container type: Plastic Container and size: 10.00
#Given in the Additional Documents to Provide page I click Continue
#Given in the Other Product Document Uploads page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58759. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Servers, Small-Scale
Given I navigate to the home page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase58759

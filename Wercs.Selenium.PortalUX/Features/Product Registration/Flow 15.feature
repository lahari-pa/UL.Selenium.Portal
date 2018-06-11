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

Scenario: [58760] Lights, LED - RU000948

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58760

Given I delete all products with UPC Number: saved as UPC58760

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57500 (The Product- Enter name, select product type: Lights, LED - Continue - Happy Path)

Given I call Shared Step 59922 (Additional Product Information - Private Label or Brand only)

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

# Missing step in test case - TCLP page

Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58760, container type: Plastic Container and size: 22

Given in the Other Product Document Uploads page I click Continue

Given in the Additional Documents Request page I click Continue

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58760. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Scenario: [58759] Servers, Small-Scale - RU001183

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58759

Given I delete all products with UPC Number: saved as UPC58759

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57500 (The Product- Enter name, select product type: Servers, Small-Scale - Continue - Happy Path)

# Shared 60935 replacing 57865 in test case

Given I call Shared Step 60935 (Additional Product Information - US - Direct Ship - Private Label Only)

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer                    | Number of batteries per package | How many batteries required to run |
| Alkaline     | Agawo Battery Industry Co., Ltd | 4                               | 2                                  |

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58759, container type: Plastic Container and size: 10.00

Given I call Shared Step 58608 (Additional Documents to Provide - Label - OSHA - CARB)

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58759. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

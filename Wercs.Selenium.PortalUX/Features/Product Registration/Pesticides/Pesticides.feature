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
@run_Pesticides

Feature: Pesticides

#release day
Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Then I save the product information as: TestCase71051

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

And I should see the Pesticide Details - U.S. Page

And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 72315-6

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Given I edit each State Pesticide Registration Number with an edited suffix

Given in the New Product page I click Continue

And I should see the Transportation Details 1 Page

Then in the New Product page I click section: Pesticide Details - State Registration Details

And I should see the Pesticide Details - State Registration Details Page

Then I check each State Pesticide Registration Number contains the edited suffix

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I check each State Pesticide Registration Number contains the edited suffix

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase71051

#release day
Scenario: [62848] Pesticide Details - EPA Expiration Date is refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Then I save the product information as: TestCase62848

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

And I should see the Pesticide Details - U.S. Page

And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 56228-10

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Given I confirm that there is data populated in the Expiration Date Column for some States

And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'

Then I edit the Expiration Date to: 2019-12-31 for the State: AZ on the Pesticide State Registration Details page

Given in the New Product page I click Continue

Then in the New Product page I click section: Pesticide Details - U.S.

And I should see the Pesticide Details - U.S. Page

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Then I confirm the 'Is Kelly Data' field for State: AZ is not checked

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I confirm the Expiration Date matches the value provided by Kelly on the State Registration Details Page for the edited State

Then I confirm the 'Is Kelly Data' field for State: AZ is checked

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62848

Scenario: [62775] Pesticides - Validation of Which one best describes your product question - Prevents, Destroys etc

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Then I save the product information as: TestCase62775

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

And I should see the Additional Product Information Page

Given I see the following sections
| Section                               |
| Which one best describes your product |

Given I should see a total of 3 radio buttons for the section: Which one best describes your product

Then I should see the following radio buttons:
| Button                                                                                                                  |
| Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)                      |
| Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth |
| Product is not considered a pesticide product                                                                           |

And in the New Product page I click Continue

Then I should see an error message: This is a required field.

And I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)

Then Which one best describes your product should not be showing the error messages: This is a required field.

And in the New Product page I click Continue

Then Which one best describes your product should not be showing the error messages: This is a required field.

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62775

Scenario: [62776] Pesticides - Validation of Which one best describes your product - Regulates Plant Growth

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Then I save the product information as: TestCase62776

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

And I should see the Additional Product Information Page

Given I see the following sections
| Section                               |
| Which one best describes your product |

Given I should see a total of 3 radio buttons for the section: Which one best describes your product

Then I should see the following radio buttons:
| Button                                                                                                                  |
| Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)                      |
| Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth |
| Product is not considered a pesticide product                                                                           |

And in the New Product page I click Continue

Then I should see an error message: This is a required field.

And I set the Which one best describes your product field to: Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth

Then Which one best describes your product should not be showing the error messages: This is a required field.

And in the New Product page I click Continue

Then Which one best describes your product should not be showing the error messages: This is a required field.

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62776

Scenario: [62849] Pesticide - Manually entered date not altered by refresh from Kelly

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Given I save the product information as: TestCase62849

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then I should see the Pesticide Details - U.S. Page

Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 305-48

Given in the New Product page I click Continue

Then I should see the Pesticide Details - State Registration Details Page

Then I confirm that there is data populated in the Expiration Date Column for some States

Then I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'

Then I edit the Expiration Date to: 2018-12-01 for the State: NY on the Pesticide State Registration Details page

Given I confirm the Expiration Date Provided By Kelly field for state: NY is blank

Given in the Pesticide Details - State Registration Details page I click Continue

Given in the New Product page I click section: Pesticide Details - U.S.

Then I should see the Pesticide Details - U.S. Page

Given in the Pesticide Details - U.S. page I click Continue

Given I confirm the Expiration Date Provided By Kelly field for state: NY is blank

Then I confirm the Expiration Date field for state: NY is showing the value: 2018-12-01

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I confirm the Expiration Date field for state: NY is showing the value: 2018-12-01

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62849

Scenario: [62852] Pesticide - Product Label is required

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Given I save the product information as: TestCase62852

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57505 (Pesticide Data - U.S. - EPA reg #(No) - EPA Exempt # (Random) - Continue - Happy Path)

Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Then I should see the Additional Documents to Provide Page

Given I see the following sections
| Section                               |
| Provide Full Product Label (required) |

Given in the Additional Documents to Provide page I click Continue

Then Provide Full Product Label (required) should be showing the error messages: Document is required: Please upload a PDF of the product label (full label).

Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: C:\Dependencies\WERCSmart\testdoc.pdf

# Click continue confirm no error
Given I click continue

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62852

Scenario: [56547] Pesiticde Data - EPA registration - Active Ingredient information returned from call to Kelly API

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Given I save the product information as: TestCase56547

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then I should see the Pesticide Details - U.S. Page

Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 73605-2

Given in the New Product page I click Continue

Then I should see the Pesticide Details - State Registration Details Page

Given in the New Product page I click section: Pesticide Details - U.S.

Then I should see the Pesticide Details - U.S. Page

Given I confirm data for EPA Registration: 73605-2 is complete

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56547

Scenario: [57512] Pesticide question shows in Additional Product Information for Flow 2L

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Given I save the product information as: TestCase57512

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57512

Scenario: [57516] Pesticide question shows in Additional Product Information for Flow 2-LS

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fertilizer

Given I save the product information as: TestCase57516

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57516

Scenario: [57520] Pesticide question shows in Additional Product Information for Flow 2-LS-B

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Animal Deterrent - Non-Aerosol

Given I save the product information as: TestCase57520

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57520


Scenario: [57522] Pesticide question shows in Additional Product Information for Flow 2-S

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide

Given I save the product information as: TestCase57522

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57522

Scenario: [57527] Pesticide question shows in Additional Product Information for Flow 6-A

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Disinfectant (Aerosol)

Given I save the product information as: TestCase57527

Given I call Shared 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57527

Scenario: [57529] Pesticide question shows in Additional Product Information for Flow 6-AG

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger

Given I save the product information as: TestCase57529

Given I call Shared Step 57532 (Product Characteristics - Aerosol & Gas available - Select Gas - Continue - Happy Path)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57529

Scenario: [57533] Pesticide question shows in Additional Product Information for Flow 6-All

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flea and Tick

Given I save the product information as: TestCase57533

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57533

Scenario: [57534] Pesticide question shows in Additional Product Information for Flow 6-LS

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bathroom and Tile Cleaner - Non-aerosol

Given I save the product information as: TestCase57534

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57534

Scenario: [57546] Pesticide question shows in Additional Product Information for Flow 2-A

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Algicide - Aerosol

Given I save the product information as: TestCase57546

Given I call Shared 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57546
@tfs_design
Scenario: [66344] Pesticide question shows in Additional Product Information for 3-Pest

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wipes, Disinfecting control

Given I save the product information as: TestCase66344

Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase66344
@tfs_design
Scenario: [66345] Pesticide question shows in Additional Product Information for Flow3-VOCSCA

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood finishing cloth, with Stain

Given I save the product information as: TestCase66345

Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase66345

#CLF - 12/7/2018 Test is not complete because plan does not seem to be complete
@56500
Scenario: [56500] Pesticide Data- Canada - validation of questions (updated)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I save the product information as: TestCase56500
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 57798 (Additional Product Information- Pesticide, Canada Only - No to everything else, Continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Then I should see the Pesticide Details - Canada Page
Then Field exists: Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product
Then in the Pesticide Details - Canada page I click Continue
Then For every field in the table I should see the following error: This is a required field.
| Field                |
| Provide Canada       |
| Product              |
| Alberta              |
| British Columbia     |
| Labrador             |
| Manitoba             |
| New Brunswick        |
| New Foundland        |
| Nova Scotia          |
| Ontario              |
| Prince Edward Island |
| Quebec               |
| Saskatchewan         |
| Northwest Territory  |
| Yukon Territory      |

Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 279255
Then in the Pesticide Details - Canada page I click Continue
Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: abc256
Then in the Pesticide Details - Canada page I click Continue
Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 2792
Then in the Pesticide Details - Canada page I click Continue
Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
Then in the Pesticide Details - Canada page I click Continue
Then Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product should not be showing any error messages
Then Field exists: Product's packaging includes a Poison Danger symbol
Given I set the Product's packaging includes a Poison Danger symbol field to: No
Then Product's packaging includes a Poison Danger symbol should not be showing any error messages
Then For every field in the table I call shared step 56494 expecting error: This is a required field.
| Field                |
| Alberta              |
| British Columbia     |
| Labrador             |
| Manitoba             |
| New Brunswick        |
| New Foundland        |
| Nova Scotia          |
| Ontario              |
| Prince Edward Island |
| Quebec               |
| Saskatchewan         |
| Northwest Territory  |
| Yukon Territory      |
Then in the Pesticide Details - Canada page I click Continue
Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
Given I call Shared Step 69388 (Retailer - Canada Only - Select No Retailer/No UPC product > Done > Continue - Happy Path)
Given I call Shared Step 69389 (Regulatory Documents to Provide - Canada only - Confirm questions - Request author, add label and todays date - Continue)
Then I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
Then I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue
#CLF - from here the test outcomes to dnot seem to be as predicted.
#I'm seeing Additional Documents -> Contact Information
Given I navigate to the home page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56500

Scenario: [56541] Pesticide Data - United States - EPA Registered - Data returned from call to Kelly API (done)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with pest control
Given I save the product information as: TestCase56541
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I should see the Pesticide Details - U.S. Page
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
Given in the New Product page I click Continue
Given I add the EPA registration number: 72315-6
Given in the New Product page I click Continue
And I should see the Pesticide Details - State Registration Details Page
Given I confirm that there is data populated in the Expiration Date Column for some States
Then I confirm that every date in the Expiration Date column has a matching date in the Expiration Date provided by Kelly column
And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
Given in the New Product page I click Continue
And I should see the Transportation Details 1 Page
Given I navigate to the home page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56541


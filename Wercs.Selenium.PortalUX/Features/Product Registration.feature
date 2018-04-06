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

Scenario: [63750] New Product - BCP
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Answering Machine, Battery Included in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Answering Machine, Battery Included in the Type of Product select field
And in the New Product page I click Continue
And I should see the Additional Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: No
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
And in the New Product page I click Continue
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
#Click Continue
#Pesticide screen displays
#The Battery-Containing Product Information page is shown
#Select any of the two radio buttons for the "indicate how battery is packaged" question
#Click any option for "Battery Type" in the Battery Table
#Type a manufacturer in the "Manufacturer" area and select any that show
#Enter a number for "Number of batteries or cells per package"
#Enter the same number for the "How many batteries or cells are required to run the equipment"
#Click Continue
#The Toxicity Characteristics Leaching Procedure (TCLP) Product Report page is shown
#Click No for "Product has had TCLP; Report is available" question
#Click No for the all eg "Lead"
#Answer Electronic Equipment questions no to all
#Click the Add Retailers button
#Select any retailer except for O'Reilly, Sears/K-Mart or Wal-Mart/SAM's CLUB because choosing any of these retailers will cause the Select Vendor drop down to display
# Click Add UPC button
# Enter UPC Number
# Select any option from the Type drop down
# Enter the Size
# Click Continue
# The "Provide any additional comments or information about the product
#that you want the Assessment Team to know." text is shown
#Add any text into the Product Comments text area
#Click Continue
#Data acceptance step displays
#Click the Summary button on the Data Acceptance screen
#Confirm that the Manufacturer column is visible
#Confirm that the name(s) of the battery is visible under the Manufacturer column
#Click the "X" on the Summary screen tab
#The Summary screen page will close and the user will return to the Data Acceptance screen
#42214
#Delete a product from the product grid
#Check product has been deleted by searching for it.

















































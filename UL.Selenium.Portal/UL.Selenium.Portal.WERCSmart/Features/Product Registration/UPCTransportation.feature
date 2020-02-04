@Shared
@ProductGrid
@NewProduct
@Homepage
@UPC
@ForwardProductRegistration
@PaymentMethods
@SummaryPage
@run_UPCTransportation
Feature: UPCTransportation

Scenario: [122305] UPC Transportation options are present if product-level options are present
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC112305
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122305
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 66                         | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Appreciable                                  | 66               |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	Given I click continue
	Given I enter UN1993 - Select data - Continue - Happy Path
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Then I click Done on Select Retailers window
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC112305, container type: Plastic Container and size: 2 do not click continue
	Given I ensure that there is a column in the Add UPC table called Transportation
	Given I ensure that DOT is listed as Shipping with limited quantity
	Given I ensure that IATA is listed as Shipping with limited quantity
	Given I ensure that I cannot select DOT at Shipping with consumer commodity
	Given I ensure that I cannot select IATA at Shipping with consumer commodity
	Given I ensure that the IMDG checkbox is not present in the UPC Transportation column
	Given I ensure that the TDG checkbox is not present in the UPC Transportation column
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122305

@tfs_design
Scenario: [122382] UPC Transportation - UPC Reset Popup
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: RandomUPC
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122382
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Appreciable                                  | 2                |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	# Select IMDG and Limited Quantity
	# Select TDG and Limited Quantity
	Given I click continue
	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols, 2.1, None, add technical name, Click Continue)
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I should see the International Marine (IMDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPCRandomUPC, container type: Plastic Container and size: 2 do not click continue
	# In the UPC Transportation column, upgrade DOT to Fully Regulated
	# Upgrade IATA to Fully Regulated
	# Upgrade IMDG to Fully Regulated
	# Upgrade TDG to Fully Regulated
	Given I click continue
	# Navigate to the Transportation Details 1 screen
	# In the DOT section, unselect everything and select Consumer Commodity
	# In the IATA section, unselect everything and then select Consumer Commodity
	Given I click Save in The Product Page
	# Confirm we get a popup saying that we have reset the UPC data (get exact text)
	# Navigate to the UPC screen
	# Ensure that DOT is listed at Consumer Commodity
	# Ensure that IATA is listed at Consumer Commodity
	# Ensure that IMDG has reset to Limited Quantity
	# Ensure that TDG has reset to Limited Quantity
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122382

@tfs_design
Scenario: [122428] UPC Transportation - Forwarding
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: RandomUPC
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122428
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 2                          | 66                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Appreciable                                  | 2                |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	# Select IMDG and Limited Quantity
	# Select TDG and Limited Quantity
	Given I click continue
	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols, 2.1, None, add technical name, Click Continue)
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I should see the International Marine (IMDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPCRandomUPC, container type: Plastic Container and size: 2 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I navigate to the home page
	Given I search for the product saved as: TestCase122428
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Given I enter the text: saved as TestCase in the 'Search by WPS ID or Product Name' field
	Given In the Foward Product Registration Screen I should see product: saved as TestCase122428
	Given In the Foward Product Registration Screen I Select the product: saved as TestCase122428
	Given I click continue on the Forward Product Registration page
	Given In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Walgreens under Other Retailers and save it as: Retailer
	Given I click continue on the Forward Product Registration page
	# Select your product on the left hand side of the screen in the Select UPCs tab
	# Ensure that the Select UPCs table on the right side of the screen contains a Transportation column
	# Ensure that DOT is listed as shipping with limited quantity
	# Ensure that IATA is listed as shipping with limited quantity
	# Ensure that IMDG is listed as shipping with limited quantity
	# Ensure that TDG is listed as shipping with limited quantity
	# Select Edit for the UPC in the Select UPCs table
	# Ensure that there is a Transportation section in the Edit UPC popup
	# Ensure that the Transportation section lists DOT, IATA, IMDG, and TDG as shipping with limited quantity
	# Ensure that you can select only one exception
	# Ensure that for DOT and IATA, you cannot downgrade to Consumer Commodity
	# Upgrade DOT to fully regulated
	# Upgrade IATA to fully regulated
	# Click Save
	# Ensure that the Transportation column now lists DOT and IATA as fully regulated
	# Ensure that IMDG and TDG are still listed as Limited Quantity
	# Click Add a UPC
	# Ensure that DOT, IATA, IMDG, and TDG are all listed in the Transportation section as Limited Quantity
	# Enter any UPC, packaging type, and size data
	# Click Save
	# Ensure that the Select UPCs column shows Limited Quantity in the Transportation column for DOT, IATA, IMDG, and TDG
	Given I click continue on the Forward Product Registration page
	Given I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	Given I click continue on the Forward Product Registration page
	Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed

Scenario: [122940] UPC Transporation - Data Entry - Exceptions
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC122940
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122940
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 66                         | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Appreciable                                  | 66               |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I click continue
	Given I enter UN1993 - Select data - Continue - Happy Path
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC122940, container type: Plastic Container and size: 2 do not click continue
	Given I ensure that I can only select one exception in the UPC Transportation column
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122940

Scenario: [122971] UPC Transportation - Data Entry - Upgrading to Fully Regulated at the UPC Level
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC122971
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122971
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 66                         | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Appreciable                                  | 66               |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	Given I click continue
	Given I enter UN1993 - Select data - Continue - Happy Path
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC122971, container type: Plastic Container and size: 2 do not click continue
	Given At the UPC level, I set DOT to Shipping fully regulated
	Given At the UPC level, I set IATA to Shipping fully regulated
	Given I click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given In the section 'Select all modes of transport that you've classified the product for', I see DOT listed at Shipping with limited quantity
	Given In the section 'Select all modes of transport that you've classified the product for', I see IATA listed at Shipping with limited quantity
	Given I ensure that the UPC table displays a column called 'UPC Transportation'
	Given In the Summary screen UPC table, I ensure that DOT is listed as Shipping fully regulated
	Given In the Summary screen UPC table, I ensure that IATA is listed as Shipping fully regulated
	Given I close the window that opened
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122971

@tfs_design
Scenario: [122984] UPC Transportation - Forwarding - iRules - Edit UPC
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: RandomUPC
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 66                         | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Appreciable                                  | 66               |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I click continue
	# Enter UN2831. Ensure that Hazard class is 6.1 and Packing group is III.
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	Given I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPCRandomUPC, container type: Plastic Container and size: 169 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I navigate to the home page
	Given I search for the product saved as: TestCase
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Given I enter the text: saved as TestCase in the 'Search by WPS ID or Product Name' field
	Given In the Foward Product Registration Screen I should see product: saved as TestCase
	Given In the Foward Product Registration Screen I Select the product: saved as TestCase
	Given I click continue on the Forward Product Registration page
	Given In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Walgreens under Other Retailers and save it as: Retailer
	Given I click continue on the Forward Product Registration page
# Select your product on the left hand side of the screen in the Select UPCs tab
# Select Edit for the UPC in the Select UPCs table
# Change the size attribute of the UPC to 170
# Click Save
# Ensure that you get an error that  tells you to check your transportation information

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
@run_Flow6

Feature: Flow 6

@TestCase:78731
Scenario: [78731] Insecticide - Crawling Bug - Aerosol (RU001005) - 6A

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC78731

Given I delete all products with UPC Number: saved as UPC78731

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Crawling Bug - Aerosol

Then I save the product information as: TestCase78731

Given I call Shared Step 57502 (Product Information - Preventing, Destroying, Repelling, Mitigating Pests, US only, NO to everything else - Continue - Happy Path)

Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |

Given in the Volatile Organic Compound Summary page I click Continue

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC78731, container type: Aerosol Can and size: 1

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue.

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Insecticide - Crawling Bug - Aerosol

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78731

@ignore
@TestCase:57711
Scenario: [57711] Antifungal - Aerosol (RU000050) - 6A

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57711

Given I delete all products with UPC Number: saved as UPC57711

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Antifungal - Aerosol

Then I save the product information as: TestCase57711

Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |


Given I set 'Prop65' to: No
Given in the Waste Classification Data page I click Continue


Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)

Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954

#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |

Given in the Volatile Organic Compound Summary page I click Continue

#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

#Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57711, container type: Aerosol Can and size: 33

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

#Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)

Given In the Additional Documents to Provide screen I upload label for section 'Provide Full Product Label (required)'

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text

Then In the Data Acceptance page I select Agreed

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Antifungal - Aerosol

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57711


@TestCase:57647
Scenario: [57647] Insecticide-Flying Bug-Moth Proofing Product containing <98% Para-Dichlorobenzene - (RU001000) - 2S
    Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	Then I generate a random UPC number and save as: UPC87914
	Then I save the product information as: TestCase87914
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	Given I click continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
	|           | Potassium hydroxide | 100     | false               |            | false       |
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
    Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 34455 (U. S. Department of Transportation (DOT) Classification - Enter all valid data)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87914, container type: Cardboard and size: 33
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58736. !"�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87914


# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 6
@TestCase:57134
Scenario: [57134] Insecticide - Flea and Tick (RU001407) - Aerosol - PESTICIDE with Granted 'Alternative Control Plan' (VOC Exempt)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I generate a random UPC number and save as: UPC57134
	Given I delete all products with UPC Number: saved as UPC57134
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flea and Tick
	Then I save the product information as: TestCase57134
	Given I call Shared Step 101692 Product Information - Pesticide Question - Happy Path
	Given I call Shared Step 101672 (Physical and Chemical Properties - Primary Physical State = Aerosol / Secondary Physical State = Liquid Spray )
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName          | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 26002-80-2 | 0.4     | false               | false       |            |		 
		| 113-48-4 |  1.6     | false               | false       |            |
		|95737-68-1  | 0.1     | false               | false       |            |
		| 74-98-6  | 2.22     | false               | false       |            |
		| 75-28-5 | 12.4     | false               | false       |            |
		| 64742-47-8 | 83.28      | false               | true       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 29183 (Pesticide Details - U.S. - No EPA number)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| Yes                                       | 2                     | 2                          | Yes            |
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57134, container type: Aerosol Can and size: 1
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 54796 (Purchase Summary)
	Given I call (confirm a Product from the Product grid) to confirm product: TestCase57134


	# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 6
@TestCase:208260
Scenario: [208260]  Insecticide - Flea and Tick (RU001407) - Aerosol - PESTICIDE with NOT Granted 'Alternative Control Plan' (VOC Exempt)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I generate a random UPC number and save as: UPC208260
	Given I delete all products with UPC Number: saved as UPC208260
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flea and Tick
	Then I save the product information as: TestCase208260
	Given I call Shared Step 101692 Product Information - Pesticide Question - Happy Path
	Given I call Shared Step 101672 (Physical and Chemical Properties - Primary Physical State = Aerosol / Secondary Physical State = Liquid Spray )
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName          | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 26002-80-2 | 0.4     | false               | false       |            |		 
		| 113-48-4 |  1.6     | false               | false       |            |
		|95737-68-1  | 0.1     | false               | false       |            |
		| 74-98-6  | 2.22     | false               | false       |            |
		| 75-28-5 | 12.4     | false               | false       |            |
		| 64742-47-8 | 83.28      | false               | true       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 29183 (Pesticide Details - U.S. - No EPA number)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 208261 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - No for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | No            |
	Given I should Enter the following Voc percent for each state: 2
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC208260, container type: Aerosol Can and size: 1
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 54796 (Purchase Summary)
	Given I call (confirm a Product from the Product grid) to confirm product: TestCase208260

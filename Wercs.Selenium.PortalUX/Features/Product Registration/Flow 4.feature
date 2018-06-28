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
@run_Flow4

Feature: Flow 4



Scenario: [57922] Odor Remover/Eliminator - Aerosol (RU001086) - 4A

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Odor Remover/Eliminator - Aerosol

Then I save the product information as: TestCase57922

Given I call Shared 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)

Given I call Shared Step 63804 (Additional Product Information - enter options)
| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
| No                                                             | No                            | No                         | No                         |

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |

Given in the Volatile Organic Compound Summary page I click Continue

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: No Retailer/No UPC Product

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Odor Remover/Eliminator - Aerosol

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57922

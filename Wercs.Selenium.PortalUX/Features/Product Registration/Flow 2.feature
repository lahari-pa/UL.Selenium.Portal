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
@run_Flow2

Feature: Flow 2


Scenario: [57367] Spill Clean Up Agent (Mitigation Agent)- RU000957 - 2S

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57367

Given I delete all products with UPC Number: saved as UPC57367

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Spill Clean Up Agent (Mitigation Agent)

Then I save the product information as: TestCase57367

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Triclosan        | 24.94   | false               | false       |            |
| Hydrogen         | 30.2    | false               | false       |            |
| Propylene Glycol | 19.8    | false               | false       |            |
| Butane           | 25.06   | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 34455 (U. S. Department of Transportation (DOT) Classification - Enter all valid data)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57367, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

And in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Spill Clean Up Agent (Mitigation Agent)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57367


Scenario: [57403] Septic System Maintainer (RU000174) - 2LS - 2S

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57403

Given I delete all products with UPC Number: saved as UPC57403

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Septic system maintainer

Then I save the product information as: TestCase57403

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57403, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Septic system maintainer

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57403



Scenario: [57439] Anti-Transpirant (RU000992) 2-L

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57439

Given I delete all products with UPC Number: saved as UPC57439

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Transpirant

Then I save the product information as: TestCase57439

Given I call Shared Step 73629 (Product Characteristics - Liquid - select any options(enter pH, boiling point, flash point))
| Secondary Physical State | Specific Gravity | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Appreciable                                  |

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57439, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Transpirant

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57439



Scenario: [57646] Plant Growth regulator (Liquid or Solid) (RU000291) 2-L

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57646

Given I delete all products with UPC Number: saved as UPC57646

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Plant Growth regulator (Liquid or Solid)

Then I save the product information as: TestCase57646

Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |


Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57646, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Plant Growth regulator (Liquid or Solid)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57646


Scenario: [57648] Trap and/or Bait Station - (RU000208) - 4S

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57648

Given I delete all products with UPC Number: saved as UPC57648

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Trap and/or Bait Station

Then I save the product information as: TestCase57648

Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57648, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Trap and/or Bait Station

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57648


Scenario: [57649] Cosmetics (RU000034) 2LS - 2L

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cosmetics

Then I save the product information as: TestCase57649

Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |


Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: No Retailer/No UPC Product

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Cosmetics

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57649


Scenario: [57708] Aquarium Maintenance chemicals (RU000327) - 2LS -2L

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57708

Given I delete all products with UPC Number: saved as UPC57708

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Aquarium maintenance chemicals

Then I save the product information as: TestCase57708

Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |


Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57708, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Aquarium maintenance chemicals

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57708


Scenario: [57731] Aquarium maintenance chemicals (RU000327) - 2LS - 2S

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57731

Given I delete all products with UPC Number: saved as UPC57731

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Aquarium maintenance chemicals

Then I save the product information as: TestCase57731

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57731, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Aquarium maintenance chemicals

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57731


Scenario: [57910] Septic System Maintainer (RU000174) - 2LS - 2L

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57910

Given I delete all products with UPC Number: saved as UPC57910

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Septic system maintainer

Then I save the product information as: TestCase57910

Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57910, container type: Aerosol Can and size: 33

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Septic system maintainer

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57910

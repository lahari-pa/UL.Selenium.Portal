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
@run_CVSRCL

Feature: CVS RCL

@TReVorId:16789
Scenario: [74208] CVS merchandising category and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428290231 as: UPC74208
#
#Given I delete all products with UPC Number: saved as UPC74208

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74208

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Camphor

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Needs 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: Beauty 360 (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Canady, Cory Cory.Canady@CVSHealth.com

Then the question: What is the CVS merchandising category for this product? is displayed at position: 3

And The following options should be displayed exclusively for section: What is the CVS merchandising category for this product?
| Option                    |
| Acne/HSC                  |
| Adult Care                |
| Allergy Remedies          |
| APPAREL                   |
| Baby Care                 |
| Baked Goods – Frozen Food |
| BATTERIES                 |
| Beverages                 |
| Bulb & Wire               |
| Candles                   |
| Candy                     |
| Cold Remedies             |
| Cosmetics                 |
| Dairy                     |
| Deodorants                |
| Diet/Nutrition            |
| Digestive Health          |
| External Pain             |
| Eye Care                  |
| Facial Care               |
| Feminine Care             |
| FIRST AID                 |
| Foot Care                 |
| Fragrances                |
| Grocery                   |
| Hair Care                 |
| Hair Notions              |
| Hand & Body               |
| Home Diagnostics          |
| Home Health Care          |
| Hosiery                   |
| Household                 |
| Household Paper           |
| Housewares                |
| LAUNDRY                   |
| Nicotine Replacement      |
| Oral Hygiene              |
| Pain Relievers            |
| Personal Cleansing        |
| Personal Intimacy         |
| PET SUPPLIES              |
| Photo Processing 1 Hour   |
| Picture Frames & ALB      |
| Pro Salon                 |
| Reading Glasses           |
| Seasonal                  |
| Seasonal Fall & Winter    |
| Seasonal Toys             |
| Shaving Needs             |
| Small Electronics         |
| Snacks                    |
| Stationery                |
| Suncare                   |
| Top of Checkout           |
| Toys                      |
| Trial Travel              |
| Vitamins                  |
| Wine & Spirits            |
| Other                     |

Given I click continue

Then What is the CVS merchandising category for this product? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74208

@TReVorId:16809
Scenario: [74253] CVS marketed or labeled for infants question and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428156483 as: UPC74253
#
#Given I delete all products with UPC Number: saved as UPC74253

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74253

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Camphor

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: Beauty 360 (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Canady, Cory Cory.Canady@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Cosmetics

Then the question: Is this product specifically designed, marketed or labeled for infants, babies, or children? is displayed at position: 4

Given I click continue

Then Is this product specifically designed, marketed or labeled for infants, babies, or children? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74253

@TReVorId:16810
Scenario: [74254] CVS topically used product and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428285367 as: UPC74254
#
#Given I delete all products with UPC Number: saved as UPC74254

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74254

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 15.025

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Then the question: Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? is displayed at position: 5

Given I click continue

Then Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74254

@TReVorId:16811
Scenario: [74255] CVS microbeads product and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428285367 as: UPC74255
#
#Given I delete all products with UPC Number: saved as UPC74255

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74255

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 28.95

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Given I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: Yes

Then the question: Product contains microbeads is displayed at position: 6

Given I click continue

Then Product contains microbeads should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74255

@TReVorId:16806
Scenario: [74256] CVS Refer to your Product Label and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428290231 as: UPC74256
#
#Given I delete all products with UPC Number: saved as UPC74256

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74256

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2.10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Given I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: Yes

Given I set the Product contains microbeads option to: No

Given I set the Is this product intended to be rinsed off after use? option to: Yes

Then the question: Refer to your Product Label. Select the options that appear on the label. is displayed at position: 8

And The following options should be displayed for section: Refer to your Product Label. Select the options that appear on the label.
| Option                                      |
| Drug Facts Panel                            |
| Supplement Facts Panel                      |
| Nutrition Facts Panel                       |
| Active Ingredient Panel                     |
| An Active Ingredient is listed on the Panel |
| None of the Above                           |

Given I click continue

#Then Refer to your Product Label. Select the options that appear on the label. should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74256

@TReVorId:16812
Scenario: [74257] CVS product intended to be rinsed off after use and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428290231 as: UPC74257
#
#Given I delete all products with UPC Number: saved as UPC74257

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74257

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2.10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Given I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: Yes

Given I set the Product contains microbeads option to: No

Then the question: Is this product intended to be rinsed off after use? is displayed at position: 7

Given I click continue

Then Is this product intended to be rinsed off after use? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74257

@TReVorId:16813
Scenario: [74259] CVS product intended to be ingested and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428290231 as: UPC74259
#
#Given I delete all products with UPC Number: saved as UPC74259

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74259

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2.10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: Yes

Given I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: Yes

Given I set the Product contains microbeads option to: Yes

Given I set the Is this product intended to be rinsed off after use? option to: Yes

Given I set the Refer to your Product Label. Select the options that appear on the label. option to: None of the Above

Then the question: Is this product intended to be ingested? is displayed at position: 9

Given I click continue

Then Is this product intended to be ingested? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74259

@TReVorId:16814
Scenario: [74260] CVS Is this product a personal care sanitizer and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

#Given I save the UPC number 050428290231 as: UPC74260
#
#Given I delete all products with UPC Number: saved as UPC74260

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74260

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2.10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Given I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: Yes

Given I set the Product contains microbeads option to: No

Given I set the Is this product intended to be rinsed off after use? option to: No

Given I set the Refer to your Product Label. Select the options that appear on the label. option to: None of the Above

Given I set the Is this product intended to be ingested? option to: No

Then the question: Is this product a personal care sanitizer, wash, or cleanser (e.g., Hand, Body, Facial)? is displayed at position: 10

Given I click continue

Then Is this product a personal care sanitizer, wash, or cleanser (e.g., Hand, Body, Facial)? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74260

@TReVorId:16807
Scenario: [74188] CVS Store Brand Associations and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57205 (Go to Retail Partners - Select CVS)

Then I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |
| 2.2  | On    |

Given if the save button is visible, I save changes and close the popup dialog

Given I navigate to the home page

Given I save the UPC number 050428290231 as: UPC74188

Given I delete all products with UPC Number: saved as UPC74188

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74188

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2.10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Then the question: What is the CVS Store Brand associated to this product? is displayed at position: 1

And The following options should be displayed for section: What is the CVS Store Brand associated to this product?
| Option                                                                                                   |
| Beauty 360 (CVS Pharmacy)                                                                                |
| Blade                                                                                                    |
| Caliber                                                                                                  |
| Cottondale                                                                                               |
| CVS Batteries                                                                                            |
| CVS Health (CVS Pharmacy)                                                                                |
| DVX                                                                                                      |
| Essence Of Beauty                                                                                        |
| GE Abound                                                                                                |
| GE Lighting - PL                                                                                         |
| Gold Emblem                                                                                              |
| Gran Legacy                                                                                              |
| Hawaiian Traditions                                                                                      |
| House to Home                                                                                            |
| Island Accents                                                                                           |
| JT Boots                                                                                                 |
| Just The Basics                                                                                          |
| Live Better                                                                                              |
| Lux Flavors                                                                                              |
| Merry Brite                                                                                              |
| Non-Brand with CVS Distribution Statement                                                                |
| Nuance Salma Hayek                                                                                       |
| Pa'Ina                                                                                                   |
| Pet Central                                                                                              |
| Poparazzi                                                                                                |
| Radiance Base                                                                                            |
| Radiance Platinum                                                                                        |
| Red And Pink                                                                                             |
| Rosebrook                                                                                                |
| Santa's Treats                                                                                           |
| Skin + Pharmacy                                                                                          |
| Spooky Village                                                                                           |
| Style Essentials                                                                                         |
| Total Home                                                                                               |
| Vida Mia                                                                                                 |
| ZX                                                                                                       |
| Other                                                                                                    |

Given I click continue

Then What is the CVS Store Brand associated to this product? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74188

@TReVorId:16808
Scenario: [74207] Product Development Manager (PDM) and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57205 (Go to Retail Partners - Select CVS)

Then I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |
| 2.2  | On    |

Given if the save button is visible, I save changes and close the popup dialog

Given I navigate to the home page

#Given I save the UPC number 050428290231 as: UPC74207
#
#Given I delete all products with UPC Number: saved as UPC74207

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74207

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2.10

Given I call Shared Step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: Live Better

Then the question: Who is the Product Development Manager (PDM) for this product? is displayed at position: 2

Then The Product Development Manager options should comprise a list containing the domain @CVSHealth.com

Given I click continue

Then Who is the Product Development Manager (PDM) for this product? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74207

@TReVorId:16816
Scenario: [74270] CVS RCL - Page should not show if Product does NOT have CVS Selected but has an eligible UPC

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57205 (Go to Retail Partners - Select CVS)

Then I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |
| 2.2  | On    |

Given if the save button is visible, I save changes and close the popup dialog

Given I navigate to the home page

#Given I save the UPC number 050428075661 as: UPC74270
#
#Given I delete all products with UPC Number: saved as UPC74270

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74270

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 74269 (Select Retailers - Rite Aid)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 10

Then I should not see the CVS RCL Page

And I should see the Regulatory Documents to Provide Page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74270

@TReVorId:16817
Scenario: [74272] CVS RCL - Page is NOT shown if Product has CVS selected with a UPC that does not start 050428

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57205 (Go to Retail Partners - Select CVS)

Then I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |
| 2.2  | On    |

Given if the save button is visible, I save changes and close the popup dialog

Given I navigate to the home page

#Given I save the UPC number 0043396824430 as: UPC74272
#
#Given I delete all products with UPC Number: saved as UPC74272

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74272

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 10

Then I should not see the CVS RCL Page

And I should see the Regulatory Documents to Provide Page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74272

@TReVorId:16815
Scenario: [74261] CVS Brand Registration section and validation

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57205 (Go to Retail Partners - Select CVS)

Then I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |
| 2.2  | On    |

Given if the save button is visible, I save changes and close the popup dialog

Given I navigate to the home page

#Given I save the UPC number 050428075661 as: UPC74261
#
#Given I delete all products with UPC Number: saved as UPC74261

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74261

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 74201 (Select Retailers - CVS)

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 10

And I confirm the page heading shows the CVS Logo with the title 'CVS Own Brand Registration' below the logo

And The displayed message text is comprised of the following paragraphs
| Paragraph                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| CVS Pharmacy has taken a major step forward in advancing its efforts to remove chemicals of concern to our customers. This action is a significant milestone in CVS Pharmacy's journey to provide products that are safe, compliant, sustainable and help people on their path to better health. As a supplier registering a CVS Pharmacy Store Brand Product, you are required to complete additional screening and questions to support CVS's restricted chemical commitment.                                                                                                                                       |
| Your product will be screened by WERCs against CVS Pharmacy's Restricted Chemical Policy (RCP) as outlined in the CVS Store Brand Quality Assurance Agreement. CVS will be notified when an item is non-compliant with CVS Pharmacy's RCP. The notification will include the item that is out of compliance and only disclose the non-compliant ingredients marked as publicly available. The output of the screening has been designed to protect the supplier's proprietary information. The Supplier is responsible for working directly with their CVS Product Development Manager to resolve the non-compliance. |

And I see the following sections
| Section   |
| Continue? |

Given I click continue

Then I should see an error message: This is a required field.

Then The alert message is displayed with text: Contact your CVS Product Development Manager with any questions.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74261

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

Scenario: [74208] CVS merchandising category and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428290231 as: UPC74208

Given I delete all products with UPC Number: saved as UPC74208

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74208

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Camphor

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Needs 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74208, container type: Plastic Container and size: 10

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: Beauty 360 (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Canady, Cory Cory.Canady@CVSHealth.com

Then the question: What is the CVS merchandising category for this product? is displayed at position: 3

And The following options should be displayed exclusively for section: What is the CVS merchandising category for this product?
| Option                    |
| Acne/HSC                  |
| Adult Care                |
| Allergy Remedies          |
| Apparel                   |
| Appliances                |
| Baby Care                 |
| Baked Goods – Frozen Food |
| Batteries                 |
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
| First Aid                 |
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
| Laundry                   |
| Nicotine Replacement      |
| Oral Hygiene              |
| Pain Relievers            |
| Personal Cleansing        |
| Personal Intimacy         |
| Pet Supplies              |
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
| Sunglasses                |
| Top of Checkout           |
| Toys                      |
| Trial Travel              |
| Vitamins                  |
| Wine & Spirits            |
| Other                     |

Given I click continue

Then What is the CVS merchandising category for this product? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74208

Scenario: [74253] CVS marketed or labeled for infants question and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428156483 as: UPC74253

Given I delete all products with UPC Number: saved as UPC74253

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74253

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Camphor

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74253, container type: Plastic Container and size: 10

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: Beauty 360 (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Canady, Cory Cory.Canady@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Cosmetics

Then the question: Is this product specifically designed, marketed or labeled for infants, babies, or children? is displayed at position: 4

Given I click continue

Then Is this product specifically designed, marketed or labeled for infants, babies, or children? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74253

Scenario: [74254] CVS topically used product and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428285367 as: UPC74254

Given I delete all products with UPC Number: saved as UPC74254

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74254

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74254, container type: Plastic Container and size: 15.025

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Then the question: Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? is displayed at position: 5

Given I click continue

Then Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74254

Scenario: [74255] CVS microbeads product and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428285367 as: UPC74255

Given I delete all products with UPC Number: saved as UPC74255

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74255

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Lanolin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74255, container type: Plastic Container and size: 28.95

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

Given I set the What is the CVS Store Brand associated to this product? option to: CVS Health (CVS Pharmacy)

Given I set the Who is the Product Development Manager (PDM) for this product? option to: Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com

Given I set the What is the CVS merchandising category for this product? option to: Facial Care

Given I set the Is this product specifically designed, marketed or labeled for infants, babies, or children? option to: No

Given I set the Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels? option to: Yes

Then the question: Product contains microbeads is displayed at position: 6

Given I click continue

Then Product contains microbeads should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74255

Scenario: [74256] CVS Refer to your Product Label and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428290231 as: UPC74256

Given I delete all products with UPC Number: saved as UPC74256

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74256

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74256, container type: Plastic Container and size: 2.10

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

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

Then Refer to your Product Label. Select the options that appear on the label. should be showing the error messages: This is a required field.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74256

Scenario: [74257] CVS product intended to be rinsed off after use and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428290231 as: UPC74257

Given I delete all products with UPC Number: saved as UPC74257

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74257

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74257, container type: Plastic Container and size: 2.10

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

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

Scenario: [74259] CVS product intended to be ingested and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428290231 as: UPC74259

Given I delete all products with UPC Number: saved as UPC74259

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74259

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74259, container type: Plastic Container and size: 2.10

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

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

Scenario: [74260] CVS Is this product a personal care sanitizer and verification

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I save the UPC number 050428290231 as: UPC74260

Given I delete all products with UPC Number: saved as UPC74260

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm

Then I save the product information as: TestCase74260

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call shared step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

# Requires 'Indicate full name of product, as sold, via this retailer (eg. Private Label Asprin)' in Retailer page - in shared 74201

Given I call shared step 74201 (Select Retailers - CVS)

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74260, container type: Plastic Container and size: 2.10

Given I call shared step 74202 (CVS Pharmacy - Yes, I wish to Continue)

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

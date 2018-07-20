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

# Take a note of the product ID

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74208

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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@ProductSetUp
@run_ReleaseDay

Feature: Release Day

Scenario: [55796] Navigate to Home Page
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load

# Check correct items are showing in header bar
Then I should see the UL/WERCSmart Logo in the header bar
And I should see the User Icon in the header bar

# Check correct items are showing in the User dropdown menu
Then I click the User Icon
And I should see My Account in the user dropdown
And I should see Sign Out in the user dropdown

# Checking that the navigation bar is showing
Then I should see the Navigation Menu Icon in the navigation bar

# Expands the navigation bar and checks that the correct icons and labels are showing
Then I expand the Navigation Menu
And the following icons and labels should be found in the navigation bar
| Item                 |
| Home                 |
| Register New Product |
| My Messages          |
| Retail Partners      |
| Supplier Reports     |
| UL Solution Center   |
| Shopping Cart        |
| Support              |

# Collapses the navigation bar and checks that only the icons are displayed on the screen (not the labels!)
Then I collapse the Navigation Menu
And the following icons should be found in the navigation bar
| Item                 |
| Home                 |
| Register New Product |
| My Messages          |
| Retail Partners      |
| Supplier Reports     |
| UL Solution Center   |
| Shopping Cart        |
| Support              |

# Checks that the top menu can be collapsed successfully
Then I click on the triangle next to Product Information to collapse the section
And I scroll to the top of the page
And I should see the Subheading Product Information in the main window
And I should see the Subheading Alerts in the main window
And I should see the Subheading Announcements in the main window
And I should see the Subheading My Products in the products grid

# Checks that the correct items are showing when the section is expanded
Then I click on the triangle next to Product Information to expand the section
And I should see the Subheading Product Information expanded in the main window
And I should see the Subheading Alerts expanded in the main window
And I should see the Subheading Announcements expanded in the main window


Scenario: [63297] Add subscription to a new supplier through data entry
Given I define the user: 63297 with the following parameters:
| Field                | Value          |
| Email                | User_<random>  |
| Country              | UNITED STATES  |
| FirstName            | Richard        |
| LastName             | Smith          |
| Password             | Pa4*ytuufnn    |
| Address1             | Address 1      |
| Address2             | Address 2      |
| City                 | City Name      |
| State                | Florida        |
| Zip                  | 999            |
| CompanyName          | Company 1      |
| CompanyPhone         | 123-456-7889   |
| EmergencyPhoneNumber | 123-456-7789   |
| SupplierType         | Manufacturer   |
| CityQuestion         | CityQuestion   |
| CityHint             | CityHint       |
| CarQuestion          | CarQuestion    |
| CarHint              | CarHint        |
| FriendQuestion       | FriendQuestion |
| FriendHint           | FriendHint     |
| JobQuestion          | JobQuestion    |
| JobHint              | JobHint        |
| MascotQuestion       | MascotQuestion |
| MascotHint           | MascotHint     |
| Pin                  | 1234           |

Given I save the current emails in the inbox for user saved as: 63297
#Given I click on the New to WERCSmart Link
Given I select the Sign Up link
Then the signup page should appear
Given I enter signup email for user: 63297
And I confirm signup email for user: 63297
And I click on submit
Then the signup thank you page should appear
Then there should be a new email for user: 63297 from: <SiteNotification> with the title: Link to create WERCSmart Account
Then the email should contain a link to set up the WERCSmart account
When I click on the link I should see the WERCSmart new account page
And I enter the information into the new user form for user saved as: 63297
And In the new user form I click on continue
Then I should be on the Security Questions page of the form
And I enter the following into the Security Questions window for user saved as: 63297
And I enter the pin for user saved as: 63297
When In the new user form I click on continue
Given I go to the WERCSmart Log in
Given I login as user: 63297
Given If terms of use page appears I accept
Then the WERCSmart homepage should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase63297
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

# Subscription Enrollment - Section 1 Checks
Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
Then In the Subscription Enrollment screen I confirm that I see the following subheadings:
| Subheading                                                          |
| 1 Select the range of your products, articles and enhanced articles |
Then In the Subscription Enrollment screen I confirm that you see Formulated Products dropdown
And I check that the following are showing in the Formulated Products dropdown:
| Item                  |
| Choose...             |
| Up to 1 Product(s)    |
| Up to 3 Product(s)    |
| Up to 5 Product(s)    |
| Up to 6000 Product(s) |
And The Formulated Products popup should have header: What Are Formulated Products?
And The Formulated Products popup should have content: During the WERCSmart registration process, information about ingredients (e.g., water, ethanol, phosphoric acid) are collected.
Then In the Subscription Enrollment screen I confirm that the option showing in the Formulated Products dropdown is: Up to 1 Product(s)
Then In the Subscription Enrollment screen I confirm that you see Articles dropdown
And I check that the following are showing in the Articles dropdown:
| Item                  |
| Choose...             |
| Up to 1 Product(s)    |
| Up to 3 Product(s)    |
| Up to 5 Product(s)    |
| Up to 6000 Product(s) |
And The Articles popup should have header: What Are Articles?
And The Articles popup should have content: According to OSHA regulation 1910.1200, an article is “a manufactured item other than a fluid or particle: (i) which is formed to a specific shape or design during manufacture; (ii) which has end-use function(s) dependent in whole or in part upon its shape or design during end-use; and (iii) which under normal conditions of use does not release more than very small quantities, e.g., minute or trace amounts of a hazardous chemical (as determined under paragraph (d) of this section), and does not pose a physical hazard or health risk to employees.”
Then In the Subscription Enrollment screen I confirm that the option showing in the Articles dropdown is: Choose...
Then In the Subscription Enrollment screen I confirm that you see Enhanced Articles dropdown
And I check that the following are showing in the Enhanced Articles dropdown:
| Item                  |
| Choose...             |
| Up to 1 Product(s)    |
| Up to 3 Product(s)    |
| Up to 5 Product(s)    |
| Up to 6000 Product(s) |
And The Enhanced Articles popup should have header: What Are Enhanced Articles?
And The Enhanced Articles popup should have content: Beverage registrations or products that include a lithium battery when sold to the consumer (lithium ion or lithium metal) are considered Enhanced Articles for the purpose of WERCSmart registration.
Then In the Subscription Enrollment screen I confirm that the option showing in the Enhanced Articles dropdown is: Choose...

# Subscription Enrollment - Section 2 Checks
Then In the Subscription Enrollment screen I confirm that I see the following subheadings:
| Subheading                |
| 2 Select the feature plan |

Then In the Subscription Enrollment screen I confirm that I see the following Plans
| Plan Type | Plan Name    | Plan Subtext                                     | Best Value | Selected |
| Feature   | Premium      | STANDARD + UNLIMITED FEATURES                    | false      | false    |
| Feature   | Standard     | LIMITED PLUS + SUPPORT SERVICES                  | true       | true     |
| Feature   | Limited Plus | LIMITED + EXTRA FEATURES                         | false      | false    |
| Feature   | Limited      | BASIC FEATURES                                   | false      | false    |

And In the Subscription Enrollment screen I confirm that under the Premium Plan I see the following items and further details
| Item                                             | Further details                                                                                                                                                                                                                                                                                                                                                                                               |
| UL ECOLOGO Readiness Assessment                  | Recognized and referenced by more than 500 institutional procurement specifications, ECOLOGO Certification can increase market demand for your products. The ECOLOGO Certification readiness assessment evaluates the likelihood that your product can achieve certification to one of the ECOLOGO multi-attribute sustainability standards, and will expand to include other products such as personal care. |
| Product Assessment Preview                       | See important product assessment results 2-business days before they are passed on to the retailer! If there are questions about your results, you will have those 2-business days to inquire with UL’s regulatory experts on the following topics: waste, transportation, California proposition 65, VOC and fire codes.                                                                                     |
| Transportation Classification Regulatory Support | Avoid potential delays and pitfalls by relying on UL's regulatory experts to provide information and insights into your transportation classifications. You may be eligible for exemptions and exceptions that will save you money and get your products on the store shelves faster.                                                                                                                         |
| Waste Classification Regulatory Support          | Many retailers are now passing the costs of hazardous waste disposal on to manufacturers like you! Understanding hazardous waste classification requirements and the basis for your products classifications is more important than ever. Rely on UL's regulatory experts to review and provide guidance to minimize your costs.                                                                              |
| VOC Classification Regulatory Support            | Regulations around VOC are growing in size and complexity. Our regulatory experts will work with you to ensure your organizations products are compliant in the markets you serve.                                                                                                                                                                                                                            |
| Draft OSHA-Compliant Safety Data Sheet           | Elect to have an OSHA-compliant GHS Safety Data Sheet(SDS) in a UL-approved format for each of your active products.                                                                                                                                                                                                                                                                                         |

And In the Subscription Enrollment screen I confirm that under the Standard Plan I see the following items and further details
| Item                      | Further details                                                                                                                                                                                                                                                                                                                                           |
| Bronze Agent Support Plan | Enjoy the benefits of having a dedicated account agent, with technical expertise, to assist with answering questions related to product registrations, holds, re-certifications and updates. On the next screen, you will be able to upgrade to Silver or Gold Agent Support Services for additional data entry, advanced reporting and liaison services. |

And In the Subscription Enrollment screen I confirm that under the Limited Plus Plan I see the following items and further details
| Item                            | Further details                                                                                                                                                                                                                                                                                                                              | Link text  | Link url                  |
| PurView Sustainability Platform | In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform. | Learn More | https://www.ulpurview.com |

And In the Subscription Enrollment screen I confirm that under the Limited Plan I see the following items and further details
| Item                         | Further details                                                                                                                                                                                                                                                                                              |
| Product Registration         | Ensure your products meet the compliance requirements of over 40 retailers by submitting your product information in our secure software platform.                                                                                                                                                           |
| Update Registration          | As regulations change, so will your reporting obligations. These changes will also require product updates. With subscription, you now have the ability to update existing product data and submit revisions for assessment at no additional charge.                                                         |
| Add Retailer to Registration | As a WERCSmart subscriber, you will benefit from transmitting your product assessment with ease to over 40 retailers. As more retailers continue to join WERCSmart for their compliance and sustainability information, you can forward existing product registrations at any time for no additional charge. |
| UPC Management               | Add or remove UPCs efficiently and as needed from your existing product registrations at no additional charge.                                                                                                                                                                                               |

And The selected item in section: Select the feature plan should be: Standard

# Subscription Enrollment - Section 3 Checks

Then In the Subscription Enrollment screen I confirm that I see the following subheadings:
| Subheading                         |
| 3 Select the Support Services Plan |

Then under subheading Select the Support Services Plan I should see text: Bronze Agent Support Services is already included with Premium and Standard subscriptions. You can always have our greatest support services. Check out what we offer!
Then under subheading Select the Support Services Plan I should see hyperlink: (View Agency Service Agreement)
Then under subheading Select the Support Services Plan clicking on hyperlink: (View Agency Service Agreement) opens Agency Service Agreement popup
Then Agency Service Agreement popup contains the following text: By enrolling in Additional Support Service Options (Bronze, Silver or Gold), you, on behalf of the account holder (You) hereby authorize UL Information and Insights Inc. ("We" or "Us") to establish an Agent account in Your WERCSmart account for products entered, modified, or submitted for re-certification on your behalf (the "Products") and further appoint Us as Your designated agent ("Agent") with respect to such Products. You acknowledge that Agent shall have full authority in your WERCSmart account with respect to such Products as if it were You, including but not limited to, entering data, making any certifications required by the WERCSmart platform, and initiating, receiving and responding to any communications from us or any recipient of WERCSmart results. You further acknowledge that You remain responsible for Agent's actions or inactions with respect to such Products. You acknowledge that such authority shall continue until (i) You have withdrawn such authority by the submission of written notice of termination to use and (ii) We have acknowledged the receipt thereof. This Authorization constitutes an amendment to the WERCSmart Terms of Use posted on the WERCSmart site, as amended from time to time.
Then on the Agency Service Agreement popup clicking Close closes the popup

Then In the Subscription Enrollment screen I confirm that I see the following Plans
| Plan Type | Plan Name    | Plan Subtext                                     | Best Value | Selected |
| Support   | Gold         | SILVER + ADVANCED REPORTING AND LIAISON SERVICES | false      | false    |
| Support   | Silver       | BRONZE + WERCSMART DATA ENTRY FEATURES           | false      | false    |
| Support   | Bronze       | DIRECT PHONE + EMAIL SUPPORT                     | false      | true     |

Then In the Subscription Enrollment screen I confirm that under the Gold Plan I see the following items and further details
| Item                                                                                         |
| Product Process Tracking and Follow up                                                       |
| Unlimited VOC CAS Hold Waste/Hazard Battery & transportation                                 |
| Proactive Product Maintenance with Direct Retailer and WERCSmart Internal Team Communication |
| Advanced Notice Alerts of Retail Requirement Changes                                         |
| Active Monitoring and Direct Notification of Retail Requirement Changes                      |

Then In the Subscription Enrollment screen I confirm that under the Silver Plan I see the following items and further details
| Item                                                    |
| Data Registration Input from Start to Finish            |
| On-Hand Management of Holds Updates and Recertification |
| On-Demand UPC WPS ID and Status Reports                 |

And The selected item in section: Select the Support Services Plan should be: Bronze

Given I select feature plan: Limited Plus
Then In the Subscription Enrollment screen I confirm that I do see the following Plans:
| plan            |
| General Support |

Given I select feature plan: Limited
Then In the Subscription Enrollment screen I confirm that I do see the following Plans:
| plan            |
| General Support |

# Subscription Enrollment - Footer Checks

Then I should see following statement at the bottom Based on the above subscription plan setup, here are your estimated annual costs:
When I set the Formulated Products to be: Choose..., then the Annual Cost should be: $0.00
Then I should see Estimated Annual Cost per Product of: $0.00
Then I should see Proceed button disabled

When I set the Formulated Products to be: Up to 1 Product(s), then the Annual Cost should be: $407.88
And I set the Formulated Products to be: Up to 3 Product(s), then the Annual Cost should be: $1,112.40
Then I should see Proceed button enabled
And I click on the Proceed button
Then I click on Checkout
Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
Then In the Payment Methods screen I confirm the following payment options are available
| Options       |
| Credit Card   |
| ACH           |
| PayPal        |
| Wire Transfer |
Then In the Payment Methods screen I confirm that the Contact Information is correct for Account saved as 63297
Then In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as 63297
And In the Payment Methods screen I open the Edit Address form
Then I confirm the Edit Address form has the correct fields
| Field                     |
| First Name                |
| Last Name                 |
| Email Address             |
| Address 1                 |
| Address 2                 |
| City                      |
| State                     |
| Country                   |
| Zip Code                  |
| Phone Number              |
| Shipping/Billing Checkbox |
Then I cancel the Edit Address form
Then I edit the Billing Address for user saved as: 63297
# ** If field is not to be changed, enter <empty> into table **
| Address Line 1 | Address Line 2 | City    | State   | Zip Code | Country | Phone Number |
| Address_New    | <empty>        | <empty> | <empty> | <empty>  | <empty> | <empty>      |
And In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as 63297
Then In the Payment Methods screen I confirm the Continue Button is disabled
Then In the Payment Methods screen I select Payment Method: Credit Card
Then In the Payment Methods screen I confirm the Credit Card fields are correct
| Field           |
| Card Type       |
| Card Number     |
| Expiration Date |
| CVV             |
| Cardholder Name |
Then In the Payment Methods screen I select Payment Method: ACH
Then In the Payment Methods screen I confirm the ACH fields are correct
| Field               |
| ABA/Routing Number  |
| Bank Account Number |
| Account Type        |
| Bank Name           |
| Account Holder Name |
Then In the Payment Methods screen I select Payment Method: Wire Transfer
Then In the Payment Methods screen I confirm the following warning message appears: Wire Transfer subscription payment will result in the WERCSmart account being locked with regard to registration, UPC updates, and recertifications until funds are received and applied to the subscription balance due. No grace period for receipt of funds is provided for Wire Transfer payments. If you need immediate access to these functions, please select a different payment option before finalizing subscription.
Then In the Payment Methods screen I select Payment Method: PayPal
Then In the Payment Methods screen I confirm the following text message appears for PayPal: In order to successfully subscribe with PayPal, please click continue. When you click "Continue", you will be redirected to PayPal to establish the payment agreement.
Then In the Payment Methods screen I select Payment Method: Credit Card
Then In the Payment Methods screen I click Continue
Then In the Payment Methods screen I confirm Credit Card error messages for the following fields are displayed
| Field           |
| Card Number     |
| Expiration Date |
| CVV             |
| Cardholder Name |
Then In the Payment Methods screen I select Payment Method: ACH
Then In the Payment Methods screen I click Continue
Then In the Payment Methods screen I confirm ACH error messages for the following fields are displayed
| Field               |
| ABA/Routing Number  |
| Bank Account Number |
| Account Type        |
| Bank Name           |
| Account Holder Name |
Then In the Payment Methods screen I select Payment Method: Credit Card
Then In the Payment Methods screen I enter Credit Card details
| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
Then In the Payment Methods screen I click Continue
#Purchase Summary
Then In the Purchase Summary screen I check the Subscription Billing header is correct
Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
Then In the Purchase Summary screen I click Confirm Order
Then In the Thank You screen I check the Header is correct
Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 40 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
#Then In the Thank You screen I click Home
Given I click on My Account
Then In the My Account screen I navigate to the Subscription Information page
Then In the Subscription Information screen I confirm the Status has the correct information: 3 Formulated, 0 Articles, 0 Enhanced Articles
Then In the Subscription Information screen I confirm the Subscription History table has the correct information
| Subscription Level Status | Quantity |
| Limited Formulated        | 3        |
Given I click on My Account
Then In the My Account screen I navigate to the Order History page
Then In the Order History screen I select Subscription
Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: 63297


Scenario: [56475] VOC checks for Fabric Softener - single Use dryer product (RU000808)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fabric Softener - Single Use Dryer Product Only

Then I save the product information as: TestCase56475

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Formaldehyde

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page

Then I confirm that I see the following VOC-OTC-CARB statement1: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.

Then The following options should be displayed for section: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
| Option |
| Yes    |
| No     |

And in the New Product page I click Continue

Then Product has been granted an Alternative Control Plan should be showing the error messages: This is a required field.

Given I set the Product has been granted an Alternative Control Plan option to: No

Then I confirm that I see the following VOC-OTC-CARB statement2: Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.

Then I should see a total of 2 radio buttons for the section: Product does not contain more than 0.05 grams

Then The following options should be displayed for section: Product does not contain more than 0.05 grams
| Option   |
| Agree    |
| Disagree |

Given in the New Product page I click Continue

Then Product does not contain more than 0.05 grams of VOC per use should be showing the error messages: This is a required field.

Given I set the Product does not contain more than 0.05 grams of VOC per use option to: Disagree

Given in the New Product page I click Continue

# Confirm the VOC Summary page is NOT shown (because there are no results for show for this RU)

# If the Ecologo step is shown run the Shared Step below - if not continue at step 35

# Shared 57712

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Then I should see the Additional Documents to Provide Page

# Confirm the Volatile Organic Compounds - Product label document upload control is shown along with the TCLP file control updates
Then I see the following sections
| Section                                           |
| Volatile Organic Compounds                        |
| Toxicity Characteristic Leaching Procedure (TCLP) |

Given in the New Product page I click Continue

Then I should see an error message: Document is required: Product Label

Then Toxicity Characteristic Leaching Procedure (TCLP) should not be showing any error messages

Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Then I should see the Optional Reports and Documents Available for Purchase Page

Given in the New Product page I click Continue

Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page

Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Goggles                       | 500                      | 45                      | 15.0      | Black      | Odorless | No data available | 5                     |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fabric Softener - Single Use Dryer Product Only

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56475


Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Then I save the product information as: TestCase71051

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

And I should see the Pesticide Details - U.S. Page

And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 72315-6

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Given I update each Registration Number with the appended text '-edited'

Given in the New Product page I click Continue

And I should see the Transportation Details 1 Page

Then in the New Product page I click section: Pesticide Details - State Registration Details

And I should see the Pesticide Details - State Registration Details Page

Then I check each State Pesticide Registration Number contains the edited suffix

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I check each State Pesticide Registration Number contains the edited suffix

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase71051


Scenario: [62848] Pesticide Details - EPA Expiration Date is refresh from Kelly when the Update WERCSmart data link is used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
Then I save the product information as: TestCase62848
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
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


Scenario: [56476] VOC checks for Personal Fragrance product
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): more than 20% fragrance
Then I save the product information as: TestCase56476
Given I call Shared Step 70675 (Product Characteristics - Liquid Only - With Water Solubility - Enter all data - Continue)
Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Acetone
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
Then I see the following sections
| Section                                                                                                             |
| Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB |
Then I do not see the following sections
| Section                                                                                                                                                              |
| Amount of VOC content (as a weight percentage (%) of the total formulation) contained in this product, excluding exempt compounds, as defined by the OTC Model Rule. |
Given in the New Product page I click Continue
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 20
Given in the New Product page I click Continue
Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
Then I confirm that I see the following VOC-OTC-CARB statement4: Based on your selection, you have verified your product contains VOC with intended uses as follows. The CARB VOC compliance limit(s) for the intended use you identified is/are:
Given I call Shared Step 57819 (VOC Results - Confirm VOC Limits table shows correct values (CARB only) - Happy Path): Personal Fragrance Product (more than 20% fragrance)
And I confirm that I see the following VOC content as weight percentage for each state statement: VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.
Then I confirm that I see the following CARB value: 20
Then I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted CARB value: 20
Given in the New Product page I click Continue
Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should see the Additional Documents to Provide Page
Then I see the following sections
| Section                                           |
| Volatile Organic Compounds                        |
Given in the New Product page I click Continue
Then I should see an error message: Document is required: Product Label
Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf
Then I should see the Optional Reports and Documents Available for Purchase Page
Given in the New Product page I click Continue
Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Goggles                       | 200                      | 25                      | 12.2      | Black      | Odorless | No data available | 5                     |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (more than 20% fragrance)
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56476


Scenario: [56477] VOC checks for Charcoal lighter material (RU000743)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Charcoal Lighter Material
And In the Product Type tab of the New Product Page, I enter: Charcoal Lighter Material in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56477
And I should only see the following options for Primary Physical State:
| State |
| Liquid |

And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 2
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
Given in the New Product page I click Continue

# Transportation Details 2 Page
And I should see the Transportation Details 2 Page
And I set the International Shipping when DOT Exemption taken? option to: I do not ship internationally and I do not know the classification
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And I confirm that I see the following VOC Content below threshold CARB statement: Verify VOC content is below the threshold of 0.02lb/start of CARB
And I confirm that I see the following VOC Content below threshold OTC statement: Verify VOC content is below the threshold of 0.02lb/start of OTC
Given in the New Product page I click Continue
Then Verify VOC content is below the threshold of 0.02lb/start of CARB should be showing the error messages: This is a required field.
Then Verify VOC content is below the threshold of 0.02lb/start of OTC should be showing the error messages: This is a required field.
And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: No
Then Verify VOC content is below the threshold of 0.02lb/start of CARB should not be showing the error messages: This is a required field.
And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: No
Then Verify VOC content is below the threshold of 0.02lb/start of OTC should not be showing the error messages: This is a required field.
Given in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I should see the following Voc Limits with units  present:
| Use                       | VOC Compliance Limit | Units      | Regulation           |
| Charcoal Lighter Material | 0.02                 | lb / start | OTC Model rule limit |
| Charcoal Lighter Material | 0.02                 | lb / start | CARB limit           |
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm statement: limits specified by CARB shows the text: Exceeds the limits specified by CARB
And I confirm statement: limits specified by OTC shows the text: Exceeds the limits specified by OTC Model Rule

# Change the CARB  and OTC threshold options
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: Yes
And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: Yes
And in the New Product page I click Continue
And I confirm statement: limits specified by CARB shows the text: Does not exceed the limits specified by CARB
And I confirm statement: limits specified by OTC shows the text: Does not exceed the limits specified by OTC Model Rule
And in the New Product page I click Continue

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
And in the New Product page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
And in the New Product page I click Continue
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
And in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
And in the New Product page I click Continue

# Safety Data Sheet Authoring - Additional Data (Optional) Page
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 5
And in the New Product page I click Continue

# Comments Page
And I should see the Comments Page
And in the New Product page I click Continue

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56477


Scenario: [56481] VOC checks for Oven Cleaner - pump sprays (RU000798) - CARB and OTC

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Oven Cleaner - Pump Sprays

Then I save the product information as: TestCase56481

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Formaldehyde

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)

Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)

Then I see the following sections
| Section                                                                                                                      |
| Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB           |
| Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule |
| Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?                 |

Then The following options should be displayed for section: Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?
| Option                                                      |
| Yes                                                         |
| No, I would like to manually enter VOC value for each area. |

Given in the New Product page I click Continue

Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.

Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule should be showing the error messages: This is a required field.

Then Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? should be showing the error messages: This is a required field.

Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 40

Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should not be showing the error messages: This is a required field.

Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule option to: 5

Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule should not be showing the error messages: This is a required field.

Given I set the Would you like to use the VOC percentages option to: Yes

Then Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? should not be showing the error messages: This is a required field.

Given in the New Product page I click Continue

Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)

Then I confirm the VOC limits table has an entry for Regulation: CARB

Then I confirm the VOC limits table has an entry for Regulation: OTC

Then I should see data for States in the 'VOC Content as weight percentage of total formula' table

Then I confirm that I see the following CARB value: 40

Then I confirm that I see the following OTC Model Rule value: 5

Then I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.

And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted CARB value: 40

And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted OTC value: 5

Given in the New Product page I click Continue

# If your supplier account is on Premium subscription you will see the Ecologo step - perform the Shared Step below if you do, if not skip to step 43

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Then I should see the Additional Documents to Provide Page

Then I see the following sections
| Section                                           |
| Volatile Organic Compounds                        |

Given in the New Product page I click Continue

Then I should see an error message: Document is required: Product Label

Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Then I should see the Optional Reports and Documents Available for Purchase Page

Given in the New Product page I click Continue

Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page

Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                      | 100                      | 250                      | 1200      | Black      | Odorless | No data available | 50                     |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Then The Data Acceptance page should appear

Then In the Data Acceptance page I select Yes, Agreed

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Oven Cleaner - Pump Sprays

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56481

Scenario: [56483] VOC - Antiperspirant and Deodorant checks
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Antiperspirants - Non-aerosol
And In the Product Type tab of the New Product Page, I enter: Antiperspirants - Non-aerosol in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56483
And I should only see the following options for Primary Physical State:
| State |
| Liquid |
| Solid |
And I set the Primary Physical State option to: Solid
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water option to: No
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Regulatory 3 Page Details
And I should see the Regulatory Information 3 Page
And I set the below options for field: Refer to your Product Label
| Option            |
| None of the Above |
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Not Regulated
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And in the New Product page I click Continue
Then HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: This is a required field.
Then MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: This is a required field.
And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 1
And I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 1
And in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I should see the following Voc Limits present:
| Use                               | VOC Compliance Limit         | Regulation                                                    |
| Antiperspirants - Non-aerosol     | 0                         | HVOC CARB and OTC Model Rule limit                               |
| Antiperspirants - Non-aerosol     | 0                         | MVOC CARB and OTC Model Rule limit                               |
And I confirm that I see the following HVOC value: 1
And I confirm that I see the following MVOC value: 1
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm statement: limits specified shows the text: Exceeds the limits specified by CARB and OTC Model Rule

#change the HVOC and MVOC value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 0
And I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 0
And in the New Product page I click Continue
And I confirm statement: limits specified shows the text: Does not exceed the limits specified by CARB and OTC Model Rule

And in the New Product page I click Continue

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
And in the New Product page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
And in the New Product page I click Continue
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
And in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
And in the New Product page I click Continue

# Safety Data Sheet Authoring - Additional Data (Optional) Page
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 5
And in the New Product page I click Continue

# Comments Page
And I should see the Comments Page
And in the New Product page I click Continue

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56483


Scenario: [56484] VOC - Aero checks
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Clear Coating - Aerosol
And In the Product Type tab of the New Product Page, I enter: Clear Coating - Aerosol in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56484
And I should only see the following options for Primary Physical State:
| State |
| Aerosol |
And I set the Secondary Physical State option to: Solid spray
And I set the pH option to: 2
And I set the Select the best Water Solubility description option to: Very soluble
And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then option to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                           |
| DOT                              |
| Shipping with limited quantity   |
| Shipping with consumer commodity |
Given in the New Product page I click Continue

# U. S. Department of Transportation (DOT) Classification Page
Then I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number field to: UN1950
And I set the Proper Shipping Name field to: Aerosols
And I set the Technical Name (if applicable) field to: Clear Coating - Aerosol
And I set the Hazard Class (select) field to: 2.1
And I set the Packing Group (select) field to: None
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I confirm that I see the following VOC-OTC-CARB statement1: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
And I confirm that I see the following VOC-OTC-CARB statement3: VOC content in grams ozone per gram
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And in the New Product page I click Continue
Then VOC content in grams ozone per gram should be showing the error messages: This is a required field.
And I set the VOC content in grams ozone per gram field to: 0.5
And in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I confirm that I see the following VOC-OTC-CARB statement4: Based on your selection, you have verified your product contains VOC with intended uses as follows. The Aerosol Coatings by the CARB VOC compliance limit(s) for the intended use you identified is/are:
And I should see the following Voc Limits present:
| Use                         | VOC Compliance Limit         | Regulation                                                |
| Clear Coating - Aerosol     | 0.85                         | Aerosol Coatings CARB limit                               |
And I confirm that I see the following VOC Grams Ozone value: 0.5
And I confirm statement: limits specified shows the text: Does not exceed the limits specified in the Aerosol Coatings by the CARB
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.

#change the VOC grams value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the VOC content in grams ozone per gram field to: 1
And in the New Product page I click Continue
And I confirm statement: limits specified shows the text: Exceeds the limits specified in the Aerosol Coatings by the CARB
And in the New Product page I click Continue

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
And in the New Product page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
And in the New Product page I click Continue
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
And in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
And in the New Product page I click Continue

# Safety Data Sheet Authoring - Additional Data (Optional) Page
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 5
#And in the New Product page I click Continue
#Then Product's Dispensing Method should be showing the error messages: This is a required field.
And I set the Product's Dispensing Method field to: Pump
And in the New Product page I click Continue

# Comments Page
And I should see the Comments Page
And in the New Product page I click Continue

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56484


@tfs_design
Scenario: [56909] Retailer Detail Page - Retailer does not require Supplier ID but does require Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

# Retail Partners Page
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I select the retailer: Costco

# Retailer Detail Page
Then I should see the retailer heading: Costco
And I confirm that there is a section labeled: Your Supplier IDs
And Section: Your Supplier IDs should be showing text: This retailer does not support Supplier ID management
And I confirm that there is a section labeled: Data Consent Tiers
And I should see the button: What are the Data Usage Tiers? in section: Data Consent Tiers
And I should see the button: Products in Scope in section: Data Consent Tiers
And I confirm that there is a section labeled: Costco & You
And The pie chart should be showing on the retailer details page
And The pie chart footer text should contain: % of your product portfolio is associated with Costco


Scenario: [56914] Retailer Detail Page - Retailer requires Supplier ID and Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

# Retail Partners Page
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I select the retailer: Wal-Mart

# Retailer Detail Page
Then I should see the retailer heading: Wal-Mart/SAM'S CLUB
And I confirm that there is a section labeled: Your Supplier IDs
And The Supplier ID Table should be showing
And I confirm that there is a section labeled: Data Consent Tiers
And I should see the button: What are the Data Usage Tiers? in section: Data Consent Tiers
And I should see the button: Products in Scope in section: Data Consent Tiers
And I confirm that there is a section labeled: Wal-Mart/SAM'S CLUB & You
And The pie chart should be showing on the retailer details page
And The pie chart footer text should contain: % of your product portfolio is associated with Wal-Mart/SAM'S CLUB

@ProductSetUp
Scenario: [58753] Hair Color Kit - RU000724
Given I create a product and take to completed using Test Case 75335 and save as: 58753_KitProduct1
Given I navigate to the landing page
Given I create a product and take to completed using Test Case 75335 and save as: 58753_KitProduct2
Given I navigate to the landing page
Given I generate a random UPC number and save as: UPC58753
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
And I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 58753_KitProduct1 and product 2: 58753_KitProduct2)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58753, container type: Plastic Container and size: 100
And I should see the Additional Documents to Provide Page
And I click continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment Kit 58753
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
#And I The Purchase summary step is shown with the success message


Scenario: [70516] Add and Remove Packaging Type
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I click on My Account
Given In the My Account page I navigate to the My Library page
Then I confirm the current active tab on the My Library page is: My Packaging Types
Given I click 'Add New' in the My Packaging Types section of My Library
Then I should see the Packaging Type Page
Given I set the Package Type Name field to: Super Packaging Type (TM)
Given I click continue
Then I should see the Bill of Materials Page
And I save the Packaging Type details as: ThisPackaging
Given I click Add Row in the Bill Of Materials grid
Given I select the option: Clear Glass for the My Packaging Materials field in the table
Given I select the option: 99 for the My Packaging Weight (grams) field in the table
Given I click continue
Given In the Data Acceptance page I click on the Accept button
Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid
Given I delete Packaging Type saved as: ThisPackaging
Then I confirm the name and ID for Packaging Type saved as: ThisPackaging appear in the Delete Product pop up
Given I click Delete in the Delete Product pop up
And I confirm that the Packaging Type saved as: ThisPackaging does not appear in the My Packaging Types grid


Scenario: [63684] Walmart Private label product
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC63684
Given I delete all products with UPC Number: saved as UPC63684

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet shampoo

Then I save the product information as: TestCase63684

Given I call Shared Step 73629 (Product Characteristics - Liquid - select any options(enter pH, boiling point, flash point))
| Secondary Physical State | Specific Gravity | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Appreciable                                  |


Given I call Shared Step 63804 (Additional Product Information - enter options)
| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
| No                                                             | No                            | Yes                         | No                         |

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Cocoa butter  | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 65181 (Retailer Association - Add Private Label Information and Select Vendor ID) and select the retailer: Wal-Mart/SAM'S CLUB and enter the name: Holiday Time and select Vendor id: test

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC63684, container type: Plastic Container and size: 3.6

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Apron                         | 550                      | 63.625                  | 33.333    | Brown      | Banana | No data available | 30                    |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Pet shampoo

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63684

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\SHA Manager\Add to Recertification
# NetProjects10\WercsSmart Portal\Release Day Tests

@SHA
@51296
Scenario: [51296] Product in Assigned status - add to recertification
Given I create a product with name: TestCase51296 and take to completed using Test Case 75651 and save as: TestCase51296
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase51296)
And I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase51296
#And I Confirm the Product now shows with all details apart from the Product ID shown in RED font
And In the SHA Manager Grid I run a search for product saved as: TestCase51296 and its status is: Assigned
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase51296 and its font is red indicating a recertification
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase51296
#And I Confirm the Product Recertification History pop up shows
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                  |
| saved as TestCase51296 | true   | 20. Completed Product-Full Update (N/C) |
And I Close the Product Recertification History pop up
Given I navigate to the landing page
And I close any other windows with the same url
Given I navigate to the landing page
And I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
#And I call Shared Step 67284 (Login into WERCSmart Portal - Visual Automation Account)
And I call Shared Step 51352 - Products page - Filter for your product - Update Required link for product saved as: TestCase51296
#And I If you are using a ULSC registered supplier you will see the Re-Import data from ULSC services page - Select No, continue editing data and click Save
#And I The Product Type step is shown
And In the New Product page I click tab: Review and Submit
And in the New Product page I click section: Safety Data Sheet Authoring - Additional Data (Optional)
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 5
And I click Save in The Product Page
#And in the New Product page I click Continue
And in the New Product page I click section: Data Acceptance
#And I Confirm no errors are shown
And In the Data Acceptance page I click on the Accept button
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
#And I Confirm your product is shown with an entry for "Recertification"
#And I Confirm you see the SDS fee in the cart (as recert reason 20 has an SDS fee associated to it)
Given If purchase details are showing click confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase51296)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase51296 and its status is: Recertification
#And I Confirm your product is shown in the Recertification status without the red recertification font color
#And I Change the status drop down from ALL to RECERTIFICATION
And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase51296
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase51296)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase51296 and its status is: Assigned
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase51296
#And I Confirm the Product Recertification History pop up shows
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                  | Date                  |
| saved as TestCase84511 | false  | 20. Completed Product-Full Update (N/C) | Within a day of today |
#And I Confirm the entry you noted in step 37 not shows False in the Active column and contains a date/time under the date column


# Assigned to Beverly Barrett
# Created by Beverly Barrett
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\Release Day Tests
# NetProjects10\WercsSmart Portal\SHA Manager\Recertification - Process Recertification

@SHA
@42273
Scenario: [42273] Recertification > Process recertification > Process 1 product
#Given I If you do not have the test product in your account mentioned in the Description then use these two test cases
#to create a product and get it to the correct status:1. Use test case 75335 to create a new product and process it thru to
#Completed Status2. Use Test case 75410 to get the same product from Completed to Recertification
Given I create a product with name: 42273 and take to completed using Test Case 75335 and save as: TestCase42273
Given I take a product from completed to recertification using Test Case 75410 saved: TestCase42273
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase42273)
And In SHA Manager I set the filter for status to : Recertification
And In SHA Manager I select the first product saved as: TestCase42273
And I Click the Process Recertification button
And I Confirm the Recertification pop up is shown
And I Uncheck the Auto Assign Regulatory Specialist to Product check box
And I Select Automated QASha from the drop down list for Select Regulatory Specialist
And In the Recertification popup I click Continue
And In the Recertification popup the Continue button will no longer be shown
And in the Recertification popup I wait for all processing to be completed
And in the Recertification popup I should see the following products as successfully assigned
| ProductID              |
| saved as TestCase42273 |
And In the Recertification popup I click Continue
And I Confirm the Recertification pop up is closed
And In the SHA Manager Grid I run a search for product saved as: TestCase42273 and its status is: Assigned
#Automation can stop here.

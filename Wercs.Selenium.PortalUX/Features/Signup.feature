@SubEnrollment
@LandingPage
@PaymentMethods
@Login
@Homepage
@WERCSmart_Signup
@MyAccount
@NewProduct
@ProductGrid
@DataSummarySheet
@RetailPartners
@wercsmart
@run_Signup

Feature: Sign Up

Background:
Given I go to the WERCSmart Log in

Scenario: [53069] Signup - Account Creation - Happy Path
Given I define the user: SignupUser with the following parameters:
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

Given I save the current emails in the inbox for user saved as: SignupUser
Given I click on the New to WERCSmart Link
Then the signup page should appear
Given I enter signup email for user: SignupUser
And I confirm signup email for user: SignupUser
And I click on submit
Then the signup thank you page should appear
Then there should be a new email for user: SignupUser from: <SiteNotification> with the title: Link to create WERCSmart Account
Then the email should contain a link to set up the WERCSmart account
When I click on the link I should see the WERCSmart new account page
And I enter the information into the new user form for user saved as: SignupUser
And In the new user form I click on continue
Then I should be on the Security questions page of the form
And I enter the following into the Security Questions window for user saved as: SignupUser
And I enter the pin: for user saved as: SignupUser
When In the new user form I click on continue
Given I go to the WERCSmart Log in
Given I login as user: SignupUser
Given If terms of use page appears I accept
Then the WERCSmart homepage should load
Then I should see username for user saved as: SignupUser in the right corner

#pass - staging 4.10
Scenario: [52998] Signup - Emails Do Not Match
Given I click on the New to WERCSmart Link
Then the signup page should appear
And I click on submit
Then Under the Enter Email text box the following errors should appear
| Error text                |
| This is a required field. |
Then Under the Confirm Email text box the following errors should appear
| Error text                |
| This is a required field. |
Given I enter signup email: AnyOldUser@fake.com
And I confirm signup email: Different@fake.com
And I click on submit
Then Under the Enter Email text box the following errors should appear
| Error text                                  |
| Email and confirm email fields do not match |

#pass - staging 4.10
Scenario: [53000] Signup - Copy and Paste Email Address
Given I click on the New to WERCSmart Link
Then the signup page should appear
Given I enter signup email: AnyOldUser@fake.com
Given I copy the current value of the signup email
When I paste into confirm email: AnyOldUser@fake.com
Then I should see popup error: You cannot paste text into this textbox!
Given In the popup error I click on Cancel

Scenario: [57737] New Account - Required fields
Given I define the user: SignupUser2 with the following parameters:
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
| CompanyPhone         | 123-456-4789   |
| EmergencyPhoneNumber | 123-456-4789   |
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

Given I save the current emails in the inbox for user saved as: SignupUser2
Given I click on the New to WERCSmart Link
Then the signup page should appear
Given I enter signup email for user: SignupUser2
And I confirm signup email for user: SignupUser2
And I click on submit
Then the signup thank you page should appear
Then there should be a new email for user: SignupUser2 from: <SiteNotification> with the title: Link to create WERCSmart Account
Then the email should contain a link to set up the WERCSmart account
When I click on the link I should see the WERCSmart new account page
And In the new user form I click on continue
Then In the Country entry error I see error message: This is a required field.
Then In the First Name entry error I see error message: This is a required field.
Then In the Last Name entry error I see error message: This is a required field.
Then In the Password entry error I see error message: This is a required field.
Then In the Confirm Password entry error I see error message: This is a required field.
Then In the Address 1 entry error I see error message: This is a required field.
Then In the City entry error I see error message: This is a required field.
Then In the State entry error I see error message: This is a required field.
Then In the Zip entry error I see error message: This is a required field.
Then In the Company entry error I see error message: This is a required field.
Then In the Company Phone entry error I see error message: This is a required field.
Then In the Country Code entry error I see error message: This is a required field.
Then In the Emergency Phone Number entry error I see error message: This is a required field.
Then In the Supplier Type entry error I see error message: This is a required field.



And I enter the information into the new user form for user saved as: SignupUser
And In the new user form I click on continue
Then I should be on the Security questions page of the form
And I enter the following into the Security Questions window for user saved as: SignupUser
And I enter the pin: for user saved as: SignupUser
When In the new user form I click on continue
Given I go to the WERCSmart Log in
Given I login as user: SignupUser
Given If terms of use page appears I accept
Then the WERCSmart homepage should load
Then I should see username for user saved as: SignupUser in the right corner

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
Given I click on the New to WERCSmart Link
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
Then I should be on the Security questions page of the form
And I enter the following into the Security Questions window for user saved as: 63297
And I enter the pin: for user saved as: 63297
When In the new user form I click on continue
Given I go to the WERCSmart Log in
Given I login as user: 63297
Given If terms of use page appears I accept
Then the WERCSmart homepage should load

# Create the product
Given I generate a random UPC number and save as: UPC63684
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Chalk in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Chalk in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase63297
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State field to: Solid
And I set the When mixed with an equal amount of water field to: No
And I set the Select the best Water Solubility description field to: Appreciable
And in the New Product page I click Continue

# Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product is marketed for use by, or on, a child option to: No
And I set the Product has been classified using OSHA option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredients Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Retailers Page
Then In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product
And I should see the Retailer Page
Given in the New Product page I click Continue

# Regulatory Documents to Provide
And I should see the Regulatory Documents to Provide Page
And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
Then in the New Product page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the New Product page I click Continue

# Safety Data Sheet Authoring - Additional Data (Optional) Page
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And I set the below options for field: Personal Protection Equipment Recommended
| Option                         |
| Mask                           |
And I set the Autoignition Temperature (°C) field to: 20
And I set the Minimum Ignition Energy (mJ) field to: 20
And I set the Viscosity field to: 20
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 20
Then in the New Product page I click Continue

# Comments Page
And I should see the Comments Page
Then the comments field should appear
And I enter the following into the comments field: Comments Field Text
Given in the New Product page I click Continue

# Data Acceptance Page [Step 22]
And I should see the Data Acceptance Page
Given In the Data Acceptance page I select Yes, Agreed
Given In the Data Acceptance page I click on the Accept button

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
| Draft OSHA-Compliant Safety Data Sheet           | Effect to have an OSHA-compliant GHS Safety Data Sheet(SDS) in a UL-approved format for each of your active products.                                                                                                                                                                                                                                                                                         |

And In the Subscription Enrollment screen I confirm that under the Standard Plan I see the following items and further details
| Item                      | Further details                                                                                                                                                                                                                                                                                                                              |
| Bronze Agent Support Plan | In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform. |

And In the Subscription Enrollment screen I confirm that under the Limited Plus Plan I see the following items and further details
| Item                            | Further details                                                                                                                                                                                                                                                                                                                                           | Link text  | Link url                   |
| PurView Sustainability Platform | Enjoy the benefits of having a dedicated account agent, with technical expertise, to assist with answering questions related to product registrations, holds, re-certifications and updates. On the next screen, you will be able to upgrade to Silver or Gold Agent Support Services for additional data entry, advanced reporting and liaison services. | Learn More | https://www.ulpurview.com/ |

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
#Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 40 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
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

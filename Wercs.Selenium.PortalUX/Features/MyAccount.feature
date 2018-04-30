@Homepage
@Login
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods

@run_MyAccount

Feature: MyAccount

Scenario: [61796] Account User Name in Header
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then I should see username for user saved as: SignupUser in the right corner
Given I click on My Account
And I should see the heading: My Account on the My Account page
Given I save all the users in the User Grid
Given I go to Details in User Grid for the current user
Given In the UserDetails screen I save the current User as: ThisUser
Given In the UserDetails page I set Name to be: Richard Smith
Given In the UserDetails page I click Save
#Given I click Save in My Account
Then In the User Grid the user saved as: ThisUser has been replaced by: Richard Smith
Then I should see user name: Richard Smith in the header next to the user icon
Given I click on My Account
Given I go to Details in User Grid for the current user
Given In the UserDetails page I set Name to be: saved as ThisUser

Scenario: [63514] Create a New User on the User Grid
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Given I click on My Account
Then I create a new email address
Then I add a new user with the following information
| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
Then I confirm the new user is Active

Scenario: [59245] Add subscription to a new supplier from My account
Given I go to the WERCSmart Log in
Given If not already created, I create a user: New_Sub with the following parameters:
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
Given I click on My Account
Then I click on NEW SUBSCRIPTION
Then In the Subscription Enrollment screen I select the following enrollment options
| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
| Up to 1 Product(s) | Up to 1 Product(s) | Up to 1 Product(s)  | Limited      | General Support       |
Then I cancel the Enrollment dialog, confirm correct page opens and Proceed
And I confirm the chosen options and body text are correct
| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan | Body Text                                                                                                                            |
| Up to 1 Product(s) | Up to 1 Product(s) | Up to 1 Product(s)  | Limited      | General               | Your new purchase will be prorated based on the credit and time left in your current subscription. Checkout to see the final amount. |
Then I click on Checkout
Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
Then In the Payment Methods screen I confirm the following payment options are available
| Options       |
| Credit Card   |
| ACH           |
| Wire Transfer |
Then In the Payment Methods screen I confirm that the Contact Information is correct for Account saved as New_Sub
Then In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as New_Sub
And In the Payment Methods screen I open the Edit Address form
Then I confirm the Sub Headings are correct: Primary Account Contact, Billing Address
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
Then I un-check the Shipping Address is the same as the billing address checkbox
And I confirm the Shipping Address form has the correct fields
| Field                     |
| Address 1                 |
| Address 2                 |
| City                      |
| State                     |
| Country                   |
| Zip Code                  |
| Phone Number              |
Then I check the Shipping Address is the same as the billing address checkbox
Then I confirm the Shipping Address is hidden
Then I cancel the Edit Address form
Then I edit the Billing Address for user saved as: New_Sub
# ** If field is not to be changed, enter <empty> into table **
| Address Line 1 | Address Line 2 | City    | State   | Zip Code | Country | Phone Number |
| Address_New    | <empty>        | <empty> | <empty> | <empty>  | <empty> | <empty>      |
And In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as New_Sub
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
Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Purchase Summary screen I check the Subscription Billing header is correct
Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
Then In the Purchase Summary screen I click Confirm Order
Then In the Thank You screen I check the Header is correct
#Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 40 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
Then In the Thank You screen I click Home
Given I click on My Account
Then In the My Account screen I navigate to the Subscription Information page
Then In the Subscription Information screen I confirm the Status has the correct information: 1 Formulated, 1 Articles, 1 Enhanced Articles
Then In the Subscription Information screen I confirm the Subscription History table has the correct information
| Row | Subscription Level Status | Quantity |
| 1   | Limited Formulated        | 1        |
| 2   | Limited Articles          | 1        |
| 3   | Limited Enhanced Articles | 1        |
Given I click on My Account
Then In the My Account screen I navigate to the Order History page
Then In the Order History screen I select Subscription
Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: New_Sub

Scenario: [67822] New subscription to a new supplier from My account - Visual Checks
#This test requires a new master account in  wercsmart without any subscription
Given I go to the WERCSmart Log in
Given If not already created, I create a user: New_VC with the following parameters:
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
#Login to WERCSmart Portal - Visaul Automation Account
Given I click on My Account
Then I click on NEW SUBSCRIPTION
Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
Then In the Subscription Enrollment screen I confirm that I see the following subheadings:
| Subheading                                                          |
| 1 Select the range of your products, articles and enhanced articles |
| 2 Select the feature plan                                           |
| 3 Select the Support Services Plan                                  |

Then In the Subscription Enrollment screen I confirm that you see Articles dropdown
Then In the Subscription Enrollment screen I confirm that when you hover over (i) for Articles you see following heading: What Are Articles?
Then In the Subscription Enrollment screen I confirm that when you hover over (i) for Articles you see following statement: According to OSHA regulation 1910.1200, an article is “a manufactured item other than a fluid or particle: (i) which is formed to a specific shape or design during manufacture; (ii) which has end-use function(s) dependent in whole or in part upon its shape or design during end-use; and (iii) which under normal conditions of use does not release more than very small quantities, e.g., minute or trace amounts of a hazardous chemical (as determined under paragraph (d) of this section), and does not pose a physical hazard or health risk to employees.”
Then In the Subscription Enrollment screen I confirm that the option showing in the Articles dropdown is: Choose...
Then In the Subscription Enrollment screen I confirm that you see Enhanced Articles dropdown
Then In the Subscription Enrollment screen I confirm that when you hover over (i) for Enhanced Articles you see following heading: What Are Enhanced Articles?
Then In the Subscription Enrollment screen I confirm that when you hover over (i) for Enhanced Articles you see following statement: Beverage registrations or products that include a lithium battery when sold to the consumer (lithium ion or lithium metal) are considered Enhanced Articles for the purpose of WERCSmart registration.
Then In the Subscription Enrollment screen I confirm that the option showing in the Enhanced Articles dropdown is: Choose...
Then In the Subscription Enrollment screen I confirm that you see Formulated Products dropdown
Then In the Subscription Enrollment screen I confirm that when you hover over (i) for Formulated Products you see following heading: What Are Formulated Products?
Then In the Subscription Enrollment screen I confirm that when you hover over (i) for Enhanced Articles you see following statement: During the WERCSmart registration process, information about ingredients (e.g., water, ethanol, phosphoric acid) are collected.
Then In the Subscription Enrollment screen I confirm that the option showing in the Formulated Products dropdown is: Choose...
Then In the Subscription Enrollment screen I confirm that I see the following Plans
| Plan Type | Plan Name    | Plan Subtext                                     | Best Value | Selected |
| Feature   | Premium      | STANDARD + UNLIMITED FEATURES                    | false      | false    |
| Feature   | Standard     | LIMITED PLUS + SUPPORT SERVICES                  | true       | true     |
| Feature   | Limited Plus | LIMITED + EXTRA FEATURES                         | false      | false    |
| Feature   | Limited      | BASIC FEATURES                                   | false      | false    |
| Support   | Gold         | SILVER + ADVANCED REPORTING AND LIAISON SERVICES | false      | false    |
| Support   | Silver       | BRONZE + WERCSMART DATA ENTRY FEATURES           | false      | false    |
| Support   | Bronze       | DIRECT PHONE + EMAIL SUPPORT                     | false      | true     |

Then In the Subscription Enrollment screen I confirm that under the Premium Plan I see the following items and further details
| Item                                             | Further details                                                                                                                                                                                                                                                                                                                                                                                               |
| UL ECOLOGO Readiness Assessment                  | Recognized and referenced by more than 500 institutional procurement specifications, ECOLOGO Certification can increase market demand for your products. The ECOLOGO Certification readiness assessment evaluates the likelihood that your product can achieve certification to one of the ECOLOGO multi-attribute sustainability standards, and will expand to include other products such as personal care. |
| Product Assessment Preview                       | See important product assessment results 2-business days before they are passed on to the retailer! If there are questions about your results, you will have those 2-business days to inquire with UL’s regulatory experts on the following topics: waste, transportation, California proposition 65, VOC and fire codes.                                                                                     |
| Transportation Classification Regulatory Support | Avoid potential delays and pitfalls by relying on UL's regulatory experts to provide information and insights into your transportation classifications. You may be eligible for exemptions and exceptions that will save you money and get your products on the store shelves faster.                                                                                                                         |
| Waste Classification Regulatory Support          | Many retailers are now passing the costs of hazardous waste disposal on to manufacturers like you! Understanding hazardous waste classification requirements and the basis for your products classifications is more important than ever. Rely on UL's regulatory experts to review and provide guidance to minimize your costs.                                                                              |
| VOC Classification Regulatory Support            | Regulations around VOC are growing in size and complexity. Our regulatory experts will work with you to ensure your organizations products are compliant in the markets you serve.                                                                                                                                                                                                                            |
| Draft OSHA-Compliant Safety Data Sheet           | Effect to have an OSHA-compliant GHS Safety Data Sheet(SDS) in a UL-approved format for each of your active products.                                                                                                                                                                                                                                                                                         |
#Click the i next to UL ECOLOGO Readiness Assessment
#Confirm the eco text is no longer visible.
Then In the Subscription Enrollment screen I confirm that under the Standard Plan I see the following items and further details
| Item                      | Further details                                                                                                                                                                                                                                                                                                                              |
| Bronze Agent Support Plan | In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform. |

Then In the Subscription Enrollment screen I confirm that under the Limited Plus Plan I see the following items and further details
| Item                            | Further details                                                                                                                                                                                                                                                                                                                                           |
| PurView Sustainability Platform | Enjoy the benefits of having a dedicated account agent, with technical expertise, to assist with answering questions related to product registrations, holds, re-certifications and updates. On the next screen, you will be able to upgrade to Silver or Gold Agent Support Services for additional data entry, advanced reporting and liaison services. |

#Confirm that you see following statement under Limited Plus "PurView Sustainability Platform"
#Click the i next to PurView Sustainability Platform
#Confirm that the following statement displays "
#Learn More"
#Also confirm that when you click Learn More link it takes you to "https://www.ulpurview.com/"
# Click the Learn More link
#confirm that you go to "https://www.ulpurview.com/"  in a new tab
#Close Purview tab

Then In the Subscription Enrollment screen I confirm that under the Limited Plan I see the following items and further details
| Item                         | Further details                                                                                                                                                                                                                                                                                              |
| Product Registration         | Ensure your products meet the compliance requirements of over 40 retailers by submitting your product information in our secure software platform.                                                                                                                                                           |
| Update Registration          | As regulations change, so will your reporting obligations. These changes will also require product updates. With subscription, you now have the ability to update existing product data and submit revisions for assessment at no additional charge.                                                         |
| Add Retailer to Registration | As a WERCSmart subscriber, you will benefit from transmitting your product assessment with ease to over 40 retailers. As more retailers continue to join WERCSmart for their compliance and sustainability information, you can forward existing product registrations at any time for no additional charge. |
| UPC Management               | Add or remove UPCs efficiently and as needed from your existing product registrations at no additional charge.                                                                                                                                                                                               |


#Confirm that you see following sub heading  ""
#Confirm that you see the following statement : "Bronze Agent Support Services is already included with Premium and Standard subscriptions. You can always have our greatest support services. Check out what we offer!"
#Click the hyperlink "View Agency Service Agreement"
#Confirm that a popup displays with following heading "View Agency Service Agreement"
#Confirm that you see the following statement: "By enrolling in Additional Support Service Options (Bronze, Silver or Gold), you, on behalf of the account holder (You) hereby authorize UL Information and Insights Inc. ("We" or "Us") to establish an Agent account in Your WERCSmart account for products entered, modified, or submitted for re-certification on your behalf (the "Products") and further appoint Us as Your designated agent ("Agent") with respect to such Products. You acknowledge that Agent shall have full authority in your WERCSmart account with respect to such Products as if it were You, including but not limited to, entering data, making any certifications required by the WERCSmart platform, and initiating, receiving and responding to any communications from us or any recipient of WERCSmart results. You further acknowledge that You remain responsible for Agent's actions or inactions with respect to such Products. You acknowledge that such authority shall continue until (i) You have withdrawn such authority by the submission of written notice of termination to use and (ii) We have acknowledged the receipt thereof. This Authorization constitutes an amendment to the WERCSmart Terms of Use posted on the WERCSmart site, as amended from time to time."
#click Close on View Agency Service Agreement popup
#subscription enrollment screen
#Confirm that you see "Gold" radio option under  3.Select the Support Services Plan
#Confirm that you see following statement under Gold ""

Then In the Subscription Enrollment screen I confirm that under the Gold Plan I see the following items and further details
| Item                                                                                         | Further details |
| Product Process Tracking and Follow up                                                       |                 |
| Unlimited VOC CAS Hold Waste/Hazard Battery & transportation                                 |                 |
| Proactive Product Maintenance with Direct Retailer and WERCSmart Internal Team Communication |                 |
| Advanced Notice Alerts of Retail Requirement Changes                                         |                 |
| Active Monitoring and Direct Notification of Retail Requirement Changes                      |                 |

Then In the Subscription Enrollment screen I confirm that under the Silver Plan I see the following items and further details
| Item                                                    | Further details |
| Data Registration Input from Start to Finish            |                 |
| On-Hand Management of Holds Updates and Recertification |                 |
| On-Demand UPC WPS ID and Status Reports                 |                 |

#Confirm that you see "Bronze" radio option under  3.Select the Support Services Plan
#In Section 2 select Limited Plus

#Bronze option only displays when Standard and Premium is selected for 2.Select the Feature Plan
#Confirm that in Section 3 you now see General Support instead of Bronze

#In Section 2 select Premium

Then In the Subscription Enrollment screen I confirm that under the Bronze Plan I see the following items and further details
| Item                                                                                                                | Further details |
| Agent Guided Basic Account Management Like Account Creation & Update Holds & Recertification Mergers & Acquisitions |                 |


#Confirm that you see following statement at the bottom "Based on the above subscription plan setup, here are your estimated annual costs:"
#Confirm that you see following statement at the bottom "Estimated Annual Cost: $0.00 "
#Confirm that you see following statement at the bottom  "Estimated Annual Cost per Product: $0.00"
#Confirm that "Proceed" button at bottom is disabled when number of products is not selected

Scenario: [64874] Division Area
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
And I navigate to My Account
And I click on the option Division Accounts

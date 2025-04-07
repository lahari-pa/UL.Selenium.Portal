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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@SubUpgrade
@ProductSetUp
@SubEnrollmentNew
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@StepsPrototype
@run_Subscription
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65

@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
Feature: Subscription

#@ignore
@TestCase:63297
Scenario: [63297] Add subscription to a new supplier through data entry
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC63297User with the following parameters:
		| Field                | Value          |
		| Email                | User_<random>  |
		| Country              | UNITED STATES  |
		| FirstName            | WERCS          |
		| LastName             | Test_Automatio |
		| Password             | Welcome1!      |
		| Address1             | Address 1      |
		| Address2             | Address 2      |
		| City                 | Latham         |
		| State                | New York       |
		| Zip                  | 12110          |
		| CompanyName          | Company 1      |
		| CompanyPhone         | 123-456-7889   |
		| EmergencyPhoneNumber | 123-456-7789   |
		| SupplierType         | Manufacturer   |
		| PhoneQuestion        | PhoneQuestion  |
		| PhoneHint            | PhoneHint      |
		| MentorQuestion       | MentorQuestion |
		| MentorHint           | MentorHint     |
		| FriendQuestion       | FriendQuestion |
		| FriendHint           | FriendHint     |
		| AnimalQuestion       | AnimalQuestion |
		| AnimalHint           | AnimalHint     |
		| CollegeQuestion      | CollegeQuestion|
		| CollegeHint          | CollegeHint    |
		| Pin                  | 1234           |
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase63297
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue


#	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button


	# Subscription Enrollment - Section 1 Checks
	Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
	And In the Subscription Enrollment page, I confirm an alert message with the text: Subscription enrollment is required to submit your registration for assessment. Please enroll at this time. Once you purchase your subscription, the registration data will transfer for assessment.
	Then I confirm the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Formulated Products panel drop down does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated Products panel, I confirm the following selector options do exist:
		| Option                |
		| Choose...             |
		| Up to 1 Product(s)    |
		| Up to 3 Product(s)    |
		| Up to 5 Product(s)    |
		| Up to 6000 Product(s) |
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated Products panel, I confirm the Up to 1 Product(s) selector option is selected
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Articles panel drop down does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Articles panel, I confirm the following selector options do exist:
		| Option                |
		| Choose...             |
		| Up to 1 Product(s)    |
		| Up to 3 Product(s)    |
		| Up to 5 Product(s)    |
		| Up to 6000 Product(s) |
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Articles panel, I confirm the Choose... selector option is selected
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Enhanced Articles panel drop down does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Enhanced Articles panel, I confirm the following selector options do exist:
		| Option                |
		| Choose...             |
		| Up to 1 Product(s)    |
		| Up to 3 Product(s)    |
		| Up to 5 Product(s)    |
		| Up to 6000 Product(s) |
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Enhanced Articles panel, I confirm the Choose... selector option is selected

	# Subscription Enrollment - Section 2 Checks
	Then I confirm the Select a subscription plan section does exist
	Then In the Select a subscription plan section, I confirm the Limited panel does exist
	Then In the Select a subscription plan section Limited panel, I confirm the Best Value footer does not exist
	Then In the Select a subscription plan section Limited panel, I confrim the radio is not selected
	Then In the Select a subscription plan section, I confirm the Standard panel does exist
	Then In the Select a subscription plan section Standard panel, I confirm the Best Value footer does exist
	Then In the Select a subscription plan section Standard panel, I confrim the radio is selected
	Then In the Select a subscription plan section, I confirm the Premium panel does exist
	Then In the Select a subscription plan section Premium panel, I confirm the Best Value footer does not exist
	Then In the Select a subscription plan section Premium panel, I confrim the radio is not selected
	Then In the Select a subscription plan section, I confirm the Limited panel does exist
	Then In the Select a subscription plan section Limited panel, I confirm the list contains: Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area displays: Ensure your products meet the compliance requirements of over 50 retailers by submitting your product information in our secure software platform. Revise your registrations to comply with ever-changing regulations and requirements. Over 50 participating recipients of Assessment data is managed in one place, with ease.
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Limited panel, I confirm the list contains: PurView Catalog Access
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area displays: In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform.
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the Learn More link
	Then I confirm https://www.ulpurview.com/ tab does exist
	Then I close the https://www.ulpurview.com/ tab
	Then I confirm https://www.ulpurview.com/ tab does not exist
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section, I confirm the Standard panel does exist
	Then In the Select a subscription plan section Standard panel, I confirm the list contains: Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area displays: Ensure your products meet the compliance requirements of over 50 retailers by submitting your product information in our secure software platform. Revise your registrations to comply with ever-changing regulations and requirements. Over 50 participating recipients of Assessment data is managed in one place, with ease.
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Limited panel, I confirm the list contains: PurView Catalog Access
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area displays: In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform.
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the Learn More link
	Then I confirm https://www.ulpurview.com/ tab does exist
	Then I close the https://www.ulpurview.com/ tab
	Then I confirm https://www.ulpurview.com/ tab does not exist
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Standard panel, I confirm the list contains: Bronze Agent Support Services - direct phone and email support
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I click the info button
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I confrim the info text area displays: Enjoy the benefits of having a dedicated account agent, with technical expertise, to assist with answering questions related to product registrations, holds, re-certifications and updates. On the next screen, you will be able to upgrade to Silver or Gold Agent Support Services for additional data entry, advanced reporting and liaison services.
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I click the info button
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Standard panel, I confirm the Best Value footer does exist
	Then In the Select a subscription plan section, I confirm the Premium panel does exist
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: Includes STANDARD features, plus
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: Regulatory Support - transportation, waste, VOC classifications
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I click the info button
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area displays: Transportation – Avoid potential delays and pitfalls by relying on UL’s regulatory experts to provide information and insights into your transportation classifications. You may be eligible for exemptions and exceptions that will save you money and get your products on the store shelves faster.
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area displays: Waste – Many retailers are now passing the costs of regulated waste disposal on to manufacturers like you! Understanding regulated waste classification requirements and the basis for your products classifications is more important than ever. Rely on UL’s regulatory experts to review and provide guidance to minimize your costs.
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area displays: VOC – Regulations around VOC are growing in size and complexity. Our regulatory experts will work with you to ensure your organizations products are compliant in the markets you serve.
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I click the info button
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: UL ECOLOGO Readiness Assessment
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I click the info button
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I confrim the info text area displays: Recognized and referenced by more than 500 institutional procurement specifications, ECOLOGO Certification can increase market demand for your products.  The ECOLOGO Certification readiness assessment evaluates the likelihood that your product can achieve certification to one of the ECOLOGO multi-attribute sustainability standards, and will expand to include other products such as personal care.
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I click the info button
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: Draft OSHA-Compliant Safety Data Sheet
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I click the info button
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I confrim the info text area displays: Elect to have an OSHA-compliant GHS Safety Data Sheet(SDS) in a UL-approved format for each of your active products.
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I click the info button
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I confrim the info text area is not displayed

	# Subscription Enrollment - Section 3 Checks

	Then I confirm the Select an Agent Support Service Plan [optional] section does exist
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the text area displays: Personalized Agent Support Services are available to provide options for quality, dependable assistance ranging from direct phone access - to data entry - to advanced reporting and liaison services.
	Then In the Select an Agent Support Service Plan [optional] section text area, I click on the View Agent Support Service Agreement link
	Then I confirm the Agency Service Agreement modal is displayed
	Then In the Agency Service Agreement modal, I confirm the title displays: Agency Service Agreement
	Then In the Agency Service Agreement modal, I confirm the body text displays: By enrolling in Additional Support Service Options (Bronze, Silver or Gold), you, on behalf of the account holder (You) hereby authorize UL Information and Insights Inc. ("We" or "Us") to establish an Agent account in Your WERCSmart account for products entered, modified, or submitted for re-certification on your behalf (the "Products") and further appoint Us as Your designated agent ("Agent") with respect to such Products. You acknowledge that Agent shall have full authority in your WERCSmart account with respect to such Products as if it were You, including but not limited to, entering data, making any certifications required by the WERCSmart platform, and initiating, receiving and responding to any communications from us or any recipient of WERCSmart results. You further acknowledge that You remain responsible for Agent's actions or inactions with respect to such Products. You acknowledge that such authority shall continue until (i) You have withdrawn such authority by the submission of written notice of termination to use and (ii) We have acknowledged the receipt thereof. This Authorization constitutes an amendment to the WERCSmart Terms of Use posted on the WERCSmart site, as amended from time to time.
	Then In the Agency Service Agreement modal, I click the Close button
	Then I confirm the Agency Service Agreement modal is not displayed
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the Bronze Level Support panel does exist
	Then In the Select an Agent Support Service Plan [optional] section Bronze Level Support panel, I confirm the list contains: Direct phone and email support. Agent-guided basic account management (i.e. account creation & updates, holds & re-certifications, mergers & acquisitions)
	Then In the Select an Agent Support Service Plan [optional] section Bronze Level Support panel, I confirm the Best Value footer does not exist
	Then In the Select an Agent Support Service Plan [optional] section Bronze Level Support panel, I confrim the radio is selected

	Then In the Select an Agent Support Service Plan [optional] section, I confirm the Silver Agent Support panel does exist
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the list contains: Data Registration Input from Start to Finish
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the list contains: On-Hand Management of Holds Updates and Recertification
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the list contains: On-Demand UPC WPS ID and Status Reports
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the Best Value footer does not exist
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confrim the radio is not selected

	Then In the Select an Agent Support Service Plan [optional] section, I confirm the Gold Agent Support panel does exist
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Product Process Tracking and Follow up
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Unlimited VOC CAS Hold Waste/Hazard Battery & transportation
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Proactive Product Maintenance with Direct Retailer and WERCSmart Internal Team Communication
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Advanced Notice Alerts of Retail Requirement Changes
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Active Monitoring and Direct Notification of Retail Requirement Changes
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the Best Value footer does not exist
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confrim the radio is not selected
	Given In the Select a subscription plan section Limited panel, I click the radio button
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the No additional Agent Support Service panel does exist
	Then In the Select an Agent Support Service Plan [optional] section No additional Agent Support Service panel, I confirm the panel sub label text is: I choose to only use the services that come with my Subscription Plan
	Then In the Select an Agent Support Service Plan [optional] section No additional Agent Support Service panel, I confirm the text area containins: If you are a LIMITED subscriber and would like Bronze Agent Support, please select STANDARD as your chosen Subscription Plan.

	# Confirm Final Selections
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated Products panel, I confirm the Up to 1 Product(s) selector option is selected
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Enhanced Articles panel, I confirm the Choose... selector option is selected
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Articles panel, I confirm the Choose... selector option is selected
	Then In the Select a subscription plan section Limited panel, I confrim the radio is selected
	Then In the Select an Agent Support Service Plan [optional] section No additional Agent Support Service panel, I confrim the radio is selected

	# Subscription Enrollment - Footer Checks

	Then I confrim the Your Total footer exists and displays the text: Based on the above selected items, your estimated Subscription Plan total, excluding sales tax, is:
	Then In the enrollment footer, I confirm the Estimated Annual Cost calculator displayes: $454.00
	Then In the enrollment footer, I confirm the Estimated Annual Cost per Product calculator displayes: $454.00
	Then In the enrollment footer, I click the PROCEED button
	Then In the Subscription Enrollment Modal, I click the Checkout button
	Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
	Then In the Payment Methods screen I confirm the following payment options are available
		| Options       |
		| Credit Card   |
		| ACH           |
		| PayPal        |
		| Wire Transfer |
	Then In the Payment Methods screen I confirm that the Contact Information is correct for Account saved as TC63297User
	Then In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as TC63297User
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
	Then I edit the Billing Address for user saved as: TC63297User
	# ** If field is not to be changed, enter <empty> into table **
		| Address Line 1 | Address Line 2 | City    | State   | Zip Code | Country | Phone Number |
		| Address_New    | <empty>        | <empty> | <empty> | <empty>  | <empty> | <empty>      |
	And In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as TC63297User
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
	#Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
	Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
	Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
	Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars and applicable sales tax will be reflected on your final invoice based on your billing location. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
	Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan.  You’ve successfully submitted your first registration for assessment!
	Then In the Thank You screen I confirm the following statement is shown: What happens now?  Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage.  The assessment process takes about two (2) business days to finalize and then is transferred to your recipient.  Your product’s registration data remains in our database.
	Then In the Thank You screen I confirm the following statement is shown: The UL WERCSmart team works with you to provide over 45 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe.  UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service.  Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
	#Then In the Thank You screen I click Home
	Given I click on My Account
	Then In the My Account screen I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm the Status has the correct information: 1 Formulated, 0 Articles, 0 Enhanced Articles
	Then In the Subscription Information screen I confirm the Subscription History table has the correct information
		| Subscription Level Status | Quantity |
		| Formulated                | 1        |
	Given I click on My Account
	Then In the My Account screen I navigate to the Order History page
	Then In the Order History screen I select Subscription
	# Uncomment when emailing issue is fixed
	#Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: TC63297User

@ignore
@TestCase:59245
Scenario: [59245] Add subscription to a new supplier from My account
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC59245User with the following parameters:
		| Field                | Value           |
		| Email                | User_<random>   |
		| Country              | UNITED STATES   |
		| FirstName            | Richard         |
		| LastName             | Smith           |
		| Password             | Pa4*ytuufnn     |
		| Address1             | Address 1       |
		| Address2             | Address 2       |
		| City                 | City Name       |
		| State                | Florida         |
		| Zip                  | 999             |
		| CompanyName          | Company 1       |
		| CompanyPhone         | 123-456-7889    |
		| EmergencyPhoneNumber | 123-456-7789    |
		| SupplierType         | Manufacturer    |
		| PhoneQuestion        | PhoneQuestion   |
		| PhoneHint            | PhoneHint       |
		| MentorQuestion       | MentorQuestion  |
		| MentorHint           | MentorHint      |
		| FriendQuestion       | FriendQuestion  |
		| FriendHint           | FriendHint      |
		| AnimalQuestion       | AnimalQuestion  |
		| AnimalHint           | AnimalHint      |
		| CollegeQuestion      | CollegeQuestion |
		| CollegeHint          | CollegeHint     |
		| Pin                  | 1234            |
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
	Then In the Payment Methods screen I confirm that the Contact Information is correct for Account saved as TC59245User
	Then In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as TC59245User
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
	Then I edit the Billing Address for user saved as: TC59245User
	# ** If field is not to be changed, enter <empty> into table **
		| Address Line 1 | Address Line 2 | City    | State   | Zip Code | Country | Phone Number |
		| Address_New    | <empty>        | <empty> | <empty> | <empty>  | <empty> | <empty>      |
	And In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as TC59245User
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
	#Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 45 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
	Then In the Thank You screen I click Home
	Given I click on My Account
	Then In the My Account page I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm the Status has the correct information: 1 Formulated, 1 Articles, 1 Enhanced Articles
	Then In the Subscription Information screen I confirm the Subscription History table has the correct information
		| Subscription Level Status | Quantity |
		| Limited Formulated        | 1        |
		| Limited Articles          | 1        |
		| Limited Enhanced Articles | 1        |
	Given I click on My Account
	Then In the My Account page I navigate to the Order History page
	Then In the Order History screen I select Subscription
	Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: TC59245User

#@ignore
@TestCase:67822
Scenario: [67822] New subscription to a new supplier from My account - Visual Checks
	# This test has commented sections for 'Coming Soon' sections that may return in future itterations, please leave these in
	#This test requires a new master account in  wercsmart without any subscription
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: New_VC with the following parameters:
		| Field                | Value           |
		| Email                | User_<random>   |
		| Country              | UNITED STATES   |
		| FirstName            | Richard         |
		| LastName             | Smith           |
		| Password             | Pa4*ytuufnn     |
		| Address1             | Address 1       |
		| Address2             | Address 2       |
		| City                 | City Name       |
		| State                | Florida         |
		| Zip                  | 999             |
		| CompanyName          | Company 1       |
		| CompanyPhone         | 123-456-7889    |
		| EmergencyPhoneNumber | 123-456-7789    |
		| SupplierType         | Manufacturer    |
		| PhoneQuestion        | PhoneQuestion   |
		| PhoneHint            | PhoneHint       |
		| MentorQuestion       | MentorQuestion  |
		| MentorHint           | MentorHint      |
		| FriendQuestion       | FriendQuestion  |
		| FriendHint           | FriendHint      |
		| AnimalQuestion       | AnimalQuestion  |
		| AnimalHint           | AnimalHint      |
		| CollegeQuestion      | CollegeQuestion |
		| CollegeHint          | CollegeHint     |
		| Pin                  | 1234            |

	Then the WERCSmart homepage should load
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
	Then I confirm the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Tiered Subscription Options heading does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Formulated Products panel does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated Products panel, I confirm the text area containins: During the WERCSmart registration process, information about ingredients (e.g., water, ethanol, phosphoric acid) are collected. A product is considered formulated when it is necessary to include ingredient formulations to validate potential safety hazards. This is the most common product category.
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated Products panel, I confrim the selector displays: Choose...
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Enhanced Articles panel does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Enhanced Articles panel, I confirm the text area containins: Enhanced Articles include beverage products or products that include a lithium (ion or metal) battery when sold to the consumer.
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Enhanced Articles panel, I confrim the selector displays: Choose...
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Articles panel does exist
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Articles panel, I confirm the text area containins: An article is a manufactured item other than a fluid or particle which under normal conditions does not pose a physical health risk. Common examples include Light bulbs (do not contain any hazard component or ingredient), Electronics (circuit-board products without a battery), and Kits / gift packs ( two or more unrelated products combined in a package that uses a single upc.)
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Articles panel, I confrim the selector displays: Choose...
#	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Single Retailer Subscription heading does exist
#	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section, I confirm the Formulated, Enhanced & Articles panel does exist
#	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section I confirm the Formulated, Enhanced & Articles panel does have the message: Coming Soon!
#	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section I confirm the Formulated, Enhanced & Articles panel is grayed out
#	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated, Enhanced & Articles panel, I confirm the text area containins: When registering a type of product (formulated, enhanced, or article, excluding batteries) that is desginated to be sold by a single retailer, this option provides disounted pricing. WERCSmart Agency services are available at an additional cost.
#	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Formulated, Enhanced & Articles panel, I confrim the selector displays: Choose...
	Then I confirm the Select a subscription plan section does exist
	Then In the Select a subscription plan section, I confirm the Limited panel does exist
	Then In the Select a subscription plan section Limited panel, I confirm the list contains: Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area displays: Ensure your products meet the compliance requirements of over 50 retailers by submitting your product information in our secure software platform. Revise your registrations to comply with ever-changing regulations and requirements. Over 50 participating recipients of Assessment data is managed in one place, with ease.
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Limited panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Limited panel, I confirm the list contains: PurView Catalog Access
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area displays: In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform.
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the Learn More link
	Then I confirm https://www.ulpurview.com/ tab does exist
	Then I close the https://www.ulpurview.com/ tab
	Then I confirm https://www.ulpurview.com/ tab does not exist
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section, I confirm the Standard panel does exist
	Then In the Select a subscription plan section Standard panel, I confirm the list contains: Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area displays: Ensure your products meet the compliance requirements of over 50 retailers by submitting your product information in our secure software platform. Revise your registrations to comply with ever-changing regulations and requirements. Over 50 participating recipients of Assessment data is managed in one place, with ease.
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I click the info button
	Then In the Select a subscription plan section Standard panel Create and Manage Product Data - manage product registration, submit to selected retailers, manage UPCs list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Limited panel, I confirm the list contains: PurView Catalog Access
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area displays: In addition to managing data for purposes of retailer regulatory compliance needs, retailer mandated sustainability reporting obligations are growing in number throughout the retail community. Avoid having to enter the same data in multiple places by electing to have your WERCSmart product data shared with the UL PurView platform.
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the Learn More link
	Then I confirm https://www.ulpurview.com/ tab does exist
	Then I close the https://www.ulpurview.com/ tab
	Then I confirm https://www.ulpurview.com/ tab does not exist
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I click the info button
	Then In the Select a subscription plan section Limited panel PurView Catalog Access list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Standard panel, I confirm the list contains: Bronze Agent Support Services - direct phone and email support
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I click the info button
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I confrim the info text area displays: Enjoy the benefits of having a dedicated account agent, with technical expertise, to assist with answering questions related to product registrations, holds, re-certifications and updates. On the next screen, you will be able to upgrade to Silver or Gold Agent Support Services for additional data entry, advanced reporting and liaison services.
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I click the info button
	Then In the Select a subscription plan section Standard panel Bronze Agent Support Services - direct phone and email support list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Standard panel, I confirm the Best Value footer does exist
	Then In the Select a subscription plan section, I confirm the Premium panel does exist
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: Includes STANDARD features, plus
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: Regulatory Support - transportation, waste, VOC classifications
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I click the info button
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area displays: Transportation – Avoid potential delays and pitfalls by relying on UL’s regulatory experts to provide information and insights into your transportation classifications. You may be eligible for exemptions and exceptions that will save you money and get your products on the store shelves faster.
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area displays: Waste – Many retailers are now passing the costs of regulated waste disposal on to manufacturers like you! Understanding regulated waste classification requirements and the basis for your products classifications is more important than ever. Rely on UL’s regulatory experts to review and provide guidance to minimize your costs.
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area displays: VOC – Regulations around VOC are growing in size and complexity. Our regulatory experts will work with you to ensure your organizations products are compliant in the markets you serve.
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I click the info button
	Then In the Select a subscription plan section Premium panel Regulatory Support - transportation, waste, VOC classifications list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: UL ECOLOGO Readiness Assessment
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I click the info button
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I confrim the info text area displays: Recognized and referenced by more than 500 institutional procurement specifications, ECOLOGO Certification can increase market demand for your products.  The ECOLOGO Certification readiness assessment evaluates the likelihood that your product can achieve certification to one of the ECOLOGO multi-attribute sustainability standards, and will expand to include other products such as personal care.
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I click the info button
	Then In the Select a subscription plan section Premium panel UL ECOLOGO Readiness Assessment list item, I confrim the info text area is not displayed
	Then In the Select a subscription plan section Premium panel, I confirm the list contains: Draft OSHA-Compliant Safety Data Sheet
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I click the info button
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I confrim the info text area is displayed
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I confrim the info text area displays: Elect to have an OSHA-compliant GHS Safety Data Sheet(SDS) in a UL-approved format for each of your active products.
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I click the info button
	Then In the Select a subscription plan section Premium panel Draft OSHA-Compliant Safety Data Sheet list item, I confrim the info text area is not displayed
	#Then In the Select a subscription plan section, I confirm the Single Retailer panel does exist
	#Then In the Select a subscription plan section I confirm the Single Retailer panel is grayed out
	#Then In the Select a subscription plan section Single Retailer panel, I confirm the list contains: Create and Manage Product Data
	#Then In the Select a subscription plan section Single Retailer panel, I confirm the list contains: Submit registration to single retailer + No Retailer
	Then I confirm the Select an Agent Support Service Plan [optional] section does exist
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the text area displays: Personalized Agent Support Services are available to provide options for quality, dependable assistance ranging from direct phone access - to data entry - to advanced reporting and liaison services.
	Then In the Select an Agent Support Service Plan [optional] section text area, I click on the View Agent Support Service Agreement link
	Then I confirm the Agency Service Agreement modal is displayed
	Then In the Agency Service Agreement modal, I confirm the title displays: Agency Service Agreement
	Then In the Agency Service Agreement modal, I confirm the body text displays: By enrolling in Additional Support Service Options (Bronze, Silver or Gold), you, on behalf of the account holder (You) hereby authorize UL Information and Insights Inc. ("We" or "Us") to establish an Agent account in Your WERCSmart account for products entered, modified, or submitted for re-certification on your behalf (the "Products") and further appoint Us as Your designated agent ("Agent") with respect to such Products. You acknowledge that Agent shall have full authority in your WERCSmart account with respect to such Products as if it were You, including but not limited to, entering data, making any certifications required by the WERCSmart platform, and initiating, receiving and responding to any communications from us or any recipient of WERCSmart results. You further acknowledge that You remain responsible for Agent's actions or inactions with respect to such Products. You acknowledge that such authority shall continue until (i) You have withdrawn such authority by the submission of written notice of termination to use and (ii) We have acknowledged the receipt thereof. This Authorization constitutes an amendment to the WERCSmart Terms of Use posted on the WERCSmart site, as amended from time to time.
	Then In the Agency Service Agreement modal, I click the Close button
	Then I confirm the Agency Service Agreement modal is not displayed
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the Bronze Level Support panel does exist
	Then In the Select an Agent Support Service Plan [optional] section Bronze Level Support panel, I confirm the list contains: Direct phone and email support. Agent-guided basic account management (i.e. account creation & updates, holds & re-certifications, mergers & acquisitions)
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the Silver Agent Support panel does exist
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the list contains: Data Registration Input from Start to Finish
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the list contains: On-Hand Management of Holds Updates and Recertification
	Then In the Select an Agent Support Service Plan [optional] section Silver Agent Support panel, I confirm the list contains: On-Demand UPC WPS ID and Status Reports
	Then In the Select an Agent Support Service Plan [optional] section, I confirm the Gold Agent Support panel does exist
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Product Process Tracking and Follow up
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Unlimited VOC CAS Hold Waste/Hazard Battery & transportation
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Proactive Product Maintenance with Direct Retailer and WERCSmart Internal Team Communication
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Advanced Notice Alerts of Retail Requirement Changes
	Then In the Select an Agent Support Service Plan [optional] section Gold Agent Support panel, I confirm the list contains: Active Monitoring and Direct Notification of Retail Requirement Changes
	Then I confrim the Your Total footer exists and displays the text: Based on the above selected items, your estimated Subscription Plan total, excluding sales tax, is:
	Then In the enrollment footer, I confirm the Estimated Annual Cost calculator displayes: $0.00
	Then In the enrollment footer, I confirm the Estimated Annual Cost per Product calculator displayes: $0.00

@ignore
@TestCase:79577
Scenario: [79577] PayPal flow through My Account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I select the following enrollment options
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
		| Up to 1 Product(s) | Up to 1 Product(s) | Up to 1 Product(s)  | Limited      | General Support       |
	Then I click on Checkout
	Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
	Then In the Payment Methods screen I confirm the Continue Button is disabled
	Then In the Payment Methods screen I select Payment Method: PayPal
	Then In the Payment Methods screen I confirm the following text message appears for PayPal: In order to successfully subscribe with PayPal, please click continue. When you click "Continue", you will be redirected to PayPal to establish the payment agreement.
	Then In the Payment Methods screen I click Continue
	Then the PayPal page should load
	Given I log into PayPal with user saved as: PayPal and click Continue
	Given the Purchase Summary should be loaded
	Then In the Purchase Summary screen I check the Subscription Billing header is correct
	Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
	Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
	Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
	Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
	Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.

@ignore
@TestCase:105063
Scenario: [105063] Upgrade Subscription Message
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC105063User with the following parameters:
		| Field                | Value          |
		| Email                | User_<random>  |
		| Country              | UNITED STATES  |
		| FirstName            | WERCS          |
		| LastName             | Test_Automatio |
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
		| PhoneQuestion        | PhoneQuestion  |
		| PhoneHint            | PhoneHint      |
		| MentorQuestion       | MentorQuestion |
		| MentorHint           | MentorHint     |
		| FriendQuestion       | FriendQuestion |
		| FriendHint           | FriendHint     |
		| AnimalQuestion       | AnimalQuestion |
		| AnimalHint           | AnimalHint     |
		| CollegeQuestion      | CollegeQuestion|
		| CollegeHint          | CollegeHint    |
		| Pin                  | 1234           |
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I select the following enrollment options
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
		| None               | None               | Up to 1 Product(s)  | Limited      | General Support       |
	#And I click on the Proceed button
	Then I click on Checkout
	Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
	Then In the Payment Methods screen I select Payment Method: Credit Card
	Then In the Payment Methods screen I enter Credit Card details
		| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
		| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	#Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 45 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
	Then In the Thank You screen I click Home
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Servers, Small-Scale
	Then I save the product information as: TestCase105063
	#And I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
		| Alkaline     | <any>        | 4                               | 2                                  |
	Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 86163 - Retailer - Canada Only & PL, Select No Retailer, Add PL, Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then In the Subscription Enrollment screen I confirm heading as Subscription  Upgrade
	And I see the alert message with text: Subscription upgrade is required to submit your registration for assessment. Please upgrade at this time. Once you purchase your subscription, the registration data will transfer for assessment. Upgrades are pro-rated for the remainder of the subscription term and your default payment method will be used. under Subscription Enrollment
	And I click on the Proceed button
	Then In the Subscription popup I confirm the Subscription Upgrade header exists
	And I confirm the chosen options and body text are correct
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan | Body Text                                                                                                                            |
		| Up to 1 Product(s) |                    | Up to 1 Product(s)  | Limited      | General               | Your new purchase will be prorated based on the credit and time left in your current subscription. Checkout to see the final amount. |
	Then I click on Checkout
	Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
	Then In the Payment Methods screen I confirm the Default method is: Credit Card
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Purchase Summary screen I check the Subscription Billing header is correct
	Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
	Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
	Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
	Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
	Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	Then In the Thank You screen I confirm the following statement is shown: You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.


@ignore
@TestCase:62727
Scenario: [62727] Upgrade Subscription through My Account 
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC62727User with the following parameters:
		| Field                | Value                   |
		| Email                | User_<random>           |
		| Country              | UNITED STATES           |
		| FirstName            | WERCS                   |
		| LastName             | Test_Automation_Upgrade |
		| Password             | Pa4*ytuufnn             |
		| Address1             | Address 1               |
		| Address2             | Address 2               |
		| City                 | City Name               |
		| State                | Florida                 |
		| Zip                  | 999                     |
		| CompanyName          | Company 1               |
		| CompanyPhone         | 123-456-7889            |
		| EmergencyPhoneNumber | 123-456-7789            |
		| SupplierType         | Manufacturer            |
		| PhoneQuestion        | PhoneQuestion           |
		| PhoneHint            | PhoneHint               |
		| MentorQuestion       | MentorQuestion          |
		| MentorHint           | MentorHint              |
		| FriendQuestion       | FriendQuestion          |
		| FriendHint           | FriendHint              |
		| AnimalQuestion       | AnimalQuestion          |
		| AnimalHint           | AnimalHint              |
		| CollegeQuestion      | CollegeQuestion         |
		| CollegeHint          | CollegeHint             |
		| Pin                  | 1234                    |
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
	Then In the Subscription Enrollment screen I select the following enrollment options
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
		| Up to 5 Product(s) | Up to 5 Product(s) | Up to 5 Product(s)  | Standard     | Silver                |
	Then I click on Checkout
	Then In the Payment Methods screen I select Payment Method: Credit Card
	Then In the Payment Methods screen I enter Credit Card details
		| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
		| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I click Home
	Given I click on My Account
	#Then In the My Account screen I navigate to the Subscription Information page
	#Then In the Subscription Information screen I confirm the Status has the correct information: 5 Formulated, 5 Articles, 5 Enhanced Articles
	Then In the Subscription Information screen I click the Upgrade button
	Then In the Subscription Upgrade screen I confirm heading as Subscription  Upgrade
	Then In the Subscription Upgrade screen I confirm the Standard Feature Plan is selected
	Then In the Subscription Upgrade screen I confirm I cannot downgrade the current Feature Plan: Standard
	Then In the Subscription Upgrade screen I confirm the Silver Support Services Plan is selected
	Then In the Subscription Upgrade screen I confirm I cannot downgrade the current Support Services Plan: Silver
	Then In the Subscription Upgrade screen I confirm the Proceed button is disabled when there is no change in the plan selection
	Then In the Subscription Upgrade screen for Articles I select Up to 10 Product(s)
	Then In the Subscription Upgrade screen I confirm the Proceed button is enabled when a change is made in the plan selection
	Then In the Subscription Upgrade screen I confirm the Estimated Annual Cost changes when Articles are changed to Up to 15 Product(s)
	Then In the Subscription Upgrade screen I confirm the Estimated Annual Cost per Product changes when Enhanced Articles are changed to Up to 75 Product(s)
	Then In the Subscription Upgrade screen I select the following enrollment options
		| Articles            | Enhanced Articles   | Formulated Products | Feature Plan | Support Services Plan |
		| Up to 15 Product(s) | Up to 15 Product(s) | Up to 15 Product(s) | Premium      | Gold                  |
	Then In the Subscription popup I confirm the Subscription Upgrade header exists
	And I confirm the chosen options and body text are correct
		| Articles            | Enhanced Articles   | Formulated Products | Feature Plan | Support Services Plan | Body Text                                                                                                                            |
		| Up to 15 Product(s) | Up to 15 Product(s) | Up to 15 Product(s) | Premium      | Gold                  | Your new purchase will be prorated based on the credit and time left in your current subscription. Checkout to see the final amount. |
	Then I click on Checkout
	Then In the Payment Methods screen I confirm the Default method is: Credit Card
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Purchase Summary screen I check the Subscription Billing header is correct
	Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
	Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
	Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
	Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
	Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	Then In the Thank You screen I confirm the following statement is shown: You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.
	#Then In the Thank You screen I click Home
	Given I click on My Account
	Then In the My Account screen I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm the Status has the correct information: 15 Formulated, 15 Articles, 15 Enhanced Articles
	Then In the Subscription Information screen I confirm status is: ACTIVE
	Then In the Subscription Information screen I confirm the Subscription History table has the correct information
		| Subscription Level Status      | Quantity |
		| Premium Gold Formulated        | 15       |
		| Premium Gold Articles          | 15       |
		| Premium Gold Enhanced Articles | 15       |
	Given I click on My Account
	Then In the My Account screen I navigate to the Order History page
	Then In the Order History screen I select Subscription
	Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: TC62727User


@ignore
@TestCase:63224
Scenario: [63224] Upgrade subscription through data entry 
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC63224User with the following parameters:
		| Field                | Value                   |
		| Email                | User_<random>           |
		| Country              | UNITED STATES           |
		| FirstName            | WERCS                   |
		| LastName             | Test_Automation_Upgrade |
		| Password             | Pa4*ytuufnn             |
		| Address1             | Address 1               |
		| Address2             | Address 2               |
		| City                 | City Name               |
		| State                | Florida                 |
		| Zip                  | 999                     |
		| CompanyName          | Company 1               |
		| CompanyPhone         | 123-456-7889            |
		| EmergencyPhoneNumber | 123-456-7789            |
		| SupplierType         | Manufacturer            |
		| PhoneQuestion        | PhoneQuestion           |
		| PhoneHint            | PhoneHint               |
		| MentorQuestion       | MentorQuestion          |
		| MentorHint           | MentorHint              |
		| FriendQuestion       | FriendQuestion          |
		| FriendHint           | FriendHint              |
		| AnimalQuestion       | AnimalQuestion          |
		| AnimalHint           | AnimalHint              |
		| CollegeQuestion      | CollegeQuestion         |
		| CollegeHint          | CollegeHint             |
		| Pin                  | 1234                    |
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I select the following enrollment options
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
		| None               | None               | Up to 1 Product(s)  | Limited      | General Support       |
	Then I click on Checkout
	Then In the Payment Methods screen I select Payment Method: Credit Card
	Then In the Payment Methods screen I enter Credit Card details
		| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
		| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I click Home
	Given I create a product with RU - Chalk and take to submitted and save as: TestCase63224Product1
	Given I navigate to the home page
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase63224Product2
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue


#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

#	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then In the Subscription Enrollment screen I confirm heading as Subscription  Upgrade
	And I see the alert message with text: Subscription upgrade is required to submit your registration for assessment. Please upgrade at this time. Once you purchase your subscription, the registration data will transfer for assessment. Upgrades are pro-rated for the remainder of the subscription term and your default payment method will be used. under Subscription Enrollment
	And I click on the Proceed button
	Then In the Subscription popup I confirm the Subscription Upgrade header exists
	And I confirm the chosen options and body text are correct
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan | Body Text                                                                                                                            |
		|                    |                    | Up to 3 Product(s)  | Limited      | General               | Your new purchase will be prorated based on the credit and time left in your current subscription. Checkout to see the final amount. |
	Then I click on Checkout
	Then In the Payment Methods screen I check the Payment Methods heading and sub headings are correct
	Then In the Payment Methods screen I confirm the Default method is: Credit Card
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Purchase Summary screen I check the Subscription Billing header is correct
	Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
	Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
	Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
	Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
	Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	Then In the Thank You screen I confirm the following statement is shown: You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.
	Given I click on My Account
	Then In the My Account screen I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm the Status has the correct information: 3 Formulated, 0 Articles, 0 Enhanced Articles
	Then In the Subscription Information screen I confirm status is: ACTIVE
	Then In the Subscription Information screen I confirm the Subscription History table has the correct information
		| Subscription Level Status      | Quantity |
		| Limited Formulated             | 3        |
	Given I click on My Account
	Then In the My Account screen I navigate to the Order History page
	Then In the Order History screen I select Subscription
	Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: TC63224User


@ignore
@TestCase:73388
Scenario: [73388] Grace period through new account 
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC73388User with the following parameters:
		| Field                | Value           |
		| Email                | User_<random>   |
		| Country              | UNITED STATES   |
		| FirstName            | Richard         |
		| LastName             | Smith           |
		| Password             | Pa4*ytuufnn     |
		| Address1             | Address 1       |
		| Address2             | Address 2       |
		| City                 | City Name       |
		| State                | Florida         |
		| Zip                  | 999             |
		| CompanyName          | Company 1       |
		| CompanyPhone         | 123-456-7889    |
		| EmergencyPhoneNumber | 123-456-7789    |
		| SupplierType         | Manufacturer    |
		| PhoneQuestion        | PhoneQuestion   |
		| PhoneHint            | PhoneHint       |
		| MentorQuestion       | MentorQuestion  |
		| MentorHint           | MentorHint      |
		| FriendQuestion       | FriendQuestion  |
		| FriendHint           | FriendHint      |
		| AnimalQuestion       | AnimalQuestion  |
		| AnimalHint           | AnimalHint      |
		| CollegeQuestion      | CollegeQuestion |
		| CollegeHint          | CollegeHint     |
		| Pin                  | 1234            |
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I select the following enrollment options
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
		| None               | None               | Up to 1 Product(s)  | Limited      | General Support       |
	Then I click on Checkout
	Then In the Payment Methods screen I select Payment Method: Credit Card
	Then In the Payment Methods screen I enter Credit Card details
		| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
		| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	Given I click on My Account
	Then In the My Account screen I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm the Status has the correct information: 1 Formulated, 0 Articles, 0 Enhanced Articles
	Then In the Subscription Information screen I confirm status is: ACTIVE
	Then In the Subscription Information screen I confirm grace period is: None


@ignore
@TestCase:73394
Scenario: [73394] Grace period through My Account 
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC73394User with the following parameters:
		| Field                | Value                   |
		| Email                | User_<random>           |
		| Country              | UNITED STATES           |
		| FirstName            | WERCS                   |
		| LastName             | Automated_TEST73394     |
		| Password             | Welcome1!               |
		| Address1             | Address 1               |
		| Address2             | Address 2               |
		| City                 | City Name               |
		| State                | Florida                 |
		| Zip                  | 999                     |
		| CompanyName          | Company 1               |
		| CompanyPhone         | 123-456-7889            |
		| EmergencyPhoneNumber | 123-456-7789            |
		| SupplierType         | Manufacturer            |
		| PhoneQuestion        | PhoneQuestion           |
		| PhoneHint            | PhoneHint               |
		| MentorQuestion       | MentorQuestion          |
		| MentorHint           | MentorHint              |
		| FriendQuestion       | FriendQuestion          |
		| FriendHint           | FriendHint              |
		| AnimalQuestion       | AnimalQuestion          |
		| AnimalHint           | AnimalHint              |
		| CollegeQuestion      | CollegeQuestion         |
		| CollegeHint          | CollegeHint             |
		| Pin                  | 1234                    |
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I select the following enrollment options
		| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
		| None               | None               | Up to 1 Product(s)  | Limited      | General Support       |
	Then I click on Checkout
	Then In the Payment Methods screen I select Payment Method: Wire Transfer
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I check the Header is correct
	Given I click on My Account
	Then In the My Account screen I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm the Status has the correct information: 1 Formulated, 0 Articles, 0 Enhanced Articles
	Then In the Subscription Information screen I confirm status is: LOCKED
	Then In the Subscription Information screen I confirm grace period is: None
	Given I click on My Account
	Then In the My Account screen I navigate to the Payment Methods page
	Then In the Payment Methods under Add a new Payment method I select: Credit Card
	Then In the Payment Methods screen I enter Credit Card details
		| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
		| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test73394_cc           |
	Given In the Add new Credit card popup I click Save
	Given I click on Make Default for user: test73394_cc
	Given I click on My Account
	Then In the My Account screen I navigate to the Subscription Information page
	Then In the Subscription Information screen I confirm status is: ACTIVE
	Then In the Subscription Information screen I confirm grace period is: None


#@ignore
@TestCase:94466
Scenario: [94466] Subscription - Retailer count in messages
	Given I go to the WERCSmart Log in
	Given If not already created, I create a user: TC94466User with the following parameters:
		| Field                | Value                   |
		| Email                | User_<random>           |
		| Country              | UNITED STATES           |
		| FirstName            | WERCS                   |
		| LastName             | Test_Automation_Upgrade |
		| Password             | Pa4*ytuufnn             |
		| Address1             | Address 1               |
		| Address2             | Address 2               |
		| City                 | Latham                  |
		| State                | New York                |
		| Zip                  | 12110                   |
		| CompanyName          | Company 1               |
		| CompanyPhone         | 123-456-7889            |
		| EmergencyPhoneNumber | 123-456-7789            |
		| SupplierType         | Manufacturer            |
		| PhoneQuestion        | PhoneQuestion           |
		| PhoneHint            | PhoneHint               |
		| MentorQuestion       | MentorQuestion          |
		| MentorHint           | MentorHint              |
		| FriendQuestion       | FriendQuestion          |
		| FriendHint           | FriendHint              |
		| AnimalQuestion       | AnimalQuestion          |
		| AnimalHint           | AnimalHint              |
		| CollegeQuestion      | CollegeQuestion         |
		| CollegeHint          | CollegeHint             |
		| Pin                  | 1234                    |
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
	Then In the Select your desired range of Formulated, Articles, Enhanced Articles or Single Retailer Products section Articles panel, I confirm the Up to 1 Product(s) selector option is selected
	Given In the Select a subscription plan section Limited panel, I click the radio button
	Then In the enrollment footer, I click the PROCEED button
	Then In the Subscription Enrollment Modal, I click the Checkout button
	Then In the Payment Methods screen I select Payment Method: Credit Card
	Then In the Payment Methods screen I enter Credit Card details
		| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
		| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
	Then In the Payment Methods screen I click Continue
	Then In the Purchase Summary screen I click Confirm Order
	Then In the Thank You screen I confirm the following statement is shown: You have successfully signed up for a subscription plan. Thank you for depending on UL to provide over 45 retailers with critical product information they require to on-board your products and keep store workers, consumers and the environment safe.

@ignore
@TestCase:119192
Scenario: [119192] Subscription - Articles/Enhanced Articles/Formulated Products Drop Down Menus - Show/Select Options

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click on My Account
	Then I click on NEW SUBSCRIPTION
	Then In the Subscription Enrollment screen I confirm heading as Subscription  Enrollment
	Then In the Subscription Enrollment screen I confirm that I see the following subheadings:
		| Subheading                                                          |
		| 1 Select the range of your products, articles and enhanced articles |
		| 2 Select the feature plan                                           |
		| 3 Select the Support Services Plan                                  |
	Then In the Subscription Enrollment screen I confirm that you see Formulated Products dropdown
	And I check that the following are showing in the Formulated Products dropdown:
		| Item                  |
		| Choose...             |
		| Up to 150 Product(s)    |
		| Up to 200 Product(s)    |
		| Up to 300 Product(s)    |	
	And The Formulated Products popup should have header: What Are Formulated Products?
	And The Formulated Products popup should have content: During the WERCSmart registration process, information about ingredients (e.g., water, ethanol, phosphoric acid) are collected.
	Then In the Subscription Enrollment screen I confirm that the option showing in the Formulated Products dropdown is: Up to 150 Product(s)
	Then In the Subscription Enrollment screen I confirm that you see Articles dropdown
	And I check that the following are showing in the Articles dropdown:
		| Item                  |
		| Choose...             |
		| Up to 15 Product(s)    |
		| Up to 20 Product(s)    |
		| Up to 25 Product(s)    |
	And The Articles popup should have header: What Are Articles?
	And The Articles popup should have content: According to OSHA regulation 1910.1200, an article is “a manufactured item other than a fluid or particle: (i) which is formed to a specific shape or design during manufacture; (ii) which has end-use function(s) dependent in whole or in part upon its shape or design during end-use; and (iii) which under normal conditions of use does not release more than very small quantities, e.g., minute or trace amounts of a hazardous chemical (as determined under paragraph (d) of this section), and does not pose a physical hazard or health risk to employees.”
	Then In the Subscription Enrollment screen I confirm that the option showing in the Articles dropdown is: Up to 15 Product(s)
	Then In the Subscription Enrollment screen I confirm that you see Enhanced Articles dropdown
	And I check that the following are showing in the Enhanced Articles dropdown:
		| Item                  |
		| Choose...             |
		| Up to 3 Product(s)    |
		| Up to 5 Product(s)    |
		| Up to 7 Product(s)    |	
	And The Enhanced Articles popup should have header: What Are Enhanced Articles?
	And The Enhanced Articles popup should have content: Beverage registrations or products that include a lithium battery when sold to the consumer (lithium ion or lithium metal) are considered Enhanced Articles for the purpose of WERCSmart registration.
	Then In the Subscription Enrollment screen I confirm that the option showing in the Enhanced Articles dropdown is: Up to 3 Product(s)


# Created by Saikiran Chittampally

@TestCase:112028
Scenario: [112028] Subscription - Updating Company Name
	
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given  I call Shared Step 62676 (Go To My Account)
	Given In the My Account page I navigate to the Payment Methods page
	Given In the Payment Methods screen I open the Edit Address form
	Given In the Account Name field, change the name of the Company INT123-test and Confirm the Contact Information is updated with the New Company Name

# Created by Saikiran Chittampally
@TestCase:112388
Scenario: [112388] Subscription - Contact Information and Billing Information Appear Properly
	
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given  I call Shared Step 62676 (Go To My Account)
	Given In the My Account page I navigate to the Payment Methods page
	Then In the payment methods page I confirm that the Contact Information account name: INT123-test, firstname: Test_Automation_ProductsAccount,last name: WERCS, email addresss: User_edcc11cb5c8e@kxxyxunf.mailosaur.net appear correct
	Then In the payment methods page I confirm that the Billing Address address one: 725 5th Ave, address two: test2, cityStateZip: New York New York 10022, country: UNITED STATES, phoneNo: 123-456-7889 appear correct		
	And I click the back arrow next to payment methods
	When In the My Account page I navigate to the Company Information page
	Then In the company information page I confirm that the Address billingAddress for: action_menu: Billing Address country: INDIA address one: test1, address two: test2, city: Hyderabad, State: Telangana, Zip: 99897, phoneNo: 345-678-9001, saveAddressOption: billingAddress updated correctly
	Then In the company information page I confirm that the Address shippingAddress for: action_menu: Shipping Address country: CANADA address one: test, address two: testshipping2, city: Ontario, State: Ontario, Zip: 97977, phoneNo: 956-608-9000, saveAddressOption: shippingAddress updated correctly
	#Again updating the Billing address with the previous data, As the data getting updated in Payment Methods page
	Then In the company information page I confirm that the Address billingAddress for: action_menu: Billing Address country: UNITED STATES address one: 725 5th Ave, address two: test2, city: New York, State: New York, Zip: 10022, phoneNo: 123-456-7889, saveAddressOption: billingAddress updated correctly
	#Again updating the Shipping address with the previous data, As the data getting updated in Payment Methods page
	Then In the company information page I confirm that the Address shippingAddress for: action_menu: Shipping Address country: CANADA address one: 725 6th Ave, address two: testshipping, city: Ontalon, State: Ontario, Zip: 99977, phoneNo: 956-608-9990, saveAddressOption: shippingAddress updated correctly
	
#Executed in QA-Integration Environment
# Created by Saikiran Chittampally
@TestCase:87997
Scenario: [87997] Order History - Subscription Features
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click on My Account
	Then In the My Account screen I navigate to the Order History page
	When In the Order History screen I select Subscription
	Then I Confirm that I see the field : Filter
	And I Confirm that I see the field : Clear Filter
	#Given I filter with order Number : INV00095035, Clear Filter
	Then I Confirm Clear Filter results are correct: INV00095035
	Given I filter with order Number : INV00095035, Filter
	Then I Confirm Filter results are correct: INV00095035
	When I click view details link
	Then I confirm that a file is produced called INV00095035-08_05_2023.pdf and save as savedasINV00095035PDF
	Then I Check that the pdf file saved as: savedasINV00095035PDF contains the text: UL Verification Services Inc.
	Then I click on close in the Report Download dialog
	Then I delete the file saved as savedasINV00095035PDF

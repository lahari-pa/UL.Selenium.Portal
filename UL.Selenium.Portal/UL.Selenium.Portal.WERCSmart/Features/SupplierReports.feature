@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@RetailPartners
@wercsmart
@Signup
@ProductGrid
@run_SupplierReports
@ViewUpcs
@DataSummarySheet
@SHA
@MyAccount
Feature: Supplier Reports

@TReVorId:16834
Scenario: [68420] List of Supplier Reports
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	And In the Supplier Reports screen the page title should be: Available Reports
	Given under the supplier Reports menu I should see the following options
		| Reports                                                            |
		| Battery-Containing Products                                        |
		| California Proposition 65 - Registrations Prior to August 30, 2018 |
		| Kit Registration Details                                           |
		| Kits Containing a Specific Registration                            |
		| Pesticide Certificate Report                                       |
		| Pesticide Report                                                   |
		| Product Types Registered                                           |
		| Registrations Revised - Not Yet Submitted                          |
		| Registrations with Retailer Chemicals of Concern                   |
		| Retailer Chemicals of Concern                                      |
		| Subscription Renewal (Formulated, Enhanced, Articles)              |
		| Subscription Renewal (Registrations Eligible for Deletion)         |
		| Sustainability Survey Eligibility - Health & Beauty                |
		| UPC and Retailer (Product Specific)                                |
		| UPC Error Details                                                  |
		| UPCs (Active) for all Registrations                                |
		| UPCs and Registrations (Retailer Specific)                         |
		| UPCs Duplicated within Account                                     |
		| VOC-related Registrations                                          |
		| Waste Classification Summary for All Registrations                 |

@TReVorId:16835
Scenario: [68421] Active UPCs for Products Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	And In the Supplier Reports screen the page title should be: Available Reports
	Given Under the Supplier Reports menu I choose: UPCs (Active) for all Registrations
	Then In the Supplier Reports screen the current sub-page should be: UPCs (Active) for all Registrations
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that an excel file is produced called UPCs (Active) for all Registrations.xlsx and save as 68421
	Then I confirm that the excel file saved as: 68421 contains the following columns:
		| Column          |
		| WPSID           |
		| Product Name    |
		| Brand           |
		| Recommended Use |
		| Individual UPC  |
		| Case UPC        |
	Given I click on close in the Report Download dialog
	And I delete the Supplier Report file saved as 68421

@TReVorId:22388
@TReVorId:22388
Scenario: [68422] Battery-containing products report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Battery-Containing Products
	Then In the Supplier Reports screen the current sub-page should be: Battery-Containing Products
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called BatteryContaining Products.xlsx and save as 68422
	Then I confirm that the excel file saved as: 68422 contains the following columns:
		| Column        |
		| Supplier Name |
		| WPSID         |
		| Product Name  |
		| Battery Type  |
		| Battery Mfg   |
	And I delete the Supplier Report file saved as 68422

@TReVorId:22389
Scenario: [68423] Formulated vs Articles Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Subscription Renewal (Formulated, Enhanced, Articles)
	Then In the Supplier Reports screen the current sub-page should be: Subscription Renewal (Formulated, Enhanced, Articles)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Subscription Renewal (Formulated Enhanced Articles).xlsx and save as 68423
	Then I confirm that the excel file saved as: 68423 contains the following columns:
		| Column              |
		| WPSID               |
		| Product Name        |
		| Formulated          |
		| Articles            |
		| Enhanced Articles   |
		| 3rd Party Formula   |
		| ULGHS Document Only |
	And I delete the Supplier Report file saved as 68423

Scenario: [73082] UPC Report for All Products with Retailer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPCs and Registrations (Retailer Specific)
	Then In the Supplier Reports screen the current page should be: UPCs and Registrations (Retailer Specific)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 73082
	Then I confirm that the excel file saved as: 73082 contains the following columns:
		| Column                    |
		| WERCSmart ID              |
		| Product Name              |
		| Brand                     |
		| UPC                       |
		| Retailer                  |
		| Status                    |
		| Ounces                    |
		| Unique Product Identifier |
		| Container Type            |
		| Package Type              |
		| Net Explosive Mass        |
		| Case Pack                 |
		| Case Pack Individual UPC  |
		| Private Label             |
		| Direct Ship Vendor        |
		| Goods Not For Resale      |
		| Registration Type         |
		| Subscription Type         |
	Then I confirm that the excel file saved as: 73082 in column: Container Type there are no numbers
	And I delete the Supplier Report file saved as 73082

Scenario: [73225] Kits that Contain a specific Product
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Kits Containing a Specific Registration
	Then In the Supplier Reports screen the current page should be: Kits Containing a Specific Registration
	Given I select a random product from the drop down
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Kits Containing a Specific Registration.xlsx and save as 73225
	Then I confirm that the excel file saved as: 73225 contains the following columns:
		| Column              |
		| Product in Kit      |
		| Product in Kit Name |
		| Kit WPSID           |
		| Kit Name            |
	And I delete the Supplier Report file saved as 73225

Scenario: [73228] Products that are Associated with a specific Kit
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Kit Registration Details
	Then In the Supplier Reports screen the current sub-page should be: Kit Registration Details
	Given I select a random product from the drop down
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Kit Registration Details.xlsx and save as 73228
	Then I confirm that the excel file saved as: 73228 contains the following columns:
		| Column              |
		| Product in Kit      |
		| Product in Kit Name |
		| Kit WPSID           |
		| Kit Name            |
	And I delete the Supplier Report file saved as 73228

Scenario: [73226] Pesticide Certificate Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Pesticide Certificate Report
	Then In the Supplier Reports screen the current page should be: Pesticide Certificate Report
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Pesticide Certificate Report.xlsx and save as excel73226
	Then I confirm that the excel file saved as: excel73226 contains the following columns:
		| Column                                            |
		| Supplier                                          |
		| WPSID                                             |
		| Product Name                                      |
		| Pesticide Certificates Currently Expired Count    |
		| Pesticide Certificates Expire in 1-30 Days Count  |
		| Pesticide Certificates Expire in 31-60 Days Count |
		| Pesticide Certificates Expire in 61-90 Days Count |
		| In Recertification                                |
	And I delete the excel file saved as excel73226

Scenario: [73229] Products with VOCs
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: VOC-related Registrations
	Then In the Supplier Reports screen the current page should be: VOC-related Registrations
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called VOCrelated Registrations.xlsx and save as 73229
	Then I confirm that the excel file saved as: 73229 contains the following columns:
		| Column       |
		| Supplier     |
		| WPSID        |
		| Product Name |
	And I delete the excel file saved as 73229

Scenario: [73227] Products and Recommended Use Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Product Types Registered
	Then In the Supplier Reports screen the current page should be: Product Types Registered
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Product Types Registered.xlsx and save as 73227
	Then I confirm that the excel file saved as: 73227 contains the following columns:
		| Column         |
		| Supplier       |
		| RU Description |
		| RU Category    |
		| WPSID          |
		| Product Name   |
	And I delete the excel file saved as 73227

Scenario: [73230] UPC Report for Specific Product with Retailer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPC and Retailer (Product Specific)
	Then In the Supplier Reports screen the current page should be: UPC and Retailer (Product Specific)
	Given I select a random product from the drop down
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPC and Retailer (Product Specific).xlsx and save as 73230
	Then I confirm that the excel file saved as: 73230 contains the following columns:
		| Column          |
		| WPSID           |
		| Product Name    |
		| Brand           |
		| Recommended Use |
		| Individual UPC  |
		| Case UPC        |
		| Retailer        |
		| Status          |
	And I delete the excel file saved as 73230

Scenario: [75391] Sustainability Survey Eligibility – Health & Beauty
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Sustainability Survey Eligibility - Health & Beauty
	Then In the Supplier Reports screen the current page should be: Sustainability Survey Eligibility - Health & Beauty
	Given In the Supplier Report page in the select Retailer dropdown I select: Target
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Sustainability Survey Eligibility  Health & Beauty.xlsx and save as 75391
	Then I confirm that the excel file saved as: 75391 contains the following columns:
		| Column                                              |
		| WERCSmart ID                                        |
		| Product Name                                        |
		| Quantity of Active UPCs                             |
		| Transparency Indicator Ratio                        |
		| 3rd Party Formula Use Indicator                     |
		| Last Submission Date                                |
		| Current Subscription Level                          |
		| Current Data Tier Consent for the Selected Retailer |
	Then I save the first product in the excel spreadsheet saved as: 75391 as TestCase75391
	Then I save the number of UPCs on the first product in the excel spreadsheet saved as: 75391 as TestCase75391UPCs
	Then I save the Transparency Indicator Ratio of the first product in the excel spreadsheet saved as: 75391 as TestCase75391TransRatio
	Then I save the Last Submission Date of the first product in the excel spreadsheet saved as: 75391 as TestCase75391Date
	Then I save the Current Subscription Level of the first product in the excel spreadsheet saved as: 75391 as TestCase75391Subscription
	Then I save the Current Data Tier Consent for the Selected Retailer of the first product in the excel spreadsheet saved as: 75391 as TestCase75391DataTier
	Given I navigate to the home page
	Given I search for the product saved as: TestCase75391
	And I confirm that the product returned has the same name as the product saved as: TestCase75391
	And I confirm that the product returned has the retailer: TG
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I confirm that the number of UPCs equals the number saved as: TestCase75391UPCs
	And I close the window that opened
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	And I confirm that the Transparency Ratio underneath Ingredients equals: TestCase75391TransRatio
	And I close the window that opened
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75391)
	Given I confirm that the Current Submission date in SHA Manager matches the date saved as: TestCase75391Date
	Given I navigate to the WERCSmart site
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click on My Account
	And In the My Account page I confirm that the subscription level is: TestCase75391Subscription
	Then I click the Retail Partners icon in the Navigation Pane
	And I select the retailer: Target
	And I confirm that the Data Consent Tiers information matches the information saved as: TestCase75391DataTier
	And I delete the Supplier Report file saved as 75391

#fails because of a bug 106613
@TReVorId:16846
Scenario: [76551] California Proposition 65 - Registrations Prior to August 30, 2018
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: California Proposition 65 - Registrations Prior to August 30, 2018
	Then In the Supplier Reports screen the current page should be: California Proposition 65 - Registrations Prior to August 30, 2018
	And In the Supplier Report page I should see the report description should be showing with text: The report output will illustrate the WERCSmart registrations active, not deleted, that exist in your WERCSmart account. The output will provide information related to Active Registrations and their responses to Proposition 65 questions presented in WERCSmart before the transition to the revised Prop 65 questions in July / August of 2018. The report will include registrations not yet updated and submitted with the revised Prop 65 data
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that a file is downloaded with file name: California Proposition 65  Registrations Prior to August 30 2018.xlsx then close the Report Download popup. I save the file as excel76551
	Then I confirm that the excel file saved as: excel76551 contains the following columns:
		| Column                    |
		| WERCSmart ID              |
		| WERCSmart Product Name    |
		| Contains Chemical on List |
		| Prop 65 Warning Required  |
		| Prop 65 Warning on Label  |
		| Exposure Warning          |
		| Warning Trigger           |
		| Warning Transmitted       |
		| Last Order Date           |
		| Last Revision Date        |
	And I delete the Supplier Report file saved as excel76551

#TODO - this scenario is incomplete because the possibility of automating the rest of the test case needs review.
Scenario: [76759] Waste Classification Summary Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Waste Classification Summary for All Registrations
	Then In the Supplier Reports screen the current page should be: Waste Classification Summary for All Registrations
	And In the Supplier Report page I should see the report description should be showing with text: Report will show the waste classification for each of the 50 states and other areas within the United States, as well as the Federal waste classification. For specific information about a registration's waste classification, and how the waste classification was derived, you may request an Additional Document from the My Products area for the registration you're interested in receiving details about.
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that a file is downloaded with file name: Waste Classification Summary for All Registrations.xlsx then close the Report Download popup. I save the file as SupplierReport76759
	Then I confirm that the excel file saved as: SupplierReport76759 contains the following columns:
		| Column        |
		| WERCSmart ID  |
		| Product Name  |
		| Federal Waste |
		| EPA Type      |
		| EPA Code      |
	Then I confirm that the excel file saved as: SupplierReport76759 contains the following columns:
		| Column         |
		| Alabama        |
		| Alaska         |
		| Arizona        |
		| Arkansas       |
		| California     |
		| Colorado       |
		| Connecticut    |
		| Delaware       |
		| Florida        |
		| Georgia        |
		| Hawaii         |
		| Idaho          |
		| Illinois       |
		| Indiana        |
		| Iowa           |
		| Kansas         |
		| Kentucky       |
		| Louisiana      |
		| Maine          |
		| Maryland       |
		| Massachusetts  |
		| Michigan       |
		| Minnesota      |
		| Mississippi    |
		| Missouri       |
		| Montana        |
		| Nebraska       |
		| Nevada         |
		| New Hampshire  |
		| New Jersey     |
		| New Mexico     |
		| New York       |
		| North Carolina |
		| North Dakota   |
		| Ohio           |
		| Oklahoma       |
		| Oregon         |
		| Pennsylvania   |
		| Rhode Island   |
		| South Carolina |
		| South Dakota   |
		| Tennessee      |
		| Texas          |
		| Utah           |
		| Vermont        |
		| Virginia       |
		| Washington     |
		| West Virginia  |
		| Wisconsin      |
		| Wyoming        |
	And I delete the Supplier Report file saved as SupplierReport76759

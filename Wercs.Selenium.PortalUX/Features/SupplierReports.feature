@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@RetailPartners
@wercsmart
@Signup
@run_SupplierReports

Feature: Supplier Reports

Background:
Given I go to the WERCSmart Log in

@tfstestcase:68420
Scenario: [68420] List of Supplier Reports
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given under the supplier Reports menu I should see the following options
| Reports                                          |
| Active UPCs for Products Report                  |
| Battery-containing products report               |
| Formulated vs. Articles Report                   |
| Kits that contain a specific product             |
| Pesticide Certificate Report                     |
| Products and Recommended Use Report              |
| Products that are associated with a specific kit |
| Products with VOCs                               |
| UPC Report for All Products with Retailer        |
| UPC Report for Specific Product with Retailer    |

@tfstestcase:68421
Scenario: [68421] Active UPCs for Products Report
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Active UPCs for Products Report
Then In the Supplier Reports screen the current page should be: Active UPCs for Products Report
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Active UPCs for Products Report.xlsx and save as 68421
Then I confirm that the excel file saved as: 68421 contains the following columns:

| Column        |
| WPSID         |
| Product Name  |
| Active UPCs   |


@tfstestcase:68422
Scenario: [68422] Battery-containing products report
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Battery-containing products report
Then In the Supplier Reports screen the current page should be: Battery-containing products report
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Battery-containing products report.xlsx and save as 68422
Then I confirm that the excel file saved as: 68422 contains the following columns:

| Column        |
| Supplier Name |
| WPSID         |
| Product Name  |
| Battery Type  |
| Battery Mfg   |


Scenario: [68423] Formulated vs Articles Report
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Formulated vs. Articles Report
Then In the Supplier Reports screen the current page should be: Formulated vs. Articles Report
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Formulated vs. Articles Report.xlsx and save as 68423
Then I confirm that the excel file saved as: 68423 contains the following columns:

| Column              |
| WPSID               |
| Product Name        |
| Formulated          |
| Articles            |
| Enhanced            |
| 3rd Party Formula   |
| ULGHS Document Only |

Scenario: [73082] UPC Report for All Products with Retailer
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC Report for All Products with Retailer
Then In the Supplier Reports screen the current page should be: UPC Report for All Products with Retailer
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called UPC Report for All Products with Retailer.xlsx and save as 73082
Then I confirm that the excel file saved as: 73082 contains the following columns:
| Column                             |
| WPSID                              |
| Product Name                       |
| UPC                                |
| Retailer                           |
| Status                             |
| Package Size                       |
| Retailer Unique Product Identifier |
| Container Type                     |
Then I confirm that the excel file saved as: 73082 in column: Container Type there are no numbers

#NOT WORKING BECAUSE 1500001 IS NOT FOUND
Scenario: [73225] Kits that Contain a specific Product
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Kits that contain a specific product
Then In the Supplier Reports screen the current page should be: Kits that contain a specific product
Given In the Kits that contain a specific product I search and select product: 1500009
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Kits that contain a specific product.xlsx and save as 73225
Then I confirm that the excel file saved as: 73225 contains the following columns:
| Column              |
| Product in Kit      |
| Product in Kit Name |
| Kit WPSID           |
| Kit Name            |

#NOT WORKING BECAUSE 1500009 IS NOT FOUND
Scenario: [73228] Products that are Associated with a specific Kit
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Products that are associated with a specific kit
Then In the Supplier Reports screen the current page should be: Products that are associated with a specific kit
Given In the Kits that contain a specific product I search and select product: 1500009
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Products that are associated with a specific kit.xlsx and save as 73228
Then I confirm that the excel file saved as: 73228 contains the following columns:
| Column              |
| Product in Kit      |
| Product in Kit Name |
| Kit WPSID           |
| Kit Name            |

#Not finished because at the moment the report is downloading as html not xls and with no results.
Scenario: [73226] Pesticide Certificate Report
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Pesticide Certificate Report
Then In the Supplier Reports screen the current page should be: Pesticide Certificate Report
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Pesticide Certificate Report.xlsx and save as 73226
Then I confirm that the excel file saved as: 73226 contains the following columns:

| Column                                            |
| Supplier                                          |
| WPSID                                             |
| Product Name                                      |
| Pesticide Certificates Currently Expired Count    |
| Pesticide Certificates Expire in 1-30 Days Count  |
| Pesticide Certificates Expire in 31-60 Days Count |
| Pesticide Certificates Expire in 61-90 Days Count |
| In Re-certification                               |


Scenario: [73229] Products with VOCs
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Products with VOCs
Then In the Supplier Reports screen the current page should be: Products with VOCs
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Products with VOCs.xlsx and save as 73229
Then I confirm that the excel file saved as: 73229 contains the following columns:

| Column       |
| Supplier     |
| WPSID        |
| Product Name |

Scenario: [73227] Products and Recommended Use Report
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Products and Recommended Use Report 
Then In the Supplier Reports screen the current page should be: Products and Recommended Use Report 
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Products and Recommended Use Report.xlsx and save as 73227
Then I confirm that the excel file saved as: 73227 contains the following columns:

| Column         |
| Supplier       |
| RU Description |
| RU Category    |
| WPSID          |
| Product Name   |  




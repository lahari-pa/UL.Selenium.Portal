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
@SHA
@PaymentMethods
@ForwardProductRegistration

Feature: Single Retailer Subscription

@TestCase:200502

Scenario: [200502] Single Retailer - Supplier Manager - Search and Result Table Revisions

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I click on the Suppliers link on the top right of the screen
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I check next radio buttons:
| Radio Button   |
| Company        |
| User Name      |
| E-Mail         |
| Phone          |
| Invoice Number |
And I call Shared step In the Supplier Manager Popup - radio button 'Company',enter in search 'Company' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'User Name',enter in search 'User Name' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'E-Mail',enter in search 'E-Mail' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'Phone',enter in search '999-999-9999' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'Invoice Number',enter in search 'Invoice Number' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |


@TestCase:200434

Scenario: [200434] Single Retailer - Not Available for Forwarding

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: Product200434
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer |
| Amazon   |
Then I generate a random UPC number and save as: UPC200434
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC200434, container type: any and size: 20
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And in the Additional Documents to Provide page I click Continue
And in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And If purchase details are showing click confirm order
And In the Thank You screen I click Home
Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In the SHA manager grid I see the WPS ID I have saved as product: Product200434 and if status is Submitted, I change status to Assigned, then confirm status is Assigned
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: Product200434)
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: Product200434)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: Product200434)
And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: Product200434
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: Product200434)
And I call Shared Step 59066 (Go to SHA Manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: Product200434)
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: Product200434) for
| Retailer |
| Amazon   |
And I navigate to the landing page
Given I log in with the account saved in TReVor as: SingleRetailerAccount
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as Product200434 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should not see product: saved as Product200434

@TestCase:200449

Scenario: [200449] Single Retailer - Not Available for Forwarding

Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: Product200449
Then I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 183893 (Single Retailer - Retailer Screen - Select retailer)
| Retailer |
| Amazon   |
Then I generate a random UPC number and save as: UPC200449
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC200449, container type: any and size: 20
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And in the Additional Documents to Provide page I click Continue
And in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: text
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And If purchase details are showing click confirm order
And In the Thank You screen I click Home
Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In the SHA manager grid I see the WPS ID I have saved as product: Product200449 and if status is Submitted, I change status to Assigned, then confirm status is Assigned
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: Product200449)
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: Product200449)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: Product200449)
And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: Product200449
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: Product200449)
And I call Shared Step 59066 (Go to SHA Manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: Product200449)
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: Product200449) for
| Retailer |
| Amazon   |
And I navigate to the landing page
Given I log in with the account saved in TReVor as: SingleRetailerAccount
And I search for the product saved as: Product200449
And I click Row Actions for the first product returned
And I should not see the following Actions options
| Option             |
| Archive Retailers  |

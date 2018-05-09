@wercsmart
@run_ChooseGoodGuide
@ConflictMinerals
@ProductGrid
@WERCSmart_ChooseGoodGuide

Feature: ChooseGoodGuide.com Scenarios

Scenario: [68878] ChooseGoodGuide.com - Create a New Company
Given I navigate to the URL: https://choosegoodguide.com/
And I click the 'Get Started Now' button
Then I click the 'Create Company Account' button
And I enter the Email: <random>
Given I save the current emails in the inbox for address saved as: AccountEmailAddress
And I click the Next button
Given I create an account with the following parameters:
| Field                  | Value             |
| Company Name           | This test company |
| Address                | Address first     |
| Address 2              | Address second    |
| Address 3              | Address third     |
| City                   | City name         |
| State                  | Kansas            |
| Postal Code            | 66506             |
| Country                | United States     |
| Phone Number           | 785-532-6412      |
| Emergency Phone Number | 785-532-6412      |
| Fax                    | 785-532-7408      |
And I click the Next button
And The contact person page should appear
Given I setup the Company Contact Person as follows:
| Field                                       | Value                  |
| Contact                                     | Jane Richardson        |
| Phone Number                                | 785-532-6413           |
| Additional Emails                           | richardSmith@smith.com |
| Password                                    | Welcome1!              |
| What city were you born in?                 | TheWercs               |
| What was the Model of your first car?       | TheWercs               |
| What is your favorite sport?                | TheWercs               |
| What is your favorite food or drink?        | TheWercs               |
| What is your favorite vacation destination? | TheWercs               |
| Secure Password                             | Welcome1!              |
And I click the Next button
Then I wait for the congratulations page to appear
And I confirm that I have received a GoodGuide account email to account: saved as AccountEmailAddress
And I confirm that I have received a Signup confirmation email to account: saved as AccountEmailAddress
Then I confirm that I have a received a Verification code email to account: saved as AccountEmailAddress
Given I save the verification code sent to account: saved as AccountEmailAddress as: Myverificationcode
Given I click on the login button on the congratulations page
Given on the GoodGuide login page I enter the Email address: saved as AccountEmailAddress
Given on the GoodGuide login page I enter the Password: Welcome1!
Then on the GoodGuide login page I click on the Login button
Then the GoodGuide Verification page should load
Then on the GoodGuide Verification page I enter verification code: saved as Myverificationcode
Then on the GoodGuide Verification page I click Verify
Then the GoodGuide terms of use page should load
Then on the GoodGuide terms of use I check the Accept checkbox
Then on the GoodGuide terms of use I click continue
And the GoodGuide Company Details page should load

Scenario: [68913] Register New Product - No Marks of Distinction
Given I navigate to the URL: https://choosegoodguide.com/
And I click the 'Get Started Now' button
Given on the GoodGuide login page I enter the Email address: c8e0c5521437.kxxyxunf@mailosaur.io
Given on the GoodGuide login page I enter the Password: Welcome1!
Then on the GoodGuide login page I click on the Login button
Then on the ChooseGoodGuide site the GoodGuide home page should load
Given on the top navigation bar I click on My Products
Then in the GoodGuide site the My Products page should load
Given In the My Products Menu I select: GoodGuide
Then in the GoodGuide site the Welcome page should load
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the New Product page should load
Given in the GoodGuide New Product page I select: Create a New Product
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the Product Identification page should load
Given I generate a random product name and save as MyProductName
Given in the Product Identification page I enter product name: saved as MyProductName
Given in the Product Identification page I select Product Line/Brand: test4 and if it does not exist I create it
Given in the Product Identification page I select Category: Health and Beauty
Then in the Product Identification page I should see message: Your product qualifies for a GoodGuide rating, a trusted indicator of product health. At the end of this registration, take a moment to preview and optionally add this product’s rating to the extensive GoodGuide online catalog, consumers' reliable resource for science-based product information. To learn more, visit http://www.goodguide.com
Given in the Product Identification page I select SubCategory: After Shave for Men
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the Product Formulation & Public Disclosure Review page should load
Then in the GoodGuide site I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water         | 100     | false               | false       |            |
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the Physical Property page should load
Then in the Physical Property page I select physical state: Liquid
Then in the Physical Property page I enter product pH: 2.7
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the Marks of Distinction page should load
Then in the Marks of Distinction page I should see rating: 10
Given in the Marks of Distinction page for Would you like to continue with the product submission process I select: Yes
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the Company/Brand Information page should load
Given in the Company/Brand Information page I upload Company logo: C:\Dependencies\WERCSmart\image1.jpg
Given in the Company/Brand Information page I upload Brand logo: C:\Dependencies\WERCSmart\image2.jpg
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the UPC List page should load
#Enter UPC
Given I generate a random UPC number and save as: UPC68913
Given in the GoodGuide site I click the 'Add UPC' button
Then In the GoodGuide site I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC68913 |
| ContainerType | Aerosol Can       |
| Size          | 20                |
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site I should be in the UPC Grid
Given in the UPC Grid I click edit
Given in the UPC Grid in the GoodGuide drop down I select: Yes
Given in the UPC Grid in the Colour drop down I select: Blue to red
Given in the UPC Grid in the Scent drop down I select: Apple
Given in the UPC Grid in the Image upload I select: C:\Dependencies\WERCSmart\image1.jpg
Given in the GoodGuide New Product page I click button: Save and Next
Then in the GoodGuide site the Summary page should load
Then in the Data Acceptance section I answer: Yes to would you like to submit product info
Then in the Data Acceptance section I click on Accept
Then in the GoodGuide site the Subscription Enrollment page should load
#Should be in shopping cart
#Click Submit Order
Given on the top navigation bar I click on My Products
Then in the GoodGuide site the My Products page should load
Given in the GoodGuide My Products page I set the search criteria as follows:
| Search By           | Filter                 | UPC | Status |
| WPS ID/Product Name | saved as MyProductName |     | All    |
Given in the GoodGuide My Products page I click on Filter
Then in the GoodGuide My Products page I should see product with Name: saved as MyProductName
Then in the GoodGuide My Products page I delete product with Name: saved as MyProductName
Then in the GoodGuide My Products page I should not see product with Name: saved as MyProductName

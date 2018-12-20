@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@ULSC

@run_ULSCServices

Feature: ULSC Services

Background:


Scenario: [23327] WERCSLink - WERCSmart - My Products Page Shows OK
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
And In the WERCSLink dashboard I click left menu link: My Products
And I Confirm the WerCSMart Product Information page is shown in new window/tab
And I close the tab with the Product Information page
Given I navigate to tab with title: Services
And In the WERCSLink page - Click the My Product link from the WERCSmart area of the Services page
And I Confirm the WerCSMart Product Information page is shown in new window/tab
And I close the tab with the Product Information page

# Created by Beverly Barrett
# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard\2.6 Services (new)\2.6.1 WERCSmart (updated)
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard\2.6 Services\2.6.1 WERCSmart

@NewProduct
Scenario: [23328] WERCSLink - WERCSmart -  Request New Assessment
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
And In the WERCSLink dashboard I click left menu link: Register New Product
And I Confirm a new window opens with the WERCSmart New Product page shown
And I set the Select the type of product to create field to: Create a New Registration
And in the New Product page I click Continue
And I should see the The Product Page
And I close the tab with the The Product page
Given I navigate to tab with title: Services
And In the WERCSLink page - Click the Register New Product link from the WERCSmart area of the Services page
And I Confirm a new window opens with the WERCSmart New Product page shown
And I close the tab with the New Product page

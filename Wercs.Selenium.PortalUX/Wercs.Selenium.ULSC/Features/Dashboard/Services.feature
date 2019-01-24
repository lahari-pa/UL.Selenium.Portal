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
And In the WERCSLink page - Click the My Products link from the WERCSmart area of the Services page
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

# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard\2.6 Services (new)
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard\2.6 Services

Scenario: [53102] Services - Screen layout checks
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
And I confirm that the WERCSLink header appears at the top left
And I confirm that the following WERCSLink menu items are showing
| Menu item                  |
| Dashboard                  |
| Key Performance Indicators |
| Recent Activities          |
| Product Lookup             |
| Services                   |
And I confirm that the WERCSLink screen shows the following sections
| Section                |
| WERCSmart®             |
| Self-Service Authoring |
| WERCS Studio           |
| Branded Materials      |
And I confirm the WERCSmart area shows the WERCSmart logo, name and Registered trade mark
And I confirm that in the WERCSmart® area the description text reads Provide data for WERCS mart ® review and recipients Get resources, enter data, manage and submit requested information in WERCS mart ®
And I confirm that in the WERCSmart® area the following links exist:
| Link title           | Link icon |
| My Products          | flask     |
| Register new product | file      |
And I confirm that in the WERCSmart® area the following subheadings appear:
| Subheading              |
| New Product Assessments |
And I confirm that in the WERCSmart® area the following images appear:
| Image          |
| wercsmart-logo |
| IandI          |
#And I Confirm the middle section of the Services screen is split into two sections - top will be the Self-Service Authoring section and the bottom will be the Branded Materials section
#And I confirm the Self-Service Authoring icon and heading is shown at the top of the top middle section
And I confirm that in the Self-Service Authoring area the description text reads Your direct connection with professional services Order your regional GHS Safety Data Sheets via an online submssion tool
And I confirm that in the Self-Service Authoring area the following links exist:
| Link title | Link icon     |
| Authoring  | pencil-square |
And I confirm that in the Self-Service Authoring area the following images appear:
| Image               |
| self-authoring-logo |
| IandI               |
#And I Confirm the lower portion of the middle section of the screen shows the Branded Materials logo and heading
And I confirm that in the Branded Materials area the description text reads Make your unique branded materials available in WERCSmart® Allow your unique component attributes to be accessible to the public or assign them as permission-only
And I confirm that in the Branded Materials area the following links exist:
| Link title        | Link icon |
| Branded Materials | tag       |
And I confirm that in the Branded Materials area the following images appear:
| Image        |
| branded-logo |
| IandI        |
#And I confirm the Right hand section of the screen shows the WERCS Studio logo and name
And I confirm that in the WERCS Studio area the description text reads Product data and documents in your private database Manage, report and distribute product information from your private Studio database.

And I confirm that in the WERCS Studio area the following links exist:
| Link title      | Link icon |
| Data Management | calendar  |
| Reports         | print     |
| Studio Home     | home      |
| Mappings        | map       |
And I confirm that in the WERCS Studio area the following images appear:
| Image  |
| studio |
| IandI  |

# Created by Beverly Barrett
# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard\2.6 Services (new)\2.6.2 Self-Service Authoring (updated)
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard\2.6 Services\2.6.2 Self Service Authoring


Scenario: [23331] WERCSLink - Self-Service Authoring  - Authoring
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
#CLF - these steps have been removed because the menu links are being removed
#And In the WERCSLink dashboard I click left menu link: Self-Service Authoring
#And I Confirm you see a new links below the Self-Service Authoring link for Authoring
#And In the WERCSLink dashboard I click left menu link: Authoring
#And I confirm a new window opens with the ULGHS.com page shown
#And I close the tab with the ULGHS.COM page
And In the WERCSLink page - Click the Authoring link from the WERCSmart area of the Services page
And I confirm a new window opens with the ULGHS.com page shown
And I close the tab with the ULGHS.COM page

# Created by Beverly Barrett

# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard\2.6 Services (new)\2.6.4 WERCS Studio
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard\2.6 Services\2.6.4 WERCS Studio

Scenario: [24436] WERCSLink - WERCS Studio - Data Management
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
And In the WERCSLink dashboard I click left menu link: WERCS Studio
And I Click the Data Management link in the navigation pane
And I Confirm New window opens with the Studio Data Management window open (Welcome page shows) and that NO script errors display
And I Select a Format/Subformat
And I Click Continue
And I Close the Data Management window
And I Click the Data Management link on the right hand side of the Services page under the WERCS Studio heading
And I Confirm New window opens with the Studio Data Management window open (Welcome page shows) and that NO script errors display
And I Select a Format/Subformat
And I Click Continue
And [Shared Step 30118 - ULSC - Close Open Portal or Studio page and logout of ULSC]

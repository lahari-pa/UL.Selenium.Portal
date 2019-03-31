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
@Studio
@MyAccount
@PackagingTypes
@run_SHALowerOptions

Feature: Lower Options (Suite ID: 26834)

# Created by Paulina Mata
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\SHA Manager\Lower Options

Scenario: [74948] Advance Search- pH range drop down filter
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I set the filter for status to : Assigned

And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue     |
| RecommendedUse | All             |
| PHRange        | Select pH Range |
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | <= 2        |
And I confirm the top 10 products all have PH Range of: <= 2
And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | 2.1 - 3.9   |
#And I Confirm  the list of products is updated according to the pH search
And I confirm the top 10 products all have PH Range of: 2.1 - 3.9
And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | 4 - 6.9     |
And I confirm the top 10 products all have PH Range of: 4 - 6.9

And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | 7 (Neutral) |
And I confirm the top 10 products all have PH Range of: 7 (Neutral)
And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | 7.1 - 9.9   |
And I confirm the top 10 products all have PH Range of: 7.1 - 9.9
And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | 10 - 12.4   |
And I confirm the top 10 products all have PH Range of: 10 - 12.4
And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue |
| RecommendedUse | All         |
| PHRange        | >= 12.5     |
And I confirm the top 10 products all have PH Range of: >= 12.5
And I call Shared Step 59066 (Go to SHA Manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue        |
| RecommendedUse | All                |
| PHRange        | Not tested/Unknown |
#And I Confirm  the list of products is updated according to the pH search

# Created by Paulina Mata

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\SHA Manager\Lower Options

Scenario: [75034] Srch - Identifier for Packaging Types
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I navigate to the MyAccount page
And In the My Account screen I navigate to the My Library page
And I navigate to the My Packaging Types tab in the My Library page
And Save the top packaging id as MPI75034 if there are no packacking types listed add a new packing type as follows
| Name | Materials   | Weight | Contact with food or drink | CONEG Certificate | CONEG contain     | Recyclable Number | Email         |
| test | Clear Glass | 60     | No                         | No                | None of the above | 2                 | test@test.com |
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm | SearchValue                      |
| Status     | All                              |
| ProductID  | savedas PackagingTypeID_MPI75034 |
And In SHA Manager 1 record is found
And In SHA Manager for the top record the values are as follows
| SearchTerm  | SearchValue                        |
| Product     | savedas PackagingTypeID_MPI75034   |
| Name        | savedas PackagingTypeName_MPI75034 |
| Distributor | P                                  |


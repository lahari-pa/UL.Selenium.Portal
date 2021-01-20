@Shared
@SHA
@Studio
@run_RejectSubmission

Feature: RejectSubmission

Scenario: [143638] Reject Submission - Product Name is Unclear

Given I Save the email for the TReVor: ProductAccount Test user as: AdminEmailAddress
Given I save the current emails in the inbox for address saved as: AdminEmailAddress
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm | SearchValue       |
| Status     | Submitted         |
| User       | AdminEmailAddress |
Given In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Reject Submission
And In the Reject Submission dialog I Select Subject: Product Name is Unclear
And In the Reject Submission dialog in the Supplier Message field I should see: During our assessment and data creation the product name may generate delays and confusion to your retail clients. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Product names are important when the packaging may be unavailable to the retail employee, Please login to WERCSmart and update the product name. For guidance: the name should be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. you may include Model Numbers or other identifying information, as long the Product Name is not solely the product's model number, nor should it be overly generic in nature.
Given In the Reject Submission dialog I click Save
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: ULSCN.Notifications@ULNotification.com with the title: Notification - Product <ID> - Product Name is Unclear
Given For product saved as: ID the html of the email should show: Your product assessment is on hold - <ID>. During our assessment and data creation the product name may generate delays and confusion to your retail clients. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Product names are important when the packaging may be unavailable to the retail employee, Please login to WERCSmart and update the product name. For guidance: the name should be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. you may include Model Numbers or other identifying information, as long the Product Name is not solely the product's model number, nor should it be overly generic in nature. If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753.

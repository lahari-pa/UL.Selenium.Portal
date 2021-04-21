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
Given For product saved as: ID I should see an alert with the following message: Product Message for product <ID> has been created succesfully.
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: ULSCN.Notifications@ULNotification.com with the title: Notification - Product <ID> - Product Name is Unclear
Given For product saved as: ID the html of the email should show: Your product assessment is on hold - <ID>. During our assessment and data creation the product name may generate delays and confusion to your retail clients. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Product names are important when the packaging may be unavailable to the retail employee, Please login to WERCSmart and update the product name. For guidance: the name should be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. you may include Model Numbers or other identifying information, as long the Product Name is not solely the product's model number, nor should it be overly generic in nature. If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753.


Scenario: [143499] Reject Submission - Transportation Information – Missing Base Classification before Exemption or Exception

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
And In the Reject Submission dialog I Select Subject: Transportation Information – Missing Base Classification before Exemption or Exception
And In the Reject Submission dialog in the Supplier Message field I should see: During the assessment and data creation for your product, we have found some information is missing. Please ensure the following is provided, even if exemption or exception applies: - UN Number - Proper Shipping Name - Technical Name (If applicable) - Packing Group - Limited Quantity (if applicable) - Any other applicable exceptions, exemptions or special permits Effective December 31, 2020, U.S. Transport no longer permits the election of Consumer Commodity (ORM-D) as an exemption. Please be sure to revise your registration accordingly and resubmit any revisions.
Given In the Reject Submission dialog in the Subject field I should see: Transportation Information – Missing Base Classification before Exemption or Exception
Given In the Reject Submission dialog I click Save
Given For product saved as: ID I should see an alert with the following message: Product Message for product <ID> has been created succesfully.
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: NoReply@UL.com with the title: Notification - Product <ID> - Transportation Information – Missing Base Classification before Exemption or Exception
Given For product saved as: ID the html of the email should show: Your product assessment has been Suspended. During the assessment and data creation for your product, we have found some information is missing. Please ensure the following is provided, even if exemption or exception applies: - UN Number - Proper Shipping Name - Technical Name (If applicable) - Packing Group - Limited Quantity (if applicable) - Any other applicable exceptions, exemptions or special permits Effective December 31, 2020, U.S. Transport no longer permits the election of Consumer Commodity (ORM-D) as an exemption. Please be sure to revise your registration accordingly and resubmit any revisions. To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or by calling 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team This e-mail may contain privileged or confidential information. If you are not the intended recipient: (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify the sender by reply e-mail, and then delete this message and its attachment(s). Underwriters Laboratories Inc. and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachments.

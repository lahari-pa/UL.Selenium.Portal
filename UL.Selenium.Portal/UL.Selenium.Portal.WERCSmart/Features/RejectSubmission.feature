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



@ScenarioId:10783
Scenario: [143507] Reject Submission - Volatile Organic Compound (VOC) Issue within Registration

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
And In the Reject Submission dialog I Select Subject: Volatile Organic Compound (VOC) Issue within Registration
And In the Reject Submission dialog in the Supplier Message field I should see: During the assessment and data creation for your product, we found the VOC (Volatile Organic Compounds) may be compliant and still require your confirmation. This secondary confirmation or clarification is needed due to the risk to retailers selling VOC products across multiple regions. Does not exceed the limits specified in the California Consumer Products Regulation Does not exceed the limits specified by the Ozone Transportation Commission Does not exceed the limits specified in the Aerosol Coatings by the CARB Does not exceed the limits specifically by the South Coast Air Quality Management District Exceeds the limits specified in the California Consumer Products Regulation Exceeds the limits specified by the South Coast Air Quality Management District Exceeds the limits specified by the Ozone Transport Commission Exceeds the limits specified in the Aerosol Coatings by the CARB An Alternative Control Plan was claimed but the uploaded documentation does not support this claim. Please rectify by either uploading the documentation or revise the submission to not use the Alternative Control Plan.
Given In the Reject Submission dialog I click Save
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: NoReply@UL.com with the title: Notification - Product <ID> - Volatile Organic Compound (VOC) Issue within Registration
Given For product saved as: ID the html of the email should show: Your product assessment has been Suspended. During the assessment and data creation for your product, we found the VOC (Volatile Organic Compounds) may be compliant and still require your confirmation. This secondary confirmation or clarification is needed due to the risk to retailers selling VOC products across multiple regions. Does not exceed the limits specified in the California Consumer Products Regulation Does not exceed the limits specified by the Ozone Transportation Commission Does not exceed the limits specified in the Aerosol Coatings by the CARB Does not exceed the limits specifically by the South Coast Air Quality Management District Exceeds the limits specified in the California Consumer Products Regulation Exceeds the limits specified by the South Coast Air Quality Management District Exceeds the limits specified by the Ozone Transport Commission Exceeds the limits specified in the Aerosol Coatings by the CARB An Alternative Control Plan was claimed but the uploaded documentation does not support this claim. Please rectify by either uploading the documentation or revise the submission to not use the Alternative Control Plan. To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or by calling 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team

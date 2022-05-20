@Shared
@SHA
@Studio
@ProductSetUp
@run_RejectSubmission

Feature: RejectSubmission

@ignore
@TestCase:143638
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

#@ignore
@TestCase:143386
Scenario: [143386] Reject Submission - Document (Safety Data Sheet) is not Compliant with UN Globally Harmonized Standard (GHS)

Given I Save the email for the TReVor: ProductAccount Test user as: AdminEmailAddress
Given I save the current emails in the inbox for address saved as: AdminEmailAddress
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm | SearchValue       |
| Status     | Submitted         |
| User       | last-frozen.kxxyxunf@mailosaur.io |
Given In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Reject Submission
And In the Reject Submission dialog I Select Subject: Document (Safety Data Sheet) is not Compliant with UN Globally Harmonized Standard (GHS)
And In the Reject Submission dialog in the Supplier Message field I should see: The document provided is not compliant with the current OSHA HazCom 2012 Standard. The Standard is outlined in OSHA’s website (https://www.osha.gov/dsg/hazcom/hazcom-appendix-d.html). The document may not compliant for and or all of the following reason(s) and we encourage you to review the OSHA website for compliance requirements: - The document provided is not a 16-Section SDS per the OSHA Standard, with headers outlined in Appendix D of 29 CFR 1910.1200. - The product is not classified for GHS or the signal words, pictograms and hazard statements are not consistent or are missing (Section 2). Please refer to Appendix C (https://www.osha.gov/dsg/hazcom/hazcom-appendix-c.html ). - The product is regulated for transport, yet no corresponding GHS Classification is identified (Section 2 and Section 14).
Given In the Reject Submission dialog I click Save
Given For product saved as: ID I should see an alert with the following message: Product Message for product ID has been created successfully
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: noreply@wercsmart.ul.com with the title: Notification - Product <ID> - Document (Safety Data Sheet) is not Compliant with UN Globally Harmonized Standard (GHS)
Given For product saved as: ID the html of the email should show: This product ID has been sent back for correction. The document provided is not compliant with the current OSHA HazCom 2012 Standard. The Standard is outlined in OSHA’s website (https://www.osha.gov/dsg/hazcom/hazcom-appendix-d.html). The document may not compliant for and or all of the following reason(s) and we encourage you to review the OSHA website for compliance requirements: - The document provided is not a 16-Section SDS per the OSHA Standard, with headers outlined in Appendix D of 29 CFR 1910.1200. - The product is not classified for GHS or the signal words, pictograms and hazard statements are not consistent or are missing (Section 2). Please refer to Appendix C (https://www.osha.gov/dsg/hazcom/hazcom-appendix-c.html ). - The product is regulated for transport, yet no corresponding GHS Classification is identified (Section 2 and Section 14). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. If you have questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or by calling 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team

@ignore
@TestCase:143499
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

@ignore
@TestCase:143470
Scenario: [143470] Reject Submission - Ingredient Issue - Document and Ingredients Do Not Match

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
And In the Reject Submission dialog I Select Subject: Ingredient Issue - Document and Ingredients Do Not Match
And In the Reject Submission dialog in the Supplier Message field I should see: During our assessment and data creation we have found a discrepancy between the formulation submitted to WERCSmart and the document (Label or Safety Data Sheet). The document includes a missing/incorrect ingredient missing from the formulation. Please update the ingredient(s) below. (Assessment Team to insert ingredients) Please update the formulation to reflect the ingredients found on the documentation provided with this product. All ingredients found on a GHS SDS should be present in the WERCSmart submission, and they need to match the percentage, or within the range, found on the document.
And In the Reject Submission dialog in the Supplier Message field I replace the following text: (Assessment Team to insert ingredients) with: (Water)
Given In the Reject Submission dialog in the Subject field I should see: Ingredient Issue - Document and Ingredients Do Not Match
Given In the Reject Submission dialog I click Save
Given For product saved as: ID I should see an alert with the following message: Product Message for product <ID> has been created succesfully.
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: NoReply@UL.com with the title: Notification - Product <ID> - Ingredient Issue - Document and Ingredients Do Not Match
Given For product saved as: ID the html of the email should show: Your product assessment has been Suspended. During our assessment and data creation we have found a discrepancy between the formulation submitted to WERCSmart and the document (Label or Safety Data Sheet). The document includes a missing/incorrect ingredient missing from the formulation. Please update the ingredient(s) below. (Water) Please update the formulation to reflect the ingredients found on the documentation provided with this product. All ingredients found on a GHS SDS should be present in the WERCSmart submission, and they need to match the percentage, or within the range, found on the document. To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or by calling 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team This e-mail may contain privileged or confidential information. If you are not the intended recipient: (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify the sender by reply e-mail, and then delete this message and its attachment(s). Underwriters Laboratories Inc. and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachments.

@ignore
@TestCase:143507
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
Given For product saved as: ID I should see an alert with the following message: Product Message for product <ID> has been created succesfully.
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: NoReply@UL.com with the title: Notification - Product <ID> - Volatile Organic Compound (VOC) Issue within Registration
Given For product saved as: ID the html of the email should show: Your product assessment has been Suspended. During the assessment and data creation for your product, we found the VOC (Volatile Organic Compounds) may be compliant and still require your confirmation. This secondary confirmation or clarification is needed due to the risk to retailers selling VOC products across multiple regions. Does not exceed the limits specified in the California Consumer Products Regulation Does not exceed the limits specified by the Ozone Transportation Commission Does not exceed the limits specified in the Aerosol Coatings by the CARB Does not exceed the limits specifically by the South Coast Air Quality Management District Exceeds the limits specified in the California Consumer Products Regulation Exceeds the limits specified by the South Coast Air Quality Management District Exceeds the limits specified by the Ozone Transport Commission Exceeds the limits specified in the Aerosol Coatings by the CARB An Alternative Control Plan was claimed but the uploaded documentation does not support this claim. Please rectify by either uploading the documentation or revise the submission to not use the Alternative Control Plan. To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or by calling 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team


@ignore
@TestCase:143390
Scenario: [143390] Reject Submission - Flash Point - Safety Data Sheet (SDS) or Article Information Sheet (AIS) Discrepancy
Then Using Test case 75142, I create a NEW PRODUCT and move it into Submitted status in SHA
Given I navigate to the landing page
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
And In the Reject Submission dialog I Select Subject: Flash Point - Safety Data Sheet (SDS) or Article Information Sheet (AIS) Discrepancy
And In the Reject Submission dialog in the Supplier Message field I should see: During our assessment and data collection we have found the flash point value provided during WERCSmart registration process does not match the document. This impacts the storage data provided to the Recipient and may also impact the transportation classification and the shipping description of the product.
Given In the Reject Submission dialog in the Subject field I should see: Flash Point - Safety Data Sheet (SDS) or Article Information Sheet (AIS) Discrepancy
Given In the Reject Submission dialog I click Save
Given For product saved as: ID I should see an alert with the following message: Product Message for product <ID> has been created successfully.
And I close alert
Given For product saved as: ID there should be a new email for email Address saved as: AdminEmailAddress from: NoReply@wercsmart.UL.com with the title: Notification - Product <ID> - Flash Point - Safety Data Sheet (SDS) or Article Information Sheet (AIS) Discrepancy
Given For product saved as: ID the html of the email should show: Your product assessment has been Suspended. During our assessment and data collection we have found the flash point value provided during WERCSmart registration process does not match the document. This impacts the storage data provided to the Recipient and may also impact the transportation classification and the shipping description of the product. To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages. For this suspension please update the flash point to be the same value as found on your Safety Data Sheet (Section 9) appropriate to Celsius and Fahrenheit. The flash point is typically found in Section 9 on a GHS (Globally Harmonized Standard) SDS (Safety Data Sheet). Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or by calling 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team

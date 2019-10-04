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
@Studio
@Portal_ShaManager
@run_Suspended

Feature: Suspended (Suite ID: 69545)

@SHA
@TReVorId:21901
Scenario: [69547] Suspend a Product - Formula - Other
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Formula – Other
And In the Suspended dialog in the Supplier Message field I should see: The issue with the composition data is: _________
And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
And In the Suspended dialog in the Internal Product Note field I should see: The issue with the composition data is: _________
And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
And In the Suspended dialog I click Save
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
And In the SHA manager grid I right click against product saved as: ID
And In the SHA manager grid when the right click context menu is open I select option: Notification History
Then In the Notification History Screen I confirm that one of the rows is as follows:
| Type      | Notification Date | Subject         |
| Suspended | Today             | Formula – Other |
And In the Notification History Screen I click on the most recent notification
And In the Notification History Detail Screen I confirm that details are as follows
| Subject         | Message                | Notification Date |
| Formula – Other | The issue with the composition data is: _________ supplier message input | Today             |

@SHA
@TReVorId:21904
Scenario: [69549] Suspend a Product - Formula - Document Issue
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Formula – Document Issue
And In the Suspended dialog in the Supplier Message field I should see: The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue.
And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
And In the Suspended dialog in the Internal Product Note field I should see: The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue.
And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
And In the Suspended dialog I click Save
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
And In the SHA manager grid I right click against product saved as: ID
And In the SHA manager grid when the right click context menu is open I select option: Notification History
Then In the Notification History Screen I confirm that one of the rows is as follows:
| Type      | Notification Date | Subject                  |
| Suspended | Today             | Formula – Document Issue |
And In the Notification History Screen I click on the most recent notification
And In the Notification History Detail Screen I confirm that details are as follows
| Subject                  | Message                                                                                                                                                                                                      | Notification Date |
| Formula – Document Issue | The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue. supplier message input | Today             |

@TReVorId:21906
Scenario: [86014] Suspend a Product - Product Name
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I set the filter for status to : Assigned
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Registration Suspension for Product Name
And In the Suspended dialog in the Supplier Message field I should see: Your recent registration is suspended, awaiting your update and resubmission, so that you may update the Product Name on the registration. Retailers require the Product Name in the WERCSmart registration be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. It is possible that the packaging may be unavailable as well. Because of this, the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. As a Product Name, although you may include Model Numbers or other identifying information, the Product Name cannot solely be the product's model number, nor should it be overly generic in nature. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Please log into your WERCSmart account and review your Suspended Items in the My Messages area so that you may update and resubmit the information. This will allow the Assessment process to proceed and minimize further delay in meeting your Retailer's requirements with regard to WERCSmart registration. If you have questions about this process you may refer to our Support Center, or contact a Support Representative (WERCSmartCustomer@UL.com). Thank you for your prompt attention to this matter. The WERCSmart Assessment Team
And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
And In the Suspended dialog in the Internal Product Note field I should see: Your recent registration is suspended, awaiting your update and resubmission, so that you may update the Product Name on the registration. Retailers require the Product Name in the WERCSmart registration be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. It is possible that the packaging may be unavailable as well. Because of this, the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. As a Product Name, although you may include Model Numbers or other identifying information, the Product Name cannot solely be the product's model number, nor should it be overly generic in nature. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Please log into your WERCSmart account and review your Suspended Items in the My Messages area so that you may update and resubmit the information. This will allow the Assessment process to proceed and minimize further delay in meeting your Retailer's requirements with regard to WERCSmart registration. If you have questions about this process you may refer to our Support Center, or contact a Support Representative (WERCSmartCustomer@UL.com). Thank you for your prompt attention to this matter. The WERCSmart Assessment Team
And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
And In the Suspended dialog I click Save
And I check alert text contains recertification and dismiss
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
And I verify the product saved as: ID displays in red with a red box around it
And In the SHA manager grid I right click against product saved as: ID
And In the SHA manager grid when the right click context menu is open I select option: Notification History
Then In the Notification History Screen I confirm that one of the rows is as follows:
| Type      | Notification Date | Subject                                  |
| Suspended | Today             | Registration Suspension for Product Name |
And In the Notification History Screen I click on the most recent notification
And In the Notification History Detail Screen I confirm that details are as follows
| Subject                                  | Message                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | Notification Date |
| Registration Suspension for Product Name | Your recent registration is suspended, awaiting your update and resubmission, so that you may update the Product Name on the registration. Retailers require the Product Name in the WERCSmart registration be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. It is possible that the packaging may be unavailable as well. Because of this, the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. As a Product Name, although you may include Model Numbers or other identifying information, the Product Name cannot solely be the product's model number, nor should it be overly generic in nature. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Please log into your WERCSmart account and review your Suspended Items in the My Messages area so that you may update and resubmit the information. This will allow the Assessment process to proceed and minimize further delay in meeting your Retailer's requirements with regard to WERCSmart registration. If you have questions about this process you may refer to our Support Center, or contact a Support Representative (WERCSmartCustomer@UL.com). Thank you for your prompt attention to this matter. The WERCSmart Assessment Team supplier message input | Today             |
And In the Notification History Detail Screen I click on: Close
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
Given In SHA Manager I select the following products:
| ProductID   |
| saved as ID |
And In SHA Manager grid I click the following top menu item: Add to Recertification
Then The Add Product to Recertification screen should be showing
Then in the Add Product to Recertification screen only the following Reasons are selected:
| Reason |
| 20.    |
Then in the Add Product to Recertification screen only the following allow users checkboxes are selected:
| Checkbox                                          |
| Allow user update Product NAME on Recertification |

@TReVorId:21907
Scenario: [69550] Suspend a Product - Delete Supplier Message
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Formula – Document Issue
And In the Suspended dialog in the Supplier Message field I enter the following text: supplier message input
And In the Suspended dialog in the Internal Product Note field I enter the following text: internal product note input
And In the Suspended dialog I click Save
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
And In the SHA manager grid I right click against product saved as: ID
And In the SHA manager grid when the right click context menu is open I select option: Notification History
Then In the Notification History Screen I confirm that one of the rows is as follows:
| Type      | Notification Date | Subject                  |
| Suspended | Today             | Formula – Document Issue |
And In the Notification History Screen I click on the most recent notification
And In the Notification History Detail Screen I confirm that details are as follows
| Subject                  | Message                | Notification Date |
| Formula – Document Issue | supplier message input | Today             |

@TReVorId:21908
Scenario: [69548] Suspend a Product - Transportation Classification
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I set the filter for status to : Assigned
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Transportation Classification
And In the Suspended dialog in the Supplier Message field I should see: Please ensure the following is provided, even if exemption or exception applies; UN number, proper shipping name, technical name (if applicable), packing group and if Limited quantity or consumer commodity is being applied.
And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
And In the Suspended dialog in the Internal Product Note field I should see: Please ensure the following is provided, even if exemption or exception applies; UN number, proper shipping name, technical name (if applicable), packing group and if Limited quantity or consumer commodity is being applied.
And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
And In the Suspended dialog I click Save
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
And In the SHA manager grid I right click against product saved as: ID
And In the SHA manager grid when the right click context menu is open I select option: Notification History
Then In the Notification History Screen I confirm that one of the rows is as follows:
| Type      | Notification Date | Subject                  |
| Suspended | Today             | Transportation Classification |
And In the Notification History Screen I click on the most recent notification
And In the Notification History Detail Screen I confirm that details are as follows
| Subject                       | Message                                                                                                                                                                                                                                                | Notification Date |
| Transportation Classification | Please ensure the following is provided, even if exemption or exception applies; UN number, proper shipping name, technical name (if applicable), packing group and if Limited quantity or consumer commodity is being applied. supplier message input | Today             |

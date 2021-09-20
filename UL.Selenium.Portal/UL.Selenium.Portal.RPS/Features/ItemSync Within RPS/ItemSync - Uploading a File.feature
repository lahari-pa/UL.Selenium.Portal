@RPS
@Login
@run_ItemSync_Uploading_a_File
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@RecentActivities
@RPSSHA
@ItemSync


Feature: ItemSync - Uploading a File

@ScenarioId:10338
Scenario: [125577] Base functionality - ItemSync - Upload a file - Screen layout - Message shown
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then I confirm the ItemSync Upload a File screen displays the message: Please select a file of UPCs to upload. If the file contains any items that are deemed invalid, the valid UPCs in the file will still process, and the invalid items will be identified and highlighted, allowing you to then make the appropriate changes to the file.
Given I call Shared Step 106194 (RPS Sign out)

#The check for the upload area, especially the drag and drop might not be robust (class check)
@ScenarioId:10339
Scenario: [125582] Base functionality - ItemSync - Upload a file - Screen layout - File Upload area - Drag and Drop area
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then I confirm the ItemSync Upload a File screen shows a File Upload Area
#Shows a drag and drop area -> how check
Then I confirm the ItemSync Upload a File screen, File Upload Area shows a drag and drop area
And I confirm the ItemSync Upload a File screen, File Upload Area shows The Description Text: Drag file here or browse
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10341
Scenario: [125586] Base functionality - ItemSync - Upload a file - Screen layout - File Upload area - Drag and Drop area - Browse link
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then I confirm the ItemSync Upload a File screen shows a File Upload Area
Then I confirm the ItemSync Upload a File screen, File Upload Area contains a browse Link
And I confirm the ItemSync Upload a File screen, File Upload Area shows The Description Text: Drag file here or browse
Then I check file browser
#Not checking the file popup as this is chrome? Not sure Ask chris again
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10379
Scenario: [125587] Base functionality - ItemSync - Upload a file - Screen layout - File Upload area - File selected from Browse link
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then In the ItemSync Upload a File screen, I click the File Upload area and open the File: TestMultipleUPCs.csv
Then I confirm the ItemSync Upload a File screen does not show a File Upload Area
Then In the ItemSync Upload a File screen, I confirm below the user message area, I see a file icon
Then In the ItemSync Upload a File screen, I confirm The selected filename shows as: TestMultipleUPCs.csv
Given I call Shared Step 106194 (RPS Sign out)

@tfs_design
#Can not automate, includes a file drag and drop
@ScenarioId:11239
Scenario: [125588]Base functionality - ItemSync - Upload a file - File Upload area - File selected from drag and drop
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown

@ScenarioId:10381
Scenario: [125590] Base functionality - ItemSync - Upload a file - File Upload area - File selected from Browse link - remove file
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then In the ItemSync Upload a File screen, I click the File Upload area and open the File: TestMultipleUPCs.csv
Then I call Shared Step 125598 (ItemSync - Upload a File - Remove icon - page refreshes)
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10382
Scenario: [125639] Base functionality - ItemSync - Upload a file - File selected from Browse link - Upload button is shown
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then In the ItemSync Upload a File screen, I click the File Upload area and open the File: TestMultipleUPCs.csv
Then In the ItemSync Upload a File screen, I see the upload button
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10384
Scenario: [125641] Base functionality - ItemSync - Upload a file - File selected from Browse link - Upload - Loading indicator
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then In the ItemSync Upload a File screen, I click the File Upload area and open the File: TestMultipleUPCs.csv
And In the ItemSync Upload a File screen, I click the 'Upload' button
Then In the ItemSync Upload a File screen, I see the Upload Loading indicator
Given I call Shared Step 106194 (RPS Sign out)












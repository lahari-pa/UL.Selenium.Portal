@RPS
@Login
@run_ItemSync_Manual_Entry
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


Feature: ItemSync - Manual Entry

@ScenarioId:10388
Scenario: [125705] Base functionality - ItemSync - Manual Entry - Screen layout - initial display

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Manual Entry
And I wait for the ItemSync Manual Entry screen to load
Then I confirm the ItemSync manual entry screen is shown with the title: Add UPC
Then In the ItemSync manual entry screen, I see a Text entry field with the default text: 'Enter your UPC'
Then In the ItemSync Manual Entry screen, I confirm I see an 'ADD' button
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10397
Scenario: [125706] Base functionality - ItemSync - Manual Entry - Invalid UPC entered 
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then In the ItemSync Manual Entry screen, I enter: 123456789 into the UPC entry field
Then In the ItemSync Manual Entry screen, I Click the 'ADD' button
Then In the ItemSync Manual Entry screen, I confirm the message: Please ensure your UPC is 12 or 14 digits is shown
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10401
Scenario: [125707] Base functionality - ItemSync - Manual Entry - Valid UPC entered - grid layout
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC)
And In the ItemSync Manual Entry screenm I confirm I see a UPC Grid
Then In the ItemSync Manual Entry screenm I confirm the UPC Grid contains one column and its heading is 'UPC'
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as currentRandomUPC
Then In the ItemSync Manual Entry screen I confirm that to the right of the UPC: saved as currentRandomUPC I see a 'Remove' Icon
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10402
Scenario: [125710] Base functionality - ItemSync - Manual Entry - Remove valid UPC from UPC grid - only 1 UPC present
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC)
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as currentRandomUPC
Then In the ItemSync Manual Entry screen I confirm that to the right of the UPC: saved as currentRandomUPC I Click the 'Remove' Icon
And In the ItemSync Manual Entry screenm I confirm I do not see a UPC Grid
Then In the ItemSync manual entry screen, I see a Text entry field with the default text: 'Enter your UPC'
Then In the ItemSync Manual Entry screen, I confirm I see an 'ADD' button
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10403
Scenario: [125708] Base functionality - ItemSync - Manual Entry - Remove valid UPC from UPC grid - > 1 UPC present
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I generate a random UPC number and save as: UPC125708A
Then I generate a random UPC number and save as: UPC125708B
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125708A
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as UPC125708A
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125708B
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as UPC125708B
Then In the ItemSync Manual Entry screen I confirm that to the right of the UPC: saved as UPC125708B I Click the 'Remove' Icon
Then In the ItemSync Manual Entry screen I confirm the UPC Grid does not contain the UPC: saved as UPC125708B
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as UPC125708A
Then In the ItemSync manual entry screen, I see a Text entry field with the default text: 'Enter your UPC'
Then In the ItemSync Manual Entry screen, I confirm I see an 'ADD' button
Given I call Shared Step 106194 (RPS Sign out)


@ScenarioId:10404
Scenario: [125711] Base functionality - ItemSync - Manual Entry - Valid UPC entered - Upload Button

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC)
And In the ItemSync Manual Entry screenm I confirm I see a UPC Grid
Then In the ItemSync Manual Entry screen, I confirm I see an 'Upload' button
Given I call Shared Step 106194 (RPS Sign out)

@tfs_design
@ScenarioId:10425
Scenario: [125712] Base functionality - ItemSync - Manual Entry - Upload - "working" indicator
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I generate a random UPC number and save as: UPC125708A
Then I generate a random UPC number and save as: UPC125708B
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125708A
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as UPC125708A
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125708B
Then In the ItemSync Manual Entry screen I confirm the UPC Grid contains the UPC: saved as UPC125708B
Then In the ItemSync Manual Entry screen, I confirm I see an 'Upload' button
And In the ItemSync Manual Entry screen, I Click the Upload Button
Then In the ItemSync Manual Entry screen, I see the Upload Loading indicator
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10426
Scenario: [125713] Base functionality - ItemSync - Manual Entry - UPCs Remaining count

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I generate a random UPC number and save as: UPC125713A
Then I generate a random UPC number and save as: UPC125713B
Then I generate a random UPC number and save as: UPC125713C

Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125713A
Then In the ItemSync Manual Entry screen, I confirm I see the UPCs remaining count
Then In the ItemSync Manual Entry screen, I confirm the UPCs Remaining count is shown in the format: xxx UPCs Remaining
And In the ItemSync Manual Entry screen, I confirm the number shown in the UPCs Remaining count is: 999
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125713B
And In the ItemSync Manual Entry screen, I confirm the number shown in the UPCs Remaining count is: 998
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC125713C
And In the ItemSync Manual Entry screen, I confirm the number shown in the UPCs Remaining count is: 997
Then In the ItemSync Manual Entry screen I confirm that to the right of the UPC: saved as UPC125713B I Click the 'Remove' Icon
And In the ItemSync Manual Entry screen, I confirm the number shown in the UPCs Remaining count is: 998
Then In the ItemSync Manual Entry screen I confirm that to the right of the UPC: saved as UPC125713C I Click the 'Remove' Icon
And In the ItemSync Manual Entry screen, I confirm the number shown in the UPCs Remaining count is: 999
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10429
Scenario: [126166] Base functionality - ItemSync - Manual Entry - 1,000 Valid UPC entered - Add Button greyed out

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I generate 1000 random UPCs save them in a string array as: UPCArray126166
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: UPCArray126166
Then In the ItemSync Manual Entry screen, I confirm the ADD button is greyed out and I cannot add any more UPCs to the grid
Then In the ItemSync Manual Entry screen, I confirm I see an 'Upload' button
And In the ItemSync Manual Entry screen, I Click the Upload Button
Then In the ItemSync Manual Entry screen, I confirm the table footer is showing
Given I call Shared Step 106194 (RPS Sign out)


@ScenarioId:10434
Scenario: [126167] Base functionality - ItemSync - Manual Entry - UPC from UPC grid - scrolling

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I generate a total of: 20 random UPCs save them in a string array as: UPCArray126167
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: UPCArray126167
#Can not check if scroll bar is present. Will still perform scroll checks
Then In the ItemSync Manual Entry screen, I confirm I can scroll up and down through the UPC grid List
And In the ItemSync Manual Entry screen, I confirm the Entry field and the ADD button are still shown at all times while scrolling the UPC grid
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10436
Scenario: [134935] Base functionality - ItemSync - Manual Entry - Duplicate UPC entered 

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
Then I generate a random UPC number and save as: UPC126167A
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC126167A
Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC) for UPC: saved as UPC126167A
Then In the ItemSync Manual Entry screen, I confirm I see the error with the message UPC already exists
Then In the ItemSync Manual Entry screen, I Clear the text in the UPC field
Then In the ItemSync Manual Entry screen, I confirm I do not see the error with the message UPC already exists
Given I call Shared Step 106194 (RPS Sign out)


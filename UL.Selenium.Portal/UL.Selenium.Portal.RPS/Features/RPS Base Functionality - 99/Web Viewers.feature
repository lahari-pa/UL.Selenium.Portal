@RPS
@Login
@run_WebViewers
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
@Global_Steps
@DemoViewer
@DemoStatus


Feature: Web Viewers

@ScenarioId:9745
Scenario: [70334] Base Functionality - Web Viewers - Demo Viewer

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Web Viewers
Then I click the sub tab: Demo Viewer
#Issue if both demoviewer and demostatus tabs are open (same title)
Then I switch to the window with the title: Log On
And I confirm the Demo Viewer Page has loaded
Then I verify that a tab opens with url: http://demoviewer.wercsmart.com/Account/LogOn?ReturnUrl=%2f
And I Close the browser tab with the title: Log On
Given I call Shared Step 106194 (RPS Sign out)


#Demo status page not showing (error) 07-07-20
@ScenarioId:9789
Scenario: [70335] Base Functionality - Web Viewers - Demo Status

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Web Viewers
Then I click the sub tab: Demo Status
#Issue if both demoviewer and demostatus tabs are open (same title)
Then I switch to the window with the title: Log On
Then I confirm the Demo Status Page has loaded
Then I verify that a tab opens with url: http://demostatus.wercsmart.com/Account/LogOn?ReturnUrl=%2f
And I Close the browser tab with the title: Log On
Given I call Shared Step 106194 (RPS Sign out)

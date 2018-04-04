@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@run_Signup

Feature: Retailer Partners

Background:
Given I go to the WERCSmart Log in

Scenario: [56881] Retailer Partners - Main Page layout (existing supplier)
# Note: We will have a separate test case for new suppliers views of this page
And I login into the WERCSmart Portal - Administrator Role
And I click the Retail Partners icon in the Navigation Pane
# You should be on the Retail Partners page
Then I should see the following heading Retail Partners
And I should see the following subheading All Retailers
And I should see the following subheading Most Recent Retailers
And Confirm that you see Retailer tiles shown under the Most Recent Retails heading
And Confirm that you see Retailer tiles shown under the All Retailers heading
And Confirm that the retailers shown under the Most Recent Retailers heading are not repeated under the All Retailers heading
And Confirm that none of the tiles are blank
And Confirm that if the Retailer logo is not shown, then the Retailer name is shown in the Retailer tile
And Use the Stored Procedure GET_MOST_RECENT_RETAILERS to confirm that the retailers shown under Most Recent Retailers is correct NOTE: Parameters for the GET_MOST_RECENT_RETAILERS are @SUPPLIERGUID  - different for each supplier  @TOPPRODUCTS - use the number 8 @SOURCESERVICE - use the word PORTAL    Supplier GUID should be enclosed in single quotes   The word PORTAL for the SOURCESERVICE does not need single quotes
And Use this query to see the list of currently active retailers in Portal select * from t_client where f_active = 1 and ISNULL(f_config.value('(/Client/@Active)[1]','varchar(20)'),'true') = 'true'  order by f_name CONFIRM this list matches the list of retailers you see in the Retail Partners page


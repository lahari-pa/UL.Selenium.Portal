@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@run_Signup

Feature: Retailer Partners

Background:
Given I go to the WERCSmart Log in

Scenario: [56881] Retailer Partners - Main Page layout (existing supplier)
Given In the shared step below login to the site using the main supplier for the environment you are testing in.
# Note: We will have a separate test case for new suppliers views of this page
And Login into WERCSmart Portal - Administrator Role
And Click the Retail Partners icon on the left hand icon list (handshake icon)
# You should be on the Retail Partners page
And Confirm the page title shows "Retail Partners"
And Confirm that you see a heading of "Most Recent Retailers"
And Confirm that you see a heading of "All Retailers"
And Confirm that you see Retailer tiles shown under the Most Recent Retails heading
And Confirm that you see Retailer tiles shown under the All Retailers heading
And Confirm that the retailers shown under the Most Recent Retailers heading are not repeated under the All Retailers heading
And Confirm that none of the tiles are blank
And Confirm that if the Retailer logo is not shown, then the Retailer name is shown in the Retailer tile
And Use the Stored Procedure GET_MOST_RECENT_RETAILERS to confirm that the retailers shown under Most Recent Retailers is correct NOTE: Parameters for the GET_MOST_RECENT_RETAILERS are @SUPPLIERGUID  - different for each supplier  @TOPPRODUCTS - use the number 8 @SOURCESERVICE - use the word PORTAL    Supplier GUID should be enclosed in single quotes   The word PORTAL for the SOURCESERVICE does not need single quotes
And Use this query to see the list of currently active retailers in Portal select * from t_client where f_active = 1 and ISNULL(f_config.value('(/Client/@Active)[1]','varchar(20)'),'true') = 'true'  order by f_name CONFIRM this list matches the list of retailers you see in the Retail Partners page


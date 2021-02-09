@Shared
@RetailPartners
@Homepage
@LandingPage
@ProductGrid
@Login
@SupplierReports
@ForgottenPassword
@CreateProducts
@wercsmart
@DocumentAcceptance
@wercsmart
@ConflictMinerals
@ProductGrid
@Portal_ChooseGoodGuide
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
@SummaryPage
@Shared
@SHA
@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@DocumentAcceptance
@UPC
@PaymentMethods
@WERCSmart_ChooseGoodGuide

@run_SpecFlowFeature1
Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

@ScenarioId:10699














#Done - Just Check
@philtag2
Scenario: [145971] Canada Only, Non Authoring Product - No Label Uploaded, PLP = Yes, GENDOC = 0

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
# In the shared step below use "Halogen  lights"  as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs TC 145971 - Canada Only, Non Authoring Product - No Label Uploaded, PLP Yes, GENDOC 0
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Halogen lights
Given I generate a random UPC number and save as: UPC145971
Given I save the product information as: TestCase145971
Given I call shared step 145969 (Additional Product Information > SOLD (Canada), PLP (YES), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145971, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
# Given the Additional Documents to Provide step is show
Given I click continue
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
# Given the Comments step is shown
Given I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145971)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145971)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145971)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 29
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145971)
# Given I call shared step 144993 (WPS Studio - PD+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145971)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145971)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145971) for
| Retailer |


#Done
@philtag3
@ScenarioId:10706
Scenario: [145852] Canada Only, Non Authoring Product - No Label Uploaded, PLP = No, GENDOC = 0, User Uploads SDS on Additional Documents to Provide

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

# In the shared step below use "Halogen  lights"  as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs TC 145852 - Canada Only, Non Authoring Product - No Label Uploaded, PLP No, GENDOC 0, User Uploads SDS on Additional Documents to Provide
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Halogen lights
Given I generate a random UPC number and save as: UPC145852
Given I save the product information as: TestCase145852
Given I call shared step 145844 (Additional Product Information > SOLD (Canada), PLP (No), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 72414 (Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145852, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : C:\Dependencies\WERCSmart\testdoc.pdf
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
# Given the Comments step is shown
Given I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145852)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145852)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145852)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145852)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 29
#Given I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
#Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145852
#Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145852)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145852)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145852) for
| Retailer |


#Done
@philtag4
Scenario: [145842] Canada Only, Non Authoring Product - No Label Uploaded, PLP = No, GENDOC = 0

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
# In the shared step below use "Halogen  lights"  as your product type  If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs 145842 - Canada Only, Non Authoring Product - No Label Uploaded, PLP No, GENDOC 0
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Halogen lights
Given I generate a random UPC number and save as: UPC145842
Given I save the product information as: TestCase145842
Given I call shared step 145844 (Additional Product Information > SOLD (Canada), PLP (No), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 72414 (Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145842, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
# Given the Additional Documents to Provide step is show
Given I click continue
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145842)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145842)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145842)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145842)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 31
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145842)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145842
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145842)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145842)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145842) for
| Retailer |


#Partly-Done
@philtag5
@ScenarioId:10704
Scenario: [145822] Canada Only, Label Only Product - Label Uploaded

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
# In the shared step below use "Nutritional Supplement - Liquid" as your product type  If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs Test case 145882 - Canada Only, Label Only Product - Label Uploaded
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nutritional Supplement - Liquid
Given I generate a random UPC number and save as: UPC145822
Given I save the product information as: TestCase145822
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 78879 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I call shared step 72414 (Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145822, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue.
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
# Given the Comments step is shown
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145822)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145822)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145822)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145822)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 31
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145822)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145822
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145822)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145822)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145822) for
| Retailer |

#Done
@philtag6
@ScenarioId:10707
Scenario: [145793] Canada Only, PLP = Yes, PLP Upload allowed = Yes, GenDocCA = 0

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# In the shared step below select Chalk as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name:  For WVs Test case 145793 - Canada Only, PLP Yes, PLP Upload allowed Yes, Gen
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC145793
Given I save the product information as: TestCase145793
# Make a note of the WPS ID shown at the top of the screen
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145793, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 100974 (Regulatory Documents to Provide - Canada only - Upload documents > Continue)
Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
Given I click continue
# Given the Additional Documents to Provide step is show
Given I click continue
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145793)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145793)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145793)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145793)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145793)
Given I call shared step 144993 (WPS Studio - PD+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP for product saved as: TestCase145793)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145793)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145793)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145793) for
| Retailer |


@philtag7
@ScenarioId:10705
Scenario: [145783] Canada Only, PLP = Yes, PLP Upload allowed = Yes, GenDocCA = 1, Alias published = No

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# In the shared step below select Chalk as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs TC 145783 - Canada Only, PLP Yes, PLP Upload allowed Yes, GenDocCA 1, Alias published No
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC145783
Given I save the product information as: TestCase145783
# Make a note of the WPS ID shown at the top of the screen
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145783, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
# Given the Additional Documents to Provide step is show
Given I click continue
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145783)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145783)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145783)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145783)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145783)
# Given I call shared step 145791 (WPS Studio - PD+ - PLP - Publish CKLT, HGHS and SBCS for main product only - not the aliases)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145783)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145783)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145783) for
| Retailer |


@philtag8
Scenario: [145743] Canada Only, PLP = Yes, PLP Upload allowed = Yes, GenDocCA = 1, Alias published = Yes

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I call shared step 144794 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# In the shared step below select Chalk as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs Test case 145743 - Canada Only, PLP Yes, PLP Upload allowed Yes, GenDocCA 1, Alias published Yes
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC145743
Given I save the product information as: TestCase145743
# Make a note of the WPS ID shown at the top of the screen
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145743, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
# Given the Additional Documents to Provide step is show
Given I click continue
# Given the Optional Reports and Documents Available for Purchase step is shown
Given I click continue
Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145743)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145743)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145743)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145743)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145743)
Given I call Shared Step 78888 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, HGHS (EN and CF) and SBCS for product saved as TestCase145743
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145743)
# Because we are working with a PLP and we need the alias products to have published HGHS documents we need the following steps to so thi.
# In Power Designer.
# Given I call shared step 149691 (WPS Studio - PD+ - PLP product for Canada - publish alias HGHS documents)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145743)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145743)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145743) for
| Retailer |

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
@run_TransparencyRationCalculation

Feature: Transparency Ration Calculation

Scenario: [80854] Ingredients - Transparency Ratio - Formulated product with 3rd party product included in formulation
#For this test case you will need to have a specific 3rd party formulation product to add to your formulated products ingredients list.
#Use test case 80821 to create this third party product and get it to completed status.
#You will need to know the WPSxxxxxxx ID associated to the 3rd party product
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I Use the shared step below to confirm the Transparency ratio for the third party product you are working with
And [Shared Step 80780 - My Products - Filter for product - View - Note transparency ratio - close summary]
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I In the shared step below use Chalk as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): (.*)
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I The Ingredients step is shown - Confirm the Transparency ratio (the numbers below the Publicly Disclosed column) shows in red background and shows 0/0
And [Shared Step 80784 - Ingredients - Search for 3rd party component product by WPSxxxxxxx]
And I If the Access Code Validation pop up is shown use the shared step below to enter the validation code for your 3rd party product
And [Shared Step 64138 - Access Code Validation - enter code - Click Validate]
And I Enter a value &lt; 100 in the percent column for the component you just added
And I Select the Yes check box in the Publicly Disclosed column for the component you just added
And I Select an entry from the Public Name drop down list for the component you just added
And I Confirm the Numerator for the Transparency Ratio shows the decimal value you calculated earlier for the 3rd party products transparency ratio for example if you saw 1/2 as the transparency ratio in the 3rd party product you will see 0.5 as the Numeratorif you saw 3/8 as the transparency ratio in the 3rd party product you will see 0.375 as the NumeratorNumerator = 1st number in the transparency ratio If you are using the 3rd party product exactly as specified in test case 80821 you will see 0.375/1
And I Confirm the Denominator for the Transparency Ratio is shown as 1Denominator = 2nd number in the transparency ratio
And I Confirm the Transparency ratio is shown with an orange background
And I Use the shared step below to add 84696-51-5 Extract, Spearmint to your formulationwith Publicly Disclosed set to Yes
And [Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name]
And I Confirm the Transparency ratio shows as 1.375/2 with a blue background colorThis is because the new component added adds 1 to the Numerator and 1 to the denominator as it is publicly disclosed
And I Use the shared step below to add FLAVOR 072 Springmint to your formulation with Publicly Disclosed set to No
And [Shared Step 80824 - Ingredients - Add FLAVOR component, not Publicly Disclosed]
And I Confirm the Transparency Ratio is shown as 1.375/3 in orange backgroundThis is because the FLAVOR component does not add 1 to the Numerator as it is not publicly disclosed but it does add 1 to the Denominator
And I Use the shared step below to add 7732-18-5 Water to your ingredients list with Publicly Disclosed set to Yes
And [Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name]
And I Confirm the Transparency Ratio is shown as 2.375/4 in blue backgroundThis is because the component you added is publicly disclosed so it adds 1 to the numerator and 1 to the denominator
And I Use the shared step below to add 144-55-8 Sodium Bicarbonate to your ingredients list with publicly disclosed set to No
And [Shared Step 80823 - Ingredients - Add non-generic component - not publicly disclosed]
And I Confirm the Transparency Ratio is shown as 2.375/5 in orange backgroundThis is because the component you added is not publicly disclosed so it does not add 1 to the numerator, but it does add 1 to the denominator
And I Use the shared step below to add NA751 Menthol Flavoring to your ingredients list with Publicly Disclosed set to Yes
And [Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name]
And I Confirm the Transparency Ratio is shown as 3.375/6 in blue backgroundThis is because the NA751 component is not considered generic so it adds 1 to the numerator and denominator
And I Use the shared step below to add RR-38254-7 FRAGRANCE - CUCUMBER to your ingredients list with Publicly Disclosed set to Yes
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: (.*)
And I Confirm the Transparency Ratio is shown as 3.375/7 in orange backgroundThis is because the Fragrance component you added is a generic so it does not add 1 to the numerator but it does add 1 to the denominator
And I Use the shared step below to add 111-42-2 Diethanolamine to your ingredients list with Publicly Disclosed set to No
And [Shared Step 80823 - Ingredients - Add non-generic component - not publicly disclosed]
And I Confirm the Transparency Ratio is shown as 3.375/8 in orange backgroundThis is because the component is not publicly disclosed so it does not add 1 to the numerator but it does add 1 to the denominator
And I Use the shared step below to add 26675-46-7 Isoflurane to your ingredients list with Publicly Disclosed set to Yes make sure the percent value you add makes the total = 100
And [Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name]
And I Confirm the Transparency ratio is shown as 4.375/9 in orange background
And I Click Continue
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I The Additional Documents to Provide step is shown- as we have FLAVOR and FRAGRANCE components in our product we need to attach IFRA and GRAS documents
And I In the shared step below add a file for the International Fragrance Association (IFRA) certificate file upload
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: (.*) and file: (.*)
And I In the shared step below add a file for the Generally Recognized as Safe (GRAS) certification file upload
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: (.*) and file: (.*)
And I Click Continue
And I The Optional Reports and Documents Available for Purchase step is shown - Click Continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Requires Table |
| Parameters     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: (.*)
And I Confirm the Data Acceptance step is shown
And I Click Summary
And I Scroll down until you see the Ingredients list
And I Confirm the Transparency Ratio is shown below the last component in the ingredients list and is shown as 4.375 / 9
And I Close the Summary view window and return to the WERCSmart Data Acceptance step
And I Click Home
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: (.*)

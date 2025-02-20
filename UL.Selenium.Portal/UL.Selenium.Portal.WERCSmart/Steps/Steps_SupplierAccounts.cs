using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using Reqnroll.Assist;
using UL.Automation.Utilities;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using System.Text.RegularExpressions;
using TReVor.Integrations;
using TReVor.Integrations.Classes;
using UL.Automation.Utilities.Mailosaur.Classes;
using NPOI.Util;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SupplierAccounts")]
	class StepsSupplierAccounts
	{
		public static string companyName= new AddNewSupplier().GetRandomCompanyName();

		[RegexStepDefinition(@"I create a new supplier products account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");


			subCompanyInfo.AddRow("ProductAccount_<random>", "UNITED STATES", "WERCS", "Test_Automation_ProductsAccount", "Welcome1!", "725 5th Ave", "", "New York", "New York", "10022", "QA_Automation_ProductsAccount", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
						//subCompanyInfo.AddRow("User_<random>", "UNITED STATES", "WERCS", "Test_Automation_ProductsAccount", "Welcome1!", "Address1", "Address2", "Latham", "New York", "12110", "QA_Automation_ProductsAccount", "123-456-7889",
			//	"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");


			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myBrand = new Steps_Brands();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();
			var dataNotification = new GoToDataTierNotification();
			myHome.ThenIClickOnUserItem("My Account");
			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 6000 Product(s)", "Up to 6000 Product(s)", "Up to 6000 Product(s)", "Standard", "Bronze");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number", "Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);

			//myPay.ThenIOpenTheEditAddressForm();

			new PaymentMethods_Edit_Address().Edit_Billing_Address(state:"New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");

			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();
			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("6000", "6000", "6000");

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//Canada supplier address
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.AddCanadaAddress("100 King St W", "Ontario", "Toronto", "ON M5X 1A9", "123-123-1234", "CANADA", "1");

			//select I have no stewardship numbers
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			Delay.Seconds(5);
			myAccount.ClickIhaveNoStewardshipNumbers();
			Delay.Seconds(5);
			

			//My Brands
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");

			myAccount.ClickTabMyLibrary("My Brands");
			myAccount.ClickAddNewMyLibrary("My Brands");
			myBrand.EnterBrandNameExpandedRow("TestBrand");
			myBrand.ClickSaveMyBrandsGrid();
			myBrand.ActiveValueIsYesForLastBrand("Yes");

			//Supplier/Vendor id 
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Wal-Mart/SAM'S CLUB");
			
			myRetailPartner.IConfirmTheRetailerDetailsPageHasLoaded();
			myRetailPartner.GivenIClickOnTheAddNewSupplierIDLink();
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput("123456");
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput("TestBrand");
			myRetailPartner.GivenInTheAddNewSupplierDialogIClickSave();
			var brandTable = new Table("Supplier ID", "Company or Brand Name");
			brandTable.AddRow("123456", "TestBrand");
			myRetailPartner.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(brandTable);

			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Sears/K-Mart");
			myRetailPartner.IConfirmTheRetailerDetailsPageHasLoaded();
			myRetailPartner.GivenIClickOnTheAddNewSupplierIDLink();
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput("123456");
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput("TestBrand");
			myRetailPartner.GivenInTheAddNewSupplierDialogIClickSave();
			var brandTable2 = new Table("Supplier ID", "Company or Brand Name");
			brandTable2.AddRow("123456", "TestBrand");
			myRetailPartner.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(brandTable2);

			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("O'Reilly");
			myRetailPartner.IConfirmTheRetailerDetailsPageHasLoaded();
			myRetailPartner.GivenIClickOnTheAddNewSupplierIDLink();
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput("123456");
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput("TestBrand");
			myRetailPartner.GivenInTheAddNewSupplierDialogIClickSave();
			var brandTable3 = new Table("Supplier ID", "Company or Brand Name");
			brandTable3.AddRow("123456", "TestBrand");
			myRetailPartner.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(brandTable3);

			//create a product for Walmart data tier 4.2 
			myProductsetup.CreateProductConditionerAndTakeToSubmitted("product1", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Wal-Mart/SAM'S CLUB");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.SetDataConsentTier("Tier 4.1", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for CVS data tier
			myProductsetup.CreateProductConditionerForCVSAndTakeToDataSummary("product2", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("CVS");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.SetDataConsentTier("Tier 4.1", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Target data tier
			myProductsetup.CreateProductConditionerForTargetAndTakeToDataSummary("product3", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			if (dataNotification.WaitForContainerToBeVisible(10))
			{
				Report.IsTrue(dataNotification.ClickGoToDataTiers(), "Failed to click Go to data tier in popup!", "Successfully clicked Go to data tier in popup");
			}
			else
			{
				Report.Info("Data Tier update required is not displayed");
			}

			myRetailPartner.SelectRetailer("Target");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.SetDataConsentTier("Tier 3", "on");
			myRetailPartner.SetDataConsentTier("Tier 4.1", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Costco data tier
			//myProductsetup.CreateProductConditionerForCostcoAndTakeToDataSummary("product4", "Conditioner");
			//myHome.ClickItemInNavigationPanel("Retail Partners");
			//myRetailPartner.SelectRetailer("Costco");
			//myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			//myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			//myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			//myRetailPartner.GivenClickTheSaveChangesButton();
			//myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Dollar Tree data tier
			myProductsetup.CreateProductConditionerForDollarTreeAndTakeToDataSummary("product5", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Dollar Tree Stores, Inc. / Greenbrier International, Inc");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Family Dollar data tier
			myProductsetup.CreateProductConditionerForFamilyDollarAndTakeToDataSummary("product6", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Family Dollar");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Walgreens data tier
			myProductsetup.CreateProductConditionerForWalgreensAndTakeToDataSummary("product7", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Walgreens");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Rite aid data tier
			myProductsetup.CreateProductConditionerForRiteAidAndTakeToDataSummary("product8", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Rite Aid");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.SetDataConsentTier("Tier 3", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//create a product for Amazon data tier
			myProductsetup.CreateProductConditionerForAmazonAndTakeToDataSummary("product9", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Amazon");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			//myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			//myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			//myRetailPartner.SetDataConsentTier("Tier 3", "on");
			//myRetailPartner.GivenClickTheSaveChangesButton();
			//myRetailPartner.ClickCloseOnSavePopupDialog();

			//data tiers fot CT
			myProductsetup.CreateProductChalkWithCanadianTierAndPLAndGoToSummary("product10", "Crayon");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Canadian Tire");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//Save account and update TReVor data
			Report.Info($"{savedAs} Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier packaging only account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountPkgOnlyWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("PackagingOnly_<random>", "UNITED STATES", "WERCS", "Test_Automation_Upgrade", "Welcome1!", "Address1", "Address2", "Latham", "Florida", "12205", "QA_Packaging_Only", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");
			Report.Info($"{savedAs} Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier lockout account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountLockOutWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("AccountLockOut_<random>", "UNITED STATES", "WERCS", "Test_Automation_Lockout", "Welcome1!", "Address1", "Address2", "Latham", "Florida", "12205", "QA_AccountLockTest", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			if (this.BasicSignup(savedAs))
			{
				this.SaveUserToTReVor(savedAs, account);
			}
		}


		[RegexStepDefinition(@"I create a new supplier Canada address only account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountCanadaAddressOnlyWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("CanadaAddressOnly_<random>", "CANADA", "WERCS", "Test_Automation_Upgrade", "Welcome1!", "1425 Kingsway", "Address2", "Sudbury", "ON", "P3A 4R7", "QA_Packaging_Only", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			if (this.BasicSignup(savedAs))
			{
				this.SaveUserToTReVor(savedAs, account);
			}
		}


		[RegexStepDefinition(@"I create a new supplier Stewardship only account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountStewardshipOnlyWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("fullstwrdshiponly_<random>", "UNITED STATES", "WERCS", "Test_Automation_Stewardship_Only", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12110", "QA_Full_Stewardship_Only", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Saskatchewan", "SA-1-1");
			myAccount.StewardshipInformation("Manitoba", "MA-1-1");
			myAccount.StewardshipInformation("Ontario", "ON-1-1");
			myAccount.StewardshipInformation("Quebec", "QU-1-1");
			Report.Info(savedAs + " Account Created");

			this.SaveUserToTReVor(savedAs, account);
		}

		[RegexStepDefinition(@"I create a new supplier Canada has address packaging account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountCanadaHasAddressPackagingWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("CanadaHasAddressPackaging_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_CanHasAddPkg", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();
			myHome.ThenIClickOnUserItem("My Account");

			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 400 Product(s)", "Up to 400 Product(s)", "Up to 400 Product(s)", "Standard", "Bronze");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number",
				"Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);



			new PaymentMethods_Edit_Address().Edit_Billing_Address(state: "New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();


			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("400", "400", "400");

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//Canada supplier address
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.AddCanadaAddress("100 King St W", "Ontario", "Toronto", "ON M5X 1A9", "123-123-1234", "CANADA", "1");

			//select I have no stewardship numbers
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			Delay.Seconds(5);
			myAccount.ClickIhaveNoStewardshipNumbers();
			Delay.Seconds(5);
			//modal wait and accept accept/ press YES
			//new GlobalSteps().WaitForAModalDialogToOpen();
			//new ModalDialog().ClickButton("YES");
			Delay.Seconds(5);

			//data tiers
			myProductsetup.CreateProductChalkWithCanadianTierAndPLAndGoToSummary("product1", "Crayon");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Canadian Tire");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier Canada has pack and partial stewardship account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountCanadaHasPackAndPartialStwdshipWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("CanadaHasPackandPartialStewardship_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_Automation_Account", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);
			myHome.ThenIClickOnUserItem("My Account");

			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 400 Product(s)", "Up to 400 Product(s)", "Up to 400 Product(s)", "Standard", "Bronze");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number",
				"Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);


			new PaymentMethods_Edit_Address().Edit_Billing_Address(state: "New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();

			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("400", "400", "400");

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//Canada supplier address
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.AddCanadaAddress("100 King St W", "Ontario", "Toronto", "ON M5X 1A9", "123-123-1234", "CANADA", "1");

			//Stewardship information
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Manitoba", "BC-1-1");

			//data tiers
			myProductsetup.CreateProductChalkWithCanadianTierAndPLAndGoToSummary("product1", "Crayon");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Canadian Tire");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier no pkg stewardship partial and update TReVor information for: (.*)")]
		public void CreateNewAccountNoPkgPartialStwdshipWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("CanadaNoPkgStwdPartial_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_Automation_Account", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			//Canada supplier address
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.AddCanadaAddress("100 King St W", "Ontario", "Toronto", "ON M5X 1A9", "123-123-1234", "CANADA", "1");

			//Stewardship information
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Manitoba", "MA-1-1");

			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier data consent and update TReVor information for: (.*)")]
		public void CreateNewAccountDataConsentWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("DataConsentAccount<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_DataConsent", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = subCompanyInfo.CreateInstance<WERCSmartUser>();
			account.Email = MailosaurHelpers.DefaultMailbox.CreateEmail(account.Email);
			account.Identifier = savedAs;
			UL.Automation.ReqnrollHelpers.Classes.Context.AddToContext(savedAs, account, true);
			Report.Success("Account details saved!");
			var mySignUp = new StepsSignup();
			var myLogin = new StepsLogin();
			var myLanding = new StepsLandingPage();
			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myBrand = new Steps_Brands();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();
			var myGlobalpage = new GlobalSteps();

			mySignUp.GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
			myLanding.ClickTheLoginButton();
			myLogin.GivenIClickOnTheNewToWercsmartLink();
			mySignUp.ThenTheSignupPageShouldAppear();
			mySignUp.GivenIEnterSignupEmailUser(savedAs);
			mySignUp.GivenIConfirmSignupEmailUser(savedAs);
			mySignUp.GivenIClickOnSubmit();
			mySignUp.ThenTheSignupThankYouPageShouldAppear();
			mySignUp.ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "<SiteNotification>", "Link to create WERCSmart Account");
			mySignUp.ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount();
			mySignUp.WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage();
			mySignUp.WhenIEnterTheFollowingInformationIntoTheNewUserForm(savedAs);
			mySignUp.WhenInTheNewUserFormIClickOnContinue();
			mySignUp.ThenIShouldBeOnThePageOfTheForm("Security Questions");
			mySignUp.EnterTheFollowingIntoSecurityQuestions(savedAs);
			mySignUp.EnterPinForUser(savedAs);
			mySignUp.WhenInTheNewUserFormIClickOnContinue();
			myLanding.ClickTheLoginButton();
			myLogin.GivenILoginAsUser(savedAs);
			mySignUp.GivenIfTermsOfUsePageAppearsIAccept();
			//myGlobalpage.GivenILogInWithEmailXAndPasswordY("User_c5d640f06772.kxxyxunf@mailosaur.io", "Welcome1!");
			myHome.ThenTheWercSmartHomepageShouldLoad();
			myHome.ThenIClickOnUserItem("My Account");


			Report.Info(savedAs + " Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier no Canada data and update TReVor information for: (.*)")]
		public void CreateNewAccountNoCanadaDataWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("NoCanadaData_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_NoCanadaData", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier no canada yes packaging full stewardship with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountNoCanYesPkgStwdFullWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("NoCanYesPkgStwdFull_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_NoCanYesPkgStwdFull", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//Stewardship data
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Saskatchewan", "SA-1-1");
			myAccount.StewardshipInformation("Manitoba", "MA-1-1");
			myAccount.StewardshipInformation("Ontario", "ON-1-1");
			myAccount.StewardshipInformation("Quebec", "QU-1-1");


			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier Partial Stewardship only account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountpartialStewardshipOnlyWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("PartialStewardshipOnly_<random>", "UNITED STATES", "WERCS", "Test_Automation_Partial_Stewardship_Only", "Welcome1!", "725 5th Ave", "", "New York", "New York", "10022", "QA_Partial_Stewardship_Only", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Saskatchewan", "SA-1-1");
			myAccount.StewardshipInformation("Quebec", "QU-1-1");
			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier premium subscription with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountPremiumSubsWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("PremiumSubscriptionAccount_<random>", "UNITED STATES", "WERCS", "Test_Automation_PremiumSubscription", "Welcome1!", "725 5th Ave", "", "New York", "New York", "10022", "QA_PremiumSubscription", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);
			myHome.ThenIClickOnUserItem("My Account");

			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 100 Product(s)", "Up to 100 Product(s)", "Up to 100 Product(s)", "Premium", "Silver");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number",
				"Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);


			new PaymentMethods_Edit_Address().Edit_Billing_Address(state: "New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();

			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("100", "100", "100");

			//create a product for Dollar Tree data tier
			myProductsetup.CreateProductConditionerForDollarTreeAndTakeToDataSummary("product5", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Dollar Tree Stores, Inc. / Greenbrier International, Inc");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			//Save account and update TReVor data
			Report.Info($"{savedAs} Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier Partial Stewardship and packaging account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountpartialStewardshipAndPkgWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("PackagePartialStewardship_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12110", "QA_Partial_Stewardship_Pkg", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//Stewardship information
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Manitoba", "MA-1-1");

			//update TReVor info
			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier no PLP with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountNoPLPWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("NoPLProductsAccount_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12110", "QA_NoPLP_Products", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			//update TReVor info
			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier Canada has all data with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountCanadaHasAddressPackageStwdshipWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("CanadaHasAllData_<random>", "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_Automation_CanadaAllData", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);
			myHome.ThenIClickOnUserItem("My Account");

			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 400 Product(s)", "Up to 400 Product(s)", "Up to 400 Product(s)", "Standard", "Bronze");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number",
				"Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);


			new PaymentMethods_Edit_Address().Edit_Billing_Address(state: "New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");

			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();


			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("400", "400", "400");

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//Canada supplier address
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.AddCanadaAddress("100 King St W", "Ontario", "Toronto", "ON M5X 1A9", "123-123-1234", "CANADA", "1");

			//Stewardship information
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Company Information");
			myAccount.StewardshipInformation("British Columbia", "BC-1-1");
			myAccount.StewardshipInformation("Saskatchewan", "SA-1-1");
			myAccount.StewardshipInformation("Manitoba", "MA-1-1");
			myAccount.StewardshipInformation("Ontario", "ON-1-1");
			myAccount.StewardshipInformation("Quebec", "QU-1-1");

			//data tiers
			myProductsetup.CreateProductChalkWithCanadianTierAndPLAndGoToSummary("product1", "Crayon");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Canadian Tire");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");
			myRetailPartner.SetDataConsentTier("Tier 1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.1", "on");
			myRetailPartner.SetDataConsentTier("Tier 2.2", "on");
			myRetailPartner.GivenClickTheSaveChangesButton();
			myRetailPartner.ClickCloseOnSavePopupDialog();

			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier Products in cart with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountProductInCartWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("ProductsInCart_<random>", "UNITED STATES", "WERCS", "Test_Automation_Stewardship_Only", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12110", "QA_ProductsInCart", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			var myProductsetup = new Steps_ProductSetup();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			//create a product and click accept 
			myProductsetup.CreateProductChalkAndClickAcceptOnDataAcceptance("Product1", "Chalk");

			this.SaveUserToTReVor(savedAs, account);
		}


		[RegexStepDefinition(@"I create a new supplier sub cart with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountSubCartWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("SubCart_<random>", "UNITED STATES", "WERCS", "Test_Automation_Stewardship_Only", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12110", "QA_SubCart", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");


			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);
			myHome.ThenIClickOnUserItem("My Account");

			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 10 Product(s)", "Up to 10 Product(s)", "Up to 10 Product(s)", "Limited", "No additional Agent Support Service");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number",
				"Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);


			new PaymentMethods_Edit_Address().Edit_Billing_Address(state: "New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();


			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("10", "10", "10");

			Report.Info($"{savedAs} Account Created");
			this.SaveUserToTReVor(savedAs, account);
		}

		[RegexStepDefinition(@"I create a new supplier Visual with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountVisualWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("VisualAccount_<random>", "UNITED STATES", "WERCS", "Test_Automation_Lockout", "Welcome1!", "Address1", "Address2", "Latham", "Florida", "12205", "QA_Visual", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");

			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			if (this.BasicSignup(savedAs))
			{
				this.SaveUserToTReVor(savedAs, account);
			}
		}

		public WERCSmartUser SaveUser(Table information, string savedAs)
		{
			WERCSmartUser account = information.CreateInstance<WERCSmartUser>();
			account.Email = MailosaurHelpers.DefaultMailbox.CreateEmail(account.Email);
			account.Identifier = savedAs;
			Context.AddToContext(savedAs, account, true);

			Report.Success("Account details saved!");
			return account;
		}

		public bool BasicSignup(string savedAs)
		{
			try
			{
				var mySignUp = new StepsSignup();
				var myLogin = new StepsLogin();
				var myLanding = new StepsLandingPage();
				var myHome = new StepsHomepage();

				mySignUp.GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
				myLanding.ClickTheLoginButton();
				myLogin.GivenIClickOnTheNewToWercsmartLink();
				mySignUp.ThenTheSignupPageShouldAppear();
				mySignUp.GivenIEnterSignupEmailUser(savedAs);
				mySignUp.GivenIConfirmSignupEmailUser(savedAs);
				mySignUp.GivenIClickOnSubmit();
				mySignUp.ThenTheSignupThankYouPageShouldAppear();
				mySignUp.ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "<SiteNotification>", "Link to create WERCSmart Account");
				mySignUp.ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount();
				mySignUp.WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage();
				mySignUp.WhenIEnterTheFollowingInformationIntoTheNewUserForm(savedAs);
				mySignUp.WhenInTheNewUserFormIClickOnContinue();
				mySignUp.ThenIShouldBeOnThePageOfTheForm("Security Questions");
				mySignUp.EnterTheFollowingIntoSecurityQuestions(savedAs);
				mySignUp.EnterPinForUser(savedAs);
				mySignUp.WhenInTheNewUserFormIClickOnContinue();
				myLanding.ClickTheLoginButton();
				myLogin.GivenILoginAsUser(savedAs);
				mySignUp.GivenIfTermsOfUsePageAppearsIAccept();
				myHome.ThenTheWercSmartHomepageShouldLoad();
				Report.Info(savedAs + " Created");
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveUserToTReVor(string savedAs, WERCSmartUser account)
		{
			
			var user = TReVorSettings.VaultRecords.GetCredential(savedAs);

			if (user != null)
			{
				Report.Info("User found!, Updating the password and email in TReVor");
				
				TReVorSettings.UpdateCredential(user.Alias,account.Email,account.Password);
				TReVorSettings.VaultRecords.Refresh();				
				var foundUser = TReVorSettings.VaultRecords.GetCredential(user.Alias);
				Report.Info($"founduser.username = '{foundUser.UserName}'");
				Report.Info($"account.email = '{account.Email}'");

				if(foundUser.UserName == account.Email)
				{
					Report.IsTrue(foundUser.UserName == account.Email, "Not able to update username", "Successfully updated username");
				}
				else
				{
					int x = 0;
					while(foundUser.UserName != account.Email && x<10)
					{

						Report.Info($"did not match the username to email... waiting 5 seconds then checking again");
						Delay.Seconds(5);
						x++;
						foundUser = TReVorSettings.VaultRecords.GetCredential(user.Alias);
					}

					Report.Info($"founduser.username = '{foundUser.UserName}'");
					Report.Info($"account.email = '{account.Email}'");
					Report.IsTrue(foundUser.UserName == account.Email, "Not able to update username", "Successfully updated username");
				}						
				
				string userpass = foundUser.Password;
				Report.IsTrue(userpass == account.Password, "Not able to update password", "Successfully updated password");	
				

			}
			else
			{
				throw new Exception("Unable to find TReVor test user saved as: " + savedAs);
			}

			return true;
		}

		[Given(@"I (should|should not) be able to create a WERCSmart account with the following special character in the email: (.*)")]
		public void GivenIShouldNotBeAbleToCreateAWERCSmartAccountWithTheFollowingParameters(string specialChar)
		{
			Report.IsTrue(new TestCreatingSupplierAccount(specialChar).TryCreateSupplier(), "", "");
		}

		[RegexStepDefinition(@"I create a new supplier NO products account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewNOProductsAccountWithFollowingParameters(string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("NoProductsAccount_<random>", "UNITED STATES", "WERCS", "Test_Automation_ProductsAccount", "Welcome1!", "Address1", "Address2", "Latham", "New York", "12110", "QA_Automation_ProductsAccount", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);
			this.BasicSignup(savedAs);

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myBrand = new Steps_Brands();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();
			var dataNotification = new GoToDataTierNotification();
			myHome.ThenIClickOnUserItem("My Account");
			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 6000 Product(s)", "Up to 6000 Product(s)", "Up to 6000 Product(s)", "Standard", "Bronze");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number", "Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);

			new PaymentMethods_Edit_Address().Edit_Billing_Address(state: "New York");

			Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
			new PaymentMethods_Edit_Address().EditAddressPopupNotShowing();

			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("6000", "6000", "6000");

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.SelectOptionForFieldInTable("Glass Packaging - Clear Glass - Non-Beverage", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//My Brands
			myAccount.ClickTabMyLibrary("My Brands");
			myAccount.ClickAddNewMyLibrary("My Brands");
			myBrand.EnterBrandNameExpandedRow("TestBrand");
			myBrand.ClickSaveMyBrandsGrid();
			myBrand.ActiveValueIsYesForLastBrand("Yes");

			//Supplier/Vendor id 
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Wal-Mart/SAM'S CLUB");
			myRetailPartner.IConfirmTheRetailerDetailsPageHasLoaded();
			myRetailPartner.GivenIClickOnTheAddNewSupplierIDLink();
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput("123456");
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput("TestBrand");
			myRetailPartner.GivenInTheAddNewSupplierDialogIClickSave();
			var brandTable = new Table("Supplier ID", "Company or Brand Name");
			brandTable.AddRow("123456", "TestBrand");
			myRetailPartner.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(brandTable);

			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("Sears/K-Mart");
			myRetailPartner.IConfirmTheRetailerDetailsPageHasLoaded();
			myRetailPartner.GivenIClickOnTheAddNewSupplierIDLink();
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput("123456");
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput("TestBrand");
			myRetailPartner.GivenInTheAddNewSupplierDialogIClickSave();
			var brandTable2 = new Table("Supplier ID", "Company or Brand Name");
			brandTable2.AddRow("123456", "TestBrand");
			myRetailPartner.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(brandTable2);

			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("O'Reilly");
			myRetailPartner.IConfirmTheRetailerDetailsPageHasLoaded();
			myRetailPartner.GivenIClickOnTheAddNewSupplierIDLink();
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput("123456");
			myRetailPartner.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput("TestBrand");
			myRetailPartner.GivenInTheAddNewSupplierDialogIClickSave();
			var brandTable3 = new Table("Supplier ID", "Company or Brand Name");
			brandTable3.AddRow("123456", "TestBrand");
			myRetailPartner.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(brandTable3);

			//Save account and update TReVor data
			Report.Info($"{savedAs} Created");
			this.SaveUserToTReVor(savedAs, account);
		}

		[RegexStepDefinition(@"In Add New Supplier I enter random Company Name")]
		public void ThenIFillOutTheInformationInTheAddNewSupplierRandomCompanyNameName()
		{

			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			var newSupplier = new AddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.CompanyNameInputExists(), "Failed to find Company Name input", "Succesfully found Company Name input"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterCompanyName(companyName), $"Failed to enter {companyName} in field Company Name",
				$"Succesfully entered {companyName} in field Company Name");
			}
			else
			{
				Report.Info("Company Input not found");
			}
		}

		[Then(@"I confirm the new supplier (should|should not) be seen in the supplier manager window")]
		public void ThenIConfirmNewSupplierAddedInSupplierManagerWindow(string condition)
		{
			try
			{
				var newSupplier = new AddNewSupplier();
				newSupplier.EnterSearchTextInSupplyManager(companyName);
				Delay.Seconds(Delay.SpeedFactor * 2);
				newSupplier.ClickSearchButtonInSupplyManager();
				Delay.Seconds(Delay.SpeedFactor * 5);
				if (condition == "should")
				{
					if (newSupplier.IfSupplierExists(companyName) != null)
					{
						Report.IsTrue(newSupplier.ClickNewSupplierInSupplyManager(companyName), $"{companyName} not displayed", $"{companyName} is displayed");
						Delay.Seconds(Delay.SpeedFactor * 5);
					}
				}
				else
				{
					Report.IsTrue(newSupplier.IfSupplierExists(companyName) == null, $"{companyName} exists", $"{companyName} not exists");
				}
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
			}
		}


		[RegexStepDefinition(@"I confirm following tabs appear available")]
		public void ThenIConfirmFollowingTabdAppearAvailable(Table table)
		{
			foreach (TableRow Row in table.Rows)
			{
				var newSupplier = new AddNewSupplier();
				List<string> tabs = newSupplier.AllTabs();				
				Report.IsTrue(tabs.Contains(Row["tabs"]), $"text does not contain tab {Row["tabs"]}", $"text contain tab{ Row["tabs"]}");
			}
		}

		[RegexStepDefinition(@"I click on (.*) tab")]
		public void ThenClickOnGivenTab(string selectTab)
		{
			var newSupplier = new AddNewSupplier();
			Report.IsTrue(newSupplier.ClickSelectedTab(selectTab), $"Failed to click {selectTab} tab",
				$"Succesfully clicked {selectTab} tab");			
		}

		[RegexStepDefinition(@"I confirm following toggles displayed")]
		public void ThenIConfirmFollowingTogglesDisplayed(Table table)
		{
			foreach (TableRow Row in table.Rows)
			{
				var newSupplier = new AddNewSupplier();
				List<string> toggleValues = newSupplier.FetaureToggle();
				Report.IsTrue(toggleValues.Contains(Row["ToggleInfo"]), $"text does not contain tab {Row["ToggleInfo"]}", $"text contain tab{ Row["ToggleInfo"]}");
			}
		}

		[RegexStepDefinition(@"I search with email in the supplier manager window: (.*)")]
		public void ISearchWithEmailInSupplierManagerWindow(string email)
		{
			try
			{
				var newSupplier = new AddNewSupplier();
				newSupplier.ClickEmailRadioButtonForSearch();
				Delay.Seconds(Delay.SpeedFactor * 2);
				newSupplier.EnterSearchTextInSupplyManager(email);
				newSupplier.ClickSearchButtonInSupplyManager();
				Delay.Seconds(Delay.SpeedFactor * 5);
				Report.IsTrue(newSupplier.ClickNewlyAddedSupplierInSupplyManagerWithEmailSearch(), "Supplier not displayed", $"Supplier displayed successfully");
				Delay.Seconds(Delay.SpeedFactor * 5);
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
			}
		}

		[RegexStepDefinition(@"I confirm (.*) Toggle enable check after clicking (back|save) button")]
		public void ThenIConfirmToggleSupplierManagerWindow(string toggleName, string action)
		{
			try
			{
				var newSupplier = new AddNewSupplier();
				string gettoggleColor = null;
				string expectedGreyColor = "rgba(204, 204, 204, 1)";
				string expectedBlueColor = "rgba(33, 150, 243, 1)";
				if (newSupplier.IsToggleButtonEnabled(toggleName) == expectedBlueColor)
				{
					Report.IsTrue(newSupplier.EditButton(), "Failed to click edit button", "Sucessfully clicked edit button");
					Report.IsTrue(newSupplier.ToggleButton(toggleName), "Failed to click toggle", "Successfully clicked toggle");
					Delay.Seconds(Delay.SpeedFactor * 5);
					newSupplier.SaveButton();
				}
				else
				{
					if (action == "back")
					{
						Report.IsTrue(newSupplier.EditButton(), "Failed to click edit button", "Sucessfully clicked edit button");
						Report.IsTrue(newSupplier.ToggleButton(toggleName), "Failed to click toggle", "Successfully clicked toggle");
						Delay.Seconds(Delay.SpeedFactor * 5);
						newSupplier.BackButton();
						Delay.Seconds(Delay.SpeedFactor * 5);
						gettoggleColor = newSupplier.IsToggleButtonEnabled(toggleName);
						Report.IsTrue(gettoggleColor == expectedGreyColor, "Toggle button enabled", "Toggle button disabled as expected");
					}
					else
					{
						Report.IsTrue(newSupplier.EditButton(), "Failed to click edit button", "Sucessfully clicked edit button");
						Report.IsTrue(newSupplier.ToggleButton(toggleName), "Failed to click toggle", "Successfully clicked toggle");
						Delay.Seconds(Delay.SpeedFactor * 5);
						newSupplier.SaveButton();
						Delay.Seconds(Delay.SpeedFactor * 5);
						gettoggleColor = newSupplier.IsToggleButtonEnabled(toggleName);
						Report.IsTrue(gettoggleColor == expectedBlueColor, "Toggle button disabled", "Toggle button enabled as expected");
					}
				}
			}
			catch (Exception e)
			{
				Report.Failure(e.Message);
			}
		}
		
		[RegexStepDefinition(@"I create a new (Manufacturer|Supplier) account with the following parameters and update TReVor information for: (.*)")]
		public void CreateNewAccountsWithFollowingParametersTable(string accountType, string savedAs)
		{
			Report.Info($"Setting up account for user: '{savedAs}'");
			Random rnd = new Random();
			string address = $"{rnd.Next()} {savedAs} Street";
			string phonenumber = DateTime.UtcNow.Ticks.ToString().Substring(8);
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow($"{savedAs.Replace(" ","")}_<random>", "UNITED STATES", "WERCS", $"{savedAs}", "Welcome1!", $"{address}", "", "Latham", "Florida", "12205", $"QA_{savedAs}_{rnd.Next()}", phonenumber,
				phonenumber, $"{accountType}", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = this.SaveUser(subCompanyInfo, savedAs);


			if (this.BasicSignup(savedAs))
			{
				this.SaveUserToTReVor(savedAs, account);
			}
		}
		
	}
}



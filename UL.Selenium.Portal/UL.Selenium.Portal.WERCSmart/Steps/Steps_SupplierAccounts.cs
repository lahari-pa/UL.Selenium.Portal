using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SupplierAccounts")]
	class StepsSupplierAccounts
	{

		[StepDefinition(@"I create supplier account with the following parameters and save as: (.*)")]
		public void GivenIfNotAlreadyCreatedICreateAUserXWithTheFollowingParameters(string savedAs, Table parameters)
		{
			Report.Info("Setting up account for user: '" + savedAs + "'");
			WERCSmartUser account = parameters.CreateInstance<WERCSmartUser>();
			account.Email = EmailFunctions.CreateEmail(account.Email);
			account.Identifier = savedAs;
			NTTQA.Selenium.SpecFlow.Context.AddToContext(savedAs, account, true);
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

			mySignUp.GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
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
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("None", "None", "Up to 1 Product(s)", "Limited", "General Support");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number",
				"Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);
			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.ClickAddRowBillOfMaterials();
			myPkgType.SelectOptionForFieldInTable("Clear Glass", "My Packaging Materials");
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
			myAccount.ClickTabMyLibrary("My Brands");
			myAccount.ClickAddNewMyLibrary("My Brands");
			myBrand.EnterBrandNameExpandedRow("TestBrand");
			myBrand.ClickSaveMyBrandsGrid();
			myBrand.ActiveValueIsYesForLastBrand("Yes");
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
			myProductsetup.CreateProductAndTakeToSubmitted("product1", "Chalk");
			Report.Info(savedAs + " Created");
		}


	}
}

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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@SubUpgrade
@ProductSetUp
@SupplierAccounts
@run_SupplierAccounts

Feature: SupplierAccounts

@ScenarioId:1393
Scenario: Create new account with supplier settings for Packaging Only
Given I create a new supplier packaging only account with the following parameters and update TReVor information for: PackagingOnly

@ScenarioId:1389
Scenario: Create new account with supplier settings for LockOut
Given I create a new supplier lockout account with the following parameters and update TReVor information for: AccountLockOut

@ScenarioId:1383
Scenario: Create new account with supplier settings for Canada Address only
#Given I log in with email: User_4b44c15b958d.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier Canada address only account with the following parameters and update TReVor information for: Canada Address Only

@ScenarioId:1399
Scenario: Create new account with supplier settings for Stewardship only
Given I create a new supplier Stewardship only account with the following parameters and update TReVor information for: fullstwrdshiponly


@ScenarioId:1384
Scenario: Create new account with supplier settings for Canada Has Address Packaging
#Given I log in with email: User_ea0759ff5975.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier Canada has address packaging account with the following parameters and update TReVor information for: CanadaHasAddressPackaging


@ScenarioId:1386
Scenario: Create new account with supplier settings for Canada Has pack and partial stewardship
Given I go to the WERCSmart Log in
#Given I log in with email: User_c062d3b9f22e.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier Canada has pack and partial stewardship account with the following parameters and update TReVor information for: CanadaHasPackandPartialStewardship


@ScenarioId:1387
Scenario: Create new account with supplier settings for Canada no pkg partial stewardship
#Given I go to the WERCSmart Log in
#Given I log in with email: User_7d26bd270428.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier no pkg stewardship partial and update TReVor information for: CanadaNoPkgStwdPartial


@ScenarioId:1388
Scenario: Create new account with supplier settings for data consent
Given I create a new supplier data consent and update TReVor information for: DataConsentAccount


@ScenarioId:1390
Scenario: Create new account with supplier settings for no Canada data
Given I create a new supplier no Canada data and update TReVor information for: NoCanadaData


@ScenarioId:1391
Scenario: Create new account with supplier settings for no Canada yes pkg stwd full
Given I create a new supplier no canada yes packaging full stewardship with the following parameters and update TReVor information for: NoCanYesPkgStwdFull


@ScenarioId:1395
Scenario: Create new account with supplier settings for partial stewardship only
Given I create a new supplier Partial Stewardship only account with the following parameters and update TReVor information for: PartialStewardshipOnly


@ScenarioId:1396
Scenario: Create new account with supplier settings for Premium Subscription
Given I create a new supplier premium subscription with the following parameters and update TReVor information for: PremiumSubscriptionAccount



@ScenarioId:1394
Scenario: Create new account with supplier settings for partial stewardship and packaging
Given I create a new supplier Partial Stewardship and packaging account with the following parameters and update TReVor information for: PackagePartialStewardship


@ScenarioId:1392
Scenario: Create new account with supplier settings for no private label products
Given I create a new supplier no PLP with the following parameters and update TReVor information for: NoPLProducts Account


@ScenarioId:1385
Scenario: Create new account with supplier settings for Canada has all data
Given I create a new supplier Canada has all data with the following parameters and update TReVor information for: CanadaHasAllData


@ScenarioId:1398
Scenario: Create new account with supplier settings for products in cart
Given I create a new supplier Products in cart with the following parameters and update TReVor information for: ProductsInCart


@ScenarioId:1400
Scenario: Create new account with supplier settings for Sub Cart
Given I create a new supplier sub cart with the following parameters and update TReVor information for: SubCart


@ScenarioId:1401
Scenario: Create new account with supplier settings for Visual
Given I create a new supplier Visual with the following parameters and update TReVor information for: VisualAccount


@ScenarioId:6939
Scenario: Create new account with supplier settings for No Products Account
Given I create a new supplier NO products account with the following parameters and update TReVor information for: NoProductsAccount

@ScenarioId:7035
Scenario: Create new account with supplier settings for Password Reset Account
Given I create a new supplier NO products account with the following parameters and update TReVor information for: PasswordResetAccount

@ScenarioId:8141
Scenario: Create new account with supplier settings for Cart No Products 
Given I create a new supplier NO products account with the following parameters and update TReVor information for: CartNoProducts

Scenario: Create new account with a subscription but no products accounts
Given I create a new supplier NO products account with the following parameters and update TReVor information for: SubCart

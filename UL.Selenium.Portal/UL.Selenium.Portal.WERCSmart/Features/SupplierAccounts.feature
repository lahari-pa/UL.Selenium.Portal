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
#@ignore
@run_SupplierAccounts

Feature: SupplierAccounts

@TestCase:1234502
Scenario: [1234502] Create new account with supplier settings for Packaging Only
	Given I create a new supplier packaging only account with the following parameters and update TReVor information for: PackagingOnly

@TestCase:1234503
Scenario: [1234503]  Create new account with supplier settings for LockOut
	Given I create a new supplier lockout account with the following parameters and update TReVor information for: AccountLockOut

@TestCase:1234504
Scenario: [1234504] Create new account with supplier settings for Canada Address only
	Given I create a new supplier Canada address only account with the following parameters and update TReVor information for: Canada Address Only

@TestCase:1234505
Scenario: [1234505] Create new account with supplier settings for Stewardship only
	Given I create a new supplier Stewardship only account with the following parameters and update TReVor information for: fullstwrdshiponly

@TestCase:1234506
Scenario: [1234506] Create new account with supplier settings for Canada Has Address Packaging
	Given I create a new supplier Canada has address packaging account with the following parameters and update TReVor information for: CanadaHasAddressPackaging

@TestCase:1234507
Scenario: [1234507] Create new account with supplier settings for Canada Has pack and partial stewardship
	#Given I go to the WERCSmart Log in
	Given I create a new supplier Canada has pack and partial stewardship account with the following parameters and update TReVor information for: CanadaHasPackandPartialStewardship

@TestCase:1234508
Scenario: [1234508] Create new account with supplier settings for Canada no pkg partial stewardship
	Given I create a new supplier no pkg stewardship partial and update TReVor information for: CanadaNoPkgStwdPartial

@TestCase:1234509
Scenario: [1234509] Create new account with supplier settings for data consent
	Given I create a new supplier data consent and update TReVor information for: DataConsentAccount

@TestCase:1234510
Scenario: [1234510] Create new account with supplier settings for no Canada data
	Given I create a new supplier no Canada data and update TReVor information for: NoCanadaData

@TestCase:1234511
Scenario: [1234511] Create new account with supplier settings for no Canada yes pkg stwd full
	Given I create a new supplier no canada yes packaging full stewardship with the following parameters and update TReVor information for: NoCanYesPkgStwdFull

@TestCase:1234512
Scenario: [1234512] Create new account with supplier settings for partial stewardship only
	Given I create a new supplier Partial Stewardship only account with the following parameters and update TReVor information for: PartialStewardshipOnly

@TestCase:1234513
Scenario: [1234513] Create new account with supplier settings for Premium Subscription
	Given I create a new supplier premium subscription with the following parameters and update TReVor information for: PremiumSubscriptionAccount

@TestCase:1234514
Scenario: [1234514] Create new account with supplier settings for partial stewardship and packaging
	Given I create a new supplier Partial Stewardship and packaging account with the following parameters and update TReVor information for: PackagePartialStewardship

@TestCase:12345015
Scenario: [12345015] Create new account with supplier settings for no private label products
	Given I create a new supplier no PLP with the following parameters and update TReVor information for: NoPLProducts Account

@TestCase:1234516
Scenario: [1234516] Create new account with supplier settings for Canada has all data
	Given I create a new supplier Canada has all data with the following parameters and update TReVor information for: CanadaHasAllData

@TestCase:1234517
Scenario: [1234517] Create new account with supplier settings for products in cart
	Given I create a new supplier Products in cart with the following parameters and update TReVor information for: ProductsInCart

@TestCase:1234518
Scenario: [1234518] Create new account with supplier settings for Sub Cart
	Given I create a new supplier sub cart with the following parameters and update TReVor information for: SubCart

@TestCase:1234519
Scenario: [1234519] Create new account with supplier settings for Visual
	Given I create a new supplier Visual with the following parameters and update TReVor information for: VisualAccount

@TestCase:1234520
Scenario: [1234520] Create new account with supplier settings for No Products Account
	Given I create a new supplier NO products account with the following parameters and update TReVor information for: NoProductsAccount

@TestCase:1234521
Scenario: [1234521] Create new account with supplier settings for Password Reset Account
	Given I create a new supplier NO products account with the following parameters and update TReVor information for: PasswordResetAccount

@TestCase:1234522
Scenario: [1234522] Create new account with supplier settings for Cart No Products
	Given I create a new supplier NO products account with the following parameters and update TReVor information for: CartNoProducts

@TestCase:1234523
Scenario: [1234523] Create new account with a subscription but no products accounts
	Given I create a new supplier NO products account with the following parameters and update TReVor information for: SubCartNoProducts

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
@run_SupplierAccounts2

Feature: SupplierAccounts2

#Scenario: [1234501a] Create new account with supplier settings for Products Account
#	Given I create a new supplier products account with the following parameters and update TReVor information for: ProductAccount

Scenario Outline: [1234501] Create new accounts
	Given I create a new <Account_Type> account with the following parameters and update TReVor information for: <TReVor_ID>

	Examples:
	| Scenario Name                   | TReVor_ID                          | Account_Type |
	| [#1234501a] Create new accounts | ProductAccount                     | Manufacturer |
	| [#1234501b] Create new accounts | PackagingOnly                      | Manufacturer |
	| [#1234501c] Create new accounts | AccountLockOut                     | Manufacturer |
	| [#1234501d] Create new accounts | Canada Address Only                | Manufacturer |
	| [#1234501e] Create new accounts | fullstwrdshiponly                  | Manufacturer |
	| [#1234501f] Create new accounts | CanadaHasAddressPackaging          | Manufacturer |
	| [#1234501g] Create new accounts | CanadaHasPackandPartialStewardship | Manufacturer |
	| [#1234501h] Create new accounts | CanadaNoPkgStwdPartial             | Manufacturer |
	| [#1234501i] Create new accounts | DataConsentAccount                 | Manufacturer |
	| [#1234501j] Create new accounts | NoCanadaData                       | Manufacturer |
	| [#1234501k] Create new accounts | NoCanYesPkgStwdFull                | Manufacturer |
	| [#1234501l] Create new accounts | PartialStewardshipOnly             | Manufacturer |
	| [#1234501m] Create new accounts | PremiumSubscriptionAccount         | Manufacturer |
	| [#1234501n] Create new accounts | PackagePartialStewardship          | Manufacturer |
	| [#1234501o] Create new accounts | NoPLProducts Account               | Manufacturer |
	| [#1234501p] Create new accounts | CanadaHasAllData                   | Manufacturer |
	| [#1234501q] Create new accounts | ProductsInCart                     | Manufacturer |
	| [#1234501r] Create new accounts | SubCart                            | Manufacturer |
	| [#1234501s] Create new accounts | VisualAccount                      | Manufacturer |
	| [#1234501t] Create new accounts | NoProductsAccount                  | Manufacturer |
	| [#1234501u] Create new accounts | PasswordResetAccount               | Manufacturer |
	| [#1234501v] Create new accounts | CartNoProducts                     | Manufacturer |
#	| [#1234501w] Create new accounts | SubCartNoProducts                  | Manufacturer |

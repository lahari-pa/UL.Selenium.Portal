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

@TReVorId:22360
Scenario: Create new account with supplier settings for Products Account
Given I create a new supplier products account with the following parameters and update TReVor information for: randomUser


@TReVorId:22377
Scenario: Create new account with supplier settings for Packaging Only
Given I create a new supplier packaging only account with the following parameters and update TReVor information for: PackagingOnly

@TReVorId:22372
Scenario: Create new account with supplier settings for LockOut
Given I create a new supplier lockout account with the following parameters and update TReVor information for: randomUser

@TReVorId:22368
Scenario: Create new account with supplier settings for Canada Address only
#Given I log in with email: User_4b44c15b958d.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier Canada address only account with the following parameters and update TReVor information for: randomUser

@TReVorId:22381
Scenario: Create new account with supplier settings for Stewardship only
Given I create a new supplier Stewardship only account with the following parameters and update TReVor information for: randomUser


@TReVorId:22369
Scenario: Create new account with supplier settings for Canada Has Address Packaging
#Given I log in with email: User_c062d3b9f22e.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier Canada has address packaging account with the following parameters and update TReVor information for: randomUser


@TReVorId:22370
Scenario: Create new account with supplier settings for Canada Has pack and partial stewardship
Given I go to the WERCSmart Log in
#Given I log in with email: User_c062d3b9f22e.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier Canada has pack and partial stewardship account with the following parameters and update TReVor information for: randomUser


@TReVorId:22375
Scenario: Create new account with supplier settings for no pkg partial stewardship
#Given I go to the WERCSmart Log in
#Given I log in with email: User_7d26bd270428.kxxyxunf@mailosaur.io and password: Welcome1!
Given I create a new supplier no pkg stewardship partial and update TReVor information for: randomUser


@TReVorId:22371
Scenario: Create new account with supplier settings for data consent
Given I create a new supplier data consent and update TReVor information for: randomUser


@TReVorId:22373
Scenario: Create new account with supplier settings for no Canada data
Given I create a new supplier no Canada data and update TReVor information for: randomUser


@TReVorId:22374
Scenario: Create new account with supplier settings for no Canada yes pkg stwd full
Given I create a new supplier no canada yes packaging full stewardship with the following parameters and update TReVor information for: randomUser


@TReVorId:22379
Scenario: Create new account with supplier settings for partial stewardship only
Given I create a new supplier Partial Stewardship only account with the following parameters and update TReVor information for: randomUser


@TReVorId:22380
Scenario: Create new account with supplier settings for Premium Subscription
Given I create a new supplier premium subscription with the following parameters and update TReVor information for: randomUser



@TReVorId:22378
Scenario: Create new account with supplier settings for partial stewardship and packaging
Given I create a new supplier Partial Stewardship and packaging account with the following parameters and update TReVor information for: randomUser


@TReVorId:22376
Scenario: Create new account with supplier settings for no private label products
Given I create a new supplier no PLP with the following parameters and update TReVor information for: randomUser


Scenario: Create new account with supplier settings for Canada has all data
Given I create a new supplier Canada has all data with the following parameters and update TReVor information for: randomUser


Scenario: Create new account with supplier settings for products in cart
Given I create a new supplier Products in cart with the following parameters and update TReVor information for: randomUser


Scenario: Create new account with supplier settings for Sub Cart
Given I create a new supplier sub cart with the following parameters and update TReVor information for: randomUser


Scenario: Create new account with supplier settings for Visual
Given I create a new supplier Visual with the following parameters and update TReVor information for: randomUser

@Shared
@admin
@LandingPage
@Login
@Homepage
@wercsmart
@MyAccount
@run_ResetPasswords
@ignore

Feature: Reset Passwords

#@testaccount
#@tfs_design
#@ScenarioId:7031
Scenario: Reset password for specific TReVor test user accounts

Given I update the password for the following TReVor test users:
| User       |
| UPCAccount |

@TrevorUsers
@JacobRun
@ScenarioId:1105
Scenario: Reset password for TReVor test user accounts

Given I update the password for all TReVor Test Users within the current branch

using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:MyAccount")]
	class WERCSmart_MyAccount
	{
		[RegexStepDefinition(@"In the My Account section, click the 'Company Information' link")]
		public void ClickTheCompanyInformationLink()
		{
			string linkText = "Company Information";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Company Information' link (should|should not) exist")]
		public void ClickTheCompanyInformationLinkIsDisplayed(string condition)
		{
			string linkText = "Company Information";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Subscription Information' link")]
		public void ClickTheSubscriptionInformationLink()
		{
			string linkText = "Subscription Information";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Subscription Information' link (should|should not) exist")]
		public void ClickTheSubscriptionInformationLinkIsDisplayed(string condition)
		{
			string linkText = "Subscription Information";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Payment Methods' link")]
		public void ClickThePaymentMethodsLink()
		{
			string linkText = "Payment Methods";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Payment Methods' link (should|should not) exist")]
		public void ClickThePaymentMethodsIsDisplayed(string condition)
		{
			string linkText = "Payment Methods";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Order History' link")]
		public void ClickTheOrderHistoryLink()
		{
			string linkText = "Order History";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Order History' link (should|should not) exist")]
		public void ClickTheOrderHistoryIsDisplayed(string condition)
		{
			string linkText = "Order History";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'My Library' link")]
		public void ClickTheMyLibraryLink()
		{
			string linkText = "My Library";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'My Library' link (should|should not) exist")]
		public void ClickTheMyLibraryIsDisplayed(string condition)
		{
			string linkText = "My Library";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Subscription Price List' link")]
		public void ClickTheSubscriptionPriceListLink()
		{
			string linkText = "Subscription Price List";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Subscription Price List' link (should|should not) exist")]
		public void ClickTheSubscriptionPriceListIsDisplayed(string condition)
		{
			string linkText = "Subscription Price List";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the My Account section, after clicking the 'Subscription Price List' link, confirm pdf file is downloaded")]
		public void AfterClickingHR1321PdfIsDownloaded()
		{
			string file = "GetActiveSubscriptionPriceList.pdf";
			string savedAs = "SubscriptionPriceList";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Invite New User' link")]
		public void ClickTheInviteNewUserLink()
		{
			string linkText = "Invite New User";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Invite New User' link (should|should not) exist")]
		public void ClickTheInviteNewUserIsDisplayed(string condition)
		{
			string linkText = "Invite New User";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}

		[RegexStepDefinition(@"In the My Account section, the 'Add New User' modal window (should|should not) be displayed")]
		public void TheAddNewUserModalIsDisplayed(string condition)
		{
			string modalTitle = "Add New User";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}

		[RegexStepDefinition(@"In the My Account section, the 'Add New User' modal window (should|should not) be displayed with 'Thank You' text")]
		public void TheAddNewUserModalIsDisplayedWithText(string condition)
		{
			string title = "×\r\nAdd New User";
			string text = "Thank You\r\nThe user has been provided an invitation via email. User must respond to the invitation to finalize the addition to the account.";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, title, text);
		}
		[RegexStepDefinition(@"In the My Account section, in the 'Add New User' modal window for section '(First Name:|Last Name:|Title:|Company Role:|Email Address:|Confirm Email:|Company Phone:|Extension:|Mobile Phone:|WERCSmart Role:|Country:)' enter value: (.*)")]
		public void TheInAddNewUserModalEnterValue(string section, string value)
		{
			new Steps_Prototype().SetTheSectionOptionTo(section, value);
		}
		[RegexStepDefinition(@"In the My Account section, in the 'Add New User' click the button (Cancel|Send Invite|Close)")]
		public void TheInAddNewUserModalClickButton(string button)
		{
			string popupTitle = "Add New User";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
		[RegexStepDefinition(@"In the My Account section, in the 'Add New User' (check|uncheck) checkbox 'Send Notifications'")]
		public void TheInAddNewUserModalCheckbox(string check_uncheck)
		{
			string checkbox = "Send Notifications";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(check_uncheck, checkbox);
		}

		[RegexStepDefinition(@"In the My Account section, click the 'Upgrade' button")]
		public void ClickTheUpgradeButton()
		{
			string button = "Upgrade";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Sync Zuora' refresh button")]
		public void ClickTheSyncZuoraButton()
		{
			string button = "Sync Zuora";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the My Account section, set the 'Pesticide Expiration' option to (On|Off)")]
		public void ClickThePesticideExpiration(string on_off)
		{
			if (Report.IsTrue(new MyAccount().PesticideExpirationToggleExists(), "Failed to find the 'Pesticide Expiration' toggle", "Successfully found the 'Pesticide Expiration' toggle"))
			{
				Report.IsTrue(new MyAccount().PesticideExpirationToggleOn_Off(on_off), $"Failed to set the 'Pesticide Expiration' toggle to {on_off}", $"Successfully set the 'Pesticide Expiration' toggle to {on_off}");
			}
		}
		[RegexStepDefinition(@"In the My Account section, verify the Subscription option '(Level:|Agent Support:|Formulated:|Enhanced:|Article:|Single-Retailer:)' is (.*)")]
		public void CheckSubscriptionData(string option, string value)
		{
			Report.IsTrue(new MyAccount().VerifySubscriptionValues(option, value), $"Failed to confirm the Subscription option '{option}' is '{value}'", $"Successfully confirmed the Subscription option '{option}' is '{value}'");

		}
		[RegexStepDefinition(@"In the My Account section, verify the Company Information: '(Administrator Name|Administrator Email|Company Domain Name)' is (.*)")]
		public void CheckCompanyInformation(string option, string value)
		{
			Report.IsTrue(new MyAccount().CheckCompanyInfo(option, value), $"Failed to confirm the Company Information: '{option}' is '{value}'", $"Successfully confirmed the Company Information: '{option}' is '{value}'");

		}
		[RegexStepDefinition(@"In the My Account section, filter users by the (User Accounts|Division Accounts|All|Approved|Rejected|Invited|Invite Expired|Requested By User|New and Active) option")]
		public void FilterUserByOption(string button)
		{
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Clear' refresh button")]
		public void ClickTheClearButton()
		{
			string button = "Clear";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the My Account section, search user by entering Name or Email Address: (.*)")]
		public void SearchUserByNameOrEmail(string name_email)
		{
			Report.IsTrue(new MyAccount().EnterSearchTextAndClickFind(name_email), $"Failed to enter Name or Email Address and click the 'Search' icon", $"Successfully entered Name or Email Address and clicked the 'Search' icon");
		}
		[RegexStepDefinition(@"In the My Account section, click action (Details|Reset Password|Change Owner|Resend Invite|Reject Request) for user: (.*)")]
		public void ClickActionForUser(string action, string username)
		{
			Report.IsTrue(new MyAccount().ForUserClickAction(username, action),
				$"Failed to click action:{action} for user: {username}",
				$"Successfully clicked action: {action} for user: {username}");
		}
		[RegexStepDefinition(@"In the My Account section, user (is|is not) exist with name (.*), email (.*) and role (.*)")]
		public void ChekUserIsDisplayed(string is_isnot, string username, string email, string role)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new MyAccount().User_Added_Check(username, email, role) == expected, $"User {(expected ? "is not" : "is")} exist in the Users table",
						$"User {is_isnot} exist in the Users table");
		}
		[RegexStepDefinition(@"In the My Account section, in the 'User Details' modal window for section '(Title:|Company Role:|Company Phone:|Extension:|Mobile Phone:|Country:)' enter value: (.*)")]
		public void TheInUserDetailsModalEnterValue(string section, string value)
		{
			new Steps_Prototype().SetTheSectionOptionTo(section, value);
		}
		[RegexStepDefinition(@"In the My Account section, in the 'User Details' click the button (Cancel|Save)")]
		public void TheInUserDetailsModalClickButton(string button)
		{
			string popupTitle = "User Details";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
		[RegexStepDefinition(@"In the My Account section, in the 'User Details' (check|uncheck) checkbox 'Send Notifications'")]
		public void TheInUserDetailsModalCheckbox(string check_uncheck)
		{
			string checkbox = "Send Notifications";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(check_uncheck, checkbox);
		}
		[RegexStepDefinition(@"In the My Account section, the 'User Details' modal window (should|should not) be displayed")]
		public void TheUserDetailsModalIsDisplayed(string condition)
		{
			string modalTitle = "User Details";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}
		[RegexStepDefinition(@"In the My Account section, the 'Change Owner' modal window (should|should not) be displayed")]
		public void TheChangeOwnerModalIsDisplayed(string condition)
		{
			string modalTitle = "Change Owner";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}
		[RegexStepDefinition(@"In the My Account section, in the 'Change Owner' click the button (Cancel|Transfer)")]
		public void TheInChangeOwnerModalClickButton(string button)
		{
			string popupTitle = "Change Owner";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
	}
}

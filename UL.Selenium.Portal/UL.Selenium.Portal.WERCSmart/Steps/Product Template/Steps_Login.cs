using System;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;
using UL.Automation.WebDriver.Classes;
using TReVor.Core.Classes.Software;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.ProductTemplate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UL.Selenium.Portal.WERCSmart.Steps.Product_Template
{
	[Binding, Scope(Tag = "ProductTemplateLogin")]
	class Steps_Login
	{
		[StepDefinition(@"In the Product Template Login page, enter username: (.*)")]
		public void ProductTemplateLoginEnterUsername(string username)
		{
			var ProductTemplateLogin = new ProductTemplateLogin();
			if(Report.IsTrue(ProductTemplateLogin.UserNameInputExists(),$"Failure, username input does not exist.",$"Success, username input does exist."))
			{
				Report.IsTrue(ProductTemplateLogin.UserNameInputEnterText(username),$"Failure, failed to enter '{username}' in username input.",$"Success, entered '{username}' in username input.");
			}
		}

		[StepDefinition(@"In the Product Template Login page, enter password: (.*)")]
		public void ProductTemplateLoginEnterPassword(string password)
		{
			var ProductTemplateLogin = new ProductTemplateLogin();
			if (Report.IsTrue(ProductTemplateLogin.PasswordInputExists(), $"Failure, password input does not exist.", $"Success, password input does exist."))
			{
				Report.IsTrue(ProductTemplateLogin.PasswordInputEnterText(password), $"Failure, failed to enter '*******' in password input.", $"Success, entered '*******' in password input.");
			}
		}

		[StepDefinition(@"In the Product Template Login page, click the Next button")]
		public void ProductTemplateLoginNextButtonClick()
		{
			var ProductTemplateLogin = new ProductTemplateLogin();
			if (Report.IsTrue(ProductTemplateLogin.NextButtonExists(), $"Failure, Next button does not exist.", $"Success, Next button does exist."))
			{
				Report.IsTrue(ProductTemplateLogin.NextButtonClick(), $"Failure, failed to click Next button.", $"Success, clicked Next button.");
			}
		}

		[StepDefinition(@"In the Product Template Login page, log in with account saved in TReVor as: (.*)")]
		public void ProductTemplateLoginToAccount(string alias)
		{
			Report.UseSubSteps = true;
			//SoftwareCredentialBasic user = TReVor.Integrations.Classes.TReVorSettings.Credentials.GetCredential(alias);
			SoftwareCredentialBasic user = TReVor.Integrations.Classes.TReVorSettings.VaultRecords.GetCredential(alias).ToSoftwareCredentialBasic();
			if (user == null)
			{
				Report.Failure($"Failed to find a user with alias: {alias}!");
				return;
			}
			Report.StartSubStep($"In the Product Template Login page, enter username: {user.UserName}");
			this.ProductTemplateLoginEnterUsername(user.UserName);
			Report.StartSubStep($"In the Product Template Login page, enter password: *******");
			this.ProductTemplateLoginEnterPassword(user.Password);
			Report.StartSubStep($"In the Product Template Login page, click the Next button");
			this.ProductTemplateLoginNextButtonClick();
		}
	}
}

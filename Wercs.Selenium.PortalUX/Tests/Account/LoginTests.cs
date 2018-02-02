using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Core.ExtensionMethods;
using Wercs.Selenium.PortalUX.Pages.Account;

namespace Wercs.Selenium.PortalUX.Tests.Account
{
	[TestClass]
	public class LoginTests : TestBase
	{
		[TestMethod]
		public void VerifyWercSmartTextIsPresent()
		{
			var expectedText = "WERCSmart®";

			var loginPage = this.Driver.GoTo<LoginPage>(LoginPage.GetUrl());
			Assert.AreEqual(expectedText, loginPage.WercSmartLogoText.Text);
		}

		[TestMethod]
		public void VerifyCanClickButton()
		{
			var loginPage = this.Driver.GoTo<LoginPage>(LoginPage.GetUrl());
			Assert.IsNotNull(loginPage.LoginButton);

			var result = loginPage.LoginButton.Click();

			Assert.IsNotNull(result);
		}
	}
}

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

			var loginPage = Driver.GoTo<LoginPage>(LoginPage.GetUrl());
			Assert.AreEqual(expectedText, loginPage.WercSmartLogoText.Text);
		}
	}
}

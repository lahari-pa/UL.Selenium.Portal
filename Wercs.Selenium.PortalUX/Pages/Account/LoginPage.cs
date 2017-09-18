using OpenQA.Selenium;
using Selenium.Core.Elements;
using System;

namespace Wercs.Selenium.PortalUX.Pages.Account
{
	/// <summary>
	/// The account login page.
	/// </summary>
	public class LoginPage : PortalPageBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginPage"/> class.
		/// </summary>
		/// <param name="driver">The web driver to use</param>
		public LoginPage(IWebDriver driver)
			: base(driver)
		{
		}

		/// <summary>
		/// Stores the URL path for this page
		/// </summary>
		private const string _url = "Account/Login";

		/// <summary>
		/// Gets the URL of this page.
		/// </summary>
		/// <returns></returns>
		public static Uri GetUrl() => new Uri(SeleniumHelper.BaseUrl + _url);

		/// <summary>
		/// Gets the WercSmart logo text element
		/// </summary>
		[BuildsBy("body > div.login-wrapper > div > div.panel-heading > div > h2")]
		public IElement WercSmartLogoText { get; private set; }
	}
}

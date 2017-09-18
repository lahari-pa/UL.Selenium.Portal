using OpenQA.Selenium;
using Selenium.Core;
using System;
using Wercs.Selenium.PortalUX.Properties;

namespace Wercs.Selenium.PortalUX
{
	/// <summary>
	/// Selenium instance handling operations
	/// </summary>
	internal static class SeleniumHelper
	{
		/// <summary>
		/// Gets the active WebDriver instance, if there is one.
		/// </summary>
		public static IWebDriver WebDriver => CoreSeleniumHelper.WebDriverInstance;

		/// <summary>
		/// Gets root URL for testing website
		/// </summary>
		public static Uri BaseUrl => new Uri(Settings.Default.BaseURL);

	}
}

using OpenQA.Selenium;
using Selenium.Core.Elements;
using Selenium.Core.Elements.Events;
using Selenium.Core.ExtensionMethods;
using Selenium.Core.Pages;
using System;
using Wercs.Selenium.PortalUX.Elements;

namespace Wercs.Selenium.PortalUX.Pages.Account
{
	/// <summary>
	/// The account login page.
	/// </summary>
	internal class LoginPage : PortalPageBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginPage"/> class.
		/// </summary>
		/// <param name="driver">The web driver to use.</param>
		public LoginPage(IWebDriver driver)
			: base(driver)
		{
		}

		/// <summary>
		/// Stores the URL path for this page.
		/// </summary>
		private const string Url = "Account/Login";

		/// <summary>
		/// Gets the URL of this page.
		/// </summary>
		/// <returns></returns>
		public static Uri GetUrl() => new Uri(SeleniumHelper.BaseUrl + Url);

		/// <summary>
		/// Gets the WercSmart logo text element.
		/// </summary>
		[BuildsBy("body > div.login-wrapper > div > div.panel-heading > div > h2")]
		public IElement WercSmartLogoText { get; private set; }

		/// <summary>
		/// Gets the login button.
		/// </summary>
		[BuildsBy("#frmLogin > input")]
		public IButton<IPage> LoginButton { get; private set; }

		/// <summary>
		/// Event handler for the click method of the LoginButton.
		/// </summary>
		/// <param name="sender">The IButton creating the event.</param>
		/// <param name="e">The event arguments for the click event.</param>
		[SubscribesTo(Event = nameof(IButton.OnClick), Member = nameof(LoginButton))]
		private void LoginButton_Click(object sender, EventArgs<IPage> e)
		{
			// Pause to let the page start doing its thing
			this.Driver.WaitForAHalfSecondEvenThoughItIsABadIdea();

			// Wait for that navigation to be complete
			this.Driver.WaitForPageReady();
			this.Driver.WaitForAjaxComplete();

			// Once navigation is complete, either we're on a different page URL or we are still on the same page.
			if (this.Driver.Url.Contains(Url))
			{
				e.EventReturn = new LoginPage(this.Driver);
			}
			else
			{
				// TODO: Return a real page after login here
				e.EventReturn = null;
			}
		}

		/// <summary>
		/// Gets the error message presented if the email is invalid.
		/// </summary>
		[BuildsBy("#loginEmail_error > span", BuildsByAttribute.PrescenceBehavior.Sometimes)]
		public IElement EmailError { get; private set; }

		/// <summary>
		/// Gets the email login textbox.
		/// </summary>
		[BuildsBy("#frmLogin > div:nth-child(1) > input")]
		public ITextbox EmailBox { get; private set; }
	}
}

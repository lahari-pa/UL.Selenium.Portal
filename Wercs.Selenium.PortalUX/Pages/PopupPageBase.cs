using OpenQA.Selenium;
using Selenium.Core.ExtensionMethods;
using Selenium.Core.Pages;

namespace Wercs.Selenium.PortalUX.Pages
{
	internal abstract class PopupPageBase : PageBase
	{
		/// <summary>
		/// Stores the close button selector.
		/// </summary>
		private readonly string _closeButtonSelector = "TODO: FIGURE OUT WHAT I SHOULD BE";

		/// <summary>
		/// Initializes a new instance of the <see cref="PopupPageBase"/> class. Will take control
		/// of the openingPageBase.
		/// </summary>
		/// <param name="driver">
		/// The driver.
		/// </param>
		/// <param name="openingPageBase">
		/// The page that opens this partial page element.
		/// </param>
		/// <param name="closeButtonCssSelector">
		/// The CSS selector for the close button. If not supplied, defaults to the standard popup ID.
		/// </param>
		/// <param name="generateElements">
		/// The generate elements.
		/// </param>
		protected PopupPageBase(
			IWebDriver driver,
			PortalPageBase openingPageBase,
			string closeButtonCssSelector = null,
			GenerateElementsBehavior generateElements = GenerateElementsBehavior.Immediate)
			: base(driver, generateElements)
		{
			this.ContainerPage = openingPageBase;
			this.ContainerPage.IsLockedByPopup = true;

			if (!string.IsNullOrEmpty(closeButtonCssSelector))
			{
				this._closeButtonSelector = closeButtonCssSelector;
			}
		}

		/// <summary>
		/// Gets or sets the base page.
		/// </summary>
		protected PortalPageBase ContainerPage { get; set; }

		/// <summary>
		/// Close this partial page base.
		/// </summary>
		public void Close()
		{
			// Locate the close element button for this modal dialog.
			var button = this.Driver.FindElementSafely(By.CssSelector(this._closeButtonSelector));
			if (button == null)
			{
				throw new NotFoundException("Unable to locate appropriate button to close this modal dialog.");
			}

			button.Click(this.Driver);

			this.ContainerPage.IsLockedByPopup = false;
		}
	}
}

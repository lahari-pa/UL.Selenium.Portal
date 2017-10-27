using OpenQA.Selenium;

namespace Wercs.Selenium.PortalUX.Pages
{
	public class PortalPageBase : global::Selenium.Core.Pages.PageBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GoodGuidePageBase"/> class.
		/// </summary>
		/// <param name="driver">
		/// The driver.
		/// </param>
		/// <param name="generateElements">
		/// The generate elements.
		/// </param>
		protected PortalPageBase(IWebDriver driver, GenerateElementsBehavior generateElements = GenerateElementsBehavior.Immediate)
			: base(driver, generateElements)
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether the page is presently locked by a popup.
		/// </summary>
		public bool IsLockedByPopup { get; set; }
	}
}

using OpenQA.Selenium;
using Selenium.Core.Elements;
using Selenium.Core.Elements.ConcreteTypes;
using Selenium.Core.ExtensionMethods;
using System;

namespace Wercs.Selenium.PortalUX.Elements.ConcreteTypes
{
	/// <summary>
	/// A button element
	/// </summary>
	[ConcreteTestClass(TestsForType = typeof(IButton))]
	public class Button : WebElementWrapper, IButton, IBuildableElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Button"/> class.
		/// </summary>
		/// <param name="wrappedElement">The web element representing a button.</param>
		public Button(IWebElement wrappedElement)
			: base(wrappedElement)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Button"/> class.
		/// </summary>
		/// <param name="cssSelector">The CSS selector to create the button.</param>
		public Button(string cssSelector)
			: base(cssSelector)
		{
		}

		/// <summary>
		/// Event fired when this button is clicked
		/// </summary>
		public event EventHandler<object> OnClick;

		/// <summary>
		/// Perform a click on this element
		/// </summary>
		/// <param name="eventArguments">
		/// Optional object to pass to the <see cref="IButton.OnClick"/> method
		/// </param>
		public void Click(object eventArguments = null)
		{
			this.WrappedElement.Click(SeleniumHelper.WebDriver);

			FireEvent(OnClick, eventArguments);
		}

		/// <summary>
		/// Method for getting a new instance of this type, provided it meets the requirements.
		/// </summary>
		/// <param name="buildsByAttribute">The builds by attribute to construct the element.</param>
		/// <param name="objectType">The parameter is not used.</param>
		/// <returns>Instance of the requested type, otherwise null if it fails the test.</returns>
		public object GetObject(BuildsByAttribute buildsByAttribute, Type objectType)
		{
			IButton obj = null;
			try
			{
				obj = new Button(buildsByAttribute.CssSelector);
			}
			catch (ArgumentException)
			{
				if (buildsByAttribute.IsRequired)
				{
					throw;
				}
			}
			return obj;
		}
	}
}

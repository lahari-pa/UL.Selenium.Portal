using OpenQA.Selenium;
using Selenium.Core.Elements;
using Selenium.Core.Elements.ConcreteTypes;
using Selenium.Core.Elements.Events;
using Selenium.Core.ExtensionMethods;
using System;
using System.Linq;

namespace Wercs.Selenium.PortalUX.Elements.ConcreteTypes
{
	/// <summary>
	/// A button element
	/// </summary>
	[ConcreteTestClass(TestsForType = typeof(IButton<>))]
	public class Button<TClickReturn> : Button, IButton<TClickReturn>, IBuildableElement
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
		public new event EventHandler<EventArgs<TClickReturn>> OnClick;

		/// <summary>
		/// Perform a click on this element
		/// </summary>
		/// <param name="eventArguments">
		/// Optional object to pass to the <see cref="IButton.OnClick"/> method
		/// </param>
		public TClickReturn Click(EventArgs<TClickReturn> eventArguments = null)
		{
			eventArguments = eventArguments ?? new EventArgs<TClickReturn>();

			this.WrappedElement.Click(SeleniumHelper.WebDriver);

			OnClick?.Invoke(this, eventArguments);

			return eventArguments.EventReturn;
		}

		/// <summary>
		/// Generator method for instantiating a proper instance of this generic type for the page object system.
		/// </summary>
		/// <param name="dummyWebElement">The dummy web element for the constructor.</param>
		/// <returns>A non-functional instance of this class so that GetObject can be exposed.</returns>
		public static IBuildableElement GetSelf(IWebElement dummyWebElement)
		{
			return new Button<bool>(dummyWebElement);
		}

		/// <summary>
		/// Method for getting a new instance of this type, provided it meets the requirements.
		/// </summary>
		/// <param name="buildsByAttribute">The builds by attribute to construct the element.</param>
		/// <param name="objectType">The parameter is not used.</param>
		/// <returns>Instance of the requested type, otherwise null if it fails the test.</returns>
		public new object GetObject(BuildsByAttribute buildsByAttribute, Type objectType)
		{
			if (!objectType.IsGenericType)
			{
				// This isn't a generic type, don't bother.
				return null;
			}

			var type = typeof(Button<>).MakeGenericType(objectType.GenericTypeArguments.Single());

			object obj = null;
			try
			{
				obj = Activator.CreateInstance(type, new object[] { buildsByAttribute.CssSelector });
			}
			catch (Exception ex)
			{
				if (ex is ArgumentException || ex.InnerException is ArgumentException)
				{
					if (buildsByAttribute.IsRequired)
					{
						throw;
					}
				}
				else
				{
					throw;
				}
			}

			return obj;
		}
	}
}

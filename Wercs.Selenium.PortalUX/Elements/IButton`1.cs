using Selenium.Core.Elements.ConcreteTypes;
using Selenium.Core.Elements.Events;
using System;

namespace Wercs.Selenium.PortalUX.Elements
{
	/// <summary>
	/// Describes a button page element.
	/// </summary>
	/// <typeparam name="TClickReturn">The type returned by the Click operation of this button.</typeparam>
	internal interface IButton<TClickReturn> : IBaseElement
	{
		/// <summary>
		/// Event fired when this button is clicked.
		/// </summary>
		event EventHandler<EventArgs<TClickReturn>> OnClick;

		/// <summary>
		/// Perform a click on this element.
		/// </summary>
		/// <param name="eventArguments">
		/// Optional object to pass to the <see cref="OnClick"/> handler method.
		/// </param>
		TClickReturn Click(EventArgs<TClickReturn> eventArguments = null);
	}
}

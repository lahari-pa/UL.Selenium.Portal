using Selenium.Core.Elements.ConcreteTypes;
using System;

namespace Wercs.Selenium.PortalUX.Elements
{
	/// <summary>
	/// Describes a button page element.
	/// </summary>
	internal interface IButton : IBaseElement
	{
		/// <summary>
		/// Event fired when this button is clicked.
		/// </summary>
		event EventHandler<object> OnClick;

		/// <summary>
		/// Perform a click on this element.
		/// </summary>
		/// <param name="eventArguments">
		/// Optional object to pass to the <see cref="OnClick"/> handler method.
		/// </param>
		void Click(object eventArguments = null);
	}
}

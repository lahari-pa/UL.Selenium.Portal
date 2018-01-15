using System;
using System.ComponentModel.DataAnnotations;

namespace Selenium.Portal.Resources.Types
{
	/// <summary>
	/// An email.
	/// </summary>
	internal class Email
	{
		/// <summary>
		/// Instance of EmailAddressAttribute for validation use.
		/// </summary>
		/// <remarks>
		/// This uses the EmailAddressAttribute found in the ComponentMode.DataAnnotations
		/// assembly. This internally has some madness RegEx to validate email addresses,
		/// so we farm out the actual validation to that rather than duplicate the
		/// same effort here.
		/// http://stackoverflow.com/a/16403290/1309423
		/// </remarks>
		private static readonly EmailAddressAttribute _emailValidator = new EmailAddressAttribute();

		/// <summary>
		/// Initializes a new instance of the <see cref="Email"/> class.
		/// </summary>
		/// <param name="value">
		/// The value.
		/// </param>
		public Email(string value)
		{
			if (!IsValidEmail(value))
			{
				throw new ArgumentException("Supplied email string is not a valid email: " + value + ".");
			}

			this.Value = value;
		}

		/// <summary>
		/// Gets the email value for this object.
		/// </summary>
		public string Value { get; private set; }

		/// <summary>
		/// Get a random and valid email address.
		/// </summary>
		/// <returns>
		/// A valid Email object.
		/// </returns>
		public static Email GetRandomValidEmail()
		{
			// <name>@<domain>.com
			var name = ResourceFactoryExtensionMethods.GetRandomString(null, "email", 15);
			var domain = ResourceFactoryExtensionMethods.GetRandomString(null, "domain", 15);
			return new Email(name + "@" + domain + ".com");
		}

		/// <summary>
		/// Determine if an email is valid.
		/// </summary>
		/// <param name="email">
		/// Email string to validate.
		/// </param>
		/// <returns>
		/// True if the email is valid, otherwise false.
		/// </returns>
		public static bool IsValidEmail(string email)
		{
			return _emailValidator.IsValid(email);
		}

		/// <summary>
		/// Returns a string of the Email value.
		/// </summary>
		/// <returns>
		/// An email as a string.
		/// </returns>
		public override string ToString()
		{
			return this.Value;
		}
	}
}
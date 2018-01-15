using System;
using System.Data;

using Selenium.Core.Resources;
using Selenium.Portal.Pages;
using Selenium.Portal.Pages.Account;
using Selenium.Portal.Pages.Home;
using Selenium.Portal.Resources.Types;

namespace Selenium.Portal.Resources
{
	/// <summary>
	/// A user account for Portal.
	/// </summary>
	[DatabaseGeneratable(@"SELECT *
	FROM [WebPortal].[dbo].[T_USER]
	WHERE F_NAME LIKE 'Selenium%'")]
	internal class User : ResourceBase<User>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="User"/> class.
		/// </summary>
		/// <param name="email">
		/// The email.
		/// </param>
		/// <param name="password">
		/// The password.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="phone">
		/// The phone.
		/// </param>
		/// <param name="verificationCode">
		/// The verification Code.
		/// </param>
		/// <param name="userGroup">
		/// The user Group.
		/// </param>
		/// <param name="isActive">
		/// The is Active.
		/// </param>
		/// <param name="freeResourceMethod">
		/// The method to call when disposing of this resource.
		/// </param>
		public User(
			string email = null,
			string password = "",
			string name = "",
			string phone = "",
			int verificationCode = 0,
			string userGroup = "",
			bool isActive = true,
			Action<User> freeResourceMethod = null)
		{
			this.Email = new Email(email);
			this.Password = password;
			this.Name = name;
			this.Phone = phone;
			this.VerificationCode = verificationCode;
			this.UserGroup = userGroup;
			this.IsActive = isActive;
			this.FreeResourceMethod = freeResourceMethod;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="User"/> class.
		/// </summary>
		/// <param name="email">
		/// The email.
		/// </param>
		/// <param name="password">
		/// The password.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="phone">
		/// The phone.
		/// </param>
		/// <param name="verificationCode">
		/// The verification Code.
		/// </param>
		/// <param name="userGroup">
		/// The user Group.
		/// </param>
		/// <param name="isActive">
		/// The is Active.
		/// </param>
		/// <param name="freeResourceMethod">
		/// The method to call when disposing of this resource.
		/// </param>
		public User(
			Email email = null,
			string password = "",
			string name = "",
			string phone = "",
			int verificationCode = 0,
			string userGroup = "",
			bool isActive = true,
			Action<User> freeResourceMethod = null)
		{
			this.Email = email;
			this.Password = password;
			this.Name = name;
			this.Phone = phone;
			this.VerificationCode = verificationCode;
			this.UserGroup = userGroup;
			this.IsActive = isActive;
			this.FreeResourceMethod = freeResourceMethod;
		}

		/// <summary>
		/// Gets the user's phone.
		/// </summary>
		[DatabaseColumn("F_PHONE", DbType.String)]
		public string Phone { get; private set; }

		/// <summary>
		/// Gets the user's password.
		/// </summary>
		[DatabaseColumn("F_PASSWORD", DbType.String)]
		public string Password { get; private set; }

		/// <summary>
		/// Gets the user's name.
		/// </summary>
		[DatabaseColumn("F_NAME", DbType.String)]
		public string Name { get; private set; }

		/// <summary>
		/// Gets the user's email.
		/// </summary>
		[DatabaseColumn("F_EMAIL", DbType.String)]
		public Email Email { get; private set; }

		/// <summary>
		/// Gets the user's verification code.
		/// </summary>
		[DatabaseColumn("F_VERIFICATION_CODE", DbType.Int32)]
		public int VerificationCode { get; private set; }

		/// <summary>
		/// Gets the user's group.
		/// </summary>
		[DatabaseColumn("F_User_Group", DbType.String)]
		public string UserGroup { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the user is active.
		/// </summary>
		[DatabaseColumn("F_ACTIVE", DbType.Boolean)]
		public bool IsActive { get; private set; }

		/// <summary>
		/// Log this user into wercsmart portal using popup
		/// </summary>
		/// <returns>
		///Wercspace page object
		/// </returns>
		public WercspacePage Login()
		{
			var loginPage = GoTo.Page<IndexPage>(IndexPage.GetUrl());
			var loginPopup = loginPage.SignInButton.Click();
			return (WercspacePage)loginPopup.Login(this);
		}

		/// <summary>
		/// Compare if two User objects are equivalent
		/// </summary>
		/// <param name="obj">
		/// Object to compare to
		/// </param>
		/// <returns>
		/// True if users are identical
		/// </returns>
		public override bool Equals(object obj)
		{
			var user = obj as User;
			return user != null && user.Email == this.Email && user.Password == this.Password;
		}

		/// <summary>
		/// Return the hash code for this user
		/// </summary>
		/// <returns>Hash code for this user</returns>
		public override int GetHashCode()
		{
			// Prevent int overflow issues, wrapping is fine for hashes
			unchecked
			{
				// Start with a large prime number
				var hash = 486187739;

				// Throw some random and the first appropriate value
				hash = (hash * 23) + this.Email.GetHashCode();

				// More shuffling and unique data
				hash = (hash * 23) + this.Password.GetHashCode();
				return hash;
			}
		}
	}
}
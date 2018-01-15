using System;
using Mailosaur;
using Selenium.Core.Resources;
using Selenium.Portal.Resources.Types;
using Wercs.Selenium.PortalUX.Classes;

namespace Selenium.Portal.Resources
{
	/// <summary>
	/// Constructors for User resource methods.
	/// </summary>
	internal static class UserFactory
	{
		/// <summary>
		/// Get a preexisting user from the database.
		/// </summary>
		/// <param name="factory">
		/// The Resource Factory.
		/// </param>
		/// <param name="whereFunc">
		/// A method to describe the requirements for the user account.
		/// </param>
		/// <returns>
		/// A user account already present in the database, and that meets the <paramref name="whereFunc"/>
		/// requirements, if present.
		/// </returns>
		public static User GetUser(this IResourceFactory factory, Func<User, bool> whereFunc = null)
		{
			var user = UserPool.POOL.GetResource(whereFunc);
			factory.References.Add(user);
			return user;
		}

		/// <summary>
		/// Get a new randomly named user account.
		/// </summary>
		/// <param name="factory">
		/// The factory.
		/// </param>
		/// <param name="whereFunc">
		/// The where func.
		/// </param>
		/// <returns>
		/// The <see cref="User"/>.
		/// </returns>
		public static User GetNewUser(this IResourceFactory factory, Func<User, bool> whereFunc = null)
		{
			var user = new User(email: new Email(factory.GetRandomString() + "@thewercs.com"), password: factory.GetRandomCapsString());
			factory.LogEphemeralNotice(user);
			return user;
		}
	}
}
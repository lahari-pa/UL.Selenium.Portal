using System;
using System.Collections.Generic;

namespace UL.Selenium.Portal.WERCSmart.Classes
{
	public class User : IEquatable<User>
	{
		// ASSIGNED PARAMETERS
		public string Identifier { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		// SIGN UP FORM QUESTIONS
		public string Country { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string CompanyName { get; set; }
		public string CompanyPhone { get; set; }
		public string CountryCode { get; set; }
		public string EmergencyPhoneNumber { get; set; }
		public string SupplierType { get; set; }

		// SECURITY QUESTIONS
		public string CityQuestion { get; set; }
		public string CityHint { get; set; }
		public string CarQuestion { get; set; }
		public string CarHint { get; set; }
		public string FriendQuestion { get; set; }
		public string FriendHint { get; set; }
		public string JobQuestion { get; set; }
		public string JobHint { get; set; }
		public string MascotQuestion { get; set; }
		public string MascotHint { get; set; }
		public string Pin { get; set; }

		//User details
		public string Username { get; set; }
		public string Title { get; set; }
		public string Role { get; set; }
		public string PhoneNumber { get; set; }
		public bool IsActive { get; set; }
		public bool ChemicalAssessment { get; set; }
		public bool ProductSubmission { get; set; }
		public bool Purview { get; set; }
		public bool SendNotifications { get; set; }

		public User()
		{
			this.Email = System.Guid.NewGuid().ToString();
		}

		public User(string sEmail)
		{
			this.Email = sEmail;
		}

		public override bool Equals(object obj)
		{
			var other = obj as User;
			if (obj == null || this.GetType() != obj.GetType())
			{
				return false;
			}
			var p = (User)obj;
			return (this.Email == p.Email);
		}

		public override int GetHashCode()
		{
			return this.Email.GetHashCode();
		}

		public bool Equals(User other)
		{
			if (other == null || this.GetType() != other.GetType())
			{
				return false;
			}
			return (this.Email == other.Email);
		}
	}

	// Custom comparer for the User class
	class UserComparer : IEqualityComparer<User>
	{
		// Products are equal if their names and product numbers are equal.
		public bool Equals(User x, User y)
		{

			//Check whether the compared objects reference the same data.
			if (Object.ReferenceEquals(x, y))
			{
				return true;
			}


			//Check whether any of the compared objects is null.
			if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
			{
				return false;
			}


			//Check whether the products' properties are equal.
			return x.Email == y.Email;
		}

		// If Equals() returns true for a pair of objects
		// then GetHashCode() must return the same value for these objects.

		public int GetHashCode(User user)
		{
			//Check whether the object is null
			if (ReferenceEquals(user, null))
			{
				return 0;
			}


			//Get hash code for the Email field if it is not null.
			int hashProductEmail = user.Email == null ? 0 : user.Email.GetHashCode();

			//Get hash code for the Code field.
			int hashProductPassword = user.Password.GetHashCode();

			//Calculate the hash code for the product.
			return hashProductEmail ^ hashProductPassword;
		}

	}

	public static class UserExtensions
	{
		public static IEnumerable<User> Except(List<User> listFirst, List<User> listSecond)
		{
			foreach (User thisUser in listFirst)
			{
				bool found = false;
				foreach (User otherUser in listSecond)
				{
					if (thisUser.Email == otherUser.Email)
					{
						found = true;
					}
				}

				if (!found)
				{
					yield return thisUser;
				}
			}
		}
	}
}

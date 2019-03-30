using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wercs.Selenium.PortalUX.Classes
{
	public class WERCSmartUser
	{
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
		public string PhoneQuestion { get; set; }
		public string PhoneHint { get; set; }
		public string MentorQuestion { get; set; }
		public string MentorHint { get; set; }
		public string FriendQuestion { get; set; }
		public string FriendHint { get; set; }
		public string AnimalQuestion { get; set; }
		public string AnimalHint { get; set; }
		public string CollegeQuestion { get; set; }
		public string CollegeHint { get; set; }
		public string Pin { get; set; }

		// old security Qs
		//public string CityQuestion { get; set; }
		//public string CityHint { get; set; }
		//public string CarQuestion { get; set; }
		//public string CarHint { get; set; }
		//public string FriendQuestion { get; set; }
		//public string FriendHint { get; set; }
		//public string JobQuestion { get; set; }
		//public string JobHint { get; set; }
		//public string MascotQuestion { get; set; }
		//public string MascotHint { get; set; }
		//public string Pin { get; set; }
	}
}

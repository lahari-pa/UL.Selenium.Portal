using UL.Automation.WebDriver.Classes;
using System;
using TechTalk.SpecFlow;
using UL.Automation.Utilities;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	internal class TestCreatingSupplierAccount
	{
		Table _supplierData;

		public TestCreatingSupplierAccount(string emailSpecialChar)
		{
			this._supplierData = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			this._supplierData.AddRow(MailosaurFunctions.CreateEmail("asdf" + emailSpecialChar + "qwerty"), "UNITED STATES", "WERCS", "Test_Automation", "Welcome1!", "1425 Kingsway", "Address2", "Latham", "New York", "12308", "QA_Automation_Account", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
		}

		internal bool TryCreateSupplier()
		{

			return false;
		}
	}
}

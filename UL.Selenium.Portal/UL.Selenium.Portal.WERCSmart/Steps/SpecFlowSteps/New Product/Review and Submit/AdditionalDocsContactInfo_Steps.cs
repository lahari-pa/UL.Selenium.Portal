using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "AdditionalDocsContactInfo")]
	public class AdditionalDocsContactInfo_Steps
	{

		[StepDefinition(@"In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: (.*)")]
		public void EnterTextForManfacturerName(string text)
		{
			string section = "Manufacturer Name";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Additional Documents -> Contact Information section, for section: 'Address' enter text: (.*)")]
		public void EnterTextForAddress(string text)
		{
			string section = "Address";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: (.*)")]
		public void EnterTextForPhone(string text)
		{
			string section = "Phone";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: (.*)")]
		public void EnterTextForEmergencyPhone(string text)
		{
			string section = "Emergency Phone";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' set the option in the section: 'Sub Format type' to : (Mexico GHS SDS|OSHA GHS SDS|Brazil GHS SDS|China GHS SDS|" +
		"Vietnam  GHS SDS|Eco Logo|European GHS SDS|Canada GHS SDS|Indonesia  GHS SDS|Japan GHS SDS|Korea GHS SDS|North American Combined GHS SDS|Product Development Regulatory Report|Singapore GHS SDS|TCLP Calculation|Transportation Classification|"+
		"Thailand GHS SDS|Taiwan GHS SDS|Australia GHS SDS|Assessment Summary Report|VOC Restriction|Malaysia GHS SDS)")]
		public void EnterTextForSubFormatType(string option)
		{
			
			new AdditionalDocsContactInfo().SelectSubFormatType(option);
		}

		[StepDefinition(@"In the Additional Documents  Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for the first 'Address': (.*)")]
		public void EnterTextForSubSectionAddress1(string text)
		{
			new AdditionalDocsContactInfo().EnterTextAddress1(text);
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for the second 'Address': (.*)")]
		public void EnterTextForSubSectionAddress2(string text)
		{
			new AdditionalDocsContactInfo().EnterTextAddress2(text);
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for 'Phone' : (.*)")]
		public void EnterTextForSubSectionPhone(string text)
		{
			new AdditionalDocsContactInfo().EnterTextPhone(text);
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for 'Emergency Phone' : (.*)")]
		public void EnterTextForSubSectionEmergencyPhone(string text)
		{
			new AdditionalDocsContactInfo().EnterTextEmergencyPhone(text);
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for 'Email' : (.*)")]
		public void EnterTextForSubSectionEmail(string text)
		{
			new AdditionalDocsContactInfo().EnterTextEmail(text);
		}


		[StepDefinition(@"In the Additional Documents -> Contact Information section, in the sub section: 'Please provide contact information required to display on SDS(s) per region.' click the 'Remove' button")]
		public void ClickRemoveButton()
		{
			new AdditionalDocsContactInfo().ClickRemoveButton();
		}

		[StepDefinition(@"In the Additional Documents -> Contact Information section, in the sub section: 'Please provide contact information required to display on SDS(s) per region.' click the 'Add Row' button")]
		public void ClickAddRowButton()
		{
			new AdditionalDocsContactInfo().ClickAddRowButton();
		}


		[StepDefinition(@"In the Additional Documents -> Contact Information section, in the sub section: 'Please go to My Account to manage your SDS emergency contact information for this document format.' click the 'My Account' link")]
		public void ClicMyAccountLink()

		{
			string linkText = "My Account";
			new Steps_Prototype().ClickLinkElement(linkText);
		}

	}
}

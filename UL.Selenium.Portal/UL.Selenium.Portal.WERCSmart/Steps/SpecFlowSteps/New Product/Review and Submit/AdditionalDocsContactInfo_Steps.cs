using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
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
			if(new AdditionalDocsContactInfo().SubFormatTypeDropDownExists())
			{
				Report.Info($"The Sub Format Type dropdown exists! Checking if the option: {option} exists in the drop down!");

				if (new AdditionalDocsContactInfo().SubFormatTypeOptionExists(option))
				{
					Report.Info($"Selecting the option: {option} in the drop down!");
					new AdditionalDocsContactInfo().SelectSubFormatType(option);
				}
			}
			Report.Info("The Sub Format Type dropdown does not exist");
			return;

		}

		[StepDefinition(@"In the Additional Documents  Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for the first 'Address': (.*)")]
		public void EnterTextForSubSectionAddress1(string text)
		{
			if(new AdditionalDocsContactInfo().Address1Exsits())
			{
				new AdditionalDocsContactInfo().EnterTextAddress1(text);
			}
			Report.Info("The First Address textbox does not exist");
			return;
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for the second 'Address': (.*)")]
		public void EnterTextForSubSectionAddress2(string text)
		{
			if (new AdditionalDocsContactInfo().Address2Exsits())
			{
				new AdditionalDocsContactInfo().EnterTextAddress2(text);
			}
			Report.Info("The second Address textbox does not exist");
			return;
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for 'Phone' : (.*)")]
		public void EnterTextForSubSectionPhone(string text)
		{
			if (new AdditionalDocsContactInfo().PhoneExsits())
			{
				new AdditionalDocsContactInfo().EnterTextPhone(text);
			}
			Report.Info("The Phone textbox does not exist");
			return;
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for 'Emergency Phone' : (.*)")]
		public void EnterTextForSubSectionEmergencyPhone(string text)
		{
			if (new AdditionalDocsContactInfo().EmergencyPhoneExsits())
			{
				new AdditionalDocsContactInfo().EnterTextEmergencyPhone(text);
			}
			Report.Info("The Emergency Phone textbox does not exist");
			return;
		}

		[StepDefinition(@"In the Additional Documents Contact Information section, in the sub section: 'Please provide contact information required to display on SDS\(s\) per region.' enter text for 'Email' : (.*)")]
		public void EnterTextForSubSectionEmail(string text)
		{
			if (new AdditionalDocsContactInfo().EmailExsits())
			{
				new AdditionalDocsContactInfo().EnterTextEmail(text);
			}
			Report.Info("The email textbox does not exist");
			return; 
		}


		[StepDefinition(@"In the Additional Documents -> Contact Information section, in the sub section: 'Please provide contact information required to display on SDS(s) per region.' click the 'Remove' button")]
		public void ClickRemoveButton()
		{
			if (new AdditionalDocsContactInfo().RemoveButtonExsits())
			{
				new AdditionalDocsContactInfo().ClickRemoveButton();
			}
			Report.Info("The Remove button does not exist");
			return;
		}

		[StepDefinition(@"In the Additional Documents -> Contact Information section, in the sub section: 'Please provide contact information required to display on SDS(s) per region.' click the 'Add Row' button")]
		public void ClickAddRowButton()
		{
			if (new AdditionalDocsContactInfo().AddRowButtonExsits())
			{
				new AdditionalDocsContactInfo().ClickAddRowButton();
			}
			Report.Info("The Add Row button does not exist");
			return;
		}


		[StepDefinition(@"In the Additional Documents -> Contact Information section, in the sub section: 'Please go to My Account to manage your SDS emergency contact information for this document format.' click the 'My Account' link")]
		public void ClickMyAccountLink()

		{
			string linkText = "My Account";
			new Steps_Prototype().ClickLinkElement(linkText);
		}

	}
}

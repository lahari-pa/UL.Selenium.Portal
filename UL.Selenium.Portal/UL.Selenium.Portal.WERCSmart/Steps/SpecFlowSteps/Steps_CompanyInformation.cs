using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:MyAccount:CompanyInformation")]

	 class Steps_CompanyInformation
	{
		[RegexStepDefinition(@"In the Company Information section, click the 'Edit' link for the (Billing Address|Shipping Address|Canada Supplier Address|Stewardship Numbers) section")]
		public void ClickTheEditLink(string section)
		{
			string linkText = "Edit";
			if (Report.IsTrue(new CompanyInformation().LinkElementExists(section, linkText), $"Failed to find the 'Edit' link for the '{section}' section", $"Successfully found the 'Edit' link for the '{section}' section"))
			{
				Report.IsTrue(new CompanyInformation().ClickLinkElement(section, linkText), $"Failed to click the 'Edit' link for the '{section}' section", $"Successfully clicked the 'Edit' link for the '{section}' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the 'Edit' link for the 'Company' section")]
		public void ClickTheCompanyEditLink()
		{
			string linkText = "Edit";
			if (Report.IsTrue(new CompanyInformation().CompanyEditLinkExists(linkText), $"Failed to find the 'Edit' link for the 'Company' section", $"Successfully found the 'Edit' link for the 'Company' section"))
			{
				Report.IsTrue(new CompanyInformation().CompanyClickEditLink(linkText), $"Failed to click the 'Edit' link for the 'Company' section", $"Successfully clicked the 'Edit' link for the 'Company' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the (Save|Cancel) button for the (Billing Address|Shipping Address|Canada Supplier Address|Stewardship Numbers) section")]
		public void ClickTheSaveCancelButton(string button, string section)
		{
			if (Report.IsTrue(new CompanyInformation().LinkElementExists(section, button), $"Failed to find the '{button}' button for the '{section}' section", $"Successfully found the '{button}' button for the '{section}' section"))
			{
				Report.IsTrue(new CompanyInformation().ClickLinkElement(section, button), $"Failed to click the '{button}' button for the '{section}' section", $"Successfully clicked the '{button}' button for the '{section}' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the (Save|Cancel) button for the 'Company' section")]
		public void ClickTheCompanySaveCancelButton(string button)
		{
			if (Report.IsTrue(new CompanyInformation().CompanyEditLinkExists(button), $"Failed to find the '{button}' button for the 'Company' section", $"Successfully found the '{button}' button for the 'Company' section"))
			{
				Report.IsTrue(new CompanyInformation().CompanyClickEditLink(button), $"Failed to click the '{button}' button for the 'Company' section", $"Successfully clicked the '{button}' button for the 'Company' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, the 'Are you sure you wish to cancel\?' modal window (should|should not) be displayed with text 'If you cancel, any changes will be lost. Continue\?'")]
		public void TheUserDetailsModalIsDisplayed(string condition)
		{
			string modalTitle = "×\r\nAre you sure you wish to cancel?";
			string text = "If you cancel, any changes will be lost. Continue?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, modalTitle, text);
		}
		[RegexStepDefinition(@"In the Company Information section, in the 'Are you sure you wish to cancel\?' modal click the button (Yes|No)")]
		public void TheInUserDetailsModalClickButton(string button)
		{
			string modalTitle = "Are you sure you wish to cancel?";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(modalTitle, button);
		}
	}
}

	

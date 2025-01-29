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
			if (Report.IsTrue(new CompanyInformation().EditLinkExists(section), $"Failed to find the 'Edit' link for the '{section}' section", $"Successfully found the 'Edit' link for the '{section}' section"))
			{
				Report.IsTrue(new CompanyInformation().ClickEditLink(section), $"Failed to click the 'Edit' link for the '{section}' section", $"Successfully clicked the 'Edit' link for the '{section}' section");
			}
		}
		[RegexStepDefinition(@"In the Company Information section, click the 'Edit' link for the 'Company' section")]
		public void ClickTheCompanyEditLink()
		{
			string section = "Company";
			if (Report.IsTrue(new CompanyInformation().CompanyEditLinkExists(section), $"Failed to find the 'Edit' link for the '{section}' section", $"Successfully found the 'Edit' link for the '{section}' section"))
			{
				Report.IsTrue(new CompanyInformation().CompanyClickEditLink(section), $"Failed to click the 'Edit' link for the '{section}' section", $"Successfully clicked the 'Edit' link for the '{section}' section");
			}
		}
	}
}

	

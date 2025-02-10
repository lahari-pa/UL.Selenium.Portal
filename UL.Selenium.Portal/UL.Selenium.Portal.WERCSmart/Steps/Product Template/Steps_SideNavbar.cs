using System;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;
using UL.Automation.WebDriver.Classes;
using TReVor.Core.Classes.Software;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.ProductTemplate;
using TReVor.Core.Classes.Software.Vault;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.Product_Template
{
	[Binding, Scope(Tag = "ProductTemplateSideNavBar")]
	class Steps_SideNavbar

	{
		[RegexStepDefinition(@"In the Side Navigation Bar, click the '(.*)' link")]
		public void InSideNavbarClickLink(string linkTitle)
		{
			SideNavbar sideNavbar = new SideNavbar();
			if(!Report.IsTrue(sideNavbar.NavLinkListExists(), "Failure, Side Navigation Bar does not exist.", "Success, Side Navigation Bar exists."))
			{
				return;
			}
			if (!Report.IsTrue(sideNavbar.NavLinkItemExists(linkTitle), $"Failure, Side Navigation Bar link '{linkTitle}' does not exist.", $"Success, Side Navigation Bar link '{linkTitle}' exists."))
			{
				return;
			}
			Report.IsTrue(sideNavbar.NavLinkItemClick(linkTitle), $"Failure, failed to click '{linkTitle}'.", $"Success, clicked '{linkTitle}'.");
		}
	}
}

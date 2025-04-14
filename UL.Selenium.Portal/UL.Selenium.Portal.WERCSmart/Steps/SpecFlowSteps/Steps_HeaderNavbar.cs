using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Windows.Controls.Ribbon;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "HeaderNavbar")]
	internal class Steps_HeaderNavbar
	{
		[RegexStepDefinition(@"In the Header Navbar, confirm (Alerts|Announcements|Product Account) dropdown button (does|does not) exist")]
		public void HeaderNavbarConfirmDropdownButtonExists(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			HeaderNavbar headerNavbar = new HeaderNavbar();
			if(Report.IsTrue(headerNavbar.HeaderDropdownButtonsListExists(), $"Failure, failed to confirm dropdown button list does exist.", $"Success, confirmed header dropdown button list does exist."))
			{
				Report.IsTrue(expected == headerNavbar.HeaderDropdownButtonWithLabelExists(buttonLabel), $"Failure, failed to confirm dropdown button with '{buttonLabel}' label {does_doesnot} exist.", $"Success, confirmed dropdown button with '{buttonLabel}' label {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Header Navbar, click (Alerts|Announcements|Product Account) dropdown button")]
		public void HeaderNavbarClickDropdownButton(string buttonLabel)
		{
			HeaderNavbar headerNavbar = new HeaderNavbar();
			if (Report.IsTrue(headerNavbar.HeaderDropdownButtonsListExists(), $"Failure, failed to confirm dropdown button list does exist.", $"Success, confirmed header dropdown button list does exist."))
			{
				if(Report.IsTrue(headerNavbar.HeaderDropdownButtonWithLabelExists(buttonLabel), $"Failure, failed to confirm dropdown button with '{buttonLabel}' label exist.", $"Success, confirmed dropdown button with '{buttonLabel}' label exist."))
				{
					Report.IsTrue(headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).Click(), $"Failure, failed to click header dropdown button with '{buttonLabel}' label.", $"Success, clicked header dropdown button with '{buttonLabel}' label.");
				}
			}
		}

		[RegexStepDefinition(@"In the Header Navbar, confirm (Alerts|Announcements|Product Account) dropdown menu (is|is not) expanded")]
		public void HeaderNavbarConfirmDropdownMenuExpanded(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			HeaderNavbar headerNavbar = new HeaderNavbar();
			if (Report.IsTrue(headerNavbar.HeaderDropdownButtonsListExists(), $"Failure, failed to confirm dropdown button list does exist.", $"Success, confirmed header dropdown button list does exist."))
			{
				if (Report.IsTrue(headerNavbar.HeaderDropdownButtonWithLabelExists(buttonLabel), $"Failure, failed to confirm dropdown button with '{buttonLabel}' label exist.", $"Success, confirmed dropdown button with '{buttonLabel}' label exist."))
				{
					Report.IsTrue(expected == headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).Expanded, $"Failure, failed to confirm dropdown button with '{buttonLabel}' label dropdown menu {is_isnot} expanded.", $"Success, confirmed dropdown button with '{buttonLabel}' label dropdown menu {is_isnot} expanded.");
				}
			}
		}

		[RegexStepDefinition(@"In the Header Navbar Product Account dropdown menu, confirm (My Account|Sign Out) option (does|does not) exist")]
		public void HeaderNavbarProductAccountConfirmDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			string buttonLabel = "Product Account";
			HeaderNavbar headerNavbar = new HeaderNavbar();
			if (Report.IsTrue(headerNavbar.HeaderDropdownButtonsListExists(), $"Failure, failed to confirm dropdown button list does exist.", $"Success, confirmed header dropdown button list does exist."))
			{
				if (Report.IsTrue(headerNavbar.HeaderDropdownButtonWithLabelExists(buttonLabel), $"Failure, failed to confirm dropdown button with '{buttonLabel}' label exist.", $"Success, confirmed dropdown button with '{buttonLabel}' label exist."))
				{
					if(Report.IsTrue(headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).Expanded, $"Failure, failed to confirm dropdown button with '{buttonLabel}' label dropdown menu is expanded.", $"Success, confirmed dropdown button with '{buttonLabel}' label dropdown menu is expanded."))
					{
						Report.IsTrue(expected == headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).DropdownOptionLinkWithLabelExists(optionLabel),$"Failure, failed to confirm '{optionLabel}' dropdown option {does_doesnot} exist.", $"Success, confirmed '{optionLabel}' dropdown option {does_doesnot} exist.");
					}
				}
			}
		}

		[RegexStepDefinition(@"In the Header Navbar Product Account dropdown menu, click (My Account|Sign Out) option")]
		public void HeaderNavbarProductAccountClickDropdownOption(string optionLabel)
		{
			string buttonLabel = "Product Account";
			HeaderNavbar headerNavbar = new HeaderNavbar();
			if (Report.IsTrue(headerNavbar.HeaderDropdownButtonsListExists(), $"Failure, failed to confirm dropdown button list does exist.", $"Success, confirmed header dropdown button list does exist."))
			{
				if (Report.IsTrue(headerNavbar.HeaderDropdownButtonWithLabelExists(buttonLabel), $"Failure, failed to confirm dropdown button with '{buttonLabel}' label exist.", $"Success, confirmed dropdown button with '{buttonLabel}' label exist."))
				{
					if (Report.IsTrue(headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).Click(), $"Failure, failed to click dropdown button with '{buttonLabel}' label.", $"Success, clicked dropdown button with '{buttonLabel}' label."))
					{ 
						if (Report.IsTrue(headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).Expanded, $"Failure, failed to confirm dropdown button with '{buttonLabel}' label dropdown menu is expanded.", $"Success, confirmed dropdown button with '{buttonLabel}' label dropdown menu is expanded."))
						{
							if (Report.IsTrue(headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).DropdownOptionLinkWithLabelExists(optionLabel), $"Failure, failed to confirm '{optionLabel}' dropdown option does exist.", $"Success, confirmed '{optionLabel}' dropdown option does exist."))
							{
								Report.IsTrue(headerNavbar.HeaderDropdownButtonByLabel(buttonLabel).DropdownOptionLinkWithLabelClick(optionLabel), $"Failure, failed to click '{optionLabel}' dropdown option.", $"Success, clicked '{optionLabel}' dropdown option.");
							}
						}
					}
				}
			}
		}
	}
}

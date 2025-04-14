using Reqnroll;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "SideMenu")]
	internal class Steps_SideMenu
	{
		#region Hamburger Icon Steps
		[RegexStepDefinition(@"In the Side Menu, confirm Hamburger Icon (does|does not) exist")]
		public void SideMenuConfirmHamburgerIconExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			Report.IsTrue(expected == sideMenu.HamburgerIconExists(), $"Failure, failed to confirm Hamburger Icon {does_doesnot} exist.", $"Success, confirmed Hamburger Icon {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Side Menu, click Hamburger Icon")]
		public void SideMenuClickHamburgerIcon()
		{
			SideMenu sideMenu = new SideMenu();
			if(Report.IsTrue(sideMenu.HamburgerIconExists(), $"Failure, failed to confirm Hamburger Icon does exist.", $"Success, confirmed Hamburger Icon does exist."))
			{
				Report.IsTrue(sideMenu.HamburgerIconClick(), $"Failure, failed to click Hamburger Icon.", $"Success, clicked Hamburger Icon.");
			}
		}

		[RegexStepDefinition(@"In the Side Menu, confirm the Labeled Links List menu (is|is not) expanded")]
		public void SideMenuConfirmMenuExpaneded(string is_isnot)
		{
			bool expected = is_isnot == "is";
			SideMenu sideMenu = new SideMenu();
			Report.IsTrue(expected == sideMenu.SidebarMenuExpanded(), $"Failure, failed to confirm the Labeled Links List menu {is_isnot} expanded.", $"Success, confirmed the Labeled Links menu {is_isnot} expanded.");
		}
		#endregion

		#region Icon Links List Steps
		[RegexStepDefinition(@"In the Side Menu, confirm Icon Links list (does|does not) exist")]
		public void SideMenuConfirmIconLinksListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			Report.IsTrue(expected == sideMenu.IconLinksListExists(), $"Failure, failed to confirm Icon Links list {does_doesnot} exist.", $"Success, confirmed Icon Links list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Side Menu, confirm Icon Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title (does|does not) exist")]
		public void SideMenuConfirmIconLinkWithTitleExists(string titleLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			if(Report.IsTrue(sideMenu.IconLinksListExists(), $"Failure, failed to confirm Icon Links list does exist.", $"Success, confirmed Icon Links list does exist."))
			{
				Report.IsTrue(expected == sideMenu.IconLinkByTitleExists(titleLabel), $"Failure, failed to confirm Icon Link with '{titleLabel}' title {does_doesnot} exist.", $"Success, confirmed Icon Link with '{titleLabel}' title {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Side Menu, click Icon Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title")]
		public void SideMenuClickIconLinkWithTitle(string titleLabel)
		{
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.IconLinksListExists(), $"Failure, failed to confirm Icon Links list does exist.", $"Success, confirmed Icon Links list does exist."))
			{
				if(Report.IsTrue(sideMenu.IconLinkByTitleExists(titleLabel), $"Failure, failed to confirm Icon Link with '{titleLabel}' title does exist.", $"Success, confirmed Icon Link with '{titleLabel}' title does exist."))
				{
					Report.IsTrue(sideMenu.IconLinkByTitle(titleLabel).Click(), $"Failure, failed to click Icon Link with '{titleLabel}' title.", $"Success, clicked Icon Link with '{titleLabel}' title.");
				}
			}
		}

		[RegexStepDefinition(@"In the Side Menu, confirm Icon Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title (does|does not) have counter badge")]
		public void SideMenuConfirmIconLinkWithTitleAlertsExist(string titleLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.IconLinksListExists(), $"Failure, failed to confirm Icon Links list does exist.", $"Success, confirmed Icon Links list does exist."))
			{
				if(Report.IsTrue(sideMenu.IconLinkByTitleExists(titleLabel), $"Failure, failed to confirm Icon Link with '{titleLabel}' title does exist.", $"Success, confirmed Icon Link with '{titleLabel}' title does exist."))
				{
					Report.IsTrue(expected == sideMenu.IconLinkByTitle(titleLabel).CounterBadgeExists(), $"Failure, failed to confirm Icon Link with '{titleLabel}' title {does_doesnot} have counter badge.", $"Success, confirmed Icon Link with '{titleLabel}' title {does_doesnot} have counter badge.");
				}
			}
		}

		[RegexStepDefinition(@"In the Side Menu, confirm Icon Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title counter badge (does|does not) display value (.*)")]
		public void SideMenuConfirmIconLinkWithTitleAlertsDisplaysAlerts(string titleLabel, string does_doesnot, string counterBadgeText)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.IconLinksListExists(), $"Failure, failed to confirm Icon Links list does exist.", $"Success, confirmed Icon Links list does exist."))
			{
				if (Report.IsTrue(sideMenu.IconLinkByTitleExists(titleLabel), $"Failure, failed to confirm Icon Link with '{titleLabel}' title does exist.", $"Success, confirmed Icon Link with '{titleLabel}' title does exist."))
				{
					if(Report.IsTrue(sideMenu.IconLinkByTitle(titleLabel).CounterBadgeExists(), $"Failure, failed to confirm Icon Link with '{titleLabel}' title does have counter badge.", $"Success, confirmed Icon Link with '{titleLabel}' title does have counter badge."))
					{
						Report.IsTrue(expected == sideMenu.IconLinkByTitle(titleLabel).CounterBadgeText().Equals(counterBadgeText, StringComparison.Ordinal), $"Failure, failed to confirm Icon Link with '{titleLabel}' title counter badge {does_doesnot} display value {counterBadgeText}.", $"Success, confirmed Icon Link with '{titleLabel}' title Alerts badge {does_doesnot} display value {counterBadgeText}.");
					}
				}
			}
		}
		#endregion

		#region Labeled Links List Steps
		[RegexStepDefinition(@"In the Side Menu, confirm Labeled Links list (does|does not) exist")]
		public void SideMenuConfirmLabeledLinksListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			Report.IsTrue(expected == sideMenu.LabeledLinksListExists(), $"Failure, failed to confirm Labeled Links list {does_doesnot} exist.", $"Success, confirmed Labeled Links list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Side Menu, confirm Labeled Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title (does|does not) exist")]
		public void SideMenuConfirmLabeledLinkWithTitleExists(string titleLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.LabeledLinksListExists(), $"Failure, failed to confirm Labeled Links list does exist.", $"Success, confirmed Labeled Links list does exist."))
			{
				Report.IsTrue(expected == sideMenu.LabeledLinkByTitleExists(titleLabel), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title {does_doesnot} exist.", $"Success, confirmed Labeled Link with '{titleLabel}' title {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Side Menu, click Labeled Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title")]
		public void SideMenuClickLabeledLinkWithTitle(string titleLabel)
		{
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.LabeledLinksListExists(), $"Failure, failed to confirm Labeled Links list does exist.", $"Success, confirmed Labeled Links list does exist."))
			{
				if (Report.IsTrue(sideMenu.LabeledLinkByTitleExists(titleLabel), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title does exist.", $"Success, confirmed Labeled Link with '{titleLabel}' title does exist."))
				{
					Report.IsTrue(sideMenu.LabeledLinkByTitle(titleLabel).Click(), $"Failure, failed to click Labeled Link with '{titleLabel}' title.", $"Success, clicked Labeled Link with '{titleLabel}' title.");
				}
			}
		}

		[RegexStepDefinition(@"In the Side Menu, confirm Labeled Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title (does|does not) have counter badge")]
		public void SideMenuConfirmLabeledLinkWithTitleAlertsExist(string titleLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.LabeledLinksListExists(), $"Failure, failed to confirm Labeled Links list does exist.", $"Success, confirmed Labeled Links list does exist."))
			{
				if (Report.IsTrue(sideMenu.LabeledLinkByTitleExists(titleLabel), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title does exist.", $"Success, confirmed Labeled Link with '{titleLabel}' title does exist."))
				{
					Report.IsTrue(expected == sideMenu.LabeledLinkByTitle(titleLabel).CounterBadgeExists(), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title {does_doesnot} have counter badge.", $"Success, confirmed Labeled Link with '{titleLabel}' title {does_doesnot} have counter badge.");
				}
			}
		}

		[RegexStepDefinition(@"In the Side Menu, confirm Labeled Link with (My Products|Add Product|Alerts|Retail Partners|Product Suite|My Reports|Shopping Cart|Webinar|Support|Chat) title counter badge (does|does not) display value (.*)")]
		public void SideMenuConfirmLabeledLinkWithTitleAlertsDisplaysAlerts(string titleLabel, string does_doesnot, string counterBadgeText)
		{
			bool expected = does_doesnot == "does";
			SideMenu sideMenu = new SideMenu();
			if (Report.IsTrue(sideMenu.LabeledLinksListExists(), $"Failure, failed to confirm Labeled Links list does exist.", $"Success, confirmed Icon Links list does exist."))
			{
				if (Report.IsTrue(sideMenu.IconLinkByTitleExists(titleLabel), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title does exist.", $"Success, confirmed Labeled Link with '{titleLabel}' title does exist."))
				{
					if (Report.IsTrue(sideMenu.LabeledLinkByTitle(titleLabel).CounterBadgeExists(), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title does have counter badge.", $"Success, confirmed Labeled Link with '{titleLabel}' title does have counter badge."))
					{
						Report.IsTrue(expected == sideMenu.LabeledLinkByTitle(titleLabel).CounterBadgeText().Equals(counterBadgeText, StringComparison.Ordinal), $"Failure, failed to confirm Labeled Link with '{titleLabel}' title counter badge {does_doesnot} display value {counterBadgeText}.", $"Success, confirmed Labeled Link with '{titleLabel}' title counter badge {does_doesnot} display value {counterBadgeText}.");
					}
				}
			}
		}
		#endregion
	}
}

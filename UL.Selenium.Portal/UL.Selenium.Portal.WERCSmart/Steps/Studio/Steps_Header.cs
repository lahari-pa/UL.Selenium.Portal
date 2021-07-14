using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace Authoring.Studio.Selenium.Steps
{
	[Binding, Scope(Tag = "Studio_Header")]
	public class Steps_Header
	{
		[StepDefinition(@"I click to open the '(.*)' menu and select '(.*)'")]
		public void WhenIClickToOpenTheMenuAndSelect(string menu, string subItem)
		{
			GeneralUtilities.SwitchToDefaultContent();
			var topHeader = new StudioTopHeader();
			Report.IsTrue(topHeader.ClickMenu(menu), $"Failed to open the {menu} menu.", $"Successfully clicked to open the {menu} menu");
			Report.IsTrue(topHeader.ClickSubMenu(menu, subItem), $"Failed to click the {subItem} button.", $"Successfully clicked the {subItem} button");
		}

		[StepDefinition(@"I click to open the '(.*)' menu, and under '(.*)' and select '(.*)'")]
		public void WhenIClickToOpenTheMenuAndUnderAndSelect(string Menu, string subMenu, string SubItem)
		{
			GeneralUtilities.SwitchToDefaultContent();
			var topHeader = new StudioTopHeader();
			Report.IsTrue(topHeader.ClickMenu(Menu), $"Failed to open the {Menu} menu.", $"Successfully clicked to open the {Menu} menu");
			Report.IsTrue(topHeader.ClickTriMenuItem(Menu, subMenu, SubItem), $"Failed to click the {SubItem} button under {subMenu}.", $"Successfully clicked the {SubItem} button under {subMenu}.");
		}

		[StepDefinition(@"I click to open the '(.*)' menu, and under the '(.*)' sub-menu, '(.*)' (should|should not) be available")]
		public void WhenIClickToOpenTheMenuAndUnderTheSub_MenuShouldNotBeAvailable(string menu, string subMenu, string item, string shouldOrShouldNot)
		{
			GeneralUtilities.SwitchToDefaultContent();
			var topHeader = new StudioTopHeader();
			Report.IsTrue(topHeader.ClickMenu(menu), $"Failed to open the {menu} menu.", $"Successfully clicked to open the {menu} menu");
			if (string.Equals(shouldOrShouldNot, "should", StringComparison.OrdinalIgnoreCase))
			{
				Report.IsTrue(topHeader.ContainsTriMenuItem(menu, subMenu, item), $"Failed, there was no item called {item} in the menu", $"Success, there was an item called {item} in the menu.");
			}
			else
			{
				Report.IsFalse(topHeader.ContainsTriMenuItem(menu, subMenu, item), $"Failed,  there was an item called {item} in the menu.", $"Success, there was no item called {item} in the menu.");
			}
		}

		[StepDefinition(@"I click to open the '(.*)' menu, '(.*)' (should|should not) be available")]
		public void WhenIClickToOpenTheMenuShouldNotBeAvailable(string menu, string subMenu, string shouldOrShouldNot)
		{
			GeneralUtilities.SwitchToDefaultContent();
			var topHeader = new StudioTopHeader();
			Report.IsTrue(topHeader.ClickMenu(menu), $"Failed to open the {menu} menu.", $"Successfully clicked to open the {menu} menu");
			if (string.Equals(shouldOrShouldNot, "should", StringComparison.OrdinalIgnoreCase))
			{
				Report.IsTrue(topHeader.ContainsMenuItem(menu, subMenu), $"Failed, there was no item called {subMenu} in the menu", $"Success, there was an item called {subMenu} in the menu.");
			}
			else
			{
				Report.IsFalse(topHeader.ContainsMenuItem(menu, subMenu), $"Failed,  there was an item called {subMenu} in the menu.", $"Success, there was no item called {subMenu} in the menu.");
			}
		}
	}
}

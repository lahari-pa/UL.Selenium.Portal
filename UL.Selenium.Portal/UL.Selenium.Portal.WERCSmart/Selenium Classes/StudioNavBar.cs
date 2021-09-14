using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioNavBar : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='navBar']");

		private string _tabName;

		private List<IWebElement> TabsList => this.ContainerElement.FindElements(By.XPath("./div"), 10).ToList();
		private IWebElement Tab => this.ContainerElement.FindElement(By.XPath($".//div[contains(text(),'{_tabName}')]"), 10);
		internal bool ClickSwitchTabs(string tabName)
		{
			_tabName = tabName;
			if (this.Tab == null)
			{
				Report.Error($"Could not find a tab with the text {_tabName}.");
				return false;
			}
			return this.Tab.TryClick();
		}

		public bool GetTabNum(string tabName, out int index)
		{
			index = 1;
			Report.Info("Waiting for the page to load");
			int count = 0;
			while (this.TabsList.Count() < 1 && count < 30)
			{
				Delay.Seconds(1);
				count++;
			}
			foreach (var tab in this.TabsList)
			{
				if (tab.Text.Contains(tabName))
				{
					return true;
				}
				else
				{
					index++;
				}
			}
			return false;
		}
	}
}

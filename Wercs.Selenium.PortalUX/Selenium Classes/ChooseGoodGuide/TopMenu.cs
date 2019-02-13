using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Wercs.Selenium.PortalUX.Selenium_Classes.ChooseGoodGuide
{
	class TopMenu : BaseObject
	{
		public const string BasePath = "//header[@class='topnavbar-wrapper']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
		public bool ClickDropDownNextToSelectBox(string selectBoxText)
		{
			return containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']/following-sibling::button")).TryClick();
		}

		public bool ClickSelectBox(string selectBoxText)
		{
			for (int i = 0; i < 60; i++)
			{
				try
				{
					var select = containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']"));
					if (select != null)
					{
						return select.TryClick();
					}
				}
				catch (Exception e)
				{
				}
			}

			return false;

		}

		public bool ClickItemFromSelectBox(string selectBoxText, string itemToSelect)
		{
			try
			{
				if (ClickDropDownNextToSelectBox(selectBoxText))
				{
					Delay.Seconds(1);
					var dropDownMenu = containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']")).FirstOrDefault(x => x.Displayed);
					return dropDownMenu.FindElement(By.XPath(".//li/a/span[text()='" + itemToSelect + "']")).TryClick();

				}
			}
			catch (Exception e)
			{
				return false;
			}

			return false;

		}
	}
}

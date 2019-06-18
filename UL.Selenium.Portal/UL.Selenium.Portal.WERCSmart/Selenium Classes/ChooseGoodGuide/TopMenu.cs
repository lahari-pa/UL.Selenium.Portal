using System;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class TopMenu : BaseObject
	{
		public const string BasePath = "//header[@class='topnavbar-wrapper']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
		public bool ClickDropDownNextToSelectBox(string selectBoxText)
		{
			return this.containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']/following-sibling::button")).TryClick();
		}

		public bool ClickSelectBox(string selectBoxText)
		{
			for (int i = 0; i < 60; i++)
			{
				try
				{
					var select = this.containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']"));
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
				if (this.ClickDropDownNextToSelectBox(selectBoxText))
				{
					Delay.Seconds(1);
					var dropDownMenu = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']")).FirstOrDefault(x => x.Displayed);
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

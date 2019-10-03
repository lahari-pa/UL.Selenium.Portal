using System;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class TopMenu : SeleniumBaseObject
	{
		public const string BasePath = "//header[@class='topnavbar-wrapper']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

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
					IWebElement select = this.containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']"));
					if (select != null)
					{
						return select.TryClick();
					}
				}
				catch (Exception)
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
					IWebElement dropDownMenu = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']")).FirstOrDefault(x => x.Displayed);
					return dropDownMenu.FindElement(By.XPath(".//li/a/span[text()='" + itemToSelect + "']")).TryClick();

				}
			}
			catch (Exception)
			{
				return false;
			}

			return false;

		}
	}
}

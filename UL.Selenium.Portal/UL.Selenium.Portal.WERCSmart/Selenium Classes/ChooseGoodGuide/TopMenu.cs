using OpenQA.Selenium;
using System;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class TopMenu : SeleniumBaseObject
	{
		public const string BasePath = "//header[@class='topnavbar-wrapper']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickDropDownNextToSelectBox(string selectBoxText)
		{
			return this.containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']/following-sibling::button"), 2).TryClick();
		}

		public bool ClickSelectBox(string selectBoxText)
		{
			for (int i = 0; i < 60; i++)
			{
				try
				{
					IWebElement select = this.containerElement.FindElement(By.XPath(".//a[text() = '" + selectBoxText + "']"), 2);

					if (select == null)
					{
						return false;
					}

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
					IWebElement dropDownMenu = this.containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']"), 2).FirstOrDefault(x => x.Displayed);
					return dropDownMenu.FindElement(By.XPath(".//li/a/span[text()='" + itemToSelect + "']"), 2).TryClick();

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

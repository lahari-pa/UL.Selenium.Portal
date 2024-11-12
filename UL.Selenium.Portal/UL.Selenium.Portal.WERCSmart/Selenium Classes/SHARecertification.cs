using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SHARecertification : SeleniumBaseObject
	{
		public const string BasePath = "//span[@id='ui-dialog-title-dialog-recertification']/../..";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement popupEditor = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;

		}

		//Continue Cancel
		public bool ClickButton(string button)
		{
			System.Collections.Generic.IList<IWebElement> varButtons = this.containerElement.FindElements(By.XPath(".//button/span"), 2);
			IWebElement matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		public bool SelectRegulatorySpecialist(string name)
		{
			IWebElement regulatorySpecialist = this.containerElement.FindElement(By.XPath(".//select[@id='regUsers']"), 2);
			if (regulatorySpecialist == null)
			{
				Report.Info("Could not find regulatory specialist select");
				return false;
			}

			regulatorySpecialist.Select(name);
			return regulatorySpecialist.SelectedOption() == name;
		}

		public bool SetAutoAssign(bool set)
		{
			IWebElement autoAssign = this.containerElement.FindElement(By.XPath(".//input[@id='chkAutoAssignUserRecert']"), 2);
			if (autoAssign == null)
			{
				Report.Info("Could not find auto assign checkbox");
				return false;
			}

			if (autoAssign.Checked() == set)
			{
				Report.Info("Already set correctly");
				return true;
			}

			return autoAssign.TryCheck(set);
		}

	}
}

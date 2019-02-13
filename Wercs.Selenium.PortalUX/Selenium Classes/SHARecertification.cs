using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class SHARecertification : BaseObject
	{
		public const string BasePath = "//span[@id='ui-dialog-title-dialog-recertification']/../..";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var popupEditor = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
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
			var varButtons = containerElement.FindElements(By.XPath(".//button/span"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		public bool SelectRegulatorySpecialist(string name)
		{
			var regulatorySpecialist = containerElement.FindElement(By.XPath(".//select[@id='regUsers']"), 2);
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
			var autoAssign = containerElement.FindElement(By.XPath(".//input[@id='chkAutoAssignUserRecert']"), 2);
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

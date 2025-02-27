using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;



namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class Alerts : SeleniumBaseObject
	{
		public string alertName;

		protected override By ContainerElementLocator => By.XPath(".//div[@class='col-md-4 col-sm-6 message-panel']");
		private List<IWebElement> GetAlerts => this.ContainerElement.FindElements(By.XPath(".//tr"), 2).ToList();

		public Alerts(string alertName)
		{
			this.alertName = alertName;
		}

		public bool AlertsButtonIsDisplayed(string button, string alertName)
		{

			foreach (var element in this.GetAlerts)
			{
				IWebElement AlertName = element.FindElement(By.XPath(".//p"), 2);
				if (AlertName == null)
				{
					Report.Info("Failed to get alert's name");
					return false;
				}
				string getAlertName = AlertName.Text;
				if (alertName == getAlertName)
				{
					IWebElement Button = element.FindElement(By.XPath($".//a[starts-with(text(),{button})]"));
					if (Button == null)
					{
						return false;
					}
					return Button.Displayed;
				}
			}
			Report.Info($"Failed to find alert {alertName}");
			return false;

		}
	}
}

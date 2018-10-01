using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class DataSummary : BaseObject
	{
		public const string BasePath = "//div[@id='dataentry']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WaitForSpinner()
		{
			var spinner = containerElement.FindElement(By.XPath(".//i[contains(@class,'fa-spinner')]"), 2);
			if (spinner == null)
			{
				return true;
			}

			while (spinner != null && spinner.Displayed)
			{
				spinner = containerElement.FindElement(By.XPath(".//i[contains(@class,'fa-spinner')]"), 2);
				Delay.Seconds(Delay.SpeedFactor * 1);
			}

			return true;
		}

		public List<Battery> GetDisplayedBatteries()
		{
			WaitForSpinner();
			var retList = new List<Battery>();
			var tableElement = containerElement.FindElement(By.XPath(".//h2[@class='summary-question' and contains(text(),'battery')]//following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}

			var rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (var row in rows)
			{
				var batteryType = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				var batteryManufacturer = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				var batteryCellsInPackage = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				var batteryCellsRequired = row.FindElement(By.XPath(".//td[4]"), 2).GetValue();
				retList.Add(new Battery() { BatteryType = batteryType, Manufacturer = batteryManufacturer, NumberPerPackage = Convert.ToInt32(batteryCellsInPackage), RequiredToRun = Convert.ToInt32(batteryCellsRequired) });
			}

			return retList;

		}

		/// <summary>
		/// Get Private label option 
		/// </summary>
		/// <returns></returns>
		public string GetPrivateLabelStatement()
		{
			WaitForSpinner();
			return this.containerElement.FindElement(By.XPath(".//h3[@class='summary-question' and contains(text(),'Private Label')]/../p[1]"), 2).Text;
		}

		/// <summary>
		/// Get Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		/// </summary>
		public string GetAlternativeControlPlanQuestion()
		{
			WaitForSpinner();
			return this.containerElement.FindElement(By.XPath(".//h3[@class='summary-question' and contains(text(),'Alternative Control Plan')]/../p[1]"), 2).Text;
		}

		/// <summary>
		/// Get Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.
		/// </summary>
		public string GetGramsOfVocPerUseAsDefinedCaliforniaConsumerProductsQuestion()
		{
			WaitForSpinner();
			return this.containerElement.FindElement(By.XPath(".//h3[@class='summary-question' and contains(text(),'California Consumer Products Regulation')]/../p[1]"), 2).Text;
		}

		public List<string> GetInfoForSectionOption(string section, string option)
		{
			WaitForSpinner();
			var els = containerElement.FindElements(By.XPath(".//h3[@class='summary-question' and contains(text(),'" + section + "')]/../p[contains(text(),'" + option + "')]"), 2);

			return els.Select(x => x.GetElementText()).ToList();
		}
	}
}

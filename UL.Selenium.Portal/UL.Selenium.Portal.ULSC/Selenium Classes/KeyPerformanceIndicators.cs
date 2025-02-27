using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	class KeyPerformanceIndicators : BaseObject
	{
		public const string BasePath = "//section";

		private IList<IWebElement> El => this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'grid-stack-item-content')]"), 2);

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_For_Load(int secondsToWait = 30)
		{
			int counter = 0;
			bool loaded = false;
			while (counter < secondsToWait && !loaded)
			{
				loaded = this.WidgetContainer("", true) != null && GeneralUtilities.WaitForWidgetSpinner(1);
				Delay.Seconds(1);
				counter++;
			}
			return loaded;
		}

		public IWebElement WidgetContainer(string title, bool firstSection = false)
		{
			if (firstSection)
			{
				return this.El.FirstOrDefault();
			}
			IWebElement match = this.containerElement.FindElements(By.XPath(".//div[@class='panel-title']"), 2)
				?.FirstOrDefault(x => x.Text == title);
			return match?.FindElement(By.XPath("./ancestor::div[starts-with(@class,'grid-stack-item-content')][1]"), 2);
		}

		//public class DashboardWidget
		//{
		//	public string Title { get; set; }
		//}

		//public class SubscriptionStatus : DashboardWidget
		//{
		//	public string CenterHeading { get; set; }
		//}

		//public enum GraphType { Pie, Bar }

		//public class WidgetGraph
		//{
		//	public Dashboard.GraphType Type { get; set; }

		//	public Dashboard.GraphData Data { get; set; }

		//}

		//public class GraphData
		//{

		//}

		//public class BarData : Dashboard.GraphData
		//{

		//}

		//public class PieData : Dashboard.GraphData
		//{

		//}
	}
}

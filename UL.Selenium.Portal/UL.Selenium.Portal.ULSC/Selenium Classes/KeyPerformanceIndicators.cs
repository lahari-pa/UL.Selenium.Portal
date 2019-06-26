using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	class KeyPerformanceIndicators : BaseObject
	{
		public const string BasePath = "//section";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_For_Load(int secondsToWait = 30)
		{
			var counter = 0;
			var loaded = false;
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
				return this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'grid-stack-item-content')]"), 2).FirstOrDefault();
			}
			var match = this.containerElement.FindElements(By.XPath(".//div[@class='panel-title']"), 2)
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

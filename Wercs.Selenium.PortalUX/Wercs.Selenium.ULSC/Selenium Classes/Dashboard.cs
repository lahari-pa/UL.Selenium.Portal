using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextTemplating;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.ULSC.Selenium_Classes
{
	class Dashboard : BaseObject
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
				this.RefreshContainer();
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

		public bool RefreshContainer()
		{
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return this.containerElement != null;
		}
		//public List<DashboardWidget> GetWidgets()
		//{

		//}

		//public DashboardWidget GetWidget(string title)
		//{

		//}

		public List<string> WidgetTitles()
		{
			return this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'grid-stack-item-content')]//div[@class='panel-title']"), 2).Select(x => x.Text).ToList();
		}

		public bool ClickWidgetDropDownMenuToggle(string widgetTitle)
		{
			var xPath = ".//div[@class='panel-title' and text()='" + widgetTitle + "']/../..//button[@class='btn btn-default dropdown-toggle']";
			return this.containerElement.FindElement(By.XPath(xPath), 2).TryClick();
		}

		public bool WidgetDropDownMenuToggleDisplayed(string widgetTitle)
		{
			var xPath = ".//div[@class='panel-title' and text()='" + widgetTitle + "']/../..//button[@class='btn btn-default dropdown-toggle']";
			return this.containerElement.FindElement(By.XPath(xPath), 2) != null;
		}

		public bool RemoveDropDownItemDisplayed(string widgetTitle)
		{
			var container = this.WidgetContainer(widgetTitle);
			if (container == null)
			{
				return false;
			}
			var el = container.FindElement(By.XPath(".//a[@id='ulscn-message-center-remove']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickRemoveDropDownItem(string widgetTitle)
		{
			var container = this.WidgetContainer(widgetTitle);
			if (container == null)
			{
				return false;
			}
			var el = container.FindElement(By.XPath(".//a[@id='ulscn-message-center-remove']"), 2);
			return el.TryClick();
		}

		public MessageCenter GetMessageCenter()
		{
			var rMessageCenter = new MessageCenter();
			// get element with title 'Message Center'
			var container = this.WidgetContainer("Message Center");
			if (container == null)
			{
				return null;
			}
			rMessageCenter.Title = "Message Center";
			// Get Filter value
			rMessageCenter.FilterPlaceholder = container.FindElement(By.XPath(".//input[@id='filterCurrent']"), 2)?.GetAttribute("placeholder");
			// Get Messages
			rMessageCenter.FilterValue = container.FindElement(By.XPath(".//input[@id='filterCurrent']"), 2)?.GetValue();
			return rMessageCenter;
		}
		public class DashboardWidget
		{
			public string Title { get; set; }

			public WidgetGraph Graph { get; set; }
		}

		public class MessageCenter : DashboardWidget
		{
			// List <Message>
			public string FilterPlaceholder { get; set; }

			public string FilterValue { get; set; }
		}

		public class Message
		{
			public string Title { get; set; }

			public string BodyText { get; set; }


		}
		public enum GraphType { PieOneTier, PieTwoTier, Bar }

		public class WidgetGraph
		{
			public GraphType Type { get; set; }

			public GraphData Data { get; set; }

		}

		public class GraphData
		{

		}

	}
}

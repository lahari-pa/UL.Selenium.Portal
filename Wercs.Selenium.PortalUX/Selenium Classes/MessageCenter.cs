using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class MessageCenter : BaseObject
	{
		public const string BasePath = "//div[@id='msgCenterControl']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		/// <summary>
		/// this is the title of the page Message Center
		/// </summary>
		/// <returns></returns>
		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath("..//h2"), 2).Text.Trim();
		}

		public bool ClickPrimaryButton(string button)
		{
			return containerElement.FindElement(By.XPath(".//button[@class='btn btn-primary' and text()='" + button + "']"), 2).TryClick();
		}
		public bool ClickShowArchived()
		{
			var input = containerElement.FindElement(By.XPath(".//input[@id='chkArchivedMsgCtr']"), 2);
			if (input == null)
			{
				return false;
			}
			var currentlyChecked = input.Checked();
			return input.TryClick() && input.Checked() != currentlyChecked;
		}
		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				var activePageControl = containerElement.FindElement(By.XPath(".//ul[starts-with(@class,'pagination')]/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				var lastControl = containerElement.FindElements(By.XPath(".//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
				if (lastControl.Count == 0)
				{
					Report.Info("Last page is: 1");
					return 1;
				}
				return int.Parse(lastControl.Last().Text);
			}
			return 1;
		}
		public bool ClickPage(string page)
		{
			if (GetPage("current") == int.Parse(page))
			{
				return false;
			}
			Report.Info("Clicking page: " + page);
			return containerElement.FindElement(By.XPath(".//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
		}
		public int MessageCount()
		{
			return containerElement.FindElements(By.XPath(".//tbody[not(starts-with(@data-bind,'foreach:'))]/tr"), 2).Count;
		}
		public bool NextDisabled()
		{
			return containerElement.FindElement(By.XPath(".//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}
		public bool Navigation(string navOption)
		{

			switch (navOption.ToLower())
			{
				case "next":
					return containerElement.FindElement(By.XPath(".//a[@class='page-link next']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
				case "previous":
					return containerElement.FindElement(By.XPath(".//a[@class='page-link prev']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
			}
			Report.Failure("Unable to apply navigation option: " + navOption);
			return false;
		}
		public List<Message> MessageItems()
		{
			var rList = new List<Message>();
			ClickPage("1");
			int pageNumber = GetPage("current");
			var ingredientNumber = 1;
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return rList;
			}
			int lastPageNumber = GetPage("last");
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				var rowCount = MessageCount();
				for (int i = 1; i <= rowCount; i++)
				{
					rList.Add(GetMessage(i));
					ingredientNumber++;
				}
				if (NextDisabled())
				{
					Report.Info("Found a total of: " + rList.Count + " ingredients");
					ClickPage("1");
					return rList;
				}
				Navigation("next");
				pageNumber = GetPage("current");
			}
			Report.Info("Found a total of: " + rList.Count + " ingredients");
			Report.Screenshot();
			ClickPage("1");
			return rList;
		}
		public Message GetMessage(int row)
		{
			var tableRow = containerElement.FindElement(By.XPath(".//tbody/tr[" + row + "]"), 2);
			if (tableRow == null)
			{
				return new Message();
			}
			return new Message() {
				WPSID = tableRow.FindElement(By.XPath(".//span[@data-bind='text: ProductID']"), 2).Text,
				ModificationDate = tableRow.FindElement(By.XPath(".//span[starts-with(@data-bind,'text: new Date')]"), 2).Text,
				Name = tableRow.FindElement(By.XPath(".//span[@data-bind='text: ProductName']"), 2).Text,
				Type = tableRow.FindElement(By.XPath(".//span[starts-with(@data-bind,'text: Type')]"), 2).Text
			};
		}
		public class Message
		{
			public string WPSID { get; set; }
			public string Name { get; set; }
			public string Type { get; set; }
			public string ModificationDate { get; set; }

		}
	}

}

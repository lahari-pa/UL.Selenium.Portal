using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class MessageCenter : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='msgCenterControl']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

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
			return this.containerElement.FindElement(By.XPath(".//button[@class='btn btn-primary' and text()='" + button + "']"), 2).TryClick();
		}
		public bool ClickShowArchived()
		{
			IWebElement input = this.containerElement.FindElement(By.XPath(".//input[@id='chkArchivedMsgCtr']"), 2);
			if (input == null)
			{
				return false;
			}
			bool currentlyChecked = input.Checked();
			return input.TryClick() && input.Checked() != currentlyChecked;
		}
		public bool ClickFilter()
		{
			IWebElement button = this.containerElement.FindElement(By.XPath("//button[contains(text(), 'Filter')]"));
			if (button == null)
			{
				return false;
			}
			return button.TryClick();
		}
		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				IWebElement activePageControl = this.containerElement.FindElement(By.XPath(".//ul[starts-with(@class,'pagination')]/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				IList<IWebElement> lastControl = this.containerElement.FindElements(By.XPath(".//ul[starts-with(@class,'pagination')]/li/a[@class='page-link']"), 2);
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
			if (this.GetPage("current") == int.Parse(page))
			{
				return false;
			}
			Report.Info("Clicking page: " + page);
			return this.containerElement.FindElement(By.XPath(".//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
		}
		public int MessageCount()
		{
			return this.containerElement.FindElements(By.XPath(".//tbody[not(starts-with(@data-bind,'foreach:'))]/tr"), 2).Count;
		}
		public bool NextDisabled()
		{
			return this.containerElement.FindElement(By.XPath(".//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}
		public bool Navigation(string navOption)
		{

			switch (navOption.ToLower())
			{
				case "next":
					return this.containerElement.FindElement(By.XPath(".//a[@class='page-link next']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
				case "previous":
					return this.containerElement.FindElement(By.XPath(".//a[@class='page-link prev']")).TryClick() && GeneralUtilities.Wait_for_load_finish();
			}
			Report.Failure("Unable to apply navigation option: " + navOption);
			return false;
		}
		public List<Message> MessageItems()
		{
			var rList = new List<Message>();
			this.ClickPage("1");
			int pageNumber = this.GetPage("current");
			int ingredientNumber = 1;
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return rList;
			}
			int lastPageNumber = this.GetPage("last");
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				int rowCount = this.MessageCount();
				for (int i = 1; i <= rowCount; i++)
				{
					rList.Add(this.GetMessage(i));
					ingredientNumber++;
				}
				if (this.NextDisabled())
				{
					Report.Info("Found a total of: " + rList.Count + " ingredients");
					this.ClickPage("1");
					return rList;
				}
				this.Navigation("next");
				pageNumber = this.GetPage("current");
			}
			Report.Info("Found a total of: " + rList.Count + " ingredients");
			Report.Screenshot();
			this.ClickPage("1");
			return rList;
		}
		public Message GetMessage(int row)
		{
			IWebElement tableRow = this.containerElement.FindElement(By.XPath(".//tbody/tr[" + row + "]"), 2);
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

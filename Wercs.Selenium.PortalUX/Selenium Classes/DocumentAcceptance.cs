using System;
using System.Collections.Generic;
using System.Linq;
using Mailosaur;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class DocumentAcceptance : BaseObject
	{
		public const string BasePath = "//div[@id='documentAcceptanceContainer']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickApproveSDS()
		{
			return false;
		}
		public bool ClickEditSDS()
		{
			return false;
		}
		public bool UserGridNavigation(string navOption)
		{
			IWebElement navEl;
			switch (navOption)
			{
				case "next":
					navEl = containerElement.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
					break;
				case "previous":
					navEl = containerElement.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
					break;
				case "...":
					navEl = containerElement.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
					break;
				default:
					Report.Info("An invalid navigation option was provided. Must either be 'next' or 'previous'");
					return false;
			}
			if (navEl == null)
			{
				Report.Info("Could not locate the navigation button element");
				return false;
			}
			navEl.ScrollElementIntoView();
			return navEl.TryClick();
		}

		public int GetPage(string position)
		{
			if (position.ToLower() == "current")
			{
				var activePageControl = containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				var lastControl = containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[@class='page-link']"), 2);
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
			return containerElement.FindElement(By.XPath(".//div[@id='settings']//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
		}

		public bool NextDisabled()
		{
			var pagingControl = containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']"), 2);
			if (pagingControl == null)
			{
				Report.Failure("Unable to find the paging control on grid navigation");
				return false;
			}
			return pagingControl.FindElement(By.XPath(".//span[@class='current next' and parent::li[@class='disabled']]"), 2) != null;
		}

		public List<MyProductsItem> GetProducts()
		{
			var rList = new List<MyProductsItem>();
			var rows = containerElement.FindElements(By.XPath(".//div[./h3[text()='My Products']]//tbody/tr"), 2);
			foreach (var row in rows)
			{
				var productsItem = new MyProductsItem();
				productsItem.WPSID = row.FindElement(By.XPath("./td[contains(@data-bind,'ProductID')]"), 2)?.Text;
				productsItem.ProductName = row.FindElement(By.XPath("./td[contains(@data-bind,'Name')]"), 2)?.Text;
				rList.Add(productsItem);
			}
			return rList;
		}
		public List<DocumentsItem> GetDocuments()
		{
			return new List<DocumentsItem>();
		}
		public class MyProductsItem : DocumentAcceptance
		{
			public string WPSID { get; set; }
			public string ProductName { get; set; }

			public bool Click()
			{
				return containerElement.FindElement(By.XPath(".//div[./h3[text()='My Products']]//tbody/tr[./td[contains(@data-bind, 'ProductID') and text()='" + WPSID + "']]"), 2).TryClick();
			}
		}
		public class DocumentsItem
		{
			public string FileName { get; set; }
			public string Subformat { get; set; }
			public string Language { get; set; }

		}
	}
}

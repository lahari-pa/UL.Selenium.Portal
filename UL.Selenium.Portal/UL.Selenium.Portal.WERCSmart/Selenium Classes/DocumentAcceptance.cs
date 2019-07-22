using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DocumentAcceptance : SeleniumBaseObject
	{

		protected override By ContainerElementLocator => By.XPath("//div[@id='documentAcceptanceContainer']");

		public bool ClickApproveSDS()
		{
			return false;
		}
		public bool ClickEditSDS()
		{
			return false;
		}
		public bool ProductGridNavigation(string navOption)
		{
			IWebElement navEl;
			switch (navOption)
			{
				case "next":
					navEl = this.containerElement.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
					break;
				case "previous":
					navEl = this.containerElement.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
					break;
				case "...":
					navEl = this.containerElement.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
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
				IWebElement activePageControl = this.containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']/li[@class='active']/span"), 2);
				if (activePageControl == null)
				{
					Report.Failure("The page control could not be found on the My Packaging Types grid");
					return -1;
				}
				return int.Parse(activePageControl.Text);
			}
			if (position.ToLower() == "last")
			{
				IList<IWebElement> lastControl = this.containerElement.FindElements(By.XPath(".//ul[@id='pagingControl']/li/a[@class='page-link']"), 2);
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
			try
			{
				if (this.GetPage("current") == int.Parse(page))
				{
					return false;
				}
				Report.Info("Clicking page: " + page);
				return this.containerElement.FindElement(By.XPath("//a[@class='page-link' and text()= '" + page + "']"), 2).TryClick();
			}
			finally
			{
				GeneralUtilities.Wait_for_load_finish();
			}
		}

		public bool NextDisabled()
		{
			IWebElement pagingControl = this.containerElement.FindElement(By.XPath(".//ul[@id='pagingControl']"), 2);
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
			this.ClickPage("1");
			GeneralUtilities.Wait_for_load_finish();
			int pageNumber = this.GetPage("current");
			if (pageNumber == -1)
			{
				Report.Failure("Could not get current page number from the grid");
				return rList;
			}
			int lastPageNumber = this.GetPage("last");
			while (pageNumber <= lastPageNumber && pageNumber != -1)
			{
				IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//div[./h3[text()='My Products']]//tbody/tr"), 2);
				foreach (IWebElement row in rows)
				{
					var productsItem = new MyProductsItem {
						WPSID = row.FindElement(By.XPath("./td[contains(@data-bind,'ProductID')]"), 2)?.Text,
						ProductName = row.FindElement(By.XPath("./td[contains(@data-bind,'Name')]"), 2)?.Text,
						PageNumber = this.GetPage("current").ToString()
					};
					rList.Add(productsItem);
				}
				if (this.NextDisabled())
				{
					Report.Info("Found a total of: " + rList.Count + " ingredients");
					this.ClickPage("1");
					return rList;
				}
				this.ProductGridNavigation("next");
				GeneralUtilities.Wait_for_load_finish();
				pageNumber = this.GetPage("current");
			}
			return rList;
		}
		public List<string> DocumentsGridHeadings()
		{
			var rList = new List<string>();
			IList<IWebElement> headings = this.containerElement.FindElements(By.XPath(".//div[./h3[contains(text(),'Documents')]]//thead//th"), 2);
			return headings.Select(x => x.Text).ToList();
		}
		public List<DocumentsItem> GetDocuments()
		{
			var rList = new List<DocumentsItem>();
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//div[./h3[contains(text(),'Documents')]]//tbody/tr"), 2);
			int i = 1;
			foreach (IWebElement row in rows)
			{
				var documentsItem = new DocumentsItem() {
					FileName = row.FindElement(By.XPath("./td[contains(@data-bind,'FileName')]"), 2)?.Text,
					Subformat = row.FindElement(By.XPath("./td[contains(@data-bind,'Subformat')]"), 2)?.Text,
					Language = row.FindElement(By.XPath("./td[contains(@data-bind,'Language')]"), 2)?.Text,
					Row = i
				};
				rList.Add(documentsItem);
				i++;
			}
			return rList;
		}

		public bool DocumentWindowOpen(string option)
		{
			Report.Info("Switch to Wercs Document window");
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			System.Collections.ObjectModel.ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url.Contains(option))
				{
					return true;
				}
			}
			return false;
		}

		public bool CloseDocumentWindow(string option)
		{
			Report.Info("Close the document window");
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			System.Collections.ObjectModel.ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url.Contains(option))
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Close();
					return true;
				}
			}
			return false;
		}

		public bool SwitchToMainWindow()
		{
			ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url.Contains("WercSmart"))
				{
					return true;
				}
			}
			return false;
		}

		public string DocumentText(string address)
		{
			var reader = new PdfReader(address);
			var output = new StringWriter();
			for (int i = 1; i <= reader.NumberOfPages; i++)
			{
				output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));
			}
			return output.ToString();
		}

		public class MyProductsItem : DocumentAcceptance
		{
			public string WPSID { get; set; }
			public string ProductName { get; set; }
			public string PageNumber { get; set; }

			public bool Click()
			{
				return this.containerElement.FindElement(By.XPath(".//div[./h3[text()='My Products']]//tbody/tr[./td[contains(@data-bind, 'ProductID') and text()='" + this.WPSID + "']]"), 2).TryClick();
			}
		}
		public class DocumentsItem : DocumentAcceptance
		{
			public int Row { get; set; }
			public string FileName { get; set; }
			public string Subformat { get; set; }
			public string Language { get; set; }

			public bool ClickAction(string action)
			{
				switch (action.ToLower())
				{
					case "view":
						return this.containerElement.FindElement(By.XPath(".//div[./h3[contains(text(),'Documents')]]//tbody/tr[" + this.Row + "]//a[text()='View']"), 2).TryClick();
				}
				return false;
			}
		}
	}
}

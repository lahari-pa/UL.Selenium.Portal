using iText.Kernel.Pdf.Canvas.Parser.Listener;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Helpers;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class DocumentAcceptance : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='documentAcceptanceContainer']");
		private List<MyProductTableRow> MyProductsTableRows => this.FindElements(By.XPath(".//div[h3[text() = 'My Products']]//tbody//tr"), 1).Select(x => new MyProductTableRow(x)).ToList();
		public MyProductTableRow MyProductsTableRowSearchById(string productId) => this.MyProductsTableRows.FirstOrDefault(x => x.WPSID.Equals(productId, System.StringComparison.Ordinal));
		private List<DocumentsTableRow> DocumentsTableRows => this.FindElements(By.XPath(".//div[h3[contains(text(), 'Documents')]]//tbody//tr"), 1).Select(x => new DocumentsTableRow(x)).ToList();
		public DocumentsTableRow DocumentsTableRowSearchBySubFormatAndLanguage(string subFormat, string language) => this.DocumentsTableRows.FirstOrDefault(x => x.SubFormat.Equals(subFormat, System.StringComparison.Ordinal) && x.Language.Equals(language, System.StringComparison.Ordinal));
		public bool MyProductsTableRowSearchByIdExists(string productId)
		{
			Report.Info($"Attempting to confirm the row with Id {productId} exists");
			return this.MyProductsTableRowSearchById(productId) != null;
		}
		public bool DocumentsTableRowSearchBySubFormatAndLanguageExists(string subFormat, string language)
		{
			Report.Info($"Attempting to confirm the row with the subformat '{subFormat}' and the language '{language}' exists");
			return this.DocumentsTableRowSearchBySubFormatAndLanguage(subFormat, language) != null;
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
			string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			System.Collections.ObjectModel.ReadOnlyCollection<string> handles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Url.Contains(option))
				{
					return true;
				}
			}
			return false;
		}

		public bool CloseDocumentWindow(string option)
		{
			Report.Info("Close the document window");
			string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			System.Collections.ObjectModel.ReadOnlyCollection<string> handles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Url.Contains(option))
				{
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Close();
					return true;
				}
			}
			return false;
		}

		public bool SwitchToMainWindow()
		{
			ReadOnlyCollection<string> handles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Url.Contains("WercSmart"))
				{
					return true;
				}
			}
			return false;
		}

		public string DocumentText(string address) => WercsmartPdfHelpers.GetTextFromPdf(address, new SimpleTextExtractionStrategy());

		public bool ConfirmDocumentAcceptancePageIsShowing()
		{
			IWebElement DocumentAcceptancePageTitle = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='page-inner-header affix-top']//h2[text()='Document Acceptance']"), 2);
			if (DocumentAcceptancePageTitle == null)
			{
				return false;
			}
			else
			{
				return true;
			}
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

	public class MyProductTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string WPSID => this.ContainerElement.FindElement(By.XPath(".//td[contains(@data-bind, 'ProductID')]"), 1)?.Text;
		private IWebElement ProductName => this.ContainerElement.FindElement(By.XPath(".//td[contains(@data-bind, 'Name')]"));
		#endregion

		#region Methods

		public bool MyProductTableRowExists()
		{
			return this.ContainerElement != null;
		}
		public bool ProductNameExists()
		{
			Report.Info($"Attempt to find Product Name");
			return this.ProductName != null;
		}
		public string GetProductName()
		{
			Report.Info($"Attempt to get Product Name");
			return this.ProductName.Text;
		}
		#endregion

	}
	public class DocumentsTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string SubFormat => this.ContainerElement.FindElement(By.XPath(".//td[contains(@data-bind, 'Subformat')]"), 1)?.Text;
		public string Language => this.ContainerElement.FindElement(By.XPath(".//td[contains(@data-bind, 'Language')]"), 1)?.Text;
		private IWebElement ViewLink => this.ContainerElement.FindElement(By.XPath(".//a[text()='View']"));
		#endregion

		#region Methods

		public bool DocumentsTableRowExists()
		{
			return this.ContainerElement != null;
		}
		public bool ViewLinkExists()
		{
			Report.Info($"Attempt to find the 'View' link");
			return this.ViewLink != null;
		}
		public bool ViewLinkClick()
		{
			Report.Info($"Attempt to click the 'View' link");
			return this.ViewLink.TryClick();
		}
		#endregion


	}
}

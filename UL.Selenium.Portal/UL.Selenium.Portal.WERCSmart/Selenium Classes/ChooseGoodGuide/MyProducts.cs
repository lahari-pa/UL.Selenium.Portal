using System;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class MyProducts : SeleniumBaseObject
	{
		// Cannot have a more precise container element than this
		protected override By ContainerElementLocator => By.XPath("//section[@id='productGridSection']");

		public bool SetSearchCriteria(string searchBy, string filter, string upc, string status)
		{
			try
			{
				if (searchBy.Length > 0)
				{
					IWebElement searchBySelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath(
						"//section[@id='productGridSection']//label[contains(text(), 'Search By')]/following-sibling::select"));
					searchBySelect.Select(searchBy);

				}

				if (filter.Length > 0)
				{
					SeleniumBrowser.WebBrowser
						.FindElement(
							By.XPath("//section[@id='productGridSection']//label[contains(text(), 'Filter')]/following-sibling::input"))
						.EnterText(filter);
				}

				if (upc.Length > 0)
				{
					SeleniumBrowser.WebBrowser.FindElement(By.XPath(
						"//section[@id='productGridSection']//label[contains(text(), 'UPC')]/following-sibling::input")).EnterText(upc);
				}

				if (status.Length > 0)
				{
					SeleniumBrowser.WebBrowser.FindElement(By.XPath(
							"//section[@id='productGridSection']//label[contains(text(), 'Status')]/following-sibling::select"))
						.Select(status);
				}

				return true;
			}
			catch (Exception)
			{
			}

			return false;

		}

		public bool ClickFilter()
		{
			if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@id='cmdFilterProducts']")).TryClick())
			{
				this.WaitForLoadingToGo();
				return true;
			}

			return false;
		}

		public bool ClickClearFilter()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@id='cmdClear']")).TryClick();
		}

		public bool FindAndClickProduct(string findBy, string findValue)
		{
			try
			{
				System.Collections.Generic.IEnumerable<string> ListOfHeaders =
					SeleniumBrowser.WebBrowser.FindElements(
							By.XPath(".//table[@class='ui-jqgrid-htable']//th[not(contains(@style, 'none'))]/div"))
						.Select(x => x.Text.Trim());

				//get the index of the header of the item we want to match
				int i = ListOfHeaders.Select((value, index) => new {
					value,
					index = index + 1
				})
							.Where(pair => pair.value == findBy)
							.Select(pair => pair.index)
							.FirstOrDefault() - 1;

				if (i > -1)
				{
					return SeleniumBrowser.WebBrowser
						.FindElements(
							By.XPath("//table[@id='tblProducts']//td[not(contains(@style, 'none'))][" + (i + 1).ToString() + "]"))
						.FirstOrDefault(x => x.Text.Trim() == findValue).TryClick();
				}
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
			}

			return false;
		}


		public bool ClickEditProduct(string findBy, string findValue)
		{
			if (this.FindAndClickProduct(findBy, findValue))
			{
				Delay.Seconds(2);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@class='editdata']")).TryClick())
				{
					Report.Info("Clicked edit button");
					Delay.Seconds(1);

					return this.Wait_for_load(60);
				}
			}

			return false;
		}

		public bool ClickDeleteProduct(string findBy, string findValue)
		{
			if (this.FindAndClickProduct(findBy, findValue))
			{
				Report.Screenshot();
				Delay.Seconds(2);
				return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//a[@title='Delete Product']")).TryClick();
			}

			return false;
		}


		public void WaitForLoadingToGo()
		{
			for (int i = 0; i < 240; i++)
			{
				try
				{
					IWebElement invisibleLoading =
						SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='load_tblProducts' and contains(@style,'none')]"));
					if (invisibleLoading != null)
					{
						return;
					}
				}
				catch (Exception)
				{
				}

				Delay.Seconds(1);
			}

			throw new Exception("Loading is still showing afater 240 seconds");
		}

	}

	class DeleteProduct : BaseObject
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//div[contains(@role, 'dialog') and (.//span[contains(text(), 'Delete Product')])]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickDelete()
		{
			return this.containerElement.FindElement(By.XPath(".//button[(./span[contains(text(),'Delete')])]")).TryClick();
		}

		public bool ClickCancel()
		{
			return this.containerElement.FindElement(By.XPath(".//button[(./span[contains(text(),'Cancel')])]")).TryClick();
		}

		public bool WaitForDialogToDisappear(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				if (!this.Wait_for_load(1))
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;
		}
	}
}

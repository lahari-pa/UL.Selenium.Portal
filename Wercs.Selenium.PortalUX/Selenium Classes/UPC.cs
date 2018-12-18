using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using Org.BouncyCastle.Crypto.Engines;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class UPC : BaseObject
	{
		public const string BasePath = "//div[@id='dataentry']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickAddCaseUpcButton()
		{
			var el = containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public List<string> GetUPCOptions()
		{
			var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var rList = new List<string>();
			if (container != null)
			{
				rList = container.FindElements(By.XPath("//tbody//div[@class='form-group']")).Select(x => x.Text.Trim()).ToList();
				rList.Select(x => x.Replace("\r\n", " ").Split(' ')).ToList();
			}
			return rList;
		}

		public string SelectProducts_FirstProductID()
		{
			var productRows = containerElement.FindElements(By.XPath(".//span[@class='select2-results']"), 2).ToList();
			if (productRows.Count == 0)
			{
				Report.Info("No product rows were returned!");
				return null;
			}
			foreach (var row in productRows)
			{
				if (row.FindElement(By.XPath(".//ul[@class='select2-results__options']"), 2) != null)
				{
					return row.FindElement(By.XPath(".//li[@class='select2-results__option']"), 2)?.Text;
				}
			}
			return null;
		}

		public bool EnterTextToSearchField(string value)
		{
			var searchEl = containerElement.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
			searchEl.EnterText(value);
			return searchEl.GetAttribute("value") == value && GeneralUtilities.Wait_for_load_finish();
		}

		public bool SelectProducts_ClickProductByID(string id)
		{
			var productRow = containerElement.FindElement(By.XPath(".//li[@class='select2-results__option' and text()='" + id + "']"), 2);
			if (productRow == null)
			{
				Report.Info("Could not find product row for product ID: " + id);
				return false;
			}
			return productRow.FindElement(By.XPath(".//ul[@class='select2-results__options']"), 2).TryClick();
		}
	}
}

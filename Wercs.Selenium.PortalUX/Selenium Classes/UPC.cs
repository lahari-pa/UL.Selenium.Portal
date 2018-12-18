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
				rList.Select(x => x.Replace("\r\n", " ").Split(' ').FirstOrDefault()).ToList();
			}
			return rList;
		}
	}
}

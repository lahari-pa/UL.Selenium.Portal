using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ReviewDocuments : BaseObject
	{
		public const string BasePath = "//div[@id='reviewDocumentsContainer']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public List<string> GetColumnsFromDocumentsTable()
		{
			return containerElement.FindElements(By.XPath(".//div[@id='documents-grid']/table//th")).Select(x => x.Text)
				.ToList();
		}

		public bool ClickViewInFirstSupplierUploadedDoc()
		{
			return containerElement.FindElements(By.XPath(".//div[@id='supplier-uploaded-grid']//tr/td[2]/a"))
				.FirstOrDefault().TryClick();
		}

	}
}

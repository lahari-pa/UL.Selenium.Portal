using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ReviewDocuments : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='reviewDocumentsContainer']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public List<string> GetColumnsFromDocumentsTable()
		{
			return this.containerElement.FindElements(By.XPath(".//div[@id='documents-grid']/table//th")).Select(x => x.Text)
				.ToList();
		}

		public bool ClickViewInFirstSupplierUploadedDoc()
		{
			return this.containerElement.FindElements(By.XPath(".//div[@id='supplier-uploaded-grid']//tr/td[2]/a"))
				.FirstOrDefault().TryClick();
		}

	}
}

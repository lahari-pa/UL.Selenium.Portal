using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ReviewDocuments : BaseObject
	{
		public const string BasePath = "//div[@id='reviewDocumentsContainer']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

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

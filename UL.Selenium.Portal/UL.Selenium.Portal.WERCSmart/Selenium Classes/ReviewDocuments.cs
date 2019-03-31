using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Extension_Methods;
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

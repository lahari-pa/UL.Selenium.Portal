using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Castle.Core.Internal;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ViewUpcs : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='summary-container']");

		private IWebElement SummaryProductContainer => this.containerElement.FindElement(By.XPath("/div[@class='summary-product']"), 2);

		private IWebElement ProductNameWpsId => this.SummaryProductContainer.FindElement(By.XPath("//h3/small[text()='Product Name (WPSID)']/following-sibling::span"), 2);

		private IWebElement ProductUpcBody => this.containerElement.FindElement(By.XPath("./div[@class='container']"), 2);

		private List<IWebElement> UpcRows => this.ProductUpcBody.FindElements(By.XPath(".//div[@class='summary-question-container]/table/tbody/tr[contains(@data-bind,'values')]"), 2).ToList();

		private List<IWebElement> UpcHeadings => this.ProductUpcBody.FindElements(By.XPath(".//div[@class='summary-question-container]/table/tbody/tr[contains(@data-bind,'values')]/th"), 2).ToList();

		private string[] HeadingTitles => this.UpcHeadings.Select(x => x.FindElement(By.XPath("./div"), 2).Text).ToArray();

		public List<ProductUpc> Upcs()
		{
			var rList = new List<ProductUpc>();
			foreach (var row in this.UpcRows)
			{
                var thisUpc = new ProductUpc();
                var upcNumberIndex = Array.IndexOf(this.HeadingTitles, "UPC Number");
                if (upcNumberIndex != -1)
                {
	                thisUpc.UpcNumber = row.FindElement(By.XPath($"./td[position()={upcNumberIndex + 1}]/ div"), 2)?.Text;
                }
                var containerTypeIndex = Array.IndexOf(this.HeadingTitles, "Container Type");
                if (containerTypeIndex != -1)
                {
	                thisUpc.ContainerType = row.FindElement(By.XPath($"./td[position()={containerTypeIndex + 1}]/ div"), 2)?.Text;
                }
				var sizeIndex = Array.IndexOf(this.HeadingTitles, "Size (Ounces)");
				if (sizeIndex != -1)
				{
					thisUpc.SizeOunces = row.FindElement(By.XPath($"./td[position()={sizeIndex + 1}]/ div"), 2)?.Text;
				}
				var retailersIndex = Array.IndexOf(this.HeadingTitles, "Retailers");
				if (retailersIndex != -1)
				{
					thisUpc.Retailers = row.FindElement(By.XPath($"./td[position()={retailersIndex + 1}]/ div"), 2)?.Text.Split(',').Select(x=>x.Trim()).ToList();
				}
			}
			return rList;
		}

		public class ProductUpc
		{
			public string UpcNumber { get; set; }

			public string ContainerType { get; set; }

            public string SizeOunces { get; set; }

            public List<string> Retailers { get; set; }


		}
	}
}

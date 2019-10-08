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

		private List<IWebElement> UpcRows => this.ProductUpcBody.FindElements(By.XPath(".//div[@class='summary-question-container']/table/tbody/tr[contains(@data-bind,'values')]"), 2).ToList();

		private List<IWebElement> UpcHeadings => this.ProductUpcBody.FindElements(By.XPath(".//div[@class='summary-question-container']/table/thead/tr[contains(@data-bind,'values')]/th"), 2).ToList();

		private string[] HeadingTitles => this.UpcHeadings.Select(x => x.FindElement(By.XPath("./div"), 2).Text).ToArray();

		public List<ProductUpc> Upcs()
		{
			var rList = new List<ProductUpc>();
			foreach (IWebElement row in this.UpcRows)
			{
				var thisUpc = new ProductUpc();
				for (int i=0; i< this.HeadingTitles.Count(); i++)
				{
					var heading = this.HeadingTitles[i];
					var colEl = row.FindElement(By.XPath($"./td[position()={i + 1}]/ div"), 2);
					var colVal = colEl?.Text;
					switch (heading)
					{
						case "UPC Number":
							thisUpc.UpcNumber = colVal;
							thisUpc.TruckIcon = colEl.FindElement(By.XPath("./i[@class='fa fa-truck']"), 1) != null;
							break;
						case "Associated UPC":
							thisUpc.AssociatedUpc = colVal;
							break;
						case "Container Type":
							thisUpc.ContainerType = colVal;
							break;
						case "Size (Ounces)":
							thisUpc.SizeOunces = colVal;
							break;
						case "Quantity":
							thisUpc.Quantity = colVal;
							break;
						case "Transport":
							thisUpc.Transport = colVal;
							break;
						case "Retailers":
							thisUpc.Retailers = colVal.Split(',').Select(x => x.Trim()).ToList();
							break;
					}
				}
				//int upcNumberIndex = Array.IndexOf(this.HeadingTitles, "UPC Number");
				//if (upcNumberIndex != -1)
				//{
				//	thisUpc.UpcNumber = row.FindElement(By.XPath($"./td[position()={upcNumberIndex + 1}]/ div"), 2)?.Text;
				//}
				//int associatedUpcIndex = Array.IndexOf(this.HeadingTitles, "Associated UPC");
				//if (associatedUpcIndex != -1)
				//{
				//	thisUpc.AssociatedUpc = row.FindElement(By.XPath(""), 2)?.Text;
				//}
				//int containerTypeIndex = Array.IndexOf(this.HeadingTitles, "Container Type");
				//if (containerTypeIndex != -1)
				//{
				//	thisUpc.ContainerType = row.FindElement(By.XPath($"./td[position()={containerTypeIndex + 1}]/ div"), 2)?.Text;
				//}
				//int sizeIndex = Array.IndexOf(this.HeadingTitles, "Size (Ounces)");
				//if (sizeIndex != -1)
				//{
				//	thisUpc.SizeOunces = row.FindElement(By.XPath($"./td[position()={sizeIndex + 1}]/ div"), 2)?.Text;
				//}
				//int retailersIndex = Array.IndexOf(this.HeadingTitles, "Retailers");
				//if (retailersIndex != -1)
				//{
				//	thisUpc.Retailers = row.FindElement(By.XPath($"./td[position()={retailersIndex + 1}]/ div"), 2)?.Text.Split(',').Select(x => x.Trim()).ToList();
				//}
				rList.Add(thisUpc);
			}
			return rList;
		}

		public List<ProductUpc> NormalUPCs()
		{
			return this.Upcs().Where(x => !x.TruckIcon).ToList();
			//var rList = new List<ProductUpc>();
			//foreach (IWebElement row in this.UpcRows)
			//{
			//	var thisUpc = new ProductUpc();
			//	int upcNumberIndex = Array.IndexOf(this.HeadingTitles, "UPC Number");
			//	if (upcNumberIndex != -1)
			//	{
			//		IWebElement upc = row.FindElement(By.XPath($"./td[position()={upcNumberIndex + 1}]/ div"), 2);
			//		IWebElement truck = upc.FindElement(By.XPath(@"//i[@class='fa fa-truck']"), 2);
			//		if (truck == null)
			//		{
			//			thisUpc.UpcNumber = row.FindElement(By.XPath($"./td[position()={upcNumberIndex + 1}]/ div"), 2)?.Text;
			//		}
			//		else
			//		{
			//			continue;
			//		}

			//	}
			//	int containerTypeIndex = Array.IndexOf(this.HeadingTitles, "Container Type");
			//	if (containerTypeIndex != -1)
			//	{
			//		thisUpc.ContainerType = row.FindElement(By.XPath($"./td[position()={containerTypeIndex + 1}]/ div"), 2)?.Text;
			//	}
			//	int sizeIndex = Array.IndexOf(this.HeadingTitles, "Size (Ounces)");
			//	if (sizeIndex != -1)
			//	{
			//		thisUpc.SizeOunces = row.FindElement(By.XPath($"./td[position()={sizeIndex + 1}]/ div"), 2)?.Text;
			//	}
			//	int retailersIndex = Array.IndexOf(this.HeadingTitles, "Retailers");
			//	if (retailersIndex != -1)
			//	{
			//		thisUpc.Retailers = row.FindElement(By.XPath($"./td[position()={retailersIndex + 1}]/ div"), 2)?.Text.Split(',').Select(x => x.Trim()).ToList();
			//	}
			//	rList.Add(thisUpc);
			//}
			//return rList;
		}

		public List<ProductUpc> CaseUPCs()
		{
			return this.Upcs().Where(x => x.TruckIcon).ToList();
			//var rList = new List<ProductUpc>();
			//foreach (IWebElement row in this.UpcRows)
			//{
			//	var thisUpc = new ProductUpc();
			//	int upcNumberIndex = Array.IndexOf(this.HeadingTitles, "UPC Number");
			//	if (upcNumberIndex != -1)
			//	{
			//		IWebElement upc = row.FindElement(By.XPath($"./td[position()={upcNumberIndex + 1}]/ div"), 2);
			//		IWebElement truck = upc.FindElement(By.XPath(@"//i[@class='fa fa-truck']"), 2);
			//		if (truck != null)
			//		{
			//			thisUpc.UpcNumber = row.FindElement(By.XPath($"./td[position()={upcNumberIndex + 1}]/ div"), 2)?.Text;
			//		}
			//		else
			//		{
			//			continue;
			//		}

			//	}
			//	int containerTypeIndex = Array.IndexOf(this.HeadingTitles, "Container Type");
			//	if (containerTypeIndex != -1)
			//	{
			//		thisUpc.ContainerType = row.FindElement(By.XPath($"./td[position()={containerTypeIndex + 1}]/ div"), 2)?.Text;
			//	}
			//	int sizeIndex = Array.IndexOf(this.HeadingTitles, "Size (Ounces)");
			//	if (sizeIndex != -1)
			//	{
			//		thisUpc.SizeOunces = row.FindElement(By.XPath($"./td[position()={sizeIndex + 1}]/ div"), 2)?.Text;
			//	}
			//	int retailersIndex = Array.IndexOf(this.HeadingTitles, "Retailers");
			//	if (retailersIndex != -1)
			//	{
			//		thisUpc.Retailers = row.FindElement(By.XPath($"./td[position()={retailersIndex + 1}]/ div"), 2)?.Text.Split(',').Select(x => x.Trim()).ToList();
			//	}
			//	rList.Add(thisUpc);
			//}
			//return rList;
		}

		public class ProductUpc
		{
			public string UpcNumber { get; set; }

			public string ContainerType { get; set; }

			public string SizeOunces { get; set; }

			public List<string> Retailers { get; set; }

			public string AssociatedUpc { get; set; }

			public string Quantity { get; set; }

			public string Transport { get; set; }

			public bool TruckIcon { get; set; }

		}
	}
}

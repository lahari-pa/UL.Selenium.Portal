using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ViewUpcs : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='summary-container']");

		private IWebElement SummaryProductContainer => this.containerElement.FindElement(By.XPath("/div[@class='summary-product']"), 2);

		private IWebElement ProductNameWpsId => this.SummaryProductContainer.FindElement(By.XPath("//h3/small[text()='Product Name (WPSID)']/following-sibling::span"), 2);

		private IWebElement ProductUpcBody => this.containerElement.FindElement(By.XPath("./div[@class='container']"), 2);

		private List<IWebElement> UpcRows => this.ProductUpcBody.FindElements(By.XPath(".//div[contains(@class,'summary-question-container')]/table/tbody/tr[contains(@data-bind,'values')]"), 2).ToList();

		private List<IWebElement> UpcHeadings => this.ProductUpcBody.FindElements(By.XPath(".//div[contains(@class,'summary-question-container')]/table/thead/tr[contains(@data-bind,'values')]/th"), 2).ToList();

		private string[] HeadingTitles => this.UpcHeadings.Select(x => x.FindElement(By.XPath("./div"), 2).Text).ToArray();

		public List<ProductUpc> Upcs()
		{
			var rList = new List<ProductUpc>();
			foreach (IWebElement row in this.UpcRows)
			{
				var thisUpc = new ProductUpc();
				for (int i = 0; i < this.HeadingTitles.Count(); i++)
				{
					var heading = this.HeadingTitles[i];
					var colEl = row.FindElement(By.XPath($".//td[position()={i + 1}]/div"), 2);
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
				rList.Add(thisUpc);
			}
			return rList;
		}

		public List<ProductUpc> NormalUPCs()
		{
			return this.Upcs().Where(x => !x.TruckIcon).ToList();
		}

		public List<ProductUpc> CaseUPCs()
		{
			return this.Upcs().Where(x => x.TruckIcon).ToList();
		}

		public bool DoesUPCHeadingsContain(string headingName)
		{

			var newList = this.HeadingTitles;
			if (newList.Contains(headingName))
			{
				return true;
			}
			else
			{
				Report.Info("Did not find the Heading name: " + headingName + ". Heading names found are as follows: " + string.Join(",", newList));
				return false;
			}


		}

		public IWebElement LoadingSpinner()
		{
			//span[contains(@data-bind,"visible: dataEntry.pname() === 'undefined (undefined)'") and contains(text(),'Loading')]
			return this.containerElement.FindElement(By.XPath(@".//span[contains(text(),'Loading')]//i[contains(@class,'fa fa-spinner fa-pulse')]"), 2);
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

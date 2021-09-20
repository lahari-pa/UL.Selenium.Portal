using System.Collections.Generic;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioLegends : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-legands']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			//get the window
			StudioUtilites.SwitchToWindow("Wercs Studio");
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
			IWebElement frame =
				SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='Widget1']//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}

		public List<ProductStatus> GetProductStatuses()
		{
			var listOfProductStatuses = new List<ProductStatus>();
			ReadOnlyCollection<IWebElement> listOfProductStatusRows = this.containerElement.FindElements(By.XPath(".//table//tr[1]/td/ul/li"));
			if (listOfProductStatusRows.Count > 0)
			{
				foreach (IWebElement row in listOfProductStatusRows)
				{
					IWebElement codeSpan = row.FindElement(By.XPath("./span"));
					if (codeSpan.GetValue().Trim().Length == 0)
					{
						break;
					}
					var thisProductStatus = new ProductStatus();
					thisProductStatus.StatusName = codeSpan.GetValue();
					thisProductStatus.StatusDescription = row.GetValue();

					thisProductStatus.CSSColour = codeSpan.GetCssValue("color");

					if (thisProductStatus.CSSColour == "rgba(255, 0, 255, 1)")
					{
						thisProductStatus.ColourName = "Magenta";
					}
					if (thisProductStatus.CSSColour == "rgba(132, 3, 158, 1)")
					{
						thisProductStatus.ColourName = "Purple";
					}
					if (thisProductStatus.CSSColour == "rgba(255, 69, 0, 1)")
					{
						thisProductStatus.ColourName = "Vermillion";
					}
					if (thisProductStatus.CSSColour == "rgba(255, 0, 0, 1)")
					{
						thisProductStatus.ColourName = "Red";
					}
					if (thisProductStatus.CSSColour == "rgba(0, 0, 0, 1)")
					{
						thisProductStatus.ColourName = "Black";
					}
					if (thisProductStatus.CSSColour == "rgba(255, 104, 31, 1)")
					{
						thisProductStatus.ColourName = "Orange";
					}
					if (thisProductStatus.CSSColour == "rgba(255, 104, 31, 1)")
					{
						thisProductStatus.ColourName = "Orange";
					}
					if (thisProductStatus.CSSColour == "rgba(153, 102, 51, 1)")
					{
						thisProductStatus.ColourName = "Potters Clay";
					}
					if (thisProductStatus.CSSColour == "rgba(51, 102, 51, 1)")
					{
						thisProductStatus.ColourName = "Killarney";
					}
					if (thisProductStatus.CSSColour == "rgba(0, 170, 0, 1)")
					{
						thisProductStatus.ColourName = "Japanese Laurel";
					}
					if (thisProductStatus.CSSColour == "rgba(170, 8, 0, 1)")
					{
						thisProductStatus.ColourName = "Bright Red";
					}
					if (thisProductStatus.CSSColour == "rgba(168, 157, 2, 1)")
					{
						thisProductStatus.ColourName = "Buddha Gold";
					}
					if (thisProductStatus.CSSColour == "rgba(168, 157, 2, 1)")
					{
						thisProductStatus.ColourName = "Buddha Gold";
					}
					listOfProductStatuses.Add(thisProductStatus);
				}
			}

			return listOfProductStatuses;
		}
	}

	public class ProductStatus
	{
		public string CSSColour { get; set; }
		public string ColourName { get; set; }
		public string StatusName { get; set; }
		public string StatusDescription { get; set; }

		public bool Bold { get; set; }
		public string CSSBackgroundColor { get; set; }

	}
}

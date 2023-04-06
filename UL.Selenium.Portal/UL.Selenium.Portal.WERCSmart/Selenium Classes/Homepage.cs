using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class Homepage : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='masterContainer']";

		protected override By ContainerElementLocator => By.XPath(BasePath);



		public bool SubTestStep()
        {
			return true;
        }




		public bool QuickLinkButtonShowing(string button)
		{
			// Specific XPath used as the elements in the 'Bulk Actions' window also seem to appear in the general search...
			IList<IWebElement> mainBodyQuickLinks = this.containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2);
			IWebElement specificQuickLink = mainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(button));
			return specificQuickLink != null;
		}

		public bool ClickQuickLink(string button)
		{
			IWebElement buttonEl = this.containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2).FirstOrDefault(x => x.Text.Contains(button.Trim()));
			if (buttonEl == null)
			{
				return false;
			}

			buttonEl.Click();
			return true;
		}

		public bool QuickLinkHoveringChangeColour(string button)
		{
			IList<IWebElement> mainBodyQuickLinks = this.containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2);
			IWebElement specificQuickLink = mainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(button));
			IWebElement parentElement = specificQuickLink.FindElement(By.XPath(".."), 2);
			return parentElement.HoveringChangesColour();
		}

		public IWebElement TopGridHeader(string header) => this.containerElement.FindElement(By.XPath("./div[@id='homeHeader']//h3[contains(text(),'" + header + "')]"), 1);

		public bool TopGridHeaderPresent(string header)
		{
			IList<IWebElement> headers = this.containerElement.FindElements(By.XPath(".//div[@id='homeHeader']//h3"), 2);
			return headers.FirstOrDefault(x => x.Text.Trim().Contains(header.Trim())) != null;
		}

		public bool TopGridMoreOptionShowing(string header)
		{
			return this.containerElement.FindElement(By.XPath(".//h3[@class='sr-only' and contains(text(),'" + header + "')]/..//a[contains(@class,'small-link')]"), 2) != null;
		}

		public bool ClickMoreForPanel(string panel)
		{
			try
			{
				IWebElement button = this.containerElement.FindElement(By.XPath(".//h3[@class='sr-only' and contains(text(),'" + panel + "')]/..//a[contains(@class,'small-link')]"), 2);
				button.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool NotificationsExistInPanel(string panel)
		{
			IWebElement alertsPanel = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'" + panel + "')]/.."), 2);
			IList<IWebElement> rows = alertsPanel.FindElements(By.XPath(".//table//tr"), 2);
			return (rows.Count != 0);
		}

		public bool ClickOnFirst(string panel)
		{
			try
			{
				IWebElement panelContainer = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'" + panel + "')]/.."), 2);
				IList<IWebElement> rows = panelContainer.FindElements(By.XPath(".//table//tr"), 2);
				rows.FirstOrDefault().Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public string GetAllAlertsAndGetAlertWithTextXAndReturnID(string alertMessage)
		{
			IWebElement panelContainer = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'Alert')]/.."), 2);
			IList<IWebElement> rows = panelContainer.FindElements(By.XPath(".//table//tr"), 2);
			foreach(var item in rows)
			{
				IWebElement AlertMessageBox = item.FindElement(By.XPath(".//td[3]"), 2);
				if (AlertMessageBox.Text==alertMessage)
				{
					string actualAlertID = item.FindElement(By.XPath(".//td[1]"), 2).Text;
					return actualAlertID;
				}
			}
			Report.Failure("Alert with message: " + alertMessage + " could not be found");
			return null;
		}
		

		public bool ClickArrowNextToProductInformation(bool expand)
		{
			try
			{
				IWebElement element = this.containerElement.FindElement(By.XPath("./div[@id='homeHeader']//a[contains(@class,'collapse-control')]"), 2);
				bool expanded = element.GetAttribute("aria-expanded") == null || Convert.ToBoolean(element.GetAttribute("aria-expanded"));
				return expanded == expand || element.TryClick();
			}
			catch (Exception ex)
			{
				Report.Info("Exception: " + ex.Message);
				return false;
			}

		}

		public bool PieChartShowingInProductInformation()
		{
			IWebElement pieChart = this.containerElement.FindElement(By.XPath(".//div[@id='products-information']"), 2);
			return pieChart != null && pieChart.Displayed;
		}

		public bool PieChartLegendShowingInProductInformation()
		{
			IWebElement pieChartLegend = this.containerElement.FindElement(By.XPath(".//div[@id='products-information']//ul[@class='status-list']"), 2);
			return pieChartLegend != null && pieChartLegend.Displayed;
		}

		public int PieChartProductsTotal()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//div[@id='total-products']"), 2);
			if (el == null)
			{
				return -1;
			}
			return Convert.ToInt16(el.Text);
		}

		public List<string> PieChartLegendItems()
		{
			return this.containerElement.FindElements(By.XPath(".//ul[@class='status-list']//li/span"), 2).Select(x => x.GetElementText().Trim()).ToList();
		}

		public bool EntryShowingInPieChartLegend(string text, string colour)
		{
			IWebElement pieChartLegend = this.containerElement.FindElement(By.XPath(".//div[@id='products-information']//ul[@class='status-list']"), 2);
			IList<IWebElement> legendEntry = pieChartLegend.FindElements(By.XPath(".//span[text()='" + text + "']"), 2);
			if (legendEntry.FirstOrDefault() == null)
			{
				return false;
			}
			// Element exists, so now we need to check the colour
			string colourShowingRaw = legendEntry.FirstOrDefault().FindElement(By.XPath("../div"), 2).GetCssValue("background-color");

			string colourShowing = "";
			switch (colourShowingRaw)
			{
				case ("rgba(239, 157, 14, 1)"):
					colourShowing = "Yellow";
					break;
				case ("rgba(0, 152, 255, 1)"):
					colourShowing = "Blue";
					break;
				case ("rgba(30, 143, 31, 1)"):
					colourShowing = "Green";
					break;
				case ("rgba(75, 82, 87, 1)"):
					colourShowing = "Grey";
					break;
				case ("rgba(207, 58, 83, 1)"):
					colourShowing = "Red";
					break;
			}

			return colourShowing == colour;
		}

		public bool ProductInformationSectionVisible()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@id='products-information']"), 2).Displayed;
			//return Convert.ToBoolean(containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']"), 2).GetAttribute("aria-expanded"));
		}

		public bool AlertsSectionVisible()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']//h3[contains(text(),'Alerts')]/../div"), 2).Displayed;
			//return Convert.ToBoolean(containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']"), 2).GetAttribute("aria-expanded"));
		}

		public bool AnnouncementsSectionVisible()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']//h3[contains(text(),'Announcements')]/../div"), 2).Displayed;
			//return Convert.ToBoolean(containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']"), 2).GetAttribute("aria-expanded"));
		}
		public string FooterText()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//footer/p"), 2).Text;
		}

		public bool ClickTermsOfUse()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//footer/p/a"), 2).TryClick();
		}

		public List<string> GetAnnouncements()
		{
			return this.containerElement
				.FindElements(
					By.XPath(
						".//div[@id='at-a-glance']//h3[contains(text(),'Announcements')]/../div//table//tr/td/span"), 2)
				.Select(x => x.Text).ToList();

		}

		public int GetAnnouncementCount()
		{
			try
			{
				string AnnouncementCount = this.containerElement
					.FindElement(By.XPath(".//div[@id='at-a-glance']//h3[contains(text(),'Announcements')]/span")).GetValue();
				Report.Info("Got announcement count: " + AnnouncementCount);
				return Convert.ToInt16(AnnouncementCount);
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return -1;
			}

		}

		public bool ClickResolveButton()
		{
			IWebElement ResolveButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='panel panel-default messaging']//p[contains(text(), 'AGHS document')]/../../following-sibling::td//a[text()='Resolve ']"), 2);
			return ResolveButton.TryClick();
		}

		public bool AlertsButtonIsDisplayed(string button, string alert)
		{
			IWebElement AlertButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='panel panel-default messaging']//p[contains(text(), '" + alert + "')]/../../following-sibling::td//a[starts-with(text(), '" + button + "')]"), 2);
			return AlertButton.Displayed;
		}
		//public bool DataConsentPopupPresent()
		//{

		//}

	}



	class HomePageHeader : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='page-inner-header home-header affix']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool QuickLinkButtonShowing(string button)
		{
			IList<IWebElement> mainBodyQuickLinks = this.containerElement.FindElements(By.XPath("//a"), 2);
			IWebElement specificQuickLink = mainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(button));
			return specificQuickLink != null;
		}
	}

	/// <summary>
	/// Shoppimg Cart - Cart is Empty dialog
	/// </summary>
	class CartIsEmptyDialog : SeleniumBaseObject
	{
		public const string BasePath = "//h4[@id='myModalLabel']/../..";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		/// <summary>
		/// this is the title of the dialog Cart is Empty
		/// </summary>
		/// <returns></returns>
		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//h4[@id='myModalLabel']"), 2).Text.Trim();
		}

		/// <summary>
		/// clicks the close button
		/// </summary>
		public void ClickClose()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Close']"), 2).Click();
		}

	}
}

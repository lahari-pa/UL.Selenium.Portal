using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class Homepage : BaseObject
	{
		public const string BasePath = "//div[@id='masterContainer']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool QuickLinkButtonShowing(string button)
		{
			// Specific XPath used as the elements in the 'Bulk Actions' window also seem to appear in the general search...
			var mainBodyQuickLinks = this.containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2);
			var specificQuickLink = mainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(button));
			return specificQuickLink != null;
		}

		public bool ClickQuickLink(string button)
		{
			var buttonEl = this.containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2).FirstOrDefault(x => x.Text.Contains(button.Trim()));
			if (buttonEl == null)
			{
				return false;
			}

			buttonEl.Click();
			return true;
		}

		public bool QuickLinkHoveringChangeColour(string button)
		{
			var mainBodyQuickLinks = this.containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2);
			var specificQuickLink = mainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(button));
			var parentElement = specificQuickLink.FindElement(By.XPath(".."), 2);
			return parentElement.HoveringChangesColour();
		}

		public bool TopGridHeaderPresent(string header)
		{
			var headers = this.containerElement.FindElements(By.XPath(".//div[@id='homeHeader']//h3"), 2);
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
				var button = this.containerElement.FindElement(By.XPath(".//h3[@class='sr-only' and contains(text(),'" + panel + "')]/..//a[contains(@class,'small-link')]"), 2);
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
			var alertsPanel = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'" + panel + "')]/.."), 2);
			var rows = alertsPanel.FindElements(By.XPath(".//table//tr"), 2);
			return (rows.Count != 0);
		}

		public bool ClickOnFirst(string panel)
		{
			try
			{
				var panelContainer = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'" + panel + "')]/.."), 2);
				var rows = panelContainer.FindElements(By.XPath(".//table//tr"), 2);
				rows.FirstOrDefault().Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public void ClickArrowNextToProductInformation(bool expand)
		{
			var element = this.containerElement.FindElement(By.XPath(".//a[contains(@class,'collapse-control') and @href='#at-a-glance']"), 2);
			var expanded = element.GetAttribute("aria-expanded") == null ? true : Convert.ToBoolean(element.GetAttribute("aria-expanded"));
			if (!expanded && expand || (expanded && !expand))
			{
				element.Click();
			}
		}

		public bool PieChartShowingInProductInformation()
		{
			var pieChart = this.containerElement.FindElement(By.XPath(".//div[@id='products-information']//*[contains(@class,'highcharts-pie-series') and contains(@class,'highcharts-tracker')]"), 2);
			return pieChart != null;
		}

		public bool PieChartLegendShowingInProductInformation()
		{
			var pieChartLegend = this.containerElement.FindElement(By.XPath(".//div[@id='products-information']//ul[@class='status-list']"), 2);
			return pieChartLegend != null;
		}

		public bool EntryShowingInPieChartLegend(string text, string colour)
		{
			var pieChartLegend = this.containerElement.FindElement(By.XPath(".//div[@id='products-information']//ul[@class='status-list']"), 2);
			var legendEntry = pieChartLegend.FindElements(By.XPath(".//span[text()='" + text + "']"), 2);
			if (legendEntry.FirstOrDefault() == null)
			{
				return false;
			}
			// Element exists, so now we need to check the colour
			var colourShowingRaw = legendEntry.FirstOrDefault().FindElement(By.XPath("../div"), 2).GetCssValue("background-color");

			var colourShowing = "";
			switch (colourShowingRaw)
			{
				case ("rgba(237, 185, 46, 1)"):
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
	}

	class NavigationBar : BaseObject
	{
		public const string BasePath = "//nav[@role='navigation']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool NavigationIconShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2) != null;
		}

		public bool NavigationIconClick(bool expand = true)
		{
			try
			{
				var element = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2);
				var elementClosed = !element.GetAttribute("class").Contains("closed");
				if (elementClosed && expand || !elementClosed && !expand)
				{
					element.Click();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool ItemShowingInNavigationPanel(string item, bool iconOnly = false)
		{
			var sideIcons = this.containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a"), 2);
			var iconPresent = sideIcons.FirstOrDefault(x => x.GetAttribute("title").Contains(item));
			if (iconPresent == null || !iconPresent.Displayed)
			{
				return false;
			}

			// Icon is present!

			if (this.containerElement.FindElement(By.XPath(".//div[contains(@class,'sidemenu-links')]"), 2).GetAttribute("class").Contains("closed"))
			{
				// Navigation Panel is not expanded!
				return iconOnly;
			}

			var expandedIcons = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'sidemenu-links')]//a"), 2);

			var expandedOption = expandedIcons.FirstOrDefault(x => x.Text.Contains(item));

			return (expandedOption != null && expandedOption.Displayed);
		}

		public bool Click_Icon(string destination)
		{
			var allIcons = this.containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a//span"), 2);
			var icon = allIcons.FirstOrDefault(x => x.Text.Trim().Contains(destination));
			if (icon == null)
			{
				return false;
			}

			icon.FindElement(By.XPath(".."), 2).Click();
			GeneralUtilities.Wait_for_load_finish();
			return true;
		}
	}

	class InactivityPopup : BaseObject
	{
		public const string BasePath = "//div[@id='LogOutModal']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool IsVisible()
		{
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return this.containerElement.GetAttribute("class") != "modal fade";
		}

		public bool ClickYes()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//button[text()='Yes']"));
			if (btn == null)
			{
				return false;
			}

			try
			{
				btn.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickNo()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[text()='No']"));
			if (btn == null)
			{
				return false;
			}

			try
			{
				btn.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}


	}
	class HomePageHeader : BaseObject
	{
		public const string BasePath = "//div[@class='page-inner-header home-header affix']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool QuickLinkButtonShowing(string button)
		{
			var mainBodyQuickLinks = this.containerElement.FindElements(By.XPath("//a"), 2);
			var specificQuickLink = mainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(button));
			return specificQuickLink != null;
		}
	}
}

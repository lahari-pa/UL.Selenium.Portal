using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class Homepage : BaseObject
    {
        public const string BasePath = "//div[@id='masterContainer']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public bool QuickLinkButtonShowing(string Button)
        {
            // Specific XPath used as the elements in the 'Bulk Actions' window also seem to appear in the general search...
            var MainBodyQuickLinks = containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2);
            var SpecificQuickLink = MainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(Button));
            return SpecificQuickLink != null;
        }

        public bool ClickQuickLink(string Button)
        {
            var ButtonEL = containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2).FirstOrDefault(x=>x.Text.Contains(Button.Trim()));
            if (ButtonEL == null)
                return false;
            ButtonEL.Click();
            return true;
        }

        public bool QuickLinkHoveringChangeColour(string Button)
        {
            var MainBodyQuickLinks = containerElement.FindElements(By.XPath("./div/div[not(@id='products-grid')]//a/div[@class='btn-text']"), 2);
            var SpecificQuickLink = MainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(Button));
            var ParentElement = SpecificQuickLink.FindElement(By.XPath(".."), 2);
            return ParentElement.HoveringChangesColour();
        }

        public bool TopGridHeaderPresent(string Header)
        {
            var Headers = containerElement.FindElements(By.XPath(".//div[@class='row collapse-headings']//h3"), 2);
            return Headers.FirstOrDefault(x => x.Text.Trim().Contains(Header.Trim())) != null;
        }

        public bool TopGridMoreOptionShowing(string Header)
        {
            return containerElement.FindElement(By.XPath(".//h3[@class='sr-only' and contains(text(),'" + Header + "')]/..//a[contains(@class,'small-link')]"), 2) != null;
        }

        public bool ClickMoreForPanel(string Panel)
        {
            try
            {
                var Button = containerElement.FindElement(By.XPath(".//h3[@class='sr-only' and contains(text(),'" + Panel + "')]/..//a[contains(@class,'small-link')]"), 2);
                Button.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool NotificationsExistInPanel(string Panel)
        {
            var AlertsPanel = containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'" + Panel + "')]/.."), 2);
            var Rows = AlertsPanel.FindElements(By.XPath(".//table//tr"), 2);
            return(Rows.Count != 0);
        }

        public bool ClickOnFirst(string Panel)
        {
            try
            {
                var PanelContainer = containerElement.FindElement(By.XPath(".//div[contains(@class,'status-panels')]//h3[contains(text(),'" + Panel + "')]/.."), 2);
                var Rows = PanelContainer.FindElements(By.XPath(".//table//tr"), 2);
                Rows.FirstOrDefault().Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void ClickRedArrowNextToProductInformation(bool expand)
        {
            var Element = containerElement.FindElement(By.XPath(".//a[contains(@class,'collapse-panels') and @href='#at-a-glance']"), 2);
            var Expanded = Element.GetAttribute("aria-expanded")==null?true: Convert.ToBoolean(Element.GetAttribute("aria-expanded"));
            if (!Expanded && expand || (Expanded && !expand))
                Element.Click();
        }

        public bool PieChartShowingInProductInformation()
        {
            var PieChart = containerElement.FindElement(By.XPath(".//div[@id='products-information']//*[contains(@class,'highcharts-pie-series') and contains(@class,'highcharts-tracker')]"), 2);
            return PieChart != null;
        }

        public bool PieChartLegendShowingInProductInformation()
        {
            var PieChartLegend = containerElement.FindElement(By.XPath(".//div[@id='products-information']//ul[@class='status-list']"), 2);
            return PieChartLegend != null;
        }

        public bool EntryShowingInPieChartLegend(string Text, string Colour)
        {
            var PieChartLegend = containerElement.FindElement(By.XPath(".//div[@id='products-information']//ul[@class='status-list']"), 2);
            var LegendEntry = PieChartLegend.FindElements(By.XPath(".//span[text()='" + Text + "']"), 2);
            if (LegendEntry.FirstOrDefault() == null)
                return false;
            // Element exists, so now we need to check the colour
            var ColourShowingRaw = LegendEntry.FirstOrDefault().FindElement(By.XPath("../div"), 2).GetCssValue("background-color");

            var ColourShowing = "";
            switch (ColourShowingRaw)
            {
                case ("rgba(237, 185, 46, 1)"):
                    ColourShowing = "Yellow";
                    break;
                case ("rgba(0, 152, 255, 1)"):
                    ColourShowing = "Blue";
                    break;
                case ("rgba(30, 143, 31, 1)"):
                    ColourShowing = "Green";
                    break;
                case ("rgba(75, 82, 87, 1)"):
                    ColourShowing = "Grey";
                    break;
                case ("rgba(207, 58, 83, 1)"):
                    ColourShowing = "Red";
                    break;
            }

            return ColourShowing==Colour;
        }

        public bool ProductInformationSectionVisible()
        {
            return containerElement.FindElement(By.XPath(".//div[@id='products-information']"), 2).Displayed;
            //return Convert.ToBoolean(containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']"), 2).GetAttribute("aria-expanded"));
        }

        public bool AlertsSectionVisible()
        {
            return containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']//h3[contains(text(),'Alerts')]/../div"), 2).Displayed;
            //return Convert.ToBoolean(containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']"), 2).GetAttribute("aria-expanded"));
        }

        public bool AnnouncementsSectionVisible()
        {
            return containerElement.FindElement(By.XPath(".//div[@id='at-a-glance']//h3[contains(text(),'Announcements')]/../div"), 2).Displayed;
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
            return containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2) != null;
        }

        public bool NavigationIconClick(bool expand = true)
        {
            try
            {
                var element = containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2);
                var elementClosed =  !element.GetAttribute("class").Contains("closed");
                if (elementClosed && expand || !elementClosed && !expand)
                    element.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ItemShowingInNavigationPanel(string item, bool IconOnly = false)
        {
            var SideIcons = containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a"), 2);
            var IconPresent = SideIcons.FirstOrDefault(x => x.GetAttribute("title").Contains(item));
            if (IconPresent == null || !IconPresent.Displayed)
                return false;

            // Icon is present!

            if (containerElement.FindElement(By.XPath(".//div[contains(@class,'sidemenu-links')]"), 2).GetAttribute("class").Contains("closed"))
            {
                // Navigation Panel is not expanded!
                return IconOnly;
            }

            var ExpandedIcons = containerElement.FindElements(By.XPath(".//div[contains(@class,'sidemenu-links')]//a"), 2);

            var ExpandedOption = ExpandedIcons.FirstOrDefault(x => x.Text.Contains(item));

            return (ExpandedOption != null && ExpandedOption.Displayed);
        }

        public bool Click_Icon(string Destination)
        {
            var AllIcons = containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a//span"), 2);
            var Icon = AllIcons.FirstOrDefault(x => x.Text.Trim().Contains(Destination));
            if (Icon == null)
                return false;
            Icon.FindElement(By.XPath(".."),2).Click();
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
			return containerElement.GetAttribute("class") != "modal fade";
		}

		public bool ClickYes()
		{
			var Btn = containerElement.FindElement(By.XPath(".//button[text()='Yes']"));
			if (Btn == null)
				return false;
			try
			{
				Btn.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickNo()
		{
			var Btn = containerElement.FindElement(By.XPath(".//a[text()='No']"));
			if (Btn == null)
				return false;
			try
			{
				Btn.Click();
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

        public bool QuickLinkButtonShowing(string Button)
        {
            var MainBodyQuickLinks = containerElement.FindElements(By.XPath("//a"), 2);
            var SpecificQuickLink = MainBodyQuickLinks.FirstOrDefault(x => x.Text.Contains(Button));
            return SpecificQuickLink != null;
        }
    }
}

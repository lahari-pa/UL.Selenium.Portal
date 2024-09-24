using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class NavBar : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//ul[@class='nav subheader fixed-top shadow-sm' or @class='nav navbar-nav']");

        //Tab Links
        private IWebElement HomeLink => ContainerElement.FindElement(By.Id("home-link"), 1);

        private IWebElement ProgramHealthLink => ContainerElement.FindElement(By.Id("programhealth-link"), 1);

        private IWebElement DashboardLink => ContainerElement.FindElement(By.Id("dashboard-link"), 1);

        private IWebElement RecentActivitiesLink => ContainerElement.FindElement(By.Id("statuscheck-link"), 1);

        private IWebElement WebViewersLink => ContainerElement.FindElement(By.Id("webviewer-link"), 1);

        private IWebElement ProductLookupsLink => ContainerElement.FindElement(By.Id("productlookup-link"), 1);

        private IWebElement HelpAndSupportLink => ContainerElement.FindElement(By.Id("freshdesk-link"), 1);

        private IWebElement ItemSyncLink => ContainerElement.FindElement(By.Id("ItemSyncMenu"), 1);

        private IWebElement DrumLogLink => ContainerElement.FindElement(By.Id("drumlog-link"), 1);

        //-------------------------------------------------------------------------//

        //Sub Tab Links
        private IWebElement DemoViewerLink => ContainerElement.FindElement(By.XPath($"//ul[@class='dropdown-menu']//li//a[text()='Demo Viewer']"), 2);

        private IWebElement DemoStatusLink => ContainerElement.FindElement(By.XPath($"//ul[@class='dropdown-menu']//li//a[text()='Demo Status']"), 2);

        private IWebElement ManualEntryLink => ContainerElement.FindElement(By.XPath($"//ul[@class='dropdown-menu']//li//a[text()='Manual Entry']"), 2);

        private IWebElement UploadAFileLink => ContainerElement.FindElement(By.XPath($"//ul[@class='dropdown-menu']//li//a[text()='Upload a File']"), 2);

        private IWebElement WebViewerLink(string text) => WebViewersLink.FindElement(By.XPath($".//a[contains(text(), '{text}')]"), 2);

        private IWebElement ItemSyncSubLink(string tabText) => ItemSyncLink.FindElement(By.XPath($".//div[contains(@class, 'dropdown-menu']//a[text()='{tabText}']"), 2);


        #endregion

        #region Methods

        public bool TabIsActive(string tabName)
        {
            string thisClass;
            switch (tabName.ToLower())
            {
                case "home":
                    thisClass = HomeLink.ClassAttribute();
                    break;
                case "program health":
                    thisClass = ProgramHealthLink.ClassAttribute();
                    break;

                case "dashboard":
                    thisClass = DashboardLink.ClassAttribute();
                    break;
                case "recent activities":
                    thisClass = RecentActivitiesLink.ClassAttribute();
                    break;
                case "web viewers":
                    thisClass = WebViewersLink.ClassAttribute();
                    break;
                case "itemsync":
                    thisClass = ItemSyncLink.ClassAttribute();
                    break;
                case "product lookup":
                    thisClass = ProductLookupsLink.ClassAttribute();
                    break;
                case "help & support":
                    thisClass = HelpAndSupportLink.ClassAttribute();
                    break;
                case "drum log":
                    thisClass = DrumLogLink.ClassAttribute();
                    break;
                default:
                    Report.Error("tabName parameter did not match any expected case");
                    return false;
            }
            return !thisClass.IsNullOrEmpty() && thisClass.Contains("active");
        }

        public bool ClickAcceptAllCookies()
        {
            IWebElement acceptAllCookies = this.FindElement(By.XPath($"//div[@id ='truste-consent-track']//div[@id ='truste-consent-buttons']//button[text() = 'Accept All Cookies']"), 2);
            return acceptAllCookies.TryClick();
        }
        public bool ClickTab(string tabName)
        {
            switch (tabName.ToLower())
            {
                case "program health":
                    return ProgramHealthLink.TryClick();
                case "dashboard":
                    return DashboardLink.TryClick();
                case "recent activities":
                    return RecentActivitiesLink.TryClick();
                case "web viewers":
                    return WebViewersLink.TryClick();
                case "itemsync":
                    return ItemSyncLink.TryClick(); ;
                case "product lookup":
                    return ProductLookupsLink.TryClick();
                case "help & support":
                    return HelpAndSupportLink.TryClick();
                case "drum log":
                    return DrumLogLink.TryClick();
                default:
                    Report.Error("tabName parameter did not match any expected case");
                    return false;
            }
        }

        public bool ClickSubTab(string tabName)
        {
            if (LinkDropDownOpen("Web Viewers"))
            {
                return WebViewerLink(tabName).TryClick();
            }
            else if (LinkDropDownOpen("ItemSync"))
            {
                return ItemSyncSubLink(tabName).TryClick();
            }
            else
            {
                Report.Error("tabName parameter did not match any expected case");
                return false;
            }
        }



        public List<string> LinkTitles() => ContainerElement.FindElements(By.XPath(".//li//a"), 1).Select(x => x.Text).ToList();

        public List<string> LinkSubTitles(string mainTitle)
        {
            List<IWebElement> dropDownEls = ContainerElement.FindElements(By.XPath(".//a[contains(@class, 'dropdown-toggle')]"), 4).ToList();
            IWebElement wantedEl = dropDownEls.First(x => x.Text == mainTitle);
            List<IWebElement> subTitleEls = wantedEl.FindElements(By.XPath($".//following-sibling::ul//li"), 4).ToList();
            List<string> subTitlesStr = subTitleEls.Select(x => x.Text).ToList();
            return subTitlesStr;

        }

        public bool LinkDropDownOpen(string mainTitle)
        {
            List<IWebElement> dropDownEls = ContainerElement.FindElements(By.XPath(".//a[contains(@class, 'dropdown-toggle')]"), 4).ToList();
            IWebElement wantedEl = dropDownEls.First(x => x.Text == mainTitle);
            string attr = wantedEl.GetAttribute("aria-expanded");
            return attr == "true";


        }

        public bool LinkDropDownClosed(string mainTitle)
        {
            List<IWebElement> dropDownEls = ContainerElement.FindElements(By.XPath(".//a[contains(@class, 'dropdown-toggle')]"), 4).ToList();
            IWebElement wantedEl = dropDownEls.First(x => x.Text == mainTitle);
            string attr = wantedEl.GetAttribute("aria-expanded");
            return attr == "false";


        }

        public bool CheckTabIsGrey(string tabName)
        {
            List<IWebElement> listOfTabEls = ContainerElement.FindElements(By.XPath($"//li[@id]"), 2).ToList();
            var wantedEl = listOfTabEls.First(x => x.Text == tabName);
            string rbgaCssValue = wantedEl.GetCssValue("background-color");
            return rbgaCssValue == "rgba(229, 232, 236, 1)";
        }

        public bool CheckUnderlineBelowtext(string tabName)
        {
            List<IWebElement> listOfTabEls = ContainerElement.FindElements(By.XPath($"//li[@id]"), 2).ToList();
            var wantedEl = listOfTabEls.First(x => x.Text == tabName);
            string rbgaCssValue = wantedEl.GetCssValue("border-bottom-color");
            return rbgaCssValue == "rgba(91, 4, 40, 1)";
        }

        public bool CheckTabIsWhite(string tabName)
        {
            List<IWebElement> listOfTabEls = ContainerElement.FindElements(By.XPath($"//li[@id]"), 2).ToList();
            var wantedEl = listOfTabEls.First(x => x.Text == tabName);
            string rbgaCssValue = wantedEl.GetCssValue("background-color");
            return rbgaCssValue == "rgba(0, 0, 0, 0)";
        }

        public bool CheckAllTabsExeptXAreNotGrey(string expectTabName)
        {
            List<IWebElement> listOfTabEls = ContainerElement.FindElements(By.XPath($"//li[@id]"), 2).ToList();
            List<IWebElement> editedTabEls = new List<IWebElement>();
            foreach (var el in listOfTabEls)
            {
                if (el.Text != expectTabName)
                {
                    editedTabEls.Add(el);
                }
            }

            bool tabNotGrey = true;

            foreach (var tab in editedTabEls)
            {
                string rbgaCssValue = tab.GetCssValue("background-color");
                if (rbgaCssValue == "rgba(229, 232, 236, 1)")
                {
                    Report.Info($"The tab with title: {tab.Text} was grey");
                    tabNotGrey = false;

                }
                else
                {
                    Report.Info($"The tab with title: {tab.Text} was not grey");


                }
            }

            return tabNotGrey;
        }

        public bool InProductLookupConfirmTableBackgroundColorGrey()
        {
            IWebElement background = this.FindElement(By.XPath($"//div[@class='body-container']"), 2);
            Report.Info(background.GetCssValue("color"));
            return background.GetCssValue("color") == "rgba(115, 135, 156, 1)";
        }

        public bool InProductLookupConfirmFilterButtonNextToSearchBox()
        {
            IWebElement filterButton = this.FindElement(By.XPath($"//input[@data-bind='textInput: searchText']/following-sibling::div//button[@data-bind='click: filters']"), 2);
            return filterButton != null;
        }

        public bool InProductLookupConfirmSearchBoxIsShown()
        {
            IWebElement searchBox = this.FindElement(By.XPath($"//input[@data-bind='textInput: searchText']"), 2);
            return searchBox != null;
        }

        public bool InProductLookupConfirmFooterIsBelowTable()
        {
            IWebElement footer = this.FindElement(By.XPath($"//div[@id='supertable_main']/following-sibling::div[@class='webviewerfooter clearfix']"), 2);
            return footer != null;
        }

        public bool ConfirmProductGridHasFollowingColumns(Table table)
        {
            foreach (var row in table.Rows)
            {
                var columnName = row["Column"];
                IWebElement columnEl = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-hbox']//th//span[text()='{columnName}']"), 5);
                if (columnEl == null)
                {
                    return false;
                }
            }

            return true;
        }
        public bool ConfirmProductGridProductInfoHasFollowingData(Table table)
        {
            IWebElement productName = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[@role='row']//td[@role='gridcell']//span[@class='title']"), 5);
            IList<IWebElement> productInfoData = this.FindElements(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[@role='row']//td[@role='gridcell']//span"), 5).ToList();
            productInfoData.Add(productName);

            if (productName == null)
            {
                return false;
            }

            bool UPCFound = false;
            bool WPSIDFound = false;
            bool supplierFound = false;

            foreach (IWebElement el in productInfoData)
            {
                if (el.Text.Contains("UPC "))
                {
                    UPCFound = true;
                }
                if (el.Text.Contains("WPSID "))
                {
                    WPSIDFound = true;
                }
                if (el.Text.Contains("The WERCS LTD") || el.Text.Contains("This company uses SRS") || el.Text.Contains("QA Squad"))
                {
                    supplierFound = true;
                }
            }

            if (UPCFound == false)
            {
                Report.Failure("UPC not found");
            }
            if (WPSIDFound == false)
            {
                Report.Failure("WPSID not found");
            }
            if (supplierFound == false)
            {
                Report.Failure("Supplier not found");
            }

            return UPCFound == true && WPSIDFound == true && supplierFound == true;

        }
        public bool ConfirmProuctGridProductInfoColumnFieldHasFont(string fieldName, string fontColor, string fontWeight)
        {
            IWebElement fieldAndFontEl = null;
            string expectedFontColor = "";
            string expectedFontWeight = "";

            if (fieldName == "Product Name")
            {
                fieldAndFontEl = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[@role='row'][2]//td[@role='gridcell']//span[@class='title']"), 5);
            }
            else if (fieldName == "UPC")
            {
                fieldAndFontEl = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[@role='row'][2]//td[@role='gridcell']//span[1]"), 5);
            }
            else if (fieldName == "WPS ID")
            {
                fieldAndFontEl = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[@role='row'][2]//td[@role='gridcell']//span[2]"), 5);
            }
            else if (fieldName == "Supplier Name")
            {
                fieldAndFontEl = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[@role='row'][2]//td[@role='gridcell']//span[3]"), 5);
            }
            else if (fieldName == "Actions")
            {
                fieldAndFontEl = this.FindElement(By.XPath($"//div[@class='ui-jqgrid-bdiv']//tr[2]//td[@aria-describedby='dataGrid_ACTIONS'][1]"), 5);
            }

            if (fontColor == "dark blue")
            {
                expectedFontColor = "rgba(0, 43, 69, 1)";
            }
            else if (fontColor == "black")
            {
                expectedFontColor = "rgba(0, 0, 0, 1)"; //"rgb(115, 135, 156)";
            }
            else if (fontColor == "light blue")
            {
                expectedFontColor = "rgba(33, 37, 41, 1)";
            }

            if (fontWeight == "bold")
            {
                expectedFontWeight = "500";
            }
            else if (fontWeight == "normal")
            {
                expectedFontWeight = "400";
            }

            if (fieldAndFontEl == null)
            {
                Report.Failure("Field was not found");
            }
            if (fieldAndFontEl.GetCssValue("color") != expectedFontColor)
            {
                Report.Failure("Expected font color was not found");
            }
            if (fieldAndFontEl.GetCssValue("font-weight") != expectedFontWeight)
            {
                Report.Failure("Expected font weight was not found");
            }
            Report.Info(fieldAndFontEl.GetCssValue("color"));
            Report.Info(fieldAndFontEl.GetCssValue("font-weight"));
            return fieldAndFontEl != null && fieldAndFontEl.GetCssValue("color") == expectedFontColor && fieldAndFontEl.GetCssValue("font-weight") == expectedFontWeight;
        }

        public bool ConfirmMenuLinksBanner()
        {
            List<IWebElement> menuLinks = ContainerElement.FindElements(By.XPath($"//li"), 5).ToList();
            return menuLinks.Any();
        }

        public bool ConfirmRowsPerPageSelectorInFooterArea()
        {
            IWebElement rowsPerPageEl = this.FindElement(By.XPath($"//table[@class='table table-bordered supertable']//div[@class='ml-2']//select[@title='Pages per row']"), 5);
            return rowsPerPageEl != null;
        }
        public bool ConfirmNavigationControlsInFooterArea()
        {
            IWebElement navigationControls = this.FindElement(By.XPath($"//table[@class='table table-bordered supertable']//div[@class='col-6']//div[@class='input-group justify-content-center']"), 5);
            return navigationControls != null;
        }
        public bool ConfirmPageNumberInFooterArea()
        {
            IWebElement pageNumber = this.FindElement(By.XPath($"//table[@class='table table-bordered supertable']//div[@class='mr-2 pt-2 float-right']"), 5);
            return pageNumber.Text.Contains("View") && pageNumber.Text.Contains(" - ") && pageNumber.Text.Contains("of");
        }
        public bool InStatusWebViewersConfirmSearchBoxIsShown()
        {
            IWebElement searchBox = this.FindElement(By.XPath($"//input[contains(@data-bind,'textInput: searchText')]"), 2);
            return searchBox != null;
        }

        public bool InStatusWebViewersConfirmBackgroundColorGrey()
        {
            IWebElement background = this.FindElement(By.XPath($"//div[@class='body-container']"), 2);
            Report.Info(background.GetCssValue("color"));
            return background.GetCssValue("color") == "rgba(0, 0, 0, 1)";
        }

        public bool InStatusWebViewersConfirmSearchBoxDisplaysFollowingPlaceholder(string placeholder)
        {
            IWebElement searchBox = this.FindElement(By.XPath($"//input[contains(@data-bind,'textInput: searchText')][@placeholder='" + placeholder + "']"), 2);
            return searchBox != null;
        }

        public bool InStatusWebViewersConfirmFilterButtonNextToSearchBox()
        {
            IWebElement filterButton = this.FindElement(By.XPath($"//div[@class='col']//button[contains(@data-bind,'click: filters')]"), 2);
            return filterButton != null;
        }

        public bool InStatusWebViewersConfirmResetButtonNextToSearchBox()
        {
            IWebElement resetButton = this.FindElement(By.XPath($"//div[@class='col']//button[contains(@data-bind,'click: reset')]"), 2);
            return resetButton != null;
        }

        public bool InStatusWebViewersConfirmTheFollowingTrendsAreDisplayed(Table table)
        {
            IWebElement card = this.FindElement(By.XPath($"//div[contains(@class,'card')]"), 2);
            foreach (var row in table.Rows)
            {
                IWebElement cardText = card.FindElement(By.XPath($"//h6[text()='{row}']"), 2);
                return true;
            }
            return false;
        }

        public bool InStatusWebViewersConfirmTableRowsBelowTrends()
        {
            IWebElement tableRows = this.FindElement(By.XPath($"//div[@class='stats-cards card-deck mt-2']/../../following-sibling::div"), 2);
            return tableRows != null;
        }
        public bool InProductLookupConfirmResetButtonNextToSearchBox()
        {
            IWebElement resetButton = this.FindElement(By.XPath($"//input[@data-bind='textInput: searchText']/following-sibling::div/following-sibling::button[@data-bind='click: reset']"), 2);
            return resetButton != null;
        }

        public bool InProductLookupConfirmSelectColumnsButtonNextToSearchBox()
        {
            IWebElement selectColumns = this.FindElement(By.XPath($"//input[@data-bind='textInput: searchText']/following-sibling::div/following-sibling::button[@data-bind='click: selectCols']"), 2);
            return selectColumns != null;
        }

        public bool InProductLookupConfirmExportButtonNextToSearchBox()
        {
            IWebElement exportButton = this.FindElement(By.XPath($"//input[@data-bind='textInput: searchText']/following-sibling::div/following-sibling::a[@data-bind='click: exportToExcel']"), 2);
            return exportButton != null;
        }

        public bool InProductLookupConfirmTheFollowingTrendsAreDisplayed(Table table)
        {
            IWebElement card = this.FindElement(By.XPath($"//div[contains(@class,'card-body')]"), 2);
            foreach (var row in table.Rows)
            {
                IWebElement cardText = card.FindElement(By.XPath($"//h6[text()='" + row["Trend"] + "']"), 2);
                if (cardText == null)
                {
                    Report.Info("test - " + row["Trend"]);
                    return false;
                }
            }
            return true;
        }

        public bool InProductLookupConfirmTableHasRows()
        {
           IList<IWebElement> tableRows = this.FindElements(By.XPath($"//div[@id='gbox_dataGrid']//table[@class='ui-jqgrid-btable ui-common-table'][@aria-labelledby='gbox_dataGrid']//tbody//tr"), 2).ToList();
           return tableRows.Count > 0;
        }

            public bool InProductLookupConfirmTableRowsBelowTrends()
        {
            IWebElement tableRows = this.FindElement(By.XPath($"//div[@class='stats-cards card-deck mt-2']/../../following-sibling::div"), 2);
            return tableRows != null;
        }

        public bool InStatusWebViewersConfirmFooterIsBelowTable()
        {
            IWebElement footer = this.FindElement(By.XPath($"//div[@id='supertable_main']/following-sibling::div[@class='webviewerfooter clearfix']"), 2);
            return footer != null;
        }

        public bool InStatusWebViewersConfirmTableBackgroundColorGrey()
        {
            IWebElement background = this.FindElement(By.XPath($"//div[@class='body-container']"), 2);
            Report.Info(background.GetCssValue("color"));
            return background.GetCssValue("color") == "rgba(0, 0, 0, 1)";
        }

        public bool InStatusWebViewersConfirmTableHasRows()
        {
            IList<IWebElement> tableRows = this.FindElements(By.XPath($"//div[@id='gbox_dataGrid']//table[@class='ui-jqgrid-btable ui-common-table'][@aria-labelledby='gbox_dataGrid']//tbody//tr"), 2).ToList();
            return tableRows.Count > 0;
        }
        public bool InProductLookupIConfirmTheFollowingTrendsAreNotDisplayed(Table table)
        {
            IWebElement card = this.FindElement(By.XPath($"//div[@class='card']"), 2);
            foreach (var row in table.Rows)
            {
                IWebElement cardText = card.FindElement(By.XPath($"//h6[text()='" + row["Trend"] + "']"), 2);
                if (cardText == null)
                {
                    Report.Info("test - " + row["Trend"]);
                    return true;
                }
            }
            return false;
        }

        public bool InRecentActivitiesIConfirmTheFollowingTrendsAreNotDisplayed(Table table)
        {
            IWebElement card = this.FindElement(By.XPath($"//div[@class='card']"), 2);
            foreach (var row in table.Rows)
            {
                IWebElement cardText = card.FindElement(By.XPath($"//h6[text()='" + row["Trend"] + "']"), 2);
                if (cardText == null)
                {
                    Report.Info("test - " + row["Trend"]);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }

    class NavBarTools : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.Id("navbar-tools");

		private IWebElement Gauge => FindElement(By.Id("dropdownMenu1"), 1);

		private IWebElement DropDownContainer => FindElement(By.XPath(".//*[@id='widget-ul' or @class='dropdown-menu show']"), 1);

		private IWebElement ResetDashboard => DropDownContainer.FindElement(By.Id("dashboard-reset"), 1);

        private IWebElement StoreViewer => DropDownContainer.FindElement(By.XPath("//a[contains(@href,'/WV/Store?')]"), 1);
        private IWebElement RefreshWidgets => DropDownContainer.FindElement(By.Id("dashboard-refresh"), 1);

		private List<IWebElement> VisibleDropDownOptions => DropDownContainer.FindElements(By.XPath(".//a[@class='dropdown-item' or not(parent::node()[@style='display: none;'])]"), 2).ToList();



		private IWebElement WidgetTitleOption => DropDownContainer.FindElement(By.Id(""), 1);

		private List<IWebElement> AllDropDownOptions => this.DropDownContainer.FindElements(By.XPath(".//a"), 1).ToList();

		#endregion

		#region Methods

		public bool ClickGauge() => this.Gauge.TryClick();

		public bool GaugeDisplayed() => this.Gauge.NotNullAndDisplayed();

		public string ResetDashboardText() => this.ResetDashboard?.Text;

		public string RefreshWidgetsText() => this.RefreshWidgets?.Text;

		public bool ResetDashboardDisplayed() => this.ResetDashboard.NotNullAndDisplayed();

        public string StoreViewerText() => this.StoreViewer?.Text;

        public bool StoreViewerDisplayed() => this.StoreViewer.NotNullAndDisplayed();

        public bool RefreshWidgetDisplayed() => this.ResetDashboard.NotNullAndDisplayed();

		public bool ClickResetDashboard() => this.ResetDashboard.TryClick();

		public bool ClickRefreshWidgets() => this.RefreshWidgets.TryClick();

		public bool DropDownContainerDisplayed() => this.DropDownContainer.NotNullAndDisplayed();

		public bool DropDownOptionsAvailable() => this.AllDropDownOptions.Any();

		public bool SelectDropDownOption(string option)
		{
			List<IWebElement> allOptions = this.VisibleDropDownOptions;
			IWebElement wantedElement = allOptions.First(x => x.Text == option);
			return wantedElement.TryClick();

		}


		public List<string> GetListOfDropDownOptions()
		{

			List<IWebElement> allOptions = this.VisibleDropDownOptions;
			List<string> optionsAsText = new List<string>();
			foreach (var option in allOptions)
			{
				optionsAsText.Add(option.Text);
			}
			return optionsAsText;
		}



		#endregion
	}
}

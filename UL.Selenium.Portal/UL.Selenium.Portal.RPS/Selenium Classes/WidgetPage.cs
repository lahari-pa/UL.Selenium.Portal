using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Steps;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class WidgetPage : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class='main-wrapper-nosidebar']");

        private List<IWebElement> WidgetContainers => FindElements(By.XPath("//div[starts-with(@class,'grid-stack-item ui')]"), 1).ToList();

       

        private List<IWebElement> DisplayedGraphs => FindElements(By.XPath(".//div[contains(@id,'-graph')]//div[contains(@id, '-graph-content')]//*[name()='svg' and contains(@class,'highcharts-root')]"), 1).ToList();

        
        #endregion

        #region Methods
        public List<string> WidgetTitles => this.WidgetContainers.Select(x => x.FindElement(By.XPath(".//div[@class='panel-title']"), 1)?.Text).ToList();

        public bool WaitWidgetSpinnerFinish()
        {
            if (this.containerElement.WaitUntilElementVisible(By.XPath(".//div[contains(@id,'content-parent-div-wait')]"), 5) != null)
            {
                return this.containerElement.WaitUntilElementInvisible(By.XPath(".//div[contains(@id,'content-parent-div-wait')]"), 30);
            }
            return true;
        }

        public bool WaitUntilXGraphsDisplayed(int graphNumber=4, int waitForSeconds = 30)
        {
           
            int i = 0;
            while (i<waitForSeconds )
            {
                if (this.DisplayedGraphs.Count()==graphNumber)
                {
                    Report.Info("The number of displayed graphs matched the expected number");
                    return true;
                }
                i++;
                Delay.Seconds(1);                
            }
            Report.Info($"The number of displayed graphs did not match the expected number after: {i} seconds");
            return false;             
            
        }

        

        public bool ClickContainer() => this.containerElement.TryClick();

        public List<Widget> Widgets()
        {
            var titles = this.WidgetTitles;
            var rList = new List<Widget>();
            foreach (var title in titles)
            {
                var thisWidget = new Widget(title);
                rList.Add(thisWidget);
            }
            return rList;
        }

        public Widget GetWidget(string widgetName)
        {
            if (Context.GetFromContextRegex(widgetName, out object contextWidget))
            {
                return (Widget)contextWidget;
            }
            return new Widget(widgetName);
        }

       

        public bool PrintDialogIsShown()
        {
            return SeleniumBrowser.Alert.IsAlertPresent();
        }

        public string DocumentWindowOpen()
        {
            Report.Info("Switch to File window");
            //string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
            //Context.AddToContext("MainWindowHandle", currentHandle);
            ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
            foreach (string handle in handles)
            {
                if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url.Contains("chart"))
                {
                    return SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url;
                }
            }
            return null;
        }

        public string DocumentText(string address)
        {
            var reader = new PdfReader(new Uri(address));
            var output = new StringWriter();
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));
            }
            return output.ToString();
        }



        


        #endregion

        public class Widget : SeleniumBaseObject
        {
            #region Page Objects
            
            protected override By ContainerElementLocator => By.XPath($"//div[starts-with(@class,'grid-stack-item ui') and .//div[@class='panel-title' and text()='{Title}']]");
            
            private IWebElement DropdownToggle => FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 1);

            private IWebElement Heading => FindElement(By.XPath(".//div[@class='panel-title']"), 1);

            private IWebElement HeadingPullLeftDiv => this.Heading.FindElement(By.XPath("./parent::div[contains(@class, 'pull-left')]"), 1);

            private IWebElement DropdownMenu => FindElement(By.XPath(".//ul[@class='dropdown-menu']"), 1);
            
            private List<IWebElement> DropDownItems() =>this.DropdownMenu.FindElements(By.XPath($".//a[starts-with(@id, '{this.Id}']"), 1).ToList();

            private IWebElement DropdownItem(string type) => this.DropdownMenu.FindElement(By.XPath($".//a[@id = '{this.Id}-{type.ToLower()}']"), 1);

            private IWebElement DropdownItemByText(string text) => this.DropdownMenu.FindElement(By.XPath($".//a[./span/following-sibling::span[text()='{text}']]"), 1);

            private IWebElement DropdownItemIcon(string type) => this.DropdownItemByText(type).FindElement(By.XPath(".//span"), 1);

            private IWebElement Body => FindElement(By.Id($"{this.Id}-content-parent-div"), 1);

            private IWebElement Panel => FindElement(By.XPath("./div[contains(@class,'panel-default')]"), 1);

            private IWebElement GraphContainer => FindElement(By.XPath($".//div[@id='{this.Id}-graph']"), 1);

            private IWebElement DataContent => FindElement(By.XPath($".//div[@id='{this.Id}-statistics-content']"), 1);

            private IWebElement ProductContent => FindElement(By.XPath($".//div[@id='{this.Id}-product-list']"), 1);

            private IWebElement GraphContent => this.GraphContainer.FindElement(By.XPath($".//div[@id= '{this.Id}-graph-content']"), 1);

            private IWebElement GraphNoContentMessage => this.GraphContainer.FindElement(By.XPath("./div[contains(@id, 'no-content') and not(@style = 'display:none;')]/p"), 1);

            private IWebElement GraphHamburgerMenuButton => this.GraphContainer.FindElement(By.XPath(".//*[name()='g' and contains(@class,'highcharts-button')]"), 1);

            private IWebElement GraphMenuList => this.GraphContainer.FindElement(By.XPath(".//div[contains(@class,'highcharts-contextmenu')]"), 1);

            private IWebElement HamburgerMenuContainer => this.GraphContainer.FindElement(By.XPath(".//div[@class='highcharts-menu']"), 1);

            private List<IWebElement> HamburgerMenuOptions => this.HamburgerMenuContainer.FindElements(By.XPath(".//div[@class='highcharts-menu-item']"), 1).ToList();

            private IWebElement ScrollBar => this.GraphContent.FindElement(By.XPath(".//*[name()='g' and @class='highcharts-scrollbar']"), 1);

            private IWebElement ProductsListBackButton => this.ProductContent.FindElement(By.XPath(".//a[@class='btn btn-default pull-right' and contains(text(),'Back')]"), 2);

            private IWebElement SupplierListBackButton => this.SupplierContent.FindElement(By.XPath(".//a[@class='btn btn-default pull-right' and contains(text(),'Back')]"), 2);

            private IWebElement GraphViewBackButton => this.GraphContent.FindElement(By.XPath(".//*[name()='g' and .//text()='Back']"), 2);

            private IWebElement LegendPageNumberElement => this.GraphContent.FindElement(By.XPath(".//*[name()='g']//* [name()='text' and @class='highcharts-legend-navigation']"), 2);

            private IWebElement ScrollRightArrow => this.ScrollBar.FindElement(By.XPath(".//*[name()='g'][3]"), 2);

            private IWebElement ScrollLeftArrow => this.ScrollBar.FindElement(By.XPath(".//*[name()='g'][2]"), 2);

            private string scrollLocation => this.ScrollBar.FindElement(By.XPath(".//*[name()='g'][1]"), 2).GetAttribute("transform");

            private IWebElement SupplierContent => FindElement(By.XPath($".//div[@id='{this.Id}-supplier-list']"), 1);

            private IWebElement WidgetDragIcon => this.containerElement.FindElement(By.XPath($".//div[contains(@class,'ui-resizable-handle')]"), 2);


            #endregion

            #region Methods
            public bool ClickWidgetDropdownToggle() => this.DropdownToggle.TryClick();

            public bool DropdownMenuDisplayed() => this.DropdownMenu.NotNullAndDisplayed();

            public bool ClickDropDownItem(string item) => this.DropdownItem(item).TryClick();

            public bool DropDownItemDisplayed(string item) => this.DropdownItemByText(item).NotNullAndDisplayed();

            public string IconForDropDownItem(string item) => this.DropdownItemIcon(item).GetAttribute("class");

            public bool HeadingDisplayed() => this.Heading.NotNullAndDisplayed();

            public string HeadingText() => this.Heading?.Text;

            public bool DropDownToggleDisplayed() => this.DropdownToggle.NotNullAndDisplayed();

            public bool BodyDisplayed() => this.Body.NotNullAndDisplayed();

            public string BorderColour() => this.Panel?.GetCssValue(@"border-color");

            public string HeadingColour() => this.Heading?.GetCssValue("color");

            public bool GraphContentDisplayed() => this.GraphContent.NotNullAndDisplayed();

            public string NoGraphContentText() => this.GraphNoContentMessage?.Text;

            public bool DataContentDisplayed() => this.DataContent.NotNullAndDisplayed();

            public bool ProductContentDisplayed() => this.ProductContent.NotNullAndDisplayed();

            public bool SupplierContentDisplayed() => this.SupplierContent.NotNullAndDisplayed();

            public bool HeadingLeftAlligned() => this.HeadingPullLeftDiv.NotNullAndDisplayed();

            public bool GraphHamburgerDisplayed() => this.GraphHamburgerMenuButton.NotNullAndDisplayed();

            public bool GraphHamburgerMenuDisplayed() => this.GraphMenuList.NotNullAndDisplayed();

            public bool ClickGraphHamburger() => this.GraphHamburgerMenuButton.TryClick();

            public bool ClickGraphHamburgerOption(string option) => this.HamburgerMenuOptions.FirstOrDefault(x => x.GetValue().Trim() == option).TryClick(ClickType.JavaScript);

            public bool GraphMenuListDisplayed() => this.GraphMenuList.NotNullAndDisplayed();

            public bool ProductsListBackButtonDisplayed() => this.ProductsListBackButton.NotNullAndDisplayed();

            public bool SupplierListBackButtonDisplayed() => this.SupplierListBackButton.NotNullAndDisplayed();

            public bool ClickProductsListBackButton() => this.ProductsListBackButton.TryClick();

            public bool ClickSupllierListBackButton() => this.SupplierListBackButton.TryClick();

            public bool GraphViewBackButtonDisplayed() => this.GraphViewBackButton.NotNullAndDisplayed();

            public bool ClickGraphViewBackButton() => this.GraphViewBackButton.TryClick();



            public List<IWebElement> GetCurrentGraphTitleElements() => this.GraphContainer.FindElements(By.XPath($".//*[name()='g' and contains (@class,'highcharts-data-labels')]//*[name()='g']/*[name()='text']"), 2).ToList();
            // public List<IWebElement> GetCurrentGraphTitleElements() => this.GraphContainer.FindElements(By.XPath($".//*[name()='g' and contains (@class,'highcharts-data-labels')]//*[name()='g']//*[name()='title']"), 2).ToList();

            public List<IWebElement> GetCurrentDataTitleEls() => this.DataContent.FindElements(By.XPath($".//tbody//tr"), 2).ToList();

            public List<IWebElement> GetCurrentProductEls()=>this.ProductContent.FindElements(By.XPath($".//tbody//tr"), 2).ToList();

            public IWebElement GetGivenProductLink(string productID)
            {
                List<IWebElement> currentProducts = this.GetCurrentProductEls();
                foreach(var product in currentProducts)
                {
                    IWebElement currentProductLink = product.FindElement(By.XPath($"//td//a[text()='{productID}']"), 2);
                    if(currentProductLink!=null)
                    {
                        Report.Info($"Found the product Link for product with ID: {productID}");
                        return currentProductLink;
                    }
                }
                Report.Info($"Did not find the Product with id: {productID} in the list of products");
                return null;

            }

            public List<string> GetHamburgerOptions()
            {
                List<string> optionsString = new List<string>();               
                foreach (var el in this.HamburgerMenuOptions)
                {
                    optionsString.Add(el.Text);
                }
                return optionsString;
            }


            //For Bar Chart only Counts
            public List<string> CurrentBarGraphFrequencies()
            {
                List<string> frequnciesInOrder = new List<string>();
                List<IWebElement> titleElements = this.GraphContent.FindElements(By.XPath($".//*[name()= contains(@class,'highcharts-label highcharts-data-label highcharts-data-label-color-')]"), 2).ToList();
                foreach(var title in titleElements)
                {
                    List<IWebElement> textEls= title.FindElements(By.XPath($".//*[name()='tspan']"), 2).ToList();
                    string freq = textEls[textEls.Count - 1].Text;
                    frequnciesInOrder.Add(freq);

                }
                return frequnciesInOrder;


            }

            //This method is currently not used as bar chart drill down needs to scroll to get all the titles, need to delete once sure not needed. 
            public List<string> CurrentChartFullTitlesGraphView2()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                var titleElements = containerHTML.FindElements(ByHtml.XPath($".//div[@id= '{this.Id}-graph-content']//*[name()= contains(@class,'highcharts-label highcharts-data-label highcharts-data-label-color-')]"));


                List<string> fullTitles = new List<string>();
                List<IWebElement> titleElementsPie = this.GraphContent.FindElements(By.XPath($".//*[name()= contains(@class,'highcharts-label highcharts-data-label highcharts-data-label-color-')]"), 2).ToList();
                
                if (this.Type=="Bar Graph")
                {
                    foreach (var title in titleElements)
                    {
                                                
                        //var textEls = currentEl.FindElements(ByHtml.XPath($".//*[name()='tspan' and not(@class='highcharts-text-outline')]"), 2);
                        string newTitle = "";
                        var thisSection = title;
                        var textEls = thisSection.FindElements(ByHtml.XPath($".//*[name()='tspan' and not(@class='highcharts-text-outline')]"));

                        foreach (var el in textEls)
                        {
                            if(newTitle.EndsWith("-"))
                            {
                                if (newTitle.EndsWith(" -"))
                                {
                                    newTitle = newTitle + " " + el.GetValue();
                                }
                                else
                                {
                                    newTitle = newTitle + el.GetValue();
                                }
                                    
                            }
                            else
                            {
                                newTitle = newTitle + " " + el.GetValue();
                            }
                            
                        }
                        fullTitles.Add(newTitle.Trim());
                    }
                    return fullTitles;
                }
                if (this.Type == "Pie Chart")
                {
                    foreach (var title in titleElementsPie)
                    {
                        string newTitle = "";
                        IWebElement textEl = title.FindElement(By.XPath($".//*[name()='tspan' and not(@class='highcharts-text-outline')]"), 2);
                        fullTitles.Add(textEl.Text);

                    }
                    return fullTitles;
                }
                else
                {
                    Report.Error("The type of graph must be either bar graph or pie chart");
                    return null;
                }
                
               
            }







            //This method replaces the orginal GraphViewTitles method as drill down was causing issues in bar charts (needed to scroll). 
            public List<string> CurrentChartFullTitlesGraphView()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                var titleElements = containerHTML.FindElements(ByHtml.XPath($".//div[@id= '{this.Id}-graph-content']//*[name()= contains(@class,'highcharts-label highcharts-data-label highcharts-data-label-color-')]"));


                List<string> fullTitles = new List<string>();                
                List<IWebElement> titleElementsPie = this.GraphContent.FindElements(By.XPath($".//*[name()= contains(@class,'highcharts-label highcharts-data-label highcharts-data-label-color-')]"), 2).ToList();

                if (this.Type == "Bar Graph")
                {
                    bool end = false;                    
                    while (end == false)
                    {
                        containerHTML = GetContainerHtml();
                        titleElements = containerHTML.FindElements(ByHtml.XPath($".//div[@id= '{this.Id}-graph-content']//*[name()= contains(@class,'highcharts-label highcharts-data-label highcharts-data-label-color-')]"));
                        string firstLocation = this.scrollLocation;
                        foreach (var title in titleElements)
                        {
                            //var textEls = currentEl.FindElements(ByHtml.XPath($".//*[name()='tspan' and not(@class='highcharts-text-outline')]"), 2);
                            string newTitle = "";
                            var thisSection = title;
                            var textEls = thisSection.FindElements(ByHtml.XPath($".//*[name()='tspan' and not(@class='highcharts-text-outline')]"));

                            foreach (var el in textEls)
                            {
                                if (newTitle.EndsWith("-"))
                                {
                                    if (newTitle.EndsWith(" -"))
                                    {
                                        newTitle = newTitle + " " + el.GetValue().Trim();
                                    }
                                    else
                                    {
                                        newTitle = newTitle + el.GetValue().Trim();
                                    }

                                }
                                else
                                {
                                    newTitle = newTitle + " " + el.GetValue().Trim();
                                }

                            }
                            if (fullTitles.Contains(newTitle.Trim()))
                            {
                                Report.Info("The Title was already found in the list, moving on.");
                            }
                            else
                            {
                                if (newTitle.Trim().Contains("&amp"))
                                {
                                    string corrected = newTitle.Trim().Replace("&amp;", "&");
                                    if (newTitle.Trim().Contains(" :"))
                                    {
                                        corrected = corrected.Replace(" :", ":");
                                    }                                    
                                  
                                   if (fullTitles.Contains(corrected))
                                   {
                                       Report.Info("The Title was already found in the list, moving on.");
                                   }
                                   else
                                    {
                                        fullTitles.Add(corrected.Replace(" :", ":"));
                                    }
                                                                        
                                    
                                }
                                else
                                {
                                    string toAdd = newTitle.Trim();
                                    if (newTitle.Trim().Contains(" :"))
                                    {
                                        
                                        toAdd = newTitle.Trim().Replace(" :", ":");
                                        fullTitles.Add(toAdd);
                                    }
                                    if (fullTitles.Contains(toAdd))
                                    {
                                        Report.Info("The Title was already found in the list, moving on.");
                                    }
                                    else
                                    {
                                        fullTitles.Add(toAdd);
                                    }

                                }
                                
                            }

                        }
                        if(!this.ScrollBarIsPresent())
                        {
                            return fullTitles;
                        }


                        this.ScrollRightArrow.TryClick();
                        var test = this.ScrollRightArrow;
                        Delay.Seconds(0.2);
                        string SecondLocation = this.scrollLocation;
                        end = SecondLocation == firstLocation;
                    }
                    bool resetToStart = false;
                    while(resetToStart==false)
                    {
                        string startPoint = this.scrollLocation;
                        if (this.ScrollLeftArrow.TryClick())
                        {
                            Delay.Seconds(0.2);
                            string endPoint = this.scrollLocation;
                            resetToStart = startPoint == endPoint;
                        }
                        else
                        {
                            Report.Info("The left arrow was not clicked");
                            return null;
                        }
                        

                    }
                    List<string> distinct = fullTitles.Distinct().ToList();
                    return distinct;

                }
                if (this.Type == "Pie Chart")
                {
                    foreach (var title in titleElementsPie)
                    {
                        string newTitle = "";
                        IWebElement textEl = title.FindElement(By.XPath($".//*[name()='tspan' and not(@class='highcharts-text-outline')]"), 2);
                        fullTitles.Add(textEl.Text);

                    }
                    return fullTitles;
                }
                else
                {
                    Report.Error("The type of graph must be either bar graph or pie chart");
                    return null;
                }


            }









            public List<string> GetCurrentProductNumbers()
            {
                //need to update to use datacontent after container.
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                try
                {
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td//a"));
                    Delay.Seconds(2);
                    List<string> productNumber = new List<string>();
                    foreach (var el in listOfEl)
                    {
                        string textfound = el.GetValue();
                        productNumber.Add(textfound);
                    }
                    return productNumber;
                }
                catch
                {
                    Delay.Seconds(5);
                    containerHTML = GetContainerHtml();
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td//a"));
                    
                    List<string> productNumber = new List<string>();
                    foreach (var el in listOfEl)
                    {
                        string textfound = el.GetValue();
                        productNumber.Add(textfound);
                    }
                    return productNumber;
                }

                
            }

            //This was made for the pie charts so might break for bar charts.
            public List<string> GetProductNumbers()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                if (this.Type == "Pie Chart")
                {
                    int x = 0;
                    while (x < 5)
                    {
                        try
                        {
                            Delay.Seconds(2);
                            var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[@data-bind='text: productNumber']"));
                            Delay.Seconds(2);
                            int numberofSections = listOfEl.Count();
                            List<string> productNumbers = new List<string>();
                            foreach (var section in listOfEl)
                            {
                                
                                var thisSection = section;
                                var list= thisSection.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                                //var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                                Delay.Seconds(2);
                                int currentUPCCount = list.Count();
                                //int currentUPCCount = currentUPCsFound.Count();
                                for (int i = 0; i < currentUPCCount; i++)
                                {
                                    productNumbers.Add(section.GetValue());
                                }
                            }
                            return productNumbers;
                        }
                        catch
                        {
                            Report.Info("Failed to get the product numbers, trying again if there has been less than 5 attempts");
                            x++;
                            Delay.Seconds(4);
                        }
                    }                     
                }
                if (this.Type == "Bar Graph")
                {


                    Report.Info($"Failed 2 times to get the values, switching to bar chart elements and trying again");
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td//a"));

                    int numberofSections = listOfEl.Count();
                    List<string> productNumbers = new List<string>();
                    foreach (var section in listOfEl)
                    {
                        productNumbers.Add(section.GetValue());
                    }
                    return productNumbers;
                }
                else
                {
                    Report.Error("The type of graph must be either bar graph or pie chart");
                    return null;
                }
            }




            //This was made for the pie charts so might break for bar charts.
            public List<string> GetProductNames()
            {
                //need to update to use datacontent after container.
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                try
                {
                    try
                    {

                        Delay.Seconds(2);
                        var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[@data-bind='text: name']"));
                        Delay.Seconds(2);
                        int numberofSections = listOfEl.Count();
                        List<string> productNames = new List<string>();
                        foreach (var section in listOfEl)
                        {
                            var thisSection = section;
                            var list = thisSection.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            //var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            Delay.Seconds(2);
                            int currentUPCCount = list.Count();
                            //int currentUPCCount = currentUPCsFound.Count();
                            for (int i = 0; i < currentUPCCount; i++)
                            {
                                if (section.GetValue().Contains("&amp;"))
                                {
                                    string corrected = section.GetValue().Replace("&amp;", "&");
                                    productNames.Add(corrected);
                                }
                                else
                                {
                                    productNames.Add(section.GetValue());
                                }
                            }
                        }
                        return productNames;
                    }
                    catch
                    {
                        Delay.Seconds(2);
                        var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[@data-bind='text: name']"));
                        Delay.Seconds(2);
                        int numberofSections = listOfEl.Count();
                        List<string> productNames = new List<string>();
                        foreach (var section in listOfEl)
                        {
                            var thisSection = section;
                            var list = thisSection.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            //var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            Delay.Seconds(2);
                            int currentUPCCount = list.Count();
                            //int currentUPCCount = currentUPCsFound.Count();
                            for (int i = 0; i < currentUPCCount; i++)
                            {
                                if (section.GetValue().Contains("&amp;"))
                                {
                                    string corrected = section.GetValue().Replace("&amp;", "&");
                                    productNames.Add(corrected);
                                }
                                else
                                {
                                    productNames.Add(section.GetValue());
                                }
                            }
                        }
                        return productNames;
                    }
                }
                catch
                {
                    Report.Info($"Failed 2 times to get the values, switching to bar chart elements and trying again");
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[contains(@class,'product-name')]"));
                    Delay.Seconds(2);
                    int numberofSections = listOfEl.Count();
                    List<string> productNumbers = new List<string>();
                    foreach (var section in listOfEl)
                    {
                        if (section.GetValue().Contains("&amp;"))
                        {
                            string corrected = section.GetValue().Replace("&amp;", "&");
                            productNumbers.Add(corrected);
                        }
                        else
                        {
                            productNumbers.Add(section.GetValue());
                        }
                       
                    }
                    return productNumbers;

                }
            }


            //This was made for the pie charts so might break for bar charts.
            public List<string> GetProductUPCS()
            {
                //need to update to use datacontent after container.
                SeleniumHtmlDocument containerHTML = GetContainerHtml();

                try
                {
                    try
                    {

                        Delay.Seconds(2);
                        var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[@data-bind='text: name']"));
                        Delay.Seconds(2);
                        int numberofSections = listOfEl.Count();
                        List<string> productUPCS = new List<string>();
                        foreach (var section in listOfEl)
                        {
                            var thisSection = section;
                            var list = thisSection.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            //var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            Delay.Seconds(2);
                            int currentUPCCount = list.Count();
                            //int currentUPCCount = currentUPCsFound.Count();
                            foreach (var upc in list)
                            {
                                productUPCS.Add(upc.GetValue());
                            }
                        }
                        return productUPCS;
                    }
                    catch
                    {
                        Delay.Seconds(2);
                        var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[@data-bind='text: name']"));
                        
                        int numberofSections = listOfEl.Count();
                        List<string> productUPCS = new List<string>();
                        foreach (var section in listOfEl)
                        {
                            var thisSection = section;
                            var list = thisSection.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            //var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[@class='col-md-2']//table//tr"));
                            Delay.Seconds(2);
                            int currentUPCCount = list.Count();
                            //int currentUPCCount = currentUPCsFound.Count();

                            foreach (var upc in list)
                            {
                                productUPCS.Add(upc.GetValue());
                            }
                        }
                        return productUPCS;
                    }
                }
                catch
                {
                    Report.Info($"Failed 2 times to get the values, switching to bar chart elements and trying again");               
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[contains(@data-bind,'upcs')]"));                    
                    List<string> productUPCS = new List<string>();

                    foreach(var el in listOfEl)
                    {
                        string elText;
                        elText = el.GetValue();
                        //if (elText.Contains(","))
                        //{
                        //    List<string> splitUPCs = elText.Split(',').ToList(); 
                        //    foreach (var item in splitUPCs)
                        //    {
                        //        item.Replace(",", "");
                        //        item.Replace(" ", "");
                        //        productUPCS.Add(item);
                        //    }
                        //}
                        //else
                        //{
                        //    productUPCS.Add(elText);
                        //}
                        productUPCS.Add(elText);
                    }                   
                    return productUPCS;

                }
            }

            public List<string> GetProductSuppliers()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                try
                {
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[contains(@data-bind,'supplier')]"));
                    Delay.Seconds(2);                    
                    List<string> productNumbers = new List<string>();
                    foreach (var section in listOfEl)
                    {

                        if (section.GetValue().Contains("&amp;"))
                        {
                            string corrected = section.GetValue().Replace("&amp;", "&");
                            productNumbers.Add(corrected);
                        }
                        else
                        {
                            productNumbers.Add(section.GetValue());
                        }                                          
                    }
                    return productNumbers;
                }
                catch
                {
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[contains(@data-bind,'supplier')]"));
                    Delay.Seconds(2);
                    List<string> productNumbers = new List<string>();
                    foreach (var section in listOfEl)
                    {
                        if (section.GetValue().Contains("&amp;"))
                        {
                            string corrected = section.GetValue().Replace("&amp;", "&");
                            productNumbers.Add(corrected);
                        }
                        else
                        {
                            productNumbers.Add(section.GetValue());
                        }
                    }
                    return productNumbers;
                }
            }





            public List<string> GetProductSuppliersIndividual()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                try
                {
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[contains(@data-bind,'supplier')]"));
                    Delay.Seconds(2);
                    int numberofSections = listOfEl.Count();
                    List<string> productNumbers = new List<string>();
                    foreach (var section in listOfEl)
                    {
                        var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[contains(@data-bind,'upcs')]"));
                        
                        int currentUPCCount = currentUPCsFound.Count();
                        for (int i = 0; i < currentUPCCount; i++)
                        {
                            if (section.GetValue().Contains("&amp;"))
                            {
                                string corrected = section.GetValue().Replace("&amp;", "&");
                                productNumbers.Add(corrected);
                            }
                            else
                            {
                                productNumbers.Add(section.GetValue());
                            }
                        }
                    }
                    return productNumbers;
                }
                catch
                {
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[contains(@data-bind,'supplier')]"));
                    
                    int numberofSections = listOfEl.Count();
                    List<string> productNumbers = new List<string>();
                    foreach (var section in listOfEl)
                    {
                        var currentUPCsFound = containerHTML.FindElements(ByHtml.XPath($".//ancestor::tr//td[contains(@data-bind,'upcs')]"));
                        
                        int currentUPCCount = currentUPCsFound.Count();
                        for (int i = 0; i < currentUPCCount; i++)
                        {
                            if (section.GetValue().Contains("&amp;"))
                            {
                                string corrected = section.GetValue().Replace("&amp;", "&");
                                productNumbers.Add(corrected);
                            }
                            else
                            {
                                productNumbers.Add(section.GetValue());
                            }
                        }
                    }
                    return productNumbers;
                }
            }



            //Data View Just Title no Count
            public List<string> GetCurrentDataTitles()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                var listOfEl= containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-statistics-content']//tbody/tr"));

                Delay.Seconds(2);
                List<string> dataTitles = new List<string>();               
                foreach(var el in listOfEl)
                {
                    string textfound = el.GetValue();           
                    textfound = textfound.Substring(0, textfound.LastIndexOf(" ") + 1);
                    char[] charsToTrim = { '*', ' ' };
                    string resultCleaned= textfound.Trim(charsToTrim);
                    if (resultCleaned.Contains("&amp;"))
                    {
                        string corrected = resultCleaned.Replace("&amp;", "&");
                        dataTitles.Add(corrected);
                    }
                    else
                    {
                        dataTitles.Add(resultCleaned);
                    }
                    
                }
                return dataTitles;
            }


            //Data View Title with Count
            public List<string> GetCurrentDataTitlesWithCount()
            {
                
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-statistics-content']//tbody/tr"));

                Delay.Seconds(2);
                List<string> dataTitles = new List<string>();
                foreach (var el in listOfEl)
                {
                    string textfound = el.GetValue();
                    string resultFormated = this.ConvertTitleToCleanFormat(textfound);
                    if (resultFormated.Contains("&amp;"))
                    {
                        string corrected = resultFormated.Replace("&amp;", "&");
                        dataTitles.Add(corrected);
                    }
                    else
                    {
                        dataTitles.Add(resultFormated);
                    }
                    
                }
                return dataTitles;
            }


            //Data view Count Only
            public List<string>GetCurrentDataTitlesCountOnly()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-statistics-content']//tbody/tr"));

                Delay.Seconds(2);
                List<string> dataTitles = new List<string>();
                foreach (var el in listOfEl)
                {
                    string textfound = el.GetValue();
                    string resultFormated = this.GetOnlyTitleNumber(textfound);
                    dataTitles.Add(resultFormated);
                }
                return dataTitles;
            }



            public string ConvertTitleToCleanFormat(string rawTitle)
            {
                string titleNumber = rawTitle;
                int lengthindex = titleNumber.Length - 1;
                int lastSpace = titleNumber.LastIndexOf(" ");
                int goLength = lengthindex - lastSpace;
                titleNumber = titleNumber.Substring(lastSpace + 1, goLength);
                string titleText = rawTitle;
                titleText= rawTitle.Substring(0, rawTitle.LastIndexOf(" ") + 1);
                char[] charsToTrim = { '*', ' ' };
                string resultCleaned = titleText.Trim(charsToTrim);
                return resultCleaned + ": " + titleNumber;
            }

            public string GetOnlyTitleNumber(string rawTitle)
            {
                string titleNumber = rawTitle;
                int lengthindex = titleNumber.Length - 1;
                int lastSpace = titleNumber.LastIndexOf(" ");
                int goLength = lengthindex - lastSpace;
                titleNumber = titleNumber.Substring(lastSpace + 1, goLength);
                return titleNumber;
            }




            public List<string> GetCurrentGraphTitles()
            {
                List<string> graphTitles = new List<string>();
                bool displayed = this.GraphContentDisplayed();
                List<IWebElement> titleElements = this.GetCurrentGraphTitleElements();
                foreach (var el in titleElements)
                {
                    string title= el.GetCssValue("title");
                    string elText = el.Text;
                    string test = el.GetValue();
                    if(elText.Contains(":"))
                    {
                         elText = elText.Substring(0, elText.LastIndexOf(":") + 1);
                        
                    }                                    
                    graphTitles.Add(elText);
                }
                return graphTitles;

            }

            public List<string> GetCurrentGraphTitlesWithCount()
            {
                List<string> graphTitles = new List<string>();
                foreach (var el in this.GetCurrentGraphTitleElements())
                {
                    graphTitles.Add(el.Text);
                }
                return graphTitles;

            }

            public List<IWebElement> GetGraphSections() => this.GraphContainer.FindElements(By.XPath($".//*[name()='g' and contains (@class,'highcharts-series highcharts-series')]//*[name()='rect']"), 2).ToList();

            public List<IWebElement> GetPieChartSections() => this.GraphContainer.FindElements(By.XPath($".//*[name()='g' and contains (@class,'highcharts-data-labels highcharts-series-0')]//*[name()='g']"), 2).ToList();

            public List<IWebElement> GetAllLegendElements() => this.GraphContainer.FindElements(By.XPath($".//*[name()='g' and contains(@class,'highcharts-legend-item highcharts-pie-series highcharts-color')]"), 2).ToList();

            public string GetTypeOfGraph()
            {
               string idStr= this.GraphContent.GetAttribute("id");
                if(idStr.IsNullOrEmpty())
                {
                    Report.Error("Did not find the class of the Graph content element");
                    return null;
                }
                if(idStr.Contains("aws"))
                {
                    return "Bar Graph";
                }
                if(idStr.Contains("sql"))
                {
                    return "Pie Chart";
                }
                else
                {
                    Report.Error("Class did not match either the expected value for a bar graph or pie chart");
                    return null;
                }
            }

            public bool ScrollBarIsPresent()
            {
                IWebElement scrollBarElement = this.ScrollBar;
                return scrollBarElement != null && this.ScrollBar.Displayed;
            }


            public bool WaitUntilGraphXIsDisplayed(int waitForSeconds = 30)
            {

                int i = 0;
                while (i < waitForSeconds)
                {
                    if (this.GraphContentDisplayed()==true)
                    {
                        Report.Info("The Graph content was displayed");
                        return true;
                    }
                    i++;
                    Delay.Seconds(1);
                }
                Report.Info($"The Graph content did not display after: {i} seconds");
                return false;

            }

            public bool MultipleLegendPagesExist()
            {
                var legendPageNumberEl = this.LegendPageNumberElement;
                if(legendPageNumberEl==null)
                {
                    Report.Info("The Legend Page Number Element was null/not found");
                    return false;
                }
                Report.Info("Found the Legend Page number Element");
                return true;
            }

            public int MaxLegendPageNumber()
            {
                var legendPageNumberEl = this.LegendPageNumberElement;
                if(legendPageNumberEl==null)
                {
                    Report.Info("There was no Page number listed");
                    return 0;
                }
                string fullString = legendPageNumberEl.Text;
                string output = fullString.Substring(fullString.IndexOf('/') + 1);
                int maxPageNumber;
                if( int.TryParse(output, out maxPageNumber))
                {
                    Report.Info("Found max page number");
                    return maxPageNumber;
                }
                Report.Info("Did not find the max page number");
                return 0;
            }

            public int CurrentLegendPageNumber()
            {
                var legendPageNumberEl = this.LegendPageNumberElement;
                if (legendPageNumberEl == null)
                {
                    Report.Info("There was no Page number listed");
                    return 0;
                }
                string fullString = legendPageNumberEl.Text;
                string output = fullString.Substring(0, fullString.IndexOf("/") + 1);
               string edited= output.Replace("/","");

                int currentPageNumber;
                if (int.TryParse(edited, out currentPageNumber))
                {
                    Report.Info("Found Current page number");
                    return currentPageNumber;
                }
                Report.Info("Did not find the current page number");
                return 0;
            }
            public string GetLegendElText(IWebElement legendEl,string id)
            {
                try
                {
                    Report.Info("Trying to get legend element text");
                    var action = new Actions(SeleniumBrowser.WebBrowser);
                    action.MoveToElement(legendEl).Perform();
                    IWebElement tooltip = this.GraphContent.FindElement(By.XPath(".//*[name()='g' and contains(@class,'tooltip')]//*[name()='text']/*[name()='tspan'][2]"), 2);
                    string tooltipTitleText = tooltip.Text;
                    string editedText = tooltipTitleText.Trim();
                    return editedText = editedText.Remove(editedText.LastIndexOf(":"), 1);
                }
                catch
                {
                    int i = 0;
                    while (i<5)
                    {
                        try
                        {
                            var list = this.GetAllLegendElements();
                            list[0].TryClick();
                            Delay.Seconds(1);
                            list[0].TryClick();
                            Delay.Seconds(1);
                            new TopBar().RefocusGraph();
                            var action = new Actions(SeleniumBrowser.WebBrowser);
                            action.MoveToElement(legendEl).Perform();
                            IWebElement tooltip = this.GraphContent.FindElement(By.XPath(".//*[name()='g' and contains(@class,'tooltip')]//*[name()='text']/*[name()='tspan'][2]"), 2);
                            string tooltipTitleText = tooltip.Text;
                            string editedText = tooltipTitleText.Trim();
                            return editedText = editedText.Remove(editedText.LastIndexOf(":"), 1);
                        }
                        catch
                        {
                            i++;
                            Report.Info("Failed to return tool tip text");
                        }
                    }
                    Report.Info("Final Failure to return tool tip text");
                    return null;
                    

                }

            }

            public bool ClickLegendPageNavigationUp() => this.GraphContainer.FindElement(By.XPath(".//*[name()='g']//*[name()='path' and contains(@class,'highcharts-legend-nav')][1]"), 2).TryClick();
            public bool ClickLegendPageNavigationDown() => this.GraphContainer.FindElement(By.XPath(".//*[name()='g']//*[name()='path' and contains(@class,'highcharts-legend-nav')][2]"), 2).TryClick();

            public bool ComparePieChartDataToShortGraphTitles(List<string> graphTitles, List<string> dataTitles)
            {
                List<string> newGraphTitles = new List<string>();
                foreach(var item in graphTitles)
                {
                    if(item =="")
                    {
                        newGraphTitles.Add(item);
                    }
                    else
                    {
                        string updateString = item.Replace("...", "");
                        updateString = updateString.Substring(0, updateString.LastIndexOf(":"));
                        newGraphTitles.Add(updateString);
                    }
                    
                }
                bool allfound = true;
                if(graphTitles.Count()!=newGraphTitles.Count())
                {
                    allfound = false;
                    Report.Info("The counts of the two lists did not match");
                    return allfound;
                }
                foreach(var graphtitle in newGraphTitles)
                {
                    bool currentFound = false;
                    for (int i=0; i<dataTitles.Count();i++)
                    {
                        
                        if(dataTitles[i].Contains(graphtitle))
                        {
                            string test = dataTitles[i];
                            Report.Info($"The graph title: {graphtitle} was found in the data titles list");
                            currentFound = true;
                        }
                    }
                    if(currentFound!=true)
                    {
                        Report.Info($"The graph title: {graphtitle} was not found in the data titles list");
                        allfound = false;
                    }
                    
                    
                    
                }
                return allfound;

            }

            public List<LegendItem> GetCurrentLegendItems()
            {
                string id = this.Title;
                int maxPages = this.MaxLegendPageNumber();
                List<IWebElement> legendEls = this.GetAllLegendElements();
                List<LegendItem> currentLegendItems = new List<LegendItem>();
                int legendElCount = legendEls.Count();
                int expectedCurrentPageNumber = 1;
                int i = 0;
                foreach (var el in legendEls)
                {
                    LegendItem currentItem = new LegendItem();
                    if (i!=0&&(i % 18) == 0)
                    {
                     this.ClickLegendPageNavigationDown();
                     Delay.Seconds(1);
                     int foundcurrentPageNumber = this.CurrentLegendPageNumber();
                     expectedCurrentPageNumber++;
                     if(foundcurrentPageNumber== expectedCurrentPageNumber)
                     {
                            Report.Info("The Page Number was as expected");
                     }
                     else
                     {

                            Report.Failure("The Page Number was not as expected");
                            return null;
                     }                      
                    }
                    string elText = this.GetLegendElText(el,id);
                    currentItem.ItemElement = el;
                    currentItem.ItemTitle = elText;
                    currentLegendItems.Add(currentItem);
                    i++;
                }
                int newExpectedCurrentPage = maxPages;
                for (int j = 0; j < maxPages-1; j++)
                {
                    this.ClickLegendPageNavigationUp();
                    Delay.Seconds(0.5);
                    newExpectedCurrentPage--;
                    int foundcurrentPageNumber = this.CurrentLegendPageNumber();
                    if (foundcurrentPageNumber == newExpectedCurrentPage)
                    {
                        Report.Info("The Page Number was as expected");
                    }
                    else
                    {

                        Report.Failure("The Page Number was not as expected");
                        return null;
                    }
                }
                return currentLegendItems;       
                         

            }

            public List<PieChartItem> GetCurrentPieChartItems()
            {
                string id = this.Title;                
                
                //get them titles from the graph for pie chart 

                List<IWebElement> pieChartEls = this.GetPieChartSections();
                List<PieChartItem> currentPieChartSections = new List<PieChartItem>();
                List<string> graphsectionTitles = this.CurrentChartFullTitlesGraphView();
                if (graphsectionTitles.Count != pieChartEls.Count)
                {
                    Report.Info("Differnt number of titles were being found");
                    return null;
                }
                int i = 0;
                foreach (var el in pieChartEls)
                {
                    PieChartItem currentItem = new PieChartItem();
                    currentItem.ItemElement = el;
                    currentItem.ItemTitle = graphsectionTitles[i];
                    currentPieChartSections.Add(currentItem);
                    i++;
                }
                return currentPieChartSections;

            }

            public bool CheckPieChartSectionRemoved(string section)
            {
                string id = this.Title;
                new Steps_Home().ForWidgetISwitchToView(id, "Data");
                Delay.Seconds(2);
                List<string> newDataTitles = this.GetCurrentDataTitles();
                new Steps_Home().ForWidgetISwitchToView(id, "Graph");
                Delay.Seconds(2);            
                
                
                List<string> graphsectionTitles = this.CurrentChartFullTitlesGraphView();
                if (graphsectionTitles.Count != newDataTitles.Count)
                {
                    Report.Info("Differnt number of titles were being found");
                    return false;
                }
                int titlePostion = 0;
                foreach(var title in newDataTitles)
                {
                    if(title.Contains(section))
                    {
                        Report.Info("Found the title postion in the data view title list");
                        break;
                    }
                    else
                    {
                        titlePostion++;
                    }
                }
                return graphsectionTitles[titlePostion] == "";         
            }
                                               

                
            

            public bool ClickLegendSection(string section, List<LegendItem> legendItemList)
            {
                //this method needs updating to handle clicking a pie chart section that is not on the first page of legend
                if (section=="<first>")
                {
                    return legendItemList[0].ItemElement.TryClick();
                }
                LegendItem wantedItem = legendItemList.FirstOrDefault(x => x.ItemTitle.Contains(section));
                if (wantedItem == null)
                {
                    Report.Info("The section we are looking for was not found in the list of sections");
                    return false;
                }
                return wantedItem.ItemElement.TryClick();
            }


            public bool ContactSupplierTextFound(string productID)
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();                
                Delay.Seconds(2);
                if(productID=="<first>")
                {
                    var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[contains(@id,'{this.Id}-product-list')]//tbody//tr//td//a[@class='contact-supplier']"));
                    return listOfEl[1].GetValue() == "Contact Supplier";                    

                }

                var wantedProductEl = containerHTML.FindElement(ByHtml.XPath($".//div[contains(@id,'{this.Id}-product-list')]//tbody//tr[.//td[text()='{productID}']]//td//a[@class='contact-supplier']"));
                return wantedProductEl.GetValue() == "Contact Supplier";

            }



            public ProductListItems GetCurrentProductListItems()
            {
                var currentProductListItems = new ProductListItems();
                currentProductListItems.ProductNumbers= this.GetProductNumbers();
                currentProductListItems.ProductNames = this.GetProductNames();
                currentProductListItems.ProductUPCs = this.GetProductUPCS();
                try
                {
                    currentProductListItems.ProductSuppliers = this.GetProductSuppliers();
                }
                catch
                {
                    Report.Info("Suppliers could not be grabbed from the product list");
                    Report.Screenshot();
                }
                return currentProductListItems;
            }




            public List<string> GetSupplierListSupplier()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();                
                    int x = 0;
                    while (x < 5)
                    {
                        try
                        {
                            Delay.Seconds(2);
                            var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-supplier-list']//tbody//tr//td[@data-bind='text: supplier']"));
                            Delay.Seconds(2);
                            List<string> suppliers = new List<string>();
                            foreach (var section in listOfEl)
                            {

                            var thisSection = section;
                            if (section.GetValue().Contains("&amp;"))
                            {
                                string corrected = section.GetValue().Replace("&amp;", "&");
                                suppliers.Add(corrected);
                            }
                            else
                            {
                                suppliers.Add(section.GetValue());
                            }                      
                            

                            }
                            return suppliers;
                        }
                        catch
                        {
                            Report.Info("Failed to get the suppliers, trying again if there has been less than 5 attempts");
                            x++;
                            Delay.Seconds(4);
                        }
                    }
                Report.Failure("Failed to get Suppliers after 5 attempts");
                return null;
                
            }

            public List<string> GetSupplierListContact()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                int x = 0;
                while (x < 5)
                {
                    try
                    {
                        Delay.Seconds(2);
                        var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-supplier-list']//tbody//tr//td//a[contains(@data-bind,'text:contact')]"));
                        Delay.Seconds(2);
                        List<string> contacts = new List<string>();
                        foreach (var section in listOfEl)
                        {
                            var thisSection = section;

                            if (section.GetValue().Contains("&amp;"))
                            {
                                string corrected = section.GetValue().Replace("&amp;", "&");
                                contacts.Add(corrected);
                            }
                            else
                            {
                                contacts.Add(section.GetValue());
                            }
                        }
                        return contacts;
                    }
                    catch
                    {
                        Report.Info("Failed to get the suppliers, trying again if there has been less than 5 attempts");
                        x++;
                        Delay.Seconds(4);
                    }
                }
                Report.Failure("Failed to get Suppliers after 5 attempts");
                return null;

            }
            

            public List<string> GetSupplierListEmail()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                int x = 0;
                while (x < 5)
                {
                    try
                    {
                        Delay.Seconds(2);
                        var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-supplier-list']//tbody//tr//td[@data-bind='text: email']"));
                        Delay.Seconds(2);
                        List<string> emails = new List<string>();
                        foreach (var section in listOfEl)
                        {
                            var thisSection = section;

                            if (section.GetValue().Contains("&amp;"))
                            {
                                string corrected = section.GetValue().Replace("&amp;", "&");
                                emails.Add(corrected);
                            }
                            else
                            {
                                emails.Add(section.GetValue());
                            }
                        }
                        return emails;
                    }
                    catch
                    {
                        Report.Info("Failed to get the suppliers, trying again if there has been less than 5 attempts");
                        x++;
                        Delay.Seconds(4);
                    }
                }
                Report.Failure("Failed to get Suppliers after 5 attempts");
                return null;

            }



            public SupplierListItems GetCurrentSupplierListItems()
            {
                var currentSupplierListItems = new SupplierListItems();
                currentSupplierListItems.Suppliers = this.GetSupplierListSupplier();
                currentSupplierListItems.Contacts = this.GetSupplierListContact();
                currentSupplierListItems.Emails = this.GetSupplierListEmail();               
                return currentSupplierListItems;
            }

            public List<string> GetSupplierListColumnHeadings()
            {
                List<IWebElement> headerElements = this.SupplierContent.FindElements(By.XPath(".//thead//tr[1]//th"), 2).ToList();
                List<string> supplierHeadersTitles = new List<string>();
                foreach (var el in headerElements)
                {
                    if(el.Text.ToLower().Contains("back"))
                    {
                        
                    }
                    else
                    {
                        supplierHeadersTitles.Add(el.Text);
                    }
                }
                return supplierHeadersTitles;

            }


            public List<string> GetProductistColumnHeadings()
            {
                List<IWebElement> headerElements = this.ProductContent.FindElements(By.XPath(".//thead//tr[1]//th"), 2).ToList();
                List<string> productListHeadings = new List<string>();
                foreach (var el in headerElements)
                {
                    if (el.Text.ToLower().Contains("back")|| el.Text.ToLower().IsNullOrEmpty())
                    {

                    }
                    else
                    {
                        productListHeadings.Add(el.Text);
                    }
                }
                return productListHeadings;

            }

            public bool ContactSupplierTextFoundForAllProducts()
            {
                SeleniumHtmlDocument containerHTML = GetContainerHtml();
                Delay.Seconds(2);
                bool textFound = true;
                var listOfEl = containerHTML.FindElements(ByHtml.XPath($".//div[contains(@id,'{this.Id}-product-list')]//tbody//tr//td//a[@class='contact-supplier']"));
                var productNumberEls = containerHTML.FindElements(ByHtml.XPath($".//div[@id='{this.Id}-product-list']//tbody//tr//td[@data-bind='text: productNumber']"));
                int i = 1;
                foreach(var el in listOfEl)
                {
                    if(el.GetValue() == "Contact Supplier")
                    {
                        Report.Info($"The row containing Product Number: {productNumberEls[i-1].GetValue()}, which was in postion {i}, did contain the text 'Contact Supplier'");
                    }
                    else
                    {
                        textFound = false;
                        Report.Info($"The row containing Product Number: {productNumberEls[i-1].GetValue()}, which was in postion {i}, did not contain the text 'Contact Supplier'");
                    }
                    i++;
                }
                return textFound;                                               

            }


            public string GetWidgetXandYCoordinate()
            {
                IWebElement wantedWidgetEl = this.containerElement;
                string xValue = wantedWidgetEl.GetAttribute("data-gs-x");
                string yValue = wantedWidgetEl.GetAttribute("data-gs-y");
                string finalCoordinates = xValue + " , " + yValue;
                return finalCoordinates;

            }

            public bool DragWidgetSizeDown()
            {
                
                IWebElement element = this.WidgetDragIcon;
               
              //  (new Actions(SeleniumBrowser.WebBrowser)).DragAndDrop(element, target).Perform();

                Actions builder = new Actions(SeleniumBrowser.WebBrowser);             
                

                builder.DragAndDropToOffset(element, 20, 20).Build().Perform();
                return true;

                // Action resize = action.clickAndHold(element).moveByOffset(X offset, Y offset).release().build();


            }


            #endregion

            #region Class Properties
            public string Title { get; }

            public string Id { get; }

            public int X { get; }

            public int Y { get; }

            public string Type { get; }

            public Widget(string title)
            {
                Title = title;
                try
                {
                    Id = this.containerElement.GetAttribute("data-gs-id");
                }
                catch
                {

                }

                X = this.containerElement.Location.X;

                Y = this.containerElement.Location.Y;

                Type = this.GetTypeOfGraph();

            }

            public class ProductListItems
            {
                public List<string> ProductNumbers { get; set; }

                public List<string> ProductNames { get; set; }
                public List<string> ProductUPCs { get; set; }

                public List<string> ProductSuppliers { get; set; }
                
            }

            public class SupplierListItems
            {
                public List<string> Suppliers { get; set; }

                public List<string> Contacts{ get; set; }
                public List<string> Emails { get; set; }              

            }

            public class LegendItem
            {
                public IWebElement ItemElement { get; set; }
                public string ItemTitle { get; set; }
            }

            public class PieChartItem
            {
                public IWebElement ItemElement { get; set; }
                public string ItemTitle { get; set; }
            }


            #endregion
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class Home : WidgetPage
    {
        #region Page Objects
        private List<IWebElement> DisplayedGraphs => FindElements(By.XPath(".//div[contains(@id,'-graph')]//div[contains(@id, '-graph-content')]//*[name()='svg' and contains(@class,'highcharts-root')]"), 1).ToList();

        private List<IWebElement> InformationPanels => FindElements(By.XPath(".//div[@class='row']/div[@class='col-md-6']"), 1).ToList();


        #endregion

        #region Methods   
        public bool WaitUntilHomeXGraphsDisplayed(int graphNumber = 4, int waitForSeconds = 30)
        {

            int i = 0;
            while (i < waitForSeconds)
            {
                if (this.DisplayedGraphs.Count() == graphNumber)
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

        public List<string> InformationPanelTitles() => this.InformationPanels.Select(x => x.FindElement(By.XPath(".//h1"), 1).Text).ToList();


        #endregion




    }
}


using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class Dashboard : WidgetPage
    {
        #region Page Objects
        private List<IWebElement> DisplayedGraphs => FindElements(By.XPath(".//div[contains(@id,'-graph')]//div[contains(@id, '-graph-content')]//*[name()='svg' and contains(@class,'highcharts-root')]"), 1).ToList();

        private List<IWebElement> InformationPanels => FindElements(By.XPath(".//div[@class='row']/div[@class='col-md-6']"), 1).ToList();

        #endregion

        #region Methods   

        //X Graphs might be an issue ( as this number can change per acc etc)
        public bool WaitUntilDashboardXGraphsDisplayed(int graphNumber = 8, int waitForSeconds = 30)
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

        public bool AnyInformationPanelsPresent()
        {
            List<IWebElement> listOfPanels = this.InformationPanels;
            if (listOfPanels.IsNullOrEmpty())
            {
                return false;
            }
            else
            {

                return true;
            }
        }
      




        #endregion




    }
}



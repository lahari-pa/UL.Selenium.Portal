using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "Dashboard")]
    class Steps_Dashboard
    {
        [StepDefinition(@"I confirm the Dashboard tab has loaded")]
        public void HomeTabLoaded()
        {
            Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
            GeneralUtilities.WaitForLoadingToFinish();
            new Dashboard().WaitWidgetSpinnerFinish();
            if (!new Dashboard().WaitUntilDashboardXGraphsDisplayed())
            {
                Report.Error("All Graphs did not load");
                Report.Info("All Graphs did not load, Attempting to reset the Dashboard");
                new Steps_Navigation().ConfirmActiveTab("Dashboard");
                Report.IsTrue(new Dashboard().WaitForContainerToBeVisible(), "Dashboard content did not load", "Dashboard content loaded");
                new Steps_Shared().SharedStep54484();
                if(!new Dashboard().WaitUntilDashboardXGraphsDisplayed())
                {
                    Report.Error("All Graphs did not load");
                    Report.Info("All Graphs did not load, Attempting to reset the Dashboard");
                }
            }
            new Steps_Navigation().ConfirmActiveTab("Dashboard");
            Report.IsTrue(new Dashboard().WaitForContainerToBeVisible(), "Dashboard content did not load", "Dashboard content loaded");
        }

        [StepDefinition(@"I confirm there is no page footer shown")]
        public void ConfirmNoPageFooter()
        {
            Report.IsTrue(!new Dashboard().AnyInformationPanelsPresent(), "A page footer was shown", "A page footer was not shown");

        }

        [StepDefinition(@"I Check that for widget (.*) the supplier list (is|is not) showing")]
        public void CheckThatSupplierListIsShowing(string widgetTitle, string showStatus)
        {
            bool showing = true;            
            if(showStatus == "is not")
            {
                showing = false;
            }
            int x = 0;
            while (new Home.Widget(widgetTitle).SupplierContentDisplayed() != showing && x < 10)
            {
                Report.Info($"The supplier list was not in the expected status");
                Delay.Seconds(5);
                x++;

            }
            if (new Home.Widget(widgetTitle).SupplierContentDisplayed() != showing)
            {
                Report.Failure($"The supplier list was not in the expected status at the end");
                return;
            }
            else
            {
                Report.Success($"The supplier list {showStatus} showing correctly");
                return;
            }
        }

        [StepDefinition(@"I Check that for the widget (.*), the Suppliers List shows the Following headings:")]
        public void CheckWidgetSupplierListHeadings(string widgetTitle, Table table)
        {
            List<string> headers = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                headers.Add(thisRow["Headers"]);
            }
            List<string> foundHeadings = new Home.Widget(widgetTitle).GetSupplierListColumnHeadings();
            var differences = headers.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty(), "The headings found did not fully match the expected headings for the suppliers list", "The headings found matched the expected headings for the suppliers list");
        }

        [StepDefinition(@"END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION")]
        public void EndOfAuotmationStep()
        {
            Report.Warning("END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION");
        }

        [StepDefinition(@"END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: (.*)")]
        public void EndOfAuotmationStepMessage(string message)
        {
            Report.Warning("END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION");
            Report.Warning($"Message: {message}");
        }

        [StepDefinition(@"In the Dashboard page, I confirm all widgets are shown correctly in their original order:")]
        public void ConfirmDashBoardWidgetsInOrginalOrder(Table table)
        {
            List<string> expectedCoordinates = new List<string>();
            expectedCoordinates.Add("0 , 0");
            expectedCoordinates.Add("6 , 0");
            expectedCoordinates.Add("0 , 12");
            expectedCoordinates.Add("6 , 12");
            expectedCoordinates.Add("0 , 24");
            expectedCoordinates.Add("6 , 24");
            expectedCoordinates.Add("0 , 36");
            expectedCoordinates.Add("6 , 36");

            List<string> headers = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                headers.Add(thisRow["Widget"]);
            }
            

            int i = 0;
            foreach(var header in headers)
            {
                string foundCoordinate = new Home.Widget(header).GetWidgetXandYCoordinate();
                Report.Info($"The expected coordinate was: {expectedCoordinates[0]}");
                Report.Info($"The found corrdinate was: {foundCoordinate}");
                Report.IsTrue(foundCoordinate==expectedCoordinates[i],"The found coordinate did not match the expected coordinate for the widget with title: "+header, "The found coordinate matched the expected coordinate for the widget with title: " + header);
                i++;
            }
           

        }

        //[StepDefinition(@"Drag test (.*)")]
        //public void IUseDoubleArrowToResizeWidget(string widget)
        //{
        //    new Home.Widget(widget).DragWidgetSizeDown();
        //}

        [StepDefinition(@"I Confirm that the Products List for the widget: (.*) contains the column headings:")]
        public void ConfrimProductsListHeadings(string widget, Table table)
        {
            List<string> headers = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                headers.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new Home.Widget(widget).GetProductistColumnHeadings();
            var diff1 = foundHeadings.Except(headers);
            var diff2 = headers.Except(foundHeadings);
            Report.IsTrue(diff1.IsNullOrEmpty() && diff2.IsNullOrEmpty(), "The expected and found headings for the products list did not match", "The expected and found headings for the products list matched");
        }

        [StepDefinition(@"I Confirm that the Products list for the widget: (.*) contains 'Contact Supplier' in all rows")]
        public void ConfirmProductsListContainsContactSupplierInAllRows(string widget)
        {
            Report.IsTrue(new Home.Widget(widget).ContactSupplierTextFoundForAllProducts(), "The text 'Contact Supplier' was not found in all rows", "The text 'Contact Supplier' was found in all rows");
        }


        

        

    }
}


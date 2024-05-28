using System.Collections.Generic;
using System.Linq;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "Dashboard")]
    class Steps_Dashboard
    {
        [RegexStepDefinition(@"I confirm the Dashboard tab has loaded")]
        public void HomeTabLoaded()
        {
            Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
            GeneralUtilities.WaitForLoadingToFinish();
            new Dashboard().WaitWidgetSpinnerFinish();
            // TODO: Working with Bev to determine whether this section eneds to be readded, leaving in until then
            /*
            if (!new Dashboard().WaitUntilDashboardXGraphsDisplayed(6, 30))
            {
                Report.Error("All Graphs did not load");
                Report.Info("All Graphs did not load, Attempting to reset the Dashboard");
                new Steps_Navigation().ConfirmActiveTab("Dashboard");
                Report.IsTrue(new Dashboard().WaitForContainerToBeVisible(), "Dashboard content did not load", "Dashboard content loaded");
                new Steps_Shared().SharedStep54484();
                if(!new Dashboard().WaitUntilDashboardXGraphsDisplayed(6, 30))
                {
                    Report.Error("All Graphs did not load");
                    Report.Info("All Graphs did not load, Attempting to reset the Dashboard");
                }
            }
            */
            new Steps_Navigation().ConfirmActiveTab("Dashboard");
            Report.IsTrue(new Dashboard().WaitForContainerToBeVisible(), "Dashboard content did not load", "Dashboard content loaded");
        }

        [RegexStepDefinition(@"I confirm there is no page footer shown")]
        public void ConfirmNoPageFooter()
        {
            Report.IsTrue(new Dashboard().AnyInformationPanelsPresent() == true, "A page footer was shown", "A page footer was not shown");

        }

        [RegexStepDefinition(@"I Check that for widget (.*) the supplier list (is|is not) showing")]
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

        [RegexStepDefinition(@"I Check that for the widget (.*), the (Supplier|Product) List shows the Following headings:")]
        public void CheckWidgetSupplierListHeadings(string widgetTitle, string listType, Table table)
        {
            List<string> headers = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                headers.Add(thisRow["Headers"]);
            }
            List<string> foundHeadings;
            Delay.Seconds(1);
            if(listType == "Supplier")
            {
                foundHeadings = new Home.Widget(widgetTitle).GetSupplierListColumnHeadings();
            }
            else
            {
                foundHeadings = new Home.Widget(widgetTitle).GetProductListColumnHeadings();
            }
            
            var differences = headers.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty(), "The headings found did not fully match the expected headings for the suppliers list", "The headings found matched the expected headings for the suppliers list");
        }

        [RegexStepDefinition(@"END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION")]
        public void EndOfAuotmationStep()
        {
            Report.Warning("END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION");
        }

        [RegexStepDefinition(@"END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: (.*)")]
        public void EndOfAuotmationStepMessage(string message)
        {
            Report.Warning("END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION");
            Report.Warning($"Message: {message}");
        }

        [RegexStepDefinition(@"In the Dashboard page, I confirm all widgets are shown correctly in their original order:")]
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

        [RegexStepDefinition(@"In the Dashboard page, I confirm all widgets are shown correctly in their order saved as: (.*)")]
        public void ConfirmDashBoardWidgetsInSavedOrder(string savedAs)
        {
            List<WidgetPage.Widget> widgetList = new List<WidgetPage.Widget>();
            if(Context.Contains(savedAs))
            {
                widgetList = (List<WidgetPage.Widget>)Context.GetFromContext(savedAs);
            }
            else
            {
                Report.Failure($"Failed to find widget list in context saved as: '{savedAs}'.");
                return;
            }

            foreach (var widget in widgetList)
            {
                string foundCoordinate = new Home.Widget(widget.Title).GetWidgetXandYCoordinate();
                Report.Info($"The expected coordinate was: {widget.XandYCoordinate}");
                Report.Info($"The found corrdinate was: {foundCoordinate}");
                Report.IsTrue(foundCoordinate == widget.XandYCoordinate, "The found coordinate did not match the expected coordinate for the widget with title: " + widget.Title, "The found coordinate matched the expected coordinate for the widget with title: " + widget.Title);
            }


        }

        [RegexStepDefinition(@"In the Dashboard page, I confirm all widgets are shown correctly in their order saved as default")]
        public void ConfirmDashBoardWidgetsInSavedOrderDefault()
        {
            ConfirmDashBoardWidgetsInSavedOrder("WidgetList");
        }

            [RegexStepDefinition(@"I use double arrow to resize widget: (.*)")]
        public void IUseDoubleArrowToResizeWidget(string widget)
        {
            Report.IsTrue(new Home.Widget(widget).DragWidgetSizeDown(),$"Failure, failed to resize {widget} widget.",$"Success, resized {widget} widget");
        }

        [RegexStepDefinition(@"I use double arrow to resize the saved widget")]
        public void IUseDoubleArrowToResizeSavedWidget()
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info($"Attempting to resize '{widget.Title}' widget.");
            IUseDoubleArrowToResizeWidget(widget.Title);
        }

        [RegexStepDefinition(@"I Confirm that the Products List for the widget: (.*) contains the column headings:")]
        public void ConfrimProductsListHeadings(string widget, Table table)
        {
            List<string> headers = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                headers.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new Home.Widget(widget).GetProductListColumnHeadings();
            var diff1 = foundHeadings.Except(headers);
            var diff2 = headers.Except(foundHeadings);
            Report.IsTrue(diff1.IsNullOrEmpty() && diff2.IsNullOrEmpty(), "The expected and found headings for the products list did not match", "The expected and found headings for the products list matched");
        }

        [RegexStepDefinition(@"I Confirm that the Products list for the widget: (.*) contains 'Contact Supplier' in all rows")]
        public void ConfirmProductsListContainsContactSupplierInAllRows(string widget)
        {
            Report.IsTrue(new Home.Widget(widget).ContactSupplierTextFoundForAllProducts(), "The text 'Contact Supplier' was not found in all rows", "The text 'Contact Supplier' was found in all rows");
        }


        

        

    }
}


using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Reqnroll;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Automation.Reporting.Classes;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "Home")]
    class Steps_Home
    {
        [RegexStepDefinition(@"I confirm I am directed to the Home tab")]
        [RegexStepDefinition(@"I confirm the Home tab has loaded")]
        public void HomeTabLoaded()
        {
            Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
            GeneralUtilities.WaitForLoadingToFinish();
            new Home().WaitWidgetSpinnerFinish();
            new Steps_Navigation().ConfirmActiveTab("Program Health");
        }

        [RegexStepDefinition(@"I confirm the Home tab has loaded in RPS")]
        public void HomeTabLoadedInRPS()
        {
            new Home().HomePageIsDisplayedInRPS();
        }

        [RegexStepDefinition(@"I confirm the following Widgets are displayed:")]
        public void ConfirmDisplayedWidgets(Table table)
        {
            Report.Info("Expected widgets:");
            ReqnrollReporting.Table(table);
            var widgets = new Home().WidgetTitles;
            var expectedWidgets = table.Rows.Select(x => x["Widget"]).ToList();
            if (!Report.IsTrue(expectedWidgets.All(x => widgets.Contains(x)), "Not all expected widgets were displayed!", "All expected widgets were displayed"))
            {
                var differences = expectedWidgets.Except(widgets).ToList();
                Report.Failure("The following widgets were not displayed: " + string.Join(", ", differences));
            }
        }

        [RegexStepDefinition(@"I confirm the following listed Widgets are displayed: (.*)")]
        public void ConfirmListedDisplayedWidgets(string widgetList)
        {
            Report.Info("Expected widgets:");
            var widgets = new Home().WidgetTitles;
            //var expectedWidgets = table.Rows.Select(x => x["Widget"]).ToList();
            var expectedWidgets = widgetList.Replace(", ", ",").Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            if (!Report.IsTrue(expectedWidgets.All(x => widgets.Contains(x)), "Not all expected widgets were displayed!", "All expected widgets were displayed"))
            {
                var differences = expectedWidgets.Except(widgets).ToList();
                Report.Failure("The following widgets were not displayed: " + string.Join(", ", differences));
            }
        }

        [RegexStepDefinition("I confirm the widget: '(.*) (is|is not) displayed'")]
        public void ConfirmWidgetDisplayedOrNot(string widget, string displayedOrNot)
        {

            bool displayed = false;
            if (displayedOrNot == "is")
            {
                displayed = true;
            }
            else if (displayedOrNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'");
                return;
            }
            if (Context.GetFromContextRegex(widget, out var result))
            {
                Report.Info("Getting widget title from Context: " + widget);
                widget = result.ToString();
            }

            int i = 0;
            var widgets = new Home().WidgetTitles;
            Report.Info("Expected widget title is: " + widget);
            while (widgets.Contains(widget) != displayed && i < 5)
            {
                Report.Info($"Widget with title '{widget}' {(displayedOrNot == "is" ? "is not" : "is")} displayed!, waiting 5 seconds and checking again");
                Delay.Seconds(5);
                i++;
            }
            Report.IsTrue(widgets.Contains(widget) == displayed, $"Widget with title '{widget}' {(displayedOrNot == "is" ? "is not" : "is")} displayed!", $"Widget with title '{widget}' {displayedOrNot} displayed as expected");
        }

        [RegexStepDefinition(@"I click the dropdown toggle for widget: (.*)")]
        public void ClickDropDownToggle(string widgetTitle)
        {
            var widget = new Home.Widget(widgetTitle);
            Report.IsTrue(widget.ClickWidgetDropdownToggle(), "Failed to click widget dropdown toggle for: " + widgetTitle, "Clicked widget dropdown toggle for: " + widgetTitle);
        }

        [RegexStepDefinition(@"I click the hamburger icon for widget: (.*)")]
        public void ClickHamburgerIcon(string widgetTitle)
        {
            var widget = new Home.Widget(widgetTitle);
            Report.IsTrue(widget.ClickWidgetHamburgerIcon(widgetTitle), "Failed to click hamburger icon for: " + widgetTitle, "Clicked widget hamburger icon for: " + widgetTitle);
        }

        [RegexStepDefinition(@"In the hamburger menu for the widget: (.*) I click the following option: (.*)")]
        public void ThenInTheHamburgerMenuForTheWidgetSupplierSubscriptionStatusIClickTheFollowingOptionPrintChart(string widgetTitle, string hamburgerOption)
        {
            var widget = new Home.Widget(widgetTitle);
            Report.IsTrue(widget.ClickHamburgerOptionForWidget(widgetTitle, hamburgerOption), "Failed to click hamburger icon for: " + widgetTitle, "Clicked widget hamburger icon for: " + widgetTitle);
        }


        [RegexStepDefinition(@"I click the dropdown toggle for the saved widget")]
        public void ClickDropDownToggle()
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title: " + widget.Title);
            Report.IsTrue(widget.ClickWidgetDropdownToggle(), "Failed to click widget dropdown toggle", "Clicked widget dropdown toggle");
        }

        [RegexStepDefinition(@"I confirm the dropdown menu list is displayed")]
        public void ConfirmDropDownMenuDisplayed()
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title: " + widget.Title);
            Report.IsTrue(widget.DropdownMenuDisplayed(), "Dropdown menu was not displayed!", "Dropdown menu was displayed");
        }

        [RegexStepDefinition(@"I click '(.*)' in the dropdown menu for widget: (.*)")]
        public void ClickDropdownOptionWidget(string option, string widgetTitle)
        {
            var widget = new Home.Widget(widgetTitle);
            Report.IsTrue(widget.ClickDropDownItem(option), $"Failed to click option: '{option}' for widget: '{widgetTitle}'", $"Clicked option: '{option}' for widget: '{widgetTitle}'");
        }

        [RegexStepDefinition(@"I click '(.*)' in the dropdown menu for the saved widget")]
        public void ClickDropdownOptionWidget(string option)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title: " + widget.Title);
            Report.IsTrue(widget.ClickDropDownItem(option), $"Failed to click option: '{option}'", $"Clicked option: '{option}'");
        }

        [RegexStepDefinition(@"I click the first displayed list option in the Select Chart Type popup and save to context as: (.*)")]
        public void ClickFirstListOption(string savedAs)
        {
            if (!new SelectChartModal().WaitForContainerToBeVisible())
            {
                Report.Failure("The Select Chart Type popup did not load!");
                return;
            }
            var options = new SelectChartModal().DisplayedListOptions();
            if (!options.Any())
            {
                Report.Failure("No list options were displayed!");
                return;
            }
            var exclusions = new List<string> { "RU Categories by RU", "Products by Status", "RU Categories by Supplier", "Product Hold Status" };
            Report.Info("The following options should not be permitted: " + string.Join(", ", exclusions));
            var firstValidOption = options.FirstOrDefault(x => !exclusions.Contains(x));
            if (firstValidOption == null)
            {
                Report.Failure("Failed to find a valid list option!");
                return;
            }
            Context.AddToContext(savedAs, firstValidOption);
            Report.Info("First option is: " + firstValidOption);
            Report.IsTrue(new SelectChartModal().ClickListItem(firstValidOption), $"Failed to click list option: {firstValidOption} in the Select Chart Type popup", $"Clicked list option: {firstValidOption} in the Select Chart Type popup");
        }

        [RegexStepDefinition(@"I confirm a popup has loaded with title: 'Select Chart Type'")]
        public void ConfirmSelectChartTypePopup()
        {
            var modal = new SelectChartModal();
            if (Report.IsTrue(modal.WaitForContainerToBeVisible(), "Popup did not load!", "Popup loaded as expected"))
            {
                Report.IsTrue(modal.TitleText == "Select Chart Type", "Popup title was not 'Select Chart Type'! Title was: " + modal.TitleText, "Modal title was 'Select Chart Type' as expected");
            }

        }

        [RegexStepDefinition(@"I close the Select Chart Type popup")]
        public void CloseSelectChartTypePopup()
        {
            Report.IsTrue(new SelectChartModal().ClickCloseTopRightX(), "Failed to close the popup", "Closed the popup");
        }

        [RegexStepDefinition(@"I click the list option: (.*) in the Select Chart Type popup")]
        public void ClickListOption(string listOption)
        {
            if (!new SelectChartModal().WaitForContainerToBeVisible())
            {
                Report.Failure("The Select Chart Type popup did not load!");
                return;
            }
            Report.Info("First option is: " + listOption);
            Report.IsTrue(new SelectChartModal().ClickListItem(listOption), $"Failed to click list option: {listOption} in the Select Chart Type popup", $"Clicked list option: {listOption} in the Select Chart Type popup");

        }

        [RegexStepDefinition(@"I confirm the Select Chart Type popup closes")]
        public void ConfirmSelectChartTypePopupCloses()
        {
            Report.IsTrue(new SelectChartModal().WaitForContainerToBeInvisible(), "Select Chart Type popup did not close!", "Select Chart Type popup closed");
        }

        [RegexStepDefinition(@"I click on the home page container element")]
        [RegexStepDefinition(@"I click on the home page background")]
        public void ClickHomePageContainer()
        {
            Report.IsTrue(new Home().ClickContainer(), "Failed to click the home page container", "Clicked the home page container");
        }

        [RegexStepDefinition("I confirm there are a total of (.*) widgets displayed in a (.*) x (.*) grid")]
        public void ConfirmWidgetCountAndGridOrder(int widgetCount, int distinctX, int distinctY)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"I confirm there are a total of {widgetCount} widgets displayed");
            this.ConfirmWidgetCount(widgetCount);
            Report.StartStep($"I confirm widgets are displayed in a {distinctX} x {distinctY} grid");
            this.ConfirmWidgetGridOrder(distinctX, distinctY);
        }

        [RegexStepDefinition("I confirm an information panel is displayed with heading: (.*)")]
        public void ConfirmInformationPanelWithHeading(string heading)
        {
            var panelHeadings = new Home().InformationPanelTitles().Select(x => x.Replace("\r\n", " ")).ToList();
            Report.IsTrue(panelHeadings.Contains(heading), $"Panel heading: '{heading}' was not displayed! Displayed was: " + string.Join(", ", panelHeadings), $"Panel heading: '{heading}' was displayed");
        }

        [RegexStepDefinition(@"I confirm there are a total of (.*) widgets displayed")]
        public void ConfirmWidgetCount(int widgetCount)
        {
            var widgets = new Home().Widgets();
            Report.IsTrue(widgets.Count == widgetCount, $"Expected there to be {widgetCount} widgets, but there were: " + widgets.Count, $"{widgetCount} widgets were displayed as expected");
        }

        [RegexStepDefinition("I confirm the widgets are displayed in a (.*) x (.*) grid")]
        public void ConfirmWidgetGridOrder(int expectedDistinctX, int expectedDistinctY)
        {
            var widgets = new Home().Widgets();
            var actualDistinctX = widgets.Select(x => x.X).Distinct().Count();
            var actualDisctinctY = widgets.Select(x => x.Y).Distinct().Count();
            Report.IsTrue(actualDistinctX == expectedDistinctX && actualDisctinctY == expectedDistinctY, $"The widgets were not displayed in a {expectedDistinctX} x {expectedDistinctY} grid! They were displayed in a {actualDistinctX} x {actualDisctinctY} grid", $"The widgets were displayed in a {expectedDistinctX} x {expectedDistinctY} grid");
        }

        [RegexStepDefinition(@"I verify each widget displays the correct data")]
        public void VerifyEachWidgetProperties()
        {
            var allWidgets = new Home().WidgetTitles;
            foreach (var widgetTitle in allWidgets)
            {
                Report.StartStep("Verifying displayed data in widget: " + widgetTitle);
                ReportDetails.CurrentDetails.UseSubSteps = true;
                var widget = new Home.Widget(widgetTitle);
                Report.StartStep("I confirm the widget is shown with a heading and a main body area");
                var headingDisplayed = widget.HeadingDisplayed();
                Report.IsTrue(headingDisplayed, "Heading was not displayed!", "Heading was displayed");
                var bodyDisplayed = widget.BodyDisplayed();
                Report.IsTrue(bodyDisplayed, "Body was not displayed!", "Body displayed");
                Report.StartStep("I confirm the widget heading shows background color: grey");
                var greyRgb = "rgb(205, 212, 219)";
                var backgroundColour = widget.BorderColour();
                Report.IsTrue(backgroundColour == greyRgb, "The heading background was not grey! Displayed colour: " + backgroundColour, "the heading background was grey.");
                Report.StartStep("I confirm the widget heading shows font color: black");
                var black = "rgba(115, 135, 156, 1)";
                var headingColour = widget.HeadingColour();
                Report.IsTrue(headingColour.Contains("(115, 135, 156"), "Heading colour was not black! Colour was: " + headingColour, "Heading colour was black");
                Report.StartStep("I confirm the widget heading shows a title");
                var titleDisplayed = !widget.HeadingText().IsNullOrEmpty();
                Report.IsTrue(titleDisplayed, "No heading title was displayed!", "Heading title was displayed");
                Report.StartStep("I confirm the widget heading title is aligned to the left of the widget heading area");
                var leftAlligned = widget.HeadingLeftAlligned();
                Report.IsTrue(leftAlligned, "Heading title was not left aligned!", "Heading title was left aligned");
                Report.StartStep("I confirm a three dots icon is shown to the right of the widget heading area");
                var toggleDisplayed = widget.DropDownToggleDisplayed();
                Report.IsTrue(toggleDisplayed, "The menu dropdown toggle (3 dots) was not displayed!", "The menu dropdown toggle (3 dots) was displayed");
                Report.StartStep("In the widget main body area, I confirm a graph or pie chart is shown - if no graph is shown I confirm I see 'There are no results that meet these criteria'");
                var graphdisplayed = widget.GraphContentDisplayed();
                var noResultsMessage = widget.NoGraphContentText();
                if (graphdisplayed)
                {
                    Report.Success("Graph content was displayed");
                    Report.Screenshot();
                    Report.StartStep("If a graph is shown, confirm the hamburger menu is displayed in the top right");
                    Report.IsTrue(widget.GraphHamburgerDisplayed(), "Graph hamburger menu was not displayed!", "Graph hamburger menu was displayed");
                }
                else
                {
                    Report.IsTrue(!noResultsMessage.IsNullOrEmpty(), "No graph was displayed, and also no message with text 'There are no results that meet these criteria'", "Message with text 'There are no results that meet these criteria' was displayed");
                }
                ReportDetails.CurrentDetails.UseSubSteps = false;
            }

        }

        [RegexStepDefinition(@"I verify each widget diplays a chart of some type")]
        public void IVerifyEachWidgetDisplaysChartOfSomeType()
        {
            var allWidgets = new Home().WidgetTitles;
            foreach (var widgetTitle in allWidgets)
            {
                Report.StartStep($"In the {widgetTitle} widget main body area, I confirm a graph or pie chart is shown - if no graph is shown I confirm I see 'There are no results that meet these criteria'");
                var widget = new Home.Widget(widgetTitle);
                var graphdisplayed = widget.GraphContentDisplayed();
                var noResultsMessage = widget.NoGraphContentText();
                if (graphdisplayed)
                {
                    Report.Success($"In {widgetTitle} widget, Graph content was displayed");
                    Report.Screenshot();
                    Report.StartStep("If a graph is shown, confirm the hamburger menu is displayed in the top right");
                    Report.IsTrue(widget.GraphHamburgerDisplayed(), $"In {widgetTitle} widget, Graph hamburger menu was not displayed!", $"In {widgetTitle} widget, Graph hamburger menu was displayed");
                }
                else
                {
                    Report.IsTrue(!noResultsMessage.IsNullOrEmpty(), $"In {widgetTitle} widget, No graph was displayed, and also no message with text 'There are no results that meet these criteria'", $"In {widgetTitle} widget, Message with text 'There are no results that meet these criteria' was displayed");
                }
            }
        }

        [RegexStepDefinition(@"I click the graph hamburger menu for widget: (.*)")]
        public void ClickGraphHamburger(string widgetTitle)
        {
            Home.Widget widget = new Home().GetWidget(widgetTitle);
            Report.IsTrue(widget.ClickGraphHamburger(), "Failed to click the graph hamburger menu button", "Clicked the graph hamburger menu button");
        }

        [RegexStepDefinition(@"I click the graph hamburger menu for the saved widget")]
        public void ClickGraphHamburger()
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.IsTrue(widget.ClickGraphHamburger(), "Failed to click the graph hamburger menu button", "Clicked the graph hamburger menu button");
        }

        [RegexStepDefinition("I save the first widget containing a graph to context as: (.*)")]
        public void SaveFirstWidgetWithGraph(string savedAs)
        {
            var widgets = new Home().WidgetTitles;
            foreach (var title in widgets)
            {
                var thisWidget = new Home.Widget(title);
                if (thisWidget.GraphContentDisplayed())
                {
                    Context.AddToContext(savedAs, thisWidget);
                    Report.IsTrue(Context.Contains(savedAs), $"Failure, failed to save the first widget to context as: '{savedAs}'.", $"Success, saved the first widget to context as: '{savedAs}'.");
                    return;
                }
            }
            Report.Failure("Failed to add a widget with graph to context");
        }

        /// <summary>
        /// uses a default savedAs 'ThisWidget'
        /// </summary>
        [RegexStepDefinition("I save the first widget containing a graph to context")]
        public void SaveFirstWidgetWithGraph()
        {
            var widgets = new Home().WidgetTitles;
            foreach (var title in widgets)
            {
                var thisWidget = new Home.Widget(title);
                if (thisWidget.GraphContentDisplayed())
                {
                    Context.AddToContext("ThisWidget", thisWidget);
                    return;
                }
            }
            Report.Failure("Failed to add a widget with graph to context");
        }

        [RegexStepDefinition("I save the first widget containing a (Bar Graph|Pie Chart) to context")]
        public void SaveFirstWidgetWithGraphChart(string displayType)
        {
            var widgets = new Home().WidgetTitles;
            foreach (var title in widgets)
            {
                var thisWidget = new Home.Widget(title);
                if (thisWidget.GraphContentDisplayed() && thisWidget.Type == displayType)
                {
                    Context.AddToContext("ThisWidget", thisWidget);
                    return;
                }
            }
            Report.Failure("Failed to add a widget with graph to context");
        }

        [RegexStepDefinition("I save the current list of widgets to context as: (.*)")]
        public void SaveTheCurrentListOfWidgetsToContextAs(string savedAs)
        {
            Report.Info($"Attempting to save the list of widget titles as: '{savedAs}'.");
            List<WidgetPage.Widget> widgetList = new List<WidgetPage.Widget>();
            List<string> widgetTitles = new Home().WidgetTitles;
            foreach(string widgetTitle in widgetTitles)
            {
                WidgetPage.Widget widget = new Home.Widget(widgetTitle);
                widgetList.Add(widget);
            }
            Context.AddToContext(savedAs, widgetList);
            return;
        }

        [RegexStepDefinition("I save the current list of widgets to context as default")]
        public void SaveTheCurrentListOfWidgetsToContextAsDefault()
        {
            SaveTheCurrentListOfWidgetsToContextAs("WidgetList");
        }

        [RegexStepDefinition(@"I confirm a menu list is shown below the three dots icon for the saved widget")]
        public void ConfirmMenuList()
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title is: " + widget.Title);
            Report.IsTrue(widget.GraphMenuListDisplayed(), "Graph Menu list was not displayed!", "Graph menu list was displayed");
        }

        [RegexStepDefinition(@"I confirm the graph menu list displays the following options:")]
        public void ConfirmMenuListDisplays(Table options)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title is: " + widget.Title);
            foreach (var row in options.Rows)
            {
                var option = row["Option"];
                Report.Info("Expected option is: " + option);
                Report.IsTrue(widget.DropDownItemDisplayed(option), "Option: " + option + " was not displayed in the drop down list!", "Option was displayed in the dropdown list");
            }
        }

        [RegexStepDefinition(@"In the graph menu list I confirm I see a (.*) icon to the left of the option: (.*)")]
        public void ConfirmIconForGraphDropdownMenuOption(string icon, string option)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title is: " + widget.Title);
            if (!widget.DropDownItemDisplayed(option))
            {
                Report.Failure("Dropdown menu item: " + option + " was not displayed!");
                return;
            }
            string iconClass;
            switch (icon)
            {
                case "pie chart":
                    iconClass = "fa fa-pie-chart";
                    break;
                case "edit":
                    iconClass = "fa fa-edit";
                    break;
                case "excel":
                    iconClass = "fa fa-file-excel-o";
                    break;
                default:
                    iconClass = null;
                    break;
            }
            var displayedIcon = widget.IconForDropDownItem(option);
            Report.IsTrue(displayedIcon == iconClass, "Expected icon: " + icon + " with class: " + iconClass + " but found icon with class: " + displayedIcon, "Icon " + icon + " was displayed as expected");
        }

        [RegexStepDefinition(@"I confirm graph content (is|is not) displayed for the saved widget")]
        public void GraphContent(string isIsNot)
        {
            bool displayed = false;
            if (isIsNot == "is")
            {
                displayed = true;
            }
            else if (isIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title is: " + widget.Title);
            Report.IsTrue(widget.GraphContentDisplayed() == displayed, $"Graph content {(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Graph content {(displayed ? "was" : "was not")} displayed as expected");
        }

        [RegexStepDefinition(@"I confirm data content (is|is not) displayed for the saved widget")]
        public void DataContent(string isIsNot)
        {
            bool displayed = false;
            if (isIsNot == "is")
            {
                displayed = true;
            }
            else if (isIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            Report.Info("Saved widget title is: " + widget.Title);
            Report.IsTrue(widget.DataContentDisplayed() == displayed, $"Data content {(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Data content {(displayed ? "was" : "was not")} displayed as expected");
        }

        [RegexStepDefinition(@"I save the current titles for the graph view in the widget with title: (.*) as: (.*)")]
        public void SaveGraphTitlesAss(string widgetTitle, string savedAs)
        {
            Report.Info($"Getting to get the titles for widget: {widgetTitle}");
            List<string> graphTitles = new Home.Widget(widgetTitle).GetCurrentGraphTitles();
            Report.IsTrue(!graphTitles.IsNullOrEmpty(), "The List of graph titles was empty, failed to get the titles", "Successfully got the Graph Titles");
            Context.AddToContext(savedAs, graphTitles);
            Report.IsTrue(Context.Contains(savedAs), "Failed to find: " + savedAs + " in context", "Successfully saved the list of graph titls to context as: " + savedAs);

        }

        [RegexStepDefinition(@"In the widget with title: (.*), I confirm that when I select the section with title: (.*) that the titles saved as: (.*) no longer appear")]
        public void InWidgetIConfirmWhenISelectTitleThatLowerLevelDataIsShown(string widgetTitle, string sectionTitle, string savedAs, string finalChart = "No")
        {
            Report.Info($"Getting the current Graph sections for the widget with title: {widgetTitle}");
            List<IWebElement> currentGraphSections = new Home.Widget(widgetTitle).GetGraphSections();
            if (currentGraphSections.IsNullOrEmpty())
            {
                currentGraphSections = new Home.Widget(widgetTitle).GetPieChartSections();
            }
            Report.Info($"Finding the postion of: {sectionTitle} within the graph");
            var currentTitles = (List<string>)Context.GetFromContext(savedAs);
            int i = 0;
            bool titleFound = false;
            if (sectionTitle == "<first>")
            {
                Report.Info("Section title wanted was the first, setting I to be = 0 to select the first graph section");

            }
            else
            {


                foreach (var title in currentTitles)
                {
                    Report.Info($"the section title was: {title}.");
                    if (title == sectionTitle)
                    {
                        Report.Info($"Found the section title as postion {i}");
                        titleFound = true;
                        break;
                    }
                    else
                    {
                        Report.Info($"The section title did not match the expected, moving to the next title");
                        i++;
                    }

                }
                if (titleFound == false)
                {
                    Report.Failure($"Did not find the title: {sectionTitle} in the list of current titles");
                    return;
                }
            }
            new TopBar().RefocusGraph();
            if (currentGraphSections[i].TryClick())
            {

                Report.Success("Succesfully single clicked the section");
                Delay.Seconds(5);
            }
            else
            {
                bool clickedSuccessfully = false;
                int x = 1;
                while (x < 6 && clickedSuccessfully == false)
                {
                    Report.Info("Trying to click the section");
                    currentGraphSections[i].ScrollElementIntoView();
                    if (currentGraphSections[i].TryDoubleClick())
                    {
                        clickedSuccessfully = true;
                        Delay.Seconds(5);
                        Report.Info($"Successfully clicked section on attempt: {x}");
                        break;
                    }
                    Report.Info($"Attempt: {x} at clicking section failed");
                    Delay.Seconds(2);
                    x++;
                }
                Report.IsTrue(clickedSuccessfully, "Failed to double click the section", "Succesfully double clicked the section");
                Delay.Seconds(5);
            }

            if (finalChart == "Yes")
            {
                int x = 0;
                if (widgetTitle == "Supplier Subscription Status")
                {
                    while (new Home.Widget(widgetTitle).SupplierContentDisplayed() == false && x < 10)
                    {
                        Report.Info($"The supplier list was not showing");
                        Delay.Seconds(5);
                        x++;

                    }
                    if (new Home.Widget(widgetTitle).SupplierContentDisplayed() == false)
                    {
                        Report.Failure($"The Supplier list did not appear");
                        return;
                    }
                    else
                    {
                        Report.Success($"The supplier list is now showing, the section was clicked and the next screen loaded correctly");
                        return;
                    }


                }
                else
                {

                    while (new Home.Widget(widgetTitle).ProductContentDisplayed() == false && x < 10)
                    {
                        Report.Info($"The product list was not showing");
                        Delay.Seconds(5);
                        x++;

                    }
                    if (new Home.Widget(widgetTitle).ProductContentDisplayed() == false)
                    {
                        Report.Failure($"The Products list did not appear");
                        return;
                    }
                    else
                    {
                        Report.Success($"The products list is now showing, the section was clicked and the next screen loaded correctly");
                        return;
                    }
                }

            }


            bool diffFound = false;
            int j = 0;
            while (j < 3 && diffFound == false)
            {
                new TopBar().RefocusGraph();
                this.ForWidgetISwitchToView(widgetTitle, "Data");
                List<string> newDataTitles = new Home.Widget(widgetTitle).GetCurrentDataTitles();
                var differences = currentTitles.Except(newDataTitles);
                diffFound = differences.Any();
                Report.Info("Wating for 5 seconds...");
                Delay.Seconds(5);
                j++;
            }
            Report.Info("Checking the titles are no longer showing...");
            Report.IsTrue(diffFound, "The titles were still showing", "The titles were no longer showing");
            this.ForWidgetISwitchToView(widgetTitle, "Graph");
            new TopBar().RefocusGraph();

        }


        [RegexStepDefinition(@"In the widget with title: (.*), I confirm that when I select the Back button that the titles saved as: (.*) no longer appear")]
        public void InWidgetIConfirmWhenISelectBackButtonThatUpperLevelDataIsShown(string widgetTitle, string savedAs)
        {


            var currentTitles = (List<string>)Context.GetFromContext(savedAs);
            Report.IsTrue(new Home.Widget(widgetTitle).ClickGraphViewBackButton(), "Failed to click the graph view back button", "Successfully clicked the graph view back button");
            bool diffFound = false;
            int j = 0;
            while (j < 5 && diffFound == false)
            {
                this.ForWidgetISwitchToView(widgetTitle, "Data");
                List<string> newDataTitles = new Home.Widget(widgetTitle).GetCurrentDataTitles();
                var differences = currentTitles.Except(newDataTitles);
                diffFound = differences.Any();
                Delay.Seconds(5);
                j++;
            }

            Report.IsTrue(diffFound, "The titles were still showing", "The titles were no longer showing");
            this.ForWidgetISwitchToView(widgetTitle, "Graph");

        }

        [RegexStepDefinition(@"For the Widget with title: (.*), I switch to the data view from the the actions menu")]
        public void ForWidgetISwitchToDataView(string widgetTitle)

        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep($"Attempting to click the drop down menu for the widget titled: {widgetTitle}");
            Report.IsTrue(new Home.Widget(widgetTitle).ClickWidgetDropdownToggle(), "Failed to click the drop down toggle", "Successfully clicked the drop down toggle");
            Report.StartStep($"Attempting to click the option 'data' from the drop down menu");
            Report.IsTrue(new Home.Widget(widgetTitle).ClickDropDownItem("Data"), "Failed to click the Data Option", "Successfully clicked the data option");
            Report.IsTrue(new Home.Widget(widgetTitle).DataContentDisplayed(), "The data content was not displayed", "Data content ws displayed");

        }

        [RegexStepDefinition(@"For the Widget with title: (.*), I switch to the: (.*) view from the the actions menu")]
        public void ForWidgetISwitchToView(string widgetTitle, string option)

        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            var iWidget = new Home.Widget(widgetTitle);
            Report.StartStep($"Attempting to click the drop down menu for the widget titled: {widgetTitle}");
            Report.IsTrue(iWidget.ClickWidgetDropdownToggle(), "Failed to click the drop down toggle", "Successfully clicked the drop down toggle");
            Report.StartStep($"Attempting to click the option: {option} from the drop down menu");
            Report.IsTrue(iWidget.ClickDropDownItem(option), "Failed to click the " + option + " option", "Successfully clicked the " + option + " option");
            switch (option)
            {
                case "Data":
                    Report.IsTrue(iWidget.DataContentDisplayed(), "The Data content was not displayed", "Data content was displayed");
                    break;
                case "Graph":
                    Report.IsTrue(iWidget.GraphContentDisplayed(), "The Graph content was not displayed", "Graph content was displayed");
                    break;
                default:
                    Report.Failure("The Option must be set to either 'Data' or 'Graph'");
                    break;
            }

            return;
        }

        [RegexStepDefinition(@"I save the current titles for the data view in the widget with title: (.*) as: (.*)")]
        public void SaveDataTitlesAss(string widgetTitle, string savedAs)
        {
            Report.Info($"Attempting to get the data titles for widget: {widgetTitle}");
            List<string> dataTitles = new Home.Widget(widgetTitle).GetCurrentDataTitles();
            Report.IsTrue(!dataTitles.IsNullOrEmpty(), "The List of dat titles was empty, failed to get the titles", "Successfully got the data Titles");
            Context.AddToContext(savedAs, dataTitles);
            Report.IsTrue(Context.Contains(savedAs), "Failed to find: " + savedAs + " in context", "Successfully saved the list of data titles to context as: " + savedAs);

        }

        [RegexStepDefinition(@"I Check that the current titles being displayed for widget: (.*) are the same as those saved as: (.*)")]
        public void CheckThatTheCurrentTitlesBeingDisplayedAreTheSameAs(string widgetTitle, string savedAs)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("Starting to switch to the data view");
            this.ForWidgetISwitchToView(widgetTitle, "Data");
            Report.StartStep("Starting to get the titles for the widget");
            this.SaveDataTitlesAss(widgetTitle, "LatestTitles");
            var latestTitles = (List<string>)Context.GetFromContext("LatestTitles");
            var previousTitles = (List<string>)Context.GetFromContext(savedAs);
            var differences = previousTitles.Except(latestTitles);
            Report.IsTrue(!differences.Any(), "Differences were found between the two sets of titles, the orginal data is not showing", "No Differences were found between the two sets of titles, the orginal data is showing");


        }


        [RegexStepDefinition(@"For the (.*) widget, I save the current titles as: (.*) and check that when I click on the section: (.*) that the titles change")]
        public void ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(string widgetTitle, string savedAs, string sectionTitle)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            Report.StartStep("Attempting to switch to the data view");
            this.ForWidgetISwitchToView(widgetTitle, "Data");
            Report.StartStep("Saving the titles to context");
            this.SaveDataTitlesAss(widgetTitle, savedAs);
            Report.StartStep("Attempting to switch to the graph view");
            this.ForWidgetISwitchToView(widgetTitle, "Graph");
            Report.StartStep("Checking that when a section is clicked, a lower level of data is shown");
            this.InWidgetIConfirmWhenISelectTitleThatLowerLevelDataIsShown(widgetTitle, sectionTitle, savedAs, finalChart: "No");

        }

        [RegexStepDefinition(@"For the widget saved to context, I save the current titles as: (.*) and check that when I click on the section: (.*) that the titles change")]
        public void ForWidgetSavedToContextISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(string savedAs, string sectionTitle)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionTheTitlesChange(widget.Title, savedAs, sectionTitle);
        }

        [RegexStepDefinition(@"I save the current titles as: (.*) and check that when I Click Back that the titles change for the (.*) widget")]
        public void ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickBackTheTitlesChange(string savedAs, string widgetTitle)
        {
            ReportSettings.UseSubSteps = true;
            Report.StartStep("Attempting to switch to the data view");
            this.ForWidgetISwitchToView(widgetTitle, "Data");
            Report.StartStep("Saving the titles to context");
            this.SaveDataTitlesAss(widgetTitle, savedAs);
            Report.StartStep("Attempting to switch to the graph view");
            this.ForWidgetISwitchToView(widgetTitle, "Graph");
            Report.StartStep("Checking that when a section is clicked, a higher level of data is shown");
            this.InWidgetIConfirmWhenISelectBackButtonThatUpperLevelDataIsShown(widgetTitle, savedAs);

        }

        [RegexStepDefinition(@"I Click the hamburger menu for the widget: (.*) and select the option: (.*)")]
        public void IClickTheHamburgerMenuForTheWidgetAndSelectOption(string widgetTitle, string option)
        {
            if (option.ToLower() == "print")
            {
                Report.Error("Due to limitations with selenium we can not handle the print dialog, so skipping this check");
                return;
            }

            Report.IsTrue(new Home.Widget(widgetTitle).GraphHamburgerDisplayed(), "The hamburger menu for the widget with title: " + widgetTitle + " was not showing", "The hamburger menu for the widget with title: " + widgetTitle + " was showing");
            this.ClickGraphHamburger(widgetTitle);
            Report.IsTrue(new Home.Widget(widgetTitle).ClickGraphHamburgerOption(option), "Failed to click the option: " + option, "Successfully clicked the option: " + option);
        }

        [RegexStepDefinition(@"I Click the hamburger menu for the saved widget and select the option: (.*)")]
        public void IClickTheHamburgerMenuForTheSavedWidgetAndSelectOption(string option)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            IClickTheHamburgerMenuForTheWidgetAndSelectOption(widget.Title, option);
        }

        [RegexStepDefinition(@"I Check that the Hamburger menu dropdown for widget: (.*) is displayed")]
        public void ICheckTheHamburgerMenuIsDisplayed(string widgetTitle)
        {
            Report.IsTrue(new Home.Widget(widgetTitle).GraphHamburgerMenuDisplayed(), "The Hamburger menu dropdown was not displayed", "The Hamburger menu dropdown was displayed");

        }

        [RegexStepDefinition(@"I Check that the Options displayed in the Hamburger menu for widget: (.*) are as follows:")]
        public void ICheckHamburgerMenuOptions(string widgetTitle, Table table)
        {
            List<string> optionsStrings = new Home.Widget(widgetTitle).GetHamburgerOptions();
            List<string> expectedOptions = new List<string>();
            table.Rows.Cast<TableRow>().ToList().ForEach(x => expectedOptions.Add(x["Options"]));
            Report.Info($"Exepcted options count: {expectedOptions.Count}");
            Report.Info($"Found options count: {optionsStrings.Count}");
            Report.IsTrue(optionsStrings.Count == expectedOptions.Count, "The number options expected did not match the number of options found", "The numbe of options found matched the number of option expected");
            bool pass = true;
            foreach (var option in optionsStrings)
            {
                if (!expectedOptions.Contains(option))
                {
                    Report.Failure($"The expected option: {option} was not found");
                    pass = false;
                }
                else
                {
                    Report.Info($"The expected option: {option} was found");
                }
            }

        }













        [RegexStepDefinition(@"I Confirm that the Graph for the widget: (.*) is a: (Pie Chart|Bar Graph)")]
        public void IConfirmGraphTypeForWidget(string widgetTitle, string graphType)
        {
            Report.Info($"Attempting to get the type of graph for the chosen widget...");
            string foundType = new Home.Widget(widgetTitle).GetTypeOfGraph();
            Report.Info($"The type of graph found was: {foundType}");
            Report.IsTrue(foundType == graphType, "The Type of graph found did not match the expected", "The type of graph found was as expected");

        }

        [RegexStepDefinition(@"I select a piece of the pie chart for the widget: (.*)")]
        public void ThenISelectAPieceOfThePieChartForTheWidgetSupplierSubscriptionStatus(string widgetTitle)
        {
            Report.Info($"Attempting to get the type of graph for the chosen widget...");
            string foundType = new Home.Widget(widgetTitle).GetTypeOfGraph();
            Report.Info($"The type of graph found was: {foundType}");
            Report.IsTrue(new Home.Widget(widgetTitle).SelectPieceOfPieChart(), "Failed to click piece of pie chart", "Successfully clicked piece of pie chart");
        }

        [RegexStepDefinition(@"I confirm that a scroll bar is present for the widget: (.*)")]
        public void IConfirmThatAScrollBarIsPresentForWidget(string widgetTitle)
        {
            Report.Info($"Attempting to find the scroll bar for the chosen widget...");
            Report.IsTrue(new Home.Widget(widgetTitle).ScrollBarIsPresent(), "No Scroll Bar was found", "A scroll bar was present");
        }

        [RegexStepDefinition(@"I Check that if required, a scroll bar is present for the Widget: (.*)")]
        public void ICheckThatScrollBarPresentIfRequired(string widgetTitle)
        {
            Report.Info($"Checking that the widget is a Bar Graph");
            string foundType = new Home.Widget(widgetTitle).GetTypeOfGraph();
            Report.Info($"The type of graph found was: {foundType}");
            if (foundType == "Pie Chart")
            {
                Report.Info("The Type of graph was a Pie Chart, a scroll bar is not required");
                return;
            }
            if (foundType == "Bar Graph")
            {
                List<IWebElement> barGraphSections = new Home.Widget(widgetTitle).GetGraphSections();
                if (barGraphSections.Count > 11)
                {
                    this.IConfirmThatAScrollBarIsPresentForWidget(widgetTitle);
                    return;

                }
                else
                {
                    Report.Info("There was not enough sections to require a scroll bar");
                    return;
                }
            }
            else
            {
                Report.Failure("The type of graph found did not match one of the expected types");
                return;
            }
        }

        [RegexStepDefinition(@"I save the (Data|Graph) View Titles (with|with out) Count for the widget: (.*) as: (.*)")]
        public void ISaveTheTitleForWidgetAs(string viewType, string useCount, string widgetTitle, string savedAs)
        {
            Report.Info($"Looking at the widget with title: {widgetTitle}");
            List<string> titleFound = new List<string>();
            if (viewType == "Data")
            {
                Report.Info("Looking at the Data View Titles");
                if (useCount == "with")
                {
                    Report.Info("Looking for titles with count");
                    titleFound = new Home.Widget(widgetTitle).GetCurrentDataTitlesWithCount();
                }
                if (useCount == "with out")
                {
                    Report.Info("Looking for titles with out count");
                    titleFound = new Home.Widget(widgetTitle).GetCurrentDataTitles();
                }
            }
            if (viewType == "Graph")
            {
                Report.Info("Looking at the Graph View Titles");
                if (useCount == "with")
                {
                    Report.Info("Looking for titles with count");
                    titleFound = new Home.Widget(widgetTitle).GetCurrentGraphTitlesWithCount();
                }
                if (useCount == "with out")
                {
                    Report.Info("Looking for titles with out count");
                    titleFound = new Home.Widget(widgetTitle).GetCurrentGraphTitles();
                }
            }
            Report.IsTrue(titleFound.Any(), "Titles were not Found", "Titles were Found");
            Report.Info("saving the titles found to context");
            Context.AddToContext(savedAs, titleFound);
        }

        [RegexStepDefinition(@"For the Widget: (.*) I select the section with title: (.*)")]
        public void ForWidgetISelectSection(string widgetTitle, string sectionTitle)
        {


            ReportDetails.CurrentDetails.UseSubSteps = true;
            Report.StartStep("Attempting to switch to the data view");
            this.ForWidgetISwitchToView(widgetTitle, "Data");
            Report.StartStep("Saving the titles to context");
            this.SaveDataTitlesAss(widgetTitle, "CurrentTitles");
            Report.StartStep("Attempting to switch to the graph view");
            this.ForWidgetISwitchToView(widgetTitle, "Graph");
            Report.Info($"Getting the current Graph sections for the widget with title: {widgetTitle}");
            List<IWebElement> currentGraphSections = new Home.Widget(widgetTitle).GetGraphSections();
            if (currentGraphSections.IsNullOrEmpty())
            {
                currentGraphSections = new Home.Widget(widgetTitle).GetPieChartSections();
            }
            Report.Info($"Finding the postion of: {sectionTitle} within the graph");
            var currentTitles = (List<string>)Context.GetFromContext("CurrentTitles");
            int i = 0;
            bool titleFound = false;
            if (sectionTitle == "<first>")
            {
                Report.Info("The title section to select will be the first title in the list of found sections");
            }
            else
            {
                foreach (var title in currentTitles)
                {
                    Report.Info($"the section title was: {title}.");
                    if (title == sectionTitle)
                    {
                        Report.Info($"Found the section title as postion {i}");
                        titleFound = true;
                        break;
                    }
                    else
                    {
                        Report.Info($"The section title did not match the expected, moving to the next title");
                        i++;
                    }

                }
                if (titleFound == false)
                {
                    Report.Failure($"Did not find the title: {sectionTitle} in the list of current titles");
                    return;
                }
            }

            if (currentGraphSections[i].TryClick())
            {
                Report.Success("Succesfully single clicked the section");
            }
            else
            {
                bool clickedSuccessfully = false;
                int x = 1;
                while (x < 6 && clickedSuccessfully == false)
                {
                    Report.Info("Trying to click the section");
                    if (currentGraphSections[i].TryDoubleClick())
                    {
                        clickedSuccessfully = true;
                        Report.Info($"Successfully clicked section on attempt: {x}");
                        break;
                    }
                    Report.Info($"Attempt: {x} at clicking section failed");
                    Delay.Seconds(2);
                    x++;
                }
                Report.IsTrue(clickedSuccessfully, "Failed to double click the section", "Succesfully double clicked the section");
            }

        }

        [RegexStepDefinition(@"For the saved widget I select the section with title: (.*)")]
        public void ForSavedWidgetISelectSection(string sectionTitle)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            ForWidgetISelectSection(widget.Title, sectionTitle);
        }

            [RegexStepDefinition(@"I confirm graph content (is|is not) displayed for the widget: (.*)")]
        public void GraphContentDisplayedForTitle(string isIsNot, string widgetTitle)
        {
            bool displayed = false;
            if (isIsNot == "is")
            {
                displayed = true;
            }
            else if (isIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }

            Report.IsTrue(new Home.Widget(widgetTitle).GraphContentDisplayed() == displayed, $"Graph content {(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Graph content {(displayed ? "was" : "was not")} displayed as expected");

        }

        [RegexStepDefinition(@"I confirm Data content (is|is not) displayed for the widget: (.*)")]
        public void DataContentDisplayedForTitle(string isIsNot, string widgetTitle)
        {
            bool displayed = false;
            if (isIsNot == "is")
            {
                displayed = true;
            }
            else if (isIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }

            Report.IsTrue(new Home.Widget(widgetTitle).DataContentDisplayed() == displayed, $"Data content {(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Data content {(displayed ? "was" : "was not")} displayed as expected");

        }

        [RegexStepDefinition(@"I confirm Product content (is|is not) displayed for the widget: (.*)")]
        public void ProductContentDisplayedForTitle(string isIsNot, string widgetTitle)
        {
            bool displayed = false;
            if (isIsNot == "is")
            {
                displayed = true;
            }
            else if (isIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }

            Report.IsTrue(new Home.Widget(widgetTitle).ProductContentDisplayed() == displayed, $"Product content {(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Product content {(displayed ? "was" : "was not")} displayed as expected");

        }

        [RegexStepDefinition(@"I confirm Product content (is|is not) displayed for the saved widget")]
        public void ProductContentDisplayedForSavedWidget(string isIsNot)
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            ProductContentDisplayedForTitle(isIsNot, widget.Title);
        }

            [RegexStepDefinition(@"I wait for the all widgets to finish loading")]
        public void WaitForAllWidgets()
        {
            Report.IsTrue(new Home().WaitWidgetSpinnerFinish(), "The widgets did not finish loading", "The widgets have finished loading");
        }

        [RegexStepDefinition(@"I get the current Legend Items for the widget: (.*) and save them as: (.*)")]
        public void IGetCurrentLegendItemsForAndSaveThemAs(string widgetTitle, string savedAs)
        {
            var LegendItemList = new WidgetPage.Widget(widgetTitle).GetCurrentLegendItems();
            Report.IsTrue(!LegendItemList.IsNullOrEmpty(), "Failed to get the Legend items, the list was empty", "The List contained legend items");
            Context.AddToContext(savedAs, LegendItemList);

        }

        [RegexStepDefinition(@"In the (.*) widget, I confirm that a legend is shown")]
        public void InTheWidgetConfirmLegendIsShownn(string widgetTitle)
        {
            var LegendItemList = new WidgetPage.Widget(widgetTitle).GetCurrentLegendItems();
            Report.IsTrue(!LegendItemList.IsNullOrEmpty(), "There was no legend", "The Legend was shown");
        }

        [RegexStepDefinition(@"In the (.*) widget, I confirm that a legend is not shown")]
        public void InTheWidgetConfirmLegendIsNotShownn(string widgetTitle)
        {
            var LegendItemList = new WidgetPage.Widget(widgetTitle).GetCurrentLegendItems();
            Report.IsTrue(LegendItemList.IsNullOrEmpty(), "The Legend was shown", "There was no legend");

        }



        [RegexStepDefinition(@"I click on the legend item: (.*) from the List saved as: (.*), for widget: (.*)")]
        public void IClickOnTheLegendItemForWidget(string legendTitle, string savedAs, string widget)
        {

            if (!Context.Contains(savedAs))
            {
                Report.Failure($"Could not find the legend list saved as: {savedAs} in context");
                return;
            }
            var legendList = (List<WidgetPage.Widget.LegendItem>)Context.GetFromContext(savedAs);
            Report.IsTrue(new WidgetPage.Widget(widget).ClickLegendSection(legendTitle, legendList), "Failed to Click the Legend Section", "Successfully clicked the legend section");

        }

        [RegexStepDefinition(@"I confirm the (.*) widget is refreshed and the section with title: (.*) is (removed|not removed) from the pie chart")]
        public void WidgetIsRefreshedAndPieChartSectionRemoved(string widget, string sectionTitle, string presence)
        {
            Report.IsTrue(new Home().WaitWidgetSpinnerFinish(), "The widgets did not finish loading", "The widgets have finished loading");
            Report.IsTrue(new Home.Widget(widget).GraphContentDisplayed(), "The Graph Content was not displayed", "The Graph Content was being displayed");
            int i = 0;
            while (i < 10)
            {

                //var refreshedPiesections = new WidgetPage.Widget(widget).GetCurrentPieChartItems();
                //WidgetPage.Widget.PieChartItem wantedItem = refreshedPiesections.FirstOrDefault(x => x.ItemTitle.Contains(sectionTitle));
                //if (wantedItem == null)
                //{
                //    Report.Success("The section we are looking for was not found in the list of sections");
                //    return;

                //}
                //else
                //{
                //    Report.Info("The section was still found in the pie chart");
                //    Delay.Seconds(3);
                //}
                if (presence == "removed")
                {
                    if (new WidgetPage.Widget(widget).CheckPieChartSectionRemoved(sectionTitle))
                    {
                        Report.Success("The section we are looking for was not found in the list of sections");
                        return;
                    }
                    else
                    {
                        Report.Info("The section was still found in the pie chart");
                        Delay.Seconds(3);
                    }
                }
                if (presence == "not removed")
                {
                    if (!new WidgetPage.Widget(widget).CheckPieChartSectionRemoved(sectionTitle))
                    {
                        Report.Success("The section we are looking for was found in the list of sections");
                        return;
                    }
                    else
                    {
                        Report.Info("The section was not found in the pie chart");
                        Delay.Seconds(3);
                    }
                }
            }
            Report.Failure("The section was still found in the pie chart after 30 seconds");

        }

        [RegexStepDefinition(@"I confirm for the widget: (.*) that the legend entry: (.*) is found and in a grey font in the legend list")]
        public void LegendEntryIsFoundInGreyFont(string widget, string sectionTitle)
        {
            Report.IsTrue(new Home().WaitWidgetSpinnerFinish(), "The widgets did not finish loading", "The widgets have finished loading");
            Report.IsTrue(new Home.Widget(widget).GraphContentDisplayed(), "The Graph Content was not displayed", "The Graph Content was being displayed");


            int i = 0;
            while (i < 10)
            {

                this.IGetCurrentLegendItemsForAndSaveThemAs(widget, "RefreshedLengedItems");
                var refreshedLegendItem = (List<WidgetPage.Widget.LegendItem>)Context.GetFromContext("RefreshedLengedItems");
                WidgetPage.Widget.LegendItem wantedItem = refreshedLegendItem.FirstOrDefault(x => x.ItemTitle.Contains(sectionTitle));
                if (wantedItem != null)
                {

                    Report.Success("The legend item we are looking for was found in the legend chart");
                    Report.IsTrue(wantedItem.ItemElement.GetAttribute("class").Contains("hidden"), "The element class was not showing as hidden", "The element class was showing as hidden");
                    new TopBar().RefocusGraph();
                    IWebElement textEl = wantedItem.ItemElement.FindElement(By.XPath(".//*[name()='text']"), 2);
                    IWebElement dotEl = wantedItem.ItemElement.FindElement(By.XPath(".//*[name()='rect']"), 2);
                    string textElColor = textEl.GetCssValue("color");
                    string dotElColor = dotEl.GetCssValue("fill");
                    if (textElColor == "rgba(204, 204, 204, 1)" && dotElColor == "rgb(204, 204, 204)")
                    {
                        Report.Success("The Legend Items color was grey");
                        return;
                    }
                    else
                    {
                        Report.Info("The Legend Items color was not Grey");
                        Delay.Seconds(3);
                    }
                }
                else
                {
                    Report.Failure("The Legend item was was not found in the legend Chart");
                    return;
                }



            }
            Report.Failure("The legend item was not grey after 30 seconds");


        }

        [RegexStepDefinition(@"I click the three dots menu icon and select the Export option for the widget: (.*)")]
        public void ForWidgetISelectThreeDotsMenuAndClickExport(string widget)
        {
            new Steps_Home().ClickDropDownToggle(widget);
            new Steps_Home().ClickDropdownOptionWidget("Export", widget);
        }

        [RegexStepDefinition(@"For the (.*) widget, I save the current titles as: (.*) and check that when I click on the section: (.*) that the products data view is seen.")]
        public void ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatProductDataSeen(string widgetTitle, string savedAs, string sectionTitle)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            Report.StartStep("Attempting to switch to the data view");
            this.ForWidgetISwitchToView(widgetTitle, "Data");
            Report.StartStep("Saving the titles to context");
            this.SaveDataTitlesAss(widgetTitle, savedAs);
            Report.StartStep("Attempting to switch to the graph view");
            this.ForWidgetISwitchToView(widgetTitle, "Graph");
            Report.StartStep("Checking that when a section is clicked, a lower level of data is shown");
            this.InWidgetIConfirmWhenISelectTitleThatLowerLevelDataIsShown(widgetTitle, sectionTitle, savedAs, finalChart: "Yes");

        }

        [RegexStepDefinition(@"For the widget that has title: (.*), I click the back button in the Products List and confirm a graph is displayed")]
        public void ForWidgetClickProductsGridBackButtonAndConfrimGraphDisplayed(string widgetTitle)
        {
            Report.IsTrue(new Home.Widget(widgetTitle).ClickProductsListBackButton(), "Failed to click the back button", "Successfully clicked the back button");
            Report.IsTrue(new Home.Widget(widgetTitle).WaitUntilGraphXIsDisplayed(), "The graph content did not appear", "The graph content was shown");
        }

        [RegexStepDefinition(@"For the saved widget, I click the back button in the Products List and confirm a graph is displayed")]
        public void ForSavedWidgetClickProductsGridBackButtonAndConfrimGraphDisplayed()
        {
            Home.Widget widget = new Home().GetWidget("%ThisWidget%");
            ForWidgetClickProductsGridBackButtonAndConfrimGraphDisplayed(widget.Title);
        }

            [RegexStepDefinition(@"In the widget (.*), I confirm I see a Contact Supplier link to the right of the product details for the Product with ID: (.*)")]
        public void ForWidgetIConfirmContactSupplierForProduct(string widget, string productID)
        {
            Report.IsTrue(new Home.Widget(widget).ContactSupplierTextFound(productID), "The text 'Contact Supplier' was not found", "The text 'Contact Supplier' was found");
        }

        [RegexStepDefinition(@"For the widget: (.*), I click on the Product Number (.*) and confirm the Product Information pop up is (shown|not shown)")]
        public void IClickProductNumberAndConfirmProductInformationPopupStatus(string widgetTitle, string productID, string status)
        {
            Report.Info("Getting all the product numbers being shown in the Product List");
            bool expectedStatus = true;
            if (status == "shown")
            {
                expectedStatus = true;
            }
            if (status == "not shown")
            {
                expectedStatus = false;
            }
            List<string> currentProductsNumbers = new Home.Widget(widgetTitle).GetCurrentProductNumbers();
            if (productID == "<first>")
            {
                var firstEl = currentProductsNumbers.First();
                IWebElement firstProduct = new Home.Widget(widgetTitle).GetGivenProductLink(firstEl);
                Report.IsTrue(firstProduct.TryClick(), "Failed to click the product", "Successfully clicked the product");
                Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible() == expectedStatus, "The product Information popup did not load", "The Product Information popup was loaded");
            }
            foreach (var number in currentProductsNumbers)
            {
                if (number == productID)
                {
                    IWebElement wantedProduct = new Home.Widget(widgetTitle).GetGivenProductLink(number);
                    Report.IsTrue(wantedProduct.TryClick(), "Failed to click the product", "Successfully clicked the product");
                    Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible() == expectedStatus, "The product Information popup did not load", "The Product Information popup was loaded");
                }
            }
        }

        [RegexStepDefinition(@"I Confirm that the Product Information pop up is (shown|not shown)")]
        public void IConfirmThatTheProductInformationPopupIsInStatus(string status)
        {
            bool expectedStatus = true;
            Report.Info($"expected popup status: {status}");
            if (status == "shown")
            {
                expectedStatus = true;
            }
            if (status == "not shown")
            {
                expectedStatus = false;
            }
            Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible() == expectedStatus, "The product Information popup was not in the expected state", "The Product Information popup was in the expected state");

        }

        [RegexStepDefinition(@"For the Supplier Subscription Status widget, I save the current titles as: (.*) and check that when I click on the section: (.*) that the supplier list view is seen.")]
        public void ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatSupplierListSeen(string savedAs, string sectionTitle)
        {

            ReportSettings.UseSubSteps = true;
            Report.StartStep("Attempting to switch to the data view");
            this.ForWidgetISwitchToView("Supplier Subscription Status", "Data");
            Report.StartStep("Saving the titles to context");
            this.SaveDataTitlesAss("Supplier Subscription Status", savedAs);
            Report.StartStep("Attempting to switch to the graph view");
            this.ForWidgetISwitchToView("Supplier Subscription Status", "Graph");
            Report.StartStep("Checking that when a section is clicked, a lower level of data is shown");
            this.InWidgetIConfirmWhenISelectTitleThatLowerLevelDataIsShown("Supplier Subscription Status", sectionTitle, savedAs, finalChart: "Yes");

        }

        [RegexStepDefinition(@"I confirm Supplier content (is|is not) displayed for the widget: (.*)")]
        public void SupplierContentDisplayedForTitle(string isIsNot, string widgetTitle)
        {
            bool displayed = false;
            if (isIsNot == "is")
            {
                displayed = true;
            }
            else if (isIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }

            Report.IsTrue(new Home.Widget(widgetTitle).SupplierContentDisplayed() == displayed, $"Supplier content {(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Supplier content {(displayed ? "was" : "was not")} displayed as expected");

        }

        [RegexStepDefinition(@"In the Web Viewers drop down menu I select: (.*)")]
        public void InTheWebViewersDropDownMenuISelect(string dropDownOption)
        {
            Report.IsTrue(new Home().SelectWebViewersDropDownOption(dropDownOption), "Failed to select drop down option: " + dropDownOption, "Successfully selected drop down option: " + dropDownOption);
        }

        [RegexStepDefinition(@"I Confirm 404 not found error is displayed")]
        public void IVerifyPageNotFoundErrorIsDisplayed()
        {
            Report.IsTrue(new Home().PageNotFoundErrorDisplayed(), "Failed to display 404 not found page", "Successfully displayed 404 page not found ");
        }



    }

}

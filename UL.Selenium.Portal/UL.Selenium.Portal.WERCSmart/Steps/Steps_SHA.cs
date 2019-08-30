using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.Cache;
using OpenQA.Selenium;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using TReVor.Api.Wrapper.Classes;
using System.IO;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
    [Binding, Scope(Tag = "SHA")]
    public class Steps_SHA
    {
        public object REport { get; private set; }

        [StepDefinition(@"I navigate to Studio")]
        public void GivenINavigateToStudio()
        {
            ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
            if (handles.Count == 0)
            {
                ((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.open();");
            }

            SeleniumBrowser.WebBrowser.SwitchTo().Window(SeleniumBrowser.WebBrowser.WindowHandles.Last());
            SeleniumBrowser.WebBrowser.Url = TestVariables.GetVariableSavedAs("SHAUrl");
            SeleniumBrowser.WebBrowser.WaitForPageLoad();
        }

        [StepDefinition(@"I navigate to Portal")]
        public void GivenINavigateToPortal()
        {
            SeleniumBrowser.WebBrowser.Url = GlobalParameters.TestUrl;
            SeleniumBrowser.WebBrowser.WaitForPageLoad();
        }

        [StepDefinition(@"I login to Studio as Administrator")]
        public void GivenILoginToStudioAsAdministrator()
        {
            var thisStudioLogin = new StudioLogin();
			TReVorTestUsers shaUser = TestUsers.GetUserSavedAs("SHAUser");
            Report.Info("Entering username: " + shaUser.Username);
            thisStudioLogin.Username = shaUser.Username;
            Report.Info("Entering password: " + shaUser.Password);
            thisStudioLogin.Password = shaUser.Password;
            Report.Info("Clicking 'sign in'");
            Report.IsTrue(thisStudioLogin.ClickSignIn(), "Failed to click 'Sign In", "Clicked 'Sign In'");
            Delay.Seconds(3);
            var thisStudioDesktop = new StudioDesktop();
            Report.IsTrue(thisStudioDesktop.Wait_for_load(30), "Studio desktop is not showing as expected.",
                "Studio desktop is showing as expected");
            Report.Info("Studio desktop is loaded");
            var thisStudioTopMenu = new StudioTopMenu();
            Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");
        }

        [StepDefinition(@"I click top menu item: (.*) and submenu item: (.*)")]
        public void GivenIClickTopMenuItemAndSubMenuItem(string menuItem, string submenuItem)
        {
            var thisTopMenu = new StudioTopMenu();
            Report.IsTrue(thisTopMenu.Wait_for_load(30), "Top menu has not loaded", "Top menu has loaded");

            if (submenuItem.Length == 0)
            {
                Report.IsTrue(thisTopMenu.ClickTopMenuItem(menuItem), "Failed to click: " + menuItem,
                    "Successfully clicked: " + menuItem);
            }
            else
            {
                Report.IsTrue(thisTopMenu.ClickSubMenu(menuItem, submenuItem), "Failed to click: " + menuItem,
                    "Successfully clicked: " + menuItem);
            }

        }

        [StepDefinition(@"In SHA Manager Page I click top menu item: (.*)")]
        public void GivenInSHAManagerPageIClickTopMenuItem(string menuItem)
        {
            var thisShaManager = new StudioSHAManager();
            Report.IsTrue(thisShaManager.ClickTopMenuItem(menuItem), "Failed to click: " + menuItem,
                "Successfully clicked: " + menuItem);
        }

        [StepDefinition(@"In SHA Manager Page I click sub menu item: (.*)")]
        public void GivenInSHAManagerPageIClickSubMenuItem(string menuItem)
        {
            var thisShaManager = new StudioSHAManager();
            for (int i = 0; i < 5; i++)
            {
                Report.Info("Attempt " + i.ToString());
                if (thisShaManager.ClickActionsMenuOption(menuItem))
                {
                    Report.Success("Successfully clicked: " + menuItem);
                    return;
                }

                Delay.Seconds(1);
            }

            Report.Failure("Failed to click: " + menuItem);
        }

        [StepDefinition(@"In the the Manage Global Messages dialog I add and save the following messages:")]
        public void GivenIAddTheFollowingMessages(Table table)
        {
            var thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
            Report.IsTrue(thisStudioManageGlobalMessages.Wait_for_load(),
                "Manage Global Messages dialog is not showing", "Manage global messages dialog is showing");
            var ListOfMessages = new List<Message>();
            foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
            {
                var thisMessage = new Message
                {
                    Title = thisRow["Title"]
                };

                if (thisRow["Message"] == "generated")
                {
                    thisMessage.MessageBody = System.Guid.NewGuid().ToString();
                }
                else
                {
                    thisMessage.MessageBody = thisRow["Message"];
                }

                thisMessage.Type = thisRow["Type"];
                thisMessage.Active = (thisRow["Active"].ToLower() == "true");
                thisMessage.Level = thisRow["Level"];
                ListOfMessages.Add(thisMessage);
                Report.IsTrue(thisStudioManageGlobalMessages.AddMessage(thisMessage), "Failed to add message",
                    "Successfully added message");
            }

            Context.AddToContext("Messages", ListOfMessages);
        }

        [StepDefinition(@"I close the Manage Global Messages dialog")]
        public void GivenICloseTheManageGlobalMessagesDialog()
        {
            var thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
            Report.IsTrue(thisStudioManageGlobalMessages.ClickCloseButton(), "Failed to close messages dialog",
                "Successfully closed messages dialog");
        }

        [StepDefinition(@"In SHA Manager Page I select status: (.*)")]
        public void GivenInSHAManagerPageISelectStatus(string status)
        {
            var thisShaManager = new StudioSHAManager();
            Report.IsTrue(thisShaManager.SelectFromStatusFilter(status), "Failed to select status: " + status,
                "Successfully selected status: " + status);
        }

        //|Status|Client|SearchPattern|ProductId|ProductName|DateRange|LastActivityDate|Supplier|User|Reviewer|OnSuspended|
        //|RecertificationActive|GGOnlyProducts|ECommFlowProducts|TReg|OrderNo|SubmissionDate|UPC|ParentUPC|
        //|RecommendedUse|FlashpointRange|PHRange|UNNumber|

        [StepDefinition(@"In SHA Manager ProductSearch page I run search:")]
        public void GivenInSHAManagerPageIRunSearch(TechTalk.SpecFlow.Table table)
        {
            var thisProductSearch = new StudioSHAManagerProductSearch();
            Report.IsTrue(thisProductSearch.Wait_for_load(60), "Product search page has not loaded",
                "Product search page has loaded as expected", false, false);
            var x = table.Rows.ToDictionary(r => r[0], r => r[1]);
            for (int i = 0; i < x.Count; i++)
            {
                Delay.Seconds(1);
                string value = x.Values.ElementAt(i);
                if (x.Values.ElementAt(i).StartsWith("saved as"))
                {
                    var savedAs = x.Values.ElementAt(i).TrimStart("saved as").Trim();
                    value = Context.GetFromContext(savedAs)?.ToString();
                    if (value == null)
                    {
                        throw new Exception("Failed to get required value from context! Saved as: " + savedAs);
                    }
                }
                switch (x.Keys.ElementAt(i))
                {
                    case "Status":
                        Report.IsTrue(thisProductSearch.SelectFromStatusFilter(value),
                            "Failed to set status to: " + value,
                            "Successfully set status to: " + value, false, false);
                        break;
                    case "Client":
                        Report.IsTrue(thisProductSearch.SelectFromClientFilter(value),
                            "Failed to set client", "Successfully set client to: " + value, false,
                            false);
                        break;
                    case "SearchPattern":
                        Report.IsTrue(thisProductSearch.SelectFromSearchPatternFilter(value),
                            "Failed to set search pattern",
                            "Successfully set search pattern to: " + value, false, false);
                        break;
                    case "ProductID":
                    case "ProductId":
                        string prodID = value;
                        if (prodID.ToLower().Contains("savedas"))
                        {
                            string savedAsText = prodID.Replace("savedas", "").Trim();
                            prodID = Context.GetFromContext(savedAsText).ToString().Trim();
                        }

                        Report.IsTrue(thisProductSearch.EnterProductID(prodID),
                            "Failed to set product id", "Successfully set product id to: " + value,
                            false, false);
                        break;
                    case "ProductName":
                        Report.IsTrue(thisProductSearch.EnterProductName(value),
                            "Failed to set product name", "Successfully set product name", false, false);
                        break;
                    case "DateRange":
                        Report.IsTrue(thisProductSearch.SelectFromDateRangeFilter(value),
                            "Failed to set date range", "Successfully set date range", false, false);
                        break;
                    case "DateFrom":
                        Report.IsTrue(thisProductSearch.EnterDateFrom(value),
                            "Failed to set date range", "Successfully set date range", false, false);
                        break;
                    case "DateTo":
                        Report.IsTrue(thisProductSearch.EnterDateTo(value),
                            "Failed to set date range", "Successfully set date range", false, false);
                        break;
                    case "LastActivityDate":
                        Report.IsTrue(thisProductSearch.EnterLastActivityDate(value),
                            "Failed to set activity date", "Successfully set activity date", false, false);
                        break;
                    case "Supplier":
                        Report.IsTrue(thisProductSearch.EnterSupplier(value),
                            "Failed to set supplier", "Successfully set supplier", false, false);
                        break;
                    case "User":
                        Report.IsTrue(thisProductSearch.EnterUser(value),
                            "Failed to set user", "Successfully set user", false, false);
                        break;
                    case "Reviewer":
                        Report.IsTrue(thisProductSearch.EnterReviewer(value),
                            "Failed to set reviewer", "Successfully set reviewer", false, false);
                        break;
                    case "OnSuspended":
                        Report.IsTrue(thisProductSearch.CheckOnSuspended(x.Values.ElementAt(i) == "true"),
                            "Failed to set on suspended", "Successfully set on suspended", false, false);
                        break;
                    case "RecertificationActive":
                        Report.IsTrue(thisProductSearch.CheckRecertificationActive(value == "true"),
                            "Failed to set recertification active", "Successfully set recertification active", false,
                            false);
                        break;
                    case "GGOnlyProducts":
                        Report.IsTrue(thisProductSearch.CheckGoodGuideOnlyProducts(value == "true"),
                            "Failed to set Good Guide only products", "Successfully set Good Guide only products",
                            false, false);
                        break;
                    case "ECommFlowProducts":
                        Report.IsTrue(thisProductSearch.CheckECommFlowProducts(value == "true"),
                            "Failed to set EComm flow products", "Successfully set EComm flow products", false, false);
                        break;
                    case "TReg":
                        Report.IsTrue(thisProductSearch.SelectFromTRegFilter(value),
                            "Failed to set TReg", "Successfully set TReg", false, false);
                        break;
                    case "OrderNo":
                        Report.IsTrue(thisProductSearch.EnterOrderNo(value),
                            "Failed to set order no", "Successfully set order no", false, false);
                        break;
                    case "SubmissionDate":
                        Report.IsTrue(thisProductSearch.EnterSubmissionDate(value),
                            "Failed to set submission date", "Successfully set submission date", false, false);
                        break;
                    case "UPC":
                        Report.IsTrue(thisProductSearch.EnterUPC(value),
                            "Failed to set upc", "Successfully set upc", false, false);
                        break;
                    case "ParentUPC":
                        Report.IsTrue(thisProductSearch.EnterParentUPC(value),
                            "Failed to set parent upc", "Successfully set parent upc", false, false);
                        break;
                    case "RecommendedUse":
                        Report.IsTrue(thisProductSearch.SelectFromRecommendedUseFilter(value),
                            "Failed to set recommended use", "Successfully set parent upc", false, false);
                        break;
                    case "FlashpointRange":
                        Report.IsTrue(thisProductSearch.SelectFromFlashPointRangeFilter(value),
                            "Failed to set Flashpoint range", "Successfully set parent upc", false, false);
                        break;
                    case "PHRange":
                        Report.IsTrue(thisProductSearch.SelectFromPHRangeFilter(value),
                            "Failed to set PH range", "Successfully set PH range", false, false);
                        break;
                    case "UNNumber":
                        Report.IsTrue(thisProductSearch.EnterUNNumber(value),
                            "Failed to set un number", "Successfully set un number", false, false);
                        break;
                    default:
                        throw new Exception("Invalid column name");
                }
            }
            Report.Info("Going to click find");
            Delay.Seconds(1);
            Report.IsTrue(thisProductSearch.ClickButton("Find"), "Failed to click find", "Clicked find", false, false);
            Report.Info("Waiting for loading bar");
            new StudioSHAManager().Wait_For_Loading_Finish();
            Report.Info("Finished waiting for loading");
            Delay.Seconds(1);
            Report.Screenshot();
        }

        [StepDefinition(
            @"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its status is: (.*)")]
        public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(string productSavedAs,
            string status)
        {

            var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
            string ID = ProductDetails.Id;
            Report.Info("Searching for id: " + ID + " and status: " + status);

            //rerun search until status is as expected or give up
            int counter = 0;

            bool found = false;

            while (counter < 10 && !found)
            {
                var thisStudioManager = new StudioSHAManager();
                thisStudioManager.Wait_for_load();
                thisStudioManager.ClickBottomMenuOption("Search");

                var myStepsSha = new Steps_SHA();

                var table = new Table(new string[] {
                    "SearchTerm",
                    "SearchValue"
                });
                table.AddRow(new string[] {
                    "ProductID",
                    ID
                });
                table.AddRow(new string[] {
                    "Status",
                    "All"
                });
                myStepsSha.GivenInSHAManagerPageIRunSearch(table);

                Delay.Seconds(2);
                var mySHAManager = new StudioSHAManager();
                mySHAManager.WaitForProductList(10);

                Product topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
                if (topProductnew != null)
                {
                    if (topProductnew.ID == ID)
                    {
                        if (status.ToLower() == "accepted or completed")
                        {
                            if (topProductnew.Status.ToLower() == "accepted" |
                                topProductnew.Status.ToLower() == "completed")
                            {
                                found = true;
                            }
                        }
                        else
                        {
                            if (status.ToLower() == "submitted")
                            {
                                if (topProductnew.Status.ToLower() == "submitted")
                                {
                                    found = true;
                                }
                            }

                            if (topProductnew.Status.ToLower() == status.ToLower())
                            {
                                found = true;
                            }
                        }
                    }
                }

                counter++;
            }

            Report.IsTrue(found, "Expected: id=" + ID + " and status " + status, "Statuses match");
            /*
			string setStatus = status;
			if (status.ToLower() == "accepted or completed")
			{
				setStatus = "Accepted";
			}
			if (status.ToLower() == "submitted or ghs submitted")
			{
				setStatus = "Submitted";
			}

			while (counter < 10)
			{
				if (status.ToLower() == "accepted or completed")
				{
					if (setStatus == "Accepted")
					{
						setStatus = "Completed";
					}
					else
					{
						setStatus = "Accepted";
					}
				}

				if (status.ToLower() == "submitted or ghs submitted")
				{
					if (setStatus == "Submitted")
					{
						setStatus = "GHS Submitted";
					}
					else
					{
						setStatus = "Submitted";
					}
				}


				var thisStudioManager = new StudioSHAManager();
				thisStudioManager.Wait_for_load();
				Product topProduct = thisStudioManager.GetTopXProducts(1).FirstOrDefault();

				if (topProduct == null || !(topProduct.Status == setStatus && topProduct.ID == ID))
				{
					string filterStatus = setStatus;
					if (filterStatus == "GHS Submitted")
					{
						filterStatus = "Submitted";
					}
					StudioSHAManager myStudioShaManager = new StudioSHAManager();

					myStudioShaManager.ClickBottomMenuOption("Search");

					Steps_SHA myStepsSha = new Steps_SHA();

					TechTalk.SpecFlow.Table table = new TechTalk.SpecFlow.Table(new string[] {
						"SearchTerm",
						"SearchValue"
					});
					table.AddRow(new string[] {
						"ProductID",
						ID
					});
					table.AddRow(new string[] {
						"Status",
						filterStatus
					});
					myStepsSha.GivenInSHAManagerPageIRunSearch(table);

					Delay.Seconds(2);
					StudioSHAManager mySHAManager = new StudioSHAManager();
					mySHAManager.WaitForProductList(10);
					counter++;
				}
				else
				{
					break;
				}

				var topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
				if (topProductnew != null)
				{
					if (status.ToLower() == "accepted or completed")
					{
						if (topProductnew.Status.ToLower() == "accepted" | topProductnew.Status.ToLower() == "accepted")
						{
							Report.IsTrue(topProductnew.ID == ID,
								"Expected: id=" + ID + " and status " + status + " but got: " + topProductnew.ID + " and " +
								topProductnew.Status, "Statuses match");
								break;
						}
					}
					else
					{
						Report.IsTrue(topProductnew.ID == ID && topProductnew.Status == setStatus,
							"Expected: id=" + ID + " and status " + status + " but got: " + topProductnew.ID + " and " +
							topProductnew.Status, "Statuses match");
					}

				}
				else
				{
					Report.Info("No products found");
				}

			}
			*/
        }

		[StepDefinition(@"I confirm that the status of the product saved as: (.*) is: (.*)")]
		public void IConfirmThatTheStatusOfTheProductIs(string productSavedAs, string status)
		{
			status = Context.GetFromContext(status)?.ToString() ?? "";
			this.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(productSavedAs, status);
		}

        [StepDefinition(
            @"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its font is (red|not red) indicating a recertification")]
        public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsAndItsFontIsRedOrNotRedIndicatingARecertification(
            string productSavedAs, string isRed)
        {
            Report.Info("Getting product from context: " + productSavedAs);
            var productDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
            if (productDetails == null)
            {
                Report.Failure("Could not find product in context: " + productSavedAs);
                return;
            }

            string id = productDetails.Id;
            Report.Info("Product ID: " + id);
            Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
            if (topProduct == null || topProduct.ID != id)
            {
                var myStudioShaManager = new StudioSHAManager();
                Report.Info("Clicking search");
                myStudioShaManager.ClickBottomMenuOption("Search");
                var myStepsSha = new Steps_SHA();
                var table = new Table("SearchTerm", "SearchValue");
                table.AddRow("ProductID", id);
                table.AddRow("Status", "All");
                myStepsSha.GivenInSHAManagerPageIRunSearch(table);
                Delay.Seconds(2);
                var mySHAManager = new StudioSHAManager();
                mySHAManager.WaitForProductList(10);
            }

            Product topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
            if (topProductnew != null)
            {
                Report.Info("Found top product");
                if (isRed == "red")
                {
                    Report.Info("The text for product " + id + " should be red because a recertification is active");
                    Report.IsTrue(topProductnew.ID == id && topProductnew.ColourRGB == "rgb(205, 10, 10)",
                        "Expected: id=" + id + " and colour: rgb(205, 10, 10) but got: " + topProductnew.ID + " and " +
                        topProductnew.ColourRGB, "Colours match");
                }
                else if (isRed == "not red")
                {
                    Report.Info(
                        "The text for product " + id + " should be not red because no recertification is active");
                    Report.IsTrue(topProductnew.ID == id && topProductnew.ColourRGB != "rgb(205, 10, 10)",
                        "Expected: id=" + id + " and NOT colour red: rgb(205, 10, 10) but got: " + topProductnew.ID +
                        " and " + topProductnew.ColourRGB,
                        "Text colour for ID " + id + " was not red as expected");
                }
                else
                {
                    Report.Info("The text colour condition parameter must be either 'red' or 'not red' for this step!");
                }
            }
            else
            {
                Report.Failure("No products found");
            }
        }

        [StepDefinition(@"In the SHA manager grid I right click against product saved as: (.*)")]
        public void GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(string savedAs)
        {
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string ID = ProductDetails.Id;

            Report.IsTrue(new StudioSHAManager().RightClickProductByID(ID), "Failed to rightclick against: " + ID,
                "Right clicked against: " + ID);
        }


        [StepDefinition(@"In the SHA manager grid when the right click context menu is open I select option: (.*)")]
        public void GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption(string option)
        {
            var thisContextMenu = new RightClickProductMenu();
            Report.IsTrue(thisContextMenu.SelectOption(option), "Failed to select option: " + option,
                "Selected option: " + option);
        }

        [StepDefinition(@"In the Product Recertification History popup I should see the following entry")]
        public void GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(Table table)
        {
            var thisProductRecertificationHistory = new ProductRecertificationHistory();
            thisProductRecertificationHistory.Wait_for_load(30);
            thisProductRecertificationHistory.WaitForTableLoad();
            Report.Screenshot();
            List<Product> ListOfRecertificationProducts = thisProductRecertificationHistory.GetProducts();
            Report.Info("Found " + ListOfRecertificationProducts.Count.ToString() + " recertification products");

            bool allPassed = true;

            foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
            {
                string id = "";
                if (thisRow["Product ID"].ToLower().Contains("saved as"))
                {
                    var productDetails =
                        (ProductInformation)Context.GetFromContext(thisRow["Product ID"].Replace("saved as", "")
                            .Trim());
                    id = productDetails.Id;
                }
                else
                {
                    id = thisRow["Product ID"];
                }

                Product thisProduct = ListOfRecertificationProducts.FirstOrDefault(x => x.ID == id);
                if (thisProduct == null)
                {
                    Report.Error("Product with id: " + id + " was not found");
                    allPassed = false;
                }
                else
                {
                    Report.Info("Product with id: " + id + " was found");

                    if (thisProduct.Active == (thisRow["Active"] == "true"))
                    {
                        Report.Info("Active matched: " + thisRow["Active"]);
                    }
                    else
                    {
                        Report.Info("Active did not match. Expected: " + thisRow["Active"] + " but got: " +
                                    thisProduct.Active);
                        allPassed = false;
                    }

                    if (thisProduct.RecertificationReason == thisRow["Recertification Reason"])
                    {
                        Report.Info("Recertification matched: " + thisRow["Recertification Reason"]);
                    }
                    else
                    {
                        Report.Info("Recertification reason did not match. Expected: " +
                                    thisRow["Recertification Reason"] + " but got: " +
                                    thisProduct.RecertificationReason);
                        allPassed = false;
                    }

                    if (table.ContainsColumn("Date"))
                    {
                        if (thisRow["Date"].Contains("Within a day of today"))
                        {
                            DateTime now = DateTime.Now;
                            DateTime yesterday = now.AddDays(-1);
                            DateTime tommorrow = now.AddDays(+1);
                            if (thisProduct.RecertificationDate > yesterday &&
                                thisProduct.RecertificationDate <= tommorrow)
                            {
                                Report.Info("Recertification date: " + thisRow["Date"]);
                            }
                            else
                            {
                                Report.Info("Recertification date did not match. Expected date between " +
                                            yesterday.ToString() + " and " + tommorrow.ToString() + " but got: " +
                                            thisProduct.RecertificationDate.ToString());
                                allPassed = false;
                            }
                        }
                        else
                        {
                            var expected = Convert.ToDateTime(thisRow["Date"]);

                            if (thisProduct.RecertificationDate == expected)
                            {
                                Report.Info("Recertification date: " + thisRow["Date"]);
                            }
                            else
                            {
                                Report.Info("Recertification date did not match. Expected: " +
                                            thisRow["Date"] + " but got: " +
                                            thisProduct.RecertificationDate.ToString());
                                allPassed = false;
                            }
                        }
                    }
                }
            }

            Report.IsTrue(allPassed, "Not all products were as expected", "All products listed were as expected");
        }

        [StepDefinition(@"I Close the Product Recertification History pop up")]
        public void GivenICloseTheProductRecertificationHistoryPopUp()
        {
            var thisProductRecertificationHistory = new ProductRecertificationHistory();
            Report.IsTrue(thisProductRecertificationHistory.ClickButton("Close"),
                "Failed to click close on the recertification history popup",
                "Successfully clicked close on the recertification history popup");
        }

        [StepDefinition(@"I confirm there is no product entry listed with Recertification Reason: (.*)")]
        public void IDoNotSeeAnEntryWithRecertificationReason(string reason)
        {
            List<Product> recertificationProducts = new ProductRecertificationHistory().GetProducts();
            Report.IsTrue(recertificationProducts.All(x => x.RecertificationReason != reason),
                "There was a product with Recertification Reason: " + reason + " which was not expected!",
                "As expected there were no products in the list with Recerficiation Reason: " + reason);
        }

        [StepDefinition(
            @"I Confirm the Product ID: (.*) is highlited yellow indicating that this is an e-comm/direct ship product")]
        public void ConfirmProductIdIsHighlightedYellow_EcommDirectShipProduct(string id)
        {
            var selStudioShaManager = new StudioSHAManager();

            if (!int.TryParse(id, out int n))
            {
                var thisProdInfo = (ProductInformation)Context.GetFromContext(id);
                id = thisProdInfo.Id;
            }

            Report.Info("Waiting for id to change colour");
            Report.IsTrue(
                selStudioShaManager.WaitForIDToBeStatus(id, 120, "N/A", "kit eCommProduct", false,
                    "rgba(254, 255, 160, 1)"),
                "ID has not turned required colour", "ID is required colour");
        }

        [StepDefinition(
            @"I Confirm the Product ID: (.*) is not highlited yellow indicating that this is not an e-comm/direct ship product")]
        public void ConfirmProductIdIsNotHighlightedYellow_NotEcommDirectShipProduct(string id)
        {
            if (id.ToLower().Contains("saved as"))
            {
                string savedAs = id.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim();
                if (Context.Contains(savedAs))
                {
                    var savedItem = (ProductInformation)Context.GetFromContext(savedAs);
                    id = savedItem.Id;
                }
                else
                {
                    throw new Exception(savedAs + " was not found");
                }
            }

            var selStudioShaManager = new StudioSHAManager();
            string colour = selStudioShaManager.ProductHighlight(id);
            if (colour == null)
            {
                Report.Failure("Unable to get product status for product id: " + id);
                Report.Screenshot();
                return;
            }

            Report.IsTrue(colour != "rgb(254,255,160)",
                "Colour was highlighted with a yellow background when it was not expected to be!",
                "Product was not highlighted yellow background as expected");
        }

        [StepDefinition(@"In SHA Manager I select the following products:")]
        public void GivenInSHAManagerISelectTheFollowingProducts(Table table)
        {
            string ID = "";
            foreach (TechTalk.SpecFlow.TableRow thisProduct in table.Rows)
            {
                if (thisProduct["ProductID"].ToLower().Contains("saved as"))
                {
                    var ProductDetails = (ProductInformation)Context.GetFromContext(thisProduct["ProductID"]
                        .Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
                    ID = ProductDetails.Id;
                }

                var thisStudioSHAManager = new StudioSHAManager();
                Report.IsTrue(thisStudioSHAManager.SelectProductByID(ID), "Failed to select: " + ID, "Selected: " + ID);
            }

        }

        [StepDefinition(@"In SHA Manager I select the first product saved as: (.*)")]
        public void GivenInSHAManagerISelectTheProduct(string savedAs)
        {
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string id = ProductDetails?.Id;
            if (id == null)
            {
                throw new Exception("Could not find product saved to context as: " + savedAs);
            }

            var thisStudioSHAManager = new StudioSHAManager();
            thisStudioSHAManager.SelectProductByID(id);
        }

        [StepDefinition(@"I Click the Process Recertification button")]
        public void GivenIClickTheProcessRecertificationButton()
        {
            var thisStudioSHAManager = new StudioSHAManager();
            Report.IsTrue(thisStudioSHAManager.ClickProcessRecertification(), "Failed to click process recertification",
                "Clicked process recertification");
        }

        [StepDefinition(@"I Confirm the Recertification pop up is shown")]
        public void GivenIConfirmTheRecertificationPopUpIsShown()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.WaitForLoad(60), "Recertification popup is not showing",
                "Recertification popup is showing");
        }

        [StepDefinition(@"I Uncheck the Auto Assign Regulatory Specialist to Product check box")]
        public void GivenIUncheckTheAutoAssignRegulatorySpecialistToProductCheckBox()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.SetAutoAssignRegulatorySpecialistToProduct(false),
                "Failed to uncheck the Auto Assign Regulatory Specialist to Product check box",
                "Unchecked the Auto Assign Regulatory Specialist to Product check box");
        }

        [StepDefinition(@"I Select (.*) from the drop down list for Select Regulatory Specialist")]
        public void GivenISelectFromTheDropDownListForRegulatorySpecialist(string specialist)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.SelectRegulatorySpecialist(specialist),
                "Failed to select: " + specialist,
                "Selected: " + specialist);
        }

        [StepDefinition(@"In the Recertification popup I click (.*)")]
        public void GivenInTheRecertificationPopupIClick(string button)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.ClickButton(button), "Failed to click " + button,
                "Clicked " + button);
        }

        [StepDefinition(@"In the Recertification popup the (.*) button will no longer be shown")]
        public void GivenInTheRecertificationPopupTheButtonWillNoLongerBeShown(string button)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(!thisRecertificationPopup.ButtonExists(button), "Button is showing which should not be",
                "As expected button is not showing");
        }

        [StepDefinition(@"in the Recertification popup I wait for all processing to be completed")]
        public void GivenInTheRecertificationPopupIWaitForAllProcessingToBeCompleted()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.WaitForProcessing(120), "Processing has not completed as expected",
                "Processing has completed as expected");
        }

        [StepDefinition(@"in the Recertification popup I should see the following products as successfully assigned")]
        public void GivenInTheRecertificationPopupIShouldSeeTheFollowingProductsAsSuccessfullyAssigned(
            TechTalk.SpecFlow.Table productsExpected)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            bool passedAll = true;
            List<string> processedInfo = thisRecertificationPopup.GetProcessingMessages();

            string ID = "";
            string expectedString = "";
            var ListOfProducts = new List<ProductInformation>();
            foreach (TechTalk.SpecFlow.TableRow thisProduct in productsExpected.Rows)
            {
                if (thisProduct["ProductID"].ToLower().Contains("saved as"))
                {
                    var ProductDetails = (ProductInformation)Context.GetFromContext(thisProduct["ProductID"]
                        .Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
                    ListOfProducts.Add(ProductDetails);
                    ID = ProductDetails.Id;
                }

                expectedString = "Product: " + ID + " succesfully assigned";

                string match = processedInfo.FirstOrDefault(x => x.Contains(expectedString));
                if (match == null)
                {
                    Report.Info("No match was found for: " + expectedString);
                    passedAll = false;

                }
                else
                {
                    Report.Info("Found: " + match);
                }

            }

            Report.IsTrue(passedAll, "Not all expected messages were found", "All expected messages were found");
        }

        [StepDefinition(@"in the Recertification popup I click on close")]
        public void GivenInTheRecertificationPopupIClickOnClose()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.CloseDialog(), "Clicking on close has not worked as expected",
                "Clicking on close has woked as expected");
        }

        [StepDefinition(@"I Confirm the Recertification pop up is closed")]
        public void GivenIConfirmTheRecertificationPopUpIsClosed()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(!thisRecertificationPopup.WaitForLoad(1), "Recertification popup is not closed",
                "Recertification popup is closed");
        }


        [StepDefinition(@"I confirm UPC number saved as: ""UPC(.*)"" is displayed in the SHA Manager Product UPC list")]
        public void ConfirmUpcIsDisplayedInShaManagerProductUpcList(string savedAs)
        {
            try
            {
                // Switch to window
                string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
                Context.AddToContext("MainWindowHandle", currentHandle);
                ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
                Report.Info("Looking for SHA Manager Product UPC window");
                bool foundWindow = false;
                foreach (string handle in allHandles)
                {
                    Report.Info("Checking handle: " + handle);
                    SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
                    if (SeleniumBrowser.WebBrowser.FindElement(
                            By.XPath(".//h1[contains(text(),'WERCSmart Product ID')]"), 2) != null)
                    {
                        Report.Success("Tab was switched successfully!");
                        Report.Screenshot();
                        foundWindow = true;
                        break;
                    }
                }

                if (!foundWindow)
                {
                    Report.Failure("Failed to find the UPC List window ('SHA Manager Product UPC')");
                    Report.Screenshot();
                }

                // Get Displayed UPCs
                List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
                if (displayedUpcs == null)
                {
                    Report.Failure("Unable to fetch UPC Information from the Product UPC window!");
                    Report.Screenshot();
                    return;
                }

                // Confirm match
                string upc = Context.GetFromContext("UPC" + savedAs).ToString();
                Report.IsTrue(displayedUpcs.Any(x => x.UPCNumber == upc),
                    $@"UPC number ""{upc}"" did not appear on the Product UPC list! UPC numbers were: {string.Join(", ", displayedUpcs)}",
                    $@"UPC number: ""{upc}"" appeared on the Product UPC list as expected");
            }
            catch (NoSuchWindowException)
            {
                Report.Failure("Failed to switch to the SHA Manager Product UPC window!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                Report.Screenshot();
            }
        }

		[StepDefinition(@"I confirm that retailer saved as (.*) appears for UPC saved as UPC(.*)")]
		public void IConfirmThatRetailerAppearsForUPC(string retailer, string savedAs)
		{
			string upc = Context.GetFromContext("UPC" + savedAs).ToString();
			retailer = Context.GetFromContext(retailer)?.ToString() ?? "";

			var studioSHAManager = new StudioSHAManager();

			Report.IsTrue(studioSHAManager.ConfirmRetailerExistsForUPC(retailer, upc), "Failed to find retailer " + retailer + " in list of retailers",
				"Successfully found retailer " + retailer + " in list of retailers.");
		}

        [StepDefinition(@"I close the SHA Manager Product UPC window")]
        public void CloseSHAManagerProductUPCWindow()
        {

        }

        [StepDefinition(@"I edit My Toolbar to add the following options")]
        public void GivenIEditMyToolbarToAddTheFollowingOptions(Table table)
        {
            var thisStepsStudio = new Steps_Studio();
            thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("My Toolbar");
            thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
            thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table);
            thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
        }

        //Search, UPC, Pst/UPC, Status, Reject Submission, Review
        [StepDefinition(@"I click the following option in the bottom menu: (.*)")]
        public void IClickTheFollowingOptionInTheBottomMenu(string option)
        {
            var myStudioShaManager = new StudioSHAManager();
            Report.IsTrue(myStudioShaManager.ClickBottomMenuOption(option), "Failed to click option: " + option,
                "Clicked option: " + option);
        }

        //Comma delimited
        [StepDefinition(@"In the Suspended dialog I Select the following clients: (.*)")]
        public void GivenInTheSuspendedDialogISelectTheFollowingClients(string clientsList)
        {
            var clients = clientsList.Split(',').Select(x => x.Trim()).ToList();
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            thisStudioSHAManagerProductSuspend.Wait_for_load(30);
            Report.IsTrue(thisStudioSHAManagerProductSuspend.SelectClients(clients),
                "Failed to select clients: " + clientsList, "Selected: " + clientsList);
        }

        [StepDefinition(@"In the Suspended dialog in the Select Regulatory Specialist drop down I choose: (.*)")]
        public void GivenInTheSuspendedDialogInTheSelectRegulatorySpecialistDropDownIChoose(string regulatorySpecialist)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.SelectRegulatorySpecialist(regulatorySpecialist),
                "Failed to select regulatory specialist: " + regulatorySpecialist, "Selected: " + regulatorySpecialist);

        }

        [StepDefinition(@"In the Suspended dialog in the Select Subject drop down I choose: (.*)")]
        public void GivenInTheSuspendedDialogInTheSelectSubjectDropDownIChoose(string subject)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.SelectSubject(subject),
                "Failed to select subject: " + subject, "Selected: " + subject);
        }

        [StepDefinition(@"In SHA Manager I select the first product")]
        public void GivenInSHAManagerISelectTheProduct()
        {
            var thisStudioSHAManager = new StudioSHAManager();
            Delay.Seconds(1);
            string id = thisStudioSHAManager.SelectFirstProduct();
            Report.IsTrue(id.Length > 0, "Product " + id + " has not been selected",
                "Product " + id + " has been selected");
            var thisProductInformation = new ProductInformation
            {
                Id = id
            };
            Context.AddToContext("ID", thisProductInformation);
        }

		[StepDefinition(@"I save the first product in the grid with retailers as: (.*)")]
		public void ISaveTheFirstProductInTheGridWithRetailersAs(string savedAs)
		{
			var thisStudioSHAManager = new StudioSHAManager();
			Delay.Seconds(1);
			string id = thisStudioSHAManager.SelectFirstProduct();
			Report.IsTrue(id.Length > 0, "Product " + id + " has not been selected",
							"Product " + id + " has been selected");
			var thisProductInformation = new ProductInformation {
				Id = id
			};
			Context.AddToContext("ID", thisProductInformation);
		}

		[StepDefinition(@"I confirm that retailer saved as (.*) appears in the list of retailers for product (.*)")]
		public void IConfirmThatRetailerAppearsInListOfRetailers(string retailer, string product)
		{
			var thisStudioSHAManager = new StudioSHAManager();
			var ProductDetails = (ProductInformation)Context.GetFromContext(product);
			string ID = ProductDetails.Id;
			retailer = Context.GetFromContext(retailer)?.ToString() ?? "";

			string retailerAbbr = "";
			var abbr = new RetailerAbbreviations();
			abbr.Map.TryGetValue(retailer, out retailerAbbr);

			Report.IsTrue(thisStudioSHAManager.RetailerIsInListOfRetailers(retailerAbbr, ID), "Failed to find retailer " + retailerAbbr + " in list of retailers.",
				"Successfully found retailer " + retailerAbbr + " in list of retailers.");
		}


        [StepDefinition(@"In the Suspended dialog in the Supplier Message field I should see: (.*)")]
        public void GivenInTheSuspendedDialogInTheSupplierMessageFieldIShouldSee(string shouldSee)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();

            string actualMessage = thisStudioSHAManagerProductSuspend.GetSupplierMessage();
            Report.Screenshot();

            actualMessage = actualMessage.Replace(System.Environment.NewLine, " ");

            RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            actualMessage = regex.Replace(actualMessage, " ");

            Report.Info("Actual message length is: " + actualMessage.Length.ToString() +
                        " expected message length is: " + shouldSee.Trim().Length);
            if (actualMessage.Trim() != shouldSee.Trim())
            {
                var builder = new StringBuilder();
                char[] ar1 = actualMessage.ToArray();
                for (int i = 0; i < ar1.Length; i++)
                {
                    if (actualMessage.Length > i + 1 && ar1[i].Equals(shouldSee[i]))
                    {
                        builder.Append(ar1[i]);
                    }
                    else
                    {
                        Report.Info("Failed on actual is: " + ar1[i] + " and expected is: " + shouldSee[i]);
                        break;
                    }
                }

                Report.Info("Matched up to " + builder);
                Report.IsTrue(actualMessage.Trim() == shouldSee.Trim(),
                    "Expected to see: " + shouldSee + " but got: " + actualMessage, "Got message " + actualMessage);
            }
        }

        [StepDefinition(@"In the Suspended dialog in the Supplier Message field I add the following text: (.*)")]
        public void GivenInTheSuspendedDialogInTheSupplierMessageFieldIAddTheFollowingText(string textToAdd)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.AddSupplierMessage(textToAdd),
                "Failed to add message: " + textToAdd, "Added message " + textToAdd);
        }

        [StepDefinition(@"In the Suspended dialog in the Supplier Message field I enter the following text: (.*)")]
        public void GivenInTheSuspendedDialogInTheSupplierMessageFieldIEnterTheFollowingText(string textToAdd)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.EnterSupplierMessage(textToAdd),
                "Failed to add message: " + textToAdd, "Added message " + textToAdd);
        }


        [StepDefinition(@"In the Suspended dialog in the Internal Product Note field I should see: (.*)")]
        public void GivenInTheSuspendedDialogInTheInternalProductNoteFieldIShouldSee(string shouldSee)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            string actualMessage = thisStudioSHAManagerProductSuspend.GetInternalProductNote();
            actualMessage = actualMessage.Replace(System.Environment.NewLine, " ");

            RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            actualMessage = regex.Replace(actualMessage, " ");

            Report.Info("Actual message length is: " + actualMessage.Length.ToString() +
                        " expected message length is: " + shouldSee.Trim().Length);
            if (actualMessage.Trim() != shouldSee.Trim())
            {
                var builder = new StringBuilder();
                char[] ar1 = actualMessage.ToArray();
                for (int i = 0; i < ar1.Length; i++)
                {
                    if (actualMessage.Length > i + 1 && ar1[i].Equals(shouldSee[i]))
                    {
                        builder.Append(ar1[i]);
                    }
                    else
                    {
                        Report.Info("Failed on actual is: " + ar1[i] + " and expected is: " + shouldSee[i]);
                        break;
                    }
                }

                Report.Info("Matched up to " + builder);
                Report.IsTrue(actualMessage.Trim() == shouldSee.Trim(),
                    "Expected to see: " + shouldSee + " but got: " + actualMessage, "Got message " + actualMessage);
            }
        }

        [StepDefinition(@"In the Suspended dialog in the Internal Product Note field I add the following text: (.*)")]
        public void GivenInTheSuspendedDialogInTheInternalProductNoteFieldIAddTheFollowingText(string textToAdd)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.AddInternalProductNote(textToAdd),
                "Failed to add message: " + textToAdd, "Added message " + textToAdd);
        }

        [StepDefinition(@"In the Suspended dialog in the Internal Product Note field I enter the following text: (.*)")]
        public void GivenInTheSuspendedDialogInTheInternalProductNoteFieldIEnterTheFollowingText(string textToAdd)
        {
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.EnterInternalProductNote(textToAdd),
                "Failed to add message: " + textToAdd, "Added message " + textToAdd);
        }

        [StepDefinition(@"In the Suspended dialog I click (.*)")]
        public void GivenInTheSuspendedDialogIClick(string button)
        {
            Delay.Seconds(1);
            var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
            Report.IsTrue(thisStudioSHAManagerProductSuspend.ClickButton(button),
                "Failed to click button: " + button, "Clicked button: " + button);
        }

        //| Type | Notification Date | Subject |
        [StepDefinition(@"In the Notification History Screen I confirm that one of the rows is as follows:")]
        public void ThenInTheNotificationHistoryScreenIConfirmThatOneOfTheRowsIsAsFollows(Table table)
        {
            Report.TableRow(table.Rows[0]);
            Report.Info("Getting displayed notifications");
            var thisProductNotificationHistory = new ProductNotificationHistory();
            List<Notification> notifications = thisProductNotificationHistory.GetNotifications();
            for (int i = 0; i < notifications.Count; i++)
            {
                Notification notification = notifications[i];
                Report.Info("Notification" + i + 1 + ". Type = '" + notification.Type + "'. Notification Date = '" +
                            notification.NotificationDate + "'. Subject = '" + notification.Subject + ".");
            }

            if (table.ContainsColumn("Type"))
            {
                string type = table.Rows[0]["Type"];
                Report.Info("Expected Type: " + type);
                notifications = notifications.Where(x => x.Type.ToLower() == type.ToLower()).ToList();
                if (!notifications.Any())
                {
                    Report.Failure("No notifications of type: " + type + " were found");
                    Report.Screenshot();
                    return;
                }

                Report.Info("Found a notification with the expected Type");
            }

            if (table.ContainsColumn("Notification Date"))
            {
                string expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
                if (table.Rows[0]["Notification Date"].ToLower() != "today")
                {
                    expectedDate = Convert.ToDateTime(table.Rows[0]["Notification Date"]).ToString("yyyy-MM-dd");
                }

                Report.Info("Expected Date: " + expectedDate);
                notifications = notifications.Where(x => x.NotificationDate.ToString("yyyy-MM-dd") == expectedDate)
                    .ToList();
                if (!notifications.Any())
                {
                    Report.Failure("No notifications of date: " + expectedDate + " were found");
                    Report.Screenshot();
                    return;
                }

                Report.Info("Found a notification with the expected Date");
            }

            if (table.ContainsColumn("Subject"))
            {
                string subject = table.Rows[0]["Subject"];
                Report.Info("Expected Subject: " + subject);
                notifications = notifications.Where(x => x.Subject == subject).ToList();
                if (!notifications.Any())
                {
                    Report.Failure("No notifications of subject: " + subject + "were found");
                    Report.Screenshot();
                    return;
                }

                Report.Info("Found a notification with the expected Subject");
            }

            Report.Success("The expected row was displayed");
            Report.Screenshot();
        }

        [StepDefinition(@"In the Notification History Screen I click on the most recent notification")]
        public void ThenInTheNotificationHistoryScreenIClickOnTheMostRecentNotification()
        {
            var thisProductNotificationHistory = new ProductNotificationHistory();
            thisProductNotificationHistory.OrderNotificationsByDate("desc");
            Delay.Seconds(1);
            Report.IsTrue(thisProductNotificationHistory.ClickTopItem(), "Failed to click most recent notification",
                "Clicked most recent notification");

        }

        //| Subject | Message| Notification Date |
        [Then(@"In the Notification History Detail Screen I confirm that details are as follows")]
        public void ThenInTheNotificationHistoryDetailScreenIConfirmThatDetailsAreAsFollows(Table table)
        {
            var thisProductNotificationHistory = new ProductNotificationHistory();
            Notification thisNotification = thisProductNotificationHistory.GetNotificationDetails();

            if (table.ContainsColumn("Subject"))
            {
                Report.IsTrue(table.Rows[0]["Subject"] == thisNotification.Subject,
                    "Expected subject: " + table.Rows[0]["Subject"] + " but got: " + thisNotification.Subject,
                    "As expected, subject was: " + table.Rows[0]["Subject"]);
            }

            if (table.ContainsColumn("Notification Date"))
            {
                string expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
                if (table.Rows[0]["Notification Date"].ToLower() != "today")
                {
                    expectedDate = Convert.ToDateTime(table.Rows[0]["Notification Date"]).ToString("yyyy-MM-dd");
                }

                Report.IsTrue(expectedDate == thisNotification.NotificationDate.ToString("yyyy-MM-dd"),
                    "Expected date: " + expectedDate + " but got: " +
                    thisNotification.NotificationDate.ToString("yyyy-MM-dd"),
                    "As expected, date was: " + expectedDate);
            }

            if (table.ContainsColumn("Message"))
            {
                string actualMessage = thisNotification.Message;
                string shouldSee = table.Rows[0]["Message"];

                actualMessage = actualMessage.Replace(System.Environment.NewLine, " ");

                RegexOptions options = RegexOptions.None;
                var regex = new Regex("[ ]{2,}", options);
                actualMessage = regex.Replace(actualMessage, " ");

                Report.Info("Actual message length is: " + actualMessage.Length.ToString() +
                            " expected message length is: " + shouldSee.Trim().Length);
                if (actualMessage.Trim() != shouldSee.Trim())
                {
                    var builder = new StringBuilder();
                    char[] ar1 = actualMessage.ToArray();
                    for (int i = 0; i < ar1.Length; i++)
                    {
                        if (actualMessage.Length > i + 1 && ar1[i].Equals(shouldSee[i]))
                        {
                            builder.Append(ar1[i]);
                        }
                        else
                        {
                            Report.Info("Failed on actual is: " + ar1[i] + " and expected is: " + shouldSee[i]);
                            break;
                        }
                    }

                    Report.Info("Matched up to " + builder);
                    Report.IsTrue(actualMessage.Trim() == shouldSee.Trim(),
                        "Expected to see: " + shouldSee + " but got: " + actualMessage, "Got message " + actualMessage);
                }

            }
        }


        [StepDefinition(@"In SHA Manager I set the filter for status to : (.*)")]
        public void GivenInSHAManagerISetTheFilterForStatusTo(string status)
        {
            var myStudioShaManager = new StudioSHAManager();
            TestReport.StartStep("I set the status filter to " + status);
            myStudioShaManager.WaitForProductList(60);
            myStudioShaManager.SelectFromStatusFilter(status);
            Report.Info("Status has been set");
            //This query is often very slow. Sometimes the results appear to have loaded but then several seconds later the
            //spinner appears and the results change.
            Delay.Seconds(10);
            GeneralUtilities.StudioWaitForSpinner();
            myStudioShaManager.WaitForProductList(60);
            //GeneralUtilities.StudioWaitForSpinner();
            Delay.Seconds(10);
            //Wait for top n items to be status Assigned
            int n = 5;
            for (int i = 0; i < 30; i++)
            {
                List<Product> topN = myStudioShaManager.GetTopXProducts(n);
                if (topN.Select(x => x.Status == status).ToList().Count == topN.Count)
                {
                    break;
                }

                Delay.Seconds(1);
            }

            Report.Screenshot();
        }

        [StepDefinition(@"I verify the product saved as: (.*) displays in red with a red box around it")]
        public void GivenIVerifyTheProductDisplaysInRedWithARedBoxAroundIt(string savedAs)
        {
            var myStudioShaManager = new StudioSHAManager();
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string ID = ProductDetails.Id;
            Report.IsTrue(myStudioShaManager.ProductWithIDHasRedBorders(ID), "Product does not have red borders",
                "Product has red borders");

        }

        [StepDefinition(@"In the Notification History Detail Screen I click on: (.*)")]
        public void ThenInTheNotificationHistoryDetailScreenIClickOn(string button)
        {
            var thisProductNotificationHistory = new ProductNotificationHistory();
            thisProductNotificationHistory.ClickButtonInNotificationDetails(button);
        }

        [StepDefinition(@"In SHA Manager grid I click the following top menu item: (.*)")]
        public void GivenInSHAManagerGridIClickTheFollowingTopMenuItem(string item)
        {
            var thiStudioShaManager = new StudioSHAManager();
            switch (item)
            {
                case "Add to Recertification":
                    Report.IsTrue(thiStudioShaManager.ClickAddToRecertification(),
                        "Failed to click add to recertification button", "Clicked add to recertification button");
                    break;
                case "Reports":
                    Report.IsTrue(thiStudioShaManager.ClickReports(), "Failed to click reports button",
                        "Clicked reports button");
                    break;
                case "Export":
                    Report.IsTrue(thiStudioShaManager.ClickExport(), "Failed to click exports button",
                        "Clicked exports button");
                    break;
                case "DataCode Export":
                    Report.IsTrue(thiStudioShaManager.ClickDataCodeExport(), "Failed to click data code export button",
                        "Clicked data code exports button");
                    break;
                case "Auto Assign":
                    Report.IsTrue(thiStudioShaManager.ClickAutoAssign(), "Failed to click auto assign button",
                        "Clicked auto assign button");
                    break;
                default:
                    throw new Exception("The menu item you passed in is not currently available");

            }
        }

        [StepDefinition(@"The Add Product to Recertification screen should be showing")]
        public void ThenTheAddProductToRecertificationScreenShouldBeShowing()
        {
            var thisAddProductToRecertificationDialog =
                new AddProductToRecertificationDialog();
            Report.IsTrue(thisAddProductToRecertificationDialog.Wait_for_load(30),
                "Add Product to Recertification screen has failed to load",
                "Add Product to Recertification screen has loaded");
        }

        [StepDefinition(@"in the Add Product to Recertification screen only the following Reasons are selected:")]
        public void ThenInTheAddProductToRecertificationScreenOnlyTheFollowingReasonsAreSelected(Table table)
        {
            var thisAddProductToRecertificationDialog =
                new AddProductToRecertificationDialog();
            List<string> selectedReasons = thisAddProductToRecertificationDialog.GetSelectedReasons();
            string pattern = @"^\d.0?";
            var regex = new Regex(pattern);
            bool matched = false;
            bool matchedAll = true;
            foreach (TableRow thisRow in table.Rows)
            {
                System.Text.RegularExpressions.Match matchRow = regex.Match(thisRow["Reason"]);
                if (!matchRow.Success)
                {
                    throw new Exception("Row value is not valid: " + thisRow["Reason"]);
                }

                matched = false;
                foreach (string thisReason in selectedReasons)
                {
                    System.Text.RegularExpressions.Match match = regex.Match(thisReason);
                    if (match.Success)
                    {
                        Report.Info(match.Value + " " + matchRow.Value);
                        if (Convert.ToInt16(match.Value) == Convert.ToInt16(matchRow.Value))
                        {
                            Report.Info("Found match for " + thisRow["Reason"]);
                            matched = true;
                            break;
                        }
                    }
                }

                if (!matched)
                {
                    Report.Error("Failed to match: " + thisRow["Reason"]);
                    matchedAll = false;
                }

            }

            Report.IsTrue(matchedAll, "Failed to match all", "Matched all as expected");

        }

        [StepDefinition(
            @"in the Add Product to Recertification screen only the following allow users checkboxes are selected:")]
        public void ThenInTheAddProductToRecertificationScreenOnlyTheFollowingAllowUsersCheckboxesAreSelected(
            Table table)
        {
            var thisAddProductToRecertificationDialog =
                new AddProductToRecertificationDialog();
            List<string> selectedCheckboxes =
                thisAddProductToRecertificationDialog.GetListOfAllowUserCheckboxesChecked();

            Report.IsTrue(
                selectedCheckboxes.OrderBy(x => x)
                    .SequenceEqual(table.Rows.Select(row => row["Checkbox"]).ToList().OrderBy(y => y)),
                "Selected options are not as expected", "Selected options are expected");
        }

        [StepDefinition(@"The SHA Manager UPC List screen should show")]
        public void ThenTheSHAManagerUPCListScreenShouldShow()
        {
            var newStudioSHAManagerProductUPC = new StudioSHAManagerProductUPC();
            Report.IsTrue(newStudioSHAManagerProductUPC.Wait_for_load(30), "UPC List is not showing",
                "UPC List is showing");
        }


        [StepDefinition(@"I confirm the top (\d*) products all have PH Range of: (.*)")]
        public void GivenIConfirmTheTopProductsAllHavePHRangeOf(int n, string phRange)
        {
            var thisStudioShaManager = new StudioSHAManager();
            List<Product> productList = thisStudioShaManager.GetTopXProducts(n);
            var sharedSteps = new Steps_Shared();
            var studioSteps = new Steps_Studio();
            var thisStudioPowerDesignerPlusDesignMode =
                new StudioPowerDesignerPlusDesignMode();
            Report.Info("Checking each product");
            int counter = 1;
            foreach (Product thisProduct in productList)
            {

                var thisPI = new ProductInformation
                {
                    Id = thisProduct.ID
                };
                Context.AddToContext(thisProduct.ID, thisPI);
                if (counter == 1)
                {
                    sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(thisProduct
                        .ID);
                }
                else
                {
                    Report.Info("Going to use quick search");
                    thisStudioPowerDesignerPlusDesignMode.QuickSearch(thisProduct.ID);
                }

                TestReport.StartStep("Looking at id: " + thisProduct.ID);
                thisStudioPowerDesignerPlusDesignMode.Wait_for_load(60);
                //studioSteps.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Chemical Product Checklist");
                TestReport.StartStep("I check the PH value");
                studioSteps.GivenInPowerDesignerIDoubleClickOnCategory("pH value");
                var thisValueEditor = new ValueEditor();
                string currentValue = thisValueEditor.GetSelectedValue();
                double phValue = Convert.ToDouble(currentValue);
                double lowerlimit = 0.0;
                double upperlimit = 0.0;
                switch (phRange)
                {
                    case "<= 2":
                        lowerlimit = 0.0;
                        upperlimit = 2.0;
                        break;
                    case "2.1 - 3.9":
                        lowerlimit = 2.1;
                        upperlimit = 3.9;
                        break;
                    case "4 - 6.9":
                        lowerlimit = 4.0;
                        upperlimit = 6.9;
                        break;
                    case "7 (Neutral)":
                        lowerlimit = 7.0;
                        upperlimit = 7.0;
                        break;
                    case "7.1 - 9.9":
                        lowerlimit = 7.1;
                        upperlimit = 9.9;
                        break;
                    case "10 - 12.4":
                        lowerlimit = 10.0;
                        upperlimit = 12.4;
                        break;
                    case ">= 12.5":
                        lowerlimit = 12.5;
                        upperlimit = 99.0;
                        break;
                }

                Report.IsTrue(phValue >= lowerlimit && phValue <= upperlimit, "PH Value is not as expected",
                    "PH value is as expected");
                thisValueEditor.ClickButton("Cancel");
                counter++;

            }
        }

        [StepDefinition(@"In SHA Manager (\d*) record is found")]
        public void GivenInSHAManagerRecordIsFound(int recordCount)
        {
            var myStudioShaManager = new StudioSHAManager();
            myStudioShaManager.WaitForProductList(60);
            Delay.Seconds(10);
            GeneralUtilities.StudioWaitForSpinner();
            int actualCount = myStudioShaManager.GetProductCount();
            Report.IsTrue(actualCount == recordCount,
                "Expected record count was: " + recordCount + " actual count was: " + actualCount,
                "As expected, record count is: " + actualCount);

        }

        //| SearchTerm | SearchValue                        |
        //| Product    | savedas PackagingTypeID_MPI75034   |
        //| Name       | savedas PackagingTypeName_MPI75034 |
        //| Distrbutor | P                                  |
        [StepDefinition(@"In SHA Manager for the top record the values are as follows")]
        public void GivenInSHAManagerForTheTopRecordTheValuesAreAsFollows(Table table)
        {
            var myStudioShaManager = new StudioSHAManager();
            Product myProduct = myStudioShaManager.GetTopXProducts(1).FirstOrDefault();
            var x = table.Rows.ToDictionary(r => r[0], r => r[1]);
            Report.Info("Checking " + x.Count + " attributes");
            for (int i = 0; i < x.Count; i++)
            {
                Report.Info("Checking: " + x.Keys.ElementAt(i));
                Delay.Seconds(1);
                string expectedValue = "";
                switch (x.Keys.ElementAt(i))
                {
                    case "Product":
                        if (x.Values.ElementAt(i).ToLower().Contains("savedas"))
                        {
                            expectedValue = Context.GetFromContext(x.Values.ElementAt(i)
                                .Replace("savedas", "", StringComparison.OrdinalIgnoreCase).Trim()).ToString();
                        }
                        else
                        {
                            expectedValue = x.Values.ElementAt(i);
                        }

                        Report.IsTrue(myProduct.ID == expectedValue,
                            "Product id was not as expected. Expected " + expectedValue + " but got: " + myProduct.ID,
                            "Product id was as expected: " + expectedValue);
                        break;
                    case "Name":
                        if (x.Values.ElementAt(i).ToLower().Contains("savedas"))
                        {
                            expectedValue = Context.GetFromContext(x.Values.ElementAt(i)
                                .Replace("savedas", "", StringComparison.OrdinalIgnoreCase).Trim()).ToString();
                        }
                        else
                        {
                            expectedValue = x.Values.ElementAt(i);
                        }

                        Report.IsTrue(myProduct.Name == expectedValue,
                            "Product name was not as expected. Expected " + expectedValue + " but got: " +
                            myProduct.Name,
                            "Product name was as expected " + expectedValue);
                        break;
                    case "Distributor":
                        Report.IsTrue(myProduct.Distributor == x.Values.ElementAt(i),
                            "Product distributor was not as expected. Expected: " + x.Values.ElementAt(i) +
                            " but got: " + myProduct.Distributor,
                            "Product distributor was as expected: " + x.Values.ElementAt(i));
                        break;

                    default:
                        throw new Exception("Looking for attribute that does not exist...");
                }
            }
        }

        [StepDefinition(@"In the Add Product to Recertification Screen I select reason number: (\d+)")]
        public void InAddProductToRecertificationScreenSelectReasonByNumber(int number)
        {
            var thisAddProductToRecertificationDialog =
                new AddProductToRecertificationDialog();
            Report.IsTrue(thisAddProductToRecertificationDialog.SelectReasonByNumber(number),
                "Failed to select reason number: " + number.ToString(),
                "Selected reason by number: " + number.ToString());

        }

        [StepDefinition(@"In the Add Product to Recertification Screen I click button: (.*)")]
        public void InAddProductToRecertificationScreenIClickButton(string button)
        {
            var thisAddProductToRecertificationDialog =
                new AddProductToRecertificationDialog();
            Report.IsTrue(thisAddProductToRecertificationDialog.ClickButton(button),
                "Failed to click button: " + button,
                "Clicked button: " + button);

        }

        [StepDefinition(@"In the list of UPCs I should (see|not see) case pack indicatior for UPC: (.*)")]
        public void ConfirmCaseUpc(string condition, string upc)
        {
            try
            {
                // Switch to window
                string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
                Context.AddToContext("MainWindowHandle", currentHandle);
                ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
                Report.Info("Looking for SHA Manager Product UPC window");
                bool foundWindow = false;
                foreach (string handle in allHandles)
                {
                    Report.Info("Checking handle: " + handle);
                    SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
                    if (SeleniumBrowser.WebBrowser.FindElement(
                            By.XPath(".//h1[contains(text(),'WERCSmart Product ID')]"), 2) != null)
                    {
                        Report.Success("Tab was switched successfully!");
                        Report.Screenshot();
                        currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
                        Context.AddToContext("SHAManagerProductUPC", currentHandle);
                        foundWindow = true;
                        break;
                    }
                }

                if (!foundWindow)
                {
                    Report.Failure("Failed to find the UPC List window ('SHA Manager Product UPC')");
                    Report.Screenshot();
                }

                // Get Displayed UPCs
                List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
                if (displayedUpcs == null)
                {
                    Report.Failure("Unable to fetch UPC Information from the Product UPC window!");
                    Report.Screenshot();
                    return;
                }

                // Confirm case indicator match
                if (upc.ToLower().Contains("saved as"))
                {
                    upc = Context
                        .GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
                        .ToString();
                }

                Report.Screenshot();
                if (condition == "see")
                {
                    Report.IsTrue(displayedUpcs.Any(x => x.UPCNumber.Contains(upc + "*")),
                        $@"UPC did not appear Case Pack Indicator on the Product UPC list! UPC numbers were: {string.Join(", ", displayedUpcs)}",
                        $@"UPC appeared with Case Pack Indicator on the Product UPC list as expected");
                }

                if (condition == "not see")
                {
                    Report.IsFalse(displayedUpcs.Any(x => x.UPCNumber.Contains(upc + "*")),
                        $@"UPC did  appear Case Pack Indicator on the Product UPC list! where it should not be, UPC numbers were: {string.Join(", ", displayedUpcs)}",
                        $@"UPC did not appeared with Case Pack Indicator on the Product UPC list as expected");
                }
            }
            catch (NoSuchWindowException)
            {
                Report.Failure("Failed to switch to the SHA Manager Product UPC window!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                Report.Screenshot();
            }
        }

		[StepDefinition(@"In the SHA list of UPCs I should (see|not see) UPC: (.*)")]
		public void ShaUPCList(string condition,string upc)
		{
			try
			{
				// Switch to window
				string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
					if (SeleniumBrowser.WebBrowser.FindElement(
							By.XPath(".//h1[contains(text(),'WERCSmart Product ID')]"), 2) != null)
					{
						Report.Success("Tab was switched successfully!");
						Report.Screenshot();
						foundWindow = true;
						break;
					}
				}

				if (!foundWindow)
				{
					Report.Failure("Failed to find the UPC List window ('SHA Manager Product UPC')");
					Report.Screenshot();
				}

				List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
				if (displayedUpcs == null)
				{
					Report.Failure("Unable to fetch UPC Information from the SHA UPC window!");
					Report.Screenshot();
					return;
				}

				if (upc.ToLower().Contains("saved as"))
				{
					upc = Context
						.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
				}

				if (condition == "see")
				{
					Report.IsTrue(displayedUpcs.Any(x => x.UPCNumber.Contains(upc)), "UPC: " + upc + " does not display",
						"UPC: " + upc + " displays as expected");
				}

				if (condition == "not see")
				{
					Report.IsTrue(!displayedUpcs.Any(x => x.UPCNumber.Contains(upc)), "UPC: " + upc + " has not been deleted.",
						"UPC: " + upc + " has been deleted as expected.");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				Report.Screenshot();
			}
		}

        [StepDefinition(@"The recertification popup should show")]
        public void TheRecertificationPopupShouldShow()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.WaitForLoad(30), "Recertification popup is not showing",
                "Recertification popup is showing");
        }

        [StepDefinition(@"In the recertification popup I set auto assign checkbox to: (true|false)")]
        public void SetAutoAssignCheckbox(string trueOrFalse)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(
                thisRecertificationPopup.SetAutoAssignRegulatorySpecialistToProduct(trueOrFalse.ToLower() == "true"),
                "Failed to set set auto assign to: " + trueOrFalse,
                "Set auto assign to: " + trueOrFalse);
        }

        [StepDefinition(@"In the recertification popup I select Regulatory Specialist: (.*)")]
        public void SetSpecialist(string specialist)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.SelectRegulatorySpecialist(specialist),
                "Failed to select: " + specialist,
                "Selected: " + specialist);
        }

        [StepDefinition(@"In the recertification popup I click button: (.*)")]
        public void ClickButton(string button)
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(thisRecertificationPopup.ClickButton("button"), "Failed to click button: " + button,
                "Clicked button: " + button);
        }

        [StepDefinition(@"in the Recertification popup I click close button")]
        public void GivenInTheRecertificationPopupIClickCloseButton()
        {
            var thisRecertificationPopup = new RecertificationPopup();
            Report.IsTrue(!thisRecertificationPopup.CloseDialog(), "Dialog has not closed as expected",
                "Dialog has closed as expected");
            Delay.Seconds(3);
        }

        [StepDefinition(@"In the Product Attribute Screen I Confirm the screen shows CNTXT present")]
        public void GivenInTheProductAttributeScreenIConfirmTheScreenShowsCNTXTPresent()
        {
            var thiStudioProductAttributeScreen = new StudioProductAttributeScreen();
            Report.IsTrue(thiStudioProductAttributeScreen.ResultsAreFound(), "No results have been found",
                "Showing as expected");
        }

        [StepDefinition(@"In the Product Attribute Screen I Select the first entry in the table with code: (.*)")]
        public void GivenInTheProductAttributeScreenISelectFirstEntryWithCodeInTheTable(string code)
        {
            var thiStudioProductAttributeScreen = new StudioProductAttributeScreen();
            Report.IsTrue(thiStudioProductAttributeScreen.SelectItemByCode(code), "Failed to select: " + code,
                "Selected item: " + code);
        }

        [StepDefinition(@"I Confirm the Data area of the screen shows (.*)")]
        public void GivenIConfirmTheDataAreaOfTheScreenShows(string expectedData)
        {
            var thiStudioProductAttributeScreen = new StudioProductAttributeScreen();
            List<string> dataItems = thiStudioProductAttributeScreen.GetDataText();
            Report.IsTrue(dataItems.Contains(expectedData), "Data item " + expectedData + " not showing as expected",
                "Data item " + expectedData + " showing as expected");
        }

        [StepDefinition(@"In the SHA Manager Grid I run a search for product saved as: (.*) and its status is: (.*)")]
        public void GivenInTheSHAManagerGridIRunASearchForProductSavedAsTestCaseAndItsStatusIs(string savedAs,
            string status)
        {
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string ID = ProductDetails.Id;
            Report.Info("Searching for id: " + ID + " and status: " + status);
            var myStudioShaManager = new StudioSHAManager();

            myStudioShaManager.ClickBottomMenuOption("Search");

            var myStepsSha = new Steps_SHA();

            var table = new Table(new string[] {
                "SearchTerm",
                "SearchValue"
            });
            table.AddRow(new string[] {
                "ProductID",
                ID
            });
            table.AddRow(new string[] {
                "Status",
                status
            });
            myStepsSha.GivenInSHAManagerPageIRunSearch(table);

            Delay.Seconds(2);
            var mySHAManager = new StudioSHAManager();
            mySHAManager.WaitForProductList(10);
        }

        [StepDefinition(@"In the Product Attribute Screen confirm that no records are found")]
        public void GivenInTheProductAttributeScreenConfirmThatNoRecordsAreFound()
        {
            var thiStudioProductAttributeScreen = new StudioProductAttributeScreen();
            Report.IsTrue(thiStudioProductAttributeScreen.ResultsAreFound(), "Results are showing",
                "As expected results are not showing");
        }

        [StepDefinition(@"I Confirm you see the Document List pop up")]
        public void GivenIConfirmYouSeeTheDocumentListPopUp()
        {
            Report.IsTrue(new SHADocumentList().Wait_for_load(30), "Documnet List pop up is not showing",
                "Document list popup is showing");
        }


        [StepDefinition(
            @"In the Document List popup I Confirm the Filename column shows an entry for xxxxxxx\.pdf - where xxxxxxx is the product id of product saved as: (.*)")]
        public void
            GivenIConfirmTheFilenameColumnShowsAnEntryForXxxxxxx_Pdf_WhereXxxxxxxIsTheProductIdOfProductSavedAsTestCase(
                string savedAs)
        {
            List<string> Documents = new SHADocumentList().GetPDFNames();
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string ID = ProductDetails.Id;
            string expectedFilename = ID + @".pdf";
            Report.Info("Searching for " + expectedFilename);
            Report.IsTrue(Documents.FirstOrDefault(x => x.Contains(expectedFilename)) != null,
                "Filename: " + expectedFilename + " is not showing as expected. Filenames showing are: " +
                string.Join(",", Documents), "Filename: " + expectedFilename + " is showing as expected");
        }

        [StepDefinition(@"In the Document List popup I Double click on the filename for product saved as: (.*)")]
        public void GivenInTheDocumentListPopupIDoubleClickOnTheFilenameForProductSavedAsTestCase(string savedAs)
        {
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string ID = ProductDetails.Id;
            string expectedFilename = ID + @".pdf";
            Report.IsTrue(new SHADocumentList().DoubleClickPDF(expectedFilename),
                "Failed to double click filename: " + expectedFilename, "Clicked filename: " + expectedFilename);
        }

        [StepDefinition(@"I Click (.*) on the Document List window pop up")]
        public void ThenIClickButtonOnTheDocumentListWindowPopUp(string button)
        {
            Report.IsTrue(new SHADocumentList().ClickButton(button),
                "Failed to double click button: " + button, "Clicked button: " + button);
        }

        [StepDefinition(
            @"I should see a new tabbed document with the pdf containing product code saved as: (.*) and NGHS / English twice")]
        public void ThenIShouldSeeANewTabbedDocumentWithThePdfContainingProductCodeSavedAsTestCase(string savedAs)
        {
            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string ID = ProductDetails.Id;
            var thisSHADocument = new SHADocumentList();
            Delay.Seconds(3);
            string docURL = thisSHADocument.DocumentWindowOpen();
            if (docURL != null)
            {
                string pdfText = thisSHADocument.DocumentText(docURL);
                Report.IsTrue(pdfText.Contains(ID), "PDF does not contain: " + ID, "PDF contains " + ID);
                Report.IsTrue(CountStringOccurrences(pdfText, "NGHS / English") == 2,
                    "PDF does not contain: NGHS / English twice", "PDF contains NGHS / English twice");
            }
            else
            {
                Report.Error("Tabbed document has not been found as expected");
            }
        }


        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }

            return count;
        }

        [StepDefinition(@"I click on the Suppliers link on the top right of the screen")]
        public void IClickOnSuppliersLink()
        {
            var thisShaManager = new StudioSHAManager();
            Report.IsTrue(thisShaManager.ClickSuppliersButton(), "Failed to click suppliers button",
                "Clicked suppliers button");
        }

        [StepDefinition(@"The Supplier Manager popup appears")]
        public void TheSupplierManagerPopupAppears()
        {
            var thisStudioSupplierManager = new StudioSupplierManager();
            Report.IsTrue(thisStudioSupplierManager.Wait_for_load(30), "StudioSupplierManager has not opened",
                "StudioSupplierManager has opened");
        }

        [StepDefinition(@"In the Supplier Manager Popup I enter the following search term: (.*)")]
        public void InSupplierManagerPopupIEnterSearchTerm(string searchTerm)
        {
            var thisStudioSupplierManager = new StudioSupplierManager();
            Report.IsTrue(thisStudioSupplierManager.EnterSearchTerm(searchTerm),
                "Failed to enter search term: " + searchTerm,
                "Entered search term: " + searchTerm);
        }

        [StepDefinition(@"In the Supplier Manager Popup I select radio button: (.*)")]
        public void InSupplierManagerPopupISelectRadioButton(string button)
        {
            var thisStudioSupplierManager = new StudioSupplierManager();
            Report.IsTrue(thisStudioSupplierManager.SelectSupplierSearchTypeRadio(button),
                "Failed to select radio button: " + button,
                "Selected radio button: " + button);
        }

        [StepDefinition(@"In the Supplier Manager Popup I click on the search button")]
        public void InSupplierManagerPopupIClickOnTheSearchButton()
        {
            var thisStudioSupplierManager = new StudioSupplierManager();
            Report.IsTrue(thisStudioSupplierManager.ClickSearchButton(), "Failed to click search button",
                "Clicked search button");
        }

        [StepDefinition(@"In the Supplier Manager Popup I save the first search result Supplier Name as: (.*)")]
        public void InSupplierManagerPopupISaveFirstSupplierNameAs(string saveAs)
        {
            var thisStudioSupplierManager = new StudioSupplierManager();
            string name = thisStudioSupplierManager.GetSupplierNames().FirstOrDefault();
            if (name != null)
            {
                Context.AddToContext(saveAs, name);
            }

            Report.IsTrue(name != null, "No name was found",
                "Name: " + name + " was saved as: " + saveAs);
        }

        [StepDefinition(@"In the Supplier Manager Popup I click on the close button")]
        public void InSupplierManagerPopupIClickOnTheCloseButton()
        {
            var thisStudioSupplierManager = new StudioSupplierManager();
            Report.IsTrue(thisStudioSupplierManager.ClickClose(), "Failed to click close button",
                "Clicked close button");
        }

        [StepDefinition(@"I save a product id which blue and has retailers as (.*)")]
        public void GivenISaveAProductIdWhichIsNotRedOrOrangeAndHasRetailersAsTestCase(string saveAs)
        {
            var thisStudioSHAManager = new StudioSHAManager();
            string id = thisStudioSHAManager.ReturnIDOfProductWhichIsBlueAndHasClients();

            if (id != null)
            {
                Context.AddToContext(saveAs, id);
            }

            Report.IsTrue(id != null, "No suitable id was found", "ID: " + id + " was found and saved as: " + saveAs);

        }

		[StepDefinition(@"I save a product which blue and has retailers as (.*)")]
		public void GivenISaveAProductWhichIsNotRedOrOrangeAndHasRetailersAsTestCase(string saveAs)
		{
			var thisStudioSHAManager = new StudioSHAManager();
			ProductInformation info = thisStudioSHAManager.ReturnProductInformationOfProductwithIsBlueAndHasClients();

			if (info != null)
			{
				Context.AddToContext(saveAs, info);
			}

			Report.IsTrue(info != null, "No suitable id was found", "ID: " + info.Id + " was found and saved as: " + saveAs);

		}


		[StepDefinition(@"I save the retailers associated with product (.*) as (.*)")]
		public void ISaveTheRetailersAssociatedWithTheProductAs(string productSavedAs, string retailersSavedAs)
		{
			var thisStudioSHAManager = new StudioSHAManager();
			var product = (ProductInformation)Context.GetFromContext(productSavedAs);
			List<string> retailers = thisStudioSHAManager.ReturnClientsOfProductByID(product.Id);
			Report.IsTrue(retailers != null && retailers.Count > 0, "Failed to find list of retailers!", "Successfully found list of retailers!");
			Context.AddToContext(retailersSavedAs, retailers);
		}

        [StepDefinition(@"I Confirm the Product shows status: (.*) for retailer: (.*)")]
        public void GivenIConfirmTheProductShowsStatusForRetailer(string status, string retailer)
        {
            if (retailer.ToLower().Contains("saved as"))
            {
                if (Context.Contains(retailer.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim()))
                {
                    retailer = Context
                        .GetFromContext(retailer.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
                        .ToString();
                }
                else
                {
                    throw new Exception("There is no saved retailer found");
                }

            }

            var thisStudioSHAManager = new StudioSHAManager();
            List<Product> RetailerStatuses = thisStudioSHAManager.GetTopXProducts(2);

            var thisStepsRetailPartners = new StepsRetailPartners();

            var matchingStatusRows =
                RetailerStatuses.Where(x => x.Status.ToLower() == status.ToLower()).ToList();
            var matchingClients = matchingStatusRows.Select(x => x.Clients)
                .Where(o => thisStepsRetailPartners.MatchAbbreviatedRetailer(o, retailer)).ToList();

            Report.IsTrue(matchingClients.Count != 0,
                "No matching row was found for status: " + status + " and retailer: " + retailer,
                "Matching row was found for status: " + status + " and retailer: " + retailer);

        }

        [StepDefinition(@"I should see a new tabbed document whose URL contains DocumentID")]
        public void ThenIShouldSeeANewTabbedDocumentWhoseURLContainsDocumentID()
        {
            Delay.Seconds(30);
            ReadOnlyCollection<string> allWindowHandles = SeleniumBrowser.WebBrowser.WindowHandles;

            foreach (string thisWindowHandle in allWindowHandles)
            {
                SeleniumBrowser.WebBrowser.SwitchTo().Window(thisWindowHandle);
                Delay.Seconds(2);
                string currentURL = SeleniumBrowser.WebBrowser.Url;
                Report.Info("URL:" + currentURL);
                Report.Screenshot();
                if (SeleniumBrowser.WebBrowser.Url.ToLower().Contains("documentid"))
                {
                    string regexPattern = @"DocumentID=(.*)";
                    Match match = new Regex(regexPattern).Match(currentURL);
                    if (match.Success)
                    {
                        Report.Info("Document id is: " + match.Groups[1].Value);
                    }
                }
            }
        }

        [StepDefinition(@"I confirm all UPC numbers in the list saved as: (.*) are displayed in the SHA Manager Product UPC list")]
        public void ConfirmAllUpcsAreDisplayedInShaManagerProductUpcList(string savedAs)
        {
            try
            {
                // Switch to window
                this.SwitchToProductListUpcWindow();
                // Get Displayed UPCs
                List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
                if (displayedUpcs == null)
                {
                    Report.Failure("Unable to fetch UPC Information from the Product UPC window!");
                    Report.Screenshot();
                    return;
                }

                // Confirm match
                var upcNumbers = (List<string>)Context.GetFromContext(savedAs);
                Report.IsTrue(displayedUpcs.All(x => upcNumbers.Contains(x.UPCNumber)),
                    "Not all UPCs saved as: " + savedAs + " were displayed! Expected: " +
                    string.Join(", ", upcNumbers) + ". but got: " +
                    string.Join(", ", displayedUpcs.Select(x => x.UPCNumber).ToList()));
            }
            catch (NoSuchWindowException)
            {
                Report.Failure("Failed to switch to the SHA Manager Product UPC window!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                Report.Screenshot();
            }
        }

        [StepDefinition(@"I save a UPC number in the SHA Manager Product UPC list to context as: (.*) with report failure: (true|false)")]
        public void SaveUpcNumberInShaManagerProductUpcListAs(string savedAs, bool reportFailure)
        {
            // Switch to window
            this.SwitchToProductListUpcWindow();
            // Get Displayed UPCs
            List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
            if (!displayedUpcs.Any())
            {
                if (reportFailure)
                {
                    Report.Failure("No UPCs were found in the Product UPC window");
                }
                else
                {
                    Report.Info("No UPCs were found in the Product UPC window");
                }
                Report.Screenshot();
                Report.Info("Closing window");
                SeleniumBrowser.WebBrowser.Close();
                Report.Info("Returning to the main window");
                try
                {
                    var handle = Context.GetFromContext("MainWindowHandle").ToString();
                    SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
                    // required to switch to the frame and refresh container
                    new StudioSHAManager().Wait_for_load();
                }
                catch (Exception ex)
                {
                    Report.Failure("Failed to navigate back to main window using MainWindowHandle context");
                    Report.Failure("Exception: " + ex.Message);
                    throw;
                }
                return;
            }
            var upcNumber = displayedUpcs.FirstOrDefault(x => !x.UPCNumber.EndsWith("*"))?.UPCNumber;
            Report.Info("Adding UPC number: " + upcNumber + " to context as: " + savedAs);
            Context.AddToContext(savedAs, upcNumber);
        }

        [StepDefinition(@"I switch to the Product List UPC Window")]
        public void SwitchToProductListUpcWindow()
        {
            try
            {
                // Switch to window
                string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
                Context.AddToContext("MainWindowHandle", currentHandle);
                System.Collections.ObjectModel.ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
                Report.Info("Looking for SHA Manager Product UPC window");
                bool foundWindow = false;
                foreach (string handle in allHandles)
                {
                    Report.Info("Checking handle: " + handle);
                    SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
                    if (SeleniumBrowser.WebBrowser.FindElement(
                            By.XPath(".//div[@class='upcTableOutter']"), 2) != null)
                    {
                        Report.Success("Tab was switched successfully!");
                        Report.Screenshot();
                        foundWindow = true;
                        break;
                    }
                }

                if (!foundWindow)
                {
                    Report.Failure("Failed to find the UPC List window ('SHA Manager Product UPC')");
                    Report.Screenshot();
                    Report.Info("Switching back to main window");
                    SeleniumBrowser.WebBrowser.SwitchTo().Window(currentHandle);
                }
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                Report.Screenshot();
            }

        }

        [Given(@"I create a new file saved as: (.*) to upload using the UPCs saved as:")]
        public void GivenICreateANewFileSavedAsToUploadUsingTheUPCsSavedAs(string savedAs, Table upcs)
        {
            throw new NotImplementedException();
        }


        // I click Sample File link and verify the Upload UPC form
        [StepDefinition(@"I click Sample File link and verify the Upload UPC form and save it as (.*) with data:")]
        public void ClickSampleFileAndVerifyTheUploadUPCForm(string savedAs, Table table)
        {
            var upc = new UPC();
            Report.IsTrue(GeneralUtilities.DeleteFileFromDownloadsFolder("Sample.xlsx"), "", "");
            Report.IsTrue(upc.ClickSampleFileLink(), "Failed to click Sample File link.", "Successfully clicked Sample File link.");
            Report.IsTrue(upc.VerifySampleFile(table, "Sample.xlsx", savedAs), "Failed to validate Sample File", "Successfully validated Sample File");
        }

        [StepDefinition(@"I save a UPC number for any product in the grid to context as: (.*)")]
        [StepDefinition(@"I find a UPC number for any product in the grid and save to context as: (.*)")]
        public void SaveUpcNumberForAnyProduct(string savedAs)
        {
            TestReport.UseSubSteps = true;
            TestReport.StartStep("Getting all product ids from the table");
            //int productsToTry = new StudioSHAManager().GetProductCount();
            var ids = new StudioSHAManager().GetAllProductIds();
            Report.Info("There are " + ids.Count + " product ids");
            //List<Product> products = new StudioSHAManager().GetTopXProducts(10);
            for (int i = 0; i < ids.Count; i++)
            {
                TestReport.StartStep("Saving any UPCs for product on row " + (i + 1));
                string id = ids[i];
                Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
                this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC List");
                this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs, false);
                if (Context.GetFromContext(savedAs) != null)
                {
                    Report.Info("Saved UPC to context");
                    break;
                }
            }
        }

        [StepDefinition(@"I find a UPC number for any product not belonging to Supplier: (.*) in the grid and save to context as: (.*)")]
        public void SaveUpcNumberForAnyProductNotCompany(string notSupplier, string savedAs)
        {
            TestReport.UseSubSteps = true;
            int productsToTry = new StudioSHAManager().GetProductCount();
            Report.Info("There are " + productsToTry + " products");
            List<Product> products = new StudioSHAManager().GetTopXProducts(productsToTry);
            for (int i = 0; i < productsToTry; i++)
            {
                TestReport.StartStep("Saving any UPCs for product on row " + (i + 1));
                string id = products[i].ID;
                if (products[i].Supplier == notSupplier)
                {
                    Report.Info("Product matches supplier: " + notSupplier + " so continuing to the next row");
                    continue;
                }
                Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
                this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC List");
                this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs, false);
                if (Context.GetFromContext(savedAs) != null)
                {
                    Report.Info("Saved UPC to context");
                    break;
                }
            }
        }

        [StepDefinition(@"I confirm that the Current Submission date in SHA Manager matches the date saved as: (.*)")]
        public void IConfirmThatTheCurrentSubmissionDateMatches(string savedAs)
        {
            string date = Context.GetFromContext(savedAs)?.ToString() ?? "";
            Product product = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
            Report.IsTrue(product.CurrentSubmission.ToString() == date, "Current submission date '" + product.CurrentSubmission.ToString() + "' does not match date saved to context '" + date + "'.",
                "Current submission date '" + product.CurrentSubmission.ToString() + "' matches date saved to context '" + date + "'.");
        }

        [StepDefinition(@"In the Authoring menu I select Power Designer Plus")]
        public void InTheAuthoringMenuISelectPowerDesignerPlus()
        {
            var thisTopMenu = new StudioTopMenu();
            Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing");
            Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
                "Failed to navigate to power designer plus", "Navigated to power designer plus");
            Delay.Seconds(3);
            var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
            if (!thisPowerDesignerPlus.Wait_for_load(30))
            {
                var thisStudioPowerDesignerPlusDesignMode =
                    new StudioPowerDesignerPlusDesignMode();
                thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
                thisStudioPowerDesignerPlusDesignMode.ClickMenuAndSubmenuOptions("Home");
                Delay.Seconds(3);
            }

            Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
                "Power designer plus has loaded");
        }
        [StepDefinition(@"I Confirm the Product saved as: (.*) shows the: '(.*)' Status")]
        public void ConfirmProductInCorrectStatus(string savedAs, string status)
        {
            var productStatus = new StudioSHAManager().GetproductStatus(savedAs);
            Report.IsTrue(productStatus.StatusName == status, "The product was not in the status " + status, "The product was in the status " + status);

        }

        [StepDefinition(@"I find the UPC number for: (.*) products in the grid and save them to context starting with: (.*)")]
        public void SaveUpcNumberForXProducts(int numberOfProducts, string savedAs)
        {
            TestReport.UseSubSteps = true;
            Context.AddToContext("numberOfUpcnumbers", numberOfProducts);
            int productsToTry = new StudioSHAManager().GetProductCount();
            Report.Info("There are " + productsToTry + " products");
            List<Product> products = new StudioSHAManager().GetTopXProducts(productsToTry);
            int j = 1;
            for (int i = 0; i < productsToTry; i++)
            {


                TestReport.StartStep("Saving any UPCs for product on row " + (i + 1));
                string id = products[i].ID;
                Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
                this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC List");
                this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs + j, false);

                if (Context.GetFromContext(savedAs + j) != null)
                {
                    Report.Info($"Saved UPC{j} to context");
                    j++;
                    Report.Screenshot();
                    Report.Info("Closing window");
                    SeleniumBrowser.WebBrowser.Close();
                    Report.Info("Returning to the main window");
                    try
                    {
                        var handle = Context.GetFromContext("MainWindowHandle").ToString();
                        SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
                        // required to switch to the frame and refresh container
                        new StudioSHAManager().Wait_for_load();
                    }
                    catch (Exception ex)
                    {
                        Report.Failure("Failed to navigate back to main window using MainWindowHandle context");
                        Report.Failure("Exception: " + ex.Message);
                        throw;
                    }

                }
                if (j > numberOfProducts)
                {
                    break;
                }
            }

        }

        [StepDefinition(@"I add the UPC numbers saved to context starting with: (.*) to the UPC bulk upload spreadsheet: (.*)")]
        public void AddUpcNumbersToBulkUploadSpreadsheet(string savedAs, string spreadsheetSavedAs)
        {
            int numberOfProducts = (int)Context.GetFromContext("numberOfUpcnumbers");

            var spreadSheetFile = (string)Context.GetFromContext(spreadsheetSavedAs);
            var excel = new ExcelUtilities(spreadSheetFile, "Sheet1");

            for (int i = 1; i <= numberOfProducts; i++)
            {
                if (Context.Contains(savedAs + i))
                {
                    var upcNumber = Context.GetFromContext(savedAs + i).ToString();
                    Report.IsTrue(excel.EditCell(i, 0, upcNumber), "Failed to edit UPC" + i + " to: " + upcNumber, "Successfully edited UPC to: " + upcNumber, false, false);
                }
                else
                {
                    Report.Failure("Failed to find: " + savedAs + i + " in context!", false);
                }
            }
        }

        [StepDefinition(@"I find a UPC number for: (.*) products not belonging to Supplier: (.*) in the grid and save to context starting with: (.*)")]
        public void SaveUpcNumberForXProductsNotCompany(int numberOfProducts, string notSupplier, string savedAs)
        {
            TestReport.UseSubSteps = true;
            Context.AddToContext("numberOfUpcnumbers", numberOfProducts);
            int productsToTry = new StudioSHAManager().GetProductCount();
            Report.Info("There are " + productsToTry + " products");
            List<Product> products = new StudioSHAManager().GetTopXProducts(productsToTry);
            int j = 1;
            for (int i = 0; i < productsToTry; i++)
            {
                TestReport.StartStep("Saving any UPCs for product on row " + (i + 1));
                string id = products[i].ID;
                if (products[i].Supplier == notSupplier)
                {
                    Report.Info("Product matches supplier: " + notSupplier + " so continuing to the next row");
                    continue;
                }
                Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
                this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC List");
                this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs + j, false);
                if (Context.GetFromContext(savedAs + j) != null)
                {
                    Report.Info($"Saved UPC{j} to context");
                    j++;
                    Report.Screenshot();
                    Report.Info("Closing window");
                    SeleniumBrowser.WebBrowser.Close();
                    Report.Info("Returning to the main window");
                    try
                    {
                        var handle = Context.GetFromContext("MainWindowHandle").ToString();
                        SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
                        // required to switch to the frame and refresh container
                        new StudioSHAManager().Wait_for_load();
                    }
                    catch (Exception ex)
                    {
                        Report.Failure("Failed to navigate back to main window using MainWindowHandle context");
                        Report.Failure("Exception: " + ex.Message);
                        throw;
                    }
                }
                if (j > numberOfProducts)
                {
                    break;
                }
            }
        }

        [StepDefinition(@"I navigate to SHA Manager and save a UPC to context as: (.*) for trevor account: (.*)")]
        public void NavigateToShaSaveUpcToContext(string upcSavedAs, string accountSavedAs)
        {
            TestReport.UseSubSteps = true;
            TestReport.StartStep("I log in to Studio and open SHA Manager");
            new Steps_Shared().GivenICallShared65080LoginToStudioAndOpenSHAManager();
            TestReport.StartStep("I click Search");
            this.IClickTheFollowingOptionInTheBottomMenu("Search");
			TReVorTestUsers user = TestUsers.GetUserSavedAs(accountSavedAs);
            var username = "";
            if (user != null)
            {
                username = user.Username;
            }
            var table = new Table("Search Term", "Search Value");
            table.AddRow("Status", "Completed");
            table.AddRow("User", username);
            TestReport.StartStep("I run a search for status Completed and user: " + username);
            this.GivenInSHAManagerPageIRunSearch(table);
            TestReport.StartStep("I save the upc for any returned product as: " + upcSavedAs);
            this.SaveUpcNumberForAnyProduct(upcSavedAs);

        }
    }
}



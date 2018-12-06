using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using OpenQA.Selenium;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;
using Match = NPOI.SS.Formula.Functions.Match;


namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "SHA")]
	class Steps_SHA
	{
		[Given(@"I navigate to Studio")]
		public void GivenINavigateToStudio()
		{
			SeleniumBrowser.WebBrowser.Url = TReVor.TestVariables.GetVariableSavedAs("SHAUrl");
			SeleniumBrowser.WebBrowser.WaitForPageLoad();

		}

		[Given(@"I navigate to Portal")]
		public void GivenINavigateToPortal()
		{
			SeleniumBrowser.WebBrowser.Url = GlobalParameters.TestUrl;
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
		}

		[Given(@"I login to Studio as Administrator")]
		public void GivenILoginToStudioAsAdministrator()
		{
			StudioLogin thisStudioLogin = new StudioLogin();
			var shaUser = TReVor.TestUsers.GetUserSavedAs("SHAUser");
			thisStudioLogin.Username = shaUser.Username;
			thisStudioLogin.Password = shaUser.Password;
			thisStudioLogin.ClickSignIn();
			Delay.Seconds(3);
			StudioDesktop thisStudioDesktop = new StudioDesktop();
			Report.IsTrue(thisStudioDesktop.Wait_for_load(30), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
			Report.Info("Studio desktop is loaded");
			StudioTopMenu thisStudioTopMenu = new StudioTopMenu();
			Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");
		}

		[Given(@"I click top menu item: (.*) and submenu item: (.*)")]
		public void GivenIClickTopMenuItemAndSubMenuItem(string menuItem, string submenuItem)
		{
			StudioTopMenu thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(30), "Top menu has not loaded", "Top menu has loaded");
			Report.IsTrue(thisTopMenu.ClickSubMenu(menuItem, submenuItem), "Failed to click: " + menuItem,
				"Successfully clicked: " + menuItem);
		}

		[Given(@"In SHA Manager Page I click top menu item: (.*)")]
		public void GivenInSHAManagerPageIClickTopMenuItem(string menuItem)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			Report.IsTrue(thisShaManager.ClickTopMenuItem(menuItem), "Failed to click: " + menuItem,
				"Successfully clicked: " + menuItem);
		}

		[Given(@"In SHA Manager Page I click sub menu item: (.*)")]
		public void GivenInSHAManagerPageIClickSubMenuItem(string menuItem)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
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

		[Given(@"In the the Manage Global Messages dialog I add and save the following messages:")]
		public void GivenIAddTheFollowingMessages(Table table)
		{
			StudioManageGlobalMessages thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
			Report.IsTrue(thisStudioManageGlobalMessages.Wait_for_load(),
				"Manage Global Messages dialog is not showing", "Manage global messages dialog is showing");
			List<Message> ListOfMessages = new List<Message>();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Message thisMessage = new Message();
				thisMessage.Title = thisRow["Title"];

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

		[Given(@"I close the Manage Global Messages dialog")]
		public void GivenICloseTheManageGlobalMessagesDialog()
		{
			StudioManageGlobalMessages thisStudioManageGlobalMessages = new StudioManageGlobalMessages();
			Report.IsTrue(thisStudioManageGlobalMessages.ClickCloseButton(), "Failed to close messages dialog",
				"Successfully closed messages dialog");
		}

		[Given(@"In SHA Manager Page I select status: (.*)")]
		public void GivenInSHAManagerPageISelectStatus(string status)
		{
			StudioSHAManager thisShaManager = new StudioSHAManager();
			Report.IsTrue(thisShaManager.SelectFromStatusFilter(status), "Failed to select status: " + status,
				"Successfully selected status: " + status);
		}

		//|Status|Client|SearchPattern|ProductId|ProductName|DateRange|LastActivityDate|Supplier|User|Reviewer|OnSuspended|
		//|RecertificationActive|GGOnlyProducts|ECommFlowProducts|TReg|OrderNo|SubmissionDate|UPC|ParentUPC|
		//|RecommendedUse|FlashpointRange|PHRange|UNNumber|

		[StepDefinition(@"In SHA Manager ProductSearch page I run search:")]
		public void GivenInSHAManagerPageIRunSearch(TechTalk.SpecFlow.Table table)
		{
			StudioSHAManagerProductSearch thisProductSearch = new StudioSHAManagerProductSearch();
			Report.IsTrue(thisProductSearch.Wait_for_load(60), "Product search page has not loaded",
				"Product search page has loaded as expected", false, false);
			var x = table.Rows.ToDictionary(r => r[0], r => r[1]);
			for (int i = 0; i < x.Count; i++)
			{
				Delay.Seconds(1);
				switch (x.Keys.ElementAt(i))
				{
					case "Status":
						Report.IsTrue(thisProductSearch.SelectFromStatusFilter(x.Values.ElementAt(i)),
							"Failed to set status to: " + x.Values.ElementAt(i),
							"Successfully set status to: " + x.Values.ElementAt(i), false, false);
						break;
					case "Client":
						Report.IsTrue(thisProductSearch.SelectFromClientFilter(x.Values.ElementAt(i)),
							"Failed to set client", "Successfully set client to: " + x.Values.ElementAt(i), false,
							false);
						break;
					case "SearchPattern":
						Report.IsTrue(thisProductSearch.SelectFromSearchPatternFilter(x.Values.ElementAt(i)),
							"Failed to set search pattern",
							"Successfully set search pattern to: " + x.Values.ElementAt(i), false, false);
						break;
					case "ProductID":
					case "ProductId":
						string prodID = x.Values.ElementAt(i);
						if (prodID.ToLower().Contains("savedas"))
						{
							string savedAsText = prodID.Replace("savedas", "").Trim();
							prodID = Context.GetFromContext(savedAsText).ToString().Trim();
						}

						Report.IsTrue(thisProductSearch.EnterProductID(prodID),
							"Failed to set product id", "Successfully set product id to: " + x.Values.ElementAt(i),
							false, false);
						break;
					case "ProductName":
						Report.IsTrue(thisProductSearch.EnterProductName(x.Values.ElementAt(i)),
							"Failed to set product name", "Successfully set product name", false, false);
						break;
					case "DateRange":
						Report.IsTrue(thisProductSearch.SelectFromDateRangeFilter(x.Values.ElementAt(i)),
							"Failed to set date range", "Successfully set date range", false, false);
						break;
					case "DateFrom":
						Report.IsTrue(thisProductSearch.EnterDateFrom(x.Values.ElementAt(i)),
							"Failed to set date range", "Successfully set date range", false, false);
						break;
					case "DateTo":
						Report.IsTrue(thisProductSearch.EnterDateTo(x.Values.ElementAt(i)),
							"Failed to set date range", "Successfully set date range", false, false);
						break;
					case "LastActivityDate":
						Report.IsTrue(thisProductSearch.EnterLastActivityDate(x.Values.ElementAt(i)),
							"Failed to set activity date", "Successfully set activity date", false, false);
						break;
					case "Supplier":
						Report.IsTrue(thisProductSearch.EnterSupplier(x.Values.ElementAt(i)),
							"Failed to set supplier", "Successfully set supplier", false, false);
						break;
					case "User":
						Report.IsTrue(thisProductSearch.EnterUser(x.Values.ElementAt(i)),
							"Failed to set user", "Successfully set user", false, false);
						break;
					case "Reviewer":
						Report.IsTrue(thisProductSearch.EnterReviewer(x.Values.ElementAt(i)),
							"Failed to set reviewer", "Successfully set reviewer", false, false);
						break;
					case "OnSuspended":
						Report.IsTrue(thisProductSearch.CheckOnSuspended(x.Values.ElementAt(i) == "true"),
							"Failed to set on suspended", "Successfully set on suspended", false, false);
						break;
					case "RecertificationActive":
						Report.IsTrue(thisProductSearch.CheckRecertificationActive(x.Values.ElementAt(i) == "true"),
							"Failed to set recertification active", "Successfully set recertification active", false,
							false);
						break;
					case "GGOnlyProducts":
						Report.IsTrue(thisProductSearch.CheckGoodGuideOnlyProducts(x.Values.ElementAt(i) == "true"),
							"Failed to set Good Guide only products", "Successfully set Good Guide only products",
							false, false);
						break;
					case "ECommFlowProducts":
						Report.IsTrue(thisProductSearch.CheckECommFlowProducts(x.Values.ElementAt(i) == "true"),
							"Failed to set EComm flow products", "Successfully set EComm flow products", false, false);
						break;
					case "TReg":
						Report.IsTrue(thisProductSearch.SelectFromTRegFilter(x.Values.ElementAt(i)),
							"Failed to set TReg", "Successfully set TReg", false, false);
						break;
					case "OrderNo":
						Report.IsTrue(thisProductSearch.EnterOrderNo(x.Values.ElementAt(i)),
							"Failed to set order no", "Successfully set order no", false, false);
						break;
					case "SubmissionDate":
						Report.IsTrue(thisProductSearch.EnterSubmissionDate(x.Values.ElementAt(i)),
							"Failed to set submission date", "Successfully set submission date", false, false);
						break;
					case "UPC":
						Report.IsTrue(thisProductSearch.EnterUPC(x.Values.ElementAt(i)),
							"Failed to set upc", "Successfully set upc", false, false);
						break;
					case "ParentUPC":
						Report.IsTrue(thisProductSearch.EnterParentUPC(x.Values.ElementAt(i)),
							"Failed to set parent upc", "Successfully set parent upc", false, false);
						break;
					case "RecommendedUse":
						Report.IsTrue(thisProductSearch.SelectFromRecommendedUseFilter(x.Values.ElementAt(i)),
							"Failed to set recommended use", "Successfully set parent upc", false, false);
						break;
					case "FlashpointRange":
						Report.IsTrue(thisProductSearch.SelectFromFlashPointRangeFilter(x.Values.ElementAt(i)),
							"Failed to set Flashpoint range", "Successfully set parent upc", false, false);
						break;
					case "PHRange":
						Report.IsTrue(thisProductSearch.SelectFromPHRangeFilter(x.Values.ElementAt(i)),
							"Failed to set PH range", "Successfully set PH range", false, false);
						break;
					case "UNNumber":
						Report.IsTrue(thisProductSearch.EnterUNNumber(x.Values.ElementAt(i)),
							"Failed to set un number", "Successfully set un number", false, false);
						break;
					default:
						throw new Exception("Invalid column name");
				}
			}

			Report.Info("Going to click find");
			Delay.Seconds(1);
			Report.IsTrue(thisProductSearch.ClickButton("Find"), "Failed to click find", "Clicked find", false, false);
			Delay.Seconds(10);
			Report.Info("Waiting for spinner");
			GeneralUtilities.StudioWaitForSpinner();
			thisProductSearch.Wait_for_load(60);
			GeneralUtilities.StudioWaitForSpinner();
			Report.Info("Finished waiting for spinner");
			Delay.Seconds(10);
			Report.Screenshot();

		}

		[StepDefinition(
			@"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its status is: (.*)")]
		public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(
			string productSavedAs, string status)
		{

			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			var ID = ProductDetails.Id;
			Report.Info("Searching for id: " + ID + " and status: " + status);

			//rerun search until status is as expected or give up
			int counter = 0;

			while (counter < 200)
			{
				var thisStudioManager = new StudioSHAManager();
				thisStudioManager.Wait_for_load();
				Product topProduct = thisStudioManager.GetTopXProducts(1).FirstOrDefault();

				if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
				{
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
						status
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

			}

			var topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
			if (topProductnew != null)
			{
				Report.IsTrue(topProductnew.ID == ID && topProductnew.Status == status,
					"Expected: id=" + ID + " and status " + status + " but got: " + topProductnew.ID + " and " +
					topProductnew.Status, "Statuses match");
			}
			else
			{
				Report.Failure("No products found");
			}

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

			var id = productDetails.Id;
			Report.Info("Product ID: " + id);
			var topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
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

			var topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
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

		[Given(@"In the SHA manager grid I right click against product saved as: (.*)")]
		public void GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(string savedAs)
		{
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var ID = ProductDetails.Id;

			Report.IsTrue(new StudioSHAManager().RightClickProductByID(ID), "Failed to rightclick against: " + ID,
				"Right clicked against: " + ID);
		}

		[Given(@"In the SHA manager grid when the right click context menu is open I select option: (.*)")]
		public void GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption(string Option)
		{
			RightClickProductMenu thisContextMenu = new RightClickProductMenu();
			Report.IsTrue(thisContextMenu.SelectOption(Option), "Failed to select option: " + Option,
				"Selected option: " + Option);
		}

		[Given(@"In the Product Recertification History popup I should see the following entry")]
		public void GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(Table table)
		{
			ProductRecertificationHistory thisProductRecertificationHistory = new ProductRecertificationHistory();

			List<Product> ListOfRecertificationProducts = thisProductRecertificationHistory.GetProducts();

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
			var recertificationProducts = new ProductRecertificationHistory().GetProducts();
			Report.IsTrue(recertificationProducts.All(x => x.RecertificationReason != reason),
				"There was a product with Recertification Reason: " + reason + " which was not expected!",
				"As expected there were no products in the list with Recerficiation Reason: " + reason);
		}

		[StepDefinition(
			@"I Confirm the Product ID: (.*) is highlited yellow indicating that this is an e-comm/direct ship product")]
		public void ConfirmProductIdIsHighlightedYellow_EcommDirectShipProduct(string id)
		{
			StudioSHAManager selStudioShaManager = new StudioSHAManager();
			Report.Info("Waiting for id to change colour");
			Report.IsTrue(selStudioShaManager.WaitForIDToBeStatus(id, 120, "N/A", "N/A", true, "rgb(254,255,160)"),
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

			StudioSHAManager selStudioShaManager = new StudioSHAManager();
			var colour = selStudioShaManager.ProductHighlight(id);
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

		[Given(@"In SHA Manager I select the following products:")]
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

				StudioSHAManager thisStudioSHAManager = new StudioSHAManager();
				Report.IsTrue(thisStudioSHAManager.SelectProductByID(ID), "Failed to select: " + ID, "Selected: " + ID);
			}

		}

		[StepDefinition(@"In SHA Manager I select the first product saved as: (.*)")]
		public void GivenInSHAManagerISelectTheProduct(string savedAs)
		{
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = ProductDetails?.Id;
			if (id == null)
			{
				throw new Exception("Could not find product saved to context as: " + savedAs);
			}

			StudioSHAManager thisStudioSHAManager = new StudioSHAManager();
			thisStudioSHAManager.SelectProductByID(id);
		}

		[StepDefinition(@"I Click the Process Recertification button")]
		public void GivenIClickTheProcessRecertificationButton()
		{
			StudioSHAManager thisStudioSHAManager = new StudioSHAManager();
			Report.IsTrue(thisStudioSHAManager.ClickProcessRecertification(), "Failed to click process recertification",
				"Clicked process recertification");
		}

		[StepDefinition(@"I Confirm the Recertification pop up is shown")]
		public void GivenIConfirmTheRecertificationPopUpIsShown()
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(thisRecertificationPopup.WaitForLoad(60), "Recertification popup is not showing",
				"Recertification popup is showing");
		}

		[StepDefinition(@"I Uncheck the Auto Assign Regulatory Specialist to Product check box")]
		public void GivenIUncheckTheAutoAssignRegulatorySpecialistToProductCheckBox()
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(thisRecertificationPopup.SetAutoAssignRegulatorySpecialistToProduct(false),
				"Failed to uncheck the Auto Assign Regulatory Specialist to Product check box",
				"Unchecked the Auto Assign Regulatory Specialist to Product check box");
		}

		[StepDefinition(@"I Select (.*) from the drop down list for Select Regulatory Specialist")]
		public void GivenISelectAutomatedQAShaFromTheDropDownListFor(string specialist)
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(thisRecertificationPopup.SelectRegulatorySpecialist(specialist),
				"Failed to select: " + specialist,
				"Selected: " + specialist);
		}

		[StepDefinition(@"In the Recertification popup I click (.*)")]
		public void GivenInTheRecertificationPopupIClick(string button)
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(thisRecertificationPopup.ClickButton(button), "Failed to click " + button,
				"Clicked " + button);
		}

		[StepDefinition(@"In the Recertification popup the (.*) button will no longer be shown")]
		public void GivenInTheRecertificationPopupTheButtonWillNoLongerBeShown(string button)
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(!thisRecertificationPopup.ButtonExists(button), "Button is showing which should not be",
				"As expected button is not showing");
		}

		[StepDefinition(@"in the Recertification popup I wait for all processing to be completed")]
		public void GivenInTheRecertificationPopupIWaitForAllProcessingToBeCompleted()
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(!thisRecertificationPopup.WaitForProcessing(240), "Processing has not completed as expected",
				"Processing has completed as expected");
		}

		[StepDefinition(@"in the Recertification popup I should see the following products as successfully assigned")]
		public void GivenInTheRecertificationPopupIShouldSeeTheFollowingProductsAsSuccessfullyAssigned(
			TechTalk.SpecFlow.Table productsExpected)
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			bool passedAll = true;
			List<string> processedInfo = thisRecertificationPopup.GetProcessingMessages();

			string ID = "";
			string expectedString = "";
			List<ProductInformation> ListOfProducts = new List<ProductInformation>();
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

				var match = processedInfo.FirstOrDefault(x => x.Contains(expectedString));
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

		[StepDefinition(@"I Confirm the Recertification pop up is closed")]
		public void GivenIConfirmTheRecertificationPopUpIsClosed()
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(!thisRecertificationPopup.WaitForLoad(1), "Recertification popup is not closed",
				"Recertification popup is closed");
		}


		[StepDefinition(@"I confirm UPC number saved as: ""UPC(.*)"" is displayed in the SHA Manager Product UPC list")]
		public void ConfirmUpcIsDisplayedInShaManagerProductUpcList(string savedAs)
		{
			try
			{
				// Switch to window
				var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (var handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
					if (SeleniumBrowser.WebBrowser.FindElement(
						    By.XPath(".//h3[contains(text(),'SHA Manager Product UPC')]"), 2) != null)
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
				var displayedUpcs = new StudioSHAManager().GetUPCs();
				if (displayedUpcs == null)
				{
					Report.Failure("Unable to fetch UPC Information from the Product UPC window!");
					Report.Screenshot();
					return;
				}

				// Confirm match
				var upc = Context.GetFromContext("UPC" + savedAs).ToString();
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

		[StepDefinition(@"I close the SHA Manager Product UPC window")]
		public void CloseSHAManagerProductUPCWindow()
		{

		}

		[StepDefinition(@"I edit My Toolbar to add the following options")]
		public void GivenIEditMyToolbarToAddTheFollowingOptions(Table table)
		{
			Steps_Studio thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
		}

		//Search, UPC, Pst/UPC, Status, Reject Submission, Review
		[StepDefinition(@"I click the following option in the bottom menu: (.*)")]
		public void IClickTheFollowingOptionInTheBottomMenu(string option)
		{
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
			Report.IsTrue(myStudioShaManager.ClickBottomMenuOption(option), "Failed to click option: " + option,
				"Clicked option: " + option);
		}

		//Comma delimited
		[StepDefinition(@"In the Suspended dialog I Select the following clients: (.*)")]
		public void GivenInTheSuspendedDialogISelectTheFollowingClients(string clientsList)
		{
			List<string> clients = clientsList.Split(',').Select(x => x.Trim()).ToList();
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			thisStudioSHAManagerProductSuspend.Wait_for_load(30);
			Report.IsTrue(thisStudioSHAManagerProductSuspend.SelectClients(clients),
				"Failed to select clients: " + clientsList, "Selected: " + clientsList);
		}

		[StepDefinition(@"In the Suspended dialog in the Select Regulatory Specialist drop down I choose: (.*)")]
		public void GivenInTheSuspendedDialogInTheSelectRegulatorySpecialistDropDownIChoose(string regulatorySpecialist)
		{
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.SelectRegulatorySpecialist(regulatorySpecialist),
				"Failed to select regulatory specialist: " + regulatorySpecialist, "Selected: " + regulatorySpecialist);

		}

		[StepDefinition(@"In the Suspended dialog in the Select Subject drop down I choose: (.*)")]
		public void GivenInTheSuspendedDialogInTheSelectSubjectDropDownIChoose(string subject)
		{
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.SelectSubject(subject),
				"Failed to select subject: " + subject, "Selected: " + subject);
		}

		[StepDefinition(@"In SHA Manager I select the first product")]
		public void GivenInSHAManagerISelectTheProduct()
		{
			StudioSHAManager thisStudioSHAManager = new StudioSHAManager();
			Delay.Seconds(1);
			string id = thisStudioSHAManager.SelectFirstProduct();
			Report.IsTrue(id.Length > 0, "Product " + id + " has not been selected",
				"Product " + id + " has been selected");
			ProductInformation thisProductInformation = new ProductInformation();
			thisProductInformation.Id = id;
			Context.AddToContext("ID", thisProductInformation);
		}

		[StepDefinition(@"In the Suspended dialog in the Supplier Message field I should see: (.*)")]
		public void GivenInTheSuspendedDialogInTheSupplierMessageFieldIShouldSee(string shouldSee)
		{
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();

			string actualMessage = thisStudioSHAManagerProductSuspend.GetSupplierMessage();
			Report.Screenshot();

			actualMessage = actualMessage.Replace(System.Environment.NewLine, " ");

			RegexOptions options = RegexOptions.None;
			Regex regex = new Regex("[ ]{2,}", options);
			actualMessage = regex.Replace(actualMessage, " ");

			Report.Info("Actual message length is: " + actualMessage.Length.ToString() +
			            " expected message length is: " + shouldSee.Trim().Length);
			if (actualMessage.Trim() != shouldSee.Trim())
			{
				StringBuilder builder = new StringBuilder();
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
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.AddSupplierMessage(textToAdd),
				"Failed to add message: " + textToAdd, "Added message " + textToAdd);
		}

		[StepDefinition(@"In the Suspended dialog in the Supplier Message field I enter the following text: (.*)")]
		public void GivenInTheSuspendedDialogInTheSupplierMessageFieldIEnterTheFollowingText(string textToAdd)
		{
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.EnterSupplierMessage(textToAdd),
				"Failed to add message: " + textToAdd, "Added message " + textToAdd);
		}


		[StepDefinition(@"In the Suspended dialog in the Internal Product Note field I should see: (.*)")]
		public void GivenInTheSuspendedDialogInTheInternalProductNoteFieldIShouldSee(string shouldSee)
		{
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			string actualMessage = thisStudioSHAManagerProductSuspend.GetInternalProductNote();
			actualMessage = actualMessage.Replace(System.Environment.NewLine, " ");

			RegexOptions options = RegexOptions.None;
			Regex regex = new Regex("[ ]{2,}", options);
			actualMessage = regex.Replace(actualMessage, " ");

			Report.Info("Actual message length is: " + actualMessage.Length.ToString() +
			            " expected message length is: " + shouldSee.Trim().Length);
			if (actualMessage.Trim() != shouldSee.Trim())
			{
				StringBuilder builder = new StringBuilder();
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
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.AddInternalProductNote(textToAdd),
				"Failed to add message: " + textToAdd, "Added message " + textToAdd);
		}

		[StepDefinition(@"In the Suspended dialog in the Internal Product Note field I enter the following text: (.*)")]
		public void GivenInTheSuspendedDialogInTheInternalProductNoteFieldIEnterTheFollowingText(string textToAdd)
		{
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.EnterInternalProductNote(textToAdd),
				"Failed to add message: " + textToAdd, "Added message " + textToAdd);
		}

		[StepDefinition(@"In the Suspended dialog I click (.*)")]
		public void GivenInTheSuspendedDialogIClick(string button)
		{
			Delay.Seconds(1);
			StudioSHAManagerProductSuspend thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.ClickButton(button),
				"Failed to click button: " + button, "Clicked button: " + button);
		}

		//| Type | Notification Date | Subject |
		[StepDefinition(@"In the Notification History Screen I confirm that one of the rows is as follows:")]
		public void ThenInTheNotificationHistoryScreenIConfirmThatOneOfTheRowsIsAsFollows(Table table)
		{
			ProductNotificationHistory thisProductNotificationHistory = new ProductNotificationHistory();
			List<Notification> ListOfNotifications = thisProductNotificationHistory.GetNotifications();
			if (table.ContainsColumn("Type"))
			{
				ListOfNotifications = ListOfNotifications
					.Where(x => x.Type.ToLower() == table.Rows[0]["Type"].ToLower()).ToList();
				if (ListOfNotifications.Count == 0)
				{
					Report.Info("No notifications of type: " + table.Rows[0]["Type"].ToLower() + "have been found");
				}
			}

			if (table.ContainsColumn("Notification Date"))
			{
				string expectedDate = DateTime.Now.ToString("yyyy-MM-dd");
				if (table.Rows[0]["Notification Date"].ToLower() != "today")
				{
					expectedDate = Convert.ToDateTime(table.Rows[0]["Notification Date"]).ToString("yyyy-MM-dd");
				}

				ListOfNotifications = ListOfNotifications
					.Where(x => x.NotificationDate.ToString("yyyy-MM-dd") == expectedDate).ToList();
				if (ListOfNotifications.Count == 0)
				{
					Report.Info("No notifications of date: " + expectedDate + "have been found");
				}
			}

			if (table.ContainsColumn("Subject"))
			{
				ListOfNotifications = ListOfNotifications.Where(x => x.Subject == table.Rows[0]["Subject"]).ToList();
				if (ListOfNotifications.Count == 0)
				{
					Report.Info("No notifications of subject: " + table.Rows[0]["Subject"]);
				}
			}

			Report.IsTrue(ListOfNotifications.Count == 1, "Matching row was not found as expected",
				"Row was found as expected");
		}

		[StepDefinition(@"In the Notification History Screen I click on the most recent notification")]
		public void ThenInTheNotificationHistoryScreenIClickOnTheMostRecentNotification()
		{
			ProductNotificationHistory thisProductNotificationHistory = new ProductNotificationHistory();
			thisProductNotificationHistory.OrderNotificationsByDate("desc");
			Delay.Seconds(1);
			Report.IsTrue(thisProductNotificationHistory.ClickTopItem(), "Failed to click most recent notification",
				"Clicked most recent notification");

		}

		//| Subject | Message| Notification Date |
		[Then(@"In the Notification History Detail Screen I confirm that details are as follows")]
		public void ThenInTheNotificationHistoryDetailScreenIConfirmThatDetailsAreAsFollows(Table table)
		{
			ProductNotificationHistory thisProductNotificationHistory = new ProductNotificationHistory();
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
				Regex regex = new Regex("[ ]{2,}", options);
				actualMessage = regex.Replace(actualMessage, " ");

				Report.Info("Actual message length is: " + actualMessage.Length.ToString() +
				            " expected message length is: " + shouldSee.Trim().Length);
				if (actualMessage.Trim() != shouldSee.Trim())
				{
					StringBuilder builder = new StringBuilder();
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


		[Given(@"In SHA Manager I set the filter for status to : (.*)")]
		public void GivenInSHAManagerISetTheFilterForStatusTo(string status)
		{
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
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
				if (topN.Select(x => x.Status == status).ToList().Count == n)
				{
					break;
				}

				Delay.Seconds(1);
			}

			Report.Screenshot();
		}

		[Given(@"I verify the product saved as: (.*) displays in red with a red box around it")]
		public void GivenIVerifyTheProductDisplaysInRedWithARedBoxAroundIt(string savedAs)
		{
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var ID = ProductDetails.Id;
			Report.IsTrue(myStudioShaManager.ProductWithIDHasRedBorders(ID), "Product does not have red borders",
				"Product has red borders");

		}

		[StepDefinition(@"In the Notification History Detail Screen I click on: (.*)")]
		public void ThenInTheNotificationHistoryDetailScreenIClickOn(string button)
		{
			ProductNotificationHistory thisProductNotificationHistory = new ProductNotificationHistory();
			thisProductNotificationHistory.ClickButtonInNotificationDetails(button);
		}

		[StepDefinition(@"In SHA Manager grid I click the following top menu item: (.*)")]
		public void GivenInSHAManagerGridIClickTheFollowingTopMenuItem(string item)
		{
			StudioSHAManager thiStudioShaManager = new StudioSHAManager();
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

		[Then(@"The Add Product to Recertification screen should be showing")]
		public void ThenTheAddProductToRecertificationScreenShouldBeShowing()
		{
			AddProductToRecertificationDialog thisAddProductToRecertificationDialog =
				new AddProductToRecertificationDialog();
			Report.IsTrue(thisAddProductToRecertificationDialog.Wait_for_load(30),
				"Add Product to Recertification screen has failed to load",
				"Add Product to Recertification screen has loaded");
		}

		[Then(@"in the Add Product to Recertification screen only the following Reasons are selected:")]
		public void ThenInTheAddProductToRecertificationScreenOnlyTheFollowingReasonsAreSelected(Table table)
		{
			AddProductToRecertificationDialog thisAddProductToRecertificationDialog =
				new AddProductToRecertificationDialog();
			List<string> selectedReasons = thisAddProductToRecertificationDialog.GetSelectedReasons();
			string pattern = @"^\d.0?";
			Regex regex = new Regex(pattern);
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
			AddProductToRecertificationDialog thisAddProductToRecertificationDialog =
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
			StudioSHAManagerProductUPC newStudioSHAManagerProductUPC = new StudioSHAManagerProductUPC();
			Report.IsTrue(newStudioSHAManagerProductUPC.Wait_for_load(30), "UPC List is not showing",
				"UPC List is showing");
		}


		[StepDefinition(@"I confirm the top (\d*) products all have PH Range of: (.*)")]
		public void GivenIConfirmTheTopProductsAllHavePHRangeOf(int n, string phRange)
		{
			StudioSHAManager thisStudioShaManager = new StudioSHAManager();
			List<Product> productList = thisStudioShaManager.GetTopXProducts(n);
			Steps_Shared sharedSteps = new Steps_Shared();
			Steps_Studio studioSteps = new Steps_Studio();
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.Info("Checking each product");
			int counter = 1;
			foreach (Product thisProduct in productList)
			{

				ProductInformation thisPI = new ProductInformation();
				thisPI.Id = thisProduct.ID;
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
				ValueEditor thisValueEditor = new ValueEditor();
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
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
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
			StudioSHAManager myStudioShaManager = new StudioSHAManager();
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
							"Product name was not as expected. Expected " + expectedValue + " but got: " + myProduct.Name,
							"Product name was as expected " + expectedValue);
						break;
					case "Distributor":
						Report.IsTrue(myProduct.Distributor == x.Values.ElementAt(i),
							"Product distributor was not as expected. Expected: " + x.Values.ElementAt(i) + " but got: " + myProduct.Distributor,
							"Product distributor was as expected: " + x.Values.ElementAt(i));
						break;

					default:
						throw new Exception("Looking for attribute that does not exist...");
				}
			}
		}
	}
}

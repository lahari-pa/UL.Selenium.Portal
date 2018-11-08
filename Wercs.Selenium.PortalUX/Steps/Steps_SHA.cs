using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Castle.Core.Internal;
using NPOI.SS.Formula.Functions;
using OpenQA.Selenium;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;


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
				Report.IsTrue(thisStudioManageGlobalMessages.AddMessage(thisMessage), "Successfully added message",
					"Failed to add message");
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

		//|Status|Client|SearchPattern|ProductId|ProductName|DateRange|LastActivityDate|Supplier|User|Reviewer|OnSuspended|RecertificationActive|GGOnlyProducts|ECommFlowProducts|TReg|OrderNo|SubmissionDate|UPC|ParentUPC|

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
							"Failed to set status to: " + x.Values.ElementAt(i), "Successfully set status to: " + x.Values.ElementAt(i), false, false);
						break;
					case "Client":
						Report.IsTrue(thisProductSearch.SelectFromClientFilter(x.Values.ElementAt(i)),
							"Failed to set client", "Successfully set client to: " + x.Values.ElementAt(i), false, false);
						break;
					case "SearchPattern":
						Report.IsTrue(thisProductSearch.SelectFromSearchPatternFilter(x.Values.ElementAt(i)),
							"Failed to set search pattern", "Successfully set search pattern to: " + x.Values.ElementAt(i), false, false);
						break;
					case "ProductID":
					case "ProductId":
						Report.IsTrue(thisProductSearch.EnterProductID(x.Values.ElementAt(i)),
							"Failed to set product id", "Successfully set product id to: " + x.Values.ElementAt(i), false, false);
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
							"Failed to set recertification active", "Successfully set recertification active", false, false);
						break;
					case "GGOnlyProducts":
						Report.IsTrue(thisProductSearch.CheckGoodGuideOnlyProducts(x.Values.ElementAt(i) == "true"),
							"Failed to set Good Guide only products", "Successfully set Good Guide only products", false, false);
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
					default:
						throw new Exception("Invalid column name");
				}
			}

			Report.Info("Going to click find");
			Delay.Seconds(1);
			Report.IsTrue(thisProductSearch.ClickButton("Find"), "Failed to click find", "Clicked find", false, false);
			Delay.Seconds(1);
			Report.Info("Waiting for spinner");
			GeneralUtilities.StudioWaitForSpinner();
			Report.Info("Finished waiting for spinner");

		}

		[StepDefinition(@"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its status is: (.*)")]
		public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(string productSavedAs, string status)
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
						"SearchValue"});
					table.AddRow(new string[] {
						"ProductID",
						ID});
					table.AddRow(new string[] {
						"Status",
						status});
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
				Report.IsTrue(topProductnew.ID == ID && topProductnew.Status == status, "Expected: id=" + ID + " and status " + status + " but got: " + topProductnew.ID + " and " + topProductnew.Status, "Statuses match");
			}
			else
			{
				Report.Failure("No products found");
			}

		}

		[StepDefinition(@"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its font is red indicating a recertification")]
		public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsAndItsFontIsRedIndicatingARecertification(string productSavedAs)
		{
			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			var ID = ProductDetails.Id;

			Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

			if (topProduct == null || topProduct.ID != ID)
			{
				StudioSHAManager myStudioShaManager = new StudioSHAManager();

				myStudioShaManager.ClickBottomMenuOption("Search");

				Steps_SHA myStepsSha = new Steps_SHA();

				TechTalk.SpecFlow.Table table = new TechTalk.SpecFlow.Table(new string[] {
					"SearchTerm",
					"SearchValue"});
				table.AddRow(new string[] {
					"ProductID",
					ID});
				table.AddRow(new string[] {
					"Status",
					"All"});
				myStepsSha.GivenInSHAManagerPageIRunSearch(table);

				Delay.Seconds(2);
				StudioSHAManager mySHAManager = new StudioSHAManager();
				mySHAManager.WaitForProductList(10);
			}

			var topProductnew = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();
			if (topProductnew != null)
			{
				Report.IsTrue(topProductnew.ID == ID && topProductnew.ColourRGB == "rgb(205, 10, 10)", "Expected: id=" + ID + " and colour: rgb(205, 10, 10) but got: " + topProductnew.ID + " and " + topProductnew.ColourRGB, "Colours match");
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
					var productDetails = (ProductInformation)Context.GetFromContext(thisRow["Product ID"].Replace("saved as", "").Trim());
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
						Report.Info("Active did not match. Expected: " + thisRow["Active"] + " but got: " + thisProduct.Active);
						allPassed = false;
					}
					if (thisProduct.RecertificationReason == thisRow["Recertification Reason"])
					{
						Report.Info("Recertification matched: " + thisRow["Recertification Reason"]);
					}
					else
					{
						Report.Info("Recertification reason did not match. Expected: " + thisRow["Recertification Reason"] + " but got: " + thisProduct.RecertificationReason);
						allPassed = false;
					}
				}
			}

			Report.IsTrue(allPassed, "Not all products were as expected", "All products listed were as expected");
		}

		[Given(@"I Close the Product Recertification History pop up")]
		public void GivenICloseTheProductRecertificationHistoryPopUp()
		{
			ProductRecertificationHistory thisProductRecertificationHistory = new ProductRecertificationHistory();
			thisProductRecertificationHistory.ClickButton("Close");
			Delay.Seconds(2);
		}

		[StepDefinition(@"I Confirm the Product ID: (.*) is highlited yellow indicating that this is an e-comm/direct ship product")]
		public void ConfirmProductIdIsHighlightedYellow_EcommDirectShipProduct(string id)
		{
			StudioSHAManager selStudioShaManager = new StudioSHAManager();
			Report.Info("Waiting for id to change colour");
			Report.IsTrue(selStudioShaManager.WaitForIDToBeStatus(id, 120, "N/A", "N/A", true, "rgb(254,255,160)"), "ID has not turned required colour", "ID is required colour");
		}

		[StepDefinition(@"I Confirm the Product ID: (.*) is not highlited yellow indicating that this is not an e-comm/direct ship product")]
		public void ConfirmProductIdIsNotHighlightedYellow_NotEcommDirectShipProduct(string id)
		{
			StudioSHAManager selStudioShaManager = new StudioSHAManager();
			var colour = selStudioShaManager.ProductHighlight(id);
			if (colour == null)
			{
				Report.Failure("Unable to get product status for product id: " + id);
				Report.Screenshot();
				return;
			}
			Report.IsTrue(colour != "rgb(254,255,160)", "Colour was highlighted with a yellow background when it was not expected to be!", "Product was not highlighted yellow background as expected");
		}

		[Given(@"In SHA Manager I select the following products:")]
		public void GivenInSHAManagerISelectTheFollowingProducts(Table table)
		{
			string ID = "";
			foreach (TechTalk.SpecFlow.TableRow thisProduct in table.Rows)
			{
				if (thisProduct["ProductID"].ToLower().Contains("saved as"))
				{
					var ProductDetails = (ProductInformation)Context.GetFromContext(thisProduct["ProductID"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
					ID = ProductDetails.Id;
				}
				StudioSHAManager thisStudioSHAManager = new StudioSHAManager();
				Report.IsTrue(thisStudioSHAManager.SelectProductByID(ID), "Failed to select: " + ID, "Selected: " + ID);
			}

		}
		[StepDefinition(@"In SHA Manager I select the first product")]
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
			Report.IsTrue(thisRecertificationPopup.SetAutoAssignRegulatorySpecialistToProduct(false), "Failed to uncheck the Auto Assign Regulatory Specialist to Product check box",
				"Unchecked the Auto Assign Regulatory Specialist to Product check box");
		}

		[StepDefinition(@"I Select (.*) from the drop down list for Select Regulatory Specialist")]
		public void GivenISelectAutomatedQAShaFromTheDropDownListFor(string specialist)
		{
			RecertificationPopup thisRecertificationPopup = new RecertificationPopup();
			Report.IsTrue(thisRecertificationPopup.SelectRegulatorySpecialist(specialist), "Failed to select: " + specialist,
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
		public void GivenInTheRecertificationPopupIShouldSeeTheFollowingProductsAsSuccessfullyAssigned(TechTalk.SpecFlow.Table productsExpected)
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
					var ProductDetails = (ProductInformation)Context.GetFromContext(thisProduct["ProductID"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
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
					if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h3[contains(text(),'SHA Manager Product UPC')]"), 2) != null)
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

		[Given(@"I edit My Toolbar to add the following options")]
		public void GivenIEditMyToolbarToAddTheFollowingOptions(Table table)
		{
			Steps_Studio thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenInPowerDesignerPlusPageIClickOnTab("my toolbar");
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton();
			thisStepsStudio.GivenInTheEditToolbarPageICheckTheFollowingItems(table);
			thisStepsStudio.GivenInTheEditToolbarPageIClick("save");
		}


	}
}

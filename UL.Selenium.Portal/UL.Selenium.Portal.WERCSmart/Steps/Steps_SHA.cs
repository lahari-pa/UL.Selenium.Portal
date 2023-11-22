using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using TReVor.Api.Wrapper.Classes;
using System.IO;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.AdvancedReportsRules;
using UL.Selenium.Portal.WERCSmart.Classes;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using TReVor.Core.Classes.Software;
using NUnit.Framework;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SHA")]
	public class Steps_SHA
	{
		public object REport { get; private set; }

		[StepDefinition(@"I navigate to Studio")]
		public void GivenINavigateToStudio()
		{
			ReadOnlyCollection<string> handles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			if (handles.Count == 0)
			{
				((IJavaScriptExecutor)SeleniumWebDriver.CurrentDriver).ExecuteScript("window.open();");
			}

			SeleniumWebDriver.CurrentDriver.SwitchTo().Window(SeleniumWebDriver.CurrentDriver.WindowHandles.Last());
			SeleniumWebDriver.CurrentDriver.Url = TReVor.Integrations.Classes.TReVorSettings.Variables.GetVariable("SHAUrl");
			SeleniumWebDriver.CurrentDriver.WaitForPageLoad();
		}

		[StepDefinition(@"I navigate to Portal")]
		public void GivenINavigateToPortal()
		{
			SeleniumWebDriver.CurrentDriver.Url = SeleniumWebDriver.BaseTestUrl;
			SeleniumWebDriver.CurrentDriver.WaitForPageLoad();
		}

		[StepDefinition(@"I login to Studio as Administrator")]
		public void GivenILoginToStudioAsAdministrator()
		{
			var thisStudioLogin = new StudioLogin();
			SoftwareCredentialBasic shaUser = TReVor.Integrations.Classes.TReVorSettings.Credentials.GetCredential("SHAUser");
			Report.Info("Entering username: " + shaUser.UserName);
			thisStudioLogin.Username = shaUser.UserName;
			Report.Info("Entering password: ******* ");
			thisStudioLogin.Password = shaUser.Password;
			Report.Info("Clicking 'sign in'");
			Report.IsTrue(thisStudioLogin.ClickSignIn(), "Failed to click 'Sign In", "Clicked 'Sign In'");
			Delay.Seconds(3);
			var thisStudioDesktop = new StudioDesktop();
			if (new PasswordExpireNotice().WaitForLoad())
			{
				Report.Info("The Password Expire Notice appeared, so clicking ignore");
				if (!new PasswordExpireNotice().ClickButton("Ignore"))
				{
					Report.Failure("Failed to Click Ignore");
				}
			}
			Report.IsTrue(thisStudioDesktop.WaitForContainerToBeVisible(30), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
			Report.Info("Studio desktop is loaded");
			var thisStudioTopMenu = new StudioTopMenu();
			Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");

			if (!Context.FeatureContext.ContainsKey("QASHAAccount"))
			{
				Report.Info($"key QASHAAccount did not exist...");
				Context.FeatureContext.Add("QASHAAccount", shaUser.UserName);
			}
			else
			{
				Report.Info($"key QASHAAccount did  exist, updating instead");
				Context.FeatureContext["QASHAAccount"] = shaUser.UserName;

			}
		}


		[StepDefinition(@"I login to Studio as (.*)")]
		public void GivenILoginToStudioAsTReVorUser(string savedAs)
		{
			var thisStudioLogin = new StudioLogin();
			SoftwareCredentialBasic shaUser = TReVor.Integrations.Classes.TReVorSettings.Credentials.GetCredential(savedAs);
			Report.Info("Entering username: " + shaUser.UserName);
			thisStudioLogin.Username = shaUser.UserName;
			Report.Info("Entering password: ****** ");
			thisStudioLogin.Password = shaUser.Password;
			Report.Info("Clicking 'sign in'");
			Report.IsTrue(thisStudioLogin.ClickSignIn(), "Failed to click 'Sign In", "Clicked 'Sign In'");
			Delay.Seconds(3);
			var thisStudioDesktop = new StudioDesktop();
			if (new PasswordExpireNotice().WaitForLoad())
			{
				Report.Info("The Password Expire Notice appeared, so clicking ignore");
				if (!new PasswordExpireNotice().ClickButton("Ignore"))
				{
					Report.Failure("Failed to Click Ignore");
				}
			}
			Report.IsTrue(thisStudioDesktop.WaitForContainerToBeVisible(30), "Studio desktop is not showing as expected.",
				"Studio desktop is showing as expected");
			Report.Info("Studio desktop is loaded");
			var thisStudioTopMenu = new StudioTopMenu();
			Report.IsTrue(thisStudioTopMenu.Wait_for_load(60), "Top menu has not loaded", "Top menu has loaded");
		}

		[StepDefinition(@"I click top menu item: (.*) and submenu item: (.*)")]
		public void GivenIClickTopMenuItemAndSubMenuItem(string menuItem, string submenuItem)
		{
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(30), "Top menu has not loaded", "Top menu has loaded", showSuccessScreenshot: false);

			if (submenuItem.Length == 0)
			{
				Report.IsTrue(thisTopMenu.ClickTopMenuItem(menuItem), "Failed to click: " + menuItem,
					"Successfully clicked: " + menuItem, showSuccessScreenshot: false);
			}
			else
			{
				Report.IsTrue(thisTopMenu.ClickSubMenu(menuItem, submenuItem), "Failed to click: " + menuItem,
					"Successfully clicked: " + submenuItem, showSuccessScreenshot: false);
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
			Report.IsTrue(thisStudioManageGlobalMessages.WaitForContainerToBeVisible(),
				"Manage Global Messages dialog is not showing", "Manage global messages dialog is showing");
			Report.IsTrue(thisStudioManageGlobalMessages.WaitForMessageTableToShow(), "The table was not showing inside the global messages dialog", "The table was  showing inside the global messages dialog");

			var ListOfMessages = new List<Message>();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				var thisMessage = new Message {
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
						string user = value;
						if (UL.Automation.SpecFlow.Classes.Context.Contains(value))
						{
							user = UL.Automation.SpecFlow.Classes.Context.GetFromContext(value).ToString();
						}
						Report.IsTrue(thisProductSearch.EnterUser(user),
							"Failed to set user", "Successfully set user", false, false);
						break;
					case "TReVorUser":
						SoftwareCredentialBasic TReVorUser = TReVor.Integrations.Classes.TReVorSettings.Credentials.GetCredential(value);
						if(Report.IsTrue(TReVorUser != null,$"Failure, TReVor user '{value}' does not exist.",$"Success, TReVor user '{value}' exists."))
						{
							Report.IsTrue(thisProductSearch.EnterUser(TReVorUser.UserName),
							"Failed to set user", "Successfully set user", false, false);
						}
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
						if (value.Contains("saved as"))
						{
							value = Context
								.GetFromContext(value.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
								.ToString();
						}
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
			Report.Screenshot();
			Report.Info("Going to click find");
			Delay.Seconds(1);
			Report.IsTrue(thisProductSearch.ClickButton("Find"), "Failed to click find", "Clicked find", false, false);
			Report.Info("Waiting for loading bar");
			new StudioSHAManager().Wait_For_Loading_Finish();
			Report.Info("Finished waiting for loading");
			Delay.Seconds(1);
			Report.Screenshot();
		}

		[StepDefinition(@"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and its status is: (.*)")]
		public void GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(string productSavedAs,
			string status)
		{

			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			string ID = ProductDetails.Id;
			Report.Info("Searching for id: " + ID + " and status: " + status);

			//rerun search until status is as expected or give up
			int counter = 0;

			bool found = false;

			while (counter < 35 && !found)
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
			Report.IsTrue(found, "Expected: id=" + ID + " and status " + status, "Statuses match", showSuccessScreenshot: false);
		}

		[StepDefinition(@"In the SHA manager grid I see the WPS ID I have saved as product: (.*) and if status is Submitted, I change status to Assigned, then confirm status is Assigned")]
		public void InShaManagerGridForProductIDSavedAsIfStatusSubmittedMoveToAssignedThenConfirmStatusAssigned(string productSavedAs)
		{
			Report.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			if (ProductDetails == null)
			{
				Report.Error($"Product saved as '{productSavedAs}' not found in context.");
				return;
			}
			string ID = ProductDetails.Id;
			Report.StartSubStep($"Attempt to get product #{ID} current status.");
			//this.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(productSavedAs, "Assigned");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", productSavedAs);
			string currentStatus = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault().Status;
			Report.Info($"Product #{ID} current status: {currentStatus}");
			Report.Screenshot();
			if (string.Equals("Submitted", currentStatus, comparisonType: StringComparison.OrdinalIgnoreCase))
			{
				Report.StartSubStep($"I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: {productSavedAs})");
				sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(productSavedAs);
				Report.StartSubStep($"49841(SHA - Search for exact WPS ID in All Status for saved as: {productSavedAs}");
				sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", productSavedAs);
			}
			Report.StartSubStep($"Attempt to get product #{ID} current status.");
			this.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(productSavedAs, "Assigned");
			currentStatus = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault().Status;
			Report.IsTrue(string.Equals("Assigned", currentStatus, comparisonType: StringComparison.OrdinalIgnoreCase), "Expected: id=" + ID + " and status " + currentStatus, "Statuses match", showSuccessScreenshot: false);
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

		[StepDefinition(@"In the SHA manager grid I right click first product")]
		public void GivenInTheSHAManagerGridIRightClickFirstProduct()
		{
			Report.IsTrue(new StudioSHAManager().RightClickFirstProduct(), "Failed to rightclick against first product", "Right clicked against first product", showSuccessScreenshot: false);
		}

		[StepDefinition(@"In the SHA manager grid I right click against product saved as: (.*)")]
		public void GivenInTheSHAManagerGridIRightClickAgainstProductSavedAs(string savedAs)
		{
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string ID = ProductDetails.Id;

			Report.IsTrue(new StudioSHAManager().RightClickProductByID(ID), "Failed to rightclick against: " + ID,
				"Right clicked against: " + ID, showSuccessScreenshot: false);
		}


		[StepDefinition(@"In the SHA manager grid when the right click context menu is open I select option: (.*)")]
		public void GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption(string option)
		{
			var thisContextMenu = new RightClickProductMenu();
			Report.IsTrue(thisContextMenu.SelectOption(option), $"Failed to select option: {option }",
				$"Selected option: { option }");
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
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
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
				Report.IsTrue(displayedUpcs.Any(x => x.UPCNumber.Contains(upc)),
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

		[StepDefinition(@"I confirm that UPC number saved as: (.*) shows a grey background for Archived in the SHA Manager Product UPC list")]
		public void IConfirmThatTheUPCNumberSavedAsShowsAGreyBackground(string savedAs)
		{
			string upc = Context.GetFromContext(savedAs)?.ToString() ?? "";
			Report.Info($"Getting UPC From Context, Found: {upc}");
			if (upc == "")
			{
				Report.Failure("Failed to find upc saved as " + savedAs + " in context.");
			}

			var sha = new StudioSHAManager();

			Report.IsTrue(sha.ConfirmUPCArchived(upc), "Failed to find UPC " + upc + " set as archived.",
				"Successfully found upc " + upc + " set as archived.");

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

		[StepDefinition(@"I confirm that retailer saved as: (.*) appears for UPC saved as: (.*)")]
		public void ConfirmThatRetailerSavedAsAppearsForUPCSavedAs(string retailerSavedAs, string upcSavedAs)
		{
			if (!Context.Contains(upcSavedAs))
			{
				Report.Error("No item saved in context as: " + upcSavedAs);
				return;
			}
			string upc = Context.GetFromContext(upcSavedAs).ToString();
			if (!Context.Contains(retailerSavedAs))
			{
				Report.Error("No item saved in context as: " + retailerSavedAs);
				return;
			}
			//SeleniumBrowser.WebBrowser.WaitForPageLoad();
			//         Delay.Seconds(5);
			//if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='upcTableOutter']"), 10) ==null)
			//{
			//	Report.Failure("View UPC table was not displayed");
			//	return;
			//}
			Report.Info("UPC is: " + upc);
			string retailer = Context.GetFromContext(retailerSavedAs).ToString();
			//retailer = new RetailerAbbreviations().TryConvertToAbbreviation(retailer);
			Report.Info("Retailer is: " + retailer);
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
			if (regulatorySpecialist == "SHA Regulatory Specialist")
			{
				regulatorySpecialist = TReVor.Integrations.Classes.TReVorSettings.Variables.GetVariable("SHA Regulatory Specialist");
			}
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

		[StepDefinition(@"In the Reject Submission dialog I Select Subject: (.*)")]
		public void GivenInTheRejectSubmissionDialogISelectSubject(string subject)
		{
			var thisStudioSHAManagerProductRejectSubmission = new StudioSHAManagerProductRejectSubmission();
			Report.IsTrue(thisStudioSHAManagerProductRejectSubmission.SelectSubject(subject),
				"Failed to select subject: " + subject, "Selected: " + subject);
		}

		[StepDefinition(@"In the Reject Submission dialog in the Subject field I should see: (.*)")]
		public void GivenInTheRejectSubmissionDialogInTheSupplierSubjectIShouldSee(string shouldSee)
		{
			var thisStudioSHAManagerProductRejectSubmission = new StudioSHAManagerProductRejectSubmission();

			string actualMessage = thisStudioSHAManagerProductRejectSubmission.GetSubjectMessage();
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

		[StepDefinition(@"In the Reject Submission dialog in the Supplier Message field I should see: (.*)")]
		public void GivenInTheRejectSubmissionDialogInTheSupplierMessageFieldIShouldSee(string shouldSee)
		{
			var thisStudioSHAManagerProductRejectSubmission = new StudioSHAManagerProductRejectSubmission();

			string actualMessage = thisStudioSHAManagerProductRejectSubmission.GetSupplierMessage();
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

		[StepDefinition(@"In the Reject Submission dialog in the Supplier Message field I replace the following text: (.*) with: (.*)")]
		public void GivenInTheRejectSubmissionDialogInTheSupplierMessageFieldIReplaceTheFollowingTextWith(string textToReplace, string newText)
		{
			var thisStudioSHAManagerProductRejectSubmission = new StudioSHAManagerProductRejectSubmission();
			Report.IsTrue(thisStudioSHAManagerProductRejectSubmission.ReplaceSupplierMessage(textToReplace, newText),
					"Failed to replace: " + textToReplace + " with: " + newText, "Successfully replaced: " + textToReplace + " with: " + newText);
		}

		[StepDefinition(@"In the Reject Submission dialog I click (Save|Cancel)")]
		public void GivenInTheRejectSubmissionDialogIClickSave(string button)
		{
			var thisStudioSHAManagerProductRejectSubmission = new StudioSHAManagerProductRejectSubmission();
			if (thisStudioSHAManagerProductRejectSubmission.RejectSubmissionDialogClickSaveOrCancel(button))
			{
				Report.Info("Successfully clicked the " + button + " button");
			} else
			{
				Report.Info("Failed to click the " + button + " button");
			}
		}

		[StepDefinition(@"In SHA Manager I select the first product")]
		public void GivenInSHAManagerISelectTheProduct()
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

		[StepDefinition(@"I confirm that the retailer (.*) is archived for product saved as: (.*)")]
		public void IConfirmThatTheRetailerIsArchivedForProduct(string retailer, string savedAs)
		{
			string retailerAbbr = "";
			var abbr = new RetailerAbbreviations();
			abbr.Map.TryGetValue(retailer, out retailerAbbr);

			var thisStudioSHAManager = new StudioSHAManager();
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string ID = ProductDetails.Id;

			Report.IsTrue(thisStudioSHAManager.RetailerIsArchived(retailerAbbr, ID), "Failed to find archived retailer " + retailer,
				"Successfully found archived retailer " + retailer);
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

		[StepDefinition(@"In the Suspended dialog below the Supplier Message field I see the following text in red: (.*)")]
		public void GivenInTheSuspendedDialogBelowTheSupplierMessageFieldIEnterTheFollowingTextInRed(string textToAdd)
		{
			var thisStudioSHAManagerProductSuspend = new StudioSHAManagerProductSuspend();
			Report.IsTrue(thisStudioSHAManagerProductSuspend.CheckForRedTextBelowSupplierMessage(textToAdd),
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
			var thisProductNotificationHistory = new ProductNotificationHistory();
			thisProductNotificationHistory.WaitForTableContentToLoad();
			SpecFlowReporting.TableRow(table.Rows[0]);
			Report.Info("Getting displayed notifications");
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
		[StepDefinition(@"In the Notification History Detail Screen I confirm that details are as follows")]
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
			Report.Screenshot();
			Report.StartStep("I set the status filter to " + status);
			myStudioShaManager.WaitForProductList(60);
			Report.Screenshot();
			myStudioShaManager.SelectFromStatusFilter(status);
			Report.Screenshot();
			Report.Info("Status has been set");
			Report.Screenshot();
			Report.Info("Pressing Enter Key");
			Report.Screenshot();			

			//This query is often very slow. Sometimes the results appear to have loaded but then several seconds later the
			//spinner appears and the results change.
			Delay.Seconds(10);
			GeneralUtilities.StudioWaitForSpinner(30);
			myStudioShaManager.WaitForProductList(60);
			//GeneralUtilities.StudioWaitForSpinner();
			Delay.Seconds(10);
			Report.Screenshot();
			//Wait for top n items to be status Assigned
			int n = 5;
			int x = 0;
			Report.Info($"Searching for status to match: {status}");
			bool correct = false;

			//Addition
			Report.Info("first try check...");
			List<Product> topN2 = myStudioShaManager.GetTopXProducts(n);
			List<Product> correctStatusItems2 = new List<Product>();
			foreach (var item in topN2)
			{
				Report.Info($"Status found was: {item.Status}");
				if (item.Status == status)
				{
					correctStatusItems2.Add(item);
				}
			}
			Report.Screenshot();
			Report.Info($"n is {n}");
			Report.Info($"Count found was: {correctStatusItems2.Count()}");
			if (correctStatusItems2.Count() == topN2.Count())
			{
				correct = true;
				Report.Info($"{n} items with correct status were found");
			}
			Delay.Seconds(10);
			Report.Info("end of first try check...");

			if (correct == false)
			{
				Report.Info($"was false...");
				Report.StartStep("I set the status filter to " + status);
				myStudioShaManager.WaitForProductList(60);
				myStudioShaManager.SelectFromStatusFilter(status);
				Report.Info("Status has been set");
				Report.Screenshot();
				Report.Info("Pressing Enter Key");
				Report.Screenshot();
				Delay.Seconds(10);
				GeneralUtilities.StudioWaitForSpinner(30);
				myStudioShaManager.WaitForProductList(60);
				Delay.Seconds(10);
			}
			//End of Addition


			Report.Info($"Going into wait loop...");
			while (correct==false && x<60)
				{
					List<Product> topN = myStudioShaManager.GetTopXProducts(n);
					List<Product> correctStatusItems = new List<Product>();
					foreach (var item in topN)
					{
						Report.Info($"Status found was: {item.Status}");
						if (item.Status == status)
						{
							correctStatusItems.Add(item);
						}
					}
					Report.Screenshot();
					Report.Info($"n is {n}");
					Report.Info($"Count found was: {correctStatusItems.Count()}");
					if (correctStatusItems.Count() == topN.Count())
					{
						correct = true;
						Report.Info($"{n} items with correct status were found");						
					}		
					Delay.Seconds(10);
					x++;					
				}

			Report.Info($"Going to final check...");

			if (correct == false)
			{
				Report.Info($"Final Filter try...");
				Report.Screenshot();
				myStudioShaManager.SelectFromStatusFilter(status);
				Report.Screenshot();
				Report.Info("Status has been set");
				Report.Screenshot();
				Report.Info("Pressing Enter Key");
				Report.Screenshot();
				Delay.Seconds(10);
				GeneralUtilities.StudioWaitForSpinner(30);
				myStudioShaManager.WaitForProductList(60);
				Report.Screenshot();

				List<Product> topN = myStudioShaManager.GetTopXProducts(n);
				List<Product> correctStatusItems = new List<Product>();
				foreach (var item in topN)
				{
					Report.Info($"Status found was: {item.Status}");
					if (item.Status == status)
					{
						correctStatusItems.Add(item);
					}
				}
				Report.Screenshot();
				Report.Info($"n is {n}");
				Report.Info($"Count found was: {correctStatusItems.Count()}");
				if (correctStatusItems.Count() == topN.Count())
				{
					correct = true;
					Report.Info($"{n} items with correct status were found");
				}
			}
			Report.Info($"Going to check...");
			Report.Screenshot();
			Report.IsTrue(correct, "The status of the top "+n+" items was not " +status+".", "The status of the top "+n+" items was "+status+".");
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

		[StepDefinition(@"The Add Product to Recertification screen should be loaded")]
		public void ThenAddProductToRecertificationScreenShouldBeShowing()
		{
			var thisAddProductToRecertificationDialog =
				new AddProductToRecertificationDialog();
			Report.IsTrue(thisAddProductToRecertificationDialog.Wait_until_load(30),
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

				var thisPI = new ProductInformation {
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

				Report.StartStep("Looking at id: " + thisProduct.ID);
				thisStudioPowerDesignerPlusDesignMode.Wait_for_load(60);
				//studioSteps.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Chemical Product Checklist");
				Report.StartStep("I check the PH value");
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
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
							By.XPath(".//h1[contains(text(),'WERCSmart Product ID')]"), 2) != null)
					{
						Report.Success("Tab was switched successfully!");
						Report.Screenshot();
						currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
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
		public void ShaUPCList(string condition, string upc)
		{
			try
			{
				// Switch to window
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
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
				Report.Info($"The list of displayed UPCs was: {string.Join(", ", displayedUpcs.Select(x => x.UPCNumber).ToList())}");

				Report.Info($"Checking if the UPC needed is saved in context");

				if (upc.ToLower().Contains("saved as"))
				{
					Report.Info("The UPC Input value contained the text 'saved as'");
					upc = Context
						.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
				}

				Report.Info($"Checking the UPC presence against the required condition: ({condition})");
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


		[StepDefinition(@"In the SHA UPC list I should (see|not see) UPC: (.*) in the First Row of the UPC table")]
		public void ShaUPCListFirstItemCheck(string condition, string upc)
		{
			try
			{
				// Switch to window
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				//Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
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

				SHAManagerProdcutUPC displayedUpcs = new StudioSHAManager().GetFirstUPC();
				if (displayedUpcs == null)
				{
					Report.Failure("Unable to fetch UPC Information from the SHA UPC window!");
					Report.Screenshot();
					return;
				}
				Report.Info($"The first found displayed UPC was: {displayedUpcs.UPCNumber}");

				Report.Info($"Checking if the UPC needed is saved in context");

				if (upc.ToLower().Contains("saved as"))
				{
					Report.Info("The UPC Input value contained the text 'saved as'");
					upc = Context
						.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
				}

				Report.Info($"Checking the UPC presence against the required condition: ({condition})");
				if (condition == "see")
				{
					Report.IsTrue(displayedUpcs.UPCNumber==upc, "UPC: " + upc + " does not display",
						"UPC: " + upc + " displays as expected");
				}

				if (condition == "not see")
				{
					Report.IsTrue(displayedUpcs.UPCNumber != upc, "UPC: " + upc + " was found in the first position.",
						"UPC: " + upc + " was not found in the first position.");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				Report.Screenshot();
			}
		}

		[StepDefinition(@"In the SHA UPC list I should (see|not see) UPC: (.*) in Any Row of the UPC table")]
		public void ShaUPCListAllItemsCheck(string condition, string upc)
		{
			try
			{
				// Switch to window
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				//Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
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

				List<string> displayedUpcs = new StudioSHAManager().UPCAssessmentScreenGetUPCStringList();


				if (displayedUpcs == null)
				{
					Report.Failure("Unable to fetch UPC Information from the SHA UPC window!");
					Report.Screenshot();
					return;
				}

				Report.Info($"The list of dispayed UPCs was: {string.Join(", ",displayedUpcs)}");

				Report.Info($"Checking if the UPC needed is saved in context");

				if (upc.ToLower().Contains("saved as"))
				{
					Report.Info("The UPC Input value contained the text 'saved as'");
					upc = Context
						.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
				}

				Report.Info($"Checking the UPC presence against the required condition: ({condition})");
				if (condition == "see")
				{
					Report.IsTrue(displayedUpcs.Contains(upc), "UPC: " + upc + " does not display", "UPC: " + upc + " displays as expected");

				}

				if (condition == "not see")
				{
					Report.IsTrue(!displayedUpcs.Contains(upc), "UPC: " + upc + " was still found.","UPC: " + upc + " was not found");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				Report.Screenshot();
			}
		}


		[StepDefinition(@"In the SHA UPC list I should (see|not see) the case pack asterisk for the UPC: (.*)")]
		public void ShaUPCListCasePackAsteriskSeen(string condition, string upc)
		{
			try
			{
				// Switch to window
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				//Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
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

				List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().UPCAssessmentScreenGetUPCs();
				if (displayedUpcs == null)
				{
					Report.Failure("Unable to fetch UPC Information from the SHA UPC window!");
					Report.Screenshot();
					return;
				}
				Report.Info($"The list of displayed UPCs was: {string.Join(", ", displayedUpcs.Select(x => x.UPCNumber).ToList())}");

				Report.Info($"Checking if the UPC needed is saved in context");

				if (upc.ToLower().Contains("saved as"))
				{
					Report.Info("The UPC Input value contained the text 'saved as'");
					upc = Context
						.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
				}

				Report.Info($"Checking that our upc is found in the table...");
				var foundUPC = new SHAManagerProdcutUPC();
				if(displayedUpcs.Any(x => x.UPCNumber.Contains(upc)))
				{
					Report.Success($"The upc {upc} was  found in the table");

					foreach(var item in displayedUpcs)
					{
						if (item.UPCNumber.Contains(upc))
						{
							foundUPC = item;
							Report.Success($"Assigned upc to 'foundUPC', UPC was: {foundUPC.UPCNumber}");
							break;
						}
					}
					if(foundUPC.IsNullOrEmpty())
					{
						Report.Failure($"Not able to assign a value to 'foundUPC'");
						return;
					}


					Report.Info($"Checking the Case pack asterisk presence against the required condition: ({condition})");
					if (condition == "see")
					{
						var array = foundUPC.UPCNumber.ToArray();
						char finalChar = array.Last();
						Report.IsTrue(finalChar.ToString()=="*", "the case pack upc asterisk was not found", "The case pack upc asterisk was found");
					}

					if (condition == "not see")
					{
						var array = foundUPC.UPCNumber.ToArray();
						char finalChar = array.Last();
						Report.IsTrue(finalChar.ToString() != "*","The case pack upc asterisk was found", "the case pack upc asterisk was not found");
					}

				}
				else
				{
					Report.Failure($"The upc {upc} was not found in the table");
					return;
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
			Report.Info("Waiting for document list");
			Delay.Seconds(8);
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

		//[StepDefinition(
		//	@"I should see a new tabbed document with the pdf containing product code saved as: (.*) and NGHS / English twice")]
		//public void ThenIShouldSeeANewTabbedDocumentWithThePdfContainingProductCodeSavedAsTestCase(string savedAs)
		//{
		//	var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
		//	string ID = ProductDetails.Id;
		//	var thisSHADocument = new SHADocumentList();
		//	Delay.Seconds(3);
		//	string docURL = thisSHADocument.DocumentWindowOpen();
		//	if (docURL != null)
		//	{
		//		Report.Info($"The found URL was: {docURL}");
		//		string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
		//		Report.Info($"Found the downloads folder: {downloadsFolder}");
		//		thisSHADocument.DownloadFileFromURL(docURL, downloadsFolder + @"\TempPDF.pdf");
		//		Report.Info($@"Downloading file from url complete, downloaded to: {downloadsFolder}+ \TempPDF.pdf");


		//		//TEST CODE
		//		Report.Info($"Running Test code for PDF check using new downloaded file");

		//		GeneralUtilities.OpenNewTabAndNavigateTo(downloadsFolder + @"\TempPDF.pdf");
		//		Report.Info($"tab opened");
		//		Delay.Seconds(3);
		//		//string docURL2 = thisSHADocument.DocumentWindowOpen();
		//		string docURL2 = thisSHADocument.TemporaryPDFWindowOpen();
		//		Report.Info($"doc window opened");
		//		Report.Screenshot();

		//		if (docURL2 == null)
		//		{
		//			Report.Info("The docURL was null");
		//			return;
		//		}

		//		string pdfText = thisSHADocument.DocumentText(docURL2);
		//		Report.Info($"this was the new found pdf text using the new test code: {pdfText}");

		//		//END TEST CODE


		//		//string pdfText = thisSHADocument.DocumentText(docURL);


		//		Report.Info($"The Found PDF Text was: {pdfText}");
		//		Report.IsTrue(pdfText.Contains(ID), "PDF does not contain: " + ID, "PDF contains " + ID);
		//		Report.IsTrue(CountStringOccurrences(pdfText, "NGHS / English") == 2, "PDF does not contain: NGHS / English twice", "PDF contains NGHS / English twice");
		//	}
		//	else
		//	{
		//		Report.Error("Tabbed document has not been found as expected");
		//	}
		//}

		[StepDefinition(@"I Check that the file saved as: (.*) contains the text 'NGHS / English' twice as well as the product codes saved as: (.*) and (.*)")]
		public void CheckThatFileSavedAsContaisnTextNGHSEnglishTwicAndProductCodesSavedAs(string fileSavedAs, string code1SavedAs, string code2SavedAs)
		{
			var productOneDetails = (ProductInformation)Context.GetFromContext(code1SavedAs);
			string ID1 = productOneDetails.Id;

			var productTwoDetails = (ProductInformation)Context.GetFromContext(code2SavedAs);
			string ID2 = productTwoDetails.Id;


			var thisSHADocument = new SHADocumentList();
			Delay.Seconds(3);
			Report.Screenshot();

			if (fileSavedAs.ToLower().Contains("savedas"))
			{
				fileSavedAs = (string)Context.GetFromContext(fileSavedAs);
			}

			PdfReader reader = new PdfReader(fileSavedAs);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			var pdfText = text;


			Report.Info($"The Found PDF Text was: {pdfText}");
			Report.IsTrue(pdfText.Contains(ID1), "PDF does not contain: " + ID1, "PDF contains " + ID1);
			Report.IsTrue(pdfText.Contains(ID2), "PDF does not contain: " + ID2, "PDF contains " + ID2);


			var foundOccurences = CountStringOccurrences(pdfText.Replace(" ", ""), @"NGHS/English");
			Report.IsTrue(foundOccurences == 2, "PDF does not contain: NGHS / English twice", "PDF contains NGHS / English twice");

		}

		[StepDefinition(@"I Check that the file saved as: (.*) contains the product codes saved as: (.*) and (.*)")]
		public void CheckThatFileSavedAsContaisnProductCodesSavedAs(string fileSavedAs, string code1SavedAs, string code2SavedAs)
		{
			var productOneDetails = (ProductInformation)Context.GetFromContext(code1SavedAs);
			string ID1 = productOneDetails.Id;

			var productTwoDetails = (ProductInformation)Context.GetFromContext(code2SavedAs);
			string ID2 = productTwoDetails.Id;

			var thisSHADocument = new SHADocumentList();
			Report.Info($"tab opened");
			Delay.Seconds(3);
			//string docURL2 = thisSHADocument.DocumentWindowOpen();
			string docURL2 = thisSHADocument.TemporaryPDFWindowOpen();
			Report.Info($"doc window opened");
			Report.Screenshot();

			if (fileSavedAs.ToLower().Contains("savedas"))
			{
				fileSavedAs = (string)Context.GetFromContext(fileSavedAs);
			}

			PdfReader reader = new PdfReader(fileSavedAs);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			var pdfText = text;


			Report.Info($"The Found PDF Text was: {pdfText}");
			Report.IsTrue(pdfText.Contains(ID1), "PDF does not contain: " + ID1, "PDF contains " + ID1);
			Report.IsTrue(pdfText.Contains(ID2), "PDF does not contain: " + ID2, "PDF contains " + ID2);


		}


		[StepDefinition(@"I Check that the file saved as: (.*) contains the text 'Canada / English' twice")]
		public void CheckThatFileSavedAsContaisnTextCanadaEnglishTwice(string fileSavedAs)
		{

			var thisSHADocument = new SHADocumentList();
			Delay.Seconds(3);
			Report.Screenshot();

			if (fileSavedAs.ToLower().Contains("savedas"))
			{
				fileSavedAs = (string)Context.GetFromContext(fileSavedAs);
			}

			PdfReader reader = new PdfReader(fileSavedAs);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			var pdfText = text;


			Report.Info($"The Found PDF Text was: {pdfText}");


			var foundOccurences = CountStringOccurrences(pdfText.Replace(" ", ""), @"Canada/English");
			Report.IsTrue(foundOccurences == 2, "PDF does not contain: Canada / English twice", "PDF contains NGHS / English twice");

		}

		[StepDefinition(@"I Check that the file saved as: (.*) contains the text 'Canada / Français' twice")]
		public void CheckThatFileSavedAsContaisnTextCanadaFrançaisTwice(string fileSavedAs)
		{

			var thisSHADocument = new SHADocumentList();
			Delay.Seconds(3);
			Report.Screenshot();

			if (fileSavedAs.ToLower().Contains("savedas"))
			{
				fileSavedAs = (string)Context.GetFromContext(fileSavedAs);
			}

			PdfReader reader = new PdfReader(fileSavedAs);
			string text = string.Empty;
			for (int page = 1; page <= reader.NumberOfPages; page++)
			{
				text += PdfTextExtractor.GetTextFromPage(reader, page);
			}
			reader.Close();
			var pdfText = text;


			Report.Info($"The Found PDF Text was: {pdfText}");


			var foundOccurences = CountStringOccurrences(pdfText.Replace(" ", ""), @"Canada/Français");
			Report.IsTrue(foundOccurences == 2, "PDF does not contain: Canada / Français twice", "PDF contains NGHS / English twice");

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

		[StepDefinition(@"I (should|should not) see the '(.*)' popup")]
		public void ThenIShouldSeeThePopup(string condition,  string header)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			var thisStudioSHAManager = new StudioSHAManager();
			if (condition == "should")
			{
				Report.IsTrue(thisStudioSupplierManager.Wait_for_load(30), "StudioSupplierManager has not opened",
					"StudioSupplierManager has opened");
				Report.IsTrue(thisStudioSHAManager.CheckPopupHeader(header), $"Failed to verify the {header} popup header", $"Succesfully verified the {header} popup header");
			}
			else
			{
				Report.IsFalse(thisStudioSHAManager.CheckPopupHeader(header), $"Failed to verify the {header} popup is closed", $"Succesfully closed the {header} popup");
				Report.Screenshot();
			}

		}
		[StepDefinition(@"An alert is displayed with next errors:")]
		public void ThenAnAlertIsDisplayedWithNextErrors(Table table)
		{
			string alertText = SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Text;
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(alertText.Contains(thisRow["Error"]), $"Alert text does not contain error {thisRow["Error"]}", $"Alert text contain error { thisRow["Error"]}");
			}

		}

		[StepDefinition(@"In the Supplier Manager Popup I check next radio buttons:")]
		public void ThenInTheSupplierManagerPopupICheckNextRadioButtons(Table table)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			foreach (TableRow thisRow in table.Rows)
			{
				if (Report.IsTrue(thisStudioSupplierManager.RadioButtonExists(thisRow["Radio Button"]), $"Failed to find radio button {thisRow["Radio Button"]}", $"Succesfully found radio button {thisRow["Radio Button"]}"))
				{
					Report.IsTrue(thisStudioSupplierManager.CheckSupplierSearchTypeRadio(thisRow["Radio Button"]), $"Failed to confirm radio button {thisRow["Radio Button"]} is displayed", $"Succesfully confirmed radio button {thisRow["Radio Button"]} is displayed");
				}
			}
		}

		[StepDefinition(@"In the Supplier Manager Popup I enter the following search term: (.*)")]
		public void InSupplierManagerPopupIEnterSearchTerm(string searchTerm)
		{
			if (searchTerm.Contains("saved as "))
			{
				searchTerm = searchTerm.Replace("saved as ", "");
		    }
		
			if (Context.GetFromContext(searchTerm) != null)
			{
				searchTerm = Context.GetFromContext(searchTerm).ToString();
			} 

			var thisStudioSupplierManager = new StudioSupplierManager();

			Report.IsTrue(thisStudioSupplierManager.EnterSearchTerm(searchTerm),
				"Failed to enter search term: " + searchTerm,
				"Entered search term: " + searchTerm);
		}

		[StepDefinition(@"In the Supplier Manager Popup I enter in search field Email of user: (.*)")]
		public void ThenInTheSupplierManagerPopupIEnterInSearchFieldEmailIfUserSavedAsTC(string savedAs)
		{
			if (savedAs.Contains("saved as "))
			{
				savedAs = savedAs.Replace("saved as ", "");
			}

			if (Context.GetFromContext(savedAs) != null)
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
				savedAs = user.Email;
			}

			var thisStudioSupplierManager = new StudioSupplierManager();

			Report.IsTrue(thisStudioSupplierManager.EnterSearchTerm(savedAs),
				"Failed to enter search term: " + savedAs,
				"Entered search term: " + savedAs);
		}

		[StepDefinition(@"In the Supplier Manager Popup I enter the following accounts email: (.*)")]
		public void GivenInTheSupplierManagerPopupIEnterTheFollowingAccountsEmail(string accountSavedAs)
		{
			TReVorTestUsers user = TestUsers.GetUserSavedAs(accountSavedAs);

			if (new TopMenuBar().LoggedIn())
			{
				Report.Info("Logged in, logging out");
				Report.IsTrue(new TopMenuBar().ClickSignOut(), "Failed to click Sign Out");
			}

			if (user == null)
			{
				string Branch = TReVorSettings.SoftwareBranch;
				string regexPattern = @"^.*(?=(\/))";
				var regex = new Regex(regexPattern);
				Match match = regex.Match(Branch);
				if (match.Success)
				{
					user = TestUsers.GetUserSavedAs(accountSavedAs, "3", match.Value);
				}
				else
				{
					throw new Exception("User: " + accountSavedAs + " could not be found");
				}
			}
			if (Report.IsTrue(user != null, "Failed to find user saved as: " + accountSavedAs, "Successfully found user saved as: " + accountSavedAs, true))
			{
				var thisStudioSupplierManager = new StudioSupplierManager();
				Report.IsTrue(thisStudioSupplierManager.EnterSearchTerm(user.Username),
					"Failed to enter search term: " + user.Username,
					"Entered search term: " + user.Username);
			}
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
			Delay.Seconds(10);
		}
		[StepDefinition(@"In the Supplier Manager Popup I (should|should not) see supliers")]
		public void ThenInTheSupplierManagerPopupIShouldSeeSupliers(string condition)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			if (condition == "should")
			{
				new StudioSupplierManager().WaitForSuppliersToLoad();
				Report.IsTrue(thisStudioSupplierManager.SupplierExists(), "Failed to confirm there is supplier shown with such search criteria", "Successfully confirmed there is supplier shown with such search criteria");
			}
		}

		//Step can be used for New User Request button in Supplier Manager too
		[StepDefinition(@"In the Supplier Manager Popup I click on button: (.*)")]
		public void ThenInTheSupplierManagerPopupIClickOnTheNewSupplierButton(string button)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			Report.IsTrue(thisStudioSupplierManager.InSupplierManagerClickButton(button), $"Failed to click {button} button",
				$"Clicked {button} button");
		}

		[StepDefinition(@"In the Add New Supplier I click on Accept button")]
		public void ThenInTheAddNewSupplierIClickOnButtonAccept()
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();

			if(Report.IsTrue(thisStudioAddNewSupplier.AcceptButtonExists(), "Failed to find Accept button", "Succesfully found Accept button"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierClickAcceptButton(), "Failed to click Accept button", "Succesfully clicked Accept button");
			}
		}

		[StepDefinition(@"In Add New Supplier I enter Company Name: (.*)")]
		public void ThenIFillOutTheInformationInTheAddNewSupplierCompanyNameName(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.CompanyNameInputExists(), "Failed to find Company Name input", "Succesfully found Company Name input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterCompanyName(value), $"Failed to enter {value} in field Company Name",
			$"Succesfully entered {value} in field Company Name");
			}
			
		}
		[StepDefinition(@"In Add New Supplier I enter Supplier Seller ID: (.*)")]
		public void ThenInAddNewSupplierIEnterSupplierSellerID(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.SellerIdInputExists(), "Failed to find Seller ID input", "Succesfully found Seller ID input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterSellerId(value), $"Failed to enter {value} in field Supplier Seller ID",
			$"Succesfully entered {value} in field Supplier Seller ID");
			}
			
		}
		[StepDefinition(@"In the Supplier Manager Popup I turn (on|off) toggle: (.*)")]
		public void ThenInTheSupplierManagerPopupITurnOnToggleSingle_RetailSubscription(string condition, string toggleName)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			if (Report.IsTrue(thisStudioSupplierManager.ToggleButtonsExists(), "Failed to find toggle buttons", "Succesfully found toggle buttons"))
			{
				if (condition == "on")
				{
					if (thisStudioSupplierManager.ToggleIsON(toggleName))
					{
						Report.Info($"{toggleName} is already turned On");
					}
					else
					{
						Report.IsTrue(thisStudioSupplierManager.ClickToggleButton(toggleName), $"Failed to click toggle {toggleName}", $"Succesfully clicked toggle {toggleName}");

					}
				}
				else
				{
					if (!thisStudioSupplierManager.ToggleIsON(toggleName))
					{
						Report.Info($"{toggleName} is already turned Off");
					}
					else
					{
						Report.IsTrue(thisStudioSupplierManager.ClickToggleButton(toggleName), $"Failed to click toogle {toggleName}", $"Succesfully clicked toggle {toggleName}");
					}
				}
			}

		}


		[StepDefinition(@"In the Supplier Manager Popup I confirm (.*) is turned (on|off)")]
		public void ThenInTheSupplierManagerPopupIConfirmSingle_RetailSubscriptionIsTurnedOn(string toggleName, string condition)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			var newSupplier = new AddNewSupplier();
			string gettoggleColor = null;
			string expectedGreyColor = "rgba(204, 204, 204, 1)";
			string expectedBlueColor = "rgba(33, 150, 243, 1)";
			if (Report.IsTrue(thisStudioSupplierManager.ToggleButtonsExists(), "Failed to find toggle buttons", "Succesfully found toggle buttons"))
			{
				if (condition == "on")
				{
					Report.IsTrue(thisStudioSupplierManager.ToggleIsON(toggleName), $"Failed to confirm {toggleName} toggle is turned on", $"Succesfully confirmed {toggleName} toggle is turned on");
					gettoggleColor = newSupplier.IsToggleButtonEnabled(toggleName);
					Report.IsTrue(gettoggleColor == expectedBlueColor, "Failed to confirm toggle color is blue", "Succesfully confirmed toggle color is blue");
				}
				else
				{
					Report.IsFalse(thisStudioSupplierManager.ToggleIsON(toggleName), $"Failed to confirm {toggleName} toggle is turned off", $"Succesfully confirmed {toggleName} toggle is turned off");
					gettoggleColor = newSupplier.IsToggleButtonEnabled(toggleName);
					Report.IsTrue(gettoggleColor == expectedGreyColor, "Failed to confirm toggle color is grey", "Succesfully confirmed toggle color is grey");
				}
			}
		}
		[StepDefinition(@"In Add New Supplier I enter Country: (.*)")]
		public void ThenInAddNewSupplierIEnterCountry(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.CountryInputExists(), "Failed to find Country input", "Succesfully found Country input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterCountry(value), $"Failed to enter {value} in field Country",
			$"Succesfully entered {value} in field Country");
			}
			
		}

		[StepDefinition(@"I Add New Supplier I enter Country Code: (.*)")]
		public void ThenIAddNewSupplierIEnterCountryCode(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.CountryCodeInputExists(), "Failed to find Country Code input", "Succesfully found Country Code input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterCountryCode(value), $"Failed to enter {value} in field Country Code",
			$"Succesfully entered {value} in field Country Code");
			}	
		}

		[StepDefinition(@"In Add New Supplier I enter Supplier Phone: (.*)")]
		public void ThenInAddNewSupplierIEnterSupplierPhone(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.SupplierPhoneInputExists(), "Failed to find Phone input", "Succesfully found Phone input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterSupplierPhone(value), $"Failed to enter {value} in field Supplier Phone",
			$"Succesfully entered {value} in field Supplier Phone");
			}
		}

		[StepDefinition(@"In Add New Supplier I enter Address: (.*)")]
		public void ThenInAddNewSupplierIEnterAddress(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.AddressInputExists(), "Failed to find Address input", "Succesfully found Address input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterAddress(value), $"Failed to enter {value} in field Address",
			$"Succesfully entered {value} in field Address");
			}
		}

		[StepDefinition(@"In Add New Supplier I enter City: (.*)")]
		public void ThenInAddNewSupplierIEnterCity(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.CityInputExists(), "Failed to find City input", "Succesfully found City input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterCity(value), $"Failed to enter {value} in field City",
			$"Succesfully entered {value} in field City");
			}
			
		}

		[StepDefinition(@"In Add New Supplier I enter State: (.*)")]
		public void ThenInAddNewSupplierIEnterState(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.StateInputExists(), "Failed to find State input", "Succesfully found State input"))
			{
			Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterState(value), $"Failed to enter {value} in field State",
			$"Succesfully entered {value} in field State");
			}		
		}

		[StepDefinition(@"In Add New Supplier I enter Postal Code: (.*)")]
		public void ThenInAddNewSupplierIEnterPostalCode(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.PostalCodeInputExists(), "Failed to find Postal Code input", "Succesfully found Postal Code input"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterPostalCode(value), $"Failed to enter {value} in field Postal Code",
			$"Succesfully entered {value} in field Postal Code");
			}
		}

		[StepDefinition(@"In Add New Supplier I enter Contact Name: (.*)")]
		public void ThenInAddNewSupplierIEnterContactName(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.ContactNameInputExists(), "Failed to find Contact Name input", "Succesfully found Contact Name input"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterContactName(value), $"Failed to enter {value} in field Contact Name",
			$"Succesfully entered {value} in field Contact Name");
			}
		}

		[StepDefinition(@"In Add New Supplier I enter Contact Email: (.*)")]
		public void ThenInAddNewSupplierIEnterContactEmail(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.ContactEmailInputExists(), "Failed to find Contact Email input", "Succesfully found Contact Email input"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterContactEmail(value), $"Failed to enter {value} in field Contact Email",
			$"Succesfully entered {value} in field Contact Email");
			}	
		}

		[StepDefinition(@"I enter email address: (.*)")]
		public void IEnterEmailAddress(string email)
		{
			try
			{
				if (email.Contains("savedas"))
				{
					email = email.Replace("savedas", "").Trim();
					email = Context.GetFromContext(email).ToString();
					var thisStudioAddNewSupplier = new StudioAddNewSupplier();
					if (Report.IsTrue(thisStudioAddNewSupplier.ContactEmailInputExists(), "Failed to find Email address input", "Succesfully found email address input"))
					{
						Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterContactEmail(email), $"Failed to enter {email} in field Email address",
					$"Succesfully entered {email} in field Email address");
					}
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In Add New Supplier I enter Contact Phone: (.*)")]
		public void ThenInAddNewSupplierIEnterContactPhone(string value)
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();
			if (Report.IsTrue(thisStudioAddNewSupplier.ContactPhoneInputExists(), "Failed to find Contact Phone input", "Succesfully found Contact Phone input"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierEnterContactPhone(value), $"Failed to enter {value} in field Contact Phone",
			$"Succesfully entered {value} in field Contact Phone");
			}	
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
			Report.IsTrue(thisStudioSupplierManager.CloseSupplierManager(), "Failed to click close button","Clicked close button");
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



		[StepDefinition(@"I save a product which blue and has retailers and at least 1 UCP as (.*)")]
		public void GivenISaveAProductWhichIsNotRedOrOrangeAndHasRetailersAndUPCAsTestCase(string saveAs)
		{
			var thisStudioSHAManager = new StudioSHAManager();
			ProductInformation info = thisStudioSHAManager.ReturnProductInformationOfProductwithIsBlueAndHasClientsAndUPC();

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

		[StepDefinition(@"I confirm that the list of retailers associated with product (.*) includes retailer (.*)")]
		public void IConfirmThatTheListOfRetailersAssociatedWithProductIncludesRetailer(string productSavedAs, string retailer)
		{
			var thisStudioSHAManager = new StudioSHAManager();
			var product = (ProductInformation)Context.GetFromContext(productSavedAs);
			List<string> retailers = thisStudioSHAManager.ReturnClientsOfProductByID(product.Id);
			Report.IsTrue(retailers.Contains(retailer), "Failed to find retailer " + retailer + " in list of retailers.", "Successfully found retailer " + retailer + ".");
		}

		[StepDefinition(@"I Confirm the Product shows status: (.*) for retailer: (.*)")]
		public void GivenIConfirmTheProductShowsStatusForRetailer(string status, string retailer)
		{
			Report.UseSubSteps = true;
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

			int j = 0;
			bool success = false;
			while (j < 20 && success == false)
			{
				var myStudioShaManager = new StudioSHAManager();
				var thisProductSearch = new StudioSHAManagerProductSearch();


				Report.StartSubStep("I click Srch in the bottom menu list");
				myStudioShaManager.ClickBottomMenuOption("Search");
				Report.Screenshot();
				Report.Info("Going to click find");
				Delay.Seconds(1);
				Report.IsTrue(thisProductSearch.ClickButton("Find"), "Failed to click find", "Clicked find", false, false);
				Report.Info("Waiting for loading bar");
				new StudioSHAManager().Wait_For_Loading_Finish();
				Report.Info("Finished waiting for loading");
				Delay.Seconds(1);
				Report.Screenshot();

				var thisStudioSHAManager = new StudioSHAManager();
				List<Product> RetailerStatuses = thisStudioSHAManager.GetTopXProducts(2);
				var matchingStatusRows = RetailerStatuses.Where(x => x.Status.ToLower() == status.ToLower()).ToList();
				var abbreviationMap = new RetailerAbbreviations().Map;
				foreach (var row in matchingStatusRows)
				{
					var clients = row.Clients;
					var clientAbbreviations = clients.Split(',').Select(x => x.Trim()).ToList();
					foreach (var abbr in clientAbbreviations)
					{
						if (abbreviationMap.ContainsValue(abbr) && abbreviationMap.FirstOrDefault(x => x.Value == abbr).Key == retailer)
						{
							Report.Success("Found product with status: " + status + " and retailer: " + retailer);
							Report.Screenshot();
							return;
						}
					}
				}

				Report.Info($"Failed to find product with status: " + status + " and retailer: " + retailer + " on attempt: " + j + 1);
				Delay.Seconds(60);
				j++;


			}

			Report.Failure("Failed to find product with status: " + status + " and retailer: " + retailer);
			//var thisStepsRetailPartners = new StepsRetailPartners();
			//var matchingClients = matchingStatusRows.Select(x => x.Clients)
			//	.Where(o => thisStepsRetailPartners.MatchAbbreviatedRetailer(o, retailer)).ToList();

			//Report.IsTrue(matchingClients.Count != 0,
			//	"No matching row was found for status: " + status + " and retailer: " + retailer,
			//	"Matching row was found for status: " + status + " and retailer: " + retailer);

		}

		[StepDefinition(@"I should see a new tabbed document whose URL contains DocumentID")]
		public void ThenIShouldSeeANewTabbedDocumentWhoseURLContainsDocumentID()
		{
			Delay.Seconds(30);
			ReadOnlyCollection<string> allWindowHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;

			foreach (string thisWindowHandle in allWindowHandles)
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Window(thisWindowHandle);
				Delay.Seconds(2);
				string currentURL = SeleniumWebDriver.CurrentDriver.Url;
				Report.Info("URL:" + currentURL);
				Report.Screenshot();
				if (SeleniumWebDriver.CurrentDriver.Url.ToLower().Contains("documentid"))
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
				SeleniumWebDriver.CurrentDriver.Close();
				Report.Info("Returning to the main window");
				try
				{
					var handle = Context.GetFromContext("MainWindowHandle").ToString();
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
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
			if (upcNumber == null)
			{
				if (reportFailure)
				{
					Report.Failure("No Non Case UPCs were found in the Product UPC window");
				}
				else
				{
					Report.Info("No Non Case UPCs were found in the Product UPC window");
				}
				Report.Screenshot();
				Report.Info("Closing window");
				SeleniumWebDriver.CurrentDriver.Close();
				Report.Info("Returning to the main window");
				try
				{
					var handle = Context.GetFromContext("MainWindowHandle").ToString();
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
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
			Report.Info("Adding UPC number: " + upcNumber + " to context as: " + savedAs);
			Context.AddToContext(savedAs, upcNumber);
		}				

		[StepDefinition(@"I switch to the Product List UPC Window")]
		public void SwitchToProductListUpcWindow()
		{
			try
			{
				// Switch to window
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				System.Collections.ObjectModel.ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Product UPC window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info("Checking handle: " + handle);
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					if (SeleniumWebDriver.CurrentDriver.FindElement(
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
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(currentHandle);
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				Report.Screenshot();
			}

		}

		[StepDefinition(@"I create a new file saved as: (.*) to upload using the UPCs saved as:")]
		public void GivenICreateANewFileSavedAsToUploadUsingTheUPCsSavedAs(string savedAs, Table upcs)
		{
			throw new NotImplementedException();
		}


		// I click Sample File link and verify the Upload UPC form
		[StepDefinition(@"I click Sample File link and verify the Upload UPC form and save it as (.*)")]
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
			Report.UseSubSteps = true;
			Report.StartSubStep("Getting all product ids from the table");
			//int productsToTry = new StudioSHAManager().GetProductCount();
			var ids = new StudioSHAManager().GetAllProductIds();
			Report.Info("There are " + ids.Count + " product ids");
			//List<Product> products = new StudioSHAManager().GetTopXProducts(10);
			for (int i = 0; i < ids.Count; i++)
			{
				Report.StartSubStep("Saving any UPCs for product on row " + (i + 1));
				string id = ids[i];
				Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
				this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
				this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs, false);
				if (Context.GetFromContext(savedAs) != null)
				{
					Report.Info("Saved UPC to context");
					break;
				}
			}Report.Info("testing0 " + savedAs);
		}

		[StepDefinition(@"I find a UPC number for any product not belonging to Supplier: (.*) in the grid and save to context as: (.*)")]
		public void SaveUpcNumberForAnyProductNotCompany(string notSupplier, string savedAs)
		{
			Report.UseSubSteps = true;
			int productsToTry = new StudioSHAManager().GetProductCount();
			Report.Info("There are " + productsToTry + " products");
			List<Product> products = new StudioSHAManager().GetTopXProducts(productsToTry);
			for (int i = 0; i < productsToTry; i++)
			{
				Report.StartSubStep("Saving any UPCs for product on row " + (i + 1));
				string id = products[i].ID;
				if (products[i].Supplier == notSupplier)
				{
					Report.Info("Product matches supplier: " + notSupplier + " so continuing to the next row");
					continue;
				}
				Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
				this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
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
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
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
			Report.UseSubSteps = true;
			Context.AddToContext("numberOfUpcnumbers", numberOfProducts);
			int productsToTry = new StudioSHAManager().GetProductCount();
			Report.Info("There are " + productsToTry + " products");
			List<Product> products = new StudioSHAManager().GetTopXProducts(productsToTry);
			int j = 1;
			for (int i = 0; i < productsToTry; i++)
			{


				Report.StartSubStep("Saving any UPCs for product on row " + (i + 1));
				string id = products[i].ID;
				Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
				this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
				this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs + j, false);

				if (Context.GetFromContext(savedAs + j) != null)
				{
					Report.Info($"Saved UPC{j} to context");
					j++;
					Report.Screenshot();
					Report.Info("Closing window");
					SeleniumWebDriver.CurrentDriver.Close();
					Report.Info("Returning to the main window");
					try
					{
						var handle = Context.GetFromContext("MainWindowHandle").ToString();
						SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
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
			var excel = new ExcelFunctions(spreadSheetFile, "Sheet1");

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

		[StepDefinition(@"I add Generic Product Names to the UPC bulk upload spreadsheet: (.*)")]
		public void IUpdateBulkUPCFileToIncludeProductNames(string spreadsheetSavedAs)
		{

			//Currently does not work if the values you are trying to edit are blank (which is by default in the sample file)
			var spreadSheetFile = (string)Context.GetFromContext(spreadsheetSavedAs);
			var excel = new ExcelFunctions(spreadSheetFile, "Sheet1");
			int numberOfProducts = excel.Excel_GetNoRows();
			int x = 1;
			for (int i = 1; i <= numberOfProducts; i++)
			{
				Report.IsTrue(excel.EditCell(i, 1, ("TestName" + x)), "Failed to edit UPC" + i + " to: " + ("TestName" + x), "Successfully edited UPC to: " + ("TestName" + x), false, false);
				x++;
			}
		}

		[StepDefinition(@"I find a UPC number for: (.*) products not belonging to Supplier: (.*) in the grid and save to context starting with: (.*)")]
		public void SaveUpcNumberForXProductsNotCompany(int numberOfProducts, string notSupplier, string savedAs)
		{
			Report.UseSubSteps = true;
			Context.AddToContext("numberOfUpcnumbers", numberOfProducts);
			int productsToTry = new StudioSHAManager().GetProductCount();
			Report.Info("There are " + productsToTry + " products");
			List<Product> products = new StudioSHAManager().GetTopXProducts(productsToTry);
			int j = 1;
			for (int i = 0; i < productsToTry; i++)
			{
				Report.StartSubStep("Saving any UPCs for product on row " + (i + 1));
				string id = products[i].ID;
				if (products[i].Supplier == notSupplier)
				{
					Report.Info("Product matches supplier: " + notSupplier + " so continuing to the next row");
					continue;
				}
				Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
				this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
				this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs + j, false);
				if (Context.GetFromContext(savedAs + j) != null)
				{
					Report.Info($"Saved UPC{j} to context");
					j++;
					Report.Screenshot();
					Report.Info("Closing window");
					SeleniumWebDriver.CurrentDriver.Close();
					Report.Info("Returning to the main window");
					try
					{
						var handle = Context.GetFromContext("MainWindowHandle").ToString();
						SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
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
			Report.UseSubSteps = true;
			Report.StartSubStep("I log in to Studio and open SHA Manager");
			new Steps_Shared().GivenICallShared65080LoginToStudioAndOpenSHAManager();
			Report.StartSubStep("I click Search");
			this.IClickTheFollowingOptionInTheBottomMenu("Search");
			SoftwareCredentialBasic user = TReVor.Integrations.Classes.TReVorSettings.Credentials.GetCredential(accountSavedAs);
			var username = "";
			if (user != null)
			{
				username = user.UserName;
			}
			var table = new Table("Search Term", "Search Value");
			table.AddRow("Status", "Completed");
			table.AddRow("User", username);
			Report.StartSubStep("I run a search for status Completed and user: " + username);
			this.GivenInSHAManagerPageIRunSearch(table);
			Report.StartSubStep("I save the upc for any returned product as: " + upcSavedAs);
			this.SaveUpcNumberForAnyProduct(upcSavedAs);

		}
		[StepDefinition(@"I Check that the product under the retailer: (.*) is under the status: (.*)")]
		public void ICheckProductUnderRetailerStatus(string retailer, string expectedStatus)
		{
			string actualStatus = new StudioSHAManager().GetProductStatusByRetailer(retailer);
			//Report.Info("The Status that is actually showing is: " + actualStatus);
			Report.Info("The Status We expect is: " + expectedStatus);
			Report.IsTrue(actualStatus == expectedStatus, "The Product under retailer: " + retailer + " was not in the expected status", "The Product under retailer: " + retailer + " was in the expected status");
		}

		[StepDefinition(@"In SHA Manager I confirm that there is one item in the grid")]
		public void InSHAManagerIConfirmThatThereIsOneItemInTheGrid()
		{
			var sha = new StudioSHAManager();
			Report.IsTrue(sha.ConfirmThereIsOneProductInTheGrid(), "Failed to find one product in the grid!", "Successfully found one product in the grid.");
		}

		[StepDefinition("SHA Search for Archived UPC. This uses environment variable for know archived product")]
		public void SHASearchForArchived()
		{
			string upc = TReVor.Integrations.Classes.TReVorSettings.Variables.GetVariable("Archived UPC");
			this.ThenSHASearchForProductByUPCInAllStatuses(upc);
		}


		[StepDefinition(@"SHA Search for product by UPC: (.*) in all statuses")]
		public void ThenSHASearchForProductByUPCInAllStatuses(string uPC)
		{
			Context.AddToContext("UPC", uPC);
			var table = new Table("SearchTerm", "SearchValue");
			table.AddRow("UPC", "saved as UPC");
			new StudioSHAManager().ClickBottomMenuOption("Search");
			this.GivenInSHAManagerPageIRunSearch(table);
		}

		[StepDefinition(@"I verify the popup message displays with the title ""(.*)""")]
		public void GivenIVerifyThePopupMessageDisplaysWithTheTitle(string title)
		{
			Report.IsTrue(new StudioSHAManagerArchivedProduct().ArchivedUPCPopupTitle(title, out string displayedTitle),
				"Unable to locate popup entitled " + title + ", instead found " + displayedTitle,
				"Located popup titled " + displayedTitle);
		}

		[StepDefinition(@"I close the Archived Product popup")]
		public void ICloseTheArchivedProductPopup() => Report.IsTrue(new StudioSHAManagerArchivedProduct().ClosePopup(), "Popup was not closed", "Popup closed successfully");

		[StepDefinition(@"I verify the file saved as: (.*) contains integers in all fields on the first data row")]
		public void ThenIVerifyTheFileSavedAsContainsIntegersInAllFieldsOnTheFirstDataRow(string savedAs)
		{

			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";

			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				int colCount = ExcelUtils.Excel_GetNoColumns();
				List<string> RowData = ExcelUtils.Excel_GetRow(1);

				Report.IsTrue(colCount == RowData.Count,
					failureMessage: "The number of Columns, " + colCount + " does not equal the number of datapoints. Expected " + RowData.Count,
					successMessage: "The number of Columns matches the number of datapoints as expected");

				foreach (string data in RowData)
				{
					Report.IsTrue(int.TryParse(data, out int result),
						"Report contains unexpected non-integer value " + data,
						showSuccessScreenshot: false);
				}
			}
		}

		[StepDefinition(@"Verify (.*) Advanced Report description reads: (.*)")]
		public void GivenVerifyAdvancedReportDescriptionReads(string report, string description)
		{
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			Report.IsTrue(new SHAAdvancedReporting().CheckReportDescription(report, description, out string actualDescription),
				"Description: \'" + actualDescription + "\' does not match expected \'" + description + "\'",
				"Description matches expected");
		}


		[StepDefinition(@"In SHA Manager - Select Actions - (.*)")]
		public void ICallSharedStep96169SHAManager_SelectProduct_Actions(string actionType)
		{
			var myStudioShaManager = new StudioSHAManager();
			if (!myStudioShaManager.Wait_for_load(30))
			{
				Report.Error("Studio SHA Manager is not showing");
			}

			Report.StartStep("Click " + actionType);
			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption(actionType),
				"Failed to click " + actionType, "Clicked " + actionType);
		}

		[StepDefinition(@"I close the Advanced Reporting popup")]
		public void ICloseTheAdvancedReportingPopup()
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ClickClose(), "Failed to click close on Advanced Reporting popup", "Successfully clicked close on Advanced Reporting popup");
		}

		[StepDefinition(@"In Advanced Reporting I confirm I see a table called (.*)")]
		public void InAdvancedReportingIConfirmISeeATableCalled(string tableName)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ConfirmTableName(tableName), "Failed to find table called " + tableName, "Successfully found table called " + tableName);
		}

		[StepDefinition(@"In Advanced Reporting I confirm I see column header (.*)")]
		public void InAdvancedReportingIConfirmISeeColumnHeader(string header)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ConfirmHeader(header), "Failed to find header called " + header, "Successfully found header called " + header);
		}

		[StepDefinition(@"I verify that the following options are available in the Report List table:")]
		public void IVerifyThatTheFollowingOptionsAreAvailableInTheReportListTable(Table table)
		{
			var shaReport = new SHAAdvancedReporting();
			foreach (TableRow row in table.Rows)
			{
				Report.IsTrue(shaReport.ConfirmAdvancedReportingOptions(row["Report Name"], row["Report Description"]),
					"Failed to find correct name '" + row["Report Name"] + "' or description '" + row["Report Description"] + "'.",
					"Successfully found name '" + row["Report Name"] + "' and description '" + row["Report Description"] + "'.");
			}
		}

		[StepDefinition(@"I confirm that the Report Names are listed in (abc|cba) order")]
		public void IConfirmThatTheReportsAreListedInOrder(string order)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ConfirmReportNamesAlphebeticalOrder(order), "Failed to find Report Names in abc order.", "Successfully found Report Names in abc order.");
		}

		[StepDefinition(@"I confirm that the report descriptions are listed in (abc|cba) order")]
		public void IConfirmThatTheReportDescriptionsAreListedInCBAOrder(string order)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ConfirmReportDescriptionsAlphabeticalOrder(order), "Failed to find Report Descriptions in abc order.", "Successfully found Report Descriptions in abc order.");
		}

		[StepDefinition(@"I confirm that the (up|down) arrow next to Report Name is (active|inactive)")]
		public void IConfirmThatTheDownArrowNextToReportNameIs(string upDown, string isActive)
		{
			var shaReport = new SHAAdvancedReporting();
			if (upDown == "up")
			{
				Report.IsTrue(shaReport.CheckIfReportNameUpArrowActive(isActive), "Failed to find the up arrow as " + isActive, "Successfully found that the up arrow is " + isActive);
			}
			else if (upDown == "down")
			{
				Report.IsTrue(shaReport.CheckIfReportNameDownArrowActive(isActive), "Failed to find the down arrow as " + isActive, "Successfully found that the down arrow is " + isActive);
			}
			else
			{
				Report.Failure("Unexpected parameter found!");
			}

		}

		[StepDefinition(@"I confirm that the (up|down) arrow next to Report Description is (active|inactive)")]
		public void IConfirmThatTheUpDownArrowNextToReportDescriptionIs(string upDown, string isActive)
		{
			var shaReport = new SHAAdvancedReporting();
			if (upDown == "up")
			{
				Report.IsTrue(shaReport.CheckIfReportDescriptionUpArrowActive(isActive), "Failed to find the up arrow as " + isActive, "Successfully found that the up arrow is " + isActive);
			}
			else if (upDown == "down")
			{
				Report.IsTrue(shaReport.CheckIfReportDescriptionDownArrowActive(isActive), "Failed to find the down arrow as " + isActive, "Successfully found that the down arrow is " + isActive);
			}
			else
			{
				Report.Failure("Unexpected parameter found!");
			}
		}

		[StepDefinition(@"I click on the Report Name column")]
		public void IClickOnTheReportNameColumn()
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ClickReportNameHeader(), "Failed to click report name header", "Successfully clicked report name header");
		}

		[StepDefinition(@"I click on the Report Description column")]
		public void IClickOnTheReportDescriptionColumn()
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ClickReportDescriptionHeader(), "Failed to click report description header", "Successfully clicked report description header");
		}


		[StepDefinition(@"I verify the popup data using UPC: (.*)")]
		public void ThenIVerifyThePopupDataUsingUPC(string uPC)
		{

			//Report.IsTrue(new StudioSHAManagerArchivedProduct().VerifyPopupContents(
			//	Context.GetFromContext("UPC").ToString(),
			//	out string failedAt),
			//	"Popup does not appear to contain the appropriate elements. Failed when looking for " + failedAt,
			//	"Popup contains the appropriate elements.");

			Report.IsTrue(new StudioSHAManagerArchivedProduct().VerifyPopupContents(uPC, out string failedAt),
				"Popup does not appear to contain the appropriate elements. Failed when looking for " + failedAt,
				"Popup contains the appropriate elements.");
		}


		[StepDefinition(@"In SHA I Search for exact UPC in (.*) Status for UPC saved as: (.*)")]
		public void InSHAISearchForExactUPCInForUPCSavedAs(string status, string savedAs)
		{

			Report.UseSubSteps = true;
			Report.StartSubStep("I set the status filter to All");
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.WaitForProductList(60);
			myStudioShaManager.SelectFromStatusFilter("All");
			GeneralUtilities.StudioWaitForSpinner();
			myStudioShaManager.WaitForProductList(60);
			Report.Info("Getting saved product: " + savedAs);
			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}
			string upc = (string)Context.GetFromContext(savedAs);
			Report.Info("Looking for id: " + upc);
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"UPC",
				upc
			});
			table.AddRow(new string[] {
				"Status",
				status
			});

			Report.StartSubStep("I click Srch in the bottom menu list");
			myStudioShaManager.ClickBottomMenuOption("Search");
			var myStepsSha = new Steps_SHA();
			Report.StartSubStep($"I enter ID: {upc} in the UPC box, change Status drop down to All, Click find");
			Report.Info("Searching for: " + upc);
			myStepsSha.GivenInSHAManagerPageIRunSearch(table);
			Delay.Seconds(1);
			Report.Info("Waiting for product list");
			Report.IsTrue(myStudioShaManager.WaitForProductList(120), "Product list not found", "Product list is showing", showSuccessScreenshot: false);


		}

		[StepDefinition(@"The Manager Validation Require Popup is not shown")]
		public void TheManagerValidationRequirePopupIsNotShown()
		{
			var managerValidationPopup = new StudioSHAManagerUPCDetailsPopupManagerValidationPopup();
			Report.IsTrue(managerValidationPopup.WaitForContainerToBeInvisible(10), "The Manager Validation Required Popup was shown", "The Manager Validation Required Popup was not shown");

		}

		[StepDefinition(@"In the Advanced Reporting popup I select report (.*)")]
		public void InTheAdvancedReportingPopupISelectReport(string report)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ClickReport(report), "Failed to click report " + report + ".", "Successfully clicked report " + report + ".");
		}

		[StepDefinition(@"In the Advanced Reporting popup I verify I (can|cannot) select report (.*)")]
		public void GivenInTheAdvancedReportingPopupIVerifyICannotSelectReport(string option, string reportName)
		{
			bool expected = option == "can";
			Report.IsTrue(new SHAAdvancedReporting().VerifyReportSelectable(reportName, expected),
				"Report was unexpectadly located",
				"Report is not available, as expected");
		}

		[StepDefinition(@"Verify no Advanced Report exists with description reading: (.*)")]
		public void GivenVerifyNoAdvancedReportExistsWithDescriptionReading(string reportDescription)
		{
			Report.IsTrue(new SHAAdvancedReporting().ReportDescriptionNotAvailable(reportDescription),
				"",
				"");
		}

		[StepDefinition(@"In the Advanced Reporting Retailer Products in Recertification report dropdown I select retailer: (.*)")]
		public void InTheAdvancedReportingRetailerProductsInREcertificationReportDropdownISelectRetailer(string retailer)
		{
			var dropDownForm = new AdvancedReportingDropDownForm();
			Report.Info("Attempting to select " + retailer + " from drop down");
			Report.IsTrue(dropDownForm.SelectOption(retailer), "Failed to select retailer " + retailer, "Successfully selected retailer " + retailer);
		}

		[StepDefinition(@"In the Advanced Reporting Retailer Products in Recertification report dropdown I click submit")]
		public void InTheAdvancedReportingRetailerProductsInRecertificationReportDropdownIClickSubmit()
		{
			var dropDownForm = new AdvancedReportingDropDownForm();
			Report.Info("Attempting to click submit");
			Report.IsTrue(dropDownForm.ClickSubmit(), "Failed to click submit", "Successfully clicked submit");
		}


		[StepDefinition(@"I enter start date (.*) and end date (.*) for Advanced Reporting")]
		public void ThenIEnterStartAndEndDatesForAdvancedReporting(string startDate, string endDate)
		{
			Report.Info("Attempting to enter start (" + startDate + ") and end (" + endDate + ") dates");
			Report.IsTrue(new AdvancedReportingDateForm().EnterStartEndDates(startDate, endDate),
				failureMessage: "Failed to update the date fields",
				successMessage: "Successfully updated the date fields");
		}

		[StepDefinition(@"In the 3rd Party Formula Use in Registrations text box I enter the CAS Number without the WPS for ingredient: (.*)")]
		public void InThe3rdPartyFormulaUseInRegistrationsIEnterTheCASNumber(string savedAs)
		{
			var ingredient = (Ingredients.Ingredient)Context.GetFromContext(savedAs);
			if (ingredient == null)
			{
				Report.Failure("Could not find ingredient saved as " + savedAs + " in context");
				return;
			}
			string CAS = "";
			if (ingredient.CASNumber.Contains("WPS"))
			{
				CAS = ingredient.CASNumber.TrimStart("WPS");
			}
			else
			{
				CAS = ingredient.CASNumber;
			}
			var input = new AdvancedReportingTextInput();
			Report.Info("Attempting to enter CAS number in the input text field");
			Report.IsTrue(input.EnterText(CAS), "Failed to enter the CAS number into the text input field.", "Successfully entered the CAS Number into the text input field.");
		}

		[StepDefinition(@"In the Advanced Reporting 3rd Party Formula Use in Registrations report I click submit")]
		public void InThe3rdPartyFormulaUseInRegistrationsReportIClickSubmit()
		{
			var input = new AdvancedReportingTextInput();
			Report.IsTrue(input.ClickSubmit(), "Failed to click submit.", "Successfully clicked submit.");
		}

		[StepDefinition(@"I verify the (.*) popup displays")]
		public void ThenIVerifyThePreparingReportPopupDisplays(string expectedTitle)
		{
			Report.IsTrue(new SHAAdvancedReporting().VerifyPopupTitle(expectedTitle, out string output),
				failureMessage: "Popup title is not displaying " + expectedTitle + "; instead it displays " + output,
				successMessage: "Popup displays title " + expectedTitle + " as expected");
		}

		/// <summary>
		/// For using a retailer saved in context wrap the retailer name in '<>'
		/// </summary>
		/// <param name="savedAs"></param>
		/// <param name="retailer"></param>
		/// <param name="presence"></param>
		[StepDefinition(@"I check that the UPC number saved as: (.*) and under the retailer: (.*), (does|does not) show the Obsolete UPC Option in the UPC details popup")]
		public void ICheckUPCNumberXObsoleteUPCOptionPresence(string savedAs, string retailer, string presence)
		{
			//For Testing the Dupe UPC Sha Tool
			Report.UseSubSteps = true;

			var studioSHAManger = new StudioSHAManager();
			var shaSteps = new Steps_SHA();
			Delay.Seconds(10);
			new Steps_SHA().SwitchToProductListUpcWindow();
			Delay.Seconds(4);
			Report.StartSubStep($"I Click on the link associated with the UPC saved as: {savedAs}");
			studioSHAManger.ClickUPCSavedAsInProducUPCTable(savedAs);
			Report.StartSubStep("I Check the UPC detail popup appears");
			var upcDetails = new StudioSHAManagerUPCDetails();
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			Report.IsTrue(upcDetails.Wait_for_load(30), "The UPC details popup did not appear", "The UPC details popup appeared");
			if (Regex.IsMatch(retailer, "<(.*)>"))
			{
				var match = Regex.Match(retailer, "<(.*)>").Groups[1].Value;
				if (Context.Contains(match, true))
				{
					retailer = Context.GetFromContext(match).ToString();
				}

			}
			Report.StartSubStep("I Select the Client: " + retailer + " from the select client list");
			IWebElement input = upcDetails.SelectClientInput;
			if (input == null)
			{
				Report.Failure("The Select Client box could not be found!");
				return;
			}
			input.Select(retailer);
			Report.StartSubStep("I wait for the UPC Details Table to Load");
			Report.IsTrue(upcDetailsPopupTable.UpcDetailsTableLoadedOrNull(30), "The UPC details Table did not Appear", "The UPC details Table appeared");
			Report.StartSubStep($"I Confirm that the Obsolete UPC button {presence} appear");
			bool expectedPresenceBool = false;

			switch (presence)
			{
				case "does":
					expectedPresenceBool = true;
					break;
				case "does not":
					break;
				default:
					Report.Error("presence must be either 'does' or 'does not'");
					return;
			}
			Report.IsTrue(upcDetailsPopupTable.ObsoleteUPCButtonPresent() == expectedPresenceBool, "The Obsolete popup incorrectly " + presence + " show", "The Obsolete popup correctly " + presence + " show");

		}

		[StepDefinition(@"I Search for a product containing duplicate UPCs listed in the Spreadsheet 'UPCsDuplicatedwithinAccount.xlsx' and save its details ending with: (.*)")]
		public void ISearchForAProductContainingDuplicateUPCSUsingSpreadSheet(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Replacing the Spreadsheet with a new copy from the embedded resource");
			Report.IsTrue(GeneralUtilities.DeleteFileFromDownloadsFolder("UPCsDuplicatedwithinAccount.xlsx"), "", "");

			if (!EmbeddedResources.ExtractToFile("UL.Selenium.Portal.WERCSmart.Dependencies.Excel.UPCsDuplicatedwithinAccount.xlsx", out string destination))
			{
				Report.Failure("testdoc.xlsx could not be found in the embedded resource");
				return;
			}

			var utils = new ExcelFunctions(destination, "Table");

			List<string> UpcNumbers = utils.Excel_GetColumn(1); //includes the header (so start search at 1 not 0)

			for (int i = 1; i < UpcNumbers.Count; i++)
			{
				Report.StartSubStep($"Searching SHA for a upc found in the duplicate UPC spread sheet. Attempt: {i}");
				string DupeUPCNumberCurrent = UpcNumbers[i];
				//do a search for this value in sha
				//if 2 or more products show,then save this to context then the retailer and id. (use coloums they are in and the same i value)
				//maybe save these^ value to class (existing one?)
				Context.AddToContext($"DupeUPCNumber{savedAs}", DupeUPCNumberCurrent);
				new Steps_SHA().InSHAISearchForExactUPCInForUPCSavedAs("All", $"DupeUPCNumber{savedAs}");
				int numProducts = new StudioSHAManager().GetProductCount();
				Report.StartSubStep("Ensuring the upc was searched for succesfully and that it is a duplicate by checking the number of products found is 2 or more");
				if (numProducts > 1)
				{
					Report.Success("The UPC was searched for succesfully and multiple Products were found");
					List<Product> productsShown = new StudioSHAManager().GetTopXProducts(1);
					string productIDFromSHA = productsShown[0].ID;
					var productInfo = new ProductInformation { Id = productIDFromSHA };
					Context.AddToContext($"ProductID{savedAs}", productInfo);


					string productRetailerInitials = productsShown[0].Clients;
					string productRetailerInitialsFirst = productRetailerInitials.Split(',')[0];
					var fullName = new RetailerAbbreviations().Map.FirstOrDefault(x => x.Value == productRetailerInitialsFirst).Key;
					Context.AddToContext($"ProductRetailer{savedAs}", fullName);

					//List<string> productIDs = utils.Excel_GetColumn(0);
					//string productIDCurrent = productIDs[i];
					//Context.AddToContext("ProductID105970", productIDCurrent); // perhaps get this from the top x product in case this id is gone from being obseleted
					//List<string> productRetailers = utils.Excel_GetColumn(5);
					//string productRetailerCurrent = productRetailers[i];
					//Context.AddToContext("ProductRetailer105970", productRetailerCurrent);
					//Context.AddToContext("ProductRetailer105970", productRetailerCurrent);
					return;
				}
				Report.Info("The number of products found was less than 2, trying the next upc in the spreadsheet");
			}
			Report.Failure("None of the UPCs in the Spreadsheet showed 2 or more products when searched for in SHA");



		}

		[StepDefinition(@"I close the SHA Manager Product UPC details pop up")]
		public void ICloseTheUPCDetailsPopup()
		{

			Report.UseSubSteps = true;
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			Report.StartSubStep("I click the close button in the UPC details popup");
			Report.IsTrue(upcDetailsPopupTable.CloseButton.TryClick(), "Failed to Click Close in the UPC details popup", "Successfully clicked Click Close in the UPC details popup");
			Report.StartSubStep("I check to see if the UPC details popup has closed");
			Report.IsTrue(upcDetailsPopupTable.WaitForContainerToBeInvisible(30), "The UPC details popup did not close", "The UPC details popup was closed");
		}

		[StepDefinition(@"I Click the Obsolete Button and Check a Popup Appears with 'Cancel' and 'Continue' buttons and the following message: (.*)")]
		public void IClickObsoleteAndCheckAPopUpAppearsWithButtonsAndMessageX(string expectedMessage)
		{
			Report.UseSubSteps = true;
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			var upcDetailsConfrimObsoletePopup = new StudioSHAManagerUPCDetailsPopupObselteUPCConfrimrationPopup();

			Report.StartSubStep("I click the Obsolete UPC button in the UPC details popup");
			Report.IsTrue(upcDetailsPopupTable.ObsoleteUPCButton.TryClick(), "Failed to Click Obselete UPC in the UPC details popup", "Successfully clicked Click Obselete UPC in the UPC details popup");
			Report.StartSubStep("I check the Confirm Obsolete UPC popup appears");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.WaitForContainerToBeVisible(10), "The Confirm Obsolete UPC popup did not appear", "The Confirm Obsolete UPC popup appeared");
			Report.StartSubStep("I Check that there is a Cancel Button in the Confirm Obsolete UPC popup");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.CancelButtonPresent(), "The Cancel Button was not present in the Confirm Obsolete UPC popup", "The Cancel Button was present in the Confirm Obsolete UPC popup");
			Report.StartSubStep("I Check that there is a Continue Button in the Confirm Obsolete UPC popup");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.ContinueButtonPresent(), "The Continue Button was not present in the Confirm Obsolete UPC popup", "The Continue Button was present in the Confirm Obsolete UPC popup");
			Report.StartSubStep("I check the text in the Confirm Obsolete UPC popup matches the expected text");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.ConfirmObseleteUPCMessage(expectedMessage), "The found message did not match the expected text", "The found message matched the expected text");

		}

		[StepDefinition(@"I click close in the Confirm Obsolete UPC popup, and the Confirm Obsolete UPC popup is closed and the UPC Details Popup remains on screen.")]
		public void IClickCloseInTheConfirmObsoleteUPCPopUpAndCheckItClosesAndTheUPCDetailsPopUpRemains()
		{
			Report.UseSubSteps = true;
			var upcDetails = new StudioSHAManagerUPCDetails();
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			var upcDetailsConfrimObsoletePopup = new StudioSHAManagerUPCDetailsPopupObselteUPCConfrimrationPopup();
			Report.StartSubStep("I Click Cancel in the Confirm Obsolete UPC popup");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.CancelButton.TryClick(), "Failed to to click Cancel", "Successfully clicked Cancel");
			Report.StartSubStep("I Check that the Confrim Obsolete UPC popup has gone");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.WaitForContainerToBeInvisible(10), "The Confirm Obsolete UPC popup appeared", "The Confirm Obsolete UPC popup did not appear");
			Report.StartSubStep("I Check that the UPC details popup still appears.");
			Report.IsTrue(upcDetails.Wait_for_load(30), "The UPC details popup did not appear", "The UPC details popup appeared");

		}

		[StepDefinition(@"I click Continue in the Confirm Obsolete UPC popup, and the Confirm the Manager Validation Require Popup appears.")]
		public void IClickContinueInTheConfirmObsoleteUPCPopUpAndCheckItTheManagerValidationPopupAppears()
		{
			Report.UseSubSteps = true;
			var upcDetails = new StudioSHAManagerUPCDetails();
			var upcDetailsPopupTable = new StudioSHAManagerUPCDetailsPopupTable();
			var upcDetailsConfrimObsoletePopup = new StudioSHAManagerUPCDetailsPopupObselteUPCConfrimrationPopup();
			var managerValidationPopup = new StudioSHAManagerUPCDetailsPopupManagerValidationPopup();
			Report.StartSubStep("I Click Continue in the Confirm Obsolete UPC popup");
			Report.IsTrue(upcDetailsConfrimObsoletePopup.ContinueButton.TryClick(), "Failed to to click Continue", "Successfully clicked Continue");
			Report.StartSubStep("I Check that the Manager Validation Required Popup appears");
			Report.IsTrue(managerValidationPopup.WaitForContainerToBeVisible(10), "The Manager Validation Required Popup did not appeared", "The Manager Validation Required Popup appeared");



		}

		[StepDefinition(@"In the Advanced Reporting popup I click Submit")]
		public void InTheAdvancedReportingPopupIClickSubmit()
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ClickSubmit(), "Failed to click submit", "Successfully clicked submit");
		}

		[StepDefinition(@"I Check that for the product: (.*) the Details in SHA Manager Match the details found in the file: (.*)")]
		public void ICheckThatForTheProductXTheDetailsInSHAManagerMatchTheFile(string productInfoSavedAs, string fileSavedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I Find the details in SHA manager for the product on screen.");
			List<Product> productsShown = new StudioSHAManager().GetTopXProducts(1);
			if (!productsShown.Any())
			{
				Report.Failure("Could not find any products");
				return;
			}
			string shaProductID = productsShown[0].ID;
			Report.Info($"The product found has ID: {shaProductID}");
			var productInfo = (ProductInformation)Context.GetFromContext(productInfoSavedAs);
			string fileProductID = productInfo.Id;

			if (!Report.IsTrue(shaProductID == fileProductID, "The product found in SHA did not match the one searched from file", "The product found in SHA did match the one searched from file"))
			{
				return;
			}
			string shaProductName = productsShown[0].Name;
			Report.Info($"The product in SHA has Name: {shaProductName}");
			DateTime shaCurrentSubmissionDate = productsShown[0].CurrentSubmission;
			Report.Info($"The product in SHA has a Current Submission Date of: {shaCurrentSubmissionDate}");
			DateTime shaOriginalSubmissionDate = productsShown[0].OriginalSubmission;
			Report.Info($"The product in SHA has a Original Submission Date of: {shaOriginalSubmissionDate}");
			string shaClients = productsShown[0].Clients;
			var shrdStep = new Steps_Shared();


			Report.StartSubStep($"Checking that the details found in SHA, match those found in the file saved as: {fileSavedAs}");
			string file = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			if (Report.IsTrue(!file.IsNullOrEmpty(), "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + file))
			{
				var utils = new ExcelFunctions(file.ToString(), "Table");
				var rows = utils.Excel_GetNoRows();
				for (int i = 1; i < rows; i++)
				{
					var rowContents = utils.GetRowContents(i);
					var productID = rowContents[0];
					if (productID == fileProductID)
					{
						Report.Info($"The Product Name in the File is: {rowContents[1]}");
						Report.IsTrue(shaProductName == rowContents[1], "The product names did not match", "The product names matched!");

						DateTime lastSubDate;
						DateTime.TryParse(rowContents[3], out lastSubDate);
						Report.Info($"The Last Submission Date in the File is: {rowContents[3]}");
						Report.IsTrue(shaCurrentSubmissionDate == lastSubDate, "The Current Submission Date in SHA did not match the Last Submission date in the file", "The Current Submission Date in SHA did match the Last Submission date in the file");

						DateTime orginalCreationDate;
						DateTime.TryParse(rowContents[4], out orginalCreationDate);
						Report.Info($"The Original Creation date in the File is: {rowContents[4]}");
						string fileOrgDatestr = orginalCreationDate.ToString();
						string shaOrgDatestr = shaOriginalSubmissionDate.ToString();
						string fileOrgDateEdited = fileOrgDatestr.Replace("12:00:00 AM", "").Trim();
						Report.IsTrue(shaOrgDatestr.Contains(fileOrgDateEdited), "The Origninal Submission Date in SHA did not match the Original Creation Date in the file", "The Original Submission Date in SHA did match the Original Creation Date in the file");
						Report.Info($"The Retailers Associated in the File is: {rowContents[5]}");
						Report.IsTrue(shaClients.Contains(rowContents[5]), "The Clients in SHA did not match the Retailers associated in the file", "The Clients in SHA matched the Retailers associated in the file");


						//Report.StartStep($"I right click on the product with ID: {fileProductID}");
						new Steps_Shared().Shared75309_SHA_SelectProduct_UpcList(productInfoSavedAs);
						var studioSHAManger = new StudioSHAManager();

						Delay.Seconds(10);
						this.SwitchToProductListUpcWindow();
						Delay.Seconds(4);
						List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
						Report.Info($"The number of UPCs displayed in the UPC Details page is: {displayedUpcs.Count}");
						Report.IsTrue(displayedUpcs.Count.ToString() == rowContents[6], "The number of UPCS in SHA for the product did not match the Number of Active UPCs for the product in the file", "The number of UPCS in SHA for the product matched the Number of Active UPCs for the product in the file");
						Report.StartStep($"Checking that the date that appears under the 'Current Submission' column in SHA Manager is exactly one year before the date that appears in the 'Eligible for Deletion' column in the file");
						var eligibleDate = rowContents[2];
						DateTime actualEligibleDate;
						DateTime.TryParse(eligibleDate, out actualEligibleDate);
						DateTime expectedEligibleDate = actualEligibleDate.AddYears(-1);
						Report.IsTrue(shaCurrentSubmissionDate == expectedEligibleDate, "The Current Submission Date in SHA is not exactly one year before the Eligible for deletion date in the file", "The Current Submission Date in SHA is exactly one year before the Eligible for deletion date in the file");
						return;

					}

				}
				Report.Failure($"The product with ID: {fileProductID} could not be found in the spreadsheet");
				return;

			}

		}

		[StepDefinition(@"I wait for the Advanced Reporting Preparing Report popup to disappear")]
		public void WaitForAdvancedReportingPopupToDisappear()
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.WaitForPreparingReportPopup(), "Failed to wait for Preparing Report popup", "Successfully waited for Preparing Report popup");
		}

		[StepDefinition(@"I search in the excel spreadsheet saved as: (.*) for product saved as: (.*) and save its information as: (.*)")]
		public void ISearchInTheExcelSpreadsheetForProductAndSaveItsInformation(string excel, string product, string saveAs)
		{
			var prodInfo = (ProductInformation)Context.GetFromContext(product);
			object File = Context.GetFromContext(excel);
			if (Report.IsTrue(File != null, "No matching file was found for name: " + excel + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				List<string> allProducts = ExcelUtils.Excel_GetColumn(0);
				if (!allProducts.Contains(prodInfo.Id))
				{
					Report.Failure("Failed to find WPSID " + prodInfo.Id + " in WPSID column of excel spreadsheet!");
				}
				else
				{
					int index = allProducts.IndexOf(prodInfo.Id);
					List<string> foundProductInfo = ExcelUtils.Excel_GetRow(index);
					var dict = new Dictionary<string, string>();
					for (int i = 0; i < ColumnTitles.Count; i++)
					{
						dict[ColumnTitles[i]] = foundProductInfo[i];
					}
					Context.AddToContext(saveAs, dict);
					Report.IsTrue(foundProductInfo.Contains(prodInfo.Id), "Failed to select proper row in the spreadsheet", "Successfully selected proper row in spreadsheet");
				}
			}
		}

		[StepDefinition(@"I confirm that the following information is present in the excel info saved as: (.*):")]
		public void IConfirmThatTheFollowingInformationIsPresentInTheExcelInfoSavedAs(string savedAs, Table table)
		{
			var excelInfo = (Dictionary<string, string>)Context.GetFromContext(savedAs);
			var prodInfo = (ProductInformation)Context.GetFromContext(table.Rows[0]["WPSID"]);
			string upc = Context.GetFromContext(table.Rows[0]["UPC"])?.ToString() ?? "";

			Report.IsTrue(excelInfo["WPSID"] == prodInfo.Id, "Failed to match WPSID " + prodInfo.Id + " to information from excel spreadsheet. Excel: " + excelInfo["WPSID"],
				"Successfully matched WPSID " + prodInfo.Id + " to information from excel spreadsheet.");

			Report.IsTrue(excelInfo["UPC"] == upc, "Failed to find upc " + upc + " in excel spreadsheet information. Instead found: " + excelInfo["UPC"],
				"Successfully found upc " + upc + " in excel spreadsheet information.");

			Report.IsTrue(excelInfo["DPCI"] == table.Rows[0]["DPCI"], "Failed to match DPCI " + table.Rows[0]["DPCI"] + " to excel information. Excel: " + excelInfo["DPCI"],
				"Successfully matched DPCI " + table.Rows[0]["DPCI"] + " to information in excel spreadsheet.");

			Report.IsTrue(excelInfo["Product Name"] == prodInfo.Name, "Failed to match Product Name " + prodInfo.Name + " to excel information. Excel: " + excelInfo["Product Name"],
				"Successfully matched Product Name " + prodInfo.Name + " to information in excel spreadsheet.");

			Report.IsTrue(excelInfo["Supplier"] == table.Rows[0]["Supplier"], "Failed to match Supplier " + table.Rows[0]["Supplier"] + " to excel information. Excel: " + excelInfo["Supplier"],
				"Successfully matched Supplier " + table.Rows[0]["Supplier"] + " to information in excel spreadsheet.");

			Report.IsTrue(excelInfo["Status"] == table.Rows[0]["Status"], "Failed to match Status " + table.Rows[0]["Status"] + " to excel information. Excel: " + excelInfo["Status"],
				"Successfully matched Status " + table.Rows[0]["Status"] + " to information in excel spreadsheet.");

			if (table.Rows[0]["UPC Status"] == "value")
			{
				Report.IsTrue(excelInfo["UPC Status"] != "", "Failed to find a value in the UPC Status column", "Successfully found a value of " + excelInfo["UPC Status"] + " in the UPC Status column.");
			}
			else
			{
				Report.IsTrue(excelInfo["UPC Status"] == table.Rows[0]["UPC Status"], "Failed to match UPC Status " + table.Rows[0]["UPC Status"] + " to excel information. Excel: " + excelInfo["UPC Status"],
					"Successfully matched UPC Status " + table.Rows[0]["UPC Status"] + " to information in excel spreadsheet.");
			}

			if (table.Rows[0]["Product Activity Date"] == "today")
			{
				var date = Convert.ToDateTime(excelInfo["Product Activity Date"]);
				DateTime today = DateTime.Today;

				Report.IsTrue(date.Day == today.Day && date.Month == today.Month && date.Year == today.Year,
					"Failed to match date to today's date. Instead found: " + excelInfo["Product Activity Date"],
					"Successfully matched Product Activity Date to today's date.");
			}
			else
			{
				Report.IsTrue(excelInfo["Product Activity Date"] == table.Rows[0]["Product Activity Date"], "Failed to match Product Activity Date " + table.Rows[0]["Product Activity Date"] + " to excel information. Excel: " + excelInfo["Product Activity Date"],
					"Successfully matched Product Activity Date " + table.Rows[0]["Product Activity Date"] + " to information in excel spreadsheet.");
			}
		}

		[StepDefinition(@"I confirm the Product UPC window has opened")]
		public void ConfirmProductUpcWindowOpened()
		{
			ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			Report.Info("Looking for SHA Manager Product UPC window");
			bool foundWindow = false;
			foreach (string handle in allHandles)
			{
				Report.Info("Checking handle: " + handle);
				SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
				if (SeleniumWebDriver.CurrentDriver.FindElement(
						By.XPath(".//h1[contains(text(),'WERCSmart Product ID')]"), 2) != null)
				{
					Report.Success("Tab was switched successfully!");
					Report.Screenshot();
					var currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
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
		}
	
		[StepDefinition(@"I verify the file saved as: (.*) against the specific requirements for Daily Report - WERCSmart Additional Reports Published")]
		public void ThenIVerifyTheFileSavedAsAgainstTheSpecificRequirementsForDailyReport_WERCSmartAdditionalReportsPublished(string savedAs)
		{
			Report.IsTrue(new DailyReportWERCSmartAdditionalReportsPublished().VerifyFile(savedAs), "Report did not match expectations", "Report conforms to stated spec");

			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption("Advanced Reporting"),
				"Failed to click document management", "Clicked document management");
			var shaReport = new SHAAdvancedReporting();
			string report = "Product Registrations Published";
			Report.IsTrue(shaReport.ClickReport(report), "Failed to click report " + report + ".", "Successfully clicked report " + report + ".");
			Delay.Seconds(2);


		}
		[StepDefinition(@"I enter start Date: (.*) and end Date: (.*) for the Advanced report then I click Submit")]
		public void IEnterAStartDateForTheProductRegistrationPublishedReportClickSubmit(string startDate, string endDate)
		{
			Report.UseSubSteps = true;
			var shaReport = new SHAAdvancedReporting();
			Report.StartSubStep("I enter an Start Date");
			shaReport.EnterStartDate(startDate);
			Report.StartSubStep("I enter an End Date");
			shaReport.EnterEndDate(endDate);
			Report.StartSubStep("I Click Submit");
			shaReport.ClickSubmit();

		}

		[StepDefinition(@"I Check that the Description Text for the Report: (.*) is shown as: (.*)")]
		public void ICheckThatTheDescriptionForTheReportIsShowAS(string reportName, string reportText)
		{
			var shaReport = new SHAAdvancedReporting();

			Report.IsTrue(shaReport.ReportDescriptionIsCorrect(reportName, reportText), "The Description was not as expected", "The Descripton was as expected");

		}

		[StepDefinition(@"I select the: (.*) report from Advanced Reporting in SHA")]
		public void ISelectProductRegistrationPublishedReportFromAdvancedReportingInSHA(string report)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("Click Advanced Reporting");
			Report.IsTrue(new StudioSHAManager().ClickActionsMenuOption("Advanced Reporting"),
				"Failed to click document management", "Clicked document management");
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ClickReport(report), "Failed to click report " + report + ".", "Successfully clicked report " + report + ".");
			Delay.Seconds(2);


		}

		[StepDefinition(@"In The advanced reporting screen I enter WPSID saved as: (.*)")]
		public void InTheAdvancedReportingScreenIEnterWPSIDSavedAs(string savedAs)
		{
			var shaReport = new SHAAdvancedReporting();
			var product = new ProductInformation();
			if (Context.Contains(savedAs))
			{
				product = (ProductInformation)Context.GetFromContext(savedAs);
			}
			else
			{
				Report.Failure($"Could not find WPSID savedAs: {savedAs} in context");
				return;
			}

			string wpsid = product.Id;
			Report.IsTrue(shaReport.EnterWPSID(wpsid), "Failed to enter WPSID: " + wpsid, "Successfully entered WPSID: " + wpsid);

		}

		[StepDefinition(@"In The advanced reporting screen I choose retailer: (.*)")]
		public void InTheAdvancedReportingScreenIChooseRetailer(string retailer)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ChooseRetailer(retailer), "Failed to choose retailer: " + retailer, "Successfully selected the retailer: " + retailer);
		}

		[StepDefinition(@"I delete the Advanced Report file saved as (.*)")]
		public void DeleteExcelFile(string savedAs)
		{
			string file = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + savedAs);
				return;
			}
			Report.Info("Deleting file: " + file);
			File.Delete(file);
		}

		[StepDefinition(@"I Click close in the Advanced Reporting Popup")]
		public void ClickCloseInAdvancedReports()
		{
			Report.IsTrue(new SHAAdvancedReporting().CloseButton.TryClick(), "Failed to click the close button", "Successfully click the close button");
		}

		[StepDefinition(@"In The advanced reporting screen I Click Option: (Includes Water|Contains Alcohol)")]
		public void InTheAdvancedReportingScreenClickOption(string optionChoice)
		{
			var shaReport = new SHAAdvancedReporting();
			if (optionChoice == "Includes Water")
			{
				Report.IsTrue(shaReport.ClickIncludesWater(), "Failed to Click Option: " + optionChoice, "Successfully Clicked Option: " + optionChoice);
			}
			if (optionChoice == "Contains Alcohol")
			{
				Report.IsTrue(shaReport.ClickContainsAlcohol(), "Failed to Click Option: " + optionChoice, "Successfully Clicked Option: " + optionChoice);
			}
		}

		[StepDefinition(@"I enter UPC Size: (.*) in the advanced reporting popup")]
		public void IEnterUPCSizeInTheAdvancedReportingPopup(string size)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.StartStep("I enter UPC Size");
			shaReport.EnterUPCSize(size);

		}

		[StepDefinition(@"In The advanced reporting screen I choose WERCSmart Retail Recipient Code: (.*)")]
		public void InTheAdvancedReportingScreenIChooseRetailRecipientCode(string recipient)
		{
			var shaReport = new SHAAdvancedReporting();
			Report.IsTrue(shaReport.ChooseRecpientCode(recipient), "Failed to choose recipient: " + recipient, "Successfully selected the recipient: " + recipient);
		}

		[StepDefinition(@"I move the product saved as (.*) from Submitted to Completed Status")]
		public void IMoveTheProductSavedAsFromSubmittedToCompletedStatus(string saveAs)
		{
			Report.UseSubSteps = true;
			var MyStepsShared = new Steps_Shared();
			var MyStepsSHA = new Steps_SHA();
			var MyStepsStudio = new Steps_Studio();
			var MyStepsAPI = new API.Steps_Api();

			Report.StartSubStep("Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Submitted", saveAs);
			Report.StartSubStep("Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Submitted");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Submitted");
			Report.StartSubStep("Given I call Shared Step 40657(SHA Manager - Submitted - Select product > process product data for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(saveAs);
			Report.StartSubStep("Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			Report.StartSubStep("Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Assigned");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Assigned");
			Report.StartSubStep("And I call Shared Step 55662(WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(saveAs);
			Report.StartSubStep("And I check whether the current environment is Staging or Production and if it is I skip the next three steps");
			MyStepsStudio.GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps();
			Report.StartSubStep("And I call Shared Step 68969(WPS Studio - Open PD +, edit existing with specific product > Click Continue for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(saveAs);
			Report.StartSubStep("And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: " + saveAs);
			MyStepsShared.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(saveAs);
			Report.StartSubStep("And I call Shared Step 55663(WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(saveAs);
			Report.StartSubStep("Given I call Shared Step 59066(Go to SHA Manager)");
			MyStepsShared.GivenICallSharedStep59066GoToSHAManager();
			Report.StartSubStep("Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			Report.StartSubStep("Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Completed");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Completed");
		}

		[StepDefinition(@"In the Supplier Manager Popup I click on the first supplier returned")]
		public void InTheSupplierManagerPopupIClickOnFirstSupplier()
		{
			Report.Info("Attempting to click on the first supplier returned in the supplier manager popup");
			Report.IsTrue(new StudioSupplierManager().ClickFirstSupplier(), "Failed to click the first supplier", "Successfully clicked the first supplier");
			Report.Info("Waiting until the Category headers appear");
			Report.IsTrue(new StudioSupplierManager().CheckCategoriesPresent(), "The category headers were not present", "The category headers were present");


		}

		[StepDefinition(@"I ensure that there is a SubscriptionStatus column in the Supplier Manager popup")]
		public void IEnsureThatThereIsASubscriptionStatusColumn()
		{
			Report.Info("Checking for SubscriptionStatus column");
			Report.IsTrue(new StudioSupplierManager().CheckForSupplierManagerColumn("SubscriptionStatus"), "Failed to find SubscriptionStatus column", "Successfully found SubscriptionStatus column");
		}

		[StepDefinition(@"In the Supplier Manager Popup I check next columns exist:")]
		public void ThenInTheSupplierManagerPopupICheckNextColumnsExist(Table table)
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			foreach (TableRow thisRow in table.Rows)
			{
				if (Report.IsTrue(thisStudioSupplierManager.ColunmTitleExists(thisRow["Column"]), $"Failed to find column {thisRow["Column"]}", $"Succesfully found column {thisRow["Column"]}"))
				{
					Report.IsTrue(thisStudioSupplierManager.CheckForSupplierManagerColumn(thisRow["Column"]), $"Failed to confirm column {thisRow["Column"]} is displayed", $"Succesfully confirmed column {thisRow["Column"]} is displayed");
				}
			}
		}
		[StepDefinition(@"In the Supplier Manager Popup I check value in Subscription column should be Tiered, Single, Single\+Tier or it should be blank")]
		public void ThenInTheSupplierManagerPopupICheckValueInSubscriptionColumnShouldBeTieredSingleSingleTierOrItShouldBeBlank()
		{
			var thisStudioSupplierManager = new StudioSupplierManager();
			if (Report.IsTrue(thisStudioSupplierManager.ColumnNamesExists(), $"Failed to find columns names", $"Succesfully found column names"))
			{
				Report.IsTrue(thisStudioSupplierManager.CheckSubscriptionColumnValues(), $"Failed to confirm all values in Subscription column are Tiered, Single, Single+Tier or blank", $"Succesfully confirmed all values in Subscription column are Tiered, Single, Single+Tier, blank or there is no values to be checked");
			}
		}

		[StepDefinition(@"I ensure that I see the status (.*) under the SubscriptionStatus column")]
		public void IEnsureThatISeeTheStatusUnderTheSubscriptionStatusColumn(string status)
		{
			Report.Info("Checking for status " + status + " under the SubscriptionStatus column");
			Report.IsTrue(new StudioSupplierManager().CheckForSupplierManagerColumnValue("SubscriptionStatus", status), "Failed to find status " + status + " for the SubscriptionStatus", "Successfully found SubscriptionStatus " + status + ".");
		}

		[StepDefinition(@"I ensure that the Subscription tab has (.*) font")]
		public void IEnsureThatTheSubscriptionTabHasFont(string color)
		{
			Report.Info("Checking for " + color + " font on Subscription tab");
			Report.IsTrue(new StudioSupplierManager().CheckForSubscriptionTabColor(color), "Failed to find " + color + " font on the Subscription tab", "Successfully found " + color + " font on the Subscription tab");
		}

		[StepDefinition(@"I ensure that the Subscription tab has (.*) background color")]
		public void IEnsureThatTheSubscriptionTabHasBackgroundColor(string color)
		{
			Report.Info("Checking for " + color + " background color on Subscription tab");
			Report.IsTrue(new StudioSupplierManager().CheckForSubscriptionTabBackgroundColor(color), "Failed to find " + color + " background color on the Subscription tab", "Successfully found " + color + " background color on the Subscription tab");
		}



		[StepDefinition(@"In The Supplier Manager popup I click on the category: (.*)")]
		public void InTheSupplierManagerPopupIClickCategory(string category)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"Starting to attempt to click the catagory: {category}");
			Report.IsTrue(new StudioSupplierManager().ClickCategory(category), "Failed to click the category", "Successfully clicked the category");
			Report.StartSubStep($"Checking that the catagory: {category} is active");
			Report.IsTrue(new StudioSupplierManager().CategoryIsActive(category), "The Category was not active", "The Category was active");
			Delay.Seconds(15);
		}

		[StepDefinition(@"In The Supplier Manager popup I click on the 'Clear Cart for All Users' button")]
		public void InTheSupplierManagerPopupIClickTheClearCartForAllUsersButton()
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"Starting to attempt to click the 'Clear Cart for All Users' button");
			Report.IsTrue(new StudioSupplierManager().ClickClearCartForAllUsers(), "Failed to click the 'Clear Cart for All Users' button", "Successfully clicked the 'Clear Cart for All Users' button");
		}

		[StepDefinition(@"In The Supplier Manager popup I check that the column: (.*) contains all values found in the table:")]
		public void InTheSupplierManagerPopupICheckThatColumnXContainsAllValues(string column, Table table)
		{
			Report.Info("Converting the table to a List");
			List<string> expectedValues = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedValues.Add(thisRow["Expected Value"]);
			}
			Report.IsTrue(new StudioSupplierManager().DataConsentTableIsPresent(), "The Data Consent Tier table was not showing", "The Data Consent Tier table was showing");
			Report.IsTrue(new StudioSupplierManager().ColumnContains(column, expectedValues), "The column: " + column + " did not contain all the expected values", "The column: " + column + " did contain all the expected values");

		}

		[StepDefinition(@"In the supplier manager popup I check that Data Tier Consent Table contains the following columns headings:")]
		public void InTheSupplierManagerPopupICheckThatTheDataConsentTierTableContainsHeaders(Table table)
		{
			Report.Info("Converting the table to a List");
			List<string> expectedValues = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedValues.Add(thisRow["Expected Headers"]);
			}
			Report.IsTrue(new StudioSupplierManager().DataConsentTiersTableContainsHeaders(expectedValues), "The Headers were not as expected", "The headers were as expected");

		}

		[StepDefinition(@"In the Supplier Manager popup I check that in The Data Tier Consent Table the email column contains only valid email addresses")]
		public void InTheSupplierManagerPopupICheckThatTheDataConsentTierTableContainsOnlyValidEmailAddress()
		{
			Report.IsTrue(new StudioSupplierManager().EmailColumnContainsEmailAddresses(), "The columns contained non valid email addresses", "The column contained only valid email addresses");

		}

		[StepDefinition(@"In the Supplier Manager popup I check that in The Data Tier Consent Table the date column contains dates that are in the format mm-dd-yyyy")]
		public void InTheSupplierManagerPopupICheckThatTheDataConsentTierTableContainsOnlyDatesInFormatmmddyyyy()
		{
			Report.IsTrue(new StudioSupplierManager().DateColumnContainsValidmmddyyyy(), "The Date column contained at least one non valid date", "The Date column contained only valid dates");

		}

		[StepDefinition(@"In The Supplier Manager popup I check that the column: (.*) is in alphabetical order")]
		public void ThenInTheSupplierManagerPopupICheckThatTheColumnRetailerIsInAlphabeticalOrder(string columnName)
		{
			Report.IsTrue(new StudioSupplierManager().RetailsAreInAlphabeticalOrder(), "The retailers were not in alphabetical order in column: " + columnName, "The retailers were in alphabetical order in column: " + columnName);
		}

		[StepDefinition(@"In the Clear Cart for All Users Popup I confirm the correct text is displayed")]
		public void GivenIConfirmTheConfirmClearCartForAllUsersPopupContainsTheCorrectText()
		{
			Report.IsTrue(new StudioSupplierManager().CheckTextInConfirmClearCartForAllUsersPopup(), "The 'Confirm Clear Cart for All Users' Popup did not display the correct text", "The 'Confirm Clear Cart for All Users' Popup displayed the correct text");
		}

		[StepDefinition(@"In the Clear Cart for All Users Popup I click the Continue button")]
		public void GivenInTheClearCartForAllUsersPopupIClickTheContinueButton()
		{
			Report.IsTrue(new StudioSupplierManager().ClickContinueInConfirmClearCartForAllUsersPopup(), "Failed to click the Continue button in 'Confirm Clear Cart for All Users' Popup", "Successfully clicked the Continue button in 'Confirm Clear Cart for All Users' Popup");
		}

		[StepDefinition(@"In the Clear Shopping Cart Popup I enter the following UserID: (.*), Password: (.*), TFS Ticket Number: (.*), Support Ticket Number: (.*) then I click Continue")]
		public void GivenInTheClearShoppingCartPopupIEnterTheFollowingUserIDAPasswordATFSTicketNumberASupportTicketNumberAThenIClickContinue(string userID, string password, string tfsTicketNumber, string supportTicketNumber)
		{
			Report.IsTrue(new StudioSupplierManager().EnterInformationInClearShoppingCartPopup(userID, password, tfsTicketNumber, supportTicketNumber), "Failed to enter information in 'Clear Shopping Cart' Popup", "Successfully entered information in 'Clear Shopping Cart' Popup");
			Report.IsTrue(new StudioSupplierManager().ClickContinueInClearShoppingCartPopup(), "Failed to click Continue in 'Clear Shopping Cart' Popup", "Successfully clicked Continue 'Clear Shopping Cart' Popup");
			Delay.Seconds(10);
		}

		[StepDefinition(@"In the Results Clear Shopping Cart for All Users Popup I confirm the correct text is displayed")]
		public void GivenInTheResultsClearShoppingCartForAllUsersPopupIConfirmTheCorrectTextIsDisplayed()
		{
			Report.IsTrue(new StudioSupplierManager().CheckTextInResultsClearShoppingCartForAllUsersPopup(), "The 'Results Clear Shopping Cart for All Users' Popup did not display the correct text", "The 'Results Clear Shopping Cart for All Users' Popup displayed the correct text");
		}

		[StepDefinition(@"In the SHA manager I search for the Product saved as: (.*) and if its Status is Accepted I set the retailers: to Completed and check the Products Grid")]
		public void InTheSHAMangerGridIFindProductAndEnsureIsCompletedIfAccepted(string productSavedAs, Table retailerTable)
		{
			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			string ID = ProductDetails.Id;
			string status = "Accepted";
			Report.Info("Searching for id: " + ID + " and status: " + status);

			int counter = 0;

			bool found = false;

			while (counter < 3 && !found)
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
			if (found == true)
			{
				new Steps_Shared().GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(productSavedAs, retailerTable);
				this.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(productSavedAs, "Completed");
			}
			else
			{
				this.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(productSavedAs, "Completed");
			}

		}

		[StepDefinition(@"I check for the following columns in UPC Retailer and Feed")]
		public void ThenICheckForTheFollowingColumnsInUPCRetailerAndFeed(Table table)
		{
			StudioSHAManager studioSHAManagerObject = new StudioSHAManager();
			List<string> columnsNotFound = studioSHAManagerObject.FindColumnInUPCRetailerAndFeedPageWithTable(table);

			Report.IsTrue(columnsNotFound.Count == 0, "One or more of the columns were not found", "Successfully found all columns");

			foreach (string columnName in columnsNotFound)
			{
				Report.Info("Column not found: " + columnName);
			}

		}

		
		[StepDefinition(@"I save all clients for product saved as: (.*)")]
		public void ThenISaveAllClientsForPrductsSavedAsTestCase(string savedAs)
		{
			StudioSHAManager studioSHAManagerObject = new StudioSHAManager();

			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = ProductDetails?.Id;
			if (id == null)
			{
				throw new Exception("Could not find product saved to context as: " + savedAs);
			}

			var clients = studioSHAManagerObject.FindClientsForProduct(id);
			if (clients != null)
			{
				var key = id + "'s Clients";
				Context.AddToContext(key, clients);
			}

			Report.IsTrue(clients != null, "Failed to find product clients", "Successfully found product clients");
		}


		[StepDefinition(@"I confirm that there is a 'U' next to the following product saved as: (.*)")]
		public void ThenIConfirmThatThereIsANextToTheFollowingProductSavedAs(string productSavedAs)
		{
			StudioSHAManager studioSHAManagerObject = new StudioSHAManager();

			var ProductDetails = (ProductInformation)Context.GetFromContext(productSavedAs);
			string ID = ProductDetails.Id;

			Report.IsTrue(studioSHAManagerObject.ConfirmUInSecondColumn(ID), "Failed to find 'U' next to product with product ID: " + ID, "Successfully found a 'U' next to product with product ID: " + ID);
		}

		[StepDefinition(@"I Close 'Supplier Manager'")]
		public void ThenICloseSupplierManager()
		{
			StudioSupplierManager studioSupplierManagerObject = new StudioSupplierManager();
			Report.IsTrue(studioSupplierManagerObject.CloseSupplierManager(), "Failed to close dialog", "Successfully closed dialog");
		}


		[StepDefinition(@"Confirm that '(.*)' shows (.*) marked with a '(.*)'")]
		public void ThenConfirmThatShowsTierTierAndTierMarkedWithA(string supplier, string tiers, string marked)
		{
			StudioSupplierManager studioSupplierManagerObject = new StudioSupplierManager();
			var arr = tiers.Split(',');
			Report.IsTrue(studioSupplierManagerObject.ConfirmTierHasCorrectMarkingForRetailer(supplier, arr, marked), "Failed to confirm all tier markings", "Successfully confirmed all tier markings");
		}


		[StepDefinition(@"Select the '(.*)' Tab in Supplier Manager")]
		public void ThenSelectTheTabInSupplierManager(string tabName)
		{
			StudioSupplierManager studioSupplierManagerObject = new StudioSupplierManager();
			Report.IsTrue(studioSupplierManagerObject.ClickTabWithName(tabName), "Failed to the following tab: " + tabName, "Successfully clicked the following tab: " + tabName);
			Delay.Seconds(5);
		}


		[StepDefinition(@"Select the supplier with the following name in Supplier Manager: '(.*)'")]
		public void SelectTheSupplierWithTheFollowingNameInSupplierManager(string selectedResult)
		{
			StudioSupplierManager studioSupplierManagerObject = new StudioSupplierManager();
			Report.IsTrue(studioSupplierManagerObject.ClickResultWithName(selectedResult), "Failed to click result with name: " + selectedResult, "Successfully clicked result with name: " + selectedResult);
			Delay.Seconds(5);
		}


		[StepDefinition(@"Search for the supplier with the following name in Supplier Manager: '(.*)'")]
		public void SearchForTheSupplierWithTheFollowingNameInSupplierManager(string text)
		{
			StudioSupplierManager studioSupplierManagerObject = new StudioSupplierManager();
			Report.IsTrue(studioSupplierManagerObject.SearchTheFollowingText(text), "Failed to search for the following text: " + text, "Successfully searched for the following text: " + text);
			Report.IsTrue(studioSupplierManagerObject.ClickSearchButton(), "Failed to click the search button", "Successfully clicked the search button");
		}


		[StepDefinition(@"I Click 'Suppliers' in SHA Manager")]
		public void IClickSuppliersInSHAManager()
		{
			StudioSupplierManager studioSupplierManagerObject = new StudioSupplierManager();
			Report.IsTrue(studioSupplierManagerObject.ClickSuppliersButton(), "Failed to click 'Suppliers' button", "Successfully clicked 'Suppliers' button");
		}

        [StepDefinition(@"I check that all clients for product saved as: (.*) have data")]
        public void ThenICheckThatAllClientsForProductSavedAsTestCaseHaveData(string savedAs)
        {
            StudioSHAManager studioSHAManagerObject = new StudioSHAManager();

            var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
            string id = ProductDetails?.Id;
            if (id == null)
            {
                throw new Exception("Could not find product saved to context as: " + savedAs);
            }

            var key = id + "'s Clients";
            var clients = Context.GetFromContext(key).ToString();
            string[] arr = clients.Split(new string[] { ", " }, StringSplitOptions.None);
            studioSHAManagerObject.FindDataForClientsInUPCRetailerAndFeedPage(arr);
        }
		
		[StepDefinition(@"In UPC Retailer and Feed I check that the following sections contain the corresponding titles:")]
		public void ThenInUPCRetailerAndFeedICheckThatTheFollowingSectionsContainTheCorrespondingTitles(Table table)
		{
			StudioSHAManager studioSHAManagerObject = new StudioSHAManager();
			Report.IsTrue(studioSHAManagerObject.CheckTheFollowingSectionTitles(table), "Failed to confirm the following section titles", "Successfully confirmed the following section titles");
		}

		[StepDefinition(@"I confirm the Document Purpose Type dropdown shows: (.*)")]
		public void GivenIConfirmTheDocumentPurposeTypeDropdownShowsAIS(string dropDownOption)
		{
			StudioSHAManager studioSHAManagerObject = new StudioSHAManager();
			Report.IsTrue(studioSHAManagerObject.CheckTheDocumentPurposeTypeDropdown(dropDownOption), "The following option was not displayed: " + dropDownOption, "The following option was displayed: " + dropDownOption);
		}

		[StepDefinition(@"I click the first UPC in the UPC Retailer and Feed page")]
		public void GivenIClickTheFirstUPCInTheUPCRetailerAndFeedPage()
		{
			StudioSHAManagerUPCRetailerAndFeedPage studioSHAManagerObject = new StudioSHAManagerUPCRetailerAndFeedPage();
			Report.IsTrue(studioSHAManagerObject.SelectFirstUPCInUPCRetailerAndFeed(), "Failed to select first UPC in UPC Retailer and Feed", "Successfully selected first UPC in UPC Retailer and Feed");
		}

		[StepDefinition(@"In UPC Details popup in UPC Retailer and Feed page I select retailer: (.*)")]
		public void GivenISelctRetailerFromUPCDetailsPopupInUPCRetailerAndFeedPage(string retailer)
		{
			StudioSHAManagerUPCRetailerAndFeedPage studioSHAManagerObject = new StudioSHAManagerUPCRetailerAndFeedPage();
			Report.IsTrue(studioSHAManagerObject.SelectRetailerInUPCDetailsPoupInUPCRetailerAndFeed(retailer), "Failed to select retailer in UPC Details Popup", "Successfully selected retailer in UPC Details Popup");
		}

		[StepDefinition(@"In UPC Details popup in Retailer and UPC Feed page I see the following properties and values")]
		public void GivenInUPCDetailsPopupInRetailerAndUPCFeedPageISeeTheFollowingPropertiesAndValues(Table table)
		{
			StudioSHAManagerUPCRetailerAndFeedPage studioSHAManagerObject = new StudioSHAManagerUPCRetailerAndFeedPage();
			Report.IsTrue(studioSHAManagerObject.InUPCDetailsPoupInUPCRetailerAndFeedISeeTheFollowingPropertiesAndValues(table).Count() == 0, "Failed to find the correct properties and values", "Successfully found the correct properties and values");
		}

		[StepDefinition(@"I close UPC Details popup in Retailer and UPC Feed page")]
		public void GivenICloseUPCDetailsPopupInRetailerAndUPCFeedPage()
		{
			StudioSHAManagerUPCRetailerAndFeedPage studioSHAManagerObject = new StudioSHAManagerUPCRetailerAndFeedPage();
			Report.IsTrue(studioSHAManagerObject.CloseUPCDetailsPoupInUPCRetailerAndFeed(), "Failed to close UPC Details popup", "Successfully closed UPC Details popup");
		}

		[StepDefinition(@"In SHA products grid, I find the first product that contains a UPC and navigate to the UPC Retailers and Feed page.")]
		public void SHAFindFirstUPCProductNavigateToUPCRetailersAndFeed()
		{
			Report.UseSubSteps = true;
			string savedAs = "temp";
			var shaSteps = new Steps_SHA();
			Report.StartSubStep("Getting all product ids from the table");
			var ids = new StudioSHAManager().GetAllProductIds();
			Report.Info("There are " + ids.Count + " product ids");
			for (int i = 0; i < ids.Count; i++)
			{
				Report.StartSubStep("Saving any UPCs for product on row " + (i + 1));
				string id = ids[i];
				Report.IsTrue(new StudioSHAManager().RightClickProductByID(id), "Failed to right click product", "Right clicked product");
				this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
				this.SaveUpcNumberInShaManagerProductUpcListAs(savedAs, false);
				if (Context.GetFromContext(savedAs) != null)
				{
					Report.Success($"Was able to succesfully navigate to the UPC Retailer and Feed Screen for a product containing at least 1 UPC");
					return;

				}

			}
			Report.Failure($"Was unable to navigate to the UPC Retailer and Feed Screen for a product containing at least 1 UPC");
			return;					
						
		}

		

		[StepDefinition(@"In the UPC Retailer and Feed page, confirm that the Packing Type Name saved as: (.*) is displayed")]
		public void ConfirmProductNameDisplayedOnUPCRetailerAndFeedPage(string savedAs)
		{
			var packagingType = new MyPackagingTypes.PackagingTypeItem { Name = Context.GetFromContext("PackagingTypeName_" + savedAs).ToString() };
			StudioSHAManagerUPCRetailerAndFeedPage UPCRetailerAndFeedPage = new StudioSHAManagerUPCRetailerAndFeedPage();
			string displayedProductName = UPCRetailerAndFeedPage.GetProductTypeNameDisplayedInUPCRetailerAndFeedPage();
			Report.IsTrue(packagingType.Name.Equals(displayedProductName), $"Expected Product Name: {packagingType.Name} is not showing. Displayed: {displayedProductName}", $"Expected Product Name: {packagingType.Name} is showing!");
		}

		[StepDefinition(@"In The SHA Products Grid, I open the product search popup, click cancel and confirm the product search popup closes")]
		public void OpenSHAProductsGridClickCancelConfirmCloses()
		{
			var thisProductSearch = new StudioSHAManagerProductSearch();
			var myStudioShaManager = new StudioSHAManager();

			Report.StartStep("I click Search in the bottom menu list");
			myStudioShaManager.ClickBottomMenuOption("Search");
			Report.IsTrue(thisProductSearch.Wait_for_load(60), "Product search page has not loaded","Product search page has loaded as expected", false, false);
			Report.Screenshot();
			Report.Info("Going to click 'Cancel'");
			Delay.Seconds(1);
			Report.IsTrue(thisProductSearch.ClickButton("Cancel"), "Failed to click cancel", "Clicked cancel", false, false);
			Report.Info("Waiting for loading bar");
			new StudioSHAManager().Wait_For_Loading_Finish();
			Report.Screenshot();
			Report.Info("Finished waiting for loading");
			Delay.Seconds(1);
			Report.Screenshot();
			var thisProductSearch2 = new StudioSHAManagerProductSearch();
			Report.IsTrue(!thisProductSearch2.SearchPopupFound(), "The Product Search Popup was found", "The product search popup was closed");
		}


		[StepDefinition(@"In the UPC Assessment Details Screen, I Confirm that I see the Product ID saved as: (.*)")]
		public void InUPCAssessmentScreenConfrimISeeUPCSavedAs(string savedAs)
		{
			Report.Info("Getting saved product: " + savedAs);
			if (!Context.Contains(savedAs))
			{
				Report.Error("Context does not contain: " + savedAs);
			}
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;
			string idfound = new StudioSHAManager().GetUPCScreenWSProductID();
			Report.Info($"id from context = {id}");
			Report.Info($"id found on page = {idfound}");
			Report.IsTrue(id == idfound, "The id found was not equal to the produc ID in context", "The Product ID's matched!");
		}

		[StepDefinition(@"I confirm the Product Data window has opened")]
		public void ConfirmProductDatawindowOpened()
		{
			ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			Report.Info("Looking for SHA Manager Product data window");
			bool foundWindow = false;
			foreach (string handle in allHandles)
			{
				Report.Info("Checking handle: " + handle);
				SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
				if (SeleniumWebDriver.CurrentDriver.FindElement(
						By.XPath(".//span[contains(text(),'Formulation')]"), 2) != null)
				{
					Report.Success("Tab was switched successfully!");
					Report.Screenshot();
					var currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
					Context.AddToContext("SHAManagerProductData", currentHandle);
					foundWindow = true;
					break;
				}
			}
			if (!foundWindow)
			{
				Report.Failure("Failed to find the UPC List window ('SHA Manager Product UPC')");
				Report.Screenshot();
			}
		}

		[StepDefinition(@"I check for the following columns in Formulation")]
		public void ThenICheckForTheFollowingColumnsInFormulation(Table table)
		{
			StudioSHAManager studioSHAManagerObject = new StudioSHAManager();
			Report.IsTrue(studioSHAManagerObject.FindColumnInProductDataPageWithTable(table), "Failed to find all the columns", "Successfully found all the columns");
		}

		[StepDefinition(@"In the Add New Supplier I click on Cancel button")]
		public void ThenInTheAddNewSupplierIClickOnCancelButton()
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();

			if (Report.IsTrue(thisStudioAddNewSupplier.CancelButtonExists(), "Failed to find cancel button", "Succesfully found cancel button"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.InAddNewSupplierClickCancelButton(), "Failed to click cancel button", "Succesfully clicked cancel button");
			}
		}

		[StepDefinition(@"I click on New Supplier Button")]
		public void ThenClickNewSupplierButton()
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();

			if (Report.IsTrue(thisStudioAddNewSupplier.NewSupplierButtonExists(), "Failed to find New Supplier button", "Succesfully found New Supplier button"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.ClickNewSupplierButton(), "Failed to click New Supplier button", "Succesfully clicked New Supplier button");
			}
		}

		[StepDefinition(@"I close Supplier Manager window")]
		public void ThenICloseSupplierManagerWindow()
		{
			var thisStudioAddNewSupplier = new StudioAddNewSupplier();

			if (Report.IsTrue(thisStudioAddNewSupplier.CloseSupplierManagerButtonExists(), "Failed to find Supplier Manager window close button", "Succesfully found Supplier Manager window close button"))
			{
				Report.IsTrue(thisStudioAddNewSupplier.CloseSupplierManagerButton(), "Failed to click on Supplier Manager window button", "Succesfully clicked Supplier Manager window close button");
			}
		}
		[StepDefinition(@"In SHA Manager I confirm product Id color is (.*) for product saved as: (.*)")]
		public void ThenInSHAManagerIConfirmProductIdColorIsBlue(string color, string savedAs)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;
			var myStudioShaManager = new StudioSHAManager();
			Report.Info("Verify product id is blue");
			Report.IsTrue(myStudioShaManager.WaitForIDToTurnBlue(id, 120), "ID has not turned blue", "ID is blue");
		}
		[StepDefinition(@"In SHA Manager I right click on the selected product:(.*) with option:(.*)")]
		public void ThenInSHAManagerIRightClickProductWithSelectedOption(string savedAs, string option)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string id = product.Id;
			var myStudioShaManager = new StudioSHAManager();
			myStudioShaManager.SelectTheProduct();
			Report.IsTrue(myStudioShaManager.RightClickProductByID(id), "Failed to right click product", "Right clicked product");
			this.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption(option);
		}

		[StepDefinition(@"I confirm (.*) column header is displayed")]
		public void ThenInSHAManagerIRightClickProductDocumentRequest(string header)
		{
			var myStudioShaManager = new StudioSHAManager();
			string headerText = myStudioShaManager.DocumentRequestHeader();
			Report.IsTrue(headerText.Equals(header), "Failed to find header", "Succesfully found header");
		}

		[StepDefinition(@"I Confirm that productID: (.*) and name matches with the Product selected in the SHA Manager Product List")]
		public void IConfirmProductID_ProductnameMatchProductListGrid(string productsavedAs)
		{
			var product = (ProductInformation)Context.GetFromContext(productsavedAs);
			string id = product.Id;
			string name = product.Name;
			try
			{
				string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
				Context.AddToContext("MainWindowHandle", currentHandle);
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				Report.Info("Looking for SHA Manager Review window");
				bool foundWindow = false;
				foreach (string handle in allHandles)
				{
					Report.Info($"Checking handle: { handle }");
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					IWebElement ele = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@title='Product Data Review']//b"), 2);
					if (ele != null)
					{
						Report.Success("Tab was switched successfully!");
						Report.Screenshot();
						foundWindow = true;
						Report.IsTrue(ele.Text.Contains(id), "Product id does not match", "product id matched succesfully");
						Report.IsTrue(ele.Text.Contains(name), "Product name does not match", "product name matched succesfully");
						break;
					}
				}

				if (!foundWindow)
				{
					Report.Failure("Failed to find the review grid List window");
					Report.Screenshot();
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				Report.Screenshot();
			}
		}
		[StepDefinition(@"In the Review Screen I check Ascending or Decending order in the Fomulation section")]
		public void ThenICheckAscDecInFormulationSection()
		{
			int i = 0;
			var myStudioShaManager = new StudioSHAManager();
			List<string> columns = new List<string> {
				"listProductFormulation_CAS",
				"listProductFormulation_ChemicalName",
				"listProductFormulation_PercentHigh",
				"listProductFormulation_PercentRange",
				"listProductFormulation_PubliclyAvailable",
				"listProductFormulation_PublicName"
			};
			Report.Info("Get each column and verify asc, dec");
			List<IWebElement> expectedValues = myStudioShaManager.GetFormulationCloumns();
			
				foreach (var column in expectedValues)
				{
					column.TryClick();
					myStudioShaManager.AscDecCheck(columns[i++], "asc");
			}			
		}
	}

	}



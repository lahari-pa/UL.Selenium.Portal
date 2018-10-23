using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NPOI.OpenXmlFormats.Vml.Office;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Studio")]
	class Steps_Studio
	{
		[StepDefinition(@"I click on publish this Document to open current document popup")]
		public void IClickOnPublishThisDocumentToOpenCurrentDocumentPopup()
		{
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("publish"),
				"Failed to click publish tool bar option", "Clicked publish tool bar option");

			CurrentDocument thisCurrentDocument = new CurrentDocument();
			Report.IsTrue(thisCurrentDocument.Wait_for_load(60), "Current document failed to load",
				"Current document loaded");

			Delay.Seconds(3);
		}

		[StepDefinition(@"in Power Designer Plus page I click on tab: (.*)")]
		public void GivenInPowerDesignerPlusPageIClickOnTab(string tab)
		{
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickTabOption(tab), "Failed to click tab: " + tab,
				"Clicked tab: " + tab);
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on edit button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton()
		{
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickEditButton(), "Failed to click edit button",
				"Clicked edit button");
			PDEditPage thisPdEditPage = new PDEditPage();
			Report.IsTrue(thisPdEditPage.Wait_for_load(60), "Edit page has failed to load", "Edit page has loaded");
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on apply rules button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton()
		{
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickApplyRulesButton(),
				"Failed to click apply rules button",
				"Clicked apply rules button");
			ApplyRulesPage thisApplyRulesPage = new ApplyRulesPage();
			Report.IsTrue(thisApplyRulesPage.Wait_for_load(60), "Apply rules page has failed to load",
				"Apply rules page has loaded");
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on document queue button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton()
		{
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("document queue"),
				"Failed to click document queue button",
				"Clicked document queue button");
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.Wait_for_load(60), "Document queue page has failed to load",
				"Document queue page has loaded");
		}

		[StepDefinition(@"In Current Document Popup select checkbox: (.*)")]
		public void InCurrentDocumentPageSelectCheckbox(string checkbox)
		{
			Report.Info("Selecting checkbox: " + checkbox);
			CurrentDocument thisCurrentDocument = new CurrentDocument();
			Report.IsTrue(thisCurrentDocument.Wait_for_load(60), "Current document failed to load", "Current document loaded");
			Report.IsTrue(thisCurrentDocument.SetCheckBox(checkbox, true), "Failed to set checkbox: " + checkbox, "Set checkbox: " + checkbox);
			Report.Screenshot();
		}

		[StepDefinition(@"I close Current Document")]
		public void GivenICloseCurrentDocument()
		{
			CurrentDocument thisCurrentDocument = new CurrentDocument();
			thisCurrentDocument.Close();
		}

		//| Text | Should Show |
		[StepDefinition(@"In Current Document I confirm that alert text matches")]
		public void GivenInCurrentDocumentIConfirmThatAlertTextMatches(Table table)
		{
			Report.Info("Beginning confirm that alert matches what is expected.");
			Delay.Seconds(2);
			CurrentDocument thisCurrentDocument = new CurrentDocument();
			Report.Info("Get alert text");
			string alertText =
				thisCurrentDocument.GetAlertText(
					"The following subformat(s) cannot be authorized because required data is missing.");

			Report.Info("Alert is showing as: " + alertText);
			string regExPattern = @"\s[ABCDEFGHIJKLMNOPQRSTUVWZYZ1234567890]{3,7}[\,\\r]?";
			MatchCollection mc = Regex.Matches(alertText, regExPattern);
			List<string> codes = new List<string>();

			foreach (Match match in mc)
			{
				foreach (Capture capture in match.Captures)
				{
					codes.Add(capture.Value.Replace(",", "").Trim());
				}
			}

			foreach (TableRow thisRow in table.Rows)
			{
				if (thisRow["Should Show"] == "true")
				{
					Report.IsTrue(codes.Contains(thisRow["Text"]), "Alert text should contain: " + thisRow["Text"],
						"Alert text contains " + thisRow["Text"]);
				}
				else
				{
					Report.IsTrue(!codes.Contains(thisRow["Text"]), "Alert text should not contain: " + thisRow["Text"],
						"Alert text does not contain " + thisRow["Text"]);
				}
			}

			try
			{
				SeleniumBrowser.Alert.WaitForAlert(3);
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}
			catch
			{
				Report.Info("No alert found");
			}
		}


		[StepDefinition(@"I set the Datacodes as follows:")]
		public void GivenISetTheDatacodesAsFollows(Table table)
		{
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
					new StudioPowerDesignerPlusDesignMode();
				thisStudioPowerDesignerPlusDesignMode.DoubleClickDataCode(thisRow["datacode"]);
				Delay.Seconds(1);
				GraphicEditor thisGraphicEditor = new GraphicEditor();
				Report.IsTrue(thisGraphicEditor.Wait_for_load(60), "Graphic editor has not loaded",
					"Graphic editor has loaded.");
				string valueToSearchFor = "";

				Report.Info("Attempting to set value: " + thisRow["value"] + " for graphic: " + thisRow["datacode"]);
				switch (thisRow["value"].ToLower())
				{
					case "pass":
						valueToSearchFor = "DPQA_PASS";
						break;
					case "fail":
						valueToSearchFor = "DPQA_FAIL";
						break;
					case "warn":
						valueToSearchFor = "DPQA_PASS_WARN";
						break;
					case "na":
						valueToSearchFor = "DPQA_NA";
						break;
					case "unknown":
						valueToSearchFor = "DPQA_UNK";
						break;
					default:
						throw new Exception("you must provide a valid value");
						break;
				}

				Report.IsTrue(thisGraphicEditor.SelectGraphic(valueToSearchFor),
					"Failed to select graphic: " + valueToSearchFor, "Set graphic: " + valueToSearchFor);
				Report.IsTrue(thisGraphicEditor.ClickButton("save"), "Failed to click save button",
					"Clicked save button");
				Delay.Seconds(1);
				thisGraphicEditor.Wait_for_close();
				Delay.Seconds(1);
			}
		}

		[StepDefinition(@"in the Edit Toolbar page I check the following items:")]
		public void GivenInTheEditToolbarPageICheckTheFollowingItems(Table table)
		{
			PDEditPage thisPDiEditPage = new PDEditPage();
			Report.IsTrue(thisPDiEditPage.Wait_for_load(30), "Edit tool bar page is not open",
				"Edit toolbar page is open");
			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(thisPDiEditPage.SetCheckBox(thisRow["Item"], true),
					"Failed to set checkbox for: " + thisRow["Item"], "Set checkbox for: " + thisRow["Item"]);
			}
		}

		[StepDefinition(@"in the Edit Toolbar page I click: (.*)")]
		public void GivenInTheEditToolbarPageIClick(string button)
		{
			PDEditPage thisPDiEditPage = new PDEditPage();
			if (button.ToLower() == "save")
			{
				Report.IsTrue(thisPDiEditPage.ClickSave(), "Failed to click save",
					"Clicked save");
			}
			else
			{
				Report.IsTrue(thisPDiEditPage.ClickCancel(), "Failed to click cancel",
					"Clicked cancel");
			}
		}

		[StepDefinition(@"In Apply Rules Page I click on the following apply radio button: (.*)")]
		public void InApplyRulesPageIClickOnTheFollowingApplyRadioButton(string button)
		{
			ApplyRulesPage thisApplyRulesPage = new ApplyRulesPage();
			Report.IsTrue(thisApplyRulesPage.SetApplyOption(button), "Failed to click " + button + " button",
				"Clicked " + button);
		}

		[StepDefinition(@"In Apply Rules Page I click on the single rule ellipsis button")]
		public void InApplyRulesPageIClickOnTheSingleRulesEllipsisButton()
		{
			ApplyRulesPage thisApplyRulesPage = new ApplyRulesPage();
			Report.IsTrue(thisApplyRulesPage.ClickSingleRuleEllipsis(), "Failed to click single rules ellipsis",
				"Clicked single rules ellipsis");
			Delay.Seconds(3);
			SelectRulesPage thisSelectRulesPage = new SelectRulesPage();
			Report.IsTrue(thisSelectRulesPage.Wait_for_load(120), "Select rules page has not loaded",
				"Select rules page has loaded");
		}

		[StepDefinition(@"In Select Rules Popup Page I click on the filter icon")]
		public void InSelectRulesPageIClickOnFilterIcon()
		{
			SelectRulesPage thisSelectRulesPage = new SelectRulesPage();
			Report.IsTrue(thisSelectRulesPage.ClickFilterButton(), "Failed to click filter button",
				"Clicked filter button");
			SelectRulesFilter thisSelectRulesFilter = new SelectRulesFilter();
			Report.IsTrue(thisSelectRulesFilter.Wait_for_load(), "Select rules popup has not loaded",
				"Select rules popup has loaded");
		}

		[StepDefinition(@"In Select Rules Filter Popup Page I enter the following: (.*) in textbox: (.*)")]
		public void InSelectRulesFilterPopupIEnterValueInTextBox(string value, string textbox)
		{
			SelectRulesFilter thisSelectRulesFilter = new SelectRulesFilter();
			Report.IsTrue(thisSelectRulesFilter.EnterInTextBox(textbox, value),
				"Failed to enter value: " + value + " in textbox: " + textbox,
				"Succeeded in entering value: " + value + " in textbox: " + textbox);
		}

		[StepDefinition(@"In Select Rules Filter Popup Page I select the following: (.*) from selectbox: (.*)")]
		public void InSelectRulesFilterPopupISelectFromSelectBox(string value, string selectbox)
		{
			SelectRulesFilter thisSelectRulesFilter = new SelectRulesFilter();
			Report.IsTrue(thisSelectRulesFilter.SelectFromSelectBox(selectbox, value),
				"Failed to enter value: " + value + " in selectbox: " + selectbox,
				"Succeeded in entering value: " + value + " in selectbox: " + selectbox);
		}

		[StepDefinition(@"In Select Rules Filter Popup Page I click button: (.*)")]
		public void InSelectRulesFilterPopupIClickButton(string button)
		{
			SelectRulesFilter thisSelectRulesFilter = new SelectRulesFilter();

			switch (button.ToLower())
			{
				case "apply":
					Report.IsTrue(thisSelectRulesFilter.ClickApply(), "Failed to click apply button",
						"Clicked apply button");
					break;
				case "cancel":
					Report.IsTrue(thisSelectRulesFilter.ClickCancel(), "Failed to click cancel button",
						"Clicked cancel button");
					break;
				case "clear":
					Report.IsTrue(thisSelectRulesFilter.ClickClear(), "Failed to click clear button",
						"Clicked clear button");
					break;
				default:
					Report.Error("Failed to provide valid button name to click - must be apply, cancel or clear");
					break;
			}

		}

		[StepDefinition(@"In Select Rules Popup Page I click first record to select")]
		public void InSelectRulesPageIClickOnFirstRecord()
		{
			SelectRulesPage thisSelectRulesPage = new SelectRulesPage();
			thisSelectRulesPage.Wait_for_load(30);
			Report.IsTrue(thisSelectRulesPage.SelectTopRule(), "Failed to select first rule", "Selected first rule");
			Delay.Seconds(3);
			try
			{
				Report.IsTrue(!thisSelectRulesPage.Wait_for_close(30), "Select rules popup has not closed",
					"Select rules popup has closed");
			}
			catch (Exception e)
			{
				//do nothing
			}

		}

		[StepDefinition(@"In Apply Rules Page I click on the button: (.*)")]
		public void InApplyRulesPageIClickOnButton(string button)
		{
			ApplyRulesPage thisApplyRulesPage = new ApplyRulesPage();
			thisApplyRulesPage.Wait_for_load(60);
			Delay.Seconds(1);
			Report.IsTrue(thisApplyRulesPage.ClickButton(button), "Failed to click " + button, "Clicked " + button);
			if (button.ToLower() == "apply")
			{
				Delay.Seconds(10);
				thisApplyRulesPage.WaitForSpinner();
				try
				{
					SeleniumBrowser.Alert.WaitForAlert(3);
					SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				}
				catch (Exception e)
				{
					//alert did not appear
				}

			}
		}

		[StepDefinition(@"I click on document queue to open document queue popup")]
		public void IClickOnPublishThisDocumentToOpenDocumentQueuePopup()
		{
			StudioPowerDesignerPlusDesignMode thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			//Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("document queue"),
			//	"Failed to click document queue tool bar option", "Clicked document queue tool bar option");

			if (!thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("document queue"))
			{
				Report.Info("There may have been a problem clicking the document queue tool bar option...");
			}

			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.Wait_for_load(60), "Document Queue page failed to load",
				"Document queue page loaded");
		}

		[StepDefinition(@"In document queue popup I click on filter icon")]
		public void InDocumentQueuePopupIClickOnFilterIcon()
		{
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.Wait_for_load(60), "Document Queue page failed to load",
				"Document queue page loaded");
			Report.IsTrue(thisDocumentQueuePage.ClickFilterButton(), "Failed to click filter button",
				"Clicked filter button");
			SelectDocumentQueueFilter thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.Wait_for_load(60), "Document Queue filter page failed to load",
				"Document queue filter page loaded");

		}

		[StepDefinition(@"In document queue filter page I enter value: (.*) in select box: (.*)")]
		public void InDocumentQueueFilterPageIEnterValueInSelectBox(string value, string selectBox)
		{
			SelectDocumentQueueFilter thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.Wait_for_load(60), "Document Queue filter page failed to load",
				"Document queue filter page loaded");
			Report.IsTrue(thisSelectDocumentQueueFilter.SelectFromSelectBox(selectBox, value),
				"Failed to select " + value + " in select box: " + selectBox,
				"Selected " + value + " in select box: " + selectBox);

		}

		[StepDefinition(@"In document queue filter page I enter value: (.*) in entry box: (.*)")]
		public void InDocumentQueueFilterPageIEnterValueInEntryBox(string value, string entryBox)
		{
			if (value.ToLower().Contains("saved as"))
			{
				var productDetails = (ProductInformation)Context.GetFromContext(value.Replace("saved as","",StringComparison.OrdinalIgnoreCase).Trim());
				value = productDetails.Id;
			}
			SelectDocumentQueueFilter thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.Wait_for_load(60), "Document Queue filter page failed to load",
				"Document queue filter page loaded");
			Report.IsTrue(thisSelectDocumentQueueFilter.EnterInTextBox(entryBox, value),
				"Failed to entry " + value + " in entry box: " + entryBox,
				"Entered " + value + " in entry box: " + entryBox);

		}

		[StepDefinition(@"In document queue filter page I click on apply")]
		public void InDocumentQueueFilterPageIClickOnApply()
		{
			SelectDocumentQueueFilter thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.ClickApply(), "Failed to click on apply",
				"Click on apply");
		}

		[StepDefinition(@"In document queue filter page I click on select all checkbox")]
		public void InDocumentQueueFilterPageIClickOnSelectAllCheckbox()
		{
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			thisDocumentQueuePage.Wait_for_load();
			Report.IsTrue(thisDocumentQueuePage.CheckSelectAllCheckbox(), "Failed to click select all checkbox",
				"Clicked select all checkbox");
		}

		[StepDefinition(@"In document queue filter page I click on process documents")]
		public void InDocumentQueueFilterPageIClickOnProcessDocuments()
		{
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			thisDocumentQueuePage.Wait_for_load();
			Report.IsTrue(thisDocumentQueuePage.ClickProcessDocuments(), "Failed to click process documents",
				"Clicked process documents");
		}

		[StepDefinition(@"In document queue filter page I click on clone selected row")]
		public void InDocumentQueueFilterPageIClickOnCloneSelectedRow()
		{
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.ClickCloneSelectedRow(), "Failed to click clone selected row",
				"Clicked clone selected row");
		}

		[StepDefinition(@"In document queue filter page I click on delete selected")]
		public void InDocumentQueueFilterPageIClickOnDeleteSelected()
		{
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.ClickDeleteSelected(), "Failed to click delete selected",
				"Clicked delete selected");
		}

		[StepDefinition(@"In document queue filter page I click on close")]
		public void InDocumentQueueFilterPageIClickOnClose()
		{
			DocumentQueuePage thisDocumentQueuePage = new DocumentQueuePage();
			thisDocumentQueuePage.ClickClose();


		}

		[StepDefinition(@"I navigate to power designer plus")]
		public void NavigateToPowerDesignerPlus()
		{
			StudioTopMenu thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing");
			thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus");
			StudioPowerDesignerPlus thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			thisPowerDesignerPlus.ClickContinueButton();
		}

		[StepDefinition(@"I should see an alert with the following message: (.*)")]
		public void IShouldSeeAnAlertAsFollows(string expectedAlertText)
		{
			CurrentDocument thisCurrentDocument = new CurrentDocument();
			string alertText =
				thisCurrentDocument.GetAlertText("");

			Report.IsTrue(alertText.Contains(expectedAlertText),
				"Alert text is not as expected. Expected: " + expectedAlertText + " but got: " + alertText,
				"Alert text is showing as expected: " + expectedAlertText);

		}

		[StepDefinition(@"I close alert")]
		public void ICloseAlert()
		{
			try
			{
				SeleniumBrowser.Alert.WaitForAlert(3);
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			}
			catch (Exception e)
			{
				Report.Info("Alert is not showing");
			}

		}

		[StepDefinition(@"I check the following items are showing in the Document Queue table")]
		public void GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(Table table)
		{
			List<string> tableHeaders = table.Header.ToList();

			DocumentQueuePage newDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
				"Document queue page loaded");
			List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
			Report.Info(listOfDocuments.Count.ToString() + " documents found");

			List<string> propertiesInDocument = new Document().GetType().GetProperties().Select(x => x.Name).ToList();

			List<string> notFoundInDocument = tableHeaders.Except(propertiesInDocument).ToList();

			if (notFoundInDocument.Count() > 0)
			{
				throw new Exception("Not all items listed are in the document object model: " + string.Join(",", notFoundInDocument));
			}
			Report.Info("All items listed are in the document object model");

			//Checking all rows in the table
			foreach (TableRow thisRow in table.Rows)
			{
				List<string> actualHeaders = new List<string>();
				listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				//for each column in the table
				foreach (string header in tableHeaders)
				{
					string value = thisRow[header];
					Report.Info("Looking at item: " + value + " for header: " + header);

					if (value.ToLower().Contains("saved as"))
					{
						if (Context.GetFromContext(value.Replace("saved as", "", StringComparison.OrdinalIgnoreCase)
							.Trim()).GetType().ToString().ToLower().Contains("string"))
						{
							value = Context.GetFromContext(value
								.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim()).ToString();
						}
						else
						{
							var productDetails = (ProductInformation)Context.GetFromContext(value.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
						value = productDetails.Id;
						}

					}

					//get this header as it appears in the document object
					string thisPropertyName = propertiesInDocument.FirstOrDefault(x =>
						x.ToLower().Replace(" ", string.Empty) == header.ToLower().Replace(" ", string.Empty));

					//filter the list of documents so that only the ones that match all remain
					try
					{
						Report.Info("List of documents count before: " + listOfDocuments.Count);
						listOfDocuments = listOfDocuments.Where(x =>
							x.GetType().GetProperty(thisPropertyName).GetValue(x, null).ToString() == value).ToList();
						Report.Info("List of documents count after: " + listOfDocuments.Count);
					}
					catch (Exception e)
					{
						Report.Error("Some problem with " + thisPropertyName + ": " + e.Message);
					}

				}

				if (listOfDocuments.Count == 0)
				{

					Report.Error("Not all documents match. This combination was not found: " + string.Join(",", thisRow.Values.ToList()));
				}
				else
				{
					Report.Success("All documents match.");
				}
			}
		}


		[StepDefinition(@"In SHA Manager I select product by id: (.*)")]
		public void InSHAManagerISelectProductById(string idToSelect)
		{
			try
			{
				if (idToSelect.ToLower().Contains("saved as"))
				{
					var productDetails = (ProductInformation)Context.GetFromContext(idToSelect.Replace("saved as", "").Trim());
					idToSelect = productDetails.Id;
				}

				StudioSHAManager thisStudioShaManager = new StudioSHAManager();
				Report.IsTrue(thisStudioShaManager.SelectProductByID(idToSelect),
					"Failed to select item by id: " + idToSelect, "Selected item with id: " + idToSelect);
			}
			catch (Exception e)
			{
				Report.Info("Alert is not showing");
			}
		}

		[StepDefinition(@"In SHA Manager I click on bottom menu item: (.*)")]
		public void InSHAManagerIClickOnBottomMenuItem(string menuItem)
		{
			try
			{
				StudioSHAManager thisStudioShaManager = new StudioSHAManager();
				Report.IsTrue(thisStudioShaManager.ClickBottomMenuOption(menuItem), "Failed to click: " + menuItem,
					"Clicked menu item: " + menuItem);
			}
			catch (Exception e)
			{
				Report.Info("Alert is not showing");
			}
		}

		[Given(@"In the Process Products popup in SHAManager I select the following retailers")]
		public void GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(Table table)
		{
			ProcessProducts thisProcessProducts = new ProcessProducts();
			Report.IsTrue(thisProcessProducts.Wait_for_load(30), "Process products screen is not showing",
				"Process products screen is showing");
			foreach (TableRow thisRetailer in table.Rows)
			{
				Report.IsTrue(thisProcessProducts.SelectRetailer(thisRetailer["Retailer"]),
					"Failed to select retailer: " + thisRetailer["Retailer"],
					"Selected retailer: " + thisRetailer["Retailer"]);
			}
		}

		[Given(@"In the Process Products popup in SHAManager I set the new status drop down list to be: (.*)")]
		public void GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo(string status)
		{
			ProcessProducts thisProcessProducts = new ProcessProducts();
			Report.IsTrue(thisProcessProducts.Wait_for_load(30), "Process products screen is not showing",
				"Process products screen is showing");
			Report.IsTrue(thisProcessProducts.SelectNewStatus(status), "Failed to select new status: " + status,
				"Selected new status: " + status);
		}

		[Given(@"In the Process Products popup in SHAManager I click on update status button")]
		public void GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton()
		{
			ProcessProducts thisProcessProducts = new ProcessProducts();
			Report.IsTrue(thisProcessProducts.Wait_for_load(30), "Process products screen is not showing",
				"Process products screen is showing");
			Report.IsTrue(thisProcessProducts.ClickUpdateStatus(), "Failed to click update status",
				"Clicked update status");
		}


		[Given(@"In the Product Formulation page I click button: (.*)")]
		public void InTheProductForulationPageIClickButton(string button)
		{
			ProductFormulationPage thisFormulationPage = new ProductFormulationPage();
			Report.IsTrue(thisFormulationPage.Wait_for_load(30), "Product formulation screen is not showing",
				"Product formulation screen is showing");
			Report.IsTrue(thisFormulationPage.ClickButton(button), "Failed to click button: " + button,
				"Clicked button: " + button);
		}

		[Given(@"In the Create component page I add component")]
		public void InTheCreateComponentPageIAddComponent(TechTalk.SpecFlow.Table component)
		{
			CreateComponentPage thisCreateComponentPage = new CreateComponentPage();
			Report.IsTrue(thisCreateComponentPage.Wait_for_load(30), "Create component screen is not showing",
				"Create component screen is showing");
			Report.IsTrue(thisCreateComponentPage.WaitForCAS(30), "CAS entry is not showing",
				"CAS entry is showing");

			if (component.ContainsColumn("Component CAS"))
			{
				if (component.Rows[0]["Component CAS"].Length > 0)
				{
					string CASNo = component.Rows[0]["Component CAS"];
					if (CASNo.ToLower().Contains("saved as"))
					{
						var savedAsItem = Context.GetFromContext(CASNo.Replace("saved as", "").Trim());
						if (savedAsItem.GetType() == typeof(string))
						{
							CASNo = savedAsItem.ToString();
						}
						else
						{
							CASNo = "WPS" + ((ProductInformation)savedAsItem).Id;
						}
					}
					Report.IsTrue(thisCreateComponentPage.EnterCAS(CASNo),
						"Failed to enter CAS number", "Entered CAS number");
				}
			}
			if (component.ContainsColumn("Component ID"))
			{
				if (component.Rows[0]["Component ID"].Length > 0)
				{
					Report.IsTrue(thisCreateComponentPage.EnterComponentID(component.Rows[0]["Component ID"]),
						"Failed to enter Component ID", "Entered Component ID");
				}
			}
			if (component.ContainsColumn("Chemical Name"))
			{
				if (component.Rows[0]["Chemical Name"].Length > 0)
				{
					string chemName = component.Rows[0]["Chemical Name"];
					if (chemName.ToLower().Contains("saved as"))
					{
						var savedAsItem = Context.GetFromContext(chemName.Replace("saved as", "").Trim());
						if (savedAsItem.GetType() == typeof(string))
						{
							chemName = savedAsItem.ToString();
						}
						else
						{
							chemName = ((ProductInformation)savedAsItem).Name;
						}
					}
					Report.IsTrue(thisCreateComponentPage.EnterChemicalName(chemName),
						"Failed to enter Chemical Name", "Entered Chemical Name");
				}
			}

			if (component.ContainsColumn("Trade secret name"))
			{
				if (component.Rows[0]["Trade secret name"].Length > 0)
				{
					Report.IsTrue(thisCreateComponentPage.EnterTradeSecretName(component.Rows[0]["Trade secret name"]),
						"Failed to enter Trade secret name", "Entered Trade secret name");
				}
			}

			if (component.ContainsColumn("Add to Formulation Now"))
			{
				if (component.Rows[0]["Add to Formulation Now"].Length > 0)
				{
					Report.IsTrue(thisCreateComponentPage.AddToFormulationNowCheckboxChecked(component.Rows[0]["Add to Formulation Now"].ToLower()=="true"),
						"Failed to enter Add to Formulation Now", "Entered Add to Formulation Now");
				}
			}

			if (component.ContainsColumn("Load Regulation Data now"))
			{
				if (component.Rows[0]["Load Regulation Data now"].Length > 0)
				{
					Report.IsTrue(thisCreateComponentPage.AddToFormulationNowCheckboxChecked(component.Rows[0]["Load Regulation Data now"].ToLower() == "true"),
						"Failed to enter Load Regulation Data now", "Entered Load Regulation Data now");
				}
			}

			if (component.ContainsColumn("Load chemical name translations"))
			{
				if (component.Rows[0]["Load chemical name translations"].Length > 0)
				{
					Report.IsTrue(thisCreateComponentPage.AddToFormulationNowCheckboxChecked(component.Rows[0]["Load chemical name translations"].ToLower() == "true"),
						"Failed to enter Load chemical name translations", "Entered Load chemical name translations");
				}
			}
			Report.Info("Beginning click save in create component page.");
			thisCreateComponentPage.ClickButton("Save");

			//string currentURL = SeleniumBrowser.WebBrowser.Url;

			Delay.Seconds(1);
			//((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("ConfirmBadCAS(null)");
			/*
			Report.Info("Checking for alert - reloading");

			try
			{
				if (SeleniumBrowser.Alert.ReloadAlert("CAS does not comply"))
				{
					Report.Info("Reloaded");
				}
				else
				{
					Report.Info("Failed to reload");
				}
			}
			catch (Exception e)
			{
				Report.Info("Error on reloading alert: " + e.Message);
			}
			*/
			Report.Info("Checking for the existence of an alert.");
			if (SeleniumBrowser.Alert.WaitForAlert(2))
			{
				Report.Info("Found an alert");
				string alertText = SeleniumBrowser.Alert.GetText();
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				Report.Info("Got an alert: " + alertText);
			}
			else
			{
				Report.Info("Did not find an alert");
			}
			Delay.Seconds(1);

		}

		[Given(@"I close the Product Formulation page")]
		public void GivenICloseTheProductFormulationPage()
		{
			ProductFormulationPage thisFormulationPage = new ProductFormulationPage();
			Report.IsTrue(thisFormulationPage.Wait_for_load(30), "Product formulation screen is not showing",
				"Product formulation screen is showing");
			thisFormulationPage.ClickClose();
		}

		[StepDefinition(@"In the Power Designer Plus Welcome page I enter Select Source Product: (.*)")]
		public void PowerDesignerPlusWelcomeIEnterSelectSourceProduct(string productID)
		{
			StudioPowerDesignerPlus thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.EnterSourceProduct(productID), $"Failed to enter {productID} into the Select Source Product field!", $"Successfully entered {productID} into the Select Source Product field");
			Report.Info("Clicking Refresh");
			thisPowerDesignerPlus.ClickRefreshButton();
		}

		[StepDefinition(@"I confirm the selected Subformat in the Power Designer Plus popup is: (.*)")]
		public void IConfirmTheSelectedSubformatInThePdPlusPopupIs(string subFormat)
		{
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlus();
			var selectedSubFormat = selStudioPowerDesignerPlus.SelectedSubFormat();
			if (selectedSubFormat != null)
			{
				Report.IsTrue(selStudioPowerDesignerPlus.SelectedSubFormat() == subFormat,
					"The selected subformat was not " + subFormat + " as expected! The selected subformat was: " + selectedSubFormat,
					"The selected subformat was " + subFormat + " as expected");
			}
			else
			{
				Report.Failure("No selected subformats were found");
				Report.Screenshot();
			}
		}

		[StepDefinition(@"I click continue in the Power Designer Plus popup")]
		public void ClickContinueInThePowerDesignerPlusPopup()
		{
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(selStudioPowerDesignerPlus.ClickContinueButton(),
				"Failed to click Continue in the Power Designer Plus popup",
				"Successfully clicked Continue in the Power Designer Plus popup");
		}

		[StepDefinition(@"In Power Designer I (left|right|double) click on section: (.*)")]
		public void GivenInPowerDesignerIClickOnSection(string click, string section)
		{
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(selStudioPowerDesignerPlus.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			Report.IsTrue(selStudioPowerDesignerPlus.ClickLeftMenuSection(section, click),
				"Failed to " + click + " click section: " + section,
				"Successfully " + click + " clicked " + section);
			Delay.Seconds(3);

		}

		[StepDefinition(@"In Power Designer I double click on category: (.*)")]
		public void GivenInPowerDesignerIDoubleClickOnCategory(string category)
		{
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(selStudioPowerDesignerPlus.DoubleClickCategoryToEdit(category),
				"Failed to double click category: " + category,
				"Successfully clicked " + category);
		}

		[StepDefinition(@"In Power Designer the phrase selector screen should open")]
		public void ThenInPowerDesignerThePhraseSelectorScreenShouldOpen()
		{
			PhraseEditor thisPhraseEditor = new PhraseEditor();
			Report.IsTrue(thisPhraseEditor.Wait_for_load(60), "Phrase editor has not opened.",
				"Phrase editor has opened");
		}

		[StepDefinition(@"In the phrase selector screen I select phrases:")]
		public void ThenInThePhraseSelectorScreenISelectPhrases(Table table)
		{
			bool addedSuccessfully = true;
			PhraseEditor thisPhraseEditor = new PhraseEditor();
			if (!thisPhraseEditor.Wait_for_load(60))
			{
				throw new Exception("Phrase editor is not loaded");
			}

			List<Phrase> SelectedPhrases = thisPhraseEditor.GetSelectedPhrases();
			List<Phrase> FilteredPhrases = SelectedPhrases;
			foreach (TableRow thisPhrase in table.Rows)
			{
				if (table.ContainsColumn("Code"))
				{
					FilteredPhrases = FilteredPhrases.Where(x => x.Code == thisPhrase["Code"]).ToList();
				}
				if (table.ContainsColumn("Text"))
				{
					FilteredPhrases = FilteredPhrases.Where(x => x.Text == thisPhrase["Text"]).ToList();
				}
				if (table.ContainsColumn("Type"))
				{
					FilteredPhrases = FilteredPhrases.Where(x => x.Text == thisPhrase["Type"]).ToList();
				}
				if (table.ContainsColumn("Notes"))
				{
					FilteredPhrases = FilteredPhrases.Where(x => x.Text == thisPhrase["Notes"]).ToList();
				}
				if (FilteredPhrases.Count == 1)
				{
					Report.Info("Phrase is already added: " + FilteredPhrases.FirstOrDefault().Code);
				}
				else
				{

					if (FilteredPhrases.Count > 1)
					{
						Report.Error("Multiple matching phrases are already added");
					}
					else
					{
						if (table.ContainsColumn("Text"))
						{
							thisPhraseEditor.filterSelectPhrases(thisPhrase["Text"]);
							if (!thisPhraseEditor.SelectItem("Text", thisPhrase["Text"]))
							{
								Report.Info("Failed to add phrase: " + thisPhrase["Text"]);
								addedSuccessfully = false;
							}
							else
							{
								Report.Success("Added phase: " + thisPhrase["Text"]);
							}
						}
						else
						{
							if (table.ContainsColumn("Code"))
							{
								if (!thisPhraseEditor.SelectItem("Code", FilteredPhrases.FirstOrDefault().Code))
								{
									Report.Info("Failed to add phrase: " + FilteredPhrases.FirstOrDefault().Code);
									addedSuccessfully = false;
								}
								else
								{
									Report.Success("Added phase: " + FilteredPhrases.FirstOrDefault().Code);
								}
							}
						}
					}
				}

				Delay.Seconds(1);
			}

			Report.IsTrue(addedSuccessfully, "Failed to add all phrases successfully", "Added phrases successfully");
		}

		//save, clear, cancel, previous, next
		[StepDefinition(@"In the phrase selector screen I click button: (.*)")]
		public void ThenInThePhraseSelectorScreenIClickButton(string button)
		{
			PhraseEditor thisPhraseEditor = new PhraseEditor();
			if (!thisPhraseEditor.Wait_for_load(60))
			{
				throw new Exception("Phrase editor is not loaded");
			}

			Report.IsTrue(thisPhraseEditor.ClickButton(button), "Failed to click button: " + button,
				"Clicked button: " + button);
		}

		[Given(@"I click on home to navigate back to editing specific product saved as (.*)")]
		public void GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(string savedAs)
		{
			StudioPowerDesignerPlusDesignMode thispd = new StudioPowerDesignerPlusDesignMode();
			thispd.Wait_for_load(5);
			thispd.ClickMenuAndSubmenuOptions("Home");
			Delay.Seconds(3);
			StudioPowerDesignerPlus thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");

			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage("ENGLISH (USA)"), "Failed to set language option",
				"Set language option");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter("CKLT"), "Failed to set subformat option",
				"Set subformat option");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat("CKLT", "MTR"), "Failed to set format option",
				"Set format option");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption("edit"), "Failed to set action option",
				"Set action option");
			Report.Screenshot();
			Delay.Seconds(1);
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(1);
			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button",
				"Clicked continue button");
		}

		[Given(@"I check whether the current environment is Staging or Production and if it is I skip the next three steps")]
		public void GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps()
		{
			if (GlobalParameters.SiteType == "Staging" || GlobalParameters.SiteType == "Local Production" ||
			    GlobalParameters.SiteType == "Production")
			{
				Report.Info("Setting context of electronic product");
				Context.AddToContext("ElectronicProduct","true");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Automation.Selenium.Extensions;
using UL.Automation.TReVor.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Studio")]
	class Steps_Studio
	{
		[StepDefinition(@"I click on publish this Document to open current document popup")]
		public void IClickOnPublishThisDocumentToOpenCurrentDocumentPopup()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			Delay.Seconds(5);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("publish"),
				"Failed to click publish tool bar option", "Clicked publish tool bar option");

			var thisCurrentDocument = new CurrentDocument();
			Delay.Seconds(3);
			Report.IsTrue(thisCurrentDocument.Wait_for_load(60), "Current document failed to load",
				"Current document loaded");
			Delay.Seconds(3);
		}

		[StepDefinition(@"in Power Designer Plus page I click on tab: (.*)")]
		public void GivenInPowerDesignerPlusPageIClickOnTab(string tab)
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickTabOption(tab), "Failed to click tab: " + tab,
				"Clicked tab: " + tab);
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on edit button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnEditButton()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickEditButton(), "Failed to click edit button",
				"Clicked edit button");
			Delay.Seconds(3);
			var thisPdEditPage = new PDEditPage();
			Report.Info("Wait for PD Edit page to load");
			Report.IsTrue(thisPdEditPage.Wait_for_load(120), "Edit page has failed to load", "Edit page has loaded");
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on apply rules button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnApplyRulesButton()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			GeneralUtilities.StudioWaitForSpinner(30);
			Delay.Seconds(5);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickApplyRulesButton(),
				"Failed to click apply rules button",
				"Clicked apply rules button");
			var thisApplyRulesPage = new ApplyRulesPage();
			Report.IsTrue(thisApplyRulesPage.Wait_for_load(60), "Apply rules page has failed to load",
				"Apply rules page has loaded");
			
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on document queue button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("document queue"),
				"Failed to click document queue button",
				"Clicked document queue button");
			var thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.Wait_for_load(60), "Document queue page has failed to load",
				"Document queue page has loaded");
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on the product attributes button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentAttributesButton()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("attributes"),
				"Failed to click the product attributes button",
				"Clicked the product attributes button");
			Delay.Seconds(5);
			var thisProductAttributePage = new ProductAttributePage();
			Report.IsTrue(thisProductAttributePage.Wait_for_load(60), "Product attribute page has failed to load",
				"Product attribute page has loaded");

		}

		[StepDefinition(@"In Current Document Popup select checkbox: (.*)")]
		public void InCurrentDocumentPageSelectCheckbox(string checkbox)
		{
			Report.Info("Selecting checkbox: " + checkbox);
			var thisCurrentDocument = new CurrentDocument();
			Delay.Seconds(10);
			Report.Info("Attempting to click checkbox");
			Report.IsTrue(thisCurrentDocument.Wait_for_load(60), "Current document failed to load", "Current document loaded", showSuccessScreenshot:false);
			Report.IsTrue(thisCurrentDocument.SetCheckBox(checkbox, true), "Failed to set checkbox: " + checkbox, "Set checkbox: " + checkbox, showSuccessScreenshot: false);
			//Report.Screenshot();
		}

		[StepDefinition(@"I close Current Document")]
		public void GivenICloseCurrentDocument()
		{
			var thisCurrentDocument = new CurrentDocument();
			thisCurrentDocument.Close();
		}

		//| Text | Should Show |
		[StepDefinition(@"In Current Document I confirm that alert text matches")]
		public void GivenInCurrentDocumentIConfirmThatAlertTextMatches(Table table)
		{
			Report.Info("Beginning confirm that alert matches what is expected.");
			Delay.Seconds(2);
			var thisCurrentDocument = new CurrentDocument();
			Report.Info("Get alert text");
			string alertText= null;
			try
			{
				alertText = thisCurrentDocument.GetAlertText("The following subformat(s) cannot be authorized because required data is missing.");
				Report.Info($"Alert Text was found as {alertText} on the first try");
			}
			catch (Exception)
			{
				try
				{
					Report.Info("First Try of getting the Alert text failed, exeption was caught. Trying to find alert text again.");
					alertText = thisCurrentDocument.GetAlertText("The following subformat(s) cannot be authorized because required data is missing.");
					Report.Info($"Alert Text was found as {alertText} on the second try");
				}
				catch (Exception ex)
				{
					Report.Error("Failed to get alert text: " + ex.Message);
				}
			}

			if(alertText == null)
			{
				alertText = "";
				Report.Failure("The alertText was Null. Setting to empty but Alert text was expected!");
				
			}

			Report.Info("Alert is showing as: " + alertText);
			string regExPattern = @"\s[ABCDEFGHIJKLMNOPQRSTUVWZYZ1234567890]{3,7}[\,\\r]?";
			MatchCollection mc = Regex.Matches(alertText, regExPattern);
			var codes = new List<string>();

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

		public void ISetTheAuthoringCompleteCodeToNGHS()
		{
			this.ISetTheAuthoringCompleteCodeTo("NGHS");
		}

		[StepDefinition(@"I set the Authoring Complete code to: (NGHS|AGHS)")]
		public void ISetTheAuthoringCompleteCodeTo(string setTo)
		{
			var thisStudioPowerDesignerPlusDesignMode = new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.SetAUTHCinPowerAuthorPlus(setTo);
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("refresh"), "Failed to find the refresh button.", "Successfully clicked refresh.");
			Delay.Seconds(10);
		}


		[StepDefinition(@"I set the Datacodes as follows:")]
		public void GivenISetTheDatacodesAsFollows(Table table)
		{
			foreach (TableRow thisRow in table.Rows)
			{
				var thisStudioPowerDesignerPlusDesignMode =
					new StudioPowerDesignerPlusDesignMode();
				thisStudioPowerDesignerPlusDesignMode.DoubleClickDataCode(thisRow["datacode"]);
				Delay.Seconds(15);
				var thisGraphicEditor = new GraphicEditor();
				Report.IsTrue(thisGraphicEditor.Wait_for_load(90), "Graphic editor has not loaded",
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
				}

				Report.IsTrue(thisGraphicEditor.SelectGraphic(valueToSearchFor),
					"Failed to select graphic: " + valueToSearchFor, "Set graphic: " + valueToSearchFor);
				Report.IsTrue(thisGraphicEditor.ClickButton("save"), "Failed to click save button",
					"Clicked save button");
				Delay.Seconds(1);
				thisGraphicEditor.Wait_for_close();
				Delay.Seconds(5);
			}
		}

		[StepDefinition(@"in the Edit Toolbar page I check the following items:")]
		public void GivenInTheEditToolbarPageICheckTheFollowingItems(Table table)
		{
			var thisPDiEditPage = new PDEditPage();
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
			var thisPDiEditPage = new PDEditPage();
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
			var thisApplyRulesPage = new ApplyRulesPage();
			Delay.Seconds(3);
			Report.IsTrue(thisApplyRulesPage.SetApplyOption(button), "Failed to click " + button + " button",
				"Clicked " + button);
		}

		[StepDefinition(@"In Apply Rules Page I click on the single rule ellipsis button")]
		public void InApplyRulesPageIClickOnTheSingleRulesEllipsisButton()
		{
			var thisApplyRulesPage = new ApplyRulesPage();
			Delay.Seconds(3);
			int i = 0;
			bool successClick = false;
			while (i < 5 && !successClick)
			{
				if (thisApplyRulesPage.ClickSingleRuleEllipsis())
				{
					Report.Success("Clicked single rules ellipsis");
					successClick = true;
				}
				else
				{
					Report.Info("Failed to click single rules ellipsis");

				}
				Delay.Seconds(2);
				i++;
			}
			if (!successClick)
			{
				Report.Failure("Failed to click single rules ellipsis after 5 tries");
			}
			//Report.IsTrue(thisApplyRulesPage.ClickSingleRuleEllipsis(), "Failed to click single rules ellipsis",
			//	"Clicked single rules ellipsis");
			Delay.Seconds(3);
			var thisSelectRulesPage = new SelectRulesPage();
			Report.IsTrue(thisSelectRulesPage.Wait_for_load(120), "Select rules page has not loaded",
				"Select rules page has loaded");
		}

		[StepDefinition(@"In Select Rules Popup Page I click on the filter icon")]
		public void InSelectRulesPageIClickOnFilterIcon()
		{
			var thisSelectRulesPage = new SelectRulesPage();
			Report.IsTrue(thisSelectRulesPage.ClickFilterButton(), "Failed to click filter button",
				"Clicked filter button");
			var thisSelectRulesFilter = new SelectRulesFilter();
			Report.IsTrue(thisSelectRulesFilter.Wait_for_load(), "Select rules popup has not loaded",
				"Select rules popup has loaded");
		}

		[StepDefinition(@"In Select Rules Filter Popup Page I enter the following: (.*) in textbox: (.*)")]
		public void InSelectRulesFilterPopupIEnterValueInTextBox(string value, string textbox)
		{
			var thisSelectRulesFilter = new SelectRulesFilter();
			Report.IsTrue(thisSelectRulesFilter.EnterInTextBox(textbox, value),
				"Failed to enter value: " + value + " in textbox: " + textbox,
				"Succeeded in entering value: " + value + " in textbox: " + textbox);
		}

		[StepDefinition(@"In Select Rules Filter Popup Page I select the following: (.*) from selectbox: (.*)")]
		public void InSelectRulesFilterPopupISelectFromSelectBox(string value, string selectbox)
		{
			var thisSelectRulesFilter = new SelectRulesFilter();
			Report.IsTrue(thisSelectRulesFilter.SelectFromSelectBox(selectbox, value),
				"Failed to enter value: " + value + " in selectbox: " + selectbox,
				"Succeeded in entering value: " + value + " in selectbox: " + selectbox);
		}

		[StepDefinition(@"In Select Rules Filter Popup Page I click button: (.*)")]
		public void InSelectRulesFilterPopupIClickButton(string button)
		{
			var thisSelectRulesFilter = new SelectRulesFilter();

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
			var thisSelectRulesPage = new SelectRulesPage();
			thisSelectRulesPage.Wait_for_load(30);
			Report.IsTrue(thisSelectRulesPage.SelectTopRule(), "Failed to select first rule", "Selected first rule");
			Delay.Seconds(3);
			try
			{
				Report.IsTrue(!thisSelectRulesPage.Wait_for_close(30), "Select rules popup has not closed",
					"Select rules popup has closed");
			}
			catch (Exception)
			{
				//do nothing
			}

		}

		[StepDefinition(@"In Apply Rules Page I click on the button: (.*)")]
		public void InApplyRulesPageIClickOnButton(string button)
		{
			Report.Info("Beginning: In Apply Rules Page I click on the button: " + button);
			var thisApplyRulesPage = new ApplyRulesPage();
			try
			{
				thisApplyRulesPage.Wait_for_load(60);
			}
			catch (Exception)
			{
				if (SeleniumBrowser.Alert.WaitForAlert(3))
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				}
			}

			Delay.Seconds(1);
			Report.IsTrue(thisApplyRulesPage.ClickButton(button), "Failed to click " + button, "Clicked " + button);
			if (button.ToLower() == "apply")
			{
				Report.Info("As button was apply, waiting for spinner and alert");
				Delay.Seconds(30);
				if (!thisApplyRulesPage.WaitForSpinner(120))
				{
					if (SeleniumBrowser.Alert.WaitForAlert(3))
					{
						SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
					}
					else
					{
						if (!thisApplyRulesPage.WaitForSpinner())
						{
							if (SeleniumBrowser.Alert.WaitForAlert(3))
							{
								SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
							}
							else
							{
								throw new Exception("Spinner is still showing");
							}
						}
					}
				}


			}
		}

		[StepDefinition(@"I click on document queue to open document queue popup")]
		public void IClickOnPublishThisDocumentToOpenDocumentQueuePopup()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			//Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("document queue"),
			//	"Failed to click document queue tool bar option", "Clicked document queue tool bar option");

			if (!thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("document queue"))
			{
				Report.Info("There may have been a problem clicking the document queue tool bar option...");
			}

			var thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.Wait_for_load(60), "Document Queue page failed to load",
				"Document queue page loaded");
		}

		[StepDefinition(@"In document queue popup I click on filter icon")]
		public void InDocumentQueuePopupIClickOnFilterIcon()
		{
			var thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.Wait_for_load(60), "Document Queue page failed to load",
				"Document queue page loaded");
			Report.IsTrue(thisDocumentQueuePage.ClickFilterButton(), "Failed to click filter button",
				"Clicked filter button");
			var thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.Wait_for_load(60), "Document Queue filter page failed to load",
				"Document queue filter page loaded");

		}

		[StepDefinition(@"In document queue filter page I enter value: (.*) in select box: (.*)")]
		public void InDocumentQueueFilterPageIEnterValueInSelectBox(string value, string selectBox)
		{
			var thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
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
				var productDetails = (ProductInformation)Context.GetFromContext(value.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
				value = productDetails.Id;
			}
			var thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.Wait_for_load(60), "Document Queue filter page failed to load",
				"Document queue filter page loaded");
			Report.IsTrue(thisSelectDocumentQueueFilter.EnterInTextBox(entryBox, value),
				"Failed to entry " + value + " in entry box: " + entryBox,
				"Entered " + value + " in entry box: " + entryBox);

		}

		[StepDefinition(@"In document queue filter page I click on apply")]
		public void InDocumentQueueFilterPageIClickOnApply()
		{
			var thisSelectDocumentQueueFilter = new SelectDocumentQueueFilter();
			Report.IsTrue(thisSelectDocumentQueueFilter.ClickApply(), "Failed to click on apply",
				"Click on apply");
		}

		[StepDefinition(@"In document queue filter page I click on select all checkbox")]
		public void InDocumentQueueFilterPageIClickOnSelectAllCheckbox()
		{
			var thisDocumentQueuePage = new DocumentQueuePage();
			thisDocumentQueuePage.Wait_for_load();
			Report.IsTrue(thisDocumentQueuePage.CheckSelectAllCheckbox(), "Failed to click select all checkbox",
				"Clicked select all checkbox");
		}

		[StepDefinition(@"In document queue filter page I click on process documents")]
		public void InDocumentQueueFilterPageIClickOnProcessDocuments()
		{
			Report.Info("Beginning: In document queue filter page I click on process documents");
			var thisDocumentQueuePage = new DocumentQueuePage();
			thisDocumentQueuePage.Wait_for_load();
			Report.IsTrue(thisDocumentQueuePage.ClickProcessDocuments(), "Failed to click process documents",
				"Clicked process documents",showSuccessScreenshot: false);
		}

		[StepDefinition(@"In document queue filter page I click on clone selected row")]
		public void InDocumentQueueFilterPageIClickOnCloneSelectedRow()
		{
			var thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.ClickCloneSelectedRow(), "Failed to click clone selected row",
				"Clicked clone selected row");
		}

		[StepDefinition(@"In document queue filter page I click on delete selected")]
		public void InDocumentQueueFilterPageIClickOnDeleteSelected()
		{
			var thisDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(thisDocumentQueuePage.ClickDeleteSelected(), "Failed to click delete selected",
				"Clicked delete selected");
		}

		[StepDefinition(@"In document queue filter page I click on close")]
		public void InDocumentQueueFilterPageIClickOnClose()
		{
			var thisDocumentQueuePage = new DocumentQueuePage();
			thisDocumentQueuePage.ClickClose();
		}

		[StepDefinition(@"I navigate to power designer plus")]
		public void NavigateToPowerDesignerPlus()
		{
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus");
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			thisPowerDesignerPlus.ClickContinueButton();
		}

		[StepDefinition(@"I should see an alert with the following message: (.*)")]
		public void IShouldSeeAnAlertAsFollows(string expectedAlertText)
		{
			var thisCurrentDocument = new CurrentDocument();
			string alertText = thisCurrentDocument.GetAlertText("");
			if (alertText == null)
			{
				Report.Failure("Could not find alert text!");
				Report.Screenshot();
				return;
			}
			Report.IsTrue(alertText.Contains(expectedAlertText),
				"Alert text is not as expected. Expected: " + expectedAlertText + " but got: " + alertText,
				"Alert text is showing as expected: " + expectedAlertText, false, false);
		}

		[StepDefinition(@"I close alert")]
		public void ICloseAlert()
		{
			try
			{
				SeleniumBrowser.Alert.WaitForAlert(3);
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				Delay.Seconds(1);
			}
			catch (Exception)
			{
				Report.Info("Alert is not showing");
			}

		}

		[StepDefinition(@"I check the following items are showing in the Document Queue table")]
		public void GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(Table table)
		{
			var tableHeaders = table.Header.ToList();

			var newDocumentQueuePage = new DocumentQueuePage();
			Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
				"Document queue page loaded");
			List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
			Report.Info(listOfDocuments.Count.ToString() + " documents found");

			var propertiesInDocument = new Document().GetType().GetProperties().Select(x => x.Name).ToList();

			var notFoundInDocument = tableHeaders.Except(propertiesInDocument).ToList();

			if (notFoundInDocument.Count() > 0)
			{
				throw new Exception("Not all items listed are in the document object model: " + string.Join(",", notFoundInDocument));
			}
			Report.Info("All items listed are in the document object model");

			//Checking all rows in the table
			foreach (TableRow thisRow in table.Rows)
			{
				var actualHeaders = new List<string>();
				listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				//for each column in the table
				foreach (string header in tableHeaders)
				{
					string value = thisRow[header];
					//Report.Info("Looking at item: " + value + " for header: " + header);

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
						//Report.Info("List of documents count before: " + listOfDocuments.Count);
						listOfDocuments = listOfDocuments.Where(x =>
							x.GetType().GetProperty(thisPropertyName).GetValue(x, null).ToString() == value).ToList();
						//Report.Info("List of documents count after: " + listOfDocuments.Count);
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

				var thisStudioShaManager = new StudioSHAManager();
				Report.IsTrue(thisStudioShaManager.SelectProductByID(idToSelect),
					"Failed to select item by id: " + idToSelect, "Selected item with id: " + idToSelect);
			}
			catch (Exception)
			{
				Report.Info("Alert is not showing");
			}
		}

		[StepDefinition(@"In SHA Manager I click on bottom menu item: (.*)")]
		public void InSHAManagerIClickOnBottomMenuItem(string menuItem)
		{
			try
			{
				var thisStudioShaManager = new StudioSHAManager();
				Report.IsTrue(thisStudioShaManager.ClickBottomMenuOption(menuItem), "Failed to click: " + menuItem,
					"Clicked menu item: " + menuItem);
			}
			catch (Exception)
			{
				Report.Info("Alert is not showing");
			}
		}

		[StepDefinition(@"In the Process Products popup in SHAManager I select the following retailers")]
		public void GivenInTheProcessProductsPopupInSHAManagerISelectTheFollowingRetailers(Table table)
		{
			var thisProcessProducts = new ProcessProducts();
			Report.IsTrue(thisProcessProducts.Wait_for_load(30), "Process products screen is not showing",
				"Process products screen is showing");
			foreach (TableRow tableRetailer in table.Rows)
			{
				string thisRetailer = tableRetailer["Retailer"];
				if (thisRetailer.ToLower().Contains("saved as"))
				{
					thisRetailer = Context
						.GetFromContext(thisRetailer.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
						.ToString();
				}
				Report.IsTrue(thisProcessProducts.SelectRetailer(thisRetailer),
					"Failed to select retailer: " + thisRetailer,
					"Selected retailer: " + thisRetailer);
			}
		}

		[StepDefinition(@"In the Process Products popup in SHAManager I set the new status drop down list to be: (.*)")]
		public void GivenInTheProcessProductsPopupInSHAManagerISetNewStatusDDListTo(string status)
		{
			var thisProcessProducts = new ProcessProducts();
			Report.IsTrue(thisProcessProducts.Wait_for_load(30), "Process products screen is not showing",
				"Process products screen is showing");
			Report.IsTrue(thisProcessProducts.SelectNewStatus(status), "Failed to select new status: " + status,
				"Selected new status: " + status);
		}

		[StepDefinition(@"In the Process Products popup in SHAManager I click on update status button")]
		public void GivenInTheProcessProductsPopupInSHAManagerIClickOnUpdateStatusButton()
		{
			var thisProcessProducts = new ProcessProducts();
			Report.IsTrue(thisProcessProducts.Wait_for_load(30), "Process products screen is not showing",
				"Process products screen is showing");
			Report.IsTrue(thisProcessProducts.ClickUpdateStatus(), "Failed to click update status",
				"Clicked update status");
		}


		[StepDefinition(@"In the Product Formulation page I click button: (.*)")]
		public void InTheProductForulationPageIClickButton(string button)
		{
			var thisFormulationPage = new ProductFormulationPage();
			Report.IsTrue(thisFormulationPage.Wait_for_load(30), "Product formulation screen is not showing",
				"Product formulation screen is showing");
			Report.IsTrue(thisFormulationPage.ClickButton(button), "Failed to click button: " + button,
				"Clicked button: " + button);
		}

		[StepDefinition(@"In the Create component page I add component")]
		public void InTheCreateComponentPageIAddComponent(TechTalk.SpecFlow.Table component)
		{
			var thisCreateComponentPage = new CreateComponentPage();
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
						object savedAsItem = Context.GetFromContext(CASNo.Replace("saved as", "").Trim());
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
						object savedAsItem = Context.GetFromContext(chemName.Replace("saved as", "").Trim());
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
					Report.IsTrue(thisCreateComponentPage.AddToFormulationNowCheckboxChecked(component.Rows[0]["Add to Formulation Now"].ToLower() == "true"),
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

		[StepDefinition(@"I close the Product Formulation page")]
		public void GivenICloseTheProductFormulationPage()
		{
			var thisFormulationPage = new ProductFormulationPage();
			Report.IsTrue(thisFormulationPage.Wait_for_load(30), "Product formulation screen is not showing",
				"Product formulation screen is showing");
			thisFormulationPage.ClickClose();
		}

		[StepDefinition(@"In the Power Designer Plus Welcome page I enter Select Source Product: (.*)")]
		public void PowerDesignerPlusWelcomeIEnterSelectSourceProduct(string productID)
		{
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.EnterSourceProduct(productID), $"Failed to enter {productID} into the Select Source Product field!", $"Successfully entered {productID} into the Select Source Product field");
			Report.Info("Clicking Refresh");
			thisPowerDesignerPlus.ClickRefreshButton();
		}

		[StepDefinition(@"I confirm the selected Subformat in the Power Designer Plus popup is: (.*)")]
		public void IConfirmTheSelectedSubformatInThePdPlusPopupIs(string subFormat)
		{
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlus();
			string selectedSubFormat = selStudioPowerDesignerPlus.SelectedSubFormat();
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
			if(click=="right"||!selStudioPowerDesignerPlus.IsSectionActive(section))
			{
				Report.IsTrue(selStudioPowerDesignerPlus.Wait_for_load(30), "Studio power designer is not open",
								"Studio power designer is open");
				Report.IsTrue(selStudioPowerDesignerPlus.ClickLeftMenuSection(section, click),
					"Failed to " + click + " click section: " + section,
					"Successfully " + click + " clicked " + section);
				Delay.Seconds(3);
				return;
			}
			Report.Success("The Section was already active");
			
		}

		[StepDefinition(@"In Power Designer I double click on category: (.*)")]
		public void GivenInPowerDesignerIDoubleClickOnCategory(string category)
		{
			Report.Info("Beginning double click on category to edit: " + category);
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(selStudioPowerDesignerPlus.DoubleClickCategoryToEdit(category),
				"Failed to double click category: " + category,
				"Successfully clicked " + category);
		}

		[StepDefinition(@"In Power Designer the phrase selector screen should open")]
		public void ThenInPowerDesignerThePhraseSelectorScreenShouldOpen()
		{
			var thisPhraseEditor = new PhraseEditor();
			Report.IsTrue(thisPhraseEditor.Wait_for_load(60), "Phrase editor has not opened.",
				"Phrase editor has opened");
		}

		[StepDefinition(@"In the phrase selector screen I select phrases:")]
		public void ThenInThePhraseSelectorScreenISelectPhrases(Table table)
		{
			bool addedSuccessfully = true;
			var thisPhraseEditor = new PhraseEditor();
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
							thisPhraseEditor.FilterSelectPhrases(thisPhrase["Text"]);
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
			var thisPhraseEditor = new PhraseEditor();
			if (!thisPhraseEditor.Wait_for_load(60))
			{
				throw new Exception("Phrase editor is not loaded");
			}

			Report.IsTrue(thisPhraseEditor.ClickButton(button), "Failed to click button: " + button,
				"Clicked button: " + button);
		}



		[StepDefinition(@"I click on home to navigate back to editing specific product saved as (.*)")]
		public void GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(string savedAs)
		{
			var thispd = new StudioPowerDesignerPlusDesignMode();
			thispd.Wait_for_load(5);
			thispd.ClickMenuAndSubmenuOptions("Home");
			Delay.Seconds(3);
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
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
			string id = productDetails.Id;
			thisPowerDesignerPlus.EnterSourceProduct(id);
			thisPowerDesignerPlus.ClickRefreshButton();
			Delay.Seconds(1);
			Report.Info("Found label: " + thisPowerDesignerPlus.GetSourceProductName());
			Report.IsTrue(thisPowerDesignerPlus.ClickContinueButton(), "Failed to click continue button",
				"Clicked continue button");
			var selStepsStudio = new Steps_Studio();
			//selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			//selStepsStudio.InPDIEnsureSECT2318IsActive();
			//selStepsStudio.InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData();
			selStepsStudio.InPowerDesignerIClickOnTheSectionsSideTab();
			selStepsStudio.GivenInPowerDesignerIClickOnSection("left", "[SECT0755] Chemical Product Checklist");
		}

		[StepDefinition(@"I check whether the current environment is Staging or Production and if it is I skip the next three steps")]
		public void GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps()
		{
			if (TReVorSettings.SoftwareBranch == "Staging" || TReVorSettings.SoftwareBranch == "Local Production" ||
				TReVorSettings.SoftwareBranch == "Production")
			{
				Report.Info("Setting context of electronic product");
				Context.AddToContext("ElectronicProduct", "true");
			}
		}

		[StepDefinition(@"I click on Product Attributes to open product attribute popup")]
		public void IClickOnProductAttributesToOpenProductAttributePopup()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("prodattributes"),
				"Failed to click product attribute tool bar option", "Clicked product attribute tool bar option");

			Delay.Seconds(3);
		}

		[StepDefinition(@"In Product Attributes Popup Page I click on the filter icon")]
		public void InProductAttributePageIClickOnFilterIcon()
		{
			var thisProductAttributePage = new ProductAttributePage();
			thisProductAttributePage.Wait_for_load(30);
			Report.IsTrue(thisProductAttributePage.ClickToolbarItem("Filter"), "Failed to click filter button",
				"Clicked filter button");
			var thisProductAttributesFilter = new ProductAttributesFilter();
			Report.IsTrue(thisProductAttributesFilter.Wait_for_load(), "Product attribute popup has not loaded",
				"Product attributes popup has loaded");
		}

		[StepDefinition(@"In Product Attributes Filter Popup Page I enter the following: (.*) in textbox: (.*)")]
		public void InProductAttributeFilterPopupIEnterValueInTextBox(string value, string textbox)
		{
			var thisProductAttributesFilter = new ProductAttributesFilter();
			Report.IsTrue(thisProductAttributesFilter.EnterInTextBox(textbox, value),
				"Failed to enter value: " + value + " in textbox: " + textbox,
				"Succeeded in entering value: " + value + " in textbox: " + textbox);
		}

		[StepDefinition(@"In Product Attributes Filter Popup Page I select the following: (.*) from selectbox: (.*)")]
		public void InProductAttributeFilterPopupISelectFromSelectBox(string value, string selectbox)
		{
			var thisProductAttributesFilter = new ProductAttributesFilter();
			Report.IsTrue(thisProductAttributesFilter.SelectFromSelectBox(selectbox, value),
				"Failed to enter value: " + value + " in selectbox: " + selectbox,
				"Succeeded in entering value: " + value + " in selectbox: " + selectbox);
		}

		[StepDefinition(@"In Product Attributes Filter Popup Page I click button: (.*)")]
		public void InProductAttributeFilterPopupIClickButton(string button)
		{
			var thisProductAttributesFilter = new ProductAttributesFilter();

			switch (button.ToLower())
			{
				case "apply":
					Report.IsTrue(thisProductAttributesFilter.ClickApply(), "Failed to click apply button",
						"Clicked apply button");
					break;
				case "cancel":
					Report.IsTrue(thisProductAttributesFilter.ClickCancel(), "Failed to click cancel button",
						"Clicked cancel button");
					break;
				case "clear":
					Report.IsTrue(thisProductAttributesFilter.ClickClear(), "Failed to click clear button",
						"Clicked clear button");
					break;
				default:
					Report.Error("Failed to provide valid button name to click - must be apply, cancel or clear");
					break;
			}

		}

		[StepDefinition(@"In Product Attributes Popup Page I should see (\d+) results")]
		public void InProductAttributePageIShouldSeeXResults(int expectedResults)
		{
			var thisProductAttributePage = new ProductAttributePage();
			Report.IsTrue(thisProductAttributePage.GetRecordCount() == expectedResults, "Reults were not as expected",
				"Results count was as expected");
		}

		[StepDefinition(@"In Power Designer Plus page in My Toolbar tab I click on check in\/out button")]
		public void GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnInOutButton()
		{
			var thisStudioPowerDesignerPlusDesignMode =
				new StudioPowerDesignerPlusDesignMode();
			thisStudioPowerDesignerPlusDesignMode.Wait_for_load();
			Report.IsTrue(thisStudioPowerDesignerPlusDesignMode.ClickToolBarItem("in out"),
				"Failed to click in out button",
				"Clicked in out button");
		}

		[StepDefinition(@"In Assign\/Reassign products I click on: (Check In|Check Out)")]
		public void GivenInAssignProductsPopupIClickOnCheckInOrCheckOut(string checkInOrCheckOut)
		{
			var thisAssignReassignProducts = new AssignReassignProducts();
			thisAssignReassignProducts.Wait_for_load();
			Report.IsTrue(thisAssignReassignProducts.ClickButton(checkInOrCheckOut),
				"Failed to click button: " + checkInOrCheckOut,
				"Clicked button: " + checkInOrCheckOut);
		}

		//Given I Click My Toolbars
		//AssignReassignProducts
		//	And I Click the Check In / Out Icon
		//	And I Click Check In
		//And I Click the X in the top corner of the pop up to close it

		[StepDefinition(@"In power designer popup I set language option: (.*)")]
		public void InPowerDesignerPopupISetLanguageOption(string language)
		{
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.SetLanguage(language), "Failed to set language option",
				"Set language option");
		}

		[StepDefinition(@"In power designer popup I set subformat option: (.*)")]
		public void InPowerDesignerPopupISetSubFormatOption(string subformat)
		{
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.Info("Setting power designer plus options...");
			Report.IsTrue(thisPowerDesignerPlus.EnterSubFormatFilter(subformat), "Failed to set subformat option",
				"Set subformat option");
		}


		[StepDefinition(@"In power designer popup I set format: (.*) and subformat: (.*)")]
		public void InPowerDesignerPopupISetFormatAndSubFormatOption(string format, string subformat)
		{
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.IsTrue(thisPowerDesignerPlus.SelectFormat(format, subformat), "Failed to set format option",
				"Set format option");
		}

		[StepDefinition(@"In power designer popup I select product id option: (.*)")]
		public void InPowerDesignerPopupISelectProductIDOption(string productIDOption)
		{
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.IsTrue(thisPowerDesignerPlus.SelectProductIDOption(productIDOption), "Failed to set action option",
				"Set action option");
		}

		[StepDefinition(@"In power designer popup I select any Format/Subformat")]
		public void InPowerDesignerPopupISelectAnyFormatSubFormatOption()
		{
			var thisPowerDesignerPlus = new StudioPowerDesignerPlus();
			Report.IsTrue(thisPowerDesignerPlus.Wait_for_load(30), "Power designer plus has not loaded",
				"Power designer plus has loaded");
			Report.IsTrue(thisPowerDesignerPlus.SelectRandomFormat(), "Failed to select ranodm format",
				"Selected random format");
		}
		[StepDefinition(@"In Power Designer I click on the 'Sections' side tab if it is closed")]
		public void InPowerDesignerIClickOnTheSectionsSideTab()
		{
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();
			Report.IsTrue(selStudioPowerDesignerPlus.Wait_for_load(30), "Studio power designer is not open",
				"Studio power designer is open");
			if(selStudioPowerDesignerPlus.IsSectionsTabOpen())
			{
				Report.Success("The sections tab was already Open");
				return;
			}
			Report.IsTrue(selStudioPowerDesignerPlus.ClickSectionsTab(), "Failed to click on Sections Tab", "Succesfully clicked on the sections tab");
			Report.IsTrue(selStudioPowerDesignerPlus.IsSectionsTabOpen(), "The sections tab was not opened", "The sections tab was opened");	
								
						
		}

		[StepDefinition(@"In PD+ I Fill the section WALMART QC RESPONCE FORM with junk data")]
		public void InPDIFillTheSectionWALMARTQCRESPONCEFORMWithJunkData()
		{
			ReportSettings.UseSubSteps = true;
			var studioPowerDesignerPlus = new StudioPowerDesignerPlus();
			var valueEdit = new ValueEditor();
			Report.StartStep("I Select the Catagory Titled: Inquiry Date");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Inquiry Date");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");			
			Report.StartStep("I Click on 'Select Current Date'");
			valueEdit.SelectCurrentDate();
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			//valueEdit.ClickButton("Save");
			Delay.Seconds(1);
			Report.StartStep("I Double Click on the section with name: Response Date");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Response Date");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded","Power designer plus has loaded");
			Report.StartStep("I Click on 'Select Current Date'");
			valueEdit.SelectCurrentDate();
			Delay.Seconds(1);			
			valueEdit.ClickSaveButton();

			Delay.Seconds(1);			
			Report.StartStep("I Double Click on the section with name: Type of Inquiry/Concern");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Type of Inquiry/Concern");
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Clicking the first available option in the list");
			valueEdit.SelectTopOption();
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();

			Delay.Seconds(1);
			Report.StartStep("I Double Click on the section with name: Brief Description of Issue");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Brief Description of Issue");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Entering the value: 'Test' Into the New Value box");
			valueEdit.NewValueBox.EnterText("Test");
			//valueEdit.EnterValueIntoField("Test");
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();

			Delay.Seconds(1);
			Report.StartStep("I Double Click on the section with name: Revision Required?");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Revision Required?");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Clicking the first available option in the list");
			valueEdit.SelectTopOption();
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);

			Report.StartStep("I Double Click on the section with name: Justification");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Justification");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Entering the value: 'Test' Into the New Value box");
			valueEdit.NewValueBox.EnterText("Test");
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);

			Report.StartStep("I Double Click on the section with name: Root Cause (if Revision Required)");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Root Cause (if Revision Required)");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Clicking the first available option in the list");
			valueEdit.SelectTopOption();
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);
			


			Report.StartStep("I Double Click on the section with name: Corrective Action (if Revision Required)");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Corrective Action (if Revision Required)");
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Clicking the first available option in the list");
			valueEdit.SelectTopOption();
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);			


			Report.StartStep("I Double Click on the section with name: Additional Information");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Additional Information");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Entering the value: 'Test' Into the New Value box");
			valueEdit.NewValueBox.EnterText("Test");
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);

			Report.StartStep("I Double Click on the section with name: Regulatory/IT Contact");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Regulatory/IT Contact");
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Entering the value: 'Test' Into the New Value box");
			valueEdit.NewValueBox.EnterText("Test");
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);

			Report.StartStep("I Double Click on the section with name: Approving Manager");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Approving Manager");
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Entering the value: 'Test' Into the New Value box");
			valueEdit.NewValueBox.EnterText("Test");
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);

			Report.StartStep("I Double Click on the section with name: Inquiry Submitted By:");
			this.GivenInPowerDesignerIDoubleClickOnCategory("Inquiry Submitted By:");			
			Report.IsTrue(valueEdit.Wait_for_load(30), "Power designer plus has not loaded", "Power designer plus has loaded");
			Report.StartStep("Clicking the first available option in the list");
			valueEdit.SelectTopOption();
			Delay.Seconds(1);
			valueEdit.ClickSaveButton();
			Delay.Seconds(1);
		}

		[StepDefinition(@"In Power Designer I ensure SECT2318 is the Active Section")]
		public void InPDIEnsureSECT2318IsActive()
		{
			string click = "left";
			var selStudioPowerDesignerPlus = new StudioPowerDesignerPlusDesignMode();			
			if(new StudioPowerDesignerPlusDesignMode().ActiveSectionMatches("[SECT2318]"))
			{
				Report.Success("The Section was already active");
				return;
			}
			Report.IsTrue(selStudioPowerDesignerPlus.Wait_for_load(30), "Studio power designer is not open",
								"Studio power designer is open");
			Report.IsTrue(selStudioPowerDesignerPlus.ClickLeftMenuSection("[SECT2318] WALMART QC RESPONSE FORM", click),
				"Failed to " + click + " click section: " + "[SECT2318] WALMART QC RESPONSE FORM",
				"Successfully " + click + " clicked " + "[SECT2318] WALMART QC RESPONSE FORM");
			Delay.Seconds(3);
			return;


			

		}


	}
}

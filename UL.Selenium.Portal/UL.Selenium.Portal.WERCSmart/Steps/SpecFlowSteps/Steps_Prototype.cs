using System;
using System.Collections.Generic;
using System.Linq;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Automation.Utilities.Helpers;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "StepsPrototype")]
	class Steps_Prototype
	{
		//[RegexStepDefinition(@"I set the radio option in section: (.*) to: (.*)")]
		public void SetRadioOptionInSectionTo(string section, string option)
		{
			Report.IsTrue(new NewProduct().SelectRadio(section, option),
				$"Failed to select radio option in section: '{section}' to option: '{option}'",
				$"Successfully set radio option: '{option}'");
		}

		//[RegexStepDefinition(@"I set the (.*) field to: (.*)")]
		//[RegexStepDefinition(@"I set the (.*) option to: (.*)")]
		public void SetTheSectionOptionTo(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			if (option.StartsWith("UPC"))
			{
				var value = Context.GetFromContext(option)?.ToString();
				if (value == null)
				{
					throw new Exception($"Could not find item in context: {option} for checking field input is correct value!");
				}
				section = section.Trim();
				value = value.Trim();
				Report.IsTrue(thisNewProduct.SetOptionInSection(section, value),
					$"Failed to set the input to {value} in section: {section}",
					$"Successfully set the input to {value} in section: {section}");
				Delay.Seconds(1);
			}
			else
			{
				section = section.Trim();
				option = option.Trim();
				Report.IsTrue(thisNewProduct.SetOptionInSection(section, option),
					$"Failed to set the input to {option} in section: {section}",
					$"Successfully set the input to {option} in section: {section}");
				Delay.Seconds(1);
			}
		}

		[RegexStepDefinition(@"in the (.*) page, I click Continue")]
		public void GivenInPageIClickContinue(string page)
		{
			var newProduct = new NewProduct();
			if (!newProduct.WaitForContainerToBeVisible())
			{
				Report.Failure("New Product page is not loaded");
				return;
			}
			if (!page.Equals("New Product", StringComparison.InvariantCultureIgnoreCase) && !newProduct.WaitForSection(page))
			{
				Report.Error($@"The page title did not match expected! Expected ""{page}""");
			}
			Report.Info("Clicking Continue");
			Report.IsTrue(newProduct.ClickContinue(), "Failed to click continue in the new product page!", "Successfully clicked continue in the new product page");
			if (page == "The Product" && newProduct.HeaderText == "The Product")
			{
				Report.Info("The active page is still 'The Product' after clicking continue");
				Report.Info("Checking for Raw Materials Warning pop up");
				var thisModalDialog = new ModalDialog();
				if (!thisModalDialog.WaitForContainerToBeVisible() || thisModalDialog.GetTitle() != "Warning")
				{
					Report.Failure("Failed to click continue to the next page!");
					return;
				}
				Report.IsTrue(thisModalDialog.Click_OK(), "Failed to click OK in the modal", "Clicked OK in the modal");
			}
		}

		public void GivenIConfirmTheTextsDisplaysTheCorrectText(string section, string[] correctText, string condition)
		{
			var newProductPage = new NewProduct();
			if (condition == "should")
			{
				Report.IsTrue(newProductPage.CheckTextOnThePage(correctText), $"The text in the {section} page displayed the incorrect text", $"The text in the {section} page displayed the correct text");
			}
			else
			{
				Report.IsFalse(newProductPage.CheckTextOnThePage(correctText), $"The text is displayed in the {section} page, but should not", $"The text is not displayed in the {section} page, as expected");

			}
		}
		[RegexStepDefinition(@"Click link element with test: (.*)")]

		public void ClickLinkElement(string linkText)
		{
			if (Report.IsTrue(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}"))
			{
				Report.IsTrue(new NewProduct().LinkElementClick(linkText), $"Failed to click link element with text {linkText}", $"Successfully clicked link element with text {linkText}");
			}
		}
		[RegexStepDefinition(@"Confirm link element (should|should not) exists with test: (.*)")]

		public void LinkElementExists(string condition, string linkText)
		{
			if (condition == "should")
			{
				Report.Info($"Attempt to confirm link element {linkText} is displayed");
				Report.IsTrue(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}");
			}
			else
			{
				Report.Info($"Attempt to confirm link element {linkText} is not displayed");
				Report.IsFalse(new NewProduct().LinkElementExists(linkText), $"Failed to confirm link element with text {linkText} is not displayed", $"Successfully confirmed link element with text {linkText} is not displayed");
			}
		}

		[RegexStepDefinition(@"I switch to tab with url: (.*)")]
		public void ConfirmNewTabOpenWithUrl(string url)
		{
			new GlobalSteps().SwitchToTheTab(url);
		}

		[RegexStepDefinition(@"I close the tab with url: (.*)")]
		public void CloseTabWithUrl(string url)
		{
			SeleniumWebDriver.CurrentDriver.CloseTabWithURL(url);
			Report.IsTrue(!SeleniumWebDriver.CurrentDriver.GetTabURLs().Contains(url), "Failed to close tab with URL: " + url, "Successfully closed tab with URL: " + url);
		}
		[RegexStepDefinition(@"I confirm the tab (should|should not) exists with url: (.*)")]
		public void NewTabShouldExists(string condition, string url)
		{
			if (condition == "should")
			{
				Report.IsTrue(SeleniumWebDriver.CurrentDriver.GetTabURLs().Contains(url), $"Failed to confirm new tab exists with url {url}", $"Successfully confirmed new tab exists with url {url}");
			}
			else
			{
				Report.IsTrue(!SeleniumWebDriver.CurrentDriver.GetTabURLs().Contains(url), $"Failed confirm new tab does not exist with url {url}", $"Successfully confirmed new tab does not exist with url {url}");
			}
		}
		[RegexStepDefinition(@"I confirm that a file is produced called (.*) and save as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
		{
			Report.StartStep($"{Report.Details.StepIndex} - Confirm File is downloaded with name: {file}");
			try
			{
				Delay.Seconds(10);
				Report.Info("Confirm a file is downloaded with name: " + file);
				//string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				string downloadsFolder = AutomationSettings.DownloadsFolder;

				Report.Info("Downloads folder: " + downloadsFolder);
				string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
				if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
				{
					Context.AddToContext(savedAs, dir.FirstOrDefault());
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[RegexStepDefinition("I compare the PDF: (.*) to the oracle PDF: (.*)")]
		public void CompareTwoPdfFiles(string toCompare, string oracle)
		{
			Assembly studioAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => string.Equals(x.GetName().Name, "UL.Selenium.Portal.WERCSmart"));
			// Initialize Sub-Steps
			Report.UseSubSteps = true;
			Report.StartSubStep("Setup");

			// Get embedded resource(s).
			Report.Info("Getting embedded resources...");
			string toCompareResourceFile = toCompare;
			string oracleResourceFile = $"{studioAssembly.GetName().Name}.{oracle}";

			// Define an extraction folder.
			string extractionFolder = Path.Combine(Directory.GetCurrentDirectory(), "Temp", Guid.NewGuid().ToString());
			_ = Directory.CreateDirectory(extractionFolder);
			//"C:\Users\32143\source\repos\UL.Selenium.Portal\UL.Selenium.Portal\UL.Selenium.Portal.WERCSmart\Dependencies\PDF\HR1321.pdf"
			try
			{
				// Define location to save comparison pdf to.
				string toCompareFile = Path.Combine(extractionFolder, "downloaded.pdf");
				Report.Info($"Saving comparison PDF file to: {toCompareFile}");
				FileInfo fileDownloded = new FileInfo(toCompareResourceFile);
				fileDownloded.MoveTo(toCompareFile);
				// Get from embedded resources.
				//_ = EmbeddedResourceHelpers.ExtractToFile(toCompareResourceFile, studioAssembly, toCompareFile);

				// Define location to store saved images to.
				string compareImageFolder = Path.Combine(extractionFolder, "Images", "downloadedFile");
				Report.Info($"Extracting comparison images to: {compareImageFolder}_«PageNumber».png");

				// Extract page 'images' from PDF file.
				_ = PdfHelpers.ConvertPdfToImages(toCompareFile, compareImageFolder, out List<string> comparisonOutputFiles);

				// Define location to save oracle pdf to.
				string oracleFile = Path.Combine(extractionFolder, "originalFile.pdf");
				Report.Info($"Saving oracle PDF file to: {oracleFile}");
				var extractToFile = EmbeddedResourceHelpers.ExtractToFile(oracleResourceFile, studioAssembly, oracleFile);

				FileInfo fileOriginal = new FileInfo(oracleFile);
				//fileOriginal.MoveTo(oracleFile);
				// Get from embedded resources.

				// Define location to store saved images to.
				string oracleImageFolder = Path.Combine(extractionFolder, "Images", "originalFile");
				Report.Info($"Extracting oracle images to: {oracleImageFolder}_«PageNumber».png");

				// Extract page 'images' from PDF file.
				_ = PdfHelpers.ConvertPdfToImages(oracleFile, oracleImageFolder, out List<string> oracleOutputFiles);

				// Check to see if the page count is the same for both files.
				if (oracleOutputFiles.Count != comparisonOutputFiles.Count)
				{
					Report.Failure($"Expected to find: {oracleOutputFiles.Count} images, but found: {comparisonOutputFiles.Count} instead!");
				}
				// Iterate through each page.
				int pagecount = Math.Min(oracleOutputFiles.Count, comparisonOutputFiles.Count);
				for (int i = 0; i < pagecount; i++)
				{
					Report.StartSubStep($"Checking Page: {i + 1}");

					// Define image paths for each image file.
					string oracleImagePath = oracleOutputFiles[i];
					string comparisonImagePath = comparisonOutputFiles[i];

					// Load each image file.
					Image oracleImage = Image.FromFile(oracleImagePath);
					Image comparisonImage = Image.FromFile(comparisonImagePath);
					//var result = oracleImage.CompareTo(comparisonImage, 0, false, out Image diffImage1);
					try
					{
						// Run comparison. By default, tolerance is 0% (so exact match), can be changed if required.
						if (!oracleImage.CompareTo(comparisonImage, 0, false, out Image diffImage))
						{
							// If we don't have a match, then render out the differential image.
							// The differential image will show a black pixel where there was a mismatched pixel located.

							// Define the folder to be used.
							string diffImageFolder = Path.Combine(extractionFolder, "Images", "Differentials");
							_ = Directory.CreateDirectory(diffImageFolder);

							// Save the differential image to disk.
							string diffImagePath = Path.Combine(diffImageFolder, $"Difference_{i + 1}.png");
							diffImage.Save(diffImagePath, ImageFormat.Png);

							// Report failure and add image to the report.
							Report.Failure("Page did not match!", false);

							// Report oracle image.
							Report.Info("Oracle:");
							Report.ImageFile(oracleImagePath);


							// Report comparison image.
							Report.Info("Showing:");
							Report.ImageFile(comparisonImagePath);

							// Report diff image.
							Report.Info("Difference:");
							Report.ImageFile(diffImagePath);
						}
						else
						{
							// Matched successfully.
							Report.Success("Page matched successfully!", showScreenshot: false);

							// Report oracle image.

							Report.ImageFile(oracleImagePath);

						}
					}
					catch (Exception ex)
					{
						Report.Info($"Fixable ERROR: {ex.Message}");
					}
					finally
					{
						oracleImage.Dispose();
						comparisonImage.Dispose();
					}
				}

			}
			catch (Exception ex)
			{
				Report.Failure($"ERROR: {ex.Message}");
			}
			finally
			{
				if (Directory.Exists(extractionFolder))
				{
					Directory.Delete(extractionFolder, true);
				}
			}
		}

		[RegexStepDefinition(@"I (should|should not) see an alert with title: (.*) subtitle: (.*) Text: (.*)")]
		public void ThenIShouldSeeAnAlertWithTitleSubtitleText(string condition, string title, string subtitle, string text)
		{
			var thisNewProduct = new NewProduct();
			Alert thisAlert = thisNewProduct.GetAlert();
			if (condition == "should")
			{
				Report.IsTrue(thisAlert.Title == title, "Title is not as expected", "Warning title is displayed");
				Report.IsTrue(thisAlert.SubTitle.Contains(subtitle), $"SubTitle is not as expected. Expected {subtitle}, but got: {thisAlert.SubTitle}", "Warning subtitle is displayed");
				Report.IsTrue(thisAlert.Text == text, $"Text is not as expected. Expected {text}, but got: {thisAlert.Text}", "Warning text is displayed");
			}
			else
			{
				Report.IsFalse(thisAlert.Title == title, "Warning title is displayed, but it is not expected", "Warning title is not displayed, as expected");
				Report.IsFalse(thisAlert.SubTitle.Contains(subtitle), "SubTitle is displayed, but it is not expected.", "SubTitle is not displayed, as expected.");
				Report.IsFalse(thisAlert.Text == text, "Warning text is displayed, but it is not expected.", "Warning text is not displayed, as expected.");
			}
		}
		[RegexStepDefinition(@"I click the browse button for section: (.*) and upload PDF: (.*)")]
		public void UploadPDFFile(string section, string pdfFile)
		{
			pdfFile = EmbeddedResourceHelpers.ExtractToFile(pdfFile, out string extractFile) ? extractFile : pdfFile;
			Report.IsTrue(new NewProduct().UploadFileForSection(section, pdfFile), $"Failed to upload PDF file: {pdfFile} for section {section}", $"Successfully uploaded PDF file: {pdfFile} for {section}");
		}
		//[RegexStepDefinition(@"I click the button (.*) for section: (.*)")]
		public void ClickButtonForSection(string section, string button)
		{
			Report.IsTrue(new NewProduct().ClickButton(section, button), $"Failed to click button {button} for section {section}", $"Successfully clicked {button} for {section}");
		}

		//[RegexStepDefinition(@"I check the button (.*) (should|should not) exists for section: (.*)")]
		public void CheckButtonExistsForSection(string section, string condition, string button)
		{
			if (condition == "should")
			{
				Report.IsTrue(new NewProduct().CheckButtonExistsInSection(section, button), $"Failed to confirm button {button} exists for section {section}", $"Successfully confirmed {button} exists for {section}");
			}
			else
			{
				Report.IsFalse(new NewProduct().CheckButtonExistsInSection(section, button), $"Failed to confirm button {button} does not exist for section {section}", $"Successfully confirmed {button} does not exist for {section}");
			}
		}
		[RegexStepDefinition(@"In the popup with the following title: (.*) I click the (.*) button")]
		public void ThenInThePopupViewWithTheFollowingTitleIClickTheButton(string popupTitle, string buttonTitle)
		{
			Report.IsTrue(new ModalDialog().ClickTheButtonInThePopupView(popupTitle, buttonTitle), "Failed to click the " + buttonTitle + " button", "Successfully clicked the " + buttonTitle + " button");
			//Delay.Seconds(5);
			Delay.Seconds(1);
		}

		[RegexStepDefinition(@"The alert message (should|should not) displayed with text: (.*)")]
		public void AlertMessageDisplayed(string displayed, string alert)
		{
			bool expectDisplayed = false;
			switch (displayed)
			{
				case "should":
					expectDisplayed = true;
					break;
				case "should not":
					break;
				default:
					Report.Failure("Step parameter must be either 'should' or 'should not'");
					return;
			}
			List<string> actualAlerts = new NewProduct().DisplayedAlerts();
			if (actualAlerts == null)
			{
				Report.Failure("Error fetching alert messages!");
				return;
			}
			Report.IsTrue(actualAlerts.Contains(alert) == expectDisplayed,
				$"Alert message {(expectDisplayed ? "is not" : "is")} displayed when . Expected: {alert} but got: {string.Join(",", actualAlerts)}",
				$"Message: '{alert}' is displayed as expected");
		}

		[RegexStepDefinition(@"Error message in section: (.*) (should|should not) be showing the error messages: (.*)")]
		public void ErrorMessagesAreShowingForItem(string section, string should, string pipeDelimitedErrorMessages)
		{
			Delay.Seconds(1);
			string[] errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			List<string> errorMessages = new NewProduct().GetErrorsForSection(section);
			Report.Info(string.Format($"Error messages showing are: {errorMessages}"));
			if (should == "should")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsTrue(errorMessages.Any(e => e.Contains(item)), $"Failed to find the error message: {item} under section: {section}!",
						$"Successfully found the error message: {item} for section: {section}");
				}
			}
			if (should == "should not")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsFalse(errorMessages.Contains(item.Trim()), $"The error message: {item} was displayed under section {section} when it should not be.",
						$"The error message: {item} was not displayed under section: {section} as expected", false, false);
				}
			}
			Report.Screenshot();
		}

		//[RegexStepDefinition(@"I enter the following into the comments field: (.*)")]
		public void ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(string text)
		{
			Report.IsTrue(new NewProduct().InputCommentAreaText(text), $"Text: {text} was not successfully inputted into the Optional Comments field!", $"Text: {text} was successfully inputted into the Optional Comments field!");
		}

		[RegexStepDefinition(@"I should be on the (.*) Page")]
		public void GivenIShouldBeOnXPage(string page)
		{
			var newProduct = new NewProduct();
			if (newProduct.WaitForContainerToBeVisible())
			{
				Report.IsTrue(newProduct.WaitForSection(page), $"{page} is not showing when it was expected to", $"{page} is showing as expected");
				return;
			}
			Report.Failure("New product page was not visible");
			Report.Screenshot();
		}

		[RegexStepDefinition(@"I click button: (.*)")]
		public void ClickButton(string button)
		{
			if (Report.IsTrue(new NewProduct().ButtonExists(button),
				$"Failed to find button {button}",
				$"Successfully found button {button}"))
			{
				Report.IsTrue(new NewProduct().ButtonClick(button),
				$"Failed to click button {button}",
				$"Successfully clicked button {button}");
			}
		}
		//[RegexStepDefinition(@"I click button: (.*)")]
		public void ClickButtonSave(string button)
		{
			if (Report.IsTrue(new NewProduct().ButtonSaveExists(button),
				$"Failed to find button {button}",
				$"Successfully found button {button}"))
			{
				Report.IsTrue(new NewProduct().ButtonSaveClick(button),
				$"Failed to click button {button}",
				$"Successfully clicked button {button}");
			}
		}

		[RegexStepDefinition(@"I confirm that I see the following (.*) value: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingCARBValue(string category, string expectedValue)
		{
			var newProductpage = new NewProduct();
			string foundValue = newProductpage.GetValueVOCSummary(category);
			Report.IsTrue(foundValue?.Trim() == expectedValue.Trim(),
				$"value was not as expected! Expected: {expectedValue}, but found: {foundValue}!",
				$"value was showing: {expectedValue}, as expected!");
		}
		[RegexStepDefinition(@"I confirm that the (.*) table (should|should not) exists")]
		public void ThenIConfirmThatTableExists(string tableName, string condition)
		{
			var newProductpage = new NewProduct();
			if (condition == "should")
			{
				Report.IsTrue(newProductpage.TableExists(tableName), $"Failed to confirm '{tableName}' table exists", $"Successsfully confirmed '{tableName}' table exists");
			}
			else
			{
				Report.IsFalse(newProductpage.TableExists(tableName), $"Failed to confirm '{tableName}' table does not exist", $"Successsfully confirmed '{tableName}' table does not exist");
			}
		}


		[RegexStepDefinition(@"Click the following button in the popup video: (.*) I click the (.*) button")]
		public void ClickTheFollowingButtonInThePopupView(string popupTitle, string buttonTitle)
		{
			Ingredients ingredientsObject = new Ingredients();
			Report.IsTrue(ingredientsObject.ClickTheFollowingButtonInThePopupView(popupTitle, buttonTitle), $"Failed to click the {buttonTitle} button", $"Successfully clicked the {buttonTitle} button");
			//Delay.Seconds(5);
			Delay.Seconds(1);
		}

		[RegexStepDefinition(@"I confirm the checkbox with the following text: (.*)")]
		public void CheckACheckboxWithTheFollowingText(string text)
		{
			Report.IsTrue(new Ingredients().CheckACheckboxWithTheFollowingText(text),
					$"Failed to check checkbox with the following text: '{text}'!",
					$"Successfully checked checkbox with the following text: '{text}'!");
			new Ingredients().CheckACheckboxWithTheFollowingText(text);
		}

		[RegexStepDefinition(@"I confirm the checkbox with description: (.*) (should|should not) be displayed")]
		public void IConfirmCheckboxWithDescriptionIsDisplayed(string description, string condition)
		{
			if (condition == "should")
			{
				Report.IsTrue(new NewProduct().StandaloneCheckbox(description) != null,
					$"Failed to confirm checkbox '{description}' is displayed!",
					$"Successfully confirmed checkbox '{description}' is displayed as expected");
			}
			else
			{
				Report.IsFalse(new NewProduct().StandaloneCheckbox(description) != null,
					$"Failed to confirm checkbox '{description}' is not displayed!",
					$"Successfully confirmed checkbox '{description}' is not displayed, as expected");
			}
		}
		//[RegexStepDefinition(@"I (check|uncheck) the checkbox with description: (.*)")]
		public void ICheckTheCheckboxWithDescription(string check, string description)
		{
			var selNewProduct = new NewProduct();
			bool toCheck = false;
			if (check == "check")
			{
				toCheck = true;
			}
			else if (check == "uncheck")
			{
				toCheck = false;
			}
			else
			{
				throw new Exception("Specflow paramater must be equal to 'check' or 'uncheck'");
			}
			bool isChecked = selNewProduct.StandaloneCheckbox(description).Checked();
			if (isChecked == toCheck)
			{
				Report.Success($"The checkbox was already {check}ed");
				return;
			}
			Report.IsTrue(selNewProduct.CheckStandaloneCheckbox(description),
				$"Failed to check the checkbox with description: '{description}'!",
				$"Successfully checked the checkbox with description: '{description}'");
			Report.IsTrue(selNewProduct.StandaloneCheckbox(description).Checked() == toCheck,
				$"The checkbox was not {check}ed after",
				$"The checkbox is {check}ed as expected");
		}
		[RegexStepDefinition(@"Confirm the checkbox with description: (.*) (is|is not) checked")]
		public void TheCheckboxWithDescriptionIsIsNotChecked(string description, string is_isnot)
		{
			bool expected = is_isnot == "is";
			bool isChecked = new NewProduct().StandaloneCheckbox(description).Checked();
			Report.IsTrue(isChecked == expected, $"Failed to confirm the checkbox with description: '{description} {(expected ? "is not" : "is")} checked'!", $"Successfully confirmed the checkbox with description: '{description}' {is_isnot} checked");
		}

		//[RegexStepDefinition(@"(.*) should be showing the value: (.*)")]
		public void CheckingFieldInputIsCorrect(string section, string value)
		{
			if (value.StartsWith("~saved as"))
			{
				string savedAs = value.Replace("~saved as", "").Trim();
				value = Context.GetFromContext(savedAs)?.ToString();
				if (value == null)
				{
					throw new Exception($"Could not find item in context: {savedAs} for checking field input is correct value!");
				}
			}
			List<string> showing = new NewProduct().SelectedOptionsForSection(section);
			Report.Info($"Value(s) showing were: {string.Join(", ", showing)}");
			var expected = value.Split('|').Select(x => x.Trim()).ToList();
			foreach (string expec in expected)
			{
				Report.IsTrue(showing.Contains(expec), $"Failed to find the selected value: {expec} in the section: {section}!", $"Successfully found {expec} in section: {section}", false, false);
			}
			Report.Screenshot();
		}

		[RegexStepDefinition(@"I confirm the pop up (should|should not) be displayed with the heading: (.*)")]
		public void ThenIConfirmThePopUpShowsTheHeading(string condition, string title)
		{
			if (condition == "should")
			{
				if (Report.IsTrue(new ModalDialog().WaitForContainerToBeVisible(), "The modal was not visible", "The modal was visible"))
				{
					string actualTitle = new ModalDialog().GetTitleH3();
					Report.IsTrue(actualTitle == title, $"Title is {actualTitle}, but should be: {title}",
						$"Title is showing as expected: {title}");
				}
			}
			else
			{
				Report.IsFalse(new ModalDialog().WaitForContainerToBeVisible(), "The modal is visible, but it is not expected", "The modal is not visible as expected");
			}
		}

		[RegexStepDefinition(@"In the Select Retailers modal, click the (.*) retailers option")]
		public void ClickRetailersOption(string option)
		{
			Report.IsTrue(new SelectRetailers().ClickRetailerOption(option) && GeneralUtilities.Wait_for_load_finish(), $"Failed to click the retailers option: {option}", $"Successfully clicked the retailers option: {option}");
		}

		[RegexStepDefinition("I (accept|dismiss) the alert pop up")]
		public void ConfirmThealertPopup(string action)
		{
			SeleniumWebDriver.CurrentDriver.WaitForAlert();

			if (action == "accept")
			{
				Report.Info("Accepting the pop up alert");
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Accept();
			}

			if (action == "dismiss")
			{
				Report.Info("Dismissing the pop up alert");
				SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Dismiss();
			}
		}

		[RegexStepDefinition(@"An alert (should|should not) be displayed with the message: (.*)")]
		public void AnAlertIsDisplayedWithTheMessage(string condition, string message)
		{
			if (condition == "should")
			{
				if (SeleniumWebDriver.CurrentDriver.IsAlertPresent())
				{
					string alertText = SeleniumWebDriver.CurrentDriver.SwitchTo().Alert().Text;
					Report.IsTrue(message == alertText, $"Alert text does not match! Expected: '{message}'. Actual: '{alertText}'.", "Successfully found text in alert!");
				}
				else
				{
					Report.Failure("Alert not present!");
				}
			}
			else
			{
				if (!SeleniumWebDriver.CurrentDriver.IsAlertPresent())
				{
					Report.Success("Alert is not displayed as expected");
				}
				else
				{
					Report.Failure("Alert still displayed when it is not expected");
				}
			}

		}

		[RegexStepDefinition(@"The following options (should|should not) be (displayed|exclusively displayed) for section: (.*)")]
		public void CheckOptionsInSection(string should, string exclusive, string section, Table expected)
		{
			var expectedOptions = new List<string>();
			List<string> displayedOptions = new List<string>();
			var differences = new List<string>();
			expected.Rows.Cast<TableRow>().ToList().ForEach(x => expectedOptions.Add(x["Option"]));
			var expectedOptionsLower = expectedOptions.Select(x => x.ToLower()).ToList();
			if (section == "Container Type")
			{
				displayedOptions = new NewProduct().GetAllOptionsForContainerTypeField();
			}
			else
			{
				displayedOptions = new NewProduct().GetAllOptionsForSection(section);
			}
			var displayedOptionsLower = displayedOptions.Select(x => x.ToLower()).ToList();
			if (exclusive == "displayed")
			{
				if (should == "should")
				{
					differences = expectedOptionsLower.Except(displayedOptionsLower).ToList();
					Report.IsTrue(expectedOptions.All(x => displayedOptionsLower.Contains(x.ToLower())),
						$"All expected options were not displayed under section: {section}. The differences were: {string.Join(", ", differences.Select(x => "'" + x + "'").ToList())}. The displayed options were: {string.Join(", ", displayedOptions)}",
						$"All expected options were displayed under section: {section} : {string.Join(", ", displayedOptions)}");
				}
				else if (should == "should not")
				{
					Report.IsTrue(!expectedOptionsLower.Any(x => displayedOptionsLower.Contains(x)),
						$"The following options were available for section: '{section}' when they were not expected!: '{string.Join(", ", expectedOptions)}'",
						$"The following options were not available for section: '{section}' as expected: {string.Join(", ", expectedOptions)}");
				}
			}
			else if (exclusive == "exclusively displayed")
			{
				Report.Info("Expected options to be displayed are:");
				foreach (string option in expectedOptions)
				{
					Report.Info(option);
				}
				bool allMatch = true;
				foreach (string displayedOption in displayedOptionsLower)
				{
					bool match = false;
					foreach (string expectedOption in expectedOptionsLower)
					{
						if (expectedOption != displayedOption)
						{
							continue;
						}
						match = true;
						break;
					}
					if (match)
					{
						continue;
					}
					allMatch = false;
					Report.Failure($"Option: {displayedOption} was displayed when it was not expected!");
					Report.Screenshot();
				}
				if (allMatch)
				{
					Report.Success($"The displayed options matched the expected options exactly for section: {section}");
					Report.Screenshot();
				}
			}
		}

		[RegexStepDefinition(@"In (.*) section, clear the textbox field with the placeholder value: (.*)")]
		public void ClearTextBoxField(string section, string placeholderValue)
		{
			if (Report.IsTrue(new NewProduct().ConfirmTextboxDisplayed(placeholderValue), $"Failed to locate a textbox under the section: {section}!", $"Successfully located a textbox under the section: {section}"))
			{
				Report.IsTrue(new NewProduct().ClearTextBox(placeholderValue), $"Failed to clear the textbox!", $"Successfully cleared the textbox!");
			}
		}


		[RegexStepDefinition(@"I (should|should only|should not) see the following sections")]
		public void CheckDisplayedSections(string condition, Table sections)
		{
			Report.Info($"Beginning I {condition} the following {sections}");
			var expectedSections = new List<string>();
			foreach (TableRow Row in sections.Rows)
			{
				expectedSections.Add(Row["Section"]);
			}
			var expectedNormalised = expectedSections.Select(x => x.Replace(" ", "")).ToList();
			var ActualSections = new NewProduct().GetDisplayedSections().Select(x => x).ToList();
			var actualNormalised = ActualSections.Select(x => x.Replace(" ", "")).ToList();
			Report.Info($"Actual sections: {string.Join(",", ActualSections)}");
			Report.Info($"Expected sections: {string.Join(",", expectedSections)}");
			if (condition == "should only")
			{
				var mismatch = new List<string>();
				foreach (string section in ActualSections)
				{
					if (!expectedSections.Contains(section))
					{
						mismatch.Add(section);
					}
				}
				Report.IsTrue(expectedSections.All(ActualSections.Contains) && expectedSections.Count == ActualSections.Count, $"The following sections were showing when they should not be: {string.Join("; ", mismatch)}", $"The only displayed sections were: '{string.Join("; ", ActualSections)}' as expected");
				return;
			}
			if (condition == "should")
			{
				Report.IsTrue(expectedSections.All(ActualSections.Contains), $"The displayed sections: '{string.Join("; ", ActualSections)}' did not match the expected sections: '{string.Join("; ", expectedSections)}'", $"The displayed sections: '{string.Join("; ", ActualSections)}' matched the expected sections");
				return;
			}
			if (condition == "should not")
			{
				Report.IsFalse(expectedSections.Any(ActualSections.Contains), $"Sections were showing which should not be. The sections not allowed are: {string.Join("; ", expectedSections)}. Actual sections: {string.Join("; ", ActualSections)}", $"Sections were not showing as expected: {string.Join("; ", expectedSections)}");
			}
		}


		[RegexStepDefinition(@"section: (.*) is highlighed in red indicating an error")]
		public void SectionIsHighlightedInRedIndicatingAnError(string section)
		{
			var selNewProduct = new NewProduct();
			string colour = selNewProduct.SectionColour(section);
			// Not the best. Will break if the exact shade changes (hex #A9443F, rgb 169, 68, 66) and verified it is intended
			string expected = "(62, 62, 62, 1)";
			Report.IsTrue(colour.Contains(expected),
				$"Section '{section}' colour was not the expected red! The colour is: {colour}",
				$"Section '{section}' colour was red as expected");
		}
		[RegexStepDefinition(@"In the (.*) section, confirm that the shadow text: '(.*)' is displayed in the textbox")]
		public void ShadowTextDisplayed(string section, string shadowText)
		{
			Report.IsTrue(new NewProduct().ConfirmTextboxDisplayed(shadowText), $"The shadow text: {shadowText}, was not displayed in the section: {section}!", $"The shadow text: {shadowText} was successfully displayed in section: {section}!");
		}

		[RegexStepDefinition(@"I navigate to the Home Page")]
		public void NavigateToTheHomePage()
		{
			try
			{
				Report.Info("Navigating to the Home Page");
				var selNav = new NavigationBar();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(selNav.Click_Icon("My Products"), "Failed to click the 'My Products' icon!", "Successfully clicked the 'My Products' icon!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[RegexStepDefinition(@"I (should|should not) see any error messages on the page")]
		public void NoErrorMessages(string condition)
		{
			var NewProduct = new NewProduct();

			List<string> errors = NewProduct.ErrorMessagesText;
			if (condition == "should")
			{
				if (!errors.Any())
				{
					Report.Success("As expected, the error message was not showing.");
					Report.Screenshot();
					return;
				}
			}
			else if (condition == "should not")
			{
				Report.Failure($"Error message was showing when it wasn't expected to! Error(s): {string.Join(", ", errors)}");
				Report.Screenshot();
			}
		}

		[RegexStepDefinition(@"I confirm I see the error message types in the popup with the following titles: (.*)")]
		public void ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle, Table table)
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CheckForTwoErrorMessagesInPopupWithTitle(table, popupTitle), "Failed to find all the error messages in popup with title " + popupTitle, "Successfully found all the error messages in popup with title " + popupTitle);
		}

		[RegexStepDefinition(@"I click close button for the CA Cleaning Ingredients Popup")]
		public void ThenIClickTheCloseButtonForThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow()
		{
			var newProductIngredients = new Ingredients();
			Report.IsTrue(newProductIngredients.CloseCACleaningIngredientsPopupWindow(), "Failed to click close button for popup", "Successfully clicked close button for popup");
		}
		[RegexStepDefinition(@"I confirm the pop up (should|should not) be displayed with the heading: (.*) and text: (.*)")]
		public void ThenIConfirmThePopUpShowsTheHeadingAndText(string condition, string title, string text)
		{
			if (condition == "should")
			{
				if (Report.IsTrue(new ModalDialog().WaitForContainerToBeVisible(), "The modal was not visible", "The modal was visible"))
				{
					string actualTitle = new ModalDialog().GetTitle();
					string actualText = new ModalDialog().GetText();

					if (Report.IsTrue(actualTitle == title, $"Title is {actualTitle}, but should be: {title}",
						$"Title is showing as expected: {title}"))
					{
						Report.IsTrue(actualText == text, $"The {title} popup did not display the correct message! Expected: '{text}' but found: '{actualText}'", $"The {title} popup was displayed correctly");
					}
				}
			}
			else
			{
				Report.IsFalse(new ModalDialog().WaitForContainerToBeVisible(), "The modal is visible, but it is not expected", "The modal is not visible as expected");
			}
		}
		[RegexStepDefinition(@"The statement: (.*) (is|is not) displayed")]
		public void ConfirmTextIsIsNotDisplayed(string text, string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new NewProduct().TextExistsOnThePage(text) == expected, $"Failure, failed to confirm the statement: '{text}' {is_isnot} displayed.", $"Success, confirmed the statement: '{text}' {is_isnot} displayed.");
		}
		[RegexStepDefinition(@"There are not any error messages displayed")]
		public void ThereAreNoErrorMessages()
		{
			new StepsNewProduct().NoErrorMessages();

		}

	}
}



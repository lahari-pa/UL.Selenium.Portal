using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.GenerateIntentionallyBadData;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit;
using UL.Automation.Utilities.Helpers;
using Mailosaur;
using ReportDetails = UL.Automation.Reporting.Classes.ReportDetails;
using System.IO;
using System.Drawing.Imaging;
using BoDi;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "StepsPrototype")]
	class Steps_Prototype
	{
		[StepDefinition(@"I set the radio option in section: (.*) to: (.*)")]
		public void SetRadioOptionInSectionTo(string section, string option)
		{
			Report.IsTrue(new NewProduct().SelectRadio(section, option),
				$"Failed to select radio option in section: '{section}' to option: '{option}'",
				$"Successfully set radio option: '{option}'");
		}

		[StepDefinition(@"I set the (.*) field to: (.*)")]
		[StepDefinition(@"I set the (.*) option to: (.*)")]
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
					throw new Exception($"Could not find item in context: { value } for checking field input is correct value!");
				}
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), value.Trim()),
					$"Failed to set the input to {value.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {value.Trim()} in section: { section.Trim()}");
				Delay.Seconds(1);
			}
			else
			{
				Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
					$"Failed to set the input to {option.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {option.Trim()} in section: {section.Trim()}");
				Delay.Seconds(1);
			}
		}

		public void ClickContinue()
		{
			Report.IsTrue(new NewProduct().ClickContinue(), "Failed to click 'Continue'!", "Clicked 'Continue' successfully");
		}

		public void ClickLinkElement(string linkText)
		{
			if (Report.IsTrue(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}"))
			{
				Report.IsTrue(new NewProduct().LinkElementClick(linkText), $"Failed to click link element with text {linkText}", $"Successfully clicked link element with text {linkText}");
			}
		}
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
				Report.IsFalse(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}");
			}
		}

		[StepDefinition(@"I switch to tab with url: (.*)")]
		public void ConfirmNewTabOpenWithUrl(string url)
		{
			new GlobalSteps().SwitchToTheTab(url);
		}

		[StepDefinition(@"I close the tab with url: (.*)")]
		public void CloseTabWithUrl(string url)
		{
			SeleniumBrowser.CloseTabWithURL(url);
			Report.IsTrue(!SeleniumBrowser.GetTabURLs().Contains(url), "Failed to close tab with URL: " + url, "Successfully closed tab with URL: " + url);
		}
		[StepDefinition(@"I confirm the tab (should|should not) exists with url: (.*)")]
		public void NewTabShouldExists(string condition, string url)
		{
			if (condition == "should")
			{
				Report.IsTrue(SeleniumBrowser.GetTabURLs().Contains(url), $"Failed to confirm new tab exists with url {url}", $"Successfully confirmed new tab exists with url {url}");
			}
			else
			{
				Report.IsTrue(!SeleniumBrowser.GetTabURLs().Contains(url), $"Failed confirm new tab does not exist with url {url}", $"Successfully confirmed new tab does not exist with url {url}");
			}
		}
		[StepDefinition(@"I confirm that a file is produced called (.*) and save as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
		{
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - Confirm File is downloaded with name: " + file);
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

		[StepDefinition("I compare the PDF: (.*) to the oracle PDF: (.*)")]
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

			try
			{
				// Define location to save comparison pdf to.
				string toCompareFile = Path.Combine(extractionFolder, "BILLS-114hr1321enr.pdf");
				Report.Info($"Saving comparison PDF file to: {toCompareFile}");
				FileInfo fileInfoDownloded = new FileInfo(toCompareResourceFile);
				fileInfoDownloded.MoveTo(toCompareFile);
				// Get from embedded resources.
				_ = EmbeddedResourceHelpers.ExtractToFile(toCompareResourceFile, studioAssembly, toCompareFile);

				// Define location to store saved images to.
				string compareImageFolder = Path.Combine(extractionFolder, "Images", "BILLS-114hr1321enr");
				Report.Info($"Extracting comparison images to: {compareImageFolder}_«PageNumber».png");

				// Extract page 'images' from PDF file.
				_ = PdfHelpers.ConvertPdfToImages(toCompareFile, compareImageFolder, out List<string> comparisonOutputFiles);

				// Define location to save oracle pdf to.
				string oracleFile = Path.Combine(extractionFolder, "HR1321.pdf");
				Report.Info($"Saving oracle PDF file to: {oracleFile}");
				FileInfo fileInfoOriginal = new FileInfo(oracleResourceFile);
				fileInfoOriginal.MoveTo(oracleFile);
				// Get from embedded resources.
				_ = EmbeddedResourceHelpers.ExtractToFile(oracleResourceFile, studioAssembly, oracleFile);

				// Define location to store saved images to.
				string oracleImageFolder = Path.Combine(extractionFolder, "Images", "HR1321");
				Report.Info($"Extracting oracle images to: {oracleImageFolder}_«PageNumber».png");

				// Extract page 'images' from PDF file.
				_ = PdfHelpers.ConvertPdfToImages(oracleFile, oracleImageFolder, out List<string> oracleOutputFiles);

				// Check to see if the page count is the same for both files.
				if (oracleOutputFiles.Count != comparisonOutputFiles.Count)
				{
					Report.Failure($"Expected to find: {oracleOutputFiles.Count} images, but found: {comparisonOutputFiles.Count} instead!");
				}
				else
				{
					// Iterate through each page.
					for (int i = 0; i < oracleOutputFiles.Count; i++)
					{
						Report.StartSubStep($"Checking Page: {i + 1}");

						// Define image paths for each image file.
						string oracleImagePath = oracleOutputFiles[i];
						string comparisonImagePath = comparisonOutputFiles[i];

						// Load each image file.
						Image oracleImage = Image.FromFile(oracleImagePath);
						Image comparisonImage = Image.FromFile(comparisonImagePath);

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
								Report.Image(oracleImage);

								// Report comparison image.
								Report.Info("Showing:");
								Report.Image(comparisonImage);

								// Report diff image.
								Report.Info("Difference:");
								Report.Image(diffImage);
							}
							else
							{
								// Matched successfully.
								Report.Success("Page matched successfully!", showScreenshot: false);

								// Report oracle image.
								Report.Image(oracleImage);
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

		

	}
}

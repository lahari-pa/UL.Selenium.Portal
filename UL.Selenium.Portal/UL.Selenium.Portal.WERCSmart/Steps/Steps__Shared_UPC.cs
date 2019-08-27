using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using System.Collections.ObjectModel;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.UPC;
using NTTQA.Selenium.UniversalFunctions;
using System.Text.RegularExpressions;
using System.Collections;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "UPC")]
	class StepsUPC
	{

		[StepDefinition(@"I click the 'Add Case UPC' button")]
		[StepDefinition(@"in the UPC Window, I click the Add Case UPC button")]
		public void ThenIClickTheAddCaseUpcButton()
		{
			Report.IsTrue((new UPC()).ClickAddCaseUpcButton(), "Failed to click the 'Add Case UPC' button!", "Successfully clicked the 'Add Case UPC' button");
		}

		[StepDefinition(@"I should (see|not see) the following UPC options:")]
		public void ShouldSeeTheUPCOptions(string condition, Table expected)
		{
			var selNewProduct = new UPC();
			List<string> upcOptions = selNewProduct.GetUPCOptions();
			if (condition == "see")
			{
				foreach (TableRow row in expected.Rows)
				{
					string option = row["Option"];
					Report.Info("Checking that I see the option '" + option + "'");
					Report.IsTrue(upcOptions.Contains(option.Trim()),
						"Option was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", upcOptions) + "'!",
						"Option was showing: '" + option + "', as expected!");
				}
			}
			if (condition == "not see")
			{
				foreach (TableRow row in expected.Rows)
				{
					string option = row["Option"];
					Report.Info("Checking that I do not see the option '" + option + "'");
					Report.IsFalse(upcOptions.Contains(option.Trim()),
						"Options were showing which should not be. The sections not allowed are: " + string.Join("; ", option) + ". Actual sections: " + string.Join("; ", option), "Sections were not showing as expected: " + string.Join("; ", option));
				}
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I should see the (.*) Page")]
		[StepDefinition(@"in the UPC Window, I should see the (.*) Page")]
		public void GivenIShouldSeeXPage(string page)
		{
			var selNewProduct = new UPC();
			Report.IsTrue(selNewProduct.WaitForSection(page),
				page + " is not showing when it was expected to",
				page + " is showing as expected");
			Report.Screenshot();
		}

		[StepDefinition(@"I add the following into the UPC case fields")]
		public void ThenIAddTheFollowingIntoTheUpcFields(Table table)
		{
			UpcCaseInformation upcInfo = table.CreateInstance<UpcCaseInformation>();
			Report.Info("UPC Number: " + upcInfo.UpcNumber);
			Report.Info("Container Type: " + upcInfo.ContainerType);
			Report.Info("Size: " + upcInfo.Size);
			Report.Info("Quantity: " + upcInfo.Quantity);
			Report.Info("Individual Upc Case Pack: " + upcInfo.IndividualUpcCasePack);
			Report.Info("Transportation Options: " + upcInfo.TransportationOption);

			Report.IsTrue(new UPC().InputUpcCaseInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");
		}


		[StepDefinition(@"I call Shared Step 87641\(Enter Universal Product Code - case information\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and Quantity: (.*) and Transportation option: (.*)")]
		public void UPCCaseInformation(string upc, string containerType, string size, string quantity, string transportation)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsUPC();
			var MyStepsProduct = new StepsNewProduct();
			//TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add Case UPC' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcCaseInformation {
					ContainerType = containerType,
					Size = size,
					Quantity = quantity,
					TransportationOption = transportation,
					UpcNumber = upc_
				};
				Report.IsTrue(new UPC().InputUpcCaseInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				upcTable.AddRow("Quantity", quantity);
				upcTable.AddRow("TransportationOption", transportation);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 87641 \(Enter Universal Product Code - case information\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and Quantity: (.*) and Associated UPC: (.*) and Transportation option: (.*)")]
		public void UPCCaseInformationWithAssociatedUPC(string upc, string containerType, string size, string quantity, string assocUPC, string transportation)
		{
			TestReport.UseSubSteps = true;
			StepsUPC MyStepsNewProduct = new StepsUPC();
			StepsNewProduct MyStepsProduct = new StepsNewProduct();
			//TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add Case UPC' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				var upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcCaseInformation {
					ContainerType = containerType,
					Size = size,
					Quantity = quantity,
					TransportationOption = transportation,
					IndividualUpcCasePack = assocUPC,
					UpcNumber = upc_
				};
				Report.IsTrue(new UPC().InputUpcCaseInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				Table upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				upcTable.AddRow("Quantity", quantity);
				upcTable.AddRow("IndividualUpcCasePack", "saved as " + assocUPC);
				upcTable.AddRow("TransportationOption", transportation);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}


		[StepDefinition(@"I call Shared Step 87647 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) do not click continue")]
		public void EnterUPCInfoDoNotClickContinue(string upc, string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
		}


		[StepDefinition(@"I call Shared Step 87658 \(Enter Universal Product Code \(UPC\)\) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and quantity: (.*) do not click continue")]
		public void UpcWithQuantityDoNotClickContinue(string upc, string containerType,
			string size, string quantity)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			//TestReport.StartStep("I confirm 'Quantity' is visible in the UPC header");
			//MyStepsNewProduct.ConfirmQuantityIsVisibleInUPCHeader();
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			var upcTable = new Table(new string[] {
				"Field",
				"Value"
			});
			upcTable.AddRow(new string[] {
				"UPCNumber",
				"saved as UPC" + upc
			});
			upcTable.AddRow(new string[] {
				"ContainerType",
				containerType
			});
			upcTable.AddRow(new string[] {
				"Size",
				size
			});
			upcTable.AddRow(new string[] {
				"Quantity",
				quantity
			});
			TestReport.StartStep("I add the following into the UPC Fields");
			MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
		}

		[StepDefinition(@"I should see lithium battery message: (.*)")]
		public void ThenIShouldSeeBatteryMessage(string message)
		{
			Report.Info("Checking error message");
			var selNewUpc = new UPC();
			string found = selNewUpc.LithiumBatteyWarning();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Warning message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Warning message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I should see maximum upc limit message: (.*)")]
		public void MaximumUpcLimitMessage(string message)
		{
			Report.Info("Checking error message");
			var selNewUpc = new UPC();
			string found = selNewUpc.MaximumLimitUpcWarning();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Warning message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Warning message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I should (see|not see) the following UPC buttons:")]
		public void UpcButtonsDisplay(string condition, Table expected)
		{
			Delay.Seconds(1);
			var selNewProduct = new UPC();
			List<string> upcButtons = selNewProduct.GetUPCbuttons();
			if (condition == "see")
			{
				foreach (TableRow row in expected.Rows)
				{
					string option = row["Option"];
					Report.Info("Checking that I see the option '" + option + "'");
					Report.IsTrue(upcButtons.Contains(option.Trim()),
						"Option was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", upcButtons) + "'!",
						"Option was showing: '" + option + "', as expected!");
				}
			}
			if (condition == "not see")
			{
				foreach (TableRow row in expected.Rows)
				{
					string option = row["Option"];
					Report.Info("Checking that I do not see the option '" + option + "'");
					Report.IsFalse(upcButtons.Contains(option.Trim()),
						"Options were showing which should not be. The sections not allowed are: " + string.Join("; ", option) + ". Actual sections: " + string.Join("; ", option), "Sections were not showing as expected: " + string.Join("; ", option));
				}
			}
			Report.Screenshot();
		}


		[StepDefinition(@"I switch to tab: (.*)")]
		public void ThenISwitchToDataAcceptancePage(string option)
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//title"), 2) != null)
				{
					Report.Success("Tab was switched successfully!");
					return;
				}
			}
			Report.Failure("Failed to find the correct tab!");
		}

		[StepDefinition(@"I call Shared Step\(Enter Universal Product Code - case information\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and Quantity: (.*) and Transportation option: (.*) do not click continue")]
		public void UPCCaseInformationDonotClickContinue(string upc, string containerType, string size, string quantity, string transportation)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsUPC();
			var MyStepsProduct = new StepsNewProduct();
			//TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add Case UPC' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcCaseInformation {
					ContainerType = containerType,
					Size = size,
					Quantity = quantity,
					TransportationOption = transportation,
					UpcNumber = upc_
				};
				Report.IsTrue(new UPC().InputUpcCaseInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				upcTable.AddRow("Quantity", quantity);
				upcTable.AddRow("TransportationOption", transportation);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
		}

		[StepDefinition(@"I confirm that UPC page contains link for: (.*)")]
		public void IConfirmUPCContains(string labelLink)
		{
			var uPCpage = new UPC();
			List<string> labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsTrue(labelLinksShowing.Contains(labelLink), "The link with text: '" + labelLink + "' was not found on the upc page", "The link with text: '" + labelLink + "' was found on the upc page as expected");
		}


		[StepDefinition(@"(.*) (should|should not) be showing the error messages on upc screen: (.*)")]
		public void ErrorMessagesAreShowingOnUpc(string section, string should, string pipeDelimitedErrorMessages)
		{
			Delay.Seconds(1);
			string[] errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			List<string> errorMessages = new UPC().GetUPCErrorsForSection(section);
			Report.Info("Error messages showing are: " + string.Join(", ", errorMessages));
			if (should == "should")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsTrue(errorMessages.Any(e => e.Contains(item)),
						"Failed to find the error message: " + item + " under section: " + section + "!",
						"Successfully found the error message: " + item + " for section: " + section, false, false);
				}
			}
			if (should == "should not")
			{
				foreach (string item in errorMessagesExpected)
				{
					Report.IsFalse(errorMessages.Contains(item.Trim()),
						"The error message: " + item + " was displayed under section" + section + " when it should not be.",
						"The error message: " + item + " was not displayed under section: " + section + " as expected", false, false);
				}
			}
			Report.Screenshot();
		}


		[StepDefinition(@"I call Shared Step 87647 \(UPC - Confirm Package type Link and field shown and required \) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) click continue")]
		public void EnterUPCInfoConfirmPackagingTypeLinkAndError(string upc, string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyStepsUpc = new StepsUPC();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			var uPCpage = new UPC();
			TestReport.StartStep("I confirm Add new Packaging Type link");
			List<string> labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsTrue(labelLinksShowing.Contains("Add new Packaging Type"), "The link with text: Add new Packaging Type was not found on the upc page", "The link with text: Add new Packaging Type was found on the upc page as expected");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
			Delay.Seconds(1);
			TestReport.StartStep("Confirm error message!");
			string pipeDelimitedErrorMessages = "This is a required field.";
			string[] errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			List<string> errorMessages = new UPC().GetUPCErrorsForSection("Package Type");
			foreach (string item in errorMessagesExpected)
			{
				Report.IsTrue(errorMessages.Any(e => e.Equals(item)),
					"Failed to find the error message",
					"Successfully found the error message");
			}
		}


		[StepDefinition(@"I call Shared Step 85909 \(UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) click continue")]
		public void EnterUPCInfoConfirmPackagingTypeLinkdoesNotExists(string upc, string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyStepsUpc = new StepsUPC();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			var uPCpage = new UPC();
			TestReport.StartStep("I confirm Add new Packaging Type link does not display");
			List<string> labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsFalse(labelLinksShowing.Contains("Add new Packaging Type"), "Add new Packaging Type link was found on the upc page, it should not have been", "Add new Packaging Type was not found on the upc page as expected");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I should not see Package Type option");
			List<string> upcOptions = uPCpage.GetUPCOptions();
			Report.IsFalse(upcOptions.Contains("Package Type"),
				"option was displayed which should not have been", "option did not displayed as expected");
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}

		[StepDefinition(@"I Select a package type from the drop down list")]
		public void GivenISelectAPackagerTypeFromTheDropDownList()
		{
			List<string> upcOptions = new NewProduct().GetPackageOptions();
			var random = new Random();
			int randomNumber = random.Next(1, upcOptions.Count - 1);
			Report.IsTrue(new NewProduct().SelectPackageType(upcOptions[randomNumber]),
				"Failed to select: " + upcOptions[randomNumber], "Selected: " + upcOptions[randomNumber]);
		}

		// Enter UPC string in the form: "Equals"+upcNumber where upcNumber is the exact number to input, rather than using the randomly generated step from context
		// Enter '_CVS' or '_cvs' for upc variable to use a upc number for retailer CVS from (required for some test cases eg. CVS RCL feature)
		[StepDefinition(
			@"I enter information for Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC(.*), container type: (.*) and size: (.*) - do not click continue")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc,
			string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
			}
			else
			{
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
		}

		[StepDefinition(@"I should see the following error text displayed in the UPC screen: (.*)")]
		public void IShouldSeeTheFollowingErrorTextDisplayedInTheUPCScreen(string text)
		{
			var upcPage = new UPC();
			string errorText = GeneralUtilities.StripSpecialChars(upcPage.GetErrorText());
			text = GeneralUtilities.StripSpecialChars(text);
			Report.IsTrue(errorText.Contains(text), "Failed to find correct error message in the UPC screen. Expected: " + text + ". But instead found: " + errorText + ".",
				"Successfully found correct error message in the UPC screen.");

		}

		[StepDefinition(@"I click the 'Upload UPCs' button and upload the file saved as: (.*)")]
		public void ThenIClickTheUploadUpcsButtonAndUploadSavedAs(string savedAs)
		{
			TestReport.UseSubSteps = true;
			var excelFile = Context.GetFromContext(savedAs).ToString();

			if (excelFile == null)
			{
				Report.Failure("The UPC spreadsheet could not be found");
				return;
			}

			TestReport.StartStep("I click the 'Upload UPC' button");
			Report.IsTrue((new UPC()).ClickUploadUpcButton(), "Failed to click the 'Upload UPC' button!", "Successfully clicked the 'Upload UPC' button");
			TestReport.StartStep($"I Upload the file saved as {savedAs}");
			Report.IsTrue(GeneralFunctions.EnterFilename(excelFile), "Failed to enter file name!", "Successfully entered file name");

		}

		[StepDefinition(@"In the Add Multiple dialog box I select all UPCs")]
		public void InTheAddMultipleDialogBoxSelectAllUpcs()
		{
			Report.IsTrue(new MultipleUPC().ClickSelectAllUpcsButton(), "The select all Upcs button was not clicked successfully", "The select all Upcs button was clicked successfully");

		}

		[StepDefinition(@"I confirm that the Add Multiple UPC window opens")]
		public void IConfirmThatTheAddMultipleUPCWindowOpens()
		{
			Report.IsTrue(new MultipleUPC().WaitForContainerToBeVisible(30), "The Add Multiple UPC windows did appear", " The Add Multiple UPC window did appear");
		}

		[StepDefinition(@"I confirm that the Add Multiple UPC window closes")]
		public void IConfirmThatTheAddMultipleUPCWindowCloses()
		{
			Report.IsTrue(new MultipleUPC().WaitForContainerToBeInvisible(30), "The Add Multiple UPC windows did not close", " The Add Multiple UPC window was closed");
		}




		[StepDefinition(@"In the Add Multiple dialog box I select the packaging type: (.*)")]
		public void InTheAddMultipleDialogBoxSelectPackagingTypeX(string packagingType)

		{
			var containsTypeOptionBox = new MultipleUPC().ContainsType;


			if (packagingType == "<first>")
			{
				var firstOption = containsTypeOptionBox.FindElement(By.XPath("./option[not(text()='Choose...')]"), 1).Text;

				if (firstOption == null)
				{
					Report.Failure("There are no Container Types");
					return;
				}
				else
				{
					Context.AddToContext("AddMultipleDialogFirstContainerOption", firstOption);
					containsTypeOptionBox.Select(firstOption);
				}

			}
			else
			{
				containsTypeOptionBox.Select(packagingType);
			}
		}

		[StepDefinition(@"In the Add Multiple dialog box I click Next")]
		public void InTheAddMultipleDialogBoxClickNext()
		{

			Report.IsTrue(new MultipleUPC().ClickNextButton(), "Failed To click the Next button", "Successfully clicked the next button");
		}

		[StepDefinition(@"In the Add Multiple dialog box I select all Retailers")]
		public void InTheAddMultipleDialogBoxSelectAllRetailers()
		{
			Report.IsTrue(new MultipleUPC().ClickSelectAllRetailersButton(), "The select all Retailers button was not clicked successfully", "The select all Retailers button was clicked successfully");
		}

		[StepDefinition(@"In the Add Multiple dialog box I click Finish")]
		public void InTheAddMultipleDialogBoxClickFinish()
		{

			Report.IsTrue(new MultipleUPC().ClickFinishButton(), "Failed To click the Finish button", "Successfully clicked the Finish button");
		}

		[StepDefinition(@"I check that the UPC Number of each product matches the excel file named: (.*) uploaded saved as: (.*)")]
		public void ICheckUPCNumberOfEachProductFromFile(string file, string savedAs)
		{
			Report.IsTrue(new MultipleUPC().CheckUPCNumberOfEachProductFromFile(file, savedAs), "The UPC numbers shown in the Add Multiple Popup did not match the file", "The UPC numbers shown in the Add Multiple Popup matched the file");

		}

		[StepDefinition(@"I check that the Size of each product matches the excel file named: (.*) uploaded saved as: (.*)")]
		public void ICheckSizeOfEachProductFromFile(string file, string savedAs)
		{
			Report.IsTrue(new MultipleUPC().CheckSizeOfEachProductFromFile(file, savedAs), "The Size shown in the Add Multiple Popup did not match the file", "The Size shown in the Add Multiple Popup matched the file");

		}

		[StepDefinition(@"I Check that all UPCs are selected")]
		public void ICheckAllUPCsAreSelected()
		{
			Report.IsTrue(new MultipleUPC().CheckAllUPCsAreSelected(), "The Size shown in the Add Multiple Popup did not match the file", "The Size shown in the Add Multiple Popup matched the file");
		}
		[StepDefinition(@"I Check if all Retailers are: (Selected|Not Selected)")]
		public void ICheckAllRetailersSelectedStatus(string status)
		{
			if (status == "Selected")
			{
				Report.IsTrue(new MultipleUPC().CheckAllRetailersSelectedStatus(), "All retailers were not selected", "All Retailers were selected");
			}
			if (status == "Not Selected")
			{
				Report.IsFalse(new MultipleUPC().CheckAllRetailersSelectedStatus(), "All Retailers were selected", "All retailers were not selected");
			}
		}

		[StepDefinition(@"I edit the testdoc.xlsx, and save its filepath as: (.*) and verify it contains the UPC data in the table saved as: (.*)")]
		public void GivenICreateANewFileSavedAsAndVerifyUsingTheUPCsSavedAs(string fileSavedAs, string tableSavedAs, Table table)
		{
			Context.AddToContext(tableSavedAs, table);

			var upc = new UPC();
			Report.IsTrue(upc.DeleteFileFromDownloadsFolder("testdoc.xlsx"), "", "");
			//Create file here
			//var excelfile = new ExcelUtilities CreateSpreadsheet(fileName);

			//var utils = ExcelUtilities.CreateSpreadsheet(Path.Combine(KnownFolders.GetPath(KnownFolder.Downloads), fileName));
			EmbeddedResources.ExtractToFile("UL.Selenium.Portal.WERCSmart.Dependencies.Excel.testdoc.xlsx", out string destination);

			var utils = new ExcelUtilities(destination, "Sheet1");


			var headers = table.Rows.FirstOrDefault().Keys.ToList();
			utils.AddRow(headers);
			foreach (var row in table.Rows)
			{
				var vals = row.Values.Select(x =>
				{
					if (Regex.IsMatch(x, "<(.*)>"))
					{
						var match = Regex.Match(x, "<(.*)>").Groups[1].Value;
						if (Context.Contains(match, true))
						{
							return Context.GetFromContext(match).ToString();
						}
					}

					return x;
				});

				utils.AddRow(vals.ToList());
			}
			//add all rows from table to excelfile


			System.IO.Directory.Move(destination, KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx");


			Report.IsTrue(upc.VerifySampleFile(table, "testdoc.xlsx", fileSavedAs), "Failed to validate File", "Successfully validated File");


		}

		[StepDefinition(@"I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: (.*)")]
		public void IConfirmAddMultipleUPCPopupAppearsAndValuesAreTheSame(string tableSavedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I confirm the Add Multiple UPC popup appears");
			this.IConfirmThatTheAddMultipleUPCWindowOpens();
			TestReport.StartStep("I confirm the UPC numbers and sizes are the same as the upload document");
			var listDisplayedUPCs = new MultipleUPC().UPCUploads;
			if (Context.Contains(tableSavedAs))
			{
				var tableContent = (Table)Context.GetFromContext(tableSavedAs);
				int i = 0;

				bool successIsTrue = true;
				foreach (var row in tableContent.Rows)
				{
					var upcNumber = row["UPC"];

					var size = row["Size"];

					var displayedSize = listDisplayedUPCs[i].Size;

					if (Regex.IsMatch(upcNumber, "<(.*)>"))
					{
						var match = Regex.Match(upcNumber, "<(.*)>").Groups[1].Value;
						if (Context.Contains(match, true))
						{
							upcNumber = Context.GetFromContext(match).ToString();
						}
					}

					var displayedUpcNumber = listDisplayedUPCs[i].UpcNumber;

					if (displayedUpcNumber != upcNumber)
					{
						Report.Failure("The Value for UPC number did not match. The displayed value was: " + displayedUpcNumber + ". The UPC number in the document was: " + upcNumber + ".");
						successIsTrue = false;
					}

					if (displayedSize != size)
					{
						Report.Failure("The Value for size did not match. The displayed value was: " + displayedSize + ". The Size in the document was: " + size + ".");
						successIsTrue = false;
					}


					i++;
				}

				Report.IsTrue(successIsTrue, "Not all Values matched the UPC upload document", "All Values matched the UPC upload document");
				return;


			}

			Report.Failure("The table " + tableSavedAs + " was not found in context");



		}

		[StepDefinition("I Confirm All UPCs are: (Selected|Not Selected)")]
		public void IConfirmAllUpcAreSelected(string selectedStatus)
		{
			bool setStatus;
			switch (selectedStatus)
			{
				case "Selected":
					setStatus = true;
					break;

				case "Not Selected":
					setStatus = false;
					break;
				default:
					Report.Error("selectedStatus must be either: 'Selected' or 'Not Selected'");
					return;
			}


			var listDisplayedUPCs = new MultipleUPC().UPCUploads;
			bool successIsTrue = true;

			for (int i = 0; i <= listDisplayedUPCs.Count - 1; i++)
			{
				var displayedChecked = listDisplayedUPCs[i].IsChecked;
				if (displayedChecked != setStatus)
				{
					Report.Failure("The UPC with number: " + listDisplayedUPCs[i].UpcNumber + " was not shown as " + selectedStatus + ".");
					successIsTrue = false;
				}
			}

			Report.IsTrue(successIsTrue, "Not all UPCS were shown as" + selectedStatus + ".", "All UPCS were shown as" + selectedStatus + ".");
			return;

		}

		[StepDefinition(@"I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: (.*)")]
		public void IConfirmAddMultipleUPCPopupDisappearssAndValuesAreTheSame(string tableSavedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I confirm the Add Multiple UPC popup dissappears");
			this.IConfirmThatTheAddMultipleUPCWindowCloses();
			TestReport.StartStep("I confirm the UPC numbers and sizes are the same as the upload document");
			var listDisplayedUPCs = new UPC().UPCsNewProduct;
			if (Context.Contains(tableSavedAs))
			{
				var tableContent = (Table)Context.GetFromContext(tableSavedAs);
				int i = 0;

				bool successIsTrue = true;
				foreach (var row in tableContent.Rows)
				{
					var upcNumber = row["UPC"];

					var size = row["Size"];

					var displayedSize = listDisplayedUPCs[i].Size;

					if (Regex.IsMatch(upcNumber, "<(.*)>"))
					{
						var match = Regex.Match(upcNumber, "<(.*)>").Groups[1].Value;
						if (Context.Contains(match, true))
						{
							upcNumber = Context.GetFromContext(match).ToString();
						}
					}

					var displayedUpcNumber = listDisplayedUPCs[i].UpcNumber;

					if (displayedUpcNumber != upcNumber)
					{
						Report.Failure("The Value for UPC number did not match. The displayed value was: " + displayedUpcNumber + ". The UPC number in the document was: " + upcNumber + ".");
						successIsTrue = false;
					}

					if (displayedSize != size)
					{
						Report.Failure("The Value for size did not match. The displayed value was: " + displayedSize + ". The Size in the document was: " + size + ".");
						successIsTrue = false;
					}


					i++;
				}

				Report.IsTrue(successIsTrue, "Not all Values matched the UPC upload document", "All Values matched the UPC upload document");
				return;


			}

			Report.Failure("The table " + tableSavedAs + " was not found in context");


		}

		[StepDefinition(@"I Confirm that the Add/Upload UPC Buttons remain stay visible when scrolling up and down the page")]
		public void IConfirmUPCButtonsRemainVisibleWhenScrolling()
		{
			TestReport.UseSubSteps = true;
			var upc = new UPC();
			TestReport.StartStep("Looking for the UPC Buton Container anywhere on the page");
			if (upc.UPCButtonContainerGeneral == null)
			{
				Report.Failure("The UPC Buttons could not be found on anywhere page");
				Report.Screenshot();
				return;
			}
			Report.Success("The UPC Button container was found");
			Report.Screenshot();
			bool allFound = true;
			if (!upc.AddUpcButton())
			{
				Report.Failure("The Add UPC Button was not found");
				Report.Screenshot();
				allFound = false;
			}
			if (!upc.AddCaseUpcButton())
			{
				Report.Failure("The Add Case UPC Button was not found");
				Report.Screenshot();
				allFound = false;
			}
			if (!upc.UploadUpcButton())
			{
				Report.Failure("The Upload UPCs Button was not found");
				Report.Screenshot();
				allFound = false;
			}

			if (allFound)
			{
				Report.Success("The UPC Buttons (+Add UPC, + Add Case UPC, & ↑ Upload UPCs were all found");
				Report.Screenshot();
			}

			TestReport.StartStep("I Scroll to the top of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToTopOfPage();
			bool buttonsFound = true;
			if (upc.UPCButtonContainerTop == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}
			TestReport.StartStep("I Scroll to the bottom of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToBottomOfPage();
			if (upc.UPCButtonContainerBottom == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}
			TestReport.StartStep("I Scroll to the top of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToTopOfPage();
			if (upc.UPCButtonContainerTop == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}
			TestReport.StartStep("I Scroll to the bottom of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToBottomOfPage();
			if (upc.UPCButtonContainerBottom == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}

			if (!buttonsFound)
			{
				Report.Failure("The UPC Buttons do not remain on screen when scrolling up and down the page");
				return;
			}
			Report.Success("The UPC Buttons remain on screen when scrolling up and down the page");

		}

		[StepDefinition(@"I Check that the type coloumn becomes populated with option: (.*)")]
		public void ICheckTypeColoumnContiansFirstOption(string packagingType)
		{
			var containsTypeOptionBox = new MultipleUPC().ContainsType;


			var displayedOption = containsTypeOptionBox.SelectedOption();

			if (packagingType == "<first>")

			{
				var chosenOption = (string)Context.GetFromContext("AddMultipleDialogFirstContainerOption");

				Report.IsTrue(chosenOption == displayedOption, "The Displayed container type did not match the type selected. Selected: " + chosenOption + ". The Displayed container type was: " + displayedOption + ".", "The Contianer types was correctly populated with the selected option");

				//if (containerOption!=selectedOption)
				//{
				//	Report.Failure("The Displayed container type did not match the type selected. Selected: "+containerOption+ ". The Displayed container type was: "+displayedOption+ ".");
				//	return;
				//}
				//Report.Success("The Contianer types was correctly populated with the selected option");
				//return;

			}
			else
			{

				Report.IsTrue(packagingType == displayedOption, "The Displayed container type did not match the type selected. Selected: " + displayedOption + ". The Displayed container type was: " + displayedOption + ".", "The Contianer types was correctly populated with the selected option");

				//if (packagingType!= displayedOption)
				//{
				//	Report.Failure("The Displayed container type did not match the type selected. Selected: " +packagingType+ ". The Displayed container type was: " +displayedOption+ ".");
				//	return;
				//}
				//Report.Success("The Contianer types was correctly populated with the selected option");
				//return;
			}



		}

		[StepDefinition(@"I make a list of the duplicated UPCs and save it as: (.*) from the table saved as: (.*)")]
		public void IMakeAListOfDuplicateUPCsFromTable(string duplicateListSavedAs, string tableSavedAs)
		{
			var tableContent = (Table)Context.GetFromContext(tableSavedAs);
			List<string> UPCCheckList = new List<string>();
			//List<string> duplicateUPCList = new List<string>();

			Hashtable duplicateUPCHashTable = new Hashtable();

			int i = 0;
			foreach (var row in tableContent.Rows)
			{
				var upcNumber = row["UPC"];

				if (Regex.IsMatch(upcNumber, "<(.*)>"))
				{
					var match = Regex.Match(upcNumber, "<(.*)>").Groups[1].Value;
					if (Context.Contains(match, true))
					{
						upcNumber = Context.GetFromContext(match).ToString();
					}
				}

				if (!UPCCheckList.Contains(upcNumber))
				{
					UPCCheckList.Add(upcNumber);
				}
				else
				{
					if (duplicateUPCHashTable.ContainsKey(upcNumber))
					{
						int old = (int)duplicateUPCHashTable[upcNumber];
						duplicateUPCHashTable[upcNumber] = old + 1;
					}
					else
					{
						duplicateUPCHashTable.Add(upcNumber, 1);
					}

				}

				//if (!UPCCheckList.Contains(upcNumber))
				//{
				//	/UPCCheckList.Add(upcNumber);
				//	
				//}
				//else
				//{
				//	duplicateUPCList.Add(upcNumber);
				//	
				//}

			}




			//Context.AddToContext(duplicatesSavedAs, duplicateUPCList);
			Context.AddToContext(duplicateListSavedAs, duplicateUPCHashTable);
		}


		[StepDefinition(@"I make a list of the duplicated UPCs including unique duplicated UPCs starting with: (.*) and save it to a hashtable as: (.*) from the table saved as: (.*)")]
		public void IMakeAListOfDuplicateUPCsFromTableIncludingUPCSStartingWithX(string exisitingDuplicateUPCsSavedAs, string duplicateListSavedAs, string tableSavedAs)
		//Needed if duplicated UPC list included replicated upcs and Unique duplicate UPCS in combination
		{
			var tableContent = (Table)Context.GetFromContext(tableSavedAs);
			List<string> UPCCheckList = new List<string>();
			//List<string> duplicateUPCList = new List<string>();

			Hashtable duplicateUPCHashTable = new Hashtable();

			int i = 0;
			foreach (var row in tableContent.Rows)
			{
				var upcNumber = row["UPC"];

				if (Regex.IsMatch(upcNumber, "<(.*)>"))
				{
					var match = Regex.Match(upcNumber, "<(.*)>").Groups[1].Value;
					if (Context.Contains(match, true))
					{
						upcNumber = Context.GetFromContext(match).ToString();
					}
				}

				if (!UPCCheckList.Contains(upcNumber))
				{
					UPCCheckList.Add(upcNumber);
				}
				else
				{
					if (duplicateUPCHashTable.ContainsKey(upcNumber))
					{
						int old = (int)duplicateUPCHashTable[upcNumber];
						duplicateUPCHashTable[upcNumber] = old + 1;
					}
					else
					{
						duplicateUPCHashTable.Add(upcNumber, 2);
					}

				}

				//if (!UPCCheckList.Contains(upcNumber))
				//{
				//	/UPCCheckList.Add(upcNumber);
				//	
				//}
				//else
				//{
				//	duplicateUPCList.Add(upcNumber);
				//	
				//}

			}

			int j = 1;
			while (Context.Contains(exisitingDuplicateUPCsSavedAs + j))
			{
				var valueToAdd = Context.GetFromContext(exisitingDuplicateUPCsSavedAs + j);
				duplicateUPCHashTable.Add(valueToAdd, 1);
				j++;
			}



			//Context.AddToContext(duplicatesSavedAs, duplicateUPCList);
			Context.AddToContext(duplicateListSavedAs, duplicateUPCHashTable);
		}




		[StepDefinition(@"I use a list of duplicated UPCs saved as: (.*) and check that they have a warning traingle next to their retailer code and save the ones that do as: (.*)")]
		public void IMakeAListOfDuplicateUPCsAndCheckForWarning(string duplicateUPCsSavedAs, string upcsWithWarningSavedAs)
		{


			//get from context this ^ list

			//for each item in the list, search the UPC grid for the element of the warning triangle and check if ==null or not.  (this method will take the upc number and find corrosponging location for triangle)>could be done in the class for this list (have bool warningPresent and get it using is present or false as default etc).

			TestReport.UseSubSteps = true;
			TestReport.StartStep("I confirm the Add Multiple UPC popup disappears");
			this.IConfirmThatTheAddMultipleUPCWindowCloses();
			TestReport.StartStep("I make a list of the UPCS that have duplicates");
			//method in upc.cs that checks the warning text and gets all duplicated upc numbers from it as a string and adds them to a list (savedAs) //doesnt work with current error message
			//List<string> duplicateUPCStrings = new List<string>(); //make =^
			TestReport.StartStep("I confirm the UPCs wich are duplicates have have a warning traingle next to their retailer code");

			var duplicateUPCStrings = (Hashtable)Context.GetFromContext(duplicateUPCsSavedAs);
			List<UPCNewProduct> listDisplayedUPCs = new UPC().UPCsNewProduct;
			Hashtable upcsWithWarniningHT = new Hashtable();

			foreach (DictionaryEntry pair in duplicateUPCStrings)
			{
				string upcNumber = pair.Key as string;
				int timesDuplicated = (int)pair.Value;
				int i = 1;

				foreach (var item in listDisplayedUPCs)
				{
					if (upcNumber == item.UpcNumber)
					{

						Report.IsTrue(item.WarningIsPresent, "The warning triangle for upc duplicate UPC No. " + upcNumber + " appearance: " + i + "  was not found next to their retailer code", "The warning triangle for upc duplicate UPC No. " + upcNumber + " appearance: " + i + "  was found next to their retailer code");
						i++;

						if (!upcsWithWarniningHT.ContainsKey(upcNumber))
						{
							upcsWithWarniningHT.Add(upcNumber, 1);
						}
						else
						{
							int old = (int)upcsWithWarniningHT[upcNumber];
							upcsWithWarniningHT[upcNumber] = old + 1;
						}

					}
				}

			}
			Context.AddToContext(upcsWithWarningSavedAs, upcsWithWarniningHT);


			//foreach (var upcNum in duplicateUPCStrings)
			//{
			//	foreach (var item in listDisplayedUPCs)
			//	{
			//		if (upcNum == item.UpcNumber)
			//		{
			//			Report.IsTrue(item.WarningIsPresent, "The warning triangle for upc duplicate UPC No. " + upcNum + " was not found next to their retailer code", "The warning triangle for upc duplicate UPC No. " + upcNum + " was found next to their retailer code");
			//			if (item.WarningIsPresent)
			//			{
			//				if (!upcsWithWarniningHT.ContainsKey(upcNum))
			//				{
			//					upcsWithWarniningHT.Add(upcNum, 1);
			//				}
			//				else
			//				{
			//					int old = (int)upcsWithWarniningHT[upcNum];
			//					upcsWithWarniningHT[upcNum] = old + 1;
			//				}
			//			}

			//		}
			//	}
			//}
			//Context.AddToContext(upcsWithWarningSavedAs, upcsWithWarniningHT);

			//var upcsWithWarnings = new List<string>();
			//foreach (var upcNum in duplicateUPCStrings)
			//{
			//	foreach(var item in listDisplayedUPCs)
			//	{
			//		if(upcNum==item.UpcNumber)
			//		{
			//			Report.IsTrue(item.WarningIsPresent, "The warning triangle for upc duplicate UPC No. " + upcNum + " was not found next to their retailer code", "The warning triangle for upc duplicate UPC No. " + upcNum + " was found next to their retailer code");
			//			if(item.WarningIsPresent)
			//			{
			//				upcsWithWarnings.Add(upcNum);
			//			}

			//		}
			//	}
			//}

			//Context.AddToContext(upcsWithWarningSavedAs, upcsWithWarnings);

		}

		[StepDefinition(@"Using the Hashtable of duplicate UPCs saved as: (.*) I select the UPCS")]
		public void UsingTheDuplicateUpcsSavedAsSelectUPCs(string upcsWithWarningSavedAs)
		{
			var upcsWithWarningHT = (Hashtable)Context.GetFromContext(upcsWithWarningSavedAs);

			Hashtable warningHTcopy = new Hashtable();
			warningHTcopy = (Hashtable)upcsWithWarningHT.Clone();
			var selectionBoxes = new UPC().UPCSelectionBoxes;
			ArrayList a = new ArrayList(warningHTcopy.Keys);

			foreach (var box in selectionBoxes)
			{
				foreach (DictionaryEntry pair in warningHTcopy)
				{
					string upcNumber = pair.Key as string;
					int timesDuplicated = (int)pair.Value;

					if (box.UpcNumber == upcNumber && timesDuplicated > 1)
					{
						Report.IsTrue(box.CheckBox.TryClick(), "The check box next to duplicate UPC No. " + upcNumber + " was not checked sucessfully", "The check box next to duplicate UPC No. " + upcNumber + " was checked sucessfully");
						warningHTcopy[upcNumber] = timesDuplicated - 1;
						break;

					}
					else if ((int)upcsWithWarningHT[upcNumber] == 1)
					{
						var testTT = (int)upcsWithWarningHT[upcNumber];
						Report.IsTrue(box.CheckBox.TryClick(), "The check box next to duplicate UPC No. " + upcNumber + " was not checked sucessfully", "The check box next to duplicate UPC No. " + upcNumber + " was checked sucessfully");
						break;
					}

				}
			}


		}

		[StepDefinition("I Click Delete Rows")]
		public void IClickDeleteRows()
		{
			Report.IsTrue(new UPC().ClickDeleteRowsButton(), "Failed to click Delete Rows", " Successfully clicked Delete Rows");
		}
		[StepDefinition("I Check the Delete Rows Warning Popup: (appears|disappears)")]
		public void ICheckTheDeleteRowsPopupPresent(string status)
		{
			if (status == "appears")
			{
				Report.IsTrue(new DeleteRowsWarning().WaitForContainerToBeVisible(30), "The warning popup did not appear", "The warning popup appeared");
			}
			if (status == "disappears")
			{
				Report.IsTrue(new DeleteRowsWarning().WaitForContainerToBeInvisible(30), "The warning popup appeared", "The warning popup did not appear");
			}
		}

		[StepDefinition("I Click Ok in the Delete Rows Warning Popup")]
		public void IClickOkInTheDeleteRowsWarningPopup()
		{
			Report.IsTrue(new DeleteRowsWarning().DeleteRowsWarningPopupOkButton.TryClick(), "Failed to Click Ok", "Succesfully clicked Ok");
		}




	}
}

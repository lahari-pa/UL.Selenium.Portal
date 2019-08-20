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




		[StepDefinition(@"In the Add Multiple dialog box I select the packaging type: (.*)")]
		public void InTheAddMultipleDialogBoxSelectPackagingTypeX(string packagingType)

		{
			var containsTypeOptionBox= new MultipleUPC().ContainsType;
				

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
		public void ICheckUPCNumberOfEachProductFromFile(string savedAs,string file)
		{
			Report.IsTrue(new UPC().ICheckUPCNumberOfEachProductFromFile(savedAs,file),"fail msg","Pass msg");  //Change messages 
			
		}

		[StepDefinition(@"I check that the size of each product matches the excel file uploaded saved as: (.*)")]
		public void ICheckSizeOfEachProductFromFile(string savedAs)
		{
		
		}








	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using System.Collections.ObjectModel;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.UPC;
using UL.Automation.Utilities.Functions;
using System.Text.RegularExpressions;
using System.Collections;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Automation.Reporting;
using UL.Automation.WebDriver.Functions;
using UL.Automation.TReVor.Classes;
using UL.Automation.Reporting.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "UPC")]
	class StepsUPC
	{

		[StepDefinition(@"I click the 'Add Casepack' button")]
		[StepDefinition(@"in the UPC Window, I click the Add Casepack button")]
		public void ThenIClickTheAddCaseUpcButton()
		{
			Report.IsTrue((new UPC()).ClickAddCaseUpcButton(), "Failed to click the 'Add Casepack' button!", "Successfully clicked the 'Add Casepack' button");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I should (see|not see) the following UPC options:")]
		public void ShouldSeeTheUPCOptions(string condition, Table expected)
		{
			var selNewProduct = new UPC();
			List<string> upcOptions = selNewProduct.GetUPCOptions();
			if (condition == "see")
			{
				//Delay.Seconds(9999);
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

		//[StepDefinition(@"I should see the (.*) Page")]
		//[StepDefinition(@"in the UPC Window, I should see the (.*) Page")]
		//public void GivenIShouldSeeXPage(string page)
		//{
		//	var selNewProduct = new UPC();
		//	Report.IsTrue(selNewProduct.WaitForSection(page),
		//		page + " is not showing when it was expected to",
		//		page + " is showing as expected");
		//	Report.Screenshot();
		//}

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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsUPC();
			var MyStepsProduct = new StepsNewProduct();
			//Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add Casepack' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.StartStep("I add the following into the UPC Fields");
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
				upcTable.AddRow("UPCName", "DefaultProductName");
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 87641A\(Enter Universal Product Code - case information\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and package type:(.*) and Quantity: (.*) and Transportation option: (.*)")]
		public void UPCCaseInformation(string upc, string containerType, string size, string packageType, string quantity, string transportation)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsUPC();
			var MyStepsProduct = new StepsNewProduct();
			//Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add Casepack' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.StartStep("I add the following into the UPC Fields");
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
				upcTable.AddRow("UPCName", "DefaultProductName");
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 87641 \(Enter Universal Product Code - case information\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and Quantity: (.*) and Associated UPC: (.*) and Transportation option: (.*)")]
		public void UPCCaseInformationWithAssociatedUPC(string upc, string containerType, string size, string quantity, string assocUPC, string transportation)
		{
			ReportSettings.UseSubSteps = true;
			StepsUPC MyStepsNewProduct = new StepsUPC();
			StepsNewProduct MyStepsProduct = new StepsNewProduct();
			//Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add Casepack' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.StartStep("I add the following into the UPC Fields");
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

			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(@"I call Shared Step 87647 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) do not click continue")]
		public void EnterUPCInfoDoNotClickContinue(string upc, string containerType, string size)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Delay.Seconds(3);
			Report.StartStep("I add the following into the UPC Fields");
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

		[StepDefinition(@"I call Shared Step 87647A \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*), size: (.*) and package type: (.*) do not click continue")]
		public void EnterUPCInfoDoNotClickContinue(string upc, string containerType, string size, string packageType)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Delay.Seconds(3);
			Report.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					PackageType = packageType,
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
				upcTable.AddRow("PackageType", packageType);

				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
		}

		[StepDefinition(@"I call Shared Step 87658 \(Enter Universal Product Code \(UPC\)\) for UPC saved as: UPC(.*) with container type: (.*) size: (.*) and quantity: (.*) do not click continue")]
		public void UpcWithQuantityDoNotClickContinue(string upc, string containerType,
			string size, string quantity)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			//Report.StartStep("I confirm 'Quantity' is visible in the UPC header");
			//MyStepsNewProduct.ConfirmQuantityIsVisibleInUPCHeader();
			Report.StartStep("I click the 'Add' button");
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
			Report.StartStep("I add the following into the UPC Fields");
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

		[Given(@"I expand UPC details for UPC saved as (.*)")]
		public void GivenIExpandUPCDetails(string upc)
		{
			var upcToGet = Context.GetFromContext(upc).ToString();
			new UPC().EnsureArrowIsExpandedforUPC(upcToGet);
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


		[StepDefinition(@"I delete the value in the (.*) field")]
		public void GivenIDeleteTheValueInTheUPCNameField(string field)
		{
			Report.IsTrue(new UPC().DeleteValueInField(field), "Unable to remove data from " + field + " field", "Deleted value in field " + field);
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsUPC();
			var MyStepsProduct = new StepsNewProduct();
			//Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add Casepack' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.StartStep("I add the following into the UPC Fields");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyStepsUpc = new StepsUPC();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			var uPCpage = new UPC();
			Report.StartStep("I confirm Add new Packaging Type link");
			List<string> labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsTrue(labelLinksShowing.Contains("Add new Packaging Type"), "The link with text: Add new Packaging Type was not found on the upc page", "The link with text: Add new Packaging Type was found on the upc page as expected");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");
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
			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
			Delay.Seconds(1);
			Report.StartStep("Confirm error message!");
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
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var MyStepsUpc = new StepsUPC();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			var uPCpage = new UPC();
			Report.StartStep("I confirm Add new Packaging Type link does not display");
			List<string> labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsFalse(labelLinksShowing.Contains("Add new Packaging Type"), "Add new Packaging Type link was found on the upc page, it should not have been", "Add new Packaging Type was not found on the upc page as expected");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I should not see Package Type option");
			List<string> upcOptions = uPCpage.GetUPCOptions();
			Report.IsFalse(upcOptions.Contains("Package Type"),
				"option was displayed which should not have been", "option did not displayed as expected");
			Report.StartStep("I add the following into the UPC Fields");
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
				Delay.Seconds(2);
				var upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
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
		[StepDefinition(@"I enter information for Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC(.*), container type: (.*) and size: (.*) - do not click continue")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(string upc,
			string containerType, string size)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Report.StartStep("I add the following into the UPC Fields");
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
				Delay.Seconds(2);
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

		[StepDefinition(@"I click the 'Upload File' button and upload the file saved as: (.*)")]
		public void ThenIClickTheUploadUpcsButtonAndUploadSavedAs(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var excelFile = Context.GetFromContext(savedAs).ToString();

			if (excelFile == null)
			{
				Report.Failure("The UPC spreadsheet could not be found");
				return;
			}

			Report.StartStep("I click the 'Upload UPC' button");
			Report.IsTrue((new UPC()).ClickUploadUpcButton(), "Failed to click the 'Upload UPC' button!", "Successfully clicked the 'Upload UPC' button");
			Report.StartStep($"I Upload the file saved as {savedAs}");
			Report.IsTrue(UploadDialog.UploadFile(excelFile), "Failed to enter file name!", "Successfully entered file name");

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

			if (containsTypeOptionBox == null)
			{
				Report.Failure("The Container Type Option Box was not found");
				return;
			}


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
					Report.Info("Selecting option: " + firstOption + " as the packaging type");

				}

			}
			else
			{
				containsTypeOptionBox.Select(packagingType);
				Report.Info("Selecting option: " + packagingType + " as the packaging type");

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
			Report.IsTrue(new MultipleUPC().WaitForContainerToBeInvisible(), "The popup was still showing", "The popup was no longer showing");
			

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

		[StepDefinition(@"I check that the (UPC|Type|Size|Retailer) of each product matches the excel file named: (.*) uploaded saved as: (.*)")]
		public void ICheckValueOfEachProductFromFile(string value, string file, string savedAs)
		{
			//This may need fixing to adapt the offset value (currently 21). See the below method for item number etc
			Report.IsTrue(new MultipleUPC().CheckValueOfEachProductFromFile(value, file, savedAs), "The UPC numbers shown in the Add Multiple Popup did not match the file", "The UPC numbers shown in the Add Multiple Popup matched the file");

		}

		[StepDefinition(@"I check that the (Item Number|Part Number|DPCI|OMSID) of each (.*) product matches the excel file named: (.*) uploaded saved as: (.*)")]
		public void ICheckValueOfEachRetailerProductFromFile(string value, string retailer, string file, string savedAs)
		{
			Report.IsTrue(new MultipleUPC().CheckValueOfEachRetailerProductFromFile(value, retailer, file, savedAs), "The UPC numbers shown in the Add Multiple Popup did not match the file", "The UPC numbers shown in the Add Multiple Popup matched the file");

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

		[StepDefinition(@"I edit the testdoc.xlsx, and save its filepath as: (.*) and verify it contains the UPC data in the table saved as: (.*), \(Base Data Only: (true|false)\)")]
		public void GivenICreateANewFileSavedAsAndVerifyUsingTheUPCsSavedAs(string fileSavedAs, string tableSavedAs,bool baseData, Table table)
		{
			Context.AddToContext(tableSavedAs, table);
			var upc = new UPC();
			Report.IsTrue(GeneralUtilities.DeleteFileFromDownloadsFolder("testdoc.xlsx"), "", "");
			//Create file here
			//var excelfile = new ExcelFunctions CreateSpreadsheet(fileName);
			//var utils = ExcelFunctions.CreateSpreadsheet(Path.Combine(KnownFolders.GetPath(KnownFolder.Downloads), fileName));
			if (!EmbeddedResources.ExtractToFile("UL.Selenium.Portal.WERCSmart.Dependencies.Excel.testdoc.xlsx", out string destination))
			{
				Report.Failure("testdoc.xlsx could not be found in the embedded resource");
				return;
			}
			var utils = new ExcelFunctions(destination, "Sheet1");
			var headers = table.Rows.FirstOrDefault().Keys.ToList();
			utils.AddRow(headers);
			foreach (var row in table.Rows)
			{
				var vals = row.RowValuesFromContext();
				utils.AddRow(vals.ToList());
			}
			//add all rows from table to excelfile
			System.IO.Directory.Move(destination, KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx");
			
			Report.IsTrue(upc.VerifySampleFile(table, "testdoc.xlsx", fileSavedAs), "Failed to validate File", "Successfully validated File");

			//File.SetLastWriteTime(KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx", DateTime.Now);
			//var dt = File.GetLastWriteTime(KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx");

			if (baseData == false)
			{
				Report.Failure("ERROR: Package reference 'Microsoft.Office.Interop.Excel' has been removed. Please find an alternative solution.");
				// TODO: Replace this with something that doesn't use 'Microsoft.Office.Interop.Excel' - the test agents will not have Microsoft Office installed.

				//Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
				//var excelWorkBook = excelApp.Workbooks.Open(KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx");
				//excelWorkBook.Activate();
				//excelWorkBook.Save();
				//excelWorkBook.Close();
				//excelApp.Quit();
			}

			//XSSFWorkbook hssfwb;
			//using (FileStream file = new FileStream(KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx", FileMode.Open, FileAccess.Read))
			//{
			//	hssfwb = new XSSFWorkbook(file);
			//	file.Close();
			//}

			//ISheet sheet = hssfwb.GetSheetAt(0);
			//IRow testrow = sheet.GetRow(4);

			////sheet.CreateRow(row.LastCellNum);
			//ICell cell = testrow.CreateCell(testrow.LastCellNum);
			//cell.SetCellValue("test");

			//using (FileStream file = new FileStream(KnownFolders.GetPath(KnownFolder.Downloads) + @"\testdoc.xlsx", FileMode.OpenOrCreate, FileAccess.Write))
			//{
			//	hssfwb.Write(file);
			//	file.Close();
			//}




		}

		[StepDefinition(@"I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: (.*)")]
		public void IConfirmAddMultipleUPCPopupAppearsAndValuesAreTheSame(string tableSavedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I confirm the Add Multiple UPC popup appears");
			this.IConfirmThatTheAddMultipleUPCWindowOpens();
			Report.StartStep("I confirm the UPC numbers and sizes are the same as the upload document");
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
					upcNumber = Context.GetFromContextRegex(upcNumber)?.ToString() ?? upcNumber;
					Report.Info("UPC number: " + upcNumber);
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
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I confirm the Add Multiple UPC popup dissappears");
			this.IConfirmThatTheAddMultipleUPCWindowCloses();
			Report.StartStep("I confirm the UPC numbers and sizes are the same as the upload document");
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

					upcNumber = Context.GetFromContextRegex(upcNumber)?.ToString() ?? upcNumber;

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
			ReportSettings.UseSubSteps = true;
			var upc = new UPC();
			Report.StartStep("Looking for the UPC Buton Container anywhere on the page");
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
				Report.Failure("The Add Casepack Button was not found");
				Report.Screenshot();
				allFound = false;
			}
			if (!upc.UploadUpcButton())
			{
				Report.Failure("The Upload File Button was not found");
				Report.Screenshot();
				allFound = false;
			}

			if (allFound)
			{
				Report.Success("The UPC Buttons (+Add UPC, + Add Casepack, & ↑ Upload File were all found");
				Report.Screenshot();
			}

			Report.StartStep("I Scroll to the top of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToTopOfPage();
			bool buttonsFound = true;
			if (upc.UPCButtonContainerTop == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}
			Report.StartStep("I Scroll to the bottom of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToBottomOfPage();
			if (upc.UPCButtonContainerBottom == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}
			Report.StartStep("I Scroll to the top of the page and check the UPC Buttons still appear");
			GeneralUtilities.ScrollToTopOfPage();
			if (upc.UPCButtonContainerTop == null)
			{
				Report.Failure("The UPC Buttons were not on screen");
				Report.Screenshot();
				buttonsFound = false;
			}
			Report.StartStep("I Scroll to the bottom of the page and check the UPC Buttons still appear");
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

		[StepDefinition(@"I Check that the type column becomes populated with option: (.*)")]
		public void ICheckTypeColumnContiansFirstOption(string packagingType)
		{
			var containsTypeOptionBox = new MultipleUPC().ContainsType;


			var displayedOption = containsTypeOptionBox.SelectedOption();

			if (packagingType == "<first>")

			{
				var chosenOption = (string)Context.GetFromContext("AddMultipleDialogFirstContainerOption");

				Report.IsTrue(chosenOption == displayedOption, "The Displayed container type did not match the type selected. Selected: " + chosenOption + ". The Displayed container type was: " + displayedOption + ".", "The Contianer types was correctly populated with the selected option");

			}
			else
			{

				Report.IsTrue(packagingType == displayedOption, "The Displayed container type did not match the type selected. Selected: " + displayedOption + ". The Displayed container type was: " + displayedOption + ".", "The Contianer types was correctly populated with the selected option");

			}



		}

		[StepDefinition(@"I make a list of the duplicated UPCs and save it as: (.*) from the table saved as: (.*)")]
		public void IMakeAListOfDuplicateUPCsFromTable(string duplicateListSavedAs, string tableSavedAs)
		{
			var tableContent = (Table)Context.GetFromContext(tableSavedAs);
			List<string> UPCCheckList = new List<string>();

			Hashtable duplicateUPCHashTable = new Hashtable();

			int i = 0;
			foreach (var row in tableContent.Rows)
			{
				var upcNumber = row["UPC"];

				if (Context.GetFromContextRegex(upcNumber, out var result))
				{
					upcNumber = result.ToString();
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

			}

			Context.AddToContext(duplicateListSavedAs, duplicateUPCHashTable);
		}


		[StepDefinition(@"I make a list of the duplicated UPCs including unique duplicated UPCs starting with: (.*) and save it to a hashtable as: (.*) from the table saved as: (.*)")]
		public void IMakeAListOfDuplicateUPCsFromTableIncludingUPCSStartingWithX(string exisitingDuplicateUPCsSavedAs, string duplicateListSavedAs, string tableSavedAs)
		{
			var tableContent = (Table)Context.GetFromContext(tableSavedAs);
			List<string> UPCCheckList = new List<string>();

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

			}

			int j = 1;
			while (Context.Contains(exisitingDuplicateUPCsSavedAs + j))
			{
				var valueToAdd = Context.GetFromContext(exisitingDuplicateUPCsSavedAs + j);
				duplicateUPCHashTable.Add(valueToAdd, 1);
				j++;
			}
			Context.AddToContext(duplicateListSavedAs, duplicateUPCHashTable);
		}




		[StepDefinition(@"I use a list of duplicated UPCs saved as: (.*) and check that they have a warning traingle next to their retailer code and save the ones that do as: (.*)")]
		public void IMakeAListOfDuplicateUPCsAndCheckForWarning(string duplicateUPCsSavedAs, string upcsWithWarningSavedAs)
		{

			ReportSettings.UseSubSteps = true;
			Report.StartStep("I confirm the Add Multiple UPC popup disappears");
			this.IConfirmThatTheAddMultipleUPCWindowCloses();
			Report.StartStep("I make a list of the UPCS that have duplicates");
			Report.StartStep("I confirm the UPCs wich are duplicates have have a warning traingle next to their retailer code");

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
						box.CheckBox.ScrollElementIntoView();
						Report.IsTrue(box.CheckBox.TryClick(), "The check box next to duplicate UPC No. " + upcNumber + " was not checked sucessfully", "The check box next to duplicate UPC No. " + upcNumber + " was checked sucessfully");
						warningHTcopy[upcNumber] = timesDuplicated - 1;
						break;

					}
					else if ((int)upcsWithWarningHT[upcNumber] == 1)
					{
						var testTT = (int)upcsWithWarningHT[upcNumber];
						box.CheckBox.ScrollElementIntoView();
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

		[StepDefinition(@"I Check the Delete Rows Warning Popup contains the following text, Line One: (.*), Line Two: (.*)")]
		public void ThenICheckTheDeleteRowsWarningPopupContainsTheFollowingTextYouAreAboutToDelete(string lineOne, string lineTwo)
		{
			var selectionBoxes = new UPC();
			Report.IsTrue(selectionBoxes.CheckDeleteRowsWarningPopupContainsText(lineOne, lineTwo), "Failed to confirm the following text in the Delete Rows Warning Popup: " + lineOne + lineTwo, "Successfully confirmed the following text in the Delete Rows Warning Popup: " + lineOne + lineTwo);
		}

		[StepDefinition("I Click Ok in the Delete Rows Warning Popup")]
		public void IClickOkInTheDeleteRowsWarningPopup()
		{
			Report.IsTrue(new DeleteRowsWarning().DeleteRowsWarningPopupOkButton.TryClick(), "Failed to Click Ok", "Succesfully clicked Ok");
		}
		[StepDefinition("I Check all Duplicate UPCs saved as: (.*) are no longer shown")]
		public void ICheckAllDuplicateUPCSAreNoLongerShown(string upcsWithWarningSavedAs)
		{
			var selectionBoxes = new UPC().UPCSelectionBoxes;
			List<string> UPCCheckList = new List<string>();

			Hashtable visibleUPCHashtable = new Hashtable();

			foreach (var row in selectionBoxes)
			{
				if (visibleUPCHashtable.ContainsKey(row.UpcNumber))
				{
					int old = (int)visibleUPCHashtable[row.UpcNumber];
					visibleUPCHashtable[row.UpcNumber] = old + 1;
				}
				else
				{
					visibleUPCHashtable.Add(row.UpcNumber, 1);
				}

			}

			var upcsWithWarningHT = (Hashtable)Context.GetFromContext(upcsWithWarningSavedAs);
			Hashtable warningHTcopy = new Hashtable();
			warningHTcopy = (Hashtable)upcsWithWarningHT.Clone();

			foreach (DictionaryEntry pair in visibleUPCHashtable)
			{

				string VisibleupcNumber = pair.Key as string;
				int VisibletimesRecorded = (int)pair.Value;

				foreach (DictionaryEntry item in upcsWithWarningHT)
				{
					string WarningupcNumber = pair.Key as string;
					int WarningtimesDuplicated = (int)pair.Value;

					if (VisibleupcNumber == WarningupcNumber)
					{
						Report.IsTrue(VisibletimesRecorded == 1, "Duplicate UPCs of: " + VisibleupcNumber + " are still shown", "Duplicate UPCs of: " + VisibleupcNumber + " are no longer shown");
					}
				}

			}


		}

		[StepDefinition(@"I save the first UPC in the list as: (.*)")]
		public void ISavetheFirstUPCInTheListAs(string savedAs)
		{
			var uPCpage = new UPC();
			string upc = uPCpage.GetFirstUPCInList();
			Context.AddToContext(savedAs, upc);
			Report.IsTrue(upc != "", "Failed to find first UPC on UPC page.", "Successfully found first UPC!");
		}

		[StepDefinition(@"I delete UPC saved as: (.*)")]
		public void IDeleteUPCSavedAs(string savedAs)
		{
			string upc = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (upc == "")
			{
				Report.Failure("Failed to find upc in context saved as " + savedAs);
				return;
			}
			var uPCpage = new UPC();
			Report.IsTrue(uPCpage.DeleteUPC(upc), "Failed to click delete for UPC " + upc + ".", "Successfully clicked delete for UPC " + upc + ".");

		}


		[StepDefinition(@"In the Universal Product Code \(UPC\) page I click Save")]
		public void InTheUPCPageIClickSave()
		{
			var uPCpage = new UPC();
			Report.IsTrue(uPCpage.ClickSaveButton(), "Failed to click the Save button.", "Successfully clicked the Save button.");
		}

		[StepDefinition(@"I call Shared Step 87829 \(UPC - Add Casepack - All Data > Continue\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and Quantity: (.*) and Individual Upc Case Pack saved As: (.*) and Transportation option: (.*)")]
		public void UPCCaseAddInformation(string upc, string containerType, string size, string quantity, string individualUpcCasePackSavedAS, string transportation)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsUPC();
			var MyStepsProduct = new StepsNewProduct();
			string individualUpcCasePack = (string)Context.GetFromContext(individualUpcCasePackSavedAS);
			//Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			//MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add Casepack' button");
			MyStepsNewProduct.ThenIClickTheAddCaseUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			Report.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcCaseInformation {
					ContainerType = containerType,
					Size = size,
					Quantity = quantity,
					TransportationOption = transportation,
					UpcNumber = upc_,
					IndividualUpcCasePack = individualUpcCasePack

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
				upcTable.AddRow("IndividualUpcCasePack", individualUpcCasePack);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
		}

		[StepDefinition(@"In the Destination Retailers input field I input the value: (.*)")]
		public void InTheDestinationRetailersInputFieldIInputTheValue(string value)
		{
			var uPCpage = new UPC();
			Report.IsTrue(uPCpage.EnterDPCI(value), "Failed to enter DPCI", "Successfully entered DPCI");
		}

		[StepDefinition(@"I set all product information options to (.*)")]
		public void GivenSetUnderadgeChildToNo(string yesOrNoOption)
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Product Information");
			Delay.Seconds(1);
			MyStepsNewProduct.SetTheSectionOptionTo("Select countries the product may be sold in", "United States");
			if (myNewProduct.CountryofOriginExists())
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Select the product's Country of Origin", "United Kingdom");
			}
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					yesOrNoOption);
			}
			MyStepsNewProduct.SetTheSectionOptionTo(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS)", yesOrNoOption);
			MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.", yesOrNoOption);
			MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", yesOrNoOption);
			MyStepsNewProduct.SetTheSectionOptionTo("Product is sold to the Retailer solely for the Retailer's use",
				yesOrNoOption);
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
		}
		[StepDefinition(@"I confirm the UPC Duplicate Warning Icon is visible")]
		public void ThenIConfirmTheUPCDuplicateWarningIconIsVisible()
		{
			Report.IsTrue(new UPC().CheckIfUPCDuplicateWarningAppears(), "Failed to find the UPC Duplicate Warning Messsage!", "Successfully found the UPC Duplicate Warning Message!");
		}

		[StepDefinition(@"I call Shared Step 292066 \\\(Retailer - Select No Retailer - Click Done - Click Continue - Happy Path\\\)")]
		public void GivenICallSharedStepRetailer_SelectNoRetailer_ClickDone_ClickContinue_HappyPath()
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			var WarningPopup = new NoRetailerWarningPopup();
			new SelectRetailers().ClickSelectAll();
			SelectRetailers selectRetailers = new SelectRetailers();
			Report.IsTrue(selectRetailers.ClickDone(), "Failed to click the 'Done' button!", "Successfully clicked the 'Done' button");
			Report.StartStep("In the Retailer page I click Continue");
			MyStepsNewProduct.NewProductPageIClickContinueNoSpinnerWait();
			/* --As per TFS70787 warning popup displays for NR  --- */
			//Report.StartStep("In the UPCs Warning popup I click Ok");
			new Steps_Retailer().IfISeeUpcWarningPopupClick("Ok");
		}

		[StepDefinition(@"I select the following retailers in the 'Select Retailers' window")]
		public void GivenIUnderDestinationRetailersInTheUPCPage(Table table)
		{
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.SelectAllRetailersInTable(table), "Failed to select all retailers in table", "Succeeded to select all retailers in table");
		}

		[StepDefinition(@"I fill in the UPC data; UPC:(.*), Product Type:(.*), Product Weight:(.*)")]
		public void FillInUPCData(string productUPC, string productType, string productWeight)
		{
			if (Context.Contains(productUPC))
			{
				productUPC = Context.GetFromContext(productUPC).ToString();
			}
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.FillInUPCData(productUPC, productType, productWeight), "Failed to fill in UPC data", "Succeeded to fill in UPC data");
		}

		[StepDefinition(@"I remove randomly selected retailers")]
		public void GivenIRemoveRetailers()
		{
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.RemoveRandomRetailers(), "Failed to remove random retailers", "Succeeded to remove random retailers");
		}

		[StepDefinition(@"I remove the following retailers")]
		public void IRemoveTheFollowingRetailers(Table table)
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.RemoveRetailers(table), "Failed to remove the retailers", "Successfully removed retailers");
		}

		[StepDefinition(@"I click the 'Restore Selected' button")]
		public void ClickRestoreRetailersButton()
		{
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.ClickRestoreSelectedRetailersButton(), "Failed to click 'Restore Selected' button in removed retailers pop-up", "Successfully clicked 'Restore Selected' button in removed retailers pop-up");
			Report.IsTrue(NewProductClassObject.CheckIfListOfAddedRetailersAreInAlphabeticalOrder(), "The added retailers are not sorted in alphabetical order", "The added retailers are sorted in alphabetical order");
		}

		[StepDefinition(@"I click the 'Add Retailers' button")]
		public void GivenIClickAddRetailers()
		{
			NewProduct NewProductClassObject = new NewProduct();
			//Open Retailers popup
			Report.IsTrue(NewProductClassObject.ClickAddRetailersButton(), "Failed to click 'Add Retailers' button", "Successfully clicked 'Add Retailers' button");
			Report.IsTrue(NewProductClassObject.CheckIfListOfRemovedRetailersAreInAlphabeticalOrder(), "The removed retailers are not sorted in alphabetical order", "The removed retailers are sorted in alphabetical order");
		}

		[StepDefinition(@"In the 'Add Retailers' popup does not contain the retailes saved as (.*)")]
		public void AddRetailersPopupDoesNotContainListOfRetailers(string savedAs)
		{
			NewProduct NewProductClassObject = new NewProduct();

			Report.IsTrue(NewProductClassObject.ListOfRemovedRetailersDoesNotContainListSavedAs(savedAs), "Restored Retailers were still found in the deleted retailers list", "No Restored Retailers were found in the deleted retailers list");

		}

		[StepDefinition(@"The 'Add Retailers' popup contains all the retailers saved as: (.*)")]
		public void AddRetailersPopupContainsDeletedRetailersList(string savedAs)
		{
			List<string> deletedRetailersInitials = (List<string>)Context.GetFromContext(savedAs);
			List<string> foundRetaiers = new NewProduct().GetListOfRemovedRetailersInPopup();
			List<string> foundRetailersInitials = new List<string>();
			foreach(var item in foundRetaiers)
			{
				foundRetailersInitials.Add(new RetailerAbbreviations().TryConvertToAbbreviation($"{item}")); 

			}
			bool countsMatch =  foundRetailersInitials.Count() == deletedRetailersInitials.Count();
			var differences1 = foundRetailersInitials.Except(deletedRetailersInitials).ToList();
			bool foundDifferences1 = differences1.Count() == 0;
			var differences2 = deletedRetailersInitials.Except(foundRetailersInitials).ToList();
			bool foundDifferences2 = differences2.Count() == 0;
			Report.IsTrue(countsMatch && foundDifferences1 && foundDifferences2, $"The 'Add Retailers' popop did not contain all the expected retailers", "The 'Add Retailers' popop did contain all the expected retailers");


		}

		[StepDefinition(@"I randomly select retailers to restore")]
		public void GivenISelectRandomRetailersToAdd()
		{
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.AddRandomRetailersThatWereRemoved(), "Failed to add random retailers", "Succeeded to add random retailers");
		}

		[StepDefinition(@"I select the following Retailers to restore")]
		public void ISelectTheFollowingRetailerToRestore(Table table)
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.AddRetailersThatWereRemoved(table), "Failed to add random retailers", "Succeeded to add random retailers");

		}

		[StepDefinition(@"I click 'Select All' to add all removed retailers")]
		public void RestoreEverySingleDeletedRetailer()
		{
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.ClickSelectAllInRemovedRetailersBox(), "Failed to click 'Select All' in removed retailers pop-up box", "Successfully clicked 'Select All' in removed retailers pop-up box");
		}

		[StepDefinition(@"In the 'Add Retailers' popup I confirm that all retailers are currently selected")]
		public void InTheAddRetailers()
		{
			NewProduct NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.CheckAllRetailesInAddRetailersPopupAreSelected(), "Not all Retailers were selected", "All Retailers were selected");

			
		}

		[StepDefinition(@"I Enter Universal Product Code details for a CVS Product, container type: (.*), size: (.*), Quantity (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly(string containerType, string size, string quantity)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			for (int i = 0; i < 100; i++)
			{
				Report.Info("Entering UPC information. Attempt: " + (i + 1));
				Report.StartStep("I click the 'Add' button");
				stepsNewProduct.ThenIClickTheAddUpcButton();
				Report.StartStep("I add the following into the UPC Fields");
				string upc = new UpcFunctions().GeneratePrefixedUPCForRetailer("CVS");
				Report.Info("UPC number: " + upc);
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc,
					Quantity = quantity
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
				Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
				stepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
				// not returning...
				if (new NewProduct().FormError().IsNullOrEmpty())
				{
					return;
				}
				// delete upc that failed
				stepsNewProduct.GivenIDeleteUPC(upc);
				Report.Info("An error was showing! on click continue! Attempting a different UPC");
			}
		}

		[StepDefinition(@"I enter Container type: (.*), Size (.*), Packaging type: (.*) and Part number: (.*) then click continue in the UPC screen")]
		public void IEnterContainerTypeSizePackagingTypeAndPartNumberThenClickContinue(string containerType, string size, string packagingType, string partNumber)
		{
			ReportSettings.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			Report.StartStep("I Click Add Part Number in the UPC screen");
			newProductSteps.ThenIClickTheAddPartNumber();
			this.IEnterUPCDetailsAndPartNumberIntoTheUPCScreen(containerType, size, packagingType, partNumber);
			Report.StartStep("I should see the Regulatory Documents to Provide Page");
			new StepsNewProduct().GivenIShouldSeeXPage("Regulatory Documents to Provide");
		}


		[StepDefinition(@"I enter UPC details, container type: (.*), size: (.*) and packaging type: (.*) then I enter Part Number: (.*)")]
		public void IEnterUPCDetailsAndPartNumberIntoTheUPCScreen(string containerType, string size, string packagingType, string partNumber)
		{
			ReportSettings.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			for (int i = 0; i < 100; i++)
			{
				Report.Info("Entering UPC information. Attempt: " + (i + 1));
				Report.StartStep("I add the following into the UPC Fields");
				//string upc = new UpcFunctions().GenerateUPC();
				string upc = GeneralFunctions.GenerateUPCNumber();
				Report.Info("UPC number: " + upc);

				var upcInfo = new UpcInformation();
				if (packagingType == "NA")
				{

					upcInfo.ContainerType = containerType;
					upcInfo.Size = size;

				}
				else
				{
					upcInfo.ContainerType = containerType;
					upcInfo.Size = size;
					upcInfo.PackageType = packagingType;

				}

				Report.IsTrue(new NewProduct().InputPartNumberInformation(upcInfo, partNumber), "Failed to input UPC Information!",	"Successfully inputted UPC information!");
				Report.StartStep("In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue");
				stepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
				// not returning...
				if (new NewProduct().FormError().IsNullOrEmpty())
				{
					return;
				}
				// delete upc that failed
				stepsNewProduct.GivenIDeleteUPC(upc);
				Report.Info("An error was showing! on click continue! Attempting a different UPC");
			}
		}

		[StepDefinition(@"I expand the chevron for UPC saved as (.*)")]
		public void IExpandTheChevronforUPCSavedAs(string savedAs)
		{
			string upc = Context.GetFromContext(savedAs)?.ToString();
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.SelectChevronForUPC(upc), "Failed to select chevron for upc " + upc, "Successfully selected chevron!");
		}

		[StepDefinition(@"I Check that in the UPC screen, under the Transportation Column the Catagory (.*) is checked")]
		public void ICheckThatInTheUPCScreenUnderTransportationColumnCatagoryXisChecked(string option)
		{
			Report.Info($"Starting the check of the selected status of option: {option}");
			bool status= new NewProduct().CheckTransportationCatagoryXIsChecked(option);
			Report.IsTrue(status, "The Catagory:" + option + " was not correctly selected", "The option:" + option + " was correctly selected");

		}


		[StepDefinition(@"I Check that in the UPC screen, under the Transportation Column for Catagory (.*) the option (.*) is checked")]
		public void ICheckThatInTheUPCScreenUnderTransportationColumnCatagoryXisCheckedForCatagoryY(string catagory, string option)
		{
			Report.Info($"Starting the check of the selected status of option: {option} for cataogry: {catagory}");
			bool status = new NewProduct().CheckTransportationOptionXIsCheckedForCatagoryY(catagory,option);
			Report.IsTrue(status, "The option:" + option + " was not correctly selected under the catagory: "+catagory, "The option:" + option + " was correctly selected  under the catagory: " + catagory);

		}

		[StepDefinition(@"I ensure that there is a column in the Add UPC table called Transportation")]
		public void IEnsureThatThereIsAColumnInTheAddUPCTableCalledTransportation()
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.TransportationColumnExists(), "Failed to find Transportation column", "Successfully found Transportation column");
		}

		[StepDefinition(@"I ensure that (DOT|IATA|IMDG|TDG) is listed as (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void IEnsureThatOptionIsListedAs(string option, string transLevel)
		{
			var NewProductClassObject = new NewProduct();

			Report.IsTrue(NewProductClassObject.CheckTransportationOption(option, transLevel), "Failed to find the correct Transportation option for " + option + ".",
				"Successfully found correct Transportation option for " + option + ".");
		}

		[StepDefinition(@"I ensure that I cannot select (DOT|IATA|IMDG|TDG) at (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void IEnsureThatICannotSelectOptionAtLevel(string option, string transLevel)
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(!NewProductClassObject.CanCheckTransportationOption(option, transLevel), "Failed to find checkbox unselectable for option " + option + ".",
				"Successfully found checkbox unselectable for " + option + ".");
		}

		[StepDefinition(@"I ensure that I can only select one exception in the UPC Transportation column")]
		public void IEnsureThatICanOnlySelectOneExceptionInTheTransportationColumn()
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.ExceptionsArePresent(), "Failed! Exceptions are not present!", "Successfully found exceptions.");
			Report.IsTrue(NewProductClassObject.CannotSelectMultipleExceptions(), "Failed! You can select more than one option.",
				"Successfully found that you can only select one option");
		}

		[StepDefinition(@"I ensure that the (DOT|IATA|IMDG|TDG) checkbox is not present in the UPC Transportation column")]
		public void IEnsureThatTheOptionCheckboxIsNotPresentInTheUPCTransportationColumn(string option)
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(!NewProductClassObject.UPCTransportationCheckboxPresent(option), "Failed! Found " + option + " checkbox.",
				"Successfully did not find " + option + "checkbox.");
		}

		[StepDefinition(@"At the UPC level, I set (DOT|IATA|IMDG|TDG) to (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void AtTheUPCLevelISetOptionToLevel(string option, string transLevel)
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.SelectUPCTransportationOptionAtLevel(option, transLevel), "Failed to select " + option + " at " + transLevel + ".",
				"Successfully selected " + option + " at " + transLevel + ".");
		}

		[StepDefinition(@"I ensure that I can select (DOT|IATA|IMDG|TDG) at (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void IEnsureThatICanSelectOptionAtLevel(string option, string transLevel)
		{
			var NewProductClassObject = new NewProduct();
			Report.IsTrue(NewProductClassObject.SelectUPCTransportationOptionAtLevel(option, transLevel), "Failed to Click " + option + " at " + transLevel + ".","Successfully click " + option + " at " + transLevel + ".");
			Report.IsTrue(NewProductClassObject.CheckTransportationOption(option, transLevel), "Failed to find the correct Transportation option for " + option + ".","Successfully found correct Transportation option for " + option + ".");

		}

		[StepDefinition(@"I call Shared Step 76738 \(Universal Product Code \(UPC\) - Canada - Package Type\) for UPC: saved as UPC(.*), container type: (.*), size: (.*), package type: (.*) and Item Number: (.*) then click continue")]
		public void EnterUPCInfoAndItemNumberThenClickContinue(string upc, string containerType, string size, string packageType, string itemNumber)
		{
			ReportSettings.UseSubSteps = true;
			var MyStepsNewProduct = new StepsNewProduct();
			Report.StartStep("I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			Report.StartStep("I click the 'Add' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			Delay.Seconds(3);
			Report.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				string upc_ = upc.Replace("Equals", "");
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc_,
					PackageType= packageType,
					ItemNumber = itemNumber

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
				upcTable.AddRow("PackageType", packageType);
				upcTable.AddRow("ItemNumber", itemNumber);

				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
				MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Global Trade Item Number (GTIN) / Universal Product Code (UPC)");

			}
		}

	}
}

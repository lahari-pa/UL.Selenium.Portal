using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using System.IO;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using static Wercs.Selenium.PortalUX.Selenium_Classes.UPC;
using static Wercs.Selenium.PortalUX.Steps.Steps_Shared;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "UPC")]
	class StepsUPC
	{

		[StepDefinition(@"I click the 'Add Case UPC' button")]
		public void ThenIClickTheAddCaseUpcButton()
		{
			Report.IsTrue((new UPC()).ClickAddCaseUpcButton(), "Failed to click the 'Add Case UPC' button!", "Successfully clicked the 'Add Case UPC' button");
		}

		[StepDefinition(@"I should (see|not see) the following UPC options:")]
		public void ShouldSeeTheUPCOptions(string condition, Table expected)
		{
			var selNewProduct = new UPC();
			var upcOptions = selNewProduct.GetUPCOptions();
			if (condition == "see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Option"];
					Report.Info("Checking that I see the option '" + option + "'");
					Report.IsTrue(upcOptions.Contains(option.Trim()),
						"Option was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", upcOptions) + "'!",
						"Option was showing: '" + option + "', as expected!");
				}
			}
			if (condition == "not see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Option"];
					Report.Info("Checking that I do not see the option '" + option + "'");
					Report.IsFalse(upcOptions.Contains(option.Trim()),
						"Options were showing which should not be. The sections not allowed are: " + string.Join("; ", option) + ". Actual sections: " + string.Join("; ", option), "Sections were not showing as expected: " + string.Join("; ", option));
				}
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I should see the (.*) Page")]
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
			var upcInfo = table.CreateInstance<UpcCaseInformation>();
			Report.Info("UPC Number: " + upcInfo.UpcNumber);
			Report.Info("Container Type: " + upcInfo.ContainerType);
			Report.Info("Size: " + upcInfo.Size);
			Report.Info("Quantity: " + upcInfo.Quantity);
			Report.Info("Transportation Option: " + upcInfo.TransportationOption);

			Report.IsTrue(new UPC().InputUpcCaseInformation(upcInfo), "Failed to input UPC Information!", "Successfully inputted UPC information!");
		}


		[StepDefinition(@"I call Shared Step 87641\(Enter Universal Product Code - case information\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) and Quantity: (.*) and Transportation option: (.*)")]
		public void UPCCaseInformation(string upc, string containerType, string size, string quantity, string transportation)
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
				upcTable.AddRow("TransportationOption", transportation);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}

			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code(UPC)");
		}


		[StepDefinition(@"I call Shared Step 87647 \(Enter Universal Product Code \(UPC\) - UPC-Container Type - Size Only\) for UPC: saved as UPC(.*), container type: (.*) and size: (.*) do not click continue")]
		public void EnterUPCInfoDoNotClickContinue(string upc, string containerType, string size)
		{
			TestReport.UseSubSteps = true;
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				var upc_ = upc.Replace("Equals", "");
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
				Table upcTable = new Table("Field", "Value");
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
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			//TestReport.StartStep("I confirm 'Quantity' is visible in the UPC header");
			//MyStepsNewProduct.ConfirmQuantityIsVisibleInUPCHeader();
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			GeneralUtilities.Wait_for_load_finish();
			TechTalk.SpecFlow.Table upcTable = new TechTalk.SpecFlow.Table(new string[] {
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
			var found = selNewUpc.LithiumBatteyWarning();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Warning message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Warning message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I should see maximum upc limit message: (.*)")]
		public void MaximumUpcLimitMessage(string message)
		{
			Report.Info("Checking error message");
			var selNewUpc = new UPC();
			var found = selNewUpc.MaximumLimitUpcWarning();

			Report.IsTrue(found.Trim() == message.Trim(),
				"Warning message was not as expected! Expected: " + message + ", but found: " + found + "!",
				"Warning message was showing: " + message + ", as expected!");
		}

		[StepDefinition(@"I should (see|not see) the following UPC buttons:")]
		public void UpcButtonsDisplay(string condition, Table expected)
		{
			Delay.Seconds(1);
			var selNewProduct = new UPC();
			var upcButtons = selNewProduct.GetUPCbuttons();
			if (condition == "see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Option"];
					Report.Info("Checking that I see the option '" + option + "'");
					Report.IsTrue(upcButtons.Contains(option.Trim()),
						"Option was not showing as expected! Expected: '" + option + "', but found: '" + string.Join("', '", upcButtons) + "'!",
						"Option was showing: '" + option + "', as expected!");
				}
			}
			if (condition == "not see")
			{
				foreach (var row in expected.Rows)
				{
					var option = row["Option"];
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
			var currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			var allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (var handle in allHandles)
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
				upcTable.AddRow("TransportationOption", transportation);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
		}

		[StepDefinition(@"I confirm that UPC page contains link for: (.*)")]
		public void IConfirmUPCContains(string labelLink)
		{
			var uPCpage = new UPC();
			var labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsTrue(labelLinksShowing.Contains(labelLink), "The link with text: '" + labelLink + "' was not found on the upc page", "The link with text: '" + labelLink + "' was found on the upc page as expected");
		}

		[StepDefinition(@"(.*) (should|should not) be showing the error messages on upc screen: (.*)")]
		public void ErrorMessagesAreShowingOnUpc(string section, string should, string pipeDelimitedErrorMessages)
		{
			Delay.Seconds(1);
			var errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			var errorMessages = new UPC().GetUPCErrorsForSection(section);
			Report.Info("Error messages showing are: " + string.Join(", ", errorMessages));
			if (should == "should")
			{
				foreach (var item in errorMessagesExpected)
				{
					Report.IsTrue(errorMessages.Any(e => e.Contains(item)),
						"Failed to find the error message: " + item + " under section: " + section + "!",
						"Successfully found the error message: " + item + " for section: " + section, false, false);
				}
			}
			if (should == "should not")
			{
				foreach (var item in errorMessagesExpected)
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
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			StepsUPC MyStepsUpc = new StepsUPC();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			UPC uPCpage = new UPC();
			TestReport.StartStep("I confirm Add new Packaging Type link");
			var labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsTrue(labelLinksShowing.Contains("Add new Packaging Type"), "The link with text: Add new Packaging Type was not found on the upc page", "The link with text: Add new Packaging Type was found on the upc page as expected");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				var upc_ = upc.Replace("Equals", "");
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
				Table upcTable = new Table("Field", "Value");
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
			var errorMessagesExpected = pipeDelimitedErrorMessages.Split('|');
			var errorMessages = new UPC().GetUPCErrorsForSection("Package Type");
			foreach (var item in errorMessagesExpected)
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
			StepsNewProduct MyStepsNewProduct = new StepsNewProduct();
			StepsUPC MyStepsUpc = new StepsUPC();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			MyStepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			UPC uPCpage = new UPC();
			TestReport.StartStep("I confirm Add new Packaging Type link does not display");
			var labelLinksShowing = uPCpage.UpcPageLinks();
			Report.IsFalse(labelLinksShowing.Contains("Add new Packaging Type"), "Add new Packaging Type link was found on the upc page, it should not have been", "Add new Packaging Type was not found on the upc page as expected");
			TestReport.StartStep("I click the 'Add UPC' button");
			MyStepsNewProduct.ThenIClickTheAddUpcButton();
			TestReport.StartStep("I should not see Package Type option");
			var upcOptions = uPCpage.GetUPCOptions();
			Report.IsFalse(upcOptions.Contains("Package Type"),
				"option was displayed which should not have been", "option did not displayed as expected");
			TestReport.StartStep("I add the following into the UPC Fields");
			if (upc.Contains("Equals"))
			{
				var upc_ = upc.Replace("Equals", "");
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
				Table upcTable = new Table("Field", "Value");
				upcTable.AddRow("UPCNumber", "saved as UPC" + upc);
				upcTable.AddRow("ContainerType", containerType);
				upcTable.AddRow("Size", size);
				MyStepsNewProduct.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			}
			TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SafewareReporting;
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
					Report.Info("Checking that I see the option '" + option + "'");
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

		[StepDefinition(@"I add the following into the UPC Fields")]
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

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsProductIncludesBattery
	{
		private static ProductIncludesBattery _productIncludesBattery = new ProductIncludesBattery();

		[StepDefinition(@"For 'Indicate how battery is packaged' I select: (.*)")]
		public void ForIndicateHowBatteryIsPackagedISelect(string option)
		{
			Report.IsTrue(_productIncludesBattery.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			_productIncludesBattery.IndicateHowBatteryIsPackaged = option;
			Report.IsTrue(_productIncludesBattery.IndicateHowBatteryIsPackaged == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"I add the following batteries:")]
		// Requires a table with the headings: | Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		public void AddTheFollowingBatteries(Table table)
		{
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (var thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Number of batteries per package"], out var batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Number of batteries per package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["How many batteries required to run"], out var batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'How many batteries required to run' column of the step table must be an integer value");
					}
					var thisBattery = new Battery {
						BatteryType = thisRow["Battery Type"],
						Manufacturer = thisRow["Manufacturer"],
						NumberPerPackage = batteriesPerPackage,
						RequiredToRun = batteriesRequired
					};
					listOfBatteries.Add(thisBattery);
				}
				if (listOfBatteries.Any())
				{
					// setter adds a table row for each battery in the list and enters data into each column
					_productIncludesBattery.Batteries = listOfBatteries;
					_productIncludesBattery.DeleteEmptyBatteryRows();
					return;
				}
				Report.Error("There were no batteries to add");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
	}
}

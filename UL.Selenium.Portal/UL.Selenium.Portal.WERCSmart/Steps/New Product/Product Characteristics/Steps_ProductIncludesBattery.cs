using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsProductIncludesBattery
	{
		private ProductIncludesBattery ProductIncludesBattery => new ProductIncludesBattery();

		[RegexStepDefinition(@"For 'Indicate how battery is packaged' I select: (.*)")]
		public void ForIndicateHowBatteryIsPackagedISelect(string option)
		{
			Report.IsTrue(this.ProductIncludesBattery.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			this.ProductIncludesBattery.IndicateHowBatteryIsPackaged = option;
			Report.IsTrue(this.ProductIncludesBattery.IndicateHowBatteryIsPackaged == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		/// <summary>
		/// Adds batteries to the Contains Battery page by constructing a List Battery objects using the table data
		/// Accepts parameter Manufacturer = any to select any returned manufacturer by looping through 'a', 'b', 'c', 'd' search inputs
		/// It saves the manufacturer to context as battery_manufacturer1, battery_manufacturer2 according to the order they were added (table row number)
		/// </summary>
		/// <param name="table"></param>
		[RegexStepDefinition(@"I add the following batteries:")]
		// Requires a table with the headings: | Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As |
		public void AddTheFollowingBatteries(Table table)
		{
			try
			{
				var listOfBatteries = new List<Battery>();
				foreach (var thisRow in table.Rows)
				{
					if (!int.TryParse(thisRow["Quantity of Batteries per Package"], out var batteriesPerPackage))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries per Package' column of the step table must be an integer value");
					}
					if (!int.TryParse(thisRow["Quantity of Batteries to Operate Product"], out var batteriesRequired))
					{
						// we cannot enter a non int value to this input field. test should be fixed - throw exception and report failure
						throw new Exception("'Quantity of Batteries to Operate Product' column of the step table must be an integer value");
					}
					var thisBattery = new Battery {
						BatteryType = thisRow["Battery Type"],
						Manufacturer = thisRow["Manufacturer"],
						NumberPerPackage = batteriesPerPackage,
						RequiredToRun = batteriesRequired,
						SavedAs = thisRow["Saved As"]
					};
					listOfBatteries.Add(thisBattery);
				}
				if (listOfBatteries.Any())
				{
					// add a table row for each battery in the list and enters data into each column
					Report.Info("Adding the following batteries:");
					ReqnrollReporting.Table(table);
					this.ProductIncludesBattery.Batteries = listOfBatteries;
					Report.Info("Removing empty battery rows");
					this.ProductIncludesBattery.DeleteEmptyBatteryRows();
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

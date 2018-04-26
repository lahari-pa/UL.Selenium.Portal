using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using ResourcePool;
using SafewareReporting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag="DataSummarySheet")]
	class StepsDataSummarySheet
	{
		[StepDefinition(@"I should see the following batteries present:")]
		public void ThenIShouldSeeTheFollowingBatteriesPresent(Table information)
		{
			var expected = information.CreateSet<Battery>();
			var dataSummarySheet = new DataSummary();
			var displayed = dataSummarySheet.GetDisplayedBatteries();
			foreach (var expectedBattery in expected)
			{
				Report.Info("Checking battery with type: " + expectedBattery.BatteryType + " and Manufacturer: " + expectedBattery.Manufacturer);
				var matchingType = displayed.Where(x => x.BatteryType == expectedBattery.BatteryType);
				if (matchingType.Count() == 0)
				{
					Report.Failure("No batteries of type: " + expectedBattery.BatteryType + " were displayed!");
					continue;
				}

				bool passed = false;
				foreach (var matched in matchingType)
				{
					if (matched.Manufacturer.Contains(expectedBattery.Manufacturer) && matched.NumberPerPackage == expectedBattery.NumberPerPackage && matched.RequiredToRun == expectedBattery.RequiredToRun)
					{
						passed = true;
						break;
					}
				}

				Report.IsTrue(passed, "Battery was not found on the data summary screen!", "Battery was successfully found on the data summary screen!");
			}
		}


		[StepDefinition(@"I confirm that I see the following option for private label question: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingOptionForPrivateLabelQuestion(string message)
		{
				var dataSummarySheet = new DataSummary();
				var found = dataSummarySheet.GetPrivateLabelStatement();

				Report.IsTrue(found.Trim() == message.Trim(),
					"private label option was not as expected! Expected: " + message + ", but found: " + found + "!",
					"private label option was showing: " + message + ", as expected!");
		}




	}
}

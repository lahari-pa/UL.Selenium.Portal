using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX
{
	[Binding]
	public class Transformations
	{
		[StepArgumentTransformation]
		public List<Battery> GetBatteryParemeters(Table table)
		{
			return table.Rows.Select(row => new Battery() {
				BatteryType = row["Battery Type"],
				Manufacturer = row["Manufacturer"],
				NumberPerPackage = Convert.ToInt32(row["Number of batteries per package"]),
				RequiredToRun = Convert.ToInt32(row["How many batteries required to run "])
			}).ToList();
		}
	}
}

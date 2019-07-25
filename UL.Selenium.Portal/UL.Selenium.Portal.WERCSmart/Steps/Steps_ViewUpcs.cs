using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ViewUpcs")]
	class Steps_ViewUpcs
	{
		[StepDefinition(@"I save the UPCs associated to the product as: (.*)")]
		public void SaveUpcsToContext(string savedAs)
		{
			var upcNumbers = new List<string>();
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			foreach (ViewUpcs.ProductUpc upc in upcs)
			{
				upcNumbers.Add(upc.UpcNumber);
			}
			Report.Info("there are " + upcNumbers.Count + " upc numbers to save");
			Report.Info("Saving to context as: " + savedAs);
			Context.AddToContext(savedAs, upcNumbers);
		}

	}
}

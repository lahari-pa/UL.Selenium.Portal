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

		[StepDefinition(@"I confirm that the number of UPCs equals the number saved as: (.*)")]
		public void ConfirmThatNumberOfUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of UPCs did not match the number saved!",
				"Number of UPCs matches number saved.");
		}

		[StepDefinition(@"I confirm that the number of normal UPCs equals the number saved as: (.*)")]
		public void ConfirmThatNumberOfNormalUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().NormalUPCs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of normal UPCs did not match the number saved!",
				"Number of normal UPCs matches number saved.");
		}

		[StepDefinition(@"I confirm that the number of Case UPCs equal the number saved as: (.*)")]
		public void ConfirmThatNumberOfCaseUPCsEqualsNumberSavedAs(string savedAs)
		{
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().CaseUPCs();
			int numUPCs = 0;
			int.TryParse(Context.GetFromContext(savedAs)?.ToString(), out numUPCs);
			Report.IsTrue(numUPCs == upcs.Count, "Number of Case UPCs did not match the number saved!",
				"Number of Case UPCs matches number saved.");
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Reporting_Module.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_RegulatoryInformation1
	{
		RegulatoryInformation1 _regulatoryInformation1 = new RegulatoryInformation1();

		[StepDefinition(@"For 'U\.S\. Toxic Substances Control Act \(TSCA\) status' I select: (.*)")]
		public void ForUSToxicSubstancesControlActTSCAStatusISelect(string option)
		{
			Report.IsTrue(this._regulatoryInformation1.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			this._regulatoryInformation1.TscaStatus = option;
			Report.IsTrue(this._regulatoryInformation1.TscaStatus == option,
				"Failed to set TSCA status: " + option,
				"Successfully set TSCA status: " + option);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_ToxicityCharacteristicsLeachingProcedure
	{
		private TCLP Tclp => new TCLP();

		[StepDefinition(@"I set 'Product has had TCLP; Report is available' to: (No|Yes)")]
		public void SetTclpReportIsAvailableTo(string noOrYes)
		{
			Report.IsTrue(this.Tclp.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product Characteristics tab has not loaded",
				"Product Characteristics tab is loaded.");
			var expected = noOrYes == "Yes";
			this.Tclp.ProductHasTclp = expected;
			Report.IsTrue(this.Tclp.ProductHasTclp == expected,
				"Failed to set Product has had TCLP: " + noOrYes,
				"Successfully set Product has had TCLP: " + noOrYes);
		}

		[StepDefinition(@"I set all the metal presence value to: (Yes|No)")]
		public void GivenISetAllTheMetalPresenceValueTo(string noOrYes)
		{
			Report.IsTrue(this.Tclp.WaitForMetalSection(30), "Metal section has failed to load.",
				"Metal section has loaded");
			var metals = this.Tclp.GetAllMetalNames();
			var listOfMetalSettings = new List<TCLP.MetalPresence>();
			foreach (var thisMetal in metals)
			{
				listOfMetalSettings.Add(new TCLP.MetalPresence(thisMetal, "No"));
			}
			Report.Info("Setting the Metal Presence values");
			this.Tclp.Metals = listOfMetalSettings;
			Report.Info("Checking the Metal Presence values are correct");
			var checkOutcome = this.Tclp.Metals;
			var pass = true;
			foreach (var thisMetalPresence in listOfMetalSettings)
			{
				if (checkOutcome.Any(x => x.Metal == thisMetalPresence.Metal && x.Presence == thisMetalPresence.Presence))
				{
					continue;
				}
				pass = false;
				Report.Info("Metal: " + thisMetalPresence.Metal + " was not set to: " + thisMetalPresence.Presence + " as was expected");
			}
			Report.IsTrue(pass, "Failed to set all metal presence values", "Successfully set all metal presence values");
		}
	}
}

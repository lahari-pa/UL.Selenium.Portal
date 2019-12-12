using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_AdditionalProductInformation
	{
		private AdditionalProductInformation AdditionalProductInformation => new AdditionalProductInformation();

		[StepDefinition(@"I set 'Product is solely for the Retailer's use' to: (No|Yes)")]
		public void SetProductIsSolelyForTheRetailersUseTo(string noOrYes)
		{
			Report.IsTrue(this.AdditionalProductInformation.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this.AdditionalProductInformation.SolelyForRetailersUse = expected;
			Report.IsTrue(this.AdditionalProductInformation.SolelyForRetailersUse == expected,
				"Failed to set Product is solely for the Retailer's use: " + noOrYes,
				"Successfully set Product is solely for the Retailer's use: " + noOrYes);
		}

		[StepDefinition(@"I set 'Product is a Retailers Private Label or Brand' to: (No|Yes)")]
		public void SetProductIsRetailersPrivateLabelOrBrandTo(string noOrYes)
		{
			Report.IsTrue(this.AdditionalProductInformation.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this.AdditionalProductInformation.RetailersPrivateLabelOrBrand = expected;
			Report.IsTrue(this.AdditionalProductInformation.RetailersPrivateLabelOrBrand == expected,
				"Failed to set Product is retailers private label or brand: " + noOrYes,
				"Successfully set Product is retailers private label or brand: " + noOrYes);
		}

		[StepDefinition(@"I set 'Product is shipped directly' to: (No|Yes)")]
		public void SetProductIsShippedDirectlyTo(string noOrYes)
		{
			Report.IsTrue(this.AdditionalProductInformation.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this.AdditionalProductInformation.ProductShippedDirectly = expected;
			Report.IsTrue(this.AdditionalProductInformation.ProductShippedDirectly == expected,
				"Failed to set product shipped directly value to: " + noOrYes,
				"Successfully set product shipped directly value to: " + noOrYes);
		}

		[StepDefinition(@"I set 'Product has been classified using OSHA' to: (No|Yes)")]
		public void SetProductHasBeenClassifiedOSHATo(string noOrYes)
		{
			Report.IsTrue(this.AdditionalProductInformation.WaitForTab(NewProduct.Tab.ProductType), "Product Type has not loaded", "Product Type tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this.AdditionalProductInformation.ProductClassifiedUnderOSHA = expected;
			Report.IsTrue(this.AdditionalProductInformation.ProductClassifiedUnderOSHA == expected,
				"Failed to set product has been classified using OSHA value to: " + noOrYes,
				"Successfully set product has been classified using OSHA value to: " + noOrYes);
		}

		[StepDefinition(@"I set 'California's Cleaning Product' to: (No|Yes)")]
		public void SetCaliforniaCleaningProductTo(string noOrYes)
		{
			Report.IsTrue(this.AdditionalProductInformation.WaitForTab(NewProduct.Tab.ProductType), "Product Type has not loaded", "Product Type tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this.AdditionalProductInformation.IsCaliforniaCleaning = expected;
			Report.IsTrue(this.AdditionalProductInformation.IsCaliforniaCleaning == expected,
				"Failed to set California Cleaning value to: " + noOrYes,
				"Successfully set California Cleaning value to: " + noOrYes);
		}

		[StepDefinition(@"In the Additional Information Page the check box for: (.*) should be: (checked|unchecked)")]
		public void GivenInTheAdditionalInformationPageTheCheckBoxXShouldBeCheckedOrUnchecked(string country, string checkedOrUnchecked)
		{
			Report.IsTrue(this.AdditionalProductInformation.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			bool expected = checkedOrUnchecked == "checked";
			if (expected)
			{
				Report.IsTrue(this.AdditionalProductInformation.ProductsMayBeSold.Contains(country),
					"Products may be sold is not set up as expected", "Products may be sold is set up as expected.");
			}
			else
			{
				Report.IsTrue(!this.AdditionalProductInformation.ProductsMayBeSold.Contains(country),
					"Products may be sold is not set up as expected", "Products may be sold is set up as expected.");
			}
		}
	}
}

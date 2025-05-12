using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:CreateTheKit")]
	class CreateTheKitSteps
	{
		[RegexStepDefinition(@"In the Create the Kit page add product: (.*)")]

		public void SelectProductCreateTheKit(string product)
		{
			CreateTheKit createTheKit = new CreateTheKit();
			ChemicalSearchBox searchBoxPrototype = new ChemicalSearchBox();
			if (Report.IsTrue(createTheKit.SearchInputExists(), $"Failed to find the search input in the 'Create the Kit' page", "Successfully found the search input in the 'Create the Kit' page"))
			{
				Report.IsTrue(createTheKit.SearchInputClick(), $"Failed to click in search input", "Successfully clicked in search input");
			}
			if (Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failed to find the search input in the 'Create the Kit' page", "Successfully found the search input in the 'Create the Kit' page"))
			{
				Report.IsTrue(searchBoxPrototype.SearchInputEnterText(product), "Failed to enter text in search input", "Successfully entered text in search input");
			}
			Report.IsTrue(searchBoxPrototype.SearchResultsExists(), "Failed to find search results", "Successfully found search results");
			var homePage = new Selenium_Classes.ChooseGoodGuide.ChooseGoodGuide_Homepage();
			homePage.WaitLoading();
			Report.IsTrue(searchBoxPrototype.SearchComponentGet(product).Click(), $"Failed to select {product} in the 'Create the Kit' page", $"Successfully selected {product} in the 'Create the Kit' page");
		}

	}
}

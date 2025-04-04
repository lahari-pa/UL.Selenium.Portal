using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class InternalInformationRevisions : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[@id='internalInfoRevisionsGrid']");
		IWebElement SearchButton(string label) => this.ContainerElement.FindElement(By.XPath($".//div[label[contains(text(), '{label}')]]//i[@class= 'fa fa-search']"));
		IWebElement SearchInput(string label) => this.ContainerElement.FindElement(By.XPath($".//div[label[contains(text(), '{label}')]]//input"));
		IWebElement SearchBrandSelect => this.ContainerElement.FindElement(By.XPath($".//div[label[contains(text(), 'Brand')]]//select"));
		private List<InternalInfoRevisionsProductsTableRow> MyProductsTableRows => this.FindElements(By.XPath("//tbody//tr"), 1).Select(x => new InternalInfoRevisionsProductsTableRow(x)).ToList();
		public InternalInfoRevisionsProductsTableRow InternalInfoRevisionsProductsTableRowSearchById(string productId) => this.MyProductsTableRows.FirstOrDefault(x => x.ProductId.Equals(productId, System.StringComparison.Ordinal));

		#endregion

		#region Methods
		public bool SearchButtonExists(string label)
		{
			Report.Info($"Attempting to find search button for '{label}'");
			return this.SearchButton(label) != null;
		}
		public bool SearchButtonClick(string label)
		{
			Report.Info($"Attempting to click search button for '{label}'");
			return this.SearchButton(label).TryClick();
		}
		public bool SearchInputExists(string label)
		{
			Report.Info($"Attempting to find search input for '{label}'");
			return this.SearchInput(label) != null;
		}
		public bool SearchInputEnterText(string label, string text)
		{
			Report.Info($"Attempting to enter text for '{label}'");
			return this.SearchInput(label).TryEnterText(text);
		}
		public bool SearchBrandSelectExists()
		{
			Report.Info($"Attempting to find select dropdown for 'Brand'");
			return this.SearchBrandSelect != null;
		}
		public bool SearchBrandSelectOption(string option)
		{
			Report.Info($"Attempting to select option for 'Brand'");
			this.SearchBrandSelect.Select(option);
			return this.SearchBrandSelect.SelectedOption() == option;
		}

		#endregion

	}
	public class InternalInfoRevisionsProductsTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string ProductId => this.ContainerElement.FindElement(By.XPath(".//td//span[contains(@data-bind, 'text: ProductID')]"), 1)?.Text;
		public string ProductName => this.ContainerElement.FindElement(By.XPath(".//td/span[contains(@data-bind, 'Name')]"), 1)?.Text;
		private IWebElement ActionLink(string link) => this.ContainerElement.FindElement(By.XPath($".//a[text()='{link}']"));
		private IWebElement ProductIdentifierInput => this.ContainerElement.FindElement(By.XPath(".//input[contains(@data-bind, 'TempIntProductID')]"));
		private IWebElement IngredientIdentifierInput => this.ContainerElement.FindElement(By.XPath(".//input[contains(@data-bind, 'TempIntFormulaID')]"));
		private IWebElement BrandSelect => this.ContainerElement.FindElement(By.XPath(".//select"));


		#endregion

		#region Methods
		public bool InternalInfoRevisionsProductsTableRowExists()
		{
			return this.ContainerElement != null;
		}
		public bool ActionLinkExists(string link)
		{
			Report.Info($"Attempt to find the '{link}' link");
			return this.ActionLink(link).Displayed;
		}
		public bool ActionLinkClick(string link)
		{
			Report.Info($"Attempt to click the '{link}' link");
			return this.ActionLink(link).TryClick();
		}
		public bool ProductIdentifierInputExists()
		{
			Report.Info($"Attempt to find the 'Product Identifier Input' input");
			return this.ProductIdentifierInput.Displayed;
		}
		public bool ProductIdentifierInputEnterText(string text)
		{
			Report.Info($"Attempt to enter text into the 'Product Identifier' input");
			return this.ProductIdentifierInput.TryEnterText(text);
		}
		public bool IngredientIdentifierInputExists()
		{
			Report.Info($"Attempt to find the 'Ingredient Identifier' input");
			return this.IngredientIdentifierInput.Displayed;
		}
		public bool IngredientIdentifierInputEnterText(string text)
		{
			Report.Info($"Attempt to enter text into the 'Ingredient Identifier' input");
			return this.IngredientIdentifierInput.TryEnterText(text);
		}
		public bool BrandSelectExists()
		{
			Report.Info($"Attempt to find the 'Brand Name' input");
			return this.BrandSelect.Displayed;
		}
		public bool BrandSelectOption(string option)
		{
			Report.Info($"Attempt to select the option for 'Brand Name'");
			this.BrandSelect.Select(option);
			return this.BrandSelect.SelectedOption() == option;
		}
		#endregion


	}
}

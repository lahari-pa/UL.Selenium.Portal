using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class ForwardProductRegistrationPage : SeleniumBaseObject
	{
		#region Class Objects
		#region General Objects
		protected override By ContainerElementLocator => By.Id("dataentry");
		private IWebElement PageHeader => this.FindElement(By.XPath(".//div[@class='product-header']//h2[text()]"), 1);
		private List<IWebElement> WizardTabsList => [.. this.FindElements(By.XPath(".//div[contains(@class,'prog-step')]//a[normalize-space()]"), 1)];
		private IWebElement WizardTab(string tabLabel) => this.WizardTabsList.FirstOrDefault(x => x.Text.Equals(tabLabel, System.StringComparison.Ordinal));
		private IWebElement LabeledButton(string buttonLabel) => this.FindElement(By.XPath($".//a[contains(@class,'button')][normalize-space()='{buttonLabel}']"));
		private IWebElement SectionFormGroup(string sectionLabel) => this.FindElement(By.XPath($".//div[@class='form-group'][.//label[text()='{sectionLabel}']]"), 1);
		private IWebElement SectionTextInput(string sectionLabel) => this.SectionFormGroup(sectionLabel).FindElement(By.XPath(".//input[@type='text']"), 1);
		#endregion
		#region Product UPC Objects
		private List<ProductUpcSearchResult> ProductUpcSearchResultsList => this.FindElements(By.XPath(".//table[contains(@data-bind,'searchResults()')]//tbody//tr"), 1).Select(x=>new ProductUpcSearchResult(x)).ToList();
		public ProductUpcSearchResult ProductUpcSearchResultByProductName(string productName) => this.ProductUpcSearchResultsList.FirstOrDefault(x => x.ProductName.Equals(productName, System.StringComparison.Ordinal));
		public ProductUpcSearchResult ProductUpcSearchResultByWPSID(string wpsid) => this.ProductUpcSearchResultsList.FirstOrDefault(x => x.WPSID.Equals(wpsid, System.StringComparison.Ordinal));
		private List<SelectedProduct> SelectedProductsList => this.FindElements(By.XPath("//table[contains(@data-bind,'selectedProds()')]//tbody//tr"), 1).Select(x => new SelectedProduct(x)).ToList();
		public SelectedProduct SelectedProductByProductName(string productName) => this.SelectedProductsList.FirstOrDefault(x => x.ProductName.Equals(productName, System.StringComparison.Ordinal));
		public SelectedProduct SelectedProductByWPSID(string wpsid) => this.SelectedProductsList.FirstOrDefault(x => x.WPSID.Equals(wpsid,System.StringComparison.Ordinal));
		private IWebElement RemoveCheckedProductsButton => this.FindElement(By.XPath(".//a[contains(@data-bind,'removeCheckedProds')]"), 1);
		#endregion
		#region Select Retailers Objects
		private List<IWebElement> SelectRetailerActionLinksList => [..this.ContainerElement.FindElements(By.XPath(".//a[@class='small-link']"), 1)];
		private IWebElement SelectRetailerActionLink(string linkLabel) => this.SelectRetailerActionLinksList.FirstOrDefault(x => x.Text.Equals(linkLabel, System.StringComparison.Ordinal));
		private List<SelectableRetailer> SelectableRetailersList => [.. this.ContainerElement.FindElements(By.XPath(".//label[.//input[@type='checkbox']]"), 1).Select(x => new SelectableRetailer(x))];
		public SelectableRetailer SelectableRetailer(string label) => this.SelectableRetailersList.FirstOrDefault(x => x.Label.Equals(label, System.StringComparison.Ordinal));
		#endregion
		#region Select UPCs Objects
		private IWebElement SelectProductsTable => this.ContainerElement.FindElement(By.XPath(".//table[@class='table']"), 1);
		public List<string> SelectProductsTableColumnLabelsList => [.. this.SelectProductsTable.FindElements(By.XPath(".//th"), 1).Select(x => x.Text.Trim())];
		private List<SelectProductsProductRow> SelectProductsProductRowsList => [.. this.SelectProductsTable.FindElements(By.XPath(".//tr[contains(@data-bind,'click')]"), 1).Select(x => new SelectProductsProductRow(x))];
		public SelectProductsProductRow SelectProductsProductRowByProductName(string productName) => this.SelectProductsProductRowsList.FirstOrDefault(x => x.ProductName.Equals(productName, System.StringComparison.Ordinal));
		public SelectProductsProductRow SelectProductsProductRowByWPSID(string wpsid) => this.SelectProductsProductRowsList.FirstOrDefault(x => x.WPSID.Equals(wpsid, System.StringComparison.Ordinal));
		private IWebElement SelectUPCsTable => this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover']"), 1);
		public List<string> SelectUPCsTableColumnLabelList => [.. this.SelectUPCsTable.FindElements(By.XPath(".//th[not(.//input[@class='checkbox'])]"), 1).Select(x => x.Text.Trim())];
		private IWebElement SelectUPCsTableSelectAllCheckbox => this.SelectUPCsTable.FindElement(By.XPath(".//input[contains(@data-bind,'checkAll')]"), 1);
		private List<SelectUPCsUPCRow> SelectUPCsTableUPCRowsList => [.. this.SelectUPCsTable.FindElements(By.XPath(".//tbody//tr"), 1).Select(x => new SelectUPCsUPCRow(x))];
		public SelectUPCsUPCRow SelectUPCsTableUPCRowByUPC(string upc) => this.SelectUPCsTableUPCRowsList.FirstOrDefault(x => x.UPC.Equals(upc, System.StringComparison.Ordinal));
		public SelectUPCsUPCRow SelectUPCsTableUPCRowByProductName(string productName) => this.SelectUPCsTableUPCRowsList.FirstOrDefault(x => x.ProductName.Equals(productName, System.StringComparison.Ordinal));
		private List<IWebElement> SelectUPCsButtonsList => [.. this.FindElements(By.XPath(".//div[@class ='marTop-10']//button"), 1)];
		private IWebElement SelectUPCsButton(string buttonLabel) => this.SelectUPCsButtonsList.FirstOrDefault(x => x.Text.Trim().Equals(buttonLabel, System.StringComparison.Ordinal));
		#endregion
		#region Product Results Objects
		private List<ProductTable> ProductTablesList => [.. this.ContainerElement.FindElements(By.XPath(""), 1).Select(x => new ProductTable(x))];
		public ProductTable ProductTableByTitle(string title) => this.ProductTablesList.FirstOrDefault(x => x.Title.Equals(title, System.StringComparison.Ordinal));
		public ProductTable ProductTableByProductName(string productName) => this.ProductTablesList.FirstOrDefault(x => x.ProductName.Equals(productName, System.StringComparison.Ordinal));
		public ProductTable ProductTableByWPSID(string wpsid) => this.ProductTablesList.FirstOrDefault(x => x.WPSID.Equals(wpsid, System.StringComparison.Ordinal));
		#endregion
		#region Review & Submit Objects

		#endregion
		#endregion

		#region Class Methods
		#region Page Header Methods
		public bool PageHeaderExists()
		{
			Report.Info($"Attempting to confirm page header exists.");
			return this.PageHeader != null;
		}

		public string PageHeaderText()
		{
			Report.Info($"Attempting to get page header text.");
			return this.PageHeader.Text;
		}
		#endregion
		#region Wizard Tab List Methods
		public bool WizardTabsListExists()
		{
			Report.Info($"Attempting to confirm the Wizard Tab list exists.");
			return !this.WizardTabsList.IsNullOrEmpty();
		}

		public List<string> WizardTabsListGet()
		{
			Report.Info($"Attempting to get Wizard Tab list.");
			return [.. this.WizardTabsList.Select(x => x.Text.Trim())];
		}

		public bool WizardTabExists(string tabLabel)
		{
			Report.Info($"Attempting to confirm '{tabLabel}' wizard tab exists.");
			return this.WizardTabsList.Any(x => x.Text.Trim().Equals(tabLabel, System.StringComparison.Ordinal));
		}

		public bool WizardTabClick(string tabLabel)
		{
			Report.Info($"Attempting to click '{tabLabel}' wizard tab.");
			return this.WizardTab(tabLabel).TryClick();
		}

		public bool WizardTabActive(string tabLabel)
		{
			return this.WizardTab(tabLabel).FindElement(By.XPath("./ancestor-or-self::div[@class='prog-step active']"), 1) != null;
		}
		#endregion
		#region Select Products Methods
		#region Section Text Search Input Methods
		public bool SectionTextInputExists(string sectionLabel)
		{
			Report.Info($"Attempting to confirm '{sectionLabel}' section text input exists.");
			return this.SectionTextInput(sectionLabel) != null;
		}

		public bool SectionTextInputClick(string sectionLabel)
		{
			Report.Info($"Attempting to click '{sectionLabel}' section text input.");
			return this.SectionTextInput(sectionLabel).TryClick();
		}

		public bool SectionTextInputEnterText(string sectionLabel, string text)
		{
			Report.Info($"Attempting to enter into '{sectionLabel}' section text input: {text}");
			return this.SectionTextInput(sectionLabel).TryEnterText(text);
		}
		#endregion
		#region Product UPC Search Results List Methods
		public bool ProductUpcSearchResultsListExists()
		{
			Report.Info($"Attempting to confirm Product Upc Search Results List exists.");
			return !this.ProductUpcSearchResultsList.IsNullOrEmpty();
		}

		public bool ProductUpcSearchResultByProductNameExists(string productName)
		{
			Report.Info($"Attempting to confirm Product UPC Search Result with Product Name '{productName}' exists.");
			return this.ProductUpcSearchResultByProductName(productName) != null;
		}

		public bool ProductUpcSearchResultByWPSIDExists(string wpsid)
		{
			Report.Info($"Attempting to confirm Product UPC Search Result with WPSID '{wpsid}' exists.");
			return this.ProductUpcSearchResultByWPSID(wpsid) != null;
		}
		#endregion
		#region Selected Products List Methods
		public bool SelectedProductsListExists()
		{
			Report.Info($"Attempting to confirm Selected Product List exists.");
			return !this.SelectedProductsList.IsNullOrEmpty();
		}

		public bool SelectedProductByProductNameExists(string productName)
		{
			Report.Info($"Attempting to confirm Selected Product with Product Name '{productName}' exists.");
			return this.SelectedProductByProductName(productName) != null;
		}

		public bool SelectedProductByWPSIDExists(string wpsid)
		{
			Report.Info($"Attempting to confirm Selected Product with WPSID '{wpsid}' exists.");
			return this.SelectedProductByWPSID(wpsid) != null;
		}

		public bool RemoveCheckedProductsButtonDisplayed()
		{
			Report.Info($"Attempting to confirm Remove Checked Products Button is displayed");
			return this.RemoveCheckedProductsButton.Displayed;
		}

		public bool RemoveCheckedProductsButtonClick()
		{
			Report.Info($"Attempting to click Remove Checked Products Button.");
			return this.RemoveCheckedProductsButton.TryClick();
		}
		#endregion
		#endregion
		#region Select Retailers Methods
		public bool SelectRetailerActionLinksListExists()
		{
			Report.Info($"Attempting to confirm Select Retailer Action Links list exists.");
			return !this.SelectRetailerActionLinksList.IsNullOrEmpty();
		}

		public bool SelectRetailerActionLinkExists(string linkLabel)
		{
			Report.Info($"Attempting to confirm '{linkLabel}' Select Action Link exists.");
			return this.SelectRetailerActionLink(linkLabel) != null;
		}

		public bool SelectRetailerActionLinkClick(string linkLabel)
		{
			Report.Info($"Attempting to click '{linkLabel}' Select Retialer Action Link.");
			return this.SelectRetailerActionLink(linkLabel).TryClick();
		}

		public bool SelectableRetailersListExists()
		{
			Report.Info($"Attempting to confirm Selectable Retailers List exists.");
			return !this.SelectableRetailersList.IsNullOrEmpty();
		}

		public bool SelectableRetailerExists(string retailerLabel)
		{
			Report.Info($"Attempting to confirm '{retailerLabel}' selectable retailer exists.");
			return this.SelectableRetailer(retailerLabel) != null;
		}
		#endregion
		#region Labeled Button Methods
		public bool LabeledButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exists.");
			return this.LabeledButton(buttonLabel) != null;
		}

		public bool LabeledButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			return this.LabeledButton(buttonLabel).TryClick();
		}
		#endregion
		#region Select UPCs Methods
		#region Select Products Table Methods
		public bool SelectProductsProductRowsListExists()
		{
			Report.Info($"Attempting to confirm Select Products Product Rows list exists.");
			return !this.SelectProductsProductRowsList.IsNullOrEmpty();
		}

		public bool SelectProductsProductRowByProductNameExists(string productName)
		{
			Report.Info($"Attempting to confirm product row with '{productName}' product name exists.");
			return this.SelectProductsProductRowByProductName(productName) != null;
		}

		public bool SelectProductsProductRowByWPSIDExists(string wpsid)
		{
			Report.Info($"Attempting to confirm product row with '{wpsid}' wpsid exists.");
			return this.SelectProductsProductRowByWPSID(wpsid) != null;
		}
		#endregion

		#region Select UPCs Table Methods
		public bool SelectUPCsTableDisplayed()
		{
			Report.Info($"Attempting to confirm Select UPCs Table is displayed.");
			return this.SelectUPCsTable.Displayed;
		}

		public bool SelectUPCsTableSelectAllCheckboxExists()
		{
			Report.Info($"Attempting to confirm Select UPCs Table Select All checkbox exists.");
			return this.SelectUPCsTableSelectAllCheckbox != null;
		}

		public bool SelectUPCsTableSelectAllCheckboxClick()
		{
			Report.Info($"Attempting to click Select UPCs Table Select All checkbox.");
			return this.SelectUPCsTableSelectAllCheckbox.TryClick();
		}

		public bool SelectUPCsTableSelectAllCheckboxChecked()
		{
			Report.Info($"Attempting to confirm Select UPCs Table Select All checkbox is checked.");
			return this.SelectUPCsTableSelectAllCheckbox.Checked();
		}

		public bool SelectUPCsUPCRowByUPCExists(string upc)
		{
			Report.Info($"Attempting to confirm UPC Row with '{upc}' UPC exists.");
			return this.SelectUPCsTableUPCRowByUPC(upc) != null;
		}

		public bool SelectUPCsUPCRowByProductNameExists(string productName)
		{
			Report.Info($"Attempting to confirm UPC Row with '{productName}' Product Name exists.");
			return this.SelectUPCsTableUPCRowByProductName(productName) != null;
		}
		#endregion

		#region Select UPC Buttons Methods
		public List<string> SelectUPCsButtonsListGetLabelsList()
		{
			Report.Info($"Attempting to get Select UPCs Button Labels list.");
			return [.. this.SelectUPCsButtonsList.Where(x => x.Displayed).Select(x => x.Text?.Trim())];
		}

		public bool SelectUPCsButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' Select UPCs button exists.");
			return this.SelectUPCsButton(buttonLabel) != null;
		}

		public bool SelectUPCsButtonDisplayed(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' Select UPCs button is diplayed.");
			return this.SelectUPCsButton(buttonLabel).Displayed;
		}

		public bool SelectUPCsButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' Select UPCs button.");
			return this.SelectUPCsButton(buttonLabel).TryClick();
		}
		#endregion
		#endregion
		#region Product Results Methods
		public bool ProductTablesListExists()
		{
			Report.Info($"Attempting to confirm Product Tables list exists.");
			return !this.ProductTablesList.IsNullOrEmpty();
		}

		public List<string> ProductTablesTitlesList()
		{
			Report.Info($"Attempting to get Product Tables Titles list.");
			return [.. this.ProductTablesList.Select(x => x.Title)];
		}

		public List<string> ProductTablesProductNamesList()
		{
			Report.Info($"Attempting to get Product Tables Product Names list.");
			return [.. this.ProductTablesList.Select(x => x.ProductName)];
		}

		public List<string> ProductTablesWPSIDsList()
		{
			Report.Info($"Attempting to get Product Tables WPSIDs list.");
			return [.. this.ProductTablesList.Select(x => x.WPSID)];
		}

		public bool ProductTableByTitleExists(string title)
		{
			Report.Info($"Attempting to confirm Product Table with '{title}' as Title exists.");
			return this.ProductTableByTitle(title) != null;
		}

		public bool ProductTableByProductNameExists(string productName)
		{
			Report.Info($"Attempting to confirm Product Table with '{productName}' as Product Name exists.");
			return this.ProductTableByProductName(productName) != null;
		}

		public bool ProductTableByWPSIDExists(string wpsid)
		{
			Report.Info($"Attempting to confirm Product Table with '{wpsid}' as WPSID exists.");
			return this.ProductTableByWPSID(wpsid) != null;
		}
		#endregion
		#endregion
	}

	public class ProductUpcSearchResult(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string WPSID => this.ContainerElement.FindElement(By.XPath(".//label[@data-bind='text: wpsid']"), 1)?.Text;
		public string ProductName => this.ContainerElement.FindElement(By.XPath(".//label[@data-bind='text: name']"),1)?.Text;
		private IWebElement Checkbox => this.ContainerElement.FindElement(By.XPath(".//input[@type='checkbox']"), 1);
		private IWebElement IsInRecertification => this.ContainerElement.FindElement(By.XPath(".//label[@data-bind='visible: isInRecertification']"), 1);
		private IWebElement HasUpcDups => this.ContainerElement.FindElement(By.XPath(".//label[@data-bind='visible: hasUpcDups']"), 1);
		#endregion

		#region Class Methods
		public bool Click()
		{
			Report.Info($"Attempting to click '{this.ProductName}' search result.");
			return this.ContainerElement.TryClick();
		}
		public bool CheckboxDisplayed()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' search result checkbox is displayed.");
			return this.Checkbox.Displayed;
		}

		public bool CheckboxClick()
		{
			Report.Info($"Attempting to click '{this.ProductName}' search result checkbox.");
			return this.Checkbox.TryClick();
		}

		public bool CheckboxChecked()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' search result checkbox is checked.");
			return this.Checkbox.Checked();
		}

		public bool IsInRecertificationDisplayed()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' search result 'is in recertification' label is displayed.");
			return this.IsInRecertification.Displayed;
		}

		public string IsInRecertificationText()
		{
			Report.Info($"Attempting to get '{this.ProductName}' search result 'is in recertification' label text.");
			return this.IsInRecertification.Text;
		}

		public bool HasUpcDupsDisplayed()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' search result 'has duplicate upc' label is displayed.");
			return this.HasUpcDups.Displayed;
		}

		public string HasUpcDupsText()
		{
			Report.Info($"Attempting to get '{this.ProductName}' search result 'has duplicate upc' label text.");
			return this.HasUpcDups.Text;
		}
		#endregion
	}

	public partial class SelectedProduct(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		private IWebElement Checkbox => this.ContainerElement.FindElement(By.XPath(".//input[@type='checkbox']"), 1);
		private string Label => this.ContainerElement.FindElement(By.XPath(".//label[@data-bind]"), 1)?.Text;
		private List<string> LabelParts => [.. SelectedProductRegex().Split(this.Label)];
		public string WPSID => this.LabelParts[0];
		public string ProductName => this.LabelParts[1];
		#endregion

		#region Class Methods
		[GeneratedRegex("^\\((.*)\\)\\s(.*)$")]
		private static partial Regex SelectedProductRegex();
		public bool CheckboxDisplayed()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' selected product checkbox is displayed.");
			return this.Checkbox.Displayed;
		}

		public bool CheckboxClick()
		{
			Report.Info($"Attempting to click '{this.ProductName}' selected product checkbox.");
			return this.Checkbox.TryClick();
		}

		public bool CheckboxChecked()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' selected product checkbox is checked.");
			return this.Checkbox.Checked();
		}
		#endregion
	}

	public class SelectableRetailer(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string Label => this.ContainerElement.FindElement(By.XPath(".//span[text()]"), 1)?.Text;
		private IWebElement Checkbox => this.ContainerElement.FindElement(By.XPath(".//input[@type='checkbox']"), 1);
		#endregion

		#region Class Methods
		public bool CheckboxClick()
		{
			Report.Info($"Attempting to click '{this.Label}' Selectable Retailer checkbox.");
			return this.Checkbox.TryClick();
		}

		public bool CheckboxChecked()
		{
			Report.Info($"Attempting to confirm '{this.Label}' Selectable Retailer checkbox is checked.");
			return this.Checkbox.Checked();
		}

		public bool IsRecent()
		{
			Report.Info($"Attempting to confirm '{this.Label}' Selectable Retailer is in Recent Section.");
			return this.ContainerElement.FindElement(By.XPath("./ancestor-or-self::div[@class='most-recent']"), 1) != null;
		}
		#endregion
	}

	public class SelectProductsRetailerRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string Retailer => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'identifier')]"), 1)?.GetAttribute("title");
		public string RetailerLabel => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'identifier')]"), 1)?.Text;
		public string PrivateLabel => this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'PrivateLabel')]//p"), 1)?.Text;
		public string SelectVendor => this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'vendor')]//p"),1)?.Text; //This may need to be updated for vendor values
		private IWebElement RemoveButton => this.ContainerElement.FindElement(By.XPath(".//a[@title='Remove']"), 1);
		#endregion

		#region Class Methods
		public bool RemoveButtonExists()
		{
			Report.Info($"Attempting to confirm '{this.Retailer}' retailer row remove button exists.");
			return this.RemoveButton != null;
		}

		public bool RemoveButtonDisplayed()
		{
			Report.Info($"Attempting to confirm '{this.Retailer}' retailer row remove button is displayed.");
			return this.RemoveButton.Displayed;
		}

		public bool RemoveButtonClick()
		{
			Report.Info($"Attempting to click '{this.Retailer}' retailer row remove button.");
			return this.RemoveButton.TryClick();
		}
		#endregion
	}

	public class SelectProductsProductRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string WPSID => this.ContainerElement.FindElement(By.XPath(".//label[contains(@data-bind,'wpsid')]"), 1)?.Text;
		public string ProductName => this.ContainerElement.FindElement(By.XPath(".//p[contains(@data-bind,'product.name')]"), 1)?.Text;
		private List<SelectProductsRetailerRow> SelectProductsRetailerRowsList => [.. this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'fwd-retailer-row')]"), 1).Select(x => new SelectProductsRetailerRow(x))];
		public SelectProductsRetailerRow SelectProductsRetailerRowByRetailer(string retailer) => this.SelectProductsRetailerRowsList.FirstOrDefault(x => x.Retailer.Equals(retailer, System.StringComparison.Ordinal));
		public SelectProductsRetailerRow SelectProductsRetailerRowByRetailerLabel(string retailerLabel) => this.SelectProductsRetailerRowsList.FirstOrDefault(x => x.RetailerLabel.Equals(retailerLabel, System.StringComparison.Ordinal));
		private IWebElement ActionsLink(string linkLabel) => this.ContainerElement.FindElement(By.XPath($".//a[text() ='{linkLabel}']"), 1);
		public bool Active => this.ContainerElement.GetAttribute("class").Contains("active");
		#endregion

		#region Class Methods
		public bool Click()
		{
			Report.Info($"Attempting to click '{this.ProductName}' Product Row.");
			return this.ContainerElement.TryClick();
		}

		public bool SelectProductsRetailerRowsListExists()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' Product Row Retailer Rows list exists.");
			return !this.SelectProductsRetailerRowsList.IsNullOrEmpty();
		}

		public List<string> SelectProductsRetailerRowsListGetRetailers()
		{
			Report.Info($"Attempting get '{this.ProductName}' Product Row Retailers List.");
			List<string> retailers = [.. this.SelectProductsRetailerRowsList.Select(x => x.Retailer)];
			return retailers;
		}

		public List<string> SelectProductsRetailerRowsListGetRetailerLabels()
		{
			Report.Info($"Attempting get '{this.ProductName}' Product Row Retailer Labels List.");
			List<string> retailerLabels = [.. this.SelectProductsRetailerRowsList.Select(x => x.RetailerLabel)];
			return retailerLabels;
		}

		public bool ActionsLinkExists(string linkLabel)
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' Product Row '{linkLabel}' Actions Link exists.");
			return this.ActionsLink(linkLabel) != null;
		}

		public bool ActionsLinkClick(string linkLabel)
		{
			Report.Info($"Attempting to click '{this.ProductName}' Product Row '{linkLabel}' Actions Link.");
			return this.ActionsLink(linkLabel).TryClick();
		}
		#endregion
	}

	public class SelectUPCsUPCRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string ProductName => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'name.field')]"), 1)?.Text.Trim();
		public string UPC => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'upcNumber.field')]"), 1)?.Text.Trim();
		public string ContainerType => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'typeToString()')]"), 1)?.Text.Trim();
		public string Size => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'size.field')]"), 1)?.Text.Trim();
		public string InternalSKU => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'packListingToString()')]"), 1)?.Text.Trim();
		public List<string> CertificationsList => [.. this.ContainerElement.FindElements(By.XPath(".//div[@data-bind='with: upc']//div[text()]"), 1).Select(x => x?.Text.Trim())];
		public string Transportation => this.ContainerElement.FindElement(By.XPath(".//span[@data-bind='text: TextLine']"), 1)?.Text;
		public List<string> DestinationRetailersList => [.. this.ContainerElement.FindElements(By.XPath(".//span[contains(@data-bind,'text: identifier')]"), 1).Select(x => x?.Text.Trim())];
		private IWebElement Checkbox => this.ContainerElement.FindElement(By.XPath(".//input[@type='checkbox']"), 1);
		private IWebElement ActionsLink(string linkLabel) => this.ContainerElement.FindElement(By.XPath($".//a[text()='{linkLabel}']"), 1);
		#endregion

		#region Class Methods
		public bool ActionsLinkExists(string linkLabel)
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' UPC row '{linkLabel}' Actions link exists.");
			return this.ActionsLink(linkLabel) != null;
		}

		public bool ActionsLinkClick(string linkLabel)
		{
			Report.Info($"Attempting to click '{this.ProductName}' UPC row '{linkLabel}' Actions link.");
			return this.ActionsLink(linkLabel).TryClick();
		}

		public bool CheckboxExists()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' UPC row checkbox exists.");
			return this.Checkbox != null;
		}

		public bool CheckboxClick()
		{
			Report.Info($"Attempting to click '{this.ProductName}' UPC row checkbox.");
			return this.Checkbox.TryClick();
		}

		public bool CheckboxChecked()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' UPC row checkbox is clicked.");
			return this.Checkbox.Checked();
		}
		#endregion
	}

	public partial class ProductTable(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string Title => this.ContainerElement.FindElement(By.XPath(".//th//span[@data-bind]"), 1)?.Text.Trim();
		private List<string> TitleParts => [.. ProductTableRegex().Split(this.Title)];
		public string WPSID => this.TitleParts[0];
		public string ProductName => this.TitleParts[1];
		private List<ProductTableRow> ProductTableRowsList => [.. this.ContainerElement.FindElements(By.XPath(".//tbody//tr"), 1).Select(x => new ProductTableRow(x))];
		public ProductTableRow ProductTableRowByUPC(string upc) => this.ProductTableRowsList.FirstOrDefault(x => x.UPC.Equals(upc, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		[GeneratedRegex("^(.*)\\s-\\s(.*)$")]
		private static partial Regex ProductTableRegex();
		public bool ProductTableRowsListExists()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' Product Table Rows list exists.");
			return !this.ProductTableRowsList.IsNullOrEmpty();
		}

		public List<string> ProductTableRowsUPCsList()
		{
			Report.Info($"Attempting to get '{this.ProductName}' Product Table UPCs list.");
			return [.. this.ProductTableRowsList.Select(x => x.UPC)];
		}

		public bool ProductTableRowByUPCExists(string upc)
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' Product Table '{upc}' Row exists.");
			return this.ProductTableRowByUPC(upc) != null;
		}
		#endregion
	}

	public class ProductTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string UPC => this.ContainerElement.FindElement(By.XPath(".//span[contains(@data-bind,'upcNumber')]"), 1)?.Text.Trim();
		public List<string> DestinationRetailersList => [.. this.ContainerElement.FindElements(By.XPath(".//span[contains(@data-bind,'identifier')]"), 1).Select(x => x?.Text.Trim())];
		private List<IWebElement> ActionsLinksList => [.. this.ContainerElement.FindElements(By.XPath(".//td//a[@data-bind]"), 1)];
		private IWebElement ActionsLinkByLabel(string linkLabel) => this.ActionsLinksList.FirstOrDefault(x => x.Text.Trim().Equals(linkLabel, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		public bool DestinationRetailersListExists()
		{
			Report.Info($"Attempting to confirm '{this.UPC}' Product Table Row Destination Retailers list exists.");
			return !this.DestinationRetailersList.IsNullOrEmpty();
		}

		public bool ActionsLinksListExists()
		{
			Report.Info($"Attempting to confirm '{this.UPC}' Product Table Row Actions Links list exists.");
			return !this.ActionsLinksList.IsNullOrEmpty();
		}

		public List<string> ActionsLinksLabelsList()
		{
			Report.Info($"Attempting to get '{this.UPC}' Product Table Row Actions links labels list.");
			return [.. this.ActionsLinksList.Select(x => x.Text.Trim())];
		}

		public bool ActionsLinkByLabelExists(string linkLabel)
		{
			Report.Info($"Attempting to confirm '{this.UPC}' Product Table Row '{linkLabel}' Actions Link exists.");
			return this.ActionsLinkByLabel(linkLabel) != null;
		}

		public bool ActionsLinkByLabelClick(string linkLabel)
		{
			Report.Info($"Attempting to click '{this.UPC}' Product Table Row '{linkLabel}' Actions Link.");
			return this.ActionsLinkByLabel(linkLabel).TryClick();
		}
		#endregion
	}
}

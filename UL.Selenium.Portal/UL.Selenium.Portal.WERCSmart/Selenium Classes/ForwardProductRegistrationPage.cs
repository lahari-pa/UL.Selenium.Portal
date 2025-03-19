using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Windows.Media.Converters;
using System.Windows.Media.Media3D;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ForwardProductRegistrationPage : SeleniumBaseObject
	{
		#region Class Objects
		#region General Objects
		protected override By ContainerElementLocator => By.Id("dataentry");
		private IWebElement PageHeader => this.FindElement(By.XPath(".//div[@class='product-header']//h2[text()]"), 1);
		private List<IWebElement> WizardTabsList => this.FindElements(By.XPath(".//div[contains(@class,'prog-step')]//a[normalize-space()]"), 1).ToList();
		private IWebElement WizardTab(string tabLabel) => this.WizardTabsList.FirstOrDefault(x => x.Text.Equals(tabLabel));
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
		public SelectableRetailer SelectableRetailerLabeled(string label) => this.SelectableRetailersList.FirstOrDefault(x => x.Label.Equals(label, System.StringComparison.Ordinal));
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
			List<string> output = new List<string>();
			this.WizardTabsList.ForEach(x => output.Add(x.Text));
			return output;
		}

		public bool WizardTabExists(string tabLabel)
		{
			Report.Info($"Attempting to confirm '{tabLabel}' wizard tab exists.");
			return this.WizardTabsList.Any(x=>x.Text.Equals(tabLabel));
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
		#region Select Products & UPCs Methods
		#region Section Text Input Methods
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

		public bool ProductUpcSearchResultByProductNameClick(string productName)
		{
			Report.Info($"Attempting to click Product Name UPC Search Result with Product Name '{productName}'.");
			return this.ProductUpcSearchResultByProductName(productName).TryClick();
		}

		public bool ProductUpcSearchResultByWPSIDExists(string wpsid)
		{
			Report.Info($"Attempting to confirm Product UPC Search Result with WPSID '{wpsid}' exists.");
			return this.ProductUpcSearchResultByWPSID(wpsid) != null;
		}

		public bool ProductUpcSearchResultByWPSIDClick(string wpsid)
		{
			Report.Info($"Attempting to click Product UPC Search Result with WPSID '{wpsid}'.");
			return this.ProductUpcSearchResultByWPSID(wpsid).TryClick();
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
		#endregion
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
			return this.SelectableRetailerLabeled(retailerLabel) != null;
		}
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
		public bool TryClick()
		{
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
}

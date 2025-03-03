using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	internal class MyProductsPage : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[@id='products-grid'][.//*[@class='ws-panel-title'][text()='My Products']]");
		private IWebElement PageInfoIcon => this.FindElement(By.XPath("//i[contains(@class,'fa-question-circle')]"), 1);
		private List<IWebElement> StatusFilterList => this.FindElements(By.XPath("//ul[contains(@class, 'status-filters')]//a"), 1).ToList();
		private IWebElement StatusFilter(string statusFilterLabel) => this.StatusFilterList.Where(x => string.Equals(x.Text, statusFilterLabel)).FirstOrDefault();
		private IWebElement LabeledButton(string buttonLabel) => this.FindElement(By.XPath($"//a[normalize-space()='{buttonLabel}']"), 1);
		private IWebElement MoreFiltersPanel => this.FindElement(By.Id("more-filters-panel"), 1);
		private IWebElement Checkbox(string checkboxLabel) => this.FindElement(By.XPath($".//label[normalize-space() = '{checkboxLabel}']//input[@type='checkbox']"), 1);
		private IWebElement LabeledDropdown(string dropdownLabel) => this.FindElement(By.XPath($"//div[contains(@class,'form-group')][.//label[@class='control-label'][normalize-space()='{dropdownLabel}']]//select"), 1);
		private List<IWebElement> LabeledDropdownOptionsList(string dropdownLabel) => this.LabeledDropdown(dropdownLabel).FindElements(By.XPath("//option"), 1).ToList();
		private IWebElement LabeledDropdownOption(string dropdownLabel, string dropdownOption) => this.LabeledDropdownOptionsList(dropdownLabel).Where(x => x.Text.Trim() == dropdownOption).FirstOrDefault();
		#endregion

		#region Methods
		#region Page Info Icon Methods
		public bool PageInfoIconExists()
		{
			Report.Info($"Attempting to confirm page info icon exists.");
			return this.PageInfoIcon != null;
		}

		public void PageInfoIconHover()
		{
			Report.Info($"Attempting to hover over the page info icon.");
			this.PageInfoIcon.Hover();
		}

		public bool PageInfoIconTextDisplayed()
		{
			Report.Info($"Attempting to confirm page info icon text is displayed.");
			return this.PageInfoIcon.GetAttribute("aria-describedby") != null;
		}

		public bool PageInfoMoreFiltersPanelExpanded()
		{
			Report.Info($"Attempting to confirm More Filters panel is expanded");
			return this.MoreFiltersPanel.GetAttribute("aria-expanded") == "true";
		}
		#endregion

		#region Status Filter List Methods
		public List<string> StatusFilterListGet()
		{
			Report.Info($"Attempting to get the list of status filters.");
			List<string> output = new List<string>();
			this.StatusFilterList.ForEach(x => output.Add(x.Text));
			return output;
		}
		public bool StatusFilterExists(string statusFilterLabel)
		{
			Report.Info($"Attempting to confirm '{statusFilterLabel}' status filter exists.");
			return this.StatusFilter(statusFilterLabel) != null;
		}

		public bool StatusFilterClick(string statusFilterLabel)
		{
			Report.Info($"Attempting to click '{statusFilterLabel}' status filter.");
			return this.StatusFilter(statusFilterLabel).TryClick();
		}

		public bool StatusFilterActive(string statusFilterLabel)
		{
			Report.Info($"Attempting to confirm '{statusFilterLabel}' status filter is active.");
			return this.StatusFilter(statusFilterLabel).GetAttribute("class").Contains("active");
		}
		#endregion

		#region Labeled Button Methods
		public bool LabeledButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exits.");
			return this.LabeledButton(buttonLabel) != null;
		}

		public bool LabeledButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			return this.LabeledButton(buttonLabel).TryClick();
		}
		#endregion

		#region More Filters Panel Methods
		public bool MoreFiltersPanelExists()
		{
			Report.Info($"Attempting to confirm more filters panel exists.");
			return this.MoreFiltersPanel != null;
		}

		public bool MoreFiltersPanelExpanded()
		{
			Report.Info($"Attempting to confirm more filters panel is expanded.");
			return this.MoreFiltersPanel.GetAttribute("@aria-expanded") == "true";
		}
		#endregion

		#region Checkbox Methods
		public bool CheckboxExists(string checkboxLabel)
		{
			Report.Info($"Attempting to confirm '{checkboxLabel}' checkbox exists.");
			return this.Checkbox(checkboxLabel) != null;
		}

		public bool CheckboxClick(string checkboxLabel)
		{
			Report.Info($"Attempting to click '{checkboxLabel}' checkbox.");
			return this.Checkbox(checkboxLabel).TryClick();
		}

		public bool CheckboxChecked(string checkboxLabel)
		{
			Report.Info($"Attempting to confirm '{checkboxLabel}' checkbox is checked.");
			return this.Checkbox(checkboxLabel).Checked();
		}
		#endregion

		#region Labeled Dropdown Methods
		public bool LabeledDropdownExists(string dropdownLabel)
		{
			Report.Info($"Attempting to confirm '{dropdownLabel}' labeled dropdown exists.");
			return this.LabeledDropdown(dropdownLabel) != null;
		}

		public bool LabeledDropdownClick(string dropdownLabel)
		{
			Report.Info($"Attempting to click '{dropdownLabel}' labeled dropdown.");
			return this.LabeledDropdown(dropdownLabel).TryClick();
		}

		public string LabeledDropdownValue(string dropdownLabel)
		{
			Report.Info($"Attempting to get '{dropdownLabel}' labeled dropdown value.");
			return this.LabeledDropdown(dropdownLabel).GetValue();
		}

		public List<string> LabeledDropdownOptionsListGet(string dropdownLabel)
		{
			Report.Info($"Attempting to get '{dropdownLabel}' labeled dropdown options list.");
			List<string> output = new List<string>();
			this.LabeledDropdownOptionsList(dropdownLabel).ForEach(x => output.Add(x.Text.Trim()));
			return output;
		}

		public bool LabeledDropdownOptionExists(string dropdownLabel, string dropdownOption)
		{
			Report.Info($"Attempting to confirm '{dropdownLabel}' labeled dropdown contains '{dropdownOption}' option.");
			return this.LabeledDropdownOption(dropdownLabel, dropdownOption) != null;
		}

		public bool LabeledDropdownOptionClick(string dropdownLabel, string dropdownOption)
		{
			Report.Info($"Attempting to click '{dropdownLabel}' labeled dropdown '{dropdownOption}' option.");
			return this.LabeledDropdownOption(dropdownLabel, dropdownOption).TryClick();
		}
		#endregion
		#endregion
	}

	public class TextSearch : SeleniumBaseObject
	{
		#region Class Objects
		private string _placeholderText;
		protected override By ContainerElementLocator => By.XPath($"//div[@class='search-group'][.//input[@type='text'][@placeholder='{_placeholderText}']]");
		private IWebElement TextInput => this.FindElement(By.XPath(".//input[@type='text']"), 1);
		private IWebElement SearchButton => this.FindElement(By.XPath(".//span[contains(@data-bind,'click')]"), 1);
		#endregion

		#region Class Methods
		public TextSearch(string placeholderText)
		{
			_placeholderText = placeholderText;
		}

		public bool TextInputExists()
		{
			Report.Info($"Attempting to confirm text search text input exists.");
			return this.TextInput != null;
		}

		public bool TextInputClick()
		{
			Report.Info($"Attempting to click text search text input.");
			return this.TextInput.TryClick();
		}

		public bool TextInputEnterText(string inputText)
		{
			Report.Info($"Attempting to enter '{inputText}' into text search text input.");
			return this.TextInput.TryEnterText(inputText);
		}

		public string TextInputTextGet()
		{
			Report.Info($"Attempting to get text search text.");
			return this.TextInput.GetValue();
		}

		public bool SearchButtonExists()
		{
			Report.Info($"Attempting to confirm text search search button exists.");
			return this.SearchButton != null;
		}

		public bool SearchButtonClick()
		{
			Report.Info($"Attempting to click text search search button.");
			return this.SearchButton.TryClick();
		}
		#endregion
	}

	internal class MyProductsTable : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//table[not(@id)][@class='table table-hover products-table']");
		private List<IWebElement> ColumnLabelsList => this.FindElements(By.XPath(".//th[text()]"), 1).ToList();
		private IWebElement ColumnLabel(string columnLabel) => this.ColumnLabelsList.FirstOrDefault(x => x.Text == columnLabel);
		private List<MyProductsTableRow> ProductTableRowsList => this.ContainerElement.FindElements(By.XPath(".//tbody[@data-bind='foreach: products']//tr"), 1).Select(x => new MyProductsTableRow(x)).ToList();
		#endregion

		#region Class Methods
		public List<string> ColumnLabelsListGet()
		{
			Report.Info($"Attempting to get list of column labels.");
			List<string> output = new List<string>();
			this.ColumnLabelsList.ForEach(x => output.Add(x.Text.Trim()));
			return output;
		}

		public bool ColumnLabelExists(string columnLabel)
		{
			Report.Info($"Attmpting to confirm '{columnLabel}' column label exists.");
			return this.ColumnLabel(columnLabel) != null;
		}

		public bool ColumnLabelDisplayed(string columnLabel)
		{
			Report.Info($"Attempting to confirm '{columnLabel}' column label is displayed.");
			return this.ColumnLabel(columnLabel).Displayed;
		}

		public List<string> ProductNameList()
		{
			Report.Info($"Attempting to get a list of the displayed product names.");
			List<string> output = new List<string>();
			this.ProductTableRowsList.ForEach(x => output.Add(x.ProductName));
			return output;
		}

		public int ProductsTableListCount()
		{
			Report.Info($"Attempting to get the number of products displayed in the products table.");
			return this.ProductTableRowsList.Count;
		}

		public MyProductsTableRow ProductRowByNameGet(string productName)
		{
			Report.Info($"Attempting to get product row with '{productName}' product name.");
			return this.ProductTableRowsList.FirstOrDefault(x => x.ProductName == productName);
		}

		public MyProductsTableRow ProductRowByIDGet(string productID)
		{
			Report.Info($"Attempting to get product row with '{productID}' product ID.");
			return this.ProductTableRowsList.Where(x => x.ProductID == productID).FirstOrDefault();
		}
		#endregion
	}

	internal class MyProductsTableFooter : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'panel-footer')]");
		private IWebElement ItemsOnPageSelect => this.FindElement(By.XPath(".//select[contains(@data-bind,'ItemsOnPage')]"), 1);
		private List<IWebElement> ItemsOnPageSelectOptionsList => this.ItemsOnPageSelect.FindElements(By.XPath(".//option"), 1).ToList();
		private IWebElement ItemsOnPageSelectOption(string optionLabel) => this.ItemsOnPageSelectOptionsList.Where(x => x.Text.Trim() == optionLabel).FirstOrDefault();
		private List<IWebElement> PaginationButtonsList => this.FindElements(By.XPath(".//ul[@id='pagingControl']//*[text()]"), 1).ToList();
		private IWebElement PaginationButton(string buttonLabel) => this.PaginationButtonsList.Where(x => x.Text == buttonLabel).FirstOrDefault();
		#endregion

		#region Class Methods
		#region Items on Page Select
		public bool ItemsOnPageSelectExists()
		{
			Report.Info($"Attempting to confirm 'Items on Page' select exists.");
			return this.ItemsOnPageSelect != null;
		}

		public bool ItemsOnPageSelectClick()
		{
			Report.Info($"Attempting to click 'Items on Page' select.");
			return this.ItemsOnPageSelect.TryClick();
		}

		public string ItemsOnPageSelectValue()
		{
			Report.Info($"Attempting to get 'Items on Page' select value.");
			return this.ItemsOnPageSelect.GetValue().ToString();
		}

		public List<string> ItemsOnPageSelectOptionsListGet()
		{
			Report.Info($"Attempting to get list of 'Items on Page' select options.");
			List<string> output = new List<string>();
			this.ItemsOnPageSelectOptionsList.ForEach(x => output.Add(x.Text.Trim()));
			return output;
		}

		public bool ItemsOnPageSelectOptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm 'Items on Page' select '{optionLabel}' option exists.");
			return this.ItemsOnPageSelectOption(optionLabel) != null;
		}

		public bool ItemsOnPageSelectOptionClick(string optionLabel)
		{
			Report.Info($"Attempting to click 'Items on Page' select '{optionLabel}' option.");
			return this.ItemsOnPageSelectOption(optionLabel).TryClick();
		}
		#endregion

		#region Pagination Methods
		public List<string> PaginationButtonsListGet()
		{
			Report.Info($"Attempting to get the list of pagination buttons.");
			List<string> output = new List<string>();
			this.PaginationButtonsList.ForEach(x => output.Add(x.Text.Trim()));
			return output;
		}

		public bool PaginationButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' pagination button exists.");
			return this.PaginationButton(buttonLabel) != null;
		}

		public bool PaginationButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' pagination button.");
			return this.PaginationButton(buttonLabel).TryClick();
		}

		public bool PaginationButtonDisabled(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' pagination button is disabled.");
			return this.PaginationButton(buttonLabel).FindElement(By.XPath(".//ancestor-or-self::li[@class = 'disabled']"), 1) != null;
		}

		public bool PaginationButtonCurrent(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' pagination button is current page.");
			return this.PaginationButton(buttonLabel).GetAttribute("class").Contains("current");
		}
		#endregion
		#endregion
	}

	public class RecipientTile
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; }
		public string Label => this.ContainerElement?.Text;
		public string DataOriginalTitle => this.ContainerElement?.GetAttribute("data-original-title");
		public string Retailer => this.DataOriginalTitle.Split('/')[0].Trim();
		public string Status => this.DataOriginalTitle.Split('/')[1].Trim();
		#endregion

		#region Class Methods
		public RecipientTile(IWebElement recipientTileComponent)
		{
			this.ContainerElement = recipientTileComponent;
		}
		public bool RetailerTileTooltipDisplayed()
		{
			Report.Info($"Attempting to confirm tooltip displayed for '{this.Label}' recipient tile.");
			this.ContainerElement.Hover();
			return this.ContainerElement.GetAttribute("aria-describedby") != null;
		}
		#endregion
	}

	public class MyProductsTableRow
	{
		#region Class Object
		private IWebElement ContainerElement { get; set; }
		private IWebElement IDProductNameCell => this.ContainerElement.FindElement(By.XPath(".//td[.//small[@data-bind='text:ProductID']]"), 1);
		public string ProductID => this.IDProductNameCell.FindElement(By.XPath(".//small[@data-bind='text:ProductID']"), 1)?.Text;
		public string ProductName => this.IDProductNameCell.FindElement(By.XPath(".//p"), 1)?.Text;
		private IWebElement PrivateLabelTile => this.IDProductNameCell.FindElement(By.XPath(".//span[@title='Private Label']"), 1);
		public string DateCreated => this.ContainerElement.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 1)?.Text;
		public string DateRevised => this.ContainerElement.FindElement(By.XPath(".//td[@data-bind='text: DateRevised']"), 1)?.Text;
		public string DateDiscontinued => this.ContainerElement.FindElement(By.XPath(".//td[@data-bind='text: DateDiscontinued']"), 1)?.Text;
		private List<RecipientTile> RecipientsList => this.ContainerElement.FindElements(By.XPath(".//ul[@class='list-inline retailers']//li"), 1).Select(x => new RecipientTile(x)).ToList();
		private IWebElement ActionsButton => this.ContainerElement.FindElement(By.XPath(".//button[@data-toggle='dropdown']"), 1);
		private List<IWebElement> ActionsButtonOptionsList => this.ContainerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a[not(@style='display: none;')]"), 1).ToList();
		private IWebElement ActionsButtonOption(string optionLabel) => this.ActionsButtonOptionsList.Where(x => x.Equals(optionLabel)).FirstOrDefault();
		#endregion

		#region Class Methods
		public MyProductsTableRow(IWebElement myProductTableRowComponent)
		{
			this.ContainerElement = myProductTableRowComponent;
		}
		public bool PrivateLabelExists()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' has a private label tile.");
			return this.PrivateLabelTile != null;
		}
		public List<string> RecipientsListGet()
		{
			Report.Info($"Attempting to get '{this.ProductName}' list of reciepient retailers.");
			List<string> output = new List<string>();
			this.RecipientsList.ForEach(x => output.Add(x.Retailer));
			return output;
		}

		public List<string> RecipientsWithStatusListGet(string status)
		{
			Report.Info($"Attempting to get '{this.ProductName}' list of reciepient retailers with '{status}' status.");
			List<string> output = new List<string>();
			this.RecipientsList.Where(x => x.Status == status).ToList().ForEach(x => output.Add(x.Retailer));
			return output;
		}

		public bool RecipientExists(string label)
		{
			Report.Info($"Attempting to confirm '{label}' recipient tile exists.");
			return this.RecipientsList.Any(x => x.Label == label);
		}

		public RecipientTile RecipientGet(string label)
		{
			Report.Info($"Attempting to get '{label}' recipient tile.");
			return this.RecipientsList.Where(x => x.Label == label).FirstOrDefault();
		}

		public bool ActionsButtonExists()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' actions button exists.");
			return this.ActionsButton != null;
		}

		public bool ActionsButtonClick()
		{
			Report.Info($"Attempting to click '{this.ProductName}' actions button.");
			return this.ActionsButton.TryClick();
		}

		public bool ActionsButtonMenuOpen()
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' actions button menu is open.");
			return this.ActionsButton.GetAttribute("aria-expanded") == "true";
		}

		public List<string> ActionsButtonOptionsListGet()
		{
			Report.Info($"Attempting to get '{this.ProductName}' actions button menu options list.");
			List<string> output = new List<string>();
			this.ActionsButtonOptionsList.ForEach(x => output.Add(x.Text.Trim()));
			return output;
		}

		public bool ActionsButtonOptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm '{this.ProductName}' actions button menu '{optionLabel}' option exists.");
			return this.ActionsButtonOption(optionLabel) != null;
		}

		public bool ActionsButtonOptionClick(string optionLabel)
		{
			Report.Info($"Attempting to click '{this.ProductName}' action button menu '{optionLabel}' option.");
			return this.ActionsButtonOption(optionLabel).TryClick();
		}
		#endregion
	}

	public class BulkActionsModal : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//div[@id='bulk-actions-modal'][not(@style='display: none;')]");
		private string ModalLabel => this.FindElement(By.XPath(".//h3"), 1)?.Text;
		private IWebElement CloseButton => this.FindElement(By.XPath(".//button[@aria-label='Close']"), 1);
		private IWebElement ForwardProductRegistrationButton => this.FindElement(By.XPath(".//a[@href='/FwdProdRegistration/Default']"), 1);
		private IWebElement AcceptDocumentsButton => this.FindElement(By.XPath(".//a[@href='/ProductManagement/DocumentAcceptance']"), 1);
		private IWebElement DeleteProductsButton => this.FindElement(By.XPath(".//a[@href='/ProductManagement/MyProducts/ManageActive']"), 1);
		private IWebElement InternalInformationRevisionsButton => this.FindElement(By.XPath(".//a[href='/ProductManagement/InternalInfoRevisions']"), 1);
		#endregion

		#region Class Methods
		public string ModalLabelGet()
		{
			Report.Info($"Attempting to get the active modal label");
			return this.ModalLabel;
		}

		public bool CloseButtonExists()
		{
			Report.Info($"Attempting to confirm modal close button exists.");
			return this.CloseButton != null;
		}

		public bool CloseButtonClick()
		{
			Report.Info($"Attempting to click modal close button.");
			return this.CloseButton.TryClick();
		}

		public bool ForwardProductRegistrationButtonExists()
		{
			Report.Info($"Attempting to confirm 'Forward Product Registration' button exists");
			return this.ForwardProductRegistrationButton != null;
		}

		public bool ForwardProductRegistrationButtonClick()
		{
			Report.Info($"Attempting to click 'Forward Product Registration' button.");
			return this.ForwardProductRegistrationButton.TryClick();
		}

		public bool AcceptDocumentsButtonExists()
		{
			Report.Info($"Attempting to confirm 'Accept Documents' button exists.");
			return this.AcceptDocumentsButton != null;
		}

		public bool AcceptDocumentsButtonClick()
		{
			Report.Info($"Attempting to click 'Accept Documents' button.");
			return this.AcceptDocumentsButton.TryClick();
		}

		public bool DeleteProductsButtonExists()
		{
			Report.Info($"Attempting to confirm 'Delete Products' button exists.");
			return this.DeleteProductsButton != null;
		}

		public bool DeleteProductsButtonClick()
		{
			Report.Info($"Attempting to click 'Delete Products' button.");
			return this.DeleteProductsButton.TryClick();
		}

		public bool InternalInformationRevisionButtonExists()
		{
			Report.Info($"Attempting to confirm 'Internal Information Revision' button exists.");
			return this.InternalInformationRevisionsButton != null;
		}

		public bool InternalInformationRevisionButtonClick()
		{
			Report.Info($"Attempting to click 'Internal Information Revision' button.");
			return this.InternalInformationRevisionsButton.TryClick();
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide;
using UL.Automation.WebDriver.BaseClasses;
using System.Windows.Forms;
using NPOI.OpenXmlFormats.Dml;
using System.Security.Cryptography.X509Certificates;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class IngredientsTableRow
	{
		#region Page Objects
		private IWebElement ContainerElement { get; set; }
		public string ChemicalName => this.ContainerElement.FindElement(By.XPath(".//div[@class='chemical-name']"), 1)?.Text;
		public string CASNumber => this.ContainerElement.FindElement(By.XPath(".//small[@data-bind='text: CAS']"), 1)?.Text;
		IWebElement RowRemoveButton => this.ContainerElement.FindElement(By.XPath(".//a[.//span[text()='×']]"), 1);
		IWebElement RowColumnCell(string columnTitle) => this.ContainerElement.FindElement(By.XPath($".//td[{new IngredientsTableHeaderRow().ColumnHeaderIndex(columnTitle) + 1}]"), 1);
		IWebElement CellCheckBox(string columnTitle) => this.RowColumnCell(columnTitle).FindElement(By.XPath(".//input[@type='checkbox']"), 1);
		public string CellCheckBoxLabel(string columnTitle) => this.RowColumnCell(columnTitle).FindElement(By.XPath(".//div[@class='checkbox']//label"), 1)?.Text;
		IWebElement CellButton(string columnTitle, string buttonLabel) => this.RowColumnCell(columnTitle).FindElement(By.XPath($".//a[text() = '{buttonLabel}']"), 1);
		IWebElement CellErrorMessage(string columnTitle) => this.RowColumnCell(columnTitle).FindElement(By.XPath(".//p[@class='form-error']"), 1);
		IWebElement CellTextInput(string columnTitle) => this.RowColumnCell(columnTitle).FindElement(By.XPath(".//input[@type='text']"), 1);
		IWebElement CellSelect(string columnTitle) => this.RowColumnCell(columnTitle).FindElement(By.XPath(".//select[@class='form-control']"), 1);
		List<IWebElement> CellSelectOptionList(string columnTitle) => this.CellSelect(columnTitle).FindElements(By.XPath(".//option"), 1).ToList();
		#endregion

		#region Methods

		public IngredientsTableRow(IWebElement chemicalRow)
		{
			this.ContainerElement = chemicalRow;
		}
		public bool RowColumnCellExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell exists.");
			return this.RowColumnCell(columnTitle) != null;
		}

		public bool CellCheckBoxExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell checkbox exists.");
			return this.CellCheckBox(columnTitle) != null;
		}

		public bool CellCheckBoxIsChecked(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell checkbox is checked.");
			return this.CellCheckBox(columnTitle).Checked();
		}

		public bool CellCheckBoxClick(string columnTitle)
		{
			Report.Info($"Attempting to click '{columnTitle}' column cell checkbox.");
			return this.CellCheckBox(columnTitle).TryClick();
		}

		public bool CellCheckBoxLabelExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell checkbox label exists.");
			return !this.CellCheckBoxLabel(columnTitle).IsNullOrEmpty();
		}

		public bool CellButtonExists(string columnTitle, string buttonLabel)
		{
			Report.Info($"Attempting to confirm the '{columnTitle}' column cell '{buttonLabel}' button exists.");
			return this.CellButton(columnTitle, buttonLabel) != null;
		}

		public bool CellButtonClick(string columnTitle, string buttonLabel)
		{
			Report.Info($"Attempting to click '{columnTitle}' column cell '{buttonLabel}' button.");
			return this.CellButton(columnTitle, buttonLabel).TryClick();
		}

		public bool CellErrorMessageExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell error message exists.");
			return this.CellErrorMessage(columnTitle) != null;
		}

		public bool CellErrorMessageDisplayed(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell error message is displayed.");
			return this.CellErrorMessage(columnTitle).Displayed;
		}

		public string CellErrorMessageText(string columnTitle)
		{
			Report.Info($"Attempting to get '{columnTitle}' column cell error message text.");
			return this.CellErrorMessage(columnTitle).Text;
		}

		public bool CellTextInputExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell text input exists.");
			return this.CellTextInput(columnTitle) != null;
		}

		public bool CellTextInputClick(string columnTitle)
		{
			Report.Info($"Attempting to click '{columnTitle}' column cell text input.");
			return this.CellTextInput(columnTitle).TryClick();
		}

		public bool CellTextInputEnterText(string columnTitle, string text)
		{
			Report.Info($"In '{columnTitle}' column cell text input, attempting to enter text: '{text}'");
			return this.CellTextInput(columnTitle).TryEnterText(text);
		}

		public string CellTextInputText(string columnTitle)
		{
			Report.Info($"Attempting to get '{columnTitle}' column cell text input text.");
			return this.CellTextInput(columnTitle).GetValue();
		}

		public bool CellSelectExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell select exists.");
			return this.CellSelect(columnTitle) != null;
		}

		public bool CellSelectClick(string columnTitle)
		{
			Report.Info($"Attempting to click '{columnTitle}' column cell select.");
			return this.CellSelect(columnTitle).TryClick();
		}

		public bool CellSelectOptionExists(string columnTitle, string optionLabel)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column cell '{optionLabel}' select option exists.");
			return this.CellSelectOptionList(columnTitle).Any(x => string.Equals(x.Text, optionLabel, StringComparison.InvariantCultureIgnoreCase));
		}

		public bool CellSelectOptionSelect(string columnTitle, string optionLabel)
		{
			Report.Info($"Attempting to select '{columnTitle}' column cell '{optionLabel}' select option.");
			this.CellSelect(columnTitle).Select(optionLabel);
			return string.Equals(this.CellSelect(columnTitle).GetValue(), optionLabel, StringComparison.InvariantCultureIgnoreCase);	
		}

		public string CellSelectValue(string columnTitle)
		{
			Report.Info($"Attempting to get the selected option of '{columnTitle}' cell column select.");
			return this.CellSelect(columnTitle).GetValue();
		}

		public bool RowRemoveButtonExists()
		{
			Report.Info($"Attempting to confirm row remove button exists.");
			return this.RowRemoveButton != null;
		}

		public bool RowRemoveButtonClick()
		{
			Report.Info($"Attempting to click row remove button.");
			return this.RowRemoveButton.TryClick();
		}
		#endregion
	}
	class IngredientsTableHeaderRow : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath($"//div[contains(@class,'panel-table')]//thead/tr");
		IWebElement SortableColumnTitle(string columnTitle) => this.ContainerElement.FindElement(By.XPath($".//span[normalize-space(text()) = '{columnTitle}']"), 1);
		private string SortableColumnTitleDatabindPrivate(string columnTitle) => this.SortableColumnTitle(columnTitle).GetAttribute("data-bind");
		IWebElement SortableColumnCarat(string columnTitle, string caratDirection) => this.SortableColumnTitle(columnTitle).FindElement(By.XPath($".//following-sibling::i[contains(@data-bind,'{(this.SortableColumnTitleDatabindGet(columnTitle))}')][contains(@class,'{caratDirection}')]"), 1);
		List<IWebElement> ColumnTitleList => this.ContainerElement.FindElements(By.XPath(".//th"), 1).ToList();
		#endregion

		#region Methods
		public bool SortableColumnTitleExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm sortable column title '{columnTitle}' exists.");
			return this.SortableColumnTitle(columnTitle) != null;
		}

		public bool SortableColumnTitleClick(string columnTitle)
		{
			Report.Info($"Attempting to click sortable column title '{columnTitle}'.");
			return this.SortableColumnTitle(columnTitle).TryClick();
		}

		public string SortableColumnTitleDatabindGet(string columnTitle)
		{
			string test = this.SortableColumnTitleDatabindPrivate(columnTitle);
			var reg = new Regex("\'.*?\'");
			var result = reg.Matches(test).Cast<Match>().FirstOrDefault().ToString().Trim('\'');
			return result;
		}

		public bool SortableColumnCaratExists(string columnTitle, string caratDirection)
		{
			Report.Info($"Attemoting to confirm '{columnTitle}' sortable column {caratDirection} carat exists.");
			return this.SortableColumnCarat(columnTitle, caratDirection) != null;
		}

		public bool SortableColumnCaratDisplayed(string columnTitle, string caratDirection)
		{
			Report.Info($"Attemoting to confirm '{columnTitle}' sortable column {caratDirection} carat exists.");
			return this.SortableColumnCarat(columnTitle, caratDirection).Displayed;
		}

		public bool ColumnHeaderExists(string columnTitle)
		{
			Report.Info($"Attempting to confirm '{columnTitle}' column header exists.");
			return this.ColumnTitleList.Where(x => x.Text == columnTitle).Any();
		}

		public int ColumnHeaderIndex(string columnTitle)
		{
			Report.Info($"Attempting to get '{columnTitle}' column title index.");
			return this.ColumnTitleList.FindIndex(x => x.Text.Contains(columnTitle));
		}
		#endregion
	}

	class IngredientsModal : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath($"//div[@class='modal fade in']");
		#region Header
		IWebElement ModalHeader => this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-header']"), 1);
		string HeaderTitle => this.ModalHeader.FindElement(By.XPath(".//h3[@class='modal-title']"), 1).Text;
		IWebElement HeaderCloseButton => this.ModalHeader.FindElement(By.XPath(".//button[.//span[text()='×']]"), 1);
		#endregion
		#region Body
		protected IWebElement ModalBody => this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-body']"), 1);
		#endregion
		#region Footer
		IWebElement ModalFooter => this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-footer']"), 1);
		IWebElement FooterButton(string buttonLabel) => this.ContainerElement.FindElement(By.XPath($".//button[text()='{buttonLabel}']"), 1);
		#endregion
		#endregion

		#region Methods
		#region Header
		public string HeaderTitleText()
		{
			Report.Info($"Attempting to get modal header title text.");
			return this.HeaderTitle;
		}
		public bool HeaderCloseButtonExists()
		{
			Report.Info($"Attempting to confirm modal header close button exists.");
			return this.HeaderCloseButton != null;
		}
		public bool HeaderCloseButtonClick()
		{
			Report.Info($"Attempting to click modal header close button.");
			return this.HeaderCloseButton.TryClick();
		}
		#endregion
		#region Body

		#endregion
		#region Footer
		public bool FooterButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' modal footer button exists.");
			return this.FooterButton(buttonLabel) != null;
		}

		public bool FooterButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' modal footer button.");
			return this.FooterButton(buttonLabel).TryClick();
		}
		#endregion
		#endregion
	}

	class RemoveComponentModal : IngredientsModal
	{
		#region Page Objects
		public string RemoveComponentText => this.ModalBody.FindElement(By.XPath(".//p[.//span[@class='glyphicon glyphicon-question-sign']]"), 1)?.Text.Trim();
		public string RemoveChemicalName => this.ModalBody.FindElement(By.XPath(".//*[contains(@data-bind,'ChemicalName')]"),1)?.Text.Trim();
		public string RemoveCASNumber => this.ModalBody.FindElement(By.XPath(".//*[contains(@data-bind,'CAS')]"),1)?.Text.Trim();
		#endregion
	}

	class RegulatoryListModal : IngredientsModal
	{
		#region Page Objects
		List<IWebElement> ColumnHeaderList => this.ModalBody.FindElements(By.XPath(".//th"), 1).ToList();
		List<IWebElement> RowList => this.ModalBody.FindElements(By.XPath(".//tbody//tr"),1).ToList();
		#endregion
		#region Methods
		public bool ColumnHeaderExists(string columnName)
		{
			Report.Info($"Attempting to confirm '{columnName}' column exists.");
			return this.ColumnHeaderList.Any(x => string.Equals(x.Text, columnName, StringComparison.InvariantCultureIgnoreCase));
		}

		public int ColumnHeaderIndex(string columnName)
		{
			Report.Info($"Attempting to get '{columnName}' column index.");
			return this.ColumnHeaderList.FindIndex(x => string.Equals(x.Text, columnName, StringComparison.InvariantCultureIgnoreCase));
		}
		#endregion
	}

	class IngredientsTable : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath($"//div[contains(@class,'panel-table')]");
		string TableLabel => this.ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading']//div[@data-bind='text: description']"), 1)?.Text;
		IWebElement ComponentSearchBox => this.ContainerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder' and contains(text(),'Start typing a component name to search')]"), 1);
		IWebElement MyIngredientsButton => this.ContainerElement.FindElement(By.XPath(".//button[contains(text(),'Use My Ingredients')]"), 1);
		string TotalPercent => this.ContainerElement.FindElement(By.XPath(".//td[@id='total-percent']//label"), 1)?.Text;
		string TransparencyPercent => this.ContainerElement.FindElement(By.XPath(".//td[@id='transparency-score']//span"), 1)?.Text;
		IWebElement ErrorArea => this.ContainerElement.FindElement(By.XPath(".//p[@class='form-error']"), 1);
		public List<IngredientsTableRow> IngredientRowList => this.ContainerElement.FindElements(By.XPath(".//tr[.//div[@class='chemical-name']]"), 1).Select(x => new IngredientsTableRow(x)).ToList();
		#endregion

		#region Methods
		public bool TableLabelExists()
		{
			Report.Info("Attempting to confirm table label exists.");
			return !this.TableLabel.IsNullOrEmpty();
		}

		public bool TotalPercentExists()
		{
			Report.Info("Attempting to confirm total percent text exists.");
			return !this.TotalPercent.IsNullOrEmpty();
		}

		public bool TransparencyPercentExists()
		{
			Report.Info("Attempting to confirm transparency percent text exists.");
			return !this.TransparencyPercent.IsNullOrEmpty();
		}

		#region Component Search Box
		public bool ComponentSearchBoxExists()
		{
			Report.Info($"Attempting to confirm component search box exists.");
			return this.ComponentSearchBox != null;
		}

		public bool ComponentSearchBoxClick()
		{
			Report.Info($"Attempting to click the component search box.");
			return this.ComponentSearchBox.TryClick();
		}
		#endregion

		#region My Ingredients Button
		public bool MyIngredientsButtonExists()
		{
			Report.Info("Attempting to confirm My Ingredients Button exists.");
			return this.MyIngredientsButton != null;
		}

		public bool MyIngredientsButtonClick()
		{
			Report.Info("Attempting to click My Ingredients Button.");
			return this.MyIngredientsButton.TryClick();
		}
		#endregion

		#region Ingredients List
		public bool IngredientsRowChemicalNameExists(string chemicalName)
		{
			Report.Info($"Attempting to confirm chemical name:'{chemicalName}' ingredient row exists.");
			var test = this.IngredientRowList.Any(x => string.Equals(x.ChemicalName, chemicalName, StringComparison.InvariantCultureIgnoreCase));
			return test;
		}

		public bool IngredientsRowCASNumberExists(string casNumber)
		{
			Report.Info($"Attempting to confirm CAS Number:'{casNumber}' ingredient row exists.");
			return this.IngredientRowList.Any(x => string.Equals(x.CASNumber, casNumber, StringComparison.InvariantCultureIgnoreCase));
		}

		public IngredientsTableRow IngredientsRowChemicalNameGet(string chemicalName)
		{
			Report.Info($"Attempting to get ingredient row with chemical name: '{chemicalName}'.");
			return this.IngredientRowList.Where(x => string.Equals(x.ChemicalName, chemicalName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		}

		public IngredientsTableRow IngredientsRowCASNumberGet(string casNumber)
		{
			Report.Info($"Attempting to get ingredient row with CAS number: '{casNumber}'.");
			return this.IngredientRowList.Where(x => string.Equals(x.CASNumber, casNumber, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		}
		#endregion
		#endregion
	}
}

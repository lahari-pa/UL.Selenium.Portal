using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
	class SuperTable : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.Id("supertable_main");

		#endregion
		// public
		#region Methods

		#endregion
	}

	class GridTable : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//*[@id='gview_dataGrid' or @id='gview_tblDrumLog']");
		private List<IWebElement> GridTableTitlesList => ContainerElement.FindElements(By.XPath("./div[not(contains(@class,'frozen'))]//tr[contains(@class,'labels')]/th"), 1).ToList();
		private List<IWebElement> GridTableRowsList => ContainerElement.FindElements(By.XPath("./div[not(contains(@class,'frozen'))]//tr[@id]"), 1).ToList();
		private List<IWebElement> GridTableProductInfoList => ContainerElement.FindElements(By.XPath("./div[contains(@class,'frozen')]//td[@title]"), 1).ToList();
		private IWebElement GridTableLoadingSpinner => FindElement(By.XPath("//div[@data-bind='if: isLoading']//div[@class='spinner-grow']"), 1);
		#endregion

		#region Methods
		public bool GridTableLoadingSpinnerExists()
        {
			Report.Info("Attempting to confirm Grid Table Loading Spinner exists.");
			return GridTableLoadingSpinner != null;
        }

		public bool GridTableLoadingSpinnerWaitToDisappear(int secondsToWait=30)
        {
			Report.Info($"Attempting to wait {secondsToWait} seconds for Grid Table Loading Spinner to disappear.");
			bool result = true;
			while(FindElement(By.XPath("//div[@class='spinner-grow']"),1) != null)
            {
				Delay.Seconds(1);
				secondsToWait--;
				Report.Info($"Continuing to wait for {secondsToWait} seconds.");
				if (secondsToWait <= 0)
                {
					Report.Info($"Failure, spinner failed to disappear after {secondsToWait} seconds.");
					result = false;
					break;
                }
            }
			return result;
        }
		public bool GridTableRowsListExists()
        {
			Report.Info("Attempting to confirm the Grid Table Rows list exists.");
			return GridTableRowsList != null;
        }
		public int GridTableRowsListCountGet()
        {
			Report.Info("Attempting to get the number of Grid Table rows.");
			int result = 0;
			if(GridTableRowsListExists())
            {
				result = GridTableRowsList.Count;
			}
			return result;
        }

		public IWebElement ProductInfoCellGet(int rowNumber)
        {
			Report.Info($"Attempting to get Product Info cell for row #{rowNumber}.");
			return GridTableProductInfoList[rowNumber - 1];
        }

		public bool GridTableRowExists(int rowNumber)
        {
			Report.Info($"Attempting to confirm Grid Table row #{rowNumber} exists.");
			return GridTableRowsListCountGet() >= rowNumber;

		}

		public bool ProductInfoCellExists(int rowNumber)
        {
			Report.Info($"Attemting to confirm Product Info cell for row #{rowNumber} exists.");
			return ProductInfoCellGet(rowNumber) != null;
        }

		public string ProductInfoCellNameGet(IWebElement productInfoCell)
        {
			Report.Info("Attempting to get the Name from the Product Info cell.");
			return productInfoCell.FindElement(By.XPath("./strong"), 1).Text;
        }

		public string ProductInfoCellUPCGet(IWebElement productInfoCell)
        {
			Report.Info("Attempting to get the UPC from the Product Info cell.");
			string UPCString = productInfoCell.FindElement(By.XPath(".//span[contains(text(),'UPC')]"), 1).Text;
			return Regex.Match(UPCString, @"^UPC ([\d]+)$").Groups[1].Value;
		}

		public string ProductInfoCellWPSIDGet(IWebElement productInfoCell)
		{
			Report.Info("Attempting to get the WPSID from the Product Info cell.");
			string UPCString = productInfoCell.FindElement(By.XPath(".//span[contains(text(),'WPSID')]"), 1).Text;
			return Regex.Match(UPCString, @"^\(WPSID ([\d]+)\)$").Groups[1].Value;
		}

		public string ProductInfoCellCompanyNameGet(IWebElement productInfoCell)
        {
			Report.Info("Attempting to get the Company Name from the Product Info cell.");
			return productInfoCell.FindElement(By.XPath(".//span[not(@class)]"), 1).Text;
		}

		private IWebElement ProductInfoCellTagGet(IWebElement productInfoCell, string tagColor, string tagLabel, string valueLabel)
        {
			Report.Info($"Attempting to get the Product Info cell {tagColor} '{tagLabel}' tag.");
			string valueLabelXPath;
			if(valueLabel == "Product Name")
            {
				valueLabelXPath = "[self::strong or self::span[contains(@class,'padding-left')]]";
            }
            else if(valueLabel == "WPSID")
            {
				valueLabelXPath = $"[self::span[starts-with(text(), '({valueLabel}')]]";
			}
            else
            {
				valueLabelXPath = $"[self::span[starts-with(text(), '{valueLabel}')]]";
			}
			return productInfoCell.FindElement(By.XPath($".//span[@class ='bold {tagColor} padding-left'][text()='{tagLabel}']//preceding-sibling::*[1]"), 1);
		}

		public bool ProductInfoCellTagExists(IWebElement productInfoCell, string tagColor, string tagLabel, string valueLabel)
        {
			Report.Info($"Attempting to confrim the Product Info cell has the {tagColor} '{tagLabel}' tag.");
			return ProductInfoCellTagGet(productInfoCell, tagColor, tagLabel, valueLabel) != null;

		}
		#endregion
	}

	class ProductInfoCell : SeleniumBaseObject
    {
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'frozen')]//td[@title]");
		private string Name => ContainerElement.FindElement(By.XPath("./strong"), 1).Text;
		private string UPCString => ContainerElement.FindElement(By.XPath(".//span[contains(text(),'UPC')]"), 1).Text;
		private string WPSIDString => ContainerElement.FindElement(By.XPath(".//span[contains(text(),'WPSID')]"), 1).Text;
		private string CompanyName => ContainerElement.FindElement(By.XPath(".//span[not(@class)]"),1).Text;
		#endregion

		#region Methods
		public string NameGet()
        {
			Report.Info($"Attempting to get the Product Name.");
			return this.Name;
        }

		public string UPCGet()
        {
			Report.Info($"Attempting to get the UPC.");
			return Regex.Match(UPCString, @"^UPC [\d]+$").Value;
        }

		public string WPSIDGet()
		{
			Report.Info($"Attempting to get the UPC.");
			return Regex.Match(UPCString, @"^(WPSID [\d]+)$").Value;
		}

		private IWebElement TagGet(string tagLabel)
        {
			Report.Info($"Attempting to get '{tagLabel}' Tag.");
			return ContainerElement.FindElement(By.XPath($".//span[@class='bold red padding-left'][text()='{tagLabel}']"), 1);
        }

		public bool TagExists(string tagLabel)
        {
			Report.Info($"Attempting to confirm '{tagLabel}' Tag exists.");
			return TagGet(tagLabel) != null;
        }

		#endregion
	}

    class SuperTableNav : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'table-page-nav')]");
		private IWebElement NavLabel => ContainerElement.FindElement(By.XPath(".//input[@type='text']"), 1);
		private List<IWebElement> ButtonList => ContainerElement.FindElements(By.XPath(".//button"), 1).ToList();
		private List<IWebElement> CardList => ContainerElement.FindElements(By.XPath(".//div[contains(@class,'card')]//div[contains(@class,'card-body')]"), 1).ToList();
		private List<IWebElement> BreadcrumbList => ContainerElement.FindElements(By.XPath(@".//div[@class='filter-breadcrumbs']//span[contains(@class,'btn btn-outline')]"), 1).ToList();
		private IWebElement SearchInput => ContainerElement.FindElement(By.XPath(@".//input[@type='text']"), 1);
		#endregion

		#region Methods
		// Nav Text
		public bool NavLabelExists()
		{
			Report.Info("Attempting to confirm the Nav Label exists.");
			return NavLabel != null;
		}

		public string NavLabelGet()
		{
			Report.Info("Attempting to get the Nav Label text.");
			return NavLabel.Text;
		}

		//Nav Buttons
		private IWebElement NavButtonGet(string buttonLabel)
		{
			Report.Info($"Attempting to get '{buttonLabel}' Button.");
			return ContainerElement.FindElement(By.XPath($".//button[contains(.,'{buttonLabel}')]"), 1);
		}
		public bool NavButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' Button exists.");
			return NavButtonGet(buttonLabel) != null;
		}

		public bool NavButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' Button.");
			bool result = false;
			if (NavButtonExists(buttonLabel))
			{
				result = NavButtonGet(buttonLabel).TryClick();
			}
			return result;
		}

		public string NavButtonGetColor(string buttonLabel)
		{
			Report.Info($"Attempting to get the color of '{buttonLabel}' Button.");
			string result = null;
			if (NavButtonExists(buttonLabel))
			{
				result = NavButtonGet(buttonLabel).GetCssValue("background-color");
			}
			return result;
		}

		public bool NavButtonHoveringChangesColor(string buttonLabel)
		{
			Report.Info($"Attempting to confirm color changes when hovering over '{buttonLabel}' Button.");
			bool result = false;
			if (NavButtonExists(buttonLabel))
			{
				result = NavButtonGet(buttonLabel).HoveringChangesColour();
			}
			return result;
		}

		//Search Input
		public bool SearchInputExists()
		{
			Report.Info("Attempting to confirm Search Input exists.");
			return SearchInput != null;
		}

		public bool SearchInputEnterText(string textString)
		{
			Report.Info($"Attempting to enter '{textString}' into the Search Input");
			return SearchInput.TryEnterText(textString);
		}

		public string SearchInputPlaceholderTextGet()
		{
			Report.Info($"Attempting to get the Search Input placeholder text.");
			return SearchInput.GetAttribute("placeholder");
		}

		public bool SearchInputPlaceholderTextExists()
		{
			Report.Info($"Attempting to confirm the Search Input has placeholder text.");
			return SearchInputPlaceholderTextGet() != null;
		}

		public string SearchInputTextGet()
		{
			Report.Info($"Attemting to get Search Input text.");
			return SearchInput.GetValue();
		}

		// Breadcrumbs
		public bool BreadcrumbListExists()
		{
			Report.Info("Attempting to confirm breadcrumb list exists.");
			return !BreadcrumbList.IsNullOrEmpty();
		}

		public int BreadcrumbListCount()
		{
			Report.Info("Attempting to count the number of breadcrumbs in breadcrumb list.");
			int result = 0;
			if (BreadcrumbListExists())
			{
				result = BreadcrumbList.Count();
			}
			return result;
		}

		private List<IWebElement> BreadcrumbListWithFilterGet(string filter)
		{
			Report.Info($"Attempting get breadcrumb list members with '{filter}' filter.");
			List<IWebElement> result = null;
			if (BreadcrumbListExists())
			{
				result = BreadcrumbList.Where(x => x.FindElement(By.XPath(".//span[data-bind='text: `${field}: ${text}`']")).Text.Contains($"{filter}. ")).ToList();
			}
			return result;
		}

		public int BreadcrumbListWithFilterCount(string filter)
		{
			Report.Info($"Attempting to count number of breadcrumb list members with '{filter}' filter.");
			int result = 0;
			if(BreadcrumbListWithFilterGet(filter) != null)
            {
				result = BreadcrumbListWithFilterGet(filter).Count();

			}
			return result;
		}

		private IWebElement BreadcrumbGet(string breadcrumbLabel)
		{
			Report.Info($"Attempting to get '{breadcrumbLabel}' breadcrumb");
			string breadcrumbXPath = ".//span[@data-bind='text: `${field}: ${text}`']" + $"[contains(text(),\"{breadcrumbLabel}\")]";
			return ContainerElement.FindElement(By.XPath(breadcrumbXPath), 1);
		}

		public bool BreadcrumbExists(string breadcrumbLabel)
		{
			Report.Info($"Attempting to confirm '{breadcrumbLabel}' breadcrumb exists.");
			return BreadcrumbGet(breadcrumbLabel) != null;
		}

		private IWebElement BreadcrumbCloseButtonGet(string breadcrumbLabel)
		{
			Report.Info($"Attempting to get '{breadcrumbLabel}' breadcrumb close button.");
			return BreadcrumbGet(breadcrumbLabel).FindElement(By.XPath(".//i[@data-bind='click: remove']"), 1);
		}

		public bool BreadcrumbCloseButtonExists(string breadcrumbLabel)
		{
			Report.Info($"Attempting to confirm '{breadcrumbLabel}' breadcrumb close button exists.");
			return BreadcrumbCloseButtonGet(breadcrumbLabel) != null;
		}

		public bool BreadcrumbClose(string breadcrumbLabel)
		{
			Report.Info($"Attempting to close '{breadcrumbLabel}' breadcrumb.");
			bool result = false;
			if (BreadcrumbCloseButtonExists(breadcrumbLabel))
			{
				result = BreadcrumbCloseButtonGet(breadcrumbLabel).TryClick();
			}
			return result;
		}

		// Cards
		public bool CardListExists()
		{
			Report.Info("Attempting to confirm card list exists.");
			return CardList != null && CardList.Count > 0;
		}

		public int CardListCount()
		{
			Report.Info("Attempting to count the number of cards in card list.");
			int result = 0;
			if (CardListExists())
			{
				result = CardList.Count();
			}
			return result;
		}

		public bool CardsAreInCorrectOrder(List<string> cardOrderList)
		{
			if (cardOrderList.Count != CardList.Count)
			{
				Report.Info("Expected card count is not equal to actual card count");
				return false;
			}

			for (int i = 0; i < cardOrderList.Count; i++)
			{
				string actualCardText = CardList[i].FindElement(By.XPath(".//h6[contains(@class,'card-subtitle')]")).Text.Trim().ToLower();
				if (cardOrderList[i].Trim().ToLower() != actualCardText)
				{
					Report.Info(string.Format("Expected text for card #{0} did not match. Expected: {1}. Actual: {2}.", i + 1, cardOrderList[i], actualCardText));
					return false;
				}
			}

			return true;
		}

		private IWebElement CardGet(string cardLabel)
		{
			Report.Info($"Attempting to get '{cardLabel}' card");
			return CardList.Where(x => x.FindElement(By.XPath(".//h6[contains(@class,'card-subtitle')]")).Text == cardLabel).SingleOrDefault();
		}

		public bool CardExists(string cardLabel)
		{
			Report.Info($"Attempting to confirm '{cardLabel}' card exists.");
			return CardGet(cardLabel) != null;
		}

		public bool CardGraphicExists(string cardLabel)
		{
			Report.Info($"Attempting to confirm graphic for '{cardLabel}' exists.");
			if (CardExists(cardLabel))
			{
				return CardGet(cardLabel).FindElement(By.XPath(@".//span[contains(@class, 'card-icon')]")) != null;
			}
			else
			{
				return false;
			}
		}

		public bool CardHoverTooltipExists(string cardLabel)
		{
			Report.Info($"Attempting to confirm '{cardLabel}' card tooltip exists.");
			bool result = false;
			if (CardExists(cardLabel))
			{
				IWebElement iCard = CardGet(cardLabel);
				iCard.Hover();
				result = iCard.GetAttribute("aria-describedby") != null;
			}
			return result;
		}

		public string CardHoverToolTipGet(string cardLabel)
		{
			Report.Info($"Attempting to get '{cardLabel}' card tooltip test.");
			string result = null;
			if (CardHoverTooltipExists(cardLabel))
			{
				result = CardGet(cardLabel).GetAttribute("data-original-title");
			}
			return result;
		}

		private IWebElement CardCountGet(string cardLabel)
		{
			Report.Info($"Attempting to get '{cardLabel}' card count element.");
			IWebElement result = null;
			if (CardExists(cardLabel))
			{
				result = CardGet(cardLabel).FindElement(By.XPath(".//span[@data-bind='text: count']"), 1);
			}
			return result;
		}

		public bool CardCountExists(string cardLabel)
		{
			Report.Info($"Attempting to confirm '{cardLabel}' card count exists and is numeric.");
			return CardCountGet(cardLabel) != null && int.TryParse(CardCountGet(cardLabel).Text, out int i);
		}

		public string CardCountGetValue(string cardLabel)
		{
			Report.Info($"Attempting to get '{cardLabel}' card count string.");
			string result = null;
			if (CardCountExists(cardLabel))
			{
				result = CardCountGet(cardLabel).Text;
			}
			return result;
		}

		private IWebElement CardGrowthGet(string cardLabel)
		{
			Report.Info($"Attempting to get '{cardLabel}' card growth element.");
			IWebElement result = null;
			if (CardExists(cardLabel))
			{
				result = CardGet(cardLabel).FindElement(By.XPath(".//small[contains(@class, 'mom-growth')]"), 1);
			}
			return result;
		}

		public bool CardGrowthExists(string cardLabel)
		{
			Report.Info($"Attempting to confirm '{cardLabel}' card growth exists.");
			return CardGrowthGet(cardLabel) != null;
		}

		public string CardGrowthGetValue(string cardLabel)
		{
			Report.Info($"Attempting to get '{cardLabel}' card growth value.");
			string result = null;
			if (CardGrowthExists(cardLabel))
			{
				result = CardGrowthGet(cardLabel).Text;
			}
			return result;
		}

		public bool CardGrowthHasClass(string cardLabel, string classString)
		{
			Report.Info($"Attempting to confirm if '{cardLabel}' card growth has '{classString}' class.");
			bool result = false;
			if (CardGrowthExists(cardLabel))
			{
				result = CardGrowthGet(cardLabel).GetAttribute("class").Contains(classString);
			}
			return result;
		}
		#endregion
	}

	class SuperTableFooter : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//tfoot|//div[@id='tblDrumLogPager']");
		private IWebElement RowsPerPageSelector => ContainerElement.FindElement(By.XPath(".//select[@title='Pages per row' or @title='Records per Page']"), 1);
		private List<IWebElement> PageSelecterOptionList => RowsPerPageSelector.FindElements(By.XPath(".//option"), 1).ToList();
		private IWebElement PagiatorButton(string buttonTitle) => ContainerElement.FindElement(By.XPath($".//button[@title='{buttonTitle}']|//li[@title='{buttonTitle}']"), 1);
		private IWebElement PageJumper => ContainerElement.FindElement(By.XPath(".//input[@data-bind='value: jumpToPage']"), 1);
		private IWebElement PageCount => PagiatorButton("Page").FindElement(By.XPath(".//span[starts-with(text(),'of ')]"), 1);
		private IWebElement RowIndex => ContainerElement.FindElement(By.XPath(".//div[@data-bind= 'if: list().length > 0']"), 1);
		private string RowIndexValueText(string valueLabel) => ContainerElement.FindElement(By.XPath(".//span[@data-bind = 'text: totalRows()']"), 1).Text;
		#endregion

		#region Methods
		public bool PagiatorButtonExists(string buttonTitle)
        {
			Report.Info($"Attempting to confirm '{buttonTitle}' Button exists.");
			return PagiatorButton(buttonTitle) != null;
        }

		public bool PagiatorButtonClick(string buttonTitle)
        {
			bool result = false;
            if (PagiatorButtonExists(buttonTitle))
            {
				Report.Info($"Attempting to click '{buttonTitle}' Button.");
				result = PagiatorButton(buttonTitle).TryClick();
			}

			return result;
        }

		public string RowsPerPageGet()
        {
			Report.Info($"Attempting to get current Rows Per Page.");
			return RowsPerPageSelector.GetValue();
        }

		public bool RowsPerPageSelectorExists()
        {
			Report.Info("Attempting to confirm rows per page selector exists.");
			return RowsPerPageSelector != null;
        }
		public bool RowsPerPageSelectorClick()
        {
			bool result = false;
			if(RowsPerPageSelectorExists())
            {
				Report.Info("Attempting to click Rows Per Page Selector.");
				result = RowsPerPageSelector.TryClick();
			}
			return result;
        }

		private IWebElement RowsPerPageSelectorOptionGet(string option)
        {
			Report.Info($"Attempting to get '{option}' option.");
			return RowsPerPageSelector.FindElement(By.XPath($".//option[text()='{option}']"), 1);
        }

		public bool RowsPerPageSelectorOptionExists(string option)
        {
			Report.Info($"Attemting to confirm '{option}' option exists.");
			return RowsPerPageSelectorOptionGet(option) != null;

		}

		public bool RowsPerPagiatorOptionClick(string option)
        {
			bool result = false;
			if(RowsPerPageSelectorOptionExists(option))
            {
				Report.Info($"Attempting to click '{option}' option.");
				result = RowsPerPageSelectorOptionGet(option).TryClick();
			}
			return result;
		}

		public bool RowIndexValueExists(string valueLabel)
        {
			Report.Info($"Attempting to confirm {valueLabel} exists.");
			return RowIndexValueText(valueLabel) != null;
		}

		public string RowIndexValueGet(string valueLabel)
        {
			Report.Info($"Attempting to get the {valueLabel} row{(valueLabel == "total" ? "s in the table" : " displayed on this page")}.");
			return RowIndexValueText(valueLabel);
        }

		public bool RowIndexExists()
        {
			Report.Info($"Attempting to confirm row index exists.");
			return RowIndex != null;
        }
		#endregion
	}
}

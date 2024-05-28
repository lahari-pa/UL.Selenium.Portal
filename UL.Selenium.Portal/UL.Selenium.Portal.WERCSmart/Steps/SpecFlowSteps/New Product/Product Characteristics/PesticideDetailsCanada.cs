using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsCanada")]
	class WERCSmart_Distributor_NewProducts_PesticideDetailsCanada
	{
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set the option in section: 'Product\'s packaging includes a Poison Danger symbol': to: (Yes|No)")]
		public void SetProductsPackagingIncludesPoisonDangerSymbol(string option)
		{
			string section = "Product's packaging includes a Poison Danger symbol";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Alberta': to: (.*)")]
		public void SetOptionForAlberta(string option)
		{
			string section = "Alberta";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'British Columbia': to: (.*)")]
		public void SetOptionForBritishColumbia(string option)
		{
			string section = "British Columbia";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Manitoba': to: (.*)")]
		public void SetOptionForManitoba(string option)
		{
			string section = "Manitoba";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'New Brunswick': to: (.*)")]
		public void SetOptionForNewBrunswick(string option)
		{
			string section = "New Brunswick";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'New Foundland and Labrador': to: (.*)")]
		public void SetOptionForNewFoundlandandLabrador(string option)
		{
			string section = "New Foundland and Labrador";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Nova Scotia': to: (.*)")]
		public void SetOptionForNovaScotia(string option)
		{
			string section = "Nova Scotia";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Ontario': to: (.*)")]
		public void SetOptionForOntario(string option)
		{
			string section = "Ontario";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Prince Edward Island': to: (.*)")]
		public void SetOptionForBritishPrinceEdwardIsland(string option)
		{
			string section = "Prince Edward Island";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Quebec': to: (.*)")]
		public void SetOptionForQuebec(string option)
		{
			string section = "Quebec";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Saskatchewan': to: (.*)")]
		public void SetOptionForSaskatchewan(string option)
		{
			string section = "Saskatchewan";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Northwest Territory': to: (.*)")]
		public void SetOptionForNorthwestTerritory(string option)
		{
			string section = "Northwest Territory";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, set option for Province: 'Yukon Territory': to: (.*)")]
		public void SetOptionForYukonTerritory(string option)
		{
			string section = "Yukon Territory";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - Canada Section, click 'Add Row' button")]
		public void SetClickAddRow()
		{
			string button = "Add Row";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the 'Pesticide Details - Canada' in row number (.*) enter 'Canada\'s 5-Digit Pest Control Number\(s\) \(PCN\) or 8-Digit Drug Identification Number\(s\) \(DIN\)': (.*)")]
		public void SetOptionForCanadas5DigitPestControlNumbers(int rowNumber, string value)
		{
			if (Report.IsTrue(new PesticideDetailsCanadaTableRow(rowNumber).RowNumberExists(), $"Failed to find row # {rowNumber}", "Successfully found row # {rowNumber}"))
			{
				Report.IsTrue(new PesticideDetailsCanadaTableRow(rowNumber).EnterPCN(value), "Failed to enter text in PCN input field", "Successfully entered text in PCN input field");
			}
		}
		[RegexStepDefinition(@"In the 'Pesticide Details - Canada' in the table 'Canada\'s 5-Digit Pest Control Number\(s\) \(PCN\) or 8-Digit Drug Identification Number\(s\) \(DIN\)' click Remove Icon for row number: (.*)")]
		public void SetOptionForCanadas5DigitPestControlNumbers(int rowNumber)
		{
			if (Report.IsTrue(new PesticideDetailsCanadaTableRow(rowNumber).RowNumberExists(), $"Failed to find row # {rowNumber}", "Successfully found row # {rowNumber}"))
			{
				Report.IsTrue(new PesticideDetailsCanadaTableRow(rowNumber).ClickRemoveIcon(), $"Failed to click Remove Icon for row {rowNumber}", $"Successfully clicked Remove Icon for row {rowNumber}");
			}
		}
		[RegexStepDefinition(@"In the 'Pesticide Details - Canada' after clicking Remove icon in 'Remove Item' modal window click button: (Yes|No)")]
		public void RemoveItemModalClickYesNo(string button)
		{
			string modalTitle = "Remove Item";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(modalTitle, button);
		}
		[RegexStepDefinition(@"In the 'Pesticide Details - Canada' 'Remove Item' modal window (should|should not) be displayed")]
		public void RemoveItemModalWindow(string condition)
		{
			string modalTitle = "Remove Item";

			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}
		[RegexStepDefinition(@"In the 'Pesticide Details - Canada' message 'For each Province make the appropriate selection from the options available' (should|should not) be displayed")]
		public void ForEachProvincemakeSelection(string condition)
		{
			string text = "For each Province, make the appropriate selection from the options available";
			new Steps_Prototype().AlertMessageDisplayed(condition, text);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Helpers;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "MyLibraryPage")]
	class Steps_MyLibrary
	{
		[RegexStepDefinition(@"In the My Library section, click the '(My Packaging Types|My Brands|My Distributors|My Ingredients|Contact Information per SDS(s))' link")]
		public void ClickTheLibraryLink(string linkText)
		{
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the My Library section, click the 'Clear' button")]
		public void ClickTheClearButton()
		{
			string linkText = "Clear";
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the My Library section, click the 'Add New' button")]
		public void ClickTheAddNewButton()
		{
			string linkText = "Add New";
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the My Library section, Validate Delete Product popup (should| should not) be displayed")]
		public void ValidateDeleteProductPopup(string condition)
		{
			string title = "Delete Product";
			string text = "Are you sure you want to remove this item?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, title, text);
		}

		[RegexStepDefinition(@"In the My Library section, in the 'Delete Product' pop up click (Delete|Close) button")]
		public void ClickDeleteCloseInDeleteProductPopUp(string button)
		{
			string popupTitle = "Delete Product";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}

		[RegexStepDefinition(@"In the My Library - Bill of Materials Section, click 'Add Row' button")]
		public void SetClickAddRow()
		{
			string button = "Add Row";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the My Library section, click action (Edit |Delete ) for product name: (.*)")]
		public void ClickActionForProduct(string productname, string action)
		{
			Report.IsTrue(new MyLibraryPage().ForProductClickAction(productname, action),
				$"Failed to click action:{action} for product: {productname}",
				$"Successfully clicked action: {action} for product: {productname}");
		}


		[RegexStepDefinition(@"In the My Library section, I filter by Product ID/Name for product: (.*)")]
		public void FilterProduct(string value)
		{
			string fieldname = "Product ID/ Name";
			new MyLibraryPage().EnterText(fieldname, value);
			Report.IsTrue(new MyLibraryPage().ClickSearch(),
				$"Failed to search for product: {value}",
				$"Successfully searched for product: {value}");
		}

		[RegexStepDefinition(@"In the My Library section, Enter Packaging Type Name: (.*)")]
		public void EnterPackageTypeName(string value)
		{
			string fieldname = "Package Type Name";
			new MyLibraryPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the My Library section, click 'Continue' button")]
		public void ClickContinue()
		{
			string button = "Continue";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the My Library section, 'Package Type Name' section  should be displayed")]
		public void ThenInThePageIShouldSeePackageTypeName()
		{
			string section_name = "Package Type Name";
			Report.IsTrue(new MyLibraryPage().SectionExists(section_name),
				"Package Type Name Field is not showing as expected", "Package Type Name Field is showing as expected");
		}

		[RegexStepDefinition(@"In the My Library section, 'Bill of Materials' section should be displayed")]
		public void ThenInThePageIShouldSeeBillOfMaterials()
		{
			string section_name = "Bill of Materials";
			Report.IsTrue(new MyLibraryPage().SectionExists(section_name),
				"Bill of Materials section is not showing", "Bill of Materials section is showing");
		}

		[RegexStepDefinition(@"In the My Library - CONEG Section, set the option in section: 'Does your container or any packaging in contact with food or drink \(including cap\) contain Bisphenol A \(BPA\)' to: (Yes|No)")]
		public void SelectPackagingInContact(string option)
		{
			string section = "Does your container or any packaging in contact with food or drink (including cap) contain Bisphenol A (BPA)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Library - CONEG Section, set the option in section: 'Do you have a CONEG Certificate for this package?' to: (Yes|No)")]
		public void SelectCONEGCertificateForPackage(string option)
		{
			string section = "Do you have a CONEG Certificate for this package?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Library - CONEG Section, confirm the question: 'Do you have a CONEG Certificate for this package?' (is|is not) displayed")]
		public void ConfirmCONEGCertificateForPackageIsIsNotDisplayed(string is_isnot)
		{
			string section = "Do you have a CONEG Certificate for this package?";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the My Library - CONEG Section, confirm the question: 'Does your container or any packaging in contact with food or drink \(including cap\) contain Bisphenol A \(BPA\)' (is|is not) displayed")]
		public void ConfirmPackagingInContactIsIsNotDisplayed(string is_isnot)
		{
			string section = "Does your container or any packaging in contact with food or drink (including cap) contain Bisphenol A (BPA)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the My Library - CONEG Section, confirm the question: 'Does your container contain the following?' (is|is not) displayed")]
		public void ConfirmContainerContainFollowingIsIsNotDisplayed(string is_isnot)
		{
			string section = "Does your container contain the following?";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}


		[RegexStepDefinition(@"In the My Library - CONEG Section, confirm the question: 'Packaging Component Recyclable Number' (is|is not) displayed")]
		public void ConfirmPackagingComponentRecyclableNumberIsIsNotDisplayed(string is_isnot)
		{
			string section = "Packaging Component Recyclable Number";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the My Library - CONEG Section, set the option in section: 'Packaging Component Recyclable Number' to: (.*)")]
		public void SetPotassium(string option)
		{
			string section = "Packaging Component Recyclable Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Library - CONEG section, confirm the packaging type: (.*) (is|is not) deleted")]
		public void InSectionPackagingTypetIsIsNotDeleted(string text, string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new MyLibraryPage().ProductNameDisplayed(text) != expected,
				$"Failure, '{text}'packaging type is not deleted", $"Success, '{text}' packaging type is deleted");
		}

		[RegexStepDefinition(@"In the My Library - CONEG section, Check or Uncheck for the section (.*): Does your container contain the following? to : (Lead|Mercury|Cadmium|Hexavalent Chromium|None of the Above)")]
		public void CheckOrUncheckRetailersSellingLocation(string section, string option)
		{
			if (section == "check")
			{
				new Steps_Prototype().ICheckTheCheckboxWithDescription(section, option);
			}
			else if (section == "uncheck")
			{
				new Steps_Prototype().ICheckTheCheckboxWithDescription(section, option);
			}
		}

		[RegexStepDefinition(@"In the My Library - CONEG section, How much in PPM? for section: (Lead|Mercury|Cadmium|Hexavalent Chromium|None of the Above), Enter value:(.*)")]
		public void EnterPPMValueForOption(string option, string value)
		{
			Report.StartStep($"Attempting to enter '{value}' into How much in PPM? text input.");
			new MyLibraryPage().EnterValueforPPM(option,value);


		}
	}

}

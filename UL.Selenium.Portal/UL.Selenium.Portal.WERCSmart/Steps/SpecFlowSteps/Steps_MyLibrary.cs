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
		//[RegexStepDefinition(@"Click link element with test: (.*)")]
		public void ClickLinkElement(string tableName, string linkText)
		{
			if (Report.IsTrue(new MyLibraryPage().LinkElementExists(tableName, linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}"))
			{
				Report.IsTrue(new MyLibraryPage().LinkElementClick(tableName, linkText), $"Failed to click link element with text {linkText}", $"Successfully clicked link element with text {linkText}");
			}
		}


		[RegexStepDefinition(@"In the My Library section, click the '(My Packaging Types|My Brands|My Distributors|My Ingredients|Contact Information per SDS(s))' link")]
		public void ClickTheLibraryLink(string linkText)
		{
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		#region  Packaging Type section

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, click the 'Clear' button")]
		public void ClickTheClearButton()
		{
			string tableName = "myLibrary";
			string linkText = "Clear";
			this.ClickLinkElement(tableName, linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, click the 'Add New' button")]
		public void ClickTheAddNewButton()
		{
			string tableName = "myLibrary";
			string linkText = "Add New";
			this.ClickLinkElement(tableName,linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, Validate Delete Product popup (should| should not) be displayed")]
		public void ValidateDeleteProductPopup(string condition)
		{
			string title = "Delete Product";
			string text = "Are you sure you want to remove this item?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, title, text);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, in the 'Delete Product' pop up click (Delete|Close) button")]
		public void ClickDeleteCloseInDeleteProductPopUp(string button)
		{
			string popupTitle = "Delete Product";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - Bill of Materials Section, click 'Add Row' button")]
		public void SetClickAddRow()
		{
			string button = "Add Row";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, click action (Edit |Delete ) for product name: (.*)")]
		public void ClickActionForProduct(string productname, string action)
		{
			Report.IsTrue(new MyLibraryPage().ForProductClickAction(productname, action),
				$"Failed to click action:{action} for product: {productname}",
				$"Successfully clicked action: {action} for product: {productname}");
		}


		[RegexStepDefinition(@"In the My Library - My Packaging Type section,Filter by Product ID/Name for product: (.*)")]
		public void FilterProduct(string value)
		{
			string fieldname = "Product ID/ Name";
			string tablename = "Library";
			new MyLibraryPage().EnterText(fieldname, value);
			Report.IsTrue(new MyLibraryPage().ClickSearch(tablename),
				$"Failed to search for product: {value}",
				$"Successfully searched for product: {value}");
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, Enter Packaging Type Name: (.*)")]
		public void EnterPackageTypeName(string value)
		{
			string fieldname = "Package Type Name";
			new MyLibraryPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, click 'Continue' button")]
		public void ClickContinue()
		{
			string button = "Continue";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, 'Package Type Name' section  should be displayed")]
		public void ThenInThePageIShouldSeePackageTypeName()
		{
			string section_name = "Package Type Name";
			Report.IsTrue(new MyLibraryPage().SectionExists(section_name),
				"Package Type Name Field is not showing as expected", "Package Type Name Field is showing as expected");
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section, 'Bill of Materials' section should be displayed")]
		public void ThenInThePageIShouldSeeBillOfMaterials()
		{
			string section_name = "Bill of Materials";
			Report.IsTrue(new MyLibraryPage().SectionExists(section_name),
				"Bill of Materials section is not showing", "Bill of Materials section is showing");
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, set the option in section: 'Does your container or any packaging in contact with food or drink \(including cap\) contain Bisphenol A \(BPA\)' to: (Yes|No)")]
		public void SelectPackagingInContact(string option)
		{
			string section = "Does your container or any packaging in contact with food or drink (including cap) contain Bisphenol A (BPA)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, set the option in section: 'Do you have a CONEG Certificate for this package?' to: (Yes|No)")]
		public void SelectCONEGCertificateForPackage(string option)
		{
			string section = "Do you have a CONEG Certificate for this package?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, confirm the question: 'Do you have a CONEG Certificate for this package?' (is|is not) displayed")]
		public void ConfirmCONEGCertificateForPackageIsIsNotDisplayed(string is_isnot)
		{
			string section = "Do you have a CONEG Certificate for this package?";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, confirm the question: 'Does your container or any packaging in contact with food or drink \(including cap\) contain Bisphenol A \(BPA\)' (is|is not) displayed")]
		public void ConfirmPackagingInContactIsIsNotDisplayed(string is_isnot)
		{
			string section = "Does your container or any packaging in contact with food or drink (including cap) contain Bisphenol A (BPA)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, confirm the question: 'Does your container contain the following?' (is|is not) displayed")]
		public void ConfirmContainerContainFollowingIsIsNotDisplayed(string is_isnot)
		{
			string section = "Does your container contain the following?";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}


		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, confirm the question: 'Packaging Component Recyclable Number' (is|is not) displayed")]
		public void ConfirmPackagingComponentRecyclableNumberIsIsNotDisplayed(string is_isnot)
		{
			string section = "Packaging Component Recyclable Number";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG Section, set the option in section: 'Packaging Component Recyclable Number' to: (.*)")]
		public void SetPotassium(string option)
		{
			string section = "Packaging Component Recyclable Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG section, confirm the packaging type: (.*) (is|is not) deleted")]
		public void InSectionPackagingTypetIsIsNotDeleted(string text, string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new MyLibraryPage().ProductNameDisplayed(text) != expected,
				$"Failure, '{text}'packaging type is not deleted", $"Success, '{text}' packaging type is deleted");
		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG section, Check or Uncheck for the section (.*): Does your container contain the following? to : (Lead|Mercury|Cadmium|Hexavalent Chromium|None of the Above)")]
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

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - CONEG section, How much in PPM? for section: (Lead|Mercury|Cadmium|Hexavalent Chromium|None of the Above), Enter value:(.*)")]
		public void EnterPPMValueForOption(string option, string value)
		{
			Report.StartStep($"Attempting to enter '{value}' into How much in PPM? text input.");
			new MyLibraryPage().EnterValueforPPM(option,value);


		}

		[RegexStepDefinition(@"In the My Library - My Packaging Type section - Bill of Materials Section, In row: (.*) - Enter My Packaging Materials value: (.*) and My Packaging Weight value:(.*)")]
		public void EnterValueInBillOfMaterials(string row, string packagingmaterialvalue, string weightvalue)
		{
			Report.StartStep($"Attempting to enter '{packagingmaterialvalue}' into My Packaging Materials input on row {row}.");
			new MyLibraryPage().EnterMyPackagingMaterials(row, packagingmaterialvalue);

			Report.StartStep($"Attempting to enter '{weightvalue}' into Packaging Weight input on row {row}.");
			new MyLibraryPage().EnterMyPackagingWeight(row, weightvalue);

		}

        #endregion

		#region My Brands section

		[RegexStepDefinition(@"In the My Library - My Brands section, Filter by Product Line for product: (.*)")]
		public void FilterProductLine(string value)
		{
			string fieldname = "Product Line";
			string tablename = "brand";
			new MyLibraryPage().EnterText(fieldname, value);
			Report.IsTrue(new MyLibraryPage().ClickSearch(tablename),
				$"Failed to search for product: {value}",
				$"Successfully searched for product: {value}");
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, click the 'Clear' button")]
		public void ClickClearButtonInBrandsSection()
		{
			string tableName = "brand";
			string linkText = "Clear";
			this.ClickLinkElement(tableName, linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, click the 'Add New' button")]
		public void ClickTheAddNewButtonInBrandsSection()
		{
			string tableName = "brand";
			string linkText = "Add New";
			this.ClickLinkElement(tableName,linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, Verify Products table is displayed")]
		public void VerifyProductsTableIsDisplayed()
		{
			string name = "brand";
			Report.IsTrue(new MyLibraryPage().ProductTableExists(name), $"{name} table is not displayed", $"Successfully {name} table is displayed");
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, in the 'cancel' pop up click (Yes|No) button")]
		public void ClickYesNoCancelPopUp(string button)
		{
			string popupTitle = "Are you sure you wish to cancel?";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, the 'Are you sure you wish to cancel?' popup (should|should not) be displayed")]
		public void AreYouSureYouWishToCancelIsDisplayed(string condition)
		{
			string modalTitle = "Are you sure you wish to cancel?";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, click action Edit for product name: (.*)")]
		public void ClickActionForProductLine(string productname)
		{
			Report.IsTrue(new MyLibraryPage().ForBrandsClickEditInAction(productname),
				$"Failed to click action:Edit for product: {productname}",
				$"Successfully clicked action: Edit for product: {productname}");
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, Under Actions click the 'Save' button")]
		public void ClickTheSaveButtonInBrandsSection()
		{
			string tableName = "brand";
			string linkText = "Save";
			this.ClickLinkElement(tableName,linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, Under Actions click the 'Cancel' button")]
		public void ClickTheCancelButtonInBrandsSection()
		{
			string tableName = "brand";
			string linkText = "Cancel";
			this.ClickLinkElement(tableName, linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, Add or Edit  Product Line /Brand Line : (.*)")]
		public void EnterValueInProductLine(string productLineValue)
		{
			Report.StartStep($"Attempting to enter '{productLineValue}' into Product Line / Brand Line");
			new MyLibraryPage().EnterProductLine(productLineValue);


		}

		[RegexStepDefinition(@"In the My Library - My Brands section, (check|uncheck) the 'Active?' checkbox")]
		public void ICheckTheCheckboxActive(string check)
		{
			bool toCheck = false;
			if (check == "check")
			{
				toCheck = true;
			}
			else if (check == "uncheck")
			{
				toCheck = false;
			}
			else
			{
				throw new Exception("Specflow paramater must be equal to 'check' or 'uncheck'");
			}
			bool isChecked = new MyLibraryPage().ActiveCheckbox().Checked();
			if (isChecked == toCheck)
			{
				Report.Success($"The checkbox was already {check}ed");
				return;
			}
			Report.IsTrue(new MyLibraryPage().CheckActiveCheckbox(),
				$"Failed to check the checkbox!",
				$"Successfully checked the checkbox");
			Report.IsTrue(new MyLibraryPage().ActiveCheckbox().Checked() == toCheck,
				$"The checkbox was not {check}ed after",
				$"The checkbox is {check}ed as expected");
		}

		[RegexStepDefinition(@"In the My Library - My Brands section, Under Active? it displays Yes/No")]
		public void VerifyActiveDisplaysYesorNo()
		{
			Report.IsTrue(new MyLibraryPage().ActiveDisplaysYesOrNo(),
				$"Failed to display Yes/No in Active column value?",
				$"Successfully displayed Yes/No in Active column value?");


		}


		[RegexStepDefinition(@"In the My Library - My Brands section, 'Product Line/ Brand Name' value: (.*) (is|is not) updated ")]
		public void VerifyProductLineValueUpdated(string value, string is_isnot)
		{
			if (is_isnot == "is")
			{
				Report.IsTrue(new MyLibraryPage().GetProductLineValue(value),
				$"Failed to update Product Line/ Brand Name",
				$"Successfully updated Product Line/ Brand Name");
			}
			else
			{
				Report.IsFalse(new MyLibraryPage().GetProductLineValue(value), " Product Line/ Brand Name is updated", " Product Line/ Brand Name is not updated");
			}
		}

        #endregion


		#region My Distributors section

		[RegexStepDefinition(@"In the My Library - My Distributors section, click the 'Clear' button")]
		public void ClickTheClearButtoninDistributorsSection()
		{
			string tableName = "distributor";
			string linkText = "Clear";
			this.ClickLinkElement(tableName, linkText);
		}

		[RegexStepDefinition(@"In the My Library - My Distributors section, Verify table is displayed")]
		public void VerifyDistributorsTableIsDisplayed()
		{
			string name = "distributor";
			Report.IsTrue(new MyLibraryPage().ProductTableExists(name), $"{name} table is not displayed", $"Successfully {name} table is displayed");
		}

		[RegexStepDefinition(@"In the My Library - My Distributors section, Search by Id or product name : (.*)")]
		public void FilterByIdorName(string value)
		{
			string fieldname = "Search by ID or Name";
			string tablename = "distributor";
			new MyLibraryPage().EnterText(fieldname, value);
			Report.IsTrue(new MyLibraryPage().ClickSearch(tablename),
				$"Failed to search for product: {value}",
				$"Successfully searched for product: {value}");
		}

		[RegexStepDefinition(@"In the My Library - My Distributors section, Filter product by (All|Pending|Approved|Rejected)")]
		public void FilterProductByPendingApprovedRejected(string filter)
		{
			string tableName = "distributor";
			this.ClickLinkElement(tableName, filter);
		}

		[RegexStepDefinition(@"In the My Library - My Distributors section, click action (Approve |Reject ) for product name: (.*)")]
		public void ClickActionForDistributorsSection(string productname, string action)
		{
			Report.IsTrue(new MyLibraryPage().ForDistributorClickAction(productname, action),
				$"Failed to click action:{action} for product: {productname}",
				$"Successfully clicked action: {action} for product: {productname}");
		}

		#endregion

	}

}

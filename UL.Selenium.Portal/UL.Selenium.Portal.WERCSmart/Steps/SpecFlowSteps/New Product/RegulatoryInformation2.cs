using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.Specialized;
using System.Security.Policy;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.DistributorSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryInformation2")]
	internal class RegulatoryInformation2
	{
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, set the option in section: 'Product contains microbeads' to: (Yes|No)")]
		public void SelectProductContainsMicrobeads(string option)
		{
			string section = "Product contains microbeads";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, set the option in section: 'Product is considered ""Rinse off""' to: (Yes|No)")]
		public void SelectProductRinseOff(string option)
		{
			string section = "Rinse off";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, click 'HR 1321' link")]
		public void ClickLinkHR1321()
		{
			string linkText = "HR 1321";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, click 'Free Water Act of 2015' link")]
		public void ClickLinkFreeWaterOf2015()
		{
			string linkText = "Free Water Act of 2015";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, 'HR 1321' link (should|should not) be displayed")]
		public void LinkHR1321Exists(string condition)
		{
			string linkText = "HR 1321";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, 'Free Water Act of 2015' link (should|should not) be displayed")]
		public void LinkFreeWaterAct1Exists(string condition)
		{
			string linkText = "Free Water Act of 2015";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}

		[RegexStepDefinition(@"In the Regulatory Information 2 Section, after clicking 'Free Water Act of 2015' link I switch to new tab")]
		public void SwitchedToNewTabAfterClickingFreeWeterActLink()
		{
			string url = "https://www.fda.gov/cosmetics/cosmetics-laws-regulations/microbead-free-waters-act-faqs";
			new Steps_Prototype().ConfirmNewTabOpenWithUrl(url);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, after clicking 'Free Water Act of 2015' link I close new opened tab")]
		public void AfterClickingFreeWeterActLinkICloseNewTab()
		{
			string url = "https://www.fda.gov/cosmetics/cosmetics-laws-regulations/microbead-free-waters-act-faqs";
			new Steps_Prototype().CloseTabWithUrl(url);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, after clicking 'Free Water Act of 2015' link I confirm new tab (should|should not) exists")]
		public void AfterClickingFreeWeterActLinkNewTabExists(string condition)
		{
			string url = "https://www.fda.gov/cosmetics/cosmetics-laws-regulations/microbead-free-waters-act-faqs";
			new Steps_Prototype().NewTabShouldExists(condition, url);
		}

		[RegexStepDefinition(@"In the Regulatory Information 2 Section, after clicking 'HR 1321' link I confirm pdf file is downloaded")]
		public void AfterClickingHR1321PdfIsDownloaded()
		{
			string file = "BILLS-114hr1321enr.pdf";
			string savedAs = "HR1321file";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
		[RegexStepDefinition(@"In the Regulatory Information 2 Section, after clicking 'HR 1321' link I compere downloaded pdf file with original file")]
		public void AfterClickingHR1321ComparePdfFile()
		{
			string downloadedFilePath = Context.GetFromContext("HR1321file")?.ToString() ?? "";
			string originalFilePath = "Dependencies.PDF.HR1321.pdf";
			new Steps_Prototype().CompareTwoPdfFiles(downloadedFilePath, originalFilePath);
		}
	}
}

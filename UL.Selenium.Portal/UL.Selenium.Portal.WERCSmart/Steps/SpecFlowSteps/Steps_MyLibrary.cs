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






	}

}

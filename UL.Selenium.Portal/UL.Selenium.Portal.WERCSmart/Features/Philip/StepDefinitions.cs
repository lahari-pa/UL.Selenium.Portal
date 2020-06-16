using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;


using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Xml;
using UL.Automation.Reporting;
using UL.Automation.Selenium.Classes;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.Utilities.Functions;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RetailerAbbreviations;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{
		public object TheProduct { get; private set; }
		public string File { get; private set; }


		[StepDefinition(@"I confirm that the the option: (.*) (.*) checked for the following section: (.*)")]
		public void ThenIConfirmThatTheTheOptionCheckedForTheFollowingSection(string option, string isOrIsNot, string section)
		{
			WebElements webElementsObject = new WebElements();

			if (isOrIsNot.ToLower() == "is")
			{
				Report.IsTrue(webElementsObject.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was not checked", "The option " + option + " was checked");
			} else
			{
				Report.IsTrue(!webElementsObject.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was checked", "The option " + option + " was not checked");
			}

		}

		[Then(@"I confirm that the following section is available for selection: (.*)")]
		public void ThenIConfirmThatTheFollowingSectionIsAvailableForSelection(string sectionName)
		{
			WebElements webElementsObject = new WebElements();
			webElementsObject.ConfirmSectionIsAvailableForSelection(sectionName);
		}


	}
}

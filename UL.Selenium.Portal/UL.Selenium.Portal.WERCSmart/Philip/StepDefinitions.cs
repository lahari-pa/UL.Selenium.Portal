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

	namespace UL.Selenium.Portal.WERCSmart.Philip
{
		[Binding, Scope(Tag = "Philip")]
		class StepDefinitions
	{
		[StepDefinition(@"Confirm that there is a CW column between Last Pub Date and GHS columns")]
		public void GivenConfirmThatThereIsACWColumnBetweenLastPubDateAndGHSColumns()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.CheckColumn();
		}

		[StepDefinition(@"Find product that has a Y in the CW column")]
		public void ThenFindProductThatHasAYInTheCWColumn()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.FindProduct();
		}

		[StepDefinition(@"Find product that has a N in the CW column")]
		public void ThenFindProductThatHasANInTheCWColumn()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.FindProductN();
		}


		[StepDefinition(@"I click vendor section")]
		public void ThenIClickVendorSection()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickVendorSection();
		}

		[StepDefinition(@"I click a section")]
		public void ThenIClickASection()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.ClickASection();
		}

		[StepDefinition(@"check text")]
		public void ThenCheckText()
		{
			WebElements WebElementsObject = new WebElements();
			WebElementsObject.CheckText();
		}

	}
}

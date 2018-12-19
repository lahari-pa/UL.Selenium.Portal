using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_PesticideDetailsUS
	{
		[StepDefinition(@"I add the EPA registration number: (.*)")]
		public void IAddTheEPARegistrationNumber(string epaNumber)
		{
			// New EPA rows are always added to the top of the stack, so check if top row has any data before entering the test value
			var newProductpage = new NewProduct();
			if (!newProductpage.TopEPARowIsEmpty())
			{
				Report.Info("Adding a new EPA row because there is pre-existing data");
				Report.IsTrue(newProductpage.AddEPARow(),
					"New EPA Row was not added successfully",
					"New EPA Row was added successfully");
				Report.Info("Entering the EPA number: " + epaNumber);
				Report.IsTrue(newProductpage.EnterEPATopRow(epaNumber),
					"The EPA Number " + epaNumber + " was not successfully added to the top EPA table row",
					"The EPA Number " + epaNumber + " was successfully added to the top EPA table row");
			}
			else
			{
				Report.Info("Entering the EPA number: " + epaNumber);
				Report.IsTrue(newProductpage.EnterEPATopRow(epaNumber),
					"The EPA Number " + epaNumber + " was not successfully added to the top EPA table row",
					"The EPA Number " + epaNumber + " was successfully added to the top EPA table row");
			}
		}
	}
}

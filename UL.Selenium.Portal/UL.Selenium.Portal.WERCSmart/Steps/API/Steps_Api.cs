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
using NTTQA.Selenium.Cache;
using NTTQA.Selenium.Reporting.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.API
{
	[Binding, Scope(Tag = "API")]
	class Steps_Api
	{
		[StepDefinition(@"I authenticate username: (.*), password: (.*)")]
		public void AuthenticateTestUser(string userName, string password)
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

			var token = "";
			var loginUrl = TestVariables.GetVariableSavedAs("BaseApiUrl") + @"/users/login";

			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/json");
				var ret = wc.UploadString(loginUrl, "POST", "{\"username\": \"" + userName + "\",\"password\": \"" + password + "\"}");
				token = Regex.Match(ret, "\"(.*)\"").Groups[1].Value;
				Context.AddToContext("ApiSavedToken", token, true);
			}

			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a token for user: " + userName, "Successfully acquired a token for user: " + userName, false, false);
		}

		[StepDefinition(@"I save the Waste Hauler report for UPC: (.*) as: (.*)")]
		public void GetWasteHaulerReport(string upc, string reportSavedAs)
		{
			var token = (string)Context.GetFromContext("ApiSavedToken");
			var requestUrl = TestVariables.GetVariableSavedAs("BaseApiUrl") + @"/upc/" + upc + "/waste_profile";
			var xml = "";

			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/json");
				wc.Headers.Add("Token", token);
				xml = wc.DownloadString(requestUrl);
				Context.AddToContext(reportSavedAs, xml, true);
			}

			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a xml for UPC: " + upc, "Successfully acquired a report for UPC: " + upc, false, false);

			using (var sw = new StreamWriter(Path.Combine(ReportingParameters.ReportFolder, "Test.xml")))
			{
				sw.Write(xml);
				sw.Flush();
				sw.Close();
			}

			Report.XMLFile(Path.Combine(ReportingParameters.ReportFolder, "Test.xml"));
		}
	}
}

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
using NTTQA.Selenium.Cache;
using NTTQA.Selenium.Reporting.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;


using System.Globalization;
using Newtonsoft.Json.Converters;

namespace UL.Selenium.Portal.WERCSmart.Steps.API
{
	[Binding, Scope(Tag = "API")]
	class Steps_Api
	{
		[StepDefinition(@"I authenticate ItemSync username: (.*), password: (.*)")]
		public void AuthenticateTestUserItemSync(string userName, string password)
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate
			{ return true; });

			string token = "";
			string loginUrl = "https://lookup.wercsmart.com/RequestedUPCServiceTest/api/ClientAPI"/*TestVariables.GetVariableSavedAs("ItemSyncApiEndpoint")*/;

			using (var wc = new WebClient())
			{
				wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
				string ret = wc.UploadString(loginUrl, "POST", "UserName=" + userName + "&Password=" + password);
				var coordinate = Coordinate.FromJson<ItemSyncResponse>(ret);
				token = coordinate.sToken;
				Context.AddToContext("ApiSavedToken", token, true);
			}
			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a token for user: " + userName, "Successfully acquired a token for user: " + userName, false, false);
		}

		[Given(@"I authenticate WasteHauler username: (.*), password: (.*)")]
		public void GivenIAuthenticateWasteHaulerUsername(string userName, string password)
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate
			{ return true; });

			var token = "";
			var loginUrl = TestVariables.GetVariableSavedAs("WasteHaulerApiEndpoint") + @"/users/login";

			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				var ret = wc.UploadString(loginUrl, "POST", "UserName=" + userName.Replace("@", "%40")/*rich.french%40ul.com*/+ "&Password=" + password/*Asdf123!*/);
				token = Regex.Match(ret, "\"(.*)\"").Groups[1].Value;
				Context.AddToContext("ApiSavedToken", token, true);
			}

			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a token for user: " + userName, "Successfully acquired a token for user: " + userName, false, false);
		}

		[StepDefinition(@"I save the Item Sync report as: (.*) using Retailer GUID: (.*) and")]
		public void ThenISaveTheItemSyncReportForUPCAsItemSyncSavedAs(string savedAs, string guid, Table table)
		{

			string token = (string)Context.GetFromContext("ApiSavedToken");

			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a xml for GUID: " + guid, "Successfully acquired a report for GUID: " + guid, false, false);

			string requestUrl = "https://lookup.wercsmart.com/RequestedUPCServiceTest/api/ClientAPI"/*TestVariables.GetVariableSavedAs("ItemSyncApiEndpoint")*/ + "/ProcessRetailerUPCList?client=" + guid + "&Token=" + token;


			string requestBody = this.MakeRequestString(table);

			string xml = "";

			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "text/xml");
				wc.Headers.Add("Token", token);
				xml = wc.UploadString(requestUrl, "POST", requestBody);
				Context.AddToContext(savedAs, xml, true);
			}

			using (var sw = new StreamWriter(Path.Combine(ReportingParameters.ReportFolder, "Test.xml")))
			{
				sw.Write(xml);
				sw.Flush();
				sw.Close();
			}

			Report.XMLFile(Path.Combine(ReportingParameters.ReportFolder, "Test.xml"));

		}

		private string MakeRequestString(Table table)
		{
			string req = "<upclist>";
			foreach (TableRow row in table.Rows)
			{
				req = req + "<upc gtin=\"" + row["UPC"] + "\" status=\"\" />";
			}
			req = req + "</upclist>";
			return req;
		}

		[StepDefinition(@"I save the Waste Hauler report for UPC: (.*) as: (.*)")]
		public void GetWasteHaulerReport(string upc, string reportSavedAs)
		{
			var token = (string)Context.GetFromContext("ApiSavedToken");
			var requestUrl = TestVariables.GetVariableSavedAs("ItemSyncApiEndpoint") + @"/upc/" + upc + "/waste_profile";
			var xml = "";

			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/json");
				wc.Headers.Add("Token", token);
				xml = wc.DownloadString(requestUrl);
			}

			Context.AddToContext("xml", xml);

			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a xml for UPC: " + upc, "Successfully acquired a report for UPC: " + upc, false, false);
			Report.Info("Response includes data: " + !string.IsNullOrEmpty(xml));

			using (var sw = new StreamWriter(Path.Combine(ReportingParameters.ReportFolder, "Test.xml")))
			{
				sw.Write(xml);
				sw.Flush();
				sw.Close();
			}

			Report.XMLFile(Path.Combine(ReportingParameters.ReportFolder, "Test.xml"));
		}

		[StepDefinition(@"I verify that data was returned as expected from file saved as: (.*)")]
		public void ThenIVerifyThatDataWasReturnedAsExpected(string savedAs)
		{
			string returnedData = (string)Context.GetFromContext(savedAs);
			Report.IsTrue(returnedData.Trim().Length > 0, "Response recieved, but is 0 characters long.", "Returned the following: " + returnedData, false, false);
		}

		public class ItemSyncResponse
		{
#pragma warning disable IDE1006 // Naming Styles: API returns formatted XML.
			public bool bError { get; set; }
			public string sErrorMessage { get; set; }
			public string sToken { get; set; }
#pragma warning restore IDE1006 // Naming Styles
		}
	}
	public class Coordinate
	{
		public static T FromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
	}

	public static class Serialize
	{
		public static string ToJson(this object self) => JsonConvert.SerializeObject(self, Converter.Settings);
	}

	internal static class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
}

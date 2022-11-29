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
using Newtonsoft.Json;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;


using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Xml;
using UL.Automation.Reporting;
using UL.Automation.WebDriver.Classes;
using UL.Automation.TReVor.Classes;

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
			string loginUrl = TestVariables.GetVariableSavedAs("ItemSyncApiEndpoint");

			using (var wc = new WebClient())
			{
				wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
				string ret = wc.UploadString(loginUrl, "POST", "UserName=" + userName + "&Password=" + password);
				var data = Coordinate.FromJson<ItemSyncTokenResponse>(ret);
				if (data.bError)
				{
					Report.Failure("Token was not retrieved. Returned error message: " + data.sErrorMessage);
				}
				else
				{
					token = data.sToken;
					Context.AddToContext("ApiSavedToken", token, true);
				}
			}
			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a token for user: " + userName, "Successfully acquired a token for user: " + userName, false, false);
		}

		[StepDefinition(@"I authenticate WasteHauler username: (.*), password: (.*)")]
		public void GivenIAuthenticateWasteHaulerUsername(string userName, string password)
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate
			{ return true; });

			var token = "";
			var loginUrl = TestVariables.GetVariableSavedAs("WasteHaulerApiEndpoint") + @"/users/login";

			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				var ret = wc.UploadString(loginUrl, "POST", "UserName=" + userName.Replace("@", "%40") + "&Password=" + password);
				token = Regex.Match(ret, "\"(.*)\"").Groups[1].Value;
				Context.AddToContext("ApiSavedToken", token, true);
			}

			Report.IsTrue(!string.IsNullOrEmpty(token), "Failed to find a token for user: " + userName, "Successfully acquired a token for user: " + userName, false, false);
		}

		[StepDefinition(@"I save the Item Sync report as: (.*) using Retailer GUID: (.*) and")]
		public void ThenISaveTheItemSyncReportForUPCAsItemSyncSavedAs(string savedAs, string guid, Table table)
		{
			var tableData = new Dictionary<string, string>();
			var reportData = new Dictionary<string, string>();

			foreach (TableRow row in table.Rows)
			{
				tableData.Add(Context.GetFromContext(row["UPC saved as"]).ToString().PadLeft(14, '0'), row["Expected Status"]);
			}

			string token = (string)Context.GetFromContext("ApiSavedToken");

			if (TestVariables.GetVariableSavedAs("ItemSyncApiEndpoint") != null)
			{

				string requestUrl = TestVariables.GetVariableSavedAs("ItemSyncApiEndpoint") + "/ProcessRetailerUPCList?client=" + guid + "&Token=" + token;

				string requestBody = this.MakeRequestString(tableData);
				string xml = string.Empty;
				using (var wc = new WebClient())
				{
					wc.Headers.Add("Content-Type", "text/xml");
					wc.Headers.Add("Token", token);
					xml = wc.UploadString(requestUrl, "POST", requestBody);
					Context.AddToContext(savedAs, xml, true);
				}

				Report.IsTrue(!string.IsNullOrEmpty(xml), "Failed to return xml for GUID: " + guid, "Successfully acquired a report for GUID: " + guid, false, false);

				var doc = new XmlDocument();
				doc.LoadXml(xml);
				foreach (XmlNode node in doc.DocumentElement)
				{
					XmlAttributeCollection AttrColl = node.Attributes;
					reportData.Add(AttrColl[0].Value, AttrColl[1].Value);
				}

				foreach (var key in tableData.Keys)
				{
					var str = reportData[key];
					Report.IsTrue(str == tableData[key],
						string.Format("UPC {0} returned {1} but expected {2}", key, reportData[key], tableData[key]),
						string.Format("UPC {0} returned {1} as expected", key, reportData[key]), false, false);
				}

				using (var sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(ReportSettings.ReportFile), "Test.xml")))
				{
					sw.Write(xml);
					sw.Flush();
					sw.Close();
				}

				Report.File(Path.Combine(Path.GetDirectoryName(ReportSettings.ReportFile), "Test.xml"));

				foreach (string str in doc.GetElementsByTagName("gtin"))
				{
					string thing = doc.GetElementsByTagName("status").ToString();
				}
			}
			else
			{
				Report.Info("Testing this API is impossible in Sprint1, Sprint2, and QA. It only exists in Staging.");
			}
		}



		private string MakeRequestString(Dictionary<string, string> dictionary)
		{
			string req = "<upclist>";
			foreach (KeyValuePair<string, string> row in dictionary)
			{
				req = req + "<upc gtin=\"" + row.Key + "\" status=\"\" />";
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

			using (var sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(ReportSettings.ReportFile), "Test.xml")))
			{
				sw.Write(xml);
				sw.Flush();
				sw.Close();
			}

			Report.File(Path.Combine(Path.GetDirectoryName(ReportSettings.ReportFile), "Test.xml"));
		}

		[StepDefinition(@"I verify that data was returned as expected from file saved as: (.*)")]
		public void ThenIVerifyThatDataWasReturnedAsExpected(string savedAs)
		{
			string returnedData = (string)Context.GetFromContext(savedAs);
			Report.IsTrue(returnedData.Trim().Length > 0, "Response recieved, but is 0 characters long.", "Returned the following: " + returnedData, false, false);
		}

		public class ItemSyncTokenResponse
		{
#pragma warning disable IDE1006 // Naming Styles: API returns formatted XML.
			public bool bError { get; set; }
			public string sErrorMessage { get; set; }
			public string sToken { get; set; }
#pragma warning restore IDE1006 // Naming Styles
		}

		public class ItemSyncResponseData
		{
#pragma warning disable IDE1006 // Naming Styles: API returns formatted XML.
			public string status { get; set; }
			public string gtin { get; set; }

			public static Dictionary<string, string> data = new Dictionary<string, string>();

			ItemSyncResponseData(string status, string gtin)
			{
				this.status = status;
				this.gtin = gtin;

				data.Add(gtin, status);
			}
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

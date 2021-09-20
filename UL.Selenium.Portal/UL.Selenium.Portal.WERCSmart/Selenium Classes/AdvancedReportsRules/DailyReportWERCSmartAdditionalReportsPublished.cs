using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using System;
using System.Collections.Generic;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.AdvancedReportsRules
{
	class DailyReportWERCSmartAdditionalReportsPublished
	{
		public class Records
		{
			internal string Description { get; set; }
			internal string Fee { get; set; }
			internal string AdditionalLanguageFee { get; set; }

			public Records(string description, string fee, string addLangFee)
			{
				this.Description = description;
				this.Fee = fee;
				this.AdditionalLanguageFee = addLangFee;
			}

		}


		static Dictionary<string, Records> _reportData = new Dictionary<string, Records>()
		{
			{"5GHS",new Records(description:"Mexico GHS SDS",fee:"275",addLangFee:"125")},
			{"AGHS",new Records(description:"OSHA GHS SDS",fee:"275",addLangFee:"125")},
			{"BGHS",new Records(description:"Brazil GHS SDS",fee:"275",addLangFee:"125")},
			{"CGHS",new Records(description:"China GHS SDS",fee:"275",addLangFee:"125")},
			{"CRLA",new Records(description:"Critical List Analysis / Inventory Status Report",fee:"25",addLangFee:"-2")},
			{"DGHS",new Records(description:"Vietnam  GHS SDS",fee:"275",addLangFee:"125")},
			{"EGHS",new Records(description:"European GHS SDS",fee:"275",addLangFee:"-2")},
			{"HGHS",new Records(description:"Canada GHS SDS",fee:"275",addLangFee:"125.00")},
			{"IGHS",new Records(description:"Indonesia  GHS SDS",fee:"275",addLangFee:"125")},
			{"JGHS",new Records(description:"Japan GHS SDS",fee:"275",addLangFee:"125")},
			{"KGHS",new Records(description:"Korea GHS SDS",fee:"275",addLangFee:"125")},
			{"NGHS",new Records(description:"North American Combined GHS SDS",fee:"275",addLangFee:"125.00")},
			{"PDRR",new Records(description:"Product Development Regulatory Report",fee:"50",addLangFee:"-2")},
			{"SGHS",new Records(description:"Singapore GHS SDS",fee:"275",addLangFee:"125")},
			{"TFRE",new Records(description:"Transportation Classification",fee:"0",addLangFee:"-2")},
			{"TGHS",new Records(description:"Thailand GHS SDS",fee:"275",addLangFee:"125")},
			{"TPAD",new Records(description:"Transportation Classification +",fee:"25",addLangFee:"-2")},
			{"TWNG",new Records(description:"Taiwan GHS SDS",fee:"275",addLangFee:"125")},
			{"UGHS",new Records(description:"Australia GHS SDS",fee:"275",addLangFee:"125")},
			{"VERE",new Records(description:"Assessment Summary Report",fee:"0",addLangFee:"-2")},
			{"VOCR",new Records(description:"VOC Restriction",fee:"0",addLangFee:"-2")},
			{"YGHS",new Records(description:"Malaysia GHS SDS",fee:"275",addLangFee:"125")},

		};

		static readonly List<KeyValuePair<string, string>> _costs = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("VOCR", "0"), new KeyValuePair<string, string>("", "") };

		static void ProcessOutput(List<List<string>> errorLog)
		{
			if (errorLog.Count > 0)
			{
				foreach (List<string> error in errorLog)
				{
					var record = string.Empty;
					foreach (var detail in error)
					{
						record = record + detail + " :: ";
					}
					Report.Error(record);
				}
			}
		}




		public bool VerifyFile(string savedAs)
		{
			var results = new List<List<string>>();
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");

				for (int i = 1; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					List<string> row = ExcelUtils.Excel_GetRow(i);
					List<string> errorRecords = ValidateData(row);

					if (errorRecords.Count > 0)
					{
						errorRecords.Add(i.ToString());
						results.Add(errorRecords);
					}
				}
			}
			ProcessOutput(results);

			return (results.Count == 0);
		}

		private static List<string> ValidateData(List<string> row)
		{
			var errorReport = new List<string>();
			string subformat = row[0];
			_reportData.TryGetValue(subformat, out Records rec);

			if (rec is null)
			{
				row.Add(" :: Not defined");
				errorReport.AddRange(row);
			}
			else
			{
				SeleniumBrowser.ScrollToTopOfPage();

				if (rec.Description != row[1])
				{
					errorReport.Add("Description " + row[0] + " :: " + row[1] + " is invalid");
				}

				if (rec.Fee != row[2])
				{
					errorReport.Add("Fee " + row[0] + " :: " + row[2] + " is invalid");
				}

				if (rec.AdditionalLanguageFee != row[3])
				{
					errorReport.Add("Additional Language Fee " + row[0] + " :: " + row[3] + " is invalid");
				}

				if (!float.TryParse(row[5], out float unused))
				{
					errorReport.Add("Reports Published field " + row[0] + " :: " + row[5] + " is not an integer");
				}
			}

			return errorReport;
		}
	}
}

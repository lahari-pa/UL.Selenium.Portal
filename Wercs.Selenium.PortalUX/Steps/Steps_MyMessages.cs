using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "MyMessages")]
	class StepsMyMessages
	{
		[StepDefinition(@"I click the (Export|Filter|Clear Filter) button")]
		public void ClickPrimaryButton(string button)
		{
			Report.IsTrue(new MessageCenter().ClickPrimaryButton(button),
				"Failed to click the " + button + " button",
				"Successfully clicked the " + button + " button");
		}

		[StepDefinition(@"I confirm an excel file is downloaded then close the Report Download popup. I save the file as (.*)")]
		public void ExcelFileDownloadedCloseReportDownload(string savedAs)
		{
			var selReportDownload = new ReportDownload();
			if (selReportDownload.Wait_for_load())
			{
				var count = 0;
				Report.Info("Confirm file is downloaded");
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				while (count < 120)
				{
					var today = DateTime.Today;
					var todayDate = today.Month + "-" + today.Day + "-" + today.Year.ToString().Remove(0, 2);
					var path = downloadsFolder + @"\" + todayDate + "*.xlsx";
					var downloads = new DirectoryInfo(downloadsFolder);
					var dir = downloads.GetFiles(path);
					//var dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
					if (dir.Any())
					{
						var mostRecent = dir.OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
						Report.Success("File with name: " + mostRecent + " was found in the download directory");
						Report.Info("Closing the Report Download popup");
						Report.IsTrue(selReportDownload.ClickClose(),
							"Failed to close the Report Download popup",
							"Successfully closed the Report Download popup");
						Context.AddToContext(savedAs, mostRecent);
						return;
					}
					Delay.Seconds(1);
					count++;
				}
				Report.Failure("Unable to find correct excel file in the download directory after 120 seconds");
				Report.Info("Closing the Report Download popup");
				Report.IsTrue(selReportDownload.ClickClose(),
					"Failed to close the Report Download popup",
					"Successfully closed the Report Download popup");
			}
		}
	}
}

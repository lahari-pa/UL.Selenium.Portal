using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
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

		[StepDefinition(@"I click the 'Show Archived' checkbox")]
		public void ClickShowArchived()
		{
			Report.IsTrue(new MessageCenter().ClickShowArchived(),
				"Failed to click the Show Archived checkbox!" +
				"Successfully clicked the Show Archived checkbox");
		}

		[StepDefinition(@"I click Filter")]
		public void ClickFilter()
		{
			Report.IsTrue(new MessageCenter().ClickFilter(),
				"Failed to click Filter",
				"Successfully clicked Filter");
		}

		[StepDefinition(@"I confirm an excel file is downloaded then close the Report Download popup. I save the file as (.*)")]
		public void ExcelFileDownloadedCloseReportDownload(string savedAs)
		{
			var selReportDownload = new ReportDownload();
			if (selReportDownload.Wait_for_load())
			{
				int count = 0;
				Report.Info("Confirm file is downloaded");
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				DateTime today = DateTime.Today;
				string date = today.ToString("M'-'dd'-'yyyy");
				string path = date + "*.xlsx";
				var downloads = new DirectoryInfo(downloadsFolder);
				while (count < 120)
				{
					Delay.Seconds(1);
					FileInfo[] dir = downloads.GetFiles(path);
					if (dir.Any())
					{
						FileInfo mostRecent = dir.OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
						Report.Success("File with name: " + mostRecent + " was found in the download directory");
						Report.Info("Closing the Report Download popup");
						Report.IsTrue(selReportDownload.ClickClose(),
							"Failed to close the Report Download popup",
							"Successfully closed the Report Download popup");
						Context.AddToContext(savedAs, downloadsFolder + @"\" + mostRecent);
						return;
					}
					count++;
				}
				Report.Failure("Unable to find correct excel file in the download directory after 120 seconds");
				Report.Info("Closing the Report Download popup");
				Report.IsTrue(selReportDownload.ClickClose(),
					"Failed to close the Report Download popup",
					"Successfully closed the Report Download popup");
			}
		}

		[StepDefinition(@"I save the messages in Message Center as (.*)")]
		public void SaveListOfMessages(string savedAs)
		{
			List<MessageCenter.Message> myMessages = new MessageCenter().MessageItems();
			Report.Info("Saving " + myMessages.Count + " messages as: " + savedAs);
			Context.AddToContext(savedAs, myMessages);
		}

		[StepDefinition(@"I confirm that additional messages were displayed since they were saved as (.*)")]
		public void ConfirmAdditionalMessagesWereDisplayed(string savedAs)
		{
			var oldMessages = (List<MessageCenter.Message>)Context.GetFromContext(savedAs);
			if (oldMessages.IsNullOrEmpty())
			{
				Report.Failure("Could not find messages in context saved as: " + savedAs);
				Report.Screenshot();
				return;
			}
			List<MessageCenter.Message> newMessages = new MessageCenter().MessageItems();
			Report.IsTrue(newMessages.Count > oldMessages.Count,
				"The message count did not increase compared to messages saved to context as: " + savedAs + "! Message count is: " + newMessages.Count,
				"The message count increased compared to messages saved to context as: " + savedAs + " as expected. Previous count was: " + oldMessages.Count + ". New count is: " + newMessages.Count);
		}

		[StepDefinition(@"I confirm that the text: (.*) is (displayed|displayed exclusively|not displayed) under the (.*) column for file saved as (.*)")]
		public void StatusColumnDisplaysTextActive(string value, string displayCondition, string column, string savedAs)
		{
			object file = Context.GetFromContext(savedAs);
			if (Report.IsTrue(file != null, "No matching file was found saved as: " + savedAs, "Found file saved as: " + savedAs))
			{
				var ExcelUtils = new ExcelUtilities(file.ToString(), "Messages");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));
				int columnIndex = ColumnTitles.FindIndex(x => x == column);
				List<string> rows = ExcelUtils.Excel_GetColumn(columnIndex);
				if (rows.Count == 0)
				{
					Report.Failure("There were no rows to check in the downloaded file");
					return;
				}
				rows.RemoveAt(0);
				if (displayCondition == "displayed")
				{
					Report.IsTrue(rows.Any(x => x == value),
						"The text: " + value + " was not displayed under the " + column + " column!",
						"The text: " + value + " was displayed under the " + column + " column as expected");
				}
				if (displayCondition == "displayed exclusively")
				{
					Report.IsTrue(rows.All(x => x == value),
						"The text: " + value + " was not the only value displayed under the " + column + " column!",
						"The text: " + value + " was the only value displayed under the " + column + " column as expected");
				}
				if (displayCondition == "not displayed")
				{
					Report.IsTrue(rows.All(x => x != value),
						"The text: " + value + " was displayed under the " + column + " column when it was not expected to!",
						"The text: " + value + " was not displayed under the " + column + " column as expected");
				}
			}
		}

		[StepDefinition(@"I confirm the number of rows in the file saved as (.*) matches the number of messages in My Messages saved as (.*)")]
		public void ExportMessagesCountMatchesInboxCount(string fileSavedAs, string messagesSavedAs)
		{
			object file = Context.GetFromContext(fileSavedAs);
			if (Report.IsTrue(file != null, "No matching file was found saved as: " + fileSavedAs, "Found file saved as: " + fileSavedAs, false, false))
			{
				var myMessages = (List<MessageCenter.Message>)Context.GetFromContext(messagesSavedAs);
				if (Report.IsTrue(myMessages != null, "No matching messages saved as: " + messagesSavedAs, "Found message saved as: " + messagesSavedAs, false, false))
				{
					var excelUtils = new ExcelUtilities(file.ToString(), "Messages");
					int fileRowCount = excelUtils.Excel_GetNoRows() - 1;
					int messageCount = myMessages.Count;
					Report.IsTrue(fileRowCount == messageCount,
						"The report file row count (discounting the header) did not match the Message Center inbox count. File count: " + fileRowCount + " Message inbox count: " + messageCount,
						"The report file row count (discounting the header) matched the Message Center inbox count : " + messageCount);
				}
			}
		}

		[StepDefinition(@"I confirm that the exported excel file saved as: (.*) contains the following columns:")]
		public void ThenIConfirmThatTheExportedExcelFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelUtilities(File.ToString(), "Messages");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));
				foreach (TableRow thisRow in table.Rows)
				{
					Report.IsTrue(ColumnTitles.Contains(thisRow["Column"]),
						"Column name is not found: " + thisRow["Column"],
						"Column name has been found as expected: " + thisRow["Column"], false, false);
				}
			}
		}
	}
}

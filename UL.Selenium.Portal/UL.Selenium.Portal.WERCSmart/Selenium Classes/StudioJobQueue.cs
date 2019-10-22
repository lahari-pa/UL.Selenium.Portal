using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioJobQueue : SeleniumBaseObject
	{
		public const string BasePath = "//iframe[@id='Widget3FRAME']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool WaitForJobInformationList(int secondsToWait)
		{
			Report.Info("Beginning wait for job list");

			//get all iframes, try them on by one for the table
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
			IList<IWebElement> iframes = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//iframe[@id]"), 1);
			var iframeIds = iframes.Select(x => x.GetAttribute("id")).ToList();

			foreach (string iframeId in iframeIds)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
				SeleniumBrowser.WebBrowser.SwitchTo().Frame(iframeId);
				try
				{
					if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//table[@id='jobListGrid-grid']"), 10) != null)
					{
						return true;
					}
				}
				catch (Exception)
				{
					Report.Info(iframeId.ToString() + " is not the right one.");
				}
			}
			return false;
		}

		public List<Job> GetFirstXJobs(int firstX)
		{
			Report.Info("Get first " + firstX.ToString() + " jobs.");
			IList<IWebElement> tableRows = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[@id='jobListGrid-grid']//tr[not(@class='jqgfirstrow')]"), 10);
			Report.Info("Found " + tableRows.Count.ToString() + " rows");
			var listOfJobs = new List<Job>();
			for (int i = 0; i < Math.Min(tableRows.Count, firstX); i++)
			{
				//Report.Info("Adding job: " + i.ToString());
				try
				{
					var myJob = new Job();
					ReadOnlyCollection<IWebElement> rowTDs = tableRows[0].FindElements(By.XPath(".//td"));
					myJob.RecordID = rowTDs[2].GetValue();
					myJob.Class = rowTDs[3].GetValue();
					myJob.Method = rowTDs[4].GetValue();
					myJob.Status = rowTDs[5].GetValue();
					myJob.Frequency = rowTDs[7].GetValue();
					if (rowTDs[8].GetValue().Trim().Length > 0)
					{
						myJob.DateCreated = Convert.ToDateTime(rowTDs[8].GetValue());
					}
					if (rowTDs[9].GetValue().Trim().Length > 0)
					{
						myJob.DateStarted = Convert.ToDateTime(rowTDs[9].GetValue());
					}
					if (rowTDs[10].GetValue().Trim().Length > 0)
					{
						myJob.DateComplete = Convert.ToDateTime(rowTDs[10].GetValue());
					}
					myJob.UserName = rowTDs[11].GetValue();

					listOfJobs.Add(myJob);
				}
				catch (Exception e)
				{
					Report.Info("Failed to add job: " + e.Message);
				}

			}

			return listOfJobs;

		}

		public bool ClickJobQueueMenuItem(string option)
		{
			Report.Info("Beginning click job queue menu option: " + option);
			try
			{
				ReadOnlyCollection<IWebElement> ListJobOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//ul[@id='jobListSelector']/li/span"));

				IWebElement matchingOption = ListJobOptions.FirstOrDefault(x => x.GetValue().Trim() == option);

				if (matchingOption == null)
				{
					Report.Info("No matching menu option has been found: " + option);
				}

				return matchingOption.TryClick();
			}
			catch (Exception)
			{
				return false;
			}

		}
	}

	public class Job
	{
		public string RecordID { get; set; }
		public string Class { get; set; }
		public string Method { get; set; }
		public string Status { get; set; }
		public string Frequency { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateStarted { get; set; }
		public DateTime DateComplete { get; set; }
		public string UserName { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class StudioJobQueue : BaseObject
	{
		public const string BasePath = "//iframe[@id='Widget2FRAME']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WaitForJobInformationList(int secondsToWait)
		{
			Report.Info("Beginning wait for job list");
			if (!SeleniumBrowser.SwitchToIFrame("Widget2FRAME"))
			{
				SeleniumBrowser.ExitIFrame();
				if (!SeleniumBrowser.SwitchToIFrame("Widget2FRAME"))
				{
					Report.Error("Could not switch to iframe");
				}
			}
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//table[@id='jobListGrid-grid']")) != null)
					{
						return true;
					}
				}
				catch (Exception e)
				{
					//do nothing
				}
				Delay.Seconds(1);
				i++;
			}

			return false;
		}

		public List<Job> GetFirstXJobs(int firstX)
		{
			var tableRows = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[@id='jobListGrid-grid']//tr[not(@class='jqgfirstrow')]"));
			List<Job> listOfJobs = new List<Job>();
			for (int i = 0; i < Math.Min(tableRows.Count, firstX); i++)
			{
				Job myJob = new Job();
				var rowTDs = tableRows[0].FindElements(By.XPath(".//td"));
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

			return listOfJobs;

		}

		public bool ClickJobQueueMenuItem(string option)
		{
			var ListJobOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//ul[@id='jobListSelector']/li/span"));

			var matchingOption = ListJobOptions.FirstOrDefault(x => x.GetValue().Trim() == option);

			if (matchingOption == null)
			{
				Report.Info("No matching menu option has been found: " + option);
			}

			return matchingOption.TryClick();
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

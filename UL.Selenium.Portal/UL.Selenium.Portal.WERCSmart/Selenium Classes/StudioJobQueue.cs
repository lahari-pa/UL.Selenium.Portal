using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioJobQueue : SeleniumBaseObject
	{
		public const string BasePath = "//iframe[@id='Widget3FRAME']";

		protected override By ContainerElementLocator => By.XPath(BasePath);
		private IWebElement TopBarMenuButton(string button) => SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($".//div[@class='ui-jqgrid-view']//div[@title = '{button}']"));
		public bool TopBarMenuButtonExists(string button)
		{
			Report.Info($"Attempt to find button {button}");
			return this.TopBarMenuButton(button) != null;
		}
		public bool ClickTopBarMenuBotton(string button)
		{
			return this.TopBarMenuButton(button).TryClick();
		}

		public bool WaitForJobInformationList(int secondsToWait)
		{
			Report.Info("Beginning wait for job list");

			//get all iframes, try them on by one for the table
			SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
			IList<IWebElement> iframes = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//iframe[@id]"), 1);
			var iframeIds = iframes.Select(x => x.GetAttribute("id")).ToList();

			foreach (string iframeId in iframeIds)
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
				SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(iframeId);
				try
				{
					if (SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//table[@id='jobListGrid-grid']"), 10) != null)
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
			IList<IWebElement> tableRows = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//table[@id='jobListGrid-grid']//tr[not(@class='jqgfirstrow')]"), 10);
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
				ReadOnlyCollection<IWebElement> ListJobOptions = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//ul[@id='jobListSelector']/li/span"));

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

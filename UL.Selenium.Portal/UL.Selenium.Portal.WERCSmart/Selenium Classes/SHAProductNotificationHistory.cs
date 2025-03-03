using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ProductNotificationHistory : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='dialog-MessageCenter']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement popupEditor = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;

		}

		//Close, Export
		public bool ClickButton(string button)
		{
			IList<IWebElement> varButtons = this.containerElement.FindElements(By.XPath("..//button/span"), 2);
			IWebElement matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		public List<string> GetHeaders()
		{
			//Report.Info("Beginning get headers");
			return SeleniumWebDriver.CurrentDriver
				.FindElements(By.XPath("//div[@id='dialog-MessageCenter']//table//th"), 2).ToList()
				.Select(x => x.GetValue()).ToList();

		}

		public bool SelectItem(string columnHeader, string value)
		{
			Report.Info("Selecting item: " + value + " in column: " + columnHeader);
			List<string> rawHeaders = this.GetHeaders();
			var headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
			int indexOfHeader = 0;
			for (int i = 0; i < headers.Count; i++)
			{
				if (headers[i] == columnHeader)
				{
					indexOfHeader = i + 1;
					break;
				}
			}

			var listOfColumnItems = this.containerElement
				.FindElements(By.XPath(".//table[@id='listProdRecertHistory']//tr/td[" + indexOfHeader + "]"), 2)
				.ToList();

			var sValues = listOfColumnItems.Select(x => x.GetValue().Trim()).ToList();
			IWebElement matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

			if (matchingItem == null)
			{
				Report.Info("Could not find matching item");
				return false;
			}
			else
			{
				Report.Info("Trying to select");
				listOfColumnItems = this.containerElement
					.FindElements(By.XPath(".//tbody[@id='sortable-list2']/tr/td[" + indexOfHeader + "]"), 2).ToList();

				matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

				Delay.Seconds(1);
				matchingItem.TryClick();
				Delay.Seconds(2);

			}

			return true;
		}

		public List<Notification> GetNotifications()
		{
			List<string> rawHeaders = this.GetHeaders();
			var headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
			int indexOfSupplierName = 0;
			int indexOfType = 0;
			int indexOfSubtype = 0;
			int indexOfActive = 0;
			int indexOfActionBy = 0;
			int indexOfNotificationDate = 0;
			int indexOfSubject = 0;

			for (int i = 0; i < headers.Count; i++)
			{
				if (headers[i] == "Supplier Name")
				{
					indexOfSupplierName = i + 1;
				}

				if (headers[i] == "Type")
				{
					indexOfType = i + 1;
				}

				if (headers[i] == "Subtype")
				{
					indexOfSubtype = i + 1;
				}

				if (headers[i] == "Active")
				{
					indexOfActive = i + 1;
				}

				if (headers[i] == "Action By")
				{
					indexOfActionBy = i + 1;
				}
				if (headers[i] == "Notification Date")
				{
					indexOfNotificationDate = i + 1;
				}
				if (headers[i] == "Subject")
				{
					indexOfSubject = i + 1;
				}
			}


			IList<IWebElement> selectedRows = this.containerElement.FindElements(By.XPath(".//table[@id='tblViewNotificationHistory']//tr"), 2);
			var listOfNotifications = new List<Notification>();
			if (selectedRows == null)
			{
				Report.Info("No rows are showing");
				return listOfNotifications;
			}

			foreach (IWebElement thisRow in selectedRows)
			{
				var thisNotification = new Notification {
					SupplierName = thisRow.FindElement(By.XPath(".//td[" + indexOfSupplierName + "]"), 2).GetValue().Trim(),
					Type = thisRow.FindElement(By.XPath(".//td[" + indexOfType + "]"), 2).GetValue().Trim(),
					SubType = thisRow.FindElement(By.XPath(".//td[" + indexOfSubtype + "]"), 2).GetValue().Trim(),
					Active = thisRow.FindElement(By.XPath(".//td[" + indexOfActive + "]"), 2).GetValue().Trim(),
					ActionBy = thisRow.FindElement(By.XPath(".//td[" + indexOfActionBy + "]"), 2).GetValue().Trim()
				};
				string rD = thisRow.FindElement(By.XPath(".//td[" + indexOfNotificationDate + "]"), 2).GetValue().Trim();
				if (rD.Trim().Length > 0)
				{
					thisNotification.NotificationDate = Convert.ToDateTime(rD);
				}

				thisNotification.Subject =
					thisRow.FindElement(By.XPath(".//td[" + indexOfSubject + "]"), 2).GetValue();
				listOfNotifications.Add(thisNotification);
			}

			return listOfNotifications;
		}

		public bool WaitForTableContentToLoad()
		{
			int x = 0;
			while (x < 20)
			{
				IWebElement tableEl = this.containerElement.FindElement(By.XPath($".//div[@class='ui-jqgrid-bdiv']"), 2);
				if (tableEl != null)
				{
					Report.Info($"The Table was loaded");
					return true;
				}
				x++;
				Delay.Seconds(3);
			}
			Report.Info($"The table did not load after 60 seconds");
			return false;

		}


		public bool ClickTopItem()
		{
			IList<IWebElement> selectedRows = this.containerElement.FindElements(By.XPath(".//table[@id='tblViewNotificationHistory']//tr"), 2);
			if (selectedRows.Count == 0)
			{
				Report.Info("No items have been found to click");
				return false;
			}

			return selectedRows[1].TryClick();
		}

		public bool OrderNotificationsByDate(string ascendingOrDescending)
		{
			IWebElement notificationSortDateHeader = SeleniumWebDriver.CurrentDriver
				.FindElement(
					By.XPath(
						"//div[@id='dialog-MessageCenter']//table//th[@id='tblViewNotificationHistory_NotificationDate']//span[@class='s-ico']/span[not(contains(@class, 'disabled'))]"),
					2);
			string currentSort = notificationSortDateHeader.GetAttribute("sort");

			if (ascendingOrDescending == "asc")
			{
				if (currentSort == "asc")
				{
					Report.Info("Notifications are already sorted ascendingly");
					return true;
				}
				else
				{
					return notificationSortDateHeader.FindElement(By.XPath("./.."), 2).TryClick();
				}
			}
			else
			{
				if (currentSort == "desc")
				{
					Report.Info("Notifications are already sorted descendingly");
					return true;
				}
				else
				{
					return notificationSortDateHeader.FindElement(By.XPath("./.."), 2).TryClick();
				}
			}

		}

		public bool WaitForNotificationDetails(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IList<IWebElement> notificationDetailDiv = this.containerElement.FindElements(By.XPath(".//div[@id='divViewProductMessageDetails']"), 2);
				if (notificationDetailDiv != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}
		public Notification GetNotificationDetails()
		{
			if (!this.WaitForNotificationDetails(60))
			{
				Report.Error("Notification details screen is not showing");
				return null;
			}
			IList<IWebElement> notificationDetailsTableRows = this.containerElement.FindElements(By.XPath(".//div[@id='divViewProductMessageDetails']//table//tr"), 2);

			var thisNotification = new Notification();
			thisNotification.ProductID = notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Product ID"))
				.FindElement(By.XPath("./td[2]")).GetValue();
			thisNotification.ProductName = notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Product Name"))
				.FindElement(By.XPath("./td[2]")).GetValue();
			thisNotification.SupplierName = notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Supplier"))
				.FindElement(By.XPath("./td[2]")).GetValue();
			thisNotification.Type = notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Type"))
				.FindElement(By.XPath("./td[2]")).GetValue();
			thisNotification.NotificationDate = Convert.ToDateTime(notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Notification Date"))
				.FindElement(By.XPath("./td[2]")).GetValue());
			thisNotification.Subject = notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Subject"))
				.FindElement(By.XPath("./td[2]")).GetValue();
			thisNotification.Message = notificationDetailsTableRows
				.FirstOrDefault(x => x.FindElement(By.XPath("./td[1]")).GetValue().Contains("Message"))
				.FindElement(By.XPath("./td[2]/textarea")).GetValue();
			return thisNotification;
		}

		public bool ClickButtonInNotificationDetails(string button)
		{
			IList<IWebElement> varButtons = this.containerElement.FindElements(By.XPath(".//div[@id='divViewProductMessageDetails']/../..//button/span"), 2);
			IWebElement matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}
	}

	class Notification
	{
		public string ProductID { get; set; }

		public string ProductName { get; set; }
		public string SupplierName { get; set; }
		public string Type { get; set; }
		public string SubType { get; set; }
		public string Active { get; set; }
		public string ActionBy { get; set; }
		public DateTime NotificationDate { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}

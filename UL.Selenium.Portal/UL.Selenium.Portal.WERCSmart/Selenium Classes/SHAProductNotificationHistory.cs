using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ProductNotificationHistory : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-MessageCenter']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var popupEditor = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
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
			var varButtons = this.containerElement.FindElements(By.XPath("..//button/span"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
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
			return SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//div[@id='dialog-MessageCenter']//table//th"), 2).ToList()
				.Select(x => x.GetValue()).ToList();

		}

		public bool SelectItem(string columnHeader, string value)
		{
			Report.Info("Selecting item: " + value + " in column: " + columnHeader);
			List<string> rawHeaders = this.GetHeaders();
			List<string> headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
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
			var matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

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
			List<string> headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
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

			var selectedRows = this.containerElement.FindElements(By.XPath(".//table[@id='tblViewNotificationHistory']//tr"), 2);
			List<Notification> listOfNotifications = new List<Notification>();
			if (selectedRows == null)
			{
				Report.Info("No rows are showing");
				return listOfNotifications;
			}

			foreach (var thisRow in selectedRows)
			{
				Notification thisNotification = new Notification();
				thisNotification.SupplierName = thisRow.FindElement(By.XPath(".//td[" + indexOfSupplierName + "]"), 2).GetValue().Trim();
				thisNotification.Type = thisRow.FindElement(By.XPath(".//td[" + indexOfType + "]"), 2).GetValue().Trim();
				thisNotification.SubType = thisRow.FindElement(By.XPath(".//td[" + indexOfSubtype + "]"), 2).GetValue().Trim();
				thisNotification.Active = thisRow.FindElement(By.XPath(".//td[" + indexOfActive + "]"), 2).GetValue().Trim();
				thisNotification.ActionBy = thisRow.FindElement(By.XPath(".//td[" + indexOfActionBy + "]"), 2).GetValue().Trim();
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

		public bool ClickTopItem()
		{
			var selectedRows = this.containerElement.FindElements(By.XPath(".//table[@id='tblViewNotificationHistory']//tr"), 2);
			if (selectedRows.Count == 0)
			{
				Report.Info("No items have been found to click");
				return false;
			}

			return selectedRows[1].TryClick();
		}

		public bool OrderNotificationsByDate(string ascendingOrDescending)
		{
			var notificationSortDateHeader = SeleniumBrowser.WebBrowser
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
				var notificationDetailDiv = this.containerElement.FindElements(By.XPath(".//div[@id='divViewProductMessageDetails']"), 2);
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
			var notificationDetailsTableRows = this.containerElement.FindElements(By.XPath(".//div[@id='divViewProductMessageDetails']//table//tr"), 2);

			Notification thisNotification = new Notification();
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
			var varButtons = this.containerElement.FindElements(By.XPath(".//div[@id='divViewProductMessageDetails']/../..//button/span"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == button.ToLower());
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

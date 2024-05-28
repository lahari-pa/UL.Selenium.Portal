using System.Collections.Generic;
using System.IO;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.ReqnrollHelpers.Classes;
using System.Collections.ObjectModel;
using System;
using System.Net;
using UL.Selenium.Portal.WERCSmart.Helpers;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SHADocumentList : SeleniumBaseObject
	{
		public const string BasePath = "//span[@id='ui-dialog-title-dialog-documentmanagement']/../..";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement popupEditor = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;

		}

		public List<string> GetPDFNames()
		{
			ReadOnlyCollection<IWebElement> ListOfFilenameTDs = this.containerElement.FindElements(By.XPath(".//table[@id='listdocuments']/tbody/tr[not(@class='jqgfirstrow')]/td[1]"));

			return ListOfFilenameTDs.Select(x => x.GetValue()).ToList();
		}

		public bool DoubleClickPDF(string pdfName)
		{
			ReadOnlyCollection<IWebElement> ListOfFilenameTDs = this.containerElement.FindElements(By.XPath(".//table[@id='listdocuments']/tbody/tr[not(@class='jqgfirstrow')]/td[1]"));
			IWebElement matchingTD = ListOfFilenameTDs.FirstOrDefault(x => x.GetValue().Contains(pdfName));
			

			if (matchingTD != null)
			{
				matchingTD.TryDoubleClick();
				Report.Info($"attempting back up double click");
				Actions actions = new Actions(SeleniumBrowser.WebBrowser);
				actions.MoveToElement(matchingTD);
				Delay.Seconds(2);
				actions.MoveByOffset(0, -60);
				//actions.ContextClick();
				actions.DoubleClick();
				actions.Perform();

				return true;


				//return matchingTD.TryDoubleClick();
			}

			return false;
		}

		public bool ClickButton(string buttonName)
		{
			ReadOnlyCollection<IWebElement> listOfButtons =
				this.containerElement.FindElements(By.XPath(".//button|.//input[@type='submit' or @type='button']"));

			IWebElement matchingButton = listOfButtons.FirstOrDefault(x => x.GetValue() == buttonName);

			if (matchingButton == null)
			{
				Report.Info("Could not find a matching button to click");
				return false;
			}

			return matchingButton.TryClick();
		}

		public string DocumentWindowOpen()
		{
			Report.Info("Switch to SHA Document window");
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url.Contains("GetDocument"))
				{
					Report.Info("Found the URL Containing 'GetDocument'");
					return SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url;
				}
			}
			return null;
		}

		public string TemporaryPDFWindowOpen()
		{
			Report.Info("Switch to SHA Document Temp PDF window");
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in handles)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url.Contains("GetDocument"))
				{
					Report.Info("Found the URL Containing 'GetDocument'");
					return SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url;
				}
			}
			return null;
		}
	}
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SHADocumentList : BaseObject
	{
		public const string BasePath = "//span[@id='ui-dialog-title-dialog-documentmanagement']/../..";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

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
				return matchingTD.TryDoubleClick();
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
					return SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Url;
				}
			}
			return null;
		}

		public string DocumentText(string address)
		{
			var reader = new PdfReader(address);
			var output = new StringWriter();
			for (int i = 1; i <= reader.NumberOfPages; i++)
			{
				output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));
			}
			return output.ToString();
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using GeneralUtilities = UL.Selenium.Portal.RPS.Classes.GeneralUtilities;
using UL.Automation.ReqnrollHelpers.Classes;


namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
	public class StudioTopMenu : BaseObject
	{
		public const string BasePath = "//div[@id='navmenu']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			//get the window
			StudioUtilites.SwitchToWindow("Wercs Studio");
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}


		//My Wercs, UL Secure Connect, Authoring, Management, Distribution, System, Window, Help
		public bool ClickTopMenuItem(string item)
		{
			IWebElement navBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='navmenu']"));
			navBar.ScrollElementIntoView();
			ReadOnlyCollection<IWebElement> ListOfOptions = this.containerElement.FindElements(By.XPath(".//li//a"));
			return ListOfOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == item.Trim().ToLower()).TryClick();

		}

		public bool ClickSubMenu(string menuItem, string submenuItem)
		{

			IWebElement navBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='navmenu']"));
			navBar.ScrollElementIntoView();
			ReadOnlyCollection<IWebElement> ListOfOptions = this.containerElement.FindElements(By.XPath(".//li//a"));
			IWebElement topMenuItem = ListOfOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == menuItem.Trim().ToLower());
			if (topMenuItem.TryClick())
			{
				ReadOnlyCollection<IWebElement> ListOfSubMenuOptions = topMenuItem.FindElements(By.XPath(".//following-sibling::ul/li/a"));
				return ListOfSubMenuOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == submenuItem.Trim().ToLower()).TryClick();
			}
			return false;
		}

	}
	public class StudioPowerDesignerPlus : WidgetPage
	{

		public bool InTheStudioClickDocumentIcon()
		{
			IWebElement DocumentIcon = FindElement(By.XPath("//*[@id='cmdPublish']/i[@class ='icon-publish']"), 1);
			return DocumentIcon.TryClick();
		}

		public string GetProductID()
		{
			IWebElement productCode = this.FindElement(By.XPath("//input[contains(@id,'ucSelectProdselectProdTB')]"), 1);
			string code = productCode.GetAttribute("value");
			return code;
		}

		public bool InTheStudioClickRelatedDocumentIcon()
		{
			IWebElement DocumentIcon = FindElement(By.XPath("//*[@id='ucSelectProdimgRelatedDocument']"), 1);
			if(DocumentIcon == null)
{
				return false;
			}
			return DocumentIcon.TryClick();
		}

	}

	public class StudioDocuments : WidgetPage
	{
		public const string BasePath = "//iframe[contains(@id, 'modalDialogFrame')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{
			
			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Current Document"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Current Document");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
		    IWebElement containerElement =  SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info(" Pop up is displayed");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool InTheStudioClickListOfPublishedDocumentIcon()
		{
			IWebElement PublishDocumentIcon = FindElement(By.XPath("//*[@id='btnListPub']"), 1);
			return PublishDocumentIcon.TryClick();
		}

		public bool CurrentDocumentPopupIsDisplayed()
		{
			IWebElement CurrentDocumentPopUp = FindElement(By.XPath("//iframe[contains(@id, 'modalDialogFrame')]"), 1);
			return CurrentDocumentPopUp.Displayed;
		}

		public string TakeNoteOfProductCode(string savedAs)
		{
			IWebElement productCode = this.FindElement(By.XPath("//input[contains(@name,'ucSelProduct$txtProduct')]"), 1);
			string code = productCode.GetAttribute("value");
			return code;
		}

		public string TakeNoteOfFileName(string savedAs)
		{
			IWebElement fileName = this.FindElement(By.XPath(".//tr[contains(@role,'row')]//td[contains(@aria-describedby,'listdocuments_FileName')]"), 1);
			return fileName.Text;
		}

		public bool Click3DotsNextToSerachIcon()
		{
			IWebElement ThreeDotsNextToSerachIcon = FindElement(By.XPath(".//*[@id='ucSelectProdselProd']"), 1);
			return ThreeDotsNextToSerachIcon.TryClick();
		}


	}

	public class PublishedDocuments : WidgetPage
	{
		public const string BasePath = "//iframe[contains(@src, 'ListPublished')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Published Documents"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Published Documents");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed successfully");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}


		public bool PublishedDocumentsPopUpIsDisplayed()
		{

			IWebElement PublishedDocumentPopUp = FindElement(By.XPath("//iframe[contains(@src, 'ListPublished')]"), 1);
			return PublishedDocumentPopUp.Displayed;
		}

		public bool ClickOnNGHSEntry()
		{
			IWebElement NGHSRowEntry = FindElement(By.XPath("//tr[contains(@id,'PublishedDocsGrid_row')]//td[contains(text(),'NGHS')]"), 1);
			return NGHSRowEntry.TryDoubleClick();
		}


		public bool ClickOnHGHSENEntry()
		{
			IWebElement HGHSENRowEntry = FindElement(By.XPath("//div[contains(@id,'PublishedDocsGrid_divSR')]//table//tr[contains(@srdata,'HGHS') and contains(@srdata,'EN') ]"), 1);
			return HGHSENRowEntry.TryDoubleClick();
		}

		public bool ClickOnHGHSCFEntry()
		{
			IWebElement HGHSCFRowEntry = FindElement(By.XPath("//div[contains(@id,'PublishedDocsGrid_divSR')]//table//tr[contains(@srdata,'HGHS') and contains(@srdata,'CF') ]"), 1);
			return HGHSCFRowEntry.TryDoubleClick();
		}

		public bool ClickOnSBCSEntry()
		{
			IWebElement NGHSRowEntry = FindElement(By.XPath("//tr[contains(@id,'PublishedDocsGrid_row')]//td[contains(text(),'SBCS')]"), 1);
			return NGHSRowEntry.TryDoubleClick();
		}

		public bool ClickOnPrimary1Source0Entry()
		{
			IWebElement Primary1Source0RowEntry = FindElement(By.XPath(".//tr[contains(@role,'row')]//td[contains(@aria-describedby,'Primary')][contains(text(),'1')]"), 1);
			return Primary1Source0RowEntry.TryDoubleClick();
		}

		public bool SelectPrimary1Source0Entry()
		{
			IWebElement Primary1Source0RowEntry = FindElement(By.XPath(".//tr[contains(@role,'row')]//td[contains(@aria-describedby,'Primary')][contains(text(),'1')]"), 1);
			return Primary1Source0RowEntry.TryClick();
		}

		public bool SelectFileNameWithWPSID(string wpsid)
		{
			IList<IWebElement> ListOfOptions = FindElements(By.XPath("//table[@id='listdocuments']//tr//td[1]"),1);
			IWebElement FileName = ListOfOptions.FirstOrDefault(x => x.Text.Contains(wpsid));
			return FileName.TryDoubleClick();
		}



	}

	public class NGHSDocument : WidgetPage
	{
		public const string BasePath = "//embed[contains(@original-url,'NGHS')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("viewPublishedDoc"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: viewPublishedDoc");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed successfully");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool NGHSDocumentIsDisplayed()
		{

			IWebElement NGHSDocument = FindElement(By.XPath("//embed[contains(@original-url,'NGHS')]"), 1);
			return NGHSDocument.Displayed;
		}

		public string GetPdfText()
        {
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL == null)
			{
				return null;
				
			}
            else
            {
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				return newTextFromPDF;
			}
			

		}

		public bool DocumentIsDisplayed()
		{

			IWebElement Document = FindElement(By.XPath("//embed[contains(@type,'pdf')]"), 1);
			return Document.Displayed;
		}

		public bool Wait_for_document_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("GetDocument"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: GetDocument");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

	}

	public class SelectProduct : WidgetPage
	{
		public const string BasePath = ".//iframe[contains(@src, 'SelectProductPage')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Select product"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Select product");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is  displayed successfully");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool SelectProductPopupIsDisplayed()
		{
			IWebElement CurrentDocumentPopUp = FindElement(By.XPath(".//iframe[contains(@src, 'SelectProductPage')]"), 1);
			return CurrentDocumentPopUp.Displayed;
		}

		public bool SelectProductPopupIsNotDisplayed()
		{
			IWebElement CurrentDocumentPopUp = FindElement(By.XPath(".//iframe[contains(@src, 'SelectProductPage')]"), 1);
			if(CurrentDocumentPopUp.Displayed)
            {
				Report.Info("Product Pop up is displayed");
				return false;
            }
			Report.Info("Product Pop up is not displayed");
			return true;
		}

		public bool VerifyEntryForEachProduct(string productID)
		{
			IList<IWebElement> rows = FindElements(By.XPath(".//tr[contains(@id,'srAliases')][contains(@srdata,'Test Case')]//td[2]"), 1);

			int i = 11;
			foreach (var item in rows)
			{
				string ProductID = item.Text;
				Report.Info("Each row displays entry for the product",ProductID == productID);
			}
			return true;
		}

		public string TakeNoteOfAliasPrroductID(string savedAs, string retailer)
		{
			IList<IWebElement> rows = FindElements(By.XPath(".//tr[contains(@id,'srAliases')][contains(@srdata,'Test Case')]//td[3]"), 2);
			retailer = retailer.Substring(4);
			List<string> productids = new List<string>();
			foreach (var item in rows)
			{
				string ProductID = item.Text;
				if (ProductID.Contains(retailer))

				{
					string id = item.Text;
					productids.Add(id);
				}
			}

			return productids.ToString();

		}

		public string SelectProductRelatedToRetailer(string productID)
		{
			IWebElement AliasProduct = this.FindElement(By.XPath(".//tr[contains(@id,'srAliases')][contains(@srdata,'Test Case')]//td[3]"), 2);
			return AliasProduct.Text;
		}

		public void SelectAliasId(string retailer)
		{
			IList<IWebElement> rows = FindElements(By.XPath(".//tr[contains(@id,'srAliases')][contains(@srdata,'Test Case')]//td[3]"), 2);
			retailer = retailer.Substring(4);
			foreach (var item in rows)
			{
				string ProductID = item.Text;
				if (ProductID.Contains(retailer))

				{
				   item.TryClick();
				}
				else
                {
					Report.Info("Product id not found for the retailer");
				}
			}


		}


	}

	public class SummarySheetDocument : WidgetPage
	{
		public const string BasePath = "//embed[contains(@type,'pdf')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("viewPublishedDoc"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: viewPublishedDoc");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed successfully");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool SummarySheetDocumentIsDisplayed()
		{

			IWebElement NGHSDocument = FindElement(By.XPath("//embed[contains(@type,'pdf')]"), 1);
			return NGHSDocument.Displayed;
		}

		public string GetPdfText()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL == null)
			{
				return null;

			}
			else
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				return newTextFromPDF;
			}


		}


		public bool Wait_for_document_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("GetDocument"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: GetDocument");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

	}

	public class ReportWriter : WidgetPage
	{
		public bool WaitUntilTableIsLoaded(int waitForSeconds = 30)
		{

			int i = 0;
			IWebElement ReportWriterTable = FindElement(By.XPath("//*[@id='tblPages']"), 1);
			while (i < waitForSeconds)
			{
				if (ReportWriterTable.Displayed)
				{
					Report.Info("The Report Writer table is displayed");
					return true;
				}
				i++;
				Delay.Seconds(1);
			}
			Report.Info($"The Report Writer table did not display after: {i} seconds");
			return false;

		}

		public bool ClickSqlTab()
		{

			IWebElement SqlTab = FindElement(By.XPath("//*[@id='celProgPage_SQL']//tbody//td[contains(@style,'cursor:pointer')]"), 1);
			return SqlTab.TryClick();
		}

		public void EnterSqlStatement(string value)
		{
			IWebElement SqlStatementTextBox = FindElement(By.XPath("//div[@class='toolbox']//tbody//td//span[@title='Execute']"), 2);
			SqlStatementTextBox.ClearTextBox();
			SqlStatementTextBox.EnterText(value);
			SqlStatementTextBox.SendKeys(Keys.Enter);
		}

		public bool ClickExecute()
		{

			IWebElement ExecuteButton = FindElement(By.XPath("//div[@class='toolbox']//tbody//td//span[@title='Execute']"), 1);
			return ExecuteButton.TryClick();
		}

		public bool WaitUntilResultTableIsLoaded(int waitForSeconds = 10)
		{

			int i = 0;
			IWebElement ReportWriterTable = FindElement(By.XPath("//*[@id='gridResults_grdSR']"), 1);
			while (i < waitForSeconds)
			{
				if (ReportWriterTable.Displayed)
				{
					Report.Info("The Result table is displayed");
					return true;
				}
				i++;
				Delay.Seconds(1);
			}
			Report.Info($"The Result table did not display after: {i} seconds");
			return false;

		}

		public string TakeNoteOfFileName(string savedAs)
		{
			IWebElement fileName = this.FindElement(By.XPath("//*[@id='gridResults_row0']/td[5]"), 1);
			return fileName.Text;
		}

		public bool CloseReportWriterTab()
		{

			IWebElement CloseReportWriterButton = FindElement(By.XPath("//div[contains(@class,'ui-dialog-titlebar')]//button[contains(@class,'ui-dialog-titlebar-close')]"), 1);
			return CloseReportWriterButton.TryClick();
		}


	}

	public class RelatedDocuments : WidgetPage
	{
		public const string BasePath = "//iframe[contains(@id, 'modalDialogFrame')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Related Document"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Related Document");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info(" Pop up is displayed");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool RelatedDocumentsIsDisplayed()
		{

			IWebElement RelatedDocument = FindElement(By.XPath(".//*[@id='RelatedDocuments_grdSR']"), 1);
			return RelatedDocument.Displayed;
		}

		public bool FileNameNotedEarlierIsDisplayed(string savedAs)
		{
			var reportWriter = new ReportWriter();
			string fileName = reportWriter.TakeNoteOfFileName(savedAs);
			var savedFileName = Context.GetFromContext(savedAs).ToString();
			IList<IWebElement> rows = FindElements(By.XPath("//div[@id='RelatedDocuments_divSRData']//table//tr//td[8]"), 1);
			foreach (var item in rows)
			{
				string fileNameinRelatedDocuments = item.Text;
				if(fileNameinRelatedDocuments == savedFileName)
					Report.Info("File Name is displayed as noted earlier");
			}
			return true;

		}

		public bool ClickFileNameNotedEarlier(string savedAs)
		{
			var reportWriter = new ReportWriter();
			string fileName = reportWriter.TakeNoteOfFileName(savedAs);
			var savedFileName = Context.GetFromContext(savedAs).ToString();
			IList<IWebElement> rows = FindElements(By.XPath("//div[@id='RelatedDocuments_divSRData']//table//tr//td[8]"), 1);
			foreach (var item in rows)
			{
				string fileNameinRelatedDocuments = item.Text;
				if (fileNameinRelatedDocuments == savedFileName)
					return item.TryDoubleClick();
			}
			Report.Info("Failed to click File Name");
			return false;

		}

		public bool DocumentIsDisplayed()
		{

			IWebElement Document = FindElement(By.XPath("//embed[contains(@type,'pdf')]"), 1);
			return Document.Displayed;
		}

		public bool Wait_for_document_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("ViewRelatedDocument"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: ViewRelatedDocument");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool UserUpdatedSHAMANAGERIsDisplayed()
		{

			IWebElement UserUpdated = FindElement(By.XPath(".//*[contains(@id,'RelatedDocuments_row')]//td[10]"), 1);
		    if (UserUpdated.Text == "SHAMANAGER")
				return UserUpdated.TryClick();
			Report.Info("User Updated: Shamanager is not displayed");
			return false;
		}

		public string MakeANoteOfFileNameWithUserTypeSHAMANAGER(string savedAs)
		{

			IWebElement FileNameWithUserTypeSHAMANAGER = FindElement(By.XPath(".//*[contains(@class,'SelectedItem')]//td[3]"), 1);
			string fileName = FileNameWithUserTypeSHAMANAGER.Text;
			return fileName;
		}

		public bool DoubleClickEntryForUserTypeSHAMANAGER()
		{

			IWebElement UserUpdated = FindElement(By.XPath(".//*[contains(@id,'RelatedDocuments_row')]//td[10]"), 1);
			if (UserUpdated.Text == "SHAMANAGER")
				return UserUpdated.TryDoubleClick();
			Report.Info("User Updated: Shamanager is not clickable or displayed");
			return false;
		}

		public string GetPdfText()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL == null)
			{
				return null;

			}
			else
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				return newTextFromPDF;
			}


		}




	}


	public class HGHSDocument : WidgetPage
	{
		public const string BasePath = "//embed[contains(@original-url,'HGHS')]";

		public bool Wait_for_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("viewPublishedDoc"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: viewPublishedDoc");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed successfully");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

		public bool HGHSENDocumentIsDisplayed()
		{

			IWebElement NGHSDocument = FindElement(By.XPath("//embed[contains(@original-url,'HGHS&Lang=EN')]"), 1);
			return NGHSDocument.Displayed;
		}

		public bool HGHSCFDocumentIsDisplayed()
		{

			IWebElement NGHSDocument = FindElement(By.XPath("//embed[contains(@original-url,'HGHS&Lang=CF')]"), 1);
			return NGHSDocument.Displayed;
		}

		public string GetPdfText()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL == null)
			{
				return null;

			}
			else
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				return newTextFromPDF;
			}


		}

		public bool DocumentIsDisplayed()
		{

			IWebElement Document = FindElement(By.XPath("//embed[contains(@type,'pdf')]"), 1);
			return Document.Displayed;
		}

		public bool Wait_for_document_load(int secondsToWait = 60)
		{

			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
			bool foundPopup = false;
			foreach (string handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("GetDocument"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: GetDocument");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				Report.Info("Pop up is not displayed");
				return false;
			}

			IWebElement frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//embed"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			IWebElement containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 1);
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				Report.Info("Pop up is displayed");
				return true;
			}
			Report.Info("Page is not displayed");
			return false;
		}

	}

}

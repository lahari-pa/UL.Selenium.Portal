using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class RetailPartners : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='retailPartners']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath("..//h2"), 2).Text;
		}

		public List<string> SubHeadingsShowing()
		{
			return this.containerElement.FindElements(By.XPath(".//h2"), 2).Where(x => x.Displayed).Select(x => x.Text.Trim()).ToList();
		}

		public List<string> ListOfRetailersWithAdditionalADataConsentRequests()
		{
			var AdditionalDataConsentRequests = new List<string>();
			IWebElement MyDataAndRecipients = this.containerElement.FindElements(By.XPath(".//h2"), 2).FirstOrDefault(x => x.Text.Contains("My Data & Recipients"));
			if (MyDataAndRecipients != null)
			{
				AdditionalDataConsentRequests = MyDataAndRecipients.FindElements(By.XPath("../ div[2]//a//span")).Select(x => x.Text).ToList();
			}

			return AdditionalDataConsentRequests;
		}

		public bool RetailerShowingInAdditionalDataConsentRequests(string retailer)
		{
			var AdditionalDataConsentRequests = new List<string>();
			IWebElement MyDataAndRecipients = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//h2"), 2).FirstOrDefault(x => x.Text.Contains("My Data & Recipients"));
			if (MyDataAndRecipients != null)
			{
				AdditionalDataConsentRequests = MyDataAndRecipients.FindElements(By.XPath("../ div[2]//a//span")).Select(x => x.Text).ToList();
				return AdditionalDataConsentRequests.Contains(retailer);
			}

			return false;
		}

		public bool ClickRetailer(string retailer, bool exact = false)
		{
			// Finds all the most recent retail partners
			IList<IWebElement> recentPartners = this.containerElement.FindElements(By.XPath(".//div[@class='most-recent']//span[@class='sr-only']"), 2);
			if (recentPartners.Any(x => x.Text.ToLower().Contains(retailer.ToLower())))
			{
				// Retailer was found in the most recent retailer portion of the screen!
				return recentPartners.FirstOrDefault(x => x.Text.ToLower().Contains(retailer.ToLower())).FindElement(By.XPath("../.."), 2).TryClick();
			}
			// Retailer not found in the most recent retailers portion, so checking the rest of the retailers
			IList<IWebElement> allPartners = this.containerElement.FindElements(By.XPath(".//div[@class='all-retailers']//span[@class='sr-only']"), 2);
			if (allPartners.Any(x => x.Text.ToLower().Contains(retailer.ToLower())))
			{
				// Retailer was found in the most recent retailer portion of the screen!
				return allPartners.FirstOrDefault(x => x.Text.ToLower().Contains(retailer.ToLower())).FindElement(By.XPath("../.."), 2).TryClick();
			}
			// Retailer not found!
			Report.Failure("No matching retailer for: " + retailer + " was found!");
			return false;
		}

		public string WarningMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'alert-warning')]"), 2)?.Text;
		}

		public bool ClickRetailerLogo(string retailerCode)
		{
			return this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col')]//a"), 2).FirstOrDefault(x => x.GetCssValue("background-image").ToLower().Contains(retailerCode.ToLower())).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool NoRetailerTilesAreEmpty()
		{
			return !this.containerElement.FindElements(By.XPath(".//div[@class='all-retailers']//div[starts-with(@class,'col') and not(.//a)]"), 2).Any();
		}

		public List<string> GetAllAvailableRetailers()
		{
			return this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col')]//a"), 2).Select(x => x.GetCssValue("background-image").Replace(@"""", "").Replace("url(", "").Replace(")", "")).ToList();
		}

		public bool TilesAppearBelowHeading(string heading)
		{
			return this.containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col-sm-3') and ../parent::div[@class='" + heading + "']]")).Any();
		}

		public List<string> AllRetailerTilesBelowHeading(string heading)
		{
			return this.containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3') and ../parent::div[@class='" + heading + "']]//span[@class='sr-only']")).Select(x => x.Text).ToList();
		}

		public bool RetailerImageDisplayed(int tile)
		{
			try
			{
				IWebElement el = this.containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3')]/a"), 2).ToList()[tile - 1];
				string backgorundImage = el.GetCssValue("background-image");
				el.ScrollElementIntoView();
				return backgorundImage != "none";
			}
			catch (Exception ex)
			{
				Report.Failure("RetailerImageDisplayed: " + ex.Message);
				return false;
			}
		}

		public bool RetailerTextDisplayed(int tile)
		{
			IWebElement el = this.containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3')]//span[@class='sr-only']"), 2).ToList()[tile - 1];
			if (el == null)
			{
				Report.Failure("Failed to find text element for tile: " + tile);
				return false;
			}
			Report.Info("Text showing for tile " + tile + " is: " + el.Text);
			return el.Displayed;
		}

		public List<string> AllRetailerNames()
		{
			return this.containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3')]//span[@class='sr-only']")).Select(x => x.Text).ToList();
		}

		//Jacob

		public bool FindRadioButton(string shouldOrShouldNot, string radioButtonText)
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@type='radio']//following-sibling::span[contains(text(), \"" + radioButtonText + "\")]"), 2);

			if (shouldOrShouldNot.ToLower() == "should")
			{
				if (el == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else if (shouldOrShouldNot.ToLower() == "should not")
			{
				if (el == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			return false;

		}

		public bool CheckIfAISIsUploaded()
		{
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[contains(text(), 'Article Information Sheet (AIS)')]/..//following-sibling::div//div[@class='dropzone']//strong[contains(text(), 'Drop .pdf file here or click ')]"), 2);
			if (el == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

	}

	class RetailPartnersDetails : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='retailDetails']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool HeaderShowing(string header, bool exact = true)
		{
			IList<IWebElement> headers = this.containerElement.FindElements(By.XPath(".//h3"), 2);
			return headers.Any(x => x.Text.Contains(header));
		}

		public string GetSectionText(string section)
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'panel') and (./preceding-sibling::h3[text()='" + section + "'])]"), 2).Text;
		}

		public string GetDCDescription()
		{
			IWebElement descriptionElement = this.containerElement.FindElement(By.XPath("//div[@class='well']"), 5);
			if (descriptionElement != null)
			{
				string htmlDescription = descriptionElement.GetInnerHTML();
				string regExPattern = @"(?s)\<span.*\>(.+?)\<\/span\>(.+?)\<";

				Match match = Regex.Match(htmlDescription, regExPattern, RegexOptions.IgnoreCase);
				if (match.Success)
				{
					string companyName = match.Groups[1].Value;
					string companyText = match.Groups[2].Value;
					return companyName.Trim() + " " + companyText.Trim();
				}

				return "";
			}

			return "";
		}

		public bool SupplierIDTableShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2) != null;
		}

		public string GetChartLegend()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='chart-legend']"), 2).Text;
		}

		public bool PieChartShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//*[name()='svg']"), 2) != null;
		}

		public string GetPieChartFooterText()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//div[@class='chart-legend']/p"), 2).Text;
		}

		public string ChartRetailerFill()
		{
			IWebElement chart = this.containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//*[name()='svg']"), 2);
			if (chart == null)
			{
				return null;
			}
			IWebElement chartSector = chart.FindElement(By.XPath(".//*[name()='path' and @class='highcharts-point highcharts-color-0']"), 2);
			if (chartSector == null)
			{
				return null;
			}
			return chartSector.GetAttribute("fill");
		}

		public string ChartCentrePercentage()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//div[@id='total-products']"), 2);
			if (el == null)
			{
				return null;
			}
			return el.Text;
		}

		public string GetAndYouText()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='chart-legend']/../../..//h3"), 2).Text;
		}

		public string GetTierInformation()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'tiersControl.tierInformation')]"), 2).Text;
		}

		public string DoesNotRequireDataConsentInfo()
		{
			return this.containerElement.FindElement(By.XPath(".//div[1]/div[1]/div[2]/div"), 2).Text;

		}

		public void ClickMoreInformation()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.tierMoreInformation')]"), 2).Click();
		}

		public bool MoreInformationShowing()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.tierMoreInformation')]"), 2);
			return el != null && el.Displayed;
		}

		public void ClickProductsInScope()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.getReport')]"), 2).TryClick();
		}

		public bool ClickBackButton()
		{
			return SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath(".//div[@class='header-with-back']//a/i"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool ClickInfoButton(string text)
		{
			return this.InfoButton(text).TryClick();
		}

		public IWebElement InfoButton(string text)
		{
			return this.containerElement.FindElement(By.XPath($@".//a[@class='btn btn-info' and contains(text(),""{text}"")]"), 2);
		}

		public List<string> GetAllDataConsentTiers()
		{
			try
			{
				//return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table//tbody[@data-bind]//tr//td//div[@data-bind='text:Name']"), 2).Select(x => x.Text).ToList().Where(x => x.Length > 0).ToList();
				return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table[not(contains(@style,'display: none'))]//tbody//tr//td//div"), 2).Select(x => x.Text).ToList().Where(x => x.Length > 0).ToList();

			}
			catch (Exception)
			{
				return new List<string>();
			}

		}

		public bool SetDataConsentTier(string tier, bool trueFalse)
		{
			IList<IWebElement> dataConsentRows = this.DataConsentTiersTable()?.FindElements(By.XPath(".//tbody//tr"), 2);
			IWebElement correctRow = dataConsentRows?.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow == null)
			{
				return false;
			}
			IWebElement checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
			bool Checked = checkbox.Selected;
			return Checked == trueFalse || correctRow.FindElement(By.XPath(".//label[@class='switch']"), 2).TryClick() && checkbox.Selected == trueFalse;
		}

		public bool GetDataConsentTier(string tier)
		{
			IList<IWebElement> dataConsentRows = this.DataConsentTiersTable()?.FindElements(By.XPath(".//tbody//tr"), 2);
			IWebElement correctRow = dataConsentRows?.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow == null)
			{
				return false;
			}
			IWebElement checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
			bool Checked = checkbox.Selected;
			return Checked;
		}
		public bool GetDataConsentTierOnofFSwitch(string tier)
		{
			IWebElement onOffSwitch = this.containerElement.FindElement(By.XPath(".//div[contains(text(),'" + tier + "')]/../following-sibling::td//span[@class='slider round']"), 2);
			if (onOffSwitch != null)
			{
				return true;
			}
			return false;
		}


		public bool SaveChangesButtonShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//p/a[contains(@class,'btn')]"), 2).Displayed;
		}

		public bool ClickSaveChanges()
		{
			return this.containerElement.FindElement(By.XPath(".//p/a[contains(@class,'btn') and not(contains(style,'display: none'))]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public string WarningMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'alert-warning') and contains(@data-bind,'additionalInfo')]"), 2)?.Text;
		}

		public List<string> WarningMessages()
		{
			IList<IWebElement> messages = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'alert-warning') and contains(@data-bind,'additionalInfo')]/p"), 2);
			if (messages.Count == 0)
			{
				return new List<string>();
			}
			return messages.Select(x => x.Text.Trim()).ToList();
		}

		

		public string GetSelectedRetailer()
		{
			return this.containerElement.FindElement(By.XPath("//h2[@id='retailerLabel']"), 2)?.Text;
		}

		public List<string> GetButtons(string section)
		{
			return this.containerElement.FindElements(By.XPath(".//div[contains(@class,'panel') and (./preceding-sibling::h3[text()='" + section + "'])]//ul[contains(@class,'list')]//a"), 2).Select(x => x.Text).ToList();
		}

		public List<string> GetSupplierIDTableHeaders()
		{
			return this.containerElement
				.FindElements(
					By.XPath(
						".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table/thead/tr/th"),
					2).Select(x => x.Text).Select(x => x.Trim()).ToList();
		}

		public bool ClickAddSupplierId()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='add-supplier-id']")).TryClick();
		}

		public List<string> WalmartRegistrationsRetailers()
		{
			string xPath = ".//p[contains(text(),'Walmart registrations')]/following-sibling::ul/li";
			return this.containerElement.FindElements(By.XPath(xPath), 2).Select(x => x.Text.Trim()).ToList();
		}

		public IWebElement DataConsentTiersTable()
		{
			return this.containerElement.FindElement(By.XPath(".//table[./thead/tr/th[text()='Data Consent Tiers']]"), 2);
		}

		public bool DeleteSupplier(string supplierId)
		{
			IWebElement allSuppliers = this.GetSuppliersAsIWebElement();

			IList<IWebElement> rows = allSuppliers.FindElements(By.TagName("tr"), 2);
			foreach (IWebElement row in rows)
			{
				IWebElement tableSupplierId = row.FindElement(By.XPath(".//*[@class='col-sm-3']"), 2);

				if (tableSupplierId.Text == supplierId)
				{
					try
					{
						IWebElement tableActionBtn = row.FindElement(By.XPath(".//span[contains(@class,ellipsis)]"), 2);
						IWebElement dropDown = row.FindElement(By.XPath(".//ul[@class='dropdown-menu']"));
						IWebElement deleteButton = dropDown.FindElement(By.XPath(".//a[contains(@data-bind,'delete')]"));
						tableActionBtn.TryClick();
						deleteButton.TryClick();
						var deleteModal = new DeleteSupplierModal();
						return deleteModal.ClickDeleteSupplierModalWindowButton("Delete");

					}
					catch (Exception e)
					{
						Report.Info("Error trying to delete Supplier " + supplierId + ". Error encountered: " + e.Message);
						return false;
					}
				}
			}
			Report.Info("Supplier " + supplierId + " not found");
			return true;
		}

		public IWebElement GetSuppliersAsIWebElement()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2);
		}

		public List<Supplier> GetAllSuppliers()
		{
			var supplierList = new List<Supplier>();
			IWebElement supplierTable = this.containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2);
			if (supplierTable == null)
			{
				Report.Info("Supplier table has not been found or is empty");
				return supplierList;
			}

			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> supplierRows = supplierTable.FindElements(By.XPath(".//tbody/tr"));

			foreach (IWebElement thisRow in supplierRows)
			{
				var newSupplier = new Supplier {
					SupplierID = thisRow.FindElement(By.XPath(".//td[1]"), 2).GetValue(),
					CompanyOrBrandName = thisRow.FindElement(By.XPath(".//td[2]"), 2).GetValue(),
					IsActive = thisRow.FindElement(By.XPath(".//td[3]/i"), 2).GetAttribute("class")
					.Contains("success"),
					IsDefault = thisRow.FindElement(By.XPath(".//td[4]/i"), 2).GetAttribute("class")
					.Contains("success")
				};

				supplierList.Add(newSupplier);

			}

			return supplierList;
		}

		public bool ClickActionBySupplierID(string sSupplierID, string action = "Deactivate")
		{
			try
			{
				IWebElement supplierTable = this.containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2);
				if (supplierTable == null)
				{
					Report.Info("Supplier table has not been found or is empty");
					return false;
				}

				System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> supplierRows = supplierTable.FindElements(By.XPath(".//tbody/tr"));

				foreach (IWebElement thisRow in supplierRows)
				{
					string SupplierID = thisRow.FindElement(By.XPath(".//td[1]"), 2).GetValue();
					if (sSupplierID == SupplierID)
					{
						if (thisRow.FindElement(By.XPath(".//td[5]//button"), 2).TryClick())
						{
							Delay.Seconds(0.5);
							System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listActions = thisRow.FindElements(By.XPath(".//td[5]//a"));
							IWebElement matchingAction = listActions.FirstOrDefault(x => x.GetValue().Contains(action));
							if (matchingAction == null)
							{
								Report.Info("Could not find expected action link");
								return false;
							}

							if (matchingAction.TryClick())
							{
								return true;
							}
							else
							{
								Report.Info("Failed to click action link: " + action);
								return false;
							}
						}
						else
						{
							Report.Info("Failed to click ... button");
							return false;
						}
					}
				}
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return false;
			}

			return false;
		}

		public bool ConfirmDataTier(string tier, string trueFalse)
		{
			string tierNum = tier.Trim().Split(':')[0];
			IWebElement row = this.DataConsentTiersTable()?.FindElement(By.XPath(@"//tbody//tr//td//div[contains(text(),""" + tierNum + @""")]//..//.."));
			if (row == null)
			{
				return false;
			}
			IWebElement checkbox = row.FindElement(By.XPath("//input[@type='checkbox']"), 2);
			bool Checked = checkbox.Selected;

			if (trueFalse == "true" && !Checked)
			{
				Report.Info("Failed to find correct status of '" + trueFalse + "' for data consent tier '" + tier + "'.");
				return false;
			}
			if (trueFalse == "false" && Checked)
			{
				Report.Info("Failed to find correct status of '" + trueFalse + "' for data consent tier '" + tier + "'.");
				return false;
			}

			Report.Info("Successfully found correct status of '" + trueFalse + "' for data consent tier '" + tier + "'.");
			return true;
		}

		public bool DataTierPresent(string tierName)
		{
			IList<IWebElement> dataConsentRows = this.DataConsentTiersTable()?.FindElements(By.XPath(".//tbody//tr"), 2);
			IWebElement correctRow = dataConsentRows?.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tierName));
			if (correctRow == null)
			{
				return false;
			}
			return true;
		}

		public List<string> ExpectedCVSDataTiers()
		{
			return new List<string> {"Tier 1: Regulatory Support", "Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports", "Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency", "Tier 3: Supplemental Reports", "Tier 4.1: Publicly Disclose Supplemental Reports"};
					
		}

		
	}

	public class DataEntryNotification : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='dataEntryNotifications']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//button[text()='Close']"), 2).TryClick();
		}

		public bool ClickOK()
		{
			return this.containerElement.FindElement(By.XPath(".//button[text()='Ok']"), 2).TryClick();
		}
		public List<string> SuccessMessages()
		{
			IList<IWebElement> messages = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'alert-success')]"), 2);
			if (messages.Count == 0)
			{
				return new List<string>();
			}
			return messages.Select(x => x.Text.Trim()).ToList();
		}
	}

	public class ReportDownload : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='download-modal']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//a[text()='Close']"), 2).TryClick();
		}


	}

	public class DataTierDetails : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='modal in' and @id='data-tiers-details']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickTab(string option)
		{
			return this.containerElement.FindElement(By.XPath($@".//li[@role='presentation']/a[contains(text(),""{option}"")]"), 2).TryClick();
		}

		public string ActiveTab()
		{
			return this.containerElement.FindElement(By.XPath($@".//li[@class='active']/a]"), 2)?.Text;
		}

		public List<string> AllTabs()
		{
			return this.containerElement.FindElements(By.XPath($@".//li[@role='presentation']/a")).Select(x => x.Text).ToList();
		}

		public string Heading()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[not(parent::div[@role])]"), 2)?.Text;
		}

		public string SubHeading()
		{
			return this.containerElement.FindElement(By.XPath(".//h3[(parent::div[@class='tab-pane active'])]"), 2)?.Text;
		}

		public List<KeyValuePair<string, string>> TabParagraphs()
		{
			string chars_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string chars_a = chars_A.ToLower();
			var rList = new List<KeyValuePair<string, string>>();
			IWebElement ol_A = this.containerElement.FindElement(By.XPath("//div[@class='tab-pane active']//ol[@type='A']"), 2);
			string section = "";
			// Get the paragraph/ section elements for A, B...
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> lis_A = ol_A.FindElements(By.XPath("./li"));
			for (int i = 0; i < lis_A.Count; i++)
			{
				IWebElement li_A = lis_A[i];
				section = chars_A[i].ToString();
				rList.Add(new KeyValuePair<string, string>(section, li_A.Text.Trim()));
				// Look for child ol (section 1, 2...)
				IWebElement ol_1 = li_A.FindElement(By.XPath("./ol[@type='1']"), 2);
				if (ol_1 == null)
				{
					// Then the tree ends at A,B..
					continue;
				}
				// Get the paragraph/ section elements for (A/B)1, (A/B)2...
				System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> lis_1 = ol_1.FindElements(By.XPath("./li"));
				for (int j = 0; j < lis_1.Count; j++)
				{
					section = chars_A[i].ToString() + (j + 1);
					IWebElement li_1 = lis_1[j];
					rList.Add(new KeyValuePair<string, string>(section, li_1.Text.Trim()));
					// Look for child ol (a, b...)
					IWebElement ol_a = li_1.FindElement(By.XPath("./ol"), 2);
					if (ol_a == null)
					{
						// Then the tree ends at (A/B)1, (A/B)2..
						continue;
					}
					// Get the paragraph/ section elements for (A/B)1, (A/B)2...
					System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> lis_a = ol_a.FindElements(By.XPath("./li"));
					for (int k = 0; k < lis_a.Count; k++)
					{
						section = chars_A[i].ToString() + (j + 1) + chars_a[k];
						IWebElement li_a = lis_a[k];
						rList.Add(new KeyValuePair<string, string>(section, li_a.Text.Trim()));
					}
				}
			}
			return rList;
		}

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@class='close']"), 2).TryClick();
		}

		public bool ClickDownloadPdfWithHeading(string option)
		{
			return this.containerElement.FindElement(By.XPath($@".//div[@role='tabpanel'][h3[contains(text(),""{option}"")]]/a"), 2).TryClick();
		}
	}

	public class DeleteSupplierModal : SeleniumBaseObject
	{
		public const string BasePath = "//div[contains(@role,'document')]//div[contains(@class,'modal-content')]";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickDeleteSupplierModalWindowButton(string choice)
		{
			IWebElement modalWindow = this.containerElement.WaitUntilElementVisible(By.XPath(BasePath), 2);
			IWebElement modalTitle = modalWindow.FindElement(By.XPath(".//h3[@class='modal-title']"), 10);

			if (modalWindow is null || modalTitle is null)
			{
				Report.Failure("Could not locate Delete Supplier ID modal window.");
				return false;
			}

			Report.IsTrue(modalTitle.Text == "Delete Supplier ID?", "Expected modal window title not found! Found: " + modalTitle.Text, "Modal window title '" + modalTitle.Text + "' located as expected.");
			switch (choice)
			{
				case "Delete":
					IWebElement deleteBtn = modalWindow.FindElement(By.XPath("//button[contains(@data-bind,'yesText')]"), 2);
					return deleteBtn.TryClick();
				case "Cancel":
					IWebElement cancelBtn = modalWindow.FindElement(By.XPath("//button[contains(@data-bind,'noText')]"), 2);
					return cancelBtn.TryClick();
				default:
					Report.Info("'" + choice + "' button not available in modal window. Only 'Delete' and 'Cancel' are available.");
					return false;
			}
		}
	}


	public class GoToDataTierNotification : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='modal fade in']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool GoToDataTiersButtonShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='modal-dialog modal-md']//a[contains(text(),'Go to data tiers')]"), 2).Displayed;
		}

		public bool ClickGoToDataTiers()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='modal-dialog modal-md']//a[contains(text(),'Go to data tiers')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

	}

	public class Supplier
	{
		public string SupplierID { get; set; }
		public string CompanyOrBrandName { get; set; }
		public bool IsActive { get; set; }
		public bool IsDefault { get; set; }
	}
}
